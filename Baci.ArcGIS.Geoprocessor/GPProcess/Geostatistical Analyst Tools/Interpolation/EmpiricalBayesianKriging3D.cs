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
	/// <para>Empirical Bayesian Kriging 3D</para>
	/// <para>Empirical Bayesian Kriging 3D</para>
	/// <para>Empirical Bayesian kriging 3D is a geostatistical interpolation method that uses Empirical Bayesian Kriging to interpolate 3D point data. All points must have x-, y-, and z-coordinates and a measured value to be interpolated. The output is a 3D geostatistical layer that calculates and renders itself as a 2D transect at a given elevation. The elevation of the layer can be changed with the range slider, and the layer will update to show the interpolated predictions for the new elevation.</para>
	/// </summary>
	public class EmpiricalBayesianKriging3D : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input features</para>
		/// <para>The input point features containing the field that will be interpolated.</para>
		/// </param>
		/// <param name="ElevationField">
		/// <para>Elevation field</para>
		/// <para>The Input features field containing the elevation value of each input point.</para>
		/// <para>If the elevation values are stored as geometry attributes in Shape.Z, it is recommended that you use that field. If the elevation values are stored in an attribute field, the elevation values must indicate distance from sea level. Positive values indicate distance above sea level, and negative values indicate distance below sea level.</para>
		/// </param>
		/// <param name="ValueField">
		/// <para>Value field</para>
		/// <para>The Input features field containing the measured values that will be interpolated.</para>
		/// </param>
		/// <param name="OutGaLayer">
		/// <para>Output geostatistical layer</para>
		/// <para>The output geostatistical layer that will display the interpolation result.</para>
		/// </param>
		public EmpiricalBayesianKriging3D(object InFeatures, object ElevationField, object ValueField, object OutGaLayer)
		{
			this.InFeatures = InFeatures;
			this.ElevationField = ElevationField;
			this.ValueField = ValueField;
			this.OutGaLayer = OutGaLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Empirical Bayesian Kriging 3D</para>
		/// </summary>
		public override string DisplayName() => "Empirical Bayesian Kriging 3D";

		/// <summary>
		/// <para>Tool Name : EmpiricalBayesianKriging3D</para>
		/// </summary>
		public override string ToolName() => "EmpiricalBayesianKriging3D";

		/// <summary>
		/// <para>Tool Excute Name : ga.EmpiricalBayesianKriging3D</para>
		/// </summary>
		public override string ExcuteName() => "ga.EmpiricalBayesianKriging3D";

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
		public override string[] ValidEnvironments() => new string[] { "coincidentPoints", "extent", "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, ElevationField, ValueField, OutGaLayer, ElevationUnits!, MeasurementErrorField!, SemivariogramModelType!, TransformationType!, SubsetSize!, OverlapFactor!, NumberSimulations!, TrendRemoval!, ElevInflationFactor!, SearchNeighborhood!, OutputElevation!, OutputType!, QuantileValue!, ThresholdType!, ProbabilityThreshold! };

		/// <summary>
		/// <para>Input features</para>
		/// <para>The input point features containing the field that will be interpolated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Elevation field</para>
		/// <para>The Input features field containing the elevation value of each input point.</para>
		/// <para>If the elevation values are stored as geometry attributes in Shape.Z, it is recommended that you use that field. If the elevation values are stored in an attribute field, the elevation values must indicate distance from sea level. Positive values indicate distance above sea level, and negative values indicate distance below sea level.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ElevationField { get; set; }

		/// <summary>
		/// <para>Value field</para>
		/// <para>The Input features field containing the measured values that will be interpolated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ValueField { get; set; }

		/// <summary>
		/// <para>Output geostatistical layer</para>
		/// <para>The output geostatistical layer that will display the interpolation result.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGALayer()]
		public object OutGaLayer { get; set; }

		/// <summary>
		/// <para>Elevation field units</para>
		/// <para>The units of the Elevation field.</para>
		/// <para>If Shape.Z is provided as the elevation field, the units will automatically match the z-units of the vertical coordinate system.</para>
		/// <para>US Survey Inches—Elevations are in U.S. survey inches.</para>
		/// <para>US Survey Feet—Elevations are in U.S. survey feet.</para>
		/// <para>US Survey Yards—Elevations are in U.S. survey yards.</para>
		/// <para>US Survey Miles—Elevations are in U.S. survey miles.</para>
		/// <para>US Survey Nautical Miles—Elevations are in U.S. survey nautical miles.</para>
		/// <para>Millimeters—Elevations are in millimeters.</para>
		/// <para>Centimeters—Elevations are in centimeters.</para>
		/// <para>Decimeters—Elevations are in decimeters.</para>
		/// <para>Meters—Elevations are in meters.</para>
		/// <para>Kilometers—Elevations are in kilometers.</para>
		/// <para>International Inches—Elevations are in international inches.</para>
		/// <para>International Feet—Elevations are in international feet.</para>
		/// <para>International Yards—Elevations are in international yards.</para>
		/// <para>Statute Miles—Elevations are in statute miles.</para>
		/// <para>International Nautical Miles—Elevations are in international nautical miles.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ElevationUnits { get; set; } = "METER";

		/// <summary>
		/// <para>Measurement error field</para>
		/// <para>Specifies the measurement error for each point in the input features. For each point, the value of this field should correspond to one standard deviation of the measured value of the point. Use this field if the measurement error values are not the same at each point.</para>
		/// <para>A common source of nonconstant measurement error is when the data is measured with different devices. One device may be more precise than another, which means that it will have a smaller measurement error. For example, a thermometer rounds to the nearest degree and another thermometer rounds to the nearest tenth of a degree. The variability of measurements is often provided by the manufacturer of the measuring device, or it may be known from empirical practice.</para>
		/// <para>Leave this parameter empty if there are no measurement error values or the measurement error values are unknown.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? MeasurementErrorField { get; set; }

		/// <summary>
		/// <para>Semivariogram model type</para>
		/// <para>The semivariogram model that will be used for the interpolation.</para>
		/// <para>Power—Power semivariogram</para>
		/// <para>Linear—Linear semivariogram</para>
		/// <para>Thin Plate Spline—Thin plate spline semivariogram</para>
		/// <para>Exponential—Exponential semivariogram</para>
		/// <para>Whittle—Whittle semivariogram</para>
		/// <para>K-Bessel—K-Bessel semivariogram</para>
		/// <para><see cref="SemivariogramModelTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Model Parameters")]
		public object? SemivariogramModelType { get; set; } = "POWER";

		/// <summary>
		/// <para>Transformation type</para>
		/// <para>The type of transformation to be applied to the input features.</para>
		/// <para>None—Do not apply any transformation. This is the default.</para>
		/// <para>Empirical—Multiplicative Skewing transformation with Empirical base function is applied.</para>
		/// <para>Log empirical—Multiplicative Skewing transformation with Log Empirical base function is applied. All data values must be positive. If this option is chosen, all predictions will be positive.</para>
		/// <para><see cref="TransformationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Model Parameters")]
		public object? TransformationType { get; set; } = "NONE";

		/// <summary>
		/// <para>Subset size</para>
		/// <para>The size of the subset. The input data will automatically be divided into subsets before processing. This parameter controls the number of points that will be in each subset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 20, Max = 1000)]
		[Category("Advanced Model Parameters")]
		public object? SubsetSize { get; set; } = "100";

		/// <summary>
		/// <para>Local model area overlap factor</para>
		/// <para>A factor representing the degree of overlap between local models (also called subsets).</para>
		/// <para>Each input point can fall into several subsets, and the overlap factor specifies the average number of subsets into which each point will fall. A high value of the overlap factor produces a smoother output surface, but it also increases processing time. Values must be between 1 and 5. The actual overlap that will be used will usually be larger than this value, so each subset will contain the same number of points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1, Max = 5)]
		[Category("Advanced Model Parameters")]
		public object? OverlapFactor { get; set; } = "1";

		/// <summary>
		/// <para>Number of simulated semivariograms</para>
		/// <para>The number of simulated semivariograms of each local model.</para>
		/// <para>Using more simulations will make the model calculations more stable, but the model will take longer to calculate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 30, Max = 10000)]
		[Category("Advanced Model Parameters")]
		public object? NumberSimulations { get; set; } = "100";

		/// <summary>
		/// <para>Order of trend removal</para>
		/// <para>The order of trend removal in the vertical direction.</para>
		/// <para>For most data in three dimensions, the values of the points change faster vertically than they do horizontally. Removing trend in the vertical direction will help alleviate this and stabilize calculations.</para>
		/// <para>None—Do not remove trend. This is the default.</para>
		/// <para>First order—Remove first order vertical trend.</para>
		/// <para><see cref="TrendRemovalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Advanced Model Parameters")]
		public object? TrendRemoval { get; set; } = "NONE";

		/// <summary>
		/// <para>Elevation inflation factor</para>
		/// <para>A constant value that is multiplied by the Elevation field value prior to subsetting and model estimation. For most data in three dimensions, the values of the points change faster vertically than they do horizontally, and this factor stretches the locations of the points such that one unit of distance vertically is statistically equivalent to one unit of distance horizontally. The locations of the points will be moved back to their original locations before returning the result of the interpolation. This correction is needed to accurately estimate the semivariogram model and for the Search neighborhood to use the correct neighbors. The elevation inflation factor is unitless and will provide the same results regardless of the units of the x-, y-, or z-coordinate of the input points.</para>
		/// <para>If no value is provided for this parameter, one will be calculated at run time using maximum likelihood estimation. The value will be printed as a geoprocessing message. The value calculated at run time will be between 1 and 1000. However, you can type values between 0.01 and 1,000,000. If the calculated value is equal to 1 or 1000, you can provide values outside that range and choose a value based on cross validation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0.01, Max = 1000000)]
		[Category("Advanced Model Parameters")]
		public object? ElevInflationFactor { get; set; }

		/// <summary>
		/// <para>Search neighborhood</para>
		/// <para>Specifies the number and orientation of the neighbors that will be used to predict values at new locations.</para>
		/// <para>Standard3D</para>
		/// <para>Max neighbors—The maximum number of neighbors per sector that will be used to estimate the value at the unknown location.</para>
		/// <para>Min neighbors—The minimum number of neighbors per sector that will be used to estimate the value at the unknown location.</para>
		/// <para>Sector type—The geometry of the 3D neighborhood. Sectors are used to ensure that neighbors are used in every direction around the prediction location. All sector types are formed from the Platonic solids.</para>
		/// <para>1 Sector (Sphere)—The closest neighbors from any direction will be used.</para>
		/// <para>4 Sector (Tetrahedron)—Divides space into four regions, and neighbors will be used in each of the four regions.</para>
		/// <para>6 Sector (Cube)—Divides space into six regions, and neighbors will be used in each of the six regions.</para>
		/// <para>8 Sector (Octahedron)—Divides space into eight regions, and neighbors will be used in each of the eight regions.</para>
		/// <para>12 Sector (Dodecahedron)—Divides space into twelve regions, and neighbors will be used in each of the twelve regions.</para>
		/// <para>20 Sector (Icosahedron)—Divides space into twenty regions, and neighbors will be used in each of the twenty regions.</para>
		/// <para>Radius—The length of the radius of the search neighborhood.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPGASearchNeighborhood()]
		[GPGASearchNeighborhoodDomain()]
		[NeighbourType("NeighbourTypeStandard3D")]
		[Category("Search Neighborhood Parameters")]
		public object? SearchNeighborhood { get; set; } = "NBRTYPE=Standard3D RADIUS=nan NBR_MAX=2 NBR_MIN=1 SECTOR_TYPE=TWELVE_SECTORS";

		/// <summary>
		/// <para>Default output elevation</para>
		/// <para>The default elevation of the Output geostatistical layer.</para>
		/// <para>The geostatistical layer will always draw as a horizontal surface at a given elevation, and this parameter specifies this elevation. After it&apos;s created, the elevation of the geostatistical layer can be changed using the range slider.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = -1.7976931348623157e+308, Max = 1.7976931348623157e+308)]
		[Category("Output Parameters")]
		public object? OutputElevation { get; set; }

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
		/// <para>The quantile value for which the output layer will be generated.</para>
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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EmpiricalBayesianKriging3D SetEnviroment(object? coincidentPoints = null, object? extent = null, object? parallelProcessingFactor = null)
		{
			base.SetEnv(coincidentPoints: coincidentPoints, extent: extent, parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

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
			/// <para>Thin Plate Spline—Thin plate spline semivariogram</para>
			/// </summary>
			[GPValue("THIN_PLATE_SPLINE")]
			[Description("Thin Plate Spline")]
			Thin_Plate_Spline,

			/// <summary>
			/// <para>Exponential—Exponential semivariogram</para>
			/// </summary>
			[GPValue("EXPONENTIAL")]
			[Description("Exponential")]
			Exponential,

			/// <summary>
			/// <para>Whittle—Whittle semivariogram</para>
			/// </summary>
			[GPValue("WHITTLE")]
			[Description("Whittle")]
			Whittle,

			/// <summary>
			/// <para>K-Bessel—K-Bessel semivariogram</para>
			/// </summary>
			[GPValue("K_BESSEL")]
			[Description("K-Bessel")]
			K_BESSEL,

		}

		/// <summary>
		/// <para>Transformation type</para>
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
			/// <para>Empirical—Multiplicative Skewing transformation with Empirical base function is applied.</para>
			/// </summary>
			[GPValue("EMPIRICAL")]
			[Description("Empirical")]
			Empirical,

			/// <summary>
			/// <para>Log empirical—Multiplicative Skewing transformation with Log Empirical base function is applied. All data values must be positive. If this option is chosen, all predictions will be positive.</para>
			/// </summary>
			[GPValue("LOGEMPIRICAL")]
			[Description("Log empirical")]
			Log_empirical,

		}

		/// <summary>
		/// <para>Order of trend removal</para>
		/// </summary>
		public enum TrendRemovalEnum 
		{
			/// <summary>
			/// <para>None—Do not remove trend. This is the default.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>First order—Remove first order vertical trend.</para>
			/// </summary>
			[GPValue("FIRST")]
			[Description("First order")]
			First_order,

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
			/// <para>Probability—Probability surface of values exceeding or not exceeding a certain threshold.</para>
			/// </summary>
			[GPValue("PROBABILITY")]
			[Description("Probability")]
			Probability,

			/// <summary>
			/// <para>Quantile—Quantile surface predicting the specified quantile of the prediction distribution.</para>
			/// </summary>
			[GPValue("QUANTILE")]
			[Description("Quantile")]
			Quantile,

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

#endregion
	}
}
