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
	/// <para>Summarize Center And Dispersion</para>
	/// <para>汇总中心和离差</para>
	/// <para>用于查找中心要素和方向分布，并根据输入计算平均和中位数位置。</para>
	/// </summary>
	public class SummarizeCenterAndDispersion : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>要进行汇总的点、线或面图层。</para>
		/// </param>
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>输出要素服务的名称。</para>
		/// </param>
		/// <param name="GenerateTypes">
		/// <para>Generate Types</para>
		/// <para>指定要生成的汇总类型。 您可以使用一个或多个汇总类型。 将为每种所选汇总类型创建一个唯一图层。</para>
		/// <para>中心要素—将创建一个图层，其中包含输入图层中最中心要素的副本。</para>
		/// <para>平均中心—将创建一个表示输入图层平均中心的点图层。</para>
		/// <para>中位数中心—将创建一个表示输入图层中位数中心的点图层。</para>
		/// <para>椭圆—将创建一个表示输入图层方向椭圆的面图层。</para>
		/// <para><see cref="GenerateTypesEnum"/></para>
		/// </param>
		public SummarizeCenterAndDispersion(object InputLayer, object OutputName, object GenerateTypes)
		{
			this.InputLayer = InputLayer;
			this.OutputName = OutputName;
			this.GenerateTypes = GenerateTypes;
		}

		/// <summary>
		/// <para>Tool Display Name : 汇总中心和离差</para>
		/// </summary>
		public override string DisplayName() => "汇总中心和离差";

		/// <summary>
		/// <para>Tool Name : SummarizeCenterAndDispersion</para>
		/// </summary>
		public override string ToolName() => "SummarizeCenterAndDispersion";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.SummarizeCenterAndDispersion</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.SummarizeCenterAndDispersion";

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
		public override object[] Parameters() => new object[] { InputLayer, OutputName, GenerateTypes, EllipseSize!, WeightField!, GroupByField!, OutCentralFeatureLayer!, OutMeanCenterLayer!, OutMedianCenterLayer!, OutEllipseLayer!, DataStore! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>要进行汇总的点、线或面图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple")]
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
		/// <para>Generate Types</para>
		/// <para>指定要生成的汇总类型。 您可以使用一个或多个汇总类型。 将为每种所选汇总类型创建一个唯一图层。</para>
		/// <para>中心要素—将创建一个图层，其中包含输入图层中最中心要素的副本。</para>
		/// <para>平均中心—将创建一个表示输入图层平均中心的点图层。</para>
		/// <para>中位数中心—将创建一个表示输入图层中位数中心的点图层。</para>
		/// <para>椭圆—将创建一个表示输入图层方向椭圆的面图层。</para>
		/// <para><see cref="GenerateTypesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object GenerateTypes { get; set; }

		/// <summary>
		/// <para>Ellipse Size</para>
		/// <para>指定标准差中输出椭圆的大小。</para>
		/// <para>一个标准差—输出椭圆将覆盖输入要素的一个标准差。 这是默认设置。</para>
		/// <para>两个标准差—输出椭圆将覆盖输入要素的两个标准差。</para>
		/// <para>三个标准差—输出椭圆将覆盖输入要素的三个标准差。</para>
		/// <para><see cref="EllipseSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? EllipseSize { get; set; } = "1_STANDARD_DEVIATION";

		/// <summary>
		/// <para>Weight Field</para>
		/// <para>根据各位置的相对重要性对它们进行加权的数值型字段。 这适用于所有汇总类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Double")]
		public object? WeightField { get; set; }

		/// <summary>
		/// <para>Group By Field</para>
		/// <para>该字段用于分组类似要素。 这适用于所有汇总类型。 例如，如果选择字段 PlantType，其中包含树木、矮树丛和草地的值，则将对值为树木的所有要素进行分析以获取其自已的中心或离差。 此示例将产生三个要素，针对每组树木、矮树丛和草地各产生一个要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text", "Date", "Double")]
		public object? GroupByField { get; set; }

		/// <summary>
		/// <para>Central Feature Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? OutCentralFeatureLayer { get; set; }

		/// <summary>
		/// <para>Mean Center Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object? OutMeanCenterLayer { get; set; }

		/// <summary>
		/// <para>Median Center Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object? OutMedianCenterLayer { get; set; }

		/// <summary>
		/// <para>Ellipse Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object? OutEllipseLayer { get; set; }

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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SummarizeCenterAndDispersion SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Generate Types</para>
		/// </summary>
		public enum GenerateTypesEnum 
		{
			/// <summary>
			/// <para>中心要素—将创建一个图层，其中包含输入图层中最中心要素的副本。</para>
			/// </summary>
			[GPValue("CENTRAL_FEATURE")]
			[Description("中心要素")]
			Central_Feature,

			/// <summary>
			/// <para>平均中心—将创建一个表示输入图层平均中心的点图层。</para>
			/// </summary>
			[GPValue("MEAN_CENTER")]
			[Description("平均中心")]
			Mean_Center,

			/// <summary>
			/// <para>中位数中心—将创建一个表示输入图层中位数中心的点图层。</para>
			/// </summary>
			[GPValue("MEDIAN_CENTER")]
			[Description("中位数中心")]
			Median_Center,

			/// <summary>
			/// <para>椭圆—将创建一个表示输入图层方向椭圆的面图层。</para>
			/// </summary>
			[GPValue("ELLIPSE")]
			[Description("椭圆")]
			Ellipse,

		}

		/// <summary>
		/// <para>Ellipse Size</para>
		/// </summary>
		public enum EllipseSizeEnum 
		{
			/// <summary>
			/// <para>一个标准差—输出椭圆将覆盖输入要素的一个标准差。 这是默认设置。</para>
			/// </summary>
			[GPValue("1_STANDARD_DEVIATION")]
			[Description("一个标准差")]
			One_standard_deviation,

			/// <summary>
			/// <para>两个标准差—输出椭圆将覆盖输入要素的两个标准差。</para>
			/// </summary>
			[GPValue("2_STANDARD_DEVIATIONS")]
			[Description("两个标准差")]
			Two_standard_deviations,

			/// <summary>
			/// <para>三个标准差—输出椭圆将覆盖输入要素的三个标准差。</para>
			/// </summary>
			[GPValue("3_STANDARD_DEVIATIONS")]
			[Description("三个标准差")]
			Three_standard_deviations,

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
