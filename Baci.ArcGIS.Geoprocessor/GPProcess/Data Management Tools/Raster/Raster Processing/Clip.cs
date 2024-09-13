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
	/// <para>Clip Raster</para>
	/// <para>裁剪栅格</para>
	/// <para>裁剪掉栅格数据集、镶嵌数据集或图像服务图层的一部分。</para>
	/// </summary>
	public class Clip : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>要裁剪的栅格数据集、镶嵌数据集或影像服务。</para>
		/// </param>
		/// <param name="Rectangle">
		/// <para>Rectangle</para>
		/// <para>用于定义裁剪栅格时将使用的边界框范围的四个坐标。</para>
		/// <para>如果已设置输出范围参数，则将自动填充 x-min、y-min、x-max 和 y-max 值。 可以使用重置按钮 将矩形范围重置为输入栅格数据集的范围。</para>
		/// <para>如果指定的值未与输入栅格数据集对齐，则该工具可验证是否已使用适当的对齐方式。 这可能会导致输出的范围与指定的范围略有不同。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster Dataset</para>
		/// <para>正在创建的数据集的名称、位置和格式。 确保其支持必要的位深度。</para>
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
		public Clip(object InRaster, object Rectangle, object OutRaster)
		{
			this.InRaster = InRaster;
			this.Rectangle = Rectangle;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 裁剪栅格</para>
		/// </summary>
		public override string DisplayName() => "裁剪栅格";

		/// <summary>
		/// <para>Tool Name : Clip</para>
		/// </summary>
		public override string ToolName() => "Clip";

		/// <summary>
		/// <para>Tool Excute Name : management.Clip</para>
		/// </summary>
		public override string ExcuteName() => "management.Clip";

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
		public override object[] Parameters() => new object[] { InRaster, Rectangle, OutRaster, InTemplateDataset!, NodataValue!, ClippingGeometry!, MaintainClippingExtent! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>要裁剪的栅格数据集、镶嵌数据集或影像服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Rectangle</para>
		/// <para>用于定义裁剪栅格时将使用的边界框范围的四个坐标。</para>
		/// <para>如果已设置输出范围参数，则将自动填充 x-min、y-min、x-max 和 y-max 值。 可以使用重置按钮 将矩形范围重置为输入栅格数据集的范围。</para>
		/// <para>如果指定的值未与输入栅格数据集对齐，则该工具可验证是否已使用适当的对齐方式。 这可能会导致输出的范围与指定的范围略有不同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object Rectangle { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>正在创建的数据集的名称、位置和格式。 确保其支持必要的位深度。</para>
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
		/// <para>Output Extent</para>
		/// <para>将用作范围的栅格数据集或要素类。 裁剪输出包括与最小边界矩形相交的像素。</para>
		/// <para>将某要素类用作输出范围并且要基于面要素进行栅格裁剪时，请选中使用输入要素裁剪几何参数。 选中此参数可能提高输出的像素深度。 确保输出格式可以支持适当的像素深度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? InTemplateDataset { get; set; }

		/// <summary>
		/// <para>NoData Value</para>
		/// <para>充当 NoData 的像素值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? NodataValue { get; set; }

		/// <summary>
		/// <para>Use Input Features for Clipping Geometry</para>
		/// <para>指定是否将数据裁剪为最小外接矩形或要素类的几何。</para>
		/// <para>未选中 - 将使用最小外接矩形来裁剪数据。</para>
		/// <para>选中 - 将使用指定要素类的几何来裁剪数据。 可以增加输出的像素深度；需确保输出格式可以支持适当的像素深度。</para>
		/// <para><see cref="ClippingGeometryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ClippingGeometry { get; set; } = "false";

		/// <summary>
		/// <para>Maintain Clipping Extent</para>
		/// <para>指定裁剪输出中将使用的范围。</para>
		/// <para>选中 - 将调整列数和行数并将对像素进行重采样，以便完全匹配指定的裁剪范围。</para>
		/// <para>未选中 - 将保留输入栅格的像元对齐，并相应地调整输出范围。</para>
		/// <para><see cref="MaintainClippingExtentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? MaintainClippingExtent { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Clip SetEnviroment(object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Use Input Features for Clipping Geometry</para>
		/// </summary>
		public enum ClippingGeometryEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ClippingGeometry")]
			ClippingGeometry,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Maintain Clipping Extent</para>
		/// </summary>
		public enum MaintainClippingExtentEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MAINTAIN_EXTENT")]
			MAINTAIN_EXTENT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MAINTAIN_EXTENT")]
			NO_MAINTAIN_EXTENT,

		}

#endregion
	}
}
