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
	/// <para>GA Layer To Rasters</para>
	/// <para>Exports a geostatistical layer to one or multiple rasters.</para>
	/// </summary>
	public class GALayerToRasters : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeostatLayer">
		/// <para>Input geostatistical layer</para>
		/// <para>The geostatistical layer to be analyzed.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The primary output raster to be created. Additional rasters can be created with the Additional output rasters parameter.</para>
		/// </param>
		public GALayerToRasters(object InGeostatLayer, object OutRaster)
		{
			this.InGeostatLayer = InGeostatLayer;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : GA Layer To Rasters</para>
		/// </summary>
		public override string DisplayName => "GA Layer To Rasters";

		/// <summary>
		/// <para>Tool Name : GALayerToRasters</para>
		/// </summary>
		public override string ToolName => "GALayerToRasters";

		/// <summary>
		/// <para>Tool Excute Name : ga.GALayerToRasters</para>
		/// </summary>
		public override string ExcuteName => "ga.GALayerToRasters";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "cellSize", "extent", "geographicTransformations", "mask", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InGeostatLayer, OutRaster, OutputType, QuantileProbabilityValue, CellSize, PointsPerBlockHorz, PointsPerBlockVert, AdditionalRasters, OutAdditionalRasters, OutElevation };

		/// <summary>
		/// <para>Input geostatistical layer</para>
		/// <para>The geostatistical layer to be analyzed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGALayer()]
		public object InGeostatLayer { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The primary output raster to be created. Additional rasters can be created with the Additional output rasters parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output Surface Type</para>
		/// <para>The surface type of the output raster.</para>
		/// <para>For more information, see What output surface types can the interpolation models generate?</para>
		/// <para>Prediction—A raster of predicted values.</para>
		/// <para>Prediction standard error—A raster of standard errors of prediction.</para>
		/// <para>Probability—A raster predicting the probability that a threshold is exceeded.</para>
		/// <para>Quantile—A raster predicting the quantile of the predicted value.</para>
		/// <para>Standard error of indicators—A raster of standard errors of indicators.</para>
		/// <para>Condition number—A raster showing the condition number for predictions in Local Polynomial Interpolation. The condition number surface indicates the stability of calculations at a particular location. The larger the condition number, the more unstable the prediction, so locations with large condition numbers may be prone to artifacts and erratic predicted values.</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutputType { get; set; } = "PREDICTION";

		/// <summary>
		/// <para>Quantile or probability value</para>
		/// <para>If the Output surface type is set to Quantile, use this parameter to enter the requested quantile. If the Output surface type is set to Probability, use this parameter to enter the requested threshold value, then the probability that the threshold is exceeded will be calculated.</para>
		/// <para>If the Input geostatistical layer is a probability or standard errors of indicators map that was created with the Not exceed option, then the probability that this threshold is not exceeded will be calculated. This will apply to all probability raster outputs from this tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain()]
		public object QuantileProbabilityValue { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>The cell size of the output rasters. This value will be shared by the Output raster and the Additional output rasters parameters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[GPSAGeoDataDomain()]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Number of points in the cell (horizontal)</para>
		/// <para>The number of predictions for each cell in the horizontal direction for block interpolation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain()]
		public object PointsPerBlockHorz { get; set; } = "1";

		/// <summary>
		/// <para>Number of points in the cell (vertical)</para>
		/// <para>The number of predictions for each cell in the vertical direction for block interpolation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain()]
		public object PointsPerBlockVert { get; set; } = "1";

		/// <summary>
		/// <para>Additional output rasters</para>
		/// <para>Provide the name, output type, and quantile or probability value for each additional output raster. See the descriptions of parameters above for more information. These additional rasters will be saved in the same location as the Output raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object AdditionalRasters { get; set; }

		/// <summary>
		/// <para>Additional rasters</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutAdditionalRasters { get; set; }

		/// <summary>
		/// <para>Output elevation</para>
		/// <para>For 3D interpolation models, you can export rasters at any elevation. Use this parameter to specify the elevation you want to export. If left empty, the elevation will be inherited from the input layer. The units will default to the same units of the input layer.</para>
		/// <para><see cref="OutElevationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object OutElevation { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GALayerToRasters SetEnviroment(object cellSize = null , object extent = null , object geographicTransformations = null , object mask = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object snapRaster = null , object workspace = null )
		{
			base.SetEnv(cellSize: cellSize, extent: extent, geographicTransformations: geographicTransformations, mask: mask, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Surface Type</para>
		/// </summary>
		public enum OutputTypeEnum 
		{
			/// <summary>
			/// <para>Prediction—A raster of predicted values.</para>
			/// </summary>
			[GPValue("PREDICTION")]
			[Description("Prediction")]
			Prediction,

			/// <summary>
			/// <para>Prediction standard error—A raster of standard errors of prediction.</para>
			/// </summary>
			[GPValue("PREDICTION_STANDARD_ERROR")]
			[Description("Prediction standard error")]
			Prediction_standard_error,

			/// <summary>
			/// <para>Probability—A raster predicting the probability that a threshold is exceeded.</para>
			/// </summary>
			[GPValue("PROBABILITY")]
			[Description("Probability")]
			Probability,

			/// <summary>
			/// <para>Quantile—A raster predicting the quantile of the predicted value.</para>
			/// </summary>
			[GPValue("QUANTILE")]
			[Description("Quantile")]
			Quantile,

			/// <summary>
			/// <para>Condition number—A raster showing the condition number for predictions in Local Polynomial Interpolation. The condition number surface indicates the stability of calculations at a particular location. The larger the condition number, the more unstable the prediction, so locations with large condition numbers may be prone to artifacts and erratic predicted values.</para>
			/// </summary>
			[GPValue("CONDITION_NUMBER")]
			[Description("Condition number")]
			Condition_number,

			/// <summary>
			/// <para>Standard error of indicators—A raster of standard errors of indicators.</para>
			/// </summary>
			[GPValue("STANDARD_ERROR_INDICATORS")]
			[Description("Standard error of indicators")]
			Standard_error_of_indicators,

		}

		/// <summary>
		/// <para>Output elevation</para>
		/// </summary>
		public enum OutElevationEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Inches")]
			[Description("Inches")]
			Inches,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NauticalMiles")]
			[Description("NauticalMiles")]
			NauticalMiles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Millimeters")]
			[Description("Millimeters")]
			Millimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Centimeters")]
			[Description("Centimeters")]
			Centimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Decimeters")]
			[Description("Decimeters")]
			Decimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

		}

#endregion
	}
}
