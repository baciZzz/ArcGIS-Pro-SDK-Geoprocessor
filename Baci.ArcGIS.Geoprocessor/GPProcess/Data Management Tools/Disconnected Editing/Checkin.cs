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
	/// <para>Check In</para>
	/// <para>Synchronizes changes from a check-out replica in ArcSDE.</para>
	/// </summary>
	[Obsolete()]
	public class Checkin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Check-in from Workspace</para>
		/// </param>
		/// <param name="DestWorkspace">
		/// <para>Check-in to Workspace</para>
		/// </param>
		public Checkin(object InWorkspace, object DestWorkspace)
		{
			this.InWorkspace = InWorkspace;
			this.DestWorkspace = DestWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : Check In</para>
		/// </summary>
		public override string DisplayName => "Check In";

		/// <summary>
		/// <para>Tool Name : Checkin</para>
		/// </summary>
		public override string ToolName => "Checkin";

		/// <summary>
		/// <para>Tool Excute Name : management.Checkin</para>
		/// </summary>
		public override string ExcuteName => "management.Checkin";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InWorkspace, DestWorkspace, Reconcile, OutputWorkspace };

		/// <summary>
		/// <para>Check-in from Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database", "Local Database")]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Check-in to Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object DestWorkspace { get; set; }

		/// <summary>
		/// <para>Reconcile with the Parent Versioin</para>
		/// <para><see cref="ReconcileEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Reconcile { get; set; } = "false";

		/// <summary>
		/// <para>Output Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutputWorkspace { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Reconcile with the Parent Versioin</para>
		/// </summary>
		public enum ReconcileEnum 
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
			[Description("NON_RECONCILE")]
			NON_RECONCILE,

		}

#endregion
	}
}
