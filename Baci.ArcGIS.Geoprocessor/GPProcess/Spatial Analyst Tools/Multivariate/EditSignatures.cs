using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Edit Signatures</para>
	/// <para>编辑特征文件</para>
	/// <para>通过合并、重新编号和删除类特征来编辑和更新特征文件。</para>
	/// </summary>
	public class EditSignatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterBands">
		/// <para>Input raster bands</para>
		/// <para>要编辑特征的输入栅格波段。</para>
		/// <para>可为整型或浮点型。</para>
		/// </param>
		/// <param name="InSignatureFile">
		/// <para>Input signature file</para>
		/// <para>要编辑类特征的输入特征文件。</para>
		/// <para>需要使用 .gsg 扩展名。</para>
		/// </param>
		/// <param name="InSignatureRemapFile">
		/// <para>Input signature remap file</para>
		/// <para>包含要进行合并、重新编号或删除的类 ID 的输入 ASCII 重映射表。</para>
		/// <para>扩展名可以为 .rmp、.asc 或 .txt。默认值为 .rmp。</para>
		/// </param>
		/// <param name="OutSignatureFile">
		/// <para>Output signature file</para>
		/// <para>输出特征文件。</para>
		/// <para>必须指定 .gsg 扩展名。</para>
		/// </param>
		public EditSignatures(object InRasterBands, object InSignatureFile, object InSignatureRemapFile, object OutSignatureFile)
		{
			this.InRasterBands = InRasterBands;
			this.InSignatureFile = InSignatureFile;
			this.InSignatureRemapFile = InSignatureRemapFile;
			this.OutSignatureFile = OutSignatureFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 编辑特征文件</para>
		/// </summary>
		public override string DisplayName() => "编辑特征文件";

		/// <summary>
		/// <para>Tool Name : EditSignatures</para>
		/// </summary>
		public override string ToolName() => "EditSignatures";

		/// <summary>
		/// <para>Tool Excute Name : sa.EditSignatures</para>
		/// </summary>
		public override string ExcuteName() => "sa.EditSignatures";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "cellSizeProjectionMethod", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRasterBands, InSignatureFile, InSignatureRemapFile, OutSignatureFile, SampleInterval! };

		/// <summary>
		/// <para>Input raster bands</para>
		/// <para>要编辑特征的输入栅格波段。</para>
		/// <para>可为整型或浮点型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InRasterBands { get; set; }

		/// <summary>
		/// <para>Input signature file</para>
		/// <para>要编辑类特征的输入特征文件。</para>
		/// <para>需要使用 .gsg 扩展名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("GSG")]
		public object InSignatureFile { get; set; }

		/// <summary>
		/// <para>Input signature remap file</para>
		/// <para>包含要进行合并、重新编号或删除的类 ID 的输入 ASCII 重映射表。</para>
		/// <para>扩展名可以为 .rmp、.asc 或 .txt。默认值为 .rmp。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("RMP", "TXT", "ASC")]
		public object InSignatureRemapFile { get; set; }

		/// <summary>
		/// <para>Output signature file</para>
		/// <para>输出特征文件。</para>
		/// <para>必须指定 .gsg 扩展名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("GSG")]
		public object OutSignatureFile { get; set; }

		/// <summary>
		/// <para>Sample interval</para>
		/// <para>采样所使用的间隔。</para>
		/// <para>默认值为 10。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object? SampleInterval { get; set; } = "10";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EditSignatures SetEnviroment(object? cellSize = null , object? cellSizeProjectionMethod = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? workspace = null )
		{
			base.SetEnv(cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

	}
}
