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
	/// <para>High/Low Clustering (Getis-Ord General G)</para>
	/// <para>高/低聚类 (Getis-Ord General G)</para>
	/// <para>使用 Getis-Ord General G 统计可度量高值或低值的聚类程度。</para>
	/// </summary>
	public class HighLowClustering : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>将计算 General G 统计的要素类。</para>
		/// </param>
		/// <param name="InputField">
		/// <para>Input Field</para>
		/// <para>要评估的数值字段。</para>
		/// </param>
		/// <param name="ConceptualizationOfSpatialRelationships">
		/// <para>Conceptualization of Spatial Relationships</para>
		/// <para>指定要素空间关系的定义方式。</para>
		/// <para>反距离—与远处的要素相比，附近的邻近要素对目标要素的计算的影响要大一些。</para>
		/// <para>反距离平方—与反距离类似，但它的坡度更明显，因此影响下降得更快，并且只有目标要素的最近邻域会对要素的计算产生重大影响。</para>
		/// <para>固定距离范围—将对邻近要素环境中的每个要素进行分析。在指定临界距离（距离范围或距离阈值）内的邻近要素将分配有值为 1 的权重，并对目标要素的计算产生影响。在指定临界距离外的邻近要素将分配值为零的权重，并且不会对目标要素的计算产生任何影响。</para>
		/// <para>无差别的区域—在目标要素的指定临界距离（距离范围或距离阈值）内的要素将分配有值为 1 的权重，并且会影响目标要素的计算。一旦超出该临界距离，权重（以及邻近要素对目标要素计算的影响）就会随距离的增加而减小。</para>
		/// <para>K - 最近邻—将最近的 k 要素包含在分析中；k 是指定的数字参数。</para>
		/// <para>仅邻接边—只有共用边界或重叠的相邻面要素会影响目标面要素的计算。</para>
		/// <para>邻接边拐角—共享边界、节点或重叠的面要素会影响目标面要素的计算。</para>
		/// <para>通过文件获取空间权重—将由指定空间权重文件定义空间关系。指向空间权重文件的路径由权重矩阵文件参数指定。</para>
		/// <para><see cref="ConceptualizationOfSpatialRelationshipsEnum"/></para>
		/// </param>
		/// <param name="DistanceMethod">
		/// <para>Distance Method</para>
		/// <para>指定计算每个要素与邻近要素之间的距离的方式。</para>
		/// <para>欧氏—两点间的直线距离</para>
		/// <para>曼哈顿—沿垂直轴度量的两点间的距离（城市街区）；计算方法是对两点的 x 和 y 坐标的差值（绝对值）求和。</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </param>
		/// <param name="Standardization">
		/// <para>Standardization</para>
		/// <para>指定是否对空间权重执行标准化。当要素的分布由于采样设计或施加的聚合方案而可能偏离时，建议使用行标准化。</para>
		/// <para>无—不对空间权重执行标准化。</para>
		/// <para>行—对空间权重执行标准化；每个权重都会除以行的和（所有相邻要素的权重和）。这是默认设置。</para>
		/// <para><see cref="StandardizationEnum"/></para>
		/// </param>
		public HighLowClustering(object InputFeatureClass, object InputField, object ConceptualizationOfSpatialRelationships, object DistanceMethod, object Standardization)
		{
			this.InputFeatureClass = InputFeatureClass;
			this.InputField = InputField;
			this.ConceptualizationOfSpatialRelationships = ConceptualizationOfSpatialRelationships;
			this.DistanceMethod = DistanceMethod;
			this.Standardization = Standardization;
		}

		/// <summary>
		/// <para>Tool Display Name : 高/低聚类 (Getis-Ord General G)</para>
		/// </summary>
		public override string DisplayName() => "高/低聚类 (Getis-Ord General G)";

		/// <summary>
		/// <para>Tool Name : HighLowClustering</para>
		/// </summary>
		public override string ToolName() => "HighLowClustering";

		/// <summary>
		/// <para>Tool Excute Name : stats.HighLowClustering</para>
		/// </summary>
		public override string ExcuteName() => "stats.HighLowClustering";

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
		public override object[] Parameters() => new object[] { InputFeatureClass, InputField, GenerateReport!, ConceptualizationOfSpatialRelationships, DistanceMethod, Standardization, DistanceBandOrThresholdDistance!, WeightsMatrixFile!, ObservedGeneralG!, Zscore!, Pvalue!, ReportFile!, NumberOfNeighbors! };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>将计算 General G 统计的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatureClass { get; set; }

		/// <summary>
		/// <para>Input Field</para>
		/// <para>要评估的数值字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object InputField { get; set; }

		/// <summary>
		/// <para>Generate Report</para>
		/// <para>指定工具是否将创建结果的图形汇总。</para>
		/// <para>选中 - 图形汇总将以 HTML 文件形式创建。</para>
		/// <para>未选中 - 不会创建图形汇总。这是默认设置。</para>
		/// <para><see cref="GenerateReportEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? GenerateReport { get; set; }

		/// <summary>
		/// <para>Conceptualization of Spatial Relationships</para>
		/// <para>指定要素空间关系的定义方式。</para>
		/// <para>反距离—与远处的要素相比，附近的邻近要素对目标要素的计算的影响要大一些。</para>
		/// <para>反距离平方—与反距离类似，但它的坡度更明显，因此影响下降得更快，并且只有目标要素的最近邻域会对要素的计算产生重大影响。</para>
		/// <para>固定距离范围—将对邻近要素环境中的每个要素进行分析。在指定临界距离（距离范围或距离阈值）内的邻近要素将分配有值为 1 的权重，并对目标要素的计算产生影响。在指定临界距离外的邻近要素将分配值为零的权重，并且不会对目标要素的计算产生任何影响。</para>
		/// <para>无差别的区域—在目标要素的指定临界距离（距离范围或距离阈值）内的要素将分配有值为 1 的权重，并且会影响目标要素的计算。一旦超出该临界距离，权重（以及邻近要素对目标要素计算的影响）就会随距离的增加而减小。</para>
		/// <para>K - 最近邻—将最近的 k 要素包含在分析中；k 是指定的数字参数。</para>
		/// <para>仅邻接边—只有共用边界或重叠的相邻面要素会影响目标面要素的计算。</para>
		/// <para>邻接边拐角—共享边界、节点或重叠的面要素会影响目标面要素的计算。</para>
		/// <para>通过文件获取空间权重—将由指定空间权重文件定义空间关系。指向空间权重文件的路径由权重矩阵文件参数指定。</para>
		/// <para><see cref="ConceptualizationOfSpatialRelationshipsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConceptualizationOfSpatialRelationships { get; set; } = "INVERSE_DISTANCE";

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>指定计算每个要素与邻近要素之间的距离的方式。</para>
		/// <para>欧氏—两点间的直线距离</para>
		/// <para>曼哈顿—沿垂直轴度量的两点间的距离（城市街区）；计算方法是对两点的 x 和 y 坐标的差值（绝对值）求和。</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceMethod { get; set; } = "EUCLIDEAN_DISTANCE";

		/// <summary>
		/// <para>Standardization</para>
		/// <para>指定是否对空间权重执行标准化。当要素的分布由于采样设计或施加的聚合方案而可能偏离时，建议使用行标准化。</para>
		/// <para>无—不对空间权重执行标准化。</para>
		/// <para>行—对空间权重执行标准化；每个权重都会除以行的和（所有相邻要素的权重和）。这是默认设置。</para>
		/// <para><see cref="StandardizationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Standardization { get; set; } = "ROW";

		/// <summary>
		/// <para>Distance Band or Threshold Distance</para>
		/// <para>为“反距离”和“固定距离”选项指定中断距离。将在对目标要素的分析中忽略为该要素指定的中断之外的要素。但是，对于无差别的区域，指定距离之外的要素的影响会随距离的减小而变弱，而在距离阈值之内的影响则被视为是等同的。输入的距离值应该与输出坐标系的值匹配。</para>
		/// <para>对于空间关系的反距离概念化，值为 0 表示未应用任何阈值距离；当将此参数留空时，将计算并应用默认阈值。此默认值为确保每个要素至少具有一个邻域的欧氏距离。</para>
		/// <para>当选择了面邻接（仅邻接边或邻接边拐角）或通过文件获取空间权重的空间概念化时，该参数无效。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 999999999999999)]
		public object? DistanceBandOrThresholdDistance { get; set; }

		/// <summary>
		/// <para>Weights Matrix File</para>
		/// <para>包含权重（其定义要素间的空间关系以及可能的时态关系）的文件的路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("swm", "gwt", "txt")]
		public object? WeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Observed General G</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object? ObservedGeneralG { get; set; }

		/// <summary>
		/// <para>ZScore</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object? Zscore { get; set; }

		/// <summary>
		/// <para>PValue</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object? Pvalue { get; set; }

		/// <summary>
		/// <para>Report File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? ReportFile { get; set; }

		/// <summary>
		/// <para>Number of Neighbors</para>
		/// <para>用于指定将包含在分析中的相邻要素数目的整数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 1000)]
		public object? NumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public HighLowClustering SetEnviroment(object? geographicTransformations = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Generate Report</para>
		/// </summary>
		public enum GenerateReportEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERATE_REPORT")]
			GENERATE_REPORT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_REPORT")]
			NO_REPORT,

		}

		/// <summary>
		/// <para>Conceptualization of Spatial Relationships</para>
		/// </summary>
		public enum ConceptualizationOfSpatialRelationshipsEnum 
		{
			/// <summary>
			/// <para>反距离—与远处的要素相比，附近的邻近要素对目标要素的计算的影响要大一些。</para>
			/// </summary>
			[GPValue("INVERSE_DISTANCE")]
			[Description("反距离")]
			Inverse_distance,

			/// <summary>
			/// <para>反距离平方—与反距离类似，但它的坡度更明显，因此影响下降得更快，并且只有目标要素的最近邻域会对要素的计算产生重大影响。</para>
			/// </summary>
			[GPValue("INVERSE_DISTANCE_SQUARED")]
			[Description("反距离平方")]
			Inverse_distance_squared,

			/// <summary>
			/// <para>固定距离范围—将对邻近要素环境中的每个要素进行分析。在指定临界距离（距离范围或距离阈值）内的邻近要素将分配有值为 1 的权重，并对目标要素的计算产生影响。在指定临界距离外的邻近要素将分配值为零的权重，并且不会对目标要素的计算产生任何影响。</para>
			/// </summary>
			[GPValue("FIXED_DISTANCE_BAND")]
			[Description("固定距离范围")]
			Fixed_distance_band,

			/// <summary>
			/// <para>无差别的区域—在目标要素的指定临界距离（距离范围或距离阈值）内的要素将分配有值为 1 的权重，并且会影响目标要素的计算。一旦超出该临界距离，权重（以及邻近要素对目标要素计算的影响）就会随距离的增加而减小。</para>
			/// </summary>
			[GPValue("ZONE_OF_INDIFFERENCE")]
			[Description("无差别的区域")]
			Zone_of_indifference,

			/// <summary>
			/// <para>K - 最近邻—将最近的 k 要素包含在分析中；k 是指定的数字参数。</para>
			/// </summary>
			[GPValue("K_NEAREST_NEIGHBORS")]
			[Description("K - 最近邻")]
			K_nearest_neighbors,

			/// <summary>
			/// <para>仅邻接边—只有共用边界或重叠的相邻面要素会影响目标面要素的计算。</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_ONLY")]
			[Description("仅邻接边")]
			Contiguity_edges_only,

			/// <summary>
			/// <para>邻接边拐角—共享边界、节点或重叠的面要素会影响目标面要素的计算。</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_CORNERS")]
			[Description("邻接边拐角")]
			Contiguity_edges_corners,

			/// <summary>
			/// <para>通过文件获取空间权重—将由指定空间权重文件定义空间关系。指向空间权重文件的路径由权重矩阵文件参数指定。</para>
			/// </summary>
			[GPValue("GET_SPATIAL_WEIGHTS_FROM_FILE")]
			[Description("通过文件获取空间权重")]
			Get_spatial_weights_from_file,

		}

		/// <summary>
		/// <para>Distance Method</para>
		/// </summary>
		public enum DistanceMethodEnum 
		{
			/// <summary>
			/// <para>欧氏—两点间的直线距离</para>
			/// </summary>
			[GPValue("EUCLIDEAN_DISTANCE")]
			[Description("欧氏")]
			Euclidean,

			/// <summary>
			/// <para>曼哈顿—沿垂直轴度量的两点间的距离（城市街区）；计算方法是对两点的 x 和 y 坐标的差值（绝对值）求和。</para>
			/// </summary>
			[GPValue("MANHATTAN_DISTANCE")]
			[Description("曼哈顿")]
			Manhattan,

		}

		/// <summary>
		/// <para>Standardization</para>
		/// </summary>
		public enum StandardizationEnum 
		{
			/// <summary>
			/// <para>无—不对空间权重执行标准化。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>行—对空间权重执行标准化；每个权重都会除以行的和（所有相邻要素的权重和）。这是默认设置。</para>
			/// </summary>
			[GPValue("ROW")]
			[Description("行")]
			Row,

		}

#endregion
	}
}
