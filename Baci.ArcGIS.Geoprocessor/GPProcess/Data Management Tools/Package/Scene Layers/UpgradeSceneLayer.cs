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
	/// <para>Upgrade Scene Layer</para>
	/// <para>升级场景图层</para>
	/// <para>用于将场景图层包升级为 SLPK 格式的当前 I3S 版本，或输出到 i3sREST 以用于 ArcGIS Enterprise。</para>
	/// </summary>
	public class UpgradeSceneLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDataset">
		/// <para>Input Dataset</para>
		/// <para>输入场景图层包。</para>
		/// </param>
		/// <param name="OutFolderPath">
		/// <para>Output Folder</para>
		/// <para>将在其中创建输出场景图层包的位置，或要输出到 i3sREST 的云连接文件 (.acs)。</para>
		/// </param>
		/// <param name="OutName">
		/// <para>Output Name</para>
		/// <para>输出场景图层名称。</para>
		/// </param>
		public UpgradeSceneLayer(object InDataset, object OutFolderPath, object OutName)
		{
			this.InDataset = InDataset;
			this.OutFolderPath = OutFolderPath;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : 升级场景图层</para>
		/// </summary>
		public override string DisplayName() => "升级场景图层";

		/// <summary>
		/// <para>Tool Name : UpgradeSceneLayer</para>
		/// </summary>
		public override string ToolName() => "UpgradeSceneLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.UpgradeSceneLayer</para>
		/// </summary>
		public override string ExcuteName() => "management.UpgradeSceneLayer";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDataset, OutFolderPath, OutName, OutLog!, TextureOptimization! };

		/// <summary>
		/// <para>Input Dataset</para>
		/// <para>输入场景图层包。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("SLPK", "SPK")]
		public object InDataset { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>将在其中创建输出场景图层包的位置，或要输出到 i3sREST 的云连接文件 (.acs)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolderPath { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>输出场景图层名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Output Log File</para>
		/// <para>用于汇总评估结果的输出日志文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("json")]
		public object? OutLog { get; set; }

		/// <summary>
		/// <para>Texture Optimization</para>
		/// <para>指定根据使用场景图层包的目标平台优化的纹理。可能需要大量时间来处理包括 KTX2 的优化。 要获得最快结果，请使用桌面或无选项。</para>
		/// <para>全部—所有用于桌面、Web 和移动平台的纹理格式都将进行优化，包括 JPEG、DXT 和 KTX2。</para>
		/// <para>桌面—支持 Windows、Linux 和 Mac 的纹理都将进行优化，包括 JPEG 和 DXT，可用于 Windows 上的 ArcGIS Pro 客户端和 Windows、Linux 和 Mac 上的 ArcGIS Runtime 桌面客户端。 这是默认设置。</para>
		/// <para>移动—支持 Android 和 iOS 的纹理将进行优化，包括 JPEG 和 KTX2，可用于 ArcGIS Runtime 移动应用程序。</para>
		/// <para>无—JPEG 纹理将进行优化，可用于桌面和 web 平台。</para>
		/// <para><see cref="TextureOptimizationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TextureOptimization { get; set; } = "DESKTOP";

		#region InnerClass

		/// <summary>
		/// <para>Texture Optimization</para>
		/// </summary>
		public enum TextureOptimizationEnum 
		{
			/// <summary>
			/// <para>全部—所有用于桌面、Web 和移动平台的纹理格式都将进行优化，包括 JPEG、DXT 和 KTX2。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("全部")]
			All,

			/// <summary>
			/// <para>无—JPEG 纹理将进行优化，可用于桌面和 web 平台。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>桌面—支持 Windows、Linux 和 Mac 的纹理都将进行优化，包括 JPEG 和 DXT，可用于 Windows 上的 ArcGIS Pro 客户端和 Windows、Linux 和 Mac 上的 ArcGIS Runtime 桌面客户端。 这是默认设置。</para>
			/// </summary>
			[GPValue("DESKTOP")]
			[Description("桌面")]
			Desktop,

			/// <summary>
			/// <para>移动—支持 Android 和 iOS 的纹理将进行优化，包括 JPEG 和 KTX2，可用于 ArcGIS Runtime 移动应用程序。</para>
			/// </summary>
			[GPValue("MOBILE")]
			[Description("移动")]
			Mobile,

		}

#endregion
	}
}
