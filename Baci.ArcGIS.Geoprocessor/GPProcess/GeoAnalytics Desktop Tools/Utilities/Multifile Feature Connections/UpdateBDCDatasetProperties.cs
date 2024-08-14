using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsDesktopTools
{
	/// <summary>
	/// <para>Update Multifile Feature Connection Dataset Properties</para>
	/// <para>Updates the properties of a multifile feature connection (MFC) dataset. This tool modifies field, geometry, time, and file settings for a specified MFC dataset.</para>
	/// </summary>
	public class UpdateBDCDatasetProperties : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="BdcDataset">
		/// <para>Multifile Feature Connection Dataset</para>
		/// <para>The MFC dataset that will be updated. The options for editing will differ depending on the source data (shapefile, delimited file, ORC, or parquet file).</para>
		/// </param>
		public UpdateBDCDatasetProperties(object BdcDataset)
		{
			this.BdcDataset = BdcDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Update Multifile Feature Connection Dataset Properties</para>
		/// </summary>
		public override string DisplayName => "Update Multifile Feature Connection Dataset Properties";

		/// <summary>
		/// <para>Tool Name : UpdateBDCDatasetProperties</para>
		/// </summary>
		public override string ToolName => "UpdateBDCDatasetProperties";

		/// <summary>
		/// <para>Tool Excute Name : gapro.UpdateBDCDatasetProperties</para>
		/// </summary>
		public override string ExcuteName => "gapro.UpdateBDCDatasetProperties";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { BdcDataset, Expression!, FieldProperties!, GeometryType!, SpatialReference!, GeometryFormatType!, GeometryField!, XField!, YField!, ZField!, TimeType!, TimeZone!, StartTimeFormat!, EndTimeFormat!, FileExtension!, FieldDelimiter!, RecordTerminator!, QuoteCharacter!, HasHeaderRow!, Encoding!, UpdatedBdc };

		/// <summary>
		/// <para>Multifile Feature Connection Dataset</para>
		/// <para>The MFC dataset that will be updated. The options for editing will differ depending on the source data (shapefile, delimited file, ORC, or parquet file).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object BdcDataset { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>An expression used to limit the features that will be used in the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		[Category("Definition Query")]
		public object? Expression { get; set; }

		/// <summary>
		/// <para>Field Properties</para>
		/// <para>Specifies the field names and properties that will be modified.</para>
		/// <para>Short—The field will be type short.</para>
		/// <para>Long—The field will be type long</para>
		/// <para>Double—The field will be type double.</para>
		/// <para>Float—The field will be type float.</para>
		/// <para>String—The field will be type string.</para>
		/// <para>Date—The field will be type date.</para>
		/// <para>BLOB—The field will be type BLOB.</para>
		/// <para>Specifies whether fields will be visible or hidden.</para>
		/// <para>Checked—The fields will be visible and available for use in geoprocessing tools. This is the default.</para>
		/// <para>Unchecked—The fields will be hidden and cannot be used as input to geoprocessing tools.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Fields")]
		public object? FieldProperties { get; set; }

		/// <summary>
		/// <para>Geometry Type</para>
		/// <para>Specifies the type of geometry that will be used to spatially represent the dataset. The geometry cannot be modified for shapefile-sourced datasets.</para>
		/// <para>Point—The geometry type will be point.</para>
		/// <para>Polyline—The geometry type will be polyline.</para>
		/// <para>Polygon—The geometry type will be polygon.</para>
		/// <para>None—No geometry type is specified.</para>
		/// <para><see cref="GeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Geometry")]
		public object? GeometryType { get; set; }

		/// <summary>
		/// <para>Spatial Reference</para>
		/// <para>The WKID value or WKT string that will be used for the spatial reference of the dataset. The default is WKID 4326 (WGS84). The spatial reference cannot be modified for shapefile-sourced data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Geometry")]
		public object? SpatialReference { get; set; }

		/// <summary>
		/// <para>Geometry Format Type</para>
		/// <para>Specifies how the geometry will be formatted. The geometry cannot be modified for shapefile-sourced data.</para>
		/// <para>XYZ—Two or more fields will represent x, y, and optionally z.</para>
		/// <para>WKT—The geometry will be represented by a single field in a well-known text field.</para>
		/// <para>WKB—The geometry will be represented by a single field in a well-known binary field.</para>
		/// <para>GeoJSON—The geometry will be represented by a single field in GeoJSON format.</para>
		/// <para>EsriJSON—The geometry will be represented by a single field in EsriJSON format.</para>
		/// <para>EsriShape—The geometry will be represented by a single field in EsriShape format.</para>
		/// <para><see cref="GeometryFormatTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Geometry")]
		public object? GeometryFormatType { get; set; }

		/// <summary>
		/// <para>Geometry Field</para>
		/// <para>A single field used to represent the geometry. This field is used when the geometry format is WKT, WKB, GeoJSON, EsriJSON, or EsriShape.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Geometry")]
		public object? GeometryField { get; set; }

		/// <summary>
		/// <para>X Field</para>
		/// <para>The field used to represent the x-location. If more than one field represents the x-location, modify the .mfc file manually.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Geometry")]
		public object? XField { get; set; }

		/// <summary>
		/// <para>Y Field</para>
		/// <para>The field used to represent the y-location. If more than one field represents the y-location, modify the .mfc file manually.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Geometry")]
		public object? YField { get; set; }

		/// <summary>
		/// <para>Z Field</para>
		/// <para>The field used to represent the z-location. If more than one field represents the z-location, modify the .mfc file manually.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Geometry")]
		public object? ZField { get; set; }

		/// <summary>
		/// <para>Time Type</para>
		/// <para>Specifies the time type that will be used to temporally represent the dataset.</para>
		/// <para>Interval—The time type will represent a duration of time with a start and end time.</para>
		/// <para>Instant—The time type will represent an instant in time.</para>
		/// <para>None—Time is not enabled.</para>
		/// <para><see cref="TimeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Time")]
		public object? TimeType { get; set; }

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>The time zone of the dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Time")]
		public object? TimeZone { get; set; }

		/// <summary>
		/// <para>Start Time</para>
		/// <para>The fields used to define the start time and the time formatting.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Time")]
		public object? StartTimeFormat { get; set; }

		/// <summary>
		/// <para>End Time</para>
		/// <para>The fields used to define the end time and the time formatting.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Time")]
		public object? EndTimeFormat { get; set; }

		/// <summary>
		/// <para>File Extension</para>
		/// <para>The file extension of the source dataset. The parameter value cannot be modified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("File")]
		public object? FileExtension { get; set; }

		/// <summary>
		/// <para>Field Delimiter</para>
		/// <para>The field delimiter used in the source dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("File")]
		public object? FieldDelimiter { get; set; }

		/// <summary>
		/// <para>Record Terminator</para>
		/// <para>The record terminator used in the source dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("File")]
		public object? RecordTerminator { get; set; }

		/// <summary>
		/// <para>Quote Character</para>
		/// <para>The quote character used in the source dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("File")]
		public object? QuoteCharacter { get; set; }

		/// <summary>
		/// <para>Has Header Row</para>
		/// <para>Specifies whether the source dataset includes a header row.</para>
		/// <para>Checked—The source dataset includes a header row.</para>
		/// <para>Unchecked—The source dataset does not include a header row.</para>
		/// <para><see cref="HasHeaderRowEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("File")]
		public object? HasHeaderRow { get; set; }

		/// <summary>
		/// <para>Encoding</para>
		/// <para>The type of encoding used by the source dataset. UTF-8 is used by default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("File")]
		public object? Encoding { get; set; }

		/// <summary>
		/// <para>Updated MFC</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object? UpdatedBdc { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Geometry Type</para>
		/// </summary>
		public enum GeometryTypeEnum 
		{
			/// <summary>
			/// <para>Point—The geometry type will be point.</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("Point")]
			Point,

			/// <summary>
			/// <para>Polyline—The geometry type will be polyline.</para>
			/// </summary>
			[GPValue("LINE")]
			[Description("Polyline")]
			Polyline,

			/// <summary>
			/// <para>Polygon—The geometry type will be polygon.</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("Polygon")]
			Polygon,

			/// <summary>
			/// <para>None—No geometry type is specified.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

		}

		/// <summary>
		/// <para>Geometry Format Type</para>
		/// </summary>
		public enum GeometryFormatTypeEnum 
		{
			/// <summary>
			/// <para>XYZ—Two or more fields will represent x, y, and optionally z.</para>
			/// </summary>
			[GPValue("XYZ")]
			[Description("XYZ")]
			XYZ,

			/// <summary>
			/// <para>WKT—The geometry will be represented by a single field in a well-known text field.</para>
			/// </summary>
			[GPValue("WKT")]
			[Description("WKT")]
			WKT,

			/// <summary>
			/// <para>WKB—The geometry will be represented by a single field in a well-known binary field.</para>
			/// </summary>
			[GPValue("WKB")]
			[Description("WKB")]
			WKB,

			/// <summary>
			/// <para>GeoJSON—The geometry will be represented by a single field in GeoJSON format.</para>
			/// </summary>
			[GPValue("GEOJSON")]
			[Description("GeoJSON")]
			GeoJSON,

			/// <summary>
			/// <para>EsriJSON—The geometry will be represented by a single field in EsriJSON format.</para>
			/// </summary>
			[GPValue("ESRIJSON")]
			[Description("EsriJSON")]
			EsriJSON,

			/// <summary>
			/// <para>EsriShape—The geometry will be represented by a single field in EsriShape format.</para>
			/// </summary>
			[GPValue("ESRISHAPE")]
			[Description("EsriShape")]
			EsriShape,

		}

		/// <summary>
		/// <para>Time Type</para>
		/// </summary>
		public enum TimeTypeEnum 
		{
			/// <summary>
			/// <para>Instant—The time type will represent an instant in time.</para>
			/// </summary>
			[GPValue("INSTANT")]
			[Description("Instant")]
			Instant,

			/// <summary>
			/// <para>Interval—The time type will represent a duration of time with a start and end time.</para>
			/// </summary>
			[GPValue("INTERVAL")]
			[Description("Interval")]
			Interval,

			/// <summary>
			/// <para>None—Time is not enabled.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

		}

		/// <summary>
		/// <para>Has Header Row</para>
		/// </summary>
		public enum HasHeaderRowEnum 
		{
			/// <summary>
			/// <para>Checked—The source dataset includes a header row.</para>
			/// </summary>
			[GPValue("true")]
			[Description("HAS_HEADER")]
			HAS_HEADER,

			/// <summary>
			/// <para>Unchecked—The source dataset does not include a header row.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_HEADER")]
			NO_HEADER,

		}

#endregion
	}
}
