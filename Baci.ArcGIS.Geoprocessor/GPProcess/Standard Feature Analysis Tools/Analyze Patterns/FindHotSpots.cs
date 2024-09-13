using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.StandardFeatureAnalysisTools
{
	/// <summary>
	/// <para>Find Hot Spots</para>
	/// <para>查找热点</para>
	/// <para>识别您的数据中具有统计显著性的高值（热点）或低值（冷点）或数据计数的空间聚类。使用此工具可查找诸如高和低房屋价值、犯罪密度、交通事故死亡率、失业率以及生物多样性等聚类的热点和冷点。</para>
	/// </summary>
	public class FindHotSpots : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Analysislayer">
		/// <para>Input Features</para>
		/// <para>将要计算热点的点或面要素图层。</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>要在门户中创建的输出图层的名称。</para>
		/// </param>
		public FindHotSpots(object Analysislayer, object Outputname)
		{
			this.Analysislayer = Analysislayer;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : 查找热点</para>
		/// </summary>
		public override string DisplayName() => "查找热点";

		/// <summary>
		/// <para>Tool Name : FindHotSpots</para>
		/// </summary>
		public override string ToolName() => "FindHotSpots";

		/// <summary>
		/// <para>Tool Excute Name : sfa.FindHotSpots</para>
		/// </summary>
		public override string ExcuteName() => "sfa.FindHotSpots";

		/// <summary>
		/// <para>Toolbox Display Name : Standard Feature Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Standard Feature Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : sfa</para>
		/// </summary>
		public override string ToolboxAlise() => "sfa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Analysislayer, Outputname, Analysisfield, Dividebyfield, Boundingpolygonlayer, Aggregatepolygonlayer, Outputlayer };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>将要计算热点的点或面要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polygon")]
		[FeatureType("Simple")]
		public object Analysislayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>要在门户中创建的输出图层的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Analysis Field</para>
		/// <para>要评估的数值字段（事件数、犯罪率和测试得分等）。所选的字段可代表下列各项：</para>
		/// <para>计数（如交通事故数）</para>
		/// <para>比率（每平方英里的犯罪数）</para>
		/// <para>平均值（如数学测验的平均得分）</para>
		/// <para>指数（如顾客满意度得分）</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object Analysisfield { get; set; }

		/// <summary>
		/// <para>Divide By Field</para>
		/// <para>输入图层中用于对数据进行归一化的数值字段。例如，如果点代表犯罪案件，则其除以总人口数可得到人均犯罪分析，而不是原始犯罪计数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object Dividebyfield { get; set; }

		/// <summary>
		/// <para>Bounding Polygons</para>
		/// <para>当分析图层为点且未指定分析字段时，您可以提供定义事件可能发生地点的面要素。例如，如果您正在分析港口中的船只事故，港口的轮廓可以为事故可能发生的地点提供一个良好的边界。当没有提供边界区域时，则分析中将仅包含至少含有一个点的位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		public object Boundingpolygonlayer { get; set; }

		/// <summary>
		/// <para>Aggregation Polygons</para>
		/// <para>当输入图层包含点且未指定分析字段时，您可以提供要聚合和分析点的面要素，例如行政单位。计算每个面内的点数，并分析每个面中的点计数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		public object Aggregatepolygonlayer { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Outputlayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindHotSpots SetEnviroment(object extent = null )
		{
			base.SetEnv(extent: extent);
			return this;
		}

	}
}
