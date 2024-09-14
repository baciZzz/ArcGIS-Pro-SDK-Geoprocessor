using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsServerTools
{
	/// <summary>
	/// <para>Geographically Weighted Regression (GWR)</para>
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
		/// <para>The point feature class containing the dependent and explanatory variables.</para>
		/// </param>
		/// <param name="DependentVariable">
		/// <para>Dependent Variable</para>
		/// <para>The numeric field containing the observed values that will be modeled.</para>
		/// </param>
		/// <param name="ModelType">
		/// <para>Model Type</para>
		/// <para>Specifies the type of data that will be modeled.</para>
		/// <para>Continuous (Gaussian)— The Dependent Variable value is continuous. The Gaussian model will be used, and the tool performs ordinary least squares regression.</para>
		/// <para><see cref="ModelTypeEnum"/></para>
		/// </param>
		/// <param name="ExplanatoryVariables">
		/// <para>Explanatory Variable(s)</para>
		/// <para>A list of fields representing independent explanatory variables in the regression model.</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>The name of the output feature service.</para>
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
		/// <para>Specifies how the neighborhood size will be determined.</para>
		/// <para>User defined— The neighborhood size will be determined by either the Number of Neighbors or Distance Band parameter.</para>
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
		public override string DisplayName() => "Geographically Weighted Regression (GWR)";

		/// <summary>
		/// <para>Tool Name : GWR</para>
		/// </summary>
		public override string ToolName() => "GWR";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.GWR</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.GWR";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoanalytics</para>
		/// </summary>
		public override string ToolboxAlise() => "geoanalytics";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, DependentVariable, ModelType, ExplanatoryVariables, OutputFeatures, NeighborhoodType, NeighborhoodSelectionMethod, NumberOfNeighbors!, DistanceBand!, LocalWeightingScheme!, DataStore!, Output! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The point feature class containing the dependent and explanatory variables.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple")]
		[PortalType("DataStoreCatalogLayer")]
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
		/// <para>Continuous (Gaussian)— The Dependent Variable value is continuous. The Gaussian model will be used, and the tool performs ordinary least squares regression.</para>
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
		/// <para>The name of the output feature service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
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
		/// <para>Specifies how the neighborhood size will be determined.</para>
		/// <para>User defined— The neighborhood size will be determined by either the Number of Neighbors or Distance Band parameter.</para>
		/// <para><see cref="NeighborhoodSelectionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object NeighborhoodSelectionMethod { get; set; } = "USER_DEFINED";

		/// <summary>
		/// <para>Number of Neighbors</para>
		/// <para>The closest number of neighbors (up to 1000) to consider for each feature. The number must be an integer between 2 and 1000.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 5000)]
		public object? NumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Distance Band</para>
		/// <para>The spatial extent of the neighborhood.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? DistanceBand { get; set; }

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
		public object? LocalWeightingScheme { get; set; } = "BISQUARE";

		/// <summary>
		/// <para>Data Store</para>
		/// <para>Specifies the ArcGIS Data Store where the output will be saved. The default is Spatiotemporal big data store. All results stored in a spatiotemporal big data store will be stored in WGS84. Results stored in a relational data store will maintain their coordinate system.</para>
		/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
		/// <para>Relational data store—Output will be stored in a relational data store.</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Data Store")]
		public object? DataStore { get; set; } = "SPATIOTEMPORAL_DATA_STORE";

		/// <summary>
		/// <para>Output</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object? Output { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GWR SetEnviroment(object? extent = null, object? outputCoordinateSystem = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Model Type</para>
		/// </summary>
		public enum ModelTypeEnum 
		{
			/// <summary>
			/// <para>Continuous (Gaussian)— The Dependent Variable value is continuous. The Gaussian model will be used, and the tool performs ordinary least squares regression.</para>
			/// </summary>
			[GPValue("CONTINUOUS")]
			[Description("Continuous (Gaussian)")]
			CONTINUOUS,

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
			/// <para>User defined— The neighborhood size will be determined by either the Number of Neighbors or Distance Band parameter.</para>
			/// </summary>
			[GPValue("USER_DEFINED")]
			[Description("User defined")]
			User_defined,

		}

		/// <summary>
		/// <para>Local Weighting Scheme</para>
		/// </summary>
		public enum LocalWeightingSchemeEnum 
		{
			/// <summary>
			/// <para>Bisquare—A weight of 0 will be assigned to any feature outside the neighborhood specified. This is the default.</para>
			/// </summary>
			[GPValue("BISQUARE")]
			[Description("Bisquare")]
			Bisquare,

			/// <summary>
			/// <para>Gaussian—All features will receive weights, but weights become exponentially smaller the farther away they are from the target feature.</para>
			/// </summary>
			[GPValue("GAUSSIAN")]
			[Description("Gaussian")]
			Gaussian,

		}

		/// <summary>
		/// <para>Data Store</para>
		/// </summary>
		public enum DataStoreEnum 
		{
			/// <summary>
			/// <para>Relational data store—Output will be stored in a relational data store.</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("Relational data store")]
			Relational_data_store,

			/// <summary>
			/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("Spatiotemporal big data store")]
			Spatiotemporal_big_data_store,

		}

#endregion
	}
}
