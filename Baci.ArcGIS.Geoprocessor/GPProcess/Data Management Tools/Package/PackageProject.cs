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
	/// <para>Package Project</para>
	/// <para>Consolidates and packages a project (.aprx file) of referenced maps and data to a  packaged project file (.ppkx).</para>
	/// </summary>
	public class PackageProject : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InProject">
		/// <para>Input Project</para>
		/// <para>The project (.aprx file) to be packaged.</para>
		/// </param>
		/// <param name="OutputFile">
		/// <para>Output File</para>
		/// <para>The output project package (.ppkx file).</para>
		/// </param>
		public PackageProject(object InProject, object OutputFile)
		{
			this.InProject = InProject;
			this.OutputFile = OutputFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Package Project</para>
		/// </summary>
		public override string DisplayName => "Package Project";

		/// <summary>
		/// <para>Tool Name : PackageProject</para>
		/// </summary>
		public override string ToolName => "PackageProject";

		/// <summary>
		/// <para>Tool Excute Name : management.PackageProject</para>
		/// </summary>
		public override string ExcuteName => "management.PackageProject";

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
		public override object[] Parameters => new object[] { InProject, OutputFile, SharingInternal, PackageAsTemplate, Extent, ApplyExtentToArcsde, AdditionalFiles, Summary, Tags, Version, IncludeToolboxes, IncludeHistoryItems, ReadOnly, SelectRelatedRows };

		/// <summary>
		/// <para>Input Project</para>
		/// <para>The project (.aprx file) to be packaged.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object InProject { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>The output project package (.ppkx file).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutputFile { get; set; }

		/// <summary>
		/// <para>Share outside of organization</para>
		/// <para>Specifies whether the project will be consolidated for your internal environment or will move all data elements so it can be shared externally.Data and maps will be consolidated and packaged if the project references them from a local path, such as c:\gisdata\landrecords.gdb\, regardless of this parameter&apos;s setting.</para>
		/// <para>Unchecked—Enterprise data sources, such as enterprise geodatabases and data from a UNC path, will not be copied to the local folder. This is the default.</para>
		/// <para>Checked—Data formats will be copied and preserved when possible.</para>
		/// <para><see cref="SharingInternalEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SharingInternal { get; set; } = "false";

		/// <summary>
		/// <para>Package as template</para>
		/// <para>Specifies whether to create a project template or a project package. Project templates can include maps, layouts, connections to databases and servers, and so on. A project template makes it easy to standardize a series of maps for different projects and to ensure the correct layers are immediately available for everyone to use in their maps.</para>
		/// <para>Unchecked—Creates a project package. This is the default.</para>
		/// <para>Checked—Creates a project template.</para>
		/// <para><see cref="PackageAsTemplateEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object PackageAsTemplate { get; set; } = "false";

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
		/// <para>Unchecked—Extent will be applied to all layers. This is the default.</para>
		/// <para>Checked—Extent will be applied to enterprise geodatabase layers only.</para>
		/// <para><see cref="ApplyExtentToArcsdeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ApplyExtentToArcsde { get; set; } = "false";

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
		/// <para>Package version</para>
		/// <para>Specifies the version of the geodatabases that will be created in the resulting package. Specifying a version allows packages to be shared with previous versions of ArcGIS and supports backward compatibility.A package saved to a previous version may lose properties available only in the newer version.</para>
		/// <para>All versions— The package will contain geodatabases and maps compatible with all versions (ArcGIS Pro 2.1 and later).</para>
		/// <para>Current version— The package will contain geodatabases and maps compatible with the version of the current release.</para>
		/// <para>2.1—The package will contain geodatabases and maps compatible with version 2.1.</para>
		/// <para>2.2— The package will contain geodatabases and maps compatible with version 2.2.</para>
		/// <para>2.3—The package will contain geodatabases and maps compatible with version 2.3.</para>
		/// <para>2.4—The package will contain geodatabases and maps compatible with version 2.4.</para>
		/// <para>2.5—The package will contain geodatabases and maps compatible with version 2.5.</para>
		/// <para>2.6—The package will contain geodatabases and maps compatible with version 2.6.</para>
		/// <para><see cref="VersionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object Version { get; set; } = "ALL";

		/// <summary>
		/// <para>Include Toolboxes</para>
		/// <para>Specifies whether project toolboxes, and the data referenced by the tools in the project toolboxes, will be consolidated and included in the output package. All projects require a default toolbox, and the default toolbox will be included regardless of this setting. A toolbox inside a connected folder is not considered a project toolbox and is not impacted by this setting.</para>
		/// <para>Checked—Project toolboxes will be included in the output package. This is the default.</para>
		/// <para>Unchecked—Project toolboxes will be excluded from the output package.</para>
		/// <para><see cref="IncludeToolboxesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeToolboxes { get; set; } = "true";

		/// <summary>
		/// <para>Include History Items</para>
		/// <para>Specifies whether geoprocessing history items will be consolidated and included in the output package. Included history items will consolidate the data required to re-execute said history item.</para>
		/// <para>History items will be included—History items will be included in the output package. This is the default.</para>
		/// <para>History items will be excluded—History items will be excluded from the output package.</para>
		/// <para>Only valid history items will be included—Only valid history items will be included in the output package. History items are invalid if any of the original input layers or tools cannot be found.</para>
		/// <para><see cref="IncludeHistoryItemsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object IncludeHistoryItems { get; set; } = "HISTORY_ITEMS";

		/// <summary>
		/// <para>Read Only Package</para>
		/// <para>Specifies whether the project will be read only. Read only projects cannot be modified or saved.</para>
		/// <para>Checked—Project will be read only.</para>
		/// <para>Unchecked—Project is writable. This is the default.</para>
		/// <para><see cref="ReadOnlyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ReadOnly { get; set; } = "false";

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
		public PackageProject SetEnviroment(object workspace = null )
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
			/// <para>Checked—Data formats will be copied and preserved when possible.</para>
			/// </summary>
			[GPValue("true")]
			[Description("EXTERNAL")]
			EXTERNAL,

			/// <summary>
			/// <para>Unchecked—Enterprise data sources, such as enterprise geodatabases and data from a UNC path, will not be copied to the local folder. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("INTERNAL")]
			INTERNAL,

		}

		/// <summary>
		/// <para>Package as template</para>
		/// </summary>
		public enum PackageAsTemplateEnum 
		{
			/// <summary>
			/// <para>Checked—Creates a project template.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PROJECT_TEMPLATE")]
			PROJECT_TEMPLATE,

			/// <summary>
			/// <para>Unchecked—Creates a project package. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("PROJECT_PACKAGE")]
			PROJECT_PACKAGE,

		}

		/// <summary>
		/// <para>Apply Extent only to enterprise geodatabase layers</para>
		/// </summary>
		public enum ApplyExtentToArcsdeEnum 
		{
			/// <summary>
			/// <para>Checked—Extent will be applied to enterprise geodatabase layers only.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ENTERPRISE_ONLY")]
			ENTERPRISE_ONLY,

			/// <summary>
			/// <para>Unchecked—Extent will be applied to all layers. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ALL")]
			ALL,

		}

		/// <summary>
		/// <para>Package version</para>
		/// </summary>
		public enum VersionEnum 
		{
			/// <summary>
			/// <para>All versions— The package will contain geodatabases and maps compatible with all versions (ArcGIS Pro 2.1 and later).</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All versions")]
			All_versions,

			/// <summary>
			/// <para>Current version— The package will contain geodatabases and maps compatible with the version of the current release.</para>
			/// </summary>
			[GPValue("CURRENT")]
			[Description("Current version")]
			Current_version,

			/// <summary>
			/// <para>2.1—The package will contain geodatabases and maps compatible with version 2.1.</para>
			/// </summary>
			[GPValue("2.1")]
			[Description("2.1")]
			_21,

			/// <summary>
			/// <para>2.2— The package will contain geodatabases and maps compatible with version 2.2.</para>
			/// </summary>
			[GPValue("2.2")]
			[Description("2.2")]
			_22,

			/// <summary>
			/// <para>2.3—The package will contain geodatabases and maps compatible with version 2.3.</para>
			/// </summary>
			[GPValue("2.3")]
			[Description("2.3")]
			_23,

			/// <summary>
			/// <para>2.4—The package will contain geodatabases and maps compatible with version 2.4.</para>
			/// </summary>
			[GPValue("2.4")]
			[Description("2.4")]
			_24,

			/// <summary>
			/// <para>2.5—The package will contain geodatabases and maps compatible with version 2.5.</para>
			/// </summary>
			[GPValue("2.5")]
			[Description("2.5")]
			_25,

			/// <summary>
			/// <para>2.6—The package will contain geodatabases and maps compatible with version 2.6.</para>
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
		/// <para>Include Toolboxes</para>
		/// </summary>
		public enum IncludeToolboxesEnum 
		{
			/// <summary>
			/// <para>Checked—Project toolboxes will be included in the output package. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("TOOLBOXES")]
			TOOLBOXES,

			/// <summary>
			/// <para>Unchecked—Project toolboxes will be excluded from the output package.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_TOOLBOXES")]
			NO_TOOLBOXES,

		}

		/// <summary>
		/// <para>Include History Items</para>
		/// </summary>
		public enum IncludeHistoryItemsEnum 
		{
			/// <summary>
			/// <para>History items will be included—History items will be included in the output package. This is the default.</para>
			/// </summary>
			[GPValue("HISTORY_ITEMS")]
			[Description("History items will be included")]
			History_items_will_be_included,

			/// <summary>
			/// <para>History items will be excluded—History items will be excluded from the output package.</para>
			/// </summary>
			[GPValue("NO_HISTORY_ITEMS")]
			[Description("History items will be excluded")]
			History_items_will_be_excluded,

			/// <summary>
			/// <para>Only valid history items will be included—Only valid history items will be included in the output package. History items are invalid if any of the original input layers or tools cannot be found.</para>
			/// </summary>
			[GPValue("VALID_HISTORY_ITEMS_ONLY")]
			[Description("Only valid history items will be included")]
			Only_valid_history_items_will_be_included,

		}

		/// <summary>
		/// <para>Read Only Package</para>
		/// </summary>
		public enum ReadOnlyEnum 
		{
			/// <summary>
			/// <para>Checked—Project will be read only.</para>
			/// </summary>
			[GPValue("true")]
			[Description("READ_ONLY")]
			READ_ONLY,

			/// <summary>
			/// <para>Unchecked—Project is writable. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("READ_WRITE")]
			READ_WRITE,

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
