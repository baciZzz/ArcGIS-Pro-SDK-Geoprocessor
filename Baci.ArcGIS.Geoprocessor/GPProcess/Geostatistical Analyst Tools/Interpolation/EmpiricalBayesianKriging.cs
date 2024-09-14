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
	/// <para>Empirical Bayesian Kriging</para>
	/// <para>Empirical Bayesian Kriging</para>
	/// <para>Empirical Bayesian kriging is an interpolation method that accounts for the error in estimating the underlying semivariogram through repeated simulations.</para>
	/// </summary>
	public class EmpiricalBayesianKriging : AbstractGPProcess
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
		public EmpiricalBayesianKriging(object InFeatures, object ZField)
		{
			this.InFeatures = InFeatures;
			this.ZField = ZField;
		}

		/// <summary>
		/// <para>Tool Display Name : Empirical Bayesian Kriging</para>
		/// </summary>
		public override string DisplayName() => "Empirical Bayesian Kriging";

		/// <summary>
		/// <para>Tool Name : EmpiricalBayesianKriging</para>
		/// </summary>
		public override string ToolName() => "EmpiricalBayesianKriging";

		/// <summary>
		/// <para>Tool Excute Name : ga.EmpiricalBayesianKriging</para>
		/// </summary>
		public override string ExcuteName() => "ga.EmpiricalBayesianKriging";

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
		public override object[] Parameters() => new object[] { InFeatures, ZField, OutGaLayer!, OutRaster!, CellSize!, TransformationType!, MaxLocalPoints!, OverlapFactor!, NumberSemivariograms!, SearchNeighborhood!, OutputType!, QuantileValue!, ThresholdType!, ProbabilityThreshold!, SemivariogramModelType! };

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
		public object? OutGaLayer { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster. This raster is required output only if no output geostatistical layer is requested.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object? OutRaster { get; set; }

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
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Data transformation type</para>
		/// <para>Type of transformation to be applied to the input data.</para>
		/// <para>None—Do not apply any transformation. This is the default.</para>
		/// <para>Empirical—Multiplicative Skewing transformation with Empirical base function.</para>
		/// <para>Log empirical—Multiplicative Skewing transformation with Log Empirical base function. All data values must be positive. If this option is chosen, all predictions will be positive.</para>
		/// <para><see cref="TransformationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TransformationType { get; set; } = "NONE";

		/// <summary>
		/// <para>Maximum number of points in each local model</para>
		/// <para>The input data will automatically be divided into groups that do not have more than this number of points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 20, Max = 1000)]
		[Category("Additional Model Parameters")]
		public object? MaxLocalPoints { get; set; } = "100";

		/// <summary>
		/// <para>Local model area overlap factor</para>
		/// <para>A factor representing the degree of overlap between local models (also called subsets). Each input point can fall into several subsets, and the overlap factor specifies the average number of subsets that each point will fall into. A high value of the overlap factor makes the output surface smoother, but it also increases processing time. Typical values vary between 0.01 and 5.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0.01, Max = 5)]
		[Category("Additional Model Parameters")]
		public object? OverlapFactor { get; set; } = "1";

		/// <summary>
		/// <para>Number of simulated semivariograms</para>
		/// <para>The number of simulated semivariograms of each local model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 30, Max = 10000)]
		[Category("Additional Model Parameters")]
		public object? NumberSemivariograms { get; set; } = "100";

		/// <summary>
		/// <para>Search neighborhood</para>
		/// <para>Defines which surrounding points will be used to control the output. Standard Circular is the default.</para>
		/// <para>Standard Circular</para>
		/// <para>Max neighbors—The maximum number of neighbors that will be used to estimate the value at the unknown location.</para>
		/// <para>Min neighbors—The minimum number of neighbors that will be used to estimate the value at the unknown location.</para>
		/// <para>Sector Type—The geometry of the neighborhood.</para>
		/// <para>One sector—Single ellipse.</para>
		/// <para>Four sectors—Ellipse divided into four sectors.</para>
		/// <para>Four sectors shifted—Ellipse divided into four sectors and shifted 45 degrees.</para>
		/// <para>Eight sectors—Ellipse divided into eight sectors.</para>
		/// <para>Angle—The angle of rotation for the axis (circle) or semimajor axis (ellipse) of the moving window.</para>
		/// <para>Radius—The length of the radius of the search circle.</para>
		/// <para>Smooth Circular</para>
		/// <para>Smoothing factor—The Smooth Interpolation option creates an outer ellipse and an inner ellipse at a distance equal to the Major Semiaxis multiplied by the Smoothing factor. The points that fall outside the smallest ellipse but inside the largest ellipse are weighted using a sigmoidal function with a value between zero and one.</para>
		/// <para>Radius—The length of the radius of the search circle.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPGASearchNeighborhood()]
		[GPGASearchNeighborhoodDomain(ChordalDistance = true)]
		[NeighbourType("StandardCircular", "SmoothCircular")]
		[Category("Search Neighborhood Parameters")]
		public object? SearchNeighborhood { get; set; } = "NBRTYPE=StandardCircular RADIUS=nan ANGLE=0 NBR_MAX=15 NBR_MIN=10 SECTOR_TYPE=ONE_SECTOR";

		/// <summary>
		/// <para>Output surface type</para>
		/// <para>Surface type to store the interpolation results.</para>
		/// <para>Prediction—Prediction surfaces are produced from the interpolated values.</para>
		/// <para>Standard error of prediction— Standard Error surfaces are produced from the standard errors of the interpolated values.</para>
		/// <para>Probability—Probability surface of values exceeding or not exceeding a certain threshold.</para>
		/// <para>Quantile—Quantile surface predicting the specified quantile of the prediction distribution.</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Parameters")]
		public object? OutputType { get; set; } = "PREDICTION";

		/// <summary>
		/// <para>Quantile value</para>
		/// <para>The quantile value for which the output raster will be generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1e-10, Max = 0.99999999989999999)]
		[Category("Output Parameters")]
		public object? QuantileValue { get; set; } = "0.5";

		/// <summary>
		/// <para>Probability threshold type</para>
		/// <para>Specifies whether to calculate the probability of exceeding or not exceeding the specified threshold.</para>
		/// <para>Exceed—Probability values exceed the threshold. This is the default.</para>
		/// <para>Not exceed—Probability values will not exceed the threshold.</para>
		/// <para><see cref="ThresholdTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Parameters")]
		public object? ThresholdType { get; set; } = "EXCEED";

		/// <summary>
		/// <para>Probability threshold</para>
		/// <para>The probability threshold value. If left empty, the median (50th quantile) of the input data will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Output Parameters")]
		public object? ProbabilityThreshold { get; set; }

		/// <summary>
		/// <para>Semivariogram model type</para>
		/// <para>The semivariogram model that will be used for the interpolation.</para>
		/// <para>Power—Power semivariogram</para>
		/// <para>Linear—Linear semivariogram</para>
		/// <para>Thin plate spline—Thin Plate Spline semivariogram</para>
		/// <para>Exponential—Exponential semivariogram</para>
		/// <para>Exponential detrended—Exponential semivariogram with first order trend removal</para>
		/// <para>Whittle—Whittle semivariogram</para>
		/// <para>Whittle detrended—Whittle semivariogram with first order trend removal</para>
		/// <para>K-Bessel—K-Bessel semivariogram</para>
		/// <para>K-Bessel detrended—K-Bessel semivariogram with first order trend removal</para>
		/// <para>The available choices depend on the value of the Data transformation type parameter.</para>
		/// <para>If the transformation type is set to None, only the first three semivariograms are available. If the type is Empirical or Log empirical, the last six semivariograms are available.</para>
		/// <para>For more information about choosing an appropriate semivariogram for your data, see the topic What is Empirical Bayesian Kriging.</para>
		/// <para><see cref="SemivariogramModelTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SemivariogramModelType { get; set; } = "POWER";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EmpiricalBayesianKriging SetEnviroment(object? cellSize = null, object? coincidentPoints = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? snapRaster = null, object? workspace = null)
		{
			base.SetEnv(cellSize: cellSize, coincidentPoints: coincidentPoints, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Data transformation type</para>
		/// </summary>
		public enum TransformationTypeEnum 
		{
			/// <summary>
			/// <para>None—Do not apply any transformation. This is the default.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>Empirical—Multiplicative Skewing transformation with Empirical base function.</para>
			/// </summary>
			[GPValue("EMPIRICAL")]
			[Description("Empirical")]
			Empirical,

			/// <summary>
			/// <para>Log empirical—Multiplicative Skewing transformation with Log Empirical base function. All data values must be positive. If this option is chosen, all predictions will be positive.</para>
			/// </summary>
			[GPValue("LOGEMPIRICAL")]
			[Description("Log empirical")]
			Log_empirical,

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
			/// <para>Quantile—Quantile surface predicting the specified quantile of the prediction distribution.</para>
			/// </summary>
			[GPValue("QUANTILE")]
			[Description("Quantile")]
			Quantile,

			/// <summary>
			/// <para>Probability—Probability surface of values exceeding or not exceeding a certain threshold.</para>
			/// </summary>
			[GPValue("PROBABILITY")]
			[Description("Probability")]
			Probability,

			/// <summary>
			/// <para>Standard error of prediction— Standard Error surfaces are produced from the standard errors of the interpolated values.</para>
			/// </summary>
			[GPValue("PREDICTION_STANDARD_ERROR")]
			[Description("Standard error of prediction")]
			Standard_error_of_prediction,

		}

		/// <summary>
		/// <para>Probability threshold type</para>
		/// </summary>
		public enum ThresholdTypeEnum 
		{
			/// <summary>
			/// <para>Exceed—Probability values exceed the threshold. This is the default.</para>
			/// </summary>
			[GPValue("EXCEED")]
			[Description("Exceed")]
			Exceed,

			/// <summary>
			/// <para>Not exceed—Probability values will not exceed the threshold.</para>
			/// </summary>
			[GPValue("NOT_EXCEED")]
			[Description("Not exceed")]
			Not_exceed,

		}

		/// <summary>
		/// <para>Semivariogram model type</para>
		/// </summary>
		public enum SemivariogramModelTypeEnum 
		{
			/// <summary>
			/// <para>Power—Power semivariogram</para>
			/// </summary>
			[GPValue("POWER")]
			[Description("Power")]
			Power,

			/// <summary>
			/// <para>Linear—Linear semivariogram</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("Linear")]
			Linear,

			/// <summary>
			/// <para>Thin plate spline—Thin Plate Spline semivariogram</para>
			/// </summary>
			[GPValue("THIN_PLATE_SPLINE")]
			[Description("Thin plate spline")]
			Thin_plate_spline,

			/// <summary>
			/// <para>Exponential—Exponential semivariogram</para>
			/// </summary>
			[GPValue("EXPONENTIAL")]
			[Description("Exponential")]
			Exponential,

			/// <summary>
			/// <para>Exponential detrended—Exponential semivariogram with first order trend removal</para>
			/// </summary>
			[GPValue("EXPONENTIAL_DETRENDED")]
			[Description("Exponential detrended")]
			Exponential_detrended,

			/// <summary>
			/// <para>Whittle—Whittle semivariogram</para>
			/// </summary>
			[GPValue("WHITTLE")]
			[Description("Whittle")]
			Whittle,

			/// <summary>
			/// <para>Whittle detrended—Whittle semivariogram with first order trend removal</para>
			/// </summary>
			[GPValue("WHITTLE_DETRENDED")]
			[Description("Whittle detrended")]
			Whittle_detrended,

			/// <summary>
			/// <para>K-Bessel—K-Bessel semivariogram</para>
			/// </summary>
			[GPValue("K_BESSEL")]
			[Description("K-Bessel")]
			K_BESSEL,

			/// <summary>
			/// <para>K-Bessel detrended—K-Bessel semivariogram with first order trend removal</para>
			/// </summary>
			[GPValue("K_BESSEL_DETRENDED")]
			[Description("K-Bessel detrended")]
			K_BESSEL_DETRENDED,

		}

#endregion
	}
}
