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
	/// <para>查找点聚类</para>
	/// <para>基于点要素的空间或时空分布查找周围噪点内的点要素聚类。</para>
	/// </summary>
	public class FindPointClusters : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputPoints">
		/// <para>Input Point Layer</para>
		/// <para>包含点聚类的点要素类。</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>输出要素服务的名称。</para>
		/// </param>
		/// <param name="MinimumPoints">
		/// <para>Minimum Features per Cluster</para>
		/// <para>根据选择的聚类方法，此参数的使用方式也不同，如下所示：</para>
		/// <para>定义距离 (DBSCAN) - 可以指定在某点开始形成聚类的特定距离内必须找到的要素数。距离可使用搜索距离参数进行定义。</para>
		/// <para>自调整 (HDBSCAN) - 可指定与估算密度时考虑的每个点相邻的要素数（包括该点）。此数字也是提取聚类时所允许的最小聚类大小。</para>
		/// </param>
		public FindPointClusters(object InputPoints, object OutputName, object MinimumPoints)
		{
			this.InputPoints = InputPoints;
			this.OutputName = OutputName;
			this.MinimumPoints = MinimumPoints;
		}

		/// <summary>
		/// <para>Tool Display Name : 查找点聚类</para>
		/// </summary>
		public override string DisplayName() => "查找点聚类";

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
		public override object[] Parameters() => new object[] { InputPoints, OutputName, MinimumPoints, SearchDistance, DataStore, Output, ClusteringMethod, UseTime, SearchDuration };

		/// <summary>
		/// <para>Input Point Layer</para>
		/// <para>包含点聚类的点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple")]
		[PortalType("DataStoreCatalogLayer")]
		public object InputPoints { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>输出要素服务的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Minimum Features per Cluster</para>
		/// <para>根据选择的聚类方法，此参数的使用方式也不同，如下所示：</para>
		/// <para>定义距离 (DBSCAN) - 可以指定在某点开始形成聚类的特定距离内必须找到的要素数。距离可使用搜索距离参数进行定义。</para>
		/// <para>自调整 (HDBSCAN) - 可指定与估算密度时考虑的每个点相邻的要素数（包括该点）。此数字也是提取聚类时所允许的最小聚类大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object MinimumPoints { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>要考虑的最大距离。</para>
		/// <para>必须在聚类隶属度的此距离内找到指定的每个聚类的最小要素数。将至少按此距离来分隔单个聚类。如果要素与聚类中下一最近要素的距离大于此距离，则不会将该要素包括在聚类中。</para>
		/// <para><see cref="SearchDistanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object SearchDistance { get; set; }

		/// <summary>
		/// <para>Data Store</para>
		/// <para>指定将用于保存输出的 ArcGIS Data Store。默认设置为时空大数据存储。在时空大数据存储中存储的所有结果都将存储在 WGS84 中。在关系数据存储中存储的结果都将保持各自的坐标系。</para>
		/// <para>时空大数据存储—输出将存储在时空大数据存储中。这是默认设置。</para>
		/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Data Store")]
		public object DataStore { get; set; } = "SPATIOTEMPORAL_DATA_STORE";

		/// <summary>
		/// <para>Output Feature Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Clustering Method</para>
		/// <para>指定将用于定义聚类的方法。</para>
		/// <para>定义的距离 (DBSCAN)— 使用指定距离将密集聚类与稀疏噪点相分离。DBSCAN 是最快的聚类方法，但仅适用于距离明确的情况，并且非常适用于定义可能存在的所有聚类。此方法将产生密度相似的聚类。这是默认设置。</para>
		/// <para>自调整 (HDBSCAN)— 使用可变距离可将不同密度的聚类与稀疏噪点相分离。HDBSCAN 是最以数据为驱动的聚类方法，且需要的用户输入最少。</para>
		/// <para><see cref="ClusteringMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ClusteringMethod { get; set; } = "DBSCAN";

		/// <summary>
		/// <para>Use Time to Find Clusters</para>
		/// <para>用于指定是否将使用时间通过 DBSCAN 查找聚类。</para>
		/// <para>选中 - 将使用搜索距离和搜索持续时间来查找时空聚类。</para>
		/// <para>未选中 - 将使用搜索距离来查找空间聚类，而时间将被忽略。这是默认设置。</para>
		/// <para><see cref="UseTimeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UseTime { get; set; } = "false";

		/// <summary>
		/// <para>Search Duration</para>
		/// <para>在搜索聚类成员时，必须在此持续时间内找到指定的最小点数方可形成聚类。</para>
		/// <para><see cref="SearchDurationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object SearchDuration { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindPointClusters SetEnviroment(object extent = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Search Distance</para>
		/// </summary>
		public enum SearchDistanceEnum 
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
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NauticalMiles")]
			[Description("NauticalMiles")]
			NauticalMiles,

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

		}

		/// <summary>
		/// <para>Data Store</para>
		/// </summary>
		public enum DataStoreEnum 
		{
			/// <summary>
			/// <para>时空大数据存储—输出将存储在时空大数据存储中。这是默认设置。</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("时空大数据存储")]
			Spatiotemporal_big_data_store,

			/// <summary>
			/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("关系数据存储")]
			Relational_data_store,

		}

		/// <summary>
		/// <para>Clustering Method</para>
		/// </summary>
		public enum ClusteringMethodEnum 
		{
			/// <summary>
			/// <para>定义的距离 (DBSCAN)— 使用指定距离将密集聚类与稀疏噪点相分离。DBSCAN 是最快的聚类方法，但仅适用于距离明确的情况，并且非常适用于定义可能存在的所有聚类。此方法将产生密度相似的聚类。这是默认设置。</para>
			/// </summary>
			[GPValue("DBSCAN")]
			[Description("定义的距离 (DBSCAN)")]
			DBSCAN,

			/// <summary>
			/// <para>自调整 (HDBSCAN)— 使用可变距离可将不同密度的聚类与稀疏噪点相分离。HDBSCAN 是最以数据为驱动的聚类方法，且需要的用户输入最少。</para>
			/// </summary>
			[GPValue("HDBSCAN")]
			[Description("自调整 (HDBSCAN)")]
			HDBSCAN,

		}

		/// <summary>
		/// <para>Use Time to Find Clusters</para>
		/// </summary>
		public enum UseTimeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("TIME")]
			TIME,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_TIME")]
			NO_TIME,

		}

		/// <summary>
		/// <para>Search Duration</para>
		/// </summary>
		public enum SearchDurationEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Milliseconds")]
			[Description("Milliseconds")]
			Milliseconds,

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

#endregion
	}
}
