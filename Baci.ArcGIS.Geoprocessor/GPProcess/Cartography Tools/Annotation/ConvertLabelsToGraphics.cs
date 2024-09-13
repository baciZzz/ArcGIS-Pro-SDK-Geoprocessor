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
	/// <para>Convert Labels To Graphics</para>
	/// <para>标注转图形</para>
	/// <para>将单个图层或整个地图的标注转换为图形。</para>
	/// </summary>
	public class ConvertLabelsToGraphics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputMap">
		/// <para>Input Map</para>
		/// <para>输入地图名称。</para>
		/// </param>
		/// <param name="ConversionScale">
		/// <para>Conversion Scale</para>
		/// <para>转换标注时使用的比例。如果已在地图上设置参考比例，则在调整符号大小和创建图形图层时，将使用该参考比例，但是将以此比例进行转换。</para>
		/// </param>
		public ConvertLabelsToGraphics(object InputMap, object ConversionScale)
		{
			this.InputMap = InputMap;
			this.ConversionScale = ConversionScale;
		}

		/// <summary>
		/// <para>Tool Display Name : 标注转图形</para>
		/// </summary>
		public override string DisplayName() => "标注转图形";

		/// <summary>
		/// <para>Tool Name : ConvertLabelsToGraphics</para>
		/// </summary>
		public override string ToolName() => "ConvertLabelsToGraphics";

		/// <summary>
		/// <para>Tool Excute Name : cartography.ConvertLabelsToGraphics</para>
		/// </summary>
		public override string ExcuteName() => "cartography.ConvertLabelsToGraphics";

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
		public override object[] Parameters() => new object[] { InputMap, ConversionScale, WhichLayers!, SingleLayer!, GraphicsSuffix!, Extent!, MultipleGraphicsLayers!, GenerateUnplaced!, OutputGroupLayer! };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>输入地图名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InputMap { get; set; }

		/// <summary>
		/// <para>Conversion Scale</para>
		/// <para>转换标注时使用的比例。如果已在地图上设置参考比例，则在调整符号大小和创建图形图层时，将使用该参考比例，但是将以此比例进行转换。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object ConversionScale { get; set; }

		/// <summary>
		/// <para>Convert</para>
		/// <para>指定是为地图中的所有图层还是为单个图层转换图形。</para>
		/// <para>地图中的所有图层—将地图中所有图层的标注转换为图形。这是默认设置。</para>
		/// <para>单个图层—标注将转换为单个图层的图形。该图层必须在要素图层参数中指定（Python 中的 single_layer）。</para>
		/// <para><see cref="WhichLayersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? WhichLayers { get; set; } = "ALL_LAYERS";

		/// <summary>
		/// <para>Feature Layer</para>
		/// <para>当转换参数设置为单个图层时包含要转换注记的标注。该图层必须位于地图中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple")]
		public object? SingleLayer { get; set; }

		/// <summary>
		/// <para>Graphics Layer Suffix</para>
		/// <para>为每个新图形图层添加的后缀。该后缀将追加到各新图形图层的源要素类名称之后。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? GraphicsSuffix { get; set; } = "Graphics";

		/// <summary>
		/// <para>Extent</para>
		/// <para>指定包含要转换为图形的标注的范围。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>输入的并集 - 该范围将基于所有输入的最大范围。</para>
		/// <para>输入的交集 - 该范围将基于所有输入共用的最小区域。</para>
		/// <para>当前显示范围 - 该范围与可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object? Extent { get; set; }

		/// <summary>
		/// <para>Convert labels from all layers to a single output graphics layer</para>
		/// <para>指定将标注转换为单独的图形图层还是单个图形图层。</para>
		/// <para>选中 - 所有图层中的标注将转换为单个图形图层。</para>
		/// <para>未选中 - 标注将转换为与其图层对应的单独图形图层。这是默认设置。</para>
		/// <para><see cref="MultipleGraphicsLayersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? MultipleGraphicsLayers { get; set; } = "false";

		/// <summary>
		/// <para>Convert unplaced labels to graphics</para>
		/// <para>指定是否将基于未放置标注创建图形。</para>
		/// <para>未选中 - 仅为当前已标注的要素创建图形。这是默认设置。</para>
		/// <para>选中 - 未放置的图形将在其可见性处于关闭状态的情况下存储在图形图层中。</para>
		/// <para><see cref="GenerateUnplacedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? GenerateUnplaced { get; set; } = "false";

		/// <summary>
		/// <para>Output Layer</para>
		/// <para>包含所生成图形的图层组。在目录窗格中工作时，可使用保存至图层文件工具将输出图层组写入图层文件中。在打开地图的情况下使用 ArcGIS Pro 时，如果在地理处理选项中选中将输出数据集添加至打开的地图选项，则该工具可将图层组添加到显示区域。所创建的图层组是临时性的，如果不保存工程，该图层组将在会话结束后消失。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPGroupLayer()]
		public object? OutputGroupLayer { get; set; } = "GroupGraphics";

		#region InnerClass

		/// <summary>
		/// <para>Convert</para>
		/// </summary>
		public enum WhichLayersEnum 
		{
			/// <summary>
			/// <para>地图中的所有图层—将地图中所有图层的标注转换为图形。这是默认设置。</para>
			/// </summary>
			[GPValue("ALL_LAYERS")]
			[Description("地图中的所有图层")]
			All_layers_in_map,

			/// <summary>
			/// <para>单个图层—标注将转换为单个图层的图形。该图层必须在要素图层参数中指定（Python 中的 single_layer）。</para>
			/// </summary>
			[GPValue("SINGLE_LAYER")]
			[Description("单个图层")]
			Single_layer,

		}

		/// <summary>
		/// <para>Convert labels from all layers to a single output graphics layer</para>
		/// </summary>
		public enum MultipleGraphicsLayersEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SINGLE_GRAPHICS_LAYER")]
			SINGLE_GRAPHICS_LAYER,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("GRAPHICS_LAYER_PER_FEATURE_LAYER")]
			GRAPHICS_LAYER_PER_FEATURE_LAYER,

		}

		/// <summary>
		/// <para>Convert unplaced labels to graphics</para>
		/// </summary>
		public enum GenerateUnplacedEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERATE_UNPLACED")]
			GENERATE_UNPLACED,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ONLY_PLACED")]
			ONLY_PLACED,

		}

#endregion
	}
}
