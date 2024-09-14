using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.MultidimensionTools
{
	/// <summary>
	/// <para>Make Multidimensional Raster Layer</para>
	/// <para>Make Multidimensional Raster Layer</para>
	/// <para>Creates a raster layer from a multidimensional raster dataset or a multidimensional raster layer  by slicing data along defined variables and dimensions.</para>
	/// </summary>
	public class MakeMultidimensionalRasterLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMultidimensionalRaster">
		/// <para>Input Multidimensional Raster</para>
		/// <para>The input multidimensional raster dataset.</para>
		/// <para>Supported inputs are netCDF, GRIB, HDF, CRF, and Zarr files, a multidimensional mosaic dataset, a multidimensional image service, an OPeNDAP URL, or a multidimensional raster layer.A Zarr file must have an extension of .zarr and a .zgroup file in the folder.</para>
		/// </param>
		/// <param name="OutMultidimensionalRasterLayer">
		/// <para>Output Multidimensional Raster Layer</para>
		/// <para>The output multidimensional raster layer.</para>
		/// </param>
		public MakeMultidimensionalRasterLayer(object InMultidimensionalRaster, object OutMultidimensionalRasterLayer)
		{
			this.InMultidimensionalRaster = InMultidimensionalRaster;
			this.OutMultidimensionalRasterLayer = OutMultidimensionalRasterLayer;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Multidimensional Raster Layer</para>
		/// </summary>
		public override string DisplayName() => "Make Multidimensional Raster Layer";

		/// <summary>
		/// <para>Tool Name : MakeMultidimensionalRasterLayer</para>
		/// </summary>
		public override string ToolName() => "MakeMultidimensionalRasterLayer";

		/// <summary>
		/// <para>Tool Excute Name : md.MakeMultidimensionalRasterLayer</para>
		/// </summary>
		public override string ExcuteName() => "md.MakeMultidimensionalRasterLayer";

		/// <summary>
		/// <para>Toolbox Display Name : Multidimension Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Multidimension Tools";

		/// <summary>
		/// <para>Toolbox Alise : md</para>
		/// </summary>
		public override string ToolboxAlise() => "md";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cellSize", "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMultidimensionalRaster, OutMultidimensionalRasterLayer, Variables!, DimensionDef!, DimensionRanges!, DimensionValues!, Dimension!, StartOfFirstIteration!, EndOfFirstIteration!, IterationStep!, IterationUnit!, Template!, Dimensionless!, SpatialReference! };

		/// <summary>
		/// <para>Input Multidimensional Raster</para>
		/// <para>The input multidimensional raster dataset.</para>
		/// <para>Supported inputs are netCDF, GRIB, HDF, CRF, and Zarr files, a multidimensional mosaic dataset, a multidimensional image service, an OPeNDAP URL, or a multidimensional raster layer.A Zarr file must have an extension of .zarr and a .zgroup file in the folder.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Output Multidimensional Raster Layer</para>
		/// <para>The output multidimensional raster layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object OutMultidimensionalRasterLayer { get; set; }

		/// <summary>
		/// <para>Variables</para>
		/// <para>The variables that will be included in the output multidimensional raster layer. If no variable is specified, the first variable will be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? Variables { get; set; }

		/// <summary>
		/// <para>Dimension Definition</para>
		/// <para>Specifies the method that will be used to slice the dimension.</para>
		/// <para>All—The full range for each dimension will be used. This is the default.</para>
		/// <para>By Ranges—The dimension will be sliced using a range or a list of ranges.</para>
		/// <para>By Iteration—The dimension will be sliced over a specified interval size.</para>
		/// <para>By Values—The dimension will be sliced using a list of dimension values.</para>
		/// <para><see cref="DimensionDefEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DimensionDef { get; set; } = "ALL";

		/// <summary>
		/// <para>Range</para>
		/// <para>The range or list of ranges for the specified dimension.</para>
		/// <para>The data will be sliced based on the dimension name and the minimum and maximum values for the range. This parameter is required when the Dimension Definition parameter is set to By Ranges.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? DimensionRanges { get; set; }

		/// <summary>
		/// <para>Values</para>
		/// <para>A list of values for the specified dimension. This parameter is required when the Dimension Definition parameter is set to By Values.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? DimensionValues { get; set; }

		/// <summary>
		/// <para>Dimension</para>
		/// <para>The dimension along which the variables will be sliced. This parameter is required when the Dimension Definition parameter is set to By Iteration.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? Dimension { get; set; }

		/// <summary>
		/// <para>Start of first iteration</para>
		/// <para>The beginning of the first interval. This interval will be used to iterate through the dataset. This parameter is required when the Dimension Definition parameter is set to By Iteration.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? StartOfFirstIteration { get; set; }

		/// <summary>
		/// <para>End of first iteration</para>
		/// <para>The end of the first interval. This interval will be used to iterate through the dataset. This parameter is required when the Dimension Definition parameter is set to By Iteration.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? EndOfFirstIteration { get; set; }

		/// <summary>
		/// <para>Step</para>
		/// <para>The frequency with which the data will be sliced. This parameter is required when the Dimension Definition parameter is set to By Iteration.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? IterationStep { get; set; }

		/// <summary>
		/// <para>Unit</para>
		/// <para>Specifies the iteration unit that will be used. This parameter is required when the Dimension Definition parameter is set to By Iteration and the Dimension parameter is set to StdTime.</para>
		/// <para><see cref="IterationUnitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? IterationUnit { get; set; }

		/// <summary>
		/// <para>Extent</para>
		/// <para>The extent (bounding box) of the layer. Choose the appropriate Extent option for the layer.</para>
		/// <para>Default—The extent will be based on the maximum extent of all participating inputs. This is the default.</para>
		/// <para>Current Display Extent—The extent is equal to the data frame or visible display. The option is not available when there is no active map.</para>
		/// <para>As Specified Below—The extent will be based on the minimum and maximum extent values specified.</para>
		/// <para>Browse—The extent will be based on an existing dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		public object? Template { get; set; }

		/// <summary>
		/// <para>Dimensionless</para>
		/// <para>Specifies whether the layer will have dimension values. This parameter is only active if a single slice is selected to create a layer.</para>
		/// <para>Checked—The layer will not have dimension values.</para>
		/// <para>Unchecked—The layer will have dimension values. This is the default.</para>
		/// <para><see cref="DimensionlessEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Dimensionless { get; set; } = "false";

		/// <summary>
		/// <para>Spatial Reference</para>
		/// <para>The coordinate system for the Output Multidimensional Raster Layer parameter value. This parameter only applies when the Input Multidimensional Raster parameter value is in Zarr format. Use this parameter to define the spatial reference if it is missing in the data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		[Category("Interpolate irregular data")]
		public object? SpatialReference { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MakeMultidimensionalRasterLayer SetEnviroment(object? cellSize = null, object? compression = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? nodata = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? rasterStatistics = null, object? resamplingMethod = null, object? scratchWorkspace = null, object? snapRaster = null, object? tileSize = null, object? workspace = null)
		{
			base.SetEnv(cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Dimension Definition</para>
		/// </summary>
		public enum DimensionDefEnum 
		{
			/// <summary>
			/// <para>All—The full range for each dimension will be used. This is the default.</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("All")]
			All,

			/// <summary>
			/// <para>By Values—The dimension will be sliced using a list of dimension values.</para>
			/// </summary>
			[GPValue("BY_VALUE")]
			[Description("By Values")]
			By_Values,

			/// <summary>
			/// <para>By Ranges—The dimension will be sliced using a range or a list of ranges.</para>
			/// </summary>
			[GPValue("BY_RANGES")]
			[Description("By Ranges")]
			By_Ranges,

			/// <summary>
			/// <para>By Iteration—The dimension will be sliced over a specified interval size.</para>
			/// </summary>
			[GPValue("BY_ITERATION")]
			[Description("By Iteration")]
			By_Iteration,

		}

		/// <summary>
		/// <para>Unit</para>
		/// </summary>
		public enum IterationUnitEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("HOURS")]
			[Description("Hours")]
			Hours,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("DAYS")]
			[Description("Days")]
			Days,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("WEEKS")]
			[Description("Weeks")]
			Weeks,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("MONTHS")]
			[Description("Months")]
			Months,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("YEARS")]
			[Description("Years")]
			Years,

		}

		/// <summary>
		/// <para>Dimensionless</para>
		/// </summary>
		public enum DimensionlessEnum 
		{
			/// <summary>
			/// <para>Checked—The layer will not have dimension values.</para>
			/// </summary>
			[GPValue("true")]
			[Description("NO_DIMENSIONS")]
			NO_DIMENSIONS,

			/// <summary>
			/// <para>Unchecked—The layer will have dimension values. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("DIMENSIONS")]
			DIMENSIONS,

		}

#endregion
	}
}
