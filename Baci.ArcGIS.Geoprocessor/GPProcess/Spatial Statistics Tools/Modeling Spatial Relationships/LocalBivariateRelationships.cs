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
	/// <para>Local Bivariate Relationships</para>
	/// <para>局部二元关系</para>
	/// <para>使用局部熵分析两个变量以获得统计学显著关系。 根据关系的类型，每个要素被划分为六个类别之一。 输出可用于可视化变量相关的区域，并探索它们在整个研究区域内的关系如何变化。</para>
	/// </summary>
	public class LocalBivariateRelationships : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>包含表示因变量和解释变量值的字段的要素类。</para>
		/// </param>
		/// <param name="DependentVariable">
		/// <para>Dependent Variable</para>
		/// <para>表示因变量值的数字字段。 在对关系进行分类时，解释变量值用于预测因变量值。</para>
		/// </param>
		/// <param name="ExplanatoryVariable">
		/// <para>Explanatory Variable</para>
		/// <para>表示解释变量值的数字字段。 在对关系进行分类时，解释变量值用于预测因变量值。</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>输出要素类，包含所有输入要素，输入要素中的字段表示因变量值、解释变量值、熵得分、伪 p 值，显著性级别、分类关系的类型以及与分类相关的诊断。</para>
		/// </param>
		public LocalBivariateRelationships(object InFeatures, object DependentVariable, object ExplanatoryVariable, object OutputFeatures)
		{
			this.InFeatures = InFeatures;
			this.DependentVariable = DependentVariable;
			this.ExplanatoryVariable = ExplanatoryVariable;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 局部二元关系</para>
		/// </summary>
		public override string DisplayName() => "局部二元关系";

		/// <summary>
		/// <para>Tool Name : LocalBivariateRelationships</para>
		/// </summary>
		public override string ToolName() => "LocalBivariateRelationships";

		/// <summary>
		/// <para>Tool Excute Name : stats.LocalBivariateRelationships</para>
		/// </summary>
		public override string ExcuteName() => "stats.LocalBivariateRelationships";

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
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "parallelProcessingFactor", "randomGenerator" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, DependentVariable, ExplanatoryVariable, OutputFeatures, NumberOfNeighbors!, NumberOfPermutations!, EnableLocalScatterplotPopups!, LevelOfConfidence!, ApplyFalseDiscoveryRateFdrCorrection!, ScalingFactor! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>包含表示因变量和解释变量值的字段的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Dependent Variable</para>
		/// <para>表示因变量值的数字字段。 在对关系进行分类时，解释变量值用于预测因变量值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object DependentVariable { get; set; }

		/// <summary>
		/// <para>Explanatory Variable</para>
		/// <para>表示解释变量值的数字字段。 在对关系进行分类时，解释变量值用于预测因变量值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ExplanatoryVariable { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>输出要素类，包含所有输入要素，输入要素中的字段表示因变量值、解释变量值、熵得分、伪 p 值，显著性级别、分类关系的类型以及与分类相关的诊断。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Number of Neighbors</para>
		/// <para>每个要素周围的邻域数（包括该要素在内），用于测试变量之间的局部关系。 邻域数量必须介于 30 和 1000 之间，默认值为 30。 提供的值应足够大，以检测要素之间的关系，但同时要小到足以识别局部模式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 30, Max = 1000)]
		public object? NumberOfNeighbors { get; set; } = "30";

		/// <summary>
		/// <para>Number of Permutations</para>
		/// <para>指定用于计算每个要素的伪 p 值的排列数。 选择排列数时需要兼顾伪 p 值的精度和所需增加的处理时间。</para>
		/// <para>置换检验次数为 99—如果置换检验次数为 99，则可能的最小伪 p 值为 0.01，其他所有伪 p 值将是该值的倍数。</para>
		/// <para>置换检验次数为 199—如果置换检验次数为 199，则可能的最小伪 p 值为 0.005，其他所有伪 p 值将是该值的数倍。 这是默认设置。</para>
		/// <para>499 次排列—如果置换检验次数为 499，则可能的最小伪 p 值为 0.002，其他所有伪 p 值将是该值的数倍。</para>
		/// <para>999 排列—如果置换检验次数为 999，则可能的最小伪 p 值为 0.001，其他所有伪 p 值将是该值的数倍。</para>
		/// <para><see cref="NumberOfPermutationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object? NumberOfPermutations { get; set; } = "199";

		/// <summary>
		/// <para>Enable Local Scatterplot Pop-ups</para>
		/// <para>指定是否为每个输出要素生成散点图弹出窗口。 每个散点图显示局部邻域中的解释变量（水平轴）和因变量（垂直轴）的值以及可视化关系形式的拟合线或曲线。 shapefile 输出不支持散点图。</para>
		/// <para>选中 - 将为数据集中的每个要素生成局部散点图弹出窗口。 这是默认设置。</para>
		/// <para>未选中 - 将不会生成局部散点图弹出窗口。</para>
		/// <para><see cref="EnableLocalScatterplotPopupsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? EnableLocalScatterplotPopups { get; set; } = "true";

		/// <summary>
		/// <para>Level of Confidence</para>
		/// <para>指定显著关系的假设检验的置信度级别。</para>
		/// <para>90%—置信度为 90％。 这是默认设置。</para>
		/// <para>95%—置信度为 95％。</para>
		/// <para>99%—置信度为 99％。</para>
		/// <para><see cref="LevelOfConfidenceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LevelOfConfidence { get; set; } = "90%";

		/// <summary>
		/// <para>Apply False Discovery Rate (FDR) Correction</para>
		/// <para>指定是否将错误发现率 (FDR) 校正应用于伪 p 值。</para>
		/// <para>选中 - 统计显著性将以 FDR 校正为基础。 这是默认设置。</para>
		/// <para>未选中 - 统计显著性将基于伪 p 值。</para>
		/// <para><see cref="ApplyFalseDiscoveryRateFdrCorrectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? ApplyFalseDiscoveryRateFdrCorrection { get; set; } = "true";

		/// <summary>
		/// <para>Scaling Factor (Alpha)</para>
		/// <para>控制对变量之间微妙关系的灵敏度。 较大的值（更接近于 1）可以检测到相对较弱的关系，而较小的值（接近于 0）将仅检测到强关系。 较小的值对异常值也更稳健。 该值必须介于 0.01 和 1 之间，默认值为 0.5。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0.01, Max = 1)]
		[Category("Advanced Options")]
		public object? ScalingFactor { get; set; } = "0.5";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LocalBivariateRelationships SetEnviroment(object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? randomGenerator = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, randomGenerator: randomGenerator);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Number of Permutations</para>
		/// </summary>
		public enum NumberOfPermutationsEnum 
		{
			/// <summary>
			/// <para>999 排列—如果置换检验次数为 999，则可能的最小伪 p 值为 0.001，其他所有伪 p 值将是该值的数倍。</para>
			/// </summary>
			[GPValue("99")]
			[Description("99")]
			_99,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("199")]
			[Description("199")]
			_199,

			/// <summary>
			/// <para>499 次排列—如果置换检验次数为 499，则可能的最小伪 p 值为 0.002，其他所有伪 p 值将是该值的数倍。</para>
			/// </summary>
			[GPValue("499")]
			[Description("499")]
			_499,

			/// <summary>
			/// <para>999 排列—如果置换检验次数为 999，则可能的最小伪 p 值为 0.001，其他所有伪 p 值将是该值的数倍。</para>
			/// </summary>
			[GPValue("999")]
			[Description("999")]
			_999,

		}

		/// <summary>
		/// <para>Enable Local Scatterplot Pop-ups</para>
		/// </summary>
		public enum EnableLocalScatterplotPopupsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_POPUP")]
			CREATE_POPUP,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_POPUP")]
			NO_POPUP,

		}

		/// <summary>
		/// <para>Level of Confidence</para>
		/// </summary>
		public enum LevelOfConfidenceEnum 
		{
			/// <summary>
			/// <para>90%—置信度为 90％。 这是默认设置。</para>
			/// </summary>
			[GPValue("90%")]
			[Description("90%")]
			_90percent,

			/// <summary>
			/// <para>95%—置信度为 95％。</para>
			/// </summary>
			[GPValue("95%")]
			[Description("95%")]
			_95percent,

			/// <summary>
			/// <para>99%—置信度为 99％。</para>
			/// </summary>
			[GPValue("99%")]
			[Description("99%")]
			_99percent,

		}

		/// <summary>
		/// <para>Apply False Discovery Rate (FDR) Correction</para>
		/// </summary>
		public enum ApplyFalseDiscoveryRateFdrCorrectionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("APPLY_FDR")]
			APPLY_FDR,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FDR")]
			NO_FDR,

		}

#endregion
	}
}
