using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkAnalystTools
{
	/// <summary>
	/// <para>Make OD Cost Matrix Analysis Layer</para>
	/// <para>创建 OD 成本矩阵分析图层</para>
	/// <para>创建起始-目的地 (OD) 成本矩阵网络分析图层并设置其分析属性。 OD 成本矩阵分析图层对于描述从一组起始位置到一组目的地位置的成本矩阵十分有用。 该图层可通过本地网络数据集进行创建，也可通过在线托管服务或门户托管服务进行创建。</para>
	/// </summary>
	public class MakeODCostMatrixAnalysisLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="NetworkDataSource">
		/// <para>Network Data Source</para>
		/// <para>将对其执行网络分析的网络数据集或服务。 将门户 URL 用于服务。</para>
		/// </param>
		public MakeODCostMatrixAnalysisLayer(object NetworkDataSource)
		{
			this.NetworkDataSource = NetworkDataSource;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建 OD 成本矩阵分析图层</para>
		/// </summary>
		public override string DisplayName() => "创建 OD 成本矩阵分析图层";

		/// <summary>
		/// <para>Tool Name : MakeODCostMatrixAnalysisLayer</para>
		/// </summary>
		public override string ToolName() => "MakeODCostMatrixAnalysisLayer";

		/// <summary>
		/// <para>Tool Excute Name : na.MakeODCostMatrixAnalysisLayer</para>
		/// </summary>
		public override string ExcuteName() => "na.MakeODCostMatrixAnalysisLayer";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise() => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { NetworkDataSource, LayerName!, TravelMode!, Cutoff!, NumberOfDestinationsToFind!, TimeOfDay!, TimeZone!, LineShape!, AccumulateAttributes!, OutNetworkAnalysisLayer!, IgnoreInvalidLocations! };

		/// <summary>
		/// <para>Network Data Source</para>
		/// <para>将对其执行网络分析的网络数据集或服务。 将门户 URL 用于服务。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object NetworkDataSource { get; set; }

		/// <summary>
		/// <para>Layer Name</para>
		/// <para>要创建的网络分析图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? LayerName { get; set; }

		/// <summary>
		/// <para>Travel Mode</para>
		/// <para>分析中使用的出行模式名称。 出行模式为一组网络设置（例如行驶限制和 U 形转弯），用于确定行人、车辆、卡车或其他交通媒介在网络中的移动方式。 出行模式在网络数据源中进行定义。</para>
		/// <para>arcpy.na.TravelMode 对象和包含出行模式有效 JSON 表示的字符串也可用作参数的输入。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TravelMode { get; set; }

		/// <summary>
		/// <para>Cutoff</para>
		/// <para>停止为指定起始点搜索目的地时所对应的阻抗值。 该值将以所选出行模式使用的阻抗属性为单位。 无法找到超过此限制的目的地。 可通过在起始点子图层中指定单个中断值来逐个起始点覆盖中断值。 默认情况下分析不使用中断。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? Cutoff { get; set; }

		/// <summary>
		/// <para>Number of Destinations to Find</para>
		/// <para>要为每个起始点查找的目的地数。 可通过为起始点子图层的 TargetDestinationCount 属性指定一个值来覆盖此默认值。 默认情况下无任何限制，可找到所有目的地。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumberOfDestinationsToFind { get; set; }

		/// <summary>
		/// <para>Time of Day</para>
		/// <para>从起始点出发的时间。</para>
		/// <para>如果您已经选择了基于流量的阻抗属性，将会根据特定的某天某时的动态交通状况来生成解决方案。 日期和时间可被指定为 5/14/2012 10:30 AM。</para>
		/// <para>可使用以下日期来指定一周中的每一天，而无需使用特定的日期：</para>
		/// <para>今天 - 12/30/1899</para>
		/// <para>星期日 - 12/31/1899</para>
		/// <para>星期一 - 1/1/1900</para>
		/// <para>星期二 - 1/2/1900</para>
		/// <para>星期三 - 1/3/1900</para>
		/// <para>星期四 - 1/4/1900</para>
		/// <para>星期五 - 1/5/1900</para>
		/// <para>星期六 - 1/6/1900</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Time of Day")]
		public object? TimeOfDay { get; set; }

		/// <summary>
		/// <para>Time Zone</para>
		/// <para>时间参数的时区。</para>
		/// <para>各位置的本地时间—时间参数是指起始点所处的时区。 这是默认设置。</para>
		/// <para>UTC—时间参数是指协调世界时间 (UTC)。 如果您想要在指定时间内（如现在）计算 OD 成本矩阵，但不确定起始点所在的时区，请选择此选项。</para>
		/// <para><see cref="TimeZoneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Time of Day")]
		public object? TimeZone { get; set; } = "LOCAL_TIME_AT_LOCATIONS";

		/// <summary>
		/// <para>Line Shape</para>
		/// <para>指定输出线形状。</para>
		/// <para>无线—将不会为输出起始点-目的地路径对生成任何形状。 适用于存在大量起始点和目的地，但仅对 OD 成本矩阵表中的阻抗成本（而不是查看地图中的 OD 成本矩阵）感兴趣的情况。</para>
		/// <para>直线—输出路径形状是介于各个起始点-目的地对之间的直线（单线）。 这是默认设置。</para>
		/// <para>无论选择何种输出 shape 类型，最佳路径始终由网络阻抗（而非欧氏距离）决定。 这表示只是路径形状不同，而对网络进行的基础遍历则相同。</para>
		/// <para><see cref="LineShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Output Geometry")]
		public object? LineShape { get; set; } = "STRAIGHT_LINES";

		/// <summary>
		/// <para>Accumulate Attributes</para>
		/// <para>分析过程中要累积的成本属性的列表。 这些累积属性仅供参考；求解程序仅使用求解分析时指定的出行模式所使用的成本属性。</para>
		/// <para>对于每个累积的成本属性，会在网络分析输出要素中填充 Total_[阻抗] 属性。</para>
		/// <para>如果网络数据源为 ArcGIS Online 服务，或如果网络数据源是不支持累积的 Portal for ArcGIS 版本上的服务，则此参数不可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		[Category("Accumulate Attributes")]
		public object? AccumulateAttributes { get; set; }

		/// <summary>
		/// <para>Network Analyst Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object? OutNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Ignore Invalid Locations at Solve Time</para>
		/// <para>指定是否忽略无效的输入位置。 通常，如果无法在网络上定位，则位置无效。 当无效位置被忽略时，求解器将跳过它们并尝试使用剩余位置执行分析。</para>
		/// <para>选中 - 将忽略无效的输入位置，并且仅使用有效的位置。 这是默认设置。</para>
		/// <para>未选中 - 将使用所有输入位置。 无效的位置将导致分析失败。</para>
		/// <para><see cref="IgnoreInvalidLocationsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Locations")]
		public object? IgnoreInvalidLocations { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeODCostMatrixAnalysisLayer SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Time Zone</para>
		/// </summary>
		public enum TimeZoneEnum 
		{
			/// <summary>
			/// <para>UTC—时间参数是指协调世界时间 (UTC)。 如果您想要在指定时间内（如现在）计算 OD 成本矩阵，但不确定起始点所在的时区，请选择此选项。</para>
			/// </summary>
			[GPValue("UTC")]
			[Description("UTC")]
			UTC,

			/// <summary>
			/// <para>各位置的本地时间—时间参数是指起始点所处的时区。 这是默认设置。</para>
			/// </summary>
			[GPValue("LOCAL_TIME_AT_LOCATIONS")]
			[Description("各位置的本地时间")]
			Local_time_at_locations,

		}

		/// <summary>
		/// <para>Line Shape</para>
		/// </summary>
		public enum LineShapeEnum 
		{
			/// <summary>
			/// <para>无线—将不会为输出起始点-目的地路径对生成任何形状。 适用于存在大量起始点和目的地，但仅对 OD 成本矩阵表中的阻抗成本（而不是查看地图中的 OD 成本矩阵）感兴趣的情况。</para>
			/// </summary>
			[GPValue("NO_LINES")]
			[Description("无线")]
			No_lines,

			/// <summary>
			/// <para>直线—输出路径形状是介于各个起始点-目的地对之间的直线（单线）。 这是默认设置。</para>
			/// </summary>
			[GPValue("STRAIGHT_LINES")]
			[Description("直线")]
			Straight_lines,

		}

		/// <summary>
		/// <para>Ignore Invalid Locations at Solve Time</para>
		/// </summary>
		public enum IgnoreInvalidLocationsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SKIP")]
			SKIP,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("HALT")]
			HALT,

		}

#endregion
	}
}
