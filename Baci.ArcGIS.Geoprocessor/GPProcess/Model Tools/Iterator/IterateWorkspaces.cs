using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ModelTools
{
	/// <summary>
	/// <para>Iterate Workspaces</para>
	/// <para>Iterates over workspaces in a folder.</para>
	/// </summary>
	public class IterateWorkspaces : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFolder">
		/// <para>Folder</para>
		/// <para>The folder which stores the workspace to iterate.</para>
		/// </param>
		public IterateWorkspaces(object InFolder)
		{
			this.InFolder = InFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : Iterate Workspaces</para>
		/// </summary>
		public override string DisplayName => "Iterate Workspaces";

		/// <summary>
		/// <para>Tool Name : IterateWorkspaces</para>
		/// </summary>
		public override string ToolName => "IterateWorkspaces";

		/// <summary>
		/// <para>Tool Excute Name : mb.IterateWorkspaces</para>
		/// </summary>
		public override string ExcuteName => "mb.IterateWorkspaces";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFolder, Wildcard, WorkspaceType, Recursive, Workspace, Name };

		/// <summary>
		/// <para>Folder</para>
		/// <para>The folder which stores the workspace to iterate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object InFolder { get; set; }

		/// <summary>
		/// <para>Wildcard</para>
		/// <para>A combination of * and characters that help to limit the results. The asterisk is the same as saying ALL. If no wildcard is specified, all inputs will be returned. For example, it can be used to restrict Iteration over input names starting with a certain character or word (for example, A* or Ari* or Land* and so on).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Wildcard { get; set; }

		/// <summary>
		/// <para>Workspace Type</para>
		/// <para>Specifies the workspace type to find.</para>
		/// <para>File geodatabase—Only file geodatabases will be the output.</para>
		/// <para>Folder—Only folders will be the output.</para>
		/// <para>Enterprise geodatabase—Only enterprise geodatabases will be the output.</para>
		/// <para>BIM—Only BIM workspaces will be the output.</para>
		/// <para><see cref="WorkspaceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object WorkspaceType { get; set; }

		/// <summary>
		/// <para>Recursive</para>
		/// <para>Specifies if subfolders in the main folder will be iterated through recursively.</para>
		/// <para>Checked—Will iterate through all subfolders.</para>
		/// <para>Unchecked—Will not iterate through all subfolders. This is the default.</para>
		/// <para><see cref="RecursiveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Recursive { get; set; } = "false";

		/// <summary>
		/// <para>Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object Workspace { get; set; }

		/// <summary>
		/// <para>Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object Name { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Workspace Type</para>
		/// </summary>
		public enum WorkspaceTypeEnum 
		{
			/// <summary>
			/// <para>File geodatabase—Only file geodatabases will be the output.</para>
			/// </summary>
			[GPValue("FILEGDB")]
			[Description("File geodatabase")]
			File_geodatabase,

			/// <summary>
			/// <para>Folder—Only folders will be the output.</para>
			/// </summary>
			[GPValue("FOLDER")]
			[Description("Folder")]
			Folder,

			/// <summary>
			/// <para>Enterprise geodatabase—Only enterprise geodatabases will be the output.</para>
			/// </summary>
			[GPValue("SDE")]
			[Description("Enterprise geodatabase")]
			Enterprise_geodatabase,

			/// <summary>
			/// <para>BIM—Only BIM workspaces will be the output.</para>
			/// </summary>
			[GPValue("BIM")]
			[Description("BIM")]
			BIM,

		}

		/// <summary>
		/// <para>Recursive</para>
		/// </summary>
		public enum RecursiveEnum 
		{
			/// <summary>
			/// <para>Checked—Will iterate through all subfolders.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RECURSIVE")]
			RECURSIVE,

			/// <summary>
			/// <para>Unchecked—Will not iterate through all subfolders. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_RECURSIVE")]
			NOT_RECURSIVE,

		}

#endregion
	}
}
