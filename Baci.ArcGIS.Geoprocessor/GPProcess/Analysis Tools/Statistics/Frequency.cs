using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AnalysisTools
{
	/// <summary>
	/// <para>Frequency</para>
	/// <para>Reads a table and a set of fields and creates a new table containing unique field values and the number of occurrences of each unique field value.</para>
	/// </summary>
	public class Frequency : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The table containing the field(s) that will be used to calculate frequency statistics.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>The output table that will store the frequency statistics.</para>
		/// </param>
		/// <param name="FrequencyFields">
		/// <para>Frequency Field(s)</para>
		/// <para>The field(s) used to calculate frequency statistics. Each unique combination of field values will be included as a new row in the output table.</para>
		/// </param>
		public Frequency(object InTable, object OutTable, object FrequencyFields)
		{
			this.InTable = InTable;
			this.OutTable = OutTable;
			this.FrequencyFields = FrequencyFields;
		}

		/// <summary>
		/// <para>Tool Display Name : Frequency</para>
		/// </summary>
		public override string DisplayName => "Frequency";

		/// <summary>
		/// <para>Tool Name : Frequency</para>
		/// </summary>
		public override string ToolName => "Frequency";

		/// <summary>
		/// <para>Tool Excute Name : analysis.Frequency</para>
		/// </summary>
		public override string ExcuteName => "analysis.Frequency";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "configKeyword", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTable, OutTable, FrequencyFields, SummaryFields };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table containing the field(s) that will be used to calculate frequency statistics.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The output table that will store the frequency statistics.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Frequency Field(s)</para>
		/// <para>The field(s) used to calculate frequency statistics. Each unique combination of field values will be included as a new row in the output table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object FrequencyFields { get; set; }

		/// <summary>
		/// <para>Summary Field(s)</para>
		/// <para>The attribute field(s) to sum and add to the output table. Values will be summed for each unique combination of frequency fields. Null values are excluded from this calculation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object SummaryFields { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Frequency SetEnviroment(object configKeyword = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
