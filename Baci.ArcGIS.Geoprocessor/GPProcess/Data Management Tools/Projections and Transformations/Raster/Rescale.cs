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
	/// <para>Rescale</para>
	/// <para>重设比例</para>
	/// <para>通过指定的 x 和 y 比例因子来调整栅格的大小。</para>
	/// </summary>
	public class Rescale : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>输入栅格。</para>
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
		/// <param name="XScale">
		/// <para>X Scale Factor</para>
		/// <para>用于 x 方向上缩放像元大小的因子。</para>
		/// <para>此因子必须大于零。</para>
		/// </param>
		/// <param name="YScale">
		/// <para>Y Scale Factor</para>
		/// <para>用于 y 方向上缩放像元大小的因子。</para>
		/// <para>此因子必须大于零。</para>
		/// </param>
		public Rescale(object InRaster, object OutRaster, object XScale, object YScale)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
			this.XScale = XScale;
			this.YScale = YScale;
		}

		/// <summary>
		/// <para>Tool Display Name : 重设比例</para>
		/// </summary>
		public override string DisplayName() => "重设比例";

		/// <summary>
		/// <para>Tool Name : 重设比例</para>
		/// </summary>
		public override string ToolName() => "重设比例";

		/// <summary>
		/// <para>Tool Excute Name : management.Rescale</para>
		/// </summary>
		public override string ExcuteName() => "management.Rescale";

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
		public override object[] Parameters() => new object[] { InRaster, OutRaster, XScale, YScale };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>输入栅格。</para>
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
		/// <para>X Scale Factor</para>
		/// <para>用于 x 方向上缩放像元大小的因子。</para>
		/// <para>此因子必须大于零。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object XScale { get; set; }

		/// <summary>
		/// <para>Y Scale Factor</para>
		/// <para>用于 y 方向上缩放像元大小的因子。</para>
		/// <para>此因子必须大于零。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object YScale { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Rescale SetEnviroment(object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
