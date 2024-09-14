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
	/// <para>Update Extended Property</para>
	/// <para>Update Extended Property</para>
	/// <para>Updates an extended property in the identified properties table for the chosen job.</para>
	/// </summary>
	public class UpdateExtendedProperty : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="JobId">
		/// <para>Job ID</para>
		/// <para>The Job ID of the Workflow Manager (Classic) job that will be updated.</para>
		/// </param>
		/// <param name="PropertiesTableName">
		/// <para>Properties Table Name</para>
		/// <para>The name of the extended properties table that will be updated.</para>
		/// </param>
		/// <param name="PropertyField">
		/// <para>Property Field</para>
		/// <para>The property to be updated in the extended properties table.</para>
		/// </param>
		/// <param name="Value">
		/// <para>Value</para>
		/// <para>The value that will be set for the extended property.</para>
		/// </param>
		public UpdateExtendedProperty(object JobId, object PropertiesTableName, object PropertyField, object Value)
		{
			this.JobId = JobId;
			this.PropertiesTableName = PropertiesTableName;
			this.PropertyField = PropertyField;
			this.Value = Value;
		}

		/// <summary>
		/// <para>Tool Display Name : Update Extended Property</para>
		/// </summary>
		public override string DisplayName() => "Update Extended Property";

		/// <summary>
		/// <para>Tool Name : UpdateExtendedProperty</para>
		/// </summary>
		public override string ToolName() => "UpdateExtendedProperty";

		/// <summary>
		/// <para>Tool Excute Name : topographic.UpdateExtendedProperty</para>
		/// </summary>
		public override string ExcuteName() => "topographic.UpdateExtendedProperty";

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
		public override object[] Parameters() => new object[] { JobId, PropertiesTableName, PropertyField, Value, IncrementValue, DatabasePath, UpdatedJobId };

		/// <summary>
		/// <para>Job ID</para>
		/// <para>The Job ID of the Workflow Manager (Classic) job that will be updated.</para>
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
		/// <para>The property to be updated in the extended properties table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object PropertyField { get; set; }

		/// <summary>
		/// <para>Value</para>
		/// <para>The value that will be set for the extended property.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Value { get; set; }

		/// <summary>
		/// <para>Increment Value</para>
		/// <para>If a value already exists for the chosen property, this parameter specifies whether the increment value will be added to the current value or will replace the current value.</para>
		/// <para>Checked—The specified value will be added to any existing value for the property.</para>
		/// <para>Unchecked—The specified value will replace the existing value for the property.</para>
		/// <para><see cref="IncrementValueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncrementValue { get; set; }

		/// <summary>
		/// <para>Input Database Path</para>
		/// <para>The Workflow Manager (Classic) database connection file (.jtc) that contains the job information. If no connection file is specified, the current default Workflow Manager (Classic) database will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jtc")]
		public object DatabasePath { get; set; }

		/// <summary>
		/// <para>Updated Job ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object UpdatedJobId { get; set; } = "-1";

		#region InnerClass

		/// <summary>
		/// <para>Increment Value</para>
		/// </summary>
		public enum IncrementValueEnum 
		{
			/// <summary>
			/// <para>Checked—The specified value will be added to any existing value for the property.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCREMENT")]
			INCREMENT,

			/// <summary>
			/// <para>Unchecked—The specified value will replace the existing value for the property.</para>
			/// </summary>
			[GPValue("false")]
			[Description("REPLACE")]
			REPLACE,

		}

#endregion
	}
}
