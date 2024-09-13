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
	/// <para>Get Job Version</para>
	/// <para>Get Job Version</para>
	/// <para>Gets the job version as an enterprise geodatabase connection file to process data in a version.</para>
	/// </summary>
	public class GetJobVersion : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputJobid">
		/// <para>Input Job ID</para>
		/// <para>The ID for the job whose version is to be retrieved.</para>
		/// </param>
		public GetJobVersion(object InputJobid)
		{
			this.InputJobid = InputJobid;
		}

		/// <summary>
		/// <para>Tool Display Name : Get Job Version</para>
		/// </summary>
		public override string DisplayName() => "Get Job Version";

		/// <summary>
		/// <para>Tool Name : GetJobVersion</para>
		/// </summary>
		public override string ToolName() => "GetJobVersion";

		/// <summary>
		/// <para>Tool Excute Name : wmx.GetJobVersion</para>
		/// </summary>
		public override string ExcuteName() => "wmx.GetJobVersion";

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
		public override object[] Parameters() => new object[] { InputJobid, InputDatabasepath!, OutputJobversion!, OutputJobversionexists! };

		/// <summary>
		/// <para>Input Job ID</para>
		/// <para>The ID for the job whose version is to be retrieved.</para>
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
		public object? InputDatabasepath { get; set; }

		/// <summary>
		/// <para>Job Version</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutputJobversion { get; set; }

		/// <summary>
		/// <para>Job Version Exists</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? OutputJobversionexists { get; set; }

	}
}
