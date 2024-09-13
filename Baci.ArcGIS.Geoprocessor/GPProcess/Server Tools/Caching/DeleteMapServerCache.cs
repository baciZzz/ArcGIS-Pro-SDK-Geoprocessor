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
	/// <para>Delete Map Server Cache</para>
	/// <para>删除地图服务器缓存</para>
	/// <para>删除现有地图影像图层缓存（包括磁盘上的所有关联文件）。</para>
	/// </summary>
	public class DeleteMapServerCache : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputService">
		/// <para>Input Service</para>
		/// <para>待删除缓存切片所属的地图影像图层。 可以通过在门户中浏览至所需的服务来对其进行选择，也可以从工程窗格的门户选项卡拖放一个 web 切片图层来提供此参数。</para>
		/// <para>待删除缓存切片所属的地图影像图层。</para>
		/// </param>
		public DeleteMapServerCache(object InputService)
		{
			this.InputService = InputService;
		}

		/// <summary>
		/// <para>Tool Display Name : 删除地图服务器缓存</para>
		/// </summary>
		public override string DisplayName() => "删除地图服务器缓存";

		/// <summary>
		/// <para>Tool Name : DeleteMapServerCache</para>
		/// </summary>
		public override string ToolName() => "DeleteMapServerCache";

		/// <summary>
		/// <para>Tool Excute Name : server.DeleteMapServerCache</para>
		/// </summary>
		public override string ExcuteName() => "server.DeleteMapServerCache";

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
		public override object[] Parameters() => new object[] { InputService, NumOfCachingServiceInstances!, OutJobUrl! };

		/// <summary>
		/// <para>Input Service</para>
		/// <para>待删除缓存切片所属的地图影像图层。 可以通过在门户中浏览至所需的服务来对其进行选择，也可以从工程窗格的门户选项卡拖放一个 web 切片图层来提供此参数。</para>
		/// <para>待删除缓存切片所属的地图影像图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InputService { get; set; }

		/// <summary>
		/// <para>Number of caching service instances</para>
		/// <para>定义用于更新/生成切片的实例数。 该参数的值将设置为无限 (-1)，且无法进行修改。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumOfCachingServiceInstances { get; set; }

		/// <summary>
		/// <para>Output Map Service URL</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutJobUrl { get; set; }

	}
}
