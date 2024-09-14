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
	/// <para>Multidimensional Principal Components</para>
	/// <para>Multidimensional Principal Components</para>
	/// <para>Transforms multidimensional rasters into  their principal components, loadings, and eigenvalues. The tool transforms the data into a reduced number of components that account for the variance of the data, so that spatial and temporal patterns can be readily identified.</para>
	/// </summary>
	public class MultidimensionalPrincipalComponents : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMultidimensionalRaster">
		/// <para>Input Multidimensional Raster</para>
		/// <para>The input multidimensional raster.</para>
		/// <para>The tool processes data along one dimension, such as a time series raster or a data cube defined by a nontime dimension [X, Y, Z]. If an input variable includes multiple dimensions, such as depth and time, the first dimension value will be used by default.</para>
		/// <para>You can use the Make Multidimensional Raster Layer tool or Subset Multidimensional Raster tool to redefine the multidimensional data as needed, such as configuring multidimensional data into a dataset with one dimension.</para>
		/// </param>
		/// <param name="Mode">
		/// <para>Mode</para>
		/// <para>Specifies the method that will be used to perform principal component analysis.</para>
		/// <para>Dimension Reduction—The input time series data will be treated as a set of images. Principal components that extract prevalent pattens over time will be computed. This is the default.</para>
		/// <para>Spatial Reduction—The input time series data will be treated as a set of pixels. Principal components that extract prevalent pattens and locations over time will be computed as a set of one-dimensional arrays stored in a table.</para>
		/// <para><see cref="ModeEnum"/></para>
		/// </param>
		/// <param name="Dimension">
		/// <para>Dimension</para>
		/// <para>The dimension name used to process the principal components.</para>
		/// </param>
		/// <param name="OutPc">
		/// <para>Output Principal Components</para>
		/// <para>The name of the output raster dataset.</para>
		/// <para>When the Mode parameter is specified as Dimension Reduction, the output will be a multiband raster with the components as bands. The first band is the first principal component with the largest eigenvalue, the second band has the principal component with the second largest eigenvalue, and so on. The output is in CRF file format (.crf), which maintains the multidimensional information.</para>
		/// <para>When the Mode parameter is specified as Spatial Reduction, the output is a table containing a set of time series data representing the principal components.</para>
		/// </param>
		/// <param name="OutLoadings">
		/// <para>Output Loadings</para>
		/// <para>The output loadings data contributing to the principal components.</para>
		/// <para>When the Mode parameter is specified as Dimension Reduction, the output will be a table containing the weights that each input raster contributed to the principal components. These weights define the correlations of the input data and the output principal components. Use the .csv file extension to output the loadings as a comma-separated values file.</para>
		/// <para>When the Mode parameter is specified as Spatial Reduction, the output is a raster where pixel values are the weights contributing the principal components. Pixels with larger values are more corelated to the principal components. This output may have a larger cell size than the input raster because a random reprojection is applied to reduce the computation complexity.</para>
		/// <para>The output loadings data contributing to the principal components.</para>
		/// <para>When the mode parameter is specified as DIMENSION_REDUCTION, the output will be a table containing the weights that each input raster contributed to the principal components. These weights define the correlations of the input data and the output principal components. Use the .csv file extension to output the loadings as a comma-separated values file.</para>
		/// <para>When the mode parameter is specified as SPATIAL_REDUCTION, the output is a raster where pixel values are the weights contributing the principal components. Pixels with larger values are more corelated to the principal components. This output may have a larger cell size than the input raster because a random reprojection is applied to reduce the computation complexity.</para>
		/// </param>
		public MultidimensionalPrincipalComponents(object InMultidimensionalRaster, object Mode, object Dimension, object OutPc, object OutLoadings)
		{
			this.InMultidimensionalRaster = InMultidimensionalRaster;
			this.Mode = Mode;
			this.Dimension = Dimension;
			this.OutPc = OutPc;
			this.OutLoadings = OutLoadings;
		}

		/// <summary>
		/// <para>Tool Display Name : Multidimensional Principal Components</para>
		/// </summary>
		public override string DisplayName() => "Multidimensional Principal Components";

		/// <summary>
		/// <para>Tool Name : MultidimensionalPrincipalComponents</para>
		/// </summary>
		public override string ToolName() => "MultidimensionalPrincipalComponents";

		/// <summary>
		/// <para>Tool Excute Name : ia.MultidimensionalPrincipalComponents</para>
		/// </summary>
		public override string ExcuteName() => "ia.MultidimensionalPrincipalComponents";

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
		public override object[] Parameters() => new object[] { InMultidimensionalRaster, Mode, Dimension, OutPc, OutLoadings, OutEigenvalues!, Variable!, NumberOfPc! };

		/// <summary>
		/// <para>Input Multidimensional Raster</para>
		/// <para>The input multidimensional raster.</para>
		/// <para>The tool processes data along one dimension, such as a time series raster or a data cube defined by a nontime dimension [X, Y, Z]. If an input variable includes multiple dimensions, such as depth and time, the first dimension value will be used by default.</para>
		/// <para>You can use the Make Multidimensional Raster Layer tool or Subset Multidimensional Raster tool to redefine the multidimensional data as needed, such as configuring multidimensional data into a dataset with one dimension.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Mode</para>
		/// <para>Specifies the method that will be used to perform principal component analysis.</para>
		/// <para>Dimension Reduction—The input time series data will be treated as a set of images. Principal components that extract prevalent pattens over time will be computed. This is the default.</para>
		/// <para>Spatial Reduction—The input time series data will be treated as a set of pixels. Principal components that extract prevalent pattens and locations over time will be computed as a set of one-dimensional arrays stored in a table.</para>
		/// <para><see cref="ModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Mode { get; set; } = "DIMENSION_REDUCTION";

		/// <summary>
		/// <para>Dimension</para>
		/// <para>The dimension name used to process the principal components.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Dimension { get; set; }

		/// <summary>
		/// <para>Output Principal Components</para>
		/// <para>The name of the output raster dataset.</para>
		/// <para>When the Mode parameter is specified as Dimension Reduction, the output will be a multiband raster with the components as bands. The first band is the first principal component with the largest eigenvalue, the second band has the principal component with the second largest eigenvalue, and so on. The output is in CRF file format (.crf), which maintains the multidimensional information.</para>
		/// <para>When the Mode parameter is specified as Spatial Reduction, the output is a table containing a set of time series data representing the principal components.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutPc { get; set; }

		/// <summary>
		/// <para>Output Loadings</para>
		/// <para>The output loadings data contributing to the principal components.</para>
		/// <para>When the Mode parameter is specified as Dimension Reduction, the output will be a table containing the weights that each input raster contributed to the principal components. These weights define the correlations of the input data and the output principal components. Use the .csv file extension to output the loadings as a comma-separated values file.</para>
		/// <para>When the Mode parameter is specified as Spatial Reduction, the output is a raster where pixel values are the weights contributing the principal components. Pixels with larger values are more corelated to the principal components. This output may have a larger cell size than the input raster because a random reprojection is applied to reduce the computation complexity.</para>
		/// <para>The output loadings data contributing to the principal components.</para>
		/// <para>When the mode parameter is specified as DIMENSION_REDUCTION, the output will be a table containing the weights that each input raster contributed to the principal components. These weights define the correlations of the input data and the output principal components. Use the .csv file extension to output the loadings as a comma-separated values file.</para>
		/// <para>When the mode parameter is specified as SPATIAL_REDUCTION, the output is a raster where pixel values are the weights contributing the principal components. Pixels with larger values are more corelated to the principal components. This output may have a larger cell size than the input raster because a random reprojection is applied to reduce the computation complexity.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutLoadings { get; set; }

		/// <summary>
		/// <para>Output Eigenvalues</para>
		/// <para>The output Eigenvalues table. Eigenvalues are values indicating the variance percentage of each component. Eigenvalues help you define the number of principal components that are needed to represent the dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutEigenvalues { get; set; }

		/// <summary>
		/// <para>Variable</para>
		/// <para>The variable of the input multidimensional raster used in computation. If the input raster is multidimensional and no variable is specified, only the first variable will be analyzed, by default.</para>
		/// <para>For example, to find the years in which temperature values were highest, specify temperature as the variable to be analyzed. If you do not specify any variables and you have both temperature and precipitation variables, both variables will be analyzed, and the output multidimensional raster will include both variables.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Variable { get; set; }

		/// <summary>
		/// <para>Number of Principal Components</para>
		/// <para>The number of principal components to compute, usually fewer than the number of input rasters.</para>
		/// <para>This parameter also takes the form of a percentage (%). For example, a value of 90% means the number of components that can explain 90 percent of variance in the data will be computed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? NumberOfPc { get; set; } = "95%";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MultidimensionalPrincipalComponents SetEnviroment(object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? nodata = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? pyramid = null, object? rasterStatistics = null, object? resamplingMethod = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Mode</para>
		/// </summary>
		public enum ModeEnum 
		{
			/// <summary>
			/// <para>Dimension Reduction—The input time series data will be treated as a set of images. Principal components that extract prevalent pattens over time will be computed. This is the default.</para>
			/// </summary>
			[GPValue("DIMENSION_REDUCTION")]
			[Description("Dimension Reduction")]
			Dimension_Reduction,

			/// <summary>
			/// <para>Spatial Reduction—The input time series data will be treated as a set of pixels. Principal components that extract prevalent pattens and locations over time will be computed as a set of one-dimensional arrays stored in a table.</para>
			/// </summary>
			[GPValue("SPATIAL_REDUCTION")]
			[Description("Spatial Reduction")]
			Spatial_Reduction,

		}

#endregion
	}
}
