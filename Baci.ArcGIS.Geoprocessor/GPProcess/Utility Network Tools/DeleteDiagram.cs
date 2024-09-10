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
	/// <para>Delete Diagram</para>
	/// <para>Select and delete network diagrams from a diagram dataset</para>
	/// </summary>
	[Obsolete()]
	public class DeleteDiagram : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDiagrams">
		/// <para>Input Network or Network Diagram Layer</para>
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
		/// <para>Tool Excute Name : un.DeleteDiagram</para>
		/// </summary>
		public override string ExcuteName() => "un.DeleteDiagram";

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
		public override object[] Parameters() => new object[] { InDiagrams, TemplateNames, DiagramNames, OutDiagrams };

		/// <summary>
		/// <para>Input Network or Network Diagram Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDiagrams { get; set; }

		/// <summary>
		/// <para>Template Names</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object TemplateNames { get; set; }

		/// <summary>
		/// <para>Diagram Names</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object DiagramNames { get; set; }

		/// <summary>
		/// <para>Output Network or Network Diagram Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutDiagrams { get; set; }

	}
}
