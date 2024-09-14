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
	/// <para>Consolidate Layer</para>
	/// <para>Consolidate Layer</para>
	/// <para>Consolidates one or more layers by copying all referenced data sources  into a single folder.</para>
	/// </summary>
	public class ConsolidateLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLayer">
		/// <para>Input Layer</para>
		/// <para>The input layers to be consolidated.</para>
		/// </param>
		/// <param name="OutputFolder">
		/// <para>Output Folder</para>
		/// <para>The output folder that will contain the layer files and consolidated data.</para>
		/// <para>If the specified folder does not exist, a new folder will be created.</para>
		/// </param>
		public ConsolidateLayer(object InLayer, object OutputFolder)
		{
			this.InLayer = InLayer;
			this.OutputFolder = OutputFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : Consolidate Layer</para>
		/// </summary>
		public override string DisplayName() => "Consolidate Layer";

		/// <summary>
		/// <para>Tool Name : ConsolidateLayer</para>
		/// </summary>
		public override string ToolName() => "ConsolidateLayer";

		/// <summary>
		/// <para>Tool Excute Name : management.ConsolidateLayer</para>
		/// </summary>
		public override string ExcuteName() => "management.ConsolidateLayer";

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
		public override object[] Parameters() => new object[] { InLayer, OutputFolder, ConvertData, ConvertArcsdeData, Extent, ApplyExtentToArcsde, SchemaOnly, SelectRelatedRows };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The input layers to be consolidated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InLayer { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>The output folder that will contain the layer files and consolidated data.</para>
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
		/// <para>Schema only</para>
		/// <para>Specifies whether only the schema of the input layers will be consolidated or packaged.</para>
		/// <para>Unchecked—All features and records for input layers will be included in the consolidated folder or package. This is the default.</para>
		/// <para>Checked—Only the schema of the layers will be consolidated or packaged. No features or records will be consolidated or packaged in the output folder.</para>
		/// <para><see cref="SchemaOnlyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SchemaOnly { get; set; } = "false";

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
		public ConsolidateLayer SetEnviroment(object extent = null, object workspace = null)
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
		/// <para>Schema only</para>
		/// </summary>
		public enum SchemaOnlyEnum 
		{
			/// <summary>
			/// <para>Checked—Only the schema of the layers will be consolidated or packaged. No features or records will be consolidated or packaged in the output folder.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SCHEMA_ONLY")]
			SCHEMA_ONLY,

			/// <summary>
			/// <para>Unchecked—All features and records for input layers will be included in the consolidated folder or package. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("ALL")]
			ALL,

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
