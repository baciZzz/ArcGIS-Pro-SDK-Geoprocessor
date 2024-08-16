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
	/// <para>Create Mobile Scene Package</para>
	/// <para>Creates a mobile scene package file (.mspk) from one or more scenes for use across the ArcGIS platform.</para>
	/// </summary>
	public class CreateMobileScenePackage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InScene">
		/// <para>Input Scene</para>
		/// <para>One or more local or global scenes that will be packaged into a single .mspk file. Active scenes and .mapx files can be added as input.</para>
		/// </param>
		/// <param name="OutputFile">
		/// <para>Output File</para>
		/// <para>The output mobile scene package .mspk file.</para>
		/// </param>
		public CreateMobileScenePackage(object InScene, object OutputFile)
		{
			this.InScene = InScene;
			this.OutputFile = OutputFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Mobile Scene Package</para>
		/// </summary>
		public override string DisplayName => "Create Mobile Scene Package";

		/// <summary>
		/// <para>Tool Name : CreateMobileScenePackage</para>
		/// </summary>
		public override string ToolName => "CreateMobileScenePackage";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateMobileScenePackage</para>
		/// </summary>
		public override string ExcuteName => "management.CreateMobileScenePackage";

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
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InScene, OutputFile, InLocator, AreaOfInterest, Extent, ClipFeatures, Title, Summary, Description, Tags, Credits, UseLimitations, AnonymousUse, TextureOptimization, EnableSceneExpiration, SceneExpirationType, ExpirationDate, ExpirationMessage, SelectRelatedRows, ReferenceOnlineContent };

		/// <summary>
		/// <para>Input Scene</para>
		/// <para>One or more local or global scenes that will be packaged into a single .mspk file. Active scenes and .mapx files can be added as input.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPMapDomain()]
		[MapType("1")]
		public object InScene { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>The output mobile scene package .mspk file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("mspk")]
		public object OutputFile { get; set; }

		/// <summary>
		/// <para>Input Locator</para>
		/// <para>Locators have the following restrictions:</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPLocatorsDomain()]
		public object InLocator { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>A polygon layer that defines the area of interest. Only those features that intersect the area of interest will be included in the mobile scene package.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object AreaOfInterest { get; set; }

		/// <summary>
		/// <para>Extent</para>
		/// <para>Specifies the extent that will be used to select or clip features.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Union of Inputs—The extent will be based on the maximum extent of all inputs.</para>
		/// <para>Intersection of Inputs—The extent will be based on the minimum area common to all inputs.</para>
		/// <para>Current Display Extent—The extent is equal to the visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object Extent { get; set; }

		/// <summary>
		/// <para>Clip Features</para>
		/// <para>Specifies whether the output features will be clipped to the given area of interest or extent.</para>
		/// <para>Checked—The geometry of the features will be clipped to the given area of interest or extent.</para>
		/// <para>Unchecked—Features in the scene will be selected and their geometry will remain unaltered. This is the default.</para>
		/// <para>Multipatch feature layers, 3D point feature layers, LAS dataset layers, service layers, tile packages, and scene layer packages, cannot be clipped and will be completely copied to the mobile scene package.</para>
		/// <para><see cref="ClipFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ClipFeatures { get; set; } = "false";

		/// <summary>
		/// <para>Title</para>
		/// <para>Adds title information to the properties of the package.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Title { get; set; }

		/// <summary>
		/// <para>Summary</para>
		/// <para>Adds summary information to the properties of the package.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Summary { get; set; }

		/// <summary>
		/// <para>Description</para>
		/// <para>Adds description information to the properties of the package.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Description { get; set; }

		/// <summary>
		/// <para>Tags</para>
		/// <para>Adds tag information to the properties of the package. Multiple tags can be added, separated by a comma or semicolon.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Tags { get; set; }

		/// <summary>
		/// <para>Credits</para>
		/// <para>Adds credit information to the properties of the package.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Credits { get; set; }

		/// <summary>
		/// <para>Use Limitations</para>
		/// <para>Adds use limitations to the properties of the package.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object UseLimitations { get; set; }

		/// <summary>
		/// <para>Enable Anonymous Use</para>
		/// <para>Specifies whether the mobile scenes can be used by anyone or only those with an ArcGIS account.</para>
		/// <para>Checked—Anyone with access to the package can use the mobile scene without signing in with an Esri named user account.</para>
		/// <para>Unchecked—Anyone with access to the package must be signed in with a named user account to use the mobile scene. This is the default.</para>
		/// <para>This optional parameter is only available with the Publisher extension.</para>
		/// <para><see cref="AnonymousUseEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AnonymousUse { get; set; } = "false";

		/// <summary>
		/// <para>Texture Optimization</para>
		/// <para>Specifies the texture optimization that will be used. Textures are optimized according to the target platform where the scene layer package will be used. This parameter applies to scene layer packages only.</para>
		/// <para>Optimizations that include ETC2 may take significant time to process. For fastest results, use Desktop or None.</para>
		/// <para>All—All texture formats including JPEG, DXT, and ETC2 for use in desktop, web, and mobile can be used.</para>
		/// <para>Desktop—Windows-, Linux-, and Mac-supported textures including JPEG and DXT can be used in the ArcGIS Pro client on Windows and ArcGIS Runtime desktop clients on Windows, Linux, and Mac. This is the default.</para>
		/// <para>Mobile—Android- and iOS-supported textures including JPEG and ETC2 can be used in ArcGIS Runtime mobile applications.</para>
		/// <para>None—JPEG textures can be used in desktop and web platforms.</para>
		/// <para><see cref="TextureOptimizationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TextureOptimization { get; set; } = "DESKTOP";

		/// <summary>
		/// <para>Enable Scene Expiration</para>
		/// <para>Specifies whether the mobile scene package will time out.</para>
		/// <para>Checked—Time-out is enabled on the mobile scene package.</para>
		/// <para>Unchecked—Time-out is not enabled on the mobile scene package. This is the default.</para>
		/// <para>This optional parameter is only available with the Publisher extension.</para>
		/// <para><see cref="EnableSceneExpirationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object EnableSceneExpiration { get; set; } = "false";

		/// <summary>
		/// <para>Scene Expiration Type</para>
		/// <para>Specifies the type of scene access for the expired mobile scene package.</para>
		/// <para>Allow to open—The user of the package will be warned that the scene has expired, and allowed to open the scene. This is the default.</para>
		/// <para>Do not allow to open—The user of the package will be warned that the scene has expired and will not be allowed to open the package.</para>
		/// <para>This optional parameter is only available with the Publisher extension.</para>
		/// <para><see cref="SceneExpirationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SceneExpirationType { get; set; } = "ALLOW_TO_OPEN";

		/// <summary>
		/// <para>Expiration Date</para>
		/// <para>The date the mobile scene package will expire.</para>
		/// <para>This optional parameter is only available with the Publisher extension.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object ExpirationDate { get; set; }

		/// <summary>
		/// <para>Expiration Message</para>
		/// <para>A text message will appear when an expired scene is accessed.</para>
		/// <para>This optional parameter is only available with the Publisher extension.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ExpirationMessage { get; set; } = "This scene is expired, Contact the scene publisher for an updated scene";

		/// <summary>
		/// <para>Keep only the rows which are related to features within the extent</para>
		/// <para>Specifies whether the specified extent will be applied to related data sources.</para>
		/// <para>Unchecked—Related data sources will be consolidated in their entirety. This is the default.</para>
		/// <para>Checked—Only related data corresponding to records within the specified extent will be consolidated.</para>
		/// <para><see cref="SelectRelatedRowsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SelectRelatedRows { get; set; } = "false";

		/// <summary>
		/// <para>Reference Online Content</para>
		/// <para>Specifies whether service layers will be referenced in the package.</para>
		/// <para>Unchecked—Service layers will not be referenced in the mobile package. This is the default.</para>
		/// <para>Checked—Service layers will be referenced in the mobile package.</para>
		/// <para><see cref="ReferenceOnlineContentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ReferenceOnlineContent { get; set; } = "false";

		#region InnerClass

		/// <summary>
		/// <para>Clip Features</para>
		/// </summary>
		public enum ClipFeaturesEnum 
		{
			/// <summary>
			/// <para>Checked—The geometry of the features will be clipped to the given area of interest or extent.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CLIP")]
			CLIP,

			/// <summary>
			/// <para>Unchecked—Features in the scene will be selected and their geometry will remain unaltered. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("SELECT")]
			SELECT,

		}

		/// <summary>
		/// <para>Enable Anonymous Use</para>
		/// </summary>
		public enum AnonymousUseEnum 
		{
			/// <summary>
			/// <para>Checked—Anyone with access to the package can use the mobile scene without signing in with an Esri named user account.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ANONYMOUS_USE")]
			ANONYMOUS_USE,

			/// <summary>
			/// <para>Unchecked—Anyone with access to the package must be signed in with a named user account to use the mobile scene. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("STANDARD")]
			STANDARD,

		}

		/// <summary>
		/// <para>Texture Optimization</para>
		/// </summary>
		public enum TextureOptimizationEnum 
		{
			/// <summary>
			/// <para>All—All texture formats including JPEG, DXT, and ETC2 for use in desktop, web, and mobile can be used.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All")]
			All,

			/// <summary>
			/// <para>Desktop—Windows-, Linux-, and Mac-supported textures including JPEG and DXT can be used in the ArcGIS Pro client on Windows and ArcGIS Runtime desktop clients on Windows, Linux, and Mac. This is the default.</para>
			/// </summary>
			[GPValue("DESKTOP")]
			[Description("Desktop")]
			Desktop,

			/// <summary>
			/// <para>Mobile—Android- and iOS-supported textures including JPEG and ETC2 can be used in ArcGIS Runtime mobile applications.</para>
			/// </summary>
			[GPValue("MOBILE")]
			[Description("Mobile")]
			Mobile,

			/// <summary>
			/// <para>None—JPEG textures can be used in desktop and web platforms.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

		}

		/// <summary>
		/// <para>Enable Scene Expiration</para>
		/// </summary>
		public enum EnableSceneExpirationEnum 
		{
			/// <summary>
			/// <para>Checked—Time-out is enabled on the mobile scene package.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ENABLE_SCENE_EXPIRATION")]
			ENABLE_SCENE_EXPIRATION,

			/// <summary>
			/// <para>Unchecked—Time-out is not enabled on the mobile scene package. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DISABLE_SCENE_EXPIRATION")]
			DISABLE_SCENE_EXPIRATION,

		}

		/// <summary>
		/// <para>Scene Expiration Type</para>
		/// </summary>
		public enum SceneExpirationTypeEnum 
		{
			/// <summary>
			/// <para>Allow to open—The user of the package will be warned that the scene has expired, and allowed to open the scene. This is the default.</para>
			/// </summary>
			[GPValue("ALLOW_TO_OPEN")]
			[Description("Allow to open")]
			Allow_to_open,

			/// <summary>
			/// <para>Do not allow to open—The user of the package will be warned that the scene has expired and will not be allowed to open the package.</para>
			/// </summary>
			[GPValue("DONOT_ALLOW_TO_OPEN")]
			[Description("Do not allow to open")]
			Do_not_allow_to_open,

		}

		/// <summary>
		/// <para>Keep only the rows which are related to features within the extent</para>
		/// </summary>
		public enum SelectRelatedRowsEnum 
		{
			/// <summary>
			/// <para>Checked—Only related data corresponding to records within the specified extent will be consolidated.</para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_ONLY_RELATED_ROWS")]
			KEEP_ONLY_RELATED_ROWS,

			/// <summary>
			/// <para>Unchecked—Related data sources will be consolidated in their entirety. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("KEEP_ALL_RELATED_ROWS")]
			KEEP_ALL_RELATED_ROWS,

		}

		/// <summary>
		/// <para>Reference Online Content</para>
		/// </summary>
		public enum ReferenceOnlineContentEnum 
		{
			/// <summary>
			/// <para>Checked—Service layers will be referenced in the mobile package.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_SERVICE_LAYERS")]
			INCLUDE_SERVICE_LAYERS,

			/// <summary>
			/// <para>Unchecked—Service layers will not be referenced in the mobile package. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE_SERVICE_LAYERS")]
			EXCLUDE_SERVICE_LAYERS,

		}

#endregion
	}
}
