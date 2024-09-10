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
	/// <para>Reconstruct Tracks</para>
	/// <para>Creates line or polygon tracks from time-enabled input data.</para>
	/// </summary>
	public class ReconstructTracks : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>The points or polygons to be reconstructed into tracks. The input must be a time-enabled layer that represents an instant in time.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>A new feature class with the resulting tracks.</para>
		/// </param>
		/// <param name="TrackFields">
		/// <para>Track Fields</para>
		/// <para>One or more fields that will be used to identify unique tracks.</para>
		/// </param>
		/// <param name="Method">
		/// <para>Method</para>
		/// <para>Specifies the criteria that will be used to reconstruct tracks. If a buffer is used, the Method parameter determines the type of buffer.</para>
		/// <para>Geodesic— If the spatial reference can be panned, tracks will cross the date line when appropriate. If the spatial reference cannot be panned, tracks will be limited to the coordinate system extent and may not wrap.</para>
		/// <para>Planar—Planar buffers will be created.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </param>
		public ReconstructTracks(object InputLayer, object OutFeatureClass, object TrackFields, object Method)
		{
			this.InputLayer = InputLayer;
			this.OutFeatureClass = OutFeatureClass;
			this.TrackFields = TrackFields;
			this.Method = Method;
		}

		/// <summary>
		/// <para>Tool Display Name : Reconstruct Tracks</para>
		/// </summary>
		public override string DisplayName() => "Reconstruct Tracks";

		/// <summary>
		/// <para>Tool Name : ReconstructTracks</para>
		/// </summary>
		public override string ToolName() => "ReconstructTracks";

		/// <summary>
		/// <para>Tool Excute Name : gapro.ReconstructTracks</para>
		/// </summary>
		public override string ExcuteName() => "gapro.ReconstructTracks";

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
		public override object[] Parameters() => new object[] { InputLayer, OutFeatureClass, TrackFields, Method, BufferType, BufferField, BufferExpression, TimeSplit, DistanceSplit, TimeBoundarySplit, TimeBoundaryReference, SummaryFields, SplitExpression, SplitType };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The points or polygons to be reconstructed into tracks. The input must be a time-enabled layer that represents an instant in time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon")]
		[FeatureType("Simple")]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>A new feature class with the resulting tracks.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Track Fields</para>
		/// <para>One or more fields that will be used to identify unique tracks.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date")]
		public object TrackFields { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>Specifies the criteria that will be used to reconstruct tracks. If a buffer is used, the Method parameter determines the type of buffer.</para>
		/// <para>Geodesic— If the spatial reference can be panned, tracks will cross the date line when appropriate. If the spatial reference cannot be panned, tracks will be limited to the coordinate system extent and may not wrap.</para>
		/// <para>Planar—Planar buffers will be created.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "GEODESIC";

		/// <summary>
		/// <para>Buffer Type</para>
		/// <para>Specifies how the buffer distance will be defined.</para>
		/// <para>Field—A single field will be used to define the buffer distance.</para>
		/// <para>Expression—An equation using fields and mathematical operators will be used to define the buffer distance.</para>
		/// <para><see cref="BufferTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BufferType { get; set; }

		/// <summary>
		/// <para>Buffer Field</para>
		/// <para>The field that will be used to buffer the input features. Field values are applied in the units of the spatial reference of the input unless you are using a geographic coordinate system, in which case they will be in meters.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object BufferField { get; set; }

		/// <summary>
		/// <para>Buffer Expression</para>
		/// <para>The expression that will be used to buffer input features. Fields must be numeric, and the expression can include [+ - * / ] operators and multiple fields. Calculated values are applied in the units of the spatial reference of the input unless you are using a geographic coordinate system, in which case they will be in meters.</para>
		/// <para>Use Arcade expressions such as as_kilometers($feature.distance) * 2 + as_meters(15).</para>
		/// <para>If the layer is added to the map, the Fields and Helpers filters can be used to build an expression.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCalculatorExpression()]
		public object BufferExpression { get; set; }

		/// <summary>
		/// <para>Time Split</para>
		/// <para>Features that are farther apart in time than the time-split duration will be split into separate tracks.</para>
		/// <para><see cref="TimeSplitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		[Category("Track Split Options")]
		public object TimeSplit { get; set; }

		/// <summary>
		/// <para>Distance Split</para>
		/// <para>Features that are farther apart in distance than the distance split value will be split into separate tracks.</para>
		/// <para><see cref="DistanceSplitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		[Category("Track Split Options")]
		public object DistanceSplit { get; set; }

		/// <summary>
		/// <para>Time Boundary Split</para>
		/// <para>A time span to split the input data into for analysis. A time boundary allows you to analyze values within a defined time span. For example, if you use a time boundary of 1 day, and set the time boundary reference to January 1, 1980, tracks will be split at the beginning of every day.</para>
		/// <para><see cref="TimeBoundarySplitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		[Category("Track Split Options")]
		public object TimeBoundarySplit { get; set; }

		/// <summary>
		/// <para>Time Boundary Reference</para>
		/// <para>The reference time used to split the input data into for analysis. Time boundaries will be created for the entire span of the data, and the reference time does not need to occur at the start. If no reference time is specified, January 1, 1970, is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Track Split Options")]
		public object TimeBoundaryReference { get; set; }

		/// <summary>
		/// <para>Summary Fields</para>
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
		public object SummaryFields { get; set; }

		/// <summary>
		/// <para>Split Expression</para>
		/// <para>An expression that splits tracks based on values, geometry or time values. Expressions that validate to true will be split.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCalculatorExpression()]
		[Category("Track Split Options")]
		public object SplitExpression { get; set; }

		/// <summary>
		/// <para>Split Type</para>
		/// <para>Specifies how the track segment between two features is created when a track is split. The split type is applied to split expressions, distance splits, and time splits.</para>
		/// <para>Gap—No segment is created between the two features. This is the default.</para>
		/// <para>Finish After—A segment is created between the two features that ends after the split.</para>
		/// <para>Start Before—A segment is created between the two features that ends before the split.</para>
		/// <para><see cref="SplitTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Track Split Options")]
		public object SplitType { get; set; } = "GAP";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ReconstructTracks SetEnviroment(object extent = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Geodesic— If the spatial reference can be panned, tracks will cross the date line when appropriate. If the spatial reference cannot be panned, tracks will be limited to the coordinate system extent and may not wrap.</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("Geodesic")]
			Geodesic,

			/// <summary>
			/// <para>Planar—Planar buffers will be created.</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("Planar")]
			Planar,

		}

		/// <summary>
		/// <para>Buffer Type</para>
		/// </summary>
		public enum BufferTypeEnum 
		{
			/// <summary>
			/// <para>Field—A single field will be used to define the buffer distance.</para>
			/// </summary>
			[GPValue("FIELD")]
			[Description("Field")]
			Field,

			/// <summary>
			/// <para>Expression—An equation using fields and mathematical operators will be used to define the buffer distance.</para>
			/// </summary>
			[GPValue("EXPRESSION")]
			[Description("Expression")]
			Expression,

		}

		/// <summary>
		/// <para>Time Split</para>
		/// </summary>
		public enum TimeSplitEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Milliseconds")]
			[Description("Milliseconds")]
			Milliseconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Seconds")]
			[Description("Seconds")]
			Seconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Hours")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Days")]
			[Description("Days")]
			Days,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Weeks")]
			[Description("Weeks")]
			Weeks,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Months")]
			[Description("Months")]
			Months,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Years")]
			[Description("Years")]
			Years,

		}

		/// <summary>
		/// <para>Distance Split</para>
		/// </summary>
		public enum DistanceSplitEnum 
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
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Miles")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NauticalMiles")]
			[Description("NauticalMiles")]
			NauticalMiles,

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

		}

		/// <summary>
		/// <para>Time Boundary Split</para>
		/// </summary>
		public enum TimeBoundarySplitEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Milliseconds")]
			[Description("Milliseconds")]
			Milliseconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Seconds")]
			[Description("Seconds")]
			Seconds,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Minutes")]
			[Description("Minutes")]
			Minutes,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Hours")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Days")]
			[Description("Days")]
			Days,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Weeks")]
			[Description("Weeks")]
			Weeks,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Months")]
			[Description("Months")]
			Months,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Years")]
			[Description("Years")]
			Years,

		}

		/// <summary>
		/// <para>Split Type</para>
		/// </summary>
		public enum SplitTypeEnum 
		{
			/// <summary>
			/// <para>Gap—No segment is created between the two features. This is the default.</para>
			/// </summary>
			[GPValue("GAP")]
			[Description("Gap")]
			Gap,

			/// <summary>
			/// <para>Finish After—A segment is created between the two features that ends after the split.</para>
			/// </summary>
			[GPValue("FINISH_LAST")]
			[Description("Finish After")]
			Finish_After,

			/// <summary>
			/// <para>Start Before—A segment is created between the two features that ends before the split.</para>
			/// </summary>
			[GPValue("START_NEXT")]
			[Description("Start Before")]
			Start_Before,

		}

#endregion
	}
}
