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
	/// <para>Spatial Autocorrelation (Global Moran's I)</para>
	/// <para>Spatial Autocorrelation (Global Moran's I)</para>
	/// <para>Measures spatial autocorrelation based on feature locations and attribute values using the Global Moran's I statistic.</para>
	/// </summary>
	public class SpatialAutocorrelation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>The feature class for which spatial autocorrelation will be calculated.</para>
		/// </param>
		/// <param name="InputField">
		/// <para>Input Field</para>
		/// <para>The numeric field used in assessing spatial autocorrelation.</para>
		/// </param>
		/// <param name="ConceptualizationOfSpatialRelationships">
		/// <para>Conceptualization of Spatial Relationships</para>
		/// <para>Specifies how spatial relationships among features are defined.</para>
		/// <para>Inverse distance—Nearby neighboring features have a larger influence on the computations for a target feature than features that are far away.</para>
		/// <para>Inverse distance squared—This is the same as Inverse distance except that the slope is sharper, so influence drops off more quickly, and only a target feature&apos;s closest neighbors will exert substantial influence on computations for that feature.</para>
		/// <para>Fixed distance band—Each feature is analyzed within the context of neighboring features. Neighboring features inside the specified critical distance (Distance Band or Threshold Distance) receive a weight of one and exert influence on computations for the target feature. Neighboring features outside the critical distance receive a weight of zero and have no influence on a target feature&apos;s computations.</para>
		/// <para>Zone of indifference—Features within the specified critical distance (Distance Band or Threshold Distance) of a target feature receive a weight of one and influence computations for that feature. Once the critical distance is exceeded, weights (and the influence a neighboring feature has on target feature computations) diminish with distance.</para>
		/// <para>K nearest neighbors—The closest k features are included in the analysis. The number of neighbors (k) to include in the analysis is specified by the Number of Neighbors parameter.</para>
		/// <para>Contiguity edges only—Only neighboring polygon features that share a boundary or overlap will influence computations for the target polygon feature.</para>
		/// <para>Contiguity edges corners—Polygon features that share a boundary, share a node, or overlap will influence computations for the target polygon feature.</para>
		/// <para>Get spatial weights from file—Spatial relationships are defined by a specified spatial weights file. The path to the spatial weights file is specified by the Weights Matrix File parameter.</para>
		/// <para><see cref="ConceptualizationOfSpatialRelationshipsEnum"/></para>
		/// </param>
		/// <param name="DistanceMethod">
		/// <para>Distance Method</para>
		/// <para>Specifies how distances are calculated from each feature to neighboring features.</para>
		/// <para>Euclidean—The straight-line distance between two points (as the crow flies) will be used.</para>
		/// <para>Manhattan—The distance between two points measured along axes at right angles (city block) will be used. This is calculated by summing the (absolute) difference between the x- and y-coordinates</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </param>
		/// <param name="Standardization">
		/// <para>Standardization</para>
		/// <para>Specifies whether standardization of spatial weights will be applied. Row standardization is recommended whenever the distribution of your features is potentially biased due to sampling design or an imposed aggregation scheme.</para>
		/// <para>None—No standardization of spatial weights is applied.</para>
		/// <para>Row—Spatial weights are standardized; each weight is divided by its row sum (the sum of the weights of all neighboring features). This is the default.</para>
		/// <para><see cref="StandardizationEnum"/></para>
		/// </param>
		public SpatialAutocorrelation(object InputFeatureClass, object InputField, object ConceptualizationOfSpatialRelationships, object DistanceMethod, object Standardization)
		{
			this.InputFeatureClass = InputFeatureClass;
			this.InputField = InputField;
			this.ConceptualizationOfSpatialRelationships = ConceptualizationOfSpatialRelationships;
			this.DistanceMethod = DistanceMethod;
			this.Standardization = Standardization;
		}

		/// <summary>
		/// <para>Tool Display Name : Spatial Autocorrelation (Global Moran's I)</para>
		/// </summary>
		public override string DisplayName() => "Spatial Autocorrelation (Global Moran's I)";

		/// <summary>
		/// <para>Tool Name : SpatialAutocorrelation</para>
		/// </summary>
		public override string ToolName() => "SpatialAutocorrelation";

		/// <summary>
		/// <para>Tool Excute Name : stats.SpatialAutocorrelation</para>
		/// </summary>
		public override string ExcuteName() => "stats.SpatialAutocorrelation";

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
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatureClass, InputField, GenerateReport!, ConceptualizationOfSpatialRelationships, DistanceMethod, Standardization, DistanceBandOrThresholdDistance!, WeightsMatrixFile!, Index!, Zscore!, Pvalue!, ReportFile!, NumberOfNeighbors! };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>The feature class for which spatial autocorrelation will be calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatureClass { get; set; }

		/// <summary>
		/// <para>Input Field</para>
		/// <para>The numeric field used in assessing spatial autocorrelation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object InputField { get; set; }

		/// <summary>
		/// <para>Generate Report</para>
		/// <para>Specifies whether the tool will create a graphical summary of results.</para>
		/// <para>Checked—A graphical summary will be created as an HTML file.</para>
		/// <para>Unchecked—No graphical summary will be created. This is the default.</para>
		/// <para><see cref="GenerateReportEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? GenerateReport { get; set; }

		/// <summary>
		/// <para>Conceptualization of Spatial Relationships</para>
		/// <para>Specifies how spatial relationships among features are defined.</para>
		/// <para>Inverse distance—Nearby neighboring features have a larger influence on the computations for a target feature than features that are far away.</para>
		/// <para>Inverse distance squared—This is the same as Inverse distance except that the slope is sharper, so influence drops off more quickly, and only a target feature&apos;s closest neighbors will exert substantial influence on computations for that feature.</para>
		/// <para>Fixed distance band—Each feature is analyzed within the context of neighboring features. Neighboring features inside the specified critical distance (Distance Band or Threshold Distance) receive a weight of one and exert influence on computations for the target feature. Neighboring features outside the critical distance receive a weight of zero and have no influence on a target feature&apos;s computations.</para>
		/// <para>Zone of indifference—Features within the specified critical distance (Distance Band or Threshold Distance) of a target feature receive a weight of one and influence computations for that feature. Once the critical distance is exceeded, weights (and the influence a neighboring feature has on target feature computations) diminish with distance.</para>
		/// <para>K nearest neighbors—The closest k features are included in the analysis. The number of neighbors (k) to include in the analysis is specified by the Number of Neighbors parameter.</para>
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
		/// <para>Euclidean—The straight-line distance between two points (as the crow flies) will be used.</para>
		/// <para>Manhattan—The distance between two points measured along axes at right angles (city block) will be used. This is calculated by summing the (absolute) difference between the x- and y-coordinates</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceMethod { get; set; } = "EUCLIDEAN_DISTANCE";

		/// <summary>
		/// <para>Standardization</para>
		/// <para>Specifies whether standardization of spatial weights will be applied. Row standardization is recommended whenever the distribution of your features is potentially biased due to sampling design or an imposed aggregation scheme.</para>
		/// <para>None—No standardization of spatial weights is applied.</para>
		/// <para>Row—Spatial weights are standardized; each weight is divided by its row sum (the sum of the weights of all neighboring features). This is the default.</para>
		/// <para><see cref="StandardizationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Standardization { get; set; } = "ROW";

		/// <summary>
		/// <para>Distance Band or Threshold Distance</para>
		/// <para>The cutoff distance for the various inverse distance and fixed distance options. Features outside the specified cutoff for a target feature are ignored in analyses for that feature. However, for Zone of indifference, the influence of features outside the given distance is reduced with distance, while those inside the distance threshold are equally considered. The distance value entered should match that of the output coordinate system.</para>
		/// <para>For the inverse distance conceptualizations of spatial relationships, a value of 0 indicates that no threshold distance is applied; when this parameter is left blank, a default threshold value is computed and applied. This default value is the Euclidean distance, which ensures that every feature has at least one neighbor.</para>
		/// <para>This parameter has no effect when polygon contiguity (Contiguity edges only or Contiguity edges corners) or Get spatial weights from file spatial conceptualization is selected.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 999999999999999)]
		public object? DistanceBandOrThresholdDistance { get; set; }

		/// <summary>
		/// <para>Weights Matrix File</para>
		/// <para>The path to a file containing weights that define spatial, and potentially temporal, relationships among features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("swm", "gwt", "txt")]
		public object? WeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Index</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object? Index { get; set; }

		/// <summary>
		/// <para>ZScore</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object? Zscore { get; set; }

		/// <summary>
		/// <para>PValue</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object? Pvalue { get; set; }

		/// <summary>
		/// <para>Report File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? ReportFile { get; set; }

		/// <summary>
		/// <para>Number of Neighbors</para>
		/// <para>An integer specifying the number of neighbors to include in the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 1000)]
		public object? NumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SpatialAutocorrelation SetEnviroment(object? geographicTransformations = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Generate Report</para>
		/// </summary>
		public enum GenerateReportEnum 
		{
			/// <summary>
			/// <para>Checked—A graphical summary will be created as an HTML file.</para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERATE_REPORT")]
			GENERATE_REPORT,

			/// <summary>
			/// <para>Unchecked—No graphical summary will be created. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_REPORT")]
			NO_REPORT,

		}

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
			/// <para>Inverse distance squared—This is the same as Inverse distance except that the slope is sharper, so influence drops off more quickly, and only a target feature&apos;s closest neighbors will exert substantial influence on computations for that feature.</para>
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
			/// <para>K nearest neighbors—The closest k features are included in the analysis. The number of neighbors (k) to include in the analysis is specified by the Number of Neighbors parameter.</para>
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
			/// <para>Euclidean—The straight-line distance between two points (as the crow flies) will be used.</para>
			/// </summary>
			[GPValue("EUCLIDEAN_DISTANCE")]
			[Description("Euclidean")]
			Euclidean,

			/// <summary>
			/// <para>Manhattan—The distance between two points measured along axes at right angles (city block) will be used. This is calculated by summing the (absolute) difference between the x- and y-coordinates</para>
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
			/// <para>Row—Spatial weights are standardized; each weight is divided by its row sum (the sum of the weights of all neighboring features). This is the default.</para>
			/// </summary>
			[GPValue("ROW")]
			[Description("Row")]
			Row,

		}

#endregion
	}
}
