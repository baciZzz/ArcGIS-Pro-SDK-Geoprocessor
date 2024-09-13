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
	/// <para>构建平衡区域</para>
	/// <para>使用基于指定标准的遗传增长算法在研究区域中创建空间连续区域。</para>
	/// </summary>
	public class BuildBalancedZones : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要聚合为区域的要素类或要素图层。</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>输出要素类，指示将哪些要素聚合到每个区域中。 要素类将由 ZONE_ID 字段表示，并包含显示您指定的每个标准的值的字段。</para>
		/// </param>
		/// <param name="ZoneCreationMethod">
		/// <para>Zone Creation Method</para>
		/// <para>指定将用于创建每个区域的方法。 区域将增长，直到满足所有指定条件为止。</para>
		/// <para>属性目标—将根据一个或多个变量的目标值创建区域。 必须在具有目标的区域构建标准参数中指定所需的每个属性的总和；同时每个区域都会增长，直到属性的总和超过这些值为止。 例如，您可以使用此选项创建每个区域中至少具有 100,000 个居民和 20,000 个家庭住宅的区域。</para>
		/// <para>区域数和属性目标—系统将创建指定数量的区域，同时使每个区域内的属性总和大致相等。 必须在目标区域数参数中指定所需的区域数。 每个区域内的属性总和均等于用属性总和除以区域数得到的商。</para>
		/// <para>所定义区域数—将创建指定数量的区域，其中每个区域都由数量大致相同的输入要素组成。 必须在目标区域数参数中指定所需的区域数。</para>
		/// <para><see cref="ZoneCreationMethodEnum"/></para>
		/// </param>
		public BuildBalancedZones(object InFeatures, object OutputFeatures, object ZoneCreationMethod)
		{
			this.InFeatures = InFeatures;
			this.OutputFeatures = OutputFeatures;
			this.ZoneCreationMethod = ZoneCreationMethod;
		}

		/// <summary>
		/// <para>Tool Display Name : 构建平衡区域</para>
		/// </summary>
		public override string DisplayName() => "构建平衡区域";

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
		public override object[] Parameters() => new object[] { InFeatures, OutputFeatures, ZoneCreationMethod, NumberOfZones!, ZoneBuildingCriteriaTarget!, ZoneBuildingCriteria!, SpatialConstraints!, WeightsMatrixFile!, ZoneCharacteristics!, AttributeToConsider!, DistanceToConsider!, CategorialVariable!, ProportionMethod!, PopulationSize!, NumberGenerations!, MutationFactor!, OutputConvergenceTable! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要聚合为区域的要素类或要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>输出要素类，指示将哪些要素聚合到每个区域中。 要素类将由 ZONE_ID 字段表示，并包含显示您指定的每个标准的值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Zone Creation Method</para>
		/// <para>指定将用于创建每个区域的方法。 区域将增长，直到满足所有指定条件为止。</para>
		/// <para>属性目标—将根据一个或多个变量的目标值创建区域。 必须在具有目标的区域构建标准参数中指定所需的每个属性的总和；同时每个区域都会增长，直到属性的总和超过这些值为止。 例如，您可以使用此选项创建每个区域中至少具有 100,000 个居民和 20,000 个家庭住宅的区域。</para>
		/// <para>区域数和属性目标—系统将创建指定数量的区域，同时使每个区域内的属性总和大致相等。 必须在目标区域数参数中指定所需的区域数。 每个区域内的属性总和均等于用属性总和除以区域数得到的商。</para>
		/// <para>所定义区域数—将创建指定数量的区域，其中每个区域都由数量大致相同的输入要素组成。 必须在目标区域数参数中指定所需的区域数。</para>
		/// <para><see cref="ZoneCreationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ZoneCreationMethod { get; set; } = "ATTRIBUTE_TARGET";

		/// <summary>
		/// <para>Target Number of Zones</para>
		/// <para>将创建的区域数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumberOfZones { get; set; }

		/// <summary>
		/// <para>Zone Building Criteria With Target</para>
		/// <para>指定要考虑的变量及其目标值和权重（可选）。 默认权重为 1，除非另行更改，否则每个变量的权重均相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? ZoneBuildingCriteriaTarget { get; set; }

		/// <summary>
		/// <para>Zone Building Criteria</para>
		/// <para>指定将被考虑的变量及其权重（可选）。 默认权重为 1，除非另行更改，否则每个变量的权重均相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? ZoneBuildingCriteria { get; set; }

		/// <summary>
		/// <para>Spatial Constraints</para>
		/// <para>指定在区域增长时将如何定义相邻要素。 区域只能增长为区域中已有的至少一个要素的相邻要素的新要素。 如果输入要素为面，则默认空间约束为邻接边拐角。 如果输入要素为点，则默认空间约束为修剪型 Delaunay 三角测量。</para>
		/// <para>仅邻接边—对于包含连续面要素的区域，只有共享边的面才是同一区域的一部分。</para>
		/// <para>邻接边拐角—对于包含连续面要素的区域，只有共享边或顶点的面才是同一区域的一部分。</para>
		/// <para>修剪型 Delaunay 三角测量—同一个区域中的要素至少具有一个与该区域中的另一要素共用的自然邻域。 自然邻域关系基于修剪型 Delaunay 三角测量。 从概念上讲，Delaunay 三角测量可以根据要素质心创建不重叠的三角网。 每个要素是一个三角形结点，具有公共边的结点被视为邻域。 然后将这些三角形剪裁成凸包，以确保要素无法与凸包外的任何要素相邻。 这是默认设置。</para>
		/// <para>通过文件获取空间权重—空间关系和可选的时态关系通过指定的空间权重文件 (.swm) 进行定义。 使用生成空间权重矩阵或生成网络空间权重工具创建空间权重矩阵。 指向空间权重文件的路径由空间权重矩阵文件参数指定。</para>
		/// <para><see cref="SpatialConstraintsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SpatialConstraints { get; set; }

		/// <summary>
		/// <para>Spatial Weight Matrix File</para>
		/// <para>包含空间权重（其定义要素间的空间关系或时态关系）的文件的路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("swm", "gwt")]
		public object? WeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Zone Characteristics</para>
		/// <para>指定将创建的区域的特征。</para>
		/// <para>相等面积—将创建总面积尽可能相似的区域。</para>
		/// <para>紧密度—将创建包含更紧密（紧凑）的要素的区域。</para>
		/// <para>相等要素数—将创建具有相等要素数的区域。</para>
		/// <para><see cref="ZoneCharacteristicsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Additional Zone Selection Criteria")]
		public object? ZoneCharacteristics { get; set; }

		/// <summary>
		/// <para>Attribute to Consider</para>
		/// <para>指定在选择最终区域时要考虑的属性和统计数据。 您可以根据属性的总和、平均值、中位数或方差对属性进行同质化。 例如，如果您要基于房屋价格创建区域并希望平衡每个区域内的平均总收入，则最好使用跨区域平均收入最相等的解决方案。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		[Category("Additional Zone Selection Criteria")]
		public object? AttributeToConsider { get; set; }

		/// <summary>
		/// <para>Distance to Consider</para>
		/// <para>将用于同质化每个区域的总距离的要素类。 距离是从该参数中每个输入要素到其最接近要素计算的。 然后，在选择最终区域解决方案时，此距离将用作附加属性约束。 例如，您可以创建警察巡逻区，使每个巡逻区与距离最近的警察局的距离大致相同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Additional Zone Selection Criteria")]
		public object? DistanceToConsider { get; set; }

		/// <summary>
		/// <para>Categorical Variable to Maintain Proportions</para>
		/// <para>区域比例要考虑的分类变量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Long", "Short", "Text", "Double", "Float")]
		[Category("Additional Zone Selection Criteria")]
		public object? CategorialVariable { get; set; }

		/// <summary>
		/// <para>Proportion Method</para>
		/// <para>指定将根据所选分类变量保持的比例类型。</para>
		/// <para>保持比例—每个区域将保持与给定分类变量的整个研究区域相同的比例。 例如，给定分类变量为 60％ 类型 A 和 40％ 类型 B，此方法将更倾向于由大约 60％ 类型 A 要素和 40％ 类型 B 要素组成的区域。</para>
		/// <para>保持整体比例—将创建区域，以便按区域的类别优势总比例与整个数据集的给定分类变量的比例相匹配。 例如，给定分类变量为 60％ 类型 A 和 40％ 类型 B，此方法将更倾向于 60％ 的区域主要是类型 A 要素，40％ 的区域主要是类型 B 要素的解决方案。</para>
		/// <para><see cref="ProportionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Zone Selection Criteria")]
		public object? ProportionMethod { get; set; }

		/// <summary>
		/// <para>Population Size</para>
		/// <para>随机生成的初始种子数。 对于大型数据集，增加此数字将增加搜索空间和寻找更好解决方案的可能性。 默认值为 100。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 3, Max = 10000000)]
		[Category("Advanced Parameters")]
		public object? PopulationSize { get; set; } = "100";

		/// <summary>
		/// <para>Number of Generations</para>
		/// <para>区域搜索过程将重复的次数。 对于较大的数据集，建议增加数量以找到最佳解决方案。 默认值为 50 代。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 10000000)]
		[Category("Advanced Parameters")]
		public object? NumberGenerations { get; set; } = "50";

		/// <summary>
		/// <para>Mutation Factor</para>
		/// <para>个体的种子值被突变为一组新种子的概率。 通过在每一代中引入可能解决方案的可变性来增加搜索空间，并允许更快地收敛到最佳解决方案。 默认值为 0.1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 1)]
		[Category("Advanced Parameters")]
		public object? MutationFactor { get; set; } = "0.1";

		/// <summary>
		/// <para>Output Convergence Table</para>
		/// <para>表中包含每一代中找到的最佳解决方案的总体适用性分数以及各个区域约束的适用性分数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Advanced Parameters")]
		public object? OutputConvergenceTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BuildBalancedZones SetEnviroment(object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? randomGenerator = null )
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
			/// <para>属性目标—将根据一个或多个变量的目标值创建区域。 必须在具有目标的区域构建标准参数中指定所需的每个属性的总和；同时每个区域都会增长，直到属性的总和超过这些值为止。 例如，您可以使用此选项创建每个区域中至少具有 100,000 个居民和 20,000 个家庭住宅的区域。</para>
			/// </summary>
			[GPValue("ATTRIBUTE_TARGET")]
			[Description("属性目标")]
			Attribute_target,

			/// <summary>
			/// <para>区域数和属性目标—系统将创建指定数量的区域，同时使每个区域内的属性总和大致相等。 必须在目标区域数参数中指定所需的区域数。 每个区域内的属性总和均等于用属性总和除以区域数得到的商。</para>
			/// </summary>
			[GPValue("NUMBER_ZONES_AND_ATTRIBUTE")]
			[Description("区域数和属性目标")]
			Number_of_zones_and_attribute_target,

			/// <summary>
			/// <para>所定义区域数—将创建指定数量的区域，其中每个区域都由数量大致相同的输入要素组成。 必须在目标区域数参数中指定所需的区域数。</para>
			/// </summary>
			[GPValue("NUMBER_OF_ZONES")]
			[Description("所定义区域数")]
			Defined_number_of_zones,

		}

		/// <summary>
		/// <para>Spatial Constraints</para>
		/// </summary>
		public enum SpatialConstraintsEnum 
		{
			/// <summary>
			/// <para>仅邻接边—对于包含连续面要素的区域，只有共享边的面才是同一区域的一部分。</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_ONLY")]
			[Description("仅邻接边")]
			Contiguity_edges_only,

			/// <summary>
			/// <para>邻接边拐角—对于包含连续面要素的区域，只有共享边或顶点的面才是同一区域的一部分。</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_CORNERS")]
			[Description("邻接边拐角")]
			Contiguity_edges_corners,

			/// <summary>
			/// <para>修剪型 Delaunay 三角测量—同一个区域中的要素至少具有一个与该区域中的另一要素共用的自然邻域。 自然邻域关系基于修剪型 Delaunay 三角测量。 从概念上讲，Delaunay 三角测量可以根据要素质心创建不重叠的三角网。 每个要素是一个三角形结点，具有公共边的结点被视为邻域。 然后将这些三角形剪裁成凸包，以确保要素无法与凸包外的任何要素相邻。 这是默认设置。</para>
			/// </summary>
			[GPValue("TRIMMED_DELAUNAY_TRIANGULATION")]
			[Description("修剪型 Delaunay 三角测量")]
			Trimmed_Delaunay_triangulation,

			/// <summary>
			/// <para>通过文件获取空间权重—空间关系和可选的时态关系通过指定的空间权重文件 (.swm) 进行定义。 使用生成空间权重矩阵或生成网络空间权重工具创建空间权重矩阵。 指向空间权重文件的路径由空间权重矩阵文件参数指定。</para>
			/// </summary>
			[GPValue("GET_SPATIAL_WEIGHTS_FROM_FILE")]
			[Description("通过文件获取空间权重")]
			Get_spatial_weights_from_file,

		}

		/// <summary>
		/// <para>Zone Characteristics</para>
		/// </summary>
		public enum ZoneCharacteristicsEnum 
		{
			/// <summary>
			/// <para>相等面积—将创建总面积尽可能相似的区域。</para>
			/// </summary>
			[GPValue("EQUAL_AREA")]
			[Description("相等面积")]
			Equal_area,

			/// <summary>
			/// <para>紧密度—将创建包含更紧密（紧凑）的要素的区域。</para>
			/// </summary>
			[GPValue("COMPACTNESS")]
			[Description("紧密度")]
			Compactness,

			/// <summary>
			/// <para>相等要素数—将创建具有相等要素数的区域。</para>
			/// </summary>
			[GPValue("EQUAL_NUMBER_OF_FEATURES")]
			[Description("相等要素数")]
			Equal_number_of_features,

		}

		/// <summary>
		/// <para>Proportion Method</para>
		/// </summary>
		public enum ProportionMethodEnum 
		{
			/// <summary>
			/// <para>保持比例—每个区域将保持与给定分类变量的整个研究区域相同的比例。 例如，给定分类变量为 60％ 类型 A 和 40％ 类型 B，此方法将更倾向于由大约 60％ 类型 A 要素和 40％ 类型 B 要素组成的区域。</para>
			/// </summary>
			[GPValue("MAINTAIN_WITHIN_PROPORTION")]
			[Description("保持比例")]
			Maintain_within_proportion,

			/// <summary>
			/// <para>保持整体比例—将创建区域，以便按区域的类别优势总比例与整个数据集的给定分类变量的比例相匹配。 例如，给定分类变量为 60％ 类型 A 和 40％ 类型 B，此方法将更倾向于 60％ 的区域主要是类型 A 要素，40％ 的区域主要是类型 B 要素的解决方案。</para>
			/// </summary>
			[GPValue("MAINTAIN_OVERALL_PROPORTION")]
			[Description("保持整体比例")]
			Maintain_overall_proportion,

		}

#endregion
	}
}
