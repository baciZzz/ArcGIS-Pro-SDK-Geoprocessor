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
	/// <para>Remove Rule From Relationship Class</para>
	/// <para>Remove Rule From Relationship Class</para>
	/// <para>Removes a rule from a relationship class.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class RemoveRuleFromRelationshipClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRelClass">
		/// <para>Input Relationship Class</para>
		/// <para>The relationship class with the rule to remove.</para>
		/// </param>
		public RemoveRuleFromRelationshipClass(object InRelClass)
		{
			this.InRelClass = InRelClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Remove Rule From Relationship Class</para>
		/// </summary>
		public override string DisplayName() => "Remove Rule From Relationship Class";

		/// <summary>
		/// <para>Tool Name : RemoveRuleFromRelationshipClass</para>
		/// </summary>
		public override string ToolName() => "RemoveRuleFromRelationshipClass";

		/// <summary>
		/// <para>Tool Excute Name : management.RemoveRuleFromRelationshipClass</para>
		/// </summary>
		public override string ExcuteName() => "management.RemoveRuleFromRelationshipClass";

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
		public override object[] Parameters() => new object[] { InRelClass, OriginSubtype!, DestinationSubtype!, RemoveAll!, OutRelClass! };

		/// <summary>
		/// <para>Input Relationship Class</para>
		/// <para>The relationship class with the rule to remove.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERelationshipClass()]
		public object InRelClass { get; set; }

		/// <summary>
		/// <para>Origin Subtype</para>
		/// <para>If the origin class has subtypes, the subtype that is associated with the relationship class rule to be deleted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? OriginSubtype { get; set; }

		/// <summary>
		/// <para>Destination Subtype</para>
		/// <para>If the destination class has subtypes, the subtype that is associated with the relationship class rule to be deleted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? DestinationSubtype { get; set; }

		/// <summary>
		/// <para>Remove All</para>
		/// <para>Specifies the relationship rules to be removed from the relationship class.</para>
		/// <para>Checked—All relationship rules will be removed from the input relationship class.</para>
		/// <para>Unchecked—Only rules from the origin and destination subtypes specified will be removed. This is the default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		public object? RemoveAll { get; set; }

		/// <summary>
		/// <para>Updated Relationship Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERelationshipClass()]
		public object? OutRelClass { get; set; }

	}
}
