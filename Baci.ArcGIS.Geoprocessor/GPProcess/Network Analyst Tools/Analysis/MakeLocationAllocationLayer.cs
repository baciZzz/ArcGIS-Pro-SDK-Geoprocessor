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
	/// <para>Make Location-Allocation Layer</para>
	/// <para>创建位置分配图层</para>
	/// <para>创建位置分配网络分析图层并设置其分析属性。位置分配分析图层对于从一组可能位置中选择指定数量的设施点（以便以最佳且高效的方式将需求点分配给设施点）十分有用。</para>
	/// </summary>
	[Obsolete()]
	public class MakeLocationAllocationLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDataset">
		/// <para>Input Analysis Network</para>
		/// <para>要执行位置分配分析的网络数据集。</para>
		/// </param>
		/// <param name="OutNetworkAnalysisLayer">
		/// <para>Output Layer Name</para>
		/// <para>要创建的位置分配网络分析图层的名称。</para>
		/// </param>
		/// <param name="ImpedanceAttribute">
		/// <para>Impedance Attribute</para>
		/// <para>分析过程中用作阻抗的成本属性。</para>
		/// </param>
		public MakeLocationAllocationLayer(object InNetworkDataset, object OutNetworkAnalysisLayer, object ImpedanceAttribute)
		{
			this.InNetworkDataset = InNetworkDataset;
			this.OutNetworkAnalysisLayer = OutNetworkAnalysisLayer;
			this.ImpedanceAttribute = ImpedanceAttribute;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建位置分配图层</para>
		/// </summary>
		public override string DisplayName() => "创建位置分配图层";

		/// <summary>
		/// <para>Tool Name : MakeLocationAllocationLayer</para>
		/// </summary>
		public override string ToolName() => "MakeLocationAllocationLayer";

		/// <summary>
		/// <para>Tool Excute Name : na.MakeLocationAllocationLayer</para>
		/// </summary>
		public override string ExcuteName() => "na.MakeLocationAllocationLayer";

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
		public override object[] Parameters() => new object[] { InNetworkDataset, OutNetworkAnalysisLayer, ImpedanceAttribute, LocAllocFromTo, LocAllocProblemType, NumberFacilitiesToFind, ImpedanceCutoff, ImpedanceTransformation, ImpedanceParameter, TargetMarketShare, AccumulateAttributeName, UturnPolicy, RestrictionAttributeName, Hierarchy, OutputPathShape, DefaultCapacity, TimeOfDay, OutputLayer };

		/// <summary>
		/// <para>Input Analysis Network</para>
		/// <para>要执行位置分配分析的网络数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNetworkDatasetLayer()]
		public object InNetworkDataset { get; set; }

		/// <summary>
		/// <para>Output Layer Name</para>
		/// <para>要创建的位置分配网络分析图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Impedance Attribute</para>
		/// <para>分析过程中用作阻抗的成本属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ImpedanceAttribute { get; set; }

		/// <summary>
		/// <para>Travel From</para>
		/// <para>指定计算网络成本时设施点与请求点之间的行驶方向。</para>
		/// <para>设施点到请求点—行驶方向从设施点到请求点。消防部门通常使用该设置，因为他们需要关注从消防站行驶到紧急救援位置所需的时间。</para>
		/// <para>请求点到设施点—行驶方向从请求点到设施点。零售店通常使用该设置，因为他们需要关注购物者到达商店所需的时间。</para>
		/// <para>使用此选项会影响具有单向限制和根据方向不同阻抗不同的网络上的请求点到设施点的分配。例如，从请求点驾车到达设施点可能需要 15 分钟，但从设施点行驶至请求点仅需 10 分钟。</para>
		/// <para><see cref="LocAllocFromToEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LocAllocFromTo { get; set; } = "FACILITY_TO_DEMAND";

		/// <summary>
		/// <para>Location-Allocation Problem Type</para>
		/// <para>将要求解的问题的类型。问题类型的选择取决于要定位的设施点种类。不同种类的设施点具有不同的优先级和约束。</para>
		/// <para>最小化阻抗—此选项可解决仓库位置问题。它选择一组使加权阻抗（请求的位置乘以到最近设施点的阻抗）的总和最小的设施点。此问题类型通常称为 P 中位数问题。</para>
		/// <para>最大化覆盖范围—此选项可解决消防站位置问题。它选择了多个设施点以保证所有或最大数量的请求点处于指定的阻抗中断范围内。</para>
		/// <para>最大化具有容量限制的覆盖范围—此选项用于求解容量有限的设施点的位置问题。此选项将选择一组满足所有或最大数量的请求而不超出任何设施点容量的设施点。除了支持容量外，该选项还选择一组使加权阻抗（分配给某个设施点的请求点乘以到该设施点的阻抗）的总和最小的设施点。</para>
		/// <para>最小化设施点数—此选项可解决消防站位置问题。它将选择当在指定的阻抗中断范围内覆盖了所有或最大数量的请求点时所需要的设施点的最小数量。</para>
		/// <para>最大化人流量—此选项可解决邻域存储位置问题，其中分配给最近所选设施点的请求比例将随距离的增加而降低。已选择最大化总分配请求点的设施点集。大于指定的阻抗中断的请求点不会影响所选的设施点集。</para>
		/// <para>最大化市场份额—此选项可解决竞争性设施点的位置问题。它选择当存在竞争性设施点时可最大化市场份额的设施点。重力模型概念用于确定分配给每个设施点的请求点比例。已选择最大化总分配请求点的设施点集。</para>
		/// <para>目标市场份额—此选项可解决竞争性设施点的位置问题。它选择当存在竞争性设施点时可达到指定目标市场份额的设施点。重力模型概念用于确定分配给每个设施点的请求点比例。已选择的最小设施点量需达到指定的目标市场份额。</para>
		/// <para><see cref="LocAllocProblemTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LocAllocProblemType { get; set; } = "MINIMIZE_IMPEDANCE";

		/// <summary>
		/// <para>Number of Facilities to Find</para>
		/// <para>指定求解程序将查找的设施点数。</para>
		/// <para>当要查找的设施点多于所需设施点时，FacilityType 值为必选项的设施点将始终为解的一部分；要选择的任何额外设施点都将从候选设施点中选取。</para>
		/// <para>在求解前所有 FacilityType 值为已选项的设施点在求解时都将视为候选设施点。</para>
		/// <para>对于最小化设施点数问题类型不会考虑参数值，因为求解程序会确定最小的设施点数来查找最大的覆盖范围。</para>
		/// <para>对于目标市场份额问题类型，参数值会被覆盖，因为求解程序会搜索要占有指定市场份额所需的最小设施点数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumberFacilitiesToFind { get; set; } = "1";

		/// <summary>
		/// <para>Impedance Cutoff</para>
		/// <para>阻抗中断指定请求点可分配给设施点的最大阻抗。最大阻抗以沿网络的最小成本路径进行测量。如果请求点位于中断外，则不会被分配。此属性可用于对人们为前往商店而愿意行进的最大距离，以及消防站到达社区中任一请求点所允许的最大时间进行建模。</para>
		/// <para>如果设置请求点的 Cutoff__[阻抗] 属性，该属性将覆盖分析图层的阻抗中断属性。您可能会发现，乡村居民愿意走 10 英里远去往某个设施点，而城镇居民则只愿意走 2 英里的路程。此情况可以如下方式建模：将分析图层的阻抗中断值设置为 10，而将城镇地区中请求点的 Cutoff_Miles 值设置为 2。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ImpedanceCutoff { get; set; }

		/// <summary>
		/// <para>Impedance Transformation</para>
		/// <para>此属性可设置对设施点与请求点间网络成本进行变换的方程。它还可与阻抗参数结合使用，指定设施点与请求点间的网络阻抗对于求解程序选择设施点的影响的严重程度。</para>
		/// <para>线性—设施点和请求点之间变换的网络阻抗与它们之间的最短路径网络阻抗相同。使用此选项，阻抗参数始终设置为 1。这是默认设置。</para>
		/// <para>幂—设施点和请求点之间变换的网络阻抗等于以最短路径网络阻抗为底，以阻抗参数所指定的数为指数的幂运算结果。将此选项与正阻抗参数结合使用可对附近的设施点指定较高的权重。</para>
		/// <para>指数—设施点和请求点之间变换的网络阻抗等于以数学常量 e 为底，以最短路径网络阻抗所指定的数为指数的幂乘以阻抗参数。将此选项与正阻抗参数结合使用可对附近的设施点指定很高的权重。指数变换通常与阻抗中断结合使用。</para>
		/// <para>如果设置请求点的 ImpedanceTransformation 属性，该属性会覆盖分析图层的“阻抗变换”属性。这时，您可能要针对城镇居民和乡村居民使用不同的阻抗变换。可通过为分析图层设置阻抗变换以匹配乡村居民的阻抗参数，同时为城镇地区中的请求点设置阻抗参数以匹配城镇居民的阻抗参数，来执行建模。</para>
		/// <para><see cref="ImpedanceTransformationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ImpedanceTransformation { get; set; } = "LINEAR";

		/// <summary>
		/// <para>Impedance Parameter</para>
		/// <para>为“阻抗变换”参数中指定的方程提供参数值。当阻抗变换的类型为线性时会忽略参数值。对于幂和指数阻抗变换，应设置非零值。</para>
		/// <para>如果设置请求点的 ImpedanceParameter 属性，该属性会覆盖分析图层的 阻抗参数属性。您可能要针对城镇居民和乡村居民使用不同的阻抗参数。可通过为分析图层设置阻抗变换以匹配乡村居民的阻抗参数，同时为城镇地区中的请求点设置阻抗参数以匹配城镇居民的阻抗参数，来执行建模。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ImpedanceParameter { get; set; } = "1";

		/// <summary>
		/// <para>Target Market Share</para>
		/// <para>指定当位置分配问题类型参数设置为目标市场份额时要求解的目标市场份额百分比。它是您希望设施点解占总请求权重的百分比。求解程序会求出为占有该值指定的目标市场份额所需的最小设施点数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object TargetMarketShare { get; set; } = "10";

		/// <summary>
		/// <para>Accumulators</para>
		/// <para>分析过程中要累积的成本属性的列表。这些累积属性仅供参考；求解程序仅使用阻抗属性参数所指定的成本属性来计算路径。</para>
		/// <para>对于每个累积的成本属性，均会向求解程序所输出的路径中添加一个 Total_[阻抗] 属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Accumulators")]
		public object AccumulateAttributeName { get; set; }

		/// <summary>
		/// <para>U-Turn Policy</para>
		/// <para>指定将在交汇点处使用的 U 形转弯策略。允许 U 形转弯表示求解程序可以在交汇点处转向并沿同一街道往回行驶。考虑到交汇点表示街道交叉路口和死角，不同的车辆可以在某些交汇点转弯，而在其他交汇点则不行 - 这取决于交汇点是交叉路口还是死角。为适应此情况，U 形转弯策略参数由连接到交汇点的边数隐性指定，这称为交汇点价。此参数可接受的值如下所列；每个值的后面是根据交汇点价对其含义的描述。</para>
		/// <para>允许—无论在交汇点处有几条连接的边，均允许 U 形转弯。这是默认值。</para>
		/// <para>不允许—在所有交汇点处均禁止 U 形转弯，不管交汇点原子价如何。不过请注意，即使已选择该设置，在网络位置处仍允许 U 形转弯；但是也可以通过设置个别网络位置的 CurbApproach 属性来禁止 U 形转弯。</para>
		/// <para>仅在末路处允许—除仅有一条相邻边的交汇点（死角）外，其他交汇点均禁止 U 形转弯。</para>
		/// <para>仅在末路处和交点处允许—在恰好有两条相邻边相遇的交汇点处禁止 U 形转弯，但是交叉点（三条或三条以上相邻边的交汇点）和死角（仅有一条相邻边的交汇点）处允许。通常，网络在路段中间有多余的交汇点。此选项可防止车辆在这些位置出现 U 形转弯。</para>
		/// <para>如果您需要定义更加精确的 U 形转弯策略，可以考虑在网络成本属性中添加一个通用转弯延迟赋值器，或者如果存在的话，调整其设置，并特别注意反向转弯的配置。还可以设置网络位置的 CurbApproach 属性。</para>
		/// <para><see cref="UturnPolicyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Restrictions")]
		public object UturnPolicy { get; set; } = "ALLOW_UTURNS";

		/// <summary>
		/// <para>Restrictions</para>
		/// <para>分析过程中要应用的限制属性的列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Restrictions")]
		public object RestrictionAttributeName { get; set; }

		/// <summary>
		/// <para>Use Hierarchy in Analysis</para>
		/// <para>选中 - 将使用等级属性进行分析。使用等级的结果是，求解程序更偏好高等级的边而不是低等级的边。分等级求解的速度更快，并且可用于模拟驾驶员在可能的情况下选择在高速公路而非地方道路上行驶（即使行程可能更远）的偏好。只有输入网络数据集具有等级属性时，此选项才处于活动状态。</para>
		/// <para>未选中 - 将不会使用等级属性进行分析。如果未使用等级，则结果是网络数据集的精确路径。</para>
		/// <para>如果未在用于执行分析的网络数据集中定义等级属性，该参数将处于非活动状态。</para>
		/// <para><see cref="HierarchyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Hierarchy")]
		public object Hierarchy { get; set; }

		/// <summary>
		/// <para>Output Path Shape</para>
		/// <para>无线—将不会为分析的输出生成任何形状。</para>
		/// <para>直线—输出线形状是对设施点解及其分配的请求点进行连接的直线。</para>
		/// <para><see cref="OutputPathShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Options")]
		public object OutputPathShape { get; set; } = "STRAIGHT_LINES";

		/// <summary>
		/// <para>Default Capacity</para>
		/// <para>指定位置分配问题类型参数设为最大化有容量限制的覆盖范围时默认的设施点容量。对于所有其他问题类型，可忽略此参数。</para>
		/// <para>设施点有容量属性，如果此属性设置为非空值，将覆盖该设施点的默认容量参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object DefaultCapacity { get; set; } = "1";

		/// <summary>
		/// <para>Start Time</para>
		/// <para>指示出发的时间和日期。出发时间可以来自设施点或请求点，取决于行驶是从请求点到设施点还是从设施点到请求点。</para>
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
		public object TimeOfDay { get; set; }

		/// <summary>
		/// <para>Network Analyst Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object OutputLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeLocationAllocationLayer SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Travel From</para>
		/// </summary>
		public enum LocAllocFromToEnum 
		{
			/// <summary>
			/// <para>请求点到设施点—行驶方向从请求点到设施点。零售店通常使用该设置，因为他们需要关注购物者到达商店所需的时间。</para>
			/// </summary>
			[GPValue("DEMAND_TO_FACILITY")]
			[Description("请求点到设施点")]
			Demand_to_Facility,

			/// <summary>
			/// <para>设施点到请求点—行驶方向从设施点到请求点。消防部门通常使用该设置，因为他们需要关注从消防站行驶到紧急救援位置所需的时间。</para>
			/// </summary>
			[GPValue("FACILITY_TO_DEMAND")]
			[Description("设施点到请求点")]
			Facility_to_Demand,

		}

		/// <summary>
		/// <para>Location-Allocation Problem Type</para>
		/// </summary>
		public enum LocAllocProblemTypeEnum 
		{
			/// <summary>
			/// <para>最小化阻抗—此选项可解决仓库位置问题。它选择一组使加权阻抗（请求的位置乘以到最近设施点的阻抗）的总和最小的设施点。此问题类型通常称为 P 中位数问题。</para>
			/// </summary>
			[GPValue("MINIMIZE_IMPEDANCE")]
			[Description("最小化阻抗")]
			Minimize_impedance,

			/// <summary>
			/// <para>最大化覆盖范围—此选项可解决消防站位置问题。它选择了多个设施点以保证所有或最大数量的请求点处于指定的阻抗中断范围内。</para>
			/// </summary>
			[GPValue("MAXIMIZE_COVERAGE")]
			[Description("最大化覆盖范围")]
			Maximize_coverage,

			/// <summary>
			/// <para>最大化具有容量限制的覆盖范围—此选项用于求解容量有限的设施点的位置问题。此选项将选择一组满足所有或最大数量的请求而不超出任何设施点容量的设施点。除了支持容量外，该选项还选择一组使加权阻抗（分配给某个设施点的请求点乘以到该设施点的阻抗）的总和最小的设施点。</para>
			/// </summary>
			[GPValue("MAXIMIZE_CAPACITATED_COVERAGE")]
			[Description("最大化具有容量限制的覆盖范围")]
			Maximize_capacitated_coverage,

			/// <summary>
			/// <para>最小化设施点数—此选项可解决消防站位置问题。它将选择当在指定的阻抗中断范围内覆盖了所有或最大数量的请求点时所需要的设施点的最小数量。</para>
			/// </summary>
			[GPValue("MINIMIZE_FACILITIES")]
			[Description("最小化设施点数")]
			Minimize_facilities,

			/// <summary>
			/// <para>最大化人流量—此选项可解决邻域存储位置问题，其中分配给最近所选设施点的请求比例将随距离的增加而降低。已选择最大化总分配请求点的设施点集。大于指定的阻抗中断的请求点不会影响所选的设施点集。</para>
			/// </summary>
			[GPValue("MAXIMIZE_ATTENDANCE")]
			[Description("最大化人流量")]
			Maximize_attendance,

			/// <summary>
			/// <para>最大化市场份额—此选项可解决竞争性设施点的位置问题。它选择当存在竞争性设施点时可最大化市场份额的设施点。重力模型概念用于确定分配给每个设施点的请求点比例。已选择最大化总分配请求点的设施点集。</para>
			/// </summary>
			[GPValue("MAXIMIZE_MARKET_SHARE")]
			[Description("最大化市场份额")]
			Maximize_market_share,

			/// <summary>
			/// <para>目标市场份额—此选项可解决竞争性设施点的位置问题。它选择当存在竞争性设施点时可达到指定目标市场份额的设施点。重力模型概念用于确定分配给每个设施点的请求点比例。已选择的最小设施点量需达到指定的目标市场份额。</para>
			/// </summary>
			[GPValue("TARGET_MARKET_SHARE")]
			[Description("目标市场份额")]
			Target_market_share,

		}

		/// <summary>
		/// <para>Impedance Transformation</para>
		/// </summary>
		public enum ImpedanceTransformationEnum 
		{
			/// <summary>
			/// <para>线性—设施点和请求点之间变换的网络阻抗与它们之间的最短路径网络阻抗相同。使用此选项，阻抗参数始终设置为 1。这是默认设置。</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("线性")]
			Linear,

			/// <summary>
			/// <para>幂—设施点和请求点之间变换的网络阻抗等于以最短路径网络阻抗为底，以阻抗参数所指定的数为指数的幂运算结果。将此选项与正阻抗参数结合使用可对附近的设施点指定较高的权重。</para>
			/// </summary>
			[GPValue("POWER")]
			[Description("幂")]
			Power,

			/// <summary>
			/// <para>指数—设施点和请求点之间变换的网络阻抗等于以数学常量 e 为底，以最短路径网络阻抗所指定的数为指数的幂乘以阻抗参数。将此选项与正阻抗参数结合使用可对附近的设施点指定很高的权重。指数变换通常与阻抗中断结合使用。</para>
			/// </summary>
			[GPValue("EXPONENTIAL")]
			[Description("指数")]
			Exponential,

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
		/// <para>Use Hierarchy in Analysis</para>
		/// </summary>
		public enum HierarchyEnum 
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
		/// <para>Output Path Shape</para>
		/// </summary>
		public enum OutputPathShapeEnum 
		{
			/// <summary>
			/// <para>无线—将不会为分析的输出生成任何形状。</para>
			/// </summary>
			[GPValue("NO_LINES")]
			[Description("无线")]
			No_lines,

			/// <summary>
			/// <para>直线—输出线形状是对设施点解及其分配的请求点进行连接的直线。</para>
			/// </summary>
			[GPValue("STRAIGHT_LINES")]
			[Description("直线")]
			Straight_lines,

		}

#endregion
	}
}
