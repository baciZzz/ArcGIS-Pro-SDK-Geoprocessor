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
	/// <para>Calculate Field</para>
	/// <para>计算字段</para>
	/// <para>可使用计算的字段值创建图层。</para>
	/// </summary>
	public class CalculateField : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>将计算字段的输入要素。</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>输出要素服务的名称。</para>
		/// </param>
		/// <param name="FieldName">
		/// <para>Field Name</para>
		/// <para>将具有计算值的字段的名称。 可以为现有字段名称或新字段名称。</para>
		/// </param>
		/// <param name="FieldType">
		/// <para>Field Type</para>
		/// <para>指定已计算字段的字段类型。</para>
		/// <para>字符串—任何字符串</para>
		/// <para>整型—整数</para>
		/// <para>双精度—小数</para>
		/// <para>日期—日期</para>
		/// <para><see cref="FieldTypeEnum"/></para>
		/// </param>
		/// <param name="Expression">
		/// <para>Expression</para>
		/// <para>计算字段中的值。 以 Arcade 格式写入表达式，其中可包括 [+ - * / ] 运算符和多个字段。 将应用经计算的值，且采用输入空间参考的单位，除非您所使用的是地理坐标系，在这种情况下，单位为米。</para>
		/// <para>如果将图层添加到地图中，则可以使用字段和助手过滤器来构建表达式。</para>
		/// </param>
		public CalculateField(object InputLayer, object OutputName, object FieldName, object FieldType, object Expression)
		{
			this.InputLayer = InputLayer;
			this.OutputName = OutputName;
			this.FieldName = FieldName;
			this.FieldType = FieldType;
			this.Expression = Expression;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算字段</para>
		/// </summary>
		public override string DisplayName() => "计算字段";

		/// <summary>
		/// <para>Tool Name : CalculateField</para>
		/// </summary>
		public override string ToolName() => "CalculateField";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.CalculateField</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.CalculateField";

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
		public override object[] Parameters() => new object[] { InputLayer, OutputName, FieldName, FieldType, Expression, TrackAware!, TrackFields!, DataStore!, OutputTable!, TimeBoundarySplit!, TimeBoundaryReference! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>将计算字段的输入要素。</para>
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
		/// <para>Field Name</para>
		/// <para>将具有计算值的字段的名称。 可以为现有字段名称或新字段名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object FieldName { get; set; }

		/// <summary>
		/// <para>Field Type</para>
		/// <para>指定已计算字段的字段类型。</para>
		/// <para>字符串—任何字符串</para>
		/// <para>整型—整数</para>
		/// <para>双精度—小数</para>
		/// <para>日期—日期</para>
		/// <para><see cref="FieldTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FieldType { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>计算字段中的值。 以 Arcade 格式写入表达式，其中可包括 [+ - * / ] 运算符和多个字段。 将应用经计算的值，且采用输入空间参考的单位，除非您所使用的是地理坐标系，在这种情况下，单位为米。</para>
		/// <para>如果将图层添加到地图中，则可以使用字段和助手过滤器来构建表达式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPCalculatorExpression()]
		public object Expression { get; set; }

		/// <summary>
		/// <para>Track Aware</para>
		/// <para>指定表达式是否会使用追踪感知型表达式。</para>
		/// <para>选中 - 表达式将使用追踪感知型表达式，且必须指定追踪字段。</para>
		/// <para>未选中 - 表达式不会使用追踪感知型表达式。 这是默认设置。</para>
		/// <para><see cref="TrackAwareEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? TrackAware { get; set; }

		/// <summary>
		/// <para>Track Fields</para>
		/// <para>将用于标识唯一轨迹的一个或多个字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object? TrackFields { get; set; }

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
		/// <para>Output Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object? OutputTable { get; set; }

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
		public CalculateField SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Field Type</para>
		/// </summary>
		public enum FieldTypeEnum 
		{
			/// <summary>
			/// <para>日期—日期</para>
			/// </summary>
			[GPValue("DATE")]
			[Description("日期")]
			Date,

			/// <summary>
			/// <para>双精度—小数</para>
			/// </summary>
			[GPValue("DOUBLE")]
			[Description("双精度")]
			Double,

			/// <summary>
			/// <para>整型—整数</para>
			/// </summary>
			[GPValue("INTEGER")]
			[Description("整型")]
			Integer,

			/// <summary>
			/// <para>字符串—任何字符串</para>
			/// </summary>
			[GPValue("STRING")]
			[Description("字符串")]
			String,

		}

		/// <summary>
		/// <para>Track Aware</para>
		/// </summary>
		public enum TrackAwareEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("TRACK_AWARE")]
			TRACK_AWARE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_TRACK_AWARE")]
			NOT_TRACK_AWARE,

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
