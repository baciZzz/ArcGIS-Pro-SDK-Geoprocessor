using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Locate Regions</para>
	/// <para>Identifies the best regions, or groups of contiguous cells, from an input utility (suitability) raster that satisfy a specified evaluation criterion and that meet identified shape, size, number, and interregion distance constraints.</para>
	/// </summary>
	public class LocateRegions : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input raster</para>
		/// <para>The input utility raster from which the regions will be derived.</para>
		/// <para>The higher the value in the input raster, the greater the utility.</para>
		/// <para>The raster can be of either integer or floating-point type.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output regions raster.</para>
		/// <para>Each region is uniquely numbered with values greater than zero. Cells that do not belong to any regions will be assigned zero. The output is always an integer raster.</para>
		/// <para>Additional fields are calculated for each region storing statistics of the selected regions. These fields are the following:</para>
		/// <para>AVERAGE—The average utility value of the region.</para>
		/// <para>TOTAL—The total sum of the utility values within the region.</para>
		/// <para>MEDIAN—The median utility value of the region.</para>
		/// <para>HIGHEST—The highest individual cell value contained within the region.</para>
		/// <para>LOWEST—The lowest individual cell value contained within the region.</para>
		/// <para>COREAREA—The core area. Any cell farther than one cell from the region&apos;s edge is considered to be part of the core.</para>
		/// <para>CORESUM—The cumulative sum of the utility values for the core area.</para>
		/// <para>EDGE—The amount of edge using the P1 ratio, which is the ratio of the perimeter of the shape to the perimeter of a circle of the same area. The P1 ratio for a circle is 1.</para>
		/// </param>
		public LocateRegions(object InRaster, object OutRaster)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Locate Regions</para>
		/// </summary>
		public override string DisplayName() => "Locate Regions";

		/// <summary>
		/// <para>Tool Name : LocateRegions</para>
		/// </summary>
		public override string ToolName() => "LocateRegions";

		/// <summary>
		/// <para>Tool Excute Name : sa.LocateRegions</para>
		/// </summary>
		public override string ExcuteName() => "sa.LocateRegions";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "rasterStatistics", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, TotalArea, AreaUnits, NumberOfRegions, RegionShape, RegionOrientation, ShapeTradeoff, EvaluationMethod, MinimumArea, MaximumArea, MinimumDistance, MaximumDistance, DistanceUnits, InExistingRegions, NumberOfNeighbors, NoIslands, RegionSeeds, RegionResolution, SelectionMethod };

		/// <summary>
		/// <para>Input raster</para>
		/// <para>The input utility raster from which the regions will be derived.</para>
		/// <para>The higher the value in the input raster, the greater the utility.</para>
		/// <para>The raster can be of either integer or floating-point type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output regions raster.</para>
		/// <para>Each region is uniquely numbered with values greater than zero. Cells that do not belong to any regions will be assigned zero. The output is always an integer raster.</para>
		/// <para>Additional fields are calculated for each region storing statistics of the selected regions. These fields are the following:</para>
		/// <para>AVERAGE—The average utility value of the region.</para>
		/// <para>TOTAL—The total sum of the utility values within the region.</para>
		/// <para>MEDIAN—The median utility value of the region.</para>
		/// <para>HIGHEST—The highest individual cell value contained within the region.</para>
		/// <para>LOWEST—The lowest individual cell value contained within the region.</para>
		/// <para>COREAREA—The core area. Any cell farther than one cell from the region&apos;s edge is considered to be part of the core.</para>
		/// <para>CORESUM—The cumulative sum of the utility values for the core area.</para>
		/// <para>EDGE—The amount of edge using the P1 ratio, which is the ratio of the perimeter of the shape to the perimeter of a circle of the same area. The P1 ratio for a circle is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Total area</para>
		/// <para>The total amount of area for all regions.</para>
		/// <para>The default is 10 percent of the input cells within the processing extent.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object TotalArea { get; set; }

		/// <summary>
		/// <para>Area units</para>
		/// <para>Defines the area units used for the Total area, Region minimum area, and Region maximum area parameters.</para>
		/// <para>The available options and their corresponding units are the following:</para>
		/// <para>Square map units—For the square of the linear units of the output spatial reference</para>
		/// <para>Square miles—For miles</para>
		/// <para>Square kilometers—For kilometers</para>
		/// <para>Hectares—For hectares</para>
		/// <para>Acres—For acres</para>
		/// <para>Square meters—For meters</para>
		/// <para>Square yards—For yards</para>
		/// <para>Square feet—For feet</para>
		/// <para>The default is based on the input raster dataset. If the input raster is in feet, yards, miles or any other imperial unit, Square miles will be used. If the input raster is in meters, kilometers, or any other metric unit, Square kilometers will be used.</para>
		/// <para><see cref="AreaUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AreaUnits { get; set; } = "SQUARE_MAP_UNITS";

		/// <summary>
		/// <para>Number of regions</para>
		/// <para>Determines how many regions the Total area will be distributed across.</para>
		/// <para>The maximum number of regions that can be specified is 30. The default is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object NumberOfRegions { get; set; } = "1";

		/// <summary>
		/// <para>Region shape</para>
		/// <para>Defines the shape characteristics for the output regions.</para>
		/// <para>The regions start out from seed cell locations and grow outward with preference given to the cells that maintain the desired shape.</para>
		/// <para>The available shape options are the following:</para>
		/// <para>Circle—Cells that maintain circular regions will receive a greater weight. This is the default.</para>
		/// <para>Ellipse—Cells that maintain elliptical-shaped regions will receive a greater weight.</para>
		/// <para>Equilateral triangle—Cells that maintain equilateral triangular-shaped regions will receive a greater weight.</para>
		/// <para>Square—Cells that maintain square-shaped regions will receive a greater weight.</para>
		/// <para>Pentagon—Cells that maintain pentagon-shaped regions will receive a greater weight.</para>
		/// <para>Hexagon—Cells that maintain hexagon-shaped regions will receive a greater weight.</para>
		/// <para>Octagon—Cells that maintain octagon-shaped regions will receive a greater weight.</para>
		/// <para><see cref="RegionShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RegionShape { get; set; } = "CIRCLE";

		/// <summary>
		/// <para>Region orientation</para>
		/// <para>Defines the orientation of the defined shape. Regions are grown out from the seed locations with preference given to the cells that maintain the desired orientation of the region shapes.</para>
		/// <para>The orientation values are in compass degrees ranging from 0 to 360, increasing clockwise starting from north. The default is 0.</para>
		/// <para>The default of 0 orients the shapes in the following manner: Circle—no effect; Ellipse—the minor axis is orientated north-south; Triangle and Pentagon—one point is straight up; Square, Hexagon, and Octagon—one flat side is oriented east-west.</para>
		/// <para>If the Region shape is set to Circle, the Region orientation parameter is unavailable.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[High(Allow = true, Value = 360)]
		public object RegionOrientation { get; set; } = "0";

		/// <summary>
		/// <para>Shape/Utility tradeoff (%)</para>
		/// <para>Identifies the weight for the cells when growing the candidate regions in the parameterized region-growing algorithm. The weighting is a tradeoff between a cell&apos;s contribution for maintaining the region shape relative to the utility contribution of the cell&apos;s attribute value.</para>
		/// <para>Higher values indicates maintaining the shape of the region is more important than selecting higher utility values. The acceptable percent values are 0 to 100, inclusively. The default is 50.</para>
		/// <para>This parameter is used to identify the feasible candidate regions. The candidate regions that will be selected by the algorithm are controlled by the Evaluation method parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object ShapeTradeoff { get; set; } = "50";

		/// <summary>
		/// <para>Evaluation method</para>
		/// <para>The evaluation criteria to be used for determining which of the candidate regions identified in the parameterized region-growing algorithm are most preferred. The preference can be specified based on a particular statistic of the utility values, or spatial arrangement of the cells within the regions.</para>
		/// <para>The available options are the following:</para>
		/// <para>Highest average value—Selects regions based on the highest average value. This is the default.</para>
		/// <para>Highest sum—Selects regions based on the highest sum.</para>
		/// <para>Highest median value—Selects regions based on the highest median value.</para>
		/// <para>Highest value—Selects regions based on the highest individual cell value contained within the region. This option ensures the best individual cells are selected.</para>
		/// <para>Lowest value—Selects regions based on the highest lowest individual cell value contained within the region. This option ensures the selected regions contain cells with really low utility.</para>
		/// <para>Greatest core area—Selects regions based on the greatest core area.Any cell that is farther than one cell from the edge of a region is considered to be part of the core. The edge distance can be controlled by the analysis cell size. Setting a smaller cell size can increase the core area.</para>
		/// <para>Highest sum of core utility values—Selects regions based on the highest cumulative sum of the utility values for the core area. The edge distance can be controlled by the analysis cell size.</para>
		/// <para>Greatest edge—Selects regions based on the greatest amount of edge using the P1 ratio, which is the ratio of the perimeter of the shape to the perimeter of a circle of the same area. The P1 ratio for a circle is 1.</para>
		/// <para><see cref="EvaluationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object EvaluationMethod { get; set; } = "HIGHEST_AVERAGE_VALUE";

		/// <summary>
		/// <para>Region minimum area</para>
		/// <para>Define the minimum area allowed for each region.</para>
		/// <para>The units specified by the Area units parameter will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object MinimumArea { get; set; }

		/// <summary>
		/// <para>Region maximum area</para>
		/// <para>Define the maximum area allowed for each region.</para>
		/// <para>The units specified by the Area units parameter will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object MaximumArea { get; set; }

		/// <summary>
		/// <para>Minimum distance between regions</para>
		/// <para>Define the minimum distance allowed between regions. No two regions can be within this distance.</para>
		/// <para>This parameter influences the parameterized region-growing (PRG) algorithm. If a cell has the potential of being added to a candidate region, but it is within this distance from any individual region in the dataset specified by the Input raster or feature of existing regions parameter, it will not be considered for the candidate region. The minimum distance setting is not applied to excluded locations (NoData cells).</para>
		/// <para>The units specified by the Distance units parameter will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object MinimumDistance { get; set; }

		/// <summary>
		/// <para>Maximum distance between regions</para>
		/// <para>Define the maximum distance allowed between regions. No region can be farther apart than this distance from at least one other region.</para>
		/// <para>When sequentially selecting regions, if the next best region is farther than this distance from any of the already selected regions, it will not be considered at this time, but it may be selected later when more regions are selected.</para>
		/// <para>The maximum distance is applied to the dataset specified in the Input raster or feature of existing regions parameter, in that at least one of the selected regions must be within the maximum distance from existing regions. The maximum distance setting is not applied to excluded areas (NoData cells) and has no effect on the PRG algorithm.</para>
		/// <para>The units specified by the Distance units parameter will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object MaximumDistance { get; set; }

		/// <summary>
		/// <para>Distance units</para>
		/// <para>Defines the distance units that will be used for the Minimum distance between regions and Maximum distance between regions parameters.</para>
		/// <para>The available options and their corresponding units are the following:</para>
		/// <para>Map units—For the linear units of the output spatial reference</para>
		/// <para>Miles—For miles</para>
		/// <para>Kilometers—For kilometers</para>
		/// <para>Meters—For meters</para>
		/// <para>Yards—For yards</para>
		/// <para>Feet—For feet</para>
		/// <para>The default is based on the input raster dataset. If the input raster is in feet, yards, miles, or any other imperial unit, Miles will be used. If the input raster is in meters, kilometers, or any other metric unit, Kilometers will be used.</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceUnits { get; set; } = "MAP_UNITS";

		/// <summary>
		/// <para>Input raster or feature of existing regions</para>
		/// <para>A dataset identifying where regions already exist.</para>
		/// <para>The input can be a raster or feature dataset. If the input is a raster, any location in the raster with a valid value is considered already allocated. All other locations are set to NoData.</para>
		/// <para>In the parameterized region-growing algorithm, no region will grow from any location identified as an existing region. Existing regions will be used in the growth and evaluation of the Minimum distance between regions and Maximum distance between regions parameters as described in the corresponding parameter descriptions above.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InExistingRegions { get; set; }

		/// <summary>
		/// <para>Number of neighbors to use in growth</para>
		/// <para>Defines which neighboring cells to use in the growth of the regions.</para>
		/// <para>The available options are the following:</para>
		/// <para>Four—Only the four direct (orthogonal) neighbors of the region cells will be considered in the region growth.</para>
		/// <para>Eight—The eight nearest neighbors (orthogonal and diagonal) will be considered in the region growth. This is the default.</para>
		/// <para><see cref="NumberOfNeighborsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Region growth and search parameters")]
		public object NumberOfNeighbors { get; set; } = "EIGHT";

		/// <summary>
		/// <para>Islands not allowed in regions</para>
		/// <para>Defines whether or not islands will be allowed within the potential regions.</para>
		/// <para>Checked—The parameterized region-growing algorithm ensures there will be no islands within a region. This is the default.A flood field algorithm is implemented as a postprocess once the regions are created but before the regions are selected. If there are islands within a region, they will be filled in and the cells will join the region. Since the fill process occurs before the selection process, the utility of the island cells will be added to the region, and their values will be included in the selection process of the regions and in the statistics of the output regions. As a result of the fill process, it is likely that the total area allocated will exceed the target specified by the Total area parameter.</para>
		/// <para>Unchecked—Islands will be allowed.</para>
		/// <para><see cref="NoIslandsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Region growth and search parameters")]
		public object NoIslands { get; set; } = "true";

		/// <summary>
		/// <para>Number of seeds to grow from</para>
		/// <para>Defines the number of seeds from which to grow the potential regions.</para>
		/// <para>The available options are the following:</para>
		/// <para>Based on input—The number of seeds will be based on the number of cells in the input raster. When the input raster has 100,000 cells or fewer, the default is Maximum. When the input raster has more than 100,000 cells, the default is Small. This is the default.</para>
		/// <para>Small—The number of seeds will be equal to 10 percent of the number of cells in the input raster, after NoData cells are excluded, but not to exceed 1,600 seeds.</para>
		/// <para>Medium—The number of seeds will be equal to 20 percent of the number of cells in the input raster, after NoData cells are excluded, but not to exceed 2,500 seeds.</para>
		/// <para>Large—The number of seeds will be equal to 30 percent of the number of cells in the input raster, after NoData cells are excluded, but not to exceed 3,600 seeds.</para>
		/// <para>Maximum—The region growth will occur at each available cell within the input raster. Available cells are all cells that are not NoData and not identified as an existing region.</para>
		/// <para><see cref="RegionSeedsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Region growth and search parameters")]
		public object RegionSeeds { get; set; } = "AUTO";

		/// <summary>
		/// <para>Resolution of the growth</para>
		/// <para>Sets the resolution at which region growth occurs.</para>
		/// <para>The input raster will be resampled to the resolution determined by the number of cells identified by this parameter (see below). For example, for LOW, the input raster is resampled to 147,356 cells. The parameterized region-growing algorithm grows on the resampled intermediate raster. Once the regions are selected from the resampled intermediate raster, the selected regions will be resampled to the Environment cell size.</para>
		/// <para>An adjustment to the target resolutions identified below may be implemented if the number of cells in the desired average region size is too small or too large. This adjustment makes sure there will be enough cells in each desired region or that unnecessary processing will not occur. As a result, the total cells for the intermediate resampled raster for each of the specified resolutions below can be lower or higher than the target number of cells.</para>
		/// <para>If the input has less than 147,356 cells or Maximum is selected, no resampling will occur and the region growth will process on all cells in the input raster. If the input raster has less than 147,356 cells, the Low, Medium, or High options have no effect.</para>
		/// <para>The available options are the following:</para>
		/// <para>Based on input—The resolution will be based on the number of cells in the input raster. When the input raster has 500,000 cells or fewer, the default is Maximum. When the input raster has more than 500,000 cells, the default is Low. This is the default.</para>
		/// <para>Low—The analysis will be performed on an intermediate raster containing 147,356 (384 x 384) cells distributed in the same x and y ratio as the input raster.</para>
		/// <para>Medium—The analysis will be performed on an intermediate raster containing 262,144 (512 x 512) cells distributed in the same x and y ratio as the input raster.</para>
		/// <para>High—The analysis will be performed on an intermediate raster containing 589,824 (768 x 768) cells distributed in the same x and y ratio as the input raster.</para>
		/// <para>Maximum—The analysis will be performed on all cells in the input raster.</para>
		/// <para><see cref="RegionResolutionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Region growth and search parameters")]
		public object RegionResolution { get; set; } = "AUTO";

		/// <summary>
		/// <para>Region selection method</para>
		/// <para>Identifies how the regions will be selected.</para>
		/// <para>The available options are the following:</para>
		/// <para>Based on number of regions—The selection method is based on the Number of regions parameter. If the Number of regions is eight or less, the Combinatorial selection method is used. If the Number of regions parameter is greater than eight, the Sequential selection method is used. This is the default.</para>
		/// <para>Combinatorial—Selects the best regions based on the specified evaluation method, while honoring the spatial constraints, by testing all combinations of the desired number of regions within the candidate regions from the parameterized region-growing (PRG) algorithm.</para>
		/// <para>Sequential—Sequentially selects the best regions based on the evaluation method and that meets the spatial constraints until the desired number of regions is reached.</para>
		/// <para><see cref="SelectionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Region growth and search parameters")]
		public object SelectionMethod { get; set; } = "AUTO";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LocateRegions SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object rasterStatistics = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, rasterStatistics: rasterStatistics, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Area units</para>
		/// </summary>
		public enum AreaUnitsEnum 
		{
			/// <summary>
			/// <para>Square map units—For the square of the linear units of the output spatial reference</para>
			/// </summary>
			[GPValue("SQUARE_MAP_UNITS")]
			[Description("Square map units")]
			Square_map_units,

			/// <summary>
			/// <para>Square miles—For miles</para>
			/// </summary>
			[GPValue("SQUARE_MILES")]
			[Description("Square miles")]
			Square_miles,

			/// <summary>
			/// <para>Square kilometers—For kilometers</para>
			/// </summary>
			[GPValue("SQUARE_KILOMETERS")]
			[Description("Square kilometers")]
			Square_kilometers,

			/// <summary>
			/// <para>Hectares—For hectares</para>
			/// </summary>
			[GPValue("HECTARES")]
			[Description("Hectares")]
			Hectares,

			/// <summary>
			/// <para>Acres—For acres</para>
			/// </summary>
			[GPValue("ACRES")]
			[Description("Acres")]
			Acres,

			/// <summary>
			/// <para>Square meters—For meters</para>
			/// </summary>
			[GPValue("SQUARE_METERS")]
			[Description("Square meters")]
			Square_meters,

			/// <summary>
			/// <para>Square yards—For yards</para>
			/// </summary>
			[GPValue("SQUARE_YARDS")]
			[Description("Square yards")]
			Square_yards,

			/// <summary>
			/// <para>Square feet—For feet</para>
			/// </summary>
			[GPValue("SQUARE_FEET")]
			[Description("Square feet")]
			Square_feet,

		}

		/// <summary>
		/// <para>Region shape</para>
		/// </summary>
		public enum RegionShapeEnum 
		{
			/// <summary>
			/// <para>Circle—Cells that maintain circular regions will receive a greater weight. This is the default.</para>
			/// </summary>
			[GPValue("CIRCLE")]
			[Description("Circle")]
			Circle,

			/// <summary>
			/// <para>Ellipse—Cells that maintain elliptical-shaped regions will receive a greater weight.</para>
			/// </summary>
			[GPValue("ELLIPSE")]
			[Description("Ellipse")]
			Ellipse,

			/// <summary>
			/// <para>Equilateral triangle—Cells that maintain equilateral triangular-shaped regions will receive a greater weight.</para>
			/// </summary>
			[GPValue("TRIANGLE")]
			[Description("Equilateral triangle")]
			Equilateral_triangle,

			/// <summary>
			/// <para>Square—Cells that maintain square-shaped regions will receive a greater weight.</para>
			/// </summary>
			[GPValue("SQUARE")]
			[Description("Square")]
			Square,

			/// <summary>
			/// <para>Pentagon—Cells that maintain pentagon-shaped regions will receive a greater weight.</para>
			/// </summary>
			[GPValue("PENTAGON")]
			[Description("Pentagon")]
			Pentagon,

			/// <summary>
			/// <para>Hexagon—Cells that maintain hexagon-shaped regions will receive a greater weight.</para>
			/// </summary>
			[GPValue("HEXAGON")]
			[Description("Hexagon")]
			Hexagon,

			/// <summary>
			/// <para>Octagon—Cells that maintain octagon-shaped regions will receive a greater weight.</para>
			/// </summary>
			[GPValue("OCTAGON")]
			[Description("Octagon")]
			Octagon,

		}

		/// <summary>
		/// <para>Evaluation method</para>
		/// </summary>
		public enum EvaluationMethodEnum 
		{
			/// <summary>
			/// <para>Highest average value—Selects regions based on the highest average value. This is the default.</para>
			/// </summary>
			[GPValue("HIGHEST_AVERAGE_VALUE")]
			[Description("Highest average value")]
			Highest_average_value,

			/// <summary>
			/// <para>Highest sum—Selects regions based on the highest sum.</para>
			/// </summary>
			[GPValue("HIGHEST_SUM")]
			[Description("Highest sum")]
			Highest_sum,

			/// <summary>
			/// <para>Highest median value—Selects regions based on the highest median value.</para>
			/// </summary>
			[GPValue("HIGHEST_MEDIAN_VALUE")]
			[Description("Highest median value")]
			Highest_median_value,

			/// <summary>
			/// <para>Highest value—Selects regions based on the highest individual cell value contained within the region. This option ensures the best individual cells are selected.</para>
			/// </summary>
			[GPValue("HIGHEST_VALUE")]
			[Description("Highest value")]
			Highest_value,

			/// <summary>
			/// <para>Lowest value—Selects regions based on the highest lowest individual cell value contained within the region. This option ensures the selected regions contain cells with really low utility.</para>
			/// </summary>
			[GPValue("LOWEST_VALUE")]
			[Description("Lowest value")]
			Lowest_value,

			/// <summary>
			/// <para>Greatest core area—Selects regions based on the greatest core area.Any cell that is farther than one cell from the edge of a region is considered to be part of the core. The edge distance can be controlled by the analysis cell size. Setting a smaller cell size can increase the core area.</para>
			/// </summary>
			[GPValue("GREATEST_CORE_AREA")]
			[Description("Greatest core area")]
			Greatest_core_area,

			/// <summary>
			/// <para>Highest sum of core utility values—Selects regions based on the highest cumulative sum of the utility values for the core area. The edge distance can be controlled by the analysis cell size.</para>
			/// </summary>
			[GPValue("HIGHEST_CORE_SUM")]
			[Description("Highest sum of core utility values")]
			Highest_sum_of_core_utility_values,

			/// <summary>
			/// <para>Greatest edge—Selects regions based on the greatest amount of edge using the P1 ratio, which is the ratio of the perimeter of the shape to the perimeter of a circle of the same area. The P1 ratio for a circle is 1.</para>
			/// </summary>
			[GPValue("GREATEST_EDGE")]
			[Description("Greatest edge")]
			Greatest_edge,

		}

		/// <summary>
		/// <para>Distance units</para>
		/// </summary>
		public enum DistanceUnitsEnum 
		{
			/// <summary>
			/// <para>Map units—For the linear units of the output spatial reference</para>
			/// </summary>
			[GPValue("MAP_UNITS")]
			[Description("Map units")]
			Map_units,

			/// <summary>
			/// <para>Miles—For miles</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para>Kilometers—For kilometers</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>Meters—For meters</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Yards—For yards</para>
			/// </summary>
			[GPValue("YARDS")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para>Feet—For feet</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("Feet")]
			Feet,

		}

		/// <summary>
		/// <para>Number of neighbors to use in growth</para>
		/// </summary>
		public enum NumberOfNeighborsEnum 
		{
			/// <summary>
			/// <para>Eight—The eight nearest neighbors (orthogonal and diagonal) will be considered in the region growth. This is the default.</para>
			/// </summary>
			[GPValue("EIGHT")]
			[Description("Eight")]
			Eight,

			/// <summary>
			/// <para>Four—Only the four direct (orthogonal) neighbors of the region cells will be considered in the region growth.</para>
			/// </summary>
			[GPValue("FOUR")]
			[Description("Four")]
			Four,

		}

		/// <summary>
		/// <para>Islands not allowed in regions</para>
		/// </summary>
		public enum NoIslandsEnum 
		{
			/// <summary>
			/// <para>Checked—The parameterized region-growing algorithm ensures there will be no islands within a region. This is the default.A flood field algorithm is implemented as a postprocess once the regions are created but before the regions are selected. If there are islands within a region, they will be filled in and the cells will join the region. Since the fill process occurs before the selection process, the utility of the island cells will be added to the region, and their values will be included in the selection process of the regions and in the statistics of the output regions. As a result of the fill process, it is likely that the total area allocated will exceed the target specified by the Total area parameter.</para>
			/// </summary>
			[GPValue("true")]
			[Description("NO_ISLANDS")]
			NO_ISLANDS,

			/// <summary>
			/// <para>Unchecked—Islands will be allowed.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ISLANDS_ALLOWED")]
			ISLANDS_ALLOWED,

		}

		/// <summary>
		/// <para>Number of seeds to grow from</para>
		/// </summary>
		public enum RegionSeedsEnum 
		{
			/// <summary>
			/// <para>Based on input—The number of seeds will be based on the number of cells in the input raster. When the input raster has 100,000 cells or fewer, the default is Maximum. When the input raster has more than 100,000 cells, the default is Small. This is the default.</para>
			/// </summary>
			[GPValue("AUTO")]
			[Description("Based on input")]
			Based_on_input,

			/// <summary>
			/// <para>Small—The number of seeds will be equal to 10 percent of the number of cells in the input raster, after NoData cells are excluded, but not to exceed 1,600 seeds.</para>
			/// </summary>
			[GPValue("SMALL")]
			[Description("Small")]
			Small,

			/// <summary>
			/// <para>Medium—The number of seeds will be equal to 20 percent of the number of cells in the input raster, after NoData cells are excluded, but not to exceed 2,500 seeds.</para>
			/// </summary>
			[GPValue("MEDIUM")]
			[Description("Medium")]
			Medium,

			/// <summary>
			/// <para>Large—The number of seeds will be equal to 30 percent of the number of cells in the input raster, after NoData cells are excluded, but not to exceed 3,600 seeds.</para>
			/// </summary>
			[GPValue("LARGE")]
			[Description("Large")]
			Large,

			/// <summary>
			/// <para>Maximum—The region growth will occur at each available cell within the input raster. Available cells are all cells that are not NoData and not identified as an existing region.</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("Maximum")]
			Maximum,

		}

		/// <summary>
		/// <para>Resolution of the growth</para>
		/// </summary>
		public enum RegionResolutionEnum 
		{
			/// <summary>
			/// <para>Based on input—The resolution will be based on the number of cells in the input raster. When the input raster has 500,000 cells or fewer, the default is Maximum. When the input raster has more than 500,000 cells, the default is Low. This is the default.</para>
			/// </summary>
			[GPValue("AUTO")]
			[Description("Based on input")]
			Based_on_input,

			/// <summary>
			/// <para>Low—The analysis will be performed on an intermediate raster containing 147,356 (384 x 384) cells distributed in the same x and y ratio as the input raster.</para>
			/// </summary>
			[GPValue("LOW")]
			[Description("Low")]
			Low,

			/// <summary>
			/// <para>Medium—The analysis will be performed on an intermediate raster containing 262,144 (512 x 512) cells distributed in the same x and y ratio as the input raster.</para>
			/// </summary>
			[GPValue("MEDIUM")]
			[Description("Medium")]
			Medium,

			/// <summary>
			/// <para>High—The analysis will be performed on an intermediate raster containing 589,824 (768 x 768) cells distributed in the same x and y ratio as the input raster.</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("High")]
			High,

			/// <summary>
			/// <para>Maximum—The analysis will be performed on all cells in the input raster.</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("Maximum")]
			Maximum,

		}

		/// <summary>
		/// <para>Region selection method</para>
		/// </summary>
		public enum SelectionMethodEnum 
		{
			/// <summary>
			/// <para>Based on number of regions—The selection method is based on the Number of regions parameter. If the Number of regions is eight or less, the Combinatorial selection method is used. If the Number of regions parameter is greater than eight, the Sequential selection method is used. This is the default.</para>
			/// </summary>
			[GPValue("AUTO")]
			[Description("Based on number of regions")]
			Based_on_number_of_regions,

			/// <summary>
			/// <para>Combinatorial—Selects the best regions based on the specified evaluation method, while honoring the spatial constraints, by testing all combinations of the desired number of regions within the candidate regions from the parameterized region-growing (PRG) algorithm.</para>
			/// </summary>
			[GPValue("COMBINATORIAL")]
			[Description("Combinatorial")]
			Combinatorial,

			/// <summary>
			/// <para>Sequential—Sequentially selects the best regions based on the evaluation method and that meets the spatial constraints until the desired number of regions is reached.</para>
			/// </summary>
			[GPValue("SEQUENTIAL")]
			[Description("Sequential")]
			Sequential,

		}

#endregion
	}
}
