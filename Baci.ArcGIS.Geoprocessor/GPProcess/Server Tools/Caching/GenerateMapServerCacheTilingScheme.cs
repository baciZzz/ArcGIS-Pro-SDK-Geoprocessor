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
	/// <para>生成地图服务器缓存切片方案</para>
	/// <para>生成用于定义比例级别、切片尺寸以及其他 Web 切片图层属性的自定义切片方案文件。</para>
	/// </summary>
	public class GenerateMapServerCacheTilingScheme : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMap">
		/// <para>Map Document</para>
		/// <para>切片方案中将用到的当前地图或现有 .mxd 文档。</para>
		/// </param>
		/// <param name="TileOrigin">
		/// <para>Tiling origin in map units</para>
		/// <para>切片方案的左上角，采用源数据框的空间参考坐标。</para>
		/// </param>
		/// <param name="OutputTilingScheme">
		/// <para>Output Tiling Scheme</para>
		/// <para>要创建的切片方案文件的路径和文件名。</para>
		/// </param>
		/// <param name="NumOfScales">
		/// <para>Number of Scales</para>
		/// <para>切片方案中的比例级数。</para>
		/// </param>
		/// <param name="Scales">
		/// <para>Scales</para>
		/// <para>要包含在切片方案中的比例级别。不使用分数表示比例级别， 而使用 500 表示比例 1:500，依此类推。</para>
		/// </param>
		/// <param name="DotsPerInch">
		/// <para>Dots(Pixels) Per Inch</para>
		/// <para>专用输出设备的每英寸点数。如果所选择的 DPI 与输出设备的分辨率不匹配，则地图切片将显示错误比例。默认值为 96。</para>
		/// </param>
		/// <param name="TileSize">
		/// <para>Tile Size</para>
		/// <para>缓存切片的宽度和高度（以像素为单位）。默认值为 256 x 256。为在性能和可管理性之间寻求最佳平衡，应避免偏离标准尺寸 256 x 256 或 512 x 512。</para>
		/// <para>128 x 128 像素—128 x 128 像素</para>
		/// <para>256 x 256 像素—256 x 256 像素</para>
		/// <para>512 x 512 像素—512 x 512 像素</para>
		/// <para>1024 x 1024 像素—1024 x 1024 像素</para>
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
		/// <para>Tool Display Name : 生成地图服务器缓存切片方案</para>
		/// </summary>
		public override string DisplayName() => "生成地图服务器缓存切片方案";

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
		/// <para>切片方案中将用到的当前地图或现有 .mxd 文档。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InMap { get; set; }

		/// <summary>
		/// <para>Tiling origin in map units</para>
		/// <para>切片方案的左上角，采用源数据框的空间参考坐标。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPPoint()]
		public object TileOrigin { get; set; } = "0 0";

		/// <summary>
		/// <para>Output Tiling Scheme</para>
		/// <para>要创建的切片方案文件的路径和文件名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml")]
		public object OutputTilingScheme { get; set; }

		/// <summary>
		/// <para>Number of Scales</para>
		/// <para>切片方案中的比例级数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumOfScales { get; set; } = "0";

		/// <summary>
		/// <para>Scales</para>
		/// <para>要包含在切片方案中的比例级别。不使用分数表示比例级别， 而使用 500 表示比例 1:500，依此类推。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		public object Scales { get; set; }

		/// <summary>
		/// <para>Dots(Pixels) Per Inch</para>
		/// <para>专用输出设备的每英寸点数。如果所选择的 DPI 与输出设备的分辨率不匹配，则地图切片将显示错误比例。默认值为 96。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object DotsPerInch { get; set; } = "96";

		/// <summary>
		/// <para>Tile Size</para>
		/// <para>缓存切片的宽度和高度（以像素为单位）。默认值为 256 x 256。为在性能和可管理性之间寻求最佳平衡，应避免偏离标准尺寸 256 x 256 或 512 x 512。</para>
		/// <para>128 x 128 像素—128 x 128 像素</para>
		/// <para>256 x 256 像素—256 x 256 像素</para>
		/// <para>512 x 512 像素—512 x 512 像素</para>
		/// <para>1024 x 1024 像素—1024 x 1024 像素</para>
		/// <para><see cref="TileSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TileSize { get; set; } = "256 x 256";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateMapServerCacheTilingScheme SetEnviroment(object? workspace = null)
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
			/// <para>128 x 128 像素—128 x 128 像素</para>
			/// </summary>
			[GPValue("128 x 128")]
			[Description("128 x 128 像素")]
			_128_by_128_pixels,

			/// <summary>
			/// <para>256 x 256 像素—256 x 256 像素</para>
			/// </summary>
			[GPValue("256 x 256")]
			[Description("256 x 256 像素")]
			_256_by_256_pixels,

			/// <summary>
			/// <para>512 x 512 像素—512 x 512 像素</para>
			/// </summary>
			[GPValue("512 x 512")]
			[Description("512 x 512 像素")]
			_512_by_512_pixels,

			/// <summary>
			/// <para>1024 x 1024 像素—1024 x 1024 像素</para>
			/// </summary>
			[GPValue("1024 x 1024")]
			[Description("1024 x 1024 像素")]
			_1024_by_1024_pixels,

		}

#endregion
	}
}
