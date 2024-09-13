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
	/// <para>Forest-based Classification and Regression</para>
	/// <para>基于森林的分类与回归</para>
	/// <para>使用随机森林算法的改编创建模型并生成预测，这是一种由 Leo Breiman 和 Adele Cutler 开发的监督机器学习方法。 可以针对分类变量（分类）和连续变量（回归）执行预测。 解释变量可以采取用于计算邻域分析值的训练要素、栅格数据集和距离要素的属性表中字段的形式，以用作附加变量。 除了基于训练数据对模型性能进行验证之外，还可以对要素或预测栅格进行预测。</para>
	/// </summary>
	public class Forest : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="PredictionType">
		/// <para>Prediction Type</para>
		/// <para>指定工具的操作模式。 可以运行此工具来训练模型，以仅评估性能、预测要素或创建预测表面。</para>
		/// <para>仅训练—将训练模型，但不会生成预测。 生成预测之前，可以使用此选项评估模型的精度。 此选项将在消息窗口和变量重要性图表中输出模型诊断。 这是默认设置</para>
		/// <para>预测至要素—将针对要素生成预测或分类。 必须为训练要素和要预测的要素提供解释变量。 该选项的输出将为要素类、消息窗口中的模型诊断以及变量重要性的可选表格和图表。</para>
		/// <para>预测至栅格—对于解释栅格相交的区域，将生成预测栅格。 必须为训练区域和要预测的区域提供解释栅格。 该选项的输出将为预测表面、消息窗口中的模型诊断以及变量重要性的可选表格和图表。</para>
		/// <para><see cref="PredictionTypeEnum"/></para>
		/// </param>
		/// <param name="InFeatures">
		/// <para>Input Training Features</para>
		/// <para>要素类，包含要预测的变量参数值以及字段中的解释训练变量（可选）。</para>
		/// </param>
		public Forest(object PredictionType, object InFeatures)
		{
			this.PredictionType = PredictionType;
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 基于森林的分类与回归</para>
		/// </summary>
		public override string DisplayName() => "基于森林的分类与回归";

		/// <summary>
		/// <para>Tool Name : Forest</para>
		/// </summary>
		public override string ToolName() => "Forest";

		/// <summary>
		/// <para>Tool Excute Name : stats.Forest</para>
		/// </summary>
		public override string ExcuteName() => "stats.Forest";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "randomGenerator" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { PredictionType, InFeatures, VariablePredict!, TreatVariableAsCategorical!, ExplanatoryVariables!, DistanceFeatures!, ExplanatoryRasters!, FeaturesToPredict!, OutputFeatures!, OutputRaster!, ExplanatoryVariableMatching!, ExplanatoryDistanceMatching!, ExplanatoryRastersMatching!, OutputTrainedFeatures!, OutputImportanceTable!, UseRasterValues!, NumberOfTrees!, MinimumLeafSize!, MaximumDepth!, SampleSize!, RandomVariables!, PercentageForTraining!, OutputClassificationTable!, OutputValidationTable!, CompensateSparseCategories!, NumberValidationRuns!, CalculateUncertainty!, OutputUncertaintyRasterLayers! };

		/// <summary>
		/// <para>Prediction Type</para>
		/// <para>指定工具的操作模式。 可以运行此工具来训练模型，以仅评估性能、预测要素或创建预测表面。</para>
		/// <para>仅训练—将训练模型，但不会生成预测。 生成预测之前，可以使用此选项评估模型的精度。 此选项将在消息窗口和变量重要性图表中输出模型诊断。 这是默认设置</para>
		/// <para>预测至要素—将针对要素生成预测或分类。 必须为训练要素和要预测的要素提供解释变量。 该选项的输出将为要素类、消息窗口中的模型诊断以及变量重要性的可选表格和图表。</para>
		/// <para>预测至栅格—对于解释栅格相交的区域，将生成预测栅格。 必须为训练区域和要预测的区域提供解释栅格。 该选项的输出将为预测表面、消息窗口中的模型诊断以及变量重要性的可选表格和图表。</para>
		/// <para><see cref="PredictionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PredictionType { get; set; } = "TRAIN";

		/// <summary>
		/// <para>Input Training Features</para>
		/// <para>要素类，包含要预测的变量参数值以及字段中的解释训练变量（可选）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Variable to Predict</para>
		/// <para>输入训练要素参数中的变量，其中包含要用于训练模型的值。 该字段包含将用于在未知位置进行预测的变量的已知（训练）值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double", "Float", "Short", "Long", "Text")]
		public object? VariablePredict { get; set; }

		/// <summary>
		/// <para>Treat Variable as Categorical</para>
		/// <para>指定要预测的变量值是否为分类变量。</para>
		/// <para>选中 - 要预测的变量值为分类变量，并且此工具将执行分类。</para>
		/// <para>未选中 - 要预测的变量值为连续变量，并且此工具将执行回归。 这是默认设置。</para>
		/// <para><see cref="TreatVariableAsCategoricalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? TreatVariableAsCategorical { get; set; }

		/// <summary>
		/// <para>Explanatory Training Variables</para>
		/// <para>表示解释变量的字段列表，可帮助预测要预测的变量值的值或类别。 对于任何表示类或类别（例如土地覆被或存在/不存在）的变量，请选中分类复选框。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? ExplanatoryVariables { get; set; }

		/// <summary>
		/// <para>Explanatory Training Distance Features</para>
		/// <para>解释训练距离要素。 通过计算从提供的要素到输入训练要素值的距离，将自动创建解释变量。 将计算每个输入解释训练距离要素值与最近的输入训练要素值的距离。 如果输入解释训练距离要素值为面要素或线要素，则距离属性将计算为要素对的最近线段之间的距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Point", "Polyline")]
		[FeatureType("Simple")]
		public object? DistanceFeatures { get; set; }

		/// <summary>
		/// <para>Explanatory Training Rasters</para>
		/// <para>从栅格中提取的解释训练变量。 解释训练变量将通过提取栅格像元值自动创建。 对于输入训练要素参数中的每个要素，将在此确切位置处提取栅格像元的值。 提取连续栅格的栅格值时，将使用双线性栅格重采样。 从分类栅格中提取栅格值时，将使用最邻近分配法。 对于任何表示类或类别（例如土地覆被或存在/不存在）的栅格，请选中分类复选框。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? ExplanatoryRasters { get; set; }

		/// <summary>
		/// <para>Input Prediction Features</para>
		/// <para>表示将进行预测的位置的要素类。 此要素类还必须包含作为字段提供的任何解释变量，这些字段对应于训练数据中使用的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object? FeaturesToPredict { get; set; }

		/// <summary>
		/// <para>Output Predicted Features</para>
		/// <para>包含预测结果的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutputFeatures { get; set; }

		/// <summary>
		/// <para>Output Prediction Surface</para>
		/// <para>包含预测结果的输出栅格。 默认像元大小将为栅格输入的最大像元大小。 要设置其他像元大小，请使用像元大小环境设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object? OutputRaster { get; set; }

		/// <summary>
		/// <para>Match Explanatory Variables</para>
		/// <para>根据右侧输入训练要素参数以及左侧输入预测要素参数中其对应字段指定的解释变量值的列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? ExplanatoryVariableMatching { get; set; }

		/// <summary>
		/// <para>Match Distance Features</para>
		/// <para>根据右侧输入训练要素参数以及左侧输入预测要素参数中其对应要素指定的解释距离要素值的列表。</para>
		/// <para>如果用于训练的要素位于不同的研究区域或时间段，则可以提供更适用于输入预测要素参数的解释距离要素值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? ExplanatoryDistanceMatching { get; set; }

		/// <summary>
		/// <para>Match Explanatory Rasters</para>
		/// <para>根据右侧输入训练要素参数以及左侧输入预测要素参数或预测表面参数中其对应栅格指定的解释栅格值的列表。</para>
		/// <para>如果用于训练的要素位于不同的研究区域或时间段，则可以提供更适用于输入预测要素参数的解释栅格值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? ExplanatoryRastersMatching { get; set; }

		/// <summary>
		/// <para>Output Trained Features</para>
		/// <para>用于训练（包括采样栅格值和距离计算）的解释变量、观察的要预测的变量字段，以及可用于进一步评估训练模型性能的相应预测。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Additional Outputs")]
		public object? OutputTrainedFeatures { get; set; }

		/// <summary>
		/// <para>Output Variable Importance Table</para>
		/// <para>表格将包含描述在所创建的模型中使用的每个解释变量（字段、距离要素和栅格）的重要性的信息。 基于该表创建的图表可通过内容窗格进行访问。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Additional Outputs")]
		public object? OutputImportanceTable { get; set; }

		/// <summary>
		/// <para>Convert Polygons to Raster Resolution for Training</para>
		/// <para>如果输入训练要素值为面要素（要预测的变量为分类变量），并且仅指定了解释训练栅格值，则训练模型时需要指定面的处理方式。</para>
		/// <para>选中 - 将面划分为所有栅格像元，其中质心落在面范围内。 提取每个质心处的栅格值并将其用于训练模型。 不再基于该面对模型进行训练，而是基于针对每个像元质心提取的栅格值对模型进行训练。 这是默认设置。</para>
		/// <para>未选中 - 为每个面指定基础连续栅格的平均值和基础分类栅格的众数。</para>
		/// <para><see cref="UseRasterValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Forest Options")]
		public object? UseRasterValues { get; set; } = "true";

		/// <summary>
		/// <para>Number of Trees</para>
		/// <para>要在森林模型中创建的树的数量。 增大树数通常将产生更加精确的模型预测，但是将增加模型计算的时间。 默认树数为 100。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 10000000)]
		[Category("Advanced Forest Options")]
		public object? NumberOfTrees { get; set; } = "100";

		/// <summary>
		/// <para>Minimum Leaf Size</para>
		/// <para>保留叶子（即未进一步进行分割的树上的终端节点）所需的最小观测值数。 回归的默认最小值为 5，分类的默认值为 1。 对于非常大的数据，增大这些数值将减少工具的运行时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 10000000)]
		[Category("Advanced Forest Options")]
		public object? MinimumLeafSize { get; set; }

		/// <summary>
		/// <para>Maximum Tree Depth</para>
		/// <para>对树进行的最大分割数。 如果使用较大的最大深度，则将创建更多分割，这可能会增大过度拟合模型的可能性。 默认值由数据驱动，并且取决于所创建的树数以及所包含的变量数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 100000000)]
		[Category("Advanced Forest Options")]
		public object? MaximumDepth { get; set; }

		/// <summary>
		/// <para>Data Available per Tree (%)</para>
		/// <para>用于每棵决策树的输入训练要素值的百分比。 默认值为 100% 的数据。 将根据指定数据的三分之二随机获取每棵树的样本。</para>
		/// <para>可以使用可用训练数据的随机样本或子集（大约三分之二）来创建森林中的每棵决策树。 针对每棵决策树使用较低百分比的输入数据可以提高适用于大型数据集的工具的速度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 100)]
		[Category("Advanced Forest Options")]
		public object? SampleSize { get; set; } = "100";

		/// <summary>
		/// <para>Number of Randomly Sampled Variables</para>
		/// <para>用于创建每棵决策树的解释变量数。</para>
		/// <para>可以使用指定解释变量的随机子集创建森林中的每棵决策树。 增大每棵决策树中使用的变量数将增大过度拟合模型的可能性，尤其是存在一个或多个主导变量时更是如此。 常用方法是：如果要预测的变量值为数值，则使用解释变量（组合字段、距离和栅格）总数的平方根；如果要预测的变量值为分类变量，则将解释变量（组合字段、距离和栅格）的总数除以 3。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 10000000)]
		[Category("Advanced Forest Options")]
		public object? RandomVariables { get; set; }

		/// <summary>
		/// <para>Training Data Excluded for Validation (%)</para>
		/// <para>要保留为验证测试数据集的输入训练要素值的百分比（介于 10% 和 50% 之间）。 将在没有此随机数据子集的情况下对模型进行训练，并将这些要素的观测值与预测值进行比较。 默认值为 10%。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 50)]
		[Category("Validation Options")]
		public object? PercentageForTraining { get; set; } = "10";

		/// <summary>
		/// <para>Output Classification Performance Table (Confusion Matrix)</para>
		/// <para>用于分类汇总所创建模型的性能的混淆矩阵。 除了工具在输出消息中计算的精度和灵敏度测量值之外，此表格还可以用于计算其他诊断。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Additional Outputs")]
		public object? OutputClassificationTable { get; set; }

		/// <summary>
		/// <para>Output  Validation Table</para>
		/// <para>如果验证的运行次数值大于 2，则此表将为每个模型创建 R 2 分布图表。 此分布可用于评估模型的稳定性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Validation Options")]
		public object? OutputValidationTable { get; set; }

		/// <summary>
		/// <para>Compensate for Sparse Categories</para>
		/// <para>指定训练数据集中的每个类别（无论其频率如何）都将在每棵树中表示。</para>
		/// <para>选中 - 每棵树将包括训练数据集中存在的各个类别。</para>
		/// <para>未选中 - 将基于训练数据集中类别的随机样本来创建每棵树。 这是默认设置。</para>
		/// <para><see cref="CompensateSparseCategoriesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Forest Options")]
		public object? CompensateSparseCategories { get; set; }

		/// <summary>
		/// <para>Number of Runs for Validation</para>
		/// <para>工具迭代次数。 可以使用输出验证表参数来显示每次运行的 R2 分布。 设置此选项并生成预测后，仅生成了最高 R 2 值的模型将用于预测。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 10000000)]
		[Category("Validation Options")]
		public object? NumberValidationRuns { get; set; } = "1";

		/// <summary>
		/// <para>Calculate Uncertainty</para>
		/// <para>指定在训练、预测要素或预测栅格时是否计算预测不确定性。</para>
		/// <para>选中 - 将被计算预测不确定性区间。</para>
		/// <para>未选中 - 不计算不确定性。 这是默认设置。</para>
		/// <para><see cref="CalculateUncertaintyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Validation Options")]
		public object? CalculateUncertainty { get; set; } = "false";

		/// <summary>
		/// <para>Output Uncertainty Raster Layers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? OutputUncertaintyRasterLayers { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Forest SetEnviroment(object? cellSize = null , object? mask = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? randomGenerator = null )
		{
			base.SetEnv(cellSize: cellSize, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, randomGenerator: randomGenerator);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Prediction Type</para>
		/// </summary>
		public enum PredictionTypeEnum 
		{
			/// <summary>
			/// <para>仅训练—将训练模型，但不会生成预测。 生成预测之前，可以使用此选项评估模型的精度。 此选项将在消息窗口和变量重要性图表中输出模型诊断。 这是默认设置</para>
			/// </summary>
			[GPValue("TRAIN")]
			[Description("仅训练")]
			Train_only,

			/// <summary>
			/// <para>预测至要素—将针对要素生成预测或分类。 必须为训练要素和要预测的要素提供解释变量。 该选项的输出将为要素类、消息窗口中的模型诊断以及变量重要性的可选表格和图表。</para>
			/// </summary>
			[GPValue("PREDICT_FEATURES")]
			[Description("预测至要素")]
			Predict_to_features,

			/// <summary>
			/// <para>预测至栅格—对于解释栅格相交的区域，将生成预测栅格。 必须为训练区域和要预测的区域提供解释栅格。 该选项的输出将为预测表面、消息窗口中的模型诊断以及变量重要性的可选表格和图表。</para>
			/// </summary>
			[GPValue("PREDICT_RASTER")]
			[Description("预测至栅格")]
			Predict_to_raster,

		}

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
			[Description("NUMERIC")]
			NUMERIC,

		}

		/// <summary>
		/// <para>Convert Polygons to Raster Resolution for Training</para>
		/// </summary>
		public enum UseRasterValuesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("TRUE")]
			TRUE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("FALSE")]
			FALSE,

		}

		/// <summary>
		/// <para>Compensate for Sparse Categories</para>
		/// </summary>
		public enum CompensateSparseCategoriesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("TRUE")]
			TRUE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("FALSE")]
			FALSE,

		}

		/// <summary>
		/// <para>Calculate Uncertainty</para>
		/// </summary>
		public enum CalculateUncertaintyEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("TRUE")]
			TRUE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("FALSE")]
			FALSE,

		}

#endregion
	}
}
