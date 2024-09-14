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
	/// <para>Replicate Job Data</para>
	/// <para>Replicates the ArcGIS Workflow Manager (Classic) configuration from a parent repository to child repositories using ArcGIS Workflow Manager (Classic) Server. Each child repository  becomes an identical copy (replica) of the parent repository.</para>
	/// </summary>
	public class CreateJobDataReplica : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputParentRepositoryURL">
		/// <para>Parent Repository URL</para>
		/// <para>The URL for the parent repository as the Workflow Manager (Classic) service URL, for example, http://localhost/arcgis/rest/services/parent/wmserver.</para>
		/// </param>
		/// <param name="InputParentRepositoryName">
		/// <para>Parent Repository Name</para>
		/// <para>The name of the parent repository that will distribute the Workflow Manager (Classic) jobs and configuration elements.</para>
		/// </param>
		/// <param name="InputMultiName">
		/// <para>Child Repository Names and URLs</para>
		/// <para>The child repositories that will be updated with the parent repository configuration. To add a child repository, provide the repository name and click the Add button. After adding the child, provide values for Connected and URL as follows:</para>
		/// <para>Connected—Enter true if the child is a connected replication. Enter false if the child is a disconnected replication.</para>
		/// <para>URL—If Connected is true, provide the URL of the child repository. If Connected is false, provide a folder location to contain the configuration file exported from the parent repository.</para>
		/// </param>
		public CreateJobDataReplica(object InputParentRepositoryURL, object InputParentRepositoryName, object InputMultiName)
		{
			this.InputParentRepositoryURL = InputParentRepositoryURL;
			this.InputParentRepositoryName = InputParentRepositoryName;
			this.InputMultiName = InputMultiName;
		}

		/// <summary>
		/// <para>Tool Display Name : Replicate Job Data</para>
		/// </summary>
		public override string DisplayName() => "Replicate Job Data";

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
		public override object[] Parameters() => new object[] { InputParentRepositoryURL, InputParentRepositoryName, InputMultiName, OutputCreatereplicastatus, OutputLastsync };

		/// <summary>
		/// <para>Parent Repository URL</para>
		/// <para>The URL for the parent repository as the Workflow Manager (Classic) service URL, for example, http://localhost/arcgis/rest/services/parent/wmserver.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InputParentRepositoryURL { get; set; }

		/// <summary>
		/// <para>Parent Repository Name</para>
		/// <para>The name of the parent repository that will distribute the Workflow Manager (Classic) jobs and configuration elements.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InputParentRepositoryName { get; set; }

		/// <summary>
		/// <para>Child Repository Names and URLs</para>
		/// <para>The child repositories that will be updated with the parent repository configuration. To add a child repository, provide the repository name and click the Add button. After adding the child, provide values for Connected and URL as follows:</para>
		/// <para>Connected—Enter true if the child is a connected replication. Enter false if the child is a disconnected replication.</para>
		/// <para>URL—If Connected is true, provide the URL of the child repository. If Connected is false, provide a folder location to contain the configuration file exported from the parent repository.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		public object InputMultiName { get; set; }

		/// <summary>
		/// <para>Create Replica Status</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object OutputCreatereplicastatus { get; set; }

		/// <summary>
		/// <para>Last Syncronized</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPValueTable()]
		public object OutputLastsync { get; set; }

	}
}
