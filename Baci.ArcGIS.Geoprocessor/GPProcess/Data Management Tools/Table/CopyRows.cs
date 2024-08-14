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
	/// <para>Copies the rows of a table  to a different table.</para>
	/// </summary>
	public class CopyRows : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRows">
		/// <para>Input Rows</para>
		/// <para>The input rows to be copied to a new table.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>The table that will be created and to which rows from the input will be copied.</para>
		/// <para>If the output table is in a folder, include an extension such as .csv, .txt, or .dbf to make the table the specified format. If the output table is in a geodatabase, do not specify an extension.</para>
		/// </param>
		public CopyRows(object InRows, object OutTable)
		{
			this.InRows = InRows;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Copy Rows</para>
		/// </summary>
		public override string DisplayName => "Copy Rows";

		/// <summary>
		/// <para>Tool Name : CopyRows</para>
		/// </summary>
		public override string ToolName => "CopyRows";

		/// <summary>
		/// <para>Tool Excute Name : management.CopyRows</para>
		/// </summary>
		public override string ExcuteName => "management.CopyRows";

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
		public override string[] ValidEnvironments => new string[] { "configKeyword", "extent", "maintainAttachments", "preserveGlobalIds", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRows, OutTable, ConfigKeyword! };

		/// <summary>
		/// <para>Input Rows</para>
		/// <para>The input rows to be copied to a new table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRows { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The table that will be created and to which rows from the input will be copied.</para>
		/// <para>If the output table is in a folder, include an extension such as .csv, .txt, or .dbf to make the table the specified format. If the output table is in a geodatabase, do not specify an extension.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		[GPBrowseFiltersDomain()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>The default storage parameters for an enterprise geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CopyRows SetEnviroment(object? configKeyword = null , object? extent = null , bool? maintainAttachments = null , bool? preserveGlobalIds = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, extent: extent, maintainAttachments: maintainAttachments, preserveGlobalIds: preserveGlobalIds, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
