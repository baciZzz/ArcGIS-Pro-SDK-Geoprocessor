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
	/// <para>Remove Rule From Topology</para>
	/// <para>Removes a rule from a topology.</para>
	/// </summary>
	public class RemoveRuleFromTopology : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTopology">
		/// <para>Input Topology</para>
		/// <para>The topology from which to remove a rule.</para>
		/// </param>
		/// <param name="InRule">
		/// <para>Rule</para>
		/// <para>The topology rule to remove from the topology.</para>
		/// </param>
		public RemoveRuleFromTopology(object InTopology, object InRule)
		{
			this.InTopology = InTopology;
			this.InRule = InRule;
		}

		/// <summary>
		/// <para>Tool Display Name : Remove Rule From Topology</para>
		/// </summary>
		public override string DisplayName => "Remove Rule From Topology";

		/// <summary>
		/// <para>Tool Name : RemoveRuleFromTopology</para>
		/// </summary>
		public override string ToolName => "RemoveRuleFromTopology";

		/// <summary>
		/// <para>Tool Excute Name : management.RemoveRuleFromTopology</para>
		/// </summary>
		public override string ExcuteName => "management.RemoveRuleFromTopology";

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
		public override object[] Parameters => new object[] { InTopology, InRule, OutTopology };

		/// <summary>
		/// <para>Input Topology</para>
		/// <para>The topology from which to remove a rule.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTopologyLayer()]
		public object InTopology { get; set; }

		/// <summary>
		/// <para>Rule</para>
		/// <para>The topology rule to remove from the topology.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InRule { get; set; }

		/// <summary>
		/// <para>Updated Input Topology</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTopologyLayer()]
		public object OutTopology { get; set; }

	}
}
