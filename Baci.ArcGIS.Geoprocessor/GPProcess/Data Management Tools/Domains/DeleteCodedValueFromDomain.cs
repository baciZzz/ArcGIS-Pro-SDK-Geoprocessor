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
	/// <para>Delete Coded Value From Domain</para>
	/// <para>Delete Coded Value From Domain</para>
	/// <para>Removes a value from a coded value domain.</para>
	/// </summary>
	public class DeleteCodedValueFromDomain : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>The workspace containing the domain to be updated.</para>
		/// </param>
		/// <param name="DomainName">
		/// <para>Domain Name</para>
		/// <para>The name of the coded value domain to be updated.</para>
		/// </param>
		/// <param name="Code">
		/// <para>Code Value</para>
		/// <para>The value(s) to be deleted from the specified domain.</para>
		/// </param>
		public DeleteCodedValueFromDomain(object InWorkspace, object DomainName, object Code)
		{
			this.InWorkspace = InWorkspace;
			this.DomainName = DomainName;
			this.Code = Code;
		}

		/// <summary>
		/// <para>Tool Display Name : Delete Coded Value From Domain</para>
		/// </summary>
		public override string DisplayName() => "Delete Coded Value From Domain";

		/// <summary>
		/// <para>Tool Name : DeleteCodedValueFromDomain</para>
		/// </summary>
		public override string ToolName() => "DeleteCodedValueFromDomain";

		/// <summary>
		/// <para>Tool Excute Name : management.DeleteCodedValueFromDomain</para>
		/// </summary>
		public override string ExcuteName() => "management.DeleteCodedValueFromDomain";

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
		public override object[] Parameters() => new object[] { InWorkspace, DomainName, Code, OutWorkspace };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>The workspace containing the domain to be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Domain Name</para>
		/// <para>The name of the coded value domain to be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainName { get; set; }

		/// <summary>
		/// <para>Code Value</para>
		/// <para>The value(s) to be deleted from the specified domain.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Code { get; set; }

		/// <summary>
		/// <para>Updated Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DeleteCodedValueFromDomain SetEnviroment(int? autoCommit = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

	}
}
