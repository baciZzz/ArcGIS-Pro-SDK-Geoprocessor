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
	/// <para>Table To Geodatabase</para>
	/// <para>表转地理数据库</para>
	/// <para>将一个或多个表转换为输出地理数据库中的地理数据库表。</para>
	/// </summary>
	public class TableToGeodatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputTable">
		/// <para>Input Table</para>
		/// <para>要转换为地理数据库表的表列表。 输入表可以为 INFO、dBASE、OLE DB、地理数据库表或表视图。</para>
		/// </param>
		/// <param name="OutputGeodatabase">
		/// <para>Output Geodatabase</para>
		/// <para>将放置表的目标地理数据库。</para>
		/// </param>
		public TableToGeodatabase(object InputTable, object OutputGeodatabase)
		{
			this.InputTable = InputTable;
			this.OutputGeodatabase = OutputGeodatabase;
		}

		/// <summary>
		/// <para>Tool Display Name : 表转地理数据库</para>
		/// </summary>
		public override string DisplayName() => "表转地理数据库";

		/// <summary>
		/// <para>Tool Name : TableToGeodatabase</para>
		/// </summary>
		public override string ToolName() => "TableToGeodatabase";

		/// <summary>
		/// <para>Tool Excute Name : conversion.TableToGeodatabase</para>
		/// </summary>
		public override string ExcuteName() => "conversion.TableToGeodatabase";

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
		public override object[] Parameters() => new object[] { InputTable, OutputGeodatabase, DerivedGeodatabase! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>要转换为地理数据库表的表列表。 输入表可以为 INFO、dBASE、OLE DB、地理数据库表或表视图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InputTable { get; set; }

		/// <summary>
		/// <para>Output Geodatabase</para>
		/// <para>将放置表的目标地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object OutputGeodatabase { get; set; }

		/// <summary>
		/// <para>Updated Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? DerivedGeodatabase { get; set; } = "tmp";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TableToGeodatabase SetEnviroment(object? configKeyword = null, object? extent = null, bool? qualifiedFieldNames = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(configKeyword: configKeyword, extent: extent, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
