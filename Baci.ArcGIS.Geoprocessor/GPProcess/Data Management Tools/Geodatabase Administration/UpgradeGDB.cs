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
	/// <para>Upgrade Geodatabase</para>
	/// <para>升级地理数据库</para>
	/// <para>将地理数据库升级至最新的 ArcGIS 版本以使用新功能。</para>
	/// </summary>
	public class UpgradeGDB : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputWorkspace">
		/// <para>Input Geodatabase</para>
		/// <para>要进行升级的地理数据库。 当升级企业级地理数据库时，指定以地理数据库管理员身份连接到地理数据库的数据库连接文件 (.sde)。</para>
		/// </param>
		/// <param name="InputPrerequisiteCheck">
		/// <para>Perform Pre-Requisite Check</para>
		/// <para>指定是否会在升级地理数据库之前执行先决条件检查。</para>
		/// <para>未选中 - 不会执行先决条件检查。 这是默认设置。</para>
		/// <para>选中 - 将在升级地理数据库之前执行先决条件检查。</para>
		/// <para><see cref="InputPrerequisiteCheckEnum"/></para>
		/// </param>
		/// <param name="InputUpgradegdbCheck">
		/// <para>Upgrade Geodatabase</para>
		/// <para>指定是否会将输入地理数据库升级以与您正在运行工具所基于的 ArcGIS 客户端版本相匹配。</para>
		/// <para>未选中 - 不会升级地理数据库。 这是默认设置。</para>
		/// <para>选中 - 将升级地理数据库。</para>
		/// <para><see cref="InputUpgradegdbCheckEnum"/></para>
		/// </param>
		public UpgradeGDB(object InputWorkspace, object InputPrerequisiteCheck, object InputUpgradegdbCheck)
		{
			this.InputWorkspace = InputWorkspace;
			this.InputPrerequisiteCheck = InputPrerequisiteCheck;
			this.InputUpgradegdbCheck = InputUpgradegdbCheck;
		}

		/// <summary>
		/// <para>Tool Display Name : 升级地理数据库</para>
		/// </summary>
		public override string DisplayName() => "升级地理数据库";

		/// <summary>
		/// <para>Tool Name : UpgradeGDB</para>
		/// </summary>
		public override string ToolName() => "UpgradeGDB";

		/// <summary>
		/// <para>Tool Excute Name : management.UpgradeGDB</para>
		/// </summary>
		public override string ExcuteName() => "management.UpgradeGDB";

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
		public override object[] Parameters() => new object[] { InputWorkspace, InputPrerequisiteCheck, InputUpgradegdbCheck, OutWorkspace! };

		/// <summary>
		/// <para>Input Geodatabase</para>
		/// <para>要进行升级的地理数据库。 当升级企业级地理数据库时，指定以地理数据库管理员身份连接到地理数据库的数据库连接文件 (.sde)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object InputWorkspace { get; set; }

		/// <summary>
		/// <para>Perform Pre-Requisite Check</para>
		/// <para>指定是否会在升级地理数据库之前执行先决条件检查。</para>
		/// <para>未选中 - 不会执行先决条件检查。 这是默认设置。</para>
		/// <para>选中 - 将在升级地理数据库之前执行先决条件检查。</para>
		/// <para><see cref="InputPrerequisiteCheckEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object InputPrerequisiteCheck { get; set; } = "true";

		/// <summary>
		/// <para>Upgrade Geodatabase</para>
		/// <para>指定是否会将输入地理数据库升级以与您正在运行工具所基于的 ArcGIS 客户端版本相匹配。</para>
		/// <para>未选中 - 不会升级地理数据库。 这是默认设置。</para>
		/// <para>选中 - 将升级地理数据库。</para>
		/// <para><see cref="InputUpgradegdbCheckEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object InputUpgradegdbCheck { get; set; } = "true";

		/// <summary>
		/// <para>Updated Input Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public UpgradeGDB SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Perform Pre-Requisite Check</para>
		/// </summary>
		public enum InputPrerequisiteCheckEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PREREQUISITE_CHECK")]
			PREREQUISITE_CHECK,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_PREREQUISITE_CHECK")]
			NO_PREREQUISITE_CHECK,

		}

		/// <summary>
		/// <para>Upgrade Geodatabase</para>
		/// </summary>
		public enum InputUpgradegdbCheckEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPGRADE")]
			UPGRADE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_UPGRADE")]
			NO_UPGRADE,

		}

#endregion
	}
}
