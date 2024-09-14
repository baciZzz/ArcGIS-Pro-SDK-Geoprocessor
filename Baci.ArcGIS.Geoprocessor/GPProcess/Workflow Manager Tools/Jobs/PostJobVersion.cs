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
	/// <para>Post Job Version</para>
	/// <para>Post Job Version</para>
	/// <para>Post the current version edits to the parent version of the job.</para>
	/// </summary>
	public class PostJobVersion : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputJobid">
		/// <para>Input Job ID</para>
		/// <para>The ID for the job whose edits from the job's version are going to be posted to it's parent version.</para>
		/// </param>
		public PostJobVersion(object InputJobid)
		{
			this.InputJobid = InputJobid;
		}

		/// <summary>
		/// <para>Tool Display Name : Post Job Version</para>
		/// </summary>
		public override string DisplayName() => "Post Job Version";

		/// <summary>
		/// <para>Tool Name : PostJobVersion</para>
		/// </summary>
		public override string ToolName() => "PostJobVersion";

		/// <summary>
		/// <para>Tool Excute Name : wmx.PostJobVersion</para>
		/// </summary>
		public override string ExcuteName() => "wmx.PostJobVersion";

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
		public override object[] Parameters() => new object[] { InputJobid, InputDatabasepath!, OutputStatus! };

		/// <summary>
		/// <para>Input Job ID</para>
		/// <para>The ID for the job whose edits from the job's version are going to be posted to it's parent version.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InputJobid { get; set; }

		/// <summary>
		/// <para>Input Database Path</para>
		/// <para>The Workflow Manager (Classic) database connection file that contains the job information. If no connection file is specified, the current default Workflow Manager (Classic) database will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jtc")]
		public object? InputDatabasepath { get; set; }

		/// <summary>
		/// <para>Post Job Version Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object? OutputStatus { get; set; }

	}
}
