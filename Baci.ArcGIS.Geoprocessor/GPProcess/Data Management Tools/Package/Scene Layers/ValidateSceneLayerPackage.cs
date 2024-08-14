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
	/// <para>Evaluates a scene layer package file (*.slpk) to determine its conformity to I3S specification.</para>
	/// </summary>
	public class ValidateSceneLayerPackage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSlpk">
		/// <para>Input Scene Layer</para>
		/// <para>The scene layer package file that will be evaluated.</para>
		/// </param>
		/// <param name="OutReport">
		/// <para>Output Log File</para>
		/// <para>The output log file that will summarize the results of the evaluation.</para>
		/// </param>
		public ValidateSceneLayerPackage(object InSlpk, object OutReport)
		{
			this.InSlpk = InSlpk;
			this.OutReport = OutReport;
		}

		/// <summary>
		/// <para>Tool Display Name : Validate Scene Layer</para>
		/// </summary>
		public override string DisplayName => "Validate Scene Layer";

		/// <summary>
		/// <para>Tool Name : ValidateSceneLayerPackage</para>
		/// </summary>
		public override string ToolName => "ValidateSceneLayerPackage";

		/// <summary>
		/// <para>Tool Excute Name : management.ValidateSceneLayerPackage</para>
		/// </summary>
		public override string ExcuteName => "management.ValidateSceneLayerPackage";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InSlpk, OutReport };

		/// <summary>
		/// <para>Input Scene Layer</para>
		/// <para>The scene layer package file that will be evaluated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object InSlpk { get; set; }

		/// <summary>
		/// <para>Output Log File</para>
		/// <para>The output log file that will summarize the results of the evaluation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutReport { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ValidateSceneLayerPackage SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
