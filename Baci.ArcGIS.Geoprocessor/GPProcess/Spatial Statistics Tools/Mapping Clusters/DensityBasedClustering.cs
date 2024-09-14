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
	/// <para>Density-based Clustering</para>
	/// <para>Density-based Clustering</para>
	/// <para>Finds clusters of point features within surrounding noise based on their spatial distribution. Time can also be incorporated to find space-time clusters.</para>
	/// </summary>
	public class DensityBasedClustering : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Point Features</para>
		/// <para>The point features for which density-based clustering will be performed.</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>The output feature class that will receive the cluster results.</para>
		/// </param>
		/// <param name="ClusterMethod">
		/// <para>Clustering Method</para>
		/// <para>Specifies the method that will be used to define clusters.</para>
		/// <para>Defined distance (DBSCAN)— A specified distance will be used to separate dense clusters from sparser noise. DBSCAN is the fastest of the clustering methods but is only appropriate if there is a very clear distance to use that works well to define all clusters that may be present. This results in clusters that have similar densities.</para>
		/// <para>Self-adjusting (HDBSCAN)— Varying distances will be used to separate clusters of varying densities from sparser noise. HDBSCAN is the most data-driven of the clustering methods and requires the least user input.</para>
		/// <para>Multi-scale (OPTICS)—The distance between neighbors and a reachability plot will be used to separate clusters of varying densities from noise. OPTICS offers the most flexibility in fine-tuning the clusters that are detected, though it is computationally intensive, particularly with a large search distance.</para>
		/// <para><see cref="ClusterMethodEnum"/></para>
		/// </param>
		/// <param name="MinFeaturesCluster">
		/// <para>Minimum Features per Cluster</para>
		/// <para>The minimum number of points that will be considered a cluster. Any cluster with fewer points than the number provided will be considered noise.</para>
		/// </param>
		public DensityBasedClustering(object InFeatures, object OutputFeatures, object ClusterMethod, object MinFeaturesCluster)
		{
			this.InFeatures = InFeatures;
			this.OutputFeatures = OutputFeatures;
			this.ClusterMethod = ClusterMethod;
			this.MinFeaturesCluster = MinFeaturesCluster;
		}

		/// <summary>
		/// <para>Tool Display Name : Density-based Clustering</para>
		/// </summary>
		public override string DisplayName() => "Density-based Clustering";

		/// <summary>
		/// <para>Tool Name : DensityBasedClustering</para>
		/// </summary>
		public override string ToolName() => "DensityBasedClustering";

		/// <summary>
		/// <para>Tool Excute Name : stats.DensityBasedClustering</para>
		/// </summary>
		public override string ExcuteName() => "stats.DensityBasedClustering";

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
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "outputZFlag", "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutputFeatures, ClusterMethod, MinFeaturesCluster, SearchDistance!, ClusterSensitivity!, TimeField!, SearchTimeInterval! };

		/// <summary>
		/// <para>Input Point Features</para>
		/// <para>The point features for which density-based clustering will be performed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The output feature class that will receive the cluster results.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Clustering Method</para>
		/// <para>Specifies the method that will be used to define clusters.</para>
		/// <para>Defined distance (DBSCAN)— A specified distance will be used to separate dense clusters from sparser noise. DBSCAN is the fastest of the clustering methods but is only appropriate if there is a very clear distance to use that works well to define all clusters that may be present. This results in clusters that have similar densities.</para>
		/// <para>Self-adjusting (HDBSCAN)— Varying distances will be used to separate clusters of varying densities from sparser noise. HDBSCAN is the most data-driven of the clustering methods and requires the least user input.</para>
		/// <para>Multi-scale (OPTICS)—The distance between neighbors and a reachability plot will be used to separate clusters of varying densities from noise. OPTICS offers the most flexibility in fine-tuning the clusters that are detected, though it is computationally intensive, particularly with a large search distance.</para>
		/// <para><see cref="ClusterMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ClusterMethod { get; set; }

		/// <summary>
		/// <para>Minimum Features per Cluster</para>
		/// <para>The minimum number of points that will be considered a cluster. Any cluster with fewer points than the number provided will be considered noise.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 100000000)]
		public object MinFeaturesCluster { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>The maximum distance that will be considered.</para>
		/// <para>For the Clustering Method parameter&apos;s Defined distance (DBSCAN) option, the Minimum Features per Cluster parameter value must be found within this distance for cluster membership. Individual clusters will be separated by at least this distance. If a point is located farther than this distance from the next closest point in the cluster, it will not be included in the cluster.</para>
		/// <para>For the Clustering Method parameter&apos;s Multi-scale (OPTICS) option, this parameter is optional and is used as the maximum search distance when creating the reachability plot. For OPTICS, the reachability plot, combined with the Cluster Sensitivity parameter value, determines cluster membership. If no distance is specified, the tool will search all distances, which will increase processing time.</para>
		/// <para>If left blank, the default distance used will be the highest core distance found in the dataset, excluding those core distances in the top 1 percent (the most extreme core distances). If the Time Field parameter value is provided, a search distance must be provided and does not include a default value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? SearchDistance { get; set; }

		/// <summary>
		/// <para>Cluster Sensitivity</para>
		/// <para>An integer between 0 and 100 that determines the compactness of clusters. A number close to 100 will result in a higher number of dense clusters. A number close to 0 will result in fewer, less compact clusters. If left blank, the tool will find a sensitivity value using the Kullback-Leibler divergence that finds the value in which adding more clusters does not add additional information.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 100)]
		public object? ClusterSensitivity { get; set; }

		/// <summary>
		/// <para>Time Field</para>
		/// <para>The field containing the time stamp for each record in the dataset. This field must be of type Date. If provided, the tool will find clusters of points that are close to each other in space and time. The Search Time Interval parameter value must be provided to determine whether a point is close enough in time to a cluster to be included in the cluster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? TimeField { get; set; }

		/// <summary>
		/// <para>Search Time Interval</para>
		/// <para>The time interval that will be used to determine whether points form a space-time cluster. The search time interval spans before and after the time of each point, so, for example, an interval of 3 days around a point will include all points starting 3 days before and ending 3 days after the time of the point.</para>
		/// <para>For the Clustering Method parameter&apos;s Defined distance (DBSCAN) option, the Minimum Features per Cluster parameter value must be found within the search distance and the search time interval to be included in a cluster.</para>
		/// <para>For the Clustering Method parameter&apos;s Multi-scale (OPTICS) option, all points outside of the search time interval will be excluded when calculating core distances, neighbor-distances, and reachability distances.</para>
		/// <para>The search time interval does not control the overall time span of the resulting space-time clusters. The time span of points within a cluster can be larger than the search time interval as long as each point has neighbors within the cluster that are within the search time interval.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? SearchTimeInterval { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DensityBasedClustering SetEnviroment(object? outputCoordinateSystem = null, object? outputZFlag = null, object? parallelProcessingFactor = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, outputZFlag: outputZFlag, parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Clustering Method</para>
		/// </summary>
		public enum ClusterMethodEnum 
		{
			/// <summary>
			/// <para>Defined distance (DBSCAN)— A specified distance will be used to separate dense clusters from sparser noise. DBSCAN is the fastest of the clustering methods but is only appropriate if there is a very clear distance to use that works well to define all clusters that may be present. This results in clusters that have similar densities.</para>
			/// </summary>
			[GPValue("DBSCAN")]
			[Description("Defined distance (DBSCAN)")]
			DBSCAN,

			/// <summary>
			/// <para>Self-adjusting (HDBSCAN)— Varying distances will be used to separate clusters of varying densities from sparser noise. HDBSCAN is the most data-driven of the clustering methods and requires the least user input.</para>
			/// </summary>
			[GPValue("HDBSCAN")]
			[Description("Self-adjusting (HDBSCAN)")]
			HDBSCAN,

			/// <summary>
			/// <para>Multi-scale (OPTICS)—The distance between neighbors and a reachability plot will be used to separate clusters of varying densities from noise. OPTICS offers the most flexibility in fine-tuning the clusters that are detected, though it is computationally intensive, particularly with a large search distance.</para>
			/// </summary>
			[GPValue("OPTICS")]
			[Description("Multi-scale (OPTICS)")]
			OPTICS,

		}

#endregion
	}
}
