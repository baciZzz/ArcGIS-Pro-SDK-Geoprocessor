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
	/// <para>Add Rule To Relationship Class</para>
	/// <para>Adds a rule to a relationship class.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddRuleToRelationshipClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRelClass">
		/// <para>Input Relationship Class</para>
		/// <para>The relationship class to which a rule will be added.</para>
		/// </param>
		public AddRuleToRelationshipClass(object InRelClass)
		{
			this.InRelClass = InRelClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Rule To Relationship Class</para>
		/// </summary>
		public override string DisplayName => "Add Rule To Relationship Class";

		/// <summary>
		/// <para>Tool Name : AddRuleToRelationshipClass</para>
		/// </summary>
		public override string ToolName => "AddRuleToRelationshipClass";

		/// <summary>
		/// <para>Tool Excute Name : management.AddRuleToRelationshipClass</para>
		/// </summary>
		public override string ExcuteName => "management.AddRuleToRelationshipClass";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRelClass, OriginSubtype!, OriginMinimum!, OriginMaximum!, DestinationSubtype!, DestinationMinimum!, DestinationMaximum!, OutRelClass! };

		/// <summary>
		/// <para>Input Relationship Class</para>
		/// <para>The relationship class to which a rule will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERelationshipClass()]
		public object InRelClass { get; set; }

		/// <summary>
		/// <para>Origin Subtype</para>
		/// <para>Specifies the subtype of the origin class. If the origin class has subtypes, choose the subtype to which you want to associate a relationship class rule. If the origin class has no subtypes, the relationship rule will apply to all features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? OriginSubtype { get; set; }

		/// <summary>
		/// <para>Origin Minimum</para>
		/// <para>Specifies the minimum range cardinality for the origin class if the relationship class is many-to-many.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? OriginMinimum { get; set; }

		/// <summary>
		/// <para>Origin Maximum</para>
		/// <para>Specifies the maximum range cardinality for the origin class if the relationship class is many-to-many or one-to-many.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? OriginMaximum { get; set; }

		/// <summary>
		/// <para>Destination Subtype</para>
		/// <para>Specifies the subtype of the destination class. If the destination class has subtypes, choose the subtype to which you want to associate a relationship class rule. If the destination class has no subtypes, the relationship rule will apply to all features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? DestinationSubtype { get; set; }

		/// <summary>
		/// <para>Destination Minimum</para>
		/// <para>Specifies the minimum range cardinality for the destination class if the relationship class is many-to-many or one-to-many.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? DestinationMinimum { get; set; }

		/// <summary>
		/// <para>Destination Maximum</para>
		/// <para>Specifies the maximum range cardinality for the destination class if the relationship class is many-to-many or one-to-many.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? DestinationMaximum { get; set; }

		/// <summary>
		/// <para>Updated Relationship Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERelationshipClass()]
		public object? OutRelClass { get; set; }

	}
}
