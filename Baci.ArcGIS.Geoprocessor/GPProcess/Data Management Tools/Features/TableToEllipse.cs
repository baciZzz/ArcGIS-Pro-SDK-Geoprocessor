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
	/// <para>Table To Ellipse</para>
	/// <para>Creates a feature class containing geodetic ellipse features constructed based on the values in an x-coordinate field, y-coordinate field, major-axis field, minor-axis field, and azimuth field of a table.</para>
	/// </summary>
	public class TableToEllipse : AbstractGPProcess
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
		/// <para>The output feature class containing geodetic ellipses as densified polylines.</para>
		/// </param>
		/// <param name="XField">
		/// <para>X Field</para>
		/// <para>A numerical field in the input table containing the x-coordinates (or longitudes) of the center points of ellipses to be positioned in the output coordinate system specified by the Spatial Reference parameter.</para>
		/// </param>
		/// <param name="YField">
		/// <para>Y Field</para>
		/// <para>A numerical field in the input table containing the y-coordinates (or latitudes) of the center points of ellipses to be positioned in the output coordinate system specified by the Spatial Reference parameter.</para>
		/// </param>
		/// <param name="MajorField">
		/// <para>Major Field</para>
		/// <para>A numerical field in the input table containing major axis lengths of the ellipses.</para>
		/// </param>
		/// <param name="MinorField">
		/// <para>Minor Field</para>
		/// <para>A numerical field in the input table containing minor axis lengths of the ellipses.</para>
		/// </param>
		/// <param name="DistanceUnits">
		/// <para>Distance Units</para>
		/// <para>Specifies the units that will be used for the Major Field and Minor Field parameters.</para>
		/// <para>Meters—The units will be meters.</para>
		/// <para>Kilometers—The units will be kilometers.</para>
		/// <para>Miles—The units will be miles.</para>
		/// <para>Nautical miles—The units will be nautical miles.</para>
		/// <para>Feet—The units will be feet.</para>
		/// <para>U.S. survey feet—The units will be U.S. survey feet.</para>
		/// <para><see cref="DistanceUnitsEnum"/></para>
		/// </param>
		public TableToEllipse(object InTable, object OutFeatureclass, object XField, object YField, object MajorField, object MinorField, object DistanceUnits)
		{
			this.InTable = InTable;
			this.OutFeatureclass = OutFeatureclass;
			this.XField = XField;
			this.YField = YField;
			this.MajorField = MajorField;
			this.MinorField = MinorField;
			this.DistanceUnits = DistanceUnits;
		}

		/// <summary>
		/// <para>Tool Display Name : Table To Ellipse</para>
		/// </summary>
		public override string DisplayName => "Table To Ellipse";

		/// <summary>
		/// <para>Tool Name : TableToEllipse</para>
		/// </summary>
		public override string ToolName => "TableToEllipse";

		/// <summary>
		/// <para>Tool Excute Name : management.TableToEllipse</para>
		/// </summary>
		public override string ExcuteName => "management.TableToEllipse";

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
		public override object[] Parameters => new object[] { InTable, OutFeatureclass, XField, YField, MajorField, MinorField, DistanceUnits, AzimuthField, AzimuthUnits, IdField, SpatialReference, Attributes };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input table. It can be a text file, CSV file, Excel file, dBASE table, or geodatabase table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing geodetic ellipses as densified polylines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureclass { get; set; }

		/// <summary>
		/// <para>X Field</para>
		/// <para>A numerical field in the input table containing the x-coordinates (or longitudes) of the center points of ellipses to be positioned in the output coordinate system specified by the Spatial Reference parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object XField { get; set; }

		/// <summary>
		/// <para>Y Field</para>
		/// <para>A numerical field in the input table containing the y-coordinates (or latitudes) of the center points of ellipses to be positioned in the output coordinate system specified by the Spatial Reference parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object YField { get; set; }

		/// <summary>
		/// <para>Major Field</para>
		/// <para>A numerical field in the input table containing major axis lengths of the ellipses.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object MajorField { get; set; }

		/// <summary>
		/// <para>Minor Field</para>
		/// <para>A numerical field in the input table containing minor axis lengths of the ellipses.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object MinorField { get; set; }

		/// <summary>
		/// <para>Distance Units</para>
		/// <para>Specifies the units that will be used for the Major Field and Minor Field parameters.</para>
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
		/// <para>Azimuth Field</para>
		/// <para>A numerical field in the input table containing azimuth angle values for the major axis rotations of the output ellipses. The values are measured clockwise from north.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object AzimuthField { get; set; }

		/// <summary>
		/// <para>Azimuth Units</para>
		/// <para>Specifies the units that will be used for the Azimuth Field parameter.</para>
		/// <para><see cref="AzimuthUnitsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AzimuthUnits { get; set; } = "DEGREES";

		/// <summary>
		/// <para>ID</para>
		/// <para>A field in the input table. This field and the values are included in the output and can be used to join the output features with the records in the input table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
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
		public TableToEllipse SetEnviroment(object scratchWorkspace = null , object workspace = null )
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
		/// <para>Azimuth Units</para>
		/// </summary>
		public enum AzimuthUnitsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("DEGREES")]
			[Description("Decimal degrees")]
			Decimal_degrees,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("MILS")]
			[Description("Mils")]
			Mils,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("RADS")]
			[Description("Radians")]
			Radians,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("GRADS")]
			[Description("Gradians")]
			Gradians,

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
