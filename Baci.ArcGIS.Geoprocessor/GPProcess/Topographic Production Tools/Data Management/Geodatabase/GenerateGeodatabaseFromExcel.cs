using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Generate Geodatabase From Excel</para>
	/// <para>Generate Geodatabase From Excel</para>
	/// <para>Creates a geodatabase from the contents of a Microsoft Excel file (.xls or .xlsx).</para>
	/// </summary>
	public class GenerateGeodatabaseFromExcel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InExcelFile">
		/// <para>Input Excel File</para>
		/// <para>The Excel file that will be used to generate the geodatabase.</para>
		/// </param>
		/// <param name="OutGeodatabase">
		/// <para>Output Geodatabase</para>
		/// <para>The geodatabase that will be generated from the Excel file.</para>
		/// </param>
		public GenerateGeodatabaseFromExcel(object InExcelFile, object OutGeodatabase)
		{
			this.InExcelFile = InExcelFile;
			this.OutGeodatabase = OutGeodatabase;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Geodatabase From Excel</para>
		/// </summary>
		public override string DisplayName() => "Generate Geodatabase From Excel";

		/// <summary>
		/// <para>Tool Name : GenerateGeodatabaseFromExcel</para>
		/// </summary>
		public override string ToolName() => "GenerateGeodatabaseFromExcel";

		/// <summary>
		/// <para>Tool Excute Name : topographic.GenerateGeodatabaseFromExcel</para>
		/// </summary>
		public override string ExcuteName() => "topographic.GenerateGeodatabaseFromExcel";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise() => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InExcelFile, OutGeodatabase, UpdatedGeodatabase! };

		/// <summary>
		/// <para>Input Excel File</para>
		/// <para>The Excel file that will be used to generate the geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xls", "xlsx")]
		public object InExcelFile { get; set; }

		/// <summary>
		/// <para>Output Geodatabase</para>
		/// <para>The geodatabase that will be generated from the Excel file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object OutGeodatabase { get; set; }

		/// <summary>
		/// <para>Updated Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object? UpdatedGeodatabase { get; set; }

	}
}
