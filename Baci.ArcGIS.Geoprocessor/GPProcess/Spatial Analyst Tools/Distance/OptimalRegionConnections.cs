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
	/// <para>Optimal Region Connections</para>
	/// <para>Calculates the optimal connectivity network between two or more input regions.</para>
	/// </summary>
	public class OptimalRegionConnections : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRegions">
		/// <para>Input raster or feature region data</para>
		/// <para>The input regions to be connected by the optimal network.</para>
		/// <para>Regions can be defined by either a raster or a feature dataset.</para>
		/// <para>If the region input is a raster, the regions are defined by groups of contiguous (adjacent) cells of the same value. Each region must be uniquely numbered. The cells that are not part of any region must be NoData. The raster type must be integer, and the values can be either positive or negative.</para>
		/// <para>If the region input is a feature dataset, it can be polygons, polylines, or points. Polygon feature regions cannot be composed of multipart polygons.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output optimal connectivity lines</para>
		/// <para>The output polyline feature class of the optimal network of paths that connect each of the input regions.</para>
		/// <para>Each path (or line) is uniquely numbered and additional fields in the attribute table store specific information about the path. Those additional fields are the following:</para>
		/// <para>PATHID—The unique identifier for the path</para>
		/// <para>PATHCOST—The total accumulative distance or cost for the path</para>
		/// <para>REGION1—The first region the path connects</para>
		/// <para>REGION2—The other region the path connects</para>
		/// <para>This information provides insight into the paths in the network.</para>
		/// <para>Since each path is represented by a unique line, there will be multiple lines in locations where paths travel the same route.</para>
		/// </param>
		public OptimalRegionConnections(object InRegions, object OutFeatureClass)
		{
			this.InRegions = InRegions;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Optimal Region Connections</para>
		/// </summary>
		public override string DisplayName => "Optimal Region Connections";

		/// <summary>
		/// <para>Tool Name : OptimalRegionConnections</para>
		/// </summary>
		public override string ToolName => "OptimalRegionConnections";

		/// <summary>
		/// <para>Tool Excute Name : sa.OptimalRegionConnections</para>
		/// </summary>
		public override string ExcuteName => "sa.OptimalRegionConnections";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "maintainSpatialIndex", "mask", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRegions, OutFeatureClass, InBarrierData!, InCostRaster!, OutNeighborPaths!, DistanceMethod!, ConnectionsWithinRegions! };

		/// <summary>
		/// <para>Input raster or feature region data</para>
		/// <para>The input regions to be connected by the optimal network.</para>
		/// <para>Regions can be defined by either a raster or a feature dataset.</para>
		/// <para>If the region input is a raster, the regions are defined by groups of contiguous (adjacent) cells of the same value. Each region must be uniquely numbered. The cells that are not part of any region must be NoData. The raster type must be integer, and the values can be either positive or negative.</para>
		/// <para>If the region input is a feature dataset, it can be polygons, polylines, or points. Polygon feature regions cannot be composed of multipart polygons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InRegions { get; set; }

		/// <summary>
		/// <para>Output optimal connectivity lines</para>
		/// <para>The output polyline feature class of the optimal network of paths that connect each of the input regions.</para>
		/// <para>Each path (or line) is uniquely numbered and additional fields in the attribute table store specific information about the path. Those additional fields are the following:</para>
		/// <para>PATHID—The unique identifier for the path</para>
		/// <para>PATHCOST—The total accumulative distance or cost for the path</para>
		/// <para>REGION1—The first region the path connects</para>
		/// <para>REGION2—The other region the path connects</para>
		/// <para>This information provides insight into the paths in the network.</para>
		/// <para>Since each path is represented by a unique line, there will be multiple lines in locations where paths travel the same route.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Input barrier raster or feature data</para>
		/// <para>The dataset that defines the barriers.</para>
		/// <para>The barriers can be defined by an integer or a floating-point raster, or by a point, line, or polygon feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object? InBarrierData { get; set; }

		/// <summary>
		/// <para>Input cost raster</para>
		/// <para>A raster defining the impedance or cost to move planimetrically through each cell.</para>
		/// <para>The value at each cell location represents the cost-per-unit distance for moving through the cell. Each cell location value is multiplied by the cell resolution while also compensating for diagonal movement to obtain the total cost of passing through the cell.</para>
		/// <para>The values of the cost raster can be integer or floating point, but they cannot be negative or zero (you cannot have a negative or zero cost).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object? InCostRaster { get; set; }

		/// <summary>
		/// <para>Output feature class of neighboring connections</para>
		/// <para>The output polyline feature class identifying all paths from each region to each of its closest or cost neighbors.</para>
		/// <para>Each path (or line) is uniquely numbered and additional fields in the attribute table store specific information about the path. Those additional fields are the following:</para>
		/// <para>PATHID—The unique identifier for the path</para>
		/// <para>PATHCOST—The total accumulative distance or cost for the path</para>
		/// <para>REGION1—The first region the path connects</para>
		/// <para>REGION2—The other region the path connects</para>
		/// <para>This information provides insight into the paths in the network and is useful when deciding which paths should be removed if necessary.</para>
		/// <para>Since each path is represented by a unique line, there will be multiple lines in locations where paths travel the same route.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutNeighborPaths { get; set; }

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>Specifies whether the distance will be calculated using a planar (flat earth) or a geodesic (ellipsoid) method.</para>
		/// <para>Planar—The distance calculation will be performed on a projected flat plane using a 2D Cartesian coordinate system. This is the default.</para>
		/// <para>Geodesic—The distance calculation will be performed on the ellipsoid. Regardless of input or output projection, the results will not change.</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DistanceMethod { get; set; } = "PLANAR";

		/// <summary>
		/// <para>Connections within regions</para>
		/// <para>Specifies whether the paths will continue and connect within the input regions.</para>
		/// <para>Generate connections—Paths will continue within the input regions to connect all paths that enter a region.</para>
		/// <para>No connections—Paths will stop at the edges of the input regions and will not continue or connect within them.</para>
		/// <para><see cref="ConnectionsWithinRegionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ConnectionsWithinRegions { get; set; } = "GENERATE_CONNECTIONS";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public OptimalRegionConnections SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , bool? maintainSpatialIndex = null , object? mask = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , object? scratchWorkspace = null , object? snapRaster = null , object? workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, maintainSpatialIndex: maintainSpatialIndex, mask: mask, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Method</para>
		/// </summary>
		public enum DistanceMethodEnum 
		{
			/// <summary>
			/// <para>Planar—The distance calculation will be performed on a projected flat plane using a 2D Cartesian coordinate system. This is the default.</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("Planar")]
			Planar,

			/// <summary>
			/// <para>Geodesic—The distance calculation will be performed on the ellipsoid. Regardless of input or output projection, the results will not change.</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("Geodesic")]
			Geodesic,

		}

		/// <summary>
		/// <para>Connections within regions</para>
		/// </summary>
		public enum ConnectionsWithinRegionsEnum 
		{
			/// <summary>
			/// <para>Generate connections—Paths will continue within the input regions to connect all paths that enter a region.</para>
			/// </summary>
			[GPValue("GENERATE_CONNECTIONS")]
			[Description("Generate connections")]
			Generate_connections,

			/// <summary>
			/// <para>No connections—Paths will stop at the edges of the input regions and will not continue or connect within them.</para>
			/// </summary>
			[GPValue("NO_CONNECTIONS")]
			[Description("No connections")]
			No_connections,

		}

#endregion
	}
}
