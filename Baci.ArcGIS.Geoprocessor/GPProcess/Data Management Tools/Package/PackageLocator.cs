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
	/// <para>Package Locator</para>
	/// <para>Package Locator</para>
	/// <para>Package a locator or composite locator  to create a single compressed .gcpk file.</para>
	/// </summary>
	public class PackageLocator : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLocator">
		/// <para>Input Locator</para>
		/// <para>The locator or composite locator that will be packaged.</para>
		/// </param>
		/// <param name="OutputFile">
		/// <para>Output File</para>
		/// <para>The name and location of the output locator package (.gcpk).</para>
		/// </param>
		public PackageLocator(object InLocator, object OutputFile)
		{
			this.InLocator = InLocator;
			this.OutputFile = OutputFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Package Locator</para>
		/// </summary>
		public override string DisplayName() => "Package Locator";

		/// <summary>
		/// <para>Tool Name : PackageLocator</para>
		/// </summary>
		public override string ToolName() => "PackageLocator";

		/// <summary>
		/// <para>Tool Excute Name : management.PackageLocator</para>
		/// </summary>
		public override string ExcuteName() => "management.PackageLocator";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLocator, OutputFile, CopyArcsdeLocator, AdditionalFiles, Summary, Tags };

		/// <summary>
		/// <para>Input Locator</para>
		/// <para>The locator or composite locator that will be packaged.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEAddressLocator()]
		public object InLocator { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>The name and location of the output locator package (.gcpk).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("gcpk")]
		public object OutputFile { get; set; }

		/// <summary>
		/// <para>Composite locator only: copy participating locators in enterprise database instead of referencing them</para>
		/// <para>This parameter has no effect in ArcGIS Pro. It remains only to support backward compatibility.</para>
		/// <para><see cref="CopyArcsdeLocatorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CopyArcsdeLocator { get; set; } = "true";

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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PackageLocator SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Composite locator only: copy participating locators in enterprise database instead of referencing them</para>
		/// </summary>
		public enum CopyArcsdeLocatorEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("COPY_ARCSDE")]
			COPY_ARCSDE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("PRESERVE_ARCSDE")]
			PRESERVE_ARCSDE,

		}

#endregion
	}
}
