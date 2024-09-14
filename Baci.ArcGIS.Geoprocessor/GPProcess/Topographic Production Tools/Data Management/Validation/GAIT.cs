using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>GAIT</para>
	/// <para>GAIT</para>
	/// <para>Validates data using the Geospatial Analysis Integrity Tool (GAIT), checking geometry, feature codes, attribute values and domains, and metadata.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class GAIT : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The features to validate.</para>
		/// </param>
		/// <param name="GaitExe">
		/// <para>GAIT Executable</para>
		/// <para>The path to the GAIT executable file.</para>
		/// </param>
		/// <param name="Folder">
		/// <para>Output Directory</para>
		/// <para>The shapefile export directory.</para>
		/// </param>
		/// <param name="Schema">
		/// <para>Attribution Schema</para>
		/// <para>The data model that corresponds to the data displayed in the input feature layer.</para>
		/// </param>
		/// <param name="Project">
		/// <para>Project Name</para>
		/// <para>The name of the project. The project contains validation information, such as the checks run on the data and the results.</para>
		/// </param>
		/// <param name="Format">
		/// <para>Inspection Profile</para>
		/// <para>The set of checks to run on the data. This is specific to the data model listed in the attribution schema.</para>
		/// </param>
		/// <param name="Metadata">
		/// <para>Metadata Mapping Table</para>
		/// <para>The metadata mapping table that corresponds to the data model of the input feature layer and the attribution schema.</para>
		/// <para>Esri metadata—Esri metadata</para>
		/// <para>Intergraph metadata—Intergraph metadata</para>
		/// <para>MGCP NGA metadata—MGCP NGA metadata</para>
		/// <para><see cref="MetadataEnum"/></para>
		/// </param>
		/// <param name="Silent">
		/// <para>Run Silent</para>
		/// <para>Indicates the amount of output messages to return from GAIT.exe.</para>
		/// <para>Checked—Limit messaging from GAIT.exe. This is the default.</para>
		/// <para>Unchecked—Run GAIT.exe in verbose mode.</para>
		/// <para><see cref="SilentEnum"/></para>
		/// </param>
		public GAIT(object InFeatures, object GaitExe, object Folder, object Schema, object Project, object Format, object Metadata, object Silent)
		{
			this.InFeatures = InFeatures;
			this.GaitExe = GaitExe;
			this.Folder = Folder;
			this.Schema = Schema;
			this.Project = Project;
			this.Format = Format;
			this.Metadata = Metadata;
			this.Silent = Silent;
		}

		/// <summary>
		/// <para>Tool Display Name : GAIT</para>
		/// </summary>
		public override string DisplayName() => "GAIT";

		/// <summary>
		/// <para>Tool Name : GAIT</para>
		/// </summary>
		public override string ToolName() => "GAIT";

		/// <summary>
		/// <para>Tool Excute Name : topographic.GAIT</para>
		/// </summary>
		public override string ExcuteName() => "topographic.GAIT";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise() => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, GaitExe, Folder, Schema, Project, Format, Metadata, Silent, ReviewerWorkspace!, Specfile!, OutFeaturelayers! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The features to validate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>GAIT Executable</para>
		/// <para>The path to the GAIT executable file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		public object GaitExe { get; set; }

		/// <summary>
		/// <para>Output Directory</para>
		/// <para>The shapefile export directory.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object Folder { get; set; }

		/// <summary>
		/// <para>Attribution Schema</para>
		/// <para>The data model that corresponds to the data displayed in the input feature layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Schema { get; set; }

		/// <summary>
		/// <para>Project Name</para>
		/// <para>The name of the project. The project contains validation information, such as the checks run on the data and the results.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Project { get; set; }

		/// <summary>
		/// <para>Inspection Profile</para>
		/// <para>The set of checks to run on the data. This is specific to the data model listed in the attribution schema.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Format { get; set; }

		/// <summary>
		/// <para>Metadata Mapping Table</para>
		/// <para>The metadata mapping table that corresponds to the data model of the input feature layer and the attribution schema.</para>
		/// <para>Esri metadata—Esri metadata</para>
		/// <para>Intergraph metadata—Intergraph metadata</para>
		/// <para>MGCP NGA metadata—MGCP NGA metadata</para>
		/// <para><see cref="MetadataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Metadata { get; set; } = "META_MGCPNGA";

		/// <summary>
		/// <para>Run Silent</para>
		/// <para>Indicates the amount of output messages to return from GAIT.exe.</para>
		/// <para>Checked—Limit messaging from GAIT.exe. This is the default.</para>
		/// <para>Unchecked—Run GAIT.exe in verbose mode.</para>
		/// <para><see cref="SilentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Silent { get; set; } = "true";

		/// <summary>
		/// <para>Reviewer Workspace</para>
		/// <para>The workspace to write the output features. Each shapefile result record is written to the reviewer table in this workspace.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEWorkspace()]
		public object? ReviewerWorkspace { get; set; }

		/// <summary>
		/// <para>Custom Inspection File</para>
		/// <para>A file that defines custom checks.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object? Specfile { get; set; }

		/// <summary>
		/// <para>Output Feature Layers</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? OutFeaturelayers { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Metadata Mapping Table</para>
		/// </summary>
		public enum MetadataEnum 
		{
			/// <summary>
			/// <para>Esri metadata—Esri metadata</para>
			/// </summary>
			[GPValue("META_ESRI")]
			[Description("Esri metadata")]
			Esri_metadata,

			/// <summary>
			/// <para>Intergraph metadata—Intergraph metadata</para>
			/// </summary>
			[GPValue("META_INGR")]
			[Description("Intergraph metadata")]
			Intergraph_metadata,

			/// <summary>
			/// <para>MGCP NGA metadata—MGCP NGA metadata</para>
			/// </summary>
			[GPValue("META_MGCPNGA")]
			[Description("MGCP NGA metadata")]
			MGCP_NGA_metadata,

		}

		/// <summary>
		/// <para>Run Silent</para>
		/// </summary>
		public enum SilentEnum 
		{
			/// <summary>
			/// <para>Checked—Limit messaging from GAIT.exe. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SILENT")]
			SILENT,

			/// <summary>
			/// <para>Unchecked—Run GAIT.exe in verbose mode.</para>
			/// </summary>
			[GPValue("false")]
			[Description("VERBOSE")]
			VERBOSE,

		}

#endregion
	}
}
