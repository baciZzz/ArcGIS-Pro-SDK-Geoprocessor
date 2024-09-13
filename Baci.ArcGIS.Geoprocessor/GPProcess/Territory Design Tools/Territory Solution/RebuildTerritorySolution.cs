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
	/// <para>Rebuild Territory Solution</para>
	/// <para>Rebuild Territory Solution</para>
	/// <para>Updates the territory solution to reflect changes made to the base level.</para>
	/// </summary>
	public class RebuildTerritorySolution : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerritorySolution">
		/// <para>Input Territory Solution</para>
		/// <para>The input territory solution.</para>
		/// </param>
		public RebuildTerritorySolution(object InTerritorySolution)
		{
			this.InTerritorySolution = InTerritorySolution;
		}

		/// <summary>
		/// <para>Tool Display Name : Rebuild Territory Solution</para>
		/// </summary>
		public override string DisplayName() => "Rebuild Territory Solution";

		/// <summary>
		/// <para>Tool Name : RebuildTerritorySolution</para>
		/// </summary>
		public override string ToolName() => "RebuildTerritorySolution";

		/// <summary>
		/// <para>Tool Excute Name : td.RebuildTerritorySolution</para>
		/// </summary>
		public override string ExcuteName() => "td.RebuildTerritorySolution";

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
		public override object[] Parameters() => new object[] { InTerritorySolution, OutTerritorySolution!, InBoundaryMask! };

		/// <summary>
		/// <para>Input Territory Solution</para>
		/// <para>The input territory solution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTerritorySolution { get; set; }

		/// <summary>
		/// <para>Updated Territory Solution</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPGroupLayer()]
		public object? OutTerritorySolution { get; set; }

		/// <summary>
		/// <para>Boundary Mask</para>
		/// <para>The layer that is used as a mask to limit the growth of point-based layers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object? InBoundaryMask { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RebuildTerritorySolution SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
