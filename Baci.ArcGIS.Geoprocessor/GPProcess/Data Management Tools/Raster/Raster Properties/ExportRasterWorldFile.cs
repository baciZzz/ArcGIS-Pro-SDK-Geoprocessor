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
	/// <para>Creates a world file based on the pixel size and the location of the upper left pixel.</para>
	/// </summary>
	public class ExportRasterWorldFile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterDataset">
		/// <para>Input Raster Dataset</para>
		/// <para>The raster dataset from which you want to create the world file.</para>
		/// </param>
		public ExportRasterWorldFile(object InRasterDataset)
		{
			this.InRasterDataset = InRasterDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Raster World File</para>
		/// </summary>
		public override string DisplayName => "Export Raster World File";

		/// <summary>
		/// <para>Tool Name : ExportRasterWorldFile</para>
		/// </summary>
		public override string ToolName => "ExportRasterWorldFile";

		/// <summary>
		/// <para>Tool Excute Name : management.ExportRasterWorldFile</para>
		/// </summary>
		public override string ExcuteName => "management.ExportRasterWorldFile";

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
		public override string[] ValidEnvironments => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRasterDataset, OutRasterDataset! };

		/// <summary>
		/// <para>Input Raster Dataset</para>
		/// <para>The raster dataset from which you want to create the world file.</para>
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
