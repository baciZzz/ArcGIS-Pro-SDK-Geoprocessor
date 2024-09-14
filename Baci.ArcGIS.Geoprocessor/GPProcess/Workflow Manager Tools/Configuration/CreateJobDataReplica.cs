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
	/// <para>Replicate Job Data</para>
	/// <para>复制作业数据</para>
	/// <para>通过使用 ArcGIS Workflow Manager (Classic) Server 将 ArcGIS Workflow Manager (Classic) 配置从父资料档案库复制到子资料档案库中。每个子资料档案库均会成为父资料档案库的相同副本（复本）。</para>
	/// </summary>
	public class CreateJobDataReplica : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputParentRepositoryURL">
		/// <para>Parent Repository URL</para>
		/// <para>作为 Workflow Manager (Classic) 服务 URL 的父资料档案库的 URL，例如，http://localhost/arcgis/rest/services/parent/wmserver。</para>
		/// </param>
		/// <param name="InputParentRepositoryName">
		/// <para>Parent Repository Name</para>
		/// <para>将分配 Workflow Manager (Classic) 作业和配置元素的父资料档案库的名称。</para>
		/// </param>
		/// <param name="InputMultiName">
		/// <para>Child Repository Names and URLs</para>
		/// <para>将通过父资料档案库配置进行更新的子资料档案库。要添加子资料档案库，请提供资料档案库的名称，然后单击添加按钮。添加完子资料档案库后，请按如下所示提供连接和 URL 的值：</para>
		/// <para>连接 - 如果子资料档案库是在线复制，请输入 true。如果子资料档案库是离线复制，请输入 false。</para>
		/// <para>URL - 如果连接为 true，请提供子资料档案库的 URL。如果连接为 false，请提供包含从父资料档案库中导出的配置文件的文件夹位置。</para>
		/// </param>
		public CreateJobDataReplica(object InputParentRepositoryURL, object InputParentRepositoryName, object InputMultiName)
		{
			this.InputParentRepositoryURL = InputParentRepositoryURL;
			this.InputParentRepositoryName = InputParentRepositoryName;
			this.InputMultiName = InputMultiName;
		}

		/// <summary>
		/// <para>Tool Display Name : 复制作业数据</para>
		/// </summary>
		public override string DisplayName() => "复制作业数据";

		/// <summary>
		/// <para>Tool Name : CreateJobDataReplica</para>
		/// </summary>
		public override string ToolName() => "CreateJobDataReplica";

		/// <summary>
		/// <para>Tool Excute Name : wmx.CreateJobDataReplica</para>
		/// </summary>
		public override string ExcuteName() => "wmx.CreateJobDataReplica";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputParentRepositoryURL, InputParentRepositoryName, InputMultiName, OutputCreatereplicastatus!, OutputLastsync! };

		/// <summary>
		/// <para>Parent Repository URL</para>
		/// <para>作为 Workflow Manager (Classic) 服务 URL 的父资料档案库的 URL，例如，http://localhost/arcgis/rest/services/parent/wmserver。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InputParentRepositoryURL { get; set; }

		/// <summary>
		/// <para>Parent Repository Name</para>
		/// <para>将分配 Workflow Manager (Classic) 作业和配置元素的父资料档案库的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InputParentRepositoryName { get; set; }

		/// <summary>
		/// <para>Child Repository Names and URLs</para>
		/// <para>将通过父资料档案库配置进行更新的子资料档案库。要添加子资料档案库，请提供资料档案库的名称，然后单击添加按钮。添加完子资料档案库后，请按如下所示提供连接和 URL 的值：</para>
		/// <para>连接 - 如果子资料档案库是在线复制，请输入 true。如果子资料档案库是离线复制，请输入 false。</para>
		/// <para>URL - 如果连接为 true，请提供子资料档案库的 URL。如果连接为 false，请提供包含从父资料档案库中导出的配置文件的文件夹位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		public object InputMultiName { get; set; }

		/// <summary>
		/// <para>Create Replica Status</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object? OutputCreatereplicastatus { get; set; }

		/// <summary>
		/// <para>Last Syncronized</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPValueTable()]
		public object? OutputLastsync { get; set; }

	}
}
