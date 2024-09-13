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
	/// <para>Create LRS Network From Existing Dataset</para>
	/// <para>Create LRS Network From Existing Dataset</para>
	/// <para>Creates an LRS Network using an existing polyline feature class.</para>
	/// </summary>
	public class CreateLRSNetworkFromExistingDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>LRS Network Feature Class</para>
		/// <para>The input feature class that will be registered as the LRS Network. The name of the feature class must be 26 or fewer characters. The feature class must reside in a geodatabase that contains a Pipeline Referencing LRS. The name of this feature class will be used as the name of the LRS Network.</para>
		/// </param>
		/// <param name="LrsName">
		/// <para>LRS Name</para>
		/// <para>The LRS name to which the new LRS Network will be registered. The LRS must reside in the same geodatabase as the LRS Network Feature Class.</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route ID Field</para>
		/// <para>The field in the LRS Network Feature Class that will be mapped as the LRS Network route ID. This must be a string or GUID field type.</para>
		/// </param>
		/// <param name="FromDateField">
		/// <para>From Date Field</para>
		/// <para>A date field in the LRS Network Feature Class that will be mapped as the LRS Network from date.</para>
		/// </param>
		/// <param name="ToDateField">
		/// <para>To Date Field</para>
		/// <para>A date field in the LRS Network Feature Class that will be mapped as the LRS Network to date.</para>
		/// </param>
		public CreateLRSNetworkFromExistingDataset(object InFeatureClass, object LrsName, object RouteIdField, object FromDateField, object ToDateField)
		{
			this.InFeatureClass = InFeatureClass;
			this.LrsName = LrsName;
			this.RouteIdField = RouteIdField;
			this.FromDateField = FromDateField;
			this.ToDateField = ToDateField;
		}

		/// <summary>
		/// <para>Tool Display Name : Create LRS Network From Existing Dataset</para>
		/// </summary>
		public override string DisplayName() => "Create LRS Network From Existing Dataset";

		/// <summary>
		/// <para>Tool Name : CreateLRSNetworkFromExistingDataset</para>
		/// </summary>
		public override string ToolName() => "CreateLRSNetworkFromExistingDataset";

		/// <summary>
		/// <para>Tool Excute Name : locref.CreateLRSNetworkFromExistingDataset</para>
		/// </summary>
		public override string ExcuteName() => "locref.CreateLRSNetworkFromExistingDataset";

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
		public override object[] Parameters() => new object[] { InFeatureClass, LrsName, RouteIdField, RouteNameField, FromDateField, ToDateField, DeriveFromLineNetwork, LineNetworkName, IncludeFieldsToSupportLines, LineIdField, LineNameField, LineOrderField, OutFeatureClass, RouteIdConfiguration, IndividualRouteIdFields };

		/// <summary>
		/// <para>LRS Network Feature Class</para>
		/// <para>The input feature class that will be registered as the LRS Network. The name of the feature class must be 26 or fewer characters. The feature class must reside in a geodatabase that contains a Pipeline Referencing LRS. The name of this feature class will be used as the name of the LRS Network.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>LRS Name</para>
		/// <para>The LRS name to which the new LRS Network will be registered. The LRS must reside in the same geodatabase as the LRS Network Feature Class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LrsName { get; set; }

		/// <summary>
		/// <para>Route ID Field</para>
		/// <para>The field in the LRS Network Feature Class that will be mapped as the LRS Network route ID. This must be a string or GUID field type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object RouteIdField { get; set; }

		/// <summary>
		/// <para>Route Name Field</para>
		/// <para>A string field in the LRS Network Feature Class that will be mapped as the LRS Network route name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object RouteNameField { get; set; }

		/// <summary>
		/// <para>From Date Field</para>
		/// <para>A date field in the LRS Network Feature Class that will be mapped as the LRS Network from date.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object FromDateField { get; set; }

		/// <summary>
		/// <para>To Date Field</para>
		/// <para>A date field in the LRS Network Feature Class that will be mapped as the LRS Network to date.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object ToDateField { get; set; }

		/// <summary>
		/// <para>Derive From Line Network</para>
		/// <para>Specifies whether the network will be configured as an LRS derived network.</para>
		/// <para>Checked—The output of this tool will be an LRS derived network. The Line Network Name parameter must also be provided.</para>
		/// <para>Unchecked—The output of this tool will not be an LRS derived network. This is the default.</para>
		/// <para><see cref="DeriveFromLineNetworkEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object DeriveFromLineNetwork { get; set; } = "false";

		/// <summary>
		/// <para>Line Network Name</para>
		/// <para>The name of the LRS line network to which the output LRS derived network will be registered. The input LRS line network must reside in the same geodatabase workspace as the LRS Network Feature Class. This parameter is only used if the Derive From Line Network parameter is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LineNetworkName { get; set; }

		/// <summary>
		/// <para>Include Fields to Support Lines</para>
		/// <para>Specifies whether the network will be configured to support lines.</para>
		/// <para>Checked—The output of this tool will be an LRS line network. The Line ID Field, Line Name Field, and Line Order Field parameters must also be provided.</para>
		/// <para>Unchecked—The output of this tool will not be an LRS line network. This is the default.</para>
		/// <para><see cref="IncludeFieldsToSupportLinesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeFieldsToSupportLines { get; set; } = "false";

		/// <summary>
		/// <para>Line ID Field</para>
		/// <para>The field in the LRS Network Feature Class that will be mapped as the LRS Network line ID. This parameter is only used if the Include Fields to Support Lines parameter is checked. This must be a string or GUID field type and must match the field type and length of the route ID field in the centerline sequence table. The Line ID Field parameter input must also be the same field type as the Route ID Field parameter input.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object LineIdField { get; set; }

		/// <summary>
		/// <para>Line Name Field</para>
		/// <para>A string field in the LRS Network Feature Class that will be mapped as the LRS Network line name. This parameter is only used if the Include Fields to Support Lines parameter is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object LineNameField { get; set; }

		/// <summary>
		/// <para>Line Order Field</para>
		/// <para>An integer field in the LRS Network Feature Class that will be mapped as the LRS Network line order. This parameter is only used if the Include Fields to Support Lines parameter is checked. This must be a long integer field type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long")]
		public object LineOrderField { get; set; }

		/// <summary>
		/// <para>Output Network Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Route ID Field Configuration</para>
		/// <para>Specifies the route ID configuration for the LRS Network.</para>
		/// <para>Autogenerated Route ID—The route ID field will be an automatically generated GUID. The route name can be configured as an LRS field. This is the default.</para>
		/// <para>Single-Field Route ID—The route ID field will be a single user-generated field. Only nonline networks are supported.</para>
		/// <para>Multi-Field Route ID—The route ID field will be a user-generated field concatenated from more than one field to form the route ID. Only nonline networks are supported.</para>
		/// <para><see cref="RouteIdConfigurationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RouteIdConfiguration { get; set; } = "AUTOGENERATED_ROUTE_ID";

		/// <summary>
		/// <para>Field(s)</para>
		/// <para>The individual fields in the LRS Network Feature Class that will be used to form the route ID. This parameter is only used if the Route ID Field Configuration parameter is set to Multi-Field Route ID. The fields must be either string or integer field types.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object IndividualRouteIdFields { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateLRSNetworkFromExistingDataset SetEnviroment(object workspace = null )
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
			/// <para>Unchecked—The output of this tool will not be an LRS derived network. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_DERIVE")]
			DO_NOT_DERIVE,

			/// <summary>
			/// <para>Checked—The output of this tool will be an LRS derived network. The Line Network Name parameter must also be provided.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DERIVE")]
			DERIVE,

		}

		/// <summary>
		/// <para>Include Fields to Support Lines</para>
		/// </summary>
		public enum IncludeFieldsToSupportLinesEnum 
		{
			/// <summary>
			/// <para>Unchecked—The output of this tool will not be an LRS line network. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_INCLUDE")]
			DO_NOT_INCLUDE,

			/// <summary>
			/// <para>Checked—The output of this tool will be an LRS line network. The Line ID Field, Line Name Field, and Line Order Field parameters must also be provided.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE")]
			INCLUDE,

		}

		/// <summary>
		/// <para>Route ID Field Configuration</para>
		/// </summary>
		public enum RouteIdConfigurationEnum 
		{
			/// <summary>
			/// <para>Autogenerated Route ID—The route ID field will be an automatically generated GUID. The route name can be configured as an LRS field. This is the default.</para>
			/// </summary>
			[GPValue("AUTOGENERATED_ROUTE_ID")]
			[Description("Autogenerated Route ID")]
			Autogenerated_Route_ID,

			/// <summary>
			/// <para>Single-Field Route ID—The route ID field will be a single user-generated field. Only nonline networks are supported.</para>
			/// </summary>
			[GPValue("SINGLE_FIELD_ROUTE_ID")]
			[Description("Single-Field Route ID")]
			SINGLE_FIELD_ROUTE_ID,

			/// <summary>
			/// <para>Multi-Field Route ID—The route ID field will be a user-generated field concatenated from more than one field to form the route ID. Only nonline networks are supported.</para>
			/// </summary>
			[GPValue("MULTI_FIELD_ROUTE_ID")]
			[Description("Multi-Field Route ID")]
			MULTI_FIELD_ROUTE_ID,

		}

#endregion
	}
}
