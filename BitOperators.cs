#region usings
using System;
using System.ComponentModel.Composition;

using VVVV.PluginInterfaces.V1;
using VVVV.PluginInterfaces.V2;
using VVVV.Utils.VColor;
using VVVV.Utils.VMath;

using VVVV.Core.Logging;
#endregion usings

namespace VVVV.Nodes
{
	#region PluginInfo
	[PluginInfo(Name = "MSB", Category = "Value", Version = "1", Help = "Basic template with one value in/out", Tags = "")]
	#endregion PluginInfo
	public class MSB : IPluginEvaluate
	{
		#region fields & pins
		[Input("Input", DefaultValue = 0)]
		IDiffSpread<int> FInput;
		
		[Input("NumBits", DefaultValue = 8, MaxValue = 8, MinValue=0, Visibility = PinVisibility.Hidden,IsSingle=true)]
		IDiffSpread<int> NumBits;
		
		[Output("MSB")]
		ISpread<int> FOutput;
		#endregion fields & pins
		
		//called when data for any output pin is requested
		public void Evaluate(int SpreadMax)
		{
			if(!FInput.IsChanged && NumBits.IsChanged) return;
			FOutput.SliceCount = SpreadMax;
			int shift,mask;
			shift = (9-NumBits[0])-1;
			mask  = 0xff>>shift;
			for (int i = 0; i < SpreadMax; i++)
			FOutput[i] = (FInput[i]>>NumBits[i])& mask;
			
		}
	}
	
	
	#region PluginInfo
	[PluginInfo(Name = "LSB", Category = "Value", Version = "1", Help = "Basic template with one value in/out", Tags = "")]
	#endregion PluginInfo
	public class LSB : IPluginEvaluate
	{
		#region fields & pins
		[Input("Input", DefaultValue = 0)]
		IDiffSpread<int> FInput;
		
		[Input("NumBits", DefaultValue = 8, MaxValue = 8, MinValue=0, Visibility = PinVisibility.Hidden,IsSingle=true)]
		IDiffSpread<int> NumBits;
		
		[Output("LSB")]
		ISpread<int> FOutput;
		#endregion fields & pins
		
		//called when data for any output pin is requested
		public void Evaluate(int SpreadMax)
		{
			if(!FInput.IsChanged && NumBits.IsChanged) return;
			FOutput.SliceCount = SpreadMax;
			int shift,mask;
			shift = (9-NumBits[0])-1;
			mask  = 0xff>>shift;
			for (int i = 0; i < SpreadMax; i++)
			FOutput[i] = FInput[i]&mask;
			
		}
	}
	
	#region PluginInfo
	[PluginInfo(Name = "LSB+MSB", Category = "Value", Version = "1", Help = "Basic template with one value in/out", Tags = "")]
	#endregion PluginInfo
	public class PackLSBMSB : IPluginEvaluate
	{
		#region fields & pins
		[Input("LSB", DefaultValue = 0)]
		IDiffSpread<int> LSB;

		[Input("NumBits", DefaultValue = 8, MaxValue = 8, MinValue=0, Visibility = PinVisibility.Hidden,IsSingle=true)]
		IDiffSpread<int> NumBits;
		
		[Input("MSB", DefaultValue = 0)]
		IDiffSpread<int> MSB;
		
		[Output("Shifted")]
		ISpread<int> FOutput;
		#endregion fields & pins
		
		//called when data for any output pin is requested
		public void Evaluate(int SpreadMax)
		{
			if(!LSB.IsChanged && MSB.IsChanged && !NumBits.IsChanged) return;
			FOutput.SliceCount = MSB.SliceCount>LSB.SliceCount ? LSB.SliceCount:MSB.SliceCount;
			int shift,mask;
			shift = (9-NumBits[0])-1;
			mask  = 0xff>>shift;
			for (int i = 0; i < FOutput.SliceCount; i++)
			{
				int temp = MSB[i] & mask;
				temp = temp << NumBits[i];
				temp = temp | (LSB[i]&mask);
				FOutput[i] = temp;
			}
			
		}
	}
	
	#region PluginInfo
	[PluginInfo(Name = "<<", Category = "Value", Version = "1", Help = "Basic template with one value in/out", Tags = "")]
	#endregion PluginInfo
	public class Shiftleft : IPluginEvaluate
	{
		#region fields & pins
		[Input("Input", DefaultValue = 0)]
		ISpread<int> FInput;
		
		[Input("Steps", DefaultValue = 0)]
		ISpread<int> StepInput;
		
		[Output("Shifted")]
		ISpread<int> FOutput;
		#endregion fields & pins
		
		//called when data for any output pin is requested
		public void Evaluate(int SpreadMax)
		{
			FOutput.SliceCount = SpreadMax;
			
			for (int i = 0; i < SpreadMax; i++)
				FOutput[i] = FInput[i]<<StepInput[i];
			
		}
	}
	
	#region PluginInfo
	[PluginInfo(Name = ">>", Category = "Value", Version = "1", Help = "Basic template with one value in/out", Tags = "")]
	#endregion PluginInfo
	public class Shiftright : IPluginEvaluate
	{
		#region fields & pins
		[Input("Input", DefaultValue = 0)]
		IDiffSpread<int> FInput;
		
		[Input("Steps", DefaultValue = 0)]
		IDiffSpread<int> StepInput;
		
		[Output("Shifted")]
		ISpread<int> FOutput;
		#endregion fields & pins
		
		//called when data for any output pin is requested
		public void Evaluate(int SpreadMax)
		{
			if(!FInput.IsChanged && !StepInput.IsChanged) return;
			FOutput.SliceCount = SpreadMax;
			
			for (int i = 0; i < SpreadMax; i++)
				FOutput[i] = FInput[i]>>StepInput[i];
			
		}
	}
	
	#region PluginInfo
	[PluginInfo(Name = "&", Category = "Value", Version = "1", Help = "Basic template with one value in/out", Tags = "")]
	#endregion PluginInfo
	public class BitAND : IPluginEvaluate
	{
		#region fields & pins
		[Input("Input", DefaultValue = 0)]
		IDiffSpread<int> FInput;
		
		[Input("Input2", DefaultValue = 0)]
		IDiffSpread<int> FInput2;
		
		[Output("Result")]
		ISpread<int> FOutput;
		#endregion fields & pins
		
		//called when data for any output pin is requested
		public void Evaluate(int SpreadMax)
		{
			if(!FInput.IsChanged && !FInput2.IsChanged) return;
			FOutput.SliceCount = SpreadMax;
			
			for (int i = 0; i < SpreadMax; i++)
			FOutput[i] = FInput[i]&FInput2[i];
			
		}
	}
	#region PluginInfo
	[PluginInfo(Name = "&", Category = "Value", Version = "Spectral", Help = "Basic template with one value in/out", Tags = "")]
	#endregion PluginInfo
	public class BitANDSpectral : IPluginEvaluate
	{
		#region fields & pins
		[Input("Input", DefaultValue = 0)]
		IDiffSpread<int> FInput;
		
		[Output("Result")]
		ISpread<int> FOutput;
		#endregion fields & pins
		
		//called when data for any output pin is requested
		public void Evaluate(int SpreadMax)
		{
			if(!FInput.IsChanged) return;
			FOutput.SliceCount = 1;
			int result = 0;
			for (int i = 0; i < SpreadMax; i++)
				result &= FInput[i];
			FOutput[0] = result;
			
		}
	}
	
	#region PluginInfo
	[PluginInfo(Name = "|", Category = "Value", Version = "1", Help = "Basic template with one value in/out", Tags = "")]
	#endregion PluginInfo
	public class BitOR : IPluginEvaluate
	{
		#region fields & pins
		[Input("Input", DefaultValue = 0)]
		IDiffSpread<int> FInput;
		
		[Input("Input2", DefaultValue = 0)]
		IDiffSpread<int> FInput2;
		
		[Output("Result")]
		ISpread<int> FOutput;
		#endregion fields & pins
		
		//called when data for any output pin is requested
		public void Evaluate(int SpreadMax)
		{
			if(!FInput.IsChanged && !FInput2.IsChanged) return;
			FOutput.SliceCount = SpreadMax;
			
			for (int i = 0; i < SpreadMax; i++)
			FOutput[i] = FInput[i]|FInput2[i];
			
		}
	}

		#region PluginInfo
	[PluginInfo(Name = "|", Category = "Value", Version = "Spectral", Help = "Basic template with one value in/out", Tags = "")]
	#endregion PluginInfo
	public class BitOrSpectral : IPluginEvaluate
	{
		#region fields & pins
		[Input("Input", DefaultValue = 0)]
		IDiffSpread<int> FInput;
		
		[Output("Result")]
		ISpread<int> FOutput;
		#endregion fields & pins
		
		//called when data for any output pin is requested
		public void Evaluate(int SpreadMax)
		{
			if(!FInput.IsChanged) return;
			FOutput.SliceCount = 1;
			int result = 0;
			for (int i = 0; i < SpreadMax; i++)
				result |= FInput[i];
			FOutput[0] = result;
			
		}
	}

	
	#region PluginInfo
	[PluginInfo(Name = "~", Category = "Value", Version = "1", Help = "Basic template with one value in/out", Tags = "")]
	#endregion PluginInfo
	public class BitNOT : IPluginEvaluate
	{
		#region fields & pins
		[Input("Input", DefaultValue = 0)]
		IDiffSpread<int> FInput;
		
		[Output("Result")]
		ISpread<int> FOutput;
		#endregion fields & pins
		
		//called when data for any output pin is requested
		public void Evaluate(int SpreadMax)
		{
			if(!FInput.IsChanged) return;
			FOutput.SliceCount = SpreadMax;
			
			for (int i = 0; i < SpreadMax; i++)
			FOutput[i] = ~FInput[i];
			
		}
	}
	
	#region PluginInfo
	[PluginInfo(Name = "^", Category = "Value", Version = "1", Help = "Basic template with one value in/out", Tags = "")]
	#endregion PluginInfo
	public class BitXOR : IPluginEvaluate
	{
		#region fields & pins
		[Input("Input", DefaultValue = 0)]
		IDiffSpread<int> FInput;
		
		[Input("Input2", DefaultValue = 0)]
		IDiffSpread<int> FInput2;
		
		[Output("Result")]
		ISpread<int> FOutput;
		#endregion fields & pins
		
		//called when data for any output pin is requested
		public void Evaluate(int SpreadMax)
		{
			if(!FInput.IsChanged && !FInput2.IsChanged) return;
			FOutput.SliceCount = SpreadMax;
			for (int i = 0; i < SpreadMax; i++)
			FOutput[i] = FInput[i] ^ FInput2[i];
			
		}
	}
	
	#region PluginInfo
	[PluginInfo(Name = "FastBit", Category = "Value", Version = "1", Help = "Basic template with one value in/out", Tags = "")]
	#endregion PluginInfo
	public class FastBit : IPluginEvaluate
	{
		#region fields & pins
		[Input("Input", DefaultValue = 0)]
		IDiffSpread<int> FInput;
		
		[Input("BitSize", DefaultValue = 8,IsSingle = true)]
		IDiffSpread<int> BitSize;
		
		[Output("Result")]
		ISpread<int> FOutput;
		#endregion fields & pins
		
		//called when data for any output pin is requested
		public void Evaluate(int SpreadMax)
		{
			if(!FInput.IsChanged && !BitSize.IsChanged) return;
			FOutput.SliceCount = SpreadMax * BitSize[0];
			for (int i = 0; i < FOutput.SliceCount; i++)
			{
				int bi=0;
				for (; bi<BitSize[i]; bi++)
				FOutput[bi+(i*BitSize[i])] = (FInput[i]>>bi)&0x01;
			}
			
			
		}
	}
	
	
}
