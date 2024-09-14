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
	/// <para>Consolidate Map</para>
	/// <para>Consolidate Map</para>
	/// <para>Consolidates a map and all referenced data sources to a specified output folder.</para>
	/// </summary>
	public class ConsolidateMap : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMap">
		/// <para>Input Map</para>
		/// <para>The map (.mapx) to be consolidated. When running this tool within the ArcGIS Pro application, the input can be a map, scene, or basemap.</para>
		/// </param>
		/// <param name="OutputFolder">
		/// <para>Output Folder</para>
		/// <para>The output folder that will contain the consolidated map and data.</para>
		/// <para>If the specified folder does not exist, a new folder will be created.</para>
		/// </param>
		public ConsolidateMap(object InMap, object OutputFolder)
		{
			this.InMap = InMap;
			this.OutputFolder = OutputFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : Consolidate Map</para>
		/// </summary>
		public override string DisplayName() => "Consolidate Map";

		/// <summary>
		/// <para>Tool Name : ConsolidateMap</para>
		/// </summary>
		public override string ToolName() => "ConsolidateMap";

		/// <summary>
		/// <para>Tool Excute Name : management.ConsolidateMap</para>
		/// </summary>
		public override string ExcuteName() => "management.ConsolidateMap";

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
		public override object[] Parameters() => new object[] { InMap, OutputFolder, ConvertData, ConvertArcsdeData, Extent, ApplyExtentToArcsde, PreserveSqlite, SelectRelatedRows };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>The map (.mapx) to be consolidated. When running this tool within the ArcGIS Pro application, the input can be a map, scene, or basemap.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InMap { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>The output folder that will contain the consolidated map and data.</para>
		/// <para>If the specified folder does not exist, a new folder will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutputFolder { get; set; }

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
		/// <para>Preserve SQLite</para>
		/// <para>Instead of converting to a file geodatabase format, input SQLite data can be preserved as SQLite output. This parameter overrides the Convert data to file geodatabase parameter when the input data is SQLite. If the input data is a SQLite network dataset, the output will always be SQLite.</para>
		/// <para>Unchecked—SQLite data will be converted to file geodatabase. This is the default.</para>
		/// <para>Checked—SQLite data will be preserved as SQLite in the consolidated folder.</para>
		/// <para><see cref="PreserveSqliteEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object PreserveSqlite { get; set; } = "false";

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
		public ConsolidateMap SetEnviroment(object extent = null, object workspace = null)
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
		/// <para>Preserve SQLite</para>
		/// </summary>
		public enum PreserveSqliteEnum 
		{
			/// <summary>
			/// <para>Checked—SQLite data will be preserved as SQLite in the consolidated folder.</para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESERVE_SQLITE")]
			PRESERVE_SQLITE,

			/// <summary>
			/// <para>Unchecked—SQLite data will be converted to file geodatabase. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("CONVERT_SQLITE")]
			CONVERT_SQLITE,

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
