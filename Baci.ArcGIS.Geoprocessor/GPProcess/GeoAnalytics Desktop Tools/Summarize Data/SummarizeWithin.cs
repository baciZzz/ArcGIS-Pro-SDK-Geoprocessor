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
	/// <para>Summarize Within</para>
	/// <para>范围内汇总</para>
	/// <para>将一个面图层与另一个图层叠加，以便汇总各面内点的数量、线的长度或面的面积，并计算面内此类要素的属性字段统计数据。</para>
	/// </summary>
	public class SummarizeWithin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="SummarizedLayer">
		/// <para>Summarized  Layer</para>
		/// <para>将按面或图格进行汇总的点、线或面要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output  Feature Class</para>
		/// <para>将包含相交几何和属性的输出要素类的名称。</para>
		/// </param>
		public SummarizeWithin(object SummarizedLayer, object OutFeatureClass)
		{
			this.SummarizedLayer = SummarizedLayer;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 范围内汇总</para>
		/// </summary>
		public override string DisplayName() => "范围内汇总";

		/// <summary>
		/// <para>Tool Name : SummarizeWithin</para>
		/// </summary>
		public override string ToolName() => "SummarizeWithin";

		/// <summary>
		/// <para>Tool Excute Name : gapro.SummarizeWithin</para>
		/// </summary>
		public override string ExcuteName() => "gapro.SummarizeWithin";

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
		public override object[] Parameters() => new object[] { SummarizedLayer, OutFeatureClass, PolygonOrBin!, BinType!, BinSize!, SummaryPolygons!, SumShape!, ShapeUnits!, StandardSummaryFields!, WeightedSummaryFields!, GroupByField!, AddMinorityMajority!, AddPercentages!, GroupBySummary! };

		/// <summary>
		/// <para>Summarized  Layer</para>
		/// <para>将按面或图格进行汇总的点、线或面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon", "Polyline")]
		[FeatureType("Simple")]
		public object SummarizedLayer { get; set; }

		/// <summary>
		/// <para>Output  Feature Class</para>
		/// <para>将包含相交几何和属性的输出要素类的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Polygon or Bin</para>
		/// <para>用于指定是否按面或图格对汇总图层进行汇总。</para>
		/// <para>面—汇总图层将聚合到面数据集。</para>
		/// <para>图格—汇总图层将聚合到运行此工具时生成的方形或六角图格。</para>
		/// <para><see cref="PolygonOrBinEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? PolygonOrBin { get; set; } = "POLYGON";

		/// <summary>
		/// <para>Bin Type</para>
		/// <para>指定将生成以汇总要素的图格形状。</para>
		/// <para>方形—图格大小表示方形的高度。 这是默认设置。</para>
		/// <para>六边形—图格大小表示两条平行边之间的高度。</para>
		/// <para><see cref="BinTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? BinType { get; set; } = "SQUARE";

		/// <summary>
		/// <para>Bin Size</para>
		/// <para>表示图格大小和汇总输入要素时所采用单位的距离间隔。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? BinSize { get; set; }

		/// <summary>
		/// <para>Summary Polygons</para>
		/// <para>用于汇总输入汇总图层内要素的面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object? SummaryPolygons { get; set; }

		/// <summary>
		/// <para>Add Shape Summary Attributes</para>
		/// <para>指定是要计算汇总图层（面或图格）内线的长度还是面的面积。 将始终包括与汇总形状相交的点、线和面的计数。</para>
		/// <para>选中 - 将计算汇总形状值。 这是默认设置。</para>
		/// <para>未选中 - 不计算汇总形状值。</para>
		/// <para><see cref="SumShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SumShape { get; set; } = "true";

		/// <summary>
		/// <para>Shape Units</para>
		/// <para>指定要用于计算形状汇总属性的单位。 如果输入汇总要素为点，则不需要使用形状单位，因为仅添加各输入面内点的计数。 如果输入汇总要素为线，则指定一个线性单位。 如果输入汇总要素为面，则指定一个面积单位。</para>
		/// <para>米—形状单位将为米。</para>
		/// <para>千米—形状单位将为公里。</para>
		/// <para>英尺—形状单位将为英尺。</para>
		/// <para>码—形状单位将为码。</para>
		/// <para>英里—形状单位将为英里。</para>
		/// <para>英亩—形状单位将为英亩。</para>
		/// <para>公顷—形状单位将为公顷。</para>
		/// <para>平方米—形状单位将为平方米。</para>
		/// <para>平方千米—形状单位将为平方公里。</para>
		/// <para>平方英尺—形状单位将为平方英尺。</para>
		/// <para>平方码—形状单位将为平方码。</para>
		/// <para>平方英里—形状单位将为平方英里。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ShapeUnits { get; set; }

		/// <summary>
		/// <para>Standard Summary Fields</para>
		/// <para>将根据指定字段进行计算的统计数据。</para>
		/// <para>指定字段是表示计数还是比率。</para>
		/// <para>计数—对于线和面图层，在计算统计数据之前，汇总字段值将根据与汇总面相交的汇总要素的百分比按比例划分。 对于点图层，不会将值按比例划分。</para>
		/// <para>比率—不会将汇总字段值按比例划分。 原始字段值将用于计算统计数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? StandardSummaryFields { get; set; }

		/// <summary>
		/// <para>Weighted Summary Fields</para>
		/// <para>指定将根据指定字段进行计算的加权统计数据。</para>
		/// <para>平均值—将计算每个字段的加权平均值，其中应用的权重是面内汇总图层的比例。</para>
		/// <para>标准差—将计算每个字段的加权标准差，其中应用的权重是面内汇总图层的比例。</para>
		/// <para>方差—将计算每个字段的加权方差，其中应用的权重是面内汇总图层的比例。</para>
		/// <para>指定字段是表示计数还是比率。</para>
		/// <para>计数—在计算统计数据之前，汇总字段值将根据与汇总面相交的汇总要素的百分比按比例划分。</para>
		/// <para>比率—不会将汇总字段值按比例划分。 原始字段值将用于计算统计数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? WeightedSummaryFields { get; set; }

		/// <summary>
		/// <para>Group By Field</para>
		/// <para>输入汇总要素中的字段，将用于计算每个唯一属性值的统计数据。 例如，输入汇总要素包含存储危险材料的企业的点位置，且其中一个字段为 HazardClass，字段中含有用于描述所存储危险材料类型的代码。 要根据每个 HazardClass 唯一值计算汇总，请将其用作分组条件字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text", "Date")]
		public object? GroupByField { get; set; }

		/// <summary>
		/// <para>Add Minority and Majority Attributes</para>
		/// <para>用于指定是否添加各个边界内每个组字段的少数（所占比例最小）或众数（所占比例最大）属性值。 如果添加，则前缀为众数_和少数_的两个新字段将添加至输出图层。 此参数仅当使用按字段分组参数时适用。</para>
		/// <para>未选中 - 将不添加少数和众数字段。 这是默认设置。</para>
		/// <para>选中 - 将添加少数和众数字段。</para>
		/// <para><see cref="AddMinorityMajorityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AddMinorityMajority { get; set; }

		/// <summary>
		/// <para>Add Group Percentages</para>
		/// <para>用于指定是否将添加百分比字段。 如果添加，则系统将针对每个输入面计算每个唯一组百分比值。 此参数仅当使用按字段分组和添加少数和众数属性时适用。</para>
		/// <para>未选中 - 将不添加百分比字段。 这是默认设置。</para>
		/// <para>选中 - 将添加百分比字段。</para>
		/// <para><see cref="AddPercentagesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AddPercentages { get; set; }

		/// <summary>
		/// <para>Group By Summary Table</para>
		/// <para>将包含按汇总分组的输出表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? GroupBySummary { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SummarizeWithin SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Polygon or Bin</para>
		/// </summary>
		public enum PolygonOrBinEnum 
		{
			/// <summary>
			/// <para>面—汇总图层将聚合到面数据集。</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("面")]
			Polygon,

			/// <summary>
			/// <para>图格—汇总图层将聚合到运行此工具时生成的方形或六角图格。</para>
			/// </summary>
			[GPValue("BIN")]
			[Description("图格")]
			Bin,

		}

		/// <summary>
		/// <para>Bin Type</para>
		/// </summary>
		public enum BinTypeEnum 
		{
			/// <summary>
			/// <para>方形—图格大小表示方形的高度。 这是默认设置。</para>
			/// </summary>
			[GPValue("SQUARE")]
			[Description("方形")]
			Square,

			/// <summary>
			/// <para>六边形—图格大小表示两条平行边之间的高度。</para>
			/// </summary>
			[GPValue("HEXAGON")]
			[Description("六边形")]
			Hexagon,

		}

		/// <summary>
		/// <para>Add Shape Summary Attributes</para>
		/// </summary>
		public enum SumShapeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_SUMMARY")]
			ADD_SUMMARY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SUMMARY")]
			NO_SUMMARY,

		}

		/// <summary>
		/// <para>Add Minority and Majority Attributes</para>
		/// </summary>
		public enum AddMinorityMajorityEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_MIN_MAJ")]
			ADD_MIN_MAJ,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MIN_MAJ")]
			NO_MIN_MAJ,

		}

		/// <summary>
		/// <para>Add Group Percentages</para>
		/// </summary>
		public enum AddPercentagesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_PERCENT")]
			ADD_PERCENT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_PERCENT")]
			NO_PERCENT,

		}

#endregion
	}
}
