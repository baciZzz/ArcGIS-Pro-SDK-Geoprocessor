using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkAnalystTools
{
	/// <summary>
	/// <para>Update Analysis Layer Attribute Parameter</para>
	/// <para>Updates the network attribute parameter value for a network analysis layer. The tool should be used to update the value of an attribute parameter for a network analysis layer prior to solving with the Solve tool.  This ensures that the  solve operation uses the specified value of the attribute parameter to produce appropriate results.</para>
	/// </summary>
	[Obsolete()]
	public class UpdateAnalysisLayerAttributeParameter : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkAnalysisLayer">
		/// <para>Input Network Analysis Layer</para>
		/// <para>Network analysis layer for which the attribute parameter value will be updated.</para>
		/// </param>
		/// <param name="ParameterizedAttribute">
		/// <para>Attribute</para>
		/// <para>The network attribute whose attribute parameter will be updated.</para>
		/// </param>
		/// <param name="AttributeParameterName">
		/// <para>Parameter</para>
		/// <para>The parameter of the network attribute that will be updated. The parameters of type Object cannot be updated using the tool.</para>
		/// </param>
		public UpdateAnalysisLayerAttributeParameter(object InNetworkAnalysisLayer, object ParameterizedAttribute, object AttributeParameterName)
		{
			this.InNetworkAnalysisLayer = InNetworkAnalysisLayer;
			this.ParameterizedAttribute = ParameterizedAttribute;
			this.AttributeParameterName = AttributeParameterName;
		}

		/// <summary>
		/// <para>Tool Display Name : Update Analysis Layer Attribute Parameter</para>
		/// </summary>
		public override string DisplayName => "Update Analysis Layer Attribute Parameter";

		/// <summary>
		/// <para>Tool Name : UpdateAnalysisLayerAttributeParameter</para>
		/// </summary>
		public override string ToolName => "UpdateAnalysisLayerAttributeParameter";

		/// <summary>
		/// <para>Tool Excute Name : na.UpdateAnalysisLayerAttributeParameter</para>
		/// </summary>
		public override string ExcuteName => "na.UpdateAnalysisLayerAttributeParameter";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InNetworkAnalysisLayer, ParameterizedAttribute, AttributeParameterName, AttributeParameterValue!, OutputLayer! };

		/// <summary>
		/// <para>Input Network Analysis Layer</para>
		/// <para>Network analysis layer for which the attribute parameter value will be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPNALayer()]
		public object InNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Attribute</para>
		/// <para>The network attribute whose attribute parameter will be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ParameterizedAttribute { get; set; }

		/// <summary>
		/// <para>Parameter</para>
		/// <para>The parameter of the network attribute that will be updated. The parameters of type Object cannot be updated using the tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AttributeParameterName { get; set; }

		/// <summary>
		/// <para>Value</para>
		/// <para>The value that will be set for the attribute parameter. It can be a string, number, date, or Boolean (True, False). If the value is not specified, then the attribute parameter value is set to Null.</para>
		/// <para>If the attribute parameter has a restriction usage type, the value can be specified as a string keyword or a numeric value. The string keyword or the numeric value determines whether the restriction attribute prohibits, avoids, or prefers the network elements it is associated with. Furthermore, the degree to which network elements are avoided or preferred can be defined by choosing HIGH, MEDIUM, or LOW keywords. The following keywords are supported:</para>
		/// <para>PROHIBITED</para>
		/// <para>AVOID_HIGH</para>
		/// <para>AVOID_MEDIUM</para>
		/// <para>AVOID_LOW</para>
		/// <para>PREFER_LOW</para>
		/// <para>PREFER_MEDIUM</para>
		/// <para>PREFER_HIGH</para>
		/// <para>Numeric values that are greater than one cause restricted elements to be avoided; the larger the number, the more the elements are avoided. Numeric values between zero and one cause restricted elements to be preferred; the smaller the number, the more restricted elements are preferred. Negative numbers prohibit restricted elements.</para>
		/// <para>If the parameter value holds an array, separate the items in the array with the localized separator character. For example, in the U.S., you would most likely use the comma character to separate the items. So representing an array of three numbers might look like the following: &quot;5,10,15&quot;.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? AttributeParameterValue { get; set; }

		/// <summary>
		/// <para>Updated Input Network Analysis Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPNALayer()]
		public object? OutputLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public UpdateAnalysisLayerAttributeParameter SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
