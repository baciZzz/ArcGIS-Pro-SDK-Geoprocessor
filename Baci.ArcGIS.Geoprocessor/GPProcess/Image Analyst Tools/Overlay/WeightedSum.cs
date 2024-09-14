using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ImageAnalystTools
{
	/// <summary>
	/// <para>Weighted Sum</para>
	/// <para>Weighted Sum</para>
	/// <para>Overlays several rasters, multiplying each by their given weight and summing them together.</para>
	/// </summary>
	public class WeightedSum : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasters">
		/// <para>Input rasters</para>
		/// <para>The weighted sum table allows you to apply different weights to individual input rasters before they are summed together.</para>
		/// <para>Raster—The raster being weighted.</para>
		/// <para>Field—The field of the raster to use for weighting.</para>
		/// <para>Weight—The weight value by which to multiply the raster. It can be any positive or negative decimal value.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output weighted raster.</para>
		/// <para>It will be of floating-point type.</para>
		/// </param>
		public WeightedSum(object InRasters, object OutRaster)
		{
			this.InRasters = InRasters;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Weighted Sum</para>
		/// </summary>
		public override string DisplayName() => "Weighted Sum";

		/// <summary>
		/// <para>Tool Name : WeightedSum</para>
		/// </summary>
		public override string ToolName() => "WeightedSum";

		/// <summary>
		/// <para>Tool Excute Name : ia.WeightedSum</para>
		/// </summary>
		public override string ExcuteName() => "ia.WeightedSum";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise() => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "configKeyword", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRasters, OutRaster };

		/// <summary>
		/// <para>Input rasters</para>
		/// <para>The weighted sum table allows you to apply different weights to individual input rasters before they are summed together.</para>
		/// <para>Raster—The raster being weighted.</para>
		/// <para>Field—The field of the raster to use for weighting.</para>
		/// <para>Weight—The weight value by which to multiply the raster. It can be any positive or negative decimal value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPSAWeightedSum()]
		[GPCompositeDomain()]
		public object InRasters { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output weighted raster.</para>
		/// <para>It will be of floating-point type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public WeightedSum SetEnviroment(int? autoCommit = null, object? cellSize = null, object? cellSizeProjectionMethod = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, cellSizeProjectionMethod: cellSizeProjectionMethod, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

	}
}
