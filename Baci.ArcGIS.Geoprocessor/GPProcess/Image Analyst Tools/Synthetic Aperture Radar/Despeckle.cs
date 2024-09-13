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
	/// <para>Despeckle</para>
	/// <para>Corrects the input synthetic aperture radar (SAR) data for speckle, which is high-frequency noise that resembles a salt and pepper effect.</para>
	/// </summary>
	public class Despeckle : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRadarData">
		/// <para>Input Radar Data</para>
		/// <para>The input radar data.</para>
		/// </param>
		/// <param name="OutRadarData">
		/// <para>Output Radar Data</para>
		/// <para>The despeckled radar data.</para>
		/// </param>
		public Despeckle(object InRadarData, object OutRadarData)
		{
			this.InRadarData = InRadarData;
			this.OutRadarData = OutRadarData;
		}

		/// <summary>
		/// <para>Tool Display Name : Despeckle</para>
		/// </summary>
		public override string DisplayName() => "Despeckle";

		/// <summary>
		/// <para>Tool Name : Despeckle</para>
		/// </summary>
		public override string ToolName() => "Despeckle";

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
		/// <para>The input radar data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRadarData { get; set; }

		/// <summary>
		/// <para>Output Radar Data</para>
		/// <para>The despeckled radar data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRadarData { get; set; }

		/// <summary>
		/// <para>Polarization Bands</para>
		/// <para>The polarization bands to be filtered.</para>
		/// <para>The first band is selected by default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? PolarizationBands { get; set; }

		/// <summary>
		/// <para>Filter Type</para>
		/// <para>Specifies the type of smoothing algorithm or filter that will be applied.</para>
		/// <para>Lee—A spatial filter will be applied to each pixel in an image to reduce the speckle noise. This option filters the data based on local statistics calculated within a square window. This filter is useful for smoothing speckled data that has an additive or multiplicative component. (Reference 1 in the Usage section above)</para>
		/// <para>Enhanced Lee—A spatial filter that preserves the sharpness and detail of the image will be applied to reduce the speckle noise. This option is a refined version of the Lee filter. This filter is useful for reducing speckle while preserving texture information. (Reference 2 in the Usage section above)</para>
		/// <para>Refined Lee—A spatial filter will be applied to selected pixels, based on local statistics, to reduce the speckle noise. This filter uses a nonsquare filter window to match the direction of edges. It is useful for reducing speckle while preserving edges. This is the default. (Reference 3 in the Usage section above)</para>
		/// <para>Frost—An exponentially damped circularly symmetric filter that uses local statistics within individual filter windows will be applied to reduce the speckle noise. This does not affect image features at the edges. This filter is useful for reducing speckle while preserving edges. (Reference 4 in the Usage section above)</para>
		/// <para>Kuan—A spatial filter, the Kuan filter, will be applied to each pixel in an image to reduce the speckle noise. This filters the data based on local statistics of the centered pixel value that is calculated using the neighboring pixels. This filter is useful for reducing speckle while preserving edges. (Reference 5 in the Usage section above)</para>
		/// <para>Gamma MAP—A Bayesian analysis and Gamma distribution filter will be applied to reduce the speckle noise. This filter is useful for reducing speckle while preserving edges. (Reference 6 in the Usage section above)</para>
		/// <para><see cref="FilterTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FilterType { get; set; } = "REFINED_LEE";

		/// <summary>
		/// <para>Filter Size</para>
		/// <para>Specifies the size of the pixel window that will be used to filter noise.</para>
		/// <para>3 x 3—A 3-by-3 filter size will be used. This is the default.</para>
		/// <para>5 x 5—A 5-by-5 filter size will be used.</para>
		/// <para>7 x 7—A 7-by-7 filter size will be used.</para>
		/// <para>9 x 9—A 9-by-9 filter size will be used.</para>
		/// <para>11 x 11—An 11-by-11 filter size will be used.</para>
		/// <para>This parameter is only valid when the Filter Type parameter is set to Lee, Enhanced Lee, Frost, Kuan, or Gamma MAP.</para>
		/// <para><see cref="FilterSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FilterSize { get; set; } = "7x7";

		/// <summary>
		/// <para>Noise Model</para>
		/// <para>Specifies the type of noise that is reducing the quality of the radar image.</para>
		/// <para>Multiplicative noise—Random signal noise that is multiplied into the relevant signal during capture or transmission is reducing the quality. This is the default.</para>
		/// <para>Additive noise—Random signal noise that is added into the relevant signal during capture or transmission is reducing the quality.</para>
		/// <para>Additive and multiplicative noise—A combination of both noise models is reducing the quality.</para>
		/// <para>This parameter is only valid when the Filter Type parameter is set to Lee.</para>
		/// <para><see cref="NoiseModelEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? NoiseModel { get; set; } = "MULTIPLICATIVE_NOISE";

		/// <summary>
		/// <para>Noise Variance</para>
		/// <para>The noise variance of the radar image. The default is 0.25.</para>
		/// <para>This parameter is only valid when the Filter Type parameter is set to Lee and the Noise Model parameter is set to Additive noise or Additive and multiplicative noise.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? NoiseVariance { get; set; } = "0.25";

		/// <summary>
		/// <para>Additive Noise Mean</para>
		/// <para>The mean value of additive noise. A larger noise mean value will produce less smoothing, while a smaller value results in more smoothing. The default value is 0.</para>
		/// <para>This parameter is only valid when the Filter Type parameter is set to Lee and the Noise Model parameter is set to Additive and multiplicative noise.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? AddNoiseMean { get; set; } = "0";

		/// <summary>
		/// <para>Multiplicative Noise Mean</para>
		/// <para>The mean value of multiplicative noise. A larger noise mean value will produce less smoothing, while a smaller value results in more smoothing. The default value is 1.</para>
		/// <para>This parameter is only valid when the Filter Type parameter is set to Lee and the Noise Model parameter is set to Multiplicative noise or Additive and multiplicative noise.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MultNoiseMean { get; set; } = "1";

		/// <summary>
		/// <para>Number of Looks</para>
		/// <para>The number of looks value of the image, which controls image smoothing and estimates noise variance. A smaller value results in more smoothing, while a larger value retains more image features. The default value is 1.</para>
		/// <para>This parameter is only valid when the Filter Type parameter is set to Enhanced Lee, Kuan, or Gamma MAP, or when the Filter Type parameter is set to Lee and the Noise Model parameter is set to Multiplicative.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumberOfLooks { get; set; } = "1";

		/// <summary>
		/// <para>Damping Factor</para>
		/// <para>The exponential damping level of smoothing that will be applied. A damping value greater than 1 will result in better edge preservation but less smoothing. Values less than 1 will result in more smoothing. A value of 0 will produce results similar to a low-pass filter. The default is 1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? DampFactor { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Despeckle SetEnviroment(object? cellAlignment = null , object? cellSize = null , object? compression = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
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
			/// <para>Lee—A spatial filter will be applied to each pixel in an image to reduce the speckle noise. This option filters the data based on local statistics calculated within a square window. This filter is useful for smoothing speckled data that has an additive or multiplicative component. (Reference 1 in the Usage section above)</para>
			/// </summary>
			[GPValue("LEE")]
			[Description("Lee")]
			Lee,

			/// <summary>
			/// <para>Enhanced Lee—A spatial filter that preserves the sharpness and detail of the image will be applied to reduce the speckle noise. This option is a refined version of the Lee filter. This filter is useful for reducing speckle while preserving texture information. (Reference 2 in the Usage section above)</para>
			/// </summary>
			[GPValue("ENHANCED_LEE")]
			[Description("Enhanced Lee")]
			Enhanced_Lee,

			/// <summary>
			/// <para>Refined Lee—A spatial filter will be applied to selected pixels, based on local statistics, to reduce the speckle noise. This filter uses a nonsquare filter window to match the direction of edges. It is useful for reducing speckle while preserving edges. This is the default. (Reference 3 in the Usage section above)</para>
			/// </summary>
			[GPValue("REFINED_LEE")]
			[Description("Refined Lee")]
			Refined_Lee,

			/// <summary>
			/// <para>Frost—An exponentially damped circularly symmetric filter that uses local statistics within individual filter windows will be applied to reduce the speckle noise. This does not affect image features at the edges. This filter is useful for reducing speckle while preserving edges. (Reference 4 in the Usage section above)</para>
			/// </summary>
			[GPValue("FROST")]
			[Description("Frost")]
			Frost,

			/// <summary>
			/// <para>Kuan—A spatial filter, the Kuan filter, will be applied to each pixel in an image to reduce the speckle noise. This filters the data based on local statistics of the centered pixel value that is calculated using the neighboring pixels. This filter is useful for reducing speckle while preserving edges. (Reference 5 in the Usage section above)</para>
			/// </summary>
			[GPValue("KUAN")]
			[Description("Kuan")]
			Kuan,

			/// <summary>
			/// <para>Gamma MAP—A Bayesian analysis and Gamma distribution filter will be applied to reduce the speckle noise. This filter is useful for reducing speckle while preserving edges. (Reference 6 in the Usage section above)</para>
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
			/// <para>3 x 3—A 3-by-3 filter size will be used. This is the default.</para>
			/// </summary>
			[GPValue("3x3")]
			[Description("3 x 3")]
			_3_x_3,

			/// <summary>
			/// <para>5 x 5—A 5-by-5 filter size will be used.</para>
			/// </summary>
			[GPValue("5x5")]
			[Description("5 x 5")]
			_5_x_5,

			/// <summary>
			/// <para>7 x 7—A 7-by-7 filter size will be used.</para>
			/// </summary>
			[GPValue("7x7")]
			[Description("7 x 7")]
			_7_x_7,

			/// <summary>
			/// <para>9 x 9—A 9-by-9 filter size will be used.</para>
			/// </summary>
			[GPValue("9x9")]
			[Description("9 x 9")]
			_9_x_9,

			/// <summary>
			/// <para>11 x 11—An 11-by-11 filter size will be used.</para>
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
			/// <para>Multiplicative noise—Random signal noise that is multiplied into the relevant signal during capture or transmission is reducing the quality. This is the default.</para>
			/// </summary>
			[GPValue("MULTIPLICATIVE_NOISE")]
			[Description("Multiplicative noise")]
			Multiplicative_noise,

			/// <summary>
			/// <para>Additive noise—Random signal noise that is added into the relevant signal during capture or transmission is reducing the quality.</para>
			/// </summary>
			[GPValue("ADDITIVE_NOISE")]
			[Description("Additive noise")]
			Additive_noise,

			/// <summary>
			/// <para>Additive and multiplicative noise—A combination of both noise models is reducing the quality.</para>
			/// </summary>
			[GPValue("ADDITIVE_AND_MULTIPLICATIVE_NOISE")]
			[Description("Additive and multiplicative noise")]
			Additive_and_multiplicative_noise,

		}

#endregion
	}
}
