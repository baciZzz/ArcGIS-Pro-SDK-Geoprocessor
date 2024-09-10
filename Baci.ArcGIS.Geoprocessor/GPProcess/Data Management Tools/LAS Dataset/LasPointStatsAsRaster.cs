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
	/// <para>LAS Point Statistics As Raster</para>
	/// <para>Creates a raster whose cell values reflect statistical information about measurements from LAS files referenced by a LAS dataset.</para>
	/// </summary>
	public class LasPointStatsAsRaster : AbstractGPProcess
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
		public LasPointStatsAsRaster(object InLasDataset, object OutRaster)
		{
			this.InLasDataset = InLasDataset;
			this.OutRaster = OutRaster;
		}

		/// <summary>
		/// <para>Tool Display Name : LAS Point Statistics As Raster</para>
		/// </summary>
		public override string DisplayName() => "LAS Point Statistics As Raster";

		/// <summary>
		/// <para>Tool Name : LasPointStatsAsRaster</para>
		/// </summary>
		public override string ToolName() => "LasPointStatsAsRaster";

		/// <summary>
		/// <para>Tool Excute Name : management.LasPointStatsAsRaster</para>
		/// </summary>
		public override string ExcuteName() => "management.LasPointStatsAsRaster";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "cellSize", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "pyramid", "rasterStatistics", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, OutRaster, Method, SamplingType, SamplingValue };

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
		/// <para>Method</para>
		/// <para>The type of statistics collected about the LAS points in each cell of the output raster.</para>
		/// <para>Pulse Count—The number of last return points.</para>
		/// <para>Point Count—The number of points from all returns.</para>
		/// <para>Most Frequent Last Return—The most frequent last return value.</para>
		/// <para>Most Frequent Class Code—The most frequent class code.</para>
		/// <para>Range of Intensity Values—The range of intensity values.</para>
		/// <para>Range of Elevation Values—The range of elevation values.</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "PULSE_COUNT";

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
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LasPointStatsAsRaster SetEnviroment(int? autoCommit = null , object cellSize = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object pyramid = null , object rasterStatistics = null , object workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, cellSize: cellSize, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, pyramid: pyramid, rasterStatistics: rasterStatistics, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>Pulse Count—The number of last return points.</para>
			/// </summary>
			[GPValue("PULSE_COUNT")]
			[Description("Pulse Count")]
			Pulse_Count,

			/// <summary>
			/// <para>Point Count—The number of points from all returns.</para>
			/// </summary>
			[GPValue("POINT_COUNT")]
			[Description("Point Count")]
			Point_Count,

			/// <summary>
			/// <para>Most Frequent Last Return—The most frequent last return value.</para>
			/// </summary>
			[GPValue("PREDOMINANT_LAST_RETURN")]
			[Description("Most Frequent Last Return")]
			Most_Frequent_Last_Return,

			/// <summary>
			/// <para>Most Frequent Class Code—The most frequent class code.</para>
			/// </summary>
			[GPValue("PREDOMINANT_CLASS")]
			[Description("Most Frequent Class Code")]
			Most_Frequent_Class_Code,

			/// <summary>
			/// <para>Range of Intensity Values—The range of intensity values.</para>
			/// </summary>
			[GPValue("INTENSITY_RANGE")]
			[Description("Range of Intensity Values")]
			Range_of_Intensity_Values,

			/// <summary>
			/// <para>Range of Elevation Values—The range of elevation values.</para>
			/// </summary>
			[GPValue("Z_RANGE")]
			[Description("Range of Elevation Values")]
			Range_of_Elevation_Values,

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
