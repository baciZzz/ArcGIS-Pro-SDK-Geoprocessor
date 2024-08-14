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
	/// <para>Determine Travel Cost Path As Polyline</para>
	/// <para>Calculates the least-cost polyline path between sources and destinations.</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.RasterAnalysisTools.OptimalPathAsLine"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.RasterAnalysisTools.OptimalPathAsLine))]
	public class DetermineTravelCostPathAsPolyline : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputsourcerasterorfeatures">
		/// <para>Input Source Raster or Features</para>
		/// <para>An image service or feature service that identifies the cells from which the least-cost path is determined to the destinations.</para>
		/// <para>If the input is an image service, the input consists of cells that have valid values (zero is a valid value), and the remaining cells must be assigned NoData.</para>
		/// </param>
		/// <param name="Inputcostraster">
		/// <para>Input Cost Raster</para>
		/// <para>The name of a cost raster image service to be used to determine the least-cost path from the sources to the destinations.</para>
		/// <para>The value at each cell location represents the cost-per-unit distance for moving through the cell. Each cell location value is multiplied by the cell resolution while also compensating for diagonal movement to obtain the total cost of passing through the cell.</para>
		/// <para>The values of the cost raster can be integer or floating point, but they cannot be negative or zero (you cannot have a negative or zero cost).</para>
		/// </param>
		/// <param name="Inputdestinationrasterorfeatures">
		/// <para>Input Destination Raster or Features</para>
		/// <para>An image service or feature service that identifies the cells to which the least-cost path is calculated.</para>
		/// </param>
		/// <param name="Outputpolylinename">
		/// <para>Output Polyline Name</para>
		/// <para>The name of the output polyline feature service.</para>
		/// <para>The polyline feature service of the optimum (least-cost) paths connecting sources and destinations.</para>
		/// <para>Each path (or line) is uniquely numbered, and has an additional field in the attribute table called DestID, which connects it back to the unique identifier on the destination raster.</para>
		/// <para>Since each path is represented by a unique line, there can be multiple lines in locations where paths travel the same route.</para>
		/// </param>
		public DetermineTravelCostPathAsPolyline(object Inputsourcerasterorfeatures, object Inputcostraster, object Inputdestinationrasterorfeatures, object Outputpolylinename)
		{
			this.Inputsourcerasterorfeatures = Inputsourcerasterorfeatures;
			this.Inputcostraster = Inputcostraster;
			this.Inputdestinationrasterorfeatures = Inputdestinationrasterorfeatures;
			this.Outputpolylinename = Outputpolylinename;
		}

		/// <summary>
		/// <para>Tool Display Name : Determine Travel Cost Path As Polyline</para>
		/// </summary>
		public override string DisplayName => "Determine Travel Cost Path As Polyline";

		/// <summary>
		/// <para>Tool Name : DetermineTravelCostPathAsPolyline</para>
		/// </summary>
		public override string ToolName => "DetermineTravelCostPathAsPolyline";

		/// <summary>
		/// <para>Tool Excute Name : ra.DetermineTravelCostPathAsPolyline</para>
		/// </summary>
		public override string ExcuteName => "ra.DetermineTravelCostPathAsPolyline";

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
		public override object[] Parameters => new object[] { Inputsourcerasterorfeatures, Inputcostraster, Inputdestinationrasterorfeatures, Outputpolylinename, Pathtype!, Outputpolylinefeatures!, Destinationfield! };

		/// <summary>
		/// <para>Input Source Raster or Features</para>
		/// <para>An image service or feature service that identifies the cells from which the least-cost path is determined to the destinations.</para>
		/// <para>If the input is an image service, the input consists of cells that have valid values (zero is a valid value), and the remaining cells must be assigned NoData.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputsourcerasterorfeatures { get; set; }

		/// <summary>
		/// <para>Input Cost Raster</para>
		/// <para>The name of a cost raster image service to be used to determine the least-cost path from the sources to the destinations.</para>
		/// <para>The value at each cell location represents the cost-per-unit distance for moving through the cell. Each cell location value is multiplied by the cell resolution while also compensating for diagonal movement to obtain the total cost of passing through the cell.</para>
		/// <para>The values of the cost raster can be integer or floating point, but they cannot be negative or zero (you cannot have a negative or zero cost).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputcostraster { get; set; }

		/// <summary>
		/// <para>Input Destination Raster or Features</para>
		/// <para>An image service or feature service that identifies the cells to which the least-cost path is calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputdestinationrasterorfeatures { get; set; }

		/// <summary>
		/// <para>Output Polyline Name</para>
		/// <para>The name of the output polyline feature service.</para>
		/// <para>The polyline feature service of the optimum (least-cost) paths connecting sources and destinations.</para>
		/// <para>Each path (or line) is uniquely numbered, and has an additional field in the attribute table called DestID, which connects it back to the unique identifier on the destination raster.</para>
		/// <para>Since each path is represented by a unique line, there can be multiple lines in locations where paths travel the same route.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputpolylinename { get; set; }

		/// <summary>
		/// <para>Path Type</para>
		/// <para>Specifies the manner in which the values and zones on the input destination data will be interpreted in the cost path calculations.</para>
		/// <para>To each cell—For each cell or location with valid values on the input destination data, a least-cost path is determined and saved on the output. With this option, each cell or location of the input destination data is treated separately, and a least-cost path is determined for each from cell.</para>
		/// <para>To each zone—For each zone on the input destination data, a least-cost path is determined and saved to the output. With this option, the least-cost path for each zone begins at the location with the lowest cost distance weighting in the zone.</para>
		/// <para>Best single—For all locations on the input destination data, the least-cost path is derived from the location with the minimum of the least-cost paths to source locations. This is the default.</para>
		/// <para><see cref="PathtypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Pathtype { get; set; } = "BEST_SINGLE";

		/// <summary>
		/// <para>Output Polyline Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? Outputpolylinefeatures { get; set; }

		/// <summary>
		/// <para>Destination Field</para>
		/// <para>The field used to obtain values for the destination locations.</para>
		/// <para>Input feature data must contain at least one valid integer field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Destinationfield { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DetermineTravelCostPathAsPolyline SetEnviroment(object? cellSize = null , object? extent = null , object? mask = null , object? outputCoordinateSystem = null , object? snapRaster = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Path Type</para>
		/// </summary>
		public enum PathtypeEnum 
		{
			/// <summary>
			/// <para>To each cell—For each cell or location with valid values on the input destination data, a least-cost path is determined and saved on the output. With this option, each cell or location of the input destination data is treated separately, and a least-cost path is determined for each from cell.</para>
			/// </summary>
			[GPValue("EACH_CELL")]
			[Description("To each cell")]
			To_each_cell,

			/// <summary>
			/// <para>To each zone—For each zone on the input destination data, a least-cost path is determined and saved to the output. With this option, the least-cost path for each zone begins at the location with the lowest cost distance weighting in the zone.</para>
			/// </summary>
			[GPValue("EACH_ZONE")]
			[Description("To each zone")]
			To_each_zone,

			/// <summary>
			/// <para>Best single—For all locations on the input destination data, the least-cost path is derived from the location with the minimum of the least-cost paths to source locations. This is the default.</para>
			/// </summary>
			[GPValue("BEST_SINGLE")]
			[Description("Best single")]
			Best_single,

		}

#endregion
	}
}
