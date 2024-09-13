using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ModelTools
{
	/// <summary>
	/// <para>If Spatial Relationship Is</para>
	/// <para>如果空间关系为</para>
	/// <para>用于评估输入是否有指定的空间关系。</para>
	/// </summary>
	public class SpatialRelationshipIfThenElse : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要进行评估的输入要素。</para>
		/// </param>
		/// <param name="SelectionCondition">
		/// <para>Selection Condition</para>
		/// <para>指定将使用的介于输入和选择要素间的空间关系选择条件。</para>
		/// <para>Exists—检查空间关系是否存在于输入中的任意要素与选择要素之间。 这是默认设置。</para>
		/// <para>无选择内容—检查空间关系是否不存在于任意输入与选择要素之间。</para>
		/// <para>全部选中—检查空间关系是否存在于输入要素的所有要素中。</para>
		/// <para>等于—检查具有空间关系的输入要素的数量是否等于计数值。</para>
		/// <para>介于—检查具有空间关系的输入要素的数量是否介于最小计数值与最大计数值之间。</para>
		/// <para>小于—检查具有空间关系的输入要素的数量是否小于计数值。</para>
		/// <para>大于—检查与 SQL 表达式匹配的记录，其字段值是否大于计数值。</para>
		/// <para>不等于—检查具有空间关系的输入要素的数量是否不等于计数值。</para>
		/// <para><see cref="SelectionConditionEnum"/></para>
		/// </param>
		public SpatialRelationshipIfThenElse(object InFeatures, object SelectionCondition)
		{
			this.InFeatures = InFeatures;
			this.SelectionCondition = SelectionCondition;
		}

		/// <summary>
		/// <para>Tool Display Name : 如果空间关系为</para>
		/// </summary>
		public override string DisplayName() => "如果空间关系为";

		/// <summary>
		/// <para>Tool Name : SpatialRelationshipIfThenElse</para>
		/// </summary>
		public override string ToolName() => "SpatialRelationshipIfThenElse";

		/// <summary>
		/// <para>Tool Excute Name : mb.SpatialRelationshipIfThenElse</para>
		/// </summary>
		public override string ExcuteName() => "mb.SpatialRelationshipIfThenElse";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise() => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OverlapType!, SelectFeatures!, SearchDistance!, InvertSpatialRelationship!, SelectionCondition, Count!, CountMin!, CountMax!, True!, False! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要进行评估的输入要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Relationship</para>
		/// <para>指定要评估的空间关系。</para>
		/// <para>相交—如果输入图层中的要素与某一选择要素相交，则会选择这些要素。 这是默认设置。</para>
		/// <para>3D 相交—如果输入要素中的要素与三维空间（x、y 和 z）中的某一选择要素相交，则将选择这些要素。</para>
		/// <para>在某一距离范围内—如果输入图层中的要素在某一选择要素的指定距离内（使用欧氏距离），则将选择这些要素。 使用搜索距离参数指定距离。</para>
		/// <para>在某一 3D 距离范围内—如果输入图层中的要素在三维空间中的某一选择要素的指定距离内，则会选择这些要素。 使用搜索距离参数指定距离。</para>
		/// <para>在某一测地线距离范围内—如果输入图层中的要素在某一选择要素的指定距离内，则会选择这些要素。 将使用测地线公式计算要素间的距离，这种方法考虑到椭球体的曲率，并可以正确处理跨越日期变更线和两极及其附近的数据。 使用搜索距离参数指定距离。</para>
		/// <para>包含—如果输入图层中的要素包含选择要素，则将选择这些要素。</para>
		/// <para>完全包含—如果输入图层中的要素完全包含选择要素，则将选择这些要素。</para>
		/// <para>Clementini 包含—该空间关系产生的结果同完全包含，但有一种情况例外：如果选择要素完全位于输入要素的边界上（没有任何一部分完全位于里面或外面），则不会选择要素。Clementini 将边界面定义为用来分隔内部和外部的线，将线的边界定义为其端点，点的边界始终为空。</para>
		/// <para>位于—如果输入图层中的要素在选择要素中，则将选择这些要素。</para>
		/// <para>完全在其他要素范围内—如果输入图层中的要素完全在选择要素之内或由选择要素包含，则将选择这些要素。</para>
		/// <para>Clementini 位于—结果同位于，但下述情况例外：如果输入图层中的要素完全位于选择图层中要素的边界上，则不会选择该要素。Clementini 将边界面定义为用来分隔内部和外部的线，将线的边界定义为其端点，点的边界始终为空。</para>
		/// <para>与其他要素相同—如果输入图层中的要素与选择要素相同（在几何中），则将选择这些要素。</para>
		/// <para>边界接触—如果输入图层中要素的边界与某一选择要素接触，则会选择这些要素。 如果输入要素为线或面，则输入要素的边界只能接触选择要素的边界，且输入要素的任何部分均不可跨越选择要素的边界。</para>
		/// <para>与其他要素共线—如果输入图层中的要素与某一选择要素共线，则会选择这些要素。 输入要素和选择要素必须是线或面。</para>
		/// <para>与轮廓交叉—如果输入图层中的要素与某一选择要素的轮廓交叉，则会选择这些要素。 输入和选择要素必须是线或面。 如果将面用于输入或选择图层，则会使用面的边界（线）。 将选择在某一点交叉的线，而不会选择共线的线。</para>
		/// <para>中心在要素范围内—如果输入图层中要素的中心落在某一选择要素内，则会选择这些要素。 要素中心的计算方式如下：对于面和多点，将使用几何的质心；对于线输入，则会使用几何的中点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OverlapType { get; set; } = "INTERSECT";

		/// <summary>
		/// <para>Selecting Features</para>
		/// <para>输入要素参数中的要素将根据它们与此图层或要素类中要素的关系进行选择。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object? SelectFeatures { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>将被搜索的距离。 仅当关系参数设置为在某一距离范围内、在某一测地线距离范围内、在某一 3D 距离范围内、相交、3D 相交、中心在要素范围内或者包含时，该参数才有效。</para>
		/// <para>如果选择在某一测地线距离范围内选项，请使用线性单位（如千米或英里）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? SearchDistance { get; set; }

		/// <summary>
		/// <para>Invert Spatial Relationship</para>
		/// <para>指定将使用空间关系评估结果，还是使用反转结果。 例如，可使用此参数获取不相交或与另一数据集中的要素不在指定距离范围内的要素的列表。</para>
		/// <para>未选中 - 将使用查询结果。 这是默认设置。</para>
		/// <para>选中 - 将使用反转查询结果。 如果使用选择类型参数，则将先反转选择，然后再将其与现有选择组合。</para>
		/// <para><see cref="InvertSpatialRelationshipEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? InvertSpatialRelationship { get; set; } = "false";

		/// <summary>
		/// <para>Selection Condition</para>
		/// <para>指定将使用的介于输入和选择要素间的空间关系选择条件。</para>
		/// <para>Exists—检查空间关系是否存在于输入中的任意要素与选择要素之间。 这是默认设置。</para>
		/// <para>无选择内容—检查空间关系是否不存在于任意输入与选择要素之间。</para>
		/// <para>全部选中—检查空间关系是否存在于输入要素的所有要素中。</para>
		/// <para>等于—检查具有空间关系的输入要素的数量是否等于计数值。</para>
		/// <para>介于—检查具有空间关系的输入要素的数量是否介于最小计数值与最大计数值之间。</para>
		/// <para>小于—检查具有空间关系的输入要素的数量是否小于计数值。</para>
		/// <para>大于—检查与 SQL 表达式匹配的记录，其字段值是否大于计数值。</para>
		/// <para>不等于—检查具有空间关系的输入要素的数量是否不等于计数值。</para>
		/// <para><see cref="SelectionConditionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SelectionCondition { get; set; } = "EXISTS";

		/// <summary>
		/// <para>Count</para>
		/// <para>整数计数值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? Count { get; set; } = "0";

		/// <summary>
		/// <para>Minimum Count</para>
		/// <para>最小整数计数值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? CountMin { get; set; } = "0";

		/// <summary>
		/// <para>Maximum Count</para>
		/// <para>最大整数计数值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? CountMax { get; set; } = "0";

		/// <summary>
		/// <para>True</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? True { get; set; } = "false";

		/// <summary>
		/// <para>False</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? False { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Invert Spatial Relationship</para>
		/// </summary>
		public enum InvertSpatialRelationshipEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INVERT")]
			INVERT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_INVERT")]
			NOT_INVERT,

		}

		/// <summary>
		/// <para>Selection Condition</para>
		/// </summary>
		public enum SelectionConditionEnum 
		{
			/// <summary>
			/// <para>Exists—检查空间关系是否存在于输入中的任意要素与选择要素之间。 这是默认设置。</para>
			/// </summary>
			[GPValue("EXISTS")]
			[Description("Exists")]
			Exists,

			/// <summary>
			/// <para>无选择内容—检查空间关系是否不存在于任意输入与选择要素之间。</para>
			/// </summary>
			[GPValue("NO_SELECTION")]
			[Description("无选择内容")]
			No_Selection,

			/// <summary>
			/// <para>全部选中—检查空间关系是否存在于输入要素的所有要素中。</para>
			/// </summary>
			[GPValue("ALL_SELECTED")]
			[Description("全部选中")]
			All_Selected,

			/// <summary>
			/// <para>等于—检查具有空间关系的输入要素的数量是否等于计数值。</para>
			/// </summary>
			[GPValue("IS_EQUAL_TO")]
			[Description("等于")]
			Is_Equal_to,

			/// <summary>
			/// <para>介于—检查具有空间关系的输入要素的数量是否介于最小计数值与最大计数值之间。</para>
			/// </summary>
			[GPValue("IS_BETWEEN")]
			[Description("介于")]
			Is_Between,

			/// <summary>
			/// <para>小于—检查具有空间关系的输入要素的数量是否小于计数值。</para>
			/// </summary>
			[GPValue("IS_LESS_THAN")]
			[Description("小于")]
			Is_Less_Than,

			/// <summary>
			/// <para>大于—检查与 SQL 表达式匹配的记录，其字段值是否大于计数值。</para>
			/// </summary>
			[GPValue("IS_GREATER_THAN")]
			[Description("大于")]
			Is_Greater_Than,

			/// <summary>
			/// <para>不等于—检查具有空间关系的输入要素的数量是否不等于计数值。</para>
			/// </summary>
			[GPValue("IS_NOT_EQUAL_TO")]
			[Description("不等于")]
			Is_Not_Equal_to,

		}

#endregion
	}
}
