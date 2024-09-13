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
	/// <para>Table To Domain</para>
	/// <para>Table To Domain</para>
	/// <para>Creates or updates a coded value domain with values from a table.</para>
	/// </summary>
	public class TableToDomain : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The database table from which to derive domain values.</para>
		/// </param>
		/// <param name="CodeField">
		/// <para>Code Field</para>
		/// <para>The field in the database table from which to derive domain code values.</para>
		/// </param>
		/// <param name="DescriptionField">
		/// <para>Description Field</para>
		/// <para>The field in the database table from which to derive domain description values.</para>
		/// </param>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>The workspace that contains the domain to be created or updated.</para>
		/// </param>
		/// <param name="DomainName">
		/// <para>Domain Name</para>
		/// <para>The name of the domain to be created or updated.</para>
		/// </param>
		public TableToDomain(object InTable, object CodeField, object DescriptionField, object InWorkspace, object DomainName)
		{
			this.InTable = InTable;
			this.CodeField = CodeField;
			this.DescriptionField = DescriptionField;
			this.InWorkspace = InWorkspace;
			this.DomainName = DomainName;
		}

		/// <summary>
		/// <para>Tool Display Name : Table To Domain</para>
		/// </summary>
		public override string DisplayName() => "Table To Domain";

		/// <summary>
		/// <para>Tool Name : TableToDomain</para>
		/// </summary>
		public override string ToolName() => "TableToDomain";

		/// <summary>
		/// <para>Tool Excute Name : management.TableToDomain</para>
		/// </summary>
		public override string ExcuteName() => "management.TableToDomain";

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
		public override object[] Parameters() => new object[] { InTable, CodeField, DescriptionField, InWorkspace, DomainName, DomainDescription!, UpdateOption!, OutWorkspace! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The database table from which to derive domain values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Code Field</para>
		/// <para>The field in the database table from which to derive domain code values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object CodeField { get; set; }

		/// <summary>
		/// <para>Description Field</para>
		/// <para>The field in the database table from which to derive domain description values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object DescriptionField { get; set; }

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>The workspace that contains the domain to be created or updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Domain Name</para>
		/// <para>The name of the domain to be created or updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainName { get; set; }

		/// <summary>
		/// <para>Domain Description</para>
		/// <para>The description of the domain to be created or updated. Domain descriptions of existing domains are not updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? DomainDescription { get; set; }

		/// <summary>
		/// <para>Update Option</para>
		/// <para>If the domain already exists, specifies how the domain will be updated.</para>
		/// <para>Append the values—Appends to the domain values from the database table. This is the default.</para>
		/// <para>Replace the values—Replaces the values in the domain with values from the database table.</para>
		/// <para><see cref="UpdateOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? UpdateOption { get; set; } = "APPEND";

		/// <summary>
		/// <para>Updated Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TableToDomain SetEnviroment(int? autoCommit = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Update Option</para>
		/// </summary>
		public enum UpdateOptionEnum 
		{
			/// <summary>
			/// <para>Append the values—Appends to the domain values from the database table. This is the default.</para>
			/// </summary>
			[GPValue("APPEND")]
			[Description("Append the values")]
			Append_the_values,

			/// <summary>
			/// <para>Replace the values—Replaces the values in the domain with values from the database table.</para>
			/// </summary>
			[GPValue("REPLACE")]
			[Description("Replace the values")]
			Replace_the_values,

		}

#endregion
	}
}
