using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools
{
	/// <summary>
	/// <para>Diffusion Interpolation With Barriers</para>
	/// <para>Interpolates a surface using a kernel that is based upon the heat equation and allows one to use raster and feature  barriers to redefine distances between input points.</para>
	/// </summary>
	public class DiffusionInterpolationWithBarriers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input features</para>
		/// <para>The input point features containing the z-values to be interpolated.</para>
		/// </param>
		/// <param name="ZField">
		/// <para>Z value field</para>
		/// <para>Field that holds a height or magnitude value for each point. This can be a numeric field or the Shape field if the input features contain z-values or m-values.</para>
		/// </param>
		public DiffusionInterpolationWithBarriers(object InFeatures, object ZField)
		{
			this.InFeatures = InFeatures;
			this.ZField = ZField;
		}

		/// <summary>
		/// <para>Tool Display Name : Diffusion Interpolation With Barriers</para>
		/// </summary>
		public override string DisplayName => "Diffusion Interpolation With Barriers";

		/// <summary>
		/// <para>Tool Name : DiffusionInterpolationWithBarriers</para>
		/// </summary>
		public override string ToolName => "DiffusionInterpolationWithBarriers";

		/// <summary>
		/// <para>Tool Excute Name : ga.DiffusionInterpolationWithBarriers</para>
		/// </summary>
		public override string ExcuteName => "ga.DiffusionInterpolationWithBarriers";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "cellSize", "coincidentPoints", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, ZField, OutGaLayer, OutRaster, CellSize, InBarrierFeatures, Bandwidth, NumberIterations, WeightField, InAdditiveBarrierRaster, InCumulativeBarrierRaster, InFlowBarrierRaster };

		/// <summary>
		/// <para>Input features</para>
		/// <para>The input point features containing the z-values to be interpolated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Z value field</para>
		/// <para>Field that holds a height or magnitude value for each point. This can be a numeric field or the Shape field if the input features contain z-values or m-values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		public object ZField { get; set; }

		/// <summary>
		/// <para>Output geostatistical layer</para>
		/// <para>The geostatistical layer produced. This layer is required output only if no output raster is requested.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPGALayer()]
		public object OutGaLayer { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster. This raster is required output only if no output geostatistical layer is requested.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>The cell size at which the output raster will be created.</para>
		/// <para>This value can be explicitly set in the Environments by the Cell Size parameter.</para>
		/// <para>If not set, it is the shorter of the width or the height of the extent of the input point features, in the input spatial reference, divided by 250.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain()]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Input absolute barrier features</para>
		/// <para>Absolute barrier features using non-Euclidean distances rather than line-of-sight distances.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InBarrierFeatures { get; set; }

		/// <summary>
		/// <para>Bandwidth</para>
		/// <para>Used to specify the maximum distance at which data points are used for prediction. With increasing bandwidth, prediction bias increases and prediction variance decreases.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain()]
		public object Bandwidth { get; set; }

		/// <summary>
		/// <para>Number of iterations</para>
		/// <para>The iteration count controls the accuracy of the numerical solution because the model solves the diffusion equation numerically. The larger this number, the more accurate the predictions, yet the longer the processing time. The more complex the barrier's geometry and the larger the bandwidth, the more iterations are required for accurate predictions.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain()]
		public object NumberIterations { get; set; } = "100";

		/// <summary>
		/// <para>Weight field</para>
		/// <para>Used to emphasize an observation. The larger the weight, the more impact it has on the prediction. For coincident observations, assign the largest weight to the most reliable measurement.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object WeightField { get; set; }

		/// <summary>
		/// <para>Input additive barrier raster</para>
		/// <para>The travel distance from one raster cell to the next based on this formula:</para>
		/// <para>(average cost value in the neighboring cells) x (distance between cell centers)</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRasterLayer()]
		[Category("Additional raster barriers")]
		public object InAdditiveBarrierRaster { get; set; }

		/// <summary>
		/// <para>Input cumulative barrier raster</para>
		/// <para>The travel distance from one raster cell to the next based on this formula:</para>
		/// <para>(difference between cost values in the neighboring cells) + (distance between cell centers)</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRasterLayer()]
		[Category("Additional raster barriers")]
		public object InCumulativeBarrierRaster { get; set; }

		/// <summary>
		/// <para>Input flow barrier raster</para>
		/// <para>A flow barrier is used when interpolating data with preferential direction of data variation, based on this formula:</para>
		/// <para>Indicator (cost values in theneighboring cell &gt; cost values in theneighboring cell) * (cost values in theneighboring cell - cost values in theneighboring cell) + (distance between cell centers),<italics>to</italics><italics>from</italics><italics>to</italics><italics>from</italics></para>
		/// <para>where indicator(true) = 1 and indicator(false) = 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRasterLayer()]
		[Category("Additional raster barriers")]
		public object InFlowBarrierRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DiffusionInterpolationWithBarriers SetEnviroment(object cellSize = null , object coincidentPoints = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object snapRaster = null , object workspace = null )
		{
			base.SetEnv(cellSize: cellSize, coincidentPoints: coincidentPoints, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

	}
}
