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
	/// <para>Synchronize Job Data</para>
	/// <para>Synchronizes multiple Workflow Manager (Classic) repositories participating in a Workflow Manager (Classic) cluster. The tool performs two-way synchronization; changes from the child repositories are sent to the parent repository and changes from the parent are sent to all child repositories.</para>
	/// </summary>
	public class SynchronizeJobData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputParentRepositoryURL">
		/// <para>Parent Repository URL</para>
		/// <para>The URL for the parent repository will be the Workflow Manager (Classic) server URL, for example, http://localhost/arcgis/rest/services/parent/wmserver.</para>
		/// </param>
		/// <param name="InputParentRepositoryName">
		/// <para>Parent Repository Name</para>
		/// <para>The parent repository that will distribute the Workflow Manager (Classic) jobs and configuration elements.</para>
		/// </param>
		/// <param name="InputMultiName">
		/// <para>Child Repository Names and URLs</para>
		/// <para>The child repositories that will be updated with the parent repository configuration. To add a child repository, provide the repository name and click the Add button. After adding the child, enter values for Connected, URL, and Last Sync Time as follows:</para>
		/// <para>Connected—The only accepted value is true. If any other value is provided, the child will not be synchronized.</para>
		/// <para>URL—The URL of the child repository.</para>
		/// <para>Last Sync Time—The date and time in the system format. For example, if your system data and time format is MM:DD:YY HH:MM:SS, the value will be 08/01/2013 11:30:45.</para>
		/// </param>
		public SynchronizeJobData(object InputParentRepositoryURL, object InputParentRepositoryName, object InputMultiName)
		{
			this.InputParentRepositoryURL = InputParentRepositoryURL;
			this.InputParentRepositoryName = InputParentRepositoryName;
			this.InputMultiName = InputMultiName;
		}

		/// <summary>
		/// <para>Tool Display Name : Synchronize Job Data</para>
		/// </summary>
		public override string DisplayName() => "Synchronize Job Data";

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
		public override object[] Parameters() => new object[] { InputParentRepositoryURL, InputParentRepositoryName, InputMultiName, OutputSynchronizereplicastatus!, OutputLastsync! };

		/// <summary>
		/// <para>Parent Repository URL</para>
		/// <para>The URL for the parent repository will be the Workflow Manager (Classic) server URL, for example, http://localhost/arcgis/rest/services/parent/wmserver.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InputParentRepositoryURL { get; set; }

		/// <summary>
		/// <para>Parent Repository Name</para>
		/// <para>The parent repository that will distribute the Workflow Manager (Classic) jobs and configuration elements.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InputParentRepositoryName { get; set; }

		/// <summary>
		/// <para>Child Repository Names and URLs</para>
		/// <para>The child repositories that will be updated with the parent repository configuration. To add a child repository, provide the repository name and click the Add button. After adding the child, enter values for Connected, URL, and Last Sync Time as follows:</para>
		/// <para>Connected—The only accepted value is true. If any other value is provided, the child will not be synchronized.</para>
		/// <para>URL—The URL of the child repository.</para>
		/// <para>Last Sync Time—The date and time in the system format. For example, if your system data and time format is MM:DD:YY HH:MM:SS, the value will be 08/01/2013 11:30:45.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		public object InputMultiName { get; set; }

		/// <summary>
		/// <para>Status of Replica Synchronization</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object? OutputSynchronizereplicastatus { get; set; }

		/// <summary>
		/// <para>Last Synchronized</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPValueTable()]
		public object? OutputLastsync { get; set; }

	}
}
