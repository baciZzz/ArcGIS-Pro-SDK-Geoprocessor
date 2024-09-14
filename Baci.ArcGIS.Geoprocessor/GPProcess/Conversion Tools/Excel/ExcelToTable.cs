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
	/// <para>Excel 转表</para>
	/// <para>将 Microsoft Excel 文件转换为表。</para>
	/// </summary>
	public class ExcelToTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputExcelFile">
		/// <para>Input Excel File</para>
		/// <para>要转换的 Microsoft Excel 文件。</para>
		/// </param>
		/// <param name="OutputTable">
		/// <para>Output Table</para>
		/// <para>输出表。</para>
		/// </param>
		public ExcelToTable(object InputExcelFile, object OutputTable)
		{
			this.InputExcelFile = InputExcelFile;
			this.OutputTable = OutputTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Excel 转表</para>
		/// </summary>
		public override string DisplayName() => "Excel 转表";

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
		public override object[] Parameters() => new object[] { InputExcelFile, OutputTable, Sheet, FieldNamesRow, CellRange };

		/// <summary>
		/// <para>Input Excel File</para>
		/// <para>要转换的 Microsoft Excel 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xls", "xlsx")]
		public object InputExcelFile { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>输出表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutputTable { get; set; }

		/// <summary>
		/// <para>Sheet</para>
		/// <para>要导入的 Excel 文件中特定工作表的名称。如果未指定，则使用工作簿中的第一个工作表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Sheet { get; set; }

		/// <summary>
		/// <para>Row To Use As Field Names</para>
		/// <para>Excel 工作表中包含要用作字段名称的值的行。默认值为 1。</para>
		/// <para>将记录转换为输出表时，会跳过指定的行。</para>
		/// <para>为避免将任何行的值用作字段名称，请将此参数设置为 0，从而将使用列字母来命名输出字段（例如，COL_A、COL_B、COL_C）。</para>
		/// <para>如果特定列中的单元格为空，则输出字段名称将基于列字母。例如，如果输入有三列，并且该行分别在 A、B 和 C 列中包含 &quot;city&quot;、&quot;&quot; 和 &quot;country&quot;，则输出表的字段名称将为：city、COL_B 和 country。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object FieldNamesRow { get; set; } = "1";

		/// <summary>
		/// <para>Cell Range</para>
		/// <para>要包含的单元格范围。</para>
		/// <para>单元格是行和列的交叉点。列由字母（A、B、C、D）标识，行由数字（1、2、3、4）标识。每个单元格都有一个基于其列和行的地址。例如，单元格 B9 是 B 列和第 9 行的交叉点。</para>
		/// <para>单元格范围使用左上单元格和右下单元格定义一个矩形，并用冒号 (:) 进行分隔。单元格范围将被包括在内，因此 A2:C10 的范围将包括 A 到 C 列中第 2 到 10 行中的所有值。</para>
		/// <para>无论在单元格范围中指定的行如何，输出字段名称都是从第 1 行中的单元格值派生的。例如，如果指定的单元格范围是 B2:D10，则字段名称将基于单元格 B1、C1 和 D1 中的值。</para>
		/// <para>以下是有效单元格范围的示例：</para>
		/// <para>A2:C10 - A 到 C 列中第 2 到 10 行的值。</para>
		/// <para>B3:B40 - B 列中第 3 到 40 行的值。</para>
		/// <para>D5:X5 - D 到 X 列中第 5 行的值。</para>
		/// <para>E200:ALM20000 - E 列到 ALM（第 1000 列）中第 200 到 20000 行的值。</para>
		/// <para>以下是无效单元格范围的示例：</para>
		/// <para>A20:C10 - 第一个单元格不能比第二个单元格低（具有较大的行号）。</para>
		/// <para>Z3:B5 - 第一个单元格不能在第二个单元格的右侧（具有较大的列字母）。</para>
		/// <para>A5:G - 两个单元格都必须具有有效的单元格标识符：字母和数字。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object CellRange { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExcelToTable SetEnviroment(object configKeyword = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(configKeyword: configKeyword, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
