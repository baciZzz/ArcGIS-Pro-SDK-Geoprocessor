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
	/// <para>EBK Regression Prediction</para>
	/// <para>EBK Regression Prediction</para>
	/// <para>EBK Regression Prediction is a geostatistical interpolation method that uses Empirical Bayesian Kriging with explanatory variable rasters that are known to affect the value of the data that you are interpolating. This approach combines kriging with regression analysis to make predictions that are more accurate than either regression or kriging can achieve on their own.</para>
	/// </summary>
	public class EBKRegressionPrediction : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input dependent variable features</para>
		/// <para>The input point features containing the field that will be interpolated.</para>
		/// </param>
		/// <param name="DependentField">
		/// <para>Dependent variable field</para>
		/// <para>The field of the Input dependent variable features containing the values of the dependent variable. This is the field that will be interpolated.</para>
		/// </param>
		/// <param name="InExplanatoryRasters">
		/// <para>Input explanatory variable rasters</para>
		/// <para>Input rasters representing the explanatory variables that will be used to build the regression model. These rasters should represent variables that are known to influence the values of the dependent variable. For example, when interpolating temperature data, an elevation raster should be used as an explanatory variable because temperature is influenced by elevation. You can use up to 62 explanatory rasters.</para>
		/// </param>
		/// <param name="OutGaLayer">
		/// <para>Output geostatistical layer</para>
		/// <para>The output geostatistical layer displaying the result of the interpolation.</para>
		/// </param>
		public EBKRegressionPrediction(object InFeatures, object DependentField, object InExplanatoryRasters, object OutGaLayer)
		{
			this.InFeatures = InFeatures;
			this.DependentField = DependentField;
			this.InExplanatoryRasters = InExplanatoryRasters;
			this.OutGaLayer = OutGaLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : EBK Regression Prediction</para>
		/// </summary>
		public override string DisplayName() => "EBK Regression Prediction";

		/// <summary>
		/// <para>Tool Name : EBKRegressionPrediction</para>
		/// </summary>
		public override string ToolName() => "EBKRegressionPrediction";

		/// <summary>
		/// <para>Tool Excute Name : ga.EBKRegressionPrediction</para>
		/// </summary>
		public override string ExcuteName() => "ga.EBKRegressionPrediction";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "coincidentPoints", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, DependentField, InExplanatoryRasters, OutGaLayer, OutRaster!, OutDiagnosticFeatureClass!, MeasurementErrorField!, MinCumulativeVariance!, InSubsetFeatures!, TransformationType!, SemivariogramModelType!, MaxLocalPoints!, OverlapFactor!, NumberSimulations!, SearchNeighborhood! };

		/// <summary>
		/// <para>Input dependent variable features</para>
		/// <para>The input point features containing the field that will be interpolated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Dependent variable field</para>
		/// <para>The field of the Input dependent variable features containing the values of the dependent variable. This is the field that will be interpolated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object DependentField { get; set; }

		/// <summary>
		/// <para>Input explanatory variable rasters</para>
		/// <para>Input rasters representing the explanatory variables that will be used to build the regression model. These rasters should represent variables that are known to influence the values of the dependent variable. For example, when interpolating temperature data, an elevation raster should be used as an explanatory variable because temperature is influenced by elevation. You can use up to 62 explanatory rasters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPSAGeoDataDomain(CheckField = true, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Geometry")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object InExplanatoryRasters { get; set; }

		/// <summary>
		/// <para>Output geostatistical layer</para>
		/// <para>The output geostatistical layer displaying the result of the interpolation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGALayer()]
		public object OutGaLayer { get; set; }

		/// <summary>
		/// <para>Output prediction raster</para>
		/// <para>The output raster displaying the result of the interpolation. The default cell size will be the maximum of the cell sizes of the Input explanatory variable rasters. To use a different cell size, use the cell size environmental setting.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object? OutRaster { get; set; }

		/// <summary>
		/// <para>Output diagnostic feature class</para>
		/// <para>Output polygon feature class that shows the regions of each local model and contains fields with diagnostic information for the local models. For each subset, a polygon will be created that surrounds the points in the subset so you can easily identify which points were used in each subset. For example, if there are 10 local models, there will be ten polygons in this output. The feature class will contain the following fields:</para>
		/// <para>Number of Principal Components (PrincComps)—The number of principal components that were used as explanatory variables. The value will always be less than or equal to the number of explanatory variable rasters.</para>
		/// <para>Percent of Variance (PercVar)—The percent of variance captured by the principal components. This value will be greater than or equal to the value specified in the Minimum cumulative percent of variance parameter below.</para>
		/// <para>Root Mean Square Error (RMSE)—The square root of the average squared cross-validation errors. The smaller this value, the better the model fits.</para>
		/// <para>Percent 90 Interval (Perc90)—The percent of data points that fall within a 90 percent cross-validation confidence interval. Ideally, this number should be close to 90. A value significantly smaller than 90 indicates that standard errors are being underestimated. A value significantly larger than 90 indicates that standard errors are being overestimated.</para>
		/// <para>Percent 95 Interval (Perc95)—The percent of data points that fall within a 95 percent cross-validation confidence interval. Ideally, this number should be close to 95. A value significantly smaller than 95 indicates that standard errors are being underestimated. A value significantly larger than 95 indicates that standard errors are being overestimated.</para>
		/// <para>Mean Absolute Error (MeanAbsErr)—The average of the absolute values of the cross-validation errors. This value should be as small as possible. It is similar to Root Mean Square Error, but it is less influenced by extreme values.</para>
		/// <para>Mean Error (MeanError)—The average of the cross-validation errors. This value should be close to zero. A value significantly different than zero indicates that the predictions are biased.</para>
		/// <para>Continuous Ranked Probability Score (CRPS)—The continuous ranked probability score is a diagnostic that measures the deviation from the predictive cumulative distribution function to each observed data value. This value should be as small as possible. This diagnostic has advantages over cross-validation diagnostics because it compares the data to a full distribution rather than to single-point predictions.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutDiagnosticFeatureClass { get; set; }

		/// <summary>
		/// <para>Dependent variable measurement error field</para>
		/// <para>A field that specifies the measurement error for each point in the dependent variable features. For each point, the value of this field should correspond to one standard deviation of the measured value of the point. Use this field if the measurement error values are not the same at each point.</para>
		/// <para>A common source of nonconstant measurement error is when the data is measured with different devices. One device might be more precise than another, which means that it will have a smaller measurement error. For example, one thermometer rounds to the nearest degree and another thermometer rounds to the nearest tenth of a degree. The variability of measurements is often provided by the manufacturer of the measuring device, or it may be known from empirical practice.</para>
		/// <para>Leave this parameter empty if there are no measurement error values or the measurement error values are unknown.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? MeasurementErrorField { get; set; }

		/// <summary>
		/// <para>Minimum cumulative percent of variance</para>
		/// <para>Defines the minimum cumulative percent of variance from the principal components of the explanatory variable rasters. Before building the regression model, the principal components of the explanatory variables are calculated, and these principal components are used as explanatory variables in the regression. Each principal component captures a certain percent of the variance of the explanatory variables, and this parameter controls the minimum percent of variance that must be captured by the principal components of each local model. For example, if a value of 75 is provided, the software will use the minimum number of principal components that are necessary to capture at least 75 percent of the variance of the explanatory variables.</para>
		/// <para>Principal components are all mutually uncorrelated with each other, so using principal components solves the problem of multicollinearity (explanatory variables that are correlated with each other). Most of the information contained in all explanatory variables can frequently be captured in just a few principal components. By discarding the least useful principal components, the model calculation becomes more stable and efficient without significant loss of accuracy.</para>
		/// <para>To calculate principal components, there must be variability in the explanatory variables, so if any of your Input explanatory variable rasters contain constant values within a subset, these constant rasters will not be used to compute principal components for that subset. If all explanatory variable rasters in a subset contain constant values, the Output diagnostic feature class will report that zero principal components were used and that they captured zero percent of the variability.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 99.989999999999995)]
		[Category("Additional Model Parameters")]
		public object? MinCumulativeVariance { get; set; } = "95";

		/// <summary>
		/// <para>Subset polygon features</para>
		/// <para>Polygon features defining where the local models will be calculated. The points inside each polygon will be used for the local models. This parameter is useful when you know that the values of the dependent variable changes according to known regions. For example, these polygons may represent administrative health districts where health policy changes in different districts.</para>
		/// <para>You can also use the Generate Subset Polygons tool to create subset polygons. The polygons created by this tool will be non-overlapping and compact.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[Category("Additional Model Parameters")]
		public object? InSubsetFeatures { get; set; }

		/// <summary>
		/// <para>Dependent variable transformation type</para>
		/// <para>Type of transformation to be applied to the input data.</para>
		/// <para>None—Do not apply any transformation. This is the default.</para>
		/// <para>Empirical—Multiplicative Skewing transformation with Empirical base function.</para>
		/// <para>Log empirical—Multiplicative Skewing transformation with Log Empirical base function. All data values must be positive. If this option is chosen, all predictions will be positive.</para>
		/// <para><see cref="TransformationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Model Parameters")]
		public object? TransformationType { get; set; } = "NONE";

		/// <summary>
		/// <para>Semivariogram model type</para>
		/// <para>The semivariogram model that will be used for the interpolation.</para>
		/// <para>Exponential—Exponential semivariogram</para>
		/// <para>Nugget—Nugget semivariogram</para>
		/// <para>Whittle—Whittle semivariogram</para>
		/// <para>K-Bessel—K-Bessel semivariogram</para>
		/// <para><see cref="SemivariogramModelTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Model Parameters")]
		public object? SemivariogramModelType { get; set; } = "EXPONENTIAL";

		/// <summary>
		/// <para>Maximum number of points in each local model</para>
		/// <para>The input data will automatically be divided into subsets that do not have more than this number of points. If Subset polygon features are supplied, the value of this parameter will be ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 20, Max = 1000)]
		[Category("Additional Model Parameters")]
		public object? MaxLocalPoints { get; set; } = "100";

		/// <summary>
		/// <para>Local model area overlap factor</para>
		/// <para>A factor representing the degree of overlap between local models (also called subsets). Each input point can fall into several subsets, and the overlap factor specifies the average number of subsets that each point will fall into. A high value of the overlap factor makes the output surface smoother, but it also increases processing time. Values must be between 1 and 5. If Subset polygon features are supplied, the value of this parameter will be ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 1, Max = 5)]
		[Category("Additional Model Parameters")]
		public object? OverlapFactor { get; set; } = "1";

		/// <summary>
		/// <para>Number of simulations</para>
		/// <para>The number of simulated semivariograms of each local model. Using more simulations will make the model calculations more stable, but the model will take longer to calculate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 30, Max = 10000)]
		[Category("Additional Model Parameters")]
		public object? NumberSimulations { get; set; } = "100";

		/// <summary>
		/// <para>Search neighborhood</para>
		/// <para>Defines which surrounding points will be used to control the output. Standard is the default.</para>
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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EBKRegressionPrediction SetEnviroment(object? cellSize = null , object? coincidentPoints = null , object? extent = null , object? geographicTransformations = null , object? mask = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? scratchWorkspace = null , object? snapRaster = null , object? workspace = null )
		{
			base.SetEnv(cellSize: cellSize, coincidentPoints: coincidentPoints, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Dependent variable transformation type</para>
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
		/// <para>Semivariogram model type</para>
		/// </summary>
		public enum SemivariogramModelTypeEnum 
		{
			/// <summary>
			/// <para>Exponential—Exponential semivariogram</para>
			/// </summary>
			[GPValue("EXPONENTIAL")]
			[Description("Exponential")]
			Exponential,

			/// <summary>
			/// <para>Nugget—Nugget semivariogram</para>
			/// </summary>
			[GPValue("NUGGET")]
			[Description("Nugget")]
			Nugget,

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

#endregion
	}
}
