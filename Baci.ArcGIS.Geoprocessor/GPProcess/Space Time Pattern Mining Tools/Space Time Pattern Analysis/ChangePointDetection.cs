using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpaceTimePatternMiningTools
{
	/// <summary>
	/// <para>Change Point Detection</para>
	/// <para>变化点检测</para>
	/// <para>在时空立方体的每个位置的时间序列的统计属性发生变化时检测时间步长。</para>
	/// </summary>
	public class ChangePointDetection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCube">
		/// <para>Input Space Time Cube</para>
		/// <para>包含要分析的变量的时空立方体。 时空立方体具有 .nc 文件扩展名，是使用时空模式挖掘工具箱中的各种工具创建的。</para>
		/// </param>
		/// <param name="AnalysisVariable">
		/// <para>Analysis Variable</para>
		/// <para>包含每个位置的时间序列值的时空立方体的数值变量。</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>将包含变化点检测结果的输出要素类。 图层显示在每个位置检测到的变化点数量，并包含显示时间序列值、变化点和每个分段平均值或标准差的估算值的弹出图表。</para>
		/// </param>
		public ChangePointDetection(object InCube, object AnalysisVariable, object OutputFeatures)
		{
			this.InCube = InCube;
			this.AnalysisVariable = AnalysisVariable;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 变化点检测</para>
		/// </summary>
		public override string DisplayName() => "变化点检测";

		/// <summary>
		/// <para>Tool Name : ChangePointDetection</para>
		/// </summary>
		public override string ToolName() => "ChangePointDetection";

		/// <summary>
		/// <para>Tool Excute Name : stpm.ChangePointDetection</para>
		/// </summary>
		public override string ExcuteName() => "stpm.ChangePointDetection";

		/// <summary>
		/// <para>Toolbox Display Name : Space Time Pattern Mining Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Space Time Pattern Mining Tools";

		/// <summary>
		/// <para>Toolbox Alise : stpm</para>
		/// </summary>
		public override string ToolboxAlise() => "stpm";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCube, AnalysisVariable, OutputFeatures, ChangeType!, Method!, NumChangePoints!, Sensitivity!, MinSegLen! };

		/// <summary>
		/// <para>Input Space Time Cube</para>
		/// <para>包含要分析的变量的时空立方体。 时空立方体具有 .nc 文件扩展名，是使用时空模式挖掘工具箱中的各种工具创建的。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object InCube { get; set; }

		/// <summary>
		/// <para>Analysis Variable</para>
		/// <para>包含每个位置的时间序列值的时空立方体的数值变量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object AnalysisVariable { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>将包含变化点检测结果的输出要素类。 图层显示在每个位置检测到的变化点数量，并包含显示时间序列值、变化点和每个分段平均值或标准差的估算值的弹出图表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Change Type</para>
		/// <para>为检测到的变化指定类型。 各选项用于指定时间序列的统计属性，假设在每个分段中都是常数。 该值将在时间序列中的每个变化点更改为一个新的常数值。</para>
		/// <para>均值漂移—将检测平均值的平移。 这是默认设置。</para>
		/// <para>标准差—将检测标准差的变化。</para>
		/// <para>坡度（线性趋势）—将检测坡度的变化（线性趋势）。</para>
		/// <para>计数—将检测计数数据平均值的变化。</para>
		/// <para><see cref="ChangeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ChangeType { get; set; } = "MEAN";

		/// <summary>
		/// <para>Method</para>
		/// <para>指定是自动检测变化点的数量还是由用于所有位置的变化点定义数量指定。</para>
		/// <para>自动检测变化点数 (PELT)—将自动检测变化点数量。 检测灵敏度将由检测灵敏度参数定义。 这是默认设置。</para>
		/// <para>变化点定义数量 (SegNeigh)—变化点数量将由变化点数量参数定义。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "AUTO_DETECT";

		/// <summary>
		/// <para>Number of Change Points</para>
		/// <para>将检测各位置的变化点数量。 默认值为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumChangePoints { get; set; } = "1";

		/// <summary>
		/// <para>Detection Sensitivity</para>
		/// <para>介于 0 和 1 之间的数值，用于定义检测的灵敏度。 值越大，在每个位置检测到的变化点越多。 默认值为 0.5。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 1)]
		public object? Sensitivity { get; set; } = "0.5";

		/// <summary>
		/// <para>Minimum Segment Length</para>
		/// <para>每分段内的最小时间步长数。 变化点会将每个时间序列划分为多个分段，其中每个分段应至少具有此数量的时间步长。 对于均值、标准差和计数的变化，默认值为 1，这意味着每个时间步长都可以是一个变化点。 对于坡度变化（线性趋势），默认值为 2，因为至少需要两个值才可以拟合线。 该值必须小于时间序列中时间步长数的一半。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MinSegLen { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ChangePointDetection SetEnviroment(object? outputCoordinateSystem = null, object? parallelProcessingFactor = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Change Type</para>
		/// </summary>
		public enum ChangeTypeEnum 
		{
			/// <summary>
			/// <para>均值漂移—将检测平均值的平移。 这是默认设置。</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("均值漂移")]
			Mean_shift,

			/// <summary>
			/// <para>标准差—将检测标准差的变化。</para>
			/// </summary>
			[GPValue("STANDARD_DEVIATION")]
			[Description("标准差")]
			Standard_deviation,

			/// <summary>
			/// <para>坡度（线性趋势）—将检测坡度的变化（线性趋势）。</para>
			/// </summary>
			[GPValue("SLOPE")]
			[Description("坡度（线性趋势）")]
			SLOPE,

			/// <summary>
			/// <para>计数—将检测计数数据平均值的变化。</para>
			/// </summary>
			[GPValue("COUNT")]
			[Description("计数")]
			Count,

		}

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>自动检测变化点数 (PELT)—将自动检测变化点数量。 检测灵敏度将由检测灵敏度参数定义。 这是默认设置。</para>
			/// </summary>
			[GPValue("AUTO_DETECT")]
			[Description("自动检测变化点数 (PELT)")]
			AUTO_DETECT,

			/// <summary>
			/// <para>变化点定义数量 (SegNeigh)—变化点数量将由变化点数量参数定义。</para>
			/// </summary>
			[GPValue("DEFINED_NUMBER")]
			[Description("变化点定义数量 (SegNeigh)")]
			DEFINED_NUMBER,

		}

#endregion
	}
}
