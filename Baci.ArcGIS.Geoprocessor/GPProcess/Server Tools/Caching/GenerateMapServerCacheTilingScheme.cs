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
	/// <para>Generate Map Server Cache Tiling Scheme</para>
	/// <para>Generate Map Server Cache Tiling Scheme</para>
	/// <para>Generates a custom tiling scheme file that defines the scale levels, tile dimensions, and other properties for a web tile layer.</para>
	/// </summary>
	public class GenerateMapServerCacheTilingScheme : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMap">
		/// <para>Map Document</para>
		/// <para>The current map or an existing .mxd document to be used for the tiling scheme.</para>
		/// </param>
		/// <param name="TileOrigin">
		/// <para>Tiling origin in map units</para>
		/// <para>The upper left corner of the tiling scheme, in coordinates of the spatial reference of the source data frame.</para>
		/// </param>
		/// <param name="OutputTilingScheme">
		/// <para>Output Tiling Scheme</para>
		/// <para>Path and file name of the tiling scheme file to create.</para>
		/// </param>
		/// <param name="NumOfScales">
		/// <para>Number of Scales</para>
		/// <para>Number of scale levels in the tiling scheme.</para>
		/// </param>
		/// <param name="Scales">
		/// <para>Scales</para>
		/// <para>Scale levels to include in the tiling scheme. These are not represented as fractions. Instead, use 500 to represent a scale of 1:500, and so on.</para>
		/// </param>
		/// <param name="DotsPerInch">
		/// <para>Dots(Pixels) Per Inch</para>
		/// <para>The dots per inch of the intended output device. If a DPI is chosen that does not match the resolution of the output device, the scale of the map tile will appear incorrect. The default value is 96.</para>
		/// </param>
		/// <param name="TileSize">
		/// <para>Tile Size</para>
		/// <para>The width and height of the cache tiles in pixels. The default is 256 by 256. For the best balance between performance and manageability, avoid deviating from standard dimensions of 256 by 256 or 512 by 512.</para>
		/// <para>128 by 128 pixels—128 by 128 pixels</para>
		/// <para>256 by 256 pixels—256 by 256 pixels</para>
		/// <para>512 by 512 pixels—512 by 512 pixels</para>
		/// <para>1024 by 1024 pixels—1024 by 1024 pixels</para>
		/// <para><see cref="TileSizeEnum"/></para>
		/// </param>
		public GenerateMapServerCacheTilingScheme(object InMap, object TileOrigin, object OutputTilingScheme, object NumOfScales, object Scales, object DotsPerInch, object TileSize)
		{
			this.InMap = InMap;
			this.TileOrigin = TileOrigin;
			this.OutputTilingScheme = OutputTilingScheme;
			this.NumOfScales = NumOfScales;
			this.Scales = Scales;
			this.DotsPerInch = DotsPerInch;
			this.TileSize = TileSize;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Map Server Cache Tiling Scheme</para>
		/// </summary>
		public override string DisplayName() => "Generate Map Server Cache Tiling Scheme";

		/// <summary>
		/// <para>Tool Name : GenerateMapServerCacheTilingScheme</para>
		/// </summary>
		public override string ToolName() => "GenerateMapServerCacheTilingScheme";

		/// <summary>
		/// <para>Tool Excute Name : server.GenerateMapServerCacheTilingScheme</para>
		/// </summary>
		public override string ExcuteName() => "server.GenerateMapServerCacheTilingScheme";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMap, TileOrigin, OutputTilingScheme, NumOfScales, Scales, DotsPerInch, TileSize };

		/// <summary>
		/// <para>Map Document</para>
		/// <para>The current map or an existing .mxd document to be used for the tiling scheme.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InMap { get; set; }

		/// <summary>
		/// <para>Tiling origin in map units</para>
		/// <para>The upper left corner of the tiling scheme, in coordinates of the spatial reference of the source data frame.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPPoint()]
		public object TileOrigin { get; set; } = "0 0";

		/// <summary>
		/// <para>Output Tiling Scheme</para>
		/// <para>Path and file name of the tiling scheme file to create.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml")]
		public object OutputTilingScheme { get; set; }

		/// <summary>
		/// <para>Number of Scales</para>
		/// <para>Number of scale levels in the tiling scheme.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumOfScales { get; set; } = "0";

		/// <summary>
		/// <para>Scales</para>
		/// <para>Scale levels to include in the tiling scheme. These are not represented as fractions. Instead, use 500 to represent a scale of 1:500, and so on.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		public object Scales { get; set; }

		/// <summary>
		/// <para>Dots(Pixels) Per Inch</para>
		/// <para>The dots per inch of the intended output device. If a DPI is chosen that does not match the resolution of the output device, the scale of the map tile will appear incorrect. The default value is 96.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object DotsPerInch { get; set; } = "96";

		/// <summary>
		/// <para>Tile Size</para>
		/// <para>The width and height of the cache tiles in pixels. The default is 256 by 256. For the best balance between performance and manageability, avoid deviating from standard dimensions of 256 by 256 or 512 by 512.</para>
		/// <para>128 by 128 pixels—128 by 128 pixels</para>
		/// <para>256 by 256 pixels—256 by 256 pixels</para>
		/// <para>512 by 512 pixels—512 by 512 pixels</para>
		/// <para>1024 by 1024 pixels—1024 by 1024 pixels</para>
		/// <para><see cref="TileSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TileSize { get; set; } = "256 x 256";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateMapServerCacheTilingScheme SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Tile Size</para>
		/// </summary>
		public enum TileSizeEnum 
		{
			/// <summary>
			/// <para>128 by 128 pixels—128 by 128 pixels</para>
			/// </summary>
			[GPValue("128 x 128")]
			[Description("128 by 128 pixels")]
			_128_by_128_pixels,

			/// <summary>
			/// <para>256 by 256 pixels—256 by 256 pixels</para>
			/// </summary>
			[GPValue("256 x 256")]
			[Description("256 by 256 pixels")]
			_256_by_256_pixels,

			/// <summary>
			/// <para>512 by 512 pixels—512 by 512 pixels</para>
			/// </summary>
			[GPValue("512 x 512")]
			[Description("512 by 512 pixels")]
			_512_by_512_pixels,

			/// <summary>
			/// <para>1024 by 1024 pixels—1024 by 1024 pixels</para>
			/// </summary>
			[GPValue("1024 x 1024")]
			[Description("1024 by 1024 pixels")]
			_1024_by_1024_pixels,

		}

#endregion
	}
}
