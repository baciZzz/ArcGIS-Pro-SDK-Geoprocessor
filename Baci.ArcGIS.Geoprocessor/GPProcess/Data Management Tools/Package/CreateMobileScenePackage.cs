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
	/// <para>Create Mobile Scene Package</para>
	/// <para>创建移动场景包</para>
	/// <para>从一个或多个场景创建移动场景包 (.mspk)，用于整个 ArcGIS 平台。</para>
	/// </summary>
	public class CreateMobileScenePackage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InScene">
		/// <para>Input Scene</para>
		/// <para>将打包到一个 .mspk 文件中的一个或多个局部或全球场景。 可以将活动场景和 .mapx 文件作为输入添加。</para>
		/// </param>
		/// <param name="OutputFile">
		/// <para>Output File</para>
		/// <para>输出移动场景包 .mspk 文件。</para>
		/// </param>
		public CreateMobileScenePackage(object InScene, object OutputFile)
		{
			this.InScene = InScene;
			this.OutputFile = OutputFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建移动场景包</para>
		/// </summary>
		public override string DisplayName() => "创建移动场景包";

		/// <summary>
		/// <para>Tool Name : CreateMobileScenePackage</para>
		/// </summary>
		public override string ToolName() => "CreateMobileScenePackage";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateMobileScenePackage</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateMobileScenePackage";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InScene, OutputFile, InLocator!, AreaOfInterest!, Extent!, ClipFeatures!, Title!, Summary!, Description!, Tags!, Credits!, UseLimitations!, AnonymousUse!, TextureOptimization!, EnableSceneExpiration!, SceneExpirationType!, ExpirationDate!, ExpirationMessage!, SelectRelatedRows!, ReferenceOnlineContent! };

		/// <summary>
		/// <para>Input Scene</para>
		/// <para>将打包到一个 .mspk 文件中的一个或多个局部或全球场景。 可以将活动场景和 .mapx 文件作为输入添加。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPMapDomain()]
		[MapType("1")]
		public object InScene { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>输出移动场景包 .mspk 文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("mspk")]
		public object OutputFile { get; set; }

		/// <summary>
		/// <para>Input Locator</para>
		/// <para>定位器具有以下限制：</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPLocatorsDomain()]
		public object? InLocator { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>定义感兴趣区域的面图层。 仅与感兴趣区域相交的要素才会包括在移动场景包中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object? AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Extent</para>
		/// <para>指定用于选择或裁剪要素的范围。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>输入的并集 - 该范围将基于所有输入的最大范围。</para>
		/// <para>输入的交集 - 该范围将基于所有输入共用的最小区域。</para>
		/// <para>当前显示范围 - 该范围与可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object? Extent { get; set; }

		/// <summary>
		/// <para>Clip Features</para>
		/// <para>指定是否将输出要素裁剪为给定的感兴趣区域或范围。</para>
		/// <para>已选中 - 要素的几何将裁剪为给定的感兴趣区或范围。</para>
		/// <para>未选中 - 将选中场景中的要素且其几何仍保持不变。 这是默认设置。</para>
		/// <para>多面体要素图层、3D 点要素图层、LAS 数据集图层、服务图层和切片包无法进行裁剪，将整个复制到移动场景包。</para>
		/// <para><see cref="ClipFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ClipFeatures { get; set; } = "false";

		/// <summary>
		/// <para>Title</para>
		/// <para>将添加到包属性的标题信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Title { get; set; }

		/// <summary>
		/// <para>Summary</para>
		/// <para>将添加到包属性的摘要信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Summary { get; set; }

		/// <summary>
		/// <para>Description</para>
		/// <para>将添加到包属性的描述信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Description { get; set; }

		/// <summary>
		/// <para>Tags</para>
		/// <para>将添加到包属性的标签信息。 可以添加多个标签，用逗号或分号分隔。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Tags { get; set; }

		/// <summary>
		/// <para>Credits</para>
		/// <para>将添加到包属性的制作者名单信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Credits { get; set; }

		/// <summary>
		/// <para>Use Limitations</para>
		/// <para>将添加到包属性的使用限制。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? UseLimitations { get; set; }

		/// <summary>
		/// <para>Enable Anonymous Use</para>
		/// <para>指定所有人或仅具有 ArcGIS 帐户的人员可以使用移动场景。</para>
		/// <para>选中 - 具有包访问权限的所有人均可使用移动场景，无需使用 Esri 指定用户帐户进行登录。</para>
		/// <para>未选中 - 具有包访问权限的所有人必须使用指定用户帐户进行登录，才能使用移动场景。 这是默认设置。</para>
		/// <para>此可选参数仅适用于 Publisher 扩展模块。</para>
		/// <para><see cref="AnonymousUseEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AnonymousUse { get; set; } = "false";

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

		/// <summary>
		/// <para>Enable Scene Expiration</para>
		/// <para>指定移动场景包是否超时。</para>
		/// <para>选中 - 将在移动场景包上启用超时功能。</para>
		/// <para>未选中 - 不会在移动场景包上启用超时功能。 这是默认设置。</para>
		/// <para>此可选参数仅适用于 Publisher 扩展模块。</para>
		/// <para><see cref="EnableSceneExpirationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? EnableSceneExpiration { get; set; } = "false";

		/// <summary>
		/// <para>Scene Expiration Type</para>
		/// <para>指定将用于已到期移动场景包的场景访问类型。</para>
		/// <para>允许打开—将警告包用户此场景已到期，且允许打开场景。 这是默认设置。</para>
		/// <para>不允许打开—将警告包用户此场景已到期，且不允许打开包。</para>
		/// <para>此可选参数仅适用于 Publisher 扩展模块。</para>
		/// <para><see cref="SceneExpirationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SceneExpirationType { get; set; } = "ALLOW_TO_OPEN";

		/// <summary>
		/// <para>Expiration Date</para>
		/// <para>移动场景包的到期日期。</para>
		/// <para>此可选参数仅适用于 Publisher 扩展模块。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? ExpirationDate { get; set; }

		/// <summary>
		/// <para>Expiration Message</para>
		/// <para>访问已到期场景时将显示的文本消息。</para>
		/// <para>此可选参数仅适用于 Publisher 扩展模块。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ExpirationMessage { get; set; } = "This scene is expired, Contact the scene publisher for an updated scene";

		/// <summary>
		/// <para>Keep only the rows which are related to features within the extent</para>
		/// <para>指定是否将指定的范围应用至相关数据源。</para>
		/// <para>未选中 - 相关的数据源将全部合并。 这是默认设置。</para>
		/// <para>选中 - 仅合并指定范围内与记录对应的相关数据。</para>
		/// <para><see cref="SelectRelatedRowsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SelectRelatedRows { get; set; } = "false";

		/// <summary>
		/// <para>Reference Online Content</para>
		/// <para>指定是否在包中引用服务图层。</para>
		/// <para>未选中 - 将不会在移动包中引用服务图层。 这是默认设置。</para>
		/// <para>选中 - 将在移动包中引用服务图层。</para>
		/// <para><see cref="ReferenceOnlineContentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ReferenceOnlineContent { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateMobileScenePackage SetEnviroment(object? parallelProcessingFactor = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Clip Features</para>
		/// </summary>
		public enum ClipFeaturesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CLIP")]
			CLIP,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("SELECT")]
			SELECT,

		}

		/// <summary>
		/// <para>Enable Anonymous Use</para>
		/// </summary>
		public enum AnonymousUseEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ANONYMOUS_USE")]
			ANONYMOUS_USE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("STANDARD")]
			STANDARD,

		}

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

			/// <summary>
			/// <para>无—JPEG 纹理将进行优化，可用于桌面和 web 平台。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

		}

		/// <summary>
		/// <para>Enable Scene Expiration</para>
		/// </summary>
		public enum EnableSceneExpirationEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ENABLE_SCENE_EXPIRATION")]
			ENABLE_SCENE_EXPIRATION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DISABLE_SCENE_EXPIRATION")]
			DISABLE_SCENE_EXPIRATION,

		}

		/// <summary>
		/// <para>Scene Expiration Type</para>
		/// </summary>
		public enum SceneExpirationTypeEnum 
		{
			/// <summary>
			/// <para>允许打开—将警告包用户此场景已到期，且允许打开场景。 这是默认设置。</para>
			/// </summary>
			[GPValue("ALLOW_TO_OPEN")]
			[Description("允许打开")]
			Allow_to_open,

			/// <summary>
			/// <para>不允许打开—将警告包用户此场景已到期，且不允许打开包。</para>
			/// </summary>
			[GPValue("DONOT_ALLOW_TO_OPEN")]
			[Description("不允许打开")]
			Do_not_allow_to_open,

		}

		/// <summary>
		/// <para>Keep only the rows which are related to features within the extent</para>
		/// </summary>
		public enum SelectRelatedRowsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_ONLY_RELATED_ROWS")]
			KEEP_ONLY_RELATED_ROWS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_ALL_RELATED_ROWS")]
			KEEP_ALL_RELATED_ROWS,

		}

		/// <summary>
		/// <para>Reference Online Content</para>
		/// </summary>
		public enum ReferenceOnlineContentEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_SERVICE_LAYERS")]
			INCLUDE_SERVICE_LAYERS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_SERVICE_LAYERS")]
			EXCLUDE_SERVICE_LAYERS,

		}

#endregion
	}
}
