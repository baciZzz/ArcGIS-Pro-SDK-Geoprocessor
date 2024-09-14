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
	/// <para>Convert Raster Function Template</para>
	/// <para>Converts a raster function template between formats (rft.xml, json, and binary).</para>
	/// </summary>
	public class ConvertRasterFunctionTemplate : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterFunctionTemplate">
		/// <para>Input Raster Function Template</para>
		/// <para>The input raster function template file. The input template file can be XML, JSON, or binary format.</para>
		/// </param>
		/// <param name="OutRasterFunctionTemplateFile">
		/// <para>Output Raster Function Template File</para>
		/// <para>The output raster function template file path and file name.</para>
		/// </param>
		public ConvertRasterFunctionTemplate(object InRasterFunctionTemplate, object OutRasterFunctionTemplateFile)
		{
			this.InRasterFunctionTemplate = InRasterFunctionTemplate;
			this.OutRasterFunctionTemplateFile = OutRasterFunctionTemplateFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Convert Raster Function Template</para>
		/// </summary>
		public override string DisplayName() => "Convert Raster Function Template";

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
		/// <para>The input raster function template file. The input template file can be XML, JSON, or binary format.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InRasterFunctionTemplate { get; set; }

		/// <summary>
		/// <para>Output Raster Function Template File</para>
		/// <para>The output raster function template file path and file name.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("rft.xml", "rft.json", "rft", "xml", "json")]
		public object OutRasterFunctionTemplateFile { get; set; }

		/// <summary>
		/// <para>Format</para>
		/// <para>The output function template file format.</para>
		/// <para>XML—XML output format.</para>
		/// <para>JSON—JSON output format. This is the default.</para>
		/// <para>Binary—Binary output format.</para>
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
			/// <para>XML—XML output format.</para>
			/// </summary>
			[GPValue("XML")]
			[Description("XML")]
			XML,

			/// <summary>
			/// <para>JSON—JSON output format. This is the default.</para>
			/// </summary>
			[GPValue("JSON")]
			[Description("JSON")]
			JSON,

			/// <summary>
			/// <para>Binary—Binary output format.</para>
			/// </summary>
			[GPValue("BINARY")]
			[Description("Binary")]
			Binary,

		}

#endregion
	}
}
