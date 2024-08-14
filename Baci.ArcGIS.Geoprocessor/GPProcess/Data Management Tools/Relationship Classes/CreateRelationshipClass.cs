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
	/// <para>This tool creates a relationship class to store an association between fields or features in the origin table and the destination table.</para>
	/// </summary>
	public class CreateRelationshipClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OriginTable">
		/// <para>Origin Table</para>
		/// <para>The table or feature class that is associated to the destination table.</para>
		/// </param>
		/// <param name="DestinationTable">
		/// <para>Destination Table</para>
		/// <para>The table that is associated to the origin table.</para>
		/// </param>
		/// <param name="OutRelationshipClass">
		/// <para>Output Relationship Class</para>
		/// <para>The relationship class that is created.</para>
		/// </param>
		/// <param name="RelationshipType">
		/// <para>Relationship Type</para>
		/// <para>The type of relationship to create between the origin and destination tables.</para>
		/// <para>Simple—A relationship between independent objects (parent to parent). This is the default.</para>
		/// <para>Composite—A relationship between dependent objects where the lifetime of one object controls the lifetime of the related object (parent to child).</para>
		/// <para><see cref="RelationshipTypeEnum"/></para>
		/// </param>
		/// <param name="ForwardLabel">
		/// <para>Forward Path Label</para>
		/// <para>A name to uniquely identify the relationship when navigating from the origin table to the destination table.</para>
		/// </param>
		/// <param name="BackwardLabel">
		/// <para>Backward Path label</para>
		/// <para>A name to uniquely identify the relationship when navigating from the destination table to the origin table.</para>
		/// </param>
		/// <param name="MessageDirection">
		/// <para>Message Direction</para>
		/// <para>The direction in which messages are passed between the origin and destination tables. For example, in a relationship between poles and transformers, when the pole is deleted, it sends a message to its related transformer objects informing them it was deleted.</para>
		/// <para>Forward (origin to destination)—Messages are passed from the origin to the destination table.</para>
		/// <para>Backward (destination to origin)—Messages are passed from the destination to the origin table.</para>
		/// <para>Both directions—Messages are passed from the origin to the destination table and from the destination to the origin table.</para>
		/// <para>None (no messages propagated)—No messages passed. This is the default.</para>
		/// <para><see cref="MessageDirectionEnum"/></para>
		/// </param>
		/// <param name="Cardinality">
		/// <para>Cardinality</para>
		/// <para>Determines how many relationships exist between rows or features in the origin and rows or features in the destination table.</para>
		/// <para>One to one (1:1)—Each row or feature in the origin table can be related to zero or one row or feature in the destination table. This is the default.</para>
		/// <para>One to many (1:M)—Each row or feature in the origin table can be related to one or several rows or features in the destination table.</para>
		/// <para>Many to many (M:N)—Several fields or features in the origin table can be related to one or several rows or features in the destination table.</para>
		/// <para><see cref="CardinalityEnum"/></para>
		/// </param>
		/// <param name="Attributed">
		/// <para>Relationship class is attributed</para>
		/// <para>Specifies if the relationship will have attributes.</para>
		/// <para>Checked—Indicates the relationship class will have attributes.</para>
		/// <para>Unchecked—Indicates the relationship class will not have attributes. This is the default.</para>
		/// <para><see cref="AttributedEnum"/></para>
		/// </param>
		/// <param name="OriginPrimaryKey">
		/// <para>Origin Primary Key</para>
		/// <para>The field in the origin table, typically the OID field, that links it to the Origin Foreign Key field in the relationship class table.</para>
		/// </param>
		/// <param name="OriginForeignKey">
		/// <para>Origin Foreign Key</para>
		/// <para>The field in the relationship class table that links it to the Origin Primary Key field in the origin table.</para>
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
		/// <para>Tool Display Name : Create Relationship Class</para>
		/// </summary>
		public override string DisplayName => "Create Relationship Class";

		/// <summary>
		/// <para>Tool Name : CreateRelationshipClass</para>
		/// </summary>
		public override string ToolName => "CreateRelationshipClass";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateRelationshipClass</para>
		/// </summary>
		public override string ExcuteName => "management.CreateRelationshipClass";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "autoCommit", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { OriginTable, DestinationTable, OutRelationshipClass, RelationshipType, ForwardLabel, BackwardLabel, MessageDirection, Cardinality, Attributed, OriginPrimaryKey, OriginForeignKey, DestinationPrimaryKey, DestinationForeignKey };

		/// <summary>
		/// <para>Origin Table</para>
		/// <para>The table or feature class that is associated to the destination table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object OriginTable { get; set; }

		/// <summary>
		/// <para>Destination Table</para>
		/// <para>The table that is associated to the origin table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object DestinationTable { get; set; }

		/// <summary>
		/// <para>Output Relationship Class</para>
		/// <para>The relationship class that is created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERelationshipClass()]
		public object OutRelationshipClass { get; set; }

		/// <summary>
		/// <para>Relationship Type</para>
		/// <para>The type of relationship to create between the origin and destination tables.</para>
		/// <para>Simple—A relationship between independent objects (parent to parent). This is the default.</para>
		/// <para>Composite—A relationship between dependent objects where the lifetime of one object controls the lifetime of the related object (parent to child).</para>
		/// <para><see cref="RelationshipTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RelationshipType { get; set; } = "SIMPLE";

		/// <summary>
		/// <para>Forward Path Label</para>
		/// <para>A name to uniquely identify the relationship when navigating from the origin table to the destination table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ForwardLabel { get; set; }

		/// <summary>
		/// <para>Backward Path label</para>
		/// <para>A name to uniquely identify the relationship when navigating from the destination table to the origin table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object BackwardLabel { get; set; }

		/// <summary>
		/// <para>Message Direction</para>
		/// <para>The direction in which messages are passed between the origin and destination tables. For example, in a relationship between poles and transformers, when the pole is deleted, it sends a message to its related transformer objects informing them it was deleted.</para>
		/// <para>Forward (origin to destination)—Messages are passed from the origin to the destination table.</para>
		/// <para>Backward (destination to origin)—Messages are passed from the destination to the origin table.</para>
		/// <para>Both directions—Messages are passed from the origin to the destination table and from the destination to the origin table.</para>
		/// <para>None (no messages propagated)—No messages passed. This is the default.</para>
		/// <para><see cref="MessageDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MessageDirection { get; set; } = "NONE";

		/// <summary>
		/// <para>Cardinality</para>
		/// <para>Determines how many relationships exist between rows or features in the origin and rows or features in the destination table.</para>
		/// <para>One to one (1:1)—Each row or feature in the origin table can be related to zero or one row or feature in the destination table. This is the default.</para>
		/// <para>One to many (1:M)—Each row or feature in the origin table can be related to one or several rows or features in the destination table.</para>
		/// <para>Many to many (M:N)—Several fields or features in the origin table can be related to one or several rows or features in the destination table.</para>
		/// <para><see cref="CardinalityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Cardinality { get; set; } = "ONE_TO_ONE";

		/// <summary>
		/// <para>Relationship class is attributed</para>
		/// <para>Specifies if the relationship will have attributes.</para>
		/// <para>Checked—Indicates the relationship class will have attributes.</para>
		/// <para>Unchecked—Indicates the relationship class will not have attributes. This is the default.</para>
		/// <para><see cref="AttributedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Attributed { get; set; } = "false";

		/// <summary>
		/// <para>Origin Primary Key</para>
		/// <para>The field in the origin table, typically the OID field, that links it to the Origin Foreign Key field in the relationship class table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OriginPrimaryKey { get; set; }

		/// <summary>
		/// <para>Origin Foreign Key</para>
		/// <para>The field in the relationship class table that links it to the Origin Primary Key field in the origin table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OriginForeignKey { get; set; }

		/// <summary>
		/// <para>Destination Primary Key</para>
		/// <para>The field in the destination table, typically the OID field, that links it to the Destination Foreign Key field in the relationship class table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DestinationPrimaryKey { get; set; }

		/// <summary>
		/// <para>Destination Foreign Key</para>
		/// <para>The field in the relationship class table that links it to the Destination Primary Key field in the destination table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DestinationForeignKey { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateRelationshipClass SetEnviroment(int? autoCommit = null , object workspace = null )
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
			/// <para>Simple—A relationship between independent objects (parent to parent). This is the default.</para>
			/// </summary>
			[GPValue("SIMPLE")]
			[Description("Simple")]
			Simple,

			/// <summary>
			/// <para>Composite—A relationship between dependent objects where the lifetime of one object controls the lifetime of the related object (parent to child).</para>
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
			/// <para>Forward (origin to destination)—Messages are passed from the origin to the destination table.</para>
			/// </summary>
			[GPValue("FORWARD")]
			[Description("Forward (origin to destination)")]
			FORWARD,

			/// <summary>
			/// <para>Backward (destination to origin)—Messages are passed from the destination to the origin table.</para>
			/// </summary>
			[GPValue("BACKWARD")]
			[Description("Backward (destination to origin)")]
			BACKWARD,

			/// <summary>
			/// <para>Both directions—Messages are passed from the origin to the destination table and from the destination to the origin table.</para>
			/// </summary>
			[GPValue("BOTH")]
			[Description("Both directions")]
			Both_directions,

			/// <summary>
			/// <para>None (no messages propagated)—No messages passed. This is the default.</para>
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
			/// <para>One to one (1:1)—Each row or feature in the origin table can be related to zero or one row or feature in the destination table. This is the default.</para>
			/// </summary>
			[GPValue("ONE_TO_ONE")]
			[Description("One to one (1:1)")]
			ONE_TO_ONE,

			/// <summary>
			/// <para>One to many (1:M)—Each row or feature in the origin table can be related to one or several rows or features in the destination table.</para>
			/// </summary>
			[GPValue("ONE_TO_MANY")]
			[Description("One to many (1:M)")]
			ONE_TO_MANY,

			/// <summary>
			/// <para>Many to many (M:N)—Several fields or features in the origin table can be related to one or several rows or features in the destination table.</para>
			/// </summary>
			[GPValue("MANY_TO_MANY")]
			[Description("Many to many (M:N)")]
			MANY_TO_MANY,

		}

		/// <summary>
		/// <para>Relationship class is attributed</para>
		/// </summary>
		public enum AttributedEnum 
		{
			/// <summary>
			/// <para>Checked—Indicates the relationship class will have attributes.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ATTRIBUTED")]
			ATTRIBUTED,

			/// <summary>
			/// <para>Unchecked—Indicates the relationship class will not have attributes. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

#endregion
	}
}
