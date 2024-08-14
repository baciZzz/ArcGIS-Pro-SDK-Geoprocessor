using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>LAS Dataset To Raster</para>
	/// <para>Creates  a raster using elevation, intensity,  or RGB values stored in the lidar points referenced by the LAS dataset.</para>
	/// </summary>
	public class LasDatasetToRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster</para>
		/// <para>The location and name of the output raster. When storing a raster dataset in a geodatabase or in a folder such as an Esri Grid, do not add a file extension to the name of the raster dataset. A file extension can be provided to define the raster&apos;s format when storing it in a folder, such as .tif to generate a GeoTIFF or .img to generate an ERDAS IMAGINE format file.</para>
		/// <para>If the raster is stored as a TIFF file or in a geodatabase, its raster compression type and quality can be specified using geoprocessing environment settings.</para>
		/// </param>
		public LasDatasetToRaster(object InLasDataset, object OutRaster)
		{
			this.InLasDataset = InLasDataset;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : LAS Dataset To Raster</para>
		/// </summary>
		public override string DisplayName => "LAS Dataset To Raster";

		/// <summary>
		/// <para>Tool Name : LasDatasetToRaster</para>
		/// </summary>
		public override string ToolName => "LasDatasetToRaster";

		/// <summary>
		/// <para>Tool Excute Name : conversion.LasDatasetToRaster</para>
		/// </summary>
		public override string ExcuteName => "conversion.LasDatasetToRaster";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "autoCommit", "cellSize", "compression", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "pyramid", "rasterStatistics", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InLasDataset, OutRaster, ValueField, InterpolationType, DataType, SamplingType, SamplingValue, ZFactor };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>The LAS dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>The location and name of the output raster. When storing a raster dataset in a geodatabase or in a folder such as an Esri Grid, do not add a file extension to the name of the raster dataset. A file extension can be provided to define the raster&apos;s format when storing it in a folder, such as .tif to generate a GeoTIFF or .img to generate an ERDAS IMAGINE format file.</para>
		/// <para>If the raster is stored as a TIFF file or in a geodatabase, its raster compression type and quality can be specified using geoprocessing environment settings.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Value Field</para>
		/// <para>The lidar data that will be used to generate the raster output.</para>
		/// <para>Elevation—Elevation from the lidar files will be used to create the raster. This is the default.</para>
		/// <para>Intensity—Intensity information from the lidar files will be used to create the raster.</para>
		/// <para>RGB—RGB values from the lidar points will be used to create 3-band imagery.</para>
		/// <para><see cref="ValueFieldEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ValueField { get; set; } = "ELEVATION";

		/// <summary>
		/// <para>Interpolation Type</para>
		/// <para>The interpolation technique that will be used to determine the cell values of the output raster.</para>
		/// <para>The binning approach provides a Cell Assignment Method for determining each output cell using the points that fall within its extent, along with a Void Fill Method to determine the value of cells that do not contain any LAS points.</para>
		/// <para><bold>Cell Assignment Methods</bold></para>
		/// <para>AVERAGE—Assigns the average value of all points in the cell. This is the default.</para>
		/// <para>MINIMUM—Assigns the minimum value found in the points within the cell.</para>
		/// <para>MAXIMUM—Assigns the maximum value found in the points within the cell.</para>
		/// <para>IDW—Uses Inverse Distance Weighted interpolation to determine the cell value.</para>
		/// <para>NEAREST—Uses Nearest Neighbor assignment to determine the cell value.</para>
		/// <para><bold>Void Fill Methods</bold></para>
		/// <para>NONE—NoData is assigned to the cell.</para>
		/// <para>SIMPLE—Averages the values from data cells immediately surrounding a NoData cell to eliminate small voids.</para>
		/// <para>LINEAR—Triangulates across void areas and uses linear interpolation on the triangulated value to determine the cell value. This is the default.</para>
		/// <para>NATURAL_NEIGHBOR—Uses natural neighbor interpolation to determine the cell value.</para>
		/// <para>The Triangulation interpolation methods derive cell values using a TIN based approach while also offering the opportunity to speed up processing time by thinning the sampling of LAS data using the Window Size technique.</para>
		/// <para><bold>Triangulation Methods</bold></para>
		/// <para>Linear—Uses linear interpolation to determine cell values.</para>
		/// <para>Natural Neighbors—Uses natural neighbor interpolation to determine cell value.</para>
		/// <para><bold>Window Size Selection Methods</bold></para>
		/// <para>Maximum—The point with the highest value in each window size is maintained. This is the default.</para>
		/// <para>Minimum—The point with the lowest value in each window size is maintained.</para>
		/// <para>Closest To Mean—The point whose value is closest to the average of all point values in the window size is maintained.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GP3DAInterpolate()]
		public object InterpolationType { get; set; } = "BINNING AVERAGE LINEAR";

		/// <summary>
		/// <para>Output Data Type</para>
		/// <para>Specifies the type of numeric values stored in the output raster.</para>
		/// <para>Floating Point—The output raster will use 32-bit floating point, which supports values ranging from -3.402823466e+38 to 3.402823466e+38. This is the default.</para>
		/// <para>Integer—The output raster will use an appropriate integer bit depth. This option will round z-values to the nearest whole number and write an integer to each raster cell value.</para>
		/// <para><see cref="DataTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DataType { get; set; } = "FLOAT";

		/// <summary>
		/// <para>Sampling Type</para>
		/// <para>Specifies the method that will be used for interpreting the Sampling Value parameter value to define the resolution of the output raster.</para>
		/// <para>Observations—The number of cells that divide the lengthiest side of the LAS dataset extent will be used.</para>
		/// <para>Cell Size—The cell size of the output raster will be used. This is the default.</para>
		/// <para><see cref="SamplingTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SamplingType { get; set; } = "CELLSIZE";

		/// <summary>
		/// <para>Sampling Value</para>
		/// <para>The value used in conjunction with the Sampling Type parameter to define the resolution of the output raster.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object SamplingValue { get; set; } = "10";

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>The factor by which z-values will be multiplied. This is typically used to convert z linear units to match x,y linear units. The default is 1, which leaves elevation values unchanged. This parameter is not available if the spatial reference of the input surface has a z datum with a specified linear unit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LasDatasetToRaster SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object pyramid = null , object rasterStatistics = null , object snapRaster = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, rasterStatistics: rasterStatistics, snapRaster: snapRaster, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Value Field</para>
		/// </summary>
		public enum ValueFieldEnum 
		{
			/// <summary>
			/// <para>Elevation—Elevation from the lidar files will be used to create the raster. This is the default.</para>
			/// </summary>
			[GPValue("ELEVATION")]
			[Description("Elevation")]
			Elevation,

			/// <summary>
			/// <para>Intensity—Intensity information from the lidar files will be used to create the raster.</para>
			/// </summary>
			[GPValue("INTENSITY")]
			[Description("Intensity")]
			Intensity,

			/// <summary>
			/// <para>RGB—RGB values from the lidar points will be used to create 3-band imagery.</para>
			/// </summary>
			[GPValue("RGB")]
			[Description("RGB")]
			RGB,

		}

		/// <summary>
		/// <para>Output Data Type</para>
		/// </summary>
		public enum DataTypeEnum 
		{
			/// <summary>
			/// <para>Floating Point—The output raster will use 32-bit floating point, which supports values ranging from -3.402823466e+38 to 3.402823466e+38. This is the default.</para>
			/// </summary>
			[GPValue("FLOAT")]
			[Description("Floating Point")]
			Floating_Point,

			/// <summary>
			/// <para>Integer—The output raster will use an appropriate integer bit depth. This option will round z-values to the nearest whole number and write an integer to each raster cell value.</para>
			/// </summary>
			[GPValue("INT")]
			[Description("Integer")]
			Integer,

		}

		/// <summary>
		/// <para>Sampling Type</para>
		/// </summary>
		public enum SamplingTypeEnum 
		{
			/// <summary>
			/// <para>Observations—The number of cells that divide the lengthiest side of the LAS dataset extent will be used.</para>
			/// </summary>
			[GPValue("OBSERVATIONS")]
			[Description("Observations")]
			Observations,

			/// <summary>
			/// <para>Cell Size—The cell size of the output raster will be used. This is the default.</para>
			/// </summary>
			[GPValue("CELLSIZE")]
			[Description("Cell Size")]
			Cell_Size,

		}

#endregion
	}
}
