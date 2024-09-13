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
	/// <para>设置范围属性域的值</para>
	/// <para>设置现有范围属性域的最小值和最大值。</para>
	/// </summary>
	public class SetValueForRangeDomain : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>包含要更新的属性域的地理数据库。</para>
		/// </param>
		/// <param name="DomainName">
		/// <para>Domain Name</para>
		/// <para>要更新的范围属性域的名称。</para>
		/// </param>
		/// <param name="MinValue">
		/// <para>Minimum Value</para>
		/// <para>范围属性域的最小值。</para>
		/// </param>
		/// <param name="MaxValue">
		/// <para>Maximum Value</para>
		/// <para>范围属性域的最大值。</para>
		/// </param>
		public SetValueForRangeDomain(object InWorkspace, object DomainName, object MinValue, object MaxValue)
		{
			this.InWorkspace = InWorkspace;
			this.DomainName = DomainName;
			this.MinValue = MinValue;
			this.MaxValue = MaxValue;
		}

		/// <summary>
		/// <para>Tool Display Name : 设置范围属性域的值</para>
		/// </summary>
		public override string DisplayName() => "设置范围属性域的值";

		/// <summary>
		/// <para>Tool Name : SetValueForRangeDomain</para>
		/// </summary>
		public override string ToolName() => "SetValueForRangeDomain";

		/// <summary>
		/// <para>Tool Excute Name : management.SetValueForRangeDomain</para>
		/// </summary>
		public override string ExcuteName() => "management.SetValueForRangeDomain";

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
		public override object[] Parameters() => new object[] { InWorkspace, DomainName, MinValue, MaxValue, OutWorkspace! };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>包含要更新的属性域的地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Domain Name</para>
		/// <para>要更新的范围属性域的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainName { get; set; }

		/// <summary>
		/// <para>Minimum Value</para>
		/// <para>范围属性域的最小值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object MinValue { get; set; }

		/// <summary>
		/// <para>Maximum Value</para>
		/// <para>范围属性域的最大值。</para>
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
