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
	/// <para>Colocation Analysis</para>
	/// <para>协同区位分析</para>
	/// <para>使用协同区位商统计测量两类点要素之间的空间关联或区位协同的局部模式。</para>
	/// </summary>
	public class ColocationAnalysis : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputType">
		/// <para>Input Type</para>
		/// <para>指定感兴趣的输入要素是来自包含指定类别的同一数据集、包含指定类别的不同数据集还是将被视为其自身类别的不同数据集（例如，一个数据集包含表示猎豹的所有点，另一个数据集包含表示瞪羚的所有点）。</para>
		/// <para>单个数据集—要分析的类别存在于单个数据集的某个字段中。</para>
		/// <para>两个数据集—要分析的类别存在于单独数据集的多个字段中。</para>
		/// <para>不含类别的数据集—将分析表示两个类别的两个单独数据集。</para>
		/// <para><see cref="InputTypeEnum"/></para>
		/// </param>
		/// <param name="InFeaturesOfInterest">
		/// <para>Input Features of Interest</para>
		/// <para>包含具有代表性类别的点的要素类。</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>该输出要素类包含所有感兴趣的输入要素并具有包含生成的局部协同区位商、符号系统立方图格和 p 值的字段。</para>
		/// </param>
		public ColocationAnalysis(object InputType, object InFeaturesOfInterest, object OutputFeatures)
		{
			this.InputType = InputType;
			this.InFeaturesOfInterest = InFeaturesOfInterest;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 协同区位分析</para>
		/// </summary>
		public override string DisplayName() => "协同区位分析";

		/// <summary>
		/// <para>Tool Name : ColocationAnalysis</para>
		/// </summary>
		public override string ToolName() => "ColocationAnalysis";

		/// <summary>
		/// <para>Tool Excute Name : stats.ColocationAnalysis</para>
		/// </summary>
		public override string ExcuteName() => "stats.ColocationAnalysis";

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
		public override object[] Parameters() => new object[] { InputType, InFeaturesOfInterest, OutputFeatures, FieldOfInterest, TimeFieldOfInterest, CategoryOfInterest, InputFeatureForComparison, FieldForComparison, TimeFieldForComparison, CategoryForComparison, NeighborhoodType, NumberOfNeighbors, DistanceBand, WeightsMatrixFile, TemporalRelationshipType, TimeStepInterval, NumberOfPermutations, LocalWeightingScheme, OutputTable };

		/// <summary>
		/// <para>Input Type</para>
		/// <para>指定感兴趣的输入要素是来自包含指定类别的同一数据集、包含指定类别的不同数据集还是将被视为其自身类别的不同数据集（例如，一个数据集包含表示猎豹的所有点，另一个数据集包含表示瞪羚的所有点）。</para>
		/// <para>单个数据集—要分析的类别存在于单个数据集的某个字段中。</para>
		/// <para>两个数据集—要分析的类别存在于单独数据集的多个字段中。</para>
		/// <para>不含类别的数据集—将分析表示两个类别的两个单独数据集。</para>
		/// <para><see cref="InputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InputType { get; set; } = "SINGLE_DATASET";

		/// <summary>
		/// <para>Input Features of Interest</para>
		/// <para>包含具有代表性类别的点的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InFeaturesOfInterest { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>该输出要素类包含所有感兴趣的输入要素并具有包含生成的局部协同区位商、符号系统立方图格和 p 值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Field of Interest</para>
		/// <para>包含要分析的一个或多个类别的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object FieldOfInterest { get; set; }

		/// <summary>
		/// <para>Time Field of Interest</para>
		/// <para>具有每个要素的可选时间戳的日期字段，以供使用空间时间窗口分析点。在空间和时间上彼此相邻的要素将被视为相邻要素，并将一起进行分析。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object TimeFieldOfInterest { get; set; }

		/// <summary>
		/// <para>Category of Interest</para>
		/// <para>分析的基本类别。该工具将针对每个感兴趣类别值确定，基本类别被相邻类别吸引或与之区位协同的程度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object CategoryOfInterest { get; set; }

		/// <summary>
		/// <para>Input Neighboring Features</para>
		/// <para>该输入要素类包含具有要比较的类别的点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InputFeatureForComparison { get; set; }

		/// <summary>
		/// <para>Field Containing Neighboring Category</para>
		/// <para>来自输入相邻要素参数的字段，包含要比较的类别。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object FieldForComparison { get; set; }

		/// <summary>
		/// <para>Time Field of Neighboring Features</para>
		/// <para>具有每个要素的时间戳的日期字段，以供使用空间时间窗分析点。在空间和时间上彼此相邻的要素将被视为相邻要素，并将一起进行分析。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object TimeFieldForComparison { get; set; }

		/// <summary>
		/// <para>Neighboring Category</para>
		/// <para>分析的相邻类别。该工具将确定感兴趣类别被相邻类别吸引或与之相互隔离的程度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object CategoryForComparison { get; set; }

		/// <summary>
		/// <para>Neighborhood Type</para>
		/// <para>指定要素空间关系的定义方式。</para>
		/// <para>距离范围—将对邻近要素环境中的每个要素进行分析。指定临界距离（由距离范围参数指定）内的相邻要素的权重为 1，并对目标要素的计算产生影响。指定临界距离之外的相邻要素的权重为零，并且不会对目标要素的计算产生任何影响。</para>
		/// <para>K - 最近邻—将最近的 k 个要素包含在分析中作为相邻要素。相邻要素数由相邻要素数参数指定。这是默认设置。</para>
		/// <para>通过文件获取空间权重—当将单个数据集用作输入类型时，可以通过指定的空间权重矩阵文件定义空间关系。指向空间权重文件的路径由权重矩阵文件参数指定。</para>
		/// <para><see cref="NeighborhoodTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object NeighborhoodType { get; set; } = "K_NEAREST_NEIGHBORS";

		/// <summary>
		/// <para>Number of Neighbors</para>
		/// <para>每个要素周围用于测试类别之间的局部关系的相邻要素数。如果未指定任何值，则将使用默认值 8。提供的值必须足够大，才能检测要素之间的关系，但同时要小到足以识别局部模式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 1, Max = 1000)]
		public object NumberOfNeighbors { get; set; } = "8";

		/// <summary>
		/// <para>Distance Band</para>
		/// <para>邻域大小是每个要素的恒定或固定距离。此距离内的所有要素都将用于测试类别之间的局部关系。如果未提供任何值，则使用的距离将是每个要素至少具有八个相邻要素的平均距离。</para>
		/// <para><see cref="DistanceBandEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object DistanceBand { get; set; }

		/// <summary>
		/// <para>Weight Matrix File</para>
		/// <para>包含权重（其定义要素间的空间关系以及可能的时态关系）的文件的路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("swm", "gwt")]
		public object WeightsMatrixFile { get; set; }

		/// <summary>
		/// <para>Temporal Relationship Type</para>
		/// <para>指定要素时态关系的定义方式。</para>
		/// <para>之前—时间窗口将针对每个感兴趣的输入要素值向后延长时间。相邻要素的日期/时间戳必须发生在感兴趣要素的日期/时间戳之前才能包含在分析中。这是默认设置。</para>
		/// <para>之后—时间窗口将针对每个感兴趣的输入要素值向前延长时间。相邻要素的日期/时间戳必须发生在感兴趣要素的日期/时间戳之后才能包含在分析中。</para>
		/// <para>跨度—时间窗口将针对每个感兴趣的输入要素值同时向前和向后延长时间。将在分析中包含日期/时间戳发生在感兴趣要素的日期/时间戳时间步长间隔值之前或之后的相邻要素。例如，如果时间步长间隔参数设置为 1 周，则窗口将在目标要素 1 周之前和 1 周之后进行查找。</para>
		/// <para><see cref="TemporalRelationshipTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TemporalRelationshipType { get; set; } = "BEFORE";

		/// <summary>
		/// <para>Time Step Interval</para>
		/// <para>表示构成时间窗口的时间单位数的整数和测量单位。</para>
		/// <para><see cref="TimeStepIntervalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object TimeStepInterval { get; set; }

		/// <summary>
		/// <para>Number of Permutations</para>
		/// <para>用于创建参考分布的置换检验次数。选择置换检验次数时，需要兼顾精度和所需增加的处理时间。根据偏好选择速度或精度。结果越可靠越精确计算所花费的时间就会越长。</para>
		/// <para>99—分析将使用 99 次置换检验。如果置换检验次数为 99，则可能的最小伪 p 值为 0.02，其他所有伪 p 值将是该值的倍数。这是默认设置。</para>
		/// <para>199—分析将使用 199 次置换检验。如果置换次数为 199，则可能的最小伪 p 值为 0.01，其他所有伪 p 值将是该值的数倍。</para>
		/// <para>499—分析将使用 499 次置换检验。如果置换次数为 499，则可能的最小伪 p 值为 0.004，其他所有伪 p 值将是该值的数倍。</para>
		/// <para>999—分析将使用 999 次置换检验。如果置换次数为 999，则可能的最小伪 p 值为 0.002，其他所有伪 p 值将是该值的数倍。</para>
		/// <para>9999—分析将使用 9999 次置换检验。如果置换检验次数为 9999，则可能的最小伪 p 值为 0.0002，其他所有伪 p 值将是该值的数倍。</para>
		/// <para><see cref="NumberOfPermutationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPCodedValueDomain()]
		public object NumberOfPermutations { get; set; } = "99";

		/// <summary>
		/// <para>Local Weighting Scheme</para>
		/// <para>指定用于提供空间加权的核类型。核用于定义每个要素与其邻域内其他要素的关联方式。</para>
		/// <para>双平方—将根据距最远相邻要素或距离范围边的距离对要素进行加权，并且将值为 0 的权重分配给指定邻域以外的任何要素。</para>
		/// <para>高斯函数—将根据距最远相邻要素或距离范围边的距离对要素进行加权，但与双平方选项相比，下降速度更快。权重 0 将会分配给指定邻域外的任何要素。这是默认设置。</para>
		/// <para>无—不应用加权方案，并且邻域内的所有要素的权重均为 1 且贡献均等。邻域外的所有要素的权重均为 0。</para>
		/// <para><see cref="LocalWeightingSchemeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Additional Options")]
		public object LocalWeightingScheme { get; set; } = "GAUSSIAN";

		/// <summary>
		/// <para>Output Table for Global Relationships</para>
		/// <para>包含感兴趣字段参数中所有类别和包含相邻类别的字段参数中所有类别之间的全局协同区位商的表格。此表可帮助您确定要分析的局部类别。</para>
		/// <para>如果将不含类别的数据集用作输入类型参数值，则将计算每个数据集和各个数据集之间的全局协同区位商。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Additional Options")]
		public object OutputTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ColocationAnalysis SetEnviroment(object outputCoordinateSystem = null, object parallelProcessingFactor = null, object randomGenerator = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, randomGenerator: randomGenerator);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Input Type</para>
		/// </summary>
		public enum InputTypeEnum 
		{
			/// <summary>
			/// <para>单个数据集—要分析的类别存在于单个数据集的某个字段中。</para>
			/// </summary>
			[GPValue("SINGLE_DATASET")]
			[Description("单个数据集")]
			Single_dataset,

			/// <summary>
			/// <para>不含类别的数据集—将分析表示两个类别的两个单独数据集。</para>
			/// </summary>
			[GPValue("DATASETS_WITHOUT_CATEGORIES")]
			[Description("不含类别的数据集")]
			Datasets_without_categories,

			/// <summary>
			/// <para>两个数据集—要分析的类别存在于单独数据集的多个字段中。</para>
			/// </summary>
			[GPValue("TWO_DATASETS")]
			[Description("两个数据集")]
			Two_datasets,

		}

		/// <summary>
		/// <para>Neighborhood Type</para>
		/// </summary>
		public enum NeighborhoodTypeEnum 
		{
			/// <summary>
			/// <para>K - 最近邻—将最近的 k 个要素包含在分析中作为相邻要素。相邻要素数由相邻要素数参数指定。这是默认设置。</para>
			/// </summary>
			[GPValue("K_NEAREST_NEIGHBORS")]
			[Description("K - 最近邻")]
			K_nearest_neighbors,

			/// <summary>
			/// <para>距离范围—将对邻近要素环境中的每个要素进行分析。指定临界距离（由距离范围参数指定）内的相邻要素的权重为 1，并对目标要素的计算产生影响。指定临界距离之外的相邻要素的权重为零，并且不会对目标要素的计算产生任何影响。</para>
			/// </summary>
			[GPValue("DISTANCE_BAND")]
			[Description("距离范围")]
			Distance_band,

			/// <summary>
			/// <para>通过文件获取空间权重—当将单个数据集用作输入类型时，可以通过指定的空间权重矩阵文件定义空间关系。指向空间权重文件的路径由权重矩阵文件参数指定。</para>
			/// </summary>
			[GPValue("GET_SPATIAL_WEIGHTS_FROM_FILE")]
			[Description("通过文件获取空间权重")]
			Get_spatial_weights_from_file,

		}

		/// <summary>
		/// <para>Distance Band</para>
		/// </summary>
		public enum DistanceBandEnum 
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
		/// <para>Temporal Relationship Type</para>
		/// </summary>
		public enum TemporalRelationshipTypeEnum 
		{
			/// <summary>
			/// <para>之前—时间窗口将针对每个感兴趣的输入要素值向后延长时间。相邻要素的日期/时间戳必须发生在感兴趣要素的日期/时间戳之前才能包含在分析中。这是默认设置。</para>
			/// </summary>
			[GPValue("BEFORE")]
			[Description("之前")]
			Before,

			/// <summary>
			/// <para>之后—时间窗口将针对每个感兴趣的输入要素值向前延长时间。相邻要素的日期/时间戳必须发生在感兴趣要素的日期/时间戳之后才能包含在分析中。</para>
			/// </summary>
			[GPValue("AFTER")]
			[Description("之后")]
			After,

			/// <summary>
			/// <para>跨度—时间窗口将针对每个感兴趣的输入要素值同时向前和向后延长时间。将在分析中包含日期/时间戳发生在感兴趣要素的日期/时间戳时间步长间隔值之前或之后的相邻要素。例如，如果时间步长间隔参数设置为 1 周，则窗口将在目标要素 1 周之前和 1 周之后进行查找。</para>
			/// </summary>
			[GPValue("SPAN")]
			[Description("跨度")]
			Span,

		}

		/// <summary>
		/// <para>Time Step Interval</para>
		/// </summary>
		public enum TimeStepIntervalEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Seconds")]
			[Description("Seconds")]
			Seconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Hours")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Days")]
			[Description("Days")]
			Days,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Weeks")]
			[Description("Weeks")]
			Weeks,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Months")]
			[Description("Months")]
			Months,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Years")]
			[Description("Years")]
			Years,

		}

		/// <summary>
		/// <para>Number of Permutations</para>
		/// </summary>
		public enum NumberOfPermutationsEnum 
		{
			/// <summary>
			/// <para>99—分析将使用 99 次置换检验。如果置换检验次数为 99，则可能的最小伪 p 值为 0.02，其他所有伪 p 值将是该值的倍数。这是默认设置。</para>
			/// </summary>
			[GPValue("99")]
			[Description("99")]
			_99,

			/// <summary>
			/// <para>199—分析将使用 199 次置换检验。如果置换次数为 199，则可能的最小伪 p 值为 0.01，其他所有伪 p 值将是该值的数倍。</para>
			/// </summary>
			[GPValue("199")]
			[Description("199")]
			_199,

			/// <summary>
			/// <para>499—分析将使用 499 次置换检验。如果置换次数为 499，则可能的最小伪 p 值为 0.004，其他所有伪 p 值将是该值的数倍。</para>
			/// </summary>
			[GPValue("499")]
			[Description("499")]
			_499,

			/// <summary>
			/// <para>999—分析将使用 999 次置换检验。如果置换次数为 999，则可能的最小伪 p 值为 0.002，其他所有伪 p 值将是该值的数倍。</para>
			/// </summary>
			[GPValue("999")]
			[Description("999")]
			_999,

			/// <summary>
			/// <para>9999—分析将使用 9999 次置换检验。如果置换检验次数为 9999，则可能的最小伪 p 值为 0.0002，其他所有伪 p 值将是该值的数倍。</para>
			/// </summary>
			[GPValue("9999")]
			[Description("9999")]
			_9999,

		}

		/// <summary>
		/// <para>Local Weighting Scheme</para>
		/// </summary>
		public enum LocalWeightingSchemeEnum 
		{
			/// <summary>
			/// <para>双平方—将根据距最远相邻要素或距离范围边的距离对要素进行加权，并且将值为 0 的权重分配给指定邻域以外的任何要素。</para>
			/// </summary>
			[GPValue("BISQUARE")]
			[Description("双平方")]
			Bisquare,

			/// <summary>
			/// <para>高斯函数—将根据距最远相邻要素或距离范围边的距离对要素进行加权，但与双平方选项相比，下降速度更快。权重 0 将会分配给指定邻域外的任何要素。这是默认设置。</para>
			/// </summary>
			[GPValue("GAUSSIAN")]
			[Description("高斯函数")]
			Gaussian,

			/// <summary>
			/// <para>无—不应用加权方案，并且邻域内的所有要素的权重均为 1 且贡献均等。邻域外的所有要素的权重均为 0。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

		}

#endregion
	}
}
