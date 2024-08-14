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
	/// <para>Export Table</para>
	/// <para>Exports the rows of a table or table view to a table.</para>
	/// </summary>
	public class ExportTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The input table containing the rows to be exported to a new table.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>The output table containing the exported rows.</para>
		/// </param>
		public ExportTable(object InTable, object OutTable)
		{
			this.InTable = InTable;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Table</para>
		/// </summary>
		public override string DisplayName => "Export Table";

		/// <summary>
		/// <para>Tool Name : ExportTable</para>
		/// </summary>
		public override string ToolName => "ExportTable";

		/// <summary>
		/// <para>Tool Excute Name : conversion.ExportTable</para>
		/// </summary>
		public override string ExcuteName => "conversion.ExportTable";

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
		public override string[] ValidEnvironments => new string[] { "configKeyword", "extent", "maintainAttachments", "preserveGlobalIds", "qualifiedFieldNames", "scratchWorkspace", "transferDomains", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTable, OutTable, WhereClause!, UseFieldAliasAsName!, FieldMapping!, SortField };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input table containing the rows to be exported to a new table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The output table containing the exported rows.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>An SQL expression used to select a subset of records.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		[Category("Filter")]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Use Field Alias as Name</para>
		/// <para>Specifies whether the input&apos;s field names or field aliases will be used as the output field name.</para>
		/// <para>Unchecked—The input&apos;s field names will be used as the output field names. This is the default.</para>
		/// <para>Checked—The input&apos;s field aliases will be used as the output field names.</para>
		/// <para><see cref="UseFieldAliasAsNameEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Fields")]
		public object? UseFieldAliasAsName { get; set; } = "false";

		/// <summary>
		/// <para>Field Map</para>
		/// <para>The attribute fields that will be in the output with the corresponding field properties and source fields. By default, all fields from the inputs will be included.</para>
		/// <para>Fields can be added, deleted, renamed, and reordered, and you can change their properties.</para>
		/// <para>Merge rules allow you to specify how values from two or more input fields are merged or combined into a single output value. There are several merge rules you can use to determine how the output field will be populated with values.</para>
		/// <para>First—Use the input fields&apos; first value.</para>
		/// <para>Last—Use the input fields&apos; last value.</para>
		/// <para>Join—Concatenate (join) the input field values.</para>
		/// <para>Sum—Calculate the total of the input field values.</para>
		/// <para>Mean—Calculate the mean (average) of the input field values.</para>
		/// <para>Median—Calculate the median (middle) of the input field values.</para>
		/// <para>Mode—Use the value with the highest frequency.</para>
		/// <para>Min—Use the minimum value of all the input field values.</para>
		/// <para>Max—Use the maximum value of all the input field values.</para>
		/// <para>Standard deviation—Use the standard deviation classification method on all the input field values.</para>
		/// <para>Count—Find the number of records included in the calculation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFieldMapping()]
		[Category("Fields")]
		public object? FieldMapping { get; set; }

		/// <summary>
		/// <para>Sort Field</para>
		/// <para>The field or fields whose values will be used to reorder the input records and the direction the records will be sorted.</para>
		/// <para>Ascending—Records will be sorted from low value to high value.</para>
		/// <para>Descending—Records will be sorted from high value to low value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Sort")]
		public object? SortField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportTable SetEnviroment(object? configKeyword = null , object? extent = null , bool? maintainAttachments = null , bool? preserveGlobalIds = null , bool? qualifiedFieldNames = null , object? scratchWorkspace = null , bool? transferDomains = null , object? workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, extent: extent, maintainAttachments: maintainAttachments, preserveGlobalIds: preserveGlobalIds, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, transferDomains: transferDomains, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Use Field Alias as Name</para>
		/// </summary>
		public enum UseFieldAliasAsNameEnum 
		{
			/// <summary>
			/// <para>Checked—The input&apos;s field aliases will be used as the output field names.</para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_ALIAS")]
			USE_ALIAS,

			/// <summary>
			/// <para>Unchecked—The input&apos;s field names will be used as the output field names. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_USE_ALIAS")]
			NOT_USE_ALIAS,

		}

#endregion
	}
}
