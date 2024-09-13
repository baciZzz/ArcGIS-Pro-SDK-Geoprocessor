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
	/// <para>传输文件</para>
	/// <para>用于在文件系统和云存储工作空间之间传输文件。</para>
	/// </summary>
	public class TransferFiles : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputPaths">
		/// <para>Input Paths</para>
		/// <para>将复制到输出文件夹的输入文件或文件夹的列表。该路径可以是文件系统路径或云存储路径，其中可以使用 .acs 文件。</para>
		/// </param>
		/// <param name="OutputFolder">
		/// <para>Output Folder</para>
		/// <para>将复制文件的输出文件夹路径。</para>
		/// </param>
		public TransferFiles(object InputPaths, object OutputFolder)
		{
			this.InputPaths = InputPaths;
			this.OutputFolder = OutputFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : 传输文件</para>
		/// </summary>
		public override string DisplayName() => "传输文件";

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
		public override object[] Parameters() => new object[] { InputPaths, OutputFolder, FileFilter, DerivedOutputFolder };

		/// <summary>
		/// <para>Input Paths</para>
		/// <para>将复制到输出文件夹的输入文件或文件夹的列表。该路径可以是文件系统路径或云存储路径，其中可以使用 .acs 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InputPaths { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>将复制文件的输出文件夹路径。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutputFolder { get; set; }

		/// <summary>
		/// <para>Filters</para>
		/// <para>此文件模式过滤器用于限制需要复制的文件（例如 .tif、.crf 和类似的影像文件类型）数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object FileFilter { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object DerivedOutputFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TransferFiles SetEnviroment(object parallelProcessingFactor = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

	}
}
