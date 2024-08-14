using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Share Package</para>
	/// <para>Shares a package by uploading to ArcGIS Online or ArcGIS Enterprise.</para>
	/// </summary>
	public class SharePackage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPackage">
		/// <para>Input Package</para>
		/// <para>Input layer (.lpk, .lpkx), scene layer (.slpk), map (.mpk, .mpkx), geoprocessing (.gpk, .gpkx), tile (.tpk, .tpkx), mobile map (.mmpk), vector tile (.vtpk), address locator (.gcpk), or project (.ppkx, .aptx) package file.</para>
		/// </param>
		/// <param name="Username">
		/// <para>Username</para>
		/// <para>The ArcGIS Online or Portal for ArcGIS user name.</para>
		/// <para>This parameter is not available on the tool dialog box. You must sign in to a portal from the sign in option at the upper right of the application.</para>
		/// </param>
		/// <param name="Password">
		/// <para>Password</para>
		/// <para>The ArcGIS Online or ArcGIS Enterprise password.</para>
		/// <para>This parameter is not available on the tool dialog box. You must sign in to a portal from the sign in option at the upper right of the application.</para>
		/// </param>
		/// <param name="Summary">
		/// <para>Summary</para>
		/// <para>Summary of the package. The summary is displayed in the item information of the package on ArcGIS Online or ArcGIS Enterprise.</para>
		/// </param>
		/// <param name="Tags">
		/// <para>Tags</para>
		/// <para>Tags used to describe and identify the package. Individual tags are separated using either a comma or semicolon.</para>
		/// </param>
		public SharePackage(object InPackage, object Username, object Password, object Summary, object Tags)
		{
			this.InPackage = InPackage;
			this.Username = Username;
			this.Password = Password;
			this.Summary = Summary;
			this.Tags = Tags;
		}

		/// <summary>
		/// <para>Tool Display Name : Share Package</para>
		/// </summary>
		public override string DisplayName => "Share Package";

		/// <summary>
		/// <para>Tool Name : SharePackage</para>
		/// </summary>
		public override string ToolName => "SharePackage";

		/// <summary>
		/// <para>Tool Excute Name : management.SharePackage</para>
		/// </summary>
		public override string ExcuteName => "management.SharePackage";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InPackage, Username, Password, Summary, Tags, Credits, Public, Groups, OutResults, Organization, PublishWebLayer, PublishResults, PackageItemId, PortalFolder };

		/// <summary>
		/// <para>Input Package</para>
		/// <para>Input layer (.lpk, .lpkx), scene layer (.slpk), map (.mpk, .mpkx), geoprocessing (.gpk, .gpkx), tile (.tpk, .tpkx), mobile map (.mmpk), vector tile (.vtpk), address locator (.gcpk), or project (.ppkx, .aptx) package file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object InPackage { get; set; }

		/// <summary>
		/// <para>Username</para>
		/// <para>The ArcGIS Online or Portal for ArcGIS user name.</para>
		/// <para>This parameter is not available on the tool dialog box. You must sign in to a portal from the sign in option at the upper right of the application.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Username { get; set; }

		/// <summary>
		/// <para>Password</para>
		/// <para>The ArcGIS Online or ArcGIS Enterprise password.</para>
		/// <para>This parameter is not available on the tool dialog box. You must sign in to a portal from the sign in option at the upper right of the application.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPEncryptedString()]
		public object Password { get; set; }

		/// <summary>
		/// <para>Summary</para>
		/// <para>Summary of the package. The summary is displayed in the item information of the package on ArcGIS Online or ArcGIS Enterprise.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Summary { get; set; }

		/// <summary>
		/// <para>Tags</para>
		/// <para>Tags used to describe and identify the package. Individual tags are separated using either a comma or semicolon.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Tags { get; set; }

		/// <summary>
		/// <para>Credits</para>
		/// <para>Credits for the package. This is generally the name of the organization that is given credit for authoring and providing the content for the package.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Credits { get; set; }

		/// <summary>
		/// <para>Share with everyone</para>
		/// <para>Specifies whether the input package will be shared and available to everybody.</para>
		/// <para>Checked—Package will be shared with everybody.</para>
		/// <para>Unchecked—Package will be shared with package owner and any selected group. This is the default.</para>
		/// <para><see cref="PublicEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Public { get; set; } = "false";

		/// <summary>
		/// <para>Groups</para>
		/// <para>List of groups to share package with.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object Groups { get; set; }

		/// <summary>
		/// <para>Tool Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object OutResults { get; set; } = "false";

		/// <summary>
		/// <para>Share within organization only</para>
		/// <para>Specifies whether the input package will be available within your organization only or shared publicly to everyone.</para>
		/// <para>Everybody— Package will be shared with everybody. This is the default.</para>
		/// <para>Within my organization— Package will be shared within your organization only.</para>
		/// <para><see cref="OrganizationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Organization { get; set; } = "false";

		/// <summary>
		/// <para>Publish web layer</para>
		/// <para>Specifies whether the package will be published as a web layer to your portal. Only tile packages, vector tile packages, and scene layer packages are supported.</para>
		/// <para>Unchecked—The package will be uploaded without publishing. This is the default.</para>
		/// <para>Checked—The package will be uploaded and published as a web layer with the same name.</para>
		/// <para><see cref="PublishWebLayerEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object PublishWebLayer { get; set; } = "false";

		/// <summary>
		/// <para>Publish Results</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object PublishResults { get; set; }

		/// <summary>
		/// <para>Package Item ID</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPString()]
		public object PackageItemId { get; set; }

		/// <summary>
		/// <para>Folder</para>
		/// <para>Specifies an existing folder or the name of a new folder on the portal for the package. If a web layer is published, it is stored in the same folder.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PortalFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SharePackage SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Share with everyone</para>
		/// </summary>
		public enum PublicEnum 
		{
			/// <summary>
			/// <para>Checked—Package will be shared with everybody.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EVERYBODY")]
			EVERYBODY,

			/// <summary>
			/// <para>Unchecked—Package will be shared with package owner and any selected group. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("MYGROUPS")]
			MYGROUPS,

		}

		/// <summary>
		/// <para>Share within organization only</para>
		/// </summary>
		public enum OrganizationEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("EVERYBODY")]
			EVERYBODY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("MYORGANIZATION")]
			MYORGANIZATION,

		}

		/// <summary>
		/// <para>Publish web layer</para>
		/// </summary>
		public enum PublishWebLayerEnum 
		{
			/// <summary>
			/// <para>Checked—The package will be uploaded and published as a web layer with the same name.</para>
			/// </summary>
			[GPValue("true")]
			[Description("TRUE")]
			TRUE,

			/// <summary>
			/// <para>Unchecked—The package will be uploaded without publishing. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("FALSE")]
			FALSE,

		}

#endregion
	}
}
