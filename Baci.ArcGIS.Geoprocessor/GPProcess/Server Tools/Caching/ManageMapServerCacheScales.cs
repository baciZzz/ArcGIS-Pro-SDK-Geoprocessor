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
	/// <para>Manage Map Server Cache Scales</para>
	/// <para>Updates the scale levels in an existing map image layer in ArcGIS Enterprise or in a cached map or image service on a stand-alone server. Use this tool to add new scales or delete existing scales from a cache.</para>
	/// </summary>
	public class ManageMapServerCacheScales : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputService">
		/// <para>Input Service</para>
		/// <para>The map image layer or map or image service where cache scales will be added or removed. You can drag a map or an image service from the Catalog tree to supply this parameter value.</para>
		/// </param>
		/// <param name="Scales">
		/// <para>Scales</para>
		/// <para>The scale values that will be included in the updated tiling scheme.</para>
		/// </param>
		public ManageMapServerCacheScales(object InputService, object Scales)
		{
			this.InputService = InputService;
			this.Scales = Scales;
		}

		/// <summary>
		/// <para>Tool Display Name : Manage Map Server Cache Scales</para>
		/// </summary>
		public override string DisplayName() => "Manage Map Server Cache Scales";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputService, Scales, OutJobUrl! };

		/// <summary>
		/// <para>Input Service</para>
		/// <para>The map image layer or map or image service where cache scales will be added or removed. You can drag a map or an image service from the Catalog tree to supply this parameter value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InputService { get; set; }

		/// <summary>
		/// <para>Scales</para>
		/// <para>The scale values that will be included in the updated tiling scheme.</para>
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
