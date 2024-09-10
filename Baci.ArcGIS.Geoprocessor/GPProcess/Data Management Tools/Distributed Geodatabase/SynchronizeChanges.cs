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
	/// <para>Synchronizes updates between two replica geodatabases in a specified direction.</para>
	/// </summary>
	public class SynchronizeChanges : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Geodatabase1">
		/// <para>Geodatabase 1</para>
		/// <para>The geodatabase hosting the replica to synchronize. The geodatabase can be local or remote.</para>
		/// </param>
		/// <param name="InReplica">
		/// <para>Replica</para>
		/// <para>A valid replica with a parent contained in one input geodatabase and a child in the other input geodatabase.</para>
		/// </param>
		/// <param name="Geodatabase2">
		/// <para>Geodatabase 2</para>
		/// <para>The geodatabase hosting the relative replica. The geodatabase can be local or remote.</para>
		/// </param>
		/// <param name="InDirection">
		/// <para>Direction</para>
		/// <para>Specifies the direction in which the changes will be synchronized: from geodatabase 1 to geodatabase 2, from geodatabase 2 to geodatabase 1, or in both directions. For check-out/check-in replicas or one-way replicas, there is only one appropriate direction. If the replica is two-way, all of the choices are available.</para>
		/// <para>Both directions—Changes will be synchronized in both directions. This is the default.</para>
		/// <para>From geodatabase 2 to geodatabase 1—Changes will be synchronized from geodatabase 2 to geodatabase 1.</para>
		/// <para>From geodatabase 1 to geodatabase 2—Changes will be synchronized from geodatabase 1 to geodatabase 2.</para>
		/// <para><see cref="InDirectionEnum"/></para>
		/// </param>
		/// <param name="ConflictPolicy">
		/// <para>Conflict Resolution Policy</para>
		/// <para>Specifies how conflicts will be resolved when they are encountered.</para>
		/// <para>Manually resolve conflicts—Conflicts will be resolved manually in the versioning reconcile environment.</para>
		/// <para>Resolve in favor of geodatabase 1—Conflicts will be resolved in favor of geodatabase 1. This is the default.</para>
		/// <para>Resolve in favor of geodatabase 2—Conflicts will be resolved in favor of geodatabase 2.</para>
		/// <para><see cref="ConflictPolicyEnum"/></para>
		/// </param>
		/// <param name="ConflictDefinition">
		/// <para>Conflict Definition</para>
		/// <para>Specifies how conflicts will be defined.</para>
		/// <para>Conflicts defined by row—Changes to the same row or feature in the parent and child versions will conflict during reconcile. This is the default.</para>
		/// <para>Conflicts defined by column— Only changes to the same attribute (column) of the same row or feature in the parent and child versions will be flagged as a conflict during reconcile. Changes to different attributes will not be considered a conflict during reconcile.</para>
		/// <para><see cref="ConflictDefinitionEnum"/></para>
		/// </param>
		/// <param name="Reconcile">
		/// <para>Reconcile with the Parent Version (Checkout only)</para>
		/// <para>Specifies whether to automatically reconcile once data changes are sent to the parent replica if there are no conflicts present. This option is only available for check-out/check-in replicas.</para>
		/// <para>Unchecked—Do not reconcile with the parent version. This is the default.</para>
		/// <para>Checked—Reconcile with the parent version.</para>
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
		/// <para>Tool Display Name : Synchronize Changes</para>
		/// </summary>
		public override string DisplayName() => "Synchronize Changes";

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
		/// <para>The geodatabase hosting the replica to synchronize. The geodatabase can be local or remote.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object Geodatabase1 { get; set; }

		/// <summary>
		/// <para>Replica</para>
		/// <para>A valid replica with a parent contained in one input geodatabase and a child in the other input geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InReplica { get; set; }

		/// <summary>
		/// <para>Geodatabase 2</para>
		/// <para>The geodatabase hosting the relative replica. The geodatabase can be local or remote.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object Geodatabase2 { get; set; }

		/// <summary>
		/// <para>Direction</para>
		/// <para>Specifies the direction in which the changes will be synchronized: from geodatabase 1 to geodatabase 2, from geodatabase 2 to geodatabase 1, or in both directions. For check-out/check-in replicas or one-way replicas, there is only one appropriate direction. If the replica is two-way, all of the choices are available.</para>
		/// <para>Both directions—Changes will be synchronized in both directions. This is the default.</para>
		/// <para>From geodatabase 2 to geodatabase 1—Changes will be synchronized from geodatabase 2 to geodatabase 1.</para>
		/// <para>From geodatabase 1 to geodatabase 2—Changes will be synchronized from geodatabase 1 to geodatabase 2.</para>
		/// <para><see cref="InDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InDirection { get; set; }

		/// <summary>
		/// <para>Conflict Resolution Policy</para>
		/// <para>Specifies how conflicts will be resolved when they are encountered.</para>
		/// <para>Manually resolve conflicts—Conflicts will be resolved manually in the versioning reconcile environment.</para>
		/// <para>Resolve in favor of geodatabase 1—Conflicts will be resolved in favor of geodatabase 1. This is the default.</para>
		/// <para>Resolve in favor of geodatabase 2—Conflicts will be resolved in favor of geodatabase 2.</para>
		/// <para><see cref="ConflictPolicyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConflictPolicy { get; set; } = "IN_FAVOR_OF_GDB1";

		/// <summary>
		/// <para>Conflict Definition</para>
		/// <para>Specifies how conflicts will be defined.</para>
		/// <para>Conflicts defined by row—Changes to the same row or feature in the parent and child versions will conflict during reconcile. This is the default.</para>
		/// <para>Conflicts defined by column— Only changes to the same attribute (column) of the same row or feature in the parent and child versions will be flagged as a conflict during reconcile. Changes to different attributes will not be considered a conflict during reconcile.</para>
		/// <para><see cref="ConflictDefinitionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ConflictDefinition { get; set; } = "BY_OBJECT";

		/// <summary>
		/// <para>Reconcile with the Parent Version (Checkout only)</para>
		/// <para>Specifies whether to automatically reconcile once data changes are sent to the parent replica if there are no conflicts present. This option is only available for check-out/check-in replicas.</para>
		/// <para>Unchecked—Do not reconcile with the parent version. This is the default.</para>
		/// <para>Checked—Reconcile with the parent version.</para>
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
		public SynchronizeChanges SetEnviroment(object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
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
			/// <para>Both directions—Changes will be synchronized in both directions. This is the default.</para>
			/// </summary>
			[GPValue("BOTH_DIRECTIONS")]
			[Description("Both directions")]
			Both_directions,

			/// <summary>
			/// <para>From geodatabase 2 to geodatabase 1—Changes will be synchronized from geodatabase 2 to geodatabase 1.</para>
			/// </summary>
			[GPValue("FROM_GEODATABASE2_TO_1")]
			[Description("From geodatabase 2 to geodatabase 1")]
			From_geodatabase_2_to_geodatabase_1,

			/// <summary>
			/// <para>From geodatabase 1 to geodatabase 2—Changes will be synchronized from geodatabase 1 to geodatabase 2.</para>
			/// </summary>
			[GPValue("FROM_GEODATABASE1_TO_2")]
			[Description("From geodatabase 1 to geodatabase 2")]
			From_geodatabase_1_to_geodatabase_2,

		}

		/// <summary>
		/// <para>Conflict Resolution Policy</para>
		/// </summary>
		public enum ConflictPolicyEnum 
		{
			/// <summary>
			/// <para>Resolve in favor of geodatabase 1—Conflicts will be resolved in favor of geodatabase 1. This is the default.</para>
			/// </summary>
			[GPValue("IN_FAVOR_OF_GDB1")]
			[Description("Resolve in favor of geodatabase 1")]
			Resolve_in_favor_of_geodatabase_1,

			/// <summary>
			/// <para>Resolve in favor of geodatabase 2—Conflicts will be resolved in favor of geodatabase 2.</para>
			/// </summary>
			[GPValue("IN_FAVOR_OF_GDB2")]
			[Description("Resolve in favor of geodatabase 2")]
			Resolve_in_favor_of_geodatabase_2,

			/// <summary>
			/// <para>Manually resolve conflicts—Conflicts will be resolved manually in the versioning reconcile environment.</para>
			/// </summary>
			[GPValue("MANUAL")]
			[Description("Manually resolve conflicts")]
			Manually_resolve_conflicts,

		}

		/// <summary>
		/// <para>Conflict Definition</para>
		/// </summary>
		public enum ConflictDefinitionEnum 
		{
			/// <summary>
			/// <para>Conflicts defined by row—Changes to the same row or feature in the parent and child versions will conflict during reconcile. This is the default.</para>
			/// </summary>
			[GPValue("BY_OBJECT")]
			[Description("Conflicts defined by row")]
			Conflicts_defined_by_row,

			/// <summary>
			/// <para>Conflicts defined by column— Only changes to the same attribute (column) of the same row or feature in the parent and child versions will be flagged as a conflict during reconcile. Changes to different attributes will not be considered a conflict during reconcile.</para>
			/// </summary>
			[GPValue("BY_ATTRIBUTE")]
			[Description("Conflicts defined by column")]
			Conflicts_defined_by_column,

		}

		/// <summary>
		/// <para>Reconcile with the Parent Version (Checkout only)</para>
		/// </summary>
		public enum ReconcileEnum 
		{
			/// <summary>
			/// <para>Checked—Reconcile with the parent version.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RECONCILE ")]
			RECONCILE_,

			/// <summary>
			/// <para>Unchecked—Do not reconcile with the parent version. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_RECONCILE")]
			DO_NOT_RECONCILE,

		}

#endregion
	}
}
