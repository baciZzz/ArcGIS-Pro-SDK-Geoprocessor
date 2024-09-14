using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkAnalystTools
{
	/// <summary>
	/// <para>Solve Vehicle Routing Problem</para>
	/// <para>求解车辆配送问题</para>
	/// <para>创建车辆配送问题 (VRP) 网络分析图层，设置分析属性，并求解分析，是设置 VRP Web 服务的理想手段。VRP 分析图层用于查找车队的最佳路径。</para>
	/// </summary>
	[Obsolete()]
	public class SolveVehicleRoutingProblem : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Orders">
		/// <para>Orders</para>
		/// <para>在交互访问的情况下，停靠点可同时具有配送量和接收量。</para>
		/// </param>
		/// <param name="Depots">
		/// <para>Depots</para>
		/// <para>站点是指车辆在工作时间开始时离开并在工作时间结束后返回的位置。在求解路径开始时，车辆在站点装货（对于配送）或卸货（对于接收）。在某些情况下，站点还可以作为一个货物补给或货物更新的位置，车辆可以在此处卸货或重新装货，然后继续进行配送和接收。站点具有打开时间和关闭时间，这由硬性时间窗指定。车辆不能在该时间窗以外的时刻到达站点。</para>
		/// <para>站点要素集具有一个关联的属性表。下面列出并描述了属性表中的字段。</para>
		/// <para>ObjectID：</para>
		/// <para>系统管理的 ID 字段。</para>
		/// <para>Shape：</para>
		/// <para>指示网络分析对象地理位置的几何字段。</para>
		/// <para>Name：</para>
		/// <para>站点的名称。路径记录集的 StartDepotName 和 EndDepotName 字段引用了您在此处指定的名称。使用路径货物补给点记录集时，也会对其进行引用。</para>
		/// <para>站点名称不区分大小写，但必须非空且唯一。</para>
		/// <para>TimeWindowStart1：</para>
		/// <para>网络位置的第一时间窗开始时间。该字段可以包含空值；空值指示没有开始时间。</para>
		/// <para>时间窗字段可以包含只有时间的值，也可以包含同时具有日期和时间的值。如果时间字段是一个只具有时间的值（例如，8:00 a.m.），则假定日期为分析图层的默认日期参数所指定的日期。使用“日期和时间”值（例如 7/11/2010 8:00 a.m.）允许您设置持续多天的时间窗。</para>
		/// <para>当任一时间窗字段包含当时的日期时，将忽略默认日期。为避免在此种情况下出现错误，设置站点、路径、停靠点和休息点的所有时间窗的格式以包含当时的日期。</para>
		/// <para>如果正在使用流量数据，则网络位置的时间字段始终会引用与网络位置所在的边相同的时区。</para>
		/// <para>TimeWindowEnd1：</para>
		/// <para>网络位置的第一时间窗结束时间。该字段可以包含空值；空值指示没有结束时间。</para>
		/// <para>TimeWindowStart2：</para>
		/// <para>网络位置的第二时间窗开始时间。该字段可以包含空值；空值指示没有第二时间窗。</para>
		/// <para>如果第一时间窗为空，正如 TimeWindowStart1 和 TimeWindowEnd1 字段所指定的那样，则第二时间窗也必须为空。</para>
		/// <para>如果两个时间窗都为非空，则二者不可以重叠。而且，第二个时间窗必须在第一个之后出现。</para>
		/// <para>TimeWindowEnd2：</para>
		/// <para>网络位置的第二时间窗结束时间。该字段可以包含空值。</para>
		/// <para>如果 TimeWindowStart2 和 TimeWindowEnd2 均为空，则不存在第二时间窗。</para>
		/// <para>如果 TimeWindowStart2 不为空，但是 TimeWindowEnd2 为空，则存在具有开始时间但没有结束时间的第二时间窗。这种情况是有效的。</para>
		/// <para>CurbApproach：</para>
		/// <para>CurbApproach 属性指定了车辆到达和离开网络位置的方向。有四种选择（其编码值显示在圆括号中）：</para>
		/// <para>车辆的任意一侧 (0) - 车辆可从两个方向中的任一方向到达和离开网络位置。允许 U 形转弯。如果车辆可在停靠点进行 U 形转弯或在驶入车道或停车场后能够调头，则应该选择该设置。</para>
		/// <para>车辆的右侧 (1) - 当车辆到达和离开网络位置时，停靠点必须在车辆右侧。禁止 U 形转弯。</para>
		/// <para>车辆的左侧 (2) - 当车辆到达和离开网络位置时，停靠点必须在车辆左侧。禁止 U 形转弯。</para>
		/// <para>禁止 U 形转弯 (3) - 当车辆到达网络位置时，停靠点可在车辆的任意一侧；但是，车辆在离开时不得调头。</para>
		/// <para>Bearing：</para>
		/// <para>点移动的方向。单位为度，并且从正北方向开始按顺时针方式进行测量。该字段与 BearingTol 字段结合使用。</para>
		/// <para>方位角数据通常会从配有 GPS 接收器的移动设备自动发送。如果正在加载移动的停靠点（例如行人或车辆），则尝试包括方位角数据。</para>
		/// <para>使用该字段可以防止将位置添加到错误的边上，例如，车辆刚好在交叉路口或天桥附近时。方位角也可帮助 Network Analyst 确定点在街道的哪一边上。</para>
		/// <para>有关详细信息，请参阅方位角和 BearingTol。</para>
		/// <para>BearingTol：</para>
		/// <para>使用 Bearing 字段在边上定位移动点时，方位角容差值将创建一个可接受方位角值的范围。如果 Bearing 字段中的值在可接受值范围（由边上的方位角容差生成）内，则可以将该点作为网络位置添加在此处，否则，将计算下一个最近边上的最近点。</para>
		/// <para>单位为度，默认值为 30。值必须大于零且小于 180。</para>
		/// <para>值为 30 表示，Network Analyst 尝试在边上添加网络位置时，在边的每一侧（左侧和右侧）的两个数字化方向上都将生成一个 15º 的可接受方位角值。</para>
		/// <para>有关详细信息，请参阅方位角和 BearingTol。</para>
		/// <para>NavLatency：</para>
		/// <para>如果 Bearing 和 BearingTol 也具有值，则该字段只在求解过程中使用；但是，即使当 Bearing 和 BearingTol 字段中有值时，NavLatency 值的输入也是可选的。NavLatency 表示 GPS 信息从移动的车辆上发送到服务器以及车辆导航设备接收到处理后路径这两个时刻之间预期要经过的时间。NavLatency 的时间单位与时间属性参数指定的成本属性的单位相同。</para>
		/// </param>
		/// <param name="Routes">
		/// <para>Routes</para>
		/// <para>适用于给定车辆配送问题的路径。路径指定了车辆和驾驶员的特征；求解后，路径还表示站点和停靠点之间的路径。</para>
		/// <para>路径可以具有开始和结束站点服务时间、固定或灵活的起始时间、基于时间的运行成本、基于距离的运行成本、多个容量、对驾驶员工作时间的各种约束等等。</para>
		/// <para>路径记录集具有多个属性。下面列出并描述了属性表中的字段。</para>
		/// <para>Name：</para>
		/// <para>路径的名称。名称必须唯一。</para>
		/// <para>如果字段值为空，则 Network Analyst 会在求解时生成唯一的名称。因此，在大多数情况下，可自行选择是否输入值。但是，如果您的分析中包括向路径预分配的休息点、路径货物补给点、按区域配送或停靠点，则您必须输入名称，因为在这些情况下路径名称将用作外键。请注意，路径名称不区分大小写。</para>
		/// <para>StartDepotName：</para>
		/// <para>路径的起始站点名称。该字段是 Depots 中 Name 字段的外键。</para>
		/// <para>如果 StartDepotName 值为空，则路径会将分配的第一个停靠点作为起始点。车辆的起始位置未知或者与您的问题不相关时，可以忽略起始站点。不过，如果 StartDepotName 为空，则 EndDepotName 不能也为空。</para>
		/// <para>如果停靠点或站点跨多个时区，则不允许使用虚拟起始站点。</para>
		/// <para>如果路径正在进行配送并且 StartDepotName 为空，则假设在路径开始前，在一个虚拟站点处进行装货。如果路径不具有货物补给点，它的配送停靠点（“停靠点”类中 DeliveryQuantities 值为非零的停靠点）会在起始站点或虚拟站点处进行装货。如果路径具有更新访问，则只有第一个更新访问之前的配送停靠点才会在起始站点或虚拟站点处进行装货。</para>
		/// <para>EndDepotName：</para>
		/// <para>路径的终止站点名称。该字段是站点参数中 Name 字段的外键。</para>
		/// <para>StartDepotServiceTime：</para>
		/// <para>在起始站点的服务时间。该字段可用于为车辆装货所用的时间建立模型。该字段可以包含空值；空值表示没有服务时间。</para>
		/// <para>该字段值的单位由时间字段单位参数（Python 中的 time_units）指定。</para>
		/// <para>起始和结束站点处的服务时间是固定值（由 StartDepotServiceTime 和 EndDepotServiceTime 字段值指定），因此不必考虑路径的实际载荷。例如，在起始站点处装载车辆所花费的时间取决于订单大小。因此，站点服务时间是与货车满载或货车平均装载对应的指定值，或者也可以设置自行估计的时间值。</para>
		/// <para>EndDepotServiceTime：</para>
		/// <para>在终止站点的服务时间。该字段可用于为车辆卸货所用的时间建立模型。该字段可以包含空值；空值表示没有服务时间。</para>
		/// <para>该字段值的单位由时间字段单位参数（Python 中的 time_units）指定。</para>
		/// <para>起始和结束站点处的服务时间是固定值（由 StartDepotServiceTime 和 EndDepotServiceTime 字段值指定），因此不必考虑路径的实际载荷。例如，在起始站点处装载车辆所花费的时间取决于订单大小。因此，站点服务时间是与货车满载或货车平均装载对应的指定值，或者也可以设置自行估计的时间值。</para>
		/// <para>EarliestStartTime：</para>
		/// <para>路径允许的最早开始时间。求解程序通过将该字段与起始站点的时间窗结合使用来确定可行的路径开始时间。</para>
		/// <para>该字段不能包含空值，其默认值只有时间，为上午 8:00；该默认值被解释为默认日期参数（Python 中的 default_date）所指定日期的上午 8:00。</para>
		/// <para>当任一时间窗字段包含当时的日期时，将忽略默认日期。为避免在此种情况下出现错误，设置站点、路径、停靠点和休息点的所有时间窗的格式以包含当时的日期。</para>
		/// <para>将网络数据集与跨越多个时区的流量数据结合使用时，EarliestStartTime 的时区与起始站点所在的边或交汇点的时区相同。</para>
		/// <para>LatestStartTime：</para>
		/// <para>路径允许的最晚开始时间。该字段不能包含空值，其默认值只有时间，为上午 10:00；该默认值被解释为分析图层的“默认日期”属性所指定日期的上午 10:00。</para>
		/// <para>将网络数据集与跨越多个时区的流量数据结合使用时，LatestStartTime 的时区与起始站点所在的边或交汇点的时区相同。</para>
		/// <para>ArriveDepartDelay</para>
		/// <para>该字段存储将车辆加速到正常行驶速度、减速到停止状态以及离开和进入网络（例如，出入停车场）所需的行驶时间。通过包含 ArriveDepartDelay 值，可防止 VRP 求解程序发送多条路径来为完全重合的停靠点提供服务。</para>
		/// <para>该属性的成本是因为对不重合的停靠点、站点和货物补给点进行访问而产生的。例如，如果路径从站点处开始，然后访问第一个停靠点，则总的到达/离开延迟会计入行驶时间。这同样适用于从第一个停靠点行驶到第二个停靠点的情况。如果第二个停靠点与第三个停靠点重合，则不会在它们之间添加 ArriveDepartDelay 值，因为车辆并不需要移动。如果路径行驶到一个货物补给点，则该值会再次计入行驶时间。</para>
		/// <para>尽管车辆需要减速、停下来休息，然后再加速，但 VRP 求解程序也不能将 ArriveDepartDelay 值计入休息时间。这表示如果路径离开某个停靠点、停下休息，然后继续行驶到下一个停靠点，则仅计入一次到达/离开延迟，而不是两次。</para>
		/// <para>为了说明，假设在一幢高层建筑物中有五个重合停靠点，而且可通过三条不同的路径来为它们提供服务。这意味着将产生三个到达/离开延迟；也就是说，三名驾驶员需要分别寻找停车位并进入同一栋建筑物。不过，如果可以仅通过一条路径来为这些停靠点提供服务，则只有一名驾驶员需要寻找停车位并进入该建筑物，这样只会产生一个到达/离开延迟。由于 VRP 求解程序会尝试将成本降至最低，所以它将尝试限制到达/离开延迟，因而会选择使用单一路径。（请注意，其他约束（例如，特殊要求、时间窗或容量）可能要求发送多条路径。）</para>
		/// <para>该字段值的单位由时间字段单位参数（Python 中的 time_units）指定。</para>
		/// <para>Capacities：</para>
		/// <para>车辆的最大容量。可以按任何度量单位（如重量、体积或数量）来指定容量。也可以指定多个度量单位，例如，重量和体积。</para>
		/// <para>输入未指明单位的容量。例如，假定您车辆的最大载重为 40,000 磅；您可输入 40000。为了用作后续参考，您需要记住该值的单位是磅。</para>
		/// <para>如果您正在追踪的是具有多个维度的对象，请以空格分隔各维度的值。例如，如果您要记录重量和体积，而您的车辆最大载重为 40,000 磅，最大容量为 2,000 立方英尺，则应在 Capacities 中输入 40000 2000。同样地，您需要记住单位。您还需要记住值及其对应单位的输入顺序（在本例中，前者是磅，后者是立方英尺）。</para>
		/// <para>鉴于以下原因，记住单位和单位顺序非常重要：第一，您可以在稍后重新解释信息；第二，您可以在停靠点的 DeliveryQuantities 和 PickupQuantities 字段中输入正确的值。为了详细描述第二点，请注意 VRP 求解程序会同时引用 Capacities、DeliveryQuantities 和 PickupQuantities，以确保路径不会超载。由于字段中不能输入单位，Network Analyst 不能转换单位，因此您需要以相同的单位和单位顺序在这三个字段中输入值，以确保能正确地解释值。如果在这三个字段的任意字段中使用的单位不同或顺序发生变化，那么您将得到意外结果，但不会收到警告消息。因此，事先设置单位和单位顺序标准，并在这三个字段中输入值时始终参考此标准是一个好办法。</para>
		/// <para>空字符串或空值相当于所有值均为零。容量值不能为负数。</para>
		/// <para>如果 Capacities 字符串中值的个数相对于停靠点的 DeliveryQuantities 或 PickupQuantities 字段来说数量不足，则其余的值将被视为零。</para>
		/// <para>VRP 求解程序仅执行简单的布尔测试来判定是否超出容量。如果路径的容量值大于或等于装载总量，则 VRP 求解程序将假定货物适宜用该车辆装载。这可能并不正确，但具体要取决于货物和车辆的实际形状。例如，VRP 求解程序允许将 1000 立方英尺的球形物装到容积为 1000 立方英尺、宽为 8 英尺的货车中。但实际上由于球形物的直径为 12.6 英尺，所以它无法装到 8 英尺宽的货车中。</para>
		/// <para>FixedCost：</para>
		/// <para>仅当解决方案中使用路径（即，路径分配有停靠点）时才产生的固定货币成本。该字段可以包含空值；空值表示没有固定成本。该成本属于路径总运行成本的一部分。</para>
		/// <para>CostPerUnitTime：</para>
		/// <para>路径总持续时间（包括行驶时间以及在停靠点、站点和休息点的服务时间和等待时间）中每单位工作时间产生的货币成本。该字段不能包含空值，其默认值为 1.0。</para>
		/// <para>该字段值的单位由时间字段单位参数（Python 中的 time_units）指定。</para>
		/// <para>CostPerUnitDistance：</para>
		/// <para>路径长度（总行驶距离）中每单位行驶距离产生的货币成本。该字段可以包含空值；空值表示没有成本。</para>
		/// <para>该字段值的单位由距离字段单位参数（Python 的 distance_units）指定。</para>
		/// <para>OvertimeStartTime：</para>
		/// <para>开始计算加班时间之前的规定工作时间。该字段可以包含空值；空值表示没有加班时间。</para>
		/// <para>该字段值的单位由时间字段单位参数（Python 中的 time_units）指定。</para>
		/// <para>例如，如果路径总持续时间超过八小时的时候要为驾驶员支付加班费，假定时间字段单位参数设置为分钟，则 OvertimeStartTime 将被指定为 480（8 小时 * 60 分钟/小时）。</para>
		/// <para>CostPerUnitOvertime：</para>
		/// <para>每单位加班工作时间产生的货币成本。该字段可以包含空值；空值表示 CostPerUnitOvertime 值与 CostPerUnitTime 值相同。</para>
		/// <para>MaxOrderCount：</para>
		/// <para>路径上允许的最大停靠点数。该字段不能包含空值，其默认值为 30。</para>
		/// <para>MaxTotalTime：</para>
		/// <para>允许的最长路径持续时间。路径持续时间包括行驶时间以及在停靠点、站点和休息点的服务和等待时间。该字段可以包含空值；空值表示对路径持续时间无限制。</para>
		/// <para>该字段值的单位由时间字段单位参数（Python 中的 time_units）指定。</para>
		/// <para>MaxTotalTravelTime：</para>
		/// <para>路径允许的最长行驶时间。行驶时间只包括在网络上行驶时所用的时间，不包括服务或等待时间。</para>
		/// <para>该字段可以包含空值；空值表示对允许的最长行驶时间无限制。该字段值不能大于 MaxTotalTime 字段值。</para>
		/// <para>该字段值的单位由时间字段单位参数（Python 中的 time_units）指定。</para>
		/// <para>MaxTotalDistance：</para>
		/// <para>路径允许的最长行驶距离。</para>
		/// <para>该字段值的单位由距离字段单位参数（Python 的 distance_units）指定。</para>
		/// <para>该字段可以包含空值；空值表示对允许的最长行驶距离无限制。</para>
		/// <para>SpecialtyNames：</para>
		/// <para>一个以空格分隔的字符串，其中包含路径所支持的特殊要求的名称。空值表示路径不支持任何特殊要求。</para>
		/// <para>该字段是停靠点参数中 SpecialtyNames 字段的外键。</para>
		/// <para>为了说明什么是特殊要求及其工作方式，假设草坪护理及树木修剪公司都有一部分停靠点需要使用斗式铲车来修剪所有树木。公司将在 SpecialtyNames 字段中为这些停靠点输入 BucketTruck 来表示其特殊要求。对于其他停靠点，SpecialtyNames 将留为空值。同样，公司也可以在带液压吊杆的铲车路径的 SpecialtyNames 字段中输入 BucketTruck。对于其他路径该字段将留为空值。求解时，VRP 求解程序会将无任何特殊要求的停靠点分配给任意路径，而将需要斗式铲车的停靠点分配给有斗式铲车的路径。</para>
		/// <para>AssignmentRule：</para>
		/// <para>该字段指定解决问题时是否可以使用路径。该字段受值的属性域约束，可能的值如下：</para>
		/// <para>Include - 路径包括在求解操作中。这是默认值。</para>
		/// <para>Exclude - 路径被排除在求解操作之外。</para>
		/// </param>
		/// <param name="TimeUnits">
		/// <para>Time Field Units</para>
		/// <para>指定分析中所有基于时间的字段值的时间单位。</para>
		/// <para>秒—秒</para>
		/// <para>分钟—分钟</para>
		/// <para>小时—小时</para>
		/// <para>天—天</para>
		/// <para>VRP 分析中的许多要素和记录都具有用于存储时间值的字段，例如用于停靠点的 ServiceTime 和用于路径的 CostPerUnitTime。为了最大程度减少数据输入的要求，这些字段值不包含单位。相反，所有基于距离的字段值都必须以相同单位输入，而此参数用于指定这些值的单位。</para>
		/// <para>注意，基于时间的输出字段使用此参数指定的相同单位。</para>
		/// <para>此时间单位无需与网络时间属性参数（Python 中的 time_attribute）的时间单位相匹配。</para>
		/// <para><see cref="TimeUnitsEnum"/></para>
		/// </param>
		/// <param name="DistanceUnits">
		/// <para>Distance Field Units</para>
		/// <para>指定分析中所有基于距离的字段值的距离单位。</para>
		/// <para>英里—英里</para>
		/// <para>千米—千米</para>
		/// <para>英尺—英尺</para>
		/// <para>码—码</para>
		/// <para>米—米</para>
		/// <para>海里—海里</para>
		/// <para>VRP 分析中许多要素和记录都有用于存储距离值的字段，例如路径的 MaxTotalDistance 和 CostPerUnitDistance。为了最大程度减少数据输入的要求，这些字段值不包含单位。相反，所有基于距离的字段值都必须以相同单位输入，而此参数用于指定这些值的单位。</para>
		/// <para>注意，基于距离的输出字段使用此参数指定的相同单位。</para>
		/// <para>此距离单位无需与网络距离属性参数（Python 中的 distance attribute）的距离单位相匹配。</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </param>
		/// <param name="NetworkDataset">
		/// <para>Network Dataset</para>
		/// <para>将对其执行车辆配送问题分析的网络数据集。由于 VRP 求解程序要尽量缩短配送时间，因此网络数据集必须具有基于时间的成本属性。</para>
		/// </param>
		/// <param name="OutputWorkspaceLocation">
		/// <para>Output Geodatabase Workspace</para>
		/// <para>将创建输出要素类的文件地理数据库或内存工作空间。此工作空间必须已经存在。默认的输出工作空间为内存。</para>
		/// </param>
		/// <param name="OutputUnassignedStopsName">
		/// <para>Output Unassigned Stops Name</para>
		/// <para>包含任何无法到达站点或未分配停靠点的输出要素类的名称。</para>
		/// </param>
		/// <param name="OutputStopsName">
		/// <para>Output Stops Name</para>
		/// <para>包含了路径所访问的停靠点的要素类的名称。此要素类包含在站点、停靠点及休息点的停靠。</para>
		/// </param>
		/// <param name="OutputRoutesName">
		/// <para>Output Routes Name</para>
		/// <para>包含了分析的路径的要素类的名称。</para>
		/// </param>
		/// <param name="OutputDirectionsName">
		/// <para>Output Directions Name</para>
		/// <para>包含了路径方向的要素类的名称。</para>
		/// </param>
		public SolveVehicleRoutingProblem(object Orders, object Depots, object Routes, object TimeUnits, object DistanceUnits, object NetworkDataset, object OutputWorkspaceLocation, object OutputUnassignedStopsName, object OutputStopsName, object OutputRoutesName, object OutputDirectionsName)
		{
			this.Orders = Orders;
			this.Depots = Depots;
			this.Routes = Routes;
			this.TimeUnits = TimeUnits;
			this.DistanceUnits = DistanceUnits;
			this.NetworkDataset = NetworkDataset;
			this.OutputWorkspaceLocation = OutputWorkspaceLocation;
			this.OutputUnassignedStopsName = OutputUnassignedStopsName;
			this.OutputStopsName = OutputStopsName;
			this.OutputRoutesName = OutputRoutesName;
			this.OutputDirectionsName = OutputDirectionsName;
		}

		/// <summary>
		/// <para>Tool Display Name : 求解车辆配送问题</para>
		/// </summary>
		public override string DisplayName() => "求解车辆配送问题";

		/// <summary>
		/// <para>Tool Name : SolveVehicleRoutingProblem</para>
		/// </summary>
		public override string ToolName() => "SolveVehicleRoutingProblem";

		/// <summary>
		/// <para>Tool Excute Name : na.SolveVehicleRoutingProblem</para>
		/// </summary>
		public override string ExcuteName() => "na.SolveVehicleRoutingProblem";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise() => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Orders, Depots, Routes, Breaks, TimeUnits, DistanceUnits, NetworkDataset, OutputWorkspaceLocation, OutputUnassignedStopsName, OutputStopsName, OutputRoutesName, OutputDirectionsName, DefaultDate, UturnPolicy, TimeWindowFactor, SpatiallyClusterRoutes, RouteZones, RouteRenewals, OrderPairs, ExcessTransitFactor, PointBarriers, LineBarriers, PolygonBarriers, TimeAttribute, DistanceAttribute, UseHierarchyInAnalysis, Restrictions, AttributeParameterValues, MaximumSnapTolerance, ExcludeRestrictedPortionsOfTheNetwork, FeatureLocatorWhereClause, PopulateRouteLines, RouteLineSimplificationTolerance, PopulateDirections, DirectionsLanguage, DirectionsStyleName, SaveOutputLayer, ServiceCapabilities, IgnoreInvalidOrderLocations, TravelMode, SolveSucceeded, OutUnassignedStops, OutStops, OutRoutes, OutDirections, OutNetworkAnalysisLayer, IgnoreNetworkLocationFields, TimeZoneUsageForTimeFields, Overrides, SaveRouteData, OutRouteData };

		/// <summary>
		/// <para>Orders</para>
		/// <para>在交互访问的情况下，停靠点可同时具有配送量和接收量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Orders { get; set; }

		/// <summary>
		/// <para>Depots</para>
		/// <para>站点是指车辆在工作时间开始时离开并在工作时间结束后返回的位置。在求解路径开始时，车辆在站点装货（对于配送）或卸货（对于接收）。在某些情况下，站点还可以作为一个货物补给或货物更新的位置，车辆可以在此处卸货或重新装货，然后继续进行配送和接收。站点具有打开时间和关闭时间，这由硬性时间窗指定。车辆不能在该时间窗以外的时刻到达站点。</para>
		/// <para>站点要素集具有一个关联的属性表。下面列出并描述了属性表中的字段。</para>
		/// <para>ObjectID：</para>
		/// <para>系统管理的 ID 字段。</para>
		/// <para>Shape：</para>
		/// <para>指示网络分析对象地理位置的几何字段。</para>
		/// <para>Name：</para>
		/// <para>站点的名称。路径记录集的 StartDepotName 和 EndDepotName 字段引用了您在此处指定的名称。使用路径货物补给点记录集时，也会对其进行引用。</para>
		/// <para>站点名称不区分大小写，但必须非空且唯一。</para>
		/// <para>TimeWindowStart1：</para>
		/// <para>网络位置的第一时间窗开始时间。该字段可以包含空值；空值指示没有开始时间。</para>
		/// <para>时间窗字段可以包含只有时间的值，也可以包含同时具有日期和时间的值。如果时间字段是一个只具有时间的值（例如，8:00 a.m.），则假定日期为分析图层的默认日期参数所指定的日期。使用“日期和时间”值（例如 7/11/2010 8:00 a.m.）允许您设置持续多天的时间窗。</para>
		/// <para>当任一时间窗字段包含当时的日期时，将忽略默认日期。为避免在此种情况下出现错误，设置站点、路径、停靠点和休息点的所有时间窗的格式以包含当时的日期。</para>
		/// <para>如果正在使用流量数据，则网络位置的时间字段始终会引用与网络位置所在的边相同的时区。</para>
		/// <para>TimeWindowEnd1：</para>
		/// <para>网络位置的第一时间窗结束时间。该字段可以包含空值；空值指示没有结束时间。</para>
		/// <para>TimeWindowStart2：</para>
		/// <para>网络位置的第二时间窗开始时间。该字段可以包含空值；空值指示没有第二时间窗。</para>
		/// <para>如果第一时间窗为空，正如 TimeWindowStart1 和 TimeWindowEnd1 字段所指定的那样，则第二时间窗也必须为空。</para>
		/// <para>如果两个时间窗都为非空，则二者不可以重叠。而且，第二个时间窗必须在第一个之后出现。</para>
		/// <para>TimeWindowEnd2：</para>
		/// <para>网络位置的第二时间窗结束时间。该字段可以包含空值。</para>
		/// <para>如果 TimeWindowStart2 和 TimeWindowEnd2 均为空，则不存在第二时间窗。</para>
		/// <para>如果 TimeWindowStart2 不为空，但是 TimeWindowEnd2 为空，则存在具有开始时间但没有结束时间的第二时间窗。这种情况是有效的。</para>
		/// <para>CurbApproach：</para>
		/// <para>CurbApproach 属性指定了车辆到达和离开网络位置的方向。有四种选择（其编码值显示在圆括号中）：</para>
		/// <para>车辆的任意一侧 (0) - 车辆可从两个方向中的任一方向到达和离开网络位置。允许 U 形转弯。如果车辆可在停靠点进行 U 形转弯或在驶入车道或停车场后能够调头，则应该选择该设置。</para>
		/// <para>车辆的右侧 (1) - 当车辆到达和离开网络位置时，停靠点必须在车辆右侧。禁止 U 形转弯。</para>
		/// <para>车辆的左侧 (2) - 当车辆到达和离开网络位置时，停靠点必须在车辆左侧。禁止 U 形转弯。</para>
		/// <para>禁止 U 形转弯 (3) - 当车辆到达网络位置时，停靠点可在车辆的任意一侧；但是，车辆在离开时不得调头。</para>
		/// <para>Bearing：</para>
		/// <para>点移动的方向。单位为度，并且从正北方向开始按顺时针方式进行测量。该字段与 BearingTol 字段结合使用。</para>
		/// <para>方位角数据通常会从配有 GPS 接收器的移动设备自动发送。如果正在加载移动的停靠点（例如行人或车辆），则尝试包括方位角数据。</para>
		/// <para>使用该字段可以防止将位置添加到错误的边上，例如，车辆刚好在交叉路口或天桥附近时。方位角也可帮助 Network Analyst 确定点在街道的哪一边上。</para>
		/// <para>有关详细信息，请参阅方位角和 BearingTol。</para>
		/// <para>BearingTol：</para>
		/// <para>使用 Bearing 字段在边上定位移动点时，方位角容差值将创建一个可接受方位角值的范围。如果 Bearing 字段中的值在可接受值范围（由边上的方位角容差生成）内，则可以将该点作为网络位置添加在此处，否则，将计算下一个最近边上的最近点。</para>
		/// <para>单位为度，默认值为 30。值必须大于零且小于 180。</para>
		/// <para>值为 30 表示，Network Analyst 尝试在边上添加网络位置时，在边的每一侧（左侧和右侧）的两个数字化方向上都将生成一个 15º 的可接受方位角值。</para>
		/// <para>有关详细信息，请参阅方位角和 BearingTol。</para>
		/// <para>NavLatency：</para>
		/// <para>如果 Bearing 和 BearingTol 也具有值，则该字段只在求解过程中使用；但是，即使当 Bearing 和 BearingTol 字段中有值时，NavLatency 值的输入也是可选的。NavLatency 表示 GPS 信息从移动的车辆上发送到服务器以及车辆导航设备接收到处理后路径这两个时刻之间预期要经过的时间。NavLatency 的时间单位与时间属性参数指定的成本属性的单位相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Depots { get; set; }

		/// <summary>
		/// <para>Routes</para>
		/// <para>适用于给定车辆配送问题的路径。路径指定了车辆和驾驶员的特征；求解后，路径还表示站点和停靠点之间的路径。</para>
		/// <para>路径可以具有开始和结束站点服务时间、固定或灵活的起始时间、基于时间的运行成本、基于距离的运行成本、多个容量、对驾驶员工作时间的各种约束等等。</para>
		/// <para>路径记录集具有多个属性。下面列出并描述了属性表中的字段。</para>
		/// <para>Name：</para>
		/// <para>路径的名称。名称必须唯一。</para>
		/// <para>如果字段值为空，则 Network Analyst 会在求解时生成唯一的名称。因此，在大多数情况下，可自行选择是否输入值。但是，如果您的分析中包括向路径预分配的休息点、路径货物补给点、按区域配送或停靠点，则您必须输入名称，因为在这些情况下路径名称将用作外键。请注意，路径名称不区分大小写。</para>
		/// <para>StartDepotName：</para>
		/// <para>路径的起始站点名称。该字段是 Depots 中 Name 字段的外键。</para>
		/// <para>如果 StartDepotName 值为空，则路径会将分配的第一个停靠点作为起始点。车辆的起始位置未知或者与您的问题不相关时，可以忽略起始站点。不过，如果 StartDepotName 为空，则 EndDepotName 不能也为空。</para>
		/// <para>如果停靠点或站点跨多个时区，则不允许使用虚拟起始站点。</para>
		/// <para>如果路径正在进行配送并且 StartDepotName 为空，则假设在路径开始前，在一个虚拟站点处进行装货。如果路径不具有货物补给点，它的配送停靠点（“停靠点”类中 DeliveryQuantities 值为非零的停靠点）会在起始站点或虚拟站点处进行装货。如果路径具有更新访问，则只有第一个更新访问之前的配送停靠点才会在起始站点或虚拟站点处进行装货。</para>
		/// <para>EndDepotName：</para>
		/// <para>路径的终止站点名称。该字段是站点参数中 Name 字段的外键。</para>
		/// <para>StartDepotServiceTime：</para>
		/// <para>在起始站点的服务时间。该字段可用于为车辆装货所用的时间建立模型。该字段可以包含空值；空值表示没有服务时间。</para>
		/// <para>该字段值的单位由时间字段单位参数（Python 中的 time_units）指定。</para>
		/// <para>起始和结束站点处的服务时间是固定值（由 StartDepotServiceTime 和 EndDepotServiceTime 字段值指定），因此不必考虑路径的实际载荷。例如，在起始站点处装载车辆所花费的时间取决于订单大小。因此，站点服务时间是与货车满载或货车平均装载对应的指定值，或者也可以设置自行估计的时间值。</para>
		/// <para>EndDepotServiceTime：</para>
		/// <para>在终止站点的服务时间。该字段可用于为车辆卸货所用的时间建立模型。该字段可以包含空值；空值表示没有服务时间。</para>
		/// <para>该字段值的单位由时间字段单位参数（Python 中的 time_units）指定。</para>
		/// <para>起始和结束站点处的服务时间是固定值（由 StartDepotServiceTime 和 EndDepotServiceTime 字段值指定），因此不必考虑路径的实际载荷。例如，在起始站点处装载车辆所花费的时间取决于订单大小。因此，站点服务时间是与货车满载或货车平均装载对应的指定值，或者也可以设置自行估计的时间值。</para>
		/// <para>EarliestStartTime：</para>
		/// <para>路径允许的最早开始时间。求解程序通过将该字段与起始站点的时间窗结合使用来确定可行的路径开始时间。</para>
		/// <para>该字段不能包含空值，其默认值只有时间，为上午 8:00；该默认值被解释为默认日期参数（Python 中的 default_date）所指定日期的上午 8:00。</para>
		/// <para>当任一时间窗字段包含当时的日期时，将忽略默认日期。为避免在此种情况下出现错误，设置站点、路径、停靠点和休息点的所有时间窗的格式以包含当时的日期。</para>
		/// <para>将网络数据集与跨越多个时区的流量数据结合使用时，EarliestStartTime 的时区与起始站点所在的边或交汇点的时区相同。</para>
		/// <para>LatestStartTime：</para>
		/// <para>路径允许的最晚开始时间。该字段不能包含空值，其默认值只有时间，为上午 10:00；该默认值被解释为分析图层的“默认日期”属性所指定日期的上午 10:00。</para>
		/// <para>将网络数据集与跨越多个时区的流量数据结合使用时，LatestStartTime 的时区与起始站点所在的边或交汇点的时区相同。</para>
		/// <para>ArriveDepartDelay</para>
		/// <para>该字段存储将车辆加速到正常行驶速度、减速到停止状态以及离开和进入网络（例如，出入停车场）所需的行驶时间。通过包含 ArriveDepartDelay 值，可防止 VRP 求解程序发送多条路径来为完全重合的停靠点提供服务。</para>
		/// <para>该属性的成本是因为对不重合的停靠点、站点和货物补给点进行访问而产生的。例如，如果路径从站点处开始，然后访问第一个停靠点，则总的到达/离开延迟会计入行驶时间。这同样适用于从第一个停靠点行驶到第二个停靠点的情况。如果第二个停靠点与第三个停靠点重合，则不会在它们之间添加 ArriveDepartDelay 值，因为车辆并不需要移动。如果路径行驶到一个货物补给点，则该值会再次计入行驶时间。</para>
		/// <para>尽管车辆需要减速、停下来休息，然后再加速，但 VRP 求解程序也不能将 ArriveDepartDelay 值计入休息时间。这表示如果路径离开某个停靠点、停下休息，然后继续行驶到下一个停靠点，则仅计入一次到达/离开延迟，而不是两次。</para>
		/// <para>为了说明，假设在一幢高层建筑物中有五个重合停靠点，而且可通过三条不同的路径来为它们提供服务。这意味着将产生三个到达/离开延迟；也就是说，三名驾驶员需要分别寻找停车位并进入同一栋建筑物。不过，如果可以仅通过一条路径来为这些停靠点提供服务，则只有一名驾驶员需要寻找停车位并进入该建筑物，这样只会产生一个到达/离开延迟。由于 VRP 求解程序会尝试将成本降至最低，所以它将尝试限制到达/离开延迟，因而会选择使用单一路径。（请注意，其他约束（例如，特殊要求、时间窗或容量）可能要求发送多条路径。）</para>
		/// <para>该字段值的单位由时间字段单位参数（Python 中的 time_units）指定。</para>
		/// <para>Capacities：</para>
		/// <para>车辆的最大容量。可以按任何度量单位（如重量、体积或数量）来指定容量。也可以指定多个度量单位，例如，重量和体积。</para>
		/// <para>输入未指明单位的容量。例如，假定您车辆的最大载重为 40,000 磅；您可输入 40000。为了用作后续参考，您需要记住该值的单位是磅。</para>
		/// <para>如果您正在追踪的是具有多个维度的对象，请以空格分隔各维度的值。例如，如果您要记录重量和体积，而您的车辆最大载重为 40,000 磅，最大容量为 2,000 立方英尺，则应在 Capacities 中输入 40000 2000。同样地，您需要记住单位。您还需要记住值及其对应单位的输入顺序（在本例中，前者是磅，后者是立方英尺）。</para>
		/// <para>鉴于以下原因，记住单位和单位顺序非常重要：第一，您可以在稍后重新解释信息；第二，您可以在停靠点的 DeliveryQuantities 和 PickupQuantities 字段中输入正确的值。为了详细描述第二点，请注意 VRP 求解程序会同时引用 Capacities、DeliveryQuantities 和 PickupQuantities，以确保路径不会超载。由于字段中不能输入单位，Network Analyst 不能转换单位，因此您需要以相同的单位和单位顺序在这三个字段中输入值，以确保能正确地解释值。如果在这三个字段的任意字段中使用的单位不同或顺序发生变化，那么您将得到意外结果，但不会收到警告消息。因此，事先设置单位和单位顺序标准，并在这三个字段中输入值时始终参考此标准是一个好办法。</para>
		/// <para>空字符串或空值相当于所有值均为零。容量值不能为负数。</para>
		/// <para>如果 Capacities 字符串中值的个数相对于停靠点的 DeliveryQuantities 或 PickupQuantities 字段来说数量不足，则其余的值将被视为零。</para>
		/// <para>VRP 求解程序仅执行简单的布尔测试来判定是否超出容量。如果路径的容量值大于或等于装载总量，则 VRP 求解程序将假定货物适宜用该车辆装载。这可能并不正确，但具体要取决于货物和车辆的实际形状。例如，VRP 求解程序允许将 1000 立方英尺的球形物装到容积为 1000 立方英尺、宽为 8 英尺的货车中。但实际上由于球形物的直径为 12.6 英尺，所以它无法装到 8 英尺宽的货车中。</para>
		/// <para>FixedCost：</para>
		/// <para>仅当解决方案中使用路径（即，路径分配有停靠点）时才产生的固定货币成本。该字段可以包含空值；空值表示没有固定成本。该成本属于路径总运行成本的一部分。</para>
		/// <para>CostPerUnitTime：</para>
		/// <para>路径总持续时间（包括行驶时间以及在停靠点、站点和休息点的服务时间和等待时间）中每单位工作时间产生的货币成本。该字段不能包含空值，其默认值为 1.0。</para>
		/// <para>该字段值的单位由时间字段单位参数（Python 中的 time_units）指定。</para>
		/// <para>CostPerUnitDistance：</para>
		/// <para>路径长度（总行驶距离）中每单位行驶距离产生的货币成本。该字段可以包含空值；空值表示没有成本。</para>
		/// <para>该字段值的单位由距离字段单位参数（Python 的 distance_units）指定。</para>
		/// <para>OvertimeStartTime：</para>
		/// <para>开始计算加班时间之前的规定工作时间。该字段可以包含空值；空值表示没有加班时间。</para>
		/// <para>该字段值的单位由时间字段单位参数（Python 中的 time_units）指定。</para>
		/// <para>例如，如果路径总持续时间超过八小时的时候要为驾驶员支付加班费，假定时间字段单位参数设置为分钟，则 OvertimeStartTime 将被指定为 480（8 小时 * 60 分钟/小时）。</para>
		/// <para>CostPerUnitOvertime：</para>
		/// <para>每单位加班工作时间产生的货币成本。该字段可以包含空值；空值表示 CostPerUnitOvertime 值与 CostPerUnitTime 值相同。</para>
		/// <para>MaxOrderCount：</para>
		/// <para>路径上允许的最大停靠点数。该字段不能包含空值，其默认值为 30。</para>
		/// <para>MaxTotalTime：</para>
		/// <para>允许的最长路径持续时间。路径持续时间包括行驶时间以及在停靠点、站点和休息点的服务和等待时间。该字段可以包含空值；空值表示对路径持续时间无限制。</para>
		/// <para>该字段值的单位由时间字段单位参数（Python 中的 time_units）指定。</para>
		/// <para>MaxTotalTravelTime：</para>
		/// <para>路径允许的最长行驶时间。行驶时间只包括在网络上行驶时所用的时间，不包括服务或等待时间。</para>
		/// <para>该字段可以包含空值；空值表示对允许的最长行驶时间无限制。该字段值不能大于 MaxTotalTime 字段值。</para>
		/// <para>该字段值的单位由时间字段单位参数（Python 中的 time_units）指定。</para>
		/// <para>MaxTotalDistance：</para>
		/// <para>路径允许的最长行驶距离。</para>
		/// <para>该字段值的单位由距离字段单位参数（Python 的 distance_units）指定。</para>
		/// <para>该字段可以包含空值；空值表示对允许的最长行驶距离无限制。</para>
		/// <para>SpecialtyNames：</para>
		/// <para>一个以空格分隔的字符串，其中包含路径所支持的特殊要求的名称。空值表示路径不支持任何特殊要求。</para>
		/// <para>该字段是停靠点参数中 SpecialtyNames 字段的外键。</para>
		/// <para>为了说明什么是特殊要求及其工作方式，假设草坪护理及树木修剪公司都有一部分停靠点需要使用斗式铲车来修剪所有树木。公司将在 SpecialtyNames 字段中为这些停靠点输入 BucketTruck 来表示其特殊要求。对于其他停靠点，SpecialtyNames 将留为空值。同样，公司也可以在带液压吊杆的铲车路径的 SpecialtyNames 字段中输入 BucketTruck。对于其他路径该字段将留为空值。求解时，VRP 求解程序会将无任何特殊要求的停靠点分配给任意路径，而将需要斗式铲车的停靠点分配给有斗式铲车的路径。</para>
		/// <para>AssignmentRule：</para>
		/// <para>该字段指定解决问题时是否可以使用路径。该字段受值的属性域约束，可能的值如下：</para>
		/// <para>Include - 路径包括在求解操作中。这是默认值。</para>
		/// <para>Exclude - 路径被排除在求解操作之外。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRecordSet()]
		public object Routes { get; set; }

		/// <summary>
		/// <para>Breaks</para>
		/// <para>给定车辆配送问题中路径的休息时段或中断。一个休息点只与一条路径相关联，而且可在以下情况下获得：完成停靠点服务后、去往停靠点的途中或在为停靠点提供服务之前。休息具有一个起始时间和持续时间，该时间段内可能会为驾驶员支付报酬，也可能不支付。休息开始时可通过三种方式来建立：使用时间窗、最长行驶时间或最长工作时间。</para>
		/// <para>休息点记录集具有关联的属性。下面列出并描述了属性表中的字段。</para>
		/// <para>&lt;para/&gt;ObjectID：</para>
		/// <para>系统管理的 ID 字段。</para>
		/// <para>RouteName：</para>
		/// <para>休息点所应用到的路径的名称。尽管一个休息点只会被分配给一条路径，但是也可将多个休息点分配给同一路径。</para>
		/// <para>该字段是路径类中 Name 字段的外键，并且不能具有空值。</para>
		/// <para>Precedence：</para>
		/// <para>Precedence 值用来指定休息点在给定路径上的顺序。precedence 值为 1 的休息点会出现在 precedence 值为 2 的休息点之前，依此类推。</para>
		/// <para>无论休息点是时间窗休息点、最长行驶时间休息点还是最长工作时间休息点，所有休息点都必须具有 precedence 值。</para>
		/// <para>ServiceTime</para>
		/// <para>休息点的持续时间。该字段不能包含空值，其默认值为 60。</para>
		/// <para>该字段值的单位由时间字段单位参数（Python 中的 time_units）指定。</para>
		/// <para>TimeWindowStart：</para>
		/// <para>休息点时间窗的开始时间。半开放时间窗对于休息点无效。</para>
		/// <para>如果该字段中存在值，则 MaxTravelTimeBetweenBreaks 和 MaxCumulWorkTime 必须为空，而且分析图层中所有其他休息点的 MaxTravelTimeBetweenBreaks 和 MaxCumulWorkTime 必须也为空值。</para>
		/// <para>如果路径具有时间窗相互重叠的多个休息点，就会在求解时出现错误。</para>
		/// <para>休息点中的时间窗口字段可以在日期字段中包含仅时间值或日期和时间值，但不能是表示自新纪元以来的毫秒数的整数。时间窗口字段的时区可以使用 time_zone_usage_for_time_fields 参数进行指定。如果像 TimeWindowStart 这样的时间字段的值只有时间（例如下午 12:00），则假定日期为默认日期参数（Python 中的 default_date）指定的日期。使用“日期和时间”值（例如 7/11/2012 12:00 p.m.）可以指定时长为两天或两天以上的时间窗。这适用于应在午夜前后的某个时间休息的情况。</para>
		/// <para>当任一时间窗字段包含当时的日期时，将忽略默认日期。为避免在此种情况下出现错误，设置站点、路径、停靠点和休息点的所有时间窗的格式以包含当时的日期。</para>
		/// <para>TimeWindowEnd：</para>
		/// <para>休息点时间窗的结束时间。半开放时间窗对于休息点无效。</para>
		/// <para>如果该字段中存在值，则 MaxTravelTimeBetweenBreaks 和 MaxCumulWorkTime 必须为空，而且分析图层中所有其他休息点的 MaxTravelTimeBetweenBreaks 和 MaxCumulWorkTime 必须也为空值。</para>
		/// <para>MaxViolationTime：</para>
		/// <para>该字段为时间窗休息点指定允许的最长冲突时间。如果到达时间不在该时间范围内，则认为与时间窗发生冲突。</para>
		/// <para>零值表示不能与时间窗发生冲突；即时间窗是硬性的。非零值指定最长延迟时间；例如，休息可在其时间窗结束后最多 30 分钟内开始，但会按照时间窗冲突重要性参数（Python 中的 time_window_factor）对延迟进行惩罚。</para>
		/// <para>该属性可以为空；TimeWindowStart 和 TimeWindowEnd 为空值表示对允许的冲突时间没有限制。如果 MaxTravelTimeBetweenBreaks 或 MaxCumulWorkTime 中存在值，那么 MaxViolationTime 必须为空。</para>
		/// <para>该字段值的单位由时间字段单位参数（Python 中的 time_units）指定。</para>
		/// <para>MaxTravelTimeBetweenBreaks：</para>
		/// <para>休息之前可累积的最长行驶时间。行驶时间从上一个休息点的结束时间开始累积，或者从路径的起始点开始累积（如果还未休息过）。</para>
		/// <para>如果这是路径的最后一个休息点，则 MaxTravelTimeBetweenBreaks 还会指明从最后一个休息点到终止站点可累积的最长行驶时间。</para>
		/// <para>该字段用于限制可在驾驶多长时间之后才需要休息。例如，如果分析的时间字段单位参数（Python 中的 time_units）设为分钟，而且 MaxTravelTimeBetweenBreaks 的值为 120，则司机将在驾驶两个小时之后中断驾驶以得到休息。如果要再驾驶两个小时后休息一次，则第二个休息点的 MaxTravelTimeBetweenBreaks 字段值应为 120。</para>
		/// <para>如果该字段中存在值，那么为了能够顺利求解分析，TimeWindowStart、TimeWindowEnd、MaxViolationTime 和 MaxCumulWorkTime 必须都为空。</para>
		/// <para>该字段值的单位由时间字段单位参数（Python 中的 time_units）指定。</para>
		/// <para>MaxCumulWorkTime：</para>
		/// <para>休息之前可累积的最长工作时间。工作时间始终从路径的起始点开始累积。</para>
		/// <para>工作时间等于行驶时间加上在停靠点、站点和休息点的服务时间。不过请注意，该时间不包括等待时间，等待时间是指路径（或驾驶员）在停靠点或站点处等待时间窗打开所用的时间。</para>
		/// <para>该字段用于限制可在工作多长时间之后才需要休息。例如，如果时间字段单位参数（Python 中的 time_units）设为分钟，而且 MaxCumulWorkTime 的值为 120，ServiceTime 的值为 15，则司机将在工作两个小时之后获得 15 分钟的休息时间。</para>
		/// <para>继续以上一个示例来进行说明，假设工作了三个小时之后又需要休息。那么，要指定该休息点，需要输入 315（5 小时 15 分钟）作为第二个休息点的 MaxCumulWorkTime 值。这个数字包括前一个休息点的 MaxCumulWorkTime 值和 ServiceTime 值，以及准许进行第二次休息之前的另外三个小时工作时间。为避免过早经过最长工作时间休息点，应该记住：此类休息点是从路径的起始点开始累积工作时间，并且工作时间包括在之前访问的站点、停靠点和休息点处的服务时间。</para>
		/// <para>如果该字段中存在值，那么为了能够顺利求解分析，TimeWindowStart、TimeWindowEnd、MaxViolationTime 和 MaxTravelTimeBetweenBreaks 必须都为空。</para>
		/// <para>该字段值的单位由时间字段单位参数（Python 中的 time_units）指定。</para>
		/// <para>IsPaid：</para>
		/// <para>用来指示是否为休息点支付报酬的布尔值。值为 True 表示在计算路径成本和判定加班时间时将包括在休息点处所花费的时间。值为 False 表示的情况与 True 值相反。默认值为 True。</para>
		/// <para>Sequence：</para>
		/// <para>该输入字段用于指示休息点在其路径上的顺序。该字段可包含空值。输入 sequence 值应为正且对于各路径均唯一（在货物补给点、停靠点和休息点之间分配），但是不需要从 1 开始，也不需要连续。</para>
		/// <para>求解程序会修改 sequence 字段。执行求解后，该字段会包含休息点在其路径上的 sequence 值。路径的输出 sequence 值在货物补给点、停靠点和休息点之间分配；从 1 开始（在起始站点处）；并且是连续的。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRecordSet()]
		public object Breaks { get; set; }

		/// <summary>
		/// <para>Time Field Units</para>
		/// <para>指定分析中所有基于时间的字段值的时间单位。</para>
		/// <para>秒—秒</para>
		/// <para>分钟—分钟</para>
		/// <para>小时—小时</para>
		/// <para>天—天</para>
		/// <para>VRP 分析中的许多要素和记录都具有用于存储时间值的字段，例如用于停靠点的 ServiceTime 和用于路径的 CostPerUnitTime。为了最大程度减少数据输入的要求，这些字段值不包含单位。相反，所有基于距离的字段值都必须以相同单位输入，而此参数用于指定这些值的单位。</para>
		/// <para>注意，基于时间的输出字段使用此参数指定的相同单位。</para>
		/// <para>此时间单位无需与网络时间属性参数（Python 中的 time_attribute）的时间单位相匹配。</para>
		/// <para><see cref="TimeUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TimeUnits { get; set; } = "Minutes";

		/// <summary>
		/// <para>Distance Field Units</para>
		/// <para>指定分析中所有基于距离的字段值的距离单位。</para>
		/// <para>英里—英里</para>
		/// <para>千米—千米</para>
		/// <para>英尺—英尺</para>
		/// <para>码—码</para>
		/// <para>米—米</para>
		/// <para>海里—海里</para>
		/// <para>VRP 分析中许多要素和记录都有用于存储距离值的字段，例如路径的 MaxTotalDistance 和 CostPerUnitDistance。为了最大程度减少数据输入的要求，这些字段值不包含单位。相反，所有基于距离的字段值都必须以相同单位输入，而此参数用于指定这些值的单位。</para>
		/// <para>注意，基于距离的输出字段使用此参数指定的相同单位。</para>
		/// <para>此距离单位无需与网络距离属性参数（Python 中的 distance attribute）的距离单位相匹配。</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceUnits { get; set; } = "Miles";

		/// <summary>
		/// <para>Network Dataset</para>
		/// <para>将对其执行车辆配送问题分析的网络数据集。由于 VRP 求解程序要尽量缩短配送时间，因此网络数据集必须具有基于时间的成本属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNetworkDatasetLayer()]
		public object NetworkDataset { get; set; }

		/// <summary>
		/// <para>Output Geodatabase Workspace</para>
		/// <para>将创建输出要素类的文件地理数据库或内存工作空间。此工作空间必须已经存在。默认的输出工作空间为内存。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database")]
		public object OutputWorkspaceLocation { get; set; }

		/// <summary>
		/// <para>Output Unassigned Stops Name</para>
		/// <para>包含任何无法到达站点或未分配停靠点的输出要素类的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputUnassignedStopsName { get; set; }

		/// <summary>
		/// <para>Output Stops Name</para>
		/// <para>包含了路径所访问的停靠点的要素类的名称。此要素类包含在站点、停靠点及休息点的停靠。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputStopsName { get; set; }

		/// <summary>
		/// <para>Output Routes Name</para>
		/// <para>包含了分析的路径的要素类的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputRoutesName { get; set; }

		/// <summary>
		/// <para>Output Directions Name</para>
		/// <para>包含了路径方向的要素类的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputDirectionsName { get; set; }

		/// <summary>
		/// <para>Default Date</para>
		/// <para>指定一天中的时间（不包含日期）的时间字段值的默认日期。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Advanced Analysis")]
		public object DefaultDate { get; set; }

		/// <summary>
		/// <para>U-Turn Policy</para>
		/// <para>指定将在交汇点处使用的 U 形转弯策略。允许 U 形转弯表示求解程序可以在交汇点处转向并沿同一街道往回行驶。考虑到交汇点表示街道交叉路口和死角，不同的车辆可以在某些交汇点转弯，而在其他交汇点则不行 - 这取决于交汇点是交叉路口还是死角。为适应此情况，U 形转弯策略参数由连接到交汇点的边数隐性指定，这称为交汇点价。此参数可接受的值如下所列；每个值的后面是根据交汇点价对其含义的描述。</para>
		/// <para>允许—无论在交汇点处有几条连接的边，均允许 U 形转弯。这是默认值。</para>
		/// <para>不允许—在所有交汇点处均禁止 U 形转弯，不管交汇点原子价如何。不过请注意，即使已选择该设置，在网络位置处仍允许 U 形转弯；但是也可以通过设置个别网络位置的 CurbApproach 属性来禁止 U 形转弯。</para>
		/// <para>仅在末路处允许—除仅有一条相邻边的交汇点（死角）外，其他交汇点均禁止 U 形转弯。</para>
		/// <para>仅在末路处和交点处允许—在恰好有两条相邻边相遇的交汇点处禁止 U 形转弯，但是交叉点（三条或三条以上相邻边的交汇点）和死角（仅有一条相邻边的交汇点）处允许。通常，网络在路段中间有多余的交汇点。此选项可防止车辆在这些位置出现 U 形转弯。</para>
		/// <para>如果您需要定义更加精确的 U 形转弯策略，可以考虑在网络成本属性中添加一个通用转弯延迟赋值器，或者如果存在的话，调整其设置，并特别注意反向转弯的配置。还可以设置网络位置的 CurbApproach 属性。</para>
		/// <para>将出行模式（Python 中的 travel_mode）设置为除自定义外的其他值时会覆盖此参数的值。</para>
		/// <para><see cref="UturnPolicyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object UturnPolicy { get; set; } = "ALLOW_UTURNS";

		/// <summary>
		/// <para>Time Window Violation Importance</para>
		/// <para>指定支持时间窗的重要性。具有三个选项，请见下面的列表和描述。</para>
		/// <para>低—提高减少驾驶时间的重要性，降低按时到达停靠点的重要性。如果积压的服务请求逐渐增多，则可以使用此设置。如果为了在当日内为更多的停靠点提供服务并减少积压的订单数，则可选择此设置，即使迟到可能会为客户带来不便。</para>
		/// <para>中速—平衡减少驾驶时间的重要性与在时间窗内到达的重要性。这是默认值。</para>
		/// <para>高—提高按时到达停靠点的重要性，降低减少驾驶时间的重要性。进行时间紧迫的配送或注重客户服务的组织将选择此设置。</para>
		/// <para><see cref="TimeWindowFactorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Analysis")]
		public object TimeWindowFactor { get; set; } = "Medium";

		/// <summary>
		/// <para>Spatially Cluster Routes</para>
		/// <para>指定是否使用空间聚类。</para>
		/// <para>选中 - 分配给各个路径的停靠点将在空间上聚类。对停靠点进行聚类往往在较小区域保持路径，并减小路径线彼此相交的频率；然而，聚类可能会增加总行程时间。这是默认设置。</para>
		/// <para>未选中 - 求解器不会对空间聚类停靠点进行优先排序，并且路线可能会相交。如果指定了路径区，请使用此选项。</para>
		/// <para><see cref="SpatiallyClusterRoutesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Analysis")]
		public object SpatiallyClusterRoutes { get; set; } = "true";

		/// <summary>
		/// <para>Route Zones</para>
		/// <para>描绘给定路径的工作区域。路径区属于面要素，用来对路径施加约束，以使路径仅为某一指定区域内或附近的停靠点提供服务。以下示例说明了路径区非常有用的情况：</para>
		/// <para>有些员工不具备在某些州或社区执行工作所需的权限。此时，您可以创建一个硬性路径区，使他们只能访问他们满足相应要求的区域中的停靠点。</para>
		/// <para>您其中的一辆车经常出现故障，所以您希望使其仅访问离汽车修理厂很近的停靠点，从而将响应时间缩至最短。此时，您可以创建一个软性或硬性路径区，使该车在附近行驶。</para>
		/// <para>路径区要素集具有一个关联属性表。下面列出并描述了属性表中的字段。</para>
		/// <para>ObjectID：</para>
		/// <para>系统管理的 ID 字段。</para>
		/// <para>Shape：</para>
		/// <para>指示网络分析对象地理位置的几何字段。</para>
		/// <para>RouteName：</para>
		/// <para>该区域所应用到的路径的名称。按区域配送最大可覆盖一条关联路径。该字段不能包含空值，而且是“路径”要素图层中 Name 字段的外键。</para>
		/// <para>IsHardZone：</para>
		/// <para>用来指示按区域配送中的区域是硬性还是软性的布尔值。值为 True 表示区域是硬性的；也就是说，落在区域面以外的停靠点不能分配给该路径。默认值为 True (1)。值为 False (0) 表示这样的停靠点仍可进行分配，但是为停靠点提供服务的成本要根据一个函数进行加权得到，该函数基于与区域的欧氏距离。实际上，这意味着，随着软性区域到停靠点的直线距离的增加，停靠点被分配给路径的可能性将会降低。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[Category("Advanced Analysis")]
		public object RouteZones { get; set; }

		/// <summary>
		/// <para>Route Renewals</para>
		/// <para>指定路径可以访问的中间站点，以重新装载或卸载正在配送或接收的货物。具体而言，货物补给点将把路径链接到站点。这一关系表明路径可在关联的站点处进行更新（在途中重新装载或卸载）。</para>
		/// <para>货物补给可用于为以下情景建立模型：车辆在起始站点接收满载的配送量、到各停靠点提供服务、返回到该站点更新配送量，然后继续为更多停靠点提供服务。例如，在丙烷气配送中，车辆可能需要进行多次交货才能将气罐排空，而且需要访问加气点并继续进行配送。</para>
		/// <para>以下是使用路径补给点时要考虑的几项规则和选择：</para>
		/// <para>重新装货/卸货点（或货物补给位置）可以与起始站点或终止站点不同。</para>
		/// <para>每条路径都可具有一个或多个预先确定的货物补给位置。</para>
		/// <para>一条路径可能会多次使用某个货物补给位置。</para>
		/// <para>如果路径上存在多个可能的货物补给位置，则求解程序会选择最近的可用货物补给位置。</para>
		/// <para>货物补给点记录集具有关联属性。下面列出并描述了属性表中的字段。</para>
		/// <para>ObjectID：</para>
		/// <para>系统管理的 ID 字段。</para>
		/// <para>DepotName：</para>
		/// <para>进行该更新时所在站点的名称。该字段不能包含空值，而且是“站点”要素图层中 Name 字段的外键。</para>
		/// <para>RouteName：</para>
		/// <para>该更新所应用到的路径的名称。该字段不能包含空值，而且是“路径”要素图层中 Name 字段的外键。</para>
		/// <para>ServiceTime：</para>
		/// <para>更新的服务时间。该字段可以包含空值；空值表示没有服务时间。</para>
		/// <para>该字段值的单位由分析图层的“时间字段单位”属性指定。</para>
		/// <para>在补给站点处装载车辆所花费的时间可能取决于车辆大小和车辆装载量。不过，货物补给点的服务时间是固定值，并且不考虑实际载荷。因此，为更新服务时间指定的值应与货车满载量、平均装载量或所选的其他估计时间相对应。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRecordSet()]
		[Category("Advanced Analysis")]
		public object RouteRenewals { get; set; }

		/// <summary>
		/// <para>Order Pairs</para>
		/// <para>将接收停靠点和配送停靠点配对，使其可由同一路径提供服务。</para>
		/// <para>有时，要求停靠点的接收和配送是成对的。例如，快递公司可能需要让路径从一个停靠点接收高优先级包裹并送往另一个停靠点，而不返回站点或分拣站，以减少送货时间。可以通过使用停靠点对，按照相应的顺序将这些相关的停靠点分配给同一路径。而且，还可以对包裹在车辆上停留的时间进行限制；例如，包裹可能是血液样本，必须在两个小时内从医生办公室运送到实验室。</para>
		/// <para>停靠点对记录集具有关联属性。下面列出并描述了属性表中的字段。</para>
		/// <para>ObjectID：</para>
		/// <para>系统管理的 ID 字段。</para>
		/// <para>FirstOrderName：</para>
		/// <para>停靠点对中第一个停靠点的名称。该字段是“停靠点”要素图层中 Name 字段的外键。</para>
		/// <para>SecondOrderName：</para>
		/// <para>停靠点对中第二个停靠点的名称。该字段是“停靠点”要素图层中 Name 字段的外键。</para>
		/// <para>停靠点对中的第一个停靠点必须为接收停靠点；也就是说，它的 DeliveryQuantities 字段值为空。停靠点对中的第二个停靠点必须为配送停靠点；也就是说，它的 PickupQuantities 字段值为空。第一个停靠点处的接收量必须与第二个停靠点处的配送量一致。有一种特殊情况是，在未使用容量时，两个停靠点的数量可能都为零。</para>
		/// <para>停靠点数量在站点处不进行装载或卸载。</para>
		/// <para>MaxTransitTime：</para>
		/// <para>停靠点对的最长行驶时间。行驶时间是指离开第一个停靠点至到达第二个停靠点的持续时间。该约束限制两个停靠点之间的车上时间（或行驶时间）。车辆携带人员或易腐烂货物时，行驶时间通常比携带包裹或不易腐烂的货物的时间要短。该字段可以包含空值；空值表示对行驶时间无限制。</para>
		/// <para>该字段值的单位由分析图层的“时间字段单位”属性指定。</para>
		/// <para>求解程序可对额外行驶时间（相对于停靠点对之间的直线行驶时间来测量）进行追踪和加权。因此，您可指示 VRP 求解程序采用以下三种方法之一：不考虑车队行程成本的增加，将总的额外行驶时间缩至最短；找出一种可平衡总冲突时间和行程成本的解决方案；或者不考虑总的额外行驶时间，而将车队的行程成本降至最低。通过为额外行驶时间重要性参数（Python 中的 excess_transit_factor）分配重要性级别，实际上就是在这三种方法中选择一种方法。无论重要性级别如何，只要超过 MaxTransitTime 值，求解程序就会返回错误。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRecordSet()]
		[Category("Advanced Analysis")]
		public object OrderPairs { get; set; }

		/// <summary>
		/// <para>Excess Transit Time Importance</para>
		/// <para>指定减少停靠点对的额外行驶时间的重要性。额外行驶时间是指超出停靠点对间直线行驶所需时间的数量。额外时间可能由司机休息或前往中间停靠点和站点造成。</para>
		/// <para>低—提高减少总体解决方案成本的重要性，降低额外行驶时间的重要性。此设置通常应用于快递服务。由于快递运输的是包裹而不是人员，因此无需担心行驶时间。使用此设置时，快递可以按照最适合的顺序为停靠点对提供服务，并且总体解决方案成本最低。</para>
		/// <para>中速—平衡减少额外行驶时间和降低总体解决方案成本的重要性。这是默认值。</para>
		/// <para>高—提高最小化停靠点对之间行驶时间的重要性，降低总体行驶成本的重要性。如果您正在停靠点对间运载乘客并且想缩短他们的乘车时间，则这种情况适合使用此设置。这是出租车服务的特征。</para>
		/// <para><see cref="ExcessTransitFactorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Analysis")]
		public object ExcessTransitFactor { get; set; } = "Medium";

		/// <summary>
		/// <para>Point Barriers</para>
		/// <para>指定点障碍，并将其分为两种类型：禁止型点障碍和增加成本型点障碍。它们可以暂时限制网络上的穿越或在网络的点上增加阻抗。点障碍由要素集定义，为点要素指定的属性值决定它们是禁止型障碍还是增加成本型障碍。下面列出并描述了属性表中的字段。</para>
		/// <para>ObjectID：</para>
		/// <para>系统管理的 ID 字段。</para>
		/// <para>Shape：</para>
		/// <para>指示网络分析对象地理位置的几何字段。</para>
		/// <para>Name：</para>
		/// <para>障碍的名称。</para>
		/// <para>BarrierType：</para>
		/// <para>指定障碍的存在将完全禁止通行还是在通行时增加成本。共有两个选项：</para>
		/// <para>(0) - 禁止穿过障碍。这是默认值。&lt;bold&gt;禁止型&lt;/bold&gt;</para>
		/// <para>(2) - 穿过障碍会增加网络成本，具体增加值取决于在 Additional_Time 和 Additional_Distance 字段中指定的值。&lt;bold&gt;增加成本型&lt;/bold&gt;</para>
		/// <para>Additional_Time：</para>
		/// <para>如果 BarrierType 设置为增加成本型，则 Additional_Time 字段的值指示路径穿过障碍时增加的时间。</para>
		/// <para>该字段值的单位由分析图层的时间字段单位属性指定。</para>
		/// <para>Additional_Distance：</para>
		/// <para>如果 BarrierType 设置为增加成本型，则 Additional_Distance 字段的值指示路径穿过障碍时增加的阻抗。</para>
		/// <para>该字段值的单位由距离字段单位参数指定。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[Category("Barriers")]
		public object PointBarriers { get; set; }

		/// <summary>
		/// <para>Line Barriers</para>
		/// <para>指定线障碍，暂时限制穿越障碍。线障碍由要素集定义。下面列出并描述了属性表中的字段。</para>
		/// <para>ObjectID：</para>
		/// <para>系统管理的 ID 字段。</para>
		/// <para>Shape：</para>
		/// <para>指示网络分析对象地理位置的几何字段。</para>
		/// <para>Name：</para>
		/// <para>障碍的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[Category("Barriers")]
		public object LineBarriers { get; set; }

		/// <summary>
		/// <para>Polygon Barriers</para>
		/// <para>指定面障碍，并将其分为两种类型：禁止型面障碍和调整成本型面障碍。它们会暂时限制穿越所覆盖的网络部分或调整阻抗。面障碍由要素集定义，为面要素指定的属性值决定它们是禁止型障碍还是调整成本型障碍。下面列出并描述了属性表中的字段。</para>
		/// <para>ObjectID：</para>
		/// <para>系统管理的 ID 字段。</para>
		/// <para>Shape：</para>
		/// <para>指示网络分析对象地理位置的几何字段。</para>
		/// <para>Name：</para>
		/// <para>障碍的名称。</para>
		/// <para>BarrierType：</para>
		/// <para>指定障碍的存在将完全禁止通行还是按比例增加行程成本。共有两个选项：</para>
		/// <para>(0) - 禁止穿过障碍的任何部分。这是默认值。&lt;bold&gt;禁止型&lt;/bold&gt;</para>
		/// <para>(1) - 将阻抗乘以 Attr_[阻抗] 属性值从而调整基础边阻抗。如果障碍部分覆盖了边，则会按比例对阻抗执行乘法运算。&lt;bold&gt;成本按比例增加型&lt;/bold&gt;</para>
		/// <para>Scaled_Time：</para>
		/// <para>障碍下面的边的基于时间的阻抗值乘以在此字段中设置的值。此字段仅在障碍为调整成本型障碍时有用。</para>
		/// <para>Scaled_Distance：</para>
		/// <para>障碍下面的边的基于距离的阻抗值乘以在此字段中设置的值。此字段仅在障碍为调整成本型障碍时有用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		[Category("Barriers")]
		public object PolygonBarriers { get; set; }

		/// <summary>
		/// <para>Time Attribute</para>
		/// <para>确定网络元素的行驶时间时使用的网络成本属性。</para>
		/// <para>将出行模式（Python 中的 travel_mode）设置为除自定义外的其他值时会覆盖此参数的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object TimeAttribute { get; set; }

		/// <summary>
		/// <para>Distance Attribute</para>
		/// <para>确定网络元素的距离时使用的网络成本属性。</para>
		/// <para>将出行模式（Python 中的 travel_mode）设置为除自定义外的其他值时会覆盖此参数的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object DistanceAttribute { get; set; }

		/// <summary>
		/// <para>Use Hierarchy in Analysis</para>
		/// <para>选中 - 将使用等级属性进行分析。使用等级的结果是，求解程序更偏好高等级的边而不是低等级的边。分等级求解的速度更快，并且可用于模拟驾驶员在可能的情况下选择在高速公路而非地方道路上行驶（即使行程可能更远）的偏好。只有输入网络数据集具有等级属性时，此选项才处于活动状态。</para>
		/// <para>未选中 - 将不会使用等级属性进行分析。如果未使用等级，则结果是网络数据集的精确路径。</para>
		/// <para>如果未在用于执行分析的网络数据集中定义等级属性，该参数将处于非活动状态。</para>
		/// <para>将出行模式（Python 中的 travel_mode）设置为除自定义外的其他值时会覆盖此参数的值。</para>
		/// <para><see cref="UseHierarchyInAnalysisEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object UseHierarchyInAnalysis { get; set; }

		/// <summary>
		/// <para>Restrictions</para>
		/// <para>指示求解时应遵守的网络约束条件属性。</para>
		/// <para>将出行模式（Python 中的 travel_mode）设置为除自定义外的其他值时会覆盖此参数的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode")]
		public object Restrictions { get; set; }

		/// <summary>
		/// <para>Attribute Parameter Values</para>
		/// <para>指定具有参数的网络属性的参数值。记录集具有两个共同唯一识别参数的列以及另一个指定参数值的列。</para>
		/// <para>将出行模式（Python 中的 travel_mode）设置为除自定义外的其他值时会覆盖此参数的值。</para>
		/// <para>属性参数值记录集具有关联属性。下面列出并说明了属性表中的所有字段。</para>
		/// <para>ObjectID：</para>
		/// <para>系统管理的 ID 字段。</para>
		/// <para>AttributeName：</para>
		/// <para>网络属性的名称，其属性参数由表行设置。</para>
		/// <para>ParameterName：</para>
		/// <para>属性参数的名称，其值由表行设置。（无法使用此工具更新“对象”类型参数。）</para>
		/// <para>ParameterValue：</para>
		/// <para>您希望的属性参数值。如果未指定值，则属性参数将被设置为空。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRecordSet()]
		[Category("Custom Travel Mode")]
		public object AttributeParameterValues { get; set; }

		/// <summary>
		/// <para>Maximum Snap Tolerance</para>
		/// <para>最大捕捉容差是指在网络上定位或重新定位一个点时 Network Analyst 搜索的最远距离。搜索会寻找适合的边或交汇点，并把点捕捉到最近的边或交汇点。如果在最大捕捉容差内没有找到合适的位置，对象将标记为无法定位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Network Locations")]
		public object MaximumSnapTolerance { get; set; } = "20 Kilometers";

		/// <summary>
		/// <para>Exclude Restricted Portions of the Network</para>
		/// <para>指定在何处放置网络位置。</para>
		/// <para>选中 - 网络位置仅放置在网络的可遍历部分。这样可防止将网络位置放在因限制或障碍而无法到达的元素上。使用该选项添加网络位置之前，请确保已经向输入网络分析图层添加了所有限制型障碍，以得到预期结果。添加障碍对象时，此选项不适用。</para>
		/// <para>未选中 - 网络位置将放置在网络的所有元素上。如果通过该选项添加的网络位置被放置在受限元素上，那么在求解过程中，可能无法到达这些网络位置。</para>
		/// <para><see cref="ExcludeRestrictedPortionsOfTheNetworkEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Network Locations")]
		public object ExcludeRestrictedPortionsOfTheNetwork { get; set; } = "true";

		/// <summary>
		/// <para>Feature Locator WHERE Clause</para>
		/// <para>用于选择源要素子集的 SQL 表达式，该子集对可以定位停靠点和站点的网络元素设定了限制。例如，为确保停靠点和站点不定位在限制出入的公路上，编写一个排除这些源要素的 SQL 表达式。注意，加载时，其他网络分析对象（例如障碍）将忽略要素定位器 WHERE 子句。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Network Locations")]
		public object FeatureLocatorWhereClause { get; set; }

		/// <summary>
		/// <para>Populate Route Lines</para>
		/// <para>指定是否将生成显示路径真实形状的线。</para>
		/// <para>选中 - 路径要素将使用线填充其 Shape 字段。</para>
		/// <para>未选中 - 将不会为输出路径生成任何形状。</para>
		/// <para><see cref="PopulateRouteLinesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object PopulateRouteLines { get; set; } = "true";

		/// <summary>
		/// <para>Route Line Simplification Tolerance</para>
		/// <para>路径几何的简化距离。</para>
		/// <para>简化将保留路径上定义路径基本形状所需的关键点（例如交点处的转弯）而删除其他点。指定的简化距离为简化线偏离原始线的最大允许偏移。简化线将减少折点的数量，并且往往能够减少绘制时间。</para>
		/// <para>将出行模式（Python 中的 travel_mode）设置为除自定义外的其他值时会覆盖此参数的值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Custom Travel Mode")]
		public object RouteLineSimplificationTolerance { get; set; } = "10 Meters";

		/// <summary>
		/// <para>Populate Directions</para>
		/// <para>指定是否将生成行驶方向。</para>
		/// <para>选中 - 将生成行驶方向。输出方向名称参数中指定的要素类使用每条路径的转向说明填充。网络数据集必须支持行驶方向；否则，求解方向时将发生错误。</para>
		/// <para>未选中 - 将不会生成方向。</para>
		/// <para><see cref="PopulateDirectionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object PopulateDirections { get; set; } = "false";

		/// <summary>
		/// <para>Directions Language</para>
		/// <para>将用于生成行驶方向的语言。下拉列表中可用的语言类别取决于您的计算机中所包含的 ArcGIS 语言包。</para>
		/// <para>如果要将此工具作为独立服务器服务的一部分进行发布，那么必须确保与您所选语言相对应的 ArcGIS 语言包已经安装到服务器上，这样才能够保证工具正常工作。而且，如果某一语言包未被安装到您的计算机中，该语言将不会显示在下拉列表中；不过，您可以直接键入语言代码。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object DirectionsLanguage { get; set; }

		/// <summary>
		/// <para>Directions Style Name</para>
		/// <para>指定方向的格式样式。</para>
		/// <para>NA 桌面—可打印转弯方向</para>
		/// <para>NA 导航—针对车辆内导航设备设计的转弯方向</para>
		/// <para>NA 校园—用于人行道的转弯行走方向</para>
		/// <para><see cref="DirectionsStyleNameEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object DirectionsStyleName { get; set; }

		/// <summary>
		/// <para>Save Output Network Analysis Layer</para>
		/// <para>指定输出是否包含结果的网络分析图层。</para>
		/// <para>选中 - 输出将包含结果的网络分析图层。</para>
		/// <para>未选中 - 输出将不包含结果的网络分析图层。</para>
		/// <para>在任何一种情况下，将返回独立的表和要素类。不过，服务器管理员可能希望选择输出一个网络分析图层，以便使用 ArcGIS Desktop 环境中的 Network Analyst 控件调试工具的设置和结果。这会使调试过程变得更加容易。</para>
		/// <para>在 ArcGIS Desktop 中，网络分析图层的默认输出位置位于临时工作空间，与临时地理数据库处于相同级别，也就是说，网络分析图层作为临时地理数据库的同级进行存储。输出网络分析图层存储为 .lyr 文件，其名称以 _ags_gpna 开头，后跟字母数字 GUID。</para>
		/// <para><see cref="SaveOutputLayerEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object SaveOutputLayer { get; set; } = "false";

		/// <summary>
		/// <para>Service Capabilities</para>
		/// <para>指定将此工具作为地理处理服务运行时所发生的最大计算机处理量。您可能出于以下两种原因之一要执行此操作：避免让服务器求解超出所允许的资源或处理时间的问题；使用不同的 VRP 功能创建多个服务，以支持业务模型。例如，如果您具有一个分级服务业务模型，您可能想提供一个每次最多只能求解五个路径的免费 VRP 服务，以及一个每次可求解五个以上路径的收费服务。</para>
		/// <para>除了限制路径的最大数量之外，您还可以限制向分析中添加的停靠点或点障碍的数量。控制问题大小的另一种方法是设置要素（通常为街道要素，即线或面障碍相交的要素）的最大数量。最后一种方法是停靠点的地理分布超出了给定的直线距离时，强制进行等级求解，即使用户选择不使用等级。</para>
		/// <para>MAXIMUM POINT BARRIERS—允许的最大点障碍数。如果超出此限制，将返回错误。空值表示没有限制。</para>
		/// <para>MAXIMUM FEATURES INTERSECTING LINE BARRIERS—分析中与所有线障碍相交的源要素的最大数。如果超出此限制，将返回错误。空值表示没有限制。</para>
		/// <para>MAXIMUM FEATURES INTERSECTING POLYGON BARRIERS—分析中与所有面障碍相交的源要素的最大数。如果超出此限制，将返回错误。空值表示没有限制。</para>
		/// <para>MAXIMUM ORDERS—分析中允许的最大停靠点数。如果超出此限制，将返回错误。空值表示没有限制。</para>
		/// <para>MAXIMUM ROUTES—分析中允许的最大路径数。如果超出此限制，将返回错误。空值表示没有限制。</para>
		/// <para>FORCE HIERARCHY BEYOND DISTANCE—使用网络等级求解车辆配送问题前，停靠点之间的最大直线距离。此值的单位与距离字段单位参数中指定的相同。如果网络没有等级属性，将忽略此约束。如果选中在分析中应用等级，将总是使用等级。如果未选中在分析中应用等级参数且此约束为空值，将不强制执行等级。</para>
		/// <para>MAXIMUM ORDERS PER ROUTE—可分配到每条路径的最大停靠点数。如果超出此限制，将返回错误。空值表示没有限制。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[Category("Service Capabilities")]
		public object ServiceCapabilities { get; set; } = "'MAXIMUM POINT BARRIERS' #;'MAXIMUM FEATURES INTERSECTING LINE BARRIERS' #;'MAXIMUM FEATURES INTERSECTING POLYGON BARRIERS' #;'MAXIMUM ORDERS' #;'MAXIMUM ROUTES' #;'FORCE HIERARCHY BEYOND DISTANCE' #;'MAXIMUM ORDERS PER ROUTE' #";

		/// <summary>
		/// <para>Ignore Invalid Order Locations</para>
		/// <para>指定在求解车辆配送问题时是否忽略无效停靠点。</para>
		/// <para>选中 - 求解程序在没有遇到其他错误时，将忽略无效停靠点并返回解决方案。如果需要生成路径并将其立即提供给驾驶员，则可以忽略无效路径，并为驾驶员求解和分配路径。然后，解决上次求解时的无效停靠点，并将其包含在下一工作日或工作时段的 VRP 分析中。</para>
		/// <para>未选中 - 遇到无效停靠点时，求解运算将失败。无效停靠点是指 VRP 求解程序无法到达的停靠点。停靠点不可达的原因可能有多种，其中包括：停靠点定位于禁止的网络元素、停靠点未定位于网络或停靠点定位于网络的离线部分。</para>
		/// <para>&lt;para/&gt;</para>
		/// <para><see cref="IgnoreInvalidOrderLocationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Network Locations")]
		public object IgnoreInvalidOrderLocations { get; set; } = "false";

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>选择用于分析的运输模式。始终选择自定义。要显示其他出行模式名称，必须使其显示在网络数据集参数指定的网络数据集中。</para>
		/// <para>出行模式是在网络数据集上定义的，并会提供模型车、货车、步行或其他出行模式的参数的覆盖值。在此处选择出行模式后，您便无需为以下参数提供值，这些参数值会被网络数据集中指定的值覆盖：</para>
		/// <para>U 形转弯策略</para>
		/// <para>时间属性</para>
		/// <para>距离属性</para>
		/// <para>在分析中应用等级</para>
		/// <para>约束条件</para>
		/// <para>属性参数值</para>
		/// <para>路线简化容差</para>
		/// <para>自定义—定义适合您特定需求的出行模式。选择自定义后，该工具不会覆盖以上列出的出行模式参数。这是默认值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TravelMode { get; set; }

		/// <summary>
		/// <para>Output Solve Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object SolveSucceeded { get; set; } = "false";

		/// <summary>
		/// <para>Output Unassigned Stops</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object OutUnassignedStops { get; set; }

		/// <summary>
		/// <para>Output Stops</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object OutStops { get; set; }

		/// <summary>
		/// <para>Output Routes</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutRoutes { get; set; }

		/// <summary>
		/// <para>Output Directions</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutDirections { get; set; }

		/// <summary>
		/// <para>Output Network Analysis Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object OutNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Ignore Network Location Fields</para>
		/// <para>当在网络中定位停靠点、站点或障碍时，指定是否考虑以下网络位置字段（SourceID、SourceOID、PosAlong 和 SideOfEdge）。</para>
		/// <para>选中 - 当在网络中定位输入时，不考虑网络位置字段。而是始终通过执行空间搜索来定位输入。</para>
		/// <para>未选中 - 当在网络中定位输入时，将考虑网络位置字段。这是默认值。</para>
		/// <para><see cref="IgnoreNetworkLocationFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Network Locations")]
		public object IgnoreNetworkLocationFields { get; set; } = "false";

		/// <summary>
		/// <para>Time Zone Usage for Time Fields</para>
		/// <para>指定工具支持的以下输入日期时间字段的时区：用于停靠点的 TimeWindowStart1、TimeWindowEnd1、TimeWindowStart2、TimeWindowEnd2、InboundArriveTime 和 OutboundDepartTime；用于站点的 TimeWindowStart1、TimeWindowEnd1、TimeWindowStart2 和 TimeWindowEnd2；用于路径的 EarliestStartTime 和 LatestStartTime；以及用于休息点的 TimeWindowStart 和 TimeWindowEnd。</para>
		/// <para>地理定位— 与停靠点或站点相关的日期时间值位于停靠点和站点所在的时区内。对于路径，日期时间值基于路径的起始站点所在的时区。如果路径没有起始站点，则路径上的所有停靠点和站点必须位于一个时区中。对于休息点，日期时间值基于路径的时区。例如，如果站点所在的区域实行东部标准时间并且第一个时间窗值（指定为 TimeWindowStart1 和 TimeWindowEnd1）为 8 a.m. 和 5 p.m.，则在东部标准时间中时间窗值将被视为 8 a.m. 和 5 p.m.。</para>
		/// <para>UTC— 与停靠点或站点相关的日期时间值位于协调世界时间 (UTC) 中，且不基于停靠点或站点所在的时区。例如，如果站点所在的区域实行东部标准时间并且第一个时间窗值（指定为 TimeWindowStart1 和 TimeWindowEnd1）为 8 a.m. 和 5 p.m.，则在东部标准时间（假设东部标准时间遵循夏令时）中，时间窗值将分别被视为 12 p.m. 和 9 p.m.。</para>
		/// <para>如果不知道停靠点或站点所在的时区，或者停靠点或站点处在多个时区内并且您想要所有的日期时间值同时启动，那么在 UTC 中指定日期时间值非常有用。UTC 选项仅在您的网络数据集定义了时区属性时才可用。否则，所有的日期时间值将始终被视为地理定位（Python 中的 GEO_LOCAL）。</para>
		/// <para><see cref="TimeZoneUsageForTimeFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Analysis")]
		public object TimeZoneUsageForTimeFields { get; set; } = "GEO_LOCAL";

		/// <summary>
		/// <para>Overrides</para>
		/// <para>求解网络分析问题时，指定可影响求解程序行为的其他设置。</para>
		/// <para>必须在 JavaScript 对象表示法 (JSON) 中指定此参数的值。例如，有效值的格式如下：{&quot;overrideSetting1&quot; : &quot;value1&quot;, &quot;overrideSetting2&quot; : &quot;value2&quot;}。覆盖设置名称始终以双引号括起。该值可以是数字、布尔值或字符串。</para>
		/// <para>此参数的默认值为无值，表示不覆盖任何求解程序设置。</para>
		/// <para>覆盖是高级设置，应仅在谨慎分析应用设置前后得到的结果之后使用。要获得每个求解程序支持的覆盖设置及其可接受值的列表，请联系 Esri 技术支持。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced Analysis")]
		public object Overrides { get; set; }

		/// <summary>
		/// <para>Save Route Data</para>
		/// <para>指定是否保存含有某文件地理数据库的 .zip 文件，该文件地理数据库包含相应格式的分析的输入和输出，可以使用该格式与 ArcGIS Online 或 ArcGIS Enterprise 共享路径图层。</para>
		/// <para>在 ArcGIS Desktop 中，此输出文件的默认输出位置位于临时文件夹内。可通过使用 arcpy.env.scratchFolder 或检查地理处理环境来确定临时文件夹的位置。</para>
		/// <para>选中 - 该工具将写出包含分析输入和输出的文件地理数据库工作空间的 .zip 存档。</para>
		/// <para>未选中 - 不会保存路径数据。这是默认设置。</para>
		/// <para><see cref="SaveRouteDataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object SaveRouteData { get; set; } = "false";

		/// <summary>
		/// <para>Output Route Data</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object OutRouteData { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SolveVehicleRoutingProblem SetEnviroment(object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Time Field Units</para>
		/// </summary>
		public enum TimeUnitsEnum 
		{
			/// <summary>
			/// <para>分钟—分钟</para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("分钟")]
			Minutes,

			/// <summary>
			/// <para>秒—秒</para>
			/// </summary>
			[GPValue("Seconds")]
			[Description("秒")]
			Seconds,

			/// <summary>
			/// <para>小时—小时</para>
			/// </summary>
			[GPValue("Hours")]
			[Description("小时")]
			Hours,

			/// <summary>
			/// <para>天—天</para>
			/// </summary>
			[GPValue("Days")]
			[Description("天")]
			Days,

		}

		/// <summary>
		/// <para>Distance Field Units</para>
		/// </summary>
		public enum DistanceUnitsEnum 
		{
			/// <summary>
			/// <para>英里—英里</para>
			/// </summary>
			[GPValue("Miles")]
			[Description("英里")]
			Miles,

			/// <summary>
			/// <para>千米—千米</para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("千米")]
			Kilometers,

			/// <summary>
			/// <para>英尺—英尺</para>
			/// </summary>
			[GPValue("Feet")]
			[Description("英尺")]
			Feet,

			/// <summary>
			/// <para>码—码</para>
			/// </summary>
			[GPValue("Yards")]
			[Description("码")]
			Yards,

			/// <summary>
			/// <para>米—米</para>
			/// </summary>
			[GPValue("Meters")]
			[Description("米")]
			Meters,

			/// <summary>
			/// <para>海里—海里</para>
			/// </summary>
			[GPValue("NauticalMiles")]
			[Description("海里")]
			Nautical_Miles,

		}

		/// <summary>
		/// <para>U-Turn Policy</para>
		/// </summary>
		public enum UturnPolicyEnum 
		{
			/// <summary>
			/// <para>允许—无论在交汇点处有几条连接的边，均允许 U 形转弯。这是默认值。</para>
			/// </summary>
			[GPValue("ALLOW_UTURNS")]
			[Description("允许")]
			Allowed,

			/// <summary>
			/// <para>不允许—在所有交汇点处均禁止 U 形转弯，不管交汇点原子价如何。不过请注意，即使已选择该设置，在网络位置处仍允许 U 形转弯；但是也可以通过设置个别网络位置的 CurbApproach 属性来禁止 U 形转弯。</para>
			/// </summary>
			[GPValue("NO_UTURNS")]
			[Description("不允许")]
			Not_allowed,

			/// <summary>
			/// <para>仅在末路处允许—除仅有一条相邻边的交汇点（死角）外，其他交汇点均禁止 U 形转弯。</para>
			/// </summary>
			[GPValue("ALLOW_DEAD_ENDS_ONLY")]
			[Description("仅在末路处允许")]
			Allowed_at_dead_ends_only,

			/// <summary>
			/// <para>仅在末路处和交点处允许—在恰好有两条相邻边相遇的交汇点处禁止 U 形转弯，但是交叉点（三条或三条以上相邻边的交汇点）和死角（仅有一条相邻边的交汇点）处允许。通常，网络在路段中间有多余的交汇点。此选项可防止车辆在这些位置出现 U 形转弯。</para>
			/// </summary>
			[GPValue("ALLOW_DEAD_ENDS_AND_INTERSECTIONS_ONLY")]
			[Description("仅在末路处和交点处允许")]
			Allowed_at_dead_ends_and_intersections_only,

		}

		/// <summary>
		/// <para>Time Window Violation Importance</para>
		/// </summary>
		public enum TimeWindowFactorEnum 
		{
			/// <summary>
			/// <para>高—提高按时到达停靠点的重要性，降低减少驾驶时间的重要性。进行时间紧迫的配送或注重客户服务的组织将选择此设置。</para>
			/// </summary>
			[GPValue("High")]
			[Description("高")]
			High,

			/// <summary>
			/// <para>中速—平衡减少驾驶时间的重要性与在时间窗内到达的重要性。这是默认值。</para>
			/// </summary>
			[GPValue("Medium")]
			[Description("中速")]
			Medium,

			/// <summary>
			/// <para>低—提高减少驾驶时间的重要性，降低按时到达停靠点的重要性。如果积压的服务请求逐渐增多，则可以使用此设置。如果为了在当日内为更多的停靠点提供服务并减少积压的订单数，则可选择此设置，即使迟到可能会为客户带来不便。</para>
			/// </summary>
			[GPValue("Low")]
			[Description("低")]
			Low,

		}

		/// <summary>
		/// <para>Spatially Cluster Routes</para>
		/// </summary>
		public enum SpatiallyClusterRoutesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CLUSTER")]
			CLUSTER,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CLUSTER")]
			NO_CLUSTER,

		}

		/// <summary>
		/// <para>Excess Transit Time Importance</para>
		/// </summary>
		public enum ExcessTransitFactorEnum 
		{
			/// <summary>
			/// <para>高—提高最小化停靠点对之间行驶时间的重要性，降低总体行驶成本的重要性。如果您正在停靠点对间运载乘客并且想缩短他们的乘车时间，则这种情况适合使用此设置。这是出租车服务的特征。</para>
			/// </summary>
			[GPValue("High")]
			[Description("高")]
			High,

			/// <summary>
			/// <para>中速—平衡减少额外行驶时间和降低总体解决方案成本的重要性。这是默认值。</para>
			/// </summary>
			[GPValue("Medium")]
			[Description("中速")]
			Medium,

			/// <summary>
			/// <para>低—提高减少总体解决方案成本的重要性，降低额外行驶时间的重要性。此设置通常应用于快递服务。由于快递运输的是包裹而不是人员，因此无需担心行驶时间。使用此设置时，快递可以按照最适合的顺序为停靠点对提供服务，并且总体解决方案成本最低。</para>
			/// </summary>
			[GPValue("Low")]
			[Description("低")]
			Low,

		}

		/// <summary>
		/// <para>Use Hierarchy in Analysis</para>
		/// </summary>
		public enum UseHierarchyInAnalysisEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_HIERARCHY")]
			USE_HIERARCHY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_HIERARCHY")]
			NO_HIERARCHY,

		}

		/// <summary>
		/// <para>Exclude Restricted Portions of the Network</para>
		/// </summary>
		public enum ExcludeRestrictedPortionsOfTheNetworkEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EXCLUDE")]
			EXCLUDE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("INCLUDE")]
			INCLUDE,

		}

		/// <summary>
		/// <para>Populate Route Lines</para>
		/// </summary>
		public enum PopulateRouteLinesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ROUTE_LINES")]
			ROUTE_LINES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ROUTE_LINES")]
			NO_ROUTE_LINES,

		}

		/// <summary>
		/// <para>Populate Directions</para>
		/// </summary>
		public enum PopulateDirectionsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DIRECTIONS")]
			DIRECTIONS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DIRECTIONS")]
			NO_DIRECTIONS,

		}

		/// <summary>
		/// <para>Directions Style Name</para>
		/// </summary>
		public enum DirectionsStyleNameEnum 
		{
			/// <summary>
			/// <para>NA 桌面—可打印转弯方向</para>
			/// </summary>
			[GPValue("NA Desktop")]
			[Description("NA 桌面")]
			NA_Desktop,

			/// <summary>
			/// <para>NA 导航—针对车辆内导航设备设计的转弯方向</para>
			/// </summary>
			[GPValue("NA Navigation")]
			[Description("NA 导航")]
			NA_Navigation,

			/// <summary>
			/// <para>NA 校园—用于人行道的转弯行走方向</para>
			/// </summary>
			[GPValue("NA Campus")]
			[Description("NA 校园")]
			NA_Campus,

		}

		/// <summary>
		/// <para>Save Output Network Analysis Layer</para>
		/// </summary>
		public enum SaveOutputLayerEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SAVE_OUTPUT_LAYER")]
			SAVE_OUTPUT_LAYER,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SAVE_OUTPUT_LAYER")]
			NO_SAVE_OUTPUT_LAYER,

		}

		/// <summary>
		/// <para>Ignore Invalid Order Locations</para>
		/// </summary>
		public enum IgnoreInvalidOrderLocationsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SKIP")]
			SKIP,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("HALT")]
			HALT,

		}

		/// <summary>
		/// <para>Ignore Network Location Fields</para>
		/// </summary>
		public enum IgnoreNetworkLocationFieldsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("IGNORE")]
			IGNORE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("HONOR")]
			HONOR,

		}

		/// <summary>
		/// <para>Time Zone Usage for Time Fields</para>
		/// </summary>
		public enum TimeZoneUsageForTimeFieldsEnum 
		{
			/// <summary>
			/// <para>地理定位— 与停靠点或站点相关的日期时间值位于停靠点和站点所在的时区内。对于路径，日期时间值基于路径的起始站点所在的时区。如果路径没有起始站点，则路径上的所有停靠点和站点必须位于一个时区中。对于休息点，日期时间值基于路径的时区。例如，如果站点所在的区域实行东部标准时间并且第一个时间窗值（指定为 TimeWindowStart1 和 TimeWindowEnd1）为 8 a.m. 和 5 p.m.，则在东部标准时间中时间窗值将被视为 8 a.m. 和 5 p.m.。</para>
			/// </summary>
			[GPValue("GEO_LOCAL")]
			[Description("地理定位")]
			Geo_local,

			/// <summary>
			/// <para>UTC— 与停靠点或站点相关的日期时间值位于协调世界时间 (UTC) 中，且不基于停靠点或站点所在的时区。例如，如果站点所在的区域实行东部标准时间并且第一个时间窗值（指定为 TimeWindowStart1 和 TimeWindowEnd1）为 8 a.m. 和 5 p.m.，则在东部标准时间（假设东部标准时间遵循夏令时）中，时间窗值将分别被视为 12 p.m. 和 9 p.m.。</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

		}

		/// <summary>
		/// <para>Save Route Data</para>
		/// </summary>
		public enum SaveRouteDataEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SAVE_ROUTE_DATA")]
			SAVE_ROUTE_DATA,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SAVE_ROUTE_DATA")]
			NO_SAVE_ROUTE_DATA,

		}

#endregion
	}
}
