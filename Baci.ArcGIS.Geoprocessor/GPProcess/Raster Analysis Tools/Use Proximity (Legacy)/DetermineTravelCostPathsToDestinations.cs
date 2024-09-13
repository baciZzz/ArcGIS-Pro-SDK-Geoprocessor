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
	/// <para>Determine Travel Cost Paths To Destinations</para>
	/// <para>Determine Travel Cost Paths To Destinations</para>
	/// <para>Calculates specific paths between known sources and known destinations.</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.RasterAnalysisTools.OptimalPathAsRaster"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.RasterAnalysisTools.OptimalPathAsRaster))]
	public class DetermineTravelCostPathsToDestinations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputdestinationrasterorfeatures">
		/// <para>Input Destination Raster or Features</para>
		/// <para>An image service or feature service that identifies the cells from which the least-cost path is determined to the least costly source.</para>
		/// <para>If the input is an image service, the input consists of cells that have valid values (zero is a valid value), and the remaining cells must be assigned NoData.</para>
		/// </param>
		/// <param name="Inputcostdistanceraster">
		/// <para>Input Cost Distance Raster</para>
		/// <para>The name of a cost distance image service to be used to determine the least-cost path from the destination locations to a source.</para>
		/// <para>The cost distance raster is usually created with the Calculate Travel Cost tool. The cost distance raster stores, for each cell, the minimum accumulative cost distance over a cost surface from each cell to a set of source cells.</para>
		/// </param>
		/// <param name="Inputcostbacklinkraster">
		/// <para>Input Cost Backlink Raster</para>
		/// <para>The name of a cost back link raster used to determine the path to return to a source via the least-cost path.</para>
		/// <para>For each cell in the back link raster, a value identifies the neighbor that is the next cell on the least accumulative cost path from the cell to a single source cell or set of source cells.</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>The name of the output travel cost paths raster service.</para>
		/// <para>The default name is based on the tool name and the input layer name. If the layer name already exists, you will be prompted to provide another name.</para>
		/// </param>
		public DetermineTravelCostPathsToDestinations(object Inputdestinationrasterorfeatures, object Inputcostdistanceraster, object Inputcostbacklinkraster, object Outputname)
		{
			this.Inputdestinationrasterorfeatures = Inputdestinationrasterorfeatures;
			this.Inputcostdistanceraster = Inputcostdistanceraster;
			this.Inputcostbacklinkraster = Inputcostbacklinkraster;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : Determine Travel Cost Paths To Destinations</para>
		/// </summary>
		public override string DisplayName() => "Determine Travel Cost Paths To Destinations";

		/// <summary>
		/// <para>Tool Name : DetermineTravelCostPathsToDestinations</para>
		/// </summary>
		public override string ToolName() => "DetermineTravelCostPathsToDestinations";

		/// <summary>
		/// <para>Tool Excute Name : ra.DetermineTravelCostPathsToDestinations</para>
		/// </summary>
		public override string ExcuteName() => "ra.DetermineTravelCostPathsToDestinations";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "mask", "outputCoordinateSystem", "pyramid", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputdestinationrasterorfeatures, Inputcostdistanceraster, Inputcostbacklinkraster, Outputname, Destinationfield!, Pathtype!, Outputraster! };

		/// <summary>
		/// <para>Input Destination Raster or Features</para>
		/// <para>An image service or feature service that identifies the cells from which the least-cost path is determined to the least costly source.</para>
		/// <para>If the input is an image service, the input consists of cells that have valid values (zero is a valid value), and the remaining cells must be assigned NoData.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputdestinationrasterorfeatures { get; set; }

		/// <summary>
		/// <para>Input Cost Distance Raster</para>
		/// <para>The name of a cost distance image service to be used to determine the least-cost path from the destination locations to a source.</para>
		/// <para>The cost distance raster is usually created with the Calculate Travel Cost tool. The cost distance raster stores, for each cell, the minimum accumulative cost distance over a cost surface from each cell to a set of source cells.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputcostdistanceraster { get; set; }

		/// <summary>
		/// <para>Input Cost Backlink Raster</para>
		/// <para>The name of a cost back link raster used to determine the path to return to a source via the least-cost path.</para>
		/// <para>For each cell in the back link raster, a value identifies the neighbor that is the next cell on the least accumulative cost path from the cell to a single source cell or set of source cells.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputcostbacklinkraster { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output travel cost paths raster service.</para>
		/// <para>The default name is based on the tool name and the input layer name. If the layer name already exists, you will be prompted to provide another name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Destination Field</para>
		/// <para>A field on the destination layer that holds the values that define each destination.</para>
		/// <para>Input feature service must contain at least one valid field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Destinationfield { get; set; }

		/// <summary>
		/// <para>Path Type</para>
		/// <para>Defines the manner in which the values and zones on the input destination data will be interpreted in the cost path calculations.</para>
		/// <para>To each cell—For each cell with valid values on the input destination data, a least-cost path is determined and saved on the output raster. With this option, each cell of the input destination data is treated separately, and a least-cost path is determined for each from cell. This is the default.</para>
		/// <para>To each zone—For each zone on the input destination data, a least-cost path is determined and saved on the output raster. With this option, the least-cost path for each zone begins at the cell with the lowest cost distance weighting in the zone.</para>
		/// <para>Best single—For all cells on the input destination data, the least-cost path is derived from the cell with the minimum of the least-cost paths to source cells.</para>
		/// <para><see cref="PathtypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Pathtype { get; set; } = "EACH_CELL";

		/// <summary>
		/// <para>Output Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object? Outputraster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DetermineTravelCostPathsToDestinations SetEnviroment(object? cellSize = null , object? extent = null , object? mask = null , object? outputCoordinateSystem = null , object? pyramid = null , object? snapRaster = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Path Type</para>
		/// </summary>
		public enum PathtypeEnum 
		{
			/// <summary>
			/// <para>To each cell—For each cell with valid values on the input destination data, a least-cost path is determined and saved on the output raster. With this option, each cell of the input destination data is treated separately, and a least-cost path is determined for each from cell. This is the default.</para>
			/// </summary>
			[GPValue("EACH_CELL")]
			[Description("To each cell")]
			To_each_cell,

			/// <summary>
			/// <para>To each zone—For each zone on the input destination data, a least-cost path is determined and saved on the output raster. With this option, the least-cost path for each zone begins at the cell with the lowest cost distance weighting in the zone.</para>
			/// </summary>
			[GPValue("EACH_ZONE")]
			[Description("To each zone")]
			To_each_zone,

			/// <summary>
			/// <para>Best single—For all cells on the input destination data, the least-cost path is derived from the cell with the minimum of the least-cost paths to source cells.</para>
			/// </summary>
			[GPValue("BEST_SINGLE")]
			[Description("Best single")]
			Best_single,

		}

#endregion
	}
}
