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
	/// <para>Create Territory Solution</para>
	/// <para>Creates a new territory solution with two levels and loads input features into the base level.</para>
	/// </summary>
	public class CreateTerritorySolution : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The geometry or data features that will be used as the base level of the created solution. The level will have the same name as the input features.</para>
		/// </param>
		/// <param name="SolutionName">
		/// <para>Territory Solution Name</para>
		/// <para>The name of the territory solution to be created.</para>
		/// </param>
		public CreateTerritorySolution(object InFeatures, object SolutionName)
		{
			this.InFeatures = InFeatures;
			this.SolutionName = SolutionName;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Territory Solution</para>
		/// </summary>
		public override string DisplayName => "Create Territory Solution";

		/// <summary>
		/// <para>Tool Name : CreateTerritorySolution</para>
		/// </summary>
		public override string ToolName => "CreateTerritorySolution";

		/// <summary>
		/// <para>Tool Excute Name : td.CreateTerritorySolution</para>
		/// </summary>
		public override string ExcuteName => "td.CreateTerritorySolution";

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
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, SolutionName, IdField, NameField, TerritoryLevelName, DefaultTerritoryName, OutTerritorySolution, InBoundaryMask };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The geometry or data features that will be used as the base level of the created solution. The level will have the same name as the input features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Territory Solution Name</para>
		/// <para>The name of the territory solution to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object SolutionName { get; set; }

		/// <summary>
		/// <para>ID Field</para>
		/// <para>The field that contains ID values for objects in the level.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object IdField { get; set; }

		/// <summary>
		/// <para>Name Field</para>
		/// <para>The field that contains name values for objects in the level.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		public object NameField { get; set; }

		/// <summary>
		/// <para>Territory Level Name</para>
		/// <para>The name of the territory level—for example, level 2.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object TerritoryLevelName { get; set; }

		/// <summary>
		/// <para>Default Territory Name</para>
		/// <para>The prefix for the names of the new territories that will be created—for example, Territory 1, Territory 2, and Territory 3 or District 1, District 2, and District 3.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object DefaultTerritoryName { get; set; }

		/// <summary>
		/// <para>Output Territory Solution</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPGroupLayer()]
		public object OutTerritorySolution { get; set; }

		/// <summary>
		/// <para>Boundary Mask</para>
		/// <para>The layer that is used as a mask to limit the growth of point-based layers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InBoundaryMask { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateTerritorySolution SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
