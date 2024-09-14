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
	/// <para>Table To Excel</para>
	/// <para>表转 Excel</para>
	/// <para>将表转换为 Microsoft Excel 文件（.xls 或 .xlsx）。</para>
	/// </summary>
	public class TableToExcel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputTable">
		/// <para>Input Table</para>
		/// <para>要转换为 Excel 文件的一个或多个表。</para>
		/// </param>
		/// <param name="OutputExcelFile">
		/// <para>Output Excel File (.xls or .xlsx)</para>
		/// <para>输出 Excel 文件。 使用 .xls 或 .xlsx 文件扩展名指定 Excel 文件的格式。</para>
		/// </param>
		public TableToExcel(object InputTable, object OutputExcelFile)
		{
			this.InputTable = InputTable;
			this.OutputExcelFile = OutputExcelFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 表转 Excel</para>
		/// </summary>
		public override string DisplayName() => "表转 Excel";

		/// <summary>
		/// <para>Tool Name : TableToExcel</para>
		/// </summary>
		public override string ToolName() => "TableToExcel";

		/// <summary>
		/// <para>Tool Excute Name : conversion.TableToExcel</para>
		/// </summary>
		public override string ExcuteName() => "conversion.TableToExcel";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "transferDomains", "transferGDBAttributeProperties", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputTable, OutputExcelFile, UseFieldAliasAsColumnHeader!, UseDomainAndSubtypeDescription! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>要转换为 Excel 文件的一个或多个表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InputTable { get; set; }

		/// <summary>
		/// <para>Output Excel File (.xls or .xlsx)</para>
		/// <para>输出 Excel 文件。 使用 .xls 或 .xlsx 文件扩展名指定 Excel 文件的格式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xls", "xlsx")]
		public object OutputExcelFile { get; set; }

		/// <summary>
		/// <para>Use field alias as column header</para>
		/// <para>指定是否将输入字段名称或字段别名用作输出列名称。</para>
		/// <para>未选中 - 将使用输入的字段名称来设置列标题。 这是默认设置。</para>
		/// <para>选中 - 使用输入地理数据库表格的字段别名来设置列标题。 如果输入为地图内的图层，请忽略该图层的已设的字段别名。</para>
		/// <para><see cref="UseFieldAliasAsColumnHeaderEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? UseFieldAliasAsColumnHeader { get; set; } = "false";

		/// <summary>
		/// <para>Use domain and subtype description</para>
		/// <para>指定是否将子类型字段或具有编码值属性域的字段中的值传输至输出。</para>
		/// <para>未选中 - 将使用所有的字段值，因为这些字段值均存储在表中。 这是默认设置。</para>
		/// <para>选中 - 对于子类型字段，将使用子类型描述。 对于具有编码值属性域的字段，将使用编码值描述。</para>
		/// <para><see cref="UseDomainAndSubtypeDescriptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? UseDomainAndSubtypeDescription { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TableToExcel SetEnviroment(object? scratchWorkspace = null, bool? transferDomains = null, bool? transferGDBAttributeProperties = null, object? workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, transferDomains: transferDomains, transferGDBAttributeProperties: transferGDBAttributeProperties, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Use field alias as column header</para>
		/// </summary>
		public enum UseFieldAliasAsColumnHeaderEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ALIAS")]
			ALIAS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NAME")]
			NAME,

		}

		/// <summary>
		/// <para>Use domain and subtype description</para>
		/// </summary>
		public enum UseDomainAndSubtypeDescriptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DESCRIPTION")]
			DESCRIPTION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("CODE")]
			CODE,

		}

#endregion
	}
}
