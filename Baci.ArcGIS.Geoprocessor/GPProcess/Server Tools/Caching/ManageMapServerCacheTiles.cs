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
	/// <para>Creates and updates tiles in an existing web tile layer cache (in ArcGIS Enterprise or ArcGIS Online), web map image layers in ArcGIS Enterprise, and cached map or image services in a stand-alone server. This tool is used to create new tiles, replace missing tiles, overwrite outdated tiles, and delete tiles.</para>
	/// </summary>
	public class ManageMapServerCacheTiles : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputService">
		/// <para>Input Service</para>
		/// <para>The web tile layer, web map imagery layer, or map image layer whose cache tiles will be updated.</para>
		/// </param>
		/// <param name="Scales">
		/// <para>Scales</para>
		/// <para>A list of scale levels at which tiles will be created.</para>
		/// <para>By default, the scales listed in the tool dialog box are between the minimum and maximum cached scales for the service. You cannot change the cache scale range of the service in ArcGIS Pro.</para>
		/// </param>
		/// <param name="UpdateMode">
		/// <para>Update Mode</para>
		/// <para>Specifies the mode that will be used to update the cache.</para>
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
		public override object[] Parameters() => new object[] { InputService, Scales, UpdateMode, NumOfCachingServiceInstances!, AreaOfInterest!, UpdateExtent!, WaitForJobCompletion!, PortalUrl!, OutJobUrl! };

		/// <summary>
		/// <para>Input Service</para>
		/// <para>The web tile layer, web map imagery layer, or map image layer whose cache tiles will be updated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InputService { get; set; }

		/// <summary>
		/// <para>Scales</para>
		/// <para>A list of scale levels at which tiles will be created.</para>
		/// <para>By default, the scales listed in the tool dialog box are between the minimum and maximum cached scales for the service. You cannot change the cache scale range of the service in ArcGIS Pro.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Scales { get; set; }

		/// <summary>
		/// <para>Update Mode</para>
		/// <para>Specifies the mode that will be used to update the cache.</para>
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
		/// <para>The total number of instances of the System/CachingTools service that will be dedicated to running this tool. If the default value of -1 is used, all the caching tool instances of the ArcGIS Enterprise setup will be used. Use a lower value to use fewer caching tool instances.</para>
		/// <para>You can increase the Maximum number of instances per machine setting of the System/CachingTools service using the Service Editor window available through an administrative connection to ArcGIS Server. Ensure that the server machines can support the chosen number of instances.</para>
		/// <para>When connecting to a stand-alone server, the default number of instances is equal to the value of the Maximum number of instances setting of the caching tool service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? NumOfCachingServiceInstances { get; set; }

		/// <summary>
		/// <para>Area Of Interest</para>
		/// <para>An area of interest that will constrain where tiles will be created or deleted. This parameter is useful for managing tiles for irregularly shaped areas. It is also useful when pre-caching some areas and leaving less-visited areas uncached.</para>
		/// <para>If you do not provide a value for this parameter, the default value uses the full extent of the map.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureRecordSetLayer()]
		public object? AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Update Extent</para>
		/// <para>A rectangular extent used to create or delete tiles, depending on the value of the Update Mode parameter. If both the Update Extent and Area of Interest parameter values are specified, the Area of Interest value will be used.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Current Display Extent—The extent is equal to the data frame or visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		[Category("Area of interest (Envelope)")]
		public object? UpdateExtent { get; set; }

		/// <summary>
		/// <para>Wait for job completion</para>
		/// <para>Specifies whether the tool will continue to run while the cache job runs on ArcGIS Online or Portal for ArcGIS.</para>
		/// <para>Checked—The tool will continue to run while the cache job runs on Portal for ArcGIS or ArcGIS Online. With this option, you can request detailed progress reports at any time and view the geoprocessing messages as they appear. This is the default.</para>
		/// <para>Unchecked—A job will be submitted to the portal, allowing you to perform other geoprocessing tasks in ArcGIS Pro or close it. Use this option when you are building a cache automatically at the time you publish the service. You can also set this option on any other cache that you build.</para>
		/// <para><see cref="WaitForJobCompletionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? WaitForJobCompletion { get; set; } = "true";

		/// <summary>
		/// <para>Portal URL</para>
		/// <para>The URL of the portal.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? PortalUrl { get; set; }

		/// <summary>
		/// <para>Output Map Service URL</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? OutJobUrl { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ManageMapServerCacheTiles SetEnviroment(object? workspace = null)
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
			/// <para>Checked—The tool will continue to run while the cache job runs on Portal for ArcGIS or ArcGIS Online. With this option, you can request detailed progress reports at any time and view the geoprocessing messages as they appear. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("WAIT")]
			WAIT,

			/// <summary>
			/// <para>Unchecked—A job will be submitted to the portal, allowing you to perform other geoprocessing tasks in ArcGIS Pro or close it. Use this option when you are building a cache automatically at the time you publish the service. You can also set this option on any other cache that you build.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_WAIT")]
			DO_NOT_WAIT,

		}

#endregion
	}
}
