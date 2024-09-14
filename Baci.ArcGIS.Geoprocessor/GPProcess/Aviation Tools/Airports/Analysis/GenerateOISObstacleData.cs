using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AviationTools
{
	/// <summary>
	/// <para>Generate OIS Obstacle Data</para>
	/// <para>Generate OIS Obstacle Data</para>
	/// <para>Generates a JSON string that is stored in the OBSTACLEJSON field on the input Obstruction Identification Surface (OIS) multipatch feature class. This class contains the data necessary to depict obstacles to safety of flight within the approach surfaces (in the form of points, lines, or polygons) in the Terrain and Obstacle Profile layout element.</para>
	/// </summary>
	public class GenerateOISObstacleData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRunwayFeatures">
		/// <para>Input Runway Features</para>
		/// <para>The input runway dataset. The feature class must be z-enabled and contain polylines.</para>
		/// </param>
		/// <param name="InObstacleFeatures">
		/// <para>Input Obstacle Features</para>
		/// <para>The input obstacle features that will be analyzed. The feature class must be z-enabled.</para>
		/// </param>
		/// <param name="TargetOisFeatures">
		/// <para>Target OIS Features</para>
		/// <para>The multipatch features with defined airport data model schema. The feature class must be z-enabled.</para>
		/// </param>
		public GenerateOISObstacleData(object InRunwayFeatures, object InObstacleFeatures, object TargetOisFeatures)
		{
			this.InRunwayFeatures = InRunwayFeatures;
			this.InObstacleFeatures = InObstacleFeatures;
			this.TargetOisFeatures = TargetOisFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate OIS Obstacle Data</para>
		/// </summary>
		public override string DisplayName() => "Generate OIS Obstacle Data";

		/// <summary>
		/// <para>Tool Name : GenerateOISObstacleData</para>
		/// </summary>
		public override string ToolName() => "GenerateOISObstacleData";

		/// <summary>
		/// <para>Tool Excute Name : aviation.GenerateOISObstacleData</para>
		/// </summary>
		public override string ExcuteName() => "aviation.GenerateOISObstacleData";

		/// <summary>
		/// <para>Toolbox Display Name : Aviation Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Aviation Tools";

		/// <summary>
		/// <para>Toolbox Alise : aviation</para>
		/// </summary>
		public override string ToolboxAlise() => "aviation";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRunwayFeatures, InDems!, InObstacleFeatures, TargetOisFeatures, ObstacleHeightField!, ObstacleHeightUnit!, InFlightpathFeatures!, OutOisFeatures!, LabelField!, HeightOption!, ElevationOption!, ElevationField!, ElevationFieldUnit!, ObstacleOutputMethod!, ShadowHorizontalDistance!, ShadowSlope! };

		/// <summary>
		/// <para>Input Runway Features</para>
		/// <para>The input runway dataset. The feature class must be z-enabled and contain polylines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InRunwayFeatures { get; set; }

		/// <summary>
		/// <para>Input Elevation Model</para>
		/// <para>The DEMs covering the obstacles that will be used to derive base elevation values. This parameter is used if Elevation Source is set to Elevation DEM.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? InDems { get; set; }

		/// <summary>
		/// <para>Input Obstacle Features</para>
		/// <para>The input obstacle features that will be analyzed. The feature class must be z-enabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline", "Polygon")]
		public object InObstacleFeatures { get; set; }

		/// <summary>
		/// <para>Target OIS Features</para>
		/// <para>The multipatch features with defined airport data model schema. The feature class must be z-enabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("MultiPatch")]
		public object TargetOisFeatures { get; set; }

		/// <summary>
		/// <para>Obstacle Height</para>
		/// <para>Specifies the field that will contain the height of the obstacle features or the keyword FEATURE_GEOMETRY to indicate obstacle feature geometry z-coordinate values.</para>
		/// <para>Feature Geometry—The field that will contain the height of the obstacle features.</para>
		/// <para><see cref="ObstacleHeightFieldEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ObstacleHeightField { get; set; } = "FEATURE_GEOMETRY";

		/// <summary>
		/// <para>Unit</para>
		/// <para>Specifies the obstacle height unit of measure that will be used.</para>
		/// <para>Kilometers—The unit will be kilometers.</para>
		/// <para>Meters—The unit will be meters.</para>
		/// <para>Decimeters—The unit will be decimeters.</para>
		/// <para>Centimeters—The unit will be centimeters.</para>
		/// <para>Millimeters—The unit will be millimeters.</para>
		/// <para>Nautical Miles—The unit will be nautical miles.</para>
		/// <para>Miles—The unit will be miles.</para>
		/// <para>Yards—The unit will be yards.</para>
		/// <para>Feet—The unit will be feet.</para>
		/// <para>Inches—The unit will be inches</para>
		/// <para>Decimal Degrees—The unit will be decimal degrees.</para>
		/// <para>Points—The unit will be points.</para>
		/// <para>Unknown—The unit will be unknown.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ObstacleHeightUnit { get; set; } = "METERS";

		/// <summary>
		/// <para>Input Flight Path Features</para>
		/// <para>The polyline features that will define curved approaches to the specified runways. If unspecified, all input features will be processed as straight approaches.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object? InFlightpathFeatures { get; set; }

		/// <summary>
		/// <para>Output OIS Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object? OutOisFeatures { get; set; }

		/// <summary>
		/// <para>Obstacle Labels</para>
		/// <para>A field from the input obstacle feature class that will be used to label the obstacle. When an obstacle JSON generated by this tool is later used to create a Terrain and Obstacle Profile element in a layout, the data from the selected field will be used to label the input point obstacles in that element.</para>
		/// <para>The Obstacle Labels parameter only applies when the Input Obstacle Features parameter values contain point features.If no value is specified, the ObjectID will be applied by default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LabelField { get; set; } = "OBJECTID";

		/// <summary>
		/// <para>Obstacle Feature Height Type</para>
		/// <para>Specifies how obstacle height values will be measured.</para>
		/// <para>Absolute height— Obstacle heights will be measured from sea level.</para>
		/// <para>Relative height— Obstacle heights will be measured from ground level. This is the default.</para>
		/// <para><see cref="HeightOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? HeightOption { get; set; } = "RELATIVE_HEIGHT";

		/// <summary>
		/// <para>Elevation Source</para>
		/// <para>Specifies where obstacle base elevation heights will be found.</para>
		/// <para>Elevation field— Base elevation heights will be found in a numeric field of the obstacle feature class.</para>
		/// <para>Elevation DEM— Base elevation heights will be found by deriving them from one or more DEMs. This is the default.</para>
		/// <para><see cref="ElevationOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ElevationOption { get; set; } = "ELEVATION_DEM";

		/// <summary>
		/// <para>Elevation Field</para>
		/// <para>The field that will contain base elevation heights of the obstacle features.</para>
		/// <para>This parameter is used if Elevation Source is set to Elevation field. The default is the first numeric field in the obstacle feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ElevationField { get; set; }

		/// <summary>
		/// <para>Elevation Field Units</para>
		/// <para>Specifies the linear unit that will be used for the base elevation values. This parameter is used if Elevation Source is set to Elevation field.</para>
		/// <para>Kilometers—The unit will be kilometers.</para>
		/// <para>Meters—The unit will be meters. This is the default.</para>
		/// <para>Decimeters—The unit will be decimeters.</para>
		/// <para>Centimeters—The unit will be centimeters.</para>
		/// <para>Millimeters—The unit will be millimeters.</para>
		/// <para>Nautical miles—The unit will be nautical miles.</para>
		/// <para>Miles—The unit will be miles.</para>
		/// <para>Yards—The unit will be yards.</para>
		/// <para>Feet—The unit will be feet.</para>
		/// <para>Inches—The unit will be inches</para>
		/// <para>Decimal degrees—The unit will be decimal degrees.</para>
		/// <para>Points—The unit will be points.</para>
		/// <para>Unknown—The unit will be unknown.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ElevationFieldUnit { get; set; } = "METERS";

		/// <summary>
		/// <para>Obstacle Output Method</para>
		/// <para>Specifies the obstacles that will be included in the output feature class.</para>
		/// <para>All obstacles—All obstacles within the extent of the OIS will be included in the output.</para>
		/// <para>Penetrating obstacles—Only obstacles that penetrate the OIS will be included in the output.</para>
		/// <para>Shadowing obstacles—Only the obstacles that shadow other obstacles will be included in the output.</para>
		/// <para><see cref="ObstacleOutputMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ObstacleOutputMethod { get; set; } = "ALL_OBSTACLES";

		/// <summary>
		/// <para>Horizontal Distance</para>
		/// <para>The length of the approach surface in meters (calculated from the runway end) where shadows are considered horizontally aligned.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Shadow Calculation Parameters")]
		public object? ShadowHorizontalDistance { get; set; } = "300";

		/// <summary>
		/// <para>Slope</para>
		/// <para>The slope of the shadow that will be considered past the Horizontal Distance parameter value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Shadow Calculation Parameters")]
		public object? ShadowSlope { get; set; } = "1.2";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateOISObstacleData SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Obstacle Height</para>
		/// </summary>
		public enum ObstacleHeightFieldEnum 
		{
			/// <summary>
			/// <para>Feature Geometry—The field that will contain the height of the obstacle features.</para>
			/// </summary>
			[GPValue("FEATURE_GEOMETRY")]
			[Description("Feature Geometry")]
			Feature_Geometry,

		}

		/// <summary>
		/// <para>Obstacle Feature Height Type</para>
		/// </summary>
		public enum HeightOptionEnum 
		{
			/// <summary>
			/// <para>Absolute height— Obstacle heights will be measured from sea level.</para>
			/// </summary>
			[GPValue("ABSOLUTE_HEIGHT")]
			[Description("Absolute height")]
			Absolute_height,

			/// <summary>
			/// <para>Relative height— Obstacle heights will be measured from ground level. This is the default.</para>
			/// </summary>
			[GPValue("RELATIVE_HEIGHT")]
			[Description("Relative height")]
			Relative_height,

		}

		/// <summary>
		/// <para>Elevation Source</para>
		/// </summary>
		public enum ElevationOptionEnum 
		{
			/// <summary>
			/// <para>Elevation field— Base elevation heights will be found in a numeric field of the obstacle feature class.</para>
			/// </summary>
			[GPValue("ELEVATION_FIELD")]
			[Description("Elevation field")]
			Elevation_field,

			/// <summary>
			/// <para>Elevation DEM— Base elevation heights will be found by deriving them from one or more DEMs. This is the default.</para>
			/// </summary>
			[GPValue("ELEVATION_DEM")]
			[Description("Elevation DEM")]
			Elevation_DEM,

		}

		/// <summary>
		/// <para>Obstacle Output Method</para>
		/// </summary>
		public enum ObstacleOutputMethodEnum 
		{
			/// <summary>
			/// <para>All obstacles—All obstacles within the extent of the OIS will be included in the output.</para>
			/// </summary>
			[GPValue("ALL_OBSTACLES")]
			[Description("All obstacles")]
			All_obstacles,

			/// <summary>
			/// <para>Penetrating obstacles—Only obstacles that penetrate the OIS will be included in the output.</para>
			/// </summary>
			[GPValue("PENETRATING_OBSTACLES")]
			[Description("Penetrating obstacles")]
			Penetrating_obstacles,

			/// <summary>
			/// <para>Shadowing obstacles—Only the obstacles that shadow other obstacles will be included in the output.</para>
			/// </summary>
			[GPValue("SHADOWING_OBSTACLES")]
			[Description("Shadowing obstacles")]
			Shadowing_obstacles,

		}

#endregion
	}
}
