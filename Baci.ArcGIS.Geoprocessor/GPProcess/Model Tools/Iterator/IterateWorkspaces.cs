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
	/// <para>迭代工作空间</para>
	/// <para>迭代文件夹中的工作空间。</para>
	/// </summary>
	public class IterateWorkspaces : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFolder">
		/// <para>Folder</para>
		/// <para>存储要迭代的工作空间的文件夹。</para>
		/// </param>
		public IterateWorkspaces(object InFolder)
		{
			this.InFolder = InFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : 迭代工作空间</para>
		/// </summary>
		public override string DisplayName() => "迭代工作空间";

		/// <summary>
		/// <para>Tool Name : IterateWorkspaces</para>
		/// </summary>
		public override string ToolName() => "IterateWorkspaces";

		/// <summary>
		/// <para>Tool Excute Name : mb.IterateWorkspaces</para>
		/// </summary>
		public override string ExcuteName() => "mb.IterateWorkspaces";

		/// <summary>
		/// <para>Toolbox Display Name : Model Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Model Tools";

		/// <summary>
		/// <para>Toolbox Alise : mb</para>
		/// </summary>
		public override string ToolboxAlise() => "mb";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFolder, Wildcard, WorkspaceType, Recursive, Workspace, Name };

		/// <summary>
		/// <para>Folder</para>
		/// <para>存储要迭代的工作空间的文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object InFolder { get; set; }

		/// <summary>
		/// <para>Wildcard</para>
		/// <para>* 与有助于限制结果的字符的组合。星号表示允许使用任意字符。如果未指定通配符，则将返回所有输入。例如，可使用通配符来限制对以某个字符或词语（例如 A*、Ari* 或 Land* 等）开头的输入名称进行迭代。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Wildcard { get; set; }

		/// <summary>
		/// <para>Workspace Type</para>
		/// <para>指定要查找的工作空间类型。</para>
		/// <para>文件地理数据库—将仅输出文件地理数据库。</para>
		/// <para>文件夹—将仅输出文件夹。</para>
		/// <para>企业级地理数据库—将仅输出企业级地理数据库。</para>
		/// <para>BIM—仅输出 BIM 工作空间。</para>
		/// <para><see cref="WorkspaceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object WorkspaceType { get; set; }

		/// <summary>
		/// <para>Recursive</para>
		/// <para>指定是否以递归方式迭代主文件夹中的子文件夹。</para>
		/// <para>选中 - 将迭代所有子文件夹。</para>
		/// <para>未选中 - 不迭代所有子文件夹。 这是默认设置。</para>
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
			/// <para>文件地理数据库—将仅输出文件地理数据库。</para>
			/// </summary>
			[GPValue("FILEGDB")]
			[Description("文件地理数据库")]
			File_geodatabase,

			/// <summary>
			/// <para>文件夹—将仅输出文件夹。</para>
			/// </summary>
			[GPValue("FOLDER")]
			[Description("文件夹")]
			Folder,

			/// <summary>
			/// <para>企业级地理数据库—将仅输出企业级地理数据库。</para>
			/// </summary>
			[GPValue("SDE")]
			[Description("企业级地理数据库")]
			Enterprise_geodatabase,

			/// <summary>
			/// <para>BIM—仅输出 BIM 工作空间。</para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RECURSIVE")]
			RECURSIVE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_RECURSIVE")]
			NOT_RECURSIVE,

		}

#endregion
	}
}
