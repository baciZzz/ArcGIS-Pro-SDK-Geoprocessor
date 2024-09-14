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
	/// <para>Convert Map Server Cache Storage Format</para>
	/// <para>转换地图服务器缓存存储格式</para>
	/// <para>在松散格式和 compactV2 格式之间转换 Web 地图影像图层或地图或影像服务缓存的存储。</para>
	/// </summary>
	public class ConvertMapServerCacheStorageFormat : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputService">
		/// <para>Input Service</para>
		/// <para>要转换缓存格式的地图或影像服务。 在 ArcGIS Enterprise 中，是包含 Web 地图图像图层 REST 端点的字符串。 在独立 ArcGIS Server 中，这是包含服务器和服务信息的字符串。</para>
		/// </param>
		public ConvertMapServerCacheStorageFormat(object InputService)
		{
			this.InputService = InputService;
		}

		/// <summary>
		/// <para>Tool Display Name : 转换地图服务器缓存存储格式</para>
		/// </summary>
		public override string DisplayName() => "转换地图服务器缓存存储格式";

		/// <summary>
		/// <para>Tool Name : ConvertMapServerCacheStorageFormat</para>
		/// </summary>
		public override string ToolName() => "ConvertMapServerCacheStorageFormat";

		/// <summary>
		/// <para>Tool Excute Name : server.ConvertMapServerCacheStorageFormat</para>
		/// </summary>
		public override string ExcuteName() => "server.ConvertMapServerCacheStorageFormat";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputService, NumOfCachingServiceInstances!, OutJobUrl! };

		/// <summary>
		/// <para>Input Service</para>
		/// <para>要转换缓存格式的地图或影像服务。 在 ArcGIS Enterprise 中，是包含 Web 地图图像图层 REST 端点的字符串。 在独立 ArcGIS Server 中，这是包含服务器和服务信息的字符串。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InputService { get; set; }

		/// <summary>
		/// <para>Number of caching service instances</para>
		/// <para>专用于运行该工具的 System/CachingTools 服务实例的总数。 将使用默认值 -1，即使用 ArcGIS Enterprise 设置的所有缓存工具实例。 使用较小的值可以使用较少的缓存工具实例。</para>
		/// <para>您可以使用服务编辑器窗口增加 System/CachingTools 服务的每台计算机的最大实例数设置，该窗口可通过 ArcGIS Server 的管理连接访问。 确保服务器计算机可以支持所选数量的实例。</para>
		/// <para>连接到独立服务器时，默认实例数等于缓存工具服务的最大实例数设置的值。</para>
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
