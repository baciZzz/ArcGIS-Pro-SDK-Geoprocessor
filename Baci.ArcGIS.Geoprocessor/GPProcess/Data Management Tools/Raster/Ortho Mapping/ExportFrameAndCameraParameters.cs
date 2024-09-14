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
	/// <para>Export Frame And Camera Parameters</para>
	/// <para>导出帧和照相机参数</para>
	/// <para>从包含帧影像的镶嵌数据集中导出帧和照相机参数。</para>
	/// </summary>
	public class ExportFrameAndCameraParameters : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputMosaicDataset">
		/// <para>Input Mosaic Dataset</para>
		/// <para>输入镶嵌数据集。</para>
		/// </param>
		/// <param name="OutputFile">
		/// <para>Output File</para>
		/// <para>包含帧和照相机参数的输出文件。 受支持的文件格式包括 .csv 和 .txt。</para>
		/// </param>
		public ExportFrameAndCameraParameters(object InputMosaicDataset, object OutputFile)
		{
			this.InputMosaicDataset = InputMosaicDataset;
			this.OutputFile = OutputFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 导出帧和照相机参数</para>
		/// </summary>
		public override string DisplayName() => "导出帧和照相机参数";

		/// <summary>
		/// <para>Tool Name : ExportFrameAndCameraParameters</para>
		/// </summary>
		public override string ToolName() => "ExportFrameAndCameraParameters";

		/// <summary>
		/// <para>Tool Excute Name : management.ExportFrameAndCameraParameters</para>
		/// </summary>
		public override string ExcuteName() => "management.ExportFrameAndCameraParameters";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputMosaicDataset, OutputFile, OutputFormat! };

		/// <summary>
		/// <para>Input Mosaic Dataset</para>
		/// <para>输入镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InputMosaicDataset { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>包含帧和照相机参数的输出文件。 受支持的文件格式包括 .csv 和 .txt。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPCompositeDomain()]
		public object OutputFile { get; set; }

		/// <summary>
		/// <para>Output Format</para>
		/// <para>指定帧和照相机参数的输出文件格式。</para>
		/// <para>Esri 帧和照相机表—帧和照相机参数将导出为 Esri 帧和照相机表（.csv 文件）。 这是默认设置。</para>
		/// <para>Pix4D 校准照相机参数—帧和照相机参数将使用 Pix4D 校准照相机参数格式导出（.txt 文件）。</para>
		/// <para><see cref="OutputFormatEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? OutputFormat { get; set; } = "ESRI_FRAME_AND_CAMERA_TABLE";

		#region InnerClass

		/// <summary>
		/// <para>Output Format</para>
		/// </summary>
		public enum OutputFormatEnum 
		{
			/// <summary>
			/// <para>Esri 帧和照相机表—帧和照相机参数将导出为 Esri 帧和照相机表（.csv 文件）。 这是默认设置。</para>
			/// </summary>
			[GPValue("ESRI_FRAME_AND_CAMERA_TABLE")]
			[Description("Esri 帧和照相机表")]
			Esri_Frame_and_Camera_Table,

			/// <summary>
			/// <para>Pix4D 校准照相机参数—帧和照相机参数将使用 Pix4D 校准照相机参数格式导出（.txt 文件）。</para>
			/// </summary>
			[GPValue("PIX4D_CALIBRATED_CAMERA_PARAMETERS")]
			[Description("Pix4D 校准照相机参数")]
			Pix4D_Calibrated_Camera_Parameters,

		}

#endregion
	}
}
