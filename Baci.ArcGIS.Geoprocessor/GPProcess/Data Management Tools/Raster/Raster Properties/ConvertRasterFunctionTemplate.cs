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
	/// <para>Convert Raster Function Template</para>
	/// <para>转换栅格函数模板</para>
	/// <para>将栅格函数模板在格式（rft.xml、json 和二进制）间进行转换。</para>
	/// </summary>
	public class ConvertRasterFunctionTemplate : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterFunctionTemplate">
		/// <para>Input Raster Function Template</para>
		/// <para>输入栅格函数模板文件。输入模板文件可以为 XML、JSON 或二进制格式。</para>
		/// </param>
		/// <param name="OutRasterFunctionTemplateFile">
		/// <para>Output Raster Function Template File</para>
		/// <para>输出栅格函数模板文件路径和文件名。</para>
		/// </param>
		public ConvertRasterFunctionTemplate(object InRasterFunctionTemplate, object OutRasterFunctionTemplateFile)
		{
			this.InRasterFunctionTemplate = InRasterFunctionTemplate;
			this.OutRasterFunctionTemplateFile = OutRasterFunctionTemplateFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 转换栅格函数模板</para>
		/// </summary>
		public override string DisplayName() => "转换栅格函数模板";

		/// <summary>
		/// <para>Tool Name : ConvertRasterFunctionTemplate</para>
		/// </summary>
		public override string ToolName() => "ConvertRasterFunctionTemplate";

		/// <summary>
		/// <para>Tool Excute Name : management.ConvertRasterFunctionTemplate</para>
		/// </summary>
		public override string ExcuteName() => "management.ConvertRasterFunctionTemplate";

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
		public override object[] Parameters() => new object[] { InRasterFunctionTemplate, OutRasterFunctionTemplateFile, Format! };

		/// <summary>
		/// <para>Input Raster Function Template</para>
		/// <para>输入栅格函数模板文件。输入模板文件可以为 XML、JSON 或二进制格式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InRasterFunctionTemplate { get; set; }

		/// <summary>
		/// <para>Output Raster Function Template File</para>
		/// <para>输出栅格函数模板文件路径和文件名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("rft.xml", "rft.json", "rft", "xml", "json")]
		public object OutRasterFunctionTemplateFile { get; set; }

		/// <summary>
		/// <para>Format</para>
		/// <para>输出函数模板文件格式。</para>
		/// <para>XML—XML 输出格式。</para>
		/// <para>JSON—JSON 输出格式。这是默认设置。</para>
		/// <para>二进制—二进制输出格式。</para>
		/// <para><see cref="FormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Format { get; set; } = "JSON";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConvertRasterFunctionTemplate SetEnviroment(object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Format</para>
		/// </summary>
		public enum FormatEnum 
		{
			/// <summary>
			/// <para>XML—XML 输出格式。</para>
			/// </summary>
			[GPValue("XML")]
			[Description("XML")]
			XML,

			/// <summary>
			/// <para>JSON—JSON 输出格式。这是默认设置。</para>
			/// </summary>
			[GPValue("JSON")]
			[Description("JSON")]
			JSON,

			/// <summary>
			/// <para>二进制—二进制输出格式。</para>
			/// </summary>
			[GPValue("BINARY")]
			[Description("二进制")]
			Binary,

		}

#endregion
	}
}
