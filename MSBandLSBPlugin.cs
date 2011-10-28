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
		ISpread<int> FInput;

		[Output("MSB")]
		ISpread<int> FOutput;
		#endregion fields & pins

		//called when data for any output pin is requested
		public void Evaluate(int SpreadMax)
		{
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
		ISpread<int> FInput;

		[Output("LSB")]
		ISpread<int> FOutput;
		#endregion fields & pins

		//called when data for any output pin is requested
		public void Evaluate(int SpreadMax)
		{
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
				FOutput[i] = FInput[i]>>StepInput[0];

		}
	}
	
}
