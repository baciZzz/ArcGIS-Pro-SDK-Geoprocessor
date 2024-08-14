using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ImageAnalystTools
{
	/// <summary>
	/// <para>Compute Change Raster</para>
	/// <para>Calculates the absolute, relative, categorical, or spectral difference between two raster datasets.</para>
	/// </summary>
	public class ComputeChangeRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="FromRaster">
		/// <para>From Raster</para>
		/// <para>The initial or earlier raster to be analyzed.</para>
		/// </param>
		/// <param name="ToRaster">
		/// <para>To Raster</para>
		/// <para>The final or later raster to be analyzed. This is the raster that will be compared to the initial raster.</para>
		/// </param>
		/// <param name="OutRasterDataset">
		/// <para>Output Raster</para>
		/// <para>The output change raster dataset.</para>
		/// </param>
		public ComputeChangeRaster(object FromRaster, object ToRaster, object OutRasterDataset)
		{
			this.FromRaster = FromRaster;
			this.ToRaster = ToRaster;
			this.OutRasterDataset = OutRasterDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Compute Change Raster</para>
		/// </summary>
		public override string DisplayName => "Compute Change Raster";

		/// <summary>
		/// <para>Tool Name : ComputeChangeRaster</para>
		/// </summary>
		public override string ToolName => "ComputeChangeRaster";

		/// <summary>
		/// <para>Tool Excute Name : ia.ComputeChangeRaster</para>
		/// </summary>
		public override string ExcuteName => "ia.ComputeChangeRaster";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "cellAlignment", "cellSize", "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { FromRaster, ToRaster, OutRasterDataset, ComputeChangeMethod!, FromClasses!, ToClasses!, FilterMethod!, DefineTransitionColors!, FromClassnameField!, ToClassnameField! };

		/// <summary>
		/// <para>From Raster</para>
		/// <para>The initial or earlier raster to be analyzed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object FromRaster { get; set; }

		/// <summary>
		/// <para>To Raster</para>
		/// <para>The final or later raster to be analyzed. This is the raster that will be compared to the initial raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object ToRaster { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>The output change raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRasterDataset { get; set; }

		/// <summary>
		/// <para>Compute Change Method</para>
		/// <para>Specifies the type of calculation that will be performed between the two rasters.</para>
		/// <para>Difference—The mathematical difference, or subtraction, between the pixel values in the rasters will be calculated. This is the default.</para>
		/// <para>Relative difference—The difference in pixel values, accounting for the quantities of the values being compared, will be calculated.</para>
		/// <para>Categorical difference—The difference between two categorical or thematic rasters will be calculated. The output will contain class transitions that occurred between the two rasters.</para>
		/// <para>Spectral Euclidean distance—The Euclidean distance between the pixel values of two multiband rasters will be calculated.</para>
		/// <para>Spectral angle difference—The spectral angle between the pixel values of two multiband rasters will be calculated. The output is in radians.</para>
		/// <para>Band with most change—The band that accounts for the most change in each pixel between two multiband rasters will be calculated.</para>
		/// <para><see cref="ComputeChangeMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ComputeChangeMethod { get; set; } = "DIFFERENCE";

		/// <summary>
		/// <para>From Classes</para>
		/// <para>The list of class names from the From Raster parameter that will be included in the computation. If no classes are provided, all classes will be included.</para>
		/// <para>This parameter is active when the Compute Change Method parameter is set to Categorical difference.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? FromClasses { get; set; }

		/// <summary>
		/// <para>To Classes</para>
		/// <para>The list of class names from the To Raster parameter that will be included in the computation. If no classes are provided, all classes will be included.</para>
		/// <para>This parameter is active when the Compute Change Method parameter is set to Categorical difference.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? ToClasses { get; set; }

		/// <summary>
		/// <para>Filter Method</para>
		/// <para>Specifies the pixels that will be categorized in the output raster. This parameter is active when the Compute Change Method parameter is set to Categorical difference.</para>
		/// <para>Changed pixels only—Only the pixels that changed categories will be categorized in the output. Pixels that did not change categories will be grouped in a class called Other.</para>
		/// <para>Unchanged pixels only—Only the pixels that did not change categories will be categorized in the output. Pixels that changed categories will be grouped in a class called Other.</para>
		/// <para>All pixels—All pixels will be categorized in the output. This is the default.</para>
		/// <para><see cref="FilterMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? FilterMethod { get; set; } = "CHANGED_PIXELS_ONLY";

		/// <summary>
		/// <para>Transition Class Colors</para>
		/// <para>Specifies the color that will be used to symbolize the output classes. When a pixel changes from one class type to another, the output pixel color represents the initial class type, the final class type, or a blend of the two.</para>
		/// <para>This parameter is active when the Compute Change Method parameter is set to Categorical difference.</para>
		/// <para><see cref="DefineTransitionColorsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("More Options")]
		public object? DefineTransitionColors { get; set; } = "AVERAGE";

		/// <summary>
		/// <para>Classname Field for From Raster</para>
		/// <para>The field that will store class names in the From Raster parameter value. The tool automatically searches for the ClassName field or Class_Name field to use.</para>
		/// <para>Use this parameter if the input does not contain these standard field names.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[Category("More Options")]
		public object? FromClassnameField { get; set; }

		/// <summary>
		/// <para>Classname Field for To Raster</para>
		/// <para>The field that will store class names in the To Raster parameter value. The tool will automatically search for the ClassName field or Class_Name field to use.</para>
		/// <para>Use this parameter if the input does not contain these standard field names.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[Category("More Options")]
		public object? ToClassnameField { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ComputeChangeRaster SetEnviroment(object? cellAlignment = null , object? cellSize = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(cellAlignment: cellAlignment, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Compute Change Method</para>
		/// </summary>
		public enum ComputeChangeMethodEnum 
		{
			/// <summary>
			/// <para>Difference—The mathematical difference, or subtraction, between the pixel values in the rasters will be calculated. This is the default.</para>
			/// </summary>
			[GPValue("DIFFERENCE")]
			[Description("Difference")]
			Difference,

			/// <summary>
			/// <para>Relative difference—The difference in pixel values, accounting for the quantities of the values being compared, will be calculated.</para>
			/// </summary>
			[GPValue("RELATIVE_DIFFERENCE")]
			[Description("Relative difference")]
			Relative_difference,

			/// <summary>
			/// <para>Categorical difference—The difference between two categorical or thematic rasters will be calculated. The output will contain class transitions that occurred between the two rasters.</para>
			/// </summary>
			[GPValue("CATEGORICAL_DIFFERENCE")]
			[Description("Categorical difference")]
			Categorical_difference,

			/// <summary>
			/// <para>Spectral Euclidean distance—The Euclidean distance between the pixel values of two multiband rasters will be calculated.</para>
			/// </summary>
			[GPValue("SPECTRAL_EUCLIDEAN_DISTANCE")]
			[Description("Spectral Euclidean distance")]
			Spectral_Euclidean_distance,

			/// <summary>
			/// <para>Spectral angle difference—The spectral angle between the pixel values of two multiband rasters will be calculated. The output is in radians.</para>
			/// </summary>
			[GPValue("SPECTRAL_ANGLE_DIFFERENCE")]
			[Description("Spectral angle difference")]
			Spectral_angle_difference,

			/// <summary>
			/// <para>Band with most change—The band that accounts for the most change in each pixel between two multiband rasters will be calculated.</para>
			/// </summary>
			[GPValue("BAND_WITH_MOST_CHANGE")]
			[Description("Band with most change")]
			Band_with_most_change,

		}

		/// <summary>
		/// <para>Filter Method</para>
		/// </summary>
		public enum FilterMethodEnum 
		{
			/// <summary>
			/// <para>All pixels—All pixels will be categorized in the output. This is the default.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All pixels")]
			All_pixels,

			/// <summary>
			/// <para>Changed pixels only—Only the pixels that changed categories will be categorized in the output. Pixels that did not change categories will be grouped in a class called Other.</para>
			/// </summary>
			[GPValue("CHANGED_PIXELS_ONLY")]
			[Description("Changed pixels only")]
			Changed_pixels_only,

			/// <summary>
			/// <para>Unchanged pixels only—Only the pixels that did not change categories will be categorized in the output. Pixels that changed categories will be grouped in a class called Other.</para>
			/// </summary>
			[GPValue("UNCHANGED_PIXELS_ONLY")]
			[Description("Unchanged pixels only")]
			Unchanged_pixels_only,

		}

		/// <summary>
		/// <para>Transition Class Colors</para>
		/// </summary>
		public enum DefineTransitionColorsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("AVERAGE")]
			[Description("Average From and To colors")]
			Average_From_and_To_colors,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("FROM_COLOR")]
			[Description("From color")]
			From_color,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("TO_COLOR")]
			[Description("To color")]
			To_color,

		}

#endregion
	}
}
