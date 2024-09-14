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
	/// <para>Convert Labels To Graphics</para>
	/// <para>Converts labels to graphics for a single layer or an entire map.</para>
	/// </summary>
	public class ConvertLabelsToGraphics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputMap">
		/// <para>Input Map</para>
		/// <para>The input map name.</para>
		/// </param>
		/// <param name="ConversionScale">
		/// <para>Conversion Scale</para>
		/// <para>The scale at which to convert labels. If a reference scale is set on the map, the reference scale will be used for symbol sizing and graphics layer creation, but conversion will happen at this scale.</para>
		/// </param>
		public ConvertLabelsToGraphics(object InputMap, object ConversionScale)
		{
			this.InputMap = InputMap;
			this.ConversionScale = ConversionScale;
		}

		/// <summary>
		/// <para>Tool Display Name : Convert Labels To Graphics</para>
		/// </summary>
		public override string DisplayName() => "Convert Labels To Graphics";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputMap, ConversionScale, WhichLayers!, SingleLayer!, GraphicsSuffix!, Extent!, MultipleGraphicsLayers!, GenerateUnplaced!, OutputGroupLayer! };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>The input map name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InputMap { get; set; }

		/// <summary>
		/// <para>Conversion Scale</para>
		/// <para>The scale at which to convert labels. If a reference scale is set on the map, the reference scale will be used for symbol sizing and graphics layer creation, but conversion will happen at this scale.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object ConversionScale { get; set; }

		/// <summary>
		/// <para>Convert</para>
		/// <para>Specifies whether to convert graphics for all layers in the map or for a single layer.</para>
		/// <para>All layers in map—Labels will be converted to graphics for all layers in the map. This is the default.</para>
		/// <para>Single layer—Labels will be converted to graphics for a single layer. The layer must be specified in the Feature Layer parameter (single_layer in Python).</para>
		/// <para><see cref="WhichLayersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? WhichLayers { get; set; } = "ALL_LAYERS";

		/// <summary>
		/// <para>Feature Layer</para>
		/// <para>The layer with the labels to convert when the Convert parameter is set to Single layer. This layer must be in the map.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple")]
		public object? SingleLayer { get; set; }

		/// <summary>
		/// <para>Graphics Layer Suffix</para>
		/// <para>The suffix that will be added to each new graphics layer. This suffix will be appended to the name of the source feature class for each new graphics layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? GraphicsSuffix { get; set; } = "Graphics";

		/// <summary>
		/// <para>Extent</para>
		/// <para>Specifies the extent that contains the labels to convert to graphics.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Union of Inputs—The extent will be based on the maximum extent of all inputs.</para>
		/// <para>Intersection of Inputs—The extent will be based on the minimum area common to all inputs.</para>
		/// <para>Current Display Extent—The extent is equal to the visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object? Extent { get; set; }

		/// <summary>
		/// <para>Convert labels from all layers to a single output graphics layer</para>
		/// <para>Specifies whether labels will be converted to individual graphics layers or to a single graphics layer.</para>
		/// <para>Checked—Labels from all layers will be converted to a single graphics layer.</para>
		/// <para>Unchecked—Labels will be converted to individual graphics layers that correspond to their layers. This is the default.</para>
		/// <para><see cref="MultipleGraphicsLayersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? MultipleGraphicsLayers { get; set; } = "false";

		/// <summary>
		/// <para>Convert unplaced labels to graphics</para>
		/// <para>Specifies whether graphics will be created from unplaced labels.</para>
		/// <para>Unchecked—Graphics will only be created for features that are currently labeled. This is the default.</para>
		/// <para>Checked—Unplaced graphics are stored in the graphics layer with their visibility is turned off.</para>
		/// <para><see cref="GenerateUnplacedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? GenerateUnplaced { get; set; } = "false";

		/// <summary>
		/// <para>Output Layer</para>
		/// <para>The group layer that will contain the generated graphics. When working in the Catalog pane, you can use the Save To Layer File tool to write the output group layer to a layer file. When using ArcGIS Pro with a map open, the tool adds the group layer to the display if the Add output dataset to an open map option is checked in the geoprocessing options. The group layer that is created is temporary and will not persist after the session ends unless the project is saved.</para>
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
			/// <para>All layers in map—Labels will be converted to graphics for all layers in the map. This is the default.</para>
			/// </summary>
			[GPValue("ALL_LAYERS")]
			[Description("All layers in map")]
			All_layers_in_map,

			/// <summary>
			/// <para>Single layer—Labels will be converted to graphics for a single layer. The layer must be specified in the Feature Layer parameter (single_layer in Python).</para>
			/// </summary>
			[GPValue("SINGLE_LAYER")]
			[Description("Single layer")]
			Single_layer,

		}

		/// <summary>
		/// <para>Convert labels from all layers to a single output graphics layer</para>
		/// </summary>
		public enum MultipleGraphicsLayersEnum 
		{
			/// <summary>
			/// <para>Checked—Labels from all layers will be converted to a single graphics layer.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SINGLE_GRAPHICS_LAYER")]
			SINGLE_GRAPHICS_LAYER,

			/// <summary>
			/// <para>Unchecked—Labels will be converted to individual graphics layers that correspond to their layers. This is the default.</para>
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
			/// <para>Checked—Unplaced graphics are stored in the graphics layer with their visibility is turned off.</para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERATE_UNPLACED")]
			GENERATE_UNPLACED,

			/// <summary>
			/// <para>Unchecked—Graphics will only be created for features that are currently labeled. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ONLY_PLACED")]
			ONLY_PLACED,

		}

#endregion
	}
}
