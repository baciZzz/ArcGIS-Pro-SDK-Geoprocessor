using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Features From CityEngine Rules</para>
	/// <para>基于 CityEngine 规则转换要素</para>
	/// <para>按照在 ArcGIS CityEngine 中创作的规则基于现有 2D 和 3D 输入要素生成 3D 几何。</para>
	/// </summary>
	public class FeaturesFromCityEngineRules : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>输入点、面或多面体要素。 输入要素可以是按程序符号化的要素图层。 将支持字段映射（属性驱动的符号属性）。</para>
		/// </param>
		/// <param name="InRulePackage">
		/// <para>Rule Package</para>
		/// <para>包含 CGA 规则信息和资源的 CityEngine 规则包文件 (*.rpk)。 对于用于点要素的规则包，应将 .rpk 文件内使用 @StartRule 注释的规则注释为 @InPoint，对于用于面要素的规则包，应注释为 @InPolygon，对于用于多面体要素的规则包，应注释为 @InMesh。 如果 @StartRule 未使用 @InPoint、@InPolygon 或 @InMesh 进行注记，将假设要素类型为面。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Features</para>
		/// <para>包含应用 CGA 规则生成的多面体要素的输出要素类。 可以将 OriginalOID 字段添加到输出要素类，从而包含已生成各个输出要素的输入要素的 ObjectID。</para>
		/// </param>
		public FeaturesFromCityEngineRules(object InFeatures, object InRulePackage, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.InRulePackage = InRulePackage;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 基于 CityEngine 规则转换要素</para>
		/// </summary>
		public override string DisplayName() => "基于 CityEngine 规则转换要素";

		/// <summary>
		/// <para>Tool Name : FeaturesFromCityEngineRules</para>
		/// </summary>
		public override string ToolName() => "FeaturesFromCityEngineRules";

		/// <summary>
		/// <para>Tool Excute Name : 3d.FeaturesFromCityEngineRules</para>
		/// </summary>
		public override string ExcuteName() => "3d.FeaturesFromCityEngineRules";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, InRulePackage, OutFeatureClass, InExistingFields!, InIncludeReports!, InLeafShapes!, OutPoints!, OutLines!, OutMultipoints! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>输入点、面或多面体要素。 输入要素可以是按程序符号化的要素图层。 将支持字段映射（属性驱动的符号属性）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "MultiPatch", "Point")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Rule Package</para>
		/// <para>包含 CGA 规则信息和资源的 CityEngine 规则包文件 (*.rpk)。 对于用于点要素的规则包，应将 .rpk 文件内使用 @StartRule 注释的规则注释为 @InPoint，对于用于面要素的规则包，应注释为 @InPolygon，对于用于多面体要素的规则包，应注释为 @InMesh。 如果 @StartRule 未使用 @InPoint、@InPolygon 或 @InMesh 进行注记，将假设要素类型为面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("rpk")]
		public object InRulePackage { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>包含应用 CGA 规则生成的多面体要素的输出要素类。 可以将 OriginalOID 字段添加到输出要素类，从而包含已生成各个输出要素的输入要素的 ObjectID。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Include Existing Fields</para>
		/// <para>指定输出要素类是否将包含输入要素类的属性字段。</para>
		/// <para>选中 - 输出要素类中将包含输入要素类的属性字段。 这是默认设置。</para>
		/// <para>未选中 - 输出要素类中将不包含输入要素类的属性字段。 如果选中导出 Leaf Shape 参数，将会自动使用此选项。</para>
		/// <para><see cref="InExistingFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? InExistingFields { get; set; } = "true";

		/// <summary>
		/// <para>Include Reports</para>
		/// <para>指定输出是否将包含程序规则包所指定的附加报告字段。 根据创建规则包的方法，报告可能包含创建模型时生成一个或多个报告的逻辑。 这些报告可以包含有关要素的各种信息。 例如，报告为每个建筑模型生成的窗口数的规则包。</para>
		/// <para>选中 - 输出要素类将包含新的属性字段，以按照规则包报告生成逻辑来包含每个要素的已报告值。 为每个报告值创建唯一的属性。</para>
		/// <para>未选中 - 将会忽略在规则包中生成的报告，且将不会生成与这些报告相关的任何新属性。 这是默认设置。</para>
		/// <para>如果规则包不包含生成报告的逻辑，将会忽略此参数。</para>
		/// <para><see cref="InIncludeReportsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? InIncludeReports { get; set; } = "false";

		/// <summary>
		/// <para>Export Leaf Shapes</para>
		/// <para>指定每个输入要素是将转换为单个合并的多面体要素，还是将成为多个要素（可能是点、线或多面体）的集合。</para>
		/// <para>CityEngine 规则包通过生成组件部分并将其合并至单个的 3D 对象来构建内容。 然而，还可以将这些组件或叶形状存储为独立的要素。 此选项在使用 3D 对象子元素（如建筑物的窗户）运行分析操作时特别重要。</para>
		/// <para>例如，某规则可能使用输入面轮廓线生成无缝建筑物模型，或者为每个公寓面（包括朝外的面板、代表中心的点以及显示边界的线）创建单独的要素。 在本示例中，应将公寓面板、中心点和轮廓均视为叶形状。</para>
		/// <para>选中 - 系统将生成其他输出要素类。 输出要素类中将不包括输入要素类的属性字段。 输出要素类将包含名为 OriginalOID 的字段，此字段引用了生成输出的输入要素 ObjectID。</para>
		/// <para>未选中 - 即使在规则逻辑中定义了附加叶形状，也将不会生成附加输出要素类。 几何的所有组成部分均将包含在输出多面体要素中。 这是默认设置。</para>
		/// <para><see cref="InLeafShapesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? InLeafShapes { get; set; } = "false";

		/// <summary>
		/// <para>Output Point Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutPoints { get; set; } = "output_feature_class_Point";

		/// <summary>
		/// <para>Output Line Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutLines { get; set; } = "output_feature_class_Line";

		/// <summary>
		/// <para>Output Multipoint Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutMultipoints { get; set; } = "output_feature_class_MPoint";

		#region InnerClass

		/// <summary>
		/// <para>Include Existing Fields</para>
		/// </summary>
		public enum InExistingFieldsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_EXISTING_FIELDS")]
			INCLUDE_EXISTING_FIELDS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DROP_EXISTING_FIELDS")]
			DROP_EXISTING_FIELDS,

		}

		/// <summary>
		/// <para>Include Reports</para>
		/// </summary>
		public enum InIncludeReportsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_REPORTS")]
			INCLUDE_REPORTS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_REPORTS")]
			EXCLUDE_REPORTS,

		}

		/// <summary>
		/// <para>Export Leaf Shapes</para>
		/// </summary>
		public enum InLeafShapesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FEATURE_PER_LEAF_SHAPE")]
			FEATURE_PER_LEAF_SHAPE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("FEATURE_PER_SHAPE")]
			FEATURE_PER_SHAPE,

		}

#endregion
	}
}
