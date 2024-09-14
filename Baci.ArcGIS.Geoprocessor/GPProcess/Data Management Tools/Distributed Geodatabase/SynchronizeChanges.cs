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
	/// <para>Synchronize Changes</para>
	/// <para>同步更改</para>
	/// <para>根据指定的方向在两个复本地理数据库之间对更新进行同步。</para>
	/// </summary>
	public class SynchronizeChanges : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Geodatabase1">
		/// <para>Geodatabase 1</para>
		/// <para>要同步的复本所在的地理数据库。 地理数据库可以是本地地理数据库也可以是远程地理数据库。</para>
		/// </param>
		/// <param name="InReplica">
		/// <para>Replica</para>
		/// <para>父项在一个输入地理数据库中而子项在另一个输入地理数据库中的有效复本。</para>
		/// </param>
		/// <param name="Geodatabase2">
		/// <para>Geodatabase 2</para>
		/// <para>相关复本所在的地理数据库。 地理数据库可以是本地地理数据库也可以是远程地理数据库。</para>
		/// </param>
		/// <param name="InDirection">
		/// <para>Direction</para>
		/// <para>指定同步变更的方向：从地理数据库 1 到地理数据库 2、从地理数据库 2 到地理数据库 1，或者双向同步变更。 对于检出/检入复本或单向复本，仅可以向一个方向发送变更。 如果复本为双向复本，则上述选择均可使用。</para>
		/// <para>两个方向—对变更进行双向同步。 这是默认设置。</para>
		/// <para>从地理数据库 2 到地理数据库 1—将变更从地理数据库 2 同步到地理数据库 1。</para>
		/// <para>从地理数据库 1 到地理数据库 2—将变更从地理数据库 1 同步到地理数据库 2。</para>
		/// <para><see cref="InDirectionEnum"/></para>
		/// </param>
		/// <param name="ConflictPolicy">
		/// <para>Conflict Resolution Policy</para>
		/// <para>指定发生冲突时解决冲突的方式。</para>
		/// <para>手动解决冲突—在版本协调环境中手动解决冲突。</para>
		/// <para>优先使用地理数据库 1 解决—优先使用地理数据库 1 解决冲突。 这是默认设置。</para>
		/// <para>优先使用地理数据库 2 解决—优先使用地理数据库 2 解决冲突。</para>
		/// <para><see cref="ConflictPolicyEnum"/></para>
		/// </param>
		/// <param name="ConflictDefinition">
		/// <para>Conflict Definition</para>
		/// <para>指定冲突的定义方式。</para>
		/// <para>由行定义的冲突—协调期间父版本和子版本中的相同行或要素发生更改。 这是默认设置。</para>
		/// <para>由列定义的冲突—协调期间只有父版本和子版本中的相同行或要素的同一属性（列）发生的更改会被标记为冲突。 协调期间不同属性所发生的更改不会被视为冲突。</para>
		/// <para><see cref="ConflictDefinitionEnum"/></para>
		/// </param>
		/// <param name="Reconcile">
		/// <para>Reconcile with the Parent Version (Checkout only)</para>
		/// <para>指定如果不存在任何冲突，则在数据变更发送到父复本后是否自动进行协调。 此选项仅适用于检出/检入复本。</para>
		/// <para>未选中 - 不使用父版本进行协调。 这是默认设置。</para>
		/// <para>选中 - 使用父版本进行协调。</para>
		/// <para><see cref="ReconcileEnum"/></para>
		/// </param>
		public SynchronizeChanges(object Geodatabase1, object InReplica, object Geodatabase2, object InDirection, object ConflictPolicy, object ConflictDefinition, object Reconcile)
		{
			this.Geodatabase1 = Geodatabase1;
			this.InReplica = InReplica;
			this.Geodatabase2 = Geodatabase2;
			this.InDirection = InDirection;
			this.ConflictPolicy = ConflictPolicy;
			this.ConflictDefinition = ConflictDefinition;
			this.Reconcile = Reconcile;
		}

		/// <summary>
		/// <para>Tool Display Name : 同步更改</para>
		/// </summary>
		public override string DisplayName() => "同步更改";

		/// <summary>
		/// <para>Tool Name : SynchronizeChanges</para>
		/// </summary>
		public override string ToolName() => "SynchronizeChanges";

		/// <summary>
		/// <para>Tool Excute Name : management.SynchronizeChanges</para>
		/// </summary>
		public override string ExcuteName() => "management.SynchronizeChanges";

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
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Geodatabase1, InReplica, Geodatabase2, InDirection, ConflictPolicy, ConflictDefinition, Reconcile, OutGeodatabase1, OutGeodatabase2 };

		/// <summary>
		/// <para>Geodatabase 1</para>
		/// <para>要同步的复本所在的地理数据库。 地理数据库可以是本地地理数据库也可以是远程地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object Geodatabase1 { get; set; }

		/// <summary>
		/// <para>Replica</para>
		/// <para>父项在一个输入地理数据库中而子项在另一个输入地理数据库中的有效复本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InReplica { get; set; }

		/// <summary>
		/// <para>Geodatabase 2</para>
		/// <para>相关复本所在的地理数据库。 地理数据库可以是本地地理数据库也可以是远程地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object Geodatabase2 { get; set; }

		/// <summary>
		/// <para>Direction</para>
		/// <para>指定同步变更的方向：从地理数据库 1 到地理数据库 2、从地理数据库 2 到地理数据库 1，或者双向同步变更。 对于检出/检入复本或单向复本，仅可以向一个方向发送变更。 如果复本为双向复本，则上述选择均可使用。</para>
		/// <para>两个方向—对变更进行双向同步。 这是默认设置。</para>
		/// <para>从地理数据库 2 到地理数据库 1—将变更从地理数据库 2 同步到地理数据库 1。</para>
		/// <para>从地理数据库 1 到地理数据库 2—将变更从地理数据库 1 同步到地理数据库 2。</para>
		/// <para><see cref="InDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InDirection { get; set; }

		/// <summary>
		/// <para>Conflict Resolution Policy</para>
		/// <para>指定发生冲突时解决冲突的方式。</para>
		/// <para>手动解决冲突—在版本协调环境中手动解决冲突。</para>
		/// <para>优先使用地理数据库 1 解决—优先使用地理数据库 1 解决冲突。 这是默认设置。</para>
		/// <para>优先使用地理数据库 2 解决—优先使用地理数据库 2 解决冲突。</para>
		/// <para><see cref="ConflictPolicyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConflictPolicy { get; set; } = "IN_FAVOR_OF_GDB1";

		/// <summary>
		/// <para>Conflict Definition</para>
		/// <para>指定冲突的定义方式。</para>
		/// <para>由行定义的冲突—协调期间父版本和子版本中的相同行或要素发生更改。 这是默认设置。</para>
		/// <para>由列定义的冲突—协调期间只有父版本和子版本中的相同行或要素的同一属性（列）发生的更改会被标记为冲突。 协调期间不同属性所发生的更改不会被视为冲突。</para>
		/// <para><see cref="ConflictDefinitionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConflictDefinition { get; set; } = "BY_OBJECT";

		/// <summary>
		/// <para>Reconcile with the Parent Version (Checkout only)</para>
		/// <para>指定如果不存在任何冲突，则在数据变更发送到父复本后是否自动进行协调。 此选项仅适用于检出/检入复本。</para>
		/// <para>未选中 - 不使用父版本进行协调。 这是默认设置。</para>
		/// <para>选中 - 使用父版本进行协调。</para>
		/// <para><see cref="ReconcileEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Reconcile { get; set; } = "false";

		/// <summary>
		/// <para>Output Geodatabase 1</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutGeodatabase1 { get; set; }

		/// <summary>
		/// <para>Output Geodatabase 2</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutGeodatabase2 { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SynchronizeChanges SetEnviroment(object geographicTransformations = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Direction</para>
		/// </summary>
		public enum InDirectionEnum 
		{
			/// <summary>
			/// <para>两个方向—对变更进行双向同步。 这是默认设置。</para>
			/// </summary>
			[GPValue("BOTH_DIRECTIONS")]
			[Description("两个方向")]
			Both_directions,

			/// <summary>
			/// <para>从地理数据库 2 到地理数据库 1—将变更从地理数据库 2 同步到地理数据库 1。</para>
			/// </summary>
			[GPValue("FROM_GEODATABASE2_TO_1")]
			[Description("从地理数据库 2 到地理数据库 1")]
			From_geodatabase_2_to_geodatabase_1,

			/// <summary>
			/// <para>从地理数据库 1 到地理数据库 2—将变更从地理数据库 1 同步到地理数据库 2。</para>
			/// </summary>
			[GPValue("FROM_GEODATABASE1_TO_2")]
			[Description("从地理数据库 1 到地理数据库 2")]
			From_geodatabase_1_to_geodatabase_2,

		}

		/// <summary>
		/// <para>Conflict Resolution Policy</para>
		/// </summary>
		public enum ConflictPolicyEnum 
		{
			/// <summary>
			/// <para>优先使用地理数据库 1 解决—优先使用地理数据库 1 解决冲突。 这是默认设置。</para>
			/// </summary>
			[GPValue("IN_FAVOR_OF_GDB1")]
			[Description("优先使用地理数据库 1 解决")]
			Resolve_in_favor_of_geodatabase_1,

			/// <summary>
			/// <para>优先使用地理数据库 2 解决—优先使用地理数据库 2 解决冲突。</para>
			/// </summary>
			[GPValue("IN_FAVOR_OF_GDB2")]
			[Description("优先使用地理数据库 2 解决")]
			Resolve_in_favor_of_geodatabase_2,

			/// <summary>
			/// <para>手动解决冲突—在版本协调环境中手动解决冲突。</para>
			/// </summary>
			[GPValue("MANUAL")]
			[Description("手动解决冲突")]
			Manually_resolve_conflicts,

		}

		/// <summary>
		/// <para>Conflict Definition</para>
		/// </summary>
		public enum ConflictDefinitionEnum 
		{
			/// <summary>
			/// <para>由行定义的冲突—协调期间父版本和子版本中的相同行或要素发生更改。 这是默认设置。</para>
			/// </summary>
			[GPValue("BY_OBJECT")]
			[Description("由行定义的冲突")]
			Conflicts_defined_by_row,

			/// <summary>
			/// <para>由列定义的冲突—协调期间只有父版本和子版本中的相同行或要素的同一属性（列）发生的更改会被标记为冲突。 协调期间不同属性所发生的更改不会被视为冲突。</para>
			/// </summary>
			[GPValue("BY_ATTRIBUTE")]
			[Description("由列定义的冲突")]
			Conflicts_defined_by_column,

		}

		/// <summary>
		/// <para>Reconcile with the Parent Version (Checkout only)</para>
		/// </summary>
		public enum ReconcileEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RECONCILE ")]
			RECONCILE_,

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
