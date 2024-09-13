using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.BusinessAnalystTools
{
	/// <summary>
	/// <para>Generate Grids and Hexagons</para>
	/// <para>Generate Grids and Hexagons</para>
	/// <para>Creates features with vector-based square grid cells, hexagons, or H3 hexagons for a given area.</para>
	/// </summary>
	public class GenerateGridsAndHexagons : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="AreaOfInterest">
		/// <para>Area of Interest</para>
		/// <para>The input feature class used to define the extent of the grid or hexagon layer.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will contain the grid or hexagon features.</para>
		/// </param>
		public GenerateGridsAndHexagons(object AreaOfInterest, object OutFeatureClass)
		{
			this.AreaOfInterest = AreaOfInterest;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Grids and Hexagons</para>
		/// </summary>
		public override string DisplayName() => "Generate Grids and Hexagons";

		/// <summary>
		/// <para>Tool Name : GenerateGridsAndHexagons</para>
		/// </summary>
		public override string ToolName() => "GenerateGridsAndHexagons";

		/// <summary>
		/// <para>Tool Excute Name : ba.GenerateGridsAndHexagons</para>
		/// </summary>
		public override string ExcuteName() => "ba.GenerateGridsAndHexagons";

		/// <summary>
		/// <para>Toolbox Display Name : Business Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Business Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ba</para>
		/// </summary>
		public override string ToolboxAlise() => "ba";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "baDataSource", "baNetworkSource", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { AreaOfInterest, OutFeatureClass, CellType!, EnrichType!, CellSize!, H3Resolution!, Variables!, DistanceType!, Distance!, Units!, OutEnrichedBuffers!, TravelDirection!, TimeOfDay!, TimeZone!, SearchTolerance!, PolygonDetail! };

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>The input feature class used to define the extent of the grid or hexagon layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will contain the grid or hexagon features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Cell Geometry Type</para>
		/// <para>Specifies the cell type that will be created in the output.</para>
		/// <para>Square—Regular four-sided polygons with equal side lengths will be created. This is the default.</para>
		/// <para>Hexagon—Regular six-sided polygons with equal side lengths will be created.</para>
		/// <para>H3 Hexagon—Regular six-sided polygons with equal side lengths based on Uber&apos;s hexagonal hierarchical spatial index will be created.</para>
		/// <para><see cref="CellTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CellType { get; set; } = "SQUARE";

		/// <summary>
		/// <para>Enrichment Type</para>
		/// <para>Specifies the method that will be used for variable enrichment.</para>
		/// <para>Enrich Cell—Enrichment will be performed on the Cell Geometry Type parameter value.</para>
		/// <para>Enrich Buffer—Enrichment will be performed on a buffer around the centroid of the grid or hexagon. The default Distance Type parameter value is Straight Line.</para>
		/// <para><see cref="EnrichTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? EnrichType { get; set; }

		/// <summary>
		/// <para>Cell Size</para>
		/// <para>The size of the cell to generate squares or hexagons. The default value is 1 square mile.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPArealUnit()]
		public object? CellSize { get; set; } = "1 SquareMiles";

		/// <summary>
		/// <para>H3 Resolution</para>
		/// <para>The resolution that will be used to generate the H3 hexagons. A value of15 represents the finest resolution. The default value is 7.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 15)]
		public object? H3Resolution { get; set; } = "7";

		/// <summary>
		/// <para>Variables</para>
		/// <para>A list of variables that will be appended to the output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Variables { get; set; }

		/// <summary>
		/// <para>Distance Type</para>
		/// <para>The method of travel that will be used for the buffer calculation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Buffer Parameters")]
		public object? DistanceType { get; set; } = "STRAIGHT_LINE_DISTANCE";

		/// <summary>
		/// <para>Distance</para>
		/// <para>The distance that will be used for the buffer calculations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Buffer Parameters")]
		public object? Distance { get; set; } = "1";

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>The units that will be used for the Distance parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Buffer Parameters")]
		public object? Units { get; set; }

		/// <summary>
		/// <para>Output Enriched Buffers</para>
		/// <para>The feature class that will contain the enriched buffers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Buffer Parameters")]
		public object? OutEnrichedBuffers { get; set; }

		/// <summary>
		/// <para>Travel Direction</para>
		/// <para>Specifies the direction of travel that will be used between the center of the cell and the buffer boundary.</para>
		/// <para>Toward Input Features—The direction of travel will be from location points to input features. This is the default.</para>
		/// <para>Away from Input Features—The direction of travel will be from input features to location points.</para>
		/// <para><see cref="TravelDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Network Parameters")]
		public object? TravelDirection { get; set; } = "TOWARD_STORES";

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>The time at which the travel will begin.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Network Parameters")]
		public object? TimeOfDay { get; set; }

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>Specifies the time zone that will be used for the Time of Day parameter.</para>
		/// <para>UTC—Coordinated universal time (UTC) will be used. Choose this option if you want the best location for a specific time, such as now, but aren&apos;t certain of the time zone.</para>
		/// <para>Local time at locations—The time zone in which the Area of Interest value is located will be used. This is the default.</para>
		/// <para><see cref="TimeZoneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Network Parameters")]
		public object? TimeZone { get; set; } = "TIME_ZONE_AT_LOCATION";

		/// <summary>
		/// <para>Search Tolerance</para>
		/// <para>The maximum distance that input points can be from the network. Points located beyond the search tolerance will be excluded from processing.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Network Parameters")]
		public object? SearchTolerance { get; set; }

		/// <summary>
		/// <para>Polygon Detail</para>
		/// <para>Specifies the level of detail that will be used for the output drive time polygons.</para>
		/// <para>Standard—The optimal setting that combines processing speed with overall accuracy will be used. This is the default.</para>
		/// <para>Generalized—The fastest method will be used.</para>
		/// <para>High—The highest level of detail will be used.</para>
		/// <para><see cref="PolygonDetailEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Network Parameters")]
		public object? PolygonDetail { get; set; } = "STANDARD";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateGridsAndHexagons SetEnviroment(object? baDataSource = null , object? baNetworkSource = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(baDataSource: baDataSource, baNetworkSource: baNetworkSource, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Cell Geometry Type</para>
		/// </summary>
		public enum CellTypeEnum 
		{
			/// <summary>
			/// <para>Square—Regular four-sided polygons with equal side lengths will be created. This is the default.</para>
			/// </summary>
			[GPValue("SQUARE")]
			[Description("Square")]
			Square,

			/// <summary>
			/// <para>Hexagon—Regular six-sided polygons with equal side lengths will be created.</para>
			/// </summary>
			[GPValue("HEXAGON")]
			[Description("Hexagon")]
			Hexagon,

			/// <summary>
			/// <para>H3 Hexagon—Regular six-sided polygons with equal side lengths based on Uber&apos;s hexagonal hierarchical spatial index will be created.</para>
			/// </summary>
			[GPValue("H3_HEXAGON")]
			[Description("H3 Hexagon")]
			H3_Hexagon,

		}

		/// <summary>
		/// <para>Enrichment Type</para>
		/// </summary>
		public enum EnrichTypeEnum 
		{
			/// <summary>
			/// <para>Enrich Cell—Enrichment will be performed on the Cell Geometry Type parameter value.</para>
			/// </summary>
			[GPValue("ENRICH_CELL")]
			[Description("Enrich Cell")]
			Enrich_Cell,

			/// <summary>
			/// <para>Enrich Buffer—Enrichment will be performed on a buffer around the centroid of the grid or hexagon. The default Distance Type parameter value is Straight Line.</para>
			/// </summary>
			[GPValue("ENRICH_BUFFER")]
			[Description("Enrich Buffer")]
			Enrich_Buffer,

		}

		/// <summary>
		/// <para>Travel Direction</para>
		/// </summary>
		public enum TravelDirectionEnum 
		{
			/// <summary>
			/// <para>Toward Input Features—The direction of travel will be from location points to input features. This is the default.</para>
			/// </summary>
			[GPValue("TOWARD_STORES")]
			[Description("Toward Input Features")]
			Toward_Input_Features,

			/// <summary>
			/// <para>Away from Input Features—The direction of travel will be from input features to location points.</para>
			/// </summary>
			[GPValue("AWAY_FROM_STORES")]
			[Description("Away from Input Features")]
			Away_from_Input_Features,

		}

		/// <summary>
		/// <para>Time Zone</para>
		/// </summary>
		public enum TimeZoneEnum 
		{
			/// <summary>
			/// <para>UTC—Coordinated universal time (UTC) will be used. Choose this option if you want the best location for a specific time, such as now, but aren&apos;t certain of the time zone.</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

			/// <summary>
			/// <para>Local time at locations—The time zone in which the Area of Interest value is located will be used. This is the default.</para>
			/// </summary>
			[GPValue("TIME_ZONE_AT_LOCATION")]
			[Description("Local time at locations")]
			Local_time_at_locations,

		}

		/// <summary>
		/// <para>Polygon Detail</para>
		/// </summary>
		public enum PolygonDetailEnum 
		{
			/// <summary>
			/// <para>Standard—The optimal setting that combines processing speed with overall accuracy will be used. This is the default.</para>
			/// </summary>
			[GPValue("STANDARD")]
			[Description("Standard")]
			Standard,

			/// <summary>
			/// <para>Generalized—The fastest method will be used.</para>
			/// </summary>
			[GPValue("GENERALIZED")]
			[Description("Generalized")]
			Generalized,

			/// <summary>
			/// <para>High—The highest level of detail will be used.</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("High")]
			High,

		}

#endregion
	}
}
