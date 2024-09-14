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
	/// <para>Add Territory Level</para>
	/// <para>Add Territory Level</para>
	/// <para>Creates a new empty feature class to represent a level.</para>
	/// </summary>
	public class AddTerritoryLevel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerritorySolution">
		/// <para>Input Territory Solution</para>
		/// <para>The input territory solution.</para>
		/// </param>
		/// <param name="LevelName">
		/// <para>Level Name</para>
		/// <para>The name of the new territory level.</para>
		/// </param>
		public AddTerritoryLevel(object InTerritorySolution, object LevelName)
		{
			this.InTerritorySolution = InTerritorySolution;
			this.LevelName = LevelName;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Territory Level</para>
		/// </summary>
		public override string DisplayName() => "Add Territory Level";

		/// <summary>
		/// <para>Tool Name : AddTerritoryLevel</para>
		/// </summary>
		public override string ToolName() => "AddTerritoryLevel";

		/// <summary>
		/// <para>Tool Excute Name : td.AddTerritoryLevel</para>
		/// </summary>
		public override string ExcuteName() => "td.AddTerritoryLevel";

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
		public override object[] Parameters() => new object[] { InTerritorySolution, LevelName, DefaultTerritoryName!, OutTerritorySolution!, PrimaryFeatureClass! };

		/// <summary>
		/// <para>Input Territory Solution</para>
		/// <para>The input territory solution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTerritorySolution { get; set; }

		/// <summary>
		/// <para>Level Name</para>
		/// <para>The name of the new territory level.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object LevelName { get; set; }

		/// <summary>
		/// <para>Default Territory Name</para>
		/// <para>The name to be used as a prefix for new territories that will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? DefaultTerritoryName { get; set; }

		/// <summary>
		/// <para>Updated Territory Solution</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPGroupLayer()]
		public object? OutTerritorySolution { get; set; }

		/// <summary>
		/// <para>Primary Feature Class</para>
		/// <para>Specifies the class level that will be used for storing level attributes.</para>
		/// <para>Territory Boundaries—Polygon features that represent the territory boundaries.</para>
		/// <para>Territory Centers— Point features that represent the territory centers.</para>
		/// <para>Base Boundaries—Polygon features that represent the base-level feature boundaries.</para>
		/// <para>Base Centers—Point features that represent the base-level feature centers.</para>
		/// <para><see cref="PrimaryFeatureClassEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? PrimaryFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddTerritoryLevel SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Primary Feature Class</para>
		/// </summary>
		public enum PrimaryFeatureClassEnum 
		{
			/// <summary>
			/// <para>Territory Boundaries—Polygon features that represent the territory boundaries.</para>
			/// </summary>
			[GPValue("TERRITORY_BOUNDARIES")]
			[Description("Territory Boundaries")]
			Territory_Boundaries,

			/// <summary>
			/// <para>Territory Centers— Point features that represent the territory centers.</para>
			/// </summary>
			[GPValue("TERRITORY_CENTERS")]
			[Description("Territory Centers")]
			Territory_Centers,

			/// <summary>
			/// <para>Base Boundaries—Polygon features that represent the base-level feature boundaries.</para>
			/// </summary>
			[GPValue("BASE_BOUNDARIES")]
			[Description("Base Boundaries")]
			Base_Boundaries,

			/// <summary>
			/// <para>Base Centers—Point features that represent the base-level feature centers.</para>
			/// </summary>
			[GPValue("BASE_CENTERS")]
			[Description("Base Centers")]
			Base_Centers,

		}

#endregion
	}
}
