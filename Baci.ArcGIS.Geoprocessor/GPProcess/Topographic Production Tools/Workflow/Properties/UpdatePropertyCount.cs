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
	/// <para>Update Property Count</para>
	/// <para>Increases the value in an extended property by the update value each time the tool is executed so that metrics are recorded.</para>
	/// </summary>
	public class UpdatePropertyCount : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="JobId">
		/// <para>Job ID</para>
		/// <para>The ID of the Workflow Manager (Classic) job that will be updated.</para>
		/// </param>
		/// <param name="PropertiesTableName">
		/// <para>Properties Table Name</para>
		/// <para>The name of the extended properties table that will be updated.</para>
		/// </param>
		/// <param name="PropertyField">
		/// <para>Property Field</para>
		/// <para>The property to be updated in the selected extended properties table.</para>
		/// </param>
		/// <param name="UpdateValue">
		/// <para>Update Value</para>
		/// <para>The value by which the selected extended property will be increased.</para>
		/// </param>
		public UpdatePropertyCount(object JobId, object PropertiesTableName, object PropertyField, object UpdateValue)
		{
			this.JobId = JobId;
			this.PropertiesTableName = PropertiesTableName;
			this.PropertyField = PropertyField;
			this.UpdateValue = UpdateValue;
		}

		/// <summary>
		/// <para>Tool Display Name : Update Property Count</para>
		/// </summary>
		public override string DisplayName => "Update Property Count";

		/// <summary>
		/// <para>Tool Name : UpdatePropertyCount</para>
		/// </summary>
		public override string ToolName => "UpdatePropertyCount";

		/// <summary>
		/// <para>Tool Excute Name : topographic.UpdatePropertyCount</para>
		/// </summary>
		public override string ExcuteName => "topographic.UpdatePropertyCount";

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
		public override object[] Parameters => new object[] { JobId, PropertiesTableName, PropertyField, UpdateValue, DatabasePath!, UpdatedJobId! };

		/// <summary>
		/// <para>Job ID</para>
		/// <para>The ID of the Workflow Manager (Classic) job that will be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object JobId { get; set; }

		/// <summary>
		/// <para>Properties Table Name</para>
		/// <para>The name of the extended properties table that will be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object PropertiesTableName { get; set; }

		/// <summary>
		/// <para>Property Field</para>
		/// <para>The property to be updated in the selected extended properties table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object PropertyField { get; set; }

		/// <summary>
		/// <para>Update Value</para>
		/// <para>The value by which the selected extended property will be increased.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object UpdateValue { get; set; }

		/// <summary>
		/// <para>Input Database Path</para>
		/// <para>The Workflow Manager (Classic) database connection file (.jtc) that contains the job information. If no connection file is specified, the current default Workflow Manager (Classic) database will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object? DatabasePath { get; set; }

		/// <summary>
		/// <para>Updated Job ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object? UpdatedJobId { get; set; } = "-1";

	}
}
