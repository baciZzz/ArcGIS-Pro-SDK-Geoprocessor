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
	/// <para>Rebuild Indexes</para>
	/// <para>重建索引</para>
	/// <para>在企业级地理数据库中重新构建现有属性或空间索引。还可以在注册参与传统版本化的数据集的状态表、state_lineage 地理数据库系统表以及增量表上重新构建索引。 过期的索引可能会降低查询的性能。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class RebuildIndexes : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Database Connection</para>
		/// <para>到数据库或地理数据库（包含要为其重建索引的数据）的连接（.sde 文件）。</para>
		/// </param>
		/// <param name="IncludeSystem">
		/// <para>Include System Tables</para>
		/// <para>指示是否重新构建状态和状态谱系表的索引。</para>
		/// <para>要激活此选项，您必须以地理数据库管理员身份进行连接。</para>
		/// <para>此选项仅适用于地理数据库。如果连接到了数据库，将禁用此选项。</para>
		/// <para>未选中 - 不会重新构建状态表和状态谱系表的索引。这是默认设置。</para>
		/// <para>选中 - 将重新构建状态表和状态谱系表的索引。</para>
		/// <para><see cref="IncludeSystemEnum"/></para>
		/// </param>
		public RebuildIndexes(object InputDatabase, object IncludeSystem)
		{
			this.InputDatabase = InputDatabase;
			this.IncludeSystem = IncludeSystem;
		}

		/// <summary>
		/// <para>Tool Display Name : 重建索引</para>
		/// </summary>
		public override string DisplayName() => "重建索引";

		/// <summary>
		/// <para>Tool Name : RebuildIndexes</para>
		/// </summary>
		public override string ToolName() => "RebuildIndexes";

		/// <summary>
		/// <para>Tool Excute Name : management.RebuildIndexes</para>
		/// </summary>
		public override string ExcuteName() => "management.RebuildIndexes";

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
		public override object[] Parameters() => new object[] { InputDatabase, IncludeSystem, InDatasets!, DeltaOnly!, OutWorkspace! };

		/// <summary>
		/// <para>Input Database Connection</para>
		/// <para>到数据库或地理数据库（包含要为其重建索引的数据）的连接（.sde 文件）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Include System Tables</para>
		/// <para>指示是否重新构建状态和状态谱系表的索引。</para>
		/// <para>要激活此选项，您必须以地理数据库管理员身份进行连接。</para>
		/// <para>此选项仅适用于地理数据库。如果连接到了数据库，将禁用此选项。</para>
		/// <para>未选中 - 不会重新构建状态表和状态谱系表的索引。这是默认设置。</para>
		/// <para>选中 - 将重新构建状态表和状态谱系表的索引。</para>
		/// <para><see cref="IncludeSystemEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeSystem { get; set; } = "false";

		/// <summary>
		/// <para>Datasets to Rebuild Indexes For</para>
		/// <para>要重新构建索引的数据集的名称。仅显示已连接用户所有的数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? InDatasets { get; set; }

		/// <summary>
		/// <para>Rebuild Delta Tables Only</para>
		/// <para>指示是否将只重新构建选定数据集的增量表的索引。如果未在输入数据集列表中选择任何数据集，则此选项将不可用。</para>
		/// <para>此选项仅适用于地理数据库。如果连接到了数据库，将禁用此选项。</para>
		/// <para>选中 - 将只对选定数据集的增量表重新构建索引。选定数据集的业务表不常更新且增量表中编辑量较大的情况下可使用此选项。这是默认设置。</para>
		/// <para>未选中 - 将针对选定数据集的所有索引重新构建索引。包括空间索引以及用户创建的属性索引和数据集的所有地理数据库维护索引。</para>
		/// <para><see cref="DeltaOnlyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DeltaOnly { get; set; } = "true";

		/// <summary>
		/// <para>Updated Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RebuildIndexes SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Include System Tables</para>
		/// </summary>
		public enum IncludeSystemEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SYSTEM")]
			SYSTEM,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SYSTEM")]
			NO_SYSTEM,

		}

		/// <summary>
		/// <para>Rebuild Delta Tables Only</para>
		/// </summary>
		public enum DeltaOnlyEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ONLY_DELTAS")]
			ONLY_DELTAS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("ALL")]
			ALL,

		}

#endregion
	}
}
