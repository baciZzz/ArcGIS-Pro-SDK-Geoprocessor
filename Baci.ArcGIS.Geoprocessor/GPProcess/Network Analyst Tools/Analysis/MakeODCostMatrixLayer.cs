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
	/// <para>Make OD Cost Matrix Layer</para>
	/// <para>创建 OD 成本矩阵图层</para>
	/// <para>创建起始-目的地 (OD) 成本矩阵网络分析图层并设置其分析属性。OD 成本矩阵分析图层对于描述从一组起始位置到一组目的地位置的成本矩阵十分有用。</para>
	/// </summary>
	[Obsolete()]
	public class MakeODCostMatrixLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDataset">
		/// <para>Input Analysis Network</para>
		/// <para>要执行 OD 成本矩阵分析的网络数据集。</para>
		/// </param>
		/// <param name="OutNetworkAnalysisLayer">
		/// <para>Output Layer Name</para>
		/// <para>要创建的 OD 成本矩阵网络分析图层的名称。</para>
		/// </param>
		/// <param name="ImpedanceAttribute">
		/// <para>Impedance Attribute</para>
		/// <para>分析过程中用作阻抗的成本属性。</para>
		/// </param>
		public MakeODCostMatrixLayer(object InNetworkDataset, object OutNetworkAnalysisLayer, object ImpedanceAttribute)
		{
			this.InNetworkDataset = InNetworkDataset;
			this.OutNetworkAnalysisLayer = OutNetworkAnalysisLayer;
			this.ImpedanceAttribute = ImpedanceAttribute;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建 OD 成本矩阵图层</para>
		/// </summary>
		public override string DisplayName() => "创建 OD 成本矩阵图层";

		/// <summary>
		/// <para>Tool Name : MakeODCostMatrixLayer</para>
		/// </summary>
		public override string ToolName() => "MakeODCostMatrixLayer";

		/// <summary>
		/// <para>Tool Excute Name : na.MakeODCostMatrixLayer</para>
		/// </summary>
		public override string ExcuteName() => "na.MakeODCostMatrixLayer";

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
		public override object[] Parameters() => new object[] { InNetworkDataset, OutNetworkAnalysisLayer, ImpedanceAttribute, DefaultCutoff, DefaultNumberDestinationsToFind, AccumulateAttributeName, UturnPolicy, RestrictionAttributeName, Hierarchy, HierarchySettings, OutputPathShape, TimeOfDay, OutputLayer };

		/// <summary>
		/// <para>Input Analysis Network</para>
		/// <para>要执行 OD 成本矩阵分析的网络数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNetworkDatasetLayer()]
		public object InNetworkDataset { get; set; }

		/// <summary>
		/// <para>Output Layer Name</para>
		/// <para>要创建的 OD 成本矩阵网络分析图层的名称。</para>
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
		/// <para>Default Cutoff</para>
		/// <para>中断为指定起始点搜索目的地时对应的默认阻抗值。如果累积的阻抗大于中断值，则停止遍历。可通过指定起始点的中断值来覆盖此默认值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object DefaultCutoff { get; set; }

		/// <summary>
		/// <para>Default Number of Destinations to Find</para>
		/// <para>要为每个起始点查找的默认目的地数。可通过为起始点的 TargetDestinationCount 属性指定一个值来覆盖默认值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object DefaultNumberDestinationsToFind { get; set; }

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
		/// <para>Hierarchy Rank Settings</para>
		/// <para>在版本 10 之前，可使用此参数将网络数据集中建立的默认等级范围更改为其他范围以用于分析。而版本 10 中不再支持此参数。要更改等级范围以进行分析，请更新网络数据集中的默认等级范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPNAHierarchySettings()]
		[Category("Hierarchy")]
		public object HierarchySettings { get; set; }

		/// <summary>
		/// <para>Output Path Shape</para>
		/// <para>无线—将不会为输出路径生成任何形状。这在存在大量的起始点和目的地，但您只对 OD 成本矩阵表（而不是输出线的形状）感兴趣时很有用。</para>
		/// <para>直线—输出路径形状是介于各个起始点-目的地对之间的直线（单线）。</para>
		/// <para>无论选择何种输出形状类型，最佳路径始终由网络阻抗（而非欧氏距离）决定。这表示只是路径形状不同，而对网络进行的基础遍历则相同。</para>
		/// <para><see cref="OutputPathShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Options")]
		public object OutputPathShape { get; set; } = "STRAIGHT_LINES";

		/// <summary>
		/// <para>Start Time</para>
		/// <para>指示从起始点出发的时间。</para>
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
		public MakeODCostMatrixLayer SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

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
			/// <para>无线—将不会为输出路径生成任何形状。这在存在大量的起始点和目的地，但您只对 OD 成本矩阵表（而不是输出线的形状）感兴趣时很有用。</para>
			/// </summary>
			[GPValue("NO_LINES")]
			[Description("无线")]
			No_lines,

			/// <summary>
			/// <para>直线—输出路径形状是介于各个起始点-目的地对之间的直线（单线）。</para>
			/// </summary>
			[GPValue("STRAIGHT_LINES")]
			[Description("直线")]
			Straight_lines,

		}

#endregion
	}
}
