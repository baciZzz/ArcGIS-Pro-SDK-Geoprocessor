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
	/// <para>将标注转换为注记</para>
	/// <para>将单个图层或整个地图的标注转换为注记。 既可以创建标准注记，也可以创建关联要素的注记。</para>
	/// </summary>
	public class ConvertLabelsToAnnotation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputMap">
		/// <para>Input Map</para>
		/// <para>输入地图。</para>
		/// </param>
		/// <param name="ConversionScale">
		/// <para>Conversion Scale</para>
		/// <para>转换标注时使用的比例。 如果已在地图上设置参考比例，则在调整符号大小和创建注记要素类时，将使用该参考比例，但是将以此比例进行转换。</para>
		/// </param>
		/// <param name="OutputGeodatabase">
		/// <para>Output Geodatabase</para>
		/// <para>用来保存输出要素类的工作空间。 此工作空间可以是现有地理数据库或现有要素数据集。 如果此数据库与地图中所有图层使用的数据库不同，则将禁用关联要素选项。</para>
		/// </param>
		public ConvertLabelsToAnnotation(object InputMap, object ConversionScale, object OutputGeodatabase)
		{
			this.InputMap = InputMap;
			this.ConversionScale = ConversionScale;
			this.OutputGeodatabase = OutputGeodatabase;
		}

		/// <summary>
		/// <para>Tool Display Name : 将标注转换为注记</para>
		/// </summary>
		public override string DisplayName() => "将标注转换为注记";

		/// <summary>
		/// <para>Tool Name : ConvertLabelsToAnnotation</para>
		/// </summary>
		public override string ToolName() => "ConvertLabelsToAnnotation";

		/// <summary>
		/// <para>Tool Excute Name : cartography.ConvertLabelsToAnnotation</para>
		/// </summary>
		public override string ExcuteName() => "cartography.ConvertLabelsToAnnotation";

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
		public override string[] ValidEnvironments() => new string[] { "annotationTextStringFieldLength", "configKeyword" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputMap, ConversionScale, OutputGeodatabase, AnnoSuffix, Extent, GenerateUnplaced, RequireSymbolId, FeatureLinked, AutoCreate, UpdateOnShapeChange, OutputGroupLayer, UpdatedGeodatabase, WhichLayers, SingleLayer, MultipleFeatureClasses, MergeLabelClasses };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>输入地图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InputMap { get; set; }

		/// <summary>
		/// <para>Conversion Scale</para>
		/// <para>转换标注时使用的比例。 如果已在地图上设置参考比例，则在调整符号大小和创建注记要素类时，将使用该参考比例，但是将以此比例进行转换。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object ConversionScale { get; set; }

		/// <summary>
		/// <para>Output Geodatabase</para>
		/// <para>用来保存输出要素类的工作空间。 此工作空间可以是现有地理数据库或现有要素数据集。 如果此数据库与地图中所有图层使用的数据库不同，则将禁用关联要素选项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object OutputGeodatabase { get; set; }

		/// <summary>
		/// <para>Annotation Suffix</para>
		/// <para>为每个新注记要素类添加的后缀。 该后缀将追加到各新注记要素类的源要素类名称之后。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object AnnoSuffix { get; set; } = "Anno";

		/// <summary>
		/// <para>Extent</para>
		/// <para>指定包含要转换为注记的标注的范围。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>输入的并集 - 该范围将基于所有输入的最大范围。</para>
		/// <para>输入的交集 - 该范围将基于所有输入共用的最小区域。</para>
		/// <para>当前显示范围 - 该范围与可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object Extent { get; set; }

		/// <summary>
		/// <para>Convert unplaced labels to unplaced annotation</para>
		/// <para>指定是否将基于未放置标注创建未放置注记。</para>
		/// <para>取消选中 - 仅为当前已标注的要素创建注记。 这是默认设置。</para>
		/// <para>选中 - 未放置的注记将存储到注记要素类中。 这些注记的状态字段将设置为“未放置”。</para>
		/// <para><see cref="GenerateUnplacedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object GenerateUnplaced { get; set; } = "false";

		/// <summary>
		/// <para>Require symbols to be selected from the symbol table</para>
		/// <para>指定是否限制可以编辑的文本符号属性。</para>
		/// <para>未选中 - 可以编辑所有文本符号属性。 这是默认设置。</para>
		/// <para>选中 - 只能编辑启用注记要素以保持集合中对其关联文本符号的引用的符号属性。</para>
		/// <para><see cref="RequireSymbolIdEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object RequireSymbolId { get; set; } = "false";

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
		/// <para>Output Layer</para>
		/// <para>包含所生成注记的图层组。 在目录窗格中工作时，可使用保存至图层文件工具将输出图层组写入图层文件中。 在打开地图的情况下使用 ArcGIS Pro 时，如果在地理处理选项中选中此选项，则该工具可将图层组添加到视图区域。 所创建的图层组是临时性的，如果不保存工程，该图层组将在会话结束后消失。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPGroupLayer()]
		public object OutputGroupLayer { get; set; } = "GroupAnno";

		/// <summary>
		/// <para>Updated Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object UpdatedGeodatabase { get; set; }

		/// <summary>
		/// <para>Convert</para>
		/// <para>指定是为地图中的所有图层还是为单个图层转换注记。 必须指定单个图层。</para>
		/// <para>地图中的所有图层—将地图中所有图层的标注转换为注记。 这是默认设置。</para>
		/// <para>单个图层—标注将转换为单个图层的注记。 必须指定图层。</para>
		/// <para><see cref="WhichLayersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object WhichLayers { get; set; } = "ALL_LAYERS";

		/// <summary>
		/// <para>Feature Layer</para>
		/// <para>当转换参数设置为单个图层时包含要转换注记的图层。 该图层必须位于地图中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple")]
		public object SingleLayer { get; set; }

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
		/// <para>指定选中将所有图层中的标注转换为单个输出要素类参数时是否合并类似标注类。</para>
		/// <para>未选中 - 选中将所有图层中的标注转换为单个输出要素类参数时不会合并具有类似属性的标注类。</para>
		/// <para>未选中 - 当选中将所有图层中的标注转换为单个输出要素类参数时，不会合并标注类。 这是默认设置。</para>
		/// <para><see cref="MergeLabelClassesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object MergeLabelClasses { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConvertLabelsToAnnotation SetEnviroment(object configKeyword = null )
		{
			base.SetEnv(configKeyword: configKeyword);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Convert unplaced labels to unplaced annotation</para>
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
		/// <para>Convert</para>
		/// </summary>
		public enum WhichLayersEnum 
		{
			/// <summary>
			/// <para>地图中的所有图层—将地图中所有图层的标注转换为注记。 这是默认设置。</para>
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
