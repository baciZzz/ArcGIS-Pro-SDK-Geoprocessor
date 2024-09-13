using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ModelTools
{
	/// <summary>
	/// <para>Iterate Field Values</para>
	/// <para>Iterate Field Values</para>
	/// <para>Iterates each value in a field.</para>
	/// </summary>
	public class IterateFieldValues : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The input table to be iterated.</para>
		/// </param>
		/// <param name="Field">
		/// <para>Field</para>
		/// <para>The input field for iteration.</para>
		/// </param>
		public IterateFieldValues(object InTable, object Field)
		{
			this.InTable = InTable;
			this.Field = Field;
		}

		/// <summary>
		/// <para>Tool Display Name : Iterate Field Values</para>
		/// </summary>
		public override string DisplayName() => "Iterate Field Values";

		/// <summary>
		/// <para>Tool Name : IterateFieldValues</para>
		/// </summary>
		public override string ToolName() => "IterateFieldValues";

		/// <summary>
		/// <para>Tool Excute Name : mb.IterateFieldValues</para>
		/// </summary>
		public override string ExcuteName() => "mb.IterateFieldValues";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise() => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, Field, DataType!, UniqueValues!, SkipNulls!, NullValue!, Value! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input table to be iterated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Field</para>
		/// <para>The input field for iteration.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long", "Short", "Text", "OID", "Float", "Double", "Date", "GUID", "GlobalID", "XML")]
		public object Field { get; set; }

		/// <summary>
		/// <para>Data Type</para>
		/// <para>Specifies the data type of the output value. The default data type is string; however, depending on how the output will be used in the model, other data types can be specified. For example, if your field contains the path to a feature class, you can set this parameter to Feature Class and use the output variable as input to a tool that accepts a feature class.</para>
		/// <para>Address Locator—Address Locator</para>
		/// <para>Analysis Cell Size—Analysis Cell Size</para>
		/// <para>Annotation Layer—Annotation Layer</para>
		/// <para>Any Value—Any Value</para>
		/// <para>ArcMap Document—ArcMap Document</para>
		/// <para>Areal Unit—Areal Unit</para>
		/// <para>BIM File Workspace—BIM File Workspace</para>
		/// <para>Boolean—Boolean</para>
		/// <para>Building Discipline Layer—Building Discipline Layer</para>
		/// <para>Building Scene Discipline Layer—Building Scene Discipline Layer</para>
		/// <para>Building Layer—Building Layer</para>
		/// <para>Building Scene Layer—Building Scene Layer</para>
		/// <para>CAD Drawing Dataset—CAD Drawing Dataset</para>
		/// <para>Calculator Expression—Calculator Expression</para>
		/// <para>Catalog Root—Catalog Root</para>
		/// <para>Cell Size—Cell Size</para>
		/// <para>Cell Size XY—Cell Size XY</para>
		/// <para>Composite Layer—Composite Layer</para>
		/// <para>Compression—Compression</para>
		/// <para>Coordinate System—Coordinate System</para>
		/// <para>Coordinate Systems Folder—Coordinate Systems Folder</para>
		/// <para>Coverage—Coverage</para>
		/// <para>Coverage Feature Class—Coverage Feature Class</para>
		/// <para>Data Element—Data Element</para>
		/// <para>Data File—Data File</para>
		/// <para>Database Connections—Database Connections</para>
		/// <para>Dataset—Dataset</para>
		/// <para>Date—Date</para>
		/// <para>dBASE Table—dBASE Table</para>
		/// <para>Decimate—Decimate</para>
		/// <para>Diagram Layer—Diagram Layer</para>
		/// <para>Dimension Layer—Dimension Layer</para>
		/// <para>Disk Connection—Disk Connection</para>
		/// <para>Double—Double</para>
		/// <para>Elevation Surface Layer—Elevation Surface Layer</para>
		/// <para>Encrypted String—Encrypted String</para>
		/// <para>Envelope—Envelope</para>
		/// <para>Evaluation Scale—Evaluation Scale</para>
		/// <para>Extent—Extent</para>
		/// <para>Extract Values—Extract Values</para>
		/// <para>Feature Class—Feature Class</para>
		/// <para>Feature Dataset—Feature Dataset</para>
		/// <para>Feature Layer—Feature Layer</para>
		/// <para>Feature Set—Feature Set</para>
		/// <para>Field—Field</para>
		/// <para>Field Info—Field Info</para>
		/// <para>Field Mappings—Field Mappings</para>
		/// <para>File—File</para>
		/// <para>Folder—Folder</para>
		/// <para>Formulated Raster—Formulated Raster</para>
		/// <para>Fuzzy Function—Fuzzy Function</para>
		/// <para>GeoDataServer—GeoDataServer</para>
		/// <para>Geodataset—Geodataset</para>
		/// <para>Geometric Network—Geometric Network</para>
		/// <para>Geostatistical Layer—Geostatistical Layer</para>
		/// <para>Geostatistical Search Neighborhood—Geostatistical Search Neighborhood</para>
		/// <para>Geostatistical Value Table—Geostatistical Value Table</para>
		/// <para>GlobeServer—GlobeServer</para>
		/// <para>GPServer—GPServer</para>
		/// <para>Graph—Graph</para>
		/// <para>Graph Data Table—Graph Data Table</para>
		/// <para>Graphics Layer—Graphics Layer</para>
		/// <para>Group Layer—Group Layer</para>
		/// <para>Horizontal Factor—Horizontal Factor</para>
		/// <para>Image Service—Image Service</para>
		/// <para>Index—Index</para>
		/// <para>INFO Expression—INFO Expression</para>
		/// <para>INFO Item—INFO Item</para>
		/// <para>INFO Table—INFO Table</para>
		/// <para>Internet Tiled Layer—Internet Tiled Layer</para>
		/// <para>KML Layer—KML Layer</para>
		/// <para>LAS Dataset—LAS Dataset</para>
		/// <para>LAS Dataset Layer—LAS Dataset Layer</para>
		/// <para>Layer—Layer</para>
		/// <para>Layer File—Layer File</para>
		/// <para>Layout—Layout</para>
		/// <para>Line—Line</para>
		/// <para>Linear Unit—Linear Unit</para>
		/// <para>Long—Long</para>
		/// <para>M Domain—M Domain</para>
		/// <para>Map—Map</para>
		/// <para>Map Server—Map Server</para>
		/// <para>Map Server Layer—Map Server Layer</para>
		/// <para>Mosaic Dataset—Mosaic Dataset</para>
		/// <para>Mosaic Layer—Mosaic Layer</para>
		/// <para>Neighborhood—Neighborhood</para>
		/// <para>Network Analyst Class FieldMap—Network Analyst Class FieldMap</para>
		/// <para>Network Analyst Hierarchy Settings—Network Analyst Hierarchy Settings</para>
		/// <para>Network Analyst Layer—Network Analyst Layer</para>
		/// <para>Network Data Source—Network Data Source</para>
		/// <para>Network Dataset—Network Dataset</para>
		/// <para>Network Dataset Layer—Network Dataset Layer</para>
		/// <para>Network Travel Mode—Network Travel Mode</para>
		/// <para>Parcel Fabric—Parcel Fabric</para>
		/// <para>Parcel Fabric for ArcMap—Parcel Fabric for ArcMap</para>
		/// <para>Parcel Fabric Layer for ArcMap—Parcel Fabric Layer for ArcMap</para>
		/// <para>Parcel Layer—Parcel Layer</para>
		/// <para>Point—Point</para>
		/// <para>Polygon—Polygon</para>
		/// <para>Projection File—Projection File</para>
		/// <para>Pyramid—Pyramid</para>
		/// <para>Radius—Radius</para>
		/// <para>Random Number Generator—Random Number Generator</para>
		/// <para>Raster Band—Raster Band</para>
		/// <para>Raster Calculator Expression—Raster Calculator Expression</para>
		/// <para>Raster Catalog—Raster Catalog</para>
		/// <para>Raster Catalog Layer—Raster Catalog Layer</para>
		/// <para>Raster Data Layer—Raster Data Layer</para>
		/// <para>Raster Dataset—Raster Dataset</para>
		/// <para>Raster Layer—Raster Layer</para>
		/// <para>Raster Statistics—Raster Statistics</para>
		/// <para>Raster Type—Raster Type</para>
		/// <para>Record Set—Record Set</para>
		/// <para>Relationship Class—Relationship Class</para>
		/// <para>Remap—Remap</para>
		/// <para>Report—Report</para>
		/// <para>Route Measure Event Properties—Route Measure Event Properties</para>
		/// <para>Scene Layer—Scene Layer</para>
		/// <para>Semivariogram—Semivariogram</para>
		/// <para>ServerConnection—ServerConnection</para>
		/// <para>Shapefile—Shapefile</para>
		/// <para>Spatial Reference—Spatial Reference</para>
		/// <para>SQL Expression—SQL Expression</para>
		/// <para>String—String</para>
		/// <para>String Hidden—String Hidden</para>
		/// <para>Table—Table</para>
		/// <para>Table View—Table View</para>
		/// <para>Terrain Layer—Terrain Layer</para>
		/// <para>Text File—Text File</para>
		/// <para>Tile Size—Tile Size</para>
		/// <para>Time Configuration—Time Configuration</para>
		/// <para>Time Unit—Time Unit</para>
		/// <para>TIN—TIN</para>
		/// <para>TIN Layer—TIN Layer</para>
		/// <para>Tool—Tool</para>
		/// <para>Toolbox—Toolbox</para>
		/// <para>Topo Features—Topo Features</para>
		/// <para>Topology—Topology</para>
		/// <para>Topology Layer—Topology Layer</para>
		/// <para>Trace Network—Trace Network</para>
		/// <para>Trace Network Layer—Trace Network Layer</para>
		/// <para>Transformation Function—Transformation Function</para>
		/// <para>Utility Network—Utility Network</para>
		/// <para>Utility Network Layer—Utility Network Layer</para>
		/// <para>Variant—Variant</para>
		/// <para>Vector Tile Layer—Vector Tile Layer</para>
		/// <para>Vertical Factor—Vertical Factor</para>
		/// <para>Voxel Layer—Voxel Layer</para>
		/// <para>VPF Coverage—VPF Coverage</para>
		/// <para>VPF Table—VPF Table</para>
		/// <para>WCS Coverage—WCS Coverage</para>
		/// <para>Weighted Overlay Table—Weighted Overlay Table</para>
		/// <para>Weighted Sum—Weighted Sum</para>
		/// <para>WMS Map—WMS Map</para>
		/// <para>WMTS Layer—WMTS Layer</para>
		/// <para>Workspace—Workspace</para>
		/// <para>XY Domain—XY Domain</para>
		/// <para>Z Domain—Z Domain</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DataType { get; set; } = "GPString";

		/// <summary>
		/// <para>Unique Values</para>
		/// <para>Specifies whether iteration values will be based on unique values.</para>
		/// <para>Checked—The iteration values will be based on the unique value of the specified field.</para>
		/// <para>Unchecked—The iteration will run for each record in the input table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		public object? UniqueValues { get; set; } = "true";

		/// <summary>
		/// <para>Skip Null Values</para>
		/// <para>Specifies whether null values in the field will be skipped.</para>
		/// <para>Checked—Null values in the field will be skipped during selection.</para>
		/// <para>Unchecked—Null values in the field will not be skipped during selection.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		public object? SkipNulls { get; set; } = "false";

		/// <summary>
		/// <para>Null Value</para>
		/// <para>The value that will be used to replace null values in the field, such as -9999, Null, or -1. The default for string fields is "" and 0 for numeric fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? NullValue { get; set; }

		/// <summary>
		/// <para>Value</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPType()]
		public object? Value { get; set; }

	}
}
