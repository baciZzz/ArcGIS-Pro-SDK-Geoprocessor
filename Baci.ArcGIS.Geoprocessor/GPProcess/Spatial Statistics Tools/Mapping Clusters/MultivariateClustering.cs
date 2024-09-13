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
	/// <para>Multivariate Clustering</para>
	/// <para>Multivariate Clustering</para>
	/// <para>Finds natural clusters of features based solely on feature attribute values.</para>
	/// </summary>
	public class MultivariateClustering : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The feature class or feature layer for which clusters will be created.</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>The output feature class that will be created containing all features, the analysis fields specified, and a field indicating to which cluster each feature belongs.</para>
		/// </param>
		/// <param name="AnalysisFields">
		/// <para>Analysis Fields</para>
		/// <para>A list of fields that will be used to distinguish one cluster from another.</para>
		/// </param>
		public MultivariateClustering(object InFeatures, object OutputFeatures, object AnalysisFields)
		{
			this.InFeatures = InFeatures;
			this.OutputFeatures = OutputFeatures;
			this.AnalysisFields = AnalysisFields;
		}

		/// <summary>
		/// <para>Tool Display Name : Multivariate Clustering</para>
		/// </summary>
		public override string DisplayName() => "Multivariate Clustering";

		/// <summary>
		/// <para>Tool Name : MultivariateClustering</para>
		/// </summary>
		public override string ToolName() => "MultivariateClustering";

		/// <summary>
		/// <para>Tool Excute Name : stats.MultivariateClustering</para>
		/// </summary>
		public override string ExcuteName() => "stats.MultivariateClustering";

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
		public override string[] ValidEnvironments() => new string[] { "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "randomGenerator", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutputFeatures, AnalysisFields, ClusteringMethod!, InitializationMethod!, InitializationField!, NumberOfClusters!, OutputTable! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The feature class or feature layer for which clusters will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The output feature class that will be created containing all features, the analysis fields specified, and a field indicating to which cluster each feature belongs.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Analysis Fields</para>
		/// <para>A list of fields that will be used to distinguish one cluster from another.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object AnalysisFields { get; set; }

		/// <summary>
		/// <para>Clustering Method</para>
		/// <para>Specifies the clustering algorithm that will be used.</para>
		/// <para>The K means and K medoids options generally produce similar results. However, K medoids is more robust to noise and outliers in the Input Features parameter value. K means is generally faster than K medoids and is recommended for large data sets.</para>
		/// <para>K means—The Input Features parameter value will be clustered using the K means algorithm. This is the default.</para>
		/// <para>K medoids—The Input Features parameter value will be clustered using the K medoids algorithm.</para>
		/// <para><see cref="ClusteringMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ClusteringMethod { get; set; } = "K_MEANS";

		/// <summary>
		/// <para>Initialization Method</para>
		/// <para>Specifies how initial seeds used to grow clusters will be obtained. If you indicate you want three clusters, for example, the analysis will begin with three seeds.</para>
		/// <para>Optimized seed locations—Seed features will be selected to optimize analysis results and performance. This is the default.</para>
		/// <para>User defined seed locations—Nonzero entries in the Initialization Field parameter value will be used as starting points to grow clusters.</para>
		/// <para>Random seed locations—Initial seed features will be randomly selected.</para>
		/// <para><see cref="InitializationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? InitializationMethod { get; set; } = "OPTIMIZED_SEED_LOCATIONS";

		/// <summary>
		/// <para>Initialization Field</para>
		/// <para>The numeric field identifying seed features. Features with a value of 1 for this field will be used to grow clusters. Each seed results in a cluster, so at least two seed features must be provided.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object? InitializationField { get; set; }

		/// <summary>
		/// <para>Number of Clusters</para>
		/// <para>The number of clusters that will be created. If you leave this parameter empty, the tool will evaluate the optimal number of clusters by computing a pseudo F-statistic for clustering solutions with 2 through 30 clusters.</para>
		/// <para>This parameter is disabled if the seed locations were provided in an initialization field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumberOfClusters { get; set; }

		/// <summary>
		/// <para>Output Table for Evaluating Number of Clusters</para>
		/// <para>The table containing the pseudo F-statistic for clustering solutions 2 through 30, calculated to evaluate the optimal number of clusters. The chart created from this table can be accessed in the stand-alone tables section of the Contents pane.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutputTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MultivariateClustering SetEnviroment(double? MResolution = null , double? MTolerance = null , object? XYResolution = null , object? XYTolerance = null , object? ZResolution = null , object? ZTolerance = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , bool? qualifiedFieldNames = null , object? randomGenerator = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, randomGenerator: randomGenerator, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Clustering Method</para>
		/// </summary>
		public enum ClusteringMethodEnum 
		{
			/// <summary>
			/// <para>K means—The Input Features parameter value will be clustered using the K means algorithm. This is the default.</para>
			/// </summary>
			[GPValue("K_MEANS")]
			[Description("K means")]
			K_means,

			/// <summary>
			/// <para>K medoids—The Input Features parameter value will be clustered using the K medoids algorithm.</para>
			/// </summary>
			[GPValue("K_MEDOIDS")]
			[Description("K medoids")]
			K_medoids,

		}

		/// <summary>
		/// <para>Initialization Method</para>
		/// </summary>
		public enum InitializationMethodEnum 
		{
			/// <summary>
			/// <para>Optimized seed locations—Seed features will be selected to optimize analysis results and performance. This is the default.</para>
			/// </summary>
			[GPValue("OPTIMIZED_SEED_LOCATIONS")]
			[Description("Optimized seed locations")]
			Optimized_seed_locations,

			/// <summary>
			/// <para>User defined seed locations—Nonzero entries in the Initialization Field parameter value will be used as starting points to grow clusters.</para>
			/// </summary>
			[GPValue("USER_DEFINED_SEED_LOCATIONS")]
			[Description("User defined seed locations")]
			User_defined_seed_locations,

			/// <summary>
			/// <para>Random seed locations—Initial seed features will be randomly selected.</para>
			/// </summary>
			[GPValue("RANDOM_SEED_LOCATIONS")]
			[Description("Random seed locations")]
			Random_seed_locations,

		}

#endregion
	}
}
