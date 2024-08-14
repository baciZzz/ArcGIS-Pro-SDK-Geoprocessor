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
	/// <para>Update Globe Server Cache</para>
	/// <para>Updates a pre-rendered tiled cache for Globe Server.</para>
	/// </summary>
	[Obsolete()]
	public class UpdateGlobeServerCache : AbstractGPProcess
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
		/// <param name="Layer">
		/// <para>Input Layers</para>
		/// </param>
		/// <param name="LodFrom">
		/// <para>From Level of Detail</para>
		/// </param>
		/// <param name="LodTo">
		/// <para>To Level of Detail</para>
		/// </param>
		/// <param name="UpdateMode">
		/// <para>Update Mode</para>
		/// <para><see cref="UpdateModeEnum"/></para>
		/// </param>
		public UpdateGlobeServerCache(object ServerName, object ObjectName, object Layer, object LodFrom, object LodTo, object UpdateMode)
		{
			this.ServerName = ServerName;
			this.ObjectName = ObjectName;
			this.Layer = Layer;
			this.LodFrom = LodFrom;
			this.LodTo = LodTo;
			this.UpdateMode = UpdateMode;
		}

		/// <summary>
		/// <para>Tool Display Name : Update Globe Server Cache</para>
		/// </summary>
		public override string DisplayName => "Update Globe Server Cache";

		/// <summary>
		/// <para>Tool Name : UpdateGlobeServerCache</para>
		/// </summary>
		public override string ToolName => "UpdateGlobeServerCache";

		/// <summary>
		/// <para>Tool Excute Name : server.UpdateGlobeServerCache</para>
		/// </summary>
		public override string ExcuteName => "server.UpdateGlobeServerCache";

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
		public override object[] Parameters => new object[] { ServerName, ObjectName, UpdateExtent!, Layer, LodFrom, LodTo, ThreadCount!, UpdateMode };

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
		/// <para>Update Extent</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object? UpdateExtent { get; set; }

		/// <summary>
		/// <para>Input Layers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Layer { get; set; }

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
		public object? ThreadCount { get; set; }

		/// <summary>
		/// <para>Update Mode</para>
		/// <para><see cref="UpdateModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object UpdateMode { get; set; }

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

#endregion
	}
}
