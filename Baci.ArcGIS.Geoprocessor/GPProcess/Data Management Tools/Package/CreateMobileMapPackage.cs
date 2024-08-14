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
	/// <para>Create Mobile Map Package</para>
	/// <para>Packages maps and basemaps along with all referenced data sources into a single .mmpk file.</para>
	/// </summary>
	public class CreateMobileMapPackage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMap">
		/// <para>Input Map</para>
		/// <para>One or more maps or basemaps that will be packaged into a single .mmpk file.</para>
		/// </param>
		/// <param name="OutputFile">
		/// <para>Output File</para>
		/// <para>The output mobile map package (.mmpk).</para>
		/// </param>
		public CreateMobileMapPackage(object InMap, object OutputFile)
		{
			this.InMap = InMap;
			this.OutputFile = OutputFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Create Mobile Map Package</para>
		/// </summary>
		public override string DisplayName => "Create Mobile Map Package";

		/// <summary>
		/// <para>Tool Name : CreateMobileMapPackage</para>
		/// </summary>
		public override string ToolName => "CreateMobileMapPackage";

		/// <summary>
		/// <para>Tool Excute Name : management.CreateMobileMapPackage</para>
		/// </summary>
		public override string ExcuteName => "management.CreateMobileMapPackage";

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
		public override string[] ValidEnvironments => new string[] { "extent", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InMap, OutputFile, InLocator!, AreaOfInterest!, Extent!, ClipFeatures!, Title!, Summary!, Description!, Tags!, Credits!, UseLimitations!, AnonymousUse!, EnableMapExpiration!, MapExpirationType!, ExpirationDate!, ExpirationMessage!, SelectRelatedRows!, ReferenceOnlineContent! };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>One or more maps or basemaps that will be packaged into a single .mmpk file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPMapDomain()]
		public object InMap { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>The output mobile map package (.mmpk).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutputFile { get; set; }

		/// <summary>
		/// <para>Input Locator</para>
		/// <para>Locators have the following restrictions:</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPLocatorsDomain()]
		public object? InLocator { get; set; }

		/// <summary>
		/// <para>Area of Interest</para>
		/// <para>Polygon layer that defines the area of interest. Only those features that intersect the Area of Interest value will be included in the mobile map package.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		public object? AreaOfInterest { get; set; }

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
		public object? Extent { get; set; }

		/// <summary>
		/// <para>Clip Features</para>
		/// <para>Specifies whether the output features will be clipped to the given Area of Interest value or Extent value.</para>
		/// <para>Checked—The geometry of the features will be clipped to the given Area of Interest value or Extent value.</para>
		/// <para>Unchecked—Features in the map will be selected and their geometry will remain unaltered. This is the default.</para>
		/// <para><see cref="ClipFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ClipFeatures { get; set; } = "false";

		/// <summary>
		/// <para>Title</para>
		/// <para>Adds title information to the properties of the package.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Title { get; set; }

		/// <summary>
		/// <para>Summary</para>
		/// <para>Adds summary information to the properties of the package.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Summary { get; set; }

		/// <summary>
		/// <para>Description</para>
		/// <para>Adds description information to the properties of the package.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Description { get; set; }

		/// <summary>
		/// <para>Tags</para>
		/// <para>Adds tag information to the properties of the package. Multiple tags can be added or separated by a comma or semicolon.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Tags { get; set; }

		/// <summary>
		/// <para>Credits</para>
		/// <para>Adds credit information to the properties of the package.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Credits { get; set; }

		/// <summary>
		/// <para>Use Limitations</para>
		/// <para>Adds use limitations to the properties of the package.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? UseLimitations { get; set; }

		/// <summary>
		/// <para>Enable Anonymous Use</para>
		/// <para>Specifies whether the mobile map can be used by anyone.</para>
		/// <para>Checked—Anyone with access to the package can use the mobile map without signing in with an Esri Named User account.</para>
		/// <para>Unchecked—Anyone with access to the package must be signed in with a Named User account to use the mobile map. This is the default.</para>
		/// <para>This optional parameter is only available with the Publisher extension.</para>
		/// <para><see cref="AnonymousUseEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AnonymousUse { get; set; } = "false";

		/// <summary>
		/// <para>Enable Map Expiration</para>
		/// <para>Specifies whether a time-out will be enabled on the mobile map package.</para>
		/// <para>Checked—Time-out will be enabled on the mobile map package.</para>
		/// <para>Unchecked—Time-out will not be enabled on the mobile map package. This is the default.</para>
		/// <para>This optional parameter is only available with the Publisher extension.</para>
		/// <para><see cref="EnableMapExpirationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? EnableMapExpiration { get; set; } = "false";

		/// <summary>
		/// <para>Map Expiration Type</para>
		/// <para>Specifies the type of access a user will have to the expired mobile map package.</para>
		/// <para>Allow to open—A user of the package will be warned that the map has expired, but will be allowed to open it. This is the default.</para>
		/// <para>Do not allow to open—A user of the package will be warned that the map has expired, and will not be allowed to open it.</para>
		/// <para>This optional parameter is only available with the Publisher extension.</para>
		/// <para><see cref="MapExpirationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? MapExpirationType { get; set; } = "ALLOW_TO_OPEN";

		/// <summary>
		/// <para>Expiration Date</para>
		/// <para>Specifies the date the mobile map package will expire.</para>
		/// <para>This optional parameter is only available with the Publisher extension.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? ExpirationDate { get; set; }

		/// <summary>
		/// <para>Expiration Message</para>
		/// <para>A text message that will display when an expired map is accessed.</para>
		/// <para>This optional parameter is only available with the Publisher extension.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ExpirationMessage { get; set; } = "This map is expired.  Contact the map publisher for an updated map.";

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
		public object? SelectRelatedRows { get; set; } = "false";

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
		public object? ReferenceOnlineContent { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateMobileMapPackage SetEnviroment(object? extent = null , object? parallelProcessingFactor = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Clip Features</para>
		/// </summary>
		public enum ClipFeaturesEnum 
		{
			/// <summary>
			/// <para>Checked—The geometry of the features will be clipped to the given Area of Interest value or Extent value.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CLIP")]
			CLIP,

			/// <summary>
			/// <para>Unchecked—Features in the map will be selected and their geometry will remain unaltered. This is the default.</para>
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
			/// <para>Checked—Anyone with access to the package can use the mobile map without signing in with an Esri Named User account.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ANONYMOUS_USE")]
			ANONYMOUS_USE,

			/// <summary>
			/// <para>Unchecked—Anyone with access to the package must be signed in with a Named User account to use the mobile map. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("STANDARD")]
			STANDARD,

		}

		/// <summary>
		/// <para>Enable Map Expiration</para>
		/// </summary>
		public enum EnableMapExpirationEnum 
		{
			/// <summary>
			/// <para>Checked—Time-out will be enabled on the mobile map package.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ENABLE_MAP_EXPIRATION")]
			ENABLE_MAP_EXPIRATION,

			/// <summary>
			/// <para>Unchecked—Time-out will not be enabled on the mobile map package. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DISABLE_MAP_EXPIRATION")]
			DISABLE_MAP_EXPIRATION,

		}

		/// <summary>
		/// <para>Map Expiration Type</para>
		/// </summary>
		public enum MapExpirationTypeEnum 
		{
			/// <summary>
			/// <para>Allow to open—A user of the package will be warned that the map has expired, but will be allowed to open it. This is the default.</para>
			/// </summary>
			[GPValue("ALLOW_TO_OPEN")]
			[Description("Allow to open")]
			Allow_to_open,

			/// <summary>
			/// <para>Do not allow to open—A user of the package will be warned that the map has expired, and will not be allowed to open it.</para>
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
