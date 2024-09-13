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
	/// <para>Linear Spectral Unmixing</para>
	/// <para>Linear Spectral Unmixing</para>
	/// <para>Performs subpixel classification and calculates the fractional abundance of different land cover types for individual pixels.</para>
	/// </summary>
	public class LinearSpectralUnmixing : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRaster">
		/// <para>Input Raster</para>
		/// <para>The input raster dataset.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster</para>
		/// <para>The output multiband raster dataset.</para>
		/// </param>
		/// <param name="InSpectralProfileFile">
		/// <para>Input Training Features or Spectral Profile</para>
		/// <para>The spectral information for the different land cover classes.</para>
		/// <para>This can be provided as polygon features, a training sample feature class generated from the Training Samples Manager, a classifier definition file (.ecd) generated from the Train Maximum Likelihood Classifier tool, or a JSON file (.json) that contains the class spectral profiles.</para>
		/// </param>
		public LinearSpectralUnmixing(object InRaster, object OutRaster, object InSpectralProfileFile)
		{
			this.InRaster = InRaster;
			this.OutRaster = OutRaster;
			this.InSpectralProfileFile = InSpectralProfileFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Linear Spectral Unmixing</para>
		/// </summary>
		public override string DisplayName() => "Linear Spectral Unmixing";

		/// <summary>
		/// <para>Tool Name : LinearSpectralUnmixing</para>
		/// </summary>
		public override string ToolName() => "LinearSpectralUnmixing";

		/// <summary>
		/// <para>Tool Excute Name : ia.LinearSpectralUnmixing</para>
		/// </summary>
		public override string ExcuteName() => "ia.LinearSpectralUnmixing";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise() => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InRaster, OutRaster, InSpectralProfileFile, ValueOption! };

		/// <summary>
		/// <para>Input Raster</para>
		/// <para>The input raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRaster { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>The output multiband raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Input Training Features or Spectral Profile</para>
		/// <para>The spectral information for the different land cover classes.</para>
		/// <para>This can be provided as polygon features, a training sample feature class generated from the Training Samples Manager, a classifier definition file (.ecd) generated from the Train Maximum Likelihood Classifier tool, or a JSON file (.json) that contains the class spectral profiles.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InSpectralProfileFile { get; set; }

		/// <summary>
		/// <para>Output Value Option</para>
		/// <para>Specifies how the output pixel values will be defined.</para>
		/// <para>Sum to one—Class values for each pixel will be provided in decimal format with the sum of all classes equal to 1. For example, Class1 = 0.16; Class2 = 0.24; Class3 = 0.60.</para>
		/// <para>Non-negative—There will be no negative output values.</para>
		/// <para><see cref="ValueOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object? ValueOption { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LinearSpectralUnmixing SetEnviroment(object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Value Option</para>
		/// </summary>
		public enum ValueOptionEnum 
		{
			/// <summary>
			/// <para>Sum to one—Class values for each pixel will be provided in decimal format with the sum of all classes equal to 1. For example, Class1 = 0.16; Class2 = 0.24; Class3 = 0.60.</para>
			/// </summary>
			[GPValue("SUM_TO_ONE")]
			[Description("Sum to one")]
			Sum_to_one,

			/// <summary>
			/// <para>Non-negative—There will be no negative output values.</para>
			/// </summary>
			[GPValue("NON_NEGATIVE")]
			[Description("Non-negative")]
			NON_NEGATIVE,

		}

#endregion
	}
}
