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
	/// <para>TIN To Raster</para>
	/// <para>Interpolates a raster using z-values from the input TIN.</para>
	/// </summary>
	public class TinRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTin">
		/// <para>Input TIN</para>
		/// <para>The TIN dataset to process.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output Raster</para>
		/// <para>The location and name of the output raster. When storing a raster dataset in a geodatabase or in a folder such as an Esri Grid, do not add a file extension to the name of the raster dataset. A file extension can be provided to define the raster&apos;s format when storing it in a folder, such as .tif to generate a GeoTIFF or .img to generate an ERDAS IMAGINE format file.</para>
		/// <para>If the raster is stored as a TIFF file or in a geodatabase, its raster compression type and quality can be specified using geoprocessing environment settings.</para>
		/// </param>
		public TinRaster(object InTin, object OutRaster)
		{
			this.InTin = InTin;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : TIN To Raster</para>
		/// </summary>
		public override string DisplayName => "TIN To Raster";

		/// <summary>
		/// <para>Tool Name : TinRaster</para>
		/// </summary>
		public override string ToolName => "TinRaster";

		/// <summary>
		/// <para>Tool Excute Name : 3d.TinRaster</para>
		/// </summary>
		public override string ExcuteName => "3d.TinRaster";

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
		public override string[] ValidEnvironments => new string[] { "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "pyramid", "rasterStatistics", "snapRaster", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTin, OutRaster, DataType, Method, SampleDistance, ZFactor, SampleValue };

		/// <summary>
		/// <para>Input TIN</para>
		/// <para>The TIN dataset to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InTin { get; set; }

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
		/// <para>The interpolation method used to create the raster.</para>
		/// <para>Linear—Calculates cell values by applying linear interpolation to the TIN triangles. This is the default.</para>
		/// <para>Natural Neighbors—Calculates cell values by using natural neighbors interpolation of TIN triangles</para>
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
		/// <para>Z Factor</para>
		/// <para>The factor by which z-values will be multiplied. This is typically used to convert z linear units to match x,y linear units. The default is 1, which leaves elevation values unchanged. This parameter is not available if the spatial reference of the input surface has a z datum with a specified linear unit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ZFactor { get; set; } = "1";

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
		public TinRaster SetEnviroment(int? autoCommit = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object pyramid = null , object rasterStatistics = null , object snapRaster = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, rasterStatistics: rasterStatistics, snapRaster: snapRaster, workspace: workspace);
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
			/// <para>Linear—Calculates cell values by applying linear interpolation to the TIN triangles. This is the default.</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("Linear")]
			Linear,

			/// <summary>
			/// <para>Natural Neighbors—Calculates cell values by using natural neighbors interpolation of TIN triangles</para>
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
