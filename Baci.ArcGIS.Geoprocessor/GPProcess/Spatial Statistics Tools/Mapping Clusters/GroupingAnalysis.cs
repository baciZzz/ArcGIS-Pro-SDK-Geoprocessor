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
	/// <para>Grouping Analysis</para>
	/// <para>Groups features based on feature attributes and optional spatial or temporal constraints.</para>
	/// </summary>
	[Obsolete()]
	public class GroupingAnalysis : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>The feature class or feature layer for which you want to create groups.</para>
		/// </param>
		/// <param name="UniqueIDField">
		/// <para>Unique ID Field</para>
		/// <para>An integer field containing a different value for every feature in the input feature class. If you don't have a Unique ID field, you can create one by adding an integer field to your feature class table and calculating the field values to equal the FID or OBJECTID field.</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The new output feature class created containing all features, the analysis fields specified, and a field indicating to which group each feature belongs.</para>
		/// </param>
		/// <param name="NumberOfGroups">
		/// <para>Number of Groups</para>
		/// <para>The number of groups to create. The Output Report parameter will be disabled for more than 15 groups.</para>
		/// </param>
		/// <param name="AnalysisFields">
		/// <para>Analysis Fields</para>
		/// <para>A list of fields you want to use to distinguish one group from another. The Output Report parameter will be disabled for more than 15 fields.</para>
		/// </param>
		/// <param name="SpatialConstraints">
		/// <para>Spatial Constraints</para>
		/// <para>Specifies if and how spatial relationships among features should constrain the groups created.</para>
		/// <para>Contiguity edges only—Groups contain contiguous polygon features. Only polygons that share an edge can be part of the same group.</para>
		/// <para>Contiguity edges corners—Groups contain contiguous polygon features. Only polygons that share an edge or a vertex can be part of the same group.</para>
		/// <para>Delaunay triangulation—Features in the same group will have at least one natural neighbor in common with another feature in the group. Natural neighbor relationships are based on Delaunay Triangulation. Conceptually, Delaunay Triangulation creates a nonoverlapping mesh of triangles from feature centroids. Each feature is a triangle node and nodes that share edges are considered neighbors.</para>
		/// <para>K nearest neighbors—Features in the same group will be near each other; each feature will be a neighbor of at least one other feature in the group. Neighbor relationships are based on the nearest K features, where you specify an Integer value, K, for the Number of Neighbors parameter.</para>
		/// <para>Get spatial weights from file—Spatial, and optionally temporal, relationships are defined by a spatial weights file (.swm). Create the spatial weights matrix file using the Generate Spatial Weights Matrix tool or the Generate Network Spatial Weights tool.</para>
		/// <para>No spatial constraint—Features will be grouped using data space proximity only. Features do not have to be near each other in space or time to be part of the same group.</para>
		/// <para><see cref="SpatialConstraintsEnum"/></para>
		/// </param>
		public GroupingAnalysis(object InputFeatures, object UniqueIDField, object OutputFeatureClass, object NumberOfGroups, object AnalysisFields, object SpatialConstraints)
		{
			this.InputFeatures = InputFeatures;
			this.UniqueIDField = UniqueIDField;
			this.OutputFeatureClass = OutputFeatureClass;
			this.NumberOfGroups = NumberOfGroups;
			this.AnalysisFields = AnalysisFields;
			this.SpatialConstraints = SpatialConstraints;
		}

		/// <summary>
		/// <para>Tool Display Name : Grouping Analysis</para>
		/// </summary>
		public override string DisplayName => "Grouping Analysis";

		/// <summary>
		/// <para>Tool Name : GroupingAnalysis</para>
		/// </summary>
		public override string ToolName => "GroupingAnalysis";

		/// <summary>
		/// <para>Tool Excute Name : stats.GroupingAnalysis</para>
		/// </summary>
		public override string ExcuteName => "stats.GroupingAnalysis";

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
		public override object[] Parameters => new object[] { InputFeatures, UniqueIDField, OutputFeatureClass, NumberOfGroups, AnalysisFields, SpatialConstraints, DistanceMethod, NumberOfNeighbors, WeightsMatrixFile, InitializationMethod, InitializationField, OutputReportFile, EvaluateOptimalNumberOfGroups, OutputFstat, MaxFstatGroup, MaxFstat };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The feature class or feature layer for which you want to create groups.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatures { get; set; }

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
		/// <para>Output Feature Class</para>
		/// <para>The new output feature class created containing all features, the analysis fields specified, and a field indicating to which group each feature belongs.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Number of Groups</para>
		/// <para>The number of groups to create. The Output Report parameter will be disabled for more than 15 groups.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumberOfGroups { get; set; } = "2";

		/// <summary>
		/// <para>Analysis Fields</para>
		/// <para>A list of fields you want to use to distinguish one group from another. The Output Report parameter will be disabled for more than 15 fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Date")]
		public object AnalysisFields { get; set; }

		/// <summary>
		/// <para>Spatial Constraints</para>
		/// <para>Specifies if and how spatial relationships among features should constrain the groups created.</para>
		/// <para>Contiguity edges only—Groups contain contiguous polygon features. Only polygons that share an edge can be part of the same group.</para>
		/// <para>Contiguity edges corners—Groups contain contiguous polygon features. Only polygons that share an edge or a vertex can be part of the same group.</para>
		/// <para>Delaunay triangulation—Features in the same group will have at least one natural neighbor in common with another feature in the group. Natural neighbor relationships are based on Delaunay Triangulation. Conceptually, Delaunay Triangulation creates a nonoverlapping mesh of triangles from feature centroids. Each feature is a triangle node and nodes that share edges are considered neighbors.</para>
		/// <para>K nearest neighbors—Features in the same group will be near each other; each feature will be a neighbor of at least one other feature in the group. Neighbor relationships are based on the nearest K features, where you specify an Integer value, K, for the Number of Neighbors parameter.</para>
		/// <para>Get spatial weights from file—Spatial, and optionally temporal, relationships are defined by a spatial weights file (.swm). Create the spatial weights matrix file using the Generate Spatial Weights Matrix tool or the Generate Network Spatial Weights tool.</para>
		/// <para>No spatial constraint—Features will be grouped using data space proximity only. Features do not have to be near each other in space or time to be part of the same group.</para>
		/// <para><see cref="SpatialConstraintsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SpatialConstraints { get; set; }

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
		/// <para>Number of Neighbors</para>
		/// <para>This parameter is enabled whenever the Spatial Constraints parameter is K nearest neighbors or one of the contiguity methods (Contiguity edges only or Contiguity edges corners). The default number of neighbors is 8 and cannot be smaller than 2 for K nearest neighbors. This value reflects the exact number of nearest neighbor candidates to consider when building groups. A feature will not be included in a group unless one of the other features in that group is a K nearest neighbor. The default for Contiguity edges only and Contiguity edges corners is 0. For the contiguity methods, this value reflects the minimum number of neighbor candidates to consider. Additional nearby neighbors for features with less than the Number of Neighbors specified will be based on feature centroid proximity.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumberOfNeighbors { get; set; } = "8";

		/// <summary>
		/// <para>Weights Matrix File</para>
		/// <para>The path to a file containing spatial weights that define spatial relationships among features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("swm", "gwt")]
		public object WeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Initialization Method</para>
		/// <para>Specifies how initial seeds are obtained when the Spatial Constraint parameter selected is No spatial constraint. Seeds are used to grow groups. If you indicate you want three groups, for example, the analysis will begin with three seeds.</para>
		/// <para>Find seed locations—Seed features will be selected to optimize performance.</para>
		/// <para>Get seeds from field—Nonzero entries in the Initialization Field will be used as starting points to grow groups.</para>
		/// <para>Use random seeds—Initial seed features will be randomly selected.</para>
		/// <para><see cref="InitializationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InitializationMethod { get; set; } = "FIND_SEED_LOCATIONS";

		/// <summary>
		/// <para>Initialization Field</para>
		/// <para>The numeric field identifying seed features. Features with a value of 1 for this field will be used to grow groups.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object InitializationField { get; set; }

		/// <summary>
		/// <para>Output Report File</para>
		/// <para>The full path for the PDF report file to be created summarizing group characteristics. This report provides a number of graphs to help you compare the characteristics of each group. Creating the report file can add substantial processing time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("pdf")]
		public object OutputReportFile { get; set; }

		/// <summary>
		/// <para>Evaluate Optimal Number of Groups</para>
		/// <para>Specifies whether the tool will assess the optimal number of groups, 2 through 15.</para>
		/// <para>Checked—Groupings from 2 to 15 will be evaluated.</para>
		/// <para>Unchecked—No evaluation of the number of groups will be performed. This is the default.</para>
		/// <para><see cref="EvaluateOptimalNumberOfGroupsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object EvaluateOptimalNumberOfGroups { get; set; } = "false";

		/// <summary>
		/// <para>F Statistic</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object OutputFstat { get; set; }

		/// <summary>
		/// <para>Maximum F Statistic Group</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object MaxFstatGroup { get; set; }

		/// <summary>
		/// <para>Maximum F Statistic</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object MaxFstat { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GroupingAnalysis SetEnviroment(object MResolution = null , object MTolerance = null , object XYResolution = null , object XYTolerance = null , object ZResolution = null , object ZTolerance = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , bool? qualifiedFieldNames = null , object randomGenerator = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, randomGenerator: randomGenerator, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Spatial Constraints</para>
		/// </summary>
		public enum SpatialConstraintsEnum 
		{
			/// <summary>
			/// <para>Contiguity edges only—Groups contain contiguous polygon features. Only polygons that share an edge can be part of the same group.</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_ONLY")]
			[Description("Contiguity edges only")]
			Contiguity_edges_only,

			/// <summary>
			/// <para>Contiguity edges corners—Groups contain contiguous polygon features. Only polygons that share an edge or a vertex can be part of the same group.</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_CORNERS")]
			[Description("Contiguity edges corners")]
			Contiguity_edges_corners,

			/// <summary>
			/// <para>Delaunay triangulation—Features in the same group will have at least one natural neighbor in common with another feature in the group. Natural neighbor relationships are based on Delaunay Triangulation. Conceptually, Delaunay Triangulation creates a nonoverlapping mesh of triangles from feature centroids. Each feature is a triangle node and nodes that share edges are considered neighbors.</para>
			/// </summary>
			[GPValue("DELAUNAY_TRIANGULATION")]
			[Description("Delaunay triangulation")]
			Delaunay_triangulation,

			/// <summary>
			/// <para>K nearest neighbors—Features in the same group will be near each other; each feature will be a neighbor of at least one other feature in the group. Neighbor relationships are based on the nearest K features, where you specify an Integer value, K, for the Number of Neighbors parameter.</para>
			/// </summary>
			[GPValue("K_NEAREST_NEIGHBORS")]
			[Description("K nearest neighbors")]
			K_nearest_neighbors,

			/// <summary>
			/// <para>Get spatial weights from file—Spatial, and optionally temporal, relationships are defined by a spatial weights file (.swm). Create the spatial weights matrix file using the Generate Spatial Weights Matrix tool or the Generate Network Spatial Weights tool.</para>
			/// </summary>
			[GPValue("GET_SPATIAL_WEIGHTS_FROM_FILE")]
			[Description("Get spatial weights from file")]
			Get_spatial_weights_from_file,

			/// <summary>
			/// <para>No spatial constraint—Features will be grouped using data space proximity only. Features do not have to be near each other in space or time to be part of the same group.</para>
			/// </summary>
			[GPValue("NO_SPATIAL_CONSTRAINT")]
			[Description("No spatial constraint")]
			No_spatial_constraint,

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
		/// <para>Initialization Method</para>
		/// </summary>
		public enum InitializationMethodEnum 
		{
			/// <summary>
			/// <para>Find seed locations—Seed features will be selected to optimize performance.</para>
			/// </summary>
			[GPValue("FIND_SEED_LOCATIONS")]
			[Description("Find seed locations")]
			Find_seed_locations,

			/// <summary>
			/// <para>Get seeds from field—Nonzero entries in the Initialization Field will be used as starting points to grow groups.</para>
			/// </summary>
			[GPValue("GET_SEEDS_FROM_FIELD")]
			[Description("Get seeds from field")]
			Get_seeds_from_field,

			/// <summary>
			/// <para>Use random seeds—Initial seed features will be randomly selected.</para>
			/// </summary>
			[GPValue("USE_RANDOM_SEEDS")]
			[Description("Use random seeds")]
			Use_random_seeds,

		}

		/// <summary>
		/// <para>Evaluate Optimal Number of Groups</para>
		/// </summary>
		public enum EvaluateOptimalNumberOfGroupsEnum 
		{
			/// <summary>
			/// <para>Checked—Groupings from 2 to 15 will be evaluated.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EVALUATE")]
			EVALUATE,

			/// <summary>
			/// <para>Unchecked—No evaluation of the number of groups will be performed. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_EVALUATE")]
			DO_NOT_EVALUATE,

		}

#endregion
	}
}
