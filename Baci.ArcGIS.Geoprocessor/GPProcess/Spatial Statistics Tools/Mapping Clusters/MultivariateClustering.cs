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
	/// <para>Multivariate Clustering</para>
	/// <para>多元聚类</para>
	/// <para>仅根据要素属性值查找要素的自然聚类。</para>
	/// </summary>
	public class MultivariateClustering : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>将为其创建聚类的要素类或要素图层。</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>将要创建的输出要素类，其中包含所有要素、指定的分析字段以及一个用于指明每个要素所属聚类的字段。</para>
		/// </param>
		/// <param name="AnalysisFields">
		/// <para>Analysis Fields</para>
		/// <para>将用于区分各个聚类的字段的列表。</para>
		/// </param>
		public MultivariateClustering(object InFeatures, object OutputFeatures, object AnalysisFields)
		{
			this.InFeatures = InFeatures;
			this.OutputFeatures = OutputFeatures;
			this.AnalysisFields = AnalysisFields;
		}

		/// <summary>
		/// <para>Tool Display Name : 多元聚类</para>
		/// </summary>
		public override string DisplayName() => "多元聚类";

		/// <summary>
		/// <para>Tool Name : MultivariateClustering</para>
		/// </summary>
		public override string ToolName() => "MultivariateClustering";

		/// <summary>
		/// <para>Tool Excute Name : stats.MultivariateClustering</para>
		/// </summary>
		public override string ExcuteName() => "stats.MultivariateClustering";

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
		public override string[] ValidEnvironments() => new string[] { "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "randomGenerator", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutputFeatures, AnalysisFields, ClusteringMethod!, InitializationMethod!, InitializationField!, NumberOfClusters!, OutputTable! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>将为其创建聚类的要素类或要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>将要创建的输出要素类，其中包含所有要素、指定的分析字段以及一个用于指明每个要素所属聚类的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Analysis Fields</para>
		/// <para>将用于区分各个聚类的字段的列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object AnalysisFields { get; set; }

		/// <summary>
		/// <para>Clustering Method</para>
		/// <para>指定要使用的聚类算法。</para>
		/// <para>K 均值和 K 中心点选项通常将产生类似的结果。 但是，K 中心点对于输入要素参数值中的噪点和异常值更加可靠。 K 均值通常比 K 中心点更快，建议用于大型数据集。</para>
		/// <para>K 均值—将使用 K 均值算法对输入要素参数值进行聚类。 这是默认设置。</para>
		/// <para>K 中心点—将使用 K 中心点算法对输入要素参数值进行聚类。</para>
		/// <para><see cref="ClusteringMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ClusteringMethod { get; set; } = "K_MEANS";

		/// <summary>
		/// <para>Initialization Method</para>
		/// <para>指定用于发展聚类的初始种子的获得方法。 例如，如果您指明需要三个聚类，则分析将从三个种子开始。</para>
		/// <para>优化的种子位置—选择种子要素以便优化分析结果和性能。 这是默认设置。</para>
		/// <para>用户定义的种子位置—初始化字段参数值中的非零条目将被用作发展聚类的起点。</para>
		/// <para>随机种子位置—将随机选择初始种子要素。</para>
		/// <para><see cref="InitializationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? InitializationMethod { get; set; } = "OPTIMIZED_SEED_LOCATIONS";

		/// <summary>
		/// <para>Initialization Field</para>
		/// <para>用于标识种子要素的数值型字段。 将使用此字段中具有 1 值的要素发展聚类。 每个种子将生成一个聚类，因此必须至少提供两个种子要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object? InitializationField { get; set; }

		/// <summary>
		/// <para>Number of Clusters</para>
		/// <para>将要创建的聚类数。 如果将此参数留空时，该工具将计算具有 2 至 30 个聚类的聚类解决方案的伪 F 统计量，以评估出最佳聚类数。</para>
		/// <para>如果在初始化字段中提供了种子位置，该参数将被禁用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumberOfClusters { get; set; }

		/// <summary>
		/// <para>Output Table for Evaluating Number of Clusters</para>
		/// <para>表中包含经计算用来评估最佳聚类数的聚类解决方案 2 至 30 的伪 F 统计量。 基于该表创建的图表可通过内容窗格独立表部分进行访问。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutputTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MultivariateClustering SetEnviroment(double? MResolution = null, double? MTolerance = null, object? XYResolution = null, object? XYTolerance = null, object? ZResolution = null, object? ZTolerance = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? outputMFlag = null, object? outputZFlag = null, double? outputZValue = null, bool? qualifiedFieldNames = null, object? randomGenerator = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, randomGenerator: randomGenerator, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Clustering Method</para>
		/// </summary>
		public enum ClusteringMethodEnum 
		{
			/// <summary>
			/// <para>K 均值和 K 中心点选项通常将产生类似的结果。 但是，K 中心点对于输入要素参数值中的噪点和异常值更加可靠。 K 均值通常比 K 中心点更快，建议用于大型数据集。</para>
			/// </summary>
			[GPValue("K_MEANS")]
			[Description("K 均值")]
			K_means,

			/// <summary>
			/// <para>K 中心点—将使用 K 中心点算法对输入要素参数值进行聚类。</para>
			/// </summary>
			[GPValue("K_MEDOIDS")]
			[Description("K 中心点")]
			K_medoids,

		}

		/// <summary>
		/// <para>Initialization Method</para>
		/// </summary>
		public enum InitializationMethodEnum 
		{
			/// <summary>
			/// <para>优化的种子位置—选择种子要素以便优化分析结果和性能。 这是默认设置。</para>
			/// </summary>
			[GPValue("OPTIMIZED_SEED_LOCATIONS")]
			[Description("优化的种子位置")]
			Optimized_seed_locations,

			/// <summary>
			/// <para>用户定义的种子位置—初始化字段参数值中的非零条目将被用作发展聚类的起点。</para>
			/// </summary>
			[GPValue("USER_DEFINED_SEED_LOCATIONS")]
			[Description("用户定义的种子位置")]
			User_defined_seed_locations,

			/// <summary>
			/// <para>随机种子位置—将随机选择初始种子要素。</para>
			/// </summary>
			[GPValue("RANDOM_SEED_LOCATIONS")]
			[Description("随机种子位置")]
			Random_seed_locations,

		}

#endregion
	}
}
