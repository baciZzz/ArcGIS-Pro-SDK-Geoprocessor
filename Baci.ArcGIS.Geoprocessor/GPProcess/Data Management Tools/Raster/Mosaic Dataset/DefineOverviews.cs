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
	/// <para>Define Overviews</para>
	/// <para>Lets you set how mosaic dataset overviews are generated. The settings made with this tool are used by the Build Overviews tool.</para>
	/// </summary>
	public class DefineOverviews : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset that you want to build overviews on.</para>
		/// </param>
		public DefineOverviews(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Define Overviews</para>
		/// </summary>
		public override string DisplayName => "Define Overviews";

		/// <summary>
		/// <para>Tool Name : DefineOverviews</para>
		/// </summary>
		public override string ToolName => "DefineOverviews";

		/// <summary>
		/// <para>Tool Excute Name : management.DefineOverviews</para>
		/// </summary>
		public override string ExcuteName => "management.DefineOverviews";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "parallelProcessingFactor", "tileSize" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InMosaicDataset, OverviewImageFolder, InTemplateDataset, Extent, PixelSize, NumberOfLevels, TileRows, TileCols, OverviewFactor, ForceOverviewTiles, ResamplingMethod, CompressionMethod, CompressionQuality, OutMosaicDataset };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset that you want to build overviews on.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>The folder or geodatabase to store the overviews.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object OverviewImageFolder { get; set; }

		/// <summary>
		/// <para>Extent from Dataset</para>
		/// <para>A raster dataset or feature class to define the extent of the overviews.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object InTemplateDataset { get; set; }

		/// <summary>
		/// <para>Extent</para>
		/// <para>Manually set the extent using the following minimum and maximum x and y coordinates.</para>
		/// <para>The mosaic dataset boundary will determine the extent of the overviews if you do not define an extent.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPEnvelope()]
		public object Extent { get; set; }

		/// <summary>
		/// <para>Pixel Size</para>
		/// <para>If you prefer not to use all the raster&apos;s pyramids, specify a base pixel size at which your overviews will be generated.</para>
		/// <para>The units for this parameter are the same as the spatial reference of the mosaic dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Overview Tile Parameters")]
		public object PixelSize { get; set; }

		/// <summary>
		/// <para>Number Of Levels</para>
		/// <para>Specify the number of levels of overviews that you want to generate overviews. A value of -1 will determine an optimal value for you.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Overview Tile Parameters")]
		public object NumberOfLevels { get; set; }

		/// <summary>
		/// <para>Number Of Rows</para>
		/// <para>Set the number of rows (in pixels) for each tile.</para>
		/// <para>Larger values will result in fewer, larger individual overviews, and increase the likelihood that you will need to regenerate lower level overviews. A smaller value will result in more, smaller files.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Overview Tile Parameters")]
		public object TileRows { get; set; } = "5120";

		/// <summary>
		/// <para>Number Of Columns</para>
		/// <para>Set the number of columns (in pixels) for each tile.</para>
		/// <para>Larger values will result in fewer, larger individual overviews, and increase the likelihood that you will need to regenerate lower level overviews. A smaller value will result in more, smaller files.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Overview Tile Parameters")]
		public object TileCols { get; set; } = "5120";

		/// <summary>
		/// <para>Overview Sampling Factor</para>
		/// <para>Set a ratio to determine the size of the next overview. For example, if the cell size of the first level is 10, and the overview factor is 3, then the next overview pixel size will be 30.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain()]
		[Category("Overview Tile Parameters")]
		public object OverviewFactor { get; set; } = "3";

		/// <summary>
		/// <para>Force Overview Tiles</para>
		/// <para>Generate overviews at all levels, or only above existing pyramid levels.</para>
		/// <para>Unchecked—Create overviews above the raster pyramid levels. This is the default.</para>
		/// <para>Checked—Create overviews at all levels.</para>
		/// <para><see cref="ForceOverviewTilesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Overview Tile Parameters")]
		public object ForceOverviewTiles { get; set; } = "false";

		/// <summary>
		/// <para>Resampling Method</para>
		/// <para>Choose an algorithm for aggregating pixel values in the overviews.</para>
		/// <para>Nearest—The fastest resampling method because it minimizes changes to pixel values. Suitable for discrete data, such as land cover. If the Raster MetadataData Type is thematic, then nearest neighbor will be the default.</para>
		/// <para>Bilinear—Calculates the value of each pixel by averaging (weighted for distance) the values of the surrounding 4 pixels. Suitable for continuous data.This is the default, unless the Raster Metadata Data Type is thematic.</para>
		/// <para>Cubic— Calculates the value of each pixel by fitting a smooth curve based on the surrounding 16 pixels. Produces the smoothest image, but can create values outside of the range found in the source data. Suitable for continuous data.</para>
		/// <para><see cref="ResamplingMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Overview Image Parameters")]
		public object ResamplingMethod { get; set; } = "BILINEAR";

		/// <summary>
		/// <para>Compression Method</para>
		/// <para>Define the type of data compression to store the overview images.</para>
		/// <para>JPEG—A lossy compression. This is the default, unless the Raster Metadata Data Type is thematic. This compression method is only valid if the mosaic dataset items adhere to JPEG specifications.</para>
		/// <para>JPEG Luna and Chroma—A lossy compression using the luma (Y) and chroma (Cb and Cr) color space components.</para>
		/// <para>None—No data compression.</para>
		/// <para>LZW—A lossless compression. If the Raster Metadata Data Type is thematic, then nearest neighbor will be the default.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Overview Image Parameters")]
		public object CompressionMethod { get; set; } = "JPEG";

		/// <summary>
		/// <para>Compression Quality</para>
		/// <para>Choose a value from 1 - 100. Higher values generate better quality outputs, but they create larger files.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Overview Image Parameters")]
		public object CompressionQuality { get; set; } = "80";

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMosaicLayer()]
		public object OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DefineOverviews SetEnviroment(object extent = null , object parallelProcessingFactor = null , double[] tileSize = null )
		{
			base.SetEnv(extent: extent, parallelProcessingFactor: parallelProcessingFactor, tileSize: tileSize);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Force Overview Tiles</para>
		/// </summary>
		public enum ForceOverviewTilesEnum 
		{
			/// <summary>
			/// <para>Checked—Create overviews at all levels.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FORCE_OVERVIEW_TILES")]
			FORCE_OVERVIEW_TILES,

			/// <summary>
			/// <para>Unchecked—Create overviews above the raster pyramid levels. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FORCE_OVERVIEW_TILES")]
			NO_FORCE_OVERVIEW_TILES,

		}

		/// <summary>
		/// <para>Resampling Method</para>
		/// </summary>
		public enum ResamplingMethodEnum 
		{
			/// <summary>
			/// <para>Nearest—The fastest resampling method because it minimizes changes to pixel values. Suitable for discrete data, such as land cover. If the Raster MetadataData Type is thematic, then nearest neighbor will be the default.</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("Nearest")]
			Nearest,

			/// <summary>
			/// <para>Bilinear—Calculates the value of each pixel by averaging (weighted for distance) the values of the surrounding 4 pixels. Suitable for continuous data.This is the default, unless the Raster Metadata Data Type is thematic.</para>
			/// </summary>
			[GPValue("BILINEAR")]
			[Description("Bilinear")]
			Bilinear,

			/// <summary>
			/// <para>Cubic— Calculates the value of each pixel by fitting a smooth curve based on the surrounding 16 pixels. Produces the smoothest image, but can create values outside of the range found in the source data. Suitable for continuous data.</para>
			/// </summary>
			[GPValue("CUBIC")]
			[Description("Cubic")]
			Cubic,

		}

#endregion
	}
}
