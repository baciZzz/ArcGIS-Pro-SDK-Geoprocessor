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
	/// <para>Export XML Workspace Document</para>
	/// <para>Creates a readable XML document of the geodatabase contents.</para>
	/// </summary>
	public class ExportXMLWorkspaceDocument : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InData">
		/// <para>Input Data</para>
		/// <para>The input datasets to be exported and represented in an XML workspace document. The input data can be a geodatabase, feature dataset, feature class, table, raster, or raster catalog. If there are multiple inputs, the inputs must be from the same workspace. Multiple input workspaces are not supported.</para>
		/// </param>
		/// <param name="OutFile">
		/// <para>Output File</para>
		/// <para>The XML workspace document file to be created. This can be an XML file (.xml) or a compressed ZIP file (.zip or .z).</para>
		/// </param>
		public ExportXMLWorkspaceDocument(object InData, object OutFile)
		{
			this.InData = InData;
			this.OutFile = OutFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Export XML Workspace Document</para>
		/// </summary>
		public override string DisplayName => "Export XML Workspace Document";

		/// <summary>
		/// <para>Tool Name : ExportXMLWorkspaceDocument</para>
		/// </summary>
		public override string ToolName => "ExportXMLWorkspaceDocument";

		/// <summary>
		/// <para>Tool Excute Name : management.ExportXMLWorkspaceDocument</para>
		/// </summary>
		public override string ExcuteName => "management.ExportXMLWorkspaceDocument";

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
		public override string[] ValidEnvironments => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InData, OutFile, ExportType, StorageType, ExportMetadata };

		/// <summary>
		/// <para>Input Data</para>
		/// <para>The input datasets to be exported and represented in an XML workspace document. The input data can be a geodatabase, feature dataset, feature class, table, raster, or raster catalog. If there are multiple inputs, the inputs must be from the same workspace. Multiple input workspaces are not supported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>The XML workspace document file to be created. This can be an XML file (.xml) or a compressed ZIP file (.zip or .z).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutFile { get; set; }

		/// <summary>
		/// <para>Export Options</para>
		/// <para>Determines if the output XML workspace document will contain all of the data from the input (table and feature class records, including geometry) or only the schema.</para>
		/// <para>Data—Export both the schema and the data. This is the default.</para>
		/// <para>Schema only—Export the schema only.</para>
		/// <para><see cref="ExportTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ExportType { get; set; } = "DATA";

		/// <summary>
		/// <para>Storage Type</para>
		/// <para>Determines how feature geometry is stored when data is exported from a feature class.</para>
		/// <para>Binary—The geometry will be stored in a compressed base64 binary format. This binary format will produce a smaller XML workspace document. Use this option when the XML workspace document will be read by a custom program that uses ArcObjects. This is the default.</para>
		/// <para>Normalized—The geometry will be stored in an uncompressed format, resulting in a larger file. Use this option when the XML workspace document will be read by a custom program that does not use ArcObjects.</para>
		/// <para><see cref="StorageTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object StorageType { get; set; } = "BINARY";

		/// <summary>
		/// <para>Export Metadata</para>
		/// <para>Determines if metadata will be exported.</para>
		/// <para>Unchecked—No metadata is exported.</para>
		/// <para>Checked—If the input contains metadata, it will be exported. This is the default.</para>
		/// <para><see cref="ExportMetadataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ExportMetadata { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportXMLWorkspaceDocument SetEnviroment(object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Export Options</para>
		/// </summary>
		public enum ExportTypeEnum 
		{
			/// <summary>
			/// <para>Data—Export both the schema and the data. This is the default.</para>
			/// </summary>
			[GPValue("DATA")]
			[Description("Data")]
			Data,

			/// <summary>
			/// <para>Schema only—Export the schema only.</para>
			/// </summary>
			[GPValue("SCHEMA_ONLY")]
			[Description("Schema only")]
			Schema_only,

		}

		/// <summary>
		/// <para>Storage Type</para>
		/// </summary>
		public enum StorageTypeEnum 
		{
			/// <summary>
			/// <para>Binary—The geometry will be stored in a compressed base64 binary format. This binary format will produce a smaller XML workspace document. Use this option when the XML workspace document will be read by a custom program that uses ArcObjects. This is the default.</para>
			/// </summary>
			[GPValue("BINARY")]
			[Description("Binary")]
			Binary,

			/// <summary>
			/// <para>Normalized—The geometry will be stored in an uncompressed format, resulting in a larger file. Use this option when the XML workspace document will be read by a custom program that does not use ArcObjects.</para>
			/// </summary>
			[GPValue("NORMALIZED")]
			[Description("Normalized")]
			Normalized,

		}

		/// <summary>
		/// <para>Export Metadata</para>
		/// </summary>
		public enum ExportMetadataEnum 
		{
			/// <summary>
			/// <para>Checked—If the input contains metadata, it will be exported. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("METADATA")]
			METADATA,

			/// <summary>
			/// <para>Unchecked—No metadata is exported.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_METADATA")]
			NO_METADATA,

		}

#endregion
	}
}
