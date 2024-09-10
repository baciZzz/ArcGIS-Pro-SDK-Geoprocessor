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
	/// <para>Predict Using Trend Raster</para>
	/// <para>Computes a forecasted multidimensional raster using the output trend raster from the Generate Trend Raster tool.</para>
	/// </summary>
	public class PredictUsingTrendRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMultidimensionalRaster">
		/// <para>Input Trend Raster</para>
		/// <para>The input multidimensional trend raster from the Generate Trend Raster tool.</para>
		/// </param>
		/// <param name="OutMultidimensionalRaster">
		/// <para>Output Multidimensional Raster</para>
		/// <para>The output Cloud Raster Format (CRF) multidimensional raster dataset.</para>
		/// </param>
		public PredictUsingTrendRaster(object InMultidimensionalRaster, object OutMultidimensionalRaster)
		{
			this.InMultidimensionalRaster = InMultidimensionalRaster;
			this.OutMultidimensionalRaster = OutMultidimensionalRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Predict Using Trend Raster</para>
		/// </summary>
		public override string DisplayName() => "Predict Using Trend Raster";

		/// <summary>
		/// <para>Tool Name : PredictUsingTrendRaster</para>
		/// </summary>
		public override string ToolName() => "PredictUsingTrendRaster";

		/// <summary>
		/// <para>Tool Excute Name : ia.PredictUsingTrendRaster</para>
		/// </summary>
		public override string ExcuteName() => "ia.PredictUsingTrendRaster";

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
		public override object[] Parameters() => new object[] { InMultidimensionalRaster, OutMultidimensionalRaster, Variables, DimensionDef, DimensionValues, Start, End, IntervalValue, IntervalUnit };

		/// <summary>
		/// <para>Input Trend Raster</para>
		/// <para>The input multidimensional trend raster from the Generate Trend Raster tool.</para>
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
		/// <para>Variables [Dimension Info] (Description)</para>
		/// <para>The variable or variables that will be predicted in the analysis. If no variables are specified, all variables will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Variables { get; set; }

		/// <summary>
		/// <para>Dimension Definition</para>
		/// <para>Specifies the method used to provide prediction dimension values.</para>
		/// <para>By value—The prediction will be calculated for a single dimension value or a list of dimension values defined by the Values parameter (dimension_values in Python). This is the default.For example, you want to predict yearly precipitation for the years 2050, 2100, and 2150.</para>
		/// <para>By interval—The prediction will be calculated for an interval of the dimension defined by a start and an end value.For example, you want to predict yearly precipitation for every year between 2050 and 2150.</para>
		/// <para><see cref="DimensionDefEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DimensionDef { get; set; } = "BY_VALUE";

		/// <summary>
		/// <para>Values</para>
		/// <para>The dimension value or values to be used in the prediction.</para>
		/// <para>The format of the time, depth, and height values must match the format of the dimension values used to generate the trend raster. If the trend raster was generated for the StdTime dimension, the format would be YYYY-MM-DDTHH:MM:SS, for example 2050-01-01T00:00:00. Multiple values are separated with a semicolon.</para>
		/// <para>This parameter is required when the Dimension Definition parameter is set to By value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object DimensionValues { get; set; }

		/// <summary>
		/// <para>Start</para>
		/// <para>The start date, height, or depth of the dimension interval to be used in the prediction.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Start { get; set; }

		/// <summary>
		/// <para>End</para>
		/// <para>The end date, height, or depth of the dimension interval to be used in the prediction.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object End { get; set; }

		/// <summary>
		/// <para>Value Interval</para>
		/// <para>The number of steps between two dimension values to be included in the prediction. The default value is 1.</para>
		/// <para>For example, to predict temperature values every five years, use a value of 5.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object IntervalValue { get; set; }

		/// <summary>
		/// <para>Unit</para>
		/// <para>Specifies the unit that will be used for the interval value. This parameter only applies when the dimension of analysis is a time dimension.</para>
		/// <para>Hours—The prediction will be calculated for each hour in the range of time described by the Start, End, and Value Interval parameters.</para>
		/// <para>Days—The prediction will be calculated for each day in the range of time described by the Start, End, and Value Interval parameters.</para>
		/// <para>Weeks—The prediction will be calculated for each week in the range of time described by the Start, End, and Value Interval parameters.</para>
		/// <para>Months—The prediction will be calculated for each month in the range of time described by the Start, End, and Value Interval parameters.</para>
		/// <para>Years—The prediction will be calculated for each year in the range of time described by the Start, End, and Value Interval parameters.</para>
		/// <para><see cref="IntervalUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object IntervalUnit { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PredictUsingTrendRaster SetEnviroment(object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object nodata = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object pyramid = null , object rasterStatistics = null , object resamplingMethod = null , object scratchWorkspace = null , object snapRaster = null , double[] tileSize = null , object workspace = null )
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
			/// <para>By value—The prediction will be calculated for a single dimension value or a list of dimension values defined by the Values parameter (dimension_values in Python). This is the default.For example, you want to predict yearly precipitation for the years 2050, 2100, and 2150.</para>
			/// </summary>
			[GPValue("BY_VALUE")]
			[Description("By value")]
			By_value,

			/// <summary>
			/// <para>By interval—The prediction will be calculated for an interval of the dimension defined by a start and an end value.For example, you want to predict yearly precipitation for every year between 2050 and 2150.</para>
			/// </summary>
			[GPValue("BY_INTERVAL")]
			[Description("By interval")]
			By_interval,

		}

		/// <summary>
		/// <para>Unit</para>
		/// </summary>
		public enum IntervalUnitEnum 
		{
			/// <summary>
			/// <para>Hours—The prediction will be calculated for each hour in the range of time described by the Start, End, and Value Interval parameters.</para>
			/// </summary>
			[GPValue("HOURS")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para>Days—The prediction will be calculated for each day in the range of time described by the Start, End, and Value Interval parameters.</para>
			/// </summary>
			[GPValue("DAYS")]
			[Description("Days")]
			Days,

			/// <summary>
			/// <para>Weeks—The prediction will be calculated for each week in the range of time described by the Start, End, and Value Interval parameters.</para>
			/// </summary>
			[GPValue("WEEKS")]
			[Description("Weeks")]
			Weeks,

			/// <summary>
			/// <para>Months—The prediction will be calculated for each month in the range of time described by the Start, End, and Value Interval parameters.</para>
			/// </summary>
			[GPValue("MONTHS")]
			[Description("Months")]
			Months,

			/// <summary>
			/// <para>Years—The prediction will be calculated for each year in the range of time described by the Start, End, and Value Interval parameters.</para>
			/// </summary>
			[GPValue("YEARS")]
			[Description("Years")]
			Years,

		}

#endregion
	}
}
