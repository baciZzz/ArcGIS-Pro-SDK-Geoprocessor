using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Terrain To Raster</para>
	/// <para>Interpolates a raster using z-values from  a terrain dataset.</para>
	/// </summary>
	public class TerrainToRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTerrain">
		/// <para>Input Terrain</para>
		/// <para>The terrain dataset to process.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster</para>
		/// <para>The location and name of the output raster. When storing a raster dataset in a geodatabase or in a folder such as an Esri Grid, do not add a file extension to the name of the raster dataset. A file extension can be provided to define the raster&apos;s format when storing it in a folder, such as .tif to generate a GeoTIFF or .img to generate an ERDAS IMAGINE format file.</para>
		/// <para>If the raster is stored as a TIFF file or in a geodatabase, its raster compression type and quality can be specified using geoprocessing environment settings.</para>
		/// </param>
		public TerrainToRaster(object InTerrain, object OutRaster)
		{
			this.InTerrain = InTerrain;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : Terrain To Raster</para>
		/// </summary>
		public override string DisplayName => "Terrain To Raster";

		/// <summary>
		/// <para>Tool Name : TerrainToRaster</para>
		/// </summary>
		public override string ToolName => "TerrainToRaster";

		/// <summary>
		/// <para>Tool Excute Name : 3d.TerrainToRaster</para>
		/// </summary>
		public override string ExcuteName => "3d.TerrainToRaster";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "autoCommit", "compression", "configKeyword", "extent", "outputCoordinateSystem", "pyramid", "rasterStatistics", "snapRaster", "terrainMemoryUsage", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTerrain, OutRaster, DataType, Method, SampleDistance, PyramidLevelResolution, SampleValue };

		/// <summary>
		/// <para>Input Terrain</para>
		/// <para>The terrain dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTerrainLayer()]
		public object InTerrain { get; set; }

		/// <summary>
		/// <para>Output Raster</para>
		/// <para>The location and name of the output raster. When storing a raster dataset in a geodatabase or in a folder such as an Esri Grid, do not add a file extension to the name of the raster dataset. A file extension can be provided to define the raster&apos;s format when storing it in a folder, such as .tif to generate a GeoTIFF or .img to generate an ERDAS IMAGINE format file.</para>
		/// <para>If the raster is stored as a TIFF file or in a geodatabase, its raster compression type and quality can be specified using geoprocessing environment settings.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

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
		/// <para>Method</para>
		/// <para>The interpolation method that will be used to calculate cell values.</para>
		/// <para>Linear—Applies a distance based weight to the Z of each node in the triangle encompassing the center of a given cell, then sums the weighted values to assign the cell value. This is the default.</para>
		/// <para>Natural Neighbors—Applies an area based weighting scheme that uses Voronoi polygons to determine cell values.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "LINEAR";

		/// <summary>
		/// <para>Sampling Distance</para>
		/// <para>The sampling method and distance used to define the cell size of the output raster.</para>
		/// <para>Observations—Defines the number of cells that divide the longest side of the output raster. This method is used by default with the value of 250.</para>
		/// <para>Cell Size—Defines the cell size of the output raster.</para>
		/// <para><see cref="SampleDistanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SampleDistance { get; set; } = "OBSERVATIONS";

		/// <summary>
		/// <para>Pyramid Level Resolution</para>
		/// <para>The z-tolerance or window-size resolution of the terrain pyramid level that will be used. The default is 0, or full resolution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object PyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Sampling Value</para>
		/// <para>The value that corresponds with the Sampling Distance for specifying the output raster's cell size.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object SampleValue { get; set; } = "250";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TerrainToRaster SetEnviroment(int? autoCommit = null , object compression = null , object configKeyword = null , object extent = null , object outputCoordinateSystem = null , object pyramid = null , object rasterStatistics = null , object snapRaster = null , object terrainMemoryUsage = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, compression: compression, configKeyword: configKeyword, extent: extent, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, rasterStatistics: rasterStatistics, snapRaster: snapRaster, terrainMemoryUsage: terrainMemoryUsage, workspace: workspace);
			return this;
		}

		#region InnerClass

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
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Linear—Applies a distance based weight to the Z of each node in the triangle encompassing the center of a given cell, then sums the weighted values to assign the cell value. This is the default.</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("Linear")]
			Linear,

			/// <summary>
			/// <para>Natural Neighbors—Applies an area based weighting scheme that uses Voronoi polygons to determine cell values.</para>
			/// </summary>
			[GPValue("NATURAL_NEIGHBORS")]
			[Description("Natural Neighbors")]
			Natural_Neighbors,

		}

		/// <summary>
		/// <para>Sampling Distance</para>
		/// </summary>
		public enum SampleDistanceEnum 
		{
			/// <summary>
			/// <para>Observations—Defines the number of cells that divide the longest side of the output raster. This method is used by default with the value of 250.</para>
			/// </summary>
			[GPValue("OBSERVATIONS")]
			[Description("Observations")]
			Observations,

			/// <summary>
			/// <para>Cell Size—Defines the cell size of the output raster.</para>
			/// </summary>
			[GPValue("CELLSIZE")]
			[Description("Cell Size")]
			Cell_Size,

		}

#endregion
	}
}
