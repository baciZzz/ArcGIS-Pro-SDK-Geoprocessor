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
	/// <para>Generate Exclude Area</para>
	/// <para>Masks pixels based on their color or by clipping a range of values. The output of this tool is used as an input to the Color Balance Mosaic Dataset tool to eliminate areas such as clouds and water that can skew the statistics used to color balance multiple images.</para>
	/// </summary>
	public class GenerateExcludeArea : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The raster or mosaic dataset layer that you want to mask.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster Dataset</para>
		/// <para>The name, location and format for the dataset you are creating. When storing a raster dataset in a geodatabase, do not add a file extension to the name of the raster dataset. When storing your raster dataset to a JPEG file, a JPEG 2000 file, or a geodatabase, you can specify a Compression type and Compression Quality within the Environment Settings.</para>
		/// </param>
		/// <param name="PixelType">
		/// <para>Pixel Type</para>
		/// <para>Choose the pixel depth of your input raster dataset. 8-bit is the default value; however, raster datasets with a greater bit-depth will need to have the color mask and histogram values scaled accordingly.</para>
		/// <para>8 bit—The input raster dataset has values from 0 to 255. This is the default.</para>
		/// <para>11 bit—The input raster dataset has values from 0 to 2047.</para>
		/// <para>12 bit—The input raster dataset has values from 0 to 4095.</para>
		/// <para>16 bit—The input raster dataset has values from 0 to 65535.</para>
		/// <para><see cref="PixelTypeEnum"/></para>
		/// </param>
		/// <param name="GenerateMethod">
		/// <para>Generate Method</para>
		/// <para>Create your mask based on the color of the pixels or by clipping high and low values.</para>
		/// <para>Color mask—Set the maximum color values to include in the output. This is the default.</para>
		/// <para>Histogram percentage—Remove a percentage of high and low pixel values.</para>
		/// <para><see cref="GenerateMethodEnum"/></para>
		/// </param>
		public GenerateExcludeArea(object InRaster, object OutRaster, object PixelType, object GenerateMethod)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
			this.PixelType = PixelType;
			this.GenerateMethod = GenerateMethod;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Exclude Area</para>
		/// </summary>
		public override string DisplayName() => "Generate Exclude Area";

		/// <summary>
		/// <para>Tool Name : GenerateExcludeArea</para>
		/// </summary>
		public override string ToolName() => "GenerateExcludeArea";

		/// <summary>
		/// <para>Tool Excute Name : management.GenerateExcludeArea</para>
		/// </summary>
		public override string ExcuteName() => "management.GenerateExcludeArea";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, PixelType, GenerateMethod, MaxRed, MaxGreen, MaxBlue, MaxWhite, MaxBlack, MaxMagenta, MaxCyan, MaxYellow, PercentageLow, PercentageHigh };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The raster or mosaic dataset layer that you want to mask.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>The name, location and format for the dataset you are creating. When storing a raster dataset in a geodatabase, do not add a file extension to the name of the raster dataset. When storing your raster dataset to a JPEG file, a JPEG 2000 file, or a geodatabase, you can specify a Compression type and Compression Quality within the Environment Settings.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Pixel Type</para>
		/// <para>Choose the pixel depth of your input raster dataset. 8-bit is the default value; however, raster datasets with a greater bit-depth will need to have the color mask and histogram values scaled accordingly.</para>
		/// <para>8 bit—The input raster dataset has values from 0 to 255. This is the default.</para>
		/// <para>11 bit—The input raster dataset has values from 0 to 2047.</para>
		/// <para>12 bit—The input raster dataset has values from 0 to 4095.</para>
		/// <para>16 bit—The input raster dataset has values from 0 to 65535.</para>
		/// <para><see cref="PixelTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PixelType { get; set; } = "8_bit";

		/// <summary>
		/// <para>Generate Method</para>
		/// <para>Create your mask based on the color of the pixels or by clipping high and low values.</para>
		/// <para>Color mask—Set the maximum color values to include in the output. This is the default.</para>
		/// <para>Histogram percentage—Remove a percentage of high and low pixel values.</para>
		/// <para><see cref="GenerateMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GenerateMethod { get; set; } = "COLOR_MASK";

		/// <summary>
		/// <para>Maximum Red</para>
		/// <para>The maximum red value to exclude. The default is 255.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Color Mask")]
		public object MaxRed { get; set; } = "255";

		/// <summary>
		/// <para>Maximum Green</para>
		/// <para>The maximum green value to exclude. The default is 255.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Color Mask")]
		public object MaxGreen { get; set; } = "255";

		/// <summary>
		/// <para>Maximum Blue</para>
		/// <para>The maximum blue value to exclude. The default is 255.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Color Mask")]
		public object MaxBlue { get; set; } = "255";

		/// <summary>
		/// <para>Maximum White</para>
		/// <para>The maximum white value to exclude. The default is 255.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Color Mask")]
		public object MaxWhite { get; set; } = "255";

		/// <summary>
		/// <para>Maximum Black</para>
		/// <para>The maximum black value to exclude. The default is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Color Mask")]
		public object MaxBlack { get; set; } = "0";

		/// <summary>
		/// <para>Maximum Magenta</para>
		/// <para>The maximum magenta value to exclude. The default is 255.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Color Mask")]
		public object MaxMagenta { get; set; } = "255";

		/// <summary>
		/// <para>Maximum Cyan</para>
		/// <para>The maximum cyan value to exclude. The default is 255.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Color Mask")]
		public object MaxCyan { get; set; } = "255";

		/// <summary>
		/// <para>Maximum Yellow</para>
		/// <para>The maximum yellow value to exclude. The default is 255.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Color Mask")]
		public object MaxYellow { get; set; } = "255";

		/// <summary>
		/// <para>Low Percentage</para>
		/// <para>Exclude this percentage of the lowest pixel values. The default is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Histogram Percentage")]
		public object PercentageLow { get; set; } = "0";

		/// <summary>
		/// <para>High Percentage</para>
		/// <para>Exclude this percentage of the highest pixel values. The default is 100.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Histogram Percentage")]
		public object PercentageHigh { get; set; } = "100";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateExcludeArea SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object snapRaster = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Pixel Type</para>
		/// </summary>
		public enum PixelTypeEnum 
		{
			/// <summary>
			/// <para>8 bit—The input raster dataset has values from 0 to 255. This is the default.</para>
			/// </summary>
			[GPValue("8_BIT")]
			[Description("8 bit")]
			_8_bit,

			/// <summary>
			/// <para>11 bit—The input raster dataset has values from 0 to 2047.</para>
			/// </summary>
			[GPValue("11_BIT")]
			[Description("11 bit")]
			_11_bit,

			/// <summary>
			/// <para>12 bit—The input raster dataset has values from 0 to 4095.</para>
			/// </summary>
			[GPValue("12_BIT")]
			[Description("12 bit")]
			_12_bit,

			/// <summary>
			/// <para>16 bit—The input raster dataset has values from 0 to 65535.</para>
			/// </summary>
			[GPValue("16_BIT")]
			[Description("16 bit")]
			_16_bit,

		}

		/// <summary>
		/// <para>Generate Method</para>
		/// </summary>
		public enum GenerateMethodEnum 
		{
			/// <summary>
			/// <para>Color mask—Set the maximum color values to include in the output. This is the default.</para>
			/// </summary>
			[GPValue("COLOR_MASK")]
			[Description("Color mask")]
			Color_mask,

			/// <summary>
			/// <para>Histogram percentage—Remove a percentage of high and low pixel values.</para>
			/// </summary>
			[GPValue("HISTOGRAM_PERCENTAGE")]
			[Description("Histogram percentage")]
			Histogram_percentage,

		}

#endregion
	}
}
