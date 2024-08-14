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
	/// <para>Remove Feature Class From Topology</para>
	/// <para>Removes a feature class from a topology.</para>
	/// </summary>
	public class RemoveFeatureClassFromTopology : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTopology">
		/// <para>Input Topology</para>
		/// <para>The topology from which to remove the feature class.</para>
		/// </param>
		/// <param name="InFeatureclass">
		/// <para>Feature Class to Remove</para>
		/// <para>The feature class to remove from the topology.</para>
		/// </param>
		public RemoveFeatureClassFromTopology(object InTopology, object InFeatureclass)
		{
			this.InTopology = InTopology;
			this.InFeatureclass = InFeatureclass;
		}

		/// <summary>
		/// <para>Tool Display Name : Remove Feature Class From Topology</para>
		/// </summary>
		public override string DisplayName => "Remove Feature Class From Topology";

		/// <summary>
		/// <para>Tool Name : RemoveFeatureClassFromTopology</para>
		/// </summary>
		public override string ToolName => "RemoveFeatureClassFromTopology";

		/// <summary>
		/// <para>Tool Excute Name : management.RemoveFeatureClassFromTopology</para>
		/// </summary>
		public override string ExcuteName => "management.RemoveFeatureClassFromTopology";

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
		public override object[] Parameters => new object[] { InTopology, InFeatureclass, OutTopology };

		/// <summary>
		/// <para>Input Topology</para>
		/// <para>The topology from which to remove the feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTopologyLayer()]
		public object InTopology { get; set; }

		/// <summary>
		/// <para>Feature Class to Remove</para>
		/// <para>The feature class to remove from the topology.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InFeatureclass { get; set; }

		/// <summary>
		/// <para>Updated Input Topology</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTopologyLayer()]
		public object OutTopology { get; set; }

	}
}
