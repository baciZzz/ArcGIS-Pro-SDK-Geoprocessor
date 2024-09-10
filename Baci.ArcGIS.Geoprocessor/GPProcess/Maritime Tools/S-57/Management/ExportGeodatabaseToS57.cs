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
	/// <para>Export Geodatabase To S-57</para>
	/// <para>Exports hydrographic data from a maritime charting geodatabase to an S-57 file.</para>
	/// </summary>
	public class ExportGeodatabaseToS57 : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSourceGdb">
		/// <para>Source Geodatabase</para>
		/// <para>The database from which the product will be exported.</para>
		/// </param>
		/// <param name="Product">
		/// <para>S-57 Product</para>
		/// <para>The name of the product to export. This product metadata entry must exist in the ProductDefinition table, and the related extents must be present in the ProductCoverage feature class in the workspace.</para>
		/// </param>
		/// <param name="ExportType">
		/// <para>Export Type</para>
		/// <para>Specifies the type of file to be created during the export.</para>
		/// <para>New Dataset— A new dataset including information that has not been previously distributed by updates will be created.</para>
		/// <para>New Edition— A new edition of a dataset including information that has not been previously distributed by updates will be created.</para>
		/// <para>Update— Changes in a dataset since the last export will be reflected in the file.</para>
		/// <para>Reissue— A reissue of a dataset including all the updates applied to the original dataset up to the date of reissue will be created. A reissue does not contain information that has not been previously issued by updates.</para>
		/// <para>Cancel— When a dataset is deleted, an updated cell file is created containing only the Dataset General Information record with the Dataset Identifier (DSID) field. In this case, the Edition Number (EDTN) subfield must be set to 0.</para>
		/// <para><see cref="ExportTypeEnum"/></para>
		/// </param>
		/// <param name="OutLocation">
		/// <para>Output Location</para>
		/// <para>The location containing the output export package.</para>
		/// </param>
		public ExportGeodatabaseToS57(object InSourceGdb, object Product, object ExportType, object OutLocation)
		{
			this.InSourceGdb = InSourceGdb;
			this.Product = Product;
			this.ExportType = ExportType;
			this.OutLocation = OutLocation;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Geodatabase To S-57</para>
		/// </summary>
		public override string DisplayName() => "Export Geodatabase To S-57";

		/// <summary>
		/// <para>Tool Name : ExportGeodatabaseToS57</para>
		/// </summary>
		public override string ToolName() => "ExportGeodatabaseToS57";

		/// <summary>
		/// <para>Tool Excute Name : maritime.ExportGeodatabaseToS57</para>
		/// </summary>
		public override string ExcuteName() => "maritime.ExportGeodatabaseToS57";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSourceGdb, Product, ExportType, OutLocation, InProductConfig, ClipDataOption, SampleExport, OutFile, InScaminFile };

		/// <summary>
		/// <para>Source Geodatabase</para>
		/// <para>The database from which the product will be exported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("Local Database", "Remote Database")]
		public object InSourceGdb { get; set; }

		/// <summary>
		/// <para>S-57 Product</para>
		/// <para>The name of the product to export. This product metadata entry must exist in the ProductDefinition table, and the related extents must be present in the ProductCoverage feature class in the workspace.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Product { get; set; }

		/// <summary>
		/// <para>Export Type</para>
		/// <para>Specifies the type of file to be created during the export.</para>
		/// <para>New Dataset— A new dataset including information that has not been previously distributed by updates will be created.</para>
		/// <para>New Edition— A new edition of a dataset including information that has not been previously distributed by updates will be created.</para>
		/// <para>Update— Changes in a dataset since the last export will be reflected in the file.</para>
		/// <para>Reissue— A reissue of a dataset including all the updates applied to the original dataset up to the date of reissue will be created. A reissue does not contain information that has not been previously issued by updates.</para>
		/// <para>Cancel— When a dataset is deleted, an updated cell file is created containing only the Dataset General Information record with the Dataset Identifier (DSID) field. In this case, the Edition Number (EDTN) subfield must be set to 0.</para>
		/// <para><see cref="ExportTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ExportType { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>The location containing the output export package.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutLocation { get; set; }

		/// <summary>
		/// <para>Product Configuration File</para>
		/// <para>The configuration file to use to export the product.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml")]
		public object InProductConfig { get; set; }

		/// <summary>
		/// <para>Clip Features at M_CSCL</para>
		/// <para>Specifies whether the export process will clip data that crosses an M_CSCL feature.</para>
		/// <para>Checked—Features in the source database that cross the boundary of an M_CSCL feature will be clipped to the boundary in the exported file.</para>
		/// <para>Unchecked—Features in the source database that cross the boundary of an M_CSCL feature will not be clipped to the boundary in the exported file. This will result in the features remaining intact in the output. This is the default.</para>
		/// <para><see cref="ClipDataOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ClipDataOption { get; set; } = "false";

		/// <summary>
		/// <para>Sample Export</para>
		/// <para>Specifies whether the product will be exported as a sample.</para>
		/// <para>Checked—The exported cell is not stored in the ProductExports table and the metadata information will not be updated in the ProductDefinition table.</para>
		/// <para>Unchecked—The exported cell is stored in the ProductExports table as a BLOB, and the edition, update, and other metadata in the ProductDefinition table will be updated. This is the default.</para>
		/// <para><see cref="SampleExportEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SampleExport { get; set; } = "false";

		/// <summary>
		/// <para>Output File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		public object OutFile { get; set; }

		/// <summary>
		/// <para>SCAMIN Configuration File</para>
		/// <para>A custom configuration file that contains the rules for calculating a feature's SCAMIN that overrides the default Radar Range SCAMIN method.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml")]
		public object InScaminFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportGeodatabaseToS57 SetEnviroment(object workspace = null )
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
			/// <para>New Dataset— A new dataset including information that has not been previously distributed by updates will be created.</para>
			/// </summary>
			[GPValue("NEW_DATASET")]
			[Description("New Dataset")]
			New_Dataset,

			/// <summary>
			/// <para>New Edition— A new edition of a dataset including information that has not been previously distributed by updates will be created.</para>
			/// </summary>
			[GPValue("NEW_EDITION")]
			[Description("New Edition")]
			New_Edition,

			/// <summary>
			/// <para>Update— Changes in a dataset since the last export will be reflected in the file.</para>
			/// </summary>
			[GPValue("UPDATE")]
			[Description("Update")]
			Update,

			/// <summary>
			/// <para>Reissue— A reissue of a dataset including all the updates applied to the original dataset up to the date of reissue will be created. A reissue does not contain information that has not been previously issued by updates.</para>
			/// </summary>
			[GPValue("REISSUE")]
			[Description("Reissue")]
			Reissue,

			/// <summary>
			/// <para>Cancel— When a dataset is deleted, an updated cell file is created containing only the Dataset General Information record with the Dataset Identifier (DSID) field. In this case, the Edition Number (EDTN) subfield must be set to 0.</para>
			/// </summary>
			[GPValue("CANCEL")]
			[Description("Cancel")]
			Cancel,

		}

		/// <summary>
		/// <para>Clip Features at M_CSCL</para>
		/// </summary>
		public enum ClipDataOptionEnum 
		{
			/// <summary>
			/// <para>Checked—Features in the source database that cross the boundary of an M_CSCL feature will be clipped to the boundary in the exported file.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CLIP")]
			CLIP,

			/// <summary>
			/// <para>Unchecked—Features in the source database that cross the boundary of an M_CSCL feature will not be clipped to the boundary in the exported file. This will result in the features remaining intact in the output. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DO_NOT_CLIP")]
			DO_NOT_CLIP,

		}

		/// <summary>
		/// <para>Sample Export</para>
		/// </summary>
		public enum SampleExportEnum 
		{
			/// <summary>
			/// <para>Checked—The exported cell is not stored in the ProductExports table and the metadata information will not be updated in the ProductDefinition table.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SAMPLE_EXPORT")]
			SAMPLE_EXPORT,

			/// <summary>
			/// <para>Unchecked—The exported cell is stored in the ProductExports table as a BLOB, and the edition, update, and other metadata in the ProductDefinition table will be updated. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("OFFICIAL_EXPORT")]
			OFFICIAL_EXPORT,

		}

#endregion
	}
}
