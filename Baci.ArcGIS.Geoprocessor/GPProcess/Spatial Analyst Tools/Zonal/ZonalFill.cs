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
	/// <para>Zonal Fill</para>
	/// <para>Fills zones using the minimum cell value from a weight raster along the zone boundary.</para>
	/// </summary>
	public class ZonalFill : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InZoneRaster">
		/// <para>Input zone raster</para>
		/// <para>The input raster that defines the zones to be filled.</para>
		/// </param>
		/// <param name="InWeightRaster">
		/// <para>Input weight raster</para>
		/// <para>Weight, or value, to be assigned to each zone.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster for which the zones have been filled.</para>
		/// </param>
		public ZonalFill(object InZoneRaster, object InWeightRaster, object OutRaster)
		{
			this.InZoneRaster = InZoneRaster;
			this.InWeightRaster = InWeightRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Zonal Fill</para>
		/// </summary>
		public override string DisplayName => "Zonal Fill";

		/// <summary>
		/// <para>Tool Name : ZonalFill</para>
		/// </summary>
		public override string ToolName => "ZonalFill";

		/// <summary>
		/// <para>Tool Excute Name : sa.ZonalFill</para>
		/// </summary>
		public override string ExcuteName => "sa.ZonalFill";

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
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InZoneRaster, InWeightRaster, OutRaster };

		/// <summary>
		/// <para>Input zone raster</para>
		/// <para>The input raster that defines the zones to be filled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InZoneRaster { get; set; }

		/// <summary>
		/// <para>Input weight raster</para>
		/// <para>Weight, or value, to be assigned to each zone.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InWeightRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster for which the zones have been filled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ZonalFill SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
