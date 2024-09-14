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
	/// <para>Create Mobile Map Package</para>
	/// <para>创建移动地图包</para>
	/// <para>将地图和底图以及所有引用的数据源一起打包到一个 .mmpk 文件中。</para>
	/// </summary>
	public class CreateMobileMapPackage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMap">
		/// <para>Input Map</para>
		/// <para>将打包到一个 .mmpk 文件中的一个或多个地图或底图。</para>
		/// </param>
		/// <param name="OutputFile">
		/// <para>Output File</para>
		/// <para>输出移动地图包 (.mmpk)。</para>
		/// </param>
		public CreateMobileMapPackage(object InMap, object OutputFile)
		{
			this.InMap = InMap;
			this.OutputFile = OutputFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建移动地图包</para>
		/// </summary>
		public override string DisplayName() => "创建移动地图包";

		/// <summary>
		/// <para>Tool Name : CreateMobileMapPackage</para>
		/// </summary>
		public override string ToolName() => "CreateMobileMapPackage";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateMobileMapPackage</para>
		/// </summary>
		public override string ExcuteName() => "management.CreateMobileMapPackage";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMap, OutputFile, InLocator!, AreaOfInterest!, Extent!, ClipFeatures!, Title!, Summary!, Description!, Tags!, Credits!, UseLimitations!, AnonymousUse!, EnableMapExpiration!, MapExpirationType!, ExpirationDate!, ExpirationMessage!, SelectRelatedRows!, ReferenceOnlineContent! };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>将打包到一个 .mmpk 文件中的一个或多个地图或底图。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPMapDomain()]
		[MapType("0", "2")]
		public object InMap { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>输出移动地图包 (.mmpk)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("mmpk")]
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
		/// <para>定义感兴趣区域的面图层。 仅与感兴趣区域值相交的要素才会包括在移动地图包中。</para>
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
		/// <para>指定是否将输出要素裁剪为给定的感兴趣区域值或范围值。</para>
		/// <para>选中 - 要素的几何将裁剪为给定的感兴趣区域值或范围值。</para>
		/// <para>未选中 - 将选中地图中的要素且其几何仍保持不变。 这是默认设置。</para>
		/// <para><see cref="ClipFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ClipFeatures { get; set; } = "false";

		/// <summary>
		/// <para>Title</para>
		/// <para>将标题信息添加到包的属性中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Title { get; set; }

		/// <summary>
		/// <para>Summary</para>
		/// <para>将摘要信息添加到包的属性中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Summary { get; set; }

		/// <summary>
		/// <para>Description</para>
		/// <para>将描述信息添加到包的属性中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Description { get; set; }

		/// <summary>
		/// <para>Tags</para>
		/// <para>将标签信息添加到包的属性中。 可以添加多个标签，标签之间用逗号或分号进行分隔。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Tags { get; set; }

		/// <summary>
		/// <para>Credits</para>
		/// <para>将制作者名单信息添加到包的属性中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Credits { get; set; }

		/// <summary>
		/// <para>Use Limitations</para>
		/// <para>将使用限制添加到包的属性中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? UseLimitations { get; set; }

		/// <summary>
		/// <para>Enable Anonymous Use</para>
		/// <para>指定移动地图是否可供所有人使用。</para>
		/// <para>选中 - 具有包访问权限的所有人均可使用移动地图，无需使用 Esri 指定用户帐户进行登录。</para>
		/// <para>未选中 - 具有包访问权限的所有人必须使用指定用户帐户进行登录，才能使用移动地图。 这是默认设置。</para>
		/// <para>此可选参数仅适用于 Publisher 扩展模块。</para>
		/// <para><see cref="AnonymousUseEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AnonymousUse { get; set; } = "false";

		/// <summary>
		/// <para>Enable Map Expiration</para>
		/// <para>指定是否将在移动地图包上启用超时。</para>
		/// <para>选中 - 将在移动地图包上启用超时。</para>
		/// <para>未选中 - 不会在移动地图包上启用超时。 这是默认设置。</para>
		/// <para>此可选参数仅适用于 Publisher 扩展模块。</para>
		/// <para><see cref="EnableMapExpirationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? EnableMapExpiration { get; set; } = "false";

		/// <summary>
		/// <para>Map Expiration Type</para>
		/// <para>指定用户对已到期移动地图包的访问类型。</para>
		/// <para>允许打开—将警告包用户此地图已到期，但仍允许打开地图。 这是默认设置。</para>
		/// <para>不允许打开—将警告包用户此地图已到期，并且不允许打开地图。</para>
		/// <para>此可选参数仅适用于 Publisher 扩展模块。</para>
		/// <para><see cref="MapExpirationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? MapExpirationType { get; set; } = "ALLOW_TO_OPEN";

		/// <summary>
		/// <para>Expiration Date</para>
		/// <para>指定移动地图包的到期日期。</para>
		/// <para>此可选参数仅适用于 Publisher 扩展模块。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? ExpirationDate { get; set; }

		/// <summary>
		/// <para>Expiration Message</para>
		/// <para>访问已到期地图时将显示的文本消息。</para>
		/// <para>此可选参数仅适用于 Publisher 扩展模块。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ExpirationMessage { get; set; } = "This map is expired.  Contact the map publisher for an updated map.";

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
		public CreateMobileMapPackage SetEnviroment(object? extent = null, object? parallelProcessingFactor = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
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
		/// <para>Enable Map Expiration</para>
		/// </summary>
		public enum EnableMapExpirationEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ENABLE_MAP_EXPIRATION")]
			ENABLE_MAP_EXPIRATION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DISABLE_MAP_EXPIRATION")]
			DISABLE_MAP_EXPIRATION,

		}

		/// <summary>
		/// <para>Map Expiration Type</para>
		/// </summary>
		public enum MapExpirationTypeEnum 
		{
			/// <summary>
			/// <para>允许打开—将警告包用户此地图已到期，但仍允许打开地图。 这是默认设置。</para>
			/// </summary>
			[GPValue("ALLOW_TO_OPEN")]
			[Description("允许打开")]
			Allow_to_open,

			/// <summary>
			/// <para>不允许打开—将警告包用户此地图已到期，并且不允许打开地图。</para>
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
