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
	/// <para>Generate Spatial Weights Matrix</para>
	/// <para>Constructs a spatial weights matrix (.swm) file to represent the spatial relationships among features in a dataset.</para>
	/// </summary>
	public class GenerateSpatialWeightsMatrix : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>The feature class for which spatial relationships of features will be assessed.</para>
		/// </param>
		/// <param name="UniqueIDField">
		/// <para>Unique ID Field</para>
		/// <para>An integer field containing a different value for every feature in the input feature class. If you don't have a Unique ID field, you can create one by adding an integer field to your feature class table and calculating the field values to equal the FID or OBJECTID field.</para>
		/// </param>
		/// <param name="OutputSpatialWeightsMatrixFile">
		/// <para>Output Spatial Weights Matrix File</para>
		/// <para>The full path for the spatial weights matrix file (.swm) you want to create.</para>
		/// </param>
		/// <param name="ConceptualizationOfSpatialRelationships">
		/// <para>Conceptualization of Spatial Relationships</para>
		/// <para>Specifies how spatial relationships among features are conceptualized.</para>
		/// <para>Inverse distance—The impact of one feature on another feature decreases with distance.</para>
		/// <para>Fixed distance—Everything within a specified critical distance of each feature is included in the analysis; everything outside the critical distance is excluded.</para>
		/// <para>K nearest neighbors—The closest k features are included in the analysis; k is a specified numeric parameter.</para>
		/// <para>Contiguity edges only—Polygon features that share a boundary are neighbors.</para>
		/// <para>Contiguity edges corners—Polygon features that share a boundary and/or share a node are neighbors.</para>
		/// <para>Delaunay triangulation—A mesh of nonoverlapping triangles is created from feature centroids; features associated with triangle nodes that share edges are neighbors.</para>
		/// <para>Space time window—Features within a specified critical distance and specified time interval of each other are neighbors.</para>
		/// <para>Convert table—Spatial relationships are defined in a table.</para>
		/// <para><see cref="ConceptualizationOfSpatialRelationshipsEnum"/></para>
		/// </param>
		public GenerateSpatialWeightsMatrix(object InputFeatureClass, object UniqueIDField, object OutputSpatialWeightsMatrixFile, object ConceptualizationOfSpatialRelationships)
		{
			this.InputFeatureClass = InputFeatureClass;
			this.UniqueIDField = UniqueIDField;
			this.OutputSpatialWeightsMatrixFile = OutputSpatialWeightsMatrixFile;
			this.ConceptualizationOfSpatialRelationships = ConceptualizationOfSpatialRelationships;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Spatial Weights Matrix</para>
		/// </summary>
		public override string DisplayName() => "Generate Spatial Weights Matrix";

		/// <summary>
		/// <para>Tool Name : GenerateSpatialWeightsMatrix</para>
		/// </summary>
		public override string ToolName() => "GenerateSpatialWeightsMatrix";

		/// <summary>
		/// <para>Tool Excute Name : stats.GenerateSpatialWeightsMatrix</para>
		/// </summary>
		public override string ExcuteName() => "stats.GenerateSpatialWeightsMatrix";

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
		public override object[] Parameters() => new object[] { InputFeatureClass, UniqueIDField, OutputSpatialWeightsMatrixFile, ConceptualizationOfSpatialRelationships, DistanceMethod, Exponent, ThresholdDistance, NumberOfNeighbors, RowStandardization, InputTable, DateTimeField, DateTimeIntervalType, DateTimeIntervalValue, UseZValues };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>The feature class for which spatial relationships of features will be assessed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object InputFeatureClass { get; set; }

		/// <summary>
		/// <para>Unique ID Field</para>
		/// <para>An integer field containing a different value for every feature in the input feature class. If you don't have a Unique ID field, you can create one by adding an integer field to your feature class table and calculating the field values to equal the FID or OBJECTID field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object UniqueIDField { get; set; }

		/// <summary>
		/// <para>Output Spatial Weights Matrix File</para>
		/// <para>The full path for the spatial weights matrix file (.swm) you want to create.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("swm")]
		public object OutputSpatialWeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Conceptualization of Spatial Relationships</para>
		/// <para>Specifies how spatial relationships among features are conceptualized.</para>
		/// <para>Inverse distance—The impact of one feature on another feature decreases with distance.</para>
		/// <para>Fixed distance—Everything within a specified critical distance of each feature is included in the analysis; everything outside the critical distance is excluded.</para>
		/// <para>K nearest neighbors—The closest k features are included in the analysis; k is a specified numeric parameter.</para>
		/// <para>Contiguity edges only—Polygon features that share a boundary are neighbors.</para>
		/// <para>Contiguity edges corners—Polygon features that share a boundary and/or share a node are neighbors.</para>
		/// <para>Delaunay triangulation—A mesh of nonoverlapping triangles is created from feature centroids; features associated with triangle nodes that share edges are neighbors.</para>
		/// <para>Space time window—Features within a specified critical distance and specified time interval of each other are neighbors.</para>
		/// <para>Convert table—Spatial relationships are defined in a table.</para>
		/// <para><see cref="ConceptualizationOfSpatialRelationshipsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConceptualizationOfSpatialRelationships { get; set; }

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>Specifies how distances are calculated from each feature to neighboring features.</para>
		/// <para>Euclidean—The straight-line distance between two points (as the crow flies)</para>
		/// <para>Manhattan—The distance between two points measured along axes at right angles (city block); calculated by summing the (absolute) difference between the x- and y-coordinates</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceMethod { get; set; } = "EUCLIDEAN";

		/// <summary>
		/// <para>Exponent</para>
		/// <para>Parameter for inverse distance calculation. Typical values are 1 or 2.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Exponent { get; set; } = "1";

		/// <summary>
		/// <para>Threshold Distance</para>
		/// <para>Specifies a cutoff distance for Inverse distance and Fixed distance conceptualizations of spatial relationships. Enter this value using the units specified in the environment output coordinate system. Defines the size of the space window for the Space time window conceptualization of spatial relationships.</para>
		/// <para>A value of zero indicates that no threshold distance is applied. When this parameter is left blank, a default threshold value is computed based on output feature class extent and the number of features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 999999999)]
		public object ThresholdDistance { get; set; }

		/// <summary>
		/// <para>Number of Neighbors</para>
		/// <para>An integer reflecting either the minimum or the exact number of neighbors. For K nearest neighbors, each feature will have exactly this specified number of neighbors. For Inverse distance or Fixed distance, each feature will have at least this many neighbors (the threshold distance will be temporarily extended to ensure this many neighbors, if necessary). When one of the contiguity Conceptualizations of Spatial Relationships is selected, each polygon will be assigned this minimum number of neighbors. For polygons with fewer than this number of contiguous neighbors, additional neighbors will be based on feature centroid proximity.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Row Standardization</para>
		/// <para>Row standardization is recommended whenever feature distribution is potentially biased due to sampling design or to an imposed aggregation scheme.</para>
		/// <para>Checked—Spatial weights are standardized by row. Each weight is divided by its row sum. This is the default.</para>
		/// <para>Unchecked—No standardization of spatial weights is applied.</para>
		/// <para><see cref="RowStandardizationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object RowStandardization { get; set; } = "true";

		/// <summary>
		/// <para>Input Table</para>
		/// <para>A table containing numeric weights relating every feature to every other feature in the input feature class. Required fields are the Input Feature Class, Unique ID field, NID (neighbor ID), and WEIGHT.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object InputTable { get; set; }

		/// <summary>
		/// <para>Date/Time Field</para>
		/// <para>A date field with a timestamp for each feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object DateTimeField { get; set; }

		/// <summary>
		/// <para>Date/Time Interval Type</para>
		/// <para>The units to use for measuring time.</para>
		/// <para>Seconds—Seconds</para>
		/// <para>Minutes—Minutes</para>
		/// <para>Hours—Hours</para>
		/// <para>Days—Days</para>
		/// <para>Weeks—Weeks</para>
		/// <para>Months—30 Days</para>
		/// <para>Years—Years</para>
		/// <para><see cref="DateTimeIntervalTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DateTimeIntervalType { get; set; }

		/// <summary>
		/// <para>Date/Time Interval Value</para>
		/// <para>An integer reflecting the number of time units comprising the time window.</para>
		/// <para>For example, if you select HOURS for the Date/Time Interval Type and 3 for the Date/Time Interval Value, the time window would be 3 hours; features within the specified space window and within the specified time window would be neighbors.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object DateTimeIntervalValue { get; set; }

		/// <summary>
		/// <para>Use Z values</para>
		/// <para>When input features are z-enabled, you have the option to use or ignore the z-values. Specifies whether z-coordinates are included in the construction of the spatial weights matrix.</para>
		/// <para>Checked—Z-values are used in the construction of the spatial weights matrix.</para>
		/// <para>Unchecked—Z-values are ignored and only X and Y coordinates are considered in the construction of the spatial weights matrix. This is the default.</para>
		/// <para><see cref="UseZValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UseZValues { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateSpatialWeightsMatrix SetEnviroment(object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Conceptualization of Spatial Relationships</para>
		/// </summary>
		public enum ConceptualizationOfSpatialRelationshipsEnum 
		{
			/// <summary>
			/// <para>Inverse distance—The impact of one feature on another feature decreases with distance.</para>
			/// </summary>
			[GPValue("INVERSE_DISTANCE")]
			[Description("Inverse distance")]
			Inverse_distance,

			/// <summary>
			/// <para>Fixed distance—Everything within a specified critical distance of each feature is included in the analysis; everything outside the critical distance is excluded.</para>
			/// </summary>
			[GPValue("FIXED_DISTANCE")]
			[Description("Fixed distance")]
			Fixed_distance,

			/// <summary>
			/// <para>K nearest neighbors—The closest k features are included in the analysis; k is a specified numeric parameter.</para>
			/// </summary>
			[GPValue("K_NEAREST_NEIGHBORS")]
			[Description("K nearest neighbors")]
			K_nearest_neighbors,

			/// <summary>
			/// <para>Contiguity edges only—Polygon features that share a boundary are neighbors.</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_ONLY")]
			[Description("Contiguity edges only")]
			Contiguity_edges_only,

			/// <summary>
			/// <para>Contiguity edges corners—Polygon features that share a boundary and/or share a node are neighbors.</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_CORNERS")]
			[Description("Contiguity edges corners")]
			Contiguity_edges_corners,

			/// <summary>
			/// <para>Delaunay triangulation—A mesh of nonoverlapping triangles is created from feature centroids; features associated with triangle nodes that share edges are neighbors.</para>
			/// </summary>
			[GPValue("DELAUNAY_TRIANGULATION")]
			[Description("Delaunay triangulation")]
			Delaunay_triangulation,

			/// <summary>
			/// <para>Space time window—Features within a specified critical distance and specified time interval of each other are neighbors.</para>
			/// </summary>
			[GPValue("SPACE_TIME_WINDOW")]
			[Description("Space time window")]
			Space_time_window,

			/// <summary>
			/// <para>Convert table—Spatial relationships are defined in a table.</para>
			/// </summary>
			[GPValue("CONVERT_TABLE")]
			[Description("Convert table")]
			Convert_table,

		}

		/// <summary>
		/// <para>Distance Method</para>
		/// </summary>
		public enum DistanceMethodEnum 
		{
			/// <summary>
			/// <para>Euclidean—The straight-line distance between two points (as the crow flies)</para>
			/// </summary>
			[GPValue("EUCLIDEAN")]
			[Description("Euclidean")]
			Euclidean,

			/// <summary>
			/// <para>Manhattan—The distance between two points measured along axes at right angles (city block); calculated by summing the (absolute) difference between the x- and y-coordinates</para>
			/// </summary>
			[GPValue("MANHATTAN")]
			[Description("Manhattan")]
			Manhattan,

		}

		/// <summary>
		/// <para>Row Standardization</para>
		/// </summary>
		public enum RowStandardizationEnum 
		{
			/// <summary>
			/// <para>Checked—Spatial weights are standardized by row. Each weight is divided by its row sum. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ROW_STANDARDIZATION")]
			ROW_STANDARDIZATION,

			/// <summary>
			/// <para>Unchecked—No standardization of spatial weights is applied.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_STANDARDIZATION")]
			NO_STANDARDIZATION,

		}

		/// <summary>
		/// <para>Date/Time Interval Type</para>
		/// </summary>
		public enum DateTimeIntervalTypeEnum 
		{
			/// <summary>
			/// <para>Seconds—Seconds</para>
			/// </summary>
			[GPValue("SECONDS")]
			[Description("Seconds")]
			Seconds,

			/// <summary>
			/// <para>Minutes—Minutes</para>
			/// </summary>
			[GPValue("MINUTES")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para>Hours—Hours</para>
			/// </summary>
			[GPValue("HOURS")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para>Days—Days</para>
			/// </summary>
			[GPValue("DAYS")]
			[Description("Days")]
			Days,

			/// <summary>
			/// <para>Weeks—Weeks</para>
			/// </summary>
			[GPValue("WEEKS")]
			[Description("Weeks")]
			Weeks,

			/// <summary>
			/// <para>Months—30 Days</para>
			/// </summary>
			[GPValue("MONTHS")]
			[Description("Months")]
			Months,

			/// <summary>
			/// <para>Years—Years</para>
			/// </summary>
			[GPValue("YEARS")]
			[Description("Years")]
			Years,

		}

		/// <summary>
		/// <para>Use Z values</para>
		/// </summary>
		public enum UseZValuesEnum 
		{
			/// <summary>
			/// <para>Checked—Z-values are used in the construction of the spatial weights matrix.</para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_Z_VALUES")]
			USE_Z_VALUES,

			/// <summary>
			/// <para>Unchecked—Z-values are ignored and only X and Y coordinates are considered in the construction of the spatial weights matrix. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_USE_Z_VALUES")]
			DO_NOT_USE_Z_VALUES,

		}

#endregion
	}
}
