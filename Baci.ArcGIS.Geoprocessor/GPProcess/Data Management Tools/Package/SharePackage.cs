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
	/// <para>Share Package</para>
	/// <para>共享包</para>
	/// <para>通过将包上传到 ArcGIS Online 或 ArcGIS Enterprise 对其进行共享。</para>
	/// </summary>
	public class SharePackage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPackage">
		/// <para>Input Package</para>
		/// <para>输入图层（.lpk 或 .lpkx）、场景图层 (.slpk)、地图（.mpk 或 .mpkx）、地理处理（.gpk、.gpkx）、切片（.tpk 或 .tpkx）、移动地图 (.mmpk)、矢量切片 (.vtpk)、地址定位器 (.gcpk) 或工程（.ppkx 或 .aptx）包文件。</para>
		/// </param>
		/// <param name="Username">
		/// <para>Username</para>
		/// <para>ArcGIS Online 或 Portal for ArcGIS 用户名。</para>
		/// <para>工具对话框中不包含此参数。 您必须从应用程序右上角的登录选项登录到活动门户。</para>
		/// </param>
		/// <param name="Password">
		/// <para>Password</para>
		/// <para>ArcGIS Online 或 ArcGIS Enterprise 密码。</para>
		/// <para>工具对话框中不包含此参数。 您必须从应用程序右上角的登录选项登录到活动门户。</para>
		/// </param>
		public SharePackage(object InPackage, object Username, object Password)
		{
			this.InPackage = InPackage;
			this.Username = Username;
			this.Password = Password;
		}

		/// <summary>
		/// <para>Tool Display Name : 共享包</para>
		/// </summary>
		public override string DisplayName() => "共享包";

		/// <summary>
		/// <para>Tool Name : SharePackage</para>
		/// </summary>
		public override string ToolName() => "SharePackage";

		/// <summary>
		/// <para>Tool Excute Name : management.SharePackage</para>
		/// </summary>
		public override string ExcuteName() => "management.SharePackage";

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
		public override object[] Parameters() => new object[] { InPackage, Username, Password, Summary!, Tags!, Credits!, Public!, Groups!, OutResults!, Organization!, PublishWebLayer!, PublishResults!, PackageItemId!, PortalFolder! };

		/// <summary>
		/// <para>Input Package</para>
		/// <para>输入图层（.lpk 或 .lpkx）、场景图层 (.slpk)、地图（.mpk 或 .mpkx）、地理处理（.gpk、.gpkx）、切片（.tpk 或 .tpkx）、移动地图 (.mmpk)、矢量切片 (.vtpk)、地址定位器 (.gcpk) 或工程（.ppkx 或 .aptx）包文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("lpkx", "mpkx", "gpkx", "mmpk", "mspk", "ppkx", "aptx", "lpk", "mpk", "gpk", "gcpk", "tpk", "tpkx", "spk", "slpk", "vtpk")]
		public object InPackage { get; set; }

		/// <summary>
		/// <para>Username</para>
		/// <para>ArcGIS Online 或 Portal for ArcGIS 用户名。</para>
		/// <para>工具对话框中不包含此参数。 您必须从应用程序右上角的登录选项登录到活动门户。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Username { get; set; }

		/// <summary>
		/// <para>Password</para>
		/// <para>ArcGIS Online 或 ArcGIS Enterprise 密码。</para>
		/// <para>工具对话框中不包含此参数。 您必须从应用程序右上角的登录选项登录到活动门户。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPEncryptedString()]
		public object Password { get; set; }

		/// <summary>
		/// <para>Summary</para>
		/// <para>包的摘要信息。 在 ArcGIS Online 或 ArcGIS Enterprise 上，摘要信息将显示在数据包的项目信息中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Summary { get; set; }

		/// <summary>
		/// <para>Tags</para>
		/// <para>用于描述和识别包的标记。 各个标签之间将以逗号或分号进行分隔。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Tags { get; set; }

		/// <summary>
		/// <para>Credits</para>
		/// <para>包的制作者。 通常是创作和提供包内容的组织的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Credits { get; set; }

		/// <summary>
		/// <para>Share with everyone</para>
		/// <para>指定是否将输入包共享并提供给所有人。</para>
		/// <para>选中 - 输入包将共享给所有人。</para>
		/// <para>未选中 - 输入包将共享给包的所有者及选中的任意群组。 这是默认设置。</para>
		/// <para><see cref="PublicEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Public { get; set; } = "false";

		/// <summary>
		/// <para>Groups</para>
		/// <para>将与其共享包的群组。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? Groups { get; set; }

		/// <summary>
		/// <para>Tool Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object? OutResults { get; set; } = "false";

		/// <summary>
		/// <para>Share within organization only</para>
		/// <para>指定输入包仅可用于组织内部还是公开共享给所有人。</para>
		/// <para>所有人—将包共享给所有人。 这是默认设置。</para>
		/// <para>在我的组织中—包将仅在组织内部共享。</para>
		/// <para><see cref="OrganizationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Organization { get; set; } = "false";

		/// <summary>
		/// <para>Publish web layer</para>
		/// <para>指定是否将包作为 Web 图层发布到门户。 仅支持切片包、矢量切片包和场景图层包。</para>
		/// <para>未选中 - 包将被上传且不被发布。 这是默认设置。</para>
		/// <para>选中 - 包将被上传并发布为具有相同名称的 web 图层。</para>
		/// <para><see cref="PublishWebLayerEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? PublishWebLayer { get; set; } = "false";

		/// <summary>
		/// <para>Publish Results</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? PublishResults { get; set; }

		/// <summary>
		/// <para>Package Item ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? PackageItemId { get; set; }

		/// <summary>
		/// <para>Folder</para>
		/// <para>包在门户上的现有文件夹或新文件夹的名称。 如果发布了 Web 图层，则系统会将其存储在同一文件夹中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? PortalFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SharePackage SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Share with everyone</para>
		/// </summary>
		public enum PublicEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EVERYBODY")]
			EVERYBODY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("MYGROUPS")]
			MYGROUPS,

		}

		/// <summary>
		/// <para>Share within organization only</para>
		/// </summary>
		public enum OrganizationEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EVERYBODY")]
			EVERYBODY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("MYORGANIZATION")]
			MYORGANIZATION,

		}

		/// <summary>
		/// <para>Publish web layer</para>
		/// </summary>
		public enum PublishWebLayerEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("TRUE")]
			TRUE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("FALSE")]
			FALSE,

		}

#endregion
	}
}
