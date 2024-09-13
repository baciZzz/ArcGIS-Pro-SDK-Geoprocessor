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
	/// <para>Generate Globe Server Cache</para>
	/// <para>Generate Globe Server Cache</para>
	/// <para>Generates a pre-rendered tiled cache for Globe Server.</para>
	/// </summary>
	[Obsolete()]
	public class GenerateGlobeServerCache : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="ServerName">
		/// <para>Host</para>
		/// </param>
		/// <param name="ObjectName">
		/// <para>GlobeServer Object</para>
		/// </param>
		/// <param name="OutFolder">
		/// <para>Server Cache Directory</para>
		/// </param>
		/// <param name="LodFrom">
		/// <para>From Level of Detail</para>
		/// </param>
		/// <param name="LodTo">
		/// <para>To Level of Detail</para>
		/// </param>
		/// <param name="Layer">
		/// <para>Input Layers</para>
		/// </param>
		public GenerateGlobeServerCache(object ServerName, object ObjectName, object OutFolder, object LodFrom, object LodTo, object Layer)
		{
			this.ServerName = ServerName;
			this.ObjectName = ObjectName;
			this.OutFolder = OutFolder;
			this.LodFrom = LodFrom;
			this.LodTo = LodTo;
			this.Layer = Layer;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Globe Server Cache</para>
		/// </summary>
		public override string DisplayName() => "Generate Globe Server Cache";

		/// <summary>
		/// <para>Tool Name : GenerateGlobeServerCache</para>
		/// </summary>
		public override string ToolName() => "GenerateGlobeServerCache";

		/// <summary>
		/// <para>Tool Excute Name : server.GenerateGlobeServerCache</para>
		/// </summary>
		public override string ExcuteName() => "server.GenerateGlobeServerCache";

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
		public override object[] Parameters() => new object[] { ServerName, ObjectName, OutFolder, LodFrom, LodTo, ThreadCount, Layer };

		/// <summary>
		/// <para>Host</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ServerName { get; set; }

		/// <summary>
		/// <para>GlobeServer Object</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ObjectName { get; set; }

		/// <summary>
		/// <para>Server Cache Directory</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutFolder { get; set; }

		/// <summary>
		/// <para>From Level of Detail</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LodFrom { get; set; }

		/// <summary>
		/// <para>To Level of Detail</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LodTo { get; set; }

		/// <summary>
		/// <para>Number of GlobeServer instances</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object ThreadCount { get; set; }

		/// <summary>
		/// <para>Input Layers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Layer { get; set; }

	}
}
