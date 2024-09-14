using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CrimeAnalysisandSafetyTools
{
	/// <summary>
	/// <para>Cell Site Records To Feature Class</para>
	/// <para>Cell Site Records To Feature Class</para>
	/// <para>Creates cell site points and sector polygons based on input latitude, longitude, azimuth, beamwidth, and radius information from a cell site table.</para>
	/// </summary>
	public class CellSiteRecordsToFeatureClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Cell Site Table</para>
		/// <para>The input table containing cell site information provided by the wireless network provider.</para>
		/// </param>
		/// <param name="OutSiteFeatureClass">
		/// <para>Output Cell Site Points</para>
		/// <para>The feature class containing the output cell site points.</para>
		/// </param>
		/// <param name="OutSectorFeatureClass">
		/// <para>Output Cell Site Sectors</para>
		/// <para>The feature class containing the output cell site sectors.</para>
		/// </param>
		/// <param name="IdFields">
		/// <para>Cell Sector ID Fields</para>
		/// <para>Specifies the unique ID field type and the fields that will be added to the output feature.</para>
		/// <para>Use the Unique ID value when the Input Cell Site Table parameter has a unique identifier for all cell sector antennas. Use a combination of other ID Type values when the Input Cell Site Table parameter does not contain a universal unique identifier for all cell sector antennas.</para>
		/// <para>ID Type—The field name to be included in the output feature classes.</para>
		/// <para>Field—The name of the fields that uniquely identify the cell sector antennas. These will be added to the output feature class.</para>
		/// <para>ID Type options are as follows:</para>
		/// <para>Unique ID—Uniquely identifies a cell sector antenna</para>
		/// <para>Site ID—Uniquely identifies a cell site</para>
		/// <para>Sector ID—Uniquely identifies a cell sector</para>
		/// <para>Switch ID—Uniquely identifies a wireless network switch</para>
		/// <para>LAC ID—Uniquely identifies the Location Area Code</para>
		/// <para>Cascade ID—Uniquely identifies the sector in the wireless network cascade</para>
		/// <para>Cell ID—Identifies the sector within an Location Area Code</para>
		/// </param>
		/// <param name="XField">
		/// <para>X Field</para>
		/// <para>The field in the input table that contains the x-coordinate of the cell site.</para>
		/// </param>
		/// <param name="YField">
		/// <para>Y Field</para>
		/// <para>The field in the input table that contains the y-coordinate of the cell site.</para>
		/// </param>
		/// <param name="InCoordinateSystem">
		/// <para>Input Coordinate System</para>
		/// <para>The coordinate system of the coordinates specified in the X Field and Y Field parameters.</para>
		/// </param>
		/// <param name="OutCoordinateSystem">
		/// <para>Output Projected Coordinate System</para>
		/// <para>The projected coordinate system of the output sites and sectors.</para>
		/// </param>
		public CellSiteRecordsToFeatureClass(object InTable, object OutSiteFeatureClass, object OutSectorFeatureClass, object IdFields, object XField, object YField, object InCoordinateSystem, object OutCoordinateSystem)
		{
			this.InTable = InTable;
			this.OutSiteFeatureClass = OutSiteFeatureClass;
			this.OutSectorFeatureClass = OutSectorFeatureClass;
			this.IdFields = IdFields;
			this.XField = XField;
			this.YField = YField;
			this.InCoordinateSystem = InCoordinateSystem;
			this.OutCoordinateSystem = OutCoordinateSystem;
		}

		/// <summary>
		/// <para>Tool Display Name : Cell Site Records To Feature Class</para>
		/// </summary>
		public override string DisplayName() => "Cell Site Records To Feature Class";

		/// <summary>
		/// <para>Tool Name : CellSiteRecordsToFeatureClass</para>
		/// </summary>
		public override string ToolName() => "CellSiteRecordsToFeatureClass";

		/// <summary>
		/// <para>Tool Excute Name : ca.CellSiteRecordsToFeatureClass</para>
		/// </summary>
		public override string ExcuteName() => "ca.CellSiteRecordsToFeatureClass";

		/// <summary>
		/// <para>Toolbox Display Name : Crime Analysis and Safety Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Crime Analysis and Safety Tools";

		/// <summary>
		/// <para>Toolbox Alise : ca</para>
		/// </summary>
		public override string ToolboxAlise() => "ca";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "maintainAttachments", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, OutSiteFeatureClass, OutSectorFeatureClass, IdFields, XField, YField, InCoordinateSystem, OutCoordinateSystem, AzimuthField, DefaultAzimuth, BeamwidthField, BeamwidthType, DefaultBeamwidth, RadiusField, RadiusUnit, DefaultRadiusLength };

		/// <summary>
		/// <para>Input Cell Site Table</para>
		/// <para>The input table containing cell site information provided by the wireless network provider.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Cell Site Points</para>
		/// <para>The feature class containing the output cell site points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutSiteFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Cell Site Sectors</para>
		/// <para>The feature class containing the output cell site sectors.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutSectorFeatureClass { get; set; }

		/// <summary>
		/// <para>Cell Sector ID Fields</para>
		/// <para>Specifies the unique ID field type and the fields that will be added to the output feature.</para>
		/// <para>Use the Unique ID value when the Input Cell Site Table parameter has a unique identifier for all cell sector antennas. Use a combination of other ID Type values when the Input Cell Site Table parameter does not contain a universal unique identifier for all cell sector antennas.</para>
		/// <para>ID Type—The field name to be included in the output feature classes.</para>
		/// <para>Field—The name of the fields that uniquely identify the cell sector antennas. These will be added to the output feature class.</para>
		/// <para>ID Type options are as follows:</para>
		/// <para>Unique ID—Uniquely identifies a cell sector antenna</para>
		/// <para>Site ID—Uniquely identifies a cell site</para>
		/// <para>Sector ID—Uniquely identifies a cell sector</para>
		/// <para>Switch ID—Uniquely identifies a wireless network switch</para>
		/// <para>LAC ID—Uniquely identifies the Location Area Code</para>
		/// <para>Cascade ID—Uniquely identifies the sector in the wireless network cascade</para>
		/// <para>Cell ID—Identifies the sector within an Location Area Code</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object IdFields { get; set; }

		/// <summary>
		/// <para>X Field</para>
		/// <para>The field in the input table that contains the x-coordinate of the cell site.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object XField { get; set; }

		/// <summary>
		/// <para>Y Field</para>
		/// <para>The field in the input table that contains the y-coordinate of the cell site.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		public object YField { get; set; }

		/// <summary>
		/// <para>Input Coordinate System</para>
		/// <para>The coordinate system of the coordinates specified in the X Field and Y Field parameters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCoordinateSystem()]
		public object InCoordinateSystem { get; set; } = "GEOGCS[\"GCS_WGS_1984\",DATUM[\"D_WGS_1984\",SPHEROID[\"WGS_1984\",6378137.0,298.257223563]],PRIMEM[\"Greenwich\",0.0],UNIT[\"Degree\",0.0174532925199433]]";

		/// <summary>
		/// <para>Output Projected Coordinate System</para>
		/// <para>The projected coordinate system of the output sites and sectors.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCoordinateSystem()]
		public object OutCoordinateSystem { get; set; }

		/// <summary>
		/// <para>Azimuth Field</para>
		/// <para>The field in the input table that contains the direction of the antenna signal (cell sector).</para>
		/// <para>The azimuth field values must be expressed in positive degrees from 0 to 360, measured clockwise from north.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text", "Float", "Double")]
		public object AzimuthField { get; set; }

		/// <summary>
		/// <para>Default Start Azimuth</para>
		/// <para>The starting azimuth value of the antenna signals (cell sectors) to be used when the azimuth field is not specified.</para>
		/// <para>For example, if three cell sectors exist at the same location and this parameter is set to 0 degrees. The first sector is generated with an azimuth of 0 degrees, the second sector is generated with an azimuth of 120 degrees, and the third sector is generated with an azimuth of 240 degrees.</para>
		/// <para>This parameter is used when the azimuth field is not specified.</para>
		/// <para>The azimuth value must be expressed in positive degrees from 0 to 360. The default is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 360)]
		public object DefaultAzimuth { get; set; } = "0";

		/// <summary>
		/// <para>Beamwidth Field</para>
		/// <para>The field in the input table containing the full or half beamwidth value (angle) of the antenna signal (cell sector).</para>
		/// <para>The beamwidth must be expressed in positive degrees from 0 to 360. Use 360 for omnidirectional antennas.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text", "Float", "Double")]
		public object BeamwidthField { get; set; }

		/// <summary>
		/// <para>Beamwidth Type</para>
		/// <para>Specifies the type of beamwidth value represented in the input cell type table.</para>
		/// <para>Full Beamwidth—Full beamwidth is represented in the input. This is the default.</para>
		/// <para>Half Beamwidth—Half beamwidth is represented in the input</para>
		/// <para><see cref="BeamwidthTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BeamwidthType { get; set; } = "FULL_BEAMWIDTH";

		/// <summary>
		/// <para>Default Beamwidth</para>
		/// <para>The beamwidth (in degrees) of the antenna signal (cell sector) to be used when the beamwidth field is not specified.</para>
		/// <para>The default is 90 degrees.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 360)]
		public object DefaultBeamwidth { get; set; } = "90";

		/// <summary>
		/// <para>Radius Field</para>
		/// <para>The field in the input table that contains the radial length (signal distance) of the antenna signal (cell sector).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text", "Float", "Double")]
		public object RadiusField { get; set; }

		/// <summary>
		/// <para>Radius Unit</para>
		/// <para>Specifies the linear unit of measurement for the radius field..</para>
		/// <para>Kilometers—The unit will be kilometers.</para>
		/// <para>Meters—The unit will be meters.</para>
		/// <para>Miles—The unit will be miles. This is the default.</para>
		/// <para>Yards—The unit will be yards.</para>
		/// <para>Feet—The unit will be feet.</para>
		/// <para><see cref="RadiusUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object RadiusUnit { get; set; } = "MILES";

		/// <summary>
		/// <para>Default Radius Length</para>
		/// <para>The radius length (signal distance) of the antenna signal (cell sector) to be used when the radial field is not specified.</para>
		/// <para>The default is 2.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object DefaultRadiusLength { get; set; } = "2";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CellSiteRecordsToFeatureClass SetEnviroment(object MDomain = null, object MResolution = null, object MTolerance = null, object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, int? autoCommit = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, bool? qualifiedFieldNames = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Beamwidth Type</para>
		/// </summary>
		public enum BeamwidthTypeEnum 
		{
			/// <summary>
			/// <para>Full Beamwidth—Full beamwidth is represented in the input. This is the default.</para>
			/// </summary>
			[GPValue("FULL_BEAMWIDTH")]
			[Description("Full Beamwidth")]
			Full_Beamwidth,

			/// <summary>
			/// <para>Half Beamwidth—Half beamwidth is represented in the input</para>
			/// </summary>
			[GPValue("HALF_BEAMWIDTH")]
			[Description("Half Beamwidth")]
			Half_Beamwidth,

		}

		/// <summary>
		/// <para>Radius Unit</para>
		/// </summary>
		public enum RadiusUnitEnum 
		{
			/// <summary>
			/// <para>Kilometers—The unit will be kilometers.</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>Meters—The unit will be meters.</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Miles—The unit will be miles. This is the default.</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para>Yards—The unit will be yards.</para>
			/// </summary>
			[GPValue("YARDS")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para>Feet—The unit will be feet.</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("Feet")]
			Feet,

		}

#endregion
	}
}
