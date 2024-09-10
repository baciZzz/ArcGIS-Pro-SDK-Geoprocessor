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
	/// <para>Generate Desire Lines</para>
	/// <para>Generates a series of lines from each customer to an associated store location. These lines are often called spider diagrams.</para>
	/// </summary>
	public class DesireLines : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InStoresLayer">
		/// <para>Store Layer</para>
		/// <para>The input point layer representing store or facility locations.</para>
		/// </param>
		/// <param name="InCustomersLayer">
		/// <para>Customer Layer</para>
		/// <para>The input point layer representing customers or patrons.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The resultant feature class that will be added to the Contents pane.</para>
		/// </param>
		/// <param name="StoreIdField">
		/// <para>Store ID Field</para>
		/// <para>A unique ID field representing a store or facility location.</para>
		/// </param>
		/// <param name="LinkField">
		/// <para>Associated Store ID Field</para>
		/// <para>An ID field used to assign individual customers to stores.</para>
		/// </param>
		public DesireLines(object InStoresLayer, object InCustomersLayer, object OutFeatureClass, object StoreIdField, object LinkField)
		{
			this.InStoresLayer = InStoresLayer;
			this.InCustomersLayer = InCustomersLayer;
			this.OutFeatureClass = OutFeatureClass;
			this.StoreIdField = StoreIdField;
			this.LinkField = LinkField;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Desire Lines</para>
		/// </summary>
		public override string DisplayName() => "Generate Desire Lines";

		/// <summary>
		/// <para>Tool Name : DesireLines</para>
		/// </summary>
		public override string ToolName() => "DesireLines";

		/// <summary>
		/// <para>Tool Excute Name : ba.DesireLines</para>
		/// </summary>
		public override string ExcuteName() => "ba.DesireLines";

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
		public override object[] Parameters() => new object[] { InStoresLayer, InCustomersLayer, OutFeatureClass, StoreIdField, LinkField, DistanceType, Units, Cutoff, TravelDirection, TimeOfDay, TimeZone };

		/// <summary>
		/// <para>Store Layer</para>
		/// <para>The input point layer representing store or facility locations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InStoresLayer { get; set; }

		/// <summary>
		/// <para>Customer Layer</para>
		/// <para>The input point layer representing customers or patrons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InCustomersLayer { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The resultant feature class that will be added to the Contents pane.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Store ID Field</para>
		/// <para>A unique ID field representing a store or facility location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "Short", "Long", "Float", "Double", "GUID", "GlobalID")]
		public object StoreIdField { get; set; }

		/// <summary>
		/// <para>Associated Store ID Field</para>
		/// <para>An ID field used to assign individual customers to stores.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "Short", "Long", "Float", "Double", "GUID", "GlobalID")]
		public object LinkField { get; set; }

		/// <summary>
		/// <para>Distance Type</para>
		/// <para>The method of travel that will be used for distance calculation. Straight Line is the default value.</para>
		/// <para>When using Portal for ArcGIS or local data sources, travel mode options are dynamically populated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceType { get; set; }

		/// <summary>
		/// <para>Measure Units</para>
		/// <para>The type of distance- or time-measuring units that will be used when calculating minimal distance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Units { get; set; }

		/// <summary>
		/// <para>Cutoff</para>
		/// <para>The distance beyond which customers will be considered outliers and excluded from consideration during desire line generation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		public object Cutoff { get; set; }

		/// <summary>
		/// <para>Travel Direction</para>
		/// <para>Specifies the direction of travel that will be used between stores and demand points.</para>
		/// <para>Toward Stores—The direction of travel will be from demand points to stores. This is the default.</para>
		/// <para>Away from Stores—The direction of travel will be from stores to demand points.</para>
		/// <para><see cref="TravelDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Network Parameters")]
		public object TravelDirection { get; set; } = "TOWARD_STORES";

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>The time at which travel begins.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Network Parameters")]
		public object TimeOfDay { get; set; }

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>Specifies the time zone that will be used for the Time of Day parameter.</para>
		/// <para>UTC—Coordinated universal time (UTC) will be used. Choose this option if you want to choose the best location for a specific time, such as now, but aren&apos;t certain in which time zone the stores or demand points will be located.</para>
		/// <para>Local time at locations—The time zone in which the stores or demand points are located will be used. If Travel Direction is Away from Stores, this is the time zone of the stores. If Travel Direction is Toward Stores, this is the time zone of the demand points. This is the default.</para>
		/// <para><see cref="TimeZoneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Network Parameters")]
		public object TimeZone { get; set; } = "TIME_ZONE_AT_LOCATION";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DesireLines SetEnviroment(object workspace = null )
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
			/// <para>Toward Stores—The direction of travel will be from demand points to stores. This is the default.</para>
			/// </summary>
			[GPValue("TOWARD_STORES")]
			[Description("Toward Stores")]
			Toward_Stores,

			/// <summary>
			/// <para>Away from Stores—The direction of travel will be from stores to demand points.</para>
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
			/// <para>UTC—Coordinated universal time (UTC) will be used. Choose this option if you want to choose the best location for a specific time, such as now, but aren&apos;t certain in which time zone the stores or demand points will be located.</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

			/// <summary>
			/// <para>Local time at locations—The time zone in which the stores or demand points are located will be used. If Travel Direction is Away from Stores, this is the time zone of the stores. If Travel Direction is Toward Stores, this is the time zone of the demand points. This is the default.</para>
			/// </summary>
			[GPValue("TIME_ZONE_AT_LOCATION")]
			[Description("Local time at locations")]
			Local_time_at_locations,

		}

#endregion
	}
}
