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
	/// <para>Aggregate Obstacles</para>
	/// <para>Aggregates obstacle features within a given radius </para>
	/// <para>so that the highest obstacle in the group represents the entire group.</para>
	/// </summary>
	public class AggregateObstacles : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InObstacleFeatures">
		/// <para>Obstacle Features</para>
		/// <para>The input obstacle features.</para>
		/// </param>
		/// <param name="HeightField">
		/// <para>Height Field</para>
		/// <para>The field containing the height of the obstacle features.</para>
		/// </param>
		/// <param name="HeightFieldUnits">
		/// <para>Height Field Units</para>
		/// <para>Specifies the units that will be used for obstacle height.</para>
		/// <para>Meters—The obstacle height will be in meters.</para>
		/// <para>Decimeters—The obstacle height will be in decimeters.</para>
		/// <para>Centimeters—The obstacle height will be in centimeters.</para>
		/// <para>Millimeters—The obstacle height will be in millimeters.</para>
		/// <para>Yards—The obstacle height will be in yards.</para>
		/// <para>Feet—The obstacle height will be in feet. This is the default.</para>
		/// <para>Inches—The obstacle height will be in inches.</para>
		/// <para><see cref="HeightFieldUnitsEnum"/></para>
		/// </param>
		/// <param name="ElevationField">
		/// <para>Elevation Field</para>
		/// <para>The field containing the elevation of the obstacle features.</para>
		/// </param>
		/// <param name="ElevationFieldUnits">
		/// <para>Elevation Field Units</para>
		/// <para>Specifies the units that will be used for obstacle elevation.</para>
		/// <para>Meters—The obstacle elevation will be in meters.</para>
		/// <para>Decimeters—The obstacle elevation will be in decimeters.</para>
		/// <para>Centimeters—The obstacle elevation will be in centimeters.</para>
		/// <para>Millimeters—The obstacle elevation will be in millimeters.</para>
		/// <para>Yards—The obstacle elevation will be in yards.</para>
		/// <para>Feet—The obstacle elevation will be in feet. This is the default.</para>
		/// <para>Inches—The obstacle elevation will be in inches.</para>
		/// <para><see cref="ElevationFieldUnitsEnum"/></para>
		/// </param>
		/// <param name="ElevationInterpretation">
		/// <para>Elevation Interpretation</para>
		/// <para>Specifies how obstacle elevations will be measured.</para>
		/// <para>On the Ground—Elevation values will be measured using the AMSL elevation of the base of the obstacle. The height value will be added to the elevation value to determine the elevation of the top of the obstacle.</para>
		/// <para>Above the Ground—Elevation values will be measured using the AMSL elevation of the top of the obstacle. This is the default.</para>
		/// <para><see cref="ElevationInterpretationEnum"/></para>
		/// </param>
		/// <param name="TargetObstacleGroupFeatures">
		/// <para>Target Obstacle Group Features</para>
		/// <para>The output feature class to which aggregated obstacle features will be written.</para>
		/// </param>
		/// <param name="TargetObstacleGroupLabel">
		/// <para>Target Obstacle Group Label</para>
		/// <para>The text describing the obstacle grouping. The text is used to identify obstacle groups for different chart specifications that may be created using different parameters.</para>
		/// </param>
		/// <param name="InObstacleAssocationTable">
		/// <para>Obstacle Association Table</para>
		/// <para>A table that will be populated with information linking each obstacle group feature to the obstacles it represents.</para>
		/// </param>
		public AggregateObstacles(object InObstacleFeatures, object HeightField, object HeightFieldUnits, object ElevationField, object ElevationFieldUnits, object ElevationInterpretation, object TargetObstacleGroupFeatures, object TargetObstacleGroupLabel, object InObstacleAssocationTable)
		{
			this.InObstacleFeatures = InObstacleFeatures;
			this.HeightField = HeightField;
			this.HeightFieldUnits = HeightFieldUnits;
			this.ElevationField = ElevationField;
			this.ElevationFieldUnits = ElevationFieldUnits;
			this.ElevationInterpretation = ElevationInterpretation;
			this.TargetObstacleGroupFeatures = TargetObstacleGroupFeatures;
			this.TargetObstacleGroupLabel = TargetObstacleGroupLabel;
			this.InObstacleAssocationTable = InObstacleAssocationTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Aggregate Obstacles</para>
		/// </summary>
		public override string DisplayName => "Aggregate Obstacles";

		/// <summary>
		/// <para>Tool Name : AggregateObstacles</para>
		/// </summary>
		public override string ToolName => "AggregateObstacles";

		/// <summary>
		/// <para>Tool Excute Name : aviation.AggregateObstacles</para>
		/// </summary>
		public override string ExcuteName => "aviation.AggregateObstacles";

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
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InObstacleFeatures, HeightField, HeightFieldUnits, ElevationField, ElevationFieldUnits, ElevationInterpretation, TargetObstacleGroupFeatures, TargetObstacleGroupLabel, InObstacleAssocationTable, SearchRadius!, HeightThreshold!, BuiltupAreasFeatures!, BuiltupAreasHeightThreshold!, UpdatedObstacleGroupFeatures! };

		/// <summary>
		/// <para>Obstacle Features</para>
		/// <para>The input obstacle features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InObstacleFeatures { get; set; }

		/// <summary>
		/// <para>Height Field</para>
		/// <para>The field containing the height of the obstacle features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object HeightField { get; set; }

		/// <summary>
		/// <para>Height Field Units</para>
		/// <para>Specifies the units that will be used for obstacle height.</para>
		/// <para>Meters—The obstacle height will be in meters.</para>
		/// <para>Decimeters—The obstacle height will be in decimeters.</para>
		/// <para>Centimeters—The obstacle height will be in centimeters.</para>
		/// <para>Millimeters—The obstacle height will be in millimeters.</para>
		/// <para>Yards—The obstacle height will be in yards.</para>
		/// <para>Feet—The obstacle height will be in feet. This is the default.</para>
		/// <para>Inches—The obstacle height will be in inches.</para>
		/// <para><see cref="HeightFieldUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object HeightFieldUnits { get; set; } = "FEET";

		/// <summary>
		/// <para>Elevation Field</para>
		/// <para>The field containing the elevation of the obstacle features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ElevationField { get; set; }

		/// <summary>
		/// <para>Elevation Field Units</para>
		/// <para>Specifies the units that will be used for obstacle elevation.</para>
		/// <para>Meters—The obstacle elevation will be in meters.</para>
		/// <para>Decimeters—The obstacle elevation will be in decimeters.</para>
		/// <para>Centimeters—The obstacle elevation will be in centimeters.</para>
		/// <para>Millimeters—The obstacle elevation will be in millimeters.</para>
		/// <para>Yards—The obstacle elevation will be in yards.</para>
		/// <para>Feet—The obstacle elevation will be in feet. This is the default.</para>
		/// <para>Inches—The obstacle elevation will be in inches.</para>
		/// <para><see cref="ElevationFieldUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ElevationFieldUnits { get; set; } = "FEET";

		/// <summary>
		/// <para>Elevation Interpretation</para>
		/// <para>Specifies how obstacle elevations will be measured.</para>
		/// <para>On the Ground—Elevation values will be measured using the AMSL elevation of the base of the obstacle. The height value will be added to the elevation value to determine the elevation of the top of the obstacle.</para>
		/// <para>Above the Ground—Elevation values will be measured using the AMSL elevation of the top of the obstacle. This is the default.</para>
		/// <para><see cref="ElevationInterpretationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ElevationInterpretation { get; set; }

		/// <summary>
		/// <para>Target Obstacle Group Features</para>
		/// <para>The output feature class to which aggregated obstacle features will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object TargetObstacleGroupFeatures { get; set; }

		/// <summary>
		/// <para>Target Obstacle Group Label</para>
		/// <para>The text describing the obstacle grouping. The text is used to identify obstacle groups for different chart specifications that may be created using different parameters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TargetObstacleGroupLabel { get; set; }

		/// <summary>
		/// <para>Obstacle Association Table</para>
		/// <para>A table that will be populated with information linking each obstacle group feature to the obstacles it represents.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InObstacleAssocationTable { get; set; }

		/// <summary>
		/// <para>Search Radius</para>
		/// <para>The radius within which the obstacles will be grouped.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? SearchRadius { get; set; } = "1.5 NauticalMiles";

		/// <summary>
		/// <para>Height Threshold</para>
		/// <para>The height threshold for an obstacle to be considered for grouping. Obstacles with a height value greater than or equal to this value will be considered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? HeightThreshold { get; set; } = "200 Feet";

		/// <summary>
		/// <para>Built-Up Areas</para>
		/// <para>Polygon features designating built up areas. These represent areas where a different height threshold is required.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object? BuiltupAreasFeatures { get; set; }

		/// <summary>
		/// <para>Built-Up Areas Height Threshold</para>
		/// <para>The height threshold for an obstacle within a built-up area polygon to be considered for grouping. Obstacles with a height value equal to or greater than this value will be considered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? BuiltupAreasHeightThreshold { get; set; } = "300 Feet";

		/// <summary>
		/// <para>Updated Obstacle Group Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? UpdatedObstacleGroupFeatures { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Height Field Units</para>
		/// </summary>
		public enum HeightFieldUnitsEnum 
		{
			/// <summary>
			/// <para>Meters—The obstacle height will be in meters.</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Decimeters—The obstacle height will be in decimeters.</para>
			/// </summary>
			[GPValue("DECIMETERS")]
			[Description("Decimeters")]
			Decimeters,

			/// <summary>
			/// <para>Centimeters—The obstacle height will be in centimeters.</para>
			/// </summary>
			[GPValue("CENTIMETERS")]
			[Description("Centimeters")]
			Centimeters,

			/// <summary>
			/// <para>Millimeters—The obstacle height will be in millimeters.</para>
			/// </summary>
			[GPValue("MILLIMETERS")]
			[Description("Millimeters")]
			Millimeters,

			/// <summary>
			/// <para>Yards—The obstacle height will be in yards.</para>
			/// </summary>
			[GPValue("YARDS")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para>Feet—The obstacle height will be in feet. This is the default.</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para>Inches—The obstacle height will be in inches.</para>
			/// </summary>
			[GPValue("INCHES")]
			[Description("Inches")]
			Inches,

		}

		/// <summary>
		/// <para>Elevation Field Units</para>
		/// </summary>
		public enum ElevationFieldUnitsEnum 
		{
			/// <summary>
			/// <para>Meters—The obstacle elevation will be in meters.</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Decimeters—The obstacle elevation will be in decimeters.</para>
			/// </summary>
			[GPValue("DECIMETERS")]
			[Description("Decimeters")]
			Decimeters,

			/// <summary>
			/// <para>Centimeters—The obstacle elevation will be in centimeters.</para>
			/// </summary>
			[GPValue("CENTIMETERS")]
			[Description("Centimeters")]
			Centimeters,

			/// <summary>
			/// <para>Millimeters—The obstacle elevation will be in millimeters.</para>
			/// </summary>
			[GPValue("MILLIMETERS")]
			[Description("Millimeters")]
			Millimeters,

			/// <summary>
			/// <para>Yards—The obstacle elevation will be in yards.</para>
			/// </summary>
			[GPValue("YARDS")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para>Feet—The obstacle elevation will be in feet. This is the default.</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para>Inches—The obstacle elevation will be in inches.</para>
			/// </summary>
			[GPValue("INCHES")]
			[Description("Inches")]
			Inches,

		}

		/// <summary>
		/// <para>Elevation Interpretation</para>
		/// </summary>
		public enum ElevationInterpretationEnum 
		{
			/// <summary>
			/// <para>On the Ground—Elevation values will be measured using the AMSL elevation of the base of the obstacle. The height value will be added to the elevation value to determine the elevation of the top of the obstacle.</para>
			/// </summary>
			[GPValue("ON_THE_GROUND")]
			[Description("On the Ground")]
			On_the_Ground,

			/// <summary>
			/// <para>Above the Ground—Elevation values will be measured using the AMSL elevation of the top of the obstacle. This is the default.</para>
			/// </summary>
			[GPValue("ABOVE_THE_GROUND")]
			[Description("Above the Ground")]
			Above_the_Ground,

		}

#endregion
	}
}
