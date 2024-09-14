using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialStatisticsTools
{
	/// <summary>
	/// <para>Generate Network Spatial Weights</para>
	/// <para>生成网络空间权重</para>
	/// <para>使用网络数据集构建一个空间权重矩阵文件 (.swm)，从而在基础网络结构方面定义要素空间关系。</para>
	/// </summary>
	[Obsolete()]
	public class GenerateNetworkSpatialWeights : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>要素间网络空间关系的点要素类将被评估。</para>
		/// </param>
		/// <param name="UniqueIDField">
		/// <para>Unique ID Field</para>
		/// <para>包含输入要素类中每个要素不同值的整型字段。如果没有“唯一 ID”字段，则可以创建一个，方法是向要素类表添加一个整型字段，然后将此字段的值计算为与 FID 或 OBJECTID 字段的值相等。</para>
		/// </param>
		/// <param name="OutputSpatialWeightsMatrixFile">
		/// <para>Output Spatial Weights Matrix File</para>
		/// <para>输出网络空间权重矩阵 (.swm) 文件。</para>
		/// </param>
		/// <param name="InputNetwork">
		/// <para>Input Network</para>
		/// <para>将对输入要素类中各要素间空间关系进行定义的网络数据集。网络数据集通常表示街道网络，但也可能表示其他种类的交通网。网络数据集至少需要一个基于时间和一个基于距离的成本属性。</para>
		/// </param>
		/// <param name="ImpedanceAttribute">
		/// <para>Impedance Attribute</para>
		/// <para>在分析中被用作阻抗的成本单位类型。</para>
		/// </param>
		public GenerateNetworkSpatialWeights(object InputFeatureClass, object UniqueIDField, object OutputSpatialWeightsMatrixFile, object InputNetwork, object ImpedanceAttribute)
		{
			this.InputFeatureClass = InputFeatureClass;
			this.UniqueIDField = UniqueIDField;
			this.OutputSpatialWeightsMatrixFile = OutputSpatialWeightsMatrixFile;
			this.InputNetwork = InputNetwork;
			this.ImpedanceAttribute = ImpedanceAttribute;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成网络空间权重</para>
		/// </summary>
		public override string DisplayName() => "生成网络空间权重";

		/// <summary>
		/// <para>Tool Name : GenerateNetworkSpatialWeights</para>
		/// </summary>
		public override string ToolName() => "GenerateNetworkSpatialWeights";

		/// <summary>
		/// <para>Tool Excute Name : stats.GenerateNetworkSpatialWeights</para>
		/// </summary>
		public override string ExcuteName() => "stats.GenerateNetworkSpatialWeights";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise() => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatureClass, UniqueIDField, OutputSpatialWeightsMatrixFile, InputNetwork, ImpedanceAttribute, ImpedanceCutoff, MaximumNumberOfNeighbors, Barriers, UTurnPolicy, Restrictions, UseHierarchyInAnalysis, SearchTolerance, ConceptualizationOfSpatialRelationships, Exponent, RowStandardization, TravelMode, TimeOfDay };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>要素间网络空间关系的点要素类将被评估。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InputFeatureClass { get; set; }

		/// <summary>
		/// <para>Unique ID Field</para>
		/// <para>包含输入要素类中每个要素不同值的整型字段。如果没有“唯一 ID”字段，则可以创建一个，方法是向要素类表添加一个整型字段，然后将此字段的值计算为与 FID 或 OBJECTID 字段的值相等。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object UniqueIDField { get; set; }

		/// <summary>
		/// <para>Output Spatial Weights Matrix File</para>
		/// <para>输出网络空间权重矩阵 (.swm) 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("swm")]
		public object OutputSpatialWeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Input Network</para>
		/// <para>将对输入要素类中各要素间空间关系进行定义的网络数据集。网络数据集通常表示街道网络，但也可能表示其他种类的交通网。网络数据集至少需要一个基于时间和一个基于距离的成本属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNetworkDatasetLayer()]
		public object InputNetwork { get; set; }

		/// <summary>
		/// <para>Impedance Attribute</para>
		/// <para>在分析中被用作阻抗的成本单位类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode Options")]
		public object ImpedanceAttribute { get; set; }

		/// <summary>
		/// <para>Impedance Cutoff</para>
		/// <para>为空间关系的反距离和固定距离概念化指定中断值。使用由阻抗属性参数指定的单位输入此值。</para>
		/// <para>零值表明应未应用任何阈值。此参数留空时，将根据输入要素类范围和要素数量计算默认阈值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Network Analysis Options")]
		public object ImpedanceCutoff { get; set; }

		/// <summary>
		/// <para>Maximum Number of Neighbors</para>
		/// <para>用于表示要为各要素查找的最大相邻要素数的整数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Network Analysis Options")]
		public object MaximumNumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Barriers</para>
		/// <para>一种点要素类的名称，其中的要素用于表示阻塞的路口、封锁的道路、事故现场或网络中行程被阻止的其他位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon", "Polyline")]
		[FeatureType("Simple")]
		[Category("Network Analysis Options")]
		public object Barriers { get; set; }

		/// <summary>
		/// <para>U-turn Policy</para>
		/// <para>指定可选的 U 形转弯限制。</para>
		/// <para>允许 U 形转弯—U 形转弯可以出现在任何位置。这是默认设置。</para>
		/// <para>禁止 U 形转弯—导航过程中不允许有任何 U 形转弯。</para>
		/// <para>仅在死角处允许 U 形转弯—U 形转弯仅允许出现在死角（即单价交汇点）。</para>
		/// <para>仅在死角和交点处允许 U 形转弯—U 形转弯仅允许出现在死角和交点处。</para>
		/// <para><see cref="UTurnPolicyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode Options")]
		public object UTurnPolicy { get; set; } = "ALLOW_UTURNS";

		/// <summary>
		/// <para>Restrictions</para>
		/// <para>限制列表。选中在计算空间关系时要遵守的限制。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode Options")]
		public object Restrictions { get; set; }

		/// <summary>
		/// <para>Use Hierarchy in Analysis</para>
		/// <para>指定是否在分析中使用等级。</para>
		/// <para>选中 - 将在启发式路径算法中使用网络数据集的等级属性来加速分析过程。</para>
		/// <para>未选中 - 将改为使用精确的路径算法。如果不存在等级属性，此选项不影响分析。</para>
		/// <para><see cref="UseHierarchyInAnalysisEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Custom Travel Mode Options")]
		public object UseHierarchyInAnalysis { get; set; } = "false";

		/// <summary>
		/// <para>Search Tolerance</para>
		/// <para>在网络数据集的输入要素类中查找要素时使用的搜索阈值。该参数包括搜索值和容差单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Network Analysis Options")]
		public object SearchTolerance { get; set; } = "5000 Meters";

		/// <summary>
		/// <para>Conceptualization of Spatial Relationships</para>
		/// <para>指明如何指定与每个空间关系关联的加权方式。</para>
		/// <para>反向—远处要素的权重比近处要素的权重小。</para>
		/// <para>固定—阻抗中断之内的要素是相邻要素（权重为 1）；阻抗中断之外的要素没有加权（权重为 0）。</para>
		/// <para><see cref="ConceptualizationOfSpatialRelationshipsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Weights Options")]
		public object ConceptualizationOfSpatialRelationships { get; set; } = "INVERSE";

		/// <summary>
		/// <para>Exponent</para>
		/// <para>空间关系概念计算的反距离参数。典型值是 1 或 2。在此指数值增大时，权重会随着距离的增加快速下降。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Weights Options")]
		public object Exponent { get; set; } = "1";

		/// <summary>
		/// <para>Row Standardization</para>
		/// <para>指定是否应用行标准化。当要素的分布由于采样设计或施加的聚合方案而可能出现偏离时，建议使用行标准化。</para>
		/// <para>选中 - 按行对空间权重执行标准化。每个权重都除以它的行总和。</para>
		/// <para>取消选中 - 不对空间权重执行标准化。</para>
		/// <para><see cref="RowStandardizationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Weights Options")]
		public object RowStandardization { get; set; } = "true";

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>用于分析的交通模式。始终选择自定义。要显示其他出行模式，必须使其显示在网络数据集参数指定的网络数据集中。</para>
		/// <para>出行模式是在网络数据集上定义的，并会提供模型车、货车、步行或其他出行模式的参数的覆盖值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TravelMode { get; set; }

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>指定行驶时间是否应该考虑交通状况。尤其是城市化地区的交通状况，可以显著影响指定行驶时间内涉及的区域。如果未指定日期或时间，在某一特定行驶时间内行驶的距离将不受交通影响。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Network Analysis Options")]
		public object TimeOfDay { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateNetworkSpatialWeights SetEnviroment(object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>U-turn Policy</para>
		/// </summary>
		public enum UTurnPolicyEnum 
		{
			/// <summary>
			/// <para>允许 U 形转弯—U 形转弯可以出现在任何位置。这是默认设置。</para>
			/// </summary>
			[GPValue("ALLOW_UTURNS")]
			[Description("允许 U 形转弯")]
			ALLOW_UTURNS,

			/// <summary>
			/// <para>禁止 U 形转弯—导航过程中不允许有任何 U 形转弯。</para>
			/// </summary>
			[GPValue("NO_UTURNS")]
			[Description("禁止 U 形转弯")]
			NO_UTURNS,

			/// <summary>
			/// <para>仅在死角处允许 U 形转弯—U 形转弯仅允许出现在死角（即单价交汇点）。</para>
			/// </summary>
			[GPValue("ALLOW_DEAD_ENDS_ONLY")]
			[Description("仅在死角处允许 U 形转弯")]
			ALLOW_DEAD_ENDS_ONLY,

			/// <summary>
			/// <para>仅在死角和交点处允许 U 形转弯—U 形转弯仅允许出现在死角和交点处。</para>
			/// </summary>
			[GPValue("ALLOW_DEAD_ENDS_AND_INTERSECTIONS_ONLY")]
			[Description("仅在死角和交点处允许 U 形转弯")]
			ALLOW_DEAD_ENDS_AND_INTERSECTIONS_ONLY,

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
		/// <para>Conceptualization of Spatial Relationships</para>
		/// </summary>
		public enum ConceptualizationOfSpatialRelationshipsEnum 
		{
			/// <summary>
			/// <para>反向—远处要素的权重比近处要素的权重小。</para>
			/// </summary>
			[GPValue("INVERSE")]
			[Description("反向")]
			Inverse,

			/// <summary>
			/// <para>固定—阻抗中断之内的要素是相邻要素（权重为 1）；阻抗中断之外的要素没有加权（权重为 0）。</para>
			/// </summary>
			[GPValue("FIXED")]
			[Description("固定")]
			Fixed,

		}

		/// <summary>
		/// <para>Row Standardization</para>
		/// </summary>
		public enum RowStandardizationEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ROW_STANDARDIZATION")]
			ROW_STANDARDIZATION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_STANDARDIZATION")]
			NO_STANDARDIZATION,

		}

#endregion
	}
}
