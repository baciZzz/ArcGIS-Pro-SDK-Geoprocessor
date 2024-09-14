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
	/// <para>Forest-based Classification and Regression</para>
	/// <para>Creates models and generates predictions using an adaptation of Leo Breiman's random forest algorithm, which is a supervised machine learning method. Predictions can be performed for both categorical variables (classification) and continuous variables (regression). Explanatory variables can take the form of fields in the attribute table of the training features. In addition to validation of model performance based on the training data, predictions can be made to features.</para>
	/// </summary>
	public class Forest : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="PredictionType">
		/// <para>Prediction Type</para>
		/// <para>Specifies the operation mode of the tool. The tool can be run to train a model to only assess performance, predict features, or create a prediction surface.</para>
		/// <para>Train only—A model will be trained, but no predictions will be generated. Use this option to assess the accuracy of your model before generating predictions. This option will output model diagnostics in the messages window and a chart of variable importance. This is the default</para>
		/// <para>Train and Predict—Predictions or classifications will be generated for features. Explanatory variables must be provided for both the training features and the features to be predicted. The output of this option will be a feature class, model diagnostics in the messages window, and an optional table of variable importance.</para>
		/// <para><see cref="PredictionTypeEnum"/></para>
		/// </param>
		/// <param name="InFeatures">
		/// <para>Input Training Features</para>
		/// <para>The layercontaining the Variable to Predict parameter and the explanatory training variables fields.</para>
		/// </param>
		/// <param name="OutputTrainedName">
		/// <para>Output Features Name</para>
		/// <para>The output feature layer name.</para>
		/// </param>
		/// <param name="VariablePredict">
		/// <para>Variable to Predict</para>
		/// <para>The variable from the Input Training Features parameter containing the values to be used to train the model. This field contains known (training) values of the variable that will be used to predict at unknown locations.</para>
		/// </param>
		public Forest(object PredictionType, object InFeatures, object OutputTrainedName, object VariablePredict)
		{
			this.PredictionType = PredictionType;
			this.InFeatures = InFeatures;
			this.OutputTrainedName = OutputTrainedName;
			this.VariablePredict = VariablePredict;
		}

		/// <summary>
		/// <para>Tool Display Name : Forest-based Classification and Regression</para>
		/// </summary>
		public override string DisplayName() => "Forest-based Classification and Regression";

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
		public override object[] Parameters() => new object[] { PredictionType, InFeatures, OutputTrainedName, VariablePredict, TreatVariableAsCategorical!, ExplanatoryVariables!, CreateVariableImportanceTable!, FeaturesToPredict!, ExplanatoryVariableMatching!, NumberOfTrees!, MinimumLeafSize!, MaximumTreeDepth!, SampleSize!, RandomVariables!, PercentageForValidation!, DataStore!, OutputTrained!, VariableOfImportance!, OutputPredicted! };

		/// <summary>
		/// <para>Prediction Type</para>
		/// <para>Specifies the operation mode of the tool. The tool can be run to train a model to only assess performance, predict features, or create a prediction surface.</para>
		/// <para>Train only—A model will be trained, but no predictions will be generated. Use this option to assess the accuracy of your model before generating predictions. This option will output model diagnostics in the messages window and a chart of variable importance. This is the default</para>
		/// <para>Train and Predict—Predictions or classifications will be generated for features. Explanatory variables must be provided for both the training features and the features to be predicted. The output of this option will be a feature class, model diagnostics in the messages window, and an optional table of variable importance.</para>
		/// <para><see cref="PredictionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PredictionType { get; set; } = "TRAIN";

		/// <summary>
		/// <para>Input Training Features</para>
		/// <para>The layercontaining the Variable to Predict parameter and the explanatory training variables fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRecordSet()]
		[GPTablesDomain()]
		[PortalType("DataStoreCatalogLayer")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Features Name</para>
		/// <para>The output feature layer name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputTrainedName { get; set; }

		/// <summary>
		/// <para>Variable to Predict</para>
		/// <para>The variable from the Input Training Features parameter containing the values to be used to train the model. This field contains known (training) values of the variable that will be used to predict at unknown locations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object VariablePredict { get; set; }

		/// <summary>
		/// <para>Treat Variable as Categorical</para>
		/// <para>Specifies whether Variable to Predict is a categorical variable.</para>
		/// <para>Checked—Variable to Predict is a categorical variable and the tool will perform classification.</para>
		/// <para>Unchecked—Variable to Predict is continuous and the tool will perform regression. This is the default.</para>
		/// <para><see cref="TreatVariableAsCategoricalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? TreatVariableAsCategorical { get; set; }

		/// <summary>
		/// <para>Explanatory Variables</para>
		/// <para>A list of fields representing the explanatory variables that help predict the value or category of Variable to Predict. Check the Categorical check box for any variables that represent classes or categories (such as land cover or presence or absence).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? ExplanatoryVariables { get; set; }

		/// <summary>
		/// <para>Create Variable Importance Table</para>
		/// <para>Specifies whether the output table will contain information describing the importance of each explanatory variable used in the model.</para>
		/// <para>Checked—The output table will contain information for each explanatory variable.</para>
		/// <para>Unchecked—The output table will not contain information for each explanatory variable. This is the default.</para>
		/// <para><see cref="CreateVariableImportanceTableEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Additional Outputs")]
		public object? CreateVariableImportanceTable { get; set; }

		/// <summary>
		/// <para>Input Prediction Features</para>
		/// <para>A feature layer representing locations where predictions will be made. This feature layer must also contain any explanatory variables provided as fields that correspond to those used from the training data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRecordSet()]
		[GPTablesDomain()]
		[PortalType("DataStoreCatalogLayer")]
		public object? FeaturesToPredict { get; set; }

		/// <summary>
		/// <para>Match Explanatory Variables</para>
		/// <para>A list of Explanatory Variables specified from Input Training Features on the right and their corresponding fields from Input Prediction Features on the left.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? ExplanatoryVariableMatching { get; set; }

		/// <summary>
		/// <para>Number of Trees</para>
		/// <para>The number of trees to create in the forest model. More trees will generally result in more accurate model prediction, but the model will take longer to calculate. The default number of trees is 100.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Advanced Forest Options")]
		public object? NumberOfTrees { get; set; } = "100";

		/// <summary>
		/// <para>Minimum Leaf Size</para>
		/// <para>The minimum number of observations required to keep a leaf (that is, the terminal node on a tree without further splits). The default minimum for regression is 5, and the default for classification is 1. For very large data, increasing these numbers will decrease the run time of the tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Advanced Forest Options")]
		public object? MinimumLeafSize { get; set; }

		/// <summary>
		/// <para>Maximum Tree Depth</para>
		/// <para>The maximum number of splits that will be made down a tree. Using a large maximum depth, more splits will be created, which may increase the chances of overfitting the model. The default is data driven and depends on the number of trees created and the number of variables included.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Advanced Forest Options")]
		public object? MaximumTreeDepth { get; set; }

		/// <summary>
		/// <para>Data Available per Tree (%)</para>
		/// <para>The percentage of Input Training Features used for each decision tree. The default is 100 percent of the data. Samples for each tree are taken randomly from two-thirds of the data specified.</para>
		/// <para>Each decision tree in the forest is created using a random sample or subset (approximately two-thirds) of the training data available. Using a lower percentage of the input data for each decision tree increases the speed of the tool for very large datasets.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 100)]
		[Category("Advanced Forest Options")]
		public object? SampleSize { get; set; } = "100";

		/// <summary>
		/// <para>Number of Randomly Sampled Variables</para>
		/// <para>The number of explanatory variables used to create each decision tree.</para>
		/// <para>Each decision tree in the forest is created using a random subset of the explanatory variables specified. Increasing the number of variables used in each decision tree will increase the chances of overfitting your model, particularly if there is one or more dominant variables. A common practice is to use the square root of the total number of explanatory variables if Variable to Predict is numeric, or divide the total number of explanatory variables by 3 if Variable to Predict is categorical.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Advanced Forest Options")]
		public object? RandomVariables { get; set; }

		/// <summary>
		/// <para>Training Data Excluded for Validation (%)</para>
		/// <para>The percentage (between 10 percent and 50 percent) of Input Training Features to reserve as the test dataset for validation. The model will be trained without this random subset of data, and the observed values for those features will be compared to the predicted values. The default is 10 percent.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 50)]
		[Category("Validation Options")]
		public object? PercentageForValidation { get; set; } = "10";

		/// <summary>
		/// <para>Data Store</para>
		/// <para>Specifies the ArcGIS Data Store where the output will be saved. The default is Spatiotemporal big data store. All results stored in a spatiotemporal big data store will be stored in WGS84. Results stored in a relational data store will maintain their coordinate system.</para>
		/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
		/// <para>Relational data store—Output will be stored in a relational data store.</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Data Store")]
		public object? DataStore { get; set; } = "SPATIOTEMPORAL_DATA_STORE";

		/// <summary>
		/// <para>Output Trained Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object? OutputTrained { get; set; }

		/// <summary>
		/// <para>Variable of Importance Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object? VariableOfImportance { get; set; }

		/// <summary>
		/// <para>Output Predicted Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object? OutputPredicted { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Forest SetEnviroment(object? extent = null, object? outputCoordinateSystem = null, object? workspace = null)
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
			/// <para>Train only—A model will be trained, but no predictions will be generated. Use this option to assess the accuracy of your model before generating predictions. This option will output model diagnostics in the messages window and a chart of variable importance. This is the default</para>
			/// </summary>
			[GPValue("TRAIN")]
			[Description("Train only")]
			Train_only,

			/// <summary>
			/// <para>Train and Predict—Predictions or classifications will be generated for features. Explanatory variables must be provided for both the training features and the features to be predicted. The output of this option will be a feature class, model diagnostics in the messages window, and an optional table of variable importance.</para>
			/// </summary>
			[GPValue("TRAIN_AND_PREDICT")]
			[Description("Train and Predict")]
			Train_and_Predict,

		}

		/// <summary>
		/// <para>Treat Variable as Categorical</para>
		/// </summary>
		public enum TreatVariableAsCategoricalEnum 
		{
			/// <summary>
			/// <para>Checked—Variable to Predict is a categorical variable and the tool will perform classification.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CATEGORICAL")]
			CATEGORICAL,

			/// <summary>
			/// <para>Unchecked—Variable to Predict is continuous and the tool will perform regression. This is the default.</para>
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
			/// <para>Checked—The output table will contain information for each explanatory variable.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_TABLE")]
			CREATE_TABLE,

			/// <summary>
			/// <para>Unchecked—The output table will not contain information for each explanatory variable. This is the default.</para>
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
			/// <para>Relational data store—Output will be stored in a relational data store.</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("Relational data store")]
			Relational_data_store,

			/// <summary>
			/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("Spatiotemporal big data store")]
			Spatiotemporal_big_data_store,

		}

#endregion
	}
}
