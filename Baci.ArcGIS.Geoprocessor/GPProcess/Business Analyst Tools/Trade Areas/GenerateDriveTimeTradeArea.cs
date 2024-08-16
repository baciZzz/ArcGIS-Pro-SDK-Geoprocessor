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
	/// <para>Generate Drive Time Trade Areas</para>
	/// <para>Creates a feature class of trade areas around point features based on travel time and distance.</para>
	/// </summary>
	public class GenerateDriveTimeTradeArea : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input point feature layer.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing the drive time polygons.</para>
		/// </param>
		/// <param name="DistanceType">
		/// <para>Distance Type</para>
		/// <para>The method of travel that will be used for drive time calculation.</para>
		/// </param>
		public GenerateDriveTimeTradeArea(object InFeatures, object OutFeatureClass, object DistanceType)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.DistanceType = DistanceType;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Drive Time Trade Areas</para>
		/// </summary>
		public override string DisplayName => "Generate Drive Time Trade Areas";

		/// <summary>
		/// <para>Tool Name : GenerateDriveTimeTradeArea</para>
		/// </summary>
		public override string ToolName => "GenerateDriveTimeTradeArea";

		/// <summary>
		/// <para>Tool Excute Name : ba.GenerateDriveTimeTradeArea</para>
		/// </summary>
		public override string ExcuteName => "ba.GenerateDriveTimeTradeArea";

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
		public override object[] Parameters => new object[] { InFeatures, OutFeatureClass, DistanceType, Distances, Units, IdField, DissolveOption, RemoveOverlap, TravelDirection, TimeOfDay, TimeZone, SearchTolerance, PolygonDetail, InputMethod, Expression };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input point feature layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
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
		/// <para>The method of travel that will be used for drive time calculation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceType { get; set; }

		/// <summary>
		/// <para>Distances</para>
		/// <para>The distances that will be used for drive time calculations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPNumericDomain()]
		public object Distances { get; set; }

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>The units that will be used for the distance values. The default value is miles.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Units { get; set; }

		/// <summary>
		/// <para>ID Field</para>
		/// <para>A unique ID field for existing facilities.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text", "Short", "Long", "GUID", "GlobalID")]
		public object IdField { get; set; }

		/// <summary>
		/// <para>Dissolve Option</para>
		/// <para>Specifies whether overlapping or nonoverlapping service areas for a single location will be used when multiple distances are specified.</para>
		/// <para>Overlap— Each polygon will include the area reachable from the facility up to the distance value. This is the default.</para>
		/// <para>Split— Each polygon will include only the area between consecutive distance values.</para>
		/// <para><see cref="DissolveOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DissolveOption { get; set; } = "OVERLAP";

		/// <summary>
		/// <para>Remove Overlap</para>
		/// <para>Specifies whether overlapping concentric rings will be created or overlap will be removed from multiple locations in relation to one another.</para>
		/// <para>Checked—Polygons will be split and the overlap between output features will be removed.</para>
		/// <para>Unchecked—Output features will be created with overlap. This is the default.</para>
		/// <para><see cref="RemoveOverlapEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object RemoveOverlap { get; set; } = "false";

		/// <summary>
		/// <para>Travel Direction</para>
		/// <para>Specifies the direction of travel that will be used between stores and customers.</para>
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
		/// <para>This parameter requires a distance value and units for the tolerance. The default value is 5000 meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Network Parameters")]
		public object SearchTolerance { get; set; }

		/// <summary>
		/// <para>Polygon Detail</para>
		/// <para>Specifies the level of detail that will be used for the output drive time polygons.</para>
		/// <para>Standard— Polygons with a standard level of detail will be created. This is the default.</para>
		/// <para>Generalized—Generalized polygons will be created using the hierarchy present in the network data source to produce results quickly.</para>
		/// <para>High— Polygons with a high level of detail will be created for applications in which precise results are important.</para>
		/// <para><see cref="PolygonDetailEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Network Parameters")]
		public object PolygonDetail { get; set; } = "STANDARD";

		/// <summary>
		/// <para>Input Method</para>
		/// <para>Specifies the type of value that will be used for each drive time.</para>
		/// <para>Values—A constant value will be used (all trade areas will be the same size). This is the default.</para>
		/// <para>Expression— The values from a field or an expression will be used (trade areas can be a different size).</para>
		/// <para><see cref="InputMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InputMethod { get; set; } = "VALUES";

		/// <summary>
		/// <para>Distance Expression</para>
		/// <para>A fields-based expression used to calculate drive time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object Expression { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateDriveTimeTradeArea SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Dissolve Option</para>
		/// </summary>
		public enum DissolveOptionEnum 
		{
			/// <summary>
			/// <para>Overlap— Each polygon will include the area reachable from the facility up to the distance value. This is the default.</para>
			/// </summary>
			[GPValue("OVERLAP")]
			[Description("Overlap")]
			Overlap,

			/// <summary>
			/// <para>Split— Each polygon will include only the area between consecutive distance values.</para>
			/// </summary>
			[GPValue("SPLIT")]
			[Description("Split")]
			Split,

		}

		/// <summary>
		/// <para>Remove Overlap</para>
		/// </summary>
		public enum RemoveOverlapEnum 
		{
			/// <summary>
			/// <para>Checked—Polygons will be split and the overlap between output features will be removed.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REMOVE_OVERLAP")]
			REMOVE_OVERLAP,

			/// <summary>
			/// <para>Unchecked—Output features will be created with overlap. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_OVERLAP")]
			KEEP_OVERLAP,

		}

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
			/// <para>Standard— Polygons with a standard level of detail will be created. This is the default.</para>
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
			/// <para>High— Polygons with a high level of detail will be created for applications in which precise results are important.</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("High")]
			High,

		}

		/// <summary>
		/// <para>Input Method</para>
		/// </summary>
		public enum InputMethodEnum 
		{
			/// <summary>
			/// <para>Values—A constant value will be used (all trade areas will be the same size). This is the default.</para>
			/// </summary>
			[GPValue("VALUES")]
			[Description("Values")]
			Values,

			/// <summary>
			/// <para>Expression— The values from a field or an expression will be used (trade areas can be a different size).</para>
			/// </summary>
			[GPValue("EXPRESSION")]
			[Description("Expression")]
			Expression,

		}

#endregion
	}
}
