using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.UtilityNetworkTools
{
	/// <summary>
	/// <para>Trace</para>
	/// <para>追踪</para>
	/// <para>可根据指定起点的连通性或可遍历性返回公共设施网络的网络要素。</para>
	/// </summary>
	public class Trace : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>将运行追踪的公共设施网络。 使用企业级地理数据库时，输入公共设施网络必须来自要素服务；不支持来自数据库连接的公共设施网络。</para>
		/// </param>
		public Trace(object InUtilityNetwork)
		{
			this.InUtilityNetwork = InUtilityNetwork;
		}

		/// <summary>
		/// <para>Tool Display Name : 追踪</para>
		/// </summary>
		public override string DisplayName() => "追踪";

		/// <summary>
		/// <para>Tool Name : 追踪</para>
		/// </summary>
		public override string ToolName() => "追踪";

		/// <summary>
		/// <para>Tool Excute Name : un.Trace</para>
		/// </summary>
		public override string ExcuteName() => "un.Trace";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise() => "un";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, TraceType!, StartingPoints!, Barriers!, DomainNetwork!, Tier!, TargetTier!, SubnetworkName!, ShortestPathNetworkAttributeName!, IncludeContainers!, IncludeContent!, IncludeStructures!, IncludeBarriers!, ValidateConsistency!, ConditionBarriers!, FunctionBarriers!, TraversabilityScope!, FilterBarriers!, FilterFunctionBarriers!, FilterScope!, FilterBitsetNetworkAttributeName!, FilterNearest!, NearestCount!, NearestCostNetworkAttribute!, NearestCategories!, NearestAssets!, Functions!, Propagators!, OutputAssettypes!, OutputConditions!, OutUtilityNetwork!, IncludeIsolatedFeatures!, IgnoreBarriersAtStartingPoints!, IncludeUpToFirstSpatialContainer!, ResultTypes!, SelectionType!, ClearAllPreviousTraceResults!, TraceName!, AggregatedPoints!, AggregatedLines!, AggregatedPolygons!, AllowIndeterminateFlow!, ValidateLocatability!, UseTraceConfig!, TraceConfigName!, OutJsonFile!, RunAsync! };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>将运行追踪的公共设施网络。 使用企业级地理数据库时，输入公共设施网络必须来自要素服务；不支持来自数据库连接的公共设施网络。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Trace Type</para>
		/// <para>指定要执行的追踪类型。</para>
		/// <para>已连接—将使用从一个或多个起点开始并沿着已连接要素向外跨越的已连接追踪。 这是默认设置。</para>
		/// <para>子网—将使用子网追踪，其从一个或多个起点开始向外跨越，目的是涵盖子网的范围。</para>
		/// <para>子网控制器—将使用能够定位与子网关联的子网控制器上的源和汇的子网控制器追踪。</para>
		/// <para>上游—将使用能够发现网络中某位置上游的要素的上溯追踪。</para>
		/// <para>下游—将使用能够发现网络中某位置下游的要素的下溯追踪。</para>
		/// <para>循环—循环是流向不明确的网络区域。 将使用能够从基于连通性的起点向外跨越的循环追踪。</para>
		/// <para>最短路径—将使用能够识别两个起点之间的最短路径的最短路径追踪。</para>
		/// <para>孤立—将使用能够发现孤立网络区域的要素的孤立追踪。</para>
		/// <para><see cref="TraceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TraceType { get; set; } = "CONNECTED";

		/// <summary>
		/// <para>Starting Points</para>
		/// <para>使用追踪位置窗格中的起点工具创建的要素图层，或包含一个或多个表示追踪起点的记录的表或要素类。 该要素类或表必须包含 FEATUREGLOBALID 字段，用于存储来自关联网络要素的信息。 默认情况下，会使用工程默认地理数据库中的 UN_Temp_Starting_Points 要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? StartingPoints { get; set; } = "UN_Temp_Starting_Points";

		/// <summary>
		/// <para>Barriers</para>
		/// <para>使用追踪位置窗格中的障碍工具创建的要素图层，或包含一个或多个表示防止追踪遍历超出此点的障碍的记录的表或要素类。 该要素类或表必须包含 FEATUREGLOBALID 字段，用于存储来自关联网络要素的信息。 默认情况下，会使用工程默认地理数据库中的 UN_Temp_Barriers 要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? Barriers { get; set; } = "UN_Temp_Barriers";

		/// <summary>
		/// <para>Domain Network</para>
		/// <para>将运行追踪的域网络的名称。 运行子网、子网控制器、上溯和下溯追踪类型时，需要此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? DomainNetwork { get; set; }

		/// <summary>
		/// <para>Tier</para>
		/// <para>要开始追踪的层的名称。 运行子网、子网控制器、上溯和下溯追踪类型时，需要此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Tier { get; set; }

		/// <summary>
		/// <para>Target Tier</para>
		/// <para>输入层流向的目标层名称。 如果上溯和下溯追踪的此参数丢失，当到达起始子网边界时，上述追踪将停止。 该参数可以使此类追踪在层级结构中继续向上或向下延伸。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? TargetTier { get; set; }

		/// <summary>
		/// <para>Subnetwork Name</para>
		/// <para>将运行追踪的子网的名称。 运行子网追踪类型时可以使用此参数。 如果指定了子网名称，则不需要起点参数（Python 中的 starting_points）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? SubnetworkName { get; set; }

		/// <summary>
		/// <para>Shortest Path Network Attribute Name</para>
		/// <para>将用于计算最短路径的网络属性。 运行最短路径追踪类型时，使用数字网络属性（例如形状长度）计算最短路径。 基于成本和距离的路径都可以进行计算。 运行最短路径追踪时，需要此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ShortestPathNetworkAttributeName { get; set; }

		/// <summary>
		/// <para>Include Containers</para>
		/// <para>指定追踪结果中是否包含容器要素。</para>
		/// <para>选中 - 追踪结果中将包含容器要素。 这将启用最多包含第一个空间容器选项。</para>
		/// <para>未选中 - 追踪结果中将不包含容器要素。 这是默认设置。</para>
		/// <para><see cref="IncludeContainersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeContainers { get; set; } = "false";

		/// <summary>
		/// <para>Include Content</para>
		/// <para>指定追踪是否在结果中返回容器的内容。</para>
		/// <para>选中 - 追踪结果将包含容器要素中的内容。</para>
		/// <para>未选中 - 追踪结果将不包含容器要素中的内容。 这是默认设置。</para>
		/// <para><see cref="IncludeContentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeContent { get; set; } = "false";

		/// <summary>
		/// <para>Include Structures</para>
		/// <para>指定追踪结果中是否包含结构要素和对象。</para>
		/// <para>选中 - 追踪结果中将包含结构要素和对象。</para>
		/// <para>未选中 - 追踪结果中将不包含结构要素和对象。 这是默认设置。</para>
		/// <para><see cref="IncludeStructuresEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeStructures { get; set; } = "false";

		/// <summary>
		/// <para>Include Barrier Features</para>
		/// <para>指定追踪结果中是否包含可遍历性障碍要素。 即使已在子网定义中进行了预设，可遍历性障碍仍可选。 此参数不适用于具备终端的设备要素。</para>
		/// <para>选中 - 追踪结果中将包含可遍历性障碍要素。 这是默认设置。</para>
		/// <para>未选中 - 追踪结果中将不包含可遍历性障碍要素。</para>
		/// <para><see cref="IncludeBarriersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeBarriers { get; set; } = "true";

		/// <summary>
		/// <para>Validate Consistency</para>
		/// <para>指定如果在任何遍历的要素中遇到脏区是否返回错误。 这是保证追踪通过网络中状态一致要素的唯一方法。 要移除脏区，请验证网络拓扑。</para>
		/// <para>选中 - 如果在任何遍历的要素中遇到脏区，追踪将返回错误。 这是默认设置。</para>
		/// <para>未选中 - 无论是否在遍历的要素中遇到脏区，追踪都将返回结果。</para>
		/// <para><see cref="ValidateConsistencyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ValidateConsistency { get; set; } = "true";

		/// <summary>
		/// <para>Condition Barriers</para>
		/// <para>基于与网络属性的比较或对类别字符串的检查，对要素设置可遍历性障碍条件。 条件障碍使用网络属性、运算符和类型以及属性值。 例如，当要素的 Device Status 属性等于 Open 的特定值时，将停止追踪。 当要素满足此条件时，追踪将停止。 如果您要使用多个属性，可使用 Combine Using 参数来定义 And 或 Or 条件。</para>
		/// <para>条件障碍组件如下：</para>
		/// <para>名称 - 按系统中定义的任何网络属性进行过滤。</para>
		/// <para>运算符 - 从大量运算符中进行选择。</para>
		/// <para>类型 - 从名称参数中指定的值中选择特定值或网络属性。</para>
		/// <para>值 - 提供会基于运算符值导致终止的输入属性类型的特定值。</para>
		/// <para>组合方法 - 如果要添加多个属性，则设置此值。您可以使用 And 或 Or 条件来对它们进行组合。</para>
		/// <para>条件障碍运算符值选项如下：</para>
		/// <para>Is equal to - 该属性等于该值。</para>
		/// <para>Does not equal - 该属性不等于该值。</para>
		/// <para>Is greater than - 该属性大于该值。</para>
		/// <para>Is greater than or equal to - 该属性大于或等于该值。</para>
		/// <para>Is less than - 该属性小于该值。</para>
		/// <para>Is less than or equal to - 该属性小于或等于该值。</para>
		/// <para>Includes the values - 值中的所有位都存在于属性中的“按位与”运算（按位与 == 值）。</para>
		/// <para>Does not include the values - 值中的所有位并非都存在于属性中的“按位与”运算（按位与 != 值）。</para>
		/// <para>Includes any - 值中至少有一位存在于属性中的“按位与”运算（按位与 == True）。</para>
		/// <para>Does not include any - 值中的所有位均未存在于属性中的“按位与”运算（按位与 == False）。</para>
		/// <para>条件障碍类型值选项如下：</para>
		/// <para>特定值 - 按特定值过滤。</para>
		/// <para>网络属性 - 按网络属性过滤。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Traversability")]
		public object? ConditionBarriers { get; set; }

		/// <summary>
		/// <para>Function Barriers</para>
		/// <para>基于函数对要素设置可遍历性障碍。 函数障碍可用于执行以下操作：限制追踪距离起点的行程或设置停止追踪的最大值。 例如，所经过的每条线的长度和为目前经过的总距离。 当经过的总长度达到指定值时，追踪将停止。</para>
		/// <para>函数障碍组件如下：</para>
		/// <para>函数 - 从大量计算函数中进行选择。</para>
		/// <para>属性 - 按系统中定义的任何网络属性进行过滤。</para>
		/// <para>运算符 - 从大量运算符中进行选择。</para>
		/// <para>值 - 提供将导致终止的输入属性类型（若发现）的特定值。</para>
		/// <para>使用局部值 - 计算每个方向的值，而不是整体全局值，例如计算 Shape length 总和的函数障碍，其中，如果值大于或等于 4，则追踪终止。 在全局情况下，遍历两条值为 2 的边之后，Shape length 总和即已达到 4，因此追踪会停止。 如果使用本地值，每条路径上的本地值会变化，且追踪将继续。</para>
		/// <para>选中 - 将使用局部值。</para>
		/// <para>未选中 - 将使用全局值。 这是默认设置。</para>
		/// <para>函数障碍函数值选项如下：</para>
		/// <para>Minimum - 输入值的最小值。</para>
		/// <para>Maximum - 输入值的最大值。</para>
		/// <para>Add - 输入值的总和。</para>
		/// <para>Average - 输入值的平均值。</para>
		/// <para>Count - 要素数目。</para>
		/// <para>Subtract - 输入值之间的差值。子网控制器和循环追踪类型不支持剪除功能。</para>
		/// <para>例如，起点要素的值为 20。 下一个要素的值为 30。 如果使用 Minimum 函数，则结果为 20；使用 Maximum 函数，结果为 30；使用 Add 函数，结果为 50；使用 Average 函数，结果为 25；使用 Count 函数，结果为 2；使用 Subtract 函数，结果为 -10。</para>
		/// <para>函数障碍运算符值选项如下：</para>
		/// <para>Is equal to - 该属性等于该值。</para>
		/// <para>Does not equal - 该属性不等于该值。</para>
		/// <para>Is greater than - 该属性大于该值。</para>
		/// <para>Is greater than or equal to - 该属性大于或等于该值。</para>
		/// <para>Is less than - 该属性小于该值。</para>
		/// <para>Is less than or equal to - 该属性小于或等于该值。</para>
		/// <para>Includes the values - 值中的所有位都存在于属性中的“按位与”运算（按位与 == 值）。</para>
		/// <para>Does not include the values - 值中的所有位并非都存在于属性中的“按位与”运算（按位与 != 值）。</para>
		/// <para>Includes any - 值中至少有一位存在于属性中的“按位与”运算（按位与 == True）。</para>
		/// <para>Does not include any - 值中的所有位均未存在于属性中的“按位与”运算（按位与 == False）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Traversability")]
		public object? FunctionBarriers { get; set; }

		/// <summary>
		/// <para>Apply Traversability To</para>
		/// <para>指定将应用的可遍历性类型。 可遍历性范围用于确定是否在交汇点和/或边处应用可遍历性。 例如，如果定义了用于停止追踪的条件障碍，其中 Device Status 等于 Open 并将遍历范围仅设置为边，则即使追踪遇到开路设备，追踪也不会停止，因为 Device Status 仅适用于交汇点。 换言之，此参数会向追踪指出是否要忽略交汇点、边或这两者。</para>
		/// <para>交汇点和边—可遍历性将同时应用于交汇点和边。 这是默认设置。</para>
		/// <para>仅交汇点—可遍历性将仅应用于交汇点。</para>
		/// <para>仅边—可遍历性将仅应用于边。</para>
		/// <para><see cref="TraversabilityScopeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Traversability")]
		public object? TraversabilityScope { get; set; } = "BOTH_JUNCTIONS_AND_EDGES";

		/// <summary>
		/// <para>Filter Barriers</para>
		/// <para>用于设置针对特定类别或网络属性的追踪停止时间。 例如，针对生命周期状态属性等于特定值的要素，追踪停止。 此参数用于根据系统中定义的网络属性值设置终止符。 如果您要使用多个属性，可使用组合方法选项来定义 And 或 Or 条件。</para>
		/// <para>过滤器障碍组件如下：</para>
		/// <para>名称 - 按类别或系统中定义的任何网络属性进行过滤。</para>
		/// <para>运算符 - 从大量运算符中进行选择。</para>
		/// <para>类型 - 从名称参数中指定的值中选择特定值或网络属性。</para>
		/// <para>值 - 提供会基于运算符值导致终止的输入属性类型的特定值。</para>
		/// <para>组合方法 - 如果要添加多个属性，则设置此值。您可以使用 And 或 Or 条件来对它们进行组合。</para>
		/// <para>过滤器障碍运算符值选项如下：</para>
		/// <para>Is equal to - 该属性等于该值。</para>
		/// <para>Does not equal - 该属性不等于该值。</para>
		/// <para>Is greater than - 该属性大于该值。</para>
		/// <para>Is greater than or equal to - 该属性大于或等于该值。</para>
		/// <para>Is less than - 该属性小于该值。</para>
		/// <para>Is less than or equal to - 该属性小于或等于该值。</para>
		/// <para>Includes the values - 值中的所有位都存在于属性中的“按位与”运算（按位与 == 值）。</para>
		/// <para>Does not include the values - 值中的所有位并非都存在于属性中的“按位与”运算（按位与 != 值）。</para>
		/// <para>Includes any - 值中至少有一位存在于属性中的“按位与”运算（按位与 == True）。</para>
		/// <para>Does not include any - 值中的所有位均未存在于属性中的“按位与”运算（按位与 == False）。</para>
		/// <para>过滤器障碍类型值选项如下：</para>
		/// <para>特定值 - 按特定值过滤。</para>
		/// <para>网络属性 - 按网络属性过滤。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Filters")]
		public object? FilterBarriers { get; set; }

		/// <summary>
		/// <para>Filter Function Barriers</para>
		/// <para>用于过滤特定类别的追踪结果。</para>
		/// <para>过滤器函数障碍组件如下：</para>
		/// <para>函数 - 从大量计算函数中进行选择。</para>
		/// <para>属性 - 按系统中定义的任何网络属性进行过滤。</para>
		/// <para>运算符 - 从大量运算符中进行选择。</para>
		/// <para>值 - 提供将导致终止的输入属性类型（若发现）的特定值。</para>
		/// <para>使用局部值 - 计算每个方向的值，而不是整体全局值。 例如计算形状长度总和的函数障碍，其中，如果值大于或等于 4，则追踪终止。 在全局情况下，遍历两条值为 2 的边之后，形状长度总和即已达到 4，因此追踪会停止。 如果使用本地值，每条路径上的本地值会变化，否则追踪将继续。</para>
		/// <para>选中 - 将使用局部值。</para>
		/// <para>未选中 - 将使用全局值。 这是默认设置。</para>
		/// <para>过滤器函数障碍函数值选项如下：</para>
		/// <para>最小值 - 输入值的最小值。</para>
		/// <para>最大值 - 输入值的最大值。</para>
		/// <para>加 - 各值的总和。</para>
		/// <para>平均值 - 输入值的平均值。</para>
		/// <para>计数 - 要素数。</para>
		/// <para>减 - 各值之间的差值。 子网控制器和循环追踪类型不支持减函数。</para>
		/// <para>例如，起点要素的值为 20。 下一个要素的值为 30。 如果使用 Minimum 函数，则结果为 20。 使用 Maximum 函数，结果为 30；使用 Add 函数，结果为 50；使用 Average 函数，结果为 25；使用 Count 函数，结果为 2；使用 Subtract 函数，结果为 -10。</para>
		/// <para>过滤器函数障碍运算符值选项如下：</para>
		/// <para>等于 - 该属性等于该值。</para>
		/// <para>不等于 - 该属性不等于该值。</para>
		/// <para>大于 - 该属性大于该值。</para>
		/// <para>大于或等于 - 该属性大于或等于该值。</para>
		/// <para>小于 - 该属性小于该值。</para>
		/// <para>小于或等于 - 该属性小于或等于该值。</para>
		/// <para>Includes the values - 值中的所有位都存在于属性中的“按位与”运算（按位与 == 值）。</para>
		/// <para>Does not include the values - 值中的所有位并非都存在于属性中的“按位与”运算（按位与 != 值）。</para>
		/// <para>Includes any - 值中至少有一位存在于属性中的“按位与”运算（按位与 == True）。</para>
		/// <para>Does not include any - 值中的所有位均未存在于属性中的“按位与”运算（按位与 == False）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Filters")]
		public object? FilterFunctionBarriers { get; set; }

		/// <summary>
		/// <para>Apply Filter To</para>
		/// <para>指定是否在交汇点、边或这两处应用特定类别的过滤器。 例如，如果定义了用于停止追踪的过滤器障碍，其中 Device Status 等于 Open 并将遍历范围仅设置为边，则即使追踪遇到开路设备，追踪也不会停止，因为 Device Status 仅适用于交汇点。 换言之，此参数会向追踪指出是否要忽略交汇点、边或这两者。</para>
		/// <para>交汇点和边 - 过滤器将同时应用于交汇点和边。 这是默认设置。</para>
		/// <para>仅交汇点 - 过滤器将仅应用于交汇点。</para>
		/// <para>仅边 - 过滤器将仅应用于边。</para>
		/// <para><see cref="FilterScopeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Filters")]
		public object? FilterScope { get; set; } = "BOTH_JUNCTIONS_AND_EDGES";

		/// <summary>
		/// <para>Filter by bitset network attribute</para>
		/// <para>将用于按 bitset 过滤的网络属性的名称。 此参数仅适用于上溯、下溯和循环追踪类型。 此参数可用于在追踪过程中添加特殊逻辑，以便追踪能够更好地反映真实世界的场景。 例如，对于循环追踪而言，Phases current 网络属性可以确定该循环是否为实际的电气循环（相同的相在循环 A 中各处均有电流通过），并且追踪结果只返回实际的电气循环。 上溯追踪的示例如下；如果追踪配电网络时指定 Phases current 网络属性，则追踪结果将只包含在网络属性中指定的有效路径，而不是所有路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Filters")]
		public object? FilterBitsetNetworkAttributeName { get; set; }

		/// <summary>
		/// <para>Filter by nearest</para>
		/// <para>指定是否使用 k-最近邻算法在给定距离内返回一些特定类型的要素。 使用此参数时，您可以指定计数、成本以及类别和/或资产类型的集合。</para>
		/// <para>选中 - 将使用 k-最近邻算法来返回计数、成本网络属性、最近类别或最近资产组/类型参数中指定的一定数量的要素。</para>
		/// <para>未选中 - k 最近邻算法不会用于过滤结果。 这是默认设置。</para>
		/// <para><see cref="FilterNearestEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Filters")]
		public object? FilterNearest { get; set; } = "false";

		/// <summary>
		/// <para>Count</para>
		/// <para>按最近过滤为选中状态时要返回的要素数量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Filters")]
		public object? NearestCount { get; set; }

		/// <summary>
		/// <para>Cost Network Attribute</para>
		/// <para>当按最近过滤为选中状态时，将用于计算接近度、成本或距离的数字网络属性（例如形状长度）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Filters")]
		public object? NearestCostNetworkAttribute { get; set; }

		/// <summary>
		/// <para>Nearest Categories</para>
		/// <para>当按最近过滤处于选中状态时，将返回的类别（例如保护类别）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Filters")]
		public object? NearestCategories { get; set; }

		/// <summary>
		/// <para>Nearest Asset Groups/Types</para>
		/// <para>当按最近过滤处于选中状态时，将返回的资产组和资产类型（例如，ElectricDistributionDevice/Transformer/Step Down）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Filters")]
		public object? NearestAssets { get; set; }

		/// <summary>
		/// <para>Functions</para>
		/// <para>将应用于追踪结果的计算函数。</para>
		/// <para>函数组件如下：</para>
		/// <para>函数 - 从大量计算函数中进行选择。</para>
		/// <para>属性 - 按系统中定义的任何网络属性进行过滤。</para>
		/// <para>过滤器名称 - 按属性名称过滤函数结果。</para>
		/// <para>过滤器运算符 - 从大量运算符中进行选择。</para>
		/// <para>过滤器类型 - 从大量过滤类型中进行选择。</para>
		/// <para>过滤器值 - 提供输入过滤属性的特定值。</para>
		/// <para>函数函数值选项如下：</para>
		/// <para>平均值 - 输入值的平均值。</para>
		/// <para>计数 - 要素数。</para>
		/// <para>最大值 - 输入值的最大值。</para>
		/// <para>最小值 - 输入值的最小值。</para>
		/// <para>加 - 输入值的总和。</para>
		/// <para>减 - 输入值之间的差值。子网控制器和循环追踪类型不支持减法函数。</para>
		/// <para>例如，起点要素的值为 20。 下一个要素的值为 30。 如果使用 Minimum 函数，则结果为 20。 使用 Maximum 函数，结果为 30；使用 Add 函数，结果为 50；使用 Average 函数，结果为 25；使用 Count 函数，结果为 2；使用 Subtract 函数，结果为 -10。</para>
		/// <para>函数过滤器运算符值选项如下：</para>
		/// <para>等于 - 该属性等于该值。</para>
		/// <para>不等于 - 该属性不等于该值。</para>
		/// <para>大于 - 该属性大于该值。</para>
		/// <para>大于或等于 - 该属性大于或等于该值。</para>
		/// <para>小于 - 该属性小于该值。</para>
		/// <para>小于或等于 - 该属性小于或等于该值。</para>
		/// <para>Includes the values - 值中的所有位都存在于属性中的“按位与”运算（按位与 == 值）。</para>
		/// <para>Does not include the values - 值中的所有位并非都存在于属性中的“按位与”运算（按位与 != 值）。</para>
		/// <para>Includes any - 值中至少有一位存在于属性中的“按位与”运算（按位与 == True）。</para>
		/// <para>Does not include any - 值中的所有位均未存在于属性中的“按位与”运算（按位与 == False）。</para>
		/// <para>函数过滤器类型值选项如下：</para>
		/// <para>特定值 - 按特定值过滤。</para>
		/// <para>网络属性 - 按网络属性过滤。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Functions")]
		public object? Functions { get; set; }

		/// <summary>
		/// <para>Propagators</para>
		/// <para>指定要传播的网络属性以及传播将在追踪过程中的发生方式。 传播的类属性表示子网控制器上已传播至子网余下要素的关键值。 例如，在配电模型中，您可传播相位值。</para>
		/// <para>传播程序组件如下：</para>
		/// <para>Attribute - 选择按系统中定义的任何网络属性进行过滤。</para>
		/// <para>Substitution Attribute - 使用替换值而不是 bitset 网络属性值。 替换是基于正在传递的网络属性中的位数进行编码的。 替换是指同相位的某个位到另一个位的映射。 例如对于相 AC 而言，可通过一个替换将位 A 映射到 B，将位 C 映射到 null。 在该示例中，1010（相 AC）的替换是 0000-0010-0000-0000 (512)。 该替换将捕捉映射，以通知您相 A 被映射到 B，且相 C 被映射到 null 而非相反（即相 A 未映射到 null，且相 C 未映射到 B）。</para>
		/// <para>Function - 从大量计算函数中进行选择。</para>
		/// <para>Operator - 从大量运算符中进行选择。</para>
		/// <para>Value - 提供会基于运算符值导致终止的输入属性类型的特定值。</para>
		/// <para>传播程序 function 值选项如下：</para>
		/// <para>PROPAGATED_BITWISE_AND—比较一个要素与下一个要素的值。</para>
		/// <para>PROPAGATED_MIN—获取最小值。</para>
		/// <para>PROPAGATED_MAX—获取最大值。</para>
		/// <para>传播程序 operator 值选项如下：</para>
		/// <para>IS_EQUAL_TO—属性与值相等。</para>
		/// <para>DOES_NOT_EQUAL—属性与值不等。</para>
		/// <para>IS_GREATER_THAN—属性大于值。</para>
		/// <para>IS_GREATER_THAN_OR_EQUAL_TO—属性大于或等于值。</para>
		/// <para>IS_LESS_THAN—属性小于值。</para>
		/// <para>IS_LESS_THAN_OR_EQUAL_TO—属性小于或等于值。</para>
		/// <para>INCLUDES_THE_VALUES—值中的所有位都存在于属性中的“按位与”运算（按位与 == 值）。</para>
		/// <para>DOES_NOT_INCLUDE_THE_VALUES—并非值中的所有位都存在于属性中的“按位与”运算（按位与 != 值）。</para>
		/// <para>INCLUDES_ANY—值中至少有一位存在于属性中的“按位与”运算（按位与 == True）。</para>
		/// <para>DOES_NOT_INCLUDE_ANY—值中的所有位均未存在于属性中的“按位与”运算（按位与 == False）。</para>
		/// <para>此参数仅可用于 Python。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Propagators")]
		public object? Propagators { get; set; }

		/// <summary>
		/// <para>Output Asset Types</para>
		/// <para>过滤要包含在结果中的输出资产类型 - 例如，仅返回架空变压器。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Output")]
		public object? OutputAssettypes { get; set; }

		/// <summary>
		/// <para>Output Conditions</para>
		/// <para>按网络属性或类别返回的要素类型。 例如，如果将追踪配置为“过滤掉除水龙头要素外的所有要素”，那么未分配水龙头类别的追踪要素均不会包含在结果中。 任何追踪的要素都会返回到结果选择集中。</para>
		/// <para>输出条件组件如下：</para>
		/// <para>名称 - 按系统中定义的任何网络属性进行过滤。</para>
		/// <para>运算符 - 从大量运算符中进行选择。</para>
		/// <para>类型 - 从名称参数中指定的值中选择特定值或网络属性。</para>
		/// <para>值 - 提供会基于运算符值导致终止的输入属性类型的特定值。</para>
		/// <para>组合方法 - 如果要添加多个属性，则设置此值。您可以使用 And 或 Or 条件来对它们进行组合。</para>
		/// <para>输出条件运算符值选项如下：</para>
		/// <para>等于 - 该属性等于该值。</para>
		/// <para>不等于 - 该属性不等于该值。</para>
		/// <para>大于 - 该属性大于该值。</para>
		/// <para>大于或等于 - 该属性大于或等于该值。</para>
		/// <para>小于 - 该属性小于该值。</para>
		/// <para>小于或等于 - 该属性小于或等于该值。</para>
		/// <para>Includes the values - 值中的所有位都存在于属性中的“按位与”运算（按位与 == 值）。</para>
		/// <para>Does not include the values - 值中的所有位并非都存在于属性中的“按位与”运算（按位与 != 值）。</para>
		/// <para>Includes any - 值中至少有一位存在于属性中的“按位与”运算（按位与 == True）。</para>
		/// <para>Does not include any - 值中的所有位均未存在于属性中的“按位与”运算（按位与 == False）。</para>
		/// <para>输出条件类型值选项如下：</para>
		/// <para>特定值 - 按特定值过滤。</para>
		/// <para>网络属性 - 按网络属性过滤。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Output")]
		public object? OutputConditions { get; set; }

		/// <summary>
		/// <para>Output Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object? OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Include Isolated Features</para>
		/// <para>指定追踪结果中是否包含孤立要素。 此参数仅在运行孤立追踪时使用。</para>
		/// <para>选中 - 追踪结果中将包含孤立要素。</para>
		/// <para>未选中 - 追踪结果中将不包含孤立要素。 这是默认设置。</para>
		/// <para><see cref="IncludeIsolatedFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeIsolatedFeatures { get; set; } = "false";

		/// <summary>
		/// <para>Ignore Barriers At Starting Points</para>
		/// <para>指定是否在追踪配置中忽略起点处的动态障碍。 这在执行上游保护设备追踪并使用所发现的保护设备（屏障）作为起始点以找到后续上游保护设备时可能非常有用。</para>
		/// <para>选中 - 追踪过程中将忽略起点处的障碍。</para>
		/// <para>未选中 - 追踪过程中不会忽略起点处的障碍。 这是默认设置。</para>
		/// <para><see cref="IgnoreBarriersAtStartingPointsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IgnoreBarriersAtStartingPoints { get; set; } = "false";

		/// <summary>
		/// <para>Include up to First Spatial Container</para>
		/// <para>指定是否将已返回的容器限制为仅在追踪结果中包含那些所遇到的容器，且最多包含每个网络元素的第一个空间容器。 如果没有遇到空间容器，但是存在给定网络元素的非空间容器，则所有非空间容器都将包含在结果中。 仅当选中包含容器时，此参数才可用。</para>
		/// <para>选中 - 当沿追踪路径遇到嵌套包含关联时，结果中仅返回遇到次数最多并包括第一个空间容器的容器。 如果不存在空间容器，则给定网络元素的所有非空间容器都将包含在结果中。</para>
		/// <para>未选中 - 所有容器都将在结果中返回。 这是默认设置。</para>
		/// <para><see cref="IncludeUpToFirstSpatialContainerEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeUpToFirstSpatialContainer { get; set; } = "false";

		/// <summary>
		/// <para>Result Types</para>
		/// <para>指定追踪返回的结果的类型。</para>
		/// <para>选择—追踪结果将作为相应网络要素上的选择集返回。 这是默认设置。</para>
		/// <para>聚合几何—追踪结果按几何类型聚合，并存储在活动地图的图层中显示的多部件要素类中。</para>
		/// <para>连通性—追踪结果将作为指定输出 .json 文件中的连通图返回。 此选项将启用输出 JSON 参数。</para>
		/// <para>元素—追踪结果将作为指定输出 .json 文件中的基于要素的信息返回。 此选项将启用输出 JSON 参数。</para>
		/// <para><see cref="ResultTypesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object? ResultTypes { get; set; }

		/// <summary>
		/// <para>Selection Type</para>
		/// <para>指定如何应用所选内容以及如果已存在当前内容要执行的操作。</para>
		/// <para>新建选择内容—生成的选择内容将替换当前选择内容。 这是默认设置。</para>
		/// <para>添加到当前选择内容—当存在一个选择内容时，会将生成的选择内容添加到当前选择内容中。 如果不存在选择内容，该选项的作用与新选择内容选项的作用相同。</para>
		/// <para>从当前选择内容中移除—将生成的选择内容从当前选择内容中移除。 如果不存在选择内容，该选项不起作用。</para>
		/// <para>选择当前选择内容的子集—将生成的选择内容与当前选择内容进行组合。 仅两者共有的记录保持选中状态。</para>
		/// <para>切换当前选择内容—生成的选择内容将被切换。 将所选的结果从当前选择内容中移除，同时将未选取的结果添加到当前选择内容中。 如果不存在选择内容，该选项的作用与新选择内容选项的作用相同。</para>
		/// <para><see cref="SelectionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object? SelectionType { get; set; } = "NEW_SELECTION";

		/// <summary>
		/// <para>Clear All Previous Trace Results</para>
		/// <para>指定是将内容从选择用于存储聚合几何的要素类截断还是追加到其上。 此参数仅适用于聚合几何结果类型。</para>
		/// <para>选中 - 将截断用于存储聚合追踪几何的要素类。 将仅写入当前追踪操作的输出几何。 这是默认设置。</para>
		/// <para>未选中 - 当前追踪操作的输出几何将追加到用于存储聚合几何的要素类。</para>
		/// <para><see cref="ClearAllPreviousTraceResultsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Output")]
		public object? ClearAllPreviousTraceResults { get; set; } = "true";

		/// <summary>
		/// <para>Trace Name</para>
		/// <para>追踪操作的名称。 此值将存储在输出要素类的 TRACENAME 字段中，以协助识别追踪结果。 此参数仅适用于聚合几何结果类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Output")]
		public object? TraceName { get; set; }

		/// <summary>
		/// <para>Aggregated Points</para>
		/// <para>包含聚合结果几何的输出多点要素类。 默认情况下，将使用名为 Trace_Results_Aggregated_Points 的系统生成要素类填充该参数，该要素类将存储在工程的默认地理数据库中。</para>
		/// <para>如果该要素类不存在，则系统会自动创建。 也可以使用现有要素类存储聚合几何。 如果使用非默认要素类，则该要素类必须是多点要素类，并且包含名为 TRACENAME 的字符串字段。 此参数仅适用于聚合几何结果类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Multipoint")]
		[Category("Output")]
		public object? AggregatedPoints { get; set; } = "Trace_Results_Aggregated_Points";

		/// <summary>
		/// <para>Aggregated Lines</para>
		/// <para>包含聚合结果几何的输出折线要素类。 默认情况下，将使用名为 Trace_Results_Aggregated_Lines 的系统生成要素类填充该参数，该要素类将存储在工程的默认地理数据库中。</para>
		/// <para>如果该要素类不存在，则系统会自动创建。 也可以使用现有要素类存储聚合几何。 如果使用非默认要素类，则该要素类必须是折线要素类，并且包含名为 TRACENAME 的字符串字段。 此参数仅适用于聚合几何结果类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[Category("Output")]
		public object? AggregatedLines { get; set; } = "Trace_Results_Aggregated_Lines";

		/// <summary>
		/// <para>Aggregated Polygons</para>
		/// <para>包含聚合结果几何的输出面要素类。 默认情况下，将使用名为 Trace_Results_Aggregated_Polygons 的系统生成要素类填充该参数，该要素类将存储在工程的默认地理数据库中。</para>
		/// <para>如果该要素类不存在，则系统会自动创建。 也可以使用现有要素类存储聚合几何。 如果使用非默认要素类，则该要素类必须是面要素类，并且包含名为 TRACENAME 的字符串字段。 此参数仅适用于聚合几何结果类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[Category("Output")]
		public object? AggregatedPolygons { get; set; } = "Trace_Results_Aggregated_Polygons";

		/// <summary>
		/// <para>Allow Indeterminate Flow</para>
		/// <para>指定是否追踪具有不确定流向的要素。 此参数仅在运行上溯追踪、下溯追踪或孤立追踪时使用。</para>
		/// <para>选中 - 将追踪具有不确定流向的要素。 这是默认设置。</para>
		/// <para>未选中 - 具有不确定流向的要素将停止可遍历性并且不会被追踪。</para>
		/// <para>此参数需要公共设施网络版本值为 5 或更高版本。</para>
		/// <para><see cref="AllowIndeterminateFlowEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AllowIndeterminateFlow { get; set; } = "true";

		/// <summary>
		/// <para>Validate Locatability</para>
		/// <para>指定如果遇到非空间交汇点或边对象并且遍历对象的关联层次结构中没有必要的包含、附件或连通性关联，是否在追踪操作期间返回错误。 此参数确保可以通过与要素或其他可定位对象的关联来定位追踪或更新子网操作返回的非空间对象。</para>
		/// <para>选中 - 如果遇到非空间交汇点或边对象并且遍历对象的关联层次结构中没有必要的包含、附件或连通性关联，则追踪将返回一条错误。</para>
		/// <para>未选中 - 追踪不会检查是否存在无法定位的对象并返回结果，无论遍历对象的关联层次结构中是否存在无法定位的对象。 这是默认设置。</para>
		/// <para>此参数需要公共设施网络版本值为 4 或更高版本。</para>
		/// <para><see cref="ValidateLocatabilityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ValidateLocatability { get; set; } = "false";

		/// <summary>
		/// <para>Use Trace Configuration</para>
		/// <para>指定是否将使用现有指定追踪配置来填充追踪工具的参数。</para>
		/// <para>选中 - 将使用现有指定追踪配置来定义追踪的属性。 将忽略除追踪配置名称、起点和障碍之外的所有参数。</para>
		/// <para>未选中 - 不使用现有指定追踪配置来定义追踪的属性。 这是默认设置。</para>
		/// <para>此参数需要公共设施网络版本值为 5 或更高版本。</para>
		/// <para><see cref="UseTraceConfigEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? UseTraceConfig { get; set; } = "false";

		/// <summary>
		/// <para>Trace Configuration Name</para>
		/// <para>将用于定义追踪属性的追踪配置的名称。 仅当选中使用追踪配置参数时，此参数才会处于活动状态。</para>
		/// <para>此参数需要公共设施网络版本值为 5 或更高版本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? TraceConfigName { get; set; }

		/// <summary>
		/// <para>Output JSON</para>
		/// <para>将追踪结果作为连通图或基于要素的信息返回时将生成的 .json 文件的名称和位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("json")]
		[Category("Output")]
		public object? OutJsonFile { get; set; }

		/// <summary>
		/// <para>Run in asynchronous mode on the server</para>
		/// <para>此参数需要 ArcGIS Enterprise 10.9.1 或更高版本。</para>
		/// <para><see cref="RunAsyncEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? RunAsync { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Trace Type</para>
		/// </summary>
		public enum TraceTypeEnum 
		{
			/// <summary>
			/// <para>已连接—将使用从一个或多个起点开始并沿着已连接要素向外跨越的已连接追踪。 这是默认设置。</para>
			/// </summary>
			[GPValue("CONNECTED")]
			[Description("已连接")]
			Connected,

			/// <summary>
			/// <para>子网—将使用子网追踪，其从一个或多个起点开始向外跨越，目的是涵盖子网的范围。</para>
			/// </summary>
			[GPValue("SUBNETWORK")]
			[Description("子网")]
			Subnetwork,

			/// <summary>
			/// <para>子网控制器—将使用能够定位与子网关联的子网控制器上的源和汇的子网控制器追踪。</para>
			/// </summary>
			[GPValue("SUBNETWORK_CONTROLLERS")]
			[Description("子网控制器")]
			Subnetwork_controllers,

			/// <summary>
			/// <para>上游—将使用能够发现网络中某位置上游的要素的上溯追踪。</para>
			/// </summary>
			[GPValue("UPSTREAM")]
			[Description("上游")]
			Upstream,

			/// <summary>
			/// <para>下游—将使用能够发现网络中某位置下游的要素的下溯追踪。</para>
			/// </summary>
			[GPValue("DOWNSTREAM")]
			[Description("下游")]
			Downstream,

			/// <summary>
			/// <para>循环—循环是流向不明确的网络区域。 将使用能够从基于连通性的起点向外跨越的循环追踪。</para>
			/// </summary>
			[GPValue("LOOPS")]
			[Description("循环")]
			Loops,

			/// <summary>
			/// <para>最短路径—将使用能够识别两个起点之间的最短路径的最短路径追踪。</para>
			/// </summary>
			[GPValue("SHORTEST_PATH")]
			[Description("最短路径")]
			Shortest_path,

			/// <summary>
			/// <para>孤立—将使用能够发现孤立网络区域的要素的孤立追踪。</para>
			/// </summary>
			[GPValue("ISOLATION")]
			[Description("孤立")]
			Isolation,

		}

		/// <summary>
		/// <para>Include Containers</para>
		/// </summary>
		public enum IncludeContainersEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_CONTAINERS")]
			INCLUDE_CONTAINERS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_CONTAINERS")]
			EXCLUDE_CONTAINERS,

		}

		/// <summary>
		/// <para>Include Content</para>
		/// </summary>
		public enum IncludeContentEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_CONTENT")]
			INCLUDE_CONTENT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_CONTENT")]
			EXCLUDE_CONTENT,

		}

		/// <summary>
		/// <para>Include Structures</para>
		/// </summary>
		public enum IncludeStructuresEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_STRUCTURES")]
			INCLUDE_STRUCTURES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_STRUCTURES")]
			EXCLUDE_STRUCTURES,

		}

		/// <summary>
		/// <para>Include Barrier Features</para>
		/// </summary>
		public enum IncludeBarriersEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_BARRIERS")]
			INCLUDE_BARRIERS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_BARRIERS")]
			EXCLUDE_BARRIERS,

		}

		/// <summary>
		/// <para>Validate Consistency</para>
		/// </summary>
		public enum ValidateConsistencyEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("VALIDATE_CONSISTENCY")]
			VALIDATE_CONSISTENCY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_VALIDATE_CONSISTENCY")]
			DO_NOT_VALIDATE_CONSISTENCY,

		}

		/// <summary>
		/// <para>Apply Traversability To</para>
		/// </summary>
		public enum TraversabilityScopeEnum 
		{
			/// <summary>
			/// <para>交汇点和边—可遍历性将同时应用于交汇点和边。 这是默认设置。</para>
			/// </summary>
			[GPValue("BOTH_JUNCTIONS_AND_EDGES")]
			[Description("交汇点和边")]
			Both_junctions_and_edges,

			/// <summary>
			/// <para>仅交汇点—可遍历性将仅应用于交汇点。</para>
			/// </summary>
			[GPValue("JUNCTIONS_ONLY")]
			[Description("仅交汇点")]
			Junctions_only,

			/// <summary>
			/// <para>仅边—可遍历性将仅应用于边。</para>
			/// </summary>
			[GPValue("EDGES_ONLY")]
			[Description("仅边")]
			Edges_only,

		}

		/// <summary>
		/// <para>Apply Filter To</para>
		/// </summary>
		public enum FilterScopeEnum 
		{
			/// <summary>
			/// <para>交汇点和边 - 过滤器将同时应用于交汇点和边。 这是默认设置。</para>
			/// </summary>
			[GPValue("BOTH_JUNCTIONS_AND_EDGES")]
			[Description("交汇点和边")]
			Both_junctions_and_edges,

			/// <summary>
			/// <para>仅交汇点 - 过滤器将仅应用于交汇点。</para>
			/// </summary>
			[GPValue("JUNCTIONS_ONLY")]
			[Description("仅交汇点")]
			Junctions_only,

			/// <summary>
			/// <para>仅边 - 过滤器将仅应用于边。</para>
			/// </summary>
			[GPValue("EDGES_ONLY")]
			[Description("仅边")]
			Edges_only,

		}

		/// <summary>
		/// <para>Filter by nearest</para>
		/// </summary>
		public enum FilterNearestEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FILTER_BY_NEAREST")]
			FILTER_BY_NEAREST,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_FILTER")]
			DO_NOT_FILTER,

		}

		/// <summary>
		/// <para>Include Isolated Features</para>
		/// </summary>
		public enum IncludeIsolatedFeaturesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_ISOLATED_FEATURES")]
			INCLUDE_ISOLATED_FEATURES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_ISOLATED_FEATURES")]
			EXCLUDE_ISOLATED_FEATURES,

		}

		/// <summary>
		/// <para>Ignore Barriers At Starting Points</para>
		/// </summary>
		public enum IgnoreBarriersAtStartingPointsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("IGNORE_BARRIERS_AT_STARTING_POINTS")]
			IGNORE_BARRIERS_AT_STARTING_POINTS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_IGNORE_BARRIERS_AT_STARTING_POINTS")]
			DO_NOT_IGNORE_BARRIERS_AT_STARTING_POINTS,

		}

		/// <summary>
		/// <para>Include up to First Spatial Container</para>
		/// </summary>
		public enum IncludeUpToFirstSpatialContainerEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_UP_TO_FIRST_SPATIAL_CONTAINER")]
			INCLUDE_UP_TO_FIRST_SPATIAL_CONTAINER,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_INCLUDE_UP_TO_FIRST_SPATIAL_CONTAINER")]
			DO_NOT_INCLUDE_UP_TO_FIRST_SPATIAL_CONTAINER,

		}

		/// <summary>
		/// <para>Result Types</para>
		/// </summary>
		public enum ResultTypesEnum 
		{
			/// <summary>
			/// <para>选择—追踪结果将作为相应网络要素上的选择集返回。 这是默认设置。</para>
			/// </summary>
			[GPValue("SELECTION")]
			[Description("选择")]
			Selection,

			/// <summary>
			/// <para>聚合几何—追踪结果按几何类型聚合，并存储在活动地图的图层中显示的多部件要素类中。</para>
			/// </summary>
			[GPValue("AGGREGATED_GEOMETRY")]
			[Description("聚合几何")]
			Aggregated_Geometry,

			/// <summary>
			/// <para>连通性—追踪结果将作为指定输出 .json 文件中的连通图返回。 此选项将启用输出 JSON 参数。</para>
			/// </summary>
			[GPValue("CONNECTIVITY")]
			[Description("连通性")]
			Connectivity,

			/// <summary>
			/// <para>元素—追踪结果将作为指定输出 .json 文件中的基于要素的信息返回。 此选项将启用输出 JSON 参数。</para>
			/// </summary>
			[GPValue("ELEMENTS")]
			[Description("元素")]
			Elements,

		}

		/// <summary>
		/// <para>Selection Type</para>
		/// </summary>
		public enum SelectionTypeEnum 
		{
			/// <summary>
			/// <para>新建选择内容—生成的选择内容将替换当前选择内容。 这是默认设置。</para>
			/// </summary>
			[GPValue("NEW_SELECTION")]
			[Description("新建选择内容")]
			New_selection,

			/// <summary>
			/// <para>添加到当前选择内容—当存在一个选择内容时，会将生成的选择内容添加到当前选择内容中。 如果不存在选择内容，该选项的作用与新选择内容选项的作用相同。</para>
			/// </summary>
			[GPValue("ADD_TO_SELECTION")]
			[Description("添加到当前选择内容")]
			Add_to_the_current_selection,

			/// <summary>
			/// <para>从当前选择内容中移除—将生成的选择内容从当前选择内容中移除。 如果不存在选择内容，该选项不起作用。</para>
			/// </summary>
			[GPValue("REMOVE_FROM_SELECTION")]
			[Description("从当前选择内容中移除")]
			Remove_from_the_current_selection,

			/// <summary>
			/// <para>选择当前选择内容的子集—将生成的选择内容与当前选择内容进行组合。 仅两者共有的记录保持选中状态。</para>
			/// </summary>
			[GPValue("SUBSET_SELECTION")]
			[Description("选择当前选择内容的子集")]
			Select_subset_from_the_current_selection,

			/// <summary>
			/// <para>切换当前选择内容—生成的选择内容将被切换。 将所选的结果从当前选择内容中移除，同时将未选取的结果添加到当前选择内容中。 如果不存在选择内容，该选项的作用与新选择内容选项的作用相同。</para>
			/// </summary>
			[GPValue("SWITCH_SELECTION")]
			[Description("切换当前选择内容")]
			Switch_the_current_selection,

		}

		/// <summary>
		/// <para>Clear All Previous Trace Results</para>
		/// </summary>
		public enum ClearAllPreviousTraceResultsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CLEAR_ALL_PREVIOUS_TRACE_RESULTS")]
			CLEAR_ALL_PREVIOUS_TRACE_RESULTS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_CLEAR_ALL_PREVIOUS_TRACE_RESULTS")]
			DO_NOT_CLEAR_ALL_PREVIOUS_TRACE_RESULTS,

		}

		/// <summary>
		/// <para>Allow Indeterminate Flow</para>
		/// </summary>
		public enum AllowIndeterminateFlowEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("TRACE_INDETERMINATE_FLOW")]
			TRACE_INDETERMINATE_FLOW,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("IGNORE_INDETERMINATE_FLOW")]
			IGNORE_INDETERMINATE_FLOW,

		}

		/// <summary>
		/// <para>Validate Locatability</para>
		/// </summary>
		public enum ValidateLocatabilityEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("VALIDATE_LOCATABILITY")]
			VALIDATE_LOCATABILITY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_VALIDATE_LOCATABILITY")]
			DO_NOT_VALIDATE_LOCATABILITY,

		}

		/// <summary>
		/// <para>Use Trace Configuration</para>
		/// </summary>
		public enum UseTraceConfigEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_TRACE_CONFIGURATION")]
			USE_TRACE_CONFIGURATION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_USE_TRACE_CONFIGURATION")]
			DO_NOT_USE_TRACE_CONFIGURATION,

		}

		/// <summary>
		/// <para>Run in asynchronous mode on the server</para>
		/// </summary>
		public enum RunAsyncEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RUN_ASYNCHRONOUSLY")]
			RUN_ASYNCHRONOUSLY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("RUN_SYNCHRONOUSLY")]
			RUN_SYNCHRONOUSLY,

		}

#endregion
	}
}
