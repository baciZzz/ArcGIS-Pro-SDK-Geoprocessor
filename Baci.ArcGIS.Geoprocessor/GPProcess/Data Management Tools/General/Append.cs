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
	/// <para>Append</para>
	/// <para>追加</para>
	/// <para>将多个输入数据集追加到现有目标数据集。 输入数据集可以是要素类、表格、shapefile、栅格、注记或尺寸注记要素类。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class Append : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputs">
		/// <para>Input Datasets</para>
		/// <para>所含数据将被追加到目标数据集的输入数据集。 输入数据集可以是点、线、面要素类、表、栅格、注记要素类或尺寸要素类。</para>
		/// <para>可将表和要素类组合起来。 如果将要素类追加到表，则将传递属性，但不会移除要素。 如果将表追加到要素类中，则输入表中的行将具有空几何。</para>
		/// </param>
		/// <param name="Target">
		/// <para>Target Dataset</para>
		/// <para>将追加输入数据集数据的现有数据集。</para>
		/// </param>
		public Append(object Inputs, object Target)
		{
			this.Inputs = Inputs;
			this.Target = Target;
		}

		/// <summary>
		/// <para>Tool Display Name : 追加</para>
		/// </summary>
		public override string DisplayName() => "追加";

		/// <summary>
		/// <para>Tool Name : 追加</para>
		/// </summary>
		public override string ToolName() => "追加";

		/// <summary>
		/// <para>Tool Excute Name : management.Append</para>
		/// </summary>
		public override string ExcuteName() => "management.Append";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "maintainAttachments", "preserveGlobalIds", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputs, Target, SchemaType!, FieldMapping!, Subtype!, Output!, Expression! };

		/// <summary>
		/// <para>Input Datasets</para>
		/// <para>所含数据将被追加到目标数据集的输入数据集。 输入数据集可以是点、线、面要素类、表、栅格、注记要素类或尺寸要素类。</para>
		/// <para>可将表和要素类组合起来。 如果将要素类追加到表，则将传递属性，但不会移除要素。 如果将表追加到要素类中，则输入表中的行将具有空几何。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Inputs { get; set; }

		/// <summary>
		/// <para>Target Dataset</para>
		/// <para>将追加输入数据集数据的现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object Target { get; set; }

		/// <summary>
		/// <para>Field Matching Type</para>
		/// <para>指定输入数据集的方案是否必须与目标数据集的字段相匹配才能追加数据。</para>
		/// <para>输入字段必须与目标字段匹配—输入数据集的字段必须与目标数据集的字段相匹配。 如果字段不匹配，则系统将返回一条错误。</para>
		/// <para>使用字段映射协调字段差异—输入数据集的字段不需要与目标数据集的字段相匹配。 如果输入数据集的任何字段与目标数据集的字段不匹配，将不会被映射到目标数据集，除非在字段映射参数中对映射进行了显式设置。</para>
		/// <para>方案不匹配时跳过并警告—输入数据集的字段必须与目标数据集的字段相匹配。 如果任何输入数据集包含与目标数据集不匹配的字段，则该输入数据集将被忽略，并会出现警告消息。</para>
		/// <para><see cref="SchemaTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SchemaType { get; set; } = "TEST";

		/// <summary>
		/// <para>Field Map</para>
		/// <para>控制如何将输入数据集中的属性字段传输或映射到目标数据集。</para>
		/// <para>仅当将字段匹配类型参数设置为使用字段映射协调字段差异时，才能使用此参数。</para>
		/// <para>由于输入数据集追加到具有预定义字段的现有目标数据集，因此无法在字段映射中添加、删除或更改字段类型。 您可以为每个输出字段设置合并规则。</para>
		/// <para>合并规则用于指定如何将两个或更多个输入字段的值合并或组合为一个输出值。 有多种合并规则可用于确定如何用值填充输出字段。</para>
		/// <para>First - 使用输入字段的第一个值。</para>
		/// <para>Last - 使用输入字段的最后一个值。</para>
		/// <para>Join - 串连（连接）输入字段的值。</para>
		/// <para>Sum - 计算输入字段值的总和。</para>
		/// <para>Mean - 计算输入字段值的平均值。</para>
		/// <para>Median - 计算输入字段值的中值。</para>
		/// <para>Mode - 使用具有最高频率的值。</para>
		/// <para>Min - 使用所有输入字段值中的最小值。</para>
		/// <para>Max - 使用所有输入字段值中的最大值。</para>
		/// <para>Standard deviation - 对所有输入字段值使用标准差分类方法。</para>
		/// <para>Count - 查找计算中所包含的记录数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFieldMapping()]
		public object? FieldMapping { get; set; }

		/// <summary>
		/// <para>Subtype</para>
		/// <para>将分配给追加到目标数据集的所有新数据的子类型描述。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Subtype { get; set; }

		/// <summary>
		/// <para>Updated Target Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? Output { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>用于选择输入数据集记录子集的 SQL 表达式。 如果指定了多个输入数据集，将使用表达式对它们进行评估。 如果没有与输入数据集表达式匹配的记录，将不会向目标追加该数据集的记录。</para>
		/// <para>有关 SQL 语法的详细信息，请参阅在 ArcGIS 中使用的查询表达式的 SQL 参考。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? Expression { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Append SetEnviroment(object? extent = null , bool? maintainAttachments = null , bool? preserveGlobalIds = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, maintainAttachments: maintainAttachments, preserveGlobalIds: preserveGlobalIds, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Field Matching Type</para>
		/// </summary>
		public enum SchemaTypeEnum 
		{
			/// <summary>
			/// <para>输入字段必须与目标字段匹配—输入数据集的字段必须与目标数据集的字段相匹配。 如果字段不匹配，则系统将返回一条错误。</para>
			/// </summary>
			[GPValue("TEST")]
			[Description("输入字段必须与目标字段匹配")]
			Input_fields_must_match_target_fields,

			/// <summary>
			/// <para>使用字段映射协调字段差异—输入数据集的字段不需要与目标数据集的字段相匹配。 如果输入数据集的任何字段与目标数据集的字段不匹配，将不会被映射到目标数据集，除非在字段映射参数中对映射进行了显式设置。</para>
			/// </summary>
			[GPValue("NO_TEST")]
			[Description("使用字段映射协调字段差异")]
			Use_the_field_map_to_reconcile_field_differences,

			/// <summary>
			/// <para>方案不匹配时跳过并警告—输入数据集的字段必须与目标数据集的字段相匹配。 如果任何输入数据集包含与目标数据集不匹配的字段，则该输入数据集将被忽略，并会出现警告消息。</para>
			/// </summary>
			[GPValue("TEST_AND_SKIP")]
			[Description("方案不匹配时跳过并警告")]
			Skip_and_warn_if_schema_does_not_match,

		}

#endregion
	}
}
