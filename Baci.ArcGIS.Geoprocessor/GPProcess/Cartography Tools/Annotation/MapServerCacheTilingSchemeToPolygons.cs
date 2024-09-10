using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CartographyTools
{
	/// <summary>
	/// <para>Map Server Cache Tiling Scheme To Polygons</para>
	/// <para>Creates a new polygon feature class from an existing tiling scheme.</para>
	/// </summary>
	public class MapServerCacheTilingSchemeToPolygons : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputMap">
		/// <para>Input Map</para>
		/// <para>The current map to be used.</para>
		/// </param>
		/// <param name="TilingScheme">
		/// <para>Tiling Scheme</para>
		/// <para>A predefined tiling scheme .xml file.</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output polygon feature class.</para>
		/// </param>
		/// <param name="UseMapExtent">
		/// <para>Generate polygons that intersect the map extent</para>
		/// <para>Specifies whether polygon features will be created for the entire extent of the tiling scheme or only those tiles that intersect the full extent of the map.</para>
		/// <para>Checked—Polygon features will be created for the full extent of the map. This is the default.</para>
		/// <para>Unchecked—Polygon features will be created for the full extent of the tiling scheme.</para>
		/// <para><see cref="UseMapExtentEnum"/></para>
		/// </param>
		/// <param name="ClipToHorizon">
		/// <para>Clip tiles at the coordinate system horizon</para>
		/// <para>Specifies whether polygons will be constrained to the valid area of use for the geographic or projected coordinate system of the map.</para>
		/// <para>Checked—Polygon features will only be created within the valid area of use for the geographic or projected coordinate system of the map. Tiles that are within the extent of the tiling scheme but outside the extent of the coordinate system horizon will be clipped. This is the default.</para>
		/// <para>Unchecked—Polygon features will be created for the full extent of the tiling scheme. Within each scale level, polygons will be of a uniform size and will not be clipped at the coordinate system horizon. This may create data that is outside the valid area of use for the geographic or projected coordinate system. If a scale within the tiling scheme would generate a tile that is larger than the spatial domain of the feature class, null geometry will be created for that feature.</para>
		/// <para><see cref="ClipToHorizonEnum"/></para>
		/// </param>
		public MapServerCacheTilingSchemeToPolygons(object InputMap, object TilingScheme, object OutputFeatureClass, object UseMapExtent, object ClipToHorizon)
		{
			this.InputMap = InputMap;
			this.TilingScheme = TilingScheme;
			this.OutputFeatureClass = OutputFeatureClass;
			this.UseMapExtent = UseMapExtent;
			this.ClipToHorizon = ClipToHorizon;
		}

		/// <summary>
		/// <para>Tool Display Name : Map Server Cache Tiling Scheme To Polygons</para>
		/// </summary>
		public override string DisplayName() => "Map Server Cache Tiling Scheme To Polygons";

		/// <summary>
		/// <para>Tool Name : MapServerCacheTilingSchemeToPolygons</para>
		/// </summary>
		public override string ToolName() => "MapServerCacheTilingSchemeToPolygons";

		/// <summary>
		/// <para>Tool Excute Name : cartography.MapServerCacheTilingSchemeToPolygons</para>
		/// </summary>
		public override string ExcuteName() => "cartography.MapServerCacheTilingSchemeToPolygons";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise() => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputMap, TilingScheme, OutputFeatureClass, UseMapExtent, ClipToHorizon, Antialiasing, Levels };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>The current map to be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InputMap { get; set; }

		/// <summary>
		/// <para>Tiling Scheme</para>
		/// <para>A predefined tiling scheme .xml file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object TilingScheme { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output polygon feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Generate polygons that intersect the map extent</para>
		/// <para>Specifies whether polygon features will be created for the entire extent of the tiling scheme or only those tiles that intersect the full extent of the map.</para>
		/// <para>Checked—Polygon features will be created for the full extent of the map. This is the default.</para>
		/// <para>Unchecked—Polygon features will be created for the full extent of the tiling scheme.</para>
		/// <para><see cref="UseMapExtentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UseMapExtent { get; set; } = "true";

		/// <summary>
		/// <para>Clip tiles at the coordinate system horizon</para>
		/// <para>Specifies whether polygons will be constrained to the valid area of use for the geographic or projected coordinate system of the map.</para>
		/// <para>Checked—Polygon features will only be created within the valid area of use for the geographic or projected coordinate system of the map. Tiles that are within the extent of the tiling scheme but outside the extent of the coordinate system horizon will be clipped. This is the default.</para>
		/// <para>Unchecked—Polygon features will be created for the full extent of the tiling scheme. Within each scale level, polygons will be of a uniform size and will not be clipped at the coordinate system horizon. This may create data that is outside the valid area of use for the geographic or projected coordinate system. If a scale within the tiling scheme would generate a tile that is larger than the spatial domain of the feature class, null geometry will be created for that feature.</para>
		/// <para><see cref="ClipToHorizonEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ClipToHorizon { get; set; } = "true";

		/// <summary>
		/// <para>Generate polygons that match map service caches with anti-aliasing enabled</para>
		/// <para>Specifies whether polygons that match map service caches with antialiasing enabled will be generated. A map service cache supertile is 2048 x 2048 pixels with antialiasing or 4096 x 4096 pixels without. To see if antialiasing was used in an existing cache, open the tiling scheme file, conf.xml, and see if the &lt;Antialiasing&gt; tag is set to true.</para>
		/// <para>Checked—Polygon tiles will be generated to match the supertile extent of a map service cache with antialiasing enabled.</para>
		/// <para>Unchecked—Polygon tiles will be generated to match the supertile extent of a map service cache without antialiasing enabled. This is the default.</para>
		/// <para><see cref="AntialiasingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Antialiasing { get; set; } = "false";

		/// <summary>
		/// <para>Scales</para>
		/// <para>The scale levels at which polygons will be created. These scale levels automatically populate based on the scale levels in the input tiling scheme. You can create polygons for all or only some of the scale levels that are included in your tiling scheme. To add more scale levels, however, you must modify your tiling scheme file or create a new one, as the Add Value button is not available for this tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Levels { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Generate polygons that intersect the map extent</para>
		/// </summary>
		public enum UseMapExtentEnum 
		{
			/// <summary>
			/// <para>Checked—Polygon features will be created for the full extent of the map. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_MAP_EXTENT")]
			USE_MAP_EXTENT,

			/// <summary>
			/// <para>Unchecked—Polygon features will be created for the full extent of the tiling scheme.</para>
			/// </summary>
			[GPValue("false")]
			[Description("FULL_TILING_SCHEME")]
			FULL_TILING_SCHEME,

		}

		/// <summary>
		/// <para>Clip tiles at the coordinate system horizon</para>
		/// </summary>
		public enum ClipToHorizonEnum 
		{
			/// <summary>
			/// <para>Checked—Polygon features will only be created within the valid area of use for the geographic or projected coordinate system of the map. Tiles that are within the extent of the tiling scheme but outside the extent of the coordinate system horizon will be clipped. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CLIP_TO_HORIZON")]
			CLIP_TO_HORIZON,

			/// <summary>
			/// <para>Unchecked—Polygon features will be created for the full extent of the tiling scheme. Within each scale level, polygons will be of a uniform size and will not be clipped at the coordinate system horizon. This may create data that is outside the valid area of use for the geographic or projected coordinate system. If a scale within the tiling scheme would generate a tile that is larger than the spatial domain of the feature class, null geometry will be created for that feature.</para>
			/// </summary>
			[GPValue("false")]
			[Description("UNIFORM_TILE_SIZE")]
			UNIFORM_TILE_SIZE,

		}

		/// <summary>
		/// <para>Generate polygons that match map service caches with anti-aliasing enabled</para>
		/// </summary>
		public enum AntialiasingEnum 
		{
			/// <summary>
			/// <para>Checked—Polygon tiles will be generated to match the supertile extent of a map service cache with antialiasing enabled.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ANTIALIASING")]
			ANTIALIASING,

			/// <summary>
			/// <para>Unchecked—Polygon tiles will be generated to match the supertile extent of a map service cache without antialiasing enabled. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

#endregion
	}
}
