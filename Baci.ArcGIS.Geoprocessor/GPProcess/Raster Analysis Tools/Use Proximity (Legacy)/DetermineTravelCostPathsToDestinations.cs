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
	/// <para>确定到目的地的行程成本路径</para>
	/// <para>计算已知源和已知目的地之间的特定路径。</para>
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
		/// <para>用于识别这些像元的影像服务或要素服务（将确定的最小成本路径为这些像元与成本最低的源之间的路径）。</para>
		/// <para>如果输入是影像服务，则输入由具有有效值（零是有效值）的像元组成，并且必须为其余的像元指定 NoData。</para>
		/// </param>
		/// <param name="Inputcostdistanceraster">
		/// <para>Input Cost Distance Raster</para>
		/// <para>要用于确定从目标位置到源的最小成本路径的成本距离影像服务的名称。</para>
		/// <para>通常使用计算行程成本工具创建成本距离栅格。对于每个像元，成本距离栅格存储从每个像元到一组源像元的成本面上的最小累积成本距离。</para>
		/// </param>
		/// <param name="Inputcostbacklinkraster">
		/// <para>Input Cost Backlink Raster</para>
		/// <para>用于确定要经由最小成本路径返回到源的路径的成本回溯链接栅格名称。</para>
		/// <para>对于成本回溯链接栅格内的每个像元，值可识别在从像元到单个源像元或一组源像元的最小累积成本路径上作为下一像元的邻近像元。</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>输出行程成本路径栅格服务的名称。</para>
		/// <para>默认名称基于工具名称以及输入图层名称。如果该图层名称已存在，则系统将提示您提供其他名称。</para>
		/// </param>
		public DetermineTravelCostPathsToDestinations(object Inputdestinationrasterorfeatures, object Inputcostdistanceraster, object Inputcostbacklinkraster, object Outputname)
		{
			this.Inputdestinationrasterorfeatures = Inputdestinationrasterorfeatures;
			this.Inputcostdistanceraster = Inputcostdistanceraster;
			this.Inputcostbacklinkraster = Inputcostbacklinkraster;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : 确定到目的地的行程成本路径</para>
		/// </summary>
		public override string DisplayName() => "确定到目的地的行程成本路径";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "mask", "outputCoordinateSystem", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputdestinationrasterorfeatures, Inputcostdistanceraster, Inputcostbacklinkraster, Outputname, Destinationfield, Pathtype, Outputraster };

		/// <summary>
		/// <para>Input Destination Raster or Features</para>
		/// <para>用于识别这些像元的影像服务或要素服务（将确定的最小成本路径为这些像元与成本最低的源之间的路径）。</para>
		/// <para>如果输入是影像服务，则输入由具有有效值（零是有效值）的像元组成，并且必须为其余的像元指定 NoData。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputdestinationrasterorfeatures { get; set; }

		/// <summary>
		/// <para>Input Cost Distance Raster</para>
		/// <para>要用于确定从目标位置到源的最小成本路径的成本距离影像服务的名称。</para>
		/// <para>通常使用计算行程成本工具创建成本距离栅格。对于每个像元，成本距离栅格存储从每个像元到一组源像元的成本面上的最小累积成本距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputcostdistanceraster { get; set; }

		/// <summary>
		/// <para>Input Cost Backlink Raster</para>
		/// <para>用于确定要经由最小成本路径返回到源的路径的成本回溯链接栅格名称。</para>
		/// <para>对于成本回溯链接栅格内的每个像元，值可识别在从像元到单个源像元或一组源像元的最小累积成本路径上作为下一像元的邻近像元。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputcostbacklinkraster { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>输出行程成本路径栅格服务的名称。</para>
		/// <para>默认名称基于工具名称以及输入图层名称。如果该图层名称已存在，则系统将提示您提供其他名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Destination Field</para>
		/// <para>目标图层上的字段，用于保存定义每个目标的值。</para>
		/// <para>输入要素服务必须至少包含一个有效字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Destinationfield { get; set; }

		/// <summary>
		/// <para>Path Type</para>
		/// <para>用于定义输入目标数据上的值和区域在成本路径计算中的解释方式。</para>
		/// <para>至每个像元—对于输入目标数据上每一个具有有效值的像元，系统会确定最小成本路径并将该路径保存在输出栅格上。利用该选项，系统会单独处理输入目标数据的每个像元，并确定每个“起始”像元的最小成本路径。这是默认设置。</para>
		/// <para>至每个区域—对于输入目标数据上的每个区域，系统会确定最小成本路径并将该路径保存在输出栅格上。利用该选项，每个区域的最小成本路径可起始于区域内成本距离权重最小的像元。</para>
		/// <para>最佳单一—对于输入目标数据上的所有像元，最小成本路径派生自距源像元具有最小成本路径的最小值的像元。</para>
		/// <para><see cref="PathtypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Pathtype { get; set; } = "EACH_CELL";

		/// <summary>
		/// <para>Output Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object Outputraster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DetermineTravelCostPathsToDestinations SetEnviroment(object cellSize = null , object extent = null , object mask = null , object outputCoordinateSystem = null , object snapRaster = null )
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
			/// <para>至每个像元—对于输入目标数据上每一个具有有效值的像元，系统会确定最小成本路径并将该路径保存在输出栅格上。利用该选项，系统会单独处理输入目标数据的每个像元，并确定每个“起始”像元的最小成本路径。这是默认设置。</para>
			/// </summary>
			[GPValue("EACH_CELL")]
			[Description("至每个像元")]
			To_each_cell,

			/// <summary>
			/// <para>至每个区域—对于输入目标数据上的每个区域，系统会确定最小成本路径并将该路径保存在输出栅格上。利用该选项，每个区域的最小成本路径可起始于区域内成本距离权重最小的像元。</para>
			/// </summary>
			[GPValue("EACH_ZONE")]
			[Description("至每个区域")]
			To_each_zone,

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
