using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>LAS To Multipoint</para>
	/// <para>Creates multipoint features using one or more lidar files.</para>
	/// </summary>
	public class LASToMultipoint : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Input">
		/// <para>Input</para>
		/// <para>The LAS or ZLAS files that will be imported to a multipoint feature class. If a folder is specified, all the LAS files that reside therein will be imported.</para>
		/// <para>In the tool dialog box, a folder can also be specified as an input by selecting the folder in Windows Explorer and dragging it onto the parameter&apos;s input box.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </param>
		/// <param name="AveragePointSpacing">
		/// <para>Average Point Spacing</para>
		/// <para>The average 2D distance between points in the input file or files. This can be an approximation. If areas have been sampled at different densities, specify the smaller spacing. The value needs to be provided in the projection units of the output coordinate system.</para>
		/// </param>
		public LASToMultipoint(object Input, object OutFeatureClass, object AveragePointSpacing)
		{
			this.Input = Input;
			this.OutFeatureClass = OutFeatureClass;
			this.AveragePointSpacing = AveragePointSpacing;
		}

		/// <summary>
		/// <para>Tool Display Name : LAS To Multipoint</para>
		/// </summary>
		public override string DisplayName => "LAS To Multipoint";

		/// <summary>
		/// <para>Tool Name : LASToMultipoint</para>
		/// </summary>
		public override string ToolName => "LASToMultipoint";

		/// <summary>
		/// <para>Tool Excute Name : 3d.LASToMultipoint</para>
		/// </summary>
		public override string ExcuteName => "3d.LASToMultipoint";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { Input, OutFeatureClass, AveragePointSpacing, ClassCode, Return, Attribute, InputCoordinateSystem, FileSuffix, ZFactor, FolderRecursion };

		/// <summary>
		/// <para>Input</para>
		/// <para>The LAS or ZLAS files that will be imported to a multipoint feature class. If a folder is specified, all the LAS files that reside therein will be imported.</para>
		/// <para>In the tool dialog box, a folder can also be specified as an input by selecting the folder in Windows Explorer and dragging it onto the parameter&apos;s input box.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCompositeDomain()]
		public object Input { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Average Point Spacing</para>
		/// <para>The average 2D distance between points in the input file or files. This can be an approximation. If areas have been sampled at different densities, specify the smaller spacing. The value needs to be provided in the projection units of the output coordinate system.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object AveragePointSpacing { get; set; }

		/// <summary>
		/// <para>Class Codes</para>
		/// <para>The classification codes to use as a query filter for LAS data points. Valid values range from 1 to 32. No filter is applied by default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object ClassCode { get; set; }

		/// <summary>
		/// <para>Return Values</para>
		/// <para>The return values that will be used to filter the LAS points that get imported to multipoint features.</para>
		/// <para>All Returns—Any returns</para>
		/// <para>1st Return—1</para>
		/// <para>2nd Return—2</para>
		/// <para>3rd Return—3</para>
		/// <para>4th Return—4</para>
		/// <para>5th Return—5</para>
		/// <para>6th Return—6</para>
		/// <para>7th Return—7</para>
		/// <para>8th Return—8</para>
		/// <para>Last Return—Last returns</para>
		/// <para><see cref="ReturnEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object Return { get; set; } = "ANY_RETURNS";

		/// <summary>
		/// <para>Input Attribute Names</para>
		/// <para>The LAS point properties whose values will be stored in binary large object (BLOB) fields in the attribute table of the output. If the resulting features will participate in a terrain dataset, the stored attributes can be used to symbolize the terrain. The Name column indicates the name of the field that will be used to store the specified attributes. The following LAS properties are supported:</para>
		/// <para>INTENSITY—Intensity</para>
		/// <para>RETURN_NUMBER—Return number</para>
		/// <para>NUMBER_OF_RETURNS—Number of returns per pulse</para>
		/// <para>SCAN_DIRECTION_FLAG —Scan direction flag</para>
		/// <para>EDGE_OF_FLIGHTLINE—Edge of flightline</para>
		/// <para>CLASSIFICATION—Classification</para>
		/// <para>SCAN_ANGLE_RANK—Scan angle rank</para>
		/// <para>FILE_MARKER—File marker</para>
		/// <para>USER_BIT_FIELD—User data value</para>
		/// <para>GPS_TIME—GPS time</para>
		/// <para>COLOR_RED—Red band</para>
		/// <para>COLOR_GREEN—Green band</para>
		/// <para>COLOR_BLUE—Blue band</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object Attribute { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>The coordinate system of the input LAS file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object InputCoordinateSystem { get; set; }

		/// <summary>
		/// <para>File Suffix</para>
		/// <para>The suffix of the files that will be imported from an input folder. This parameter is required when a folder is specified as input.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object FileSuffix { get; set; } = "las";

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>The factor by which z-values will be multiplied. This is typically used to convert z linear units to match x,y linear units. The default is 1, which leaves elevation values unchanged. This parameter is not available if the spatial reference of the input surface has a z datum with a specified linear unit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Include Subfolders</para>
		/// <para>Scans through subfolders when an input folder is selected containing data in a subfolders directory. The output feature class will be generated with a row for each file encountered in the directory structure.</para>
		/// <para>Unchecked—Only LAS files found in an input folder will be converted to multipoint features. This is the default.</para>
		/// <para>Checked—All LAS files residing in the subdirectories of an input folder will be converted to multipoint features.</para>
		/// <para><see cref="FolderRecursionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object FolderRecursion { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LASToMultipoint SetEnviroment(object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Return Values</para>
		/// </summary>
		public enum ReturnEnum 
		{
			/// <summary>
			/// <para>All Returns—Any returns</para>
			/// </summary>
			[GPValue("ANY_RETURNS")]
			[Description("All Returns")]
			All_Returns,

			/// <summary>
			/// <para>1st Return—1</para>
			/// </summary>
			[GPValue("1")]
			[Description("1st Return")]
			_1st_Return,

			/// <summary>
			/// <para>2nd Return—2</para>
			/// </summary>
			[GPValue("2")]
			[Description("2nd Return")]
			_2nd_Return,

			/// <summary>
			/// <para>3rd Return—3</para>
			/// </summary>
			[GPValue("3")]
			[Description("3rd Return")]
			_3rd_Return,

			/// <summary>
			/// <para>4th Return—4</para>
			/// </summary>
			[GPValue("4")]
			[Description("4th Return")]
			_4th_Return,

			/// <summary>
			/// <para>5th Return—5</para>
			/// </summary>
			[GPValue("5")]
			[Description("5th Return")]
			_5th_Return,

			/// <summary>
			/// <para>6th Return—6</para>
			/// </summary>
			[GPValue("6")]
			[Description("6th Return")]
			_6th_Return,

			/// <summary>
			/// <para>7th Return—7</para>
			/// </summary>
			[GPValue("7")]
			[Description("7th Return")]
			_7th_Return,

			/// <summary>
			/// <para>8th Return—8</para>
			/// </summary>
			[GPValue("8")]
			[Description("8th Return")]
			_8th_Return,

			/// <summary>
			/// <para>Last Return—Last returns</para>
			/// </summary>
			[GPValue("LAST_RETURNS")]
			[Description("Last Return")]
			Last_Return,

		}

		/// <summary>
		/// <para>Include Subfolders</para>
		/// </summary>
		public enum FolderRecursionEnum 
		{
			/// <summary>
			/// <para>Checked—All LAS files residing in the subdirectories of an input folder will be converted to multipoint features.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RECURSION")]
			RECURSION,

			/// <summary>
			/// <para>Unchecked—Only LAS files found in an input folder will be converted to multipoint features. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_RECURSION")]
			NO_RECURSION,

		}

#endregion
	}
}
