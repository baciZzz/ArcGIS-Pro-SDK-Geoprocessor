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
	/// <para>Visualize Space Time Cube in 3D</para>
	/// <para>Visualizes  the variables stored in a netCDF cube created with the Space Time Pattern Mining tools.  Output from this tool is a three-dimensional representation uniquely rendered based on the variable and theme specified.</para>
	/// </summary>
	public class VisualizeSpaceTimeCube3D : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCube">
		/// <para>Input Space Time Cube</para>
		/// <para>The netCDF cube that contains the variable to be displayed. This file must have an .nc extension and must have been created using either the Create Space Time Cube By Aggregating Points or Create Space Time Cube From Defined Locations tool.</para>
		/// </param>
		/// <param name="CubeVariable">
		/// <para>Cube Variable</para>
		/// <para>The numeric variable in the netCDF cube that you want to explore. The space-time cube will always contain the COUNT variable if aggregation was used when creating the cube. Any summary fields or variables will also be available if they were included when the cube was created.</para>
		/// </param>
		/// <param name="DisplayTheme">
		/// <para>Display Theme</para>
		/// <para>Specifies the characteristic of the Cube Variable parameter to be displayed. Options will vary depending on how the cube was created and the analyses that were run.</para>
		/// <para>Value—The numeric value of the Cube Variable parameter will be displayed.</para>
		/// <para>Hot and cold spot results—The statistical significance of each bin will be displayed based on the space-time hot spot analysis run in Emerging Hot Spot Analysis.</para>
		/// <para>Estimated bins—Bins with estimated values will be displayed.</para>
		/// <para>Cluster and outlier results—The cluster or outlier type (COType) for each bin determined by Local Outlier Analysis will be displayed.</para>
		/// <para>Temporal aggregation count—The count of records aggregated into each space-time bin will be displayed.</para>
		/// <para>Forecast results—The input time steps and the resulting forecasted values from the Time Series Forecasting tools will be displayed.</para>
		/// <para>Time series outlier results—The results of the Outlier Option parameter in the Time Series Forecasting tools will be displayed.</para>
		/// <para>Value is the numeric value of the Cube Variable parameter and is always available. Estimated bins values are only available for the summary fields that were included when the cube was created. Hot and cold spot results values will only be available for the Cube Variable parameter value for which Emerging Hot Spot Analysis has been run. Cluster and outlier results values will only be available for Cube Variables for which Local Outlier Analysis has been run. Temporal aggregation count values will only be available for defined location cubes that have been aggregated temporally. Forecast results values will only be available for the Cube Variable parameter value for which a Time Series Forecasting tool has been run. Time series outlier results values will only be available when the Outlier Option parameter has been set for a tool in the the Time Series Forecasting toolset.</para>
		/// <para>For in-depth information about each option, including descriptions of the output and created charts, see the Visualization display themes for the space-time cube topic.</para>
		/// <para><see cref="DisplayThemeEnum"/></para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>The output feature class results. This feature class will be a three-dimensional map representation of the display variable that can be displayed in a 3D scene.</para>
		/// </param>
		public VisualizeSpaceTimeCube3D(object InCube, object CubeVariable, object DisplayTheme, object OutputFeatures)
		{
			this.InCube = InCube;
			this.CubeVariable = CubeVariable;
			this.DisplayTheme = DisplayTheme;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Visualize Space Time Cube in 3D</para>
		/// </summary>
		public override string DisplayName() => "Visualize Space Time Cube in 3D";

		/// <summary>
		/// <para>Tool Name : VisualizeSpaceTimeCube3D</para>
		/// </summary>
		public override string ToolName() => "VisualizeSpaceTimeCube3D";

		/// <summary>
		/// <para>Tool Excute Name : stpm.VisualizeSpaceTimeCube3D</para>
		/// </summary>
		public override string ExcuteName() => "stpm.VisualizeSpaceTimeCube3D";

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
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCube, CubeVariable, DisplayTheme, OutputFeatures };

		/// <summary>
		/// <para>Input Space Time Cube</para>
		/// <para>The netCDF cube that contains the variable to be displayed. This file must have an .nc extension and must have been created using either the Create Space Time Cube By Aggregating Points or Create Space Time Cube From Defined Locations tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object InCube { get; set; }

		/// <summary>
		/// <para>Cube Variable</para>
		/// <para>The numeric variable in the netCDF cube that you want to explore. The space-time cube will always contain the COUNT variable if aggregation was used when creating the cube. Any summary fields or variables will also be available if they were included when the cube was created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CubeVariable { get; set; }

		/// <summary>
		/// <para>Display Theme</para>
		/// <para>Specifies the characteristic of the Cube Variable parameter to be displayed. Options will vary depending on how the cube was created and the analyses that were run.</para>
		/// <para>Value—The numeric value of the Cube Variable parameter will be displayed.</para>
		/// <para>Hot and cold spot results—The statistical significance of each bin will be displayed based on the space-time hot spot analysis run in Emerging Hot Spot Analysis.</para>
		/// <para>Estimated bins—Bins with estimated values will be displayed.</para>
		/// <para>Cluster and outlier results—The cluster or outlier type (COType) for each bin determined by Local Outlier Analysis will be displayed.</para>
		/// <para>Temporal aggregation count—The count of records aggregated into each space-time bin will be displayed.</para>
		/// <para>Forecast results—The input time steps and the resulting forecasted values from the Time Series Forecasting tools will be displayed.</para>
		/// <para>Time series outlier results—The results of the Outlier Option parameter in the Time Series Forecasting tools will be displayed.</para>
		/// <para>Value is the numeric value of the Cube Variable parameter and is always available. Estimated bins values are only available for the summary fields that were included when the cube was created. Hot and cold spot results values will only be available for the Cube Variable parameter value for which Emerging Hot Spot Analysis has been run. Cluster and outlier results values will only be available for Cube Variables for which Local Outlier Analysis has been run. Temporal aggregation count values will only be available for defined location cubes that have been aggregated temporally. Forecast results values will only be available for the Cube Variable parameter value for which a Time Series Forecasting tool has been run. Time series outlier results values will only be available when the Outlier Option parameter has been set for a tool in the the Time Series Forecasting toolset.</para>
		/// <para>For in-depth information about each option, including descriptions of the output and created charts, see the Visualization display themes for the space-time cube topic.</para>
		/// <para><see cref="DisplayThemeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DisplayTheme { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The output feature class results. This feature class will be a three-dimensional map representation of the display variable that can be displayed in a 3D scene.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public VisualizeSpaceTimeCube3D SetEnviroment(object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Display Theme</para>
		/// </summary>
		public enum DisplayThemeEnum 
		{
			/// <summary>
			/// <para>Value—The numeric value of the Cube Variable parameter will be displayed.</para>
			/// </summary>
			[GPValue("VALUE")]
			[Description("Value")]
			Value,

			/// <summary>
			/// <para>Hot and cold spot results—The statistical significance of each bin will be displayed based on the space-time hot spot analysis run in Emerging Hot Spot Analysis.</para>
			/// </summary>
			[GPValue("HOT_AND_COLD_SPOT_RESULTS")]
			[Description("Hot and cold spot results")]
			Hot_and_cold_spot_results,

			/// <summary>
			/// <para>Cluster and outlier results—The cluster or outlier type (COType) for each bin determined by Local Outlier Analysis will be displayed.</para>
			/// </summary>
			[GPValue("LOCAL_OUTLIER_RESULTS")]
			[Description("Cluster and outlier results")]
			Cluster_and_outlier_results,

			/// <summary>
			/// <para>Estimated bins—Bins with estimated values will be displayed.</para>
			/// </summary>
			[GPValue("ESTIMATED_BINS")]
			[Description("Estimated bins")]
			Estimated_bins,

			/// <summary>
			/// <para>Temporal aggregation count—The count of records aggregated into each space-time bin will be displayed.</para>
			/// </summary>
			[GPValue("TEMPORAL_AGGREGATION_COUNT")]
			[Description("Temporal aggregation count")]
			Temporal_aggregation_count,

			/// <summary>
			/// <para>Forecast results—The input time steps and the resulting forecasted values from the Time Series Forecasting tools will be displayed.</para>
			/// </summary>
			[GPValue("FORECAST_RESULTS")]
			[Description("Forecast results")]
			Forecast_results,

			/// <summary>
			/// <para>Time series outlier results—The results of the Outlier Option parameter in the Time Series Forecasting tools will be displayed.</para>
			/// </summary>
			[GPValue("TIME_SERIES_OUTLIER_RESULTS")]
			[Description("Time series outlier results")]
			Time_series_outlier_results,

		}

#endregion
	}
}
