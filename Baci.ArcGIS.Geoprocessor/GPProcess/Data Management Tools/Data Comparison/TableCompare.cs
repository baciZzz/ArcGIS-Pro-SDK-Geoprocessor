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
	/// <para>Table Compare</para>
	/// <para>表比较</para>
	/// <para>对两个表或表视图进行比较并返回比较结果。</para>
	/// </summary>
	public class TableCompare : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InBaseTable">
		/// <para>Input Base Table</para>
		/// <para>将输入基础表与输入测试表进行比较。输入基础表是指已被声明为有效的表格数据。该基础数据具有正确的字段定义和属性值。</para>
		/// </param>
		/// <param name="InTestTable">
		/// <para>Input Test Table</para>
		/// <para>将输入测试表与输入基础表进行比较。输入测试表是指已通过编辑或编译新的字段、新的记录或新的属性值而进行更改的数据。</para>
		/// </param>
		/// <param name="SortField">
		/// <para>Sort Field</para>
		/// <para>用于在输入基础表和输入测试表中对记录进行排序的一个或多个字段。记录将以升序进行排序。在输入基础表与输入测试表中均按公用字段进行排序，可确保对每个输入数据集中相同的行进行比较。</para>
		/// </param>
		public TableCompare(object InBaseTable, object InTestTable, object SortField)
		{
			this.InBaseTable = InBaseTable;
			this.InTestTable = InTestTable;
			this.SortField = SortField;
		}

		/// <summary>
		/// <para>Tool Display Name : 表比较</para>
		/// </summary>
		public override string DisplayName() => "表比较";

		/// <summary>
		/// <para>Tool Name : TableCompare</para>
		/// </summary>
		public override string ToolName() => "TableCompare";

		/// <summary>
		/// <para>Tool Excute Name : management.TableCompare</para>
		/// </summary>
		public override string ExcuteName() => "management.TableCompare";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InBaseTable, InTestTable, SortField, CompareType, IgnoreOptions, AttributeTolerances, OmitField, ContinueCompare, OutCompareFile, CompareStatus };

		/// <summary>
		/// <para>Input Base Table</para>
		/// <para>将输入基础表与输入测试表进行比较。输入基础表是指已被声明为有效的表格数据。该基础数据具有正确的字段定义和属性值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InBaseTable { get; set; }

		/// <summary>
		/// <para>Input Test Table</para>
		/// <para>将输入测试表与输入基础表进行比较。输入测试表是指已通过编辑或编译新的字段、新的记录或新的属性值而进行更改的数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTestTable { get; set; }

		/// <summary>
		/// <para>Sort Field</para>
		/// <para>用于在输入基础表和输入测试表中对记录进行排序的一个或多个字段。记录将以升序进行排序。在输入基础表与输入测试表中均按公用字段进行排序，可确保对每个输入数据集中相同的行进行比较。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		public object SortField { get; set; }

		/// <summary>
		/// <para>Compare Type</para>
		/// <para>比较类型。默认设置为 ALL。该默认设置将对要比较的表中的所有属性进行比较。</para>
		/// <para>所有—比较所有属性。这是默认设置。</para>
		/// <para>仅属性—仅比较属性及其值。</para>
		/// <para>仅方案—仅比较方案。</para>
		/// <para><see cref="CompareTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object CompareType { get; set; } = "ALL";

		/// <summary>
		/// <para>Ignore Options</para>
		/// <para>不会对这些属性进行比较。</para>
		/// <para>忽略扩展属性—不比较扩展属性。</para>
		/// <para>忽略子类型—不比较子类型。</para>
		/// <para>忽略关系类—不比较关系类。</para>
		/// <para>忽略字段别名—不比较字段别名。</para>
		/// <para><see cref="IgnoreOptionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object IgnoreOptions { get; set; }

		/// <summary>
		/// <para>Attribute Tolerance</para>
		/// <para>在该数值范围内的属性值将被视作相同。它仅适用于数值字段类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object AttributeTolerances { get; set; }

		/// <summary>
		/// <para>Omit Fields</para>
		/// <para>在比较过程中将被忽略的一个或多个字段。这些字段的字段定义和表格值将被忽略。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object OmitField { get; set; }

		/// <summary>
		/// <para>Continue Comparison</para>
		/// <para>指示在遇到第一个不匹配项后是否继续比较所有属性。</para>
		/// <para>未选中 - 在遇到第一个不匹配项后即停止比较。这是默认设置。</para>
		/// <para>选中 - 在遇到第一个不匹配项后继续比较其他属性。</para>
		/// <para><see cref="ContinueCompareEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ContinueCompare { get; set; } = "false";

		/// <summary>
		/// <para>Output Compare File</para>
		/// <para>该文件将包含输入基础表和输入测试表之间的所有异同点。该文件是一个以逗号分隔的文本文件，在 ArcGIS 中可以表的形式对其进行查看和使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object OutCompareFile { get; set; }

		/// <summary>
		/// <para>Compare Status</para>
		/// <para><see cref="CompareStatusEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CompareStatus { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TableCompare SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Compare Type</para>
		/// </summary>
		public enum CompareTypeEnum 
		{
			/// <summary>
			/// <para>所有—比较所有属性。这是默认设置。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有")]
			All,

			/// <summary>
			/// <para>仅属性—仅比较属性及其值。</para>
			/// </summary>
			[GPValue("ATTRIBUTES_ONLY")]
			[Description("仅属性")]
			Attributes_only,

			/// <summary>
			/// <para>仅方案—仅比较方案。</para>
			/// </summary>
			[GPValue("SCHEMA_ONLY")]
			[Description("仅方案")]
			Schema_only,

		}

		/// <summary>
		/// <para>Ignore Options</para>
		/// </summary>
		public enum IgnoreOptionsEnum 
		{
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
