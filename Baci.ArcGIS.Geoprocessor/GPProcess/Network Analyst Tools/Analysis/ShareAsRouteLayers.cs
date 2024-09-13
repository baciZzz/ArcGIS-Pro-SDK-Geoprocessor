using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkAnalystTools
{
	/// <summary>
	/// <para>Share As Route Layers</para>
	/// <para>共享为路径图层</para>
	/// <para>用于将网络分析结果共享为门户中的路径图层项目。路径图层中包含特定路径的全部信息，例如分配至路径的停靠点，以及出行方向等。</para>
	/// </summary>
	public class ShareAsRouteLayers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkAnalysisLayer">
		/// <para>Input Network Analysis Layer or  Route Data</para>
		/// <para>网络分析图层或包含用于创建路径图层项目的路径数据的 .zip 文件。当输入为网络分析图层时，其应已得到求解。</para>
		/// </param>
		public ShareAsRouteLayers(object InNetworkAnalysisLayer)
		{
			this.InNetworkAnalysisLayer = InNetworkAnalysisLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : 共享为路径图层</para>
		/// </summary>
		public override string DisplayName() => "共享为路径图层";

		/// <summary>
		/// <para>Tool Name : ShareAsRouteLayers</para>
		/// </summary>
		public override string ToolName() => "ShareAsRouteLayers";

		/// <summary>
		/// <para>Tool Excute Name : na.ShareAsRouteLayers</para>
		/// </summary>
		public override string ExcuteName() => "na.ShareAsRouteLayers";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise() => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InNetworkAnalysisLayer, Summary!, Tags!, RouteNamePrefix!, PortalFolderName!, ShareWith!, Groups!, RouteLayerItems! };

		/// <summary>
		/// <para>Input Network Analysis Layer or  Route Data</para>
		/// <para>网络分析图层或包含用于创建路径图层项目的路径数据的 .zip 文件。当输入为网络分析图层时，其应已得到求解。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Summary</para>
		/// <para>路径图层项目使用的摘要。摘要显示为路径图层项目的项目信息的一部分。如果未指定任何值，则将使用默认摘要文本 - Route and directions for &lt;路径名称&gt;，其中 &lt;路径名称&gt; 可替换为由路径图层表示的路径的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Summary { get; set; }

		/// <summary>
		/// <para>Tags</para>
		/// <para>用于描述和标识路径图层项目的标签。各个标签之间用逗号进行分隔。路径名称始终作为标签包含在内，即使在未指定任何值的情况下也是如此。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Tags { get; set; }

		/// <summary>
		/// <para>Route Name Prefix</para>
		/// <para>添加至每个路径图层项目标题的限定符。例如，路径名称前缀 Monday morning deliveries 可用于对基于星期一上午配送时所进行的路径分析创建的所有路径图层项目进行分组。如果未指定任何值，则仅使用路径名称创建路径图层项目的标题。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? RouteNamePrefix { get; set; }

		/// <summary>
		/// <para>Portal Folder Name</para>
		/// <para>个人在线工作空间中将创建路径图层项目的文件夹。如果具有指定名称的文件夹不存在，则会创建一个文件夹。如果存在具有指定名称的文件夹，则将在现有文件夹中创建项目。如果未指定任何值，则将在您的在线工作空间中的根文件夹内创建路径图层项目。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? PortalFolderName { get; set; }

		/// <summary>
		/// <para>Share with</para>
		/// <para>指定可以访问路径图层项目的用户。可以使用以下关键字指定此参数：</para>
		/// <para>所有人— 路径图层项目将公开，任何人都可以通过这些项目的 URL 进行访问。</para>
		/// <para>不共享— 路径图层项目将仅共享给项目的所有者（运行该工具时连接到该门户的用户）。因此，仅项目的所有者才可以访问路径图层。这是默认设置。</para>
		/// <para>以下群组— 路径图层项目将共享给连接的用户所属的组及其成员。这些组是使用组参数指定的。</para>
		/// <para>组织— 路径图层项目将共享给您所在组织中所有经过身份验证的用户。</para>
		/// <para><see cref="ShareWithEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ShareWith { get; set; } = "MYCONTENT";

		/// <summary>
		/// <para>Groups</para>
		/// <para>将与之共享路径图层项目的群组列表。仅当共享给参数设置为这些群组时，此选项才适用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Groups { get; set; }

		/// <summary>
		/// <para>Route Layer Items</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? RouteLayerItems { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ShareAsRouteLayers SetEnviroment(object? outputCoordinateSystem = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Share with</para>
		/// </summary>
		public enum ShareWithEnum 
		{
			/// <summary>
			/// <para>所有人— 路径图层项目将公开，任何人都可以通过这些项目的 URL 进行访问。</para>
			/// </summary>
			[GPValue("EVERYBODY")]
			[Description("所有人")]
			Everyone,

			/// <summary>
			/// <para>组织— 路径图层项目将共享给您所在组织中所有经过身份验证的用户。</para>
			/// </summary>
			[GPValue("MYORGANIZATION")]
			[Description("组织")]
			Organization,

			/// <summary>
			/// <para>以下群组— 路径图层项目将共享给连接的用户所属的组及其成员。这些组是使用组参数指定的。</para>
			/// </summary>
			[GPValue("MYGROUPS")]
			[Description("以下群组")]
			These_groups,

			/// <summary>
			/// <para>不共享— 路径图层项目将仅共享给项目的所有者（运行该工具时连接到该门户的用户）。因此，仅项目的所有者才可以访问路径图层。这是默认设置。</para>
			/// </summary>
			[GPValue("MYCONTENT")]
			[Description("不共享")]
			Not_shared,

		}

#endregion
	}
}
