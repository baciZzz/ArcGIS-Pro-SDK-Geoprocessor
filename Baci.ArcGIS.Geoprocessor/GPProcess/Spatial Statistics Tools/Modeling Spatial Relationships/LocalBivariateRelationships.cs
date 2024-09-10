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
	/// <para>Local Bivariate Relationships</para>
	/// <para>Analyzes two variables for statistically significant relationships using local entropy. Each feature is classified into one of six categories based on the type of relationship. The output can be used to visualize areas where the variables are related and explore how their relationship changes across the study area.</para>
	/// </summary>
	public class LocalBivariateRelationships : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The feature class containing fields representing the Dependent Variable and Explanatory Variable values.</para>
		/// </param>
		/// <param name="DependentVariable">
		/// <para>Dependent Variable</para>
		/// <para>The numeric field representing the values of the dependent variable. When categorizing the relationships, the Explanatory Variable value is used to predict the Dependent Variable value.</para>
		/// </param>
		/// <param name="ExplanatoryVariable">
		/// <para>Explanatory Variable</para>
		/// <para>The numeric field representing the values of the explanatory variable. When categorizing the relationships, the Explanatory Variable value is used to predict the Dependent Variable value.</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>The output feature class containing all input features with fields representing the Dependent Variable value, Explanatory Variable value, entropy score, pseudo p-value, level of significance, type of categorized relationship, and diagnostics related to the categorization.</para>
		/// </param>
		public LocalBivariateRelationships(object InFeatures, object DependentVariable, object ExplanatoryVariable, object OutputFeatures)
		{
			this.InFeatures = InFeatures;
			this.DependentVariable = DependentVariable;
			this.ExplanatoryVariable = ExplanatoryVariable;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Local Bivariate Relationships</para>
		/// </summary>
		public override string DisplayName() => "Local Bivariate Relationships";

		/// <summary>
		/// <para>Tool Name : LocalBivariateRelationships</para>
		/// </summary>
		public override string ToolName() => "LocalBivariateRelationships";

		/// <summary>
		/// <para>Tool Excute Name : stats.LocalBivariateRelationships</para>
		/// </summary>
		public override string ExcuteName() => "stats.LocalBivariateRelationships";

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
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "parallelProcessingFactor", "randomGenerator" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, DependentVariable, ExplanatoryVariable, OutputFeatures, NumberOfNeighbors, NumberOfPermutations, EnableLocalScatterplotPopups, LevelOfConfidence, ApplyFalseDiscoveryRateFdrCorrection, ScalingFactor };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The feature class containing fields representing the Dependent Variable and Explanatory Variable values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Dependent Variable</para>
		/// <para>The numeric field representing the values of the dependent variable. When categorizing the relationships, the Explanatory Variable value is used to predict the Dependent Variable value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object DependentVariable { get; set; }

		/// <summary>
		/// <para>Explanatory Variable</para>
		/// <para>The numeric field representing the values of the explanatory variable. When categorizing the relationships, the Explanatory Variable value is used to predict the Dependent Variable value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ExplanatoryVariable { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The output feature class containing all input features with fields representing the Dependent Variable value, Explanatory Variable value, entropy score, pseudo p-value, level of significance, type of categorized relationship, and diagnostics related to the categorization.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Number of Neighbors</para>
		/// <para>The number of neighbors around each feature (including the feature) that will be used to test for a local relationship between the variables. The number of neighbors must be between 30 and 1000, and the default is 30. The provided value should be large enough to detect the relationship between features, but small enough to still identify local patterns.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 30, Max = 1000)]
		public object NumberOfNeighbors { get; set; } = "30";

		/// <summary>
		/// <para>Number of Permutations</para>
		/// <para>Specifies the number of permutations used to calculate the pseudo p-value for each feature. Choosing a number of permutations is a balance between precision in the pseudo p-value and increased processing time.</para>
		/// <para>99 permutations—With 99 permutations, the smallest possible pseudo p-value is 0.01, and all other pseudo p-values will be multiples of this value.</para>
		/// <para>199 permutations—With 199 permutations, the smallest possible pseudo p-value is 0.005, and all other pseudo p-values will be multiples of this value. This is the default.</para>
		/// <para>499 permutations—With 499 permutations, the smallest possible pseudo p-value is 0.002, and all other pseudo p-values will be multiples of this value.</para>
		/// <para>999 permutations—With 999 permutations, the smallest possible pseudo p-value is 0.001, and all other pseudo p-values will be multiples of this value.</para>
		/// <para><see cref="NumberOfPermutationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object NumberOfPermutations { get; set; } = "199";

		/// <summary>
		/// <para>Enable Local Scatterplot Pop-ups</para>
		/// <para>Specifies whether scatterplot pop-ups will be generated for each output feature. Each scatterplot displays the values of the explanatory (horizontal axis) and dependent (vertical axis) variables in the local neighborhood along with a fitted line or curve visualizing the form of the relationship. Scatterplot charts are not supported for shapefile outputs.</para>
		/// <para>Checked—Local scatterplot pop-ups will be generated for each feature in the dataset. This is the default.</para>
		/// <para>Unchecked—Local scatterplot pop-ups will not be generated.</para>
		/// <para><see cref="EnableLocalScatterplotPopupsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object EnableLocalScatterplotPopups { get; set; } = "true";

		/// <summary>
		/// <para>Level of Confidence</para>
		/// <para>Specifies a confidence level of the hypothesis test for significant relationships.</para>
		/// <para>90%—The confidence level is 90 percent. This is the default.</para>
		/// <para>95%—The confidence level is 95 percent.</para>
		/// <para>99%—The confidence level is 99 percent..</para>
		/// <para><see cref="LevelOfConfidenceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LevelOfConfidence { get; set; } = "90%";

		/// <summary>
		/// <para>Apply False Discovery Rate (FDR) Correction</para>
		/// <para>Specifies whether False Discover Rate (FDR) correction will be applied to the pseudo p-values.</para>
		/// <para>Checked—Statistical significance will be based on the FDR correction. This is the default.</para>
		/// <para>Unchecked—Statistical significance will be based on the pseudo p-value.</para>
		/// <para><see cref="ApplyFalseDiscoveryRateFdrCorrectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object ApplyFalseDiscoveryRateFdrCorrection { get; set; } = "true";

		/// <summary>
		/// <para>Scaling Factor (Alpha)</para>
		/// <para>Controls the sensitivity to subtle relationships between the variables. Larger values (closer to one) can detect relatively weak relationships, while smaller values (closer to zero) will only detect strong relationships. Smaller values are also more robust to outliers. The value must be between 0.01 and 1, and the default is 0.5.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0.01, Max = 1)]
		[Category("Advanced Options")]
		public object ScalingFactor { get; set; } = "0.5";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LocalBivariateRelationships SetEnviroment(object outputCoordinateSystem = null , object parallelProcessingFactor = null , object randomGenerator = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, randomGenerator: randomGenerator);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Number of Permutations</para>
		/// </summary>
		public enum NumberOfPermutationsEnum 
		{
			/// <summary>
			/// <para>99 permutations—With 99 permutations, the smallest possible pseudo p-value is 0.01, and all other pseudo p-values will be multiples of this value.</para>
			/// </summary>
			[GPValue("99")]
			[Description("99")]
			_99,

			/// <summary>
			/// <para>199 permutations—With 199 permutations, the smallest possible pseudo p-value is 0.005, and all other pseudo p-values will be multiples of this value. This is the default.</para>
			/// </summary>
			[GPValue("199")]
			[Description("199")]
			_199,

			/// <summary>
			/// <para>499 permutations—With 499 permutations, the smallest possible pseudo p-value is 0.002, and all other pseudo p-values will be multiples of this value.</para>
			/// </summary>
			[GPValue("499")]
			[Description("499")]
			_499,

			/// <summary>
			/// <para>999 permutations—With 999 permutations, the smallest possible pseudo p-value is 0.001, and all other pseudo p-values will be multiples of this value.</para>
			/// </summary>
			[GPValue("999")]
			[Description("999")]
			_999,

		}

		/// <summary>
		/// <para>Enable Local Scatterplot Pop-ups</para>
		/// </summary>
		public enum EnableLocalScatterplotPopupsEnum 
		{
			/// <summary>
			/// <para>Checked—Local scatterplot pop-ups will be generated for each feature in the dataset. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_POPUP")]
			CREATE_POPUP,

			/// <summary>
			/// <para>Unchecked—Local scatterplot pop-ups will not be generated.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_POPUP")]
			NO_POPUP,

		}

		/// <summary>
		/// <para>Level of Confidence</para>
		/// </summary>
		public enum LevelOfConfidenceEnum 
		{
			/// <summary>
			/// <para>90%—The confidence level is 90 percent. This is the default.</para>
			/// </summary>
			[GPValue("90%")]
			[Description("90%")]
			_90percent,

			/// <summary>
			/// <para>95%—The confidence level is 95 percent.</para>
			/// </summary>
			[GPValue("95%")]
			[Description("95%")]
			_95percent,

			/// <summary>
			/// <para>99%—The confidence level is 99 percent..</para>
			/// </summary>
			[GPValue("99%")]
			[Description("99%")]
			_99percent,

		}

		/// <summary>
		/// <para>Apply False Discovery Rate (FDR) Correction</para>
		/// </summary>
		public enum ApplyFalseDiscoveryRateFdrCorrectionEnum 
		{
			/// <summary>
			/// <para>Checked—Statistical significance will be based on the FDR correction. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("APPLY_FDR")]
			APPLY_FDR,

			/// <summary>
			/// <para>Unchecked—Statistical significance will be based on the pseudo p-value.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FDR")]
			NO_FDR,

		}

#endregion
	}
}
