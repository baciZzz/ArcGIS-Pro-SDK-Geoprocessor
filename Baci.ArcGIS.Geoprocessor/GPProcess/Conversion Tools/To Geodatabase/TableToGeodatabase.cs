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
	/// <para>Converts one or more tables to geodatabase tables in an output geodatabase. The inputs can be dBASE, INFO, VPF, OLE DB tables, geodatabase tables, or table views.</para>
	/// </summary>
	public class TableToGeodatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputTable">
		/// <para>Input Table</para>
		/// <para>The list of tables to be converted to geodatabase tables. Input tables can be INFO, dBASE, OLE DB, geodatabase tables, or table views.</para>
		/// </param>
		/// <param name="OutputGeodatabase">
		/// <para>Output Geodatabase</para>
		/// <para>The destination geodatabase where the tables will be placed.</para>
		/// </param>
		public TableToGeodatabase(object InputTable, object OutputGeodatabase)
		{
			this.InputTable = InputTable;
			this.OutputGeodatabase = OutputGeodatabase;
		}

		/// <summary>
		/// <para>Tool Display Name : Table To Geodatabase</para>
		/// </summary>
		public override string DisplayName() => "Table To Geodatabase";

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
		public override object[] Parameters() => new object[] { InputTable, OutputGeodatabase, DerivedGeodatabase };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The list of tables to be converted to geodatabase tables. Input tables can be INFO, dBASE, OLE DB, geodatabase tables, or table views.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InputTable { get; set; }

		/// <summary>
		/// <para>Output Geodatabase</para>
		/// <para>The destination geodatabase where the tables will be placed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object OutputGeodatabase { get; set; }

		/// <summary>
		/// <para>Updated Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object DerivedGeodatabase { get; set; } = "tmp";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TableToGeodatabase SetEnviroment(object configKeyword = null , object extent = null , bool? qualifiedFieldNames = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(configKeyword: configKeyword, extent: extent, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
