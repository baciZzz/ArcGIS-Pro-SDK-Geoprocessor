using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.BusinessAnalystTools
{
	/// <summary>
	/// <para>Calculate Suitability Score</para>
	/// <para>Calculates or recalculates a suitability score.</para>
	/// </summary>
	public class CalculateSuitabilityScore : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InAnalysisLayer">
		/// <para>Input Suitability Analysis Layer</para>
		/// <para>The Suitability Analysis Layer that will be used in the analysis.</para>
		/// </param>
		public CalculateSuitabilityScore(object InAnalysisLayer)
		{
			this.InAnalysisLayer = InAnalysisLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Calculate Suitability Score</para>
		/// </summary>
		public override string DisplayName => "Calculate Suitability Score";

		/// <summary>
		/// <para>Tool Name : CalculateSuitabilityScore</para>
		/// </summary>
		public override string ToolName => "CalculateSuitabilityScore";

		/// <summary>
		/// <para>Tool Excute Name : ba.CalculateSuitabilityScore</para>
		/// </summary>
		public override string ExcuteName => "ba.CalculateSuitabilityScore";

		/// <summary>
		/// <para>Toolbox Display Name : Business Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Business Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ba</para>
		/// </summary>
		public override string ToolboxAlise => "ba";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InAnalysisLayer, OutAnalysisLayer };

		/// <summary>
		/// <para>Input Suitability Analysis Layer</para>
		/// <para>The Suitability Analysis Layer that will be used in the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object InAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Output Suitability Analysis Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CalculateSuitabilityScore SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
