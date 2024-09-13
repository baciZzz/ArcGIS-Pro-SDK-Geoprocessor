using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsServerTools
{
	/// <summary>
	/// <para>Forest-based Classification and Regression</para>
	/// <para>基于森林的分类与回归</para>
	/// <para>使用 Leo Breiman 随机森林算法（一种监督式机器学习方法）的改编版本创建模型并生成预测。可以针对分类变量（分类）和连续变量（回归）执行预测。解释变量可采用训练要素属性表中字段的形式。除了基于训练数据对模型性能进行验证之外，还可以对要素进行预测。</para>
	/// </summary>
	public class Forest : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="PredictionType">
		/// <para>Prediction Type</para>
		/// <para>指定工具的操作模式。可以运行此工具来训练模型，以仅评估性能、预测要素或创建预测表面。</para>
		/// <para>仅训练—将训练模型，但不会生成预测。生成预测之前，可以使用此选项评估模型的精度。此选项将在消息窗口和变量重要性图表中输出模型诊断。这是默认设置</para>
		/// <para>训练和预测—将针对要素生成预测或分类。必须为训练要素和要预测的要素提供解释变量。该选项的输出将为要素类、消息窗口中的模型诊断以及变量重要性的可选表格。</para>
		/// <para><see cref="PredictionTypeEnum"/></para>
		/// </param>
		/// <param name="InFeatures">
		/// <para>Input Training Features</para>
		/// <para>包含要预测的变量参数以及解释训练变量字段的图层。</para>
		/// </param>
		/// <param name="OutputTrainedName">
		/// <para>Output Features Name</para>
		/// <para>输出要素图层名称。</para>
		/// </param>
		/// <param name="VariablePredict">
		/// <para>Variable to Predict</para>
		/// <para>输入训练要素参数中的变量，其中包含要用于训练模型的值。该字段包含将用于在未知位置进行预测的变量的已知（训练）值。</para>
		/// </param>
		public Forest(object PredictionType, object InFeatures, object OutputTrainedName, object VariablePredict)
		{
			this.PredictionType = PredictionType;
			this.InFeatures = InFeatures;
			this.OutputTrainedName = OutputTrainedName;
			this.VariablePredict = VariablePredict;
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
		/// <para>Tool Excute Name : geoanalytics.Forest</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.Forest";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoanalytics</para>
		/// </summary>
		public override string ToolboxAlise() => "geoanalytics";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { PredictionType, InFeatures, OutputTrainedName, VariablePredict, TreatVariableAsCategorical, ExplanatoryVariables, CreateVariableImportanceTable, FeaturesToPredict, ExplanatoryVariableMatching, NumberOfTrees, MinimumLeafSize, MaximumTreeDepth, SampleSize, RandomVariables, PercentageForValidation, DataStore, OutputTrained, VariableOfImportance, OutputPredicted };

		/// <summary>
		/// <para>Prediction Type</para>
		/// <para>指定工具的操作模式。可以运行此工具来训练模型，以仅评估性能、预测要素或创建预测表面。</para>
		/// <para>仅训练—将训练模型，但不会生成预测。生成预测之前，可以使用此选项评估模型的精度。此选项将在消息窗口和变量重要性图表中输出模型诊断。这是默认设置</para>
		/// <para>训练和预测—将针对要素生成预测或分类。必须为训练要素和要预测的要素提供解释变量。该选项的输出将为要素类、消息窗口中的模型诊断以及变量重要性的可选表格。</para>
		/// <para><see cref="PredictionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PredictionType { get; set; } = "TRAIN";

		/// <summary>
		/// <para>Input Training Features</para>
		/// <para>包含要预测的变量参数以及解释训练变量字段的图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRecordSet()]
		[GPTablesDomain()]
		[PortalType("DataStoreCatalogLayer")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Features Name</para>
		/// <para>输出要素图层名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputTrainedName { get; set; }

		/// <summary>
		/// <para>Variable to Predict</para>
		/// <para>输入训练要素参数中的变量，其中包含要用于训练模型的值。该字段包含将用于在未知位置进行预测的变量的已知（训练）值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object VariablePredict { get; set; }

		/// <summary>
		/// <para>Treat Variable as Categorical</para>
		/// <para>指定要预测的变量是否为分类变量。</para>
		/// <para>选中 - 要预测的变量为分类变量，并且此工具将执行分类。</para>
		/// <para>未选中 - 要预测的变量为连续变量，并且此工具将执行回归。这是默认设置。</para>
		/// <para><see cref="TreatVariableAsCategoricalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object TreatVariableAsCategorical { get; set; }

		/// <summary>
		/// <para>Explanatory Variables</para>
		/// <para>表示解释变量的字段列表，可帮助预测要预测的变量的值或类别。对于任何表示类或类别（例如土地覆被或存在/不存在）的变量，请选中分类复选框。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object ExplanatoryVariables { get; set; }

		/// <summary>
		/// <para>Create Variable Importance Table</para>
		/// <para>指定输出表是否包含描述在模型中使用的每个解释变量的重要性的信息。</para>
		/// <para>选中 - 输出表将包含每个解释变量的信息。</para>
		/// <para>未选中 - 输出表将不包含每个解释变量的信息。这是默认设置。</para>
		/// <para><see cref="CreateVariableImportanceTableEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Additional Outputs")]
		public object CreateVariableImportanceTable { get; set; }

		/// <summary>
		/// <para>Input Prediction Features</para>
		/// <para>表示将进行预测的位置的要素图层。此要素图层还必须包含作为字段提供的任何解释变量，这些字段对应于训练数据中使用的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRecordSet()]
		[GPTablesDomain()]
		[PortalType("DataStoreCatalogLayer")]
		public object FeaturesToPredict { get; set; }

		/// <summary>
		/// <para>Match Explanatory Variables</para>
		/// <para>根据右侧输入训练要素以及左侧输入预测要素中其对应字段指定的解释变量列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object ExplanatoryVariableMatching { get; set; }

		/// <summary>
		/// <para>Number of Trees</para>
		/// <para>要在森林模型中创建的树的数量。增大树数通常将产生更加精确的模型预测，但是将增加模型计算的时间。默认树数为 100。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Advanced Forest Options")]
		public object NumberOfTrees { get; set; } = "100";

		/// <summary>
		/// <para>Minimum Leaf Size</para>
		/// <para>保留叶子（即未进一步进行分割的树上的终端节点）所需的最小观测值数。回归的默认最小值为 5，分类的默认值为 1。对于非常大的数据，增大这些数值将减少工具的运行时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Advanced Forest Options")]
		public object MinimumLeafSize { get; set; }

		/// <summary>
		/// <para>Maximum Tree Depth</para>
		/// <para>对树进行的最大分割数。如果使用较大的最大深度，则将创建更多分割，这可能会增大过度拟合模型的可能性。默认值由数据驱动，并且取决于所创建的树数以及所包含的变量数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Advanced Forest Options")]
		public object MaximumTreeDepth { get; set; }

		/// <summary>
		/// <para>Data Available per Tree (%)</para>
		/// <para>用于每棵决策树的输入训练要素的百分比。默认值为 100% 的数据。将根据指定数据的三分之二随机获取每棵树的样本。</para>
		/// <para>可以使用可用训练数据的随机样本或子集（大约三分之二）来创建森林中的每棵决策树。针对每棵决策树使用较低百分比的输入数据可以提高适用于大型数据集的工具的速度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 100)]
		[Category("Advanced Forest Options")]
		public object SampleSize { get; set; } = "100";

		/// <summary>
		/// <para>Number of Randomly Sampled Variables</para>
		/// <para>用于创建每棵决策树的解释变量数。</para>
		/// <para>森林中的每个决策树都是使用指定解释变量的随机子集创建的。增大每棵决策树中使用的变量数将增大过度拟合模型的可能性，尤其是存在一个或多个主导变量时更是如此。常用方法是：如果要预测的变量为数值，则使用解释变量总数的平方根；如果要预测的变量为分类变量，则将解释变量的总数除以 3。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Advanced Forest Options")]
		public object RandomVariables { get; set; }

		/// <summary>
		/// <para>Training Data Excluded for Validation (%)</para>
		/// <para>要保留为验证测试数据集的输入训练要素的百分比（介于 10% 和 50% 之间）。将在没有此随机数据子集的情况下对模型进行训练，并将这些要素的观测值与预测值进行比较。默认值为 10%。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 50)]
		[Category("Validation Options")]
		public object PercentageForValidation { get; set; } = "10";

		/// <summary>
		/// <para>Data Store</para>
		/// <para>指定将用于保存输出的 ArcGIS Data Store。默认设置为时空大数据存储。在时空大数据存储中存储的所有结果都将存储在 WGS84 中。在关系数据存储中存储的结果都将保持各自的坐标系。</para>
		/// <para>时空大数据存储—输出将存储在时空大数据存储中。这是默认设置。</para>
		/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Data Store")]
		public object DataStore { get; set; } = "SPATIOTEMPORAL_DATA_STORE";

		/// <summary>
		/// <para>Output Trained Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object OutputTrained { get; set; }

		/// <summary>
		/// <para>Variable of Importance Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object VariableOfImportance { get; set; }

		/// <summary>
		/// <para>Output Predicted Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object OutputPredicted { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Forest SetEnviroment(object extent = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Prediction Type</para>
		/// </summary>
		public enum PredictionTypeEnum 
		{
			/// <summary>
			/// <para>仅训练—将训练模型，但不会生成预测。生成预测之前，可以使用此选项评估模型的精度。此选项将在消息窗口和变量重要性图表中输出模型诊断。这是默认设置</para>
			/// </summary>
			[GPValue("TRAIN")]
			[Description("仅训练")]
			Train_only,

			/// <summary>
			/// <para>训练和预测—将针对要素生成预测或分类。必须为训练要素和要预测的要素提供解释变量。该选项的输出将为要素类、消息窗口中的模型诊断以及变量重要性的可选表格。</para>
			/// </summary>
			[GPValue("TRAIN_AND_PREDICT")]
			[Description("训练和预测")]
			Train_and_Predict,

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
		/// <para>Create Variable Importance Table</para>
		/// </summary>
		public enum CreateVariableImportanceTableEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_TABLE")]
			CREATE_TABLE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_TABLE")]
			NO_TABLE,

		}

		/// <summary>
		/// <para>Data Store</para>
		/// </summary>
		public enum DataStoreEnum 
		{
			/// <summary>
			/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("关系数据存储")]
			Relational_data_store,

			/// <summary>
			/// <para>时空大数据存储—输出将存储在时空大数据存储中。这是默认设置。</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("时空大数据存储")]
			Spatiotemporal_big_data_store,

		}

#endregion
	}
}
