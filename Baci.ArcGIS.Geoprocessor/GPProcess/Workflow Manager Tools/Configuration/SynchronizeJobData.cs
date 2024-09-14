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
	/// <para>Synchronize Job Data</para>
	/// <para>同步作业数据</para>
	/// <para>同步参与 Workflow Manager (Classic) 集群的多个 Workflow Manager (Classic) 资料档案库。此工具执行双向同步；子资料档案库中的更改发送到父资料档案库中，父资料档案库中的更改发送到所有子资料档案库中。</para>
	/// </summary>
	public class SynchronizeJobData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputParentRepositoryURL">
		/// <para>Parent Repository URL</para>
		/// <para>父资料档案库的 URL 将成为 Workflow Manager (Classic) 服务器 URL，例如，http://localhost/arcgis/rest/services/parent/wmserver。</para>
		/// </param>
		/// <param name="InputParentRepositoryName">
		/// <para>Parent Repository Name</para>
		/// <para>将分配 Workflow Manager (Classic) 作业和配置元素的父资料档案库。</para>
		/// </param>
		/// <param name="InputMultiName">
		/// <para>Child Repository Names and URLs</para>
		/// <para>将通过父资料档案库配置进行更新的子资料档案库。要添加子资料档案库，请提供资料档案库的名称，然后单击添加按钮。添加完子资料档案库后，请按如下所示输入连接、URL 和上次同步时间的值：</para>
		/// <para>连接 - 唯一可以接受的值是 true。如果提供任何其他值，子资料档案库将不会同步。</para>
		/// <para>URL - 子资料档案库的 URL。</para>
		/// <para>上次同步时间 - 采用系统格式的日期和时间。例如，如果您的系统日期和时间格式是 MM:DD:YY HH:MM:SS，该值将是 08/01/2013 11:30:45。</para>
		/// </param>
		public SynchronizeJobData(object InputParentRepositoryURL, object InputParentRepositoryName, object InputMultiName)
		{
			this.InputParentRepositoryURL = InputParentRepositoryURL;
			this.InputParentRepositoryName = InputParentRepositoryName;
			this.InputMultiName = InputMultiName;
		}

		/// <summary>
		/// <para>Tool Display Name : 同步作业数据</para>
		/// </summary>
		public override string DisplayName() => "同步作业数据";

		/// <summary>
		/// <para>Tool Name : SynchronizeJobData</para>
		/// </summary>
		public override string ToolName() => "SynchronizeJobData";

		/// <summary>
		/// <para>Tool Excute Name : wmx.SynchronizeJobData</para>
		/// </summary>
		public override string ExcuteName() => "wmx.SynchronizeJobData";

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
		public override object[] Parameters() => new object[] { InputParentRepositoryURL, InputParentRepositoryName, InputMultiName, OutputSynchronizereplicastatus, OutputLastsync };

		/// <summary>
		/// <para>Parent Repository URL</para>
		/// <para>父资料档案库的 URL 将成为 Workflow Manager (Classic) 服务器 URL，例如，http://localhost/arcgis/rest/services/parent/wmserver。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InputParentRepositoryURL { get; set; }

		/// <summary>
		/// <para>Parent Repository Name</para>
		/// <para>将分配 Workflow Manager (Classic) 作业和配置元素的父资料档案库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InputParentRepositoryName { get; set; }

		/// <summary>
		/// <para>Child Repository Names and URLs</para>
		/// <para>将通过父资料档案库配置进行更新的子资料档案库。要添加子资料档案库，请提供资料档案库的名称，然后单击添加按钮。添加完子资料档案库后，请按如下所示输入连接、URL 和上次同步时间的值：</para>
		/// <para>连接 - 唯一可以接受的值是 true。如果提供任何其他值，子资料档案库将不会同步。</para>
		/// <para>URL - 子资料档案库的 URL。</para>
		/// <para>上次同步时间 - 采用系统格式的日期和时间。例如，如果您的系统日期和时间格式是 MM:DD:YY HH:MM:SS，该值将是 08/01/2013 11:30:45。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		public object InputMultiName { get; set; }

		/// <summary>
		/// <para>Status of Replica Synchronization</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object OutputSynchronizereplicastatus { get; set; }

		/// <summary>
		/// <para>Last Synchronized</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPValueTable()]
		public object OutputLastsync { get; set; }

	}
}
