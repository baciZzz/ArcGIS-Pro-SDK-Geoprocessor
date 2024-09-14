using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Set Production Properties</para>
	/// <para>Set Production Properties</para>
	/// <para>Updates the production properties extended properties table of a Workflow Manager (Classic) job based on its production type to ensure that the job and any associated tasks use the correct data and maps.</para>
	/// </summary>
	public class SetProductionProperties : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="JobId">
		/// <para>Job ID</para>
		/// <para>The ID of the Workflow Manager (Classic) job that will be updated.</para>
		/// </param>
		public SetProductionProperties(object JobId)
		{
			this.JobId = JobId;
		}

		/// <summary>
		/// <para>Tool Display Name : Set Production Properties</para>
		/// </summary>
		public override string DisplayName() => "Set Production Properties";

		/// <summary>
		/// <para>Tool Name : SetProductionProperties</para>
		/// </summary>
		public override string ToolName() => "SetProductionProperties";

		/// <summary>
		/// <para>Tool Excute Name : topographic.SetProductionProperties</para>
		/// </summary>
		public override string ExcuteName() => "topographic.SetProductionProperties";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise() => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { JobId, DatabasePath!, UpdatedJobId! };

		/// <summary>
		/// <para>Job ID</para>
		/// <para>The ID of the Workflow Manager (Classic) job that will be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object JobId { get; set; }

		/// <summary>
		/// <para>Input Database Path</para>
		/// <para>The Workflow Manager (Classic) database connection file (.jtc) that contains the job information. If no connection file is specified, the current default Workflow Manager (Classic) database will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jtc")]
		public object? DatabasePath { get; set; }

		/// <summary>
		/// <para>Updated Job ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object? UpdatedJobId { get; set; } = "-1";

	}
}
