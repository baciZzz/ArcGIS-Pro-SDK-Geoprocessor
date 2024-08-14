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
	/// <para>Automates the process and trains a machine learning model to produce a deep learning package (.dlpk file). This includes exploratory data analysis, feature selection, feature engineering, model selection, hyperparameter tuning, and model training. Its outputs include performance metrics of the best model on the training data, as well as the trained  .dlpk model that can be used to predict on a compatible new dataset using the Predict Using AutoML tool.</para>
	/// </summary>
	public class TrainUsingAutoML : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Training Features</para>
		/// <para>The input feature class that will be used to train the model.</para>
		/// </param>
		/// <param name="OutModel">
		/// <para>Output Model</para>
		/// <para>The output trained model that will be saved as a deep learning package (.dlpk file).</para>
		/// </param>
		/// <param name="VariablePredict">
		/// <para>Variable to Predict</para>
		/// <para>A field from the Input Training Features parameter value that contains the values that will be used to train the model. This field contains known (training) values of the variable that will be used to predict at unknown locations.</para>
		/// </param>
		public TrainUsingAutoML(object InFeatures, object OutModel, object VariablePredict)
		{
			this.InFeatures = InFeatures;
			this.OutModel = OutModel;
			this.VariablePredict = VariablePredict;
		}

		/// <summary>
		/// <para>Tool Display Name : Train Using AutoML</para>
		/// </summary>
		public override string DisplayName => "Train Using AutoML";

		/// <summary>
		/// <para>Tool Name : TrainUsingAutoML</para>
		/// </summary>
		public override string ToolName => "TrainUsingAutoML";

		/// <summary>
		/// <para>Tool Excute Name : geoai.TrainUsingAutoML</para>
		/// </summary>
		public override string ExcuteName => "geoai.TrainUsingAutoML";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAI Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "GeoAI Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoai</para>
		/// </summary>
		public override string ToolboxAlise => "geoai";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "geographicTransformations", "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutModel, VariablePredict, TreatVariableAsCategorical!, ExplanatoryVariables!, DistanceFeatures!, ExplanatoryRasters!, TotalTimeLimit!, AutomlMode!, Algorithms!, ValidationPercent!, OutReport!, OutImportance!, OutFeatures! };

		/// <summary>
		/// <para>Input Training Features</para>
		/// <para>The input feature class that will be used to train the model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Model</para>
		/// <para>The output trained model that will be saved as a deep learning package (.dlpk file).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutModel { get; set; }

		/// <summary>
		/// <para>Variable to Predict</para>
		/// <para>A field from the Input Training Features parameter value that contains the values that will be used to train the model. This field contains known (training) values of the variable that will be used to predict at unknown locations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object VariablePredict { get; set; }

		/// <summary>
		/// <para>Treat Variable as Categorical</para>
		/// <para>Specifies whether the Variable to Predict parameter value will be treated as a categorical variable.</para>
		/// <para>Checked—The Variable to Predict parameter value will be treated as a categorical variable and the tool will perform classification.</para>
		/// <para>Unchecked—The Variable to Predict parameter value will be treated as continuous and the tool will perform regression. This is the default.</para>
		/// <para><see cref="TreatVariableAsCategoricalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? TreatVariableAsCategorical { get; set; } = "false";

		/// <summary>
		/// <para>Explanatory Training Variables</para>
		/// <para>A list of fields representing the explanatory variables that will help predict the value or category of the Variable to Predict parameter value. Check the accompanying check box for any variables that represent classes or categories (such as land cover, presence, or absence).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? ExplanatoryVariables { get; set; }

		/// <summary>
		/// <para>Explanatory Training Distance Features</para>
		/// <para>The features whose distances from the input training features will be estimated automatically and added as more explanatory variables. Distances will be calculated from each of the input explanatory training distance features to the nearest input training features. Point and polygon features are supported, and if the input explanatory training distance features are polygons, the distance attributes will be calculated as the distance between the closest segments of the pair of features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		public object? DistanceFeatures { get; set; }

		/// <summary>
		/// <para>Explanatory Training Rasters</para>
		/// <para>The rasters whose values will be extracted from the raster and considered as explanatory variables for the model. Each layer forms one explanatory variable. For each feature in the input training features, the value of the raster cell will be extracted at that exact location. Bilinear raster resampling will be used when extracting the raster value for continuous rasters. Nearest neighbor assignment will be used when extracting a raster value from categorical rasters. Check the Categorical check box for any raster that represent classes or categories such as land cover, presence, or absence.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? ExplanatoryRasters { get; set; }

		/// <summary>
		/// <para>Total Time Limit (Minutes)</para>
		/// <para>The total time limit in minutes it takes for AutoML model training. The default is 60 (1 hour).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? TotalTimeLimit { get; set; } = "60";

		/// <summary>
		/// <para>AutoML Mode</para>
		/// <para>Specifies the goal of AutoML and how intensive the AutoML search will be.</para>
		/// <para>Basic—Basic is used to explain the significance of the different variables and the data. Feature engineering, feature selection, and hyperparameter tuning will not be performed. Full descriptions and explanations for model learning curves, feature importance plots generated for tree-based models, and SHAP plots for all other models will be included in reports. This mode takes the least amount of processing time. This is the default.</para>
		/// <para>Intermediate—Intermediate is used to train a model that will be used in real-life use cases. It uses 5-fold cross validation (CV) and produces output of learning curves and importance plots in the reports, but SHAP plots are not available.</para>
		/// <para>Advanced— Advanced is used for machine learning competitions (for maximum performance). This mode uses 10-fold cross validation (CV) and performs feature engineering, feature selection, and hyperparameter tuning. In this mode, input training features are assigned to multiple spatial grids of different sizes based on their location, and the corresponding grid IDs are passed as additional categorical explanatory variables to the model. The report only includes learning curves and model explainability is not available.</para>
		/// <para><see cref="AutomlModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? AutomlMode { get; set; } = "BASIC";

		/// <summary>
		/// <para>Algorithms</para>
		/// <para>Specifies the algorithms that will be used during the training.</para>
		/// <para>Linear—The Linear regression supervised algorithm will be used to train a regression machine learning model. In case only linear model is chosen then make sure that the total number of records are less than 10000 and number of columns less than 1000. Other models can handle larger datasets and hence it is suggested to use Linear model as one of the many models and not as a standalone model while running the tool.</para>
		/// <para>Random Forest—The Random Forest decision tree-based supervised machine learning algorithm will be used. It can be used for both classification and regression.</para>
		/// <para>XGBoost—The XGBoost (extreme gradient boosting) supervised machine learning algorithm will be used. It can be used for both classification and regression.</para>
		/// <para>Light GBM—The Light GBM gradient boosting ensemble algorithm, which is based on decision trees, will be used. It can be used for both classification and regression. Light GBM is optimized for high performance with distributed systems.</para>
		/// <para>Decision Tree— The Decision Tree supervised machine learning algorithm, which classifies or regresses the data using true and false answers to certain questions, will be used. Decision trees are easily understood and are good for explainability.</para>
		/// <para>Extra Tree— The Extra Tree (extremely randomized trees) ensemble supervised machine learning algorithm, which uses decision trees, will be used. This method is similar to Random Forests but can be faster.</para>
		/// <para>By default, all of the algorithms will be used.</para>
		/// <para><see cref="AlgorithmsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? Algorithms { get; set; }

		/// <summary>
		/// <para>Validation Percentage</para>
		/// <para>The percentage of input data that will be used for validation. The default value is 10.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Advanced Options")]
		public object? ValidationPercent { get; set; } = "10";

		/// <summary>
		/// <para>Output Report</para>
		/// <para>Specifies the output report that will be generated as a HTML file. If the path provided is not empty then the report will be created inside a new folder under the provided path. The report will contain details of the various models as well as details of the hyperparameters that were used during the evaluation and the performance of each model. Hyperparameters are parameters that control the training process. They are not updated during training and include model architecture, learning rate, number of epochs, and so on.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[Category("Additional Outputs")]
		public object? OutReport { get; set; }

		/// <summary>
		/// <para>Output Importance Table</para>
		/// <para>An output table containing information about the importance of each explanatory variable (fields, distance features, and rasters) used in the model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Additional Outputs")]
		public object? OutImportance { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature layer containing the predicted values by the best performing model on the training feature layer. It can be used to verify model performance by visually comparing the predicted values with the ground truth.</para>
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
			/// <para>Checked—The Variable to Predict parameter value will be treated as a categorical variable and the tool will perform classification.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CATEGORICAL")]
			CATEGORICAL,

			/// <summary>
			/// <para>Unchecked—The Variable to Predict parameter value will be treated as continuous and the tool will perform regression. This is the default.</para>
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
			/// <para>Basic—Basic is used to explain the significance of the different variables and the data. Feature engineering, feature selection, and hyperparameter tuning will not be performed. Full descriptions and explanations for model learning curves, feature importance plots generated for tree-based models, and SHAP plots for all other models will be included in reports. This mode takes the least amount of processing time. This is the default.</para>
			/// </summary>
			[GPValue("BASIC")]
			[Description("Basic")]
			Basic,

			/// <summary>
			/// <para>Intermediate—Intermediate is used to train a model that will be used in real-life use cases. It uses 5-fold cross validation (CV) and produces output of learning curves and importance plots in the reports, but SHAP plots are not available.</para>
			/// </summary>
			[GPValue("INTERMEDIATE")]
			[Description("Intermediate")]
			Intermediate,

			/// <summary>
			/// <para>Advanced— Advanced is used for machine learning competitions (for maximum performance). This mode uses 10-fold cross validation (CV) and performs feature engineering, feature selection, and hyperparameter tuning. In this mode, input training features are assigned to multiple spatial grids of different sizes based on their location, and the corresponding grid IDs are passed as additional categorical explanatory variables to the model. The report only includes learning curves and model explainability is not available.</para>
			/// </summary>
			[GPValue("ADVANCED")]
			[Description("Advanced")]
			Advanced,

		}

		/// <summary>
		/// <para>Algorithms</para>
		/// </summary>
		public enum AlgorithmsEnum 
		{
			/// <summary>
			/// <para>Random Forest—The Random Forest decision tree-based supervised machine learning algorithm will be used. It can be used for both classification and regression.</para>
			/// </summary>
			[GPValue("RANDOM FOREST")]
			[Description("Random Forest")]
			Random_Forest,

			/// <summary>
			/// <para>XGBoost—The XGBoost (extreme gradient boosting) supervised machine learning algorithm will be used. It can be used for both classification and regression.</para>
			/// </summary>
			[GPValue("XGBOOST")]
			[Description("XGBoost")]
			XGBoost,

			/// <summary>
			/// <para>Light GBM—The Light GBM gradient boosting ensemble algorithm, which is based on decision trees, will be used. It can be used for both classification and regression. Light GBM is optimized for high performance with distributed systems.</para>
			/// </summary>
			[GPValue("LIGHT GBM")]
			[Description("Light GBM")]
			Light_GBM,

			/// <summary>
			/// <para>Decision Tree— The Decision Tree supervised machine learning algorithm, which classifies or regresses the data using true and false answers to certain questions, will be used. Decision trees are easily understood and are good for explainability.</para>
			/// </summary>
			[GPValue("DECISION TREE")]
			[Description("Decision Tree")]
			Decision_Tree,

			/// <summary>
			/// <para>Extra Tree— The Extra Tree (extremely randomized trees) ensemble supervised machine learning algorithm, which uses decision trees, will be used. This method is similar to Random Forests but can be faster.</para>
			/// </summary>
			[GPValue("EXTRA TREE")]
			[Description("Extra Tree")]
			Extra_Tree,

			/// <summary>
			/// <para>Linear—The Linear regression supervised algorithm will be used to train a regression machine learning model. In case only linear model is chosen then make sure that the total number of records are less than 10000 and number of columns less than 1000. Other models can handle larger datasets and hence it is suggested to use Linear model as one of the many models and not as a standalone model while running the tool.</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("Linear")]
			Linear,

		}

#endregion
	}
}
