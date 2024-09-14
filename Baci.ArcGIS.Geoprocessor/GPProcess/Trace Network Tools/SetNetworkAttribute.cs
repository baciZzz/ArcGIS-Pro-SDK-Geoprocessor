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
	/// <para>Set Network Attribute</para>
	/// <para>Set Network Attribute</para>
	/// <para>Assigns a network attribute to a feature class to be used during trace operations.</para>
	/// </summary>
	public class SetNetworkAttribute : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTraceNetwork">
		/// <para>Input Trace Network</para>
		/// <para>The trace network that contains the network attribute to set.</para>
		/// </param>
		/// <param name="NetworkAttribute">
		/// <para>Network Attribute</para>
		/// <para>The network attribute to be assigned to the feature class field.</para>
		/// </param>
		/// <param name="Featureclass">
		/// <para>Feature Class</para>
		/// <para>The input feature class that contains the field that will be used to set the network attribute.</para>
		/// </param>
		/// <param name="Field">
		/// <para>Field</para>
		/// <para>An existing field that will be assigned the network attribute. The field data type must match the data type of the network attribute. For example, if the network attribute is a short integer type, the field must also be a short integer type. Network attributes that do not support null values can only be assigned to fields that do not allow null values.</para>
		/// </param>
		public SetNetworkAttribute(object InTraceNetwork, object NetworkAttribute, object Featureclass, object Field)
		{
			this.InTraceNetwork = InTraceNetwork;
			this.NetworkAttribute = NetworkAttribute;
			this.Featureclass = Featureclass;
			this.Field = Field;
		}

		/// <summary>
		/// <para>Tool Display Name : Set Network Attribute</para>
		/// </summary>
		public override string DisplayName() => "Set Network Attribute";

		/// <summary>
		/// <para>Tool Name : SetNetworkAttribute</para>
		/// </summary>
		public override string ToolName() => "SetNetworkAttribute";

		/// <summary>
		/// <para>Tool Excute Name : tn.SetNetworkAttribute</para>
		/// </summary>
		public override string ExcuteName() => "tn.SetNetworkAttribute";

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
		public override object[] Parameters() => new object[] { InTraceNetwork, NetworkAttribute, Featureclass, Field, OutTraceNetwork! };

		/// <summary>
		/// <para>Input Trace Network</para>
		/// <para>The trace network that contains the network attribute to set.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTraceNetwork { get; set; }

		/// <summary>
		/// <para>Network Attribute</para>
		/// <para>The network attribute to be assigned to the feature class field.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object NetworkAttribute { get; set; }

		/// <summary>
		/// <para>Feature Class</para>
		/// <para>The input feature class that contains the field that will be used to set the network attribute.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Featureclass { get; set; }

		/// <summary>
		/// <para>Field</para>
		/// <para>An existing field that will be assigned the network attribute. The field data type must match the data type of the network attribute. For example, if the network attribute is a short integer type, the field must also be a short integer type. Network attributes that do not support null values can only be assigned to fields that do not allow null values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Field { get; set; }

		/// <summary>
		/// <para>Updated Trace Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETraceNetwork()]
		public object? OutTraceNetwork { get; set; }

	}
}
