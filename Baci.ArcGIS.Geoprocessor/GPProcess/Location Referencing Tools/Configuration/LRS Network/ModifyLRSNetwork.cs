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
	/// <para>Modify LRS Network</para>
	/// <para>Modify LRS Network</para>
	/// <para>Modifies an LRS Network in a Location Referencing linear referencing system (LRS).</para>
	/// </summary>
	public class ModifyLRSNetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>LRS Network Feature Class</para>
		/// <para>The input LRS Network feature class to be modified.</para>
		/// </param>
		public ModifyLRSNetwork(object InFeatureClass)
		{
			this.InFeatureClass = InFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Modify LRS Network</para>
		/// </summary>
		public override string DisplayName() => "Modify LRS Network";

		/// <summary>
		/// <para>Tool Name : ModifyLRSNetwork</para>
		/// </summary>
		public override string ToolName() => "ModifyLRSNetwork";

		/// <summary>
		/// <para>Tool Excute Name : locref.ModifyLRSNetwork</para>
		/// </summary>
		public override string ExcuteName() => "locref.ModifyLRSNetwork";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureClass, RouteIdField!, RouteNameField!, FromDateField!, ToDateField!, DeriveFromLineNetwork!, LineNetworkName!, IncludeFieldsToSupportLines!, LineIdField!, LineNameField!, LineOrderField!, OutFeatureClass!, RouteIdConfiguration!, IndividualRouteIdFields! };

		/// <summary>
		/// <para>LRS Network Feature Class</para>
		/// <para>The input LRS Network feature class to be modified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Route ID Field</para>
		/// <para>The field in the input feature class that will be mapped as the LRS Network route ID. The field type must match the RouteId field type of the Centerline_Sequence table and must either be a string or GUID field type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? RouteIdField { get; set; }

		/// <summary>
		/// <para>Route Name Field</para>
		/// <para>A string field in the input feature class that will be mapped as the LRS Network route name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? RouteNameField { get; set; }

		/// <summary>
		/// <para>From Date Field</para>
		/// <para>A date field in the input feature class that will be mapped as the LRS Network from date.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? FromDateField { get; set; }

		/// <summary>
		/// <para>To Date Field</para>
		/// <para>A date field in the input feature class that will be mapped as the LRS Network to date.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object? ToDateField { get; set; }

		/// <summary>
		/// <para>Derive From Line Network</para>
		/// <para>Determines if the current LRS network will be configured as an LRS Derived Network.</para>
		/// <para>As is—The current LRS Network derived property will not be changed. This is the default.</para>
		/// <para>Derive—The input LRS Derived Network will be modified to become an LRS Derived Network. The line network name parameter must also be provided to specify which LRS Network to derive from.</para>
		/// <para>Do not derive—The input LRS Derived Network will be modified to no longer be an LRS Derived Network.</para>
		/// <para><see cref="DeriveFromLineNetworkEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DeriveFromLineNetwork { get; set; } = "AS_IS";

		/// <summary>
		/// <para>Line Network Name</para>
		/// <para>The name of the LRS Line Network to which the input LRS Derived Network will be registered. The input LRS Line Network must reside in the same geodatabase workspace and LRS as the LRS network feature class. This parameter is only used if the Derive From Line Network parameter is set to Derive.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LineNetworkName { get; set; }

		/// <summary>
		/// <para>Include Fields to Support Lines</para>
		/// <para>Determines if the current LRS network will be configured to support lines.</para>
		/// <para>As is—The current LRS Network line support property will not be changed. This is the default.</para>
		/// <para>Include—The input LRS Network will be modified to add support for lines. The line id field, line name field, and line order field parameters must also be provided, and valid fields to map to these parameters must exist in the LRS network feature class.</para>
		/// <para>Do not include—The input LRS Network will be modified to remove support for lines.</para>
		/// <para><see cref="IncludeFieldsToSupportLinesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? IncludeFieldsToSupportLines { get; set; } = "AS_IS";

		/// <summary>
		/// <para>Line ID Field</para>
		/// <para>The field in the input feature class that will be mapped as the LRS Network line ID. This parameter is only used if the Include Fields to Support Lines parameter is set to Include. The field type must match the RouteId field type of the Centerline_Sequence table and must either be a string of exactly 38 characters or a GUID field type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? LineIdField { get; set; }

		/// <summary>
		/// <para>Line Name Field</para>
		/// <para>A string field in the input feature class that will be mapped as the LRS Network line name. This parameter is only used if the Include Fields to Support Lines parameter is set to Include.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object? LineNameField { get; set; }

		/// <summary>
		/// <para>Line Order Field</para>
		/// <para>The field in the input feature class that will be mapped as the LRS Network line order. This parameter is only used if the Include Fields to Support Lines parameter is set to Include. This must be a long integer field type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long")]
		public object? LineOrderField { get; set; }

		/// <summary>
		/// <para>Output Network Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Route ID Field Configuration</para>
		/// <para>Determines the route ID configuration for an LRS Network.</para>
		/// <para>As is—The current LRS Network route ID configuration will not be changed. This is the default.</para>
		/// <para>Autogenerated Route ID—The route ID field will be an autogenerated GUID, and the route name can be configured as an LRS field.</para>
		/// <para>Single-Field Route ID—Supported only for nonline networks.</para>
		/// <para>Multi-Field Route ID—Supported only for nonline networks. More than one field is needed to form the concatenated route ID.</para>
		/// <para><see cref="RouteIdConfigurationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? RouteIdConfiguration { get; set; } = "AS_IS";

		/// <summary>
		/// <para>Field(s)</para>
		/// <para>The individual fields in the LRS Network Feature Class that will be used to form the route ID. This parameter is only used if the Route ID Field Configuration parameter's Multi-Field Route ID option is set. The fields must be either string or number integer field types.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object? IndividualRouteIdFields { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ModifyLRSNetwork SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Derive From Line Network</para>
		/// </summary>
		public enum DeriveFromLineNetworkEnum 
		{
			/// <summary>
			/// <para>As is—The current LRS Network derived property will not be changed. This is the default.</para>
			/// </summary>
			[GPValue("AS_IS")]
			[Description("As is")]
			As_is,

			/// <summary>
			/// <para>Do not derive—The input LRS Derived Network will be modified to no longer be an LRS Derived Network.</para>
			/// </summary>
			[GPValue("DO_NOT_DERIVE")]
			[Description("Do not derive")]
			Do_not_derive,

			/// <summary>
			/// <para>Derive From Line Network</para>
			/// </summary>
			[GPValue("DERIVE")]
			[Description("Derive")]
			Derive,

		}

		/// <summary>
		/// <para>Include Fields to Support Lines</para>
		/// </summary>
		public enum IncludeFieldsToSupportLinesEnum 
		{
			/// <summary>
			/// <para>As is—The current LRS Network line support property will not be changed. This is the default.</para>
			/// </summary>
			[GPValue("AS_IS")]
			[Description("As is")]
			As_is,

			/// <summary>
			/// <para>Do not include—The input LRS Network will be modified to remove support for lines.</para>
			/// </summary>
			[GPValue("DO_NOT_INCLUDE")]
			[Description("Do not include")]
			Do_not_include,

			/// <summary>
			/// <para>Include Fields to Support Lines</para>
			/// </summary>
			[GPValue("INCLUDE")]
			[Description("Include")]
			Include,

		}

		/// <summary>
		/// <para>Route ID Field Configuration</para>
		/// </summary>
		public enum RouteIdConfigurationEnum 
		{
			/// <summary>
			/// <para>As is—The current LRS Network route ID configuration will not be changed. This is the default.</para>
			/// </summary>
			[GPValue("AS_IS")]
			[Description("As is")]
			As_is,

			/// <summary>
			/// <para>Autogenerated Route ID—The route ID field will be an autogenerated GUID, and the route name can be configured as an LRS field.</para>
			/// </summary>
			[GPValue("AUTOGENERATED_ROUTE_ID")]
			[Description("Autogenerated Route ID")]
			Autogenerated_Route_ID,

			/// <summary>
			/// <para>Single-Field Route ID—Supported only for nonline networks.</para>
			/// </summary>
			[GPValue("SINGLE_FIELD_ROUTE_ID")]
			[Description("Single-Field Route ID")]
			SINGLE_FIELD_ROUTE_ID,

			/// <summary>
			/// <para>Multi-Field Route ID—Supported only for nonline networks. More than one field is needed to form the concatenated route ID.</para>
			/// </summary>
			[GPValue("MULTI_FIELD_ROUTE_ID")]
			[Description("Multi-Field Route ID")]
			MULTI_FIELD_ROUTE_ID,

		}

#endregion
	}
}
