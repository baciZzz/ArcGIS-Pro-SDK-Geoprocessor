using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Merge Branch</para>
	/// <para>Merges two or more logical branches into a single output.</para>
	/// </summary>
	[Obsolete()]
	public class MergeBranch : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		public MergeBranch()
		{
		}

		/// <summary>
		/// <para>Tool Display Name : Merge Branch</para>
		/// </summary>
		public override string DisplayName() => "Merge Branch";

		/// <summary>
		/// <para>Tool Name : MergeBranch</para>
		/// </summary>
		public override string ToolName() => "MergeBranch";

		/// <summary>
		/// <para>Tool Excute Name : management.MergeBranch</para>
		/// </summary>
		public override string ExcuteName() => "management.MergeBranch";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InValues, OutValue };

		/// <summary>
		/// <para>In Values</para>
		/// <para>A list of values from different branches. The first ready-to-run state value in the list will be the output of the tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object InValues { get; set; }

		/// <summary>
		/// <para>output_value</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPType()]
		public object OutValue { get; set; }

	}
}
