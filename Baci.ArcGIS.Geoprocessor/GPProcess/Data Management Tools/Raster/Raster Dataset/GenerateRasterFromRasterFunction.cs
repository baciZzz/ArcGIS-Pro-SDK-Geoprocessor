using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Generate Raster From Raster Function</para>
	/// <para>使用栅格函数生成栅格</para>
	/// <para>从输入栅格函数或函数链生成栅格数据集。</para>
	/// </summary>
	public class GenerateRasterFromRasterFunction : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="RasterFunction">
		/// <para>Input Raster Function</para>
		/// <para>栅格函数名称、栅格函数 JSON 对象或函数链（以 .rft.xml 格式）。</para>
		/// </param>
		/// <param name="OutRasterDataset">
		/// <para>Output Raster Dataset</para>
		/// <para>输出栅格数据集。</para>
		/// </param>
		public GenerateRasterFromRasterFunction(object RasterFunction, object OutRasterDataset)
		{
			this.RasterFunction = RasterFunction;
			this.OutRasterDataset = OutRasterDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 使用栅格函数生成栅格</para>
		/// </summary>
		public override string DisplayName() => "使用栅格函数生成栅格";

		/// <summary>
		/// <para>Tool Name : GenerateRasterFromRasterFunction</para>
		/// </summary>
		public override string ToolName() => "GenerateRasterFromRasterFunction";

		/// <summary>
		/// <para>Tool Excute Name : management.GenerateRasterFromRasterFunction</para>
		/// </summary>
		public override string ExcuteName() => "management.GenerateRasterFromRasterFunction";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellAlignment", "cellSize", "compression", "extent", "geographicTransformations", "gpuID", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "processorType", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { RasterFunction, OutRasterDataset, RasterFunctionArguments!, RasterProperties!, Format!, ProcessAsMultidimensional! };

		/// <summary>
		/// <para>Input Raster Function</para>
		/// <para>栅格函数名称、栅格函数 JSON 对象或函数链（以 .rft.xml 格式）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object RasterFunction { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>输出栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRasterDataset { get; set; }

		/// <summary>
		/// <para>Raster Function Arguments</para>
		/// <para>参数与函数链相关联。例如，如果函数链应用山体阴影栅格函数，则设置数据源、方位角和高度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? RasterFunctionArguments { get; set; }

		/// <summary>
		/// <para>Raster Properties</para>
		/// <para>输出栅格数据集关键属性（如传感器或波长）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? RasterProperties { get; set; }

		/// <summary>
		/// <para>Format</para>
		/// <para>输出栅格格式。</para>
		/// <para>默认格式将派生自在输出栅格数据集中指定的文件扩展名。</para>
		/// <para>TIFF—栅格数据集的标记图像文件格式</para>
		/// <para>Cloud Optimized GeoTIFF—Cloud Optimized GeoTIFF 格式。</para>
		/// <para>ERDAS IMAGINE 文件—ERDAS IMAGINE 栅格数据格式</para>
		/// <para>Esri Grid—Esri 格网栅格数据集格式</para>
		/// <para>CRF—云栅格格式</para>
		/// <para>MRF—元栅格格式</para>
		/// <para><see cref="FormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Format { get; set; }

		/// <summary>
		/// <para>Process as Multidimensional</para>
		/// <para>指定是否将输入镶嵌数据集作为多维栅格数据集进行处理。</para>
		/// <para>未选中 - 输入不会作为多维栅格数据集进行处理。 如果输入是多维的，则仅处理当前显示的切片。 这是默认设置。</para>
		/// <para>选中 - 输入将作为多维栅格数据集进行处理，并对所有剖切片进行处理以生成新的多维栅格数据集。 将格式参数设置为云栅格格式以使用此选项。</para>
		/// <para><see cref="ProcessAsMultidimensionalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ProcessAsMultidimensional { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateRasterFromRasterFunction SetEnviroment(object? cellAlignment = null, object? cellSize = null, object? compression = null, object? extent = null, object? geographicTransformations = null, object? nodata = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? processorType = null, object? pyramid = null, object? rasterStatistics = null, object? resamplingMethod = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(cellAlignment: cellAlignment, cellSize: cellSize, compression: compression, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, processorType: processorType, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Format</para>
		/// </summary>
		public enum FormatEnum 
		{
			/// <summary>
			/// <para>TIFF—栅格数据集的标记图像文件格式</para>
			/// </summary>
			[GPValue("TIFF")]
			[Description("TIFF")]
			TIFF,

			/// <summary>
			/// <para>Cloud Optimized GeoTIFF—Cloud Optimized GeoTIFF 格式。</para>
			/// </summary>
			[GPValue("COG")]
			[Description("Cloud Optimized GeoTIFF")]
			Cloud_Optimized_GeoTIFF,

			/// <summary>
			/// <para>ERDAS IMAGINE 文件—ERDAS IMAGINE 栅格数据格式</para>
			/// </summary>
			[GPValue("IMAGINE Image")]
			[Description("ERDAS IMAGINE 文件")]
			ERDAS_IMAGINE_file,

			/// <summary>
			/// <para>Esri Grid—Esri 格网栅格数据集格式</para>
			/// </summary>
			[GPValue("GRID")]
			[Description("Esri Grid")]
			Esri_Grid,

			/// <summary>
			/// <para>CRF—云栅格格式</para>
			/// </summary>
			[GPValue("CRF")]
			[Description("CRF")]
			CRF,

			/// <summary>
			/// <para>MRF—元栅格格式</para>
			/// </summary>
			[GPValue("MRF")]
			[Description("MRF")]
			MRF,

		}

		/// <summary>
		/// <para>Process as Multidimensional</para>
		/// </summary>
		public enum ProcessAsMultidimensionalEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ALL_SLICES")]
			ALL_SLICES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("CURRENT_SLICE")]
			CURRENT_SLICE,

		}

#endregion
	}
}
