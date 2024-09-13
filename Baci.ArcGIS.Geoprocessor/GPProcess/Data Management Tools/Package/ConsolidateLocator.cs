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
	/// <para>合并定位器</para>
	/// <para>通过将所有定位器复制到同一文件夹中，可以合并定位器或复合定位器。</para>
	/// </summary>
	public class ConsolidateLocator : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLocator">
		/// <para>Input Locator</para>
		/// <para>要合并的输入定位器或复合定位器。</para>
		/// </param>
		/// <param name="OutputFolder">
		/// <para>Output Folder</para>
		/// <para>将包含合并定位器或复合定位器及其参与定位器的输出文件夹。</para>
		/// <para>如果指定的文件夹不存在，将创建一个新文件夹。</para>
		/// </param>
		public ConsolidateLocator(object InLocator, object OutputFolder)
		{
			this.InLocator = InLocator;
			this.OutputFolder = OutputFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : 合并定位器</para>
		/// </summary>
		public override string DisplayName() => "合并定位器";

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
		/// <para>要合并的输入定位器或复合定位器。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEAddressLocator()]
		public object InLocator { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>将包含合并定位器或复合定位器及其参与定位器的输出文件夹。</para>
		/// <para>如果指定的文件夹不存在，将创建一个新文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutputFolder { get; set; }

		/// <summary>
		/// <para>Composite locator only: copy participating locators in enterprise database instead of referencing them</para>
		/// <para>此参数在 ArcGIS Pro 中不起作用。保留它仅是为了支持向后兼容。</para>
		/// <para><see cref="CopyArcsdeLocatorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CopyArcsdeLocator { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConsolidateLocator SetEnviroment(object? workspace = null )
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
