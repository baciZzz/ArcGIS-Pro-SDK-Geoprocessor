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
	/// <para>Add Variable Based Suitability Criteria</para>
	/// <para>Adds criteria based on the values calculated for the input layer using the Enrich Layer tool.</para>
	/// </summary>
	public class AddVariableBasedSuitabilityCriteria : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InAnalysisLayer">
		/// <para>Input Suitability Analysis Layer</para>
		/// <para>The Suitability Analysis layer that will be used in the analysis.</para>
		/// </param>
		/// <param name="Variables">
		/// <para>Variables</para>
		/// <para>The variables from which the suitability criteria will be determined.</para>
		/// </param>
		public AddVariableBasedSuitabilityCriteria(object InAnalysisLayer, object Variables)
		{
			this.InAnalysisLayer = InAnalysisLayer;
			this.Variables = Variables;
		}

		/// <summary>
		/// <para>Tool Display Name : Add Variable Based Suitability Criteria</para>
		/// </summary>
		public override string DisplayName => "Add Variable Based Suitability Criteria";

		/// <summary>
		/// <para>Tool Name : AddVariableBasedSuitabilityCriteria</para>
		/// </summary>
		public override string ToolName => "AddVariableBasedSuitabilityCriteria";

		/// <summary>
		/// <para>Tool Excute Name : ba.AddVariableBasedSuitabilityCriteria</para>
		/// </summary>
		public override string ExcuteName => "ba.AddVariableBasedSuitabilityCriteria";

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
		public override string[] ValidEnvironments => new string[] { "baDataSource", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InAnalysisLayer, Variables, OutAnalysisLayer, OutCriteriaName };

		/// <summary>
		/// <para>Input Suitability Analysis Layer</para>
		/// <para>The Suitability Analysis layer that will be used in the analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Variables</para>
		/// <para>The variables from which the suitability criteria will be determined.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Variables { get; set; }

		/// <summary>
		/// <para>Output Suitability Analysis Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Output Criteria Name</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutCriteriaName { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddVariableBasedSuitabilityCriteria SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
