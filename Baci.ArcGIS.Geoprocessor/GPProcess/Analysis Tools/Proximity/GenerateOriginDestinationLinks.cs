using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AnalysisTools
{
	/// <summary>
	/// <para>Generate Origin-Destination Links</para>
	/// <para>Generate Origin-Destination Links</para>
	/// <para>Generates connecting lines from origin features to destination features. This is often referred to as a spider diagram.</para>
	/// </summary>
	public class GenerateOriginDestinationLinks : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OriginFeatures">
		/// <para>Origin Features</para>
		/// <para>The input features from which links will be generated.</para>
		/// </param>
		/// <param name="DestinationFeatures">
		/// <para>Destination Features</para>
		/// <para>The destination features to which links will be generated.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output polyline feature class that will contain the output links.</para>
		/// </param>
		public GenerateOriginDestinationLinks(object OriginFeatures, object DestinationFeatures, object OutFeatureClass)
		{
			this.OriginFeatures = OriginFeatures;
			this.DestinationFeatures = DestinationFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Origin-Destination Links</para>
		/// </summary>
		public override string DisplayName() => "Generate Origin-Destination Links";

		/// <summary>
		/// <para>Tool Name : GenerateOriginDestinationLinks</para>
		/// </summary>
		public override string ToolName() => "GenerateOriginDestinationLinks";

		/// <summary>
		/// <para>Tool Excute Name : analysis.GenerateOriginDestinationLinks</para>
		/// </summary>
		public override string ExcuteName() => "analysis.GenerateOriginDestinationLinks";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise() => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { OriginFeatures, DestinationFeatures, OutFeatureClass, OriginGroupField!, DestinationGroupField!, LineType!, NumNearest!, SearchDistance!, DistanceUnit!, AggregateLinks!, SumFields! };

		/// <summary>
		/// <para>Origin Features</para>
		/// <para>The input features from which links will be generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object OriginFeatures { get; set; }

		/// <summary>
		/// <para>Destination Features</para>
		/// <para>The destination features to which links will be generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object DestinationFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output polyline feature class that will contain the output links.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Origin Group Field</para>
		/// <para>The attribute field from the input origin features that will be used for grouping. Features that have the same group field value between origins and destinations will be connected with a link.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object? OriginGroupField { get; set; }

		/// <summary>
		/// <para>Destination Group Field</para>
		/// <para>The attribute field from the input destination features that will be used for grouping. Features that have the same group field value between origins and destinations will be connected with a link.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		public object? DestinationGroupField { get; set; }

		/// <summary>
		/// <para>Line Type</para>
		/// <para>Specifies whether a shortest path on a spheroid (geodesic) or a Cartesian projected earth (planar) will be used when generating the output links. Geodesic lines will have a slight curve when their length exceeds approximately 50 kilometers, as the curvature of the Earth makes the shortest distance between two points appear curved when viewed on a 2D map.</para>
		/// <para>It is recommended that you use the Geodesic line type with data stored in a coordinate system that is not appropriate for distance measurements (for example, Web Mercator and any geographic coordinate system) or any dataset that spans a large geographic area.</para>
		/// <para>Planar—Planar distance will be used between features. This is the default.</para>
		/// <para>Geodesic—Geodesic distances will be used between features. This line type takes into account the curvature of the spheroid and correctly deals with data near the dateline and poles.</para>
		/// <para><see cref="LineTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LineType { get; set; } = "PLANAR";

		/// <summary>
		/// <para>Number of Nearest Destinations</para>
		/// <para>The maximum number of links that will be generated per origin feature to the nearest destination features. If no number is specified, the tool will generate links between all origin and destination features.</para>
		/// <para>For example, using a value of 1 will generate links between each origin feature and its closest destination feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? NumNearest { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>The maximum distance between an origin and destination feature that will produce a link feature in the output. The unit of the search distance is specified in the distance unit parameter. If no search distance is specified, the tool will generate links between all origin and destination features regardless of their distance apart.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SearchDistance { get; set; }

		/// <summary>
		/// <para>Distance Unit</para>
		/// <para>Specifies the units used to measure the length of the links. Distances for each link will appear in the LINK_DIST field. If a distance unit is not specified, the distance unit of the origin features&apos; coordinate system will be used.</para>
		/// <para>Kilometers—The distance between origin and destination will be calculated in kilometers.</para>
		/// <para>Meters—The distance between origin and destination will be calculated in meters.</para>
		/// <para>Miles—The distance between origin and destination will be calculated in miles.</para>
		/// <para>Nautical miles—The distance between origin and destination will be calculated in nautical miles.</para>
		/// <para>Yards—The distance between origin and destination will be calculated in yards.</para>
		/// <para>Feet—The distance between origin and destination will be calculated in feet.</para>
		/// <para><see cref="DistanceUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DistanceUnit { get; set; }

		/// <summary>
		/// <para>Aggregate Overlapping Links</para>
		/// <para>Specifies whether overlapping links will be aggregated.</para>
		/// <para>Checked—Overlapping links will be aggregated if the starting point coordinates are the same.</para>
		/// <para>Unchecked—Overlapping links will not be aggregated. This is the default.</para>
		/// <para><see cref="AggregateLinksEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AggregateLinks { get; set; } = "false";

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>Specifies the numeric field or fields containing the attribute values that will be used to calculate the specified statistic. Multiple statistic and field combinations can be specified. Null values are excluded from all statistical calculations.</para>
		/// <para>Text attribute fields can be summarized using first and last statistics. Numeric attribute fields can be summarized using any statistic.</para>
		/// <para>Available statistics types are as follows:</para>
		/// <para>Sum—The values for the specified field will be added together.</para>
		/// <para>Mean—The average for the specified field will be calculated.</para>
		/// <para>Minimum—The smallest value for all records of the specified field will be found.</para>
		/// <para>Maximum—The largest value for all records of the specified field will be found.</para>
		/// <para>Range—The range of values (maximum minus minimum) for the specified field will be calculated.</para>
		/// <para>Standard deviation—The standard deviation of values in the specified field will be calculated.</para>
		/// <para>Count—The number of values included in the statistical calculations will be found. Each value will be counted except null values. To determine the number of null values in a field, create a count on the field in question, create a count on a different field that does not contain null values (for example, the OID if present), and subtract the two values.</para>
		/// <para>First—The specified field value of the first record in the input will be used.</para>
		/// <para>Last—The specified field value of the last record in the input will be used.</para>
		/// <para>Median—The median for all records of the specified field will be calculated.</para>
		/// <para>Variance—The variance for all records of the specified field will be calculated.</para>
		/// <para>Unique—The number of unique values of the specified field will be counted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? SumFields { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateOriginDestinationLinks SetEnviroment(object? extent = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Line Type</para>
		/// </summary>
		public enum LineTypeEnum 
		{
			/// <summary>
			/// <para>Planar—Planar distance will be used between features. This is the default.</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("Planar")]
			Planar,

			/// <summary>
			/// <para>Geodesic—Geodesic distances will be used between features. This line type takes into account the curvature of the spheroid and correctly deals with data near the dateline and poles.</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("Geodesic")]
			Geodesic,

		}

		/// <summary>
		/// <para>Distance Unit</para>
		/// </summary>
		public enum DistanceUnitEnum 
		{
			/// <summary>
			/// <para>Kilometers—The distance between origin and destination will be calculated in kilometers.</para>
			/// </summary>
			[GPValue("KILOMETERS")]
			[Description("Kilometers")]
			Kilometers,

			/// <summary>
			/// <para>Meters—The distance between origin and destination will be calculated in meters.</para>
			/// </summary>
			[GPValue("METERS")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para>Miles—The distance between origin and destination will be calculated in miles.</para>
			/// </summary>
			[GPValue("MILES")]
			[Description("Miles")]
			Miles,

			/// <summary>
			/// <para>Nautical miles—The distance between origin and destination will be calculated in nautical miles.</para>
			/// </summary>
			[GPValue("NAUTICALMILES")]
			[Description("Nautical miles")]
			Nautical_miles,

			/// <summary>
			/// <para>Yards—The distance between origin and destination will be calculated in yards.</para>
			/// </summary>
			[GPValue("YARDS")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para>Feet—The distance between origin and destination will be calculated in feet.</para>
			/// </summary>
			[GPValue("FEET")]
			[Description("Feet")]
			Feet,

		}

		/// <summary>
		/// <para>Aggregate Overlapping Links</para>
		/// </summary>
		public enum AggregateLinksEnum 
		{
			/// <summary>
			/// <para>Checked—Overlapping links will be aggregated if the starting point coordinates are the same.</para>
			/// </summary>
			[GPValue("true")]
			[Description("AGGREGATE_OVERLAPPING")]
			AGGREGATE_OVERLAPPING,

			/// <summary>
			/// <para>Unchecked—Overlapping links will not be aggregated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_AGGREGATE")]
			NO_AGGREGATE,

		}

#endregion
	}
}
