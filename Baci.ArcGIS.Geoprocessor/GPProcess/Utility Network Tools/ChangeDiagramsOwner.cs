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
	/// <para>Change Diagrams Owner</para>
	/// <para>Change the diagrams owner</para>
	/// </summary>
	[Obsolete()]
	public class ChangeDiagramsOwner : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDiagrams">
		/// <para>Input Network or Network Diagram Layer</para>
		/// </param>
		/// <param name="TargetOwner">
		/// <para>Target Owner</para>
		/// </param>
		public ChangeDiagramsOwner(object InDiagrams, object TargetOwner)
		{
			this.InDiagrams = InDiagrams;
			this.TargetOwner = TargetOwner;
		}

		/// <summary>
		/// <para>Tool Display Name : Change Diagrams Owner</para>
		/// </summary>
		public override string DisplayName() => "Change Diagrams Owner";

		/// <summary>
		/// <para>Tool Name : ChangeDiagramsOwner</para>
		/// </summary>
		public override string ToolName() => "ChangeDiagramsOwner";

		/// <summary>
		/// <para>Tool Excute Name : un.ChangeDiagramsOwner</para>
		/// </summary>
		public override string ExcuteName() => "un.ChangeDiagramsOwner";

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
		public override object[] Parameters() => new object[] { InDiagrams, TargetOwner, SourceOwner, DiagramNames, OutDiagrams };

		/// <summary>
		/// <para>Input Network or Network Diagram Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDiagrams { get; set; }

		/// <summary>
		/// <para>Target Owner</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TargetOwner { get; set; }

		/// <summary>
		/// <para>Source Owner</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object SourceOwner { get; set; }

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
