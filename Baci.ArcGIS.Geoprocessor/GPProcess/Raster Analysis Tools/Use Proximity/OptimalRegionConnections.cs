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
	/// <para>Optimal Region Connections</para>
	/// <para>Optimal Region Connections</para>
	/// <para>Calculates the optimal connection of paths between two or more input regions.</para>
	/// </summary>
	public class OptimalRegionConnections : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputregionrasterorfeatures">
		/// <para>Input Region Raster or Features</para>
		/// <para>The input regions to be connected by the optimal network.</para>
		/// <para>Regions can be defined by either raster or feature data.</para>
		/// <para>If the region input is raster, the regions are defined by groups of contiguous (adjacent) cells of the same value. Each region must be uniquely numbered. The cells that are not part of any region must be NoData. The raster type must be integer, and the values can be either positive or negative.</para>
		/// <para>If the region input is feature data, it can be polygons, lines, or points. Polygon feature regions cannot be composed of multipart polygons.</para>
		/// </param>
		/// <param name="Outputoptimallinesname">
		/// <para>Output Optimal Connectivity Lines Name</para>
		/// <para>The name of the output line feature service that connects each input region.</para>
		/// <para>Each path (or line) is uniquely numbered and additional fields in the attribute table store specific information about the path. Those additional fields are the following:</para>
		/// <para>PATHID—The unique identifier for the path</para>
		/// <para>PATHCOST—The total accumulative distance or cost for the path</para>
		/// <para>REGION1—The first region the path connects</para>
		/// <para>REGION2—The other region the path connects</para>
		/// <para>This information provides insight into the paths within the network.</para>
		/// <para>Since each path is represented by a unique line, there will be multiple lines in locations where paths travel the same route.</para>
		/// </param>
		public OptimalRegionConnections(object Inputregionrasterorfeatures, object Outputoptimallinesname)
		{
			this.Inputregionrasterorfeatures = Inputregionrasterorfeatures;
			this.Outputoptimallinesname = Outputoptimallinesname;
		}

		/// <summary>
		/// <para>Tool Display Name : Optimal Region Connections</para>
		/// </summary>
		public override string DisplayName() => "Optimal Region Connections";

		/// <summary>
		/// <para>Tool Name : OptimalRegionConnections</para>
		/// </summary>
		public override string ToolName() => "OptimalRegionConnections";

		/// <summary>
		/// <para>Tool Excute Name : ra.OptimalRegionConnections</para>
		/// </summary>
		public override string ExcuteName() => "ra.OptimalRegionConnections";

		/// <summary>
		/// <para>Toolbox Display Name : Raster Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Raster Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : ra</para>
		/// </summary>
		public override string ToolboxAlise() => "ra";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "mask", "outputCoordinateSystem", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputregionrasterorfeatures, Outputoptimallinesname, Inputbarrierrasterorfeatures, Inputcostraster, Outputneighborconnectionsname, Distancemethod, Connectionswithinregions, Outputoptimallinesfeatures, Outputneighborconnectionfeatures };

		/// <summary>
		/// <para>Input Region Raster or Features</para>
		/// <para>The input regions to be connected by the optimal network.</para>
		/// <para>Regions can be defined by either raster or feature data.</para>
		/// <para>If the region input is raster, the regions are defined by groups of contiguous (adjacent) cells of the same value. Each region must be uniquely numbered. The cells that are not part of any region must be NoData. The raster type must be integer, and the values can be either positive or negative.</para>
		/// <para>If the region input is feature data, it can be polygons, lines, or points. Polygon feature regions cannot be composed of multipart polygons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputregionrasterorfeatures { get; set; }

		/// <summary>
		/// <para>Output Optimal Connectivity Lines Name</para>
		/// <para>The name of the output line feature service that connects each input region.</para>
		/// <para>Each path (or line) is uniquely numbered and additional fields in the attribute table store specific information about the path. Those additional fields are the following:</para>
		/// <para>PATHID—The unique identifier for the path</para>
		/// <para>PATHCOST—The total accumulative distance or cost for the path</para>
		/// <para>REGION1—The first region the path connects</para>
		/// <para>REGION2—The other region the path connects</para>
		/// <para>This information provides insight into the paths within the network.</para>
		/// <para>Since each path is represented by a unique line, there will be multiple lines in locations where paths travel the same route.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputoptimallinesname { get; set; }

		/// <summary>
		/// <para>Input Barrier Raster or Features</para>
		/// <para>The dataset that defines the barriers.</para>
		/// <para>The barriers can be defined by an integer or a floating-point image service, or by a feature service.</para>
		/// <para>For an image service barrier, the barrier must have a valid value, including zero, and the areas that are not barriers must be NoData.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputbarrierrasterorfeatures { get; set; }

		/// <summary>
		/// <para>Input Cost Raster</para>
		/// <para>An image service defining the impedance or cost to move planimetrically through each cell.</para>
		/// <para>The value at each cell location represents the cost-per-unit distance for moving through the cell. Each cell location value is multiplied by the cell resolution while also compensating for diagonal movement to obtain the total cost of passing through the cell.</para>
		/// <para>The values of the cost raster can be integer or floating point, but they cannot be negative or zero (you cannot have a negative or zero cost).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputcostraster { get; set; }

		/// <summary>
		/// <para>Output Neighboring Connections Name</para>
		/// <para>The output polyline feature class identifying all paths from each region to each of its closest or cost neighbors.</para>
		/// <para>Each path (or line) is uniquely numbered and additional fields in the attribute table store specific information about the path. Those additional fields are the following:</para>
		/// <para>PATHID—The unique identifier for the path</para>
		/// <para>PATHCOST—The total accumulative distance or cost for the path</para>
		/// <para>REGION1—The first region the path connects</para>
		/// <para>REGION2—The other region the path connects</para>
		/// <para>This information provides insight into the paths within the network and is useful when deciding which paths should be removed if necessary.</para>
		/// <para>Since each path is represented by a unique line, there will be multiple lines in locations where paths travel the same route.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Outputneighborconnectionsname { get; set; }

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>Specifies whether to calculate the distance using a planar (flat earth) or a geodesic (ellipsoid) method.</para>
		/// <para>Planar—The distance calculation will be performed on a projected flat plane using a 2D Cartesian coordinate system. This is the default.</para>
		/// <para>Geodesic—The distance calculation will be performed on the ellipsoid. Therefore, regardless of input or output projection, the results do not change.</para>
		/// <para><see cref="DistancemethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Distancemethod { get; set; } = "PLANAR";

		/// <summary>
		/// <para>Connections Within Regions</para>
		/// <para>Specifies whether the paths will continue and connect within the input regions.</para>
		/// <para>Generate connections—Paths will continue within the input regions to connect all paths that enter a region.</para>
		/// <para>No connections—Paths will stop at the edges of the input regions and will not continue or connect within them.</para>
		/// <para><see cref="ConnectionswithinregionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Connectionswithinregions { get; set; } = "GENERATE_CONNECTIONS";

		/// <summary>
		/// <para>Output optimal connectivity lines</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object Outputoptimallinesfeatures { get; set; }

		/// <summary>
		/// <para>Output Neighboring Connections</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object Outputneighborconnectionfeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public OptimalRegionConnections SetEnviroment(object cellSize = null, object extent = null, object mask = null, object outputCoordinateSystem = null, object snapRaster = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Method</para>
		/// </summary>
		public enum DistancemethodEnum 
		{
			/// <summary>
			/// <para>Planar—The distance calculation will be performed on a projected flat plane using a 2D Cartesian coordinate system. This is the default.</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("Planar")]
			Planar,

			/// <summary>
			/// <para>Geodesic—The distance calculation will be performed on the ellipsoid. Therefore, regardless of input or output projection, the results do not change.</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("Geodesic")]
			Geodesic,

		}

		/// <summary>
		/// <para>Connections Within Regions</para>
		/// </summary>
		public enum ConnectionswithinregionsEnum 
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
