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
	/// <para>Grouping Analysis</para>
	/// <para>分组分析</para>
	/// <para>根据要素属性和可选的空间或时态约束对要素进行分组。</para>
	/// </summary>
	[Obsolete()]
	public class GroupingAnalysis : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>要创建组的要素类或要素图层。</para>
		/// </param>
		/// <param name="UniqueIDField">
		/// <para>Unique ID Field</para>
		/// <para>包含输入要素类中每个要素不同值的整型字段。如果没有“唯一 ID”字段，则可以创建一个，方法是向要素类表添加一个整型字段，然后将此字段的值计算为与 FID 或 OBJECTID 字段的值相等。</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>创建的新输出要素类，其中包含所有要素、指定的分析字段以及一个用于指明每个要素所属组的字段。</para>
		/// </param>
		/// <param name="NumberOfGroups">
		/// <para>Number of Groups</para>
		/// <para>要创建的组数。如果多于 15 个组，将禁用输出报表参数。</para>
		/// </param>
		/// <param name="AnalysisFields">
		/// <para>Analysis Fields</para>
		/// <para>用于区分各个组的字段的列表。如果多于 15 个字段，将禁用输出报表参数。</para>
		/// </param>
		/// <param name="SpatialConstraints">
		/// <para>Spatial Constraints</para>
		/// <para>指定要素之间的空间关系是否应该约束所创建的组以及如何约束。</para>
		/// <para>仅邻接边—组中包含相邻的面要素。只有共享一条边的面才属于同一个组。</para>
		/// <para>邻接边拐角—组中包含相邻的面要素。只有共享一条边或一个折点的面才属于同一个组。</para>
		/// <para>Delaunay 三角测量—同一个组中的要素至少具有一个与该组中的另一要素共用的自然邻域。自然邻域关系基于 Delaunay 三角测量。从概念上讲，Delaunay 三角测量可以根据要素质心创建不重叠的三角网。每个要素是一个三角形结点，具有公共边的结点被视为邻域。</para>
		/// <para>K - 最近邻—同一个组中的要素将相互邻近；每个要素至少是该组中某一其他要素的邻域。邻域关系基于最近的 K 要素，您可以在此为相邻要素的数目参数指定整型值 K。</para>
		/// <para>通过文件获取空间权重—空间关系和可选的时态关系通过空间权重文件 (.swm) 进行定义。使用生成空间权重矩阵或生成网络空间权重工具创建空间权重矩阵文件。</para>
		/// <para>无空间约束—只能使用数据空间邻域法对要素进行分组。要素不是必须在空间或时间上互相接近，才能属于同一个组。</para>
		/// <para><see cref="SpatialConstraintsEnum"/></para>
		/// </param>
		public GroupingAnalysis(object InputFeatures, object UniqueIDField, object OutputFeatureClass, object NumberOfGroups, object AnalysisFields, object SpatialConstraints)
		{
			this.InputFeatures = InputFeatures;
			this.UniqueIDField = UniqueIDField;
			this.OutputFeatureClass = OutputFeatureClass;
			this.NumberOfGroups = NumberOfGroups;
			this.AnalysisFields = AnalysisFields;
			this.SpatialConstraints = SpatialConstraints;
		}

		/// <summary>
		/// <para>Tool Display Name : 分组分析</para>
		/// </summary>
		public override string DisplayName() => "分组分析";

		/// <summary>
		/// <para>Tool Name : GroupingAnalysis</para>
		/// </summary>
		public override string ToolName() => "GroupingAnalysis";

		/// <summary>
		/// <para>Tool Excute Name : stats.GroupingAnalysis</para>
		/// </summary>
		public override string ExcuteName() => "stats.GroupingAnalysis";

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
		public override object[] Parameters() => new object[] { InputFeatures, UniqueIDField, OutputFeatureClass, NumberOfGroups, AnalysisFields, SpatialConstraints, DistanceMethod, NumberOfNeighbors, WeightsMatrixFile, InitializationMethod, InitializationField, OutputReportFile, EvaluateOptimalNumberOfGroups, OutputFstat, MaxFstatGroup, MaxFstat };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要创建组的要素类或要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Unique ID Field</para>
		/// <para>包含输入要素类中每个要素不同值的整型字段。如果没有“唯一 ID”字段，则可以创建一个，方法是向要素类表添加一个整型字段，然后将此字段的值计算为与 FID 或 OBJECTID 字段的值相等。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object UniqueIDField { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>创建的新输出要素类，其中包含所有要素、指定的分析字段以及一个用于指明每个要素所属组的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Number of Groups</para>
		/// <para>要创建的组数。如果多于 15 个组，将禁用输出报表参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object NumberOfGroups { get; set; } = "2";

		/// <summary>
		/// <para>Analysis Fields</para>
		/// <para>用于区分各个组的字段的列表。如果多于 15 个字段，将禁用输出报表参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Date")]
		public object AnalysisFields { get; set; }

		/// <summary>
		/// <para>Spatial Constraints</para>
		/// <para>指定要素之间的空间关系是否应该约束所创建的组以及如何约束。</para>
		/// <para>仅邻接边—组中包含相邻的面要素。只有共享一条边的面才属于同一个组。</para>
		/// <para>邻接边拐角—组中包含相邻的面要素。只有共享一条边或一个折点的面才属于同一个组。</para>
		/// <para>Delaunay 三角测量—同一个组中的要素至少具有一个与该组中的另一要素共用的自然邻域。自然邻域关系基于 Delaunay 三角测量。从概念上讲，Delaunay 三角测量可以根据要素质心创建不重叠的三角网。每个要素是一个三角形结点，具有公共边的结点被视为邻域。</para>
		/// <para>K - 最近邻—同一个组中的要素将相互邻近；每个要素至少是该组中某一其他要素的邻域。邻域关系基于最近的 K 要素，您可以在此为相邻要素的数目参数指定整型值 K。</para>
		/// <para>通过文件获取空间权重—空间关系和可选的时态关系通过空间权重文件 (.swm) 进行定义。使用生成空间权重矩阵或生成网络空间权重工具创建空间权重矩阵文件。</para>
		/// <para>无空间约束—只能使用数据空间邻域法对要素进行分组。要素不是必须在空间或时间上互相接近，才能属于同一个组。</para>
		/// <para><see cref="SpatialConstraintsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SpatialConstraints { get; set; }

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>指定计算每个要素与邻近要素之间的距离的方式。</para>
		/// <para>欧氏—两点间的直线距离</para>
		/// <para>曼哈顿—沿垂直轴度量的两点间的距离（城市街区）；计算方法是对两点的 x 和 y 坐标的差值（绝对值）求和。</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceMethod { get; set; } = "EUCLIDEAN";

		/// <summary>
		/// <para>Number of Neighbors</para>
		/// <para>当空间约束参数为 K 最近邻域或邻接方法中的一种（仅邻接边或邻接边拐角）时，将启用此参数。默认的相邻要素数是 8，并且对于 K 最近邻域，此数目不能小于 2。该值反映在构建组时要考虑的最近邻域候选要素的准确数量。除非组中的一个其他要素是 K 最近邻域，否则不会将该要素包括在组中。仅邻接边和邻接边拐角的默认值为 0。对于邻接方法，该值反映了要考虑的最小邻域候选数量。如果要素的相邻要素的数目小于指定的相邻要素的数目，则将根据要素质心邻近性获得附加相邻要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumberOfNeighbors { get; set; } = "8";

		/// <summary>
		/// <para>Weights Matrix File</para>
		/// <para>指向包含空间权重（其定义了要素间的空间关系）的文件的路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("swm", "gwt")]
		public object WeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Initialization Method</para>
		/// <para>指定当选择的空间约束参数为无空间约束时如何获取初始种子。种子用来生长组。例如，如果您指明需要三个组，则分析将从三个种子开始。</para>
		/// <para>查找种子位置—选择种子要素以便优化性能。</para>
		/// <para>通过字段获取种子—“初始化字段”中的非零条目将被用作分组的起点。</para>
		/// <para>使用随机种子—将随机选择初始种子要素。</para>
		/// <para><see cref="InitializationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InitializationMethod { get; set; } = "FIND_SEED_LOCATIONS";

		/// <summary>
		/// <para>Initialization Field</para>
		/// <para>用于标识种子要素的数值型字段。将使用此字段中具有 1 值的要素进行分组。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object InitializationField { get; set; }

		/// <summary>
		/// <para>Output Report File</para>
		/// <para>所要创建的用于汇总组特征的 PDF 报表文件的完整路径。此报表提供了许多图表，以帮助您比较每个组的特征。创建报表文件会大大增加处理时间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("pdf")]
		public object OutputReportFile { get; set; }

		/// <summary>
		/// <para>Evaluate Optimal Number of Groups</para>
		/// <para>指定该工具是否将评估 2 到 15 的最佳组数。</para>
		/// <para>选中 - 对从 2 到 15 的组数进行评估。</para>
		/// <para>取消选中 - 不对组数进行评估。这是默认设置。</para>
		/// <para><see cref="EvaluateOptimalNumberOfGroupsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object EvaluateOptimalNumberOfGroups { get; set; } = "false";

		/// <summary>
		/// <para>F Statistic</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object OutputFstat { get; set; }

		/// <summary>
		/// <para>Maximum F Statistic Group</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object MaxFstatGroup { get; set; }

		/// <summary>
		/// <para>Maximum F Statistic</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPDouble()]
		public object MaxFstat { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GroupingAnalysis SetEnviroment(object MResolution = null, object MTolerance = null, object XYResolution = null, object XYTolerance = null, object ZResolution = null, object ZTolerance = null, object geographicTransformations = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, bool? qualifiedFieldNames = null, object randomGenerator = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, randomGenerator: randomGenerator, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Spatial Constraints</para>
		/// </summary>
		public enum SpatialConstraintsEnum 
		{
			/// <summary>
			/// <para>仅邻接边—组中包含相邻的面要素。只有共享一条边的面才属于同一个组。</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_ONLY")]
			[Description("仅邻接边")]
			Contiguity_edges_only,

			/// <summary>
			/// <para>邻接边拐角—组中包含相邻的面要素。只有共享一条边或一个折点的面才属于同一个组。</para>
			/// </summary>
			[GPValue("CONTIGUITY_EDGES_CORNERS")]
			[Description("邻接边拐角")]
			Contiguity_edges_corners,

			/// <summary>
			/// <para>Delaunay 三角测量—同一个组中的要素至少具有一个与该组中的另一要素共用的自然邻域。自然邻域关系基于 Delaunay 三角测量。从概念上讲，Delaunay 三角测量可以根据要素质心创建不重叠的三角网。每个要素是一个三角形结点，具有公共边的结点被视为邻域。</para>
			/// </summary>
			[GPValue("DELAUNAY_TRIANGULATION")]
			[Description("Delaunay 三角测量")]
			Delaunay_triangulation,

			/// <summary>
			/// <para>K - 最近邻—同一个组中的要素将相互邻近；每个要素至少是该组中某一其他要素的邻域。邻域关系基于最近的 K 要素，您可以在此为相邻要素的数目参数指定整型值 K。</para>
			/// </summary>
			[GPValue("K_NEAREST_NEIGHBORS")]
			[Description("K - 最近邻")]
			K_nearest_neighbors,

			/// <summary>
			/// <para>通过文件获取空间权重—空间关系和可选的时态关系通过空间权重文件 (.swm) 进行定义。使用生成空间权重矩阵或生成网络空间权重工具创建空间权重矩阵文件。</para>
			/// </summary>
			[GPValue("GET_SPATIAL_WEIGHTS_FROM_FILE")]
			[Description("通过文件获取空间权重")]
			Get_spatial_weights_from_file,

			/// <summary>
			/// <para>无空间约束—只能使用数据空间邻域法对要素进行分组。要素不是必须在空间或时间上互相接近，才能属于同一个组。</para>
			/// </summary>
			[GPValue("NO_SPATIAL_CONSTRAINT")]
			[Description("无空间约束")]
			No_spatial_constraint,

		}

		/// <summary>
		/// <para>Distance Method</para>
		/// </summary>
		public enum DistanceMethodEnum 
		{
			/// <summary>
			/// <para>欧氏—两点间的直线距离</para>
			/// </summary>
			[GPValue("EUCLIDEAN")]
			[Description("欧氏")]
			Euclidean,

			/// <summary>
			/// <para>曼哈顿—沿垂直轴度量的两点间的距离（城市街区）；计算方法是对两点的 x 和 y 坐标的差值（绝对值）求和。</para>
			/// </summary>
			[GPValue("MANHATTAN")]
			[Description("曼哈顿")]
			Manhattan,

		}

		/// <summary>
		/// <para>Initialization Method</para>
		/// </summary>
		public enum InitializationMethodEnum 
		{
			/// <summary>
			/// <para>查找种子位置—选择种子要素以便优化性能。</para>
			/// </summary>
			[GPValue("FIND_SEED_LOCATIONS")]
			[Description("查找种子位置")]
			Find_seed_locations,

			/// <summary>
			/// <para>通过字段获取种子—“初始化字段”中的非零条目将被用作分组的起点。</para>
			/// </summary>
			[GPValue("GET_SEEDS_FROM_FIELD")]
			[Description("通过字段获取种子")]
			Get_seeds_from_field,

			/// <summary>
			/// <para>使用随机种子—将随机选择初始种子要素。</para>
			/// </summary>
			[GPValue("USE_RANDOM_SEEDS")]
			[Description("使用随机种子")]
			Use_random_seeds,

		}

		/// <summary>
		/// <para>Evaluate Optimal Number of Groups</para>
		/// </summary>
		public enum EvaluateOptimalNumberOfGroupsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EVALUATE")]
			EVALUATE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_EVALUATE")]
			DO_NOT_EVALUATE,

		}

#endregion
	}
}
