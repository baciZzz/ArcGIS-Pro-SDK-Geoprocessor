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
	/// <para>Transfer Files</para>
	/// <para>Transfer Files</para>
	/// <para>Transfers files between a file system and a cloud storage workspace.</para>
	/// </summary>
	public class TransferFiles : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputPaths">
		/// <para>Input Paths</para>
		/// <para>The list of input files or folders that will be copied to the output folder. The path can be a file system path or cloud storage path where the .acs file can be used.</para>
		/// </param>
		/// <param name="OutputFolder">
		/// <para>Output Folder</para>
		/// <para>The output folder path where the files will be copied.</para>
		/// </param>
		public TransferFiles(object InputPaths, object OutputFolder)
		{
			this.InputPaths = InputPaths;
			this.OutputFolder = OutputFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : Transfer Files</para>
		/// </summary>
		public override string DisplayName() => "Transfer Files";

		/// <summary>
		/// <para>Tool Name : TransferFiles</para>
		/// </summary>
		public override string ToolName() => "TransferFiles";

		/// <summary>
		/// <para>Tool Excute Name : management.TransferFiles</para>
		/// </summary>
		public override string ExcuteName() => "management.TransferFiles";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputPaths, OutputFolder, FileFilter!, DerivedOutputFolder! };

		/// <summary>
		/// <para>Input Paths</para>
		/// <para>The list of input files or folders that will be copied to the output folder. The path can be a file system path or cloud storage path where the .acs file can be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InputPaths { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>The output folder path where the files will be copied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutputFolder { get; set; }

		/// <summary>
		/// <para>Filters</para>
		/// <para>A file pattern filter that will limit the number of files that need to be copied, such as .tif, .crf, and similar image file types.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? FileFilter { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object? DerivedOutputFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TransferFiles SetEnviroment(object? parallelProcessingFactor = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

	}
}
