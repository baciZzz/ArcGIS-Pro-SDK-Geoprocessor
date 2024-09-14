using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.StandardFeatureAnalysisTools
{
	/// <summary>
	/// <para>Summarize Nearby</para>
	/// <para>邻近汇总</para>
	/// <para>在输入图层中查找处于指定要素距离内的要素。</para>
	/// </summary>
	public class SummarizeNearby : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Sumnearbylayer">
		/// <para>Input Nearby Layer</para>
		/// <para>用作输入汇总图层中到要素的距离的测量起点的点、线或面要素。</para>
		/// </param>
		/// <param name="Summarylayer">
		/// <para>Input Summary Features</para>
		/// <para>点、线或面要素。将汇总此图层中与输入邻近要素图层中的要素相距指定距离的要素。</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>要在门户中创建的输出图层的名称。</para>
		/// </param>
		/// <param name="Neartype">
		/// <para>Distance Measurement</para>
		/// <para>定义要使用的距离测量方式：按直线距离进行测量，或利用多种交通方式（称为出行模式）通过测量沿街道网络的行驶时间或行驶距离来进行测量。</para>
		/// <para>直线—使用直线欧式距离测量法。这是默认设置。</para>
		/// <para>行驶距离—使用汽车行驶距离。</para>
		/// <para>行驶时间—使用在指定汽车行驶时间内行驶的距离。</para>
		/// <para>货运距离—使用卡车行驶距离。</para>
		/// <para>货运时间—使用在指定卡车行驶时间内行驶的距离。</para>
		/// <para>步行距离—使用沿街道步行的距离。</para>
		/// <para>步行时间—使用指定步行时间内行驶的距离。</para>
		/// <para><see cref="NeartypeEnum"/></para>
		/// </param>
		/// <param name="Distances">
		/// <para>Distances</para>
		/// <para>定义搜索距离（针对直线和基于距离的出行模式）或时间（针对基于时间的出行模式）的双精度值列表。可以输入一个距离值或多个距离值。汇总处于您所输入距离内（包含该距离）的要素。距离值的 units 由 units 参数提供。</para>
		/// </param>
		/// <param name="Units">
		/// <para>Distance Units</para>
		/// <para>如果邻近类型为基于直线或基于距离的出行模式，则此单位应为与距离中指定的距离值一同使用的线性单位。有效选项包括米、千米、英尺、码和英里。</para>
		/// <para>如果邻近要素类型为基于时间的出行模式，则值将包括秒、分钟和小时。</para>
		/// <para>英里—英里</para>
		/// <para>英尺—英尺</para>
		/// <para>千米—千米</para>
		/// <para>米—米</para>
		/// <para>码—码</para>
		/// <para>秒—秒</para>
		/// <para>分—分</para>
		/// <para>小时—小时</para>
		/// <para><see cref="UnitsEnum"/></para>
		/// </param>
		public SummarizeNearby(object Sumnearbylayer, object Summarylayer, object Outputname, object Neartype, object Distances, object Units)
		{
			this.Sumnearbylayer = Sumnearbylayer;
			this.Summarylayer = Summarylayer;
			this.Outputname = Outputname;
			this.Neartype = Neartype;
			this.Distances = Distances;
			this.Units = Units;
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
		/// <para>Tool Excute Name : sfa.SummarizeNearby</para>
		/// </summary>
		public override string ExcuteName() => "sfa.SummarizeNearby";

		/// <summary>
		/// <para>Toolbox Display Name : Standard Feature Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Standard Feature Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : sfa</para>
		/// </summary>
		public override string ToolboxAlise() => "sfa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Sumnearbylayer, Summarylayer, Outputname, Neartype, Distances, Units, Timeofday, Timezonefortimeofday, Returnboundaries, Sumshape, Shapeunits, Summaryfields, Groupbyfield, Minoritymajority, Percentshape, Resultlayer, Groupbysummary };

		/// <summary>
		/// <para>Input Nearby Layer</para>
		/// <para>用作输入汇总图层中到要素的距离的测量起点的点、线或面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polyline", "Polygon")]
		[FeatureType("Simple")]
		public object Sumnearbylayer { get; set; }

		/// <summary>
		/// <para>Input Summary Features</para>
		/// <para>点、线或面要素。将汇总此图层中与输入邻近要素图层中的要素相距指定距离的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polyline", "Polygon")]
		[FeatureType("Simple")]
		public object Summarylayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>要在门户中创建的输出图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Distance Measurement</para>
		/// <para>定义要使用的距离测量方式：按直线距离进行测量，或利用多种交通方式（称为出行模式）通过测量沿街道网络的行驶时间或行驶距离来进行测量。</para>
		/// <para>直线—使用直线欧式距离测量法。这是默认设置。</para>
		/// <para>行驶距离—使用汽车行驶距离。</para>
		/// <para>行驶时间—使用在指定汽车行驶时间内行驶的距离。</para>
		/// <para>货运距离—使用卡车行驶距离。</para>
		/// <para>货运时间—使用在指定卡车行驶时间内行驶的距离。</para>
		/// <para>步行距离—使用沿街道步行的距离。</para>
		/// <para>步行时间—使用指定步行时间内行驶的距离。</para>
		/// <para><see cref="NeartypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Neartype { get; set; } = "STRAIGHTLINE";

		/// <summary>
		/// <para>Distances</para>
		/// <para>定义搜索距离（针对直线和基于距离的出行模式）或时间（针对基于时间的出行模式）的双精度值列表。可以输入一个距离值或多个距离值。汇总处于您所输入距离内（包含该距离）的要素。距离值的 units 由 units 参数提供。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Distances { get; set; }

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>如果邻近类型为基于直线或基于距离的出行模式，则此单位应为与距离中指定的距离值一同使用的线性单位。有效选项包括米、千米、英尺、码和英里。</para>
		/// <para>如果邻近要素类型为基于时间的出行模式，则值将包括秒、分钟和小时。</para>
		/// <para>英里—英里</para>
		/// <para>英尺—英尺</para>
		/// <para>千米—千米</para>
		/// <para>米—米</para>
		/// <para>码—码</para>
		/// <para>秒—秒</para>
		/// <para>分—分</para>
		/// <para>小时—小时</para>
		/// <para><see cref="UnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Units { get; set; }

		/// <summary>
		/// <para>Time Of Day</para>
		/// <para>指定行驶时间是否应该考虑交通状况。要在分析中使用流量，必须将邻近要素类型设置为基于出行时间的模式。时间值表示出行开始或离开输入点的时间。</para>
		/// <para>支持两种类型的流量：典型流量和实时流量。典型流量将参考行驶速度，该速度由一周内每 5 分钟执行一次测速所得的历史平均速度组成。实时流量从流量源（用于处理电话调查记录、传感器和其他数据源）检索速度以记录实际行驶速度并预测近期速度。</para>
		/// <para>要确保任务在适用的位置使用典型流量，请选择该周的某个时间和某天，并将这天转换为 1990 年的以下某个日期：尽管用来表示该周各天的日期来自 1990 年，但典型流量将根据近期的交通趋势（通常在过去的几个月中）进行计算。</para>
		/// <para>星期一 - 1/1/1990</para>
		/// <para>星期二 - 1/2/1990</para>
		/// <para>星期三 - 1/3/1990</para>
		/// <para>星期四 - 1/4/1990</para>
		/// <para>星期五 - 1/5/1990</para>
		/// <para>星期六 - 1/6/1990</para>
		/// <para>星期日 - 1/7/1990</para>
		/// <para>要在适用的情况下使用实时流量，请选择当前时间 12 小时范围内的日期和时间。Esri 会保存 12 小时的实时交通数据并参考 12 小时以后的预测数据。如果为此参数指定的时间和日期在 24 小时时间窗之外，或分析中的行驶时间继续超过预测数据窗，则任务将回退到典型流量速度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object Timeofday { get; set; }

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>指定所选时间的一个或多个时区。有两个选项可供选择：GeoLocal（默认）和 UTC。</para>
		/// <para>Geolocal—时间值采用输入点所在的一个或多个时区。该选项会导致各时区中分析的起始时间有所变动。这是默认设置。</para>
		/// <para>协调世界时间 (UTC)—时间值采用协调世界时间 (UTC)。无论时区差异，所有点的开始时间均应同步。</para>
		/// <para><see cref="TimezonefortimeofdayEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Timezonefortimeofday { get; set; } = "GEOLOCAL";

		/// <summary>
		/// <para>Return boundaries</para>
		/// <para>指定是返回输入几何还是返回直线或出行模式缓冲区几何。</para>
		/// <para>选中 - 输出图层将包含由指定邻近要素类型定义的区域。例如，如果使用 5 英里的直线距离，则输出中将包含输入邻近要素图层要素周围以 5 英里为半径的区域。这是默认设置。</para>
		/// <para>未选中 - 输出图层将包含与输入邻近要素图层相同的要素。</para>
		/// <para><see cref="ReturnboundariesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Returnboundaries { get; set; } = "true";

		/// <summary>
		/// <para>Add shape summary attributes</para>
		/// <para>根据输入汇总要素的形状计算统计数据，例如输入汇总图层中各个面内汇总要素线的长度或面的面积。</para>
		/// <para>选中 - 计算形状汇总属性。这是默认设置。</para>
		/// <para>未选中 - 不计算形状汇总属性。</para>
		/// <para><see cref="SumshapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Sumshape { get; set; } = "true";

		/// <summary>
		/// <para>Shape Unit</para>
		/// <para>如果要汇总邻近要素的形状，请指定形状汇总的单位。</para>
		/// <para>如果输入汇总要素为面，则有效选项为英亩、公顷、平方米、平方千米、平方英尺、平方码和平方英里。</para>
		/// <para>如果输入汇总要素为线，则有效选项为米、千米、英尺、码和英里。</para>
		/// <para>英里—英里</para>
		/// <para>英尺—英尺</para>
		/// <para>千米—千米</para>
		/// <para>米—米</para>
		/// <para>码—码</para>
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
		public object Shapeunits { get; set; }

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>字段名称及您想要为各面内全部点计算的统计汇总类型的列表。始终返回每个面内的点计数。支持的统计数据类型如下：</para>
		/// <para>Sum - 总值。</para>
		/// <para>Minimum - 最小值。</para>
		/// <para>Max - 最大值。</para>
		/// <para>Mean - 平均值。</para>
		/// <para>Standard deviation - 标准差。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object Summaryfields { get; set; }

		/// <summary>
		/// <para>Group By Field</para>
		/// <para>这是输入汇总要素的一个字段，可用于分别计算每个唯一属性值的统计数据。例如，假设输入汇总要素包含存储危险材料的企业的点位置，且其中一个字段为 HazardClass，字段中含有用于描述所存储危险材料类型的代码。要根据每个 HazardClass 唯一值计算汇总，请将其用作分组条件字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object Groupbyfield { get; set; }

		/// <summary>
		/// <para>Add minority and majority attributes</para>
		/// <para>仅当使用分组条件字段时适用。如果选中，将对各个边界内每个组字段的少数（所占比例最小）或众数（所占比例最大）属性值进行计算。前缀为众数_和少数_的两个新字段将添加至输出图层。</para>
		/// <para>未选中 - 不添加少数和众数字段。这是默认设置。</para>
		/// <para>选中 - 添加少数和众数字段。</para>
		/// <para><see cref="MinoritymajorityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Minoritymajority { get; set; } = "false";

		/// <summary>
		/// <para>Add group percentages</para>
		/// <para>仅当使用分组条件字段时适用。如果选中，则系统将针对每个输入邻近要素计算各唯一组值的百分比。</para>
		/// <para>未选中 - 不添加百分比字段。这是默认设置。</para>
		/// <para>选中 - 添加百分比字段。</para>
		/// <para><see cref="PercentshapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Percentshape { get; set; } = "false";

		/// <summary>
		/// <para>Output Feature Service</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Resultlayer { get; set; }

		/// <summary>
		/// <para>Output Group Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object Groupbysummary { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SummarizeNearby SetEnviroment(object extent = null)
		{
			base.SetEnv(extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Measurement</para>
		/// </summary>
		public enum NeartypeEnum 
		{
			/// <summary>
			/// <para>行驶距离—使用汽车行驶距离。</para>
			/// </summary>
			[GPValue("DRIVINGDISTANCE")]
			[Description("行驶距离")]
			Driving_distance,

			/// <summary>
			/// <para>行驶时间—使用在指定汽车行驶时间内行驶的距离。</para>
			/// </summary>
			[GPValue("DRIVINGTIME")]
			[Description("行驶时间")]
			Driving_time,

			/// <summary>
			/// <para>直线—使用直线欧式距离测量法。这是默认设置。</para>
			/// </summary>
			[GPValue("STRAIGHTLINE")]
			[Description("直线")]
			STRAIGHTLINE,

			/// <summary>
			/// <para>货运距离—使用卡车行驶距离。</para>
			/// </summary>
			[GPValue("TRUCKINGDISTANCE")]
			[Description("货运距离")]
			Trucking_distance,

			/// <summary>
			/// <para>货运时间—使用在指定卡车行驶时间内行驶的距离。</para>
			/// </summary>
			[GPValue("TRUCKINGTIME")]
			[Description("货运时间")]
			Trucking_time,

			/// <summary>
			/// <para>步行距离—使用沿街道步行的距离。</para>
			/// </summary>
			[GPValue("WALKINGDISTANCE")]
			[Description("步行距离")]
			Walking_distance,

			/// <summary>
			/// <para>步行时间—使用指定步行时间内行驶的距离。</para>
			/// </summary>
			[GPValue("WALKINGTIME")]
			[Description("步行时间")]
			Walking_time,

		}

		/// <summary>
		/// <para>Distance Units</para>
		/// </summary>
		public enum UnitsEnum 
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
		public enum TimezonefortimeofdayEnum 
		{
			/// <summary>
			/// <para>协调世界时间 (UTC)—时间值采用协调世界时间 (UTC)。无论时区差异，所有点的开始时间均应同步。</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("协调世界时间 (UTC)")]
			UTC,

			/// <summary>
			/// <para>Geolocal—时间值采用输入点所在的一个或多个时区。该选项会导致各时区中分析的起始时间有所变动。这是默认设置。</para>
			/// </summary>
			[GPValue("GEOLOCAL")]
			[Description("Geolocal")]
			Geolocal,

		}

		/// <summary>
		/// <para>Return boundaries</para>
		/// </summary>
		public enum ReturnboundariesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RETURN_BOUNDARIES")]
			RETURN_BOUNDARIES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("RETURN_INPUT")]
			RETURN_INPUT,

		}

		/// <summary>
		/// <para>Add shape summary attributes</para>
		/// </summary>
		public enum SumshapeEnum 
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
		public enum MinoritymajorityEnum 
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
		public enum PercentshapeEnum 
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
