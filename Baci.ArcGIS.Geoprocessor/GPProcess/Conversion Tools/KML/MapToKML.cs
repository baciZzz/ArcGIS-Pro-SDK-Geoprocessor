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
	/// <para>地图转 KML</para>
	/// <para>将地图转换为包含几何和符号系统的 KML 文件。 输出文件采用 ZIP 压缩方式压缩，具有 .kmz 扩展名，并且可以由任何 KML 客户端读取，包括 ArcGIS Earth 和 Google Earth。</para>
	/// </summary>
	public class MapToKML : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMap">
		/// <para>Input Map</para>
		/// <para>要转换为 KML 的地图、场景或底图。</para>
		/// </param>
		/// <param name="OutKmzFile">
		/// <para>Output File</para>
		/// <para>输出 KML 文件。 该文件是压缩文件，扩展名为 .kmz。 任何 KML 客户端都可读取该文件，包括 ArcGIS Earth 和 Google Earth。</para>
		/// </param>
		public MapToKML(object InMap, object OutKmzFile)
		{
			this.InMap = InMap;
			this.OutKmzFile = OutKmzFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 地图转 KML</para>
		/// </summary>
		public override string DisplayName() => "地图转 KML";

		/// <summary>
		/// <para>Tool Name : MapToKML</para>
		/// </summary>
		public override string ToolName() => "MapToKML";

		/// <summary>
		/// <para>Tool Excute Name : conversion.MapToKML</para>
		/// </summary>
		public override string ExcuteName() => "conversion.MapToKML";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMap, OutKmzFile, MapOutputScale!, IsComposite!, IsVectorToRaster!, ExtentToExport!, ImageSize!, DpiOfClient!, IgnoreZvalue!, Layout! };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>要转换为 KML 的地图、场景或底图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InMap { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>输出 KML 文件。 该文件是压缩文件，扩展名为 .kmz。 任何 KML 客户端都可读取该文件，包括 ArcGIS Earth 和 Google Earth。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("kmz")]
		public object OutKmzFile { get; set; }

		/// <summary>
		/// <para>Map Output Scale</para>
		/// <para>将导出地图中每个图层的比例。</para>
		/// <para>此参数对任何比例可变选项都很重要，例如图层可见性或按比例渲染。 如果图层在输出比例下不可见，则其不会包含在输出 KML 中。 如果没有比例相关选项，则可使用任何值（例如 1）。</para>
		/// <para>对于栅格图层，可以将值 0 用来创建一个未平铺输出图像。 如果使用大于或等于 1 的值，则由该值确定栅格的输出分辨率。 此参数对栅格图层以外的图层无效。</para>
		/// <para>仅接受数字字符；例如，输入 20000 作为比例，而不是 1:20000。 在使用逗号作为小数点的语言中，也可以输入 20,000。</para>
		/// <para>如果要导出将以 3D 矢量形式显示的图层并且选中返回单一合成图像参数，则只要要素不具有任何取决于比例的渲染，您就可以将此参数设置为任何值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MapOutputScale { get; set; } = "0";

		/// <summary>
		/// <para>Return single composite image</para>
		/// <para>指定输出 KML 将包含单个合成图像还是单独的图层。</para>
		/// <para>选中 - 输出 KML 文件将包含将地图中的所有要素合成为单个栅格图像的单个图像。 栅格以 KML GroundOverlay 形式悬在地形上方。 此选项可减小输出 KMZ 的大小。 KML 中的各个要素和图层将不可选择。</para>
		/// <para>未选中 - 输出 KML 将包含单独的单个图层。 这是默认设置。 可通过矢量转栅格参数确定是以栅格的形式还是以矢量和栅格组合的形式返回图层。</para>
		/// <para><see cref="IsCompositeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Data Content Properties")]
		public object? IsComposite { get; set; } = "false";

		/// <summary>
		/// <para>Convert Vector to Raster</para>
		/// <para>指定是将地图中的每个矢量图层转换为单独的栅格图像还是将其保留为矢量图层。</para>
		/// <para>如果选中返回单一合成图像参数，则此参数处于非活动状态。</para>
		/// <para>选中 - 矢量图层将在 KML 输出中转换为单独的栅格图像。 正态栅格图层也将被添加到 KML 输出中。 各输出 KML 栅格图层为可选状态，并且可以在特定 KML 客户端中调整其透明度。</para>
		/// <para>未选中 - 矢量图层将保留为 KML 矢量。 这是默认设置。</para>
		/// <para><see cref="IsVectorToRasterEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Data Content Properties")]
		public object? IsVectorToRaster { get; set; } = "false";

		/// <summary>
		/// <para>Extent to Export</para>
		/// <para>待导出区域的地理范围。 将矩形范围边界指定为按左下右上的形式（x-min、y-min、x-max、y-max）以空格分隔的 WGS84 地理坐标字符串。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>当前显示范围 - 该范围与数据框或可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		[Category("Extent Properties")]
		public object? ExtentToExport { get; set; }

		/// <summary>
		/// <para>Size of returned image (pixels)</para>
		/// <para>地图输出比例参数值设置为大于或等于 1 的值时，栅格图层的切片大小。 此参数仅对栅格图层有效。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Output Image Properties")]
		public object? ImageSize { get; set; } = "1024";

		/// <summary>
		/// <para>DPI of output image</para>
		/// <para>输出 KML 文档中所有栅格的设备分辨率。 典型的屏幕分辨率是 96 dpi。 如果地图内的数据支持高分辨率并且 KML 需要高分辨率，则考虑增加值。 可将该参数与返回图像的大小（像素）参数一起用于控制输出图像分辨率。 默认值为 96。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Output Image Properties")]
		public object? DpiOfClient { get; set; } = "96";

		/// <summary>
		/// <para>Clamped features to ground</para>
		/// <para>指定是否将要素强制固定于地面。</para>
		/// <para>选中 - 将忽略输入要素的 z 值，并将在创建 KML 输出时将要素强制固定于地面。 要素将被叠加到 terrain 上。 当要素不具有 z 值时，将使用此选项。 这是默认设置。</para>
		/// <para>未选中 - 在创建 KML 输出时，将使用输入要素的 z 值。 将在 KML 客户端中相对于海平面绘制要素。</para>
		/// <para><see cref="IgnoreZvalueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IgnoreZvalue { get; set; } = "true";

		/// <summary>
		/// <para>Legend Layout Source</para>
		/// <para>包含将作为屏幕叠加层包含在 KML 输出中的图例元素的布局名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Legend Screen Overlay")]
		public object? Layout { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Return single composite image</para>
		/// </summary>
		public enum IsCompositeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPOSITE")]
			COMPOSITE,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("VECTOR_TO_IMAGE")]
			VECTOR_TO_IMAGE,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CLAMPED_TO_GROUND")]
			CLAMPED_TO_GROUND,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ABSOLUTE")]
			ABSOLUTE,

		}

#endregion
	}
}
