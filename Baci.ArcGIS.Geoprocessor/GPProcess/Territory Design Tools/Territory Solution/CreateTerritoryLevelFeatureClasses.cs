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
	/// <para>Creates feature classes for a specified territory level.</para>
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
		/// <para>Specifies the feature classes that will be created at the specified Level parameter value.</para>
		/// <para>Territory Boundaries—Polygon features that represent the territory boundaries will be created.</para>
		/// <para>Territory Centers—Point features that represent the territory centers will be created.</para>
		/// <para>Base Boundaries—Polygon features that represent the base boundaries will be created.</para>
		/// <para>Base Centers— Point features that represent the base centers will be created.</para>
		/// <para>Line Barriers—Line features that restrict traversal across a line will be created.</para>
		/// <para>Seed Points—Point features from which territories are derived will be created.</para>
		/// <para>Restricted Areas—Polygon features that prevent the creation of territories will be created.</para>
		/// <para>Polygon Barriers—Polygon features that restrict traversal across a polygon will be created.</para>
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
		public override string DisplayName => "Create Territory Level Feature Classes";

		/// <summary>
		/// <para>Tool Name : CreateTerritoryLevelFeatureClasses</para>
		/// </summary>
		public override string ToolName => "CreateTerritoryLevelFeatureClasses";

		/// <summary>
		/// <para>Tool Excute Name : td.CreateTerritoryLevelFeatureClasses</para>
		/// </summary>
		public override string ExcuteName => "td.CreateTerritoryLevelFeatureClasses";

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
		public override object[] Parameters => new object[] { InTerritorySolution, Level, FeatureClasses, OutTerritorySolution! };

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
		/// <para>Specifies the feature classes that will be created at the specified Level parameter value.</para>
		/// <para>Territory Boundaries—Polygon features that represent the territory boundaries will be created.</para>
		/// <para>Territory Centers—Point features that represent the territory centers will be created.</para>
		/// <para>Base Boundaries—Polygon features that represent the base boundaries will be created.</para>
		/// <para>Base Centers— Point features that represent the base centers will be created.</para>
		/// <para>Line Barriers—Line features that restrict traversal across a line will be created.</para>
		/// <para>Seed Points—Point features from which territories are derived will be created.</para>
		/// <para>Restricted Areas—Polygon features that prevent the creation of territories will be created.</para>
		/// <para>Polygon Barriers—Polygon features that restrict traversal across a polygon will be created.</para>
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
		public object? OutTerritorySolution { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateTerritoryLevelFeatureClasses SetEnviroment(object? workspace = null )
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
			/// <para>Territory Boundaries—Polygon features that represent the territory boundaries will be created.</para>
			/// </summary>
			[GPValue("TERRITORY_BOUNDARIES")]
			[Description("Territory Boundaries")]
			Territory_Boundaries,

			/// <summary>
			/// <para>Territory Centers—Point features that represent the territory centers will be created.</para>
			/// </summary>
			[GPValue("TERRITORY_CENTERS")]
			[Description("Territory Centers")]
			Territory_Centers,

			/// <summary>
			/// <para>Base Boundaries—Polygon features that represent the base boundaries will be created.</para>
			/// </summary>
			[GPValue("BASE_BOUNDARIES")]
			[Description("Base Boundaries")]
			Base_Boundaries,

			/// <summary>
			/// <para>Base Centers— Point features that represent the base centers will be created.</para>
			/// </summary>
			[GPValue("BASE_CENTERS")]
			[Description("Base Centers")]
			Base_Centers,

			/// <summary>
			/// <para>Seed Points—Point features from which territories are derived will be created.</para>
			/// </summary>
			[GPValue("SEED_POINTS")]
			[Description("Seed Points")]
			Seed_Points,

			/// <summary>
			/// <para>Line Barriers—Line features that restrict traversal across a line will be created.</para>
			/// </summary>
			[GPValue("LINE_BARRIERS")]
			[Description("Line Barriers")]
			Line_Barriers,

			/// <summary>
			/// <para>Polygon Barriers—Polygon features that restrict traversal across a polygon will be created.</para>
			/// </summary>
			[GPValue("POLYGON_BARRIERS")]
			[Description("Polygon Barriers")]
			Polygon_Barriers,

			/// <summary>
			/// <para>Restricted Areas—Polygon features that prevent the creation of territories will be created.</para>
			/// </summary>
			[GPValue("RESTRICTED_AREAS")]
			[Description("Restricted Areas")]
			Restricted_Areas,

		}

#endregion
	}
}
