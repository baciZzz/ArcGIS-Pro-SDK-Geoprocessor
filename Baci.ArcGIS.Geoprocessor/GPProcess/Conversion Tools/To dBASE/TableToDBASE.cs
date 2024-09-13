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
	/// <para>Table To dBASE</para>
	/// <para>表转 dBASE</para>
	/// <para>将一个或多个表转换为 dBASE 表。</para>
	/// </summary>
	public class TableToDBASE : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputTable">
		/// <para>Input Tables</para>
		/// <para>要转换为 dBASE 的一组表。</para>
		/// </param>
		/// <param name="OutputFolder">
		/// <para>Output Folder</para>
		/// <para>用于保存输出 dBASE 表的目标文件夹。</para>
		/// </param>
		public TableToDBASE(object InputTable, object OutputFolder)
		{
			this.InputTable = InputTable;
			this.OutputFolder = OutputFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : 表转 dBASE</para>
		/// </summary>
		public override string DisplayName() => "表转 dBASE";

		/// <summary>
		/// <para>Tool Name : TableToDBASE</para>
		/// </summary>
		public override string ToolName() => "TableToDBASE";

		/// <summary>
		/// <para>Tool Excute Name : conversion.TableToDBASE</para>
		/// </summary>
		public override string ExcuteName() => "conversion.TableToDBASE";

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
		public override string[] ValidEnvironments() => new string[] { "configKeyword", "extent", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputTable, OutputFolder, DerivedFolder };

		/// <summary>
		/// <para>Input Tables</para>
		/// <para>要转换为 dBASE 的一组表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InputTable { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>用于保存输出 dBASE 表的目标文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutputFolder { get; set; }

		/// <summary>
		/// <para>Updated Output Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object DerivedFolder { get; set; } = "tmp";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TableToDBASE SetEnviroment(object configKeyword = null , object extent = null , bool? qualifiedFieldNames = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, extent: extent, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
