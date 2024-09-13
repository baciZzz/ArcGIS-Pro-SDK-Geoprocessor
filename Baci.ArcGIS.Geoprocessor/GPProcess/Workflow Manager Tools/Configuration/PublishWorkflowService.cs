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
	/// <para>Publish Workflow Service</para>
	/// <para>Uploads and shares a workflow service and a map service of job locations for an ArcGIS Workflow Manager (Classic) repository.</para>
	/// </summary>
	public class PublishWorkflowService : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="ServiceName">
		/// <para>Service Name</para>
		/// <para>The name of the workflow service that will be uploaded and shared.</para>
		/// </param>
		/// <param name="AoiServiceName">
		/// <para>AOI Service Name</para>
		/// <para>The name of the map service that will be uploaded and shared.</para>
		/// </param>
		/// <param name="Server">
		/// <para>Server</para>
		/// <para>The ArcGIS Server connection file (.ags) that contains the information needed to connect to ArcGIS Server or the URL to the ArcGIS Enterprise portal federated server.</para>
		/// </param>
		/// <param name="OutServiceDraftLocation">
		/// <para>Output Service Draft Location</para>
		/// <para>The folder where service definitions will be saved.</para>
		/// </param>
		public PublishWorkflowService(object ServiceName, object AoiServiceName, object Server, object OutServiceDraftLocation)
		{
			this.ServiceName = ServiceName;
			this.AoiServiceName = AoiServiceName;
			this.Server = Server;
			this.OutServiceDraftLocation = OutServiceDraftLocation;
		}

		/// <summary>
		/// <para>Tool Display Name : Publish Workflow Service</para>
		/// </summary>
		public override string DisplayName() => "Publish Workflow Service";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { ServiceName, AoiServiceName, Server, OutServiceDraftLocation, InputDatabasePath!, ServerFolder!, Description!, OutputWorkflowServiceDraftPath!, OutputMapServiceDraftPath!, Overwrite! };

		/// <summary>
		/// <para>Service Name</para>
		/// <para>The name of the workflow service that will be uploaded and shared.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ServiceName { get; set; }

		/// <summary>
		/// <para>AOI Service Name</para>
		/// <para>The name of the map service that will be uploaded and shared.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object AoiServiceName { get; set; }

		/// <summary>
		/// <para>Server</para>
		/// <para>The ArcGIS Server connection file (.ags) that contains the information needed to connect to ArcGIS Server or the URL to the ArcGIS Enterprise portal federated server.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEServerConnection()]
		[GPCodedValueDomain()]
		public object Server { get; set; }

		/// <summary>
		/// <para>Output Service Draft Location</para>
		/// <para>The folder where service definitions will be saved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutServiceDraftLocation { get; set; }

		/// <summary>
		/// <para>Input Database Path (.jtc)</para>
		/// <para>The workflow connection file (.jtc) that contains the information needed to connect to the Workflow Manager (Classic) repository.</para>
		/// <para>The workflow connection in your ArcGIS Pro project will be used if a workflow connection file is not defined.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jtc")]
		public object? InputDatabasePath { get; set; }

		/// <summary>
		/// <para>Server Folder</para>
		/// <para>The folder to which the services will be published on ArcGIS Server.</para>
		/// <para>If a folder is not specified, the services will be published to the root folder of ArcGIS Server.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ServerFolder { get; set; }

		/// <summary>
		/// <para>Description</para>
		/// <para>A description of the services that will be published.</para>
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
		/// <para>Specifies whether the Service Name and AOI Service Name services will be overwritten.</para>
		/// <para>Checked—The services will be overwritten.</para>
		/// <para>Unchecked—The services will not be overwritten. This is the default.</para>
		/// <para>If the Service Name, AOI Service Name, and Server Folder doesn&apos;t match the existing service names and location, new services will be published.</para>
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
			/// <para>Checked—The services will be overwritten.</para>
			/// </summary>
			[GPValue("true")]
			[Description("OVERWRITE")]
			OVERWRITE,

			/// <summary>
			/// <para>Unchecked—The services will not be overwritten. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_OVERWRITE")]
			NO_OVERWRITE,

		}

#endregion
	}
}
