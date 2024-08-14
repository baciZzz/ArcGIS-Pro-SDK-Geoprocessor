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
	/// <para>Deletes an existing map image layer cache, including all associated files on disk.</para>
	/// </summary>
	public class DeleteMapServerCache : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputService">
		/// <para>Input Service</para>
		/// <para>The map image layer whose cache tiles you want to delete. You can choose it by browsing to the desired service in Portal or you can drag and drop a web tile layer from the Project pane Portal tab to supply this parameter.</para>
		/// <para>The map image layer whose cache tiles you want to delete.</para>
		/// </param>
		public DeleteMapServerCache(object InputService)
		{
			this.InputService = InputService;
		}

		/// <summary>
		/// <para>Tool Display Name : Delete Map Server Cache</para>
		/// </summary>
		public override string DisplayName => "Delete Map Server Cache";

		/// <summary>
		/// <para>Tool Name : DeleteMapServerCache</para>
		/// </summary>
		public override string ToolName => "DeleteMapServerCache";

		/// <summary>
		/// <para>Tool Excute Name : server.DeleteMapServerCache</para>
		/// </summary>
		public override string ExcuteName => "server.DeleteMapServerCache";

		/// <summary>
		/// <para>Toolbox Display Name : Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : server</para>
		/// </summary>
		public override string ToolboxAlise => "server";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputService, NumOfCachingServiceInstances, OutJobUrl };

		/// <summary>
		/// <para>Input Service</para>
		/// <para>The map image layer whose cache tiles you want to delete. You can choose it by browsing to the desired service in Portal or you can drag and drop a web tile layer from the Project pane Portal tab to supply this parameter.</para>
		/// <para>The map image layer whose cache tiles you want to delete.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InputService { get; set; }

		/// <summary>
		/// <para>Number of caching service instances</para>
		/// <para>Defines the number of instances that will be used to update/generate the tiles. The value for this parameter is set to unlimited (-1) and cannot be modified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumOfCachingServiceInstances { get; set; }

		/// <summary>
		/// <para>Output Map Service URL</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutJobUrl { get; set; }

	}
}
