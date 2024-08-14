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
	/// <para>Export Acknowledgement Message</para>
	/// <para>Creates an output acknowledgement file to acknowledge the reception of previously received data change messages.</para>
	/// </summary>
	public class ExportAcknowledgementMessage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeodatabase">
		/// <para>Export from Replica Geodatabase</para>
		/// <para>Specifies the replica geodatabase from which to export the acknowledgement message. The geodatabase may be local or remote.</para>
		/// </param>
		/// <param name="OutAcknowledgementFile">
		/// <para>Output Acknowledgement File</para>
		/// <para>Specifies the delta file to export to.</para>
		/// </param>
		/// <param name="InReplica">
		/// <para>Replica</para>
		/// <para>The replica from which the acknowledgement message will be exported.</para>
		/// </param>
		public ExportAcknowledgementMessage(object InGeodatabase, object OutAcknowledgementFile, object InReplica)
		{
			this.InGeodatabase = InGeodatabase;
			this.OutAcknowledgementFile = OutAcknowledgementFile;
			this.InReplica = InReplica;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Acknowledgement Message</para>
		/// </summary>
		public override string DisplayName => "Export Acknowledgement Message";

		/// <summary>
		/// <para>Tool Name : ExportAcknowledgementMessage</para>
		/// </summary>
		public override string ToolName => "ExportAcknowledgementMessage";

		/// <summary>
		/// <para>Tool Excute Name : management.ExportAcknowledgementMessage</para>
		/// </summary>
		public override string ExcuteName => "management.ExportAcknowledgementMessage";

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
		public override string[] ValidEnvironments => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InGeodatabase, OutAcknowledgementFile, InReplica };

		/// <summary>
		/// <para>Export from Replica Geodatabase</para>
		/// <para>Specifies the replica geodatabase from which to export the acknowledgement message. The geodatabase may be local or remote.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InGeodatabase { get; set; }

		/// <summary>
		/// <para>Output Acknowledgement File</para>
		/// <para>Specifies the delta file to export to.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutAcknowledgementFile { get; set; }

		/// <summary>
		/// <para>Replica</para>
		/// <para>The replica from which the acknowledgement message will be exported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InReplica { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportAcknowledgementMessage SetEnviroment(object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
