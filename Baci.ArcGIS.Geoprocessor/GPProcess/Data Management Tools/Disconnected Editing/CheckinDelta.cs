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
	/// <para>Check In From Delta</para>
	/// <para>Check In From Delta</para>
	/// <para>Imports Changes from a delta file into the parent replica.</para>
	/// </summary>
	[Obsolete()]
	public class CheckinDelta : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDeltaDatabase">
		/// <para>Check-in from Delta Database</para>
		/// </param>
		/// <param name="DestWorkspace">
		/// <para>Check-in to Workspace</para>
		/// </param>
		public CheckinDelta(object InDeltaDatabase, object DestWorkspace)
		{
			this.InDeltaDatabase = InDeltaDatabase;
			this.DestWorkspace = DestWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : Check In From Delta</para>
		/// </summary>
		public override string DisplayName() => "Check In From Delta";

		/// <summary>
		/// <para>Tool Name : CheckinDelta</para>
		/// </summary>
		public override string ToolName() => "CheckinDelta";

		/// <summary>
		/// <para>Tool Excute Name : management.CheckinDelta</para>
		/// </summary>
		public override string ExcuteName() => "management.CheckinDelta";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDeltaDatabase, DestWorkspace, Reconcile, OutputWorkspace };

		/// <summary>
		/// <para>Check-in from Delta Database</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("mdb", "xml")]
		public object InDeltaDatabase { get; set; }

		/// <summary>
		/// <para>Check-in to Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Remote Database")]
		public object DestWorkspace { get; set; }

		/// <summary>
		/// <para>Reconcile with the Parent Version</para>
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
		/// <para>Reconcile with the Parent Version</para>
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
