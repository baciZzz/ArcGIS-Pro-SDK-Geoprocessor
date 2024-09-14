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
	/// <para>Cost Path As Polyline</para>
	/// <para>Cost Path As Polyline</para>
	/// <para>Calculates the least-cost path from a source to a destination as a line feature.</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.RasterAnalysisTools.OptimalPathAsLine"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.RasterAnalysisTools.OptimalPathAsLine))]
	public class CostPathAsPolyline : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputdestinationrasterorfeatures">
		/// <para>Input Destination Raster or Features</para>
		/// <para>An image service or feature service that identifies those locations from which the least-cost path is determined to the least costly source.</para>
		/// <para>If the input is an image service, the input consists of cells that have valid values (zero is a valid value), and the remaining cells must be assigned NoData.</para>
		/// </param>
		/// <param name="Inputcostdistanceraster">
		/// <para>Input Cost Distance or Euclidean Distance Raster</para>
		/// <para>The cost distance or Euclidean distance raster to be used to determine the least-cost path from the sources to the destinations.</para>
		/// </param>
		/// <param name="Inputcostbacklinkraster">
		/// <para>Input Cost Backlink, Back Direction or Flow Direction Raster</para>
		/// <para>The name of the raster used to determine the path to return to a source via the least-cost path or the shortest path.</para>
		/// <para>For each cell in the back link or direction raster, a value identifies the neighbor that is the next cell on the path from the cell to a source cell.</para>
		/// </param>
		/// <param name="Outputpolylinename">
		/// <para>Output Polyline Name</para>
		/// <para>The output feature service that will contain the least cost path.</para>
		/// </param>
		public CostPathAsPolyline(object Inputdestinationrasterorfeatures, object Inputcostdistanceraster, object Inputcostbacklinkraster, object Outputpolylinename)
		{
			this.Inputdestinationrasterorfeatures = Inputdestinationrasterorfeatures;
			this.Inputcostdistanceraster = Inputcostdistanceraster;
			this.Inputcostbacklinkraster = Inputcostbacklinkraster;
			this.Outputpolylinename = Outputpolylinename;
		}

		/// <summary>
		/// <para>Tool Display Name : Cost Path As Polyline</para>
		/// </summary>
		public override string DisplayName() => "Cost Path As Polyline";

		/// <summary>
		/// <para>Tool Name : CostPathAsPolyline</para>
		/// </summary>
		public override string ToolName() => "CostPathAsPolyline";

		/// <summary>
		/// <para>Tool Excute Name : ra.CostPathAsPolyline</para>
		/// </summary>
		public override string ExcuteName() => "ra.CostPathAsPolyline";

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
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputdestinationrasterorfeatures, Inputcostdistanceraster, Inputcostbacklinkraster, Outputpolylinename, Pathtype!, Destinationfield!, Outputpolylinefeatures! };

		/// <summary>
		/// <para>Input Destination Raster or Features</para>
		/// <para>An image service or feature service that identifies those locations from which the least-cost path is determined to the least costly source.</para>
		/// <para>If the input is an image service, the input consists of cells that have valid values (zero is a valid value), and the remaining cells must be assigned NoData.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputdestinationrasterorfeatures { get; set; }

		/// <summary>
		/// <para>Input Cost Distance or Euclidean Distance Raster</para>
		/// <para>The cost distance or Euclidean distance raster to be used to determine the least-cost path from the sources to the destinations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputcostdistanceraster { get; set; }

		/// <summary>
		/// <para>Input Cost Backlink, Back Direction or Flow Direction Raster</para>
		/// <para>The name of the raster used to determine the path to return to a source via the least-cost path or the shortest path.</para>
		/// <para>For each cell in the back link or direction raster, a value identifies the neighbor that is the next cell on the path from the cell to a source cell.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputcostbacklinkraster { get; set; }

		/// <summary>
		/// <para>Output Polyline Name</para>
		/// <para>The output feature service that will contain the least cost path.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputpolylinename { get; set; }

		/// <summary>
		/// <para>Path type</para>
		/// <para>Specifies the manner in which the values and zones on the input destination data will be interpreted in the cost path calculations.</para>
		/// <para>Best single—For all cells on the input destination data, the least-cost path will be derived from the cell with the minimum of the least-cost paths to source cells.</para>
		/// <para>Each zone—For each zone on the input destination data, a least-cost path is determined and saved on the output raster. With this option, the least-cost path for each zone will begin at the cell with the lowest cost distance weighting in the zone.</para>
		/// <para>Each cell—For each cell with valid values on the input destination data, a least-cost path is determined and saved on the output raster. With this option, each cell of the input destination data will be treated separately, and a least-cost path will be determined for each from cell.</para>
		/// <para><see cref="PathtypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Pathtype { get; set; } = "BEST_SINGLE";

		/// <summary>
		/// <para>Destination Field</para>
		/// <para>The field that will be used to obtain values for the destination locations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Destinationfield { get; set; }

		/// <summary>
		/// <para>Output Polyline Feature</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? Outputpolylinefeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CostPathAsPolyline SetEnviroment(object? outputCoordinateSystem = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Path type</para>
		/// </summary>
		public enum PathtypeEnum 
		{
			/// <summary>
			/// <para>Each cell—For each cell with valid values on the input destination data, a least-cost path is determined and saved on the output raster. With this option, each cell of the input destination data will be treated separately, and a least-cost path will be determined for each from cell.</para>
			/// </summary>
			[GPValue("EACH_CELL")]
			[Description("Each cell")]
			Each_cell,

			/// <summary>
			/// <para>Each zone—For each zone on the input destination data, a least-cost path is determined and saved on the output raster. With this option, the least-cost path for each zone will begin at the cell with the lowest cost distance weighting in the zone.</para>
			/// </summary>
			[GPValue("EACH_ZONE")]
			[Description("Each zone")]
			Each_zone,

			/// <summary>
			/// <para>Best single—For all cells on the input destination data, the least-cost path will be derived from the cell with the minimum of the least-cost paths to source cells.</para>
			/// </summary>
			[GPValue("BEST_SINGLE")]
			[Description("Best single")]
			Best_single,

		}

#endregion
	}
}
