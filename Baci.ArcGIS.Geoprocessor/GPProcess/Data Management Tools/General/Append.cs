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
	/// <para>Append</para>
	/// <para>Append</para>
	/// <para>Appends multiple input datasets into an existing target dataset. Input datasets can be feature classes, tables, shapefiles, rasters, or annotation or dimensions feature classes.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class Append : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputs">
		/// <para>Input Datasets</para>
		/// <para>The input datasets containing the data to be appended to the target dataset. Input datasets can be point, line, or polygon feature classes, tables, rasters, annotation feature classes, or dimensions feature classes.</para>
		/// <para>Tables and feature classes can be combined. If a feature class is appended to a table, attributes will be transferred; however, the features will be dropped. If a table is appended to a feature class, the rows from the input table will have null geometry.</para>
		/// </param>
		/// <param name="Target">
		/// <para>Target Dataset</para>
		/// <para>The existing dataset where the data of the input datasets will be appended.</para>
		/// </param>
		public Append(object Inputs, object Target)
		{
			this.Inputs = Inputs;
			this.Target = Target;
		}

		/// <summary>
		/// <para>Tool Display Name : Append</para>
		/// </summary>
		public override string DisplayName() => "Append";

		/// <summary>
		/// <para>Tool Name : Append</para>
		/// </summary>
		public override string ToolName() => "Append";

		/// <summary>
		/// <para>Tool Excute Name : management.Append</para>
		/// </summary>
		public override string ExcuteName() => "management.Append";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "maintainAttachments", "preserveGlobalIds", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputs, Target, SchemaType!, FieldMapping!, Subtype!, Output!, Expression! };

		/// <summary>
		/// <para>Input Datasets</para>
		/// <para>The input datasets containing the data to be appended to the target dataset. Input datasets can be point, line, or polygon feature classes, tables, rasters, annotation feature classes, or dimensions feature classes.</para>
		/// <para>Tables and feature classes can be combined. If a feature class is appended to a table, attributes will be transferred; however, the features will be dropped. If a table is appended to a feature class, the rows from the input table will have null geometry.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Inputs { get; set; }

		/// <summary>
		/// <para>Target Dataset</para>
		/// <para>The existing dataset where the data of the input datasets will be appended.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object Target { get; set; }

		/// <summary>
		/// <para>Field Matching Type</para>
		/// <para>Specifies whether the fields of the input dataset must match the fields of the target dataset for data to be appended.</para>
		/// <para>Input fields must match target fields—Fields from the input dataset must match the fields of the target dataset. An error will be returned if the fields do not match.</para>
		/// <para>Use the field map to reconcile field differences—Fields from the input dataset do not need to match the fields of the target dataset. Any fields from the input datasets that do not match the fields of the target dataset will not be mapped to the target dataset unless the mapping is explicitly set in the Field Map parameter.</para>
		/// <para>Skip and warn if schema does not match—Fields from the input dataset must match the fields of the target dataset. If any of the input datasets contain fields that do not match the target dataset, that input dataset will be omitted with a warning message.</para>
		/// <para><see cref="SchemaTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SchemaType { get; set; } = "TEST";

		/// <summary>
		/// <para>Field Map</para>
		/// <para>Controls how the attribute fields from the input datasets will be transferred or mapped to the target dataset.</para>
		/// <para>This parameter can only be used if the Field Matching Type parameter is set to Use the field map to reconcile field differences.</para>
		/// <para>Because the input datasets are appended to an existing target dataset that has predefined fields, you cannot add, remove, or change the type of the fields in the field map. You can set merge rules for each output field.</para>
		/// <para>Merge rules allow you to specify how values from two or more input fields are merged or combined into a single output value. There are several merge rules you can use to determine how the output field will be populated with values.</para>
		/// <para>First—Use the input fields&apos; first value.</para>
		/// <para>Last—Use the input fields&apos; last value.</para>
		/// <para>Join—Concatenate (join) the input field values.</para>
		/// <para>Sum—Calculate the total of the input field values.</para>
		/// <para>Mean—Calculate the mean (average) of the input field values.</para>
		/// <para>Median—Calculate the median (middle) of the input field values.</para>
		/// <para>Mode—Use the value with the highest frequency.</para>
		/// <para>Min—Use the minimum value of all the input field values.</para>
		/// <para>Max—Use the maximum value of all the input field values.</para>
		/// <para>Standard deviation—Use the standard deviation classification method on all the input field values.</para>
		/// <para>Count—Find the number of records included in the calculation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFieldMapping()]
		public object? FieldMapping { get; set; }

		/// <summary>
		/// <para>Subtype</para>
		/// <para>The subtype description that will be assigned to all new data that is appended to the target dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Subtype { get; set; }

		/// <summary>
		/// <para>Updated Target Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? Output { get; set; }

		/// <summary>
		/// <para>Expression</para>
		/// <para>The SQL expression that will be used to select a subset of the input datasets&apos; records. If multiple input datasets are specified, they will all be evaluated using the expression. If no records match the expression for an input dataset, no records from that dataset will be appended to the target.</para>
		/// <para>For more information about SQL syntax, see SQL reference for query expressions used in ArcGIS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object? Expression { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Append SetEnviroment(object? extent = null, bool? maintainAttachments = null, bool? preserveGlobalIds = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, maintainAttachments: maintainAttachments, preserveGlobalIds: preserveGlobalIds, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Field Matching Type</para>
		/// </summary>
		public enum SchemaTypeEnum 
		{
			/// <summary>
			/// <para>Input fields must match target fields—Fields from the input dataset must match the fields of the target dataset. An error will be returned if the fields do not match.</para>
			/// </summary>
			[GPValue("TEST")]
			[Description("Input fields must match target fields")]
			Input_fields_must_match_target_fields,

			/// <summary>
			/// <para>Use the field map to reconcile field differences—Fields from the input dataset do not need to match the fields of the target dataset. Any fields from the input datasets that do not match the fields of the target dataset will not be mapped to the target dataset unless the mapping is explicitly set in the Field Map parameter.</para>
			/// </summary>
			[GPValue("NO_TEST")]
			[Description("Use the field map to reconcile field differences")]
			Use_the_field_map_to_reconcile_field_differences,

			/// <summary>
			/// <para>Skip and warn if schema does not match—Fields from the input dataset must match the fields of the target dataset. If any of the input datasets contain fields that do not match the target dataset, that input dataset will be omitted with a warning message.</para>
			/// </summary>
			[GPValue("TEST_AND_SKIP")]
			[Description("Skip and warn if schema does not match")]
			Skip_and_warn_if_schema_does_not_match,

		}

#endregion
	}
}
