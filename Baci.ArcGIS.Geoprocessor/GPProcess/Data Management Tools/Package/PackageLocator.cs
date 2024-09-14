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
	/// <para>打包定位器</para>
	/// <para>将定位器或复合定位器打包，创建一个压缩 .gcpk 文件。</para>
	/// </summary>
	public class PackageLocator : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLocator">
		/// <para>Input Locator</para>
		/// <para>要打包的定位器或复合定位器。</para>
		/// </param>
		/// <param name="OutputFile">
		/// <para>Output File</para>
		/// <para>输出定位器包 (.gcpk) 的名称和位置。</para>
		/// </param>
		public PackageLocator(object InLocator, object OutputFile)
		{
			this.InLocator = InLocator;
			this.OutputFile = OutputFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 打包定位器</para>
		/// </summary>
		public override string DisplayName() => "打包定位器";

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
		/// <para>要打包的定位器或复合定位器。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEAddressLocator()]
		public object InLocator { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>输出定位器包 (.gcpk) 的名称和位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("gcpk")]
		public object OutputFile { get; set; }

		/// <summary>
		/// <para>Composite locator only: copy participating locators in enterprise database instead of referencing them</para>
		/// <para>此参数在 ArcGIS Pro 中不起作用。保留它仅是为了支持向后兼容。</para>
		/// <para><see cref="CopyArcsdeLocatorEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CopyArcsdeLocator { get; set; } = "true";

		/// <summary>
		/// <para>Additional Files</para>
		/// <para>将附加文件添加到包中。诸如 .doc、.txt、.pdf 等附加文件可用于提供有关打包内容和目的的详细信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object AdditionalFiles { get; set; }

		/// <summary>
		/// <para>Summary</para>
		/// <para>将摘要信息添加到包的属性中。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object Summary { get; set; }

		/// <summary>
		/// <para>Tags</para>
		/// <para>将标签信息添加到包的属性中。可以添加多个标签，标签之间用逗号或分号进行分隔。</para>
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
