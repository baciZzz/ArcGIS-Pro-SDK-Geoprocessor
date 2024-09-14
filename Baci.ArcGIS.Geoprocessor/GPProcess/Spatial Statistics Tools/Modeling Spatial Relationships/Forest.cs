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
	/// <para>Forest-based Classification and Regression</para>
	/// <para>Creates models and generates predictions using an adaptation of Leo Breiman's random forest algorithm, which is a supervised machine learning method. Predictions can be performed for both categorical variables (classification) and continuous variables (regression). Explanatory variables can take the form of fields in the attribute table of the training features, raster datasets, and distance features used to calculate proximity values for use as additional variables. In addition to validation of model performance based on the training data, predictions can be made to either features or a prediction raster.</para>
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
		/// <para>Predict to features—Predictions or classifications will be generated for features. Explanatory variables must be provided for both the training features and the features to be predicted. The output of this option will be a feature class, model diagnostics in the messages window, and an optional table and chart of variable importance.</para>
		/// <para>Predict to raster—A prediction raster will be generated for the area where the explanatory rasters intersect. Explanatory rasters must be provided for both the training area and the area to be predicted. The output of this option will be a prediction surface, model diagnostics in the messages window, and an optional table and chart of variable importance.</para>
		/// <para><see cref="PredictionTypeEnum"/></para>
		/// </param>
		/// <param name="InFeatures">
		/// <para>Input Training Features</para>
		/// <para>The feature class containing the Variable to Predict parameter and, optionally, the explanatory training variables from fields.</para>
		/// </param>
		public Forest(object PredictionType, object InFeatures)
		{
			this.PredictionType = PredictionType;
			this.InFeatures = InFeatures;
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
		public override object[] Parameters() => new object[] { PredictionType, InFeatures, VariablePredict, TreatVariableAsCategorical, ExplanatoryVariables, DistanceFeatures, ExplanatoryRasters, FeaturesToPredict, OutputFeatures, OutputRaster, ExplanatoryVariableMatching, ExplanatoryDistanceMatching, ExplanatoryRastersMatching, OutputTrainedFeatures, OutputImportanceTable, UseRasterValues, NumberOfTrees, MinimumLeafSize, MaximumDepth, SampleSize, RandomVariables, PercentageForTraining, OutputClassificationTable, OutputValidationTable, CompensateSparseCategories, NumberValidationRuns, CalculateUncertainty, OutputUncertaintyRasterLayers };

		/// <summary>
		/// <para>Prediction Type</para>
		/// <para>Specifies the operation mode of the tool. The tool can be run to train a model to only assess performance, predict features, or create a prediction surface.</para>
		/// <para>Train only—A model will be trained, but no predictions will be generated. Use this option to assess the accuracy of your model before generating predictions. This option will output model diagnostics in the messages window and a chart of variable importance. This is the default</para>
		/// <para>Predict to features—Predictions or classifications will be generated for features. Explanatory variables must be provided for both the training features and the features to be predicted. The output of this option will be a feature class, model diagnostics in the messages window, and an optional table and chart of variable importance.</para>
		/// <para>Predict to raster—A prediction raster will be generated for the area where the explanatory rasters intersect. Explanatory rasters must be provided for both the training area and the area to be predicted. The output of this option will be a prediction surface, model diagnostics in the messages window, and an optional table and chart of variable importance.</para>
		/// <para><see cref="PredictionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PredictionType { get; set; } = "TRAIN";

		/// <summary>
		/// <para>Input Training Features</para>
		/// <para>The feature class containing the Variable to Predict parameter and, optionally, the explanatory training variables from fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Variable to Predict</para>
		/// <para>The variable from the Input Training Features parameter containing the values to be used to train the model. This field contains known (training) values of the variable that will be used to predict at unknown locations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Double", "Float", "Short", "Long", "Text")]
		public object VariablePredict { get; set; }

		/// <summary>
		/// <para>Treat Variable as Categorical</para>
		/// <para>Specifies whether the Variable to Predict is a categorical variable.</para>
		/// <para>Checked—The Variable to Predict is a categorical variable and the tool will perform classification.</para>
		/// <para>Unchecked—The Variable to Predict is continuous and the tool will perform regression. This is the default.</para>
		/// <para><see cref="TreatVariableAsCategoricalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object TreatVariableAsCategorical { get; set; }

		/// <summary>
		/// <para>Explanatory Training Variables</para>
		/// <para>A list of fields representing the explanatory variables that help predict the value or category of the Variable to Predict. Check the Categorical check box for any variables that represent classes or categories (such as land cover or presence or absence).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object ExplanatoryVariables { get; set; }

		/// <summary>
		/// <para>Explanatory Training Distance Features</para>
		/// <para>Automatically creates explanatory variables by calculating a distance from the provided features to the Input Training Features. Distances will be calculated from each of the input Explanatory Training Distance Features to the nearest Input Training Features. If the input Explanatory Training Distance Features are polygons or lines, the distance attributes are calculated as the distance between the closest segments of the pair of features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Point", "Polyline")]
		[FeatureType("Simple")]
		public object DistanceFeatures { get; set; }

		/// <summary>
		/// <para>Explanatory Training Rasters</para>
		/// <para>Automatically creates explanatory training variables in your model whose values are extracted from rasters. For each feature in the Input Training Features, the value of the raster cell is extracted at that exact location. Bilinear raster resampling is used when extracting the raster value for continuous rasters. Nearest neighbor assignment is used when extracting a raster value from categorical rasters. Check the Categorical check box for any rasters that represent classes or categories such as land cover or presence or absence.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object ExplanatoryRasters { get; set; }

		/// <summary>
		/// <para>Input Prediction Features</para>
		/// <para>A feature class representing locations where predictions will be made. This feature class must also contain any explanatory variables provided as fields that correspond to those used from the training data if any.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object FeaturesToPredict { get; set; }

		/// <summary>
		/// <para>Output Predicted Features</para>
		/// <para>The output feature class to receive the results of the prediction results.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Output Prediction Surface</para>
		/// <para>The output raster containing the prediction results. The default cell size will be the maximum cell size of the raster inputs. To set a different cell size, use the cell size environment setting.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object OutputRaster { get; set; }

		/// <summary>
		/// <para>Match Explanatory Variables</para>
		/// <para>A list of the Explanatory Variables specified from the Input Training Features on the right and their corresponding fields from the Input Prediction Features on the left.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object ExplanatoryVariableMatching { get; set; }

		/// <summary>
		/// <para>Match Distance Features</para>
		/// <para>A list of the Explanatory Distance Features specified for the Input Training Features on the right. Corresponding feature sets should be specified for the Input Prediction Features on the left.</para>
		/// <para>Explanatory Distance Features that are more appropriate for the Input Prediction Features can be provided if those used for training are in a different study area or time period.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object ExplanatoryDistanceMatching { get; set; }

		/// <summary>
		/// <para>Match Explanatory Rasters</para>
		/// <para>A list of the Explanatory Rasters specified for the Input Training Features on the right. Corresponding rasters should be specified for the Input Prediction Features or the Prediction Surface to be created on the left.</para>
		/// <para>Explanatory Rasters that are more appropriate for the Input Prediction Features can be provided if those used for training are in a different study area or time period.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object ExplanatoryRastersMatching { get; set; }

		/// <summary>
		/// <para>Output Trained Features</para>
		/// <para>Output Trained Features will contain all explanatory variables used for training (including sampled raster values and distance calculations), as well as the observed Variable to Predict field and accompanying predictions that can be used to further assess performance of the trained model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Additional Outputs")]
		public object OutputTrainedFeatures { get; set; }

		/// <summary>
		/// <para>Output Variable Importance Table</para>
		/// <para>If specified, the table will contain information describing the importance of each explanatory variable (fields, distance features, and rasters) used in the model created. The chart created from this table can be accessed in the Contents pane.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Additional Outputs")]
		public object OutputImportanceTable { get; set; }

		/// <summary>
		/// <para>Convert Polygons to Raster Resolution for Training</para>
		/// <para>Specifies how polygons are treated when training the model if the Input Training Features are polygons with a categorical Variable to Predict and only Explanatory Training Rasters have been specified.</para>
		/// <para>Checked—The polygon is divided into all of the raster cells with centroids falling within the polygon. The raster values at each centroid are then extracted and used to train the model. The model is no longer trained on the polygon itself, but rather the model is trained on the raster values extracted for each cell centroid. This is the default.</para>
		/// <para>Unchecked—Each polygon is assigned the average value of the underlying continuous rasters and the majority for underlying categorical rasters.</para>
		/// <para><see cref="UseRasterValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Forest Options")]
		public object UseRasterValues { get; set; } = "true";

		/// <summary>
		/// <para>Number of Trees</para>
		/// <para>The number of trees to create in the forest model. More trees will generally result in more accurate model prediction, but the model will take longer to calculate. The default number of trees is 100.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 10000000)]
		[Category("Advanced Forest Options")]
		public object NumberOfTrees { get; set; } = "100";

		/// <summary>
		/// <para>Minimum Leaf Size</para>
		/// <para>The minimum number of observations required to keep a leaf (that is the terminal node on a tree without further splits). The default minimum for regression is 5 and the default for classification is 1. For very large data, increasing these numbers will decrease the run time of the tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 10000000)]
		[Category("Advanced Forest Options")]
		public object MinimumLeafSize { get; set; }

		/// <summary>
		/// <para>Maximum Tree Depth</para>
		/// <para>The maximum number of splits that will be made down a tree. Using a large maximum depth, more splits will be created, which may increase the chances of overfitting the model. The default is data driven and depends on the number of trees created and the number of variables included.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 100000000)]
		[Category("Advanced Forest Options")]
		public object MaximumDepth { get; set; }

		/// <summary>
		/// <para>Data Available per Tree (%)</para>
		/// <para>Specifies the percentage of the Input Training Features used for each decision tree. The default is 100 percent of the data. Samples for each tree are taken randomly from two-thirds of the data specified.</para>
		/// <para>Each decision tree in the forest is created using a random sample or subset (approximately two-thirds) of the training data available. Using a lower percentage of the input data for each decision tree increases the speed of the tool for very large datasets.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 100)]
		[Category("Advanced Forest Options")]
		public object SampleSize { get; set; } = "100";

		/// <summary>
		/// <para>Number of Randomly Sampled Variables</para>
		/// <para>Specifies the number of explanatory variables used to create each decision tree.</para>
		/// <para>Each of the decision trees in the forest is created using a random subset of the explanatory variables specified. Increasing the number of variables used in each decision tree will increase the chances of overfitting your model particularly if there is one or more dominant variables. A common practice is to use the square root of the total number of explanatory variables (fields, distances, and rasters combined) if your Variable to Predict is numeric or divide the total number of explanatory variables (fields, distances, and rasters combined) by 3 if Variable to Predict is categorical.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 10000000)]
		[Category("Advanced Forest Options")]
		public object RandomVariables { get; set; }

		/// <summary>
		/// <para>Training Data Excluded for Validation (%)</para>
		/// <para>Specifies the percentage (between 10 percent and 50 percent) of Input Training Features to reserve as the test dataset for validation. The model will be trained without this random subset of data, and the observed values for those features will be compared to the predicted values. The default is 10 percent.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 50)]
		[Category("Validation Options")]
		public object PercentageForTraining { get; set; } = "10";

		/// <summary>
		/// <para>Output Classification Performance Table (Confusion Matrix)</para>
		/// <para>If specified, creates a confusion matrix for classification summarizing the performance of the model created. This table can be used to calculate other diagnostics beyond the accuracy and sensitivity measures the tool calculates in the output messages.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Additional Outputs")]
		public object OutputClassificationTable { get; set; }

		/// <summary>
		/// <para>Output  Validation Table</para>
		/// <para>If the Number of Runs for Validation specified is greater than 2, this table creates a chart of the distribution of R2 for each model. This distribution can be used to assess the stability of your model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Validation Options")]
		public object OutputValidationTable { get; set; }

		/// <summary>
		/// <para>Compensate for Sparse Categories</para>
		/// <para>If there are categories in your dataset that don&apos;t occur as often as others, checking this parameter will ensure that each category is represented in each tree.</para>
		/// <para>Checked—Each tree will include every category that is represented in the training dataset.</para>
		/// <para>Unchecked—Each tree will be created based on a random sample of the categories in the training dataset. This is the default.</para>
		/// <para><see cref="CompensateSparseCategoriesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Forest Options")]
		public object CompensateSparseCategories { get; set; }

		/// <summary>
		/// <para>Number of Runs for Validation</para>
		/// <para>The tool will run for the number of iterations specified. The distribution of the R2 for each run can be displayed using the Output Validation Table parameter. When this is set and predictions are being generated, only the model that produced the highest R2 value will be used for predictions.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 10000000)]
		[Category("Validation Options")]
		public object NumberValidationRuns { get; set; } = "1";

		/// <summary>
		/// <para>Calculate Uncertainty</para>
		/// <para>Specifies whether prediction uncertainty will be calculated when training, predicting to features, or predicting to raster.</para>
		/// <para>Checked—A prediction uncertainty interval will be calculated.</para>
		/// <para>Unchecked—Uncertainty will not be calculated. This is the default.</para>
		/// <para><see cref="CalculateUncertaintyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Validation Options")]
		public object CalculateUncertainty { get; set; } = "false";

		/// <summary>
		/// <para>Output Uncertainty Raster Layers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutputUncertaintyRasterLayers { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Forest SetEnviroment(object cellSize = null, object mask = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object randomGenerator = null)
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
			/// <para>Train only—A model will be trained, but no predictions will be generated. Use this option to assess the accuracy of your model before generating predictions. This option will output model diagnostics in the messages window and a chart of variable importance. This is the default</para>
			/// </summary>
			[GPValue("TRAIN")]
			[Description("Train only")]
			Train_only,

			/// <summary>
			/// <para>Predict to features—Predictions or classifications will be generated for features. Explanatory variables must be provided for both the training features and the features to be predicted. The output of this option will be a feature class, model diagnostics in the messages window, and an optional table and chart of variable importance.</para>
			/// </summary>
			[GPValue("PREDICT_FEATURES")]
			[Description("Predict to features")]
			Predict_to_features,

			/// <summary>
			/// <para>Predict to raster—A prediction raster will be generated for the area where the explanatory rasters intersect. Explanatory rasters must be provided for both the training area and the area to be predicted. The output of this option will be a prediction surface, model diagnostics in the messages window, and an optional table and chart of variable importance.</para>
			/// </summary>
			[GPValue("PREDICT_RASTER")]
			[Description("Predict to raster")]
			Predict_to_raster,

		}

		/// <summary>
		/// <para>Treat Variable as Categorical</para>
		/// </summary>
		public enum TreatVariableAsCategoricalEnum 
		{
			/// <summary>
			/// <para>Checked—The Variable to Predict is a categorical variable and the tool will perform classification.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CATEGORICAL")]
			CATEGORICAL,

			/// <summary>
			/// <para>Unchecked—The Variable to Predict is continuous and the tool will perform regression. This is the default.</para>
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
			/// <para>Checked—The polygon is divided into all of the raster cells with centroids falling within the polygon. The raster values at each centroid are then extracted and used to train the model. The model is no longer trained on the polygon itself, but rather the model is trained on the raster values extracted for each cell centroid. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("TRUE")]
			TRUE,

			/// <summary>
			/// <para>Unchecked—Each polygon is assigned the average value of the underlying continuous rasters and the majority for underlying categorical rasters.</para>
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
			/// <para>Checked—Each tree will include every category that is represented in the training dataset.</para>
			/// </summary>
			[GPValue("true")]
			[Description("TRUE")]
			TRUE,

			/// <summary>
			/// <para>Unchecked—Each tree will be created based on a random sample of the categories in the training dataset. This is the default.</para>
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
			/// <para>Checked—A prediction uncertainty interval will be calculated.</para>
			/// </summary>
			[GPValue("true")]
			[Description("TRUE")]
			TRUE,

			/// <summary>
			/// <para>Unchecked—Uncertainty will not be calculated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("FALSE")]
			FALSE,

		}

#endregion
	}
}
