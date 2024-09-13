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
	/// <para>合并多维栅格</para>
	/// <para>在空间上、跨变量或跨维度合并多个多维栅格数据集。</para>
	/// </summary>
	public class MergeMultidimensionalRasters : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMultidimensionalRasters">
		/// <para>Input Multidimensional Rasters</para>
		/// <para>要合并的输入多维栅格。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster</para>
		/// <para>采用云栅格格式（.crf 文件）或 NetCDF 格式（.nc 文件）的合并多维栅格数据集。</para>
		/// </param>
		public MergeMultidimensionalRasters(object InMultidimensionalRasters, object OutRaster)
		{
			this.InMultidimensionalRasters = InMultidimensionalRasters;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 合并多维栅格</para>
		/// </summary>
		public override string DisplayName() => "合并多维栅格";

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
		public override object[] Parameters() => new object[] { InMultidimensionalRasters, OutRaster, ResolveOverlapMethod! };

		/// <summary>
		/// <para>Input Multidimensional Rasters</para>
		/// <para>要合并的输入多维栅格。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCompositeDomain()]
		public object InMultidimensionalRasters { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>采用云栅格格式（.crf 文件）或 NetCDF 格式（.nc 文件）的合并多维栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Resolve Overlap Method</para>
		/// <para>指定将用于处理所合并数据集中重叠像素的方法。</para>
		/// <para>第一个—重叠区域内的像素值将为来自输入栅格列表中第一个栅格的值。 这是默认设置。</para>
		/// <para>最后一个—重叠区域内的像素值将为来自输入栅格列表中最后一个栅格的值。</para>
		/// <para>最小值—重叠区域内的像素值将为重叠像素的最小值。</para>
		/// <para>最大值—重叠区域内的像素值将为重叠像素的最大值。</para>
		/// <para>平均值—重叠区域内的像素值将为重叠像素的平均值。</para>
		/// <para>总和—重叠区域内的像素值将为重叠像素的总和。</para>
		/// <para><see cref="ResolveOverlapMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ResolveOverlapMethod { get; set; } = "FIRST";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MergeMultidimensionalRasters SetEnviroment(object? cellSize = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
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
			/// <para>第一个—重叠区域内的像素值将为来自输入栅格列表中第一个栅格的值。 这是默认设置。</para>
			/// </summary>
			[GPValue("FIRST")]
			[Description("第一个")]
			First,

			/// <summary>
			/// <para>最后一个—重叠区域内的像素值将为来自输入栅格列表中最后一个栅格的值。</para>
			/// </summary>
			[GPValue("LAST")]
			[Description("最后一个")]
			Last,

			/// <summary>
			/// <para>最小值—重叠区域内的像素值将为重叠像素的最小值。</para>
			/// </summary>
			[GPValue("MIN")]
			[Description("最小值")]
			Minimum,

			/// <summary>
			/// <para>最大值—重叠区域内的像素值将为重叠像素的最大值。</para>
			/// </summary>
			[GPValue("MAX")]
			[Description("最大值")]
			Maximum,

			/// <summary>
			/// <para>平均值—重叠区域内的像素值将为重叠像素的平均值。</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("平均值")]
			Mean,

			/// <summary>
			/// <para>总和—重叠区域内的像素值将为重叠像素的总和。</para>
			/// </summary>
			[GPValue("SUM")]
			[Description("总和")]
			Sum,

		}

#endregion
	}
}
