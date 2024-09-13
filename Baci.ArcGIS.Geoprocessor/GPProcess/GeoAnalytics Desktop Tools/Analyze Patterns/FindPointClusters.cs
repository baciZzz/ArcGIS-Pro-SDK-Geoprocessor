using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsDesktopTools
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
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>包含所生成点聚类的新要素类。</para>
		/// </param>
		/// <param name="ClusteringMethod">
		/// <para>Clustering Method</para>
		/// <para>指定将用于定义聚类的方法。</para>
		/// <para>定义的距离 (DBSCAN)— 使用指定距离将密集聚类与稀疏噪点相分离。DBSCAN 是最快的聚类方法，但仅适用于要使用的距离明确，并且非常适用于定义可能存在的所有聚类。此方法将产生密度相似的聚类。这是默认设置。</para>
		/// <para>自调整 (HDBSCAN)— 使用可变距离可将不同密度的聚类与稀疏噪点相分离。HDBSCAN 是最以数据为驱动的聚类方法，且需要的用户输入最少。</para>
		/// <para><see cref="ClusteringMethodEnum"/></para>
		/// </param>
		/// <param name="MinimumPoints">
		/// <para>Minimum Features per Cluster</para>
		/// <para>根据选择的聚类方法，此参数的使用方式也不同，如下所示：</para>
		/// <para>定义距离 (DBSCAN) - 可以指定在某点开始形成聚类的特定距离内必须找到的要素数。距离可使用搜索距离参数进行定义。</para>
		/// <para>自调整 (HDBSCAN) - 可指定与估算密度时考虑的每个点相邻的要素数（包括该点）。此数字也是提取聚类时所允许的最小聚类大小。</para>
		/// </param>
		public FindPointClusters(object InputPoints, object OutFeatureClass, object ClusteringMethod, object MinimumPoints)
		{
			this.InputPoints = InputPoints;
			this.OutFeatureClass = OutFeatureClass;
			this.ClusteringMethod = ClusteringMethod;
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
		/// <para>Tool Excute Name : gapro.FindPointClusters</para>
		/// </summary>
		public override string ExcuteName() => "gapro.FindPointClusters";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise() => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputPoints, OutFeatureClass, ClusteringMethod, MinimumPoints, SearchDistance!, UseTime!, SearchDuration! };

		/// <summary>
		/// <para>Input Point Layer</para>
		/// <para>包含点聚类的点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InputPoints { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含所生成点聚类的新要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Clustering Method</para>
		/// <para>指定将用于定义聚类的方法。</para>
		/// <para>定义的距离 (DBSCAN)— 使用指定距离将密集聚类与稀疏噪点相分离。DBSCAN 是最快的聚类方法，但仅适用于要使用的距离明确，并且非常适用于定义可能存在的所有聚类。此方法将产生密度相似的聚类。这是默认设置。</para>
		/// <para>自调整 (HDBSCAN)— 使用可变距离可将不同密度的聚类与稀疏噪点相分离。HDBSCAN 是最以数据为驱动的聚类方法，且需要的用户输入最少。</para>
		/// <para><see cref="ClusteringMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ClusteringMethod { get; set; } = "DBSCAN";

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
		/// <para>必须在聚类成员的此距离内找到指定的每个聚类的最小要素数。将至少按此距离来分隔单个聚类。如果要素与聚类中下一最近要素的距离大于此距离，则不会将该要素包括在聚类中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? SearchDistance { get; set; }

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
		public object? UseTime { get; set; } = "false";

		/// <summary>
		/// <para>Search Duration</para>
		/// <para>在搜索聚类成员时，必须在此持续时间内找到指定的最小点数方可形成聚类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? SearchDuration { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindPointClusters SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Clustering Method</para>
		/// </summary>
		public enum ClusteringMethodEnum 
		{
			/// <summary>
			/// <para>定义的距离 (DBSCAN)— 使用指定距离将密集聚类与稀疏噪点相分离。DBSCAN 是最快的聚类方法，但仅适用于要使用的距离明确，并且非常适用于定义可能存在的所有聚类。此方法将产生密度相似的聚类。这是默认设置。</para>
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

#endregion
	}
}
