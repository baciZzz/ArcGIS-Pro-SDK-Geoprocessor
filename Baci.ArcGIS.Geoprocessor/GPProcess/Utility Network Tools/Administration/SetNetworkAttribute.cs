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
	/// <para>Set Network Attribute</para>
	/// <para>Assigns a network attribute to a feature class or table at the asset type level to be used during tracing operations.</para>
	/// </summary>
	public class SetNetworkAttribute : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Utility Network</para>
		/// <para>The utility network that contains the network attribute to set.</para>
		/// </param>
		/// <param name="NetworkAttribute">
		/// <para>Network Attribute</para>
		/// <para>The network attribute to be assigned to the field in the feature class or table.</para>
		/// </param>
		/// <param name="DomainNetwork">
		/// <para>Domain Network</para>
		/// <para>The domain network that contains the feature class or table that will have a network attribute set on it.</para>
		/// </param>
		/// <param name="Featureclass">
		/// <para>Input Table</para>
		/// <para>The input feature class or table that contains the field that will be used to set the network attribute.</para>
		/// </param>
		/// <param name="Field">
		/// <para>Field</para>
		/// <para>An existing field that will be assigned the network attribute. The field data type must match the data type of the network attribute. For example, if the network attribute is a short integer type, the field must also be a short integer type. Network attributes that do not support nulls can only be assigned to fields that do not allow null values.</para>
		/// </param>
		public SetNetworkAttribute(object InUtilityNetwork, object NetworkAttribute, object DomainNetwork, object Featureclass, object Field)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.NetworkAttribute = NetworkAttribute;
			this.DomainNetwork = DomainNetwork;
			this.Featureclass = Featureclass;
			this.Field = Field;
		}

		/// <summary>
		/// <para>Tool Display Name : Set Network Attribute</para>
		/// </summary>
		public override string DisplayName => "Set Network Attribute";

		/// <summary>
		/// <para>Tool Name : SetNetworkAttribute</para>
		/// </summary>
		public override string ToolName => "SetNetworkAttribute";

		/// <summary>
		/// <para>Tool Excute Name : un.SetNetworkAttribute</para>
		/// </summary>
		public override string ExcuteName => "un.SetNetworkAttribute";

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
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InUtilityNetwork, NetworkAttribute, DomainNetwork, Featureclass, Field, OutUtilityNetwork };

		/// <summary>
		/// <para>Input Utility Network</para>
		/// <para>The utility network that contains the network attribute to set.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Network Attribute</para>
		/// <para>The network attribute to be assigned to the field in the feature class or table.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object NetworkAttribute { get; set; }

		/// <summary>
		/// <para>Domain Network</para>
		/// <para>The domain network that contains the feature class or table that will have a network attribute set on it.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object DomainNetwork { get; set; }

		/// <summary>
		/// <para>Input Table</para>
		/// <para>The input feature class or table that contains the field that will be used to set the network attribute.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Featureclass { get; set; }

		/// <summary>
		/// <para>Field</para>
		/// <para>An existing field that will be assigned the network attribute. The field data type must match the data type of the network attribute. For example, if the network attribute is a short integer type, the field must also be a short integer type. Network attributes that do not support nulls can only be assigned to fields that do not allow null values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Field { get; set; }

		/// <summary>
		/// <para>Updated Utility Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEUtilityNetwork()]
		public object OutUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SetNetworkAttribute SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
