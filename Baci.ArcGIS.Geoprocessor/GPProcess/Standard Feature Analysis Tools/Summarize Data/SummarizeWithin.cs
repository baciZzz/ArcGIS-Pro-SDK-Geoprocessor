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
	/// <para>Summarize Within</para>
	/// <para>Summarize Within</para>
	/// <para>Finds the point, line, or polygon features (or portions of these features) that are within the boundaries of polygons in another layer.</para>
	/// </summary>
	public class SummarizeWithin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Sumwithinlayer">
		/// <para>Input Polygons</para>
		/// <para>Features, or portions of features, in the input summary features that fall within the boundaries of these polygons will be summarized.</para>
		/// </param>
		/// <param name="Summarylayer">
		/// <para>Input Summary Features</para>
		/// <para>The point, line, or polygon features that will be summarized for each input polygon.</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>The name of the output layer to create on your portal.</para>
		/// </param>
		public SummarizeWithin(object Sumwithinlayer, object Summarylayer, object Outputname)
		{
			this.Sumwithinlayer = Sumwithinlayer;
			this.Summarylayer = Summarylayer;
			this.Outputname = Outputname;
		}

		/// <summary>
		/// <para>Tool Display Name : Summarize Within</para>
		/// </summary>
		public override string DisplayName() => "Summarize Within";

		/// <summary>
		/// <para>Tool Name : SummarizeWithin</para>
		/// </summary>
		public override string ToolName() => "SummarizeWithin";

		/// <summary>
		/// <para>Tool Excute Name : sfa.SummarizeWithin</para>
		/// </summary>
		public override string ExcuteName() => "sfa.SummarizeWithin";

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
		public override string[] ValidEnvironments() => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Sumwithinlayer, Summarylayer, Outputname, Sumshape, Shapeunits, Summaryfields, Groupbyfield, Minoritymajority, Percentshape, Outputlayer, Groupbysummarylayer };

		/// <summary>
		/// <para>Input Polygons</para>
		/// <para>Features, or portions of features, in the input summary features that fall within the boundaries of these polygons will be summarized.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object Sumwithinlayer { get; set; }

		/// <summary>
		/// <para>Input Summary Features</para>
		/// <para>The point, line, or polygon features that will be summarized for each input polygon.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polyline", "Polygon")]
		[FeatureType("Simple")]
		public object Summarylayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output layer to create on your portal.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Add shape summary attributes</para>
		/// <para>Calculate statistics based on the shape of the input summary features, such as the length of lines or areas of polygons of the input summary features within each input polygon.</para>
		/// <para>Checked—Calculate the shape summary attributes. This is the default.</para>
		/// <para>Unchecked—Do not calculate the shape summary attributes.</para>
		/// <para><see cref="SumshapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Sumshape { get; set; } = "true";

		/// <summary>
		/// <para>Shape Unit</para>
		/// <para>If summarizing the shape of the input summary features, specify the units of the shape summary.</para>
		/// <para>When the input summary features are polygons, the valid options are acres, hectares, square meters, square kilometers, square feet, square yards, and square miles.</para>
		/// <para>When the input summary features are lines, the valid options are meters, kilometers, feet, yards, and miles.</para>
		/// <para>Miles—Miles</para>
		/// <para>Feet—Feet</para>
		/// <para>Kilometers—Kilometers</para>
		/// <para>Meters—Meters</para>
		/// <para>Yards—Yards</para>
		/// <para>Acres—Acres</para>
		/// <para>Hectares—Hectares</para>
		/// <para>Square meters—Square meters</para>
		/// <para>Square kilometers—Square kilometers</para>
		/// <para>Square feet—Square feet</para>
		/// <para>Square yards—Square yards</para>
		/// <para>Square miles—Square miles</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Shapeunits { get; set; }

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
		/// <para>This is a field from the input summary features that you can use to calculate statistics separately for each unique attribute value. For example, suppose the input summary features contain point locations of businesses that store hazardous materials, and one of the fields is HazardClass containing codes that describe the type of hazardous material stored. To calculate summaries by each unique value of HazardClass, use it as the group by field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object Groupbyfield { get; set; }

		/// <summary>
		/// <para>Add minority and majority attributes</para>
		/// <para>This only applies when using a group by field. If checked, the minority (least dominant) or the majority (most dominant) attribute values for each group field within each boundary are calculated. Two new fields are added to the output layer prefixed with Majority_ and Minority_.</para>
		/// <para>Unchecked—Do not add minority and majority fields. This is the default.</para>
		/// <para>Checked—Add minority and majority fields.</para>
		/// <para><see cref="MinoritymajorityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Minoritymajority { get; set; } = "false";

		/// <summary>
		/// <para>Add group percentages</para>
		/// <para>This only applies when using a group by field. If checked, the percentage of each unique group value is calculated for each input polygon.</para>
		/// <para>Unchecked—Do not add percentage fields. This is the default.</para>
		/// <para>Checked—Add percentage fields.</para>
		/// <para><see cref="PercentshapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Percentshape { get; set; } = "false";

		/// <summary>
		/// <para>Output Feature Service</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Outputlayer { get; set; }

		/// <summary>
		/// <para>Output Group Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPRecordSet()]
		public object Groupbysummarylayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SummarizeWithin SetEnviroment(object extent = null)
		{
			base.SetEnv(extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Add shape summary attributes</para>
		/// </summary>
		public enum SumshapeEnum 
		{
			/// <summary>
			/// <para>Checked—Calculate the shape summary attributes. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_SHAPE_SUM")]
			ADD_SHAPE_SUM,

			/// <summary>
			/// <para>Unchecked—Do not calculate the shape summary attributes.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SHAPE_SUM")]
			NO_SHAPE_SUM,

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
		/// <para>Add group percentages</para>
		/// </summary>
		public enum PercentshapeEnum 
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
