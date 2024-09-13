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
	/// <para>Export Territory Solution</para>
	/// <para>Export Territory Solution</para>
	/// <para>Exports a territory solution to a feature class. The export includes records from all levels (hierarchy) of the solution.</para>
	/// </summary>
	public class ExportTerritorySolution : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerritorySolution">
		/// <para>Input Territory Solution</para>
		/// <para>The Territory Design solution layer that will be exported.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will contain the exported territory solution.</para>
		/// </param>
		public ExportTerritorySolution(object InTerritorySolution, object OutFeatureClass)
		{
			this.InTerritorySolution = InTerritorySolution;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Territory Solution</para>
		/// </summary>
		public override string DisplayName() => "Export Territory Solution";

		/// <summary>
		/// <para>Tool Name : ExportTerritorySolution</para>
		/// </summary>
		public override string ToolName() => "ExportTerritorySolution";

		/// <summary>
		/// <para>Tool Excute Name : td.ExportTerritorySolution</para>
		/// </summary>
		public override string ExcuteName() => "td.ExportTerritorySolution";

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
		public override object[] Parameters() => new object[] { InTerritorySolution, OutFeatureClass, OutputGeometryType! };

		/// <summary>
		/// <para>Input Territory Solution</para>
		/// <para>The Territory Design solution layer that will be exported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTerritorySolution { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will contain the exported territory solution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Shape Type</para>
		/// <para>Specifies the feature geometry type to export.</para>
		/// <para>Territory Boundaries—Polygon features that represent the territory boundaries will be exported.</para>
		/// <para>Territory Centers—Point features that represent the territory centers will be exported.</para>
		/// <para><see cref="OutputGeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OutputGeometryType { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportTerritorySolution SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Shape Type</para>
		/// </summary>
		public enum OutputGeometryTypeEnum 
		{
			/// <summary>
			/// <para>Territory Boundaries—Polygon features that represent the territory boundaries will be exported.</para>
			/// </summary>
			[GPValue("TERRITORY_BOUNDARIES")]
			[Description("Territory Boundaries")]
			Territory_Boundaries,

			/// <summary>
			/// <para>Territory Centers—Point features that represent the territory centers will be exported.</para>
			/// </summary>
			[GPValue("TERRITORY_CENTERS")]
			[Description("Territory Centers")]
			Territory_Centers,

		}

#endregion
	}
}
