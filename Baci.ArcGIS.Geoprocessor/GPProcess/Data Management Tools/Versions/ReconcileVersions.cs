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
	/// <para>Reconcile Versions</para>
	/// <para>协调版本</para>
	/// <para>根据目标版本协调一个或多个版本。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ReconcileVersions : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputDatabase">
		/// <para>Input Workspace</para>
		/// <para>包含要协调的版本的企业级地理数据库。</para>
		/// <para>对于分支版本化，这将为要素服务 URL（即 https://mysite.mydomain/server/rest/services/ElectricNetwork/FeatureServer）或要素图层门户项目。</para>
		/// </param>
		/// <param name="ReconcileMode">
		/// <para>Reconcile Mode</para>
		/// <para>指定执行工具时要协调的版本。</para>
		/// <para>如果输入为分支工作空间，则此参数的唯一有效选择是协调所有版本。</para>
		/// <para>协调所有版本—编辑版本将与目标版本进行协调。 这是默认设置。</para>
		/// <para>仅协调分块版本—协调阻止目标版本压缩的版本。 此选项使用建议的协调顺序。</para>
		/// <para><see cref="ReconcileModeEnum"/></para>
		/// </param>
		public ReconcileVersions(object InputDatabase, object ReconcileMode)
		{
			this.InputDatabase = InputDatabase;
			this.ReconcileMode = ReconcileMode;
		}

		/// <summary>
		/// <para>Tool Display Name : 协调版本</para>
		/// </summary>
		public override string DisplayName() => "协调版本";

		/// <summary>
		/// <para>Tool Name : ReconcileVersions</para>
		/// </summary>
		public override string ToolName() => "ReconcileVersions";

		/// <summary>
		/// <para>Tool Excute Name : management.ReconcileVersions</para>
		/// </summary>
		public override string ExcuteName() => "management.ReconcileVersions";

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
		public override object[] Parameters() => new object[] { InputDatabase, ReconcileMode, TargetVersion!, EditVersions!, AcquireLocks!, AbortIfConflicts!, ConflictDefinition!, ConflictResolution!, WithPost!, WithDelete!, OutLog!, OutWorkspace!, ProceedIfConflictsNotReviewed!, ReconcileCheckoutVersions! };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>包含要协调的版本的企业级地理数据库。</para>
		/// <para>对于分支版本化，这将为要素服务 URL（即 https://mysite.mydomain/server/rest/services/ElectricNetwork/FeatureServer）或要素图层门户项目。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database", "Feature Service")]
		public object InputDatabase { get; set; }

		/// <summary>
		/// <para>Reconcile Mode</para>
		/// <para>指定执行工具时要协调的版本。</para>
		/// <para>如果输入为分支工作空间，则此参数的唯一有效选择是协调所有版本。</para>
		/// <para>协调所有版本—编辑版本将与目标版本进行协调。 这是默认设置。</para>
		/// <para>仅协调分块版本—协调阻止目标版本压缩的版本。 此选项使用建议的协调顺序。</para>
		/// <para><see cref="ReconcileModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ReconcileMode { get; set; } = "ALL_VERSIONS";

		/// <summary>
		/// <para>Target Version</para>
		/// <para>编辑版本的任何直系版本的名称，例如父版本或默认版本。</para>
		/// <para>它通常包含您希望在编辑版本中包括的其他版本的编辑内容。</para>
		/// <para>如果输入工作空间为分支版本服务，则此参数的唯一有效选择是协调默认版本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? TargetVersion { get; set; }

		/// <summary>
		/// <para>Edit Versions</para>
		/// <para>要与所选目标版本进行协调的版本或编辑版本的名称。</para>
		/// <para>仅显示所选目标版本的直系版本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? EditVersions { get; set; }

		/// <summary>
		/// <para>Acquire Locks</para>
		/// <para>指定是否将获取要素锁定。</para>
		/// <para>如果输入为分支工作空间，则协调过程中无法获取锁定。</para>
		/// <para>选中 - 协调过程中将获取锁定。 要提交编辑时可使用此选项。 确保在协调和提交操作之间的时间内没有修改目标版本。 这是默认设置。</para>
		/// <para>未选中 - 协调过程中将不获取任何锁定。 此时允许多个用户平行协调。 不将编辑版本提交到目标版本时可使用此选项，因为在协调和提交操作之间的时间内可能修改了目标版本。</para>
		/// <para><see cref="AcquireLocksEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AcquireLocks { get; set; } = "true";

		/// <summary>
		/// <para>Abort if Conflicts Detected</para>
		/// <para>如果协调过程中在目标版本与编辑版本之间发现冲突，则指定是否将中止协调过程。</para>
		/// <para>选中 - 如果发现冲突，将中止协调。</para>
		/// <para>未选中 - 如果发现冲突，将不会中止协调。 这是默认设置。</para>
		/// <para><see cref="AbortIfConflictsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AbortIfConflicts { get; set; } = "false";

		/// <summary>
		/// <para>Conflict Definition</para>
		/// <para>指定是按对象（行）还是按属性（列）定义发生冲突所需的条件。</para>
		/// <para>按对象定义的冲突（按行）—将按对象定义冲突。 协调期间父版本和子版本中的相同行或要素发生任何更改。 这是默认设置。</para>
		/// <para>按属性定义的冲突（按列）—将按属性定义冲突。 协调期间只有父版本和子版本中的相同行或要素的同一属性（列）发生的更改会被标记为冲突。 协调期间不同属性所发生的更改不会被视为冲突。</para>
		/// <para><see cref="ConflictDefinitionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ConflictDefinition { get; set; } = "BY_OBJECT";

		/// <summary>
		/// <para>Conflict Resolution</para>
		/// <para>指定检测到冲突时将使用的解决方案。</para>
		/// <para>如果输入为分支工作空间，则默认支持编辑版本。</para>
		/// <para>优先使用目标版本解决冲突—将优先使用目标版本解决所有冲突。 这是传统版本化的默认值。</para>
		/// <para>优先使用编辑版本解决冲突—将优先使用编辑版本解决所有冲突。 这是分支版本化的默认值。</para>
		/// <para><see cref="ConflictResolutionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ConflictResolution { get; set; } = "FAVOR_TARGET_VERSION";

		/// <summary>
		/// <para>Post Versions After Reconcile</para>
		/// <para>指定是否将当前编辑会话提交到已协调的目标版本。</para>
		/// <para>选中 - 协调后将当前编辑版本提交到目标版本。</para>
		/// <para>未选中 - 协调后不将当前编辑版本提交到目标版本。 这是默认设置。</para>
		/// <para><see cref="WithPostEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? WithPost { get; set; } = "false";

		/// <summary>
		/// <para>Delete Versions After Post</para>
		/// <para>指定提交后是否删除已协调的编辑版本。 此参数仅适用于选中协调后提交版本参数的情况。</para>
		/// <para>选中 - 协调后的当前编辑版本在提交到目标版本后将被删除。</para>
		/// <para>未选中 - 不会删除协调后的当前编辑版本。 这是默认设置。</para>
		/// <para><see cref="WithDeleteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? WithDelete { get; set; } = "false";

		/// <summary>
		/// <para>Reconcile Versions Log</para>
		/// <para>写入日志文件的名称和位置。 日志文件是包含地理处理消息内容的 ASCII 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object? OutLog { get; set; }

		/// <summary>
		/// <para>Updated Input Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutWorkspace { get; set; }

		/// <summary>
		/// <para>Proceed if unreviewed conflicts are detected</para>
		/// <para>指定如果在协调过程开始之前检测到现有的未审查冲突，是否继续进行协调。 如果继续，则执行工具时，之前会话中的现有冲突将会丢失。 此参数仅适用于分支版本化。</para>
		/// <para>选中 - 如果检测到现有的未审查冲突，将继续进行协调。 这是默认设置。</para>
		/// <para>未选中 - 如果检测到现有的未审查冲突，不会继续进行协调。</para>
		/// <para><see cref="ProceedIfConflictsNotReviewedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ProceedIfConflictsNotReviewed { get; set; } = "true";

		/// <summary>
		/// <para>Reconcile checkout replica versions</para>
		/// <para>指定协调过程是否将包括检出复本版本。 如果要将检出复本创建为地理数据库复制工作流的一部分，则系统会在地理数据库中创建相关联的版本。 您可通过此选项在要协调的版本列表中包括或移除这些类型的版本。 此参数不适用于分支版本化。</para>
		/// <para>选中 - 协调过程将包括检出复本版本。 这是默认设置。</para>
		/// <para>未选中 - 协调过程将不包括检出复本版本。</para>
		/// <para><see cref="ReconcileCheckoutVersionsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ReconcileCheckoutVersions { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ReconcileVersions SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Reconcile Mode</para>
		/// </summary>
		public enum ReconcileModeEnum 
		{
			/// <summary>
			/// <para>协调所有版本—编辑版本将与目标版本进行协调。 这是默认设置。</para>
			/// </summary>
			[GPValue("ALL_VERSIONS")]
			[Description("协调所有版本")]
			Reconcile_all_versions,

			/// <summary>
			/// <para>仅协调分块版本—协调阻止目标版本压缩的版本。 此选项使用建议的协调顺序。</para>
			/// </summary>
			[GPValue("BLOCKING_VERSIONS")]
			[Description("仅协调分块版本")]
			Reconcile_blocking_versions_only,

		}

		/// <summary>
		/// <para>Acquire Locks</para>
		/// </summary>
		public enum AcquireLocksEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("LOCK_ACQUIRED")]
			LOCK_ACQUIRED,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_LOCK_ACQUIRED")]
			NO_LOCK_ACQUIRED,

		}

		/// <summary>
		/// <para>Abort if Conflicts Detected</para>
		/// </summary>
		public enum AbortIfConflictsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ABORT_CONFLICTS")]
			ABORT_CONFLICTS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ABORT")]
			NO_ABORT,

		}

		/// <summary>
		/// <para>Conflict Definition</para>
		/// </summary>
		public enum ConflictDefinitionEnum 
		{
			/// <summary>
			/// <para>按对象定义的冲突（按行）—将按对象定义冲突。 协调期间父版本和子版本中的相同行或要素发生任何更改。 这是默认设置。</para>
			/// </summary>
			[GPValue("BY_OBJECT")]
			[Description("按对象定义的冲突（按行）")]
			BY_OBJECT,

			/// <summary>
			/// <para>按属性定义的冲突（按列）—将按属性定义冲突。 协调期间只有父版本和子版本中的相同行或要素的同一属性（列）发生的更改会被标记为冲突。 协调期间不同属性所发生的更改不会被视为冲突。</para>
			/// </summary>
			[GPValue("BY_ATTRIBUTE")]
			[Description("按属性定义的冲突（按列）")]
			BY_ATTRIBUTE,

		}

		/// <summary>
		/// <para>Conflict Resolution</para>
		/// </summary>
		public enum ConflictResolutionEnum 
		{
			/// <summary>
			/// <para>优先使用目标版本解决冲突—将优先使用目标版本解决所有冲突。 这是传统版本化的默认值。</para>
			/// </summary>
			[GPValue("FAVOR_TARGET_VERSION")]
			[Description("优先使用目标版本解决冲突")]
			Resolve_conflicts_in_favor_of_the_target_version,

			/// <summary>
			/// <para>优先使用编辑版本解决冲突—将优先使用编辑版本解决所有冲突。 这是分支版本化的默认值。</para>
			/// </summary>
			[GPValue("FAVOR_EDIT_VERSION")]
			[Description("优先使用编辑版本解决冲突")]
			Resolve_conflicts_in_favor_of_the_edit_version,

		}

		/// <summary>
		/// <para>Post Versions After Reconcile</para>
		/// </summary>
		public enum WithPostEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("POST")]
			POST,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_POST")]
			NO_POST,

		}

		/// <summary>
		/// <para>Delete Versions After Post</para>
		/// </summary>
		public enum WithDeleteEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("DELETE_VERSION")]
			DELETE_VERSION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_VERSION")]
			KEEP_VERSION,

		}

		/// <summary>
		/// <para>Proceed if unreviewed conflicts are detected</para>
		/// </summary>
		public enum ProceedIfConflictsNotReviewedEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PROCEED")]
			PROCEED,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_PROCEED")]
			NOT_PROCEED,

		}

		/// <summary>
		/// <para>Reconcile checkout replica versions</para>
		/// </summary>
		public enum ReconcileCheckoutVersionsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RECONCILE")]
			RECONCILE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_RECONCILE")]
			DO_NOT_RECONCILE,

		}

#endregion
	}
}
