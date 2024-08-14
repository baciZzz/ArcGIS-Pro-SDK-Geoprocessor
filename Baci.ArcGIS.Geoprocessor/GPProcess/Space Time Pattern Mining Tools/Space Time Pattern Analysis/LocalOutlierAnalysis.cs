using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpaceTimePatternMiningTools
{
	/// <summary>
	/// <para>Local Outlier Analysis</para>
	/// <para>Identifies statistically significant clusters and outliers in the context of both space and time.  This tool is a space-time implementation of the Anselin Local Moran's I statistic.</para>
	/// </summary>
	public class LocalOutlierAnalysis : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCube">
		/// <para>Input Space Time Cube</para>
		/// <para>The netCDF cube to be analyzed. This file must have an (.nc) extension and must have been created using either the Create Space Time Cube By Aggregating Points or Create Space Time Cube From Defined Features tool.</para>
		/// </param>
		/// <param name="AnalysisVariable">
		/// <para>Analysis Variable</para>
		/// <para>The numeric variable in the netCDF file you want to analyze.</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>The output feature class containing locations that were considered statistically significant clusters or outliers.</para>
		/// </param>
		public LocalOutlierAnalysis(object InCube, object AnalysisVariable, object OutputFeatures)
		{
			this.InCube = InCube;
			this.AnalysisVariable = AnalysisVariable;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Local Outlier Analysis</para>
		/// </summary>
		public override string DisplayName => "Local Outlier Analysis";

		/// <summary>
		/// <para>Tool Name : LocalOutlierAnalysis</para>
		/// </summary>
		public override string ToolName => "LocalOutlierAnalysis";

		/// <summary>
		/// <para>Tool Excute Name : stpm.LocalOutlierAnalysis</para>
		/// </summary>
		public override string ExcuteName => "stpm.LocalOutlierAnalysis";

		/// <summary>
		/// <para>Toolbox Display Name : Space Time Pattern Mining Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Space Time Pattern Mining Tools";

		/// <summary>
		/// <para>Toolbox Alise : stpm</para>
		/// </summary>
		public override string ToolboxAlise => "stpm";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "randomGenerator", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InCube, AnalysisVariable, OutputFeatures, NeighborhoodDistance, NeighborhoodTimeStep, NumberOfPermutations, PolygonMask, ConceptualizationOfSpatialRelationships, NumberOfNeighbors, DefineGlobalWindow };

		/// <summary>
		/// <para>Input Space Time Cube</para>
		/// <para>The netCDF cube to be analyzed. This file must have an (.nc) extension and must have been created using either the Create Space Time Cube By Aggregating Points or Create Space Time Cube From Defined Features tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object InCube { get; set; }

		/// <summary>
		/// <para>Analysis Variable</para>
		/// <para>The numeric variable in the netCDF file you want to analyze.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object AnalysisVariable { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The output feature class containing locations that were considered statistically significant clusters or outliers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Neighborhood Distance</para>
		/// <para>The spatial extent of the analysis neighborhood. This value determines which features are analyzed together in order to assess local space-time clustering.</para>
		/// <para><see cref="NeighborhoodDistanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object NeighborhoodDistance { get; set; }

		/// <summary>
		/// <para>Neighborhood Time Step</para>
		/// <para>The number of time-step intervals to include in the analysis neighborhood. This value determines which features are analyzed together in order to assess local space-time clustering.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain()]
		public object NeighborhoodTimeStep { get; set; } = "1";

		/// <summary>
		/// <para>Number of Permutations</para>
		/// <para>The number of random permutations for the calculation of pseudo p-values. The default number of permutations is 499. If you choose 0 permutations, the standard p-value is calculated.</para>
		/// <para>0—Permutations are not used and a standard p-value is calculated.</para>
		/// <para>99—With 99 permutations, the smallest possible pseudo p-value is 0.01 and all other pseudo p-values will be even multiples of this value.</para>
		/// <para>199—With 199 permutations, the smallest possible pseudo p-value is 0.005 and all other pseudo p-values will be even multiples of this value.</para>
		/// <para>499—With 499 permutations, the smallest possible pseudo p-value is 0.002 and all other pseudo p-values will be even multiples of this value.</para>
		/// <para>999—With 999 permutations, the smallest possible pseudo p-value is 0.001 and all other pseudo p-values will be even multiples of this value.</para>
		/// <para>9999—With 9999 permutations, the smallest possible pseudo p-value is 0.0001 and all other pseudo p-values will be even multiples of this value.</para>
		/// <para><see cref="NumberOfPermutationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object NumberOfPermutations { get; set; } = "499";

		/// <summary>
		/// <para>Polygon Analysis Mask</para>
		/// <para>A polygon feature layer with one or more polygons defining the analysis study area. You would use a polygon analysis mask to exclude a large lake from the analysis, for example. Bins defined in the Input Space Time Cube that fall outside of the mask will not be included in the analysis.</para>
		/// <para>This parameter is only available for grid cubes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object PolygonMask { get; set; }

		/// <summary>
		/// <para>Conceptualization of Spatial Relationships</para>
		/// <para>Specifies how spatial relationships among features are defined.</para>
		/// <para>Fixed distance—Each bin is analyzed within the context of neighboring bins. Neighboring bins inside the specified critical distance (Neighborhood Distance) receive a weight of one and exert influence on computations for the target bin. Neighboring bins outside the critical distance receive a weight of zero and have no influence on a target bin&apos;s computations.</para>
		/// <para>K nearest neighbors—The closest k bins are included in the analysis for the target bin; k is a specified numeric parameter.</para>
		/// <para>Contiguity edges only—Only neighboring bins that share an edge will influence computations for the target polygon bin.</para>
		/// <para>Contiguity edges corners—Bins that share an edge or share a node will influence computations for the target polygon bin.</para>
		/// <para><see cref="ConceptualizationOfSpatialRelationshipsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConceptualizationOfSpatialRelationships { get; set; } = "FIXED_DISTANCE";

		/// <summary>
		/// <para>Number of Spatial Neighbors</para>
		/// <para>An integer specifying either the minimum or the exact number of neighbors to include in calculations for the target bin. For K nearest neighbors, each bin will have exactly this specified number of neighbors. For Fixed distance, each bin will have at least this many neighbors (the Neighborhood Distance will be temporarily extended to ensure this many neighbors if necessary). When one of the contiguity conceptualizations are selected, each bin will be assigned this minimum number of neighbors. For bins with fewer than this number of contiguous neighbors, additional neighbors will be based on feature centroid proximity.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain()]
		public object NumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Define Global Window</para>
		/// <para>The Anselin Local Moran&apos;s I statistic works by comparing a local statistic calculated from the neighbors for each bin to a global value. This parameter can be used to control which bins are used to calculate the global value.</para>
		/// <para>Entire cube—Each neighborhood is analyzed in comparison to the entire cube. This is the default.</para>
		/// <para>Neighborhood Time Step—Each neighborhood is analyzed in comparison to the bins contained within the specified Neighborhood Time Step.</para>
		/// <para>Individual time step—Each neighborhood is analyzed in comparison to the bins in the same time step.</para>
		/// <para><see cref="DefineGlobalWindowEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DefineGlobalWindow { get; set; } = "ENTIRE_CUBE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LocalOutlierAnalysis SetEnviroment(object geographicTransformations = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object randomGenerator = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, randomGenerator: randomGenerator, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Neighborhood Distance</para>
		/// </summary>
		public enum NeighborhoodDistanceEnum 
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
		/// <para>Number of Permutations</para>
		/// </summary>
		public enum NumberOfPermutationsEnum 
		{
			/// <summary>
			/// <para>0—Permutations are not used and a standard p-value is calculated.</para>
			/// </summary>
			[GPValue("0")]
			[Description("0")]
			_0,

			/// <summary>
			/// <para>99—With 99 permutations, the smallest possible pseudo p-value is 0.01 and all other pseudo p-values will be even multiples of this value.</para>
			/// </summary>
			[GPValue("99")]
			[Description("99")]
			_99,

			/// <summary>
			/// <para>199—With 199 permutations, the smallest possible pseudo p-value is 0.005 and all other pseudo p-values will be even multiples of this value.</para>
			/// </summary>
			[GPValue("199")]
			[Description("199")]
			_199,

			/// <summary>
			/// <para>499—With 499 permutations, the smallest possible pseudo p-value is 0.002 and all other pseudo p-values will be even multiples of this value.</para>
			/// </summary>
			[GPValue("499")]
			[Description("499")]
			_499,

			/// <summary>
			/// <para>999—With 999 permutations, the smallest possible pseudo p-value is 0.001 and all other pseudo p-values will be even multiples of this value.</para>
			/// </summary>
			[GPValue("999")]
			[Description("999")]
			_999,

			/// <summary>
			/// <para>9999—With 9999 permutations, the smallest possible pseudo p-value is 0.0001 and all other pseudo p-values will be even multiples of this value.</para>
			/// </summary>
			[GPValue("9999")]
			[Description("9999")]
			_9999,

		}

		/// <summary>
		/// <para>Conceptualization of Spatial Relationships</para>
		/// </summary>
		public enum ConceptualizationOfSpatialRelationshipsEnum 
		{
			/// <summary>
			/// <para>Fixed distance—Each bin is analyzed within the context of neighboring bins. Neighboring bins inside the specified critical distance (Neighborhood Distance) receive a weight of one and exert influence on computations for the target bin. Neighboring bins outside the critical distance receive a weight of zero and have no influence on a target bin&apos;s computations.</para>
			/// </summary>
			[GPValue("FIXED_DISTANCE")]
			[Description("Fixed distance")]
			Fixed_distance,

			/// <summary>
			/// <para>K nearest neighbors—The closest k bins are included in the analysis for the target bin; k is a specified numeric parameter.</para>
			/// </summary>
			[GPValue("K_NEAREST_NEIGHBORS")]
			[Description("K nearest neighbors")]
			K_nearest_neighbors,

			/// <summary>
			/// <para>Contiguity edges only—Only neighboring bins that share an edge will influence computations for the target polygon bin.</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_ONLY")]
			[Description("Contiguity edges only")]
			Contiguity_edges_only,

			/// <summary>
			/// <para>Contiguity edges corners—Bins that share an edge or share a node will influence computations for the target polygon bin.</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_CORNERS")]
			[Description("Contiguity edges corners")]
			Contiguity_edges_corners,

		}

		/// <summary>
		/// <para>Define Global Window</para>
		/// </summary>
		public enum DefineGlobalWindowEnum 
		{
			/// <summary>
			/// <para>Entire cube—Each neighborhood is analyzed in comparison to the entire cube. This is the default.</para>
			/// </summary>
			[GPValue("ENTIRE_CUBE")]
			[Description("Entire cube")]
			Entire_cube,

			/// <summary>
			/// <para>Neighborhood Time Step—Each neighborhood is analyzed in comparison to the bins contained within the specified Neighborhood Time Step.</para>
			/// </summary>
			[GPValue("NEIGHBORHOOD_TIME_STEP")]
			[Description("Neighborhood Time Step")]
			Neighborhood_Time_Step,

			/// <summary>
			/// <para>Individual time step—Each neighborhood is analyzed in comparison to the bins in the same time step.</para>
			/// </summary>
			[GPValue("INDIVIDUAL_TIME_STEP")]
			[Description("Individual time step")]
			Individual_time_step,

		}

#endregion
	}
}
