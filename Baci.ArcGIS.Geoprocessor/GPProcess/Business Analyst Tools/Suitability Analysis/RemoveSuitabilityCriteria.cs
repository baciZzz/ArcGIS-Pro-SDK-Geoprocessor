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
	/// <para>Remove Suitability Criteria</para>
	/// <para>Remove Suitability Criteria</para>
	/// <para>Removes criteria from a suitability analysis layer.</para>
	/// </summary>
	public class RemoveSuitabilityCriteria : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InAnalysisLayer">
		/// <para>Input Suitability Analysis Layer</para>
		/// <para>The suitability analysis layer from which criteria will be removed.</para>
		/// </param>
		/// <param name="DropCriteria">
		/// <para>Drop Criteria</para>
		/// <para>A list of criteria to be removed from a suitability analysis layer.</para>
		/// </param>
		public RemoveSuitabilityCriteria(object InAnalysisLayer, object DropCriteria)
		{
			this.InAnalysisLayer = InAnalysisLayer;
			this.DropCriteria = DropCriteria;
		}

		/// <summary>
		/// <para>Tool Display Name : Remove Suitability Criteria</para>
		/// </summary>
		public override string DisplayName() => "Remove Suitability Criteria";

		/// <summary>
		/// <para>Tool Name : RemoveSuitabilityCriteria</para>
		/// </summary>
		public override string ToolName() => "RemoveSuitabilityCriteria";

		/// <summary>
		/// <para>Tool Excute Name : ba.RemoveSuitabilityCriteria</para>
		/// </summary>
		public override string ExcuteName() => "ba.RemoveSuitabilityCriteria";

		/// <summary>
		/// <para>Toolbox Display Name : Business Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Business Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ba</para>
		/// </summary>
		public override string ToolboxAlise() => "ba";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InAnalysisLayer, DropCriteria, UpdatedAnalysisLayer };

		/// <summary>
		/// <para>Input Suitability Analysis Layer</para>
		/// <para>The suitability analysis layer from which criteria will be removed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Drop Criteria</para>
		/// <para>A list of criteria to be removed from a suitability analysis layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object DropCriteria { get; set; }

		/// <summary>
		/// <para>Output Suitability Analysis Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object UpdatedAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RemoveSuitabilityCriteria SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
