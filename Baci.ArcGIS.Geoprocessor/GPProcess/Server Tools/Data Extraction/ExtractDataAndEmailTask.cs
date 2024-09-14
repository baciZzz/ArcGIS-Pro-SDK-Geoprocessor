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
	/// <para>Extract Data and Email Task</para>
	/// <para>Extract Data and Email Task</para>
	/// <para>Extracts the data in the specified layers and area of interest to the selected format and spatial reference, zips the data, and emails it to the specified address. This tool can be used to create a Data Extraction geoprocessing service.</para>
	/// </summary>
	public class ExtractDataAndEmailTask : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="LayersToClip">
		/// <para>Layers to Clip</para>
		/// <para>The layers to be clipped. Layers must be feature or raster; layer files are not supported.</para>
		/// </param>
		/// <param name="AreaOfInterest">
		/// <para>Area of Interest</para>
		/// <para>One or more polygons by which the layers will be clipped.</para>
		/// </param>
		/// <param name="FeatureFormat">
		/// <para>Feature Format</para>
		/// <para>Specifies the format of the output features. The format should be specified as follows:</para>
		/// <para>Name or format - Short Name - extension (if any)</para>
		/// <para>The hyphens are required and there must be one space before and after the hyphen.</para>
		/// <para>For example:</para>
		/// <para>File Geodatabase - GDB - .gdb</para>
		/// <para>Shapefile - SHP - .shp</para>
		/// <para>Autodesk AutoCAD - DXF_R2007 - .dxf</para>
		/// <para>Autodesk AutoCAD - DWG_R2007 - .dwg</para>
		/// <para>Bentley Microstation Design (V8) - DGN_V8 - .dgn</para>
		/// <para>The list of short names supported includes DGN_V8, DWG_R14, DWG_R2000, DWG_R2004, DWG_R2005, DWG_R2007, DWG_R2010, DXF_R14, DXF_R2000, DXF_R2004, DXF_R2005, DXF_R2007, and DXF_R2010.</para>
		/// <para><see cref="FeatureFormatEnum"/></para>
		/// </param>
		/// <param name="RasterFormat">
		/// <para>Raster Format</para>
		/// <para>Specifies the format of the output raster datasets. The format should be specified as follows:</para>
		/// <para>Name of format - Short Name - extension (if any)</para>
		/// <para>The hyphens are required and there must be one space before and after the hyphen.</para>
		/// <para>For example:</para>
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
		/// <para><see cref="RasterFormatEnum"/></para>
		/// </param>
		/// <param name="To">
		/// <para>To</para>
		/// <para>The email address of the recipient.</para>
		/// <para>This tool will be able to email to this address if and only if the SMTP server has been configured within this model.</para>
		/// </param>
		public ExtractDataAndEmailTask(object LayersToClip, object AreaOfInterest, object FeatureFormat, object RasterFormat, object To)
		{
			this.LayersToClip = LayersToClip;
			this.AreaOfInterest = AreaOfInterest;
			this.FeatureFormat = FeatureFormat;
			this.RasterFormat = RasterFormat;
			this.To = To;
		}

		/// <summary>
		/// <para>Tool Display Name : Extract Data and Email Task</para>
		/// </summary>
		public override string DisplayName() => "Extract Data and Email Task";

		/// <summary>
		/// <para>Tool Name : ExtractDataAndEmailTask</para>
		/// </summary>
		public override string ToolName() => "ExtractDataAndEmailTask";

		/// <summary>
		/// <para>Tool Excute Name : server.ExtractDataAndEmailTask</para>
		/// </summary>
		public override string ExcuteName() => "server.ExtractDataAndEmailTask";

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
		public override object[] Parameters() => new object[] { LayersToClip, AreaOfInterest, FeatureFormat, RasterFormat, To, Sent! };

		/// <summary>
		/// <para>Layers to Clip</para>
		/// <para>The layers to be clipped. Layers must be feature or raster; layer files are not supported.</para>
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
		/// <para>Specifies the format of the output features. The format should be specified as follows:</para>
		/// <para>Name or format - Short Name - extension (if any)</para>
		/// <para>The hyphens are required and there must be one space before and after the hyphen.</para>
		/// <para>For example:</para>
		/// <para>File Geodatabase - GDB - .gdb</para>
		/// <para>Shapefile - SHP - .shp</para>
		/// <para>Autodesk AutoCAD - DXF_R2007 - .dxf</para>
		/// <para>Autodesk AutoCAD - DWG_R2007 - .dwg</para>
		/// <para>Bentley Microstation Design (V8) - DGN_V8 - .dgn</para>
		/// <para>The list of short names supported includes DGN_V8, DWG_R14, DWG_R2000, DWG_R2004, DWG_R2005, DWG_R2007, DWG_R2010, DXF_R14, DXF_R2000, DXF_R2004, DXF_R2005, DXF_R2007, and DXF_R2010.</para>
		/// <para><see cref="FeatureFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FeatureFormat { get; set; } = "File Geodatabase - GDB - .gdb";

		/// <summary>
		/// <para>Raster Format</para>
		/// <para>Specifies the format of the output raster datasets. The format should be specified as follows:</para>
		/// <para>Name of format - Short Name - extension (if any)</para>
		/// <para>The hyphens are required and there must be one space before and after the hyphen.</para>
		/// <para>For example:</para>
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
		/// <para><see cref="RasterFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RasterFormat { get; set; } = "ESRI GRID - GRID";

		/// <summary>
		/// <para>To</para>
		/// <para>The email address of the recipient.</para>
		/// <para>This tool will be able to email to this address if and only if the SMTP server has been configured within this model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object To { get; set; }

		/// <summary>
		/// <para>Send Email Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? Sent { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Feature Format</para>
		/// </summary>
		public enum FeatureFormatEnum 
		{
			/// <summary>
			/// <para>File Geodatabase - GDB - .gdb</para>
			/// </summary>
			[GPValue("File Geodatabase - GDB - .gdb")]
			[Description("File Geodatabase - GDB - .gdb")]
			File_Geodatabase___GDB___gdb,

			/// <summary>
			/// <para>Shapefile - SHP - .shp</para>
			/// </summary>
			[GPValue("Shapefile - SHP - .shp")]
			[Description("Shapefile - SHP - .shp")]
			Shapefile___SHP___shp,

		}

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
