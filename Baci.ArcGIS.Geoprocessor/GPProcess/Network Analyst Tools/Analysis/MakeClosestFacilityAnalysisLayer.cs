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
	/// <para>Make Closest Facility Analysis Layer</para>
	/// <para>创建最近设施点分析图层</para>
	/// <para>创建最近设施点网络分析图层并设置其分析属性。最近设施点分析图层对于根据指定的出行模式确定与事件点距离最近的设施点十分有用。该图层可通过本地网络数据集进行创建，也可通过在线托管服务或门户托管服务进行创建。</para>
	/// </summary>
	public class MakeClosestFacilityAnalysisLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="NetworkDataSource">
		/// <para>Network Data Source</para>
		/// <para>将对其执行网络分析的网络数据集或服务。将门户 URL 用于服务。</para>
		/// </param>
		public MakeClosestFacilityAnalysisLayer(object NetworkDataSource)
		{
			this.NetworkDataSource = NetworkDataSource;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建最近设施点分析图层</para>
		/// </summary>
		public override string DisplayName() => "创建最近设施点分析图层";

		/// <summary>
		/// <para>Tool Name : MakeClosestFacilityAnalysisLayer</para>
		/// </summary>
		public override string ToolName() => "MakeClosestFacilityAnalysisLayer";

		/// <summary>
		/// <para>Tool Excute Name : na.MakeClosestFacilityAnalysisLayer</para>
		/// </summary>
		public override string ExcuteName() => "na.MakeClosestFacilityAnalysisLayer";

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
		public override object[] Parameters() => new object[] { NetworkDataSource, LayerName, TravelMode, TravelDirection, Cutoff, NumberOfFacilitiesToFind, TimeOfDay, TimeZone, TimeOfDayUsage, LineShape, AccumulateAttributes, GenerateDirectionsOnSolve, OutNetworkAnalysisLayer };

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
		/// <para>Travel Direction</para>
		/// <para>指定设施点与事件点之间的行驶方向。</para>
		/// <para>朝向设施点—行驶方向 - 从事件点到设施点。零售店通常使用该设置，因为他们需要关注购物者（事件点）到达商店（设施点）所需的时间。这是默认设置。</para>
		/// <para>远离设施点—行驶方向 - 从设施点到事件点。消防部门通常使用该设置，因为他们需要关注从消防站（设施点）行驶到紧急救援位置（事件点）所需的时间。</para>
		/// <para>如果网络包含基于出行方向的单行道或抗阻，则出行方向可能会影响找到的设施点。例如，从特定事件点到特定设施点驾车可能需要 10 分钟，但是从另一个方向，即设施点到时间点可能需要 15 分钟，因为存在单行线或交通状况不同。</para>
		/// <para><see cref="TravelDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TravelDirection { get; set; } = "TO_FACILITIES";

		/// <summary>
		/// <para>Cutoff</para>
		/// <para>抗阻值到达该值后将停止搜索指定事件点的设施点（以您所选出行模式使用的抗阻属性为单位）。行驶方向为朝向设施点时，在事件点子图层中指定单个中断值可按事件点覆盖中断，行驶方向为远离设施点时，在事件点子图层中指定单个中断值可按设施点覆盖中断。默认情况下分析不使用中断。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Cutoff { get; set; }

		/// <summary>
		/// <para>Number of Facilities to Find</para>
		/// <para>要按事件点查找的最近设施点数。可通过在事件点子图层中指定 TargetFacilityCount 属性的各个值来覆盖此默认值。要查找的设施点默认数量为一。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumberOfFacilitiesToFind { get; set; } = "1";

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>指定路径应该开始或结束的时间和日期。对该值的解释取决于是将时间用法设置为路径的起始时间还是终止时间。</para>
		/// <para>如果您已经选择了基于流量的阻抗属性，将会根据特定的某天某时的动态交通状况来生成解决方案。日期和时间可被指定为 5/14/2012 10:30 AM。</para>
		/// <para>可使用以下日期来指定一周中的每一天，而无需使用特定的日期：</para>
		/// <para>今天 - 12/30/1899</para>
		/// <para>星期日 - 12/31/1899</para>
		/// <para>星期一 - 1/1/1900</para>
		/// <para>星期二 - 1/2/1900</para>
		/// <para>星期三 - 1/3/1900</para>
		/// <para>星期四 - 1/4/1900</para>
		/// <para>星期五 - 1/5/1900</para>
		/// <para>星期六 - 1/6/1900</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Time of Day")]
		public object TimeOfDay { get; set; }

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>时间参数的时区。</para>
		/// <para>各位置的本地时间—时间参数采用设施点或事件点所处的时区。这是默认设置。</para>
		/// <para>如果将时间用法设置为起始时间，行驶方向设置为远离设施点，则为设施点所在时区。</para>
		/// <para>如果将时间用法设置为起始时间，行驶方向设置为朝向设施点，则为事件点所在时区。</para>
		/// <para>如果将时间用法设置为结束时间，行驶方向设置为远离设施点，则为事件点所在时区。</para>
		/// <para>如果将时间用法设置为结束时间，行驶方向设置为朝向设施点，则为设施点所在时区。</para>
		/// <para>UTC—时间参数是指协调世界时间 (UTC)。如果您想要查找可在指定时间内（如现在）到达的最近地点，但不确定设施点或事件点所在的时区，请选择此选项。</para>
		/// <para><see cref="TimeZoneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Time of Day")]
		public object TimeZone { get; set; } = "LOCAL_TIME_AT_LOCATIONS";

		/// <summary>
		/// <para>Time of Day Usage</para>
		/// <para>指示时间参数值是表示路径的到达时间还是离开时间。</para>
		/// <para>开始时间—时间参数可理解为从设施点或事件点出发的时间。这是默认设置。当选择此设置时，时间参数表示求解程序应该基于给定离开时间找到最佳路径。</para>
		/// <para>结束时间—时间参数可理解为到达设施点或事件点的时间。如果您想知道何时从一个地点离开，从而能在时间所指定的时间到达目的地，该选项将十分有用。</para>
		/// <para><see cref="TimeOfDayUsageEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Time of Day")]
		public object TimeOfDayUsage { get; set; } = "START_TIME";

		/// <summary>
		/// <para>Line Shape</para>
		/// <para>为分析所输出的路径要素指定形状类型。</para>
		/// <para>无论选择何种输出形状类型，最佳路径始终由网络阻抗（而非欧氏距离）决定。这表示只是路径形状不同，而对网络进行的基础遍历则相同。</para>
		/// <para>沿网络—输出路径将具有基础网络源的精确形状。输出包括线性参考的路径测量值。测量值从第一个停靠点增加并将记录到达指定位置的累积阻抗。</para>
		/// <para>无线—将不会为输出路径生成任何形状。</para>
		/// <para>直线—输出路径形状为两个停靠点之间的一条直线。</para>
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
		/// <para>选中 - 表示求解时将生成转弯方向。</para>
		/// <para>未选中 - 表示求解时不会生成转弯方向。这是默认设置。</para>
		/// <para>对于不需要生成转弯方向的分析，保持此选项处于未选中状态可显著减少求解分析所需的时间。</para>
		/// <para><see cref="GenerateDirectionsOnSolveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Directions")]
		public object GenerateDirectionsOnSolve { get; set; } = "false";

		/// <summary>
		/// <para>Network Analyst Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object OutNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeClosestFacilityAnalysisLayer SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Travel Direction</para>
		/// </summary>
		public enum TravelDirectionEnum 
		{
			/// <summary>
			/// <para>朝向设施点—行驶方向 - 从事件点到设施点。零售店通常使用该设置，因为他们需要关注购物者（事件点）到达商店（设施点）所需的时间。这是默认设置。</para>
			/// </summary>
			[GPValue("TO_FACILITIES")]
			[Description("朝向设施点")]
			Toward_facilities,

			/// <summary>
			/// <para>远离设施点—行驶方向 - 从设施点到事件点。消防部门通常使用该设置，因为他们需要关注从消防站（设施点）行驶到紧急救援位置（事件点）所需的时间。</para>
			/// </summary>
			[GPValue("FROM_FACILITIES")]
			[Description("远离设施点")]
			Away_from_facilities,

		}

		/// <summary>
		/// <para>Time Zone</para>
		/// </summary>
		public enum TimeZoneEnum 
		{
			/// <summary>
			/// <para>UTC—时间参数是指协调世界时间 (UTC)。如果您想要查找可在指定时间内（如现在）到达的最近地点，但不确定设施点或事件点所在的时区，请选择此选项。</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

			/// <summary>
			/// <para>各位置的本地时间—时间参数采用设施点或事件点所处的时区。这是默认设置。</para>
			/// </summary>
			[GPValue("LOCAL_TIME_AT_LOCATIONS")]
			[Description("各位置的本地时间")]
			Local_time_at_locations,

		}

		/// <summary>
		/// <para>Time of Day Usage</para>
		/// </summary>
		public enum TimeOfDayUsageEnum 
		{
			/// <summary>
			/// <para>开始时间—时间参数可理解为从设施点或事件点出发的时间。这是默认设置。当选择此设置时，时间参数表示求解程序应该基于给定离开时间找到最佳路径。</para>
			/// </summary>
			[GPValue("START_TIME")]
			[Description("开始时间")]
			Start_time,

			/// <summary>
			/// <para>结束时间—时间参数可理解为到达设施点或事件点的时间。如果您想知道何时从一个地点离开，从而能在时间所指定的时间到达目的地，该选项将十分有用。</para>
			/// </summary>
			[GPValue("END_TIME")]
			[Description("结束时间")]
			End_time,

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

#endregion
	}
}
