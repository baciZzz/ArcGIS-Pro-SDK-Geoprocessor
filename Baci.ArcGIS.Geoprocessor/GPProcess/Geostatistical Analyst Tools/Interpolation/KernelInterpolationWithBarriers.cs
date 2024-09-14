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
	/// <para>Kernel Interpolation With Barriers</para>
	/// <para>Kernel Interpolation With Barriers</para>
	/// <para>A moving window predictor that uses the shortest distance between points so that points on either side of the line barriers are connected.</para>
	/// </summary>
	public class KernelInterpolationWithBarriers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input features</para>
		/// <para>The input point features containing the z-values to be interpolated.</para>
		/// </param>
		/// <param name="ZField">
		/// <para>Z value field</para>
		/// <para>Field that holds a height or magnitude value for each point. This can be a numeric field or the Shape field if the input features contain z-values or m-values.</para>
		/// </param>
		public KernelInterpolationWithBarriers(object InFeatures, object ZField)
		{
			this.InFeatures = InFeatures;
			this.ZField = ZField;
		}

		/// <summary>
		/// <para>Tool Display Name : Kernel Interpolation With Barriers</para>
		/// </summary>
		public override string DisplayName() => "Kernel Interpolation With Barriers";

		/// <summary>
		/// <para>Tool Name : KernelInterpolationWithBarriers</para>
		/// </summary>
		public override string ToolName() => "KernelInterpolationWithBarriers";

		/// <summary>
		/// <para>Tool Excute Name : ga.KernelInterpolationWithBarriers</para>
		/// </summary>
		public override string ExcuteName() => "ga.KernelInterpolationWithBarriers";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "coincidentPoints", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, ZField, OutGaLayer, OutRaster, CellSize, InBarrierFeatures, KernelFunction, Bandwidth, Power, Ridge, OutputType };

		/// <summary>
		/// <para>Input features</para>
		/// <para>The input point features containing the z-values to be interpolated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Z value field</para>
		/// <para>Field that holds a height or magnitude value for each point. This can be a numeric field or the Shape field if the input features contain z-values or m-values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ZField { get; set; }

		/// <summary>
		/// <para>Output geostatistical layer</para>
		/// <para>The geostatistical layer produced. This layer is required output only if no output raster is requested.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPGALayer()]
		public object OutGaLayer { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster. This raster is required output only if no output geostatistical layer is requested.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>The cell size at which the output raster will be created.</para>
		/// <para>This value can be explicitly set in the Environments by the Cell Size parameter.</para>
		/// <para>If not set, it is the shorter of the width or the height of the extent of the input point features, in the input spatial reference, divided by 250.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Input absolute barrier features</para>
		/// <para>Absolute barrier features using non-Euclidean distances rather than line-of-sight distances.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline")]
		public object InBarrierFeatures { get; set; }

		/// <summary>
		/// <para>Kernel function</para>
		/// <para>The kernel function used in the simulation.</para>
		/// <para>Exponential— The function grows or decays proportionally.</para>
		/// <para>Gaussian— Bell-shaped function that falls off quickly toward plus/minus infinity.</para>
		/// <para>Quartic— Fourth-order polynomial function.</para>
		/// <para>Epanechnikov— A discontinuous parabolic function.</para>
		/// <para>Fifth order polynomial— Fifth-order polynomial function.</para>
		/// <para>Constant—An indicator function.</para>
		/// <para><see cref="KernelFunctionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object KernelFunction { get; set; } = "POLYNOMIAL5";

		/// <summary>
		/// <para>Bandwidth</para>
		/// <para>Used to specify the maximum distance at which data points are used for prediction. With increasing bandwidth, prediction bias increases and prediction variance decreases.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 1.7976931348623157e+308)]
		public object Bandwidth { get; set; }

		/// <summary>
		/// <para>Order of polynomial</para>
		/// <para>Sets the order of the polynomial.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 1)]
		public object Power { get; set; } = "1";

		/// <summary>
		/// <para>Ridge parameter</para>
		/// <para>Used for the numerical stabilization of the solution of the system of linear equations. It does not influence predictions in the case of regularly distributed data without barriers. Predictions for areas in which the data is located near the feature barrier or isolated by the barriers can be unstable and tend to require relatively large ridge parameter values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1, Max = 100)]
		public object Ridge { get; set; } = "50";

		/// <summary>
		/// <para>Output surface type</para>
		/// <para>Surface type to store the interpolation results.</para>
		/// <para>Prediction—Prediction surfaces are produced from the interpolated values.</para>
		/// <para>Standard error of prediction— Standard Error surfaces are produced from the standard errors of the interpolated values.</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutputType { get; set; } = "PREDICTION";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public KernelInterpolationWithBarriers SetEnviroment(object cellSize = null, object coincidentPoints = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object snapRaster = null, object workspace = null)
		{
			base.SetEnv(cellSize: cellSize, coincidentPoints: coincidentPoints, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Kernel function</para>
		/// </summary>
		public enum KernelFunctionEnum 
		{
			/// <summary>
			/// <para>Exponential— The function grows or decays proportionally.</para>
			/// </summary>
			[GPValue("EXPONENTIAL")]
			[Description("Exponential")]
			Exponential,

			/// <summary>
			/// <para>Gaussian— Bell-shaped function that falls off quickly toward plus/minus infinity.</para>
			/// </summary>
			[GPValue("GAUSSIAN")]
			[Description("Gaussian")]
			Gaussian,

			/// <summary>
			/// <para>Quartic— Fourth-order polynomial function.</para>
			/// </summary>
			[GPValue("QUARTIC")]
			[Description("Quartic")]
			Quartic,

			/// <summary>
			/// <para>Epanechnikov— A discontinuous parabolic function.</para>
			/// </summary>
			[GPValue("EPANECHNIKOV")]
			[Description("Epanechnikov")]
			Epanechnikov,

			/// <summary>
			/// <para>Fifth order polynomial— Fifth-order polynomial function.</para>
			/// </summary>
			[GPValue("POLYNOMIAL5")]
			[Description("Fifth order polynomial")]
			Fifth_order_polynomial,

			/// <summary>
			/// <para>Constant—An indicator function.</para>
			/// </summary>
			[GPValue("CONSTANT")]
			[Description("Constant")]
			Constant,

		}

		/// <summary>
		/// <para>Output surface type</para>
		/// </summary>
		public enum OutputTypeEnum 
		{
			/// <summary>
			/// <para>Prediction—Prediction surfaces are produced from the interpolated values.</para>
			/// </summary>
			[GPValue("PREDICTION")]
			[Description("Prediction")]
			Prediction,

			/// <summary>
			/// <para>Standard error of prediction— Standard Error surfaces are produced from the standard errors of the interpolated values.</para>
			/// </summary>
			[GPValue("PREDICTION_STANDARD_ERROR")]
			[Description("Standard error of prediction")]
			Standard_error_of_prediction,

		}

#endregion
	}
}
