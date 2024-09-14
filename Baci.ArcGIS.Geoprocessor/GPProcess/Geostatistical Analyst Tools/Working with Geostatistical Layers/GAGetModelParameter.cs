using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeostatisticalAnalystTools
{
	/// <summary>
	/// <para>Get Model Parameter</para>
	/// <para>Get Model Parameter</para>
	/// <para>Gets model parameter value from an existing geostatistical model source.</para>
	/// </summary>
	public class GAGetModelParameter : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGaModelSource">
		/// <para>Input geostatistical model source</para>
		/// <para>The geostatistical model source to be analyzed.</para>
		/// </param>
		/// <param name="ModelParamXpath">
		/// <para>Parameter XML Path</para>
		/// <para>XML path to the required model parameter.</para>
		/// </param>
		public GAGetModelParameter(object InGaModelSource, object ModelParamXpath)
		{
			this.InGaModelSource = InGaModelSource;
			this.ModelParamXpath = ModelParamXpath;
		}

		/// <summary>
		/// <para>Tool Display Name : Get Model Parameter</para>
		/// </summary>
		public override string DisplayName() => "Get Model Parameter";

		/// <summary>
		/// <para>Tool Name : GAGetModelParameter</para>
		/// </summary>
		public override string ToolName() => "GAGetModelParameter";

		/// <summary>
		/// <para>Tool Excute Name : ga.GAGetModelParameter</para>
		/// </summary>
		public override string ExcuteName() => "ga.GAGetModelParameter";

		/// <summary>
		/// <para>Toolbox Display Name : Geostatistical Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Geostatistical Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ga</para>
		/// </summary>
		public override string ToolboxAlise() => "ga";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGaModelSource, ModelParamXpath, OutParamValue! };

		/// <summary>
		/// <para>Input geostatistical model source</para>
		/// <para>The geostatistical model source to be analyzed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InGaModelSource { get; set; }

		/// <summary>
		/// <para>Parameter XML Path</para>
		/// <para>XML path to the required model parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ModelParamXpath { get; set; }

		/// <summary>
		/// <para>Parameter value</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutParamValue { get; set; } = " ";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GAGetModelParameter SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
