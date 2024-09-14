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
	/// <para>Copy Rows</para>
	/// <para>复制行</para>
	/// <para>可将表的行复制到不同表中。</para>
	/// </summary>
	public class CopyRows : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRows">
		/// <para>Input Rows</para>
		/// <para>要复制到新表的输入行。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>将要创建以及要将输入中的行复制到的表格。</para>
		/// <para>如果输出表位于文件夹中，则需要包含扩展名，例如 .csv、.txt 或 .dbf，以使表格具有指定格式。 如果输出表位于地理数据库中，则无需指定扩展名。</para>
		/// </param>
		public CopyRows(object InRows, object OutTable)
		{
			this.InRows = InRows;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 复制行</para>
		/// </summary>
		public override string DisplayName() => "复制行";

		/// <summary>
		/// <para>Tool Name : CopyRows</para>
		/// </summary>
		public override string ToolName() => "CopyRows";

		/// <summary>
		/// <para>Tool Excute Name : management.CopyRows</para>
		/// </summary>
		public override string ExcuteName() => "management.CopyRows";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "extent", "maintainAttachments", "preserveGlobalIds", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRows, OutTable, ConfigKeyword! };

		/// <summary>
		/// <para>Input Rows</para>
		/// <para>要复制到新表的输入行。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRows { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>将要创建以及要将输入中的行复制到的表格。</para>
		/// <para>如果输出表位于文件夹中，则需要包含扩展名，例如 .csv、.txt 或 .dbf，以使表格具有指定格式。 如果输出表位于地理数据库中，则无需指定扩展名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		[GPBrowseFiltersDomain()]
		[Filters("esri_browseDialogFilters_tables_all")]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>企业级地理数据库的默认存储参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CopyRows SetEnviroment(object? configKeyword = null, object? extent = null, bool? maintainAttachments = null, bool? preserveGlobalIds = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(configKeyword: configKeyword, extent: extent, maintainAttachments: maintainAttachments, preserveGlobalIds: preserveGlobalIds, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
