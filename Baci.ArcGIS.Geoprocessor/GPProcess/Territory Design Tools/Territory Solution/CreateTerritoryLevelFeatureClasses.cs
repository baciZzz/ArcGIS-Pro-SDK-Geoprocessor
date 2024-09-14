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
	/// <para>Create Territory Level Feature Classes</para>
	/// <para>Create Territory Level Feature Classes</para>
	/// <para>Creates feature classes for a specified level.</para>
	/// </summary>
	public class CreateTerritoryLevelFeatureClasses : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerritorySolution">
		/// <para>Input Territory Solution</para>
		/// <para>The Territory Design solution layer that will be used in the analysis.</para>
		/// </param>
		/// <param name="Level">
		/// <para>Level</para>
		/// <para>The level to which the feature classes will be added.</para>
		/// </param>
		/// <param name="FeatureClasses">
		/// <para>Feature Classes</para>
		/// <para>Creates a point or polygon feature class at the specified level.</para>
		/// <para>Territory Boundaries—Polygon features that represent the territory boundaries.</para>
		/// <para>Territory Centers—Point features that represent the territory centers.</para>
		/// <para>Base Boundaries—Polygon features that represent the base boundaries.</para>
		/// <para>Base Centers—Point features that represent the base centers.</para>
		/// <para><see cref="FeatureClassesEnum"/></para>
		/// </param>
		public CreateTerritoryLevelFeatureClasses(object InTerritorySolution, object Level, object FeatureClasses)
		{
			this.InTerritorySolution = InTerritorySolution;
			this.Level = Level;
			this.FeatureClasses = FeatureClasses;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Territory Level Feature Classes</para>
		/// </summary>
		public override string DisplayName() => "Create Territory Level Feature Classes";

		/// <summary>
		/// <para>Tool Name : CreateTerritoryLevelFeatureClasses</para>
		/// </summary>
		public override string ToolName() => "CreateTerritoryLevelFeatureClasses";

		/// <summary>
		/// <para>Tool Excute Name : td.CreateTerritoryLevelFeatureClasses</para>
		/// </summary>
		public override string ExcuteName() => "td.CreateTerritoryLevelFeatureClasses";

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
		public override object[] Parameters() => new object[] { InTerritorySolution, Level, FeatureClasses, OutTerritorySolution };

		/// <summary>
		/// <para>Input Territory Solution</para>
		/// <para>The Territory Design solution layer that will be used in the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTerritorySolution { get; set; }

		/// <summary>
		/// <para>Level</para>
		/// <para>The level to which the feature classes will be added.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Level { get; set; }

		/// <summary>
		/// <para>Feature Classes</para>
		/// <para>Creates a point or polygon feature class at the specified level.</para>
		/// <para>Territory Boundaries—Polygon features that represent the territory boundaries.</para>
		/// <para>Territory Centers—Point features that represent the territory centers.</para>
		/// <para>Base Boundaries—Polygon features that represent the base boundaries.</para>
		/// <para>Base Centers—Point features that represent the base centers.</para>
		/// <para><see cref="FeatureClassesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object FeatureClasses { get; set; }

		/// <summary>
		/// <para>Updated Territory Solution</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPGroupLayer()]
		public object OutTerritorySolution { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateTerritoryLevelFeatureClasses SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Feature Classes</para>
		/// </summary>
		public enum FeatureClassesEnum 
		{
			/// <summary>
			/// <para>Territory Boundaries—Polygon features that represent the territory boundaries.</para>
			/// </summary>
			[GPValue("TERRITORY_BOUNDARIES")]
			[Description("Territory Boundaries")]
			Territory_Boundaries,

			/// <summary>
			/// <para>Territory Centers—Point features that represent the territory centers.</para>
			/// </summary>
			[GPValue("TERRITORY_CENTERS")]
			[Description("Territory Centers")]
			Territory_Centers,

			/// <summary>
			/// <para>Base Boundaries—Polygon features that represent the base boundaries.</para>
			/// </summary>
			[GPValue("BASE_BOUNDARIES")]
			[Description("Base Boundaries")]
			Base_Boundaries,

			/// <summary>
			/// <para>Base Centers—Point features that represent the base centers.</para>
			/// </summary>
			[GPValue("BASE_CENTERS")]
			[Description("Base Centers")]
			Base_Centers,

		}

#endregion
	}
}
