using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AnalysisTools
{
	/// <summary>
	/// <para>Generate Origin-Destination Links</para>
	/// <para>生成起点-目的地链接</para>
	/// <para>用于从起点要素到目的地要素生成连接线。 这通常被称为蛛网图。</para>
	/// </summary>
	public class GenerateOriginDestinationLinks : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OriginFeatures">
		/// <para>Origin Features</para>
		/// <para>将以其为起点生成链接的输入要素。</para>
		/// </param>
		/// <param name="DestinationFeatures">
		/// <para>Destination Features</para>
		/// <para>将以其为终点生成链接的目的地要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将包含输出链接的输出折线要素类。</para>
		/// </param>
		public GenerateOriginDestinationLinks(object OriginFeatures, object DestinationFeatures, object OutFeatureClass)
		{
			this.OriginFeatures = OriginFeatures;
			this.DestinationFeatures = DestinationFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成起点-目的地链接</para>
		/// </summary>
		public override string DisplayName() => "生成起点-目的地链接";

		/// <summary>
		/// <para>Tool Name : GenerateOriginDestinationLinks</para>
		/// </summary>
		public override string ToolName() => "GenerateOriginDestinationLinks";

		/// <summary>
		/// <para>Tool Excute Name : analysis.GenerateOriginDestinationLinks</para>
		/// </summary>
		public override string ExcuteName() => "analysis.GenerateOriginDestinationLinks";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise() => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { OriginFeatures, DestinationFeatures, OutFeatureClass, OriginGroupField!, DestinationGroupField!, LineType!, NumNearest!, SearchDistance!, DistanceUnit!, AggregateLinks!, SumFields! };

		/// <summary>
		/// <para>Origin Features</para>
		/// <para>将以其为起点生成链接的输入要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object OriginFeatures { get; set; }

		/// <summary>
		/// <para>Destination Features</para>
		/// <para>将以其为终点生成链接的目的地要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object DestinationFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将包含输出链接的输出折线要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Origin Group Field</para>
		/// <para>用于分组的输入起点要素中的属性字段。 在起点和目的地之间具有相同字段组值的要素将通过链接进行连接。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object? OriginGroupField { get; set; }

		/// <summary>
		/// <para>Destination Group Field</para>
		/// <para>用于分组的输入目的地要素中的属性字段。 在起点和目的地之间具有相同字段组值的要素将通过链接进行连接。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object? DestinationGroupField { get; set; }

		/// <summary>
		/// <para>Line Type</para>
		/// <para>指定在生成输出链接时，将使用椭球体（测地线）还是笛卡尔投影地球（平面）上的最短路径。 当测地线的长度超过约 50 千米时，测地线将略微弯曲，因为在 2D 地图上查看时，地球的曲率会使两点之间的最短距离显得弯曲。</para>
		/// <para>建议将测地线类型用于在不适合进行距离测量的坐标系（例如 Web 墨卡托和任何地理坐标系）中存储的数据，或者任何地理区域跨度较大的数据集。</para>
		/// <para>平面—要素之间将使用平面距离。 这是默认设置。</para>
		/// <para>测地线—要素之间将使用测地线距离。 这种线类型考虑到椭球体的曲率，并可以正确处理日期变更线和两极附近的数据。</para>
		/// <para><see cref="LineTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LineType { get; set; } = "PLANAR";

		/// <summary>
		/// <para>Number of Nearest Destinations</para>
		/// <para>针对每个起点要素到最近的目的地要素将生成的最大链接数量。 如果未指定任何数字，则该工具将在所有起点要素和目的地要素之间生成链接。</para>
		/// <para>例如，使用值 1 将在每个起点要素及其最接近的目的地要素之间生成链接。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? NumNearest { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>将在输出中生成链接要素的起点和目的地要素之间的最大距离。 搜索距离的单位将在距离单位参数中指定。 如果未指定任何搜索距离，则该工具将在所有起点要素和目的地要素之间生成链接，而不考虑它们之间的距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SearchDistance { get; set; }

		/// <summary>
		/// <para>Distance Unit</para>
		/// <para>指定用于测量链接长度的单位。 每个链接的距离将显示在 LINK_DIST 字段中。 如果未指定距离单位，则将使用起点要素坐标系的距离单位。</para>
		/// <para>千米—将以千米为单位计算起点和目的地之间的距离。</para>
		/// <para>米—将以米为单位计算起点和目的地之间的距离。</para>
		/// <para>英里—将以英里为单位计算起点和目的地之间的距离。</para>
		/// <para>海里—将以海里为单位计算起点和目的地之间的距离。</para>
		/// <para>码—将以码为单位计算起点和目的地之间的距离。</para>
		/// <para>英尺—将以英尺为单位计算起点和目的地之间的距离。</para>
		/// <para><see cref="DistanceUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DistanceUnit { get; set; }

		/// <summary>
		/// <para>Aggregate Overlapping Links</para>
		/// <para>指定是否将对重叠链接进行聚合。</para>
		/// <para>选中 - 如果起点坐标相同，则将对重叠链接进行聚合。</para>
		/// <para>未选中 - 将不会以重叠链接进行聚合。 这是默认设置。</para>
		/// <para><see cref="AggregateLinksEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AggregateLinks { get; set; } = "false";

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>指定包含用于计算指定统计数据的属性值的一个或多个数值字段。 可以指定多项统计和字段组合。 空值将被排除在所有统计计算之外。</para>
		/// <para>可使用第一种和最后一种统计来对文本属性字段进行汇总。 可使用任何一种统计来对数值属性字段进行汇总。</para>
		/// <para>可用统计类型如下：</para>
		/// <para>总和 - 将指定字段的值相加在一起。</para>
		/// <para>平均值 - 将计算指定字段的平均值。</para>
		/// <para>最小值 - 将查找指定字段所有记录的最小值。</para>
		/// <para>最大值 - 将查找指定字段所有记录的最大值。</para>
		/// <para>范围 - 将计算指定字段的值范围（最大值 - 最小值）。</para>
		/// <para>标准差 - 将计算指定字段中值的标准差。</para>
		/// <para>计数 - 将查找统计计算中包括的值的数目。 计数包括除空值外的所有值。 要确定字段中的空值数，请在相应字段上创建计数，然后在另一个不包含空值的字段上创建计数（例如 OID，如果存在的话），然后将这两个值相减。</para>
		/// <para>第一个 - 将使用输入中第一条记录的指定字段值。</para>
		/// <para>最后一个 - 将使用输入中最后一条记录的指定字段值。</para>
		/// <para>中值 - 将计算指定字段所有记录的中值。</para>
		/// <para>方差 - 将计算指定字段所有记录的方差。</para>
		/// <para>唯一值 - 将计算指定字段的唯一值数量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? SumFields { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateOriginDestinationLinks SetEnviroment(object? extent = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Line Type</para>
		/// </summary>
		public enum LineTypeEnum 
		{
			/// <summary>
			/// <para>平面—要素之间将使用平面距离。 这是默认设置。</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("平面")]
			Planar,

			/// <summary>
			/// <para>测地线—要素之间将使用测地线距离。 这种线类型考虑到椭球体的曲率，并可以正确处理日期变更线和两极附近的数据。</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("测地线")]
			Geodesic,

		}

		/// <summary>
		/// <para>Distance Unit</para>
		/// </summary>
		public enum DistanceUnitEnum 
		{
			/// <summary>
			/// <para>千米—将以千米为单位计算起点和目的地之间的距离。</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("千米")]
			Kilometers,

			/// <summary>
			/// <para>米—将以米为单位计算起点和目的地之间的距离。</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("米")]
			Meters,

			/// <summary>
			/// <para>英里—将以英里为单位计算起点和目的地之间的距离。</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("英里")]
			Miles,

			/// <summary>
			/// <para>海里—将以海里为单位计算起点和目的地之间的距离。</para>
			/// </summary>
			[GPValue("NAUTICALMILES")]
			[Description("海里")]
			Nautical_miles,

			/// <summary>
			/// <para>码—将以码为单位计算起点和目的地之间的距离。</para>
			/// </summary>
			[GPValue("YARDS")]
			[Description("码")]
			Yards,

			/// <summary>
			/// <para>英尺—将以英尺为单位计算起点和目的地之间的距离。</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("英尺")]
			Feet,

		}

		/// <summary>
		/// <para>Aggregate Overlapping Links</para>
		/// </summary>
		public enum AggregateLinksEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("AGGREGATE_OVERLAPPING")]
			AGGREGATE_OVERLAPPING,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_AGGREGATE")]
			NO_AGGREGATE,

		}

#endregion
	}
}
