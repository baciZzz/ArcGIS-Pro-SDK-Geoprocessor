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
	/// <para>Hot Spot Analysis (Getis-Ord Gi*)</para>
	/// <para>Given a set of weighted features, identifies statistically significant hot spots and cold spots using the Getis-Ord Gi* statistic.</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.SpatialStatisticsTools.OptimizedHotSpotAnalysis"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.SpatialStatisticsTools.OptimizedHotSpotAnalysis))]
	public class HotSpots : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>The feature class for which hot spot analysis will be performed.</para>
		/// </param>
		/// <param name="InputField">
		/// <para>Input Field</para>
		/// <para>The numeric field (number of victims, crime rate, test scores, and so on) to be evaluated.</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class to receive the z-score and p-value results.</para>
		/// </param>
		/// <param name="ConceptualizationOfSpatialRelationships">
		/// <para>Conceptualization of Spatial Relationships</para>
		/// <para>Specifies how spatial relationships among features will be defined.</para>
		/// <para>Inverse distance—Nearby neighboring features will have a larger influence on the computations for a target feature than features that are far away.</para>
		/// <para>Inverse distance squared—Same as Inverse distance except that the slope is sharper, so influence will drop off more quickly, and only a target feature&apos;s closest neighbors will exert substantial influence on computations for that feature.</para>
		/// <para>Fixed distance band—Each feature will be analyzed within the context of neighboring features. Neighboring features inside the specified critical distance (Distance Band or Threshold Distance) will receive a weight of one and exert influence on computations for the target feature. Neighboring features outside the critical distance will receive a weight of zero and have no influence on a target feature&apos;s computations.</para>
		/// <para>Zone of indifference—Features within the specified critical distance (Distance Band or Threshold Distance) of a target feature will receive a weight of one and influence computations for that feature. Once the critical distance is exceeded, weights (and the influence a neighboring feature has on target feature computations) will diminish with distance.</para>
		/// <para>K nearest neighbors—The closest k features will be included in the analysis; k is a specified numeric parameter.</para>
		/// <para>Contiguity edges only—Only neighboring polygon features that share a boundary or overlap will influence computations for the target polygon feature.</para>
		/// <para>Contiguity edges corners—Polygon features that share a boundary, share a node, or overlap will influence computations for the target polygon feature.</para>
		/// <para>Get spatial weights from file—Spatial relationships will be defined by a specified spatial weights file. The path to the spatial weights file is specified by the Weights Matrix File parameter.</para>
		/// <para><see cref="ConceptualizationOfSpatialRelationshipsEnum"/></para>
		/// </param>
		/// <param name="DistanceMethod">
		/// <para>Distance Method</para>
		/// <para>Specifies how distances will be calculated from each feature to neighboring features.</para>
		/// <para>Euclidean—The straight-line distance between two points (as the crow flies)</para>
		/// <para>Manhattan—The distance between two points measured along axes at right angles (city block), calculated by summing the (absolute) difference between the x- and y-coordinates</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </param>
		/// <param name="Standardization">
		/// <para>Standardization</para>
		/// <para>Row standardization has no impact on this tool: results from Hot Spot Analysis (the Getis-Ord Gi* statistic) would be identical with or without row standardization. The parameter is disabled; it remains as a tool parameter only to support backward compatibility.</para>
		/// <para>None—No standardization of spatial weights is applied.</para>
		/// <para>Row—No standardization of spatial weights is applied.</para>
		/// <para><see cref="StandardizationEnum"/></para>
		/// </param>
		public HotSpots(object InputFeatureClass, object InputField, object OutputFeatureClass, object ConceptualizationOfSpatialRelationships, object DistanceMethod, object Standardization)
		{
			this.InputFeatureClass = InputFeatureClass;
			this.InputField = InputField;
			this.OutputFeatureClass = OutputFeatureClass;
			this.ConceptualizationOfSpatialRelationships = ConceptualizationOfSpatialRelationships;
			this.DistanceMethod = DistanceMethod;
			this.Standardization = Standardization;
		}

		/// <summary>
		/// <para>Tool Display Name : Hot Spot Analysis (Getis-Ord Gi*)</para>
		/// </summary>
		public override string DisplayName => "Hot Spot Analysis (Getis-Ord Gi*)";

		/// <summary>
		/// <para>Tool Name : HotSpots</para>
		/// </summary>
		public override string ToolName => "HotSpots";

		/// <summary>
		/// <para>Tool Excute Name : stats.HotSpots</para>
		/// </summary>
		public override string ExcuteName => "stats.HotSpots";

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
		public override string[] ValidEnvironments => new string[] { "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputFeatureClass, InputField, OutputFeatureClass, ConceptualizationOfSpatialRelationships, DistanceMethod, Standardization, DistanceBandOrThresholdDistance, SelfPotentialField, WeightsMatrixFile, ApplyFalseDiscoveryRateFDRCorrection, ResultsField, ProbabilityField, SourceID, NumberOfNeighbors };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>The feature class for which hot spot analysis will be performed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatureClass { get; set; }

		/// <summary>
		/// <para>Input Field</para>
		/// <para>The numeric field (number of victims, crime rate, test scores, and so on) to be evaluated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object InputField { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class to receive the z-score and p-value results.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Conceptualization of Spatial Relationships</para>
		/// <para>Specifies how spatial relationships among features will be defined.</para>
		/// <para>Inverse distance—Nearby neighboring features will have a larger influence on the computations for a target feature than features that are far away.</para>
		/// <para>Inverse distance squared—Same as Inverse distance except that the slope is sharper, so influence will drop off more quickly, and only a target feature&apos;s closest neighbors will exert substantial influence on computations for that feature.</para>
		/// <para>Fixed distance band—Each feature will be analyzed within the context of neighboring features. Neighboring features inside the specified critical distance (Distance Band or Threshold Distance) will receive a weight of one and exert influence on computations for the target feature. Neighboring features outside the critical distance will receive a weight of zero and have no influence on a target feature&apos;s computations.</para>
		/// <para>Zone of indifference—Features within the specified critical distance (Distance Band or Threshold Distance) of a target feature will receive a weight of one and influence computations for that feature. Once the critical distance is exceeded, weights (and the influence a neighboring feature has on target feature computations) will diminish with distance.</para>
		/// <para>K nearest neighbors—The closest k features will be included in the analysis; k is a specified numeric parameter.</para>
		/// <para>Contiguity edges only—Only neighboring polygon features that share a boundary or overlap will influence computations for the target polygon feature.</para>
		/// <para>Contiguity edges corners—Polygon features that share a boundary, share a node, or overlap will influence computations for the target polygon feature.</para>
		/// <para>Get spatial weights from file—Spatial relationships will be defined by a specified spatial weights file. The path to the spatial weights file is specified by the Weights Matrix File parameter.</para>
		/// <para><see cref="ConceptualizationOfSpatialRelationshipsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConceptualizationOfSpatialRelationships { get; set; } = "FIXED_DISTANCE_BAND";

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>Specifies how distances will be calculated from each feature to neighboring features.</para>
		/// <para>Euclidean—The straight-line distance between two points (as the crow flies)</para>
		/// <para>Manhattan—The distance between two points measured along axes at right angles (city block), calculated by summing the (absolute) difference between the x- and y-coordinates</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceMethod { get; set; } = "EUCLIDEAN_DISTANCE";

		/// <summary>
		/// <para>Standardization</para>
		/// <para>Row standardization has no impact on this tool: results from Hot Spot Analysis (the Getis-Ord Gi* statistic) would be identical with or without row standardization. The parameter is disabled; it remains as a tool parameter only to support backward compatibility.</para>
		/// <para>None—No standardization of spatial weights is applied.</para>
		/// <para>Row—No standardization of spatial weights is applied.</para>
		/// <para><see cref="StandardizationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Standardization { get; set; } = "ROW";

		/// <summary>
		/// <para>Distance Band or Threshold Distance</para>
		/// <para>Specifies a cutoff distance for the inverse distance and fixed distance options. Features outside the specified cutoff for a target feature will be ignored in analyses for that feature. However, for Zone of indifference, the influence of features outside the given distance will be reduced with distance, while those inside the distance threshold will be equally considered. The distance value entered should match that of the output coordinate system.</para>
		/// <para>For the inverse distance conceptualizations of spatial relationships, a value of 0 indicates that no threshold distance will be applied; when this parameter is left blank, a default threshold value will be computed and applied. The default value is the Euclidean distance, which ensures that every feature has at least one neighbor.</para>
		/// <para>This parameter has no effect when polygon contiguity (Contiguity edges only or Contiguity edges corners) or Get spatial weights from file spatial conceptualization is selected.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain()]
		public object DistanceBandOrThresholdDistance { get; set; }

		/// <summary>
		/// <para>Self Potential Field</para>
		/// <para>The field representing self potential: the distance or weight between a feature and itself.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object SelfPotentialField { get; set; }

		/// <summary>
		/// <para>Weights Matrix File</para>
		/// <para>The path to a file containing weights that define spatial, and potentially temporal, relationships among features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object WeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Apply False Discovery Rate (FDR) Correction</para>
		/// <para>Specifies whether statistical significance will be assessed with or without FDR correction.</para>
		/// <para>Checked—Statistical significance will be based on the FDR correction.</para>
		/// <para>Unchecked—Statistical significance will not be based on the FDR correction; it will be based on the p-value and z-score fields. This is the default.</para>
		/// <para><see cref="ApplyFalseDiscoveryRateFDRCorrectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ApplyFalseDiscoveryRateFDRCorrection { get; set; } = "false";

		/// <summary>
		/// <para>Results Field</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[Field()]
		public object ResultsField { get; set; } = "GiZScore";

		/// <summary>
		/// <para>Probability Field</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[Field()]
		public object ProbabilityField { get; set; } = "GiPValue";

		/// <summary>
		/// <para>Source_ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[Field()]
		public object SourceID { get; set; } = "SOURCE_ID";

		/// <summary>
		/// <para>Number of Neighbors</para>
		/// <para>An integer specifying the number of neighbors to include in the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain()]
		public object NumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public HotSpots SetEnviroment(object MResolution = null , object MTolerance = null , object XYResolution = null , object XYTolerance = null , object ZResolution = null , object ZTolerance = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , bool? qualifiedFieldNames = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Conceptualization of Spatial Relationships</para>
		/// </summary>
		public enum ConceptualizationOfSpatialRelationshipsEnum 
		{
			/// <summary>
			/// <para>Inverse distance—Nearby neighboring features will have a larger influence on the computations for a target feature than features that are far away.</para>
			/// </summary>
			[GPValue("INVERSE_DISTANCE")]
			[Description("Inverse distance")]
			Inverse_distance,

			/// <summary>
			/// <para>Inverse distance squared—Same as Inverse distance except that the slope is sharper, so influence will drop off more quickly, and only a target feature&apos;s closest neighbors will exert substantial influence on computations for that feature.</para>
			/// </summary>
			[GPValue("INVERSE_DISTANCE_SQUARED")]
			[Description("Inverse distance squared")]
			Inverse_distance_squared,

			/// <summary>
			/// <para>Fixed distance band—Each feature will be analyzed within the context of neighboring features. Neighboring features inside the specified critical distance (Distance Band or Threshold Distance) will receive a weight of one and exert influence on computations for the target feature. Neighboring features outside the critical distance will receive a weight of zero and have no influence on a target feature&apos;s computations.</para>
			/// </summary>
			[GPValue("FIXED_DISTANCE_BAND")]
			[Description("Fixed distance band")]
			Fixed_distance_band,

			/// <summary>
			/// <para>Zone of indifference—Features within the specified critical distance (Distance Band or Threshold Distance) of a target feature will receive a weight of one and influence computations for that feature. Once the critical distance is exceeded, weights (and the influence a neighboring feature has on target feature computations) will diminish with distance.</para>
			/// </summary>
			[GPValue("ZONE_OF_INDIFFERENCE")]
			[Description("Zone of indifference")]
			Zone_of_indifference,

			/// <summary>
			/// <para>K nearest neighbors—The closest k features will be included in the analysis; k is a specified numeric parameter.</para>
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
			/// <para>Get spatial weights from file—Spatial relationships will be defined by a specified spatial weights file. The path to the spatial weights file is specified by the Weights Matrix File parameter.</para>
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
			/// <para>Manhattan—The distance between two points measured along axes at right angles (city block), calculated by summing the (absolute) difference between the x- and y-coordinates</para>
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
			/// <para>Row standardization has no impact on this tool: results from Hot Spot Analysis (the Getis-Ord Gi* statistic) would be identical with or without row standardization. The parameter is disabled; it remains as a tool parameter only to support backward compatibility.</para>
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
			/// <para>Checked—Statistical significance will be based on the FDR correction.</para>
			/// </summary>
			[GPValue("true")]
			[Description("APPLY_FDR")]
			APPLY_FDR,

			/// <summary>
			/// <para>Unchecked—Statistical significance will not be based on the FDR correction; it will be based on the p-value and z-score fields. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FDR")]
			NO_FDR,

		}

#endregion
	}
}
