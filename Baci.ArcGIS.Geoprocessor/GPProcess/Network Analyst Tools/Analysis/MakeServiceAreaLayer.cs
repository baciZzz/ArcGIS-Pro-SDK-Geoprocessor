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
	/// <para>Make Service Area Layer</para>
	/// <para>创建服务区图层</para>
	/// <para>创建服务区网络分析图层并设置其分析属性。服务区分析图层主要用于确定在指定中断成本范围内能从设施点位置访问的区域。</para>
	/// </summary>
	[Obsolete()]
	public class MakeServiceAreaLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkDataset">
		/// <para>Input Analysis Network</para>
		/// <para>将在其中执行服务区分析的网络数据集。</para>
		/// </param>
		/// <param name="OutNetworkAnalysisLayer">
		/// <para>Output Layer Name</para>
		/// <para>要创建的服务区网络分析图层的名称。</para>
		/// </param>
		/// <param name="ImpedanceAttribute">
		/// <para>Impedance Attribute</para>
		/// <para>分析过程中用作阻抗的成本属性。</para>
		/// </param>
		public MakeServiceAreaLayer(object InNetworkDataset, object OutNetworkAnalysisLayer, object ImpedanceAttribute)
		{
			this.InNetworkDataset = InNetworkDataset;
			this.OutNetworkAnalysisLayer = OutNetworkAnalysisLayer;
			this.ImpedanceAttribute = ImpedanceAttribute;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建服务区图层</para>
		/// </summary>
		public override string DisplayName() => "创建服务区图层";

		/// <summary>
		/// <para>Tool Name : MakeServiceAreaLayer</para>
		/// </summary>
		public override string ToolName() => "MakeServiceAreaLayer";

		/// <summary>
		/// <para>Tool Excute Name : na.MakeServiceAreaLayer</para>
		/// </summary>
		public override string ExcuteName() => "na.MakeServiceAreaLayer";

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
		public override object[] Parameters() => new object[] { InNetworkDataset, OutNetworkAnalysisLayer, ImpedanceAttribute, TravelFromTo, DefaultBreakValues, PolygonType, Merge, NestingType, LineType, Overlap, Split, ExcludedSourceName, AccumulateAttributeName, UturnPolicy, RestrictionAttributeName, PolygonTrim, PolyTrimValue, LinesSourceFields, Hierarchy, TimeOfDay, OutputLayer };

		/// <summary>
		/// <para>Input Analysis Network</para>
		/// <para>将在其中执行服务区分析的网络数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNetworkDatasetLayer()]
		public object InNetworkDataset { get; set; }

		/// <summary>
		/// <para>Output Layer Name</para>
		/// <para>要创建的服务区网络分析图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Impedance Attribute</para>
		/// <para>分析过程中用作阻抗的成本属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ImpedanceAttribute { get; set; }

		/// <summary>
		/// <para>Travel From or To Facility</para>
		/// <para>指定行至或离开设施点的方向。</para>
		/// <para>远离设施点—在远离设施点的方向上创建服务区。</para>
		/// <para>朝向设施点—在接近设施点的方向上创建服务区。</para>
		/// <para>使用此选项的结果是，在基于行驶方向的网络中，单向限制及不同行驶方向的阻抗差异会产生不同的服务区。例如，应该在远离设施点的方向上创建比萨外卖店的服务区，而医院的服务区应该创建在朝向设施点的方向上。</para>
		/// <para><see cref="TravelFromToEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TravelFromTo { get; set; } = "TRAVEL_FROM";

		/// <summary>
		/// <para>Default Break Values</para>
		/// <para>指示要计算的服务区范围的默认阻抗值。可通过对设施点指定中断值来覆盖默认值。</para>
		/// <para>可以设置多个面中断来创建同心服务区。例如，要为同一设施点查找 2 分钟、3 分钟和 5 分钟服务区，请将“默认中断值”参数指定为“2 3 5”（2、3 和 5 这些数字之间应该以空格分隔）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DefaultBreakValues { get; set; }

		/// <summary>
		/// <para>Polygon Type</para>
		/// <para>指定要生成的面的类型。</para>
		/// <para>简单面—创建生成速度快并且相当精确的概化面，边缘除外。这是默认设置。</para>
		/// <para>详细面—创建详细面，用于对服务区线进行精确建模并且可包含未到达的岛状区域。这种面比概化面的生成速度慢。</para>
		/// <para>无面—在仅需要服务区线的情况下，将关闭“面生成”选项。</para>
		/// <para>如果是具有类似格网网络的市区数据，则概化多边形和详细多边形之间的差别最小。然而，对于山区道路和农村道路，详细多边形可能会呈现出比概化多边形更精确的结果。</para>
		/// <para><see cref="PolygonTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Polygon Generation Options")]
		public object PolygonType { get; set; } = "SIMPLE_POLYS";

		/// <summary>
		/// <para>Merge Polygons with Similar Ranges</para>
		/// <para>指定用来合并共享相似中断值的面的选项。仅当为多个设施点生成面时，此选项才可用。</para>
		/// <para>重叠—为各个设施点创建单独的面。这些面可以相互叠置。</para>
		/// <para>斯普利特—为各个设施点创建最接近的单独面。这些面不会相互叠置。</para>
		/// <para>融合— 连接具有相同中断值的多个设施点的面。</para>
		/// <para><see cref="MergeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Polygon Generation Options")]
		public object Merge { get; set; } = "NO_MERGE";

		/// <summary>
		/// <para>Polygon Nest Option</para>
		/// <para>指定该选项，将同心服务区面创建为圆或环。仅当为这些设施点指定多个中断值时，此选项才可用。</para>
		/// <para>环—不包括较小中断的区域。这将在连续的中断之间创建面。如果要查找从一个中断到另一个中断的区域，请使用此选项。</para>
		/// <para>圆盘— 在设施点与中断之间创建面。例如，如果创建 5 分钟和 10 分钟服务区，则 10 分钟服务区面将包含 5 分钟服务区面内的区域。如果要为各个中断查找从设施点到中断的整个区域，请使用此选项。</para>
		/// <para><see cref="NestingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Polygon Generation Options")]
		public object NestingType { get; set; } = "RINGS";

		/// <summary>
		/// <para>Line Type</para>
		/// <para>指定基于服务区分析生成的线的类型。对于大型服务区，选择实际线或具有测量值的实际线选项将增加分析所占用的内存量。</para>
		/// <para>无线—不生成线。这是默认设置。</para>
		/// <para>实际线—生成没有测量值的线。</para>
		/// <para>具有测量值的实际线—生成具有测量值的线。基于插入了中间结点的边上每个端点的阻抗值生成测量值。如果对性能要求较高，请勿使用此选项。</para>
		/// <para><see cref="LineTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Line Generation Options")]
		public object LineType { get; set; } = "NO_LINES";

		/// <summary>
		/// <para>Overlap Lines</para>
		/// <para>确定计算服务区线时是否生成重叠线。</para>
		/// <para>选中 - 当设施点具有重合的服务区线时，将包含各个设施点的单独线要素。</para>
		/// <para>未选中 - 每个服务区线最多被包含一次，并将它与最近（阻抗最小）的设施点相关联。</para>
		/// <para><see cref="OverlapEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Line Generation Options")]
		public object Overlap { get; set; } = "true";

		/// <summary>
		/// <para>Split Lines when They Cross a Service Area Break</para>
		/// <para>选中 - 将两个中断之间的每条线分割为两条线，各自位于其对应中断内。如果要按中断对服务区线进行符号化，此选项很有用。否则，应取消选中此选项以达到最佳性能。</para>
		/// <para>未选中 - 在中断的边界处不对线进行分割。这是默认设置。</para>
		/// <para><see cref="SplitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Line Generation Options")]
		public object Split { get; set; } = "true";

		/// <summary>
		/// <para>Exclude Sources from Polygon Generation</para>
		/// <para>指定生成面时要排除的网络源的列表。所有面都将忽略排除的源中遍历元素的几何。</para>
		/// <para>在生成面的过程中，如果需要排除某些会创建低精度的面或者对服务区分析无关紧要的网络源时，此选项十分有用。例如，在街道和铁路的多模式网络上创建行驶时间服务区时，应该在面生成过程中选择排除铁路线，这样才能准确地对车辆可以行驶的区域进行建模。</para>
		/// <para>从服务区多边形中排除网络源并不会阻止这些源受遍历。只会影响该服务区的多边形形状。如果要阻止遍历一个给定的网络源，必须在定义网络数据集时创建适当的限制。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Polygon Generation Options")]
		public object ExcludedSourceName { get; set; }

		/// <summary>
		/// <para>Accumulators</para>
		/// <para>分析过程中要累积的成本属性的列表。这些累积属性仅供参考；求解程序仅使用阻抗属性参数所指定的成本属性来计算路径。</para>
		/// <para>对于每个累积的成本属性，均会向求解程序所输出的路径中添加一个 Total_[阻抗] 属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Accumulators")]
		public object AccumulateAttributeName { get; set; }

		/// <summary>
		/// <para>U-Turn Policy</para>
		/// <para>指定将在交汇点处使用的 U 形转弯策略。允许 U 形转弯表示求解程序可以在交汇点处转向并沿同一街道往回行驶。考虑到交汇点表示街道交叉路口和死角，不同的车辆可以在某些交汇点转弯，而在其他交汇点则不行 - 这取决于交汇点是交叉路口还是死角。为适应此情况，U 形转弯策略参数由连接到交汇点的边数隐性指定，这称为交汇点价。此参数可接受的值如下所列；每个值的后面是根据交汇点价对其含义的描述。</para>
		/// <para>允许—无论在交汇点处有几条连接的边，均允许 U 形转弯。这是默认值。</para>
		/// <para>不允许—在所有交汇点处均禁止 U 形转弯，不管交汇点原子价如何。不过请注意，即使已选择该设置，在网络位置处仍允许 U 形转弯；但是也可以通过设置个别网络位置的 CurbApproach 属性来禁止 U 形转弯。</para>
		/// <para>仅在末路处允许—除仅有一条相邻边的交汇点（死角）外，其他交汇点均禁止 U 形转弯。</para>
		/// <para>仅在末路处和交点处允许—在恰好有两条相邻边相遇的交汇点处禁止 U 形转弯，但是交叉点（三条或三条以上相邻边的交汇点）和死角（仅有一条相邻边的交汇点）处允许。通常，网络在路段中间有多余的交汇点。此选项可防止车辆在这些位置出现 U 形转弯。</para>
		/// <para>如果您需要定义更加精确的 U 形转弯策略，可以考虑在网络成本属性中添加一个通用转弯延迟赋值器，或者如果存在的话，调整其设置，并特别注意反向转弯的配置。还可以设置网络位置的 CurbApproach 属性。</para>
		/// <para><see cref="UturnPolicyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Restrictions")]
		public object UturnPolicy { get; set; } = "ALLOW_UTURNS";

		/// <summary>
		/// <para>Restrictions</para>
		/// <para>分析过程中要应用的限制属性的列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Restrictions")]
		public object RestrictionAttributeName { get; set; }

		/// <summary>
		/// <para>Trim Polygons</para>
		/// <para>选中 - 对包含服务区外围边的面进行修剪，以使其达到外边界的指定距离内。这在网络非常稀疏且不需要服务区覆盖大片不含要素的区域时十分有用。</para>
		/// <para>未选中 - 不修剪面。</para>
		/// <para><see cref="PolygonTrimEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Polygon Generation Options")]
		public object PolygonTrim { get; set; } = "true";

		/// <summary>
		/// <para>Polygon Trim</para>
		/// <para>指定对服务区面进行修剪的距离范围。该参数包括距离的值和单位。默认值是 100 米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Polygon Generation Options")]
		public object PolyTrimValue { get; set; } = "100 Meters";

		/// <summary>
		/// <para>Include Network Source Fields in Lines</para>
		/// <para>选中 - 向服务区线添加 SourceID、SourceOID、FromPosition 和 ToPosition 字段，以保存分析过程中已遍历的基础源要素的信息。此选项可用于将服务区线的结果连接到原始源数据。</para>
		/// <para>未选中 - 不向服务区线添加源字段（SourceID、SourceOID、FromPosition 和 ToPosition）。</para>
		/// <para><see cref="LinesSourceFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Line Generation Options")]
		public object LinesSourceFields { get; set; } = "true";

		/// <summary>
		/// <para>Use Hierarchy in Analysis</para>
		/// <para>选中 - 将使用等级属性进行分析。使用等级的结果是，求解程序更偏好高等级的边而不是低等级的边。分等级求解的速度更快，并且可用于模拟驾驶员在可能的情况下选择在高速公路而非地方道路上行驶（即使行程可能更远）的偏好。只有输入网络数据集具有等级属性时，此选项才处于活动状态。</para>
		/// <para>未选中 - 将不会使用等级属性进行分析。如果不使用等级，则结果为沿网络数据集的所有边测量的服务区（无论等级级别为何）。</para>
		/// <para>如果未在用于执行分析的网络数据集中定义等级属性，该参数将处于非活动状态。</para>
		/// <para><see cref="HierarchyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Hierarchy")]
		public object Hierarchy { get; set; } = "false";

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>离开或到达服务区图层的设施点的时间。将此值理解为离开还是到达时间，取决于行驶方向是离开还是朝向设施点。</para>
		/// <para>如果将行驶自/至设施点设置为 TRAVEL_FROM，此值表示离开时间。</para>
		/// <para>如果将行驶自/至设施点设置为 TRAVEL_TO，此值表示到达时间。</para>
		/// <para>如果您已经选择了基于流量的阻抗属性，将会根据特定的某天某时的动态交通状况来生成解决方案。日期和时间可被指定为 5/14/2012 10:30 AM。</para>
		/// <para>可使用以下日期来指定一周中的每一天，而无需使用特定的日期：</para>
		/// <para>今天 - 12/30/1899</para>
		/// <para>星期日 - 12/31/1899</para>
		/// <para>星期一 - 1/1/1900</para>
		/// <para>星期二 - 1/2/1900</para>
		/// <para>星期三 - 1/3/1900</para>
		/// <para>星期四 - 1/4/1900</para>
		/// <para>星期五 - 1/5/1900</para>
		/// <para>星期六 - 1/6/1900</para>
		/// <para>重复解决相同的分析问题，但使用不同的“时间”参数值，这样您就会看到设施点的到达时间随时间的变化。例如，消防站周围的 5 分钟服务区在大清早时可能变得大一点，而在早高峰期消失，上午晚些时候服务区又扩大，并在一天中都保持这样。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object TimeOfDay { get; set; }

		/// <summary>
		/// <para>Network Analyst Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object OutputLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeServiceAreaLayer SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Travel From or To Facility</para>
		/// </summary>
		public enum TravelFromToEnum 
		{
			/// <summary>
			/// <para>朝向设施点—在接近设施点的方向上创建服务区。</para>
			/// </summary>
			[GPValue("TRAVEL_TO")]
			[Description("朝向设施点")]
			Toward_Facilities,

			/// <summary>
			/// <para>远离设施点—在远离设施点的方向上创建服务区。</para>
			/// </summary>
			[GPValue("TRAVEL_FROM")]
			[Description("远离设施点")]
			Away_from_Facilities,

		}

		/// <summary>
		/// <para>Polygon Type</para>
		/// </summary>
		public enum PolygonTypeEnum 
		{
			/// <summary>
			/// <para>简单面—创建生成速度快并且相当精确的概化面，边缘除外。这是默认设置。</para>
			/// </summary>
			[GPValue("SIMPLE_POLYS")]
			[Description("简单面")]
			Simple_polygons,

			/// <summary>
			/// <para>详细面—创建详细面，用于对服务区线进行精确建模并且可包含未到达的岛状区域。这种面比概化面的生成速度慢。</para>
			/// </summary>
			[GPValue("DETAILED_POLYS")]
			[Description("详细面")]
			Detailed_polygons,

			/// <summary>
			/// <para>无面—在仅需要服务区线的情况下，将关闭“面生成”选项。</para>
			/// </summary>
			[GPValue("NO_POLYS")]
			[Description("无面")]
			No_polygons,

		}

		/// <summary>
		/// <para>Merge Polygons with Similar Ranges</para>
		/// </summary>
		public enum MergeEnum 
		{
			/// <summary>
			/// <para>重叠—为各个设施点创建单独的面。这些面可以相互叠置。</para>
			/// </summary>
			[GPValue("NO_MERGE")]
			[Description("重叠")]
			Overlap,

			/// <summary>
			/// <para>斯普利特—为各个设施点创建最接近的单独面。这些面不会相互叠置。</para>
			/// </summary>
			[GPValue("NO_OVERLAP")]
			[Description("斯普利特")]
			Split,

			/// <summary>
			/// <para>融合— 连接具有相同中断值的多个设施点的面。</para>
			/// </summary>
			[GPValue("MERGE")]
			[Description("融合")]
			Dissolve,

		}

		/// <summary>
		/// <para>Polygon Nest Option</para>
		/// </summary>
		public enum NestingTypeEnum 
		{
			/// <summary>
			/// <para>环—不包括较小中断的区域。这将在连续的中断之间创建面。如果要查找从一个中断到另一个中断的区域，请使用此选项。</para>
			/// </summary>
			[GPValue("RINGS")]
			[Description("环")]
			Rings,

			/// <summary>
			/// <para>圆盘— 在设施点与中断之间创建面。例如，如果创建 5 分钟和 10 分钟服务区，则 10 分钟服务区面将包含 5 分钟服务区面内的区域。如果要为各个中断查找从设施点到中断的整个区域，请使用此选项。</para>
			/// </summary>
			[GPValue("DISKS")]
			[Description("圆盘")]
			Disks,

		}

		/// <summary>
		/// <para>Line Type</para>
		/// </summary>
		public enum LineTypeEnum 
		{
			/// <summary>
			/// <para>无线—不生成线。这是默认设置。</para>
			/// </summary>
			[GPValue("NO_LINES")]
			[Description("无线")]
			No_lines,

			/// <summary>
			/// <para>实际线—生成没有测量值的线。</para>
			/// </summary>
			[GPValue("TRUE_LINES")]
			[Description("实际线")]
			True_lines,

			/// <summary>
			/// <para>具有测量值的实际线—生成具有测量值的线。基于插入了中间结点的边上每个端点的阻抗值生成测量值。如果对性能要求较高，请勿使用此选项。</para>
			/// </summary>
			[GPValue("TRUE_LINES_WITH_MEASURES")]
			[Description("具有测量值的实际线")]
			True_lines_with_measures,

		}

		/// <summary>
		/// <para>Overlap Lines</para>
		/// </summary>
		public enum OverlapEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("OVERLAP")]
			OVERLAP,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NON_OVERLAP")]
			NON_OVERLAP,

		}

		/// <summary>
		/// <para>Split Lines when They Cross a Service Area Break</para>
		/// </summary>
		public enum SplitEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SPLIT")]
			SPLIT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SPLIT")]
			NO_SPLIT,

		}

		/// <summary>
		/// <para>U-Turn Policy</para>
		/// </summary>
		public enum UturnPolicyEnum 
		{
			/// <summary>
			/// <para>允许—无论在交汇点处有几条连接的边，均允许 U 形转弯。这是默认值。</para>
			/// </summary>
			[GPValue("ALLOW_UTURNS")]
			[Description("允许")]
			Allowed,

			/// <summary>
			/// <para>不允许—在所有交汇点处均禁止 U 形转弯，不管交汇点原子价如何。不过请注意，即使已选择该设置，在网络位置处仍允许 U 形转弯；但是也可以通过设置个别网络位置的 CurbApproach 属性来禁止 U 形转弯。</para>
			/// </summary>
			[GPValue("NO_UTURNS")]
			[Description("不允许")]
			Not_allowed,

			/// <summary>
			/// <para>仅在末路处允许—除仅有一条相邻边的交汇点（死角）外，其他交汇点均禁止 U 形转弯。</para>
			/// </summary>
			[GPValue("ALLOW_DEAD_ENDS_ONLY")]
			[Description("仅在末路处允许")]
			Allowed_at_dead_ends_only,

			/// <summary>
			/// <para>仅在末路处和交点处允许—在恰好有两条相邻边相遇的交汇点处禁止 U 形转弯，但是交叉点（三条或三条以上相邻边的交汇点）和死角（仅有一条相邻边的交汇点）处允许。通常，网络在路段中间有多余的交汇点。此选项可防止车辆在这些位置出现 U 形转弯。</para>
			/// </summary>
			[GPValue("ALLOW_DEAD_ENDS_AND_INTERSECTIONS_ONLY")]
			[Description("仅在末路处和交点处允许")]
			Allowed_at_dead_ends_and_intersections_only,

		}

		/// <summary>
		/// <para>Trim Polygons</para>
		/// </summary>
		public enum PolygonTrimEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("TRIM_POLYS")]
			TRIM_POLYS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_TRIM_POLYS")]
			NO_TRIM_POLYS,

		}

		/// <summary>
		/// <para>Include Network Source Fields in Lines</para>
		/// </summary>
		public enum LinesSourceFieldsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("LINES_SOURCE_FIELDS")]
			LINES_SOURCE_FIELDS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_LINES_SOURCE_FIELDS")]
			NO_LINES_SOURCE_FIELDS,

		}

		/// <summary>
		/// <para>Use Hierarchy in Analysis</para>
		/// </summary>
		public enum HierarchyEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_HIERARCHY")]
			USE_HIERARCHY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_HIERARCHY")]
			NO_HIERARCHY,

		}

#endregion
	}
}
