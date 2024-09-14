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
	/// <para>确定最佳行程成本网络</para>
	/// <para>计算一组输入区域的最佳成本网络。</para>
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
		/// <para>要通过最低成本网络连接的输入区域。</para>
		/// <para>区域可以通过影像服务或要素服务来定义。</para>
		/// <para>如果区域输入为栅格，则区域将通过值相同的连续（邻近）像元组进行定义。 每个区域必须具有唯一的编号。 不属于任何区域的像元一定是 NoData。 栅格类型必须为整型，值可正可负。</para>
		/// <para>如果区域输入为要素，则其可以是面、线或点。 面要素区域不能包含多部分面。</para>
		/// </param>
		/// <param name="Inputcostraster">
		/// <para>Input Cost Raster</para>
		/// <para>定义以平面测量的经过每个像元所需的阻抗或成本。</para>
		/// <para>每个像元位置上的值表示经过像元时移动每单位距离所需的成本。 每个像元位置值乘以像元分辨率，同时也会补偿对角线移动来获取经过像元的总成本。</para>
		/// <para>成本栅格的值可以是整型或浮点型，但不可以为负值或零（不存在负成本或零成本）。</para>
		/// </param>
		/// <param name="Outputoptimumnetworkname">
		/// <para>Output Optimum Network Name</para>
		/// <para>输出最佳网络要素服务的名称。</para>
		/// <para>最佳（成本最低）路径网络的折线要素服务需要连接每个输入区域。</para>
		/// <para>每条路径（或线）都是唯一标识的，同时属性表中的其他字段用于存储有关路径的特定信息。 这些字段包括：</para>
		/// <para>PATHID- 路径的唯一标识符</para>
		/// <para>PATHCOST- 路径的总累计成本</para>
		/// <para>REGION1- 该路径连接的第一个区域</para>
		/// <para>REGION2- 该路径连接的另一个区域</para>
		/// <para>该信息有助于您深入分析网络内的路径。</para>
		/// <para>由于每条路径都是由唯一的线所表示，因此多条路径经过同一路线的位置会存在多条线。</para>
		/// </param>
		public DetermineOptimumTravelCostNetwork(object Inputregionsrasterorfeatures, object Inputcostraster, object Outputoptimumnetworkname)
		{
			this.Inputregionsrasterorfeatures = Inputregionsrasterorfeatures;
			this.Inputcostraster = Inputcostraster;
			this.Outputoptimumnetworkname = Outputoptimumnetworkname;
		}

		/// <summary>
		/// <para>Tool Display Name : 确定最佳行程成本网络</para>
		/// </summary>
		public override string DisplayName() => "确定最佳行程成本网络";

		/// <summary>
		/// <para>Tool Name : DetermineOptimumTravelCostNetwork</para>
		/// </summary>
		public override string ToolName() => "DetermineOptimumTravelCostNetwork";

		/// <summary>
		/// <para>Tool Excute Name : ra.DetermineOptimumTravelCostNetwork</para>
		/// </summary>
		public override string ExcuteName() => "ra.DetermineOptimumTravelCostNetwork";

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
		public override object[] Parameters() => new object[] { Inputregionsrasterorfeatures, Inputcostraster, Outputoptimumnetworkname, Outputneighbornetworkname!, Outputoptimumnetworkfeatures!, Outputneighbornetworkfeatures! };

		/// <summary>
		/// <para>Input Regions Raster or Features</para>
		/// <para>要通过最低成本网络连接的输入区域。</para>
		/// <para>区域可以通过影像服务或要素服务来定义。</para>
		/// <para>如果区域输入为栅格，则区域将通过值相同的连续（邻近）像元组进行定义。 每个区域必须具有唯一的编号。 不属于任何区域的像元一定是 NoData。 栅格类型必须为整型，值可正可负。</para>
		/// <para>如果区域输入为要素，则其可以是面、线或点。 面要素区域不能包含多部分面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputregionsrasterorfeatures { get; set; }

		/// <summary>
		/// <para>Input Cost Raster</para>
		/// <para>定义以平面测量的经过每个像元所需的阻抗或成本。</para>
		/// <para>每个像元位置上的值表示经过像元时移动每单位距离所需的成本。 每个像元位置值乘以像元分辨率，同时也会补偿对角线移动来获取经过像元的总成本。</para>
		/// <para>成本栅格的值可以是整型或浮点型，但不可以为负值或零（不存在负成本或零成本）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputcostraster { get; set; }

		/// <summary>
		/// <para>Output Optimum Network Name</para>
		/// <para>输出最佳网络要素服务的名称。</para>
		/// <para>最佳（成本最低）路径网络的折线要素服务需要连接每个输入区域。</para>
		/// <para>每条路径（或线）都是唯一标识的，同时属性表中的其他字段用于存储有关路径的特定信息。 这些字段包括：</para>
		/// <para>PATHID- 路径的唯一标识符</para>
		/// <para>PATHCOST- 路径的总累计成本</para>
		/// <para>REGION1- 该路径连接的第一个区域</para>
		/// <para>REGION2- 该路径连接的另一个区域</para>
		/// <para>该信息有助于您深入分析网络内的路径。</para>
		/// <para>由于每条路径都是由唯一的线所表示，因此多条路径经过同一路线的位置会存在多条线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputoptimumnetworkname { get; set; }

		/// <summary>
		/// <para>Output Neighbor Network Name</para>
		/// <para>输出邻域网络要素服务的名称。</para>
		/// <para>该折线要素服务用于标识从每个区域到其每个最近成本邻域的所有路径。</para>
		/// <para>每条路径（或线）都是唯一标识的，同时属性表中的其他字段用于存储有关路径的特定信息。 这些字段包括：</para>
		/// <para>PATHID- 路径的唯一标识符</para>
		/// <para>PATHCOST- 路径的总累计成本</para>
		/// <para>REGION1- 该路径连接的第一个区域</para>
		/// <para>REGION2- 该路径连接的另一个区域</para>
		/// <para>该信息有助于深入分析网络内的路径，而且对于决定应该移除哪条路径尤其有用（如有必要）。</para>
		/// <para>由于每条路径都是由唯一的线所表示，因此多条路径经过同一路线的位置会存在多条线。</para>
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
		public DetermineOptimumTravelCostNetwork SetEnviroment(object? cellSize = null, object? extent = null, object? mask = null, object? outputCoordinateSystem = null, object? snapRaster = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, snapRaster: snapRaster);
			return this;
		}

	}
}
