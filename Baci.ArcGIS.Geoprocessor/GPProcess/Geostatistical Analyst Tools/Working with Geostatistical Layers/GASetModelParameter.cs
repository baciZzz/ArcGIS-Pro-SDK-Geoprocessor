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
	/// <para>Set Model Parameter</para>
	/// <para>设置模型参数</para>
	/// <para>设置现有地统计模型源中的参数值。</para>
	/// </summary>
	public class GASetModelParameter : AbstractGPProcess
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
		/// <param name="InParamValue">
		/// <para>Parameter value</para>
		/// <para>由 XML 路径定义的参数值。</para>
		/// </param>
		/// <param name="OutGaModel">
		/// <para>Output model</para>
		/// <para>利用在 XML 路径中定义的参数值创建的地统计模型。</para>
		/// </param>
		public GASetModelParameter(object InGaModelSource, object ModelParamXpath, object InParamValue, object OutGaModel)
		{
			this.InGaModelSource = InGaModelSource;
			this.ModelParamXpath = ModelParamXpath;
			this.InParamValue = InParamValue;
			this.OutGaModel = OutGaModel;
		}

		/// <summary>
		/// <para>Tool Display Name : 设置模型参数</para>
		/// </summary>
		public override string DisplayName() => "设置模型参数";

		/// <summary>
		/// <para>Tool Name : GASetModelParameter</para>
		/// </summary>
		public override string ToolName() => "GASetModelParameter";

		/// <summary>
		/// <para>Tool Excute Name : ga.GASetModelParameter</para>
		/// </summary>
		public override string ExcuteName() => "ga.GASetModelParameter";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGaModelSource, ModelParamXpath, InParamValue, OutGaModel };

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
		/// <para>由 XML 路径定义的参数值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InParamValue { get; set; }

		/// <summary>
		/// <para>Output model</para>
		/// <para>利用在 XML 路径中定义的参数值创建的地统计模型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml")]
		public object OutGaModel { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GASetModelParameter SetEnviroment(object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
