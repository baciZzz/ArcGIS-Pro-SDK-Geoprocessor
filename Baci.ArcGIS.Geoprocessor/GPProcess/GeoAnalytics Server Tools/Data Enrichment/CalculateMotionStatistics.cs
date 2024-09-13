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
	/// <para>Calculate Motion Statistics</para>
	/// <para>计算动态统计数据</para>
	/// <para>计算启用时间的要素类中点的动态统计数据。</para>
	/// </summary>
	public class CalculateMotionStatistics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>将计算动态统计数据的启用时间的点要素。</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>结果图层的名称。</para>
		/// </param>
		/// <param name="TrackFields">
		/// <para>Track Fields</para>
		/// <para>用于标识不同实体的一个或多个字段。</para>
		/// </param>
		/// <param name="TrackHistoryWindow">
		/// <para>Track History Window</para>
		/// <para>将用于汇总统计数据的观测点数（包括当前观测点）。 默认值为 3，这意味着将使用当前观测点和前两个观测点在轨迹的每个点上计算汇总统计数据。 此参数不会影响瞬时统计数据或空闲分类。</para>
		/// </param>
		public CalculateMotionStatistics(object InputLayer, object OutputName, object TrackFields, object TrackHistoryWindow)
		{
			this.InputLayer = InputLayer;
			this.OutputName = OutputName;
			this.TrackFields = TrackFields;
			this.TrackHistoryWindow = TrackHistoryWindow;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算动态统计数据</para>
		/// </summary>
		public override string DisplayName() => "计算动态统计数据";

		/// <summary>
		/// <para>Tool Name : CalculateMotionStatistics</para>
		/// </summary>
		public override string ToolName() => "CalculateMotionStatistics";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.CalculateMotionStatistics</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.CalculateMotionStatistics";

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
		public override object[] Parameters() => new object[] { InputLayer, OutputName, TrackFields, TrackHistoryWindow, MotionStatistics, DistanceMethod, IdleDistTolerance, IdleTimeTolerance, TimeBoundarySplit, TimeBoundaryReference, DistanceUnit, DurationUnit, SpeedUnit, AccelerationUnit, ElevationUnit, DataStore, Output };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>将计算动态统计数据的启用时间的点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple")]
		[PortalType("DataStoreCatalogLayer")]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>结果图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Track Fields</para>
		/// <para>用于标识不同实体的一个或多个字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object TrackFields { get; set; }

		/// <summary>
		/// <para>Track History Window</para>
		/// <para>将用于汇总统计数据的观测点数（包括当前观测点）。 默认值为 3，这意味着将使用当前观测点和前两个观测点在轨迹的每个点上计算汇总统计数据。 此参数不会影响瞬时统计数据或空闲分类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object TrackHistoryWindow { get; set; }

		/// <summary>
		/// <para>Motion Statistics</para>
		/// <para>指定包含要计算并写入结果的统计数据的组。 如果未提供任何值，则将计算所有组的所有统计数据。</para>
		/// <para>距离分析—将计算轨迹历史记录窗口中当前观测点和先前观测点之间的距离以及最大距离、最小距离、平均距离和总距离。</para>
		/// <para>持续时间—将计算轨迹历史记录窗口中当前观测点和先前观测点之间的持续时间以及最大持续时间、最小持续时间、平均持续时间和总持续时间。</para>
		/// <para>速度—将计算轨迹历史记录窗口中当前观测点和先前观测点之间的行驶速度以及最大行驶速度、最小行驶速度和平均行驶速度。</para>
		/// <para>加速—将计算轨迹历史记录窗口中当前速度和先前速度之间的加速度以及最大加速度、最小加速度和平均加速度。</para>
		/// <para>高程—将计算轨迹历史记录窗口中的当前高程、当前高程和先前高程之间的高程变化以及最大高程变化、最小高程变化、平均高程变化和总高程变化。</para>
		/// <para>坡度—将计算轨迹历史记录窗口中当前观测点和先前观测点之间的坡度以及最大坡度、最小坡度和平均坡度。</para>
		/// <para>空闲—将计算轨迹历史记录窗口实体当前是否空闲以及空闲时间百分比和总空闲时间。</para>
		/// <para>方位—将计算先前观测点与当前观测点之间的行驶角度。</para>
		/// <para><see cref="MotionStatisticsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object MotionStatistics { get; set; }

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>指定在计算动态统计数据时将使用的距离测量方法。</para>
		/// <para>测地线—将使用测地线距离。</para>
		/// <para>平面—将使用平面距离。 这是默认设置。</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceMethod { get; set; }

		/// <summary>
		/// <para>Idle Distance Tolerance</para>
		/// <para>轨迹中的两个连续点视为空闲时可以分开的最大距离。 此参数与空闲时间容差参数一起用于确定实体是否空闲。 如果在动态统计数据参数中指定了空闲统计数据组，或者如果要计算所有组中的统计数据，空闲距离容差参数为必需项。</para>
		/// <para><see cref="IdleDistToleranceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object IdleDistTolerance { get; set; }

		/// <summary>
		/// <para>Idle Time Tolerance</para>
		/// <para>轨迹中的两个连续点视为空闲时必须彼此靠近的最小持续时间。 此参数与空闲距离容差参数一起用于确定实体是否空闲。 如果在动态统计数据参数中指定了空闲统计数据组，或者如果要计算所有组中的统计数据，空闲时间容差参数为必需项。</para>
		/// <para><see cref="IdleTimeToleranceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object IdleTimeTolerance { get; set; }

		/// <summary>
		/// <para>Time Boundary Split</para>
		/// <para>用于分割输入数据以进行分析的时间跨度。您可通过时间界限分析定义的时间跨度内的值。例如，如果您使用始于 1980 年 1 月 1 日的 1 天的时间界限，则轨迹将在每天开始时被分割。此参数仅适用于 ArcGIS Enterprise 10.7 及更高版本。</para>
		/// <para><see cref="TimeBoundarySplitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object TimeBoundarySplit { get; set; }

		/// <summary>
		/// <para>Time Boundary Reference</para>
		/// <para>用于分割输入数据以进行分析的参考时间。将为整个数据跨度创建时间界限，且不需要在开始时产生参考时间。如果未指定参考时间，则将使用 1970 年 1 月 1 日。此参数仅适用于 ArcGIS Enterprise 10.7 及更高版本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Advanced Options")]
		public object TimeBoundaryReference { get; set; }

		/// <summary>
		/// <para>Distance Unit</para>
		/// <para>指定输出要素类中距离值的测量单位。</para>
		/// <para>米—测量单位为米。 这是默认设置。</para>
		/// <para>千米—测量单位为千米。</para>
		/// <para>英里—测量单位为英里。</para>
		/// <para>海里—测量单位为海里。</para>
		/// <para>码—测量单位为码。</para>
		/// <para>英尺—测量单位为英尺。</para>
		/// <para><see cref="DistanceUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object DistanceUnit { get; set; }

		/// <summary>
		/// <para>Duration Unit</para>
		/// <para>指定输出要素类中持续时间值的测量单位。</para>
		/// <para>年—测量单位为年。</para>
		/// <para>月—测量单位为月。</para>
		/// <para>周—测量单位为周。</para>
		/// <para>天—测量单位为天。</para>
		/// <para>小时—测量单位为小时。</para>
		/// <para>分—测量单位为分钟。</para>
		/// <para>秒—测量单位为秒。 这是默认设置。</para>
		/// <para>毫秒—测量单位为毫秒。</para>
		/// <para><see cref="DurationUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object DurationUnit { get; set; }

		/// <summary>
		/// <para>Speed Unit</para>
		/// <para>指定输出要素类中速度值的测量单位。</para>
		/// <para>米/秒—测量单位为米/秒。 这是默认设置。</para>
		/// <para>英里/小时—测量单位为英里/小时。</para>
		/// <para>千米/小时—测量单位为千米/小时。</para>
		/// <para>英尺/秒—测量单位为英尺/秒。</para>
		/// <para>海里/小时—测量单位为海里/小时。</para>
		/// <para><see cref="SpeedUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object SpeedUnit { get; set; }

		/// <summary>
		/// <para>Acceleration Unit</para>
		/// <para>指定输出要素类中加速度值的测量单位。</para>
		/// <para>米/平方秒—测量单位为米/平方秒。 这是默认设置。</para>
		/// <para>英尺/平方秒—测量单位为英尺/平方秒。</para>
		/// <para><see cref="AccelerationUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object AccelerationUnit { get; set; }

		/// <summary>
		/// <para>Elevation Unit</para>
		/// <para>指定输出要素类中高程值的测量单位。</para>
		/// <para>米—测量单位为米。 这是默认设置。</para>
		/// <para>千米—测量单位为千米。</para>
		/// <para>英里—测量单位为英里。</para>
		/// <para>海里—测量单位为海里。</para>
		/// <para>码—测量单位为码。</para>
		/// <para>英尺—测量单位为英尺。</para>
		/// <para><see cref="ElevationUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object ElevationUnit { get; set; }

		/// <summary>
		/// <para>Data Store</para>
		/// <para>指定将用于保存输出的 ArcGIS Data Store。默认为 SPATIOTEMPORAL_DATA_STORE。在时空大数据存储中存储的所有结果都将存储在 WGS84 中。在关系数据存储中存储的结果都将保持各自的坐标系。</para>
		/// <para>时空大数据存储—输出将存储在时空大数据存储中。这是默认设置。</para>
		/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Data Store")]
		public object DataStore { get; set; }

		/// <summary>
		/// <para>Output Feature Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateMotionStatistics SetEnviroment(object extent = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Motion Statistics</para>
		/// </summary>
		public enum MotionStatisticsEnum 
		{
			/// <summary>
			/// <para>距离分析—将计算轨迹历史记录窗口中当前观测点和先前观测点之间的距离以及最大距离、最小距离、平均距离和总距离。</para>
			/// </summary>
			[GPValue("DISTANCE")]
			[Description("距离分析")]
			Distance,

			/// <summary>
			/// <para>持续时间—将计算轨迹历史记录窗口中当前观测点和先前观测点之间的持续时间以及最大持续时间、最小持续时间、平均持续时间和总持续时间。</para>
			/// </summary>
			[GPValue("DURATION")]
			[Description("持续时间")]
			Duration,

			/// <summary>
			/// <para>速度—将计算轨迹历史记录窗口中当前观测点和先前观测点之间的行驶速度以及最大行驶速度、最小行驶速度和平均行驶速度。</para>
			/// </summary>
			[GPValue("SPEED")]
			[Description("速度")]
			Speed,

			/// <summary>
			/// <para>加速—将计算轨迹历史记录窗口中当前速度和先前速度之间的加速度以及最大加速度、最小加速度和平均加速度。</para>
			/// </summary>
			[GPValue("ACCELERATION")]
			[Description("加速")]
			Acceleration,

			/// <summary>
			/// <para>高程—将计算轨迹历史记录窗口中的当前高程、当前高程和先前高程之间的高程变化以及最大高程变化、最小高程变化、平均高程变化和总高程变化。</para>
			/// </summary>
			[GPValue("ELEVATION")]
			[Description("高程")]
			Elevation,

			/// <summary>
			/// <para>坡度—将计算轨迹历史记录窗口中当前观测点和先前观测点之间的坡度以及最大坡度、最小坡度和平均坡度。</para>
			/// </summary>
			[GPValue("SLOPE")]
			[Description("坡度")]
			Slope,

			/// <summary>
			/// <para>方位—将计算先前观测点与当前观测点之间的行驶角度。</para>
			/// </summary>
			[GPValue("BEARING")]
			[Description("方位")]
			Bearing,

			/// <summary>
			/// <para>空闲—将计算轨迹历史记录窗口实体当前是否空闲以及空闲时间百分比和总空闲时间。</para>
			/// </summary>
			[GPValue("IDLE")]
			[Description("空闲")]
			Idle,

		}

		/// <summary>
		/// <para>Distance Method</para>
		/// </summary>
		public enum DistanceMethodEnum 
		{
			/// <summary>
			/// <para>平面—将使用平面距离。 这是默认设置。</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("平面")]
			Planar,

			/// <summary>
			/// <para>测地线—将使用测地线距离。</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("测地线")]
			Geodesic,

		}

		/// <summary>
		/// <para>Idle Distance Tolerance</para>
		/// </summary>
		public enum IdleDistToleranceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("英尺")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("码")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("英里")]
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
			[Description("米")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("千米")]
			Kilometers,

		}

		/// <summary>
		/// <para>Idle Time Tolerance</para>
		/// </summary>
		public enum IdleTimeToleranceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Milliseconds")]
			[Description("毫秒")]
			Milliseconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Seconds")]
			[Description("秒")]
			Seconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("分")]
			Minutes,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Hours")]
			[Description("小时")]
			Hours,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Days")]
			[Description("天")]
			Days,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Weeks")]
			[Description("周")]
			Weeks,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Months")]
			[Description("月")]
			Months,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Years")]
			[Description("年")]
			Years,

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
			[Description("毫秒")]
			Milliseconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Seconds")]
			[Description("秒")]
			Seconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("分")]
			Minutes,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Hours")]
			[Description("小时")]
			Hours,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Days")]
			[Description("天")]
			Days,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Weeks")]
			[Description("周")]
			Weeks,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Months")]
			[Description("月")]
			Months,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Years")]
			[Description("年")]
			Years,

		}

		/// <summary>
		/// <para>Distance Unit</para>
		/// </summary>
		public enum DistanceUnitEnum 
		{
			/// <summary>
			/// <para>千米—测量单位为千米。</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("千米")]
			Kilometers,

			/// <summary>
			/// <para>米—测量单位为米。 这是默认设置。</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("米")]
			Meters,

			/// <summary>
			/// <para>英里—测量单位为英里。</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("英里")]
			Miles,

			/// <summary>
			/// <para>海里—测量单位为海里。</para>
			/// </summary>
			[GPValue("NAUTICAL_MILES")]
			[Description("海里")]
			Nautical_Miles,

			/// <summary>
			/// <para>码—测量单位为码。</para>
			/// </summary>
			[GPValue("YARDS")]
			[Description("码")]
			Yards,

			/// <summary>
			/// <para>英尺—测量单位为英尺。</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("英尺")]
			Feet,

		}

		/// <summary>
		/// <para>Duration Unit</para>
		/// </summary>
		public enum DurationUnitEnum 
		{
			/// <summary>
			/// <para>年—测量单位为年。</para>
			/// </summary>
			[GPValue("YEARS")]
			[Description("年")]
			Years,

			/// <summary>
			/// <para>月—测量单位为月。</para>
			/// </summary>
			[GPValue("MONTHS")]
			[Description("月")]
			Months,

			/// <summary>
			/// <para>周—测量单位为周。</para>
			/// </summary>
			[GPValue("WEEKS")]
			[Description("周")]
			Weeks,

			/// <summary>
			/// <para>天—测量单位为天。</para>
			/// </summary>
			[GPValue("DAYS")]
			[Description("天")]
			Days,

			/// <summary>
			/// <para>小时—测量单位为小时。</para>
			/// </summary>
			[GPValue("HOURS")]
			[Description("小时")]
			Hours,

			/// <summary>
			/// <para>分—测量单位为分钟。</para>
			/// </summary>
			[GPValue("MINUTES")]
			[Description("分")]
			Minutes,

			/// <summary>
			/// <para>秒—测量单位为秒。 这是默认设置。</para>
			/// </summary>
			[GPValue("SECONDS")]
			[Description("秒")]
			Seconds,

			/// <summary>
			/// <para>毫秒—测量单位为毫秒。</para>
			/// </summary>
			[GPValue("MILLISECONDS")]
			[Description("毫秒")]
			Milliseconds,

		}

		/// <summary>
		/// <para>Speed Unit</para>
		/// </summary>
		public enum SpeedUnitEnum 
		{
			/// <summary>
			/// <para>米/秒—测量单位为米/秒。 这是默认设置。</para>
			/// </summary>
			[GPValue("METERS_PER_SECOND")]
			[Description("米/秒")]
			Meters_Per_Second,

			/// <summary>
			/// <para>英里/小时—测量单位为英里/小时。</para>
			/// </summary>
			[GPValue("MILES_PER_HOUR")]
			[Description("英里/小时")]
			Miles_Per_Hour,

			/// <summary>
			/// <para>千米/小时—测量单位为千米/小时。</para>
			/// </summary>
			[GPValue("KILOMETERS_PER_HOUR")]
			[Description("千米/小时")]
			Kilometers_Per_Hour,

			/// <summary>
			/// <para>英尺/秒—测量单位为英尺/秒。</para>
			/// </summary>
			[GPValue("FEET_PER_SECOND")]
			[Description("英尺/秒")]
			Feet_Per_Second,

			/// <summary>
			/// <para>海里/小时—测量单位为海里/小时。</para>
			/// </summary>
			[GPValue("NAUTICAL_MILES_PER_HOUR")]
			[Description("海里/小时")]
			Nautical_Miles_Per_Hour,

		}

		/// <summary>
		/// <para>Acceleration Unit</para>
		/// </summary>
		public enum AccelerationUnitEnum 
		{
			/// <summary>
			/// <para>米/平方秒—测量单位为米/平方秒。 这是默认设置。</para>
			/// </summary>
			[GPValue("METERS_PER_SECOND_SQUARED")]
			[Description("米/平方秒")]
			Meters_Per_Second_Squared,

			/// <summary>
			/// <para>英尺/平方秒—测量单位为英尺/平方秒。</para>
			/// </summary>
			[GPValue("FEET_PER_SECOND_SQUARED")]
			[Description("英尺/平方秒")]
			Feet_Per_Second_Squared,

		}

		/// <summary>
		/// <para>Elevation Unit</para>
		/// </summary>
		public enum ElevationUnitEnum 
		{
			/// <summary>
			/// <para>千米—测量单位为千米。</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("千米")]
			Kilometers,

			/// <summary>
			/// <para>米—测量单位为米。 这是默认设置。</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("米")]
			Meters,

			/// <summary>
			/// <para>英里—测量单位为英里。</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("英里")]
			Miles,

			/// <summary>
			/// <para>海里—测量单位为海里。</para>
			/// </summary>
			[GPValue("NAUTICAL_MILES")]
			[Description("海里")]
			Nautical_Miles,

			/// <summary>
			/// <para>码—测量单位为码。</para>
			/// </summary>
			[GPValue("YARDS")]
			[Description("码")]
			Yards,

			/// <summary>
			/// <para>英尺—测量单位为英尺。</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("英尺")]
			Feet,

		}

		/// <summary>
		/// <para>Data Store</para>
		/// </summary>
		public enum DataStoreEnum 
		{
			/// <summary>
			/// <para>时空大数据存储—输出将存储在时空大数据存储中。这是默认设置。</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("时空大数据存储")]
			Spatiotemporal_big_data_store,

			/// <summary>
			/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("关系数据存储")]
			Relational_data_store,

		}

#endregion
	}
}
