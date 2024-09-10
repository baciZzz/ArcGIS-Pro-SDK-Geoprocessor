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
	/// <para>Adds an attribute rule to a dataset.</para>
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
		/// <para>The table or feature class that will have the new rule applied.</para>
		/// </param>
		/// <param name="Name">
		/// <para>Name</para>
		/// <para>A unique name for the new rule.</para>
		/// </param>
		/// <param name="Type">
		/// <para>Type</para>
		/// <para>Specifies the type of attribute rule to add.</para>
		/// <para>Calculation—Automatically populate attribute values for features when another attribute is set on a feature. These rules are applied based on the triggering events specified. Long running calculations can be set to run in batch mode and will be evaluated at a user-defined time.When adding multiple calculation rules, the order in which the rules are added is important if there are circular dependencies. For example, Rule A calculates Field1 is equal to the value of $feature.Field2 + $feature.Field3, and Rule B calculates Field4 is equal to $feature.Field1 + $feature.Field5; the results of the calculation may be different depending on the order in which the rules are added.</para>
		/// <para>Constraint—Specify permissible attribute configurations on a feature. When the constraint rule is violated, an error is generated and the feature is not stored. For example, if the value of Field A must be less than the sum of Field B and Field C, an error will be generated when that constraint is violated.</para>
		/// <para>Validation—Check for existing features with a batch validation process. Rules are evaluated at a user-defined time. When a rule is violated, an error feature is created. The type of rule can only be used for data that has been set up for branch versioning.</para>
		/// <para><see cref="TypeEnum"/></para>
		/// </param>
		/// <param name="ScriptExpression">
		/// <para>Script Expression</para>
		/// <para>The Arcade expression that defines the rule.</para>
		/// </param>
		public AddAttributeRule(object InTable, object Name, object Type, object ScriptExpression)
		{
			this.InTable = InTable;
			this.Name = Name;
			this.Type = Type;
			this.ScriptExpression = ScriptExpression;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Attribute Rule</para>
		/// </summary>
		public override string DisplayName() => "Add Attribute Rule";

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
		/// <para>The table or feature class that will have the new rule applied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// <para>A unique name for the new rule.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Name { get; set; }

		/// <summary>
		/// <para>Type</para>
		/// <para>Specifies the type of attribute rule to add.</para>
		/// <para>Calculation—Automatically populate attribute values for features when another attribute is set on a feature. These rules are applied based on the triggering events specified. Long running calculations can be set to run in batch mode and will be evaluated at a user-defined time.When adding multiple calculation rules, the order in which the rules are added is important if there are circular dependencies. For example, Rule A calculates Field1 is equal to the value of $feature.Field2 + $feature.Field3, and Rule B calculates Field4 is equal to $feature.Field1 + $feature.Field5; the results of the calculation may be different depending on the order in which the rules are added.</para>
		/// <para>Constraint—Specify permissible attribute configurations on a feature. When the constraint rule is violated, an error is generated and the feature is not stored. For example, if the value of Field A must be less than the sum of Field B and Field C, an error will be generated when that constraint is violated.</para>
		/// <para>Validation—Check for existing features with a batch validation process. Rules are evaluated at a user-defined time. When a rule is violated, an error feature is created. The type of rule can only be used for data that has been set up for branch versioning.</para>
		/// <para><see cref="TypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Type { get; set; }

		/// <summary>
		/// <para>Script Expression</para>
		/// <para>The Arcade expression that defines the rule.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCalculatorExpression()]
		public object ScriptExpression { get; set; }

		/// <summary>
		/// <para>Is Editable</para>
		/// <para>Specifies whether the attribute value can be edited. Attribute rules can be configured to either block or allow editors to edit the attribute values of the field being calculated. This parameter is only applicable for the calculation attribute rule type.</para>
		/// <para>Checked—Editors will be able to edit the attribute value. This is the default.</para>
		/// <para>Unchecked—Editors will not be able to edit the attribute value.</para>
		/// <para><see cref="IsEditableEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IsEditable { get; set; } = "true";

		/// <summary>
		/// <para>Triggering Events</para>
		/// <para>Specifies the editing events that will trigger the attribute rule to take effect. This parameter is valid for calculation and constraint rule types only. At least one triggering event must be provided for calculation rules in which the Batch parameter is unchecked (batch = &quot;NOT_BATCH&quot; in Python). Triggering events are not applicable for calculation rules that have the Batch parameter checked (batch = &quot;BATCH&quot; in Python).</para>
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
		/// <para>Error Number</para>
		/// <para>An error number that will be returned when this rule is violated. This value is not required to be unique, so you may have the same custom error number returned for multiple rules.</para>
		/// <para>This parameter is required for the constraint and validation rules. It is optional for calculation rules.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ErrorNumber { get; set; }

		/// <summary>
		/// <para>Error Message</para>
		/// <para>An error message that will be returned when this rule is violated. It is recommended that you use a descriptive message to help the editor understand the violation when it occurs. The message is limited to 2000 characters.</para>
		/// <para>This parameter is required for the constraint and validation rules. It is optional for calculation rules.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ErrorMessage { get; set; }

		/// <summary>
		/// <para>Description</para>
		/// <para>The description of the new attribute rule. The description is limited to 256 characters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Description { get; set; }

		/// <summary>
		/// <para>Subtype</para>
		/// <para>The subtype to which the rule will be applied if the dataset has subtypes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Subtype { get; set; }

		/// <summary>
		/// <para>Field</para>
		/// <para>The name of an existing field to which the rule will be applied. This parameter is only applicable for the calculation attribute rule type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Field { get; set; }

		/// <summary>
		/// <para>Exclude from application evaluation</para>
		/// <para>Specifies whether the rule will be excluded from evaluation before edits are applied. Because not all clients may have the capability to run all of the available rules, you can choose to flag a rule for simple clients only. For example, some rules may refer to data that has not been made available to all clients (reasons can include the data is offline, size, or security), or some rules may depend on the user or context (that is, a lightweight field update in ArcGIS Collector may not execute a rule that requires additional user input or knowledge; however, a client such as ArcGIS Pro may support it). This parameter is not applicable for validation rules or calculation rules if the Batch parameter is checked.</para>
		/// <para>Checked—The rule will be excluded from client evaluation.</para>
		/// <para>Unchecked—The rule will be executed for all clients. This is the default.</para>
		/// <para>Prior to ArcGIS Pro 2.4, this parameter was labeled Server only.</para>
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
		/// <para>Specifies whether the rule evaluation will be executed in batch mode.</para>
		/// <para>Checked—The rule evaluation will be executed in batch mode at a later time by executing validate.</para>
		/// <para>Unchecked—The rule evaluation will not be executed in batch mode. Triggering events will be used to determine when the rule is evaluated for insert, update, or delete edit operations. This is the default.</para>
		/// <para>Calculation rules can be either checked or unchecked. Validation rules are always checked for this parameter, and constraint rules are always unchecked.</para>
		/// <para>Batch rules are only supported for data with branch versioning enabled.</para>
		/// <para><see cref="BatchEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Batch { get; set; } = "false";

		/// <summary>
		/// <para>Severity</para>
		/// <para>The severity of the error.</para>
		/// <para>A value within the range of 1 through 5 can be chosen to define the severity of the rule. A value of 1 is high, being the most severe, and a value of 5 is low, being the least severe. For example, you can provide a low severity for a specific attribute rule and ignore the error during data production workflows, or set a high severity in which the error would need to be fixed for accuracy of data collected.</para>
		/// <para>This parameter is only applicable to validation rules.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object Severity { get; set; }

		/// <summary>
		/// <para>Tags</para>
		/// <para>A set of tags that identify the rule (searchable and indexable) as a way to map to a functional requirement in a data model.</para>
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
			/// <para>Calculation—Automatically populate attribute values for features when another attribute is set on a feature. These rules are applied based on the triggering events specified. Long running calculations can be set to run in batch mode and will be evaluated at a user-defined time.When adding multiple calculation rules, the order in which the rules are added is important if there are circular dependencies. For example, Rule A calculates Field1 is equal to the value of $feature.Field2 + $feature.Field3, and Rule B calculates Field4 is equal to $feature.Field1 + $feature.Field5; the results of the calculation may be different depending on the order in which the rules are added.</para>
			/// </summary>
			[GPValue("CALCULATION")]
			[Description("Calculation")]
			Calculation,

			/// <summary>
			/// <para>Constraint—Specify permissible attribute configurations on a feature. When the constraint rule is violated, an error is generated and the feature is not stored. For example, if the value of Field A must be less than the sum of Field B and Field C, an error will be generated when that constraint is violated.</para>
			/// </summary>
			[GPValue("CONSTRAINT")]
			[Description("Constraint")]
			Constraint,

			/// <summary>
			/// <para>Validation—Check for existing features with a batch validation process. Rules are evaluated at a user-defined time. When a rule is violated, an error feature is created. The type of rule can only be used for data that has been set up for branch versioning.</para>
			/// </summary>
			[GPValue("VALIDATION")]
			[Description("Validation")]
			Validation,

		}

		/// <summary>
		/// <para>Is Editable</para>
		/// </summary>
		public enum IsEditableEnum 
		{
			/// <summary>
			/// <para>Checked—Editors will be able to edit the attribute value. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EDITABLE")]
			EDITABLE,

			/// <summary>
			/// <para>Unchecked—Editors will not be able to edit the attribute value.</para>
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
		/// <para>Exclude from application evaluation</para>
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
			/// <para>Unchecked—The rule will be executed for all clients. This is the default.</para>
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
			/// <para>Checked—The rule evaluation will be executed in batch mode at a later time by executing validate.</para>
			/// </summary>
			[GPValue("true")]
			[Description("BATCH")]
			BATCH,

			/// <summary>
			/// <para>Unchecked—The rule evaluation will not be executed in batch mode. Triggering events will be used to determine when the rule is evaluated for insert, update, or delete edit operations. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_BATCH")]
			NOT_BATCH,

		}

#endregion
	}
}
