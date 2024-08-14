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
	/// <para>Refresh Excel</para>
	/// <para>Refreshes a Microsoft Excel file  in ArcGIS Pro.</para>
	/// </summary>
	public class RefreshExcel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InExcelFile">
		/// <para>Input Excel File</para>
		/// <para>The Excel file that will be refreshed.</para>
		/// </param>
		public RefreshExcel(object InExcelFile)
		{
			this.InExcelFile = InExcelFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Refresh Excel</para>
		/// </summary>
		public override string DisplayName => "Refresh Excel";

		/// <summary>
		/// <para>Tool Name : RefreshExcel</para>
		/// </summary>
		public override string ToolName => "RefreshExcel";

		/// <summary>
		/// <para>Tool Excute Name : management.RefreshExcel</para>
		/// </summary>
		public override string ExcuteName => "management.RefreshExcel";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InExcelFile, OutExcelFile };

		/// <summary>
		/// <para>Input Excel File</para>
		/// <para>The Excel file that will be refreshed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object InExcelFile { get; set; }

		/// <summary>
		/// <para>Refreshed Excel File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? OutExcelFile { get; set; }

	}
}
