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
	/// <para>Rename</para>
	/// <para>Rename</para>
	/// <para>Changes the name of a dataset.  This includes a variety of data types, including feature dataset, raster, table, and shapefile.</para>
	/// </summary>
	public class Rename : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InData">
		/// <para>Input Data Element</para>
		/// <para>The input data to be renamed.</para>
		/// </param>
		/// <param name="OutData">
		/// <para>Output Data Element</para>
		/// <para>The name for the output data.</para>
		/// </param>
		public Rename(object InData, object OutData)
		{
			this.InData = InData;
			this.OutData = OutData;
		}

		/// <summary>
		/// <para>Tool Display Name : Rename</para>
		/// </summary>
		public override string DisplayName() => "Rename";

		/// <summary>
		/// <para>Tool Name : Rename</para>
		/// </summary>
		public override string ToolName() => "Rename";

		/// <summary>
		/// <para>Tool Excute Name : management.Rename</para>
		/// </summary>
		public override string ExcuteName() => "management.Rename";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InData, OutData, DataType! };

		/// <summary>
		/// <para>Input Data Element</para>
		/// <para>The input data to be renamed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEType()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Output Data Element</para>
		/// <para>The name for the output data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEType()]
		public object OutData { get; set; }

		/// <summary>
		/// <para>Data Type</para>
		/// <para>The type of data to be renamed. The only time you need to provide a value is when a geodatabase contains a feature dataset and a feature class with the same name. In this case, you need to select the data type (feature dataset or feature class) of the item you want to rename.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? DataType { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Rename SetEnviroment(object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
