using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Create Vector Tile Package</para>
	/// <para>创建矢量切片包</para>
	/// <para>从地图或底图生成矢量切片，并将切片打包为单个 .vtpk 文件。</para>
	/// </summary>
	public class CreateVectorTilePackage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMap">
		/// <para>Input Map</para>
		/// <para>用于生成切片并对其进行打包的地图。 输入地图必须具有元数据描述和标签。</para>
		/// </param>
		/// <param name="OutputFile">
		/// <para>Output File</para>
		/// <para>输出矢量切片包。 该包的文件扩展名为 .vtpk。</para>
		/// </param>
		/// <param name="ServiceType">
		/// <para>Package for ArcGIS Online | Bing Maps | Google Maps</para>
		/// <para>确定是从现有地图服务生成切片方案还是根据 ArcGIS Online、Bing Maps 和 Google Maps 生成地图切片。</para>
		/// <para>选中 - 使用 ArcGIS Online/Bing Maps/Google Maps 的切片方案。 ArcGIS Online/Bing Maps/Google Maps 切片方案可用于将您的缓存切片与这些在线地图服务的切片进行叠加。 加载切片方案时，ArcGIS Pro 以内置选项形式包括此切片方案。 选择此切片方案时，源地图的数据框必须使用 WGS 1984 Web Mercator（辅助球体）投影坐标系。 这是默认设置。</para>
		/// <para>未选中 - 使用一个现有矢量切片服务的切片方案。 仅支持不同等级间的比例逐渐加倍且有 512 × 512 切片尺寸的切片方案。 必须在 tiling_scheme 参数中指定矢量切片服务或切片方案文件。</para>
		/// <para><see cref="ServiceTypeEnum"/></para>
		/// </param>
		/// <param name="MinCachedScale">
		/// <para>Minimum Cached Scale</para>
		/// <para>生成切片的最小比例。 这不必是您的切片方案中的最小比例。 由最小缓存比例确定生成缓存时将使用哪个比例。</para>
		/// </param>
		/// <param name="MaxCachedScale">
		/// <para>Maximum Cached Scale</para>
		/// <para>生成切片的最大比例。 这不必是您的切片方案中的最大比例。 由最大缓存比例确定生成缓存时将使用哪个比例。</para>
		/// </param>
		public CreateVectorTilePackage(object InMap, object OutputFile, object ServiceType, object MinCachedScale, object MaxCachedScale)
		{
			this.InMap = InMap;
			this.OutputFile = OutputFile;
			this.ServiceType = ServiceType;
			this.MinCachedScale = MinCachedScale;
			this.MaxCachedScale = MaxCachedScale;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建矢量切片包</para>
		/// </summary>
		public override string DisplayName() => "创建矢量切片包";

		/// <summary>
		/// <para>Tool Name : CreateVectorTilePackage</para>
		/// </summary>
		public override string ToolName() => "CreateVectorTilePackage";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateVectorTilePackage</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateVectorTilePackage";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMap, OutputFile, ServiceType, TilingScheme!, TileStructure!, MinCachedScale, MaxCachedScale, IndexPolygons!, Summary!, Tags! };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>用于生成切片并对其进行打包的地图。 输入地图必须具有元数据描述和标签。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InMap { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>输出矢量切片包。 该包的文件扩展名为 .vtpk。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("vtpk")]
		public object OutputFile { get; set; }

		/// <summary>
		/// <para>Package for ArcGIS Online | Bing Maps | Google Maps</para>
		/// <para>确定是从现有地图服务生成切片方案还是根据 ArcGIS Online、Bing Maps 和 Google Maps 生成地图切片。</para>
		/// <para>选中 - 使用 ArcGIS Online/Bing Maps/Google Maps 的切片方案。 ArcGIS Online/Bing Maps/Google Maps 切片方案可用于将您的缓存切片与这些在线地图服务的切片进行叠加。 加载切片方案时，ArcGIS Pro 以内置选项形式包括此切片方案。 选择此切片方案时，源地图的数据框必须使用 WGS 1984 Web Mercator（辅助球体）投影坐标系。 这是默认设置。</para>
		/// <para>未选中 - 使用一个现有矢量切片服务的切片方案。 仅支持不同等级间的比例逐渐加倍且有 512 × 512 切片尺寸的切片方案。 必须在 tiling_scheme 参数中指定矢量切片服务或切片方案文件。</para>
		/// <para><see cref="ServiceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ServiceType { get; set; } = "true";

		/// <summary>
		/// <para>Tiling scheme</para>
		/// <para>当未选中适用于 ArcGIS Online、Bing Maps 或 Google Maps 的包参数时，要使用的矢量切片服务或切片方案文件。 切片方案尺寸必须为 512 × 512 并具有 2 倍比率的连续缩放。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? TilingScheme { get; set; }

		/// <summary>
		/// <para>Tiling Format</para>
		/// <para>请指定是使用索引结构对切片生成结构进行优化，还是在所有细节层次上将其优化为所有切片的平面数组。 默认情况下系统会优化索引结构，并生成较小的缓存。</para>
		/// <para>索引—根据优化切片生成和文件大小的要素密度索引生成切片。 这是默认设置。</para>
		/// <para>平整—在不考虑要素密度的情况下，针对各个细节层次生成常规切片。 此缓存要大于使用索引结构生成的缓存。</para>
		/// <para><see cref="TileStructureEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TileStructure { get; set; } = "INDEXED";

		/// <summary>
		/// <para>Minimum Cached Scale</para>
		/// <para>生成切片的最小比例。 这不必是您的切片方案中的最小比例。 由最小缓存比例确定生成缓存时将使用哪个比例。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		[GPCodedValueDomain()]
		public object MinCachedScale { get; set; }

		/// <summary>
		/// <para>Maximum Cached Scale</para>
		/// <para>生成切片的最大比例。 这不必是您的切片方案中的最大比例。 由最大缓存比例确定生成缓存时将使用哪个比例。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		[GPCodedValueDomain()]
		public object MaxCachedScale { get; set; }

		/// <summary>
		/// <para>Index Polygons</para>
		/// <para>依照要素密度指定预生成切片索引，仅在切片格式参数为索引时可用。 使用创建矢量切片索引工具来创建索引面。 如果此参数中未指定索引面，则在处理过程中会生成优化索引面以辅助切片的创建，但这些索引面无法保存或输出。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object? IndexPolygons { get; set; }

		/// <summary>
		/// <para>Summary</para>
		/// <para>将汇总信息添加到输出矢量切片包的属性中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Summary { get; set; }

		/// <summary>
		/// <para>Tags</para>
		/// <para>将标签信息添加到输出矢量切片包的属性中。 多个标签之间使用逗号或分号进行分隔。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Tags { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Package for ArcGIS Online | Bing Maps | Google Maps</para>
		/// </summary>
		public enum ServiceTypeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ONLINE")]
			ONLINE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXISTING")]
			EXISTING,

		}

		/// <summary>
		/// <para>Tiling Format</para>
		/// </summary>
		public enum TileStructureEnum 
		{
			/// <summary>
			/// <para>索引—根据优化切片生成和文件大小的要素密度索引生成切片。 这是默认设置。</para>
			/// </summary>
			[GPValue("INDEXED")]
			[Description("索引")]
			Indexed,

			/// <summary>
			/// <para>平整—在不考虑要素密度的情况下，针对各个细节层次生成常规切片。 此缓存要大于使用索引结构生成的缓存。</para>
			/// </summary>
			[GPValue("FLAT")]
			[Description("平整")]
			Flat,

		}

#endregion
	}
}
