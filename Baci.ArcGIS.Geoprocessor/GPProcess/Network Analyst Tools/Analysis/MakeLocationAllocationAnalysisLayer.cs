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
	/// <para>Make Location-Allocation Analysis Layer</para>
	/// <para>创建位置分配图层</para>
	/// <para>创建位置分配网络分析图层并设置其分析属性。 位置分配分析图层对于从一组可能位置中选择指定数量的设施点（以便以最佳且高效的方式将需求点分配给设施点）十分有用。 该图层可通过本地网络数据集进行创建，也可通过在线托管服务或门户托管服务进行创建。</para>
	/// </summary>
	public class MakeLocationAllocationAnalysisLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="NetworkDataSource">
		/// <para>Network Data Source</para>
		/// <para>将对其执行网络分析的网络数据集或服务。 将门户 URL 用于服务。</para>
		/// </param>
		public MakeLocationAllocationAnalysisLayer(object NetworkDataSource)
		{
			this.NetworkDataSource = NetworkDataSource;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建位置分配图层</para>
		/// </summary>
		public override string DisplayName() => "创建位置分配图层";

		/// <summary>
		/// <para>Tool Name : MakeLocationAllocationAnalysisLayer</para>
		/// </summary>
		public override string ToolName() => "MakeLocationAllocationAnalysisLayer";

		/// <summary>
		/// <para>Tool Excute Name : na.MakeLocationAllocationAnalysisLayer</para>
		/// </summary>
		public override string ExcuteName() => "na.MakeLocationAllocationAnalysisLayer";

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
		public override object[] Parameters() => new object[] { NetworkDataSource, LayerName!, TravelMode!, TravelDirection!, ProblemType!, Cutoff!, NumberOfFacilitiesToFind!, DecayFunctionType!, DecayFunctionParameterValue!, TargetMarketShare!, Capacity!, TimeOfDay!, TimeZone!, LineShape!, AccumulateAttributes!, OutNetworkAnalysisLayer!, IgnoreInvalidLocations! };

		/// <summary>
		/// <para>Network Data Source</para>
		/// <para>将对其执行网络分析的网络数据集或服务。 将门户 URL 用于服务。</para>
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
		public object? LayerName { get; set; }

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>分析中使用的出行模式名称。 出行模式为一组网络设置（例如行驶限制和 U 形转弯），用于确定行人、车辆、卡车或其他交通媒介在网络中的移动方式。 出行模式在网络数据源中进行定义。</para>
		/// <para>arcpy.na.TravelMode 对象和包含出行模式有效 JSON 表示的字符串也可用作参数的输入。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TravelMode { get; set; }

		/// <summary>
		/// <para>Travel Direction</para>
		/// <para>指定计算网络成本时设施点与请求点之间的行驶方向。</para>
		/// <para>远离设施点—行驶方向从设施点到请求点。 这是默认设置。 消防部门通常使用该设置，因为他们需要关注从消防站行驶到紧急救援位置所需的时间。</para>
		/// <para>朝向设施点—行驶方向从请求点到设施点。 零售店通常使用该设置，因为他们需要关注购物者到达商店所需的时间。</para>
		/// <para>使用此选项会影响具有单向限制和根据方向不同阻抗不同的网络上的请求点到设施点的分配。 例如，从请求点驾车到达设施点可能需要 15 分钟，但从设施点驾车行驶至请求点仅需 10 分钟。</para>
		/// <para><see cref="TravelDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TravelDirection { get; set; } = "FROM_FACILITIES";

		/// <summary>
		/// <para>Problem Type</para>
		/// <para>将要求解的问题的类型。 问题类型的选择取决于要定位的设施点种类。 不同种类的设施点具有不同的优先级和约束。</para>
		/// <para>最小化阻抗—此选项可解决仓库位置问题。 它选择一组使加权阻抗（请求的位置乘以到最近设施点的阻抗）的总和最小的设施点。 此问题类型通常称为 P 中位数问题。 此为默认问题类型。</para>
		/// <para>最大化覆盖范围—此选项可解决消防站位置问题。 它选择了多个设施点以保证所有或最大数量的请求点处于指定的阻抗中断范围内。</para>
		/// <para>最大化具有容量限制的覆盖范围—此选项用于求解容量有限的设施点的位置问题。 此选项将选择一组满足所有或最大数量的请求而不超出任何设施点容量的设施点。 除了支持容量外，该选项还选择一组使加权阻抗（分配给某个设施点的请求点乘以到该设施点的阻抗）的总和最小的设施点。</para>
		/// <para>最小化设施点数—此选项可解决消防站位置问题。 它将选择当在指定的阻抗中断范围内覆盖了所有或最大数量的请求点时所需要的设施点的最小数量。</para>
		/// <para>最大化人流量—此选项可解决邻域存储位置问题，其中分配给最近所选设施点的请求比例将随距离的增加而降低。 已选择最大化总分配请求点的设施点集。 大于指定的阻抗中断的请求点不会影响所选的设施点集。</para>
		/// <para>最大化市场份额—此选项可解决竞争性设施点的位置问题。 它选择当存在竞争性设施点时可最大化市场份额的设施点。 重力模型概念用于确定分配给每个设施点的请求点比例。 已选择最大化总分配请求点的设施点集。</para>
		/// <para>目标市场份额—此选项可解决竞争性设施点的位置问题。 它选择当存在竞争性设施点时可达到指定目标市场份额的设施点。 重力模型概念用于确定分配给每个设施点的请求点比例。 已选择的最小设施点量需达到指定的目标市场份额。</para>
		/// <para><see cref="ProblemTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Problem Type")]
		public object? ProblemType { get; set; } = "MINIMIZE_IMPEDANCE";

		/// <summary>
		/// <para>Cutoff</para>
		/// <para>请求点可分配给设施点的最大阻抗的单位是您所选出行模式所使用的阻抗属性的单位。 最大阻抗以沿网络的最小成本路径进行测量。 如果请求点位于中断外，则不会被分配。 此属性可用于对人们为前往商店而愿意行进的最大距离，以及消防站到达社区中任一请求点所允许的最大时间进行建模。</para>
		/// <para>可通过在 Cutoff_ [阻抗] 属性中指定请求点子图层中的单个中断值来逐个请求点覆盖中断。 例如，您可能会发现，乡村居民愿意走 10 英里远去往某个设施点，而城镇居民则只愿意走 2 英里的路程。 可按如下方式对此行为进行建模：将分析图层的中断值设置为 10 并将城区中各请求点的 Cutoff_Miles 值设置为 2。</para>
		/// <para>默认情况下分析不使用中断。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Problem Type")]
		public object? Cutoff { get; set; }

		/// <summary>
		/// <para>Number of Facilities to Find</para>
		/// <para>指定求解程序将查找的设施点数。 默认情况下，此参数设置为 1。</para>
		/// <para>当要查找的设施点多于所需设施点时，FacilityType 值为必选项的设施点将始终为解的一部分；要选择的任何额外设施点都将从候选设施点中选取。</para>
		/// <para>在求解前所有 FacilityType 值为已选项的设施点在求解时都将视为候选设施点。</para>
		/// <para>对于最小化设施点数问题类型，不会考虑参数值，因为求解程序会确定最小的设施点数来查找最大的覆盖范围。</para>
		/// <para>对于目标市场份额问题类型，参数值会被覆盖，因为求解程序会搜索要占有指定市场份额所需的最小设施点数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Problem Type")]
		public object? NumberOfFacilitiesToFind { get; set; } = "1";

		/// <summary>
		/// <para>Decay Function Type</para>
		/// <para>此属性可设置对设施点与请求点间网络成本进行变换的方程。 此属性与衰减函数参数值结合使用，可指定设施点与请求点间的网络阻抗对求解程序选择设施点的影响的严重程度。</para>
		/// <para>线性—设施点和请求点之间变换的网络阻抗与它们之间的最短路径网络阻抗相同。 使用此选项，阻抗参数始终设置为 1。 这是默认设置。</para>
		/// <para>幂—设施点和请求点之间变换的网络阻抗等于以最短路径网络阻抗为底，以阻抗参数所指定的数为指数的幂运算结果。 将此选项与正阻抗参数结合使用可对附近的设施点指定较高的权重。</para>
		/// <para>指数—设施点和请求点之间变换的网络阻抗等于以数学常量 e 为底，以最短路径网络阻抗所指定的数为指数的幂乘以阻抗参数。 将此选项与正阻抗参数结合使用可对附近的设施点指定很高的权重。指数变换通常与阻抗中断结合使用。</para>
		/// <para>如果设置请求点的 ImpedanceTransformation 属性，则该属性会逐个请求点覆盖分析图层的衰减函数参数值属性。 这时，您可能要针对城镇居民和乡村居民使用不同的衰减函数。 可通过为分析图层设置阻抗变换以匹配乡村居民的衰减函数，同时为城镇地区中的各个请求点设置阻抗变换以匹配城镇居民的衰减函数，来执行建模。</para>
		/// <para><see cref="DecayFunctionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Problem Type")]
		public object? DecayFunctionType { get; set; } = "LINEAR";

		/// <summary>
		/// <para>Decay Function Parameter Value</para>
		/// <para>衰减函数类型参数中指定的方程的参数值。 当衰减函数的类型为线性时会忽略参数值。 对于幂和指数衰减参数，应设置非零值。</para>
		/// <para>如果设置请求点的 ImpedanceTransformation 属性，则该属性会逐个请求点覆盖分析图层的衰减函数参数值属性。 这时，您可能要针对城镇居民和乡村居民使用不同的衰减函数。 可通过为分析图层设置阻抗变换以匹配乡村居民的衰减函数，同时为城镇地区中的各个请求点设置阻抗变换以匹配城镇居民的衰减函数，来执行建模。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Problem Type")]
		public object? DecayFunctionParameterValue { get; set; } = "1";

		/// <summary>
		/// <para>Target Market Share</para>
		/// <para>指定当问题类型参数设置为目标市场份额时要求解的目标市场份额百分比。 它是您希望设施点解占总请求权重的百分比。 求解程序会求出为占有该值指定的目标市场份额所需的最小设施点数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Problem Type")]
		public object? TargetMarketShare { get; set; } = "10";

		/// <summary>
		/// <para>Capacity</para>
		/// <para>指定问题类型参数设置为最大化有容量限制的覆盖范围时默认的设施点容量。 对于所有其他问题类型，可忽略此参数。</para>
		/// <para>设施点有容量属性，如果此属性设置为非空值，将覆盖该设施点的容量参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Problem Type")]
		public object? Capacity { get; set; } = "1";

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>出发的时间和日期。 出发时间可以来自设施点或请求点，取决于行驶方向是从请求点到设施点还是从设施点到请求点。</para>
		/// <para>如果您已经选择了基于流量的阻抗属性，将会根据特定的某天某时的动态交通状况来生成解决方案。 日期和时间可被指定为 5/14/2012 10:30 AM。</para>
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
		public object? TimeOfDay { get; set; }

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>时间参数的时区。</para>
		/// <para>各位置的本地时间—时间参数是指设施点或请求点所处的时区。 如果行驶方向是从设施点到请求点，此为设施点所处的时区。 如果行驶方向是从请求点到设施点，此为请求点所处的时区。 这是默认设置。</para>
		/// <para>UTC—时间参数是指协调世界时间 (UTC)。 如果您想要在指定时间内（如现在）选择最佳位置，但不确定设施点或请求点所在的时区，请选择此选项。</para>
		/// <para><see cref="TimeZoneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Time of Day")]
		public object? TimeZone { get; set; } = "LOCAL_TIME_AT_LOCATIONS";

		/// <summary>
		/// <para>Line Shape</para>
		/// <para>指定输出线形状。</para>
		/// <para>无线—将不会为分析的输出生成任何形状。 如果您想求解超大型问题，并且仅对解决方案表感兴趣而不想查看地图中的结果，则此选项十分有用。</para>
		/// <para>直线—输出线形状是对设施点及其分配的请求点进行连接的直线。 这是默认设置。</para>
		/// <para>无论选择何种输出 shape 类型，最佳路径始终由网络阻抗（而非欧氏距离）决定。 这表示只是路径形状不同，而对网络进行的基础遍历则相同。</para>
		/// <para><see cref="LineShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Geometry")]
		public object? LineShape { get; set; } = "STRAIGHT_LINES";

		/// <summary>
		/// <para>Accumulate Attributes</para>
		/// <para>分析过程中要累积的成本属性的列表。 这些累积属性仅供参考；求解程序仅使用求解分析时指定的出行模式所使用的成本属性。</para>
		/// <para>对于每个累积的成本属性，会在网络分析输出要素中填充 Total_[阻抗] 属性。</para>
		/// <para>如果网络数据源为 ArcGIS Online 服务，或如果网络数据源是不支持累积的 Portal for ArcGIS 版本上的服务，则此参数不可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Accumulate Attributes")]
		public object? AccumulateAttributes { get; set; }

		/// <summary>
		/// <para>Network Analyst Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object? OutNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Ignore Invalid Locations at Solve Time</para>
		/// <para>指定是否忽略无效的输入位置。 通常，如果无法在网络上定位，则位置无效。 当无效位置被忽略时，求解器将跳过它们并尝试使用剩余位置执行分析。</para>
		/// <para>选中 - 将忽略无效的输入位置，并且仅使用有效的位置。 这是默认设置。</para>
		/// <para>未选中 - 将使用所有输入位置。 无效的位置将导致分析失败。</para>
		/// <para><see cref="IgnoreInvalidLocationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Locations")]
		public object? IgnoreInvalidLocations { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeLocationAllocationAnalysisLayer SetEnviroment(object? workspace = null)
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
			/// <para>朝向设施点—行驶方向从请求点到设施点。 零售店通常使用该设置，因为他们需要关注购物者到达商店所需的时间。</para>
			/// </summary>
			[GPValue("TO_FACILITIES")]
			[Description("朝向设施点")]
			Toward_facilities,

			/// <summary>
			/// <para>远离设施点—行驶方向从设施点到请求点。 这是默认设置。 消防部门通常使用该设置，因为他们需要关注从消防站行驶到紧急救援位置所需的时间。</para>
			/// </summary>
			[GPValue("FROM_FACILITIES")]
			[Description("远离设施点")]
			Away_from_facilities,

		}

		/// <summary>
		/// <para>Problem Type</para>
		/// </summary>
		public enum ProblemTypeEnum 
		{
			/// <summary>
			/// <para>最小化阻抗—此选项可解决仓库位置问题。 它选择一组使加权阻抗（请求的位置乘以到最近设施点的阻抗）的总和最小的设施点。 此问题类型通常称为 P 中位数问题。 此为默认问题类型。</para>
			/// </summary>
			[GPValue("MINIMIZE_IMPEDANCE")]
			[Description("最小化阻抗")]
			Minimize_impedance,

			/// <summary>
			/// <para>最大化覆盖范围—此选项可解决消防站位置问题。 它选择了多个设施点以保证所有或最大数量的请求点处于指定的阻抗中断范围内。</para>
			/// </summary>
			[GPValue("MAXIMIZE_COVERAGE")]
			[Description("最大化覆盖范围")]
			Maximize_coverage,

			/// <summary>
			/// <para>最大化具有容量限制的覆盖范围—此选项用于求解容量有限的设施点的位置问题。 此选项将选择一组满足所有或最大数量的请求而不超出任何设施点容量的设施点。 除了支持容量外，该选项还选择一组使加权阻抗（分配给某个设施点的请求点乘以到该设施点的阻抗）的总和最小的设施点。</para>
			/// </summary>
			[GPValue("MAXIMIZE_CAPACITATED_COVERAGE")]
			[Description("最大化具有容量限制的覆盖范围")]
			Maximize_capacitated_coverage,

			/// <summary>
			/// <para>最小化设施点数—此选项可解决消防站位置问题。 它将选择当在指定的阻抗中断范围内覆盖了所有或最大数量的请求点时所需要的设施点的最小数量。</para>
			/// </summary>
			[GPValue("MINIMIZE_FACILITIES")]
			[Description("最小化设施点数")]
			Minimize_facilities,

			/// <summary>
			/// <para>最大化人流量—此选项可解决邻域存储位置问题，其中分配给最近所选设施点的请求比例将随距离的增加而降低。 已选择最大化总分配请求点的设施点集。 大于指定的阻抗中断的请求点不会影响所选的设施点集。</para>
			/// </summary>
			[GPValue("MAXIMIZE_ATTENDANCE")]
			[Description("最大化人流量")]
			Maximize_attendance,

			/// <summary>
			/// <para>最大化市场份额—此选项可解决竞争性设施点的位置问题。 它选择当存在竞争性设施点时可最大化市场份额的设施点。 重力模型概念用于确定分配给每个设施点的请求点比例。 已选择最大化总分配请求点的设施点集。</para>
			/// </summary>
			[GPValue("MAXIMIZE_MARKET_SHARE")]
			[Description("最大化市场份额")]
			Maximize_market_share,

			/// <summary>
			/// <para>目标市场份额—此选项可解决竞争性设施点的位置问题。 它选择当存在竞争性设施点时可达到指定目标市场份额的设施点。 重力模型概念用于确定分配给每个设施点的请求点比例。 已选择的最小设施点量需达到指定的目标市场份额。</para>
			/// </summary>
			[GPValue("TARGET_MARKET_SHARE")]
			[Description("目标市场份额")]
			Target_market_share,

		}

		/// <summary>
		/// <para>Decay Function Type</para>
		/// </summary>
		public enum DecayFunctionTypeEnum 
		{
			/// <summary>
			/// <para>线性—设施点和请求点之间变换的网络阻抗与它们之间的最短路径网络阻抗相同。 使用此选项，阻抗参数始终设置为 1。 这是默认设置。</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("线性")]
			Linear,

			/// <summary>
			/// <para>幂—设施点和请求点之间变换的网络阻抗等于以最短路径网络阻抗为底，以阻抗参数所指定的数为指数的幂运算结果。 将此选项与正阻抗参数结合使用可对附近的设施点指定较高的权重。</para>
			/// </summary>
			[GPValue("POWER")]
			[Description("幂")]
			Power,

			/// <summary>
			/// <para>指数—设施点和请求点之间变换的网络阻抗等于以数学常量 e 为底，以最短路径网络阻抗所指定的数为指数的幂乘以阻抗参数。 将此选项与正阻抗参数结合使用可对附近的设施点指定很高的权重。指数变换通常与阻抗中断结合使用。</para>
			/// </summary>
			[GPValue("EXPONENTIAL")]
			[Description("指数")]
			Exponential,

		}

		/// <summary>
		/// <para>Time Zone</para>
		/// </summary>
		public enum TimeZoneEnum 
		{
			/// <summary>
			/// <para>UTC—时间参数是指协调世界时间 (UTC)。 如果您想要在指定时间内（如现在）选择最佳位置，但不确定设施点或请求点所在的时区，请选择此选项。</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

			/// <summary>
			/// <para>各位置的本地时间—时间参数是指设施点或请求点所处的时区。 如果行驶方向是从设施点到请求点，此为设施点所处的时区。 如果行驶方向是从请求点到设施点，此为请求点所处的时区。 这是默认设置。</para>
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
			/// <para>无线—将不会为分析的输出生成任何形状。 如果您想求解超大型问题，并且仅对解决方案表感兴趣而不想查看地图中的结果，则此选项十分有用。</para>
			/// </summary>
			[GPValue("NO_LINES")]
			[Description("无线")]
			No_lines,

			/// <summary>
			/// <para>直线—输出线形状是对设施点及其分配的请求点进行连接的直线。 这是默认设置。</para>
			/// </summary>
			[GPValue("STRAIGHT_LINES")]
			[Description("直线")]
			Straight_lines,

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
