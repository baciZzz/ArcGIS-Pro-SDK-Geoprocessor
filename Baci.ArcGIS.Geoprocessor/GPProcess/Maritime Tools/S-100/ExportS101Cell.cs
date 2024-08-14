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
	/// <para>Export S-101 Cell</para>
	/// <para>Exports S-101 hydrographic data from a geodatabase to an S-101 file.</para>
	/// </summary>
	public class ExportS101Cell : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureCatalogue">
		/// <para>S-100 Feature Catalogue</para>
		/// <para>An S-100 feature catalogue document that describes the content of a data product and specification.</para>
		/// </param>
		/// <param name="InS101Workspace">
		/// <para>S-101 Workspace</para>
		/// <para>The workspace that contains the product.</para>
		/// </param>
		/// <param name="Product">
		/// <para>S-101 Product</para>
		/// <para>The name of the product to export.</para>
		/// <para>This information must exist in the ProductCoverage feature class and ProductDefinition table before using this tool.</para>
		/// </param>
		/// <param name="ExportType">
		/// <para>Export Type</para>
		/// <para>The type of file created during export.</para>
		/// <para>New edition—A new edition of a dataset, including new information that has not been previously distributed by updates. This is the default.</para>
		/// <para><see cref="ExportTypeEnum"/></para>
		/// </param>
		/// <param name="OutputLocation">
		/// <para>Output Location</para>
		/// <para>The location where the export package will be written.</para>
		/// </param>
		public ExportS101Cell(object InFeatureCatalogue, object InS101Workspace, object Product, object ExportType, object OutputLocation)
		{
			this.InFeatureCatalogue = InFeatureCatalogue;
			this.InS101Workspace = InS101Workspace;
			this.Product = Product;
			this.ExportType = ExportType;
			this.OutputLocation = OutputLocation;
		}

		/// <summary>
		/// <para>Tool Display Name : Export S-101 Cell</para>
		/// </summary>
		public override string DisplayName => "Export S-101 Cell";

		/// <summary>
		/// <para>Tool Name : ExportS101Cell</para>
		/// </summary>
		public override string ToolName => "ExportS101Cell";

		/// <summary>
		/// <para>Tool Excute Name : maritime.ExportS101Cell</para>
		/// </summary>
		public override string ExcuteName => "maritime.ExportS101Cell";

		/// <summary>
		/// <para>Toolbox Display Name : Maritime Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Maritime Tools";

		/// <summary>
		/// <para>Toolbox Alise : maritime</para>
		/// </summary>
		public override string ToolboxAlise => "maritime";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "S100FeatureCatalogueFile", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatureCatalogue, InS101Workspace, Product, ExportType, OutputLocation, OutOutputFile };

		/// <summary>
		/// <para>S-100 Feature Catalogue</para>
		/// <para>An S-100 feature catalogue document that describes the content of a data product and specification.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object InFeatureCatalogue { get; set; }

		/// <summary>
		/// <para>S-101 Workspace</para>
		/// <para>The workspace that contains the product.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object InS101Workspace { get; set; }

		/// <summary>
		/// <para>S-101 Product</para>
		/// <para>The name of the product to export.</para>
		/// <para>This information must exist in the ProductCoverage feature class and ProductDefinition table before using this tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Product { get; set; }

		/// <summary>
		/// <para>Export Type</para>
		/// <para>The type of file created during export.</para>
		/// <para>New edition—A new edition of a dataset, including new information that has not been previously distributed by updates. This is the default.</para>
		/// <para><see cref="ExportTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ExportType { get; set; } = "NEW_EDITION";

		/// <summary>
		/// <para>Output Location</para>
		/// <para>The location where the export package will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutputLocation { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object OutOutputFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportS101Cell SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Export Type</para>
		/// </summary>
		public enum ExportTypeEnum 
		{
			/// <summary>
			/// <para>New edition—A new edition of a dataset, including new information that has not been previously distributed by updates. This is the default.</para>
			/// </summary>
			[GPValue("NEW_EDITION")]
			[Description("New edition")]
			New_edition,

		}

#endregion
	}
}
