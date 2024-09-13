using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAITools
{
	/// <summary>
	/// <para>Train Using AutoML</para>
	/// <para>使用 AutoML 进行训练</para>
	/// <para>自动化过程并训练机器学习模型以生成深度学习包（.dlpk 文件）。 这包括探索性数据分析、要素选择、要素工程、模型选择、超参数调整和模型训练。 其输出包括训练数据上最佳模型的性能指标，以及可用于通过使用 AutoML 进行预测工具预测兼容新数据集的经训练的 .dlpk 模型。</para>
	/// </summary>
	public class TrainUsingAutoML : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Training Features</para>
		/// <para>将用于训练模型的输入要素类。</para>
		/// </param>
		/// <param name="OutModel">
		/// <para>Output Model</para>
		/// <para>将另存为深度学习包（.dlpk 文件）的输出训练模型。</para>
		/// </param>
		/// <param name="VariablePredict">
		/// <para>Variable to Predict</para>
		/// <para>来自输入训练要素参数值的字段，其中包含将用于训练模型的值。 该字段包含将用于在未知位置进行预测的变量的已知（训练）值。</para>
		/// </param>
		public TrainUsingAutoML(object InFeatures, object OutModel, object VariablePredict)
		{
			this.InFeatures = InFeatures;
			this.OutModel = OutModel;
			this.VariablePredict = VariablePredict;
		}

		/// <summary>
		/// <para>Tool Display Name : 使用 AutoML 进行训练</para>
		/// </summary>
		public override string DisplayName() => "使用 AutoML 进行训练";

		/// <summary>
		/// <para>Tool Name : TrainUsingAutoML</para>
		/// </summary>
		public override string ToolName() => "TrainUsingAutoML";

		/// <summary>
		/// <para>Tool Excute Name : geoai.TrainUsingAutoML</para>
		/// </summary>
		public override string ExcuteName() => "geoai.TrainUsingAutoML";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAI Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAI Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoai</para>
		/// </summary>
		public override string ToolboxAlise() => "geoai";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutModel, VariablePredict, TreatVariableAsCategorical!, ExplanatoryVariables!, DistanceFeatures!, ExplanatoryRasters!, TotalTimeLimit!, AutomlMode!, Algorithms!, ValidationPercent!, OutReport!, OutImportance!, OutFeatures! };

		/// <summary>
		/// <para>Input Training Features</para>
		/// <para>将用于训练模型的输入要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Model</para>
		/// <para>将另存为深度学习包（.dlpk 文件）的输出训练模型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("dlpk", "emd")]
		public object OutModel { get; set; }

		/// <summary>
		/// <para>Variable to Predict</para>
		/// <para>来自输入训练要素参数值的字段，其中包含将用于训练模型的值。 该字段包含将用于在未知位置进行预测的变量的已知（训练）值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object VariablePredict { get; set; }

		/// <summary>
		/// <para>Treat Variable as Categorical</para>
		/// <para>指定要预测的变量参数值是否将被视为分类变量。</para>
		/// <para>选中 - 要预测的变量参数值将被视为分类变量，工具将执行分类。</para>
		/// <para>未选中 - 要预测的变量参数值将被视为连续的，工具将执行回归。 这是默认设置。</para>
		/// <para><see cref="TreatVariableAsCategoricalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? TreatVariableAsCategorical { get; set; } = "false";

		/// <summary>
		/// <para>Explanatory Training Variables</para>
		/// <para>表示解释变量的字段列表，可帮助预测要预测的变量参数值的值或类别。 对于任何表示类或类别（例如土地覆被、存在或不存在）的变量，请选中随附的复选框。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? ExplanatoryVariables { get; set; }

		/// <summary>
		/// <para>Explanatory Training Distance Features</para>
		/// <para>将自动估计该要素与输入训练要素的距离并将其添加为其他解释变量。 将计算每个输入解释训练距离要素与最近的输入训练要素的距离。 支持点和面要素，如果输入解释训练距离要素为面要素或线要素，则距离属性将计算为要素对的最近线段之间的距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		public object? DistanceFeatures { get; set; }

		/// <summary>
		/// <para>Explanatory Training Rasters</para>
		/// <para>将从栅格中提取该栅格的值，并且其将被视为模型的解释变量。 每个图层构成一个解释变量。 对于输入训练要素中的每个要素，将在此确切位置处提取栅格像元的值。 提取连续栅格的栅格值时，将使用双线性栅格重采样。 从分类栅格中提取栅格值时，将使用最邻近分配法。 对于任何表示类或类别（例如土地覆被、存在或不存在）的栅格，请选中分类复选框。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? ExplanatoryRasters { get; set; }

		/// <summary>
		/// <para>Total Time Limit (Minutes)</para>
		/// <para>AutoML 模型训练所需的总时间限制（以分钟为单位）。 默认值为 60（1 小时）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? TotalTimeLimit { get; set; } = "60";

		/// <summary>
		/// <para>AutoML Mode</para>
		/// <para>指定 AutoML 的目标以及 AutoML 搜索的密集程度。</para>
		/// <para>基础—“基本”用于解释不同变量和数据的重要性。 不执行要素工程、要素选择和超参数调整。 报告中将包含关于模型学习曲线、为基于树的模型生成的要素重要性图以及所有其他模型的 SHAP 图的完整描述和解释。 此模式需要的处理时间最少。 这是默认设置。</para>
		/// <para>中级—“中级”用于训练将在实际用例中使用的模型。 它使用 5 倍交叉验证 (CV) 方法并将在报告中生成学习曲线和重要性图的输出，但 SHAP 图不可用。</para>
		/// <para>高级—“高级”用于机器学习竞技（以获得最佳性能）。 此模式使用 10 倍交叉验证 (CV) 方法并将执行要素工程、要素选择和超参数调整。 在这种模式下，将基于输入训练要素的位置将其分配给到多个不同大小的空间格网，并且相应的格网 ID 将作为附加分类解释变量传递给模型。 该报告仅包括学习曲线，模型可解释性功能不可用。</para>
		/// <para><see cref="AutomlModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? AutomlMode { get; set; } = "BASIC";

		/// <summary>
		/// <para>Algorithms</para>
		/// <para>指定将在训练期间使用的算法。</para>
		/// <para>线性—线性回归监督算法将用于训练回归机器学习模型。如果仅选择线性模型，请确保记录总数小于 10000 且列数小于 1000。 其他模型可以处理更大的数据集，因此建议在运行该工具时将线性模型用作众多模型之一，而不是作为独立模型。</para>
		/// <para>随机森林—将使用基于随机森林决策树的监督机器学习算法。 它可以用于分类和回归。</para>
		/// <para>XGBoost—将使用 XGBoost（极端梯度提）监督机器学习算法。 它可以用于分类和回归。</para>
		/// <para>Light GBM—将使用基于决策树的 Light GBM 梯度提升集成算法。 它可以用于分类和回归。 Light GBM 针对分布式系统的高性能进行了优化。</para>
		/// <para>决策树—将使用决策树监督机器学习算法，该算法使用对某些问题的 true 和 false 答案对数据进行分类或回归。 决策树易于理解并且具有可解释性。</para>
		/// <para>极端树—将通过使用决策树的极端树（极度随机树）集成监督机器学习算法。 此方法类似于随机森林，但速度更快。</para>
		/// <para>默认情况下，将使用所有算法。</para>
		/// <para><see cref="AlgorithmsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? Algorithms { get; set; }

		/// <summary>
		/// <para>Validation Percentage</para>
		/// <para>将用于验证的输入数据的百分比。 默认值为 10。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Advanced Options")]
		public object? ValidationPercent { get; set; } = "10";

		/// <summary>
		/// <para>Output Report</para>
		/// <para>指定将生成为 HTML 文件的输出报告。 如果提供的路径不为空，则将在提供路径下的新文件夹中创建报告。 该报告将包含各种模型的详细信息、评估期间使用的超参数的详细信息以及每个模型的性能。 超参数是控制训练过程的参数。 它们在训练期间不会更新，包括模型架构、学习率、时期数等。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("html")]
		[Category("Additional Outputs")]
		public object? OutReport { get; set; }

		/// <summary>
		/// <para>Output Importance Table</para>
		/// <para>输出表包含有关模型中使用的每个解释变量（字段、距离要素和栅格）的重要性的信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Additional Outputs")]
		public object? OutImportance { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含训练要素图层上性能最佳模型的预测值的要素图层。 它可用于通过直观地将预测值与实际地表进行比较来验证模型性能。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Additional Outputs")]
		public object? OutFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TrainUsingAutoML SetEnviroment(object? geographicTransformations = null , object? outputCoordinateSystem = null )
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Treat Variable as Categorical</para>
		/// </summary>
		public enum TreatVariableAsCategoricalEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CATEGORICAL")]
			CATEGORICAL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("CONTINUOUS")]
			CONTINUOUS,

		}

		/// <summary>
		/// <para>AutoML Mode</para>
		/// </summary>
		public enum AutomlModeEnum 
		{
			/// <summary>
			/// <para>基础—“基本”用于解释不同变量和数据的重要性。 不执行要素工程、要素选择和超参数调整。 报告中将包含关于模型学习曲线、为基于树的模型生成的要素重要性图以及所有其他模型的 SHAP 图的完整描述和解释。 此模式需要的处理时间最少。 这是默认设置。</para>
			/// </summary>
			[GPValue("BASIC")]
			[Description("基础")]
			Basic,

			/// <summary>
			/// <para>中级—“中级”用于训练将在实际用例中使用的模型。 它使用 5 倍交叉验证 (CV) 方法并将在报告中生成学习曲线和重要性图的输出，但 SHAP 图不可用。</para>
			/// </summary>
			[GPValue("INTERMEDIATE")]
			[Description("中级")]
			Intermediate,

			/// <summary>
			/// <para>高级—“高级”用于机器学习竞技（以获得最佳性能）。 此模式使用 10 倍交叉验证 (CV) 方法并将执行要素工程、要素选择和超参数调整。 在这种模式下，将基于输入训练要素的位置将其分配给到多个不同大小的空间格网，并且相应的格网 ID 将作为附加分类解释变量传递给模型。 该报告仅包括学习曲线，模型可解释性功能不可用。</para>
			/// </summary>
			[GPValue("ADVANCED")]
			[Description("高级")]
			Advanced,

		}

		/// <summary>
		/// <para>Algorithms</para>
		/// </summary>
		public enum AlgorithmsEnum 
		{
			/// <summary>
			/// <para>随机森林—将使用基于随机森林决策树的监督机器学习算法。 它可以用于分类和回归。</para>
			/// </summary>
			[GPValue("RANDOM FOREST")]
			[Description("随机森林")]
			Random_Forest,

			/// <summary>
			/// <para>XGBoost—将使用 XGBoost（极端梯度提）监督机器学习算法。 它可以用于分类和回归。</para>
			/// </summary>
			[GPValue("XGBOOST")]
			[Description("XGBoost")]
			XGBoost,

			/// <summary>
			/// <para>Light GBM—将使用基于决策树的 Light GBM 梯度提升集成算法。 它可以用于分类和回归。 Light GBM 针对分布式系统的高性能进行了优化。</para>
			/// </summary>
			[GPValue("LIGHT GBM")]
			[Description("Light GBM")]
			Light_GBM,

			/// <summary>
			/// <para>决策树—将使用决策树监督机器学习算法，该算法使用对某些问题的 true 和 false 答案对数据进行分类或回归。 决策树易于理解并且具有可解释性。</para>
			/// </summary>
			[GPValue("DECISION TREE")]
			[Description("决策树")]
			Decision_Tree,

			/// <summary>
			/// <para>极端树—将通过使用决策树的极端树（极度随机树）集成监督机器学习算法。 此方法类似于随机森林，但速度更快。</para>
			/// </summary>
			[GPValue("EXTRA TREE")]
			[Description("极端树")]
			Extra_Tree,

			/// <summary>
			/// <para>线性—线性回归监督算法将用于训练回归机器学习模型。如果仅选择线性模型，请确保记录总数小于 10000 且列数小于 1000。 其他模型可以处理更大的数据集，因此建议在运行该工具时将线性模型用作众多模型之一，而不是作为独立模型。</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("线性")]
			Linear,

		}

#endregion
	}
}
