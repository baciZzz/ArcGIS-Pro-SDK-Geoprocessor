using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ServerTools
{
	/// <summary>
	/// <para>Stage Service</para>
	/// <para>Stage Service</para>
	/// <para>Stages a service definition. A staged service definition file (.sd) contains all the necessary information to share a web layer, web tool, or service.</para>
	/// </summary>
	public class StageService : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InServiceDefinitionDraft">
		/// <para>Service Definition Draft</para>
		/// <para>The input draft service definition. Service definition drafts can be created using the arcpy.sharing module or the CreateGeocodeSDDraft, CreateGPSDDraft, or CreateImageSDDraft ArcPy functions.</para>
		/// </param>
		/// <param name="OutServiceDefinition">
		/// <para>Service Definition</para>
		/// <para>The resulting service definition. The default is to write the service definition to the same directory as the draft service definition.</para>
		/// </param>
		public StageService(object InServiceDefinitionDraft, object OutServiceDefinition)
		{
			this.InServiceDefinitionDraft = InServiceDefinitionDraft;
			this.OutServiceDefinition = OutServiceDefinition;
		}

		/// <summary>
		/// <para>Tool Display Name : Stage Service</para>
		/// </summary>
		public override string DisplayName() => "Stage Service";

		/// <summary>
		/// <para>Tool Name : StageService</para>
		/// </summary>
		public override string ToolName() => "StageService";

		/// <summary>
		/// <para>Tool Excute Name : server.StageService</para>
		/// </summary>
		public override string ExcuteName() => "server.StageService";

		/// <summary>
		/// <para>Toolbox Display Name : Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : server</para>
		/// </summary>
		public override string ToolboxAlise() => "server";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InServiceDefinitionDraft, OutServiceDefinition, StagingVersion };

		/// <summary>
		/// <para>Service Definition Draft</para>
		/// <para>The input draft service definition. Service definition drafts can be created using the arcpy.sharing module or the CreateGeocodeSDDraft, CreateGPSDDraft, or CreateImageSDDraft ArcPy functions.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("sddraft")]
		public object InServiceDefinitionDraft { get; set; }

		/// <summary>
		/// <para>Service Definition</para>
		/// <para>The resulting service definition. The default is to write the service definition to the same directory as the draft service definition.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("sd", "tpk", "sds")]
		public object OutServiceDefinition { get; set; }

		/// <summary>
		/// <para>Staging Version</para>
		/// <para>The version of the published service definition.</para>
		/// <para>When sharing a feature, a tile, or an imagery layer to ArcGIS Enterprise, use 5 for the value. When sharing a map image layer or web tool to ArcGIS Enterprise, and any layer type to ArcGIS Online, use 102. This is the default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 3, Max = 2147483647)]
		public object StagingVersion { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public StageService SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
