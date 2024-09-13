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
	/// <para>生成空间权重矩阵</para>
	/// <para>构建一个空间权重矩阵 (.swm) 文件，以表示数据集中各要素间的空间关系。</para>
	/// </summary>
	public class GenerateSpatialWeightsMatrix : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>将被评估要素空间关系的要素类。</para>
		/// </param>
		/// <param name="UniqueIDField">
		/// <para>Unique ID Field</para>
		/// <para>包含输入要素类中每个要素不同值的整型字段。如果没有“唯一 ID”字段，则可以创建一个，方法是向要素类表添加一个整型字段，然后将此字段的值计算为与 FID 或 OBJECTID 字段的值相等。</para>
		/// </param>
		/// <param name="OutputSpatialWeightsMatrixFile">
		/// <para>Output Spatial Weights Matrix File</para>
		/// <para>要创建的空间权重矩阵文件 (.swm) 的完整路径。</para>
		/// </param>
		/// <param name="ConceptualizationOfSpatialRelationships">
		/// <para>Conceptualization of Spatial Relationships</para>
		/// <para>指定要素空间关系的概念化方式。</para>
		/// <para>反距离—一个要素对另一个要素的影响随着距离的增加而减少。</para>
		/// <para>固定距离—将每个要素的指定临界距离内的所有要素都包含在分析中；将临界距离外的所有要素都排除在外。</para>
		/// <para>K 最近相邻要素—将最近的 k 要素包含在分析中；k 是指定的数字参数。</para>
		/// <para>仅邻接边—共享一个边界的面要素是相邻要素。</para>
		/// <para>邻接边拐角—共享一个边界和/或一个结点的面要素是相邻要素。</para>
		/// <para>Delaunay 三角测量—基于要素质心创建不重叠三角形的网格；共享边且与三角形结点关联的要素是相邻要素。</para>
		/// <para>空间时间窗—相邻要素是指在指定的临界距离内且在彼此的指定时间间隔内出现的要素。</para>
		/// <para>转换表—在表中定义空间关系。</para>
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
		/// <para>Tool Display Name : 生成空间权重矩阵</para>
		/// </summary>
		public override string DisplayName() => "生成空间权重矩阵";

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
		public override object[] Parameters() => new object[] { InputFeatureClass, UniqueIDField, OutputSpatialWeightsMatrixFile, ConceptualizationOfSpatialRelationships, DistanceMethod, Exponent, ThresholdDistance, NumberOfNeighbors, RowStandardization, InputTable, DateTimeField, DateTimeIntervalType, DateTimeIntervalValue, UseZValues };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>将被评估要素空间关系的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object InputFeatureClass { get; set; }

		/// <summary>
		/// <para>Unique ID Field</para>
		/// <para>包含输入要素类中每个要素不同值的整型字段。如果没有“唯一 ID”字段，则可以创建一个，方法是向要素类表添加一个整型字段，然后将此字段的值计算为与 FID 或 OBJECTID 字段的值相等。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object UniqueIDField { get; set; }

		/// <summary>
		/// <para>Output Spatial Weights Matrix File</para>
		/// <para>要创建的空间权重矩阵文件 (.swm) 的完整路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("swm")]
		public object OutputSpatialWeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Conceptualization of Spatial Relationships</para>
		/// <para>指定要素空间关系的概念化方式。</para>
		/// <para>反距离—一个要素对另一个要素的影响随着距离的增加而减少。</para>
		/// <para>固定距离—将每个要素的指定临界距离内的所有要素都包含在分析中；将临界距离外的所有要素都排除在外。</para>
		/// <para>K 最近相邻要素—将最近的 k 要素包含在分析中；k 是指定的数字参数。</para>
		/// <para>仅邻接边—共享一个边界的面要素是相邻要素。</para>
		/// <para>邻接边拐角—共享一个边界和/或一个结点的面要素是相邻要素。</para>
		/// <para>Delaunay 三角测量—基于要素质心创建不重叠三角形的网格；共享边且与三角形结点关联的要素是相邻要素。</para>
		/// <para>空间时间窗—相邻要素是指在指定的临界距离内且在彼此的指定时间间隔内出现的要素。</para>
		/// <para>转换表—在表中定义空间关系。</para>
		/// <para><see cref="ConceptualizationOfSpatialRelationshipsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConceptualizationOfSpatialRelationships { get; set; }

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>指定计算每个要素与邻近要素之间的距离的方式。</para>
		/// <para>欧氏—两点间的直线距离</para>
		/// <para>曼哈顿—沿垂直轴度量的两点间的距离（城市街区）；计算方法是对两点的 x 和 y 坐标的差值（绝对值）求和。</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceMethod { get; set; } = "EUCLIDEAN";

		/// <summary>
		/// <para>Exponent</para>
		/// <para>反距离计算参数。典型值是 1 或 2。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Exponent { get; set; } = "1";

		/// <summary>
		/// <para>Threshold Distance</para>
		/// <para>为空间关系的反距离和固定距离概念化指定中断距离。使用在环境输出坐标系中指定的单位输入此值。为空间关系的空间时间窗概念化定义空间窗的大小。</para>
		/// <para>零值表示未应用任何距离阈值。此参数留空时，将根据输出要素类范围和要素数目计算默认阈值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 999999999)]
		public object ThresholdDistance { get; set; }

		/// <summary>
		/// <para>Number of Neighbors</para>
		/// <para>用于表示相邻要素最小数目或精确数目的整数。对于 K 最近邻，每个要素的相邻要素数正好等于这个指定数目。对于反距离或固定距离，每个要素将至少具有这些数目的相邻要素（如有必要，距离阈值将临时增大以确保达到这个相邻要素数目）。选中一个邻接空间关系的概念化后，将向每个面分配至少该最小数目的相邻要素。对于具有少于此相邻要素数目的面，将根据要素质心邻近性获得附加相邻要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Row Standardization</para>
		/// <para>当要素的分布由于采样设计或施加的聚合方案而可能出现偏离时，建议使用行标准化。</para>
		/// <para>选中 - 按行对空间权重执行标准化。每个权重都除以它的行总和。这是默认设置。</para>
		/// <para>取消选中 - 不对空间权重执行标准化。</para>
		/// <para><see cref="RowStandardizationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object RowStandardization { get; set; } = "true";

		/// <summary>
		/// <para>Input Table</para>
		/// <para>由输入要素类中每个要素相对于其他要素的数字权重组成的表。必填字段是“输入要素类”、“唯一 ID 字段”、“NID”（相邻要素 ID）和“权重”。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object InputTable { get; set; }

		/// <summary>
		/// <para>Date/Time Field</para>
		/// <para>包含每个要素的时间戳的日期字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object DateTimeField { get; set; }

		/// <summary>
		/// <para>Date/Time Interval Type</para>
		/// <para>用于测量时间的单位。</para>
		/// <para>秒—秒</para>
		/// <para>分钟—分钟</para>
		/// <para>小时—小时</para>
		/// <para>天—天</para>
		/// <para>周—周</para>
		/// <para>月—30 天</para>
		/// <para>年—年</para>
		/// <para><see cref="DateTimeIntervalTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DateTimeIntervalType { get; set; }

		/// <summary>
		/// <para>Date/Time Interval Value</para>
		/// <para>反映构成时间窗的时间单位数量的整数。</para>
		/// <para>例如，如果为日期/时间间隔类型选择 HOURS，为日期/时间间隔值选择 3，则时间窗为 3 小时；位于指定空间窗和指定时间窗内的要素将成为相邻要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object DateTimeIntervalValue { get; set; }

		/// <summary>
		/// <para>Use Z values</para>
		/// <para>如果输入要素启用了 z 值，则可以选择使用或忽略 z 值。指定是否在空间权重矩阵的构建中包含 z 坐标。</para>
		/// <para>选中 - Z 值用于空间权重矩阵的构建中。</para>
		/// <para>未选中 - 忽略 Z 值且在空间权重矩阵的构建中仅考虑 X 和 Y 坐标。这是默认设置。</para>
		/// <para><see cref="UseZValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UseZValues { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateSpatialWeightsMatrix SetEnviroment(object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
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
			/// <para>反距离—一个要素对另一个要素的影响随着距离的增加而减少。</para>
			/// </summary>
			[GPValue("INVERSE_DISTANCE")]
			[Description("反距离")]
			Inverse_distance,

			/// <summary>
			/// <para>固定距离—将每个要素的指定临界距离内的所有要素都包含在分析中；将临界距离外的所有要素都排除在外。</para>
			/// </summary>
			[GPValue("FIXED_DISTANCE")]
			[Description("固定距离")]
			Fixed_distance,

			/// <summary>
			/// <para>K 最近相邻要素—将最近的 k 要素包含在分析中；k 是指定的数字参数。</para>
			/// </summary>
			[GPValue("K_NEAREST_NEIGHBORS")]
			[Description("K 最近相邻要素")]
			K_nearest_neighbors,

			/// <summary>
			/// <para>仅邻接边—共享一个边界的面要素是相邻要素。</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_ONLY")]
			[Description("仅邻接边")]
			Contiguity_edges_only,

			/// <summary>
			/// <para>邻接边拐角—共享一个边界和/或一个结点的面要素是相邻要素。</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_CORNERS")]
			[Description("邻接边拐角")]
			Contiguity_edges_corners,

			/// <summary>
			/// <para>Delaunay 三角测量—基于要素质心创建不重叠三角形的网格；共享边且与三角形结点关联的要素是相邻要素。</para>
			/// </summary>
			[GPValue("DELAUNAY_TRIANGULATION")]
			[Description("Delaunay 三角测量")]
			Delaunay_triangulation,

			/// <summary>
			/// <para>空间时间窗—相邻要素是指在指定的临界距离内且在彼此的指定时间间隔内出现的要素。</para>
			/// </summary>
			[GPValue("SPACE_TIME_WINDOW")]
			[Description("空间时间窗")]
			Space_time_window,

			/// <summary>
			/// <para>转换表—在表中定义空间关系。</para>
			/// </summary>
			[GPValue("CONVERT_TABLE")]
			[Description("转换表")]
			Convert_table,

		}

		/// <summary>
		/// <para>Distance Method</para>
		/// </summary>
		public enum DistanceMethodEnum 
		{
			/// <summary>
			/// <para>欧氏—两点间的直线距离</para>
			/// </summary>
			[GPValue("EUCLIDEAN")]
			[Description("欧氏")]
			Euclidean,

			/// <summary>
			/// <para>曼哈顿—沿垂直轴度量的两点间的距离（城市街区）；计算方法是对两点的 x 和 y 坐标的差值（绝对值）求和。</para>
			/// </summary>
			[GPValue("MANHATTAN")]
			[Description("曼哈顿")]
			Manhattan,

		}

		/// <summary>
		/// <para>Row Standardization</para>
		/// </summary>
		public enum RowStandardizationEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ROW_STANDARDIZATION")]
			ROW_STANDARDIZATION,

			/// <summary>
			/// <para></para>
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
			/// <para>秒—秒</para>
			/// </summary>
			[GPValue("SECONDS")]
			[Description("秒")]
			Seconds,

			/// <summary>
			/// <para>分钟—分钟</para>
			/// </summary>
			[GPValue("MINUTES")]
			[Description("分钟")]
			Minutes,

			/// <summary>
			/// <para>小时—小时</para>
			/// </summary>
			[GPValue("HOURS")]
			[Description("小时")]
			Hours,

			/// <summary>
			/// <para>天—天</para>
			/// </summary>
			[GPValue("DAYS")]
			[Description("天")]
			Days,

			/// <summary>
			/// <para>周—周</para>
			/// </summary>
			[GPValue("WEEKS")]
			[Description("周")]
			Weeks,

			/// <summary>
			/// <para>月—30 天</para>
			/// </summary>
			[GPValue("MONTHS")]
			[Description("月")]
			Months,

			/// <summary>
			/// <para>年—年</para>
			/// </summary>
			[GPValue("YEARS")]
			[Description("年")]
			Years,

		}

		/// <summary>
		/// <para>Use Z values</para>
		/// </summary>
		public enum UseZValuesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_Z_VALUES")]
			USE_Z_VALUES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_USE_Z_VALUES")]
			DO_NOT_USE_Z_VALUES,

		}

#endregion
	}
}
