using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ServerTools
{
	/// <summary>
	/// <para>Extract Data Task</para>
	/// <para>提取数据任务</para>
	/// <para>将指定感兴趣区域中的所选图层提取为选定的格式和空间参考，然后返回 .zip 文件中的数据。</para>
	/// </summary>
	public class ExtractDataTask : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="LayersToClip">
		/// <para>Layers to Clip</para>
		/// <para>要裁剪的图层。 图层必须是要素或栅格；不支持图层文件。</para>
		/// </param>
		/// <param name="AreaOfInterest">
		/// <para>Area of Interest</para>
		/// <para>裁剪图层所依据的一个或多个面。</para>
		/// </param>
		/// <param name="FeatureFormat">
		/// <para>Feature Format</para>
		/// <para>指定输出要素的格式。 格式应指定如下：</para>
		/// <para>名称或格式 - 名称缩写 - 扩展名（如果存在）</para>
		/// <para>必须使用连字符且连字符前后必须各有一个空格。</para>
		/// <para>例如：</para>
		/// <para>File Geodatabase - GDB - .gdb</para>
		/// <para>Shapefile - SHP - .shp</para>
		/// <para>Autodesk AutoCAD - DXF_R2007 - .dxf</para>
		/// <para>Autodesk AutoCAD - DWG_R2007 - .dwg</para>
		/// <para>Bentley Microstation Design (V8) - DGN_V8 - .dgn</para>
		/// <para>支持的名称缩写列表中包含 DGN_V8、DWG_R14、DWG_R2000、DWG_R2004、DWG_R2005、DWG_R2007、DWG_R2010、DXF_R14、DXF_R2000、DXF_R2004、DXF_R2005、DXF_R2007 和 DXF_R2010。</para>
		/// </param>
		/// <param name="RasterFormat">
		/// <para>Raster Format</para>
		/// <para>指定输出栅格数据集的格式。 格式应指定如下：</para>
		/// <para>格式名称 - 名称缩写 - 扩展名（如果有）。</para>
		/// <para>必须使用连字符且连字符前后必须各有一个空格。</para>
		/// <para>例如：</para>
		/// <para>Esri GRID - GRID</para>
		/// <para>File Geodatabase - GDB - .gdb</para>
		/// <para>ERDAS IMAGINE - IMG - .img</para>
		/// <para>Tagged Image File Format - TIFF - .tif</para>
		/// <para>Portable Network Graphics - PNG - .png</para>
		/// <para>Graphic Interchange Format - GIF - .gif</para>
		/// <para>Joint Photographics Experts Group - JPEG - .jpg</para>
		/// <para>Joint Photographics Experts Group - JPEG - .jp2</para>
		/// <para>Bitmap - BMP - .bmp</para>
		/// <para>上述的某些栅格格式存在限制，所以并非所有数据都可以转换为此格式。</para>
		/// <para><see cref="RasterFormatEnum"/></para>
		/// </param>
		/// <param name="OutputZipFile">
		/// <para>Output Zip File</para>
		/// <para>包含已提取的数据的 zip 文件。</para>
		/// </param>
		public ExtractDataTask(object LayersToClip, object AreaOfInterest, object FeatureFormat, object RasterFormat, object OutputZipFile)
		{
			this.LayersToClip = LayersToClip;
			this.AreaOfInterest = AreaOfInterest;
			this.FeatureFormat = FeatureFormat;
			this.RasterFormat = RasterFormat;
			this.OutputZipFile = OutputZipFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 提取数据任务</para>
		/// </summary>
		public override string DisplayName() => "提取数据任务";

		/// <summary>
		/// <para>Tool Name : ExtractDataTask</para>
		/// </summary>
		public override string ToolName() => "ExtractDataTask";

		/// <summary>
		/// <para>Tool Excute Name : server.ExtractDataTask</para>
		/// </summary>
		public override string ExcuteName() => "server.ExtractDataTask";

		/// <summary>
		/// <para>Toolbox Display Name : Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : server</para>
		/// </summary>
		public override string ToolboxAlise() => "server";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { LayersToClip, AreaOfInterest, FeatureFormat, RasterFormat, OutputZipFile };

		/// <summary>
		/// <para>Layers to Clip</para>
		/// <para>要裁剪的图层。 图层必须是要素或栅格；不支持图层文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object LayersToClip { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>裁剪图层所依据的一个或多个面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Feature Format</para>
		/// <para>指定输出要素的格式。 格式应指定如下：</para>
		/// <para>名称或格式 - 名称缩写 - 扩展名（如果存在）</para>
		/// <para>必须使用连字符且连字符前后必须各有一个空格。</para>
		/// <para>例如：</para>
		/// <para>File Geodatabase - GDB - .gdb</para>
		/// <para>Shapefile - SHP - .shp</para>
		/// <para>Autodesk AutoCAD - DXF_R2007 - .dxf</para>
		/// <para>Autodesk AutoCAD - DWG_R2007 - .dwg</para>
		/// <para>Bentley Microstation Design (V8) - DGN_V8 - .dgn</para>
		/// <para>支持的名称缩写列表中包含 DGN_V8、DWG_R14、DWG_R2000、DWG_R2004、DWG_R2005、DWG_R2007、DWG_R2010、DXF_R14、DXF_R2000、DXF_R2004、DXF_R2005、DXF_R2007 和 DXF_R2010。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FeatureFormat { get; set; } = "File Geodatabase - GDB - .gdb";

		/// <summary>
		/// <para>Raster Format</para>
		/// <para>指定输出栅格数据集的格式。 格式应指定如下：</para>
		/// <para>格式名称 - 名称缩写 - 扩展名（如果有）。</para>
		/// <para>必须使用连字符且连字符前后必须各有一个空格。</para>
		/// <para>例如：</para>
		/// <para>Esri GRID - GRID</para>
		/// <para>File Geodatabase - GDB - .gdb</para>
		/// <para>ERDAS IMAGINE - IMG - .img</para>
		/// <para>Tagged Image File Format - TIFF - .tif</para>
		/// <para>Portable Network Graphics - PNG - .png</para>
		/// <para>Graphic Interchange Format - GIF - .gif</para>
		/// <para>Joint Photographics Experts Group - JPEG - .jpg</para>
		/// <para>Joint Photographics Experts Group - JPEG - .jp2</para>
		/// <para>Bitmap - BMP - .bmp</para>
		/// <para>上述的某些栅格格式存在限制，所以并非所有数据都可以转换为此格式。</para>
		/// <para><see cref="RasterFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RasterFormat { get; set; } = "ESRI GRID - GRID";

		/// <summary>
		/// <para>Output Zip File</para>
		/// <para>包含已提取的数据的 zip 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object OutputZipFile { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Raster Format</para>
		/// </summary>
		public enum RasterFormatEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("ESRI GRID - GRID")]
			[Description("ESRI GRID - GRID")]
			ESRI_GRID___GRID,

			/// <summary>
			/// <para>File Geodatabase - GDB - .gdb</para>
			/// </summary>
			[GPValue("File Geodatabase - GDB - .gdb")]
			[Description("File Geodatabase - GDB - .gdb")]
			File_Geodatabase___GDB___gdb,

			/// <summary>
			/// <para>ERDAS IMAGINE - IMG - .img</para>
			/// </summary>
			[GPValue("ERDAS IMAGINE - IMG - .img")]
			[Description("ERDAS IMAGINE - IMG - .img")]
			ERDAS_IMAGINE___IMG___img,

			/// <summary>
			/// <para>Tagged Image File Format - TIFF - .tif</para>
			/// </summary>
			[GPValue("Tagged Image File Format - TIFF - .tif")]
			[Description("Tagged Image File Format - TIFF - .tif")]
			Tagged_Image_File_Format___TIFF___tif,

			/// <summary>
			/// <para>Graphic Interchange Format - GIF - .gif</para>
			/// </summary>
			[GPValue("Graphic Interchange Format - GIF - .gif")]
			[Description("Graphic Interchange Format - GIF - .gif")]
			Graphic_Interchange_Format___GIF___gif,

			/// <summary>
			/// <para>Joint Photographics Experts Group - JPEG - .jpg</para>
			/// </summary>
			[GPValue("Joint Photographics Experts Group - JPEG - .jpg")]
			[Description("Joint Photographics Experts Group - JPEG - .jpg")]
			Joint_Photographics_Experts_Group___JPEG___jpg,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Joint Photographics Experts Group - JPEG 2000 - .jp2")]
			[Description("Joint Photographics Experts Group - JPEG 2000 - .jp2")]
			Joint_Photographics_Experts_Group___JPEG_2000___jp2,

			/// <summary>
			/// <para>Bitmap - BMP - .bmp</para>
			/// </summary>
			[GPValue("Bitmap - BMP - .bmp")]
			[Description("Bitmap - BMP - .bmp")]
			Bitmap___BMP___bmp,

			/// <summary>
			/// <para>Portable Network Graphics - PNG - .png</para>
			/// </summary>
			[GPValue("Portable Network Graphics - PNG - .png")]
			[Description("Portable Network Graphics - PNG - .png")]
			Portable_Network_Graphics___PNG___png,

		}

#endregion
	}
}
