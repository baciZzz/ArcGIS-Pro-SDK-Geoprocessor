using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools
{
	/// <summary>
	/// <para>Exploratory Interpolation</para>
	/// <para>Generates various interpolation results from input point features and a field. The interpolation results are then compared and ranked using customizable criteria based on cross validation statistics.</para>
	/// </summary>
	public class ExploratoryInterpolation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input features</para>
		/// <para>The input points representing locations of points to be interpolated.</para>
		/// </param>
		/// <param name="ValueField">
		/// <para>Value field</para>
		/// <para>The field containing the values to be interpolated.</para>
		/// </param>
		/// <param name="OutCvTable">
		/// <para>Output cross validation table</para>
		/// <para>The output table containing cross validation statistics and ranks for each interpolation result. The final ranks of the interpolation results are stored in the RANK field.</para>
		/// </param>
		public ExploratoryInterpolation(object InFeatures, object ValueField, object OutCvTable)
		{
			this.InFeatures = InFeatures;
			this.ValueField = ValueField;
			this.OutCvTable = OutCvTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Exploratory Interpolation</para>
		/// </summary>
		public override string DisplayName => "Exploratory Interpolation";

		/// <summary>
		/// <para>Tool Name : ExploratoryInterpolation</para>
		/// </summary>
		public override string ToolName => "ExploratoryInterpolation";

		/// <summary>
		/// <para>Tool Excute Name : ga.ExploratoryInterpolation</para>
		/// </summary>
		public override string ExcuteName => "ga.ExploratoryInterpolation";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "coincidentPoints", "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, ValueField, OutCvTable, OutGeostatLayer!, InterpMethods!, ComparisonMethod!, Criterion!, CriteriaHierarchy!, WeightedCriteria!, ExclusionCriteria! };

		/// <summary>
		/// <para>Input features</para>
		/// <para>The input points representing locations of points to be interpolated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Value field</para>
		/// <para>The field containing the values to be interpolated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object ValueField { get; set; }

		/// <summary>
		/// <para>Output cross validation table</para>
		/// <para>The output table containing cross validation statistics and ranks for each interpolation result. The final ranks of the interpolation results are stored in the RANK field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutCvTable { get; set; }

		/// <summary>
		/// <para>Output geostatistical layer with highest rank</para>
		/// <para>The output geostatistical layer of the interpolation result with highest rank. This interpolation result will have the value 1 in the RANK field of the output cross validation table. If there are ties for the interpolation result with highest rank or all results are excluded by exclusion criteria, the layer will not be created even if a value is provided. Warning messages will be returned by the tool if this occurs.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPGALayer()]
		public object? OutGeostatLayer { get; set; }

		/// <summary>
		/// <para>Interpolation methods</para>
		/// <para>Specifies the interpolation methods that will be performed on the input features and value field. For each method specified, 1 to 5 interpolation results will be generated. By default, all methods will be generated except inverse distance weighting, radial basis functions, and global polynomial (because these methods cannot create standard errors of predictions). By default, 11 interpolation results will be generated. If all options are specified, 20 interpolation results will be generated.</para>
		/// <para>Simple Kriging—Four simple kriging results will be generated: default, optimized, trend removal, and transformation with trend removal.</para>
		/// <para>Ordinary Kriging—Two ordinary kriging results will be generated: default and optimized.</para>
		/// <para>Universal Kriging—Two universal kriging results will be generated: default and optimized.</para>
		/// <para>Empirical Bayesian Kriging—Two empirical Bayesian kriging results will be generated: default and advanced.</para>
		/// <para>Kernel (Local Polynomial) Interpolation—One default kernel (local polynomial) interpolation result will be generated.</para>
		/// <para>Inverse Distance Weighting—Two inverse distance weighting results will be generated: default and optimized.</para>
		/// <para>Radial Basis Functions—Five radial basis functions results will be generated, one for each of the five kernel functions.</para>
		/// <para>Global Polynomial Interpolation—Two global polynomial interpolation results will be generated: linear (first order) and quadratic (second order) trend.</para>
		/// <para><see cref="InterpMethodsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? InterpMethods { get; set; } = "SIMPLE_KRIGING;ORDINARY_KRIGING;UNIVERSAL_KRIGING;EBK;KERNEL_INTERPOLATION";

		/// <summary>
		/// <para>Comparison method</para>
		/// <para>Specifies the method that will be used to compare and rank the interpolation results.</para>
		/// <para>Single criterion—A single criterion will be used to compare and rank results, such as highest prediction accuracy or lowest bias. The criterion from the Criterion parameter is used.</para>
		/// <para>Hierarchical sorting with tolerances—Hierarchical sorting will be used to compare results. Multiple criteria are specified in priority order (highest priority first) in the Criteria hierarchy parameter. The interpolation results are ranked by the first criterion, and any ties are broken by the second criterion. Ties in the second criterion are broken by the third criterion, and so on. Cross validation statistics are continuous values and generally do not have exact ties, so tolerances (percent or absolute) can be specified to create ties in each of the criteria.</para>
		/// <para>Weighted average rank—The weighted average rank of multiple criteria will be used to compare results. Multiple criteria and associated weights are specified using the Weighted criteria parameter. The interpolation results are ranked independently by each of the criteria, and a weighted average of the ranks is used to determine the final ranks. Criteria with larger weights will have more influence on the final ranks, so weights can be used to indicate preference for certain criteria over others.</para>
		/// <para><see cref="ComparisonMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ComparisonMethod { get; set; } = "SINGLE";

		/// <summary>
		/// <para>Criterion</para>
		/// <para>Specifies the criterion that will be used to rank the interpolation results.</para>
		/// <para>Highest prediction accuracy—Results will be ranked by lowest root mean square error. This option measures how closely the cross validation predictions match the true values, on average. This is the default.</para>
		/// <para>Lowest bias—Results will be ranked by mean error closest to zero. This option measures how much the cross validation predictions overpredict or underpredict the true values, on average. Interpolation results with positive mean errors systematically overpredict the true values (positive bias), and results with negative mean errors systematically underpredict the true values (negative bias).</para>
		/// <para>Lowest worst-case error—Results will be ranked by lowest maximum absolute error. This option measures only the single least accurate cross validation prediction (positive or negative). This is useful when you are most concerned about worst-case scenarios rather than the accuracy in typical conditions.</para>
		/// <para>Highest standard error accuracy— Results will be ranked by root mean square standardized error closest to one. This option measures how closely the variability of the cross validation predictions match the estimated standard errors. This is useful if you intend to create confidence intervals or margins of error for the predictions.</para>
		/// <para>Highest precision—Results will be ranked by lowest average standard error. When creating confidence intervals or margins of error for the predicted values, results with higher precision will have narrower intervals around the predictions. It does not measure whether the standard errors are estimated accurately, only that the standard errors are small. When using this option, it is recommended that you include minimum and maximum root mean square standardized error values as exclusion criteria to ensure that the standard errors are both accurate and precise.</para>
		/// <para><see cref="CriterionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Criterion { get; set; } = "ACCURACY";

		/// <summary>
		/// <para>Criteria hierarchy</para>
		/// <para>The hierarchy of criteria that will be used for hierarchical sorting with tolerances. Provide multiple criteria in priority order with the first being most important. The interpolation results are ranked by the first criterion, and any ties are broken by the second criterion. Ties in the second criterion are broken by the third criterion, and so on. Cross validation statistics are continuous values and generally do not have exact ties, so tolerances are used to induce ties in the criteria. For each row, specify a criterion in the first column, a tolerance type (percent or absolute) in the second column, and a tolerance value in the third column. If no tolerance value is provided, no tolerance will be used; this is most useful for the final row so that there will be no ties for the interpolation result with highest rank.</para>
		/// <para>For each row (level of the hierarchy), the following criteria are available:</para>
		/// <para>Root mean square error (Accuracy)—Results will be ranked by highest accuracy.</para>
		/// <para>Mean error (Bias)—Results will be ranked by lowest bias.</para>
		/// <para>Maximum absolute error (Worst-case error)—Results will be ranked by lowest worst-case error.</para>
		/// <para>Standardized RMSE (Standard error accuracy)—Results will be ranked by highest standard error accuracy.</para>
		/// <para>Average standard error (Precision)—Results will be ranked by highest precision.</para>
		/// <para>For example, you can specify a Root mean square error (Accuracy) value with a 5 percent tolerance in the first row and a Mean error (Bias) value with no tolerance in the second row. These options will first rank the interpolation results by lowest root mean square error (highest prediction accuracy), and all interpolation results whose root mean square error values are within 5 percent of the most accurate result will be considered ties by prediction accuracy. Among the tying results, the result with a mean error closest to zero (lowest bias) will receive the highest rank.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? CriteriaHierarchy { get; set; } = "ACCURACY PERCENT #";

		/// <summary>
		/// <para>Weighted criteria</para>
		/// <para>The multiple criteria with weights that will be used to rank interpolation results. For each row, provide a criterion and a weight. The interpolation results will be ranked independently by each of the criteria, and a weighted average of the ranks will be used to determine the final ranks of the interpolation results.</para>
		/// <para>Highest prediction accuracy—Results will be ranked by lowest root mean square error.</para>
		/// <para>Lowest bias—Results will be ranked by mean error closest to zero.</para>
		/// <para>Lowest worst-case error—Results will be ranked by lowest maximum absolute error.</para>
		/// <para>Highest standard error accuracy—Results will be ranked by root mean square standardized error closest to one.</para>
		/// <para>Highest precision—Results will be ranked by lowest average standard error.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? WeightedCriteria { get; set; } = "ACCURACY 1";

		/// <summary>
		/// <para>Exclusion criteria</para>
		/// <para>The criteria and associated values that will be used to exclude interpolation results from the comparison. Excluded results will not receive ranks and will have the value No in the Included field of the output cross validation table.</para>
		/// <para>Maximum root mean square error—Results will be excluded if the root mean square error exceeds the specified value. The value cannot be negative. This option measures prediction accuracy.</para>
		/// <para>Maximum absolute error—Results will be excluded if the maximum absolute error exceeds the specified value. The value cannot be negative. This option measures the worst-case error.</para>
		/// <para>Maximum root mean square standardized error—Results will be excluded if the root mean square standard error exceeds the specified value. The value must be greater than or equal to 1. This option measures standard error accuracy.</para>
		/// <para>Minimum root mean square standardized error—Results will be excluded if the root mean square standardized error does not exceed the specified value. The value must be between 0 and 1. This option measures standard error accuracy.</para>
		/// <para>Maximum mean error—Results will be excluded if the mean error exceeds the specified value. The value cannot be negative. This option measures bias.</para>
		/// <para>Minimum mean error—Results will be excluded if the mean error does not exceed the specified value. The value cannot be positive. This option measures bias.</para>
		/// <para>Maximum average standard error—Results will be excluded if the average standard error exceeds the specified value. The value cannot be negative. This option measures precision.</para>
		/// <para>Minimum percent error reduction—Results will be excluded if the interpolation result is not sufficiently more accurate than a baseline nonspatial model that predicts the global average value at all locations in the map. This relative accuracy is measured by comparing the root mean square error value to the standard deviation of the values of the points being interpolated, and the root mean square error must be at least the specified percent less than the standard deviation to be included in the comparison. For example, a value of 10 means that the root mean square error must be at least 10 percent lower than the standard deviation to be included in the comparison and ranking. The value must be between 0 and 100. This option measures prediction accuracy.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? ExclusionCriteria { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExploratoryInterpolation SetEnviroment(object? coincidentPoints = null , object? parallelProcessingFactor = null )
		{
			base.SetEnv(coincidentPoints: coincidentPoints, parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Interpolation methods</para>
		/// </summary>
		public enum InterpMethodsEnum 
		{
			/// <summary>
			/// <para>Simple Kriging—Four simple kriging results will be generated: default, optimized, trend removal, and transformation with trend removal.</para>
			/// </summary>
			[GPValue("SIMPLE_KRIGING")]
			[Description("Simple Kriging")]
			Simple_Kriging,

			/// <summary>
			/// <para>Ordinary Kriging—Two ordinary kriging results will be generated: default and optimized.</para>
			/// </summary>
			[GPValue("ORDINARY_KRIGING")]
			[Description("Ordinary Kriging")]
			Ordinary_Kriging,

			/// <summary>
			/// <para>Universal Kriging—Two universal kriging results will be generated: default and optimized.</para>
			/// </summary>
			[GPValue("UNIVERSAL_KRIGING")]
			[Description("Universal Kriging")]
			Universal_Kriging,

			/// <summary>
			/// <para>Empirical Bayesian Kriging—Two empirical Bayesian kriging results will be generated: default and advanced.</para>
			/// </summary>
			[GPValue("EBK")]
			[Description("Empirical Bayesian Kriging")]
			Empirical_Bayesian_Kriging,

			/// <summary>
			/// <para>Kernel (Local Polynomial) Interpolation—One default kernel (local polynomial) interpolation result will be generated.</para>
			/// </summary>
			[GPValue("KERNEL_INTERPOLATION")]
			[Description("Kernel (Local Polynomial) Interpolation")]
			KERNEL_INTERPOLATION,

			/// <summary>
			/// <para>Inverse Distance Weighting—Two inverse distance weighting results will be generated: default and optimized.</para>
			/// </summary>
			[GPValue("IDW")]
			[Description("Inverse Distance Weighting")]
			Inverse_Distance_Weighting,

			/// <summary>
			/// <para>Radial Basis Functions—Five radial basis functions results will be generated, one for each of the five kernel functions.</para>
			/// </summary>
			[GPValue("RBF")]
			[Description("Radial Basis Functions")]
			Radial_Basis_Functions,

			/// <summary>
			/// <para>Global Polynomial Interpolation—Two global polynomial interpolation results will be generated: linear (first order) and quadratic (second order) trend.</para>
			/// </summary>
			[GPValue("GPI")]
			[Description("Global Polynomial Interpolation")]
			Global_Polynomial_Interpolation,

		}

		/// <summary>
		/// <para>Comparison method</para>
		/// </summary>
		public enum ComparisonMethodEnum 
		{
			/// <summary>
			/// <para>Single criterion—A single criterion will be used to compare and rank results, such as highest prediction accuracy or lowest bias. The criterion from the Criterion parameter is used.</para>
			/// </summary>
			[GPValue("SINGLE")]
			[Description("Single criterion")]
			Single_criterion,

			/// <summary>
			/// <para>Hierarchical sorting with tolerances—Hierarchical sorting will be used to compare results. Multiple criteria are specified in priority order (highest priority first) in the Criteria hierarchy parameter. The interpolation results are ranked by the first criterion, and any ties are broken by the second criterion. Ties in the second criterion are broken by the third criterion, and so on. Cross validation statistics are continuous values and generally do not have exact ties, so tolerances (percent or absolute) can be specified to create ties in each of the criteria.</para>
			/// </summary>
			[GPValue("SORTING")]
			[Description("Hierarchical sorting with tolerances")]
			Hierarchical_sorting_with_tolerances,

			/// <summary>
			/// <para>Weighted average rank—The weighted average rank of multiple criteria will be used to compare results. Multiple criteria and associated weights are specified using the Weighted criteria parameter. The interpolation results are ranked independently by each of the criteria, and a weighted average of the ranks is used to determine the final ranks. Criteria with larger weights will have more influence on the final ranks, so weights can be used to indicate preference for certain criteria over others.</para>
			/// </summary>
			[GPValue("AVERAGE_RANK")]
			[Description("Weighted average rank")]
			Weighted_average_rank,

		}

		/// <summary>
		/// <para>Criterion</para>
		/// </summary>
		public enum CriterionEnum 
		{
			/// <summary>
			/// <para>Highest prediction accuracy—Results will be ranked by lowest root mean square error. This option measures how closely the cross validation predictions match the true values, on average. This is the default.</para>
			/// </summary>
			[GPValue("ACCURACY")]
			[Description("Highest prediction accuracy")]
			Highest_prediction_accuracy,

			/// <summary>
			/// <para>Lowest bias—Results will be ranked by mean error closest to zero. This option measures how much the cross validation predictions overpredict or underpredict the true values, on average. Interpolation results with positive mean errors systematically overpredict the true values (positive bias), and results with negative mean errors systematically underpredict the true values (negative bias).</para>
			/// </summary>
			[GPValue("BIAS")]
			[Description("Lowest bias")]
			Lowest_bias,

			/// <summary>
			/// <para>Lowest worst-case error—Results will be ranked by lowest maximum absolute error. This option measures only the single least accurate cross validation prediction (positive or negative). This is useful when you are most concerned about worst-case scenarios rather than the accuracy in typical conditions.</para>
			/// </summary>
			[GPValue("WORST_CASE")]
			[Description("Lowest worst-case error")]
			WORST_CASE,

			/// <summary>
			/// <para>Highest standard error accuracy— Results will be ranked by root mean square standardized error closest to one. This option measures how closely the variability of the cross validation predictions match the estimated standard errors. This is useful if you intend to create confidence intervals or margins of error for the predictions.</para>
			/// </summary>
			[GPValue("STANDARD_ERROR")]
			[Description("Highest standard error accuracy")]
			Highest_standard_error_accuracy,

			/// <summary>
			/// <para>Highest precision—Results will be ranked by lowest average standard error. When creating confidence intervals or margins of error for the predicted values, results with higher precision will have narrower intervals around the predictions. It does not measure whether the standard errors are estimated accurately, only that the standard errors are small. When using this option, it is recommended that you include minimum and maximum root mean square standardized error values as exclusion criteria to ensure that the standard errors are both accurate and precise.</para>
			/// </summary>
			[GPValue("PRECISION")]
			[Description("Highest precision")]
			Highest_precision,

		}

#endregion
	}
}
