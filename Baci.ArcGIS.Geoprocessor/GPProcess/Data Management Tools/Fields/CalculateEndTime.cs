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
	/// <para>Calculate End Time</para>
	/// <para>Calculate End Time</para>
	/// <para>Calculates the end time of features based on the time values stored in another field.</para>
	/// </summary>
	public class CalculateEndTime : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The feature class or table for which an End Time Field is calculated based on the Start Time Field specified.</para>
		/// </param>
		/// <param name="StartField">
		/// <para>Start Time Field</para>
		/// <para>The field containing values that will be used to calculate values for the End Time Field. The Start Time Field and the End Time Field must be of the same type. For example, if the Start Time Field is of type LONG, the End Time Field should be of type LONG as well.</para>
		/// </param>
		/// <param name="EndField">
		/// <para>End Time Field</para>
		/// <para>The field that will be populated with values based on the Start Time Field specified. The Start Time Field and the End Time Field must be of the same format.</para>
		/// </param>
		public CalculateEndTime(object InTable, object StartField, object EndField)
		{
			this.InTable = InTable;
			this.StartField = StartField;
			this.EndField = EndField;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate End Time</para>
		/// </summary>
		public override string DisplayName() => "Calculate End Time";

		/// <summary>
		/// <para>Tool Name : CalculateEndTime</para>
		/// </summary>
		public override string ToolName() => "CalculateEndTime";

		/// <summary>
		/// <para>Tool Excute Name : management.CalculateEndTime</para>
		/// </summary>
		public override string ExcuteName() => "management.CalculateEndTime";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, StartField, EndField, Fields!, OutTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The feature class or table for which an End Time Field is calculated based on the Start Time Field specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Start Time Field</para>
		/// <para>The field containing values that will be used to calculate values for the End Time Field. The Start Time Field and the End Time Field must be of the same type. For example, if the Start Time Field is of type LONG, the End Time Field should be of type LONG as well.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object StartField { get; set; }

		/// <summary>
		/// <para>End Time Field</para>
		/// <para>The field that will be populated with values based on the Start Time Field specified. The Start Time Field and the End Time Field must be of the same format.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object EndField { get; set; }

		/// <summary>
		/// <para>ID Fields</para>
		/// <para>The name of the field or fields that can be used to uniquely identify spatial entities. These fields are used to first sort based on entity type if there is more than one entity. For instance, for a feature class representing population values per state over time, the state name could be the unique value field (the entity). If population figures are per county, you would need to set the county name and state name as the unique value fields, since some county names are the same for different states. If there is only one entity, this parameter can be ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object? Fields { get; set; }

		/// <summary>
		/// <para>Updated Input Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateEndTime SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
