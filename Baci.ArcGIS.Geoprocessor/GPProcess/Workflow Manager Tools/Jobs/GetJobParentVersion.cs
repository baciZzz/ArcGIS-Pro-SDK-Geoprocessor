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
	/// <para>Get Job Parent Version</para>
	/// <para>Get Job Parent Version</para>
	/// <para>Gets the parent version of a job as an enterprise geodatabase connection file to be used for posting edits in a geoprocessing model to the correct parent version.</para>
	/// </summary>
	public class GetJobParentVersion : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputJobid">
		/// <para>Input Job ID</para>
		/// <para>The ID for the job's parent version to be retrieved.</para>
		/// </param>
		public GetJobParentVersion(object InputJobid)
		{
			this.InputJobid = InputJobid;
		}

		/// <summary>
		/// <para>Tool Display Name : Get Job Parent Version</para>
		/// </summary>
		public override string DisplayName() => "Get Job Parent Version";

		/// <summary>
		/// <para>Tool Name : GetJobParentVersion</para>
		/// </summary>
		public override string ToolName() => "GetJobParentVersion";

		/// <summary>
		/// <para>Tool Excute Name : wmx.GetJobParentVersion</para>
		/// </summary>
		public override string ExcuteName() => "wmx.GetJobParentVersion";

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
		public override object[] Parameters() => new object[] { InputJobid, InputDatabasepath, OutputJobparentversion };

		/// <summary>
		/// <para>Input Job ID</para>
		/// <para>The ID for the job's parent version to be retrieved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InputJobid { get; set; }

		/// <summary>
		/// <para>Input Database Path</para>
		/// <para>The Workflow Manager (Classic) database connection file that contains the job information. If no connection file is specified, the current default Workflow Manager (Classic) database in the project is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jtc")]
		public object InputDatabasepath { get; set; }

		/// <summary>
		/// <para>Job Parent Version</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutputJobparentversion { get; set; }

	}
}
