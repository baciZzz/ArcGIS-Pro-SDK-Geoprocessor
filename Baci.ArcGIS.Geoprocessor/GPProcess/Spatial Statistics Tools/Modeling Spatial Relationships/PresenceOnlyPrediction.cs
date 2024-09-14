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
	/// <para>Presence-only Prediction (MaxEnt)</para>
	/// <para>Presence-only Prediction (MaxEnt)</para>
	/// <para>Models the presence of a phenomenon given known presence locations and explanatory variables using a maximum entropy approach (MaxEnt). The tool provides output features and rasters that include the probability of presence and can be applied to problems in which only presence is known and absence is not known.</para>
	/// </summary>
	public class PresenceOnlyPrediction : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputPointFeatures">
		/// <para>Input Point Features</para>
		/// <para>The point features representing locations where presence of a phenomenon of interest is known to occur.</para>
		/// </param>
		public PresenceOnlyPrediction(object InputPointFeatures)
		{
			this.InputPointFeatures = InputPointFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Presence-only Prediction (MaxEnt)</para>
		/// </summary>
		public override string DisplayName() => "Presence-only Prediction (MaxEnt)";

		/// <summary>
		/// <para>Tool Name : PresenceOnlyPrediction</para>
		/// </summary>
		public override string ToolName() => "PresenceOnlyPrediction";

		/// <summary>
		/// <para>Tool Excute Name : stats.PresenceOnlyPrediction</para>
		/// </summary>
		public override string ExcuteName() => "stats.PresenceOnlyPrediction";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "cellSizeProjectionMethod", "extent", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "randomGenerator", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputPointFeatures, ContainsBackground!, PresenceIndicatorField!, ExplanatoryVariables!, DistanceFeatures!, ExplanatoryRasters!, BasisExpansionFunctions!, NumberKnots!, StudyAreaType!, StudyAreaPolygon!, SpatialThinning!, ThinningDistanceBand!, NumberOfIterations!, RelativeWeight!, LinkFunction!, PresenceProbabilityCutoff!, OutputTrainedFeatures!, OutputTrainedRaster!, OutputResponseCurveTable!, OutputSensitivityTable!, FeaturesToPredict!, OutputPredFeatures!, OutputPredRaster!, ExplanatoryVariableMatching!, ExplanatoryDistanceMatching!, ExplanatoryRastersMatching!, AllowPredictionsOutsideOfDataRanges!, ResamplingScheme!, NumberOfGroups! };

		/// <summary>
		/// <para>Input Point Features</para>
		/// <para>The point features representing locations where presence of a phenomenon of interest is known to occur.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InputPointFeatures { get; set; }

		/// <summary>
		/// <para>Contains Background Points</para>
		/// <para>Specifies whether the input point features contain background points.</para>
		/// <para>If the input points do not contain background points, the tool will generate background points using cells in the explanatory training rasters. The tool uses background points to model the characteristics of the landscape in unknown locations and compare them to landscape characteristics in known presence locations. Therefore, background points can be considered as the study area. Generally, these are locations where presence of a phenomenon of interest is unknown. However, if any information is known about the background points, the Relative Weight of Presence to Background parameter can be used to indicate this.</para>
		/// <para>Checked—The input point features include background points.</para>
		/// <para>Unchecked—The input point features do not include background points. This is the default.</para>
		/// <para><see cref="ContainsBackgroundEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ContainsBackground { get; set; } = "false";

		/// <summary>
		/// <para>Presence Indicator Field</para>
		/// <para>The field from the input point features containing binary values that indicate each point as presence (1) or background (0). The field must be numeric (Short, Long, Float, or Double types).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? PresenceIndicatorField { get; set; }

		/// <summary>
		/// <para>Explanatory Training Variables</para>
		/// <para>A list of fields representing the explanatory variables that will help predict the probability of presence. You can specify whether each variable is categorical or numeric. Check the Categorical check box for each variable that represents a class or category (such as land cover).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? ExplanatoryVariables { get; set; }

		/// <summary>
		/// <para>Explanatory Training Distance Features</para>
		/// <para>A list of feature layers or feature classes that will be used to automatically create explanatory variables that represent the distance from the input point features to the nearest provided distance features. If the input explanatory training distance features are polygons or lines, the distance attributes are calculated as the distance between the closest segment and the point.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Point", "Polyline")]
		[FeatureType("Simple")]
		public object? DistanceFeatures { get; set; }

		/// <summary>
		/// <para>Explanatory Training Rasters</para>
		/// <para>A list of rasters that will be used to automatically create explanatory training variables in the model whose values are extracted from rasters. For each feature (presence and background points) in the input point features, the value of the raster cell will be extracted at that exact location.</para>
		/// <para>Bilinear raster resampling will be used when extracting the raster value for continuous rasters. Nearest neighbor assignment will be used when extracting a raster value from categorical rasters.</para>
		/// <para>You can specify whether each raster value is categorical or numeric. Check the Categorical check box for each raster that represents a class or category (such as land cover).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? ExplanatoryRasters { get; set; }

		/// <summary>
		/// <para>Explanatory Variable Expansions (Basis Functions)</para>
		/// <para>Specifies the basis function that will be used to transform the provided explanatory variables for use in the model. If multiple basis functions are selected, the tool will produce multiple transformed variables and attempt to use them in the model.</para>
		/// <para>Original (Linear)— A linear transformation to the input variables will be applied. This is the default</para>
		/// <para>Pairwise interaction (Product)— A pairwise multiplication on continuous explanatory variables will be used, yielding interaction variables. This option is only available when multiple explanatory variables have been provided.</para>
		/// <para>Smoothed step (Hinge)— The continuous explanatory variable values will be converted into two segments, a static segment (composed of zeroes or ones) and a linear function segment (increasing or decreasing).</para>
		/// <para>Discrete step (Threshold)— The continuous explanatory variable values will be converted into a binary variable composed of zeroes and ones.</para>
		/// <para>Squared (Quadratic)— The square of each continuous explanatory variable value will be returned.</para>
		/// <para><see cref="BasisExpansionFunctionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? BasisExpansionFunctions { get; set; } = "LINEAR";

		/// <summary>
		/// <para>Number of Knots</para>
		/// <para>The number of knots that will be used by the hinge and threshold explanatory variable expansions. The value controls how many thresholds are created, which are used to create multiple explanatory variable expansions using each threshold. The value must be between 2 and 50. The default is 10.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 50)]
		public object? NumberKnots { get; set; } = "10";

		/// <summary>
		/// <para>Study Area</para>
		/// <para>Specifies the type of study area that will be used to define where presence is possible when the input point features do not contain background points.</para>
		/// <para>Convex hull— The smallest convex polygon that encloses all the presence points in the input point features will be used. This is the default</para>
		/// <para>Raster extent—The extent of the intersection of the explanatory training rasters will be used.</para>
		/// <para>Polygon study area—A custom study area that is defined by a polygon feature class will be used.</para>
		/// <para><see cref="StudyAreaTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? StudyAreaType { get; set; } = "CONVEX_HULL";

		/// <summary>
		/// <para>Study Area Polygon</para>
		/// <para>A feature class containing the polygons that define a custom study area. The input point features must be located within the custom study area covered by the polygon features. A study area can be composed of multiple polygons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object? StudyAreaPolygon { get; set; }

		/// <summary>
		/// <para>Apply Spatial Thinning</para>
		/// <para>Specifies whether spatial thinning will be applied to presence and background points before training the model.</para>
		/// <para>Spatial thinning helps to reduce sampling bias by removing points and ensuring that remaining points have a minimum nearest-neighbor distance, set in the Minimum Nearest Neighbors parameter. Spatial thinning is also applied to background points whether they are provided in input point features or generated by the tool.</para>
		/// <para>Checked—Spatial thinning will be applied.</para>
		/// <para>Unchecked—Spatial thinning will not be applied. This is the default.</para>
		/// <para><see cref="SpatialThinningEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SpatialThinning { get; set; } = "false";

		/// <summary>
		/// <para>Minimum Nearest Neighbor Distance</para>
		/// <para>The minimum distance between any two presence points or any two background points when spatial thinning is applied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? ThinningDistanceBand { get; set; }

		/// <summary>
		/// <para>Number of Iterations for Thinning</para>
		/// <para>The number of runs that will be used to find the optimal spatial thinning solution, seeking to maintain as many presence and background points as possible while ensuring that no two presence or two background points are within the specified Minimum Nearest Neighbor Distance parameter value. The minimum possible is 1 iteration and the maximum possible is 50 iterations. The default is 10.</para>
		/// <para>This parameter is only applicable for spatial thinning applied to presence and background points in the input point features. Spatial thinning that is applied to background points generated from raster cells undergo spatial thinning by resampling the raster cells to the specified Minimum Nearest Distance parameter value without needing to iterate for an optimal solution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 50)]
		public object? NumberOfIterations { get; set; } = "10";

		/// <summary>
		/// <para>Relative Weight of Presence to Background</para>
		/// <para>A value between 1 and 100 that specifies the relative information weight of presence points to background points. The default is 100.</para>
		/// <para>A higher value indicates that presence points are the primary source of information; it is unknown whether background points represent presence or absence and background points receive lower weight in the model. A lower value indicates that background points also contribute valuable information that can be used in conjunction with presence points; there is greater confidence that background points represent absence and their information can be used in the model as absence locations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 100)]
		[Category("Advanced Model Options")]
		public object? RelativeWeight { get; set; } = "100";

		/// <summary>
		/// <para>Presence Probability Transformation (Link Function)</para>
		/// <para>Specifies the function that will convert the unbounded outputs of the model to a number between 0 and 1. This value can be interpreted as the probability of presence at the location. Each option converts the same continuous value to a different probability.</para>
		/// <para>C-log-log— The C-log-log link function will be used to convert the predictions to probabilities. This option is recommended when the presence and location of a phenomenon is unambiguous, for example, when modeling the presence of an immobile plant species. This is the default.</para>
		/// <para>Logistic—The logistic link function will be used to convert predictions to probabilities. This option is recommended when the presence and location of a phenomenon is ambiguous, for example, when modeling the presence of a migratory animal species.</para>
		/// <para><see cref="LinkFunctionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Model Options")]
		public object? LinkFunction { get; set; }

		/// <summary>
		/// <para>Presence Probability Cutoff</para>
		/// <para>A cutoff value between 0.01 and 0.99 that establishes which probabilities correspond with presence in the resulting classification. The cutoff value is used to help evaluate the model's performance using training data and known presence points. Classification diagnostics are provided in geoprocessing messages and in the output trained features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0.01, Max = 0.98999999999999999)]
		[Category("Advanced Model Options")]
		public object? PresenceProbabilityCutoff { get; set; } = "0.5";

		/// <summary>
		/// <para>Output Trained Features</para>
		/// <para>An output feature class that will contain all features and explanatory variables used in the training of the model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Training Outputs")]
		public object? OutputTrainedFeatures { get; set; }

		/// <summary>
		/// <para>Output Trained Raster</para>
		/// <para>The output raster with cell values indicating the probability of presence using the selected link function. The default cell size is the maximum of the cell sizes of the explanatory training rasters. An output trained raster can only be created if the input point features do not contain background points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Training Outputs")]
		public object? OutputTrainedRaster { get; set; }

		/// <summary>
		/// <para>Output Response Curve Table</para>
		/// <para>The output table that will contain diagnostics from the training model that indicate the effect of each explanatory variable on the probability of presence after accounting for the average effects of all other explanatory variables in the model.</para>
		/// <para>The table will have up to two derived charts of partial dependence plots: one set of line charts for continuous variables and one set of bar charts for categorical variables.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Training Outputs")]
		public object? OutputResponseCurveTable { get; set; }

		/// <summary>
		/// <para>Output Sensitivity Table</para>
		/// <para>The output table that will contain diagnostics of training model accuracy as the probability presence cutoff changes from 0 to 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Training Outputs")]
		public object? OutputSensitivityTable { get; set; }

		/// <summary>
		/// <para>Input Prediction Features</para>
		/// <para>The feature class representing locations where predictions will be made. The feature class must contain any provided explanatory variable fields that were used from the input point features.</para>
		/// <para>When using spatial thinning, you can use the original input point features as input prediction features to receive a prediction for the entire dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[Category("Prediction Options")]
		public object? FeaturesToPredict { get; set; }

		/// <summary>
		/// <para>Output Prediction Features</para>
		/// <para>The output feature class that will contain the results of the prediction model applied to the input prediction features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Prediction Options")]
		public object? OutputPredFeatures { get; set; }

		/// <summary>
		/// <para>Output Prediction Raster</para>
		/// <para>The output raster containing the prediction results at each cell of the matched explanatory rasters. The default cell size is the maximum of the cell sizes of the explanatory training rasters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		[Category("Prediction Options")]
		public object? OutputPredRaster { get; set; }

		/// <summary>
		/// <para>Match Explanatory Variables</para>
		/// <para>The matching explanatory variable fields for the input point features and input prediction features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Prediction Options")]
		public object? ExplanatoryVariableMatching { get; set; }

		/// <summary>
		/// <para>Match Distance Features</para>
		/// <para>The matching distance features for the training and prediction.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Prediction Options")]
		public object? ExplanatoryDistanceMatching { get; set; }

		/// <summary>
		/// <para>Match Explanatory Rasters</para>
		/// <para>The matching rasters for the training and prediction.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Prediction Options")]
		public object? ExplanatoryRastersMatching { get; set; }

		/// <summary>
		/// <para>Allow Predictions Outside of Data Ranges</para>
		/// <para>Specifies whether the prediction will allow extrapolation when explanatory variable values are out of the range of values used in training.</para>
		/// <para>Checked—The prediction will allow extrapolation beyond the range of values used in training. This is the default.</para>
		/// <para>Unchecked—The prediction will not allow extrapolation beyond the range of values used in training.</para>
		/// <para><see cref="AllowPredictionsOutsideOfDataRangesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Prediction Options")]
		public object? AllowPredictionsOutsideOfDataRanges { get; set; } = "true";

		/// <summary>
		/// <para>Resampling Scheme</para>
		/// <para>Specifies the method that will be used to perform cross validation of the prediction model. Cross validation excludes a portion of the data during training of the model and uses it to test the model&apos;s performance after it is trained.</para>
		/// <para>None—Cross validation will not be performed. This is the default</para>
		/// <para>Random— The points will be randomly divided into groups, and each group will be left out once when performing cross validation. The number of groups is specified in the Number of Groups parameter.</para>
		/// <para><see cref="ResamplingSchemeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Validation Options")]
		public object? ResamplingScheme { get; set; } = "NONE";

		/// <summary>
		/// <para>Number of Groups</para>
		/// <para>The number of groups that will be used in cross validation for the random resampling scheme. A field in the output trained features indicates the group that each point was assigned to. The default is 3. A minimum of 2 groups and a maximum of 10 groups are allowed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 10)]
		[Category("Validation Options")]
		public object? NumberOfGroups { get; set; } = "3";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PresenceOnlyPrediction SetEnviroment(object? cellSize = null, object? cellSizeProjectionMethod = null, object? extent = null, object? mask = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? randomGenerator = null, object? snapRaster = null)
		{
			base.SetEnv(cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, extent: extent, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, randomGenerator: randomGenerator, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Contains Background Points</para>
		/// </summary>
		public enum ContainsBackgroundEnum 
		{
			/// <summary>
			/// <para>Checked—The input point features include background points.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESENCE_AND_BACKGROUND_POINTS")]
			PRESENCE_AND_BACKGROUND_POINTS,

			/// <summary>
			/// <para>Unchecked—The input point features do not include background points. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("PRESENCE_ONLY_POINTS")]
			PRESENCE_ONLY_POINTS,

		}

		/// <summary>
		/// <para>Explanatory Variable Expansions (Basis Functions)</para>
		/// </summary>
		public enum BasisExpansionFunctionsEnum 
		{
			/// <summary>
			/// <para>Original (Linear)— A linear transformation to the input variables will be applied. This is the default</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("Original (Linear)")]
			LINEAR,

			/// <summary>
			/// <para>Squared (Quadratic)— The square of each continuous explanatory variable value will be returned.</para>
			/// </summary>
			[GPValue("QUADRATIC")]
			[Description("Squared (Quadratic)")]
			QUADRATIC,

			/// <summary>
			/// <para>Pairwise interaction (Product)— A pairwise multiplication on continuous explanatory variables will be used, yielding interaction variables. This option is only available when multiple explanatory variables have been provided.</para>
			/// </summary>
			[GPValue("PRODUCT")]
			[Description("Pairwise interaction (Product)")]
			PRODUCT,

			/// <summary>
			/// <para>Smoothed step (Hinge)— The continuous explanatory variable values will be converted into two segments, a static segment (composed of zeroes or ones) and a linear function segment (increasing or decreasing).</para>
			/// </summary>
			[GPValue("HINGE")]
			[Description("Smoothed step (Hinge)")]
			HINGE,

			/// <summary>
			/// <para>Discrete step (Threshold)— The continuous explanatory variable values will be converted into a binary variable composed of zeroes and ones.</para>
			/// </summary>
			[GPValue("THRESHOLD")]
			[Description("Discrete step (Threshold)")]
			THRESHOLD,

		}

		/// <summary>
		/// <para>Study Area</para>
		/// </summary>
		public enum StudyAreaTypeEnum 
		{
			/// <summary>
			/// <para>Convex hull— The smallest convex polygon that encloses all the presence points in the input point features will be used. This is the default</para>
			/// </summary>
			[GPValue("CONVEX_HULL")]
			[Description("Convex hull")]
			Convex_hull,

			/// <summary>
			/// <para>Raster extent—The extent of the intersection of the explanatory training rasters will be used.</para>
			/// </summary>
			[GPValue("RASTER_EXTENT")]
			[Description("Raster extent")]
			Raster_extent,

			/// <summary>
			/// <para>Polygon study area—A custom study area that is defined by a polygon feature class will be used.</para>
			/// </summary>
			[GPValue("STUDY_POLYGON")]
			[Description("Polygon study area")]
			Polygon_study_area,

		}

		/// <summary>
		/// <para>Apply Spatial Thinning</para>
		/// </summary>
		public enum SpatialThinningEnum 
		{
			/// <summary>
			/// <para>Checked—Spatial thinning will be applied.</para>
			/// </summary>
			[GPValue("true")]
			[Description("THINNING")]
			THINNING,

			/// <summary>
			/// <para>Unchecked—Spatial thinning will not be applied. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_THINNING")]
			NO_THINNING,

		}

		/// <summary>
		/// <para>Presence Probability Transformation (Link Function)</para>
		/// </summary>
		public enum LinkFunctionEnum 
		{
			/// <summary>
			/// <para>C-log-log— The C-log-log link function will be used to convert the predictions to probabilities. This option is recommended when the presence and location of a phenomenon is unambiguous, for example, when modeling the presence of an immobile plant species. This is the default.</para>
			/// </summary>
			[GPValue("CLOGLOG")]
			[Description("C-log-log")]
			CLOGLOG,

			/// <summary>
			/// <para>Logistic—The logistic link function will be used to convert predictions to probabilities. This option is recommended when the presence and location of a phenomenon is ambiguous, for example, when modeling the presence of a migratory animal species.</para>
			/// </summary>
			[GPValue("LOGISTIC")]
			[Description("Logistic")]
			Logistic,

		}

		/// <summary>
		/// <para>Allow Predictions Outside of Data Ranges</para>
		/// </summary>
		public enum AllowPredictionsOutsideOfDataRangesEnum 
		{
			/// <summary>
			/// <para>Checked—The prediction will allow extrapolation beyond the range of values used in training. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ALLOWED")]
			ALLOWED,

			/// <summary>
			/// <para>Unchecked—The prediction will not allow extrapolation beyond the range of values used in training.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_ALLOWED")]
			NOT_ALLOWED,

		}

		/// <summary>
		/// <para>Resampling Scheme</para>
		/// </summary>
		public enum ResamplingSchemeEnum 
		{
			/// <summary>
			/// <para>None—Cross validation will not be performed. This is the default</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>Random— The points will be randomly divided into groups, and each group will be left out once when performing cross validation. The number of groups is specified in the Number of Groups parameter.</para>
			/// </summary>
			[GPValue("RANDOM")]
			[Description("Random")]
			Random,

		}

#endregion
	}
}
