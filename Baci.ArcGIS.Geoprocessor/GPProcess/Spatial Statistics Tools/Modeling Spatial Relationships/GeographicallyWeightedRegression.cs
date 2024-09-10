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
	/// <para>Performs Geographically Weighted Regression (GWR), a local form of linear regression used to model spatially varying relationships.</para>
	/// </summary>
	[Obsolete()]
	public class GeographicallyWeightedRegression : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input features</para>
		/// <para>The feature class containing the dependent and independent variables.</para>
		/// </param>
		/// <param name="DependentField">
		/// <para>Dependent variable</para>
		/// <para>The numeric field containing the values that will be modeled.</para>
		/// </param>
		/// <param name="ExplanatoryField">
		/// <para>Explanatory variable(s)</para>
		/// <para>A list of fields representing independent explanatory variables in the regression model.</para>
		/// </param>
		/// <param name="OutFeatureclass">
		/// <para>Output feature class</para>
		/// <para>The output feature class that will receive dependent variable estimates and residuals.</para>
		/// </param>
		/// <param name="KernelType">
		/// <para>Kernel type</para>
		/// <para>Specifies whether the kernel is constructed as a fixed distance, or if it is allowed to vary in extent as a function of feature density.</para>
		/// <para>Fixed—The spatial context (the Gaussian kernel) used to solve each local regression analysis is a fixed distance.</para>
		/// <para>Adaptive—The spatial context (the Gaussian kernel) is a function of a specified number of neighbors. Where feature distribution is dense, the spatial context is smaller; where feature distribution is sparse, the spatial context is larger.</para>
		/// <para><see cref="KernelTypeEnum"/></para>
		/// </param>
		/// <param name="BandwidthMethod">
		/// <para>Bandwidth method</para>
		/// <para>Specifies how the extent of the kernel will be determined. When Akaike Information Criterion or Cross Validation is selected, the tool will find the optimal distance or number of neighbors. Typically, you will select either Akaike Information Criterion or Cross Validation when you aren&apos;t sure what to use for the Distance or Number of neighbors parameter. Once the tool determines the optimal distance or number of neighbors, however, you&apos;ll use the As specified below option.</para>
		/// <para>Akaike Information Criterion—The extent of the kernel is determined using the Akaike Information Criterion.</para>
		/// <para>Cross Validation—The extent of the kernel is determined using cross validation.</para>
		/// <para>As specified below—The extent of the kernel is determined by a fixed distance or a fixed number of neighbors. You must specify a value for either the Distance or Number of neighbors parameters.</para>
		/// <para><see cref="BandwidthMethodEnum"/></para>
		/// </param>
		public GeographicallyWeightedRegression(object InFeatures, object DependentField, object ExplanatoryField, object OutFeatureclass, object KernelType, object BandwidthMethod)
		{
			this.InFeatures = InFeatures;
			this.DependentField = DependentField;
			this.ExplanatoryField = ExplanatoryField;
			this.OutFeatureclass = OutFeatureclass;
			this.KernelType = KernelType;
			this.BandwidthMethod = BandwidthMethod;
		}

		/// <summary>
		/// <para>Tool Display Name : Geographically Weighted Regression (GWR)</para>
		/// </summary>
		public override string DisplayName() => "Geographically Weighted Regression (GWR)";

		/// <summary>
		/// <para>Tool Name : GeographicallyWeightedRegression</para>
		/// </summary>
		public override string ToolName() => "GeographicallyWeightedRegression";

		/// <summary>
		/// <para>Tool Excute Name : stats.GeographicallyWeightedRegression</para>
		/// </summary>
		public override string ExcuteName() => "stats.GeographicallyWeightedRegression";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, DependentField, ExplanatoryField, OutFeatureclass, KernelType, BandwidthMethod, Distance, NumberOfNeighbors, WeightField, CoefficientRasterWorkspace, CellSize, InPredictionLocations, PredictionExplanatoryField, OutPredictionFeatureclass, OutTable, OutRegressionRasters };

		/// <summary>
		/// <para>Input features</para>
		/// <para>The feature class containing the dependent and independent variables.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Dependent variable</para>
		/// <para>The numeric field containing the values that will be modeled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object DependentField { get; set; }

		/// <summary>
		/// <para>Explanatory variable(s)</para>
		/// <para>A list of fields representing independent explanatory variables in the regression model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object ExplanatoryField { get; set; }

		/// <summary>
		/// <para>Output feature class</para>
		/// <para>The output feature class that will receive dependent variable estimates and residuals.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureclass { get; set; }

		/// <summary>
		/// <para>Kernel type</para>
		/// <para>Specifies whether the kernel is constructed as a fixed distance, or if it is allowed to vary in extent as a function of feature density.</para>
		/// <para>Fixed—The spatial context (the Gaussian kernel) used to solve each local regression analysis is a fixed distance.</para>
		/// <para>Adaptive—The spatial context (the Gaussian kernel) is a function of a specified number of neighbors. Where feature distribution is dense, the spatial context is smaller; where feature distribution is sparse, the spatial context is larger.</para>
		/// <para><see cref="KernelTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object KernelType { get; set; } = "FIXED";

		/// <summary>
		/// <para>Bandwidth method</para>
		/// <para>Specifies how the extent of the kernel will be determined. When Akaike Information Criterion or Cross Validation is selected, the tool will find the optimal distance or number of neighbors. Typically, you will select either Akaike Information Criterion or Cross Validation when you aren&apos;t sure what to use for the Distance or Number of neighbors parameter. Once the tool determines the optimal distance or number of neighbors, however, you&apos;ll use the As specified below option.</para>
		/// <para>Akaike Information Criterion—The extent of the kernel is determined using the Akaike Information Criterion.</para>
		/// <para>Cross Validation—The extent of the kernel is determined using cross validation.</para>
		/// <para>As specified below—The extent of the kernel is determined by a fixed distance or a fixed number of neighbors. You must specify a value for either the Distance or Number of neighbors parameters.</para>
		/// <para><see cref="BandwidthMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BandwidthMethod { get; set; } = "AICc";

		/// <summary>
		/// <para>Distance</para>
		/// <para>The distance to use when the Kernel type parameter is set to Fixed and the Bandwidth method parameter is set to As specified below.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 1.7976900000000001e+308)]
		public object Distance { get; set; }

		/// <summary>
		/// <para>Number of neighbors</para>
		/// <para>The exact number of neighbors to include in the local bandwidth of the Gaussian kernel when the Kernel type parameter is set to Adaptive and the Bandwidth method parameter is set to As specified below.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 1000)]
		public object NumberOfNeighbors { get; set; } = "30";

		/// <summary>
		/// <para>Weights</para>
		/// <para>The numeric field containing a spatial weighting for individual features. This weight field allows some features to be more important in the model calibration process than others. This is useful when the number of samples taken at different locations varies, values for the dependent and independent variables are averaged, and places with more samples are more reliable (should be weighted higher). If you have an average of 25 different samples for one location but an average of only 2 samples for another location, for example, you can use the number of samples as your weight field so that locations with more samples have a larger influence on model calibration than locations with few samples.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object WeightField { get; set; }

		/// <summary>
		/// <para>Coefficient raster workspace</para>
		/// <para>The full path to the workspace where the coefficient rasters will be created. When this workspace is provided, rasters are created for the intercept and every explanatory variable.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEWorkspace()]
		[Category("Additional Parameters (Optional)")]
		public object CoefficientRasterWorkspace { get; set; }

		/// <summary>
		/// <para>Output cell size</para>
		/// <para>The cell size (a number) or reference to the cell size (a path to a raster dataset) to use when creating the coefficient rasters.</para>
		/// <para>The default cell size is the shortest of the width or height of the extent specified in the geoprocessing environment output coordinate system, divided by 250.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[analysis_cell_size()]
		[Category("Additional Parameters (Optional)")]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Prediction locations</para>
		/// <para>A feature class containing features representing locations where estimates should be computed. Each feature in this dataset should contain values for all of the explanatory variables specified; the dependent variable for these features will be estimated using the model calibrated for the input feature class data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		[Category("Additional Parameters (Optional)")]
		public object InPredictionLocations { get; set; }

		/// <summary>
		/// <para>Prediction explanatory variable(s)</para>
		/// <para>A list of fields representing explanatory variables in the Prediction locations feature class. These field names should be provided in the same order (a one-to-one correspondence) as those listed for the input feature class Explanatory variables parameter. If no prediction explanatory variables are given, the output prediction feature class will only contain computed coefficient values for each prediction location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		[Category("Additional Parameters (Optional)")]
		public object PredictionExplanatoryField { get; set; }

		/// <summary>
		/// <para>Output prediction feature class</para>
		/// <para>The output feature class to receive dependent variable estimates for each feature in the Prediction locations feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Additional Parameters (Optional)")]
		public object OutPredictionFeatureclass { get; set; }

		/// <summary>
		/// <para>Output table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETable()]
		public object OutTable { get; set; }

		/// <summary>
		/// <para>Output regression rasters</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRasterLayer()]
		public object OutRegressionRasters { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GeographicallyWeightedRegression SetEnviroment(object cellSize = null , object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , object workspace = null )
		{
			base.SetEnv(cellSize: cellSize, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Kernel type</para>
		/// </summary>
		public enum KernelTypeEnum 
		{
			/// <summary>
			/// <para>Fixed—The spatial context (the Gaussian kernel) used to solve each local regression analysis is a fixed distance.</para>
			/// </summary>
			[GPValue("FIXED")]
			[Description("Fixed")]
			Fixed,

			/// <summary>
			/// <para>Adaptive—The spatial context (the Gaussian kernel) is a function of a specified number of neighbors. Where feature distribution is dense, the spatial context is smaller; where feature distribution is sparse, the spatial context is larger.</para>
			/// </summary>
			[GPValue("ADAPTIVE")]
			[Description("Adaptive")]
			Adaptive,

		}

		/// <summary>
		/// <para>Bandwidth method</para>
		/// </summary>
		public enum BandwidthMethodEnum 
		{
			/// <summary>
			/// <para>Akaike Information Criterion—The extent of the kernel is determined using the Akaike Information Criterion.</para>
			/// </summary>
			[GPValue("AICc")]
			[Description("Akaike Information Criterion")]
			Akaike_Information_Criterion,

			/// <summary>
			/// <para>Cross Validation—The extent of the kernel is determined using cross validation.</para>
			/// </summary>
			[GPValue("CV")]
			[Description("Cross Validation")]
			Cross_Validation,

			/// <summary>
			/// <para>As specified below—The extent of the kernel is determined by a fixed distance or a fixed number of neighbors. You must specify a value for either the Distance or Number of neighbors parameters.</para>
			/// </summary>
			[GPValue("BANDWIDTH_PARAMETER")]
			[Description("As specified below")]
			As_specified_below,

		}

#endregion
	}
}
