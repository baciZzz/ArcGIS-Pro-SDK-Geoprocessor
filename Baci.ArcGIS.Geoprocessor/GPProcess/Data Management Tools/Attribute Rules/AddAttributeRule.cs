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
	/// <para>Add Attribute Rule</para>
	/// <para>添加属性规则</para>
	/// <para>用于向数据集添加属性规则。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddAttributeRule : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>将应用新规则的表或要素类。</para>
		/// </param>
		/// <param name="Name">
		/// <para>Name</para>
		/// <para>新规则的唯一名称。</para>
		/// </param>
		/// <param name="Type">
		/// <para>Type</para>
		/// <para>指定要添加的属性规则类型。</para>
		/// <para>计算—在要素上设置其他属性时，将自动填充要素的属性值。将基于指定的触发事件来应用这些规则。可将长时间运行的计算设置为在批处理模式下运行，并在用户定义的时间进行评估。添加多个计算规则时，如果存在循环依赖关系，则添加规则的顺序非常重要。例如，规则 A 计算 Field1 等于 $feature.Field2 + $feature.Field3 的值，规则 B 计算 Field4 等于 $feature.Field1 + $feature.Field5，则计算的结果可能不同，具体取决于添加规则的顺序。</para>
		/// <para>约束—指定要素上允许的属性配置。如果违反约束规则，则将生成错误，并且不会存储该要素。例如，如果 Field A 的值必须小于 Field B 与 Field C 的总和，则在违反该约束时将会生成错误。</para>
		/// <para>验证—使用批处理验证过程对现有要素进行检查。将在用户定义的时间评估规则。违反规则时，将创建错误要素。规则的类型只能用于设置为分支版本化的数据。</para>
		/// <para><see cref="TypeEnum"/></para>
		/// </param>
		/// <param name="ScriptExpression">
		/// <para>Script Expression</para>
		/// <para>用于定义规则的 Arcade 表达式。</para>
		/// </param>
		public AddAttributeRule(object InTable, object Name, object Type, object ScriptExpression)
		{
			this.InTable = InTable;
			this.Name = Name;
			this.Type = Type;
			this.ScriptExpression = ScriptExpression;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加属性规则</para>
		/// </summary>
		public override string DisplayName() => "添加属性规则";

		/// <summary>
		/// <para>Tool Name : AddAttributeRule</para>
		/// </summary>
		public override string ToolName() => "AddAttributeRule";

		/// <summary>
		/// <para>Tool Excute Name : management.AddAttributeRule</para>
		/// </summary>
		public override string ExcuteName() => "management.AddAttributeRule";

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
		public override object[] Parameters() => new object[] { InTable, Name, Type, ScriptExpression, IsEditable, TriggeringEvents, ErrorNumber, ErrorMessage, Description, Subtype, Field, ExcludeFromClientEvaluation, OutTable, Batch, Severity, Tags };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>将应用新规则的表或要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// <para>新规则的唯一名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Name { get; set; }

		/// <summary>
		/// <para>Type</para>
		/// <para>指定要添加的属性规则类型。</para>
		/// <para>计算—在要素上设置其他属性时，将自动填充要素的属性值。将基于指定的触发事件来应用这些规则。可将长时间运行的计算设置为在批处理模式下运行，并在用户定义的时间进行评估。添加多个计算规则时，如果存在循环依赖关系，则添加规则的顺序非常重要。例如，规则 A 计算 Field1 等于 $feature.Field2 + $feature.Field3 的值，规则 B 计算 Field4 等于 $feature.Field1 + $feature.Field5，则计算的结果可能不同，具体取决于添加规则的顺序。</para>
		/// <para>约束—指定要素上允许的属性配置。如果违反约束规则，则将生成错误，并且不会存储该要素。例如，如果 Field A 的值必须小于 Field B 与 Field C 的总和，则在违反该约束时将会生成错误。</para>
		/// <para>验证—使用批处理验证过程对现有要素进行检查。将在用户定义的时间评估规则。违反规则时，将创建错误要素。规则的类型只能用于设置为分支版本化的数据。</para>
		/// <para><see cref="TypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Type { get; set; }

		/// <summary>
		/// <para>Script Expression</para>
		/// <para>用于定义规则的 Arcade 表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCalculatorExpression()]
		public object ScriptExpression { get; set; }

		/// <summary>
		/// <para>Is Editable</para>
		/// <para>指定是否可以编辑属性值。可将属性规则配置为阻止或允许编辑者编辑正在进行计算的字段的属性值。此参数仅适用于计算属性规则类型。</para>
		/// <para>选中 - 编辑者将可以编辑属性值。这是默认设置。</para>
		/// <para>未选中 - 编辑者将无法编辑属性值。</para>
		/// <para><see cref="IsEditableEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsEditable { get; set; } = "true";

		/// <summary>
		/// <para>Triggering Events</para>
		/// <para>指定将触发属性规则生效的编辑事件。该参数仅对计算和约束规则类型有效。对于未选中批处理参数（Python 中的 batch = &quot;NOT_BATCH&quot;）的计算规则，必须至少提供一个触发事件。触发事件不适用于选中了批处理参数（Python 中的 batch = &quot;BATCH&quot;）的计算规则。</para>
		/// <para>插入—将在添加新要素后应用规则。</para>
		/// <para>更新—将在更新要素后应用规则。</para>
		/// <para>删除—将在删除要素后应用规则。</para>
		/// <para><see cref="TriggeringEventsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object TriggeringEvents { get; set; }

		/// <summary>
		/// <para>Error Number</para>
		/// <para>违反此规则时将返回的错误编号。此值不必唯一，因此可以针对多个规则返回相同的自定义错误编号。</para>
		/// <para>对于约束和验证规则，此参数为必需项。对于计算规则，则为可选参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ErrorNumber { get; set; }

		/// <summary>
		/// <para>Error Message</para>
		/// <para>违反此规则时将返回的错误消息。建议使用描述性消息，以便在出现冲突时帮助编辑者理解冲突。消息最多包含 2000 个字符。</para>
		/// <para>对于约束和验证规则，此参数为必需项。对于计算规则，则为可选参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ErrorMessage { get; set; }

		/// <summary>
		/// <para>Description</para>
		/// <para>新属性规则的描述。描述最多包含 256 个字符。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Description { get; set; }

		/// <summary>
		/// <para>Subtype</para>
		/// <para>如果数据集具有子类型，则将对其应用规则的子类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Subtype { get; set; }

		/// <summary>
		/// <para>Field</para>
		/// <para>将应用该规则的现有字段的名称。此参数仅适用于计算属性规则类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Field { get; set; }

		/// <summary>
		/// <para>Exclude from application evaluation</para>
		/// <para>指定是否在应用编辑内容之前从评估中排除规则。因为并非所有客户端都能够运行所有可用规则，所以您可以选择标记仅适用于简单客户端的规则。例如，某些规则可能会参考尚未提供给所有客户端的数据（原因包括数据离线、大小或安全性），或者某些规则可能取决于用户或上下文（即 ArcGIS Collector 中的轻量级字段更新可能不会执行需要其他用户输入或知识的规则，但 ArcGIS Pro 一类的客户端可能会为其提供支持）。如果选中了 Batch 参数，则此参数不适用于验证规则和计算规则。</para>
		/// <para>选中 - 将从客户端评估中排除该规则。</para>
		/// <para>未选中 - 将针对所有客户端执行该规则。这是默认设置。</para>
		/// <para>在 ArcGIS Pro 2.4 之前，此参数标注为仅限服务器。</para>
		/// <para><see cref="ExcludeFromClientEvaluationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ExcludeFromClientEvaluation { get; set; } = "false";

		/// <summary>
		/// <para>Attribute Rule Added</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Batch</para>
		/// <para>指定是否将在批处理模式下执行规则评估。</para>
		/// <para>选中 - 稍后将通过执行验证在批处理模式下执行规则评估。</para>
		/// <para>未选中 - 将不会在批处理模式下执行规则评估。将使用触发事件来确定针对插入、更新或删除编辑操作进行规则评估的时间。这是默认设置。</para>
		/// <para>计算规则可处于选中或未选中状态。此参数的验证规则始终处于选中状态，约束规则始终处于未选中状态。</para>
		/// <para>只有已启用分支版本化的数据才支持批处理规则。</para>
		/// <para><see cref="BatchEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Batch { get; set; } = "false";

		/// <summary>
		/// <para>Severity</para>
		/// <para>错误的严重性。</para>
		/// <para>可以在 1-5 范围内选择一个值定义规则的严重性。值 1 为最高，代表最严重；值 5 为最低，代表最不严重。例如，您可以为特定的属性规则选择低严重性，忽略数据生产流程中的错误，也可以设置高严重性，此时则需要修复错误以提高所收集数据的准确性。</para>
		/// <para>此参数仅适用于验证规则。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object Severity { get; set; }

		/// <summary>
		/// <para>Tags</para>
		/// <para>用于标识规则（可搜索和可索引）的一系列标签，作为映射到数据模型中的功能需求的方式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Tags { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddAttributeRule SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Type</para>
		/// </summary>
		public enum TypeEnum 
		{
			/// <summary>
			/// <para>计算—在要素上设置其他属性时，将自动填充要素的属性值。将基于指定的触发事件来应用这些规则。可将长时间运行的计算设置为在批处理模式下运行，并在用户定义的时间进行评估。添加多个计算规则时，如果存在循环依赖关系，则添加规则的顺序非常重要。例如，规则 A 计算 Field1 等于 $feature.Field2 + $feature.Field3 的值，规则 B 计算 Field4 等于 $feature.Field1 + $feature.Field5，则计算的结果可能不同，具体取决于添加规则的顺序。</para>
			/// </summary>
			[GPValue("CALCULATION")]
			[Description("计算")]
			Calculation,

			/// <summary>
			/// <para>约束—指定要素上允许的属性配置。如果违反约束规则，则将生成错误，并且不会存储该要素。例如，如果 Field A 的值必须小于 Field B 与 Field C 的总和，则在违反该约束时将会生成错误。</para>
			/// </summary>
			[GPValue("CONSTRAINT")]
			[Description("约束")]
			Constraint,

			/// <summary>
			/// <para>验证—使用批处理验证过程对现有要素进行检查。将在用户定义的时间评估规则。违反规则时，将创建错误要素。规则的类型只能用于设置为分支版本化的数据。</para>
			/// </summary>
			[GPValue("VALIDATION")]
			[Description("验证")]
			Validation,

		}

		/// <summary>
		/// <para>Is Editable</para>
		/// </summary>
		public enum IsEditableEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EDITABLE")]
			EDITABLE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NONEDITABLE")]
			NONEDITABLE,

		}

		/// <summary>
		/// <para>Triggering Events</para>
		/// </summary>
		public enum TriggeringEventsEnum 
		{
			/// <summary>
			/// <para>插入—将在添加新要素后应用规则。</para>
			/// </summary>
			[GPValue("INSERT")]
			[Description("插入")]
			Insert,

			/// <summary>
			/// <para>删除—将在删除要素后应用规则。</para>
			/// </summary>
			[GPValue("DELETE")]
			[Description("删除")]
			Delete,

			/// <summary>
			/// <para>更新—将在更新要素后应用规则。</para>
			/// </summary>
			[GPValue("UPDATE")]
			[Description("更新")]
			Update,

		}

		/// <summary>
		/// <para>Exclude from application evaluation</para>
		/// </summary>
		public enum ExcludeFromClientEvaluationEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EXCLUDE")]
			EXCLUDE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("INCLUDE")]
			INCLUDE,

		}

		/// <summary>
		/// <para>Batch</para>
		/// </summary>
		public enum BatchEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("BATCH")]
			BATCH,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_BATCH")]
			NOT_BATCH,

		}

#endregion
	}
}
