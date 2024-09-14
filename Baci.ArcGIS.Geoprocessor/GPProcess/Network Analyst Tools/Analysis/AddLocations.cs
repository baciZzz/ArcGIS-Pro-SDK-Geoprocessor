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
	/// <para>Add Locations</para>
	/// <para>添加位置</para>
	/// <para>将输入要素或记录添加到网络分析图层。 向特定子图层（如“停靠点”图层和“障碍”图层）添加输入。 当网络分析图层引用网络数据集作为其网络数据源时，该工具会计算输入的网络位置，除非预先计算的网络位置字段是从输入映射的。</para>
	/// </summary>
	public class AddLocations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkAnalysisLayer">
		/// <para>Input Network Analysis Layer</para>
		/// <para>要添加网络分析对象的网络分析图层。</para>
		/// </param>
		/// <param name="SubLayer">
		/// <para>Sub Layer</para>
		/// <para>要添加网络分析对象的网络分析图层的子图层名称。</para>
		/// </param>
		/// <param name="InTable">
		/// <para>Input Locations</para>
		/// <para>包含要添加到网络分析子图层的位置的要素类或表。</para>
		/// </param>
		public AddLocations(object InNetworkAnalysisLayer, object SubLayer, object InTable)
		{
			this.InNetworkAnalysisLayer = InNetworkAnalysisLayer;
			this.SubLayer = SubLayer;
			this.InTable = InTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加位置</para>
		/// </summary>
		public override string DisplayName() => "添加位置";

		/// <summary>
		/// <para>Tool Name : AddLocations</para>
		/// </summary>
		public override string ToolName() => "AddLocations";

		/// <summary>
		/// <para>Tool Excute Name : na.AddLocations</para>
		/// </summary>
		public override string ExcuteName() => "na.AddLocations";

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
		public override object[] Parameters() => new object[] { InNetworkAnalysisLayer, SubLayer, InTable, FieldMappings!, SearchTolerance!, SortField!, SearchCriteria!, MatchType!, Append!, SnapToPositionAlongNetwork!, SnapOffset!, ExcludeRestrictedElements!, SearchQuery!, OutputLayer!, AllowAutoRelocate! };

		/// <summary>
		/// <para>Input Network Analysis Layer</para>
		/// <para>要添加网络分析对象的网络分析图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNALayer()]
		public object InNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Sub Layer</para>
		/// <para>要添加网络分析对象的网络分析图层的子图层名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SubLayer { get; set; }

		/// <summary>
		/// <para>Input Locations</para>
		/// <para>包含要添加到网络分析子图层的位置的要素类或表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field Mappings</para>
		/// <para>您要添加位置的网络分析子图层的输入字段与输入数据或指定常量中的字段之间的映射。</para>
		/// <para>网络分析图层的输入子图层具有一组输入字段，可以填充这些字段以修改或控制分析行为。 将位置添加到子图层时，可以使用此参数将输入表中的字段值映射到子图层中的这些字段。 您还可以使用字段映射为每个属性指定恒定默认值。</para>
		/// <para>如果属性的字段和默认值都没有指定，则生成的网络分析对象的属性值为空。</para>
		/// <para>每个图层的文档中提供了每种网络分析图层类型的每个子图层的输入字段的完整列表。 例如，检查 Route 图层 Stops 子图层的输入字段。</para>
		/// <para>如果加载的数据包含基于用于分析的网络数据源和出行模式预先计算的网络位置或位置范围，请从下拉菜单中选择使用网络位置字段选项。 使用网络位置字段来添加网络分析对象比按照几何加载速度更快。</para>
		/// <para>ArcGIS Online 和一些 ArcGIS Enterprise 门户不支持使用网络位置字段。 对于使用这些门户之一作为网络数据源的网络分析图层，所有输入都将在求解时定位，并且任何映射的位置字段都将被忽略。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[NAClassFieldMap()]
		public object? FieldMappings { get; set; }

		/// <summary>
		/// <para>Search Tolerance</para>
		/// <para>在网络上定位输入要素所需的最大搜索距离。 搜索容差以外的要素将保持未定位状态。 该参数包括值和单位。</para>
		/// <para>此参数的默认值由存储在输入网络分析图层中的位置属性确定。 如果网络分析图层具有所选子图层的位置设置替代，则将使用这些设置。 否则，将使用网络分析图层的默认位置设置。 为此参数设置非默认值将更新网络分析图层的位置设置，覆盖选定子图层。</para>
		/// <para>在将位置添加到具有线或面几何（如“线障碍”和“面障碍”）的子图层时，不使用该参数。</para>
		/// <para>使用现有网络位置字段添加位置时不使用此参数。</para>
		/// <para>当网络分析图层的网络数据源为早于 11.0 版本的 ArcGIS Enterprise 门户时，不使用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Advanced")]
		public object? SearchTolerance { get; set; }

		/// <summary>
		/// <para>Sort Field</para>
		/// <para>当网络分析对象被添加到网络分析图层时用于排序网络分析对象的字段。 默认设置为输入要素类或表中的 ObjectID 字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID")]
		[Category("Advanced")]
		public object? SortField { get; set; }

		/// <summary>
		/// <para>Search Criteria</para>
		/// <para>在网络上定位输入时，将搜索的网络数据集中的边和交汇点源。 例如，如果网络数据集引用表示街道和人行道的单独要素类，则可以选择在街道上定位输入，而非人行道。</para>
		/// <para>以下是每个网络源可用的捕捉类型选择：</para>
		/// <para>NONE - 点将不位于此网络源的元素上。</para>
		/// <para>SHAPE - 点将位于此网络源中元素的最近点处。</para>
		/// <para>MIDDLE - 此选项已弃用，其行为与 Shape 相同。</para>
		/// <para>END - 此选项已弃用，其行为与 Shape 相同。</para>
		/// <para>此参数的默认值由存储在输入网络分析图层中的位置属性确定。 如果网络分析图层具有所选子图层的位置设置替代，则将使用这些设置。 否则，将使用网络分析图层的默认位置设置。 为此参数设置非默认值将更新网络分析图层的位置设置，覆盖选定子图层。</para>
		/// <para>使用现有网络位置字段添加位置时不使用此参数。</para>
		/// <para>当网络分析图层的网络数据源为 ArcGIS Online 时，不使用此参数。</para>
		/// <para>当网络分析图层的网络数据源为早于 11.0 版本的 ArcGIS Enterprise 门户时，不使用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Advanced")]
		public object? SearchCriteria { get; set; }

		/// <summary>
		/// <para>Find Closest among All Classes</para>
		/// <para>此参数已弃用和维护，只是为了向后兼容。 输入将始终与用于定位的所有源中最近的网络源匹配，对应于参数值 MATCH_TO_CLOSEST 或 True。</para>
		/// <para><see cref="MatchTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? MatchType { get; set; } = "true";

		/// <summary>
		/// <para>Append to Existing Locations</para>
		/// <para>指定是否将新网络分析对象附加到现有对象。</para>
		/// <para>选中 - 会将新的网络分析对象追加到所选子图层中的现有对象集中。 这是默认设置。</para>
		/// <para>未选中 - 将删除现有的网络分析对象并使用新的对象来代替。</para>
		/// <para><see cref="AppendEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Append { get; set; } = "true";

		/// <summary>
		/// <para>Snap to Network</para>
		/// <para>指定将输入捕捉到其计算出的网络位置，还是由其原始地理位置表示它。</para>
		/// <para>要在分析中使用路边通道来控制车辆在靠近位置时必须使用道路的哪一侧，请勿将输入捕捉到其网络位置，或使用捕捉偏移来确保该点始终清晰地保持在道路的一侧。</para>
		/// <para>在将位置添加到具有线或面几何（如“线障碍”和“面障碍”）的子图层时，不使用该参数。</para>
		/// <para>当输入网络分析图层的网络数据源为门户服务时，不使用此参数。</para>
		/// <para>选中 - 网络位置的几何将被捕捉到其网络位置。</para>
		/// <para>未选中 - 网络位置的几何将基于输入要素的几何。 这是默认设置。</para>
		/// <para><see cref="SnapToPositionAlongNetworkEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SnapToPositionAlongNetwork { get; set; } = "false";

		/// <summary>
		/// <para>Snap Offset</para>
		/// <para>将点捕捉到网络时将应用的偏移距离。 偏移距离为零表示点将与网络要素（通常是线）重合。 要使点偏离网络要素，请输入偏移距离。 偏移与起始点的位置有关；即，如果起始点在左侧，它的新位置就会向左偏移。 如果起始点在右侧，它的新位置就会向右偏移。</para>
		/// <para>默认设置为 5 米。 但是，如果未选中捕捉到网络，则会忽略此参数。</para>
		/// <para>在将位置添加到具有线或面几何（如“线障碍”和“面障碍”）的子图层时，不使用该参数。</para>
		/// <para>当输入网络分析图层的网络数据源为门户服务时，不使用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? SnapOffset { get; set; } = "5 Meters";

		/// <summary>
		/// <para>Exclude Restricted Portions of the Network</para>
		/// <para>此参数已弃用和维护，只是为了向后兼容。 分析输入永远不会位于受限制的网络元素上，对应于 EXCLUDE 或 True 的参数值。</para>
		/// <para><see cref="ExcludeRestrictedElementsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ExcludeRestrictedElements { get; set; } = "true";

		/// <summary>
		/// <para>Search Query</para>
		/// <para>将搜索限制在源要素类的要素子集内的查询。 这在不想查找可能不适合网络位置的要素时很有用。 例如，如果您不想定位在高速公路坡道上，则可定义一个查询将其排除。 可以为网络数据集的每个边或交汇点源要素类指定一个单独的 SQL 表达式。</para>
		/// <para>任何在地理处理窗格中未明确指定的网络源都不会应用查询。</para>
		/// <para>此参数的默认值由存储在输入网络分析图层中的位置属性确定。 如果网络分析图层具有所选子图层的位置设置替代，则将使用这些设置。 否则，将使用网络分析图层的默认位置设置。 为此参数设置非默认值将更新网络分析图层的位置设置，覆盖选定子图层。</para>
		/// <para>使用现有网络位置字段添加位置时不使用此参数。</para>
		/// <para>当网络分析图层的网络数据源为 ArcGIS Online 时，不使用此参数。</para>
		/// <para>当网络分析图层的网络数据源为早于 11.0 版本的 ArcGIS Enterprise 门户时，不使用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Advanced")]
		public object? SearchQuery { get; set; }

		/// <summary>
		/// <para>Updated Input Network Analysis Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object? OutputLayer { get; set; }

		/// <summary>
		/// <para>Allow automatic relocating at solve time</para>
		/// <para>指定是否可以在求解时自动重定位具有现有网络位置字段的输入，以确保分析的位置字段有效并且可路由。</para>
		/// <para>选中 - 位于限制网络元素上的点和受障碍影响的点将在求解时重定位至最近的可路由位置。 这是默认设置。</para>
		/// <para>取消选中 - 求解时网络位置字段将按原样使用（即使点无法访问），并且这可能会导致求解失败。</para>
		/// <para>此参数的默认值由存储在输入网络分析图层中的位置属性确定。 如果网络分析图层具有所选子图层的位置设置替代，则将使用这些设置。 否则，将使用网络分析图层的默认位置设置。 为此参数设置非默认值将更新网络分析图层的位置设置，覆盖选定子图层。</para>
		/// <para>即使不允许在求解时自动重新定位，也将在求解时定位没有位置字段或位置字段不完整的输入。</para>
		/// <para>当网络分析图层的网络数据源为 ArcGIS Online 时，不使用此参数。</para>
		/// <para>当网络分析图层的网络数据源是不支持使用网络位置字段的 ArcGIS Enterprise 门户时，不使用此参数。</para>
		/// <para>当网络分析图层的网络数据源为早于 11.0 版本的 ArcGIS Enterprise 门户时，不使用此参数。</para>
		/// <para><see cref="AllowAutoRelocateEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced")]
		public object? AllowAutoRelocate { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddLocations SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Find Closest among All Classes</para>
		/// </summary>
		public enum MatchTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MATCH_TO_CLOSEST")]
			MATCH_TO_CLOSEST,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("PRIORITY")]
			PRIORITY,

		}

		/// <summary>
		/// <para>Append to Existing Locations</para>
		/// </summary>
		public enum AppendEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("APPEND")]
			APPEND,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("CLEAR")]
			CLEAR,

		}

		/// <summary>
		/// <para>Snap to Network</para>
		/// </summary>
		public enum SnapToPositionAlongNetworkEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SNAP")]
			SNAP,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SNAP")]
			NO_SNAP,

		}

		/// <summary>
		/// <para>Exclude Restricted Portions of the Network</para>
		/// </summary>
		public enum ExcludeRestrictedElementsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EXCLUDE")]
			EXCLUDE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("INCLUDE")]
			INCLUDE,

		}

		/// <summary>
		/// <para>Allow automatic relocating at solve time</para>
		/// </summary>
		public enum AllowAutoRelocateEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ALLOW")]
			ALLOW,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ALLOW")]
			NO_ALLOW,

		}

#endregion
	}
}
