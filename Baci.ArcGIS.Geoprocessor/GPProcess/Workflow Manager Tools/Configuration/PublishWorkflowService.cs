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
	/// <para>Publish Workflow Service</para>
	/// <para>发布工作流服务</para>
	/// <para>为 ArcGIS Workflow Manager (Classic) 存储库上传和共享作业位置的工作流服务和地图服务。</para>
	/// </summary>
	public class PublishWorkflowService : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="ServiceName">
		/// <para>Service Name</para>
		/// <para>将上传和共享的工作流服务的名称。</para>
		/// </param>
		/// <param name="AoiServiceName">
		/// <para>AOI Service Name</para>
		/// <para>将上传和共享的地图服务的名称。</para>
		/// </param>
		/// <param name="Server">
		/// <para>Server</para>
		/// <para>包含连接到 ArcGIS Server 所需的信息或连接到 ArcGIS Enterprise 门户联合服务器的 URL 的 ArcGIS Server 连接文件 (.ags)。</para>
		/// </param>
		/// <param name="OutServiceDraftLocation">
		/// <para>Output Service Draft Location</para>
		/// <para>将保存服务定义的文件夹。</para>
		/// </param>
		public PublishWorkflowService(object ServiceName, object AoiServiceName, object Server, object OutServiceDraftLocation)
		{
			this.ServiceName = ServiceName;
			this.AoiServiceName = AoiServiceName;
			this.Server = Server;
			this.OutServiceDraftLocation = OutServiceDraftLocation;
		}

		/// <summary>
		/// <para>Tool Display Name : 发布工作流服务</para>
		/// </summary>
		public override string DisplayName() => "发布工作流服务";

		/// <summary>
		/// <para>Tool Name : PublishWorkflowService</para>
		/// </summary>
		public override string ToolName() => "PublishWorkflowService";

		/// <summary>
		/// <para>Tool Excute Name : wmx.PublishWorkflowService</para>
		/// </summary>
		public override string ExcuteName() => "wmx.PublishWorkflowService";

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
		public override object[] Parameters() => new object[] { ServiceName, AoiServiceName, Server, OutServiceDraftLocation, InputDatabasePath!, ServerFolder!, Description!, OutputWorkflowServiceDraftPath!, OutputMapServiceDraftPath!, Overwrite! };

		/// <summary>
		/// <para>Service Name</para>
		/// <para>将上传和共享的工作流服务的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ServiceName { get; set; }

		/// <summary>
		/// <para>AOI Service Name</para>
		/// <para>将上传和共享的地图服务的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object AoiServiceName { get; set; }

		/// <summary>
		/// <para>Server</para>
		/// <para>包含连接到 ArcGIS Server 所需的信息或连接到 ArcGIS Enterprise 门户联合服务器的 URL 的 ArcGIS Server 连接文件 (.ags)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEServerConnection()]
		[GPCodedValueDomain()]
		public object Server { get; set; }

		/// <summary>
		/// <para>Output Service Draft Location</para>
		/// <para>将保存服务定义的文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutServiceDraftLocation { get; set; }

		/// <summary>
		/// <para>Input Database Path (.jtc)</para>
		/// <para>包含连接到 Workflow Manager (Classic) 存储库所需的信息的工作流连接文件 (.jtc)。</para>
		/// <para>如果未定义工作流连接文件，则将使用 ArcGIS Pro 工程中的工作流连接。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jtc")]
		public object? InputDatabasePath { get; set; }

		/// <summary>
		/// <para>Server Folder</para>
		/// <para>ArcGIS Server 上服务将发布至的文件夹。</para>
		/// <para>如果未指定文件夹，服务将发布到 ArcGIS Server 的根文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ServerFolder { get; set; }

		/// <summary>
		/// <para>Description</para>
		/// <para>将发布的服务的描述。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Description { get; set; }

		/// <summary>
		/// <para>Output Workflow Service Path (*.sddraft)</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("sddraft")]
		public object? OutputWorkflowServiceDraftPath { get; set; }

		/// <summary>
		/// <para>Output Map Service Path (*.sddraft)</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("sddraft")]
		public object? OutputMapServiceDraftPath { get; set; }

		/// <summary>
		/// <para>Overwrite Existing Service</para>
		/// <para>指定是否覆盖服务名称和 AOI 服务名称服务。</para>
		/// <para>选中 - 将覆盖服务。</para>
		/// <para>未选中 - 将不会覆盖服务。 这是默认设置。</para>
		/// <para>如果服务名称、AOI 服务名称和服务器文件夹与现有服务名称和位置不匹配，则系统将发布新服务。</para>
		/// <para><see cref="OverwriteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Overwrite { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Overwrite Existing Service</para>
		/// </summary>
		public enum OverwriteEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("OVERWRITE")]
			OVERWRITE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_OVERWRITE")]
			NO_OVERWRITE,

		}

#endregion
	}
}
