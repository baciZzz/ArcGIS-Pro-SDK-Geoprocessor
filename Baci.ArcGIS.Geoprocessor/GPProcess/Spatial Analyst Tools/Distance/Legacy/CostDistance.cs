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
	/// <para>Cost Distance</para>
	/// <para>Cost Distance</para>
	/// <para>Calculates the least accumulative cost distance for each cell from or to the least-cost source over a cost surface.</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.DistanceAccumulation"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.DistanceAccumulation))]
	public class CostDistance : AbstractGPProcess
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
		/// <param name="InCostRaster">
		/// <para>Input cost raster</para>
		/// <para>A raster defining the impedance or cost to move planimetrically through each cell.</para>
		/// <para>The value at each cell location represents the cost-per-unit distance for moving through the cell. Each cell location value is multiplied by the cell resolution while also compensating for diagonal movement to obtain the total cost of passing through the cell.</para>
		/// <para>The values of the cost raster can be integer or floating point, but they cannot be negative or zero (you cannot have a negative or zero cost).</para>
		/// </param>
		/// <param name="OutDistanceRaster">
		/// <para>Output distance raster</para>
		/// <para>The output cost distance raster.</para>
		/// <para>The cost distance raster identifies, for each cell, the least accumulative cost distance over a cost surface to the identified source locations.</para>
		/// <para>A source can be a cell, a set of cells, or one or more feature locations.</para>
		/// <para>The output raster is of floating-point type.</para>
		/// </param>
		public CostDistance(object InSourceData, object InCostRaster, object OutDistanceRaster)
		{
			this.InSourceData = InSourceData;
			this.InCostRaster = InCostRaster;
			this.OutDistanceRaster = OutDistanceRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Cost Distance</para>
		/// </summary>
		public override string DisplayName() => "Cost Distance";

		/// <summary>
		/// <para>Tool Name : CostDistance</para>
		/// </summary>
		public override string ToolName() => "CostDistance";

		/// <summary>
		/// <para>Tool Excute Name : sa.CostDistance</para>
		/// </summary>
		public override string ExcuteName() => "sa.CostDistance";

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
		public override object[] Parameters() => new object[] { InSourceData, InCostRaster, OutDistanceRaster, MaximumDistance, OutBacklinkRaster, SourceCostMultiplier, SourceStartCost, SourceResistanceRate, SourceCapacity, SourceDirection };

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
		/// <para>Input cost raster</para>
		/// <para>A raster defining the impedance or cost to move planimetrically through each cell.</para>
		/// <para>The value at each cell location represents the cost-per-unit distance for moving through the cell. Each cell location value is multiplied by the cell resolution while also compensating for diagonal movement to obtain the total cost of passing through the cell.</para>
		/// <para>The values of the cost raster can be integer or floating point, but they cannot be negative or zero (you cannot have a negative or zero cost).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InCostRaster { get; set; }

		/// <summary>
		/// <para>Output distance raster</para>
		/// <para>The output cost distance raster.</para>
		/// <para>The cost distance raster identifies, for each cell, the least accumulative cost distance over a cost surface to the identified source locations.</para>
		/// <para>A source can be a cell, a set of cells, or one or more feature locations.</para>
		/// <para>The output raster is of floating-point type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutDistanceRaster { get; set; }

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
		/// <para>The backlink raster contains values 0 through 8, which define the direction or identify the next neighboring cell (the succeeding cell) along the least accumulative cost path from a cell to reach its least-cost source.</para>
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
		/// <para>Specifies the direction of the traveler when applying the source resistance rate and the source starting cost.</para>
		/// <para>Travel from source—The source resistance rate and source starting cost will be applied beginning at the input source, and travel out to the non-source cells. This is the default.</para>
		/// <para>Travel to source—The source resistance rate and source starting cost will be applied beginning at each non-source cell, and travel back to the input source.</para>
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
		public CostDistance SetEnviroment(int? autoCommit = null, object cellSize = null, object compression = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object scratchWorkspace = null, object snapRaster = null, double[] tileSize = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
