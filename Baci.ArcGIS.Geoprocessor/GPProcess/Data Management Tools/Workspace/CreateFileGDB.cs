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
	/// <para>Create File Geodatabase</para>
	/// <para>Create File Geodatabase</para>
	/// <para>Creates a file geodatabase in a folder.</para>
	/// </summary>
	public class CreateFileGDB : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutFolderPath">
		/// <para>File Geodatabase Location</para>
		/// <para>The folder where the file geodatabase will be created.</para>
		/// </param>
		/// <param name="OutName">
		/// <para>File GDB Name</para>
		/// <para>The name of the file geodatabase to be created.</para>
		/// </param>
		public CreateFileGDB(object OutFolderPath, object OutName)
		{
			this.OutFolderPath = OutFolderPath;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : Create File Geodatabase</para>
		/// </summary>
		public override string DisplayName() => "Create File Geodatabase";

		/// <summary>
		/// <para>Tool Name : CreateFileGDB</para>
		/// </summary>
		public override string ToolName() => "CreateFileGDB";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateFileGDB</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateFileGDB";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { OutFolderPath, OutName, OutVersion!, OutFileGdb! };

		/// <summary>
		/// <para>File Geodatabase Location</para>
		/// <para>The folder where the file geodatabase will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolderPath { get; set; }

		/// <summary>
		/// <para>File GDB Name</para>
		/// <para>The name of the file geodatabase to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>File Geodatabase Version</para>
		/// <para>The ArcGIS version for the new geodatabase.</para>
		/// <para>Current—Creates a geodatabase compatible with the currently installed version of ArcGIS. This is the default.</para>
		/// <para>10.0—Creates a geodatabase compatible with ArcGIS version 10.</para>
		/// <para>9.3—Creates a geodatabase compatible with ArcGIS version 9.3.</para>
		/// <para>9.2—Creates a geodatabase compatible with ArcGIS version 9.2.</para>
		/// <para><see cref="OutVersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OutVersion { get; set; } = "CURRENT";

		/// <summary>
		/// <para>Output File Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutFileGdb { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateFileGDB SetEnviroment(object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>File Geodatabase Version</para>
		/// </summary>
		public enum OutVersionEnum 
		{
			/// <summary>
			/// <para>Current—Creates a geodatabase compatible with the currently installed version of ArcGIS. This is the default.</para>
			/// </summary>
			[GPValue("CURRENT")]
			[Description("Current")]
			Current,

			/// <summary>
			/// <para>10.0—Creates a geodatabase compatible with ArcGIS version 10.</para>
			/// </summary>
			[GPValue("10.0")]
			[Description("10.0")]
			_100,

			/// <summary>
			/// <para>9.3—Creates a geodatabase compatible with ArcGIS version 9.3.</para>
			/// </summary>
			[GPValue("9.3")]
			[Description("9.3")]
			_93,

			/// <summary>
			/// <para>9.2—Creates a geodatabase compatible with ArcGIS version 9.2.</para>
			/// </summary>
			[GPValue("9.2")]
			[Description("9.2")]
			_92,

		}

#endregion
	}
}
