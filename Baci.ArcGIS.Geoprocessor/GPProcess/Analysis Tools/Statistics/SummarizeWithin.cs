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
	/// <para>Summarize Within</para>
	/// <para>Summarize Within</para>
	/// <para>Overlays a polygon layer with another layer to summarize the number of points, length of the lines, or area of the polygons within each polygon, and calculate attribute field statistics about the features within the polygons.</para>
	/// </summary>
	public class SummarizeWithin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPolygons">
		/// <para>Input Polygons</para>
		/// <para>The polygons used to summarize the features, or portions of features, in the input summary layer.</para>
		/// </param>
		/// <param name="InSumFeatures">
		/// <para>Input Summary Features</para>
		/// <para>The point, line, or polygon features that will be summarized for each polygon in the input polygons.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output polygon feature class containing the same geometries and attributes as the input polygons with additional new attributes for the number points, length of lines, and area of polygons inside each input polygon and statistics about those features.</para>
		/// </param>
		public SummarizeWithin(object InPolygons, object InSumFeatures, object OutFeatureClass)
		{
			this.InPolygons = InPolygons;
			this.InSumFeatures = InSumFeatures;
			this.OutFeatureClass = OutFeatureClass;
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
		/// <para>Tool Excute Name : analysis.SummarizeWithin</para>
		/// </summary>
		public override string ExcuteName() => "analysis.SummarizeWithin";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "outputCoordinateSystem", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPolygons, InSumFeatures, OutFeatureClass, KeepAllPolygons!, SumFields!, SumShape!, ShapeUnit!, GroupField!, AddMinMaj!, AddGroupPercent!, OutGroupTable! };

		/// <summary>
		/// <para>Input Polygons</para>
		/// <para>The polygons used to summarize the features, or portions of features, in the input summary layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InPolygons { get; set; }

		/// <summary>
		/// <para>Input Summary Features</para>
		/// <para>The point, line, or polygon features that will be summarized for each polygon in the input polygons.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polygon", "Polyline")]
		[FeatureType("Simple")]
		public object InSumFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output polygon feature class containing the same geometries and attributes as the input polygons with additional new attributes for the number points, length of lines, and area of polygons inside each input polygon and statistics about those features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Keep all input polygons</para>
		/// <para>Specifies whether all input polygons or only those intersecting or containing at least one input summary feature will be copied to the output feature class.</para>
		/// <para>Checked—All input polygons will be copied to the output feature class. This is the default.</para>
		/// <para>Unchecked—Only input polygons that intersect or contain at least one input summary feature will be copied to the output feature class.</para>
		/// <para><see cref="KeepAllPolygonsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? KeepAllPolygons { get; set; } = "true";

		/// <summary>
		/// <para>Summary Fields</para>
		/// <para>A list of attribute field names from the input summary features, as well as statistical summary types that will be calculated for those attribute fields for all points in each polygon.</para>
		/// <para>Summary fields must be numeric. Text and other attribute field types are not supported.</para>
		/// <para>The following are the statistic types:</para>
		/// <para>Sum—The total value of all the points in each polygon will be calculated.</para>
		/// <para>Mean—The average of all the points in each polygon will be calculated.</para>
		/// <para>Min—The smallest value of all the points in each polygon will be identified.</para>
		/// <para>Max—The largest value of all the points in each polygon will be identified.</para>
		/// <para>Stddev—The standard deviation of all the points in each polygon will be calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? SumFields { get; set; }

		/// <summary>
		/// <para>Add shape summary  attributes</para>
		/// <para>Specifies whether attributes for the number of points, length of lines, and area of polygon features summarized in each input polygon will be added to the output.</para>
		/// <para>Checked—Shape summary attributes will be added to the output feature class. This is the default.</para>
		/// <para>Unchecked—Shape summary attributes will not be added to the output feature class.</para>
		/// <para><see cref="SumShapeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SumShape { get; set; } = "true";

		/// <summary>
		/// <para>Shape Unit</para>
		/// <para>The unit that will be used when calculating shape summary attributes. If the input summary features are points, no shape unit is necessary, since only the count of points in each input polygon is added.</para>
		/// <para>&lt;para/&gt;If the input summary features are lines, specify a linear unit. If the input summary features are polygons, specify an areal unit.</para>
		/// <para>Meters—The unit will be meters.</para>
		/// <para>Kilometers—The unit will be kilometers.</para>
		/// <para>Feet—The unit will be feet.</para>
		/// <para>Yards—The unit will be yards.</para>
		/// <para>Miles—The unit will be miles.</para>
		/// <para>Acres—The unit will be acres.</para>
		/// <para>Hectares—The unit will be hectares.</para>
		/// <para>Square meters—The unit will be square meters.</para>
		/// <para>Square kilometers—The unit will be square kilometers.</para>
		/// <para>Square feet—The unit will be square feet.</para>
		/// <para>Square yards—The unit will be square yards.</para>
		/// <para>Square miles—The unit will be square miles.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ShapeUnit { get; set; }

		/// <summary>
		/// <para>Group Field</para>
		/// <para>An attribute field from the input summary features that is used for grouping. Features that have the same group field value will be combined and summarized with other features with the same group field value.</para>
		/// <para>When a group field is specified, the Output Grouped Table parameter is required.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text")]
		public object? GroupField { get; set; }

		/// <summary>
		/// <para>Add minority and majority attributes</para>
		/// <para>Specifies whether minority and majority fields will be added to the output. This parameter allows you to determine which group field value is the minority (least dominant) and the majority (most dominant) within each input polygon.</para>
		/// <para>This parameter is active if you specified a Group Field parameter value.</para>
		/// <para>Unchecked—Minority and majority fields will not be added to the output. This is the default.</para>
		/// <para>Checked—Minority and majority fields will be added to the output.</para>
		/// <para><see cref="AddMinMajEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AddMinMaj { get; set; } = "false";

		/// <summary>
		/// <para>Add group percentages</para>
		/// <para>Specifies whether a percentage attribute field will be added to the output. This parameter allows you to determine the percentage of each attribute value in each group.</para>
		/// <para>This parameter is active if you specified a Group Field parameter value.</para>
		/// <para>Unchecked—A percentage attribute field will not be added to the output. This is the default.</para>
		/// <para>Checked—A percentage attribute field will be added to the output.</para>
		/// <para><see cref="AddGroupPercentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AddGroupPercent { get; set; } = "false";

		/// <summary>
		/// <para>Output Grouped Table</para>
		/// <para>An output table that includes summary fields for each group of summary features for each input polygon.</para>
		/// <para>The table will have the following attribute fields:</para>
		/// <para>Join_ID—An ID corresponding to an ID field added to the output feature class</para>
		/// <para>The group field</para>
		/// <para>A shape summary field</para>
		/// <para>One field for each of the summary fields</para>
		/// <para>Percentage field</para>
		/// <para>This parameter is required when the Group Field parameter value is specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutGroupTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SummarizeWithin SetEnviroment(object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? outputZFlag = null, double? outputZValue = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Keep all input polygons</para>
		/// </summary>
		public enum KeepAllPolygonsEnum 
		{
			/// <summary>
			/// <para>Checked—All input polygons will be copied to the output feature class. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_ALL")]
			KEEP_ALL,

			/// <summary>
			/// <para>Unchecked—Only input polygons that intersect or contain at least one input summary feature will be copied to the output feature class.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ONLY_INTERSECTING")]
			ONLY_INTERSECTING,

		}

		/// <summary>
		/// <para>Add shape summary  attributes</para>
		/// </summary>
		public enum SumShapeEnum 
		{
			/// <summary>
			/// <para>Checked—Shape summary attributes will be added to the output feature class. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_SHAPE_SUM")]
			ADD_SHAPE_SUM,

			/// <summary>
			/// <para>Unchecked—Shape summary attributes will not be added to the output feature class.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SHAPE_SUM")]
			NO_SHAPE_SUM,

		}

		/// <summary>
		/// <para>Add minority and majority attributes</para>
		/// </summary>
		public enum AddMinMajEnum 
		{
			/// <summary>
			/// <para>Checked—Minority and majority fields will be added to the output.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_MIN_MAJ")]
			ADD_MIN_MAJ,

			/// <summary>
			/// <para>Unchecked—Minority and majority fields will not be added to the output. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_MIN_MAJ")]
			NO_MIN_MAJ,

		}

		/// <summary>
		/// <para>Add group percentages</para>
		/// </summary>
		public enum AddGroupPercentEnum 
		{
			/// <summary>
			/// <para>Checked—A percentage attribute field will be added to the output.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_PERCENT")]
			ADD_PERCENT,

			/// <summary>
			/// <para>Unchecked—A percentage attribute field will not be added to the output. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_PERCENT")]
			NO_PERCENT,

		}

#endregion
	}
}
