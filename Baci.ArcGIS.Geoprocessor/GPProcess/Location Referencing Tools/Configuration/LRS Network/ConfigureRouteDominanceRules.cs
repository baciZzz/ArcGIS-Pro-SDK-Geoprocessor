using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.LocationReferencingTools
{
	/// <summary>
	/// <para>Configure Route Dominance Rules</para>
	/// <para>Configure Route Dominance Rules</para>
	/// <para>Configures a set of rules to determine the dominant route in a</para>
	/// <para>network where there are concurrent routes.</para>
	/// </summary>
	public class ConfigureRouteDominanceRules : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>LRS Network Feature Class</para>
		/// <para>The input feature class. Only a registered LRS Network feature class can be used.</para>
		/// </param>
		/// <param name="ConfigureType">
		/// <para>Configure Type</para>
		/// <para>Specifies the type of configuration that will be applied to the LRS Network Feature Class parameter value.</para>
		/// <para>Add—A new rule will be added to the configuration.</para>
		/// <para>Update—An existing rule will be updated.</para>
		/// <para>Delete—An existing rule will be deleted.</para>
		/// <para><see cref="ConfigureTypeEnum"/></para>
		/// </param>
		/// <param name="RuleName">
		/// <para>Rule Name</para>
		/// <para>The name of the rule that will be added, updated, or deleted. The rule name can be up to 30 characters.</para>
		/// </param>
		public ConfigureRouteDominanceRules(object InFeatureClass, object ConfigureType, object RuleName)
		{
			this.InFeatureClass = InFeatureClass;
			this.ConfigureType = ConfigureType;
			this.RuleName = RuleName;
		}

		/// <summary>
		/// <para>Tool Display Name : Configure Route Dominance Rules</para>
		/// </summary>
		public override string DisplayName() => "Configure Route Dominance Rules";

		/// <summary>
		/// <para>Tool Name : ConfigureRouteDominanceRules</para>
		/// </summary>
		public override string ToolName() => "ConfigureRouteDominanceRules";

		/// <summary>
		/// <para>Tool Excute Name : locref.ConfigureRouteDominanceRules</para>
		/// </summary>
		public override string ExcuteName() => "locref.ConfigureRouteDominanceRules";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise() => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureClass, ConfigureType, RuleName, UpdatedRuleName!, SourceTableName!, Fields!, OrderMethod!, OrderType!, PrioritizedExceptions!, OutFeatureClass! };

		/// <summary>
		/// <para>LRS Network Feature Class</para>
		/// <para>The input feature class. Only a registered LRS Network feature class can be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Configure Type</para>
		/// <para>Specifies the type of configuration that will be applied to the LRS Network Feature Class parameter value.</para>
		/// <para>Add—A new rule will be added to the configuration.</para>
		/// <para>Update—An existing rule will be updated.</para>
		/// <para>Delete—An existing rule will be deleted.</para>
		/// <para><see cref="ConfigureTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConfigureType { get; set; }

		/// <summary>
		/// <para>Rule Name</para>
		/// <para>The name of the rule that will be added, updated, or deleted. The rule name can be up to 30 characters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RuleName { get; set; }

		/// <summary>
		/// <para>Updated Rule Name</para>
		/// <para>The updated name of the rule. This parameter is only used when Update is specified as the Configure Type parameter value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? UpdatedRuleName { get; set; }

		/// <summary>
		/// <para>Source Table Name</para>
		/// <para>The source event table or feature class registered to the LRS Network Feature Class parameter value. Alternatively, the network feature class can be used. Only nonspanning line events are supported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SourceTableName { get; set; }

		/// <summary>
		/// <para>Fields</para>
		/// <para>The attribute field aliases in the source table. If multiple fields are used, they will be concatenated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Fields { get; set; }

		/// <summary>
		/// <para>Order Method</para>
		/// <para>Specifies whether route dominance ordering will be determined by lesser or greater values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? OrderMethod { get; set; }

		/// <summary>
		/// <para>Order Type</para>
		/// <para>Specifies the ordering type that will be used when evaluating numeric or alphanumeric strings.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? OrderType { get; set; }

		/// <summary>
		/// <para>Prioritized Exceptions</para>
		/// <para>A comma-separated list of user-provided exceptions.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? PrioritizedExceptions { get; set; }

		/// <summary>
		/// <para>Output Network Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Configure Type</para>
		/// </summary>
		public enum ConfigureTypeEnum 
		{
			/// <summary>
			/// <para>Add—A new rule will be added to the configuration.</para>
			/// </summary>
			[GPValue("ADD")]
			[Description("Add")]
			Add,

			/// <summary>
			/// <para>Update—An existing rule will be updated.</para>
			/// </summary>
			[GPValue("UPDATE")]
			[Description("Update")]
			Update,

			/// <summary>
			/// <para>Delete—An existing rule will be deleted.</para>
			/// </summary>
			[GPValue("DELETE")]
			[Description("Delete")]
			Delete,

		}

#endregion
	}
}
