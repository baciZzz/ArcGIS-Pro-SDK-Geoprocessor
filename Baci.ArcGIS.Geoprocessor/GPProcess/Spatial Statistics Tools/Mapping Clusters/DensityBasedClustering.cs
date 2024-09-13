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
	/// <para>基于密度的聚类</para>
	/// <para>基于点要素的空间分布查找周围噪点内的点要素聚类。 可以整合时间以查找空间-时间聚类。</para>
	/// </summary>
	public class DensityBasedClustering : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Point Features</para>
		/// <para>将执行基于密度的聚类的点要素。</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>将接收聚类结果的输出要素类。</para>
		/// </param>
		/// <param name="ClusterMethod">
		/// <para>Clustering Method</para>
		/// <para>指定将用于定义聚类的方法。</para>
		/// <para>定义的距离 (DBSCAN)—将使用指定距离将密集聚类与稀疏噪点分离。 DBSCAN 是最快的聚类方法，但仅适用于要使用的距离非常明确，并且非常适用于定义可能存在的所有聚类。 此方法将产生密度相似的聚类。</para>
		/// <para>自调整 (HDBSCAN)—将使用可变距离将不同密度的聚类与稀疏噪点分离。 HDBSCAN 是最以数据为驱动的聚类方法，且需要的用户输入最少。</para>
		/// <para>多比例 (OPTICS)—将使用相邻要素与可达图之间的距离将不同密度的聚类与噪点相分离。 OPTICS 在优化检测到的聚类方面最灵活，但其属于计算密集型，尤其是当搜索距离较大时。</para>
		/// <para><see cref="ClusterMethodEnum"/></para>
		/// </param>
		/// <param name="MinFeaturesCluster">
		/// <para>Minimum Features per Cluster</para>
		/// <para>将视为聚类的最小点数。 点数少于给定数量的聚类将被视为噪点。</para>
		/// </param>
		public DensityBasedClustering(object InFeatures, object OutputFeatures, object ClusterMethod, object MinFeaturesCluster)
		{
			this.InFeatures = InFeatures;
			this.OutputFeatures = OutputFeatures;
			this.ClusterMethod = ClusterMethod;
			this.MinFeaturesCluster = MinFeaturesCluster;
		}

		/// <summary>
		/// <para>Tool Display Name : 基于密度的聚类</para>
		/// </summary>
		public override string DisplayName() => "基于密度的聚类";

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
		/// <para>将执行基于密度的聚类的点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>将接收聚类结果的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Clustering Method</para>
		/// <para>指定将用于定义聚类的方法。</para>
		/// <para>定义的距离 (DBSCAN)—将使用指定距离将密集聚类与稀疏噪点分离。 DBSCAN 是最快的聚类方法，但仅适用于要使用的距离非常明确，并且非常适用于定义可能存在的所有聚类。 此方法将产生密度相似的聚类。</para>
		/// <para>自调整 (HDBSCAN)—将使用可变距离将不同密度的聚类与稀疏噪点分离。 HDBSCAN 是最以数据为驱动的聚类方法，且需要的用户输入最少。</para>
		/// <para>多比例 (OPTICS)—将使用相邻要素与可达图之间的距离将不同密度的聚类与噪点相分离。 OPTICS 在优化检测到的聚类方面最灵活，但其属于计算密集型，尤其是当搜索距离较大时。</para>
		/// <para><see cref="ClusterMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ClusterMethod { get; set; }

		/// <summary>
		/// <para>Minimum Features per Cluster</para>
		/// <para>将视为聚类的最小点数。 点数少于给定数量的聚类将被视为噪点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 100000000)]
		public object MinFeaturesCluster { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>要考虑的最大距离。</para>
		/// <para>对于聚类方法参数的定义的距离 (DBSCAN) 选项，必须在聚类成员资格的此距离内找到每个聚类的最小要素数参数值。 将至少按此距离来分隔单个聚类。 如果点与聚类中下一最近点的距离大于此距离，则不会将该点包括在聚类中。</para>
		/// <para>对于聚类方法参数的多比例 (OPTICS) 选项，此参数是可选的，并且可用作创建可达图时的最大搜索距离。 对于 OPTICS，结合聚类敏感度参数值的可达图可以确定聚类成员资格。 如果未指定距离，则工具将搜索所有距离，这会增加处理时间。</para>
		/// <para>如果留空，则使用的默认距离将为数据集中找到的最高核心距离，排除前 1% 的核心距离（即最极端的核心距离）。 如果提供时间字段参数值，必须提供搜索距离且不得包括默认值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? SearchDistance { get; set; }

		/// <summary>
		/// <para>Cluster Sensitivity</para>
		/// <para>0 到 100 之间的整数，用于确定聚类的紧密度。 值越接近 100，则产生的密集聚类越多。 值越接近 0，则产生的较松散聚类越多。 如果留空，工具将使用 Kullback-Leibler Divergence 找到一个添加更多聚类并不会增加额外信息的敏感度值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 100)]
		public object? ClusterSensitivity { get; set; }

		/// <summary>
		/// <para>Time Field</para>
		/// <para>包含数据集中每条记录的时间戳的字段。 此字段的类型必须是日期。 提供参数后，工具将查找在空间和时间上彼此接近的点聚类。 必须提供搜索时间间隔参数值以确定某点如要包含于聚类，其在时间上是否与聚类足够接近。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? TimeField { get; set; }

		/// <summary>
		/// <para>Search Time Interval</para>
		/// <para>用于确定点是否构成空间-时间聚类的时间间隔。 搜索时间间隔包括各点时间的之前和之后的时间，因此，例如围绕一个点的时间间隔为 3 天，则将包括从该点时间之前 3 天到之后 3 天范围内的所有点。</para>
		/// <para>对于聚类方法参数的定义的距离 (DBSCAN) 选项，必须在搜索距离和搜索时间间隔范围内找到每个聚类的最小要素数，才能将点包含在聚类中。</para>
		/// <para>对于聚类方法参数的多比例 (OPTICS) 选项，在计算核心距离、相邻要素距离和可达距离时，将排除搜索时间间隔外的所有点。</para>
		/// <para>搜索时间间隔不控制生成空间-时间聚类的整体时间跨度。 聚类中各点的时间跨度可以大于搜索时间间隔，只要各个点在聚类中具有搜索时间间隔范围内的相邻要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? SearchTimeInterval { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DensityBasedClustering SetEnviroment(object? outputCoordinateSystem = null , object? outputZFlag = null , object? parallelProcessingFactor = null )
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
			/// <para>定义的距离 (DBSCAN)—将使用指定距离将密集聚类与稀疏噪点分离。 DBSCAN 是最快的聚类方法，但仅适用于要使用的距离非常明确，并且非常适用于定义可能存在的所有聚类。 此方法将产生密度相似的聚类。</para>
			/// </summary>
			[GPValue("DBSCAN")]
			[Description("定义的距离 (DBSCAN)")]
			DBSCAN,

			/// <summary>
			/// <para>自调整 (HDBSCAN)—将使用可变距离将不同密度的聚类与稀疏噪点分离。 HDBSCAN 是最以数据为驱动的聚类方法，且需要的用户输入最少。</para>
			/// </summary>
			[GPValue("HDBSCAN")]
			[Description("自调整 (HDBSCAN)")]
			HDBSCAN,

			/// <summary>
			/// <para>多比例 (OPTICS)—将使用相邻要素与可达图之间的距离将不同密度的聚类与噪点相分离。 OPTICS 在优化检测到的聚类方面最灵活，但其属于计算密集型，尤其是当搜索距离较大时。</para>
			/// </summary>
			[GPValue("OPTICS")]
			[Description("多比例 (OPTICS)")]
			OPTICS,

		}

#endregion
	}
}
