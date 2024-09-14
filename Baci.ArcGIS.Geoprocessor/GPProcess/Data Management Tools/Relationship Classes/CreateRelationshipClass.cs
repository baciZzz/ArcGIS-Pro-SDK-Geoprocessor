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
	/// <para>Create Relationship Class</para>
	/// <para>创建关系类</para>
	/// <para>此工具可创建用于存储源表和目标表中字段或要素之间关联的关系类。</para>
	/// </summary>
	public class CreateRelationshipClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OriginTable">
		/// <para>Origin Table</para>
		/// <para>与目标表相关联的表或要素类。</para>
		/// </param>
		/// <param name="DestinationTable">
		/// <para>Destination Table</para>
		/// <para>与源表相关联的表。</para>
		/// </param>
		/// <param name="OutRelationshipClass">
		/// <para>Output Relationship Class</para>
		/// <para>创建的关系类。</para>
		/// </param>
		/// <param name="RelationshipType">
		/// <para>Relationship Type</para>
		/// <para>要在源表和目标表之间创建的关系类型。</para>
		/// <para>简单—两个独立对象之间的关系（父对父）。这是默认设置。</para>
		/// <para>复合—两个相关对象之间的关系，其中一个对象的生存时间控制相关对象的生存时间（父对子）。</para>
		/// <para><see cref="RelationshipTypeEnum"/></para>
		/// </param>
		/// <param name="ForwardLabel">
		/// <para>Forward Path Label</para>
		/// <para>用于在从源表导航至目标表时唯一识别关系的名称。</para>
		/// </param>
		/// <param name="BackwardLabel">
		/// <para>Backward Path label</para>
		/// <para>用于在从目标表导航至源表时唯一识别关系的名称。</para>
		/// </param>
		/// <param name="MessageDirection">
		/// <para>Message Direction</para>
		/// <para>消息在源表与目标表之间的传递方向。例如，在电线杆与变压器的关系中，当电线杆被删除时，会向与之相关的变压器对象发送一条消息，以告知它们该电线杆已被删除。</para>
		/// <para>向前(源至目标)—将消息从源表传递到目标表。</para>
		/// <para>向后(目标至源)—将消息从目标表传递到源表。</para>
		/// <para>两个方向—将消息从源表传递到目标表，然后再从目标表传递到源表。</para>
		/// <para>无(不传递任何消息)—不传递任何消息。这是默认设置。</para>
		/// <para><see cref="MessageDirectionEnum"/></para>
		/// </param>
		/// <param name="Cardinality">
		/// <para>Cardinality</para>
		/// <para>确定在源表的行或要素与目标表的行或要素之间存在多少种关系。</para>
		/// <para>一对一 (1:1)—源表中的每个行或要素可以与目标表中的零个或一个行或要素相关联。这是默认设置。</para>
		/// <para>一对多 (1:M)—源表中的每个行或要素可与目标表中的一个或多个行或要素相关联。</para>
		/// <para>多对多 (M:N)—源表中的多个字段或要素可与目标表中的一个或多个行或要素相关联。</para>
		/// <para><see cref="CardinalityEnum"/></para>
		/// </param>
		/// <param name="Attributed">
		/// <para>Relationship class is attributed</para>
		/// <para>指定关系是否具有属性。</para>
		/// <para>选中 - 指示关系类将具有属性。</para>
		/// <para>取消选中 - 指示关系类将不具有属性。这是默认设置。</para>
		/// <para><see cref="AttributedEnum"/></para>
		/// </param>
		/// <param name="OriginPrimaryKey">
		/// <para>Origin Primary Key</para>
		/// <para>与关系类表中的源外键字段相关联的源表中的字段（通常指 OID 字段）。</para>
		/// </param>
		/// <param name="OriginForeignKey">
		/// <para>Origin Foreign Key</para>
		/// <para>与源表中的源主键字段相关联的关系类表中的字段。</para>
		/// </param>
		public CreateRelationshipClass(object OriginTable, object DestinationTable, object OutRelationshipClass, object RelationshipType, object ForwardLabel, object BackwardLabel, object MessageDirection, object Cardinality, object Attributed, object OriginPrimaryKey, object OriginForeignKey)
		{
			this.OriginTable = OriginTable;
			this.DestinationTable = DestinationTable;
			this.OutRelationshipClass = OutRelationshipClass;
			this.RelationshipType = RelationshipType;
			this.ForwardLabel = ForwardLabel;
			this.BackwardLabel = BackwardLabel;
			this.MessageDirection = MessageDirection;
			this.Cardinality = Cardinality;
			this.Attributed = Attributed;
			this.OriginPrimaryKey = OriginPrimaryKey;
			this.OriginForeignKey = OriginForeignKey;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建关系类</para>
		/// </summary>
		public override string DisplayName() => "创建关系类";

		/// <summary>
		/// <para>Tool Name : CreateRelationshipClass</para>
		/// </summary>
		public override string ToolName() => "CreateRelationshipClass";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateRelationshipClass</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateRelationshipClass";

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
		public override object[] Parameters() => new object[] { OriginTable, DestinationTable, OutRelationshipClass, RelationshipType, ForwardLabel, BackwardLabel, MessageDirection, Cardinality, Attributed, OriginPrimaryKey, OriginForeignKey, DestinationPrimaryKey, DestinationForeignKey };

		/// <summary>
		/// <para>Origin Table</para>
		/// <para>与目标表相关联的表或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object OriginTable { get; set; }

		/// <summary>
		/// <para>Destination Table</para>
		/// <para>与源表相关联的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object DestinationTable { get; set; }

		/// <summary>
		/// <para>Output Relationship Class</para>
		/// <para>创建的关系类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERelationshipClass()]
		public object OutRelationshipClass { get; set; }

		/// <summary>
		/// <para>Relationship Type</para>
		/// <para>要在源表和目标表之间创建的关系类型。</para>
		/// <para>简单—两个独立对象之间的关系（父对父）。这是默认设置。</para>
		/// <para>复合—两个相关对象之间的关系，其中一个对象的生存时间控制相关对象的生存时间（父对子）。</para>
		/// <para><see cref="RelationshipTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RelationshipType { get; set; } = "SIMPLE";

		/// <summary>
		/// <para>Forward Path Label</para>
		/// <para>用于在从源表导航至目标表时唯一识别关系的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ForwardLabel { get; set; }

		/// <summary>
		/// <para>Backward Path label</para>
		/// <para>用于在从目标表导航至源表时唯一识别关系的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object BackwardLabel { get; set; }

		/// <summary>
		/// <para>Message Direction</para>
		/// <para>消息在源表与目标表之间的传递方向。例如，在电线杆与变压器的关系中，当电线杆被删除时，会向与之相关的变压器对象发送一条消息，以告知它们该电线杆已被删除。</para>
		/// <para>向前(源至目标)—将消息从源表传递到目标表。</para>
		/// <para>向后(目标至源)—将消息从目标表传递到源表。</para>
		/// <para>两个方向—将消息从源表传递到目标表，然后再从目标表传递到源表。</para>
		/// <para>无(不传递任何消息)—不传递任何消息。这是默认设置。</para>
		/// <para><see cref="MessageDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MessageDirection { get; set; } = "NONE";

		/// <summary>
		/// <para>Cardinality</para>
		/// <para>确定在源表的行或要素与目标表的行或要素之间存在多少种关系。</para>
		/// <para>一对一 (1:1)—源表中的每个行或要素可以与目标表中的零个或一个行或要素相关联。这是默认设置。</para>
		/// <para>一对多 (1:M)—源表中的每个行或要素可与目标表中的一个或多个行或要素相关联。</para>
		/// <para>多对多 (M:N)—源表中的多个字段或要素可与目标表中的一个或多个行或要素相关联。</para>
		/// <para><see cref="CardinalityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Cardinality { get; set; } = "ONE_TO_ONE";

		/// <summary>
		/// <para>Relationship class is attributed</para>
		/// <para>指定关系是否具有属性。</para>
		/// <para>选中 - 指示关系类将具有属性。</para>
		/// <para>取消选中 - 指示关系类将不具有属性。这是默认设置。</para>
		/// <para><see cref="AttributedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Attributed { get; set; } = "false";

		/// <summary>
		/// <para>Origin Primary Key</para>
		/// <para>与关系类表中的源外键字段相关联的源表中的字段（通常指 OID 字段）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OriginPrimaryKey { get; set; }

		/// <summary>
		/// <para>Origin Foreign Key</para>
		/// <para>与源表中的源主键字段相关联的关系类表中的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OriginForeignKey { get; set; }

		/// <summary>
		/// <para>Destination Primary Key</para>
		/// <para>与关系类表中的目标外键字段相关联的目标表中的字段（通常指 OID 字段）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DestinationPrimaryKey { get; set; }

		/// <summary>
		/// <para>Destination Foreign Key</para>
		/// <para>与目标表中的目标主键字段相关联的关系类表中的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DestinationForeignKey { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateRelationshipClass SetEnviroment(int? autoCommit = null, object workspace = null)
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
			/// <para>简单—两个独立对象之间的关系（父对父）。这是默认设置。</para>
			/// </summary>
			[GPValue("SIMPLE")]
			[Description("简单")]
			Simple,

			/// <summary>
			/// <para>复合—两个相关对象之间的关系，其中一个对象的生存时间控制相关对象的生存时间（父对子）。</para>
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
			/// <para>向前(源至目标)—将消息从源表传递到目标表。</para>
			/// </summary>
			[GPValue("FORWARD")]
			[Description("向前(源至目标)")]
			FORWARD,

			/// <summary>
			/// <para>向后(目标至源)—将消息从目标表传递到源表。</para>
			/// </summary>
			[GPValue("BACKWARD")]
			[Description("向后(目标至源)")]
			BACKWARD,

			/// <summary>
			/// <para>两个方向—将消息从源表传递到目标表，然后再从目标表传递到源表。</para>
			/// </summary>
			[GPValue("BOTH")]
			[Description("两个方向")]
			Both_directions,

			/// <summary>
			/// <para>无(不传递任何消息)—不传递任何消息。这是默认设置。</para>
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
			/// <para>一对一 (1:1)—源表中的每个行或要素可以与目标表中的零个或一个行或要素相关联。这是默认设置。</para>
			/// </summary>
			[GPValue("ONE_TO_ONE")]
			[Description("一对一 (1:1)")]
			ONE_TO_ONE,

			/// <summary>
			/// <para>一对多 (1:M)—源表中的每个行或要素可与目标表中的一个或多个行或要素相关联。</para>
			/// </summary>
			[GPValue("ONE_TO_MANY")]
			[Description("一对多 (1:M)")]
			ONE_TO_MANY,

			/// <summary>
			/// <para>多对多 (M:N)—源表中的多个字段或要素可与目标表中的一个或多个行或要素相关联。</para>
			/// </summary>
			[GPValue("MANY_TO_MANY")]
			[Description("多对多 (M:N)")]
			MANY_TO_MANY,

		}

		/// <summary>
		/// <para>Relationship class is attributed</para>
		/// </summary>
		public enum AttributedEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ATTRIBUTED")]
			ATTRIBUTED,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

#endregion
	}
}
