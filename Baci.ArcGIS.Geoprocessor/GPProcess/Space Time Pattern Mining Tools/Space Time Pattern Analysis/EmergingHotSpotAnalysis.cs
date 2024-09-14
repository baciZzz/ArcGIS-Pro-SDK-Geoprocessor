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
	/// <para>Emerging Hot Spot Analysis</para>
	/// <para>新兴时空热点分析</para>
	/// <para>识别使用通过聚合点创建时空立方体、通过已定义位置创建时空立方体或通过多维栅格图层创建时空立方体工具创建的时空立方体中点密度（计数）或值聚类中的趋势。 类别包含新增的、连续的、加强的、持续的、逐渐减少的、分散的、振荡的以及历史的热点和冷点。</para>
	/// </summary>
	public class EmergingHotSpotAnalysis : AbstractGPProcess
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
		/// <para>输出要素类结果。 此要素类为数据中热点和冷点趋势的二维地图表达。 例如，将显示任何新热点或加强的热点。</para>
		/// </param>
		public EmergingHotSpotAnalysis(object InCube, object AnalysisVariable, object OutputFeatures)
		{
			this.InCube = InCube;
			this.AnalysisVariable = AnalysisVariable;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 新兴时空热点分析</para>
		/// </summary>
		public override string DisplayName() => "新兴时空热点分析";

		/// <summary>
		/// <para>Tool Name : EmergingHotSpotAnalysis</para>
		/// </summary>
		public override string ToolName() => "EmergingHotSpotAnalysis";

		/// <summary>
		/// <para>Tool Excute Name : stpm.EmergingHotSpotAnalysis</para>
		/// </summary>
		public override string ExcuteName() => "stpm.EmergingHotSpotAnalysis";

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
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InCube, AnalysisVariable, OutputFeatures, NeighborhoodDistance!, NeighborhoodTimeStep!, PolygonMask!, ConceptualizationOfSpatialRelationships!, NumberOfNeighbors!, DefineGlobalWindow! };

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
		/// <para>输出要素类结果。 此要素类为数据中热点和冷点趋势的二维地图表达。 例如，将显示任何新热点或加强的热点。</para>
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
		/// <para>用于指定邻域的最小数目或精确数目以包括在目标条柱的计算中的整数。 对于 K 最近邻，每个条柱的相邻要素数正好等于这个指定数目。 对于固定距离，每个条柱将至少具有这么多的相邻要素（如有必要，阈值距离将临时增大以确保达到这么多的相邻要素）。 选中一个邻接概念化后，将向每个条柱分配至少该最小数目的相邻要素。 对于具有少于此相邻要素数目的条柱，将根据要素质心邻近性获得附加相邻要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 1000)]
		public object? NumberOfNeighbors { get; set; }

		/// <summary>
		/// <para>Define Global Window</para>
		/// <para>统计数据工作原理为对根据每个条柱的邻域计算的局部统计数据与全局值进行比较。 可以使用此参数来控制用于计算全局值的条柱。</para>
		/// <para>整个立方体—将对每个邻域进行分析，与整个立方体进行比较。 这是默认设置。</para>
		/// <para>邻域时间步长—将对每个邻域进行分析，与指定邻域时间步长内包含的条柱进行比较。</para>
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
		public EmergingHotSpotAnalysis SetEnviroment(object? geographicTransformations = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

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
			/// <para>邻域时间步长—将对每个邻域进行分析，与指定邻域时间步长内包含的条柱进行比较。</para>
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
