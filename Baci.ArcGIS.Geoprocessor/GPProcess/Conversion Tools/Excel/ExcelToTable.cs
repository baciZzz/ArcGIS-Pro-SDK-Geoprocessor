using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>Excel To Table</para>
	/// <para>Excel To Table</para>
	/// <para>Converts Microsoft Excel files into a table.</para>
	/// </summary>
	public class ExcelToTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputExcelFile">
		/// <para>Input Excel File</para>
		/// <para>The Excel file to convert.</para>
		/// </param>
		/// <param name="OutputTable">
		/// <para>Output Table</para>
		/// <para>The output table.</para>
		/// </param>
		public ExcelToTable(object InputExcelFile, object OutputTable)
		{
			this.InputExcelFile = InputExcelFile;
			this.OutputTable = OutputTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Excel To Table</para>
		/// </summary>
		public override string DisplayName() => "Excel To Table";

		/// <summary>
		/// <para>Tool Name : ExcelToTable</para>
		/// </summary>
		public override string ToolName() => "ExcelToTable";

		/// <summary>
		/// <para>Tool Excute Name : conversion.ExcelToTable</para>
		/// </summary>
		public override string ExcuteName() => "conversion.ExcelToTable";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputExcelFile, OutputTable, Sheet!, FieldNamesRow!, CellRange! };

		/// <summary>
		/// <para>Input Excel File</para>
		/// <para>The Excel file to convert.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xls", "xlsx")]
		public object InputExcelFile { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The output table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutputTable { get; set; }

		/// <summary>
		/// <para>Sheet</para>
		/// <para>The name of the particular sheet in the Excel file to import. If unspecified, the first sheet in the workbook will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Sheet { get; set; }

		/// <summary>
		/// <para>Row To Use As Field Names</para>
		/// <para>The row in the Excel sheet that contains values to be used as field names. The default value is 1.</para>
		/// <para>The row specified will be skipped when converting records to the output table.</para>
		/// <para>To avoid using any row&apos;s values as field names, set this parameter to 0, which will name the output fields using the column letter (for example, COL_A, COL_B, COL_C).</para>
		/// <para>If a cell in a particular column is empty, the output field name will be based on the column letter. For example, if the input has three columns, and the row contains &quot;city&quot;, &quot;&quot;, and &quot;country&quot; in columns A, B, and C respectively, the output table&apos;s field names will be city, COL_B, and country.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? FieldNamesRow { get; set; } = "1";

		/// <summary>
		/// <para>Cell Range</para>
		/// <para>The cell range to include.</para>
		/// <para>A cell is the intersection of a row and a column. Columns are identified by letters (A, B, C, D), and rows are identified by numbers (1, 2, 3, 4). Each cell has an address based on its column and row. For example, the cell B9 is the intersection of column B and row 9.</para>
		/// <para>A cell range defines a rectangle using the upper left cell and lower right cell, separated by a colon (:). Cell ranges are inclusive, so a range of A2:C10 will include all values in columns A through C and all values in rows 2 through 10.</para>
		/// <para>The output field names are derived from cell values in row 1, regardless of the rows specified in the cell range. For example, if the cell range specified is B2:D10, the field names will be based on the values in cells B1, C1, and D1.</para>
		/// <para>The following are examples of valid cell ranges:</para>
		/// <para>A2:C10—The values in columns A through C, from row 2 through 10</para>
		/// <para>B3:B40—The values in column B, from rows 3 through 40</para>
		/// <para>D5:X5—The values in columns D through X, for row 5</para>
		/// <para>E200:ALM20000—The values in columns E through ALM (1000th column), from row 200 through 20000</para>
		/// <para>The following are examples of invalid cell ranges:</para>
		/// <para>A20:C10—The first cell cannot be lower (have a larger row number) than the second cell.</para>
		/// <para>Z3:B5—The second cell cannot be to the right (have a larger column letter) of the first cell.</para>
		/// <para>A5:G—Both cells must have a valid cell identifier: a letter and a number.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? CellRange { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExcelToTable SetEnviroment(object? configKeyword = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(configKeyword: configKeyword, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
