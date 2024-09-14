using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools
{
	/// <summary>
	/// <para>Exploratory Interpolation</para>
	/// <para>探索性插值</para>
	/// <para>可根据输入点要素和字段生成各种插值结果。 然后使用基于交叉验证统计的可定制标准对插值结果进行比较和排序。</para>
	/// </summary>
	public class ExploratoryInterpolation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input features</para>
		/// <para>表示要插值点的位置的输入点。</para>
		/// </param>
		/// <param name="ValueField">
		/// <para>Value field</para>
		/// <para>包含要插值的值的字段。</para>
		/// </param>
		/// <param name="OutCvTable">
		/// <para>Output cross validation table</para>
		/// <para>包含交叉验证统计信息和每个插值结果排名的输出表。 插值结果的最终等级存储在 RANK 字段中。</para>
		/// </param>
		public ExploratoryInterpolation(object InFeatures, object ValueField, object OutCvTable)
		{
			this.InFeatures = InFeatures;
			this.ValueField = ValueField;
			this.OutCvTable = OutCvTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 探索性插值</para>
		/// </summary>
		public override string DisplayName() => "探索性插值";

		/// <summary>
		/// <para>Tool Name : ExploratoryInterpolation</para>
		/// </summary>
		public override string ToolName() => "ExploratoryInterpolation";

		/// <summary>
		/// <para>Tool Excute Name : ga.ExploratoryInterpolation</para>
		/// </summary>
		public override string ExcuteName() => "ga.ExploratoryInterpolation";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise() => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "coincidentPoints", "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, ValueField, OutCvTable, OutGeostatLayer!, InterpMethods!, ComparisonMethod!, Criterion!, CriteriaHierarchy!, WeightedCriteria!, ExclusionCriteria! };

		/// <summary>
		/// <para>Input features</para>
		/// <para>表示要插值点的位置的输入点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Value field</para>
		/// <para>包含要插值的值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ValueField { get; set; }

		/// <summary>
		/// <para>Output cross validation table</para>
		/// <para>包含交叉验证统计信息和每个插值结果排名的输出表。 插值结果的最终等级存储在 RANK 字段中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutCvTable { get; set; }

		/// <summary>
		/// <para>Output geostatistical layer with highest rank</para>
		/// <para>具有最高排名的插值结果的输出地统计图层。 此插值结果将具有输出交叉验证表 RANK 字段中的值 1。 如果具有最高排名的插值结果存在并列或所有结果都被排除标准所排除，即使提供了值也不会创建图层。 如果发生这种情况，该工具将返回警告消息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPGALayer()]
		public object? OutGeostatLayer { get; set; }

		/// <summary>
		/// <para>Interpolation methods</para>
		/// <para>指定将在输入要素和值字段上执行的插值方法。 对于指定的每种方法，将生成 1 到 5 个插值结果。 默认情况下，将生成除反距离加权、径向基函数和全局多项式之外的所有方法（因为这些方法不能产生预测的标准误差）。 默认情况下，将生成 11 个插值结果。 如果指定所有选项，将生成 20 个插值结果。</para>
		/// <para>简单克里金法—将生成四个简单的克里金结果：默认、优化、趋势移除和带趋势移除的转换。</para>
		/// <para>普通克里金法—将生成两个普通的克里金结果：默认和优化。</para>
		/// <para>泛克里金法—将生成两个泛克里金结果：默认和优化。</para>
		/// <para>经验贝叶斯克里金法—将生成两个经验贝叶斯克里金法结果：默认和高级。</para>
		/// <para>局部多项式核插值法—将生成一个默认核（局部多项式）插值结果。</para>
		/// <para>反距离权重法—将生成两个反距离加权结果：默认和优化。</para>
		/// <para>径向基函数插值法—将生成五个径向基函数结果，每个核函数一个。</para>
		/// <para>全局多项式插值法—将生成两个全局多项式插值结果：线性（一阶）和二次（二阶）趋势。</para>
		/// <para><see cref="InterpMethodsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? InterpMethods { get; set; } = "SIMPLE_KRIGING;ORDINARY_KRIGING;UNIVERSAL_KRIGING;EBK;KERNEL_INTERPOLATION";

		/// <summary>
		/// <para>Comparison method</para>
		/// <para>指定将用于比较和排列插值结果的方法。</para>
		/// <para>单一条件—将使用单一标准来比较和排名结果，例如最高预测精度或最低偏差。 使用条件参数中的标准。</para>
		/// <para>具有公差的分级排序—分级排序将用于比较结果。 在条件等级参数中以优先级顺序（最高优先级在前）指定多个条件。 插值结果按第一个标准排序，任何并列情况将使用第二个标准继续区分。 如果第二个标准出现并列，就使用第三个标准继续区分，依此类推。 交叉验证统计数据是连续值，通常没有完全并列的情况，因此可以指定容差（百分比或绝对值）以在每个标准中创建并列情况。</para>
		/// <para>加权平均排名—多个标准的加权平均排名将用于比较结果。 使用加权标准参数指定多个标准和相关的权重。 插值结果按每个标准独立排序，并使用排名的加权平均值来确定最终排名。 权重较大的标准将对最终排名产生更大的影响，因此权重可以用于表示这些标准的优先级高于其他标准。</para>
		/// <para><see cref="ComparisonMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ComparisonMethod { get; set; } = "SINGLE";

		/// <summary>
		/// <para>Criterion</para>
		/// <para>指定将用于对插值结果进行排名的标准。</para>
		/// <para>最高预测精度—结果按最低均方根误差排序。 此选项将衡量交叉验证预测与真实值的平均匹配程度。 这是默认设置。</para>
		/// <para>最低偏差—结果按最接近零的平均误差排列。 此选项测量交叉验证预测高估或低估真实值的平均程度。 具有正平均误差的插值结果系统地高估了真实值（正偏差），而具有负平均误差的结果系统地低估了真实值（负偏差）。</para>
		/// <para>最低最坏情况误差—结果将按最低最大绝对误差排序。 此选项仅测量单个最不准确的交叉验证预测（正向或负向）。 当您最关心的点在于最坏情况而非典型条件下的准确性时，此选项很有用。</para>
		/// <para>最高标准误差精度—结果按最接近一的均方根标准化误差进行排序。 此选项用于测量交叉验证预测的可变性与估计标准误差的匹配程度。 如果您打算为预测创建置信区间或误差范围，此功能很有用。</para>
		/// <para>最高精度—结果将按最低平均标准误差排序。 在为预测值创建置信区间或误差范围时，精度较高的结果将在预测周围具有较窄的区间。 它不衡量标准误差是否估计精确，只衡量标准误差是否很小。 使用此选项时，建议您包括最小和最大均方根标准化误差值作为排除标准，以确保标准误差既准确又精准。</para>
		/// <para><see cref="CriterionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Criterion { get; set; } = "ACCURACY";

		/// <summary>
		/// <para>Criteria hierarchy</para>
		/// <para>将用于具有公差的分级排序的标准等级结构。 按优先顺序提供多个标准，第一个标准是最重要的。 插值结果按第一个标准排序，任何并列情况将使用第二个标准继续区分。 如果第二个标准出现并列，就使用第三个标准继续区分，依此类推。 交叉验证统计数据是连续值，通常没有完全并列的情况，因此可以指定容差以在每个标准中创建并列情况。 对于每一行，在第一列中指定标准，在第二列中指定公差类型（百分比或绝对值），在第三列中指定公差值。 如果没有提供公差值，则不使用公差；这对最后一行最有用，这样插值结果就不会出现排名最高的结果。</para>
		/// <para>对于每一行（每个级别），以下条件可用：</para>
		/// <para>均方根误差（精度）- 结果将按最高精度排序。</para>
		/// <para>平均误差（偏差）- 结果将按最低偏差排序。</para>
		/// <para>最大绝对误差（最坏情况误差）- 结果将按最低最坏情况误差排序。</para>
		/// <para>标准化 RMSE（标准误差精度）- 结果将按最高标准误差精度排序。</para>
		/// <para>平均标准误差（精度） - 结果将按最高精度排序。</para>
		/// <para>例如，您可以在第一行中指定公差为 5% 的均方根误差（精度）值，在第二行中指定不带公差的平均误差（偏差）值。 这些选项将首先按最低均方根误差（最高预测精度）对插值结果进行排序，所有均方根误差值在最准确结果的 5% 以内的插值结果将被视为预测精度并列。 在并列结果中，平均误差最接近零（最低偏差）的结果将获得最高排名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? CriteriaHierarchy { get; set; } = "ACCURACY PERCENT #";

		/// <summary>
		/// <para>Weighted criteria</para>
		/// <para>具有权重的多个标准将用于对插值结果进行排名。 对于每一行，提供一个标准和一个权重。 插值结果将按每个标准独立进行排名，排名的加权平均值将用于确定插值结果的最终排名。</para>
		/// <para>最高预测精度 - 结果将按最低均方根误差排序。</para>
		/// <para>最低误差 - 结果按最接近零的平均误差排列。</para>
		/// <para>最低最坏情况误差 - 结果将按最低最大绝对误差排序。</para>
		/// <para>最高标准误差精度 - 结果按最接近一的均方根标准化误差进行排序。</para>
		/// <para>最高精度 - 结果将按最低平均标准误差排序。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? WeightedCriteria { get; set; } = "ACCURACY 1";

		/// <summary>
		/// <para>Exclusion criteria</para>
		/// <para>将用于从比较中排除插值结果的标准和关联值。 排除的结果将不会获得排名，并将在输出交叉验证表的 Included 字段中具有 No 值。</para>
		/// <para>最大均方根误差 - 如果均方根误差超过指定值，结果将被排除。 该值不能为负。 此选项测量预测精度。</para>
		/// <para>最大绝对误差 - 如果均方根误差超过指定值，结果将被排除。 该值不能为负。 此选项测量最坏情况误差。</para>
		/// <para>最大标准化均方根误差 - 如果均方根误差超过指定值，结果将被排除。 此值必须大于或等于 1。 此选项测量标准误差精度。</para>
		/// <para>最小标准化均方根误差 - 如果均方根误差不超过指定值，结果将被排除。 值必须位于 0 和 1 之间。 此选项测量标准误差精度。</para>
		/// <para>最大平均误差 - 如果平均误差超过指定值，结果将被排除。 该值不能为负。 此选项测量偏差。</para>
		/// <para>最小平均误差 - 如果平均误差不超过指定值，结果将被排除。 值不能为正。 此选项测量偏差。</para>
		/// <para>最大平均标准误差 - 如果平均标准误差超过指定值，结果将被排除。 该值不能为负。 此选项测量精度。</para>
		/// <para>最小误差减少百分比 - 如果插值结果与预测地图中所有位置的全局平均值的基线非空间模型相比不够准确，则将排除结果。 这种相对精度是通过将均方根误差值与被插值点值的标准偏差进行比较来测量的，并且均方根误差必须至少小于要包含在比较中的标准偏差的指定百分比。 例如，值 10 表示均方根误差必须比标准差至少低 10% 才能包含在比较和排名中。 该值必须介于 0 到 100 之间 此选项测量预测精度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? ExclusionCriteria { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExploratoryInterpolation SetEnviroment(object? coincidentPoints = null, object? parallelProcessingFactor = null)
		{
			base.SetEnv(coincidentPoints: coincidentPoints, parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Interpolation methods</para>
		/// </summary>
		public enum InterpMethodsEnum 
		{
			/// <summary>
			/// <para>简单克里金法—将生成四个简单的克里金结果：默认、优化、趋势移除和带趋势移除的转换。</para>
			/// </summary>
			[GPValue("SIMPLE_KRIGING")]
			[Description("简单克里金法")]
			Simple_Kriging,

			/// <summary>
			/// <para>普通克里金法—将生成两个普通的克里金结果：默认和优化。</para>
			/// </summary>
			[GPValue("ORDINARY_KRIGING")]
			[Description("普通克里金法")]
			Ordinary_Kriging,

			/// <summary>
			/// <para>泛克里金法—将生成两个泛克里金结果：默认和优化。</para>
			/// </summary>
			[GPValue("UNIVERSAL_KRIGING")]
			[Description("泛克里金法")]
			Universal_Kriging,

			/// <summary>
			/// <para>经验贝叶斯克里金法—将生成两个经验贝叶斯克里金法结果：默认和高级。</para>
			/// </summary>
			[GPValue("EBK")]
			[Description("经验贝叶斯克里金法")]
			Empirical_Bayesian_Kriging,

			/// <summary>
			/// <para>局部多项式核插值法—将生成一个默认核（局部多项式）插值结果。</para>
			/// </summary>
			[GPValue("KERNEL_INTERPOLATION")]
			[Description("局部多项式核插值法")]
			KERNEL_INTERPOLATION,

			/// <summary>
			/// <para>反距离权重法—将生成两个反距离加权结果：默认和优化。</para>
			/// </summary>
			[GPValue("IDW")]
			[Description("反距离权重法")]
			Inverse_Distance_Weighting,

			/// <summary>
			/// <para>径向基函数插值法—将生成五个径向基函数结果，每个核函数一个。</para>
			/// </summary>
			[GPValue("RBF")]
			[Description("径向基函数插值法")]
			Radial_Basis_Functions,

			/// <summary>
			/// <para>全局多项式插值法—将生成两个全局多项式插值结果：线性（一阶）和二次（二阶）趋势。</para>
			/// </summary>
			[GPValue("GPI")]
			[Description("全局多项式插值法")]
			Global_Polynomial_Interpolation,

		}

		/// <summary>
		/// <para>Comparison method</para>
		/// </summary>
		public enum ComparisonMethodEnum 
		{
			/// <summary>
			/// <para>单一条件—将使用单一标准来比较和排名结果，例如最高预测精度或最低偏差。 使用条件参数中的标准。</para>
			/// </summary>
			[GPValue("SINGLE")]
			[Description("单一条件")]
			Single_criterion,

			/// <summary>
			/// <para>具有公差的分级排序—分级排序将用于比较结果。 在条件等级参数中以优先级顺序（最高优先级在前）指定多个条件。 插值结果按第一个标准排序，任何并列情况将使用第二个标准继续区分。 如果第二个标准出现并列，就使用第三个标准继续区分，依此类推。 交叉验证统计数据是连续值，通常没有完全并列的情况，因此可以指定容差（百分比或绝对值）以在每个标准中创建并列情况。</para>
			/// </summary>
			[GPValue("SORTING")]
			[Description("具有公差的分级排序")]
			Hierarchical_sorting_with_tolerances,

			/// <summary>
			/// <para>加权平均排名—多个标准的加权平均排名将用于比较结果。 使用加权标准参数指定多个标准和相关的权重。 插值结果按每个标准独立排序，并使用排名的加权平均值来确定最终排名。 权重较大的标准将对最终排名产生更大的影响，因此权重可以用于表示这些标准的优先级高于其他标准。</para>
			/// </summary>
			[GPValue("AVERAGE_RANK")]
			[Description("加权平均排名")]
			Weighted_average_rank,

		}

		/// <summary>
		/// <para>Criterion</para>
		/// </summary>
		public enum CriterionEnum 
		{
			/// <summary>
			/// <para>最高预测精度—结果按最低均方根误差排序。 此选项将衡量交叉验证预测与真实值的平均匹配程度。 这是默认设置。</para>
			/// </summary>
			[GPValue("ACCURACY")]
			[Description("最高预测精度")]
			Highest_prediction_accuracy,

			/// <summary>
			/// <para>最低偏差—结果按最接近零的平均误差排列。 此选项测量交叉验证预测高估或低估真实值的平均程度。 具有正平均误差的插值结果系统地高估了真实值（正偏差），而具有负平均误差的结果系统地低估了真实值（负偏差）。</para>
			/// </summary>
			[GPValue("BIAS")]
			[Description("最低偏差")]
			Lowest_bias,

			/// <summary>
			/// <para>最低最坏情况误差—结果将按最低最大绝对误差排序。 此选项仅测量单个最不准确的交叉验证预测（正向或负向）。 当您最关心的点在于最坏情况而非典型条件下的准确性时，此选项很有用。</para>
			/// </summary>
			[GPValue("WORST_CASE")]
			[Description("最低最坏情况误差")]
			WORST_CASE,

			/// <summary>
			/// <para>最高标准误差精度—结果按最接近一的均方根标准化误差进行排序。 此选项用于测量交叉验证预测的可变性与估计标准误差的匹配程度。 如果您打算为预测创建置信区间或误差范围，此功能很有用。</para>
			/// </summary>
			[GPValue("STANDARD_ERROR")]
			[Description("最高标准误差精度")]
			Highest_standard_error_accuracy,

			/// <summary>
			/// <para>最高精度—结果将按最低平均标准误差排序。 在为预测值创建置信区间或误差范围时，精度较高的结果将在预测周围具有较窄的区间。 它不衡量标准误差是否估计精确，只衡量标准误差是否很小。 使用此选项时，建议您包括最小和最大均方根标准化误差值作为排除标准，以确保标准误差既准确又精准。</para>
			/// </summary>
			[GPValue("PRECISION")]
			[Description("最高精度")]
			Highest_precision,

		}

#endregion
	}
}
