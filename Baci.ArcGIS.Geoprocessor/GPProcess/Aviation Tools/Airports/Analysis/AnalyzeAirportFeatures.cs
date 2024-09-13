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
	/// <para>Analyzes specified point features around an airfield to find and record information such as distance from a given runway centerline or the end of the nearest runway and its designation.</para>
	/// </summary>
	public class AnalyzeAirportFeatures : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Analysis Features</para>
		/// <para>The input point features that will be analyzed and recorded in terms of their physical relationships to features in the other inputs.</para>
		/// </param>
		/// <param name="InRunwayFeatures">
		/// <para>Input Runway Features</para>
		/// <para>The input runway polyline features, specifically their centerlines, that will be used in the analysis.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>The output table, with a row for each input airport feature, containing the analyzed results. The EGL and MSL columns will no longer be output.</para>
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
		public override object[] Parameters() => new object[] { InFeatures, InRunwayFeatures, OutTable, InFeaturesHeight!, InFeaturesHeightUnit!, RunwayEndFeatures!, AirportRefPointFeatures!, RefPointHeight!, RefPointHeightUnit!, InOutHorizontalUnit! };

		/// <summary>
		/// <para>Input Analysis Features</para>
		/// <para>The input point features that will be analyzed and recorded in terms of their physical relationships to features in the other inputs.</para>
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
		/// <para>The output table, with a row for each input airport feature, containing the analyzed results. The EGL and MSL columns will no longer be output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Input Analysis Features Height</para>
		/// <para>Specifies the name of a field in the input airport features dataset. The specified field must contain numeric values. The values in this field will be used to identify the height of each input airport feature. If the SHAPE_Z value is chosen as the location of the height, the Input Analysis Features Height Unit parameter value will be ignored.</para>
		/// <para>SHAPE_Z—Height values will be derived from the z-values of the input point features. This is the default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? InFeaturesHeight { get; set; } = "SHAPE_Z";

		/// <summary>
		/// <para>Input Analysis Features Height Unit</para>
		/// <para>Specifies the linear unit of measure that will be used when the Input Analysis Features Height parameter value is specified.</para>
		/// <para>Kilometers—The unit will be kilometers.</para>
		/// <para>Meters—The unit will be meters.</para>
		/// <para>Decimeters—The unit will be decimeters.</para>
		/// <para>Centimeters—The unit will be centimeters.</para>
		/// <para>Millimeters—The unit will be millimeters.</para>
		/// <para>Nautical Miles—The unit will be nautical miles.</para>
		/// <para>Miles—The unit will be miles.</para>
		/// <para>Yards—The unit will be yards.</para>
		/// <para>Feet—The unit will be feet.</para>
		/// <para>Inches—The unit will be inches.</para>
		/// <para>Decimal Degrees—The unit will be decimal degrees.</para>
		/// <para>Points—The unit will be points.</para>
		/// <para>Unknown—The unit will be unknown.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? InFeaturesHeightUnit { get; set; } = "METERS";

		/// <summary>
		/// <para>Runway End Features</para>
		/// <para>The input runway end point features associated with the runways in the Input Runway Features parameter that represent the thresholds of those runways.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object? RunwayEndFeatures { get; set; }

		/// <summary>
		/// <para>Airport Control Point Features</para>
		/// <para>The input airport control point features that contain the runway threshold points. The runway threshold points will be identified by searching for the POINTTYPE attribute equal to DISPLACED_THRESHOLD, and the attribute RUNWAYENDD equal to the runway end designator.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object? AirportRefPointFeatures { get; set; }

		/// <summary>
		/// <para>Airport Control Point Elevation</para>
		/// <para>Specifies the name of a field in the input airport reference point features dataset. The specified field must contain numeric values. The values in this field will be used to identify the height of each input airport reference point feature. If SHAPE_Z is chosen as the location of the height, the Airport Control Point Elevation Unit parameter value will be ignored.</para>
		/// <para>SHAPE_Z—The z-value of each point will be used. This is the default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? RefPointHeight { get; set; } = "SHAPE_Z";

		/// <summary>
		/// <para>Airport Reference Point Elevation Unit</para>
		/// <para>Specifies the linear unit of measure that will be used when an airport reference point height is specified.</para>
		/// <para>Kilometers—The unit will be kilometers.</para>
		/// <para>Meters—The unit will be meters.</para>
		/// <para>Decimeters—The unit will be decimeters.</para>
		/// <para>Centimeters—The unit will be centimeters.</para>
		/// <para>Millimeters—The unit will be millimeters.</para>
		/// <para>Nautical Miles—The unit will be nautical miles.</para>
		/// <para>Miles—The unit will be miles.</para>
		/// <para>Yards—The unit will be yards.</para>
		/// <para>Feet—The unit will be feet.</para>
		/// <para>Inches—The unit will be inches.</para>
		/// <para>Decimal Degrees—The unit will be decimal degrees.</para>
		/// <para>Points—The unit will be points.</para>
		/// <para>Unknown—The unit will be unknown.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? RefPointHeightUnit { get; set; } = "METERS";

		/// <summary>
		/// <para>Output Horizontal Unit of Measure</para>
		/// <para>Specifies the output unit of measurement for the five output distances produced.</para>
		/// <para>Same as input—The horizontal units from the input coordinate system will be used. If the input data is not projected, this will be meters. This is the default</para>
		/// <para>Kilometers—The unit will be kilometers.</para>
		/// <para>Meters—The unit will be meters.</para>
		/// <para>Decimeters—The unit will be decimeters.</para>
		/// <para>Centimeters—The unit will be centimeters.</para>
		/// <para>Millimeters—The unit will be millimeters.</para>
		/// <para>Nautical Miles—The unit will be nautical miles.</para>
		/// <para>Miles—The unit will be miles.</para>
		/// <para>Yards—The unit will be yards.</para>
		/// <para>Feet—The unit will be feet.</para>
		/// <para>Inches—The unit will be inches.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? InOutHorizontalUnit { get; set; } = "SAME_AS_INPUT";

	}
}
