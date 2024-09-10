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
	/// <para>Creates an attributed relationship class from the origin, destination, and relationship tables.</para>
	/// </summary>
	public class TableToRelationshipClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OriginTable">
		/// <para>Origin Table</para>
		/// <para>The table or feature class that will be associated to the destination table.</para>
		/// </param>
		/// <param name="DestinationTable">
		/// <para>Destination Table</para>
		/// <para>The table or feature class that will be associated to the origin table.</para>
		/// </param>
		/// <param name="OutRelationshipClass">
		/// <para>Output Relationship Class</para>
		/// <para>The relationship class that will be created.</para>
		/// </param>
		/// <param name="RelationshipType">
		/// <para>Relationship Type</para>
		/// <para>The type of association to create between the origin and destination tables.</para>
		/// <para>Simple—An association where each object is independent of each other (a parent-to-parent relationship). This is the default.</para>
		/// <para>Composite—An association where the lifetime of one object controls the lifetime of its related object (a parent-child relationship).</para>
		/// <para><see cref="RelationshipTypeEnum"/></para>
		/// </param>
		/// <param name="ForwardLabel">
		/// <para>Forward Path Label</para>
		/// <para>A label describing the relationship as it is traversed from the origin table/feature class to the destination table/feature class.</para>
		/// </param>
		/// <param name="BackwardLabel">
		/// <para>Backward Path Label</para>
		/// <para>A label describing the relationship as it is traversed from the destination table/feature class to the origin table/feature class.</para>
		/// </param>
		/// <param name="MessageDirection">
		/// <para>Message Direction</para>
		/// <para>The direction messages will be propagated between the objects in the relationship. For example, in a relationship between poles and transformers, when the pole is deleted, it sends a message to its related transformer objects informing them it was deleted.</para>
		/// <para>None (no messages propagated)—No messages propagated. This is the default.</para>
		/// <para>Forward (origin to destination)—Messages propagated from the origin to the destination.</para>
		/// <para>Backward (destination to origin)—Messages propagated from the destination to the origin.</para>
		/// <para>Both directions—Messages propagated from the origin to the destination and from the destination to the origin.</para>
		/// <para><see cref="MessageDirectionEnum"/></para>
		/// </param>
		/// <param name="Cardinality">
		/// <para>Cardinality</para>
		/// <para>The cardinality of the relationship between the origin and destination.</para>
		/// <para>One to one (1:1)—Each object of the origin table/feature class can be related to zero or one object of the destination table/feature class. This is the default.</para>
		/// <para>One to many (1:M)—Each object of the origin table/feature class can be related to multiple objects in the destination table/feature class.</para>
		/// <para>Many to many (M:N)—Multiple objects of the origin table/feature class can be related to multiple objects in the destination table/feature class.</para>
		/// <para><see cref="CardinalityEnum"/></para>
		/// </param>
		/// <param name="RelationshipTable">
		/// <para>Relationship Table</para>
		/// <para>The table containing attributes that will be added to the relationship class.</para>
		/// </param>
		/// <param name="AttributeFields">
		/// <para>Attribute Fields</para>
		/// <para>The fields containing attribute values that will be added to the relationship class.</para>
		/// <para>The Add Field button, which is used only in ModelBuilder, allows you to add expected field(s) so you can complete the dialog and continue to build your model.</para>
		/// </param>
		/// <param name="OriginPrimaryKey">
		/// <para>Origin Primary Key</para>
		/// <para>The field in the origin table that will be used to create the relationship. Generally, this is the object identifier field.</para>
		/// </param>
		/// <param name="OriginForeignKey">
		/// <para>Origin Foreign Key</para>
		/// <para>The name of the Foreign Key field in the relationship table that refers to the Primary Key field in the origin table/feature class.</para>
		/// </param>
		/// <param name="DestinationPrimaryKey">
		/// <para>Destination Primary Key</para>
		/// <para>The field in the destination table that will be used to create the relationship. Generally, this is the object identifier field.</para>
		/// </param>
		/// <param name="DestinationForeignKey">
		/// <para>Destination Foreign Key</para>
		/// <para>The field in the relationship table that refers to the Primary Key field in the destination table.</para>
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
		/// <para>Tool Display Name : Table To Relationship Class</para>
		/// </summary>
		public override string DisplayName() => "Table To Relationship Class";

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
		/// <para>The table or feature class that will be associated to the destination table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object OriginTable { get; set; }

		/// <summary>
		/// <para>Destination Table</para>
		/// <para>The table or feature class that will be associated to the origin table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object DestinationTable { get; set; }

		/// <summary>
		/// <para>Output Relationship Class</para>
		/// <para>The relationship class that will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERelationshipClass()]
		public object OutRelationshipClass { get; set; }

		/// <summary>
		/// <para>Relationship Type</para>
		/// <para>The type of association to create between the origin and destination tables.</para>
		/// <para>Simple—An association where each object is independent of each other (a parent-to-parent relationship). This is the default.</para>
		/// <para>Composite—An association where the lifetime of one object controls the lifetime of its related object (a parent-child relationship).</para>
		/// <para><see cref="RelationshipTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RelationshipType { get; set; } = "SIMPLE";

		/// <summary>
		/// <para>Forward Path Label</para>
		/// <para>A label describing the relationship as it is traversed from the origin table/feature class to the destination table/feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ForwardLabel { get; set; }

		/// <summary>
		/// <para>Backward Path Label</para>
		/// <para>A label describing the relationship as it is traversed from the destination table/feature class to the origin table/feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object BackwardLabel { get; set; }

		/// <summary>
		/// <para>Message Direction</para>
		/// <para>The direction messages will be propagated between the objects in the relationship. For example, in a relationship between poles and transformers, when the pole is deleted, it sends a message to its related transformer objects informing them it was deleted.</para>
		/// <para>None (no messages propagated)—No messages propagated. This is the default.</para>
		/// <para>Forward (origin to destination)—Messages propagated from the origin to the destination.</para>
		/// <para>Backward (destination to origin)—Messages propagated from the destination to the origin.</para>
		/// <para>Both directions—Messages propagated from the origin to the destination and from the destination to the origin.</para>
		/// <para><see cref="MessageDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MessageDirection { get; set; } = "NONE";

		/// <summary>
		/// <para>Cardinality</para>
		/// <para>The cardinality of the relationship between the origin and destination.</para>
		/// <para>One to one (1:1)—Each object of the origin table/feature class can be related to zero or one object of the destination table/feature class. This is the default.</para>
		/// <para>One to many (1:M)—Each object of the origin table/feature class can be related to multiple objects in the destination table/feature class.</para>
		/// <para>Many to many (M:N)—Multiple objects of the origin table/feature class can be related to multiple objects in the destination table/feature class.</para>
		/// <para><see cref="CardinalityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Cardinality { get; set; } = "ONE_TO_ONE";

		/// <summary>
		/// <para>Relationship Table</para>
		/// <para>The table containing attributes that will be added to the relationship class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object RelationshipTable { get; set; }

		/// <summary>
		/// <para>Attribute Fields</para>
		/// <para>The fields containing attribute values that will be added to the relationship class.</para>
		/// <para>The Add Field button, which is used only in ModelBuilder, allows you to add expected field(s) so you can complete the dialog and continue to build your model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GlobalID", "GUID")]
		public object AttributeFields { get; set; }

		/// <summary>
		/// <para>Origin Primary Key</para>
		/// <para>The field in the origin table that will be used to create the relationship. Generally, this is the object identifier field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OriginPrimaryKey { get; set; }

		/// <summary>
		/// <para>Origin Foreign Key</para>
		/// <para>The name of the Foreign Key field in the relationship table that refers to the Primary Key field in the origin table/feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OriginForeignKey { get; set; }

		/// <summary>
		/// <para>Destination Primary Key</para>
		/// <para>The field in the destination table that will be used to create the relationship. Generally, this is the object identifier field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DestinationPrimaryKey { get; set; }

		/// <summary>
		/// <para>Destination Foreign Key</para>
		/// <para>The field in the relationship table that refers to the Primary Key field in the destination table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DestinationForeignKey { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TableToRelationshipClass SetEnviroment(int? autoCommit = null , object workspace = null )
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
			/// <para>Simple—An association where each object is independent of each other (a parent-to-parent relationship). This is the default.</para>
			/// </summary>
			[GPValue("SIMPLE")]
			[Description("Simple")]
			Simple,

			/// <summary>
			/// <para>Composite—An association where the lifetime of one object controls the lifetime of its related object (a parent-child relationship).</para>
			/// </summary>
			[GPValue("COMPOSITE")]
			[Description("Composite")]
			Composite,

		}

		/// <summary>
		/// <para>Message Direction</para>
		/// </summary>
		public enum MessageDirectionEnum 
		{
			/// <summary>
			/// <para>Forward (origin to destination)—Messages propagated from the origin to the destination.</para>
			/// </summary>
			[GPValue("FORWARD")]
			[Description("Forward (origin to destination)")]
			FORWARD,

			/// <summary>
			/// <para>Backward (destination to origin)—Messages propagated from the destination to the origin.</para>
			/// </summary>
			[GPValue("BACKWARD")]
			[Description("Backward (destination to origin)")]
			BACKWARD,

			/// <summary>
			/// <para>Both directions—Messages propagated from the origin to the destination and from the destination to the origin.</para>
			/// </summary>
			[GPValue("BOTH")]
			[Description("Both directions")]
			Both_directions,

			/// <summary>
			/// <para>None (no messages propagated)—No messages propagated. This is the default.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None (no messages propagated)")]
			NONE,

		}

		/// <summary>
		/// <para>Cardinality</para>
		/// </summary>
		public enum CardinalityEnum 
		{
			/// <summary>
			/// <para>One to one (1:1)—Each object of the origin table/feature class can be related to zero or one object of the destination table/feature class. This is the default.</para>
			/// </summary>
			[GPValue("ONE_TO_ONE")]
			[Description("One to one (1:1)")]
			ONE_TO_ONE,

			/// <summary>
			/// <para>One to many (1:M)—Each object of the origin table/feature class can be related to multiple objects in the destination table/feature class.</para>
			/// </summary>
			[GPValue("ONE_TO_MANY")]
			[Description("One to many (1:M)")]
			ONE_TO_MANY,

			/// <summary>
			/// <para>Many to many (M:N)—Multiple objects of the origin table/feature class can be related to multiple objects in the destination table/feature class.</para>
			/// </summary>
			[GPValue("MANY_TO_MANY")]
			[Description("Many to many (M:N)")]
			MANY_TO_MANY,

		}

#endregion
	}
}
