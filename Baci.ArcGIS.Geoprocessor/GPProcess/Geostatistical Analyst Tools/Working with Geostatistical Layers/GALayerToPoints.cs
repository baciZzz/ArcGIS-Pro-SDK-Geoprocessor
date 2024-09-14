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
	/// <para>GA Layer To Points</para>
	/// <para>GA Layer To Points</para>
	/// <para>Exports a geostatistical layer to points. The tool can also be used to predict values at unmeasured locations or to validate predictions made at measured locations.</para>
	/// </summary>
	public class GALayerToPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeostatLayer">
		/// <para>Input geostatistical layer</para>
		/// <para>The geostatistical layer to be analyzed.</para>
		/// </param>
		/// <param name="InLocations">
		/// <para>Input point observation locations</para>
		/// <para>Point locations where predictions or validations will be performed.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output statistics at point locations</para>
		/// <para>The output feature class containing either the predictions or the predictions and the validation results.</para>
		/// <para>The fields in this feature class can include the following fields (where applicable):</para>
		/// <para>Source_ID (Source ID)—The object ID of the source feature in the Input point observation locations.</para>
		/// <para>The feature or object identifier of the input dataset that was used.</para>
		/// <para>Included (Included)—Indicates whether a prediction was calculated for this feature. The values in this field can be one of the following:</para>
		/// <para>Yes—There are no problems making a prediction at this point.</para>
		/// <para>Not enough neighbors—There are not enough neighbors to make a prediction.</para>
		/// <para>Weight parameter is too small—The weight parameter is too small.</para>
		/// <para>Overfilling—Overflow of floating-point calculations.</para>
		/// <para>Problem with data transformation—The value to be transformed is outside of the supported range for the selected transformation (only in kriging).</para>
		/// <para>No explanatory rasters—The value cannot be calculated because one of the explanatory variables is not defined. The point could be outside the extent of at least one explanatory variable raster, or the point could be on top of a NoData cell in at least one of the explanatory variable rasters. This only applies to EBK Regression Prediction models.</para>
		/// <para>Predicted (Predicted)—The prediction value at this location.</para>
		/// <para>Error (Error)—The predicted value minus the value in the validation field.</para>
		/// <para>StdError (Standard Error)—The kriging standard error.</para>
		/// <para>Stdd_Error (Standardized Error)—The standardized prediction errors. Ideally, the standardized prediction errors are distributed normally.</para>
		/// <para>NormValue (Normal Value)—The normal distribution value (x-axis) that corresponds to the standardized prediction errors (y-axis) in the normal QQplot.</para>
		/// <para>CRPS (Continuous Ranked Probability Score)—The continuous ranked probability score is a diagnostic that measures the deviation from the predictive cumulative distribution function to each observed data value. This value should be as small as possible. This diagnostic has advantages over cross-validation diagnostics because it compares the data to a full distribution rather than to single-point predictions. This field is only created for Empirical Bayesian Kriging and EBK Regression Prediction models.</para>
		/// <para>Interval90 (Inside 90 Percent Interval)—Indicates whether or not the validation point is inside of a 90 percent confidence interval. This field is only created for Empirical Bayesian Kriging and EBK Regression Prediction models. If the model fits the data, approximately 90 percent of the features should be contained in a 90 percent confidence interval. This field can contain the following values:</para>
		/// <para>Yes—The validation point is inside the 90 percent confidence interval.</para>
		/// <para>No—The validation point is not inside the 90 percent confidence interval.</para>
		/// <para>Excluded—A prediction cannot be made at this location.</para>
		/// <para>Interval95 (Inside 95 Percent Interval)—Indicates whether or not the validation point is inside of a 95 percent confidence interval. This field is only created for Empirical Bayesian Kriging and EBK Regression Prediction models. If the model fits the data, approximately 95 percent of the features should be contained in a 95 percent confidence interval. This field can contain the following values:</para>
		/// <para>Yes—The validation point is inside the 95 percent confidence interval.</para>
		/// <para>No—The validation point is not inside the 95 percent confidence interval.</para>
		/// <para>Excluded—A prediction cannot be made at this location.</para>
		/// <para>QuanVal (Validation Quantile)—The quantile of the measured value at the feature with respect to the prediction distribution. This value can range from 0 to 1, and values close to 0 indicate that the measured value is on the far left tail of the distribution, and values close to 1 indicate that the measured value is on the right tail of the distribution. If many values are close to either extreme, this could indicate that the prediction distributions do not model the data well, and some of the interpolation parameters need to be altered. This field is only created for Empirical Bayesian Kriging and EBK Regression Prediction models.</para>
		/// </param>
		public GALayerToPoints(object InGeostatLayer, object InLocations, object OutFeatureClass)
		{
			this.InGeostatLayer = InGeostatLayer;
			this.InLocations = InLocations;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : GA Layer To Points</para>
		/// </summary>
		public override string DisplayName() => "GA Layer To Points";

		/// <summary>
		/// <para>Tool Name : GALayerToPoints</para>
		/// </summary>
		public override string ToolName() => "GALayerToPoints";

		/// <summary>
		/// <para>Tool Excute Name : ga.GALayerToPoints</para>
		/// </summary>
		public override string ExcuteName() => "ga.GALayerToPoints";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGeostatLayer, InLocations, ZField!, OutFeatureClass, AppendAllFields!, ElevationField!, ElevationUnits! };

		/// <summary>
		/// <para>Input geostatistical layer</para>
		/// <para>The geostatistical layer to be analyzed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGALayer()]
		public object InGeostatLayer { get; set; }

		/// <summary>
		/// <para>Input point observation locations</para>
		/// <para>Point locations where predictions or validations will be performed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InLocations { get; set; }

		/// <summary>
		/// <para>Field to validate on</para>
		/// <para>If this field is left blank, predictions are made at the location points. If a field is selected, predictions are made at the location points, compared to their Z_value_field values, and a validation analysis is performed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		[ExcludeField("Predicted", "StdError", "Error", "Stdd_Error", "NormValue", "Source_ID", "Included")]
		public object? ZField { get; set; }

		/// <summary>
		/// <para>Output statistics at point locations</para>
		/// <para>The output feature class containing either the predictions or the predictions and the validation results.</para>
		/// <para>The fields in this feature class can include the following fields (where applicable):</para>
		/// <para>Source_ID (Source ID)—The object ID of the source feature in the Input point observation locations.</para>
		/// <para>The feature or object identifier of the input dataset that was used.</para>
		/// <para>Included (Included)—Indicates whether a prediction was calculated for this feature. The values in this field can be one of the following:</para>
		/// <para>Yes—There are no problems making a prediction at this point.</para>
		/// <para>Not enough neighbors—There are not enough neighbors to make a prediction.</para>
		/// <para>Weight parameter is too small—The weight parameter is too small.</para>
		/// <para>Overfilling—Overflow of floating-point calculations.</para>
		/// <para>Problem with data transformation—The value to be transformed is outside of the supported range for the selected transformation (only in kriging).</para>
		/// <para>No explanatory rasters—The value cannot be calculated because one of the explanatory variables is not defined. The point could be outside the extent of at least one explanatory variable raster, or the point could be on top of a NoData cell in at least one of the explanatory variable rasters. This only applies to EBK Regression Prediction models.</para>
		/// <para>Predicted (Predicted)—The prediction value at this location.</para>
		/// <para>Error (Error)—The predicted value minus the value in the validation field.</para>
		/// <para>StdError (Standard Error)—The kriging standard error.</para>
		/// <para>Stdd_Error (Standardized Error)—The standardized prediction errors. Ideally, the standardized prediction errors are distributed normally.</para>
		/// <para>NormValue (Normal Value)—The normal distribution value (x-axis) that corresponds to the standardized prediction errors (y-axis) in the normal QQplot.</para>
		/// <para>CRPS (Continuous Ranked Probability Score)—The continuous ranked probability score is a diagnostic that measures the deviation from the predictive cumulative distribution function to each observed data value. This value should be as small as possible. This diagnostic has advantages over cross-validation diagnostics because it compares the data to a full distribution rather than to single-point predictions. This field is only created for Empirical Bayesian Kriging and EBK Regression Prediction models.</para>
		/// <para>Interval90 (Inside 90 Percent Interval)—Indicates whether or not the validation point is inside of a 90 percent confidence interval. This field is only created for Empirical Bayesian Kriging and EBK Regression Prediction models. If the model fits the data, approximately 90 percent of the features should be contained in a 90 percent confidence interval. This field can contain the following values:</para>
		/// <para>Yes—The validation point is inside the 90 percent confidence interval.</para>
		/// <para>No—The validation point is not inside the 90 percent confidence interval.</para>
		/// <para>Excluded—A prediction cannot be made at this location.</para>
		/// <para>Interval95 (Inside 95 Percent Interval)—Indicates whether or not the validation point is inside of a 95 percent confidence interval. This field is only created for Empirical Bayesian Kriging and EBK Regression Prediction models. If the model fits the data, approximately 95 percent of the features should be contained in a 95 percent confidence interval. This field can contain the following values:</para>
		/// <para>Yes—The validation point is inside the 95 percent confidence interval.</para>
		/// <para>No—The validation point is not inside the 95 percent confidence interval.</para>
		/// <para>Excluded—A prediction cannot be made at this location.</para>
		/// <para>QuanVal (Validation Quantile)—The quantile of the measured value at the feature with respect to the prediction distribution. This value can range from 0 to 1, and values close to 0 indicate that the measured value is on the far left tail of the distribution, and values close to 1 indicate that the measured value is on the right tail of the distribution. If many values are close to either extreme, this could indicate that the prediction distributions do not model the data well, and some of the interpolation parameters need to be altered. This field is only created for Empirical Bayesian Kriging and EBK Regression Prediction models.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Append all fields from input features</para>
		/// <para>Determines whether all fields will be copied from the input features to the output feature class.</para>
		/// <para>Checked—All fields from the input features will be copied to the output feature class. This is the default.</para>
		/// <para>Unchecked—Only the feature ID value will be copied, and it will be named Source_ID on the output feature class.</para>
		/// <para><see cref="AppendAllFieldsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AppendAllFields { get; set; } = "true";

		/// <summary>
		/// <para>Elevation field</para>
		/// <para>The field containing the elevation of each input point. The parameter only applies to 3D geostatistical models. If the elevation values are stored as geometry attributes in Shape.Z, it is recommended to use that field. If the elevations are stored in an attribute field, the elevations must indicate distance from sea level. Positive values indicate distance above sea level, and negative values indicate distance below sea level.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object? ElevationField { get; set; }

		/// <summary>
		/// <para>Elevation field units</para>
		/// <para>The units of the elevation field. This parameter only applies to 3D geostatistical models. If Shape.Z is provided as the elevation field, the units will automatically match the Z-units of the vertical coordinate system.</para>
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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GALayerToPoints SetEnviroment(object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Append all fields from input features</para>
		/// </summary>
		public enum AppendAllFieldsEnum 
		{
			/// <summary>
			/// <para>Checked—All fields from the input features will be copied to the output feature class. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ALL")]
			ALL,

			/// <summary>
			/// <para>Unchecked—Only the feature ID value will be copied, and it will be named Source_ID on the output feature class.</para>
			/// </summary>
			[GPValue("false")]
			[Description("FID_ONLY")]
			FID_ONLY,

		}

#endregion
	}
}
