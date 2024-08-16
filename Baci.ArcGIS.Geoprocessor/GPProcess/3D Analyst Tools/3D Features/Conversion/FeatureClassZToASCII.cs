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
	/// <para>Feature Class Z To ASCII</para>
	/// <para>Exports 3D features to ASCII text files storing GENERATE, XYZ, or profile data.</para>
	/// </summary>
	public class FeatureClassZToASCII : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>Input Features</para>
		/// <para>The 3D point, multipoint, polyline, or polygon feature class that will be exported to an ASCII file.</para>
		/// </param>
		/// <param name="OutputLocation">
		/// <para>Output Location</para>
		/// <para>The folder to which output files will be written.</para>
		/// </param>
		/// <param name="OutFile">
		/// <para>Output Text File</para>
		/// <para>The name of the resulting ASCII file.</para>
		/// <para>If a line or polygon feature class is exported to XYZ format, the file name is used as a base name. Each feature will have a unique file output, since the XYZ format only supports one line or polygon per file. Multipart features will also have each part written to a separate file. The file name will be appended with the OID of each feature, as well as any additional characters needed to make each file name unique.</para>
		/// </param>
		public FeatureClassZToASCII(object InFeatureClass, object OutputLocation, object OutFile)
		{
			this.InFeatureClass = InFeatureClass;
			this.OutputLocation = OutputLocation;
			this.OutFile = OutFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Feature Class Z To ASCII</para>
		/// </summary>
		public override string DisplayName => "Feature Class Z To ASCII";

		/// <summary>
		/// <para>Tool Name : FeatureClassZToASCII</para>
		/// </summary>
		public override string ToolName => "FeatureClassZToASCII";

		/// <summary>
		/// <para>Tool Excute Name : 3d.FeatureClassZToASCII</para>
		/// </summary>
		public override string ExcuteName => "3d.FeatureClassZToASCII";

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
		public override string[] ValidEnvironments => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatureClass, OutputLocation, OutFile, Format, Delimiter, DecimalFormat, DigitsAfterDecimal, DecimalSeparator, DerivedOutput };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The 3D point, multipoint, polyline, or polygon feature class that will be exported to an ASCII file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon", "Point", "Multipoint")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>The folder to which output files will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutputLocation { get; set; }

		/// <summary>
		/// <para>Output Text File</para>
		/// <para>The name of the resulting ASCII file.</para>
		/// <para>If a line or polygon feature class is exported to XYZ format, the file name is used as a base name. Each feature will have a unique file output, since the XYZ format only supports one line or polygon per file. Multipart features will also have each part written to a separate file. The file name will be appended with the OID of each feature, as well as any additional characters needed to make each file name unique.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutFile { get; set; } = "pf.txt";

		/// <summary>
		/// <para>ASCII Format</para>
		/// <para>Specifies the format of the ASCII file being created.</para>
		/// <para>GENERATE—Writes output in the GENERATE format. This is the default.</para>
		/// <para>XYZ—Writes XYZ information of input features. One file will be created for each line or polygon in the input feature.</para>
		/// <para>Profile—Writes profile information for line features that can be used in external graphing applications.</para>
		/// <para><see cref="FormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Format { get; set; } = "GENERATE";

		/// <summary>
		/// <para>Delimiter</para>
		/// <para>Specifies the delimiter that will indicate the separation of entries in the columns of the text file table.</para>
		/// <para>Space—A space will be used to delimit field values. This is the default.</para>
		/// <para>Comma—A comma will be used to delimit field values. This option is not applicable if the decimal separator is also a comma.</para>
		/// <para><see cref="DelimiterEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Delimiter { get; set; } = "SPACE";

		/// <summary>
		/// <para>Decimal Notation</para>
		/// <para>Specifies the method that will determine the number of significant digits stored in the output files.</para>
		/// <para>Automatically Determined—The number of significant digits needed to preserve the available precision, while removing unnecessary trailing zeros, is automatically determined. This is the default.</para>
		/// <para>Specified Number—The number of significant digits is defined in the Digits after Decimal parameter.</para>
		/// <para><see cref="DecimalFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DecimalFormat { get; set; } = "AUTOMATIC";

		/// <summary>
		/// <para>Digits after Decimal</para>
		/// <para>The number of digits written after the decimal for floating-point values written to the output files. This parameter is used when the Decimal Notation parameter is set to Specified Number (decimal_format=FIXED in Python).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object DigitsAfterDecimal { get; set; } = "3";

		/// <summary>
		/// <para>Decimal Separator</para>
		/// <para>Specifies the decimal character that will differentiate the integer of a number from its fractional part.</para>
		/// <para>Point—A point is used as the decimal character. This is the default.</para>
		/// <para>Comma—A comma is used as the decimal character.</para>
		/// <para><see cref="DecimalSeparatorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DecimalSeparator { get; set; } = "DECIMAL_POINT";

		/// <summary>
		/// <para>Updated Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object DerivedOutput { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FeatureClassZToASCII SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>ASCII Format</para>
		/// </summary>
		public enum FormatEnum 
		{
			/// <summary>
			/// <para>GENERATE—Writes output in the GENERATE format. This is the default.</para>
			/// </summary>
			[GPValue("GENERATE")]
			[Description("GENERATE")]
			GENERATE,

			/// <summary>
			/// <para>XYZ—Writes XYZ information of input features. One file will be created for each line or polygon in the input feature.</para>
			/// </summary>
			[GPValue("XYZ")]
			[Description("XYZ")]
			XYZ,

			/// <summary>
			/// <para>Profile—Writes profile information for line features that can be used in external graphing applications.</para>
			/// </summary>
			[GPValue("PROFILE")]
			[Description("Profile")]
			Profile,

		}

		/// <summary>
		/// <para>Delimiter</para>
		/// </summary>
		public enum DelimiterEnum 
		{
			/// <summary>
			/// <para>Comma—A comma will be used to delimit field values. This option is not applicable if the decimal separator is also a comma.</para>
			/// </summary>
			[GPValue("COMMA")]
			[Description("Comma")]
			Comma,

			/// <summary>
			/// <para>Space—A space will be used to delimit field values. This is the default.</para>
			/// </summary>
			[GPValue("SPACE")]
			[Description("Space")]
			Space,

		}

		/// <summary>
		/// <para>Decimal Notation</para>
		/// </summary>
		public enum DecimalFormatEnum 
		{
			/// <summary>
			/// <para>Automatically Determined—The number of significant digits needed to preserve the available precision, while removing unnecessary trailing zeros, is automatically determined. This is the default.</para>
			/// </summary>
			[GPValue("AUTOMATIC")]
			[Description("Automatically Determined")]
			Automatically_Determined,

			/// <summary>
			/// <para>Specified Number—The number of significant digits is defined in the Digits after Decimal parameter.</para>
			/// </summary>
			[GPValue("FIXED")]
			[Description("Specified Number")]
			Specified_Number,

		}

		/// <summary>
		/// <para>Decimal Separator</para>
		/// </summary>
		public enum DecimalSeparatorEnum 
		{
			/// <summary>
			/// <para>Point—A point is used as the decimal character. This is the default.</para>
			/// </summary>
			[GPValue("DECIMAL_POINT")]
			[Description("Point")]
			Point,

			/// <summary>
			/// <para>Comma—A comma is used as the decimal character.</para>
			/// </summary>
			[GPValue("DECIMAL_COMMA")]
			[Description("Comma")]
			Comma,

		}

#endregion
	}
}
