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
	/// <para>Overlays a polygon layer with another layer to summarize the number of points, length of the lines, or area of the polygons within each polygon and calculates attribute field statistics about those features within the polygons.</para>
	/// </summary>
	public class SummarizeWithin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="SummarizedLayer">
		/// <para>Summarized  Layer</para>
		/// <para>The point, line, or polygon features that will be summarized by either polygons or bins.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output  Feature Class</para>
		/// <para>The name of the output feature class that will contain the intersecting geometries and attributes.</para>
		/// </param>
		public SummarizeWithin(object SummarizedLayer, object OutFeatureClass)
		{
			this.SummarizedLayer = SummarizedLayer;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Summarize Within</para>
		/// </summary>
		public override string DisplayName => "Summarize Within";

		/// <summary>
		/// <para>Tool Name : SummarizeWithin</para>
		/// </summary>
		public override string ToolName => "SummarizeWithin";

		/// <summary>
		/// <para>Tool Excute Name : gapro.SummarizeWithin</para>
		/// </summary>
		public override string ExcuteName => "gapro.SummarizeWithin";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { SummarizedLayer, OutFeatureClass, PolygonOrBin, BinType, BinSize, SummaryPolygons, SumShape, ShapeUnits, StandardSummaryFields, WeightedSummaryFields, GroupByField, AddMinorityMajority, AddPercentages, GroupBySummary };

		/// <summary>
		/// <para>Summarized  Layer</para>
		/// <para>The point, line, or polygon features that will be summarized by either polygons or bins.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object SummarizedLayer { get; set; }

		/// <summary>
		/// <para>Output  Feature Class</para>
		/// <para>The name of the output feature class that will contain the intersecting geometries and attributes.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Polygon or Bin</para>
		/// <para>Specifies whether Summarized Layer will be summarized by polygons or bins.</para>
		/// <para>Polygon—The summarized layer will be aggregated into a polygon dataset.</para>
		/// <para>Bin—The summarized layer will be aggregated into square or hexagonal bins that are generated when the tool is run.</para>
		/// <para><see cref="PolygonOrBinEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PolygonOrBin { get; set; } = "POLYGON";

		/// <summary>
		/// <para>Bin Type</para>
		/// <para>Specifies the bin shape that will be generated to summarize features.</para>
		/// <para>Square—Bin Size represents the height of a square. This is the default.</para>
		/// <para>Hexagon—Bin Size represents the height between two parallel sides.</para>
		/// <para><see cref="BinTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BinType { get; set; } = "SQUARE";

		/// <summary>
		/// <para>Bin Size</para>
		/// <para>The distance interval that represents the bin size and units by which the input features will be summarized.</para>
		/// <para><see cref="BinSizeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object BinSize { get; set; }

		/// <summary>
		/// <para>Summary Polygons</para>
		/// <para>The polygons used to summarize the features in the input summarized layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object SummaryPolygons { get; set; }

		/// <summary>
		/// <para>Add Shape Summary Attributes</para>
		/// <para>Specifies whether the length of lines or area of polygons within the summary layer (polygon or bin) will be calculated. The count of points, lines, and polygons intersecting the summary shape will always be included.</para>
		/// <para>Checked—Summary shape values will be calculated. This is the default.</para>
		/// <para>Unchecked—Summary shape values will not be calculated.</para>
		/// <para><see cref="SumShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SumShape { get; set; } = "true";

		/// <summary>
		/// <para>Shape Units</para>
		/// <para>Specifies the unit to be used to calculate shape summary attributes. If the input summary features are points, a shape unit is unnecessary, since only the count of points within each input polygon is added. If the input summary features are lines, specify a linear unit. If the input summary features are polygons, specify an areal unit.</para>
		/// <para>Meters—The shape units will be meters.</para>
		/// <para>Kilometers—The shape units will be kilometers.</para>
		/// <para>Feet—The shape units will be feet.</para>
		/// <para>Yards—The shape units will be yards.</para>
		/// <para>Miles—The shape units will be miles.</para>
		/// <para>Acres—The shape units will be acres.</para>
		/// <para>Hectares—The shape units will be hectares.</para>
		/// <para>Square meters—The shape units will be square meters.</para>
		/// <para>Square kilometers—The shape units will be square kilometers.</para>
		/// <para>Square feet—The shape units will be square feet.</para>
		/// <para>Square yards—The shape units will be square yards.</para>
		/// <para>Square miles—The shape units will be square miles.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ShapeUnits { get; set; }

		/// <summary>
		/// <para>Standard Summary Fields</para>
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
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object StandardSummaryFields { get; set; }

		/// <summary>
		/// <para>Weighted Summary Fields</para>
		/// <para>Specifies the weighted statistics that will be calculated on specified fields.</para>
		/// <para>Count—The count of each field will be calculated, multiplied by the proportion of the summarized layer within the polygons.</para>
		/// <para>Sum—The sum of weighted values in each field will be calculated, in which the weight applied is the proportion of the summarized layer within the polygons.</para>
		/// <para>Mean—The mean of weighted values in each field will be calculated, in which the weight applied is the proportion of the summarized layer within the polygons.</para>
		/// <para>Minimum—The minimum of weighted values in each field will be calculated, in which the weight applied is the proportion of the summarized layer within the polygons.</para>
		/// <para>Maximum—The maximum of weighted values in each field will be calculated, in which the weight applied is the proportion of the summarized layer within the polygons.</para>
		/// <para>Range—The difference between Minimum and Maximum will be calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object WeightedSummaryFields { get; set; }

		/// <summary>
		/// <para>Group By Field</para>
		/// <para>A field from the input summary features that will be used to calculate statistics for each unique attribute value. For example, the input summary features contain point locations of businesses that store hazardous materials, and one of the fields is HazardClass, containing codes that describe the type of hazardous material stored. To calculate summaries by each unique value of HazardClass, use it as the group by field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object GroupByField { get; set; }

		/// <summary>
		/// <para>Add Minority and Majority Attributes</para>
		/// <para>Specifies whether minority (least dominant) and majority (most dominant) attribute values for each group field within each boundary will be added. If they are, two new fields are added to the output layer prefixed with Majority_ and Minority_. This parameter only applies when the Group By Field parameter is used.</para>
		/// <para>Unchecked—Minority and majority fields will not be added. This is the default.</para>
		/// <para>Checked—Minority and majority fields will be added.</para>
		/// <para><see cref="AddMinorityMajorityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AddMinorityMajority { get; set; }

		/// <summary>
		/// <para>Add Group Percentages</para>
		/// <para>Specifies whether percentage fields will be added. If they are, the percentage of each unique group value is calculated for each input polygon. This parameter only applies when the Group By Field and Add Minority and Majority Attributes parameters are used.</para>
		/// <para>Unchecked—Percentage fields will not be added. This is the default.</para>
		/// <para>Checked—Percentage fields will be added.</para>
		/// <para><see cref="AddPercentagesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AddPercentages { get; set; }

		/// <summary>
		/// <para>Group By Summary Table</para>
		/// <para>The output table that will contain the group by summaries.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object GroupBySummary { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SummarizeWithin SetEnviroment(object extent = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object workspace = null )
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
			/// <para>Polygon or Bin</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("Polygon")]
			Polygon,

			/// <summary>
			/// <para>Bin—The summarized layer will be aggregated into square or hexagonal bins that are generated when the tool is run.</para>
			/// </summary>
			[GPValue("BIN")]
			[Description("Bin")]
			Bin,

		}

		/// <summary>
		/// <para>Bin Type</para>
		/// </summary>
		public enum BinTypeEnum 
		{
			/// <summary>
			/// <para>Square—Bin Size represents the height of a square. This is the default.</para>
			/// </summary>
			[GPValue("SQUARE")]
			[Description("Square")]
			Square,

			/// <summary>
			/// <para>Hexagon—Bin Size represents the height between two parallel sides.</para>
			/// </summary>
			[GPValue("HEXAGON")]
			[Description("Hexagon")]
			Hexagon,

		}

		/// <summary>
		/// <para>Bin Size</para>
		/// </summary>
		public enum BinSizeEnum 
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
		/// <para>Add Shape Summary Attributes</para>
		/// </summary>
		public enum SumShapeEnum 
		{
			/// <summary>
			/// <para>Checked—Summary shape values will be calculated. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_SUMMARY")]
			ADD_SUMMARY,

			/// <summary>
			/// <para>Unchecked—Summary shape values will not be calculated.</para>
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
			/// <para>Checked—Minority and majority fields will be added.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_MIN_MAJ")]
			ADD_MIN_MAJ,

			/// <summary>
			/// <para>Unchecked—Minority and majority fields will not be added. This is the default.</para>
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
			/// <para>Checked—Percentage fields will be added.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_PERCENT")]
			ADD_PERCENT,

			/// <summary>
			/// <para>Unchecked—Percentage fields will not be added. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_PERCENT")]
			NO_PERCENT,

		}

#endregion
	}
}
