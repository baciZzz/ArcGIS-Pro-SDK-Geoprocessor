using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Calculate Value</para>
	/// <para>计算值</para>
	/// <para>基于指定的 Python 表达式返回值。</para>
	/// </summary>
	[Obsolete()]
	public class CalculateValue : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Expression">
		/// <para>Expression</para>
		/// <para>要进行求值的 Python 表达式。</para>
		/// </param>
		public CalculateValue(object Expression)
		{
			this.Expression = Expression;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算值</para>
		/// </summary>
		public override string DisplayName() => "计算值";

		/// <summary>
		/// <para>Tool Name : CalculateValue</para>
		/// </summary>
		public override string ToolName() => "CalculateValue";

		/// <summary>
		/// <para>Tool Excute Name : management.CalculateValue</para>
		/// </summary>
		public override string ExcuteName() => "management.CalculateValue";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Expression, CodeBlock!, DataType!, Value! };

		/// <summary>
		/// <para>Expression</para>
		/// <para>要进行求值的 Python 表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSQLExpression()]
		public object Expression { get; set; }

		/// <summary>
		/// <para>Code Block</para>
		/// <para>Python 代码块。 必需在表达式参数中引用代码块中的代码。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? CodeBlock { get; set; }

		/// <summary>
		/// <para>Data type</para>
		/// <para>指定 Python 表达式返回值的数据类型。 此参数有助于将计算值工具与其他工具相连接。</para>
		/// <para>地址定位器—地址定位器</para>
		/// <para>分析像元大小—分析像元大小</para>
		/// <para>注记图层—注记图层</para>
		/// <para>任何值—任何值</para>
		/// <para>ArcMap 文档—ArcMap 文档</para>
		/// <para>面积单位—面积单位</para>
		/// <para>BIM 文件工作空间—BIM 文件工作空间</para>
		/// <para>布尔—布尔</para>
		/// <para>建筑领域图层—建筑领域图层</para>
		/// <para>建筑场景领域图层—建筑场景领域图层</para>
		/// <para>建筑图层—建筑图层</para>
		/// <para>构建场景图层—构建场景图层</para>
		/// <para>CAD 工程图数据集—CAD 工程图数据集</para>
		/// <para>计算器表达式—计算器表达式</para>
		/// <para>目录根—目录根</para>
		/// <para>像元大小—像元大小</para>
		/// <para>像元大小 XY—像元大小 XY</para>
		/// <para>复合图层—复合图层</para>
		/// <para>压缩—压缩</para>
		/// <para>坐标系—坐标系</para>
		/// <para>坐标系文件夹—坐标系文件夹</para>
		/// <para>Coverage—Coverage</para>
		/// <para>Coverage 要素类—Coverage 要素类</para>
		/// <para>数据元素—数据元素</para>
		/// <para>数据文件—数据文件</para>
		/// <para>数据库连接—数据库连接</para>
		/// <para>数据集—数据集</para>
		/// <para>日期—日期</para>
		/// <para>dBASE 表—dBASE 表</para>
		/// <para>抽稀—抽稀</para>
		/// <para>逻辑示意图图层—逻辑示意图图层</para>
		/// <para>尺寸图层—尺寸图层</para>
		/// <para>磁盘连接—磁盘连接</para>
		/// <para>双精度—双精度</para>
		/// <para>高程表面图层—高程表面图层</para>
		/// <para>加密字符串—加密字符串</para>
		/// <para>包络矩形—包络矩形</para>
		/// <para>评估等级—评估等级</para>
		/// <para>范围—范围</para>
		/// <para>提取值—提取值</para>
		/// <para>要素类—要素类</para>
		/// <para>要素数据集—要素数据集</para>
		/// <para>要素图层—要素图层</para>
		/// <para>要素集—要素集</para>
		/// <para>字段—字段</para>
		/// <para>字段信息—字段信息</para>
		/// <para>字段映射—字段映射</para>
		/// <para>文件—文件</para>
		/// <para>文件夹—文件夹</para>
		/// <para>格式化栅格—格式化栅格</para>
		/// <para>模糊函数—模糊函数</para>
		/// <para>GeoDataServer—GeoDataServer</para>
		/// <para>地理数据集—地理数据集</para>
		/// <para>几何网络—几何网络</para>
		/// <para>地统计图层—地统计图层</para>
		/// <para>地统计搜索邻域—地统计搜索邻域</para>
		/// <para>地统计值表—地统计值表</para>
		/// <para>GlobeServer—GlobeServer</para>
		/// <para>GPServer—GPServer</para>
		/// <para>图表—图表</para>
		/// <para>图表数据表—图表数据表</para>
		/// <para>图形图层—图形图层</para>
		/// <para>分组图层—分组图层</para>
		/// <para>水平系数—水平系数</para>
		/// <para>影像服务—影像服务</para>
		/// <para>索引—索引</para>
		/// <para>INFO 表达式—INFO 表达式</para>
		/// <para>INFO 项目—INFO 项目</para>
		/// <para>INFO 表—INFO 表</para>
		/// <para>Internet 切片图层—Internet 切片图层</para>
		/// <para>KML 图层—KML 图层</para>
		/// <para>LAS 数据集—LAS 数据集</para>
		/// <para>LAS 数据集图层—LAS 数据集图层</para>
		/// <para>图层—图层</para>
		/// <para>图层文件—图层文件</para>
		/// <para>布局—布局</para>
		/// <para>线—线</para>
		/// <para>线性单位—线性单位</para>
		/// <para>长整型—长整型</para>
		/// <para>M 值域—M 值域</para>
		/// <para>地图—地图</para>
		/// <para>地图服务器—地图服务器</para>
		/// <para>地图服务器图层—地图服务器图层</para>
		/// <para>镶嵌数据集—镶嵌数据集</para>
		/// <para>镶嵌图层—镶嵌图层</para>
		/// <para>邻域分析—邻域分析</para>
		/// <para>Network Analyst 类 FieldMap—Network Analyst 类 FieldMap</para>
		/// <para>Network Analyst 等级设置—Network Analyst 等级设置</para>
		/// <para>网络分析图层—网络分析图层</para>
		/// <para>网络数据源—网络数据源</para>
		/// <para>网络数据集—网络数据集</para>
		/// <para>网络数据集图层—网络数据集图层</para>
		/// <para>网络出行模式—网络出行模式</para>
		/// <para>宗地结构—宗地结构</para>
		/// <para>ArcMap 宗地结构—ArcMap 宗地结构</para>
		/// <para>ArcMap 宗地结构图层—ArcMap 宗地结构图层</para>
		/// <para>宗地图层—宗地图层</para>
		/// <para>点—点</para>
		/// <para>面—面</para>
		/// <para>投影文件—投影文件</para>
		/// <para>金字塔—金字塔</para>
		/// <para>半径—半径</para>
		/// <para>随机数生成器—随机数生成器</para>
		/// <para>栅格波段—栅格波段</para>
		/// <para>栅格计算器表达式—栅格计算器表达式</para>
		/// <para>栅格目录—栅格目录</para>
		/// <para>栅格目录图层—栅格目录图层</para>
		/// <para>栅格数据图层—栅格数据图层</para>
		/// <para>栅格数据集—栅格数据集</para>
		/// <para>栅格图层—栅格图层</para>
		/// <para>栅格统计—栅格统计</para>
		/// <para>栅格类型—栅格类型</para>
		/// <para>记录集—记录集</para>
		/// <para>关系类—关系类</para>
		/// <para>重映射—重映射</para>
		/// <para>报表—报表</para>
		/// <para>路径测量事件属性—路径测量事件属性</para>
		/// <para>场景图层—场景图层</para>
		/// <para>半变异函数—半变异函数</para>
		/// <para>ServerConnection—ServerConnection</para>
		/// <para>Shapefile—Shapefile</para>
		/// <para>空间参考—空间参考</para>
		/// <para>SQL 表达式—SQL 表达式</para>
		/// <para>字符串—字符串</para>
		/// <para>隐藏字符串—隐藏字符串</para>
		/// <para>表—表</para>
		/// <para>表视图—表视图</para>
		/// <para>Terrain 图层—Terrain 图层</para>
		/// <para>文本文件—文本文件</para>
		/// <para>分块大小—分块大小</para>
		/// <para>时间配置—时间配置</para>
		/// <para>时间单位—时间单位</para>
		/// <para>TIN—TIN</para>
		/// <para>TIN 图层—TIN 图层</para>
		/// <para>工具—工具</para>
		/// <para>工具箱—工具箱</para>
		/// <para>拓扑要素—拓扑要素</para>
		/// <para>拓扑—拓扑</para>
		/// <para>拓扑图层—拓扑图层</para>
		/// <para>追踪网络—追踪网络</para>
		/// <para>追踪网络图层—追踪网络图层</para>
		/// <para>变换函数—变换函数</para>
		/// <para>公共设施网络—公共设施网络</para>
		/// <para>公共设施网络图层—公共设施网络图层</para>
		/// <para>变量—变量</para>
		/// <para>矢量切片图层—矢量切片图层</para>
		/// <para>垂直系数—垂直系数</para>
		/// <para>体元图层—体元图层</para>
		/// <para>VPF Coverage—VPF Coverage</para>
		/// <para>VPF 表—VPF 表</para>
		/// <para>WCS Coverage—WCS Coverage</para>
		/// <para>加权叠加表—加权叠加表</para>
		/// <para>加权总和—加权总和</para>
		/// <para>WMS 地图—WMS 地图</para>
		/// <para>WMTS 图层—WMTS 图层</para>
		/// <para>工作空间—工作空间</para>
		/// <para>XY 值域—XY 值域</para>
		/// <para>Z 值域—Z 值域</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DataType { get; set; } = "GPVariant";

		/// <summary>
		/// <para>Value</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPType()]
		public object? Value { get; set; }

	}
}
