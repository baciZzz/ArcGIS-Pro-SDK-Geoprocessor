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
	/// <para>XY To Line</para>
	/// <para>Creates a feature class containing geodetic or planar line features from the values in a start x-coordinate field, start y-coordinate field, end x-coordinate field, and end y-coordinate field of a table.</para>
	/// </summary>
	public class XYToLine : AbstractGPProcess
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
		/// <para>The output feature class containing geodetic or planar lines.</para>
		/// </param>
		/// <param name="StartxField">
		/// <para>Start X Field</para>
		/// <para>A numerical field in the input table containing the x-coordinates (or longitudes) of the starting points of lines to be positioned in the output coordinate system specified by the Spatial Reference parameter.</para>
		/// </param>
		/// <param name="StartyField">
		/// <para>Start Y Field</para>
		/// <para>A numerical field in the input table containing the y-coordinates (or latitudes) of the starting points of lines to be positioned in the output coordinate system specified by the Spatial Reference parameter.</para>
		/// </param>
		/// <param name="EndxField">
		/// <para>End X Field</para>
		/// <para>A numerical field in the input table containing the x-coordinates (or longitudes) of the ending points of lines to be positioned in the output coordinate system specified by the Spatial Reference parameter.</para>
		/// </param>
		/// <param name="EndyField">
		/// <para>End Y Field</para>
		/// <para>A numerical field in the input table containing the y-coordinates (or latitudes) of the ending points of lines to be positioned in the output coordinate system specified by the Spatial Reference parameter.</para>
		/// </param>
		public XYToLine(object InTable, object OutFeatureclass, object StartxField, object StartyField, object EndxField, object EndyField)
		{
			this.InTable = InTable;
			this.OutFeatureclass = OutFeatureclass;
			this.StartxField = StartxField;
			this.StartyField = StartyField;
			this.EndxField = EndxField;
			this.EndyField = EndyField;
		}

		/// <summary>
		/// <para>Tool Display Name : XY To Line</para>
		/// </summary>
		public override string DisplayName => "XY To Line";

		/// <summary>
		/// <para>Tool Name : XYToLine</para>
		/// </summary>
		public override string ToolName => "XYToLine";

		/// <summary>
		/// <para>Tool Excute Name : management.XYToLine</para>
		/// </summary>
		public override string ExcuteName => "management.XYToLine";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTable, OutFeatureclass, StartxField, StartyField, EndxField, EndyField, LineType!, IdField!, SpatialReference!, Attributes! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input table. It can be a text file, CSV file, Excel file, dBASE table, or geodatabase table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing geodetic or planar lines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureclass { get; set; }

		/// <summary>
		/// <para>Start X Field</para>
		/// <para>A numerical field in the input table containing the x-coordinates (or longitudes) of the starting points of lines to be positioned in the output coordinate system specified by the Spatial Reference parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object StartxField { get; set; }

		/// <summary>
		/// <para>Start Y Field</para>
		/// <para>A numerical field in the input table containing the y-coordinates (or latitudes) of the starting points of lines to be positioned in the output coordinate system specified by the Spatial Reference parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object StartyField { get; set; }

		/// <summary>
		/// <para>End X Field</para>
		/// <para>A numerical field in the input table containing the x-coordinates (or longitudes) of the ending points of lines to be positioned in the output coordinate system specified by the Spatial Reference parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object EndxField { get; set; }

		/// <summary>
		/// <para>End Y Field</para>
		/// <para>A numerical field in the input table containing the y-coordinates (or latitudes) of the ending points of lines to be positioned in the output coordinate system specified by the Spatial Reference parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object EndyField { get; set; }

		/// <summary>
		/// <para>Line Type</para>
		/// <para>Specifies the type of line that will be constructed.</para>
		/// <para>Geodesic— A type of geodetic line that most accurately represents the shortest distance between any two points on the surface of the earth will be constructed. This is the default.</para>
		/// <para>Great circle—A type of geodetic line that represents the path between any two points along the intersection of the surface of the earth and a plane that passes through the center of the earth will be constructed. If the Spatial Reference parameter value is a spheroid-based coordinate system, the line is a great elliptic. If the Spatial Reference parameter value is a sphere-based coordinate system, the line is uniquely called a great circle—a circle of the largest radius on the spherical surface.</para>
		/// <para>Rhumb line—A type of geodetic line, also known as a loxodrome line, that represents a path between any two points on the surface of a spheroid defined by a constant azimuth from a pole will be constructed. A rhumb line is shown as a straight line in the Mercator projection.</para>
		/// <para>Normal section—A type of geodetic line that represents a path between any two points on the surface of a spheroid defined by the intersection of the spheroid surface and a plane that passes through the two points and is normal (perpendicular) to the spheroid surface at the starting point of the two points will be constructed. The normal section line from point A to point B is different from the line from point B to point A.</para>
		/// <para>Planar line—A straight line in the projected plane will be used. A planar line usually does not accurately represent the shortest distance on the surface of the earth as a geodesic line does. This option is not available for geographic coordinate systems.</para>
		/// <para><see cref="LineTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LineType { get; set; } = "GEODESIC";

		/// <summary>
		/// <para>ID</para>
		/// <para>A field in the input table. This field and the values are included in the output and can be used to join the output features with the records in the input table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object? IdField { get; set; }

		/// <summary>
		/// <para>Spatial Reference</para>
		/// <para>The spatial reference of the output feature class. The default is GCS_WGS_1984 or the input coordinate system if it is not Unknown.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object? SpatialReference { get; set; } = "{B286C06B-0879-11D2-AACA-00C04FA33C20};-450359962737.049 -450359962737.049 10000;-100000 10000;-100000 10000;0.001;0.001;0.001;IsHighPrecision";

		/// <summary>
		/// <para>Preserve attributes</para>
		/// <para>Specifies whether the remaining input fields will be added to the output feature class.</para>
		/// <para>Unchecked—The remaining input fields will not be added to the output feature class. This is the default.</para>
		/// <para>Checked—The remaining input fields will be added to the output feature class. A new field, ORIG_FID, will also be added to the output feature class to store the input feature ID values.</para>
		/// <para><see cref="AttributesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Attributes { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public XYToLine SetEnviroment(object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Line Type</para>
		/// </summary>
		public enum LineTypeEnum 
		{
			/// <summary>
			/// <para>Geodesic— A type of geodetic line that most accurately represents the shortest distance between any two points on the surface of the earth will be constructed. This is the default.</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("Geodesic")]
			Geodesic,

			/// <summary>
			/// <para>Great circle—A type of geodetic line that represents the path between any two points along the intersection of the surface of the earth and a plane that passes through the center of the earth will be constructed. If the Spatial Reference parameter value is a spheroid-based coordinate system, the line is a great elliptic. If the Spatial Reference parameter value is a sphere-based coordinate system, the line is uniquely called a great circle—a circle of the largest radius on the spherical surface.</para>
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
			/// <para>Normal section—A type of geodetic line that represents a path between any two points on the surface of a spheroid defined by the intersection of the spheroid surface and a plane that passes through the two points and is normal (perpendicular) to the spheroid surface at the starting point of the two points will be constructed. The normal section line from point A to point B is different from the line from point B to point A.</para>
			/// </summary>
			[GPValue("NORMAL_SECTION")]
			[Description("Normal section")]
			Normal_section,

			/// <summary>
			/// <para>Planar line—A straight line in the projected plane will be used. A planar line usually does not accurately represent the shortest distance on the surface of the earth as a geodesic line does. This option is not available for geographic coordinate systems.</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("Planar line")]
			Planar_line,

		}

		/// <summary>
		/// <para>Preserve attributes</para>
		/// </summary>
		public enum AttributesEnum 
		{
			/// <summary>
			/// <para>Checked—The remaining input fields will be added to the output feature class. A new field, ORIG_FID, will also be added to the output feature class to store the input feature ID values.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ATTRIBUTES")]
			ATTRIBUTES,

			/// <summary>
			/// <para>Unchecked—The remaining input fields will not be added to the output feature class. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ATTRIBUTES")]
			NO_ATTRIBUTES,

		}

#endregion
	}
}
