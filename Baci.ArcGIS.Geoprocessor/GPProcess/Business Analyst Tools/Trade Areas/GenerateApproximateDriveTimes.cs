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
	/// <para>Generate Approximate Drive Times</para>
	/// <para>Creates trade areas that approximate the size, shape, and area of existing polygons using available routes from the selected distance type.</para>
	/// </summary>
	public class GenerateApproximateDriveTimes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input polygon feature layer.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing the drive time polygons.</para>
		/// </param>
		/// <param name="DistanceType">
		/// <para>Distance Type</para>
		/// <para>The method of travel used to create the output polygons.</para>
		/// </param>
		public GenerateApproximateDriveTimes(object InFeatures, object OutFeatureClass, object DistanceType)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.DistanceType = DistanceType;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Approximate Drive Times</para>
		/// </summary>
		public override string DisplayName => "Generate Approximate Drive Times";

		/// <summary>
		/// <para>Tool Name : GenerateApproximateDriveTimes</para>
		/// </summary>
		public override string ToolName => "GenerateApproximateDriveTimes";

		/// <summary>
		/// <para>Tool Excute Name : ba.GenerateApproximateDriveTimes</para>
		/// </summary>
		public override string ExcuteName => "ba.GenerateApproximateDriveTimes";

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
		public override object[] Parameters => new object[] { InFeatures, OutFeatureClass, DistanceType, Units!, InStoresLayer!, StoreIdField!, LinkField!, IterationsLimit!, MinimumStep!, TargetPercentDiff!, TravelDirection!, TimeOfDay!, TimeZone!, SearchTolerance!, PolygonDetail! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input polygon feature layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing the drive time polygons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Distance Type</para>
		/// <para>The method of travel used to create the output polygons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceType { get; set; }

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>The distance units to be used with the threshold values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Units { get; set; }

		/// <summary>
		/// <para>Store Layer</para>
		/// <para>A point layer that will be used as the starting point for creating network service areas.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object? InStoresLayer { get; set; }

		/// <summary>
		/// <para>Store ID Field</para>
		/// <para>The ID that uniquely identifies each Store Layer point.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? StoreIdField { get; set; }

		/// <summary>
		/// <para>Associated Store ID Field</para>
		/// <para>The ID that uniquely identifies each Input Features point.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? LinkField { get; set; }

		/// <summary>
		/// <para>Iterations Limit</para>
		/// <para>The maximum number of drive times that can be used to find the optimal threshold limit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object? IterationsLimit { get; set; }

		/// <summary>
		/// <para>Minimum Step</para>
		/// <para>The minimum increment distance or time—for example, 1 mile or 1 min—that will be used between iterations to expand until the threshold is reached.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Category("Advanced Parameters")]
		public object? MinimumStep { get; set; }

		/// <summary>
		/// <para>Threshold Percent Difference</para>
		/// <para>The maximum difference between the target value and threshold value when determining the threshold drive time, for example, 5 percent. The default value is 5.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Category("Advanced Parameters")]
		public object? TargetPercentDiff { get; set; } = "5";

		/// <summary>
		/// <para>Travel Direction</para>
		/// <para>Specifies the direction of travel for output polygon creation.</para>
		/// <para>Toward Stores—The direction of travel will be from customers to stores. This is the default.</para>
		/// <para>Away from Stores—The direction of travel will be from stores to customers.</para>
		/// <para><see cref="TravelDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Network Parameters")]
		public object? TravelDirection { get; set; } = "TOWARD_STORES";

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
		/// <para>Search Tolerance</para>
		/// <para>The maximum distance that input points can be from the network.</para>
		/// <para>The default value is 5000 meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Network Parameters")]
		public object? SearchTolerance { get; set; }

		/// <summary>
		/// <para>Polygon Detail</para>
		/// <para>Specifies the level of detail that will be used for the output drive time polygons.</para>
		/// <para>Standard—Polygons with a standard level of detail will be created. This is the default.</para>
		/// <para>Generalized—Generalized polygons will be created using the hierarchy present in the network data source to produce results quickly.</para>
		/// <para>High—Polygons with a high level of detail will be created for applications in which precise results are important.</para>
		/// <para><see cref="PolygonDetailEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Network Parameters")]
		public object? PolygonDetail { get; set; } = "STANDARD";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateApproximateDriveTimes SetEnviroment(object? baDataSource = null , object? baNetworkSource = null , object? workspace = null )
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

		/// <summary>
		/// <para>Polygon Detail</para>
		/// </summary>
		public enum PolygonDetailEnum 
		{
			/// <summary>
			/// <para>Standard—Polygons with a standard level of detail will be created. This is the default.</para>
			/// </summary>
			[GPValue("STANDARD")]
			[Description("Standard")]
			Standard,

			/// <summary>
			/// <para>Generalized—Generalized polygons will be created using the hierarchy present in the network data source to produce results quickly.</para>
			/// </summary>
			[GPValue("GENERALIZED")]
			[Description("Generalized")]
			Generalized,

			/// <summary>
			/// <para>High—Polygons with a high level of detail will be created for applications in which precise results are important.</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("High")]
			High,

		}

#endregion
	}
}
