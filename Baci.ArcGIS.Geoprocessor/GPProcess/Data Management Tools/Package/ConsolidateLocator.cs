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
	/// <para>Consolidate Locator</para>
	/// <para>Consolidate Locator</para>
	/// <para>Consolidate a locator or composite locator  by copying all locators into a single folder.</para>
	/// </summary>
	public class ConsolidateLocator : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLocator">
		/// <para>Input Locator</para>
		/// <para>The input locator or composite locator that will be consolidated.</para>
		/// </param>
		/// <param name="OutputFolder">
		/// <para>Output Folder</para>
		/// <para>The output folder that will contain the consolidated locator or composite locator with its participating locators.</para>
		/// <para>If the specified folder does not exist, a new folder will be created.</para>
		/// </param>
		public ConsolidateLocator(object InLocator, object OutputFolder)
		{
			this.InLocator = InLocator;
			this.OutputFolder = OutputFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : Consolidate Locator</para>
		/// </summary>
		public override string DisplayName() => "Consolidate Locator";

		/// <summary>
		/// <para>Tool Name : ConsolidateLocator</para>
		/// </summary>
		public override string ToolName() => "ConsolidateLocator";

		/// <summary>
		/// <para>Tool Excute Name : management.ConsolidateLocator</para>
		/// </summary>
		public override string ExcuteName() => "management.ConsolidateLocator";

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
		public override object[] Parameters() => new object[] { InLocator, OutputFolder, CopyArcsdeLocator! };

		/// <summary>
		/// <para>Input Locator</para>
		/// <para>The input locator or composite locator that will be consolidated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEAddressLocator()]
		public object InLocator { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>The output folder that will contain the consolidated locator or composite locator with its participating locators.</para>
		/// <para>If the specified folder does not exist, a new folder will be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutputFolder { get; set; }

		/// <summary>
		/// <para>Composite locator only: copy participating locators in enterprise database instead of referencing them</para>
		/// <para>This parameter has no effect in ArcGIS Pro. It remains only to support backward compatibility.</para>
		/// <para><see cref="CopyArcsdeLocatorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CopyArcsdeLocator { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConsolidateLocator SetEnviroment(object? workspace = null)
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
