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
	/// <para>Local Polynomial Interpolation</para>
	/// <para>Local Polynomial Interpolation</para>
	/// <para>Fits the specified order (zero, first, second, third, and so on) polynomial, each within specified overlapping neighborhoods, to produce an output surface.</para>
	/// </summary>
	public class LocalPolynomialInterpolation : AbstractGPProcess
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
		public LocalPolynomialInterpolation(object InFeatures, object ZField)
		{
			this.InFeatures = InFeatures;
			this.ZField = ZField;
		}

		/// <summary>
		/// <para>Tool Display Name : Local Polynomial Interpolation</para>
		/// </summary>
		public override string DisplayName() => "Local Polynomial Interpolation";

		/// <summary>
		/// <para>Tool Name : LocalPolynomialInterpolation</para>
		/// </summary>
		public override string ToolName() => "LocalPolynomialInterpolation";

		/// <summary>
		/// <para>Tool Excute Name : ga.LocalPolynomialInterpolation</para>
		/// </summary>
		public override string ExcuteName() => "ga.LocalPolynomialInterpolation";

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
		public override object[] Parameters() => new object[] { InFeatures, ZField, OutGaLayer, OutRaster, CellSize, Power, SearchNeighborhood, KernelFunction, Bandwidth, UseConditionNumber, ConditionNumber, WeightField, OutputType };

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
		/// <para>Order of polynomial</para>
		/// <para>The order of the polynomial.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 10)]
		public object Power { get; set; } = "1";

		/// <summary>
		/// <para>Search neighborhood</para>
		/// <para>Defines which surrounding points will be used to control the output. Standard is the default.</para>
		/// <para>Standard</para>
		/// <para>Major semiaxis—The major semiaxis value of the searching neighborhood.</para>
		/// <para>Minor semiaxis—The minor semiaxis value of the searching neighborhood.</para>
		/// <para>Angle—The angle of rotation for the axis (circle) or semimajor axis (ellipse) of the moving window.</para>
		/// <para>Max neighbors—The maximum number of neighbors that will be used to estimate the value at the unknown location.</para>
		/// <para>Min neighbors—The minimum number of neighbors that will be used to estimate the value at the unknown location.</para>
		/// <para>Sector Type—The geometry of the neighborhood.</para>
		/// <para>One sector—Single ellipse.</para>
		/// <para>Four sectors—Ellipse divided into four sectors.</para>
		/// <para>Four sectors shifted—Ellipse divided into four sectors and shifted 45 degrees.</para>
		/// <para>Eight sectors—Ellipse divided into eight sectors.</para>
		/// <para>Smooth</para>
		/// <para>Major semiaxis—The major semiaxis value of the searching neighborhood.</para>
		/// <para>Minor semiaxis—The minor semiaxis value of the searching neighborhood.</para>
		/// <para>Angle—The angle of rotation for the axis (circle) or semimajor axis (ellipse) of the moving window.</para>
		/// <para>Smoothing factor—The Smooth Interpolation option creates an outer ellipse and an inner ellipse at a distance equal to the Major Semiaxis multiplied by the Smoothing factor. The points that fall outside the smallest ellipse but inside the largest ellipse are weighted using a sigmoidal function with a value between zero and one.</para>
		/// <para>Standard Circular</para>
		/// <para>Radius—The length of the radius of the search circle.</para>
		/// <para>Angle—The angle of rotation for the axis (circle) or semimajor axis (ellipse) of the moving window.</para>
		/// <para>Max neighbors—The maximum number of neighbors that will be used to estimate the value at the unknown location.</para>
		/// <para>Min neighbors—The minimum number of neighbors that will be used to estimate the value at the unknown location.</para>
		/// <para>Sector Type—The geometry of the neighborhood.</para>
		/// <para>One sector—Single ellipse.</para>
		/// <para>Four sectors—Ellipse divided into four sectors.</para>
		/// <para>Four sectors shifted—Ellipse divided into four sectors and shifted 45 degrees.</para>
		/// <para>Eight sectors—Ellipse divided into eight sectors.</para>
		/// <para>Smooth Circular</para>
		/// <para>Radius—The length of the radius of the search circle.</para>
		/// <para>Smoothing factor—The Smooth Interpolation option creates an outer ellipse and an inner ellipse at a distance equal to the Major Semiaxis multiplied by the Smoothing factor. The points that fall outside the smallest ellipse but inside the largest ellipse are weighted using a sigmoidal function with a value between zero and one.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPGASearchNeighborhood()]
		[GPGASearchNeighborhoodDomain()]
		[NeighbourType("Standard", "Smooth", "StandardCircular", "SmoothCircular")]
		public object SearchNeighborhood { get; set; } = "NBRTYPE=Standard S_MAJOR=nan S_MINOR=nan ANGLE=0 NBR_MAX=15 NBR_MIN=10 SECTOR_TYPE=ONE_SECTOR";

		/// <summary>
		/// <para>Kernel function</para>
		/// <para>The kernel function used in the simulation.</para>
		/// <para>Exponential—The function grows or decays proportionally.</para>
		/// <para>Gaussian—Bell-shaped function that falls off quickly toward plus or minus infinity.</para>
		/// <para>Quartic—Fourth-order polynomial function.</para>
		/// <para>Epanechnikov—A discontinuous parabolic function.</para>
		/// <para>Fifth-order polynomial—Fifth-order polynomial function.</para>
		/// <para>Constant—An indicator function.</para>
		/// <para><see cref="KernelFunctionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object KernelFunction { get; set; } = "EXPONENTIAL";

		/// <summary>
		/// <para>Bandwidth</para>
		/// <para>Used to specify the maximum distance at which data points are used for prediction. With increasing bandwidth, prediction bias increases and prediction variance decreases.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 1.7976931348623157e+308)]
		public object Bandwidth { get; set; }

		/// <summary>
		/// <para>Use spatial condition number threshold</para>
		/// <para>Option to control the creation of prediction and prediction standard errors where the predictions are unstable. This option is only available for polynomials of order 1, 2, and 3.</para>
		/// <para>Unchecked—Predictions will be created everywhere, including areas where the predictions are unstable. This is the default.</para>
		/// <para>Checked—Prediction and prediction standard errors will not be created where the predictions are unstable.</para>
		/// <para><see cref="UseConditionNumberEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UseConditionNumber { get; set; } = "false";

		/// <summary>
		/// <para>Spatial condition number threshold</para>
		/// <para>Every invertible square matrix has a condition number that indicates how inaccurate the solution to the linear equations can be with a small change in the matrix coefficients (it can be due to imprecise data). If the condition number is large, a small change in the matrix coefficients results in a large change in the solution vector.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1.01, Max = 10000)]
		public object ConditionNumber { get; set; }

		/// <summary>
		/// <para>Weight field</para>
		/// <para>Used to emphasize an observation. The larger the weight, the more impact it has on the prediction. For coincident observations, assign the largest weight to the most reliable measurement.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object WeightField { get; set; }

		/// <summary>
		/// <para>Output surface type</para>
		/// <para>Surface type to store the interpolation results.</para>
		/// <para>Prediction—Prediction surfaces are produced from the interpolated values.</para>
		/// <para>Standard error of prediction— Standard Error surfaces are produced from the standard errors of the interpolated values.</para>
		/// <para>Condition number—The Spatial condition number surface indicates the stability of calculations at a particular location. The larger the condition number, the more unstable the prediction, so locations with large condition numbers may be prone to artifacts and erratic predicted values.</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutputType { get; set; } = "PREDICTION";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LocalPolynomialInterpolation SetEnviroment(object cellSize = null, object coincidentPoints = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object snapRaster = null, object workspace = null)
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
			/// <para>Exponential—The function grows or decays proportionally.</para>
			/// </summary>
			[GPValue("EXPONENTIAL")]
			[Description("Exponential")]
			Exponential,

			/// <summary>
			/// <para>Gaussian—Bell-shaped function that falls off quickly toward plus or minus infinity.</para>
			/// </summary>
			[GPValue("GAUSSIAN")]
			[Description("Gaussian")]
			Gaussian,

			/// <summary>
			/// <para>Quartic—Fourth-order polynomial function.</para>
			/// </summary>
			[GPValue("QUARTIC")]
			[Description("Quartic")]
			Quartic,

			/// <summary>
			/// <para>Epanechnikov—A discontinuous parabolic function.</para>
			/// </summary>
			[GPValue("EPANECHNIKOV")]
			[Description("Epanechnikov")]
			Epanechnikov,

			/// <summary>
			/// <para>Fifth-order polynomial—Fifth-order polynomial function.</para>
			/// </summary>
			[GPValue("POLYNOMIAL5")]
			[Description("Fifth-order polynomial")]
			POLYNOMIAL5,

			/// <summary>
			/// <para>Constant—An indicator function.</para>
			/// </summary>
			[GPValue("CONSTANT")]
			[Description("Constant")]
			Constant,

		}

		/// <summary>
		/// <para>Use spatial condition number threshold</para>
		/// </summary>
		public enum UseConditionNumberEnum 
		{
			/// <summary>
			/// <para>Checked—Prediction and prediction standard errors will not be created where the predictions are unstable.</para>
			/// </summary>
			[GPValue("true")]
			[Description("USE_CONDITION_NUMBER")]
			USE_CONDITION_NUMBER,

			/// <summary>
			/// <para>Unchecked—Predictions will be created everywhere, including areas where the predictions are unstable. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_USE_CONDITION_NUMBER")]
			NO_USE_CONDITION_NUMBER,

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

			/// <summary>
			/// <para>Condition number—The Spatial condition number surface indicates the stability of calculations at a particular location. The larger the condition number, the more unstable the prediction, so locations with large condition numbers may be prone to artifacts and erratic predicted values.</para>
			/// </summary>
			[GPValue("CONDITION_NUMBER")]
			[Description("Condition number")]
			Condition_number,

		}

#endregion
	}
}
