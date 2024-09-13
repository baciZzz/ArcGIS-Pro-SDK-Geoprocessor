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
	/// <para>Replace Web Layer</para>
	/// <para>替换 Web 图层</para>
	/// <para>用于将门户中某一 web 图层的内容替换为其他 web 图层的内容。</para>
	/// </summary>
	public class ReplaceWebLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetLayer">
		/// <para>Target Layer</para>
		/// <para>要替换的 web 图层。除了图层或目录路径之外，还可以使用以下某项的项目 ID 或服务 URL 进行指定。</para>
		/// <para>矢量切片</para>
		/// <para>切片图层</para>
		/// <para>从以下源之一发布的场景图层：</para>
		/// <para>场景图层包</para>
		/// <para>文件夹或云数据存储中引用的场景缓存</para>
		/// </param>
		/// <param name="ArchiveLayerName">
		/// <para>Archive Layer Name</para>
		/// <para>替换的 web 图层将作为存档图层保留在门户中。请为存档图层指定唯一名称。</para>
		/// </param>
		/// <param name="UpdateLayer">
		/// <para>Update Layer</para>
		/// <para>替换 web 图层。除了图层或目录路径之外，还可以使用以下某项的项目 ID 或服务 URL 进行指定。</para>
		/// <para>矢量切片</para>
		/// <para>切片图层</para>
		/// <para>从以下源之一发布的场景图层：</para>
		/// <para>场景图层包</para>
		/// <para>文件夹或云数据存储中引用的场景缓存</para>
		/// </param>
		public ReplaceWebLayer(object TargetLayer, object ArchiveLayerName, object UpdateLayer)
		{
			this.TargetLayer = TargetLayer;
			this.ArchiveLayerName = ArchiveLayerName;
			this.UpdateLayer = UpdateLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 替换 Web 图层</para>
		/// </summary>
		public override string DisplayName() => "替换 Web 图层";

		/// <summary>
		/// <para>Tool Name : ReplaceWebLayer</para>
		/// </summary>
		public override string ToolName() => "ReplaceWebLayer";

		/// <summary>
		/// <para>Tool Excute Name : server.ReplaceWebLayer</para>
		/// </summary>
		public override string ExcuteName() => "server.ReplaceWebLayer";

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
		public override object[] Parameters() => new object[] { TargetLayer, ArchiveLayerName, UpdateLayer, ReplaceItemInfo, UpdatedTargetLayer, CreateNewItem };

		/// <summary>
		/// <para>Target Layer</para>
		/// <para>要替换的 web 图层。除了图层或目录路径之外，还可以使用以下某项的项目 ID 或服务 URL 进行指定。</para>
		/// <para>矢量切片</para>
		/// <para>切片图层</para>
		/// <para>从以下源之一发布的场景图层：</para>
		/// <para>场景图层包</para>
		/// <para>文件夹或云数据存储中引用的场景缓存</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object TargetLayer { get; set; }

		/// <summary>
		/// <para>Archive Layer Name</para>
		/// <para>替换的 web 图层将作为存档图层保留在门户中。请为存档图层指定唯一名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ArchiveLayerName { get; set; }

		/// <summary>
		/// <para>Update Layer</para>
		/// <para>替换 web 图层。除了图层或目录路径之外，还可以使用以下某项的项目 ID 或服务 URL 进行指定。</para>
		/// <para>矢量切片</para>
		/// <para>切片图层</para>
		/// <para>从以下源之一发布的场景图层：</para>
		/// <para>场景图层包</para>
		/// <para>文件夹或云数据存储中引用的场景缓存</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object UpdateLayer { get; set; }

		/// <summary>
		/// <para>Replace Item Information</para>
		/// <para>指定是否替换缩略图、摘要、描述和标签。无论哪种情况，都不会替换项目的“制作者名单（属性）”、“使用条款”和“创建时间”信息。</para>
		/// <para>未选中 - 更新图层时，将不会替换目标图层的项目信息。这是默认设置。</para>
		/// <para>已选中 - 目标图层的项目信息将替换为更新图层的项目信息。</para>
		/// <para><see cref="ReplaceItemInfoEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ReplaceItemInfo { get; set; } = "false";

		/// <summary>
		/// <para>Updated Target Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object UpdatedTargetLayer { get; set; }

		/// <summary>
		/// <para>Create New Item For Archive Layer</para>
		/// <para>指定是否为归档图层创建新项目。此选项适用于 ArcGIS Online 和 ArcGIS Enterprise 10.8 或更高版本中的门户。</para>
		/// <para>未选中 - 将更新图层的项目 ID 用于归档图层。这是矢量切片图层和切片图层的默认设置。</para>
		/// <para>选中 - 将为归档图层创建新项目 ID。这是场景图层的默认值。</para>
		/// <para><see cref="CreateNewItemEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CreateNewItem { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ReplaceWebLayer SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Replace Item Information</para>
		/// </summary>
		public enum ReplaceItemInfoEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REPLACE")]
			REPLACE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP")]
			KEEP,

		}

		/// <summary>
		/// <para>Create New Item For Archive Layer</para>
		/// </summary>
		public enum CreateNewItemEnum 
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
