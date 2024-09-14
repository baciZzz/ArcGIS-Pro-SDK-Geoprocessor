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
	/// <para>Batch Update Fields</para>
	/// <para>Batch Update Fields</para>
	/// <para>Transforms fields in a table or feature class based on schema defined in the definition table and creates a new table or feature class.</para>
	/// </summary>
	public class BatchUpdateFields : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The input table or feature class.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>The output table or feature class containing the updated fields.</para>
		/// </param>
		/// <param name="FieldDefinitionTable">
		/// <para>Output Schema Definition Table</para>
		/// <para>A table containing the field definitions and calculations that will be used to create the output.</para>
		/// </param>
		public BatchUpdateFields(object InTable, object OutTable, object FieldDefinitionTable)
		{
			this.InTable = InTable;
			this.OutTable = OutTable;
			this.FieldDefinitionTable = FieldDefinitionTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Batch Update Fields</para>
		/// </summary>
		public override string DisplayName() => "Batch Update Fields";

		/// <summary>
		/// <para>Tool Name : BatchUpdateFields</para>
		/// </summary>
		public override string ToolName() => "BatchUpdateFields";

		/// <summary>
		/// <para>Tool Excute Name : management.BatchUpdateFields</para>
		/// </summary>
		public override string ExcuteName() => "management.BatchUpdateFields";

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
		public override object[] Parameters() => new object[] { InTable, OutTable, FieldDefinitionTable, ScriptFile!, OutputFieldName!, SourceFieldName!, OutputFieldType!, OutputFieldDecimalsOrLength!, OutputFieldAlias!, OutputFieldScript! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input table or feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The output table or feature class containing the updated fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Output Schema Definition Table</para>
		/// <para>A table containing the field definitions and calculations that will be used to create the output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object FieldDefinitionTable { get; set; }

		/// <summary>
		/// <para>Script File</para>
		/// <para>A Python file that stores multiple line Python functions to perform calculations for the Output Table parameter fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("py")]
		public object? ScriptFile { get; set; }

		/// <summary>
		/// <para>Output Field Name</para>
		/// <para>The field name from the definition table that contains the target field names for the output table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		[Category("Output Schema Definition Table Fields")]
		public object? OutputFieldName { get; set; }

		/// <summary>
		/// <para>Source Field  Name</para>
		/// <para>The field name from the definition table that contains the source field names from the input table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		[Category("Output Schema Definition Table Fields")]
		public object? SourceFieldName { get; set; }

		/// <summary>
		/// <para>Output Field Type</para>
		/// <para>The field name from the definition table that defines the data types for the output table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		[Category("Output Schema Definition Table Fields")]
		public object? OutputFieldType { get; set; }

		/// <summary>
		/// <para>Output Field Decimals or Length</para>
		/// <para>The field name from the definition table that defines the number of decimals or the length of the field for the output fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		[Category("Output Schema Definition Table Fields")]
		public object? OutputFieldDecimalsOrLength { get; set; }

		/// <summary>
		/// <para>Output Field Alias</para>
		/// <para>The field name from the definition table that defines the alias names for the fields of the output table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		[Category("Output Schema Definition Table Fields")]
		public object? OutputFieldAlias { get; set; }

		/// <summary>
		/// <para>Output Field Script</para>
		/// <para>The field name from the definition table that defines the calculations for the output fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		[Category("Output Schema Definition Table Fields")]
		public object? OutputFieldScript { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BatchUpdateFields SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
