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
	/// <para>Extract Data</para>
	/// <para>Extracts selected  layers in the specified area of interest to a specific format and spatial reference.   The extracted data is then written to a zip file.</para>
	/// </summary>
	public class ExtractData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="LayersToClip">
		/// <para>Layers to Clip</para>
		/// <para>The layers to be clipped. Layers must be feature or raster layers in the map's table of contents. Layer files do not work for this parameter.</para>
		/// </param>
		/// <param name="AreaOfInterest">
		/// <para>Area of Interest</para>
		/// <para>One or more polygons by which the layers will be clipped.</para>
		/// </param>
		/// <param name="FeatureFormat">
		/// <para>Feature Format</para>
		/// <para>The format in which the output features will be delivered. The string provided should be formatted as follows:</para>
		/// <para>Name or format - Short Name - extension (if any)</para>
		/// <para>The hyphen between the components is required, as well as the spaces around the hyphen.</para>
		/// <para>For example:</para>
		/// <para>File Geodatabase - GDB - .gdb</para>
		/// <para>Shapefile - SHP - .shp</para>
		/// <para>Autodesk AutoCAD - DXF_R2007 - .dxf</para>
		/// <para>Autodesk AutoCAD - DWG_R2007 - .dwg</para>
		/// <para>Bentley Microstation Design (V8) - DGN_V8 - .dgn</para>
		/// <para>Internally, this tool uses the Export to CAD tool to convert data to the .dgn, .dwg, and .dxf CAD formats. The list of short names supported includes DGN_V8, DWG_R14, DWG_R2000, DWG_R2004, DWG_R2005, DWG_R2007, DWG_R2010, DXF_R14, DXF_R2000, DXF_R2004, DXF_R2005, DXF_R2007, and DXF_R2010.</para>
		/// </param>
		/// <param name="RasterFormat">
		/// <para>Raster Format</para>
		/// <para>The format in which the output raster datasets will be delivered. The string provided should be formatted as follows:</para>
		/// <para>Name of format - Short Name - extension (if any)</para>
		/// <para>Any of the following strings will work:</para>
		/// <para>Esri GRID - GRID</para>
		/// <para>File Geodatabase - GDB - .gdb</para>
		/// <para>ERDAS IMAGINE - IMG - .img</para>
		/// <para>Tagged Image File Format - TIFF - .tif</para>
		/// <para>Portable Network Graphics - PNG - .png</para>
		/// <para>Graphic Interchange Format - GIF - .gif</para>
		/// <para>Joint Photographics Experts Group - JPEG - .jpg</para>
		/// <para>Joint Photographics Experts Group - JPEG - .jp2</para>
		/// <para>Bitmap - BMP - .bmp</para>
		/// <para>Some of the above raster formats have limitations and not all data can be converted to the format.</para>
		/// </param>
		/// <param name="SpatialReference">
		/// <para>Spatial Reference</para>
		/// <para>The spatial reference of the output data delivered by the tool.</para>
		/// <para>For standard Esri spatial references, the name you provide here should be the name of the desired coordinate system. This name corresponds to the name of the spatial reference&apos;s projection file. Alternatively, you can use the Well Known ID (WKID) of the coordinate system.</para>
		/// <para>For example:</para>
		/// <para>Sinusoidal (world)</para>
		/// <para>WGS 1984 World Mercator</para>
		/// <para>NAD 1983 HARN StatePlane Oregon North FIPS 3601 (Meters)</para>
		/// <para>WGS 1984 UTM Zone 11N</para>
		/// <para>102003</para>
		/// <para>54001</para>
		/// <para>If you want the output to have the same coordinate system as the input, then use the string &quot;Same As Input&quot;.</para>
		/// <para>For any custom projection, the name specified should be the name of the custom projection file (without extension). The location of the custom projection files should be specified in the Custom Spatial Reference Folder parameter.</para>
		/// <para>Same As Input—Use the coordinate from input</para>
		/// </param>
		/// <param name="OutputZipFile">
		/// <para>Output Zip File</para>
		/// <para>The zip file that will contain the extracted data.</para>
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
		/// <para>Tool Display Name : Extract Data</para>
		/// </summary>
		public override string DisplayName() => "Extract Data";

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
		/// <para>The layers to be clipped. Layers must be feature or raster layers in the map's table of contents. Layer files do not work for this parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object LayersToClip { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>One or more polygons by which the layers will be clipped.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Feature Format</para>
		/// <para>The format in which the output features will be delivered. The string provided should be formatted as follows:</para>
		/// <para>Name or format - Short Name - extension (if any)</para>
		/// <para>The hyphen between the components is required, as well as the spaces around the hyphen.</para>
		/// <para>For example:</para>
		/// <para>File Geodatabase - GDB - .gdb</para>
		/// <para>Shapefile - SHP - .shp</para>
		/// <para>Autodesk AutoCAD - DXF_R2007 - .dxf</para>
		/// <para>Autodesk AutoCAD - DWG_R2007 - .dwg</para>
		/// <para>Bentley Microstation Design (V8) - DGN_V8 - .dgn</para>
		/// <para>Internally, this tool uses the Export to CAD tool to convert data to the .dgn, .dwg, and .dxf CAD formats. The list of short names supported includes DGN_V8, DWG_R14, DWG_R2000, DWG_R2004, DWG_R2005, DWG_R2007, DWG_R2010, DXF_R14, DXF_R2000, DXF_R2004, DXF_R2005, DXF_R2007, and DXF_R2010.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object FeatureFormat { get; set; } = "File Geodatabase - GDB - .gdb";

		/// <summary>
		/// <para>Raster Format</para>
		/// <para>The format in which the output raster datasets will be delivered. The string provided should be formatted as follows:</para>
		/// <para>Name of format - Short Name - extension (if any)</para>
		/// <para>Any of the following strings will work:</para>
		/// <para>Esri GRID - GRID</para>
		/// <para>File Geodatabase - GDB - .gdb</para>
		/// <para>ERDAS IMAGINE - IMG - .img</para>
		/// <para>Tagged Image File Format - TIFF - .tif</para>
		/// <para>Portable Network Graphics - PNG - .png</para>
		/// <para>Graphic Interchange Format - GIF - .gif</para>
		/// <para>Joint Photographics Experts Group - JPEG - .jpg</para>
		/// <para>Joint Photographics Experts Group - JPEG - .jp2</para>
		/// <para>Bitmap - BMP - .bmp</para>
		/// <para>Some of the above raster formats have limitations and not all data can be converted to the format.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object RasterFormat { get; set; } = "ESRI GRID - GRID";

		/// <summary>
		/// <para>Spatial Reference</para>
		/// <para>The spatial reference of the output data delivered by the tool.</para>
		/// <para>For standard Esri spatial references, the name you provide here should be the name of the desired coordinate system. This name corresponds to the name of the spatial reference&apos;s projection file. Alternatively, you can use the Well Known ID (WKID) of the coordinate system.</para>
		/// <para>For example:</para>
		/// <para>Sinusoidal (world)</para>
		/// <para>WGS 1984 World Mercator</para>
		/// <para>NAD 1983 HARN StatePlane Oregon North FIPS 3601 (Meters)</para>
		/// <para>WGS 1984 UTM Zone 11N</para>
		/// <para>102003</para>
		/// <para>54001</para>
		/// <para>If you want the output to have the same coordinate system as the input, then use the string &quot;Same As Input&quot;.</para>
		/// <para>For any custom projection, the name specified should be the name of the custom projection file (without extension). The location of the custom projection files should be specified in the Custom Spatial Reference Folder parameter.</para>
		/// <para>Same As Input—Use the coordinate from input</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object SpatialReference { get; set; } = "Same As Input";

		/// <summary>
		/// <para>Custom Spatial Reference Folder</para>
		/// <para>The location of any custom projection file or files referenced in the Spatial Reference parameter. This is only necessary if the custom projection file is not in the default installation Coordinate System folder.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object CustomSpatialReferenceFolder { get; set; }

		/// <summary>
		/// <para>Output Zip File</para>
		/// <para>The zip file that will contain the extracted data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object OutputZipFile { get; set; }

	}
}
