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
	/// <para>Alter Attribute Rule</para>
	/// <para>Alters the properties of an attribute rule.</para>
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
		/// <para>The table containing the attribute rule to be altered.</para>
		/// </param>
		/// <param name="Name">
		/// <para>Rule Name</para>
		/// <para>The name of the attribute rule that will be altered.</para>
		/// </param>
		public AlterAttributeRule(object InTable, object Name)
		{
			this.InTable = InTable;
			this.Name = Name;
		}

		/// <summary>
		/// <para>Tool Display Name : Alter Attribute Rule</para>
		/// </summary>
		public override string DisplayName() => "Alter Attribute Rule";

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
		public override object[] Parameters() => new object[] { InTable, Name, Description, ErrorNumber, ErrorMessage, Tags, UpdatedTable, TriggeringEvents, ScriptExpression, ExcludeFromClientEvaluation };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table containing the attribute rule to be altered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Rule Name</para>
		/// <para>The name of the attribute rule that will be altered.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Name { get; set; }

		/// <summary>
		/// <para>Description</para>
		/// <para>The description of the attribute rule. To clear the current value of the description, choose the Reset option from the drop-down menu.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Description { get; set; }

		/// <summary>
		/// <para>Error Number</para>
		/// <para>The error number of the attribute rule. To clear the current value of the error number for a calculation rule, choose the Reset option from the drop-down menu. Error number is a required property for constraint and validation rules and cannot be cleared.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ErrorNumber { get; set; }

		/// <summary>
		/// <para>Error Message</para>
		/// <para>The error message of the attribute rule. To clear the current value of the error message for a calculation rule, choose the Reset option from the drop-down menu. Error message is a required property for constraint and validation rules and cannot be cleared.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ErrorMessage { get; set; }

		/// <summary>
		/// <para>Tags</para>
		/// <para>The tags for the attribute rule. To clear all tags, click to remove each tag from the list, and select Reset from the drop-down menu.</para>
		/// <para><see cref="TagsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object Tags { get; set; }

		/// <summary>
		/// <para>Updated Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object UpdatedTable { get; set; }

		/// <summary>
		/// <para>Triggering Events</para>
		/// <para>Specifies the editing events that will trigger the attribute rule to take effect. Triggering events are only applicable for constraint rules and calculation rules that have the Batch parameter set to false. Be aware that the new values will replace existing triggering events. To keep the current triggering events, leave this parameter empty.</para>
		/// <para>Insert—The rule will be applied when a new feature is added.</para>
		/// <para>Update—The rule will be applied when a feature is updated.</para>
		/// <para>Delete—The rule will be applied when a feature is deleted.</para>
		/// <para><see cref="TriggeringEventsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object TriggeringEvents { get; set; }

		/// <summary>
		/// <para>Script Expression</para>
		/// <para>An Arcade expression that defines the rule. To keep the current expression, leave this parameter empty. Be aware that if an expression is provided for this parameter, it will replace the existing Arcade expression of the rule. If you alter the script expression of a batch calculation or validation rule, the rule will need to be reevaluated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCalculatorExpression()]
		public object ScriptExpression { get; set; }

		/// <summary>
		/// <para>Exclude From Client Evaluation</para>
		/// <para>Specifies whether the rule will be evaluated before edits are applied. The default for this property corresponds to the current value set for the rule. That is, if the input rule has the exclude from client evaluation property set to false, the default for this parameter will be unchecked so as to not modify the property without you specifically choosing to do so. This parameter is not applicable for validation rules or batch calculation rules.</para>
		/// <para>Checked—The rule will be excluded from client evaluation.</para>
		/// <para>Unchecked—The rule will be executed for all clients.</para>
		/// <para><see cref="ExcludeFromClientEvaluationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ExcludeFromClientEvaluation { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AlterAttributeRule SetEnviroment(object workspace = null)
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
			[Description("Reset")]
			Reset,

		}

		/// <summary>
		/// <para>Triggering Events</para>
		/// </summary>
		public enum TriggeringEventsEnum 
		{
			/// <summary>
			/// <para>Insert—The rule will be applied when a new feature is added.</para>
			/// </summary>
			[GPValue("INSERT")]
			[Description("Insert")]
			Insert,

			/// <summary>
			/// <para>Delete—The rule will be applied when a feature is deleted.</para>
			/// </summary>
			[GPValue("DELETE")]
			[Description("Delete")]
			Delete,

			/// <summary>
			/// <para>Update—The rule will be applied when a feature is updated.</para>
			/// </summary>
			[GPValue("UPDATE")]
			[Description("Update")]
			Update,

		}

		/// <summary>
		/// <para>Exclude From Client Evaluation</para>
		/// </summary>
		public enum ExcludeFromClientEvaluationEnum 
		{
			/// <summary>
			/// <para>Checked—The rule will be excluded from client evaluation.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EXCLUDE")]
			EXCLUDE,

			/// <summary>
			/// <para>Unchecked—The rule will be executed for all clients.</para>
			/// </summary>
			[GPValue("false")]
			[Description("INCLUDE")]
			INCLUDE,

		}

#endregion
	}
}
