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
	/// <para>Update Task Group Metrics</para>
	/// <para>Updates and summarizes task group metrics that are part of the standard Topographic Workflow deployment of Workflow Manager (Classic).</para>
	/// </summary>
	public class UpdateTaskGroupMetrics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="JobId">
		/// <para>Job ID</para>
		/// <para>The job ID of the job that will be updated.</para>
		/// </param>
		public UpdateTaskGroupMetrics(object JobId)
		{
			this.JobId = JobId;
		}

		/// <summary>
		/// <para>Tool Display Name : Update Task Group Metrics</para>
		/// </summary>
		public override string DisplayName => "Update Task Group Metrics";

		/// <summary>
		/// <para>Tool Name : UpdateTaskGroupMetrics</para>
		/// </summary>
		public override string ToolName => "UpdateTaskGroupMetrics";

		/// <summary>
		/// <para>Tool Excute Name : topographic.UpdateTaskGroupMetrics</para>
		/// </summary>
		public override string ExcuteName => "topographic.UpdateTaskGroupMetrics";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { JobId, StatusLayer, StatusField, DatabasePath, UpdatedJobId, UpdatedStatusLayer };

		/// <summary>
		/// <para>Job ID</para>
		/// <para>The job ID of the job that will be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object JobId { get; set; }

		/// <summary>
		/// <para>Status Layer</para>
		/// <para>The feature class containing status polygons that keep track of the last time work occurred over an extent. Only use this parameter to update a polygon feature class that is not the standard status polygons created by the Topographic Workflow.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object StatusLayer { get; set; }

		/// <summary>
		/// <para>Status Field</para>
		/// <para>The text or date field in which the last modified date will be stored. The parameter is only enable, if a Status Layer value is defined.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object StatusField { get; set; }

		/// <summary>
		/// <para>Input Database Path</para>
		/// <para>The Workflow Manager (Classic) database connection file (.jtc) that contains the job information. If no connection file is specified, the current default Workflow Manager (Classic) database will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object DatabasePath { get; set; }

		/// <summary>
		/// <para>Updated Job ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object UpdatedJobId { get; set; } = "-1";

		/// <summary>
		/// <para>Updated Status Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object UpdatedStatusLayer { get; set; }

	}
}
