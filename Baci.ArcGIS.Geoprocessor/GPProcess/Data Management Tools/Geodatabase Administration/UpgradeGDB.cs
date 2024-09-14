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
	/// <para>Upgrade Geodatabase</para>
	/// <para>Upgrades a geodatabase to the latest ArcGIS release to take advantage of new functionality.</para>
	/// </summary>
	public class UpgradeGDB : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputWorkspace">
		/// <para>Input Geodatabase</para>
		/// <para>The geodatabase to upgrade. When upgrading an enterprise geodatabase, specify a database connection file (.sde) that connects to the geodatabase as the geodatabase administrator.</para>
		/// </param>
		/// <param name="InputPrerequisiteCheck">
		/// <para>Perform Pre-Requisite Check</para>
		/// <para>Specifies whether the prerequisite check will be run before upgrading the geodatabase.</para>
		/// <para>Unchecked—The prerequisite check will not be run. This is the default.</para>
		/// <para>Checked—The prerequisite check will be run before upgrading the geodatabase.</para>
		/// <para><see cref="InputPrerequisiteCheckEnum"/></para>
		/// </param>
		/// <param name="InputUpgradegdbCheck">
		/// <para>Upgrade Geodatabase</para>
		/// <para>Specifies whether the input geodatabase will be upgraded to match the release of the ArcGIS client from which you are running the tool.</para>
		/// <para>Unchecked—The geodatabase will not be upgraded. This is the default.</para>
		/// <para>Checked—The geodatabase will be upgraded.</para>
		/// <para><see cref="InputUpgradegdbCheckEnum"/></para>
		/// </param>
		public UpgradeGDB(object InputWorkspace, object InputPrerequisiteCheck, object InputUpgradegdbCheck)
		{
			this.InputWorkspace = InputWorkspace;
			this.InputPrerequisiteCheck = InputPrerequisiteCheck;
			this.InputUpgradegdbCheck = InputUpgradegdbCheck;
		}

		/// <summary>
		/// <para>Tool Display Name : Upgrade Geodatabase</para>
		/// </summary>
		public override string DisplayName() => "Upgrade Geodatabase";

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
		public override object[] Parameters() => new object[] { InputWorkspace, InputPrerequisiteCheck, InputUpgradegdbCheck, OutWorkspace };

		/// <summary>
		/// <para>Input Geodatabase</para>
		/// <para>The geodatabase to upgrade. When upgrading an enterprise geodatabase, specify a database connection file (.sde) that connects to the geodatabase as the geodatabase administrator.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object InputWorkspace { get; set; }

		/// <summary>
		/// <para>Perform Pre-Requisite Check</para>
		/// <para>Specifies whether the prerequisite check will be run before upgrading the geodatabase.</para>
		/// <para>Unchecked—The prerequisite check will not be run. This is the default.</para>
		/// <para>Checked—The prerequisite check will be run before upgrading the geodatabase.</para>
		/// <para><see cref="InputPrerequisiteCheckEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object InputPrerequisiteCheck { get; set; } = "true";

		/// <summary>
		/// <para>Upgrade Geodatabase</para>
		/// <para>Specifies whether the input geodatabase will be upgraded to match the release of the ArcGIS client from which you are running the tool.</para>
		/// <para>Unchecked—The geodatabase will not be upgraded. This is the default.</para>
		/// <para>Checked—The geodatabase will be upgraded.</para>
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
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public UpgradeGDB SetEnviroment(object workspace = null)
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
			/// <para>Checked—The prerequisite check will be run before upgrading the geodatabase.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PREREQUISITE_CHECK")]
			PREREQUISITE_CHECK,

			/// <summary>
			/// <para>Unchecked—The prerequisite check will not be run. This is the default.</para>
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
			/// <para>Checked—The geodatabase will be upgraded.</para>
			/// </summary>
			[GPValue("true")]
			[Description("UPGRADE")]
			UPGRADE,

			/// <summary>
			/// <para>Unchecked—The geodatabase will not be upgraded. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_UPGRADE")]
			NO_UPGRADE,

		}

#endregion
	}
}
