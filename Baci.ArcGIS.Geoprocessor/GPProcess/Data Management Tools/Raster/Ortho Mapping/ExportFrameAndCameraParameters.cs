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
	/// <para>Export Frame And Camera Parameters</para>
	/// <para>Exports frame and camera parameters from a mosaic dataset that contains frame imagery.</para>
	/// </summary>
	public class ExportFrameAndCameraParameters : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputMosaicDataset">
		/// <para>Input Mosaic Dataset</para>
		/// <para>The input mosaic dataset.</para>
		/// </param>
		/// <param name="OutputFile">
		/// <para>Output File</para>
		/// <para>The output file containing the frame and camera parameters. Supported file formats include .csv and .txt.</para>
		/// </param>
		public ExportFrameAndCameraParameters(object InputMosaicDataset, object OutputFile)
		{
			this.InputMosaicDataset = InputMosaicDataset;
			this.OutputFile = OutputFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Frame And Camera Parameters</para>
		/// </summary>
		public override string DisplayName() => "Export Frame And Camera Parameters";

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
		/// <para>The input mosaic dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InputMosaicDataset { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>The output file containing the frame and camera parameters. Supported file formats include .csv and .txt.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPCompositeDomain()]
		public object OutputFile { get; set; }

		/// <summary>
		/// <para>Output Format</para>
		/// <para>Specifies the output file format for the frame and camera parameters.</para>
		/// <para>Esri Frame and Camera Table—The frame and camera parameters will be exported as an Esri Frames and Camera table (.csv file). This is the default.</para>
		/// <para>Pix4D Calibrated Camera Parameters—The frame and camera parameters will be exported using the Pix4D calibrated camera parameters format (.txt file).</para>
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
			/// <para>Esri Frame and Camera Table—The frame and camera parameters will be exported as an Esri Frames and Camera table (.csv file). This is the default.</para>
			/// </summary>
			[GPValue("ESRI_FRAME_AND_CAMERA_TABLE")]
			[Description("Esri Frame and Camera Table")]
			Esri_Frame_and_Camera_Table,

			/// <summary>
			/// <para>Pix4D Calibrated Camera Parameters—The frame and camera parameters will be exported using the Pix4D calibrated camera parameters format (.txt file).</para>
			/// </summary>
			[GPValue("PIX4D_CALIBRATED_CAMERA_PARAMETERS")]
			[Description("Pix4D Calibrated Camera Parameters")]
			Pix4D_Calibrated_Camera_Parameters,

		}

#endregion
	}
}
