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
	/// <para>用于定位网络上的输入要素，并将字段添加到描述网络位置的输入要素。 该工具用于预先计算将在 Network Analyst 工作流中使用的输入的网络位置，从而提高求解时的分析性能。 该工具将计算的输入网络位置存储在输入数据的字段中。</para>
	/// </summary>
	public class CalculateLocations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointFeatures">
		/// <para>Input Features</para>
		/// <para>将要计算网络位置的输入要素。</para>
		/// <para>对于线和面要素，由于网络位置信息存储在 BLOB 字段中，所以仅支持地理数据库要素类。</para>
		/// </param>
		public CalculateLocations(object InPointFeatures)
		{
			this.InPointFeatures = InPointFeatures;
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
		public override object[] Parameters() => new object[] { InPointFeatures, InNetworkDataset!, SearchTolerance!, SearchCriteria!, MatchType!, SourceIDField!, SourceOIDField!, PositionField!, SideField!, SnapXField!, SnapYField!, DistanceField!, SnapZField!, LocationField!, ExcludeRestrictedElements!, SearchQuery!, OutPointFeatureClass!, TravelMode!, OutputLayer! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>将要计算网络位置的输入要素。</para>
		/// <para>对于线和面要素，由于网络位置信息存储在 BLOB 字段中，所以仅支持地理数据库要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline", "Polygon")]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Input Analysis Network</para>
		/// <para>将用于计算位置的网络数据集。</para>
		/// <para>除非网络分析图层的子图层用作输入要素，否则此参数为必填项。 在这种情况下，将隐藏该参数，并自动将其设置为网络分析图层所引用的网络数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPNetworkDatasetLayer()]
		public object? InNetworkDataset { get; set; }

		/// <summary>
		/// <para>Search Tolerance</para>
		/// <para>在网络上定位输入要素所需的最大搜索距离。 搜索容差以外的要素将保持未定位状态。 该参数包括值和单位。</para>
		/// <para>默认值为 5000 米。</para>
		/// <para>如果输入要素是网络分析图层的子图层，则此参数的默认值由存储在输入网络分析图层中的位置属性确定。 如果网络分析图层具有所选子图层的位置设置替代，则将使用这些设置。 否则，将使用网络分析图层的默认位置设置。 为此参数设置非默认值将更新网络分析图层的位置设置，覆盖选定子图层。</para>
		/// <para>计算线或面要素的位置时，不使用该参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Advanced")]
		public object? SearchTolerance { get; set; }

		/// <summary>
		/// <para>Search Criteria</para>
		/// <para>在网络上定位输入时，将搜索的网络数据集中的边和交汇点源。 例如，如果网络数据集引用表示街道和人行道的单独要素类，则可以选择在街道上定位输入，而非人行道。</para>
		/// <para>以下是每个网络源可用的捕捉类型选择：</para>
		/// <para>NONE - 点将不位于此网络源的元素上。</para>
		/// <para>SHAPE - 点将位于此网络源中元素的最近点处。</para>
		/// <para>MIDDLE - 此选项已弃用，其行为与 Shape 相同。</para>
		/// <para>END - 此选项已弃用，其行为与 Shape 相同。</para>
		/// <para>默认值是在所有网络源上定位，但通过运行融合网络工具创建的替代交汇点和系统交汇点除外。</para>
		/// <para>如果输入要素是网络分析图层的子图层，则此参数的默认值由存储在输入网络分析图层中的位置属性确定。 如果网络分析图层具有所选子图层的位置设置替代，则将使用这些设置。 否则，将使用网络分析图层的默认位置设置。 为此参数设置非默认值将更新网络分析图层的位置设置，覆盖选定子图层。</para>
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
		/// <para>Source ID Field</para>
		/// <para>要创建或更新的字段的名称，将使用输入要素已计算网络位置的网络数据集源要素类的 ID 进行填充。 默认值为 SourceID。</para>
		/// <para>计算线或面要素的位置时，不使用该参数。</para>
		/// <para>当输入要素为网络分析图层的子图层时，请勿使用此参数。 子图层中的网络位置必须以默认名称存储在位置字段中，否则在求解图层时将不会使用它们。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		[Category("Network Location Fields")]
		public object? SourceIDField { get; set; }

		/// <summary>
		/// <para>Source OID Field</para>
		/// <para>要创建或更新的字段的名称，将使用输入要素已计算网络位置的网络数据集源要素类的 ObjectID 字段值进行填充。 默认值为 SourceOID。</para>
		/// <para>计算线或面要素的位置时，不使用该参数。</para>
		/// <para>当输入要素为网络分析图层的子图层时，请勿使用此参数。 子图层中的网络位置必须以默认名称存储在位置字段中，否则在求解图层时将不会使用它们。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		[Category("Network Location Fields")]
		public object? SourceOIDField { get; set; }

		/// <summary>
		/// <para>Percent Along Field</para>
		/// <para>要创建或更新的字段的名称，用于描述已计算网络位置沿其所在网络元素的延伸百分比。 默认值为 PosAlong。</para>
		/// <para>计算线或面要素的位置时，不使用该参数。</para>
		/// <para>当输入要素为网络分析图层的子图层时，请勿使用此参数。 子图层中的网络位置必须以默认名称存储在位置字段中，否则在求解图层时将不会使用它们。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double")]
		[Category("Network Location Fields")]
		public object? PositionField { get; set; }

		/// <summary>
		/// <para>Side of Edge Field</para>
		/// <para>要创建或更新的字段的名称，用于描述已计算网络位置所在的网络边缘侧。 默认值为 SideOfEdge。</para>
		/// <para>计算线或面要素的位置时，不使用该参数。</para>
		/// <para>当输入要素为网络分析图层的子图层时，请勿使用此参数。 子图层中的网络位置必须以默认名称存储在位置字段中，否则在求解图层时将不会使用它们。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		[Category("Network Location Fields")]
		public object? SideField { get; set; }

		/// <summary>
		/// <para>Located X-Coordinate Field</para>
		/// <para>要使用已计算网络位置的 x 坐标创建或更新的字段名称。 默认值为 SnapX。</para>
		/// <para>计算线或面要素的位置时，不使用该参数。</para>
		/// <para>当输入要素为网络分析图层的子图层时，请勿使用此参数。 子图层中的网络位置必须以默认名称存储在位置字段中，否则在求解图层时将不会使用它们。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double")]
		[Category("Network Location Fields")]
		public object? SnapXField { get; set; }

		/// <summary>
		/// <para>Located Y-Coordinate Field</para>
		/// <para>要使用已计算网络位置的 y 坐标创建或更新的字段名称。 默认值为 SnapY。</para>
		/// <para>计算线或面要素的位置时，不使用该参数。</para>
		/// <para>当输入要素为网络分析图层的子图层时，请勿使用此参数。 子图层中的网络位置必须以默认名称存储在位置字段中，否则在求解图层时将不会使用它们。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double")]
		[Category("Network Location Fields")]
		public object? SnapYField { get; set; }

		/// <summary>
		/// <para>Distance from Feature Field</para>
		/// <para>要创建或更新的字段的名称，用于描述原始点要素与其已计算网络位置之间的距离（以米为单位）。 默认值为 DistanceToNetworkInMeters。</para>
		/// <para>计算线或面要素的位置时，不使用该参数。</para>
		/// <para>当输入要素为网络分析图层的子图层时，请勿使用此参数。 子图层中的网络位置必须以默认名称存储在位置字段中，否则在求解图层时将不会使用它们。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double")]
		[Category("Network Location Fields")]
		public object? DistanceField { get; set; }

		/// <summary>
		/// <para>Located Z-Coordinate Field</para>
		/// <para>要使用已计算网络位置的 z 坐标创建或更新的字段的名称。 默认值为 SnapZ。</para>
		/// <para>仅当输入的网络数据集支持基于网络源的 z 坐标值的连通性时，才会使用该参数。</para>
		/// <para>计算线或面要素的位置时，不使用该参数。</para>
		/// <para>当输入要素为网络分析图层的子图层时，请勿使用此参数。 子图层中的网络位置必须以默认名称存储在位置字段中，否则在求解图层时将不会使用它们。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double")]
		[Category("Network Location Fields")]
		public object? SnapZField { get; set; }

		/// <summary>
		/// <para>Location Ranges Field</para>
		/// <para>要使用线或面要素的计算的网络位置的位置范围创建或更新的字段的名称。 默认值为 Locations。</para>
		/// <para>仅当计算线或面要素的位置时，才会使用此参数。</para>
		/// <para>当输入要素为网络分析图层的子图层时，请勿使用此参数。 子图层中的网络位置必须以默认名称存储在位置字段中，否则在求解图层时将不会使用它们。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Blob")]
		[Category("Network Location Fields")]
		public object? LocationField { get; set; }

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
		/// <para>默认情况下，不对任何源使用查询。</para>
		/// <para>如果输入要素是网络分析图层的子图层，则此参数的默认值由存储在输入网络分析图层中的位置属性确定。 如果网络分析图层具有所选子图层的位置设置替代，则将使用这些设置。 否则，将使用网络分析图层的默认位置设置。 为此参数设置非默认值将更新网络分析图层的位置设置，覆盖选定子图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Advanced")]
		public object? SearchQuery { get; set; }

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline", "Polygon")]
		public object? OutPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>将使用的出行模式的名称。</para>
		/// <para>如果选择了一个出行模式，那么将在计算网络位置时进行出行模式设置（例如限制和阻抗属性）。 例如，在应用所选出行模式时，如果距离输入点之一最近的网络边缘受到限制，则该工具将定位下一条不受限制的网络边缘上的点。</para>
		/// <para>可用出行模式取决于输入分析网络参数值。</para>
		/// <para>如果将网络分析图层的子图层用作输入要素，则将隐藏此参数并且不应使用此参数。 在计算网络位置时，将自动使用网络分析图层的当前出行模式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TravelMode { get; set; }

		/// <summary>
		/// <para>Network Analyst Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object? OutputLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateLocations SetEnviroment(object? workspace = null )
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
