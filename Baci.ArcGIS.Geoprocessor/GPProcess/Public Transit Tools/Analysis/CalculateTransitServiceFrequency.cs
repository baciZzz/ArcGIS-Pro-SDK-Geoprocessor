using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.PublicTransitTools
{
	/// <summary>
	/// <para>Calculate Transit Service Frequency</para>
	/// <para>计算交通服务频率</para>
	/// <para>计算在一个或多个指定时间窗内，公共交通停靠点、公共交通线路沿线、感兴趣点或区域的可用计划公共交通服务的频率。</para>
	/// </summary>
	public class CalculateTransitServiceFrequency : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTransitFeatureDataset">
		/// <para>Input Transit Feature Dataset</para>
		/// <para>包含来自 Network Analyst 公共交通数据模型的 Stops 和 LineVariantElements 要素类的要素数据集。 要素数据集的父地理数据库必须包含公共交通数据模型的 LineVariants、Schedules、ScheduleElements 和 Runs 表以及 Calendars 表、CalendarExceptions 表或两者皆有。</para>
		/// <para>可以使用 GTFS 转公共交通数据模型工具从通用交通数据规范 (GTFS) 公共交通数据创建具有关联要素类和表的有效要素数据集。</para>
		/// </param>
		/// <param name="AnalysisType">
		/// <para>Analysis Type</para>
		/// <para>指定工具将为其计算公共交通服务频率的位置类型。</para>
		/// <para>交通停靠点—将计算公共交通停靠点的公共交通服务频率。 输出将为要素类，其中包含来自输入公共交通数据模型 Stops 要素类的公共交通停靠点的副本。</para>
		/// <para>交通线路—将计算沿公共交通线路的公共交通服务频率。 输出将为要素类，其中包含来自输入公共交通数据模型 LineVariantElements 要素类的公共交通线路的副本。</para>
		/// <para>感兴趣点—将计算指定感兴趣点的公共交通服务频率。 输出将为输入感兴趣点的副本。</para>
		/// <para>面—将计算所有公共交通停靠点范围内所有区域的公共交通服务频率。 输出将为面要素类，表示公共交通系统所服务的区域。</para>
		/// <para><see cref="AnalysisTypeEnum"/></para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>输出要素类。</para>
		/// <para>shapefile 不是有效值。</para>
		/// </param>
		/// <param name="TimeWindows">
		/// <para>Time Windows</para>
		/// <para>将计算公共交通服务频率的时间段。</para>
		/// <para>可以指定多个时间窗。 输出要素类将包含一组字段，表示每个时间窗的交通频率统计数据。 这些字段将以输出字段前缀列中指定的值作为前缀。</para>
		/// <para>时间窗可以解释为具体日期或通用工作日。 使用具体日期列用于确定开始日期时间列的日期部分将被解释为确切日期还是通用工作日。 例如，如果开始日期时间值的日期部分是 2021 年 12 月 25 日，并且使用具体日期为 True，则将使用确切日期，并且计算的公共交通服务频率将包括为圣诞节假期添加或移除的所有特殊服务. 如果使用具体日期为 False，则该日期将被解释为星期六，并且计算的公共交通服务频率将包括所有典型星期六的常规服务。</para>
		/// <para>对于具体日期，将考虑 CalendarExceptions 表中包含的常规公共交通服务以及 Calendars 表中定义的日期范围的所有例外情况。 对于通用工作日，仅考虑 Calendars 表中工作日字段中定义的常规服务。</para>
		/// <para>使用具体日期 - 布尔值，用于指示时间窗的日期将被解释为指定的确切日期 (True) 还是由日期表示的通用工作日 (False)。</para>
		/// <para>开始日期时间 - 时间窗开始的日期和时间。</para>
		/// <para>持续时间（分钟）- 时间窗的持续时间（以分钟为单位）。</para>
		/// <para>到达或出发计数 - 在计算公共交通频率统计数据时，是否将计算公共交通停靠点的到达或出发。</para>
		/// <para>到达 - 到达公共交通停靠点的次数。 将在计算中考虑到达次数。</para>
		/// <para>出发 - 从公共交通停靠点出发的次数。 将在计算中考虑出发次数。</para>
		/// <para>输出字段前缀 - 将包含在与此时间窗关联的所有输出字段名称中的字符串前缀。 字符串前缀必须是唯一的，并且只能包含对输出要素类中的字段名称有效的字符。</para>
		/// </param>
		public CalculateTransitServiceFrequency(object InTransitFeatureDataset, object AnalysisType, object OutFeatureClass, object TimeWindows)
		{
			this.InTransitFeatureDataset = InTransitFeatureDataset;
			this.AnalysisType = AnalysisType;
			this.OutFeatureClass = OutFeatureClass;
			this.TimeWindows = TimeWindows;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算交通服务频率</para>
		/// </summary>
		public override string DisplayName() => "计算交通服务频率";

		/// <summary>
		/// <para>Tool Name : CalculateTransitServiceFrequency</para>
		/// </summary>
		public override string ToolName() => "CalculateTransitServiceFrequency";

		/// <summary>
		/// <para>Tool Excute Name : transit.CalculateTransitServiceFrequency</para>
		/// </summary>
		public override string ExcuteName() => "transit.CalculateTransitServiceFrequency";

		/// <summary>
		/// <para>Toolbox Display Name : Public Transit Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Public Transit Tools";

		/// <summary>
		/// <para>Toolbox Alise : transit</para>
		/// </summary>
		public override string ToolboxAlise() => "transit";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTransitFeatureDataset, AnalysisType, OutFeatureClass, TimeWindows, SeparateCountsByLine!, InPointsOfInterest!, NetworkDataSource!, TravelMode!, TravelLimit!, TravelLimitUnits!, CellSize!, Barriers! };

		/// <summary>
		/// <para>Input Transit Feature Dataset</para>
		/// <para>包含来自 Network Analyst 公共交通数据模型的 Stops 和 LineVariantElements 要素类的要素数据集。 要素数据集的父地理数据库必须包含公共交通数据模型的 LineVariants、Schedules、ScheduleElements 和 Runs 表以及 Calendars 表、CalendarExceptions 表或两者皆有。</para>
		/// <para>可以使用 GTFS 转公共交通数据模型工具从通用交通数据规范 (GTFS) 公共交通数据创建具有关联要素类和表的有效要素数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object InTransitFeatureDataset { get; set; }

		/// <summary>
		/// <para>Analysis Type</para>
		/// <para>指定工具将为其计算公共交通服务频率的位置类型。</para>
		/// <para>交通停靠点—将计算公共交通停靠点的公共交通服务频率。 输出将为要素类，其中包含来自输入公共交通数据模型 Stops 要素类的公共交通停靠点的副本。</para>
		/// <para>交通线路—将计算沿公共交通线路的公共交通服务频率。 输出将为要素类，其中包含来自输入公共交通数据模型 LineVariantElements 要素类的公共交通线路的副本。</para>
		/// <para>感兴趣点—将计算指定感兴趣点的公共交通服务频率。 输出将为输入感兴趣点的副本。</para>
		/// <para>面—将计算所有公共交通停靠点范围内所有区域的公共交通服务频率。 输出将为面要素类，表示公共交通系统所服务的区域。</para>
		/// <para><see cref="AnalysisTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AnalysisType { get; set; } = "STOPS";

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>输出要素类。</para>
		/// <para>shapefile 不是有效值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Time Windows</para>
		/// <para>将计算公共交通服务频率的时间段。</para>
		/// <para>可以指定多个时间窗。 输出要素类将包含一组字段，表示每个时间窗的交通频率统计数据。 这些字段将以输出字段前缀列中指定的值作为前缀。</para>
		/// <para>时间窗可以解释为具体日期或通用工作日。 使用具体日期列用于确定开始日期时间列的日期部分将被解释为确切日期还是通用工作日。 例如，如果开始日期时间值的日期部分是 2021 年 12 月 25 日，并且使用具体日期为 True，则将使用确切日期，并且计算的公共交通服务频率将包括为圣诞节假期添加或移除的所有特殊服务. 如果使用具体日期为 False，则该日期将被解释为星期六，并且计算的公共交通服务频率将包括所有典型星期六的常规服务。</para>
		/// <para>对于具体日期，将考虑 CalendarExceptions 表中包含的常规公共交通服务以及 Calendars 表中定义的日期范围的所有例外情况。 对于通用工作日，仅考虑 Calendars 表中工作日字段中定义的常规服务。</para>
		/// <para>使用具体日期 - 布尔值，用于指示时间窗的日期将被解释为指定的确切日期 (True) 还是由日期表示的通用工作日 (False)。</para>
		/// <para>开始日期时间 - 时间窗开始的日期和时间。</para>
		/// <para>持续时间（分钟）- 时间窗的持续时间（以分钟为单位）。</para>
		/// <para>到达或出发计数 - 在计算公共交通频率统计数据时，是否将计算公共交通停靠点的到达或出发。</para>
		/// <para>到达 - 到达公共交通停靠点的次数。 将在计算中考虑到达次数。</para>
		/// <para>出发 - 从公共交通停靠点出发的次数。 将在计算中考虑出发次数。</para>
		/// <para>输出字段前缀 - 将包含在与此时间窗关联的所有输出字段名称中的字符串前缀。 字符串前缀必须是唯一的，并且只能包含对输出要素类中的字段名称有效的字符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object TimeWindows { get; set; }

		/// <summary>
		/// <para>Separate Counts By Transit Line</para>
		/// <para>指定在计算公共交通频率统计数据时，使用同一停靠点或通道的多条公共交通线路的服务是按公共交通线路分开计数还是合并计数。</para>
		/// <para>当按交通线路分开计数时，输出将包含使用停靠点或通道的每条唯一交通线路的每个停靠点或交通线段的副本，并且这些重复要素将具有重叠几何。</para>
		/// <para>如果输入数据中的 LineVariants 表具有可选 GDirectionID 字段，则输出将另外按 GDirectionID 字段值分开计数。 例如，如果停靠点服务于沿同一条线的两个行进方向，则输出将包含 GDirectionID 字段定义的每个行进方向的停靠点副本。</para>
		/// <para>选中 - 在计算公共交通频率统计数据时，为同一停靠点或通道提供服务的多条公共交通线路将分开计数。</para>
		/// <para>未选中 - 在计算公共交通频率统计数据时，为同一停靠点或通道提供服务的多条公共交通线路不会分开计数，其将合并计数。 这是默认设置。</para>
		/// <para>仅在分析类型参数设置为交通停靠点或交通线路时，此参数才适用。</para>
		/// <para><see cref="SeparateCountsByLineEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SeparateCountsByLine { get; set; } = "false";

		/// <summary>
		/// <para>Input Points of Interest</para>
		/// <para>将计算可用公共交通服务频率的感兴趣点。</para>
		/// <para>如果指定了面图层，则将使用面质心处可用的公共交通服务。</para>
		/// <para>当分析类型参数设置为感兴趣点时，此参数是必需项；否则，它将被忽略。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		public object? InPointsOfInterest { get; set; }

		/// <summary>
		/// <para>Network Data Source</para>
		/// <para>将用于确定指定感兴趣点范围内的公共交通停靠点或计算公共交通停靠点范围内的面区域的网络数据集或服务。 可以使用网络数据集的目录路径、网络数据集图层对象、网络数据集图层的字符串名称或网络分析服务的门户 URL。 网络必须包含至少一个出行模式。</para>
		/// <para>要使用门户 URL，您必须使用具有路径选择权限的帐户登录门户。</para>
		/// <para>如果使用 ArcGIS Online 作为网络数据源，则运行该工具将消耗配额。</para>
		/// <para>使用适合对往返公共交通停靠点的乘客进行建模的网络数据集。 请勿使用经过配置的网络数据集，该网络数据集将公共交通数据与公共交通赋值器配合使用，因为此类型的网络将模拟乘坐公共交通的乘客，而非在公共交通停靠点往返的乘客。</para>
		/// <para>当分析类型参数设置为感兴趣点或区域时，此参数是必需项；否则，它将被忽略。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPNetworkDataSource()]
		public object? NetworkDataSource { get; set; }

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>将用于确定指定感兴趣点范围内的公共交通停靠点或计算公共交通停靠点范围内的面区域的网络数据源的出行模式。 可以指定出行模式作为出行模式的字符串名称，也可以作为 arcpy.nax.TravelMode 对象。</para>
		/// <para>使用最适合对往返公共交通停靠点的乘客进行建模的出行模式。 通常情况下，应使用模拟步行时间或距离的出行模式。</para>
		/// <para>请勿将出行模式与使用公共交通赋值器的阻抗属性配合使用，因为该出行模式将模拟乘坐公共交通的乘客，而非在公共交通停靠点往返的乘客。</para>
		/// <para>当分析类型参数设置为感兴趣点或区域时，此参数是必需项；否则，它将被忽略。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[NetworkTravelMode()]
		public object? TravelMode { get; set; }

		/// <summary>
		/// <para>Maximum travel time or distance to stops</para>
		/// <para>在感兴趣点范围内查找公共交通停靠点或计算公共交通停靠点可到达的区域时将使用的阻抗限制。</para>
		/// <para>此参数单位应为到停靠点的最长行驶时间或距离参数中指定的单位。</para>
		/// <para>当分析类型参数设置为感兴趣点或区域时，此参数是必需项；否则，它将被忽略。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? TravelLimit { get; set; }

		/// <summary>
		/// <para>Units of travel time or distance to stops</para>
		/// <para>指定将用于在到停靠点的最长行驶时间或距离参数中指定的阻抗限制的单位。</para>
		/// <para>可用单位取决于出行模式参数中指定的值。 如果出行模式的阻抗具有时间单位，则仅可用基于时间的单位。 如果出行模式的阻抗具有距离单位，则仅可用基于距离的单位。 如果出行模式的阻抗单位既不基于时间也不基于距离，则唯一可用的选项将是未知单位，并且到停靠点的最长行驶时间或距离参数值将以出行模式的阻抗为单位。</para>
		/// <para>千米—指定的阻抗限制将以千米为单位。</para>
		/// <para>米—指定的阻抗限制将以米为单位。</para>
		/// <para>英里—指定的阻抗限制将以英里为单位。</para>
		/// <para>码—指定的阻抗限制将以码为单位。</para>
		/// <para>英尺—指定的阻抗限制将以英尺为单位。</para>
		/// <para>海里—指定的阻抗限制将以海里为单位。</para>
		/// <para>天—指定的阻抗限制将以日为单位。</para>
		/// <para>小时—指定的阻抗限制将以小时为单位。</para>
		/// <para>分—指定的阻抗限制将以分钟为单位。</para>
		/// <para>秒—指定的阻抗限制将以秒为单位。</para>
		/// <para>出行模式的阻抗单位—将以所选出行模式的阻抗单位指定阻抗限制。</para>
		/// <para>当分析类型参数设置为感兴趣点或区域时，此参数是必需项；否则，它将被忽略。</para>
		/// <para>建议您在计算兴趣点的公共交通服务频率时使用基于距离的出行限制。 通过基于距离的限制，该工具可以使用简单的直线距离选择提前减小 OD 成本矩阵的大小。 这可能会从 OD 成本矩阵分析中清除一些起点和目的地，从而提高性能。 如果网络数据源是消耗配额的服务，这种优化也会减少所需的配额数量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TravelLimitUnits { get; set; }

		/// <summary>
		/// <para>Cell Size</para>
		/// <para>将用于表示从工具输出中的公共交通停靠点可到达的区域的像元大小（边长）。 使用该参数设置数值和单位。</para>
		/// <para>在计算从公共交通停靠点可到达的区域时，将计算服务区域。 生成的通常重叠的服务区面被简化为类似栅格的面要素类，该要素类由此参数中指定大小的正方形像元组成。 根据服务区面与像元质心重叠的公共交通停靠点，为这些像元中的每一个像元计算公共交通服务频率统计数据。</para>
		/// <para>使用与行人在现实世界中的出行方式相关的像元大小。 例如，您可以根据城市街区或宗地的大小或行人在不到一分钟的时间内步行的距离来确定像元大小。 像元越小，准确度越高，但也需要更长的处理时间。</para>
		/// <para>默认值是 80 米。</para>
		/// <para>当分析类型参数设置为区域时，此参数是必需项；否则，它将被忽略。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? CellSize { get; set; } = "80 Meters";

		/// <summary>
		/// <para>Barriers</para>
		/// <para>在计算指定感兴趣点范围内的公共交通停靠点或计算公共交通停靠点范围内的面区域时，将在网络分析中用作障碍的点、线或面要素。</para>
		/// <para>仅当分析类型参数设置为感兴趣点或区域时，此参数才为相关项；否则，它将被忽略。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Barriers { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Analysis Type</para>
		/// </summary>
		public enum AnalysisTypeEnum 
		{
			/// <summary>
			/// <para>交通停靠点—将计算公共交通停靠点的公共交通服务频率。 输出将为要素类，其中包含来自输入公共交通数据模型 Stops 要素类的公共交通停靠点的副本。</para>
			/// </summary>
			[GPValue("STOPS")]
			[Description("交通停靠点")]
			Transit_stops,

			/// <summary>
			/// <para>交通线路—将计算沿公共交通线路的公共交通服务频率。 输出将为要素类，其中包含来自输入公共交通数据模型 LineVariantElements 要素类的公共交通线路的副本。</para>
			/// </summary>
			[GPValue("LINES")]
			[Description("交通线路")]
			Transit_lines,

			/// <summary>
			/// <para>感兴趣点—将计算指定感兴趣点的公共交通服务频率。 输出将为输入感兴趣点的副本。</para>
			/// </summary>
			[GPValue("POINTS_OF_INTEREST")]
			[Description("感兴趣点")]
			Points_of_interest,

			/// <summary>
			/// <para>面—将计算所有公共交通停靠点范围内所有区域的公共交通服务频率。 输出将为面要素类，表示公共交通系统所服务的区域。</para>
			/// </summary>
			[GPValue("AREAS")]
			[Description("面")]
			Areas,

		}

		/// <summary>
		/// <para>Separate Counts By Transit Line</para>
		/// </summary>
		public enum SeparateCountsByLineEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SEPARATE")]
			SEPARATE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SEPARATE")]
			NO_SEPARATE,

		}

#endregion
	}
}
