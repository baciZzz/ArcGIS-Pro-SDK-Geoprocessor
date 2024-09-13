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
	/// <para>Create Database View</para>
	/// <para>创建数据库视图</para>
	/// <para>基于 SQL 表达式在数据库中创建视图。</para>
	/// </summary>
	public class CreateDatabaseView : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Workspace</para>
		/// <para>包含用于构建视图的表或要素类的数据库。 此数据库也是创建视图的位置。</para>
		/// </param>
		/// <param name="ViewName">
		/// <para>Output View Name</para>
		/// <para>将要创建在数据库中的视图的名称。</para>
		/// </param>
		/// <param name="ViewDefinition">
		/// <para>View Definition</para>
		/// <para>用于构建视图的 SQL 语句。</para>
		/// </param>
		public CreateDatabaseView(object InputDatabase, object ViewName, object ViewDefinition)
		{
			this.InputDatabase = InputDatabase;
			this.ViewName = ViewName;
			this.ViewDefinition = ViewDefinition;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建数据库视图</para>
		/// </summary>
		public override string DisplayName() => "创建数据库视图";

		/// <summary>
		/// <para>Tool Name : CreateDatabaseView</para>
		/// </summary>
		public override string ToolName() => "CreateDatabaseView";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateDatabaseView</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateDatabaseView";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputDatabase, ViewName, ViewDefinition, OutLayer };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>包含用于构建视图的表或要素类的数据库。 此数据库也是创建视图的位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database", "Local Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Output View Name</para>
		/// <para>将要创建在数据库中的视图的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ViewName { get; set; }

		/// <summary>
		/// <para>View Definition</para>
		/// <para>用于构建视图的 SQL 语句。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ViewDefinition { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateDatabaseView SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
