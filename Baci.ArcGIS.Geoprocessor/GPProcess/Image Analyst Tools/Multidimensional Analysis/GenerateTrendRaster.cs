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
	/// <para>Generate Trend Raster</para>
	/// <para>生成趋势栅格</para>
	/// <para>用于面向多维栅格中一个或多个变量估计每个像素沿维度的趋势。</para>
	/// </summary>
	public class GenerateTrendRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMultidimensionalRaster">
		/// <para>Input Multidimensional Raster</para>
		/// <para>输入多维栅格数据集。</para>
		/// </param>
		/// <param name="OutMultidimensionalRaster">
		/// <para>Output Multidimensional Raster</para>
		/// <para>输出云栅格格式 (CRF) 多维栅格数据集。</para>
		/// </param>
		/// <param name="Dimension">
		/// <para>Dimension</para>
		/// <para>将沿此维度为分析中所选的一个或多个变量提取趋势。</para>
		/// </param>
		public GenerateTrendRaster(object InMultidimensionalRaster, object OutMultidimensionalRaster, object Dimension)
		{
			this.InMultidimensionalRaster = InMultidimensionalRaster;
			this.OutMultidimensionalRaster = OutMultidimensionalRaster;
			this.Dimension = Dimension;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成趋势栅格</para>
		/// </summary>
		public override string DisplayName() => "生成趋势栅格";

		/// <summary>
		/// <para>Tool Name : GenerateTrendRaster</para>
		/// </summary>
		public override string ToolName() => "GenerateTrendRaster";

		/// <summary>
		/// <para>Tool Excute Name : ia.GenerateTrendRaster</para>
		/// </summary>
		public override string ExcuteName() => "ia.GenerateTrendRaster";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMultidimensionalRaster, OutMultidimensionalRaster, Dimension, Variables!, LineType!, Frequency!, IgnoreNodata!, CycleLength!, CycleUnit!, Rmse!, R2!, SlopePValue!, SeasonalPeriod! };

		/// <summary>
		/// <para>Input Multidimensional Raster</para>
		/// <para>输入多维栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Output Multidimensional Raster</para>
		/// <para>输出云栅格格式 (CRF) 多维栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Dimension</para>
		/// <para>将沿此维度为分析中所选的一个或多个变量提取趋势。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Dimension { get; set; }

		/// <summary>
		/// <para>Variables [Dimension Info] (Description)</para>
		/// <para>将计算趋势的一个或多个变量。如果未指定变量，则将分析多维栅格中的第一个变量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Variables { get; set; }

		/// <summary>
		/// <para>Trend Type</para>
		/// <para>指定用于执行沿维度像素值的趋势分析的类型。</para>
		/// <para>线性—将沿线性趋势线拟合变量像素值。这是默认设置。</para>
		/// <para>多项式—将沿二阶多项式趋势线拟合变量像素值。</para>
		/// <para>谐波—将沿谐波趋势线拟合变量像素值。</para>
		/// <para>Mann-Kendall—变量像素值将使用 Mann-Kendall 趋势测试进行评估。</para>
		/// <para>Seasonal-Kendall—变量像素值将使用 Seasonal-Kendall 趋势测试进行评估。</para>
		/// <para><see cref="LineTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LineType { get; set; } = "LINEAR";

		/// <summary>
		/// <para>Frequency / Polynomial Order</para>
		/// <para>趋势拟合中使用的频率或多项式阶数。如果趋势类型是多项式，则此参数将指定多项式阶数。如果趋势类型为谐波，则此参数将指定用于拟合趋势的模型数量。</para>
		/// <para>仅当分析的维度是时间时，趋势分析中才会包含此参数。</para>
		/// <para>如果趋势类型参数为谐波，则默认值为 1，这意味着将使用一阶谐波曲线来拟合模型。</para>
		/// <para>如果趋势类型参数是多项式，则默认值为 2 或二阶多项式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? Frequency { get; set; }

		/// <summary>
		/// <para>Ignore NoData</para>
		/// <para>指定分析中是否忽略 NoData 值。</para>
		/// <para>已选中 - 分析将包括沿给定维度的所有有效像素，并忽略所有 NoData 像素。 这是默认设置。</para>
		/// <para>未选中 - 如果沿给定维度的像素包含任意 NoData 值，则分析结果将变为 NoData。</para>
		/// <para><see cref="IgnoreNodataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IgnoreNodata { get; set; } = "true";

		/// <summary>
		/// <para>Length of Cycle</para>
		/// <para>要进行建模的周期性变化的长度。当趋势类型设置为谐波时，此参数为必需项。例如，叶绿度通常在一年中具有一个较强的变化周期，因此周期长度为 1 年。每小时温度数据在一天中具有一个较强的变化周期，因此周期长度为 1 天。</para>
		/// <para>对于每年周期变化的数据，默认长度为 1 年。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? CycleLength { get; set; }

		/// <summary>
		/// <para>Cycle Unit</para>
		/// <para>指定用于谐波周期长度的时间单位。</para>
		/// <para>天—谐波周期的长度单位为天。</para>
		/// <para>年—谐波周期的长度单位为年。这是默认设置。</para>
		/// <para><see cref="CycleUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CycleUnit { get; set; }

		/// <summary>
		/// <para>RMSE</para>
		/// <para>指定是否将计算趋势拟合线的均方根误差 (RMSE)。</para>
		/// <para>选中 - 将计算 RMSE 并显示在栅格数据集属性窗口的统计数据下方。这是默认设置。</para>
		/// <para>未选中 - 将不计算 RMSE。</para>
		/// <para><see cref="RmseEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Model Statistics")]
		public object? Rmse { get; set; } = "true";

		/// <summary>
		/// <para>R-Squared</para>
		/// <para>指定是否将为趋势拟合线计算 R 平方拟合优度统计数据。</para>
		/// <para>选中 - 将计算 R 平方值并显示在栅格数据集属性窗口的统计数据下方。</para>
		/// <para>未选中 - 将不计算 R 平方值。这是默认设置。</para>
		/// <para><see cref="R2Enum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Model Statistics")]
		public object? R2 { get; set; } = "false";

		/// <summary>
		/// <para>P-Value of Slope Coefficient</para>
		/// <para>指定是否将为趋势线的斜率系数计算 p 值统计数据。</para>
		/// <para>选中 - 将计算 p 值并显示在栅格数据集属性窗口的统计数据下方。</para>
		/// <para>未选中 - 将不计算 p 值。这是默认设置。</para>
		/// <para><see cref="SlopePValueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Model Statistics")]
		public object? SlopePValue { get; set; } = "false";

		/// <summary>
		/// <para>Seasonal Period</para>
		/// <para>指定在执行 Seasonal-Kendall 测试时用于季节性期间长度的时间单位。</para>
		/// <para>天—季节性期间的长度单位为天。这是默认设置。</para>
		/// <para>月—季节性期间的长度单位为月。</para>
		/// <para><see cref="SeasonalPeriodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SeasonalPeriod { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateTrendRaster SetEnviroment(object? cellSize = null, object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? nodata = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? pyramid = null, object? rasterStatistics = null, object? resamplingMethod = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Trend Type</para>
		/// </summary>
		public enum LineTypeEnum 
		{
			/// <summary>
			/// <para>线性—将沿线性趋势线拟合变量像素值。这是默认设置。</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("线性")]
			Linear,

			/// <summary>
			/// <para>谐波—将沿谐波趋势线拟合变量像素值。</para>
			/// </summary>
			[GPValue("HARMONIC")]
			[Description("谐波")]
			Harmonic,

			/// <summary>
			/// <para>多项式—将沿二阶多项式趋势线拟合变量像素值。</para>
			/// </summary>
			[GPValue("POLYNOMIAL")]
			[Description("多项式")]
			Polynomial,

			/// <summary>
			/// <para>Mann-Kendall—变量像素值将使用 Mann-Kendall 趋势测试进行评估。</para>
			/// </summary>
			[GPValue("MANN-KENDALL")]
			[Description("Mann-Kendall")]
			MANN_KENDALL,

			/// <summary>
			/// <para>Seasonal-Kendall—变量像素值将使用 Seasonal-Kendall 趋势测试进行评估。</para>
			/// </summary>
			[GPValue("SEASONAL-KENDALL")]
			[Description("Seasonal-Kendall")]
			SEASONAL_KENDALL,

		}

		/// <summary>
		/// <para>Ignore NoData</para>
		/// </summary>
		public enum IgnoreNodataEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DATA")]
			DATA,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NODATA")]
			NODATA,

		}

		/// <summary>
		/// <para>Cycle Unit</para>
		/// </summary>
		public enum CycleUnitEnum 
		{
			/// <summary>
			/// <para>天—谐波周期的长度单位为天。</para>
			/// </summary>
			[GPValue("DAYS")]
			[Description("天")]
			Days,

			/// <summary>
			/// <para>年—谐波周期的长度单位为年。这是默认设置。</para>
			/// </summary>
			[GPValue("YEARS")]
			[Description("年")]
			Years,

		}

		/// <summary>
		/// <para>RMSE</para>
		/// </summary>
		public enum RmseEnum 
		{
			/// <summary>
			/// <para>RMSE</para>
			/// </summary>
			[GPValue("true")]
			[Description("RMSE")]
			RMSE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_RMSE")]
			NO_RMSE,

		}

		/// <summary>
		/// <para>R-Squared</para>
		/// </summary>
		public enum R2Enum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("R2")]
			R2,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_R2")]
			NO_R2,

		}

		/// <summary>
		/// <para>P-Value of Slope Coefficient</para>
		/// </summary>
		public enum SlopePValueEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SLOPEPVALUE")]
			SLOPEPVALUE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SLOPEPVALUE")]
			NO_SLOPEPVALUE,

		}

		/// <summary>
		/// <para>Seasonal Period</para>
		/// </summary>
		public enum SeasonalPeriodEnum 
		{
			/// <summary>
			/// <para>天—季节性期间的长度单位为天。这是默认设置。</para>
			/// </summary>
			[GPValue("DAYS")]
			[Description("天")]
			Days,

			/// <summary>
			/// <para>月—季节性期间的长度单位为月。</para>
			/// </summary>
			[GPValue("MONTHS")]
			[Description("月")]
			Months,

		}

#endregion
	}
}
