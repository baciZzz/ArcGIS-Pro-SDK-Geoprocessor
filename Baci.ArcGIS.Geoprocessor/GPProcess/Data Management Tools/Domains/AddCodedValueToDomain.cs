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
	/// <para>Add Coded Value To Domain</para>
	/// <para>Adds a value to a domain's coded value list.</para>
	/// </summary>
	public class AddCodedValueToDomain : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>The geodatabase containing the domain to be updated.</para>
		/// </param>
		/// <param name="DomainName">
		/// <para>Domain Name</para>
		/// <para>The name of the attribute domain that will have a value added to its coded value list.</para>
		/// </param>
		/// <param name="Code">
		/// <para>Code Value</para>
		/// <para>The value to be added to the specified domain's coded value list.</para>
		/// </param>
		/// <param name="CodeDescription">
		/// <para>Code Description</para>
		/// <para>A description of what the coded value represents.</para>
		/// </param>
		public AddCodedValueToDomain(object InWorkspace, object DomainName, object Code, object CodeDescription)
		{
			this.InWorkspace = InWorkspace;
			this.DomainName = DomainName;
			this.Code = Code;
			this.CodeDescription = CodeDescription;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Coded Value To Domain</para>
		/// </summary>
		public override string DisplayName => "Add Coded Value To Domain";

		/// <summary>
		/// <para>Tool Name : AddCodedValueToDomain</para>
		/// </summary>
		public override string ToolName => "AddCodedValueToDomain";

		/// <summary>
		/// <para>Tool Excute Name : management.AddCodedValueToDomain</para>
		/// </summary>
		public override string ExcuteName => "management.AddCodedValueToDomain";

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
		public override object[] Parameters => new object[] { InWorkspace, DomainName, Code, CodeDescription, OutWorkspace };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>The geodatabase containing the domain to be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Domain Name</para>
		/// <para>The name of the attribute domain that will have a value added to its coded value list.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainName { get; set; }

		/// <summary>
		/// <para>Code Value</para>
		/// <para>The value to be added to the specified domain's coded value list.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Code { get; set; }

		/// <summary>
		/// <para>Code Description</para>
		/// <para>A description of what the coded value represents.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object CodeDescription { get; set; }

		/// <summary>
		/// <para>Updated Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddCodedValueToDomain SetEnviroment(int? autoCommit = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

	}
}
