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
	/// <para>Generate Spatial Weights Matrix</para>
	/// <para>Generates a spatial weights matrix file (.swm) to represent the spatial relationships among features in a dataset.</para>
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
		/// <para>The full path for the output spatial weights matrix file (.swm).</para>
		/// </param>
		/// <param name="ConceptualizationOfSpatialRelationships">
		/// <para>Conceptualization of Spatial Relationships</para>
		/// <para>Specifies how spatial relationships among features will be conceptualized.</para>
		/// <para>Inverse distance—The impact of one feature on another feature will decrease with distance.</para>
		/// <para>Fixed distance—Everything within a specified critical distance of each feature will be included in the analysis; everything outside the critical distance will be excluded.</para>
		/// <para>K nearest neighbors—The closest k features will be included in the analysis; k is a specified numeric parameter.</para>
		/// <para>Contiguity edges only—Polygon features that share a boundary will be neighbors.</para>
		/// <para>Contiguity edges corners—Polygon features that share a boundary or share a node will be neighbors.</para>
		/// <para>Delaunay triangulation—A mesh of nonoverlapping triangles will be created from feature centroids, and features associated with triangle nodes that share edges will be neighbors.</para>
		/// <para>Space time window—Features within a specified critical distance and specified time interval of each other will be neighbors.</para>
		/// <para>Convert table—Spatial relationships will be defined in a table.</para>
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
		public override object[] Parameters() => new object[] { InputFeatureClass, UniqueIDField, OutputSpatialWeightsMatrixFile, ConceptualizationOfSpatialRelationships, DistanceMethod!, Exponent!, ThresholdDistance!, NumberOfNeighbors!, RowStandardization!, InputTable!, DateTimeField!, DateTimeIntervalType!, DateTimeIntervalValue!, UseZValues! };

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
		/// <para>The full path for the output spatial weights matrix file (.swm).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("swm")]
		public object OutputSpatialWeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Conceptualization of Spatial Relationships</para>
		/// <para>Specifies how spatial relationships among features will be conceptualized.</para>
		/// <para>Inverse distance—The impact of one feature on another feature will decrease with distance.</para>
		/// <para>Fixed distance—Everything within a specified critical distance of each feature will be included in the analysis; everything outside the critical distance will be excluded.</para>
		/// <para>K nearest neighbors—The closest k features will be included in the analysis; k is a specified numeric parameter.</para>
		/// <para>Contiguity edges only—Polygon features that share a boundary will be neighbors.</para>
		/// <para>Contiguity edges corners—Polygon features that share a boundary or share a node will be neighbors.</para>
		/// <para>Delaunay triangulation—A mesh of nonoverlapping triangles will be created from feature centroids, and features associated with triangle nodes that share edges will be neighbors.</para>
		/// <para>Space time window—Features within a specified critical distance and specified time interval of each other will be neighbors.</para>
		/// <para>Convert table—Spatial relationships will be defined in a table.</para>
		/// <para><see cref="ConceptualizationOfSpatialRelationshipsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConceptualizationOfSpatialRelationships { get; set; }

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>Specifies how distances will be calculated from each feature to neighboring features.</para>
		/// <para>Euclidean—The straight-line distance between two points (as the crow flies) will be calculated. This is the default.</para>
		/// <para>Manhattan—The distance between two points measured along axes at right angles (city block) will be calculated by summing the (absolute) difference between the x- and y-coordinates.</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DistanceMethod { get; set; } = "EUCLIDEAN";

		/// <summary>
		/// <para>Exponent</para>
		/// <para>The value for inverse distance calculation. A typical value is 1 or 2.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? Exponent { get; set; } = "1";

		/// <summary>
		/// <para>Threshold Distance</para>
		/// <para>The cutoff distance for the Conceptualization of Spatial Relationships parameter&apos;s Inverse distance and Fixed distance options. Enter this value using the units specified in the environment output coordinate system. This defines the size of the space window for the Space time window option.</para>
		/// <para>When this parameter is left blank, a default threshold value is computed based on the output feature class extent and the number of features. For the inverse distance conceptualization of spatial relationships, a value of zero indicates that no threshold distance will be applied and all features will be neighbors of every other feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 999999999)]
		public object? ThresholdDistance { get; set; }

		/// <summary>
		/// <para>Number of Neighbors</para>
		/// <para>An integer reflecting either the minimum or the exact number of neighbors. When the Conceptualization of Spatial Relationships parameter is set to K nearest neighbors, each feature will have exactly this specified number of neighbors. For the Inverse distance or Fixed distance option, each feature will have at least this many neighbors (the threshold distance will be temporarily extended to ensure this many neighbors, if necessary). When the Contiguity edges only or Contiguity edges corners option is chosen, each polygon will be assigned this minimum number of neighbors. For polygons with fewer than this number of contiguous neighbors, additional neighbors will be based on feature centroid proximity.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Row Standardization</para>
		/// <para>Specifies whether spatial weights will be standardized by row. Row standardization is recommended whenever feature distribution is potentially biased due to sampling design or to an imposed aggregation scheme.</para>
		/// <para>Checked—Spatial weights will be standardized by row. Each weight is divided by its row sum. This is the default.</para>
		/// <para>Unchecked—No standardization of spatial weights will be applied.</para>
		/// <para><see cref="RowStandardizationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? RowStandardization { get; set; } = "true";

		/// <summary>
		/// <para>Input Table</para>
		/// <para>A table containing numeric weights relating every feature to every other feature in the input feature class. Required fields for the table are the Unique ID Field parameter value, NID (neighbor ID), and WEIGHT.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? InputTable { get; set; }

		/// <summary>
		/// <para>Date/Time Field</para>
		/// <para>A date field with a time stamp for each feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? DateTimeField { get; set; }

		/// <summary>
		/// <para>Date/Time Interval Type</para>
		/// <para>Specifies the units that will be used for measuring time.</para>
		/// <para>Seconds—The unit will be seconds.</para>
		/// <para>Minutes—The unit will be minutes.</para>
		/// <para>Hours—The unit will be hours.</para>
		/// <para>Days—The unit will be days.</para>
		/// <para>Weeks—The unit will be weeks.</para>
		/// <para>Months—The unit will be 30 days.</para>
		/// <para>Years—The unit will be years.</para>
		/// <para><see cref="DateTimeIntervalTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DateTimeIntervalType { get; set; }

		/// <summary>
		/// <para>Date/Time Interval Value</para>
		/// <para>An integer reflecting the number of time units comprising the time window.</para>
		/// <para>For example, if you choose Hours for the Date/Time Interval Type parameter and specify 3 for the Date/Time Interval Value parameter, the time window will be 3 hours; features within the specified space window and within the specified time window will be neighbors.</para>
		/// <para>For example, if you choose HOURS for the Date_Time_Interval_Type parameter and specify 3 for the Date_Time_Interval_Value parameter, the time window will be 3 hours; features within the specified space window and within the specified time window will be neighbors.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? DateTimeIntervalValue { get; set; }

		/// <summary>
		/// <para>Use Z values</para>
		/// <para>Specifies whether z-coordinates will be used in the construction of the spatial weights matrix if the input features are z-enabled.</para>
		/// <para>Checked—Z-values will be used in the construction of the spatial weights matrix.</para>
		/// <para>Unchecked—Z-values will not be used; they will be ignored and only x- and y-coordinates will be considered in the construction of the spatial weights matrix. This is the default.</para>
		/// <para><see cref="UseZValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? UseZValues { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateSpatialWeightsMatrix SetEnviroment(object? geographicTransformations = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? workspace = null)
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
			/// <para>Inverse distance—The impact of one feature on another feature will decrease with distance.</para>
			/// </summary>
			[GPValue("INVERSE_DISTANCE")]
			[Description("Inverse distance")]
			Inverse_distance,

			/// <summary>
			/// <para>Fixed distance—Everything within a specified critical distance of each feature will be included in the analysis; everything outside the critical distance will be excluded.</para>
			/// </summary>
			[GPValue("FIXED_DISTANCE")]
			[Description("Fixed distance")]
			Fixed_distance,

			/// <summary>
			/// <para>K nearest neighbors—The closest k features will be included in the analysis; k is a specified numeric parameter.</para>
			/// </summary>
			[GPValue("K_NEAREST_NEIGHBORS")]
			[Description("K nearest neighbors")]
			K_nearest_neighbors,

			/// <summary>
			/// <para>Contiguity edges only—Polygon features that share a boundary will be neighbors.</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_ONLY")]
			[Description("Contiguity edges only")]
			Contiguity_edges_only,

			/// <summary>
			/// <para>Contiguity edges corners—Polygon features that share a boundary or share a node will be neighbors.</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_CORNERS")]
			[Description("Contiguity edges corners")]
			Contiguity_edges_corners,

			/// <summary>
			/// <para>Delaunay triangulation—A mesh of nonoverlapping triangles will be created from feature centroids, and features associated with triangle nodes that share edges will be neighbors.</para>
			/// </summary>
			[GPValue("DELAUNAY_TRIANGULATION")]
			[Description("Delaunay triangulation")]
			Delaunay_triangulation,

			/// <summary>
			/// <para>Space time window—Features within a specified critical distance and specified time interval of each other will be neighbors.</para>
			/// </summary>
			[GPValue("SPACE_TIME_WINDOW")]
			[Description("Space time window")]
			Space_time_window,

			/// <summary>
			/// <para>Convert table—Spatial relationships will be defined in a table.</para>
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
			/// <para>Euclidean—The straight-line distance between two points (as the crow flies) will be calculated. This is the default.</para>
			/// </summary>
			[GPValue("EUCLIDEAN")]
			[Description("Euclidean")]
			Euclidean,

			/// <summary>
			/// <para>Manhattan—The distance between two points measured along axes at right angles (city block) will be calculated by summing the (absolute) difference between the x- and y-coordinates.</para>
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
			/// <para>Checked—Spatial weights will be standardized by row. Each weight is divided by its row sum. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ROW_STANDARDIZATION")]
			ROW_STANDARDIZATION,

			/// <summary>
			/// <para>Unchecked—No standardization of spatial weights will be applied.</para>
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
			/// <para>Seconds—The unit will be seconds.</para>
			/// </summary>
			[GPValue("SECONDS")]
			[Description("Seconds")]
			Seconds,

			/// <summary>
			/// <para>Minutes—The unit will be minutes.</para>
			/// </summary>
			[GPValue("MINUTES")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para>Hours—The unit will be hours.</para>
			/// </summary>
			[GPValue("HOURS")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para>Days—The unit will be days.</para>
			/// </summary>
			[GPValue("DAYS")]
			[Description("Days")]
			Days,

			/// <summary>
			/// <para>Weeks—The unit will be weeks.</para>
			/// </summary>
			[GPValue("WEEKS")]
			[Description("Weeks")]
			Weeks,

			/// <summary>
			/// <para>Months—The unit will be 30 days.</para>
			/// </summary>
			[GPValue("MONTHS")]
			[Description("Months")]
			Months,

			/// <summary>
			/// <para>Years—The unit will be years.</para>
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
			/// <para>Checked—Z-values will be used in the construction of the spatial weights matrix.</para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_Z_VALUES")]
			USE_Z_VALUES,

			/// <summary>
			/// <para>Unchecked—Z-values will not be used; they will be ignored and only x- and y-coordinates will be considered in the construction of the spatial weights matrix. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_USE_Z_VALUES")]
			DO_NOT_USE_Z_VALUES,

		}

#endregion
	}
}
