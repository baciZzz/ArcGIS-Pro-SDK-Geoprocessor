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
	/// <para>Consolidate Project</para>
	/// <para>合并工程</para>
	/// <para>将工程（.aprx 文件）与引用的地图和数据合并到一个指定的输出文件夹。</para>
	/// </summary>
	public class ConsolidateProject : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InProject">
		/// <para>Input Project</para>
		/// <para>要合并的工程（.aprx 文件）。</para>
		/// </param>
		/// <param name="OutputFolder">
		/// <para>Output Folder</para>
		/// <para>此输出文件夹将包含合并的工程和数据。如果指定的文件夹不存在，将创建一个新文件夹。</para>
		/// </param>
		public ConsolidateProject(object InProject, object OutputFolder)
		{
			this.InProject = InProject;
			this.OutputFolder = OutputFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : 合并工程</para>
		/// </summary>
		public override string DisplayName() => "合并工程";

		/// <summary>
		/// <para>Tool Name : ConsolidateProject</para>
		/// </summary>
		public override string ToolName() => "ConsolidateProject";

		/// <summary>
		/// <para>Tool Excute Name : management.ConsolidateProject</para>
		/// </summary>
		public override string ExcuteName() => "management.ConsolidateProject";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InProject, OutputFolder, SharingInternal, Extent, ApplyExtentToEnterpriseGeo, PackageAsTemplate, PreserveSqlite, Version, SelectRelatedRows };

		/// <summary>
		/// <para>Input Project</para>
		/// <para>要合并的工程（.aprx 文件）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("aprx")]
		public object InProject { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>此输出文件夹将包含合并的工程和数据。如果指定的文件夹不存在，将创建一个新文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutputFolder { get; set; }

		/// <summary>
		/// <para>Share outside of organization</para>
		/// <para>指定是将工程和所有数据合并到单个文件夹（在组织外共享）还是引用这些工程和数据（在组织内共享）。通过企业级地理数据库或 UNC 文件系统引用的数据路径可在内部共享。如果您的工程并非通过此类数据路径构建，则数据将合并到工程包中。如果工程通过本地路径（例如 c:\gisdata\landrecords.gdb\）引用数据和地图，则将对这些数据和地图进行合并和打包（不考虑该参数设置）。</para>
		/// <para>未选中 - 工程及其数据源将不会合并到输出文件夹。这是默认设置。该参数适用于企业级地理数据库数据源，其中包括通过 UNC 路径引用的企业级地理数据库和文件夹。</para>
		/// <para>选中 - 工程及其数据源将被复制和保留（如有可能）。</para>
		/// <para><see cref="SharingInternalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SharingInternal { get; set; } = "false";

		/// <summary>
		/// <para>Extent</para>
		/// <para>指定用于选择或裁剪要素的范围。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>输入的并集 - 该范围将基于所有输入的最大范围。</para>
		/// <para>输入的交集 - 该范围将基于所有输入共用的最小区域。</para>
		/// <para>当前显示范围 - 该范围与可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object Extent { get; set; }

		/// <summary>
		/// <para>Apply Extent only to enterprise geodatabase layers</para>
		/// <para>指定将范围参数应用到所有图层，还是仅应用到企业级地理数据库图层。</para>
		/// <para>未选中 - 范围将应用到所有图层。这是默认设置。</para>
		/// <para>选中 - 范围将仅应用到企业级地理数据库图层。</para>
		/// <para><see cref="ApplyExtentToEnterpriseGeoEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ApplyExtentToEnterpriseGeo { get; set; } = "false";

		/// <summary>
		/// <para>Consolidate as template</para>
		/// <para>指定将工程作为模板工程还是规则工程进行合并。模板可以包含地图、布局、数据库和服务器的连接等。通过工程模板，您可以标准化一系列地图以在工程中使用，并确保所有人均可在他们的地图中立即使用正确的图层。</para>
		/// <para>未选中 - 该工程将被作为工程合并到文件夹中。这是默认设置。</para>
		/// <para>选中 - 该工程将被作为模板合并到文件夹中。</para>
		/// <para><see cref="PackageAsTemplateEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object PackageAsTemplate { get; set; } = "false";

		/// <summary>
		/// <para>Preserve SQLite Geodatabase</para>
		/// <para>用于指定是保留 SQLite 地理数据库还是将其转换为文件地理数据库。该参数仅适用于 .geodatabase 文件，主要用于 ArcGIS Runtime 应用程序中的离线工作流。文件扩展名为 .sqlite 或 .gpkg 的 SQLite 数据库将转换为文件地理数据库。</para>
		/// <para>未选中 - SQLite 地理数据库将被转换为文件地理数据库。这是默认设置。</para>
		/// <para>选中 - 将保留 SQLite 地理数据库。</para>
		/// <para><see cref="PreserveSqliteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object PreserveSqlite { get; set; } = "false";

		/// <summary>
		/// <para>Version</para>
		/// <para>指定合并工程的另存 ArcGIS Pro 版本。保存到较早版本可以确保工具向后兼容。如果尝试将工具箱合并到较早版本，而工具箱中包含仅在较新版本中可用的功能，则会发生错误。您必须移除与较早版本不兼容的工具或指定兼容的版本。</para>
		/// <para>当前版本— 合并的文件夹将包含与当前版本兼容的地理数据库和地图。</para>
		/// <para>2.1—合并的文件夹将包含与 2.1 版本兼容的地理数据库和地图。</para>
		/// <para>2.2— 合并的文件夹将包含与 2.2 版本兼容的地理数据库和地图。</para>
		/// <para>2.3—合并的文件夹将包含与 2.3 版本兼容的地理数据库和地图。</para>
		/// <para>2.4—合并的文件夹将包含与 2.4 版本兼容的地理数据库和地图。</para>
		/// <para>2.5—合并的文件夹将包含与 2.5 版本兼容的地理数据库和地图。</para>
		/// <para>2.6—合并的文件夹将包含与 2.6 版本兼容的地理数据库和地图。</para>
		/// <para><see cref="VersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Version { get; set; } = "CURRENT";

		/// <summary>
		/// <para>Keep only the rows which are related to features within the extent</para>
		/// <para>指定是否将指定的范围应用至相关数据源。</para>
		/// <para>未选中 - 相关的数据源将全部合并。这是默认设置。</para>
		/// <para>选中 - 仅合并指定范围内与记录对应的相关数据。</para>
		/// <para><see cref="SelectRelatedRowsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SelectRelatedRows { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConsolidateProject SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Share outside of organization</para>
		/// </summary>
		public enum SharingInternalEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EXTERNAL")]
			EXTERNAL,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("INTERNAL")]
			INTERNAL,

		}

		/// <summary>
		/// <para>Apply Extent only to enterprise geodatabase layers</para>
		/// </summary>
		public enum ApplyExtentToEnterpriseGeoEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ENTERPRISE_ONLY")]
			ENTERPRISE_ONLY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ALL")]
			ALL,

		}

		/// <summary>
		/// <para>Consolidate as template</para>
		/// </summary>
		public enum PackageAsTemplateEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PROJECT_TEMPLATE")]
			PROJECT_TEMPLATE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("PROJECT_PACKAGE")]
			PROJECT_PACKAGE,

		}

		/// <summary>
		/// <para>Preserve SQLite Geodatabase</para>
		/// </summary>
		public enum PreserveSqliteEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESERVE_SQLITE")]
			PRESERVE_SQLITE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("CONVERT_SQLITE")]
			CONVERT_SQLITE,

		}

		/// <summary>
		/// <para>Version</para>
		/// </summary>
		public enum VersionEnum 
		{
			/// <summary>
			/// <para>当前版本— 合并的文件夹将包含与当前版本兼容的地理数据库和地图。</para>
			/// </summary>
			[GPValue("CURRENT")]
			[Description("当前版本")]
			Current_version,

			/// <summary>
			/// <para>2.1—合并的文件夹将包含与 2.1 版本兼容的地理数据库和地图。</para>
			/// </summary>
			[GPValue("2.1")]
			[Description("2.1")]
			_21,

			/// <summary>
			/// <para>2.2— 合并的文件夹将包含与 2.2 版本兼容的地理数据库和地图。</para>
			/// </summary>
			[GPValue("2.2")]
			[Description("2.2")]
			_22,

			/// <summary>
			/// <para>2.3—合并的文件夹将包含与 2.3 版本兼容的地理数据库和地图。</para>
			/// </summary>
			[GPValue("2.3")]
			[Description("2.3")]
			_23,

			/// <summary>
			/// <para>2.4—合并的文件夹将包含与 2.4 版本兼容的地理数据库和地图。</para>
			/// </summary>
			[GPValue("2.4")]
			[Description("2.4")]
			_24,

			/// <summary>
			/// <para>2.5—合并的文件夹将包含与 2.5 版本兼容的地理数据库和地图。</para>
			/// </summary>
			[GPValue("2.5")]
			[Description("2.5")]
			_25,

			/// <summary>
			/// <para>2.6—合并的文件夹将包含与 2.6 版本兼容的地理数据库和地图。</para>
			/// </summary>
			[GPValue("2.6")]
			[Description("2.6")]
			_26,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("2.7")]
			[Description("2.7")]
			_27,

		}

		/// <summary>
		/// <para>Keep only the rows which are related to features within the extent</para>
		/// </summary>
		public enum SelectRelatedRowsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_ONLY_RELATED_ROWS")]
			KEEP_ONLY_RELATED_ROWS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_ALL_RELATED_ROWS")]
			KEEP_ALL_RELATED_ROWS,

		}

#endregion
	}
}
