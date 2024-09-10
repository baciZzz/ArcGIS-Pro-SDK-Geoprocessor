using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.BusinessAnalystTools
{
	/// <summary>
	/// <para>Create Target Group</para>
	/// <para>Creates a new target group. A target group is a container for targets that you create, name, and populate with segments from a locally installed Business Analyst dataset.</para>
	/// </summary>
	public class CreateTargetGroup : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetGroup">
		/// <para>Output Target Group</para>
		/// <para>The name for the output target group file.</para>
		/// </param>
		/// <param name="InputType">
		/// <para>Targets</para>
		/// <para>Specifies a list of the targets to be added to the new target group.</para>
		/// <para>Name—The name of the target.</para>
		/// <para>Segments—The segments to be added to the target.</para>
		/// <para>Color—The color associated with the segment.</para>
		/// </param>
		public CreateTargetGroup(object TargetGroup, object InputType)
		{
			this.TargetGroup = TargetGroup;
			this.InputType = InputType;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Target Group</para>
		/// </summary>
		public override string DisplayName() => "Create Target Group";

		/// <summary>
		/// <para>Tool Name : CreateTargetGroup</para>
		/// </summary>
		public override string ToolName() => "CreateTargetGroup";

		/// <summary>
		/// <para>Tool Excute Name : ba.CreateTargetGroup</para>
		/// </summary>
		public override string ExcuteName() => "ba.CreateTargetGroup";

		/// <summary>
		/// <para>Toolbox Display Name : Business Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Business Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ba</para>
		/// </summary>
		public override string ToolboxAlise() => "ba";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "baDataSource", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { TargetGroup, InputType };

		/// <summary>
		/// <para>Output Target Group</para>
		/// <para>The name for the output target group file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("sgtargetgroup")]
		public object TargetGroup { get; set; }

		/// <summary>
		/// <para>Targets</para>
		/// <para>Specifies a list of the targets to be added to the new target group.</para>
		/// <para>Name—The name of the target.</para>
		/// <para>Segments—The segments to be added to the target.</para>
		/// <para>Color—The color associated with the segment.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object InputType { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateTargetGroup SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
