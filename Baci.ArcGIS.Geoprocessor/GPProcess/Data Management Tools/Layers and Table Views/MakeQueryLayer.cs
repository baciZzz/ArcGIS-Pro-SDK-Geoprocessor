using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Make Query Layer</para>
	/// <para>创建查询图层</para>
	/// <para>基于输入的 SQL 选择语句，从 DBMS 表创建查询图层。</para>
	/// </summary>
	public class MakeQueryLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>包含要查询的数据的数据库连接文件。</para>
		/// </param>
		/// <param name="OutLayerName">
		/// <para>Output Layer Name</para>
		/// <para>要创建的要素图层或表视图的输出名称。</para>
		/// </param>
		/// <param name="Query">
		/// <para>Query</para>
		/// <para>定义要在数据库中执行的选择查询的 SQL 语句。</para>
		/// <para>此字符串在启用其余控件之前必须通过验证。在您单击此输入框以外的位置时，验证将被触发。验证过程将在数据库中执行查询，并验证 SQL 查询的结果是否符合 ArcGIS 所实施的数据建模标准。如果验证失败，工具将返回一条警告。唯一例外的是 Model Builder，在这种情况下，如果输入为派生的数据，则不会触发验证。</para>
		/// <para>验证规则如下：</para>
		/// <para>SQL 查询的结果只能包含一个空间字段。</para>
		/// <para>SQL 查询的结果只能包含一个空间参考。</para>
		/// <para>SQL 查询的结果必须只有一种实体类型，例如，点、多点、线或面。</para>
		/// <para>SQL 查询的结果不能有任何 ArcGIS 不支持的字段类型；ArcGIS 字段数据类型描述 ArcGIS 支持的字段类型。</para>
		/// <para>如果所使用的空间数据库中的数据执行的标准与 ArcGIS 不同，则验证尤为重要。</para>
		/// </param>
		public MakeQueryLayer(object InputDatabase, object OutLayerName, object Query)
		{
			this.InputDatabase = InputDatabase;
			this.OutLayerName = OutLayerName;
			this.Query = Query;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建查询图层</para>
		/// </summary>
		public override string DisplayName() => "创建查询图层";

		/// <summary>
		/// <para>Tool Name : MakeQueryLayer</para>
		/// </summary>
		public override string ToolName() => "MakeQueryLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeQueryLayer</para>
		/// </summary>
		public override string ExcuteName() => "management.MakeQueryLayer";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputDatabase, OutLayerName, Query, OidFields!, ShapeType!, Srid!, SpatialReference!, OutLayer!, SpatialProperties!, MValues!, ZValues!, Extent! };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>包含要查询的数据的数据库连接文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Output Layer Name</para>
		/// <para>要创建的要素图层或表视图的输出名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutLayerName { get; set; }

		/// <summary>
		/// <para>Query</para>
		/// <para>定义要在数据库中执行的选择查询的 SQL 语句。</para>
		/// <para>此字符串在启用其余控件之前必须通过验证。在您单击此输入框以外的位置时，验证将被触发。验证过程将在数据库中执行查询，并验证 SQL 查询的结果是否符合 ArcGIS 所实施的数据建模标准。如果验证失败，工具将返回一条警告。唯一例外的是 Model Builder，在这种情况下，如果输入为派生的数据，则不会触发验证。</para>
		/// <para>验证规则如下：</para>
		/// <para>SQL 查询的结果只能包含一个空间字段。</para>
		/// <para>SQL 查询的结果只能包含一个空间参考。</para>
		/// <para>SQL 查询的结果必须只有一种实体类型，例如，点、多点、线或面。</para>
		/// <para>SQL 查询的结果不能有任何 ArcGIS 不支持的字段类型；ArcGIS 字段数据类型描述 ArcGIS 支持的字段类型。</para>
		/// <para>如果所使用的空间数据库中的数据执行的标准与 ArcGIS 不同，则验证尤为重要。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Query { get; set; }

		/// <summary>
		/// <para>Unique Identifier Field(s)</para>
		/// <para>SELECT 列表的 SELECT 语句中的一个或多个字段，可用于生成动态的唯一行标识符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? OidFields { get; set; }

		/// <summary>
		/// <para>Shape Type</para>
		/// <para>指定查询图层的形状类型。在输出查询图层中只会使用查询结果集中与指定形状类型匹配的那些记录。工具验证将尝试根据结果集中的第一条记录设置此属性。如果形状类型不是所需的输出形状类型，则执行工具之前可对此进行更改。如果查询结果集未返回几何字段，则忽略此参数。</para>
		/// <para>点—输出查询图层将使用点几何。</para>
		/// <para>多点—输出查询图层将使用多点几何。</para>
		/// <para>Polygon—输出查询图层将使用面几何。</para>
		/// <para>折线—输出查询图层将使用折线几何。</para>
		/// <para><see cref="ShapeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ShapeType { get; set; }

		/// <summary>
		/// <para>SRID</para>
		/// <para>返回几何查询的空间参考标识符 (SRID) 值。在输出查询图层中只会使用查询结果集中与指定 SRID 值匹配的那些记录。工具验证将尝试根据结果集中的第一条记录设置此属性。如果 SRID 值不是所需的输出 SRID 值，则执行工具之前可对此进行更改。如果查询结果集未返回几何字段，则忽略此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Srid { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>输出查询图层将使用的坐标系。工具验证将尝试根据结果集中的第一条记录设置此属性。如果坐标系不是所需的输出坐标系，则执行工具之前可对此进行更改。如果查询结果集未返回几何字段，则忽略此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object? SpatialReference { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object? OutLayer { get; set; }

		/// <summary>
		/// <para>Define the spatial properties of the layer</para>
		/// <para>指定图层空间属性的定义方式。</para>
		/// <para>验证过程中，系统将为查询图层设定维数、几何类型、空间参考、SRID 以及唯一标识符属性。这些值取决于查询返回的第一行。要手动定义这些属性，而不是使用查询表的工具来获取，默认情况下需选中定义图层的空间属性参数。</para>
		/// <para>选中 - 手动定义图层的空间属性。这是默认设置。</para>
		/// <para>未选中 - 图层属性将根据查询中返回的第一行确定。</para>
		/// <para><see cref="SpatialPropertiesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SpatialProperties { get; set; } = "true";

		/// <summary>
		/// <para>Coordinates include M values</para>
		/// <para>指定图层是否具有 m 值。</para>
		/// <para>选中 - 图层将包含 m 值。</para>
		/// <para>未选中 - 图层将不包含 m 值。这是默认设置。</para>
		/// <para><see cref="MValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? MValues { get; set; } = "false";

		/// <summary>
		/// <para>Coordinates include Z values</para>
		/// <para>指定图层是否包含 z 值。</para>
		/// <para>选中 - 图层将包含 z 值。</para>
		/// <para>未选中 - 图层将不包含 z 值。这是默认设置。</para>
		/// <para><see cref="ZValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ZValues { get; set; } = "false";

		/// <summary>
		/// <para>Extent</para>
		/// <para>图层的范围。此参数只有在定义图层的空间属性选中的状态下才能使用（Python 中的 spatial_properties = DEFINE_SPATIAL_PROPERTIES）。范围必须包括表中的所有要素。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>当前显示范围 - 该范围与数据框或可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object? Extent { get; set; } = "0 0 0 0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeQueryLayer SetEnviroment(object? outputCoordinateSystem = null, object? workspace = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Shape Type</para>
		/// </summary>
		public enum ShapeTypeEnum 
		{
			/// <summary>
			/// <para>点—输出查询图层将使用点几何。</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("点")]
			Point,

			/// <summary>
			/// <para>多点—输出查询图层将使用多点几何。</para>
			/// </summary>
			[GPValue("MULTIPOINT")]
			[Description("多点")]
			Multipoint,

			/// <summary>
			/// <para>Polygon—输出查询图层将使用面几何。</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("Polygon")]
			Polygon,

			/// <summary>
			/// <para>折线—输出查询图层将使用折线几何。</para>
			/// </summary>
			[GPValue("POLYLINE")]
			[Description("折线")]
			Polyline,

		}

		/// <summary>
		/// <para>Define the spatial properties of the layer</para>
		/// </summary>
		public enum SpatialPropertiesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DEFINE_SPATIAL_PROPERTIES")]
			DEFINE_SPATIAL_PROPERTIES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_DEFINE_SPATIAL_PROPERTIES")]
			DO_NOT_DEFINE_SPATIAL_PROPERTIES,

		}

		/// <summary>
		/// <para>Coordinates include M values</para>
		/// </summary>
		public enum MValuesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_M_VALUES")]
			INCLUDE_M_VALUES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_INCLUDE_M_VALUES")]
			DO_NOT_INCLUDE_M_VALUES,

		}

		/// <summary>
		/// <para>Coordinates include Z values</para>
		/// </summary>
		public enum ZValuesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_Z_VALUES")]
			INCLUDE_Z_VALUES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_INCLUDE_Z_VALUES")]
			DO_NOT_INCLUDE_Z_VALUES,

		}

#endregion
	}
}
