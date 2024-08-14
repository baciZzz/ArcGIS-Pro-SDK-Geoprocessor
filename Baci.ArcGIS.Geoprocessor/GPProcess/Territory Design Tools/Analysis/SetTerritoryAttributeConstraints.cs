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
	/// <para>Set Territory Attribute Constraints</para>
	/// <para>Sets variables for adding constraints when solving the territory solution.</para>
	/// </summary>
	public class SetTerritoryAttributeConstraints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerritorySolution">
		/// <para>Input Territory Solution</para>
		/// <para>The Territory Design solution layer that will be used in the analysis</para>
		/// </param>
		/// <param name="Level">
		/// <para>Level</para>
		/// <para>The level to which the constraints will be applied.</para>
		/// </param>
		public SetTerritoryAttributeConstraints(object InTerritorySolution, object Level)
		{
			this.InTerritorySolution = InTerritorySolution;
			this.Level = Level;
		}

		/// <summary>
		/// <para>Tool Display Name : Set Territory Attribute Constraints</para>
		/// </summary>
		public override string DisplayName => "Set Territory Attribute Constraints";

		/// <summary>
		/// <para>Tool Name : SetTerritoryAttributeConstraints</para>
		/// </summary>
		public override string ToolName => "SetTerritoryAttributeConstraints";

		/// <summary>
		/// <para>Tool Excute Name : td.SetTerritoryAttributeConstraints</para>
		/// </summary>
		public override string ExcuteName => "td.SetTerritoryAttributeConstraints";

		/// <summary>
		/// <para>Toolbox Display Name : Territory Design Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Territory Design Tools";

		/// <summary>
		/// <para>Toolbox Alise : td</para>
		/// </summary>
		public override string ToolboxAlise => "td";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "baDataSource", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTerritorySolution, Level, Constraints!, OutTerritorySolution! };

		/// <summary>
		/// <para>Input Territory Solution</para>
		/// <para>The Territory Design solution layer that will be used in the analysis</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTerritorySolution { get; set; }

		/// <summary>
		/// <para>Level</para>
		/// <para>The level to which the constraints will be applied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Level { get; set; }

		/// <summary>
		/// <para>Constraints</para>
		/// <para>The variables that will be used for constraining the territory solution.</para>
		/// <para>Variable—Numeric value to be used as the constraint.</para>
		/// <para>Minimum—Numeric value that sets a hard limit for the territories&apos; lower bound.</para>
		/// <para>Maximum—Numeric value that sets a hard limit for the territories&apos; upper bound.</para>
		/// <para>Ideal Value—Numeric value that sets a soft limit for the ideal value for the territory solution.</para>
		/// <para>Weight—The influence a constraint value has on the territory solution. The number must be greater than 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object? Constraints { get; set; }

		/// <summary>
		/// <para>Updated Territory Solution</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPGroupLayer()]
		public object? OutTerritorySolution { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SetTerritoryAttributeConstraints SetEnviroment(object? baDataSource = null , object? workspace = null )
		{
			base.SetEnv(baDataSource: baDataSource, workspace: workspace);
			return this;
		}

	}
}
