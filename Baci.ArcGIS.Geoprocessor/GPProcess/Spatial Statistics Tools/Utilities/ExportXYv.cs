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
	/// <para>将要素属性导出到 ASCII</para>
	/// <para>将要素类坐标和属性值导出到以空格、逗号、制表符或分号进行分隔的 ASCII 文本文件中。</para>
	/// </summary>
	public class ExportXYv : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>将从中导出要素坐标和属性值的要素类。</para>
		/// </param>
		/// <param name="ValueField">
		/// <para>Value Field</para>
		/// <para>输入要素类中包含要导出到 ASCII 文本文件的值的一个或多个字段。</para>
		/// </param>
		/// <param name="Delimiter">
		/// <para>Delimiter</para>
		/// <para>指定要素坐标和属性值在输出 ASCII 文件中的分隔方式。</para>
		/// <para>空格—要素坐标和属性值将在输出中以空格进行分隔。这是默认设置。</para>
		/// <para>逗号—要素坐标和属性值将在输出中以逗号进行分隔。</para>
		/// <para>分号—要素坐标和属性值将在输出中以分号进行分隔。</para>
		/// <para>制表符—要素坐标和属性值将在输出中以制表符进行分隔。</para>
		/// <para><see cref="DelimiterEnum"/></para>
		/// </param>
		/// <param name="OutputASCIIFile">
		/// <para>Output ASCII File</para>
		/// <para>将包含要素坐标和属性值的 ASCII 文本文件。</para>
		/// </param>
		/// <param name="AddFieldNamesToOutput">
		/// <para>Add Field Names to Output</para>
		/// <para>指定是否将字段名称作为第一行包含在输出文本文件中。</para>
		/// <para>选中 - 将字段名称写入输出文本文件。</para>
		/// <para>未选中 - 字段名称将不会写入输出文本文件。这是默认设置。</para>
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
		/// <para>Tool Display Name : 将要素属性导出到 ASCII</para>
		/// </summary>
		public override string DisplayName() => "将要素属性导出到 ASCII";

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
		/// <para>将从中导出要素坐标和属性值的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatureClass { get; set; }

		/// <summary>
		/// <para>Value Field</para>
		/// <para>输入要素类中包含要导出到 ASCII 文本文件的值的一个或多个字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GlobalID")]
		public object ValueField { get; set; }

		/// <summary>
		/// <para>Delimiter</para>
		/// <para>指定要素坐标和属性值在输出 ASCII 文件中的分隔方式。</para>
		/// <para>空格—要素坐标和属性值将在输出中以空格进行分隔。这是默认设置。</para>
		/// <para>逗号—要素坐标和属性值将在输出中以逗号进行分隔。</para>
		/// <para>分号—要素坐标和属性值将在输出中以分号进行分隔。</para>
		/// <para>制表符—要素坐标和属性值将在输出中以制表符进行分隔。</para>
		/// <para><see cref="DelimiterEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Delimiter { get; set; } = "SPACE";

		/// <summary>
		/// <para>Output ASCII File</para>
		/// <para>将包含要素坐标和属性值的 ASCII 文本文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("txt", "tab", "tsv", "csv")]
		public object OutputASCIIFile { get; set; }

		/// <summary>
		/// <para>Add Field Names to Output</para>
		/// <para>指定是否将字段名称作为第一行包含在输出文本文件中。</para>
		/// <para>选中 - 将字段名称写入输出文本文件。</para>
		/// <para>未选中 - 字段名称将不会写入输出文本文件。这是默认设置。</para>
		/// <para><see cref="AddFieldNamesToOutputEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AddFieldNamesToOutput { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportXYv SetEnviroment(object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
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
			/// <para>空格—要素坐标和属性值将在输出中以空格进行分隔。这是默认设置。</para>
			/// </summary>
			[GPValue("SPACE")]
			[Description("空格")]
			Space,

			/// <summary>
			/// <para>逗号—要素坐标和属性值将在输出中以逗号进行分隔。</para>
			/// </summary>
			[GPValue("COMMA")]
			[Description("逗号")]
			Comma,

			/// <summary>
			/// <para>分号—要素坐标和属性值将在输出中以分号进行分隔。</para>
			/// </summary>
			[GPValue("SEMI-COLON")]
			[Description("分号")]
			Semicolon,

			/// <summary>
			/// <para>制表符—要素坐标和属性值将在输出中以制表符进行分隔。</para>
			/// </summary>
			[GPValue("TAB")]
			[Description("制表符")]
			Tab,

		}

		/// <summary>
		/// <para>Add Field Names to Output</para>
		/// </summary>
		public enum AddFieldNamesToOutputEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADD_FIELD_NAMES")]
			ADD_FIELD_NAMES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FIELD_NAMES")]
			NO_FIELD_NAMES,

		}

#endregion
	}
}
