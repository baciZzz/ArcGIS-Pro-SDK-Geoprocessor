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
	/// <para>Path Distance</para>
	/// <para>Calculates, for each cell, the least accumulative cost distance from or to the least-cost source, while accounting for surface distance along with horizontal and vertical cost factors.</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.DistanceAccumulation"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.DistanceAccumulation))]
	public class PathDistance : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSourceData">
		/// <para>Input raster or feature source data</para>
		/// <para>The input source locations.</para>
		/// <para>This is a raster or feature dataset that identifies the cells or locations from or to which the least accumulated cost distance for every output cell location is calculated.</para>
		/// <para>For rasters, the input type can be integer or floating point.</para>
		/// </param>
		/// <param name="OutDistanceRaster">
		/// <para>Output distance raster</para>
		/// <para>The output path distance raster.</para>
		/// <para>The output path distance raster identifies, for each cell, the least accumulative cost distance, over a cost surface to the identified source locations, while accounting for surface distance as well as horizontal and vertical surface factors.</para>
		/// <para>A source can be a cell, a set of cells, or one or more feature locations.</para>
		/// <para>The output raster is of floating-point type.</para>
		/// </param>
		public PathDistance(object InSourceData, object OutDistanceRaster)
		{
			this.InSourceData = InSourceData;
			this.OutDistanceRaster = OutDistanceRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Path Distance</para>
		/// </summary>
		public override string DisplayName() => "Path Distance";

		/// <summary>
		/// <para>Tool Name : PathDistance</para>
		/// </summary>
		public override string ToolName() => "PathDistance";

		/// <summary>
		/// <para>Tool Excute Name : sa.PathDistance</para>
		/// </summary>
		public override string ExcuteName() => "sa.PathDistance";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSourceData, OutDistanceRaster, InCostRaster, InSurfaceRaster, InHorizontalRaster, HorizontalFactor, InVerticalRaster, VerticalFactor, MaximumDistance, OutBacklinkRaster, SourceCostMultiplier, SourceStartCost, SourceResistanceRate, SourceCapacity, SourceDirection };

		/// <summary>
		/// <para>Input raster or feature source data</para>
		/// <para>The input source locations.</para>
		/// <para>This is a raster or feature dataset that identifies the cells or locations from or to which the least accumulated cost distance for every output cell location is calculated.</para>
		/// <para>For rasters, the input type can be integer or floating point.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InSourceData { get; set; }

		/// <summary>
		/// <para>Output distance raster</para>
		/// <para>The output path distance raster.</para>
		/// <para>The output path distance raster identifies, for each cell, the least accumulative cost distance, over a cost surface to the identified source locations, while accounting for surface distance as well as horizontal and vertical surface factors.</para>
		/// <para>A source can be a cell, a set of cells, or one or more feature locations.</para>
		/// <para>The output raster is of floating-point type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutDistanceRaster { get; set; }

		/// <summary>
		/// <para>Input cost raster</para>
		/// <para>A raster defining the impedance or cost to move planimetrically through each cell.</para>
		/// <para>The value at each cell location represents the cost-per-unit distance for moving through the cell. Each cell location value is multiplied by the cell resolution while also compensating for diagonal movement to obtain the total cost of passing through the cell.</para>
		/// <para>The values of the cost raster can be integer or floating point, but they cannot be negative or zero (you cannot have a negative or zero cost).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InCostRaster { get; set; }

		/// <summary>
		/// <para>Input surface raster</para>
		/// <para>A raster defining the elevation values at each cell location.</para>
		/// <para>The values are used to calculate the actual surface distance covered when passing between cells.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InSurfaceRaster { get; set; }

		/// <summary>
		/// <para>Input horizontal raster</para>
		/// <para>A raster defining the horizontal direction at each cell.</para>
		/// <para>The values on the raster must be integers ranging from 0 to 360, with 0 degrees being north, or toward the top of the screen, and increasing clockwise. Flat areas should be given a value of -1. The values at each location will be used in conjunction with the Horizontal factor to determine the horizontal cost incurred when moving from a cell to its neighbors.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		[Category("Horizontal factor parameters (optional)")]
		public object InHorizontalRaster { get; set; }

		/// <summary>
		/// <para>Horizontal factor</para>
		/// <para>Specifies the relationship between the horizontal cost factor and the horizontal relative moving angle (HRMA).</para>
		/// <para>There are several factors with modifiers from which to select that identify a defined horizontal factor graph. Additionally, a table can be used to create a custom graph. The graphs are used to identify the horizontal factor used in calculating the total cost for moving into a neighboring cell.</para>
		/// <para>In the descriptions below, two acronyms are used: HF stands for horizontal factor, which defines the horizontal difficulty encountered when moving from one cell to the next; and HRMA stands for horizontal relative moving angle, which identifies the angle between the horizontal direction from a cell and the moving direction.</para>
		/// <para>The Horizontal factor options are as follows:</para>
		/// <para>Binary—If the HRMA is less than the cut angle, the HF is set to the value associated with the zero factor; otherwise, it is infinity.</para>
		/// <para>Forward—Only forward movement is allowed. The HRMA must be greater than or equal to 0 and less than 90 degrees (0 &lt;= HRMA &lt; 90). If the HRMA is greater than 0 and less than 45 degrees, the HF for the cell is set to the value associated with the zero factor. If the HRMA is greater than or equal to 45 degrees, the side value modifier value is used. The HF for any HRMA equal to or greater than 90 degrees is set to infinity.</para>
		/// <para>Linear—The HF is a linear function of the HRMA.</para>
		/// <para>Inverse Linear—The HF is an inverse linear function of the HRMA.</para>
		/// <para>Table—A table file will be used to define the horizontal factor graph used to determine the HFs.</para>
		/// <para>Modifiers to the horizontal factors are the following:</para>
		/// <para>Zero factor—The horizontal factor to be used when the HRMA is zero. This factor positions the y-intercept for any of the horizontal factor functions.</para>
		/// <para>Cut angle—The HRMA angle beyond which the HF will be set to infinity.</para>
		/// <para>Slope—The slope of the straight line used with the Linear and Inverse Linear horizontal factor keywords. The slope is specified as a fraction of rise over run (for example, 45 percent slope is 1/45, which is input as 0.02222).</para>
		/// <para>Side value—The HF when the HRMA is greater than or equal to 45 degrees and less than 90 degrees when the Forward horizontal factor keyword is specified.</para>
		/// <para>Table name—The name of the table defining the HF.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAHorizontalFactor()]
		[Category("Horizontal factor parameters (optional)")]
		public object HorizontalFactor { get; set; } = "BINARY 1 45";

		/// <summary>
		/// <para>Input vertical raster</para>
		/// <para>A raster defining the z-values for each cell location.</para>
		/// <para>The values are used for calculating the slope used to identify the vertical factor incurred when moving from one cell to another.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		[Category("Vertical factor parameters (optional)")]
		public object InVerticalRaster { get; set; }

		/// <summary>
		/// <para>Vertical factor</para>
		/// <para>Specifies the relationship between the vertical cost factor and the vertical relative moving angle (VRMA).</para>
		/// <para>There are several factors with modifiers from which to select that identify a defined vertical factor graph. Additionally, a table can be used to create a custom graph. The graphs are used to identify the vertical factor used in calculating the total cost for moving into a neighboring cell.</para>
		/// <para>In the descriptions below, two acronyms are used: VF stands for vertical factor, which defines the vertical difficulty encountered in moving from one cell to the next; and VRMA stands for vertical relative moving angle, which identifies the slope angle between the FROM or processing cell and the TO cell.</para>
		/// <para>The Vertical factor options are as follows:</para>
		/// <para>Binary—If the VRMA is greater than the low-cut angle and less than the high-cut angle, the VF is set to the value associated with the zero factor; otherwise, it is infinity.</para>
		/// <para>Linear—The VF is a linear function of the VRMA.</para>
		/// <para>Symmetric Linear—The VF is a linear function of the VRMA in either the negative or positive side of the VRMA, respectively, and the two linear functions are symmetrical with respect to the VF (y) axis.</para>
		/// <para>Inverse Linear—The VF is an inverse linear function of the VRMA.</para>
		/// <para>Symmetric Inverse Linear—The VF is an inverse linear function of the VRMA in either the negative or positive side of the VRMA, respectively, and the two linear functions are symmetrical with respect to the VF (y) axis.</para>
		/// <para>Cos—The VF is the cosine-based function of the VRMA.</para>
		/// <para>Sec—The VF is the secant-based function of the VRMA.</para>
		/// <para>Cos-Sec—The VF is the cosine-based function of the VRMA when the VRMA is negative and is the secant-based function of the VRMA when the VRMA is nonnegative.</para>
		/// <para>Sec-Cos—The VF is the secant-based function of the VRMA when the VRMA is negative and is the cosine-based function of the VRMA when the VRMA is nonnegative.</para>
		/// <para>Table—A table file will be used to define the vertical-factor graph used to determine the VFs.</para>
		/// <para>Modifiers to the vertical keywords are the following:</para>
		/// <para>Zero factor—The vertical factor used when the VRMA is zero. This factor positions the y-intercept of the specified function. By definition, the zero factor is not applicable to any of the trigonometric vertical functions (COS, SEC, COS-SEC, or SEC-COS). The y-intercept is defined by these functions.</para>
		/// <para>Low Cut angle—The VRMA angle below which the VF will be set to infinity.</para>
		/// <para>High Cut angle—The VRMA angle above which the VF will be set to infinity.</para>
		/// <para>Slope—The slope of the straight line used with the Linear and Inverse Linear vertical-factor keywords. The slope is specified as a fraction of rise over run (for example, 45 percent slope is 1/45, which is input as 0.02222).</para>
		/// <para>Table name—The name of the table defining the VF.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAVerticalFactor()]
		[Category("Vertical factor parameters (optional)")]
		public object VerticalFactor { get; set; } = "BINARY 1 -30 30";

		/// <summary>
		/// <para>Maximum distance</para>
		/// <para>The threshold that the accumulative cost values cannot exceed.</para>
		/// <para>If an accumulative cost distance value exceeds this value, the output value for the cell location will be NoData. The maximum distance is the extent for which the accumulative cost distances are calculated.</para>
		/// <para>The default distance is to the edge of the output raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object MaximumDistance { get; set; }

		/// <summary>
		/// <para>Output backlink raster</para>
		/// <para>The output cost backlink raster.</para>
		/// <para>The backlink raster contains values 0 through 8, which define the direction or identify the next neighboring cell (the succeeding cell) along the least accumulative cost path from a cell to reach its least-cost source, while accounting for surface distance as well as horizontal and vertical surface factors.</para>
		/// <para>If the path is to pass into the right neighbor, the cell will be assigned the value 1, 2 for the lower right diagonal cell, and continue clockwise. The value 0 is reserved for source cells.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object OutBacklinkRaster { get; set; }

		/// <summary>
		/// <para>Multiplier to apply to costs</para>
		/// <para>The multiplier to apply to the cost values.</para>
		/// <para>This allows for control of the mode of travel or the magnitude at a source. The greater the multiplier, the greater the cost to move through each cell.</para>
		/// <para>The values must be greater than zero. The default is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Source Characteristics")]
		public object SourceCostMultiplier { get; set; }

		/// <summary>
		/// <para>Start cost</para>
		/// <para>The starting cost from which to begin the cost calculations.</para>
		/// <para>Allows for the specification of the fixed cost associated with a source. Instead of starting at a cost of zero, the cost algorithm will begin with the value set by Start cost.</para>
		/// <para>The values must be zero or greater. The default is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Source Characteristics")]
		public object SourceStartCost { get; set; }

		/// <summary>
		/// <para>Accumulative cost resistance rate</para>
		/// <para>This parameter simulates the increase in the effort to overcome costs as the accumulative cost increases. It is used to model fatigue of the traveler. The growing accumulative cost to reach a cell is multiplied by the resistance rate and added to the cost to move into the subsequent cell.</para>
		/// <para>It is a modified version of a compound interest rate formula that is used to calculate the apparent cost of moving through a cell. As the value of the resistance rate increases, it increases the cost of the cells that are visited later. The greater the resistance rate, the more additional cost is added to reach the next cell, which is compounded for each subsequent movement. Since the resistance rate is similar to a compound rate and generally the accumulative cost values are very large, small resistance rates are suggested, such as 0.02, 0.005, or even smaller, depending on the accumulative cost values.</para>
		/// <para>The values must be zero or greater. The default is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Source Characteristics")]
		public object SourceResistanceRate { get; set; }

		/// <summary>
		/// <para>Capacity</para>
		/// <para>The cost capacity for the traveler for a source.</para>
		/// <para>The cost calculations continue for each source until the specified capacity is reached.</para>
		/// <para>The values must be greater than zero. The default capacity is to the edge of the output raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Source Characteristics")]
		public object SourceCapacity { get; set; }

		/// <summary>
		/// <para>Travel direction</para>
		/// <para>Specifies the direction of the traveler when applying horizontal and vertical factors and the source resistance rate.</para>
		/// <para>Travel from source—The horizontal factor, vertical factor and source resistance rate will be applied beginning at the input source, and travel out to the nonsource cells. This is the default.</para>
		/// <para>Travel to source—The horizontal factor, vertical factor and source resistance rate will be applied beginning at each nonsource cell and travel back to the input source.</para>
		/// <para>If you select the String option, you can choose between from and to options, which will be applied to all sources.</para>
		/// <para>If you select the Field option, you can select the field from the source data that determines the direction to use for each source. The field must contain the text string FROM_SOURCE or TO_SOURCE.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Source Characteristics")]
		public object SourceDirection { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PathDistance SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
