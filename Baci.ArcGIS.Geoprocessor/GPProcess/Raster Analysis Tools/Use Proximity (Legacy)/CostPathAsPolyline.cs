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
	/// <para>成本路径折线</para>
	/// <para>将从源到目标的的最小成本路径计算为线要素。</para>
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
		/// <para>用于识别这些位置的图像服务或要素服务（将确定的最小成本路径为这些位置与最低成本源之间的路径）。</para>
		/// <para>如果输入是影像服务，则输入由具有有效值（零是有效值）的像元组成，并且必须为其余的像元指定 NoData。</para>
		/// </param>
		/// <param name="Inputcostdistanceraster">
		/// <para>Input Cost Distance or Euclidean Distance Raster</para>
		/// <para>要用于确定从源到目的地的最小成本路径的成本距离或欧式距离栅格。</para>
		/// </param>
		/// <param name="Inputcostbacklinkraster">
		/// <para>Input Cost Backlink, Back Direction or Flow Direction Raster</para>
		/// <para>用于确定要经由最小成本路径或最短路径返回到源的路径的栅格名称。</para>
		/// <para>对于回溯链接或方向栅格中的每个像元，该值用于识别在从该像元到源像元的路径上作为下一像元的邻近像元。</para>
		/// </param>
		/// <param name="Outputpolylinename">
		/// <para>Output Polyline Name</para>
		/// <para>将包含最小成本路径的输出要素服务。</para>
		/// </param>
		public CostPathAsPolyline(object Inputdestinationrasterorfeatures, object Inputcostdistanceraster, object Inputcostbacklinkraster, object Outputpolylinename)
		{
			this.Inputdestinationrasterorfeatures = Inputdestinationrasterorfeatures;
			this.Inputcostdistanceraster = Inputcostdistanceraster;
			this.Inputcostbacklinkraster = Inputcostbacklinkraster;
			this.Outputpolylinename = Outputpolylinename;
		}

		/// <summary>
		/// <para>Tool Display Name : 成本路径折线</para>
		/// </summary>
		public override string DisplayName() => "成本路径折线";

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
		public override object[] Parameters() => new object[] { Inputdestinationrasterorfeatures, Inputcostdistanceraster, Inputcostbacklinkraster, Outputpolylinename, Pathtype, Destinationfield, Outputpolylinefeatures };

		/// <summary>
		/// <para>Input Destination Raster or Features</para>
		/// <para>用于识别这些位置的图像服务或要素服务（将确定的最小成本路径为这些位置与最低成本源之间的路径）。</para>
		/// <para>如果输入是影像服务，则输入由具有有效值（零是有效值）的像元组成，并且必须为其余的像元指定 NoData。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputdestinationrasterorfeatures { get; set; }

		/// <summary>
		/// <para>Input Cost Distance or Euclidean Distance Raster</para>
		/// <para>要用于确定从源到目的地的最小成本路径的成本距离或欧式距离栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputcostdistanceraster { get; set; }

		/// <summary>
		/// <para>Input Cost Backlink, Back Direction or Flow Direction Raster</para>
		/// <para>用于确定要经由最小成本路径或最短路径返回到源的路径的栅格名称。</para>
		/// <para>对于回溯链接或方向栅格中的每个像元，该值用于识别在从该像元到源像元的路径上作为下一像元的邻近像元。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputcostbacklinkraster { get; set; }

		/// <summary>
		/// <para>Output Polyline Name</para>
		/// <para>将包含最小成本路径的输出要素服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputpolylinename { get; set; }

		/// <summary>
		/// <para>Path type</para>
		/// <para>用于指定输入目标数据上的值和区域在成本路径计算中的解释方式。</para>
		/// <para>最佳单一—对于输入目标数据上的所有像元，最小成本路径派生自距源像元具有最小成本路径的最小值的像元。</para>
		/// <para>每个区域—对于输入目标数据上的每个区域，系统会确定最小成本路径并将该路径保存在输出栅格上。利用该选项，每个区域的最小成本路径将起始于区域内成本距离权重最小的像元。</para>
		/// <para>每个像元—对于输入目标数据上每一个具有有效值的像元，系统会确定最小成本路径并将该路径保存在输出栅格上。利用该选项，系统会单独处理输入目标数据的每个像元，并确定每个“起始”像元的最小成本路径。</para>
		/// <para><see cref="PathtypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Pathtype { get; set; } = "BEST_SINGLE";

		/// <summary>
		/// <para>Destination Field</para>
		/// <para>要用于获得目标位置的值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Destinationfield { get; set; }

		/// <summary>
		/// <para>Output Polyline Feature</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object Outputpolylinefeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CostPathAsPolyline SetEnviroment(object outputCoordinateSystem = null)
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
			/// <para>每个像元—对于输入目标数据上每一个具有有效值的像元，系统会确定最小成本路径并将该路径保存在输出栅格上。利用该选项，系统会单独处理输入目标数据的每个像元，并确定每个“起始”像元的最小成本路径。</para>
			/// </summary>
			[GPValue("EACH_CELL")]
			[Description("每个像元")]
			Each_cell,

			/// <summary>
			/// <para>每个区域—对于输入目标数据上的每个区域，系统会确定最小成本路径并将该路径保存在输出栅格上。利用该选项，每个区域的最小成本路径将起始于区域内成本距离权重最小的像元。</para>
			/// </summary>
			[GPValue("EACH_ZONE")]
			[Description("每个区域")]
			Each_zone,

			/// <summary>
			/// <para>最佳单一—对于输入目标数据上的所有像元，最小成本路径派生自距源像元具有最小成本路径的最小值的像元。</para>
			/// </summary>
			[GPValue("BEST_SINGLE")]
			[Description("最佳单一")]
			Best_single,

		}

#endregion
	}
}
