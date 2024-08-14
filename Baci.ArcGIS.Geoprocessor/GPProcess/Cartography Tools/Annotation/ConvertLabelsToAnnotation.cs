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
	/// <para>Convert Labels To Annotation</para>
	/// <para>Converts labels to annotation for a single layer or the entire map. Both standard annotation and feature-linked annotation can be created.</para>
	/// </summary>
	public class ConvertLabelsToAnnotation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputMap">
		/// <para>Input Map</para>
		/// <para>The input map.</para>
		/// </param>
		/// <param name="ConversionScale">
		/// <para>Conversion Scale</para>
		/// <para>The scale at which labels will be converted. If a reference scale is set on the map, the reference scale will be used for symbol sizing and annotation feature class creation, but conversion will occur at this scale.</para>
		/// </param>
		/// <param name="OutputGeodatabase">
		/// <para>Output Geodatabase</para>
		/// <para>The workspace where the output feature classes will be saved. The workspace can be an existing geodatabase or an existing feature dataset. If this is not the same database used by all the layers in the map, the feature-linked option will be disabled.</para>
		/// </param>
		public ConvertLabelsToAnnotation(object InputMap, object ConversionScale, object OutputGeodatabase)
		{
			this.InputMap = InputMap;
			this.ConversionScale = ConversionScale;
			this.OutputGeodatabase = OutputGeodatabase;
		}

		/// <summary>
		/// <para>Tool Display Name : Convert Labels To Annotation</para>
		/// </summary>
		public override string DisplayName => "Convert Labels To Annotation";

		/// <summary>
		/// <para>Tool Name : ConvertLabelsToAnnotation</para>
		/// </summary>
		public override string ToolName => "ConvertLabelsToAnnotation";

		/// <summary>
		/// <para>Tool Excute Name : cartography.ConvertLabelsToAnnotation</para>
		/// </summary>
		public override string ExcuteName => "cartography.ConvertLabelsToAnnotation";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "annotationTextStringFieldLength", "configKeyword" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputMap, ConversionScale, OutputGeodatabase, AnnoSuffix!, Extent!, GenerateUnplaced!, RequireSymbolId!, FeatureLinked!, AutoCreate!, UpdateOnShapeChange!, OutputGroupLayer!, UpdatedGeodatabase!, WhichLayers!, SingleLayer!, MultipleFeatureClasses!, MergeLabelClasses! };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>The input map.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InputMap { get; set; }

		/// <summary>
		/// <para>Conversion Scale</para>
		/// <para>The scale at which labels will be converted. If a reference scale is set on the map, the reference scale will be used for symbol sizing and annotation feature class creation, but conversion will occur at this scale.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object ConversionScale { get; set; }

		/// <summary>
		/// <para>Output Geodatabase</para>
		/// <para>The workspace where the output feature classes will be saved. The workspace can be an existing geodatabase or an existing feature dataset. If this is not the same database used by all the layers in the map, the feature-linked option will be disabled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPWorkspaceDomain()]
		public object OutputGeodatabase { get; set; }

		/// <summary>
		/// <para>Annotation Suffix</para>
		/// <para>The suffix that will be added to each new annotation feature class. This suffix will be appended to the name of the source feature class for each new annotation feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? AnnoSuffix { get; set; } = "Anno";

		/// <summary>
		/// <para>Extent</para>
		/// <para>Specifies the extent that contains the labels to convert to annotation.</para>
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
		/// <para>Convert unplaced labels to unplaced annotation</para>
		/// <para>Specifies whether unplaced annotation will be created from unplaced labels.</para>
		/// <para>Unchecked—Annotation will only be created for features that are currently labeled. This is the default.</para>
		/// <para>Checked—Unplaced annotation will be stored in the annotation feature class. The status field for these annotation is set to Unplaced.</para>
		/// <para><see cref="GenerateUnplacedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? GenerateUnplaced { get; set; } = "false";

		/// <summary>
		/// <para>Require symbols to be selected from the symbol table</para>
		/// <para>Specifies whether the text symbol properties that can be edited will be restricted.</para>
		/// <para>Unchecked—All text symbol properties can be edited. This is the default.</para>
		/// <para>Checked—Only symbol properties that enable annotation features can be edited to maintain reference to their associated text symbol in the collection.</para>
		/// <para><see cref="RequireSymbolIdEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? RequireSymbolId { get; set; } = "false";

		/// <summary>
		/// <para>Create feature-linked annotation</para>
		/// <para>This parameter is only available with ArcGIS Desktop Standard and ArcGIS Desktop Advanced licenses.</para>
		/// <para>Specifies whether the output annotation feature class will be linked to the features in another feature class.</para>
		/// <para>Unchecked—The output annotation feature class will not be linked to the features in another feature class. This is the default.</para>
		/// <para>Checked—The output annotation feature class will be linked to the features in another feature class.</para>
		/// <para><see cref="FeatureLinkedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? FeatureLinked { get; set; } = "false";

		/// <summary>
		/// <para>Create annotation when new features are added</para>
		/// <para>Specifies whether annotation will be created when new features are added to the linked feature class if the Create feature-linked annotation parameter is checked.</para>
		/// <para>Checked—Feature-linked annotation will be created when new features are added to the linked feature class. This is the default.</para>
		/// <para>Unchecked—Feature-linked annotation will not be created when new features are added to the linked feature class.</para>
		/// <para><see cref="AutoCreateEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AutoCreate { get; set; } = "true";

		/// <summary>
		/// <para>Update annotation when feature's shape is modified</para>
		/// <para>Specifies whether the position of annotation will be updated when the shape of the linked feature is updated if the Create feature-linked annotation parameter is checked.</para>
		/// <para>Checked—The position of the annotation will be updated when the shape of the linked feature is modified. This is the default.</para>
		/// <para>Unchecked—The position of the annotation will not be updated when the shape of the linked feature is modified.</para>
		/// <para><see cref="UpdateOnShapeChangeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? UpdateOnShapeChange { get; set; } = "true";

		/// <summary>
		/// <para>Output Layer</para>
		/// <para>The group layer that will contain the generated annotation. When working in the Catalog pane, you can use the Save To Layer File tool to write the output group layer to a layer file. When using ArcGIS Pro with a map open, the tool adds the group layer to the display if this option is checked in the geoprocessing options. The group layer that is created is temporary and will not persist after the session ends unless the project is saved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPGroupLayer()]
		public object? OutputGroupLayer { get; set; } = "GroupAnno";

		/// <summary>
		/// <para>Updated Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? UpdatedGeodatabase { get; set; }

		/// <summary>
		/// <para>Convert</para>
		/// <para>Specifies whether annotation will be converted for all layers in the map or for a single layer. The single layer must be specified.</para>
		/// <para>All layers in map—Labels will be converted to annotation for all layers in the map. This is the default.</para>
		/// <para>Single layer—Labels will be converted to annotation for a single layer. The layer must be specified.</para>
		/// <para><see cref="WhichLayersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? WhichLayers { get; set; } = "ALL_LAYERS";

		/// <summary>
		/// <para>Feature Layer</para>
		/// <para>The layer with the annotation to convert when the Convert parameter is set to Single layer. This layer must be in the map.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object? SingleLayer { get; set; }

		/// <summary>
		/// <para>Convert labels from all layers to a single output feature class</para>
		/// <para>Specifies whether labels will be converted to individual annotation feature classes or to a single annotation feature class. If converting to a single annotation feature class, the annotation cannot be feature-linked.</para>
		/// <para>Checked—Labels from all layers will be converted to a single annotation feature class.</para>
		/// <para>Unchecked—Labels will be converted to individual annotation feature classes that correspond to their layers. This is the default.</para>
		/// <para><see cref="MultipleFeatureClassesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? MultipleFeatureClasses { get; set; } = "false";

		/// <summary>
		/// <para>Merge similar label classes</para>
		/// <para>Specifies whether similar label classes will be merged when the Convert labels from all layers to a single output feature class parameter is checked.</para>
		/// <para>Checked—Label classes with similar properties will be merged when the Convert labels from all layers to a single output feature class parameter is checked.</para>
		/// <para>Unchecked—Label classes will not be merged when the Convert labels from all layers to a single output feature class parameter is checked. This is the default.</para>
		/// <para><see cref="MergeLabelClassesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? MergeLabelClasses { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConvertLabelsToAnnotation SetEnviroment(int? annotationTextStringFieldLength = null , object? configKeyword = null )
		{
			base.SetEnv(annotationTextStringFieldLength: annotationTextStringFieldLength, configKeyword: configKeyword);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Convert unplaced labels to unplaced annotation</para>
		/// </summary>
		public enum GenerateUnplacedEnum 
		{
			/// <summary>
			/// <para>Checked—Unplaced annotation will be stored in the annotation feature class. The status field for these annotation is set to Unplaced.</para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERATE_UNPLACED")]
			GENERATE_UNPLACED,

			/// <summary>
			/// <para>Unchecked—Annotation will only be created for features that are currently labeled. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ONLY_PLACED")]
			ONLY_PLACED,

		}

		/// <summary>
		/// <para>Require symbols to be selected from the symbol table</para>
		/// </summary>
		public enum RequireSymbolIdEnum 
		{
			/// <summary>
			/// <para>Checked—Only symbol properties that enable annotation features can be edited to maintain reference to their associated text symbol in the collection.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REQUIRE_ID")]
			REQUIRE_ID,

			/// <summary>
			/// <para>Unchecked—All text symbol properties can be edited. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_REQUIRE_ID")]
			NO_REQUIRE_ID,

		}

		/// <summary>
		/// <para>Create feature-linked annotation</para>
		/// </summary>
		public enum FeatureLinkedEnum 
		{
			/// <summary>
			/// <para>Checked—The output annotation feature class will be linked to the features in another feature class.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FEATURE_LINKED")]
			FEATURE_LINKED,

			/// <summary>
			/// <para>Unchecked—The output annotation feature class will not be linked to the features in another feature class. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("STANDARD")]
			STANDARD,

		}

		/// <summary>
		/// <para>Create annotation when new features are added</para>
		/// </summary>
		public enum AutoCreateEnum 
		{
			/// <summary>
			/// <para>Checked—Feature-linked annotation will be created when new features are added to the linked feature class. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("AUTO_CREATE")]
			AUTO_CREATE,

			/// <summary>
			/// <para>Unchecked—Feature-linked annotation will not be created when new features are added to the linked feature class.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_AUTO_CREATE")]
			NO_AUTO_CREATE,

		}

		/// <summary>
		/// <para>Update annotation when feature's shape is modified</para>
		/// </summary>
		public enum UpdateOnShapeChangeEnum 
		{
			/// <summary>
			/// <para>Checked—The position of the annotation will be updated when the shape of the linked feature is modified. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SHAPE_UPDATE")]
			SHAPE_UPDATE,

			/// <summary>
			/// <para>Unchecked—The position of the annotation will not be updated when the shape of the linked feature is modified.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SHAPE_UPDATE")]
			NO_SHAPE_UPDATE,

		}

		/// <summary>
		/// <para>Convert</para>
		/// </summary>
		public enum WhichLayersEnum 
		{
			/// <summary>
			/// <para>All layers in map—Labels will be converted to annotation for all layers in the map. This is the default.</para>
			/// </summary>
			[GPValue("ALL_LAYERS")]
			[Description("All layers in map")]
			All_layers_in_map,

			/// <summary>
			/// <para>Single layer—Labels will be converted to annotation for a single layer. The layer must be specified.</para>
			/// </summary>
			[GPValue("SINGLE_LAYER")]
			[Description("Single layer")]
			Single_layer,

		}

		/// <summary>
		/// <para>Convert labels from all layers to a single output feature class</para>
		/// </summary>
		public enum MultipleFeatureClassesEnum 
		{
			/// <summary>
			/// <para>Checked—Labels from all layers will be converted to a single annotation feature class.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SINGLE_FEATURE_CLASS")]
			SINGLE_FEATURE_CLASS,

			/// <summary>
			/// <para>Unchecked—Labels will be converted to individual annotation feature classes that correspond to their layers. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("FEATURE_CLASS_PER_FEATURE_LAYER")]
			FEATURE_CLASS_PER_FEATURE_LAYER,

		}

		/// <summary>
		/// <para>Merge similar label classes</para>
		/// </summary>
		public enum MergeLabelClassesEnum 
		{
			/// <summary>
			/// <para>Checked—Label classes with similar properties will be merged when the Convert labels from all layers to a single output feature class parameter is checked.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MERGE_LABEL_CLASS")]
			MERGE_LABEL_CLASS,

			/// <summary>
			/// <para>Unchecked—Label classes will not be merged when the Convert labels from all layers to a single output feature class parameter is checked. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MERGE_LABEL_CLASS")]
			NO_MERGE_LABEL_CLASS,

		}

#endregion
	}
}
