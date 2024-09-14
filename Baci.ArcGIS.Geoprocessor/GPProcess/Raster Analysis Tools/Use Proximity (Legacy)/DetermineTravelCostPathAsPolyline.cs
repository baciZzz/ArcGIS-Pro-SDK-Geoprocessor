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
	/// <para>确定行程成本路径为折线</para>
	/// <para>计算源和目的地之间的最低成本折线路径。</para>
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
		/// <para>用于识别像元的影像服务或要素服务（将确定的最小成本路径为这些像元与目的地之间的路径）。</para>
		/// <para>如果输入是影像服务，则输入由具有有效值（零是有效值）的像元组成，并且必须为其余的像元指定 NoData。</para>
		/// </param>
		/// <param name="Inputcostraster">
		/// <para>Input Cost Raster</para>
		/// <para>要用于确定从源到目的地的最小成本路径的成本栅格影像服务的名称。</para>
		/// <para>每个像元位置上的值表示经过像元时移动每单位距离所需的成本。每个像元位置值乘以像元分辨率，同时也会补偿对角线移动来获取经过像元的总成本。</para>
		/// <para>成本栅格的值可以是整型或浮点型，但不可以为负值或零（不存在负成本或零成本）。</para>
		/// </param>
		/// <param name="Inputdestinationrasterorfeatures">
		/// <para>Input Destination Raster or Features</para>
		/// <para>用于识别这些像元的影像服务或要素服务，可计算到这些像元的最小成本路径。</para>
		/// </param>
		/// <param name="Outputpolylinename">
		/// <para>Output Polyline Name</para>
		/// <para>输出折线要素服务的名称。</para>
		/// <para>连接源和目的地的最佳（最小成本）路径的折线要素服务。</para>
		/// <para>每个路径（或线）都具有唯一编号，并在属性表中包含名为 DestID 的附加字段，该字段可将路径与目标栅格上的唯一标识符相连。</para>
		/// <para>由于每条路径都是由唯一的线所表示，因此多条路径可经过同一路线的位置会存在多条线。</para>
		/// </param>
		public DetermineTravelCostPathAsPolyline(object Inputsourcerasterorfeatures, object Inputcostraster, object Inputdestinationrasterorfeatures, object Outputpolylinename)
		{
			this.Inputsourcerasterorfeatures = Inputsourcerasterorfeatures;
			this.Inputcostraster = Inputcostraster;
			this.Inputdestinationrasterorfeatures = Inputdestinationrasterorfeatures;
			this.Outputpolylinename = Outputpolylinename;
		}

		/// <summary>
		/// <para>Tool Display Name : 确定行程成本路径为折线</para>
		/// </summary>
		public override string DisplayName() => "确定行程成本路径为折线";

		/// <summary>
		/// <para>Tool Name : DetermineTravelCostPathAsPolyline</para>
		/// </summary>
		public override string ToolName() => "DetermineTravelCostPathAsPolyline";

		/// <summary>
		/// <para>Tool Excute Name : ra.DetermineTravelCostPathAsPolyline</para>
		/// </summary>
		public override string ExcuteName() => "ra.DetermineTravelCostPathAsPolyline";

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
		public override object[] Parameters() => new object[] { Inputsourcerasterorfeatures, Inputcostraster, Inputdestinationrasterorfeatures, Outputpolylinename, Pathtype, Outputpolylinefeatures, Destinationfield };

		/// <summary>
		/// <para>Input Source Raster or Features</para>
		/// <para>用于识别像元的影像服务或要素服务（将确定的最小成本路径为这些像元与目的地之间的路径）。</para>
		/// <para>如果输入是影像服务，则输入由具有有效值（零是有效值）的像元组成，并且必须为其余的像元指定 NoData。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputsourcerasterorfeatures { get; set; }

		/// <summary>
		/// <para>Input Cost Raster</para>
		/// <para>要用于确定从源到目的地的最小成本路径的成本栅格影像服务的名称。</para>
		/// <para>每个像元位置上的值表示经过像元时移动每单位距离所需的成本。每个像元位置值乘以像元分辨率，同时也会补偿对角线移动来获取经过像元的总成本。</para>
		/// <para>成本栅格的值可以是整型或浮点型，但不可以为负值或零（不存在负成本或零成本）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputcostraster { get; set; }

		/// <summary>
		/// <para>Input Destination Raster or Features</para>
		/// <para>用于识别这些像元的影像服务或要素服务，可计算到这些像元的最小成本路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputdestinationrasterorfeatures { get; set; }

		/// <summary>
		/// <para>Output Polyline Name</para>
		/// <para>输出折线要素服务的名称。</para>
		/// <para>连接源和目的地的最佳（最小成本）路径的折线要素服务。</para>
		/// <para>每个路径（或线）都具有唯一编号，并在属性表中包含名为 DestID 的附加字段，该字段可将路径与目标栅格上的唯一标识符相连。</para>
		/// <para>由于每条路径都是由唯一的线所表示，因此多条路径可经过同一路线的位置会存在多条线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputpolylinename { get; set; }

		/// <summary>
		/// <para>Path Type</para>
		/// <para>用于指定输入目标数据上的值和区域在成本路径计算中的解释方式。</para>
		/// <para>至每个像元—对于输入目标数据上每一个具有有效值的像元或位置，系统会确定最小成本路径并将该路径保存在输出栅格上。利用该选项，系统会分别处理输入目标数据中的每个像元或位置，并确定每个“起始”像元的最小成本路径。</para>
		/// <para>至每个区域—对于输入目标数据上的每个区域，系统会确定最小成本路径并将该路径保存在输出栅格上。利用该选项，每个区域的最小成本路径可起始于区域内成本距离权重最小的位置。</para>
		/// <para>最佳单一—对于输入目标数据上的所有位置，最小成本路径派生自距源位置具有最小成本路径的最小值的位置。这是默认设置。</para>
		/// <para><see cref="PathtypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Pathtype { get; set; } = "BEST_SINGLE";

		/// <summary>
		/// <para>Output Polyline Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object Outputpolylinefeatures { get; set; }

		/// <summary>
		/// <para>Destination Field</para>
		/// <para>用于获得目标位置的值的字段。</para>
		/// <para>输入要素数据必须至少包含一个有效整型字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Destinationfield { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DetermineTravelCostPathAsPolyline SetEnviroment(object cellSize = null, object extent = null, object mask = null, object outputCoordinateSystem = null, object snapRaster = null)
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
			/// <para>至每个像元—对于输入目标数据上每一个具有有效值的像元或位置，系统会确定最小成本路径并将该路径保存在输出栅格上。利用该选项，系统会分别处理输入目标数据中的每个像元或位置，并确定每个“起始”像元的最小成本路径。</para>
			/// </summary>
			[GPValue("EACH_CELL")]
			[Description("至每个像元")]
			To_each_cell,

			/// <summary>
			/// <para>至每个区域—对于输入目标数据上的每个区域，系统会确定最小成本路径并将该路径保存在输出栅格上。利用该选项，每个区域的最小成本路径可起始于区域内成本距离权重最小的位置。</para>
			/// </summary>
			[GPValue("EACH_ZONE")]
			[Description("至每个区域")]
			To_each_zone,

			/// <summary>
			/// <para>最佳单一—对于输入目标数据上的所有位置，最小成本路径派生自距源位置具有最小成本路径的最小值的位置。这是默认设置。</para>
			/// </summary>
			[GPValue("BEST_SINGLE")]
			[Description("最佳单一")]
			Best_single,

		}

#endregion
	}
}
