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
	/// <para>生成排除区域</para>
	/// <para>根据像素颜色或通过裁剪值范围进行掩膜。此工具的输出被用作平衡镶嵌数据集色彩工具的输入，用于消除云和水体等能够影响所用统计信息的区域，以便对多个影像进行色彩平衡处理。</para>
	/// </summary>
	public class GenerateExcludeArea : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>想要进行掩膜处理的栅格或镶嵌数据集图层。</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster Dataset</para>
		/// <para>要创建的数据集的名称、位置和格式。将栅格数据集存储到地理数据库时，请勿向栅格数据集的名称添加文件扩展名。将栅格数据集存储到 JPEG 文件、JPEG 2000 文件或地理数据库时，可在“环境设置”中指定压缩类型和压缩质量。</para>
		/// </param>
		/// <param name="PixelType">
		/// <para>Pixel Type</para>
		/// <para>选择输入栅格数据集的像素深度。默认设置为 8 位；但较大位深度的栅格数据集需要相应大小的色彩掩膜和直方图值。</para>
		/// <para>8 位—输入栅格数据集的值介于 0 到 255 之间。这是默认设置。</para>
		/// <para>11 位—输入栅格数据集的值介于 0 到 2047 之间。</para>
		/// <para>12 位—输入栅格数据集的值介于 0 到 4095 之间。</para>
		/// <para>16 位—输入栅格数据集的值介于 0 到 65535 之间。</para>
		/// <para><see cref="PixelTypeEnum"/></para>
		/// </param>
		/// <param name="GenerateMethod">
		/// <para>Generate Method</para>
		/// <para>根据像素颜色或通过裁剪高低值创建掩膜。</para>
		/// <para>色彩掩膜—设置要在输出中包含的最大颜色值。这是默认设置。</para>
		/// <para>直方图百分比—移除高低像素值的百分比。</para>
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
		/// <para>Tool Display Name : 生成排除区域</para>
		/// </summary>
		public override string DisplayName() => "生成排除区域";

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
		public override object[] Parameters() => new object[] { InRaster, OutRaster, PixelType, GenerateMethod, MaxRed!, MaxGreen!, MaxBlue!, MaxWhite!, MaxBlack!, MaxMagenta!, MaxCyan!, MaxYellow!, PercentageLow!, PercentageHigh! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>想要进行掩膜处理的栅格或镶嵌数据集图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Raster Dataset</para>
		/// <para>要创建的数据集的名称、位置和格式。将栅格数据集存储到地理数据库时，请勿向栅格数据集的名称添加文件扩展名。将栅格数据集存储到 JPEG 文件、JPEG 2000 文件或地理数据库时，可在“环境设置”中指定压缩类型和压缩质量。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Pixel Type</para>
		/// <para>选择输入栅格数据集的像素深度。默认设置为 8 位；但较大位深度的栅格数据集需要相应大小的色彩掩膜和直方图值。</para>
		/// <para>8 位—输入栅格数据集的值介于 0 到 255 之间。这是默认设置。</para>
		/// <para>11 位—输入栅格数据集的值介于 0 到 2047 之间。</para>
		/// <para>12 位—输入栅格数据集的值介于 0 到 4095 之间。</para>
		/// <para>16 位—输入栅格数据集的值介于 0 到 65535 之间。</para>
		/// <para><see cref="PixelTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PixelType { get; set; } = "8_bit";

		/// <summary>
		/// <para>Generate Method</para>
		/// <para>根据像素颜色或通过裁剪高低值创建掩膜。</para>
		/// <para>色彩掩膜—设置要在输出中包含的最大颜色值。这是默认设置。</para>
		/// <para>直方图百分比—移除高低像素值的百分比。</para>
		/// <para><see cref="GenerateMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GenerateMethod { get; set; } = "COLOR_MASK";

		/// <summary>
		/// <para>Maximum Red</para>
		/// <para>要排除的最大红色值。默认值为 255。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Color Mask")]
		public object? MaxRed { get; set; } = "255";

		/// <summary>
		/// <para>Maximum Green</para>
		/// <para>要排除的最大绿色值。默认值为 255。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Color Mask")]
		public object? MaxGreen { get; set; } = "255";

		/// <summary>
		/// <para>Maximum Blue</para>
		/// <para>要排除的最大蓝色值。默认值为 255。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Color Mask")]
		public object? MaxBlue { get; set; } = "255";

		/// <summary>
		/// <para>Maximum White</para>
		/// <para>要排除的最大白色值。默认值为 255。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Color Mask")]
		public object? MaxWhite { get; set; } = "255";

		/// <summary>
		/// <para>Maximum Black</para>
		/// <para>要排除的最大黑色值。默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Color Mask")]
		public object? MaxBlack { get; set; } = "0";

		/// <summary>
		/// <para>Maximum Magenta</para>
		/// <para>要排除的最大洋红色值。默认值为 255。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Color Mask")]
		public object? MaxMagenta { get; set; } = "255";

		/// <summary>
		/// <para>Maximum Cyan</para>
		/// <para>要排除的最大青色值。默认值为 255。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Color Mask")]
		public object? MaxCyan { get; set; } = "255";

		/// <summary>
		/// <para>Maximum Yellow</para>
		/// <para>要排除的最大黄色值。默认值为 255。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Color Mask")]
		public object? MaxYellow { get; set; } = "255";

		/// <summary>
		/// <para>Low Percentage</para>
		/// <para>排除该最低像素值的百分比。默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Histogram Percentage")]
		public object? PercentageLow { get; set; } = "0";

		/// <summary>
		/// <para>High Percentage</para>
		/// <para>排除该最高像素值的百分比。默认值为 100。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Histogram Percentage")]
		public object? PercentageHigh { get; set; } = "100";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateExcludeArea SetEnviroment(object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? snapRaster = null, object? workspace = null)
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
			/// <para>8 位—输入栅格数据集的值介于 0 到 255 之间。这是默认设置。</para>
			/// </summary>
			[GPValue("8_BIT")]
			[Description("8 位")]
			_8_bit,

			/// <summary>
			/// <para>11 位—输入栅格数据集的值介于 0 到 2047 之间。</para>
			/// </summary>
			[GPValue("11_BIT")]
			[Description("11 位")]
			_11_bit,

			/// <summary>
			/// <para>12 位—输入栅格数据集的值介于 0 到 4095 之间。</para>
			/// </summary>
			[GPValue("12_BIT")]
			[Description("12 位")]
			_12_bit,

			/// <summary>
			/// <para>16 位—输入栅格数据集的值介于 0 到 65535 之间。</para>
			/// </summary>
			[GPValue("16_BIT")]
			[Description("16 位")]
			_16_bit,

		}

		/// <summary>
		/// <para>Generate Method</para>
		/// </summary>
		public enum GenerateMethodEnum 
		{
			/// <summary>
			/// <para>色彩掩膜—设置要在输出中包含的最大颜色值。这是默认设置。</para>
			/// </summary>
			[GPValue("COLOR_MASK")]
			[Description("色彩掩膜")]
			Color_mask,

			/// <summary>
			/// <para>直方图百分比—移除高低像素值的百分比。</para>
			/// </summary>
			[GPValue("HISTOGRAM_PERCENTAGE")]
			[Description("直方图百分比")]
			Histogram_percentage,

		}

#endregion
	}
}
