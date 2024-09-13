using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialStatisticsTools
{
	/// <summary>
	/// <para>Multiscale Geographically Weighted Regression (MGWR)</para>
	/// <para>Multiscale Geographically Weighted Regression (MGWR)</para>
	/// <para>Performs multiscale geographically weighted regression (MGWR), which is a local form of linear regression that models spatially varying relationships.</para>
	/// </summary>
	public class MGWR : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The feature class containing the dependent and explanatory variables.</para>
		/// </param>
		/// <param name="DependentVariable">
		/// <para>Dependent Variable</para>
		/// <para>The numeric field containing the observed values that will be modeled.</para>
		/// </param>
		/// <param name="ModelType">
		/// <para>Model Type</para>
		/// <para>Specifies the regression model based on the values of the dependent variable. Currently, only continuous data is supported, and the parameter is hidden in the Geoprocessing pane. Do not use categorical, count, or binary dependent variables.</para>
		/// <para>Continuous—The dependent variable represents continuous values. This is the default.</para>
		/// <para><see cref="ModelTypeEnum"/></para>
		/// </param>
		/// <param name="ExplanatoryVariables">
		/// <para>Explanatory Variables</para>
		/// <para>A list of fields that will be used as independent explanatory variables in the regression model.</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>The new feature class containing the coefficients, residuals, and significance levels of the MGWR model.</para>
		/// </param>
		/// <param name="NeighborhoodType">
		/// <para>Neighborhood Type</para>
		/// <para>Specifies whether the neighborhood will be a fixed distance or allowed to vary spatially depending on the density of the features.</para>
		/// <para>Number of Neighbors— The neighborhood size will be a specified number of closest neighbors for each feature. Where features are dense, the spatial extent of the neighborhood will be smaller; where features are sparse, the spatial extent of the neighborhood will be larger.</para>
		/// <para>Distance Band—The neighborhood size will be a constant or fixed distance for each feature.</para>
		/// <para><see cref="NeighborhoodTypeEnum"/></para>
		/// </param>
		/// <param name="NeighborhoodSelectionMethod">
		/// <para>Neighborhood Selection Method</para>
		/// <para>Specifies how the neighborhood size will be determined.</para>
		/// <para>Golden Search—An optimal distance or number of neighbors will be identified by minimizing the AICc value using the Golden Search algorithm.</para>
		/// <para>Manual Intervals—A distance or number of neighbors will be identified by testing a range of values and choosing the value with the smallest AICc. If the Neighborhood Type parameter is set to Distance Band, the minimum value of this range is provided by the Minimum search distance parameter. The minimum value is then incremented by the value specified in the Search Distance Increment parameter. This is repeated the number of times specified by the Number of Increments parameter. If the Neighborhood Type parameter is set to Number of Neighbors, the minimum value, increment size, and number of increments are provided in the Minimum Number of Neighbors, Number of Neighbors Increment, and Number of Increments parameters, respectively.</para>
		/// <para>User Defined— The neighborhood size will be specified by either the Number of Neighbors parameter or the Distance Band parameter.</para>
		/// <para><see cref="NeighborhoodSelectionMethodEnum"/></para>
		/// </param>
		public MGWR(object InFeatures, object DependentVariable, object ModelType, object ExplanatoryVariables, object OutputFeatures, object NeighborhoodType, object NeighborhoodSelectionMethod)
		{
			this.InFeatures = InFeatures;
			this.DependentVariable = DependentVariable;
			this.ModelType = ModelType;
			this.ExplanatoryVariables = ExplanatoryVariables;
			this.OutputFeatures = OutputFeatures;
			this.NeighborhoodType = NeighborhoodType;
			this.NeighborhoodSelectionMethod = NeighborhoodSelectionMethod;
		}

		/// <summary>
		/// <para>Tool Display Name : Multiscale Geographically Weighted Regression (MGWR)</para>
		/// </summary>
		public override string DisplayName() => "Multiscale Geographically Weighted Regression (MGWR)";

		/// <summary>
		/// <para>Tool Name : MGWR</para>
		/// </summary>
		public override string ToolName() => "MGWR";

		/// <summary>
		/// <para>Tool Excute Name : stats.MGWR</para>
		/// </summary>
		public override string ExcuteName() => "stats.MGWR";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise() => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "snapRaster" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, DependentVariable, ModelType, ExplanatoryVariables, OutputFeatures, NeighborhoodType, NeighborhoodSelectionMethod, MinimumNumberOfNeighbors!, MaximumNumberOfNeighbors!, DistanceUnit!, MinimumSearchDistance!, MaximumSearchDistance!, NumberOfNeighborsIncrement!, SearchDistanceIncrement!, NumberOfIncrements!, NumberOfNeighbors!, DistanceBand!, NumberOfNeighborsGolden!, NumberOfNeighborsManual!, NumberOfNeighborsDefined!, DistanceGolden!, DistanceManual!, DistanceDefined!, PredictionLocations!, ExplanatoryVariablesToMatch!, OutputPredictedFeatures!, RobustPrediction!, LocalWeightingScheme!, OutputTable!, CoefficientRasterWorkspace!, Scale!, CoefficientRasterLayers!, OutputLayerGroup! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The feature class containing the dependent and explanatory variables.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Dependent Variable</para>
		/// <para>The numeric field containing the observed values that will be modeled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object DependentVariable { get; set; }

		/// <summary>
		/// <para>Model Type</para>
		/// <para>Specifies the regression model based on the values of the dependent variable. Currently, only continuous data is supported, and the parameter is hidden in the Geoprocessing pane. Do not use categorical, count, or binary dependent variables.</para>
		/// <para>Continuous—The dependent variable represents continuous values. This is the default.</para>
		/// <para><see cref="ModelTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ModelType { get; set; } = "CONTINUOUS";

		/// <summary>
		/// <para>Explanatory Variables</para>
		/// <para>A list of fields that will be used as independent explanatory variables in the regression model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ExplanatoryVariables { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The new feature class containing the coefficients, residuals, and significance levels of the MGWR model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Neighborhood Type</para>
		/// <para>Specifies whether the neighborhood will be a fixed distance or allowed to vary spatially depending on the density of the features.</para>
		/// <para>Number of Neighbors— The neighborhood size will be a specified number of closest neighbors for each feature. Where features are dense, the spatial extent of the neighborhood will be smaller; where features are sparse, the spatial extent of the neighborhood will be larger.</para>
		/// <para>Distance Band—The neighborhood size will be a constant or fixed distance for each feature.</para>
		/// <para><see cref="NeighborhoodTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object NeighborhoodType { get; set; }

		/// <summary>
		/// <para>Neighborhood Selection Method</para>
		/// <para>Specifies how the neighborhood size will be determined.</para>
		/// <para>Golden Search—An optimal distance or number of neighbors will be identified by minimizing the AICc value using the Golden Search algorithm.</para>
		/// <para>Manual Intervals—A distance or number of neighbors will be identified by testing a range of values and choosing the value with the smallest AICc. If the Neighborhood Type parameter is set to Distance Band, the minimum value of this range is provided by the Minimum search distance parameter. The minimum value is then incremented by the value specified in the Search Distance Increment parameter. This is repeated the number of times specified by the Number of Increments parameter. If the Neighborhood Type parameter is set to Number of Neighbors, the minimum value, increment size, and number of increments are provided in the Minimum Number of Neighbors, Number of Neighbors Increment, and Number of Increments parameters, respectively.</para>
		/// <para>User Defined— The neighborhood size will be specified by either the Number of Neighbors parameter or the Distance Band parameter.</para>
		/// <para><see cref="NeighborhoodSelectionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object NeighborhoodSelectionMethod { get; set; }

		/// <summary>
		/// <para>Minimum Number of Neighbors</para>
		/// <para>The minimum number of neighbors that each feature will include in its calculation. It is recommended that you use at least 30 neighbors.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MinimumNumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Maximum Number of Neighbors</para>
		/// <para>The maximum number of neighbors that each feature will include in its calculations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MaximumNumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Distance Unit</para>
		/// <para>Specifies the unit of distance that will be used to measure the distances between features.</para>
		/// <para>US Survey Feet—Distances will be measured in US survey feet.</para>
		/// <para>Meters—Distances will be measured in meters.</para>
		/// <para>Kilometers—Distances will be measured in kilometers.</para>
		/// <para>US Survey Miles—Distances will be measured in US survey miles.</para>
		/// <para><see cref="DistanceUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DistanceUnit { get; set; }

		/// <summary>
		/// <para>Minimum Search Distance</para>
		/// <para>The minimum search distance that will be applied to every explanatory variable. It is recommended that you provide a minimum distance that includes at least 30 neighbors for each feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MinimumSearchDistance { get; set; }

		/// <summary>
		/// <para>Maximum Search Distance</para>
		/// <para>The maximum neighborhood search distance that will be applied to all variables.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaximumSearchDistance { get; set; }

		/// <summary>
		/// <para>Number of Neighbors Increment</para>
		/// <para>The number of neighbors by which manual intervals will increase for each neighborhood test.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumberOfNeighborsIncrement { get; set; }

		/// <summary>
		/// <para>Search Distance Increment</para>
		/// <para>The distance by which manual intervals will increase for each neighborhood test.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SearchDistanceIncrement { get; set; }

		/// <summary>
		/// <para>Number of Increments</para>
		/// <para>The number of neighborhood sizes to test when using manual intervals. The first neighborhood size is the value of the Minimum Number of Neighbors or Minimum Search Distance parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 20)]
		public object? NumberOfIncrements { get; set; }

		/// <summary>
		/// <para>Number of Neighbors</para>
		/// <para>The number of neighbors that will be used for the user-defined neighborhood type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Distance Band</para>
		/// <para>The size of the distance band that will be used for the user-defined neighborhood type. All features within this distance will be included as neighbors in the local models.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? DistanceBand { get; set; }

		/// <summary>
		/// <para>Number of Neighbors for Golden Search</para>
		/// <para>The customized Golden Search options for individual explanatory variables. For each explanatory variable to be customized, provide the variable, the minimum number of neighbors, and the maximum number of neighbors in the columns.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Customized Neighborhood Options")]
		public object? NumberOfNeighborsGolden { get; set; }

		/// <summary>
		/// <para>Number of Neighbors for Manual Intervals</para>
		/// <para>The customized manual intervals options for individual explanatory variables. For each explanatory variable to be customized, provide the minimum number of neighbors, number of neighbors increment, and number of increments in the columns.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Customized Neighborhood Options")]
		public object? NumberOfNeighborsManual { get; set; }

		/// <summary>
		/// <para>User Defined Number of Neighbors</para>
		/// <para>The customized user-defined options for individual explanatory variables. For each explanatory variable to be customized, provide the number of neighbors.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Customized Neighborhood Options")]
		public object? NumberOfNeighborsDefined { get; set; }

		/// <summary>
		/// <para>Search Distance for Golden Search</para>
		/// <para>The customized Golden Search options for individual explanatory variables. For each explanatory variable to be customized, provide the variable, the minimum search distance, and the maximum search distance in the columns.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Customized Neighborhood Options")]
		public object? DistanceGolden { get; set; }

		/// <summary>
		/// <para>Search Distance for Manual Intervals</para>
		/// <para>The customized manual intervals options for individual explanatory variables. For each variable to be customized, provide the variable, the minimum search distance, search distance increments, and number of increments in the columns.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Customized Neighborhood Options")]
		public object? DistanceManual { get; set; }

		/// <summary>
		/// <para>User Defined Search Distance</para>
		/// <para>The customized user-defined options for individual explanatory variables. For each variable to be customized, provide the variable and the distance band in the columns.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Customized Neighborhood Options")]
		public object? DistanceDefined { get; set; }

		/// <summary>
		/// <para>Prediction Locations</para>
		/// <para>A feature class with the locations where estimates will be computed. Each feature in this dataset should contain a value for every explanatory variables specified. The dependent variable for these features will be estimated using the model calibrated for the input feature class data. These feature locations should be close to (within 115 percent of the extent) or within the same study area as the input features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		[Category("Prediction Options")]
		public object? PredictionLocations { get; set; }

		/// <summary>
		/// <para>Explanatory Variables to Match</para>
		/// <para>The explanatory variables from the prediction locations that match corresponding explanatory variables from the input features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Prediction Options")]
		public object? ExplanatoryVariablesToMatch { get; set; }

		/// <summary>
		/// <para>Output Predicted Features</para>
		/// <para>The output feature class that will receive dependent variable estimates for every prediction location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Prediction Options")]
		public object? OutputPredictedFeatures { get; set; }

		/// <summary>
		/// <para>Robust Prediction</para>
		/// <para>Specifies the features that will be used in the prediction calculations.</para>
		/// <para>Checked—Features with values greater than three standard deviations from the mean (value outliers) and features with weights of 0 (spatial outliers) will be excluded from the prediction calculations but will receive predictions in the output feature class. This is the default.</para>
		/// <para>Unchecked—Every feature will be used in the prediction calculations.</para>
		/// <para><see cref="RobustPredictionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Prediction Options")]
		public object? RobustPrediction { get; set; } = "true";

		/// <summary>
		/// <para>Local Weighting Scheme</para>
		/// <para>Specifies the kernel type that will be used to provide the spatial weighting in the model. The kernel defines how each feature is related to other features within its neighborhood.</para>
		/// <para>Bisquare—A weight of zero will be assigned to any feature outside the neighborhood specified. This is the default.</para>
		/// <para>Gaussian—All features will receive weights, but weights become exponentially smaller the farther away they are from the target feature.</para>
		/// <para><see cref="LocalWeightingSchemeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object? LocalWeightingScheme { get; set; } = "BISQUARE";

		/// <summary>
		/// <para>Output Neighborhood Table</para>
		/// <para>A table containing the output statistics of the MGWR model. A bar chart of estimated bandwidths or numbers of neighbors is included with the output.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Additional Options")]
		public object? OutputTable { get; set; }

		/// <summary>
		/// <para>Coefficient Raster Workspace</para>
		/// <para>The workspace where the coefficient rasters will be created. When this workspace is provided, rasters are created for the intercept and every explanatory variable. This parameter is only available with a Desktop Advanced license. If a directory is provided, the rasters will be TIFF (.tif) raster type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEWorkspace()]
		[Category("Additional Options")]
		public object? CoefficientRasterWorkspace { get; set; }

		/// <summary>
		/// <para>Scale Data</para>
		/// <para>Specifies whether the values of the explanatory and dependent variables will be scaled to have mean zero and standard deviation one prior to fitting the model.</para>
		/// <para>Checked—The values of the variables will be scaled. The results will contain scaled and unscaled versions of the explanatory variable coefficients.</para>
		/// <para>Unchecked—The values of the variables will not be scaled. All coefficients will be unscaled and in original data units.</para>
		/// <para><see cref="ScaleEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Scale { get; set; } = "true";

		/// <summary>
		/// <para>Coefficient Raster Layers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? CoefficientRasterLayers { get; set; }

		/// <summary>
		/// <para>Output Layer Group</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPGroupLayer()]
		public object? OutputLayerGroup { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MGWR SetEnviroment(object? cellSize = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? snapRaster = null )
		{
			base.SetEnv(cellSize: cellSize, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, snapRaster: snapRaster);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Model Type</para>
		/// </summary>
		public enum ModelTypeEnum 
		{
			/// <summary>
			/// <para>Continuous—The dependent variable represents continuous values. This is the default.</para>
			/// </summary>
			[GPValue("CONTINUOUS")]
			[Description("Continuous")]
			Continuous,

		}

		/// <summary>
		/// <para>Neighborhood Type</para>
		/// </summary>
		public enum NeighborhoodTypeEnum 
		{
			/// <summary>
			/// <para>Number of Neighbors— The neighborhood size will be a specified number of closest neighbors for each feature. Where features are dense, the spatial extent of the neighborhood will be smaller; where features are sparse, the spatial extent of the neighborhood will be larger.</para>
			/// </summary>
			[GPValue("NUMBER_OF_NEIGHBORS")]
			[Description("Number of Neighbors")]
			Number_of_Neighbors,

			/// <summary>
			/// <para>Distance Band—The neighborhood size will be a constant or fixed distance for each feature.</para>
			/// </summary>
			[GPValue("DISTANCE_BAND")]
			[Description("Distance Band")]
			Distance_Band,

		}

		/// <summary>
		/// <para>Neighborhood Selection Method</para>
		/// </summary>
		public enum NeighborhoodSelectionMethodEnum 
		{
			/// <summary>
			/// <para>Golden Search—An optimal distance or number of neighbors will be identified by minimizing the AICc value using the Golden Search algorithm.</para>
			/// </summary>
			[GPValue("GOLDEN_SEARCH")]
			[Description("Golden Search")]
			Golden_Search,

			/// <summary>
			/// <para>Manual Intervals—A distance or number of neighbors will be identified by testing a range of values and choosing the value with the smallest AICc. If the Neighborhood Type parameter is set to Distance Band, the minimum value of this range is provided by the Minimum search distance parameter. The minimum value is then incremented by the value specified in the Search Distance Increment parameter. This is repeated the number of times specified by the Number of Increments parameter. If the Neighborhood Type parameter is set to Number of Neighbors, the minimum value, increment size, and number of increments are provided in the Minimum Number of Neighbors, Number of Neighbors Increment, and Number of Increments parameters, respectively.</para>
			/// </summary>
			[GPValue("MANUAL_INTERVALS")]
			[Description("Manual Intervals")]
			Manual_Intervals,

			/// <summary>
			/// <para>User Defined— The neighborhood size will be specified by either the Number of Neighbors parameter or the Distance Band parameter.</para>
			/// </summary>
			[GPValue("USER_DEFINED")]
			[Description("User Defined")]
			User_Defined,

		}

		/// <summary>
		/// <para>Distance Unit</para>
		/// </summary>
		public enum DistanceUnitEnum 
		{
			/// <summary>
			/// <para>US Survey Feet—Distances will be measured in US survey feet.</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("US Survey Feet")]
			US_Survey_Feet,

			/// <summary>
			/// <para>Meters—Distances will be measured in meters.</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Kilometers—Distances will be measured in kilometers.</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>US Survey Miles—Distances will be measured in US survey miles.</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("US Survey Miles")]
			US_Survey_Miles,

		}

		/// <summary>
		/// <para>Robust Prediction</para>
		/// </summary>
		public enum RobustPredictionEnum 
		{
			/// <summary>
			/// <para>Checked—Features with values greater than three standard deviations from the mean (value outliers) and features with weights of 0 (spatial outliers) will be excluded from the prediction calculations but will receive predictions in the output feature class. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ROBUST")]
			ROBUST,

			/// <summary>
			/// <para>Unchecked—Every feature will be used in the prediction calculations.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NON_ROBUST")]
			NON_ROBUST,

		}

		/// <summary>
		/// <para>Local Weighting Scheme</para>
		/// </summary>
		public enum LocalWeightingSchemeEnum 
		{
			/// <summary>
			/// <para>Gaussian—All features will receive weights, but weights become exponentially smaller the farther away they are from the target feature.</para>
			/// </summary>
			[GPValue("GAUSSIAN")]
			[Description("Gaussian")]
			Gaussian,

			/// <summary>
			/// <para>Bisquare—A weight of zero will be assigned to any feature outside the neighborhood specified. This is the default.</para>
			/// </summary>
			[GPValue("BISQUARE")]
			[Description("Bisquare")]
			Bisquare,

		}

		/// <summary>
		/// <para>Scale Data</para>
		/// </summary>
		public enum ScaleEnum 
		{
			/// <summary>
			/// <para>Checked—The values of the variables will be scaled. The results will contain scaled and unscaled versions of the explanatory variable coefficients.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SCALE_DATA")]
			SCALE_DATA,

			/// <summary>
			/// <para>Unchecked—The values of the variables will not be scaled. All coefficients will be unscaled and in original data units.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SCALE_DATA")]
			NO_SCALE_DATA,

		}

#endregion
	}
}
