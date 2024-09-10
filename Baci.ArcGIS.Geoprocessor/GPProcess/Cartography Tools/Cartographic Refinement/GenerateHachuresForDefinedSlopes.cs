using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CartographyTools
{
	/// <summary>
	/// <para>Generate Hachures For Defined Slopes</para>
	/// <para>Creates multipart lines or polygons representing the slope between the lines representing the upper and lower parts of a slope.</para>
	/// </summary>
	public class GenerateHachuresForDefinedSlopes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="UpperLines">
		/// <para>Upper Line Features</para>
		/// <para>The line features that represent the top of a slope.</para>
		/// </param>
		/// <param name="LowerLines">
		/// <para>Lower Line Features</para>
		/// <para>The line features that represent the bottom of a slope.</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing multipart line or polygon hachures representing the slope area.</para>
		/// </param>
		public GenerateHachuresForDefinedSlopes(object UpperLines, object LowerLines, object OutputFeatureClass)
		{
			this.UpperLines = UpperLines;
			this.LowerLines = LowerLines;
			this.OutputFeatureClass = OutputFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Hachures For Defined Slopes</para>
		/// </summary>
		public override string DisplayName() => "Generate Hachures For Defined Slopes";

		/// <summary>
		/// <para>Tool Name : GenerateHachuresForDefinedSlopes</para>
		/// </summary>
		public override string ToolName() => "GenerateHachuresForDefinedSlopes";

		/// <summary>
		/// <para>Tool Excute Name : cartography.GenerateHachuresForDefinedSlopes</para>
		/// </summary>
		public override string ExcuteName() => "cartography.GenerateHachuresForDefinedSlopes";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise() => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "ZDomain", "extent", "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { UpperLines, LowerLines, OutputFeatureClass, OutputType, FullyConnected, SearchDistance, Interval, MinimumLength, AlternateHachures, Perpendicular, PolygonBaseWidth };

		/// <summary>
		/// <para>Upper Line Features</para>
		/// <para>The line features that represent the top of a slope.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object UpperLines { get; set; }

		/// <summary>
		/// <para>Lower Line Features</para>
		/// <para>The line features that represent the bottom of a slope.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object LowerLines { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing multipart line or polygon hachures representing the slope area.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Feature Type</para>
		/// <para>Specifies whether polygon triangles or tick lines will be created to represent the slope.</para>
		/// <para>Polygon triangles—Multipart polygon features will be created in which a triangular polygon is created for each hachure, with the base along the upper line. This is the default.</para>
		/// <para>Line ticks—Multipart line features will be created in which a linear tick is created for each hachure.</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutputType { get; set; } = "POLYGON_TRIANGLES";

		/// <summary>
		/// <para>Fully connected</para>
		/// <para>Specifies whether the upper and lower lines in the input data form fully connected areas. If the upper and lower lines are not fully connected, leave this parameter unchecked to create hachures inside areas that are derived by connecting the extremities of the upper and lower features. If the upper and lower lines are fully connected, check this parameter to create hachures inside the fully enclosed areas.</para>
		/// <para>Unchecked—The upper and lower features are not fully connected in the input data. New connections between the upper and lower features will be derived. This is the default.</para>
		/// <para>Checked—The upper and lower features are fully connected in the input data. New connections between features will not be derived.</para>
		/// <para><see cref="FullyConnectedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object FullyConnected { get; set; } = "false";

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>The distance used when deriving connections between the upper and lower features. When the extremities for the upper and lower feature are within this distance, the area between the features is used for creating hachures. The default value is 20 meters. When the Fully connected parameter is checked, this parameter is not available.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object SearchDistance { get; set; } = "20 Meters";

		/// <summary>
		/// <para>Hachure Interval</para>
		/// <para>The distance between the hachure ticks or triangles within the slope area. The default value is 10 meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object Interval { get; set; } = "10 Meters";

		/// <summary>
		/// <para>Minimum Length</para>
		/// <para>The length a hachure tick or triangle must be to be created. Hachures that are shorter than this length will not be created. The default value is 0 meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object MinimumLength { get; set; } = "0 Meters";

		/// <summary>
		/// <para>Alternate length of every other hachure</para>
		/// <para>Specifies whether the length of every other hachure triangle or tick will differ.</para>
		/// <para>Unchecked—All hachures will be of uniform length, which is the distance between the upper and lower slope lines. This is the default.</para>
		/// <para>Checked—Every other hachure will be one-half the distance between the upper and lower slope lines.</para>
		/// <para><see cref="AlternateHachuresEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AlternateHachures { get; set; } = "false";

		/// <summary>
		/// <para>Perpendicular to upper line</para>
		/// <para>Specifies whether the hachure ticks or triangles will be perpendicular to the upper slope line.</para>
		/// <para>Unchecked—Hachures will be oriented to obtain even spacing. This is the default.</para>
		/// <para>Checked—Hachures will be oriented perpendicularly to the upper line.</para>
		/// <para><see cref="PerpendicularEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Perpendicular { get; set; } = "false";

		/// <summary>
		/// <para>Polygon Base Width</para>
		/// <para>The width of the base of triangular polygon hachures. This parameter is active only when the Output Feature Type parameter is set to Polygon triangles. The default value is 5 meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object PolygonBaseWidth { get; set; } = "5 Meters";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateHachuresForDefinedSlopes SetEnviroment(object MDomain = null , object ZDomain = null , object extent = null , object outputCoordinateSystem = null )
		{
			base.SetEnv(MDomain: MDomain, ZDomain: ZDomain, extent: extent, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Feature Type</para>
		/// </summary>
		public enum OutputTypeEnum 
		{
			/// <summary>
			/// <para>Polygon triangles—Multipart polygon features will be created in which a triangular polygon is created for each hachure, with the base along the upper line. This is the default.</para>
			/// </summary>
			[GPValue("POLYGON_TRIANGLES")]
			[Description("Polygon triangles")]
			Polygon_triangles,

			/// <summary>
			/// <para>Line ticks—Multipart line features will be created in which a linear tick is created for each hachure.</para>
			/// </summary>
			[GPValue("LINE_TICKS")]
			[Description("Line ticks")]
			Line_ticks,

		}

		/// <summary>
		/// <para>Fully connected</para>
		/// </summary>
		public enum FullyConnectedEnum 
		{
			/// <summary>
			/// <para>Checked—The upper and lower features are fully connected in the input data. New connections between features will not be derived.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FULLY_CONNECTED")]
			FULLY_CONNECTED,

			/// <summary>
			/// <para>Unchecked—The upper and lower features are not fully connected in the input data. New connections between the upper and lower features will be derived. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_CONNECTED")]
			NOT_CONNECTED,

		}

		/// <summary>
		/// <para>Alternate length of every other hachure</para>
		/// </summary>
		public enum AlternateHachuresEnum 
		{
			/// <summary>
			/// <para>Checked—Every other hachure will be one-half the distance between the upper and lower slope lines.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ALTERNATE_HACHURES")]
			ALTERNATE_HACHURES,

			/// <summary>
			/// <para>Unchecked—All hachures will be of uniform length, which is the distance between the upper and lower slope lines. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("UNIFORM_HACHURES")]
			UNIFORM_HACHURES,

		}

		/// <summary>
		/// <para>Perpendicular to upper line</para>
		/// </summary>
		public enum PerpendicularEnum 
		{
			/// <summary>
			/// <para>Checked—Hachures will be oriented perpendicularly to the upper line.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PERPENDICULAR")]
			PERPENDICULAR,

			/// <summary>
			/// <para>Unchecked—Hachures will be oriented to obtain even spacing. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_PERPENDICULAR")]
			NOT_PERPENDICULAR,

		}

#endregion
	}
}
