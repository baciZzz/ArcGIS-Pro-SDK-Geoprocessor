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
	/// <para>地图服务器缓存切片方案转换为面</para>
	/// <para>基于现有切片方案创建新面要素类。</para>
	/// </summary>
	public class MapServerCacheTilingSchemeToPolygons : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputMap">
		/// <para>Input Map</para>
		/// <para>要使用的当前地图。</para>
		/// </param>
		/// <param name="TilingScheme">
		/// <para>Tiling Scheme</para>
		/// <para>预定义切片方案 .xml 文件。</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>输出面要素类。</para>
		/// </param>
		/// <param name="UseMapExtent">
		/// <para>Generate polygons that intersect the map extent</para>
		/// <para>指定是要为切片方案的整个范围创建面要素还是仅生成与地图全图范围相交的切片。</para>
		/// <para>选中 - 将为地图的全图范围创建面要素。 这是默认设置。</para>
		/// <para>不选中 - 将为切片方案的全图范围创建面要素。</para>
		/// <para><see cref="UseMapExtentEnum"/></para>
		/// </param>
		/// <param name="ClipToHorizon">
		/// <para>Clip tiles at the coordinate system horizon</para>
		/// <para>指定是否将面限制到地图的地理坐标系或投影坐标系的有效使用区域内。</para>
		/// <para>选中 - 仅在地图的地理坐标系或投影坐标系的有效使用区域内创建面要素。 位于切片方案范围内但位于坐标系视域范围外的切片将被裁剪。 这是默认设置。</para>
		/// <para>不选中 - 将为切片方案的全图范围创建面要素。 在每个比例级别内，面将具有相同的大小，且不会在坐标系视域中被裁剪。 这可能会在地理坐标系或投影坐标系的有效使用区域之外创建数据。 如果使用切片方案中的某一比例将生成大于要素类的空间域的切片，则将为该要素创建空几何。</para>
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
		/// <para>Tool Display Name : 地图服务器缓存切片方案转换为面</para>
		/// </summary>
		public override string DisplayName() => "地图服务器缓存切片方案转换为面";

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
		public override object[] Parameters() => new object[] { InputMap, TilingScheme, OutputFeatureClass, UseMapExtent, ClipToHorizon, Antialiasing!, Levels! };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>要使用的当前地图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InputMap { get; set; }

		/// <summary>
		/// <para>Tiling Scheme</para>
		/// <para>预定义切片方案 .xml 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object TilingScheme { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>输出面要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Generate polygons that intersect the map extent</para>
		/// <para>指定是要为切片方案的整个范围创建面要素还是仅生成与地图全图范围相交的切片。</para>
		/// <para>选中 - 将为地图的全图范围创建面要素。 这是默认设置。</para>
		/// <para>不选中 - 将为切片方案的全图范围创建面要素。</para>
		/// <para><see cref="UseMapExtentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UseMapExtent { get; set; } = "true";

		/// <summary>
		/// <para>Clip tiles at the coordinate system horizon</para>
		/// <para>指定是否将面限制到地图的地理坐标系或投影坐标系的有效使用区域内。</para>
		/// <para>选中 - 仅在地图的地理坐标系或投影坐标系的有效使用区域内创建面要素。 位于切片方案范围内但位于坐标系视域范围外的切片将被裁剪。 这是默认设置。</para>
		/// <para>不选中 - 将为切片方案的全图范围创建面要素。 在每个比例级别内，面将具有相同的大小，且不会在坐标系视域中被裁剪。 这可能会在地理坐标系或投影坐标系的有效使用区域之外创建数据。 如果使用切片方案中的某一比例将生成大于要素类的空间域的切片，则将为该要素创建空几何。</para>
		/// <para><see cref="ClipToHorizonEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ClipToHorizon { get; set; } = "true";

		/// <summary>
		/// <para>Generate polygons that match map service caches with anti-aliasing enabled</para>
		/// <para>指定是否生成与启用了抗锯齿功能的地图服务缓存相匹配的面。 启用抗锯齿功能的地图服务缓存超级切片为 2048 x 2048 像素，而未启用抗锯齿功能的超级切片为 4096 x 4096 像素。 要查看现有缓存中是否启用了抗锯齿功能，请打开切片方案文件 conf.xml 并查看 &lt;Antialiasing&gt; 标记是否已设置为 true。</para>
		/// <para>选中 - 将生成与启用了抗锯齿功能的地图服务缓存的超级切片范围相匹配的面切片。</para>
		/// <para>未选中 - 将生成与未启用抗锯齿功能的地图服务缓存的超级切片范围相匹配的面切片。 这是默认设置。</para>
		/// <para><see cref="AntialiasingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Antialiasing { get; set; } = "false";

		/// <summary>
		/// <para>Scales</para>
		/// <para>创建面时使用的比例级别。 这些比例级别将根据输入切片方案中的比例级别自动进行填充。 可以使用切片方案中所包含的全部或部分比例级别来创建面。 但是，由于此工具的添加值按钮不可用，要添加更多比例级别，必须修改切片方案文件或创建新的切片方案文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Levels { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Generate polygons that intersect the map extent</para>
		/// </summary>
		public enum UseMapExtentEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_MAP_EXTENT")]
			USE_MAP_EXTENT,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CLIP_TO_HORIZON")]
			CLIP_TO_HORIZON,

			/// <summary>
			/// <para></para>
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

#endregion
	}
}
