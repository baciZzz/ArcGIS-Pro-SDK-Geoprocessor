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
	/// <para>Point File Information</para>
	/// <para>Generates statistical information about one or more point files in a polygon or multipatch output.</para>
	/// </summary>
	public class PointFileInformation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Input">
		/// <para>Point Data</para>
		/// <para>Any combination of folders and files storing point records that will be analyzed.</para>
		/// <para>In the tool dialog box, a folder can also be specified as an input by selecting the folder in Windows Explorer and dragging it onto the parameter&apos;s input box.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </param>
		/// <param name="InFileType">
		/// <para>File Format</para>
		/// <para>Specifies the format of the input files.</para>
		/// <para>LAS format lidar—Lidar data storage format defined by the American Society of Photogrammetry and Remote Sensing (ASPRS).</para>
		/// <para>ASCII file with XYZ—XYZ file.</para>
		/// <para>ASCII file with XYZI—XYZI file.</para>
		/// <para>ASCII file in Generate format—GENERATE file.</para>
		/// <para><see cref="InFileTypeEnum"/></para>
		/// </param>
		public PointFileInformation(object Input, object OutFeatureClass, object InFileType)
		{
			this.Input = Input;
			this.OutFeatureClass = OutFeatureClass;
			this.InFileType = InFileType;
		}

		/// <summary>
		/// <para>Tool Display Name : Point File Information</para>
		/// </summary>
		public override string DisplayName() => "Point File Information";

		/// <summary>
		/// <para>Tool Name : PointFileInformation</para>
		/// </summary>
		public override string ToolName() => "PointFileInformation";

		/// <summary>
		/// <para>Tool Excute Name : 3d.PointFileInformation</para>
		/// </summary>
		public override string ExcuteName() => "3d.PointFileInformation";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Input, OutFeatureClass, InFileType, FileSuffix, InputCoordinateSystem, FolderRecursion, ExtrudeGeometry, DecimalSeparator, SummarizeByClassCode, ImproveLasPointSpacing, MinPointSpacing };

		/// <summary>
		/// <para>Point Data</para>
		/// <para>Any combination of folders and files storing point records that will be analyzed.</para>
		/// <para>In the tool dialog box, a folder can also be specified as an input by selecting the folder in Windows Explorer and dragging it onto the parameter&apos;s input box.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Input { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>File Format</para>
		/// <para>Specifies the format of the input files.</para>
		/// <para>LAS format lidar—Lidar data storage format defined by the American Society of Photogrammetry and Remote Sensing (ASPRS).</para>
		/// <para>ASCII file with XYZ—XYZ file.</para>
		/// <para>ASCII file with XYZI—XYZI file.</para>
		/// <para>ASCII file in Generate format—GENERATE file.</para>
		/// <para><see cref="InFileTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InFileType { get; set; } = "LAS";

		/// <summary>
		/// <para>File Suffix</para>
		/// <para>The suffix of the files to be imported when a folder is specified in the input. This parameter is required if an input folder is provided.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object FileSuffix { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>The coordinate system of the input data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object InputCoordinateSystem { get; set; }

		/// <summary>
		/// <para>Include Subfolders</para>
		/// <para>Specifies whether data in subfolders will be used to generate results. The tool scans subfolders when an input folder is selected containing data in a subfolders directory. The output feature class will be generated with a row for each file encountered in the directory structure.</para>
		/// <para>Unchecked—Only the data found in the input folder will be used to generate the results. This is the default.</para>
		/// <para>Checked—Any data found in the input folder and its subdirectories will be used to generate results.</para>
		/// <para><see cref="FolderRecursionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object FolderRecursion { get; set; } = "false";

		/// <summary>
		/// <para>Extrude Geometry Shapes</para>
		/// <para>Specifies whether the output will be created as a 2D polygon or multipatch feature class with extruded features that reflect the elevation range found in each file.</para>
		/// <para>Unchecked—The output will be created as a 2D polygon feature class. This is the default.</para>
		/// <para>Checked—The output will be created as a multipatch feature class.</para>
		/// <para><see cref="ExtrudeGeometryEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ExtrudeGeometry { get; set; } = "false";

		/// <summary>
		/// <para>Decimal Separator</para>
		/// <para>The decimal character that will be used in the text file to differentiate the integer of a number from its fractional part.</para>
		/// <para>Point—A point will be used as the decimal character. This is the default.</para>
		/// <para>Comma—A comma will be used as the decimal character.</para>
		/// <para><see cref="DecimalSeparatorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DecimalSeparator { get; set; } = "DECIMAL_POINT";

		/// <summary>
		/// <para>Summarize by class code</para>
		/// <para>Specifies whether the results will summarize LAS files per class code or per LAS file. This option will require an intensive scan of the LAS file.</para>
		/// <para>Unchecked—Each output feature will represent all the data found in a lidar file. This is the default.</para>
		/// <para>Checked—Each output feature will represent a single class code found in a lidar file.</para>
		/// <para><see cref="SummarizeByClassCodeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SummarizeByClassCode { get; set; } = "false";

		/// <summary>
		/// <para>Improve LAS files point spacing estimate</para>
		/// <para>Specifies whether enhanced assessment of the point spacing in LAS files, which can reduce over-estimation caused by irregular data distribution, will be used.</para>
		/// <para>Unchecked—Regular point spacing estimate is used for LAS files, where the extent is equally divided by the number of points. This is the default.</para>
		/// <para>Checked—Binning will be used to obtain a more precise point spacing estimate for LAS files. This may increase the tool&apos;s execution time.</para>
		/// <para><see cref="ImproveLasPointSpacingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ImproveLasPointSpacing { get; set; } = "false";

		/// <summary>
		/// <para>Average Point Spacing</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object MinPointSpacing { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PointFileInformation SetEnviroment(object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object configKeyword = null , object extent = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>File Format</para>
		/// </summary>
		public enum InFileTypeEnum 
		{
			/// <summary>
			/// <para>LAS format lidar—Lidar data storage format defined by the American Society of Photogrammetry and Remote Sensing (ASPRS).</para>
			/// </summary>
			[GPValue("LAS")]
			[Description("LAS format lidar")]
			LAS_format_lidar,

			/// <summary>
			/// <para>ASCII file with XYZ—XYZ file.</para>
			/// </summary>
			[GPValue("XYZ")]
			[Description("ASCII file with XYZ")]
			ASCII_file_with_XYZ,

			/// <summary>
			/// <para>ASCII file with XYZI—XYZI file.</para>
			/// </summary>
			[GPValue("XYZI")]
			[Description("ASCII file with XYZI")]
			ASCII_file_with_XYZI,

			/// <summary>
			/// <para>ASCII file in Generate format—GENERATE file.</para>
			/// </summary>
			[GPValue("GENERATE")]
			[Description("ASCII file in Generate format")]
			ASCII_file_in_Generate_format,

		}

		/// <summary>
		/// <para>Include Subfolders</para>
		/// </summary>
		public enum FolderRecursionEnum 
		{
			/// <summary>
			/// <para>Checked—Any data found in the input folder and its subdirectories will be used to generate results.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RECURSION")]
			RECURSION,

			/// <summary>
			/// <para>Unchecked—Only the data found in the input folder will be used to generate the results. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_RECURSION")]
			NO_RECURSION,

		}

		/// <summary>
		/// <para>Extrude Geometry Shapes</para>
		/// </summary>
		public enum ExtrudeGeometryEnum 
		{
			/// <summary>
			/// <para>Checked—The output will be created as a multipatch feature class.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EXTRUSION")]
			EXTRUSION,

			/// <summary>
			/// <para>Unchecked—The output will be created as a 2D polygon feature class. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_EXTRUSION")]
			NO_EXTRUSION,

		}

		/// <summary>
		/// <para>Decimal Separator</para>
		/// </summary>
		public enum DecimalSeparatorEnum 
		{
			/// <summary>
			/// <para>Point—A point will be used as the decimal character. This is the default.</para>
			/// </summary>
			[GPValue("DECIMAL_POINT")]
			[Description("Point")]
			Point,

			/// <summary>
			/// <para>Comma—A comma will be used as the decimal character.</para>
			/// </summary>
			[GPValue("DECIMAL_COMMA")]
			[Description("Comma")]
			Comma,

		}

		/// <summary>
		/// <para>Summarize by class code</para>
		/// </summary>
		public enum SummarizeByClassCodeEnum 
		{
			/// <summary>
			/// <para>Checked—Each output feature will represent a single class code found in a lidar file.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SUMMARIZE")]
			SUMMARIZE,

			/// <summary>
			/// <para>Unchecked—Each output feature will represent all the data found in a lidar file. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SUMMARIZE")]
			NO_SUMMARIZE,

		}

		/// <summary>
		/// <para>Improve LAS files point spacing estimate</para>
		/// </summary>
		public enum ImproveLasPointSpacingEnum 
		{
			/// <summary>
			/// <para>Checked—Binning will be used to obtain a more precise point spacing estimate for LAS files. This may increase the tool&apos;s execution time.</para>
			/// </summary>
			[GPValue("true")]
			[Description("LAS_SPACING")]
			LAS_SPACING,

			/// <summary>
			/// <para>Unchecked—Regular point spacing estimate is used for LAS files, where the extent is equally divided by the number of points. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_LAS_SPACING")]
			NO_LAS_SPACING,

		}

#endregion
	}
}
