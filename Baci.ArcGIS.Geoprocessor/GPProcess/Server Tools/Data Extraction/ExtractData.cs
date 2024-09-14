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
		public override object[] Parameters() => new object[] { LayersToClip, AreaOfInterest, FeatureFormat, RasterFormat, SpatialReference, CustomSpatialReferenceFolder!, OutputZipFile };

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
		public object? CustomSpatialReferenceFolder { get; set; }

		/// <summary>
		/// <para>Output Zip File</para>
		/// <para>包含已提取的数据的 zip 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object OutputZipFile { get; set; }

	}
}
