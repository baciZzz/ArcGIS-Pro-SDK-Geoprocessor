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
	/// <para>Incremental Spatial Autocorrelation</para>
	/// <para>增量空间自相关</para>
	/// <para>测量一系列距离的空间自相关，并选择性创建这些距离及其相应 z 得分的折线图。z 得分反映空间聚类的程度，具有统计显著性的峰值 z 得分表示促进空间过程聚类最明显的距离。这些峰值距离通常为具有“距离范围”或“距离半径”参数的工具所使用的合适值。</para>
	/// </summary>
	public class IncrementalSpatialAutocorrelation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>要对一系列距离进行测量的空间自相关的要素类。</para>
		/// </param>
		/// <param name="InputField">
		/// <para>Input Field</para>
		/// <para>用于评估空间自相关的数值字段。</para>
		/// </param>
		/// <param name="NumberOfDistanceBands">
		/// <para>Number of Distance Bands</para>
		/// <para>针对空间自相关而增加邻域大小和分析数据集的次数。分别在开始距离和距离增量参数中指定的增量的起点和大小。</para>
		/// </param>
		public IncrementalSpatialAutocorrelation(object InputFeatures, object InputField, object NumberOfDistanceBands)
		{
			this.InputFeatures = InputFeatures;
			this.InputField = InputField;
			this.NumberOfDistanceBands = NumberOfDistanceBands;
		}

		/// <summary>
		/// <para>Tool Display Name : 增量空间自相关</para>
		/// </summary>
		public override string DisplayName() => "增量空间自相关";

		/// <summary>
		/// <para>Tool Name : IncrementalSpatialAutocorrelation</para>
		/// </summary>
		public override string ToolName() => "IncrementalSpatialAutocorrelation";

		/// <summary>
		/// <para>Tool Excute Name : stats.IncrementalSpatialAutocorrelation</para>
		/// </summary>
		public override string ExcuteName() => "stats.IncrementalSpatialAutocorrelation";

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
		public override object[] Parameters() => new object[] { InputFeatures, InputField, NumberOfDistanceBands, BeginningDistance!, DistanceIncrement!, DistanceMethod!, RowStandardization!, OutputTable!, OutputReportFile!, FirstPeak!, MaxPeak! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要对一系列距离进行测量的空间自相关的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Input Field</para>
		/// <para>用于评估空间自相关的数值字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object InputField { get; set; }

		/// <summary>
		/// <para>Number of Distance Bands</para>
		/// <para>针对空间自相关而增加邻域大小和分析数据集的次数。分别在开始距离和距离增量参数中指定的增量的起点和大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 30)]
		public object NumberOfDistanceBands { get; set; } = "10";

		/// <summary>
		/// <para>Beginning Distance</para>
		/// <para>开始空间自相关分析的距离和开始增量的距离。为此参数输入的值应使用输出坐标系环境设置的单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 999999999)]
		public object? BeginningDistance { get; set; }

		/// <summary>
		/// <para>Distance Increment</para>
		/// <para>每次迭代后要增加的距离。分析中使用的距离于开始距离处开始，以距离增量中指定的数量增加。为此参数输入的值应使用输出坐标系环境设置的单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1.0000000000000001e-09, Max = 999999999)]
		public object? DistanceIncrement { get; set; }

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
		public object? DistanceMethod { get; set; } = "EUCLIDEAN";

		/// <summary>
		/// <para>Row Standardization</para>
		/// <para>当要素的分布由于采样设计或施加的聚合方案而可能偏离时，建议使用行标准化。</para>
		/// <para>选中 - 将对空间权重执行标准化；每项权重将除以其所在行的和（所有相邻要素的权重和）。</para>
		/// <para>取消选中 - 不对空间权重执行标准化。</para>
		/// <para><see cref="RowStandardizationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? RowStandardization { get; set; } = "true";

		/// <summary>
		/// <para>Output Table</para>
		/// <para>要创建的表格包含各距离范围和相关 z 得分结果。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutputTable { get; set; }

		/// <summary>
		/// <para>Output Report File</para>
		/// <para>要创建的 PDF 文件包含汇总结果的折线图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("pdf")]
		public object? OutputReportFile { get; set; }

		/// <summary>
		/// <para>First Peak</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object? FirstPeak { get; set; }

		/// <summary>
		/// <para>Maximum Peak</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object? MaxPeak { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public IncrementalSpatialAutocorrelation SetEnviroment(object? geographicTransformations = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

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

#endregion
	}
}
