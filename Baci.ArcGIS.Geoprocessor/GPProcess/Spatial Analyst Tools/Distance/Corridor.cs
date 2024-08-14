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
	/// <para>Corridor</para>
	/// <para>Calculates the sum of accumulative costs for two input accumulative cost rasters.</para>
	/// </summary>
	public class Corridor : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDistanceRaster1">
		/// <para>Input cost distance raster 1</para>
		/// <para>The first input distance raster.</para>
		/// <para>It should be an accumulated cost distance output from a distance tool such as Cost Distance or Path Distance.</para>
		/// </param>
		/// <param name="InDistanceRaster2">
		/// <para>Input cost distance raster 2</para>
		/// <para>The second input distance raster.</para>
		/// <para>It should be an accumulated cost distance output from a distance tool such as Cost Distance or Path Distance.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output corridor raster.</para>
		/// <para>The output raster is of floating-point type.</para>
		/// </param>
		public Corridor(object InDistanceRaster1, object InDistanceRaster2, object OutRaster)
		{
			this.InDistanceRaster1 = InDistanceRaster1;
			this.InDistanceRaster2 = InDistanceRaster2;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Corridor</para>
		/// </summary>
		public override string DisplayName => "Corridor";

		/// <summary>
		/// <para>Tool Name : Corridor</para>
		/// </summary>
		public override string ToolName => "Corridor";

		/// <summary>
		/// <para>Tool Excute Name : sa.Corridor</para>
		/// </summary>
		public override string ExcuteName => "sa.Corridor";

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
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InDistanceRaster1, InDistanceRaster2, OutRaster };

		/// <summary>
		/// <para>Input cost distance raster 1</para>
		/// <para>The first input distance raster.</para>
		/// <para>It should be an accumulated cost distance output from a distance tool such as Cost Distance or Path Distance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InDistanceRaster1 { get; set; }

		/// <summary>
		/// <para>Input cost distance raster 2</para>
		/// <para>The second input distance raster.</para>
		/// <para>It should be an accumulated cost distance output from a distance tool such as Cost Distance or Path Distance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InDistanceRaster2 { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output corridor raster.</para>
		/// <para>The output raster is of floating-point type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Corridor SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
