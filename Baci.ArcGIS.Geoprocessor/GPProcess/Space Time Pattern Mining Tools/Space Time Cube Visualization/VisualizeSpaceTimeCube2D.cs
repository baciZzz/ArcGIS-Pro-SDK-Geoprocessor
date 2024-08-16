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
	/// <para>Visualize Space Time Cube in 2D</para>
	/// <para>Visualizes  the variables stored in a netCDF cube and the results generated by the Space Time Pattern Mining tools. Output from this tool is a two-dimensional representation uniquely rendered based on the variable and theme specified.</para>
	/// </summary>
	public class VisualizeSpaceTimeCube2D : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCube">
		/// <para>Input Space Time Cube</para>
		/// <para>The netCDF cube that contains the variable to be displayed. This file must have an .nc extension and must have been created using either the Create Space Time Cube By Aggregating Points, Create Space Time Cube From Defined Locations, or Create Space Time Cube from Multidimensional Raster Layer tool.</para>
		/// </param>
		/// <param name="CubeVariable">
		/// <para>Cube Variable</para>
		/// <para>The numeric variable in the netCDF cube to explore. The space-time cube will always contain the COUNT variable. Any Summary Fields or Variables values will also be available if they were included when the cube was created.</para>
		/// </param>
		/// <param name="DisplayTheme">
		/// <para>Display Theme</para>
		/// <para>Specifies the characteristic of the Cube Variable value to display. Options will vary depending on how the cube was created and the analyses that were run.</para>
		/// <para>If the cube was created by aggregating points, the Locations with data and Trends options will be available. The Number of estimated bins and Locations excluded from analysis options will only be available for those Summary Fields values that were included in the cube creation process.</para>
		/// <para>If the cube was created from defined locations, the Trends option will be available for those Summary Fields or Variables values that were included in the cube creation process.</para>
		/// <para>The Hot and cold spot trends and Emerging Hot Spot Analysis results options will only be available after Emerging Hot Spot Analysis has been run on the selected Cube Variable value. The Percentage of local outliers, Local outlier in the most recent time period, Local Outlier Analysis results, and Locations without spatial neighbors options will only be available when the Local Outlier Analysis tool has been run.</para>
		/// <para>The Forecast results option will only be available for cubes created by tools in the Time Series Forecasting toolset. The Time series outlier results option will only be available when the Outlier Option parameter in the Time Series Forecasting tools has been specified.</para>
		/// <para>For in-depth information about each option, including descriptions of the output and created charts, see the Visualization display themes for the space-time cube topic.</para>
		/// <para>Locations with data—All locations that contain data for the Cube Variable parameter will be displayed.</para>
		/// <para>Trends—The trend of values at each location that were determined using the Mann-Kendall statistic will be displayed.</para>
		/// <para>Hot and cold spot trends—The trend of z-scores at each location that were determined using the Mann-Kendall statistic will be displayed.</para>
		/// <para>Emerging Hot Spot Analysis results—The results of the Emerging Hot Spot Analysis tool for the specified Cube Variable parameter will be displayed.</para>
		/// <para>Local Outlier Analysis results—The results of the Local Outlier Analysis tool for the specified Cube Variable parameter will be displayed.</para>
		/// <para>Percentage of local outliers—The total percentage of outliers at each location will be displayed.</para>
		/// <para>Local outlier in the most recent time period—The outliers occurring in the most recent time period will be displayed.</para>
		/// <para>Time Series Clustering results—The results of the Time Series Clustering tool for the specified Cube Variable parameter will be displayed.</para>
		/// <para>Locations without spatial neighbors—Locations that have no spatial neighbors for the last analysis run will be displayed. These locations rely only on temporal neighbors for analysis.</para>
		/// <para>Number of estimated bins—The number of bins that were estimated for each location will be displayed.</para>
		/// <para>Locations excluded from analysis—The locations that were excluded from analysis because they had empty bins that did not meet the criteria for estimation will be displayed.</para>
		/// <para>Forecast results—The results of the Time Series Forecasting tool used for the specified Analysis Variable parameter will be displayed.</para>
		/// <para>Time series outlier results—The results of the Outlier Option parameter in the Time Series Forecasting tools will be displayed.</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>The output feature class results. This feature class will be a two-dimensional map representation of the specified display variable.</para>
		/// </param>
		public VisualizeSpaceTimeCube2D(object InCube, object CubeVariable, object DisplayTheme, object OutputFeatures)
		{
			this.InCube = InCube;
			this.CubeVariable = CubeVariable;
			this.DisplayTheme = DisplayTheme;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Visualize Space Time Cube in 2D</para>
		/// </summary>
		public override string DisplayName => "Visualize Space Time Cube in 2D";

		/// <summary>
		/// <para>Tool Name : VisualizeSpaceTimeCube2D</para>
		/// </summary>
		public override string ToolName => "VisualizeSpaceTimeCube2D";

		/// <summary>
		/// <para>Tool Excute Name : stpm.VisualizeSpaceTimeCube2D</para>
		/// </summary>
		public override string ExcuteName => "stpm.VisualizeSpaceTimeCube2D";

		/// <summary>
		/// <para>Toolbox Display Name : Space Time Pattern Mining Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Space Time Pattern Mining Tools";

		/// <summary>
		/// <para>Toolbox Alise : stpm</para>
		/// </summary>
		public override string ToolboxAlise => "stpm";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InCube, CubeVariable, DisplayTheme, OutputFeatures, EnableTimeSeriesPopups };

		/// <summary>
		/// <para>Input Space Time Cube</para>
		/// <para>The netCDF cube that contains the variable to be displayed. This file must have an .nc extension and must have been created using either the Create Space Time Cube By Aggregating Points, Create Space Time Cube From Defined Locations, or Create Space Time Cube from Multidimensional Raster Layer tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object InCube { get; set; }

		/// <summary>
		/// <para>Cube Variable</para>
		/// <para>The numeric variable in the netCDF cube to explore. The space-time cube will always contain the COUNT variable. Any Summary Fields or Variables values will also be available if they were included when the cube was created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CubeVariable { get; set; }

		/// <summary>
		/// <para>Display Theme</para>
		/// <para>Specifies the characteristic of the Cube Variable value to display. Options will vary depending on how the cube was created and the analyses that were run.</para>
		/// <para>If the cube was created by aggregating points, the Locations with data and Trends options will be available. The Number of estimated bins and Locations excluded from analysis options will only be available for those Summary Fields values that were included in the cube creation process.</para>
		/// <para>If the cube was created from defined locations, the Trends option will be available for those Summary Fields or Variables values that were included in the cube creation process.</para>
		/// <para>The Hot and cold spot trends and Emerging Hot Spot Analysis results options will only be available after Emerging Hot Spot Analysis has been run on the selected Cube Variable value. The Percentage of local outliers, Local outlier in the most recent time period, Local Outlier Analysis results, and Locations without spatial neighbors options will only be available when the Local Outlier Analysis tool has been run.</para>
		/// <para>The Forecast results option will only be available for cubes created by tools in the Time Series Forecasting toolset. The Time series outlier results option will only be available when the Outlier Option parameter in the Time Series Forecasting tools has been specified.</para>
		/// <para>For in-depth information about each option, including descriptions of the output and created charts, see the Visualization display themes for the space-time cube topic.</para>
		/// <para>Locations with data—All locations that contain data for the Cube Variable parameter will be displayed.</para>
		/// <para>Trends—The trend of values at each location that were determined using the Mann-Kendall statistic will be displayed.</para>
		/// <para>Hot and cold spot trends—The trend of z-scores at each location that were determined using the Mann-Kendall statistic will be displayed.</para>
		/// <para>Emerging Hot Spot Analysis results—The results of the Emerging Hot Spot Analysis tool for the specified Cube Variable parameter will be displayed.</para>
		/// <para>Local Outlier Analysis results—The results of the Local Outlier Analysis tool for the specified Cube Variable parameter will be displayed.</para>
		/// <para>Percentage of local outliers—The total percentage of outliers at each location will be displayed.</para>
		/// <para>Local outlier in the most recent time period—The outliers occurring in the most recent time period will be displayed.</para>
		/// <para>Time Series Clustering results—The results of the Time Series Clustering tool for the specified Cube Variable parameter will be displayed.</para>
		/// <para>Locations without spatial neighbors—Locations that have no spatial neighbors for the last analysis run will be displayed. These locations rely only on temporal neighbors for analysis.</para>
		/// <para>Number of estimated bins—The number of bins that were estimated for each location will be displayed.</para>
		/// <para>Locations excluded from analysis—The locations that were excluded from analysis because they had empty bins that did not meet the criteria for estimation will be displayed.</para>
		/// <para>Forecast results—The results of the Time Series Forecasting tool used for the specified Analysis Variable parameter will be displayed.</para>
		/// <para>Time series outlier results—The results of the Outlier Option parameter in the Time Series Forecasting tools will be displayed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DisplayTheme { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The output feature class results. This feature class will be a two-dimensional map representation of the specified display variable.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Enable Time Series Pop-ups</para>
		/// <para>Specifies whether time series pop-ups will be generated for each output feature. Pop-up charts are not supported for shapefile outputs.</para>
		/// <para>Checked—Time series pop-ups will be generated for each feature in the dataset.</para>
		/// <para>Unchecked—Time series pop-ups will not be generated. This is the default.</para>
		/// <para><see cref="EnableTimeSeriesPopupsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object EnableTimeSeriesPopups { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public VisualizeSpaceTimeCube2D SetEnviroment(object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Enable Time Series Pop-ups</para>
		/// </summary>
		public enum EnableTimeSeriesPopupsEnum 
		{
			/// <summary>
			/// <para>Checked—Time series pop-ups will be generated for each feature in the dataset.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_POPUP")]
			CREATE_POPUP,

			/// <summary>
			/// <para>Unchecked—Time series pop-ups will not be generated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_POPUP")]
			NO_POPUP,

		}

#endregion
	}
}
