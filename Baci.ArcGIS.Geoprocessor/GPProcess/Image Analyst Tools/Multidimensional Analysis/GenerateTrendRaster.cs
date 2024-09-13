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
	/// <para>Generate Trend Raster</para>
	/// <para>Estimates the trend for each pixel along a dimension for one or more variables in a multidimensional raster.</para>
	/// </summary>
	public class GenerateTrendRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMultidimensionalRaster">
		/// <para>Input Multidimensional Raster</para>
		/// <para>The input multidimensional raster dataset.</para>
		/// </param>
		/// <param name="OutMultidimensionalRaster">
		/// <para>Output Multidimensional Raster</para>
		/// <para>The output Cloud Raster Format (CRF) multidimensional raster dataset.</para>
		/// </param>
		/// <param name="Dimension">
		/// <para>Dimension</para>
		/// <para>The dimension along which a trend will be extracted for the variable or variables selected in the analysis.</para>
		/// </param>
		public GenerateTrendRaster(object InMultidimensionalRaster, object OutMultidimensionalRaster, object Dimension)
		{
			this.InMultidimensionalRaster = InMultidimensionalRaster;
			this.OutMultidimensionalRaster = OutMultidimensionalRaster;
			this.Dimension = Dimension;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Trend Raster</para>
		/// </summary>
		public override string DisplayName() => "Generate Trend Raster";

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
		/// <para>The input multidimensional raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Output Multidimensional Raster</para>
		/// <para>The output Cloud Raster Format (CRF) multidimensional raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Dimension</para>
		/// <para>The dimension along which a trend will be extracted for the variable or variables selected in the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Dimension { get; set; }

		/// <summary>
		/// <para>Variables [Dimension Info] (Description)</para>
		/// <para>The variable or variables for which trends will be calculated. If no variable is specified, the first variable in the multidimensional raster will be analyzed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Variables { get; set; }

		/// <summary>
		/// <para>Trend Type</para>
		/// <para>Specifies the type of trend analysis to perform to pixel values along a dimension.</para>
		/// <para>Linear—Variable pixel values will be fitted along a linear trend line. This is the default.</para>
		/// <para>Polynomial—Variable pixel values will be fitted along a second order polynomial trend line.</para>
		/// <para>Harmonic—Variable pixel values will be fitted along a harmonic trend line.</para>
		/// <para>Mann-Kendall—Variable pixel values will be evaluated using the Mann-Kendall trend test.</para>
		/// <para>Seasonal-Kendall—Variable pixel values will be evaluated using the Seasonal-Kendall trend test.</para>
		/// <para><see cref="LineTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LineType { get; set; } = "LINEAR";

		/// <summary>
		/// <para>Frequency / Polynomial Order</para>
		/// <para>The frequency or the polynomial order number to use in the trend fitting. If the trend type is polynomial, this parameter specifies the polynomial order. If the trend type is harmonic, this parameter specifies the number of models to use to fit the trend.</para>
		/// <para>This parameter is only included in the trend analysis when the dimension being analyzed is time.</para>
		/// <para>If the Trend Type parameter is Harmonic, the default value is 1, meaning a first order harmonic curve is used to fit the model.</para>
		/// <para>If the Trend Type parameter is Polynomial, the default value is 2, or second order polynomial.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? Frequency { get; set; }

		/// <summary>
		/// <para>Ignore NoData</para>
		/// <para>Specifies whether NoData values are ignored in the analysis.</para>
		/// <para>Checked—The analysis will include all valid pixels along a given dimension and ignore any NoData pixels. This is the default.</para>
		/// <para>Unchecked—The analysis will result in NoData if there are any NoData values for the pixels along the given dimension.</para>
		/// <para><see cref="IgnoreNodataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IgnoreNodata { get; set; } = "true";

		/// <summary>
		/// <para>Length of Cycle</para>
		/// <para>The length of periodic variation to model. This parameter is required when Trend Type is set to Harmonic. For example, leaf greenness often has one strong cycle of variation in a single year, so the cycle length is 1 year. Hourly temperature data has one strong cycle of variation throughout a single day, so the cycle length is 1 day.</para>
		/// <para>The default length is 1 year for data that varies on an annual cycle.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? CycleLength { get; set; }

		/// <summary>
		/// <para>Cycle Unit</para>
		/// <para>Specifies the time unit to be used for the length of a harmonic cycle.</para>
		/// <para>Days—The unit for the length of the harmonic cycle is days.</para>
		/// <para>Years—The unit for the length of the harmonic cycle is years. This is the default.</para>
		/// <para><see cref="CycleUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CycleUnit { get; set; }

		/// <summary>
		/// <para>RMSE</para>
		/// <para>Specifies whether the root mean square error (RMSE) of the trend fit line will be calculated.</para>
		/// <para>Checked—The RMSE will be calculated and displayed in the raster dataset properties window under Statistics. This is the default.</para>
		/// <para>Unchecked—The RMSE will not be calculated.</para>
		/// <para><see cref="RmseEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Model Statistics")]
		public object? Rmse { get; set; } = "true";

		/// <summary>
		/// <para>R-Squared</para>
		/// <para>Specifies whether the R-squared goodness-of-fit statistic for the trend fit line will be calculated.</para>
		/// <para>Checked—The R-squared value will be calculated and displayed in the raster dataset properties window under Statistics.</para>
		/// <para>Unchecked—The R-squared value will not be calculated. This is the default.</para>
		/// <para><see cref="R2Enum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Model Statistics")]
		public object? R2 { get; set; } = "false";

		/// <summary>
		/// <para>P-Value of Slope Coefficient</para>
		/// <para>Specifies whether the p-value statistic for the slope coefficient of the trend line will be calculated.</para>
		/// <para>Checked—The p-value will be calculated and displayed in the raster dataset properties window under Statistics.</para>
		/// <para>Unchecked—The p-value will not be calculated. This is the default.</para>
		/// <para><see cref="SlopePValueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Model Statistics")]
		public object? SlopePValue { get; set; } = "false";

		/// <summary>
		/// <para>Seasonal Period</para>
		/// <para>Specifies the time unit to be used for the length of a seasonal period when performing the Seasonal-Kendall test.</para>
		/// <para>Days—The unit for the length of the seasonal period is days. This is the default.</para>
		/// <para>Months—The unit for the length of the seasonal period is months.</para>
		/// <para><see cref="SeasonalPeriodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SeasonalPeriod { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateTrendRaster SetEnviroment(object? cellSize = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
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
			/// <para>Linear—Variable pixel values will be fitted along a linear trend line. This is the default.</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("Linear")]
			Linear,

			/// <summary>
			/// <para>Harmonic—Variable pixel values will be fitted along a harmonic trend line.</para>
			/// </summary>
			[GPValue("HARMONIC")]
			[Description("Harmonic")]
			Harmonic,

			/// <summary>
			/// <para>Polynomial—Variable pixel values will be fitted along a second order polynomial trend line.</para>
			/// </summary>
			[GPValue("POLYNOMIAL")]
			[Description("Polynomial")]
			Polynomial,

			/// <summary>
			/// <para>Mann-Kendall—Variable pixel values will be evaluated using the Mann-Kendall trend test.</para>
			/// </summary>
			[GPValue("MANN-KENDALL")]
			[Description("Mann-Kendall")]
			MANN_KENDALL,

			/// <summary>
			/// <para>Seasonal-Kendall—Variable pixel values will be evaluated using the Seasonal-Kendall trend test.</para>
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
			/// <para>Checked—The analysis will include all valid pixels along a given dimension and ignore any NoData pixels. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DATA")]
			DATA,

			/// <summary>
			/// <para>Unchecked—The analysis will result in NoData if there are any NoData values for the pixels along the given dimension.</para>
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
			/// <para>Days—The unit for the length of the harmonic cycle is days.</para>
			/// </summary>
			[GPValue("DAYS")]
			[Description("Days")]
			Days,

			/// <summary>
			/// <para>Years—The unit for the length of the harmonic cycle is years. This is the default.</para>
			/// </summary>
			[GPValue("YEARS")]
			[Description("Years")]
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
			/// <para>Unchecked—The RMSE will not be calculated.</para>
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
			/// <para>Checked—The R-squared value will be calculated and displayed in the raster dataset properties window under Statistics.</para>
			/// </summary>
			[GPValue("true")]
			[Description("R2")]
			R2,

			/// <summary>
			/// <para>Unchecked—The R-squared value will not be calculated. This is the default.</para>
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
			/// <para>Checked—The p-value will be calculated and displayed in the raster dataset properties window under Statistics.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SLOPEPVALUE")]
			SLOPEPVALUE,

			/// <summary>
			/// <para>Unchecked—The p-value will not be calculated. This is the default.</para>
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
			/// <para>Days—The unit for the length of the seasonal period is days. This is the default.</para>
			/// </summary>
			[GPValue("DAYS")]
			[Description("Days")]
			Days,

			/// <summary>
			/// <para>Months—The unit for the length of the seasonal period is months.</para>
			/// </summary>
			[GPValue("MONTHS")]
			[Description("Months")]
			Months,

		}

#endregion
	}
}
