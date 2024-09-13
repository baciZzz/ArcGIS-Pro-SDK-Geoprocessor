using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.MaritimeTools
{
	/// <summary>
	/// <para>Import S-100 Feature Catalogue</para>
	/// <para>Import S-100 Feature Catalogue</para>
	/// <para>Imports the contents of an S-100 feature catalogue into an existing geodatabase. A feature catalogue is an XML document that describes the content of a data product.</para>
	/// </summary>
	public class ImportS100FeatureCatalogue : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureCatalogue">
		/// <para>S-100 Feature Catalogue</para>
		/// <para>An S-100 feature catalogue document that describes the content of a data product and specification.</para>
		/// </param>
		/// <param name="TargetWorkspace">
		/// <para>Target Workspace</para>
		/// <para>The geodatabase to which output data will be written.</para>
		/// </param>
		public ImportS100FeatureCatalogue(object InFeatureCatalogue, object TargetWorkspace)
		{
			this.InFeatureCatalogue = InFeatureCatalogue;
			this.TargetWorkspace = TargetWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : Import S-100 Feature Catalogue</para>
		/// </summary>
		public override string DisplayName() => "Import S-100 Feature Catalogue";

		/// <summary>
		/// <para>Tool Name : ImportS100FeatureCatalogue</para>
		/// </summary>
		public override string ToolName() => "ImportS100FeatureCatalogue";

		/// <summary>
		/// <para>Tool Excute Name : maritime.ImportS100FeatureCatalogue</para>
		/// </summary>
		public override string ExcuteName() => "maritime.ImportS100FeatureCatalogue";

		/// <summary>
		/// <para>Toolbox Display Name : Maritime Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Maritime Tools";

		/// <summary>
		/// <para>Toolbox Alise : maritime</para>
		/// </summary>
		public override string ToolboxAlise() => "maritime";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "S100FeatureCatalogueFile", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureCatalogue, TargetWorkspace, AdminConnection!, OutputWorkspace! };

		/// <summary>
		/// <para>S-100 Feature Catalogue</para>
		/// <para>An S-100 feature catalogue document that describes the content of a data product and specification.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml")]
		public object InFeatureCatalogue { get; set; }

		/// <summary>
		/// <para>Target Workspace</para>
		/// <para>The geodatabase to which output data will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object TargetWorkspace { get; set; }

		/// <summary>
		/// <para>Administrator Connection</para>
		/// <para>Optional enterprise geodatabase administrator connection file that should be used when importing into an enterprise geodatabase, for example, the SDE user.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("sde")]
		public object? AdminConnection { get; set; }

		/// <summary>
		/// <para>Output Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutputWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportS100FeatureCatalogue SetEnviroment(object? S100FeatureCatalogueFile = null , object? workspace = null )
		{
			base.SetEnv(S100FeatureCatalogueFile: S100FeatureCatalogueFile, workspace: workspace);
			return this;
		}

	}
}
