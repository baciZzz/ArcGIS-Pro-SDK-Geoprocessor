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
	/// <para>Map To KML</para>
	/// <para>Converts a map to a KML file containing geometries and symbology. The output file is compressed using ZIP compression, has a .kmz extension, and can be read by any KML client including ArcGIS Earth and Google Earth.</para>
	/// </summary>
	public class MapToKML : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMap">
		/// <para>Input Map</para>
		/// <para>The map, scene or basemap to convert to KML.</para>
		/// </param>
		/// <param name="OutKmzFile">
		/// <para>Output File</para>
		/// <para>The output KML file. This file is compressed and has a .kmz extension. The file can be read by any KML client including ArcGIS Earth and Google Earth.</para>
		/// </param>
		public MapToKML(object InMap, object OutKmzFile)
		{
			this.InMap = InMap;
			this.OutKmzFile = OutKmzFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Map To KML</para>
		/// </summary>
		public override string DisplayName => "Map To KML";

		/// <summary>
		/// <para>Tool Name : MapToKML</para>
		/// </summary>
		public override string ToolName => "MapToKML";

		/// <summary>
		/// <para>Tool Excute Name : conversion.MapToKML</para>
		/// </summary>
		public override string ExcuteName => "conversion.MapToKML";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InMap, OutKmzFile, MapOutputScale, IsComposite, IsVectorToRaster, ExtentToExport, ImageSize, DpiOfClient, IgnoreZvalue };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>The map, scene or basemap to convert to KML.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InMap { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>The output KML file. This file is compressed and has a .kmz extension. The file can be read by any KML client including ArcGIS Earth and Google Earth.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("kmz")]
		public object OutKmzFile { get; set; }

		/// <summary>
		/// <para>Map Output Scale</para>
		/// <para>The scale at which to export each layer in the map.</para>
		/// <para>This parameter is important with any scale dependency, such as layer visibility or scale-dependent rendering. If the layer is not visible at the output scale, it is not included in the output KML. Any value, such as 1, can be used if there are no scale dependencies.</para>
		/// <para>For raster layers, a value of 0 can be used to create one untiled output image. If a value greater than or equal to 1 is used, it determines the output resolution of the raster. This parameter has no effect on layers that are not raster layers.</para>
		/// <para>Only numeric characters are accepted; for example, enter 20000 as the scale, not 1:20000. In languages that use commas as the decimal point, 20,000 is also acceptable.</para>
		/// <para>If you&apos;re exporting a layer that is to be displayed as 3D vectors and the Return single composite image parameter is checked, you can set this parameter to any value as long as your features do not have any scale-dependent rendering.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MapOutputScale { get; set; } = "0";

		/// <summary>
		/// <para>Return single composite image</para>
		/// <para>Specifies whether the output KML contains a single composite image or separate layers.</para>
		/// <para>Checked—The output KML contains a single image that composites all the features in the map into a single raster image. The raster is draped over the terrain as a KML GroundOverlay. This option reduces the size of the output KML file. When you choose this option, individual features and layers in the KML are not selectable.</para>
		/// <para>Unchecked—The output KML contains separate, individual layers. This is the default. Whether the layers are returned as rasters or as a combination of vectors and rasters is determined by the Convert Vector to Raster parameter.</para>
		/// <para><see cref="IsCompositeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Data Content Properties")]
		public object IsComposite { get; set; } = "false";

		/// <summary>
		/// <para>Convert Vector to Raster</para>
		/// <para>Specifies whether each vector layer in the map is converted to a separate raster image or preserved as vector layers.</para>
		/// <para>This parameter is inactive if the Return single composite image parameter is checked.</para>
		/// <para>Checked—Vector layers are converted to a separate raster image in the KML output. Normal raster layers are also added to the KML output. Each output KML raster layer is selectable, and its transparency can be adjusted in certain KML clients.</para>
		/// <para>Unchecked—Vector layers are preserved as KML vectors. This is the default.</para>
		/// <para><see cref="IsVectorToRasterEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Data Content Properties")]
		public object IsVectorToRaster { get; set; } = "false";

		/// <summary>
		/// <para>Extent to Export</para>
		/// <para>The geographic extent of the area to be exported. Specify the extent rectangle bounds as a space-delimited string of WGS84 geographic coordinates in the form left lower right upper (x-min, y-min, x-max, y-max).</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Current Display Extent—The extent is equal to the data frame or visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		[Category("Extent Properties")]
		public object ExtentToExport { get; set; }

		/// <summary>
		/// <para>Size of returned image (pixels)</para>
		/// <para>The size of the tiles for raster layers if the Map Output Scale parameter value is set to a value greater than or equal to 1. This parameter only has an effect on raster layers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Output Image Properties")]
		public object ImageSize { get; set; } = "1024";

		/// <summary>
		/// <para>DPI of output image</para>
		/// <para>The device resolution for any rasters in the output KML document. Typical screen resolution is 96 dpi. If the data in your map supports a high resolution and your KML requires it, consider increasing the value. Use this parameter with the Size of returned image (pixels) parameter to control output image resolution. The default value is 96.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Output Image Properties")]
		public object DpiOfClient { get; set; } = "96";

		/// <summary>
		/// <para>Clamped features to ground</para>
		/// <para>Specifies whether features are clamped to the ground.</para>
		/// <para>Checked—The z-values of the input features are overridden and KML is created with the features clamped to the ground. The features are draped over the terrain. This option is used for features that do not have z-values. This is the default.</para>
		/// <para>Unchecked—The z-values of the input features are used when creating KML. The features are drawn inside KML clients relative to sea level.</para>
		/// <para><see cref="IgnoreZvalueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IgnoreZvalue { get; set; } = "true";

		#region InnerClass

		/// <summary>
		/// <para>Return single composite image</para>
		/// </summary>
		public enum IsCompositeEnum 
		{
			/// <summary>
			/// <para>Checked—The output KML contains a single image that composites all the features in the map into a single raster image. The raster is draped over the terrain as a KML GroundOverlay. This option reduces the size of the output KML file. When you choose this option, individual features and layers in the KML are not selectable.</para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPOSITE")]
			COMPOSITE,

			/// <summary>
			/// <para>Unchecked—The output KML contains separate, individual layers. This is the default. Whether the layers are returned as rasters or as a combination of vectors and rasters is determined by the Convert Vector to Raster parameter.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_COMPOSITE")]
			NO_COMPOSITE,

		}

		/// <summary>
		/// <para>Convert Vector to Raster</para>
		/// </summary>
		public enum IsVectorToRasterEnum 
		{
			/// <summary>
			/// <para>Checked—Vector layers are converted to a separate raster image in the KML output. Normal raster layers are also added to the KML output. Each output KML raster layer is selectable, and its transparency can be adjusted in certain KML clients.</para>
			/// </summary>
			[GPValue("true")]
			[Description("VECTOR_TO_IMAGE")]
			VECTOR_TO_IMAGE,

			/// <summary>
			/// <para>Unchecked—Vector layers are preserved as KML vectors. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("VECTOR_TO_VECTOR")]
			VECTOR_TO_VECTOR,

		}

		/// <summary>
		/// <para>Clamped features to ground</para>
		/// </summary>
		public enum IgnoreZvalueEnum 
		{
			/// <summary>
			/// <para>Checked—The z-values of the input features are overridden and KML is created with the features clamped to the ground. The features are draped over the terrain. This option is used for features that do not have z-values. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CLAMPED_TO_GROUND")]
			CLAMPED_TO_GROUND,

			/// <summary>
			/// <para>Unchecked—The z-values of the input features are used when creating KML. The features are drawn inside KML clients relative to sea level.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ABSOLUTE")]
			ABSOLUTE,

		}

#endregion
	}
}
