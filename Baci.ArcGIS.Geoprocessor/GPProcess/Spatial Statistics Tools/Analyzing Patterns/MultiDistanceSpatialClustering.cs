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
	/// <para>Multi-Distance Spatial Cluster Analysis (Ripley's K Function)</para>
	/// <para>多距离空间聚类分析 (Ripley's K 函数)</para>
	/// <para>确定要素（或与要素相关联的值）是否显示某一距离范围内统计意义显著的聚类或离散。</para>
	/// </summary>
	public class MultiDistanceSpatialClustering : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>要对其执行分析的要素类。</para>
		/// </param>
		/// <param name="OutputTable">
		/// <para>Output Table</para>
		/// <para>将要写入分析结果的表。</para>
		/// </param>
		/// <param name="NumberOfDistanceBands">
		/// <para>Number of Distance Bands</para>
		/// <para>针对聚类而递增邻域大小和分析数据集的次数。分别在开始距离和距离增量参数中指定的增量的起点和大小。</para>
		/// </param>
		public MultiDistanceSpatialClustering(object InputFeatureClass, object OutputTable, object NumberOfDistanceBands)
		{
			this.InputFeatureClass = InputFeatureClass;
			this.OutputTable = OutputTable;
			this.NumberOfDistanceBands = NumberOfDistanceBands;
		}

		/// <summary>
		/// <para>Tool Display Name : 多距离空间聚类分析 (Ripley's K 函数)</para>
		/// </summary>
		public override string DisplayName() => "多距离空间聚类分析 (Ripley's K 函数)";

		/// <summary>
		/// <para>Tool Name : MultiDistanceSpatialClustering</para>
		/// </summary>
		public override string ToolName() => "MultiDistanceSpatialClustering";

		/// <summary>
		/// <para>Tool Excute Name : stats.MultiDistanceSpatialClustering</para>
		/// </summary>
		public override string ExcuteName() => "stats.MultiDistanceSpatialClustering";

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
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem", "randomGenerator", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatureClass, OutputTable, NumberOfDistanceBands, ComputeConfidenceEnvelope!, DisplayResultsGraphically!, WeightField!, BeginningDistance!, DistanceIncrement!, BoundaryCorrectionMethod!, StudyAreaMethod!, StudyAreaFeatureClass!, ResultImage! };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>要对其执行分析的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>将要写入分析结果的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutputTable { get; set; }

		/// <summary>
		/// <para>Number of Distance Bands</para>
		/// <para>针对聚类而递增邻域大小和分析数据集的次数。分别在开始距离和距离增量参数中指定的增量的起点和大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 100)]
		public object NumberOfDistanceBands { get; set; } = "10";

		/// <summary>
		/// <para>Compute Confidence Envelope</para>
		/// <para>置信区间通过将要素点（或要素值）随机放在研究区域中计算。随机放置的点/值的数量与要素类中的点的数量相同。每组随机放置都称为“排列”，置信区间就通过这些排列创建。此参数用于选择要使用多少排列来创建置信区间。</para>
		/// <para>0 排列 - 无置信区间—不创建置信区间。</para>
		/// <para>9 排列—随机放置了 9 组点/值。</para>
		/// <para>99 次排列—随机放置了 99 组点/值。</para>
		/// <para>999 次排列—随机放置了 999 组点/值。</para>
		/// <para><see cref="ComputeConfidenceEnvelopeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ComputeConfidenceEnvelope { get; set; } = "0_PERMUTATIONS_-_NO_CONFIDENCE_ENVELOPE";

		/// <summary>
		/// <para>Display Results Graphically</para>
		/// <para>该参数无效，但仍支持向后兼容。</para>
		/// <para><see cref="DisplayResultsGraphicallyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DisplayResultsGraphically { get; set; }

		/// <summary>
		/// <para>Weight Field</para>
		/// <para>数字字段，包含代表每个位置的要素/事件数量的权重。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? WeightField { get; set; }

		/// <summary>
		/// <para>Beginning Distance</para>
		/// <para>开始聚类分析的距离及开始增量的距离。为此参数输入的值应使用“输出坐标系”的单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 9999999)]
		public object? BeginningDistance { get; set; }

		/// <summary>
		/// <para>Distance Increment</para>
		/// <para>每次迭代过程中要递增的距离。分析中使用的距离于开始距离处开始，以距离增量中指定的数量增加。为此参数输入的值应使用“输出坐标系”环境设置的单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 9999999)]
		public object? DistanceIncrement { get; set; }

		/// <summary>
		/// <para>Boundary Correction Method</para>
		/// <para>对于研究区域的边附近要素的相邻点数低估情况进行校正所采用的方法。</para>
		/// <para>无—不应用边校正。但是，如果输入要素类已有点落在研究区域边界之外，则这些点将用于边界附近要素的邻域计数。</para>
		/// <para>模拟外边界值—此方法模拟研究区域外的点，以便边附近的相邻点数不被低估。所模拟点是研究区域边界内边附近的点“镜像”。</para>
		/// <para>缩小分析区域—此方法收缩研究区域，以便某些点可在研究区域边界外被发现。在研究区域外发现的点用于计算相邻点数目，但不可用于聚类分析自身。</para>
		/// <para>Ripley 边校正公式—对于点 i 的邻域中的所有点 (j)，此方法通过检查来了解是否研究区域的边离 i 更近，或者是否 j 离 i 更近。如果 j 更近，则将额外权重提供给点 j。此边校正方法仅适用于形状为方形或矩形的研究区域。</para>
		/// <para><see cref="BoundaryCorrectionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? BoundaryCorrectionMethod { get; set; } = "NONE";

		/// <summary>
		/// <para>Study Area Method</para>
		/// <para>指定要用于研究区域的区域。K 函数对研究区域大小的变化很敏感，因此认真选择此值很重要。</para>
		/// <para>最小外接矩形—指示将使用封闭所有点的最小矩形。</para>
		/// <para>用户提供的研究区域要素类—指示定义研究区域的要素类将在“研究区域要素类”参数中提供。</para>
		/// <para><see cref="StudyAreaMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? StudyAreaMethod { get; set; } = "MINIMUM_ENCLOSING_RECTANGLE";

		/// <summary>
		/// <para>Study Area Feature Class</para>
		/// <para>描绘应在其中分析输入要素类的区域的要素类。仅在研究区域方法参数选择了用户提供的研究区域要素类时需要指定。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object? StudyAreaFeatureClass { get; set; }

		/// <summary>
		/// <para>Result Graph</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPGraph()]
		public object? ResultImage { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MultiDistanceSpatialClustering SetEnviroment(object? geographicTransformations = null, object? outputCoordinateSystem = null, object? randomGenerator = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, randomGenerator: randomGenerator, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Compute Confidence Envelope</para>
		/// </summary>
		public enum ComputeConfidenceEnvelopeEnum 
		{
			/// <summary>
			/// <para>0 排列 - 无置信区间—不创建置信区间。</para>
			/// </summary>
			[GPValue("0_PERMUTATIONS_-_NO_CONFIDENCE_ENVELOPE")]
			[Description("0 排列 - 无置信区间")]
			_0_PERMUTATIONS___NO_CONFIDENCE_ENVELOPE,

			/// <summary>
			/// <para>9 排列—随机放置了 9 组点/值。</para>
			/// </summary>
			[GPValue("9_PERMUTATIONS")]
			[Description("9 排列")]
			_9_permutations,

			/// <summary>
			/// <para>99 次排列—随机放置了 99 组点/值。</para>
			/// </summary>
			[GPValue("99_PERMUTATIONS")]
			[Description("99 次排列")]
			_99_permutations,

			/// <summary>
			/// <para>999 次排列—随机放置了 999 组点/值。</para>
			/// </summary>
			[GPValue("999_PERMUTATIONS")]
			[Description("999 次排列")]
			_999_permutations,

		}

		/// <summary>
		/// <para>Display Results Graphically</para>
		/// </summary>
		public enum DisplayResultsGraphicallyEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DISPLAY_IT")]
			DISPLAY_IT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DISPLAY")]
			NO_DISPLAY,

		}

		/// <summary>
		/// <para>Boundary Correction Method</para>
		/// </summary>
		public enum BoundaryCorrectionMethodEnum 
		{
			/// <summary>
			/// <para>无—不应用边校正。但是，如果输入要素类已有点落在研究区域边界之外，则这些点将用于边界附近要素的邻域计数。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>模拟外边界值—此方法模拟研究区域外的点，以便边附近的相邻点数不被低估。所模拟点是研究区域边界内边附近的点“镜像”。</para>
			/// </summary>
			[GPValue("SIMULATE_OUTER_BOUNDARY_VALUES")]
			[Description("模拟外边界值")]
			Simulate_outer_boundary_values,

			/// <summary>
			/// <para>缩小分析区域—此方法收缩研究区域，以便某些点可在研究区域边界外被发现。在研究区域外发现的点用于计算相邻点数目，但不可用于聚类分析自身。</para>
			/// </summary>
			[GPValue("REDUCE_ANALYSIS_AREA")]
			[Description("缩小分析区域")]
			Reduce_analysis_area,

			/// <summary>
			/// <para>Ripley 边校正公式—对于点 i 的邻域中的所有点 (j)，此方法通过检查来了解是否研究区域的边离 i 更近，或者是否 j 离 i 更近。如果 j 更近，则将额外权重提供给点 j。此边校正方法仅适用于形状为方形或矩形的研究区域。</para>
			/// </summary>
			[GPValue("RIPLEY_EDGE_CORRECTION_FORMULA")]
			[Description("Ripley 边校正公式")]
			RIPLEY_EDGE_CORRECTION_FORMULA,

		}

		/// <summary>
		/// <para>Study Area Method</para>
		/// </summary>
		public enum StudyAreaMethodEnum 
		{
			/// <summary>
			/// <para>最小外接矩形—指示将使用封闭所有点的最小矩形。</para>
			/// </summary>
			[GPValue("MINIMUM_ENCLOSING_RECTANGLE")]
			[Description("最小外接矩形")]
			Minimum_enclosing_rectangle,

			/// <summary>
			/// <para>用户提供的研究区域要素类—指示定义研究区域的要素类将在“研究区域要素类”参数中提供。</para>
			/// </summary>
			[GPValue("USER_PROVIDED_STUDY_AREA_FEATURE_CLASS")]
			[Description("用户提供的研究区域要素类")]
			User_provided_study_area_feature_class,

		}

#endregion
	}
}
