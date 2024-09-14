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
	/// <para>Create Spatial Type</para>
	/// <para>Create Spatial Type</para>
	/// <para>Adds the ST_Geometry SQL type, subtypes, and functions to an Oracle or a PostgreSQL database. This allows you to use the ST_Geometry SQL type to store geometries in a database that does not contain a geodatabase. You can also use this tool to upgrade the existing ST_Geometry type, subtypes, and functions in an Oracle or a PostgreSQL database.</para>
	/// </summary>
	public class CreateSpatialType : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>The input_database is the database connection file (.sde) that connects to the Oracle or PostgreSQL database. You must connect as a database administrator user; in Oracle, you must connect as the sys user.</para>
		/// </param>
		/// <param name="SdeUserPassword">
		/// <para>SDE User Password</para>
		/// <para>The password for the sde database user. If the sde user does not exist in the database, it will be created and will use the password you provide. The password policy of the underlying database will be enforced. If the sde user does exist in the database or database cluster, this password must match the existing password.</para>
		/// </param>
		public CreateSpatialType(object InputDatabase, object SdeUserPassword)
		{
			this.InputDatabase = InputDatabase;
			this.SdeUserPassword = SdeUserPassword;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Spatial Type</para>
		/// </summary>
		public override string DisplayName() => "Create Spatial Type";

		/// <summary>
		/// <para>Tool Name : CreateSpatialType</para>
		/// </summary>
		public override string ToolName() => "CreateSpatialType";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateSpatialType</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateSpatialType";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputDatabase, SdeUserPassword, TablespaceName!, StShapeLibraryPath!, OutWorkspace! };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>The input_database is the database connection file (.sde) that connects to the Oracle or PostgreSQL database. You must connect as a database administrator user; in Oracle, you must connect as the sys user.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>SDE User Password</para>
		/// <para>The password for the sde database user. If the sde user does not exist in the database, it will be created and will use the password you provide. The password policy of the underlying database will be enforced. If the sde user does exist in the database or database cluster, this password must match the existing password.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPEncryptedString()]
		public object SdeUserPassword { get; set; }

		/// <summary>
		/// <para>Tablespace Name</para>
		/// <para>The name of a tablespace that will be set as the default tablespace for the sde user in Oracle. If the tablespace name does not exist, it will be created in the Oracle default storage location. If a tablespace with the specified name does exist, it will be set as the sde user's default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? TablespaceName { get; set; }

		/// <summary>
		/// <para>ST_Geometry Shape Library Path</para>
		/// <para>The location on the Oracle server where the st_shape library resides.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("dll", "so")]
		public object? StShapeLibraryPath { get; set; }

		/// <summary>
		/// <para>Output Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

	}
}
