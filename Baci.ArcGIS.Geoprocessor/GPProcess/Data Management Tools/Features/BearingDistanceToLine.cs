using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Bearing Distance To Line</para>
	/// <para>Creates a feature class containing geodetic line features constructed based on the values in an x-coordinate field, y-coordinate field, bearing field, and distance field of a table.</para>
	/// </summary>
	public class BearingDistanceToLine : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The input table. It can be a text file, CSV file, Excel file, dBASE table, or geodatabase table.</para>
		/// </param>
		/// <param name="OutFeatureclass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing densified geodetic lines.</para>
		/// </param>
		/// <param name="XField">
		/// <para>X Field</para>
		/// <para>A numerical field in the input table containing the x-coordinates (or longitudes) of the starting points of lines to be positioned in the output coordinate system specified by the Spatial Reference parameter.</para>
		/// </param>
		/// <param name="YField">
		/// <para>Y Field</para>
		/// <para>A numerical field in the input table containing the y-coordinates (or latitudes) of the starting points of lines to be positioned in the output coordinate system specified by the Spatial Reference parameter.</para>
		/// </param>
		/// <param name="DistanceField">
		/// <para>Distance Field</para>
		/// <para>A numerical field in the input table containing the distances from the starting points for creating the output lines.</para>
		/// </param>
		/// <param name="DistanceUnits">
		/// <para>Distance Units</para>
		/// <para>Specifies the units that will be used for the Distance Field parameter.</para>
		/// <para>Meters—The units will be meters.</para>
		/// <para>Kilometers—The units will be kilometers.</para>
		/// <para>Miles—The units will be miles.</para>
		/// <para>Nautical miles—The units will be nautical miles.</para>
		/// <para>Feet—The units will be feet.</para>
		/// <para>U.S. survey feet—The units will be U.S. survey feet.</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </param>
		/// <param name="BearingField">
		/// <para>Bearing Field</para>
		/// <para>A numerical field in the input table containing bearing angle values for the output line rotation. The angles are measured clockwise from north.</para>
		/// </param>
		/// <param name="BearingUnits">
		/// <para>Bearing Units</para>
		/// <para>Specifies the units of the Bearing Field parameter values.</para>
		/// <para>Decimal degrees— The units will be decimal degrees. This is the default.</para>
		/// <para>Mils—The units will be mils.</para>
		/// <para>Radians—The units will be radians.</para>
		/// <para>Gradians—The units will be gradians.</para>
		/// <para><see cref="BearingUnitsEnum"/></para>
		/// </param>
		public BearingDistanceToLine(object InTable, object OutFeatureclass, object XField, object YField, object DistanceField, object DistanceUnits, object BearingField, object BearingUnits)
		{
			this.InTable = InTable;
			this.OutFeatureclass = OutFeatureclass;
			this.XField = XField;
			this.YField = YField;
			this.DistanceField = DistanceField;
			this.DistanceUnits = DistanceUnits;
			this.BearingField = BearingField;
			this.BearingUnits = BearingUnits;
		}

		/// <summary>
		/// <para>Tool Display Name : Bearing Distance To Line</para>
		/// </summary>
		public override string DisplayName() => "Bearing Distance To Line";

		/// <summary>
		/// <para>Tool Name : BearingDistanceToLine</para>
		/// </summary>
		public override string ToolName() => "BearingDistanceToLine";

		/// <summary>
		/// <para>Tool Excute Name : management.BearingDistanceToLine</para>
		/// </summary>
		public override string ExcuteName() => "management.BearingDistanceToLine";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, OutFeatureclass, XField, YField, DistanceField, DistanceUnits, BearingField, BearingUnits, LineType, IdField, SpatialReference, Attributes };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input table. It can be a text file, CSV file, Excel file, dBASE table, or geodatabase table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing densified geodetic lines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureclass { get; set; }

		/// <summary>
		/// <para>X Field</para>
		/// <para>A numerical field in the input table containing the x-coordinates (or longitudes) of the starting points of lines to be positioned in the output coordinate system specified by the Spatial Reference parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long")]
		public object XField { get; set; }

		/// <summary>
		/// <para>Y Field</para>
		/// <para>A numerical field in the input table containing the y-coordinates (or latitudes) of the starting points of lines to be positioned in the output coordinate system specified by the Spatial Reference parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long")]
		public object YField { get; set; }

		/// <summary>
		/// <para>Distance Field</para>
		/// <para>A numerical field in the input table containing the distances from the starting points for creating the output lines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long")]
		public object DistanceField { get; set; }

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>Specifies the units that will be used for the Distance Field parameter.</para>
		/// <para>Meters—The units will be meters.</para>
		/// <para>Kilometers—The units will be kilometers.</para>
		/// <para>Miles—The units will be miles.</para>
		/// <para>Nautical miles—The units will be nautical miles.</para>
		/// <para>Feet—The units will be feet.</para>
		/// <para>U.S. survey feet—The units will be U.S. survey feet.</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceUnits { get; set; } = "METERS";

		/// <summary>
		/// <para>Bearing Field</para>
		/// <para>A numerical field in the input table containing bearing angle values for the output line rotation. The angles are measured clockwise from north.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long")]
		public object BearingField { get; set; }

		/// <summary>
		/// <para>Bearing Units</para>
		/// <para>Specifies the units of the Bearing Field parameter values.</para>
		/// <para>Decimal degrees— The units will be decimal degrees. This is the default.</para>
		/// <para>Mils—The units will be mils.</para>
		/// <para>Radians—The units will be radians.</para>
		/// <para>Gradians—The units will be gradians.</para>
		/// <para><see cref="BearingUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BearingUnits { get; set; } = "DEGREES";

		/// <summary>
		/// <para>Line Type</para>
		/// <para>Specifies the type of geodetic line to construct.</para>
		/// <para>Geodesic— A type of geodetic line that most accurately represents the shortest distance between any two points on the surface of the earth will be constructed. The mathematical definition of the geodesic line is quite lengthy and complex and is therefore omitted here. This is the default.</para>
		/// <para>Great circle—A type of geodetic line that represents the path between any two points along the intersection of the surface of the earth and a plane that passes through the center of the earth will be constructed. Depending on the output coordinate system specified by the Spatial Reference parameter, in a spheroid-based coordinate system, the line is a great elliptic; in a sphere-based coordinate system, the line is uniquely called a great circle—a circle of the largest radius on the spherical surface.</para>
		/// <para>Rhumb line—A type of geodetic line, also known as a loxodrome line, that represents a path between any two points on the surface of a spheroid defined by a constant azimuth from a pole will be constructed. A rhumb line is shown as a straight line in the Mercator projection.</para>
		/// <para>Normal section—A type of geodetic line that represents a path between any two points on the surface of a spheroid defined by the intersection of the spheroid surface and a plane that passes through the two points and is normal (perpendicular) to the spheroid surface at the starting point of the two points will be constructed. Therefore, the normal section line from point A to point B is different from the one from point B to point A.</para>
		/// <para><see cref="LineTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LineType { get; set; } = "GEODESIC";

		/// <summary>
		/// <para>ID</para>
		/// <para>A field in the input table. This field and the values are included in the output and can be used to join the output features with the records in the input table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double", "Short", "Long", "Text")]
		public object IdField { get; set; }

		/// <summary>
		/// <para>Spatial Reference</para>
		/// <para>The spatial reference of the output feature class. The default is GCS_WGS_1984 or the input coordinate system if it is not Unknown.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object SpatialReference { get; set; } = "{B286C06B-0879-11D2-AACA-00C04FA33C20};IsHighPrecision";

		/// <summary>
		/// <para>Preserve attributes</para>
		/// <para>Specifies whether the remaining input fields will be written to the output feature class.</para>
		/// <para>Unchecked—The remaining input fields will not be written to the output feature class. This is the default.</para>
		/// <para>Checked—The remaining input fields will be included in the output feature class. A new field, ORIG_FID, will also be added to the output feature class to store the input feature ID values.</para>
		/// <para><see cref="AttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Attributes { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BearingDistanceToLine SetEnviroment(object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Units</para>
		/// </summary>
		public enum DistanceUnitsEnum 
		{
			/// <summary>
			/// <para>Meters—The units will be meters.</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Kilometers—The units will be kilometers.</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>Miles—The units will be miles.</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para>Nautical miles—The units will be nautical miles.</para>
			/// </summary>
			[GPValue("NAUTICAL_MILES")]
			[Description("Nautical miles")]
			Nautical_miles,

			/// <summary>
			/// <para>Feet—The units will be feet.</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para>U.S. survey feet—The units will be U.S. survey feet.</para>
			/// </summary>
			[GPValue("US_SURVEY_FEET")]
			[Description("U.S. survey feet")]
			US_survey_feet,

		}

		/// <summary>
		/// <para>Bearing Units</para>
		/// </summary>
		public enum BearingUnitsEnum 
		{
			/// <summary>
			/// <para>Decimal degrees— The units will be decimal degrees. This is the default.</para>
			/// </summary>
			[GPValue("DEGREES")]
			[Description("Decimal degrees")]
			Decimal_degrees,

			/// <summary>
			/// <para>Mils—The units will be mils.</para>
			/// </summary>
			[GPValue("MILS")]
			[Description("Mils")]
			Mils,

			/// <summary>
			/// <para>Radians—The units will be radians.</para>
			/// </summary>
			[GPValue("RADS")]
			[Description("Radians")]
			Radians,

			/// <summary>
			/// <para>Gradians—The units will be gradians.</para>
			/// </summary>
			[GPValue("GRADS")]
			[Description("Gradians")]
			Gradians,

		}

		/// <summary>
		/// <para>Line Type</para>
		/// </summary>
		public enum LineTypeEnum 
		{
			/// <summary>
			/// <para>Geodesic— A type of geodetic line that most accurately represents the shortest distance between any two points on the surface of the earth will be constructed. The mathematical definition of the geodesic line is quite lengthy and complex and is therefore omitted here. This is the default.</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("Geodesic")]
			Geodesic,

			/// <summary>
			/// <para>Great circle—A type of geodetic line that represents the path between any two points along the intersection of the surface of the earth and a plane that passes through the center of the earth will be constructed. Depending on the output coordinate system specified by the Spatial Reference parameter, in a spheroid-based coordinate system, the line is a great elliptic; in a sphere-based coordinate system, the line is uniquely called a great circle—a circle of the largest radius on the spherical surface.</para>
			/// </summary>
			[GPValue("GREAT_CIRCLE")]
			[Description("Great circle")]
			Great_circle,

			/// <summary>
			/// <para>Rhumb line—A type of geodetic line, also known as a loxodrome line, that represents a path between any two points on the surface of a spheroid defined by a constant azimuth from a pole will be constructed. A rhumb line is shown as a straight line in the Mercator projection.</para>
			/// </summary>
			[GPValue("RHUMB_LINE")]
			[Description("Rhumb line")]
			Rhumb_line,

			/// <summary>
			/// <para>Normal section—A type of geodetic line that represents a path between any two points on the surface of a spheroid defined by the intersection of the spheroid surface and a plane that passes through the two points and is normal (perpendicular) to the spheroid surface at the starting point of the two points will be constructed. Therefore, the normal section line from point A to point B is different from the one from point B to point A.</para>
			/// </summary>
			[GPValue("NORMAL_SECTION")]
			[Description("Normal section")]
			Normal_section,

		}

		/// <summary>
		/// <para>Preserve attributes</para>
		/// </summary>
		public enum AttributesEnum 
		{
			/// <summary>
			/// <para>Checked—The remaining input fields will be included in the output feature class. A new field, ORIG_FID, will also be added to the output feature class to store the input feature ID values.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ATTRIBUTES")]
			ATTRIBUTES,

			/// <summary>
			/// <para>Unchecked—The remaining input fields will not be written to the output feature class. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ATTRIBUTES")]
			NO_ATTRIBUTES,

		}

#endregion
	}
}
