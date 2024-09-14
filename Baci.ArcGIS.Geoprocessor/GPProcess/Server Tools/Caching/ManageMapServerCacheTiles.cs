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
	/// <para>Manage Map Server Cache Tiles</para>
	/// <para>Manage Map Server Cache Tiles</para>
	/// <para>Creates and updates tiles in an existing web tile layer cache. This tool is used to create new tiles, replace missing tiles, overwrite outdated tiles, and delete tiles.</para>
	/// </summary>
	public class ManageMapServerCacheTiles : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputService">
		/// <para>Input Service</para>
		/// <para>The web tile layer or map image layer whose cache tiles you want to update. You can choose it by browsing to the desired service in Portal or you can drag and drop a web tile layer from the Project pane Portal tab to supply this parameter.</para>
		/// </param>
		/// <param name="Scales">
		/// <para>Scales</para>
		/// <para>A list of scale levels at which tiles will be created.</para>
		/// <para>By default, the scales listed in the tool dialog are between the minimum and maximum cached scales for the service. You cannot change the cache scale range of the service with ArcGIS Pro.</para>
		/// </param>
		/// <param name="UpdateMode">
		/// <para>Update Mode</para>
		/// <para>The mode for updating the cache.</para>
		/// <para>Recreate Empty Tiles—Only tiles that are empty will be created. Existing tiles will be left unchanged. This option is not available for web tile layers published to ArcGIS Online.</para>
		/// <para>Recreate All Tiles—Existing tiles will be replaced and new tiles will be added if the extent has changed.</para>
		/// <para>Delete Tiles—Tiles will be deleted from the cache. The cache folder structure will not be deleted.</para>
		/// <para><see cref="UpdateModeEnum"/></para>
		/// </param>
		public ManageMapServerCacheTiles(object InputService, object Scales, object UpdateMode)
		{
			this.InputService = InputService;
			this.Scales = Scales;
			this.UpdateMode = UpdateMode;
		}

		/// <summary>
		/// <para>Tool Display Name : Manage Map Server Cache Tiles</para>
		/// </summary>
		public override string DisplayName() => "Manage Map Server Cache Tiles";

		/// <summary>
		/// <para>Tool Name : ManageMapServerCacheTiles</para>
		/// </summary>
		public override string ToolName() => "ManageMapServerCacheTiles";

		/// <summary>
		/// <para>Tool Excute Name : server.ManageMapServerCacheTiles</para>
		/// </summary>
		public override string ExcuteName() => "server.ManageMapServerCacheTiles";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputService, Scales, UpdateMode, NumOfCachingServiceInstances, AreaOfInterest, UpdateExtent, WaitForJobCompletion, PortalUrl, OutJobUrl };

		/// <summary>
		/// <para>Input Service</para>
		/// <para>The web tile layer or map image layer whose cache tiles you want to update. You can choose it by browsing to the desired service in Portal or you can drag and drop a web tile layer from the Project pane Portal tab to supply this parameter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InputService { get; set; }

		/// <summary>
		/// <para>Scales</para>
		/// <para>A list of scale levels at which tiles will be created.</para>
		/// <para>By default, the scales listed in the tool dialog are between the minimum and maximum cached scales for the service. You cannot change the cache scale range of the service with ArcGIS Pro.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Scales { get; set; }

		/// <summary>
		/// <para>Update Mode</para>
		/// <para>The mode for updating the cache.</para>
		/// <para>Recreate Empty Tiles—Only tiles that are empty will be created. Existing tiles will be left unchanged. This option is not available for web tile layers published to ArcGIS Online.</para>
		/// <para>Recreate All Tiles—Existing tiles will be replaced and new tiles will be added if the extent has changed.</para>
		/// <para>Delete Tiles—Tiles will be deleted from the cache. The cache folder structure will not be deleted.</para>
		/// <para><see cref="UpdateModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object UpdateMode { get; set; } = "RECREATE_ALL_TILES";

		/// <summary>
		/// <para>Number of caching service instances</para>
		/// <para>Defines the number of instances that will be used to update/generate the tiles. The value for this parameter is set to unlimited (-1) and cannot be modified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object NumOfCachingServiceInstances { get; set; }

		/// <summary>
		/// <para>Area Of Interest</para>
		/// <para>Defines an area of interest to constrain where tiles will be created or deleted. This parameter is useful if you want to manage tiles for irregularly shaped areas. It&apos;s also useful in situations where you want to pre-cache some areas and leave less-visited areas uncached.</para>
		/// <para>If you do not provide a value for this parameter, the default is to use the full extent of the map.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Update Extent</para>
		/// <para>Rectangular extent at which to create or delete tiles, depending on the value of the Update Mode parameter. It is not recommended you provide values for both Update Extent and Area of Interest. If values for both parameters are provided, the value of Area of Interest will be used.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Current Display Extent—The extent is equal to the data frame or visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		[Category("Area of interest (Envelope)")]
		public object UpdateExtent { get; set; }

		/// <summary>
		/// <para>Wait for job completion</para>
		/// <para>This parameter allows you to watch the progress of the cache job running on ArcGIS Online or Portal for ArcGIS.</para>
		/// <para>Checked—This tool will continue to run in Pro while the cache job runs on your Portal for ArcGIS or ArcGIS Online. With this option, you can request detailed progress reports at any time and view the geoprocessing messages as they appear.</para>
		/// <para>Unchecked—This tool will submit the job to the Portal, allowing you to perform other geoprocessing tasks in ArcGIS Pro or even close it. This option is used when you choose to build a cache automatically at the time you publish the service, and you can also set this option on any other cache that you build.</para>
		/// <para><see cref="WaitForJobCompletionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object WaitForJobCompletion { get; set; } = "true";

		/// <summary>
		/// <para>Portal URL</para>
		/// <para>The portal URL.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object PortalUrl { get; set; }

		/// <summary>
		/// <para>Output Map Service URL</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object OutJobUrl { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ManageMapServerCacheTiles SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Update Mode</para>
		/// </summary>
		public enum UpdateModeEnum 
		{
			/// <summary>
			/// <para>Recreate Empty Tiles—Only tiles that are empty will be created. Existing tiles will be left unchanged. This option is not available for web tile layers published to ArcGIS Online.</para>
			/// </summary>
			[GPValue("RECREATE_EMPTY_TILES")]
			[Description("Recreate Empty Tiles")]
			Recreate_Empty_Tiles,

			/// <summary>
			/// <para>Recreate All Tiles—Existing tiles will be replaced and new tiles will be added if the extent has changed.</para>
			/// </summary>
			[GPValue("RECREATE_ALL_TILES")]
			[Description("Recreate All Tiles")]
			Recreate_All_Tiles,

			/// <summary>
			/// <para>Delete Tiles—Tiles will be deleted from the cache. The cache folder structure will not be deleted.</para>
			/// </summary>
			[GPValue("DELETE_TILES")]
			[Description("Delete Tiles")]
			Delete_Tiles,

		}

		/// <summary>
		/// <para>Wait for job completion</para>
		/// </summary>
		public enum WaitForJobCompletionEnum 
		{
			/// <summary>
			/// <para>Checked—This tool will continue to run in Pro while the cache job runs on your Portal for ArcGIS or ArcGIS Online. With this option, you can request detailed progress reports at any time and view the geoprocessing messages as they appear.</para>
			/// </summary>
			[GPValue("true")]
			[Description("WAIT")]
			WAIT,

			/// <summary>
			/// <para>Unchecked—This tool will submit the job to the Portal, allowing you to perform other geoprocessing tasks in ArcGIS Pro or even close it. This option is used when you choose to build a cache automatically at the time you publish the service, and you can also set this option on any other cache that you build.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_WAIT")]
			DO_NOT_WAIT,

		}

#endregion
	}
}
