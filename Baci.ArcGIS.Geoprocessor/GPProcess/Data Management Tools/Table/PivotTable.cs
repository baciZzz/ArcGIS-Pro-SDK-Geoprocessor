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
	/// <para>Pivot Table</para>
	/// <para>Creates a table from the input table by reducing redundancy  in records and flattening one-to-many relationships.</para>
	/// </summary>
	public class PivotTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The table whose records will be pivoted.</para>
		/// </param>
		/// <param name="Fields">
		/// <para>Input Field(s)</para>
		/// <para>The fields that define records to be included in the output table.</para>
		/// </param>
		/// <param name="PivotField">
		/// <para>Pivot Field</para>
		/// <para>The field whose record values are used to generate the field names in the output table.</para>
		/// </param>
		/// <param name="ValueField">
		/// <para>Value Field</para>
		/// <para>The field whose values populate the pivoted fields in the output table.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>The table to be created.</para>
		/// </param>
		public PivotTable(object InTable, object Fields, object PivotField, object ValueField, object OutTable)
		{
			this.InTable = InTable;
			this.Fields = Fields;
			this.PivotField = PivotField;
			this.ValueField = ValueField;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Pivot Table</para>
		/// </summary>
		public override string DisplayName() => "Pivot Table";

		/// <summary>
		/// <para>Tool Name : PivotTable</para>
		/// </summary>
		public override string ToolName() => "PivotTable";

		/// <summary>
		/// <para>Tool Excute Name : management.PivotTable</para>
		/// </summary>
		public override string ExcuteName() => "management.PivotTable";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, Fields, PivotField, ValueField, OutTable };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table whose records will be pivoted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Input Field(s)</para>
		/// <para>The fields that define records to be included in the output table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Fields { get; set; }

		/// <summary>
		/// <para>Pivot Field</para>
		/// <para>The field whose record values are used to generate the field names in the output table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object PivotField { get; set; }

		/// <summary>
		/// <para>Value Field</para>
		/// <para>The field whose values populate the pivoted fields in the output table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object ValueField { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The table to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PivotTable SetEnviroment(object configKeyword = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
