using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsServerTools
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
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>输出要素服务的名称。</para>
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
		public DetectIncidents(object InputLayer, object OutputName, object TrackFields, object StartCondition)
		{
			this.InputLayer = InputLayer;
			this.OutputName = OutputName;
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
		/// <para>Tool Excute Name : geoanalytics.DetectIncidents</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.DetectIncidents";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoanalytics</para>
		/// </summary>
		public override string ToolboxAlise() => "geoanalytics";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputLayer, OutputName, TrackFields, StartCondition, EndCondition!, OutputMode!, DataStore!, Output!, TimeBoundarySplit!, TimeBoundaryReference! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>包含潜在事件的输入要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRecordSet()]
		[GPTablesDomain()]
		[PortalType("DataStoreCatalogLayer")]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>输出要素服务的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

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
		/// <para>Data Store</para>
		/// <para>指定将用于保存输出的 ArcGIS Data Store。 默认设置为时空大数据存储。 在时空大数据存储中存储的所有结果都将存储在 WGS84 中。 在关系数据存储中存储的结果都将保持各自的坐标系。</para>
		/// <para>时空大数据存储—输出将存储在时空大数据存储中。 这是默认设置。</para>
		/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Data Store")]
		public object? DataStore { get; set; } = "SPATIOTEMPORAL_DATA_STORE";

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object? Output { get; set; }

		/// <summary>
		/// <para>Time Boundary Split</para>
		/// <para>用于分割输入数据以进行分析的时间跨度。 您可通过时间界限分析定义的时间跨度内的值。 例如，如果您使用始于 1980 年 1 月 1 日的 1 天的时间界限，则轨迹将在每天开始时被分割。 此参数仅适用于 ArcGIS Enterprise 10.7 及更高版本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TimeBoundarySplit { get; set; }

		/// <summary>
		/// <para>Time Boundary Reference</para>
		/// <para>用于分割输入数据以进行分析的参考时间。 将为整个数据跨度创建时间界限，且不需要在开始时产生参考时间。 如果未指定参考时间，则将使用 1970 年 1 月 1 日。 此参数仅适用于 ArcGIS Enterprise 10.7 及更高版本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? TimeBoundaryReference { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DetectIncidents SetEnviroment(object? extent = null, object? outputCoordinateSystem = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
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

		/// <summary>
		/// <para>Data Store</para>
		/// </summary>
		public enum DataStoreEnum 
		{
			/// <summary>
			/// <para>时空大数据存储—输出将存储在时空大数据存储中。 这是默认设置。</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("时空大数据存储")]
			Spatiotemporal_big_data_store,

			/// <summary>
			/// <para>关系数据存储—输出将存储在关系数据存储中。</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("关系数据存储")]
			Relational_data_store,

		}

#endregion
	}
}
