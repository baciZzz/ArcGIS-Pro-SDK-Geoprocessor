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
	/// <para>GA Layer 3D To Multidimensional Raster</para>
	/// <para>GA Layer 3D To Multidimensional Raster</para>
	/// <para>Exports a 3D geostatistical layer created using the Empirical Bayesian Kriging 3D tool to a multidimensional Cloud Raster Format (*.crf file) </para>
	/// <para>raster dataset. Tools in the Multidimensional Analysis toolset of the Image Analyst toolbox are designed to work directly on multidimensional rasters and can identify the 3D nature of the data.</para>
	/// </summary>
	public class GALayer3DToMultidimensionalRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="In3DGeostatLayer">
		/// <para>Input 3D geostatistical layer</para>
		/// <para>The 3D geostatistical layer representing the model to be exported to a multivariate raster dataset.</para>
		/// </param>
		/// <param name="OutMultidimensionalRaster">
		/// <para>Output multidimensional raster dataset</para>
		/// <para>The output raster dataset containing the results of exporting the geostatistical model. The output must be saved as a Cloud Raster Format file (*.crf).</para>
		/// </param>
		public GALayer3DToMultidimensionalRaster(object In3DGeostatLayer, object OutMultidimensionalRaster)
		{
			this.In3DGeostatLayer = In3DGeostatLayer;
			this.OutMultidimensionalRaster = OutMultidimensionalRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : GA Layer 3D To Multidimensional Raster</para>
		/// </summary>
		public override string DisplayName() => "GA Layer 3D To Multidimensional Raster";

		/// <summary>
		/// <para>Tool Name : GALayer3DToMultidimensionalRaster</para>
		/// </summary>
		public override string ToolName() => "GALayer3DToMultidimensionalRaster";

		/// <summary>
		/// <para>Tool Excute Name : ga.GALayer3DToMultidimensionalRaster</para>
		/// </summary>
		public override string ExcuteName() => "ga.GALayer3DToMultidimensionalRaster";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { In3DGeostatLayer, OutMultidimensionalRaster, CellSize!, ExplicitOnly!, MinElev!, MaxElev!, ElevInterval!, ElevValues!, ElevUnits!, OutputType!, QuantileProbabilityValue!, AdditionalOutputs!, BuildTranspose! };

		/// <summary>
		/// <para>Input 3D geostatistical layer</para>
		/// <para>The 3D geostatistical layer representing the model to be exported to a multivariate raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGALayer()]
		public object In3DGeostatLayer { get; set; }

		/// <summary>
		/// <para>Output multidimensional raster dataset</para>
		/// <para>The output raster dataset containing the results of exporting the geostatistical model. The output must be saved as a Cloud Raster Format file (*.crf).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Cell size</para>
		/// <para>The cell size of the output multidimensional raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain(CheckField = false, SingleBand = false)]
		[DataType("DERasterDataset", "DERasterBand", "GPRasterLayer", "analysis_cell_size", "DEMosaicDataset", "GPMosaicLayer", "GPRasterCalculatorExpression", "DETable", "DEImageServer", "DEFile")]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		[GeometryType("Point", "Polygon", "Polyline", "Multipoint")]
		public object? CellSize { get; set; }

		/// <summary>
		/// <para>Enter explicit elevation values</para>
		/// <para>Specifies whether elevations will be provided as an explicit list or an iterator will be used. Each elevation will be represented by a dimension in the output multidimensional raster.</para>
		/// <para>Checked—Elevation values will be provided as a list.</para>
		/// <para>Unchecked—Elevation values will be provided using an iterator. This is the default.</para>
		/// <para><see cref="ExplicitOnlyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ExplicitOnly { get; set; } = "false";

		/// <summary>
		/// <para>Minimum elevation</para>
		/// <para>The minimum elevation that will be used to start the iteration.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = -1.7976931348623157e+308, Max = 1.7976931348623157e+308)]
		public object? MinElev { get; set; }

		/// <summary>
		/// <para>Maximum elevation</para>
		/// <para>The maximum elevation that will be used to stop the iteration.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = -1.7976931348623157e+308, Max = 1.7976931348623157e+308)]
		public object? MaxElev { get; set; }

		/// <summary>
		/// <para>Elevation interval</para>
		/// <para>The increment that the elevation will increase with each iteration.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? ElevInterval { get; set; }

		/// <summary>
		/// <para>Elevation values</para>
		/// <para>The elevation values to export.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? ElevValues { get; set; }

		/// <summary>
		/// <para>Elevation units</para>
		/// <para>Specifies the measurement unit of the elevation values.</para>
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
		public object? ElevUnits { get; set; } = "METER";

		/// <summary>
		/// <para>Output type</para>
		/// <para>Specifies the primary output type of the output multidimensional raster. The Additional output types parameter can be used to specify additional variables in the output multidimensional raster.</para>
		/// <para>For more information, see What output surface types can the interpolation models generate?</para>
		/// <para>Prediction—A multidimensional raster of predicted values. This is the default.</para>
		/// <para>Prediction standard error—A multidimensional raster of standard errors of prediction.</para>
		/// <para>Probability—A multidimensional raster predicting the probability that a threshold is exceeded.</para>
		/// <para>Quantile—A multidimensional raster predicting the quantile of the predicted value.</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Parameters")]
		public object? OutputType { get; set; } = "PREDICTION";

		/// <summary>
		/// <para>Quantile or probability threshold value</para>
		/// <para>If Output type is set to Quantile, use this parameter to enter the requested quantile. If Output type is set to Probability, use this parameter to enter the requested threshold value, and the probability that the threshold is exceeded will be calculated. Subtract this value from one to get the probability that the threshold is not exceeded.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = -1.7976931348623157e+308, Max = 1.7976931348623157e+308)]
		[Category("Output Parameters")]
		public object? QuantileProbabilityValue { get; set; }

		/// <summary>
		/// <para>Additional output types</para>
		/// <para>Specifies the output type and quantile or probability value for each additional output type. If multiple output types are provided, the output raster will be a multivariate raster dataset with a different variable for each output type.</para>
		/// <para>For more information, see What output surface types can the interpolation models generate?</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Output Parameters")]
		public object? AdditionalOutputs { get; set; }

		/// <summary>
		/// <para>Build multidimensional transpose</para>
		/// <para>Specifies whether multidimensional transposes will be built on the output multidimensional raster.</para>
		/// <para>Checked—Multidimensional transposes will be built on the output multidimensional raster.</para>
		/// <para>Unchecked—Multidimensional transposes will not be built on the output multidimensional raster. This is the default.</para>
		/// <para><see cref="BuildTransposeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Output Parameters")]
		public object? BuildTranspose { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GALayer3DToMultidimensionalRaster SetEnviroment(object? cellSize = null, object? extent = null, object? geographicTransformations = null, object? mask = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? snapRaster = null)
		{
			base.SetEnv(cellSize: cellSize, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Enter explicit elevation values</para>
		/// </summary>
		public enum ExplicitOnlyEnum 
		{
			/// <summary>
			/// <para>Checked—Elevation values will be provided as a list.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EXPLICIT_VALUES")]
			EXPLICIT_VALUES,

			/// <summary>
			/// <para>Unchecked—Elevation values will be provided using an iterator. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_EXPLICIT_VALUES")]
			NO_EXPLICIT_VALUES,

		}

		/// <summary>
		/// <para>Output type</para>
		/// </summary>
		public enum OutputTypeEnum 
		{
			/// <summary>
			/// <para>Prediction—A multidimensional raster of predicted values. This is the default.</para>
			/// </summary>
			[GPValue("PREDICTION")]
			[Description("Prediction")]
			Prediction,

			/// <summary>
			/// <para>Prediction standard error—A multidimensional raster of standard errors of prediction.</para>
			/// </summary>
			[GPValue("PREDICTION_STANDARD_ERROR")]
			[Description("Prediction standard error")]
			Prediction_standard_error,

			/// <summary>
			/// <para>Probability—A multidimensional raster predicting the probability that a threshold is exceeded.</para>
			/// </summary>
			[GPValue("PROBABILITY")]
			[Description("Probability")]
			Probability,

			/// <summary>
			/// <para>Quantile—A multidimensional raster predicting the quantile of the predicted value.</para>
			/// </summary>
			[GPValue("QUANTILE")]
			[Description("Quantile")]
			Quantile,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("CONDITION_NUMBER")]
			[Description("CONDITION_NUMBER")]
			CONDITION_NUMBER,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("STANDARD_ERROR_INDICATORS")]
			[Description("STANDARD_ERROR_INDICATORS")]
			STANDARD_ERROR_INDICATORS,

		}

		/// <summary>
		/// <para>Build multidimensional transpose</para>
		/// </summary>
		public enum BuildTransposeEnum 
		{
			/// <summary>
			/// <para>Checked—Multidimensional transposes will be built on the output multidimensional raster.</para>
			/// </summary>
			[GPValue("true")]
			[Description("BUILD_TRANSPOSE")]
			BUILD_TRANSPOSE,

			/// <summary>
			/// <para>Unchecked—Multidimensional transposes will not be built on the output multidimensional raster. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_BUILD_TRANSPOSE")]
			DO_NOT_BUILD_TRANSPOSE,

		}

#endregion
	}
}
