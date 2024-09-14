using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Make Aggregation Query Layer</para>
	/// <para>Make Aggregation Query Layer</para>
	/// <para>Creates a query layer that summarizes, aggregates,  and filters DBMS tables dynamically based on time, range, and attribute queries from a related table, and joins the result to a feature layer.</para>
	/// </summary>
	public class MakeAggregationQueryLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetFeatureClass">
		/// <para>Target Feature Class</para>
		/// <para>The feature class or spatial table from an enterprise database.</para>
		/// </param>
		/// <param name="TargetJoinField">
		/// <para>Target Join Field</para>
		/// <para>The field in the target feature class on which the join will be based.</para>
		/// </param>
		/// <param name="RelatedTable">
		/// <para>Related Table</para>
		/// <para>The input table containing the fields that will be used to calculate statistics. Statistics are joined to the Output Layer value.</para>
		/// </param>
		/// <param name="RelatedJoinField">
		/// <para>Related Join Field</para>
		/// <para>A field in the summary table that contains the values on which the join will be based. Aggregation or summary statistics are also calculated separately for each unique attribute value from this field.</para>
		/// </param>
		/// <param name="OutLayer">
		/// <para>Output Layer</para>
		/// <para>The output name of the query layer that will be created.</para>
		/// </param>
		public MakeAggregationQueryLayer(object TargetFeatureClass, object TargetJoinField, object RelatedTable, object RelatedJoinField, object OutLayer)
		{
			this.TargetFeatureClass = TargetFeatureClass;
			this.TargetJoinField = TargetJoinField;
			this.RelatedTable = RelatedTable;
			this.RelatedJoinField = RelatedJoinField;
			this.OutLayer = OutLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Aggregation Query Layer</para>
		/// </summary>
		public override string DisplayName() => "Make Aggregation Query Layer";

		/// <summary>
		/// <para>Tool Name : MakeAggregationQueryLayer</para>
		/// </summary>
		public override string ToolName() => "MakeAggregationQueryLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.MakeAggregationQueryLayer</para>
		/// </summary>
		public override string ExcuteName() => "management.MakeAggregationQueryLayer";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { TargetFeatureClass, TargetJoinField, RelatedTable, RelatedJoinField, OutLayer, Statistics, ParameterDefinitions, OidFields, ShapeType, Srid, SpatialReference, MValues, ZValues, Extent };

		/// <summary>
		/// <para>Target Feature Class</para>
		/// <para>The feature class or spatial table from an enterprise database.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object TargetFeatureClass { get; set; }

		/// <summary>
		/// <para>Target Join Field</para>
		/// <para>The field in the target feature class on which the join will be based.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "OID", "Date", "GUID")]
		public object TargetJoinField { get; set; }

		/// <summary>
		/// <para>Related Table</para>
		/// <para>The input table containing the fields that will be used to calculate statistics. Statistics are joined to the Output Layer value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object RelatedTable { get; set; }

		/// <summary>
		/// <para>Related Join Field</para>
		/// <para>A field in the summary table that contains the values on which the join will be based. Aggregation or summary statistics are also calculated separately for each unique attribute value from this field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "OID", "Date", "GUID")]
		public object RelatedJoinField { get; set; }

		/// <summary>
		/// <para>Output Layer</para>
		/// <para>The output name of the query layer that will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object OutLayer { get; set; }

		/// <summary>
		/// <para>Summary Field(s)</para>
		/// <para>Specifies the numeric field or fields containing the attribute values that will be used to calculate the specified statistic. Multiple statistic and field combinations can be specified. Null values are excluded from all statistical calculations.</para>
		/// <para>The output layer will include a ROW_COUNT field showing total count (or frequency) of each unique value from the Related Join Field value. The difference between the ROW_COUNT field and the Count statistic type is that ROW_COUNT includes null values while Count excludes null values.</para>
		/// <para>Available statistics types are as follows:</para>
		/// <para>Count—The number of values included in the statistical calculations will be found. Each value will be counted except null values.</para>
		/// <para>Sum—The values for the specified field will be added together.</para>
		/// <para>Average—The average for the specified field will be calculated.</para>
		/// <para>Minimum—The smallest value for all records of the specified field will be found.</para>
		/// <para>Maximum—The largest value for all records of the specified field will be found.</para>
		/// <para>Standard deviation—The standard deviation of values in the specified field will be calculated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object Statistics { get; set; }

		/// <summary>
		/// <para>Parameter Definitions</para>
		/// <para>Specifies one or more query parameters for criteria or conditions; records matching these criteria are used while computing aggregated results. A query parameter is similar to an SQL statement variable for which the value is defined when the query is run. This allows you to dynamically change query filters for the output layer. You can think of a parameter as a predicate or condition in a SQL where clause. For example Country_Name = &apos;Nigeria&apos; in a SQL where clause is called a predicate in which the = is a comparison operator, Country_Name is a field name on the left, and &apos;Nigeria&apos; is a value on the right. When you define more than one parameter, you must specify a logical operator between them (such as AND, OR, and so on).</para>
		/// <para>When not specified, all records from the related table will be used in computing aggregated or summary results.</para>
		/// <para>The two parameter definition types are the following:</para>
		/// <para>Range—Connect numeric or temporal values dynamically to the range and time sliders.</para>
		/// <para>Discrete—Update a query with literal values when the query is run.</para>
		/// <para>The following properties are available:</para>
		/// <para>Parameter Type—The parameter type can be Range or Discrete.</para>
		/// <para>Name—The name of the parameter, which is similar to a variable name. A name cannot contain spaces or special characters. Once the output query layer is created and the layer source SQL statement is checked, this name in the SQL statement that defines the output query layer source,will be prefixed with either ::r: (for range parameter) or :: (for discrete parameter).</para>
		/// <para>Alias—The alias for the parameter name. The alias can include spaces and special characters.</para>
		/// <para>Field or Expression—A field name or a valid SQL expression that will be used in the left side of a predicate or condition in a where clause.</para>
		/// <para>Data type—The data type of the field or expression specified in the Field or Expression column. When the Parameter Type value is Range, the Data type column value cannot be String.</para>
		/// <para>Date—The data type of the field or expression will be Date (date time).</para>
		/// <para>String—The data type of the field or expression will be String (text).</para>
		/// <para>Integer—The data type of the field or expression will be Integer (whole numbers).</para>
		/// <para>Double—The data type of the field or expression will be Double (fractional numbers).</para>
		/// <para>Start Value—The default start value for the Range column. This is the value that will be used when the time or range slider is not enabled. When the Start Value and End Value column values are omitted and the time or range slider is disabled, all records from the related table will be used to compute aggregated results. This value is ignored when the Parameter Type column is set to Discrete.</para>
		/// <para>End Value—The default end value for the Range parameter. This is the value that will be used when the time or range slider is not enabled. When the Start Value and End Value column values are omitted and the time or range slider is disabled, all records from the related table will be used to compute aggregated results. This value is ignored when the Parameter Type column is set to Discrete.</para>
		/// <para>Operator for Discrete Parameter—The comparison operator that will be used between the Field or Expression column value and a value in an SQL predicate or condition.</para>
		/// <para>None—Choose None, when Parameter Type is set to Range.</para>
		/// <para>Equal to—Compare the equality of a field or expression to a value.</para>
		/// <para>Not equal to—Test whether a field or expression is not equal to a value.</para>
		/// <para>Greater than—Test whether a field or expression is higher than a value.</para>
		/// <para>Less than—Test whether a field or expression is lower than a value.</para>
		/// <para>Include values—Determine whether a value from a field or expression matches any value in a list.</para>
		/// <para>Default Discrete Values—When the Parameter Type value is Discrete, you must provide a default value. When Operator for Discrete Parameter is Include values, you can provide multiple values separated by commas, for example VANDALISM,BURGLARY/THEFT.</para>
		/// <para>Operator for Next Parameter—The logical operator between this operator and the next one. This column is only applicable when you have more than one parameter definition.</para>
		/// <para>None—Choose None when there are no more parameters.</para>
		/// <para>And—Combine two conditions and select a record if both conditions are true.</para>
		/// <para>Or—Combine two conditions and select a record if at least one condition is true.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object ParameterDefinitions { get; set; }

		/// <summary>
		/// <para>Unique Identifier Field(s)</para>
		/// <para>The unique identifier fields that will be used to uniquely identify each row in the table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object OidFields { get; set; }

		/// <summary>
		/// <para>Shape Type</para>
		/// <para>Specifies the shape type of the query layer. Only those records from the result set of the query that match the specified shape type will be used in the output query layer. By default, the shape type of the first record in the result set will be used. This parameter is ignored if the result set of the query does not return a geometry field.</para>
		/// <para>Point—The output query layer will use point geometry.</para>
		/// <para>Multipoint—The output query layer will use multipoint geometry.</para>
		/// <para>Polygon—The output query layer will use polygon geometry.</para>
		/// <para>Polyline—The output query layer will use polyline geometry.</para>
		/// <para><see cref="ShapeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ShapeType { get; set; }

		/// <summary>
		/// <para>Spatial Reference ID (SRID)</para>
		/// <para>The spatial reference identifier (SRID) value for queries that return geometry. Only those records from the result set of the query that match the specified SRID value will be used in the output query layer. By default, the SRID value of the first record in the result set will be used. This parameter is ignored if the result set of the query does not return a geometry field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Srid { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>The coordinate system that will be used by the output query layer. By default, the spatial reference of the first record in the result set will be used. This parameter is ignored if the result set of the query does not return a geometry field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSpatialReference()]
		public object SpatialReference { get; set; }

		/// <summary>
		/// <para>Coordinates include M values</para>
		/// <para>Specifies whether the output layer will include linear measurements (m-values).</para>
		/// <para>Checked—The layer will include m-values.</para>
		/// <para>Unchecked—The layer will not include m-values. This is the default.</para>
		/// <para><see cref="MValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object MValues { get; set; } = "false";

		/// <summary>
		/// <para>Coordinates include Z values</para>
		/// <para>Specifies whether the output layer will include elevation values (z-values).</para>
		/// <para>Checked—The layer will include z-values.</para>
		/// <para>Unchecked—The layer will not include z-values. This is the default.</para>
		/// <para><see cref="ZValuesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ZValues { get; set; } = "false";

		/// <summary>
		/// <para>Extent</para>
		/// <para>Specifies the extent of the layer. The extent must include all features in the table.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Current Display Extent—The extent is equal to the data frame or visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object Extent { get; set; } = "0 0 0 0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeAggregationQueryLayer SetEnviroment(object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Shape Type</para>
		/// </summary>
		public enum ShapeTypeEnum 
		{
			/// <summary>
			/// <para>Point—The output query layer will use point geometry.</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("Point")]
			Point,

			/// <summary>
			/// <para>Multipoint—The output query layer will use multipoint geometry.</para>
			/// </summary>
			[GPValue("MULTIPOINT")]
			[Description("Multipoint")]
			Multipoint,

			/// <summary>
			/// <para>Polygon—The output query layer will use polygon geometry.</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("Polygon")]
			Polygon,

			/// <summary>
			/// <para>Polyline—The output query layer will use polyline geometry.</para>
			/// </summary>
			[GPValue("POLYLINE")]
			[Description("Polyline")]
			Polyline,

		}

		/// <summary>
		/// <para>Coordinates include M values</para>
		/// </summary>
		public enum MValuesEnum 
		{
			/// <summary>
			/// <para>Checked—The layer will include m-values.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_M_VALUES")]
			INCLUDE_M_VALUES,

			/// <summary>
			/// <para>Unchecked—The layer will not include m-values. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_INCLUDE_M_VALUES")]
			DO_NOT_INCLUDE_M_VALUES,

		}

		/// <summary>
		/// <para>Coordinates include Z values</para>
		/// </summary>
		public enum ZValuesEnum 
		{
			/// <summary>
			/// <para>Checked—The layer will include z-values.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_Z_VALUES")]
			INCLUDE_Z_VALUES,

			/// <summary>
			/// <para>Unchecked—The layer will not include z-values. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_INCLUDE_Z_VALUES")]
			DO_NOT_INCLUDE_Z_VALUES,

		}

#endregion
	}
}
