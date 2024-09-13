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
	/// <para>Huff Model Calibration</para>
	/// <para>Huff Model Calibration</para>
	/// <para>Calculates exponent values for use in the Huff Model tool.</para>
	/// </summary>
	public class HuffModelCalibration : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFacilityFeatures">
		/// <para>Input Facility Features</para>
		/// <para>The input point feature class representing competitors or existing stores.</para>
		/// </param>
		/// <param name="FacilityIdField">
		/// <para>Facility ID Field</para>
		/// <para>A unique ID field representing a store or facility location.</para>
		/// </param>
		/// <param name="InCustomerFeatures">
		/// <para>Input Customer Features</para>
		/// <para>The input point feature class representing customer locations.</para>
		/// </param>
		/// <param name="LinkField">
		/// <para>Associated Facility ID Field</para>
		/// <para>The field that will be used as an ID to assign individual customers to a facility or store.</para>
		/// </param>
		/// <param name="InSalesPotentialFeatures">
		/// <para>Input Sales Potential Features</para>
		/// <para>The input polygon feature class used to determine the potential sales market.</para>
		/// </param>
		/// <param name="SalesPotentialIdField">
		/// <para>Sales Potential ID Field</para>
		/// <para>A unique ID field representing the sales potential area.</para>
		/// </param>
		/// <param name="OutCalibration">
		/// <para>Output Calibration</para>
		/// <para>The output calibration file that will contain the calibrated Huff model results, which is the exponent values for the attractiveness variables and distance. The output file extension will be *.huffmodel.</para>
		/// </param>
		/// <param name="AttractivenessVariables">
		/// <para>Attractiveness Variables</para>
		/// <para>The fields that will be used to determine the attractiveness of each competitor. In many cases, the size of the store is used as a substitute for attractiveness.</para>
		/// </param>
		public HuffModelCalibration(object InFacilityFeatures, object FacilityIdField, object InCustomerFeatures, object LinkField, object InSalesPotentialFeatures, object SalesPotentialIdField, object OutCalibration, object AttractivenessVariables)
		{
			this.InFacilityFeatures = InFacilityFeatures;
			this.FacilityIdField = FacilityIdField;
			this.InCustomerFeatures = InCustomerFeatures;
			this.LinkField = LinkField;
			this.InSalesPotentialFeatures = InSalesPotentialFeatures;
			this.SalesPotentialIdField = SalesPotentialIdField;
			this.OutCalibration = OutCalibration;
			this.AttractivenessVariables = AttractivenessVariables;
		}

		/// <summary>
		/// <para>Tool Display Name : Huff Model Calibration</para>
		/// </summary>
		public override string DisplayName() => "Huff Model Calibration";

		/// <summary>
		/// <para>Tool Name : HuffModelCalibration</para>
		/// </summary>
		public override string ToolName() => "HuffModelCalibration";

		/// <summary>
		/// <para>Tool Excute Name : ba.HuffModelCalibration</para>
		/// </summary>
		public override string ExcuteName() => "ba.HuffModelCalibration";

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
		public override object[] Parameters() => new object[] { InFacilityFeatures, FacilityIdField, InCustomerFeatures, LinkField, InSalesPotentialFeatures, SalesPotentialIdField, OutCalibration, AttractivenessVariables, CustomerWeightField!, DistanceType!, DistanceUnits!, TravelDirection!, TimeOfDay!, TimeZone! };

		/// <summary>
		/// <para>Input Facility Features</para>
		/// <para>The input point feature class representing competitors or existing stores.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InFacilityFeatures { get; set; }

		/// <summary>
		/// <para>Facility ID Field</para>
		/// <para>A unique ID field representing a store or facility location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text", "OID")]
		public object FacilityIdField { get; set; }

		/// <summary>
		/// <para>Input Customer Features</para>
		/// <para>The input point feature class representing customer locations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InCustomerFeatures { get; set; }

		/// <summary>
		/// <para>Associated Facility ID Field</para>
		/// <para>The field that will be used as an ID to assign individual customers to a facility or store.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text", "OID")]
		public object LinkField { get; set; }

		/// <summary>
		/// <para>Input Sales Potential Features</para>
		/// <para>The input polygon feature class used to determine the potential sales market.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InSalesPotentialFeatures { get; set; }

		/// <summary>
		/// <para>Sales Potential ID Field</para>
		/// <para>A unique ID field representing the sales potential area.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text", "OID")]
		public object SalesPotentialIdField { get; set; }

		/// <summary>
		/// <para>Output Calibration</para>
		/// <para>The output calibration file that will contain the calibrated Huff model results, which is the exponent values for the attractiveness variables and distance. The output file extension will be *.huffmodel.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("huffmodel")]
		public object OutCalibration { get; set; }

		/// <summary>
		/// <para>Attractiveness Variables</para>
		/// <para>The fields that will be used to determine the attractiveness of each competitor. In many cases, the size of the store is used as a substitute for attractiveness.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object AttractivenessVariables { get; set; }

		/// <summary>
		/// <para>Customer Weight Field</para>
		/// <para>A calculated weighted value field assigned to each customer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? CustomerWeightField { get; set; }

		/// <summary>
		/// <para>Distance Type</para>
		/// <para>The method of travel that will be used to calculate distance. The default value is Straight Line.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DistanceType { get; set; } = "STRAIGHT_LINE_DISTANCE";

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>The distance-measuring units that will be used when calculating distance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DistanceUnits { get; set; }

		/// <summary>
		/// <para>Travel Direction</para>
		/// <para>Specifies the direction of travel that will be used between stores and sales potential features.</para>
		/// <para>Toward Stores—The direction of travel will be from sales potential features to stores. This is the default.</para>
		/// <para>Away from Stores—The direction of travel will be from stores to sales potential features.</para>
		/// <para><see cref="TravelDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Network Parameters")]
		public object? TravelDirection { get; set; }

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>The time and date that will be used when calculating distance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Network Parameters")]
		public object? TimeOfDay { get; set; }

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
		public object? TimeZone { get; set; } = "TIME_ZONE_AT_LOCATION";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public HuffModelCalibration SetEnviroment(object? baDataSource = null , object? baNetworkSource = null , object? workspace = null )
		{
			base.SetEnv(baDataSource: baDataSource, baNetworkSource: baNetworkSource, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Travel Direction</para>
		/// </summary>
		public enum TravelDirectionEnum 
		{
			/// <summary>
			/// <para>Toward Stores—The direction of travel will be from sales potential features to stores. This is the default.</para>
			/// </summary>
			[GPValue("TOWARD_STORES")]
			[Description("Toward Stores")]
			Toward_Stores,

			/// <summary>
			/// <para>Away from Stores—The direction of travel will be from stores to sales potential features.</para>
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
