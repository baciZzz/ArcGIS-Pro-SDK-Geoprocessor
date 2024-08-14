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
	/// <para>Delete Trace Configuration</para>
	/// <para>Deletes one or more named trace configurations  from a utility network.</para>
	/// </summary>
	public class DeleteTraceConfiguration : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The utility network containing the named trace configuration to be deleted.</para>
		/// </param>
		/// <param name="TraceConfigName">
		/// <para>Trace Configuration</para>
		/// <para>The named trace configurations to be deleted.</para>
		/// </param>
		public DeleteTraceConfiguration(object InUtilityNetwork, object TraceConfigName)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TraceConfigName = TraceConfigName;
		}

		/// <summary>
		/// <para>Tool Display Name : Delete Trace Configuration</para>
		/// </summary>
		public override string DisplayName => "Delete Trace Configuration";

		/// <summary>
		/// <para>Tool Name : DeleteTraceConfiguration</para>
		/// </summary>
		public override string ToolName => "DeleteTraceConfiguration";

		/// <summary>
		/// <para>Tool Excute Name : un.DeleteTraceConfiguration</para>
		/// </summary>
		public override string ExcuteName => "un.DeleteTraceConfiguration";

		/// <summary>
		/// <para>Toolbox Display Name : Utility Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Utility Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : un</para>
		/// </summary>
		public override string ToolboxAlise => "un";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InUtilityNetwork, TraceConfigName, OutUtilityNetwork };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The utility network containing the named trace configuration to be deleted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Trace Configuration</para>
		/// <para>The named trace configurations to be deleted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object TraceConfigName { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object OutUtilityNetwork { get; set; }

	}
}
