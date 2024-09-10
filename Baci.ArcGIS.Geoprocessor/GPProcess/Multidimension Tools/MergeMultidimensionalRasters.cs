using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.MultidimensionTools
{
	/// <summary>
	/// <para>Merge Multidimensional Rasters</para>
	/// <para>Combines multiple multidimensional raster datasets spatially, or across variables and dimensions.</para>
	/// </summary>
	public class MergeMultidimensionalRasters : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMultidimensionalRasters">
		/// <para>Input Multidimensional Rasters</para>
		/// <para>The input multidimensional rasters to be combined.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster</para>
		/// <para>The merged multidimensional raster dataset in Cloud Raster Format (a .crf file).</para>
		/// </param>
		public MergeMultidimensionalRasters(object InMultidimensionalRasters, object OutRaster)
		{
			this.InMultidimensionalRasters = InMultidimensionalRasters;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Merge Multidimensional Rasters</para>
		/// </summary>
		public override string DisplayName() => "Merge Multidimensional Rasters";

		/// <summary>
		/// <para>Tool Name : MergeMultidimensionalRasters</para>
		/// </summary>
		public override string ToolName() => "MergeMultidimensionalRasters";

		/// <summary>
		/// <para>Tool Excute Name : md.MergeMultidimensionalRasters</para>
		/// </summary>
		public override string ExcuteName() => "md.MergeMultidimensionalRasters";

		/// <summary>
		/// <para>Toolbox Display Name : Multidimension Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Multidimension Tools";

		/// <summary>
		/// <para>Toolbox Alise : md</para>
		/// </summary>
		public override string ToolboxAlise() => "md";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMultidimensionalRasters, OutRaster, ResolveOverlapMethod };

		/// <summary>
		/// <para>Input Multidimensional Rasters</para>
		/// <para>The input multidimensional rasters to be combined.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCompositeDomain()]
		public object InMultidimensionalRasters { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>The merged multidimensional raster dataset in Cloud Raster Format (a .crf file).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Resolve Overlap Method</para>
		/// <para>Specifies the method to use to resolve overlapping pixels in the combined datasets.</para>
		/// <para>First—The pixel value in the overlapping areas will be the value from the first raster in the list of input rasters. This is the default.</para>
		/// <para>Last—The pixel value in the overlapping areas will be the value from the last raster in the list of input rasters.</para>
		/// <para>Minimum—The pixel value in the overlapping areas will be the minimum value of the overlapping pixels.</para>
		/// <para>Maximum—The pixel value in the overlapping areas will be the maximum value of the overlapping pixels.</para>
		/// <para>Mean—The pixel value in the overlapping areas will be the average of the overlapping pixels.</para>
		/// <para>Sum—The pixel value in the overlapping areas will be the total sum of the overlapping pixels.</para>
		/// <para><see cref="ResolveOverlapMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ResolveOverlapMethod { get; set; } = "FIRST";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MergeMultidimensionalRasters SetEnviroment(object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object nodata = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object pyramid = null , object rasterStatistics = null , object resamplingMethod = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
		{
			base.SetEnv(cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Resolve Overlap Method</para>
		/// </summary>
		public enum ResolveOverlapMethodEnum 
		{
			/// <summary>
			/// <para>First—The pixel value in the overlapping areas will be the value from the first raster in the list of input rasters. This is the default.</para>
			/// </summary>
			[GPValue("FIRST")]
			[Description("First")]
			First,

			/// <summary>
			/// <para>Last—The pixel value in the overlapping areas will be the value from the last raster in the list of input rasters.</para>
			/// </summary>
			[GPValue("LAST")]
			[Description("Last")]
			Last,

			/// <summary>
			/// <para>Minimum—The pixel value in the overlapping areas will be the minimum value of the overlapping pixels.</para>
			/// </summary>
			[GPValue("MIN")]
			[Description("Minimum")]
			Minimum,

			/// <summary>
			/// <para>Maximum—The pixel value in the overlapping areas will be the maximum value of the overlapping pixels.</para>
			/// </summary>
			[GPValue("MAX")]
			[Description("Maximum")]
			Maximum,

			/// <summary>
			/// <para>Mean—The pixel value in the overlapping areas will be the average of the overlapping pixels.</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("Mean")]
			Mean,

			/// <summary>
			/// <para>Sum—The pixel value in the overlapping areas will be the total sum of the overlapping pixels.</para>
			/// </summary>
			[GPValue("SUM")]
			[Description("Sum")]
			Sum,

		}

#endregion
	}
}
