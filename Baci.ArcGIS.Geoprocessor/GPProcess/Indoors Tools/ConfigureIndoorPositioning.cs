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
	/// <para>Configure Indoor Positioning</para>
	/// <para>Writes indoor positioning system configuration information to an ArcGIS Indoors geodatabase. The values are used by ArcGIS Indoors for iOS and ArcGIS Indoors for Android.</para>
	/// </summary>
	[Obsolete()]
	public class ConfigureIndoorPositioning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InGeodatabase">
		/// <para>Input Geodatabase</para>
		/// <para>The Indoors file or enterprise geodatabase for which IPS configuration information will be generated.</para>
		/// </param>
		/// <param name="EncryptionKey">
		/// <para>Encryption Key</para>
		/// <para>The key used by the tool and Indoors mobile apps to encrypt or unencrypt the API Key parameter (api_key in Python) value.</para>
		/// </param>
		/// <param name="ApiKey">
		/// <para>API Key</para>
		/// <para>A unique value in the form of a GUID used by Indoors mobile apps to enable Indoo.rs indoor positioning. The API key is provided by Indoo.rs.</para>
		/// </param>
		/// <param name="BuildingId">
		/// <para>Building ID</para>
		/// <para>A unique alphanumerical value used by Indoors mobile apps to link the site in the mobile map package to the Indoo.rs indoor positioning survey. The building ID is provided by Indoo.rs.</para>
		/// </param>
		public ConfigureIndoorPositioning(object InGeodatabase, object EncryptionKey, object ApiKey, object BuildingId)
		{
			this.InGeodatabase = InGeodatabase;
			this.EncryptionKey = EncryptionKey;
			this.ApiKey = ApiKey;
			this.BuildingId = BuildingId;
		}

		/// <summary>
		/// <para>Tool Display Name : Configure Indoor Positioning</para>
		/// </summary>
		public override string DisplayName() => "Configure Indoor Positioning";

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
		/// <para>The Indoors file or enterprise geodatabase for which IPS configuration information will be generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object InGeodatabase { get; set; }

		/// <summary>
		/// <para>Encryption Key</para>
		/// <para>The key used by the tool and Indoors mobile apps to encrypt or unencrypt the API Key parameter (api_key in Python) value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object EncryptionKey { get; set; }

		/// <summary>
		/// <para>API Key</para>
		/// <para>A unique value in the form of a GUID used by Indoors mobile apps to enable Indoo.rs indoor positioning. The API key is provided by Indoo.rs.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ApiKey { get; set; }

		/// <summary>
		/// <para>Building ID</para>
		/// <para>A unique alphanumerical value used by Indoors mobile apps to link the site in the mobile map package to the Indoo.rs indoor positioning survey. The building ID is provided by Indoo.rs.</para>
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
