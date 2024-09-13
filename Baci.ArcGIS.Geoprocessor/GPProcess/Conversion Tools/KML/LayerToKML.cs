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
	/// <para>Layer To KML</para>
	/// <para>图层转 KML</para>
	/// <para>用于将要素或栅格图层转换为 KML 文件，其中包含 Esri 几何和符号系统的转换。 文件采用 ZIP 压缩方式压缩，具有 .kmz 扩展名，并且可以由任何 KML 客户端读取，包括 ArcGIS Earth、ArcGlobe 和 Google Earth。</para>
	/// </summary>
	public class LayerToKML : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Layer">
		/// <para>Layer</para>
		/// <para>要转换为 KML 的要素或栅格图层或者图层文件 (.lyrx)。</para>
		/// </param>
		/// <param name="OutKmzFile">
		/// <para>Output File</para>
		/// <para>输出 KML 文件。 该文件是压缩文件，扩展名为 .kmz。 任何 KML 客户端都可读取该文件，包括 ArcGIS Earth、ArcGlobe 和 Google Earth。</para>
		/// </param>
		public LayerToKML(object Layer, object OutKmzFile)
		{
			this.Layer = Layer;
			this.OutKmzFile = OutKmzFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 图层转 KML</para>
		/// </summary>
		public override string DisplayName() => "图层转 KML";

		/// <summary>
		/// <para>Tool Name : LayerToKML</para>
		/// </summary>
		public override string ToolName() => "LayerToKML";

		/// <summary>
		/// <para>Tool Excute Name : conversion.LayerToKML</para>
		/// </summary>
		public override string ExcuteName() => "conversion.LayerToKML";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "maintainAttachments", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Layer, OutKmzFile, LayerOutputScale!, IsComposite!, BoundaryBoxExtent!, ImageSize!, DpiOfClient!, IgnoreZvalue! };

		/// <summary>
		/// <para>Layer</para>
		/// <para>要转换为 KML 的要素或栅格图层或者图层文件 (.lyrx)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object Layer { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>输出 KML 文件。 该文件是压缩文件，扩展名为 .kmz。 任何 KML 客户端都可读取该文件，包括 ArcGIS Earth、ArcGlobe 和 Google Earth。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("kmz")]
		public object OutKmzFile { get; set; }

		/// <summary>
		/// <para>Layer Output Scale</para>
		/// <para>对于栅格图层，可以将值 0 用来创建一个未平铺输出图像。 如果使用大于或等于 1 的值，则将确定栅格的输出分辨率。 此参数对栅格图层以外的图层无效。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? LayerOutputScale { get; set; } = "0";

		/// <summary>
		/// <para>Return single composite image</para>
		/// <para>指定输出是否将为单个合成图像。 如果图层是栅格，则可以为该参数选择任一选项，这没有任何明显的区别。</para>
		/// <para>选中 – 输出 KML 文件为表示源图层中的栅格或矢量要素的单一合成图像。 栅格以 KML GroundOverlay 形式叠加在地形上方。 使用该选项可减小输出 KMZ 文件的大小。 使用该选项时，KML 中的单个要素和图层将不可选择。</para>
		/// <para>未选中 - 如果图层具有矢量要素，则将以 KML 矢量保留它们。</para>
		/// <para><see cref="IsCompositeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Data Content Properties")]
		public object? IsComposite { get; set; } = "false";

		/// <summary>
		/// <para>Extent to Export</para>
		/// <para>待导出区域的地理范围。 定义范围框（在 WGS84 坐标系中）或选择定义范围的图层或数据集。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>当前显示范围 - 该范围与数据框或可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		[Category("Extent Properties")]
		public object? BoundaryBoxExtent { get; set; }

		/// <summary>
		/// <para>Size of returned image (pixels)</para>
		/// <para>图层输出比例参数值被设置为大于或等于 1 的值时的栅格图层的切片大小。 此参数对栅格图层以外的图层无效。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Output Image Properties")]
		public object? ImageSize { get; set; } = "1024";

		/// <summary>
		/// <para>DPI of output image</para>
		/// <para>选中返回单一合成图像参数时的 KML 输出的设备分辨率。 此参数将与返回图像的大小（像素）参数配合使用以控制输出图像分辨率。</para>
		/// <para>此参数无法重采样源栅格。 任何输入栅格均会创建快照，并将其作为简单 .png 图像包括在 KML 输出中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Output Image Properties")]
		public object? DpiOfClient { get; set; } = "96";

		/// <summary>
		/// <para>Clamped features to ground</para>
		/// <para>指定是否覆盖输入要素的 z 值。</para>
		/// <para>选中 - 要素的 z 值将被覆盖并叠加在地形上方。 此设置适用于不具有 z 值的要素。 这是默认设置。</para>
		/// <para>未选中 - 要素的 z 值将被考虑。 将在 KML 客户端中相对于海平面绘制要素。</para>
		/// <para><see cref="IgnoreZvalueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IgnoreZvalue { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LayerToKML SetEnviroment(object? extent = null , bool? maintainAttachments = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, maintainAttachments: maintainAttachments, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

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
