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
	/// <para>Find Dwell Locations</para>
	/// <para>Find Dwell Locations</para>
	/// <para>Finds locations where moving objects have stopped, or dwelled, using given time and distance thresholds.</para>
	/// </summary>
	public class FindDwellLocations : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>The point tracks in which dwells will be found. The input must be a time-enabled layer with features that represent instants in time.</para>
		/// </param>
		/// <param name="Output">
		/// <para>Output Dataset</para>
		/// <para>The output feature class with the resulting dwells.</para>
		/// </param>
		/// <param name="TrackFields">
		/// <para>Track Fields</para>
		/// <para>One or more fields that will be used to identify unique tracks.</para>
		/// </param>
		/// <param name="DistanceMethod">
		/// <para>Distance Method</para>
		/// <para>Specifies how the distances between dwell features will be calculated.</para>
		/// <para>Geodesic— If the spatial reference can be panned, tracks will cross the international date line when appropriate. If the spatial reference cannot be panned, tracks will be limited to the coordinate system extent and may not wrap.</para>
		/// <para>Planar—Planar distances will be used.</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </param>
		/// <param name="DistanceTolerance">
		/// <para>Distance Tolerance</para>
		/// <para>The maximum distance between points to be considered a single dwell location.</para>
		/// </param>
		/// <param name="TimeTolerance">
		/// <para>Time Tolerance</para>
		/// <para>The minimum time duration to be considered a single dwell location.</para>
		/// <para>Both time and distance are considered when finding dwells. The Distance Tolerance parameter specifies distance.</para>
		/// </param>
		/// <param name="OutputType">
		/// <para>Output Type</para>
		/// <para>Specifies how the dwell features will be output.</para>
		/// <para>Dwell features— All of the input point features that are part of a dwell will be returned.</para>
		/// <para>Mean centers— Points representing the mean centers of each dwell group will be returned. This is the default.</para>
		/// <para>Convex hulls— Polygons representing the convex hull of each dwell group will be returned.</para>
		/// <para>All features— All of the input point features will be returned.</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </param>
		public FindDwellLocations(object InputFeatures, object Output, object TrackFields, object DistanceMethod, object DistanceTolerance, object TimeTolerance, object OutputType)
		{
			this.InputFeatures = InputFeatures;
			this.Output = Output;
			this.TrackFields = TrackFields;
			this.DistanceMethod = DistanceMethod;
			this.DistanceTolerance = DistanceTolerance;
			this.TimeTolerance = TimeTolerance;
			this.OutputType = OutputType;
		}

		/// <summary>
		/// <para>Tool Display Name : Find Dwell Locations</para>
		/// </summary>
		public override string DisplayName() => "Find Dwell Locations";

		/// <summary>
		/// <para>Tool Name : FindDwellLocations</para>
		/// </summary>
		public override string ToolName() => "FindDwellLocations";

		/// <summary>
		/// <para>Tool Excute Name : gapro.FindDwellLocations</para>
		/// </summary>
		public override string ExcuteName() => "gapro.FindDwellLocations";

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
		public override object[] Parameters() => new object[] { InputFeatures, Output, TrackFields, DistanceMethod, DistanceTolerance, TimeTolerance, OutputType, SummaryStatistics!, TimeBoundarySplit!, TimeBoundaryReference! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The point tracks in which dwells will be found. The input must be a time-enabled layer with features that represent instants in time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Output Dataset</para>
		/// <para>The output feature class with the resulting dwells.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Track Fields</para>
		/// <para>One or more fields that will be used to identify unique tracks.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object TrackFields { get; set; }

		/// <summary>
		/// <para>Distance Method</para>
		/// <para>Specifies how the distances between dwell features will be calculated.</para>
		/// <para>Geodesic— If the spatial reference can be panned, tracks will cross the international date line when appropriate. If the spatial reference cannot be panned, tracks will be limited to the coordinate system extent and may not wrap.</para>
		/// <para>Planar—Planar distances will be used.</para>
		/// <para><see cref="DistanceMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DistanceMethod { get; set; } = "PLANAR";

		/// <summary>
		/// <para>Distance Tolerance</para>
		/// <para>The maximum distance between points to be considered a single dwell location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		[GPUnitDomain()]
		public object DistanceTolerance { get; set; }

		/// <summary>
		/// <para>Time Tolerance</para>
		/// <para>The minimum time duration to be considered a single dwell location.</para>
		/// <para>Both time and distance are considered when finding dwells. The Distance Tolerance parameter specifies distance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object TimeTolerance { get; set; }

		/// <summary>
		/// <para>Output Type</para>
		/// <para>Specifies how the dwell features will be output.</para>
		/// <para>Dwell features— All of the input point features that are part of a dwell will be returned.</para>
		/// <para>Mean centers— Points representing the mean centers of each dwell group will be returned. This is the default.</para>
		/// <para>Convex hulls— Polygons representing the convex hull of each dwell group will be returned.</para>
		/// <para>All features— All of the input point features will be returned.</para>
		/// <para><see cref="OutputTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutputType { get; set; } = "DWELL_FEATURES";

		/// <summary>
		/// <para>Summary Statistics</para>
		/// <para>The statistics that will be calculated on specified fields.</para>
		/// <para>Count—The number of nonnull values. It can be used on numeric fields or strings. The count of [null, 0, 2] is 2.</para>
		/// <para>Sum—The sum of numeric values in a field. The sum of [null, null, 3] is 3.</para>
		/// <para>Mean—The mean of numeric values. The mean of [0, 2, null] is 1.</para>
		/// <para>Min—The minimum value of a numeric field. The minimum of [0, 2, null] is 0.</para>
		/// <para>Max—The maximum value of a numeric field. The maximum value of [0, 2, null] is 2.</para>
		/// <para>Standard Deviation—The standard deviation of a numeric field. The standard deviation of [1] is null. The standard deviation of [null, 1,1,1] is null.</para>
		/// <para>Variance—The variance of a numeric field in a track. The variance of [1] is null. The variance of [null, 1, 1, 1] is null.</para>
		/// <para>Range—The range of a numeric field. This is calculated as the minimum value subtracted from the maximum value. The range of [0, null, 1] is 1. The range of [null, 4] is 0.</para>
		/// <para>Any—A sample string from a field of type string.</para>
		/// <para>First—The first value of a specified field in a track.</para>
		/// <para>Last—The last value of a specified field in a track.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? SummaryStatistics { get; set; }

		/// <summary>
		/// <para>Time Boundary Split</para>
		/// <para>A time span to split the input data into for analysis. A time boundary allows you to analyze values within a defined time span. For example, if you use a time boundary of 1 day, and set the time boundary reference to January 1, 1980, tracks will be split at the beginning of every day.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPUnitDomain()]
		public object? TimeBoundarySplit { get; set; }

		/// <summary>
		/// <para>Time Boundary Reference</para>
		/// <para>The reference time used to split the input data into for analysis. Time boundaries will be created for the entire span of the data, and the reference time does not need to occur at the start. If no reference time is specified, January 1, 1970, is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? TimeBoundaryReference { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public FindDwellLocations SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Distance Method</para>
		/// </summary>
		public enum DistanceMethodEnum 
		{
			/// <summary>
			/// <para>Planar—Planar distances will be used.</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("Planar")]
			Planar,

			/// <summary>
			/// <para>Geodesic— If the spatial reference can be panned, tracks will cross the international date line when appropriate. If the spatial reference cannot be panned, tracks will be limited to the coordinate system extent and may not wrap.</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("Geodesic")]
			Geodesic,

		}

		/// <summary>
		/// <para>Output Type</para>
		/// </summary>
		public enum OutputTypeEnum 
		{
			/// <summary>
			/// <para>Mean centers— Points representing the mean centers of each dwell group will be returned. This is the default.</para>
			/// </summary>
			[GPValue("DWELL_MEAN_CENTERS")]
			[Description("Mean centers")]
			Mean_centers,

			/// <summary>
			/// <para>Convex hulls— Polygons representing the convex hull of each dwell group will be returned.</para>
			/// </summary>
			[GPValue("DWELL_CONVEX_HULLS")]
			[Description("Convex hulls")]
			Convex_hulls,

			/// <summary>
			/// <para>Dwell features— All of the input point features that are part of a dwell will be returned.</para>
			/// </summary>
			[GPValue("DWELL_FEATURES")]
			[Description("Dwell features")]
			Dwell_features,

			/// <summary>
			/// <para>All features— All of the input point features will be returned.</para>
			/// </summary>
			[GPValue("ALL_FEATURES")]
			[Description("All features")]
			All_features,

		}

#endregion
	}
}
