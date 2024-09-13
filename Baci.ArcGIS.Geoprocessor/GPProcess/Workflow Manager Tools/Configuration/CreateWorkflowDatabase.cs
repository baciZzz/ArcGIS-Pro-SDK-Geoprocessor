using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.WorkflowManagerTools
{
	/// <summary>
	/// <para>Create Workflow Database</para>
	/// <para>Create Workflow Database</para>
	/// <para>Creates Workflow Manager (Classic) schema and configures an enterprise geodatabase as the Workflow Manager (Classic) database.</para>
	/// </summary>
	public class CreateWorkflowDatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabaseConnection">
		/// <para>Input Database Connection</para>
		/// <para>The location of the enterprise geodatabase connection file that will host the Workflow Manager (Classic) schema and configuration. The connection file must connect directly to the database, and the connection should be made as a database owner.</para>
		/// </param>
		/// <param name="AOISpatialReference">
		/// <para>AOI Spatial Reference</para>
		/// <para>The spatial reference of the AOI feature class. You can specify the spatial reference in the following ways:</para>
		/// <para>Select a spatial reference.</para>
		/// <para>Select a feature class or feature dataset whose spatial reference you want to apply.</para>
		/// </param>
		/// <param name="ImportConfiguration">
		/// <para>Import Configuration</para>
		/// <para>Specifies the Workflow Manager (Classic) elements to be imported into the new Workflow Manager (Classic) database. The default is Minimum configuration (Minimum Configuration in Python).</para>
		/// <para>Minimum configuration—Imports the basic elements that the Workflow Manager (Classic) system requires.</para>
		/// <para>Quick configuration—Includes the Minimum Configuration elements plus samples for several elements.</para>
		/// <para>Custom configuration—Specifies a Workflow Manager (Classic) configuration file in the Input Custom Configuration parameter, exported from a preexisting database.</para>
		/// <para><see cref="ImportConfigurationEnum"/></para>
		/// </param>
		public CreateWorkflowDatabase(object InputDatabaseConnection, object AOISpatialReference, object ImportConfiguration)
		{
			this.InputDatabaseConnection = InputDatabaseConnection;
			this.AOISpatialReference = AOISpatialReference;
			this.ImportConfiguration = ImportConfiguration;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Workflow Database</para>
		/// </summary>
		public override string DisplayName() => "Create Workflow Database";

		/// <summary>
		/// <para>Tool Name : CreateWorkflowDatabase</para>
		/// </summary>
		public override string ToolName() => "CreateWorkflowDatabase";

		/// <summary>
		/// <para>Tool Excute Name : wmx.CreateWorkflowDatabase</para>
		/// </summary>
		public override string ExcuteName() => "wmx.CreateWorkflowDatabase";

		/// <summary>
		/// <para>Toolbox Display Name : Workflow Manager Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Workflow Manager Tools";

		/// <summary>
		/// <para>Toolbox Alise : wmx</para>
		/// </summary>
		public override string ToolboxAlise() => "wmx";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "configKeyword" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputDatabaseConnection, AOISpatialReference, ImportConfiguration, InputCustomConfiguration!, UserStore!, OutputDatabasepath! };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>The location of the enterprise geodatabase connection file that will host the Workflow Manager (Classic) schema and configuration. The connection file must connect directly to the database, and the connection should be made as a database owner.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabaseConnection { get; set; }

		/// <summary>
		/// <para>AOI Spatial Reference</para>
		/// <para>The spatial reference of the AOI feature class. You can specify the spatial reference in the following ways:</para>
		/// <para>Select a spatial reference.</para>
		/// <para>Select a feature class or feature dataset whose spatial reference you want to apply.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCoordinateSystem()]
		public object AOISpatialReference { get; set; }

		/// <summary>
		/// <para>Import Configuration</para>
		/// <para>Specifies the Workflow Manager (Classic) elements to be imported into the new Workflow Manager (Classic) database. The default is Minimum configuration (Minimum Configuration in Python).</para>
		/// <para>Minimum configuration—Imports the basic elements that the Workflow Manager (Classic) system requires.</para>
		/// <para>Quick configuration—Includes the Minimum Configuration elements plus samples for several elements.</para>
		/// <para>Custom configuration—Specifies a Workflow Manager (Classic) configuration file in the Input Custom Configuration parameter, exported from a preexisting database.</para>
		/// <para><see cref="ImportConfigurationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ImportConfiguration { get; set; }

		/// <summary>
		/// <para>Input Custom Configuration</para>
		/// <para>A custom configuration file that was exported from an existing Workflow Manager (Classic) database.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jxl")]
		public object? InputCustomConfiguration { get; set; }

		/// <summary>
		/// <para>User Store</para>
		/// <para>Specifies the user store from which the users and roles will be retrieved. The users can be imported from a portal and are assigned to roles created in the Workflow Manager (Classic) repository. The portal user profile information cannot be edited using ArcGIS Workflow Manager (Classic) Administrator. The users and roles can be created in the Workflow Manager (Classic) repository using the Traditional option. When using the Traditional option, the users and roles can be imported from the Active Directory in ArcGIS Workflow Manager (Classic) Administrator.</para>
		/// <para>Portal—The users will be imported from the portal you are currently signed in to.</para>
		/// <para>Traditional—The users and roles will be created in the Workflow Manager (Classic) repository using ArcGIS Workflow Manager (Classic) Administrator. Users and roles can be imported from the Active Directory when this option is used. This is the default.</para>
		/// <para><see cref="UserStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? UserStore { get; set; }

		/// <summary>
		/// <para>Output Database Path (.jtc)</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jtc")]
		public object? OutputDatabasepath { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateWorkflowDatabase SetEnviroment(object? configKeyword = null )
		{
			base.SetEnv(configKeyword: configKeyword);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Import Configuration</para>
		/// </summary>
		public enum ImportConfigurationEnum 
		{
			/// <summary>
			/// <para>Minimum configuration—Imports the basic elements that the Workflow Manager (Classic) system requires.</para>
			/// </summary>
			[GPValue("Minimum Configuration")]
			[Description("Minimum configuration")]
			Minimum_configuration,

			/// <summary>
			/// <para>Quick configuration—Includes the Minimum Configuration elements plus samples for several elements.</para>
			/// </summary>
			[GPValue("Quick Configuration")]
			[Description("Quick configuration")]
			Quick_configuration,

			/// <summary>
			/// <para>Custom configuration—Specifies a Workflow Manager (Classic) configuration file in the Input Custom Configuration parameter, exported from a preexisting database.</para>
			/// </summary>
			[GPValue("Custom Configuration")]
			[Description("Custom configuration")]
			Custom_configuration,

		}

		/// <summary>
		/// <para>User Store</para>
		/// </summary>
		public enum UserStoreEnum 
		{
			/// <summary>
			/// <para>Traditional—The users and roles will be created in the Workflow Manager (Classic) repository using ArcGIS Workflow Manager (Classic) Administrator. Users and roles can be imported from the Active Directory when this option is used. This is the default.</para>
			/// </summary>
			[GPValue("TRADITIONAL")]
			[Description("Traditional")]
			Traditional,

			/// <summary>
			/// <para>Portal—The users will be imported from the portal you are currently signed in to.</para>
			/// </summary>
			[GPValue("PORTAL")]
			[Description("Portal")]
			Portal,

		}

#endregion
	}
}
