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
	/// <para>Exploratory Regression</para>
	/// <para>Exploratory Regression</para>
	/// <para>Evaluates all possible combinations of the input candidate explanatory variables, looking for OLS models that best explain the dependent variable within the context of user-specified criteria.</para>
	/// </summary>
	public class ExploratoryRegression : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>The feature class or feature layer containing the dependent and candidate explanatory variables to analyze.</para>
		/// </param>
		/// <param name="DependentVariable">
		/// <para>Dependent Variable</para>
		/// <para>The numeric field containing the observed values you want to model using OLS.</para>
		/// </param>
		/// <param name="CandidateExplanatoryVariables">
		/// <para>Candidate Explanatory Variables</para>
		/// <para>A list of fields to try as OLS model explanatory variables.</para>
		/// </param>
		public ExploratoryRegression(object InputFeatures, object DependentVariable, object CandidateExplanatoryVariables)
		{
			this.InputFeatures = InputFeatures;
			this.DependentVariable = DependentVariable;
			this.CandidateExplanatoryVariables = CandidateExplanatoryVariables;
		}

		/// <summary>
		/// <para>Tool Display Name : Exploratory Regression</para>
		/// </summary>
		public override string DisplayName() => "Exploratory Regression";

		/// <summary>
		/// <para>Tool Name : ExploratoryRegression</para>
		/// </summary>
		public override string ToolName() => "ExploratoryRegression";

		/// <summary>
		/// <para>Tool Excute Name : stats.ExploratoryRegression</para>
		/// </summary>
		public override string ExcuteName() => "stats.ExploratoryRegression";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatures, DependentVariable, CandidateExplanatoryVariables, WeightsMatrixFile!, OutputReportFile!, OutputResultsTable!, MaximumNumberOfExplanatoryVariables!, MinimumNumberOfExplanatoryVariables!, MinimumAcceptableAdjRSquared!, MaximumCoefficientPValueCutoff!, MaximumVIFValueCutoff!, MinimumAcceptableJarqueBeraPValue!, MinimumAcceptableSpatialAutocorrelationPValue! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The feature class or feature layer containing the dependent and candidate explanatory variables to analyze.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Dependent Variable</para>
		/// <para>The numeric field containing the observed values you want to model using OLS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object DependentVariable { get; set; }

		/// <summary>
		/// <para>Candidate Explanatory Variables</para>
		/// <para>A list of fields to try as OLS model explanatory variables.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object CandidateExplanatoryVariables { get; set; }

		/// <summary>
		/// <para>Weights Matrix File</para>
		/// <para>A file containing spatial weights that define the spatial relationships among your input features. This file is used to assess spatial autocorrelation among regression residuals. You can use the Generate Spatial Weights Matrix File tool to create this. When you do not provide a spatial weights matrix file, residuals are assessed for spatial autocorrelation based on each feature&apos;s 8 nearest neighbors.</para>
		/// <para>Note: The spatial weights matrix file is only used to analyze spatial structure in model residuals; it is not used to build or to calibrate any of the OLS models.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("swm", "gwt")]
		public object? WeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Output Report File</para>
		/// <para>The report file contains tool results, including details about any models found that passed all the search criteria you entered. This output file also contains diagnostics to help you fix common regression problems in the case that you don't find any passing models.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("txt")]
		public object? OutputReportFile { get; set; }

		/// <summary>
		/// <para>Output Results Table</para>
		/// <para>The optional output table created containing the explanatory variables and diagnostics for all of the models within the Coefficient p-value and VIF value cutoffs.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutputResultsTable { get; set; }

		/// <summary>
		/// <para>Maximum Number of Explanatory Variables</para>
		/// <para>All models with explanatory variables up to the value entered here will be assessed. If, for example, the Minimum Number of Explanatory Variables is 2 and the Maximum Number of Explanatory Variables is 3, the Exploratory Regression tool will try all models with every combination of two explanatory variables, and all models with every combination of three explanatory variables.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Search Criteria")]
		public object? MaximumNumberOfExplanatoryVariables { get; set; } = "5";

		/// <summary>
		/// <para>Minimum Number of Explanatory Variables</para>
		/// <para>This value represents the minimum number of explanatory variables for models evaluated. If, for example, the Minimum Number of Explanatory Variables is 2 and the Maximum Number of Explanatory Variables is 3, the Exploratory Regression tool will try all models with every combination of two explanatory variables, and all models with every combination of three explanatory variables.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Search Criteria")]
		public object? MinimumNumberOfExplanatoryVariables { get; set; } = "1";

		/// <summary>
		/// <para>Minimum Acceptable Adj R Squared</para>
		/// <para>This is the lowest Adjusted R-Squared value you consider a passing model. If a model passes all of your other search criteria, but has an Adjusted R-Squared value smaller than the value entered here, it will not show up as a Passing Model in the Output Report File. Valid values for this parameter range from 0.0 to 1.0. The default value is 0.05, indicating that passing models will explain at least 50 percent of the variation in the dependent variable.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 1)]
		[Category("Search Criteria")]
		public object? MinimumAcceptableAdjRSquared { get; set; } = "0.5";

		/// <summary>
		/// <para>Maximum Coefficient p value Cutoff</para>
		/// <para>For each model evaluated, OLS computes explanatory variable coefficient p-values. The cutoff p-value you enter here represents the confidence level you require for all coefficients in the model in order to consider the model passing. Small p-values reflect a stronger confidence level. Valid values for this parameter range from 1.0 down to 0.0, but will most likely be 0.1, 0.05, 0.01, 0.001, and so on. The default value is 0.05, indicating passing models will only contain explanatory variables whose coefficients are statistically at the 95 percent confidence level (p-values smaller than 0.05). To relax this default you would enter a larger p-value cutoff, such as 0.1. If you are getting lots of passing models, you will likely want to make this search criteria more stringent by decreasing the default p-value cutoff from 0.05 to 0.01 or smaller.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 1)]
		[Category("Search Criteria")]
		public object? MaximumCoefficientPValueCutoff { get; set; } = "0.05";

		/// <summary>
		/// <para>Maximum VIF Value Cutoff</para>
		/// <para>This value reflects how much redundancy (multicollinearity) among model explanatory variables you will tolerate. When the VIF (Variance Inflation Factor) value is higher than about 7.5, multicollinearity can make a model unstable; consequently, 7.5 is the default value here. If you want your passing models to have less redundancy, you would enter a smaller value, such as 5.0, for this parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 99999999)]
		[Category("Search Criteria")]
		public object? MaximumVIFValueCutoff { get; set; } = "7.5";

		/// <summary>
		/// <para>Minimum Acceptable Jarque Bera p value</para>
		/// <para>The p-value returned by the Jarque-Bera diagnostic test indicates whether the model residuals are normally distributed. If the p-value is statistically significant (small), the model residuals are not normal and the model is biased. Passing models should have large Jarque-Bera p-values. The default minimum acceptable p-value is 0.1. Only models returning p-values larger than this minimum will be considered passing. If you are having trouble finding unbiased passing models, and decide to relax this criterion, you might enter a smaller minimum p-value such as 0.05.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 1)]
		[Category("Search Criteria")]
		public object? MinimumAcceptableJarqueBeraPValue { get; set; } = "0.1";

		/// <summary>
		/// <para>Minimum Acceptable Spatial Autocorrelation p value</para>
		/// <para>For models that pass all of the other search criteria, the Exploratory Regression tool will check model residuals for spatial clustering using Global Moran's I. When the p-value for this diagnostic test is statistically significant (small), it indicates the model is very likely missing key explanatory variables (it isn't telling the whole story). Unfortunately, if you have spatial autocorrelation in your regression residuals, your model is misspecified, so you cannot trust your results. Passing models should have large p-values for this diagnostic test. The default minimum p-value is 0.1. Only models returning p-values larger than this minimum will be considered passing. If you are having trouble finding properly specified models because of this diagnostic test, and decide to relax this search criteria, you might enter a smaller minimum such as 0.05.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 1)]
		[Category("Search Criteria")]
		public object? MinimumAcceptableSpatialAutocorrelationPValue { get; set; } = "0.1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExploratoryRegression SetEnviroment(object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
