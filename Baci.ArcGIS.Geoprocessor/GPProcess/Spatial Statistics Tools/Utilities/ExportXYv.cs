using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialStatisticsTools
{
	/// <summary>
	/// <para>Export Feature Attribute To ASCII</para>
	/// <para>Export Feature Attribute To ASCII</para>
	/// <para>Exports feature class coordinates and attribute values to a space-, comma-, tab-, or semicolon-delimited ASCII text file.</para>
	/// </summary>
	public class ExportXYv : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>The feature class from which the feature coordinates and attribute values will be exported.</para>
		/// </param>
		/// <param name="ValueField">
		/// <para>Value Field</para>
		/// <para>The field or fields in the input feature class containing the values to export to an ASCII text file.</para>
		/// </param>
		/// <param name="Delimiter">
		/// <para>Delimiter</para>
		/// <para>Specifies how feature coordinates and attribute values will be separated in the output ASCII file.</para>
		/// <para>Space—Feature coordinates and attribute values will be separated by a space in the output. This is the default.</para>
		/// <para>Comma—Feature coordinates and attribute values will be separated by a comma in the output.</para>
		/// <para>Semicolon—Feature coordinates and attribute values will be separated by a semicolon in the output.</para>
		/// <para>Tab—Feature coordinates and attribute values will be separated by a tab in the output.</para>
		/// <para><see cref="DelimiterEnum"/></para>
		/// </param>
		/// <param name="OutputASCIIFile">
		/// <para>Output ASCII File</para>
		/// <para>The ASCII text file that will contain the feature coordinates and attribute values.</para>
		/// </param>
		/// <param name="AddFieldNamesToOutput">
		/// <para>Add Field Names to Output</para>
		/// <para>Specifies whether field names will be included as the first line in the output text file.</para>
		/// <para>Checked—Field names will be written to the output text file.</para>
		/// <para>Unchecked—Field names will not be written to the output text file. This is the default.</para>
		/// <para><see cref="AddFieldNamesToOutputEnum"/></para>
		/// </param>
		public ExportXYv(object InputFeatureClass, object ValueField, object Delimiter, object OutputASCIIFile, object AddFieldNamesToOutput)
		{
			this.InputFeatureClass = InputFeatureClass;
			this.ValueField = ValueField;
			this.Delimiter = Delimiter;
			this.OutputASCIIFile = OutputASCIIFile;
			this.AddFieldNamesToOutput = AddFieldNamesToOutput;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Feature Attribute To ASCII</para>
		/// </summary>
		public override string DisplayName() => "Export Feature Attribute To ASCII";

		/// <summary>
		/// <para>Tool Name : ExportXYv</para>
		/// </summary>
		public override string ToolName() => "ExportXYv";

		/// <summary>
		/// <para>Tool Excute Name : stats.ExportXYv</para>
		/// </summary>
		public override string ExcuteName() => "stats.ExportXYv";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Statistics Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Statistics Tools";

		/// <summary>
		/// <para>Toolbox Alise : stats</para>
		/// </summary>
		public override string ToolboxAlise() => "stats";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatureClass, ValueField, Delimiter, OutputASCIIFile, AddFieldNamesToOutput };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>The feature class from which the feature coordinates and attribute values will be exported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatureClass { get; set; }

		/// <summary>
		/// <para>Value Field</para>
		/// <para>The field or fields in the input feature class containing the values to export to an ASCII text file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GlobalID")]
		public object ValueField { get; set; }

		/// <summary>
		/// <para>Delimiter</para>
		/// <para>Specifies how feature coordinates and attribute values will be separated in the output ASCII file.</para>
		/// <para>Space—Feature coordinates and attribute values will be separated by a space in the output. This is the default.</para>
		/// <para>Comma—Feature coordinates and attribute values will be separated by a comma in the output.</para>
		/// <para>Semicolon—Feature coordinates and attribute values will be separated by a semicolon in the output.</para>
		/// <para>Tab—Feature coordinates and attribute values will be separated by a tab in the output.</para>
		/// <para><see cref="DelimiterEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Delimiter { get; set; } = "SPACE";

		/// <summary>
		/// <para>Output ASCII File</para>
		/// <para>The ASCII text file that will contain the feature coordinates and attribute values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("txt", "tab", "tsv", "csv")]
		public object OutputASCIIFile { get; set; }

		/// <summary>
		/// <para>Add Field Names to Output</para>
		/// <para>Specifies whether field names will be included as the first line in the output text file.</para>
		/// <para>Checked—Field names will be written to the output text file.</para>
		/// <para>Unchecked—Field names will not be written to the output text file. This is the default.</para>
		/// <para><see cref="AddFieldNamesToOutputEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AddFieldNamesToOutput { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportXYv SetEnviroment(object? geographicTransformations = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Delimiter</para>
		/// </summary>
		public enum DelimiterEnum 
		{
			/// <summary>
			/// <para>Space—Feature coordinates and attribute values will be separated by a space in the output. This is the default.</para>
			/// </summary>
			[GPValue("SPACE")]
			[Description("Space")]
			Space,

			/// <summary>
			/// <para>Comma—Feature coordinates and attribute values will be separated by a comma in the output.</para>
			/// </summary>
			[GPValue("COMMA")]
			[Description("Comma")]
			Comma,

			/// <summary>
			/// <para>Semicolon—Feature coordinates and attribute values will be separated by a semicolon in the output.</para>
			/// </summary>
			[GPValue("SEMI-COLON")]
			[Description("Semicolon")]
			Semicolon,

			/// <summary>
			/// <para>Tab—Feature coordinates and attribute values will be separated by a tab in the output.</para>
			/// </summary>
			[GPValue("TAB")]
			[Description("Tab")]
			Tab,

		}

		/// <summary>
		/// <para>Add Field Names to Output</para>
		/// </summary>
		public enum AddFieldNamesToOutputEnum 
		{
			/// <summary>
			/// <para>Checked—Field names will be written to the output text file.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_FIELD_NAMES")]
			ADD_FIELD_NAMES,

			/// <summary>
			/// <para>Unchecked—Field names will not be written to the output text file. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FIELD_NAMES")]
			NO_FIELD_NAMES,

		}

#endregion
	}
}
