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
	/// <para>Create Replica From Server</para>
	/// <para>Create Replica From Server</para>
	/// <para>Creates a replica using a specified list of feature classes, layers, feature datasets, and tables from a remote geodatabase using a geodata service published on ArcGIS Server.</para>
	/// </summary>
	public class CreateReplicaFromServer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeodataservice">
		/// <para>Geodata Service</para>
		/// <para>The geodata service representing the geodatabase from which the replica will be created. The geodatabase referenced by the geodata service must be an enterprise geodatabase.</para>
		/// </param>
		/// <param name="Datasets">
		/// <para>Datasets</para>
		/// <para>The list of the feature datasets, stand-alone feature classes, tables, and stand-alone attributed relationship classes from the geodata service to replicate.</para>
		/// </param>
		/// <param name="InType">
		/// <para>Replica Type</para>
		/// <para>Specifies the type of replica that will be created.</para>
		/// <para>Two way replica— Changes will be sent between child and parent replicas in both directions.</para>
		/// <para>One way replica—Changes will be sent from the parent replica to the child replica only.</para>
		/// <para>Check out replica—Data will be replicated, edited, and checked back in one time.</para>
		/// <para>One way child to parent replica—Changes will be sent from the child replica to the parent replica only.</para>
		/// <para><see cref="InTypeEnum"/></para>
		/// </param>
		/// <param name="OutGeodatabase">
		/// <para>Geodatabase to replicate data to</para>
		/// <para>The local geodatabase that will host the child replica. Geodata services are used to represent remote geodatabases. The geodatabase can be an enterprise or file geodatabase. For two-way replicas, the child geodatabase must be an enterprise geodatabase. For one-way and check-out replicas, the geodatabase can be a file or enterprise geodatabase. File geodatabases must exist before running this tool.</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Replica Name</para>
		/// <para>The name that identifies the replica.</para>
		/// </param>
		/// <param name="Archiving">
		/// <para>Use archiving to track changes for 1 way replication</para>
		/// <para>Specifies whether the archive class will be used to track changes instead of the versioning delta tables. This is only available for one-way replicas.</para>
		/// <para>Checked—Archiving will be used to track changes.</para>
		/// <para>Not checked—Archiving will not be used to track changes. This is the default.</para>
		/// <para><see cref="ArchivingEnum"/></para>
		/// </param>
		public CreateReplicaFromServer(object InGeodataservice, object Datasets, object InType, object OutGeodatabase, object OutName, object Archiving)
		{
			this.InGeodataservice = InGeodataservice;
			this.Datasets = Datasets;
			this.InType = InType;
			this.OutGeodatabase = OutGeodatabase;
			this.OutName = OutName;
			this.Archiving = Archiving;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Replica From Server</para>
		/// </summary>
		public override string DisplayName() => "Create Replica From Server";

		/// <summary>
		/// <para>Tool Name : CreateReplicaFromServer</para>
		/// </summary>
		public override string ToolName() => "CreateReplicaFromServer";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateReplicaFromServer</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateReplicaFromServer";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGeodataservice, Datasets, InType, OutGeodatabase, OutName, AccessType!, InitialDataSender!, ExpandFeatureClassesAndTables!, ReuseSchema!, GetRelatedData!, GeometryFeatures!, Archiving, OutGeodata!, OutputName! };

		/// <summary>
		/// <para>Geodata Service</para>
		/// <para>The geodata service representing the geodatabase from which the replica will be created. The geodatabase referenced by the geodata service must be an enterprise geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEGeoDataServer()]
		public object InGeodataservice { get; set; }

		/// <summary>
		/// <para>Datasets</para>
		/// <para>The list of the feature datasets, stand-alone feature classes, tables, and stand-alone attributed relationship classes from the geodata service to replicate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Datasets { get; set; }

		/// <summary>
		/// <para>Replica Type</para>
		/// <para>Specifies the type of replica that will be created.</para>
		/// <para>Two way replica— Changes will be sent between child and parent replicas in both directions.</para>
		/// <para>One way replica—Changes will be sent from the parent replica to the child replica only.</para>
		/// <para>Check out replica—Data will be replicated, edited, and checked back in one time.</para>
		/// <para>One way child to parent replica—Changes will be sent from the child replica to the parent replica only.</para>
		/// <para><see cref="InTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InType { get; set; } = "TWO_WAY_REPLICA";

		/// <summary>
		/// <para>Geodatabase to replicate data to</para>
		/// <para>The local geodatabase that will host the child replica. Geodata services are used to represent remote geodatabases. The geodatabase can be an enterprise or file geodatabase. For two-way replicas, the child geodatabase must be an enterprise geodatabase. For one-way and check-out replicas, the geodatabase can be a file or enterprise geodatabase. File geodatabases must exist before running this tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object OutGeodatabase { get; set; }

		/// <summary>
		/// <para>Replica Name</para>
		/// <para>The name that identifies the replica.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Replica Access Type</para>
		/// <para>Specifies the type of replica access.</para>
		/// <para>Full—Complex types such as topologies, are supported and the data must be versioned. This is the default.</para>
		/// <para>Simple—The data on the child is not versioned and must be simple. This allows the replica to be interoperable. Nonsimple features in the parent (for example, features in topologies) are converted to simple features (for example, point, line, and polygon feature classes).</para>
		/// <para><see cref="AccessTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Setting")]
		public object? AccessType { get; set; } = "FULL";

		/// <summary>
		/// <para>Initial Data Sender</para>
		/// <para>Specifies which replica will send changes when in disconnected mode. If you are working in a connected mode, this parameter is inconsequential. This ensures that the relative replica will not send updates until the changes are first received from the initial data sender.</para>
		/// <para>Child data sender—The child replica will be the initial data sender. This is the default.</para>
		/// <para>Parent data sender—The parent replica will be the initial data sender.</para>
		/// <para><see cref="InitialDataSenderEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Setting")]
		public object? InitialDataSender { get; set; } = "CHILD_DATA_SENDER";

		/// <summary>
		/// <para>Expand Feature Classes and Tables</para>
		/// <para>Specifies whether expanded feature classes and tables—such as those in networks, topologies, or relationship classes—will be added.</para>
		/// <para>Use defaults—The expanded feature classes and tables related to the feature classes and tables in the replica will be added. The default for feature classes is to replicate all features intersecting the spatial filter. If no spatial filter has been provided, all features will be included. The default for tables is to replicate the schema only. This is the default.</para>
		/// <para>Add with schema only—Only the schema for the expanded feature classes and tables will be added.</para>
		/// <para>All rows—All rows for expanded feature classes and tables will be added.</para>
		/// <para>Do not add—No expanded feature classes or tables will be added.</para>
		/// <para><see cref="ExpandFeatureClassesAndTablesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Setting")]
		public object? ExpandFeatureClassesAndTables { get; set; } = "USE_DEFAULTS";

		/// <summary>
		/// <para>Re-use Schema</para>
		/// <para>Specifies whether a geodatabase that contains the schema of the data to be replicated will be reused. This reduces the amount of time required to replicate the data. This parameter is only available for checkout replicas.</para>
		/// <para>Do not reuse—Schema will not be reused. This is the default.</para>
		/// <para>Reuse—Schema will be used.</para>
		/// <para><see cref="ReuseSchemaEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Setting")]
		public object? ReuseSchema { get; set; } = "DO_NOT_REUSE";

		/// <summary>
		/// <para>Replicate Related Data</para>
		/// <para>Specifies whether rows related to rows existing in the replica will be replicated. For example, a feature (f1) is inside the replication filter and a related feature (f2) from another class is outside the filter. Feature f2 is included in the replica if you choose to get related data.</para>
		/// <para>Do not get related—Related data will not be replicated.</para>
		/// <para>Get related—Related data will be replicated. This is the default.</para>
		/// <para><see cref="GetRelatedDataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Setting")]
		public object? GetRelatedData { get; set; } = "GET_RELATED";

		/// <summary>
		/// <para>Replica Geometry Features</para>
		/// <para>The features that will be used to define the area to replicate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline", "Point", "Multipoint")]
		[Category("Advanced Setting")]
		public object? GeometryFeatures { get; set; }

		/// <summary>
		/// <para>Use archiving to track changes for 1 way replication</para>
		/// <para>Specifies whether the archive class will be used to track changes instead of the versioning delta tables. This is only available for one-way replicas.</para>
		/// <para>Checked—Archiving will be used to track changes.</para>
		/// <para>Not checked—Archiving will not be used to track changes. This is the default.</para>
		/// <para><see cref="ArchivingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Setting")]
		public object Archiving { get; set; } = "false";

		/// <summary>
		/// <para>Out GeoData Service</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutGeodata { get; set; }

		/// <summary>
		/// <para>Replica Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutputName { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateReplicaFromServer SetEnviroment(object? configKeyword = null , object? extent = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Replica Type</para>
		/// </summary>
		public enum InTypeEnum 
		{
			/// <summary>
			/// <para>Two way replica— Changes will be sent between child and parent replicas in both directions.</para>
			/// </summary>
			[GPValue("TWO_WAY_REPLICA")]
			[Description("Two way replica")]
			Two_way_replica,

			/// <summary>
			/// <para>One way replica—Changes will be sent from the parent replica to the child replica only.</para>
			/// </summary>
			[GPValue("ONE_WAY_REPLICA")]
			[Description("One way replica")]
			One_way_replica,

			/// <summary>
			/// <para>Check out replica—Data will be replicated, edited, and checked back in one time.</para>
			/// </summary>
			[GPValue("CHECK_OUT")]
			[Description("Check out replica")]
			Check_out_replica,

			/// <summary>
			/// <para>One way child to parent replica—Changes will be sent from the child replica to the parent replica only.</para>
			/// </summary>
			[GPValue("ONE_WAY_CHILD_TO_PARENT_REPLICA")]
			[Description("One way child to parent replica")]
			One_way_child_to_parent_replica,

		}

		/// <summary>
		/// <para>Replica Access Type</para>
		/// </summary>
		public enum AccessTypeEnum 
		{
			/// <summary>
			/// <para>Full—Complex types such as topologies, are supported and the data must be versioned. This is the default.</para>
			/// </summary>
			[GPValue("FULL")]
			[Description("Full")]
			Full,

			/// <summary>
			/// <para>Simple—The data on the child is not versioned and must be simple. This allows the replica to be interoperable. Nonsimple features in the parent (for example, features in topologies) are converted to simple features (for example, point, line, and polygon feature classes).</para>
			/// </summary>
			[GPValue("SIMPLE")]
			[Description("Simple")]
			Simple,

		}

		/// <summary>
		/// <para>Initial Data Sender</para>
		/// </summary>
		public enum InitialDataSenderEnum 
		{
			/// <summary>
			/// <para>Child data sender—The child replica will be the initial data sender. This is the default.</para>
			/// </summary>
			[GPValue("CHILD_DATA_SENDER")]
			[Description("Child data sender")]
			Child_data_sender,

			/// <summary>
			/// <para>Parent data sender—The parent replica will be the initial data sender.</para>
			/// </summary>
			[GPValue("PARENT_DATA_SENDER")]
			[Description("Parent data sender")]
			Parent_data_sender,

		}

		/// <summary>
		/// <para>Expand Feature Classes and Tables</para>
		/// </summary>
		public enum ExpandFeatureClassesAndTablesEnum 
		{
			/// <summary>
			/// <para>Use defaults—The expanded feature classes and tables related to the feature classes and tables in the replica will be added. The default for feature classes is to replicate all features intersecting the spatial filter. If no spatial filter has been provided, all features will be included. The default for tables is to replicate the schema only. This is the default.</para>
			/// </summary>
			[GPValue("USE_DEFAULTS")]
			[Description("Use defaults")]
			Use_defaults,

			/// <summary>
			/// <para>Add with schema only—Only the schema for the expanded feature classes and tables will be added.</para>
			/// </summary>
			[GPValue("ADD_WITH_SCHEMA_ONLY")]
			[Description("Add with schema only")]
			Add_with_schema_only,

			/// <summary>
			/// <para>All rows—All rows for expanded feature classes and tables will be added.</para>
			/// </summary>
			[GPValue("ALL_ROWS")]
			[Description("All rows")]
			All_rows,

			/// <summary>
			/// <para>Do not add—No expanded feature classes or tables will be added.</para>
			/// </summary>
			[GPValue("DO_NOT_ADD")]
			[Description("Do not add")]
			Do_not_add,

		}

		/// <summary>
		/// <para>Re-use Schema</para>
		/// </summary>
		public enum ReuseSchemaEnum 
		{
			/// <summary>
			/// <para>Reuse—Schema will be used.</para>
			/// </summary>
			[GPValue("REUSE")]
			[Description("Reuse")]
			Reuse,

			/// <summary>
			/// <para>Do not reuse—Schema will not be reused. This is the default.</para>
			/// </summary>
			[GPValue("DO_NOT_REUSE")]
			[Description("Do not reuse")]
			Do_not_reuse,

		}

		/// <summary>
		/// <para>Replicate Related Data</para>
		/// </summary>
		public enum GetRelatedDataEnum 
		{
			/// <summary>
			/// <para>Get related—Related data will be replicated. This is the default.</para>
			/// </summary>
			[GPValue("GET_RELATED")]
			[Description("Get related")]
			Get_related,

			/// <summary>
			/// <para>Do not get related—Related data will not be replicated.</para>
			/// </summary>
			[GPValue("DO_NOT_GET_RELATED")]
			[Description("Do not get related")]
			Do_not_get_related,

		}

		/// <summary>
		/// <para>Use archiving to track changes for 1 way replication</para>
		/// </summary>
		public enum ArchivingEnum 
		{
			/// <summary>
			/// <para>Checked—Archiving will be used to track changes.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ARCHIVING")]
			ARCHIVING,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_USE_ARCHIVING")]
			DO_NOT_USE_ARCHIVING,

		}

#endregion
	}
}
