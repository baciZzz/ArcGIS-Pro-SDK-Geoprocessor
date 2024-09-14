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
	/// <para>GA Layer 3D To Multidimensional Raster</para>
	/// <para>3D GA 图层转多维栅格</para>
	/// <para>将使用 3D 经验贝叶斯克里金工具创建的 3D 地统计图层导出为多维云栅格格式（*.crf 文件）栅格数据集。 Image Analyst 工具箱“多维分析”工具集中的工具旨在直接使用多维栅格，并且可以识别数据的 3D 特性。</para>
	/// </summary>
	public class GALayer3DToMultidimensionalRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="In3DGeostatLayer">
		/// <para>Input 3D geostatistical layer</para>
		/// <para>该 3D 地统计图层用于表示要导出到多元栅格数据集的模型。</para>
		/// </param>
		/// <param name="OutMultidimensionalRaster">
		/// <para>Output multidimensional raster dataset</para>
		/// <para>该输出栅格数据集中包含导出地统计模型的结果。 必须将该输出另存为云栅格格式文件 (*.crf)。</para>
		/// </param>
		public GALayer3DToMultidimensionalRaster(object In3DGeostatLayer, object OutMultidimensionalRaster)
		{
			this.In3DGeostatLayer = In3DGeostatLayer;
			this.OutMultidimensionalRaster = OutMultidimensionalRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : 3D GA 图层转多维栅格</para>
		/// </summary>
		public override string DisplayName() => "3D GA 图层转多维栅格";

		/// <summary>
		/// <para>Tool Name : GALayer3DToMultidimensionalRaster</para>
		/// </summary>
		public override string ToolName() => "GALayer3DToMultidimensionalRaster";

		/// <summary>
		/// <para>Tool Excute Name : ga.GALayer3DToMultidimensionalRaster</para>
		/// </summary>
		public override string ExcuteName() => "ga.GALayer3DToMultidimensionalRaster";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise() => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { In3DGeostatLayer, OutMultidimensionalRaster, CellSize!, ExplicitOnly!, MinElev!, MaxElev!, ElevInterval!, ElevValues!, ElevUnits!, OutputType!, QuantileProbabilityValue!, AdditionalOutputs!, BuildTranspose! };

		/// <summary>
		/// <para>Input 3D geostatistical layer</para>
		/// <para>该 3D 地统计图层用于表示要导出到多元栅格数据集的模型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGALayer()]
		public object In3DGeostatLayer { get; set; }

		/// <summary>
		/// <para>Output multidimensional raster dataset</para>
		/// <para>该输出栅格数据集中包含导出地统计模型的结果。 必须将该输出另存为云栅格格式文件 (*.crf)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Cell size</para>
		/// <para>输出多维栅格的像元大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Enter explicit elevation values</para>
		/// <para>用于指定是将高程作为显式列表提供还是使用迭代器进行提供。 每个高程都将由输出多维栅格中的一个维度表示。</para>
		/// <para>选中 - 高程值将作为列表提供。</para>
		/// <para>未选中 - 将使用迭代器提供高程值。 这是默认设置。</para>
		/// <para><see cref="ExplicitOnlyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ExplicitOnly { get; set; } = "false";

		/// <summary>
		/// <para>Minimum elevation</para>
		/// <para>将用于开始迭代的最小高程。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = -1.7976931348623157e+308, Max = 1.7976931348623157e+308)]
		public object? MinElev { get; set; }

		/// <summary>
		/// <para>Maximum elevation</para>
		/// <para>将用于停止迭代的最大高程。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = -1.7976931348623157e+308, Max = 1.7976931348623157e+308)]
		public object? MaxElev { get; set; }

		/// <summary>
		/// <para>Elevation interval</para>
		/// <para>高程将随着每次迭代而增加的增量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? ElevInterval { get; set; }

		/// <summary>
		/// <para>Elevation values</para>
		/// <para>要导出的高程值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? ElevValues { get; set; }

		/// <summary>
		/// <para>Elevation units</para>
		/// <para>指定高程值的测量单位。</para>
		/// <para>美国测量英寸—高程以美制英寸为单位。</para>
		/// <para>美国测量英尺—高程以美制英尺为单位。</para>
		/// <para>美国测量码—高程以美制码为单位。</para>
		/// <para>美国测量英里—高程以美制英里为单位。</para>
		/// <para>美国测量海里—高程以美制海里为单位。</para>
		/// <para>毫米—高程以毫米为单位。</para>
		/// <para>厘米—高程以厘米为单位。</para>
		/// <para>分米—高程以分米为单位。</para>
		/// <para>米—高程以米为单位。</para>
		/// <para>千米—高程以千米为单位。</para>
		/// <para>国际英寸—高程以国际英寸为单位。</para>
		/// <para>国际英尺—高程以国际英尺为单位。</para>
		/// <para>国际码—高程以国际码为单位。</para>
		/// <para>法定英里—高程以法定英里为单位。</para>
		/// <para>国际海里—高程以国际海里为单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ElevUnits { get; set; } = "METER";

		/// <summary>
		/// <para>Output type</para>
		/// <para>用于指定输出多维栅格的主要输出类型。 附加输出类型参数可用于指定输出多维栅格中的其他变量。</para>
		/// <para>有关详细信息，请参阅插值模型可以生成何种类型的输出表面？</para>
		/// <para>预测—预测值的多维栅格。 这是默认设置。</para>
		/// <para>预测标准误差—预测标准误差的多维栅格。</para>
		/// <para>概率—用于预测超出阈值的概率的多维栅格。</para>
		/// <para>分位数—用于预测预测值分位数的多维栅格。</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Parameters")]
		public object? OutputType { get; set; } = "PREDICTION";

		/// <summary>
		/// <para>Quantile or probability threshold value</para>
		/// <para>如果输出类型设置为分位数，则使用此参数输入请求的分位数。 如果输出类型设置为概率，则使用此参数输入请求的阈值，然后即可计算超出此阈值的概率。 从一个值中减去该值即可得出未超出阈值的概率。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = -1.7976931348623157e+308, Max = 1.7976931348623157e+308)]
		[Category("Output Parameters")]
		public object? QuantileProbabilityValue { get; set; }

		/// <summary>
		/// <para>Additional output types</para>
		/// <para>指定每个附加输出类型的输出类型及分位数或概率值。 如果提供了多个输出类型，则输出栅格将是一个每种输出类型的变量都不同的多元栅格数据集。</para>
		/// <para>有关详细信息，请参阅插值模型可以生成何种类型的输出表面？</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Output Parameters")]
		public object? AdditionalOutputs { get; set; }

		/// <summary>
		/// <para>Build multidimensional transpose</para>
		/// <para>指定是否将在输出多维栅格上构建多维转置。</para>
		/// <para>选中 - 将在输出多维栅格上构建多维转置。</para>
		/// <para>未选中 - 将不会在输出多维栅格上构建多维转置。 这是默认设置。</para>
		/// <para><see cref="BuildTransposeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Output Parameters")]
		public object? BuildTranspose { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GALayer3DToMultidimensionalRaster SetEnviroment(object? cellSize = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? snapRaster = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Enter explicit elevation values</para>
		/// </summary>
		public enum ExplicitOnlyEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EXPLICIT_VALUES")]
			EXPLICIT_VALUES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_EXPLICIT_VALUES")]
			NO_EXPLICIT_VALUES,

		}

		/// <summary>
		/// <para>Output type</para>
		/// </summary>
		public enum OutputTypeEnum 
		{
			/// <summary>
			/// <para>预测—预测值的多维栅格。 这是默认设置。</para>
			/// </summary>
			[GPValue("PREDICTION")]
			[Description("预测")]
			Prediction,

			/// <summary>
			/// <para>预测标准误差—预测标准误差的多维栅格。</para>
			/// </summary>
			[GPValue("PREDICTION_STANDARD_ERROR")]
			[Description("预测标准误差")]
			Prediction_standard_error,

			/// <summary>
			/// <para>概率—用于预测超出阈值的概率的多维栅格。</para>
			/// </summary>
			[GPValue("PROBABILITY")]
			[Description("概率")]
			Probability,

			/// <summary>
			/// <para>分位数—用于预测预测值分位数的多维栅格。</para>
			/// </summary>
			[GPValue("QUANTILE")]
			[Description("分位数")]
			Quantile,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("CONDITION_NUMBER")]
			[Description("CONDITION_NUMBER")]
			CONDITION_NUMBER,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("STANDARD_ERROR_INDICATORS")]
			[Description("STANDARD_ERROR_INDICATORS")]
			STANDARD_ERROR_INDICATORS,

		}

		/// <summary>
		/// <para>Build multidimensional transpose</para>
		/// </summary>
		public enum BuildTransposeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("BUILD_TRANSPOSE")]
			BUILD_TRANSPOSE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_BUILD_TRANSPOSE")]
			DO_NOT_BUILD_TRANSPOSE,

		}

#endregion
	}
}
