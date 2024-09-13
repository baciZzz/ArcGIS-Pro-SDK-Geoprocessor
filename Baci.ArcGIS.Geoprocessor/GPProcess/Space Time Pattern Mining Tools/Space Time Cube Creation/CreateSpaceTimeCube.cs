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
	/// <para>Create Space Time Cube By Aggregating Points</para>
	/// <para>通过聚合点创建时空立方体</para>
	/// <para>通过将一组点聚合到空间时间立方图格的方法将其汇总到 netCDF 数据结构中。在每个立方图格内计算点计数并聚合指定属性。对于所有立方图格位置，评估计数趋势和汇总字段值。</para>
	/// </summary>
	public class CreateSpaceTimeCube : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要聚合到时空立方图格的输入点要素类。</para>
		/// </param>
		/// <param name="OutputCube">
		/// <para>Output Space Time Cube</para>
		/// <para>将创建的输出 netCDF 数据立方体，以包含输入要素点数据的计数和汇总。</para>
		/// </param>
		/// <param name="TimeField">
		/// <para>Time Field</para>
		/// <para>包含每个点的日期和时间（时间戳）的字段。此字段必须为日期类型。</para>
		/// </param>
		public CreateSpaceTimeCube(object InFeatures, object OutputCube, object TimeField)
		{
			this.InFeatures = InFeatures;
			this.OutputCube = OutputCube;
			this.TimeField = TimeField;
		}

		/// <summary>
		/// <para>Tool Display Name : 通过聚合点创建时空立方体</para>
		/// </summary>
		public override string DisplayName() => "通过聚合点创建时空立方体";

		/// <summary>
		/// <para>Tool Name : CreateSpaceTimeCube</para>
		/// </summary>
		public override string ToolName() => "CreateSpaceTimeCube";

		/// <summary>
		/// <para>Tool Excute Name : stpm.CreateSpaceTimeCube</para>
		/// </summary>
		public override string ExcuteName() => "stpm.CreateSpaceTimeCube";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutputCube, TimeField, TemplateCube, TimeStepInterval, TimeStepAlignment, ReferenceTime, DistanceInterval, SummaryFields, AggregationShapeType, DefinedPolygonLocations, LocationId };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要聚合到时空立方图格的输入点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Space Time Cube</para>
		/// <para>将创建的输出 netCDF 数据立方体，以包含输入要素点数据的计数和汇总。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object OutputCube { get; set; }

		/// <summary>
		/// <para>Time Field</para>
		/// <para>包含每个点的日期和时间（时间戳）的字段。此字段必须为日期类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object TimeField { get; set; }

		/// <summary>
		/// <para>Template Cube</para>
		/// <para>用于定义输出时空立方体分析范围、立方图格维度和立方图格对齐方式的参考时空立方体。还可从模板立方体获取时间步长间隔、距离间隔和参考时间信息。该模板立方体必须是已使用此工具创建的 netCDF (.nc) 文件。</para>
		/// <para>通过聚合到已定义位置而创建的时空立方体不能用作模板立方体。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("nc")]
		public object TemplateCube { get; set; }

		/// <summary>
		/// <para>Time Step Interval</para>
		/// <para>用来表示单个时间步长的秒数、分钟数、小时数、天数、周数或年数。将聚合相同时间步长间隔和距离间隔中的所有点。（提供模板立方体时，将忽略此参数，并从该模板立方体获取时间步长间隔值。）</para>
		/// <para><see cref="TimeStepIntervalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object TimeStepInterval { get; set; }

		/// <summary>
		/// <para>Time Step Alignment</para>
		/// <para>定义如何根据给定的时间步长间隔进行聚合。如果提供模板立方体，则与模板立方体相关的时间步长对齐将会覆盖此参数设置，并将使用模板立方体的时间步长对齐。</para>
		/// <para>结束时间—时间步长与最后一次时间事件对齐，并向后聚合时间。</para>
		/// <para>开始时间—时间步长与第一次时间事件对齐，并向前聚合时间。</para>
		/// <para>参考时间—时间步长将与指定的特定日期/时间对齐。如果输入要素中的所有点的时间戳大于您所提供的参考时间（或时间戳刚好位于输入要素的开始时间），则时间步长间隔将以该参考时间为开始时间，并向前聚合时间（与使用开始时间对齐的效果相同）。如果输入要素中的所有点的时间戳小于您所提供的参考时间（或时间戳刚好位于输入要素的结束时间），则时间步长间隔将以该参考时间为结束时间，并向后聚合时间（与使用结束时间对齐的效果相同）。如果提供的参考时间处于数据时间范围的中间，则将以提供的参考时间结束创建时间步长间隔（与使用结束时间对齐的情况相同）；其他间隔将在参考时间前后进行创建，直到覆盖数据的完整时间范围为止。</para>
		/// <para><see cref="TimeStepAlignmentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TimeStepAlignment { get; set; } = "END_TIME";

		/// <summary>
		/// <para>Reference Time</para>
		/// <para>用于对齐时间步长间隔的日期/时间。例如，如果想要按星期从星期一至星期天对数据进行归类，可以将星期天的午夜设置为参考时间，以确保立方图格在星期天和星期一之间的午夜进行划分。（提供模板立方体时，将禁用此参数，因为参考时间将由模板立方体确定。）</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object ReferenceTime { get; set; }

		/// <summary>
		/// <para>Distance Interval</para>
		/// <para>用于聚合输入要素的立方图格尺寸。将对相同距离间隔和时间步长间隔内的所有点进行聚合。当聚合到六边形网格时，该距离用作构建六边形面的高度。（提供模板立方体时，将禁用此参数，因为距离间隔值将由模板立方体确定。）</para>
		/// <para><see cref="DistanceIntervalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object DistanceInterval { get; set; }

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
		/// <para>SPATIAL_NEIGHBORS - 用空间相邻要素平均值填充空立方图格。</para>
		/// <para>SPACE_TIME_NEIGHBORS - 用时空相邻要素平均值填充空立方图格。</para>
		/// <para>TEMPORAL_TREND - 使用一元样条插值算法填充空立方图格。</para>
		/// <para>任何汇总字段记录中出现的空值都将导致从输出立方体中排除这些要素。如果输入要素中出现空值，则强烈建议您先运行填充缺失值工具。如果在运行填充缺失值工具后，仍存在空值而每个立方图格中的点数是分析策略的一部分，您可能需要考虑创建单独的立方体，针对计数（不含汇总字段）创建一个，并针对汇总字段创建一个。如果每个汇总字段的空值集不相同，您可能还需要考虑为每个汇总字段创建一个单独的立方体。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object SummaryFields { get; set; }

		/// <summary>
		/// <para>Aggregation Shape Type</para>
		/// <para>输入要素点数据将要聚合到的面网格形状。</para>
		/// <para>渔网网格—输入要素将要聚合到方形（渔网）像元网格中。</para>
		/// <para>六边形网格—输入要素将要聚合到六边形像元网格中。</para>
		/// <para>已定义位置—输入要素将聚合到所提供的位置。</para>
		/// <para><see cref="AggregationShapeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AggregationShapeType { get; set; } = "FISHNET_GRID";

		/// <summary>
		/// <para>Defined Polygon Locations</para>
		/// <para>输入点数据将要聚合到的面要素。例如，这些数据可表示县边界、警务区或销售区域。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object DefinedPolygonLocations { get; set; }

		/// <summary>
		/// <para>Location ID</para>
		/// <para>包含每个唯一位置的 ID 编号的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object LocationId { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateSpaceTimeCube SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

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
		/// <para>Time Step Alignment</para>
		/// </summary>
		public enum TimeStepAlignmentEnum 
		{
			/// <summary>
			/// <para>结束时间—时间步长与最后一次时间事件对齐，并向后聚合时间。</para>
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

		/// <summary>
		/// <para>Distance Interval</para>
		/// </summary>
		public enum DistanceIntervalEnum 
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
		/// <para>Aggregation Shape Type</para>
		/// </summary>
		public enum AggregationShapeTypeEnum 
		{
			/// <summary>
			/// <para>渔网网格—输入要素将要聚合到方形（渔网）像元网格中。</para>
			/// </summary>
			[GPValue("FISHNET_GRID")]
			[Description("渔网网格")]
			Fishnet_grid,

			/// <summary>
			/// <para>六边形网格—输入要素将要聚合到六边形像元网格中。</para>
			/// </summary>
			[GPValue("HEXAGON_GRID")]
			[Description("六边形网格")]
			Hexagon_grid,

			/// <summary>
			/// <para>已定义位置—输入要素将聚合到所提供的位置。</para>
			/// </summary>
			[GPValue("DEFINED_LOCATIONS")]
			[Description("已定义位置")]
			Defined_locations,

		}

#endregion
	}
}
