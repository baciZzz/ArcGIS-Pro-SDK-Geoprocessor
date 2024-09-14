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
	/// <para>Optimal Path As Raster</para>
	/// <para>Optimal Path As Raster</para>
	/// <para>Calculates the optimal path from a source to a destination as a raster.</para>
	/// </summary>
	public class OptimalPathAsRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputdestinationrasterorfeatures">
		/// <para>Input raster or feature destination data</para>
		/// <para>A raster or feature dataset that identifies locations from which the least accumulative cost path is determined to the least costly source.</para>
		/// <para>For a raster, the input type must be integer, and it must consist of cells that have valid values (zero is a valid value). The remaining cells must be assigned NoData.</para>
		/// </param>
		/// <param name="Inputdistanceaccumulationraster">
		/// <para>Input distance accumulation raster</para>
		/// <para>The distance accumulation raster is used to determine the optimal path from the sources to the destinations.</para>
		/// <para>The distance accumulation raster is usually created with the Distance Accumulation or Distance Allocation tools. Each cell in the distance accumulation raster represents the minimum accumulative cost distance over a surface from each cell to a set of source cells.</para>
		/// </param>
		/// <param name="Inputbackdirectionraster">
		/// <para>Input back direction or flow direction raster</para>
		/// <para>The back direction raster contains calculated directions in degrees. The direction identifies the next cell along the optimal path back to the least accumulative cost source while avoiding barriers.</para>
		/// <para>The range of values is from 0 degrees to 360 degrees. The value 0 is reserved for the source cells. Due east (right) is 90 degrees, and the values increase clockwise (180 is south, 270 is west, and 360 is north).</para>
		/// </param>
		/// <param name="Outputrastername">
		/// <para>Output Raster Name</para>
		/// <para>The name of output raster service that contains the optimal paths.</para>
		/// </param>
		public OptimalPathAsRaster(object Inputdestinationrasterorfeatures, object Inputdistanceaccumulationraster, object Inputbackdirectionraster, object Outputrastername)
		{
			this.Inputdestinationrasterorfeatures = Inputdestinationrasterorfeatures;
			this.Inputdistanceaccumulationraster = Inputdistanceaccumulationraster;
			this.Inputbackdirectionraster = Inputbackdirectionraster;
			this.Outputrastername = Outputrastername;
		}

		/// <summary>
		/// <para>Tool Display Name : Optimal Path As Raster</para>
		/// </summary>
		public override string DisplayName() => "Optimal Path As Raster";

		/// <summary>
		/// <para>Tool Name : OptimalPathAsRaster</para>
		/// </summary>
		public override string ToolName() => "OptimalPathAsRaster";

		/// <summary>
		/// <para>Tool Excute Name : ra.OptimalPathAsRaster</para>
		/// </summary>
		public override string ExcuteName() => "ra.OptimalPathAsRaster";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputdestinationrasterorfeatures, Inputdistanceaccumulationraster, Inputbackdirectionraster, Outputrastername, Destinationfield, Pathtype, Outputraster };

		/// <summary>
		/// <para>Input raster or feature destination data</para>
		/// <para>A raster or feature dataset that identifies locations from which the least accumulative cost path is determined to the least costly source.</para>
		/// <para>For a raster, the input type must be integer, and it must consist of cells that have valid values (zero is a valid value). The remaining cells must be assigned NoData.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputdestinationrasterorfeatures { get; set; }

		/// <summary>
		/// <para>Input distance accumulation raster</para>
		/// <para>The distance accumulation raster is used to determine the optimal path from the sources to the destinations.</para>
		/// <para>The distance accumulation raster is usually created with the Distance Accumulation or Distance Allocation tools. Each cell in the distance accumulation raster represents the minimum accumulative cost distance over a surface from each cell to a set of source cells.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputdistanceaccumulationraster { get; set; }

		/// <summary>
		/// <para>Input back direction or flow direction raster</para>
		/// <para>The back direction raster contains calculated directions in degrees. The direction identifies the next cell along the optimal path back to the least accumulative cost source while avoiding barriers.</para>
		/// <para>The range of values is from 0 degrees to 360 degrees. The value 0 is reserved for the source cells. Due east (right) is 90 degrees, and the values increase clockwise (180 is south, 270 is west, and 360 is north).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputbackdirectionraster { get; set; }

		/// <summary>
		/// <para>Output Raster Name</para>
		/// <para>The name of output raster service that contains the optimal paths.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputrastername { get; set; }

		/// <summary>
		/// <para>Destination field</para>
		/// <para>The field that is used to obtain values for the destination locations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Destinationfield { get; set; }

		/// <summary>
		/// <para>Path type</para>
		/// <para>Specifies a keyword defining the manner in which the values and zones in the input destination data will be interpreted in the cost path calculations.</para>
		/// <para>Each zone—For each zone in the input destination data, a least-cost path is determined and saved on the output raster. With this option, the least-cost path for each zone begins at the cell with the lowest cost distance weighting in the zone. This is the default.</para>
		/// <para>Best single—For all cells in the input destination data, the least-cost path is derived from the cell with the minimum of the least-cost paths to source cells.</para>
		/// <para>Each cell—For each cell with valid values in the input destination data, a least-cost path is determined and saved on the output raster. With this option, each cell of the input destination data is treated separately, and a least-cost path is determined for each cell.</para>
		/// <para><see cref="PathtypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Pathtype { get; set; } = "EACH_ZONE";

		/// <summary>
		/// <para>Output Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outputraster { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Path type</para>
		/// </summary>
		public enum PathtypeEnum 
		{
			/// <summary>
			/// <para>Best single—For all cells in the input destination data, the least-cost path is derived from the cell with the minimum of the least-cost paths to source cells.</para>
			/// </summary>
			[GPValue("BEST_SINGLE")]
			[Description("Best single")]
			Best_single,

			/// <summary>
			/// <para>Each cell—For each cell with valid values in the input destination data, a least-cost path is determined and saved on the output raster. With this option, each cell of the input destination data is treated separately, and a least-cost path is determined for each cell.</para>
			/// </summary>
			[GPValue("EACH_CELL")]
			[Description("Each cell")]
			Each_cell,

			/// <summary>
			/// <para>Each zone—For each zone in the input destination data, a least-cost path is determined and saved on the output raster. With this option, the least-cost path for each zone begins at the cell with the lowest cost distance weighting in the zone. This is the default.</para>
			/// </summary>
			[GPValue("EACH_ZONE")]
			[Description("Each zone")]
			Each_zone,

		}

#endregion
	}
}
