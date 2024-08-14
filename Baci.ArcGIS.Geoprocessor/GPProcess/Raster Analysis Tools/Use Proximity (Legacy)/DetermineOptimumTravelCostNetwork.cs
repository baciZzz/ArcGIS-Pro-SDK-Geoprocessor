using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.RasterAnalysisTools
{
	/// <summary>
	/// <para>Determine Optimum Travel Cost Network</para>
	/// <para>Calculates the optimum cost network from a set of input regions.</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.RasterAnalysisTools.OptimalRegionConnections"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.RasterAnalysisTools.OptimalRegionConnections))]
	public class DetermineOptimumTravelCostNetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputregionsrasterorfeatures">
		/// <para>Input Regions Raster or Features</para>
		/// <para>The input regions that are to be connected by the least-cost network.</para>
		/// <para>Regions can be defined by either an image service or a feature service.</para>
		/// <para>If the region input is a raster, the regions are defined by groups of contiguous (adjacent) cells of the same value. Each region must be uniquely numbered. The cells that are not part of any region must be NoData. The raster type must be integer, and the values can be either positive or negative.</para>
		/// <para>If the region input is a feature, it can be polygons, lines, or points. Polygon feature regions cannot be composed of multipart polygons.</para>
		/// </param>
		/// <param name="Inputcostraster">
		/// <para>Input Cost Raster</para>
		/// <para>A raster defining the impedance or cost to move planimetrically through each cell.</para>
		/// <para>The value at each cell location represents the cost-per-unit distance for moving through the cell. Each cell location value is multiplied by the cell resolution while also compensating for diagonal movement to obtain the total cost of passing through the cell.</para>
		/// <para>The values of the cost raster can be integer or floating point, but they cannot be negative or zero (you cannot have a negative or zero cost).</para>
		/// </param>
		/// <param name="Outputoptimumnetworkname">
		/// <para>Output Optimum Network Name</para>
		/// <para>The name of the output optimum network feature service.</para>
		/// <para>The polyline feature service of the optimum (least-cost) network of paths necessary to connect each of the input regions.</para>
		/// <para>Each path (or line) is uniquely numbered, and additional fields in the attribute table store specific information about the path. Those fields include the following:</para>
		/// <para>PATHID—Unique identifier for the path</para>
		/// <para>PATHCOST—Total accumulative cost for the path</para>
		/// <para>REGION1—The first region the path connects</para>
		/// <para>REGION2—The other region the path connects</para>
		/// <para>This information provides you insight into the paths within the network.</para>
		/// <para>Since each path is represented by a unique line, there will be multiple lines in locations where paths travel the same route.</para>
		/// </param>
		public DetermineOptimumTravelCostNetwork(object Inputregionsrasterorfeatures, object Inputcostraster, object Outputoptimumnetworkname)
		{
			this.Inputregionsrasterorfeatures = Inputregionsrasterorfeatures;
			this.Inputcostraster = Inputcostraster;
			this.Outputoptimumnetworkname = Outputoptimumnetworkname;
		}

		/// <summary>
		/// <para>Tool Display Name : Determine Optimum Travel Cost Network</para>
		/// </summary>
		public override string DisplayName => "Determine Optimum Travel Cost Network";

		/// <summary>
		/// <para>Tool Name : DetermineOptimumTravelCostNetwork</para>
		/// </summary>
		public override string ToolName => "DetermineOptimumTravelCostNetwork";

		/// <summary>
		/// <para>Tool Excute Name : ra.DetermineOptimumTravelCostNetwork</para>
		/// </summary>
		public override string ExcuteName => "ra.DetermineOptimumTravelCostNetwork";

		/// <summary>
		/// <para>Toolbox Display Name : Raster Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Raster Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : ra</para>
		/// </summary>
		public override string ToolboxAlise => "ra";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "cellSize", "extent", "mask", "outputCoordinateSystem", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { Inputregionsrasterorfeatures, Inputcostraster, Outputoptimumnetworkname, Outputneighbornetworkname!, Outputoptimumnetworkfeatures!, Outputneighbornetworkfeatures! };

		/// <summary>
		/// <para>Input Regions Raster or Features</para>
		/// <para>The input regions that are to be connected by the least-cost network.</para>
		/// <para>Regions can be defined by either an image service or a feature service.</para>
		/// <para>If the region input is a raster, the regions are defined by groups of contiguous (adjacent) cells of the same value. Each region must be uniquely numbered. The cells that are not part of any region must be NoData. The raster type must be integer, and the values can be either positive or negative.</para>
		/// <para>If the region input is a feature, it can be polygons, lines, or points. Polygon feature regions cannot be composed of multipart polygons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputregionsrasterorfeatures { get; set; }

		/// <summary>
		/// <para>Input Cost Raster</para>
		/// <para>A raster defining the impedance or cost to move planimetrically through each cell.</para>
		/// <para>The value at each cell location represents the cost-per-unit distance for moving through the cell. Each cell location value is multiplied by the cell resolution while also compensating for diagonal movement to obtain the total cost of passing through the cell.</para>
		/// <para>The values of the cost raster can be integer or floating point, but they cannot be negative or zero (you cannot have a negative or zero cost).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputcostraster { get; set; }

		/// <summary>
		/// <para>Output Optimum Network Name</para>
		/// <para>The name of the output optimum network feature service.</para>
		/// <para>The polyline feature service of the optimum (least-cost) network of paths necessary to connect each of the input regions.</para>
		/// <para>Each path (or line) is uniquely numbered, and additional fields in the attribute table store specific information about the path. Those fields include the following:</para>
		/// <para>PATHID—Unique identifier for the path</para>
		/// <para>PATHCOST—Total accumulative cost for the path</para>
		/// <para>REGION1—The first region the path connects</para>
		/// <para>REGION2—The other region the path connects</para>
		/// <para>This information provides you insight into the paths within the network.</para>
		/// <para>Since each path is represented by a unique line, there will be multiple lines in locations where paths travel the same route.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputoptimumnetworkname { get; set; }

		/// <summary>
		/// <para>Output Neighbor Network Name</para>
		/// <para>The name of the output Neighbor network feature service.</para>
		/// <para>The polyline feature service identifying all paths from each region to each of its closest-cost neighbors.</para>
		/// <para>Each path (or line) is uniquely numbered, and additional fields in the attribute table store specific information about the path. Those fields include the following:</para>
		/// <para>PATHID—Unique identifier for the path</para>
		/// <para>PATHCOST—Total accumulative cost for the path</para>
		/// <para>REGION1—The first region the path connects</para>
		/// <para>REGION2—The other region the path connects</para>
		/// <para>This information provides you insight into the paths within the network and is particularly useful when deciding which paths should be removed if necessary.</para>
		/// <para>Since each path is represented by a unique line, there will be multiple lines in locations where paths travel the same route.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Outputneighbornetworkname { get; set; }

		/// <summary>
		/// <para>Output Optimum Network Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? Outputoptimumnetworkfeatures { get; set; }

		/// <summary>
		/// <para>Output Neighbor Network Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? Outputneighbornetworkfeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DetermineOptimumTravelCostNetwork SetEnviroment(object? cellSize = null , object? extent = null , object? mask = null , object? outputCoordinateSystem = null , object? snapRaster = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, snapRaster: snapRaster);
			return this;
		}

	}
}
