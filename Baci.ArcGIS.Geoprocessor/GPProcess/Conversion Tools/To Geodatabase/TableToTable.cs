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
	/// <para>Table To Table</para>
	/// <para>Table To Table</para>
	/// <para>Exports the rows of a table   to a different table.</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.ConversionTools.ExportTable"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.ConversionTools.ExportTable))]
	public class TableToTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRows">
		/// <para>Input Rows</para>
		/// <para>The input table to be exported to a new table.</para>
		/// </param>
		/// <param name="OutPath">
		/// <para>Output Location</para>
		/// <para>The destination where the output table will be written.</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Output Name</para>
		/// <para>The name of the output table.</para>
		/// <para>If the output location is a folder, include an extension such as .csv, .txt, or .dbf to export the table to that format. If the output location is a geodatabase, do not specify an extension.</para>
		/// </param>
		public TableToTable(object InRows, object OutPath, object OutName)
		{
			this.InRows = InRows;
			this.OutPath = OutPath;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : Table To Table</para>
		/// </summary>
		public override string DisplayName() => "Table To Table";

		/// <summary>
		/// <para>Tool Name : TableToTable</para>
		/// </summary>
		public override string ToolName() => "TableToTable";

		/// <summary>
		/// <para>Tool Excute Name : conversion.TableToTable</para>
		/// </summary>
		public override string ExcuteName() => "conversion.TableToTable";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "extent", "maintainAttachments", "preserveGlobalIds", "qualifiedFieldNames", "scratchWorkspace", "transferDomains", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRows, OutPath, OutName, WhereClause!, FieldMapping!, ConfigKeyword!, OutTable! };

		/// <summary>
		/// <para>Input Rows</para>
		/// <para>The input table to be exported to a new table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRows { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>The destination where the output table will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutPath { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output table.</para>
		/// <para>If the output location is a folder, include an extension such as .csv, .txt, or .dbf to export the table to that format. If the output location is a geodatabase, do not specify an extension.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>An SQL expression that will be used to select a subset of records.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

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
		/// <para>Config Keyword</para>
		/// <para>Specifies the default storage parameters (configurations) for geodatabases in a relational database management system (RDBMS). This setting is applicable only when using enterprise geodatabase tables.</para>
		/// <para>Configuration keywords are set by the database administrator.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Geodatabase Settings (optional)")]
		public object? ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object? OutTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TableToTable SetEnviroment(object? configKeyword = null , object? extent = null , bool? maintainAttachments = null , bool? preserveGlobalIds = null , bool? qualifiedFieldNames = null , object? scratchWorkspace = null , bool? transferDomains = null , object? workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, extent: extent, maintainAttachments: maintainAttachments, preserveGlobalIds: preserveGlobalIds, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, transferDomains: transferDomains, workspace: workspace);
			return this;
		}

	}
}
