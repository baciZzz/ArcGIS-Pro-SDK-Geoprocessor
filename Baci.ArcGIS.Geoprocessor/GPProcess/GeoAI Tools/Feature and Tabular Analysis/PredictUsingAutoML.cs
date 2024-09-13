using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAITools
{
	/// <summary>
	/// <para>Predict Using AutoML</para>
	/// <para>Predict Using AutoML</para>
	/// <para>Uses the trained  .dlpk model produced by the Train Using AutoML tool to predict continuous variables (regression) or categorical variables (classification) on unseen compatible datasets.</para>
	/// </summary>
	public class PredictUsingAutoML : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InModelDefinition">
		/// <para>Model Definition</para>
		/// <para>The .dlpk file or the .emd file.</para>
		/// </param>
		/// <param name="PredictionType">
		/// <para>Prediction Type</para>
		/// <para>Specifies the output file type that will be created.</para>
		/// <para>Predict feature—A feature layer containing the prediction values will be created. The Output Prediction Features value is required for this option.</para>
		/// <para>Predict raster—A raster layer containing the prediction values will be created. The Output Prediction Surface value is required for this option.</para>
		/// <para><see cref="PredictionTypeEnum"/></para>
		/// </param>
		/// <param name="InFeatures">
		/// <para>Input Prediction Features</para>
		/// <para>The features for which the prediction will be obtained. The input should include some or all of the fields necessary to determine the dependent variable value. This parameter is required if the Prediction Type parameter is set to Predict feature.</para>
		/// </param>
		public PredictUsingAutoML(object InModelDefinition, object PredictionType, object InFeatures)
		{
			this.InModelDefinition = InModelDefinition;
			this.PredictionType = PredictionType;
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Predict Using AutoML</para>
		/// </summary>
		public override string DisplayName() => "Predict Using AutoML";

		/// <summary>
		/// <para>Tool Name : PredictUsingAutoML</para>
		/// </summary>
		public override string ToolName() => "PredictUsingAutoML";

		/// <summary>
		/// <para>Tool Excute Name : geoai.PredictUsingAutoML</para>
		/// </summary>
		public override string ExcuteName() => "geoai.PredictUsingAutoML";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAI Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAI Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoai</para>
		/// </summary>
		public override string ToolboxAlise() => "geoai";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InModelDefinition, PredictionType, InFeatures, ExplanatoryRasters!, DistanceFeatures!, OutPredictionFeatures!, OutPredictionSurface!, MatchExplanatoryVariables!, MatchDistanceVariables!, MatchExplanatoryRasters! };

		/// <summary>
		/// <para>Model Definition</para>
		/// <para>The .dlpk file or the .emd file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("dlpk")]
		public object InModelDefinition { get; set; }

		/// <summary>
		/// <para>Prediction Type</para>
		/// <para>Specifies the output file type that will be created.</para>
		/// <para>Predict feature—A feature layer containing the prediction values will be created. The Output Prediction Features value is required for this option.</para>
		/// <para>Predict raster—A raster layer containing the prediction values will be created. The Output Prediction Surface value is required for this option.</para>
		/// <para><see cref="PredictionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PredictionType { get; set; } = "PREDICT_FEATURE";

		/// <summary>
		/// <para>Input Prediction Features</para>
		/// <para>The features for which the prediction will be obtained. The input should include some or all of the fields necessary to determine the dependent variable value. This parameter is required if the Prediction Type parameter is set to Predict feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Explanatory Rasters</para>
		/// <para>A list of rasters that contain some or all of the fields necessary to determine the dependent variable value. This parameter is required if the Prediction Type parameter is set to Predict raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? ExplanatoryRasters { get; set; }

		/// <summary>
		/// <para>Distance Features</para>
		/// <para>The features whose distances from the input training features will be estimated automatically and added as more explanatory variables. Distances will be calculated from each of the input explanatory training distance features to the nearest input training features. If the input explanatory training distance features are polygons or lines, the distance attributes will be calculated as the distance between the closest segments of the pair of features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		public object? DistanceFeatures { get; set; }

		/// <summary>
		/// <para>Output Prediction Features</para>
		/// <para>The output table or feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? OutPredictionFeatures { get; set; }

		/// <summary>
		/// <para>Output Prediction Surface</para>
		/// <para>The path to where the output prediction raster will be saved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object? OutPredictionSurface { get; set; }

		/// <summary>
		/// <para>Match Explanatory Variables</para>
		/// <para>The mapping of field names from the prediction set to the training set. The columns and fields in the test feature class must match the field names provided during the training. The string values are the column names in the train dataset that match the field names in the input feature class. This parameter is only required if the same variables are identified by different names in the training and the test datasets.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? MatchExplanatoryVariables { get; set; }

		/// <summary>
		/// <para>Match Distance Variables</para>
		/// <para>The mapping of distance features names from the prediction set to the training set. The names of the distance features that were used for prediction must match the same distance features used during training. The string values are the feature names that were used for prediction that match the distance features names used for training. This parameter is only required if the same distance features used during training and prediction are identified by different names.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? MatchDistanceVariables { get; set; }

		/// <summary>
		/// <para>Match Explanatory Rasters</para>
		/// <para>The mapping of field names from the prediction rasters to the training rasters. The names of the explanatory rasters that were used for prediction must match the same explanatory rasters used during training. The string values are the explanatory raster names that were used for prediction that match the explanatory raster names used for training. This parameter is only required if the same explanatory rasters used during training and prediction are identified by different names.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? MatchExplanatoryRasters { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PredictUsingAutoML SetEnviroment(object? geographicTransformations = null , object? outputCoordinateSystem = null )
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Prediction Type</para>
		/// </summary>
		public enum PredictionTypeEnum 
		{
			/// <summary>
			/// <para>Predict feature—A feature layer containing the prediction values will be created. The Output Prediction Features value is required for this option.</para>
			/// </summary>
			[GPValue("PREDICT_FEATURE")]
			[Description("Predict feature")]
			Predict_feature,

			/// <summary>
			/// <para>Predict raster—A raster layer containing the prediction values will be created. The Output Prediction Surface value is required for this option.</para>
			/// </summary>
			[GPValue("PREDICT_RASTER")]
			[Description("Predict raster")]
			Predict_raster,

		}

#endregion
	}
}
