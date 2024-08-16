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
	/// <para>Analyze Runway Obstacles</para>
	/// <para>Analyzes obstacle data and obstruction identification surfaces (OIS) to determine if obstacles are penetrating.</para>
	/// </summary>
	public class AnalyzeRunwayObstacles : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputOisFeatures">
		/// <para>Input OIS Features</para>
		/// <para>The multipatch features with defined Airport schema. The feature class must be z-enabled.</para>
		/// </param>
		/// <param name="InputObstacleFeatures">
		/// <para>Input Obstacle Features</para>
		/// <para>The input obstacle features that will be analyzed. The feature class must be z-enabled.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Obstacle Feature Class</para>
		/// <para>A feature class containing one point for each obstacle feature that falls within the area covered by the input OIS. If the geometry type of the input obstacle feature is a polyline or polygon, a multipoint feature class will be created.</para>
		/// </param>
		public AnalyzeRunwayObstacles(object InputOisFeatures, object InputObstacleFeatures, object OutFeatureClass)
		{
			this.InputOisFeatures = InputOisFeatures;
			this.InputObstacleFeatures = InputObstacleFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Analyze Runway Obstacles</para>
		/// </summary>
		public override string DisplayName => "Analyze Runway Obstacles";

		/// <summary>
		/// <para>Tool Name : AnalyzeRunwayObstacles</para>
		/// </summary>
		public override string ToolName => "AnalyzeRunwayObstacles";

		/// <summary>
		/// <para>Tool Excute Name : aviation.AnalyzeRunwayObstacles</para>
		/// </summary>
		public override string ExcuteName => "aviation.AnalyzeRunwayObstacles";

		/// <summary>
		/// <para>Toolbox Display Name : Aviation Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Aviation Tools";

		/// <summary>
		/// <para>Toolbox Alise : aviation</para>
		/// </summary>
		public override string ToolboxAlise => "aviation";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputOisFeatures, InputObstacleFeatures, OutFeatureClass, HeightField, UnitField, HeightOption, ElevationOption, ElevationField, ElevationFieldUnit, InDems };

		/// <summary>
		/// <para>Input OIS Features</para>
		/// <para>The multipatch features with defined Airport schema. The feature class must be z-enabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("MultiPatch")]
		public object InputOisFeatures { get; set; }

		/// <summary>
		/// <para>Input Obstacle Features</para>
		/// <para>The input obstacle features that will be analyzed. The feature class must be z-enabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon", "Polyline")]
		public object InputObstacleFeatures { get; set; }

		/// <summary>
		/// <para>Output Obstacle Feature Class</para>
		/// <para>A feature class containing one point for each obstacle feature that falls within the area covered by the input OIS. If the geometry type of the input obstacle feature is a polyline or polygon, a multipoint feature class will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Obstacle Height</para>
		/// <para>The field containing the height of the obstacle features. The default value is Feature Geometry.</para>
		/// <para>Feature Geometry—The field containing the height of the obstacle features.</para>
		/// <para><see cref="HeightFieldEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object HeightField { get; set; } = "FEATURE_GEOMETRY";

		/// <summary>
		/// <para>Unit</para>
		/// <para>Specifies the linear unit of the obstacle height.</para>
		/// <para>Kilometers—The linear unit is kilometers.</para>
		/// <para>Meters—The linear unit is meters.</para>
		/// <para>Decimeters—The linear unit is decimeters.</para>
		/// <para>Centimeters—The linear unit is centimeters.</para>
		/// <para>Millimeters—The linear unit is millimeters.</para>
		/// <para>Nautical miles—The linear unit is nautical miles.</para>
		/// <para>Miles—The linear unit is miles.</para>
		/// <para>Yards—The linear unit is yards.</para>
		/// <para>Feet—The linear unit is feet.</para>
		/// <para>Inches—The linear unit is inches.</para>
		/// <para>Decimal degrees—The linear unit is decimal degrees.</para>
		/// <para>Points—The linear unit is points.</para>
		/// <para>Unknown—The linear unit is unknown.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object UnitField { get; set; } = "METERS";

		/// <summary>
		/// <para>Obstacle Features</para>
		/// <para>Specifies how obstacle height values will be interpreted.</para>
		/// <para>Absolute height— Obstacle heights are measured from sea level. This is the default.</para>
		/// <para>Relative height— Obstacle heights are measured from ground level.</para>
		/// <para><see cref="HeightOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object HeightOption { get; set; } = "ABSOLUTE_HEIGHT";

		/// <summary>
		/// <para>Elevations</para>
		/// <para>Specifies how obstacle base elevation heights are identified. This parameter is enabled if the Obstacle Features parameter is set to Relative height.</para>
		/// <para>Elevation field— Base elevation heights are derived from a numeric field of the obstacle feature class. This is the default.</para>
		/// <para>Elevation DEM— Base elevation heights are derived from one or more DEMs.</para>
		/// <para><see cref="ElevationOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ElevationOption { get; set; } = "ELEVATION_FIELD";

		/// <summary>
		/// <para>Elevation Field</para>
		/// <para>The field containing base elevation heights of the obstacle features.</para>
		/// <para>This parameter is active if the Obstacle Features parameter is set to Relative height and the Elevations parameter is set to Elevation field. The default is the first numeric field in the obstacle feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ElevationField { get; set; }

		/// <summary>
		/// <para>Elevation Field Units</para>
		/// <para>Specifies the linear unit of the base elevation values. This parameter is active if the Obstacle Features parameter is set to Relative height and the Elevations parameter is set to Elevation field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ElevationFieldUnit { get; set; } = "METERS";

		/// <summary>
		/// <para>Input Elevation Model</para>
		/// <para>The DEMs covering the obstacles, used to derive base elevation values. This parameter is active if the Obstacle Features parameter is set to Relative height and the Elevations parameter is set to Elevation DEM.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object InDems { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AnalyzeRunwayObstacles SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Obstacle Height</para>
		/// </summary>
		public enum HeightFieldEnum 
		{
			/// <summary>
			/// <para>Feature Geometry—The field containing the height of the obstacle features.</para>
			/// </summary>
			[GPValue("FEATURE_GEOMETRY")]
			[Description("Feature Geometry")]
			Feature_Geometry,

		}

		/// <summary>
		/// <para>Obstacle Features</para>
		/// </summary>
		public enum HeightOptionEnum 
		{
			/// <summary>
			/// <para>Absolute height— Obstacle heights are measured from sea level. This is the default.</para>
			/// </summary>
			[GPValue("ABSOLUTE_HEIGHT")]
			[Description("Absolute height")]
			Absolute_height,

			/// <summary>
			/// <para>Relative height— Obstacle heights are measured from ground level.</para>
			/// </summary>
			[GPValue("RELATIVE_HEIGHT")]
			[Description("Relative height")]
			Relative_height,

		}

		/// <summary>
		/// <para>Elevations</para>
		/// </summary>
		public enum ElevationOptionEnum 
		{
			/// <summary>
			/// <para>Elevation field— Base elevation heights are derived from a numeric field of the obstacle feature class. This is the default.</para>
			/// </summary>
			[GPValue("ELEVATION_FIELD")]
			[Description("Elevation field")]
			Elevation_field,

			/// <summary>
			/// <para>Elevation DEM— Base elevation heights are derived from one or more DEMs.</para>
			/// </summary>
			[GPValue("ELEVATION_DEM")]
			[Description("Elevation DEM")]
			Elevation_DEM,

		}

#endregion
	}
}
