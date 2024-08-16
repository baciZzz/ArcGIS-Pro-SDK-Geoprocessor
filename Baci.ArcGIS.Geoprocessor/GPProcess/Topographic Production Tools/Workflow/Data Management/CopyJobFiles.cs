using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Copy Job Files</para>
	/// <para>Copies Workflow Manager (Classic) job files to and from a local machine and a shared directory for processing.</para>
	/// </summary>
	public class CopyJobFiles : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="JobId">
		/// <para>Job ID</para>
		/// <para>The Job ID of the Workflow Manager (Classic) job that will be updated.</para>
		/// </param>
		/// <param name="SourcePath">
		/// <para>Source Path</para>
		/// <para>The path to the folder containing the files to be copied.</para>
		/// </param>
		/// <param name="TargetPath">
		/// <para>Target Path</para>
		/// <para>The path to the location where the files will be copied.</para>
		/// </param>
		public CopyJobFiles(object JobId, object SourcePath, object TargetPath)
		{
			this.JobId = JobId;
			this.SourcePath = SourcePath;
			this.TargetPath = TargetPath;
		}

		/// <summary>
		/// <para>Tool Display Name : Copy Job Files</para>
		/// </summary>
		public override string DisplayName => "Copy Job Files";

		/// <summary>
		/// <para>Tool Name : CopyJobFiles</para>
		/// </summary>
		public override string ToolName => "CopyJobFiles";

		/// <summary>
		/// <para>Tool Excute Name : topographic.CopyJobFiles</para>
		/// </summary>
		public override string ExcuteName => "topographic.CopyJobFiles";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { JobId, SourcePath, TargetPath, ArchiveSource, DeleteSource, CreateJobFolder, DatabasePath, UpdatedJobId };

		/// <summary>
		/// <para>Job ID</para>
		/// <para>The Job ID of the Workflow Manager (Classic) job that will be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLong()]
		public object JobId { get; set; }

		/// <summary>
		/// <para>Source Path</para>
		/// <para>The path to the folder containing the files to be copied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object SourcePath { get; set; }

		/// <summary>
		/// <para>Target Path</para>
		/// <para>The path to the location where the files will be copied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object TargetPath { get; set; }

		/// <summary>
		/// <para>Archive Source Files</para>
		/// <para>Specifies whether the files in the source path will be zipped before copying to the target location.</para>
		/// <para>Checked—A .zip file with the contents of the source directory will be created and copied to the target location.</para>
		/// <para>Unchecked—The contents of the source directory will be copied directly to the target location. This is the default.</para>
		/// <para><see cref="ArchiveSourceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ArchiveSource { get; set; }

		/// <summary>
		/// <para>Delete Source Files</para>
		/// <para>Specifies whether the files in the source path will be deleted after the files are copied to the target location.</para>
		/// <para>Checked—The source directory and all its contents will be deleted after the files are copied.</para>
		/// <para>Unchecked—The source directory will not be deleted after the files are copied. This is the default.</para>
		/// <para><see cref="DeleteSourceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object DeleteSource { get; set; }

		/// <summary>
		/// <para>Create Job Folder</para>
		/// <para>Specifies whether a folder will be created in the target path for containing the copied files.</para>
		/// <para>Checked—A folder will be created in the target path with the name of the chosen job. Files are copied from the source path to this new folder.</para>
		/// <para>Unchecked—A folder will not be created, and files from the source path will be copied directly to the target path. This is the default.</para>
		/// <para><see cref="CreateJobFolderEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CreateJobFolder { get; set; }

		/// <summary>
		/// <para>Input Database Path</para>
		/// <para>The Workflow Manager (Classic) database connection file (.jtc) that contains the job information. If no connection file is specified, the current default Workflow Manager (Classic) database will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("jtc")]
		public object DatabasePath { get; set; }

		/// <summary>
		/// <para>Updated Job ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object UpdatedJobId { get; set; } = "-1";

		#region InnerClass

		/// <summary>
		/// <para>Archive Source Files</para>
		/// </summary>
		public enum ArchiveSourceEnum 
		{
			/// <summary>
			/// <para>Checked—A .zip file with the contents of the source directory will be created and copied to the target location.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ARCHIVE")]
			ARCHIVE,

			/// <summary>
			/// <para>Unchecked—The contents of the source directory will be copied directly to the target location. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ARCHIVE")]
			NO_ARCHIVE,

		}

		/// <summary>
		/// <para>Delete Source Files</para>
		/// </summary>
		public enum DeleteSourceEnum 
		{
			/// <summary>
			/// <para>Checked—The source directory and all its contents will be deleted after the files are copied.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_SOURCE")]
			DELETE_SOURCE,

			/// <summary>
			/// <para>Unchecked—The source directory will not be deleted after the files are copied. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DELETE_SOURCE")]
			NO_DELETE_SOURCE,

		}

		/// <summary>
		/// <para>Create Job Folder</para>
		/// </summary>
		public enum CreateJobFolderEnum 
		{
			/// <summary>
			/// <para>Checked—A folder will be created in the target path with the name of the chosen job. Files are copied from the source path to this new folder.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_JOB_FOLDER")]
			CREATE_JOB_FOLDER,

			/// <summary>
			/// <para>Unchecked—A folder will not be created, and files from the source path will be copied directly to the target path. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CREATE_JOB_FOLDER")]
			NO_CREATE_JOB_FOLDER,

		}

#endregion
	}
}
