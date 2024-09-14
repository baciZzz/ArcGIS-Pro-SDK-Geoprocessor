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
	/// <para>File Compare</para>
	/// <para>Compares two files and returns the comparison results..</para>
	/// </summary>
	public class FileCompare : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InBaseFile">
		/// <para>Input Base File</para>
		/// <para>The Input Base File is compared with the Input Test File. The Input Base File refers to a file that you have declared valid. This base file has the correct content and information.</para>
		/// </param>
		/// <param name="InTestFile">
		/// <para>Input Test File</para>
		/// <para>The Input Test File is compared against the Input Base File. The Input Test File refers to a file that you have made changes to by editing or compiling new information.</para>
		/// </param>
		public FileCompare(object InBaseFile, object InTestFile)
		{
			this.InBaseFile = InBaseFile;
			this.InTestFile = InTestFile;
		}

		/// <summary>
		/// <para>Tool Display Name : File Compare</para>
		/// </summary>
		public override string DisplayName() => "File Compare";

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
		public override object[] Parameters() => new object[] { InBaseFile, InTestFile, FileType!, ContinueCompare!, OutCompareFile!, CompareStatus! };

		/// <summary>
		/// <para>Input Base File</para>
		/// <para>The Input Base File is compared with the Input Test File. The Input Base File refers to a file that you have declared valid. This base file has the correct content and information.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object InBaseFile { get; set; }

		/// <summary>
		/// <para>Input Test File</para>
		/// <para>The Input Test File is compared against the Input Base File. The Input Test File refers to a file that you have made changes to by editing or compiling new information.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object InTestFile { get; set; }

		/// <summary>
		/// <para>File Type</para>
		/// <para>The type of files being compared.</para>
		/// <para>ASCII—Compare using ASCII characters. This is the default.</para>
		/// <para>Binary—Perform a binary compare.</para>
		/// <para><see cref="FileTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FileType { get; set; } = "ASCII";

		/// <summary>
		/// <para>Continue Comparison</para>
		/// <para>Indicates whether to compare all properties after encountering the first mismatch.</para>
		/// <para>Unchecked—Stops after encountering the first mismatch. This is the default.</para>
		/// <para>Checked—Compares other properties after encountering the first mismatch.</para>
		/// <para><see cref="ContinueCompareEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ContinueCompare { get; set; } = "false";

		/// <summary>
		/// <para>Output Compare File</para>
		/// <para>This file will contain all similarities and differences between the Input Base File and the Input Test File. This file is a comma-delimited text file which can be viewed and used as a table in ArcGIS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object? OutCompareFile { get; set; }

		/// <summary>
		/// <para>Compare Status</para>
		/// <para><see cref="CompareStatusEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CompareStatus { get; set; } = "true";

		#region InnerClass

		/// <summary>
		/// <para>File Type</para>
		/// </summary>
		public enum FileTypeEnum 
		{
			/// <summary>
			/// <para>ASCII—Compare using ASCII characters. This is the default.</para>
			/// </summary>
			[GPValue("ASCII")]
			[Description("ASCII")]
			ASCII,

			/// <summary>
			/// <para>Binary—Perform a binary compare.</para>
			/// </summary>
			[GPValue("BINARY")]
			[Description("Binary")]
			Binary,

		}

		/// <summary>
		/// <para>Continue Comparison</para>
		/// </summary>
		public enum ContinueCompareEnum 
		{
			/// <summary>
			/// <para>Checked—Compares other properties after encountering the first mismatch.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CONTINUE_COMPARE")]
			CONTINUE_COMPARE,

			/// <summary>
			/// <para>Unchecked—Stops after encountering the first mismatch. This is the default.</para>
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
