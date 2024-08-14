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
	/// <para>Focal Flow</para>
	/// <para>Determines the flow of the values in the input raster within each cell's immediate neighborhood.</para>
	/// </summary>
	public class FocalFlow : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurfaceRaster">
		/// <para>Input surface raster</para>
		/// <para>The input surface raster for which to calculate the focal flow.</para>
		/// <para>The eight immediate neighbors of each cell are evaluated to determine the flow.</para>
		/// <para>The input raster can be integer or floating point.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output focal flow raster.</para>
		/// <para>The output raster is always of integer type.</para>
		/// </param>
		public FocalFlow(object InSurfaceRaster, object OutRaster)
		{
			this.InSurfaceRaster = InSurfaceRaster;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Focal Flow</para>
		/// </summary>
		public override string DisplayName => "Focal Flow";

		/// <summary>
		/// <para>Tool Name : FocalFlow</para>
		/// </summary>
		public override string ToolName => "FocalFlow";

		/// <summary>
		/// <para>Tool Excute Name : sa.FocalFlow</para>
		/// </summary>
		public override string ExcuteName => "sa.FocalFlow";

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
		public override object[] Parameters => new object[] { InSurfaceRaster, OutRaster, ThresholdValue! };

		/// <summary>
		/// <para>Input surface raster</para>
		/// <para>The input surface raster for which to calculate the focal flow.</para>
		/// <para>The eight immediate neighbors of each cell are evaluated to determine the flow.</para>
		/// <para>The input raster can be integer or floating point.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAGeoData()]
		[GPSAGeoDataDomain()]
		public object InSurfaceRaster { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output focal flow raster.</para>
		/// <para>The output raster is always of integer type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Threshold value</para>
		/// <para>Defines a value that constitutes the threshold, which must be equaled or exceeded before flow can occur.</para>
		/// <para>The threshold value can be either an integer or floating-point value.</para>
		/// <para>If the difference between the value at a neighboring cell location and the value of the processing cell is less than or equal to the threshold value, the output will be 0 (or no flow).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? ThresholdValue { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FocalFlow SetEnviroment(int? autoCommit = null , object? cellSize = null , object? cellSizeProjectionMethod = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
