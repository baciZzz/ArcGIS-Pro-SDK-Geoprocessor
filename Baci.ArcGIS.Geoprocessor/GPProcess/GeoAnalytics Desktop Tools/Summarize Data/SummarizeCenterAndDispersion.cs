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
		public SummarizeCenterAndDispersion(object InputLayer)
		{
			this.InputLayer = InputLayer;
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
		/// <para>Tool Excute Name : gapro.SummarizeCenterAndDispersion</para>
		/// </summary>
		public override string ExcuteName() => "gapro.SummarizeCenterAndDispersion";

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
		public override object[] Parameters() => new object[] { InputLayer, OutCentralFeature, OutMeanCenter, OutMedianCenter, OutEllipse, EllipseSize, WeightField, GroupByField };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>要进行汇总的点、线或面图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon", "Polyline")]
		[FeatureType("Simple")]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Central Feature</para>
		/// <para>将包含位于输入图层最中心的要素的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutCentralFeature { get; set; }

		/// <summary>
		/// <para>Output Mean Center</para>
		/// <para>将包含用于表示输入图层的平均中心的要素的输出点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutMeanCenter { get; set; }

		/// <summary>
		/// <para>Output Median Center</para>
		/// <para>将包含用于表示输入图层的中位数中心的要素的输出点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutMedianCenter { get; set; }

		/// <summary>
		/// <para>Output Ellipse</para>
		/// <para>将包含输入图层的方向椭圆表示的输出面要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutEllipse { get; set; }

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
		public object EllipseSize { get; set; } = "1_STANDARD_DEVIATION";

		/// <summary>
		/// <para>Weight Field</para>
		/// <para>根据各位置的相对重要性对它们进行加权的数值型字段。 这适用于所有汇总类型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Double")]
		public object WeightField { get; set; }

		/// <summary>
		/// <para>Group By Field</para>
		/// <para>该字段用于分组类似要素。 这适用于所有汇总类型。 例如，如果选择字段 PlantType，其中包含树木、矮树丛和草地的值，则将对值为树木的所有要素进行分析以获取其自已的中心或离差。 此示例将产生三个要素，针对每组树木、矮树丛和草地各产生一个要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text", "Date", "Double")]
		public object GroupByField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SummarizeCenterAndDispersion SetEnviroment(object extent = null, object outputCoordinateSystem = null, object parallelProcessingFactor = null, object workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

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

#endregion
	}
}
