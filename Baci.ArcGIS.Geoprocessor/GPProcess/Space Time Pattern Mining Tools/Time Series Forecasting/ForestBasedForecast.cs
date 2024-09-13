using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpaceTimePatternMiningTools
{
	/// <summary>
	/// <para>Forest-based Forecast</para>
	/// <para>Forest-based Forecast</para>
	/// <para>Forecasts the values of each location of a space-time cube using an adaptation of   the random forest algorithm, which is a supervised machine learning method developed by Leo Breiman and Adele Cutler. The forest regression model is trained using time windows on each location of the space-time cube.</para>
	/// </summary>
	public class ForestBasedForecast : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCube">
		/// <para>Input Space Time Cube</para>
		/// <para>The netCDF cube containing the variable to forecast to future time steps. This file must have an .nc file extension and must have been created using the Create Space Time Cube By Aggregating Points, Create Space Time Cube From Defined Locations, or Create Space Time Cube From Multidimensional Raster Layer tool.</para>
		/// </param>
		/// <param name="AnalysisVariable">
		/// <para>Analysis Variable</para>
		/// <para>The numeric variable in the netCDF file that will be forecasted to future time steps.</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>The output feature class of all locations in the space-time cube with forecasted values stored as fields. The layer displays the forecast for the final time step and contains pop-up charts showing the time series, forecasts, and 90 percent confidence bounds for each location.</para>
		/// </param>
		public ForestBasedForecast(object InCube, object AnalysisVariable, object OutputFeatures)
		{
			this.InCube = InCube;
			this.AnalysisVariable = AnalysisVariable;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Forest-based Forecast</para>
		/// </summary>
		public override string DisplayName() => "Forest-based Forecast";

		/// <summary>
		/// <para>Tool Name : ForestBasedForecast</para>
		/// </summary>
		public override string ToolName() => "ForestBasedForecast";

		/// <summary>
		/// <para>Tool Excute Name : stpm.ForestBasedForecast</para>
		/// </summary>
		public override string ExcuteName() => "stpm.ForestBasedForecast";

		/// <summary>
		/// <para>Toolbox Display Name : Space Time Pattern Mining Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Space Time Pattern Mining Tools";

		/// <summary>
		/// <para>Toolbox Alise : stpm</para>
		/// </summary>
		public override string ToolboxAlise() => "stpm";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "parallelProcessingFactor", "randomGenerator" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCube, AnalysisVariable, OutputFeatures, OutputCube!, NumberOfTimeStepsToForecast!, TimeWindow!, NumberForValidation!, NumberOfTrees!, MinimumLeafSize!, MaximumDepth!, SampleSize!, ForecastApproach!, OutlierOption!, LevelOfConfidence!, MaximumNumberOfOutliers!, OtherVariables!, ImportanceThreshold!, OutputImportanceTable!, ModelScale!, ClusterVariable! };

		/// <summary>
		/// <para>Input Space Time Cube</para>
		/// <para>The netCDF cube containing the variable to forecast to future time steps. This file must have an .nc file extension and must have been created using the Create Space Time Cube By Aggregating Points, Create Space Time Cube From Defined Locations, or Create Space Time Cube From Multidimensional Raster Layer tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object InCube { get; set; }

		/// <summary>
		/// <para>Analysis Variable</para>
		/// <para>The numeric variable in the netCDF file that will be forecasted to future time steps.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AnalysisVariable { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The output feature class of all locations in the space-time cube with forecasted values stored as fields. The layer displays the forecast for the final time step and contains pop-up charts showing the time series, forecasts, and 90 percent confidence bounds for each location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Output Space Time Cube</para>
		/// <para>A new space-time cube (.nc file) containing the values of the input space-time cube with the forecasted time steps appended. The Visualize Space Time Cube in 3D tool can be used to see all of the observed and forecasted values simultaneously.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object? OutputCube { get; set; }

		/// <summary>
		/// <para>Number of Time Steps to Forecast</para>
		/// <para>A positive integer specifying the number of time steps to forecast. This value cannot be larger than 50 percent of the total time steps in the input space-time cube. The default value is one time step.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumberOfTimeStepsToForecast { get; set; } = "1";

		/// <summary>
		/// <para>Time Step Window</para>
		/// <para>The number of previous time steps that will be used when training the model. If the data displays seasonality (repeating cycles), provide the number of time steps corresponding to one season. This value cannot be larger than one-third of the number of time steps in the input space-time cube. When using individual location model scale, if no value is provided, a time window is estimated for each location using a spectral density function. When using entire cube or time series cluster model scales, if no value is provided, one-fourth of the number of time steps will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? TimeWindow { get; set; }

		/// <summary>
		/// <para>Number of Time Steps to Exclude for Validation</para>
		/// <para>The number of time steps at the end of each time series to exclude for validation. The default value is 10 percent (rounded down) of the number of input time steps, and this value cannot be larger than 25 percent of the number of time steps. Provide the value 0 to not exclude any time steps.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumberForValidation { get; set; }

		/// <summary>
		/// <para>Number of Trees</para>
		/// <para>The number of trees that will be created in the forest model. More trees generally result in more accurate model prediction, but the model will take longer to calculate. The default number of trees is 100, and the value must be at least 1 and not greater than 1,000.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 1000)]
		[Category("Advanced Forest Options")]
		public object? NumberOfTrees { get; set; } = "100";

		/// <summary>
		/// <para>Minimum Leaf Size</para>
		/// <para>The minimum number of observations that are required to keep a leaf (that is, the terminal node on a tree without further splits). For very large data, increasing this number will decrease the run time of the tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 10000000)]
		[Category("Advanced Forest Options")]
		public object? MinimumLeafSize { get; set; }

		/// <summary>
		/// <para>Maximum Tree Depth</para>
		/// <para>The maximum number of splits that will be made down a tree. Using a large maximum depth, more splits will be created, which may increase the chance of overfitting the model. If no value is provided, a value will be identified by the tool based on the number of trees created by the model and the size of the time step window.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 100000000)]
		[Category("Advanced Forest Options")]
		public object? MaximumDepth { get; set; }

		/// <summary>
		/// <para>Percentage of Training Available per Tree (%)</para>
		/// <para>The percent of training data that will be used to fit the forecast model. The training data consists of associated explanatory and dependent variables constructed using time windows. All remaining training data will be used to optimize the parameters of the forecast model. The default is 100 percent.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 100)]
		[Category("Advanced Forest Options")]
		public object? SampleSize { get; set; } = "100";

		/// <summary>
		/// <para>Forecast Approach</para>
		/// <para>Specifies how the explanatory and dependent variables will be represented when training the forest model at each location.</para>
		/// <para>To train the forest model that will be used to forecast, sets of explanatory and dependent variables must be created using time windows. Use this parameter to specify whether these variables will be linearly detrended and whether the dependent variable will be represented by its raw value or by the residual of a linear regression model. This linear regression model uses all time steps within a time window as explanatory variables and uses the following time step as the dependent variable. The residual is calculated by subtracting the predicted value based on linear regression from the raw value of the dependent variable.</para>
		/// <para>If any variables are provided in the Other Variables parameter or if Entire cube or Time series cluster is specified for the Model Scale parameter, the Value option will be the only available forecast approach.</para>
		/// <para>Build model by value— Values within the time window will not be detrended and the dependent variable will be represented by its raw value. If any other variables are provided or if the model scale is not individual location, this will be the only available forecast approach and will be the default.</para>
		/// <para>Build model by value after detrending— Values within the time window will be linearly detrended, and the dependent variable will be represented by its detrended value. This is the default.</para>
		/// <para>Build model by residual— Values within the time window will not be detrended, and the dependent variable will be represented by the residual of a linear regression model using the values within the time window as explanatory variables.</para>
		/// <para>Build model by residual after detrending— Values within the time window will be linearly detrended, and the dependent variable will be represented by the residual of a linear regression model using the detrended values within the time window as explanatory variables.</para>
		/// <para><see cref="ForecastApproachEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ForecastApproach { get; set; } = "VALUE_DETREND";

		/// <summary>
		/// <para>Outlier Option</para>
		/// <para>Specifies whether statistically significant time series outliers will be identified.</para>
		/// <para>None—Outliers will not be identified. This is the default.</para>
		/// <para>Identify outliers—Outliers will be identified using the Generalized ESD test.</para>
		/// <para><see cref="OutlierOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OutlierOption { get; set; } = "NONE";

		/// <summary>
		/// <para>Level of Confidence</para>
		/// <para>Specifies the confidence level for the test for time series outliers.</para>
		/// <para>90%—The confidence level for the test is 90 percent. This is the default.</para>
		/// <para>95%—The confidence level for the test is 95 percent.</para>
		/// <para>99%—The confidence level for the test is 99 percent.</para>
		/// <para><see cref="LevelOfConfidenceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LevelOfConfidence { get; set; } = "90%";

		/// <summary>
		/// <para>Maximum Number of Outliers</para>
		/// <para>The maximum number of time steps that can be declared outliers for each location. The default value corresponds to 5 percent (rounded down) of the number of time steps of the input space-time cube (a value of at least 1 will always be used). This value cannot exceed 20 percent of the number of time steps.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MaximumNumberOfOutliers { get; set; }

		/// <summary>
		/// <para>Other Variables</para>
		/// <para>Other variables of the input space-time cube that will be used as explanatory variables to improve the forecasts.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? OtherVariables { get; set; }

		/// <summary>
		/// <para>Importance Threshold (%)</para>
		/// <para>The percent of factors deemed most important for forecasting the analysis variable. For example, if the value is 20, the top 20 percent of factors for each location will be included in the importance table. Each variable (the analysis variable and each explanatory variable) is represented as a factor once for each time step in the time step window, so the number of factors at each location is the length of the time window multiplied by the number of variables. The number of factors is multiplied by the importance threshold to determine the number of important factors for each forecast model. The default is 10, and the value must be an integer between 1 and 100.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 100)]
		[Category("Advanced Forest Options")]
		public object? ImportanceThreshold { get; set; } = "10";

		/// <summary>
		/// <para>Output Importance Table</para>
		/// <para>The output table that will contain the most important factors at each location. For individual location model scale, each important factor at each location of the space-time cube will be represented as a row in the table with fields containing the name of the variable and associated time lag. For entire cube and time series cluster model scales, all important factors in the entire cube or cluster model will be represented by a row .The table will include a chart displaying the most important factors across all locations separated by time lag. The chart allows you to visualize lagged effects between the explanatory variables and the variable being forecasted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Advanced Forest Options")]
		public object? OutputImportanceTable { get; set; }

		/// <summary>
		/// <para>Model Scale</para>
		/// <para>Specifies the scale that will be used to estimate the forecast and validation models.</para>
		/// <para>Individual location—A different forecast model and validation model will be estimated for each location. This is the default.</para>
		/// <para>Entire cube—A single forecast model and validation model will be estimated using all locations as training data.</para>
		/// <para>Time series cluster—A forecast and validation model will be estimated for each cluster of a time series clustering result. Provide the variable with time series clustering results in the Cluster Variable parameter.</para>
		/// <para><see cref="ModelScaleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ModelScale { get; set; } = "INDIVIDUAL_LOCATION";

		/// <summary>
		/// <para>Cluster Variable</para>
		/// <para>The variable that will be used to group the locations of the space-time cube into regions, and different forecast and validation models will be estimated for each region. The variable must have time series clustering results to be used. The cluster variable can be any variable of the space-time cube including the analysis variable.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ClusterVariable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ForestBasedForecast SetEnviroment(object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? randomGenerator = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, randomGenerator: randomGenerator);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Forecast Approach</para>
		/// </summary>
		public enum ForecastApproachEnum 
		{
			/// <summary>
			/// <para>Build model by value— Values within the time window will not be detrended and the dependent variable will be represented by its raw value. If any other variables are provided or if the model scale is not individual location, this will be the only available forecast approach and will be the default.</para>
			/// </summary>
			[GPValue("VALUE")]
			[Description("Build model by value")]
			Build_model_by_value,

			/// <summary>
			/// <para>Build model by value after detrending— Values within the time window will be linearly detrended, and the dependent variable will be represented by its detrended value. This is the default.</para>
			/// </summary>
			[GPValue("VALUE_DETREND")]
			[Description("Build model by value after detrending")]
			Build_model_by_value_after_detrending,

			/// <summary>
			/// <para>Build model by residual— Values within the time window will not be detrended, and the dependent variable will be represented by the residual of a linear regression model using the values within the time window as explanatory variables.</para>
			/// </summary>
			[GPValue("RESIDUAL")]
			[Description("Build model by residual")]
			Build_model_by_residual,

			/// <summary>
			/// <para>Build model by residual after detrending— Values within the time window will be linearly detrended, and the dependent variable will be represented by the residual of a linear regression model using the detrended values within the time window as explanatory variables.</para>
			/// </summary>
			[GPValue("RESIDUAL_DETREND")]
			[Description("Build model by residual after detrending")]
			Build_model_by_residual_after_detrending,

		}

		/// <summary>
		/// <para>Outlier Option</para>
		/// </summary>
		public enum OutlierOptionEnum 
		{
			/// <summary>
			/// <para>None—Outliers will not be identified. This is the default.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>Identify outliers—Outliers will be identified using the Generalized ESD test.</para>
			/// </summary>
			[GPValue("IDENTIFY")]
			[Description("Identify outliers")]
			Identify_outliers,

		}

		/// <summary>
		/// <para>Level of Confidence</para>
		/// </summary>
		public enum LevelOfConfidenceEnum 
		{
			/// <summary>
			/// <para>90%—The confidence level for the test is 90 percent. This is the default.</para>
			/// </summary>
			[GPValue("90%")]
			[Description("90%")]
			_90percent,

			/// <summary>
			/// <para>95%—The confidence level for the test is 95 percent.</para>
			/// </summary>
			[GPValue("95%")]
			[Description("95%")]
			_95percent,

			/// <summary>
			/// <para>99%—The confidence level for the test is 99 percent.</para>
			/// </summary>
			[GPValue("99%")]
			[Description("99%")]
			_99percent,

		}

		/// <summary>
		/// <para>Model Scale</para>
		/// </summary>
		public enum ModelScaleEnum 
		{
			/// <summary>
			/// <para>Individual location—A different forecast model and validation model will be estimated for each location. This is the default.</para>
			/// </summary>
			[GPValue("INDIVIDUAL_LOCATION")]
			[Description("Individual location")]
			Individual_location,

			/// <summary>
			/// <para>Entire cube—A single forecast model and validation model will be estimated using all locations as training data.</para>
			/// </summary>
			[GPValue("ENTIRE_CUBE")]
			[Description("Entire cube")]
			Entire_cube,

			/// <summary>
			/// <para>Time series cluster—A forecast and validation model will be estimated for each cluster of a time series clustering result. Provide the variable with time series clustering results in the Cluster Variable parameter.</para>
			/// </summary>
			[GPValue("TIME_SERIES_CLUSTER")]
			[Description("Time series cluster")]
			Time_series_cluster,

		}

#endregion
	}
}
