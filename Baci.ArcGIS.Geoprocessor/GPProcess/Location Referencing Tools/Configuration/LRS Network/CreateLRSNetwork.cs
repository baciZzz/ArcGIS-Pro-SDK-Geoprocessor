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
	/// <para>Create LRS Network</para>
	/// <para>Creates an LRS Network in an ArcGIS Location Referencing linear referencing system (LRS).</para>
	/// </summary>
	public class CreateLRSNetwork : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPath">
		/// <para>Input Location</para>
		/// <para>The input workspace that will contain the new LRS Network. This workspace must be a geodatabase that contains a Location Referencing LRS. In addition to the top level of a geodatabase, a feature dataset is also supported as a valid path.</para>
		/// </param>
		/// <param name="LrsName">
		/// <para>LRS Name</para>
		/// <para>The LRS to which the new LRS Network will be registered. The LRS must reside in the same geodatabase as the Input Location parameter value.</para>
		/// </param>
		/// <param name="NetworkName">
		/// <para>LRS Network Name</para>
		/// <para>The name of the LRS Network that will be created, as well as the name of the feature class that will be created and registered with the LRS Network. The LRS Network name must be 26 or fewer characters and cannot contain special characters other than underscores.</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route ID Field</para>
		/// <para>The field in the output feature class that will be mapped as the LRS Network route ID. The field type is derived from the RouteId field of the centerline sequence table and must be either string or GUID type.</para>
		/// </param>
		/// <param name="RouteNameField">
		/// <para>Route Name Field</para>
		/// <para>A string field in the output feature class that will be mapped as the LRS Network route name.</para>
		/// </param>
		/// <param name="FromDateField">
		/// <para>From Date Field</para>
		/// <para>A date field in the output feature class that will be mapped as the LRS Network from date.</para>
		/// </param>
		/// <param name="ToDateField">
		/// <para>To Date Field</para>
		/// <para>A date field in the output feature class that will be mapped as the LRS Network to date.</para>
		/// </param>
		public CreateLRSNetwork(object InPath, object LrsName, object NetworkName, object RouteIdField, object RouteNameField, object FromDateField, object ToDateField)
		{
			this.InPath = InPath;
			this.LrsName = LrsName;
			this.NetworkName = NetworkName;
			this.RouteIdField = RouteIdField;
			this.RouteNameField = RouteNameField;
			this.FromDateField = FromDateField;
			this.ToDateField = ToDateField;
		}

		/// <summary>
		/// <para>Tool Display Name : Create LRS Network</para>
		/// </summary>
		public override string DisplayName => "Create LRS Network";

		/// <summary>
		/// <para>Tool Name : CreateLRSNetwork</para>
		/// </summary>
		public override string ToolName => "CreateLRSNetwork";

		/// <summary>
		/// <para>Tool Excute Name : locref.CreateLRSNetwork</para>
		/// </summary>
		public override string ExcuteName => "locref.CreateLRSNetwork";

		/// <summary>
		/// <para>Toolbox Display Name : Location Referencing Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Location Referencing Tools";

		/// <summary>
		/// <para>Toolbox Alise : locref</para>
		/// </summary>
		public override string ToolboxAlise => "locref";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InPath, LrsName, NetworkName, RouteIdField, RouteNameField, FromDateField, ToDateField, DeriveFromLineNetwork!, LineNetworkName!, IncludeFieldsToSupportLines!, LineIdField!, LineNameField!, LineOrderField!, MeasureUnit!, OutFeatureClass! };

		/// <summary>
		/// <para>Input Location</para>
		/// <para>The input workspace that will contain the new LRS Network. This workspace must be a geodatabase that contains a Location Referencing LRS. In addition to the top level of a geodatabase, a feature dataset is also supported as a valid path.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InPath { get; set; }

		/// <summary>
		/// <para>LRS Name</para>
		/// <para>The LRS to which the new LRS Network will be registered. The LRS must reside in the same geodatabase as the Input Location parameter value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LrsName { get; set; }

		/// <summary>
		/// <para>LRS Network Name</para>
		/// <para>The name of the LRS Network that will be created, as well as the name of the feature class that will be created and registered with the LRS Network. The LRS Network name must be 26 or fewer characters and cannot contain special characters other than underscores.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object NetworkName { get; set; }

		/// <summary>
		/// <para>Route ID Field</para>
		/// <para>The field in the output feature class that will be mapped as the LRS Network route ID. The field type is derived from the RouteId field of the centerline sequence table and must be either string or GUID type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object RouteIdField { get; set; } = "RouteId";

		/// <summary>
		/// <para>Route Name Field</para>
		/// <para>A string field in the output feature class that will be mapped as the LRS Network route name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object RouteNameField { get; set; } = "RouteName";

		/// <summary>
		/// <para>From Date Field</para>
		/// <para>A date field in the output feature class that will be mapped as the LRS Network from date.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object FromDateField { get; set; } = "FromDate";

		/// <summary>
		/// <para>To Date Field</para>
		/// <para>A date field in the output feature class that will be mapped as the LRS Network to date.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ToDateField { get; set; } = "ToDate";

		/// <summary>
		/// <para>Derive From Line Network</para>
		/// <para>Specifies whether the network will be configured as an LRS derived network.</para>
		/// <para>Checked—The output will be an LRS derived network and a feature class to support the LRS derived network. The Line Network Name parameter value must also be provided.</para>
		/// <para>Unchecked—The output will not be an LRS derived network. This is the default.</para>
		/// <para><see cref="DeriveFromLineNetworkEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DeriveFromLineNetwork { get; set; } = "false";

		/// <summary>
		/// <para>Line Network Name</para>
		/// <para>The name of the LRS line network to which the output LRS derived network will be registered. The input LRS line network must reside in the same geodatabase workspace as the Line Network Name value. This parameter is only used if the Derive From Line Network parameter is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LineNetworkName { get; set; }

		/// <summary>
		/// <para>Include Fields to Support Lines</para>
		/// <para>Specifies whether fields that support lines will be added.</para>
		/// <para>Checked—The output will be an LRS line network, and the output feature class will include fields that support lines. The Line ID Field, Line Name Field, and Line Order Field parameter values must also be provided.</para>
		/// <para>Unchecked—The output will not be an LRS line network. This is the default.</para>
		/// <para><see cref="IncludeFieldsToSupportLinesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeFieldsToSupportLines { get; set; } = "false";

		/// <summary>
		/// <para>Line ID Field</para>
		/// <para>The field in the output feature class that will be mapped as the LRS Network line ID. This parameter is only used if the Include Fields to Support Lines parameter is checked. The field type is derived from the RouteId field of the centerline sequence table and will either be a string of exactly 38 characters or a GUID field type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? LineIdField { get; set; } = "LineId";

		/// <summary>
		/// <para>Line Name Field</para>
		/// <para>A string field in the output feature class that will be mapped as the LRS Network line name. This parameter is only used if the Include Fields to Support Lines parameter is checked.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? LineNameField { get; set; } = "LineName";

		/// <summary>
		/// <para>Line Order Field</para>
		/// <para>The field in the output feature class that will be mapped as the LRS Network line order. This parameter is only used if the Include Fields to Support Lines parameter is checked. This will be a long integer field type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? LineOrderField { get; set; } = "LineOrder";

		/// <summary>
		/// <para>Measure Unit</para>
		/// <para>Specifies the unit of measure (m-unit) the LRS Network will use.</para>
		/// <para>Miles (US Survey)—The unit of measure will be miles. This is the default.</para>
		/// <para>Inches (US Survey)—The unit of measure will be inches.</para>
		/// <para>Feet (US Survey)—The unit of measure will be feet.</para>
		/// <para>Yards (US Survey)—The unit of measure will be yards.</para>
		/// <para>Nautical miles (US Survey)—The unit of measure will be nautical miles.</para>
		/// <para>Feet (International)—The unit of measure will be international feet.</para>
		/// <para>Millimeters—The unit of measure will be millimeters.</para>
		/// <para>Centimeters—The unit of measure will be centimeters</para>
		/// <para>Meters—The unit of measure will be meters.</para>
		/// <para>Kilometers—The unit of measure will be kilometers.</para>
		/// <para>Decimeters—The unit of measure will be decimeters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? MeasureUnit { get; set; } = "MILES";

		/// <summary>
		/// <para>Output Network Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateLRSNetwork SetEnviroment(object? workspace = null )
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
			/// <para>Checked—The output will be an LRS derived network and a feature class to support the LRS derived network. The Line Network Name parameter value must also be provided.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DERIVE")]
			DERIVE,

			/// <summary>
			/// <para>Unchecked—The output will not be an LRS derived network. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_DERIVE")]
			DO_NOT_DERIVE,

		}

		/// <summary>
		/// <para>Include Fields to Support Lines</para>
		/// </summary>
		public enum IncludeFieldsToSupportLinesEnum 
		{
			/// <summary>
			/// <para>Checked—The output will be an LRS line network, and the output feature class will include fields that support lines. The Line ID Field, Line Name Field, and Line Order Field parameter values must also be provided.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE")]
			INCLUDE,

			/// <summary>
			/// <para>Unchecked—The output will not be an LRS line network. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_INCLUDE")]
			DO_NOT_INCLUDE,

		}

#endregion
	}
}
