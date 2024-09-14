using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Validate Scene Layer</para>
	/// <para>验证场景图层</para>
	/// <para>评估场景图层包文件 (*.slpk)，以确定其是否符合 I3S 规范。</para>
	/// </summary>
	public class ValidateSceneLayerPackage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSlpk">
		/// <para>Input Scene Layer</para>
		/// <para>将进行评估的场景图层包文件。</para>
		/// </param>
		/// <param name="OutReport">
		/// <para>Output Log File</para>
		/// <para>用于汇总评估结果的输出日志文件。</para>
		/// </param>
		public ValidateSceneLayerPackage(object InSlpk, object OutReport)
		{
			this.InSlpk = InSlpk;
			this.OutReport = OutReport;
		}

		/// <summary>
		/// <para>Tool Display Name : 验证场景图层</para>
		/// </summary>
		public override string DisplayName() => "验证场景图层";

		/// <summary>
		/// <para>Tool Name : ValidateSceneLayerPackage</para>
		/// </summary>
		public override string ToolName() => "ValidateSceneLayerPackage";

		/// <summary>
		/// <para>Tool Excute Name : management.ValidateSceneLayerPackage</para>
		/// </summary>
		public override string ExcuteName() => "management.ValidateSceneLayerPackage";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSlpk, OutReport };

		/// <summary>
		/// <para>Input Scene Layer</para>
		/// <para>将进行评估的场景图层包文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("SLPK", "SPK")]
		public object InSlpk { get; set; }

		/// <summary>
		/// <para>Output Log File</para>
		/// <para>用于汇总评估结果的输出日志文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("json", "txt", "xml")]
		public object OutReport { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ValidateSceneLayerPackage SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
