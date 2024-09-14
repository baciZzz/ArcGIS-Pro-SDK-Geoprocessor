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
	/// <para>将空间权重矩阵转换为表</para>
	/// <para>用于将二进制空间权重矩阵文件 (.swm) 转换为表。</para>
	/// </summary>
	public class ConvertSpatialWeightsMatrixtoTable : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputSpatialWeightsMatrixFile">
		/// <para>Input Spatial Weights Matrix File</para>
		/// <para>要转换的空间权重矩阵文件 (.swm) 的完整路径名。</para>
		/// </param>
		/// <param name="OutputTable">
		/// <para>Output Table</para>
		/// <para>要创建的表的完整路径名。</para>
		/// </param>
		public ConvertSpatialWeightsMatrixtoTable(object InputSpatialWeightsMatrixFile, object OutputTable)
		{
			this.InputSpatialWeightsMatrixFile = InputSpatialWeightsMatrixFile;
			this.OutputTable = OutputTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 将空间权重矩阵转换为表</para>
		/// </summary>
		public override string DisplayName() => "将空间权重矩阵转换为表";

		/// <summary>
		/// <para>Tool Name : ConvertSpatialWeightsMatrixtoTable</para>
		/// </summary>
		public override string ToolName() => "ConvertSpatialWeightsMatrixtoTable";

		/// <summary>
		/// <para>Tool Excute Name : stats.ConvertSpatialWeightsMatrixtoTable</para>
		/// </summary>
		public override string ExcuteName() => "stats.ConvertSpatialWeightsMatrixtoTable";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise() => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputSpatialWeightsMatrixFile, OutputTable };

		/// <summary>
		/// <para>Input Spatial Weights Matrix File</para>
		/// <para>要转换的空间权重矩阵文件 (.swm) 的完整路径名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("swm", "gwt")]
		public object InputSpatialWeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>要创建的表的完整路径名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutputTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConvertSpatialWeightsMatrixtoTable SetEnviroment(object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
