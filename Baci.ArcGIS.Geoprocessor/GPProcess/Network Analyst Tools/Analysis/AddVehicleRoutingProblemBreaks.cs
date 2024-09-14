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
	/// <para>Add Vehicle Routing Problem Breaks</para>
	/// <para>添加车辆配送休息点</para>
	/// <para>在车辆配送 (VRP) 图层中创建休息点。</para>
	/// </summary>
	public class AddVehicleRoutingProblemBreaks : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InVrpLayer">
		/// <para>Input Vehicle Routing Problem Layer</para>
		/// <para>将向其添加休息点的车辆配送分析图层。</para>
		/// </param>
		public AddVehicleRoutingProblemBreaks(object InVrpLayer)
		{
			this.InVrpLayer = InVrpLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加车辆配送休息点</para>
		/// </summary>
		public override string DisplayName() => "添加车辆配送休息点";

		/// <summary>
		/// <para>Tool Name : AddVehicleRoutingProblemBreaks</para>
		/// </summary>
		public override string ToolName() => "AddVehicleRoutingProblemBreaks";

		/// <summary>
		/// <para>Tool Excute Name : na.AddVehicleRoutingProblemBreaks</para>
		/// </summary>
		public override string ExcuteName() => "na.AddVehicleRoutingProblemBreaks";

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
		public override object[] Parameters() => new object[] { InVrpLayer, TargetRoute!, BreakType!, TimeWindowProperties!, TravelTimeProperties!, WorkTimeProperties!, AppendToExistingBreaks!, OutVrpLayer! };

		/// <summary>
		/// <para>Input Vehicle Routing Problem Layer</para>
		/// <para>将向其添加休息点的车辆配送分析图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InVrpLayer { get; set; }

		/// <summary>
		/// <para>Target Route Name</para>
		/// <para>休息点参数的路径。 如果未指定此参数，则会为每个现有路径创建休息点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? TargetRoute { get; set; }

		/// <summary>
		/// <para>Break Type</para>
		/// <para>指定当前 VRP 图层的休息点类型。 所有休息点的类型必须相同。</para>
		/// <para>时间窗休息点—休息将在特定时间窗内进行。 这是默认设置。</para>
		/// <para>最长行驶时间中断—在经过一定的行驶时间后休息。 这些值为到达第一个休息点之前或两个休息点之间的时间量。</para>
		/// <para>最长工作时间中断—累积一定时间后休息。 这些值始终是自路径起点开始经历的时间。</para>
		/// <para><see cref="BreakTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? BreakType { get; set; } = "TIME_WINDOW_BREAK";

		/// <summary>
		/// <para>Break Properties</para>
		/// <para>指定中断开始的时间范围。 要设置时间窗休息点，请使用两个时间值。</para>
		/// <para>当休息点类型参数设置为时间窗休息点时，启用以下选项。</para>
		/// <para>已支付 - 用来指示是否为休息点支付报酬的布尔值。</para>
		/// <para>休息点持续时间 - 休息点的持续时间。 该字段不能包含空值，其默认值为 60。</para>
		/// <para>时间窗开始 - 时间窗的开始时间。</para>
		/// <para>时间窗结束 - 时间窗的结束时间。</para>
		/// <para>最长冲突时间：该字段为时间窗休息点指定允许的最长冲突时间。 如果到达时间不在该时间范围内，则认为与时间窗发生冲突。 零值表示不能与时间窗发生冲突；即时间窗是硬性的。 非零值表示最长延迟时间。 例如，中断可在其时间窗结束后最多 30 分钟内开始，但会按照时间窗冲突重要性设置对延迟进行惩罚（该设置可评定遵循时间窗且不引起冲突的重要性）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? TimeWindowProperties { get; set; }

		/// <summary>
		/// <para>Break Properties</para>
		/// <para>指定可在驾驶多长时间之后才需要休息。</para>
		/// <para>当休息点类型参数设置为最长行驶时间中断时，启用以下属性。</para>
		/// <para>已支付 - 用来指示是否为休息点支付报酬的布尔值。</para>
		/// <para>休息点持续时间 - 休息点的持续时间。 该字段不能包含空值，其默认值为 60。</para>
		/// <para>最长行驶时间 - 休息之前可累积的最长行驶时间。 行驶时间从上一个休息点的结束时间开始累积，或者从路径的起始点开始累积（如果还未休息过）。如果这是路径的最后一个休息点，则 MaxTravelTimeBetweenBreaks 字段还表示从最后一个休息点到终止站点可累积的最长行驶时间。</para>
		/// <para>该字段将限制可在驾驶多长时间之后才需要休息。 例如，如果分析的时间字段单位参数（Python 中的 time_units）设为分钟，而且 MaxTravelTimeBetweenBreaks 字段的值为 120，则司机将在驾驶两个小时之后休息。 如果要再行驶两个小时后再次休息，则第二个休息点的 MaxTravelTimeBetweenBreaks 字段必须为 120。</para>
		/// <para>该字段值的单位由时间字段单位参数指定（Python 中的 time_units）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? TravelTimeProperties { get; set; }

		/// <summary>
		/// <para>Break Properties</para>
		/// <para>指定可在工作多长时间之后才需要休息。</para>
		/// <para>当休息点类型参数设置为最长工作时间休息点时,启用以下属性。</para>
		/// <para>已支付 - 用来指示是否为休息点支付报酬的布尔值。</para>
		/// <para>休息点持续时间 - 休息点的持续时间。 该字段不能包含空值，其默认值为 60。</para>
		/// <para>累积的最长工作时间 - 休息之前可累积的最长工作时间。 工作时间始终从路径的起始点开始累积。 工作时间等于行驶时间加上在停靠点、站点和休息点的服务时间。 不过，此时间不包括等待时间，等待时间是指路径（或驾驶员）在停靠点或站点处等待时间窗打开所用的时间。MaxCumulWorkTime 字段也表示休息之前可累积的最长工作时间。</para>
		/// <para>该字段将限制可在工作多长时间之后才需要中断。 例如，如果时间字段单位参数（Python 中的 time_units）设为分钟，而且 MaxCumulWorkTime 字段的值为 120，ServiceTime 字段的值为 15，则司机将在工作 2 个小时之后获得 15 分钟的休息时间。</para>
		/// <para>继续此示例来进行说明，假设工作了 3 个小时之后又需要休息。 那么，要指定该休息点，需要输入 315（5 小时 15 分钟）作为第二个休息点的 MaxCumulWorkTime 字段值。 这个数字包括前一个休息点的 MaxCumulWorkTime 和 ServiceTime 字段值，以及准许进行第二次休息之前的另外三个小时工作时间。 为避免过早经过最长工作时间休息点，应该记住：工作时间是从路径的起始点开始累积的，并且包括在之前访问的站点、停靠点和休息点处的服务时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? WorkTimeProperties { get; set; }

		/// <summary>
		/// <para>Append To Existing Breaks</para>
		/// <para>指定是否将新的休息点追加到现有的休息点属性表中。</para>
		/// <para>选中 - 新的休息点将追加到休息点属性表的现有集合中。 这是默认设置。</para>
		/// <para>未选中 - 现有休息点将被替换为新的休息点。</para>
		/// <para><see cref="AppendToExistingBreaksEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AppendToExistingBreaks { get; set; } = "true";

		/// <summary>
		/// <para>Output Vehicle Routing Problem Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object? OutVrpLayer { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Break Type</para>
		/// </summary>
		public enum BreakTypeEnum 
		{
			/// <summary>
			/// <para>时间窗休息点—休息将在特定时间窗内进行。 这是默认设置。</para>
			/// </summary>
			[GPValue("TIME_WINDOW_BREAK")]
			[Description("时间窗休息点")]
			Time_Window_Break,

			/// <summary>
			/// <para>最长行驶时间中断—在经过一定的行驶时间后休息。 这些值为到达第一个休息点之前或两个休息点之间的时间量。</para>
			/// </summary>
			[GPValue("MAXIMUM_TRAVEL_TIME_BREAK")]
			[Description("最长行驶时间中断")]
			Maximum_Travel_Time_Break,

			/// <summary>
			/// <para>最长工作时间中断—累积一定时间后休息。 这些值始终是自路径起点开始经历的时间。</para>
			/// </summary>
			[GPValue("MAXIMUM_WORK_TIME_BREAK")]
			[Description("最长工作时间中断")]
			Maximum_Work_Time_Break,

		}

		/// <summary>
		/// <para>Append To Existing Breaks</para>
		/// </summary>
		public enum AppendToExistingBreaksEnum 
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
