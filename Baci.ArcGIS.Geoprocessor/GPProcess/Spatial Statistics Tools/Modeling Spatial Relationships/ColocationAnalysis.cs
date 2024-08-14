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
	/// <para>Colocation Analysis</para>
	/// <para>Measures local patterns of spatial association, or colocation, between two categories of point features using the colocation quotient statistic.</para>
	/// </summary>
	public class ColocationAnalysis : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputType">
		/// <para>Input Type</para>
		/// <para>Specifies whether the Input Features of Interest will come from the same dataset with specified categories, different datasets with specified categories, or different datasets that will be treated as their own category (for example, one dataset with all points representing cheetahs and a second dataset in which all points represent gazelles).</para>
		/// <para>Single dataset—The categories to be analyzed exist in a field in a single dataset.</para>
		/// <para>Two datasets—The categories to be analyzed exist in fields of separate datasets.</para>
		/// <para>Datasets without categories—Two separate datasets representing two categories will be analyzed.</para>
		/// <para><see cref="InputTypeEnum"/></para>
		/// </param>
		/// <param name="InFeaturesOfInterest">
		/// <para>Input Features of Interest</para>
		/// <para>The feature class containing points with representative categories.</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>The output feature class containing all the Input Features of Interest with fields containing the resulting local colocation quotient, symbology bin, and p-values.</para>
		/// </param>
		public ColocationAnalysis(object InputType, object InFeaturesOfInterest, object OutputFeatures)
		{
			this.InputType = InputType;
			this.InFeaturesOfInterest = InFeaturesOfInterest;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Colocation Analysis</para>
		/// </summary>
		public override string DisplayName => "Colocation Analysis";

		/// <summary>
		/// <para>Tool Name : ColocationAnalysis</para>
		/// </summary>
		public override string ToolName => "ColocationAnalysis";

		/// <summary>
		/// <para>Tool Excute Name : stats.ColocationAnalysis</para>
		/// </summary>
		public override string ExcuteName => "stats.ColocationAnalysis";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "outputCoordinateSystem", "parallelProcessingFactor", "randomGenerator" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputType, InFeaturesOfInterest, OutputFeatures, FieldOfInterest, TimeFieldOfInterest, CategoryOfInterest, InputFeatureForComparison, FieldForComparison, TimeFieldForComparison, CategoryForComparison, NeighborhoodType, NumberOfNeighbors, DistanceBand, WeightsMatrixFile, TemporalRelationshipType, TimeStepInterval, NumberOfPermutations, LocalWeightingScheme, OutputTable };

		/// <summary>
		/// <para>Input Type</para>
		/// <para>Specifies whether the Input Features of Interest will come from the same dataset with specified categories, different datasets with specified categories, or different datasets that will be treated as their own category (for example, one dataset with all points representing cheetahs and a second dataset in which all points represent gazelles).</para>
		/// <para>Single dataset—The categories to be analyzed exist in a field in a single dataset.</para>
		/// <para>Two datasets—The categories to be analyzed exist in fields of separate datasets.</para>
		/// <para>Datasets without categories—Two separate datasets representing two categories will be analyzed.</para>
		/// <para><see cref="InputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InputType { get; set; } = "SINGLE_DATASET";

		/// <summary>
		/// <para>Input Features of Interest</para>
		/// <para>The feature class containing points with representative categories.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeaturesOfInterest { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The output feature class containing all the Input Features of Interest with fields containing the resulting local colocation quotient, symbology bin, and p-values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Field of Interest</para>
		/// <para>The field containing the category or categories to be analyzed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object FieldOfInterest { get; set; }

		/// <summary>
		/// <para>Time Field of Interest</para>
		/// <para>A date field with an optional time stamp for each feature to analyze points using a space-time window. Features near each other in space and time will be considered neighbors and will be analyzed together.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object TimeFieldOfInterest { get; set; }

		/// <summary>
		/// <para>Category of Interest</para>
		/// <para>The base category for the analysis. The tool will identify, for each Category of Interest value, the degree to which the base category is attracted to or colocated with the Neighboring Category.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object CategoryOfInterest { get; set; }

		/// <summary>
		/// <para>Input Neighboring Features</para>
		/// <para>The input feature class containing the points with the categories that will be compared.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InputFeatureForComparison { get; set; }

		/// <summary>
		/// <para>Field Containing Neighboring Category</para>
		/// <para>The field from the Input Neighboring Features parameter containing the category to be compared.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object FieldForComparison { get; set; }

		/// <summary>
		/// <para>Time Field of Neighboring Features</para>
		/// <para>A date field with a time stamp for each feature to analyze your points using a space-time window. Features near each other in space and time will be considered neighbors and will be analyzed together.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object TimeFieldForComparison { get; set; }

		/// <summary>
		/// <para>Neighboring Category</para>
		/// <para>The neighboring category for the analysis. The tool will identify the degree to which the Category of Interest is attracted to or isolated from the Neighboring Category.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object CategoryForComparison { get; set; }

		/// <summary>
		/// <para>Neighborhood Type</para>
		/// <para>Specifies how the spatial relationships among features are defined.</para>
		/// <para>Distance band—Each feature will be analyzed within the context of neighboring features. Neighboring features inside the specified critical distance specified by the Distance Band parameter receive a weight of one and exert influence on computations for the target feature. Neighboring features outside the critical distance receive a weight of zero and have no influence on a target feature&apos;s computations.</para>
		/// <para>K nearest neighbors—The closest k features will be included in the analysis as neighbors. The number of neighbors is specified by the Number of Neighbors parameter. This is the default.</para>
		/// <para>Get spatial weights from file—When Single dataset is used as the Input Tpe, spatial relationships will be defined by a specified spatial weights matrix file. The path to the spatial weights file is specified by the Weight Matrix File parameter.</para>
		/// <para><see cref="NeighborhoodTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object NeighborhoodType { get; set; } = "K_NEAREST_NEIGHBORS";

		/// <summary>
		/// <para>Number of Neighbors</para>
		/// <para>The number of neighbors around each feature that will be used to test for local relationships between categories. If no value is provided, the default of 8 is used. The provided value must be large enough to detect the relationships between features but small enough to still identify local patterns.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain()]
		public object NumberOfNeighbors { get; set; } = "8";

		/// <summary>
		/// <para>Distance Band</para>
		/// <para>The neighborhood size is a constant or fixed distance for each feature. All features within this distance will be used to test for local relationships between categories. If no value is provided, the distance used will be the average distance at which each feature has at least eight neighbors.</para>
		/// <para><see cref="DistanceBandEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object DistanceBand { get; set; }

		/// <summary>
		/// <para>Weight Matrix File</para>
		/// <para>The path to a file containing weights that define spatial, and potentially temporal, relationships among features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object WeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Temporal Relationship Type</para>
		/// <para>Specifies how temporal relationships among features will be defined.</para>
		/// <para>Before—The time window will extend back in time for each of the Input Features of Interest values. Neighboring features must have a date/time stamp that occurs before the date/time stamp of the feature of interest to be included in the analysis. This is the default.</para>
		/// <para>After—The time window will extend forward in time for each of the Input Features of Interest values. Neighboring features must have a date/time stamp that occurs after the date/time stamp of the feature of interest to be included in the analysis.</para>
		/// <para>Span—The time window will extend both back and forward in time for each of the Input Features of Interest values. Neighboring features that have a date/time stamp that occurs within the Time Step Interval value either before or after the date/time stamp of the feature of interest will be included in the analysis. For example, if the Time Step Interval parameter is set to 1 week, the window will look 1 week before and 1 week after the target feature.</para>
		/// <para><see cref="TemporalRelationshipTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TemporalRelationshipType { get; set; } = "BEFORE";

		/// <summary>
		/// <para>Time Step Interval</para>
		/// <para>An integer and unit of measurement representing the number of time units composing the time window.</para>
		/// <para><see cref="TimeStepIntervalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object TimeStepInterval { get; set; }

		/// <summary>
		/// <para>Number of Permutations</para>
		/// <para>The number of permutations that will be used to create a reference distribution. Choosing the number of permutations is a balance between precision and increased processing time. Choose your preference of speed versus precision. More robust and precise results take longer to calculate.</para>
		/// <para>99—The analysis will use 99 permutations. With 99 permutations, the smallest possible pseudo p-value is 0.02 and all other pseudo p-values will be multiples of this value. This is the default.</para>
		/// <para>199—The analysis will use 199 permutations. With 199 permutations, the smallest possible pseudo p-value is 0.01 and all other pseudo p-values will be even multiples of this value.</para>
		/// <para>499—The analysis will use 499 permutations. With 499 permutations, the smallest possible pseudo p-value is 0.004 and all other pseudo p-values will be even multiples of this value.</para>
		/// <para>999—The analysis will use 999 permutations. With 999 permutations, the smallest possible pseudo p-value is 0.002 and all other pseudo p-values will be even multiples of this value.</para>
		/// <para>9999—The analysis will use 9,999 permutations. With 9,999 permutations, the smallest possible pseudo p-value is 0.0002 and all other pseudo p-values will be even multiples of this value.</para>
		/// <para><see cref="NumberOfPermutationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object NumberOfPermutations { get; set; } = "99";

		/// <summary>
		/// <para>Local Weighting Scheme</para>
		/// <para>Specifies the kernel type that will be used to provide the spatial weighting. The kernel defines how each feature is related to other features within its neighborhood.</para>
		/// <para>Bisquare—Features will be weighted based on the distance to the farthest neighbor or the edge of the distance band, and a weight of 0 will be assigned to any feature outside the neighborhood specified.</para>
		/// <para>Gaussian—Features will be weighted based on the distance to the farthest neighbor or the edge of the distance band but drop off more quickly than the Bisquare option. A weight of 0 will be assigned to any feature outside the neighborhood specified. This is the default.</para>
		/// <para>None—No weighting scheme will be applied, and all features within the neighborhood will be given a weight of 1 and contribute equally. All features outside the neighborhood will be given a weight of 0.</para>
		/// <para><see cref="LocalWeightingSchemeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object LocalWeightingScheme { get; set; } = "GAUSSIAN";

		/// <summary>
		/// <para>Output Table for Global Relationships</para>
		/// <para>A table that includes the global colocation quotients between all the categories in the Field of Interest parameter and all the categories in the Field Containing Neighboring Category parameter. This table can help you determine the local categories to analyze.</para>
		/// <para>If Datasets without categories is used as the Input Type parameter value, global colocation quotients will be calculated for each dataset and between each dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Additional Options")]
		public object OutputTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ColocationAnalysis SetEnviroment(object outputCoordinateSystem = null , object parallelProcessingFactor = null , object randomGenerator = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, randomGenerator: randomGenerator);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Input Type</para>
		/// </summary>
		public enum InputTypeEnum 
		{
			/// <summary>
			/// <para>Single dataset—The categories to be analyzed exist in a field in a single dataset.</para>
			/// </summary>
			[GPValue("SINGLE_DATASET")]
			[Description("Single dataset")]
			Single_dataset,

			/// <summary>
			/// <para>Datasets without categories—Two separate datasets representing two categories will be analyzed.</para>
			/// </summary>
			[GPValue("DATASETS_WITHOUT_CATEGORIES")]
			[Description("Datasets without categories")]
			Datasets_without_categories,

			/// <summary>
			/// <para>Two datasets—The categories to be analyzed exist in fields of separate datasets.</para>
			/// </summary>
			[GPValue("TWO_DATASETS")]
			[Description("Two datasets")]
			Two_datasets,

		}

		/// <summary>
		/// <para>Neighborhood Type</para>
		/// </summary>
		public enum NeighborhoodTypeEnum 
		{
			/// <summary>
			/// <para>K nearest neighbors—The closest k features will be included in the analysis as neighbors. The number of neighbors is specified by the Number of Neighbors parameter. This is the default.</para>
			/// </summary>
			[GPValue("K_NEAREST_NEIGHBORS")]
			[Description("K nearest neighbors")]
			K_nearest_neighbors,

			/// <summary>
			/// <para>Distance band—Each feature will be analyzed within the context of neighboring features. Neighboring features inside the specified critical distance specified by the Distance Band parameter receive a weight of one and exert influence on computations for the target feature. Neighboring features outside the critical distance receive a weight of zero and have no influence on a target feature&apos;s computations.</para>
			/// </summary>
			[GPValue("DISTANCE_BAND")]
			[Description("Distance band")]
			Distance_band,

			/// <summary>
			/// <para>Get spatial weights from file—When Single dataset is used as the Input Tpe, spatial relationships will be defined by a specified spatial weights matrix file. The path to the spatial weights file is specified by the Weight Matrix File parameter.</para>
			/// </summary>
			[GPValue("GET_SPATIAL_WEIGHTS_FROM_FILE")]
			[Description("Get spatial weights from file")]
			Get_spatial_weights_from_file,

		}

		/// <summary>
		/// <para>Distance Band</para>
		/// </summary>
		public enum DistanceBandEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

		/// <summary>
		/// <para>Temporal Relationship Type</para>
		/// </summary>
		public enum TemporalRelationshipTypeEnum 
		{
			/// <summary>
			/// <para>Before—The time window will extend back in time for each of the Input Features of Interest values. Neighboring features must have a date/time stamp that occurs before the date/time stamp of the feature of interest to be included in the analysis. This is the default.</para>
			/// </summary>
			[GPValue("BEFORE")]
			[Description("Before")]
			Before,

			/// <summary>
			/// <para>After—The time window will extend forward in time for each of the Input Features of Interest values. Neighboring features must have a date/time stamp that occurs after the date/time stamp of the feature of interest to be included in the analysis.</para>
			/// </summary>
			[GPValue("AFTER")]
			[Description("After")]
			After,

			/// <summary>
			/// <para>Span—The time window will extend both back and forward in time for each of the Input Features of Interest values. Neighboring features that have a date/time stamp that occurs within the Time Step Interval value either before or after the date/time stamp of the feature of interest will be included in the analysis. For example, if the Time Step Interval parameter is set to 1 week, the window will look 1 week before and 1 week after the target feature.</para>
			/// </summary>
			[GPValue("SPAN")]
			[Description("Span")]
			Span,

		}

		/// <summary>
		/// <para>Time Step Interval</para>
		/// </summary>
		public enum TimeStepIntervalEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Seconds")]
			[Description("Seconds")]
			Seconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Hours")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Days")]
			[Description("Days")]
			Days,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Weeks")]
			[Description("Weeks")]
			Weeks,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Months")]
			[Description("Months")]
			Months,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Years")]
			[Description("Years")]
			Years,

		}

		/// <summary>
		/// <para>Number of Permutations</para>
		/// </summary>
		public enum NumberOfPermutationsEnum 
		{
			/// <summary>
			/// <para>99—The analysis will use 99 permutations. With 99 permutations, the smallest possible pseudo p-value is 0.02 and all other pseudo p-values will be multiples of this value. This is the default.</para>
			/// </summary>
			[GPValue("99")]
			[Description("99")]
			_99,

			/// <summary>
			/// <para>199—The analysis will use 199 permutations. With 199 permutations, the smallest possible pseudo p-value is 0.01 and all other pseudo p-values will be even multiples of this value.</para>
			/// </summary>
			[GPValue("199")]
			[Description("199")]
			_199,

			/// <summary>
			/// <para>499—The analysis will use 499 permutations. With 499 permutations, the smallest possible pseudo p-value is 0.004 and all other pseudo p-values will be even multiples of this value.</para>
			/// </summary>
			[GPValue("499")]
			[Description("499")]
			_499,

			/// <summary>
			/// <para>999—The analysis will use 999 permutations. With 999 permutations, the smallest possible pseudo p-value is 0.002 and all other pseudo p-values will be even multiples of this value.</para>
			/// </summary>
			[GPValue("999")]
			[Description("999")]
			_999,

			/// <summary>
			/// <para>9999—The analysis will use 9,999 permutations. With 9,999 permutations, the smallest possible pseudo p-value is 0.0002 and all other pseudo p-values will be even multiples of this value.</para>
			/// </summary>
			[GPValue("9999")]
			[Description("9999")]
			_9999,

		}

		/// <summary>
		/// <para>Local Weighting Scheme</para>
		/// </summary>
		public enum LocalWeightingSchemeEnum 
		{
			/// <summary>
			/// <para>Bisquare—Features will be weighted based on the distance to the farthest neighbor or the edge of the distance band, and a weight of 0 will be assigned to any feature outside the neighborhood specified.</para>
			/// </summary>
			[GPValue("BISQUARE")]
			[Description("Bisquare")]
			Bisquare,

			/// <summary>
			/// <para>Gaussian—Features will be weighted based on the distance to the farthest neighbor or the edge of the distance band but drop off more quickly than the Bisquare option. A weight of 0 will be assigned to any feature outside the neighborhood specified. This is the default.</para>
			/// </summary>
			[GPValue("GAUSSIAN")]
			[Description("Gaussian")]
			Gaussian,

			/// <summary>
			/// <para>None—No weighting scheme will be applied, and all features within the neighborhood will be given a weight of 1 and contribute equally. All features outside the neighborhood will be given a weight of 0.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

		}

#endregion
	}
}
