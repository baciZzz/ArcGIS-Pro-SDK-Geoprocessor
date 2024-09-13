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
	/// <para>Raster To Other Format</para>
	/// <para>栅格转其他格式</para>
	/// <para>将一个或多个栅格数据集转换为其他格式。</para>
	/// </summary>
	public class RasterToOtherFormat : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputRasters">
		/// <para>Input Rasters</para>
		/// <para>待转换的栅格数据集。</para>
		/// </param>
		/// <param name="OutputWorkspace">
		/// <para>Output Workspace</para>
		/// <para>将写入栅格数据集的文件夹。</para>
		/// </param>
		public RasterToOtherFormat(object InputRasters, object OutputWorkspace)
		{
			this.InputRasters = InputRasters;
			this.OutputWorkspace = OutputWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : 栅格转其他格式</para>
		/// </summary>
		public override string DisplayName() => "栅格转其他格式";

		/// <summary>
		/// <para>Tool Name : RasterToOtherFormat</para>
		/// </summary>
		public override string ToolName() => "RasterToOtherFormat";

		/// <summary>
		/// <para>Tool Excute Name : conversion.RasterToOtherFormat</para>
		/// </summary>
		public override string ExcuteName() => "conversion.RasterToOtherFormat";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "ZDomain", "ZResolution", "compression", "configKeyword", "extent", "nodata", "outputCoordinateSystem", "outputZFlag", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputRasters, OutputWorkspace, RasterFormat!, DerivedWorkspace! };

		/// <summary>
		/// <para>Input Rasters</para>
		/// <para>待转换的栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InputRasters { get; set; }

		/// <summary>
		/// <para>Output Workspace</para>
		/// <para>将写入栅格数据集的文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object OutputWorkspace { get; set; }

		/// <summary>
		/// <para>Raster Format</para>
		/// <para>新栅格数据集的格式。</para>
		/// <para>BIL—Esri 波段按行交叉格式文件</para>
		/// <para>BIP—Esri 波段按像素交叉格式文件</para>
		/// <para>BMP—Microsoft 位图图形栅格数据集格式</para>
		/// <para>BSQ—Esri 波段顺序格式文件</para>
		/// <para>CRF—云栅格格式</para>
		/// <para>ENVI DAT 文件—ENVI DAT 文件</para>
		/// <para>GIF—栅格数据集的图形交换格式</para>
		/// <para>Esri Grid—Esri 格网栅格数据集格式</para>
		/// <para>ERDAS IMAGINE 文件—ERDAS IMAGINE 栅格数据格式</para>
		/// <para>JPEG 2000—JPEG 2000 栅格数据集格式</para>
		/// <para>JPEG—联合图像专家组栅格数据集格式</para>
		/// <para>MRF—元栅格格式</para>
		/// <para>PNG—可移植网络图形栅格数据集格式</para>
		/// <para>TIFF—栅格数据集的标记图像文件格式</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? RasterFormat { get; set; } = "TIFF";

		/// <summary>
		/// <para>Updated Output Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? DerivedWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RasterToOtherFormat SetEnviroment(object? XYDomain = null , object? ZDomain = null , object? ZResolution = null , object? compression = null , object? configKeyword = null , object? extent = null , object? nodata = null , object? outputCoordinateSystem = null , object? outputZFlag = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, ZDomain: ZDomain, ZResolution: ZResolution, compression: compression, configKeyword: configKeyword, extent: extent, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, outputZFlag: outputZFlag, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
