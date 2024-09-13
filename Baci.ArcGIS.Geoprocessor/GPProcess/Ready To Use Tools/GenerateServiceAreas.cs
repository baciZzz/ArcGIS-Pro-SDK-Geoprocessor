using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ReadyToUseTools
{
	/// <summary>
	/// <para>Generate Service Areas</para>
	/// <para>生成服务区</para>
	/// <para>确定设施点周围的网络服务区。 网络服务区是指包含从一个或多个设施点的给定距离或行程时间之内可到达的所有街道的区域。 例如，某一设施点的 10 分钟服务区包含从该设施点出发 10 分钟内可以到达的所有街道。</para>
	/// </summary>
	public class GenerateServiceAreas : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Facilities">
		/// <para>Facilities</para>
		/// <para>在其周围生成服务区的输入位置。</para>
		/// <para>最多可加载 1,000 个设施点。</para>
		/// <para>设施点要素集具有一个关联的属性表。 下面介绍了属性表中的字段。</para>
		/// <para>ObjectID</para>
		/// <para>系统管理的 ID 字段。</para>
		/// <para>Name</para>
		/// <para>设施点的名称。 如果未指定名称，则求解过程中会自动生成一个名称。</para>
		/// <para>当“多个设施点的面”参数设置为“叠置”或“不叠置”时，输入设施点的所有字段都包含在输出面中。 输入设备点的 ObjectID 字段会传递到输出面的 FacilityOID 字段中。</para>
		/// <para>Breaks</para>
		/// <para>指定基于每个设施点计算的服务区范围。</para>
		/// <para>此属性允许您为每个设施点指定不同服务区中断值。 例如，对于两个设施点，您可以为其中一个设施点生成 5 和 10 分钟服务区，为另一个设施点生成 6、9 和 12 分钟服务区。</para>
		/// <para>使用空格分隔多个中断值，使用点字符作为小数分隔符指定数值，即使计算机的区域设置定义了其他小数分隔符也是如此。 例如，值 5.5 10 15.5 用于指定设施点周围的三个中断值。</para>
		/// <para>AdditionalTime</para>
		/// <para>在设施点花费的时间量，可缩减针对给定设施点计算的服务区范围。 默认值为 0。</para>
		/// <para>例如，在计算表示消防站响应时间的服务区时，AdditionalTime 中可以存储每个消防站的出动时间，该时间为消防员配带好适当的防护设备并离开消防站所用的时间。 假设“消防站 1”的出动时间为 1 分钟，“消防站 2”的出动时间为 3 分钟。 如果分别计算这两个消防站的 5 分钟服务区，则“消防站 1”的实际服务区相当于 4 分钟服务区的范围（因为在这 5 分钟里需要 1 分钟的出动时间）。 同样，“消防站 2”的服务区距离消防站仅为 2 分钟。</para>
		/// <para>AdditionalDistance</para>
		/// <para>在计算服务之前，为到达设施点所行驶的额外距离。 此属性可缩减针对给定设施点计算的服务区的范围。 默认值为 0。</para>
		/// <para>通常，设施点的位置（例如门店地点）并不是恰好位于街道上，而是位于道路的后方。 该属性值可用于构建实际设施点位置与其在街道上的位置之间的距离，如有必要，可在计算设施点的服务区时包括此段距离。</para>
		/// <para>AdditionalCost</para>
		/// <para>在设施点花费的额外成本，可缩减针对给定设施点计算的服务区范围。 默认值为 0。</para>
		/// <para>当分析的出行模式使用不基于时间也不基于距离的阻抗属性时，使用此属性值。属性值的单位将理解为未知单位。</para>
		/// <para>CurbApproach</para>
		/// <para>指定车辆到达和离开设施点的方向。 该字段值可指定为以下整数之一（请使用数值代码而非括号中的名称）：</para>
		/// <para>0（车辆的任意一侧）- 车辆可从任一方向到达和离开设施点，因此设施点处允许 U 形转弯。 如果车辆有可能要在设施点处调头，则可以选择该设置。 此决策可能取决于道路的宽度以及交通量，或者该设施点是否有停车场能让车辆驶入并调头。</para>
		/// <para>1（车辆的右侧）- 当车辆到达和离开设施点时，路边必须在车辆右侧。 禁止 U 形转弯。 通常用于必须在右侧停靠的车辆（如公共汽车）。</para>
		/// <para>2（车辆的左侧）- 当车辆到达和离开设施点时，路边必须在车辆左侧。 禁止 U 形转弯。 通常用于必须在左侧停靠的车辆（如公共汽车）。</para>
		/// <para>3（禁止 U 形转弯）- 当车辆到达设施点时，路边可在车辆的任意一侧；但是，车辆在离开时不得调头。</para>
		/// <para>CurbApproach 属性是专为使用以下两种国家驾驶标准而设计的：右侧通行（美国）和左侧通行（英国）。 首先，考虑位于车辆左侧的设施点。 不管车辆行驶在左车道还是右车道，停靠点始终位于车辆的左侧。 不同国家的驾驶标准可能会要求您从这两种方向中的其中一个接近设施点；即只能从车辆的右侧或左侧接近设施点。 例如，如果要到达一个设施点并且在车辆与设施点之间不存在其他交通车道，在美国应该选择 1（车辆的右侧），而在英国应该选择 2（车辆的左侧）。</para>
		/// <para>Bearing</para>
		/// <para>点移动的方向。 单位为度，从正北开始沿顺时针方向进行测量。 该字段与 BearingTol 字段结合使用。</para>
		/// <para>方位角数据通常会从配有 GPS 接收器的移动设备自动发送。 如果正在加载移动输入位置（例如行人或车辆），请尝试包括方位角数据。</para>
		/// <para>使用该字段可以防止将位置添加到错误的边上，例如，车辆刚好在交叉路口或天桥附近时。 方位角也可帮助工具确定点在街道的哪一边上。</para>
		/// <para>BearingTol</para>
		/// <para>使用 Bearing 字段在边上定位移动点时，方位角容差值将创建一个可接受方位角值的范围。 如果 Bearing 字段值在可接受值范围（由边上的方位角容差生成）内，则可以将该点作为网络位置添加在此处，否则，将计算下一个最近边上的最近点。</para>
		/// <para>单位为度，默认值为 30。 值必须大于 0 且小于 180。 值为 30 表示，Network Analyst 尝试在边上添加网络位置时，在边的每一侧（左侧和右侧）的两个数字化方向上都将生成一个 15 度的可接受方位角值。</para>
		/// <para>NavLatency</para>
		/// <para>如果 Bearing 和 BearingTol 也具有值，则该字段只在求解过程中使用；但是，即使当 Bearing 和 BearingTolNavLatency 字段中有值时，NavLatency 值的输入也是可选的。NavLatency 表示 GPS 信息从移动的车辆上发送到服务器以及车辆导航设备接收到处理后路径这两个时刻之间预期要花费的成本。</para>
		/// <para>NavLatency 的单位与阻抗属性的单位相同。</para>
		/// </param>
		/// <param name="BreakValues">
		/// <para>Break Values</para>
		/// <para>指定为每个设施点生成的服务区面的大小和数量。 单位由“中断单位”值决定。</para>
		/// <para>可以设置多个面中断来为每个设施点创建同心服务区。 例如，要查找每个设施点的 2 英里、3 英里及 5 英里服务区，请输入 2 3 5，各个数值之间用空格进行分隔，将设置“中断单位”设置为“英里”。 所指定中断值的数量没有限制。</para>
		/// <para>最大中断值的大小不能超过 300 分钟或 300 英里（482.80 千米）。 当生成详细面时，最大服务区大小限制为 15 分钟和 15 英里（24.14 千米）。</para>
		/// </param>
		/// <param name="BreakUnits">
		/// <para>Break Units</para>
		/// <para>指定中断值参数的单位。</para>
		/// <para>此参数单位的选择决定了工具通过测量行驶距离还是行驶时间来创建服务区。 选择时间单位以测量行驶时间。 要测量行驶距离，则请选择距离单位。 选择的单位还确定工具在结果中报告总行驶时间或距离时采用的单位。</para>
		/// <para>具体选项如下：</para>
		/// <para>米—线性单位为米。</para>
		/// <para>千米—线性单位为千米。</para>
		/// <para>英尺—线性单位为英尺。</para>
		/// <para>码—线性单位为码。</para>
		/// <para>英里—线性单位为英里。</para>
		/// <para>海里—线性单位为海里。</para>
		/// <para>秒—时间单位为秒。</para>
		/// <para>分—时间单位为分钟。</para>
		/// <para>小时—时间单位为小时。</para>
		/// <para>天—时间单位为天。</para>
		/// <para><see cref="BreakUnitsEnum"/></para>
		/// </param>
		public GenerateServiceAreas(object Facilities, object BreakValues, object BreakUnits)
		{
			this.Facilities = Facilities;
			this.BreakValues = BreakValues;
			this.BreakUnits = BreakUnits;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成服务区</para>
		/// </summary>
		public override string DisplayName() => "生成服务区";

		/// <summary>
		/// <para>Tool Name : GenerateServiceAreas</para>
		/// </summary>
		public override string ToolName() => "GenerateServiceAreas";

		/// <summary>
		/// <para>Tool Excute Name : agolservices.GenerateServiceAreas</para>
		/// </summary>
		public override string ExcuteName() => "agolservices.GenerateServiceAreas";

		/// <summary>
		/// <para>Toolbox Display Name : Ready To Use Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Ready To Use Tools";

		/// <summary>
		/// <para>Toolbox Alise : agolservices</para>
		/// </summary>
		public override string ToolboxAlise() => "agolservices";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Facilities, BreakValues, BreakUnits, AnalysisRegion!, TravelDirection!, TimeOfDay!, UseHierarchy!, UturnAtJunctions!, PolygonsForMultipleFacilities!, PolygonOverlapType!, DetailedPolygons!, PolygonTrimDistance!, PolygonSimplificationTolerance!, PointBarriers!, LineBarriers!, PolygonBarriers!, Restrictions!, AttributeParameterValues!, TimeZoneForTimeOfDay!, TravelMode!, Impedance!, SaveOutputNetworkAnalysisLayer!, Overrides!, TimeImpedance!, DistanceImpedance!, PolygonDetail!, OutputType!, OutputFormat!, IgnoreInvalidLocations!, ServiceAreas!, SolveSucceeded!, OutputNetworkAnalysisLayer!, OutputFacilities!, OutputServiceAreaLines!, OutputResultFile!, OutputNetworkAnalysisLayerPackage! };

		/// <summary>
		/// <para>Facilities</para>
		/// <para>在其周围生成服务区的输入位置。</para>
		/// <para>最多可加载 1,000 个设施点。</para>
		/// <para>设施点要素集具有一个关联的属性表。 下面介绍了属性表中的字段。</para>
		/// <para>ObjectID</para>
		/// <para>系统管理的 ID 字段。</para>
		/// <para>Name</para>
		/// <para>设施点的名称。 如果未指定名称，则求解过程中会自动生成一个名称。</para>
		/// <para>当“多个设施点的面”参数设置为“叠置”或“不叠置”时，输入设施点的所有字段都包含在输出面中。 输入设备点的 ObjectID 字段会传递到输出面的 FacilityOID 字段中。</para>
		/// <para>Breaks</para>
		/// <para>指定基于每个设施点计算的服务区范围。</para>
		/// <para>此属性允许您为每个设施点指定不同服务区中断值。 例如，对于两个设施点，您可以为其中一个设施点生成 5 和 10 分钟服务区，为另一个设施点生成 6、9 和 12 分钟服务区。</para>
		/// <para>使用空格分隔多个中断值，使用点字符作为小数分隔符指定数值，即使计算机的区域设置定义了其他小数分隔符也是如此。 例如，值 5.5 10 15.5 用于指定设施点周围的三个中断值。</para>
		/// <para>AdditionalTime</para>
		/// <para>在设施点花费的时间量，可缩减针对给定设施点计算的服务区范围。 默认值为 0。</para>
		/// <para>例如，在计算表示消防站响应时间的服务区时，AdditionalTime 中可以存储每个消防站的出动时间，该时间为消防员配带好适当的防护设备并离开消防站所用的时间。 假设“消防站 1”的出动时间为 1 分钟，“消防站 2”的出动时间为 3 分钟。 如果分别计算这两个消防站的 5 分钟服务区，则“消防站 1”的实际服务区相当于 4 分钟服务区的范围（因为在这 5 分钟里需要 1 分钟的出动时间）。 同样，“消防站 2”的服务区距离消防站仅为 2 分钟。</para>
		/// <para>AdditionalDistance</para>
		/// <para>在计算服务之前，为到达设施点所行驶的额外距离。 此属性可缩减针对给定设施点计算的服务区的范围。 默认值为 0。</para>
		/// <para>通常，设施点的位置（例如门店地点）并不是恰好位于街道上，而是位于道路的后方。 该属性值可用于构建实际设施点位置与其在街道上的位置之间的距离，如有必要，可在计算设施点的服务区时包括此段距离。</para>
		/// <para>AdditionalCost</para>
		/// <para>在设施点花费的额外成本，可缩减针对给定设施点计算的服务区范围。 默认值为 0。</para>
		/// <para>当分析的出行模式使用不基于时间也不基于距离的阻抗属性时，使用此属性值。属性值的单位将理解为未知单位。</para>
		/// <para>CurbApproach</para>
		/// <para>指定车辆到达和离开设施点的方向。 该字段值可指定为以下整数之一（请使用数值代码而非括号中的名称）：</para>
		/// <para>0（车辆的任意一侧）- 车辆可从任一方向到达和离开设施点，因此设施点处允许 U 形转弯。 如果车辆有可能要在设施点处调头，则可以选择该设置。 此决策可能取决于道路的宽度以及交通量，或者该设施点是否有停车场能让车辆驶入并调头。</para>
		/// <para>1（车辆的右侧）- 当车辆到达和离开设施点时，路边必须在车辆右侧。 禁止 U 形转弯。 通常用于必须在右侧停靠的车辆（如公共汽车）。</para>
		/// <para>2（车辆的左侧）- 当车辆到达和离开设施点时，路边必须在车辆左侧。 禁止 U 形转弯。 通常用于必须在左侧停靠的车辆（如公共汽车）。</para>
		/// <para>3（禁止 U 形转弯）- 当车辆到达设施点时，路边可在车辆的任意一侧；但是，车辆在离开时不得调头。</para>
		/// <para>CurbApproach 属性是专为使用以下两种国家驾驶标准而设计的：右侧通行（美国）和左侧通行（英国）。 首先，考虑位于车辆左侧的设施点。 不管车辆行驶在左车道还是右车道，停靠点始终位于车辆的左侧。 不同国家的驾驶标准可能会要求您从这两种方向中的其中一个接近设施点；即只能从车辆的右侧或左侧接近设施点。 例如，如果要到达一个设施点并且在车辆与设施点之间不存在其他交通车道，在美国应该选择 1（车辆的右侧），而在英国应该选择 2（车辆的左侧）。</para>
		/// <para>Bearing</para>
		/// <para>点移动的方向。 单位为度，从正北开始沿顺时针方向进行测量。 该字段与 BearingTol 字段结合使用。</para>
		/// <para>方位角数据通常会从配有 GPS 接收器的移动设备自动发送。 如果正在加载移动输入位置（例如行人或车辆），请尝试包括方位角数据。</para>
		/// <para>使用该字段可以防止将位置添加到错误的边上，例如，车辆刚好在交叉路口或天桥附近时。 方位角也可帮助工具确定点在街道的哪一边上。</para>
		/// <para>BearingTol</para>
		/// <para>使用 Bearing 字段在边上定位移动点时，方位角容差值将创建一个可接受方位角值的范围。 如果 Bearing 字段值在可接受值范围（由边上的方位角容差生成）内，则可以将该点作为网络位置添加在此处，否则，将计算下一个最近边上的最近点。</para>
		/// <para>单位为度，默认值为 30。 值必须大于 0 且小于 180。 值为 30 表示，Network Analyst 尝试在边上添加网络位置时，在边的每一侧（左侧和右侧）的两个数字化方向上都将生成一个 15 度的可接受方位角值。</para>
		/// <para>NavLatency</para>
		/// <para>如果 Bearing 和 BearingTol 也具有值，则该字段只在求解过程中使用；但是，即使当 Bearing 和 BearingTolNavLatency 字段中有值时，NavLatency 值的输入也是可选的。NavLatency 表示 GPS 信息从移动的车辆上发送到服务器以及车辆导航设备接收到处理后路径这两个时刻之间预期要花费的成本。</para>
		/// <para>NavLatency 的单位与阻抗属性的单位相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Facilities { get; set; }

		/// <summary>
		/// <para>Break Values</para>
		/// <para>指定为每个设施点生成的服务区面的大小和数量。 单位由“中断单位”值决定。</para>
		/// <para>可以设置多个面中断来为每个设施点创建同心服务区。 例如，要查找每个设施点的 2 英里、3 英里及 5 英里服务区，请输入 2 3 5，各个数值之间用空格进行分隔，将设置“中断单位”设置为“英里”。 所指定中断值的数量没有限制。</para>
		/// <para>最大中断值的大小不能超过 300 分钟或 300 英里（482.80 千米）。 当生成详细面时，最大服务区大小限制为 15 分钟和 15 英里（24.14 千米）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object BreakValues { get; set; } = "5 10 15";

		/// <summary>
		/// <para>Break Units</para>
		/// <para>指定中断值参数的单位。</para>
		/// <para>此参数单位的选择决定了工具通过测量行驶距离还是行驶时间来创建服务区。 选择时间单位以测量行驶时间。 要测量行驶距离，则请选择距离单位。 选择的单位还确定工具在结果中报告总行驶时间或距离时采用的单位。</para>
		/// <para>具体选项如下：</para>
		/// <para>米—线性单位为米。</para>
		/// <para>千米—线性单位为千米。</para>
		/// <para>英尺—线性单位为英尺。</para>
		/// <para>码—线性单位为码。</para>
		/// <para>英里—线性单位为英里。</para>
		/// <para>海里—线性单位为海里。</para>
		/// <para>秒—时间单位为秒。</para>
		/// <para>分—时间单位为分钟。</para>
		/// <para>小时—时间单位为小时。</para>
		/// <para>天—时间单位为天。</para>
		/// <para><see cref="BreakUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BreakUnits { get; set; } = "Minutes";

		/// <summary>
		/// <para>Analysis Region</para>
		/// <para>将在其中执行分析的区域。 如果未对此参数指定值，工具会基于输入点的位置自动计算区域名称。 仅当自动检测的区域名称输入不准确时，才需要设置区域名称。</para>
		/// <para>要指定区域，请使用以下值之一：</para>
		/// <para>欧洲—分析区域为欧洲。</para>
		/// <para>日本—分析区域为日本。</para>
		/// <para>韩国—分析区域为韩国。</para>
		/// <para>中东和非洲—分析区域为中东和非洲。</para>
		/// <para>北美—分析区域为北美洲。</para>
		/// <para>南美洲—分析区域为南美。</para>
		/// <para>南亚—分析区域为南亚。</para>
		/// <para>泰国—分析区域为泰国。</para>
		/// <para>不再支持以下区域名称，且将在未来版本中删除这些名称。 如果您指定了任一已弃用的区域名称，则工具会自动为您所在的区域分配支持的区域名称。</para>
		/// <para>希腊将重定向到欧洲</para>
		/// <para>印度将重定向到南亚</para>
		/// <para>大洋洲将重定向到南亚</para>
		/// <para>东南亚将重定向到南亚</para>
		/// <para>台湾将重定向到南亚</para>
		/// <para><see cref="AnalysisRegionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Analysis")]
		public object? AnalysisRegion { get; set; }

		/// <summary>
		/// <para>Travel Direction</para>
		/// <para>指定用于生成服务区面的行程方向是朝向还是远离设施点。</para>
		/// <para>离开设施点—在远离设施点的方向上生成服务区。</para>
		/// <para>朝向设施点—在朝向设施点的方向上创建服务区。</para>
		/// <para>行程方向可以改变面的形状，因为街道两侧的阻抗可能不同，或者可能存在单向约束，例如单行道。 方向的选择取决于服务区分析的特性。 例如，应该在远离设施点的方向上创建比萨外卖店的服务区，而医院的服务区应该创建在朝向设施点的方向上。</para>
		/// <para><see cref="TravelDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Analysis")]
		public object? TravelDirection { get; set; } = "Away From Facility";

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>离开或到达设施点的时间。 对该值的解释取决于行驶方向是朝向设施点还是远离设施点。</para>
		/// <para>如果将行驶方向设置为远离设施点，则此值表示离开时间。</para>
		/// <para>如果将行驶方向设为朝向设施点，则此值表示到达时间。</para>
		/// <para>可以使用时间的时区参数指定该时间和日期是参考 UTC 还是设施点或事件点所在时区。</para>
		/// <para>通过重复求解同一分析，但使用不同的时间值，可查看设施点的到达时间随时间的变化。 例如，消防站周围的 5 分钟服务区在大清早时可能变得大一点，而在早高峰期消失，上午晚些时候服务区又扩大，并在一天中都保持这样。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Advanced Analysis")]
		public object? TimeOfDay { get; set; }

		/// <summary>
		/// <para>Use Hierarchy</para>
		/// <para>指定是否将在查找设施点和事件点之间的最佳路径时使用等级。</para>
		/// <para>选中 (True) - 将在分析中使用等级。 使用等级的结果是，求解程序更偏好高等级的边而不是低等级的边。 分等级求解的速度更快，并且可用于模拟驾驶员在可能的情况下选择在高速公路而非地方道路上行驶（即使行程可能更远）的偏好。</para>
		/// <para>未选中 (False) - 不会在分析中使用等级。 如果不使用等级属性，则会沿网络数据集的所有边进行测量以生成准确的服务区（无论等级级别如何）。</para>
		/// <para>无论是否选中应用等级参数 (True)，当最大中断值超过 240 分钟或 240 英里（386.24 千米）时，将始终使用等级。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Custom Travel Mode")]
		public object? UseHierarchy { get; set; } = "false";

		/// <summary>
		/// <para>UTurn at Junctions</para>
		/// <para>执行是限制还是允许服务区在交汇点处进行 U 形转弯。 为理解这些参数值，请考虑下列术语：交汇点是在路段的尽头且可能与其他一条或多条路段相连的点；伪交汇点是指两条街道确实在此处相连的点；交叉点是指三条或更多街道在此处相连的点；死角是指一条不与其他路段相连的路段的尽头。</para>
		/// <para>允许—无论在交汇点处有几条连接的边，均允许 U 形转弯。 这是默认值。</para>
		/// <para>不允许—在所有交汇点处均禁止 U 形转弯，不管交汇点原子价如何。 不过请注意，即使已选择该选项，在网络位置仍允许 U 形转弯；但是也可以通过设置个别网络位置的 CurbApproach 属性来禁止 U 形转弯。</para>
		/// <para>仅在死角处允许—除仅有一条相邻边的交汇点（死角）外，其他交汇点均禁止 U 形转弯。</para>
		/// <para>仅在交点和死角处允许—在恰好有两条相邻边相遇的交汇点处禁止 U 形转弯，但是交叉点（三条或三条以上相邻边的交汇点）和死角（仅有一条相邻边的交汇点）处允许。 通常，网络在路段中间有多余的交汇点。 此选项可防止车辆在这些位置掉头。</para>
		/// <para><see cref="UturnAtJunctionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object? UturnAtJunctions { get; set; } = "Allowed Only at Intersections and Dead Ends";

		/// <summary>
		/// <para>Geometry at Overlaps</para>
		/// <para>指定当分析中存在多个设施点时生成服务区面的方式。</para>
		/// <para>叠置—将为每个设施点创建单独的面。 这些面可以相互叠置。 这是默认设置。</para>
		/// <para>不叠置—将创建单独的面，使得某个设施点的面无法与其他设施点的面叠置。 网络的任何部分都只能由最近设施点的服务区覆盖。</para>
		/// <para>按中断值合并—将创建并连接具有相同中断值的不同设施点的面。</para>
		/// <para>在使用“叠置”或“非叠置”时，输入设施点的所有字段都包含在输出面中（输入 ObjectID 字段中的值传递到输出面的 FacilityOID 字段这种情况除外）。 按中断值合并时 FacilityOID 字段为空，输入字段不包含在输出中。</para>
		/// <para><see cref="PolygonsForMultipleFacilitiesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object? PolygonsForMultipleFacilities { get; set; } = "Overlapping";

		/// <summary>
		/// <para>Geometry at Cutoffs</para>
		/// <para>指定是否将同心服务区面创建为圆盘或圆环。 仅当为设施点指定了多个中断值时，此选项才适用。</para>
		/// <para>圆环—代表中断值较大的面，可排除中断值较小的面。 这将在连续的中断之间创建面。 请使用此选项查找从一个中断到另一个中断的区域。 例如，如果创建 5 分钟和 10 分钟服务区，则 10 分钟服务区面将排除 5 分钟服务区面内的区域。 这是默认设置。</para>
		/// <para>圆盘—在设施点与休息点之间创建面。 例如，如果创建 5 分钟和 10 分钟服务区，则 10 分钟服务区面将包含 5 分钟服务区面内的区域。</para>
		/// <para><see cref="PolygonOverlapTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object? PolygonOverlapType { get; set; } = "Rings";

		/// <summary>
		/// <para>Detailed Polygons</para>
		/// <para>不推荐使用此参数。 要生成详细面，请将面细节参数值设置为高。</para>
		/// <para>指定用于创建详细面或概化面的选项。</para>
		/// <para>未选中 (False) - 将创建概化面，生成速度快且相当准确。 这是默认设置。</para>
		/// <para>选中 (True) - 将创建详细面，以对服务区线进行精确建模并且可包含未到达的区域岛。 这种面比概化面的生成速度慢得多。 使用等级时，不支持此选项。</para>
		/// <para>仅当中断值参数内指定的最大值小于或等于 15 分钟或 15 英里（24.14 千米）时，工具才会支持生成详细面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Output")]
		public object? DetailedPolygons { get; set; } = "false";

		/// <summary>
		/// <para>Polygon Trim Distance</para>
		/// <para>将对服务区面进行修剪的距离范围。 当您在街道网络稀疏的地点查找服务区且不需要服务区覆盖大片没有街道要素的区域时，此选项很有用。</para>
		/// <para>默认值是 100 米。 此参数没有值或值为 0 时，会指定将不对服务区面进行修剪。 使用等级时，将忽略此参数值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Output")]
		public object? PolygonTrimDistance { get; set; } = "100 Meters";

		/// <summary>
		/// <para>Polygon Simplification Tolerance</para>
		/// <para>简化面几何时依据的数量。</para>
		/// <para>简化仍将保留面的关键折点，以定义面的基本形状和移除其他折点。 所指定的简化距离为简化面边界可偏离原始面边界的最大偏移。 对面进行简化将减少折点的数量，并且往往能够减少绘制时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Custom Travel Mode")]
		public object? PolygonSimplificationTolerance { get; set; } = "10 Meters";

		/// <summary>
		/// <para>Point Barriers</para>
		/// <para>使用此参数可指定一个或多个点作为临时限制，或表示在基础街道上行驶可能需要的附加时间或距离。 例如，点障碍可用来显示一棵沿街倒下的树或是铁路道口上的时间延迟。</para>
		/// <para>工具限制了可添加为障碍的点不得超过 250 个。</para>
		/// <para>指定点障碍后，可通过使用以下属性为每个事件点设置属性，例如其名称或障碍类型：</para>
		/// <para>Name</para>
		/// <para>障碍名称。</para>
		/// <para>BarrierType</para>
		/// <para>指定点障碍是完全限制通行还是增加通过障碍时的时间或距离。 此特性值可指定为以下整数之一（请使用数值代码而非括号中的名称）：</para>
		/// <para>0（限制型）- 禁止穿过障碍。 此障碍称为限制型点障碍，因为它作为限制使用。</para>
		/// <para>2（增加成本型）- 穿过此障碍会增加通过 Additional_Time、Additional_Distance 或 AdditionalCost 字段指定的行驶时间或行驶距离的数值。 此障碍类型称为增加成本型点障碍。</para>
		/// <para>Additional_Time</para>
		/// <para>穿越障碍时增加的行驶时间。 此字段仅适用于增加成本型障碍，且仅在测量单位参数值基于时间时适用。</para>
		/// <para>此字段值必须大于或等于零，并且其单位必须与在测量单位参数中指定的单位相同。</para>
		/// <para>Additional_Distance</para>
		/// <para>穿越障碍时增加的距离。 此字段仅适用于增加成本型障碍，且仅在测量单位参数值基于距离时适用。</para>
		/// <para>该字段值必须大于或等于零，并且其单位必须与在测量单位参数中指定的单位相同。</para>
		/// <para>AdditionalCost</para>
		/// <para>穿越障碍时增加的成本。 当测量单位参数值不基于时间或距离时，此字段仅适用于增加成本型障碍。</para>
		/// <para>FullEdge</para>
		/// <para>指定分析期间如何将限制点障碍应用于边元素。 该字段值可指定为以下整数之一（请使用数值代码而非括号中的名称）：</para>
		/// <para>0 (False) - 允许沿边行进到障碍，但不允许穿过障碍。 这是默认值。</para>
		/// <para>1 (True) - 禁止沿关联边的任何位置行进。</para>
		/// <para>CurbApproach</para>
		/// <para>指定受障碍影响的行驶方向。 该字段值可指定为以下整数之一（请使用数值代码而非括号中的名称）：</para>
		/// <para>0（车辆的任一侧）- 障碍将影响在边左右两个方向上行驶的车辆。</para>
		/// <para>1（车辆右侧）- 只会影响车辆的右行方向（障碍位于车辆左侧）。 在同一条边上行驶但从左侧接近障碍的车辆不会受到障碍的影响。</para>
		/// <para>2（车辆左侧）- 只会影响车辆的左行方向（障碍位于车辆左侧）。 在同一条边上行驶但从右侧接近障碍的车辆不会受到障碍的影响。</para>
		/// <para>由于交汇点是点且不分左右侧，所以无论路边通道如何设置，交汇点上的障碍都会影响所有车辆。</para>
		/// <para>CurbApproach 属性适用于以下两种国家驾驶标准：右侧通行（美国）和左侧通行（英国）。 首先，考虑位于车辆左侧的设施点。 不管车辆行驶在左车道还是右车道，停靠点始终位于车辆的左侧。 不同国家的驾驶标准可能会要求您从这两种方向中的其中一个接近设施点，也就是说，只能从车辆的右侧或左侧接近设施点。 例如，要到达一个设施点并且在车辆与设施点之间不存在其他交通车道，应在美国请选择 1（车辆的右侧），而在英国请选择 2（车辆的左侧）。</para>
		/// <para>Bearing</para>
		/// <para>点移动的方向。 单位为度，从正北开始沿顺时针方向进行测量。 该字段与 BearingTol 字段结合使用。</para>
		/// <para>方位角数据通常会从配有 GPS 接收器的移动设备自动发送。 如果正在加载移动输入位置（例如行人或车辆），请尝试包括方位角数据。</para>
		/// <para>使用该字段可以防止将位置添加到错误的边上，例如，车辆刚好在交叉路口或天桥附近时。 方位角也可帮助工具确定点在街道的哪一边上。</para>
		/// <para>BearingTol</para>
		/// <para>使用 Bearing 字段在边上定位移动点时，方位角容差值将创建一个可接受方位角值的范围。 如果 Bearing 字段值在可接受值范围（由边上的方位角容差生成）内，则可以将该点作为网络位置添加在此处，否则，将计算下一个最近边上的最近点。</para>
		/// <para>单位为度，默认值为 30。 值必须大于 0 且小于 180。 值为 30 表示，Network Analyst 尝试在边上添加网络位置时，在边的每一侧（左侧和右侧）的两个数字化方向上都将生成一个 15 度的可接受方位角值。</para>
		/// <para>NavLatency</para>
		/// <para>如果 Bearing 和 BearingTol 也具有值，则该字段只在求解过程中使用；但是，即使当 Bearing 和 BearingTolNavLatency 字段中有值时，NavLatency 值的输入也是可选的。NavLatency 表示 GPS 信息从移动的车辆上发送到服务器以及车辆导航设备接收到处理后路径这两个时刻之间预期要花费的成本。</para>
		/// <para>NavLatency 的单位与阻抗属性的单位相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[Category("Barriers")]
		public object? PointBarriers { get; set; }

		/// <summary>
		/// <para>Line Barriers</para>
		/// <para>使用此参数可指定一条或多条线，用于禁止在线与街道相交的位置通行。 例如，线障碍可用于对阻塞若干个路段交通的游行或抗议队伍进行建模。 线障碍还可隔离多条道路以禁止进行遍历，从而在可能的路径中去除不符合要求的街道网络部分。</para>
		/// <para>该工具限制了您可以使用线障碍参数限制的街道数量。 可指定为线障碍的线数没有限制时，所有线的相交街道的合并数不能超过 500。</para>
		/// <para>指定线障碍时，可以使用以下属性为每个障碍设置名称和障碍类型属性：</para>
		/// <para>Name</para>
		/// <para>障碍名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[Category("Barriers")]
		public object? LineBarriers { get; set; }

		/// <summary>
		/// <para>Polygon Barriers</para>
		/// <para>使用此参数可指定面，用于完全限制通行或按比例调整行驶在面相交的街道上所需的行驶时间或距离。</para>
		/// <para>该操作限制了您可以使用面障碍参数限制的街道数量。 可指定为面障碍的面数没有限制时，所有面的相交街道的合并数不能超过 2,000。</para>
		/// <para>指定面障碍时，可通过使用以下属性为每个面障碍设置属性，例如名称或障碍类型：</para>
		/// <para>Name</para>
		/// <para>障碍名称。</para>
		/// <para>BarrierType</para>
		/// <para>指定障碍是完全禁止通行还是按比例调整穿过成本（例如时间或距离）。 该字段值可指定为以下整数之一（请使用数值代码而非括号中的名称）：</para>
		/// <para>0（限制型）- 禁止穿过障碍的任何部分。 此障碍称作限制型面障碍，因为它禁止在与障碍相交的街道上行驶。 此类障碍的一个具体应用是对覆盖街道中某些区域且导致街道无法通行的洪水进行建模。</para>
		/// <para>1（按比例调整成本型）- 根据使用 ScaledTimeFactor 或 ScaledDistanceFactor 字段指定的系数，按比例调整在基础街道上行驶所需的成本（例如行驶时间或距离）。 如果障碍部分覆盖了街道，则会按比例调整行驶时间或行驶距离。 例如，系数 0.25 表示在基础街道上行进的速度是正常速度的四倍。 系数 3.0 表示预期在基础街道上行进相同距离所花费的时间为正常值的三倍。 此障碍类型称为调整成本型面障碍。 例如，可使用该障碍对导致特定区域的行进速度减慢的暴风雨进行建模。</para>
		/// <para>ScaledTimeFactor</para>
		/// <para>它是与障碍相交街道的行驶时间要乘以的因子。 该字段值必须大于零。</para>
		/// <para>此字段仅适用于按比例调整成本型障碍且仅在测量单位参数基于时间时适用。</para>
		/// <para>ScaledDistanceFactor</para>
		/// <para>它是与障碍相交街道的距离要乘以的因子。 该字段值必须大于零。</para>
		/// <para>此字段仅适用于按比例调整成本型障碍且仅在测量单位参数基于距离时适用。</para>
		/// <para>ScaledCostFactor</para>
		/// <para>这是与障碍相交的街道的成本要乘以的系数。 该字段值必须大于零。</para>
		/// <para>此字段仅适用于按比例调整成本型障碍且仅在测量单位参数既不基于时间也不基于距离时适用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[Category("Barriers")]
		public object? PolygonBarriers { get; set; }

		/// <summary>
		/// <para>Restrictions</para>
		/// <para>确定服务区时工具将遵从的行驶限制。</para>
		/// <para>限制表示行驶偏好或要求。 大多数情况下，限制条件会导致道路禁行。 例如，使用“避开收费公路”限制的结果是，仅在访问某一事件点或设施点需要借道收费公路时，才会生成一条包含该收费公路的路径。 高度限制则使您可以绕开低于车辆高度的间隙。 如果车辆上装载着腐蚀性物质，使用“禁止任何危险物品”限制将防止在标记着运输腐蚀性材料为非法行为的路上运输这些材料。</para>
		/// <para>除非将出行模式设置为自定义，否则会忽略您为此参数提供的值。</para>
		/// <para>某些限制需要指定一个额外值以供它们使用。 该值必须与限制名称和用于限制的特定参数相关联。 可识别名称在属性参数值参数的 AttributeName 列中显示的限制。 在查找可遍历道路时，要正确使用限制，请指定属性参数值参数的 ParameterValue 字段。</para>
		/// <para>有些限制仅适用于某些国家/地区；下表按区域显示了这些限制的可用性。 关于在某区域内可用性有限的限制，通过在网络分析覆盖范围上查看“国家/地区列表”部分中的表，可以确定该限制在特定国家/地区是否可用。 如果一个国家/地区具有 Logistics Attribute 列的 Yes 值，则该国家/地区支持具有区域可选性的限制。 如果您指定的限制名称在事件点所在的国家/地区不可用，该服务会忽略无效限制。 该服务还会忽略约束条件用法属性参数值为 0 到 1（请参阅属性参数值参数）时的约束条件。 它会禁止约束条件用法参数值大于 0 时的所有约束条件。</para>
		/// <para>该工具支持以下约束条件：</para>
		/// <para>禁止任何危险物品—结果将不包含禁止运输任何危险类型材料的道路。可用性：在北美洲及欧洲选择国家</para>
		/// <para>避开拼车道路—结果将避开专供拼车（高承载）车辆行使的道路。可用性：所有国家</para>
		/// <para>避开快速车道—结果将避开指定为快速车道的道路。可用性：所有国家</para>
		/// <para>避开轮渡—结果将避开轮渡。可用性：所有国家</para>
		/// <para>避开关口—结果将避开存在关键通道或守卫控制入口等关口的道路。可用性：所有国家</para>
		/// <para>避开限行道路—结果将避开限制进入高速公路的道路。可用性：所有国家</para>
		/// <para>避开私家道路—结果将避开非公有和维护的道路。可用性：所有国家</para>
		/// <para>避开不适合行人的道路—结果将避开不适合行人的道路。可用性：所有国家</para>
		/// <para>避开楼梯—结果将避开行人适合路线上的所有楼梯。可用性：所有国家</para>
		/// <para>避开收费公路—结果将避开汽车收费公路。可用性：所有国家</para>
		/// <para>避开卡车收费公路—结果将避开卡车收费公路。可用性：所有国家</para>
		/// <para>避开货车禁行道路—结果将避开禁止货车通行的道路，除非正在进行配送。可用性：所有国家</para>
		/// <para>避开未铺设道路—结果将避开未铺设（例如，泥土、砾石等）的道路。可用性：所有国家</para>
		/// <para>轴计数限制—结果将不包含具有指定轴数的卡车禁行的道路。 可使用车轴数限制参数指定车轴数。可用性：在北美洲及欧洲选择国家</para>
		/// <para>驾驶公共汽车—结果将不包含公共汽车禁行的道路。 使用此约束条件还将确保结果支持单行道。可用性：所有国家</para>
		/// <para>驾驶出租车—结果将不包含出租车禁行的道路。 使用此约束条件还将确保结果支持单行道。可用性：所有国家</para>
		/// <para>驾驶货车—结果将不包含卡车禁行的道路。 使用此约束条件还将确保结果支持单行道。可用性：所有国家</para>
		/// <para>驾驶汽车—结果将不包含汽车禁行的道路。 使用此约束条件还将确保结果支持单行道。可用性：所有国家</para>
		/// <para>驾驶急救车辆—结果将不包含急救车辆禁行的道路。 使用此约束条件还将确保结果支持单行道。可用性：所有国家</para>
		/// <para>高度限制—结果将不包含车辆高度超出道路所允许的最大高度的道路。 可使用“车辆高度（米）”限制参数指定车辆高度。可用性：在北美洲及欧洲选择国家</para>
		/// <para>主销到后轴长度限制—结果将不包含车辆长度超出路上所有货车所允许的主销到后轴最大长度的道路。 可使用“车辆主销到后轴长度（米）”限制参数指定车辆中心立轴与后轴之间的长度。可用性：在北美洲及欧洲选择国家</para>
		/// <para>长度限制—结果将不包含车辆长度超出道路所允许的最大长度的道路。 可使用“车辆长度（单位为米）”限制参数指定车辆长度。可用性：在北美洲及欧洲选择国家</para>
		/// <para>行人首选—结果将使用适合行人导航的首选路线。可用性：在北美洲及欧洲选择国家</para>
		/// <para>骑摩托车—结果将不包含摩托车禁行的道路。 使用此约束条件还将确保结果支持单行道。可用性：所有国家</para>
		/// <para>禁止在建道路—结果将不包含在建道路。可用性：所有国家</para>
		/// <para>禁止带有一个或多个拖车的半挂车或牵引车—结果将不包含带有一个或多个拖车的半挂车或牵引车禁行的道路。可用性：在北美洲及欧洲选择国家</para>
		/// <para>禁止单轴车辆—结果将不包含单轴车辆禁行的道路。可用性：在北美洲及欧洲选择国家</para>
		/// <para>禁止双轴车辆—结果将不包含双轴车辆禁行的道路。可用性：在北美洲及欧洲选择国家</para>
		/// <para>禁止过境交通—结果将不包含禁止过境交通（非本地）的道路。可用性：所有国家</para>
		/// <para>带拖车的卡车限制—结果将不包含具有指定拖车数量的货车禁行的道路。 可使用“卡车上的拖车数量”限制参数指定卡车的拖车数量。可用性：在北美洲及欧洲选择国家</para>
		/// <para>使用首选危险物品路径—结果将优先选择专用于运输危险类型材料的道路。可用性：在北美洲及欧洲选择国家</para>
		/// <para>使用首选卡车路径—结果将优先选择指定为卡车路径的道路，例如，由美国的《国家地面交通援助法案》指定为国家网络的一部分的道路，由州或省指定为卡车路径的道路，或在某区域内驾驶卡车的首选道路。可用性：在北美洲及欧洲选择国家</para>
		/// <para>步行—结果将不包含行人禁行的道路。可用性：所有国家</para>
		/// <para>重量限制—结果将不包含车辆重量超出道路所允许的最大重量的道路。 可使用“车辆重量（千克）”限制参数指定车辆重量。可用性：在北美洲及欧洲选择国家</para>
		/// <para>轴负重限制—结果将不包含车辆轴负重超出道路所允许的最大轴负重的道路。 可使用“车辆轴负重（千克）”限制参数指定车辆轴负量。可用性：在北美洲及欧洲选择国家</para>
		/// <para>宽度限制—结果将不包含车辆宽度超出道路所允许的最大宽度的道路。 可使用“车辆宽度（单位为米）”限制参数指定车辆宽度。可用性：在北美洲及欧洲选择国家</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object? Restrictions { get; set; } = "'Avoid Carpool Roads';'Avoid Express Lanes';'Avoid Gates';'Avoid Private Roads';'Avoid Unpaved Roads';'Driving an Automobile';'Roads Under Construction Prohibited';'Through Traffic Prohibited'";

		/// <summary>
		/// <para>Attribute Parameter Values</para>
		/// <para>使用此参数可指定属性或限制条件所需的其他值，例如，指定限制对在受限道路上行驶是禁止、避免还是首选。 如果该限制要避免或首选道路，您可以使用此参数进一步指定要避免或首选的程度。 例如，您可以选择从不使用收费公路，尽可能的避开它们，或倾向于它们。</para>
		/// <para>除非将出行模式设置为自定义，否则会忽略您为此参数提供的值。</para>
		/// <para>如果指定了要素类的属性参数值参数，则要素类上的字段名称必须与如下所示字段相匹配：</para>
		/// <para>AttributeName- 限制的名称。</para>
		/// <para>ParameterName- 与限制关联的参数名称。 限制根据其用途可具有一个或多个 ParameterName 字段值。</para>
		/// <para>ParameterValue- 工具在评估限制时使用的 ParameterName 的值。</para>
		/// <para>属性参数值参数取决于限制参数。 仅当限制名称指定为限制参数值时，ParameterValue 字段才适用。</para>
		/// <para>在属性参数值中，每个限制（以 AttributeName 形式列出）具有一个 ParameterName 字段值，指定限制的行程是禁止、避免还是首选的限制用法与道路选择避免或首选的限制和程度相关联。 可为限制用法 ParameterName 分配下列字符串值，或在括号内列出等效数值：</para>
		/// <para>PROHIBITED (-1) - 完全禁止在使用限制的道路上行驶。</para>
		/// <para>AVOID_HIGH (5) - 极不可能将工具包括在与限制相关的道路中。</para>
		/// <para>AVOID_MEDIUM (2) - 不太可能将工具包括在与限制相关的道路中。</para>
		/// <para>AVOID_LOW (1.3) - 一定程度上不太可能将工具包括在与限制相关的道路中。</para>
		/// <para>PREFER_LOW (0.8) - 一定程度上有可能将工具包括在与限制相关的道路中。</para>
		/// <para>PREFER_MEDIUM (0.5) - 有可能将工具包括在与限制相关的道路中。</para>
		/// <para>PREFER_HIGH (0.2) - 极有可能将工具包括在与限制相关的道路中。</para>
		/// <para>大多数情况下，如果约束条件取决于车辆特征（如车辆高度），则可以使用默认值 PROHIBITED 作为“约束条件用法”值。 但是在某些情况下，“限制用法”的值取决于您的路径偏好。 例如，“避开收费公路”限制具有“限制用法”属性的默认值 AVOID_MEDIUM。 这表示在使用限制时，在可能的情况下工具将绕开收费公路。 AVOID_MEDIUM 也表示查找最佳路径时避开收费公路的重要性，即优先级为中等。 选择 AVOID_LOW 会降低避开收费公路的重要性；而选择 AVOID_HIGH 则会增加其重要性，并且操作为避开收费公路而生成更长的路径时更容易为人所接受。 选择 PROHIBITED 则会完全不允许在收费公路上行驶，因此路径不可能经过收费公路的所有部分。 但是请注意，避开或禁止收费公路以及避开公路通行费只是一部分人的目的。 对另外一部分人来说，因为避开拥堵的交通比交一些公路通行费更为重要，会宁愿走收费公路。 在后一种情况中，您可以选择 PREFER_LOW、PREFER_MEDIUM 或 PREFER_HIGH 作为“限制用法”的值。 首选的等级越高，工具在与限制相关的道路上行驶的距离越远。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRecordSet()]
		[Category("Custom Travel Mode")]
		public object? AttributeParameterValues { get; set; }

		/// <summary>
		/// <para>Time Zone for Time of Day</para>
		/// <para>指定时区或时间参数的时区。</para>
		/// <para>本地地理位置—时间参数是指设施点所处的时区或区域。 服务区开始时间或结束时间的时区交错。 将时间设为 9:00 AM，为时间的时区选择“本地地理位置”，然后进行求解，将为处于东部时区的所有设施点生成东部时间 9:00 a.m. 的服务区、为处于中部时区的设施点生成中部时间 9:00 a.m. 的服务区、为处于山区时区的设施点生成山区时间 9:00 a.m. 的服务区等等。如果商店处于覆盖美国、在当地时间 9:00 a.m. 开业的商店链中，则可以在一次求解中选择此参数值来查找处于所有商店开业时间的市场地区。 首先，东部时区的商店开业并生成一个面，一小时后中部时区的商店开业，以此类推。 当地时间始终为 9 点，但却因不同时区而实时交错。</para>
		/// <para>UTC—时间参数是指协调世界时间 (UTC)。 无论各设施点处于哪个时区都会同时到达或出发。将时间设为 2:00 PM，选择 UTC，然后进行求解，将为处于东部时区的所有设施点生成东部标准时间 9:00 a.m. 的服务区、为处于中部时区的设施点生成中部标准时间 8:00 a.m. 的服务区、为处于山地时区的设施点生成山地标准时间 7:00 a.m. 的服务区，等等。以上情况均假定为标准时间。 在夏令时期间，东部、中部、和山地时间应各提前 1 小时（即分别为 10:00 a.m.、9:00 a.m. 和 8:00 a.m.）。UTC 选项可用于为跨两个时区的管辖区显示紧急响应范围。 将急救车辆加载为设施点。 将时间参数设置为 UTC 的当前时间。 （您需要确定当前 UTC 时间和日期，以便正确使用此选项。）设置其他属性，并对分析进行求解。 尽管时区边界会分割车辆，但结果仍将显示当前交通状况下可以到达的区域。 也可对其他时间使用相同的过程，而不仅是当前时间。</para>
		/// <para>无论时间的时区如何设置，当时间为非空值并且多个设施点的面设置为创建合并或非重叠面时，所有设施点必须处于同一时区。</para>
		/// <para><see cref="TimeZoneForTimeOfDayEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Analysis")]
		public object? TimeZoneForTimeOfDay { get; set; } = "Geographically Local";

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>用于在分析中建模的交通模式。 出行模式在 ArcGIS Online 中进行管理，组织管理员可通过对其进行配置，以反映组织工作流。 指定组织所支持的出行模式名称。</para>
		/// <para>要获取受支持的出行模式名称列表，请运行获取出行模式工具，该工具位于访问工具所使用的同一 GIS Server 连接下的实用程序工具箱中。 获取出行模式工具会将表“支持的出行模式”添加到应用程序中。 可将“支持的出行模式”表中 Travel Mode Name 字段的任何值指定为输入。 您还可以将 Travel Mode Settings 字段中的值指定为输入。 由于工具不必根据出行模式名称查找设置，因而加快了工具的执行速度。</para>
		/// <para>默认值，自定义，可以使用自定义出行模式参数（在交汇点处 U 形转弯、应用等级、限制、属性参数值和阻抗）配置您自己的出行模式。 自定义出行模式参数的默认值对使用汽车的出行方式建模。 您还可以选择自定义并设置上述自定义出行模式参数，从而以快速步行速度对行人建模，或以给定高度、重量和特定危险材料货物对卡车建模。 您可以尝试不同的设置以获取所需的分析结果。 一旦确定了分析设置，则可使用组织管理员身份并将这些设置保存为新建或现有出行模式的一部分，以便您组织中的所有人均运行相同设置的分析。</para>
		/// <para>选择自定义后，您为自定义出行模式参数设置的值便会包含在分析中。 指定您组织定义的其他出行模式，将忽略为自定义出行模式参数设置的所有值；该工具将用您所指定的出行模式中的值将其覆盖。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? TravelMode { get; set; } = "Custom";

		/// <summary>
		/// <para>Impedance</para>
		/// <para>指定阻抗，该值表示沿交通网络的路段或其他部分行进所需的精力或成本。</para>
		/// <para>行程时间是一种阻抗，比如，汽车花费 1 分钟沿空无一人的道路行驶一公里。 行程时间会随出行模式的不同而不同（行人可能需要 20 多分钟才能走完一公里），所以在建模时为出行模式选择正确的阻抗非常重要。</para>
		/// <para>行程距离也是一种阻抗，可将以千米表示的道路长度作为阻抗。 从这个意义上，行程距离对所有模式均相同，即对行人而言 1 千米的距离对汽车而言也是 1 千米。 （但不同模式所允许行进的线路可能会有变化，而这会影响两点间的距离，可通过出行模式设置对此进行建模。）</para>
		/// <para>除非将出行模式设置为自定义（这是默认值），否则会忽略您为此参数提供的值。</para>
		/// <para>行驶时间—使用历史和实时流量数据。 此选项适用于在每天的特定时间使用实时流量速度数据（如果适用）对汽车沿道路行驶的时间进行建模。 如果使用 TravelTime，则可以选择设置 TravelTime::车辆最大速度 (km/h) 属性参数来指定车辆能够行驶的速度的物理限制。</para>
		/// <para>分—不使用实时流量数据，而是使用汽车的历史平均速度。</para>
		/// <para>卡车行驶时间—使用历史和实时流量数据，但将速度限制为发布的卡车限速要求。 这有助于模拟卡车在特定时间沿着道路行驶所需的时间。 如果使用 TruckTravelTime，则可以选择设置 TruckTravelTime::车辆最大速度 (km/h) 属性参数来指定卡车能够行驶的速度的物理限制。</para>
		/// <para>卡车分钟—不使用实时流量数据，而是使用汽车历史平均速度的较小值以及发布的卡车限速要求。</para>
		/// <para>步行时间—在所有道路和路径上的默认速度为 5 千米/小时，但可以通过 WalkTime::步行速度 (km/h) 属性参数进行配置。</para>
		/// <para>英里—以英里为单位存储沿道路的长度测量值，可用于基于最短距离执行分析。</para>
		/// <para>千米—以公里为单位存储沿道路的长度测量值，可用于基于最短距离进行分析。</para>
		/// <para>每小时一公里的时间—默认将所有道路和路径上的速度都设为 1 千米/小时。 使用任何属性参数都无法更改速度。</para>
		/// <para>行驶时间—对汽车的行驶时间进行建模。 这些行驶时间是动态的，会随交通数据可用区域的交通流量而波动。 这是默认值。</para>
		/// <para>卡车时间—对卡车的行驶时间进行建模。 这些行驶时间对于每条道路都是静态的，不会随交通流量而波动。</para>
		/// <para>步行时间—对行人的步行时间进行建模。</para>
		/// <para>行驶距离—存储沿道路和路径测得的距离长度。 要对步行距离建模，请选择此选项并确保在限制参数中设置了步行。 同样，若对行驶距离或货运距离建模，则在此处选择行程距离并设置相应限制，以使车辆仅在允许的道路上行进。</para>
		/// <para>如果选择基于时间的阻抗（例如 TravelTime、TruckTravelTime、Minutes、TruckMinutes 或 WalkTime），则必须将中断单位参数设置为基于时间的值；如果您选择基于距离的阻抗（例如 Miles 或 Kilometers），则中断单位必须为基于距离的值。</para>
		/// <para>不再支持行驶时间、卡车时间、步行时间和行驶距离阻抗值，且将在未来版本中删除。 如果您使用上述任一值，则工具将为基于时间的值使用时间阻抗参数，为基于距离的值使用距离阻抗参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object? Impedance { get; set; } = "Drive Time";

		/// <summary>
		/// <para>Save Output Network Analysis Layer</para>
		/// <para>指定是否将分析设置保存为网络分析图层文件。 即使在 ArcGIS Desktop 应用程序（例如 ArcMap）中打开文件，仍然无法直接使用此文件。 需要将其发送至 Esri 技术支持以诊断工具所返回结果的质量。</para>
		/// <para>选中（在 Python 中为 True）- 输出将另存为网络分析图层文件。 文件将下载到计算机上的临时目录中。 在 ArcGIS Pro 中，可以通过查看输出网络分析图层参数值来确定已下载文件的位置，该参数位于与工程地理处理历史中的工具执行相对应的条目中。 在 ArcMap 中，可以通过访问输出网络分析图层参数的快捷菜单中的复制位置选项来确定文件的位置，该参数位于与地理处理结果窗口中的工具执行对应的条目中。</para>
		/// <para>未选中（在 Python 中为 False）- 输出不会另存为网络分析图层文件。 这是默认设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Output")]
		public object? SaveOutputNetworkAnalysisLayer { get; set; } = "false";

		/// <summary>
		/// <para>Overrides</para>
		/// <para>此参数仅供内部使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced Analysis")]
		public object? Overrides { get; set; }

		/// <summary>
		/// <para>Time Impedance</para>
		/// <para>如果使用阻抗参数指定的出行模式阻抗是基于时间的，则时间阻抗和阻抗参数的值必须相同。 否则，操作将返回错误。</para>
		/// <para><see cref="TimeImpedanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object? TimeImpedance { get; set; } = "TravelTime";

		/// <summary>
		/// <para>Distance Impedance</para>
		/// <para>如果使用阻抗参数指定的出行模式阻抗是基于距离的，则距离阻抗和阻抗参数的值必须相同。 否则，操作将返回错误。</para>
		/// <para><see cref="DistanceImpedanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object? DistanceImpedance { get; set; } = "Kilometers";

		/// <summary>
		/// <para>Polygon Detail</para>
		/// <para>指定输出面的细节层次。</para>
		/// <para>标准—面将以标准细节层次进行创建。 标准面的生成速度很快，且准确性相对较高，但向服务区面的边界处移动时，质量会在一定程度上降低。 这是默认设置。</para>
		/// <para>概化—将使用网络数据源中的等级创建概化面，以便快速生成结果。 与标准或高精度面相比，概化面的质量较差。</para>
		/// <para>高—将创建具有最高细节层次的面。 面中可能出现洞；它们表示不超出中断阻抗的情况下或由于行驶限制而无法到达的孤立网络元素（例如，街道）。该选项应该用于需要结果精确的应用。</para>
		/// <para>如果分析涉及的市区具有类似格网的街道网络，那么概化面和标准面之间的差异十分细微。 但是，如果涉及山区和农村道路，那么标准面表示的结果可能要比概化面更加详细。</para>
		/// <para>仅当中断值参数内指定的最大值小于或等于 15 分钟或 15 英里（24.14 千米）时，工具支持生成高精度面。</para>
		/// <para><see cref="PolygonDetailEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object? PolygonDetail { get; set; } = "Standard";

		/// <summary>
		/// <para>Output Type</para>
		/// <para>指定要生成的输出类型。 服务区输出可以是超过中断值前表示可到达道路的线要素，也可以是包括这些线的面要素（表示可达到的区域）。</para>
		/// <para>面—服务区输出将仅包含面。 这是默认设置。</para>
		/// <para>线—服务区输出将仅包含线。</para>
		/// <para>面和线—服务区输出将既包含面又包含线。</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object? OutputType { get; set; } = "Polygons";

		/// <summary>
		/// <para>Output Format</para>
		/// <para>指定将返回输出要素的格式。</para>
		/// <para>要素集—输出要素将作为要素类和表返回。 这是默认设置。</para>
		/// <para>JSON 文件—输出要素将作为包含输出的 JSON 表示的压缩文件返回。 指定此选项时，输出将是包含由服务针对每个输出创建的一个或多个 JSON 文件（扩展名为 .zip）的单个文件（扩展名为 .json）。</para>
		/// <para>GeoJSON 文件—输出要素将作为包含输出的 GeoJSON 表示的压缩文件返回。 指定此选项时，输出将是包含由服务针对每个输出创建的一个或多个 GeoJSON 文件（扩展名为 .zip）的单个文件（扩展名为 .geojson）。</para>
		/// <para>如果指定基于文件的输出格式（如 JSON 文件或 GeoJSON 文件），则不会向显示添加输出，因为应用程序（例如 ArcMap 或 ArcGIS Pro）无法绘制结果文件的内容。 相反，结果文件将下载到计算机上的临时目录中。 在 ArcGIS Pro 中，可以通过查看输出结果文件参数值来确定已下载文件的位置，该参数位于与工程地理处理历史中的工具执行相对应的条目中。 在 ArcMap 中，可以通过访问输出结果文件参数快捷菜单中的复制位置选项来确定文件的位置，该参数位于与地理处理结果窗口中的工具执行对应的条目中。</para>
		/// <para><see cref="OutputFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object? OutputFormat { get; set; } = "Feature Set";

		/// <summary>
		/// <para>Ignore Invalid Locations</para>
		/// <para>指定是否忽略无效的输入位置。</para>
		/// <para>选中 - 将忽略未定位的网络位置，并且将仅使用有效网络位置运行分析。 如果这些位置位于不可遍历的元素上或有其他错误，则分析仍会继续进行。 如果您已知网络位置并不完全正确，但是希望对有效的网络位置运行分析，则此选项将非常有用。 这是默认设置。</para>
		/// <para>未选中 - 不会忽略无效位置。 如果存在无效位置，请勿运行分析。 更正无效位置，然后重新运行分析。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Network Locations")]
		public object? IgnoreInvalidLocations { get; set; } = "true";

		/// <summary>
		/// <para>Service Areas</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? ServiceAreas { get; set; }

		/// <summary>
		/// <para>Solve Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? SolveSucceeded { get; set; }

		/// <summary>
		/// <para>Output Network Analysis Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? OutputNetworkAnalysisLayer { get; set; } = "scratchfile";

		/// <summary>
		/// <para>Output Facilities</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? OutputFacilities { get; set; }

		/// <summary>
		/// <para>Output Service Area Lines</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? OutputServiceAreaLines { get; set; }

		/// <summary>
		/// <para>Output Result File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? OutputResultFile { get; set; } = "scratchfile";

		/// <summary>
		/// <para>Output Network Analysis Layer Package</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? OutputNetworkAnalysisLayerPackage { get; set; } = "scratchfile";

		#region InnerClass

		/// <summary>
		/// <para>Break Units</para>
		/// </summary>
		public enum BreakUnitsEnum 
		{
			/// <summary>
			/// <para>米—线性单位为米。</para>
			/// </summary>
			[GPValue("Meters")]
			[Description("米")]
			Meters,

			/// <summary>
			/// <para>千米—线性单位为千米。</para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("千米")]
			Kilometers,

			/// <summary>
			/// <para>英尺—线性单位为英尺。</para>
			/// </summary>
			[GPValue("Feet")]
			[Description("英尺")]
			Feet,

			/// <summary>
			/// <para>码—线性单位为码。</para>
			/// </summary>
			[GPValue("Yards")]
			[Description("码")]
			Yards,

			/// <summary>
			/// <para>英里—线性单位为英里。</para>
			/// </summary>
			[GPValue("Miles")]
			[Description("英里")]
			Miles,

			/// <summary>
			/// <para>海里—线性单位为海里。</para>
			/// </summary>
			[GPValue("NauticalMiles")]
			[Description("海里")]
			Nautical_Miles,

			/// <summary>
			/// <para>秒—时间单位为秒。</para>
			/// </summary>
			[GPValue("Seconds")]
			[Description("秒")]
			Seconds,

			/// <summary>
			/// <para>分—时间单位为分钟。</para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("分")]
			Minutes,

			/// <summary>
			/// <para>小时—时间单位为小时。</para>
			/// </summary>
			[GPValue("Hours")]
			[Description("小时")]
			Hours,

			/// <summary>
			/// <para>天—时间单位为天。</para>
			/// </summary>
			[GPValue("Days")]
			[Description("天")]
			Days,

		}

		/// <summary>
		/// <para>Analysis Region</para>
		/// </summary>
		public enum AnalysisRegionEnum 
		{
			/// <summary>
			/// <para>欧洲—分析区域为欧洲。</para>
			/// </summary>
			[GPValue("Europe")]
			[Description("欧洲")]
			Europe,

			/// <summary>
			/// <para>日本—分析区域为日本。</para>
			/// </summary>
			[GPValue("Japan")]
			[Description("日本")]
			Japan,

			/// <summary>
			/// <para>韩国—分析区域为韩国。</para>
			/// </summary>
			[GPValue("Korea")]
			[Description("韩国")]
			Korea,

			/// <summary>
			/// <para>中东和非洲—分析区域为中东和非洲。</para>
			/// </summary>
			[GPValue("MiddleEastAndAfrica")]
			[Description("中东和非洲")]
			Middle_East_And_Africa,

			/// <summary>
			/// <para>北美—分析区域为北美洲。</para>
			/// </summary>
			[GPValue("NorthAmerica")]
			[Description("北美")]
			North_America,

			/// <summary>
			/// <para>南美洲—分析区域为南美。</para>
			/// </summary>
			[GPValue("SouthAmerica")]
			[Description("南美洲")]
			South_America,

			/// <summary>
			/// <para>南亚—分析区域为南亚。</para>
			/// </summary>
			[GPValue("SouthAsia")]
			[Description("南亚")]
			South_Asia,

			/// <summary>
			/// <para>泰国—分析区域为泰国。</para>
			/// </summary>
			[GPValue("Thailand")]
			[Description("泰国")]
			Thailand,

		}

		/// <summary>
		/// <para>Travel Direction</para>
		/// </summary>
		public enum TravelDirectionEnum 
		{
			/// <summary>
			/// <para>离开设施点—在远离设施点的方向上生成服务区。</para>
			/// </summary>
			[GPValue("Away From Facility")]
			[Description("离开设施点")]
			Away_From_Facility,

			/// <summary>
			/// <para>朝向设施点—在朝向设施点的方向上创建服务区。</para>
			/// </summary>
			[GPValue("Towards Facility")]
			[Description("朝向设施点")]
			Towards_Facility,

		}

		/// <summary>
		/// <para>UTurn at Junctions</para>
		/// </summary>
		public enum UturnAtJunctionsEnum 
		{
			/// <summary>
			/// <para>允许—无论在交汇点处有几条连接的边，均允许 U 形转弯。 这是默认值。</para>
			/// </summary>
			[GPValue("Allowed")]
			[Description("允许")]
			Allowed,

			/// <summary>
			/// <para>不允许—在所有交汇点处均禁止 U 形转弯，不管交汇点原子价如何。 不过请注意，即使已选择该选项，在网络位置仍允许 U 形转弯；但是也可以通过设置个别网络位置的 CurbApproach 属性来禁止 U 形转弯。</para>
			/// </summary>
			[GPValue("Not Allowed")]
			[Description("不允许")]
			Not_Allowed,

			/// <summary>
			/// <para>仅在死角处允许—除仅有一条相邻边的交汇点（死角）外，其他交汇点均禁止 U 形转弯。</para>
			/// </summary>
			[GPValue("Allowed Only at Dead Ends")]
			[Description("仅在死角处允许")]
			Allowed_only_at_Dead_Ends,

			/// <summary>
			/// <para>仅在交点和死角处允许—在恰好有两条相邻边相遇的交汇点处禁止 U 形转弯，但是交叉点（三条或三条以上相邻边的交汇点）和死角（仅有一条相邻边的交汇点）处允许。 通常，网络在路段中间有多余的交汇点。 此选项可防止车辆在这些位置掉头。</para>
			/// </summary>
			[GPValue("Allowed Only at Intersections and Dead Ends")]
			[Description("仅在交点和死角处允许")]
			Allowed_only_at_Intersections_and_Dead_Ends,

		}

		/// <summary>
		/// <para>Geometry at Overlaps</para>
		/// </summary>
		public enum PolygonsForMultipleFacilitiesEnum 
		{
			/// <summary>
			/// <para>叠置—将为每个设施点创建单独的面。 这些面可以相互叠置。 这是默认设置。</para>
			/// </summary>
			[GPValue("Overlapping")]
			[Description("叠置")]
			Overlapping,

			/// <summary>
			/// <para>不叠置—将创建单独的面，使得某个设施点的面无法与其他设施点的面叠置。 网络的任何部分都只能由最近设施点的服务区覆盖。</para>
			/// </summary>
			[GPValue("Not Overlapping")]
			[Description("不叠置")]
			Not_Overlapping,

			/// <summary>
			/// <para>按中断值合并—将创建并连接具有相同中断值的不同设施点的面。</para>
			/// </summary>
			[GPValue("Merge by Break Value")]
			[Description("按中断值合并")]
			Merge_by_Break_Value,

		}

		/// <summary>
		/// <para>Geometry at Cutoffs</para>
		/// </summary>
		public enum PolygonOverlapTypeEnum 
		{
			/// <summary>
			/// <para>圆环—代表中断值较大的面，可排除中断值较小的面。 这将在连续的中断之间创建面。 请使用此选项查找从一个中断到另一个中断的区域。 例如，如果创建 5 分钟和 10 分钟服务区，则 10 分钟服务区面将排除 5 分钟服务区面内的区域。 这是默认设置。</para>
			/// </summary>
			[GPValue("Rings")]
			[Description("圆环")]
			Rings,

			/// <summary>
			/// <para>圆盘—在设施点与休息点之间创建面。 例如，如果创建 5 分钟和 10 分钟服务区，则 10 分钟服务区面将包含 5 分钟服务区面内的区域。</para>
			/// </summary>
			[GPValue("Disks")]
			[Description("圆盘")]
			Disks,

		}

		/// <summary>
		/// <para>Time Zone for Time of Day</para>
		/// </summary>
		public enum TimeZoneForTimeOfDayEnum 
		{
			/// <summary>
			/// <para>本地地理位置—时间参数是指设施点所处的时区或区域。 服务区开始时间或结束时间的时区交错。 将时间设为 9:00 AM，为时间的时区选择“本地地理位置”，然后进行求解，将为处于东部时区的所有设施点生成东部时间 9:00 a.m. 的服务区、为处于中部时区的设施点生成中部时间 9:00 a.m. 的服务区、为处于山区时区的设施点生成山区时间 9:00 a.m. 的服务区等等。如果商店处于覆盖美国、在当地时间 9:00 a.m. 开业的商店链中，则可以在一次求解中选择此参数值来查找处于所有商店开业时间的市场地区。 首先，东部时区的商店开业并生成一个面，一小时后中部时区的商店开业，以此类推。 当地时间始终为 9 点，但却因不同时区而实时交错。</para>
			/// </summary>
			[GPValue("Geographically Local")]
			[Description("本地地理位置")]
			Geographically_Local,

			/// <summary>
			/// <para>UTC—时间参数是指协调世界时间 (UTC)。 无论各设施点处于哪个时区都会同时到达或出发。将时间设为 2:00 PM，选择 UTC，然后进行求解，将为处于东部时区的所有设施点生成东部标准时间 9:00 a.m. 的服务区、为处于中部时区的设施点生成中部标准时间 8:00 a.m. 的服务区、为处于山地时区的设施点生成山地标准时间 7:00 a.m. 的服务区，等等。以上情况均假定为标准时间。 在夏令时期间，东部、中部、和山地时间应各提前 1 小时（即分别为 10:00 a.m.、9:00 a.m. 和 8:00 a.m.）。UTC 选项可用于为跨两个时区的管辖区显示紧急响应范围。 将急救车辆加载为设施点。 将时间参数设置为 UTC 的当前时间。 （您需要确定当前 UTC 时间和日期，以便正确使用此选项。）设置其他属性，并对分析进行求解。 尽管时区边界会分割车辆，但结果仍将显示当前交通状况下可以到达的区域。 也可对其他时间使用相同的过程，而不仅是当前时间。</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

		}

		/// <summary>
		/// <para>Time Impedance</para>
		/// </summary>
		public enum TimeImpedanceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("分")]
			Minutes,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("TravelTime")]
			[Description("行驶时间")]
			Travel_Time,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("TimeAt1KPH")]
			[Description("每小时一公里的时间")]
			Time_At_One_Kilometer_Per_Hour,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("WalkTime")]
			[Description("步行时间")]
			Walk_Time,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("TruckMinutes")]
			[Description("卡车分钟")]
			Truck_Minutes,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("TruckTravelTime")]
			[Description("卡车行驶时间")]
			Truck_Travel_Time,

		}

		/// <summary>
		/// <para>Distance Impedance</para>
		/// </summary>
		public enum DistanceImpedanceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("英里")]
			Miles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("千米")]
			Kilometers,

		}

		/// <summary>
		/// <para>Polygon Detail</para>
		/// </summary>
		public enum PolygonDetailEnum 
		{
			/// <summary>
			/// <para>概化—将使用网络数据源中的等级创建概化面，以便快速生成结果。 与标准或高精度面相比，概化面的质量较差。</para>
			/// </summary>
			[GPValue("Generalized")]
			[Description("概化")]
			Generalized,

			/// <summary>
			/// <para>标准—面将以标准细节层次进行创建。 标准面的生成速度很快，且准确性相对较高，但向服务区面的边界处移动时，质量会在一定程度上降低。 这是默认设置。</para>
			/// </summary>
			[GPValue("Standard")]
			[Description("标准")]
			Standard,

			/// <summary>
			/// <para>高—将创建具有最高细节层次的面。 面中可能出现洞；它们表示不超出中断阻抗的情况下或由于行驶限制而无法到达的孤立网络元素（例如，街道）。该选项应该用于需要结果精确的应用。</para>
			/// </summary>
			[GPValue("High")]
			[Description("高")]
			High,

		}

		/// <summary>
		/// <para>Output Type</para>
		/// </summary>
		public enum OutputTypeEnum 
		{
			/// <summary>
			/// <para>面—服务区输出将仅包含面。 这是默认设置。</para>
			/// </summary>
			[GPValue("Polygons")]
			[Description("面")]
			Polygons,

			/// <summary>
			/// <para>线—服务区输出将仅包含线。</para>
			/// </summary>
			[GPValue("Lines")]
			[Description("线")]
			Lines,

			/// <summary>
			/// <para>面和线—服务区输出将既包含面又包含线。</para>
			/// </summary>
			[GPValue("Polygons and lines")]
			[Description("面和线")]
			Polygons_and_lines,

		}

		/// <summary>
		/// <para>Output Format</para>
		/// </summary>
		public enum OutputFormatEnum 
		{
			/// <summary>
			/// <para>要素集—输出要素将作为要素类和表返回。 这是默认设置。</para>
			/// </summary>
			[GPValue("Feature Set")]
			[Description("要素集")]
			Feature_Set,

			/// <summary>
			/// <para>JSON 文件—输出要素将作为包含输出的 JSON 表示的压缩文件返回。 指定此选项时，输出将是包含由服务针对每个输出创建的一个或多个 JSON 文件（扩展名为 .zip）的单个文件（扩展名为 .json）。</para>
			/// </summary>
			[GPValue("JSON File")]
			[Description("JSON 文件")]
			JSON_File,

			/// <summary>
			/// <para>GeoJSON 文件—输出要素将作为包含输出的 GeoJSON 表示的压缩文件返回。 指定此选项时，输出将是包含由服务针对每个输出创建的一个或多个 GeoJSON 文件（扩展名为 .zip）的单个文件（扩展名为 .geojson）。</para>
			/// </summary>
			[GPValue("GeoJSON File")]
			[Description("GeoJSON 文件")]
			GeoJSON_File,

		}

#endregion
	}
}
