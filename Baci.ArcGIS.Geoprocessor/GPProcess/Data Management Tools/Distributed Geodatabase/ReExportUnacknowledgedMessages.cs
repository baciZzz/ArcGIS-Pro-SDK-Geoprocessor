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
	/// <para>Re-export Unacknowledged Messages</para>
	/// <para>Re-export Unacknowledged Messages</para>
	/// <para>Creates an output delta file containing unacknowledged replica updates from a one-way or two-way replica geodatabase.</para>
	/// </summary>
	public class ReExportUnacknowledgedMessages : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeodatabase">
		/// <para>Export from Replica Geodatabase</para>
		/// <para>The replica geodatabase from which the unacknowledged messages will be reexported. The geodatabase can be a local geodatabase or a geodata service.</para>
		/// </param>
		/// <param name="OutputDeltaFile">
		/// <para>Output Delta File</para>
		/// <para>The delta file to which data changes will be reexported.</para>
		/// </param>
		/// <param name="InReplica">
		/// <para>Replica</para>
		/// <para>The replica from which the unacknowledged messages will be reexported.</para>
		/// </param>
		/// <param name="InExportOption">
		/// <para>Export options</para>
		/// <para>Specifies the changes that will be reexported.</para>
		/// <para>All unacknowledged—All changes with unacknowledged messages will be reexported.</para>
		/// <para>Most recent—Only those changes made since the last set of exported changes was sent will be reexported.</para>
		/// <para><see cref="InExportOptionEnum"/></para>
		/// </param>
		public ReExportUnacknowledgedMessages(object InGeodatabase, object OutputDeltaFile, object InReplica, object InExportOption)
		{
			this.InGeodatabase = InGeodatabase;
			this.OutputDeltaFile = OutputDeltaFile;
			this.InReplica = InReplica;
			this.InExportOption = InExportOption;
		}

		/// <summary>
		/// <para>Tool Display Name : Re-export Unacknowledged Messages</para>
		/// </summary>
		public override string DisplayName() => "Re-export Unacknowledged Messages";

		/// <summary>
		/// <para>Tool Name : ReExportUnacknowledgedMessages</para>
		/// </summary>
		public override string ToolName() => "ReExportUnacknowledgedMessages";

		/// <summary>
		/// <para>Tool Excute Name : management.ReExportUnacknowledgedMessages</para>
		/// </summary>
		public override string ExcuteName() => "management.ReExportUnacknowledgedMessages";

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
		public override object[] Parameters() => new object[] { InGeodatabase, OutputDeltaFile, InReplica, InExportOption };

		/// <summary>
		/// <para>Export from Replica Geodatabase</para>
		/// <para>The replica geodatabase from which the unacknowledged messages will be reexported. The geodatabase can be a local geodatabase or a geodata service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InGeodatabase { get; set; }

		/// <summary>
		/// <para>Output Delta File</para>
		/// <para>The delta file to which data changes will be reexported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml", "gdb")]
		public object OutputDeltaFile { get; set; }

		/// <summary>
		/// <para>Replica</para>
		/// <para>The replica from which the unacknowledged messages will be reexported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InReplica { get; set; }

		/// <summary>
		/// <para>Export options</para>
		/// <para>Specifies the changes that will be reexported.</para>
		/// <para>All unacknowledged—All changes with unacknowledged messages will be reexported.</para>
		/// <para>Most recent—Only those changes made since the last set of exported changes was sent will be reexported.</para>
		/// <para><see cref="InExportOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object InExportOption { get; set; } = "ALL_UNACKNOWLEDGED";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ReExportUnacknowledgedMessages SetEnviroment(object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Export options</para>
		/// </summary>
		public enum InExportOptionEnum 
		{
			/// <summary>
			/// <para>All unacknowledged—All changes with unacknowledged messages will be reexported.</para>
			/// </summary>
			[GPValue("ALL_UNACKNOWLEDGED")]
			[Description("All unacknowledged")]
			All_unacknowledged,

			/// <summary>
			/// <para>Most recent—Only those changes made since the last set of exported changes was sent will be reexported.</para>
			/// </summary>
			[GPValue("MOST_RECENT")]
			[Description("Most recent")]
			Most_recent,

		}

#endregion
	}
}
