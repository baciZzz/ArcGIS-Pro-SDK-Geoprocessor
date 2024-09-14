using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsServerTools
{
	/// <summary>
	/// <para>Find Point Clusters</para>
	/// <para>Find Point Clusters</para>
	/// <para>Finds clusters of point features in surrounding noise based on their spatial or spatiotemporal distribution.</para>
	/// </summary>
	public class FindPointClusters : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputPoints">
		/// <para>Input Point Layer</para>
		/// <para>The point feature class containing the point clusters.</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>The name of the output feature service.</para>
		/// </param>
		/// <param name="MinimumPoints">
		/// <para>Minimum Features per Cluster</para>
		/// <para>This parameter is used differently depending on the clustering method chosen as follows:</para>
		/// <para>Defined distance (DBSCAN)—Specifies the number of features that must be found within a certain distance of a point for that point to start to form a cluster. The distance is defined using the Search Distance parameter.</para>
		/// <para>Self-adjusting (HDBSCAN)—Specifies the number of features neighboring each point (including the point) that will be considered when estimating density. This number is also the minimum cluster size allowed when extracting clusters.</para>
		/// </param>
		public FindPointClusters(object InputPoints, object OutputName, object MinimumPoints)
		{
			this.InputPoints = InputPoints;
			this.OutputName = OutputName;
			this.MinimumPoints = MinimumPoints;
		}

		/// <summary>
		/// <para>Tool Display Name : Find Point Clusters</para>
		/// </summary>
		public override string DisplayName() => "Find Point Clusters";

		/// <summary>
		/// <para>Tool Name : FindPointClusters</para>
		/// </summary>
		public override string ToolName() => "FindPointClusters";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.FindPointClusters</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.FindPointClusters";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoanalytics</para>
		/// </summary>
		public override string ToolboxAlise() => "geoanalytics";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputPoints, OutputName, MinimumPoints, SearchDistance!, DataStore!, Output!, ClusteringMethod!, UseTime!, SearchDuration! };

		/// <summary>
		/// <para>Input Point Layer</para>
		/// <para>The point feature class containing the point clusters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple")]
		[PortalType("DataStoreCatalogLayer")]
		public object InputPoints { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output feature service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Minimum Features per Cluster</para>
		/// <para>This parameter is used differently depending on the clustering method chosen as follows:</para>
		/// <para>Defined distance (DBSCAN)—Specifies the number of features that must be found within a certain distance of a point for that point to start to form a cluster. The distance is defined using the Search Distance parameter.</para>
		/// <para>Self-adjusting (HDBSCAN)—Specifies the number of features neighboring each point (including the point) that will be considered when estimating density. This number is also the minimum cluster size allowed when extracting clusters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object MinimumPoints { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>The maximum distance to be considered.</para>
		/// <para>The Minimum Features per Cluster specified must be found within this distance for cluster membership. Individual clusters will be separated by at least this distance. If a feature is located farther than this distance from the next closest feature in the cluster, it will not be included in the cluster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? SearchDistance { get; set; }

		/// <summary>
		/// <para>Data Store</para>
		/// <para>Specifies the ArcGIS Data Store where the output will be saved. The default is Spatiotemporal big data store. All results stored in a spatiotemporal big data store will be stored in WGS84. Results stored in a relational data store will maintain their coordinate system.</para>
		/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
		/// <para>Relational data store—Output will be stored in a relational data store.</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Data Store")]
		public object? DataStore { get; set; } = "SPATIOTEMPORAL_DATA_STORE";

		/// <summary>
		/// <para>Output Feature Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? Output { get; set; }

		/// <summary>
		/// <para>Clustering Method</para>
		/// <para>Specifies the method that will be used to define clusters.</para>
		/// <para>Defined distance (DBSCAN)— Uses a specified distance to separate dense clusters from sparser noise. DBSCAN is the fastest of the clustering methods but is only appropriate if there is a clear distance that works well to define all clusters that may be present. This results in clusters that have similar densities. This is the default.</para>
		/// <para>Self-adjusting (HDBSCAN)— Uses varying distances to separate clusters of varying densities from sparser noise. HDBSCAN is the most data driven of the clustering methods and requires the least user input.</para>
		/// <para><see cref="ClusteringMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ClusteringMethod { get; set; } = "DBSCAN";

		/// <summary>
		/// <para>Use Time to Find Clusters</para>
		/// <para>Specifies whether or not time will be used to discover clusters with DBSCAN.</para>
		/// <para>Checked—Spatiotemporal clusters will be found using both a search distance and a search duration.</para>
		/// <para>Unchecked—Spatial clusters will be found using a search distance and time will be ignored. This is the default.</para>
		/// <para><see cref="UseTimeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? UseTime { get; set; } = "false";

		/// <summary>
		/// <para>Search Duration</para>
		/// <para>When searching for cluster members, the specified minimum number of points must be found within this time duration to form a cluster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? SearchDuration { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindPointClusters SetEnviroment(object? extent = null, object? outputCoordinateSystem = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Data Store</para>
		/// </summary>
		public enum DataStoreEnum 
		{
			/// <summary>
			/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("Spatiotemporal big data store")]
			Spatiotemporal_big_data_store,

			/// <summary>
			/// <para>Relational data store—Output will be stored in a relational data store.</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("Relational data store")]
			Relational_data_store,

		}

		/// <summary>
		/// <para>Clustering Method</para>
		/// </summary>
		public enum ClusteringMethodEnum 
		{
			/// <summary>
			/// <para>Defined distance (DBSCAN)— Uses a specified distance to separate dense clusters from sparser noise. DBSCAN is the fastest of the clustering methods but is only appropriate if there is a clear distance that works well to define all clusters that may be present. This results in clusters that have similar densities. This is the default.</para>
			/// </summary>
			[GPValue("DBSCAN")]
			[Description("Defined distance (DBSCAN)")]
			DBSCAN,

			/// <summary>
			/// <para>Self-adjusting (HDBSCAN)— Uses varying distances to separate clusters of varying densities from sparser noise. HDBSCAN is the most data driven of the clustering methods and requires the least user input.</para>
			/// </summary>
			[GPValue("HDBSCAN")]
			[Description("Self-adjusting (HDBSCAN)")]
			HDBSCAN,

		}

		/// <summary>
		/// <para>Use Time to Find Clusters</para>
		/// </summary>
		public enum UseTimeEnum 
		{
			/// <summary>
			/// <para>Checked—Spatiotemporal clusters will be found using both a search distance and a search duration.</para>
			/// </summary>
			[GPValue("true")]
			[Description("TIME")]
			TIME,

			/// <summary>
			/// <para>Unchecked—Spatial clusters will be found using a search distance and time will be ignored. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_TIME")]
			NO_TIME,

		}

#endregion
	}
}
