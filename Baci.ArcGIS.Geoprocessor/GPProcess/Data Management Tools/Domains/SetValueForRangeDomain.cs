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
	/// <para>Set Value For Range Domain</para>
	/// <para>Sets the minimum and maximum values for an existing Range domain.</para>
	/// </summary>
	public class SetValueForRangeDomain : AbstractGPProcess
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
		/// <para>The name of the range domain to be updated.</para>
		/// </param>
		/// <param name="MinValue">
		/// <para>Minimum Value</para>
		/// <para>The minimum value of the range domain.</para>
		/// </param>
		/// <param name="MaxValue">
		/// <para>Maximum Value</para>
		/// <para>The maximum value of the range domain.</para>
		/// </param>
		public SetValueForRangeDomain(object InWorkspace, object DomainName, object MinValue, object MaxValue)
		{
			this.InWorkspace = InWorkspace;
			this.DomainName = DomainName;
			this.MinValue = MinValue;
			this.MaxValue = MaxValue;
		}

		/// <summary>
		/// <para>Tool Display Name : Set Value For Range Domain</para>
		/// </summary>
		public override string DisplayName => "Set Value For Range Domain";

		/// <summary>
		/// <para>Tool Name : SetValueForRangeDomain</para>
		/// </summary>
		public override string ToolName => "SetValueForRangeDomain";

		/// <summary>
		/// <para>Tool Excute Name : management.SetValueForRangeDomain</para>
		/// </summary>
		public override string ExcuteName => "management.SetValueForRangeDomain";

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
		public override object[] Parameters => new object[] { InWorkspace, DomainName, MinValue, MaxValue, OutWorkspace! };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>The geodatabase containing the domain to be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Domain Name</para>
		/// <para>The name of the range domain to be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainName { get; set; }

		/// <summary>
		/// <para>Minimum Value</para>
		/// <para>The minimum value of the range domain.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object MinValue { get; set; }

		/// <summary>
		/// <para>Maximum Value</para>
		/// <para>The maximum value of the range domain.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object MaxValue { get; set; }

		/// <summary>
		/// <para>Updated Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SetValueForRangeDomain SetEnviroment(int? autoCommit = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, workspace: workspace);
			return this;
		}

	}
}
