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
	/// <para>Delete Domain</para>
	/// <para>Deletes a domain from a workspace.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class DeleteDomain : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>The geodatabase that contains the domain to be deleted.</para>
		/// </param>
		/// <param name="DomainName">
		/// <para>Domain Name</para>
		/// <para>The name of the domain to be deleted.</para>
		/// </param>
		public DeleteDomain(object InWorkspace, object DomainName)
		{
			this.InWorkspace = InWorkspace;
			this.DomainName = DomainName;
		}

		/// <summary>
		/// <para>Tool Display Name : Delete Domain</para>
		/// </summary>
		public override string DisplayName() => "Delete Domain";

		/// <summary>
		/// <para>Tool Name : DeleteDomain</para>
		/// </summary>
		public override string ToolName() => "DeleteDomain";

		/// <summary>
		/// <para>Tool Excute Name : management.DeleteDomain</para>
		/// </summary>
		public override string ExcuteName() => "management.DeleteDomain";

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
		public override object[] Parameters() => new object[] { InWorkspace, DomainName, OutWorkspace };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>The geodatabase that contains the domain to be deleted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Domain Name</para>
		/// <para>The name of the domain to be deleted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainName { get; set; }

		/// <summary>
		/// <para>Updated Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DeleteDomain SetEnviroment(int? autoCommit = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

	}
}
