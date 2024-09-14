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
	/// <para>Create Space Time Cube</para>
	/// <para>创建时空立方体</para>
	/// <para>通过将一组点聚合到空间时间条柱的方法将其汇总到 netCDF 数据结构中。在每个条柱内计算点计数并聚合指定属性。对于所有条柱位置，评估计数趋势和汇总字段值。</para>
	/// </summary>
	public class CreateSpaceTimeCube : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="PointLayer">
		/// <para>Point Layer</para>
		/// <para>将聚合到时空条柱的输入点要素类。</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>将创建的输出 netCDF 数据立方体，以包含输入要素点数据的计数和汇总。</para>
		/// </param>
		/// <param name="DistanceInterval">
		/// <para>Distance Interval</para>
		/// <para>条柱尺寸将用于聚合点图层。将对相同距离间隔和时间间隔内的所有点进行聚合。</para>
		/// <para>确定条柱大小的距离。</para>
		/// <para><see cref="DistanceIntervalEnum"/></para>
		/// </param>
		/// <param name="TimeStepInterval">
		/// <para>Time Interval</para>
		/// <para>用来表示单个时间步长的秒数、分钟数、小时数、天数、周数或年数。将对相同时间间隔和距离间隔内的所有点进行聚合。此参数的有效条目示例为 1 周、13 天或 1 个月。</para>
		/// <para><see cref="TimeStepIntervalEnum"/></para>
		/// </param>
		public CreateSpaceTimeCube(object PointLayer, object OutputName, object DistanceInterval, object TimeStepInterval)
		{
			this.PointLayer = PointLayer;
			this.OutputName = OutputName;
			this.DistanceInterval = DistanceInterval;
			this.TimeStepInterval = TimeStepInterval;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建时空立方体</para>
		/// </summary>
		public override string DisplayName() => "创建时空立方体";

		/// <summary>
		/// <para>Tool Name : CreateSpaceTimeCube</para>
		/// </summary>
		public override string ToolName() => "CreateSpaceTimeCube";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.CreateSpaceTimeCube</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.CreateSpaceTimeCube";

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
		public override object[] Parameters() => new object[] { PointLayer, OutputName, DistanceInterval, TimeStepInterval, TimeStepIntervalAlignment, ReferenceTime, SummaryFields, Output };

		/// <summary>
		/// <para>Point Layer</para>
		/// <para>将聚合到时空条柱的输入点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple")]
		[PortalType("DataStoreCatalogLayer")]
		public object PointLayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>将创建的输出 netCDF 数据立方体，以包含输入要素点数据的计数和汇总。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Distance Interval</para>
		/// <para>条柱尺寸将用于聚合点图层。将对相同距离间隔和时间间隔内的所有点进行聚合。</para>
		/// <para>确定条柱大小的距离。</para>
		/// <para><see cref="DistanceIntervalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object DistanceInterval { get; set; }

		/// <summary>
		/// <para>Time Interval</para>
		/// <para>用来表示单个时间步长的秒数、分钟数、小时数、天数、周数或年数。将对相同时间间隔和距离间隔内的所有点进行聚合。此参数的有效条目示例为 1 周、13 天或 1 个月。</para>
		/// <para><see cref="TimeStepIntervalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object TimeStepInterval { get; set; }

		/// <summary>
		/// <para>Time Interval Alignment</para>
		/// <para>指定如何根据时间间隔 （Python 中的 time_step_interval）参数进行聚合。</para>
		/// <para>结束时间—时间步长将与最后一次时间事件对齐，并向后聚合时间。</para>
		/// <para>开始时间—时间步长将与第一次时间事件对齐，并向前聚合时间。</para>
		/// <para>参考时间—时间步长将与指定日期或时间对齐。如果输入要素中的所有点具有的时间戳大于指定的参考时间（或时间戳刚好位于输入要素的开始时间），则时间步长间隔将以该参考时间为起始时间，并向前聚合时间（与使用起始时间对齐的情况相同）。如果输入要素中的所有点具有的时间戳小于指定的参考时间（或时间戳刚好位于输入要素的结束时间），则时间步长间隔将以该参考时间为结束时间，并向后聚合时间（与使用结束时间对齐的情况相同）。如果指定的参考时间处于数据时间范围的中间，则将以提供的参考时间结束创建时间步长间隔（与使用结束时间对齐的情况相同）；其他间隔将在参考时间前后进行创建，直到覆盖数据的完整时间范围为止。</para>
		/// <para><see cref="TimeStepIntervalAlignmentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TimeStepIntervalAlignment { get; set; }

		/// <summary>
		/// <para>Reference Time</para>
		/// <para>将用于对齐时间步长间隔的日期或时间。例如，如果要按星期从星期一至星期天对数据进行归类，请将星期天的午夜设置为参考时间，以确保条柱在星期天和星期一之间的午夜进行划分。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object ReferenceTime { get; set; }

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>包含将用于在聚合到时空立方体时计算指定统计数据的属性值的数值字段。可以指定多项统计和字段组合。空值将被排除在所有统计计算之外。</para>
		/// <para>可用统计数据类型如下：</para>
		/// <para>总和 - 添加每个条柱中指定字段的合计值。</para>
		/// <para>平均值 - 计算每个条柱中指定字段的平均值。</para>
		/// <para>最小值 - 查找每个条柱中指定字段所有记录的最小值。</para>
		/// <para>最大值 - 查找每个条柱中指定字段所有记录的最大值。</para>
		/// <para>标准差 - 查找每个条柱中指定字段的值的标准差。</para>
		/// <para>可用填充类型如下：</para>
		/// <para>零 - 用零填充空条柱。</para>
		/// <para>Spatial_Neighbors - 用空间相邻要素平均值填充空条柱。</para>
		/// <para>时空邻域 - 用时空相邻要素平均值填充空条柱。</para>
		/// <para>时间趋势 - 使用一元样条插值算法填充空条柱。</para>
		/// <para>任何汇总字段中出现的空值都将导致从分析中排除这些要素。如果每个条柱中的点数均为分析策略的一部分，需要考虑创建单独的立方体，针对计数（不含汇总字段）创建一个，并针对汇总字段创建一个。如果每个汇总字段的空值集不相同，需要考虑为每个汇总字段创建一个单独的立方体。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object SummaryFields { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateSpaceTimeCube SetEnviroment(object extent = null, object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Interval</para>
		/// </summary>
		public enum DistanceIntervalEnum 
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
		/// <para>Time Interval</para>
		/// </summary>
		public enum TimeStepIntervalEnum 
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

		/// <summary>
		/// <para>Time Interval Alignment</para>
		/// </summary>
		public enum TimeStepIntervalAlignmentEnum 
		{
			/// <summary>
			/// <para>结束时间—时间步长将与最后一次时间事件对齐，并向后聚合时间。</para>
			/// </summary>
			[GPValue("END_TIME")]
			[Description("结束时间")]
			End_time,

			/// <summary>
			/// <para>开始时间—时间步长将与第一次时间事件对齐，并向前聚合时间。</para>
			/// </summary>
			[GPValue("START_TIME")]
			[Description("开始时间")]
			Start_time,

			/// <summary>
			/// <para>参考时间—时间步长将与指定日期或时间对齐。如果输入要素中的所有点具有的时间戳大于指定的参考时间（或时间戳刚好位于输入要素的开始时间），则时间步长间隔将以该参考时间为起始时间，并向前聚合时间（与使用起始时间对齐的情况相同）。如果输入要素中的所有点具有的时间戳小于指定的参考时间（或时间戳刚好位于输入要素的结束时间），则时间步长间隔将以该参考时间为结束时间，并向后聚合时间（与使用结束时间对齐的情况相同）。如果指定的参考时间处于数据时间范围的中间，则将以提供的参考时间结束创建时间步长间隔（与使用结束时间对齐的情况相同）；其他间隔将在参考时间前后进行创建，直到覆盖数据的完整时间范围为止。</para>
			/// </summary>
			[GPValue("REFERENCE_TIME")]
			[Description("参考时间")]
			Reference_time,

		}

#endregion
	}
}
