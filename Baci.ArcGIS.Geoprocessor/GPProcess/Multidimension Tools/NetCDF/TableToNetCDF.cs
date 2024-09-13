using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.MultidimensionTools
{
	/// <summary>
	/// <para>Table to NetCDF</para>
	/// <para>表至 NetCDF</para>
	/// <para>将表转换为 NetCDF 文件。</para>
	/// </summary>
	public class TableToNetCDF : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>输入表。</para>
		/// </param>
		/// <param name="FieldsToVariables">
		/// <para>Fields to Variables</para>
		/// <para>在 netCDF 文件中创建变量时使用的字段。</para>
		/// <para>Field - 输入要素属性表中的某个字段。</para>
		/// <para>Variable - netCDF 变量名</para>
		/// <para>Units - 由字段表示的数据的单位</para>
		/// </param>
		/// <param name="OutNetcdfFile">
		/// <para>Output netCDF File</para>
		/// <para>输出的 netCDF 文件。 文件名的扩展名必须是 .nc。</para>
		/// </param>
		public TableToNetCDF(object InTable, object FieldsToVariables, object OutNetcdfFile)
		{
			this.InTable = InTable;
			this.FieldsToVariables = FieldsToVariables;
			this.OutNetcdfFile = OutNetcdfFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 表至 NetCDF</para>
		/// </summary>
		public override string DisplayName() => "表至 NetCDF";

		/// <summary>
		/// <para>Tool Name : TableToNetCDF</para>
		/// </summary>
		public override string ToolName() => "TableToNetCDF";

		/// <summary>
		/// <para>Tool Excute Name : md.TableToNetCDF</para>
		/// </summary>
		public override string ExcuteName() => "md.TableToNetCDF";

		/// <summary>
		/// <para>Toolbox Display Name : Multidimension Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Multidimension Tools";

		/// <summary>
		/// <para>Toolbox Alise : md</para>
		/// </summary>
		public override string ToolboxAlise() => "md";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, FieldsToVariables, OutNetcdfFile, FieldsToDimensions };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>输入表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Fields to Variables</para>
		/// <para>在 netCDF 文件中创建变量时使用的字段。</para>
		/// <para>Field - 输入要素属性表中的某个字段。</para>
		/// <para>Variable - netCDF 变量名</para>
		/// <para>Units - 由字段表示的数据的单位</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		public object FieldsToVariables { get; set; }

		/// <summary>
		/// <para>Output netCDF File</para>
		/// <para>输出的 netCDF 文件。 文件名的扩展名必须是 .nc。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object OutNetcdfFile { get; set; }

		/// <summary>
		/// <para>Fields to Dimensions</para>
		/// <para>在 netCDF 文件中创建维度时使用的字段。</para>
		/// <para>Field - 输入表中的某个字段。</para>
		/// <para>Dimension - netCDF 维度名称</para>
		/// <para>Units - 由字段表示的数据的单位</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object FieldsToDimensions { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TableToNetCDF SetEnviroment(object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
