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
	/// <para>Aggregate Points</para>
	/// <para>聚合点</para>
	/// <para>将点聚合到面要素或立方图格。系统将返回一个面，其中包含存在点的所有位置的点计数以及可选统计数据。</para>
	/// </summary>
	public class AggregatePoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="PointLayer">
		/// <para>Point Layer</para>
		/// <para>聚合到面或立方图格的点要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>包含所聚合面结果的新要素类。</para>
		/// </param>
		/// <param name="PolygonOrBin">
		/// <para>Polygon or Bin</para>
		/// <para>指定点图层的聚合方式。</para>
		/// <para>面—点图层将聚合到面数据集。</para>
		/// <para>图格—点图层将聚合到运行此工具时生成的方形或六角立方图格。</para>
		/// <para><see cref="PolygonOrBinEnum"/></para>
		/// </param>
		public AggregatePoints(object PointLayer, object OutFeatureClass, object PolygonOrBin)
		{
			this.PointLayer = PointLayer;
			this.OutFeatureClass = OutFeatureClass;
			this.PolygonOrBin = PolygonOrBin;
		}

		/// <summary>
		/// <para>Tool Display Name : 聚合点</para>
		/// </summary>
		public override string DisplayName() => "聚合点";

		/// <summary>
		/// <para>Tool Name : AggregatePoints</para>
		/// </summary>
		public override string ToolName() => "AggregatePoints";

		/// <summary>
		/// <para>Tool Excute Name : gapro.AggregatePoints</para>
		/// </summary>
		public override string ExcuteName() => "gapro.AggregatePoints";

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
		public override object[] Parameters() => new object[] { PointLayer, OutFeatureClass, PolygonOrBin, PolygonLayer!, BinType!, BinSize!, TimeStepInterval!, TimeStepRepeat!, TimeStepReference!, SummaryFields! };

		/// <summary>
		/// <para>Point Layer</para>
		/// <para>聚合到面或立方图格的点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object PointLayer { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含所聚合面结果的新要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Polygon or Bin</para>
		/// <para>指定点图层的聚合方式。</para>
		/// <para>面—点图层将聚合到面数据集。</para>
		/// <para>图格—点图层将聚合到运行此工具时生成的方形或六角立方图格。</para>
		/// <para><see cref="PolygonOrBinEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PolygonOrBin { get; set; } = "POLYGON";

		/// <summary>
		/// <para>Polygon Layer</para>
		/// <para>输入点将聚合到的面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object? PolygonLayer { get; set; }

		/// <summary>
		/// <para>Bin Type</para>
		/// <para>指定将生成的用于保存聚合点的立方图格形状。</para>
		/// <para>正方形—将生成方形立方图格，其中立方图格大小表示方形的高度。这是默认设置。</para>
		/// <para>六边形—将生成六边形立方图格，其中图格大小表示两条平行边之间的高度。</para>
		/// <para><see cref="BinTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? BinType { get; set; }

		/// <summary>
		/// <para>Bin Size</para>
		/// <para>表示点图层将聚合到的立方图格大小和单位的距离间隔。距离间隔必须为线性单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object? BinSize { get; set; }

		/// <summary>
		/// <para>Time Step Interval</para>
		/// <para>用来指定时间步长持续时间的值。 只有在输入点启用了时间且表示时刻时，此参数才可用。</para>
		/// <para>只有对输入启用了时间的情况下，才可应用时间步长。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TimeStepInterval { get; set; }

		/// <summary>
		/// <para>Time Step Repeat</para>
		/// <para>用来指定时间步长间隔发生频率的值。 只有在输入点启用了时间且表示时刻时，此参数才可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TimeStepRepeat { get; set; }

		/// <summary>
		/// <para>Time Step Reference</para>
		/// <para>用来指定时间步长所要对齐的参考时间的日期。 默认情况下为 1970 年 1 月 1 日 12:00 a.m.。只有在输入点启用了时间且表示时刻时，此参数才可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? TimeStepReference { get; set; }

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>将根据指定字段进行计算的统计数据。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? SummaryFields { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AggregatePoints SetEnviroment(object? extent = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? workspace = null)
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
			/// <para>面—点图层将聚合到面数据集。</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("面")]
			Polygon,

			/// <summary>
			/// <para>图格—点图层将聚合到运行此工具时生成的方形或六角立方图格。</para>
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
			/// <para>正方形—将生成方形立方图格，其中立方图格大小表示方形的高度。这是默认设置。</para>
			/// </summary>
			[GPValue("SQUARE")]
			[Description("正方形")]
			Square,

			/// <summary>
			/// <para>六边形—将生成六边形立方图格，其中图格大小表示两条平行边之间的高度。</para>
			/// </summary>
			[GPValue("HEXAGON")]
			[Description("六边形")]
			Hexagon,

		}

#endregion
	}
}
