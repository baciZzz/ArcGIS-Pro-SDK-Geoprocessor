using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Zonal Histogram</para>
	/// <para>Creates a table and a histogram graph that show the frequency distribution of cell values on the value input for each unique zone.</para>
	/// </summary>
	public class ZonalHistogram : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InZoneData">
		/// <para>Input raster or feature zone data</para>
		/// <para>The dataset that defines the zones.</para>
		/// <para>The zones can be defined by an integer raster or a feature layer.</para>
		/// </param>
		/// <param name="ZoneField">
		/// <para>Zone field</para>
		/// <para>The field that contains the values that define each zone.</para>
		/// <para>It can be an integer or a string field of the zone dataset.</para>
		/// </param>
		/// <param name="InValueRaster">
		/// <para>Input value raster</para>
		/// <para>The raster that contains the values used to create the histogram.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output table</para>
		/// <para>The output table file.</para>
		/// <para>The format of the table is determined by the output location and path. By default, the output will be a geodatabase table if in a geodatabase workspace, and a dBASE table if in a file workspace.</para>
		/// <para>The optional graph output is created from the information in the table.</para>
		/// </param>
		public ZonalHistogram(object InZoneData, object ZoneField, object InValueRaster, object OutTable)
		{
			this.InZoneData = InZoneData;
			this.ZoneField = ZoneField;
			this.InValueRaster = InValueRaster;
			this.OutTable = OutTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Zonal Histogram</para>
		/// </summary>
		public override string DisplayName => "Zonal Histogram";

		/// <summary>
		/// <para>Tool Name : ZonalHistogram</para>
		/// </summary>
		public override string ToolName => "ZonalHistogram";

		/// <summary>
		/// <para>Tool Excute Name : sa.ZonalHistogram</para>
		/// </summary>
		public override string ExcuteName => "sa.ZonalHistogram";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "qualifiedFieldNames", "scratchWorkspace", "snapRaster", "tileSize", "transferDomains", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InZoneData, ZoneField, InValueRaster, OutTable, OutGraph, ZonesAsRows };

		/// <summary>
		/// <para>Input raster or feature zone data</para>
		/// <para>The dataset that defines the zones.</para>
		/// <para>The zones can be defined by an integer raster or a feature layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InZoneData { get; set; }

		/// <summary>
		/// <para>Zone field</para>
		/// <para>The field that contains the values that define each zone.</para>
		/// <para>It can be an integer or a string field of the zone dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object ZoneField { get; set; }

		/// <summary>
		/// <para>Input value raster</para>
		/// <para>The raster that contains the values used to create the histogram.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InValueRaster { get; set; }

		/// <summary>
		/// <para>Output table</para>
		/// <para>The output table file.</para>
		/// <para>The format of the table is determined by the output location and path. By default, the output will be a geodatabase table if in a geodatabase workspace, and a dBASE table if in a file workspace.</para>
		/// <para>The optional graph output is created from the information in the table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Output graph name</para>
		/// <para>The name of the output graph for display.</para>
		/// <para>The graph is listed in the Contents pane under Standalone Tables.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object OutGraph { get; set; }

		/// <summary>
		/// <para>Zones as rows in output table</para>
		/// <para>Specifies how the values from the input value raster will be represented in the output table.</para>
		/// <para>Unchecked—Zones will be represented as fields. This is the default.</para>
		/// <para>Checked—Zones will be represented as rows.</para>
		/// <para><see cref="ZonesAsRowsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ZonesAsRows { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ZonalHistogram SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , bool? qualifiedFieldNames = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , bool? transferDomains = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, transferDomains: transferDomains, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Zones as rows in output table</para>
		/// </summary>
		public enum ZonesAsRowsEnum 
		{
			/// <summary>
			/// <para>Unchecked—Zones will be represented as fields. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ZONES_AS_FIELDS")]
			ZONES_AS_FIELDS,

			/// <summary>
			/// <para>Checked—Zones will be represented as rows.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ZONES_AS_ROWS")]
			ZONES_AS_ROWS,

		}

#endregion
	}
}
