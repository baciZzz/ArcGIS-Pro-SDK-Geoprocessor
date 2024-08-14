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
	/// <para>Neighborhood Summary Statistics</para>
	/// <para>Calculates summary  statistics of one or more numeric fields using local neighborhoods around each feature.  The local statistics include mean (average), median, standard deviation, interquartile range, skewness, and quantile imbalance. All statistics can be geographically weighted using kernels to give more influence to neighbors closer to the focal feature.  Various neighborhood types can be used, including distance band, number of neighbors, polygon contiguity, Delaunay triangulation, and spatial weights matrix files (.swm).</para>
	/// <para>Summary statistics are also calculated for the distances to the neighbors of each feature.</para>
	/// </summary>
	public class NeighborhoodSummaryStatistics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The point or polygon features that will be used to calculate the local statistics.</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>The output feature class containing the local statistics as fields. Each statistic of each analysis field will be stored as an individual field.</para>
		/// </param>
		public NeighborhoodSummaryStatistics(object InFeatures, object OutputFeatures)
		{
			this.InFeatures = InFeatures;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Neighborhood Summary Statistics</para>
		/// </summary>
		public override string DisplayName => "Neighborhood Summary Statistics";

		/// <summary>
		/// <para>Tool Name : NeighborhoodSummaryStatistics</para>
		/// </summary>
		public override string ToolName => "NeighborhoodSummaryStatistics";

		/// <summary>
		/// <para>Tool Excute Name : stats.NeighborhoodSummaryStatistics</para>
		/// </summary>
		public override string ExcuteName => "stats.NeighborhoodSummaryStatistics";

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
		public override string[] ValidEnvironments => new string[] { "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutputFeatures, AnalysisFields!, LocalSummaryStatistic!, IncludeFocalFeature!, IgnoreNulls!, NeighborhoodType!, DistanceBand!, NumberOfNeighbors!, WeightsMatrixFile!, LocalWeightingScheme!, KernelBandwidth! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The point or polygon features that will be used to calculate the local statistics.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The output feature class containing the local statistics as fields. Each statistic of each analysis field will be stored as an individual field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Analysis Fields</para>
		/// <para>One or more fields for which local statistics will be calculated. If no analysis fields are provided, only local statistics based on distances to neighbors will be calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		public object? AnalysisFields { get; set; }

		/// <summary>
		/// <para>Local Summary Statistic</para>
		/// <para>Specifies the local summary statistic that will be calculated for each analysis field.</para>
		/// <para>All—All local statistics will be calculated. This is the default.</para>
		/// <para>Mean—The local mean (average) will be calculated.</para>
		/// <para>Median— The local median will be calculated.</para>
		/// <para>Standard deviation—The local standard deviation will be calculated.</para>
		/// <para>Interquartile range— The local interquartile range will be calculated.</para>
		/// <para>Skewness— The local skewness will be calculated.</para>
		/// <para>Quantile imbalance— The local quantile imbalance will be calculated.</para>
		/// <para><see cref="LocalSummaryStatisticEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LocalSummaryStatistic { get; set; } = "ALL";

		/// <summary>
		/// <para>Include Focal Feature in Calculations</para>
		/// <para>Specifies whether the focal feature will be included when calculating local statistics for each feature.</para>
		/// <para>Checked—The focal feature and all of its neighbors will be included when calculating local statistics. This is the default.</para>
		/// <para>Unchecked—The focal feature will not be included when calculating local statistics. Only neighbors of the feature will be included.</para>
		/// <para><see cref="IncludeFocalFeatureEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IncludeFocalFeature { get; set; } = "true";

		/// <summary>
		/// <para>Ignore Null Values in Calculations</para>
		/// <para>Specifies whether null values in the analysis fields will be included or ignored in the calculations.</para>
		/// <para>Checked—Null values in the analysis fields will be ignored, and statistics will be calculated using only non-null values. This is the default.</para>
		/// <para>Unchecked—Null values in the analysis fields will be included in the calculations, and any local statistic will be calculated as null if any of the values used in the calculation are null.</para>
		/// <para><see cref="IgnoreNullsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? IgnoreNulls { get; set; } = "true";

		/// <summary>
		/// <para>Neighborhood Type</para>
		/// <para>Specifies how neighbors will be chosen for each input feature. To calculate local statistics, neighboring features must be identified for each input feature, and these neighbors are used to calculate the local statistics for each feature. For point features, the default is Delaunay triangulation. For polygon features, the default is Contiguity edges corners.</para>
		/// <para>The Delaunay triangulation option is only available with a Desktop Advanced license.</para>
		/// <para>Distance band—Features within a specified critical distance of each feature will be included as neighbors.</para>
		/// <para>Number of neighbors— The closest features will be included as neighbors.</para>
		/// <para>Contiguity edges only— Polygon features that share an edge will be included as neighbors.</para>
		/// <para>Contiguity edges corners— Polygon features that share an edge or a corner will be included as neighbors. This is the default for polygon features.</para>
		/// <para>Delaunay triangulation—Features whose Delaunay triangulation share an edge will be included as neighbors. This is the default for point features.</para>
		/// <para>Get spatial weights from file— Neighbors and weights will be defined by a specified spatial weights file.</para>
		/// <para><see cref="NeighborhoodTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? NeighborhoodType { get; set; }

		/// <summary>
		/// <para>Distance Band</para>
		/// <para>All features within this distance will be included as neighbors. If no value is provided, one will be estimated during processing and included as a geoprocessing message. If the specified distance results in more than 1,000 neighbors, only the closest 1,000 features will be included as neighbors.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? DistanceBand { get; set; }

		/// <summary>
		/// <para>Number of Neighbors</para>
		/// <para>The number of neighbors that will be included for each local calculation. The number does not include the focal feature. If the focal feature is included in calculations, one additional neighbor will be used. The default is 8.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain()]
		public object? NumberOfNeighbors { get; set; } = "8";

		/// <summary>
		/// <para>Weights Matrix File</para>
		/// <para>The path and file name of the spatial weights matrix file that defines spatial, and potentially temporal, relationships among features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object? WeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Local Weighting Scheme</para>
		/// <para>Specifies the weighting scheme that will be applied to neighbors when calculating local statistics.</para>
		/// <para>Unweighted—Neighbors will not be weighted. This is the default.</para>
		/// <para>Bisquare—Neighbors will be weighted using a bisquare kernel scheme.</para>
		/// <para>Gaussian—Neighbors will be weighted using a Gaussian kernel scheme.</para>
		/// <para><see cref="LocalWeightingSchemeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LocalWeightingScheme { get; set; } = "UNWEIGHTED";

		/// <summary>
		/// <para>Kernel Bandwidth</para>
		/// <para>The bandwidth of the bisquare or Gaussian local weighting schemes. If no value is provided, one will be estimated during processing and included as a geoprocessing message.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? KernelBandwidth { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public NeighborhoodSummaryStatistics SetEnviroment(object? outputCoordinateSystem = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Local Summary Statistic</para>
		/// </summary>
		public enum LocalSummaryStatisticEnum 
		{
			/// <summary>
			/// <para>All—All local statistics will be calculated. This is the default.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All")]
			All,

			/// <summary>
			/// <para>Mean—The local mean (average) will be calculated.</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("Mean")]
			Mean,

			/// <summary>
			/// <para>Median— The local median will be calculated.</para>
			/// </summary>
			[GPValue("MEDIAN")]
			[Description("Median")]
			Median,

			/// <summary>
			/// <para>Standard deviation—The local standard deviation will be calculated.</para>
			/// </summary>
			[GPValue("STD_DEV")]
			[Description("Standard deviation")]
			Standard_deviation,

			/// <summary>
			/// <para>Interquartile range— The local interquartile range will be calculated.</para>
			/// </summary>
			[GPValue("IQR")]
			[Description("Interquartile range")]
			Interquartile_range,

			/// <summary>
			/// <para>Skewness— The local skewness will be calculated.</para>
			/// </summary>
			[GPValue("SKEWNESS")]
			[Description("Skewness")]
			Skewness,

			/// <summary>
			/// <para>Quantile imbalance— The local quantile imbalance will be calculated.</para>
			/// </summary>
			[GPValue("QUANTILE_IMBALANCE")]
			[Description("Quantile imbalance")]
			Quantile_imbalance,

		}

		/// <summary>
		/// <para>Include Focal Feature in Calculations</para>
		/// </summary>
		public enum IncludeFocalFeatureEnum 
		{
			/// <summary>
			/// <para>Checked—The focal feature and all of its neighbors will be included when calculating local statistics. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_FOCAL")]
			INCLUDE_FOCAL,

			/// <summary>
			/// <para>Unchecked—The focal feature will not be included when calculating local statistics. Only neighbors of the feature will be included.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_FOCAL")]
			EXCLUDE_FOCAL,

		}

		/// <summary>
		/// <para>Ignore Null Values in Calculations</para>
		/// </summary>
		public enum IgnoreNullsEnum 
		{
			/// <summary>
			/// <para>Checked—Null values in the analysis fields will be ignored, and statistics will be calculated using only non-null values. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("IGNORE_NULLS")]
			IGNORE_NULLS,

			/// <summary>
			/// <para>Unchecked—Null values in the analysis fields will be included in the calculations, and any local statistic will be calculated as null if any of the values used in the calculation are null.</para>
			/// </summary>
			[GPValue("false")]
			[Description("INCLUDE_NULLS")]
			INCLUDE_NULLS,

		}

		/// <summary>
		/// <para>Neighborhood Type</para>
		/// </summary>
		public enum NeighborhoodTypeEnum 
		{
			/// <summary>
			/// <para>Distance band—Features within a specified critical distance of each feature will be included as neighbors.</para>
			/// </summary>
			[GPValue("DISTANCE_BAND")]
			[Description("Distance band")]
			Distance_band,

			/// <summary>
			/// <para>Number of neighbors— The closest features will be included as neighbors.</para>
			/// </summary>
			[GPValue("NUMBER_OF_NEIGHBORS")]
			[Description("Number of neighbors")]
			Number_of_neighbors,

			/// <summary>
			/// <para>Contiguity edges only— Polygon features that share an edge will be included as neighbors.</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_ONLY")]
			[Description("Contiguity edges only")]
			Contiguity_edges_only,

			/// <summary>
			/// <para>Contiguity edges corners— Polygon features that share an edge or a corner will be included as neighbors. This is the default for polygon features.</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_CORNERS")]
			[Description("Contiguity edges corners")]
			Contiguity_edges_corners,

			/// <summary>
			/// <para>Delaunay triangulation—Features whose Delaunay triangulation share an edge will be included as neighbors. This is the default for point features.</para>
			/// </summary>
			[GPValue("DELAUNAY_TRIANGULATION")]
			[Description("Delaunay triangulation")]
			Delaunay_triangulation,

			/// <summary>
			/// <para>Get spatial weights from file— Neighbors and weights will be defined by a specified spatial weights file.</para>
			/// </summary>
			[GPValue("GET_SPATIAL_WEIGHTS_FROM_FILE")]
			[Description("Get spatial weights from file")]
			Get_spatial_weights_from_file,

		}

		/// <summary>
		/// <para>Local Weighting Scheme</para>
		/// </summary>
		public enum LocalWeightingSchemeEnum 
		{
			/// <summary>
			/// <para>Unweighted—Neighbors will not be weighted. This is the default.</para>
			/// </summary>
			[GPValue("UNWEIGHTED")]
			[Description("Unweighted")]
			Unweighted,

			/// <summary>
			/// <para>Bisquare—Neighbors will be weighted using a bisquare kernel scheme.</para>
			/// </summary>
			[GPValue("BISQUARE")]
			[Description("Bisquare")]
			Bisquare,

			/// <summary>
			/// <para>Gaussian—Neighbors will be weighted using a Gaussian kernel scheme.</para>
			/// </summary>
			[GPValue("GAUSSIAN")]
			[Description("Gaussian")]
			Gaussian,

		}

#endregion
	}
}
