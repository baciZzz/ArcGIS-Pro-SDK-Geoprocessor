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
	/// <para>Despeckle</para>
	/// <para>去斑</para>
	/// <para>校正输入合成孔径雷达 (SAR) 数据中的散斑，这是一种类似于斑白效果的高频噪声。</para>
	/// </summary>
	public class Despeckle : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRadarData">
		/// <para>Input Radar Data</para>
		/// <para>输入雷达数据。</para>
		/// </param>
		/// <param name="OutRadarData">
		/// <para>Output Radar Data</para>
		/// <para>去斑雷达数据。</para>
		/// </param>
		public Despeckle(object InRadarData, object OutRadarData)
		{
			this.InRadarData = InRadarData;
			this.OutRadarData = OutRadarData;
		}

		/// <summary>
		/// <para>Tool Display Name : 去斑</para>
		/// </summary>
		public override string DisplayName() => "去斑";

		/// <summary>
		/// <para>Tool Name : 去斑</para>
		/// </summary>
		public override string ToolName() => "去斑";

		/// <summary>
		/// <para>Tool Excute Name : ia.Despeckle</para>
		/// </summary>
		public override string ExcuteName() => "ia.Despeckle";

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
		public override string[] ValidEnvironments() => new string[] { "cellAlignment", "cellSize", "compression", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRadarData, OutRadarData, PolarizationBands!, FilterType!, FilterSize!, NoiseModel!, NoiseVariance!, AddNoiseMean!, MultNoiseMean!, NumberOfLooks!, DampFactor! };

		/// <summary>
		/// <para>Input Radar Data</para>
		/// <para>输入雷达数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRadarData { get; set; }

		/// <summary>
		/// <para>Output Radar Data</para>
		/// <para>去斑雷达数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRadarData { get; set; }

		/// <summary>
		/// <para>Polarization Bands</para>
		/// <para>要过滤的极化波段。</para>
		/// <para>默认情况下，第一个波段处于选中状态。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? PolarizationBands { get; set; }

		/// <summary>
		/// <para>Filter Type</para>
		/// <para>指定将应用的平滑算法或滤波器类型。</para>
		/// <para>Lee—空间滤波器将应用于图像中的每个像素以减少散斑噪声。 此选项对基于在方形窗口中计算的局部统计量的数据进行过滤。 对具有相加或相乘组件的斑点数据进行平滑处理时，此滤波器将非常有用。 （上述“使用方法”部分中的参考 1）</para>
		/// <para>增强型 Lee—将应用保留图像清晰度和细节的空间滤波器来减少散斑噪声。 此选项是 Lee 滤波器的改进版本。 如需在减少斑点的同时保留纹理信息，此滤波器将十分有用。 （上述“使用方法”部分中的参考 2）</para>
		/// <para>优化型 Lee—空间滤波器将根据局部统计数据应用于所选像素，以减少散斑噪声。 此滤波器使用非方形滤波器窗口来匹配边缘的方向。 如需在减少斑点的同时保留边缘，此滤波器将十分有用。 这是默认设置。 （上述“使用方法”部分中的参考 3）</para>
		/// <para>Frost—将应用一个使用单个滤波器窗口中局部统计量的、呈指数衰减的圆周状对称的滤波器来减少斑点噪声。 这不会影响边缘的图像要素。 如需在减少斑点的同时保留边缘，此滤波器将十分有用。 （上述“使用方法”部分中的参考 4）</para>
		/// <para>Kuan—空间滤波器（Kuan 滤波器）将应用于图像中的每个像素以减少散斑噪声。 此滤波器根据使用相邻像素所计算得出的居中像素值的局部统计量过滤数据。 如需在减少斑点的同时保留边缘，此滤波器将十分有用。 （上述“使用方法”部分中的参考 5）</para>
		/// <para>Gamma MAP—将应用贝叶斯分析和 Gamma 分布滤波器来减少散斑噪声。 如需在减少斑点的同时保留边缘，此滤波器将十分有用。 （上述“使用方法”部分中的参考 6）</para>
		/// <para><see cref="FilterTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FilterType { get; set; } = "REFINED_LEE";

		/// <summary>
		/// <para>Filter Size</para>
		/// <para>指定将用于过滤噪声的像素窗口的大小。</para>
		/// <para>3 x 3—将使用 3 x 3 滤波器大小。 这是默认设置。</para>
		/// <para>5 x 5—将使用 5 x 5 滤波器大小。</para>
		/// <para>7 x 7—将使用 7 x 7 滤波器大小。</para>
		/// <para>9 x 9—将使用 9 x 9 滤波器大小。</para>
		/// <para>11 x 11—将使用 11 x 11 滤波器大小。</para>
		/// <para>此参数只有在滤波器类型参数设置为 Lee、增强型 Lee、Frost、Kuan 或 Gamma MAP 时才有效。</para>
		/// <para><see cref="FilterSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FilterSize { get; set; } = "7x7";

		/// <summary>
		/// <para>Noise Model</para>
		/// <para>指定用于减少雷达影像质量的噪声类型。</para>
		/// <para>相乘噪声—将降低在捕获或传输过程中用于相乘为相关信号的随机信号噪声的质量。 这是默认设置。</para>
		/// <para>相加噪声—将降低在捕获或传输过程中用于相加为相关信号的随机信号噪声的质量。</para>
		/// <para>相加和相乘噪声—将降低两种噪声模型组合的质量。</para>
		/// <para>此参数只有在滤波器类型参数设置为 Lee 时才有效。</para>
		/// <para><see cref="NoiseModelEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? NoiseModel { get; set; } = "MULTIPLICATIVE_NOISE";

		/// <summary>
		/// <para>Noise Variance</para>
		/// <para>雷达影像的噪声方差。 默认值为 0.25。</para>
		/// <para>此参数只有在滤波器类型参数设置为 Lee，且噪声模型参数设置为相加噪声或相加和相乘噪声时才有效。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? NoiseVariance { get; set; } = "0.25";

		/// <summary>
		/// <para>Additive Noise Mean</para>
		/// <para>相加噪声的平均值。 噪声均值越大，平滑效果越差，而噪声均值越小，平滑效果越好。 默认值为 0。</para>
		/// <para>此参数只有在滤波器类型参数设置为 Lee，且噪声模型参数设置为相加和相乘噪声时才有效。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? AddNoiseMean { get; set; } = "0";

		/// <summary>
		/// <para>Multiplicative Noise Mean</para>
		/// <para>相乘噪声的平均值。 噪声均值越大，平滑效果越差，而噪声均值越小，平滑效果越好。 默认值为 1。</para>
		/// <para>此参数只有在滤波器类型参数设置为 Lee，且噪声模型参数设置为相乘噪声或相加和相乘噪声时才有效。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MultNoiseMean { get; set; } = "1";

		/// <summary>
		/// <para>Number of Looks</para>
		/// <para>影像的查看次数，而查看次数用于控制影像平滑和估算噪声方差。 较小的值会导致较多的平滑处理，而较大的值则会保留较多的影像要素。 默认值为 1。</para>
		/// <para>此参数只有在滤波器类型参数设置为增强型 Lee、Kuan 或 Gamma MAP，或滤波器类型参数设置为 Lee 且噪声模型参数设置为相乘时才有效。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumberOfLooks { get; set; } = "1";

		/// <summary>
		/// <para>Damping Factor</para>
		/// <para>将应用的平滑指数衰减等级。 阻尼值大于 1 时，可以更好的保留边缘，但平滑效果交差。 值小于 1 时，平滑度更高。 值等于 0 的效果与低通滤波器相似。 默认值为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? DampFactor { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Despeckle SetEnviroment(object? cellAlignment = null, object? cellSize = null, object? compression = null, object? extent = null, object? geographicTransformations = null, object? nodata = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? pyramid = null, object? rasterStatistics = null, object? resamplingMethod = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(cellAlignment: cellAlignment, cellSize: cellSize, compression: compression, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Filter Type</para>
		/// </summary>
		public enum FilterTypeEnum 
		{
			/// <summary>
			/// <para>Lee—空间滤波器将应用于图像中的每个像素以减少散斑噪声。 此选项对基于在方形窗口中计算的局部统计量的数据进行过滤。 对具有相加或相乘组件的斑点数据进行平滑处理时，此滤波器将非常有用。 （上述“使用方法”部分中的参考 1）</para>
			/// </summary>
			[GPValue("LEE")]
			[Description("Lee")]
			Lee,

			/// <summary>
			/// <para>增强型 Lee—将应用保留图像清晰度和细节的空间滤波器来减少散斑噪声。 此选项是 Lee 滤波器的改进版本。 如需在减少斑点的同时保留纹理信息，此滤波器将十分有用。 （上述“使用方法”部分中的参考 2）</para>
			/// </summary>
			[GPValue("ENHANCED_LEE")]
			[Description("增强型 Lee")]
			Enhanced_Lee,

			/// <summary>
			/// <para>优化型 Lee—空间滤波器将根据局部统计数据应用于所选像素，以减少散斑噪声。 此滤波器使用非方形滤波器窗口来匹配边缘的方向。 如需在减少斑点的同时保留边缘，此滤波器将十分有用。 这是默认设置。 （上述“使用方法”部分中的参考 3）</para>
			/// </summary>
			[GPValue("REFINED_LEE")]
			[Description("优化型 Lee")]
			Refined_Lee,

			/// <summary>
			/// <para>Frost—将应用一个使用单个滤波器窗口中局部统计量的、呈指数衰减的圆周状对称的滤波器来减少斑点噪声。 这不会影响边缘的图像要素。 如需在减少斑点的同时保留边缘，此滤波器将十分有用。 （上述“使用方法”部分中的参考 4）</para>
			/// </summary>
			[GPValue("FROST")]
			[Description("Frost")]
			Frost,

			/// <summary>
			/// <para>Kuan—空间滤波器（Kuan 滤波器）将应用于图像中的每个像素以减少散斑噪声。 此滤波器根据使用相邻像素所计算得出的居中像素值的局部统计量过滤数据。 如需在减少斑点的同时保留边缘，此滤波器将十分有用。 （上述“使用方法”部分中的参考 5）</para>
			/// </summary>
			[GPValue("KUAN")]
			[Description("Kuan")]
			Kuan,

			/// <summary>
			/// <para>Gamma MAP—将应用贝叶斯分析和 Gamma 分布滤波器来减少散斑噪声。 如需在减少斑点的同时保留边缘，此滤波器将十分有用。 （上述“使用方法”部分中的参考 6）</para>
			/// </summary>
			[GPValue("GAMMA_MAP")]
			[Description("Gamma MAP")]
			Gamma_MAP,

		}

		/// <summary>
		/// <para>Filter Size</para>
		/// </summary>
		public enum FilterSizeEnum 
		{
			/// <summary>
			/// <para>3 x 3—将使用 3 x 3 滤波器大小。 这是默认设置。</para>
			/// </summary>
			[GPValue("3x3")]
			[Description("3 x 3")]
			_3_x_3,

			/// <summary>
			/// <para>5 x 5—将使用 5 x 5 滤波器大小。</para>
			/// </summary>
			[GPValue("5x5")]
			[Description("5 x 5")]
			_5_x_5,

			/// <summary>
			/// <para>7 x 7—将使用 7 x 7 滤波器大小。</para>
			/// </summary>
			[GPValue("7x7")]
			[Description("7 x 7")]
			_7_x_7,

			/// <summary>
			/// <para>9 x 9—将使用 9 x 9 滤波器大小。</para>
			/// </summary>
			[GPValue("9x9")]
			[Description("9 x 9")]
			_9_x_9,

			/// <summary>
			/// <para>11 x 11—将使用 11 x 11 滤波器大小。</para>
			/// </summary>
			[GPValue("11x11")]
			[Description("11 x 11")]
			_11_x_11,

		}

		/// <summary>
		/// <para>Noise Model</para>
		/// </summary>
		public enum NoiseModelEnum 
		{
			/// <summary>
			/// <para>相乘噪声—将降低在捕获或传输过程中用于相乘为相关信号的随机信号噪声的质量。 这是默认设置。</para>
			/// </summary>
			[GPValue("MULTIPLICATIVE_NOISE")]
			[Description("相乘噪声")]
			Multiplicative_noise,

			/// <summary>
			/// <para>相加噪声—将降低在捕获或传输过程中用于相加为相关信号的随机信号噪声的质量。</para>
			/// </summary>
			[GPValue("ADDITIVE_NOISE")]
			[Description("相加噪声")]
			Additive_noise,

			/// <summary>
			/// <para>相加和相乘噪声—将降低两种噪声模型组合的质量。</para>
			/// </summary>
			[GPValue("ADDITIVE_AND_MULTIPLICATIVE_NOISE")]
			[Description("相加和相乘噪声")]
			Additive_and_multiplicative_noise,

		}

#endregion
	}
}
