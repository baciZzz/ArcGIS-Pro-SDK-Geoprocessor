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
	/// <para>Append Routes</para>
	/// <para>Appends routes from an input polyline into an LRS Network.</para>
	/// </summary>
	public class AppendRoutes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="SourceRoutes">
		/// <para>Source Routes</para>
		/// <para>The input from which the routes will be derived. The input can be a polyline feature class, shapefile, feature service, or LRS Network feature class.</para>
		/// </param>
		/// <param name="InLrsNetwork">
		/// <para>LRS Network</para>
		/// <para>The target LRS Network into which the routes will be loaded.</para>
		/// </param>
		/// <param name="RouteIdField">
		/// <para>Route ID Field</para>
		/// <para>The field in the input polyline feature class that will be mapped to the LRS Network route ID. The field type must match the RouteID field type of the target LRS Network and must be either a string or GUID field type. If it is a text field, the field length must be shorter than or equal to the length of the target RouteID field.</para>
		/// </param>
		public AppendRoutes(object SourceRoutes, object InLrsNetwork, object RouteIdField)
		{
			this.SourceRoutes = SourceRoutes;
			this.InLrsNetwork = InLrsNetwork;
			this.RouteIdField = RouteIdField;
		}

		/// <summary>
		/// <para>Tool Display Name : Append Routes</para>
		/// </summary>
		public override string DisplayName => "Append Routes";

		/// <summary>
		/// <para>Tool Name : AppendRoutes</para>
		/// </summary>
		public override string ToolName => "AppendRoutes";

		/// <summary>
		/// <para>Tool Excute Name : locref.AppendRoutes</para>
		/// </summary>
		public override string ExcuteName => "locref.AppendRoutes";

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
		public override object[] Parameters => new object[] { SourceRoutes, InLrsNetwork, RouteIdField, RouteNameField, FromDateField, ToDateField, LineIdField, LineNameField, LineOrderField, FieldMap, LoadType, OutLrsNetwork, OutDetailsFile };

		/// <summary>
		/// <para>Source Routes</para>
		/// <para>The input from which the routes will be derived. The input can be a polyline feature class, shapefile, feature service, or LRS Network feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object SourceRoutes { get; set; }

		/// <summary>
		/// <para>LRS Network</para>
		/// <para>The target LRS Network into which the routes will be loaded.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InLrsNetwork { get; set; }

		/// <summary>
		/// <para>Route ID Field</para>
		/// <para>The field in the input polyline feature class that will be mapped to the LRS Network route ID. The field type must match the RouteID field type of the target LRS Network and must be either a string or GUID field type. If it is a text field, the field length must be shorter than or equal to the length of the target RouteID field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object RouteIdField { get; set; }

		/// <summary>
		/// <para>Route Name Field</para>
		/// <para>The field in the input polyline feature class that will be mapped as the LRS Network route name. The field must be a string field, and the field length must be shorter than or equal to the length of the target route name field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object RouteNameField { get; set; }

		/// <summary>
		/// <para>From Date Field</para>
		/// <para>A date field in the input polyline feature class that will be mapped as the From Date Field in the LRS Network . If the field is not mapped, a null value representing the beginning of time will be provided for all appended routes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object FromDateField { get; set; }

		/// <summary>
		/// <para>To Date Field</para>
		/// <para>A date field in the input polyline feature class that will be mapped as the To date in the LRS Network. If a To date field is not mapped, a null value representing the end of time will be provided for all appended routes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object ToDateField { get; set; }

		/// <summary>
		/// <para>Line ID Field</para>
		/// <para>The field in the input polyline feature class that will be mapped as the LRS Network line ID. This parameter is only used if the target is an LRS line network. The field type must match the RouteID field type of the centerline sequence table and must be either a string of exactly 38 characters or a GUID field type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object LineIdField { get; set; }

		/// <summary>
		/// <para>Line Name Field</para>
		/// <para>The string field in the input polyline feature class that will be mapped as the LRS Network line name. This parameter is only used if the target is an LRS line network.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object LineNameField { get; set; }

		/// <summary>
		/// <para>Line Order Field</para>
		/// <para>The long integer field in the input polyline feature class that will be mapped as the LRS Network line order. This parameter is only used if the target is an LRS line network.</para>
		/// <para>Learn more about line networks and line order in Pipeline Referencing or line networks and line order in Roads and Highways.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long")]
		public object LineOrderField { get; set; }

		/// <summary>
		/// <para>Field Map</para>
		/// <para>Controls how attribute information in the source route fields is transferred to the input LRS Network. Fields cannot be added to or removed from the target LRS Network because the data of the source routes is appended to an existing LRS Network that has a predefined schema. While you can set merge rules for each output field, the tool will ignore those rules.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFieldMapping()]
		public object FieldMap { get; set; }

		/// <summary>
		/// <para>Load Type</para>
		/// <para>Specifies how appended routes with measure or temporality overlaps with identical route IDs as Target Network records are loaded into the network feature class.</para>
		/// <para>Add—The appended routes are loaded into the target LRS Network. If any route ID in the source routes already exists in the target LRS Network with the same temporality, it will be written to the output log as a duplicate route and must be corrected or filtered out before completing the loading process. This is the default.</para>
		/// <para>Retire by route ID—The appended routes are loaded into the target LRS Network and any routes in the target LRS Network that have the same route ID and temporality overlap as the appended routes are retired. If the appended route eclipses a target route with the same route ID, the target route is deleted.</para>
		/// <para>Replace by route ID—The appended routes are loaded into the target LRS Network and any routes in the target LRS Network with the same route ID as the appended routes are deleted.</para>
		/// <para><see cref="LoadTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LoadType { get; set; } = "ADD";

		/// <summary>
		/// <para>LRS Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutLrsNetwork { get; set; }

		/// <summary>
		/// <para>Output Results File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETextFile()]
		public object OutDetailsFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AppendRoutes SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Load Type</para>
		/// </summary>
		public enum LoadTypeEnum 
		{
			/// <summary>
			/// <para>Add—The appended routes are loaded into the target LRS Network. If any route ID in the source routes already exists in the target LRS Network with the same temporality, it will be written to the output log as a duplicate route and must be corrected or filtered out before completing the loading process. This is the default.</para>
			/// </summary>
			[GPValue("ADD")]
			[Description("Add")]
			Add,

			/// <summary>
			/// <para>Retire by route ID—The appended routes are loaded into the target LRS Network and any routes in the target LRS Network that have the same route ID and temporality overlap as the appended routes are retired. If the appended route eclipses a target route with the same route ID, the target route is deleted.</para>
			/// </summary>
			[GPValue("RETIRE_BY_ROUTE_ID")]
			[Description("Retire by route ID")]
			Retire_by_route_ID,

			/// <summary>
			/// <para>Replace by route ID—The appended routes are loaded into the target LRS Network and any routes in the target LRS Network with the same route ID as the appended routes are deleted.</para>
			/// </summary>
			[GPValue("REPLACE_BY_ROUTE_ID")]
			[Description("Replace by route ID")]
			Replace_by_route_ID,

		}

#endregion
	}
}
