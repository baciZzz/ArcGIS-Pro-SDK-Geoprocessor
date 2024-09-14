using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AnalysisTools
{
	/// <summary>
	/// <para>Summarize Nearby</para>
	/// <para>邻近汇总</para>
	/// <para>无论时区如何，所有点的开始时间均应同步。距离的测量方式可采用直线距离、行驶时间距离（例如，10 分钟内）或行驶距离（5 公里内）。行驶时间和行驶距离的测量要求您先使用网络分析权限登录到 ArcGIS Online 组织帐户，然后消耗配额。</para>
	/// </summary>
	public class SummarizeNearby : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>将进行缓冲的点、线或面要素，以及用于汇总输入汇总要素的缓冲区。</para>
		/// </param>
		/// <param name="InSumFeatures">
		/// <para>Input Summary Features</para>
		/// <para>将要汇总的点、线或面要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>输出面要素类，包括缓冲的输入要素、输入要素的属性和关于各缓冲区中数量点、线的长度及面的面积等新属性以及有关这些要素的统计数据。</para>
		/// </param>
		/// <param name="DistanceType">
		/// <para>Distance Measurement</para>
		/// <para>定义在输入要素周围生成缓冲区域中使用的距离测量的方式。行驶距离和行驶时间均使用道路网络，并遵守交通规则，例如单行道。行驶时间遵守当前发布的限速要求。</para>
		/// <para>要使用行驶时间和行驶距离测量选项，您必须先使用网络分析权限登录 ArcGIS Online 组织帐户。每次工具成功运行，都会根据使用的服务和从服务返回的结果从您的订阅中扣除服务配额。ArcGIS Online 服务配额页面会提供有关服务配额的详细信息。</para>
		/// <para>所有距离类型均使用 ArcGIS Online 路径和网络服务（直线距离除外）。</para>
		/// <para>行驶距离—车辆或其他类似小型汽车（例如小卡车）的行驶距离。行驶遵循车辆专用的所有规则。</para>
		/// <para>行驶时间—特定时间内车辆或其他类似小型汽车（例如小卡车）的行驶距离。基于交通状况的动态行驶速度可用于指定时间的可用位置。行驶遵循车辆专用的所有规则。</para>
		/// <para>直线—欧氏距离或直线距离。</para>
		/// <para>货运距离—沿指定的卡车路径行驶的距离。行驶遵循汽车的所有规则和货运的特定规则。</para>
		/// <para>货运时间—指定时间内沿指定卡车路径行驶的距离。基于交通状况的动态行驶速度可用于指定时间的可用位置。行驶遵循汽车的所有规则和货运的特定规则。</para>
		/// <para>步行距离—沿着可允许行人通过的线路和道路行驶的距离。</para>
		/// <para>步行时间—指定时间内沿着可允许行人通过的线路和道路所行驶的距离。</para>
		/// <para><see cref="DistanceTypeEnum"/></para>
		/// </param>
		/// <param name="Distances">
		/// <para>Distances</para>
		/// <para>距离值可定义搜索距离（例如直线、行驶、货运或步行距离）或行驶时间（行驶、货运或步行时间）。汇总处于您所输入距离内（包含该距离）的要素。</para>
		/// <para>可以指定多个值。将为每个距离在每个输入要素周围生成一个区域。</para>
		/// </param>
		/// <param name="DistanceUnits">
		/// <para>Distance Units</para>
		/// <para>距离值单位。</para>
		/// <para>英里—英里</para>
		/// <para>千米—千米</para>
		/// <para>英尺—英尺</para>
		/// <para>码—码</para>
		/// <para>米—米</para>
		/// <para>小时—小时</para>
		/// <para>分—分</para>
		/// <para>秒—秒</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </param>
		public SummarizeNearby(object InFeatures, object InSumFeatures, object OutFeatureClass, object DistanceType, object Distances, object DistanceUnits)
		{
			this.InFeatures = InFeatures;
			this.InSumFeatures = InSumFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.DistanceType = DistanceType;
			this.Distances = Distances;
			this.DistanceUnits = DistanceUnits;
		}

		/// <summary>
		/// <para>Tool Display Name : 邻近汇总</para>
		/// </summary>
		public override string DisplayName() => "邻近汇总";

		/// <summary>
		/// <para>Tool Name : SummarizeNearby</para>
		/// </summary>
		public override string ToolName() => "SummarizeNearby";

		/// <summary>
		/// <para>Tool Excute Name : analysis.SummarizeNearby</para>
		/// </summary>
		public override string ExcuteName() => "analysis.SummarizeNearby";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise() => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "outputCoordinateSystem", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, InSumFeatures, OutFeatureClass, DistanceType, Distances, DistanceUnits, TimeOfDay, TimeZone, KeepAllPolygons, SumFields, SumShape, ShapeUnit, GroupField, AddMinMaj, AddGroupPercent, OutputGroupedTable };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>将进行缓冲的点、线或面要素，以及用于汇总输入汇总要素的缓冲区。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polygon", "Polyline")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Input Summary Features</para>
		/// <para>将要汇总的点、线或面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polygon", "Polyline")]
		[FeatureType("Simple")]
		public object InSumFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>输出面要素类，包括缓冲的输入要素、输入要素的属性和关于各缓冲区中数量点、线的长度及面的面积等新属性以及有关这些要素的统计数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Distance Measurement</para>
		/// <para>定义在输入要素周围生成缓冲区域中使用的距离测量的方式。行驶距离和行驶时间均使用道路网络，并遵守交通规则，例如单行道。行驶时间遵守当前发布的限速要求。</para>
		/// <para>要使用行驶时间和行驶距离测量选项，您必须先使用网络分析权限登录 ArcGIS Online 组织帐户。每次工具成功运行，都会根据使用的服务和从服务返回的结果从您的订阅中扣除服务配额。ArcGIS Online 服务配额页面会提供有关服务配额的详细信息。</para>
		/// <para>所有距离类型均使用 ArcGIS Online 路径和网络服务（直线距离除外）。</para>
		/// <para>行驶距离—车辆或其他类似小型汽车（例如小卡车）的行驶距离。行驶遵循车辆专用的所有规则。</para>
		/// <para>行驶时间—特定时间内车辆或其他类似小型汽车（例如小卡车）的行驶距离。基于交通状况的动态行驶速度可用于指定时间的可用位置。行驶遵循车辆专用的所有规则。</para>
		/// <para>直线—欧氏距离或直线距离。</para>
		/// <para>货运距离—沿指定的卡车路径行驶的距离。行驶遵循汽车的所有规则和货运的特定规则。</para>
		/// <para>货运时间—指定时间内沿指定卡车路径行驶的距离。基于交通状况的动态行驶速度可用于指定时间的可用位置。行驶遵循汽车的所有规则和货运的特定规则。</para>
		/// <para>步行距离—沿着可允许行人通过的线路和道路行驶的距离。</para>
		/// <para>步行时间—指定时间内沿着可允许行人通过的线路和道路所行驶的距离。</para>
		/// <para><see cref="DistanceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceType { get; set; }

		/// <summary>
		/// <para>Distances</para>
		/// <para>距离值可定义搜索距离（例如直线、行驶、货运或步行距离）或行驶时间（行驶、货运或步行时间）。汇总处于您所输入距离内（包含该距离）的要素。</para>
		/// <para>可以指定多个值。将为每个距离在每个输入要素周围生成一个区域。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Distances { get; set; }

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>距离值单位。</para>
		/// <para>英里—英里</para>
		/// <para>千米—千米</para>
		/// <para>英尺—英尺</para>
		/// <para>码—码</para>
		/// <para>米—米</para>
		/// <para>小时—小时</para>
		/// <para>分—分</para>
		/// <para>秒—秒</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceUnits { get; set; }

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>指定行驶时间是否应该考虑交通状况。交通状况，尤其是城市化地区的交通状况，可以显著影响指定行驶时间内涉及的区域。如果未指定日期或时间，在某一特定行驶时间内行驶的距离将不受交通影响。</para>
		/// <para>根据为此参数指定的日期和时间，交通状况可能是实时的，也可能是典型的（历史状况）。Esri 会保存 12 小时的实时交通数据并参考 12 小时以后的预测数据。如果您指定的时间和日期为 24 小时时间窗之内的时间和日期，则使用实时交通。如果超出了时间窗范围，则使用典型或历史交通。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object TimeOfDay { get; set; }

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>指定时间的时区。可以将时区指定为本地时间或协调世界时间 (UTC)。</para>
		/// <para>Geolocal—时间采用本地时区或输入要素所在的时区。该选项会导致各时区中分析的起始时间有所变动。这是默认设置。例如，将 geolocal 时间设置为上午 9:00 会致使东部时区内各点的行驶时间在 东部时间上午 9:00 开始， 同样中部时区内各点在中部时间上午 9:00 开始。（开始时间与 UTC 时间或实际时间偏差一小时。）</para>
		/// <para>UTC—时间引用协调世界时间 (UTC)。无论时区差异，所有点的开始时间均应同步。例如，将 UTC 时间设置为上午 9:00 会致使东部时区内各点的行驶时间在 东部时间上午 4:00 开始， 同样中部时区内各点在中部时间上午 3:00 开始。（开始时间同步。）</para>
		/// <para><see cref="TimeZoneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TimeZone { get; set; } = "GEOLOCAL";

		/// <summary>
		/// <para>Keep polygons with no points</para>
		/// <para>确定是输入要素的所有缓冲区还是仅那些相交或包括至少一个输入汇总要素的缓冲区将会复制到输出要素类。</para>
		/// <para>选中 - 所有缓冲区都将复制到输出要素类。这是默认设置。</para>
		/// <para>未选中 - 只有相交或包括至少一个输入汇总要素的缓冲区将会复制到输出要素类。</para>
		/// <para><see cref="KeepAllPolygonsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object KeepAllPolygons { get; set; } = "true";

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>输入汇总要素中的属性字段名称及您想要为各输入要素缓冲区内全部点计算属性字段的统计汇总类型的列表。</para>
		/// <para>汇总字段必须为数值型。不支持文本和其他属性字段类型。</para>
		/// <para>统计类型如下：</para>
		/// <para>Sum - 添加每个缓冲区中所有点的总值。</para>
		/// <para>Mean - 计算每个缓冲区中所有点的平均值。</para>
		/// <para>Min - 查找每个缓冲区中所有点的最小值。</para>
		/// <para>Max - 查找每个缓冲区中所有点的最大值。</para>
		/// <para>Stddev - 查找每个缓冲区中所有点的标准差。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object SumFields { get; set; }

		/// <summary>
		/// <para>Add shape summary  attributes</para>
		/// <para>确定是否输出要素类将包括各输入要素缓冲区中汇总得出的点数量、线长度及面要素面积等属性。</para>
		/// <para>选中 - 将形状汇总属性添加到输出要素类。这是默认设置。</para>
		/// <para>未选中 - 不将形状汇总属性添加到输出要素类。</para>
		/// <para><see cref="SumShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SumShape { get; set; } = "true";

		/// <summary>
		/// <para>Shape Unit</para>
		/// <para>用以计算形状汇总属性的单位。如果输入汇总要素为点，则不使用形状单位，因为仅添加各输入要素缓冲区内点的计数。</para>
		/// <para>如果输入汇总要素为线，则指定一个线性单位。如果输入汇总要素为面，则指定一个面积单位。</para>
		/// <para>米—米</para>
		/// <para>千米—千米</para>
		/// <para>英尺—英尺</para>
		/// <para>码—码</para>
		/// <para>英里—英里</para>
		/// <para>英亩—英亩</para>
		/// <para>公顷—公顷</para>
		/// <para>平方米—平方米</para>
		/// <para>平方千米—平方千米</para>
		/// <para>平方英尺—平方英尺</para>
		/// <para>平方码—平方码</para>
		/// <para>平方英里—平方英里</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ShapeUnit { get; set; }

		/// <summary>
		/// <para>Group Field</para>
		/// <para>用于分组的输入汇总要素中的属性字段。具有相同组字段值的要素将合并与具有相同组字段值的其他要素汇总。</para>
		/// <para>如果选择一个组字段，则需要创建一个附加输出分组表格并必须指定其位置。使用组字段时需要使用该输出分组表格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object GroupField { get; set; }

		/// <summary>
		/// <para>Add minority and majority attributes</para>
		/// <para>仅当选定组字段时，才启用此选项。通过该选项，您可以确定各输入要素缓冲区中哪个组字段值为少数（所占比例最小），哪个为众数（所占比例最大）。</para>
		/// <para>未选中 - 不向输出添加少数和众数字段。这是默认设置。</para>
		/// <para>选中 - 向输出添加少数和众数字段。</para>
		/// <para><see cref="AddMinMajEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AddMinMaj { get; set; } = "false";

		/// <summary>
		/// <para>Add group percentages</para>
		/// <para>仅当选定组字段时，才启用此选项。您可以确定各组内各个属性值的百分比。</para>
		/// <para>未选中 - 不向输出添加百分比属性字段。这是默认设置。</para>
		/// <para>选中 - 向输出添加百分比属性字段。</para>
		/// <para><see cref="AddGroupPercentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AddGroupPercent { get; set; } = "false";

		/// <summary>
		/// <para>Output Grouped Table</para>
		/// <para>如果指定了组字段，则需要输出分组表。</para>
		/// <para>各个输入要素缓冲区各汇总要素组的汇总字段的输出表。该表将具有以下属性字段：</para>
		/// <para>Join_ID - 与添加到输出要素类的 ID 字段对应的 ID。</para>
		/// <para>组字段。</para>
		/// <para>点计数或线长度等形状汇总字段。</para>
		/// <para>每个汇总字段对应一个字段。</para>
		/// <para>百分比字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object OutputGroupedTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SummarizeNearby SetEnviroment(object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object outputZFlag = null, object outputZValue = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Measurement</para>
		/// </summary>
		public enum DistanceTypeEnum 
		{
			/// <summary>
			/// <para>行驶距离—车辆或其他类似小型汽车（例如小卡车）的行驶距离。行驶遵循车辆专用的所有规则。</para>
			/// </summary>
			[GPValue("DRIVING_DISTANCE")]
			[Description("行驶距离")]
			Driving_distance,

			/// <summary>
			/// <para>行驶时间—特定时间内车辆或其他类似小型汽车（例如小卡车）的行驶距离。基于交通状况的动态行驶速度可用于指定时间的可用位置。行驶遵循车辆专用的所有规则。</para>
			/// </summary>
			[GPValue("DRIVING_TIME")]
			[Description("行驶时间")]
			Driving_time,

			/// <summary>
			/// <para>直线—欧氏距离或直线距离。</para>
			/// </summary>
			[GPValue("STRAIGHT_LINE")]
			[Description("直线")]
			Straight_line,

			/// <summary>
			/// <para>货运距离—沿指定的卡车路径行驶的距离。行驶遵循汽车的所有规则和货运的特定规则。</para>
			/// </summary>
			[GPValue("TRUCKING_DISTANCE")]
			[Description("货运距离")]
			Trucking_distance,

			/// <summary>
			/// <para>货运时间—指定时间内沿指定卡车路径行驶的距离。基于交通状况的动态行驶速度可用于指定时间的可用位置。行驶遵循汽车的所有规则和货运的特定规则。</para>
			/// </summary>
			[GPValue("TRUCKING_TIME")]
			[Description("货运时间")]
			Trucking_time,

			/// <summary>
			/// <para>步行距离—沿着可允许行人通过的线路和道路行驶的距离。</para>
			/// </summary>
			[GPValue("WALKING_DISTANCE")]
			[Description("步行距离")]
			Walking_distance,

			/// <summary>
			/// <para>步行时间—指定时间内沿着可允许行人通过的线路和道路所行驶的距离。</para>
			/// </summary>
			[GPValue("WALKING_TIME")]
			[Description("步行时间")]
			Walking_time,

		}

		/// <summary>
		/// <para>Distance Units</para>
		/// </summary>
		public enum DistanceUnitsEnum 
		{
			/// <summary>
			/// <para>米—米</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("米")]
			Meters,

			/// <summary>
			/// <para>千米—千米</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("千米")]
			Kilometers,

			/// <summary>
			/// <para>英尺—英尺</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("英尺")]
			Feet,

			/// <summary>
			/// <para>码—码</para>
			/// </summary>
			[GPValue("YARDS")]
			[Description("码")]
			Yards,

			/// <summary>
			/// <para>英里—英里</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("英里")]
			Miles,

			/// <summary>
			/// <para>秒—秒</para>
			/// </summary>
			[GPValue("SECONDS")]
			[Description("秒")]
			Seconds,

			/// <summary>
			/// <para>分—分</para>
			/// </summary>
			[GPValue("MINUTES")]
			[Description("分")]
			Minutes,

			/// <summary>
			/// <para>小时—小时</para>
			/// </summary>
			[GPValue("HOURS")]
			[Description("小时")]
			Hours,

		}

		/// <summary>
		/// <para>Time Zone</para>
		/// </summary>
		public enum TimeZoneEnum 
		{
			/// <summary>
			/// <para>UTC—时间引用协调世界时间 (UTC)。无论时区差异，所有点的开始时间均应同步。例如，将 UTC 时间设置为上午 9:00 会致使东部时区内各点的行驶时间在 东部时间上午 4:00 开始， 同样中部时区内各点在中部时间上午 3:00 开始。（开始时间同步。）</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

			/// <summary>
			/// <para>Geolocal—时间采用本地时区或输入要素所在的时区。该选项会导致各时区中分析的起始时间有所变动。这是默认设置。例如，将 geolocal 时间设置为上午 9:00 会致使东部时区内各点的行驶时间在 东部时间上午 9:00 开始， 同样中部时区内各点在中部时间上午 9:00 开始。（开始时间与 UTC 时间或实际时间偏差一小时。）</para>
			/// </summary>
			[GPValue("GEOLOCAL")]
			[Description("Geolocal")]
			Geolocal,

		}

		/// <summary>
		/// <para>Keep polygons with no points</para>
		/// </summary>
		public enum KeepAllPolygonsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_ALL")]
			KEEP_ALL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ONLY_INTERSECTING")]
			ONLY_INTERSECTING,

		}

		/// <summary>
		/// <para>Add shape summary  attributes</para>
		/// </summary>
		public enum SumShapeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_SHAPE_SUM")]
			ADD_SHAPE_SUM,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SHAPE_SUM")]
			NO_SHAPE_SUM,

		}

		/// <summary>
		/// <para>Add minority and majority attributes</para>
		/// </summary>
		public enum AddMinMajEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_MIN_MAJ")]
			ADD_MIN_MAJ,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MIN_MAJ")]
			NO_MIN_MAJ,

		}

		/// <summary>
		/// <para>Add group percentages</para>
		/// </summary>
		public enum AddGroupPercentEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_PERCENT")]
			ADD_PERCENT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_PERCENT")]
			NO_PERCENT,

		}

#endregion
	}
}
