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
	/// <para>Color Balance Mosaic Dataset</para>
	/// <para>Color Balance Mosaic Dataset</para>
	/// <para>Makes transitions from one image to an adjoining image appear seamless.</para>
	/// </summary>
	public class ColorBalanceMosaicDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset you want to color balance.</para>
		/// </param>
		public ColorBalanceMosaicDataset(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Color Balance Mosaic Dataset</para>
		/// </summary>
		public override string DisplayName() => "Color Balance Mosaic Dataset";

		/// <summary>
		/// <para>Tool Name : ColorBalanceMosaicDataset</para>
		/// </summary>
		public override string ToolName() => "ColorBalanceMosaicDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.ColorBalanceMosaicDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.ColorBalanceMosaicDataset";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, BalancingMethod, ColorSurfaceType, TargetRaster, ExcludeRaster, StretchType, Gamma, BlockField, OutMosaicDataset };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset you want to color balance.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMosaicLayer()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Balance Method</para>
		/// <para>The balancing algorithm to use.</para>
		/// <para>Dodging—Change each pixel&apos;s value toward a target color. With this technique, you must also choose the type of target color surface, which affects the target color. Dodging tends to give the best result in most cases.</para>
		/// <para>Histogram—Change each pixel&apos;s value according to its relationship with a target histogram. The target histogram can be derived from all of the rasters, or you can specify a raster. This technique works well when all of the rasters have a similar histogram.</para>
		/// <para>Standard deviation—Change each of the pixel&apos;s values according to its relationship with the histogram of the target raster, within one standard deviation. The standard deviation can be calculated from all of the rasters in the mosaic dataset, or you can specify a target raster. This technique works best when all of the rasters have normal distributions.</para>
		/// <para><see cref="BalancingMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BalancingMethod { get; set; } = "DODGING";

		/// <summary>
		/// <para>Color Surface Type</para>
		/// <para>When using the Dodging balance method, each pixel needs a target color, which is determined by the surface type.</para>
		/// <para>Single color—Use when there are only a small number of raster datasets and a few different types of ground objects. If there are too many raster datasets or too many types of ground surfaces, the output color may become blurred. All the pixels are altered toward a single color point—the average of all pixels.</para>
		/// <para>Color grid— Use when you have a large number of raster datasets, or areas with a large number of diverse ground objects. Pixels are altered toward multiple target colors, which are distributed across the mosaic dataset.</para>
		/// <para>First order— This technique tends to create a smoother color change and uses less storage in the auxiliary table, but it may take longer to process compared to the color grid surface. All pixels are altered toward many points obtained from the two-dimensional polynomial slanted plane.</para>
		/// <para>Second order— This technique tends to create a smoother color change and uses less storage in the auxiliary table, but it may take longer to process compared to the color grid surface. All input pixels are altered toward a set of multiple points obtained from the two-dimensional polynomial parabolic surface.</para>
		/// <para>Third order— This technique tends to create a smoother color change and uses less storage in the auxiliary table, but it may take longer to process compared to the color grid surface. All input pixels are altered toward multiple points obtained from the cubic surface.</para>
		/// <para><see cref="ColorSurfaceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ColorSurfaceType { get; set; } = "COLOR_GRID";

		/// <summary>
		/// <para>Target Raster</para>
		/// <para>The raster you want to use to color balance the other images. The balance method and color surface type, if applicable, will be derived from this image.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object TargetRaster { get; set; }

		/// <summary>
		/// <para>Exclude Area Raster</para>
		/// <para>Apply a mask before color balancing the mosaic dataset. Create the mask using the Generate Exclude Area tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRasterLayer()]
		[Category("Pre-processing Options")]
		public object ExcludeRaster { get; set; }

		/// <summary>
		/// <para>Stretch Type</para>
		/// <para>Stretch the range of values before color balancing. Choose from one of the following options:</para>
		/// <para>None— Use the original pixel values. This is the default.</para>
		/// <para>Adaptive— An adaptive prestretch will be applied before any processing takes place.</para>
		/// <para>Minimum Maximum— Stretch the values between their actual minimum and maximum values.</para>
		/// <para>Standard deviation— Stretch the values between the default number of standard deviations.</para>
		/// <para><see cref="StretchTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Pre-processing Options")]
		public object StretchType { get; set; } = "NONE";

		/// <summary>
		/// <para>Gamma</para>
		/// <para>Adjust the overall brightness of an image. A low value will minimize the contrast between moderate values by making them appear darker. Higher values increase the contrast by making them appear brighter.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Pre-processing Options")]
		public object Gamma { get; set; } = "1";

		/// <summary>
		/// <para>Block Field</para>
		/// <para>The name of the field in a mosaic dataset's attribute table used to identify items that should be considered one item when performing some calculations and operations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object BlockField { get; set; }

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMosaicLayer()]
		public object OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ColorBalanceMosaicDataset SetEnviroment(object parallelProcessingFactor = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Balance Method</para>
		/// </summary>
		public enum BalancingMethodEnum 
		{
			/// <summary>
			/// <para>Dodging—Change each pixel&apos;s value toward a target color. With this technique, you must also choose the type of target color surface, which affects the target color. Dodging tends to give the best result in most cases.</para>
			/// </summary>
			[GPValue("DODGING")]
			[Description("Dodging")]
			Dodging,

			/// <summary>
			/// <para>Histogram—Change each pixel&apos;s value according to its relationship with a target histogram. The target histogram can be derived from all of the rasters, or you can specify a raster. This technique works well when all of the rasters have a similar histogram.</para>
			/// </summary>
			[GPValue("HISTOGRAM")]
			[Description("Histogram")]
			Histogram,

			/// <summary>
			/// <para>Standard deviation—Change each of the pixel&apos;s values according to its relationship with the histogram of the target raster, within one standard deviation. The standard deviation can be calculated from all of the rasters in the mosaic dataset, or you can specify a target raster. This technique works best when all of the rasters have normal distributions.</para>
			/// </summary>
			[GPValue("STANDARD_DEVIATION")]
			[Description("Standard deviation")]
			Standard_deviation,

		}

		/// <summary>
		/// <para>Color Surface Type</para>
		/// </summary>
		public enum ColorSurfaceTypeEnum 
		{
			/// <summary>
			/// <para>Single color—Use when there are only a small number of raster datasets and a few different types of ground objects. If there are too many raster datasets or too many types of ground surfaces, the output color may become blurred. All the pixels are altered toward a single color point—the average of all pixels.</para>
			/// </summary>
			[GPValue("SINGLE_COLOR")]
			[Description("Single color")]
			Single_color,

			/// <summary>
			/// <para>Color grid— Use when you have a large number of raster datasets, or areas with a large number of diverse ground objects. Pixels are altered toward multiple target colors, which are distributed across the mosaic dataset.</para>
			/// </summary>
			[GPValue("COLOR_GRID")]
			[Description("Color grid")]
			Color_grid,

			/// <summary>
			/// <para>First order— This technique tends to create a smoother color change and uses less storage in the auxiliary table, but it may take longer to process compared to the color grid surface. All pixels are altered toward many points obtained from the two-dimensional polynomial slanted plane.</para>
			/// </summary>
			[GPValue("FIRST_ORDER")]
			[Description("First order")]
			First_order,

			/// <summary>
			/// <para>Second order— This technique tends to create a smoother color change and uses less storage in the auxiliary table, but it may take longer to process compared to the color grid surface. All input pixels are altered toward a set of multiple points obtained from the two-dimensional polynomial parabolic surface.</para>
			/// </summary>
			[GPValue("SECOND_ORDER")]
			[Description("Second order")]
			Second_order,

			/// <summary>
			/// <para>Third order— This technique tends to create a smoother color change and uses less storage in the auxiliary table, but it may take longer to process compared to the color grid surface. All input pixels are altered toward multiple points obtained from the cubic surface.</para>
			/// </summary>
			[GPValue("THIRD_ORDER")]
			[Description("Third order")]
			Third_order,

		}

		/// <summary>
		/// <para>Stretch Type</para>
		/// </summary>
		public enum StretchTypeEnum 
		{
			/// <summary>
			/// <para>None— Use the original pixel values. This is the default.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>Standard deviation— Stretch the values between the default number of standard deviations.</para>
			/// </summary>
			[GPValue("STANDARD_DEVIATION")]
			[Description("Standard deviation")]
			Standard_deviation,

			/// <summary>
			/// <para>Minimum Maximum— Stretch the values between their actual minimum and maximum values.</para>
			/// </summary>
			[GPValue("MINIMUM_MAXIMUM")]
			[Description("Minimum Maximum")]
			Minimum_Maximum,

			/// <summary>
			/// <para>Adaptive— An adaptive prestretch will be applied before any processing takes place.</para>
			/// </summary>
			[GPValue("ADAPTIVE")]
			[Description("Adaptive")]
			Adaptive,

		}

#endregion
	}
}
