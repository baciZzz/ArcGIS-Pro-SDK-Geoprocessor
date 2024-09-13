using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TerritoryDesignTools
{
	/// <summary>
	/// <para>Make Territory Solution Layer</para>
	/// <para>Make Territory Solution Layer</para>
	/// <para>Creates a group layer that represents a territory solution from an existing territory solution dataset.</para>
	/// </summary>
	public class MakeTerritorySolutionLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerritoryDataset">
		/// <para>Input Territory Solution Dataset</para>
		/// <para>The input territory solution.</para>
		/// </param>
		/// <param name="OutTerritorySolution">
		/// <para>Output Territory Solution Layer</para>
		/// <para>The output territory solution group layer.</para>
		/// </param>
		public MakeTerritorySolutionLayer(object InTerritoryDataset, object OutTerritorySolution)
		{
			this.InTerritoryDataset = InTerritoryDataset;
			this.OutTerritorySolution = OutTerritorySolution;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Territory Solution Layer</para>
		/// </summary>
		public override string DisplayName() => "Make Territory Solution Layer";

		/// <summary>
		/// <para>Tool Name : MakeTerritorySolutionLayer</para>
		/// </summary>
		public override string ToolName() => "MakeTerritorySolutionLayer";

		/// <summary>
		/// <para>Tool Excute Name : td.MakeTerritorySolutionLayer</para>
		/// </summary>
		public override string ExcuteName() => "td.MakeTerritorySolutionLayer";

		/// <summary>
		/// <para>Toolbox Display Name : Territory Design Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Territory Design Tools";

		/// <summary>
		/// <para>Toolbox Alise : td</para>
		/// </summary>
		public override string ToolboxAlise() => "td";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTerritoryDataset, OutTerritorySolution };

		/// <summary>
		/// <para>Input Territory Solution Dataset</para>
		/// <para>The input territory solution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTerritoryDataset { get; set; }

		/// <summary>
		/// <para>Output Territory Solution Layer</para>
		/// <para>The output territory solution group layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPGroupLayer()]
		public object OutTerritorySolution { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeTerritorySolutionLayer SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
