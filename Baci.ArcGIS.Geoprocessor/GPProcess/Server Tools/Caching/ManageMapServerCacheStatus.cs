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
	/// <para>Manage Map Server Cache Status</para>
	/// <para>Manages internal data kept by the server about the built tiles in a map or image service cache.</para>
	/// </summary>
	public class ManageMapServerCacheStatus : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputService">
		/// <para>Input Service</para>
		/// <para>The map image layer for which the cache status will be modified.. You can choose it by browsing to the desired service in Portal or you can drag and drop a web tile layer from the Catalog pane Portal tab to supply this parameter.</para>
		/// </param>
		/// <param name="ManageMode">
		/// <para>Manage Mode</para>
		/// <para>Delete cache status—Deletes the status information used by the server.</para>
		/// <para>Rebuild cache status—Deletes, then rebuilds the status information used by the server.</para>
		/// <para>Rebuild bundle status—Creates status information in a new file geodatabase named Status.gdb in a folder you specify in the Output Folder parameter. This option is used when you want to create a custom status report for a particular area of interest or set of scales.</para>
		/// <para><see cref="ManageModeEnum"/></para>
		/// </param>
		public ManageMapServerCacheStatus(object InputService, object ManageMode)
		{
			this.InputService = InputService;
			this.ManageMode = ManageMode;
		}

		/// <summary>
		/// <para>Tool Display Name : Manage Map Server Cache Status</para>
		/// </summary>
		public override string DisplayName() => "Manage Map Server Cache Status";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputService, ManageMode, Scales, NumOfCachingServiceInstances, ReportFolder, AreaOfInterest, ReportExtent, OutputFolder };

		/// <summary>
		/// <para>Input Service</para>
		/// <para>The map image layer for which the cache status will be modified.. You can choose it by browsing to the desired service in Portal or you can drag and drop a web tile layer from the Catalog pane Portal tab to supply this parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InputService { get; set; }

		/// <summary>
		/// <para>Manage Mode</para>
		/// <para>Delete cache status—Deletes the status information used by the server.</para>
		/// <para>Rebuild cache status—Deletes, then rebuilds the status information used by the server.</para>
		/// <para>Rebuild bundle status—Creates status information in a new file geodatabase named Status.gdb in a folder you specify in the Output Folder parameter. This option is used when you want to create a custom status report for a particular area of interest or set of scales.</para>
		/// <para><see cref="ManageModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ManageMode { get; set; } = "REBUILD_CACHE_STATUS";

		/// <summary>
		/// <para>Scales</para>
		/// <para>The scale levels for which the status will be modified. This parameter is only applicable when building a custom status using the Rebuild bundle status option for the Manage Mode parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object Scales { get; set; }

		/// <summary>
		/// <para>Number of caching service instances</para>
		/// <para>Defines the number of instances that will be used to update/generate the tiles. The value for this parameter is set to unlimited (-1) and cannot be modified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumOfCachingServiceInstances { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>Output folder for the Status.gdb. This parameter is only applicable when building a custom status using the Rebuild bundle status option.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object ReportFolder { get; set; }

		/// <summary>
		/// <para>Area Of Interest</para>
		/// <para>An area of interest (polygon) that determines what geography the status report will cover. This parameter is only applicable when building a custom status using the Rebuild bundle status option.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Report Extent</para>
		/// <para>A rectangular extent defining the area for which the status will be built. This parameter is only applicable when building a custom status using the Rebuild bundle status option.</para>
		/// <para>Note that the Area Of Interest parameter allows you to specify an area of interest that is nonrectangular.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Current Display Extent—The extent is equal to the data frame or visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
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
			/// <para>Rebuild cache status—Deletes, then rebuilds the status information used by the server.</para>
			/// </summary>
			[GPValue("REBUILD_CACHE_STATUS")]
			[Description("Rebuild cache status")]
			Rebuild_cache_status,

			/// <summary>
			/// <para>Delete cache status—Deletes the status information used by the server.</para>
			/// </summary>
			[GPValue("DELETE_CACHE_STATUS")]
			[Description("Delete cache status")]
			Delete_cache_status,

			/// <summary>
			/// <para>Rebuild bundle status—Creates status information in a new file geodatabase named Status.gdb in a folder you specify in the Output Folder parameter. This option is used when you want to create a custom status report for a particular area of interest or set of scales.</para>
			/// </summary>
			[GPValue("REPORT_BUNDLE_STATUS")]
			[Description("Rebuild bundle status")]
			Rebuild_bundle_status,

		}

#endregion
	}
}
