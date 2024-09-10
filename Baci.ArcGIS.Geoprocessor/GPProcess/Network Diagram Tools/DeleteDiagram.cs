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
	/// <para>Delete Diagram</para>
	/// <para>Deletes one or more stored network diagrams, which are optionally filtered by their diagram template names, related to a given network.</para>
	/// </summary>
	public class DeleteDiagram : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDiagrams">
		/// <para>Input Network or Network Diagram Layer</para>
		/// <para>The input network diagram layer to delete, or the utility network or trace network layer on which the set of specified input diagram names to delete are based.</para>
		/// </param>
		public DeleteDiagram(object InDiagrams)
		{
			this.InDiagrams = InDiagrams;
		}

		/// <summary>
		/// <para>Tool Display Name : Delete Diagram</para>
		/// </summary>
		public override string DisplayName() => "Delete Diagram";

		/// <summary>
		/// <para>Tool Name : DeleteDiagram</para>
		/// </summary>
		public override string ToolName() => "DeleteDiagram";

		/// <summary>
		/// <para>Tool Excute Name : nd.DeleteDiagram</para>
		/// </summary>
		public override string ExcuteName() => "nd.DeleteDiagram";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDiagrams, TemplateNames, DiagramNames, OutDiagrams };

		/// <summary>
		/// <para>Input Network or Network Diagram Layer</para>
		/// <para>The input network diagram layer to delete, or the utility network or trace network layer on which the set of specified input diagram names to delete are based.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDiagrams { get; set; }

		/// <summary>
		/// <para>Template Names</para>
		/// <para>The names of the templates for which the related diagrams are to be processed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object TemplateNames { get; set; }

		/// <summary>
		/// <para>Diagram Names</para>
		/// <para>The names of the diagrams to be processed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object DiagramNames { get; set; }

		/// <summary>
		/// <para>Output Diagrams</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutDiagrams { get; set; }

	}
}
