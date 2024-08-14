using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.WorkflowManagerTools
{
	/// <summary>
	/// <para>Clear Job Replication Information</para>
	/// <para>Deletes the  replication information on a parent repository and sends  a web service call to all the child repositories in the cluster. Consequently, the replication information is cleared from all the repositories participating in the cluster.</para>
	/// </summary>
	public class ClearJobReplicationInfo : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputRepositoryURL">
		/// <para>Repository URL</para>
		/// <para>The URL for the Workflow Manager (Classic) Server Object as defined on the server.</para>
		/// <para>For example, http://ServerName/arcgis/rest/services/ServerObjectName/WMServer.</para>
		/// </param>
		public ClearJobReplicationInfo(object InputRepositoryURL)
		{
			this.InputRepositoryURL = InputRepositoryURL;
		}

		/// <summary>
		/// <para>Tool Display Name : Clear Job Replication Information</para>
		/// </summary>
		public override string DisplayName => "Clear Job Replication Information";

		/// <summary>
		/// <para>Tool Name : ClearJobReplicationInfo</para>
		/// </summary>
		public override string ToolName => "ClearJobReplicationInfo";

		/// <summary>
		/// <para>Tool Excute Name : wmx.ClearJobReplicationInfo</para>
		/// </summary>
		public override string ExcuteName => "wmx.ClearJobReplicationInfo";

		/// <summary>
		/// <para>Toolbox Display Name : Workflow Manager Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Workflow Manager Tools";

		/// <summary>
		/// <para>Toolbox Alise : wmx</para>
		/// </summary>
		public override string ToolboxAlise => "wmx";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputRepositoryURL, InputDatabasepath!, OutputStatus! };

		/// <summary>
		/// <para>Repository URL</para>
		/// <para>The URL for the Workflow Manager (Classic) Server Object as defined on the server.</para>
		/// <para>For example, http://ServerName/arcgis/rest/services/ServerObjectName/WMServer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InputRepositoryURL { get; set; }

		/// <summary>
		/// <para>Input Database Path</para>
		/// <para>The Workflow Manager (Classic) connection file (.jtc) for the database from which to delete the replication information. If no connection file is specified, the current default Workflow Manager (Classic) database is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object? InputDatabasepath { get; set; }

		/// <summary>
		/// <para>Clear Replication Status</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLong()]
		public object? OutputStatus { get; set; }

	}
}
