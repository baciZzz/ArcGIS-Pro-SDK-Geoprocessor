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
	/// <para>Import XML Workspace Document</para>
	/// <para>Import XML Workspace Document</para>
	/// <para>Imports the contents of an XML workspace document into an existing geodatabase.</para>
	/// </summary>
	public class ImportXMLWorkspaceDocument : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetGeodatabase">
		/// <para>Target Geodatabase</para>
		/// <para>The existing geodatabase where the contents of the XML workspace document will be imported.</para>
		/// </param>
		/// <param name="InFile">
		/// <para>Import File</para>
		/// <para>The input XML workspace document file containing geodatabase contents to be imported. The file can be an .xml file or a compressed .zip or .z file containing the .xml file.</para>
		/// </param>
		public ImportXMLWorkspaceDocument(object TargetGeodatabase, object InFile)
		{
			this.TargetGeodatabase = TargetGeodatabase;
			this.InFile = InFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Import XML Workspace Document</para>
		/// </summary>
		public override string DisplayName() => "Import XML Workspace Document";

		/// <summary>
		/// <para>Tool Name : ImportXMLWorkspaceDocument</para>
		/// </summary>
		public override string ToolName() => "ImportXMLWorkspaceDocument";

		/// <summary>
		/// <para>Tool Excute Name : management.ImportXMLWorkspaceDocument</para>
		/// </summary>
		public override string ExcuteName() => "management.ImportXMLWorkspaceDocument";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { TargetGeodatabase, InFile, ImportType!, ConfigKeyword!, OutGeodatabase! };

		/// <summary>
		/// <para>Target Geodatabase</para>
		/// <para>The existing geodatabase where the contents of the XML workspace document will be imported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object TargetGeodatabase { get; set; }

		/// <summary>
		/// <para>Import File</para>
		/// <para>The input XML workspace document file containing geodatabase contents to be imported. The file can be an .xml file or a compressed .zip or .z file containing the .xml file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml", "zip", "z")]
		public object InFile { get; set; }

		/// <summary>
		/// <para>Import Options</para>
		/// <para>Specifies whether both data (feature class and table records, including geometry) and schema will be imported, or only the schema will be imported.</para>
		/// <para>Import data and schema—Data and schema will be imported. This is the default.</para>
		/// <para>Import schema only—Only the schema will be imported.</para>
		/// <para><see cref="ImportTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ImportType { get; set; } = "DATA";

		/// <summary>
		/// <para>Configuration Keyword</para>
		/// <para>The geodatabase configuration keyword to be applied if the Target Geodatabase parameter value is an enterprise or file geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Updated Target Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutGeodatabase { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportXMLWorkspaceDocument SetEnviroment(object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Import Options</para>
		/// </summary>
		public enum ImportTypeEnum 
		{
			/// <summary>
			/// <para>Import data and schema—Data and schema will be imported. This is the default.</para>
			/// </summary>
			[GPValue("DATA")]
			[Description("Import data and schema")]
			Import_data_and_schema,

			/// <summary>
			/// <para>Import schema only—Only the schema will be imported.</para>
			/// </summary>
			[GPValue("SCHEMA_ONLY")]
			[Description("Import schema only")]
			Import_schema_only,

		}

#endregion
	}
}
