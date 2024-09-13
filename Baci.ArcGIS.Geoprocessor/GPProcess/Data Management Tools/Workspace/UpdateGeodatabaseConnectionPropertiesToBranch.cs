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
	/// <para>Update Geodatabase Connection Properties To Branch</para>
	/// <para>将地理数据库连接属性更新到分支中</para>
	/// <para>更新企业级地理数据库连接以使用分支版本化。</para>
	/// </summary>
	public class UpdateGeodatabaseConnectionPropertiesToBranch : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Geodatabase Connection</para>
		/// <para>要更新的输入企业级地理数据库连接。</para>
		/// </param>
		public UpdateGeodatabaseConnectionPropertiesToBranch(object InputDatabase)
		{
			this.InputDatabase = InputDatabase;
		}

		/// <summary>
		/// <para>Tool Display Name : 将地理数据库连接属性更新到分支中</para>
		/// </summary>
		public override string DisplayName() => "将地理数据库连接属性更新到分支中";

		/// <summary>
		/// <para>Tool Name : UpdateGeodatabaseConnectionPropertiesToBranch</para>
		/// </summary>
		public override string ToolName() => "UpdateGeodatabaseConnectionPropertiesToBranch";

		/// <summary>
		/// <para>Tool Excute Name : management.UpdateGeodatabaseConnectionPropertiesToBranch</para>
		/// </summary>
		public override string ExcuteName() => "management.UpdateGeodatabaseConnectionPropertiesToBranch";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputDatabase, OutWorkspace! };

		/// <summary>
		/// <para>Input Geodatabase Connection</para>
		/// <para>要更新的输入企业级地理数据库连接。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Updated Geodatabase Connection Properties To Branch</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

	}
}
