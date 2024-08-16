using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.WorkflowManagerTools
{
	/// <summary>
	/// <para>Import Job Data</para>
	/// <para>Imports configuration and job information from a Workflow Manager (Classic) repository to a destination repository.  This tool is most useful for setting up a repository similar to an existing repository, disconnected repository replica creation, and changing synchronization.</para>
	/// </summary>
	public class ImportJobData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFile">
		/// <para>Input JXL/Acknowledgement</para>
		/// <para>The JXL file that contains the jobs and configuration elements generated using the Export Job Data tool.</para>
		/// </param>
		/// <param name="InputMerge">
		/// <para>Merge</para>
		/// <para>Specifies whether contents of the destination Workflow Manager (Classic) repository should be combined rather than overwritten with the contents of the input configuration file.</para>
		/// <para>Checked—Combines the contents of the destination Workflow Manager (Classic) database with the contents of the input configuration file.</para>
		/// <para>Unchecked—Replaces the entire contents of the destination Workflow Manager (Classic) database with the contents of the input configuration file.</para>
		/// <para><see cref="InputMergeEnum"/></para>
		/// </param>
		public ImportJobData(object InputFile, object InputMerge)
		{
			this.InputFile = InputFile;
			this.InputMerge = InputMerge;
		}

		/// <summary>
		/// <para>Tool Display Name : Import Job Data</para>
		/// </summary>
		public override string DisplayName => "Import Job Data";

		/// <summary>
		/// <para>Tool Name : ImportJobData</para>
		/// </summary>
		public override string ToolName => "ImportJobData";

		/// <summary>
		/// <para>Tool Excute Name : wmx.ImportJobData</para>
		/// </summary>
		public override string ExcuteName => "wmx.ImportJobData";

		/// <summary>
		/// <para>Toolbox Display Name : Workflow Manager Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Workflow Manager Tools";

		/// <summary>
		/// <para>Toolbox Alise : wmx</para>
		/// </summary>
		public override string ToolboxAlise => "wmx";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputFile, InputMerge, InputDatabasepath, InputRepositoryName, OutputStatus };

		/// <summary>
		/// <para>Input JXL/Acknowledgement</para>
		/// <para>The JXL file that contains the jobs and configuration elements generated using the Export Job Data tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jxl", "xml")]
		public object InputFile { get; set; }

		/// <summary>
		/// <para>Merge</para>
		/// <para>Specifies whether contents of the destination Workflow Manager (Classic) repository should be combined rather than overwritten with the contents of the input configuration file.</para>
		/// <para>Checked—Combines the contents of the destination Workflow Manager (Classic) database with the contents of the input configuration file.</para>
		/// <para>Unchecked—Replaces the entire contents of the destination Workflow Manager (Classic) database with the contents of the input configuration file.</para>
		/// <para><see cref="InputMergeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object InputMerge { get; set; }

		/// <summary>
		/// <para>Input Database Path</para>
		/// <para>The Workflow Manager (Classic) connection file that contains the connection information to the destination repository. If no connection file is specified, the current default Workflow Manager (Classic) database in the project will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jtc")]
		public object InputDatabasepath { get; set; }

		/// <summary>
		/// <para>Repository Name</para>
		/// <para>The name of the repository as specified in the Workflow Manager (Classic) system settings. This name should be unique within all the repositories in your cluster. If the repository name is not specified, the current default Workflow Manager (Classic) repository name will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object InputRepositoryName { get; set; }

		/// <summary>
		/// <para>Status</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object OutputStatus { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Merge</para>
		/// </summary>
		public enum InputMergeEnum 
		{
			/// <summary>
			/// <para>Checked—Combines the contents of the destination Workflow Manager (Classic) database with the contents of the input configuration file.</para>
			/// </summary>
			[GPValue("true")]
			[Description("COMBINE")]
			COMBINE,

			/// <summary>
			/// <para>Unchecked—Replaces the entire contents of the destination Workflow Manager (Classic) database with the contents of the input configuration file.</para>
			/// </summary>
			[GPValue("false")]
			[Description("REPLACE")]
			REPLACE,

		}

#endregion
	}
}
