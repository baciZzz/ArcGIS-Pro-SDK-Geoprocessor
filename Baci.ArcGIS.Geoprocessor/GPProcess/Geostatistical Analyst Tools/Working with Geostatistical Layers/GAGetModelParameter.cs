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
	/// <para>获取模型参数</para>
	/// <para>从现有的地统计模型源获取模型参数值。</para>
	/// </summary>
	public class GAGetModelParameter : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGaModelSource">
		/// <para>Input geostatistical model source</para>
		/// <para>要分析的地统计模型源。</para>
		/// </param>
		/// <param name="ModelParamXpath">
		/// <para>Parameter XML Path</para>
		/// <para>所需模型参数的 XML 路径。</para>
		/// </param>
		public GAGetModelParameter(object InGaModelSource, object ModelParamXpath)
		{
			this.InGaModelSource = InGaModelSource;
			this.ModelParamXpath = ModelParamXpath;
		}

		/// <summary>
		/// <para>Tool Display Name : 获取模型参数</para>
		/// </summary>
		public override string DisplayName() => "获取模型参数";

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
		/// <para>要分析的地统计模型源。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InGaModelSource { get; set; }

		/// <summary>
		/// <para>Parameter XML Path</para>
		/// <para>所需模型参数的 XML 路径。</para>
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
