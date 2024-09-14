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
	/// <para>Package Map</para>
	/// <para>Package Map</para>
	/// <para>Packages a map and all referenced data sources to create a single compressed .mpkx file.</para>
	/// </summary>
	public class PackageMap : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMap">
		/// <para>Input  Map</para>
		/// <para>The map (.mapx) to be packaged. When running this tool in ArcGIS Pro, the input can be a map, scene, or basemap.</para>
		/// </param>
		/// <param name="OutputFile">
		/// <para>Output File</para>
		/// <para>The output map package (.mpkx).</para>
		/// </param>
		public PackageMap(object InMap, object OutputFile)
		{
			this.InMap = InMap;
			this.OutputFile = OutputFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Package Map</para>
		/// </summary>
		public override string DisplayName() => "Package Map";

		/// <summary>
		/// <para>Tool Name : PackageMap</para>
		/// </summary>
		public override string ToolName() => "PackageMap";

		/// <summary>
		/// <para>Tool Excute Name : management.PackageMap</para>
		/// </summary>
		public override string ExcuteName() => "management.PackageMap";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMap, OutputFile, ConvertData, ConvertArcsdeData, Extent, ApplyExtentToArcsde, Arcgisruntime, ReferenceAllData, Version, AdditionalFiles, Summary, Tags, SelectRelatedRows };

		/// <summary>
		/// <para>Input  Map</para>
		/// <para>The map (.mapx) to be packaged. When running this tool in ArcGIS Pro, the input can be a map, scene, or basemap.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InMap { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>The output map package (.mpkx).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("mpkx")]
		public object OutputFile { get; set; }

		/// <summary>
		/// <para>Convert data to file geodatabase</para>
		/// <para>Specifies whether input layers will be converted to a file geodatabase or preserved in their original format.</para>
		/// <para>Checked—All data will be converted to a file geodatabase. This option does not apply to enterprise geodatabase data sources. To include enterprise geodatabase data, check the Include Enterprise geodatabase data instead of referencing the data parameter.</para>
		/// <para>Unchecked—Data formats will be preserved when possible. This is the default.</para>
		/// <para><see cref="ConvertDataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ConvertData { get; set; } = "false";

		/// <summary>
		/// <para>Include Enterprise Geodatabase data instead of referencing the data</para>
		/// <para>Specifies whether input enterprise geodatabase layers will be converted to a file geodatabase or preserved in their original format.</para>
		/// <para>Checked—All enterprise geodatabase data sources will be converted to a file geodatabase. This is the default.</para>
		/// <para>Unchecked—All enterprise geodatabase data sources will be preserved and will be referenced in the resulting package.</para>
		/// <para><see cref="ConvertArcsdeDataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ConvertArcsdeData { get; set; } = "true";

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
		/// <para>Apply Extent only to enterprise geodatabase layers</para>
		/// <para>Specifies whether the specified extent will be applied to all layers or only to enterprise geodatabase layers.</para>
		/// <para>Unchecked—The extent will be applied to all layers. This is the default.</para>
		/// <para>Checked—The extent will be applied to enterprise geodatabase layers only.</para>
		/// <para><see cref="ApplyExtentToArcsdeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ApplyExtentToArcsde { get; set; } = "false";

		/// <summary>
		/// <para>Support ArcGIS Runtime</para>
		/// <para>Specifies whether the package will support ArcGIS Runtime. To support ArcGIS Runtime, all data sources will be converted to a file geodatabase, and an .msd file will be created in the output package.</para>
		/// <para>Unchecked—The output package will not support ArcGIS Runtime.</para>
		/// <para>Checked—The output package will support ArcGIS Runtime.</para>
		/// <para>Runtime-enabled packages can only be created with ArcGIS 10.x.</para>
		/// <para><see cref="ArcgisruntimeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Arcgisruntime { get; set; } = "false";

		/// <summary>
		/// <para>Reference all data for Runtime</para>
		/// <para>Checking this option will create a package that references the data needed rather than copying the data. This is valuable when trying to package large datasets that are available from a central location within an organization.</para>
		/// <para>Checked—Creates a package that references the data needed rather than copying the data.</para>
		/// <para>Unchecked— Creates a package that contains all needed data. This is the default.</para>
		/// <para><see cref="ReferenceAllDataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ReferenceAllData { get; set; } = "false";

		/// <summary>
		/// <para>Package version</para>
		/// <para>Specifies the version of the geodatabases that will be created in the resulting package. Specifying a version allows packages to be shared with previous versions of ArcGIS and supports backward compatibility.A package saved to a previous version may lose properties available only in the newer version.</para>
		/// <para>All versions—The package will contain geodatabases and a map compatible with all versions (ArcGIS Pro 1.2 and later).</para>
		/// <para>Current version— The package will contain geodatabases and a map compatible with the version of the current release.</para>
		/// <para>2.x—The package will contain geodatabases and a map compatible with version 2.0 and later.</para>
		/// <para>1.2—The package will contain geodatabases and a map compatible with version 1.2 and later.</para>
		/// <para><see cref="VersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object Version { get; set; } = "ALL";

		/// <summary>
		/// <para>Additional Files</para>
		/// <para>Adds additional files to a package. Additional files, such as .doc, .txt, .pdf, and so on, are used to provide more information about the contents and purpose of the package.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object AdditionalFiles { get; set; }

		/// <summary>
		/// <para>Summary</para>
		/// <para>Adds summary information to the properties of the package.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Summary { get; set; }

		/// <summary>
		/// <para>Tags</para>
		/// <para>Adds tag information to the properties of the package. Multiple tags can be added or separated by a comma or semicolon.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Tags { get; set; }

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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PackageMap SetEnviroment(object extent = null, object workspace = null)
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Convert data to file geodatabase</para>
		/// </summary>
		public enum ConvertDataEnum 
		{
			/// <summary>
			/// <para>Checked—All data will be converted to a file geodatabase. This option does not apply to enterprise geodatabase data sources. To include enterprise geodatabase data, check the Include Enterprise geodatabase data instead of referencing the data parameter.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CONVERT")]
			CONVERT,

			/// <summary>
			/// <para>Unchecked—Data formats will be preserved when possible. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("PRESERVE")]
			PRESERVE,

		}

		/// <summary>
		/// <para>Include Enterprise Geodatabase data instead of referencing the data</para>
		/// </summary>
		public enum ConvertArcsdeDataEnum 
		{
			/// <summary>
			/// <para>Checked—All enterprise geodatabase data sources will be converted to a file geodatabase. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CONVERT_ARCSDE")]
			CONVERT_ARCSDE,

			/// <summary>
			/// <para>Unchecked—All enterprise geodatabase data sources will be preserved and will be referenced in the resulting package.</para>
			/// </summary>
			[GPValue("false")]
			[Description("PRESERVE_ARCSDE")]
			PRESERVE_ARCSDE,

		}

		/// <summary>
		/// <para>Apply Extent only to enterprise geodatabase layers</para>
		/// </summary>
		public enum ApplyExtentToArcsdeEnum 
		{
			/// <summary>
			/// <para>Checked—The extent will be applied to enterprise geodatabase layers only.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ARCSDE_ONLY")]
			ARCSDE_ONLY,

			/// <summary>
			/// <para>Unchecked—The extent will be applied to all layers. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ALL")]
			ALL,

		}

		/// <summary>
		/// <para>Support ArcGIS Runtime</para>
		/// </summary>
		public enum ArcgisruntimeEnum 
		{
			/// <summary>
			/// <para>Checked—The output package will support ArcGIS Runtime.</para>
			/// </summary>
			[GPValue("true")]
			[Description("RUNTIME")]
			RUNTIME,

			/// <summary>
			/// <para>Unchecked—The output package will not support ArcGIS Runtime.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DESKTOP")]
			DESKTOP,

		}

		/// <summary>
		/// <para>Reference all data for Runtime</para>
		/// </summary>
		public enum ReferenceAllDataEnum 
		{
			/// <summary>
			/// <para>Checked—Creates a package that references the data needed rather than copying the data.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REFERENCED")]
			REFERENCED,

			/// <summary>
			/// <para>Unchecked— Creates a package that contains all needed data. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_REFERENCED")]
			NOT_REFERENCED,

		}

		/// <summary>
		/// <para>Package version</para>
		/// </summary>
		public enum VersionEnum 
		{
			/// <summary>
			/// <para>All versions—The package will contain geodatabases and a map compatible with all versions (ArcGIS Pro 1.2 and later).</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All versions")]
			All_versions,

			/// <summary>
			/// <para>Current version— The package will contain geodatabases and a map compatible with the version of the current release.</para>
			/// </summary>
			[GPValue("CURRENT")]
			[Description("Current version")]
			Current_version,

			/// <summary>
			/// <para>1.2—The package will contain geodatabases and a map compatible with version 1.2 and later.</para>
			/// </summary>
			[GPValue("1.2")]
			[Description("1.2")]
			_12,

			/// <summary>
			/// <para>2.x—The package will contain geodatabases and a map compatible with version 2.0 and later.</para>
			/// </summary>
			[GPValue("2.x")]
			[Description("2.x")]
			_2x,

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

#endregion
	}
}
