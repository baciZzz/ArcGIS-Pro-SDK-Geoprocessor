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
	/// <para>从服务器创建复本</para>
	/// <para>使用在 ArcGIS Server 上发布的地理数据服务，从远程地理数据库利用指定列表中的要素类、图层、要素数据集和表创建复本。</para>
	/// </summary>
	public class CreateReplicaFromServer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeodataservice">
		/// <para>Geodata Service</para>
		/// <para>表示用于创建复本的地理数据库的地理数据服务。 地理数据服务所引用的地理数据库必须是企业级地理数据库。</para>
		/// </param>
		/// <param name="Datasets">
		/// <para>Datasets</para>
		/// <para>地理数据服务中要复制的要素数据集、独立要素类、表和独立属性关系类的列表。</para>
		/// </param>
		/// <param name="InType">
		/// <para>Replica Type</para>
		/// <para>指定要创建的复本类型。</para>
		/// <para>双向复本—变更将在子复本和父复本之间进行双向发送。</para>
		/// <para>单向复本—变更只能从父复本发送到子复本。</para>
		/// <para>检出复本—一次复制、编辑并检回数据。</para>
		/// <para>“子-父”单向复本—变更只能从子复本发送到父复本。</para>
		/// <para><see cref="InTypeEnum"/></para>
		/// </param>
		/// <param name="OutGeodatabase">
		/// <para>Geodatabase to replicate data to</para>
		/// <para>将托管子复本的本地地理数据库。 地理数据服务用于表示远程地理数据库。 地理数据库可以是企业级或文件地理数据库。 对于双向复本，子地理数据库必须是企业级地理数据库。 对于单向复本和检出复本，地理数据库可以是文件或者企业级地理数据库。 运行此工具前，必须存在文件地理数据库。</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Replica Name</para>
		/// <para>用于识别复本的名称。</para>
		/// </param>
		/// <param name="Archiving">
		/// <para>Use archiving to track changes for 1 way replication</para>
		/// <para>指定是否使用存档类来追踪变更而非对增量表进行版本化。 这仅适用于单向复本。</para>
		/// <para>选中 - 存档将用于追踪变更。</para>
		/// <para>未选中 - 存档将不会用于追踪变更。 这是默认设置。</para>
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
		/// <para>Tool Display Name : 从服务器创建复本</para>
		/// </summary>
		public override string DisplayName() => "从服务器创建复本";

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
		/// <para>表示用于创建复本的地理数据库的地理数据服务。 地理数据服务所引用的地理数据库必须是企业级地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEGeoDataServer()]
		public object InGeodataservice { get; set; }

		/// <summary>
		/// <para>Datasets</para>
		/// <para>地理数据服务中要复制的要素数据集、独立要素类、表和独立属性关系类的列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Datasets { get; set; }

		/// <summary>
		/// <para>Replica Type</para>
		/// <para>指定要创建的复本类型。</para>
		/// <para>双向复本—变更将在子复本和父复本之间进行双向发送。</para>
		/// <para>单向复本—变更只能从父复本发送到子复本。</para>
		/// <para>检出复本—一次复制、编辑并检回数据。</para>
		/// <para>“子-父”单向复本—变更只能从子复本发送到父复本。</para>
		/// <para><see cref="InTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InType { get; set; } = "TWO_WAY_REPLICA";

		/// <summary>
		/// <para>Geodatabase to replicate data to</para>
		/// <para>将托管子复本的本地地理数据库。 地理数据服务用于表示远程地理数据库。 地理数据库可以是企业级或文件地理数据库。 对于双向复本，子地理数据库必须是企业级地理数据库。 对于单向复本和检出复本，地理数据库可以是文件或者企业级地理数据库。 运行此工具前，必须存在文件地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object OutGeodatabase { get; set; }

		/// <summary>
		/// <para>Replica Name</para>
		/// <para>用于识别复本的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Replica Access Type</para>
		/// <para>指定要创建的复本访问类型。</para>
		/// <para>全部—支持复杂类型（例如拓扑），并且必须对数据进行版本化。 这是默认设置。</para>
		/// <para>简单—子复本上的数据不可版本化且必须为简单形式。 将允许复本互相操作。 在复制期间，父地理数据库中的非简单要素（例如，拓扑中的要素）转换为简单要素（例如点、线和面要素类）。</para>
		/// <para><see cref="AccessTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Setting")]
		public object? AccessType { get; set; } = "FULL";

		/// <summary>
		/// <para>Initial Data Sender</para>
		/// <para>指定在断开连接模式下哪个复本可发送变更。 如果在连接模式下工作，此参数无关紧要。 这样可确保首先从初始数据发送方接收到变更后，关系复本才发送更新。</para>
		/// <para>子数据发送方—子复本将为初始数据发送方。 这是默认设置。</para>
		/// <para>父数据发送方—父复本将为初始数据发送方。</para>
		/// <para><see cref="InitialDataSenderEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Setting")]
		public object? InitialDataSender { get; set; } = "CHILD_DATA_SENDER";

		/// <summary>
		/// <para>Expand Feature Classes and Tables</para>
		/// <para>指定是否将添加扩展要素类和表（例如网络、拓扑或关系类中的要素类和表）。</para>
		/// <para>使用默认值—将添加与复本中的要素类和表相关的扩展要素类和表。 要素类的默认设置是复制所有与空间过滤器相交的要素。 如果未提供任何空间过滤器，则系统会将所有要素包括在内。 表的默认设置是仅复制方案。 这是默认设置。</para>
		/// <para>仅使用方案添加—将仅为扩展要素类和表添加方案。</para>
		/// <para>所有行—将为扩展要素类和表添加所有行。</para>
		/// <para>不添加—将不添加扩展要素类或表。</para>
		/// <para><see cref="ExpandFeatureClassesAndTablesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Setting")]
		public object? ExpandFeatureClassesAndTables { get; set; } = "USE_DEFAULTS";

		/// <summary>
		/// <para>Re-use Schema</para>
		/// <para>指定是否将重用包含要复制数据的方案的地理数据库。 这可以减少复制数据所需的时间。 此参数仅适用于检出复本。</para>
		/// <para>不重用—将不会重用方案。 这是默认设置。</para>
		/// <para>重用—将使用方案。</para>
		/// <para><see cref="ReuseSchemaEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Setting")]
		public object? ReuseSchema { get; set; } = "DO_NOT_REUSE";

		/// <summary>
		/// <para>Replicate Related Data</para>
		/// <para>指定是否将复制与复本中现有行相关的行。 例如，复本过滤器内部存在一个要素 (f1)，且该过滤器外部存在一个来自其他类的相关要素 (f2)。 如果您选择获取相关数据，则要素 f2 会包含到复本中。</para>
		/// <para>不取得关联—将不会复制相关数据。</para>
		/// <para>取得关联—将复制相关数据。 这是默认设置。</para>
		/// <para><see cref="GetRelatedDataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Setting")]
		public object? GetRelatedData { get; set; } = "GET_RELATED";

		/// <summary>
		/// <para>Replica Geometry Features</para>
		/// <para>将用于定义要复制区域的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline", "Point", "Multipoint")]
		[Category("Advanced Setting")]
		public object? GeometryFeatures { get; set; }

		/// <summary>
		/// <para>Use archiving to track changes for 1 way replication</para>
		/// <para>指定是否使用存档类来追踪变更而非对增量表进行版本化。 这仅适用于单向复本。</para>
		/// <para>选中 - 存档将用于追踪变更。</para>
		/// <para>未选中 - 存档将不会用于追踪变更。 这是默认设置。</para>
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
		public CreateReplicaFromServer SetEnviroment(object? configKeyword = null, object? extent = null, object? scratchWorkspace = null, object? workspace = null)
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
			/// <para>双向复本—变更将在子复本和父复本之间进行双向发送。</para>
			/// </summary>
			[GPValue("TWO_WAY_REPLICA")]
			[Description("双向复本")]
			Two_way_replica,

			/// <summary>
			/// <para>单向复本—变更只能从父复本发送到子复本。</para>
			/// </summary>
			[GPValue("ONE_WAY_REPLICA")]
			[Description("单向复本")]
			One_way_replica,

			/// <summary>
			/// <para>检出复本—一次复制、编辑并检回数据。</para>
			/// </summary>
			[GPValue("CHECK_OUT")]
			[Description("检出复本")]
			Check_out_replica,

			/// <summary>
			/// <para>“子-父”单向复本—变更只能从子复本发送到父复本。</para>
			/// </summary>
			[GPValue("ONE_WAY_CHILD_TO_PARENT_REPLICA")]
			[Description("“子-父”单向复本")]
			One_way_child_to_parent_replica,

		}

		/// <summary>
		/// <para>Replica Access Type</para>
		/// </summary>
		public enum AccessTypeEnum 
		{
			/// <summary>
			/// <para>全部—支持复杂类型（例如拓扑），并且必须对数据进行版本化。 这是默认设置。</para>
			/// </summary>
			[GPValue("FULL")]
			[Description("全部")]
			Full,

			/// <summary>
			/// <para>简单—子复本上的数据不可版本化且必须为简单形式。 将允许复本互相操作。 在复制期间，父地理数据库中的非简单要素（例如，拓扑中的要素）转换为简单要素（例如点、线和面要素类）。</para>
			/// </summary>
			[GPValue("SIMPLE")]
			[Description("简单")]
			Simple,

		}

		/// <summary>
		/// <para>Initial Data Sender</para>
		/// </summary>
		public enum InitialDataSenderEnum 
		{
			/// <summary>
			/// <para>子数据发送方—子复本将为初始数据发送方。 这是默认设置。</para>
			/// </summary>
			[GPValue("CHILD_DATA_SENDER")]
			[Description("子数据发送方")]
			Child_data_sender,

			/// <summary>
			/// <para>父数据发送方—父复本将为初始数据发送方。</para>
			/// </summary>
			[GPValue("PARENT_DATA_SENDER")]
			[Description("父数据发送方")]
			Parent_data_sender,

		}

		/// <summary>
		/// <para>Expand Feature Classes and Tables</para>
		/// </summary>
		public enum ExpandFeatureClassesAndTablesEnum 
		{
			/// <summary>
			/// <para>使用默认值—将添加与复本中的要素类和表相关的扩展要素类和表。 要素类的默认设置是复制所有与空间过滤器相交的要素。 如果未提供任何空间过滤器，则系统会将所有要素包括在内。 表的默认设置是仅复制方案。 这是默认设置。</para>
			/// </summary>
			[GPValue("USE_DEFAULTS")]
			[Description("使用默认值")]
			Use_defaults,

			/// <summary>
			/// <para>仅使用方案添加—将仅为扩展要素类和表添加方案。</para>
			/// </summary>
			[GPValue("ADD_WITH_SCHEMA_ONLY")]
			[Description("仅使用方案添加")]
			Add_with_schema_only,

			/// <summary>
			/// <para>所有行—将为扩展要素类和表添加所有行。</para>
			/// </summary>
			[GPValue("ALL_ROWS")]
			[Description("所有行")]
			All_rows,

			/// <summary>
			/// <para>不添加—将不添加扩展要素类或表。</para>
			/// </summary>
			[GPValue("DO_NOT_ADD")]
			[Description("不添加")]
			Do_not_add,

		}

		/// <summary>
		/// <para>Re-use Schema</para>
		/// </summary>
		public enum ReuseSchemaEnum 
		{
			/// <summary>
			/// <para>重用—将使用方案。</para>
			/// </summary>
			[GPValue("REUSE")]
			[Description("重用")]
			Reuse,

			/// <summary>
			/// <para>不重用—将不会重用方案。 这是默认设置。</para>
			/// </summary>
			[GPValue("DO_NOT_REUSE")]
			[Description("不重用")]
			Do_not_reuse,

		}

		/// <summary>
		/// <para>Replicate Related Data</para>
		/// </summary>
		public enum GetRelatedDataEnum 
		{
			/// <summary>
			/// <para>取得关联—将复制相关数据。 这是默认设置。</para>
			/// </summary>
			[GPValue("GET_RELATED")]
			[Description("取得关联")]
			Get_related,

			/// <summary>
			/// <para>不取得关联—将不会复制相关数据。</para>
			/// </summary>
			[GPValue("DO_NOT_GET_RELATED")]
			[Description("不取得关联")]
			Do_not_get_related,

		}

		/// <summary>
		/// <para>Use archiving to track changes for 1 way replication</para>
		/// </summary>
		public enum ArchivingEnum 
		{
			/// <summary>
			/// <para></para>
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
