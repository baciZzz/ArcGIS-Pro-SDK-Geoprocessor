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
	/// <para>Cluster and Outlier Analysis (Anselin Local Moran's I)</para>
	/// <para>Given a set of weighted features, identifies statistically significant hot spots, cold spots, and spatial outliers using the Anselin Local Moran's I statistic.</para>
	/// </summary>
	public class ClustersOutliers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>The feature class for which cluster and outlier analysis will be performed.</para>
		/// </param>
		/// <param name="InputField">
		/// <para>Input Field</para>
		/// <para>The numeric field to be evaluated.</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class to receive the results fields.</para>
		/// </param>
		/// <param name="ConceptualizationOfSpatialRelationships">
		/// <para>Conceptualization of Spatial Relationships</para>
		/// <para>Specifies how spatial relationships among features are defined.</para>
		/// <para>Inverse distance—Nearby neighboring features have a larger influence on the computations for a target feature than features that are far away.</para>
		/// <para>Inverse distance squared—Same as Inverse distance except that the slope is sharper, so influence drops off more quickly, and only a target feature&apos;s closest neighbors will exert substantial influence on computations for that feature.</para>
		/// <para>Fixed distance band—Each feature is analyzed within the context of neighboring features. Neighboring features inside the specified critical distance (Distance Band or Threshold Distance) receive a weight of one and exert influence on computations for the target feature. Neighboring features outside the critical distance receive a weight of zero and have no influence on a target feature&apos;s computations.</para>
		/// <para>Zone of indifference—Features within the specified critical distance (Distance Band or Threshold Distance) of a target feature receive a weight of one and influence computations for that feature. Once the critical distance is exceeded, weights (and the influence a neighboring feature has on target feature computations) diminish with distance.</para>
		/// <para>K nearest neighbors—The closest k features are included in the analysis. The number of neighbors (k) is specified by the Number of Neighbors parameter.</para>
		/// <para>Contiguity edges only—Only neighboring polygon features that share a boundary or overlap will influence computations for the target polygon feature.</para>
		/// <para>Contiguity edges corners—Polygon features that share a boundary, share a node, or overlap will influence computations for the target polygon feature.</para>
		/// <para>Get spatial weights from file—Spatial relationships are defined by a specified spatial weights file. The path to the spatial weights file is specified by the Weights Matrix File parameter.</para>
		/// <para><see cref="ConceptualizationOfSpatialRelationshipsEnum"/></para>
		/// </param>
		/// <param name="DistanceMethod">
		/// <para>Distance Method</para>
		/// <para>Specifies how distances are calculated from each feature to neighboring features.</para>
		/// <para>Euclidean—The straight-line distance between two points (as the crow flies)</para>
		/// <para>Manhattan—The distance between two points measured along axes at right angles (city block); calculated by summing the (absolute) difference between the x- and y-coordinates</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </param>
		/// <param name="Standardization">
		/// <para>Standardization</para>
		/// <para>Row standardization is recommended whenever the distribution of your features is potentially biased due to sampling design or an imposed aggregation scheme.</para>
		/// <para>None—No standardization of spatial weights is applied.</para>
		/// <para>Row—Spatial weights are standardized; each weight is divided by its row sum (the sum of the weights of all neighboring features).</para>
		/// <para><see cref="StandardizationEnum"/></para>
		/// </param>
		public ClustersOutliers(object InputFeatureClass, object InputField, object OutputFeatureClass, object ConceptualizationOfSpatialRelationships, object DistanceMethod, object Standardization)
		{
			this.InputFeatureClass = InputFeatureClass;
			this.InputField = InputField;
			this.OutputFeatureClass = OutputFeatureClass;
			this.ConceptualizationOfSpatialRelationships = ConceptualizationOfSpatialRelationships;
			this.DistanceMethod = DistanceMethod;
			this.Standardization = Standardization;
		}

		/// <summary>
		/// <para>Tool Display Name : Cluster and Outlier Analysis (Anselin Local Moran's I)</para>
		/// </summary>
		public override string DisplayName => "Cluster and Outlier Analysis (Anselin Local Moran's I)";

		/// <summary>
		/// <para>Tool Name : ClustersOutliers</para>
		/// </summary>
		public override string ToolName => "ClustersOutliers";

		/// <summary>
		/// <para>Tool Excute Name : stats.ClustersOutliers</para>
		/// </summary>
		public override string ExcuteName => "stats.ClustersOutliers";

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
		public override string[] ValidEnvironments => new string[] { "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "randomGenerator", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputFeatureClass, InputField, OutputFeatureClass, ConceptualizationOfSpatialRelationships, DistanceMethod, Standardization, DistanceBandOrThresholdDistance, WeightsMatrixFile, ApplyFalseDiscoveryRateFDRCorrection, IndexFieldName, ZscoreFieldName, ProbabilityField, ClusterOutlierType, SourceID, NumberOfPermutations, NumberOfNeighbors };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>The feature class for which cluster and outlier analysis will be performed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatureClass { get; set; }

		/// <summary>
		/// <para>Input Field</para>
		/// <para>The numeric field to be evaluated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object InputField { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class to receive the results fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Conceptualization of Spatial Relationships</para>
		/// <para>Specifies how spatial relationships among features are defined.</para>
		/// <para>Inverse distance—Nearby neighboring features have a larger influence on the computations for a target feature than features that are far away.</para>
		/// <para>Inverse distance squared—Same as Inverse distance except that the slope is sharper, so influence drops off more quickly, and only a target feature&apos;s closest neighbors will exert substantial influence on computations for that feature.</para>
		/// <para>Fixed distance band—Each feature is analyzed within the context of neighboring features. Neighboring features inside the specified critical distance (Distance Band or Threshold Distance) receive a weight of one and exert influence on computations for the target feature. Neighboring features outside the critical distance receive a weight of zero and have no influence on a target feature&apos;s computations.</para>
		/// <para>Zone of indifference—Features within the specified critical distance (Distance Band or Threshold Distance) of a target feature receive a weight of one and influence computations for that feature. Once the critical distance is exceeded, weights (and the influence a neighboring feature has on target feature computations) diminish with distance.</para>
		/// <para>K nearest neighbors—The closest k features are included in the analysis. The number of neighbors (k) is specified by the Number of Neighbors parameter.</para>
		/// <para>Contiguity edges only—Only neighboring polygon features that share a boundary or overlap will influence computations for the target polygon feature.</para>
		/// <para>Contiguity edges corners—Polygon features that share a boundary, share a node, or overlap will influence computations for the target polygon feature.</para>
		/// <para>Get spatial weights from file—Spatial relationships are defined by a specified spatial weights file. The path to the spatial weights file is specified by the Weights Matrix File parameter.</para>
		/// <para><see cref="ConceptualizationOfSpatialRelationshipsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConceptualizationOfSpatialRelationships { get; set; } = "INVERSE_DISTANCE";

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>Specifies how distances are calculated from each feature to neighboring features.</para>
		/// <para>Euclidean—The straight-line distance between two points (as the crow flies)</para>
		/// <para>Manhattan—The distance between two points measured along axes at right angles (city block); calculated by summing the (absolute) difference between the x- and y-coordinates</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceMethod { get; set; } = "EUCLIDEAN_DISTANCE";

		/// <summary>
		/// <para>Standardization</para>
		/// <para>Row standardization is recommended whenever the distribution of your features is potentially biased due to sampling design or an imposed aggregation scheme.</para>
		/// <para>None—No standardization of spatial weights is applied.</para>
		/// <para>Row—Spatial weights are standardized; each weight is divided by its row sum (the sum of the weights of all neighboring features).</para>
		/// <para><see cref="StandardizationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Standardization { get; set; } = "ROW";

		/// <summary>
		/// <para>Distance Band or Threshold Distance</para>
		/// <para>Specifies a cutoff distance for Inverse Distance and Fixed Distance options. Features outside the specified cutoff for a target feature are ignored in analyses for that feature. However, for Zone of Indifference, the influence of features outside the given distance is reduced with distance, while those inside the distance threshold are equally considered. The distance value entered should match that of the output coordinate system.</para>
		/// <para>For the Inverse Distance conceptualizations of spatial relationships, a value of 0 indicates that no threshold distance is applied; when this parameter is left blank, a default threshold value is computed and applied. This default value is the Euclidean distance that ensures every feature has at least one neighbor.</para>
		/// <para>This parameter has no effect when Polygon Contiguity or Get Spatial Weights From File spatial conceptualizations are selected.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 999999999999999)]
		public object DistanceBandOrThresholdDistance { get; set; }

		/// <summary>
		/// <para>Weights Matrix File</para>
		/// <para>The path to a file containing weights that define spatial, and potentially temporal, relationships among features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("swm", "gwt")]
		public object WeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Apply False Discovery Rate (FDR) Correction</para>
		/// <para>Specifies whether statistical significance will be assessed with or without FDR correction.</para>
		/// <para>Checked—Statistical significance will be based on the False Discovery Rate correction for a 95 percent confidence level.</para>
		/// <para>Unchecked—Features with p-values less than 0.05 will appear in the COType field reflecting statistically significant clusters or outliers at a 95 percent confidence level. This is the default.</para>
		/// <para><see cref="ApplyFalseDiscoveryRateFDRCorrectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ApplyFalseDiscoveryRateFDRCorrection { get; set; } = "false";

		/// <summary>
		/// <para>Index Field Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[Field()]
		public object IndexFieldName { get; set; } = "LMiIndex";

		/// <summary>
		/// <para>ZScore Field Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[Field()]
		public object ZscoreFieldName { get; set; } = "LMiZScore";

		/// <summary>
		/// <para>Probability Field</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[Field()]
		public object ProbabilityField { get; set; } = "LMiPValue";

		/// <summary>
		/// <para>Cluster Outlier Type</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[Field()]
		public object ClusterOutlierType { get; set; } = "CO_Type";

		/// <summary>
		/// <para>Source ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[Field()]
		public object SourceID { get; set; } = "SOURCE_ID";

		/// <summary>
		/// <para>Number of Permutations</para>
		/// <para>The number of random permutations for the calculation of pseudo p-values. The default number of permutations is 499. If you choose 0 permutations, the standard p-value is calculated.</para>
		/// <para>0—Permutations are not used and a standard p-value is calculated.</para>
		/// <para>99—With 99 permutations, the smallest possible pseudo p-value is 0.01 and all other pseudo p-values will be multiples of this value.</para>
		/// <para>199—With 199 permutations, the smallest possible pseudo p-value is 0.005 and all other possible pseudo p-values will be multiples of this value.</para>
		/// <para>499—With 499 permutations, the smallest possible pseudo p-value is 0.002 and all other pseudo p-values will be multiples of this value.</para>
		/// <para>999—With 999 permutations, the smallest possible pseudo p-value is 0.001 and all other pseudo p-values will be multiples of this value.</para>
		/// <para>9999—With 9999 permutations, the smallest possible pseudo p-value is 0.0001 and all other pseudo p-values will be multiples of this value.</para>
		/// <para><see cref="NumberOfPermutationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object NumberOfPermutations { get; set; } = "499";

		/// <summary>
		/// <para>Number of Neighbors</para>
		/// <para>The number of neighbors to include in the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 1000)]
		public object NumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ClustersOutliers SetEnviroment(object MResolution = null , object MTolerance = null , object XYResolution = null , object XYTolerance = null , object ZResolution = null , object ZTolerance = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , bool? qualifiedFieldNames = null , object randomGenerator = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, randomGenerator: randomGenerator, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Conceptualization of Spatial Relationships</para>
		/// </summary>
		public enum ConceptualizationOfSpatialRelationshipsEnum 
		{
			/// <summary>
			/// <para>Inverse distance—Nearby neighboring features have a larger influence on the computations for a target feature than features that are far away.</para>
			/// </summary>
			[GPValue("INVERSE_DISTANCE")]
			[Description("Inverse distance")]
			Inverse_distance,

			/// <summary>
			/// <para>Inverse distance squared—Same as Inverse distance except that the slope is sharper, so influence drops off more quickly, and only a target feature&apos;s closest neighbors will exert substantial influence on computations for that feature.</para>
			/// </summary>
			[GPValue("INVERSE_DISTANCE_SQUARED")]
			[Description("Inverse distance squared")]
			Inverse_distance_squared,

			/// <summary>
			/// <para>Fixed distance band—Each feature is analyzed within the context of neighboring features. Neighboring features inside the specified critical distance (Distance Band or Threshold Distance) receive a weight of one and exert influence on computations for the target feature. Neighboring features outside the critical distance receive a weight of zero and have no influence on a target feature&apos;s computations.</para>
			/// </summary>
			[GPValue("FIXED_DISTANCE_BAND")]
			[Description("Fixed distance band")]
			Fixed_distance_band,

			/// <summary>
			/// <para>Zone of indifference—Features within the specified critical distance (Distance Band or Threshold Distance) of a target feature receive a weight of one and influence computations for that feature. Once the critical distance is exceeded, weights (and the influence a neighboring feature has on target feature computations) diminish with distance.</para>
			/// </summary>
			[GPValue("ZONE_OF_INDIFFERENCE")]
			[Description("Zone of indifference")]
			Zone_of_indifference,

			/// <summary>
			/// <para>K nearest neighbors—The closest k features are included in the analysis. The number of neighbors (k) is specified by the Number of Neighbors parameter.</para>
			/// </summary>
			[GPValue("K_NEAREST_NEIGHBORS")]
			[Description("K nearest neighbors")]
			K_nearest_neighbors,

			/// <summary>
			/// <para>Contiguity edges only—Only neighboring polygon features that share a boundary or overlap will influence computations for the target polygon feature.</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_ONLY")]
			[Description("Contiguity edges only")]
			Contiguity_edges_only,

			/// <summary>
			/// <para>Contiguity edges corners—Polygon features that share a boundary, share a node, or overlap will influence computations for the target polygon feature.</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_CORNERS")]
			[Description("Contiguity edges corners")]
			Contiguity_edges_corners,

			/// <summary>
			/// <para>Get spatial weights from file—Spatial relationships are defined by a specified spatial weights file. The path to the spatial weights file is specified by the Weights Matrix File parameter.</para>
			/// </summary>
			[GPValue("GET_SPATIAL_WEIGHTS_FROM_FILE")]
			[Description("Get spatial weights from file")]
			Get_spatial_weights_from_file,

		}

		/// <summary>
		/// <para>Distance Method</para>
		/// </summary>
		public enum DistanceMethodEnum 
		{
			/// <summary>
			/// <para>Euclidean—The straight-line distance between two points (as the crow flies)</para>
			/// </summary>
			[GPValue("EUCLIDEAN_DISTANCE")]
			[Description("Euclidean")]
			Euclidean,

			/// <summary>
			/// <para>Manhattan—The distance between two points measured along axes at right angles (city block); calculated by summing the (absolute) difference between the x- and y-coordinates</para>
			/// </summary>
			[GPValue("MANHATTAN_DISTANCE")]
			[Description("Manhattan")]
			Manhattan,

		}

		/// <summary>
		/// <para>Standardization</para>
		/// </summary>
		public enum StandardizationEnum 
		{
			/// <summary>
			/// <para>None—No standardization of spatial weights is applied.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>Row standardization is recommended whenever the distribution of your features is potentially biased due to sampling design or an imposed aggregation scheme.</para>
			/// </summary>
			[GPValue("ROW")]
			[Description("Row")]
			Row,

		}

		/// <summary>
		/// <para>Apply False Discovery Rate (FDR) Correction</para>
		/// </summary>
		public enum ApplyFalseDiscoveryRateFDRCorrectionEnum 
		{
			/// <summary>
			/// <para>Checked—Statistical significance will be based on the False Discovery Rate correction for a 95 percent confidence level.</para>
			/// </summary>
			[GPValue("true")]
			[Description("APPLY_FDR")]
			APPLY_FDR,

			/// <summary>
			/// <para>Unchecked—Features with p-values less than 0.05 will appear in the COType field reflecting statistically significant clusters or outliers at a 95 percent confidence level. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FDR")]
			NO_FDR,

		}

		/// <summary>
		/// <para>Number of Permutations</para>
		/// </summary>
		public enum NumberOfPermutationsEnum 
		{
			/// <summary>
			/// <para>0—Permutations are not used and a standard p-value is calculated.</para>
			/// </summary>
			[GPValue("0")]
			[Description("0")]
			_0,

			/// <summary>
			/// <para>99—With 99 permutations, the smallest possible pseudo p-value is 0.01 and all other pseudo p-values will be multiples of this value.</para>
			/// </summary>
			[GPValue("99")]
			[Description("99")]
			_99,

			/// <summary>
			/// <para>199—With 199 permutations, the smallest possible pseudo p-value is 0.005 and all other possible pseudo p-values will be multiples of this value.</para>
			/// </summary>
			[GPValue("199")]
			[Description("199")]
			_199,

			/// <summary>
			/// <para>499—With 499 permutations, the smallest possible pseudo p-value is 0.002 and all other pseudo p-values will be multiples of this value.</para>
			/// </summary>
			[GPValue("499")]
			[Description("499")]
			_499,

			/// <summary>
			/// <para>999—With 999 permutations, the smallest possible pseudo p-value is 0.001 and all other pseudo p-values will be multiples of this value.</para>
			/// </summary>
			[GPValue("999")]
			[Description("999")]
			_999,

			/// <summary>
			/// <para>9999—With 9999 permutations, the smallest possible pseudo p-value is 0.0001 and all other pseudo p-values will be multiples of this value.</para>
			/// </summary>
			[GPValue("9999")]
			[Description("9999")]
			_9999,

		}

#endregion
	}
}
