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
	/// <para>Manage Map Server Cache Tiles</para>
	/// <para>管理地图服务器缓存切片</para>
	/// <para>在现有 web 切片图层缓存中创建和更新切片。 此工具用于创建新切片、恢复缺失切片、覆盖过时切片以及删除切片。</para>
	/// </summary>
	public class ManageMapServerCacheTiles : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputService">
		/// <para>Input Service</para>
		/// <para>待更新缓存切片所属的 web 切片图层或地图影像图层。 可以通过在门户中浏览至所需的服务来对其进行选择，也可以从工程窗格的门户选项卡拖放一个 web 切片图层来提供此参数。</para>
		/// </param>
		/// <param name="Scales">
		/// <para>Scales</para>
		/// <para>创建切片时使用的比例级别列表。</para>
		/// <para>默认情况下，工具对话框中所列出的比例介于该服务的最小和最大缓存比例之间。 在 ArcGIS Pro 中，无法更改服务的缓存比例范围。</para>
		/// </param>
		/// <param name="UpdateMode">
		/// <para>Update Mode</para>
		/// <para>缓存的更新模式。</para>
		/// <para>重新创建空切片—只对空的切片重新创建。 现有切片将保持不变。 此选项不适用于发布至 ArcGIS Online 的 web 切片图层。</para>
		/// <para>重新创建所有切片—如果范围发生改变，则需要更换现有切片并添加新切片。</para>
		/// <para>删除切片—将从缓存中删除切片。 缓存文件夹结构不会删除。</para>
		/// <para><see cref="UpdateModeEnum"/></para>
		/// </param>
		public ManageMapServerCacheTiles(object InputService, object Scales, object UpdateMode)
		{
			this.InputService = InputService;
			this.Scales = Scales;
			this.UpdateMode = UpdateMode;
		}

		/// <summary>
		/// <para>Tool Display Name : 管理地图服务器缓存切片</para>
		/// </summary>
		public override string DisplayName() => "管理地图服务器缓存切片";

		/// <summary>
		/// <para>Tool Name : ManageMapServerCacheTiles</para>
		/// </summary>
		public override string ToolName() => "ManageMapServerCacheTiles";

		/// <summary>
		/// <para>Tool Excute Name : server.ManageMapServerCacheTiles</para>
		/// </summary>
		public override string ExcuteName() => "server.ManageMapServerCacheTiles";

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
		public override object[] Parameters() => new object[] { InputService, Scales, UpdateMode, NumOfCachingServiceInstances, AreaOfInterest, UpdateExtent, WaitForJobCompletion, PortalUrl, OutJobUrl };

		/// <summary>
		/// <para>Input Service</para>
		/// <para>待更新缓存切片所属的 web 切片图层或地图影像图层。 可以通过在门户中浏览至所需的服务来对其进行选择，也可以从工程窗格的门户选项卡拖放一个 web 切片图层来提供此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InputService { get; set; }

		/// <summary>
		/// <para>Scales</para>
		/// <para>创建切片时使用的比例级别列表。</para>
		/// <para>默认情况下，工具对话框中所列出的比例介于该服务的最小和最大缓存比例之间。 在 ArcGIS Pro 中，无法更改服务的缓存比例范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Scales { get; set; }

		/// <summary>
		/// <para>Update Mode</para>
		/// <para>缓存的更新模式。</para>
		/// <para>重新创建空切片—只对空的切片重新创建。 现有切片将保持不变。 此选项不适用于发布至 ArcGIS Online 的 web 切片图层。</para>
		/// <para>重新创建所有切片—如果范围发生改变，则需要更换现有切片并添加新切片。</para>
		/// <para>删除切片—将从缓存中删除切片。 缓存文件夹结构不会删除。</para>
		/// <para><see cref="UpdateModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object UpdateMode { get; set; } = "RECREATE_ALL_TILES";

		/// <summary>
		/// <para>Number of caching service instances</para>
		/// <para>定义用于更新/生成切片的实例数。 该参数的值将设置为无限 (-1)，且无法进行修改。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumOfCachingServiceInstances { get; set; }

		/// <summary>
		/// <para>Area Of Interest</para>
		/// <para>定义感兴趣区以对将创建或删除的切片进行约束。 该参数用于为形状不规则的区域管理切片。 它对您要对某些区域进行预缓存或让较少访问的区域保持未缓存的状态等情形也同样有用。</para>
		/// <para>若未提供该参数的值，则会默认使用地图的全图范围。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Update Extent</para>
		/// <para>创建或删除切片时所参照的矩形范围，具体取决于更新模式参数的值。 建议不要同时提供更新范围和感兴趣区两个参数值。 如果同时提供了两个参数的值，则会使用感兴趣区的值。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>当前显示范围 - 该范围与数据框或可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		[Category("Area of interest (Envelope)")]
		public object UpdateExtent { get; set; }

		/// <summary>
		/// <para>Wait for job completion</para>
		/// <para>可以通过该参数查看在 ArcGIS Online 或 Portal for ArcGIS 上运行的缓存作业的进度。</para>
		/// <para>选中 - 此工具将继续在 Pro 中运行，同时缓存作业在 Portal for ArcGIS 或 ArcGIS Online 中运行。 使用此选项，您可以随时请求详细的进度报告并查看显示的地理处理消息。</para>
		/// <para>未选中 - 此工具会将作业提交至门户，允许您在 ArcGIS Pro 中执行其他地理处理任务或将其关闭。 在您选择在发布服务之际自动构建缓存时使用此选项，您还可在您所构建的任何其他缓存中设置此选项。</para>
		/// <para><see cref="WaitForJobCompletionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object WaitForJobCompletion { get; set; } = "true";

		/// <summary>
		/// <para>Portal URL</para>
		/// <para>门户 URL。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object PortalUrl { get; set; }

		/// <summary>
		/// <para>Output Map Service URL</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutJobUrl { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ManageMapServerCacheTiles SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Update Mode</para>
		/// </summary>
		public enum UpdateModeEnum 
		{
			/// <summary>
			/// <para>重新创建空切片—只对空的切片重新创建。 现有切片将保持不变。 此选项不适用于发布至 ArcGIS Online 的 web 切片图层。</para>
			/// </summary>
			[GPValue("RECREATE_EMPTY_TILES")]
			[Description("重新创建空切片")]
			Recreate_Empty_Tiles,

			/// <summary>
			/// <para>重新创建所有切片—如果范围发生改变，则需要更换现有切片并添加新切片。</para>
			/// </summary>
			[GPValue("RECREATE_ALL_TILES")]
			[Description("重新创建所有切片")]
			Recreate_All_Tiles,

			/// <summary>
			/// <para>删除切片—将从缓存中删除切片。 缓存文件夹结构不会删除。</para>
			/// </summary>
			[GPValue("DELETE_TILES")]
			[Description("删除切片")]
			Delete_Tiles,

		}

		/// <summary>
		/// <para>Wait for job completion</para>
		/// </summary>
		public enum WaitForJobCompletionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("WAIT")]
			WAIT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_WAIT")]
			DO_NOT_WAIT,

		}

#endregion
	}
}
