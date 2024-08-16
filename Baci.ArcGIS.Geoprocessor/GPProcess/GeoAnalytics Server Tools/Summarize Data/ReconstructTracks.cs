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
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>The name of the output feature service.</para>
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
		public ReconstructTracks(object InputLayer, object OutputName, object TrackFields, object Method)
		{
			this.InputLayer = InputLayer;
			this.OutputName = OutputName;
			this.TrackFields = TrackFields;
			this.Method = Method;
		}

		/// <summary>
		/// <para>Tool Display Name : Reconstruct Tracks</para>
		/// </summary>
		public override string DisplayName => "Reconstruct Tracks";

		/// <summary>
		/// <para>Tool Name : ReconstructTracks</para>
		/// </summary>
		public override string ToolName => "ReconstructTracks";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.ReconstructTracks</para>
		/// </summary>
		public override string ExcuteName => "geoanalytics.ReconstructTracks";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "GeoAnalytics Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoanalytics</para>
		/// </summary>
		public override string ToolboxAlise => "geoanalytics";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputLayer, OutputName, TrackFields, Method, BufferType, BufferField, BufferExpression, TimeSplit, SummaryFields, Output, DataStore, DistanceSplit, TimeBoundarySplit, TimeBoundaryReference, SplitExpression, SplitType };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The points or polygons to be reconstructed into tracks. The input must be a time-enabled layer that represents an instant in time.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple")]
		[PortalType("DataStoreCatalogLayer")]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output feature service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

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
		/// <para>In ArcGIS Enterprise 10.5 and 10.5.1, expressions are formatted as as_kilometers(distance) * 2 + as_meters(15). In ArcGIS Enterprise 10.6 or later, use Arcade expressions such as as_kilometers($feature.distance) * 2 + as_meters(15).</para>
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
		/// <para>First—The first value of a specified field in a track. This option is available with ArcGIS Enterprise 10.8.1.</para>
		/// <para>Last—The last value of a specified field in a track. This option is available with ArcGIS Enterprise 10.8.1.</para>
		/// <para>The statistics that will be calculated on specified fields.</para>
		/// <para>COUNT—The number of nonnull values. It can be used on numeric fields or strings. The count of [null, 0, 2] is 2.</para>
		/// <para>SUM—The sum of numeric values in a field. The sum of [null, null, 3] is 3.</para>
		/// <para>MEAN—The mean of numeric values. The mean of [0,2, null] is 1.</para>
		/// <para>MIN—The minimum value of a numeric field. The minimum of [0, 2, null] is 0.</para>
		/// <para>MAX—The maximum value of a numeric field. The maximum value of [0, 2, null] is 2.</para>
		/// <para>STDDEV—The standard deviation of a numeric field. The standard deviation of [1] is null. The standard deviation of [null, 1,1,1] is null.</para>
		/// <para>VAR—The variance of a numeric field in a track. The variance of [1] is null. The variance of [null, 1,1,1] is null.</para>
		/// <para>RANGE—The range of a numeric field. This is calculated as the minimum value subtracted from the maximum value. The range of [0, null, 1] is 1. The range of [null, 4] is 0.</para>
		/// <para>ANY—A sample string from a field of type string.</para>
		/// <para>FIRST—The first value of a specified field in a track. This option is available with ArcGIS Enterprise 10.8.1.</para>
		/// <para>LAST—The last value of a specified field in a track. This option is available with ArcGIS Enterprise 10.8.1.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object SummaryFields { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Data Store</para>
		/// <para>Specifies the ArcGIS Data Store where the output will be saved. The default is Spatiotemporal big data store. All results stored in a spatiotemporal big data store will be stored in WGS84. Results stored in a relational data store will maintain their coordinate system.</para>
		/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
		/// <para>Relational data store—Output will be stored in a relational data store.</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Data Store")]
		public object DataStore { get; set; } = "SPATIOTEMPORAL_DATA_STORE";

		/// <summary>
		/// <para>Distance Split</para>
		/// <para>Features that are farther apart in distance than the distance split value will be split into separate tracks. This parameter is only available with ArcGIS Enterprise 10.6 and later.</para>
		/// <para><see cref="DistanceSplitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		[Category("Track Split Options")]
		public object DistanceSplit { get; set; }

		/// <summary>
		/// <para>Time Boundary Split</para>
		/// <para>A time span to split the input data into for analysis. A time boundary allows you to analyze values within a defined time span. For example, if you use a time boundary of 1 day, starting on January 1, 1980, tracks will be split at the beginning of every day. This parameter is only available with ArcGIS Enterprise 10.7 and later.</para>
		/// <para><see cref="TimeBoundarySplitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTimeUnit()]
		[GPCodedValueDomain()]
		[Category("Track Split Options")]
		public object TimeBoundarySplit { get; set; }

		/// <summary>
		/// <para>Time Boundary Reference</para>
		/// <para>The reference time used to split the input data into for analysis. Time boundaries will be created for the entire span of the data, and the reference time does not need to occur at the start. If no reference time is specified, January 1, 1970, is used. This parameter is only available with ArcGIS Enterprise 10.7 and later.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		[Category("Track Split Options")]
		public object TimeBoundaryReference { get; set; }

		/// <summary>
		/// <para>Split Expression</para>
		/// <para>An expression that splits tracks based on values, geometry or time values. Expressions that validate to true will be split. This parameter is only available with ArcGIS Enterprise 10.9 and later.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCalculatorExpression()]
		[Category("Track Split Options")]
		public object SplitExpression { get; set; }

		/// <summary>
		/// <para>Split Type</para>
		/// <para>Specifies how the track segment between two features is created when a track is split. The split type is applied to split expressions, distance splits, and time splits. This parameter is only available with ArcGIS Enterprise 10.9 and later.</para>
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
		public ReconstructTracks SetEnviroment(object extent = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
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
		/// <para>Data Store</para>
		/// </summary>
		public enum DataStoreEnum 
		{
			/// <summary>
			/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("Spatiotemporal big data store")]
			Spatiotemporal_big_data_store,

			/// <summary>
			/// <para>Relational data store—Output will be stored in a relational data store.</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("Relational data store")]
			Relational_data_store,

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
