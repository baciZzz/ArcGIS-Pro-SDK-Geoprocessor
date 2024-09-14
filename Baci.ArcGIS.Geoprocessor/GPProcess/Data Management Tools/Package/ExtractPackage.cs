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
	/// <para>Extract Package</para>
	/// <para>Extract Package</para>
	/// <para>Extracts the contents of a package to a specified folder. The output folder will be  updated with the extracted contents of the input package.</para>
	/// </summary>
	public class ExtractPackage : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPackage">
		/// <para>Input Package</para>
		/// <para>The input package that will be extracted.</para>
		/// </param>
		public ExtractPackage(object InPackage)
		{
			this.InPackage = InPackage;
		}

		/// <summary>
		/// <para>Tool Display Name : Extract Package</para>
		/// </summary>
		public override string DisplayName() => "Extract Package";

		/// <summary>
		/// <para>Tool Name : ExtractPackage</para>
		/// </summary>
		public override string ToolName() => "ExtractPackage";

		/// <summary>
		/// <para>Tool Excute Name : management.ExtractPackage</para>
		/// </summary>
		public override string ExcuteName() => "management.ExtractPackage";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPackage, OutputFolder, CachePackage, StorageFormatType, CreateReadyToServeFormat, TargetCloudConnection };

		/// <summary>
		/// <para>Input Package</para>
		/// <para>The input package that will be extracted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("lpk", "mpk", "gpk", "lpkx", "mpkx", "mmpk", "mspk", "gpkx", "gcpk", "ppkx", "aptx", "tpk", "tpkx", "vtpk", "slpk")]
		public object InPackage { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>The output folder that will contain the contents of the package.</para>
		/// <para>If the specified folder does not exist, a folder will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object OutputFolder { get; set; }

		/// <summary>
		/// <para>Cache Package</para>
		/// <para>Specifies whether a copy of the package will be cached to your profile.</para>
		/// <para>When extracting a package, the output is first extracted to your user profile and appended with a unique ID before a copy is made to the directory specified in the Output Folder parameter. Downloading and extracting subsequent versions of the same package will only update this location. You do not need to manually create a cached version of the package in your user profile when using this parameter. This parameter is not active if the input package is a vector tile package (.vtpk) or a tile package (.tpk and .tpkx).</para>
		/// <para>Checked—A copy of the package will be extracted and cached to your profile. This is the default.</para>
		/// <para>Unchecked—A copy of the package will only be extracted to the output parameter specified; it will not be cached.</para>
		/// <para><see cref="CachePackageEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CachePackage { get; set; } = "true";

		/// <summary>
		/// <para>Storage Format Type</para>
		/// <para>Specifies the storage format that will be used for the extracted cache. This parameter is applicable only when the input package is a vector tile package (.vtpk).</para>
		/// <para>Compact— The tiles will be grouped in bundle files using the Compact V2 storage format. This format provides better performance on network shares and cloud store directories. This is the default.</para>
		/// <para>Exploded— Each tile will be stored as an individual file.</para>
		/// <para><see cref="StorageFormatTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object StorageFormatType { get; set; } = "COMPACT";

		/// <summary>
		/// <para>Create Ready To Serve Cache Dataset</para>
		/// <para>Specifies whether a ready-to-serve format for ArcGIS Enterprise will be created. This parameter is active only when the input package is a vector tile package (.vtpk) or a tile package (.tpkx).</para>
		/// <para>Checked—A folder structure with an extracted cache that can be used to create a tile layer in ArcGIS Enterprise will be created. The file extension of the folder signifies the content it stores: .tiles (cache dataset) for tile layer packages or .vtiles (vector cache dataset) for vector tile packages.</para>
		/// <para>Unchecked—A folder structure with extracted contents of the package will be created. This is the default.</para>
		/// <para><see cref="CreateReadyToServeFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CreateReadyToServeFormat { get; set; } = "false";

		/// <summary>
		/// <para>Target Cloud Connection</para>
		/// <para>The target .acs file to which the package contents will be extracted. This parameter is enabled only when the input package is a scene layer package (.slpk), a vector tile package (.vtpk), or a tile package (.tpkx).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFolder()]
		public object TargetCloudConnection { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractPackage SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Cache Package</para>
		/// </summary>
		public enum CachePackageEnum 
		{
			/// <summary>
			/// <para>Checked—A copy of the package will be extracted and cached to your profile. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CACHE")]
			CACHE,

			/// <summary>
			/// <para>Unchecked—A copy of the package will only be extracted to the output parameter specified; it will not be cached.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CACHE")]
			NO_CACHE,

		}

		/// <summary>
		/// <para>Storage Format Type</para>
		/// </summary>
		public enum StorageFormatTypeEnum 
		{
			/// <summary>
			/// <para>Compact— The tiles will be grouped in bundle files using the Compact V2 storage format. This format provides better performance on network shares and cloud store directories. This is the default.</para>
			/// </summary>
			[GPValue("COMPACT")]
			[Description("Compact")]
			Compact,

			/// <summary>
			/// <para>Exploded— Each tile will be stored as an individual file.</para>
			/// </summary>
			[GPValue("EXPLODED")]
			[Description("Exploded")]
			Exploded,

		}

		/// <summary>
		/// <para>Create Ready To Serve Cache Dataset</para>
		/// </summary>
		public enum CreateReadyToServeFormatEnum 
		{
			/// <summary>
			/// <para>Checked—A folder structure with an extracted cache that can be used to create a tile layer in ArcGIS Enterprise will be created. The file extension of the folder signifies the content it stores: .tiles (cache dataset) for tile layer packages or .vtiles (vector cache dataset) for vector tile packages.</para>
			/// </summary>
			[GPValue("true")]
			[Description("READY_TO_SERVE_CACHE_DATASET")]
			READY_TO_SERVE_CACHE_DATASET,

			/// <summary>
			/// <para>Unchecked—A folder structure with extracted contents of the package will be created. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("EXTRACTED_PACKAGE")]
			EXTRACTED_PACKAGE,

		}

#endregion
	}
}
