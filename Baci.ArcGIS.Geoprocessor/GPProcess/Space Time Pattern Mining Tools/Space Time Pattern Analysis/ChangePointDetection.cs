using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpaceTimePatternMiningTools
{
	/// <summary>
	/// <para>Change Point Detection</para>
	/// <para>Change Point Detection</para>
	/// <para>Detects time steps when a statistical property of the time series changes for each location of a space-time cube.</para>
	/// </summary>
	public class ChangePointDetection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCube">
		/// <para>Input Space Time Cube</para>
		/// <para>The space-time cube containing the variable to be analyzed. Space-time cubes have a .nc file extension and are created using various tools in the Space Time Pattern Mining toolbox.</para>
		/// </param>
		/// <param name="AnalysisVariable">
		/// <para>Analysis Variable</para>
		/// <para>The numeric variable of the space-time cube containing the time series values of each location.</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>The output feature class that will contain the change point detection results. The layer displays the number of change points detected at each location and contains pop-up line charts showing the time series values, change points, and estimates of mean or standard deviation of each segment.</para>
		/// </param>
		public ChangePointDetection(object InCube, object AnalysisVariable, object OutputFeatures)
		{
			this.InCube = InCube;
			this.AnalysisVariable = AnalysisVariable;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Change Point Detection</para>
		/// </summary>
		public override string DisplayName() => "Change Point Detection";

		/// <summary>
		/// <para>Tool Name : ChangePointDetection</para>
		/// </summary>
		public override string ToolName() => "ChangePointDetection";

		/// <summary>
		/// <para>Tool Excute Name : stpm.ChangePointDetection</para>
		/// </summary>
		public override string ExcuteName() => "stpm.ChangePointDetection";

		/// <summary>
		/// <para>Toolbox Display Name : Space Time Pattern Mining Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Space Time Pattern Mining Tools";

		/// <summary>
		/// <para>Toolbox Alise : stpm</para>
		/// </summary>
		public override string ToolboxAlise() => "stpm";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCube, AnalysisVariable, OutputFeatures, ChangeType!, Method!, NumChangePoints!, Sensitivity!, MinSegLen! };

		/// <summary>
		/// <para>Input Space Time Cube</para>
		/// <para>The space-time cube containing the variable to be analyzed. Space-time cubes have a .nc file extension and are created using various tools in the Space Time Pattern Mining toolbox.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object InCube { get; set; }

		/// <summary>
		/// <para>Analysis Variable</para>
		/// <para>The numeric variable of the space-time cube containing the time series values of each location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object AnalysisVariable { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The output feature class that will contain the change point detection results. The layer displays the number of change points detected at each location and contains pop-up line charts showing the time series values, change points, and estimates of mean or standard deviation of each segment.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Change Type</para>
		/// <para>Specifies the type of change that will be detected. Each option specifies a statistical property of the time series that is assumed to be constant in each segment. The value changes to a new constant value at each change point in the time series.</para>
		/// <para>Mean shift—Shifts in mean value will be detected. This is the default.</para>
		/// <para>Standard deviation—Changes in standard deviation will be detected.</para>
		/// <para>Slope (Linear trend)—Changes in slope (linear trend) will be detected.</para>
		/// <para>Count—Changes in the mean of count data will be detected.</para>
		/// <para><see cref="ChangeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ChangeType { get; set; } = "MEAN";

		/// <summary>
		/// <para>Method</para>
		/// <para>Specifies whether the number of change points will be detected automatically or specified by a defined number of change points used for all locations.</para>
		/// <para>Auto-detect number of change points (PELT)—The number of change points will be detected automatically. The sensitivity of the detection will be defined by the Detection Sensitivity parameter. This is the default.</para>
		/// <para>Defined number of change points (SegNeigh)—The number of change points will be defined by the Number of Change Points parameter.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "AUTO_DETECT";

		/// <summary>
		/// <para>Number of Change Points</para>
		/// <para>The number of change points that will be detected at each location. The default is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumChangePoints { get; set; } = "1";

		/// <summary>
		/// <para>Detection Sensitivity</para>
		/// <para>A number between 0 and 1 that defines the sensitivity of the detection. Larger values will result in more detected change points at each location. The default is 0.5.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 1)]
		public object? Sensitivity { get; set; } = "0.5";

		/// <summary>
		/// <para>Minimum Segment Length</para>
		/// <para>The minimum number of time steps within each segment. The change points will divide each time series into segments in which each segment has at least this number of time steps. For change in mean, standard deviation, and count, the default is 1, meaning that every time step can be a change point. For change in slope (linear trend), the default is 2 because at least two values are required to fit a line. The value must be less than half the number of time steps in the time series.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MinSegLen { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ChangePointDetection SetEnviroment(object? outputCoordinateSystem = null, object? parallelProcessingFactor = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Change Type</para>
		/// </summary>
		public enum ChangeTypeEnum 
		{
			/// <summary>
			/// <para>Mean shift—Shifts in mean value will be detected. This is the default.</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("Mean shift")]
			Mean_shift,

			/// <summary>
			/// <para>Standard deviation—Changes in standard deviation will be detected.</para>
			/// </summary>
			[GPValue("STANDARD_DEVIATION")]
			[Description("Standard deviation")]
			Standard_deviation,

			/// <summary>
			/// <para>Slope (Linear trend)—Changes in slope (linear trend) will be detected.</para>
			/// </summary>
			[GPValue("SLOPE")]
			[Description("Slope (Linear trend)")]
			SLOPE,

			/// <summary>
			/// <para>Count—Changes in the mean of count data will be detected.</para>
			/// </summary>
			[GPValue("COUNT")]
			[Description("Count")]
			Count,

		}

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Auto-detect number of change points (PELT)—The number of change points will be detected automatically. The sensitivity of the detection will be defined by the Detection Sensitivity parameter. This is the default.</para>
			/// </summary>
			[GPValue("AUTO_DETECT")]
			[Description("Auto-detect number of change points (PELT)")]
			AUTO_DETECT,

			/// <summary>
			/// <para>Defined number of change points (SegNeigh)—The number of change points will be defined by the Number of Change Points parameter.</para>
			/// </summary>
			[GPValue("DEFINED_NUMBER")]
			[Description("Defined number of change points (SegNeigh)")]
			DEFINED_NUMBER,

		}

#endregion
	}
}
