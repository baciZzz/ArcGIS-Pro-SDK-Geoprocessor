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
	/// <para>Evaluate Forecasts By Location</para>
	/// <para>Evaluate Forecasts By Location</para>
	/// <para>Selects the most accurate among multiple forecasting results for each location of a space-time cube. This allows you to use multiple tools in the Time Series Forecasting toolset with the same time series data and select the best forecast for each location.</para>
	/// </summary>
	public class EvaluateForecastsByLocation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCubes">
		/// <para>Input Forecast Space Time Cubes</para>
		/// <para>The input space-time cubes containing forecasts to be compared. To be compared, all forecast cubes must be created from the same original time series data.</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>The new output feature class representing the locations of the space-time cube and fields containing the forecast values of the selected method at each location. The pop-ups of the features display charts of the original time series data and the forecasts of all methods.</para>
		/// </param>
		public EvaluateForecastsByLocation(object InCubes, object OutputFeatures)
		{
			this.InCubes = InCubes;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Evaluate Forecasts By Location</para>
		/// </summary>
		public override string DisplayName() => "Evaluate Forecasts By Location";

		/// <summary>
		/// <para>Tool Name : EvaluateForecastsByLocation</para>
		/// </summary>
		public override string ToolName() => "EvaluateForecastsByLocation";

		/// <summary>
		/// <para>Tool Excute Name : stpm.EvaluateForecastsByLocation</para>
		/// </summary>
		public override string ExcuteName() => "stpm.EvaluateForecastsByLocation";

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
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCubes, OutputFeatures, OutputCube!, EvaluateUsingValidationResults! };

		/// <summary>
		/// <para>Input Forecast Space Time Cubes</para>
		/// <para>The input space-time cubes containing forecasts to be compared. To be compared, all forecast cubes must be created from the same original time series data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object InCubes { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The new output feature class representing the locations of the space-time cube and fields containing the forecast values of the selected method at each location. The pop-ups of the features display charts of the original time series data and the forecasts of all methods.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Output Space Time Cube</para>
		/// <para>The output space-time cube (.nc file) containing the original time series data with the forecasts of the selected method at each location. The Visualize Space Time Cube in 3D tool can be used to view the original and forecasted values simultaneously.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object? OutputCube { get; set; }

		/// <summary>
		/// <para>Evaluate Using Validation Results</para>
		/// <para>Specifies whether the forecast method for a location will be determined using the smallest Validation RMSE or smallest Forecast RMSE.</para>
		/// <para>Checked—The forecast method will be determined using the smallest Validation RMSE. This is the default.</para>
		/// <para>Unchecked—The forecast method will be determined using the smallest Forecast RMSE.</para>
		/// <para><see cref="EvaluateUsingValidationResultsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? EvaluateUsingValidationResults { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EvaluateForecastsByLocation SetEnviroment(object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Evaluate Using Validation Results</para>
		/// </summary>
		public enum EvaluateUsingValidationResultsEnum 
		{
			/// <summary>
			/// <para>Checked—The forecast method will be determined using the smallest Validation RMSE. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_VALIDATION")]
			USE_VALIDATION,

			/// <summary>
			/// <para>Unchecked—The forecast method will be determined using the smallest Forecast RMSE.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_VALIDATION")]
			NO_VALIDATION,

		}

#endregion
	}
}
