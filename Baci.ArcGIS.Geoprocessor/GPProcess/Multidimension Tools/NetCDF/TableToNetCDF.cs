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
	/// <para>Converts a table to a netCDF file.</para>
	/// </summary>
	public class TableToNetCDF : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The input table.</para>
		/// </param>
		/// <param name="FieldsToVariables">
		/// <para>Fields to Variables</para>
		/// <para>The field or fields used to create variables in the netCDF file.</para>
		/// <para>Field—A field in the input feature attribute table.</para>
		/// <para>Variable—The netCDF variable name</para>
		/// <para>Units—The units of the data represented by the field</para>
		/// </param>
		/// <param name="OutNetcdfFile">
		/// <para>Output netCDF File</para>
		/// <para>The output netCDF file. The file name must have an .nc extension.</para>
		/// </param>
		public TableToNetCDF(object InTable, object FieldsToVariables, object OutNetcdfFile)
		{
			this.InTable = InTable;
			this.FieldsToVariables = FieldsToVariables;
			this.OutNetcdfFile = OutNetcdfFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Table to NetCDF</para>
		/// </summary>
		public override string DisplayName => "Table to NetCDF";

		/// <summary>
		/// <para>Tool Name : TableToNetCDF</para>
		/// </summary>
		public override string ToolName => "TableToNetCDF";

		/// <summary>
		/// <para>Tool Excute Name : md.TableToNetCDF</para>
		/// </summary>
		public override string ExcuteName => "md.TableToNetCDF";

		/// <summary>
		/// <para>Toolbox Display Name : Multidimension Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Multidimension Tools";

		/// <summary>
		/// <para>Toolbox Alise : md</para>
		/// </summary>
		public override string ToolboxAlise => "md";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTable, FieldsToVariables, OutNetcdfFile, FieldsToDimensions };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Fields to Variables</para>
		/// <para>The field or fields used to create variables in the netCDF file.</para>
		/// <para>Field—A field in the input feature attribute table.</para>
		/// <para>Variable—The netCDF variable name</para>
		/// <para>Units—The units of the data represented by the field</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		public object FieldsToVariables { get; set; }

		/// <summary>
		/// <para>Output netCDF File</para>
		/// <para>The output netCDF file. The file name must have an .nc extension.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object OutNetcdfFile { get; set; }

		/// <summary>
		/// <para>Fields to Dimensions</para>
		/// <para>The field or fields used to create dimensions in the netCDF file.</para>
		/// <para>Field—A field in the input table.</para>
		/// <para>Dimension—The netCDF dimension name</para>
		/// <para>Units—The units of the data represented by the field</para>
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
