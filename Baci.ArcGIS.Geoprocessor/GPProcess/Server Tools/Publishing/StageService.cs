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
	/// <para>过渡服务</para>
	/// <para>过渡服务定义。 过渡的服务定义文件 (.sd) 包含用于共享 Web 图层、Web 工具或服务的所有必要信息。</para>
	/// </summary>
	public class StageService : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InServiceDefinitionDraft">
		/// <para>Service Definition Draft</para>
		/// <para>输入草稿服务定义。 可以使用 arcpy.sharing 模块或 CreateGeocodeSDDraft、CreateGPSDDraft 或 CreateImageSDDraft ArcPy 函数创建服务定义草稿。</para>
		/// </param>
		/// <param name="OutServiceDefinition">
		/// <para>Service Definition</para>
		/// <para>生成的服务定义。 默认情况下，服务定义将写入与服务定义草稿相同的目录中。</para>
		/// </param>
		public StageService(object InServiceDefinitionDraft, object OutServiceDefinition)
		{
			this.InServiceDefinitionDraft = InServiceDefinitionDraft;
			this.OutServiceDefinition = OutServiceDefinition;
		}

		/// <summary>
		/// <para>Tool Display Name : 过渡服务</para>
		/// </summary>
		public override string DisplayName() => "过渡服务";

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
		/// <para>输入草稿服务定义。 可以使用 arcpy.sharing 模块或 CreateGeocodeSDDraft、CreateGPSDDraft 或 CreateImageSDDraft ArcPy 函数创建服务定义草稿。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("sddraft")]
		public object InServiceDefinitionDraft { get; set; }

		/// <summary>
		/// <para>Service Definition</para>
		/// <para>生成的服务定义。 默认情况下，服务定义将写入与服务定义草稿相同的目录中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("sd", "tpk", "sds")]
		public object OutServiceDefinition { get; set; }

		/// <summary>
		/// <para>Staging Version</para>
		/// <para>发布的服务定义版本。</para>
		/// <para>在将要素、切片或影像图层共享至 ArcGIS Enterprise 时，使用值 5。 在将地图影像图层或 Web 工具共享至 ArcGIS Enterprise 以及将任何图层类型共享至 ArcGIS Online 时，使用 102。 这是默认设置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 3, Max = 2147483647)]
		public object StagingVersion { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public StageService SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
