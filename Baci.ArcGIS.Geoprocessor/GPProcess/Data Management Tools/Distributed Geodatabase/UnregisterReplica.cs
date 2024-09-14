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
	/// <para>Unregister Replica</para>
	/// <para>Unregister Replica</para>
	/// <para>Unregisters a replica from an enterprise geodatabase.</para>
	/// </summary>
	public class UnregisterReplica : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeodatabase">
		/// <para>Input Geodatabase</para>
		/// <para>The enterprise geodatabase that contains the replica to unregister.</para>
		/// </param>
		/// <param name="InReplica">
		/// <para>Replica ID or Name</para>
		/// <para>The name or id of the replica that will be unregistered. If providing the replica name, it must be fully qualified, for example, myuser.myreplica.</para>
		/// </param>
		public UnregisterReplica(object InGeodatabase, object InReplica)
		{
			this.InGeodatabase = InGeodatabase;
			this.InReplica = InReplica;
		}

		/// <summary>
		/// <para>Tool Display Name : Unregister Replica</para>
		/// </summary>
		public override string DisplayName() => "Unregister Replica";

		/// <summary>
		/// <para>Tool Name : UnregisterReplica</para>
		/// </summary>
		public override string ToolName() => "UnregisterReplica";

		/// <summary>
		/// <para>Tool Excute Name : management.UnregisterReplica</para>
		/// </summary>
		public override string ExcuteName() => "management.UnregisterReplica";

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
		public override object[] Parameters() => new object[] { InGeodatabase, InReplica, UpdatedGeodatabase };

		/// <summary>
		/// <para>Input Geodatabase</para>
		/// <para>The enterprise geodatabase that contains the replica to unregister.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object InGeodatabase { get; set; }

		/// <summary>
		/// <para>Replica ID or Name</para>
		/// <para>The name or id of the replica that will be unregistered. If providing the replica name, it must be fully qualified, for example, myuser.myreplica.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InReplica { get; set; }

		/// <summary>
		/// <para>Updated Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object UpdatedGeodatabase { get; set; }

	}
}
