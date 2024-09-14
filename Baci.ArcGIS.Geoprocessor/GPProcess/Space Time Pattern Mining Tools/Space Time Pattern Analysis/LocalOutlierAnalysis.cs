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
	/// <para>局部异常值分析</para>
	/// <para>标识出空间和时间环境中的统计显著性聚类和异常值。 该工具是 Anselin Local Moran's I 统计的时空实现。</para>
	/// </summary>
	public class LocalOutlierAnalysis : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InCube">
		/// <para>Input Space Time Cube</para>
		/// <para>包含要分析的变量的时空立方体。 时空立方体具有 .nc 文件扩展名，是使用时空模式挖掘工具箱中的各种工具创建的。</para>
		/// </param>
		/// <param name="AnalysisVariable">
		/// <para>Analysis Variable</para>
		/// <para>要分析的 netCDF 文件中的数值变量。</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>输出要素类，包含被视为统计显著性聚类或异常值的位置。</para>
		/// </param>
		public LocalOutlierAnalysis(object InCube, object AnalysisVariable, object OutputFeatures)
		{
			this.InCube = InCube;
			this.AnalysisVariable = AnalysisVariable;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 局部异常值分析</para>
		/// </summary>
		public override string DisplayName() => "局部异常值分析";

		/// <summary>
		/// <para>Tool Name : LocalOutlierAnalysis</para>
		/// </summary>
		public override string ToolName() => "LocalOutlierAnalysis";

		/// <summary>
		/// <para>Tool Excute Name : stpm.LocalOutlierAnalysis</para>
		/// </summary>
		public override string ExcuteName() => "stpm.LocalOutlierAnalysis";

		/// <summary>
		/// <para>Toolbox Display Name : Space Time Pattern Mining Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Space Time Pattern Mining Tools";

		/// <summary>
		/// <para>Toolbox Alise : stpm</para>
		/// </summary>
		public override string ToolboxAlise() => "stpm";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "randomGenerator", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCube, AnalysisVariable, OutputFeatures, NeighborhoodDistance!, NeighborhoodTimeStep!, NumberOfPermutations!, PolygonMask!, ConceptualizationOfSpatialRelationships!, NumberOfNeighbors!, DefineGlobalWindow! };

		/// <summary>
		/// <para>Input Space Time Cube</para>
		/// <para>包含要分析的变量的时空立方体。 时空立方体具有 .nc 文件扩展名，是使用时空模式挖掘工具箱中的各种工具创建的。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object InCube { get; set; }

		/// <summary>
		/// <para>Analysis Variable</para>
		/// <para>要分析的 netCDF 文件中的数值变量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object AnalysisVariable { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>输出要素类，包含被视为统计显著性聚类或异常值的位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Neighborhood Distance</para>
		/// <para>分析邻域的空间范围。 该值用于确定应将哪些要素一起分析以便访问本地时空聚类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? NeighborhoodDistance { get; set; }

		/// <summary>
		/// <para>Neighborhood Time Step</para>
		/// <para>包含在分析邻域中的时间步长间隔数。 该值用于确定应将哪些要素一起分析以便访问本地时空聚类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 10)]
		public object? NeighborhoodTimeStep { get; set; } = "1";

		/// <summary>
		/// <para>Number of Permutations</para>
		/// <para>伪 p 值计算对应的随机置换检验。 默认置换检验次数为 499。如果选择 0 次置换检验，则会计算标准 p 值。</para>
		/// <para>0—未使用置换检验时，将计算标准 p 值。</para>
		/// <para>99—如果有 99 次置换检验，则可能的最小伪 p 值为 0.01，其他所有伪 p 值将是该值的偶数倍。</para>
		/// <para>199—如果有 199 次置换检验，则可能的最小伪 p 值为 0.005，其他所有伪 p 值将是该值的偶数倍。</para>
		/// <para>499—如果有 499 次置换检验，则可能的最小伪 p 值为 0.002，其他所有伪 p 值将是该值的偶数倍。</para>
		/// <para>999—如果有 999 次置换检验，则可能的最小伪 p 值为 0.001，其他所有伪 p 值将是该值的偶数倍。</para>
		/// <para>9999—如果有 9999 次置换检验，则可能的最小伪 p 值为 0.0001，其他所有伪 p 值将是该值的偶数倍。</para>
		/// <para><see cref="NumberOfPermutationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object? NumberOfPermutations { get; set; } = "499";

		/// <summary>
		/// <para>Polygon Analysis Mask</para>
		/// <para>具有用于定义分析研究区域的一个或多个面的面要素图层。 例如，可使用面分析掩膜将大湖从分析中排除。 在输入时空立方体中定义并落在掩膜外的立方图格将不包括在分析中。</para>
		/// <para>此参数仅适用于格网立方体。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object? PolygonMask { get; set; }

		/// <summary>
		/// <para>Conceptualization of Spatial Relationships</para>
		/// <para>指定要素空间关系的定义方式。</para>
		/// <para>固定距离—对邻近条柱环境内的每个条柱进行分析。 在指定临界距离（邻域距离）内的邻近条柱将分配值为 1 的权重，并对目标条柱的计算产生影响。 在指定临界距离外的邻近条柱将分配值为零的权重，并且不会对目标条柱的计算产生任何影响。</para>
		/// <para>K - 最近邻—将最近的 k 条柱包含在目标条柱的分析中；k 是指定的数字参数。</para>
		/// <para>仅邻接边—只有共用边的邻近条柱会影响目标面条柱的计算。</para>
		/// <para>邻接边拐角—共用边或节点的条柱会影响目标面条柱的计算。</para>
		/// <para><see cref="ConceptualizationOfSpatialRelationshipsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ConceptualizationOfSpatialRelationships { get; set; } = "FIXED_DISTANCE";

		/// <summary>
		/// <para>Number of Spatial Neighbors</para>
		/// <para>用于指定邻域的最小数目或精确数目以包括在目标条柱的计算中的整数。 对于 K 最近邻，每个条柱的相邻要素数正好等于这个指定数目。 对于固定距离，每个条柱将至少具有这么多的相邻要素（如有必要，邻域距离将临时增大以确保达到这么多的相邻要素）。 选中一个邻接概念化后，将向每个条柱分配至少该最小数目的相邻要素。 对于具有少于此相邻要素数目的条柱，将根据要素质心邻近性获得附加相邻要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 1000)]
		public object? NumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Define Global Window</para>
		/// <para>Anselin Local Moran&apos;s I 统计数据工作原理为对根据每个条柱的邻域计算的局部统计数据与全局值进行比较。 可以使用此参数来控制用于计算全局值的条柱。</para>
		/// <para>整个立方体—将对每个邻域进行分析，与整个立方体进行比较。 这是默认设置。</para>
		/// <para>邻域时间步长—将对每个邻域进行分析，与邻域时间步长内包含的条柱进行比较。</para>
		/// <para>单一时间步长—将每个邻域进行分析，与相同时间步长内的条柱进行比较。</para>
		/// <para><see cref="DefineGlobalWindowEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DefineGlobalWindow { get; set; } = "ENTIRE_CUBE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LocalOutlierAnalysis SetEnviroment(object? geographicTransformations = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? randomGenerator = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, randomGenerator: randomGenerator, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Number of Permutations</para>
		/// </summary>
		public enum NumberOfPermutationsEnum 
		{
			/// <summary>
			/// <para>0—未使用置换检验时，将计算标准 p 值。</para>
			/// </summary>
			[GPValue("0")]
			[Description("0")]
			_0,

			/// <summary>
			/// <para>99—如果有 99 次置换检验，则可能的最小伪 p 值为 0.01，其他所有伪 p 值将是该值的偶数倍。</para>
			/// </summary>
			[GPValue("99")]
			[Description("99")]
			_99,

			/// <summary>
			/// <para>199—如果有 199 次置换检验，则可能的最小伪 p 值为 0.005，其他所有伪 p 值将是该值的偶数倍。</para>
			/// </summary>
			[GPValue("199")]
			[Description("199")]
			_199,

			/// <summary>
			/// <para>499—如果有 499 次置换检验，则可能的最小伪 p 值为 0.002，其他所有伪 p 值将是该值的偶数倍。</para>
			/// </summary>
			[GPValue("499")]
			[Description("499")]
			_499,

			/// <summary>
			/// <para>999—如果有 999 次置换检验，则可能的最小伪 p 值为 0.001，其他所有伪 p 值将是该值的偶数倍。</para>
			/// </summary>
			[GPValue("999")]
			[Description("999")]
			_999,

			/// <summary>
			/// <para>9999—如果有 9999 次置换检验，则可能的最小伪 p 值为 0.0001，其他所有伪 p 值将是该值的偶数倍。</para>
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
			/// <para>固定距离—对邻近条柱环境内的每个条柱进行分析。 在指定临界距离（邻域距离）内的邻近条柱将分配值为 1 的权重，并对目标条柱的计算产生影响。 在指定临界距离外的邻近条柱将分配值为零的权重，并且不会对目标条柱的计算产生任何影响。</para>
			/// </summary>
			[GPValue("FIXED_DISTANCE")]
			[Description("固定距离")]
			Fixed_distance,

			/// <summary>
			/// <para>K - 最近邻—将最近的 k 条柱包含在目标条柱的分析中；k 是指定的数字参数。</para>
			/// </summary>
			[GPValue("K_NEAREST_NEIGHBORS")]
			[Description("K - 最近邻")]
			K_nearest_neighbors,

			/// <summary>
			/// <para>仅邻接边—只有共用边的邻近条柱会影响目标面条柱的计算。</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_ONLY")]
			[Description("仅邻接边")]
			Contiguity_edges_only,

			/// <summary>
			/// <para>邻接边拐角—共用边或节点的条柱会影响目标面条柱的计算。</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_CORNERS")]
			[Description("邻接边拐角")]
			Contiguity_edges_corners,

		}

		/// <summary>
		/// <para>Define Global Window</para>
		/// </summary>
		public enum DefineGlobalWindowEnum 
		{
			/// <summary>
			/// <para>整个立方体—将对每个邻域进行分析，与整个立方体进行比较。 这是默认设置。</para>
			/// </summary>
			[GPValue("ENTIRE_CUBE")]
			[Description("整个立方体")]
			Entire_cube,

			/// <summary>
			/// <para>邻域时间步长—将对每个邻域进行分析，与邻域时间步长内包含的条柱进行比较。</para>
			/// </summary>
			[GPValue("NEIGHBORHOOD_TIME_STEP")]
			[Description("邻域时间步长")]
			Neighborhood_Time_Step,

			/// <summary>
			/// <para>单一时间步长—将每个邻域进行分析，与相同时间步长内的条柱进行比较。</para>
			/// </summary>
			[GPValue("INDIVIDUAL_TIME_STEP")]
			[Description("单一时间步长")]
			Individual_time_step,

		}

#endregion
	}
}
