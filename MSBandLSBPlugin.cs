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
		[Input("Input", DefaultValue = 1.0)]
		IDiffSpread<int> FInput;
		
		[Output("MSB")]
		ISpread<int> FOutput;
		#endregion fields & pins
		
		//called when data for any output pin is requested
		public void Evaluate(int SpreadMax)
		{
			if(!FInput.IsChanged) return;
			FOutput.SliceCount = SpreadMax;
			
			for (int i = 0; i < SpreadMax; i++)
			FOutput[i] = (byte)((((int)FInput[i])>>7)&0xff);
			
		}
	}
	
	
	#region PluginInfo
	[PluginInfo(Name = "LSB", Category = "Value", Version = "1", Help = "Basic template with one value in/out", Tags = "")]
	#endregion PluginInfo
	public class LSB : IPluginEvaluate
	{
		#region fields & pins
		[Input("Input", DefaultValue = 1.0)]
		IDiffSpread<int> FInput;
		
		[Output("LSB")]
		ISpread<int> FOutput;
		#endregion fields & pins
		
		//called when data for any output pin is requested
		public void Evaluate(int SpreadMax)
		{
			if(!FInput.IsChanged) return;
			FOutput.SliceCount = SpreadMax;
			
			for (int i = 0; i < SpreadMax; i++)
			FOutput[i] = FInput[i]&0xFF;
			
		}
	}
	
	
	#region PluginInfo
	[PluginInfo(Name = "Shiftleft", Category = "Value", Version = "1", Help = "Basic template with one value in/out", Tags = "")]
	#endregion PluginInfo
	public class Shiftleft : IPluginEvaluate
	{
		#region fields & pins
		[Input("Input", DefaultValue = 1.0)]
		ISpread<int> FInput;
		
		[Input("Steps", DefaultValue = 0, IsSingle=true)]
		ISpread<int> StepInput;
		
		[Output("Shifted")]
		ISpread<int> FOutput;
		#endregion fields & pins
		
		//called when data for any output pin is requested
		public void Evaluate(int SpreadMax)
		{
			FOutput.SliceCount = SpreadMax;
			
			for (int i = 0; i < SpreadMax; i++)
			FOutput[i] = FInput[i]<<StepInput[0];
			
		}
	}
	
	#region PluginInfo
	[PluginInfo(Name = "Shiftright", Category = "Value", Version = "1", Help = "Basic template with one value in/out", Tags = "")]
	#endregion PluginInfo
	public class Shiftright : IPluginEvaluate
	{
		#region fields & pins
		[Input("Input", DefaultValue = 1.0)]
		IDiffSpread<int> FInput;
		
		[Input("Steps", DefaultValue = 0, IsSingle=true)]
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
			FOutput[i] = FInput[i]>>StepInput[0];
			
		}
	}
	
	#region PluginInfo
	[PluginInfo(Name = "BitAND", Category = "Value", Version = "1", Help = "Basic template with one value in/out", Tags = "")]
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
			FOutput[i] = FInput[i]&FInput2[0];
			
		}
	}
	
	#region PluginInfo
	[PluginInfo(Name = "BitOR", Category = "Value", Version = "1", Help = "Basic template with one value in/out", Tags = "")]
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
			FOutput[i] = FInput[i]|FInput2[0];
			
		}
	}

	
	#region PluginInfo
	[PluginInfo(Name = "BitNOT", Category = "Value", Version = "1", Help = "Basic template with one value in/out", Tags = "")]
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
	[PluginInfo(Name = "BitXOR", Category = "Value", Version = "1", Help = "Basic template with one value in/out", Tags = "")]
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
		ISpread<int> BitSize;
		
		[Output("Result")]
		ISpread<int> FOutput;
		#endregion fields & pins
		
		//called when data for any output pin is requested
		public void Evaluate(int SpreadMax)
		{
			if(!FInput.IsChanged) return;
			FOutput.SliceCount = SpreadMax * BitSize[0];
			for (int i = 0; i < FOutput.SliceCount; i++)
			{
				int bi=0;
				for (; bi<BitSize[0]; bi++)
					FOutput[bi+(i*BitSize[0])] = (FInput[i]>>bi)&0x01;
			}
			
			
		}
	}


}
