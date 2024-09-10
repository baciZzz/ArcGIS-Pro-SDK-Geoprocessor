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
	/// <para>Generate Coordinate Notations</para>
	/// <para>Converts source coordinates in a table to multiple coordinate formats.</para>
	/// </summary>
	public class GenerateCoordinateNotations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The table containing the source coordinates.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>The output table containing the converted coordinates.</para>
		/// </param>
		/// <param name="XOrLonField">
		/// <para>X Field (longitude, UTM, MGRS, USNG, GARS, GEOREF)</para>
		/// <para>The field in the input table containing the x or longitude coordinates.</para>
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
		public GenerateCoordinateNotations(object InTable, object OutTable, object XOrLonField, object InCoordinateFormat)
		{
			this.InTable = InTable;
			this.OutTable = OutTable;
			this.XOrLonField = XOrLonField;
			this.InCoordinateFormat = InCoordinateFormat;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Coordinate Notations</para>
		/// </summary>
		public override string DisplayName() => "Generate Coordinate Notations";

		/// <summary>
		/// <para>Tool Name : GenerateCoordinateNotations</para>
		/// </summary>
		public override string ToolName() => "GenerateCoordinateNotations";

		/// <summary>
		/// <para>Tool Excute Name : defense.GenerateCoordinateNotations</para>
		/// </summary>
		public override string ExcuteName() => "defense.GenerateCoordinateNotations";

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
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, OutTable, XOrLonField, InCoordinateFormat, YOrLatField, CoordinateSystem };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The table containing the source coordinates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The output table containing the converted coordinates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>X Field (longitude, UTM, MGRS, USNG, GARS, GEOREF)</para>
		/// <para>The field in the input table containing the x or longitude coordinates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object XOrLonField { get; set; }

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
		/// <para>Y Field (latitude)</para>
		/// <para>The field in the input table containing the y or latitude coordinates.</para>
		/// <para>The Y Field (latitude) parameter is used when the Input Coordinate Format parameter is set to Decimal Degrees - Two Fields, Degrees and Decimal Minutes - Two Fields, or Degrees Minutes and Seconds - Two Fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object YOrLatField { get; set; }

		/// <summary>
		/// <para>Output Coordinate System</para>
		/// <para>The spatial reference of the coordinates in the output table. The default is GCS_WGS_1984.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object CoordinateSystem { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateCoordinateNotations SetEnviroment(object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
