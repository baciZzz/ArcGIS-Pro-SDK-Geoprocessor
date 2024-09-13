using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.BusinessAnalystTools
{
	/// <summary>
	/// <para>Assign Customers By Distance</para>
	/// <para>Assign Customers By Distance</para>
	/// <para>Assigns customers to the closest store based on a selected distance type.</para>
	/// </summary>
	public class AssignCustomersByDistance : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Customer Features</para>
		/// <para>The input point feature layer representing customers.</para>
		/// </param>
		/// <param name="InStoreFeatures">
		/// <para>Input Store Features</para>
		/// <para>The input point feature layer representing store or facilities.</para>
		/// </param>
		/// <param name="StoreIdField">
		/// <para>Store ID Field</para>
		/// <para>A unique ID field for Input Store Features.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>A point layer containing customers with assigned store or facility and distance.</para>
		/// </param>
		public AssignCustomersByDistance(object InFeatures, object InStoreFeatures, object StoreIdField, object OutFeatureClass)
		{
			this.InFeatures = InFeatures;
			this.InStoreFeatures = InStoreFeatures;
			this.StoreIdField = StoreIdField;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Assign Customers By Distance</para>
		/// </summary>
		public override string DisplayName() => "Assign Customers By Distance";

		/// <summary>
		/// <para>Tool Name : AssignCustomersByDistance</para>
		/// </summary>
		public override string ToolName() => "AssignCustomersByDistance";

		/// <summary>
		/// <para>Tool Excute Name : ba.AssignCustomersByDistance</para>
		/// </summary>
		public override string ExcuteName() => "ba.AssignCustomersByDistance";

		/// <summary>
		/// <para>Toolbox Display Name : Business Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Business Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ba</para>
		/// </summary>
		public override string ToolboxAlise() => "ba";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "baDataSource", "baNetworkSource", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, InStoreFeatures, StoreIdField, OutFeatureClass, LinkField, DistanceType, DistanceUnits, TravelDirection, TimeOfDay, TimeZone, SearchTolerance };

		/// <summary>
		/// <para>Input Customer Features</para>
		/// <para>The input point feature layer representing customers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Input Store Features</para>
		/// <para>The input point feature layer representing store or facilities.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InStoreFeatures { get; set; }

		/// <summary>
		/// <para>Store ID Field</para>
		/// <para>A unique ID field for Input Store Features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "Short", "Long", "GUID", "GlobalID")]
		public object StoreIdField { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>A point layer containing customers with assigned store or facility and distance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Field Name</para>
		/// <para>A new field that contains the assigned store or facility ID.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object LinkField { get; set; }

		/// <summary>
		/// <para>Distance Type</para>
		/// <para>The method of travel used to calculate the distance between customers and stores.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceType { get; set; } = "STRAIGHT_LINE_DISTANCE";

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>The units that will be used to measure the selected distance type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceUnits { get; set; }

		/// <summary>
		/// <para>Travel Direction</para>
		/// <para>Specifies the direction of travel that will be used between stores or facilities and customers.</para>
		/// <para>Toward Stores—The direction of travel will be from customers to stores. This is the default.</para>
		/// <para>Away from Stores—The direction of travel will be from stores to customers.</para>
		/// <para><see cref="TravelDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Network Parameters")]
		public object TravelDirection { get; set; } = "TOWARD_STORES";

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>The time and date that will be used when calculating distance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Network Parameters")]
		public object TimeOfDay { get; set; }

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>Specifies the time zone that will be used for the Time of Day parameter.</para>
		/// <para>Time Zone at Location—The time zone in which the territories are located will be used. This is the default.</para>
		/// <para>UTC—Coordinated universal time (UTC) will be used.</para>
		/// <para><see cref="TimeZoneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Network Parameters")]
		public object TimeZone { get; set; } = "TIME_ZONE_AT_LOCATION";

		/// <summary>
		/// <para>Search Tolerance</para>
		/// <para>The maximum distance that input points can be from the network. Points located beyond the search tolerance will be excluded from processing.</para>
		/// <para>The parameter requires a distance value and units for the tolerance. The default value is 5000 meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Network Parameters")]
		public object SearchTolerance { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AssignCustomersByDistance SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Travel Direction</para>
		/// </summary>
		public enum TravelDirectionEnum 
		{
			/// <summary>
			/// <para>Toward Stores—The direction of travel will be from customers to stores. This is the default.</para>
			/// </summary>
			[GPValue("TOWARD_STORES")]
			[Description("Toward Stores")]
			Toward_Stores,

			/// <summary>
			/// <para>Away from Stores—The direction of travel will be from stores to customers.</para>
			/// </summary>
			[GPValue("AWAY_FROM_STORES")]
			[Description("Away from Stores")]
			Away_from_Stores,

		}

		/// <summary>
		/// <para>Time Zone</para>
		/// </summary>
		public enum TimeZoneEnum 
		{
			/// <summary>
			/// <para>UTC—Coordinated universal time (UTC) will be used.</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

			/// <summary>
			/// <para>Time Zone at Location—The time zone in which the territories are located will be used. This is the default.</para>
			/// </summary>
			[GPValue("TIME_ZONE_AT_LOCATION")]
			[Description("Time Zone at Location")]
			Time_Zone_at_Location,

		}

#endregion
	}
}
