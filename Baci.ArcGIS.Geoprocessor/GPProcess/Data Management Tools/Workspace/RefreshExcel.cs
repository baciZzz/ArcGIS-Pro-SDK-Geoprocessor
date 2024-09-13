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
	/// <para>刷新 Excel</para>
	/// <para>刷新 ArcGIS Pro 中的 Microsoft Excel 文件。</para>
	/// </summary>
	public class RefreshExcel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InExcelFile">
		/// <para>Input Excel File</para>
		/// <para>将刷新 Excel 文件。</para>
		/// </param>
		public RefreshExcel(object InExcelFile)
		{
			this.InExcelFile = InExcelFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 刷新 Excel</para>
		/// </summary>
		public override string DisplayName() => "刷新 Excel";

		/// <summary>
		/// <para>Tool Name : RefreshExcel</para>
		/// </summary>
		public override string ToolName() => "RefreshExcel";

		/// <summary>
		/// <para>Tool Excute Name : management.RefreshExcel</para>
		/// </summary>
		public override string ExcuteName() => "management.RefreshExcel";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InExcelFile, OutExcelFile! };

		/// <summary>
		/// <para>Input Excel File</para>
		/// <para>将刷新 Excel 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xls", "xlsx")]
		public object InExcelFile { get; set; }

		/// <summary>
		/// <para>Refreshed Excel File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? OutExcelFile { get; set; }

	}
}
