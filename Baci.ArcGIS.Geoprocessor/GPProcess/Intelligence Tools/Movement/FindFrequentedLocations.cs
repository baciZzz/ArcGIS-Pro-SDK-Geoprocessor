using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IntelligenceTools
{
	/// <summary>
	/// <para>Find Frequented Locations</para>
	/// <para>查找常用位置</para>
	/// <para>识别运动轨迹已停留多个时间段的区域，并根据轨迹标识符聚合这些位置。</para>
	/// </summary>
	public class FindFrequentedLocations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>输入运动轨迹点，用于分析是否为可能的常用地点。 图层必须已启用时间。</para>
		/// </param>
		/// <param name="TrackIdField">
		/// <para>Track ID Field</para>
		/// <para>包含将源数据组织成运动轨迹的唯一标识符的字段。</para>
		/// </param>
		/// <param name="OutFeatureclass">
		/// <para>Output Feature Class</para>
		/// <para>包含可能常用位置的输出面要素类。</para>
		/// </param>
		public FindFrequentedLocations(object InFeatures, object TrackIdField, object OutFeatureclass)
		{
			this.InFeatures = InFeatures;
			this.TrackIdField = TrackIdField;
			this.OutFeatureclass = OutFeatureclass;
		}

		/// <summary>
		/// <para>Tool Display Name : 查找常用位置</para>
		/// </summary>
		public override string DisplayName() => "查找常用位置";

		/// <summary>
		/// <para>Tool Name : FindFrequentedLocations</para>
		/// </summary>
		public override string ToolName() => "FindFrequentedLocations";

		/// <summary>
		/// <para>Tool Excute Name : intelligence.FindFrequentedLocations</para>
		/// </summary>
		public override string ExcuteName() => "intelligence.FindFrequentedLocations";

		/// <summary>
		/// <para>Toolbox Display Name : Intelligence Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Intelligence Tools";

		/// <summary>
		/// <para>Toolbox Alise : intelligence</para>
		/// </summary>
		public override string ToolboxAlise() => "intelligence";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, TrackIdField, OutFeatureclass, Expression!, SearchDistance!, MinimumLoiterTime!, TimeBoundary!, MinimumDwells!, NormalizeDailyDistribution!, SummaryFields! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入运动轨迹点，用于分析是否为可能的常用地点。 图层必须已启用时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Track ID Field</para>
		/// <para>包含将源数据组织成运动轨迹的唯一标识符的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object TrackIdField { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含可能常用位置的输出面要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureclass { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>用于选择记录子集的 SQL 表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? Expression { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>运动轨迹点在不再被视为常用位置的一部分之前可以徘徊的最大距离。 默认值是 100 米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? SearchDistance { get; set; } = "100 Meters";

		/// <summary>
		/// <para>Minimum Loiter Time</para>
		/// <para>运动轨迹点在被视为停留之前可以在区域中徘徊的最短时间。</para>
		/// <para>该值有助于识别可能常用位置，其中多个唯一运动轨迹停留在同一时间和空间。 默认值为 10 分钟。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? MinimumLoiterTime { get; set; } = "10 Minutes";

		/// <summary>
		/// <para>Time Boundary</para>
		/// <para>将用于拆分输入要素参数值的时间跨度。 例如，如果您使用始于 1 天的时间界限，则轨迹将在每天开始时被分割。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TimeBoundary { get; set; } = "1 Days";

		/// <summary>
		/// <para>Minimum Dwells Per Location</para>
		/// <para>要定义为常用位置所需发生的重叠单次停留的最小数量。 默认情况下，将返回满足停留条件的所有位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MinimumDwells { get; set; } = "1";

		/// <summary>
		/// <para>Normalize Daily Distribution</para>
		/// <para>指定是否对停留位置的每日分布进行归一化。 归一化值表示在特定日期停留位置发生的总时间的百分比，而实际值表示在给定日期发生的停留总数。</para>
		/// <para>选中 - 将对停留位置值的每日分布进行归一化。</para>
		/// <para>未选中 - 不对停留位置值的每日分布进行归一化。 这是默认设置。</para>
		/// <para><see cref="NormalizeDailyDistributionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? NormalizeDailyDistribution { get; set; } = "false";

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>指定将计算的统计数据。</para>
		/// <para>可以计算以下变量的统计数据：</para>
		/// <para>开始时间 - 首次检测到单次停留位置的时间（以小时为单位）。 时间将舍入为最接近的小时。</para>
		/// <para>结束时间 - 最后一次检测到单次停留位置的时间（以小时为单位）。 时间将舍入为最接近的小时。</para>
		/// <para>停留持续时间 - 每个单次停留位置处于活动状态的时间（以秒为单位）</para>
		/// <para>支持以下统计数据：</para>
		/// <para>平均值 - 数值的平均值。</para>
		/// <para>最小值 - 数值字段的最小值。</para>
		/// <para>最大值 - 数值字段的最大值。</para>
		/// <para>标准差 - 数值字段的标准差。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? SummaryFields { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindFrequentedLocations SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Normalize Daily Distribution</para>
		/// </summary>
		public enum NormalizeDailyDistributionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("NORMALIZED")]
			NORMALIZED,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("REAL")]
			REAL,

		}

#endregion
	}
}
