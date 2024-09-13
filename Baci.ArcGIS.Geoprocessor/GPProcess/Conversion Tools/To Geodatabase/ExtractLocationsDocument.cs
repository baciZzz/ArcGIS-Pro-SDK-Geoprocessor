using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>Extract Locations From Document</para>
	/// <para>从文档中提取位置</para>
	/// <para>分析包含非结构化或半结构化文本（例如电子邮件消息、行程表单等）的文档，并将位置提取到点要素类。</para>
	/// </summary>
	public class ExtractLocationsDocument : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFile">
		/// <para>Input File</para>
		/// <para>将扫描以查找位置 （坐标或自定义位置）、日期和自定义属性的输入文件；或者将扫描其中所有文件以查找位置的文件夹。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class containing point features that represent the locations that were found.</para>
		/// </param>
		public ExtractLocationsDocument(object InFile, object OutFeatureClass)
		{
			this.InFile = InFile;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 从文档中提取位置</para>
		/// </summary>
		public override string DisplayName() => "从文档中提取位置";

		/// <summary>
		/// <para>Tool Name : ExtractLocationsDocument</para>
		/// </summary>
		public override string ToolName() => "ExtractLocationsDocument";

		/// <summary>
		/// <para>Tool Excute Name : conversion.ExtractLocationsDocument</para>
		/// </summary>
		public override string ExcuteName() => "conversion.ExtractLocationsDocument";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFile, OutFeatureClass, InTemplate, CoordDdLatlon, CoordDdXydeg, CoordDdXyplain, CoordDmLatlon, CoordDmXymin, CoordDmsLatlon, CoordDmsXysec, CoordDmsXysep, CoordUtm, CoordUpsNorth, CoordUpsSouth, CoordMgrs, CoordMgrsNorthpolar, CoordMgrsSouthpolar, CommaDecimal, CoordUseLonlat, InCoorSystem, InCustomLocations, FuzzyMatch, MaxFeaturesExtracted, IgnoreFirstFeatures, DateMonthname, DateMDY, DateYyyymmdd, DateYymmdd, DateYyjjj, MaxDatesExtracted, IgnoreFirstDates, DateRangeBegin, DateRangeEnd, InCustomAttributes, FileLink, FileModDatetime, PreTextLength, PostTextLength, StdCoordFmt, ReqWordBreaks };

		/// <summary>
		/// <para>Input File</para>
		/// <para>将扫描以查找位置 （坐标或自定义位置）、日期和自定义属性的输入文件；或者将扫描其中所有文件以查找位置的文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object InFile { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class containing point features that represent the locations that were found.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Input Template</para>
		/// <para>The template file (*.lxttmpl) that determines the setting to use for each tool parameter. When a template file is provided, all values specified for other parameters will be ignored except those that determine the input content that will be processed and the output feature class.</para>
		/// <para>Some settings that are available in the Extract Locations pane are only available to this tool when the settings are saved to a template file, and the template file is referenced in this parameter. These settings are as follows:</para>
		/// <para>Spatial coordinates in x,y format—Allows two sequential numbers such as 630084 4833438 or 981075.652ftUS 607151.272ftUS to be recognized as coordinates when they are valid for a planar coordinate system associated with the input documents. You can specify whether numbers with and without units are recognized or only numbers with units of measure are recognized as coordinates.</para>
		/// <para>Custom coordinate and date formats—Allows you to customize how text is recognized as a spatial coordinate or a date, particularly when written in a language other than English or using a format that is not common in the United States. For example, a spatial coordinate written as 30 20 10 N x 060 50 40 W can be recognized with a customization to recognize the character x as valid text between the latitude and longitude. Coordinates and dates such as 60.91°N, 147.34°O and 17 juillet, 2018 can be recognized when customizations are specified to accommodate the language of the documents, in this case French. Also, when two-digit years are used, you can control the range of years to which they are matched.</para>
		/// <para>Preferences for some ambiguous dates—Dates such as 10/12/2019 are ambiguous because they can be interpreted as either October 12, 2019, or December 10, 2019. Some countries use the m/d/yy date format as a standard, and other countries use the d/m/yy format. A preference can be set for how these ambiguous dates are interpreted, either as m/d/yy or d/m/yy, to suit the country of origin of the documents.</para>
		/// <para>Length of fields in the output feature class—You can specify the length of the fields containing text surrounding spatial coordinates that are extracted from a document using the Pre-Text Field Length (pre_text_length in Python) and Post-Text Field Length (post_text_length in Python) parameters. The Extract Locations pane allows you to control the length of several additional fields in the attribute table, including fields containing dates extracted from the document, the original text that was converted to dates, the file name from which the information was extracted, and so on.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("lxttmpl")]
		public object InTemplate { get; set; }

		/// <summary>
		/// <para>Latitude And Longitude</para>
		/// <para>Specifies whether to search for coordinates stored as decimal degrees formatted as latitude and longitude (infrequent false positives). Examples are: 33.8N 77.035W and W77N38.88909.</para>
		/// <para>Checked—The tool will search for decimal degrees coordinates formatted as latitude and longitude. This is the default.</para>
		/// <para>Unchecked—The tool will not search for decimal degrees coordinates formatted as latitude and longitude.</para>
		/// <para><see cref="CoordDdLatlonEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Coordinate Formats - DD")]
		public object CoordDdLatlon { get; set; } = "true";

		/// <summary>
		/// <para>X Y With Degree Symbols</para>
		/// <para>Specifies whether to search for coordinates stored as decimal degrees formatted as X Y with degree symbols (infrequent false positives). Examples are: 38.8° -77.035° and -077d+38.88909d.</para>
		/// <para>Checked—The tool will search for decimal degrees coordinates formatted as X Y with degree symbols. This is the default.</para>
		/// <para>Unchecked—The tool will not search for decimal degrees coordinates formatted as X Y with degree symbols.</para>
		/// <para><see cref="CoordDdXydegEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Coordinate Formats - DD")]
		public object CoordDdXydeg { get; set; } = "true";

		/// <summary>
		/// <para>X Y With No Symbols</para>
		/// <para>Specifies whether to search for coordinates stored as decimal degrees formatted as X Y with no symbols (frequent false positives). Examples are: 38.8 -77.035 and -077.0, +38.88909.</para>
		/// <para>Checked—The tool will search for decimal degrees coordinates formatted as X Y with no symbols (frequent false positives). This is the default.</para>
		/// <para>Unchecked—The tool will not search for decimal degrees coordinates formatted as X Y with no symbols.</para>
		/// <para><see cref="CoordDdXyplainEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Coordinate Formats - DD")]
		public object CoordDdXyplain { get; set; } = "true";

		/// <summary>
		/// <para>Latitude And Longitude</para>
		/// <para>Specifies whether to search for coordinates stored as degrees decimal minutes formatted as latitude and longitude (infrequent false positives). Examples are: 3853.3N 7702.100W and W7702N3853.3458.</para>
		/// <para>Checked—The tool will search for degrees decimal minutes coordinates formatted as latitude and longitude. This is the default.</para>
		/// <para>Unchecked—The tool will not search for degrees decimal minutes coordinates formatted as latitude and longitude.</para>
		/// <para><see cref="CoordDmLatlonEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Coordinate Formats - DM")]
		public object CoordDmLatlon { get; set; } = "true";

		/// <summary>
		/// <para>X Y With Minutes Symbols</para>
		/// <para>Specifies whether to search for coordinates stored as degrees decimal minutes formatted as X Y with minutes symbols (infrequent false positives). Examples are: 3853&apos; -7702.1&apos; and -07702m+3853.3458m.</para>
		/// <para>Checked—The tool will search for degrees decimal minutes coordinates formatted as X Y with minutes symbols. This is the default.</para>
		/// <para>Unchecked—The tool will not search for degrees decimal minutes coordinates formatted as X Y with minutes symbols.</para>
		/// <para><see cref="CoordDmXyminEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Coordinate Formats - DM")]
		public object CoordDmXymin { get; set; } = "true";

		/// <summary>
		/// <para>Latitude And Longitude</para>
		/// <para>Specifies whether to search for coordinates stored as degrees minutes seconds formatted as latitude and longitude (infrequent false positives). Examples are: 385320.7N 770206.000W and W770206N385320.76.</para>
		/// <para>Checked—The tool will search for degrees minutes seconds coordinates formatted as latitude and longitude. This is the default.</para>
		/// <para>Unchecked—The tool will not search for degrees minutes seconds coordinates formatted as latitude and longitude.</para>
		/// <para><see cref="CoordDmsLatlonEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Coordinate Formats - DMS")]
		public object CoordDmsLatlon { get; set; } = "true";

		/// <summary>
		/// <para>X Y With Seconds Symbols</para>
		/// <para>Specifies whether to search for coordinates stored as degrees minutes seconds formatted as X Y with seconds symbols (infrequent false positives). Examples are: 385320&quot; -770206.0&quot; and -0770206.0s+385320.76s.</para>
		/// <para>Checked—The tool will search for degrees minutes seconds coordinates formatted as X Y with seconds symbols. This is the default.</para>
		/// <para>Unchecked—The tool will not search for degrees minutes seconds coordinates formatted as X Y with seconds symbols.</para>
		/// <para><see cref="CoordDmsXysecEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Coordinate Formats - DMS")]
		public object CoordDmsXysec { get; set; } = "true";

		/// <summary>
		/// <para>X Y With Separators</para>
		/// <para>Specifies whether to search for coordinates stored as degrees minutes seconds formatted as X Y with separators (moderate false positives). Examples are: 38:53:20 -77:2:6.0 and -077/02/06/+38/53/20.76.</para>
		/// <para>Checked—The tool will search for degrees minutes seconds coordinates formatted as X Y with separators. This is the default.</para>
		/// <para>Unchecked—The tool will not search for degrees minutes seconds coordinates formatted as X Y with separators.</para>
		/// <para><see cref="CoordDmsXysepEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Coordinate Formats - DMS")]
		public object CoordDmsXysep { get; set; } = "true";

		/// <summary>
		/// <para>Universal Transverse Mercator</para>
		/// <para>Specifies whether to search for Universal Transverse Mercator (UTM) coordinates (infrequent false positives). Examples are: 18S 323503 4306438 and 18 north 323503.25 4306438.39.</para>
		/// <para>Checked—The tool will search for UTM coordinates. This is the default.</para>
		/// <para>Unchecked—The tool will not search for UTM coordinates.</para>
		/// <para><see cref="CoordUtmEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Coordinate Formats - UTM")]
		public object CoordUtm { get; set; } = "true";

		/// <summary>
		/// <para>UPS North Polar</para>
		/// <para>Specifies whether to search for Universal Polar Stereographic (UPS) coordinates in the north polar area (infrequent false positives). Examples are: Y 2722399 2000000 and north 2722399 2000000.</para>
		/// <para>Checked—The tool will search for UPS coordinates in the north polar area. This is the default.</para>
		/// <para>Unchecked—The tool will not search for UPS coordinates in the north polar area.</para>
		/// <para><see cref="CoordUpsNorthEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Coordinate Formats - UTM")]
		public object CoordUpsNorth { get; set; } = "false";

		/// <summary>
		/// <para>UPS South Polar</para>
		/// <para>Specifies whether to search for Universal Polar Stereographic (UPS) coordinates in the south polar area (infrequent false positives). Examples are: A 2000000 3168892 and south 2000000 3168892.</para>
		/// <para>Checked—The tool will search for UPS coordinates in the south polar area. This is the default.</para>
		/// <para>Unchecked—The tool will not search for UPS coordinates in the south polar area.</para>
		/// <para><see cref="CoordUpsSouthEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Coordinate Formats - UTM")]
		public object CoordUpsSouth { get; set; } = "false";

		/// <summary>
		/// <para>Military Grid Reference System</para>
		/// <para>Specifies whether to search for Military Grid Reference System (MGRS) coordinates (infrequent false positives). Examples are: 18S UJ 13503 06438 and 18SUJ0306.</para>
		/// <para>Checked—The tool will search for MGRS coordinates. This is the default.</para>
		/// <para>Unchecked—The tool will not search for MGRS coordinates.</para>
		/// <para><see cref="CoordMgrsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Coordinate Formats - MGRS")]
		public object CoordMgrs { get; set; } = "true";

		/// <summary>
		/// <para>North Polar</para>
		/// <para>Specifies whether to search for Military Grid Reference System (MGRS) coordinates in the north polar area (infrequent false positives). Examples are: Y TG 56814 69009 and YTG5669.</para>
		/// <para>Checked—The tool will search for MGRS coordinates in the north polar area. This is the default.</para>
		/// <para>Unchecked—The tool will not search for MGRS coordinates in the north polar area.</para>
		/// <para><see cref="CoordMgrsNorthpolarEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Coordinate Formats - MGRS")]
		public object CoordMgrsNorthpolar { get; set; } = "false";

		/// <summary>
		/// <para>South Polar</para>
		/// <para>Specifies whether to search for Military Grid Reference System (MGRS) coordinates in the south polar area (moderate false positives). Examples are: A TN 56814 30991 and ATN5630.</para>
		/// <para>Checked—The tool will search for MGRS coordinates in the south polar area. This is the default.</para>
		/// <para>Unchecked—The tool will not search for MGRS coordinates in the south polar area.</para>
		/// <para><see cref="CoordMgrsSouthpolarEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Coordinate Formats - MGRS")]
		public object CoordMgrsSouthpolar { get; set; } = "false";

		/// <summary>
		/// <para>Use Comma As Decimal Separator</para>
		/// <para>Specifies whether a comma (,) will be recognized as a decimal separator. By default, content is scanned for spatial coordinates defined by numbers that use a period (.) or a middle dot (·) as the decimal separator, for example: Lat 01° 10·80’ N Long 103° 28·60’ E. If you are working with content in which spatial coordinates are defined by numbers that use a comma (,) as the decimal separator, for example: 52° 8′ 32,14″ N; 5° 24′ 56,09″ E, set this parameter to recognize a comma as the decimal separator instead. This parameter is not set automatically based on the regional setting for your computer&apos;s operating system.</para>
		/// <para>Checked—A comma will be recognized as the decimal separator.</para>
		/// <para>Unchecked—A period or a middle dot will be recognized as the decimal separator. This is the default.</para>
		/// <para><see cref="CommaDecimalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Coordinate Formats")]
		public object CommaDecimal { get; set; } = "false";

		/// <summary>
		/// <para>Interpret As Longitude, Latitude</para>
		/// <para>Specifies whether x,y coordinates will be interpreted as longitude-latitude. When numbers resemble x,y coordinates, both numbers are less than 90, and there are no symbols or notations to indicate which number represents the latitude or longitude, results can be ambiguous. Interpret the numbers as a longitude-latitude coordinate (x,y) instead of a latitude-longitude coordinate (y,x).</para>
		/// <para>Checked—x,y coordinates will be interpreted as longitude-latitude.</para>
		/// <para>Unchecked—x,y coordinates will be interpreted as latitude-longitude. This is the default.</para>
		/// <para><see cref="CoordUseLonlatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Coordinate Formats")]
		public object CoordUseLonlat { get; set; } = "false";

		/// <summary>
		/// <para>Input Coordinate System</para>
		/// <para>The coordinate system that will be used to interpret the spatial coordinates defined in the input. GCS-WGS-84 is the default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		[Category("Coordinate Formats")]
		public object InCoorSystem { get; set; } = "GEOGCS[\"GCS_WGS_1984\",DATUM[\"D_WGS_1984\",SPHEROID[\"WGS_1984\",6378137.0,298.257223563]],PRIMEM[\"Greenwich\",0.0],UNIT[\"Degree\",0.0174532925199433]];-400 -400 11258999068426.2;-100000 10000;-100000 10000;8.98315284119521E-09;0.001;0.001;IsHighPrecision";

		/// <summary>
		/// <para>Input Custom Locations</para>
		/// <para>The custom location file (.lxtgaz) that will be used when scanning the input content. A point is created to represent each occurrence of each place name in the custom location file up to the limits established by other tool parameters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("lxtgaz")]
		[Category("Custom Locations")]
		public object InCustomLocations { get; set; }

		/// <summary>
		/// <para>Use Fuzzy Matching</para>
		/// <para>Specifies whether fuzzy matching will be used when comparing the input content to the place names specified in the custom location file.</para>
		/// <para>Checked—Fuzzy matching will be used when searching the custom location file.</para>
		/// <para>Unchecked—Exact matching will be used when searching the custom location file. This is the default.</para>
		/// <para><see cref="FuzzyMatchEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Custom Locations")]
		public object FuzzyMatch { get; set; } = "false";

		/// <summary>
		/// <para>Maximum Number Of Extracted Features</para>
		/// <para>The maximum number of features that can be extracted. The tool will stop scanning the input content for locations when the maximum number is reached. When running as a geoprocessing service, the service and the server may have separate limits on the number of features allowed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 2147483647)]
		[Category("Feature Options")]
		public object MaxFeaturesExtracted { get; set; }

		/// <summary>
		/// <para>Ignore This First Number of Features</para>
		/// <para>The number of features detected and ignored before extracting all other features. This parameter can be used to focus the search on a specific portion of the data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 2147483647)]
		[Category("Feature Options")]
		public object IgnoreFirstFeatures { get; set; }

		/// <summary>
		/// <para>Month Name Used</para>
		/// <para>Specifies whether to search for dates in which the month name appears (infrequent false positives). 12 May 2003 and January 15, 1997 are examples.</para>
		/// <para>Checked—The tool will search for dates in which the month name appears. This is the default.</para>
		/// <para>Unchecked—The tool will not search for dates in which the month name appears.</para>
		/// <para><see cref="DateMonthnameEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Date Formats")]
		public object DateMonthname { get; set; } = "true";

		/// <summary>
		/// <para>M/D/Y and D/M/Y</para>
		/// <para>Specifies whether to search for dates in which numbers are in the M/D/Y or D/M/Y format (moderate false positives). 5/12/03 and 1-15-1997 are examples.</para>
		/// <para>Checked—The tool will search for dates in which numbers are in the M/D/Y or D/M/Y format (moderate false positives). This is the default.</para>
		/// <para>Unchecked—The tool will not search for dates in which numbers are in the M/D/Y or D/M/Y format.</para>
		/// <para><see cref="DateMDYEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Date Formats")]
		public object DateMDY { get; set; } = "true";

		/// <summary>
		/// <para>YYYYMMDD</para>
		/// <para>Specifies whether to search for dates in which numbers are in the YYYYMMDD format (moderate false positives). 20030512 and 19970115 are examples.</para>
		/// <para>Checked—The tool will search for dates in which numbers are in the YYYYMMDD format (moderate false positives). This is the default.</para>
		/// <para>Unchecked—The tool will not search for dates in which numbers are in the YYYYMMDD format.</para>
		/// <para><see cref="DateYyyymmddEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Date Formats")]
		public object DateYyyymmdd { get; set; } = "true";

		/// <summary>
		/// <para>YYMMDD</para>
		/// <para>Specifies whether to search for dates in which numbers are in the YYMMDD format (frequent false positives). 030512 and 970115 are examples.</para>
		/// <para>Checked—The tool will search for dates in which numbers are in the YYMMDD format (frequent false positives). This is the default.</para>
		/// <para>Unchecked—The tool will not search for dates in which numbers are in the YYMMDD format.</para>
		/// <para><see cref="DateYymmddEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Date Formats")]
		public object DateYymmdd { get; set; } = "true";

		/// <summary>
		/// <para>YYJJJ</para>
		/// <para>Specifies whether to search for dates in which numbers are in the YYJJJ or YYYYJJJ format (frequent false positives). 03132 and 97015 are examples.</para>
		/// <para>Checked—The tool will search for dates in which numbers are in the YYJJJ or YYYYJJJ format (frequent false positives). This is the default.</para>
		/// <para>Unchecked—The tool will not search for dates in which numbers are in the YYJJJ or YYYYJJJ format.</para>
		/// <para><see cref="DateYyjjjEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Date Formats")]
		public object DateYyjjj { get; set; } = "true";

		/// <summary>
		/// <para>Maximum Number Of Extracted Dates</para>
		/// <para>The maximum number of dates that will be extracted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 2147483647)]
		[Category("Date Options")]
		public object MaxDatesExtracted { get; set; }

		/// <summary>
		/// <para>Ignore This First Number Of Dates</para>
		/// <para>The number of dates that will be detected and ignored before extracting all other dates.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 2147483647)]
		[Category("Date Options")]
		public object IgnoreFirstDates { get; set; }

		/// <summary>
		/// <para>Earliest Date Of Acceptable Date Range</para>
		/// <para>The earliest acceptable date to extract. Detected dates matching this value or later will be extracted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Date Options")]
		public object DateRangeBegin { get; set; }

		/// <summary>
		/// <para>Latest Date Of Acceptable Date Range</para>
		/// <para>The latest acceptable date to extract. Detected dates matching this value or earlier will be extracted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Date Options")]
		public object DateRangeEnd { get; set; }

		/// <summary>
		/// <para>Input Custom Attributes</para>
		/// <para>The custom attribute file (.lxtca) that will be used to scan the input content. Fields will be created in the output feature class's attribute table for all custom attributes defined in the file. When the input content is scanned, it will be examined to see if it contains text associated with all custom attributes specified in the file. When a match is found, the appropriate text is extracted from the input content and stored in the appropriate field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("lxtca")]
		[Category("Custom Attributes")]
		public object InCustomAttributes { get; set; }

		/// <summary>
		/// <para>Input File Link Text</para>
		/// <para>The file path that will be used as the file name in the output data when the Input File parameter (in_file in Python) is transferred to the server. If this parameter is not specified, the path of the Input File will be used, which may be an unreachable folder on a server. This parameter has no effect when the Input File is not specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Input File Information")]
		public object FileLink { get; set; }

		/// <summary>
		/// <para>Input File Date and Time</para>
		/// <para>The UTC date and time that the file was modified will be used as the modified attribute in the output data when the Input File parameter (in_file in Python) is transferred to the server. If this parameter is not specified, the current modified time of the input file will be used. This parameter has no effect when the Input File is not specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Input File Information")]
		public object FileModDatetime { get; set; }

		/// <summary>
		/// <para>Pre-Text Field Length</para>
		/// <para>Content is extracted from the input document to provide context for the location that was found. This parameter defines the maximum number of characters that will be extracted preceding the text that defines the location. The extracted text is stored in the Pre-Text field in the output feature class's attribute table. The default is 254. The Pre-Text field's data type will also have this length. The length of a text field in a shapefile is limited to 254 characters; when the output is a shapefile, a larger number of characters will be truncated to 254.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 2147483647)]
		[Category("Feature Options")]
		public object PreTextLength { get; set; } = "254";

		/// <summary>
		/// <para>Post-Text Field Length</para>
		/// <para>Content is extracted from the input document to provide context for the location that was found. This parameter defines the maximum number of characters that will be extracted following the text that defines the location. The extracted text is stored in the Post-Text field in the output feature class's attribute table. The default is 254. The Post-Text field's data type will also have this length. The length of a text field in a shapefile is limited to 254 characters; when the output is a shapefile, a larger number of characters will be truncated to 254.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 2147483647)]
		[Category("Feature Options")]
		public object PostTextLength { get; set; } = "254";

		/// <summary>
		/// <para>Coordinate Format</para>
		/// <para>Specifies the coordinate format that will be used to store the coordinate location. A standard representation of the spatial coordinate that defines the point feature is recorded in a field in the attribute table.</para>
		/// <para>DD - Decimal Degrees—The coordinate location is recorded in decimal degrees format. This is the default.</para>
		/// <para>DM - Degrees Decimal Minutes—The coordinate location is recorded in degrees decimal minutes format.</para>
		/// <para>DMS - Degrees Minutes Seconds—The coordinate location is recorded in degrees minutes seconds format.</para>
		/// <para>UTM - Universal Transverse Mercator—The coordinate location is recorded in Universal Transverse Mercator format.</para>
		/// <para>MGRS - Military Grid Reference System—The coordinate location is recorded in Military Grid Reference System format.</para>
		/// <para><see cref="StdCoordFmtEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Standardized Coordinate")]
		public object StdCoordFmt { get; set; } = "STD_COORD_FMT_DD";

		/// <summary>
		/// <para>Require Word Breaks</para>
		/// <para>Specifies whether to search for text using word breaks. A word break occurs when words (text) are bounded by whitespace or punctuation characters as in European languages.</para>
		/// <para>This setting can produce frequent false positives or infrequent false positives depending on the language of the text. For example, when word breaks are not required, the English text Bernard will produce a match against the text San Bernardino, which would likely be considered a false positive. However, when text is written using a language that does not use word breaks, you cannot find words if word breaks are required. For example, with the text I flew to Tokyo in Japanese, 私は東京に飛んで, you would only be able to find the word Tokyo, 東京, when word breaks are not required.</para>
		/// <para>Checked—The tool will search for words that are bounded by whitespace or punctuation characters. This is the default.</para>
		/// <para>Unchecked—The tool will not search for words that are bounded by whitespace or punctuation characters.</para>
		/// <para><see cref="ReqWordBreaksEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Search Control")]
		public object ReqWordBreaks { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractLocationsDocument SetEnviroment(object geographicTransformations = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Latitude And Longitude</para>
		/// </summary>
		public enum CoordDdLatlonEnum 
		{
			/// <summary>
			/// <para>Checked—The tool will search for decimal degrees coordinates formatted as latitude and longitude. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FIND_DD_LATLON")]
			FIND_DD_LATLON,

			/// <summary>
			/// <para>Unchecked—The tool will not search for decimal degrees coordinates formatted as latitude and longitude.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_FIND_DD_LATLON")]
			DONT_FIND_DD_LATLON,

		}

		/// <summary>
		/// <para>X Y With Degree Symbols</para>
		/// </summary>
		public enum CoordDdXydegEnum 
		{
			/// <summary>
			/// <para>Checked—The tool will search for decimal degrees coordinates formatted as X Y with degree symbols. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FIND_DD_XYDEG")]
			FIND_DD_XYDEG,

			/// <summary>
			/// <para>Unchecked—The tool will not search for decimal degrees coordinates formatted as X Y with degree symbols.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_FIND_DD_XYDEG")]
			DONT_FIND_DD_XYDEG,

		}

		/// <summary>
		/// <para>X Y With No Symbols</para>
		/// </summary>
		public enum CoordDdXyplainEnum 
		{
			/// <summary>
			/// <para>Checked—The tool will search for decimal degrees coordinates formatted as X Y with no symbols (frequent false positives). This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FIND_DD_XYPLAIN")]
			FIND_DD_XYPLAIN,

			/// <summary>
			/// <para>Unchecked—The tool will not search for decimal degrees coordinates formatted as X Y with no symbols.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_FIND_DD_XYPLAIN")]
			DONT_FIND_DD_XYPLAIN,

		}

		/// <summary>
		/// <para>Latitude And Longitude</para>
		/// </summary>
		public enum CoordDmLatlonEnum 
		{
			/// <summary>
			/// <para>Checked—The tool will search for degrees decimal minutes coordinates formatted as latitude and longitude. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FIND_DM_LATLON")]
			FIND_DM_LATLON,

			/// <summary>
			/// <para>Unchecked—The tool will not search for degrees decimal minutes coordinates formatted as latitude and longitude.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_FIND_DM_LATLON")]
			DONT_FIND_DM_LATLON,

		}

		/// <summary>
		/// <para>X Y With Minutes Symbols</para>
		/// </summary>
		public enum CoordDmXyminEnum 
		{
			/// <summary>
			/// <para>Checked—The tool will search for degrees decimal minutes coordinates formatted as X Y with minutes symbols. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FIND_DM_XYMIN")]
			FIND_DM_XYMIN,

			/// <summary>
			/// <para>Unchecked—The tool will not search for degrees decimal minutes coordinates formatted as X Y with minutes symbols.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_FIND_DM_XYMIN")]
			DONT_FIND_DM_XYMIN,

		}

		/// <summary>
		/// <para>Latitude And Longitude</para>
		/// </summary>
		public enum CoordDmsLatlonEnum 
		{
			/// <summary>
			/// <para>Checked—The tool will search for degrees minutes seconds coordinates formatted as latitude and longitude. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FIND_DMS_LATLON")]
			FIND_DMS_LATLON,

			/// <summary>
			/// <para>Unchecked—The tool will not search for degrees minutes seconds coordinates formatted as latitude and longitude.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_FIND_DMS_LATLON")]
			DONT_FIND_DMS_LATLON,

		}

		/// <summary>
		/// <para>X Y With Seconds Symbols</para>
		/// </summary>
		public enum CoordDmsXysecEnum 
		{
			/// <summary>
			/// <para>Checked—The tool will search for degrees minutes seconds coordinates formatted as X Y with seconds symbols. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FIND_DMS_XYSEC")]
			FIND_DMS_XYSEC,

			/// <summary>
			/// <para>Unchecked—The tool will not search for degrees minutes seconds coordinates formatted as X Y with seconds symbols.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_FIND_DMS_XYSEC")]
			DONT_FIND_DMS_XYSEC,

		}

		/// <summary>
		/// <para>X Y With Separators</para>
		/// </summary>
		public enum CoordDmsXysepEnum 
		{
			/// <summary>
			/// <para>Checked—The tool will search for degrees minutes seconds coordinates formatted as X Y with separators. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FIND_DMS_XYSEP")]
			FIND_DMS_XYSEP,

			/// <summary>
			/// <para>Unchecked—The tool will not search for degrees minutes seconds coordinates formatted as X Y with separators.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_FIND_DMS_XYSEP")]
			DONT_FIND_DMS_XYSEP,

		}

		/// <summary>
		/// <para>Universal Transverse Mercator</para>
		/// </summary>
		public enum CoordUtmEnum 
		{
			/// <summary>
			/// <para>Checked—The tool will search for UTM coordinates. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FIND_UTM_MAINWORLD")]
			FIND_UTM_MAINWORLD,

			/// <summary>
			/// <para>Unchecked—The tool will not search for UTM coordinates.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_FIND_UTM_MAINWORLD")]
			DONT_FIND_UTM_MAINWORLD,

		}

		/// <summary>
		/// <para>UPS North Polar</para>
		/// </summary>
		public enum CoordUpsNorthEnum 
		{
			/// <summary>
			/// <para>Checked—The tool will search for UPS coordinates in the north polar area. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FIND_UTM_NORTHPOLAR")]
			FIND_UTM_NORTHPOLAR,

			/// <summary>
			/// <para>Unchecked—The tool will not search for UPS coordinates in the north polar area.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_FIND_UTM_NORTHPOLAR")]
			DONT_FIND_UTM_NORTHPOLAR,

		}

		/// <summary>
		/// <para>UPS South Polar</para>
		/// </summary>
		public enum CoordUpsSouthEnum 
		{
			/// <summary>
			/// <para>Checked—The tool will search for UPS coordinates in the south polar area. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FIND_UTM_SOUTHPOLAR")]
			FIND_UTM_SOUTHPOLAR,

			/// <summary>
			/// <para>Unchecked—The tool will not search for UPS coordinates in the south polar area.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_FIND_UTM_SOUTHPOLAR")]
			DONT_FIND_UTM_SOUTHPOLAR,

		}

		/// <summary>
		/// <para>Military Grid Reference System</para>
		/// </summary>
		public enum CoordMgrsEnum 
		{
			/// <summary>
			/// <para>Checked—The tool will search for MGRS coordinates. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FIND_MGRS_MAINWORLD")]
			FIND_MGRS_MAINWORLD,

			/// <summary>
			/// <para>Unchecked—The tool will not search for MGRS coordinates.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_FIND_MGRS_MAINWORLD")]
			DONT_FIND_MGRS_MAINWORLD,

		}

		/// <summary>
		/// <para>North Polar</para>
		/// </summary>
		public enum CoordMgrsNorthpolarEnum 
		{
			/// <summary>
			/// <para>Checked—The tool will search for MGRS coordinates in the north polar area. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FIND_MGRS_NORTHPOLAR")]
			FIND_MGRS_NORTHPOLAR,

			/// <summary>
			/// <para>Unchecked—The tool will not search for MGRS coordinates in the north polar area.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_FIND_MGRS_NORTHPOLAR")]
			DONT_FIND_MGRS_NORTHPOLAR,

		}

		/// <summary>
		/// <para>South Polar</para>
		/// </summary>
		public enum CoordMgrsSouthpolarEnum 
		{
			/// <summary>
			/// <para>Checked—The tool will search for MGRS coordinates in the south polar area. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FIND_MGRS_SOUTHPOLAR")]
			FIND_MGRS_SOUTHPOLAR,

			/// <summary>
			/// <para>Unchecked—The tool will not search for MGRS coordinates in the south polar area.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_FIND_MGRS_SOUTHPOLAR")]
			DONT_FIND_MGRS_SOUTHPOLAR,

		}

		/// <summary>
		/// <para>Use Comma As Decimal Separator</para>
		/// </summary>
		public enum CommaDecimalEnum 
		{
			/// <summary>
			/// <para>Checked—A comma will be recognized as the decimal separator.</para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_COMMA_DECIMAL_MARK")]
			USE_COMMA_DECIMAL_MARK,

			/// <summary>
			/// <para>Unchecked—A period or a middle dot will be recognized as the decimal separator. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("USE_DOT_DECIMAL_MARK")]
			USE_DOT_DECIMAL_MARK,

		}

		/// <summary>
		/// <para>Interpret As Longitude, Latitude</para>
		/// </summary>
		public enum CoordUseLonlatEnum 
		{
			/// <summary>
			/// <para>Checked—x,y coordinates will be interpreted as longitude-latitude.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PREFER_LONLAT")]
			PREFER_LONLAT,

			/// <summary>
			/// <para>Unchecked—x,y coordinates will be interpreted as latitude-longitude. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("PREFER_LATLON")]
			PREFER_LATLON,

		}

		/// <summary>
		/// <para>Use Fuzzy Matching</para>
		/// </summary>
		public enum FuzzyMatchEnum 
		{
			/// <summary>
			/// <para>Checked—Fuzzy matching will be used when searching the custom location file.</para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_FUZZY")]
			USE_FUZZY,

			/// <summary>
			/// <para>Unchecked—Exact matching will be used when searching the custom location file. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_USE_FUZZY")]
			DONT_USE_FUZZY,

		}

		/// <summary>
		/// <para>Month Name Used</para>
		/// </summary>
		public enum DateMonthnameEnum 
		{
			/// <summary>
			/// <para>Checked—The tool will search for dates in which the month name appears. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FIND_DATE_MONTHNAME")]
			FIND_DATE_MONTHNAME,

			/// <summary>
			/// <para>Unchecked—The tool will not search for dates in which the month name appears.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_FIND_DATE_MONTHNAME")]
			DONT_FIND_DATE_MONTHNAME,

		}

		/// <summary>
		/// <para>M/D/Y and D/M/Y</para>
		/// </summary>
		public enum DateMDYEnum 
		{
			/// <summary>
			/// <para>Checked—The tool will search for dates in which numbers are in the M/D/Y or D/M/Y format (moderate false positives). This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FIND_DATE_M_D_Y")]
			FIND_DATE_M_D_Y,

			/// <summary>
			/// <para>Unchecked—The tool will not search for dates in which numbers are in the M/D/Y or D/M/Y format.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_FIND_DATE_M_D_Y")]
			DONT_FIND_DATE_M_D_Y,

		}

		/// <summary>
		/// <para>YYYYMMDD</para>
		/// </summary>
		public enum DateYyyymmddEnum 
		{
			/// <summary>
			/// <para>Checked—The tool will search for dates in which numbers are in the YYYYMMDD format (moderate false positives). This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FIND_DATE_YYYYMMDD")]
			FIND_DATE_YYYYMMDD,

			/// <summary>
			/// <para>Unchecked—The tool will not search for dates in which numbers are in the YYYYMMDD format.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_FIND_DATE_YYYYMMDD")]
			DONT_FIND_DATE_YYYYMMDD,

		}

		/// <summary>
		/// <para>YYMMDD</para>
		/// </summary>
		public enum DateYymmddEnum 
		{
			/// <summary>
			/// <para>Checked—The tool will search for dates in which numbers are in the YYMMDD format (frequent false positives). This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FIND_DATE_YYMMDD")]
			FIND_DATE_YYMMDD,

			/// <summary>
			/// <para>Unchecked—The tool will not search for dates in which numbers are in the YYMMDD format.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_FIND_DATE_YYMMDD")]
			DONT_FIND_DATE_YYMMDD,

		}

		/// <summary>
		/// <para>YYJJJ</para>
		/// </summary>
		public enum DateYyjjjEnum 
		{
			/// <summary>
			/// <para>Checked—The tool will search for dates in which numbers are in the YYJJJ or YYYYJJJ format (frequent false positives). This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FIND_DATE_YYJJJ")]
			FIND_DATE_YYJJJ,

			/// <summary>
			/// <para>Unchecked—The tool will not search for dates in which numbers are in the YYJJJ or YYYYJJJ format.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_FIND_DATE_YYJJJ")]
			DONT_FIND_DATE_YYJJJ,

		}

		/// <summary>
		/// <para>Coordinate Format</para>
		/// </summary>
		public enum StdCoordFmtEnum 
		{
			/// <summary>
			/// <para>DD - Decimal Degrees—The coordinate location is recorded in decimal degrees format. This is the default.</para>
			/// </summary>
			[GPValue("STD_COORD_FMT_DD")]
			[Description("DD - Decimal Degrees")]
			STD_COORD_FMT_DD,

			/// <summary>
			/// <para>DM - Degrees Decimal Minutes—The coordinate location is recorded in degrees decimal minutes format.</para>
			/// </summary>
			[GPValue("STD_COORD_FMT_DM")]
			[Description("DM - Degrees Decimal Minutes")]
			STD_COORD_FMT_DM,

			/// <summary>
			/// <para>DMS - Degrees Minutes Seconds—The coordinate location is recorded in degrees minutes seconds format.</para>
			/// </summary>
			[GPValue("STD_COORD_FMT_DMS")]
			[Description("DMS - Degrees Minutes Seconds")]
			STD_COORD_FMT_DMS,

			/// <summary>
			/// <para>UTM - Universal Transverse Mercator—The coordinate location is recorded in Universal Transverse Mercator format.</para>
			/// </summary>
			[GPValue("STD_COORD_FMT_UTM")]
			[Description("UTM - Universal Transverse Mercator")]
			STD_COORD_FMT_UTM,

			/// <summary>
			/// <para>MGRS - Military Grid Reference System—The coordinate location is recorded in Military Grid Reference System format.</para>
			/// </summary>
			[GPValue("STD_COORD_FMT_MGRS")]
			[Description("MGRS - Military Grid Reference System")]
			STD_COORD_FMT_MGRS,

		}

		/// <summary>
		/// <para>Require Word Breaks</para>
		/// </summary>
		public enum ReqWordBreaksEnum 
		{
			/// <summary>
			/// <para>Checked—The tool will search for words that are bounded by whitespace or punctuation characters. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REQ_WORD_BREAKS")]
			REQ_WORD_BREAKS,

			/// <summary>
			/// <para>Unchecked—The tool will not search for words that are bounded by whitespace or punctuation characters.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DONT_REQ_WORD_BREAKS")]
			DONT_REQ_WORD_BREAKS,

		}

#endregion
	}
}
