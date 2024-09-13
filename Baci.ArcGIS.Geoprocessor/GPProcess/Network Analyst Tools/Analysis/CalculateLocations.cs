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
	/// <para>Calculate Locations</para>
	/// <para>计算位置</para>
	/// <para>定位网络上的输入要素，并将描述这些网络位置的字段添加到输入要素中。该工具用于将网络位置信息存储为要素属性，以便快速地为网络分析的输入加载要素。</para>
	/// </summary>
	public class CalculateLocations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointFeatures">
		/// <para>Input Features</para>
		/// <para>将要计算网络位置的输入要素。</para>
		/// <para>对于线和面要素，由于网络位置信息存储在 BLOB 字段中（在位置范围字段参数中指定），所以仅支持地理数据库要素类。</para>
		/// </param>
		/// <param name="InNetworkDataset">
		/// <para>Input Analysis Network</para>
		/// <para>将用于计算位置的网络数据集。</para>
		/// <para>如果将网络分析图层的子图层用作输入要素，则该参数将被自动设置为网络分析图层所引用的网络数据集。</para>
		/// </param>
		public CalculateLocations(object InPointFeatures, object InNetworkDataset)
		{
			this.InPointFeatures = InPointFeatures;
			this.InNetworkDataset = InNetworkDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算位置</para>
		/// </summary>
		public override string DisplayName() => "计算位置";

		/// <summary>
		/// <para>Tool Name : CalculateLocations</para>
		/// </summary>
		public override string ToolName() => "CalculateLocations";

		/// <summary>
		/// <para>Tool Excute Name : na.CalculateLocations</para>
		/// </summary>
		public override string ExcuteName() => "na.CalculateLocations";

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
		public override object[] Parameters() => new object[] { InPointFeatures, InNetworkDataset, SearchTolerance, SearchCriteria, MatchType, SourceIDField, SourceOIDField, PositionField, SideField, SnapXField, SnapYField, DistanceField, SnapZField, LocationField, ExcludeRestrictedElements, SearchQuery, OutPointFeatureClass, TravelMode };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>将要计算网络位置的输入要素。</para>
		/// <para>对于线和面要素，由于网络位置信息存储在 BLOB 字段中（在位置范围字段参数中指定），所以仅支持地理数据库要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline", "Polygon")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Input Analysis Network</para>
		/// <para>将用于计算位置的网络数据集。</para>
		/// <para>如果将网络分析图层的子图层用作输入要素，则该参数将被自动设置为网络分析图层所引用的网络数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNetworkDatasetLayer()]
		public object InNetworkDataset { get; set; }

		/// <summary>
		/// <para>Search Tolerance</para>
		/// <para>在网络上定位输入要素所使用的搜索容差。搜索容差以外的要素将保持未定位状态。该参数包括容差的值和单位。</para>
		/// <para>默认值为 5000 米。</para>
		/// <para>计算线或面要素的位置时，不使用该参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Advanced")]
		public object SearchTolerance { get; set; } = "5000 Meters";

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
		/// <para>Source ID Field</para>
		/// <para>要使用计算的网络位置的源 ID 创建或更新的字段名称。默认情况下，将创建或更新名为 SourceID 的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		[Category("Network Location Fields")]
		public object SourceIDField { get; set; }

		/// <summary>
		/// <para>Source OID Field</para>
		/// <para>要使用计算的网络位置的源 OID 创建或更新的字段名称。默认情况下，将创建或更新名为 SourceOID 的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		[Category("Network Location Fields")]
		public object SourceOIDField { get; set; }

		/// <summary>
		/// <para>Percent Along Field</para>
		/// <para>要使用计算的网络位置的延伸百分比创建或更新的字段名称。默认情况下，将创建或更新名为 PosAlong 的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double")]
		[Category("Network Location Fields")]
		public object PositionField { get; set; }

		/// <summary>
		/// <para>Side of Edge Field</para>
		/// <para>要使用点要素在计算的网络位置的边侧创建或更新的字段名称。默认情况下，将创建或更新名为 SideOfEdge 的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		[Category("Network Location Fields")]
		public object SideField { get; set; }

		/// <summary>
		/// <para>Located X-Coordinate Field</para>
		/// <para>要使用计算的网络位置的 x 坐标创建或更新的字段名称。默认情况下，将创建或更新名为 SnapX 的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double")]
		[Category("Network Location Fields")]
		public object SnapXField { get; set; }

		/// <summary>
		/// <para>Located Y-Coordinate Field</para>
		/// <para>要使用计算的网络位置的 у 坐标创建或更新的字段名称。默认情况下，将创建或更新名为 SnapY 的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double")]
		[Category("Network Location Fields")]
		public object SnapYField { get; set; }

		/// <summary>
		/// <para>Distance from Feature Field</para>
		/// <para>要使用点要素与计算的网络位置的距离创建或更新的字段名称。默认情况下，将创建或更新名为 Distance 的字段。</para>
		/// <para>输出字段的单位为米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double")]
		[Category("Network Location Fields")]
		public object DistanceField { get; set; }

		/// <summary>
		/// <para>Located Z-Coordinate Field</para>
		/// <para>要使用计算的网络位置的 z 坐标创建或更新的字段名称。默认情况下，将创建或更新名为 SnapZ 的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double")]
		[Category("Network Location Fields")]
		public object SnapZField { get; set; }

		/// <summary>
		/// <para>Location Ranges Field</para>
		/// <para>要使用线或面要素的计算的网络位置的位置范围创建或更新的字段名称。默认情况下，将创建或更新名为 Locations 的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Blob")]
		[Category("Network Location Fields")]
		public object LocationField { get; set; }

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
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline", "Polygon")]
		public object OutPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>要在分析中使用的出行模式名称。</para>
		/// <para>如果选择了一个出行模式，那么将在计算位置字段时进行出行模式设置（例如限制和阻抗属性）。例如，如果距离输入点之一最近的网络边缘禁止卡车通行，且您的出行模式设置的是卡车模式，则计算位置会把点定位到下一个最近的不禁止卡车的网络边缘。</para>
		/// <para>可用出行模式取决于输入分析网络参数值。</para>
		/// <para>如果将网络分析图层的子图层用作输入要素，则出行模式参数必须设置为网络分析图层的行驶模式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TravelMode { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateLocations SetEnviroment(object workspace = null )
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
