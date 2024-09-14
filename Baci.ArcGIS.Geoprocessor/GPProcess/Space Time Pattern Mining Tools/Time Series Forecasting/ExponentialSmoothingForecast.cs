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
	/// <para>Exponential Smoothing Forecast</para>
	/// <para>Exponential Smoothing Forecast</para>
	/// <para>Forecasts the values of each location of a space-time cube using the Holt-Winters exponential smoothing method by decomposing the time series at each location cube into seasonal  and trend components.</para>
	/// </summary>
	public class ExponentialSmoothingForecast : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCube">
		/// <para>Input Space Time Cube</para>
		/// <para>The netCDF cube containing the variable to forecast to future time steps. This file must have an .nc file extension and must have been created using the Create Space Time Cube By Aggregating Points, Create Space Time Cube From Defined Locations, or Create Space Time Cube From Multidimensional Raster Layer tool.</para>
		/// </param>
		/// <param name="AnalysisVariable">
		/// <para>Analysis Variable</para>
		/// <para>The numeric variable in the netCDF file that will be forecasted to future time steps.</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>The output feature class of all locations in the space-time cube with forecasted values stored as fields. The layer displays the forecast for the final time step and contains pop-up charts showing the time series, forecasts, and 90 percent confidence bounds for each location.</para>
		/// </param>
		public ExponentialSmoothingForecast(object InCube, object AnalysisVariable, object OutputFeatures)
		{
			this.InCube = InCube;
			this.AnalysisVariable = AnalysisVariable;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Exponential Smoothing Forecast</para>
		/// </summary>
		public override string DisplayName() => "Exponential Smoothing Forecast";

		/// <summary>
		/// <para>Tool Name : ExponentialSmoothingForecast</para>
		/// </summary>
		public override string ToolName() => "ExponentialSmoothingForecast";

		/// <summary>
		/// <para>Tool Excute Name : stpm.ExponentialSmoothingForecast</para>
		/// </summary>
		public override string ExcuteName() => "stpm.ExponentialSmoothingForecast";

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
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCube, AnalysisVariable, OutputFeatures, OutputCube, NumberOfTimeStepsToForecast, SeasonLength, NumberForValidation, OutlierOption, LevelOfConfidence, MaximumNumberOfOutliers };

		/// <summary>
		/// <para>Input Space Time Cube</para>
		/// <para>The netCDF cube containing the variable to forecast to future time steps. This file must have an .nc file extension and must have been created using the Create Space Time Cube By Aggregating Points, Create Space Time Cube From Defined Locations, or Create Space Time Cube From Multidimensional Raster Layer tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object InCube { get; set; }

		/// <summary>
		/// <para>Analysis Variable</para>
		/// <para>The numeric variable in the netCDF file that will be forecasted to future time steps.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AnalysisVariable { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The output feature class of all locations in the space-time cube with forecasted values stored as fields. The layer displays the forecast for the final time step and contains pop-up charts showing the time series, forecasts, and 90 percent confidence bounds for each location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Output Space Time Cube</para>
		/// <para>A new space-time cube (.nc file) containing the values of the input space-time cube with the forecasted time steps appended. The Visualize Space Time Cube in 3D tool can be used to see all of the observed and forecasted values simultaneously.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object OutputCube { get; set; }

		/// <summary>
		/// <para>Number of Time Steps to Forecast</para>
		/// <para>A positive integer specifying the number of time steps to forecast. This value cannot be larger than 50 percent of the total time steps in the input space-time cube. The default value is one time step.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumberOfTimeStepsToForecast { get; set; } = "1";

		/// <summary>
		/// <para>Season Length</para>
		/// <para>The number of time steps corresponding to one season at each location. If there are multiple seasons in the data, it is recommended that you use the longest season to produce the most reliable result. If no value is specified, a season length will be estimated by the tool at each location using a spectral density function.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object SeasonLength { get; set; }

		/// <summary>
		/// <para>Number of Time Steps to Exclude for Validation</para>
		/// <para>The number of time steps at the end of each time series to exclude for validation. The default value is 10 percent (rounded down) of the number of input time steps, and this value cannot be larger than 25 percent of the number of time steps. Provide the value 0 to not exclude any time steps.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumberForValidation { get; set; }

		/// <summary>
		/// <para>Outlier Option</para>
		/// <para>Specifies whether statistically significant time series outliers will be identified.</para>
		/// <para>None—Outliers will not be identified. This is the default.</para>
		/// <para>Identify outliers—Outliers will be identified using the Generalized ESD test.</para>
		/// <para><see cref="OutlierOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutlierOption { get; set; } = "NONE";

		/// <summary>
		/// <para>Level of Confidence</para>
		/// <para>Specifies the confidence level for the test for time series outliers.</para>
		/// <para>90%—The confidence level for the test is 90 percent. This is the default.</para>
		/// <para>95%—The confidence level for the test is 95 percent.</para>
		/// <para>99%—The confidence level for the test is 99 percent.</para>
		/// <para><see cref="LevelOfConfidenceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LevelOfConfidence { get; set; } = "90%";

		/// <summary>
		/// <para>Maximum Number of Outliers</para>
		/// <para>The maximum number of time steps that can be declared outliers for each location. The default value corresponds to 5 percent (rounded down) of the number of time steps of the input space-time cube (a value of at least 1 will always be used). This value cannot exceed 20 percent of the number of time steps.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MaximumNumberOfOutliers { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExponentialSmoothingForecast SetEnviroment(object outputCoordinateSystem = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Outlier Option</para>
		/// </summary>
		public enum OutlierOptionEnum 
		{
			/// <summary>
			/// <para>None—Outliers will not be identified. This is the default.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>Identify outliers—Outliers will be identified using the Generalized ESD test.</para>
			/// </summary>
			[GPValue("IDENTIFY")]
			[Description("Identify outliers")]
			Identify_outliers,

		}

		/// <summary>
		/// <para>Level of Confidence</para>
		/// </summary>
		public enum LevelOfConfidenceEnum 
		{
			/// <summary>
			/// <para>90%—The confidence level for the test is 90 percent. This is the default.</para>
			/// </summary>
			[GPValue("90%")]
			[Description("90%")]
			_90percent,

			/// <summary>
			/// <para>95%—The confidence level for the test is 95 percent.</para>
			/// </summary>
			[GPValue("95%")]
			[Description("95%")]
			_95percent,

			/// <summary>
			/// <para>99%—The confidence level for the test is 99 percent.</para>
			/// </summary>
			[GPValue("99%")]
			[Description("99%")]
			_99percent,

		}

#endregion
	}
}
