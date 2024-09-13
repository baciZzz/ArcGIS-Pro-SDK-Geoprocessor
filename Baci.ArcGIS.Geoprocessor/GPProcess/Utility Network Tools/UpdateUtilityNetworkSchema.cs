using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.UtilityNetworkTools
{
	/// <summary>
	/// <para>Update Utility Network Schema</para>
	/// <para>Update Utility Network Schema</para>
	/// <para>Updates the schema of a utility network based upon a Xml set of instructions</para>
	/// </summary>
	[Obsolete()]
	public class UpdateUtilityNetworkSchema : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// </param>
		/// <param name="Operations">
		/// <para>Schema Operations</para>
		/// </param>
		public UpdateUtilityNetworkSchema(object InUtilityNetwork, object Operations)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.Operations = Operations;
		}

		/// <summary>
		/// <para>Tool Display Name : Update Utility Network Schema</para>
		/// </summary>
		public override string DisplayName() => "Update Utility Network Schema";

		/// <summary>
		/// <para>Tool Name : UpdateUtilityNetworkSchema</para>
		/// </summary>
		public override string ToolName() => "UpdateUtilityNetworkSchema";

		/// <summary>
		/// <para>Tool Excute Name : un.UpdateUtilityNetworkSchema</para>
		/// </summary>
		public override string ExcuteName() => "un.UpdateUtilityNetworkSchema";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise() => "un";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, Operations, OutMessages, OutUtilityNetwork };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Schema Operations</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object Operations { get; set; }

		/// <summary>
		/// <para>Output Messages</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutMessages { get; set; }

		/// <summary>
		/// <para>Output Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object OutUtilityNetwork { get; set; }

	}
}
