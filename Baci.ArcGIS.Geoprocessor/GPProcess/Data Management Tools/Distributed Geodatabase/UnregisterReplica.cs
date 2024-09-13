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
	/// <para>取消注册复本</para>
	/// <para>从企业级地理数据库取消注册复本。</para>
	/// </summary>
	public class UnregisterReplica : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeodatabase">
		/// <para>Input Geodatabase</para>
		/// <para>包含要取消注册的复本的企业级地理数据库。</para>
		/// </param>
		/// <param name="InReplica">
		/// <para>Replica ID or Name</para>
		/// <para>将取消注册的复本的名称或 ID。如果提供复本名称，则它必须是完全限定的，例如 myuser.myreplica。</para>
		/// </param>
		public UnregisterReplica(object InGeodatabase, object InReplica)
		{
			this.InGeodatabase = InGeodatabase;
			this.InReplica = InReplica;
		}

		/// <summary>
		/// <para>Tool Display Name : 取消注册复本</para>
		/// </summary>
		public override string DisplayName() => "取消注册复本";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGeodatabase, InReplica, UpdatedGeodatabase };

		/// <summary>
		/// <para>Input Geodatabase</para>
		/// <para>包含要取消注册的复本的企业级地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object InGeodatabase { get; set; }

		/// <summary>
		/// <para>Replica ID or Name</para>
		/// <para>将取消注册的复本的名称或 ID。如果提供复本名称，则它必须是完全限定的，例如 myuser.myreplica。</para>
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
