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
	/// <para>Import Territory Solution</para>
	/// <para>Import Territory Solution</para>
	/// <para>Creates a new territory solution and imports the territories hierarchy from a table or a layer.</para>
	/// </summary>
	public class ImportTerritorySolution : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InData">
		/// <para>Input Data</para>
		/// <para>The layer or records to be imported.</para>
		/// </param>
		/// <param name="SolutionName">
		/// <para>Territory Solution Name</para>
		/// <para>The name of the territory solution to be created.</para>
		/// </param>
		/// <param name="LevelSettings">
		/// <para>Level Settings</para>
		/// <para>The level settings for importing the territories hierarchy.</para>
		/// <para>Level Name—The name of the level (required).</para>
		/// <para>Default Territory Name—The prefix for the new territory that will, subsequently, be created at the level (optional).</para>
		/// <para>ID Field—The field that contains IDs (unique IDs) for territories (required).</para>
		/// <para>Name Field—The field that contains names for territories (optional).</para>
		/// <para>Parent ID Field—The field that contains IDs of parent territories (optional).</para>
		/// <para>Primary Feature Class—Specifies the class level that will be used for storing level attributes (optional).</para>
		/// <para>Territory Boundaries—Level attributes will be stored using the boundaries of the territory solution.</para>
		/// <para>Territory Centers—Level attributes will be stored using the boundary centers of the territory solution.</para>
		/// <para>Base Boundaries—Level attributes will be stored using the boundaries of the base layer.</para>
		/// <para>Base Centers—Level attributes will be stored using the boundary centers of the base layer.</para>
		/// </param>
		public ImportTerritorySolution(object InData, object SolutionName, object LevelSettings)
		{
			this.InData = InData;
			this.SolutionName = SolutionName;
			this.LevelSettings = LevelSettings;
		}

		/// <summary>
		/// <para>Tool Display Name : Import Territory Solution</para>
		/// </summary>
		public override string DisplayName() => "Import Territory Solution";

		/// <summary>
		/// <para>Tool Name : ImportTerritorySolution</para>
		/// </summary>
		public override string ToolName() => "ImportTerritorySolution";

		/// <summary>
		/// <para>Tool Excute Name : td.ImportTerritorySolution</para>
		/// </summary>
		public override string ExcuteName() => "td.ImportTerritorySolution";

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
		public override object[] Parameters() => new object[] { InData, SolutionName, LevelSettings, OutTerritorySolution };

		/// <summary>
		/// <para>Input Data</para>
		/// <para>The layer or records to be imported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTableView()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Territory Solution Name</para>
		/// <para>The name of the territory solution to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object SolutionName { get; set; }

		/// <summary>
		/// <para>Level Settings</para>
		/// <para>The level settings for importing the territories hierarchy.</para>
		/// <para>Level Name—The name of the level (required).</para>
		/// <para>Default Territory Name—The prefix for the new territory that will, subsequently, be created at the level (optional).</para>
		/// <para>ID Field—The field that contains IDs (unique IDs) for territories (required).</para>
		/// <para>Name Field—The field that contains names for territories (optional).</para>
		/// <para>Parent ID Field—The field that contains IDs of parent territories (optional).</para>
		/// <para>Primary Feature Class—Specifies the class level that will be used for storing level attributes (optional).</para>
		/// <para>Territory Boundaries—Level attributes will be stored using the boundaries of the territory solution.</para>
		/// <para>Territory Centers—Level attributes will be stored using the boundary centers of the territory solution.</para>
		/// <para>Base Boundaries—Level attributes will be stored using the boundaries of the base layer.</para>
		/// <para>Base Centers—Level attributes will be stored using the boundary centers of the base layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object LevelSettings { get; set; }

		/// <summary>
		/// <para>Output Territory Solution</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPGroupLayer()]
		public object OutTerritorySolution { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportTerritorySolution SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
