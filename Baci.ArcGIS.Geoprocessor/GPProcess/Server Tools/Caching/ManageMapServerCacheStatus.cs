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
	/// <para>Manage Map Server Cache Status</para>
	/// <para>管理地图服务器缓存状态</para>
	/// <para>管理服务器所保存的与地图或影像服务缓存中的构建切片有关的内部数据。</para>
	/// </summary>
	public class ManageMapServerCacheStatus : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputService">
		/// <para>Input Service</para>
		/// <para>将修改其缓存状态的地图影像图层。 可以通过在门户中浏览至所需的服务来对其进行选择，也可以从目录窗格的门户选项卡拖放一个 web 切片图层来提供此参数。</para>
		/// </param>
		/// <param name="ManageMode">
		/// <para>Manage Mode</para>
		/// <para>删除缓存状态—删除服务器所使用的状态信息。</para>
		/// <para>重建缓存状态—删除服务器所使用的状态信息，然后重新构建该状态信息。</para>
		/// <para>重建包状态—在一个名为 Status.gdb 的新文件地理数据库中创建状态信息，此文件地理数据库位于在输出文件夹参数指定的文件夹中。 该选项用于为特定感兴趣区域或比例设置创建自定义状态报告。</para>
		/// <para><see cref="ManageModeEnum"/></para>
		/// </param>
		public ManageMapServerCacheStatus(object InputService, object ManageMode)
		{
			this.InputService = InputService;
			this.ManageMode = ManageMode;
		}

		/// <summary>
		/// <para>Tool Display Name : 管理地图服务器缓存状态</para>
		/// </summary>
		public override string DisplayName() => "管理地图服务器缓存状态";

		/// <summary>
		/// <para>Tool Name : ManageMapServerCacheStatus</para>
		/// </summary>
		public override string ToolName() => "ManageMapServerCacheStatus";

		/// <summary>
		/// <para>Tool Excute Name : server.ManageMapServerCacheStatus</para>
		/// </summary>
		public override string ExcuteName() => "server.ManageMapServerCacheStatus";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputService, ManageMode, Scales, NumOfCachingServiceInstances, ReportFolder, AreaOfInterest, ReportExtent, OutputFolder };

		/// <summary>
		/// <para>Input Service</para>
		/// <para>将修改其缓存状态的地图影像图层。 可以通过在门户中浏览至所需的服务来对其进行选择，也可以从目录窗格的门户选项卡拖放一个 web 切片图层来提供此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InputService { get; set; }

		/// <summary>
		/// <para>Manage Mode</para>
		/// <para>删除缓存状态—删除服务器所使用的状态信息。</para>
		/// <para>重建缓存状态—删除服务器所使用的状态信息，然后重新构建该状态信息。</para>
		/// <para>重建包状态—在一个名为 Status.gdb 的新文件地理数据库中创建状态信息，此文件地理数据库位于在输出文件夹参数指定的文件夹中。 该选项用于为特定感兴趣区域或比例设置创建自定义状态报告。</para>
		/// <para><see cref="ManageModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ManageMode { get; set; } = "REBUILD_CACHE_STATUS";

		/// <summary>
		/// <para>Scales</para>
		/// <para>将修改其状态的比例级别。 此参数仅适用于使用重建包状态选项为管理模式参数构建自定义状态的情况。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Scales { get; set; }

		/// <summary>
		/// <para>Number of caching service instances</para>
		/// <para>定义用于更新/生成切片的实例数。 该参数的值将设置为无限 (-1)，且无法进行修改。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumOfCachingServiceInstances { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>Status.gdb 的输出文件夹。 此参数仅适用于使用重建包状态选项构建自定义状态的情况。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object ReportFolder { get; set; }

		/// <summary>
		/// <para>Area Of Interest</para>
		/// <para>感兴趣区(面)决定着状态报告将覆盖的地理形态。 此参数仅适用于使用重建包状态选项构建自定义状态的情况。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Report Extent</para>
		/// <para>定义构建状态区域的矩形范围。 此参数仅适用于使用重建包状态选项构建自定义状态的情况。</para>
		/// <para>请注意，感兴趣区参数可指定非矩形感兴趣区。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>当前显示范围 - 该范围与数据框或可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		[Category("Area of Interest (Envelope)")]
		public object ReportExtent { get; set; }

		/// <summary>
		/// <para>Output Map Service URL</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutputFolder { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Manage Mode</para>
		/// </summary>
		public enum ManageModeEnum 
		{
			/// <summary>
			/// <para>重建缓存状态—删除服务器所使用的状态信息，然后重新构建该状态信息。</para>
			/// </summary>
			[GPValue("REBUILD_CACHE_STATUS")]
			[Description("重建缓存状态")]
			Rebuild_cache_status,

			/// <summary>
			/// <para>删除缓存状态—删除服务器所使用的状态信息。</para>
			/// </summary>
			[GPValue("DELETE_CACHE_STATUS")]
			[Description("删除缓存状态")]
			Delete_cache_status,

			/// <summary>
			/// <para>重建包状态—在一个名为 Status.gdb 的新文件地理数据库中创建状态信息，此文件地理数据库位于在输出文件夹参数指定的文件夹中。 该选项用于为特定感兴趣区域或比例设置创建自定义状态报告。</para>
			/// </summary>
			[GPValue("REPORT_BUNDLE_STATUS")]
			[Description("重建包状态")]
			Rebuild_bundle_status,

		}

#endregion
	}
}
