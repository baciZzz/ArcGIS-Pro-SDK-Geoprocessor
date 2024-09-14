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
	/// <para>Generate Map Server Cache</para>
	/// <para>Generate Map Server Cache</para>
	/// <para>Generates pre-rendered tile cache for the map server.</para>
	/// </summary>
	[Obsolete()]
	public class GenerateMapServerCache : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="ServerName">
		/// <para>Host</para>
		/// </param>
		/// <param name="ObjectName">
		/// <para>Map Server</para>
		/// </param>
		/// <param name="DataFrame">
		/// <para>Data Frame</para>
		/// </param>
		/// <param name="OutFolder">
		/// <para>Service Cache Directory</para>
		/// </param>
		/// <param name="TilingSchemeType">
		/// <para>Tiling Scheme</para>
		/// <para><see cref="TilingSchemeTypeEnum"/></para>
		/// </param>
		/// <param name="ScalesType">
		/// <para>Scales</para>
		/// <para><see cref="ScalesTypeEnum"/></para>
		/// </param>
		/// <param name="NumOfScales">
		/// <para>Number of Scales</para>
		/// </param>
		/// <param name="Dpi">
		/// <para>Dots(Pixels) Per Inch</para>
		/// </param>
		/// <param name="TileWidth">
		/// <para>Tile Width (in pixels)</para>
		/// </param>
		/// <param name="TileHeight">
		/// <para>Tile Height (in pixels)</para>
		/// </param>
		public GenerateMapServerCache(object ServerName, object ObjectName, object DataFrame, object OutFolder, object TilingSchemeType, object ScalesType, object NumOfScales, object Dpi, object TileWidth, object TileHeight)
		{
			this.ServerName = ServerName;
			this.ObjectName = ObjectName;
			this.DataFrame = DataFrame;
			this.OutFolder = OutFolder;
			this.TilingSchemeType = TilingSchemeType;
			this.ScalesType = ScalesType;
			this.NumOfScales = NumOfScales;
			this.Dpi = Dpi;
			this.TileWidth = TileWidth;
			this.TileHeight = TileHeight;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Map Server Cache</para>
		/// </summary>
		public override string DisplayName() => "Generate Map Server Cache";

		/// <summary>
		/// <para>Tool Name : GenerateMapServerCache</para>
		/// </summary>
		public override string ToolName() => "GenerateMapServerCache";

		/// <summary>
		/// <para>Tool Excute Name : server.GenerateMapServerCache</para>
		/// </summary>
		public override string ExcuteName() => "server.GenerateMapServerCache";

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
		public override object[] Parameters() => new object[] { ServerName, ObjectName, DataFrame, OutFolder, TilingSchemeType, ScalesType, NumOfScales, Dpi, TileWidth, TileHeight, MapOrLayers, TilingSchema, TileOrigin, Levels, Layer, ThreadCount, Antialiasing, CacheFormat, TileCompressionQuality, OutServerName, OutObjectName };

		/// <summary>
		/// <para>Host</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ServerName { get; set; }

		/// <summary>
		/// <para>Map Server</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ObjectName { get; set; }

		/// <summary>
		/// <para>Data Frame</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DataFrame { get; set; }

		/// <summary>
		/// <para>Service Cache Directory</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutFolder { get; set; }

		/// <summary>
		/// <para>Tiling Scheme</para>
		/// <para><see cref="TilingSchemeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TilingSchemeType { get; set; } = "NEW";

		/// <summary>
		/// <para>Scales</para>
		/// <para><see cref="ScalesTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ScalesType { get; set; } = "STANDARD";

		/// <summary>
		/// <para>Number of Scales</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumOfScales { get; set; }

		/// <summary>
		/// <para>Dots(Pixels) Per Inch</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object Dpi { get; set; } = "96";

		/// <summary>
		/// <para>Tile Width (in pixels)</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object TileWidth { get; set; } = "512";

		/// <summary>
		/// <para>Tile Height (in pixels)</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object TileHeight { get; set; } = "512";

		/// <summary>
		/// <para>Cache Type</para>
		/// <para><see cref="MapOrLayersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Cache Type(Optional)")]
		public object MapOrLayers { get; set; } = "FUSED";

		/// <summary>
		/// <para>Predefined Tiling Scheme</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object TilingSchema { get; set; }

		/// <summary>
		/// <para>Tiling origin in map units</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPPoint()]
		public object TileOrigin { get; set; } = "0 0";

		/// <summary>
		/// <para>Scales</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object Levels { get; set; }

		/// <summary>
		/// <para>Input Layers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Cache Type(Optional)")]
		public object Layer { get; set; }

		/// <summary>
		/// <para>Number of caching service instances</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object ThreadCount { get; set; }

		/// <summary>
		/// <para>Antialiasing (Smoothes edges of labels and lines for improved display quality)</para>
		/// <para><see cref="AntialiasingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Antialiasing { get; set; } = "false";

		/// <summary>
		/// <para>Cache Tile Format</para>
		/// <para><see cref="CacheFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CacheFormat { get; set; } = "PNG24";

		/// <summary>
		/// <para>Tile Compression Quality</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object TileCompressionQuality { get; set; } = "0";

		/// <summary>
		/// <para>Output Host</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutServerName { get; set; }

		/// <summary>
		/// <para>Output Map Server</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutObjectName { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Tiling Scheme</para>
		/// </summary>
		public enum TilingSchemeTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NEW")]
			[Description("NEW")]
			NEW,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("PREDEFINED")]
			[Description("PREDEFINED")]
			PREDEFINED,

		}

		/// <summary>
		/// <para>Scales</para>
		/// </summary>
		public enum ScalesTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("STANDARD")]
			[Description("STANDARD")]
			STANDARD,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("CUSTOM")]
			[Description("CUSTOM")]
			CUSTOM,

		}

		/// <summary>
		/// <para>Cache Type</para>
		/// </summary>
		public enum MapOrLayersEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("FUSED")]
			[Description("FUSED")]
			FUSED,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("MULTI_LAYER")]
			[Description("MULTI_LAYER")]
			MULTI_LAYER,

		}

		/// <summary>
		/// <para>Antialiasing (Smoothes edges of labels and lines for improved display quality)</para>
		/// </summary>
		public enum AntialiasingEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ANTIALIASING")]
			ANTIALIASING,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Cache Tile Format</para>
		/// </summary>
		public enum CacheFormatEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("PNG8")]
			[Description("PNG8")]
			PNG8,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("PNG24")]
			[Description("PNG24")]
			PNG24,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("PNG32")]
			[Description("PNG32")]
			PNG32,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("JPEG")]
			JPEG,

		}

#endregion
	}
}
