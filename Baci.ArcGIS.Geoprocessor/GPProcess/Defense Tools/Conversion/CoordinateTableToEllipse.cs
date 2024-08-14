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
	/// <para>Coordinate Table To Ellipse</para>
	/// <para>Creates ellipse features from coordinates stored in a table and input data values.</para>
	/// </summary>
	public class CoordinateTableToEllipse : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The table containing the source coordinates.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Ellipse Feature Class</para>
		/// <para>The feature class containing the output ellipse polygon features.</para>
		/// </param>
		/// <param name="XOrLonField">
		/// <para>X Field (longitude, UTM, MGRS, USNG, GARS, GeoRef)</para>
		/// <para>The field in the input table containing the x or longitude coordinates.</para>
		/// </param>
		/// <param name="MajorField">
		/// <para>Major Field</para>
		/// <para>The field in the input table containing the major axis values.</para>
		/// </param>
		/// <param name="MinorField">
		/// <para>Minor Field</para>
		/// <para>The field in the input table containing the minor axis values.</para>
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
		public CoordinateTableToEllipse(object InTable, object OutFeatureClass, object XOrLonField, object MajorField, object MinorField, object InCoordinateFormat)
		{
			this.InTable = InTable;
			this.OutFeatureClass = OutFeatureClass;
			this.XOrLonField = XOrLonField;
			this.MajorField = MajorField;
			this.MinorField = MinorField;
			this.InCoordinateFormat = InCoordinateFormat;
		}

		/// <summary>
		/// <para>Tool Display Name : Coordinate Table To Ellipse</para>
		/// </summary>
		public override string DisplayName => "Coordinate Table To Ellipse";

		/// <summary>
		/// <para>Tool Name : CoordinateTableToEllipse</para>
		/// </summary>
		public override string ToolName => "CoordinateTableToEllipse";

		/// <summary>
		/// <para>Tool Excute Name : defense.CoordinateTableToEllipse</para>
		/// </summary>
		public override string ExcuteName => "defense.CoordinateTableToEllipse";

		/// <summary>
		/// <para>Toolbox Display Name : Defense Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Defense Tools";

		/// <summary>
		/// <para>Toolbox Alise : defense</para>
		/// </summary>
		public override string ToolboxAlise => "defense";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTable, OutFeatureClass, XOrLonField, MajorField, MinorField, InCoordinateFormat, DistanceUnits, YOrLatField, AzimuthField, AzimuthUnits, CoordinateSystem };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table containing the source coordinates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Ellipse Feature Class</para>
		/// <para>The feature class containing the output ellipse polygon features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>X Field (longitude, UTM, MGRS, USNG, GARS, GeoRef)</para>
		/// <para>The field in the input table containing the x or longitude coordinates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object XOrLonField { get; set; }

		/// <summary>
		/// <para>Major Field</para>
		/// <para>The field in the input table containing the major axis values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object MajorField { get; set; }

		/// <summary>
		/// <para>Minor Field</para>
		/// <para>The field in the input table containing the minor axis values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object MinorField { get; set; }

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
		/// <para>Distance Units</para>
		/// <para>Specifies the unit of measurement for the major and minor axes.</para>
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
		public object DistanceUnits { get; set; } = "METERS";

		/// <summary>
		/// <para>Y Field (latitude)</para>
		/// <para>The field in the input table containing the latitude coordinates.</para>
		/// <para>The Y Field (latitude) parameter is used when the Input Coordinate Format parameter is set to Decimal Degrees - Two Fields, Degrees and Decimal Minutes - Two Fields, or Degrees Minutes and Seconds - Two Fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object YOrLatField { get; set; }

		/// <summary>
		/// <para>Azimuth Field</para>
		/// <para>The field in the input table containing the ellipse azimuth values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object AzimuthField { get; set; }

		/// <summary>
		/// <para>Azimuth Units</para>
		/// <para>Specifies the unit of measurement for the azimuth field.</para>
		/// <para>Degrees—The angle will be degrees. This is the default.</para>
		/// <para>Mils—The angle will be mils.</para>
		/// <para>Radians—The angle will be radians.</para>
		/// <para>Gradians—The angle will be gradians.</para>
		/// <para><see cref="AzimuthUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Units Options")]
		public object AzimuthUnits { get; set; } = "DEGREES";

		/// <summary>
		/// <para>Output Coordinate System</para>
		/// <para>The spatial reference of the output feature class. The default is GCS_WGS_1984.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object CoordinateSystem { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CoordinateTableToEllipse SetEnviroment(object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

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
		/// <para>Azimuth Units</para>
		/// </summary>
		public enum AzimuthUnitsEnum 
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

#endregion
	}
}
