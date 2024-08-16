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
	/// <para>Consolidate Project</para>
	/// <para>Consolidates a project (.aprx file) and referenced maps and data to a specified output folder.</para>
	/// </summary>
	public class ConsolidateProject : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InProject">
		/// <para>Input Project</para>
		/// <para>The project (.aprx file) to be consolidated.</para>
		/// </param>
		/// <param name="OutputFolder">
		/// <para>Output Folder</para>
		/// <para>The output folder that will contain the consolidated project and data. If the specified folder does not exist, a new folder will be created.</para>
		/// </param>
		public ConsolidateProject(object InProject, object OutputFolder)
		{
			this.InProject = InProject;
			this.OutputFolder = OutputFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : Consolidate Project</para>
		/// </summary>
		public override string DisplayName => "Consolidate Project";

		/// <summary>
		/// <para>Tool Name : ConsolidateProject</para>
		/// </summary>
		public override string ToolName => "ConsolidateProject";

		/// <summary>
		/// <para>Tool Excute Name : management.ConsolidateProject</para>
		/// </summary>
		public override string ExcuteName => "management.ConsolidateProject";

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
		public override object[] Parameters => new object[] { InProject, OutputFolder, SharingInternal, Extent, ApplyExtentToEnterpriseGeo, PackageAsTemplate, PreserveSqlite, Version, SelectRelatedRows };

		/// <summary>
		/// <para>Input Project</para>
		/// <para>The project (.aprx file) to be consolidated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("aprx")]
		public object InProject { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>The output folder that will contain the consolidated project and data. If the specified folder does not exist, a new folder will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutputFolder { get; set; }

		/// <summary>
		/// <para>Share outside of organization</para>
		/// <para>Specifies whether the project and all data will be consolidated into a single folder (for sharing outside your organization) or referenced (for sharing inside your organization). Data paths referenced from enterprise geodatabases or a UNC file system can be shared internally. If your project was not built with data paths like this, the data will be consolidated into the project package.Data and maps will be consolidated and packaged if the project references them from a local path, such as c:\gisdata\landrecords.gdb\ regardless of this parameter&apos;s setting.</para>
		/// <para>Unchecked—The project and its data sources will not be consolidated to the output folder. This is the default. This parameter applies to enterprise geodatabase data sources, including enterprise geodatabases and folders referenced via a UNC path.</para>
		/// <para>Checked—The project and its data sources will be copied and preserved when possible.</para>
		/// <para><see cref="SharingInternalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SharingInternal { get; set; } = "false";

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
		/// <para>Specifies whether the Extent parameter will be applied to all layers or to enterprise geodatabase layers only.</para>
		/// <para>Unchecked—The extent will be applied to all layers. This is the default.</para>
		/// <para>Checked—The extent will be applied to enterprise geodatabase layers only.</para>
		/// <para><see cref="ApplyExtentToEnterpriseGeoEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ApplyExtentToEnterpriseGeo { get; set; } = "false";

		/// <summary>
		/// <para>Consolidate as template</para>
		/// <para>Specifies whether the project will be consolidated as a template or a regular project. Templates can include maps, layouts, connections to databases and servers, and so on. A project template allows you to standardize a series of maps for use in a project and ensure that the correct layers are immediately available for everyone to use in their maps.</para>
		/// <para>Unchecked—The project will be consolidated as a project into a folder. This is the default.</para>
		/// <para>Checked—The project will be consolidated as a template into a folder.</para>
		/// <para><see cref="PackageAsTemplateEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object PackageAsTemplate { get; set; } = "false";

		/// <summary>
		/// <para>Preserve SQLite Geodatabase</para>
		/// <para>Specifies whether SQLite geodatabases will be preserved or converted to file geodatabases.This parameter applies only to .geodatabase files, used primarily for offline workflows in ArcGIS Runtime apps. SQLite databases with .sqlite or .gpkg file extensions will be converted to file geodatabases.</para>
		/// <para>Unchecked—SQLite geodatabases will be converted to file geodatabases. This is the default.</para>
		/// <para>Checked—SQLite geodatabases will be preserved.</para>
		/// <para><see cref="PreserveSqliteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object PreserveSqlite { get; set; } = "false";

		/// <summary>
		/// <para>Version</para>
		/// <para>Specifies the ArcGIS Pro version the consolidated project will be saved as. Saving to an earlier version will ensure tool backward compatibility. If you attempt to consolidate a toolbox to an earlier version and capabilities that are only available in the newer version are included, an error will occur. You must remove tools that are incompatible with the earlier version, or specify a compatible version.</para>
		/// <para>Current version— The consolidated folder will contain geodatabases and maps compatible with the version of the current release.</para>
		/// <para>2.1—The consolidated folder will contain geodatabases and maps compatible with version 2.1.</para>
		/// <para>2.2— The consolidated folder will contain geodatabases and maps compatible with version 2.2.</para>
		/// <para>2.3—The consolidated folder will contain geodatabases and maps compatible with version 2.3.</para>
		/// <para>2.4—The consolidated folder will contain geodatabases and maps compatible with version 2.4.</para>
		/// <para>2.5—The consolidated folder will contain geodatabases and maps compatible with version 2.5.</para>
		/// <para>2.6—The consolidated folder will contain geodatabases and maps compatible with version 2.6.</para>
		/// <para><see cref="VersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Version { get; set; } = "CURRENT";

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
		public ConsolidateProject SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Share outside of organization</para>
		/// </summary>
		public enum SharingInternalEnum 
		{
			/// <summary>
			/// <para>Checked—The project and its data sources will be copied and preserved when possible.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EXTERNAL")]
			EXTERNAL,

			/// <summary>
			/// <para>Unchecked—The project and its data sources will not be consolidated to the output folder. This is the default. This parameter applies to enterprise geodatabase data sources, including enterprise geodatabases and folders referenced via a UNC path.</para>
			/// </summary>
			[GPValue("false")]
			[Description("INTERNAL")]
			INTERNAL,

		}

		/// <summary>
		/// <para>Apply Extent only to enterprise geodatabase layers</para>
		/// </summary>
		public enum ApplyExtentToEnterpriseGeoEnum 
		{
			/// <summary>
			/// <para>Checked—The extent will be applied to enterprise geodatabase layers only.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ENTERPRISE_ONLY")]
			ENTERPRISE_ONLY,

			/// <summary>
			/// <para>Unchecked—The extent will be applied to all layers. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ALL")]
			ALL,

		}

		/// <summary>
		/// <para>Consolidate as template</para>
		/// </summary>
		public enum PackageAsTemplateEnum 
		{
			/// <summary>
			/// <para>Checked—The project will be consolidated as a template into a folder.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PROJECT_TEMPLATE")]
			PROJECT_TEMPLATE,

			/// <summary>
			/// <para>Unchecked—The project will be consolidated as a project into a folder. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("PROJECT_PACKAGE")]
			PROJECT_PACKAGE,

		}

		/// <summary>
		/// <para>Preserve SQLite Geodatabase</para>
		/// </summary>
		public enum PreserveSqliteEnum 
		{
			/// <summary>
			/// <para>Checked—SQLite geodatabases will be preserved.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESERVE_SQLITE")]
			PRESERVE_SQLITE,

			/// <summary>
			/// <para>Unchecked—SQLite geodatabases will be converted to file geodatabases. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("CONVERT_SQLITE")]
			CONVERT_SQLITE,

		}

		/// <summary>
		/// <para>Version</para>
		/// </summary>
		public enum VersionEnum 
		{
			/// <summary>
			/// <para>Current version— The consolidated folder will contain geodatabases and maps compatible with the version of the current release.</para>
			/// </summary>
			[GPValue("CURRENT")]
			[Description("Current version")]
			Current_version,

			/// <summary>
			/// <para>2.1—The consolidated folder will contain geodatabases and maps compatible with version 2.1.</para>
			/// </summary>
			[GPValue("2.1")]
			[Description("2.1")]
			_21,

			/// <summary>
			/// <para>2.2— The consolidated folder will contain geodatabases and maps compatible with version 2.2.</para>
			/// </summary>
			[GPValue("2.2")]
			[Description("2.2")]
			_22,

			/// <summary>
			/// <para>2.3—The consolidated folder will contain geodatabases and maps compatible with version 2.3.</para>
			/// </summary>
			[GPValue("2.3")]
			[Description("2.3")]
			_23,

			/// <summary>
			/// <para>2.4—The consolidated folder will contain geodatabases and maps compatible with version 2.4.</para>
			/// </summary>
			[GPValue("2.4")]
			[Description("2.4")]
			_24,

			/// <summary>
			/// <para>2.5—The consolidated folder will contain geodatabases and maps compatible with version 2.5.</para>
			/// </summary>
			[GPValue("2.5")]
			[Description("2.5")]
			_25,

			/// <summary>
			/// <para>2.6—The consolidated folder will contain geodatabases and maps compatible with version 2.6.</para>
			/// </summary>
			[GPValue("2.6")]
			[Description("2.6")]
			_26,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("2.7")]
			[Description("2.7")]
			_27,

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
