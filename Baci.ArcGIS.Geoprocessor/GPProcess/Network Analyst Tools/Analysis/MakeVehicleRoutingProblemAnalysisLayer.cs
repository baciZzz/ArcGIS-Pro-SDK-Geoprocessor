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
	/// <para>Make Vehicle Routing Problem Analysis Layer</para>
	/// <para>创建车辆配送分析图层</para>
	/// <para>创建车辆配送 (VRP) 网络分析图层并设置其分析属性。 VRP 分析图层可用于在使用一支车队时对一组路径进行优化。 该图层可通过本地网络数据集进行创建，也可通过在线托管服务或门户托管服务进行创建。</para>
	/// </summary>
	public class MakeVehicleRoutingProblemAnalysisLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="NetworkDataSource">
		/// <para>Network Data Source</para>
		/// <para>将对其执行网络分析的网络数据集或服务。 将门户 URL 用于服务。</para>
		/// </param>
		public MakeVehicleRoutingProblemAnalysisLayer(object NetworkDataSource)
		{
			this.NetworkDataSource = NetworkDataSource;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建车辆配送分析图层</para>
		/// </summary>
		public override string DisplayName() => "创建车辆配送分析图层";

		/// <summary>
		/// <para>Tool Name : MakeVehicleRoutingProblemAnalysisLayer</para>
		/// </summary>
		public override string ToolName() => "MakeVehicleRoutingProblemAnalysisLayer";

		/// <summary>
		/// <para>Tool Excute Name : na.MakeVehicleRoutingProblemAnalysisLayer</para>
		/// </summary>
		public override string ExcuteName() => "na.MakeVehicleRoutingProblemAnalysisLayer";

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
		public override object[] Parameters() => new object[] { NetworkDataSource, LayerName!, TravelMode!, TimeUnits!, DistanceUnits!, DefaultDate!, TimeZoneForTimeFields!, LineShape!, TimeWindowFactor!, ExcessTransitFactor!, GenerateDirectionsOnSolve!, SpatialClustering!, OutNetworkAnalysisLayer!, IgnoreInvalidLocations! };

		/// <summary>
		/// <para>Network Data Source</para>
		/// <para>将对其执行网络分析的网络数据集或服务。 将门户 URL 用于服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object NetworkDataSource { get; set; }

		/// <summary>
		/// <para>Layer Name</para>
		/// <para>要创建的 VRP 网络分析图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? LayerName { get; set; }

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>分析中使用的出行模式名称。 出行模式为一组网络设置（例如行驶限制和 U 形转弯），用于确定行人、车辆、卡车或其他交通媒介在网络中的移动方式。 出行模式在网络数据源中进行定义。 arcpy.na.TravelMode 对象和包含出行模式有效 JSON 表示的字符串也可用作参数的输入。</para>
		/// <para>VRP 将仅使用基于时间的阻抗进行求解，因此仅基于时间的阻抗出行模式可供选择。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TravelMode { get; set; }

		/// <summary>
		/// <para>Time Field Units</para>
		/// <para>指定分析图层的子图层和表（网络分析类）的时态字段所用的时间单位。 该值不必与时间成本属性的单位相匹配。</para>
		/// <para>分—时间单位将为分钟。 这是默认设置。</para>
		/// <para>秒—时间单位将为秒。</para>
		/// <para>小时—时间单位将为小时。</para>
		/// <para>天—时间单位将为天。</para>
		/// <para><see cref="TimeUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TimeUnits { get; set; } = "Minutes";

		/// <summary>
		/// <para>Distance Field Units</para>
		/// <para>指定分析图层的子图层和表（网络分析类）的距离字段所用的距离单位。 该值不必与可选距离成本属性的单位相匹配。</para>
		/// <para>英里—距离单位将为英里。 这是默认设置。</para>
		/// <para>千米—距离单位将为公里。</para>
		/// <para>英尺—距离单位将为英尺。</para>
		/// <para>码—距离单位将为码。</para>
		/// <para>米—距离单位将为米。</para>
		/// <para>英寸—距离单位将为英寸。</para>
		/// <para>厘米—距离单位将为厘米。</para>
		/// <para>毫米—距离单位将为毫米。</para>
		/// <para>分米—距离单位将为分米。</para>
		/// <para>海里—距离单位将为海里。</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DistanceUnits { get; set; } = "Miles";

		/// <summary>
		/// <para>Default Date</para>
		/// <para>未用时间指定日期的时间字段值的隐式日期。 如果某个停靠点对象的时间字段（如 TimeWindowStart）只有时间值，则假定该日期为默认日期。 默认日期不影响已具有日期的时间字段值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Date and Time")]
		public object? DefaultDate { get; set; }

		/// <summary>
		/// <para>Time Zone for Time Fields</para>
		/// <para>指定工具支持的输入日期时间字段所用的时区。</para>
		/// <para>各位置的本地时间—与停靠点或站点相关的日期时间值位于停靠点和站点所在的时区内。 对于路径，日期时间值基于路径的起始站点所在的时区。 如果路径没有起始站点，则路径上的所有停靠点和站点必须位于一个时区中。 对于中断点，日期时间值基于路径的时区。 这是默认设置。</para>
		/// <para>UTC—与停靠点或站点相关的日期时间值位于协调世界时间 (UTC) 中，且不基于停靠点或站点所在的时区。</para>
		/// <para>如果不知道停靠点或站点所在的时区，或者停靠点或站点处在多个时区内并且您想要所有的日期时间值同时启动，那么在 UTC 中指定日期时间值非常有用。 UTC 选项仅在您的网络数据集定义了时区属性时才可用。 否则，所有日期时间值将始终被视为与该位置相对应的时区。</para>
		/// <para><see cref="TimeZoneForTimeFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Date and Time")]
		public object? TimeZoneForTimeFields { get; set; } = "LOCAL_TIME_AT_LOCATIONS";

		/// <summary>
		/// <para>Output Route Shape</para>
		/// <para>为分析所输出的路径要素指定要使用的形状类型。</para>
		/// <para>沿网络—输出路径将具有基础网络源的精确形状。 输出包括线性参考的路径测量值。 测量值从第一个停靠点增加并将记录到达指定位置的累积阻抗。</para>
		/// <para>无线—将不会为输出路径生成任何形状。</para>
		/// <para>直线—输出路径形状为两个停靠点之间的一条直线。如果所选网络数据源为服务，则此选项不可用。</para>
		/// <para>无论选择何种输出 shape 类型，最佳路径始终由网络阻抗（而非欧氏距离）决定。 这表示只是路径形状不同，而对网络进行的基础遍历则相同。</para>
		/// <para><see cref="LineShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Geometry")]
		public object? LineShape { get; set; } = "ALONG_NETWORK";

		/// <summary>
		/// <para>Time Window Violation Importance</para>
		/// <para>用于指定支持时间窗且不引起冲突的重要性。 如果路径在时间窗关闭后才到达停靠点、站点或休息点，将会产生时间窗冲突。 该冲突是时间窗关闭与路径到达时间之间的时间间隔。</para>
		/// <para>高—求解程序需要寻求最小化时间窗冲突的解决方案（以增加总体行驶时间为代价）。 如果对您而言按时到达停靠点要比最小化总体解决方案成本更加重要，请选择此设置。 您可能会在以下情况下选择此设置：您要在自己的停靠点会见客户，且不想因为迟到给客户带来不便（另一种方法是使用根本不会出现冲突的硬性时间窗）。假设还要考虑车辆配送 (VRP) 的其他约束，可能无法在它们的时间窗内访问所有停靠点。 在这种情况下，即使选择“高”设置也可能会产生冲突。</para>
		/// <para>中—求解程序在满足时间窗和减少总体解决方案成本之间寻求一种平衡。 这是默认设置。</para>
		/// <para>低—求解程序需要寻求最小化总体行驶时间的解决方案（不考虑时间窗）。 如果减少您的总体解决方案成本要比满足时间窗更重要，请选择此设置。 如果积压的服务请求逐渐增多，则可以使用此设置。 如果为了在当日内为更多的停靠点提供服务并减少积压的订单，则可选择此设置，即使车队迟到会为客户带来不便。</para>
		/// <para><see cref="TimeWindowFactorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced")]
		public object? TimeWindowFactor { get; set; } = "Medium";

		/// <summary>
		/// <para>Excess Transit Time Importance</para>
		/// <para>指定减少额外行驶时间的重要性。 额外行驶时间是指超出停靠点对间直线行驶所需时间的数量。 额外时间是由于在需求点对的访问期间进行休息或者行驶至其他停靠点或站点而导致的。 仅当您使用停靠点对时，此参数才相关。</para>
		/// <para>高—求解程序需要寻求需求点对之间超出行驶时间较短的解决方案（以增加总体行驶成本为代价）。 如果您正在停靠点对间运载乘客并且想缩短他们的乘车时间，请使用此设置。 这是出租车服务的特征。</para>
		/// <para>中—求解程序在减少超出行驶时间和减少总体解决方案成本之间寻求一种平衡。 这是默认设置。</para>
		/// <para>低—求解程序需要寻求最小化总体解决方案成本的结果（不考虑额外行驶时间）。 此设置通常应用于快递服务。 由于快递运输的是包裹而不是人员，因此行驶时间并不十分重要。 使用此设置时，快递可以按照最适合的顺序为停靠点对提供服务，并且总体解决方案成本最低。</para>
		/// <para><see cref="ExcessTransitFactorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced")]
		public object? ExcessTransitFactor { get; set; } = "Medium";

		/// <summary>
		/// <para>Generate Directions on Solve</para>
		/// <para>指定是否将生成方向。</para>
		/// <para>选中 - 求解时会生成转向指示。 这是默认设置。</para>
		/// <para>未选中 - 求解时不会生成转向指示。</para>
		/// <para><see cref="GenerateDirectionsOnSolveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Directions")]
		public object? GenerateDirectionsOnSolve { get; set; } = "true";

		/// <summary>
		/// <para>Spatial Clustering</para>
		/// <para>指定是否使用空间聚类。</para>
		/// <para>选中 - 分配给各个路径的停靠点将在空间上聚类。 对停靠点进行聚类往往在较小区域保持路径，并减小路径线彼此相交的频率；然而，聚类可能会增加总行程时间。 这是默认设置。</para>
		/// <para>未选中 - 求解器不会对空间聚类停靠点进行优先排序，并且路线可能会相交。 如果指定了路径区，使用此选项。</para>
		/// <para><see cref="SpatialClusteringEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced")]
		public object? SpatialClustering { get; set; } = "true";

		/// <summary>
		/// <para>Network Analyst Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object? OutNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Ignore Invalid Locations at Solve Time</para>
		/// <para>指定是否忽略无效的输入位置。</para>
		/// <para>选中 - 表示将忽略无效的输入位置，仅使用有效位置即可成功进行分析。</para>
		/// <para>取消选中 - 表示不会忽略无效位置，从而导致分析失败。 这是默认设置。</para>
		/// <para><see cref="IgnoreInvalidLocationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Locations")]
		public object? IgnoreInvalidLocations { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeVehicleRoutingProblemAnalysisLayer SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Time Field Units</para>
		/// </summary>
		public enum TimeUnitsEnum 
		{
			/// <summary>
			/// <para>分—时间单位将为分钟。 这是默认设置。</para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("分")]
			Minutes,

			/// <summary>
			/// <para>秒—时间单位将为秒。</para>
			/// </summary>
			[GPValue("Seconds")]
			[Description("秒")]
			Seconds,

			/// <summary>
			/// <para>小时—时间单位将为小时。</para>
			/// </summary>
			[GPValue("Hours")]
			[Description("小时")]
			Hours,

			/// <summary>
			/// <para>天—时间单位将为天。</para>
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
			/// <para>英里—距离单位将为英里。 这是默认设置。</para>
			/// </summary>
			[GPValue("Miles")]
			[Description("英里")]
			Miles,

			/// <summary>
			/// <para>千米—距离单位将为公里。</para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("千米")]
			Kilometers,

			/// <summary>
			/// <para>英尺—距离单位将为英尺。</para>
			/// </summary>
			[GPValue("Feet")]
			[Description("英尺")]
			Feet,

			/// <summary>
			/// <para>码—距离单位将为码。</para>
			/// </summary>
			[GPValue("Yards")]
			[Description("码")]
			Yards,

			/// <summary>
			/// <para>米—距离单位将为米。</para>
			/// </summary>
			[GPValue("Meters")]
			[Description("米")]
			Meters,

			/// <summary>
			/// <para>英寸—距离单位将为英寸。</para>
			/// </summary>
			[GPValue("Inches")]
			[Description("英寸")]
			Inches,

			/// <summary>
			/// <para>厘米—距离单位将为厘米。</para>
			/// </summary>
			[GPValue("Centimeters")]
			[Description("厘米")]
			Centimeters,

			/// <summary>
			/// <para>毫米—距离单位将为毫米。</para>
			/// </summary>
			[GPValue("Millimeters")]
			[Description("毫米")]
			Millimeters,

			/// <summary>
			/// <para>分米—距离单位将为分米。</para>
			/// </summary>
			[GPValue("Decimeters")]
			[Description("分米")]
			Decimeters,

			/// <summary>
			/// <para>海里—距离单位将为海里。</para>
			/// </summary>
			[GPValue("NauticalMiles")]
			[Description("海里")]
			Nautical_Miles,

		}

		/// <summary>
		/// <para>Time Zone for Time Fields</para>
		/// </summary>
		public enum TimeZoneForTimeFieldsEnum 
		{
			/// <summary>
			/// <para>UTC—与停靠点或站点相关的日期时间值位于协调世界时间 (UTC) 中，且不基于停靠点或站点所在的时区。</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

			/// <summary>
			/// <para>各位置的本地时间—与停靠点或站点相关的日期时间值位于停靠点和站点所在的时区内。 对于路径，日期时间值基于路径的起始站点所在的时区。 如果路径没有起始站点，则路径上的所有停靠点和站点必须位于一个时区中。 对于中断点，日期时间值基于路径的时区。 这是默认设置。</para>
			/// </summary>
			[GPValue("LOCAL_TIME_AT_LOCATIONS")]
			[Description("各位置的本地时间")]
			Local_time_at_locations,

		}

		/// <summary>
		/// <para>Output Route Shape</para>
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
			/// <para>直线—输出路径形状为两个停靠点之间的一条直线。如果所选网络数据源为服务，则此选项不可用。</para>
			/// </summary>
			[GPValue("STRAIGHT_LINES")]
			[Description("直线")]
			Straight_lines,

			/// <summary>
			/// <para>沿网络—输出路径将具有基础网络源的精确形状。 输出包括线性参考的路径测量值。 测量值从第一个停靠点增加并将记录到达指定位置的累积阻抗。</para>
			/// </summary>
			[GPValue("ALONG_NETWORK")]
			[Description("沿网络")]
			Along_network,

		}

		/// <summary>
		/// <para>Time Window Violation Importance</para>
		/// </summary>
		public enum TimeWindowFactorEnum 
		{
			/// <summary>
			/// <para>高—求解程序需要寻求最小化时间窗冲突的解决方案（以增加总体行驶时间为代价）。 如果对您而言按时到达停靠点要比最小化总体解决方案成本更加重要，请选择此设置。 您可能会在以下情况下选择此设置：您要在自己的停靠点会见客户，且不想因为迟到给客户带来不便（另一种方法是使用根本不会出现冲突的硬性时间窗）。假设还要考虑车辆配送 (VRP) 的其他约束，可能无法在它们的时间窗内访问所有停靠点。 在这种情况下，即使选择“高”设置也可能会产生冲突。</para>
			/// </summary>
			[GPValue("High")]
			[Description("高")]
			High,

			/// <summary>
			/// <para>中—求解程序在满足时间窗和减少总体解决方案成本之间寻求一种平衡。 这是默认设置。</para>
			/// </summary>
			[GPValue("Medium")]
			[Description("中")]
			Medium,

			/// <summary>
			/// <para>低—求解程序需要寻求最小化总体行驶时间的解决方案（不考虑时间窗）。 如果减少您的总体解决方案成本要比满足时间窗更重要，请选择此设置。 如果积压的服务请求逐渐增多，则可以使用此设置。 如果为了在当日内为更多的停靠点提供服务并减少积压的订单，则可选择此设置，即使车队迟到会为客户带来不便。</para>
			/// </summary>
			[GPValue("Low")]
			[Description("低")]
			Low,

		}

		/// <summary>
		/// <para>Excess Transit Time Importance</para>
		/// </summary>
		public enum ExcessTransitFactorEnum 
		{
			/// <summary>
			/// <para>高—求解程序需要寻求需求点对之间超出行驶时间较短的解决方案（以增加总体行驶成本为代价）。 如果您正在停靠点对间运载乘客并且想缩短他们的乘车时间，请使用此设置。 这是出租车服务的特征。</para>
			/// </summary>
			[GPValue("High")]
			[Description("高")]
			High,

			/// <summary>
			/// <para>中—求解程序在减少超出行驶时间和减少总体解决方案成本之间寻求一种平衡。 这是默认设置。</para>
			/// </summary>
			[GPValue("Medium")]
			[Description("中")]
			Medium,

			/// <summary>
			/// <para>低—求解程序需要寻求最小化总体解决方案成本的结果（不考虑额外行驶时间）。 此设置通常应用于快递服务。 由于快递运输的是包裹而不是人员，因此行驶时间并不十分重要。 使用此设置时，快递可以按照最适合的顺序为停靠点对提供服务，并且总体解决方案成本最低。</para>
			/// </summary>
			[GPValue("Low")]
			[Description("低")]
			Low,

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
		/// <para>Spatial Clustering</para>
		/// </summary>
		public enum SpatialClusteringEnum 
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
		/// <para>Ignore Invalid Locations at Solve Time</para>
		/// </summary>
		public enum IgnoreInvalidLocationsEnum 
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

#endregion
	}
}
