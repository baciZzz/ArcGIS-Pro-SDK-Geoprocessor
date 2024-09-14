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
	/// <para>Find Routes</para>
	/// <para>查找路径</para>
	/// <para>用于确定访问输入停靠点的最短路径，并返回行驶方向、所访问停靠点的信息以及路径（包括行驶时间和距离）。</para>
	/// </summary>
	public class FindRoutes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Stops">
		/// <para>Stops</para>
		/// <para>指定一条或多条输出路径将访问的位置。</para>
		/// <para>您最多可以添加 10,000 个停靠点，并最多向一条路径分配 150 个停靠点。（使用 RouteName 属性向路径分配停靠点。）</para>
		/// <para>指定停靠点后，可使用以下特性为每个停靠点设置属性，例如停靠点的名称或服务时间。</para>
		/// <para>Name</para>
		/// <para>停靠点的名称。该名称用于行驶方向中。如果未指定名称，则会在输出停靠点、路径和方向中自动生成前缀为 Location 的唯一名称。</para>
		/// <para>RouteName</para>
		/// <para>分配给停靠点的路径的名称。将相同的路径名称分配到不同的停靠点会导致这些停靠点被归为一组，并由同一路径进行访问。通过将唯一的路径名称分配到不同的停靠点组，可以在一个求解操作中生成多个路径。</para>
		/// <para>您最多可以将 150 个停靠点分组到一个路径中。</para>
		/// <para>Sequence</para>
		/// <para>输出路径将按照您使用此属性指定的顺序访问停靠点。在一组具有相同 RouteName 值的停靠点中，序号应大于 0 且不大于停靠点的总数。而且，序号不应重复。</para>
		/// <para>如果选中重新排序停靠点以查找最佳路径 (True)，将忽略所有值（但每个路径名称的第一个和最后一个 sequence 值可能除外），以便工具查找可使每个路径总行程最小化的顺序。（保留停靠点的顺序和返回到起点的设置决定了是否忽略每个路径的第一个或最后一个 sequence 值。）</para>
		/// <para>AdditionalTime</para>
		/// <para>在停靠点所花费的时间，该时间将添加到路径总时间中。默认值为 0。</para>
		/// <para>该属性值的单位由测量单位参数指定。仅在测量单位基于时间时，属性值才能包含在分析中。</para>
		/// <para>您可以将为了完成任务而在停靠点花费的额外时间考虑在内，例如，维修设备、配送包裹或检查场所。</para>
		/// <para>AdditionalDistance</para>
		/// <para>在停靠点所行驶的额外距离，该距离将添加到路径总距离中。默认值为 0。</para>
		/// <para>该属性值的单位由测量单位参数指定。仅在测量单位基于距离时，属性值才能包含在分析中。</para>
		/// <para>通常，停靠点的位置（例如住宅）并不是恰好位于街道上，而是位于道路的后方。如果有必要将停靠点的实际位置与其在街道上的位置之间的距离计入总行驶距离，则可使用该属性值构建此段距离。</para>
		/// <para>AdditionalCost</para>
		/// <para>在停靠点花费的额外成本，该成本将添加到路径总成本中。默认值为 0。</para>
		/// <para>当分析的出行模式使用既不基于时间也不基于距离的阻抗属性时，应使用此属性值。属性值的单位将解释为未知单位。</para>
		/// <para>TimeWindowStart</para>
		/// <para>可以访问停靠点的最早时间。通过为停靠点时间窗指定开始时间和结束时间，您可以定义路径应在何时访问停靠点。当分析的出行模式使用基于时间的阻抗属性时，指定时间窗口值将使分析查找以下解决方案：尽可能缩短总行程并在规定时间窗口内到达停靠点。</para>
		/// <para>确保以日期和时间值的形式指定此值，例如 8/12/2015 12:15 PM。</para>
		/// <para>解决跨越多个时区的问题时，时间窗的值将采用停靠点所处位置的时区。</para>
		/// <para>此字段可以包含空值；空值表示路径可以在 TimeWindowEnd 属性中所指定时间之前的任意时间到达。如果 TimeWindowEnd 中也出现空值，则路径可以随时访问停靠点。</para>
		/// <para>TimeWindowEnd</para>
		/// <para>可以访问停靠点的最晚时间。通过为停靠点时间窗指定开始时间和结束时间，您可以定义路径将在何时访问停靠点。当分析的出行模式使用基于时间的阻抗属性时，指定时间窗口值将使分析查找以下解决方案：尽可能缩短总行程并在规定时间窗口内到达停靠点。</para>
		/// <para>确保以日期和时间值的形式指定此值，例如 8/12/2015 12:15 PM。</para>
		/// <para>解决跨越多个时区的问题时，时间窗的值将采用停靠点所处位置的时区。</para>
		/// <para>此字段可以包含空值；空值表示路径可以在 TimeWindowStart 属性中所指定时间之后的任意时间到达。如果 TimeWindowStart 中也出现空值，则路径可以随时访问停靠点。</para>
		/// <para>CurbApproach</para>
		/// <para>指定车辆到达和离开停靠点的方向。该字段值可指定为以下整数之一（请使用数值代码而非括号中的名称）：</para>
		/// <para>0（车辆的任意一侧）- 车辆可从任一方向到达和离开停靠点，因此停靠点处允许 U 形转弯。如果您的车辆有可能要在停靠点处调头，则可以选择该设置。此决策可能取决于道路的宽度以及交通量，或者该停靠点是否有停车场能让车辆驶入并调头。</para>
		/// <para>1（车辆的右侧）- 当车辆到达和离开停靠点时，停靠点必须在车辆右侧。禁止 U 形转弯。通常用于必须在右侧停靠的车辆（如公共汽车）。</para>
		/// <para>2（车辆的左侧）- 当车辆到达和离开停靠点时，路边必须在车辆左侧。禁止 U 形转弯。通常用于必须在左侧停靠的车辆（如公共汽车）。</para>
		/// <para>3（禁止 U 形转弯）- 当车辆到达停靠点时，路边可在车辆的任意一侧；但是，车辆在离开时不得调头。</para>
		/// <para>CurbApproach 属性是专为使用以下两种国家驾驶标准而设计的：右侧通行（美国）和左侧通行（英国）。首先，考虑位于车辆左侧的停靠点。不管车辆行驶在左车道还是右车道，停靠点始终位于车辆的左侧。不同国家的驾驶标准可能会要求您从这两种方向中的其中一个接近停靠点，也就是说，只能从车辆的右侧或左侧接近停靠点。例如，如果要到达一个停靠点并且在车辆与停靠点之间不存在交通车道，那么在美国请选择 1（车辆的右侧），而在英国请选择 2（车辆的左侧）。</para>
		/// <para>LocationType</para>
		/// <para>指定停靠点类型。该字段值可指定为以下整数之一（请使用数值代码而非括号中的名称）：</para>
		/// <para>0（停靠点）- 路径将访问的位置。这是默认设置。</para>
		/// <para>1（航路点）- 路径将经过但不停靠的位置。航路点可用于强制路径采用特定路线（经过航路点），无需将其视为实际停靠点。航路点不会显示在方向上。</para>
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
		/// <param name="MeasurementUnits">
		/// <para>Measurement Units</para>
		/// <para>指定用于测量和报告输出路径的总行驶时间或行驶距离的单位。</para>
		/// <para>为此参数选择的单位可以确定工具将测量距离还是时间来查找最佳路径。选择时间单位最小化所选出行模式的行驶时间（例如驾车时间或步行时间）。要最小化给定出行模式的行驶距离，请选择一个距离单位。选择的单位还确定工具在结果中以哪种单位报告总时间或距离。</para>
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
		/// <para><see cref="MeasurementUnitsEnum"/></para>
		/// </param>
		public FindRoutes(object Stops, object MeasurementUnits)
		{
			this.Stops = Stops;
			this.MeasurementUnits = MeasurementUnits;
		}

		/// <summary>
		/// <para>Tool Display Name : 查找路径</para>
		/// </summary>
		public override string DisplayName() => "查找路径";

		/// <summary>
		/// <para>Tool Name : FindRoutes</para>
		/// </summary>
		public override string ToolName() => "FindRoutes";

		/// <summary>
		/// <para>Tool Excute Name : agolservices.FindRoutes</para>
		/// </summary>
		public override string ExcuteName() => "agolservices.FindRoutes";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Stops, MeasurementUnits, AnalysisRegion, ReorderStopsToFindOptimalRoutes, PreserveTerminalStops, ReturnToStart, UseTimeWindows, TimeOfDay, TimeZoneForTimeOfDay, UturnAtJunctions, PointBarriers, LineBarriers, PolygonBarriers, UseHierarchy, Restrictions, AttributeParameterValues, RouteShape, RouteLineSimplificationTolerance, PopulateRouteEdges, PopulateDirections, DirectionsLanguage, DirectionsDistanceUnits, DirectionsStyleName, TravelMode, Impedance, TimeZoneForTimeWindows, SaveOutputNetworkAnalysisLayer, Overrides, SaveRouteData, TimeImpedance, DistanceImpedance, OutputFormat, IgnoreInvalidLocations, SolveSucceeded, OutputRoutes, OutputRouteEdges, OutputDirections, OutputStops, OutputNetworkAnalysisLayer, OutputRouteData, OutputResultFile, OutputNetworkAnalysisLayerPackage, OutputDirectionPoints, OutputDirectionLines };

		/// <summary>
		/// <para>Stops</para>
		/// <para>指定一条或多条输出路径将访问的位置。</para>
		/// <para>您最多可以添加 10,000 个停靠点，并最多向一条路径分配 150 个停靠点。（使用 RouteName 属性向路径分配停靠点。）</para>
		/// <para>指定停靠点后，可使用以下特性为每个停靠点设置属性，例如停靠点的名称或服务时间。</para>
		/// <para>Name</para>
		/// <para>停靠点的名称。该名称用于行驶方向中。如果未指定名称，则会在输出停靠点、路径和方向中自动生成前缀为 Location 的唯一名称。</para>
		/// <para>RouteName</para>
		/// <para>分配给停靠点的路径的名称。将相同的路径名称分配到不同的停靠点会导致这些停靠点被归为一组，并由同一路径进行访问。通过将唯一的路径名称分配到不同的停靠点组，可以在一个求解操作中生成多个路径。</para>
		/// <para>您最多可以将 150 个停靠点分组到一个路径中。</para>
		/// <para>Sequence</para>
		/// <para>输出路径将按照您使用此属性指定的顺序访问停靠点。在一组具有相同 RouteName 值的停靠点中，序号应大于 0 且不大于停靠点的总数。而且，序号不应重复。</para>
		/// <para>如果选中重新排序停靠点以查找最佳路径 (True)，将忽略所有值（但每个路径名称的第一个和最后一个 sequence 值可能除外），以便工具查找可使每个路径总行程最小化的顺序。（保留停靠点的顺序和返回到起点的设置决定了是否忽略每个路径的第一个或最后一个 sequence 值。）</para>
		/// <para>AdditionalTime</para>
		/// <para>在停靠点所花费的时间，该时间将添加到路径总时间中。默认值为 0。</para>
		/// <para>该属性值的单位由测量单位参数指定。仅在测量单位基于时间时，属性值才能包含在分析中。</para>
		/// <para>您可以将为了完成任务而在停靠点花费的额外时间考虑在内，例如，维修设备、配送包裹或检查场所。</para>
		/// <para>AdditionalDistance</para>
		/// <para>在停靠点所行驶的额外距离，该距离将添加到路径总距离中。默认值为 0。</para>
		/// <para>该属性值的单位由测量单位参数指定。仅在测量单位基于距离时，属性值才能包含在分析中。</para>
		/// <para>通常，停靠点的位置（例如住宅）并不是恰好位于街道上，而是位于道路的后方。如果有必要将停靠点的实际位置与其在街道上的位置之间的距离计入总行驶距离，则可使用该属性值构建此段距离。</para>
		/// <para>AdditionalCost</para>
		/// <para>在停靠点花费的额外成本，该成本将添加到路径总成本中。默认值为 0。</para>
		/// <para>当分析的出行模式使用既不基于时间也不基于距离的阻抗属性时，应使用此属性值。属性值的单位将解释为未知单位。</para>
		/// <para>TimeWindowStart</para>
		/// <para>可以访问停靠点的最早时间。通过为停靠点时间窗指定开始时间和结束时间，您可以定义路径应在何时访问停靠点。当分析的出行模式使用基于时间的阻抗属性时，指定时间窗口值将使分析查找以下解决方案：尽可能缩短总行程并在规定时间窗口内到达停靠点。</para>
		/// <para>确保以日期和时间值的形式指定此值，例如 8/12/2015 12:15 PM。</para>
		/// <para>解决跨越多个时区的问题时，时间窗的值将采用停靠点所处位置的时区。</para>
		/// <para>此字段可以包含空值；空值表示路径可以在 TimeWindowEnd 属性中所指定时间之前的任意时间到达。如果 TimeWindowEnd 中也出现空值，则路径可以随时访问停靠点。</para>
		/// <para>TimeWindowEnd</para>
		/// <para>可以访问停靠点的最晚时间。通过为停靠点时间窗指定开始时间和结束时间，您可以定义路径将在何时访问停靠点。当分析的出行模式使用基于时间的阻抗属性时，指定时间窗口值将使分析查找以下解决方案：尽可能缩短总行程并在规定时间窗口内到达停靠点。</para>
		/// <para>确保以日期和时间值的形式指定此值，例如 8/12/2015 12:15 PM。</para>
		/// <para>解决跨越多个时区的问题时，时间窗的值将采用停靠点所处位置的时区。</para>
		/// <para>此字段可以包含空值；空值表示路径可以在 TimeWindowStart 属性中所指定时间之后的任意时间到达。如果 TimeWindowStart 中也出现空值，则路径可以随时访问停靠点。</para>
		/// <para>CurbApproach</para>
		/// <para>指定车辆到达和离开停靠点的方向。该字段值可指定为以下整数之一（请使用数值代码而非括号中的名称）：</para>
		/// <para>0（车辆的任意一侧）- 车辆可从任一方向到达和离开停靠点，因此停靠点处允许 U 形转弯。如果您的车辆有可能要在停靠点处调头，则可以选择该设置。此决策可能取决于道路的宽度以及交通量，或者该停靠点是否有停车场能让车辆驶入并调头。</para>
		/// <para>1（车辆的右侧）- 当车辆到达和离开停靠点时，停靠点必须在车辆右侧。禁止 U 形转弯。通常用于必须在右侧停靠的车辆（如公共汽车）。</para>
		/// <para>2（车辆的左侧）- 当车辆到达和离开停靠点时，路边必须在车辆左侧。禁止 U 形转弯。通常用于必须在左侧停靠的车辆（如公共汽车）。</para>
		/// <para>3（禁止 U 形转弯）- 当车辆到达停靠点时，路边可在车辆的任意一侧；但是，车辆在离开时不得调头。</para>
		/// <para>CurbApproach 属性是专为使用以下两种国家驾驶标准而设计的：右侧通行（美国）和左侧通行（英国）。首先，考虑位于车辆左侧的停靠点。不管车辆行驶在左车道还是右车道，停靠点始终位于车辆的左侧。不同国家的驾驶标准可能会要求您从这两种方向中的其中一个接近停靠点，也就是说，只能从车辆的右侧或左侧接近停靠点。例如，如果要到达一个停靠点并且在车辆与停靠点之间不存在交通车道，那么在美国请选择 1（车辆的右侧），而在英国请选择 2（车辆的左侧）。</para>
		/// <para>LocationType</para>
		/// <para>指定停靠点类型。该字段值可指定为以下整数之一（请使用数值代码而非括号中的名称）：</para>
		/// <para>0（停靠点）- 路径将访问的位置。这是默认设置。</para>
		/// <para>1（航路点）- 路径将经过但不停靠的位置。航路点可用于强制路径采用特定路线（经过航路点），无需将其视为实际停靠点。航路点不会显示在方向上。</para>
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
		public object Stops { get; set; }

		/// <summary>
		/// <para>Measurement Units</para>
		/// <para>指定用于测量和报告输出路径的总行驶时间或行驶距离的单位。</para>
		/// <para>为此参数选择的单位可以确定工具将测量距离还是时间来查找最佳路径。选择时间单位最小化所选出行模式的行驶时间（例如驾车时间或步行时间）。要最小化给定出行模式的行驶距离，请选择一个距离单位。选择的单位还确定工具在结果中以哪种单位报告总时间或距离。</para>
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
		/// <para><see cref="MeasurementUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MeasurementUnits { get; set; } = "Minutes";

		/// <summary>
		/// <para>Analysis Region</para>
		/// <para>将执行分析的区域。 如果未对此参数指定值，工具会基于输入点的位置自动计算区域名称。 仅当自动检测的区域名称输入不准确时，才需要设置区域名称。</para>
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
		public object AnalysisRegion { get; set; }

		/// <summary>
		/// <para>Reorder Stops to Find Optimal Routes</para>
		/// <para>指定是按照您定义的顺序还是按照工具确定的可使总行程最小化的顺序来访问停靠点。</para>
		/// <para>选中 (True) - 将按照工具确定的顺序访问停靠点，从而最大程度减少总体行驶距离或时间。它可以对停靠点进行重新排序并将停靠点的时间窗考虑在内。利用其他参数，可在使用该工具对中途的停靠点进行重新排序的同时保留第一个或最后一个停靠点。</para>
		/// <para>未选中 (False) - 将按照您定义的顺序访问停靠点。您可以在输入停靠点要素中使用 Sequence 属性来设置停靠点的顺序，也可以通过停靠点的 Object ID 确定顺序。这是默认设置。</para>
		/// <para>查找最佳停靠点顺序和最佳路径通常称作解决流动推销员问题 (TSP)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		public object ReorderStopsToFindOptimalRoutes { get; set; } = "false";

		/// <summary>
		/// <para>Preserve Terminal Stops</para>
		/// <para>指定如何保留终端停靠点。如果选中重新排序停靠点以查找最佳路径（或 True），您可以保留起始停靠点或结束停靠点，然后由该工具对余下的停靠点进行重新排序。</para>
		/// <para>第一个和最后一个停靠点是通过其 Sequence 属性值确定的，如果 Sequence 值为空，则通过其 Object ID 值来确定。</para>
		/// <para>保留第一个—该工具不会对第一个停靠点进行重新排序。 如果从已知位置开始，例如您的主页、总部或当前位置，请选择此选项。</para>
		/// <para>保留最后一个—该工具不会对最后一个停靠点进行重新排序。 输出路径可以从任何停靠点要素开始，但必须在预先确定的最后一个停靠点结束。</para>
		/// <para>保留第一个和最后一个—该工具不会对第一个和最后一个停靠点进行重新排序。</para>
		/// <para>不保留—该工具可以对任意停靠点进行重新排序，包括第一个和最后一个停靠点。 路径可能从任一停靠点要素开始或在任一停靠点结束。</para>
		/// <para>如果未选中重新排序停靠点以查找最佳路径（或 False），则将忽略保留终端停靠点。</para>
		/// <para><see cref="PreserveTerminalStopsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PreserveTerminalStops { get; set; } = "Preserve First";

		/// <summary>
		/// <para>Return to Start</para>
		/// <para>指定路径是否将在同一位置开始和结束。使用此选项，可以避免重复第一个停靠点要素并避免在结束时对重复的停靠点进行排序。</para>
		/// <para>路径的起始位置是 Sequence 属性值最低的停靠点要素。如果 Sequence 值为空，则为 Object ID 值最低的停靠点要素。</para>
		/// <para>选中 (True) - 路径将在第一个停靠点要素处开始和结束。如果同时选中重新排序停靠点以查找最佳路径和返回到起点（或 True），保留终端停靠点必须设置为保留第一个。这是默认值。</para>
		/// <para>未选中 (False) - 路径不会在第一个停靠点要素处开始和结束。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		public object ReturnToStart { get; set; } = "false";

		/// <summary>
		/// <para>Use Time Windows</para>
		/// <para>指定是否支持时间窗。如果任何输入停靠点的时间窗指定了路径将在何时到达停靠点，则选中此选项（或将其设置为 True）。通过在 TimeWindowStart 和 TimeWindowEnd 属性中输入时间值，可以将时间窗添加到输入停靠点。</para>
		/// <para>选中 (True) - 输入停靠点具有时间窗，并且您希望该工具尝试遵照这些时间窗。</para>
		/// <para>未选中 (False) - 输入停靠点没有时间窗；或者即使有时间窗，您也不希望该工具尝试遵照这些时间窗。这是默认值。</para>
		/// <para>当选中应用时间窗（或 True）时，即使所有输入停靠点都没有时间窗，该工具的运行时间也会稍长一些，因此建议您在可能的情况下取消选中此选项（设置为 False）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Advanced Analysis")]
		public object UseTimeWindows { get; set; } = "false";

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>路线开始的时间和日期。</para>
		/// <para>如果您正在对驾车出行模式进行建模并指定当前日期和时间作为该参数的值，则工具将使用实时交通状况查找最佳路径，并且总行驶时间将基于交通状况提供。</para>
		/// <para>指定时间可提供更加准确的路径和行驶时间评估，因为行驶时间是根据相应日期和时间的交通状况而估算出的。</para>
		/// <para>时间的时区参数指定该时间和日期是参考 UTC 还是停靠点所在时区。</para>
		/// <para>如果未将测量单位设置为基于时间的单位，则该工具将忽略此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object TimeOfDay { get; set; }

		/// <summary>
		/// <para>Time Zone for Time of Day</para>
		/// <para>指定时间参数的时区。</para>
		/// <para>本地地理位置—时间参数采用路径的第一个停靠点处的时区。 如果生成开始于多个时区的多个路径，则开始时间会采用协调世界时间 (UTC) 交错。 例如，时间值为 1 月 2 日 10:00 a.m.， 表示始于东部时区的路径的开始时间为东部标准时间 10:00 a.m. (UTC-3:00)，始于中部时区的路径的开始时间为中部标准时间 10:00 a.m. (UTC-4:00)。 开始时间偏差一小时（UTC 时间）。 输出停靠点要素类中记录的到达与离开的时间和日期将采用每个路径第一个停靠点的本地时区。</para>
		/// <para>UTC—时间参数指 UTC。 如果您想要在特定的时间（如现在）生成路径，但不确定第一个停靠点所在的时区，请选择此选项。 如果您生成跨越多个时区的多个路径，以 UTC 表示的开始时间将发生同步。 例如，时间值为 1 月 2 日 10:00 a.m.， 表示始于东部时区的路径的开始时间为东部标准时间 5:00 a.m. (UTC-5:00)，始于中部时区的路径的开始时间为中部标准时间 4:00 a.m. (UTC-6:00)。 这两个路径均于 10:00 a.m. UTC. 输出停靠点要素类中记录的到达与离开的时间和日期将参考 UTC。</para>
		/// <para><see cref="TimeZoneForTimeOfDayEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TimeZoneForTimeOfDay { get; set; } = "Geographically Local";

		/// <summary>
		/// <para>UTurn at Junctions</para>
		/// <para>&lt;para/&gt;指定交汇点的 U 形转弯策略。 允许 U 形转弯表示求解程序可以在交汇点处转向并沿同一街道往回行驶。 考虑到交汇点表示街道交叉路口和死角，不同的车辆可以在某些交汇点转弯，而在其他交汇点则不行 - 这取决于交汇点是交叉路口还是死角。 为适应此情况，U 形转弯策略参数由与交汇点连通的边数隐性指定，这称为交汇点原子价。 此参数可接受的值如下所列；每个值的后面是根据交汇点价对其含义的描述。</para>
		/// <para>允许—无论在交汇点处有几条连接的边，均允许 U 形转弯。 这是默认值。</para>
		/// <para>不允许—在所有交汇点处均禁止 U 形转弯，不管交汇点原子价如何。 不过请注意，即使已选择该选项，在网络位置仍允许 U 形转弯；但是也可以通过设置个别网络位置的 CurbApproach 属性来禁止 U 形转弯。</para>
		/// <para>仅在死角处允许—除仅有一条相邻边的交汇点（死角）外，其他交汇点均禁止 U 形转弯。</para>
		/// <para>仅在交点和死角处允许—在恰好有两条相邻边相遇的交汇点处禁止 U 形转弯，但是交叉点（三条或三条以上相邻边的交汇点）和死角（仅有一条相邻边的交汇点）处允许。 通常，网络在路段中间有多余的交汇点。 此选项可防止车辆在这些位置掉头。</para>
		/// <para>除非将出行模式设置为自定义，否则会忽略此参数。</para>
		/// <para><see cref="UturnAtJunctionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object UturnAtJunctions { get; set; } = "Allowed Only at Intersections and Dead Ends";

		/// <summary>
		/// <para>Point Barriers</para>
		/// <para>使用此参数可指定一个或多个点，来充当临时限制或表示在基础街道上行驶可能需要的附加时间或距离。 例如，可使用点障碍显示一棵沿街倒下的树或穿过铁路道口时花费的时间延迟。</para>
		/// <para>工具限制了可添加为障碍的点不得超过 250 个。</para>
		/// <para>指定点障碍时，可通过使用以下特性为每个障碍点设置属性，例如其名称或障碍类型。</para>
		/// <para>Name</para>
		/// <para>障碍名称。</para>
		/// <para>BarrierType</para>
		/// <para>指定点障碍是完全限制通行还是会在穿越时增加时间或距离。 此特性值可指定为以下整数之一（请使用数值代码而非括号中的名称）：</para>
		/// <para>0（限制型）- 禁止穿过障碍。 此障碍称为限制型点障碍，因为它作为限制使用。</para>
		/// <para>2（增加成本型）- 穿过此障碍会增加通过 Additional_Time、Additional_Distance 或 Additional_Cost 字段指定的行驶时间或行驶距离的数值。 此障碍类型称为增加成本型点障碍。</para>
		/// <para>Additional_Time</para>
		/// <para>遍历障碍时增加的行驶时间。 此字段仅适用于增加成本型障碍，且仅在测量单位参数值基于时间时适用。</para>
		/// <para>此字段值必须大于或等于零，并且其单位必须与在测量单位参数中指定的单位相同。</para>
		/// <para>Additional_Distance</para>
		/// <para>遍历障碍时增加的距离。 此字段仅适用于增加成本型障碍，且仅在测量单位参数值基于距离时适用。</para>
		/// <para>该字段值必须大于或等于零，并且其单位必须与在测量单位参数中指定的单位相同。</para>
		/// <para>Additional_Cost</para>
		/// <para>遍历障碍时增加的成本。 当测量单位参数值不基于时间或距离时，此字段仅适用于增加成本型障碍。</para>
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
		/// <para>CurbApproach 属性适用于以下两种国家驾驶标准：右侧通行（美国）和左侧通行（英国）。 首先，考虑位于车辆左侧的设施点。 不管车辆行驶在左车道还是右车道，停靠点始终位于车辆的左侧。 不同国家的驾驶标准可能会要求您从这两种方向中的其中一个接近设施点，也就是说，只能从车辆的右侧或左侧接近设施点。 例如，要到达一个设施点并且在车辆与设施点之间不存在其他交通车道，在美国应该选择 1（车辆的右侧），而在英国应该选择 2（车辆的左侧）。</para>
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
		public object PointBarriers { get; set; }

		/// <summary>
		/// <para>Line Barriers</para>
		/// <para>使用此参数可指定一条或多条线，以禁止在线与街道的所有相交位置通行。 例如，线障碍可用于对阻塞若干个路段交通的游行或抗议队伍进行建模。 线障碍还可隔离多条道路以禁止进行遍历，从而在可能的路径中去除不符合要求的街道网络部分。</para>
		/// <para>该工具限制了您可以使用线障碍参数限制的街道数量。 可指定为线障碍的线数没有限制时，所有线的相交街道的合并数不能超过 500。</para>
		/// <para>指定线障碍时，可使用以下特性设置每个线障碍的名称和障碍类型：</para>
		/// <para>Name</para>
		/// <para>障碍名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[Category("Barriers")]
		public object LineBarriers { get; set; }

		/// <summary>
		/// <para>Polygon Barriers</para>
		/// <para>使用此参数可指定面，以完全限制通行或按比例调整在与面相交的街道上行进所需的时间或距离。</para>
		/// <para>该服务限制了您可以使用面障碍参数限制的街道数量。 可指定为面障碍的面数没有限制时，所有面的相交街道的合并数不能超过 2,000。</para>
		/// <para>指定面障碍时，可通过使用以下特性为每个面障碍设置属性，例如其名称或障碍类型。</para>
		/// <para>Name</para>
		/// <para>障碍名称。</para>
		/// <para>BarrierType</para>
		/// <para>指定障碍是完全禁止通行还是按比例调整穿过成本（例如时间或距离）。 该字段值可指定为以下整数之一（请使用数值代码而非括号中的名称）：</para>
		/// <para>0（限制型）- 禁止穿过障碍的任何部分。 此障碍称作限制型面障碍，因为它禁止在与障碍相交的街道上行驶。 此类障碍的一个具体应用是对覆盖街道中某些区域且导致街道无法通行的洪水进行建模。</para>
		/// <para>1（按比例调整成本型）- 根据使用 ScaledTimeFactor 或 ScaledDistanceFactor 字段指定的系数，按比例调整在基础街道上行驶所需的成本（例如行驶时间或距离）。 如果障碍部分覆盖了街道，则会按比例调整行驶时间或行驶距离。 例如，系数 0.25 表示在基础街道上行进的速度是正常速度的四倍。 系数 3.0 表示预期在基础街道上行进相同距离所花费的时间为正常值的三倍。 此障碍类型称为按比例调整成本型面障碍。 可用于对导致特定区域的行进速度减慢的暴风雨进行建模。</para>
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
		public object PolygonBarriers { get; set; }

		/// <summary>
		/// <para>Use Hierarchy</para>
		/// <para>指定在查找停靠点间的最短路径时是否使用等级。</para>
		/// <para>选中（在 Python 中为 True）- 查找路径时将使用等级。 在应用等级时，相比低等级的街道（例如地方道路），该工具会优先标识等级较高的街道（例如高速公路），且该工具可以用于模拟驾驶员对在高速公路（而非地方道路）上行驶的偏好，即使这意味着行程更远。 查找远距离位置的路径时尤为有用，因为长途驾驶员往往更偏好于在高速公路上行驶，这样可以避免停靠、交叉路口和转弯。 应用等级可实现更快的计算速度，尤其是对于长途路径来说，因为该工具需要在相对较小的街道子集中标识最佳路径。</para>
		/// <para>未选中（在 Python 中为 False）- 查找路径时不会使用等级。 如果没有应用等级，该工具就会考虑所有的街道且在选择路线时并不一定标识等级较高的街道。 常用于在市内查找短路径。</para>
		/// <para>如果设施点和请求点间的直线距离大于 50 英里（80.46 公里），即使未选中此参数（在 Python 中设置为 False），工具也会自动恢复为使用等级。</para>
		/// <para>除非将出行模式设置为自定义，否则会忽略此参数。 对自定义步行模式进行建模时，建议关闭等级，因为该等级专用于机动车辆。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Custom Travel Mode")]
		public object UseHierarchy { get; set; } = "true";

		/// <summary>
		/// <para>Restrictions</para>
		/// <para>在查找最佳路径时工具将遵从的限制。</para>
		/// <para>限制表示行驶偏好或要求。 大多数情况下，限制条件会导致道路禁行。 例如，使用“避开收费公路”限制将导致路径仅在需要借道收费公路才能访问某一事件点或设施点时包含收费公路。 高度限制则使您可以绕开低于车辆高度的间隙。 如果车辆上装载着腐蚀性物质，使用“禁止任何危险物品”限制将防止在标记着运输腐蚀性材料为非法行为的路上运输这些材料。</para>
		/// <para>除非将出行模式设置为自定义，否则会忽略您为此参数提供的值。</para>
		/// <para>某些限制需要指定一个额外值才能进行使用。 该值必须与限制名称和用于限制的特定参数相关联。 可识别名称在属性参数值参数的 AttributeName 列中显示的限制。 查找可遍历道路时，要正确使用限制，应在属性参数值参数中指定 ParameterValue 字段。</para>
		/// <para>有些限制仅适用于某些国家/地区；下表按区域显示了这些限制的可用性。 对于在某区域内可用性有限的限制，可查看网络分析覆盖范围的“国家/地区列表”部分中的表，确定限制在特定国家/地区是否可用。 如果国家/地区的“物流属性”列的值为是，则该国家/地区支持具有区域可选性的限制。 如果您指定的限制名称在事件点所在的国家/地区不可用，该服务会忽略无效限制。 该服务还会忽略限制用法属性参数值介于 0 到 1（请参阅属性参数值参数）之间的限制。 它会禁止限制用法参数值大于 0 的所有限制。</para>
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
		/// <para>主销到后轴长度限制—结果将不包含车辆长度超出路上所有货车所允许的主销到后轴最大长度的道路。 可使用车辆中心立轴-后轴长度（单位为米）限制参数指定车辆中心立轴与后轴之间的长度。可用性：在北美洲及欧洲选择国家</para>
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
		public object Restrictions { get; set; } = "'Avoid Carpool Roads';'Avoid Express Lanes';'Avoid Gates';'Avoid Private Roads';'Avoid Unpaved Roads';'Driving an Automobile';'Roads Under Construction Prohibited';'Through Traffic Prohibited'";

		/// <summary>
		/// <para>Attribute Parameter Values</para>
		/// <para>使用此参数可指定属性或限制条件所需的其他值，例如，指定限制对在受限道路上行驶是禁止、避免还是首选。 如果该限制要避免或首选道路，您可以使用此参数进一步指定要避免或首选的程度。 例如，您可以选择从不使用收费公路，尽可能的避开它们，或首选它们。</para>
		/// <para>除非将出行模式设置为自定义，否则会忽略您为此参数提供的值。</para>
		/// <para>如果指定了要素类的属性参数值参数，则要素类上的字段名称必须与以下字段相匹配：</para>
		/// <para>AttributeName- 限制的名称。</para>
		/// <para>ParameterName- 与限制关联的参数名称。 限制根据其用途可具有一个或多个 ParameterName 字段值。</para>
		/// <para>ParameterValue- 工具在评估限制时使用的 ParameterName 的值。</para>
		/// <para>属性参数值参数取决于限制参数。 仅当限制名称指定为限制参数值时，ParameterValue 字段才适用。</para>
		/// <para>在属性参数值中，每个限制（以 AttributeName 形式列出）具有一个 ParameterName 字段值，指定限制的行程是禁止、避免还是首选的限制用法与道路选择避免或首选的限制和程度相关联。 可为限制用法 ParameterName 分配下列字符串值，或在括号内列出等效数值：</para>
		/// <para>PROHIBITED (-1) - 完全禁止在使用限制的道路上行驶。</para>
		/// <para>AVOID_HIGH (5) - 工具极不可能将与限制相关的道路包括在路径中。</para>
		/// <para>AVOID_MEDIUM (2) - 工具不可能将与限制相关的道路包括在路径中。</para>
		/// <para>AVOID_LOW (1.3) - 工具不太可能将与限制相关的道路包括在路径中。</para>
		/// <para>PREFER_LOW (0.8) - 工具稍微有可能将与限制相关的道路包括在路径中。</para>
		/// <para>PREFER_MEDIUM (0.5) - 工具可能将与限制相关的道路包括在路径中。</para>
		/// <para>PREFER_HIGH (0.2) - 工具非常有可能将与限制相关的道路包括在路径中。</para>
		/// <para>大多数情况下，如果限制取决于车辆高度等车辆特征，则可以将“限制用法”设置为默认值 PROHIBITED。 但是在某些情况下，“限制用法”值取决于您的路径偏好。 例如，“避开收费公路”限制将“限制用法”参数设置为默认值 AVOID_MEDIUM。 这表示在使用限制时，在可能的情况下工具会试图绕开收费公路。 AVOID_MEDIUM 也表示查找最佳路径时避开收费公路的重要性，即优先级为中等。 选择 AVOID_LOW 会降低避开收费公路的重要性；而选择 AVOID_HIGH 则会增加其重要性，因此服务为避开收费公路而生成更长的路径时更容易为人所接受。 选择 PROHIBITED 则会完全不允许在收费公路上行驶，因此路径不可能经过收费公路的所有部分。 但是请注意，避开或禁止收费公路并由此避开公路通行费只是一部分人的目的。 对另外一部分人来说，因为避开拥堵的交通比交一些公路通行费更为重要，会宁愿走收费公路。 在后一种情况中，选择 PREFER_LOW、PREFER_MEDIUM 或 PREFER_HIGH 作为“限制用法”的值。 首选的等级越高，工具为了在与限制相关的道路上行驶就会绕行更远的路程。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRecordSet()]
		[Category("Custom Travel Mode")]
		public object AttributeParameterValues { get; set; }

		/// <summary>
		/// <para>Route Shape</para>
		/// <para>指定工具输出的路径要素的类型。</para>
		/// <para>实际形状—返回基于基础街道所生成的路径的精确形状。</para>
		/// <para>具有测量值的实际形状—返回基于基础街道所生成的路径的精确形状。 此外，会对该形状进行测量以便其可用于线性参考中。 测量值从第一个停靠点开始增加，并以测量单位参数所指定的单位来记录累积行驶时间或累积行驶距离。</para>
		/// <para>直线—返回两个停靠点之间的一条直线。</para>
		/// <para>无—不返回任何路径形状。 此值在您只想确定路径的总行程时间或行程距离时十分有用，并可以快速返回结果。</para>
		/// <para>当路径形状参数设置为实际形状或具有测量值的实际形状时，可以使用适当的路线简化容差参数值对路径形状的制图综合进行进一步控制。</para>
		/// <para>无论为路径形状参数选择哪个值，最佳路径始终通过最大限度地缩短行驶时间或行驶距离来确定，从不使用停靠点间的直线距离进行确定。 这意味着只有路径形状是不同的，而非查找路径时搜索的基础街道。</para>
		/// <para><see cref="RouteShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object RouteShape { get; set; } = "True Shape";

		/// <summary>
		/// <para>Route Line Simplification Tolerance</para>
		/// <para>指定要对路径、方向和路径边的输出线几何进行简化的程度。</para>
		/// <para>如果路径形状参数未设置为实际形状，则工具将忽略此参数。</para>
		/// <para>简化将保留路径上定义路径基本形状所需的关键点（例如交点处的转弯）而删除其他点。 指定的简化距离为简化线偏离原始线的最大允许偏移。 简化线将减少路径几何中的折点数。 这可改善工具执行时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Custom Travel Mode")]
		public object RouteLineSimplificationTolerance { get; set; } = "10 Meters";

		/// <summary>
		/// <para>Populate Route Edges</para>
		/// <para>指定工具是否将为每条路径生成边。路径边表示路径所遍历的各个街道要素或其他相似要素。输出路径边图层通常用于查看生成的路径在哪些街道或路径上行驶得最多或最少。</para>
		/// <para>选中 (True) - 将生成路径边。输出路径边图层将由线要素填充。</para>
		/// <para>未选中 (False) - 将不会生成路径边。返回输出路径边图层，但该图层为空。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Output")]
		public object PopulateRouteEdges { get; set; } = "false";

		/// <summary>
		/// <para>Populate Directions</para>
		/// <para>指定工具是否将为每条路径生成行驶方向。</para>
		/// <para>选中（在 Python 中为 True）- 将根据方向语言、方向样式名称和方向距离单位参数值生成和配置方向。</para>
		/// <para>未选中（在 Python 中为 False）- 将不会生成方向，且工具将返回一个空的 Directions 图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Output")]
		public object PopulateDirections { get; set; } = "true";

		/// <summary>
		/// <para>Directions Language</para>
		/// <para>在生成行驶方向时使用的语言。</para>
		/// <para>此参数仅在选中填充方向参数（在 Python 中为 True）时使用。</para>
		/// <para>可使用下列两位或五位字符语言代码指定参数值：</para>
		/// <para>ar - 阿拉伯语</para>
		/// <para>bs - 波斯尼亚语</para>
		/// <para>ca - 加泰罗尼亚语</para>
		/// <para>cs - 捷克语</para>
		/// <para>da - 丹麦语</para>
		/// <para>de - 德语</para>
		/// <para>el - 希腊语</para>
		/// <para>en - 英语</para>
		/// <para>es - 西班牙语</para>
		/// <para>et - 爱沙尼亚语</para>
		/// <para>fi - 芬兰语</para>
		/// <para>fr - 法语</para>
		/// <para>he - 希伯来语</para>
		/// <para>hr - 克罗地亚语</para>
		/// <para>hu - 匈牙利语</para>
		/// <para>id - 印度尼西亚语</para>
		/// <para>it - 意大利语</para>
		/// <para>ja - 日语</para>
		/// <para>ko - 朝鲜语</para>
		/// <para>lt - 立陶宛语</para>
		/// <para>lv - 拉脱维亚语</para>
		/// <para>nb - 挪威语</para>
		/// <para>nl - 荷兰语</para>
		/// <para>pl - 波兰语</para>
		/// <para>pt-BR - 巴西葡萄牙语</para>
		/// <para>pt-PT - 欧洲葡萄牙语</para>
		/// <para>ro - 罗马尼亚语</para>
		/// <para>ru - 俄语</para>
		/// <para>sl - 斯洛文尼亚语</para>
		/// <para>sr - 塞尔维亚语</para>
		/// <para>sv - 瑞典语</para>
		/// <para>th - 泰语</para>
		/// <para>tr - 土耳其语</para>
		/// <para>uk - 乌克兰语</para>
		/// <para>vi - 越南语</para>
		/// <para>zh-CN - 简体中文</para>
		/// <para>zh-HK - 繁体中文（香港）</para>
		/// <para>zh-TW - 繁体中文（台湾）</para>
		/// <para>工具首先在全部本地化语言中搜索与指定值完全匹配的语言。 如果未找到完全匹配，则会尝试匹配语系。 如果仍未找到匹配，该工具将会使用默认语言（英语）返回方向。 例如，如果将方向指示语言指定为 es-MX（墨西哥西班牙语），则工具将返回西班牙语的指示，因为它支持 es 语言代码但不支持 es-MX。</para>
		/// <para>如果某种语言支持本地化，例如巴西葡萄牙语 (pt-BR) 和欧洲葡萄牙语 (pt-PT)，则指定语系和本地化。 如果您只指定语系，则工具将无法与具体语系匹配，而使用默认语言（英语）返回方向。 例如，如果方向语言指定为 pt，则工具将返回英文指示，因为它无法确定应该使用 pt-BR 还是 pt-PT 返回方向。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Output")]
		public object DirectionsLanguage { get; set; } = "en";

		/// <summary>
		/// <para>Directions Distance Units</para>
		/// <para>指定在行驶方向上显示行驶距离时使用的单位。 此参数仅在选中填充方向参数（在 Python 中为 True）时使用。</para>
		/// <para>英里—线性单位为英里。</para>
		/// <para>千米—线性单位为千米。</para>
		/// <para>米—线性单位为米。</para>
		/// <para>英尺—线性单位为英尺。</para>
		/// <para>码—线性单位为码。</para>
		/// <para>海里—线性单位为海里。</para>
		/// <para><see cref="DirectionsDistanceUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object DirectionsDistanceUnits { get; set; } = "Miles";

		/// <summary>
		/// <para>Directions Style Name</para>
		/// <para>指定方向的格式化样式的名称。 此参数仅在选中填充方向参数（在 Python 中为 True）时使用。</para>
		/// <para>Network Analyst Desktop—适合打印的转弯说明。</para>
		/// <para>Network Analyst 导航—针对车辆内导航设备设计的转弯方向。</para>
		/// <para><see cref="DirectionsStyleNameEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object DirectionsStyleName { get; set; } = "NA Desktop";

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>用于在分析中建模的交通模式。 出行模式在 ArcGIS Online 中进行管理，组织管理员可通过对其进行配置，以反映组织工作流。 您需要指定组织所支持的出行模式的名称。</para>
		/// <para>获取受支持出行模式名称的列表，请使用与访问此工具时使用的相同 GIS 服务器连接，并在实用程序工具箱中运行 GetTravelModes 工具。 GetTravelModes 会将“支持的出行模式”表添加到应用程序中。 可将“支持的出行模式”表中 Travel Mode Name 字段的任何值指定为输入。 您还可以将 Travel Mode Settings 字段中的值指定为输入。 这将缩短工具执行时间，因为工具无需根据出行模式名称查找设置。</para>
		/// <para>默认值，自定义，可以使用自定义出行模式参数（在交汇点处 U 形转弯、应用等级、限制、属性参数值和阻抗）配置您自己的出行模式。 自定义出行模式参数的默认值对使用汽车的出行方式建模。 也可以选择自定义并设置上述自定义出行模式参数，从而以快速步行速度对行人建模，或以给定高度、重量和特定危险材料货物对卡车建模。 您可以尝试不同的设置以获取所需的分析结果。 一旦确定了分析设置，则可使用组织管理员身份并将这些设置保存为新建或现有出行模式的一部分，以便您组织中的所有人均运行相同设置的分析。</para>
		/// <para>选择自定义后，您为自定义出行模式参数设置的值便会包含在分析中。 指定您组织定义的其他出行模式，将忽略为自定义出行模式参数设置的所有值；该工具将用您所指定的出行模式中的值将其覆盖。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object TravelMode { get; set; } = "Custom";

		/// <summary>
		/// <para>Impedance</para>
		/// <para>指定阻抗，该值表示沿交通网络的路段或其他部分行进所需的精力或成本。</para>
		/// <para>行程时间是一种阻抗，比如，汽车花费 1 分钟沿空无一人的道路行驶一公里。 行程时间会随出行模式的不同而不同（行人可能需要 20 多分钟才能走完一公里），所以在建模时为出行模式选择正确的阻抗非常重要。</para>
		/// <para>行程距离也是一种阻抗，可将以千米表示的道路长度作为阻抗。 从这个意义上，行程距离对所有模式均相同，即对行人而言 1 千米的距离对汽车而言也是 1 千米。 （但不同模式所允许行进的线路可能会有变化，而这会影响两点间的距离，可通过出行模式设置对此进行建模。）</para>
		/// <para>除非将出行模式设置为自定义（这是默认值），否则会忽略您为此参数提供的值。</para>
		/// <para>从以下阻抗值中进行选择：</para>
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
		/// <para>如果选择基于时间的阻抗（例如 TravelTime、TruckTravelTime、Minutes、TruckMinutes 或 WalkTime），则必须将测量单位参数设置为基于时间的值。 如果您选择基于距离的阻抗（例如 Miles 或 Kilometers），则测量单位必须基于距离。</para>
		/// <para>不再支持行驶时间、卡车时间、步行时间和行驶距离阻抗值，且将在未来版本中删除。 如果您使用上述任一值，则工具将为基于时间的值使用时间阻抗参数，为基于距离的值使用距离阻抗参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object Impedance { get; set; } = "Drive Time";

		/// <summary>
		/// <para>Time Zone for Time Windows</para>
		/// <para>指定停靠点的时间窗值的时区。时间窗被指定为停靠点上 TimeWindowStart 和 TimeWindowEnd 字段的一部分。此参数仅在选中应用时间窗参数（或设置为 True）时可用。</para>
		/// <para>本地地理位置—与停靠点相关的时间窗值位于停靠点所在的时区内。 例如，如果停靠点所在的区域实行东部标准时间并且时间窗值为 8 AM 和 10 AM，则在东部标准时间中时间窗值将被视为 8 AM 和 10 AM。 这是默认设置。</para>
		/// <para>UTC—与停靠点有关的时间窗值采用协调世界时间 (UTC)。 例如，如果停靠点所在的区域实行东部标准时间并且时间窗值为 8 AM 和 10 AM，则在东部标准时间中时间窗值将被视为 12 p.m 和 2 p.m（假设东部标准时间遵循夏令时）。 如果不知道停靠点所在的时区，或者停靠点处在多个时区内并且您想要所有的时间窗同时启动，那么在 UTC 中指定时间窗值则非常有用。</para>
		/// <para><see cref="TimeZoneForTimeWindowsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Analysis")]
		public object TimeZoneForTimeWindows { get; set; } = "Geographically Local";

		/// <summary>
		/// <para>Save Output Network Analysis Layer</para>
		/// <para>指定是否将分析设置另存为网络分析图层文件。 即使在 ArcGIS Desktop 应用程序（例如 ArcMap）中打开文件，仍然无法直接使用此文件。 需要将其发送至 Esri 技术支持以诊断工具所返回结果的质量。</para>
		/// <para>选中（在 Python 中为 True）- 输出将另存为网络分析图层文件。 文件将下载到计算机上的临时目录中。 在 ArcGIS Pro 中，可以通过查看输出网络分析图层参数的值来确定已下载文件的位置，该参数位于与工程地理处理历史中的工具执行相对应的条目中。 在 ArcMap 中，可以通过访问输出网络分析图层参数上的快捷菜单中的复制位置选项来确定文件的位置，该参数位于与地理处理结果窗口中的工具执行对应的条目中。</para>
		/// <para>未选中（在 Python 中为 False）- 输出不会另存为网络分析图层文件。 这是默认设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Output")]
		public object SaveOutputNetworkAnalysisLayer { get; set; } = "false";

		/// <summary>
		/// <para>Overrides</para>
		/// <para>求解网络分析问题时，可影响求解程序行为的其他设置。</para>
		/// <para>必须在 JavaScript 对象表示法 (JSON) 中指定此参数的值。 例如，有效值的格式如下：{&quot;overrideSetting1&quot; : &quot;value1&quot;, &quot;overrideSetting2&quot; : &quot;value2&quot;}。 覆盖设置名称始终以双引号括起。 该值可以是数字、布尔值或字符串。</para>
		/// <para>此参数的默认值为无值，表示不覆盖任何求解程序设置。</para>
		/// <para>覆盖是高级设置，应仅在谨慎分析应用设置前后得到的结果之后使用。 要获取每个求解器支持的覆盖设置及其可接受值的列表，请联系 Esri 技术支持。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced Analysis")]
		public object Overrides { get; set; }

		/// <summary>
		/// <para>Save Route Data</para>
		/// <para>指定输出中是否包括含有某类文件地理数据库的 .zip 文件，该类文件地理数据库通过可与 ArcGIS Online 或 Portal for ArcGIS 共享路径图层的格式保存分析的输入和输出。</para>
		/// <para>选中（在 Python 中为 True）- 路径数据将另存为为 .zip 文件。 文件将下载到计算机上的临时目录中。 在 ArcGIS Pro 中，可以通过查看输出路径数据参数的值来确定已下载文件的位置，该参数位于与工程地理处理历史中的工具执行相对应的条目中。 在 ArcMap 中，可以通过访问输出路径数据参数上的快捷菜单中的复制位置选项来确定文件的位置，该参数位于与地理处理结果窗口中的工具执行对应的条目中。</para>
		/// <para>未选中（在 Python 中为 False）- 路径数据将不会另存为 .zip 文件。 这是默认设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Output")]
		public object SaveRouteData { get; set; } = "false";

		/// <summary>
		/// <para>Time Impedance</para>
		/// <para>如果使用阻抗参数指定的出行模式阻抗是基于时间的，则时间阻抗和阻抗参数的值必须相同。 否则，服务将返回错误。</para>
		/// <para><see cref="TimeImpedanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object TimeImpedance { get; set; } = "TravelTime";

		/// <summary>
		/// <para>Distance Impedance</para>
		/// <para>如果使用阻抗参数指定的出行模式阻抗是基于距离的，则距离阻抗和阻抗参数的值必须相同。 否则，服务将返回错误。</para>
		/// <para><see cref="DistanceImpedanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object DistanceImpedance { get; set; } = "Kilometers";

		/// <summary>
		/// <para>Output Format</para>
		/// <para>指定创建输出要素时使用的格式。</para>
		/// <para>要素集—输出要素将作为要素类和表返回。 这是默认设置。</para>
		/// <para>JSON 文件—输出要素将作为包含输出的 JSON 表示的压缩文件返回。 指定此选项时，输出将是包含由服务针对每个输出创建的一个或多个 JSON 文件（扩展名为 .zip）的单个文件（扩展名为 .json）。</para>
		/// <para>GeoJSON 文件—输出要素将作为包含输出的 GeoJSON 表示的压缩文件返回。 指定此选项时，输出将是包含由服务针对每个输出创建的一个或多个 GeoJSON 文件（扩展名为 .zip）的单个文件（扩展名为 .geojson）。</para>
		/// <para>如果指定基于文件的输出格式（如 JSON 文件或 GeoJSON 文件），则不会向显示添加输出，因为应用程序（例如 ArcMap 或 ArcGIS Pro）无法绘制结果文件的内容。 相反，结果文件将下载到计算机上的临时目录中。 在 ArcGIS Pro 中，可以通过查看输出结果文件参数的值来确定已下载文件的位置，该参数位于与工程地理处理历史中的工具执行相对应的条目中。 在 ArcMap 中，可以通过访问输出结果文件参数上的快捷菜单中的复制位置选项来确定文件的位置，该参数位于与地理处理结果窗口中的工具执行对应的条目中。</para>
		/// <para><see cref="OutputFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object OutputFormat { get; set; } = "Feature Set";

		/// <summary>
		/// <para>Ignore Invalid Locations</para>
		/// <para>指定是否忽略无效的输入位置。</para>
		/// <para>选中 - 将忽略未定位的网络位置，并且将仅使用有效网络位置运行分析。 如果这些位置位于不可遍历的元素上或有其他错误，则分析仍会继续进行。 如果您知道您的网络位置并不完全正确，但是想对有效的网络位置运行分析，此选项很有用。 这是默认设置。</para>
		/// <para>未选中 - 不会忽略无效位置。 如果存在无效位置，请勿运行分析。 更正无效位置，然后重新运行分析。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Network Locations")]
		public object IgnoreInvalidLocations { get; set; } = "true";

		/// <summary>
		/// <para>Solve Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object SolveSucceeded { get; set; }

		/// <summary>
		/// <para>Output Routes</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object OutputRoutes { get; set; }

		/// <summary>
		/// <para>Output Route Edges</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object OutputRouteEdges { get; set; }

		/// <summary>
		/// <para>Output Directions</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object OutputDirections { get; set; }

		/// <summary>
		/// <para>Output Stops</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object OutputStops { get; set; }

		/// <summary>
		/// <para>Output Network Analysis Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object OutputNetworkAnalysisLayer { get; set; } = "scratchfile";

		/// <summary>
		/// <para>Output Route Data</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object OutputRouteData { get; set; } = "scratchfile";

		/// <summary>
		/// <para>Output Result File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object OutputResultFile { get; set; } = "scratchfile";

		/// <summary>
		/// <para>Output Network Analysis Layer Package</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object OutputNetworkAnalysisLayerPackage { get; set; } = "scratchfile";

		/// <summary>
		/// <para>Output Direction Points</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object OutputDirectionPoints { get; set; }

		/// <summary>
		/// <para>Output Direction Lines</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object OutputDirectionLines { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Measurement Units</para>
		/// </summary>
		public enum MeasurementUnitsEnum 
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
		/// <para>Preserve Terminal Stops</para>
		/// </summary>
		public enum PreserveTerminalStopsEnum 
		{
			/// <summary>
			/// <para>保留第一个—该工具不会对第一个停靠点进行重新排序。 如果从已知位置开始，例如您的主页、总部或当前位置，请选择此选项。</para>
			/// </summary>
			[GPValue("Preserve First")]
			[Description("保留第一个")]
			Preserve_First,

			/// <summary>
			/// <para>保留最后一个—该工具不会对最后一个停靠点进行重新排序。 输出路径可以从任何停靠点要素开始，但必须在预先确定的最后一个停靠点结束。</para>
			/// </summary>
			[GPValue("Preserve Last")]
			[Description("保留最后一个")]
			Preserve_Last,

			/// <summary>
			/// <para>保留第一个和最后一个—该工具不会对第一个和最后一个停靠点进行重新排序。</para>
			/// </summary>
			[GPValue("Preserve First and Last")]
			[Description("保留第一个和最后一个")]
			Preserve_First_and_Last,

			/// <summary>
			/// <para>不保留—该工具可以对任意停靠点进行重新排序，包括第一个和最后一个停靠点。 路径可能从任一停靠点要素开始或在任一停靠点结束。</para>
			/// </summary>
			[GPValue("Preserve None")]
			[Description("不保留")]
			Preserve_None,

		}

		/// <summary>
		/// <para>Time Zone for Time of Day</para>
		/// </summary>
		public enum TimeZoneForTimeOfDayEnum 
		{
			/// <summary>
			/// <para>本地地理位置—时间参数采用路径的第一个停靠点处的时区。 如果生成开始于多个时区的多个路径，则开始时间会采用协调世界时间 (UTC) 交错。 例如，时间值为 1 月 2 日 10:00 a.m.， 表示始于东部时区的路径的开始时间为东部标准时间 10:00 a.m. (UTC-3:00)，始于中部时区的路径的开始时间为中部标准时间 10:00 a.m. (UTC-4:00)。 开始时间偏差一小时（UTC 时间）。 输出停靠点要素类中记录的到达与离开的时间和日期将采用每个路径第一个停靠点的本地时区。</para>
			/// </summary>
			[GPValue("Geographically Local")]
			[Description("本地地理位置")]
			Geographically_Local,

			/// <summary>
			/// <para>UTC—时间参数指 UTC。 如果您想要在特定的时间（如现在）生成路径，但不确定第一个停靠点所在的时区，请选择此选项。 如果您生成跨越多个时区的多个路径，以 UTC 表示的开始时间将发生同步。 例如，时间值为 1 月 2 日 10:00 a.m.， 表示始于东部时区的路径的开始时间为东部标准时间 5:00 a.m. (UTC-5:00)，始于中部时区的路径的开始时间为中部标准时间 4:00 a.m. (UTC-6:00)。 这两个路径均于 10:00 a.m. UTC. 输出停靠点要素类中记录的到达与离开的时间和日期将参考 UTC。</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

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
		/// <para>Route Shape</para>
		/// </summary>
		public enum RouteShapeEnum 
		{
			/// <summary>
			/// <para>实际形状—返回基于基础街道所生成的路径的精确形状。</para>
			/// </summary>
			[GPValue("True Shape")]
			[Description("实际形状")]
			True_Shape,

			/// <summary>
			/// <para>具有测量值的实际形状—返回基于基础街道所生成的路径的精确形状。 此外，会对该形状进行测量以便其可用于线性参考中。 测量值从第一个停靠点开始增加，并以测量单位参数所指定的单位来记录累积行驶时间或累积行驶距离。</para>
			/// </summary>
			[GPValue("True Shape with Measures")]
			[Description("具有测量值的实际形状")]
			True_Shape_with_Measures,

			/// <summary>
			/// <para>直线—返回两个停靠点之间的一条直线。</para>
			/// </summary>
			[GPValue("Straight Line")]
			[Description("直线")]
			Straight_Line,

			/// <summary>
			/// <para>无—不返回任何路径形状。 此值在您只想确定路径的总行程时间或行程距离时十分有用，并可以快速返回结果。</para>
			/// </summary>
			[GPValue("None")]
			[Description("无")]
			None,

		}

		/// <summary>
		/// <para>Directions Distance Units</para>
		/// </summary>
		public enum DirectionsDistanceUnitsEnum 
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

		}

		/// <summary>
		/// <para>Directions Style Name</para>
		/// </summary>
		public enum DirectionsStyleNameEnum 
		{
			/// <summary>
			/// <para>Network Analyst Desktop—适合打印的转弯说明。</para>
			/// </summary>
			[GPValue("NA Desktop")]
			[Description("Network Analyst Desktop")]
			Network_Analyst_Desktop,

			/// <summary>
			/// <para>Network Analyst 导航—针对车辆内导航设备设计的转弯方向。</para>
			/// </summary>
			[GPValue("NA Navigation")]
			[Description("Network Analyst 导航")]
			Network_Analyst_Navigation,

		}

		/// <summary>
		/// <para>Time Zone for Time Windows</para>
		/// </summary>
		public enum TimeZoneForTimeWindowsEnum 
		{
			/// <summary>
			/// <para>本地地理位置—与停靠点相关的时间窗值位于停靠点所在的时区内。 例如，如果停靠点所在的区域实行东部标准时间并且时间窗值为 8 AM 和 10 AM，则在东部标准时间中时间窗值将被视为 8 AM 和 10 AM。 这是默认设置。</para>
			/// </summary>
			[GPValue("Geographically Local")]
			[Description("本地地理位置")]
			Geographically_Local,

			/// <summary>
			/// <para>UTC—与停靠点有关的时间窗值采用协调世界时间 (UTC)。 例如，如果停靠点所在的区域实行东部标准时间并且时间窗值为 8 AM 和 10 AM，则在东部标准时间中时间窗值将被视为 12 p.m 和 2 p.m（假设东部标准时间遵循夏令时）。 如果不知道停靠点所在的时区，或者停靠点处在多个时区内并且您想要所有的时间窗同时启动，那么在 UTC 中指定时间窗值则非常有用。</para>
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
