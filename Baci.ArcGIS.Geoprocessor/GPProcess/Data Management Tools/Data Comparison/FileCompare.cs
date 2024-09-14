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
	/// <para>File Compare</para>
	/// <para>文件比较</para>
	/// <para>比较两个文件并返回比较结果。</para>
	/// </summary>
	public class FileCompare : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InBaseFile">
		/// <para>Input Base File</para>
		/// <para>将输入基础文件与输入测试文件进行比较。输入基础文件是指已被声明为有效的文件。此基础文件包含正确的内容和信息。</para>
		/// </param>
		/// <param name="InTestFile">
		/// <para>Input Test File</para>
		/// <para>将输入测试文件与输入基础文件进行比较。输入测试文件是指已通过编辑或编译新信息而进行更改的文件。</para>
		/// </param>
		public FileCompare(object InBaseFile, object InTestFile)
		{
			this.InBaseFile = InBaseFile;
			this.InTestFile = InTestFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 文件比较</para>
		/// </summary>
		public override string DisplayName() => "文件比较";

		/// <summary>
		/// <para>Tool Name : FileCompare</para>
		/// </summary>
		public override string ToolName() => "FileCompare";

		/// <summary>
		/// <para>Tool Excute Name : management.FileCompare</para>
		/// </summary>
		public override string ExcuteName() => "management.FileCompare";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InBaseFile, InTestFile, FileType, ContinueCompare, OutCompareFile, CompareStatus };

		/// <summary>
		/// <para>Input Base File</para>
		/// <para>将输入基础文件与输入测试文件进行比较。输入基础文件是指已被声明为有效的文件。此基础文件包含正确的内容和信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object InBaseFile { get; set; }

		/// <summary>
		/// <para>Input Test File</para>
		/// <para>将输入测试文件与输入基础文件进行比较。输入测试文件是指已通过编辑或编译新信息而进行更改的文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object InTestFile { get; set; }

		/// <summary>
		/// <para>File Type</para>
		/// <para>进行比较的文件的类型。</para>
		/// <para>ASCII—使用 ASCII 字符进行比较。这是默认设置。</para>
		/// <para>二进制—执行二进制比较。</para>
		/// <para><see cref="FileTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FileType { get; set; } = "ASCII";

		/// <summary>
		/// <para>Continue Comparison</para>
		/// <para>指示在遇到第一个不匹配项后是否继续比较所有属性。</para>
		/// <para>未选中 - 在遇到第一个不匹配项后停止比较。这是默认设置。</para>
		/// <para>选中 - 在遇到第一个不匹配项后继续比较其他属性。</para>
		/// <para><see cref="ContinueCompareEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ContinueCompare { get; set; } = "false";

		/// <summary>
		/// <para>Output Compare File</para>
		/// <para>此文件将包含输入基础文件与输入测试文件之间的所有异同点。该文件是一个以逗号分隔的文本文件，在 ArcGIS 中可以表的形式对其进行查看和使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object OutCompareFile { get; set; }

		/// <summary>
		/// <para>Compare Status</para>
		/// <para><see cref="CompareStatusEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CompareStatus { get; set; } = "true";

		#region InnerClass

		/// <summary>
		/// <para>File Type</para>
		/// </summary>
		public enum FileTypeEnum 
		{
			/// <summary>
			/// <para>ASCII—使用 ASCII 字符进行比较。这是默认设置。</para>
			/// </summary>
			[GPValue("ASCII")]
			[Description("ASCII")]
			ASCII,

			/// <summary>
			/// <para>二进制—执行二进制比较。</para>
			/// </summary>
			[GPValue("BINARY")]
			[Description("二进制")]
			Binary,

		}

		/// <summary>
		/// <para>Continue Comparison</para>
		/// </summary>
		public enum ContinueCompareEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CONTINUE_COMPARE")]
			CONTINUE_COMPARE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CONTINUE_COMPARE")]
			NO_CONTINUE_COMPARE,

		}

		/// <summary>
		/// <para>Compare Status</para>
		/// </summary>
		public enum CompareStatusEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("NO_DIFFERENCES_FOUND")]
			NO_DIFFERENCES_FOUND,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DIFFERENCES_FOUND")]
			DIFFERENCES_FOUND,

		}

#endregion
	}
}
