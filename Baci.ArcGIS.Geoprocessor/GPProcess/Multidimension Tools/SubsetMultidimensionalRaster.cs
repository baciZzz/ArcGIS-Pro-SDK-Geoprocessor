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
	/// <para>Subset Multidimensional Raster</para>
	/// <para>子集多维栅格</para>
	/// <para>可沿定义的变量和维度对数据进行分割，从而创建多维栅格的子集。</para>
	/// </summary>
	public class SubsetMultidimensionalRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMultidimensionalRaster">
		/// <para>Input Multidimensional Raster</para>
		/// <para>输入多维栅格数据集。</para>
		/// <para>支持的输入包括 netCDF、GRIB、HDF 或 CRF 文件、多维镶嵌数据集或多维栅格图层。</para>
		/// </param>
		/// <param name="OutMultidimensionalRaster">
		/// <para>Output Multidimensional Raster</para>
		/// <para>输出多维栅格数据集。</para>
		/// </param>
		public SubsetMultidimensionalRaster(object InMultidimensionalRaster, object OutMultidimensionalRaster)
		{
			this.InMultidimensionalRaster = InMultidimensionalRaster;
			this.OutMultidimensionalRaster = OutMultidimensionalRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 子集多维栅格</para>
		/// </summary>
		public override string DisplayName() => "子集多维栅格";

		/// <summary>
		/// <para>Tool Name : SubsetMultidimensionalRaster</para>
		/// </summary>
		public override string ToolName() => "SubsetMultidimensionalRaster";

		/// <summary>
		/// <para>Tool Excute Name : md.SubsetMultidimensionalRaster</para>
		/// </summary>
		public override string ExcuteName() => "md.SubsetMultidimensionalRaster";

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
		public override object[] Parameters() => new object[] { InMultidimensionalRaster, OutMultidimensionalRaster, Variables!, DimensionDef!, DimensionRanges!, DimensionValues!, Dimension!, StartOfFirstIteration!, EndOfFirstIteration!, IterationStep!, IterationUnit! };

		/// <summary>
		/// <para>Input Multidimensional Raster</para>
		/// <para>输入多维栅格数据集。</para>
		/// <para>支持的输入包括 netCDF、GRIB、HDF 或 CRF 文件、多维镶嵌数据集或多维栅格图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Output Multidimensional Raster</para>
		/// <para>输出多维栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Variables</para>
		/// <para>将包含在输出多维栅格中的变量。如果未指定任何变量，则将使用所有变量。</para>
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
		/// <para>分割变量时使用的维度。当维度定义参数设置为按迭代时，此参数为必需项。</para>
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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SubsetMultidimensionalRaster SetEnviroment(object? cellSize = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
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

#endregion
	}
}
