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
	/// <para>Table Select</para>
	/// <para>Selects table records matching a Structured Query Language (SQL) expression and writes them to an output table.</para>
	/// </summary>
	public class TableSelect : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The table containing records matching the specified expression that will be written to the output table.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>The output table containing records from the input table that match the specified expression.</para>
		/// </param>
		public TableSelect(object InTable, object OutTable)
		{
			this.InTable = InTable;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Table Select</para>
		/// </summary>
		public override string DisplayName => "Table Select";

		/// <summary>
		/// <para>Tool Name : TableSelect</para>
		/// </summary>
		public override string ToolName => "TableSelect";

		/// <summary>
		/// <para>Tool Excute Name : analysis.TableSelect</para>
		/// </summary>
		public override string ExcuteName => "analysis.TableSelect";

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
		public override string[] ValidEnvironments => new string[] { "configKeyword" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTable, OutTable, WhereClause! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table containing records matching the specified expression that will be written to the output table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The output table containing records from the input table that match the specified expression.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>An SQL expression used to select a subset of records.</para>
		/// <para>An SQL expression used to select a subset of records. For more information on SQL syntax, see SQL reference for elements used in query expressions.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? WhereClause { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TableSelect SetEnviroment(object? configKeyword = null )
		{
			base.SetEnv(configKeyword: configKeyword);
			return this;
		}

	}
}
