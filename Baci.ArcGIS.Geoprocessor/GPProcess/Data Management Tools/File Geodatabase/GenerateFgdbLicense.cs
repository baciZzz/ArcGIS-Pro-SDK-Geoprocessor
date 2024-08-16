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
	/// <para>Generate File Geodatabase License</para>
	/// <para>Generates a license file (.sdlic) for displaying the contents in a licensed file geodatabase created by the Generate Licensed File Geodatabase tool.</para>
	/// </summary>
	public class GenerateFgdbLicense : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLicDefFile">
		/// <para>Input License Definition File</para>
		/// <para>The license definition file (.licdef) created by the Generate Licensed File Geodatabase tool.</para>
		/// </param>
		/// <param name="OutLicFile">
		/// <para>Output Data License File</para>
		/// <para>The license file (.sdlic) for distribution.</para>
		/// </param>
		public GenerateFgdbLicense(object InLicDefFile, object OutLicFile)
		{
			this.InLicDefFile = InLicDefFile;
			this.OutLicFile = OutLicFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate File Geodatabase License</para>
		/// </summary>
		public override string DisplayName => "Generate File Geodatabase License";

		/// <summary>
		/// <para>Tool Name : GenerateFgdbLicense</para>
		/// </summary>
		public override string ToolName => "GenerateFgdbLicense";

		/// <summary>
		/// <para>Tool Excute Name : management.GenerateFgdbLicense</para>
		/// </summary>
		public override string ExcuteName => "management.GenerateFgdbLicense";

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
		public override object[] Parameters => new object[] { InLicDefFile, OutLicFile, AllowExport, ExpDate };

		/// <summary>
		/// <para>Input License Definition File</para>
		/// <para>The license definition file (.licdef) created by the Generate Licensed File Geodatabase tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("licdef")]
		public object InLicDefFile { get; set; }

		/// <summary>
		/// <para>Output Data License File</para>
		/// <para>The license file (.sdlic) for distribution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("sdlic")]
		public object OutLicFile { get; set; }

		/// <summary>
		/// <para>Allow Export of Vector Data</para>
		/// <para>Specifies whether the export of vector data is allowed.</para>
		/// <para>Vector data cannot be exported—Vector data cannot be exported with the data license file (.sdlic) installed. This is the default.</para>
		/// <para>Allow export of vector data— Vector data can be exported with the data license file (.sdlic) installed.</para>
		/// <para><see cref="AllowExportEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AllowExport { get; set; } = "DENY_EXPORT";

		/// <summary>
		/// <para>Expiration Date</para>
		/// <para>The expiration date of the data license file, after which the file geodatabase’s contents can no longer be displayed. The default value is empty (blank), which means the data license file will never expire.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object ExpDate { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateFgdbLicense SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Allow Export of Vector Data</para>
		/// </summary>
		public enum AllowExportEnum 
		{
			/// <summary>
			/// <para>Vector data cannot be exported—Vector data cannot be exported with the data license file (.sdlic) installed. This is the default.</para>
			/// </summary>
			[GPValue("DENY_EXPORT")]
			[Description("Vector data cannot be exported")]
			Vector_data_cannot_be_exported,

			/// <summary>
			/// <para>Allow export of vector data— Vector data can be exported with the data license file (.sdlic) installed.</para>
			/// </summary>
			[GPValue("ALLOW_EXPORT")]
			[Description("Allow export of vector data")]
			Allow_export_of_vector_data,

		}

#endregion
	}
}
