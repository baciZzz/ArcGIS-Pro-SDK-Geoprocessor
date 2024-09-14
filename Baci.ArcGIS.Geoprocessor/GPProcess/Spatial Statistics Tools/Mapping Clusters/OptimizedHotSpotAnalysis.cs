using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialStatisticsTools
{
	/// <summary>
	/// <para>Optimized Hot Spot Analysis</para>
	/// <para>优化的热点分析</para>
	/// <para>假设存在事件点或加权要素（点或面），可以使用 Getis-Ord Gi* 统计数据创建具有统计显著性的热点和冷点的地图。它通过评估输入要素类的特征来生成可优化结果。</para>
	/// </summary>
	public class OptimizedHotSpotAnalysis : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>将要执行热点分析的点或面要素类。</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>接收 z 得分、p 值和 Gi_Bin 结果的输出要素类。</para>
		/// </param>
		public OptimizedHotSpotAnalysis(object InputFeatures, object OutputFeatures)
		{
			this.InputFeatures = InputFeatures;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 优化的热点分析</para>
		/// </summary>
		public override string DisplayName() => "优化的热点分析";

		/// <summary>
		/// <para>Tool Name : OptimizedHotSpotAnalysis</para>
		/// </summary>
		public override string ToolName() => "OptimizedHotSpotAnalysis";

		/// <summary>
		/// <para>Tool Excute Name : stats.OptimizedHotSpotAnalysis</para>
		/// </summary>
		public override string ExcuteName() => "stats.OptimizedHotSpotAnalysis";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise() => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatures, OutputFeatures, AnalysisField, IncidentDataAggregationMethod, BoundingPolygonsDefiningWhereIncidentsArePossible, PolygonsForAggregatingIncidentsIntoCounts, DensitySurface, CellSize, DistanceBand };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>将要执行热点分析的点或面要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polygon")]
		[FeatureType("Simple")]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>接收 z 得分、p 值和 Gi_Bin 结果的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Analysis Field</para>
		/// <para>要评估的数值字段（事件数、犯罪率和测试得分等）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object AnalysisField { get; set; }

		/// <summary>
		/// <para>Incident Data Aggregation Method</para>
		/// <para>用于创建加权要素以通过事件点数据进行分析的聚合方法。</para>
		/// <para>在渔网格网内计数事件—渔网面网格将覆盖事件点数据，并将计算每个面内的事件数。如果定义事件潜在发生位置的边界面参数中未提供任何边界面，则只分析至少含一个事件的像元；否则，将分析边界面之内的所有像元。</para>
		/// <para>在六边形格网内计数事件—六边形面网格将覆盖事件点数据，并将计算每个面像元内的事件数。如果定义事件潜在发生位置的边界面参数中未提供任何边界面，则只分析至少含一个事件的像元；否则，将分析边界面之内的所有像元。</para>
		/// <para>在渔网面内计数事件—提供聚合面以覆盖用于将事件聚合到计数的面参数中的事件点数据。计算每个面内的事件数。</para>
		/// <para>捕捉附近事件以创建加权点—邻近事件将聚合在一起，从而创建单个加权点。各点的权重值是该位置的聚合事件数。</para>
		/// <para><see cref="IncidentDataAggregationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object IncidentDataAggregationMethod { get; set; } = "COUNT_INCIDENTS_WITHIN_FISHNET_POLYGONS";

		/// <summary>
		/// <para>Bounding Polygons Defining Where Incidents Are Possible</para>
		/// <para>面要素类定义可能会发生输入要素事件的区域。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object BoundingPolygonsDefiningWhereIncidentsArePossible { get; set; }

		/// <summary>
		/// <para>Polygons For Aggregating Incidents Into Counts</para>
		/// <para>用于聚合输入要素事件以获得各面要素的事件计数的面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object PolygonsForAggregatingIncidentsIntoCounts { get; set; }

		/// <summary>
		/// <para>Density Surface</para>
		/// <para>因此，密度表面参数会被禁用；其仍将作为一个工具参数而保留以保持向后兼容性。核密度工具可用于将您的加权点的密度表面可视化。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object DensitySurface { get; set; }

		/// <summary>
		/// <para>Cell Size</para>
		/// <para>用于聚合输入要素的格网像元的大小。当聚合到六边形网格时，该距离用作构建六边形面的高度。</para>
		/// <para><see cref="CellSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		[Category("Override Settings")]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Distance Band</para>
		/// <para>分析邻域的空间范围。该值用于确定将哪些要素一起用于分析以便访问局部聚类。</para>
		/// <para><see cref="DistanceBandEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		[Category("Override Settings")]
		public object DistanceBand { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public OptimizedHotSpotAnalysis SetEnviroment(object MResolution = null, object MTolerance = null, object XYResolution = null, object XYTolerance = null, object ZResolution = null, object ZTolerance = null, object geographicTransformations = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, bool? qualifiedFieldNames = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Incident Data Aggregation Method</para>
		/// </summary>
		public enum IncidentDataAggregationMethodEnum 
		{
			/// <summary>
			/// <para>在渔网格网内计数事件—渔网面网格将覆盖事件点数据，并将计算每个面内的事件数。如果定义事件潜在发生位置的边界面参数中未提供任何边界面，则只分析至少含一个事件的像元；否则，将分析边界面之内的所有像元。</para>
			/// </summary>
			[GPValue("COUNT_INCIDENTS_WITHIN_FISHNET_POLYGONS")]
			[Description("在渔网格网内计数事件")]
			Count_incidents_within_fishnet_grid,

			/// <summary>
			/// <para>在六边形格网内计数事件—六边形面网格将覆盖事件点数据，并将计算每个面像元内的事件数。如果定义事件潜在发生位置的边界面参数中未提供任何边界面，则只分析至少含一个事件的像元；否则，将分析边界面之内的所有像元。</para>
			/// </summary>
			[GPValue("COUNT_INCIDENTS_WITHIN_HEXAGON_POLYGONS")]
			[Description("在六边形格网内计数事件")]
			Count_incidents_within_hexagon_grid,

			/// <summary>
			/// <para>在渔网面内计数事件—提供聚合面以覆盖用于将事件聚合到计数的面参数中的事件点数据。计算每个面内的事件数。</para>
			/// </summary>
			[GPValue("COUNT_INCIDENTS_WITHIN_AGGREGATION_POLYGONS")]
			[Description("在渔网面内计数事件")]
			Count_incidents_within_aggregation_polygons,

			/// <summary>
			/// <para>捕捉附近事件以创建加权点—邻近事件将聚合在一起，从而创建单个加权点。各点的权重值是该位置的聚合事件数。</para>
			/// </summary>
			[GPValue("SNAP_NEARBY_INCIDENTS_TO_CREATE_WEIGHTED_POINTS")]
			[Description("捕捉附近事件以创建加权点")]
			Snap_nearby_incidents_to_create_weighted_points,

		}

		/// <summary>
		/// <para>Cell Size</para>
		/// </summary>
		public enum CellSizeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

		/// <summary>
		/// <para>Distance Band</para>
		/// </summary>
		public enum DistanceBandEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Kilometers")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

		}

#endregion
	}
}
