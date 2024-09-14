using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DefenseTools
{
	/// <summary>
	/// <para>Coordinate Table To Line Of Bearing</para>
	/// <para>Coordinate Table To Line Of Bearing</para>
	/// <para>Creates lines of bearing from coordinates stored in a table.</para>
	/// </summary>
	public class CoordinateTableToLineOfBearing : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The table containing the source coordinates.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Bearing Lines Feature Class</para>
		/// <para>The feature class containing the output lines of bearing.</para>
		/// </param>
		/// <param name="XOrLonField">
		/// <para>X Field (longitude, UTM, MGRS, USNG, GARS, GEOREF)</para>
		/// <para>The field in the input table containing the x or longitude coordinates.</para>
		/// </param>
		/// <param name="BearingField">
		/// <para>Bearing Field</para>
		/// <para>The field in the input table containing the bearing values.</para>
		/// </param>
		/// <param name="DistanceField">
		/// <para>Distance Field</para>
		/// <para>The field in the input table containing the distance values.</para>
		/// </param>
		/// <param name="InCoordinateFormat">
		/// <para>Input Coordinate Format</para>
		/// <para>Specifies the format of the input table coordinates.</para>
		/// <para>Decimal Degrees - One Field—Coordinates will be formatted in a decimal degrees coordinate pair stored in a single field with coordinates separated by a space, comma, or slash.</para>
		/// <para>Decimal Degrees - Two Fields—Coordinates will be formatted in a decimal degrees coordinate pair stored in two table fields. This is the default.</para>
		/// <para>Degrees and Decimal Minutes - One Field—Coordinates will be formatted in a degrees and decimal minutes coordinate pair stored in a single table field with coordinates separated by a space, comma, or slash.</para>
		/// <para>Degrees and Decimal Minutes - Two Fields—Coordinates will be formatted in a degrees and decimal minutes coordinate pair stored in two table fields.</para>
		/// <para>Degrees, Minutes, and Seconds - One Field—Coordinates will be formatted in a degrees, minutes, and seconds coordinate pair stored in a single table field with coordinates separated by a space, comma, or slash.</para>
		/// <para>Degrees, Minutes, and Seconds - Two Fields—Coordinates will be formatted in a degrees, minutes, and seconds coordinate pair stored in two table fields.</para>
		/// <para>Global Area Reference System—Coordinates will be formatted in Global Area Reference System.</para>
		/// <para>World Geographic Reference System— Coordinates will be formatted in World Geographic Reference System.</para>
		/// <para>Universal Transverse Mercator Bands—Coordinates will be formatted in Universal Transverse Mercator coordinate bands.</para>
		/// <para>Universal Transverse Mercator Zones—Coordinates will be formatted in Universal Transverse Mercator coordinate zones.</para>
		/// <para>United States National Grid—Coordinates will be formatted in United States National Grid.</para>
		/// <para>Military Grid Reference System—Coordinates will be formatted in Military Grid Reference System.</para>
		/// </param>
		public CoordinateTableToLineOfBearing(object InTable, object OutFeatureClass, object XOrLonField, object BearingField, object DistanceField, object InCoordinateFormat)
		{
			this.InTable = InTable;
			this.OutFeatureClass = OutFeatureClass;
			this.XOrLonField = XOrLonField;
			this.BearingField = BearingField;
			this.DistanceField = DistanceField;
			this.InCoordinateFormat = InCoordinateFormat;
		}

		/// <summary>
		/// <para>Tool Display Name : Coordinate Table To Line Of Bearing</para>
		/// </summary>
		public override string DisplayName() => "Coordinate Table To Line Of Bearing";

		/// <summary>
		/// <para>Tool Name : CoordinateTableToLineOfBearing</para>
		/// </summary>
		public override string ToolName() => "CoordinateTableToLineOfBearing";

		/// <summary>
		/// <para>Tool Excute Name : defense.CoordinateTableToLineOfBearing</para>
		/// </summary>
		public override string ExcuteName() => "defense.CoordinateTableToLineOfBearing";

		/// <summary>
		/// <para>Toolbox Display Name : Defense Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Defense Tools";

		/// <summary>
		/// <para>Toolbox Alise : defense</para>
		/// </summary>
		public override string ToolboxAlise() => "defense";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, OutFeatureClass, XOrLonField, BearingField, DistanceField, InCoordinateFormat, BearingUnits!, DistanceUnits!, YOrLatField!, LineType!, CoordinateSystem! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table containing the source coordinates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Bearing Lines Feature Class</para>
		/// <para>The feature class containing the output lines of bearing.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>X Field (longitude, UTM, MGRS, USNG, GARS, GEOREF)</para>
		/// <para>The field in the input table containing the x or longitude coordinates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object XOrLonField { get; set; }

		/// <summary>
		/// <para>Bearing Field</para>
		/// <para>The field in the input table containing the bearing values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object BearingField { get; set; }

		/// <summary>
		/// <para>Distance Field</para>
		/// <para>The field in the input table containing the distance values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object DistanceField { get; set; }

		/// <summary>
		/// <para>Input Coordinate Format</para>
		/// <para>Specifies the format of the input table coordinates.</para>
		/// <para>Decimal Degrees - One Field—Coordinates will be formatted in a decimal degrees coordinate pair stored in a single field with coordinates separated by a space, comma, or slash.</para>
		/// <para>Decimal Degrees - Two Fields—Coordinates will be formatted in a decimal degrees coordinate pair stored in two table fields. This is the default.</para>
		/// <para>Degrees and Decimal Minutes - One Field—Coordinates will be formatted in a degrees and decimal minutes coordinate pair stored in a single table field with coordinates separated by a space, comma, or slash.</para>
		/// <para>Degrees and Decimal Minutes - Two Fields—Coordinates will be formatted in a degrees and decimal minutes coordinate pair stored in two table fields.</para>
		/// <para>Degrees, Minutes, and Seconds - One Field—Coordinates will be formatted in a degrees, minutes, and seconds coordinate pair stored in a single table field with coordinates separated by a space, comma, or slash.</para>
		/// <para>Degrees, Minutes, and Seconds - Two Fields—Coordinates will be formatted in a degrees, minutes, and seconds coordinate pair stored in two table fields.</para>
		/// <para>Global Area Reference System—Coordinates will be formatted in Global Area Reference System.</para>
		/// <para>World Geographic Reference System— Coordinates will be formatted in World Geographic Reference System.</para>
		/// <para>Universal Transverse Mercator Bands—Coordinates will be formatted in Universal Transverse Mercator coordinate bands.</para>
		/// <para>Universal Transverse Mercator Zones—Coordinates will be formatted in Universal Transverse Mercator coordinate zones.</para>
		/// <para>United States National Grid—Coordinates will be formatted in United States National Grid.</para>
		/// <para>Military Grid Reference System—Coordinates will be formatted in Military Grid Reference System.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InCoordinateFormat { get; set; } = "DD_2";

		/// <summary>
		/// <para>Bearing Units</para>
		/// <para>Specifies the unit of measurement for the bearing angles.</para>
		/// <para>Degrees—The angle will be degrees. This is the default.</para>
		/// <para>Mils—The angle will be mils.</para>
		/// <para>Radians—The angle will be radians.</para>
		/// <para>Gradians—The angle will be gradians.</para>
		/// <para><see cref="BearingUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Units Options")]
		public object? BearingUnits { get; set; } = "DEGREES";

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>Specifies the units of measurement for the distance.</para>
		/// <para>Meters—The unit will be meters. This is the default.</para>
		/// <para>Kilometers—The unit will be kilometers.</para>
		/// <para>Miles—The unit will be miles.</para>
		/// <para>Nautical miles—The unit will be nautical miles.</para>
		/// <para>Feet—The unit will be feet.</para>
		/// <para>US survey feet—The unit will be U.S. survey feet.</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Units Options")]
		public object? DistanceUnits { get; set; } = "METERS";

		/// <summary>
		/// <para>Y Field (latitude)</para>
		/// <para>The field in the input table containing the y or latitude coordinates.</para>
		/// <para>The Y Field (latitude) parameter is used when the Input Coordinate Format parameter is set to Decimal Degrees - Two Fields, Degrees and Decimal Minutes - Two Fields, or Degrees Minutes and Seconds - Two Fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object? YOrLatField { get; set; }

		/// <summary>
		/// <para>Line Type</para>
		/// <para>Specifies the output line type.</para>
		/// <para>Geodesic line—The shortest distance between any two points on the earth&apos;s spheroidal surface (ellipsoid) will be used. This is the default.</para>
		/// <para>Great circle line—The line on a spheroid (ellipsoid) defined by the intersection of a plane passing through the center of the spheroid will be used.</para>
		/// <para>Rhumb line—A line of constant bearing or azimuth will be used.</para>
		/// <para>Normal section—A normal plane to the earth&apos;s ellipsoidal surface containing the start and end points will be used.</para>
		/// <para><see cref="LineTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LineType { get; set; } = "GEODESIC";

		/// <summary>
		/// <para>Output Coordinate System</para>
		/// <para>The spatial reference of the output feature class. The default is GCS_WGS_1984.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object? CoordinateSystem { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CoordinateTableToLineOfBearing SetEnviroment(object? geographicTransformations = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Bearing Units</para>
		/// </summary>
		public enum BearingUnitsEnum 
		{
			/// <summary>
			/// <para>Degrees—The angle will be degrees. This is the default.</para>
			/// </summary>
			[GPValue("DEGREES")]
			[Description("Degrees")]
			Degrees,

			/// <summary>
			/// <para>Mils—The angle will be mils.</para>
			/// </summary>
			[GPValue("MILS")]
			[Description("Mils")]
			Mils,

			/// <summary>
			/// <para>Radians—The angle will be radians.</para>
			/// </summary>
			[GPValue("RADS")]
			[Description("Radians")]
			Radians,

			/// <summary>
			/// <para>Gradians—The angle will be gradians.</para>
			/// </summary>
			[GPValue("GRADS")]
			[Description("Gradians")]
			Gradians,

		}

		/// <summary>
		/// <para>Distance Units</para>
		/// </summary>
		public enum DistanceUnitsEnum 
		{
			/// <summary>
			/// <para>Meters—The unit will be meters. This is the default.</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Kilometers—The unit will be kilometers.</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>Miles—The unit will be miles.</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para>Nautical miles—The unit will be nautical miles.</para>
			/// </summary>
			[GPValue("NAUTICAL_MILES")]
			[Description("Nautical miles")]
			Nautical_miles,

			/// <summary>
			/// <para>Feet—The unit will be feet.</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para>US survey feet—The unit will be U.S. survey feet.</para>
			/// </summary>
			[GPValue("US_SURVEY_FEET")]
			[Description("US survey feet")]
			US_survey_feet,

		}

		/// <summary>
		/// <para>Line Type</para>
		/// </summary>
		public enum LineTypeEnum 
		{
			/// <summary>
			/// <para>Geodesic line—The shortest distance between any two points on the earth&apos;s spheroidal surface (ellipsoid) will be used. This is the default.</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("Geodesic line")]
			Geodesic_line,

			/// <summary>
			/// <para>Great circle line—The line on a spheroid (ellipsoid) defined by the intersection of a plane passing through the center of the spheroid will be used.</para>
			/// </summary>
			[GPValue("GREAT_CIRCLE")]
			[Description("Great circle line")]
			Great_circle_line,

			/// <summary>
			/// <para>Rhumb line—A line of constant bearing or azimuth will be used.</para>
			/// </summary>
			[GPValue("RHUMB_LINE")]
			[Description("Rhumb line")]
			Rhumb_line,

			/// <summary>
			/// <para>Normal section—A normal plane to the earth&apos;s ellipsoidal surface containing the start and end points will be used.</para>
			/// </summary>
			[GPValue("NORMAL_SECTION")]
			[Description("Normal section")]
			Normal_section,

		}

#endregion
	}
}
