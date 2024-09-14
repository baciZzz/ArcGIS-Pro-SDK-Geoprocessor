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
	/// <para>Calculate End Date</para>
	/// <para>Calculate End Date</para>
	/// <para>Populates the values for a specified end date field with values calculated using the start date field specified. This tool is useful when the intervals between start date field values are not regular and you want to animate the feature class or table through time or some other value using the Animation toolbar.</para>
	/// </summary>
	[Obsolete()]
	public class CalculateEndDate : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputTable">
		/// <para>Input Table</para>
		/// <para>The feature class or table for which an end date field is calculated based on the start date field specified.</para>
		/// </param>
		/// <param name="StartDateField">
		/// <para>Start Date Field</para>
		/// <para>The field containing values that will be used to calculate values for the end date field. The start date field and the end date field must be of the same format.</para>
		/// </param>
		/// <param name="EndDateField">
		/// <para>End Date Field</para>
		/// <para>The field that will be populated with values based on the start date field specified. The start date field and the end date field must be of the same format.</para>
		/// </param>
		public CalculateEndDate(object InputTable, object StartDateField, object EndDateField)
		{
			this.InputTable = InputTable;
			this.StartDateField = StartDateField;
			this.EndDateField = EndDateField;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate End Date</para>
		/// </summary>
		public override string DisplayName() => "Calculate End Date";

		/// <summary>
		/// <para>Tool Name : CalculateEndDate</para>
		/// </summary>
		public override string ToolName() => "CalculateEndDate";

		/// <summary>
		/// <para>Tool Excute Name : management.CalculateEndDate</para>
		/// </summary>
		public override string ExcuteName() => "management.CalculateEndDate";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputTable, UniqueIDFields!, StartDateField, EndDateField, OutputTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The feature class or table for which an end date field is calculated based on the start date field specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InputTable { get; set; }

		/// <summary>
		/// <para>Unique ID Fields</para>
		/// <para>The name of the field or fields that can be used to uniquely identify spatial entities. This field or these fields are used to first sort based on entity type if there is more than one entity. For instance, for a feature class representing population values per state over time, state name could be the unique value field (the entity). If population figures are per county, you would need to set county name and state name as the unique value fields, since some county names are the same for different states. If there is only one entity, this parameter can be ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? UniqueIDFields { get; set; }

		/// <summary>
		/// <para>Start Date Field</para>
		/// <para>The field containing values that will be used to calculate values for the end date field. The start date field and the end date field must be of the same format.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object StartDateField { get; set; }

		/// <summary>
		/// <para>End Date Field</para>
		/// <para>The field that will be populated with values based on the start date field specified. The start date field and the end date field must be of the same format.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object EndDateField { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object? OutputTable { get; set; } = "Output Table";

	}
}
