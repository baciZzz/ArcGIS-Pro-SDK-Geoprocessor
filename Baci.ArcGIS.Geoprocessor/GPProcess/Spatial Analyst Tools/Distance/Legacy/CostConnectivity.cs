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
	/// <para>Cost Connectivity</para>
	/// <para>Cost Connectivity</para>
	/// <para>Produces the least-cost connectivity network between two or more input regions.</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.OptimalRegionConnections"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.SpatialAnalystTools.OptimalRegionConnections))]
	public class CostConnectivity : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRegions">
		/// <para>Input raster or feature region data</para>
		/// <para>The input regions that are to be connected by the least-cost network.</para>
		/// <para>Regions can be defined by either a raster or a feature dataset.</para>
		/// <para>If the region input is a raster, the regions are defined by groups of contiguous (adjacent) cells of the same value. Each region must be uniquely numbered. The cells that are not part of any region must be NoData. The raster type must be integer, and the values can be either positive or negative.</para>
		/// <para>If the region input is a feature dataset, it can be either polygons, lines, or points. Polygon feature regions cannot be composed of multipart polygons.</para>
		/// </param>
		/// <param name="InCostRaster">
		/// <para>Input cost raster</para>
		/// <para>A raster defining the impedance or cost to move planimetrically through each cell.</para>
		/// <para>The value at each cell location represents the cost-per-unit distance for moving through the cell. Each cell location value is multiplied by the cell resolution while also compensating for diagonal movement to obtain the total cost of passing through the cell.</para>
		/// <para>The values of the cost raster can be integer or floating point, but they cannot be negative or zero (you cannot have a negative or zero cost).</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output feature class</para>
		/// <para>The output polyline feature class of the optimum (least-cost) network of paths necessary to connect each of the input regions.</para>
		/// <para>Each path (or line) is uniquely numbered, and additional fields in the attribute table store specific information about the path. Those fields include the following:</para>
		/// <para>PATHID—Unique identifier for the path</para>
		/// <para>PATHCOST—Total accumulative cost for the path</para>
		/// <para>REGION1—The first region the path connects</para>
		/// <para>REGION2—The other region the path connects</para>
		/// <para>This information provides you insight into the paths within the network.</para>
		/// <para>Since each path is represented by a unique line, there will be multiple lines in locations where paths travel the same route.</para>
		/// </param>
		public CostConnectivity(object InRegions, object InCostRaster, object OutFeatureClass)
		{
			this.InRegions = InRegions;
			this.InCostRaster = InCostRaster;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Cost Connectivity</para>
		/// </summary>
		public override string DisplayName() => "Cost Connectivity";

		/// <summary>
		/// <para>Tool Name : CostConnectivity</para>
		/// </summary>
		public override string ToolName() => "CostConnectivity";

		/// <summary>
		/// <para>Tool Excute Name : sa.CostConnectivity</para>
		/// </summary>
		public override string ExcuteName() => "sa.CostConnectivity";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "maintainSpatialIndex", "mask", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRegions, InCostRaster, OutFeatureClass, OutNeighborPaths! };

		/// <summary>
		/// <para>Input raster or feature region data</para>
		/// <para>The input regions that are to be connected by the least-cost network.</para>
		/// <para>Regions can be defined by either a raster or a feature dataset.</para>
		/// <para>If the region input is a raster, the regions are defined by groups of contiguous (adjacent) cells of the same value. Each region must be uniquely numbered. The cells that are not part of any region must be NoData. The raster type must be integer, and the values can be either positive or negative.</para>
		/// <para>If the region input is a feature dataset, it can be either polygons, lines, or points. Polygon feature regions cannot be composed of multipart polygons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "DEFeatureClass", "GPFeatureLayer", "DETin", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("OID", "Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRegions { get; set; }

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
		/// <para>Output feature class</para>
		/// <para>The output polyline feature class of the optimum (least-cost) network of paths necessary to connect each of the input regions.</para>
		/// <para>Each path (or line) is uniquely numbered, and additional fields in the attribute table store specific information about the path. Those fields include the following:</para>
		/// <para>PATHID—Unique identifier for the path</para>
		/// <para>PATHCOST—Total accumulative cost for the path</para>
		/// <para>REGION1—The first region the path connects</para>
		/// <para>REGION2—The other region the path connects</para>
		/// <para>This information provides you insight into the paths within the network.</para>
		/// <para>Since each path is represented by a unique line, there will be multiple lines in locations where paths travel the same route.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Output feature class of neighboring connections</para>
		/// <para>The output polyline feature class identifying all paths from each region to each of its closest-cost neighbors.</para>
		/// <para>Each path (or line) is uniquely numbered, and additional fields in the attribute table store specific information about the path. Those fields include the following:</para>
		/// <para>PATHID—Unique identifier for the path</para>
		/// <para>PATHCOST—Total accumulative cost for the path</para>
		/// <para>REGION1—The first region the path connects</para>
		/// <para>REGION2—The other region the path connects</para>
		/// <para>This information provides you insight into the paths within the network and is particularly useful when deciding which paths should be removed if necessary.</para>
		/// <para>Since each path is represented by a unique line, there will be multiple lines in locations where paths travel the same route.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutNeighborPaths { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CostConnectivity SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , bool? maintainSpatialIndex = null , object? mask = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , object? scratchWorkspace = null , object? snapRaster = null , object? workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, maintainSpatialIndex: maintainSpatialIndex, mask: mask, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

	}
}
