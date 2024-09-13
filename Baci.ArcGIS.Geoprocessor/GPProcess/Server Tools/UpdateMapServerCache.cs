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
	/// <para>Update Map Server Cache</para>
	/// <para>Update Map Server Cache</para>
	/// <para>Updates a pre-rendered tiled cache for Map Server.</para>
	/// </summary>
	[Obsolete()]
	public class UpdateMapServerCache : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="ServerName">
		/// <para>Host</para>
		/// </param>
		/// <param name="ObjectName">
		/// <para>Map Server</para>
		/// </param>
		/// <param name="DataFrame">
		/// <para>Data Frame</para>
		/// </param>
		/// <param name="Layer">
		/// <para>Input Layers</para>
		/// </param>
		/// <param name="Levels">
		/// <para>Scales</para>
		/// </param>
		/// <param name="UpdateMode">
		/// <para>Update Mode</para>
		/// <para><see cref="UpdateModeEnum"/></para>
		/// </param>
		public UpdateMapServerCache(object ServerName, object ObjectName, object DataFrame, object Layer, object Levels, object UpdateMode)
		{
			this.ServerName = ServerName;
			this.ObjectName = ObjectName;
			this.DataFrame = DataFrame;
			this.Layer = Layer;
			this.Levels = Levels;
			this.UpdateMode = UpdateMode;
		}

		/// <summary>
		/// <para>Tool Display Name : Update Map Server Cache</para>
		/// </summary>
		public override string DisplayName() => "Update Map Server Cache";

		/// <summary>
		/// <para>Tool Name : UpdateMapServerCache</para>
		/// </summary>
		public override string ToolName() => "UpdateMapServerCache";

		/// <summary>
		/// <para>Tool Excute Name : server.UpdateMapServerCache</para>
		/// </summary>
		public override string ExcuteName() => "server.UpdateMapServerCache";

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
		public override object[] Parameters() => new object[] { ServerName, ObjectName, DataFrame, Layer, ConstrainingExtent, Levels, UpdateMode, ThreadCount, Antialiasing, OutServerName, OutObjectName };

		/// <summary>
		/// <para>Host</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object ServerName { get; set; }

		/// <summary>
		/// <para>Map Server</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ObjectName { get; set; }

		/// <summary>
		/// <para>Data Frame</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DataFrame { get; set; }

		/// <summary>
		/// <para>Input Layers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Layer { get; set; }

		/// <summary>
		/// <para>Update Extent</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object ConstrainingExtent { get; set; }

		/// <summary>
		/// <para>Scales</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Levels { get; set; }

		/// <summary>
		/// <para>Update Mode</para>
		/// <para><see cref="UpdateModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object UpdateMode { get; set; }

		/// <summary>
		/// <para>Number of caching service instances</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object ThreadCount { get; set; }

		/// <summary>
		/// <para>Antialiasing (Smoothes edges of labels and lines for improved display quality)</para>
		/// <para><see cref="AntialiasingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Antialiasing { get; set; } = "false";

		/// <summary>
		/// <para>Output Host</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutServerName { get; set; }

		/// <summary>
		/// <para>Output Map Server</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutObjectName { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Update Mode</para>
		/// </summary>
		public enum UpdateModeEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Recreate Empty Tiles")]
			[Description("Recreate Empty Tiles")]
			Recreate_Empty_Tiles,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Recreate All Tiles")]
			[Description("Recreate All Tiles")]
			Recreate_All_Tiles,

		}

		/// <summary>
		/// <para>Antialiasing (Smoothes edges of labels and lines for improved display quality)</para>
		/// </summary>
		public enum AntialiasingEnum 
		{
			/// <summary>
			/// <para>Antialiasing (Smoothes edges of labels and lines for improved display quality)</para>
			/// </summary>
			[GPValue("true")]
			[Description("Antialiasing")]
			Antialiasing,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

#endregion
	}
}
