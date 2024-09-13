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
	/// <para>Shift</para>
	/// <para>Shift</para>
	/// <para>可根据 x 和 y 平移量将栅格移动（滑动）到新的地理位置。如果需要平移栅格数据集以与其他数据文件对齐，则该工具非常有用。</para>
	/// </summary>
	public class Shift : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>输入栅格数据集。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster Dataset</para>
		/// <para>输出栅格数据集。</para>
		/// <para>以文件格式存储栅格数据集时，请指定文件扩展名，具体如下：</para>
		/// <para>.bil - Esri BIL</para>
		/// <para>.bip - Esri BIP</para>
		/// <para>.bmp - BMP</para>
		/// <para>.bsq - Esri BSQ</para>
		/// <para>.dat - ENVI DAT</para>
		/// <para>.gif - GIF</para>
		/// <para>.img - ERDAS IMAGINE</para>
		/// <para>.jpg - JPEG</para>
		/// <para>.jp2 - JPEG 2000</para>
		/// <para>.png - PNG</para>
		/// <para>.tif - TIFF</para>
		/// <para>.mrf - MRF</para>
		/// <para>.crf - CRF</para>
		/// <para>Esri Grid 无扩展名</para>
		/// <para>将栅格数据集存储到地理数据库时，请勿向栅格数据集的名称添加文件扩展名。</para>
		/// <para>将栅格数据集存储为 JPEG 格式文件、JPEG 2000 格式文件、TIFF 格式文件或地理数据库时，可在地理处理环境中指定压缩类型和压缩质量值。</para>
		/// </param>
		/// <param name="XValue">
		/// <para>Shift X Coordinates by</para>
		/// <para>x 坐标的平移值。</para>
		/// </param>
		/// <param name="YValue">
		/// <para>Shift Y Coordinates by</para>
		/// <para>y 坐标的平移值。</para>
		/// </param>
		public Shift(object InRaster, object OutRaster, object XValue, object YValue)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
			this.XValue = XValue;
			this.YValue = YValue;
		}

		/// <summary>
		/// <para>Tool Display Name : Shift</para>
		/// </summary>
		public override string DisplayName() => "Shift";

		/// <summary>
		/// <para>Tool Name : Shift</para>
		/// </summary>
		public override string ToolName() => "Shift";

		/// <summary>
		/// <para>Tool Excute Name : management.Shift</para>
		/// </summary>
		public override string ExcuteName() => "management.Shift";

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
		public override string[] ValidEnvironments() => new string[] { "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, XValue, YValue, InSnapRaster! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>输入栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>输出栅格数据集。</para>
		/// <para>以文件格式存储栅格数据集时，请指定文件扩展名，具体如下：</para>
		/// <para>.bil - Esri BIL</para>
		/// <para>.bip - Esri BIP</para>
		/// <para>.bmp - BMP</para>
		/// <para>.bsq - Esri BSQ</para>
		/// <para>.dat - ENVI DAT</para>
		/// <para>.gif - GIF</para>
		/// <para>.img - ERDAS IMAGINE</para>
		/// <para>.jpg - JPEG</para>
		/// <para>.jp2 - JPEG 2000</para>
		/// <para>.png - PNG</para>
		/// <para>.tif - TIFF</para>
		/// <para>.mrf - MRF</para>
		/// <para>.crf - CRF</para>
		/// <para>Esri Grid 无扩展名</para>
		/// <para>将栅格数据集存储到地理数据库时，请勿向栅格数据集的名称添加文件扩展名。</para>
		/// <para>将栅格数据集存储为 JPEG 格式文件、JPEG 2000 格式文件、TIFF 格式文件或地理数据库时，可在地理处理环境中指定压缩类型和压缩质量值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Shift X Coordinates by</para>
		/// <para>x 坐标的平移值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object XValue { get; set; }

		/// <summary>
		/// <para>Shift Y Coordinates by</para>
		/// <para>y 坐标的平移值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object YValue { get; set; }

		/// <summary>
		/// <para>Input Snap Raster</para>
		/// <para>用于对齐输出栅格数据集像元的栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRasterLayer()]
		public object? InSnapRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Shift SetEnviroment(object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
