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
	/// <para>Tiled Labels To Annotation</para>
	/// <para>Converts labels to annotation for layers in a map based on a polygon index layer.</para>
	/// </summary>
	public class TiledLabelsToAnnotation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputMap">
		/// <para>Input Map</para>
		/// <para>The map that contains the labels to convert to annotation.</para>
		/// </param>
		/// <param name="PolygonIndexLayer">
		/// <para>Polygon Index Layer</para>
		/// <para>The polygon layer that contains tile features.</para>
		/// </param>
		/// <param name="OutGeodatabase">
		/// <para>Output Geodatabase</para>
		/// <para>The workspace where the output feature classes will be saved. The workspace can be an existing geodatabase or an existing feature dataset.</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Output Layer</para>
		/// <para>The group layer that will contain the generated annotation. You can use the Save To Layer File tool to write the output group layer to a layer file.</para>
		/// </param>
		/// <param name="AnnoSuffix">
		/// <para>Annotation Suffix</para>
		/// <para>The suffix that will be added to each new annotation feature class. This suffix will be appended to the name of the source feature class for each new annotation feature class. The reference scale for the annotation will follow this suffix.</para>
		/// </param>
		public TiledLabelsToAnnotation(object InputMap, object PolygonIndexLayer, object OutGeodatabase, object OutLayer, object AnnoSuffix)
		{
			this.InputMap = InputMap;
			this.PolygonIndexLayer = PolygonIndexLayer;
			this.OutGeodatabase = OutGeodatabase;
			this.OutLayer = OutLayer;
			this.AnnoSuffix = AnnoSuffix;
		}

		/// <summary>
		/// <para>Tool Display Name : Tiled Labels To Annotation</para>
		/// </summary>
		public override string DisplayName => "Tiled Labels To Annotation";

		/// <summary>
		/// <para>Tool Name : TiledLabelsToAnnotation</para>
		/// </summary>
		public override string ToolName => "TiledLabelsToAnnotation";

		/// <summary>
		/// <para>Tool Excute Name : cartography.TiledLabelsToAnnotation</para>
		/// </summary>
		public override string ExcuteName => "cartography.TiledLabelsToAnnotation";

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
		public override string[] ValidEnvironments => new string[] { "annotationTextStringFieldLength", "referenceScale" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputMap, PolygonIndexLayer, OutGeodatabase, OutLayer, AnnoSuffix, ReferenceScaleValue, ReferenceScaleField, TileIdField, CoordinateSysField, MapRotationField, FeatureLinked, GenerateUnplacedAnnotation, OutWorkspace, WhichLayers, SingleLayer, RequireSymbolId, AutoCreate, UpdateOnShapeChange, MultipleFeatureClasses, MergeLabelClasses };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>The map that contains the labels to convert to annotation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InputMap { get; set; }

		/// <summary>
		/// <para>Polygon Index Layer</para>
		/// <para>The polygon layer that contains tile features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[GPFeatureClassDomain()]
		public object PolygonIndexLayer { get; set; }

		/// <summary>
		/// <para>Output Geodatabase</para>
		/// <para>The workspace where the output feature classes will be saved. The workspace can be an existing geodatabase or an existing feature dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutGeodatabase { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// <para>The group layer that will contain the generated annotation. You can use the Save To Layer File tool to write the output group layer to a layer file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGroupLayer()]
		public object OutLayer { get; set; } = "GroupAnno";

		/// <summary>
		/// <para>Annotation Suffix</para>
		/// <para>The suffix that will be added to each new annotation feature class. This suffix will be appended to the name of the source feature class for each new annotation feature class. The reference scale for the annotation will follow this suffix.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object AnnoSuffix { get; set; } = "Anno";

		/// <summary>
		/// <para>Reference Scale Value</para>
		/// <para>The scale value that will be used as a reference for the annotation. This is the scale on which all symbol and text sizes in the annotation will be based.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ReferenceScaleValue { get; set; }

		/// <summary>
		/// <para>Reference Scale Field</para>
		/// <para>The field in the polygon index layer that will determine the reference scale of the annotation. This is the scale on which all symbol and text sizes in the annotation will be based.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object ReferenceScaleField { get; set; }

		/// <summary>
		/// <para>Tile ID Field</para>
		/// <para>A field in the polygon index layer that uniquely identifies the tiled area. These values will populate the TileID field in the annotation feature class attribute table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object TileIdField { get; set; }

		/// <summary>
		/// <para>Coordinate System Field</para>
		/// <para>A field in the polygon index layer that contains the coordinate system information for each tile. Due to the length required for a field to store coordinate system information, a polygon index layer that contains a coordinate system field must be a geodatabase feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object CoordinateSysField { get; set; }

		/// <summary>
		/// <para>Map Rotation Field</para>
		/// <para>A field in the polygon index layer that contains the angle by which the map will be rotated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object MapRotationField { get; set; }

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
		public object FeatureLinked { get; set; } = "false";

		/// <summary>
		/// <para>Convert unplaced labels to unplaced annotation</para>
		/// <para>Specifies whether unplaced annotation will be created from unplaced labels.</para>
		/// <para>Unchecked—Annotation will only be created for features that are currently labeled. This is the default.</para>
		/// <para>Checked—Unplaced annotation will be stored in the annotation feature class. The status field for these annotation is set to Unplaced.</para>
		/// <para><see cref="GenerateUnplacedAnnotationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object GenerateUnplacedAnnotation { get; set; } = "false";

		/// <summary>
		/// <para>Output Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Convert</para>
		/// <para>Specifies whether annotation will be created for all layers in the map or for a single layer. The single layer must be specified.</para>
		/// <para>All layers in map—Labels will be converted to annotation for the entire map. This is the default.</para>
		/// <para>Single layer—Labels will be converted to annotation for a single layer. The layer must be specified.</para>
		/// <para><see cref="WhichLayersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object WhichLayers { get; set; } = "ALL_LAYERS";

		/// <summary>
		/// <para>Feature Layer</para>
		/// <para>The layer that will be converted when the Convert parameter is set to Single layer. This layer must be in the map.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object SingleLayer { get; set; }

		/// <summary>
		/// <para>Require symbols to be selected from the symbol table</para>
		/// <para>Specifies whether all text symbol properties can be edited.</para>
		/// <para>Unchecked—All text symbol properties can be edited. This is the default.</para>
		/// <para>Checked—Only symbol properties that enable annotation features to maintain reference to their associated text symbol in the collection can be edited.</para>
		/// <para><see cref="RequireSymbolIdEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object RequireSymbolId { get; set; } = "false";

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
		public object AutoCreate { get; set; } = "true";

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
		public object UpdateOnShapeChange { get; set; } = "true";

		/// <summary>
		/// <para>Convert labels from all layers to a single output feature class</para>
		/// <para>Specifies whether labels will be converted to individual annotation feature classes or a single annotation feature class. If converting to a single annotation feature class, the annotation cannot be feature-linked.</para>
		/// <para>Checked—Labels from all layers will be converted to a single annotation feature class.</para>
		/// <para>Unchecked—Labels will be converted to individual annotation feature classes that correspond to their layers. This is the default.</para>
		/// <para><see cref="MultipleFeatureClassesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object MultipleFeatureClasses { get; set; } = "false";

		/// <summary>
		/// <para>Merge similar label classes</para>
		/// <para>Specifies whether similar label classes will be merged if the Convert labels from all layers to a single output feature class parameter is checked.</para>
		/// <para>Checked—Label classes with similar properties will be merged when creating a single feature class.</para>
		/// <para>Unchecked—Label classes with similar properties will not be merged. This is the default.</para>
		/// <para><see cref="MergeLabelClassesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object MergeLabelClasses { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TiledLabelsToAnnotation SetEnviroment(object referenceScale = null )
		{
			base.SetEnv(referenceScale: referenceScale);
			return this;
		}

		#region InnerClass

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
		/// <para>Convert unplaced labels to unplaced annotation</para>
		/// </summary>
		public enum GenerateUnplacedAnnotationEnum 
		{
			/// <summary>
			/// <para>Checked—Unplaced annotation will be stored in the annotation feature class. The status field for these annotation is set to Unplaced.</para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERATE_UNPLACED_ANNOTATION")]
			GENERATE_UNPLACED_ANNOTATION,

			/// <summary>
			/// <para>Unchecked—Annotation will only be created for features that are currently labeled. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_GENERATE_UNPLACED_ANNOTATION")]
			NOT_GENERATE_UNPLACED_ANNOTATION,

		}

		/// <summary>
		/// <para>Convert</para>
		/// </summary>
		public enum WhichLayersEnum 
		{
			/// <summary>
			/// <para>All layers in map—Labels will be converted to annotation for the entire map. This is the default.</para>
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
		/// <para>Require symbols to be selected from the symbol table</para>
		/// </summary>
		public enum RequireSymbolIdEnum 
		{
			/// <summary>
			/// <para>Checked—Only symbol properties that enable annotation features to maintain reference to their associated text symbol in the collection can be edited.</para>
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
			/// <para>Checked—Label classes with similar properties will be merged when creating a single feature class.</para>
			/// </summary>
			[GPValue("true")]
			[Description("MERGE_LABEL_CLASS")]
			MERGE_LABEL_CLASS,

			/// <summary>
			/// <para>Unchecked—Label classes with similar properties will not be merged. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MERGE_LABEL_CLASS")]
			NO_MERGE_LABEL_CLASS,

		}

#endregion
	}
}
