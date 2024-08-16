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
	/// <para>Geographically Weighted Regression (GWR)</para>
	/// <para>Performs Geographically Weighted Regression (GWR), which is a local form of linear regression that is used to model spatially varying relationships.</para>
	/// </summary>
	public class GWR : AbstractGPProcess
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
		/// <para>Specifies the type of data that will be modeled.</para>
		/// <para>Continuous (Gaussian)— The Dependent Variable value is continuous. The Gaussian model will be used, and the tool will perform ordinary least squares regression.</para>
		/// <para>Binary (Logistic)— The Dependent Variable value represents presence or absence. This can be either conventional 1s and 0s or continuous data that has been coded based on a threshold value. The Logistic regression model will be used.</para>
		/// <para>Count (Poisson)—The Dependent Variable value is discrete and represents events, such as crime counts, disease incidents, or traffic accidents. The Poisson regression model will be used.</para>
		/// <para><see cref="ModelTypeEnum"/></para>
		/// </param>
		/// <param name="ExplanatoryVariables">
		/// <para>Explanatory Variable(s)</para>
		/// <para>A list of fields representing independent explanatory variables in the regression model.</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>The new feature class containing the dependent variable estimates and residuals.</para>
		/// </param>
		/// <param name="NeighborhoodType">
		/// <para>Neighborhood Type</para>
		/// <para>Specifies whether the neighborhood used is constructed as a fixed distance or allowed to vary in spatial extent depending on the density of the features.</para>
		/// <para>Number of neighbors— The neighborhood size is a function of a specified number of neighbors included in calculations for each feature. Where features are dense, the spatial extent of the neighborhood is smaller; where features are sparse, the spatial extent of the neighborhood is larger.</para>
		/// <para>Distance band—The neighborhood size is a constant or fixed distance for each feature.</para>
		/// <para><see cref="NeighborhoodTypeEnum"/></para>
		/// </param>
		/// <param name="NeighborhoodSelectionMethod">
		/// <para>Neighborhood Selection Method</para>
		/// <para>Specifies how the neighborhood size will be determined. The neighborhood selected with the Golden search and Manual intervals options is based on minimizing the AICc value.</para>
		/// <para>Golden search—The tool will identify an optimal distance or number of neighbors based on the characteristics of the data using the golden section search method.</para>
		/// <para>Manual intervals— The neighborhoods tested will be defined by the values specified in the Minimum Number of Neighbors and Number of Neighbors Increment parameters when Number of neighbors is chosen for the Neighborhood Type parameter, or the Minimum Search Distance and Search Distance Increment parameters when Distance band is chosen for the Neighborhood Type parameter, as well as the Number of Increments parameter.</para>
		/// <para>User defined— The neighborhood size will be specified by either the Number of Neighbors or Distance Band parameter.</para>
		/// <para><see cref="NeighborhoodSelectionMethodEnum"/></para>
		/// </param>
		public GWR(object InFeatures, object DependentVariable, object ModelType, object ExplanatoryVariables, object OutputFeatures, object NeighborhoodType, object NeighborhoodSelectionMethod)
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
		/// <para>Tool Display Name : Geographically Weighted Regression (GWR)</para>
		/// </summary>
		public override string DisplayName => "Geographically Weighted Regression (GWR)";

		/// <summary>
		/// <para>Tool Name : GWR</para>
		/// </summary>
		public override string ToolName => "GWR";

		/// <summary>
		/// <para>Tool Excute Name : stats.GWR</para>
		/// </summary>
		public override string ExcuteName => "stats.GWR";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "cellSize", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, DependentVariable, ModelType, ExplanatoryVariables, OutputFeatures, NeighborhoodType, NeighborhoodSelectionMethod, MinimumNumberOfNeighbors, MaximumNumberOfNeighbors, MinimumSearchDistance, MaximumSearchDistance, NumberOfNeighborsIncrement, SearchDistanceIncrement, NumberOfIncrements, NumberOfNeighbors, DistanceBand, PredictionLocations, ExplanatoryVariablesToMatch, OutputPredictedFeatures, RobustPrediction, LocalWeightingScheme, CoefficientRasterWorkspace, CoefficientRasterLayers };

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
		/// <para>Specifies the type of data that will be modeled.</para>
		/// <para>Continuous (Gaussian)— The Dependent Variable value is continuous. The Gaussian model will be used, and the tool will perform ordinary least squares regression.</para>
		/// <para>Binary (Logistic)— The Dependent Variable value represents presence or absence. This can be either conventional 1s and 0s or continuous data that has been coded based on a threshold value. The Logistic regression model will be used.</para>
		/// <para>Count (Poisson)—The Dependent Variable value is discrete and represents events, such as crime counts, disease incidents, or traffic accidents. The Poisson regression model will be used.</para>
		/// <para><see cref="ModelTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ModelType { get; set; } = "CONTINUOUS";

		/// <summary>
		/// <para>Explanatory Variable(s)</para>
		/// <para>A list of fields representing independent explanatory variables in the regression model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ExplanatoryVariables { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The new feature class containing the dependent variable estimates and residuals.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Neighborhood Type</para>
		/// <para>Specifies whether the neighborhood used is constructed as a fixed distance or allowed to vary in spatial extent depending on the density of the features.</para>
		/// <para>Number of neighbors— The neighborhood size is a function of a specified number of neighbors included in calculations for each feature. Where features are dense, the spatial extent of the neighborhood is smaller; where features are sparse, the spatial extent of the neighborhood is larger.</para>
		/// <para>Distance band—The neighborhood size is a constant or fixed distance for each feature.</para>
		/// <para><see cref="NeighborhoodTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object NeighborhoodType { get; set; }

		/// <summary>
		/// <para>Neighborhood Selection Method</para>
		/// <para>Specifies how the neighborhood size will be determined. The neighborhood selected with the Golden search and Manual intervals options is based on minimizing the AICc value.</para>
		/// <para>Golden search—The tool will identify an optimal distance or number of neighbors based on the characteristics of the data using the golden section search method.</para>
		/// <para>Manual intervals— The neighborhoods tested will be defined by the values specified in the Minimum Number of Neighbors and Number of Neighbors Increment parameters when Number of neighbors is chosen for the Neighborhood Type parameter, or the Minimum Search Distance and Search Distance Increment parameters when Distance band is chosen for the Neighborhood Type parameter, as well as the Number of Increments parameter.</para>
		/// <para>User defined— The neighborhood size will be specified by either the Number of Neighbors or Distance Band parameter.</para>
		/// <para><see cref="NeighborhoodSelectionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object NeighborhoodSelectionMethod { get; set; }

		/// <summary>
		/// <para>Minimum Number of Neighbors</para>
		/// <para>The minimum number of neighbors each feature will include in its calculations. It is recommended that you use at least 30 neighbors.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 999)]
		public object MinimumNumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Maximum Number of Neighbors</para>
		/// <para>The maximum number of neighbors (up to 1000) each feature will include in its calculations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 3, Max = 1000)]
		public object MaximumNumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Minimum Search Distance</para>
		/// <para>The minimum neighborhood search distance. It is recommended that you use a distance at which each feature has at least 30 neighbors.</para>
		/// <para><see cref="MinimumSearchDistanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object MinimumSearchDistance { get; set; }

		/// <summary>
		/// <para>Maximum Search Distance</para>
		/// <para>The maximum neighborhood search distance. If a distance results in features with more than 1000 neighbors, the tool will use the first 1000 in calculations for the target feature.</para>
		/// <para><see cref="MaximumSearchDistanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object MaximumSearchDistance { get; set; }

		/// <summary>
		/// <para>Number of Neighbors Increment</para>
		/// <para>The number of neighbors by which manual intervals will increase for each neighborhood test.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 500)]
		public object NumberOfNeighborsIncrement { get; set; }

		/// <summary>
		/// <para>Search Distance Increment</para>
		/// <para>The distance by which manual intervals will increase for each neighborhood test.</para>
		/// <para><see cref="SearchDistanceIncrementEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object SearchDistanceIncrement { get; set; }

		/// <summary>
		/// <para>Number of Increments</para>
		/// <para>The number of neighborhood sizes to test starting with the Minimum Number of Neighbors or Minimum Search Distance parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 20)]
		public object NumberOfIncrements { get; set; }

		/// <summary>
		/// <para>Number of Neighbors</para>
		/// <para>The closest number of neighbors (up to 1000) to consider for each feature. The number must be an integer between 2 and 1000.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 2, Max = 1000)]
		public object NumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Distance Band</para>
		/// <para>The spatial extent of the neighborhood.</para>
		/// <para><see cref="DistanceBandEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object DistanceBand { get; set; }

		/// <summary>
		/// <para>Prediction Locations</para>
		/// <para>A feature class containing features representing locations where estimates will be computed. Each feature in this dataset should contain values for all the explanatory variables specified. The dependent variable for these features will be estimated using the model calibrated for the input feature class data. To be predicted, these feature locations should be within the same study area as the Input Features or be close (within the extent plus 15 percent).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		[Category("Prediction Options")]
		public object PredictionLocations { get; set; }

		/// <summary>
		/// <para>Explanatory Variables to Match</para>
		/// <para>The explanatory variables from the Prediction Locations parameter that match corresponding explanatory variables from the Input Feature Class parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Prediction Options")]
		public object ExplanatoryVariablesToMatch { get; set; }

		/// <summary>
		/// <para>Output Predicted Features</para>
		/// <para>The output feature class that will receive dependent variable estimates for each Prediction Location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Prediction Options")]
		public object OutputPredictedFeatures { get; set; }

		/// <summary>
		/// <para>Robust Prediction</para>
		/// <para>Specifies the features that will be used in prediction calculations.</para>
		/// <para>Checked—Features with values more than three standard deviations from the mean (value outliers) and features with weights of 0 (spatial outliers) will be excluded from prediction calculations but will receive predictions in the output feature class. This is the default.</para>
		/// <para>Unchecked—All features will be used in prediction calculations.</para>
		/// <para><see cref="RobustPredictionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Prediction Options")]
		public object RobustPrediction { get; set; } = "true";

		/// <summary>
		/// <para>Local Weighting Scheme</para>
		/// <para>Specifies the kernel type that will be used to provide the spatial weighting in the model. The kernel defines how each feature is related to other features within its neighborhood.</para>
		/// <para>Bisquare—A weight of 0 will be assigned to any feature outside the neighborhood specified. This is the default.</para>
		/// <para>Gaussian—All features will receive weights, but weights become exponentially smaller the farther away they are from the target feature.</para>
		/// <para><see cref="LocalWeightingSchemeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object LocalWeightingScheme { get; set; } = "BISQUARE";

		/// <summary>
		/// <para>Coefficient Raster Workspace</para>
		/// <para>The workspace where the coefficient rasters will be created. When this workspace is provided, rasters are created for the intercept and every explanatory variable.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEWorkspace()]
		[Category("Additional Options")]
		public object CoefficientRasterWorkspace { get; set; }

		/// <summary>
		/// <para>Coefficient Raster Layers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object CoefficientRasterLayers { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GWR SetEnviroment(object cellSize = null , object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , object workspace = null )
		{
			base.SetEnv(cellSize: cellSize, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Model Type</para>
		/// </summary>
		public enum ModelTypeEnum 
		{
			/// <summary>
			/// <para>Continuous (Gaussian)— The Dependent Variable value is continuous. The Gaussian model will be used, and the tool will perform ordinary least squares regression.</para>
			/// </summary>
			[GPValue("CONTINUOUS")]
			[Description("Continuous (Gaussian)")]
			CONTINUOUS,

			/// <summary>
			/// <para>Binary (Logistic)— The Dependent Variable value represents presence or absence. This can be either conventional 1s and 0s or continuous data that has been coded based on a threshold value. The Logistic regression model will be used.</para>
			/// </summary>
			[GPValue("BINARY")]
			[Description("Binary (Logistic)")]
			BINARY,

			/// <summary>
			/// <para>Count (Poisson)—The Dependent Variable value is discrete and represents events, such as crime counts, disease incidents, or traffic accidents. The Poisson regression model will be used.</para>
			/// </summary>
			[GPValue("COUNT")]
			[Description("Count (Poisson)")]
			COUNT,

		}

		/// <summary>
		/// <para>Neighborhood Type</para>
		/// </summary>
		public enum NeighborhoodTypeEnum 
		{
			/// <summary>
			/// <para>Number of neighbors— The neighborhood size is a function of a specified number of neighbors included in calculations for each feature. Where features are dense, the spatial extent of the neighborhood is smaller; where features are sparse, the spatial extent of the neighborhood is larger.</para>
			/// </summary>
			[GPValue("NUMBER_OF_NEIGHBORS")]
			[Description("Number of neighbors")]
			Number_of_neighbors,

			/// <summary>
			/// <para>Distance band—The neighborhood size is a constant or fixed distance for each feature.</para>
			/// </summary>
			[GPValue("DISTANCE_BAND")]
			[Description("Distance band")]
			Distance_band,

		}

		/// <summary>
		/// <para>Neighborhood Selection Method</para>
		/// </summary>
		public enum NeighborhoodSelectionMethodEnum 
		{
			/// <summary>
			/// <para>Golden search—The tool will identify an optimal distance or number of neighbors based on the characteristics of the data using the golden section search method.</para>
			/// </summary>
			[GPValue("GOLDEN_SEARCH")]
			[Description("Golden search")]
			Golden_search,

			/// <summary>
			/// <para>Manual intervals— The neighborhoods tested will be defined by the values specified in the Minimum Number of Neighbors and Number of Neighbors Increment parameters when Number of neighbors is chosen for the Neighborhood Type parameter, or the Minimum Search Distance and Search Distance Increment parameters when Distance band is chosen for the Neighborhood Type parameter, as well as the Number of Increments parameter.</para>
			/// </summary>
			[GPValue("MANUAL_INTERVALS")]
			[Description("Manual intervals")]
			Manual_intervals,

			/// <summary>
			/// <para>User defined— The neighborhood size will be specified by either the Number of Neighbors or Distance Band parameter.</para>
			/// </summary>
			[GPValue("USER_DEFINED")]
			[Description("User defined")]
			User_defined,

		}

		/// <summary>
		/// <para>Minimum Search Distance</para>
		/// </summary>
		public enum MinimumSearchDistanceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

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

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

		/// <summary>
		/// <para>Maximum Search Distance</para>
		/// </summary>
		public enum MaximumSearchDistanceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

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

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

		/// <summary>
		/// <para>Search Distance Increment</para>
		/// </summary>
		public enum SearchDistanceIncrementEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

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

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

		/// <summary>
		/// <para>Distance Band</para>
		/// </summary>
		public enum DistanceBandEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

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

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

		/// <summary>
		/// <para>Robust Prediction</para>
		/// </summary>
		public enum RobustPredictionEnum 
		{
			/// <summary>
			/// <para>Checked—Features with values more than three standard deviations from the mean (value outliers) and features with weights of 0 (spatial outliers) will be excluded from prediction calculations but will receive predictions in the output feature class. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ROBUST")]
			ROBUST,

			/// <summary>
			/// <para>Unchecked—All features will be used in prediction calculations.</para>
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
			/// <para>Bisquare—A weight of 0 will be assigned to any feature outside the neighborhood specified. This is the default.</para>
			/// </summary>
			[GPValue("BISQUARE")]
			[Description("Bisquare")]
			Bisquare,

		}

#endregion
	}
}
