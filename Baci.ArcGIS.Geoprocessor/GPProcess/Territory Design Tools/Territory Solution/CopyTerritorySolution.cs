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
	/// <para>Copy Territory Solution</para>
	/// <para>Copy Territory Solution</para>
	/// <para>Creates a copy of a territory solution.</para>
	/// </summary>
	public class CopyTerritorySolution : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerritorySolution">
		/// <para>Input Territory Solution</para>
		/// <para>The input territory solution.</para>
		/// </param>
		/// <param name="TargetGdb">
		/// <para>Target Geodatabase</para>
		/// <para>The location of the output geodatabase.</para>
		/// </param>
		/// <param name="TerritorySolutionName">
		/// <para>Territory Solution Name</para>
		/// <para>The name of the copied territory solution</para>
		/// </param>
		public CopyTerritorySolution(object InTerritorySolution, object TargetGdb, object TerritorySolutionName)
		{
			this.InTerritorySolution = InTerritorySolution;
			this.TargetGdb = TargetGdb;
			this.TerritorySolutionName = TerritorySolutionName;
		}

		/// <summary>
		/// <para>Tool Display Name : Copy Territory Solution</para>
		/// </summary>
		public override string DisplayName() => "Copy Territory Solution";

		/// <summary>
		/// <para>Tool Name : CopyTerritorySolution</para>
		/// </summary>
		public override string ToolName() => "CopyTerritorySolution";

		/// <summary>
		/// <para>Tool Excute Name : td.CopyTerritorySolution</para>
		/// </summary>
		public override string ExcuteName() => "td.CopyTerritorySolution";

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
		public override object[] Parameters() => new object[] { InTerritorySolution, TargetGdb, TerritorySolutionName, OutTerritorySolution };

		/// <summary>
		/// <para>Input Territory Solution</para>
		/// <para>The input territory solution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTerritorySolution { get; set; }

		/// <summary>
		/// <para>Target Geodatabase</para>
		/// <para>The location of the output geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database")]
		public object TargetGdb { get; set; }

		/// <summary>
		/// <para>Territory Solution Name</para>
		/// <para>The name of the copied territory solution</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object TerritorySolutionName { get; set; }

		/// <summary>
		/// <para>Out Territory Solution</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPGroupLayer()]
		public object OutTerritorySolution { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CopyTerritorySolution SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
