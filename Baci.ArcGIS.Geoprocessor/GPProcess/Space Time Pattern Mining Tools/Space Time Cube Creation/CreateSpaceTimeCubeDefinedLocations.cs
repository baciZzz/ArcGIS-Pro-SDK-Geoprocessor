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
	/// <para>Create Space Time Cube From Defined Locations</para>
	/// <para>通过已定义位置创建时空立方体</para>
	/// <para>获取面板数据或测点数据（地理位置不变但属性会随时间改变的已定义位置），并通过创建时空立方图格将其构建为 netCDF 数据格式。对于所有位置，评估变量或汇总字段趋势。</para>
	/// </summary>
	public class CreateSpaceTimeCubeDefinedLocations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要转换为时空立方体的输入点或面要素类。</para>
		/// </param>
		/// <param name="OutputCube">
		/// <para>Output Space Time Cube</para>
		/// <para>将创建的输出 netCDF 数据立方体。</para>
		/// </param>
		/// <param name="LocationId">
		/// <para>Location ID</para>
		/// <para>包含每个唯一位置的 ID 编号的整型字段。</para>
		/// </param>
		/// <param name="TemporalAggregation">
		/// <para>Temporal Aggregation</para>
		/// <para>确定是否对数据进行时间聚合。</para>
		/// <para>取消选中 - 时空立方体将通过输入要素的现有时间结构进行创建。例如，您有一组年度数据，并希望通过年度时间步长间隔创建立方体。这是默认设置。</para>
		/// <para>选中 - 时空立方体将根据您提供的时间步长间隔对您的要素进行时间聚合。例如，您有一组每日收集的数据，并希望通过每周时间步长间隔创建立方体。</para>
		/// <para><see cref="TemporalAggregationEnum"/></para>
		/// </param>
		/// <param name="TimeField">
		/// <para>Time Field</para>
		/// <para>包含数据集中每行的时间戳的字段。此字段必须为日期类型。</para>
		/// </param>
		/// <param name="TimeStepInterval">
		/// <para>Time Step Interval</para>
		/// <para>用来表示单个时间步长的秒数、分钟数、小时数、天数、周数或年数。此参数的有效条目示例为 1 周、13 天或 1 个月。</para>
		/// <para>如果取消选中时间聚合，则不进行时间聚合，且此参数应设置为数据的现有时间结构。</para>
		/// <para>如果选中时间聚合，则会进行时间聚合，且此参数应设置为您要创建的时间步长间隔。将聚合相同时间步长间隔内的所有要素。</para>
		/// </param>
		public CreateSpaceTimeCubeDefinedLocations(object InFeatures, object OutputCube, object LocationId, object TemporalAggregation, object TimeField, object TimeStepInterval)
		{
			this.InFeatures = InFeatures;
			this.OutputCube = OutputCube;
			this.LocationId = LocationId;
			this.TemporalAggregation = TemporalAggregation;
			this.TimeField = TimeField;
			this.TimeStepInterval = TimeStepInterval;
		}

		/// <summary>
		/// <para>Tool Display Name : 通过已定义位置创建时空立方体</para>
		/// </summary>
		public override string DisplayName() => "通过已定义位置创建时空立方体";

		/// <summary>
		/// <para>Tool Name : CreateSpaceTimeCubeDefinedLocations</para>
		/// </summary>
		public override string ToolName() => "CreateSpaceTimeCubeDefinedLocations";

		/// <summary>
		/// <para>Tool Excute Name : stpm.CreateSpaceTimeCubeDefinedLocations</para>
		/// </summary>
		public override string ExcuteName() => "stpm.CreateSpaceTimeCubeDefinedLocations";

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
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutputCube, LocationId, TemporalAggregation, TimeField, TimeStepInterval, TimeStepAlignment!, ReferenceTime!, Variables!, SummaryFields!, InRelatedTable!, RelatedLocationId! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要转换为时空立方体的输入点或面要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Space Time Cube</para>
		/// <para>将创建的输出 netCDF 数据立方体。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object OutputCube { get; set; }

		/// <summary>
		/// <para>Location ID</para>
		/// <para>包含每个唯一位置的 ID 编号的整型字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object LocationId { get; set; }

		/// <summary>
		/// <para>Temporal Aggregation</para>
		/// <para>确定是否对数据进行时间聚合。</para>
		/// <para>取消选中 - 时空立方体将通过输入要素的现有时间结构进行创建。例如，您有一组年度数据，并希望通过年度时间步长间隔创建立方体。这是默认设置。</para>
		/// <para>选中 - 时空立方体将根据您提供的时间步长间隔对您的要素进行时间聚合。例如，您有一组每日收集的数据，并希望通过每周时间步长间隔创建立方体。</para>
		/// <para><see cref="TemporalAggregationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object TemporalAggregation { get; set; } = "false";

		/// <summary>
		/// <para>Time Field</para>
		/// <para>包含数据集中每行的时间戳的字段。此字段必须为日期类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object TimeField { get; set; }

		/// <summary>
		/// <para>Time Step Interval</para>
		/// <para>用来表示单个时间步长的秒数、分钟数、小时数、天数、周数或年数。此参数的有效条目示例为 1 周、13 天或 1 个月。</para>
		/// <para>如果取消选中时间聚合，则不进行时间聚合，且此参数应设置为数据的现有时间结构。</para>
		/// <para>如果选中时间聚合，则会进行时间聚合，且此参数应设置为您要创建的时间步长间隔。将聚合相同时间步长间隔内的所有要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object TimeStepInterval { get; set; }

		/// <summary>
		/// <para>Time Step Alignment</para>
		/// <para>定义如何根据给定的时间步长间隔创建立方体结构。</para>
		/// <para>结束时间—时间步长与最后一次时间事件对齐，并向后聚合时间。这是默认设置。</para>
		/// <para>开始时间—时间步长与第一次时间事件对齐，并向前聚合时间。</para>
		/// <para>参考时间—时间步长将与指定的特定日期/时间对齐。如果输入要素中的所有点的时间戳大于您所提供的参考时间（或时间戳刚好位于输入要素的开始时间），则时间步长间隔将以该参考时间为开始时间，并向前聚合时间（与使用开始时间对齐的效果相同）。如果输入要素中的所有点的时间戳小于您所提供的参考时间（或时间戳刚好位于输入要素的结束时间），则时间步长间隔将以该参考时间为结束时间，并向后聚合时间（与使用结束时间对齐的效果相同）。如果提供的参考时间处于数据时间范围的中间，则将以提供的参考时间结束创建时间步长间隔（与使用结束时间对齐的情况相同）；其他间隔将在参考时间前后进行创建，直到覆盖数据的完整时间范围为止。</para>
		/// <para><see cref="TimeStepAlignmentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TimeStepAlignment { get; set; } = "END_TIME";

		/// <summary>
		/// <para>Reference Time</para>
		/// <para>用于对齐时间步长间隔的日期/时间。例如，如果想要按星期从星期一至星期天对数据进行归类，可以将星期天的午夜设置为参考时间，以确保立方图格在星期天和星期一之间的午夜进行划分。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? ReferenceTime { get; set; }

		/// <summary>
		/// <para>Variables</para>
		/// <para>将在时空立方体中引入的包含属性值的数值字段。</para>
		/// <para>可用填充类型有：</para>
		/// <para>DROP_LOCATIONS - 缺少任何变量的数据的位置将从输出时空立方体中删除。</para>
		/// <para>ZEROS - 用零填充空立方图格。</para>
		/// <para>SPATIAL_NEIGHBORS - 用空间相邻要素平均值填充空立方图格。</para>
		/// <para>SPACE_TIME_NEIGHBORS - 用时空相邻要素平均值填充空立方图格。</para>
		/// <para>TEMPORAL_TREND - 使用一元样条插值算法填充空立方图格。</para>
		/// <para>任何变量记录中出现的空值都将导致产生空立方图格。如果输入要素中出现空值，则强烈建议您先运行填充缺失值工具。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? Variables { get; set; }

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>包含属性值的数值字段，用于在将数据聚合到时空立方体时计算指定的统计数据。可以指定多项统计和字段组合。在任何指定字段中出现的空值都将导致从输出立方体中删除相应要素。如果输入要素中出现空值，则强烈建议您在创建时空立方体前先运行填充缺失值工具。</para>
		/// <para>可用的统计类型有：</para>
		/// <para>SUM - 添加每个立方图格中指定字段的合计值。</para>
		/// <para>MEAN - 计算每个立方图格中指定字段的平均值。</para>
		/// <para>MIN - 查找每个立方图格中指定字段所有记录的最小值。</para>
		/// <para>MAX - 查找每个立方图格中指定字段所有记录的最大值。</para>
		/// <para>STD - 查找每个立方图格中指定字段的值的标准差。</para>
		/// <para>MEDIAN - 查找每个立方图格中指定字段所有记录的中值。</para>
		/// <para>可用填充类型有：</para>
		/// <para>ZEROS - 用零填充空立方图格。</para>
		/// <para>SPATIAL_NEIGHBORS - 用空间相邻要素平均值填充空立方图格</para>
		/// <para>SPACE_TIME_NEIGHBORS - 用时空相邻要素平均值填充空立方图格。</para>
		/// <para>TEMPORAL_TREND - 使用一元样条插值算法填充空立方图格。</para>
		/// <para>任何汇总字段记录中出现的空值都将导致从输出立方体中排除这些要素。如果输入要素中出现空值，则强烈建议您先运行填充缺失值工具。如果在运行填充缺失值工具后，仍存在空值而每个立方图格中的点数是分析策略的一部分，您可能需要考虑创建单独的立方体，针对计数（不含汇总字段）创建一个，并针对汇总字段创建一个。如果每个汇总字段的空值集不相同，您可能还需要考虑为每个汇总字段创建一个单独的立方体。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? SummaryFields { get; set; }

		/// <summary>
		/// <para>Related Table</para>
		/// <para>将关联到输入要素的表或表视图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		public object? InRelatedTable { get; set; }

		/// <summary>
		/// <para>Related Location ID</para>
		/// <para>相关表中包含基于关联的位置 ID 的整型字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object? RelatedLocationId { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateSpaceTimeCubeDefinedLocations SetEnviroment(object? geographicTransformations = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Temporal Aggregation</para>
		/// </summary>
		public enum TemporalAggregationEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("APPLY_TEMPORAL_AGGREGATION")]
			APPLY_TEMPORAL_AGGREGATION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_TEMPORAL_AGGREGATION")]
			NO_TEMPORAL_AGGREGATION,

		}

		/// <summary>
		/// <para>Time Step Alignment</para>
		/// </summary>
		public enum TimeStepAlignmentEnum 
		{
			/// <summary>
			/// <para>结束时间—时间步长与最后一次时间事件对齐，并向后聚合时间。这是默认设置。</para>
			/// </summary>
			[GPValue("END_TIME")]
			[Description("结束时间")]
			End_time,

			/// <summary>
			/// <para>开始时间—时间步长与第一次时间事件对齐，并向前聚合时间。</para>
			/// </summary>
			[GPValue("START_TIME")]
			[Description("开始时间")]
			Start_time,

			/// <summary>
			/// <para>参考时间—时间步长将与指定的特定日期/时间对齐。如果输入要素中的所有点的时间戳大于您所提供的参考时间（或时间戳刚好位于输入要素的开始时间），则时间步长间隔将以该参考时间为开始时间，并向前聚合时间（与使用开始时间对齐的效果相同）。如果输入要素中的所有点的时间戳小于您所提供的参考时间（或时间戳刚好位于输入要素的结束时间），则时间步长间隔将以该参考时间为结束时间，并向后聚合时间（与使用结束时间对齐的效果相同）。如果提供的参考时间处于数据时间范围的中间，则将以提供的参考时间结束创建时间步长间隔（与使用结束时间对齐的情况相同）；其他间隔将在参考时间前后进行创建，直到覆盖数据的完整时间范围为止。</para>
			/// </summary>
			[GPValue("REFERENCE_TIME")]
			[Description("参考时间")]
			Reference_time,

		}

#endregion
	}
}
