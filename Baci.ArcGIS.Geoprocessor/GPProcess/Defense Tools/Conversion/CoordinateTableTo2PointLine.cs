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
	/// <para>Coordinate Table To 2-Point Line</para>
	/// <para>Creates 2-point line features from coordinates stored in a table.</para>
	/// </summary>
	public class CoordinateTableTo2PointLine : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The table containing the source coordinates.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Line Feature Class</para>
		/// <para>The feature class containing the output line features.</para>
		/// </param>
		/// <param name="StartXOrLonField">
		/// <para>Start X Field (longitude, UTM, MGRS, USNG, GARS, GEOREF)</para>
		/// <para>The field in the input table containing the starting x or longitude coordinates.</para>
		/// </param>
		/// <param name="EndXOrLonField">
		/// <para>End X Field (longitude, UTM, MGRS, USNG, GARS, GEOREF)</para>
		/// <para>The field in the input table containing the ending x or longitude coordinates.</para>
		/// </param>
		/// <param name="InCoordinateFormat">
		/// <para>Input Coordinate Format</para>
		/// <para>Specifies the format of the point coordinates.</para>
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
		public CoordinateTableTo2PointLine(object InTable, object OutFeatureClass, object StartXOrLonField, object EndXOrLonField, object InCoordinateFormat)
		{
			this.InTable = InTable;
			this.OutFeatureClass = OutFeatureClass;
			this.StartXOrLonField = StartXOrLonField;
			this.EndXOrLonField = EndXOrLonField;
			this.InCoordinateFormat = InCoordinateFormat;
		}

		/// <summary>
		/// <para>Tool Display Name : Coordinate Table To 2-Point Line</para>
		/// </summary>
		public override string DisplayName => "Coordinate Table To 2-Point Line";

		/// <summary>
		/// <para>Tool Name : CoordinateTableTo2PointLine</para>
		/// </summary>
		public override string ToolName => "CoordinateTableTo2PointLine";

		/// <summary>
		/// <para>Tool Excute Name : defense.CoordinateTableTo2PointLine</para>
		/// </summary>
		public override string ExcuteName => "defense.CoordinateTableTo2PointLine";

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
		public override string[] ValidEnvironments => new string[] { "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTable, OutFeatureClass, StartXOrLonField, EndXOrLonField, InCoordinateFormat, StartYOrLatField!, EndYOrLatField!, LineType!, CoordinateSystem! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table containing the source coordinates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Line Feature Class</para>
		/// <para>The feature class containing the output line features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Start X Field (longitude, UTM, MGRS, USNG, GARS, GEOREF)</para>
		/// <para>The field in the input table containing the starting x or longitude coordinates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object StartXOrLonField { get; set; }

		/// <summary>
		/// <para>End X Field (longitude, UTM, MGRS, USNG, GARS, GEOREF)</para>
		/// <para>The field in the input table containing the ending x or longitude coordinates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object EndXOrLonField { get; set; }

		/// <summary>
		/// <para>Input Coordinate Format</para>
		/// <para>Specifies the format of the point coordinates.</para>
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
		/// <para>Start Y Field (latitude)</para>
		/// <para>The field in the input table containing the starting y or latitude coordinates.</para>
		/// <para>The Start Y Field (latitude) parameter is used when the Input Coordinate Format parameter is set to Decimal Degrees - Two Fields, Degrees and Decimal Minutes - Two Fields, or Degrees Minutes and Seconds - Two Fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object? StartYOrLatField { get; set; }

		/// <summary>
		/// <para>End Y Field (latitude)</para>
		/// <para>The field in the input table containing the ending y or latitude coordinates.</para>
		/// <para>The End Y Field (latitude) parameter is used when the Input Coordinate Format parameter is set to Decimal Degrees - Two Fields, Degrees and Decimal Minutes - Two Fields, or Degrees Minutes and Seconds - Two Fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object? EndYOrLatField { get; set; }

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
		public CoordinateTableTo2PointLine SetEnviroment(object? geographicTransformations = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

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
