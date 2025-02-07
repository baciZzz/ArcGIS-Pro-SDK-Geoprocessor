using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TraceNetworkTools
{
	/// <summary>
	/// <para>Delete Trace Configuration</para>
	/// <para>Delete Trace Configuration</para>
	/// <para>Deletes one or more named trace configurations from a trace network.</para>
	/// </summary>
	public class DeleteTraceConfiguration : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTraceNetwork">
		/// <para>Input Trace Network</para>
		/// <para>The trace network containing the named trace configuration to be deleted.</para>
		/// </param>
		/// <param name="TraceConfigName">
		/// <para>Trace Configuration</para>
		/// <para>The named trace configurations to be deleted.</para>
		/// </param>
		public DeleteTraceConfiguration(object InTraceNetwork, object TraceConfigName)
		{
			this.InTraceNetwork = InTraceNetwork;
			this.TraceConfigName = TraceConfigName;
		}

		/// <summary>
		/// <para>Tool Display Name : Delete Trace Configuration</para>
		/// </summary>
		public override string DisplayName() => "Delete Trace Configuration";

		/// <summary>
		/// <para>Tool Name : DeleteTraceConfiguration</para>
		/// </summary>
		public override string ToolName() => "DeleteTraceConfiguration";

		/// <summary>
		/// <para>Tool Excute Name : tn.DeleteTraceConfiguration</para>
		/// </summary>
		public override string ExcuteName() => "tn.DeleteTraceConfiguration";

		/// <summary>
		/// <para>Toolbox Display Name : Trace Network Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Trace Network Tools";

		/// <summary>
		/// <para>Toolbox Alise : tn</para>
		/// </summary>
		public override string ToolboxAlise() => "tn";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTraceNetwork, TraceConfigName, UpdatedTraceNetwork! };

		/// <summary>
		/// <para>Input Trace Network</para>
		/// <para>The trace network containing the named trace configuration to be deleted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTraceNetwork { get; set; }

		/// <summary>
		/// <para>Trace Configuration</para>
		/// <para>The named trace configurations to be deleted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object TraceConfigName { get; set; }

		/// <summary>
		/// <para>Updated Trace Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETraceNetwork()]
		public object? UpdatedTraceNetwork { get; set; }

	}
}
