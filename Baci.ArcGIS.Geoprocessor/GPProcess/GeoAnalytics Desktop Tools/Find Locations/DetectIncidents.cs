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
	/// <para>Detect Incidents</para>
	/// <para>检测事件</para>
	/// <para>创建用于检测满足给定条件的要素的图层。</para>
	/// </summary>
	public class DetectIncidents : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>包含潜在事件的输入要素。</para>
		/// </param>
		/// <param name="Output">
		/// <para>Output Dataset</para>
		/// <para>包含事件的新输出数据集。</para>
		/// </param>
		/// <param name="TrackFields">
		/// <para>Track Fields</para>
		/// <para>将用于标识唯一轨迹的一个或多个字段。</para>
		/// </param>
		/// <param name="StartCondition">
		/// <para>Start Condition</para>
		/// <para>将用于标识事件的条件。以 Arcade 格式写入表达式，其中可包括 [+ - * / ] 运算符和多个字段。</para>
		/// <para>如果将图层添加到地图中，则可以使用字段和助手过滤器来构建表达式。</para>
		/// </param>
		public DetectIncidents(object InputLayer, object Output, object TrackFields, object StartCondition)
		{
			this.InputLayer = InputLayer;
			this.Output = Output;
			this.TrackFields = TrackFields;
			this.StartCondition = StartCondition;
		}

		/// <summary>
		/// <para>Tool Display Name : 检测事件</para>
		/// </summary>
		public override string DisplayName() => "检测事件";

		/// <summary>
		/// <para>Tool Name : DetectIncidents</para>
		/// </summary>
		public override string ToolName() => "DetectIncidents";

		/// <summary>
		/// <para>Tool Excute Name : gapro.DetectIncidents</para>
		/// </summary>
		public override string ExcuteName() => "gapro.DetectIncidents";

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
		public override object[] Parameters() => new object[] { InputLayer, Output, TrackFields, StartCondition, EndCondition!, OutputMode!, TimeBoundarySplit!, TimeBoundaryReference! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>包含潜在事件的输入要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// <para>包含事件的新输出数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object Output { get; set; }

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
		/// <para>Start Condition</para>
		/// <para>将用于标识事件的条件。以 Arcade 格式写入表达式，其中可包括 [+ - * / ] 运算符和多个字段。</para>
		/// <para>如果将图层添加到地图中，则可以使用字段和助手过滤器来构建表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCalculatorExpression()]
		public object StartCondition { get; set; }

		/// <summary>
		/// <para>End Condition</para>
		/// <para>将用于结束事件的条件。如果未指定结束条件，则开始条件不再为 true 时，事件将结束。</para>
		/// <para>以 Arcade 格式写入表达式，其中可包括运算符和多个字段。</para>
		/// <para>如果将图层添加到地图中，则可以使用字段和助手过滤器来构建表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCalculatorExpression()]
		public object? EndCondition { get; set; }

		/// <summary>
		/// <para>Output Mode</para>
		/// <para>用于指定将返回的要素。</para>
		/// <para>所有要素—将返回所有输入要素。这是默认设置。</para>
		/// <para>事件点—仅将返回被发现是事件的要素。</para>
		/// <para><see cref="OutputModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OutputMode { get; set; } = "ALL_FEATURES";

		/// <summary>
		/// <para>Time Boundary Split</para>
		/// <para>用于分割输入数据以进行分析的时间跨度。 您可通过时间界限分析定义的时间跨度内的值。 例如，如果您使用 1 天的时间界限，并将时间界限参考设置为 1980 年 1 月 1 日，则轨迹将在每天开始时被分割。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TimeBoundarySplit { get; set; }

		/// <summary>
		/// <para>Time Boundary Reference</para>
		/// <para>用于分割输入数据以进行分析的参考时间。 将为整个数据跨度创建时间界限，且不需要在开始时产生参考时间。 如果未指定参考时间，则将使用 1970 年 1 月 1 日。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? TimeBoundaryReference { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DetectIncidents SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Mode</para>
		/// </summary>
		public enum OutputModeEnum 
		{
			/// <summary>
			/// <para>所有要素—将返回所有输入要素。这是默认设置。</para>
			/// </summary>
			[GPValue("ALL_FEATURES")]
			[Description("所有要素")]
			All_features,

			/// <summary>
			/// <para>事件点—仅将返回被发现是事件的要素。</para>
			/// </summary>
			[GPValue("INCIDENTS")]
			[Description("事件点")]
			Incidents,

		}

#endregion
	}
}
