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
	/// <para>Time Series Smoothing</para>
	/// <para>时间序列平滑</para>
	/// <para>使用居中、前移和后移平均值以及基于局部线性回归的自适应方法对一个或多个时间序列的数字变量进行平滑处理。 对短期波动进行平滑处理后，较长期的趋势或周期通常会变得明显。</para>
	/// </summary>
	public class TimeSeriesSmoothing : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features or Table</para>
		/// <para>包含时间序列数据和要平滑的字段的要素或表。</para>
		/// </param>
		/// <param name="TimeField">
		/// <para>Time Field</para>
		/// <para>包含每条记录的时间的字段。</para>
		/// </param>
		/// <param name="AnalysisField">
		/// <para>Analysis Field</para>
		/// <para>包含要平滑的值的字段。</para>
		/// </param>
		public TimeSeriesSmoothing(object InFeatures, object TimeField, object AnalysisField)
		{
			this.InFeatures = InFeatures;
			this.TimeField = TimeField;
			this.AnalysisField = AnalysisField;
		}

		/// <summary>
		/// <para>Tool Display Name : 时间序列平滑</para>
		/// </summary>
		public override string DisplayName() => "时间序列平滑";

		/// <summary>
		/// <para>Tool Name : TimeSeriesSmoothing</para>
		/// </summary>
		public override string ToolName() => "TimeSeriesSmoothing";

		/// <summary>
		/// <para>Tool Excute Name : stats.TimeSeriesSmoothing</para>
		/// </summary>
		public override string ExcuteName() => "stats.TimeSeriesSmoothing";

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
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, TimeField, AnalysisField, GroupMethod, Method, TimeWindow, AppendToInput, OutputFeatures, IdField, ApplyShorterWindow, EnableTimeSeriesPopups, UpdatedFeatures };

		/// <summary>
		/// <para>Input Features or Table</para>
		/// <para>包含时间序列数据和要平滑的字段的要素或表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Time Field</para>
		/// <para>包含每条记录的时间的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Date")]
		public object TimeField { get; set; }

		/// <summary>
		/// <para>Analysis Field</para>
		/// <para>包含要平滑的值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object AnalysisField { get; set; }

		/// <summary>
		/// <para>Grouping Method</para>
		/// <para>指定用于将记录分组至不同时间序列的方法。 每个时间序列都会单独进行平滑处理。</para>
		/// <para>按位置—同一位置的要素将被分组到同一时间序列。 这是默认设置。</para>
		/// <para>按 ID 字段—ID 字段值相同的记录将被分组到同一时间序列。</para>
		/// <para>无—所有记录都将位于相同的时间序列中。</para>
		/// <para><see cref="GroupMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GroupMethod { get; set; } = "LOCATION";

		/// <summary>
		/// <para>Smoothing Method</para>
		/// <para>指定将要使用的平滑方法。</para>
		/// <para>后移平均值—平滑值是在时间窗范围内记录及其之前的值的平均值。 这是默认设置。</para>
		/// <para>居中移动平均值—平滑值是记录及其之前和之后的值的平均值。 时间窗的一半用于记录的时间之前，另一半用于之后。</para>
		/// <para>前移平均值—平滑值是在时间窗范围内记录及其之后的值的平均值。</para>
		/// <para>自适应带宽局部线性回归—平滑值是以记录为中心的局部线性回归的结果。 时间窗的大小将针对每条记录进行优化。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "BACKWARD";

		/// <summary>
		/// <para>Time Window</para>
		/// <para>时间窗的长度。 可以以秒、分钟、小时、天、周、月或年为单位提供该值。 对于后移、前移和居中移动平均值，必须提供值和单位。 对于自适应带宽局部线性回归，值可以留空，将会为每个值单独估计时间窗。 处于时间窗边界上的值将包含在时间窗内。 例如，如果您具有每日数据并使用时间窗为四天的后移平均值，则在平滑记录时，时间窗内将包含五个值：记录的值和前四天的值。</para>
		/// <para><see cref="TimeWindowEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		public object TimeWindow { get; set; }

		/// <summary>
		/// <para>Append fields to input data</para>
		/// <para>指定是将输出字段追加到输入数据集还是将其另存为新的输出表或要素类。 如果您选择将字段追加到输入，则会忽略输出坐标系环境。</para>
		/// <para>选中 - 输出字段将被追加到输入要素。 此选项会修改输入数据。</para>
		/// <para>未选中 - 输出字段将不会追加到输入。 将创建包含输出字段的输出表或要素类。 这是默认设置。</para>
		/// <para><see cref="AppendToInputEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AppendToInput { get; set; } = "false";

		/// <summary>
		/// <para>Output Features</para>
		/// <para>包含平滑值和时间窗的字段以及相邻要素数目的输出要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>ID Field</para>
		/// <para>包含每个时间序列的唯一 ID 的整数或文本字段。 所有此字段值相同的记录都是同一时间序列的一部分。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object IdField { get; set; }

		/// <summary>
		/// <para>Apply shorter time window at start and end</para>
		/// <para>指定是否在每个时间序列的开始和结束位置缩短时间窗。</para>
		/// <para>选中 - 将在时间序列的开始和结束位置缩短时间窗，从而使时间窗不会在时间序列开始前或结束后延伸。</para>
		/// <para>未选中 - 时间窗不会缩短。 如果时间窗在时间序列开始前或结束后延伸，平滑值将为空。 这是默认设置。</para>
		/// <para><see cref="ApplyShorterWindowEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ApplyShorterWindow { get; set; } = "false";

		/// <summary>
		/// <para>Enable time series pop-ups</para>
		/// <para>指定输出要素或表是否包括弹出图表，以显示时间序列的原始和平滑值。</para>
		/// <para>选中 - 输出将包括弹出图表。 这是默认设置。</para>
		/// <para>未选中 - 输出将不包括弹出图表。</para>
		/// <para><see cref="EnableTimeSeriesPopupsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object EnableTimeSeriesPopups { get; set; } = "true";

		/// <summary>
		/// <para>Updated Features or Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object UpdatedFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TimeSeriesSmoothing SetEnviroment(object outputCoordinateSystem = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Grouping Method</para>
		/// </summary>
		public enum GroupMethodEnum 
		{
			/// <summary>
			/// <para>按位置—同一位置的要素将被分组到同一时间序列。 这是默认设置。</para>
			/// </summary>
			[GPValue("LOCATION")]
			[Description("按位置")]
			By_location,

			/// <summary>
			/// <para>按 ID 字段—ID 字段值相同的记录将被分组到同一时间序列。</para>
			/// </summary>
			[GPValue("ID_FIELD")]
			[Description("按 ID 字段")]
			By_ID_field,

			/// <summary>
			/// <para>无—所有记录都将位于相同的时间序列中。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

		}

		/// <summary>
		/// <para>Smoothing Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>后移平均值—平滑值是在时间窗范围内记录及其之前的值的平均值。 这是默认设置。</para>
			/// </summary>
			[GPValue("BACKWARD")]
			[Description("后移平均值")]
			Backward_moving_average,

			/// <summary>
			/// <para>居中移动平均值—平滑值是记录及其之前和之后的值的平均值。 时间窗的一半用于记录的时间之前，另一半用于之后。</para>
			/// </summary>
			[GPValue("CENTERED")]
			[Description("居中移动平均值")]
			Centered_moving_average,

			/// <summary>
			/// <para>前移平均值—平滑值是在时间窗范围内记录及其之后的值的平均值。</para>
			/// </summary>
			[GPValue("FORWARD")]
			[Description("前移平均值")]
			Forward_moving_average,

			/// <summary>
			/// <para>自适应带宽局部线性回归—平滑值是以记录为中心的局部线性回归的结果。 时间窗的大小将针对每条记录进行优化。</para>
			/// </summary>
			[GPValue("ADAPTIVE")]
			[Description("自适应带宽局部线性回归")]
			Adaptive_bandwidth_local_linear_regression,

		}

		/// <summary>
		/// <para>Time Window</para>
		/// </summary>
		public enum TimeWindowEnum 
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
		/// <para>Append fields to input data</para>
		/// </summary>
		public enum AppendToInputEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("APPEND_TO_INPUT")]
			APPEND_TO_INPUT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NEW_OUTPUT")]
			NEW_OUTPUT,

		}

		/// <summary>
		/// <para>Apply shorter time window at start and end</para>
		/// </summary>
		public enum ApplyShorterWindowEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("APPLY_SHORTER_WINDOW")]
			APPLY_SHORTER_WINDOW,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_APPLY_SHORTER_WINDOW")]
			NOT_APPLY_SHORTER_WINDOW,

		}

		/// <summary>
		/// <para>Enable time series pop-ups</para>
		/// </summary>
		public enum EnableTimeSeriesPopupsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_POPUP")]
			CREATE_POPUP,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_POPUP")]
			NO_POPUP,

		}

#endregion
	}
}
