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
	/// <para>Table To Relationship Class</para>
	/// <para>表转关系类</para>
	/// <para>通过源表、目标表和关系表创建属性关系类。</para>
	/// </summary>
	public class TableToRelationshipClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OriginTable">
		/// <para>Origin Table</para>
		/// <para>将与目标表关联的表或要素类。</para>
		/// </param>
		/// <param name="DestinationTable">
		/// <para>Destination Table</para>
		/// <para>将与源表关联的表或要素类。</para>
		/// </param>
		/// <param name="OutRelationshipClass">
		/// <para>Output Relationship Class</para>
		/// <para>将创建的关系类。</para>
		/// </param>
		/// <param name="RelationshipType">
		/// <para>Relationship Type</para>
		/// <para>指定在源表和目标表之间创建的关联类型。</para>
		/// <para>简单—每个对象将彼此独立（父-父关系）。 这是默认设置。</para>
		/// <para>复合—一个对象的生存时间将控制其相关对象的生存时间（父-子关系）。</para>
		/// <para><see cref="RelationshipTypeEnum"/></para>
		/// </param>
		/// <param name="ForwardLabel">
		/// <para>Forward Path Label</para>
		/// <para>描述从源表或要素类到目标表或要素类遍历时的关系的标注。</para>
		/// </param>
		/// <param name="BackwardLabel">
		/// <para>Backward Path Label</para>
		/// <para>描述从目标表或要素类到源表或要素类遍历时的关系的标注。</para>
		/// </param>
		/// <param name="MessageDirection">
		/// <para>Message Direction</para>
		/// <para>指定消息在此关系所关联的对象之间进行传递时的方向。 例如，在电线杆和变压器之间的关系中，当电线杆被删除时，它会向其相关的变压器对象发送消息，通知电线杆已被删除。</para>
		/// <para>无(不传递任何消息)—不会传递任何消息。 这是默认设置。</para>
		/// <para>向前(源至目标)—消息将从源传递到目标。</para>
		/// <para>向后(目标至源)—消息将从目标传递到源。</para>
		/// <para>两个方向—消息将从源传递到目标，然后从目标传递到源。</para>
		/// <para><see cref="MessageDirectionEnum"/></para>
		/// </param>
		/// <param name="Cardinality">
		/// <para>Cardinality</para>
		/// <para>指定源和目标之间关系的基数。</para>
		/// <para>一对一 (1:1)—源表或要素类中的每个对象都可与目标表或要素类中的零个或一个对象相关联。 这是默认设置。</para>
		/// <para>一对多 (1:M)—源表或要素类的每个对象都可以与目标表或要素类中的多个对象相关。</para>
		/// <para>多对多 (M:N)—源表或要素类的多个对象可以与目标表或要素类中的多个对象相关。</para>
		/// <para><see cref="CardinalityEnum"/></para>
		/// </param>
		/// <param name="RelationshipTable">
		/// <para>Relationship Table</para>
		/// <para>包含将添加到关系类的属性的表。</para>
		/// </param>
		/// <param name="AttributeFields">
		/// <para>Attribute Fields</para>
		/// <para>字段名称，此字段包含将添加到关系类的属性值。 字段必须存在于关系表参数值中。</para>
		/// </param>
		/// <param name="OriginPrimaryKey">
		/// <para>Origin Primary Key</para>
		/// <para>将用于创建关系的源表中的字段。</para>
		/// </param>
		/// <param name="OriginForeignKey">
		/// <para>Origin Foreign Key</para>
		/// <para>关系表中的字段名称，引用源表或要素类中的主键字段。 对于基于表的关系类，这些值用于填充关系类中的关系，因此不能为空。</para>
		/// </param>
		/// <param name="DestinationPrimaryKey">
		/// <para>Destination primary key</para>
		/// <para>将用于创建关系的目标表中的字段。</para>
		/// </param>
		/// <param name="DestinationForeignKey">
		/// <para>Destination Foreign Key</para>
		/// <para>关系表中的字段，引用目标表或要素类中主键字段。 对于基于表的关系类，这些值用于填充关系类中的关系，因此不能为空。</para>
		/// </param>
		public TableToRelationshipClass(object OriginTable, object DestinationTable, object OutRelationshipClass, object RelationshipType, object ForwardLabel, object BackwardLabel, object MessageDirection, object Cardinality, object RelationshipTable, object AttributeFields, object OriginPrimaryKey, object OriginForeignKey, object DestinationPrimaryKey, object DestinationForeignKey)
		{
			this.OriginTable = OriginTable;
			this.DestinationTable = DestinationTable;
			this.OutRelationshipClass = OutRelationshipClass;
			this.RelationshipType = RelationshipType;
			this.ForwardLabel = ForwardLabel;
			this.BackwardLabel = BackwardLabel;
			this.MessageDirection = MessageDirection;
			this.Cardinality = Cardinality;
			this.RelationshipTable = RelationshipTable;
			this.AttributeFields = AttributeFields;
			this.OriginPrimaryKey = OriginPrimaryKey;
			this.OriginForeignKey = OriginForeignKey;
			this.DestinationPrimaryKey = DestinationPrimaryKey;
			this.DestinationForeignKey = DestinationForeignKey;
		}

		/// <summary>
		/// <para>Tool Display Name : 表转关系类</para>
		/// </summary>
		public override string DisplayName() => "表转关系类";

		/// <summary>
		/// <para>Tool Name : TableToRelationshipClass</para>
		/// </summary>
		public override string ToolName() => "TableToRelationshipClass";

		/// <summary>
		/// <para>Tool Excute Name : management.TableToRelationshipClass</para>
		/// </summary>
		public override string ExcuteName() => "management.TableToRelationshipClass";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { OriginTable, DestinationTable, OutRelationshipClass, RelationshipType, ForwardLabel, BackwardLabel, MessageDirection, Cardinality, RelationshipTable, AttributeFields, OriginPrimaryKey, OriginForeignKey, DestinationPrimaryKey, DestinationForeignKey };

		/// <summary>
		/// <para>Origin Table</para>
		/// <para>将与目标表关联的表或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object OriginTable { get; set; }

		/// <summary>
		/// <para>Destination Table</para>
		/// <para>将与源表关联的表或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object DestinationTable { get; set; }

		/// <summary>
		/// <para>Output Relationship Class</para>
		/// <para>将创建的关系类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERelationshipClass()]
		public object OutRelationshipClass { get; set; }

		/// <summary>
		/// <para>Relationship Type</para>
		/// <para>指定在源表和目标表之间创建的关联类型。</para>
		/// <para>简单—每个对象将彼此独立（父-父关系）。 这是默认设置。</para>
		/// <para>复合—一个对象的生存时间将控制其相关对象的生存时间（父-子关系）。</para>
		/// <para><see cref="RelationshipTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RelationshipType { get; set; } = "SIMPLE";

		/// <summary>
		/// <para>Forward Path Label</para>
		/// <para>描述从源表或要素类到目标表或要素类遍历时的关系的标注。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ForwardLabel { get; set; }

		/// <summary>
		/// <para>Backward Path Label</para>
		/// <para>描述从目标表或要素类到源表或要素类遍历时的关系的标注。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object BackwardLabel { get; set; }

		/// <summary>
		/// <para>Message Direction</para>
		/// <para>指定消息在此关系所关联的对象之间进行传递时的方向。 例如，在电线杆和变压器之间的关系中，当电线杆被删除时，它会向其相关的变压器对象发送消息，通知电线杆已被删除。</para>
		/// <para>无(不传递任何消息)—不会传递任何消息。 这是默认设置。</para>
		/// <para>向前(源至目标)—消息将从源传递到目标。</para>
		/// <para>向后(目标至源)—消息将从目标传递到源。</para>
		/// <para>两个方向—消息将从源传递到目标，然后从目标传递到源。</para>
		/// <para><see cref="MessageDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MessageDirection { get; set; } = "NONE";

		/// <summary>
		/// <para>Cardinality</para>
		/// <para>指定源和目标之间关系的基数。</para>
		/// <para>一对一 (1:1)—源表或要素类中的每个对象都可与目标表或要素类中的零个或一个对象相关联。 这是默认设置。</para>
		/// <para>一对多 (1:M)—源表或要素类的每个对象都可以与目标表或要素类中的多个对象相关。</para>
		/// <para>多对多 (M:N)—源表或要素类的多个对象可以与目标表或要素类中的多个对象相关。</para>
		/// <para><see cref="CardinalityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Cardinality { get; set; } = "ONE_TO_ONE";

		/// <summary>
		/// <para>Relationship Table</para>
		/// <para>包含将添加到关系类的属性的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object RelationshipTable { get; set; }

		/// <summary>
		/// <para>Attribute Fields</para>
		/// <para>字段名称，此字段包含将添加到关系类的属性值。 字段必须存在于关系表参数值中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GlobalID", "GUID")]
		public object AttributeFields { get; set; }

		/// <summary>
		/// <para>Origin Primary Key</para>
		/// <para>将用于创建关系的源表中的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OriginPrimaryKey { get; set; }

		/// <summary>
		/// <para>Origin Foreign Key</para>
		/// <para>关系表中的字段名称，引用源表或要素类中的主键字段。 对于基于表的关系类，这些值用于填充关系类中的关系，因此不能为空。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OriginForeignKey { get; set; }

		/// <summary>
		/// <para>Destination primary key</para>
		/// <para>将用于创建关系的目标表中的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DestinationPrimaryKey { get; set; }

		/// <summary>
		/// <para>Destination Foreign Key</para>
		/// <para>关系表中的字段，引用目标表或要素类中主键字段。 对于基于表的关系类，这些值用于填充关系类中的关系，因此不能为空。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DestinationForeignKey { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TableToRelationshipClass SetEnviroment(int? autoCommit = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Relationship Type</para>
		/// </summary>
		public enum RelationshipTypeEnum 
		{
			/// <summary>
			/// <para>简单—每个对象将彼此独立（父-父关系）。 这是默认设置。</para>
			/// </summary>
			[GPValue("SIMPLE")]
			[Description("简单")]
			Simple,

			/// <summary>
			/// <para>复合—一个对象的生存时间将控制其相关对象的生存时间（父-子关系）。</para>
			/// </summary>
			[GPValue("COMPOSITE")]
			[Description("复合")]
			Composite,

		}

		/// <summary>
		/// <para>Message Direction</para>
		/// </summary>
		public enum MessageDirectionEnum 
		{
			/// <summary>
			/// <para>向前(源至目标)—消息将从源传递到目标。</para>
			/// </summary>
			[GPValue("FORWARD")]
			[Description("向前(源至目标)")]
			FORWARD,

			/// <summary>
			/// <para>向后(目标至源)—消息将从目标传递到源。</para>
			/// </summary>
			[GPValue("BACKWARD")]
			[Description("向后(目标至源)")]
			BACKWARD,

			/// <summary>
			/// <para>两个方向—消息将从源传递到目标，然后从目标传递到源。</para>
			/// </summary>
			[GPValue("BOTH")]
			[Description("两个方向")]
			Both_directions,

			/// <summary>
			/// <para>无(不传递任何消息)—不会传递任何消息。 这是默认设置。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无(不传递任何消息)")]
			NONE,

		}

		/// <summary>
		/// <para>Cardinality</para>
		/// </summary>
		public enum CardinalityEnum 
		{
			/// <summary>
			/// <para>一对一 (1:1)—源表或要素类中的每个对象都可与目标表或要素类中的零个或一个对象相关联。 这是默认设置。</para>
			/// </summary>
			[GPValue("ONE_TO_ONE")]
			[Description("一对一 (1:1)")]
			ONE_TO_ONE,

			/// <summary>
			/// <para>一对多 (1:M)—源表或要素类的每个对象都可以与目标表或要素类中的多个对象相关。</para>
			/// </summary>
			[GPValue("ONE_TO_MANY")]
			[Description("一对多 (1:M)")]
			ONE_TO_MANY,

			/// <summary>
			/// <para>多对多 (M:N)—源表或要素类的多个对象可以与目标表或要素类中的多个对象相关。</para>
			/// </summary>
			[GPValue("MANY_TO_MANY")]
			[Description("多对多 (M:N)")]
			MANY_TO_MANY,

		}

#endregion
	}
}
