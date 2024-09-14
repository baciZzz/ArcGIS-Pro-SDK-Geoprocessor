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
	/// <para>Manage Map Server Cache Scales</para>
	/// <para>管理地图服务器缓存比例</para>
	/// <para>用于在 ArcGIS Enterprise 中的现有地图图像图层或独立服务器上的已缓存地图或影像服务中更新比例级别。 使用此工具可添加新比例或从缓存中删除现有比例。</para>
	/// </summary>
	public class ManageMapServerCacheScales : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputService">
		/// <para>Input Service</para>
		/// <para>将添加或删除缓存比例的地图图像图层或地图或影像服务。 您可以通过拖动目录树中的地图或影像服务以提供此参数值。</para>
		/// </param>
		/// <param name="Scales">
		/// <para>Scales</para>
		/// <para>将包含在已更新切片方案中的比例值。</para>
		/// </param>
		public ManageMapServerCacheScales(object InputService, object Scales)
		{
			this.InputService = InputService;
			this.Scales = Scales;
		}

		/// <summary>
		/// <para>Tool Display Name : 管理地图服务器缓存比例</para>
		/// </summary>
		public override string DisplayName() => "管理地图服务器缓存比例";

		/// <summary>
		/// <para>Tool Name : ManageMapServerCacheScales</para>
		/// </summary>
		public override string ToolName() => "ManageMapServerCacheScales";

		/// <summary>
		/// <para>Tool Excute Name : server.ManageMapServerCacheScales</para>
		/// </summary>
		public override string ExcuteName() => "server.ManageMapServerCacheScales";

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
		public override object[] Parameters() => new object[] { InputService, Scales, OutJobUrl! };

		/// <summary>
		/// <para>Input Service</para>
		/// <para>将添加或删除缓存比例的地图图像图层或地图或影像服务。 您可以通过拖动目录树中的地图或影像服务以提供此参数值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InputService { get; set; }

		/// <summary>
		/// <para>Scales</para>
		/// <para>将包含在已更新切片方案中的比例值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		public object Scales { get; set; }

		/// <summary>
		/// <para>Output Map Service URL</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutJobUrl { get; set; }

	}
}
