using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.NetworkAnalystTools
{
	/// <summary>
	/// <para>Share As Route Layers</para>
	/// <para>Shares the results of network analyses as route layer items in a portal.  A route layer includes all the information for a particular route such as the stops assigned to the route as well as the travel directions.</para>
	/// </summary>
	public class ShareAsRouteLayers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InNetworkAnalysisLayer">
		/// <para>Input Network Analysis Layer or  Route Data</para>
		/// <para>The network analysis layer or a .zip file containing the route data from which the route layer items are created. When the input is a network analysis layer, it should already be solved.</para>
		/// </param>
		public ShareAsRouteLayers(object InNetworkAnalysisLayer)
		{
			this.InNetworkAnalysisLayer = InNetworkAnalysisLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Share As Route Layers</para>
		/// </summary>
		public override string DisplayName => "Share As Route Layers";

		/// <summary>
		/// <para>Tool Name : ShareAsRouteLayers</para>
		/// </summary>
		public override string ToolName => "ShareAsRouteLayers";

		/// <summary>
		/// <para>Tool Excute Name : na.ShareAsRouteLayers</para>
		/// </summary>
		public override string ExcuteName => "na.ShareAsRouteLayers";

		/// <summary>
		/// <para>Toolbox Display Name : Network Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Network Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : na</para>
		/// </summary>
		public override string ToolboxAlise => "na";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "outputCoordinateSystem" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InNetworkAnalysisLayer, Summary!, Tags!, RouteNamePrefix!, PortalFolderName!, ShareWith!, Groups!, RouteLayerItems! };

		/// <summary>
		/// <para>Input Network Analysis Layer or  Route Data</para>
		/// <para>The network analysis layer or a .zip file containing the route data from which the route layer items are created. When the input is a network analysis layer, it should already be solved.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InNetworkAnalysisLayer { get; set; }

		/// <summary>
		/// <para>Summary</para>
		/// <para>The summary used by the route layer items. The summary is displayed as part of the item information for the route layer item. If a value is not specified, default summary text—Route and directions for <route name>—is used, where <route name> is replaced with the name of the route represented by the route layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Summary { get; set; }

		/// <summary>
		/// <para>Tags</para>
		/// <para>The tags used to describe and identify the route layer items. Individual tags are separated with commas. The route name is always included as a tag even when a value is not specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Tags { get; set; }

		/// <summary>
		/// <para>Route Name Prefix</para>
		/// <para>A qualifier added to the title of every route layer item. For example, a route name prefix Monday morning deliveries can be used to group all route layer items created from a route analysis performed by deliveries that should be executed on Monday morning. If a value is not specified, the title of the route layer item is created using only the route name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? RouteNamePrefix { get; set; }

		/// <summary>
		/// <para>Portal Folder Name</para>
		/// <para>The folder in your personal online workspace where the route layer items will be created. If a folder with the specified name does not exist, a folder will be created. If a folder with the specified name exists, the items will be created in the existing folder. If a value is not specified, the route layer items are created in the root folder of your online workspace.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? PortalFolderName { get; set; }

		/// <summary>
		/// <para>Share with</para>
		/// <para>Specifies who can access the route layer items. The parameter can be specified using the following keywords:</para>
		/// <para>Everyone— The route layer items will be public and can be accessed by anyone with the URL to the items.</para>
		/// <para>Not shared— The route layer items will only be shared with the owner of the item (the user connected to the portal when the tool is run). As a result, only the item owner can access the route layers. This is the default.</para>
		/// <para>These groups— The route layer items will be shared with groups the connected user belongs to and its members. The groups are specified using the groups parameter.</para>
		/// <para>Organization— The route layer items will be shared with all authenticated users in your organization.</para>
		/// <para><see cref="ShareWithEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ShareWith { get; set; } = "MYCONTENT";

		/// <summary>
		/// <para>Groups</para>
		/// <para>The list of groups with which the route layer items will be shared. This option is applicable only when the Share with parameter is set to These groups.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Groups { get; set; }

		/// <summary>
		/// <para>Route Layer Items</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object? RouteLayerItems { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ShareAsRouteLayers SetEnviroment(object? outputCoordinateSystem = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Share with</para>
		/// </summary>
		public enum ShareWithEnum 
		{
			/// <summary>
			/// <para>Everyone— The route layer items will be public and can be accessed by anyone with the URL to the items.</para>
			/// </summary>
			[GPValue("EVERYBODY")]
			[Description("Everyone")]
			Everyone,

			/// <summary>
			/// <para>Organization— The route layer items will be shared with all authenticated users in your organization.</para>
			/// </summary>
			[GPValue("MYORGANIZATION")]
			[Description("Organization")]
			Organization,

			/// <summary>
			/// <para>These groups— The route layer items will be shared with groups the connected user belongs to and its members. The groups are specified using the groups parameter.</para>
			/// </summary>
			[GPValue("MYGROUPS")]
			[Description("These groups")]
			These_groups,

			/// <summary>
			/// <para>Not shared— The route layer items will only be shared with the owner of the item (the user connected to the portal when the tool is run). As a result, only the item owner can access the route layers. This is the default.</para>
			/// </summary>
			[GPValue("MYCONTENT")]
			[Description("Not shared")]
			Not_shared,

		}

#endregion
	}
}
