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
	/// <para>ASCII 3D To Feature Class</para>
	/// <para>Imports 3D features from one or more ASCII files stored in XYZ, XYZI, or GENERATE formats into a new feature class.</para>
	/// </summary>
	public class ASCII3DToFeatureClass : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Input">
		/// <para>ASCII 3D Data</para>
		/// <para>The ASCII files or folders containing data in XYZ, XYZI (with lidar intensity), or 3D GENERATE format. All input files must be in the same format. If a folder is specified, the File Suffix parameter becomes required, and all the files that have the same extension as the specified suffix will be processed.</para>
		/// <para>In the tool dialog box, a folder can also be specified as an input by selecting the folder in Windows Explorer and dragging it onto the parameter&apos;s input box.</para>
		/// </param>
		/// <param name="InFileType">
		/// <para>File Format</para>
		/// <para>The format of the ASCII files that will be converted to a feature class.</para>
		/// <para>XYZ—Text file that contain geometry information stored as XYZ coordinates.</para>
		/// <para>XYZI—Text files that contain XYZ coordinates alongside intensity measurements.</para>
		/// <para>Generate—Text files structured in the Generate format.</para>
		/// <para><see cref="InFileTypeEnum"/></para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </param>
		/// <param name="OutGeometryType">
		/// <para>Output Feature Class Type</para>
		/// <para>The geometry type of the output feature class.</para>
		/// <para>Multipoint features—Multipoints are recommended the input data contains a large number of points and attributes per feature are not required.</para>
		/// <para>Point features—Each XYZ coordinate will produce one point feature.</para>
		/// <para>Polyline features—The output will contain polyline features.</para>
		/// <para>Polygon features—The output will contain polygon features.</para>
		/// <para><see cref="OutGeometryTypeEnum"/></para>
		/// </param>
		public ASCII3DToFeatureClass(object Input, object InFileType, object OutFeatureClass, object OutGeometryType)
		{
			this.Input = Input;
			this.InFileType = InFileType;
			this.OutFeatureClass = OutFeatureClass;
			this.OutGeometryType = OutGeometryType;
		}

		/// <summary>
		/// <para>Tool Display Name : ASCII 3D To Feature Class</para>
		/// </summary>
		public override string DisplayName => "ASCII 3D To Feature Class";

		/// <summary>
		/// <para>Tool Name : ASCII3DToFeatureClass</para>
		/// </summary>
		public override string ToolName => "ASCII3DToFeatureClass";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ASCII3DToFeatureClass</para>
		/// </summary>
		public override string ExcuteName => "3d.ASCII3DToFeatureClass";

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
		public override string[] ValidEnvironments => new string[] { "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { Input, InFileType, OutFeatureClass, OutGeometryType, ZFactor, InputCoordinateSystem, AveragePointSpacing, FileSuffix, DecimalSeparator };

		/// <summary>
		/// <para>ASCII 3D Data</para>
		/// <para>The ASCII files or folders containing data in XYZ, XYZI (with lidar intensity), or 3D GENERATE format. All input files must be in the same format. If a folder is specified, the File Suffix parameter becomes required, and all the files that have the same extension as the specified suffix will be processed.</para>
		/// <para>In the tool dialog box, a folder can also be specified as an input by selecting the folder in Windows Explorer and dragging it onto the parameter&apos;s input box.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Input { get; set; }

		/// <summary>
		/// <para>File Format</para>
		/// <para>The format of the ASCII files that will be converted to a feature class.</para>
		/// <para>XYZ—Text file that contain geometry information stored as XYZ coordinates.</para>
		/// <para>XYZI—Text files that contain XYZ coordinates alongside intensity measurements.</para>
		/// <para>Generate—Text files structured in the Generate format.</para>
		/// <para><see cref="InFileTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InFileType { get; set; } = "XYZ";

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Feature Class Type</para>
		/// <para>The geometry type of the output feature class.</para>
		/// <para>Multipoint features—Multipoints are recommended the input data contains a large number of points and attributes per feature are not required.</para>
		/// <para>Point features—Each XYZ coordinate will produce one point feature.</para>
		/// <para>Polyline features—The output will contain polyline features.</para>
		/// <para>Polygon features—The output will contain polygon features.</para>
		/// <para><see cref="OutGeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutGeometryType { get; set; } = "MULTIPOINT";

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>The factor by which z-values will be multiplied. This is typically used to convert z linear units to match x,y linear units. The default is 1, which leaves elevation values unchanged. This parameter is not available if the spatial reference of the input surface has a z datum with a specified linear unit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>The coordinate system of the input data. The default is an Unknown Coordinate System. If specified, the output may or may not be projected into a different coordinate system. This depends the whether the geoprocessing environment has a coordinate system defined for the location of the target feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object InputCoordinateSystem { get; set; }

		/// <summary>
		/// <para>Average Point Spacing</para>
		/// <para>The average planimetric distance between points of the input. This parameter is only used when the output geometry is set to MULTIPOINT, and its function is to provide a means for grouping the points together. This value is used in conjunction with the points per shape limit to construct a virtual tile system used to group the points. The tile system's origin is based on the domain of the target feature class. Specify the spacing in the horizontal units of the target feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object AveragePointSpacing { get; set; }

		/// <summary>
		/// <para>File Suffix</para>
		/// <para>The suffix of the files that will be imported from an input folder. This parameter is required when a folder is specified as input.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object FileSuffix { get; set; }

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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ASCII3DToFeatureClass SetEnviroment(object XYResolution = null , object XYTolerance = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>File Format</para>
		/// </summary>
		public enum InFileTypeEnum 
		{
			/// <summary>
			/// <para>XYZ—Text file that contain geometry information stored as XYZ coordinates.</para>
			/// </summary>
			[GPValue("XYZ")]
			[Description("XYZ")]
			XYZ,

			/// <summary>
			/// <para>XYZI—Text files that contain XYZ coordinates alongside intensity measurements.</para>
			/// </summary>
			[GPValue("XYZI")]
			[Description("XYZI")]
			XYZI,

			/// <summary>
			/// <para>Generate—Text files structured in the Generate format.</para>
			/// </summary>
			[GPValue("GENERATE")]
			[Description("Generate")]
			Generate,

		}

		/// <summary>
		/// <para>Output Feature Class Type</para>
		/// </summary>
		public enum OutGeometryTypeEnum 
		{
			/// <summary>
			/// <para>Point features—Each XYZ coordinate will produce one point feature.</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("Point features")]
			Point_features,

			/// <summary>
			/// <para>Multipoint features—Multipoints are recommended the input data contains a large number of points and attributes per feature are not required.</para>
			/// </summary>
			[GPValue("MULTIPOINT")]
			[Description("Multipoint features")]
			Multipoint_features,

			/// <summary>
			/// <para>Polyline features—The output will contain polyline features.</para>
			/// </summary>
			[GPValue("POLYLINE")]
			[Description("Polyline features")]
			Polyline_features,

			/// <summary>
			/// <para>Polygon features—The output will contain polygon features.</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("Polygon features")]
			Polygon_features,

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

#endregion
	}
}
