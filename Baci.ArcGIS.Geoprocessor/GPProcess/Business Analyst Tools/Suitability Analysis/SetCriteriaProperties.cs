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
	/// <para>Set Criteria Properties</para>
	/// <para>Define parameters for criteria.</para>
	/// </summary>
	public class SetCriteriaProperties : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InAnalysisLayer">
		/// <para>Input Suitability Analysis Layer</para>
		/// <para>The Suitability Analysis layer that will be used in the analysis.</para>
		/// </param>
		/// <param name="CriteriaProperties">
		/// <para>Criteria Properties</para>
		/// <para>The input features that will be used to set up your criteria properties.</para>
		/// <para>Criterion—The field, point, or variable that will be used to calculate your suitability score.</para>
		/// <para>Title—The name of your criteria.</para>
		/// <para>Weight—The influence a criteria value has on the overall suitability score. The number must be greater than or equal to 0.</para>
		/// <para>Influence—Can be positive, inverse, or ideal. An example of a positive influence is as follows: You want a site to score higher if it has a greater number of households holding graduate or professional degrees. An example of an inverse influence is as follows: A lower median home value is more desirable as it is indicative of greater home affordability. An example of an ideal influence would be a search for areas within a range of values.</para>
		/// <para>Positive—The higher the criteria value, the higher the suitability score.</para>
		/// <para>Inverse—The lower the criteria value, the higher the suitability score.</para>
		/// <para>Ideal—The closer to the ideal value, the higher the score.</para>
		/// <para>Ideal Value—The closer the criteria value is to the ideal value, the higher the suitability score.</para>
		/// <para>Minimum Value—A numeric value that sets a hard limit for the criteria lower bound.</para>
		/// <para>Maximum Value—A numeric value that sets a hard limit for the criteria upper bound.</para>
		/// <para>Enabled—Check to include the criteria in the final suitability score.</para>
		/// </param>
		public SetCriteriaProperties(object InAnalysisLayer, object CriteriaProperties)
		{
			this.InAnalysisLayer = InAnalysisLayer;
			this.CriteriaProperties = CriteriaProperties;
		}

		/// <summary>
		/// <para>Tool Display Name : Set Criteria Properties</para>
		/// </summary>
		public override string DisplayName => "Set Criteria Properties";

		/// <summary>
		/// <para>Tool Name : SetCriteriaProperties</para>
		/// </summary>
		public override string ToolName => "SetCriteriaProperties";

		/// <summary>
		/// <para>Tool Excute Name : ba.SetCriteriaProperties</para>
		/// </summary>
		public override string ExcuteName => "ba.SetCriteriaProperties";

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
		public override object[] Parameters => new object[] { InAnalysisLayer, CriteriaProperties, OutAnalysisLayer };

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
		/// <para>Criteria Properties</para>
		/// <para>The input features that will be used to set up your criteria properties.</para>
		/// <para>Criterion—The field, point, or variable that will be used to calculate your suitability score.</para>
		/// <para>Title—The name of your criteria.</para>
		/// <para>Weight—The influence a criteria value has on the overall suitability score. The number must be greater than or equal to 0.</para>
		/// <para>Influence—Can be positive, inverse, or ideal. An example of a positive influence is as follows: You want a site to score higher if it has a greater number of households holding graduate or professional degrees. An example of an inverse influence is as follows: A lower median home value is more desirable as it is indicative of greater home affordability. An example of an ideal influence would be a search for areas within a range of values.</para>
		/// <para>Positive—The higher the criteria value, the higher the suitability score.</para>
		/// <para>Inverse—The lower the criteria value, the higher the suitability score.</para>
		/// <para>Ideal—The closer to the ideal value, the higher the score.</para>
		/// <para>Ideal Value—The closer the criteria value is to the ideal value, the higher the suitability score.</para>
		/// <para>Minimum Value—A numeric value that sets a hard limit for the criteria lower bound.</para>
		/// <para>Maximum Value—A numeric value that sets a hard limit for the criteria upper bound.</para>
		/// <para>Enabled—Check to include the criteria in the final suitability score.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object CriteriaProperties { get; set; }

		/// <summary>
		/// <para>Output Suitability Analysis Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SetCriteriaProperties SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
