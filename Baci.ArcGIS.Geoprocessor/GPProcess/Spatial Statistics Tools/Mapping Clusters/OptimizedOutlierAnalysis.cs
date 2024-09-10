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
	/// <para>Optimized Outlier Analysis</para>
	/// <para>Given incident points or weighted features (points or polygons), creates a map of statistically significant hot spots, cold spots, and spatial outliers using the Anselin Local Moran's I statistic. It evaluates the characteristics of the input feature class to produce optimal results.</para>
	/// </summary>
	public class OptimizedOutlierAnalysis : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>The point or polygon feature class for which the cluster and outlier analysis will be performed.</para>
		/// </param>
		/// <param name="OutputFeatures">
		/// <para>Output Features</para>
		/// <para>The output feature class to receive the result fields.</para>
		/// </param>
		public OptimizedOutlierAnalysis(object InputFeatures, object OutputFeatures)
		{
			this.InputFeatures = InputFeatures;
			this.OutputFeatures = OutputFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : Optimized Outlier Analysis</para>
		/// </summary>
		public override string DisplayName() => "Optimized Outlier Analysis";

		/// <summary>
		/// <para>Tool Name : OptimizedOutlierAnalysis</para>
		/// </summary>
		public override string ToolName() => "OptimizedOutlierAnalysis";

		/// <summary>
		/// <para>Tool Excute Name : stats.OptimizedOutlierAnalysis</para>
		/// </summary>
		public override string ExcuteName() => "stats.OptimizedOutlierAnalysis";

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
		public override string[] ValidEnvironments() => new string[] { "MResolution", "MTolerance", "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "qualifiedFieldNames", "randomGenerator", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatures, OutputFeatures, AnalysisField, IncidentDataAggregationMethod, BoundingPolygonsDefiningWhereIncidentsArePossible, PolygonsForAggregatingIncidentsIntoCounts, PerformanceAdjustment, CellSize, DistanceBand };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The point or polygon feature class for which the cluster and outlier analysis will be performed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polygon")]
		[FeatureType("Simple")]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Output Features</para>
		/// <para>The output feature class to receive the result fields.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatures { get; set; }

		/// <summary>
		/// <para>Analysis Field</para>
		/// <para>The numeric field (number of incidents, crime rates, test scores, and so on) to be evaluated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double")]
		public object AnalysisField { get; set; }

		/// <summary>
		/// <para>Incident Data Aggregation Method</para>
		/// <para>The aggregation method to use to create weighted features for analysis from incident point data.</para>
		/// <para>Count incidents within fishnet grid—A fishnet polygon mesh will overlay the incident point data and the number of incidents within each polygon cell will be counted. If no bounding polygon is provided in the Bounding Polygons Defining Where Incidents Are Possible parameter, only cells with at least one incident will be used in the analysis; otherwise, all cells within the bounding polygons will be analyzed.</para>
		/// <para>Count incidents within hexagon grid—A hexagon polygon mesh will overlay the incident point data and the number of incidents within each polygon cell will be counted. If no bounding polygon is provided in the Bounding Polygons Defining Where Incidents Are Possible parameter, only cells with at least one incident will be used in the analysis; otherwise, all cells within the bounding polygons will be analyzed.</para>
		/// <para>Count incidents within aggregation polygons—You provide aggregation polygons to overlay the incident point data in the Polygons For Aggregating Incidents Into Counts parameter. The incidents within each polygon are counted.</para>
		/// <para>Snap nearby incidents to create weighted points—Nearby incidents will be aggregated together to create a single weighted point. The weight for each point is the number of aggregated incidents at that location.</para>
		/// <para><see cref="IncidentDataAggregationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object IncidentDataAggregationMethod { get; set; } = "COUNT_INCIDENTS_WITHIN_FISHNET_POLYGONS";

		/// <summary>
		/// <para>Bounding Polygons Defining Where Incidents Are Possible</para>
		/// <para>A polygon feature class defining where the incident Input Features could possibly occur.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object BoundingPolygonsDefiningWhereIncidentsArePossible { get; set; }

		/// <summary>
		/// <para>Polygons For Aggregating Incidents Into Counts</para>
		/// <para>The polygons to use to aggregate the incident Input Features in order to get an incident count for each polygon feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object PolygonsForAggregatingIncidentsIntoCounts { get; set; }

		/// <summary>
		/// <para>Performance Adjustment</para>
		/// <para>This analysis utilizes permutations to create a reference distribution. Choosing the number of permutations is a balance between precision and increased processing time. Choose your preference for speed versus precision. More robust and precise results take longer to calculate.</para>
		/// <para>Quick (199 permutations)—With 199 permutations, the smallest possible pseudo p-value is 0.005 and all other pseudo p-values will be even multiples of this value.</para>
		/// <para>Balanced (499 permutations)—With 499 permutations, the smallest possible pseudo p-value is 0.002 and all other pseudo p-values will be even multiples of this value.</para>
		/// <para>Robust (999 permutations)—With 999 permutations, the smallest possible pseudo p-value is 0.001 and all other pseudo p-values will be even multiples of this value.</para>
		/// <para><see cref="PerformanceAdjustmentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PerformanceAdjustment { get; set; } = "BALANCED_499";

		/// <summary>
		/// <para>Cell Size</para>
		/// <para>The size of the grid cells used to aggregate the Input Features. When aggregating into a hexagon grid, this distance is used as the height to construct the hexagon polygons.</para>
		/// <para><see cref="CellSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		[Category("Override Settings")]
		public object CellSize { get; set; }

		/// <summary>
		/// <para>Distance Band</para>
		/// <para>The spatial extent of the analysis neighborhood. This value determines which features are analyzed together in order to assess local clustering.</para>
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
		public OptimizedOutlierAnalysis SetEnviroment(object MResolution = null , object MTolerance = null , object XYResolution = null , object XYTolerance = null , object ZResolution = null , object ZTolerance = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , bool? qualifiedFieldNames = null , object randomGenerator = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, qualifiedFieldNames: qualifiedFieldNames, randomGenerator: randomGenerator, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Incident Data Aggregation Method</para>
		/// </summary>
		public enum IncidentDataAggregationMethodEnum 
		{
			/// <summary>
			/// <para>Count incidents within fishnet grid—A fishnet polygon mesh will overlay the incident point data and the number of incidents within each polygon cell will be counted. If no bounding polygon is provided in the Bounding Polygons Defining Where Incidents Are Possible parameter, only cells with at least one incident will be used in the analysis; otherwise, all cells within the bounding polygons will be analyzed.</para>
			/// </summary>
			[GPValue("COUNT_INCIDENTS_WITHIN_FISHNET_POLYGONS")]
			[Description("Count incidents within fishnet grid")]
			Count_incidents_within_fishnet_grid,

			/// <summary>
			/// <para>Count incidents within hexagon grid—A hexagon polygon mesh will overlay the incident point data and the number of incidents within each polygon cell will be counted. If no bounding polygon is provided in the Bounding Polygons Defining Where Incidents Are Possible parameter, only cells with at least one incident will be used in the analysis; otherwise, all cells within the bounding polygons will be analyzed.</para>
			/// </summary>
			[GPValue("COUNT_INCIDENTS_WITHIN_HEXAGON_POLYGONS")]
			[Description("Count incidents within hexagon grid")]
			Count_incidents_within_hexagon_grid,

			/// <summary>
			/// <para>Count incidents within aggregation polygons—You provide aggregation polygons to overlay the incident point data in the Polygons For Aggregating Incidents Into Counts parameter. The incidents within each polygon are counted.</para>
			/// </summary>
			[GPValue("COUNT_INCIDENTS_WITHIN_AGGREGATION_POLYGONS")]
			[Description("Count incidents within aggregation polygons")]
			Count_incidents_within_aggregation_polygons,

			/// <summary>
			/// <para>Snap nearby incidents to create weighted points—Nearby incidents will be aggregated together to create a single weighted point. The weight for each point is the number of aggregated incidents at that location.</para>
			/// </summary>
			[GPValue("SNAP_NEARBY_INCIDENTS_TO_CREATE_WEIGHTED_POINTS")]
			[Description("Snap nearby incidents to create weighted points")]
			Snap_nearby_incidents_to_create_weighted_points,

		}

		/// <summary>
		/// <para>Performance Adjustment</para>
		/// </summary>
		public enum PerformanceAdjustmentEnum 
		{
			/// <summary>
			/// <para>Quick (199 permutations)—With 199 permutations, the smallest possible pseudo p-value is 0.005 and all other pseudo p-values will be even multiples of this value.</para>
			/// </summary>
			[GPValue("QUICK_199")]
			[Description("Quick (199 permutations)")]
			QUICK_199,

			/// <summary>
			/// <para>Balanced (499 permutations)—With 499 permutations, the smallest possible pseudo p-value is 0.002 and all other pseudo p-values will be even multiples of this value.</para>
			/// </summary>
			[GPValue("BALANCED_499")]
			[Description("Balanced (499 permutations)")]
			BALANCED_499,

			/// <summary>
			/// <para>Robust (999 permutations)—With 999 permutations, the smallest possible pseudo p-value is 0.001 and all other pseudo p-values will be even multiples of this value.</para>
			/// </summary>
			[GPValue("ROBUST_999")]
			[Description("Robust (999 permutations)")]
			ROBUST_999,

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
