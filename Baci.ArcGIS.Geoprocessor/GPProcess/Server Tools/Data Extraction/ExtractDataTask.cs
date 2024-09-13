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
	/// <para>将指定感兴趣区域中的所选图层提取为选定的格式和空间参考，然后返回 .zip 文件中的所有数据。</para>
	/// </summary>
	public class ExtractDataTask : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="LayersToClip">
		/// <para>Layers to Clip</para>
		/// <para>要裁剪的图层。图层必须为地图内容列表中的要素或栅格图层。图层文件不适用于该参数。</para>
		/// </param>
		/// <param name="AreaOfInterest">
		/// <para>Area of Interest</para>
		/// <para>裁剪图层所依据的一个或多个面。</para>
		/// </param>
		/// <param name="FeatureFormat">
		/// <para>Feature Format</para>
		/// <para>传送输出要素时使用的格式。所提供的字符串应采用如下格式：</para>
		/// <para>名称或格式 - 名称缩写 - 扩展名（如果存在）</para>
		/// <para>各部分之间需要有连字符，连字符两边需要有空格。</para>
		/// <para>例如：</para>
		/// <para>文件地理数据库 - GDB - .gdb</para>
		/// <para>Shapefile - SHP - .shp</para>
		/// <para>Autodesk AutoCAD - DXF_R2007 - .dxf</para>
		/// <para>Autodesk AutoCAD - DWG_R2007 - .dwg</para>
		/// <para>Bentley Microstation Design (V8) - DGN_V8 - .dgn</para>
		/// <para>在内部，此工具使用要素转 CAD 工具将数据转换为 .dgn、.dwg 和 .dxf 的 CAD 格式。支持的名称缩写列表里包含 DGN_V8、DWG_R14、DWG_R2000、DWG_R2004、DWG_R2005、DWG_R2007、DWG_R2010、DXF_R14、DXF_R2000、DXF_R2004、DXF_R2005、DXF_R2007 和 DXF_R2010。</para>
		/// </param>
		/// <param name="RasterFormat">
		/// <para>Raster Format</para>
		/// <para>传送输出栅格数据集时使用的格式。所提供的字符串应采用如下格式：</para>
		/// <para>格式名称 - 名称缩写 - 扩展名（如果有）。</para>
		/// <para>以下任意字符串都可以使用：</para>
		/// <para>Esri GRID - GRID</para>
		/// <para>文件地理数据库 - GDB - .gdb</para>
		/// <para>ERDAS IMAGINE - IMG - .img</para>
		/// <para>标记图像文件格式 - TIFF - .tif</para>
		/// <para>可移植网络图形 - PNG - .png</para>
		/// <para>图形交换格式 - GIF - .gif</para>
		/// <para>联合图像专家组 - JPEG - .jpg</para>
		/// <para>联合图像专家组 - JPEG - .jp2</para>
		/// <para>位图 - BMP - .bmp</para>
		/// <para>上述的某些栅格格式存在限制，所以并不是所有的数据都可以转换为此格式。</para>
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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { LayersToClip, AreaOfInterest, FeatureFormat, RasterFormat, OutputZipFile };

		/// <summary>
		/// <para>Layers to Clip</para>
		/// <para>要裁剪的图层。图层必须为地图内容列表中的要素或栅格图层。图层文件不适用于该参数。</para>
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
		/// <para>传送输出要素时使用的格式。所提供的字符串应采用如下格式：</para>
		/// <para>名称或格式 - 名称缩写 - 扩展名（如果存在）</para>
		/// <para>各部分之间需要有连字符，连字符两边需要有空格。</para>
		/// <para>例如：</para>
		/// <para>文件地理数据库 - GDB - .gdb</para>
		/// <para>Shapefile - SHP - .shp</para>
		/// <para>Autodesk AutoCAD - DXF_R2007 - .dxf</para>
		/// <para>Autodesk AutoCAD - DWG_R2007 - .dwg</para>
		/// <para>Bentley Microstation Design (V8) - DGN_V8 - .dgn</para>
		/// <para>在内部，此工具使用要素转 CAD 工具将数据转换为 .dgn、.dwg 和 .dxf 的 CAD 格式。支持的名称缩写列表里包含 DGN_V8、DWG_R14、DWG_R2000、DWG_R2004、DWG_R2005、DWG_R2007、DWG_R2010、DXF_R14、DXF_R2000、DXF_R2004、DXF_R2005、DXF_R2007 和 DXF_R2010。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FeatureFormat { get; set; } = "File Geodatabase - GDB - .gdb";

		/// <summary>
		/// <para>Raster Format</para>
		/// <para>传送输出栅格数据集时使用的格式。所提供的字符串应采用如下格式：</para>
		/// <para>格式名称 - 名称缩写 - 扩展名（如果有）。</para>
		/// <para>以下任意字符串都可以使用：</para>
		/// <para>Esri GRID - GRID</para>
		/// <para>文件地理数据库 - GDB - .gdb</para>
		/// <para>ERDAS IMAGINE - IMG - .img</para>
		/// <para>标记图像文件格式 - TIFF - .tif</para>
		/// <para>可移植网络图形 - PNG - .png</para>
		/// <para>图形交换格式 - GIF - .gif</para>
		/// <para>联合图像专家组 - JPEG - .jpg</para>
		/// <para>联合图像专家组 - JPEG - .jp2</para>
		/// <para>位图 - BMP - .bmp</para>
		/// <para>上述的某些栅格格式存在限制，所以并不是所有的数据都可以转换为此格式。</para>
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
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("Tagged Image File Format - TIFF - .tif")]
			[Description("Tagged Image File Format - TIFF - .tif")]
			Tagged_Image_File_Format___TIFF___tif,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Graphic Interchange Format - GIF - .gif")]
			[Description("Graphic Interchange Format - GIF - .gif")]
			Graphic_Interchange_Format___GIF___gif,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("Bitmap - BMP - .bmp")]
			[Description("Bitmap - BMP - .bmp")]
			Bitmap___BMP___bmp,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Portable Network Graphics - PNG - .png")]
			[Description("Portable Network Graphics - PNG - .png")]
			Portable_Network_Graphics___PNG___png,

		}

#endregion
	}
}
