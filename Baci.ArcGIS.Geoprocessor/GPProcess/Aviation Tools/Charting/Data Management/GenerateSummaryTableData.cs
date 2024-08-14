using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AviationTools
{
	/// <summary>
	/// <para>Generate Summary Table Data</para>
	/// <para>Collects information from related tables in a selected aviation charting database and outputs the resulting information to a table.</para>
	/// </summary>
	public class GenerateSummaryTableData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetGeodatabase">
		/// <para>Target Geodatabase</para>
		/// <para>The Aviation charting schema geodatabase.</para>
		/// </param>
		/// <param name="InPreferences">
		/// <para>Input Preferences</para>
		/// <para>The preferences stored in the database that control how, and for which charts, summary table information will be generated.</para>
		/// </param>
		/// <param name="InChartsTable">
		/// <para>Charts Table</para>
		/// <para>The table containing information specific to each chart processed by the tool according to preferences stored in the database.</para>
		/// </param>
		public GenerateSummaryTableData(object TargetGeodatabase, object InPreferences, object InChartsTable)
		{
			this.TargetGeodatabase = TargetGeodatabase;
			this.InPreferences = InPreferences;
			this.InChartsTable = InChartsTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Summary Table Data</para>
		/// </summary>
		public override string DisplayName => "Generate Summary Table Data";

		/// <summary>
		/// <para>Tool Name : GenerateSummaryTableData</para>
		/// </summary>
		public override string ToolName => "GenerateSummaryTableData";

		/// <summary>
		/// <para>Tool Excute Name : aviation.GenerateSummaryTableData</para>
		/// </summary>
		public override string ExcuteName => "aviation.GenerateSummaryTableData";

		/// <summary>
		/// <para>Toolbox Display Name : Aviation Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Aviation Tools";

		/// <summary>
		/// <para>Toolbox Alise : aviation</para>
		/// </summary>
		public override string ToolboxAlise => "aviation";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { TargetGeodatabase, InPreferences, InChartsTable, OutWorkspace };

		/// <summary>
		/// <para>Target Geodatabase</para>
		/// <para>The Aviation charting schema geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object TargetGeodatabase { get; set; }

		/// <summary>
		/// <para>Input Preferences</para>
		/// <para>The preferences stored in the database that control how, and for which charts, summary table information will be generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object InPreferences { get; set; }

		/// <summary>
		/// <para>Charts Table</para>
		/// <para>The table containing information specific to each chart processed by the tool according to preferences stored in the database.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[GPTablesDomain()]
		public object InChartsTable { get; set; }

		/// <summary>
		/// <para>Output Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

	}
}
