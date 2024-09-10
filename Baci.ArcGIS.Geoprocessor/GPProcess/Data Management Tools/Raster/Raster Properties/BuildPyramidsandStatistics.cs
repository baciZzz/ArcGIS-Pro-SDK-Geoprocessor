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
	/// <para>Build Pyramids And Statistics</para>
	/// <para>Traverses a folder structure, building pyramids and calculating statistics for all the raster datasets it contains. It can also build pyramids and calculate statistics for all the items in a mosaic dataset.</para>
	/// </summary>
	public class BuildPyramidsandStatistics : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Data or Workspace</para>
		/// <para>The workspace that contains all the raster datasets or mosaic datasets to be processed.</para>
		/// <para>If the workspace includes a mosaic dataset, only the statistics associated with the mosaic dataset will be included. The statistics associated with the items within the mosaic dataset will not be included.</para>
		/// </param>
		public BuildPyramidsandStatistics(object InWorkspace)
		{
			this.InWorkspace = InWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : Build Pyramids And Statistics</para>
		/// </summary>
		public override string DisplayName() => "Build Pyramids And Statistics";

		/// <summary>
		/// <para>Tool Name : BuildPyramidsandStatistics</para>
		/// </summary>
		public override string ToolName() => "BuildPyramidsandStatistics";

		/// <summary>
		/// <para>Tool Excute Name : management.BuildPyramidsandStatistics</para>
		/// </summary>
		public override string ExcuteName() => "management.BuildPyramidsandStatistics";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor", "pyramid", "rasterStatistics" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWorkspace, IncludeSubdirectories, BuildPyramids, CalculateStatistics, BUILDONSOURCE, BlockField, EstimateStatistics, XSkipFactor, YSkipFactor, IgnoreValues, PyramidLevel, SKIPFIRST, ResampleTechnique, CompressionType, CompressionQuality, SkipExisting, OutWorkspace, WhereClause, SipsMode };

		/// <summary>
		/// <para>Input Data or Workspace</para>
		/// <para>The workspace that contains all the raster datasets or mosaic datasets to be processed.</para>
		/// <para>If the workspace includes a mosaic dataset, only the statistics associated with the mosaic dataset will be included. The statistics associated with the items within the mosaic dataset will not be included.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Include Sub-directories</para>
		/// <para>Specify whether to include subdirectories.</para>
		/// <para>Unchecked—Does not include subdirectories.</para>
		/// <para>Checked—Includes all the raster datasets within the subdirectories when loading. This is the default.</para>
		/// <para>Mosaic datasets must be specified as an input workspace if you want to include the items within the mosaic dataset. Otherwise, only the statistics associated with the mosaic dataset will be used.</para>
		/// <para><see cref="IncludeSubdirectoriesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeSubdirectories { get; set; } = "true";

		/// <summary>
		/// <para>Build Pyramids</para>
		/// <para>Specify whether to build pyramids.</para>
		/// <para>Unchecked—Does not build pyramids.</para>
		/// <para>Checked—Builds pyramids. This is the default.</para>
		/// <para><see cref="BuildPyramidsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object BuildPyramids { get; set; } = "true";

		/// <summary>
		/// <para>Calculate Statistics</para>
		/// <para>Specify whether to calculate statistics.</para>
		/// <para>Unchecked—Does not calculate statistics.</para>
		/// <para>Checked—Calculates statistics. This is the default.</para>
		/// <para><see cref="CalculateStatisticsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CalculateStatistics { get; set; } = "true";

		/// <summary>
		/// <para>Include Source Datasets</para>
		/// <para>Specify whether to build pyramids and calculate statistics on the source raster datasets, or calculate statistics on the raster items in a mosaic dataset. This option only applies to mosaic datasets.</para>
		/// <para>Unchecked—Statistics will be calculated for each raster item in the mosaic dataset (on each row in the attribute table). Any functions added to the raster item will be applied before generating the statistics. This is the default.</para>
		/// <para>Checked—Builds pyramids and calculates statistics on the source data of the mosaic dataset.</para>
		/// <para><see cref="BUILDONSOURCEEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Statistics Options")]
		public object BUILDONSOURCE { get; set; } = "false";

		/// <summary>
		/// <para>Block Field</para>
		/// <para>The name of the field within a mosaic dataset's attribute table used to identify items that should be considered one item when performing some calculations and operations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Statistics Options")]
		public object BlockField { get; set; }

		/// <summary>
		/// <para>Estimate Mosaic Dataset Statistics</para>
		/// <para>Specify whether to calculate statistics for the mosaic dataset (not the rasters within it). The statistics are derived from the existing statistics that have been calculated for each raster in the mosaic dataset.</para>
		/// <para>Unchecked—Statistics are not calculated for the mosaic dataset. This is the default.</para>
		/// <para>Checked—Statistics will be calculated for the mosaic dataset.</para>
		/// <para><see cref="EstimateStatisticsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Statistics Options")]
		public object EstimateStatistics { get; set; } = "false";

		/// <summary>
		/// <para>X Skip Factor</para>
		/// <para>The number of horizontal pixels between samples.</para>
		/// <para>A skip factor controls the portion of the raster that is used when calculating the statistics. The input value indicates the horizontal or vertical skip factor, where a value of 1 will use each pixel and a value of 2 will use every second pixel. The skip factor can only range from 1 to the number of columns/rows in the raster.</para>
		/// <para>A skip factor controls the portion of the raster that is used when calculating the statistics. The input value indicates the horizontal or vertical skip factor, where a value of 1 will use each pixel and a value of 2 will use every second pixel. The skip factor can only range from 1 to the number of columns/rows in the raster.</para>
		/// <para>The value must be greater than zero and less than or equal to the number of columns in the raster. The default is 1 or the last skip factor used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Statistics Options")]
		public object XSkipFactor { get; set; }

		/// <summary>
		/// <para>Y Skip Factor</para>
		/// <para>The number of vertical pixels between samples.</para>
		/// <para>A skip factor controls the portion of the raster that is used when calculating the statistics. The input value indicates the horizontal or vertical skip factor, where a value of 1 will use each pixel and a value of 2 will use every second pixel. The skip factor can only range from 1 to the number of columns/rows in the raster.</para>
		/// <para>A skip factor controls the portion of the raster that is used when calculating the statistics. The input value indicates the horizontal or vertical skip factor, where a value of 1 will use each pixel and a value of 2 will use every second pixel. The skip factor can only range from 1 to the number of columns/rows in the raster.</para>
		/// <para>The value must be greater than zero and less than or equal to the number of rows in the raster. The default is 1 or the last y skip factor used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Statistics Options")]
		public object YSkipFactor { get; set; }

		/// <summary>
		/// <para>Ignore Values</para>
		/// <para>The pixel values that are not to be included in the statistics calculation.</para>
		/// <para>The default is no value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[Category("Statistics Options")]
		public object IgnoreValues { get; set; }

		/// <summary>
		/// <para>Pyramid levels</para>
		/// <para>Choose the number of reduced-resolution dataset layers that will be built. The default value is -1, which will build full pyramids. A value of 0 will result in no pyramid levels.</para>
		/// <para>The maximum number of pyramid levels you can specify is 29. Any value of 30 or higher will create a full set of pyramids.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Pyramids Options")]
		public object PyramidLevel { get; set; }

		/// <summary>
		/// <para>Skip first level</para>
		/// <para>Choose whether to skip the first pyramid level. Skipping the first level will take up slightly less disk space, but it will slow down performance at these scales.</para>
		/// <para>Unchecked—The first pyramid level will be built. This is the default.</para>
		/// <para>Checked—The first pyramid level will not be built.</para>
		/// <para><see cref="SKIPFIRSTEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Pyramids Options")]
		public object SKIPFIRST { get; set; } = "false";

		/// <summary>
		/// <para>Pyramid resampling technique</para>
		/// <para>The resampling technique used to build your pyramids.</para>
		/// <para>Nearest neighbor—This method uses the value of the closest cell to assign a value to the output cell when resampling. This is the default.</para>
		/// <para>Bilinear—This method determines the new value of a cell based on a weighted distance average of the four nearest input cell centers.</para>
		/// <para>Cubic—This method determines the new value of a cell based on fitting a smooth curve through the 16 nearest input cell centers.</para>
		/// <para><see cref="ResampleTechniqueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Pyramids Options")]
		public object ResampleTechnique { get; set; } = "NEAREST";

		/// <summary>
		/// <para>Pyramid compression type</para>
		/// <para>The compression type to use when building the raster pyramids.</para>
		/// <para>Default—If the source data is compressed using a wavelet compression, it will build pyramids with the JPEG compression type; otherwise, LZ77 will be used. This is the default compression method.</para>
		/// <para>LZ77 Compression—The LZ77 compression algorithm will be used to build the pyramids. LZ77 can be used for any data type.</para>
		/// <para>JPEG Compression—The JPEG compression algorithm to build pyramids. Only data that adheres to the JPEG compression specification can use this compression type. If JPEG is chosen, you can then set the Compression Quality.</para>
		/// <para>JPEG Luma and Chroma—A lossy compression using the luma (Y) and chroma (Cb and Cr) color space components.</para>
		/// <para>No compression—No compression will be used when building pyramids.</para>
		/// <para><see cref="CompressionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Pyramids Options")]
		public object CompressionType { get; set; } = "DEFAULT";

		/// <summary>
		/// <para>Compression quality (1-100)</para>
		/// <para>The compression quality to use when pyramids are built with the JPEG compression method. The value must be between 0 and 100. The values closer to 100 will produce a higher-quality image, but the compression ratio will be lower.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[Category("Pyramids Options")]
		public object CompressionQuality { get; set; } = "75";

		/// <summary>
		/// <para>Skip Existing</para>
		/// <para>Specify whether to calculate statistics only where they are missing, or regenerate them even if they exist.</para>
		/// <para>Checked—Statistics will only be calculated if they do not already exist. This is the default.</para>
		/// <para>Unchecked—Statistics will be calculated even if they already exist; existing statistics will be overwritten.</para>
		/// <para><see cref="SkipExistingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SkipExisting { get; set; } = "true";

		/// <summary>
		/// <para>Updated Input Data</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>An SQL expression to select raster datasets that will be processed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>SIPS Mode</para>
		/// <para>Specifies whether to enable building of pyramid files using key processes and algorithms defined in the Softcopy Image Processing Standard (SIPS), NGA.STND.0014.</para>
		/// <para>Unchecked—Pyramids will be built using standard subsampling methods. This is the default.</para>
		/// <para>Checked—Pyramids will be built using SIPS processing.</para>
		/// <para><see cref="SipsModeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Pyramids Options")]
		public object SipsMode { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BuildPyramidsandStatistics SetEnviroment(object parallelProcessingFactor = null , object pyramid = null , object rasterStatistics = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, rasterStatistics: rasterStatistics);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Include Sub-directories</para>
		/// </summary>
		public enum IncludeSubdirectoriesEnum 
		{
			/// <summary>
			/// <para>Checked—Includes all the raster datasets within the subdirectories when loading. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_SUBDIRECTORIES")]
			INCLUDE_SUBDIRECTORIES,

			/// <summary>
			/// <para>Unchecked—Does not include subdirectories.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Build Pyramids</para>
		/// </summary>
		public enum BuildPyramidsEnum 
		{
			/// <summary>
			/// <para>Checked—Builds pyramids. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("BUILD_PYRAMIDS")]
			BUILD_PYRAMIDS,

			/// <summary>
			/// <para>Unchecked—Does not build pyramids.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Calculate Statistics</para>
		/// </summary>
		public enum CalculateStatisticsEnum 
		{
			/// <summary>
			/// <para>Checked—Calculates statistics. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CALCULATE_STATISTICS")]
			CALCULATE_STATISTICS,

			/// <summary>
			/// <para>Unchecked—Does not calculate statistics.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Include Source Datasets</para>
		/// </summary>
		public enum BUILDONSOURCEEnum 
		{
			/// <summary>
			/// <para>Checked—Builds pyramids and calculates statistics on the source data of the mosaic dataset.</para>
			/// </summary>
			[GPValue("true")]
			[Description("BUILD_ON_SOURCE")]
			BUILD_ON_SOURCE,

			/// <summary>
			/// <para>Unchecked—Statistics will be calculated for each raster item in the mosaic dataset (on each row in the attribute table). Any functions added to the raster item will be applied before generating the statistics. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Estimate Mosaic Dataset Statistics</para>
		/// </summary>
		public enum EstimateStatisticsEnum 
		{
			/// <summary>
			/// <para>Checked—Statistics will be calculated for the mosaic dataset.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ESTIMATE_STATISTICS")]
			ESTIMATE_STATISTICS,

			/// <summary>
			/// <para>Unchecked—Statistics are not calculated for the mosaic dataset. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Skip first level</para>
		/// </summary>
		public enum SKIPFIRSTEnum 
		{
			/// <summary>
			/// <para>Checked—The first pyramid level will not be built.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SKIP_FIRST")]
			SKIP_FIRST,

			/// <summary>
			/// <para>Unchecked—The first pyramid level will be built. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Pyramid resampling technique</para>
		/// </summary>
		public enum ResampleTechniqueEnum 
		{
			/// <summary>
			/// <para>Nearest neighbor—This method uses the value of the closest cell to assign a value to the output cell when resampling. This is the default.</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("Nearest neighbor")]
			Nearest_neighbor,

			/// <summary>
			/// <para>Bilinear—This method determines the new value of a cell based on a weighted distance average of the four nearest input cell centers.</para>
			/// </summary>
			[GPValue("BILINEAR")]
			[Description("Bilinear")]
			Bilinear,

			/// <summary>
			/// <para>Cubic—This method determines the new value of a cell based on fitting a smooth curve through the 16 nearest input cell centers.</para>
			/// </summary>
			[GPValue("CUBIC")]
			[Description("Cubic")]
			Cubic,

		}

		/// <summary>
		/// <para>Pyramid compression type</para>
		/// </summary>
		public enum CompressionTypeEnum 
		{
			/// <summary>
			/// <para>Default—If the source data is compressed using a wavelet compression, it will build pyramids with the JPEG compression type; otherwise, LZ77 will be used. This is the default compression method.</para>
			/// </summary>
			[GPValue("DEFAULT")]
			[Description("Default")]
			Default,

			/// <summary>
			/// <para>JPEG Compression—The JPEG compression algorithm to build pyramids. Only data that adheres to the JPEG compression specification can use this compression type. If JPEG is chosen, you can then set the Compression Quality.</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("JPEG Compression")]
			JPEG_Compression,

			/// <summary>
			/// <para>LZ77 Compression—The LZ77 compression algorithm will be used to build the pyramids. LZ77 can be used for any data type.</para>
			/// </summary>
			[GPValue("LZ77")]
			[Description("LZ77 Compression")]
			LZ77_Compression,

			/// <summary>
			/// <para>No compression—No compression will be used when building pyramids.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("No compression")]
			No_compression,

			/// <summary>
			/// <para>JPEG Luma and Chroma—A lossy compression using the luma (Y) and chroma (Cb and Cr) color space components.</para>
			/// </summary>
			[GPValue("JPEG_YCBCR")]
			[Description("JPEG Luma and Chroma")]
			JPEG_Luma_and_Chroma,

		}

		/// <summary>
		/// <para>Skip Existing</para>
		/// </summary>
		public enum SkipExistingEnum 
		{
			/// <summary>
			/// <para>Checked—Statistics will only be calculated if they do not already exist. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SKIP_EXISTING")]
			SKIP_EXISTING,

			/// <summary>
			/// <para>Unchecked—Statistics will be calculated even if they already exist; existing statistics will be overwritten.</para>
			/// </summary>
			[GPValue("false")]
			[Description("OVERWRITE")]
			OVERWRITE,

		}

		/// <summary>
		/// <para>SIPS Mode</para>
		/// </summary>
		public enum SipsModeEnum 
		{
			/// <summary>
			/// <para>Checked—Pyramids will be built using SIPS processing.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SIPS_MODE")]
			SIPS_MODE,

			/// <summary>
			/// <para>Unchecked—Pyramids will be built using standard subsampling methods. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

#endregion
	}
}
