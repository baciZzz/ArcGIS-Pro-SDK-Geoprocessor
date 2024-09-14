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
	/// <para>分块标注转注记</para>
	/// <para>基于面索引图层将地图中的各图层的标注转换为注记。</para>
	/// </summary>
	public class TiledLabelsToAnnotation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputMap">
		/// <para>Input Map</para>
		/// <para>包含要转换为注记的标注的地图。</para>
		/// </param>
		/// <param name="PolygonIndexLayer">
		/// <para>Polygon Index Layer</para>
		/// <para>包含分块要素的面图层。</para>
		/// </param>
		/// <param name="OutGeodatabase">
		/// <para>Output Geodatabase</para>
		/// <para>用来保存输出要素类的工作空间。 此工作空间可以是现有地理数据库或现有要素数据集。</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Output Layer</para>
		/// <para>包含所生成注记的图层组。 可使用保存至图层文件工具将输出图层组写入图层文件中。</para>
		/// </param>
		/// <param name="AnnoSuffix">
		/// <para>Annotation Suffix</para>
		/// <para>为每个新注记要素类添加的后缀。 该后缀将追加到各新注记要素类的源要素类名称之后。 注记的参考比例遵照该后缀。</para>
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
		/// <para>Tool Display Name : 分块标注转注记</para>
		/// </summary>
		public override string DisplayName() => "分块标注转注记";

		/// <summary>
		/// <para>Tool Name : TiledLabelsToAnnotation</para>
		/// </summary>
		public override string ToolName() => "TiledLabelsToAnnotation";

		/// <summary>
		/// <para>Tool Excute Name : cartography.TiledLabelsToAnnotation</para>
		/// </summary>
		public override string ExcuteName() => "cartography.TiledLabelsToAnnotation";

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
		public override string[] ValidEnvironments() => new string[] { "annotationTextStringFieldLength", "referenceScale" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputMap, PolygonIndexLayer, OutGeodatabase, OutLayer, AnnoSuffix, ReferenceScaleValue, ReferenceScaleField, TileIdField, CoordinateSysField, MapRotationField, FeatureLinked, GenerateUnplacedAnnotation, OutWorkspace, WhichLayers, SingleLayer, RequireSymbolId, AutoCreate, UpdateOnShapeChange, MultipleFeatureClasses, MergeLabelClasses };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>包含要转换为注记的标注的地图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InputMap { get; set; }

		/// <summary>
		/// <para>Polygon Index Layer</para>
		/// <para>包含分块要素的面图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object PolygonIndexLayer { get; set; }

		/// <summary>
		/// <para>Output Geodatabase</para>
		/// <para>用来保存输出要素类的工作空间。 此工作空间可以是现有地理数据库或现有要素数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutGeodatabase { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// <para>包含所生成注记的图层组。 可使用保存至图层文件工具将输出图层组写入图层文件中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGroupLayer()]
		public object OutLayer { get; set; } = "GroupAnno";

		/// <summary>
		/// <para>Annotation Suffix</para>
		/// <para>为每个新注记要素类添加的后缀。 该后缀将追加到各新注记要素类的源要素类名称之后。 注记的参考比例遵照该后缀。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object AnnoSuffix { get; set; } = "Anno";

		/// <summary>
		/// <para>Reference Scale Value</para>
		/// <para>将用作注记参考的比例值。 注记中的所有符号及文本的大小都会参照此比例。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ReferenceScaleValue { get; set; }

		/// <summary>
		/// <para>Reference Scale Field</para>
		/// <para>面索引图层中用于确定注记参考比例的字段。 注记中的所有符号及文本的大小都会参照此比例。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ReferenceScaleField { get; set; }

		/// <summary>
		/// <para>Tile ID Field</para>
		/// <para>面索引图层中用于唯一标识分块区域的字段。 这些值将填充到注记要素类属性表中的 TileID 字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "OID")]
		public object TileIdField { get; set; }

		/// <summary>
		/// <para>Coordinate System Field</para>
		/// <para>面索引图层中包含各分块坐标系信息的字段。 考虑到存储坐标系信息时所需的字段长度，包含坐标系字段的面索引图层必须为地理数据库要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object CoordinateSysField { get; set; }

		/// <summary>
		/// <para>Map Rotation Field</para>
		/// <para>面索引图层中包含地图将旋转角度值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object MapRotationField { get; set; }

		/// <summary>
		/// <para>Create feature-linked annotation</para>
		/// <para>仅当具有 ArcGIS Desktop Standard 和 ArcGIS Desktop Advanced 许可时，此参数才可用。</para>
		/// <para>用于指定是否将输出注记要素类关联到其他要素类中的要素。</para>
		/// <para>未选中 - 输出注记要素类将不会关联到其他要素类中的要素。 这是默认设置。</para>
		/// <para>选中 - 输出注记要素类将关联到其他要素类中的要素。</para>
		/// <para><see cref="FeatureLinkedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object FeatureLinked { get; set; } = "false";

		/// <summary>
		/// <para>Convert unplaced labels to unplaced annotation</para>
		/// <para>指定是否将基于未放置标注创建未放置注记。</para>
		/// <para>取消选中 - 仅为当前已标注的要素创建注记。 这是默认设置。</para>
		/// <para>选中 - 未放置的注记将存储到注记要素类中。 这些注记的状态字段将设置为“未放置”。</para>
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
		/// <para>指定是为地图中的所有图层还是为单个图层创建注记。 必须指定单个图层。</para>
		/// <para>地图中的所有图层—标注将转换为整个地图的注记。 这是默认设置。</para>
		/// <para>单个图层—标注将转换为单个图层的注记。 必须指定图层。</para>
		/// <para><see cref="WhichLayersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object WhichLayers { get; set; } = "ALL_LAYERS";

		/// <summary>
		/// <para>Feature Layer</para>
		/// <para>当转换参数设置为单个图层时将转换的图层。 该图层必须位于地图中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple")]
		public object SingleLayer { get; set; }

		/// <summary>
		/// <para>Require symbols to be selected from the symbol table</para>
		/// <para>指定是否可以编辑所有文本符号属性。</para>
		/// <para>未选中 - 可以编辑所有文本符号属性。 这是默认设置。</para>
		/// <para>已选中 - 只能编辑启用注记要素以保持集合中对其关联文本符号的引用的符号属性。</para>
		/// <para><see cref="RequireSymbolIdEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object RequireSymbolId { get; set; } = "false";

		/// <summary>
		/// <para>Create annotation when new features are added</para>
		/// <para>如果已选中创建要素关联注记参数，用于指定在向链接要素类添加新要素时是否创建注记。</para>
		/// <para>选中 - 向关联要素类添加新要素时，将创建关联要素注记。 这是默认设置。</para>
		/// <para>未选中 - 向关联要素类添加新要素时，不会创建关联要素注记。</para>
		/// <para><see cref="AutoCreateEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AutoCreate { get; set; } = "true";

		/// <summary>
		/// <para>Update annotation when feature's shape is modified</para>
		/// <para>如果已选中创建要素关联注记参数，用于指定在更新链接要素的形状时是否更新注记的位置。</para>
		/// <para>已选中 - 修改链接要素的形状时，将更新注记的位置。 这是默认设置。</para>
		/// <para>未选中 - 修改链接要素的形状时，不会更新注记的位置。</para>
		/// <para><see cref="UpdateOnShapeChangeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UpdateOnShapeChange { get; set; } = "true";

		/// <summary>
		/// <para>Convert labels from all layers to a single output feature class</para>
		/// <para>指定标注将转换为单独的注记要素类还是单个注记要素类。 如果转换为单个注记要素类，则注记不能与要素关联。</para>
		/// <para>已选中 - 所有图层中的标注将转换为单个注记要素类。</para>
		/// <para>未选中 - 标注将转换为与其图层对应的单独注记要素类。 这是默认设置。</para>
		/// <para><see cref="MultipleFeatureClassesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object MultipleFeatureClasses { get; set; } = "false";

		/// <summary>
		/// <para>Merge similar label classes</para>
		/// <para>如果已选中将所有图层中的标注转换为单个输出要素类参数，用于指定是否合并类似标注类。</para>
		/// <para>选中 - 创建单个要素类时，将合并具有类似属性的标注类。</para>
		/// <para>未选中 - 将合并具有类似属性的标注类。 这是默认设置。</para>
		/// <para><see cref="MergeLabelClassesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object MergeLabelClasses { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TiledLabelsToAnnotation SetEnviroment(object referenceScale = null)
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FEATURE_LINKED")]
			FEATURE_LINKED,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERATE_UNPLACED_ANNOTATION")]
			GENERATE_UNPLACED_ANNOTATION,

			/// <summary>
			/// <para></para>
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
			/// <para>地图中的所有图层—标注将转换为整个地图的注记。 这是默认设置。</para>
			/// </summary>
			[GPValue("ALL_LAYERS")]
			[Description("地图中的所有图层")]
			All_layers_in_map,

			/// <summary>
			/// <para>单个图层—标注将转换为单个图层的注记。 必须指定图层。</para>
			/// </summary>
			[GPValue("SINGLE_LAYER")]
			[Description("单个图层")]
			Single_layer,

		}

		/// <summary>
		/// <para>Require symbols to be selected from the symbol table</para>
		/// </summary>
		public enum RequireSymbolIdEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REQUIRE_ID")]
			REQUIRE_ID,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("AUTO_CREATE")]
			AUTO_CREATE,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SHAPE_UPDATE")]
			SHAPE_UPDATE,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SINGLE_FEATURE_CLASS")]
			SINGLE_FEATURE_CLASS,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("MERGE_LABEL_CLASS")]
			MERGE_LABEL_CLASS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MERGE_LABEL_CLASS")]
			NO_MERGE_LABEL_CLASS,

		}

#endregion
	}
}
