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
	/// <para>Spatially Constrained Multivariate Clustering</para>
	/// <para>Finds spatially contiguous clusters of features based on a set of feature attribute values and optional cluster size limits.</para>
	/// </summary>
	public class SpatiallyConstrainedMultivariateClustering : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The feature class or feature layer for which you want to create clusters.</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>The new output feature class created containing all features, the analysis fields specified, and a field indicating to which cluster each feature belongs.</para>
		/// </param>
		/// <param name="AnalysisFields">
		/// <para>Analysis Fields</para>
		/// <para>A list of fields that will be used to distinguish one cluster from another.</para>
		/// </param>
		public SpatiallyConstrainedMultivariateClustering(object InFeatures, object OutputFeatures, object AnalysisFields)
		{
			this.InFeatures = InFeatures;
			this.OutputFeatures = OutputFeatures;
			this.AnalysisFields = AnalysisFields;
		}

		/// <summary>
		/// <para>Tool Display Name : Spatially Constrained Multivariate Clustering</para>
		/// </summary>
		public override string DisplayName => "Spatially Constrained Multivariate Clustering";

		/// <summary>
		/// <para>Tool Name : SpatiallyConstrainedMultivariateClustering</para>
		/// </summary>
		public override string ToolName => "SpatiallyConstrainedMultivariateClustering";

		/// <summary>
		/// <para>Tool Excute Name : stats.SpatiallyConstrainedMultivariateClustering</para>
		/// </summary>
		public override string ExcuteName => "stats.SpatiallyConstrainedMultivariateClustering";

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
		public override string[] ValidEnvironments => new string[] { "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "parallelProcessingFactor", "qualifiedFieldNames", "randomGenerator", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutputFeatures, AnalysisFields, SizeConstraints, ConstraintField, MinConstraint, MaxConstraint, NumberOfClusters, SpatialConstraints, WeightsMatrixFile, NumberOfPermutations, OutputTable };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The feature class or feature layer for which you want to create clusters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The new output feature class created containing all features, the analysis fields specified, and a field indicating to which cluster each feature belongs.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Analysis Fields</para>
		/// <para>A list of fields that will be used to distinguish one cluster from another.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		public object AnalysisFields { get; set; }

		/// <summary>
		/// <para>Cluster Size Constraints</para>
		/// <para>Specifies cluster size based on number of features per group or a target attribute value per group.</para>
		/// <para>None—No cluster size constraints will be used. This is the default.</para>
		/// <para>Number of features—A minimum and maximum number of features per group will be used.</para>
		/// <para>Attribute value—A minimum and maximum attribute value per group will be used.</para>
		/// <para><see cref="SizeConstraintsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SizeConstraints { get; set; } = "NONE";

		/// <summary>
		/// <para>Constraint Field</para>
		/// <para>The attribute value to be summed per cluster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object ConstraintField { get; set; }

		/// <summary>
		/// <para>Minimum per Cluster</para>
		/// <para>The minimum number of features per cluster or the minimum attribute value per cluster. This must be a positive value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MinConstraint { get; set; }

		/// <summary>
		/// <para>Fill to Limit</para>
		/// <para>The maximum number of features per cluster or the maximum attribute value per cluster. If a maximum constraint is set, the Number of Clusters parameter is inactive. This must be a positive value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MaxConstraint { get; set; }

		/// <summary>
		/// <para>Number of Clusters</para>
		/// <para>The number of clusters to create. If this parameter is empty, the tool will evaluate the optimal number of clusters by computing a pseudo F-statistic value for clustering solutions with 2 through 30 clusters.</para>
		/// <para>This parameter will be disabled if a maximum number of features or maximum attribute value has been set.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumberOfClusters { get; set; }

		/// <summary>
		/// <para>Spatial Constraints</para>
		/// <para>Specifies how spatial relationships among features will be defined.</para>
		/// <para>Contiguity edges only—Clusters will contain contiguous polygon features. Only polygons that share an edge can be part of the same cluster.</para>
		/// <para>Contiguity edges corners— Clusters will contain contiguous polygon features. Only polygons that share an edge or a vertex can be part of the same cluster. This is the default for polygon features.</para>
		/// <para>Trimmed Delaunay triangulation— Features in the same cluster will have at least one natural neighbor in common with another feature in the cluster. Natural neighbor relationships are based on a trimmed Delaunay triangulation. Conceptually, Delaunay triangulation creates a nonoverlapping mesh of triangles from feature centroids. Each feature is a triangle node, and nodes that share edges are considered neighbors. These triangles are then clipped to a convex hull to ensure that features cannot be neighbors with any features outside the convex hull. This is the default for point features.</para>
		/// <para>Get spatial weights from file—Spatial, and optionally temporal, relationships are defined by a specified spatial weights file (.swm). Create the spatial weights matrix using the Generate Spatial Weights Matrix or Generate Network Spatial Weights tool. The path to the spatial weights file is specified by the Spatial Weights Matrix File parameter.</para>
		/// <para><see cref="SpatialConstraintsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SpatialConstraints { get; set; }

		/// <summary>
		/// <para>Spatial Weights Matrix File</para>
		/// <para>The path to a file containing spatial weights that define spatial, and potentially temporal, relationships among features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object WeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Permutations to Calculate Membership Probabilities</para>
		/// <para>The number of random permutations for the calculation of membership stability scores. If 0 (zero) is chosen, probabilities will not be calculated. Calculating these probabilities uses permutations of random spanning trees and evidence accumulation.</para>
		/// <para>This calculation can take a significant time to run for larger datasets. It is recommended that you iterate and find the optimal number of clusters for your analysis first; then calculate probabilities for your analysis in a subsequent run. Setting the Parallel Processing Factor Environment setting to 50 may improve the run time of the tool.</para>
		/// <para><see cref="NumberOfPermutationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object NumberOfPermutations { get; set; } = "0";

		/// <summary>
		/// <para>Output Table for Evaluating Number of Clusters</para>
		/// <para>The table created containing the results of the F-statistic values calculated to evaluate the optimal number of clusters. The chart created from this table can be accessed in the Contents pane under the output feature layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object OutputTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SpatiallyConstrainedMultivariateClustering SetEnviroment(object MResolution = null , object MTolerance = null , object XYResolution = null , object XYTolerance = null , object ZResolution = null , object ZTolerance = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , object parallelProcessingFactor = null , bool? qualifiedFieldNames = null , object randomGenerator = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, parallelProcessingFactor: parallelProcessingFactor, qualifiedFieldNames: qualifiedFieldNames, randomGenerator: randomGenerator, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Cluster Size Constraints</para>
		/// </summary>
		public enum SizeConstraintsEnum 
		{
			/// <summary>
			/// <para>None—No cluster size constraints will be used. This is the default.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>Number of features—A minimum and maximum number of features per group will be used.</para>
			/// </summary>
			[GPValue("NUM_FEATURES")]
			[Description("Number of features")]
			Number_of_features,

			/// <summary>
			/// <para>Attribute value—A minimum and maximum attribute value per group will be used.</para>
			/// </summary>
			[GPValue("ATTRIBUTE_VALUE")]
			[Description("Attribute value")]
			Attribute_value,

		}

		/// <summary>
		/// <para>Spatial Constraints</para>
		/// </summary>
		public enum SpatialConstraintsEnum 
		{
			/// <summary>
			/// <para>Contiguity edges only—Clusters will contain contiguous polygon features. Only polygons that share an edge can be part of the same cluster.</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_ONLY")]
			[Description("Contiguity edges only")]
			Contiguity_edges_only,

			/// <summary>
			/// <para>Contiguity edges corners— Clusters will contain contiguous polygon features. Only polygons that share an edge or a vertex can be part of the same cluster. This is the default for polygon features.</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_CORNERS")]
			[Description("Contiguity edges corners")]
			Contiguity_edges_corners,

			/// <summary>
			/// <para>Trimmed Delaunay triangulation— Features in the same cluster will have at least one natural neighbor in common with another feature in the cluster. Natural neighbor relationships are based on a trimmed Delaunay triangulation. Conceptually, Delaunay triangulation creates a nonoverlapping mesh of triangles from feature centroids. Each feature is a triangle node, and nodes that share edges are considered neighbors. These triangles are then clipped to a convex hull to ensure that features cannot be neighbors with any features outside the convex hull. This is the default for point features.</para>
			/// </summary>
			[GPValue("TRIMMED_DELAUNAY_TRIANGULATION")]
			[Description("Trimmed Delaunay triangulation")]
			Trimmed_Delaunay_triangulation,

			/// <summary>
			/// <para>Get spatial weights from file—Spatial, and optionally temporal, relationships are defined by a specified spatial weights file (.swm). Create the spatial weights matrix using the Generate Spatial Weights Matrix or Generate Network Spatial Weights tool. The path to the spatial weights file is specified by the Spatial Weights Matrix File parameter.</para>
			/// </summary>
			[GPValue("GET_SPATIAL_WEIGHTS_FROM_FILE")]
			[Description("Get spatial weights from file")]
			Get_spatial_weights_from_file,

		}

		/// <summary>
		/// <para>Permutations to Calculate Membership Probabilities</para>
		/// </summary>
		public enum NumberOfPermutationsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("0")]
			[Description("0")]
			_0,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("100")]
			[Description("100")]
			_100,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("200")]
			[Description("200")]
			_200,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("500")]
			[Description("500")]
			_500,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("1000")]
			[Description("1000")]
			_1000,

		}

#endregion
	}
}
