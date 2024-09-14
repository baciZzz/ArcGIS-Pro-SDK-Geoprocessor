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
	/// <para>Alter Attribute Rule</para>
	/// <para>更改属性规则</para>
	/// <para>更改属性规则的属性。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AlterAttributeRule : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>包含要更改的属性规则的表。</para>
		/// </param>
		/// <param name="Name">
		/// <para>Rule Name</para>
		/// <para>要更改的属性规则名称。</para>
		/// </param>
		public AlterAttributeRule(object InTable, object Name)
		{
			this.InTable = InTable;
			this.Name = Name;
		}

		/// <summary>
		/// <para>Tool Display Name : 更改属性规则</para>
		/// </summary>
		public override string DisplayName() => "更改属性规则";

		/// <summary>
		/// <para>Tool Name : AlterAttributeRule</para>
		/// </summary>
		public override string ToolName() => "AlterAttributeRule";

		/// <summary>
		/// <para>Tool Excute Name : management.AlterAttributeRule</para>
		/// </summary>
		public override string ExcuteName() => "management.AlterAttributeRule";

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
		public override object[] Parameters() => new object[] { InTable, Name, Description!, ErrorNumber!, ErrorMessage!, Tags!, UpdatedTable!, TriggeringEvents!, ScriptExpression!, ExcludeFromClientEvaluation! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>包含要更改的属性规则的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Rule Name</para>
		/// <para>要更改的属性规则名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Name { get; set; }

		/// <summary>
		/// <para>Description</para>
		/// <para>属性规则的描述。 要清除描述的当前值，请从下拉菜单中选择重置选项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Description { get; set; }

		/// <summary>
		/// <para>Error Number</para>
		/// <para>属性规则的错误编号。 要清除计算规则错误编号的当前值，请从下拉菜单中选择重置选项。 对于约束和验证规则，错误编号为必需属性，且不能清除。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ErrorNumber { get; set; }

		/// <summary>
		/// <para>Error Message</para>
		/// <para>属性规则的错误消息。 要清除计算规则错误消息的当前值，请从下拉菜单中选择重置选项。 对于约束和验证规则，错误消息为必需属性，且不能清除。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ErrorMessage { get; set; }

		/// <summary>
		/// <para>Tags</para>
		/// <para>属性规则的标签。 要清除所有标签，请单击删除按钮 以从列表中移除所有标签，然后从下拉菜单中选择重置。</para>
		/// <para><see cref="TagsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? Tags { get; set; }

		/// <summary>
		/// <para>Updated Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? UpdatedTable { get; set; }

		/// <summary>
		/// <para>Triggering Events</para>
		/// <para>指定将触发属性规则生效的编辑事件。 触发事件仅适用于将批处理参数设置为 false 的约束规则和计算规则类型。 新值将替换现有触发事件。 要保留当前触发事件，请将此参数留空。</para>
		/// <para>插入—将在添加新要素后应用规则。</para>
		/// <para>更新—将在更新要素后应用规则。</para>
		/// <para>删除—将在删除要素后应用规则。</para>
		/// <para><see cref="TriggeringEventsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? TriggeringEvents { get; set; }

		/// <summary>
		/// <para>Script Expression</para>
		/// <para>用于定义规则的 Arcade 表达式。 要保留当前表达式，请将此参数留空。 如果为此参数提供了表达式，该表达式将替换规则的现有 Arcade 表达式。 如果更改了批处理计算或验证规则的脚本表达式，则必须重新评估规则。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCalculatorExpression()]
		public object? ScriptExpression { get; set; }

		/// <summary>
		/// <para>Exclude From Client Evaluation</para>
		/// <para>指定应用程序是否在将编辑内容应用到工作空间之前在本地评估规则。</para>
		/// <para>此参数的默认值对应于为规则设置的当前值。 也就是说，如果输入规则将“从客户端评估中排除”参数设置为 false，则将取消选中此参数的默认值，这样将不会自动排除该规则。 该参数不适用于验证规则或批处理计算规则。</para>
		/// <para>选中 - 将从客户端评估中排除该规则。</para>
		/// <para>未选中 - 不会从客户端评估中排除该规则。</para>
		/// <para><see cref="ExcludeFromClientEvaluationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ExcludeFromClientEvaluation { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AlterAttributeRule SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Tags</para>
		/// </summary>
		public enum TagsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("RESET")]
			[Description("重置")]
			Reset,

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
		/// <para>Exclude From Client Evaluation</para>
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

#endregion
	}
}
