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
	/// <para>Validate Scene Layer</para>
	/// <para>Evaluates a scene layer package (*.slpk or *.i3sREST) in a cloud store to determine its conformity to I3S specifications.</para>
	/// </summary>
	public class ValidateSceneLayerPackage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutReport">
		/// <para>Output Log File</para>
		/// <para>The output log file that will summarize the results of the evaluation.</para>
		/// </param>
		public ValidateSceneLayerPackage(object OutReport)
		{
			this.OutReport = OutReport;
		}

		/// <summary>
		/// <para>Tool Display Name : Validate Scene Layer</para>
		/// </summary>
		public override string DisplayName() => "Validate Scene Layer";

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
		public override object[] Parameters() => new object[] { InSlpk!, OutReport, InFolder! };

		/// <summary>
		/// <para>Input Scene Layer</para>
		/// <para>The scene layer package (*.slpk) that will be evaluated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("SLPK", "SPK")]
		public object? InSlpk { get; set; }

		/// <summary>
		/// <para>Output Log File</para>
		/// <para>The output log file that will summarize the results of the evaluation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("json", "txt", "xml")]
		public object OutReport { get; set; }

		/// <summary>
		/// <para>Input Folder</para>
		/// <para>The scene layer content (*.i3sREST) in a cloud store that will be evaluated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object? InFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ValidateSceneLayerPackage SetEnviroment(object? workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
