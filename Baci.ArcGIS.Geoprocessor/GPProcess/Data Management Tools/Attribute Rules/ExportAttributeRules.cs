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
	/// <para>Export Attribute Rules</para>
	/// <para>Export Attribute Rules</para>
	/// <para>Exports attribute rules from a dataset to a comma-separated values (.csv) file.</para>
	/// </summary>
	public class ExportAttributeRules : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The table or feature class from which the attribute rules will be exported.</para>
		/// </param>
		/// <param name="OutCsvFile">
		/// <para>Output File</para>
		/// <para>The folder location and name of the .csv file to be created.</para>
		/// </param>
		public ExportAttributeRules(object InTable, object OutCsvFile)
		{
			this.InTable = InTable;
			this.OutCsvFile = OutCsvFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Attribute Rules</para>
		/// </summary>
		public override string DisplayName() => "Export Attribute Rules";

		/// <summary>
		/// <para>Tool Name : ExportAttributeRules</para>
		/// </summary>
		public override string ToolName() => "ExportAttributeRules";

		/// <summary>
		/// <para>Tool Excute Name : management.ExportAttributeRules</para>
		/// </summary>
		public override string ExcuteName() => "management.ExportAttributeRules";

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
		public override object[] Parameters() => new object[] { InTable, OutCsvFile };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table or feature class from which the attribute rules will be exported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>The folder location and name of the .csv file to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("CSV")]
		public object OutCsvFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportAttributeRules SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
