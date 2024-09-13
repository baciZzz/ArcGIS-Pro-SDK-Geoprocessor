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
	/// <para>Import XML Workspace Document</para>
	/// <para>导入 XML 工作空间文档</para>
	/// <para>将 XML 工作空间文档的内容导入现有地理数据库。</para>
	/// </summary>
	public class ImportXMLWorkspaceDocument : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetGeodatabase">
		/// <para>Target Geodatabase</para>
		/// <para>XML 工作空间文档的内容将被导入的现有地理数据库。</para>
		/// </param>
		/// <param name="InFile">
		/// <para>Import File</para>
		/// <para>包含要导入的地理数据库内容的输入 XML 工作空间文档文件。它可以是 XML 文件 (.xml) 或包含 XML 文件的 ZIP 压缩文件（.zip 或 .z）。</para>
		/// </param>
		public ImportXMLWorkspaceDocument(object TargetGeodatabase, object InFile)
		{
			this.TargetGeodatabase = TargetGeodatabase;
			this.InFile = InFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 导入 XML 工作空间文档</para>
		/// </summary>
		public override string DisplayName() => "导入 XML 工作空间文档";

		/// <summary>
		/// <para>Tool Name : ImportXMLWorkspaceDocument</para>
		/// </summary>
		public override string ToolName() => "ImportXMLWorkspaceDocument";

		/// <summary>
		/// <para>Tool Excute Name : management.ImportXMLWorkspaceDocument</para>
		/// </summary>
		public override string ExcuteName() => "management.ImportXMLWorkspaceDocument";

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
		public override object[] Parameters() => new object[] { TargetGeodatabase, InFile, ImportType, ConfigKeyword, OutGeodatabase };

		/// <summary>
		/// <para>Target Geodatabase</para>
		/// <para>XML 工作空间文档的内容将被导入的现有地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object TargetGeodatabase { get; set; }

		/// <summary>
		/// <para>Import File</para>
		/// <para>包含要导入的地理数据库内容的输入 XML 工作空间文档文件。它可以是 XML 文件 (.xml) 或包含 XML 文件的 ZIP 压缩文件（.zip 或 .z）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml", "zip", "z")]
		public object InFile { get; set; }

		/// <summary>
		/// <para>Import Options</para>
		/// <para>确定是将数据（要素类和表记录，包括几何）和方案都导入，还是仅导入方案。</para>
		/// <para>导入数据和方案—导入数据和方案。这是默认设置。</para>
		/// <para>仅导入方案—仅导入方案。</para>
		/// <para><see cref="ImportTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ImportType { get; set; } = "DATA";

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>要在目标地理数据库为企业级地理数据库或文件地理数据库时应用的地理数据库配置关键字。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Updated Target Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutGeodatabase { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportXMLWorkspaceDocument SetEnviroment(object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Import Options</para>
		/// </summary>
		public enum ImportTypeEnum 
		{
			/// <summary>
			/// <para>导入数据和方案—导入数据和方案。这是默认设置。</para>
			/// </summary>
			[GPValue("DATA")]
			[Description("导入数据和方案")]
			Import_data_and_schema,

			/// <summary>
			/// <para>仅导入方案—仅导入方案。</para>
			/// </summary>
			[GPValue("SCHEMA_ONLY")]
			[Description("仅导入方案")]
			Import_schema_only,

		}

#endregion
	}
}
