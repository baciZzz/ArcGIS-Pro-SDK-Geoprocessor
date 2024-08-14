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
	/// <para>Converts  a table to a Microsoft Excel file (.xls or .xlsx).</para>
	/// </summary>
	public class TableToExcel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputTable">
		/// <para>Input Table</para>
		/// <para>The table to be converted to Microsoft Excel.</para>
		/// </param>
		/// <param name="OutputExcelFile">
		/// <para>Output Excel File (.xls or .xlsx)</para>
		/// <para>The output Excel file. Specify the format of the Excel file using an .xls or .xlsx file extension.</para>
		/// </param>
		public TableToExcel(object InputTable, object OutputExcelFile)
		{
			this.InputTable = InputTable;
			this.OutputExcelFile = OutputExcelFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Table To Excel</para>
		/// </summary>
		public override string DisplayName => "Table To Excel";

		/// <summary>
		/// <para>Tool Name : TableToExcel</para>
		/// </summary>
		public override string ToolName => "TableToExcel";

		/// <summary>
		/// <para>Tool Excute Name : conversion.TableToExcel</para>
		/// </summary>
		public override string ExcuteName => "conversion.TableToExcel";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "scratchWorkspace", "transferDomains", "transferGDBAttributeProperties", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputTable, OutputExcelFile, UseFieldAliasAsColumnHeader, UseDomainAndSubtypeDescription };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table to be converted to Microsoft Excel.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InputTable { get; set; }

		/// <summary>
		/// <para>Output Excel File (.xls or .xlsx)</para>
		/// <para>The output Excel file. Specify the format of the Excel file using an .xls or .xlsx file extension.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutputExcelFile { get; set; }

		/// <summary>
		/// <para>Use field alias as column header</para>
		/// <para>Specifies how column names in the output are determined.</para>
		/// <para>Unchecked—Column headers will be set using the input&apos;s field names. This is the default.</para>
		/// <para>Checked—Column headers will be set using the input geodatabase table&apos;s field aliases. If the input is a layer in a map, the value set on the layer&apos;s field alias is ignored.</para>
		/// <para><see cref="UseFieldAliasAsColumnHeaderEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UseFieldAliasAsColumnHeader { get; set; } = "false";

		/// <summary>
		/// <para>Use domain and subtype description</para>
		/// <para>Controls how values from subtype fields or fields with a coded value domain are transferred to the output.</para>
		/// <para>Unchecked—All field values will be used as they are stored in the table. This is the default.</para>
		/// <para>Checked—For subtype fields, the subtype description will be used. For fields with a coded value domain, the coded value descriptions will be used.</para>
		/// <para><see cref="UseDomainAndSubtypeDescriptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UseDomainAndSubtypeDescription { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TableToExcel SetEnviroment(object scratchWorkspace = null , bool? transferDomains = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, transferDomains: transferDomains, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Use field alias as column header</para>
		/// </summary>
		public enum UseFieldAliasAsColumnHeaderEnum 
		{
			/// <summary>
			/// <para>Checked—Column headers will be set using the input geodatabase table&apos;s field aliases. If the input is a layer in a map, the value set on the layer&apos;s field alias is ignored.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ALIAS")]
			ALIAS,

			/// <summary>
			/// <para>Unchecked—Column headers will be set using the input&apos;s field names. This is the default.</para>
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
			/// <para>Checked—For subtype fields, the subtype description will be used. For fields with a coded value domain, the coded value descriptions will be used.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DESCRIPTION")]
			DESCRIPTION,

			/// <summary>
			/// <para>Unchecked—All field values will be used as they are stored in the table. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("CODE")]
			CODE,

		}

#endregion
	}
}
