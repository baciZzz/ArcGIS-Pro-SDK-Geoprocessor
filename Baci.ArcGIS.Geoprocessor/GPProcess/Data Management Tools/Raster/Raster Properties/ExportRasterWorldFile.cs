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
	/// <para>Export Raster World File</para>
	/// <para>导出栅格坐标文件</para>
	/// <para>根据左上角像素的像素大小和位置创建坐标文件。</para>
	/// </summary>
	public class ExportRasterWorldFile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterDataset">
		/// <para>Input Raster Dataset</para>
		/// <para>用于创建坐标文件的栅格数据集。</para>
		/// </param>
		public ExportRasterWorldFile(object InRasterDataset)
		{
			this.InRasterDataset = InRasterDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 导出栅格坐标文件</para>
		/// </summary>
		public override string DisplayName() => "导出栅格坐标文件";

		/// <summary>
		/// <para>Tool Name : ExportRasterWorldFile</para>
		/// </summary>
		public override string ToolName() => "ExportRasterWorldFile";

		/// <summary>
		/// <para>Tool Excute Name : management.ExportRasterWorldFile</para>
		/// </summary>
		public override string ExcuteName() => "management.ExportRasterWorldFile";

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
		public override object[] Parameters() => new object[] { InRasterDataset, OutRasterDataset! };

		/// <summary>
		/// <para>Input Raster Dataset</para>
		/// <para>用于创建坐标文件的栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object InRasterDataset { get; set; }

		/// <summary>
		/// <para>Updated Input Raster Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERasterDataset()]
		public object? OutRasterDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportRasterWorldFile SetEnviroment(object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
