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
	/// <para>Add Vehicle Routing Problem Routes</para>
	/// <para>添加车辆配送路径</para>
	/// <para>在 Vehicle Routing Problem (VRP) 图层中创建路径。 该工具会将行追加到 Routes 子图层，并可以在创建唯一名称字段时添加具有特定设置的行。</para>
	/// </summary>
	public class AddVehicleRoutingProblemRoutes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InVrpLayer">
		/// <para>Input Vehicle Routing Problem Layer</para>
		/// <para>将添加路径的车辆配送分析图层。</para>
		/// </param>
		/// <param name="NumberOfRoutes">
		/// <para>Number of Routes</para>
		/// <para>要添加的路径数。</para>
		/// </param>
		/// <param name="RouteNamePrefix">
		/// <para>Route Name Prefix</para>
		/// <para>添加至每个路径图层项目标题的限定符。 例如，路径名称前缀 WeekdayRoute 将用作每个路径名称的起始文本，并附加对象 ID。</para>
		/// </param>
		public AddVehicleRoutingProblemRoutes(object InVrpLayer, object NumberOfRoutes, object RouteNamePrefix)
		{
			this.InVrpLayer = InVrpLayer;
			this.NumberOfRoutes = NumberOfRoutes;
			this.RouteNamePrefix = RouteNamePrefix;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加车辆配送路径</para>
		/// </summary>
		public override string DisplayName() => "添加车辆配送路径";

		/// <summary>
		/// <para>Tool Name : AddVehicleRoutingProblemRoutes</para>
		/// </summary>
		public override string ToolName() => "AddVehicleRoutingProblemRoutes";

		/// <summary>
		/// <para>Tool Excute Name : na.AddVehicleRoutingProblemRoutes</para>
		/// </summary>
		public override string ExcuteName() => "na.AddVehicleRoutingProblemRoutes";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InVrpLayer, NumberOfRoutes, RouteNamePrefix, StartDepotName!, EndDepotName!, EarliestStartTime!, LatestStartTime!, MaxOrderCount!, Capacities!, RouteConstraints!, Costs!, AdditionalRouteTime!, AppendToExistingRoutes!, OutVrpLayer! };

		/// <summary>
		/// <para>Input Vehicle Routing Problem Layer</para>
		/// <para>将添加路径的车辆配送分析图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNALayer()]
		public object InVrpLayer { get; set; }

		/// <summary>
		/// <para>Number of Routes</para>
		/// <para>要添加的路径数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumberOfRoutes { get; set; }

		/// <summary>
		/// <para>Route Name Prefix</para>
		/// <para>添加至每个路径图层项目标题的限定符。 例如，路径名称前缀 WeekdayRoute 将用作每个路径名称的起始文本，并附加对象 ID。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object RouteNamePrefix { get; set; } = "Route";

		/// <summary>
		/// <para>Start Depot Name</para>
		/// <para>路径的起始站点名称。 如果起始站点名称值为空，则路径会将分配的第一个停靠点作为起始点。 车辆的起始位置未知或者与您的问题不相关时，可以忽略起始站点。 但是，当起始站点名称值为空时，则终止站点名称值不能同时为空。 如果停靠点或站点跨多个时区，则不允许使用虚拟起始站点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? StartDepotName { get; set; }

		/// <summary>
		/// <para>End Depot Name</para>
		/// <para>路径的终止站点名称。 如果终止站点名称值为空，则路径将在分配的最后一个停靠点处结束。 当终止站点名称值为空时，则起始站点名称值不能同时为空。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? EndDepotName { get; set; }

		/// <summary>
		/// <para>Earliest Start Time</para>
		/// <para>路径允许的最早开始时间。</para>
		/// <para>求解程序通过将该参数与起始站点的时间窗（在 Depots 图层中由 TimeWindowStart 字段提供）结合使用来确定可行的路径开始时间。 该参数的默认仅时间值是 8:00:00 a.m.，解释为分析图层 Default Date 属性给定的日期的上午 8:00:00。 如果未指定任何值，则将使用默认值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? EarliestStartTime { get; set; } = "8:00:00 AM";

		/// <summary>
		/// <para>Latest Start Time</para>
		/// <para>路径允许的最晚开始时间。 该参数的默认仅时间值是 10:00:00 a.m.，解释为分析图层 Default Date 属性提供的日期的上午 10:00:00。 如果未指定任何值，则将使用默认值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? LatestStartTime { get; set; } = "10:00:00 AM";

		/// <summary>
		/// <para>Max Order Count</para>
		/// <para>路径上允许的最大停靠点数。 默认值为 30。 如果未指定任何值，则将使用默认值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MaxOrderCount { get; set; } = "30";

		/// <summary>
		/// <para>Capacities</para>
		/// <para>车辆的最大装载量（体积、重量、数量等）。 空值等于零。 最多允许 9 个容量字段，但仅使用对车辆需求进行建模所需的数量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? Capacities { get; set; }

		/// <summary>
		/// <para>Route Constraints</para>
		/// <para>对路径施加的限制，用于限制总时间、总行驶时间和总距离。</para>
		/// <para>最长总时间 - 允许的最大路径持续时间。 路径持续时间包括行驶时间以及在停靠点、站点和休息点的服务和等待时间。</para>
		/// <para>最大总行驶时间 - 路径允许的最大行驶时间。 行驶时间只包括在网络上行驶时所用的时间，不包括服务或等待时间。 该字段值不能大于 MaxTotalTime 字段值。</para>
		/// <para>最大总距离 - 路径允许的最大行驶距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? RouteConstraints { get; set; }

		/// <summary>
		/// <para>Costs</para>
		/// <para>VRP 解决方案中路径产生的成本。</para>
		/// <para>固定成本 - 仅当解决方案中使用路径（即，路径分配有停靠点）时才产生的固定货币成本。</para>
		/// <para>单位时间成本 - 路径总持续时间（包括行驶时间以及在停靠点、站点和休息点的服务时间和等待时间）中每单位工作时间产生的货币成本。</para>
		/// <para>单位距离成本 - 在路径长度（总行驶距离）上行驶单位距离产生的货币成本。</para>
		/// <para>加班时间开始时间 - 开始计算加班时间之前的规定工作时间。</para>
		/// <para>单位加班时间成本 - 每单位加班工作时间产生的货币成本。 该字段可以包含空值；空值表示单位加班时间成本值与单位时间成本值相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? Costs { get; set; }

		/// <summary>
		/// <para>Additional Route Time</para>
		/// <para>附件路径时间选项。</para>
		/// <para>起始站点服务时间 - 起始站点的服务时间。 该字段可用于为车辆装货所用的时间建立模型。</para>
		/// <para>结束站点服务时间 - 结束站点的服务时间。 该字段可用于为车辆卸货所用的时间建立模型。</para>
		/// <para>到达/离开延迟 - 将车辆加速到正常行驶速度、减速到停止状态以及离开和进入网络（例如，出入停车场）所需的行驶时间。 通过包含到达/离开延迟值，可防止 VRP 求解程序发送多条路径来为完全重合的停靠点提供服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? AdditionalRouteTime { get; set; }

		/// <summary>
		/// <para>Append To Existing Routes</para>
		/// <para>指定是否将新的路径追加到现有路径属性表中。</para>
		/// <para>选中 - 新的路径将追加到路径属性表的现有集合中。 这是默认设置。</para>
		/// <para>未选中 - 现有路径将被删除并替换为新路径。</para>
		/// <para><see cref="AppendToExistingRoutesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AppendToExistingRoutes { get; set; } = "true";

		/// <summary>
		/// <para>Output Vehicle Routing Problem Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object? OutVrpLayer { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Append To Existing Routes</para>
		/// </summary>
		public enum AppendToExistingRoutesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("APPEND")]
			APPEND,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("CLEAR")]
			CLEAR,

		}

#endregion
	}
}
