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
	/// <para>Find Dwell Locations</para>
	/// <para>查找停留位置</para>
	/// <para>使用给定的时间和距离阈值来查找移动对象已停止或停留的位置。</para>
	/// </summary>
	public class FindDwellLocations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>可从中找到停留的点轨迹。输入必须为启用时间的图层，并具有用于表示时刻的要素。</para>
		/// </param>
		/// <param name="Output">
		/// <para>Output Dataset</para>
		/// <para>带有所生成停留的输出要素类。</para>
		/// </param>
		/// <param name="TrackFields">
		/// <para>Track Fields</para>
		/// <para>将用于标识唯一轨迹的一个或多个字段。</para>
		/// </param>
		/// <param name="DistanceMethod">
		/// <para>Distance Method</para>
		/// <para>指定如何计算停留要素之间的距离。</para>
		/// <para>测地线— 如果空间参考可以平移，则轨迹将在适当的时候穿过国际日期变更线。如果空间参考不可平移，则轨迹将被限制在坐标系的范围之内且不可环绕。</para>
		/// <para>平面—将使用平面距离。</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </param>
		/// <param name="DistanceTolerance">
		/// <para>Distance Tolerance</para>
		/// <para>点之间将视为一个停留位置的最大距离。</para>
		/// <para><see cref="DistanceToleranceEnum"/></para>
		/// </param>
		/// <param name="TimeTolerance">
		/// <para>Time Tolerance</para>
		/// <para>将视为单个停留位置的最短持续时间。</para>
		/// <para>在查找停留时，系统会同时考虑时间和距离。距离容差参数将指定距离。</para>
		/// <para><see cref="TimeToleranceEnum"/></para>
		/// </param>
		/// <param name="OutputType">
		/// <para>Output Type</para>
		/// <para>用于指定将如何输出停留要素。</para>
		/// <para>停留要素— 将返回构成停留的所有输入点要素。</para>
		/// <para>平均中心— 将返回表示每个停留组的平均中心的点。这是默认设置。</para>
		/// <para>凸包— 将返回表示每个停留组的凸包的面。</para>
		/// <para>所有要素— 将返回所有输入点要素。</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </param>
		public FindDwellLocations(object InputFeatures, object Output, object TrackFields, object DistanceMethod, object DistanceTolerance, object TimeTolerance, object OutputType)
		{
			this.InputFeatures = InputFeatures;
			this.Output = Output;
			this.TrackFields = TrackFields;
			this.DistanceMethod = DistanceMethod;
			this.DistanceTolerance = DistanceTolerance;
			this.TimeTolerance = TimeTolerance;
			this.OutputType = OutputType;
		}

		/// <summary>
		/// <para>Tool Display Name : 查找停留位置</para>
		/// </summary>
		public override string DisplayName() => "查找停留位置";

		/// <summary>
		/// <para>Tool Name : FindDwellLocations</para>
		/// </summary>
		public override string ToolName() => "FindDwellLocations";

		/// <summary>
		/// <para>Tool Excute Name : gapro.FindDwellLocations</para>
		/// </summary>
		public override string ExcuteName() => "gapro.FindDwellLocations";

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
		public override object[] Parameters() => new object[] { InputFeatures, Output, TrackFields, DistanceMethod, DistanceTolerance, TimeTolerance, OutputType, SummaryStatistics, TimeBoundarySplit, TimeBoundaryReference };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>可从中找到停留的点轨迹。输入必须为启用时间的图层，并具有用于表示时刻的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// <para>带有所生成停留的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Track Fields</para>
		/// <para>将用于标识唯一轨迹的一个或多个字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object TrackFields { get; set; }

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>指定如何计算停留要素之间的距离。</para>
		/// <para>测地线— 如果空间参考可以平移，则轨迹将在适当的时候穿过国际日期变更线。如果空间参考不可平移，则轨迹将被限制在坐标系的范围之内且不可环绕。</para>
		/// <para>平面—将使用平面距离。</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceMethod { get; set; } = "PLANAR";

		/// <summary>
		/// <para>Distance Tolerance</para>
		/// <para>点之间将视为一个停留位置的最大距离。</para>
		/// <para><see cref="DistanceToleranceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object DistanceTolerance { get; set; }

		/// <summary>
		/// <para>Time Tolerance</para>
		/// <para>将视为单个停留位置的最短持续时间。</para>
		/// <para>在查找停留时，系统会同时考虑时间和距离。距离容差参数将指定距离。</para>
		/// <para><see cref="TimeToleranceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object TimeTolerance { get; set; }

		/// <summary>
		/// <para>Output Type</para>
		/// <para>用于指定将如何输出停留要素。</para>
		/// <para>停留要素— 将返回构成停留的所有输入点要素。</para>
		/// <para>平均中心— 将返回表示每个停留组的平均中心的点。这是默认设置。</para>
		/// <para>凸包— 将返回表示每个停留组的凸包的面。</para>
		/// <para>所有要素— 将返回所有输入点要素。</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutputType { get; set; } = "DWELL_FEATURES";

		/// <summary>
		/// <para>Summary Statistics</para>
		/// <para>将根据指定字段进行计算的统计数据。</para>
		/// <para>计数 - 非空值的数目。可用于数值字段或字符串。[null, 0, 2] 的计数为 2。</para>
		/// <para>总和 - 字段内数值的总和。[null, null, 3] 的总和为 3。</para>
		/// <para>平均值 - 数值的平均值。[0, 2, null] 的平均值为 1。</para>
		/// <para>最小值 - 数值字段的最小值。[0, 2, null] 的最小值为 0。</para>
		/// <para>最大值 - 数值字段的最大值。[0, 2, null] 的最大值为 2。</para>
		/// <para>标准差 - 数值字段的标准差。[1] 的标准差为 null。[null, 1,1,1] 的标准差为 null。</para>
		/// <para>方差 - 轨迹中数值字段内数值的方差。[1] 的方差为 null。[null, 1, 1, 1] 的方差为 null。</para>
		/// <para>范围 - 数值字段的范围。其计算方法为最大值减去最小值。[0, null, 1] 的范围为 1。[null, 4] 的范围为 0。</para>
		/// <para>任何 - 字符串型字段中的示例字符串。</para>
		/// <para>第一个 - 轨迹中指定字段的第一个值。</para>
		/// <para>最后一个 - 轨迹中指定字段的最后一个值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object SummaryStatistics { get; set; }

		/// <summary>
		/// <para>Time Boundary Split</para>
		/// <para>用于分割输入数据以进行分析的时间跨度。您可通过时间界限分析定义的时间跨度内的值。例如，如果您使用 1 天的时间界限，并将时间界限参考设置为 1980 年 1 月 1 日，则轨迹将在每天开始时被分割。</para>
		/// <para><see cref="TimeBoundarySplitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object TimeBoundarySplit { get; set; }

		/// <summary>
		/// <para>Time Boundary Reference</para>
		/// <para>用于分割输入数据以进行分析的参考时间。将为整个数据跨度创建时间界限，且不需要在开始时产生参考时间。如果未指定参考时间，则将使用 1970 年 1 月 1 日。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object TimeBoundaryReference { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindDwellLocations SetEnviroment(object extent = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Method</para>
		/// </summary>
		public enum DistanceMethodEnum 
		{
			/// <summary>
			/// <para>平面—将使用平面距离。</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("平面")]
			Planar,

			/// <summary>
			/// <para>测地线— 如果空间参考可以平移，则轨迹将在适当的时候穿过国际日期变更线。如果空间参考不可平移，则轨迹将被限制在坐标系的范围之内且不可环绕。</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("测地线")]
			Geodesic,

		}

		/// <summary>
		/// <para>Distance Tolerance</para>
		/// </summary>
		public enum DistanceToleranceEnum 
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
		/// <para>Time Tolerance</para>
		/// </summary>
		public enum TimeToleranceEnum 
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
		/// <para>Output Type</para>
		/// </summary>
		public enum OutputTypeEnum 
		{
			/// <summary>
			/// <para>平均中心— 将返回表示每个停留组的平均中心的点。这是默认设置。</para>
			/// </summary>
			[GPValue("DWELL_MEAN_CENTERS")]
			[Description("平均中心")]
			Mean_centers,

			/// <summary>
			/// <para>凸包— 将返回表示每个停留组的凸包的面。</para>
			/// </summary>
			[GPValue("DWELL_CONVEX_HULLS")]
			[Description("凸包")]
			Convex_hulls,

			/// <summary>
			/// <para>停留要素— 将返回构成停留的所有输入点要素。</para>
			/// </summary>
			[GPValue("DWELL_FEATURES")]
			[Description("停留要素")]
			Dwell_features,

			/// <summary>
			/// <para>所有要素— 将返回所有输入点要素。</para>
			/// </summary>
			[GPValue("ALL_FEATURES")]
			[Description("所有要素")]
			All_features,

		}

		/// <summary>
		/// <para>Time Boundary Split</para>
		/// </summary>
		public enum TimeBoundarySplitEnum 
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
