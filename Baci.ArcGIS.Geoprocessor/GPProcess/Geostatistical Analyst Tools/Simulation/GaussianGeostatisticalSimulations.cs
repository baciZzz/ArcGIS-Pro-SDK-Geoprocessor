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
	/// <para>Gaussian Geostatistical Simulations</para>
	/// <para>Gaussian Geostatistical Simulations</para>
	/// <para>Performs a conditional or unconditional geostatistical simulation based on a Simple Kriging model. The simulated rasters can be considered equally probable realizations of the kriging model.</para>
	/// </summary>
	public class GaussianGeostatisticalSimulations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeostatLayer">
		/// <para>Input geostatistical layer</para>
		/// <para>Input a geostatistical layer resulting from a Simple Kriging model.</para>
		/// </param>
		/// <param name="NumberOfRealizations">
		/// <para>Number of realizations</para>
		/// <para>The number of simulations to perform.</para>
		/// </param>
		/// <param name="OutputWorkspace">
		/// <para>Output workspace</para>
		/// <para>Stores all the simulation results. The workspace can be either a folder or a geodatabase.</para>
		/// </param>
		/// <param name="OutputSimulationPrefix">
		/// <para>Output simulation prefix</para>
		/// <para>A one- to three-character alphanumeric prefix that is automatically added to the output dataset names.</para>
		/// </param>
		public GaussianGeostatisticalSimulations(object InGeostatLayer, object NumberOfRealizations, object OutputWorkspace, object OutputSimulationPrefix)
		{
			this.InGeostatLayer = InGeostatLayer;
			this.NumberOfRealizations = NumberOfRealizations;
			this.OutputWorkspace = OutputWorkspace;
			this.OutputSimulationPrefix = OutputSimulationPrefix;
		}

		/// <summary>
		/// <para>Tool Display Name : Gaussian Geostatistical Simulations</para>
		/// </summary>
		public override string DisplayName() => "Gaussian Geostatistical Simulations";

		/// <summary>
		/// <para>Tool Name : GaussianGeostatisticalSimulations</para>
		/// </summary>
		public override string ToolName() => "GaussianGeostatisticalSimulations";

		/// <summary>
		/// <para>Tool Excute Name : ga.GaussianGeostatisticalSimulations</para>
		/// </summary>
		public override string ExcuteName() => "ga.GaussianGeostatisticalSimulations";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "randomGenerator", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGeostatLayer, NumberOfRealizations, OutputWorkspace, OutputSimulationPrefix, InConditioningFeatures, ConditioningField, CellSize, InBoundingDataset, SaveSimulatedRasters, Quantile, Threshold, InStatsPolygons, RasterStatType, ConditioningMeasurementErrorField, OutWorkspace, OutPolygonStat, OutRasterSimulation, OutRasterStat, OutConvergenceValue };

		/// <summary>
		/// <para>Input geostatistical layer</para>
		/// <para>Input a geostatistical layer resulting from a Simple Kriging model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGALayer()]
		public object InGeostatLayer { get; set; }

		/// <summary>
		/// <para>Number of realizations</para>
		/// <para>The number of simulations to perform.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 4500)]
		public object NumberOfRealizations { get; set; } = "10";

		/// <summary>
		/// <para>Output workspace</para>
		/// <para>Stores all the simulation results. The workspace can be either a folder or a geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object OutputWorkspace { get; set; }

		/// <summary>
		/// <para>Output simulation prefix</para>
		/// <para>A one- to three-character alphanumeric prefix that is automatically added to the output dataset names.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputSimulationPrefix { get; set; }

		/// <summary>
		/// <para>Input conditioning features</para>
		/// <para>The features used to condition the realizations. If left blank, unconditional realizations are produced.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		public object InConditioningFeatures { get; set; }

		/// <summary>
		/// <para>Conditioning field</para>
		/// <para>The field used to condition the realizations. If left blank, unconditional realizations are produced.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ConditioningField { get; set; }

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
		/// <para>Input bounding features</para>
		/// <para>Limits the analysis to these features' bounding polygon. If point features are entered, then a convex hull polygon is automatically created. Realizations are then performed within that polygon. If bounding features are supplied, any features or rasters supplied in the Mask environment will be ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Point")]
		public object InBoundingDataset { get; set; }

		/// <summary>
		/// <para>Save simulated rasters</para>
		/// <para>Specifies whether or not the simulated rasters are saved to disk.</para>
		/// <para>Checked—Indicates that the simulated rasters will be saved to disk.</para>
		/// <para>Unchecked—Indicates that the simulated rasters will not be saved to disk.</para>
		/// <para><see cref="SaveSimulatedRastersEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SaveSimulatedRasters { get; set; } = "false";

		/// <summary>
		/// <para>Quantile</para>
		/// <para>The quantile value for which the output raster will be generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 2.2204460492503131e-16, Max = 0.99999999999999978)]
		public object Quantile { get; set; }

		/// <summary>
		/// <para>Threshold</para>
		/// <para>The threshold value for which the output raster will be generated, as the percentage of the number of times the set threshold was exceeded, on a cell-by-cell basis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Threshold { get; set; }

		/// <summary>
		/// <para>Input statistical polygons</para>
		/// <para>These polygons represent areas of interest for which summary statistics are calculated.</para>
		/// <para>If statistical polygons are provided, the output polygon feature class will be saved in the Output workspace, and it will have the same name as the input polygons, preceded by the Output simulation prefix. For example, if the input statistical polygons were named myPolys and you entered aaa as the output prefix, then the output polygons will be named aaamyPolys, and will be saved in the specified output workspace.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InStatsPolygons { get; set; }

		/// <summary>
		/// <para>Raster statistics type</para>
		/// <para>The simulated rasters are postprocessed on a cell-by-cell basis, and each selected statistics type is calculated and reported in an output raster.</para>
		/// <para>Minimum—Calculates the minimum (smallest value).</para>
		/// <para>Maximum—Calculates the maximum (largest value).</para>
		/// <para>Mean—Calculates the mean (average).</para>
		/// <para>Standard deviation—Calculates the standard deviation.</para>
		/// <para>First quartile—Calculates the 25th quantile.</para>
		/// <para>Median—Calculates the median.</para>
		/// <para>Third quartile—Calculates the 75th quantile.</para>
		/// <para>Quantile—Calculates a user-specified quantile (0 &lt; Q &lt; 1).</para>
		/// <para>Probability threshold—Calculates the percentage of the simulations where the cell value exceeds a user-specified threshold value.</para>
		/// <para><see cref="RasterStatTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object RasterStatType { get; set; }

		/// <summary>
		/// <para>Conditioning measurement error field</para>
		/// <para>A field that specifies the measurement error for each input point in the conditioning features. For each conditioning feature, the value of this field should correspond to one standard deviation of the measured value of the feature. Use this field if the measurement error values are not the same at each sampling location.</para>
		/// <para>A common source of nonconstant measurement error is when the data is measured with different devices. One device might be more precise than another, which means that it will have a smaller measurement error. For example, one thermometer rounds to the nearest degree and another thermometer rounds to the nearest tenth of a degree. The variability of measurements is often provided by the manufacturer of the measuring device, or it may be known from empirical practice.</para>
		/// <para>Leave this parameter blank if there are no measurement error values or the measurement error values are unknown.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ConditioningMeasurementErrorField { get; set; }

		/// <summary>
		/// <para>Output workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Output statistical polygons</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutPolygonStat { get; set; }

		/// <summary>
		/// <para>Output simulation rasters</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutRasterSimulation { get; set; }

		/// <summary>
		/// <para>Output statistical rasters</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutRasterStat { get; set; }

		/// <summary>
		/// <para>Convergence</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object OutConvergenceValue { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GaussianGeostatisticalSimulations SetEnviroment(object cellSize = null, object extent = null, object geographicTransformations = null, object mask = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object randomGenerator = null, object scratchWorkspace = null, object snapRaster = null, object workspace = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, randomGenerator: randomGenerator, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Save simulated rasters</para>
		/// </summary>
		public enum SaveSimulatedRastersEnum 
		{
			/// <summary>
			/// <para>Checked—Indicates that the simulated rasters will be saved to disk.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SAVE_SIMULATIONS")]
			SAVE_SIMULATIONS,

			/// <summary>
			/// <para>Unchecked—Indicates that the simulated rasters will not be saved to disk.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_SAVE_SIMULATIONS")]
			DO_NOT_SAVE_SIMULATIONS,

		}

		/// <summary>
		/// <para>Raster statistics type</para>
		/// </summary>
		public enum RasterStatTypeEnum 
		{
			/// <summary>
			/// <para>Minimum—Calculates the minimum (smallest value).</para>
			/// </summary>
			[GPValue("MIN")]
			[Description("Minimum")]
			Minimum,

			/// <summary>
			/// <para>Maximum—Calculates the maximum (largest value).</para>
			/// </summary>
			[GPValue("MAX")]
			[Description("Maximum")]
			Maximum,

			/// <summary>
			/// <para>Mean—Calculates the mean (average).</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("Mean")]
			Mean,

			/// <summary>
			/// <para>Standard deviation—Calculates the standard deviation.</para>
			/// </summary>
			[GPValue("STDDEV")]
			[Description("Standard deviation")]
			Standard_deviation,

			/// <summary>
			/// <para>First quartile—Calculates the 25th quantile.</para>
			/// </summary>
			[GPValue("QUARTILE1")]
			[Description("First quartile")]
			First_quartile,

			/// <summary>
			/// <para>Median—Calculates the median.</para>
			/// </summary>
			[GPValue("MEDIAN")]
			[Description("Median")]
			Median,

			/// <summary>
			/// <para>Third quartile—Calculates the 75th quantile.</para>
			/// </summary>
			[GPValue("QUARTILE3")]
			[Description("Third quartile")]
			Third_quartile,

			/// <summary>
			/// <para>Quantile—Calculates a user-specified quantile (0 &lt; Q &lt; 1).</para>
			/// </summary>
			[GPValue("QUANTILE")]
			[Description("Quantile")]
			Quantile,

			/// <summary>
			/// <para>Probability threshold—Calculates the percentage of the simulations where the cell value exceeds a user-specified threshold value.</para>
			/// </summary>
			[GPValue("P_THRSHLD")]
			[Description("Probability threshold")]
			Probability_threshold,

		}

#endregion
	}
}
