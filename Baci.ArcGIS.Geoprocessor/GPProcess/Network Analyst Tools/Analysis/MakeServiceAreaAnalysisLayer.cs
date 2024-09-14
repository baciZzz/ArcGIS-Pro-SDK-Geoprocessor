using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkAnalystTools
{
	/// <summary>
	/// <para>Make Service Area Analysis Layer</para>
	/// <para>创建服务区分析图层</para>
	/// <para>创建服务区网络分析图层并设置其分析属性。服务区分析图层主要用于确定在指定中断成本范围内能从设施点位置访问的区域。该图层可通过本地网络数据集或在线托管或门户托管路径服务创建。</para>
	/// </summary>
	public class MakeServiceAreaAnalysisLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="NetworkDataSource">
		/// <para>Network Data Source</para>
		/// <para>将对其执行网络分析的网络数据集或服务。将门户 URL 用于服务。</para>
		/// </param>
		public MakeServiceAreaAnalysisLayer(object NetworkDataSource)
		{
			this.NetworkDataSource = NetworkDataSource;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建服务区分析图层</para>
		/// </summary>
		public override string DisplayName() => "创建服务区分析图层";

		/// <summary>
		/// <para>Tool Name : MakeServiceAreaAnalysisLayer</para>
		/// </summary>
		public override string ToolName() => "MakeServiceAreaAnalysisLayer";

		/// <summary>
		/// <para>Tool Excute Name : na.MakeServiceAreaAnalysisLayer</para>
		/// </summary>
		public override string ExcuteName() => "na.MakeServiceAreaAnalysisLayer";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise() => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { NetworkDataSource, LayerName, TravelMode, TravelDirection, Cutoffs, TimeOfDay, TimeZone, OutputType, PolygonDetail, GeometryAtOverlaps, GeometryAtCutoffs, PolygonTrimDistance, ExcludeSourcesFromPolygonGeneration, AccumulateAttributes, OutNetworkAnalysisLayer };

		/// <summary>
		/// <para>Network Data Source</para>
		/// <para>将对其执行网络分析的网络数据集或服务。将门户 URL 用于服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object NetworkDataSource { get; set; }

		/// <summary>
		/// <para>Layer Name</para>
		/// <para>要创建的网络分析图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object LayerName { get; set; }

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>分析中使用的出行模式名称。出行模式为一组网络设置（例如行驶限制和 U 形转弯），用于确定行人、车辆、卡车或其他交通媒介在网络中的移动方式。出行模式在网络数据源中进行定义。</para>
		/// <para>arcpy.na.TravelMode 对象和包含出行模式有效 JSON 表示的字符串也可用作参数的输入。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TravelMode { get; set; }

		/// <summary>
		/// <para>Travel Direction</para>
		/// <para>指定行至或离开设施点的方向。</para>
		/// <para>远离设施点—服务区表示远离设施点。这是默认设置。</para>
		/// <para>朝向设施点—服务区表示朝向设施点。</para>
		/// <para>使用此参数的结果是，在基于行驶方向的网络中，单向限制及不同行驶方向的阻抗差异会产生不同的服务区。例如，应该在远离设施点的方向上创建比萨外卖店的服务区，而医院的服务区应该创建在朝向设施点的方向上。</para>
		/// <para><see cref="TravelDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TravelDirection { get; set; } = "FROM_FACILITIES";

		/// <summary>
		/// <para>Cutoffs</para>
		/// <para>将使用您所选择出行模式使用的抗阻属性单位计算服务区范围。例如，分析行驶时间时，中断值 10 表示生成的服务区将代表 10 分钟行驶区域内可送达的区域。</para>
		/// <para>可设置多个中断值以便创建同心服务区。例如，要针对同一设施点查找 2 分钟、3 分钟和 5 分钟内的服务区，可将该参数值指定为 2、3 和 5。</para>
		/// <para>在设施点子图层中指定单独的中断值可按设施点覆盖默认中断值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object Cutoffs { get; set; }

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>离开或到达服务区图层的设施点的时间。此值可理解为离开时间或到达时间，具体取决于行驶方向是远离还是朝向设施点。</para>
		/// <para>如果将行驶方向设置为远离设施点，则此值表示离开时间。</para>
		/// <para>如果将行驶方向设置为朝向设施点，则此值表示到达时间。</para>
		/// <para>根据使用抗阻值的出行模式查找可到达的道路，而抗阻值根据时间的不同而不同（例如取决于动态交通状况）时，时间参数最为有用。使用不同的时间值求解同一分析可查看设施点可到达的道路如何随时间的变化而变化。例如，消防站周围的 5 分钟服务区在大清早时可能变得大一点，而在早高峰期消失，上午晚些时候服务区又扩大，并在一天中都保持这样。</para>
		/// <para>可将时间和日期指定为 10/21/2015 10:30 AM。</para>
		/// <para>可使用以下日期来指定一周中的每一天，而无需使用特定的日期：</para>
		/// <para>今天 - 12/30/1899</para>
		/// <para>星期日 - 12/31/1899</para>
		/// <para>星期一 - 1/1/1900</para>
		/// <para>星期二 - 1/2/1900</para>
		/// <para>星期三 - 1/3/1900</para>
		/// <para>星期四 - 1/4/1900</para>
		/// <para>星期五 - 1/5/1900</para>
		/// <para>星期六 - 1/6/1900</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Time of Day")]
		public object TimeOfDay { get; set; }

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>指定时间参数的时区。</para>
		/// <para>各位置的本地时间—时间参数将使用设施点所处的一个或多个时区。服务区开始时间或结束时间的时区交错。这是默认设置。例如，如果将时间设为 9:00 a.m.，则会为处于东部时区的所有设施点生成东部时间 9:00 a.m. 的服务区、为处于中部时区的设施点生成中部时间 9:00 a.m. 的服务区、为处于山区时区的设施点生成山区时间 9:00 a.m. 的服务区等等。如果商店处于覆盖美国、在当地时间 9:00 a.m. 开业的商店链中，请在一次求解中选择此参数值来查找处于所有商店开业时间的市场地区。首先，东部时区的商店将开业，并生成面。一个小时后，商店将在中部时区开业，依此类推。当地时间始终为 9 点，但却因不同时区而实时交错。</para>
		/// <para>UTC—时间参数将使用协调世界时间 (UTC)。无论各设施点处于哪些时区或区域都会同时到达或出发。如果将时间设为 2:00 p.m.，则会为处于东部时区的所有设施点生成东部标准时间 9:00 a.m. 的服务区、为处于中部时区的设施点生成中部标准时间 8:00 a.m. 的服务区、为处于山区时区的设施点生成山区标准时间 7:00 a.m. 的服务区等等。UTC 选项可用于为跨两个时区的管辖区显示紧急响应范围。将急救车辆加载为设施点。将时间设置为 UTC 的当前时间。（您需要确定准确的当前时间和日期，以便 UTC 正确使用此选项。） 设置其他属性，并对分析进行求解。尽管时区边界会分割车辆，但结果仍将显示当前交通状况下可以到达的区域。也可对其他时间使用相同的过程，而不仅是当前时间。以上情况均假定为标准时间。在夏令时期间，东部、中部、和山地时间应各提前 1 小时（即分别为 10:00 a.m.、9:00 a.m. 和 8:00 a.m.）。</para>
		/// <para>&lt;bold/&gt;</para>
		/// <para><see cref="TimeZoneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Time of Day")]
		public object TimeZone { get; set; } = "LOCAL_TIME_AT_LOCATIONS";

		/// <summary>
		/// <para>Output Type</para>
		/// <para>指定要生成的输出类型。服务区输出可以是超过中断值前表示可到达道路的线要素，也可以是包括这些线的面要素（表示可达到的区域）。</para>
		/// <para>面—服务区输出将仅包含面。这是默认设置。</para>
		/// <para>线—服务区输出将仅包含线。</para>
		/// <para>面和线—服务区输出将既包含面又包含线。</para>
		/// <para>如果网络数据源是不支持线生成的 Portal for ArcGIS 版本上的服务，则线以及面和线输出类型将不可用。</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Geometry")]
		public object OutputType { get; set; } = "POLYGONS";

		/// <summary>
		/// <para>Polygon Detail</para>
		/// <para>指定输出面的细节层次。</para>
		/// <para>标准—将以标准细节层次创建面。这是默认设置。</para>
		/// <para>概化—将使用网络的等级属性创建概化面，以快速生成结果。如果网络没有等级属性，则此选项不可用。</para>
		/// <para>高—将创建细节层次较高的面，以便用于需要精细结果的情况。</para>
		/// <para>如果分析包括的市区具有类似格网的街道网络，则概化面和标准面之间的差异十分细微。但是，如果涉及山区和农村道路，那么标准面表示的结果可能要比概化面更加详细。</para>
		/// <para><see cref="PolygonDetailEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Geometry")]
		public object PolygonDetail { get; set; } = "STANDARD";

		/// <summary>
		/// <para>Geometry at Overlaps</para>
		/// <para>指定多个设施点中服务区输出间的相互行为。</para>
		/// <para>重叠—将为各个设施点创建单独的面或线集。这些面或线可以相互叠置。这是默认设置。</para>
		/// <para>融合—将中断值相同的多个设施点面合并为一个单独的面。该选项不适用于线输出。</para>
		/// <para>分割—区域将分配至最近设施点，因此面或线不会相互重叠。</para>
		/// <para><see cref="GeometryAtOverlapsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Geometry")]
		public object GeometryAtOverlaps { get; set; } = "OVERLAP";

		/// <summary>
		/// <para>Geometry at Cutoffs</para>
		/// <para>指定在指定了多个中断值的情况下单个设施点服务区输出的行为。该参数不适用于线输出。</para>
		/// <para>环—各个面将仅包括连续中断值之间的区域。其将不会包括设施点和任何较小中断值之间的区域。例如，如果创建 5 分钟和 10 分钟服务区，5 分钟服务区面将包含 0 到 5 分钟内可到达的区域，而 10 分钟服务区面则包括 5 到 10 分钟内可到达的区域。这是默认设置。</para>
		/// <para>磁盘—各个面将包含从设施点到中断值内可到达的区域，其中包括较小中断值内可到达的区域。例如，如果创建 5 分钟和 10 分钟服务区，则 10 分钟服务区面将包含 5 分钟服务区面内的区域。</para>
		/// <para><see cref="GeometryAtCutoffsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Geometry")]
		public object GeometryAtCutoffs { get; set; } = "RINGS";

		/// <summary>
		/// <para>Polygon Trim Distance</para>
		/// <para>服务区面修剪距离。面修剪距离是附近没有其他可到达道路时，服务区面将从道路延伸的距离，类似于线缓冲大小。这在网络稀疏且不需要服务区覆盖大片不含要素的区域时十分有用。</para>
		/// <para>该参数包括距离的值和单位。默认值是 100 米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Output Geometry")]
		public object PolygonTrimDistance { get; set; } = "100 Meters";

		/// <summary>
		/// <para>Exclude Sources From Polygon Generation</para>
		/// <para>生成服务区面时将要排除的网络数据集边源。不会在已排除源周围生成面，即使它们在分析中遍历。</para>
		/// <para>从服务区多边形中排除网络源并不会阻止这些源受遍历。只会影响该服务区的多边形形状。要阻止遍历给定网络源，必须在定义网络数据集时创建适当的限制。</para>
		/// <para>在生成面的过程中，如果需要排除某些会创建低精度的面或者对服务区分析无关紧要的网络源时，此选项十分有用。例如，在包含街道和地铁线路的多模式网络中创建步行时间服务区时，应选择在面生成过程中排除地铁线路。尽管旅客可以乘坐地铁线路，但是他们却无法在地铁线路中途下车或进入到附近建筑。相反，他们必须全程乘坐地铁线路，在地铁站离开地铁系统，然后通过街道步行至建筑物内。沿地铁线路生成的面要素不会十分准确。</para>
		/// <para>此参数在以下情况中不可用：输出几何类型不包括面，网络中的边源少于两个，网络数据源是 ArcGIS Online 服务，或者网络数据源服务所在 Portal for ArcGIS 版本不支持排除源功能。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Output Geometry")]
		public object ExcludeSourcesFromPolygonGeneration { get; set; }

		/// <summary>
		/// <para>Accumulate Attributes</para>
		/// <para>分析过程中要累积的成本属性的列表。这些累积属性仅供参考；求解程序仅使用求解分析时指定的出行模式所使用的成本属性。</para>
		/// <para>对于每个累积的成本属性，会在网络分析输出要素中填充 Total_[Impedance] 属性。</para>
		/// <para>如果分析图层未配置为输出线、网络数据源为 ArcGIS Online 服务，或如果网络数据源是不支持累积的 Portal for ArcGIS 版本上的服务，则此参数不可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Accumulate Attributes")]
		public object AccumulateAttributes { get; set; }

		/// <summary>
		/// <para>Network Analyst Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object OutNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeServiceAreaAnalysisLayer SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Travel Direction</para>
		/// </summary>
		public enum TravelDirectionEnum 
		{
			/// <summary>
			/// <para>朝向设施点—服务区表示朝向设施点。</para>
			/// </summary>
			[GPValue("TO_FACILITIES")]
			[Description("朝向设施点")]
			Toward_facilities,

			/// <summary>
			/// <para>远离设施点—服务区表示远离设施点。这是默认设置。</para>
			/// </summary>
			[GPValue("FROM_FACILITIES")]
			[Description("远离设施点")]
			Away_from_facilities,

		}

		/// <summary>
		/// <para>Time Zone</para>
		/// </summary>
		public enum TimeZoneEnum 
		{
			/// <summary>
			/// <para>UTC—时间参数将使用协调世界时间 (UTC)。无论各设施点处于哪些时区或区域都会同时到达或出发。如果将时间设为 2:00 p.m.，则会为处于东部时区的所有设施点生成东部标准时间 9:00 a.m. 的服务区、为处于中部时区的设施点生成中部标准时间 8:00 a.m. 的服务区、为处于山区时区的设施点生成山区标准时间 7:00 a.m. 的服务区等等。UTC 选项可用于为跨两个时区的管辖区显示紧急响应范围。将急救车辆加载为设施点。将时间设置为 UTC 的当前时间。（您需要确定准确的当前时间和日期，以便 UTC 正确使用此选项。） 设置其他属性，并对分析进行求解。尽管时区边界会分割车辆，但结果仍将显示当前交通状况下可以到达的区域。也可对其他时间使用相同的过程，而不仅是当前时间。以上情况均假定为标准时间。在夏令时期间，东部、中部、和山地时间应各提前 1 小时（即分别为 10:00 a.m.、9:00 a.m. 和 8:00 a.m.）。</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

			/// <summary>
			/// <para>各位置的本地时间—时间参数将使用设施点所处的一个或多个时区。服务区开始时间或结束时间的时区交错。这是默认设置。例如，如果将时间设为 9:00 a.m.，则会为处于东部时区的所有设施点生成东部时间 9:00 a.m. 的服务区、为处于中部时区的设施点生成中部时间 9:00 a.m. 的服务区、为处于山区时区的设施点生成山区时间 9:00 a.m. 的服务区等等。如果商店处于覆盖美国、在当地时间 9:00 a.m. 开业的商店链中，请在一次求解中选择此参数值来查找处于所有商店开业时间的市场地区。首先，东部时区的商店将开业，并生成面。一个小时后，商店将在中部时区开业，依此类推。当地时间始终为 9 点，但却因不同时区而实时交错。</para>
			/// </summary>
			[GPValue("LOCAL_TIME_AT_LOCATIONS")]
			[Description("各位置的本地时间")]
			Local_time_at_locations,

		}

		/// <summary>
		/// <para>Output Type</para>
		/// </summary>
		public enum OutputTypeEnum 
		{
			/// <summary>
			/// <para>面—服务区输出将仅包含面。这是默认设置。</para>
			/// </summary>
			[GPValue("POLYGONS")]
			[Description("面")]
			Polygons,

			/// <summary>
			/// <para>线—服务区输出将仅包含线。</para>
			/// </summary>
			[GPValue("LINES")]
			[Description("线")]
			Lines,

			/// <summary>
			/// <para>面和线—服务区输出将既包含面又包含线。</para>
			/// </summary>
			[GPValue("POLYGONS_AND_LINES")]
			[Description("面和线")]
			Polygons_and_lines,

		}

		/// <summary>
		/// <para>Polygon Detail</para>
		/// </summary>
		public enum PolygonDetailEnum 
		{
			/// <summary>
			/// <para>概化—将使用网络的等级属性创建概化面，以快速生成结果。如果网络没有等级属性，则此选项不可用。</para>
			/// </summary>
			[GPValue("GENERALIZED")]
			[Description("概化")]
			Generalized,

			/// <summary>
			/// <para>标准—将以标准细节层次创建面。这是默认设置。</para>
			/// </summary>
			[GPValue("STANDARD")]
			[Description("标准")]
			Standard,

			/// <summary>
			/// <para>高—将创建细节层次较高的面，以便用于需要精细结果的情况。</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("高")]
			High,

		}

		/// <summary>
		/// <para>Geometry at Overlaps</para>
		/// </summary>
		public enum GeometryAtOverlapsEnum 
		{
			/// <summary>
			/// <para>重叠—将为各个设施点创建单独的面或线集。这些面或线可以相互叠置。这是默认设置。</para>
			/// </summary>
			[GPValue("OVERLAP")]
			[Description("重叠")]
			Overlap,

			/// <summary>
			/// <para>融合—将中断值相同的多个设施点面合并为一个单独的面。该选项不适用于线输出。</para>
			/// </summary>
			[GPValue("DISSOLVE")]
			[Description("融合")]
			Dissolve,

			/// <summary>
			/// <para>分割—区域将分配至最近设施点，因此面或线不会相互重叠。</para>
			/// </summary>
			[GPValue("SPLIT")]
			[Description("分割")]
			Split,

		}

		/// <summary>
		/// <para>Geometry at Cutoffs</para>
		/// </summary>
		public enum GeometryAtCutoffsEnum 
		{
			/// <summary>
			/// <para>环—各个面将仅包括连续中断值之间的区域。其将不会包括设施点和任何较小中断值之间的区域。例如，如果创建 5 分钟和 10 分钟服务区，5 分钟服务区面将包含 0 到 5 分钟内可到达的区域，而 10 分钟服务区面则包括 5 到 10 分钟内可到达的区域。这是默认设置。</para>
			/// </summary>
			[GPValue("RINGS")]
			[Description("环")]
			Rings,

			/// <summary>
			/// <para>磁盘—各个面将包含从设施点到中断值内可到达的区域，其中包括较小中断值内可到达的区域。例如，如果创建 5 分钟和 10 分钟服务区，则 10 分钟服务区面将包含 5 分钟服务区面内的区域。</para>
			/// </summary>
			[GPValue("DISKS")]
			[Description("磁盘")]
			Disks,

		}

#endregion
	}
}
