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
	/// <para>Solve Location Allocation</para>
	/// <para>求解位置分配</para>
	/// <para>从一组输入位置中确定一个或多个最佳位置，方法是向输入设施点分配请求点，并满足将大部分请求点分配到设施点并最小化总行程的条件。</para>
	/// </summary>
	public class SolveLocationAllocation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Facilities">
		/// <para>Facilities</para>
		/// <para>指定求解程序将在分析期间选择的一个或多个设施点。求解程序会根据问题类型及所指定的条件，以最有效的方法确定最佳的设施点来分配请求。</para>
		/// <para>在尝试寻找最具竞争力位置的竞争性分析中，竞争设施点也是在此处指定的。</para>
		/// <para>定义设施点后，可使用以下特性为每个设施点设置属性，例如设施点的名称或类型。</para>
		/// <para>Name</para>
		/// <para>设施点的名称。如果设施点为解的一部分，则该名称将包含在输出分配线的名称中。</para>
		/// <para>FacilityType</para>
		/// <para>指定设施点是候选设施点、必选设施点、还是竞争设施点。该字段值可指定为以下整数之一（请使用数值代码而非括号中的名称）：</para>
		/// <para>0（候选项） - 设施点可能是解的一部分。</para>
		/// <para>1（必填项）- 设施点必须为解的一部分。</para>
		/// <para>2（竞争项）- 可能会从您的设施点中移除请求的竞争对手设施点。竞争设施点特定于最大化市场份额与目标市场份额两种问题类型；在其他问题类型中会将其忽略。</para>
		/// <para>Weight</para>
		/// <para>设施点的相对权重，用于评定设施点的吸引力、有利条件或一个设施点较之另一个设施点的差异。</para>
		/// <para>例如，一个值为 2.0 的权重更好地体现了客户的购物意愿，客户在高权重设施点处购物的意愿强于普通权重设施点处的购物意愿，差距达到 2 倍。可能影响设施点权重的因素包括建筑物面积、街区环境以及建筑物的使用年限。非 1 权重值仅适用于最大化市场份额与目标市场份额两种问题类型；在其他问题类型中会将其忽略。</para>
		/// <para>Cutoff</para>
		/// <para>停止从指定设施点搜索请求点时所对应的阻抗值。如果设施点超出此处所示的值，则无法将请求点分配至该设施点。</para>
		/// <para>您可利用此属性为每个请求点指定不同的中断值。例如，您可能会发现，乡村居民愿意走 10 英里远去往某个设施点，而城镇居民则只愿意走 2 英里的路程。您可对此行为进行建模，方法是将位于农村地区的所有请求点的 Cutoff 值设置为 10，然后将位于城市地区的请求点的 Cutoff 值设置为 2。</para>
		/// <para>Capacity</para>
		/// <para>Capacity 字段特定于“最大化有容量限制的覆盖范围”问题类型；其他问题类型将忽略此字段。</para>
		/// <para>容量用于指定该设施点能够供应多少加权请求。即使请求在设施点的默认测量中断范围内，求解程序也不会将超出容量的请求分配到设施点。</para>
		/// <para>分配到 Capacity 字段的任意值会覆盖给定设施点的默认容量参数（Python 中的 Default_Capacity）。</para>
		/// <para>CurbApproach</para>
		/// <para>指定车辆到达或离开设施点的方向。该字段值可指定为以下整数之一（请使用数值代码而非括号中的名称）：</para>
		/// <para>0（车辆的任意一侧）- 从车辆的右侧或左侧均可访问设施点。</para>
		/// <para>1（车辆的右侧）- 当车辆到达或离开设施点时，设施点必须位于车辆右侧。通常用于必须在右侧停靠以便乘客在停靠点下车的车辆（如公共汽车）。</para>
		/// <para>2（车辆的左侧）- 当车辆到达或离开设施点时，设施点必须位于车辆左侧。在车辆到达和离开设施点时，停靠点必须位于车辆的左侧。通常用于必须在左侧停靠以便乘客在停靠点下车的车辆（如公共汽车）。</para>
		/// <para>CurbApproach 属性是专为使用以下两种国家驾驶标准而设计的：右侧通行（美国）和左侧通行（英国）。首先，考虑位于车辆左侧的设施点。不管车辆行驶在左车道还是右车道，停靠点始终位于车辆的左侧。决定从其中任一方向到达设施点可能会更改国家驾驶标准，也就是说，从车辆的右侧或左侧靠近事件点。例如，如果要到达一个设施点并且在车辆与事件点之间不存在交通车道，那么在美国请选择 1（车辆的右侧），而在英国请选择 2（车辆的左侧）。</para>
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
		/// <param name="DemandPoints">
		/// <para>Demand Points</para>
		/// <para>指定一个或多个请求点。此求解程序在很大程度上会根据这些设施点对此处所指定的请求点的服务状况来确定最佳设施点。</para>
		/// <para>请求点通常是指对设施点提供的货物和服务有需求的人或物品的位置。请求点可以是根据居住在此处的人数进行加权的邮编区域的质心，也可以是根据这些人员产生的预计消费来加权的邮编区域质心。请求点也可以表示商业客户。如果您提供的业务具有很高的库存周转率，则它们将比低周转率的业务具有更高的加权值。</para>
		/// <para>指定请求点后，可使用以下特性为每个请求点设置属性，例如请求点的名称或权重。</para>
		/// <para>Name</para>
		/// <para>请求点的名称。如果请求点为解的一部分，则该名称将包含在输出分配线的名称中。</para>
		/// <para>GroupName</para>
		/// <para>请求点所属组的名称。最大化有容量限制的覆盖范围、目标市场份额和最大化市场份额问题类型将忽略此字段。</para>
		/// <para>如果请求点共享组名称，则求解程序会将组的所有成员分配给同一设施点。（如果某些约束（如中断距离）阻止组中的任意请求点到达同一设施点，则不对任何请求点进行分配。）</para>
		/// <para>Weight</para>
		/// <para>请求点的相对权重。权重值为 2.0 表示请求点的重要性是该值为 1.0 的请求点的两倍。例如，如果请求点代表家庭，则权重可表示每个家庭中的人数。</para>
		/// <para>Cutoff</para>
		/// <para>停止从指定设施点搜索请求点时所对应的阻抗值。如果设施点超出此处所示的值，则无法将请求点分配至该设施点。</para>
		/// <para>您可利用此属性为每个请求点指定中断值。例如，您可能会发现，乡村居民愿意走 10 英里远去往某个设施点，而城镇居民则只愿意走 2 英里的路程。您可对此行为进行建模，方法是将位于农村地区的所有请求点的 Cutoff 值设置为 10，然后将位于城市地区的请求点的 Cutoff 值设置为 2。</para>
		/// <para>该属性值的单位由测量单位参数指定。</para>
		/// <para>此属性的值将使用默认测量中断参数覆盖分析的默认设置。默认值为 Null，这将导致系统为所有请求点使用由默认测量中断参数设置的默认值。</para>
		/// <para>ImpedanceTransformation</para>
		/// <para>此属性的值将使用测量变换模型参数覆盖分析的默认设置。</para>
		/// <para>ImpedanceParameter</para>
		/// <para>此属性的值将使用测量变换因子参数覆盖分析的默认设置。</para>
		/// <para>CurbApproach</para>
		/// <para>指定车辆到达或离开请求点的方向。该字段值可指定为以下整数之一（请使用数值代码而非括号中的名称）：</para>
		/// <para>0（车辆的任意一侧）- 从车辆的右侧或左侧均可访问请求点。</para>
		/// <para>1（车辆的右侧）- 当车辆到达或离开请求点时，请求点必须位于车辆右侧。在车辆到达和离开请求点时，停靠点必须位于车辆的右侧。通常用于必须在右侧停靠以便乘客在停靠点下车的车辆（如公共汽车）。</para>
		/// <para>2（车辆的左侧）- 当车辆到达或离开请求点时，请求点必须位于车辆左侧。在车辆到达和离开请求点时，停靠点必须位于车辆的左侧。通常用于必须在左侧停靠以便乘客在停靠点下车的车辆（如公共汽车）。</para>
		/// <para>CurbApproach 属性是专为使用以下两种国家驾驶标准而设计的：右侧通行（美国）和左侧通行（英国）。首先，考虑位于车辆左侧的请求点。不管车辆行驶在左车道还是右车道，停靠点始终位于车辆的左侧。您决定从哪个方向到达请求点（也就是说，请求点必须位于车辆的右侧还是左侧）可能会随国家驾驶标准而有所不同。例如，如果要到达一个请求点并且在车辆与请求点之间不存在其他交通车道，那么在美国请选择 1（车辆的右侧），而在英国请选择 2（车辆的左侧）。</para>
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
		/// <para>指定用于测量请求点和设施点之间行驶时间或行驶距离的单位。工具将根据哪些设施点可通过最少量的行程达到最大量的加权请求，或者通过最少量的行程实现最大量的加权请求可到达哪些设施点来找到最佳设施点。</para>
		/// <para>输出分配线使用不同的单位来报告行驶距离或行驶时间，其中包括您为此参数指定的单位。</para>
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
		public SolveLocationAllocation(object Facilities, object DemandPoints, object MeasurementUnits)
		{
			this.Facilities = Facilities;
			this.DemandPoints = DemandPoints;
			this.MeasurementUnits = MeasurementUnits;
		}

		/// <summary>
		/// <para>Tool Display Name : 求解位置分配</para>
		/// </summary>
		public override string DisplayName() => "求解位置分配";

		/// <summary>
		/// <para>Tool Name : SolveLocationAllocation</para>
		/// </summary>
		public override string ToolName() => "SolveLocationAllocation";

		/// <summary>
		/// <para>Tool Excute Name : agolservices.SolveLocationAllocation</para>
		/// </summary>
		public override string ExcuteName() => "agolservices.SolveLocationAllocation";

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
		public override object[] Parameters() => new object[] { Facilities, DemandPoints, MeasurementUnits, AnalysisRegion!, ProblemType!, NumberOfFacilitiesToFind!, DefaultMeasurementCutoff!, DefaultCapacity!, TargetMarketShare!, MeasurementTransformationModel!, MeasurementTransformationFactor!, TravelDirection!, TimeOfDay!, TimeZoneForTimeOfDay!, UturnAtJunctions!, PointBarriers!, LineBarriers!, PolygonBarriers!, UseHierarchy!, Restrictions!, AttributeParameterValues!, AllocationLineShape!, TravelMode!, Impedance!, SaveOutputNetworkAnalysisLayer!, Overrides!, TimeImpedance!, DistanceImpedance!, OutputFormat!, IgnoreInvalidLocations!, SolveSucceeded!, OutputAllocationLines!, OutputFacilities!, OutputDemandPoints!, OutputNetworkAnalysisLayer!, OutputResultFile!, OutputNetworkAnalysisLayerPackage! };

		/// <summary>
		/// <para>Facilities</para>
		/// <para>指定求解程序将在分析期间选择的一个或多个设施点。求解程序会根据问题类型及所指定的条件，以最有效的方法确定最佳的设施点来分配请求。</para>
		/// <para>在尝试寻找最具竞争力位置的竞争性分析中，竞争设施点也是在此处指定的。</para>
		/// <para>定义设施点后，可使用以下特性为每个设施点设置属性，例如设施点的名称或类型。</para>
		/// <para>Name</para>
		/// <para>设施点的名称。如果设施点为解的一部分，则该名称将包含在输出分配线的名称中。</para>
		/// <para>FacilityType</para>
		/// <para>指定设施点是候选设施点、必选设施点、还是竞争设施点。该字段值可指定为以下整数之一（请使用数值代码而非括号中的名称）：</para>
		/// <para>0（候选项） - 设施点可能是解的一部分。</para>
		/// <para>1（必填项）- 设施点必须为解的一部分。</para>
		/// <para>2（竞争项）- 可能会从您的设施点中移除请求的竞争对手设施点。竞争设施点特定于最大化市场份额与目标市场份额两种问题类型；在其他问题类型中会将其忽略。</para>
		/// <para>Weight</para>
		/// <para>设施点的相对权重，用于评定设施点的吸引力、有利条件或一个设施点较之另一个设施点的差异。</para>
		/// <para>例如，一个值为 2.0 的权重更好地体现了客户的购物意愿，客户在高权重设施点处购物的意愿强于普通权重设施点处的购物意愿，差距达到 2 倍。可能影响设施点权重的因素包括建筑物面积、街区环境以及建筑物的使用年限。非 1 权重值仅适用于最大化市场份额与目标市场份额两种问题类型；在其他问题类型中会将其忽略。</para>
		/// <para>Cutoff</para>
		/// <para>停止从指定设施点搜索请求点时所对应的阻抗值。如果设施点超出此处所示的值，则无法将请求点分配至该设施点。</para>
		/// <para>您可利用此属性为每个请求点指定不同的中断值。例如，您可能会发现，乡村居民愿意走 10 英里远去往某个设施点，而城镇居民则只愿意走 2 英里的路程。您可对此行为进行建模，方法是将位于农村地区的所有请求点的 Cutoff 值设置为 10，然后将位于城市地区的请求点的 Cutoff 值设置为 2。</para>
		/// <para>Capacity</para>
		/// <para>Capacity 字段特定于“最大化有容量限制的覆盖范围”问题类型；其他问题类型将忽略此字段。</para>
		/// <para>容量用于指定该设施点能够供应多少加权请求。即使请求在设施点的默认测量中断范围内，求解程序也不会将超出容量的请求分配到设施点。</para>
		/// <para>分配到 Capacity 字段的任意值会覆盖给定设施点的默认容量参数（Python 中的 Default_Capacity）。</para>
		/// <para>CurbApproach</para>
		/// <para>指定车辆到达或离开设施点的方向。该字段值可指定为以下整数之一（请使用数值代码而非括号中的名称）：</para>
		/// <para>0（车辆的任意一侧）- 从车辆的右侧或左侧均可访问设施点。</para>
		/// <para>1（车辆的右侧）- 当车辆到达或离开设施点时，设施点必须位于车辆右侧。通常用于必须在右侧停靠以便乘客在停靠点下车的车辆（如公共汽车）。</para>
		/// <para>2（车辆的左侧）- 当车辆到达或离开设施点时，设施点必须位于车辆左侧。在车辆到达和离开设施点时，停靠点必须位于车辆的左侧。通常用于必须在左侧停靠以便乘客在停靠点下车的车辆（如公共汽车）。</para>
		/// <para>CurbApproach 属性是专为使用以下两种国家驾驶标准而设计的：右侧通行（美国）和左侧通行（英国）。首先，考虑位于车辆左侧的设施点。不管车辆行驶在左车道还是右车道，停靠点始终位于车辆的左侧。决定从其中任一方向到达设施点可能会更改国家驾驶标准，也就是说，从车辆的右侧或左侧靠近事件点。例如，如果要到达一个设施点并且在车辆与事件点之间不存在交通车道，那么在美国请选择 1（车辆的右侧），而在英国请选择 2（车辆的左侧）。</para>
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
		/// <para>Demand Points</para>
		/// <para>指定一个或多个请求点。此求解程序在很大程度上会根据这些设施点对此处所指定的请求点的服务状况来确定最佳设施点。</para>
		/// <para>请求点通常是指对设施点提供的货物和服务有需求的人或物品的位置。请求点可以是根据居住在此处的人数进行加权的邮编区域的质心，也可以是根据这些人员产生的预计消费来加权的邮编区域质心。请求点也可以表示商业客户。如果您提供的业务具有很高的库存周转率，则它们将比低周转率的业务具有更高的加权值。</para>
		/// <para>指定请求点后，可使用以下特性为每个请求点设置属性，例如请求点的名称或权重。</para>
		/// <para>Name</para>
		/// <para>请求点的名称。如果请求点为解的一部分，则该名称将包含在输出分配线的名称中。</para>
		/// <para>GroupName</para>
		/// <para>请求点所属组的名称。最大化有容量限制的覆盖范围、目标市场份额和最大化市场份额问题类型将忽略此字段。</para>
		/// <para>如果请求点共享组名称，则求解程序会将组的所有成员分配给同一设施点。（如果某些约束（如中断距离）阻止组中的任意请求点到达同一设施点，则不对任何请求点进行分配。）</para>
		/// <para>Weight</para>
		/// <para>请求点的相对权重。权重值为 2.0 表示请求点的重要性是该值为 1.0 的请求点的两倍。例如，如果请求点代表家庭，则权重可表示每个家庭中的人数。</para>
		/// <para>Cutoff</para>
		/// <para>停止从指定设施点搜索请求点时所对应的阻抗值。如果设施点超出此处所示的值，则无法将请求点分配至该设施点。</para>
		/// <para>您可利用此属性为每个请求点指定中断值。例如，您可能会发现，乡村居民愿意走 10 英里远去往某个设施点，而城镇居民则只愿意走 2 英里的路程。您可对此行为进行建模，方法是将位于农村地区的所有请求点的 Cutoff 值设置为 10，然后将位于城市地区的请求点的 Cutoff 值设置为 2。</para>
		/// <para>该属性值的单位由测量单位参数指定。</para>
		/// <para>此属性的值将使用默认测量中断参数覆盖分析的默认设置。默认值为 Null，这将导致系统为所有请求点使用由默认测量中断参数设置的默认值。</para>
		/// <para>ImpedanceTransformation</para>
		/// <para>此属性的值将使用测量变换模型参数覆盖分析的默认设置。</para>
		/// <para>ImpedanceParameter</para>
		/// <para>此属性的值将使用测量变换因子参数覆盖分析的默认设置。</para>
		/// <para>CurbApproach</para>
		/// <para>指定车辆到达或离开请求点的方向。该字段值可指定为以下整数之一（请使用数值代码而非括号中的名称）：</para>
		/// <para>0（车辆的任意一侧）- 从车辆的右侧或左侧均可访问请求点。</para>
		/// <para>1（车辆的右侧）- 当车辆到达或离开请求点时，请求点必须位于车辆右侧。在车辆到达和离开请求点时，停靠点必须位于车辆的右侧。通常用于必须在右侧停靠以便乘客在停靠点下车的车辆（如公共汽车）。</para>
		/// <para>2（车辆的左侧）- 当车辆到达或离开请求点时，请求点必须位于车辆左侧。在车辆到达和离开请求点时，停靠点必须位于车辆的左侧。通常用于必须在左侧停靠以便乘客在停靠点下车的车辆（如公共汽车）。</para>
		/// <para>CurbApproach 属性是专为使用以下两种国家驾驶标准而设计的：右侧通行（美国）和左侧通行（英国）。首先，考虑位于车辆左侧的请求点。不管车辆行驶在左车道还是右车道，停靠点始终位于车辆的左侧。您决定从哪个方向到达请求点（也就是说，请求点必须位于车辆的右侧还是左侧）可能会随国家驾驶标准而有所不同。例如，如果要到达一个请求点并且在车辆与请求点之间不存在其他交通车道，那么在美国请选择 1（车辆的右侧），而在英国请选择 2（车辆的左侧）。</para>
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
		public object DemandPoints { get; set; }

		/// <summary>
		/// <para>Measurement Units</para>
		/// <para>指定用于测量请求点和设施点之间行驶时间或行驶距离的单位。工具将根据哪些设施点可通过最少量的行程达到最大量的加权请求，或者通过最少量的行程实现最大量的加权请求可到达哪些设施点来找到最佳设施点。</para>
		/// <para>输出分配线使用不同的单位来报告行驶距离或行驶时间，其中包括您为此参数指定的单位。</para>
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
		/// <para>Problem Type</para>
		/// <para>指定位置分配分析的目标。 默认的目标为最小化阻抗。</para>
		/// <para>最小化阻抗—也称为 P 中位数问题类型。 将设施点设置在适当的位置，以使请求点与设施点的解之间的所有加权行驶时间或距离之和最小。 （加权行驶为分配给设施点的请求量乘以到达该设施点的行驶距离或行驶时间。）此问题类型通常用于仓库选址，因为它可以减少将货物运送到各销售店的总运输成本。 因为最小化阻抗可减少公众到达选定设施点所需行进的总距离，所以，通常认为对于某些公共机构（例如，图书馆、区域机场、博物馆、机动车辆管理部门及医疗诊所）的选址而言，选择不具有阻抗中断的最小化阻抗问题类型比其他问题类型更加合理。下面描述了“最小化阻抗”这一问题类型对请求的处理方法：</para>
		/// <para>如果某个请求点因设置中断距离或中断时间而无法到达任何设施点，则不对其进行分配。</para>
		/// <para>如果某个请求点只能到达一个设施点，则该请求点会将其所有请求权重分配给该设施点。</para>
		/// <para>如果某个请求点能到达两个或多个设施点，则该请求点会将其所有请求权重仅分配给最近设施点。</para>
		/// <para>最大化覆盖范围—将设施点设置在适当的位置，以使尽可能多的请求被分配到所求解的设施点的阻抗中断内。“最大化覆盖范围”常用于定位消防站、警察局和 ERS 中心，因为紧急救援服务通常需要在指定响应时间内到达所有请求点位置。 请注意，具有准确精密的数据，以确保分析结果能够准确的为真实世界建模，这对所有组织都十分重要，对紧急救援服务尤为关键。与在店内就餐的比萨饼店相反，比萨外卖业务会试图将店址设在一定车程时间范围内可以覆盖最多人口的位置。 定购比萨外卖的人通常不关心比萨饼店的远近；他们只关心比萨是否能够在店家所说的时间内送达。 因此，比萨外卖业务会从其所说的送货时间中减去比萨制作时间，并针对最大化覆盖范围这一问题类型进行求解，以选出在覆盖区域中能够争取到最多潜在顾客的候选设施点。 （在店内就餐的比萨饼店的潜在顾客受距离的影响更大，因为他们要前往餐馆就餐，因此人流量最大化和市场份额两种问题类型更适合于此种情况。）以下列表描述了“最大化覆盖范围”这一问题类型对请求的处理方法：</para>
		/// <para>如果某个请求点因中断距离或中断时间而无法到达任何设施点，则不对其进行分配。</para>
		/// <para>如果某个请求点只能到达一个设施点，则该请求点会将其所有请求权重分配给该设施点。</para>
		/// <para>如果某个请求点能到达两个或多个设施点，则该请求点会将其所有请求权重仅分配给最近设施点。</para>
		/// <para>最大化有容量限制的覆盖范围—将设施点设置在适当的位置，以满足所有或最大数量的请求而不超出任何设施点的容量。“最大化有容量限制的覆盖范围”的工作方式与“最小化阻抗”和“最大化覆盖范围”问题类型相似，但增加了容量限制。 可指定单个设施点的容量，方法是将输入设施点中的数值分配到其对应的 Capacity 字段。 如果 Capacity 字段值为空，则从默认容量属性中为该设施点分配容量。在下列情况下可使用“最大化有容量限制的覆盖范围”问题类型：创建包含给定人员数量或业务数量的区域；查找病床数量有限或可治疗的患者数量有限的医院或其他医疗设施点；以及查找未将其库存假定为无限的仓库。以下列表描述了“最大化有容量限制的覆盖范围”这一问题类型对请求的处理方法：</para>
		/// <para>与最大化覆盖范围不同，最大化有容量限制的覆盖范围并不需要默认测量中断参数值；然而，当指定中断时，不可对所有设施点中断时间或距离以外的任何请求点进行分配。</para>
		/// <para>被分配的请求点具有所有或零个分配到设施点的请求权重；也就是说，不可使用此问题类型来分配请求。</para>
		/// <para>如果设施点可达到的总请求大于设施点容量，那么只可分配能够最大化总占有请求和最小化总加权行驶的请求点。当请求点被分配到的设施点不是最近设施点解时，您可能会注意到效率明显减低。 在请求点具有不同的权重时以及在所涉及的请求点可到达超过一个设施点时，可能会发生这种情况。 这类结果表示，最近设施点解对于加权请求没有足够的容量或整个问题的最有效解需要一个或多个局部低效率情况。 在任何一种情况下，解都是正确的。</para>
		/// <para>最小化设施点数—对设施点进行选择，以在行驶时间或行驶距离中断范围内使尽可能多的加权请求被分配到所求解的设施点；此外，还要使覆盖请求所需的设施点数量最小化。除需考虑要定位的设施点数目（此数目由求解程序确定）外，最小化设施点数与最大化覆盖范围相同。 如无需限制设施点建造成本这一因素，则原本使用最大化覆盖范围（如应急响应）的组织可应用最小化设施点来求解，以使所有可能的请求点全部都能得到设施点覆盖。以下列表描述了“最小化设施点数”这一问题类型对请求的处理方法：</para>
		/// <para>如果某个请求点因中断距离或中断时间而无法到达任何设施点，则不对其进行分配。</para>
		/// <para>如果某个请求点只能到达一个设施点，则该请求点会将其所有请求权重分配给该设施点。</para>
		/// <para>如果某个请求点能到达两个或多个设施点，则该请求点会将其所有请求权重仅分配给最近设施点。</para>
		/// <para>最大化人流量—在假定请求权重因设施点与请求点间距离的增加而减少的前提下，将设施点定位在能够将尽可能多的请求权重分配给设施点的位置上。很少或没有竞争的专卖店适合该问题类型，但当缺乏有关市场份额这一问题类型分析所需的竞争对手的数据时，它也可以用于普通零售店和餐馆。 其他适合该问题类型的业务包括咖啡店、健身中心、牙医及诊所和电子商品店。 公交车站的选址通常也使用“最大化人流量”进行分析。 “最大化人流量”假定人们到达设施点所需行进的距离越远，他们就越不可能去利用它。 这一假定的具体表现就是分配至设施点的请求数量会随距离的增加而减少。以下列表描述了“最大化人流量”这一问题类型对请求的处理方法：</para>
		/// <para>如果某个请求点因中断距离或中断时间而无法到达任何设施点，则不对其进行分配。</para>
		/// <para>如果某个请求点可到达一个设施点，则仅将其请求权重部分分配给该设施点。 所分配的量会按设施点与请求点间最大中断距离（或时间）和行驶距离（或时间）的函数而减少。</para>
		/// <para>如果请求点可到达多个设施点，则仅将其权重按比例分配给最近的设施点。</para>
		/// <para>最大化市场份额—选择一定数量的设施点，以保证存在竞争对手的情况下分配到最多的请求。 其目标是利用您所指定数量的设施点占有尽可能多的总市场份额。 总市场份额是有效请求点的所有请求权重之和。市场份额问题类型需要的数据最多，因为除了自己的权重之外，您还需要知道竞争对手设施点的权重。 如果您已拥有包括竞争对手数据在内的全面信息，那么原先使用最大化人流量问题类型的设施点也可以使用市场份额这一问题类型。 大型折扣店通常使用最大化市场份额来为少量的几个新店选址。 市场份额这一问题类型将使用 Huff（赫夫）模型，该模型也称作重力模型或空间交互模型。以下列表描述了“最大化市场份额”这一问题类型对请求的处理方法：</para>
		/// <para>如果某个请求点因中断距离或中断时间而无法到达任何设施点，则不对其进行分配。</para>
		/// <para>如果某个请求点只能到达一个设施点，则该请求点会将其所有请求权重分配给该设施点。</para>
		/// <para>如果某个请求点可到达两个或多个设施点，则该请求点会将其所有请求权重分配给这些设施点；然后，按照与设施点的吸引力（设施点权重）成正比、与设施点和请求点之间距离成反比的方式在各设施点之间分割请求权重。 如果各设施点的权重相同，则与远处的设施点相比，近处的设施点将分配到更多的请求权重。</para>
		/// <para>总市场份额可用于计算所占有的市场份额，是有效请求点的所有权重之和。</para>
		/// <para>目标市场份额—可在存在竞争者的情况下，选出占有总市场份额指定百分比所需的设施点的最小数量。 总市场份额是有效请求点的所有请求权重之和。 设置希望占有的市场份额的百分比，然后由求解程序确定满足该阈值所需的最小设施点数。市场份额问题类型需要的数据最多，因为除了自己的权重之外，您还需要知道竞争对手设施点的权重。 如果您已拥有包括竞争对手数据在内的全面信息，那么原先使用最大化人流量问题类型的设施点也可以使用市场份额这一问题类型。当希望了解要占有指定的市场份额需要进行多大程度的扩张，或在出现新的竞争设施点的情况下需要采取何种措施来保证当前的市场额时，大型折扣店通常会使用“目标市场份额”这一问题类型。 如果不考虑预算，求解结果通常可以作为商店应当采取的措施。 在考虑预算的其他情况下，商店就回到了最大化市场份额的问题类型，这时只要以确定的设施点数争取到尽可能大的市场份额即可。以下列表描述了“目标市场份额”这一问题类型对请求的处理方法：</para>
		/// <para>总市场份额用于计算所占有的市场份额，是有效请求点的所有权重之和。</para>
		/// <para>如果某个请求点因中断距离或中断时间而无法到达任何设施点，则不对其进行分配。</para>
		/// <para>如果某个请求点只能到达一个设施点，则该请求点会将其所有请求权重分配给该设施点。</para>
		/// <para>如果某个请求点可到达两个或多个设施点，则该请求点会将其所有请求权重分配给这些设施点；然后，按照与设施点的吸引力（设施点权重）成正比、与设施点和请求点之间距离成反比的方式在各设施点之间分割请求权重。 如果各设施点的权重相同，则与远处的设施点相比，近处的设施点将分配到更多的请求权重。</para>
		/// <para><see cref="ProblemTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Location-Allocation Problem Settings")]
		public object? ProblemType { get; set; } = "Minimize Impedance";

		/// <summary>
		/// <para>Number of Facilities to Find</para>
		/// <para>要查找的设施点数。默认值为 1。</para>
		/// <para>始终要首先选择 FacilityType 字段值为 1（必选项）的设施点。任何额外设施点都将从候选设施点中选择，其 FacilityType 字段值为 2。</para>
		/// <para>在求解前所有 FacilityType 值为 3（已选项）的设施点在求解时都将视为候选设施点。</para>
		/// <para>如果要查找的设施点数低于必选设施点数，则出现错误。</para>
		/// <para>对于“最小化设施点数”和“目标市场份额”问题类型，禁用了要查找的设施点数，因为求解程序需要确定满足目标时所需的设施点的最少个数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Location-Allocation Problem Settings")]
		public object? NumberOfFacilitiesToFind { get; set; } = "1";

		/// <summary>
		/// <para>Default Measurement Cutoff</para>
		/// <para>请求点与其分配到的设施点之间所允许的最大行驶时间或行驶距离。如果请求点位于设施点中断范围之外，则不会被分配给此设施点。</para>
		/// <para>默认值为无，表示不应用中断限制。</para>
		/// <para>该参数的单位与通过测量单位参数指定的单位相同。</para>
		/// <para>行驶时间或距离中断是按照沿道路行驶的最短路径测量的。</para>
		/// <para>此参数可用于对人们为前往商店而愿意行进的最大距离，以及消防站到达社区中任一请求点所允许的最大时间进行建模。</para>
		/// <para>请注意，请求点包含 Cutoff 字段，如果进行相应设置，该字段将覆盖默认测量中断参数。您可能会发现，乡村居民愿意走 10 英里远去往某个设施点，而城镇居民则只愿意走 2 英里的路程。假设将测量单位设置为英里，可按如下方式对此行为进行建模：将默认测量中断设置为 10 并将城区中请求点的 Cutoff 字段值设置为 2。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Location-Allocation Problem Settings")]
		public object? DefaultMeasurementCutoff { get; set; }

		/// <summary>
		/// <para>Default Capacity</para>
		/// <para>此参数特定于“最大化有容量限制的覆盖范围”问题类型。它是在分析中分配到所有设施点的默认容量。您可以通过在设施点的 Capacity 字段中指定值来覆盖设施点的默认容量。</para>
		/// <para>默认值为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Location-Allocation Problem Settings")]
		public object? DefaultCapacity { get; set; } = "1";

		/// <summary>
		/// <para>Target Market Share</para>
		/// <para>此参数特定于“目标市场份额”问题类型。它是您希望已选和必选设施点占总请求权重的百分比。求解程序会确定为占有此处所指定目标市场份额所需的最小设施点数。</para>
		/// <para>默认值为 10%。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Location-Allocation Problem Settings")]
		public object? TargetMarketShare { get; set; } = "10";

		/// <summary>
		/// <para>Measurement Transformation Model</para>
		/// <para>此属性可设置对设施点与请求点间网络成本进行变换的方程。此参数还可与阻抗参数结合使用，指定设施点与请求点间的网络阻抗对于求解程序选择设施点的影响的严重程度。</para>
		/// <para>在以下变换选项的列表中，d 指的是请求点，f 指的是设施点。阻抗是指两个位置之间的最短行驶距离或时间。所以阻抗df 即为请求点 d 与设施点 f 之间的最短路径（时间或距离），成本df 即为设施点与请求点之间变换的行驶时间或距离。Lambda (λ) 表示阻抗参数。测量单位参数决定了是分析行驶时间还是行驶距离。</para>
		/// <para>线性—成本df = λ * 阻抗df设施点与请求点之间的变换行驶时间或距离与两个位置之间最短路径的时间或距离相同。 使用此选项，阻抗参数 (λ) 始终设置为 1。 这是默认设置。</para>
		/// <para>幂—成本df = 阻抗dfλ设施点和请求点之间变换的行驶时间或距离等于以最短路径的时间或距离为底，以阻抗参数 (λ) 所指定的数为指数的幂运算结果。 将幂函数选项与正阻抗参数结合使用可对附近的设施点指定较高的权重。</para>
		/// <para>指数—成本df = e（λ * 阻抗df）设施点和请求点之间变换的行驶时间或距离等于以数学常量 e 为底，以最短路径网络阻抗所指定的数为指数的幂乘以阻抗参数 (λ)。 将指数选项与正阻抗参数结合使用可对附近的设施点指定高权重。</para>
		/// <para>为此参数设置的值可以通过输入请求点中的 ImpedanceTransformation 字段覆盖每个请求点。</para>
		/// <para><see cref="MeasurementTransformationModelEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Location-Allocation Problem Settings")]
		public object? MeasurementTransformationModel { get; set; } = "Linear";

		/// <summary>
		/// <para>Measurement Transformation Factor</para>
		/// <para>为测量变换模型参数中指定的方程提供参数值。当阻抗变换的类型为线性时会忽略参数值。对于幂阻抗变换和指数阻抗变换，应设置非零值。</para>
		/// <para>默认值为 1。</para>
		/// <para>为此参数设置的值可以通过输入请求点中的 ImpedanceParameter 字段覆盖每个请求点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Location-Allocation Problem Settings")]
		public object? MeasurementTransformationFactor { get; set; } = "1";

		/// <summary>
		/// <para>Travel Direction</para>
		/// <para>指定是测量从设施点到请求点还是从请求点到设施点的行驶时间或行驶距离。</para>
		/// <para>设施点到请求点—行驶方向是从设施点指向请求点。 这是默认设置。</para>
		/// <para>请求点到设施点—行驶方向是从请求点指向设施点。</para>
		/// <para>行驶时间和距离可能会随行驶方向的不同而发生改变。由于单行道和转弯限制，从点 A 行驶到点 B 时可能会比从点 B 行驶到点 A 时交通更畅通或者路径更短。例如，从点 A 行驶到点 B 可能需要 10 分钟，而反过来可能需要 15 分钟。这些测量差异可能会影响到请求点是否因中断而能够被分配到特定的设施点，或者在分配请求的问题类型中，可能会影响所争取到的请求数量。</para>
		/// <para>消防部门通常按从设施点到请求点的方向进行测量，因为他们需要关注从消防站（设施点）行驶到紧急救援位置（请求点）所花的时间。零售商店管理层则更关注顾客（请求点）到达商店（设施点）所需的时间；因此，商店管理层常按从请求点到设施点的方向进行测量。</para>
		/// <para>行驶方向还决定了所提供的任何开始时间的意义。有关详细信息，请参阅时间参数。</para>
		/// <para><see cref="TravelDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Analysis")]
		public object? TravelDirection { get; set; } = "Facility to Demand";

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>行进的开始时间。如果测量单位不是基于时间的，则忽略此参数。默认值是无时间或日期。如果未指定时间，求解程序将使用通用速度，通常为所发布限速要求中的速度。</para>
		/// <para>在实际生活中，交通流量是不断变化的，设施点和请求点之间的行驶时间会随着交通流量的变化而波动。因此，通过多次分析指示的不同时间和日期值可能会影响到将请求分配给设施点的方式以及和结果中所选的设施点。</para>
		/// <para>时间始终表示开始时间。但行驶可能从设施点也可能从请求点开始；具体取决于对行驶方向参数进行的选择。</para>
		/// <para>时间的时区参数指定该时间和日期是参考 UTC 还是设施点或请求点所在时区。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Advanced Analysis")]
		public object? TimeOfDay { get; set; }

		/// <summary>
		/// <para>Time Zone for Time of Day</para>
		/// <para>指定时间参数的时区。默认值为本地地理位置。</para>
		/// <para>本地地理位置—时间参数是指设施点或请求点所处的时区。 如果行驶方向是从设施点到请求点，此为设施点所处的时区。 如果行驶方向是从请求点到设施点，此为请求点所处的时区。</para>
		/// <para>UTC—时间参数是指协调世界时间 (UTC)。 如果您想要在指定时间内（如现在）找到最佳位置，但不确定设施点或请求点所在的时区，请选择此选项。</para>
		/// <para>无论时间的时区参数值如何，如果您的设施点和请求点在多个时区中，则工具将强制执行以下规则：</para>
		/// <para>指定一天中的某个时间并且行驶方向为从设施点到请求点时，所有设施点必须处于同一时区。</para>
		/// <para>指定一天中的某个时间并且行驶方向为从请求点到设施点时，所有请求点必须处于同一时区。</para>
		/// <para><see cref="TimeZoneForTimeOfDayEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Analysis")]
		public object? TimeZoneForTimeOfDay { get; set; } = "Geographically Local";

		/// <summary>
		/// <para>UTurn at Junctions</para>
		/// <para>&lt;para/&gt;指定交汇点的 U 形转弯策略。 允许 U 形转弯表示求解程序可以在交汇点处转向并沿同一街道往回行驶。 考虑到交汇点表示街道交叉路口和死角，不同的车辆可以在某些交汇点转弯，而在其他交汇点则不行 - 这取决于交汇点是交叉路口还是死角。 为适应此情况，U 形转弯策略参数由连接到交汇点的边数隐性指定，这称为交汇点价。 此参数可接受的值如下所列；每个值的后面是根据交汇点价对其含义的描述。</para>
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
		public object? UturnAtJunctions { get; set; } = "Allowed Only at Intersections and Dead Ends";

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
		/// <para>Use Hierarchy</para>
		/// <para>指定是否将在查找设施点和请求点之间的最短路径时使用等级。</para>
		/// <para>选中 (True) - 在设施点和请求点之间进行测量时将使用等级。在应用等级时，相比低等级的街道（例如地方道路），该工具更偏好等级较高的街道（例如高速公路），且该工具可以用于模拟驾驶员对在高速公路（而非地方道路）上行驶的偏好，即使这意味着行程更远。查找远距离位置的路径时尤为如此，因为长途驾驶员往往更偏好于在高速公路上行驶，这样可以避免停靠、交叉路口和转弯。应用等级可实现更快的计算速度，尤其是对于长途路径来说，因为该工具可以在相对较小的街道子集中确定最佳路径。</para>
		/// <para>未选中 (False) - 在设施点和请求点之间进行测量时将不使用等级。如果没有应用等级，该工具就会考虑所有的街道且在选择路线时不会选择等级较高的街道。这常用于在市内查找短途路径。</para>
		/// <para>如果设施点和请求点间的直线距离大于 50 英里，即使您设置此参数为不使用等级，工具也会自动转换为使用等级。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[Category("Custom Travel Mode")]
		public object? UseHierarchy { get; set; } = "true";

		/// <summary>
		/// <para>Restrictions</para>
		/// <para>指定查找设施点和请求点间的最佳路径时工具将使用的约束条件。</para>
		/// <para>限制表示行驶偏好或要求。 大多数情况下，限制条件会导致道路禁行。 例如，使用“避开收费公路”限制的结果是，仅在访问某一事件点或设施点需要借道收费公路时，才会生成一条包含该收费公路的路径。 高度限制则使您可以绕开低于车辆高度的间隙。 如果车辆上装载着腐蚀性物质，使用“禁止任何危险物品”限制将防止在标记着运输腐蚀性材料为非法行为的路上运输这些材料。</para>
		/// <para>某些限制需要指定一个额外值以供它们使用。 该值必须与限制名称和用于限制的特定参数相关联。 可识别名称在属性参数值参数的 AttributeName 列中显示的限制。 在查找可遍历道路时，要正确使用限制，请指定属性参数值参数的 ParameterValue 字段。</para>
		/// <para>有些限制仅适用于某些国家/地区；下表按区域显示了这些限制的可用性。 关于在某区域内可用性有限的限制，通过在网络分析覆盖范围上查看“国家/地区列表”部分中的表，可以确定该限制在特定国家/地区是否可用。 如果一个国家/地区具有 Logistics Attribute 列的 Yes 值，则该国家/地区支持具有区域可选性的限制。 如果您指定的限制名称在事件点所在的国家/地区不可用，该服务会忽略无效限制。 该服务还会忽略约束条件用法属性参数值为 0 到 1（请参阅属性参数值参数）时的约束条件。 它会禁止约束条件用法参数值大于 0 时的所有约束条件。</para>
		/// <para>除非将出行模式设置为自定义，否则会忽略您为此参数提供的值。</para>
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
		/// <para>Allocation Line Shape</para>
		/// <para>指定工具输出的线要素的类型。参数可接受以下值之一：</para>
		/// <para>Straight Line—返回所求解的设施点与为其分配的请求点之间的直线。 这是默认设置。 在地图上绘制直线有助于直观地查看请求是如何分配的。</para>
		/// <para>None—返回表，其中含有有关所求解的设施点与为其分配的请求点之间最短路径的数据，而不返回线。</para>
		/// <para>无论选择哪种分配线形状参数值，最短路径始终通过最大限度地缩短行驶时间或行驶距离，而不是使用请求点和设施点间的直线距离来确定。也就是说，此参数只更改输出线形状；而不更改测量方法。</para>
		/// <para><see cref="AllocationLineShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object? AllocationLineShape { get; set; } = "Straight Line";

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
		/// <para>如果选择基于时间的阻抗，例如 TravelTime、TruckTravelTime、Minutes、TruckMinutes 或 WalkTime，则测量单位参数必须设置为基于时间的值。 如果您选择基于距离的阻抗（例如 Miles 或 Kilometers），则测量单位必须基于距离。</para>
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
		/// <para>Solve Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? SolveSucceeded { get; set; }

		/// <summary>
		/// <para>Output Allocation Lines</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? OutputAllocationLines { get; set; }

		/// <summary>
		/// <para>Output Facilities</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? OutputFacilities { get; set; }

		/// <summary>
		/// <para>Output Demand Points</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? OutputDemandPoints { get; set; }

		/// <summary>
		/// <para>Output Network Analysis Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? OutputNetworkAnalysisLayer { get; set; } = "scratchfile";

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
		/// <para>Problem Type</para>
		/// </summary>
		public enum ProblemTypeEnum 
		{
			/// <summary>
			/// <para>最大化人流量—在假定请求权重因设施点与请求点间距离的增加而减少的前提下，将设施点定位在能够将尽可能多的请求权重分配给设施点的位置上。很少或没有竞争的专卖店适合该问题类型，但当缺乏有关市场份额这一问题类型分析所需的竞争对手的数据时，它也可以用于普通零售店和餐馆。 其他适合该问题类型的业务包括咖啡店、健身中心、牙医及诊所和电子商品店。 公交车站的选址通常也使用“最大化人流量”进行分析。 “最大化人流量”假定人们到达设施点所需行进的距离越远，他们就越不可能去利用它。 这一假定的具体表现就是分配至设施点的请求数量会随距离的增加而减少。以下列表描述了“最大化人流量”这一问题类型对请求的处理方法：</para>
			/// </summary>
			[GPValue("Maximize Attendance")]
			[Description("最大化人流量")]
			Maximize_Attendance,

			/// <summary>
			/// <para>最大化有容量限制的覆盖范围—将设施点设置在适当的位置，以满足所有或最大数量的请求而不超出任何设施点的容量。“最大化有容量限制的覆盖范围”的工作方式与“最小化阻抗”和“最大化覆盖范围”问题类型相似，但增加了容量限制。 可指定单个设施点的容量，方法是将输入设施点中的数值分配到其对应的 Capacity 字段。 如果 Capacity 字段值为空，则从默认容量属性中为该设施点分配容量。在下列情况下可使用“最大化有容量限制的覆盖范围”问题类型：创建包含给定人员数量或业务数量的区域；查找病床数量有限或可治疗的患者数量有限的医院或其他医疗设施点；以及查找未将其库存假定为无限的仓库。以下列表描述了“最大化有容量限制的覆盖范围”这一问题类型对请求的处理方法：</para>
			/// </summary>
			[GPValue("Maximize Capacitated Coverage")]
			[Description("最大化有容量限制的覆盖范围")]
			Maximize_Capacitated_Coverage,

			/// <summary>
			/// <para>最大化覆盖范围—将设施点设置在适当的位置，以使尽可能多的请求被分配到所求解的设施点的阻抗中断内。“最大化覆盖范围”常用于定位消防站、警察局和 ERS 中心，因为紧急救援服务通常需要在指定响应时间内到达所有请求点位置。 请注意，具有准确精密的数据，以确保分析结果能够准确的为真实世界建模，这对所有组织都十分重要，对紧急救援服务尤为关键。与在店内就餐的比萨饼店相反，比萨外卖业务会试图将店址设在一定车程时间范围内可以覆盖最多人口的位置。 定购比萨外卖的人通常不关心比萨饼店的远近；他们只关心比萨是否能够在店家所说的时间内送达。 因此，比萨外卖业务会从其所说的送货时间中减去比萨制作时间，并针对最大化覆盖范围这一问题类型进行求解，以选出在覆盖区域中能够争取到最多潜在顾客的候选设施点。 （在店内就餐的比萨饼店的潜在顾客受距离的影响更大，因为他们要前往餐馆就餐，因此人流量最大化和市场份额两种问题类型更适合于此种情况。）以下列表描述了“最大化覆盖范围”这一问题类型对请求的处理方法：</para>
			/// </summary>
			[GPValue("Maximize Coverage")]
			[Description("最大化覆盖范围")]
			Maximize_Coverage,

			/// <summary>
			/// <para>最大化市场份额—选择一定数量的设施点，以保证存在竞争对手的情况下分配到最多的请求。 其目标是利用您所指定数量的设施点占有尽可能多的总市场份额。 总市场份额是有效请求点的所有请求权重之和。市场份额问题类型需要的数据最多，因为除了自己的权重之外，您还需要知道竞争对手设施点的权重。 如果您已拥有包括竞争对手数据在内的全面信息，那么原先使用最大化人流量问题类型的设施点也可以使用市场份额这一问题类型。 大型折扣店通常使用最大化市场份额来为少量的几个新店选址。 市场份额这一问题类型将使用 Huff（赫夫）模型，该模型也称作重力模型或空间交互模型。以下列表描述了“最大化市场份额”这一问题类型对请求的处理方法：</para>
			/// </summary>
			[GPValue("Maximize Market Share")]
			[Description("最大化市场份额")]
			Maximize_Market_Share,

			/// <summary>
			/// <para>最小化设施点数—对设施点进行选择，以在行驶时间或行驶距离中断范围内使尽可能多的加权请求被分配到所求解的设施点；此外，还要使覆盖请求所需的设施点数量最小化。除需考虑要定位的设施点数目（此数目由求解程序确定）外，最小化设施点数与最大化覆盖范围相同。 如无需限制设施点建造成本这一因素，则原本使用最大化覆盖范围（如应急响应）的组织可应用最小化设施点来求解，以使所有可能的请求点全部都能得到设施点覆盖。以下列表描述了“最小化设施点数”这一问题类型对请求的处理方法：</para>
			/// </summary>
			[GPValue("Minimize Facilities")]
			[Description("最小化设施点数")]
			Minimize_Facilities,

			/// <summary>
			/// <para>最小化阻抗—也称为 P 中位数问题类型。 将设施点设置在适当的位置，以使请求点与设施点的解之间的所有加权行驶时间或距离之和最小。 （加权行驶为分配给设施点的请求量乘以到达该设施点的行驶距离或行驶时间。）此问题类型通常用于仓库选址，因为它可以减少将货物运送到各销售店的总运输成本。 因为最小化阻抗可减少公众到达选定设施点所需行进的总距离，所以，通常认为对于某些公共机构（例如，图书馆、区域机场、博物馆、机动车辆管理部门及医疗诊所）的选址而言，选择不具有阻抗中断的最小化阻抗问题类型比其他问题类型更加合理。下面描述了“最小化阻抗”这一问题类型对请求的处理方法：</para>
			/// </summary>
			[GPValue("Minimize Impedance")]
			[Description("最小化阻抗")]
			Minimize_Impedance,

			/// <summary>
			/// <para>目标市场份额—可在存在竞争者的情况下，选出占有总市场份额指定百分比所需的设施点的最小数量。 总市场份额是有效请求点的所有请求权重之和。 设置希望占有的市场份额的百分比，然后由求解程序确定满足该阈值所需的最小设施点数。市场份额问题类型需要的数据最多，因为除了自己的权重之外，您还需要知道竞争对手设施点的权重。 如果您已拥有包括竞争对手数据在内的全面信息，那么原先使用最大化人流量问题类型的设施点也可以使用市场份额这一问题类型。当希望了解要占有指定的市场份额需要进行多大程度的扩张，或在出现新的竞争设施点的情况下需要采取何种措施来保证当前的市场额时，大型折扣店通常会使用“目标市场份额”这一问题类型。 如果不考虑预算，求解结果通常可以作为商店应当采取的措施。 在考虑预算的其他情况下，商店就回到了最大化市场份额的问题类型，这时只要以确定的设施点数争取到尽可能大的市场份额即可。以下列表描述了“目标市场份额”这一问题类型对请求的处理方法：</para>
			/// </summary>
			[GPValue("Target Market Share")]
			[Description("目标市场份额")]
			Target_Market_Share,

		}

		/// <summary>
		/// <para>Measurement Transformation Model</para>
		/// </summary>
		public enum MeasurementTransformationModelEnum 
		{
			/// <summary>
			/// <para>线性—成本df = λ * 阻抗df设施点与请求点之间的变换行驶时间或距离与两个位置之间最短路径的时间或距离相同。 使用此选项，阻抗参数 (λ) 始终设置为 1。 这是默认设置。</para>
			/// </summary>
			[GPValue("Linear")]
			[Description("线性")]
			Linear,

			/// <summary>
			/// <para>幂—成本df = 阻抗dfλ设施点和请求点之间变换的行驶时间或距离等于以最短路径的时间或距离为底，以阻抗参数 (λ) 所指定的数为指数的幂运算结果。 将幂函数选项与正阻抗参数结合使用可对附近的设施点指定较高的权重。</para>
			/// </summary>
			[GPValue("Power")]
			[Description("幂")]
			Power,

			/// <summary>
			/// <para>指数—成本df = e（λ * 阻抗df）设施点和请求点之间变换的行驶时间或距离等于以数学常量 e 为底，以最短路径网络阻抗所指定的数为指数的幂乘以阻抗参数 (λ)。 将指数选项与正阻抗参数结合使用可对附近的设施点指定高权重。</para>
			/// </summary>
			[GPValue("Exponential")]
			[Description("指数")]
			Exponential,

		}

		/// <summary>
		/// <para>Travel Direction</para>
		/// </summary>
		public enum TravelDirectionEnum 
		{
			/// <summary>
			/// <para>请求点到设施点—行驶方向是从请求点指向设施点。</para>
			/// </summary>
			[GPValue("Demand to Facility")]
			[Description("请求点到设施点")]
			Demand_to_Facility,

			/// <summary>
			/// <para>设施点到请求点—行驶方向是从设施点指向请求点。 这是默认设置。</para>
			/// </summary>
			[GPValue("Facility to Demand")]
			[Description("设施点到请求点")]
			Facility_to_Demand,

		}

		/// <summary>
		/// <para>Time Zone for Time of Day</para>
		/// </summary>
		public enum TimeZoneForTimeOfDayEnum 
		{
			/// <summary>
			/// <para>本地地理位置—时间参数是指设施点或请求点所处的时区。 如果行驶方向是从设施点到请求点，此为设施点所处的时区。 如果行驶方向是从请求点到设施点，此为请求点所处的时区。</para>
			/// </summary>
			[GPValue("Geographically Local")]
			[Description("本地地理位置")]
			Geographically_Local,

			/// <summary>
			/// <para>UTC—时间参数是指协调世界时间 (UTC)。 如果您想要在指定时间内（如现在）找到最佳位置，但不确定设施点或请求点所在的时区，请选择此选项。</para>
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
		/// <para>Allocation Line Shape</para>
		/// </summary>
		public enum AllocationLineShapeEnum 
		{
			/// <summary>
			/// <para>None—返回表，其中含有有关所求解的设施点与为其分配的请求点之间最短路径的数据，而不返回线。</para>
			/// </summary>
			[GPValue("None")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>Straight Line—返回所求解的设施点与为其分配的请求点之间的直线。 这是默认设置。 在地图上绘制直线有助于直观地查看请求是如何分配的。</para>
			/// </summary>
			[GPValue("Straight Line")]
			[Description("Straight Line")]
			Straight_Line,

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
