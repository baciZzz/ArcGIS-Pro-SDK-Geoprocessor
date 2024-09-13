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
	/// <para>Subset Multidimensional Raster</para>
	/// <para>Subset Multidimensional Raster</para>
	/// <para>Creates a subset of a multidimensional raster by slicing data along defined variables and dimensions.</para>
	/// </summary>
	public class SubsetMultidimensionalRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMultidimensionalRaster">
		/// <para>Input Multidimensional Raster</para>
		/// <para>The input multidimensional raster dataset.</para>
		/// <para>Supported inputs include netCDF, GRIB, HDF or CRF files, a multidimensional mosaic dataset, or a multidimensional raster layer.</para>
		/// </param>
		/// <param name="OutMultidimensionalRaster">
		/// <para>Output Multidimensional Raster</para>
		/// <para>The output multidimensional raster dataset.</para>
		/// </param>
		public SubsetMultidimensionalRaster(object InMultidimensionalRaster, object OutMultidimensionalRaster)
		{
			this.InMultidimensionalRaster = InMultidimensionalRaster;
			this.OutMultidimensionalRaster = OutMultidimensionalRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Subset Multidimensional Raster</para>
		/// </summary>
		public override string DisplayName() => "Subset Multidimensional Raster";

		/// <summary>
		/// <para>Tool Name : SubsetMultidimensionalRaster</para>
		/// </summary>
		public override string ToolName() => "SubsetMultidimensionalRaster";

		/// <summary>
		/// <para>Tool Excute Name : md.SubsetMultidimensionalRaster</para>
		/// </summary>
		public override string ExcuteName() => "md.SubsetMultidimensionalRaster";

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
		public override string[] ValidEnvironments() => new string[] { "cellSize", "compression", "configKeyword", "extent", "geographicTransformations", "nodata", "outputCoordinateSystem", "parallelProcessingFactor", "pyramid", "rasterStatistics", "resamplingMethod", "scratchWorkspace", "snapRaster", "tileSize", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMultidimensionalRaster, OutMultidimensionalRaster, Variables!, DimensionDef!, DimensionRanges!, DimensionValues!, Dimension!, StartOfFirstIteration!, EndOfFirstIteration!, IterationStep!, IterationUnit! };

		/// <summary>
		/// <para>Input Multidimensional Raster</para>
		/// <para>The input multidimensional raster dataset.</para>
		/// <para>Supported inputs include netCDF, GRIB, HDF or CRF files, a multidimensional mosaic dataset, or a multidimensional raster layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Output Multidimensional Raster</para>
		/// <para>The output multidimensional raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutMultidimensionalRaster { get; set; }

		/// <summary>
		/// <para>Variables</para>
		/// <para>The variables that will be included in the output multidimensional raster. If no variable is specified, all of the variables will be used.</para>
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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SubsetMultidimensionalRaster SetEnviroment(object? cellSize = null , object? compression = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? nodata = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? pyramid = null , object? rasterStatistics = null , object? resamplingMethod = null , object? scratchWorkspace = null , object? snapRaster = null , object? tileSize = null , object? workspace = null )
		{
			base.SetEnv(cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, nodata: nodata, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics, resamplingMethod: resamplingMethod, scratchWorkspace: scratchWorkspace, snapRaster: snapRaster, tileSize: tileSize, workspace: workspace);
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

#endregion
	}
}
