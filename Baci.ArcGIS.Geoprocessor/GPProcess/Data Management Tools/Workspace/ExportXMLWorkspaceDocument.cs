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
	/// <para>Export XML Workspace Document</para>
	/// <para>导出 XML 工作空间文档</para>
	/// <para>创建地理数据库内容的可读取 XML 文档。</para>
	/// </summary>
	public class ExportXMLWorkspaceDocument : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InData">
		/// <para>Input Data</para>
		/// <para>要导出的并以 XML 工作空间文档表示的输入数据集。输入数据可以是地理数据库、要素数据集、要素类、表、栅格或者栅格目录。如果存在多个输入，则这些输入必须来自同一工作空间。不支持多个输入工作空间。</para>
		/// </param>
		/// <param name="OutFile">
		/// <para>Output File</para>
		/// <para>要创建的 XML 工作空间文档文件。它可以是 XML 文件 (.xml) 或 ZIP 压缩文件（.zip 或 .z）。</para>
		/// </param>
		public ExportXMLWorkspaceDocument(object InData, object OutFile)
		{
			this.InData = InData;
			this.OutFile = OutFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 导出 XML 工作空间文档</para>
		/// </summary>
		public override string DisplayName() => "导出 XML 工作空间文档";

		/// <summary>
		/// <para>Tool Name : ExportXMLWorkspaceDocument</para>
		/// </summary>
		public override string ToolName() => "ExportXMLWorkspaceDocument";

		/// <summary>
		/// <para>Tool Excute Name : management.ExportXMLWorkspaceDocument</para>
		/// </summary>
		public override string ExcuteName() => "management.ExportXMLWorkspaceDocument";

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
		public override object[] Parameters() => new object[] { InData, OutFile, ExportType!, StorageType!, ExportMetadata! };

		/// <summary>
		/// <para>Input Data</para>
		/// <para>要导出的并以 XML 工作空间文档表示的输入数据集。输入数据可以是地理数据库、要素数据集、要素类、表、栅格或者栅格目录。如果存在多个输入，则这些输入必须来自同一工作空间。不支持多个输入工作空间。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InData { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>要创建的 XML 工作空间文档文件。它可以是 XML 文件 (.xml) 或 ZIP 压缩文件（.zip 或 .z）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml", "zip", "z")]
		public object OutFile { get; set; }

		/// <summary>
		/// <para>Export Options</para>
		/// <para>确定输出 XML 工作空间文档是包含输入的所有数据（表和要素类记录，包括几何）还是仅包含方案。</para>
		/// <para>Data—同时导出方案和数据。这是默认设置。</para>
		/// <para>仅方案—仅导出方案。</para>
		/// <para><see cref="ExportTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ExportType { get; set; } = "DATA";

		/// <summary>
		/// <para>Storage Type</para>
		/// <para>确定从要素类中导出数据时要素几何的存储方式。</para>
		/// <para>二进制—几何将以压缩的 base64 二进制格式进行存储。该二进制格式将生成较小的 XML 工作空间文档。将由使用 ArcObjects 的自定义程序读取 XML 工作空间文档时，使用该选项。这是默认设置。</para>
		/// <para>归一化—几何将以未压缩的格式存储，从而产生更大的文件。将由不使用 ArcObjects 的自定义程序读取 XML 工作空间文档时，使用该选项。</para>
		/// <para><see cref="StorageTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? StorageType { get; set; } = "BINARY";

		/// <summary>
		/// <para>Export Metadata</para>
		/// <para>确定是否导出元数据。</para>
		/// <para>取消选中 - 不导出元数据。</para>
		/// <para>选中 - 如果输入包含元数据，将导出元数据。这是默认设置。</para>
		/// <para><see cref="ExportMetadataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ExportMetadata { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportXMLWorkspaceDocument SetEnviroment(object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Export Options</para>
		/// </summary>
		public enum ExportTypeEnum 
		{
			/// <summary>
			/// <para>Data—同时导出方案和数据。这是默认设置。</para>
			/// </summary>
			[GPValue("DATA")]
			[Description("Data")]
			Data,

			/// <summary>
			/// <para>仅方案—仅导出方案。</para>
			/// </summary>
			[GPValue("SCHEMA_ONLY")]
			[Description("仅方案")]
			Schema_only,

		}

		/// <summary>
		/// <para>Storage Type</para>
		/// </summary>
		public enum StorageTypeEnum 
		{
			/// <summary>
			/// <para>二进制—几何将以压缩的 base64 二进制格式进行存储。该二进制格式将生成较小的 XML 工作空间文档。将由使用 ArcObjects 的自定义程序读取 XML 工作空间文档时，使用该选项。这是默认设置。</para>
			/// </summary>
			[GPValue("BINARY")]
			[Description("二进制")]
			Binary,

			/// <summary>
			/// <para>归一化—几何将以未压缩的格式存储，从而产生更大的文件。将由不使用 ArcObjects 的自定义程序读取 XML 工作空间文档时，使用该选项。</para>
			/// </summary>
			[GPValue("NORMALIZED")]
			[Description("归一化")]
			Normalized,

		}

		/// <summary>
		/// <para>Export Metadata</para>
		/// </summary>
		public enum ExportMetadataEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("METADATA")]
			METADATA,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_METADATA")]
			NO_METADATA,

		}

#endregion
	}
}
