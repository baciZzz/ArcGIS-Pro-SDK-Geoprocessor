using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.IndoorsTools
{
	/// <summary>
	/// <para>Configure Indoor Positioning</para>
	/// <para>配置室内定位</para>
	/// <para>用于将室内定位系统配置信息写入 ArcGIS Indoors 地理数据库。 这些值由 ArcGIS Indoors for iOS 和 ArcGIS Indoors for Android 使用。</para>
	/// </summary>
	[Obsolete()]
	public class ConfigureIndoorPositioning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeodatabase">
		/// <para>Input Geodatabase</para>
		/// <para>将为其生成 IPS 配置信息的 Indoors 文件或企业级地理数据库。</para>
		/// </param>
		/// <param name="EncryptionKey">
		/// <para>Encryption Key</para>
		/// <para>该工具和 Indoors 移动应用程序使用的密钥，用于对 API 密钥参数（Python 中的 api_key）值进行加密或解密。</para>
		/// </param>
		/// <param name="ApiKey">
		/// <para>API Key</para>
		/// <para>采用 GUID 形式的唯一值，由 Indoors 移动应用程序用于启用 Indoo.rs 室内定位。 API 密钥由 Indoo.rs 提供。</para>
		/// </param>
		/// <param name="BuildingId">
		/// <para>Building ID</para>
		/// <para>Indoors 移动应用程序使用的唯一字母数字值，用于将移动地图包中的站点链接到 Indoo.rs 室内定位调查。 建筑物 ID 由 Indoo.rs 提供。</para>
		/// </param>
		public ConfigureIndoorPositioning(object InGeodatabase, object EncryptionKey, object ApiKey, object BuildingId)
		{
			this.InGeodatabase = InGeodatabase;
			this.EncryptionKey = EncryptionKey;
			this.ApiKey = ApiKey;
			this.BuildingId = BuildingId;
		}

		/// <summary>
		/// <para>Tool Display Name : 配置室内定位</para>
		/// </summary>
		public override string DisplayName() => "配置室内定位";

		/// <summary>
		/// <para>Tool Name : ConfigureIndoorPositioning</para>
		/// </summary>
		public override string ToolName() => "ConfigureIndoorPositioning";

		/// <summary>
		/// <para>Tool Excute Name : indoors.ConfigureIndoorPositioning</para>
		/// </summary>
		public override string ExcuteName() => "indoors.ConfigureIndoorPositioning";

		/// <summary>
		/// <para>Toolbox Display Name : Indoors Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Indoors Tools";

		/// <summary>
		/// <para>Toolbox Alise : indoors</para>
		/// </summary>
		public override string ToolboxAlise() => "indoors";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InGeodatabase, EncryptionKey, ApiKey, BuildingId, UpdatedGdb! };

		/// <summary>
		/// <para>Input Geodatabase</para>
		/// <para>将为其生成 IPS 配置信息的 Indoors 文件或企业级地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object InGeodatabase { get; set; }

		/// <summary>
		/// <para>Encryption Key</para>
		/// <para>该工具和 Indoors 移动应用程序使用的密钥，用于对 API 密钥参数（Python 中的 api_key）值进行加密或解密。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object EncryptionKey { get; set; }

		/// <summary>
		/// <para>API Key</para>
		/// <para>采用 GUID 形式的唯一值，由 Indoors 移动应用程序用于启用 Indoo.rs 室内定位。 API 密钥由 Indoo.rs 提供。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ApiKey { get; set; }

		/// <summary>
		/// <para>Building ID</para>
		/// <para>Indoors 移动应用程序使用的唯一字母数字值，用于将移动地图包中的站点链接到 Indoo.rs 室内定位调查。 建筑物 ID 由 Indoo.rs 提供。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object BuildingId { get; set; }

		/// <summary>
		/// <para>Updated Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? UpdatedGdb { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConfigureIndoorPositioning SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
