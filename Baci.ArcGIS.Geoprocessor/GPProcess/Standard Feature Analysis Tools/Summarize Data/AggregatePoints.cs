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
	/// <para>Aggregate Points</para>
	/// <para>Uses a layer of point features and a layer of polygon features to determine which points fall within each polygon's area. After determining this point-in-polygon spatial relationship, statistics about all points in the polygon are calculated and assigned to the area.</para>
	/// </summary>
	public class AggregatePoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Pointlayer">
		/// <para>Input Points</para>
		/// <para>The point features that will be aggregated into the polygons in the polygon layer.</para>
		/// </param>
		/// <param name="Polygonlayer">
		/// <para>Aggregating Polygons</para>
		/// <para>The polygon features (areas) into which the input points will be aggregated.</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>The name of the output layer to create on your portal.</para>
		/// </param>
		/// <param name="Keepboundarieswithnopoints">
		/// <para>Keep boundaries with no points</para>
		/// <para>Specifies whether the polygons that have no points within them should be returned in the output.</para>
		/// <para>Checked—Keep polygons that have no points. This is the default.</para>
		/// <para>Unchecked—Do not return polygons with no points in the output.</para>
		/// <para><see cref="KeepboundarieswithnopointsEnum"/></para>
		/// </param>
		public AggregatePoints(object Pointlayer, object Polygonlayer, object Outputname, object Keepboundarieswithnopoints)
		{
			this.Pointlayer = Pointlayer;
			this.Polygonlayer = Polygonlayer;
			this.Outputname = Outputname;
			this.Keepboundarieswithnopoints = Keepboundarieswithnopoints;
		}

		/// <summary>
		/// <para>Tool Display Name : Aggregate Points</para>
		/// </summary>
		public override string DisplayName() => "Aggregate Points";

		/// <summary>
		/// <para>Tool Name : AggregatePoints</para>
		/// </summary>
		public override string ToolName() => "AggregatePoints";

		/// <summary>
		/// <para>Tool Excute Name : sfa.AggregatePoints</para>
		/// </summary>
		public override string ExcuteName() => "sfa.AggregatePoints";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Pointlayer, Polygonlayer, Outputname, Keepboundarieswithnopoints, Summaryfields, Groupbyfield, Minoritymajority, Percentpoints, Aggregatedlayer, Groupsummary };

		/// <summary>
		/// <para>Input Points</para>
		/// <para>The point features that will be aggregated into the polygons in the polygon layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint")]
		[FeatureType("Simple")]
		public object Pointlayer { get; set; }

		/// <summary>
		/// <para>Aggregating Polygons</para>
		/// <para>The polygon features (areas) into which the input points will be aggregated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object Polygonlayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output layer to create on your portal.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Keep boundaries with no points</para>
		/// <para>Specifies whether the polygons that have no points within them should be returned in the output.</para>
		/// <para>Checked—Keep polygons that have no points. This is the default.</para>
		/// <para>Unchecked—Do not return polygons with no points in the output.</para>
		/// <para><see cref="KeepboundarieswithnopointsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Keepboundarieswithnopoints { get; set; } = "true";

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>A list of field names and statistical summary type that you wish to calculate for all points within each polygon. The count of points within each polygon is always returned. The following statistic types are supported:</para>
		/// <para>Sum—The total value.</para>
		/// <para>Minimum—The smallest value.</para>
		/// <para>Max—The largest value.</para>
		/// <para>Mean—The average or mean value.</para>
		/// <para>Standard deviation—The standard deviation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object Summaryfields { get; set; }

		/// <summary>
		/// <para>Group By Field</para>
		/// <para>A field name in the pointLayer. Points that have the same value for the group by field will have their own counts and summary field statistics.</para>
		/// <para>You can create statistical groups using an attribute in the analysis layer. For example, if you are aggregating crimes to neighborhood boundaries, you may have a Crime_type attribute with five different crime types. Each unique crime type forms a group, and the statistics you choose will be calculated for each unique value of Crime_type. When you choose a grouping attribute, two results are created: the result layer and a related table containing the statistics.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object Groupbyfield { get; set; }

		/// <summary>
		/// <para>Add minority and majority attributes</para>
		/// <para>This Boolean parameter is applicable only when a Group By Field is specified. If checked, the minority (least dominant) or the majority (most dominant) attribute values for each group field within each boundary are calculated. Two new fields are added to the output layer prefixed with Majority_ and Minority_.</para>
		/// <para>Unchecked—Do not add minority and majority fields. This is the default.</para>
		/// <para>Checked—Add minority and majority fields.</para>
		/// <para><see cref="MinoritymajorityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Minoritymajority { get; set; } = "false";

		/// <summary>
		/// <para>Add percentage</para>
		/// <para>This Boolean parameter is applicable only when a Group By Field is specified. If checked, the percentage count of points for each unique Group By Field value is calculated. A new field is added to the output group summary table containing the percentages of each attribute value within each group. If Add minority and majority attributes is true, two additional fields are added to the output containing the percentages of the minority and majority attribute values within each group.</para>
		/// <para>Unchecked—Do not add percentage fields. This is the default.</para>
		/// <para>Checked—Add percentage fields.</para>
		/// <para><see cref="PercentpointsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Percentpoints { get; set; } = "false";

		/// <summary>
		/// <para>Output Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Aggregatedlayer { get; set; }

		/// <summary>
		/// <para>Output Group Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object Groupsummary { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AggregatePoints SetEnviroment(object extent = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Keep boundaries with no points</para>
		/// </summary>
		public enum KeepboundarieswithnopointsEnum 
		{
			/// <summary>
			/// <para>Checked—Keep polygons that have no points. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_EMPTY")]
			KEEP_EMPTY,

			/// <summary>
			/// <para>Unchecked—Do not return polygons with no points in the output.</para>
			/// </summary>
			[GPValue("false")]
			[Description("REMOVE_EMPTY")]
			REMOVE_EMPTY,

		}

		/// <summary>
		/// <para>Add minority and majority attributes</para>
		/// </summary>
		public enum MinoritymajorityEnum 
		{
			/// <summary>
			/// <para>Checked—Add minority and majority fields.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_MIN_MAJ")]
			ADD_MIN_MAJ,

			/// <summary>
			/// <para>Unchecked—Do not add minority and majority fields. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MIN_MAJ")]
			NO_MIN_MAJ,

		}

		/// <summary>
		/// <para>Add percentage</para>
		/// </summary>
		public enum PercentpointsEnum 
		{
			/// <summary>
			/// <para>Checked—Add percentage fields.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_PERCENT")]
			ADD_PERCENT,

			/// <summary>
			/// <para>Unchecked—Do not add percentage fields. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_PERCENT")]
			NO_PERCENT,

		}

#endregion
	}
}
