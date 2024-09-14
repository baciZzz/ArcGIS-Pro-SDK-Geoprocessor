using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkDiagramTools
{
	/// <summary>
	/// <para>Delete Diagram Template</para>
	/// <para>Delete Diagram Template</para>
	/// <para>Deletes a diagram template and all diagrams  </para>
	/// <para>based on that template.</para>
	/// </summary>
	public class DeleteDiagramTemplate : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InUtilityNetwork">
		/// <para>Input Network</para>
		/// <para>The utility network or trace network related to the diagram template to delete.</para>
		/// </param>
		/// <param name="TemplateName">
		/// <para>Input Diagram Template</para>
		/// <para>The name of the diagram template to delete.</para>
		/// </param>
		public DeleteDiagramTemplate(object InUtilityNetwork, object TemplateName)
		{
			this.InUtilityNetwork = InUtilityNetwork;
			this.TemplateName = TemplateName;
		}

		/// <summary>
		/// <para>Tool Display Name : Delete Diagram Template</para>
		/// </summary>
		public override string DisplayName() => "Delete Diagram Template";

		/// <summary>
		/// <para>Tool Name : DeleteDiagramTemplate</para>
		/// </summary>
		public override string ToolName() => "DeleteDiagramTemplate";

		/// <summary>
		/// <para>Tool Excute Name : nd.DeleteDiagramTemplate</para>
		/// </summary>
		public override string ExcuteName() => "nd.DeleteDiagramTemplate";

		/// <summary>
		/// <para>Toolbox Display Name : Network Diagram Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Network Diagram Tools";

		/// <summary>
		/// <para>Toolbox Alise : nd</para>
		/// </summary>
		public override string ToolboxAlise() => "nd";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InUtilityNetwork, TemplateName, OutUtilityNetwork! };

		/// <summary>
		/// <para>Input Network</para>
		/// <para>The utility network or trace network related to the diagram template to delete.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InUtilityNetwork { get; set; }

		/// <summary>
		/// <para>Input Diagram Template</para>
		/// <para>The name of the diagram template to delete.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TemplateName { get; set; }

		/// <summary>
		/// <para>Output Network</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutUtilityNetwork { get; set; }

	}
}
