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
	/// <para>Huff Model</para>
	/// <para>Creates a probability surface to predict the sales potential of an area based on distance and an attractiveness factor.</para>
	/// </summary>
	public class HuffModel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFacilityFeatures">
		/// <para>Input Facility Features</para>
		/// <para>An input point feature layer representing existing facility locations. It is the first feature from the layer or the feature selected when a selection is available.</para>
		/// </param>
		/// <param name="FacilityIdField">
		/// <para>Facility ID Field</para>
		/// <para>A unique ID field for existing facilities.</para>
		/// </param>
		/// <param name="InCandidateFeatures">
		/// <para>Input Candidate Features</para>
		/// <para>An input point feature layer representing new candidate facility locations. It is the first feature from the layer or the feature selected when a selection is available.</para>
		/// </param>
		/// <param name="CandidateIdField">
		/// <para>Candidate ID Field</para>
		/// <para>A unique ID field for candidate facilities.</para>
		/// </param>
		/// <param name="InSalesPotentialFeatures">
		/// <para>Input Sales Potential Features</para>
		/// <para>An input point or polygon feature layer used to calculate the sales potential. It is either all features from a layer or only selected features when a selection is available.</para>
		/// </param>
		/// <param name="SalesPotentialIdField">
		/// <para>Sales Potential ID Field</para>
		/// <para>A unique ID field for sales potential features.</para>
		/// </param>
		/// <param name="SalesPotentialField">
		/// <para>Sales Potential Field</para>
		/// <para>The field containing the values that will be used to calculate the sales potential.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output feature Class</para>
		/// <para>The output feature class that will contain the tool results representing the probability of sales.</para>
		/// </param>
		/// <param name="AttractivenessVariables">
		/// <para>Attractiveness Variables</para>
		/// <para>The attribute fields that indicate the attractiveness of each competitor. In many cases, the size of the facility is used as a substitute for attractiveness and will be a multivalue table.</para>
		/// <para>An additional attractiveness variable is needed. The attractiveness field must be present in the existing facilities (competitors) and the candidate facilities layer.</para>
		/// <para>Existing Facilities Value—Numeric field in the Input Facility Features parameter layer that represents attractiveness.</para>
		/// <para>Candidates Location Value—Numeric Field in the Input Candidate Features parameter layer that matches the attractiveness value from the Input Facility Features parameter layer. Distance does not require a matching field.</para>
		/// <para>Exponent—The value that determines how much of a factor the variable is to the attractiveness value. The default value is 1.</para>
		/// </param>
		/// <param name="DistanceExponent">
		/// <para>Distance Exponent</para>
		/// <para>The distance exponent is generally a negative number because attractiveness decreases when distance increases. The default value is -1.5.</para>
		/// </param>
		public HuffModel(object InFacilityFeatures, object FacilityIdField, object InCandidateFeatures, object CandidateIdField, object InSalesPotentialFeatures, object SalesPotentialIdField, object SalesPotentialField, object OutFeatureClass, object AttractivenessVariables, object DistanceExponent)
		{
			this.InFacilityFeatures = InFacilityFeatures;
			this.FacilityIdField = FacilityIdField;
			this.InCandidateFeatures = InCandidateFeatures;
			this.CandidateIdField = CandidateIdField;
			this.InSalesPotentialFeatures = InSalesPotentialFeatures;
			this.SalesPotentialIdField = SalesPotentialIdField;
			this.SalesPotentialField = SalesPotentialField;
			this.OutFeatureClass = OutFeatureClass;
			this.AttractivenessVariables = AttractivenessVariables;
			this.DistanceExponent = DistanceExponent;
		}

		/// <summary>
		/// <para>Tool Display Name : Huff Model</para>
		/// </summary>
		public override string DisplayName => "Huff Model";

		/// <summary>
		/// <para>Tool Name : HuffModel</para>
		/// </summary>
		public override string ToolName => "HuffModel";

		/// <summary>
		/// <para>Tool Excute Name : ba.HuffModel</para>
		/// </summary>
		public override string ExcuteName => "ba.HuffModel";

		/// <summary>
		/// <para>Toolbox Display Name : Business Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Business Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ba</para>
		/// </summary>
		public override string ToolboxAlise => "ba";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "baDataSource", "baNetworkSource", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFacilityFeatures, FacilityIdField, InCandidateFeatures, CandidateIdField, InSalesPotentialFeatures, SalesPotentialIdField, SalesPotentialField, OutFeatureClass, AttractivenessVariables, DistanceExponent, OutPredictedSales, DistanceType, DistanceUnits, OutDistanceMatrix, TravelDirection, TimeOfDay, TimeZone };

		/// <summary>
		/// <para>Input Facility Features</para>
		/// <para>An input point feature layer representing existing facility locations. It is the first feature from the layer or the feature selected when a selection is available.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InFacilityFeatures { get; set; }

		/// <summary>
		/// <para>Facility ID Field</para>
		/// <para>A unique ID field for existing facilities.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text", "OID")]
		public object FacilityIdField { get; set; }

		/// <summary>
		/// <para>Input Candidate Features</para>
		/// <para>An input point feature layer representing new candidate facility locations. It is the first feature from the layer or the feature selected when a selection is available.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InCandidateFeatures { get; set; }

		/// <summary>
		/// <para>Candidate ID Field</para>
		/// <para>A unique ID field for candidate facilities.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text", "OID")]
		public object CandidateIdField { get; set; }

		/// <summary>
		/// <para>Input Sales Potential Features</para>
		/// <para>An input point or polygon feature layer used to calculate the sales potential. It is either all features from a layer or only selected features when a selection is available.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		public object InSalesPotentialFeatures { get; set; }

		/// <summary>
		/// <para>Sales Potential ID Field</para>
		/// <para>A unique ID field for sales potential features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text", "OID")]
		public object SalesPotentialIdField { get; set; }

		/// <summary>
		/// <para>Sales Potential Field</para>
		/// <para>The field containing the values that will be used to calculate the sales potential.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object SalesPotentialField { get; set; }

		/// <summary>
		/// <para>Output feature Class</para>
		/// <para>The output feature class that will contain the tool results representing the probability of sales.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Attractiveness Variables</para>
		/// <para>The attribute fields that indicate the attractiveness of each competitor. In many cases, the size of the facility is used as a substitute for attractiveness and will be a multivalue table.</para>
		/// <para>An additional attractiveness variable is needed. The attractiveness field must be present in the existing facilities (competitors) and the candidate facilities layer.</para>
		/// <para>Existing Facilities Value—Numeric field in the Input Facility Features parameter layer that represents attractiveness.</para>
		/// <para>Candidates Location Value—Numeric Field in the Input Candidate Features parameter layer that matches the attractiveness value from the Input Facility Features parameter layer. Distance does not require a matching field.</para>
		/// <para>Exponent—The value that determines how much of a factor the variable is to the attractiveness value. The default value is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object AttractivenessVariables { get; set; }

		/// <summary>
		/// <para>Distance Exponent</para>
		/// <para>The distance exponent is generally a negative number because attractiveness decreases when distance increases. The default value is -1.5.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object DistanceExponent { get; set; } = "-1.5";

		/// <summary>
		/// <para>Predicted Sales</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object OutPredictedSales { get; set; }

		/// <summary>
		/// <para>Distance Type</para>
		/// <para>The type of distance, based on method of travel, that will be used. The default value is Straight Line.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceType { get; set; } = "STRAIGHT_LINE_DISTANCE";

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>The distance-measuring units that will be used when calculating distance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceUnits { get; set; }

		/// <summary>
		/// <para>Output Distance Matrix</para>
		/// <para>The name and location of the matrix table of distance calculations. The IDs for the Input Facilitates Features and Input Candidate Features parameters must be unique.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object OutDistanceMatrix { get; set; }

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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public HuffModel SetEnviroment(object workspace = null )
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
