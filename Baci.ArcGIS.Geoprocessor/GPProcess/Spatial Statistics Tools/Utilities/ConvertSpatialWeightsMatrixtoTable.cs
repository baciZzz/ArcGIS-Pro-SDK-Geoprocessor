using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialStatisticsTools
{
	/// <summary>
	/// <para>Convert Spatial Weights Matrix to Table</para>
	/// <para>Converts a binary spatial weights matrix file (.swm) to a table.</para>
	/// </summary>
	public class ConvertSpatialWeightsMatrixtoTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputSpatialWeightsMatrixFile">
		/// <para>Input Spatial Weights Matrix File</para>
		/// <para>The full pathname for the spatial weights matrix file (.swm) you want to convert.</para>
		/// </param>
		/// <param name="OutputTable">
		/// <para>Output Table</para>
		/// <para>A full pathname to the table you want to create.</para>
		/// </param>
		public ConvertSpatialWeightsMatrixtoTable(object InputSpatialWeightsMatrixFile, object OutputTable)
		{
			this.InputSpatialWeightsMatrixFile = InputSpatialWeightsMatrixFile;
			this.OutputTable = OutputTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Convert Spatial Weights Matrix to Table</para>
		/// </summary>
		public override string DisplayName => "Convert Spatial Weights Matrix to Table";

		/// <summary>
		/// <para>Tool Name : ConvertSpatialWeightsMatrixtoTable</para>
		/// </summary>
		public override string ToolName => "ConvertSpatialWeightsMatrixtoTable";

		/// <summary>
		/// <para>Tool Excute Name : stats.ConvertSpatialWeightsMatrixtoTable</para>
		/// </summary>
		public override string ExcuteName => "stats.ConvertSpatialWeightsMatrixtoTable";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputSpatialWeightsMatrixFile, OutputTable };

		/// <summary>
		/// <para>Input Spatial Weights Matrix File</para>
		/// <para>The full pathname for the spatial weights matrix file (.swm) you want to convert.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object InputSpatialWeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>A full pathname to the table you want to create.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutputTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConvertSpatialWeightsMatrixtoTable SetEnviroment(object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
