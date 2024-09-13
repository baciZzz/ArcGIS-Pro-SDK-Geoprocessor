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
	/// <para>将输入要素或记录添加到网络分析图层。向特定子图层（如“停靠点”图层和“障碍”图层）添加输入。</para>
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
		public override object[] Parameters() => new object[] { InNetworkAnalysisLayer, SubLayer, InTable, FieldMappings, SearchTolerance, SortField, SearchCriteria, MatchType, Append, SnapToPositionAlongNetwork, SnapOffset, ExcludeRestrictedElements, SearchQuery, OutputLayer };

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
		/// <para>网络分析图层的输入子图层具有一组输入字段，您可以根据分析需要来修改或填充这些输入字段。将位置添加到子图层时，可以使用此参数将输入表中的字段值映射到子图层中的这些字段。您还可以使用字段映射为每个属性指定恒定默认值。</para>
		/// <para>如果属性的字段和默认值都没有指定，则生成的网络分析对象的属性值为空。</para>
		/// <para>每个图层的文档中提供了每种网络分析图层类型的每个子图层的输入字段的完整列表。例如，检查 Route 图层 Stops 子图层的输入字段。</para>
		/// <para>如果正在加载的数据中含有基于用于分析的网络数据集的网络位置或位置范围，请从下拉菜单中选择使用网络位置字段选项。使用网络位置字段来添加网络分析对象比按照几何加载速度更快。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[NAClassFieldMap()]
		public object FieldMappings { get; set; }

		/// <summary>
		/// <para>Search Tolerance</para>
		/// <para>在网络上定位输入要素所使用的搜索容差。搜索容差以外的要素将保持未定位状态。该参数包括容差的值和单位。</para>
		/// <para>默认值为 5000 米。</para>
		/// <para>在将位置添加到具有线或面几何（如“线障碍”和“面障碍”）的子图层时，不使用该参数。</para>
		/// <para>当输入网络分析图层的网络数据源为门户服务时，不使用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Advanced")]
		public object SearchTolerance { get; set; }

		/// <summary>
		/// <para>Sort Field</para>
		/// <para>当网络分析对象被添加到网络分析图层时用于排序网络分析对象的字段。默认设置为输入要素类或表中的 ObjectID 字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID")]
		[Category("Advanced")]
		public object SortField { get; set; }

		/// <summary>
		/// <para>Search Criteria</para>
		/// <para>计算网络位置时将搜索网络数据集中的源以及将使用几何的部分（也称为捕捉类型）。例如，如果网络数据集引用表示街道和人行道的单独要素类，则可以选择在街道上定位输入，而非人行道。</para>
		/// <para>以下是每个网络源可用的捕捉类型选择：</para>
		/// <para>SHAPE - 点将位于此网络源中元素的最近点处。</para>
		/// <para>MIDDLE - 点将位于此网络源中元素的最近中点处。</para>
		/// <para>END - 点将位于此网络源中元素的最近端点处。</para>
		/// <para>NONE - 点将不位于此网络源的元素上。</para>
		/// <para>针对向后兼容性，将保留 MIDDLE 和 END 选项。使用 SHAPE 选项在特定的网络源中查找输入；否则，请使用 NONE。</para>
		/// <para>计算线或面要素的位置时，即使指定了其他捕捉类型，也将仅使用 SHAPE 捕捉类型。</para>
		/// <para>除通过运行融合网络工具创建的覆盖交汇点和系统交汇点外（其默认值为 NONE），其他所有网络源的默认值为 SHAPE。</para>
		/// <para>网络数据源为门户服务时此参数不可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Advanced")]
		public object SearchCriteria { get; set; }

		/// <summary>
		/// <para>Find Closest among All Classes</para>
		/// <para>此参数仅可通过 Python 获得。</para>
		/// <para><see cref="MatchTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object MatchType { get; set; } = "true";

		/// <summary>
		/// <para>Append to Existing Locations</para>
		/// <para>指定是否将新网络分析对象附加到现有对象。</para>
		/// <para>选中 - 会将新的网络分析对象追加到所选子图层中的现有对象集中。这是默认设置。</para>
		/// <para>未选中 - 将删除现有的网络分析对象并使用新的对象来代替。</para>
		/// <para><see cref="AppendEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Append { get; set; } = "true";

		/// <summary>
		/// <para>Snap to Network</para>
		/// <para>指定将输入捕捉到其计算出的网络位置，还是由其原始地理位置表示它。</para>
		/// <para>要在分析中使用路边通道来控制车辆在靠近位置时必须使用道路的哪一侧，请勿将输入捕捉到其网络位置，或使用捕捉偏移来确保该点始终清晰地保持在道路的一侧。</para>
		/// <para>在将位置添加到具有线或面几何（如“线障碍”和“面障碍”）的子图层时，不使用该参数。</para>
		/// <para>当输入网络分析图层的网络数据源为门户服务时，不使用此参数。</para>
		/// <para>如果在添加位置后更改网络分析图层的出行模式，或者添加或移除障碍，则在求解时将自动重新计算受影响点的网络位置，以确保其仍然有效。此自动重新计算过程将不考虑先前在计算网络位置时使用的任何设置，例如搜索查询。相反，它仅使用输入要素的几何以及网络分析图层的出行模式和障碍。要在自动重新计算该点的网络位置时，提升选择相同网络位置的可能性，请使用此参数将输入捕捉到运行此工具时计算出的网络位置。这样，所需的网络位置将保留在输入点的几何中。</para>
		/// <para>选中 - 网络位置的几何将被捕捉到其网络位置。</para>
		/// <para>未选中 - 网络位置的几何将基于输入要素的几何。这是默认设置。</para>
		/// <para><see cref="SnapToPositionAlongNetworkEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SnapToPositionAlongNetwork { get; set; } = "false";

		/// <summary>
		/// <para>Snap Offset</para>
		/// <para>将点捕捉到网络时，您可以应用偏移距离。偏移距离为零表示点将与网络要素（通常是线）重合。要使点偏离网络要素，请输入偏移距离。偏移与起始点的位置有关；即，如果起始点在左侧，它的新位置就会向左偏移。如果起始点在右侧，它的新位置就会向右偏移。</para>
		/// <para>默认值为 5 米。但是，如果未选中捕捉到网络，则会忽略此参数。</para>
		/// <para>在将位置添加到具有线或面几何（如“线障碍”和“面障碍”）的子图层时，不使用该参数。</para>
		/// <para>当输入网络分析图层的网络数据源为门户服务时，不使用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object SnapOffset { get; set; } = "5 Meters";

		/// <summary>
		/// <para>Exclude Restricted Portions of the Network</para>
		/// <para>此参数仅可通过 Python 获得。</para>
		/// <para><see cref="ExcludeRestrictedElementsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ExcludeRestrictedElements { get; set; } = "true";

		/// <summary>
		/// <para>Search Query</para>
		/// <para>定义将搜索限制在源要素类的要素子集内的查询。这在不想查找可能不适合分析的要素时很有用。例如，您可以使用查询来排除具有特定道路类的所有要素。</para>
		/// <para>可以为网络数据集的每个源要素类指定一个单独的 SQL 表达式。默认情况下任何源都不使用查询。</para>
		/// <para>网络数据源为门户服务时此参数不可用。</para>
		/// <para>通过在名称列内选择源名称并在查询列中使用 SQL 表达式构建器来指定给定网络源的 SQL 表达式。有关 SQL 语法的详细信息，请参阅在 ArcGIS 中使用的查询表达式的 SQL 参考。</para>
		/// <para>在工具对话框中未明确指定的任何网络源都不会应用查询。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Advanced")]
		public object SearchQuery { get; set; }

		/// <summary>
		/// <para>Updated Input Network Analysis Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object OutputLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddLocations SetEnviroment(object workspace = null )
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

#endregion
	}
}
