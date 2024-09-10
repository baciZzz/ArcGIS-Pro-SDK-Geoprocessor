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
	/// <para>DEM to Raster</para>
	/// <para>Converts a digital elevation model (DEM) in a United States Geological Survey (USGS) format to a raster dataset.</para>
	/// </summary>
	[Obsolete()]
	public class DEMToRaster : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDemFile">
		/// <para>Input USGS DEM file</para>
		/// <para>The input USGS DEM file. The DEM must be standard USGS 7.5 minute, 1 degree, or any other file in the USGS DEM format. The DEM may be in either fixed or variable record-length format.</para>
		/// </param>
		/// <param name="OutRaster">
		/// <para>Output raster</para>
		/// <para>The output raster dataset to be created.</para>
		/// <para>If the output raster will not be saved to a geodatabase, specify .tif for TIFF file format, .CRF for CRF file format, .img for ERDAS IMAGINE file format, or no extension for Esri Grid raster format.</para>
		/// </param>
		public DEMToRaster(object InDemFile, object OutRaster)
		{
			this.InDemFile = InDemFile;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : DEM to Raster</para>
		/// </summary>
		public override string DisplayName() => "DEM to Raster";

		/// <summary>
		/// <para>Tool Name : DEMToRaster</para>
		/// </summary>
		public override string ToolName() => "DEMToRaster";

		/// <summary>
		/// <para>Tool Excute Name : conversion.DEMToRaster</para>
		/// </summary>
		public override string ExcuteName() => "conversion.DEMToRaster";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "cellSizeProjectionMethod", "compression", "configKeyword", "extent", "pyramid", "rasterStatistics", "scratchWorkspace", "tileSize" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDemFile, OutRaster, DataType, ZFactor };

		/// <summary>
		/// <para>Input USGS DEM file</para>
		/// <para>The input USGS DEM file. The DEM must be standard USGS 7.5 minute, 1 degree, or any other file in the USGS DEM format. The DEM may be in either fixed or variable record-length format.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("DEM", "TXT", "ASC")]
		public object InDemFile { get; set; }

		/// <summary>
		/// <para>Output raster</para>
		/// <para>The output raster dataset to be created.</para>
		/// <para>If the output raster will not be saved to a geodatabase, specify .tif for TIFF file format, .CRF for CRF file format, .img for ERDAS IMAGINE file format, or no extension for Esri Grid raster format.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object OutRaster { get; set; }

		/// <summary>
		/// <para>Output data type</para>
		/// <para>Data type of the output raster dataset.</para>
		/// <para>Integer—An integer raster dataset will be created.</para>
		/// <para>Float—A floating-point raster dataset will be created. This is the default.</para>
		/// <para><see cref="DataTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DataType { get; set; } = "FLOAT";

		/// <summary>
		/// <para>Z factor</para>
		/// <para>The number of ground x,y units in one surface z unit.</para>
		/// <para>The z-factor adjusts the units of measure for the z units when they are different from the x,y units of the input surface. The z-values of the input surface are multiplied by the z-factor when calculating the final output surface.</para>
		/// <para>If the x,y units and z units are in the same units of measure, the z-factor is 1. This is the default.</para>
		/// <para>If the x,y units and z units are in different units of measure, the z-factor must be set to the appropriate factor, or the results will be incorrect. For example, if your z units are feet and your x,y units are meters, you would use a z-factor of 0.3048 to convert your z units from feet to meters (1 foot = 0.3048 meter).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DEMToRaster SetEnviroment(int? autoCommit = null , object cellSize = null , object compression = null , object configKeyword = null , object extent = null , object pyramid = null , object rasterStatistics = null , object scratchWorkspace = null , double[] tileSize = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, compression: compression, configKeyword: configKeyword, extent: extent, pyramid: pyramid, rasterStatistics: rasterStatistics, scratchWorkspace: scratchWorkspace, tileSize: tileSize);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output data type</para>
		/// </summary>
		public enum DataTypeEnum 
		{
			/// <summary>
			/// <para>Float—A floating-point raster dataset will be created. This is the default.</para>
			/// </summary>
			[GPValue("FLOAT")]
			[Description("Float")]
			Float,

			/// <summary>
			/// <para>Integer—An integer raster dataset will be created.</para>
			/// </summary>
			[GPValue("INTEGER")]
			[Description("Integer")]
			Integer,

		}

#endregion
	}
}
