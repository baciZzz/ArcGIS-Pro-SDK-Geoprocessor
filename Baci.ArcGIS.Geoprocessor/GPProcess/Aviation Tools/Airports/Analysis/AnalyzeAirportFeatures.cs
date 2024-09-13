using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AviationTools
{
	/// <summary>
	/// <para>Analyze Airport Features</para>
	/// <para>Analyze Airport Features</para>
	/// <para>Analyzes specified point features around an airfield to find and record information such as distance from a given runway centerline or the end of the nearest runway, and the designation for that nearest runway.</para>
	/// </summary>
	public class AnalyzeAirportFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The input point features that will be analyzed and recorded, in terms of their physical relationships to features in the other inputs.</para>
		/// </param>
		/// <param name="InRunwayFeatures">
		/// <para>Input Runway Features</para>
		/// <para>The input runway polyline features, specifically their centerlines, that will be used in the analysis.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>The output table, with a row for each input airport feature, containing the analytical results.</para>
		/// </param>
		public AnalyzeAirportFeatures(object InFeatures, object InRunwayFeatures, object OutTable)
		{
			this.InFeatures = InFeatures;
			this.InRunwayFeatures = InRunwayFeatures;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Analyze Airport Features</para>
		/// </summary>
		public override string DisplayName() => "Analyze Airport Features";

		/// <summary>
		/// <para>Tool Name : AnalyzeAirportFeatures</para>
		/// </summary>
		public override string ToolName() => "AnalyzeAirportFeatures";

		/// <summary>
		/// <para>Tool Excute Name : aviation.AnalyzeAirportFeatures</para>
		/// </summary>
		public override string ExcuteName() => "aviation.AnalyzeAirportFeatures";

		/// <summary>
		/// <para>Toolbox Display Name : Aviation Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Aviation Tools";

		/// <summary>
		/// <para>Toolbox Alise : aviation</para>
		/// </summary>
		public override string ToolboxAlise() => "aviation";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, InRunwayFeatures, OutTable, InFeaturesHeight, InFeaturesHeightUnit, RunwayEndFeatures, AirportRefPointFeatures, RefPointHeight, RefPointHeightUnit };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The input point features that will be analyzed and recorded, in terms of their physical relationships to features in the other inputs.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Input Runway Features</para>
		/// <para>The input runway polyline features, specifically their centerlines, that will be used in the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InRunwayFeatures { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The output table, with a row for each input airport feature, containing the analytical results.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Input Features Height</para>
		/// <para>The name of a field in the input airport features dataset. The specified field must contain numeric values. The values in this field will be used to identify the height of each input airport feature.</para>
		/// <para>SHAPE_Z—Height values will be derived from the z-values of the input point features. This is the default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InFeaturesHeight { get; set; } = "SHAPE_Z";

		/// <summary>
		/// <para>Input Features Height Unit</para>
		/// <para>Specifies the linear unit of measure that will be used when the Input Features Height parameter is specified.</para>
		/// <para>Kilometers—Kilometers</para>
		/// <para>Meters—Meters</para>
		/// <para>Decimeters—Decimeters</para>
		/// <para>Centimeters—Centimeters</para>
		/// <para>Millimeters—Millimeters</para>
		/// <para>Nautical Miles—Nautical miles</para>
		/// <para>Miles—Miles</para>
		/// <para>Yards—Yards</para>
		/// <para>Feet—Feet</para>
		/// <para>Inches—Inches</para>
		/// <para>Decimal Degrees—Decimal degrees</para>
		/// <para>Points—Points</para>
		/// <para>Unknown—Unknown</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InFeaturesHeightUnit { get; set; } = "METERS";

		/// <summary>
		/// <para>Runway End Features</para>
		/// <para>The input runway end point features associated with the runways in the Input Features Height Unit parameter that represent the thresholds of those runways.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object RunwayEndFeatures { get; set; }

		/// <summary>
		/// <para>Airport Reference Point Features</para>
		/// <para>The input airport reference point features that define the center point of an airport, located at the geometric center of all the usable runways and computed as a weighted average of the end of runway coordinates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object AirportRefPointFeatures { get; set; }

		/// <summary>
		/// <para>Airport Reference Point Height</para>
		/// <para>The name of a field in the input airport reference point features dataset. The specified field must contain numeric values. The values in this field will be used to identify the height of each input airport reference point feature.</para>
		/// <para>SHAPE_Z—The z-value of each point. This is the default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RefPointHeight { get; set; } = "SHAPE_Z";

		/// <summary>
		/// <para>Airport Reference Point Height Unit</para>
		/// <para>The linear unit of measure that will be used when the airport reference point height is specified.</para>
		/// <para>Kilometers—Kilometers</para>
		/// <para>Meters—Meters</para>
		/// <para>Decimeters—Decimeters</para>
		/// <para>Centimeters—Centimeters</para>
		/// <para>Millimeters—Millimeters</para>
		/// <para>Nautical Miles—Nautical miles</para>
		/// <para>Miles—Miles</para>
		/// <para>Yards—Yards</para>
		/// <para>Feet—Feet</para>
		/// <para>Inches—Inches</para>
		/// <para>Decimal Degrees—Decimal degrees</para>
		/// <para>Points—Points</para>
		/// <para>Unknown—Unknown</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RefPointHeightUnit { get; set; } = "METERS";

	}
}
