using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsDesktopTools
{
	/// <summary>
	/// <para>Reconstruct Tracks</para>
	/// <para>重新构建轨迹</para>
	/// <para>从启用时间的输入数据创建线或面轨迹。</para>
	/// </summary>
	public class ReconstructTracks : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>要重新构建为轨迹的点或面。输入必须为启用时间的图层，用于表示时刻。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>包含所生成轨迹的新要素类。</para>
		/// </param>
		/// <param name="TrackFields">
		/// <para>Track Fields</para>
		/// <para>将用于标识唯一轨迹的一个或多个字段。</para>
		/// </param>
		/// <param name="Method">
		/// <para>Method</para>
		/// <para>指定将用于重新构建轨迹的条件。如果使用了缓冲区，则方法参数将用于确定缓冲区的类型。</para>
		/// <para>测地线— 如果空间参考可以平移，则轨迹将在适当的时候穿过日期变更线。如果空间参考不可平移，则轨迹将被限制在坐标系的范围之内且不可环绕。</para>
		/// <para>平面—将创建平面缓冲区。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </param>
		public ReconstructTracks(object InputLayer, object OutFeatureClass, object TrackFields, object Method)
		{
			this.InputLayer = InputLayer;
			this.OutFeatureClass = OutFeatureClass;
			this.TrackFields = TrackFields;
			this.Method = Method;
		}

		/// <summary>
		/// <para>Tool Display Name : 重新构建轨迹</para>
		/// </summary>
		public override string DisplayName() => "重新构建轨迹";

		/// <summary>
		/// <para>Tool Name : ReconstructTracks</para>
		/// </summary>
		public override string ToolName() => "ReconstructTracks";

		/// <summary>
		/// <para>Tool Excute Name : gapro.ReconstructTracks</para>
		/// </summary>
		public override string ExcuteName() => "gapro.ReconstructTracks";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise() => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputLayer, OutFeatureClass, TrackFields, Method, BufferType!, BufferField!, BufferExpression!, TimeSplit!, DistanceSplit!, TimeBoundarySplit!, TimeBoundaryReference!, SummaryFields!, SplitExpression!, SplitType! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>要重新构建为轨迹的点或面。输入必须为启用时间的图层，用于表示时刻。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含所生成轨迹的新要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Track Fields</para>
		/// <para>将用于标识唯一轨迹的一个或多个字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object TrackFields { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>指定将用于重新构建轨迹的条件。如果使用了缓冲区，则方法参数将用于确定缓冲区的类型。</para>
		/// <para>测地线— 如果空间参考可以平移，则轨迹将在适当的时候穿过日期变更线。如果空间参考不可平移，则轨迹将被限制在坐标系的范围之内且不可环绕。</para>
		/// <para>平面—将创建平面缓冲区。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "GEODESIC";

		/// <summary>
		/// <para>Buffer Type</para>
		/// <para>指定缓冲距离将如何定义。</para>
		/// <para>字段—将使用单个字段来定义缓冲距离。</para>
		/// <para>表达式—使用字段和数学运算符的方程将用于定义缓冲距离。</para>
		/// <para><see cref="BufferTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? BufferType { get; set; }

		/// <summary>
		/// <para>Buffer Field</para>
		/// <para>将用于缓冲输入要素的字段。字段值采用输入空间参考的单位，除非您所使用的是地理坐标系，在这种情况下，单位将为米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object? BufferField { get; set; }

		/// <summary>
		/// <para>Buffer Expression</para>
		/// <para>将用于缓冲输入要素的表达式。字段必须为数字形式，并且表达式可以包含 [+ - * / ] 运算符和多个字段。将应用经计算的值，且采用输入空间参考的单位，除非您所使用的是地理坐标系，在这种情况下，单位为米。</para>
		/// <para>请使用 Arcade 表达式，例如 as_kilometers($feature.distance) * 2 + as_meters(15)。</para>
		/// <para>如果将图层添加到地图中，则可以使用字段和助手过滤器来构建表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCalculatorExpression()]
		public object? BufferExpression { get; set; }

		/// <summary>
		/// <para>Time Split</para>
		/// <para>时间差距大于按时间分割的持续时间的要素将被分割成单独的轨迹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		[Category("Track Split Options")]
		public object? TimeSplit { get; set; }

		/// <summary>
		/// <para>Distance Split</para>
		/// <para>距离差距大于距离分割值的要素将被分割成单独的轨迹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		[Category("Track Split Options")]
		public object? DistanceSplit { get; set; }

		/// <summary>
		/// <para>Time Boundary Split</para>
		/// <para>用于分割输入数据以进行分析的时间跨度。 您可通过时间界限分析定义的时间跨度内的值。 例如，如果您使用 1 天的时间界限，并将时间界限参考设置为 1980 年 1 月 1 日，则轨迹将在每天开始时被分割。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		[Category("Track Split Options")]
		public object? TimeBoundarySplit { get; set; }

		/// <summary>
		/// <para>Time Boundary Reference</para>
		/// <para>用于分割输入数据以进行分析的参考时间。 将为整个数据跨度创建时间界限，且不需要在开始时产生参考时间。 如果未指定参考时间，则将使用 1970 年 1 月 1 日。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Track Split Options")]
		public object? TimeBoundaryReference { get; set; }

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>将根据指定字段进行计算的统计数据。</para>
		/// <para>计数 - 非空值的数目。 可用于数值字段或字符串。 [null, 0, 2] 的计数为 2。</para>
		/// <para>总和 - 字段内数值的总和。 [null, null, 3] 的总和为 3。</para>
		/// <para>平均值 - 数值的平均值。 [0, 2, null] 的平均值为 1。</para>
		/// <para>最小值 - 数值字段的最小值。 [0, 2, null] 的最小值为 0。</para>
		/// <para>最大值 - 数值字段的最大值。 [0, 2, null] 的最大值为 2。</para>
		/// <para>标准差 - 数值字段的标准差。 [1] 的标准差为 null。 [null, 1,1,1] 的标准差为 null。</para>
		/// <para>方差 - 轨迹中数值字段内数值的方差。 [1] 的方差为 null。 [null, 1, 1, 1] 的方差为 null。</para>
		/// <para>范围 - 数值字段的范围。 其计算方法为最大值减去最小值。 [0, null, 1] 的范围为 1。 [null, 4] 的范围为 0。</para>
		/// <para>任何 - 字符串型字段中的示例字符串。</para>
		/// <para>第一个 - 轨迹中指定字段的第一个值。</para>
		/// <para>最后一个 - 轨迹中指定字段的最后一个值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? SummaryFields { get; set; }

		/// <summary>
		/// <para>Split Expression</para>
		/// <para>可根据值、几何或时间值来分割轨迹的表达式。 将对验证为 true 的表达式进行分割。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCalculatorExpression()]
		[Category("Track Split Options")]
		public object? SplitExpression { get; set; }

		/// <summary>
		/// <para>Split Type</para>
		/// <para>指定在分割轨迹时，在两个要素之间创建轨迹段的方式。分割类型将应用于分割表达式、距离分割和时间分割。</para>
		/// <para>间距—在两个要素之间未创建任何段。这是默认设置。</para>
		/// <para>之后完成—将在两个要素之间创建一个段，该段在分割后结束。</para>
		/// <para>之前开始—将在两个要素之间创建一个段，该段在分割前结束。</para>
		/// <para><see cref="SplitTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Track Split Options")]
		public object? SplitType { get; set; } = "GAP";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ReconstructTracks SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>测地线— 如果空间参考可以平移，则轨迹将在适当的时候穿过日期变更线。如果空间参考不可平移，则轨迹将被限制在坐标系的范围之内且不可环绕。</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("测地线")]
			Geodesic,

			/// <summary>
			/// <para>平面—将创建平面缓冲区。</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("平面")]
			Planar,

		}

		/// <summary>
		/// <para>Buffer Type</para>
		/// </summary>
		public enum BufferTypeEnum 
		{
			/// <summary>
			/// <para>字段—将使用单个字段来定义缓冲距离。</para>
			/// </summary>
			[GPValue("FIELD")]
			[Description("字段")]
			Field,

			/// <summary>
			/// <para>表达式—使用字段和数学运算符的方程将用于定义缓冲距离。</para>
			/// </summary>
			[GPValue("EXPRESSION")]
			[Description("表达式")]
			Expression,

		}

		/// <summary>
		/// <para>Split Type</para>
		/// </summary>
		public enum SplitTypeEnum 
		{
			/// <summary>
			/// <para>间距—在两个要素之间未创建任何段。这是默认设置。</para>
			/// </summary>
			[GPValue("GAP")]
			[Description("间距")]
			Gap,

			/// <summary>
			/// <para>之后完成—将在两个要素之间创建一个段，该段在分割后结束。</para>
			/// </summary>
			[GPValue("FINISH_LAST")]
			[Description("之后完成")]
			Finish_After,

			/// <summary>
			/// <para>之前开始—将在两个要素之间创建一个段，该段在分割前结束。</para>
			/// </summary>
			[GPValue("START_NEXT")]
			[Description("之前开始")]
			Start_Before,

		}

#endregion
	}
}
