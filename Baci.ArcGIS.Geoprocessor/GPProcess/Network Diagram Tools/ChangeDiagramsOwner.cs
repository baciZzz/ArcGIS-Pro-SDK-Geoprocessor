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
	/// <para>Change Diagrams Owner</para>
	/// <para>Change Diagrams Owner</para>
	/// <para>Changes ownership of stored network diagrams.</para>
	/// </summary>
	public class ChangeDiagramsOwner : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDiagrams">
		/// <para>Input Network or Network Diagram Layer</para>
		/// <para>The input network layer or network diagram layer related to the utility network or trace network of interest with the stored network diagrams whose ownership will be transferred.</para>
		/// </param>
		/// <param name="TargetOwner">
		/// <para>Target Owner</para>
		/// <para>The name of the user that will become the new owner of the specified diagrams.</para>
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
		/// <para>Tool Excute Name : nd.ChangeDiagramsOwner</para>
		/// </summary>
		public override string ExcuteName() => "nd.ChangeDiagramsOwner";

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
		public override object[] Parameters() => new object[] { InDiagrams, TargetOwner, SourceOwner!, DiagramNames!, OutDiagrams! };

		/// <summary>
		/// <para>Input Network or Network Diagram Layer</para>
		/// <para>The input network layer or network diagram layer related to the utility network or trace network of interest with the stored network diagrams whose ownership will be transferred.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InDiagrams { get; set; }

		/// <summary>
		/// <para>Target Owner</para>
		/// <para>The name of the user that will become the new owner of the specified diagrams.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TargetOwner { get; set; }

		/// <summary>
		/// <para>Source Owner</para>
		/// <para>The name of the user whose ownership of the network diagrams will be changed.</para>
		/// <para>This parameter is only used when there are no specified diagram names. When diagram names are specified, it will be ignored.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? SourceOwner { get; set; }

		/// <summary>
		/// <para>Diagram Names</para>
		/// <para>The names of the diagrams to be processed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? DiagramNames { get; set; }

		/// <summary>
		/// <para>Output Network or Network Diagram Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutDiagrams { get; set; }

	}
}
