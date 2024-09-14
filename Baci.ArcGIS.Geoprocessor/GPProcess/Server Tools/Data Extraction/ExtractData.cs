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
	/// <para>Extract Data</para>
	/// <para>提取数据</para>
	/// <para>将指定感兴趣区域中的所选图层提取为特定的格式和特定的空间参考。然后将提取的数据写入 zip 文件中。</para>
	/// </summary>
	public class ExtractData : AbstractGPProcess
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
		/// </param>
		/// <param name="SpatialReference">
		/// <para>Spatial Reference</para>
		/// <para>工具传送的输出数据的空间参考。</para>
		/// <para>对于标准 ESRI 空间参考，此处所提供的名称应为所需坐标系的名称。此名称与空间参考的投影文件名称相对应。此外，还可以使用坐标系的熟知 ID (WKID)。</para>
		/// <para>例如：</para>
		/// <para>Sinusoidal (world)</para>
		/// <para>WGS 1984 World Mercator</para>
		/// <para>NAD 1983 HARN StatePlane Oregon North FIPS 3601 (Meters)</para>
		/// <para>WGS 1984 UTM Zone 11N</para>
		/// <para>102003</para>
		/// <para>54001</para>
		/// <para>如果希望输出具有与输入相同的坐标系，可使用字符串“与输入相同”。</para>
		/// <para>对于任何自定义投影而言，指定的名称都应为自定义投影文件的名称（无扩展名）。自定义投影文件的位置应在“自定义空间参考文件夹”参数中指定。</para>
		/// <para>与输入相同—使用输入的坐标</para>
		/// </param>
		/// <param name="OutputZipFile">
		/// <para>Output Zip File</para>
		/// <para>包含已提取的数据的 zip 文件。</para>
		/// </param>
		public ExtractData(object LayersToClip, object AreaOfInterest, object FeatureFormat, object RasterFormat, object SpatialReference, object OutputZipFile)
		{
			this.LayersToClip = LayersToClip;
			this.AreaOfInterest = AreaOfInterest;
			this.FeatureFormat = FeatureFormat;
			this.RasterFormat = RasterFormat;
			this.SpatialReference = SpatialReference;
			this.OutputZipFile = OutputZipFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 提取数据</para>
		/// </summary>
		public override string DisplayName() => "提取数据";

		/// <summary>
		/// <para>Tool Name : ExtractData</para>
		/// </summary>
		public override string ToolName() => "ExtractData";

		/// <summary>
		/// <para>Tool Excute Name : server.ExtractData</para>
		/// </summary>
		public override string ExcuteName() => "server.ExtractData";

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
		public override object[] Parameters() => new object[] { LayersToClip, AreaOfInterest, FeatureFormat, RasterFormat, SpatialReference, CustomSpatialReferenceFolder, OutputZipFile };

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
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object RasterFormat { get; set; } = "ESRI GRID - GRID";

		/// <summary>
		/// <para>Spatial Reference</para>
		/// <para>工具传送的输出数据的空间参考。</para>
		/// <para>对于标准 ESRI 空间参考，此处所提供的名称应为所需坐标系的名称。此名称与空间参考的投影文件名称相对应。此外，还可以使用坐标系的熟知 ID (WKID)。</para>
		/// <para>例如：</para>
		/// <para>Sinusoidal (world)</para>
		/// <para>WGS 1984 World Mercator</para>
		/// <para>NAD 1983 HARN StatePlane Oregon North FIPS 3601 (Meters)</para>
		/// <para>WGS 1984 UTM Zone 11N</para>
		/// <para>102003</para>
		/// <para>54001</para>
		/// <para>如果希望输出具有与输入相同的坐标系，可使用字符串“与输入相同”。</para>
		/// <para>对于任何自定义投影而言，指定的名称都应为自定义投影文件的名称（无扩展名）。自定义投影文件的位置应在“自定义空间参考文件夹”参数中指定。</para>
		/// <para>与输入相同—使用输入的坐标</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object SpatialReference { get; set; } = "Same As Input";

		/// <summary>
		/// <para>Custom Spatial Reference Folder</para>
		/// <para>在“空间参考”参数中，引用的任何自定义投影文件的位置。只有在自定义投影文件不在默认的安装坐标系文件夹中时，才必须使用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object CustomSpatialReferenceFolder { get; set; }

		/// <summary>
		/// <para>Output Zip File</para>
		/// <para>包含已提取的数据的 zip 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object OutputZipFile { get; set; }

	}
}
