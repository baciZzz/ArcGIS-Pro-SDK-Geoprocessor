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
	/// <para>Converts the storage of a web map image layer or of a  map or image service cache between the exploded format and the compactV2  format.</para>
	/// </summary>
	public class ConvertMapServerCacheStorageFormat : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputService">
		/// <para>Input Service</para>
		/// <para>The map or image service whose cache format will be converted. In ArcGIS Enterprise, this is a string containing the REST endpoint of the web map image layer. In a stand-alone ArcGIS Server, this is a string containing both the server and the service information.</para>
		/// </param>
		public ConvertMapServerCacheStorageFormat(object InputService)
		{
			this.InputService = InputService;
		}

		/// <summary>
		/// <para>Tool Display Name : Convert Map Server Cache Storage Format</para>
		/// </summary>
		public override string DisplayName => "Convert Map Server Cache Storage Format";

		/// <summary>
		/// <para>Tool Name : ConvertMapServerCacheStorageFormat</para>
		/// </summary>
		public override string ToolName => "ConvertMapServerCacheStorageFormat";

		/// <summary>
		/// <para>Tool Excute Name : server.ConvertMapServerCacheStorageFormat</para>
		/// </summary>
		public override string ExcuteName => "server.ConvertMapServerCacheStorageFormat";

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
		public override object[] Parameters => new object[] { InputService, NumOfCachingServiceInstances!, OutJobUrl! };

		/// <summary>
		/// <para>Input Service</para>
		/// <para>The map or image service whose cache format will be converted. In ArcGIS Enterprise, this is a string containing the REST endpoint of the web map image layer. In a stand-alone ArcGIS Server, this is a string containing both the server and the service information.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InputService { get; set; }

		/// <summary>
		/// <para>Number of caching service instances</para>
		/// <para>The total number of instances of the System/CachingTools service that will be dedicated to running this tool. The default value of -1 is used, all the caching tool instances of the ArcGIS Enterprise setup will be used. Use a lower value to use fewer caching tool instances.</para>
		/// <para>You can increase the Maximum number of instances per machine setting of the System/CachingTools service using the Service Editor window available through an administrative connection to ArcGIS Server. Ensure that the server machines can support the chosen number of instances.</para>
		/// <para>When connecting to a stand-alone server, the default number of instances is equal to the value of the Maximum number of instances setting of the caching tool service.</para>
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
