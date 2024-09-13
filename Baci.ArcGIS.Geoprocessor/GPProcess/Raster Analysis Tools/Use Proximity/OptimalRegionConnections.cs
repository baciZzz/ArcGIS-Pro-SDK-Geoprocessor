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
	/// <para>最佳区域连接</para>
	/// <para>在两个或多个输入区域之间计算最佳路径连接。</para>
	/// </summary>
	public class OptimalRegionConnections : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputregionrasterorfeatures">
		/// <para>Input Region Raster or Features</para>
		/// <para>要通过最佳网络连接的输入区域。</para>
		/// <para>区域可以通过栅格或要素数据来定义。</para>
		/// <para>如果区域输入为栅格，则区域将通过值相同的连续（邻近）像元组进行定义。每个区域必须具有唯一的编号。不属于任何区域的像元一定是 NoData。栅格类型必须为整型，值可正可负。</para>
		/// <para>如果区域输入为要素数据，则其可以是面、线或点。面要素区域不能包含多部分面。</para>
		/// </param>
		/// <param name="Outputoptimallinesname">
		/// <para>Output Optimal Connectivity Lines Name</para>
		/// <para>连接每个输入区域的输出线要素服务的名称。</para>
		/// <para>每条路径（或线）都是唯一标识的，同时属性表中的其他字段用于存储有关路径的特定信息。这些其他字段包括：</para>
		/// <para>PATHID - 路径的唯一标识符</para>
		/// <para>PATHCOST - 路径的总累计距离或成本</para>
		/// <para>REGION1 - 该路径连接的第一个区域</para>
		/// <para>REGION2 - 该路径连接的另一个区域</para>
		/// <para>该信息有助于深入分析网络内的路径。</para>
		/// <para>由于每条路径都是由唯一的线所表示，因此多条路径经过同一路线的位置会存在多条线。</para>
		/// </param>
		public OptimalRegionConnections(object Inputregionrasterorfeatures, object Outputoptimallinesname)
		{
			this.Inputregionrasterorfeatures = Inputregionrasterorfeatures;
			this.Outputoptimallinesname = Outputoptimallinesname;
		}

		/// <summary>
		/// <para>Tool Display Name : 最佳区域连接</para>
		/// </summary>
		public override string DisplayName() => "最佳区域连接";

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
		/// <para>要通过最佳网络连接的输入区域。</para>
		/// <para>区域可以通过栅格或要素数据来定义。</para>
		/// <para>如果区域输入为栅格，则区域将通过值相同的连续（邻近）像元组进行定义。每个区域必须具有唯一的编号。不属于任何区域的像元一定是 NoData。栅格类型必须为整型，值可正可负。</para>
		/// <para>如果区域输入为要素数据，则其可以是面、线或点。面要素区域不能包含多部分面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputregionrasterorfeatures { get; set; }

		/// <summary>
		/// <para>Output Optimal Connectivity Lines Name</para>
		/// <para>连接每个输入区域的输出线要素服务的名称。</para>
		/// <para>每条路径（或线）都是唯一标识的，同时属性表中的其他字段用于存储有关路径的特定信息。这些其他字段包括：</para>
		/// <para>PATHID - 路径的唯一标识符</para>
		/// <para>PATHCOST - 路径的总累计距离或成本</para>
		/// <para>REGION1 - 该路径连接的第一个区域</para>
		/// <para>REGION2 - 该路径连接的另一个区域</para>
		/// <para>该信息有助于深入分析网络内的路径。</para>
		/// <para>由于每条路径都是由唯一的线所表示，因此多条路径经过同一路线的位置会存在多条线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputoptimallinesname { get; set; }

		/// <summary>
		/// <para>Input Barrier Raster or Features</para>
		/// <para>定义障碍的数据集。</para>
		/// <para>可通过整型或浮点型图像服务或要素服务来定义障碍。</para>
		/// <para>对于图像服务障碍，该障碍必须具有有效值（包括零），并且非障碍区域必须为 NoData。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputbarrierrasterorfeatures { get; set; }

		/// <summary>
		/// <para>Input Cost Raster</para>
		/// <para>定义以平面测量方式经过每个像元的成本或阻抗的栅格。</para>
		/// <para>每个像元位置上的值表示经过像元时移动每单位距离所需的成本。每个像元位置值乘以像元分辨率，同时也会补偿对角线移动来获取经过像元的总成本。</para>
		/// <para>成本栅格的值可以是整型或浮点型，但不可以为负值或零（不存在负成本或零成本）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Inputcostraster { get; set; }

		/// <summary>
		/// <para>Output Neighboring Connections Name</para>
		/// <para>该输出折线要素类用于标识从每个区域到其每个最近或成本相邻要素的所有路径。</para>
		/// <para>每条路径（或线）都是唯一标识的，同时属性表中的其他字段用于存储有关路径的特定信息。这些其他字段包括：</para>
		/// <para>PATHID - 路径的唯一标识符</para>
		/// <para>PATHCOST - 路径的总累计距离或成本</para>
		/// <para>REGION1 - 该路径连接的第一个区域</para>
		/// <para>REGION2 - 该路径连接的另一个区域</para>
		/// <para>该信息有助于深入分析网络内的路径，而且对于决定应该移除哪条路径非常有用（如有必要）。</para>
		/// <para>由于每条路径都是由唯一的线所表示，因此多条路径经过同一路线的位置会存在多条线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Outputneighborconnectionsname { get; set; }

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>指定是否使用平面（平地）或测地线（椭球）方法计算距离。</para>
		/// <para>平面—将使用 2D 笛卡尔坐标系对投影平面执行距离计算。这是默认设置。</para>
		/// <para>测地线—距离计算将在椭圆体上执行。因此，结果不会改变，不考虑输入或输出投影。</para>
		/// <para><see cref="DistancemethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Distancemethod { get; set; } = "PLANAR";

		/// <summary>
		/// <para>Connections Within Regions</para>
		/// <para>指定路径是否将在输入区域内继续并连接。</para>
		/// <para>生成连接—路径将在输入区域内继续以连接进入区域的所有路径。</para>
		/// <para>无连接—路径将在输入区域的边缘停止，并且不会在输入区域内继续或连接。</para>
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
		public OptimalRegionConnections SetEnviroment(object cellSize = null , object extent = null , object mask = null , object outputCoordinateSystem = null , object snapRaster = null )
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
			/// <para>平面—将使用 2D 笛卡尔坐标系对投影平面执行距离计算。这是默认设置。</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("平面")]
			Planar,

			/// <summary>
			/// <para>测地线—距离计算将在椭圆体上执行。因此，结果不会改变，不考虑输入或输出投影。</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("测地线")]
			Geodesic,

		}

		/// <summary>
		/// <para>Connections Within Regions</para>
		/// </summary>
		public enum ConnectionswithinregionsEnum 
		{
			/// <summary>
			/// <para>生成连接—路径将在输入区域内继续以连接进入区域的所有路径。</para>
			/// </summary>
			[GPValue("GENERATE_CONNECTIONS")]
			[Description("生成连接")]
			Generate_connections,

			/// <summary>
			/// <para>无连接—路径将在输入区域的边缘停止，并且不会在输入区域内继续或连接。</para>
			/// </summary>
			[GPValue("NO_CONNECTIONS")]
			[Description("无连接")]
			No_connections,

		}

#endregion
	}
}
