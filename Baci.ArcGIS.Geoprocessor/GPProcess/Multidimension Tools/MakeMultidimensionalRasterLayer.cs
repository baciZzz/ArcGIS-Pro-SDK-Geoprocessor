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
	/// <para>Make Multidimensional Raster Layer</para>
	/// <para>创建多维栅格图层</para>
	/// <para>用于沿定义的变量和维度对数据进行分割，从而根据多维栅格数据集或多维栅格图层创建栅格图层。</para>
	/// </summary>
	public class MakeMultidimensionalRasterLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMultidimensionalRaster">
		/// <para>Input Multidimensional Raster</para>
		/// <para>输入多维栅格数据集。</para>
		/// <para>支持的输入包括 netCDF、GRIB、HDF、CRF 或 Zarr 文件、多维镶嵌数据集、多维影像服务、OPeNDAP URL 或多维栅格图层。Zarr 文件必须具有扩展名 .zarr 和文件夹中的 .zgroup 文件。</para>
		/// </param>
		/// <param name="OutMultidimensionalRasterLayer">
		/// <para>Output Multidimensional Raster Layer</para>
		/// <para>输出多维栅格图层。</para>
		/// </param>
		public MakeMultidimensionalRasterLayer(object InMultidimensionalRaster, object OutMultidimensionalRasterLayer)
		{
			this.InMultidimensionalRaster = InMultidimensionalRaster;
			this.OutMultidimensionalRasterLayer = OutMultidimensionalRasterLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建多维栅格图层</para>
		/// </summary>
		public override string DisplayName() => "创建多维栅格图层";

		/// <summary>
		/// <para>Tool Name : MakeMultidimensionalRasterLayer</para>
		/// </summary>
		public override string ToolName() => "MakeMultidimensionalRasterLayer";

		/// <summary>
		/// <para>Tool Excute Name : md.MakeMultidimensionalRasterLayer</para>
		/// </summary>
		public override string ExcuteName() => "md.MakeMultidimensionalRasterLayer";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMultidimensionalRaster, OutMultidimensionalRasterLayer, Variables!, DimensionDef!, DimensionRanges!, DimensionValues!, Dimension!, StartOfFirstIteration!, EndOfFirstIteration!, IterationStep!, IterationUnit!, Template!, Dimensionless!, SpatialReference! };

		/// <summary>
		/// <para>Input Multidimensional Raster</para>
		/// <para>输入多维栅格数据集。</para>
		/// <para>支持的输入包括 netCDF、GRIB、HDF、CRF 或 Zarr 文件、多维镶嵌数据集、多维影像服务、OPeNDAP URL 或多维栅格图层。Zarr 文件必须具有扩展名 .zarr 和文件夹中的 .zgroup 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Output Multidimensional Raster Layer</para>
		/// <para>输出多维栅格图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object OutMultidimensionalRasterLayer { get; set; }

		/// <summary>
		/// <para>Variables</para>
		/// <para>将包含在输出多维栅格图层中的变量。 如果未指定任何变量，则将使用第一个变量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Variables { get; set; }

		/// <summary>
		/// <para>Dimension Definition</para>
		/// <para>指定将用于分割维度的方法。</para>
		/// <para>全部—将使用每个维度的完整范围。 这是默认设置。</para>
		/// <para>按范围—将使用范围或范围列表对维度进行分割。</para>
		/// <para>按迭代—将以指定的间隔大小对维度进行分割。</para>
		/// <para>按值—将使用一系列维度值对维度进行分割。</para>
		/// <para><see cref="DimensionDefEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DimensionDef { get; set; } = "ALL";

		/// <summary>
		/// <para>Range</para>
		/// <para>指定维度的范围或范围列表。</para>
		/// <para>系统将根据维度名称以及范围的最小值和最大值对数据进行分割。 当维度定义参数设置为按范围时，此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? DimensionRanges { get; set; }

		/// <summary>
		/// <para>Values</para>
		/// <para>指定维度的值列表。 当维度定义参数设置为按值时，此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? DimensionValues { get; set; }

		/// <summary>
		/// <para>Dimension</para>
		/// <para>分割变量时使用的维度。 当维度定义参数设置为按迭代时，此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Dimension { get; set; }

		/// <summary>
		/// <para>Start of first iteration</para>
		/// <para>第一个间隔的开始。 该间隔将用于遍历数据集。 当维度定义参数设置为按迭代时，此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? StartOfFirstIteration { get; set; }

		/// <summary>
		/// <para>End of first iteration</para>
		/// <para>第一个间隔的结束。 该间隔将用于遍历数据集。 当维度定义参数设置为按迭代时，此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? EndOfFirstIteration { get; set; }

		/// <summary>
		/// <para>Step</para>
		/// <para>分割数据时使用的频率。 当维度定义参数设置为按迭代时，此参数为必需项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? IterationStep { get; set; }

		/// <summary>
		/// <para>Unit</para>
		/// <para>指定将使用的迭代单位。 当维度定义参数设置为按迭代且维度参数设置为 StdTime 时，此参数为必需项。</para>
		/// <para><see cref="IterationUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? IterationUnit { get; set; }

		/// <summary>
		/// <para>Extent</para>
		/// <para>图层的范围（边界框）。 为图层选择合适的范围选项。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>当前显示范围 - 该范围与数据框或可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object? Template { get; set; }

		/// <summary>
		/// <para>Dimensionless</para>
		/// <para>指定图层是否具有维度值。 仅当选择单个剖切片来创建图层时，此参数才处于活动状态。</para>
		/// <para>选中 - 图层没有维度值。</para>
		/// <para>未选中 - 图层具有维度值。 这是默认设置。</para>
		/// <para><see cref="DimensionlessEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Dimensionless { get; set; } = "false";

		/// <summary>
		/// <para>Spatial Reference</para>
		/// <para>输出多维栅格图层参数值的坐标系。 此参数仅在输入多维栅格参数值为 Zarr 格式时适用。 如果数据中缺少空间参考，则可以使用此参数定义空间参考。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		[Category("Interpolate irregular data")]
		public object? SpatialReference { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeMultidimensionalRasterLayer SetEnviroment(object? cellSize = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Dimension Definition</para>
		/// </summary>
		public enum DimensionDefEnum 
		{
			/// <summary>
			/// <para>全部—将使用每个维度的完整范围。 这是默认设置。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("全部")]
			All,

			/// <summary>
			/// <para>按值—将使用一系列维度值对维度进行分割。</para>
			/// </summary>
			[GPValue("BY_VALUE")]
			[Description("按值")]
			By_Values,

			/// <summary>
			/// <para>按范围—将使用范围或范围列表对维度进行分割。</para>
			/// </summary>
			[GPValue("BY_RANGES")]
			[Description("按范围")]
			By_Ranges,

			/// <summary>
			/// <para>按迭代—将以指定的间隔大小对维度进行分割。</para>
			/// </summary>
			[GPValue("BY_ITERATION")]
			[Description("按迭代")]
			By_Iteration,

		}

		/// <summary>
		/// <para>Unit</para>
		/// </summary>
		public enum IterationUnitEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("HOURS")]
			[Description("小时")]
			Hours,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("DAYS")]
			[Description("天")]
			Days,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("WEEKS")]
			[Description("周")]
			Weeks,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("MONTHS")]
			[Description("月")]
			Months,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("YEARS")]
			[Description("年")]
			Years,

		}

		/// <summary>
		/// <para>Dimensionless</para>
		/// </summary>
		public enum DimensionlessEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("NO_DIMENSIONS")]
			NO_DIMENSIONS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DIMENSIONS")]
			DIMENSIONS,

		}

#endregion
	}
}
