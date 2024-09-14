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
	/// <para>Build Balanced Zones</para>
	/// <para>Build Balanced Zones</para>
	/// <para>Creates spatially contiguous zones in your study area using a genetic growth algorithm based on criteria that you specify.</para>
	/// </summary>
	public class BuildBalancedZones : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The feature class or feature layer that will be aggregated into zones.</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>The output feature class indicating which features are aggregated into each zone. The feature class will be symbolized by the ZONE_ID field and will contain fields displaying the values of each criteria that you specify.</para>
		/// </param>
		/// <param name="ZoneCreationMethod">
		/// <para>Zone Creation Method</para>
		/// <para>Specifies the method that will be used to grow each zone. Zones grow until all specified criteria are satisfied.</para>
		/// <para>Attribute target—Zones will be created based on target values of one or multiple variables. If this option is chosen, the desired sum of each attribute must be specified in the Zone Building Criteria With Target parameter, and each zone will grow until the sum of the attributes exceeds these values. For example, you can use this option to create zones that each have at least 100,000 residents and 20,000 family homes.</para>
		/// <para>Number of zones and attribute target—A specified number of zones will be created while keeping the sum of an attribute approximately equal within each zone. If this option is chosen, the desired number of zones must be specified in the Target Number of Zones parameter. The attribute sum within each zone is equal to the sum of the total attribute divided by the number of zones.</para>
		/// <para>Defined number of zones—A specified number of zones will be created that are each composed of approximately the same number of input features. If this option is chosen, the desired number of zones must be specified in the Target Number of Zones parameter.</para>
		/// <para><see cref="ZoneCreationMethodEnum"/></para>
		/// </param>
		public BuildBalancedZones(object InFeatures, object OutputFeatures, object ZoneCreationMethod)
		{
			this.InFeatures = InFeatures;
			this.OutputFeatures = OutputFeatures;
			this.ZoneCreationMethod = ZoneCreationMethod;
		}

		/// <summary>
		/// <para>Tool Display Name : Build Balanced Zones</para>
		/// </summary>
		public override string DisplayName() => "Build Balanced Zones";

		/// <summary>
		/// <para>Tool Name : BuildBalancedZones</para>
		/// </summary>
		public override string ToolName() => "BuildBalancedZones";

		/// <summary>
		/// <para>Tool Excute Name : stats.BuildBalancedZones</para>
		/// </summary>
		public override string ExcuteName() => "stats.BuildBalancedZones";

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
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "parallelProcessingFactor", "randomGenerator" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutputFeatures, ZoneCreationMethod, NumberOfZones, ZoneBuildingCriteriaTarget, ZoneBuildingCriteria, SpatialConstraints, WeightsMatrixFile, ZoneCharacteristics, AttributeToConsider, DistanceToConsider, CategorialVariable, ProportionMethod, PopulationSize, NumberGenerations, MutationFactor, OutputConvergenceTable };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The feature class or feature layer that will be aggregated into zones.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The output feature class indicating which features are aggregated into each zone. The feature class will be symbolized by the ZONE_ID field and will contain fields displaying the values of each criteria that you specify.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Zone Creation Method</para>
		/// <para>Specifies the method that will be used to grow each zone. Zones grow until all specified criteria are satisfied.</para>
		/// <para>Attribute target—Zones will be created based on target values of one or multiple variables. If this option is chosen, the desired sum of each attribute must be specified in the Zone Building Criteria With Target parameter, and each zone will grow until the sum of the attributes exceeds these values. For example, you can use this option to create zones that each have at least 100,000 residents and 20,000 family homes.</para>
		/// <para>Number of zones and attribute target—A specified number of zones will be created while keeping the sum of an attribute approximately equal within each zone. If this option is chosen, the desired number of zones must be specified in the Target Number of Zones parameter. The attribute sum within each zone is equal to the sum of the total attribute divided by the number of zones.</para>
		/// <para>Defined number of zones—A specified number of zones will be created that are each composed of approximately the same number of input features. If this option is chosen, the desired number of zones must be specified in the Target Number of Zones parameter.</para>
		/// <para><see cref="ZoneCreationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ZoneCreationMethod { get; set; } = "ATTRIBUTE_TARGET";

		/// <summary>
		/// <para>Target Number of Zones</para>
		/// <para>The number of zones that will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumberOfZones { get; set; }

		/// <summary>
		/// <para>Zone Building Criteria With Target</para>
		/// <para>Specifies the variables that will be considered, their target values, and optional weights. The default weights are set to 1, and each variable contributes equally unless they are changed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object ZoneBuildingCriteriaTarget { get; set; }

		/// <summary>
		/// <para>Zone Building Criteria</para>
		/// <para>Specifies the variables that will be considered and, optionally, weights. The default weights are set to 1, and each variable contributes equally unless changed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object ZoneBuildingCriteria { get; set; }

		/// <summary>
		/// <para>Spatial Constraints</para>
		/// <para>Specifies how neighbors are defined while the zones grow. Zones can only grow into new features that are neighbors of at least one of the features already in the zone. If the input features are polygons, the default spatial constraint is Contiguity edges corners. If the input features are points, the default spatial constraint is Trimmed Delaunay triangulation.</para>
		/// <para>Contiguity edges only—For zones containing contiguous polygon features, only polygons that share an edge will be part of the same zone.</para>
		/// <para>Contiguity edges corners— For zones containing contiguous polygon features, only polygons that share an edge or a vertex will be part of the same zone.</para>
		/// <para>Trimmed Delaunay triangulation— Features in the same zone will have at least one natural neighbor in common with another feature in the zone. Natural neighbor relationships are based on a trimmed Delaunay Triangulation. Conceptually, Delaunay Triangulation creates a non-overlapping mesh of triangles from feature centroids. Each feature is a triangle node, and nodes that share edges are considered neighbors. These triangles are then clipped to a convex hull to ensure that features cannot be neighbors with any features outside of the convex hull. This is the default.</para>
		/// <para>Get spatial weights from file— Spatial, and, optionally, temporal relationships will be defined by a specified spatial weights file (.swm). Create the spatial weights matrix using the Generate Spatial Weights Matrix tool or the Generate Network Spatial Weights tool. The path to the spatial weights file is specified by the Spatial Weights Matrix File parameter.</para>
		/// <para><see cref="SpatialConstraintsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SpatialConstraints { get; set; }

		/// <summary>
		/// <para>Spatial Weight Matrix File</para>
		/// <para>The path to a file containing spatial weights that define spatial and, optionally, temporal relationships among features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("swm", "gwt")]
		public object WeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Zone Characteristics</para>
		/// <para>Specifies the desired characteristics of the zones that will be created.</para>
		/// <para>Equal area— Zones with total area as similar as possible will be created.</para>
		/// <para>Compactness—Zones will be created with more closely-packed (compact) features.</para>
		/// <para>Equal number of features—Zones with an equal number of features will be created.</para>
		/// <para><see cref="ZoneCharacteristicsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Additional Zone Selection Criteria")]
		public object ZoneCharacteristics { get; set; }

		/// <summary>
		/// <para>Attribute to Consider</para>
		/// <para>Specifies attributes and statistics to consider in the selection of final zones. You can choose to homogenize attributes based on their sum, average, median, or variance. For example, if you are creating zones based on home values and want to balance the average total income within each zone, the solution with the most equal average income across zones will be preferred.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Additional Zone Selection Criteria")]
		public object AttributeToConsider { get; set; }

		/// <summary>
		/// <para>Distance to Consider</para>
		/// <para>The feature class that will be used to homogenize the total distance per zone. The distance is calculated from each of the input features to the closest feature provided in this parameter. This distance is then used as an additional attribute constraint when selecting the final zone solution. For example, you can create police patrol districts that are each approximately the same distance from the closest police station.</para>
		/// <para>This optional parameter is not available with a Desktop Basic or Desktop Standard license.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Additional Zone Selection Criteria")]
		public object DistanceToConsider { get; set; }

		/// <summary>
		/// <para>Categorical Variable to Maintain Proportions</para>
		/// <para>The categorical variable to be considered for zone proportions.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long", "Short", "Text", "Double", "Float")]
		[Category("Additional Zone Selection Criteria")]
		public object CategorialVariable { get; set; }

		/// <summary>
		/// <para>Proportion Method</para>
		/// <para>Specifies the type of proportion that will be maintained based on the chosen categorical variable.</para>
		/// <para>Maintain within proportion—Each zone will maintain the same proportions as the overall study area for the given categorical variable. For example, given a categorical variable that is 60% Type A and 40% Type B, this method will prefer zones that are comprised of approximately 60% Type A features and 40% Type B features.</para>
		/// <para>Maintain overall proportion—Zones will be created so that the overall proportions of category predominance by zone matches the proportions of the given categorical variable for the entire dataset. For example, given a categorical variable that is 60% Type A and 40% Type B, this method will prefer solutions where 60% of the zones are predominantly Type A features and 40% of the zones are predominantly Type B features.</para>
		/// <para><see cref="ProportionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Zone Selection Criteria")]
		public object ProportionMethod { get; set; }

		/// <summary>
		/// <para>Population Size</para>
		/// <para>The number of randomly generated initial seeds. For larger datasets, increasing this number will increase the search space and the probability of finding a better solution. The default is 100.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 3, Max = 10000000)]
		[Category("Advanced Parameters")]
		public object PopulationSize { get; set; } = "100";

		/// <summary>
		/// <para>Number of Generations</para>
		/// <para>The number of times the zone search process is repeated. For larger datasets, increasing the number is recommended in order to find an optimal solution. The default is 50 generations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 10000000)]
		[Category("Advanced Parameters")]
		public object NumberGenerations { get; set; } = "50";

		/// <summary>
		/// <para>Mutation Factor</para>
		/// <para>The probability that an individual's seed values will be mutated to a new set of seeds. Mutation increases the search space by introducing variability of the possible solutions in every generation and allows for faster convergence to an optimal solution. The default is 0.1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 1)]
		[Category("Advanced Parameters")]
		public object MutationFactor { get; set; } = "0.1";

		/// <summary>
		/// <para>Output Convergence Table</para>
		/// <para>If specified, a table will be created containing the total fitness score for the best solution found in every generation as well as the fitness score for the individual zone constraints.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Advanced Parameters")]
		public object OutputConvergenceTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BuildBalancedZones SetEnviroment(object outputCoordinateSystem = null, object parallelProcessingFactor = null, object randomGenerator = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, randomGenerator: randomGenerator);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Zone Creation Method</para>
		/// </summary>
		public enum ZoneCreationMethodEnum 
		{
			/// <summary>
			/// <para>Attribute target—Zones will be created based on target values of one or multiple variables. If this option is chosen, the desired sum of each attribute must be specified in the Zone Building Criteria With Target parameter, and each zone will grow until the sum of the attributes exceeds these values. For example, you can use this option to create zones that each have at least 100,000 residents and 20,000 family homes.</para>
			/// </summary>
			[GPValue("ATTRIBUTE_TARGET")]
			[Description("Attribute target")]
			Attribute_target,

			/// <summary>
			/// <para>Number of zones and attribute target—A specified number of zones will be created while keeping the sum of an attribute approximately equal within each zone. If this option is chosen, the desired number of zones must be specified in the Target Number of Zones parameter. The attribute sum within each zone is equal to the sum of the total attribute divided by the number of zones.</para>
			/// </summary>
			[GPValue("NUMBER_ZONES_AND_ATTRIBUTE")]
			[Description("Number of zones and attribute target")]
			Number_of_zones_and_attribute_target,

			/// <summary>
			/// <para>Defined number of zones—A specified number of zones will be created that are each composed of approximately the same number of input features. If this option is chosen, the desired number of zones must be specified in the Target Number of Zones parameter.</para>
			/// </summary>
			[GPValue("NUMBER_OF_ZONES")]
			[Description("Defined number of zones")]
			Defined_number_of_zones,

		}

		/// <summary>
		/// <para>Spatial Constraints</para>
		/// </summary>
		public enum SpatialConstraintsEnum 
		{
			/// <summary>
			/// <para>Contiguity edges only—For zones containing contiguous polygon features, only polygons that share an edge will be part of the same zone.</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_ONLY")]
			[Description("Contiguity edges only")]
			Contiguity_edges_only,

			/// <summary>
			/// <para>Contiguity edges corners— For zones containing contiguous polygon features, only polygons that share an edge or a vertex will be part of the same zone.</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_CORNERS")]
			[Description("Contiguity edges corners")]
			Contiguity_edges_corners,

			/// <summary>
			/// <para>Trimmed Delaunay triangulation— Features in the same zone will have at least one natural neighbor in common with another feature in the zone. Natural neighbor relationships are based on a trimmed Delaunay Triangulation. Conceptually, Delaunay Triangulation creates a non-overlapping mesh of triangles from feature centroids. Each feature is a triangle node, and nodes that share edges are considered neighbors. These triangles are then clipped to a convex hull to ensure that features cannot be neighbors with any features outside of the convex hull. This is the default.</para>
			/// </summary>
			[GPValue("TRIMMED_DELAUNAY_TRIANGULATION")]
			[Description("Trimmed Delaunay triangulation")]
			Trimmed_Delaunay_triangulation,

			/// <summary>
			/// <para>Get spatial weights from file— Spatial, and, optionally, temporal relationships will be defined by a specified spatial weights file (.swm). Create the spatial weights matrix using the Generate Spatial Weights Matrix tool or the Generate Network Spatial Weights tool. The path to the spatial weights file is specified by the Spatial Weights Matrix File parameter.</para>
			/// </summary>
			[GPValue("GET_SPATIAL_WEIGHTS_FROM_FILE")]
			[Description("Get spatial weights from file")]
			Get_spatial_weights_from_file,

		}

		/// <summary>
		/// <para>Zone Characteristics</para>
		/// </summary>
		public enum ZoneCharacteristicsEnum 
		{
			/// <summary>
			/// <para>Equal area— Zones with total area as similar as possible will be created.</para>
			/// </summary>
			[GPValue("EQUAL_AREA")]
			[Description("Equal area")]
			Equal_area,

			/// <summary>
			/// <para>Compactness—Zones will be created with more closely-packed (compact) features.</para>
			/// </summary>
			[GPValue("COMPACTNESS")]
			[Description("Compactness")]
			Compactness,

			/// <summary>
			/// <para>Equal number of features—Zones with an equal number of features will be created.</para>
			/// </summary>
			[GPValue("EQUAL_NUMBER_OF_FEATURES")]
			[Description("Equal number of features")]
			Equal_number_of_features,

		}

		/// <summary>
		/// <para>Proportion Method</para>
		/// </summary>
		public enum ProportionMethodEnum 
		{
			/// <summary>
			/// <para>Maintain within proportion—Each zone will maintain the same proportions as the overall study area for the given categorical variable. For example, given a categorical variable that is 60% Type A and 40% Type B, this method will prefer zones that are comprised of approximately 60% Type A features and 40% Type B features.</para>
			/// </summary>
			[GPValue("MAINTAIN_WITHIN_PROPORTION")]
			[Description("Maintain within proportion")]
			Maintain_within_proportion,

			/// <summary>
			/// <para>Maintain overall proportion—Zones will be created so that the overall proportions of category predominance by zone matches the proportions of the given categorical variable for the entire dataset. For example, given a categorical variable that is 60% Type A and 40% Type B, this method will prefer solutions where 60% of the zones are predominantly Type A features and 40% of the zones are predominantly Type B features.</para>
			/// </summary>
			[GPValue("MAINTAIN_OVERALL_PROPORTION")]
			[Description("Maintain overall proportion")]
			Maintain_overall_proportion,

		}

#endregion
	}
}
