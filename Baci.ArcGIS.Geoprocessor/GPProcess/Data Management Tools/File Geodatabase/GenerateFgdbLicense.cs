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
	/// <para>生成文件地理数据库许可</para>
	/// <para>生成许可文件 (.sdlic) 以显示由生成经许可的文件地理数据库工具创建的经许可的文件地理数据库中的内容。</para>
	/// </summary>
	public class GenerateFgdbLicense : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLicDefFile">
		/// <para>Input License Definition File</para>
		/// <para>由生成经许可的文件地理数据库工具创建的许可定义文件 (.licdef)。</para>
		/// </param>
		/// <param name="OutLicFile">
		/// <para>Output Data License File</para>
		/// <para>用于分发的许可文件 (.sdlic)。</para>
		/// </param>
		public GenerateFgdbLicense(object InLicDefFile, object OutLicFile)
		{
			this.InLicDefFile = InLicDefFile;
			this.OutLicFile = OutLicFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成文件地理数据库许可</para>
		/// </summary>
		public override string DisplayName() => "生成文件地理数据库许可";

		/// <summary>
		/// <para>Tool Name : GenerateFgdbLicense</para>
		/// </summary>
		public override string ToolName() => "GenerateFgdbLicense";

		/// <summary>
		/// <para>Tool Excute Name : management.GenerateFgdbLicense</para>
		/// </summary>
		public override string ExcuteName() => "management.GenerateFgdbLicense";

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
		public override object[] Parameters() => new object[] { InLicDefFile, OutLicFile, AllowExport!, ExpDate! };

		/// <summary>
		/// <para>Input License Definition File</para>
		/// <para>由生成经许可的文件地理数据库工具创建的许可定义文件 (.licdef)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("licdef")]
		public object InLicDefFile { get; set; }

		/// <summary>
		/// <para>Output Data License File</para>
		/// <para>用于分发的许可文件 (.sdlic)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("sdlic")]
		public object OutLicFile { get; set; }

		/// <summary>
		/// <para>Allow Export of Vector Data</para>
		/// <para>指定是否允许导出矢量数据。</para>
		/// <para>矢量数据无法导出—无法通过安装数据许可文件 (.sdlic) 导出矢量数据。 这是默认设置。</para>
		/// <para>允许导出矢量数据—可通过安装数据许可文件 (.sdlic) 导出矢量数据。</para>
		/// <para><see cref="AllowExportEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? AllowExport { get; set; } = "DENY_EXPORT";

		/// <summary>
		/// <para>Expiration Date</para>
		/// <para>数据许可文件的到期日期，到期后无法再显示文件地理数据库内容。 默认值为空（空白）也就是说数据许可文件永远不会到期。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDate()]
		public object? ExpDate { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateFgdbLicense SetEnviroment(object? workspace = null )
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
			/// <para>矢量数据无法导出—无法通过安装数据许可文件 (.sdlic) 导出矢量数据。 这是默认设置。</para>
			/// </summary>
			[GPValue("DENY_EXPORT")]
			[Description("矢量数据无法导出")]
			Vector_data_cannot_be_exported,

			/// <summary>
			/// <para>允许导出矢量数据—可通过安装数据许可文件 (.sdlic) 导出矢量数据。</para>
			/// </summary>
			[GPValue("ALLOW_EXPORT")]
			[Description("允许导出矢量数据")]
			Allow_export_of_vector_data,

		}

#endregion
	}
}
