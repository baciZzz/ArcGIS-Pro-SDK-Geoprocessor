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
	/// <para>Feature Compare</para>
	/// <para>要素比较</para>
	/// <para>比较两个要素类或图层并返回比较结果。</para>
	/// </summary>
	public class FeatureCompare : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InBaseFeatures">
		/// <para>Input Base Features</para>
		/// <para>将输入基础要素与输入测试要素进行比较。输入基础要素是指已声明有效的数据。该基础数据具有正确的几何定义、字段定义以及空间参考。</para>
		/// </param>
		/// <param name="InTestFeatures">
		/// <para>Input Test Features</para>
		/// <para>将输入测试要素与输入基础要素进行比较。输入测试要素是指因编辑或编译新要素而进行更改的数据。</para>
		/// </param>
		/// <param name="SortField">
		/// <para>Sort Field</para>
		/// <para>用于在输入基础要素和输入测试要素中对记录进行排序的一个或多个字段。记录将以升序进行排序。在输入基础要素与输入测试要素中均使用公用字段进行排序，可确保正在对各输入数据集中相同的行进行比较。</para>
		/// </param>
		public FeatureCompare(object InBaseFeatures, object InTestFeatures, object SortField)
		{
			this.InBaseFeatures = InBaseFeatures;
			this.InTestFeatures = InTestFeatures;
			this.SortField = SortField;
		}

		/// <summary>
		/// <para>Tool Display Name : 要素比较</para>
		/// </summary>
		public override string DisplayName() => "要素比较";

		/// <summary>
		/// <para>Tool Name : FeatureCompare</para>
		/// </summary>
		public override string ToolName() => "FeatureCompare";

		/// <summary>
		/// <para>Tool Excute Name : management.FeatureCompare</para>
		/// </summary>
		public override string ExcuteName() => "management.FeatureCompare";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InBaseFeatures, InTestFeatures, SortField, CompareType!, IgnoreOptions!, XyTolerance!, MTolerance!, ZTolerance!, AttributeTolerances!, OmitField!, ContinueCompare!, OutCompareFile!, CompareStatus! };

		/// <summary>
		/// <para>Input Base Features</para>
		/// <para>将输入基础要素与输入测试要素进行比较。输入基础要素是指已声明有效的数据。该基础数据具有正确的几何定义、字段定义以及空间参考。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InBaseFeatures { get; set; }

		/// <summary>
		/// <para>Input Test Features</para>
		/// <para>将输入测试要素与输入基础要素进行比较。输入测试要素是指因编辑或编译新要素而进行更改的数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InTestFeatures { get; set; }

		/// <summary>
		/// <para>Sort Field</para>
		/// <para>用于在输入基础要素和输入测试要素中对记录进行排序的一个或多个字段。记录将以升序进行排序。在输入基础要素与输入测试要素中均使用公用字段进行排序，可确保正在对各输入数据集中相同的行进行比较。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		public object SortField { get; set; }

		/// <summary>
		/// <para>Compare Type</para>
		/// <para>比较类型。默认值为全部，使用该默认设置将对待比较的要素的所有属性进行比较。</para>
		/// <para>所有—将比较要素类的所有属性。这是默认设置。</para>
		/// <para>仅几何—仅比较要素类的几何。</para>
		/// <para>仅属性—仅比较属性及属性值。</para>
		/// <para>仅方案—仅比较要素类的方案。</para>
		/// <para>仅限空间参考—仅比较两个要素类的空间参考。</para>
		/// <para><see cref="CompareTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CompareType { get; set; } = "ALL";

		/// <summary>
		/// <para>Ignore Options</para>
		/// <para>不会对这些属性进行比较。</para>
		/// <para>忽略 M 值—不比较测量属性。</para>
		/// <para>忽略 Z 值—不比较高程属性。</para>
		/// <para>忽略 PointID—不比较点 ID 属性。</para>
		/// <para>忽略扩展属性—不比较扩展属性。</para>
		/// <para>忽略子类型—不比较子类型。</para>
		/// <para>忽略关系类—不比较关系类。</para>
		/// <para>忽略表达类—不比较表达类。</para>
		/// <para>忽略字段别名—不比较字段别名。</para>
		/// <para><see cref="IgnoreOptionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? IgnoreOptions { get; set; }

		/// <summary>
		/// <para>XY Tolerance</para>
		/// <para>落在此距离范围内的要素被视作相同。要使误差最小，所选的比较容差值应尽量小。默认情况下，比较容差就是输入基础要素的“XY 容差”。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? XyTolerance { get; set; }

		/// <summary>
		/// <para>M Tolerance</para>
		/// <para>测量容差是测量值间所允许的最小距离，如果两个测量值之间的距离在此范围内，它们会被视为相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MTolerance { get; set; } = "0";

		/// <summary>
		/// <para>Z Tolerance</para>
		/// <para>“Z 容差”是 z 坐标间所允许的最小距离，如果两个坐标之间的距离在此范围内，它们会被视为同一坐标。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ZTolerance { get; set; } = "0";

		/// <summary>
		/// <para>Attribute Tolerance</para>
		/// <para>在该数值范围内的属性值将被视作相同。它仅适用于数值字段类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? AttributeTolerances { get; set; }

		/// <summary>
		/// <para>Omit Fields</para>
		/// <para>在比较过程中将被忽略的一个或多个字段。这些字段的字段定义和表格值将被忽略。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? OmitField { get; set; }

		/// <summary>
		/// <para>Continue Comparison</para>
		/// <para>指示在遇到第一个不匹配项后是否继续比较所有属性。</para>
		/// <para>未选中 - 在遇到第一个不匹配项后停止比较。这是默认设置。</para>
		/// <para>选中 - 在遇到第一个不匹配项后继续比较其他属性。</para>
		/// <para><see cref="ContinueCompareEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ContinueCompare { get; set; } = "false";

		/// <summary>
		/// <para>Output Compare File</para>
		/// <para>该文件将包含输入基础要素与输入测试要素之间所有的异同处。该文件是一个以逗号分隔的文本文件，在 ArcGIS 中可以表的形式对其进行查看和使用。</para>
		/// <para>该文件将包含 in_base_features 与 in_test_features 之间所有的异同处。该文件是一个以逗号分隔的文本文件，在 ArcGIS 中可以表的形式对其进行查看和使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object? OutCompareFile { get; set; }

		/// <summary>
		/// <para>Compare Status</para>
		/// <para><see cref="CompareStatusEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CompareStatus { get; set; } = "true";

		#region InnerClass

		/// <summary>
		/// <para>Compare Type</para>
		/// </summary>
		public enum CompareTypeEnum 
		{
			/// <summary>
			/// <para>所有—将比较要素类的所有属性。这是默认设置。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有")]
			All,

			/// <summary>
			/// <para>仅几何—仅比较要素类的几何。</para>
			/// </summary>
			[GPValue("GEOMETRY_ONLY")]
			[Description("仅几何")]
			Geometry_only,

			/// <summary>
			/// <para>仅属性—仅比较属性及属性值。</para>
			/// </summary>
			[GPValue("ATTRIBUTES_ONLY")]
			[Description("仅属性")]
			Attributes_only,

			/// <summary>
			/// <para>仅方案—仅比较要素类的方案。</para>
			/// </summary>
			[GPValue("SCHEMA_ONLY")]
			[Description("仅方案")]
			Schema_only,

			/// <summary>
			/// <para>仅限空间参考—仅比较两个要素类的空间参考。</para>
			/// </summary>
			[GPValue("SPATIAL_REFERENCE_ONLY")]
			[Description("仅限空间参考")]
			Spatial_Reference_only,

		}

		/// <summary>
		/// <para>Ignore Options</para>
		/// </summary>
		public enum IgnoreOptionsEnum 
		{
			/// <summary>
			/// <para>忽略 M 值—不比较测量属性。</para>
			/// </summary>
			[GPValue("IGNORE_M")]
			[Description("忽略 M 值")]
			Ignore_Ms,

			/// <summary>
			/// <para>忽略 Z 值—不比较高程属性。</para>
			/// </summary>
			[GPValue("IGNORE_Z")]
			[Description("忽略 Z 值")]
			Ignore_Zs,

			/// <summary>
			/// <para>忽略 PointID—不比较点 ID 属性。</para>
			/// </summary>
			[GPValue("IGNORE_POINTID")]
			[Description("忽略 PointID")]
			Ignore_PointIDs,

			/// <summary>
			/// <para>忽略扩展属性—不比较扩展属性。</para>
			/// </summary>
			[GPValue("IGNORE_EXTENSION_PROPERTIES")]
			[Description("忽略扩展属性")]
			Ignore_extension_properties,

			/// <summary>
			/// <para>忽略子类型—不比较子类型。</para>
			/// </summary>
			[GPValue("IGNORE_SUBTYPES")]
			[Description("忽略子类型")]
			Ignore_subtypes,

			/// <summary>
			/// <para>忽略关系类—不比较关系类。</para>
			/// </summary>
			[GPValue("IGNORE_RELATIONSHIPCLASSES")]
			[Description("忽略关系类")]
			Ignore_relationship_classes,

			/// <summary>
			/// <para>忽略表达类—不比较表达类。</para>
			/// </summary>
			[GPValue("IGNORE_REPRESENTATIONCLASSES")]
			[Description("忽略表达类")]
			Ignore_representation_classes,

			/// <summary>
			/// <para>忽略字段别名—不比较字段别名。</para>
			/// </summary>
			[GPValue("IGNORE_FIELDALIAS")]
			[Description("忽略字段别名")]
			Ignore_field_alias,

		}

		/// <summary>
		/// <para>Continue Comparison</para>
		/// </summary>
		public enum ContinueCompareEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CONTINUE_COMPARE")]
			CONTINUE_COMPARE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CONTINUE_COMPARE")]
			NO_CONTINUE_COMPARE,

		}

		/// <summary>
		/// <para>Compare Status</para>
		/// </summary>
		public enum CompareStatusEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("NO_DIFFERENCES_FOUND")]
			NO_DIFFERENCES_FOUND,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DIFFERENCES_FOUND")]
			DIFFERENCES_FOUND,

		}

#endregion
	}
}
