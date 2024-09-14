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
	/// <para>Make Route Analysis Layer</para>
	/// <para>创建路径分析图层</para>
	/// <para>创建路径网络分析图层并设置其分析属性。路径分析图层可用于根据指定的网络成本确定一组网络位置之间的最佳路径。该图层可通过本地网络数据集进行创建，也可通过在线托管路径服务或门户托管路径服务进行创建。</para>
	/// </summary>
	public class MakeRouteAnalysisLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="NetworkDataSource">
		/// <para>Network Data Source</para>
		/// <para>将对其执行网络分析的网络数据集或服务。将门户 URL 用于服务。</para>
		/// </param>
		public MakeRouteAnalysisLayer(object NetworkDataSource)
		{
			this.NetworkDataSource = NetworkDataSource;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建路径分析图层</para>
		/// </summary>
		public override string DisplayName() => "创建路径分析图层";

		/// <summary>
		/// <para>Tool Name : MakeRouteAnalysisLayer</para>
		/// </summary>
		public override string ToolName() => "MakeRouteAnalysisLayer";

		/// <summary>
		/// <para>Tool Excute Name : na.MakeRouteAnalysisLayer</para>
		/// </summary>
		public override string ExcuteName() => "na.MakeRouteAnalysisLayer";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { NetworkDataSource, LayerName, TravelMode, Sequence, TimeOfDay, TimeZone, LineShape, AccumulateAttributes, GenerateDirectionsOnSolve, OutNetworkAnalysisLayer, TimeZoneForTimeFields };

		/// <summary>
		/// <para>Network Data Source</para>
		/// <para>将对其执行网络分析的网络数据集或服务。将门户 URL 用于服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object NetworkDataSource { get; set; }

		/// <summary>
		/// <para>Layer Name</para>
		/// <para>要创建的网络分析图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object LayerName { get; set; }

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>分析中使用的出行模式名称。出行模式为一组网络设置（例如行驶限制和 U 形转弯），用于确定行人、车辆、卡车或其他交通媒介在网络中的移动方式。出行模式在网络数据源中进行定义。</para>
		/// <para>arcpy.na.TravelMode 对象和包含出行模式有效 JSON 表示的字符串也可用作参数的输入。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TravelMode { get; set; }

		/// <summary>
		/// <para>Sequence</para>
		/// <para>指定在计算最佳路径时是否必须以特定顺序访问输入停靠点。此选项将路径分析由最短路径问题变为流动推销员问题 (TSP)。</para>
		/// <para>使用当前顺序—将按照输入顺序访问停靠点。这是默认设置。</para>
		/// <para>查找最佳顺序—将重新排序停靠点以查找最佳路径。此选项将路径分析由最短路径问题变为流动推销员问题 (TSP)。</para>
		/// <para>保留第一个和最后一个停靠点—按输入顺序保留第一个停靠点和最后一个停靠点。将重新排序其余的停靠点以查找最佳路径。</para>
		/// <para>保留第一个停靠点—按输入顺序保留第一个停靠点。将重新排序其余的停靠点以查找最佳路径。</para>
		/// <para>保留最后一个停靠点—按输入顺序保留最后一个停靠点。将重新排序其余的停靠点以查找最佳路径。</para>
		/// <para><see cref="SequenceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Sequence { get; set; } = "USE_CURRENT_ORDER";

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>路径的开始日期和时间。路径开始时间通常用于查找阻抗属性随当日时间变化的路径。例如，开始时间 7:00 a.m. 可用于查找被认为是高峰时段流量的路径。此参数的默认值为 8:00 a.m.。可将日期和时间指定为 10/21/05 10:30 AM。如果路径跨越多天，则仅指定开始时间，并使用当前日期。</para>
		/// <para>可使用以下日期来指定一周中的每一天，而无需使用特定的日期：</para>
		/// <para>今天 - 12/30/1899</para>
		/// <para>星期日 - 12/31/1899</para>
		/// <para>星期一 - 1/1/1900</para>
		/// <para>星期二 - 1/2/1900</para>
		/// <para>星期三 - 1/3/1900</para>
		/// <para>星期四 - 1/4/1900</para>
		/// <para>星期五 - 1/5/1900</para>
		/// <para>星期六 - 1/6/1900</para>
		/// <para>例如，要指定行程从星期二 5:00 p.m. 开始，则请将该参数值指定为 1/2/1900 5:00 PM。</para>
		/// <para>求解结束后，在输出路径中填充路径的开始时间与结束时间。也会在生成方向时使用这些开始时间和结束时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Time of Day")]
		public object TimeOfDay { get; set; }

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>指定时间参数的时区。</para>
		/// <para>各位置的本地时间—时间参数采用路径的第一个停靠点处的时区。这是默认设置。如果生成开始于多个时区的多个路径，则开始时间会采用协调世界时间 (UTC) 交错。例如，时间值为 10:00 a.m., 2 January 表示始于东部时区的路径的开始时间为东部标准时间 10:00 a.m. （UTC 为 3:00 p.m.），始于中部时区的路径的开始时间为中部标准时间 10:00 a.m. （UTC 为 4:00 p.m.）。开始时间偏差一小时（UTC 时间）。输出停靠点要素类中记录的到达与离开的时间和日期将采用每个路径第一个停靠点的本地时区。</para>
		/// <para>UTC—时间参数是指协调世界时间 (UTC)。如果您想要在特定的时间（如现在）生成路径，但不确定第一个停靠点所在的时区，请选择此选项。如果您生成跨越多个时区的多个路径，以 UTC 表示的开始时间将发生同步。例如，时间值为 10:00 a.m., 2 January 表示始于东部时区的路径的开始时间为东部标准时间 5:00 a.m. （UTC 为 10:00 a.m.），始于中部时区的路径的开始时间为中部标准时间 4:00 a.m. （UTC 为 10:00 p.m.）。这两个路径均于 10:00 a.m. UTC 开始。输出停靠点要素类中记录的到达与离开的时间和日期将采用 UTC 时间。</para>
		/// <para><see cref="TimeZoneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Time of Day")]
		public object TimeZone { get; set; } = "LOCAL_TIME_AT_LOCATIONS";

		/// <summary>
		/// <para>Line Shape</para>
		/// <para>为分析所输出的路径要素指定形状类型。</para>
		/// <para>沿网络—输出路径将具有基础网络源的精确形状。输出包括线性参考的路径测量值。测量值从第一个停靠点增加并将记录到达指定位置的累积阻抗。</para>
		/// <para>无线—将不会为输出路径生成任何形状。</para>
		/// <para>直线—输出路径形状为两个停靠点之间的一条直线。</para>
		/// <para>无论选择何种输出形状类型，最佳路径始终由网络阻抗（而非欧氏距离）决定。这表示只是路径形状不同，而对网络进行的基础遍历则相同。</para>
		/// <para><see cref="LineShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Geometry")]
		public object LineShape { get; set; } = "ALONG_NETWORK";

		/// <summary>
		/// <para>Accumulate Attributes</para>
		/// <para>分析过程中要累积的成本属性的列表。这些累积属性仅供参考；求解程序仅使用求解分析时指定的出行模式所使用的成本属性。</para>
		/// <para>对于每个累积的成本属性，会在网络分析输出要素中填充 Total_[Impedance] 属性。</para>
		/// <para>如果网络数据源为 ArcGIS Online 服务，或如果网络数据源是不支持累积的 Portal for ArcGIS 版本上的服务，则此参数不可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Accumulate Attributes")]
		public object AccumulateAttributes { get; set; }

		/// <summary>
		/// <para>Generate Directions on Solve</para>
		/// <para>指定运行分析时是否生成方向。</para>
		/// <para>选中 - 求解时会生成转向指示。这是默认设置。</para>
		/// <para>未选中 - 求解时不会生成转向指示。</para>
		/// <para>对于不需要生成转向指示的分析，保持此选项的未选中状态可以减少求解分析的时间。</para>
		/// <para><see cref="GenerateDirectionsOnSolveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Directions")]
		public object GenerateDirectionsOnSolve { get; set; } = "true";

		/// <summary>
		/// <para>Network Analyst Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object OutNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Time Zone for Time Fields</para>
		/// <para>指定将用于解释输入表中包括的时间字段（例如用于时间窗口的字段）的时区。</para>
		/// <para>各位置的本地时间—停靠点时间字段中的日期和时间将根据停靠点所在的时区进行解释。这是默认设置。</para>
		/// <para>UTC—停靠点时间字段中的日期和时间采用协调世界时间 (UTC)。</para>
		/// <para><see cref="TimeZoneForTimeFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Time of Day")]
		public object TimeZoneForTimeFields { get; set; } = "LOCAL_TIME_AT_LOCATIONS";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeRouteAnalysisLayer SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Sequence</para>
		/// </summary>
		public enum SequenceEnum 
		{
			/// <summary>
			/// <para>使用当前顺序—将按照输入顺序访问停靠点。这是默认设置。</para>
			/// </summary>
			[GPValue("USE_CURRENT_ORDER")]
			[Description("使用当前顺序")]
			Use_current_order,

			/// <summary>
			/// <para>查找最佳顺序—将重新排序停靠点以查找最佳路径。此选项将路径分析由最短路径问题变为流动推销员问题 (TSP)。</para>
			/// </summary>
			[GPValue("FIND_BEST_ORDER")]
			[Description("查找最佳顺序")]
			Find_best_order,

			/// <summary>
			/// <para>保留第一个和最后一个停靠点—按输入顺序保留第一个停靠点和最后一个停靠点。将重新排序其余的停靠点以查找最佳路径。</para>
			/// </summary>
			[GPValue("PRESERVE_BOTH")]
			[Description("保留第一个和最后一个停靠点")]
			Preserve_both_first_and_last_stop,

			/// <summary>
			/// <para>保留第一个停靠点—按输入顺序保留第一个停靠点。将重新排序其余的停靠点以查找最佳路径。</para>
			/// </summary>
			[GPValue("PRESERVE_FIRST")]
			[Description("保留第一个停靠点")]
			Preserve_first_stop,

			/// <summary>
			/// <para>保留最后一个停靠点—按输入顺序保留最后一个停靠点。将重新排序其余的停靠点以查找最佳路径。</para>
			/// </summary>
			[GPValue("PRESERVE_LAST")]
			[Description("保留最后一个停靠点")]
			Preserve_last_stop,

		}

		/// <summary>
		/// <para>Time Zone</para>
		/// </summary>
		public enum TimeZoneEnum 
		{
			/// <summary>
			/// <para>UTC—时间参数是指协调世界时间 (UTC)。如果您想要在特定的时间（如现在）生成路径，但不确定第一个停靠点所在的时区，请选择此选项。如果您生成跨越多个时区的多个路径，以 UTC 表示的开始时间将发生同步。例如，时间值为 10:00 a.m., 2 January 表示始于东部时区的路径的开始时间为东部标准时间 5:00 a.m. （UTC 为 10:00 a.m.），始于中部时区的路径的开始时间为中部标准时间 4:00 a.m. （UTC 为 10:00 p.m.）。这两个路径均于 10:00 a.m. UTC 开始。输出停靠点要素类中记录的到达与离开的时间和日期将采用 UTC 时间。</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

			/// <summary>
			/// <para>各位置的本地时间—时间参数采用路径的第一个停靠点处的时区。这是默认设置。如果生成开始于多个时区的多个路径，则开始时间会采用协调世界时间 (UTC) 交错。例如，时间值为 10:00 a.m., 2 January 表示始于东部时区的路径的开始时间为东部标准时间 10:00 a.m. （UTC 为 3:00 p.m.），始于中部时区的路径的开始时间为中部标准时间 10:00 a.m. （UTC 为 4:00 p.m.）。开始时间偏差一小时（UTC 时间）。输出停靠点要素类中记录的到达与离开的时间和日期将采用每个路径第一个停靠点的本地时区。</para>
			/// </summary>
			[GPValue("LOCAL_TIME_AT_LOCATIONS")]
			[Description("各位置的本地时间")]
			Local_time_at_locations,

		}

		/// <summary>
		/// <para>Line Shape</para>
		/// </summary>
		public enum LineShapeEnum 
		{
			/// <summary>
			/// <para>无线—将不会为输出路径生成任何形状。</para>
			/// </summary>
			[GPValue("NO_LINES")]
			[Description("无线")]
			No_lines,

			/// <summary>
			/// <para>直线—输出路径形状为两个停靠点之间的一条直线。</para>
			/// </summary>
			[GPValue("STRAIGHT_LINES")]
			[Description("直线")]
			Straight_lines,

			/// <summary>
			/// <para>沿网络—输出路径将具有基础网络源的精确形状。输出包括线性参考的路径测量值。测量值从第一个停靠点增加并将记录到达指定位置的累积阻抗。</para>
			/// </summary>
			[GPValue("ALONG_NETWORK")]
			[Description("沿网络")]
			Along_network,

		}

		/// <summary>
		/// <para>Generate Directions on Solve</para>
		/// </summary>
		public enum GenerateDirectionsOnSolveEnum 
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
		/// <para>Time Zone for Time Fields</para>
		/// </summary>
		public enum TimeZoneForTimeFieldsEnum 
		{
			/// <summary>
			/// <para>UTC—停靠点时间字段中的日期和时间采用协调世界时间 (UTC)。</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

			/// <summary>
			/// <para>各位置的本地时间—停靠点时间字段中的日期和时间将根据停靠点所在的时区进行解释。这是默认设置。</para>
			/// </summary>
			[GPValue("LOCAL_TIME_AT_LOCATIONS")]
			[Description("各位置的本地时间")]
			Local_time_at_locations,

		}

#endregion
	}
}
