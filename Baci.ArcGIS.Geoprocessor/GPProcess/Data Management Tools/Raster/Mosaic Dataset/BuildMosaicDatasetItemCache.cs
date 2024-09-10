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
	/// <para>Build Mosaic Dataset Item Cache</para>
	/// <para>Inserts the Cached Raster function as the final step in all function chains within a mosaic dataset.</para>
	/// </summary>
	public class BuildMosaicDatasetItemCache : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset where you want to apply the cache function.</para>
		/// </param>
		public BuildMosaicDatasetItemCache(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Build Mosaic Dataset Item Cache</para>
		/// </summary>
		public override string DisplayName() => "Build Mosaic Dataset Item Cache";

		/// <summary>
		/// <para>Tool Name : BuildMosaicDatasetItemCache</para>
		/// </summary>
		public override string ToolName() => "BuildMosaicDatasetItemCache";

		/// <summary>
		/// <para>Tool Excute Name : management.BuildMosaicDatasetItemCache</para>
		/// </summary>
		public override string ExcuteName() => "management.BuildMosaicDatasetItemCache";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, WhereClause, DefineCache, GenerateCache, ItemCacheFolder, CompressionMethod, CompressionQuality, MaxAllowedRows, MaxAllowedColumns, RequestSizeType, RequestSize, OutMosaicDataset };

		/// <summary>
		/// <para>Mosaic Dataset</para>
		/// <para>The mosaic dataset where you want to apply the cache function.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Query Definition</para>
		/// <para>An SQL expression to select specific raster datasets within the mosaic dataset on which you want the item cache built.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPSQLExpression()]
		public object WhereClause { get; set; }

		/// <summary>
		/// <para>Define Cache</para>
		/// <para>Enable editing on the Cache properties.</para>
		/// <para>Checked—Add the Cached Raster function to the selected items. If an item already has this function, it will not add another one. This is the default.</para>
		/// <para>Unchecked—No raster cache will be defined.</para>
		/// <para><see cref="DefineCacheEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object DefineCache { get; set; } = "true";

		/// <summary>
		/// <para>Generate Cache</para>
		/// <para>Choose to generate the cache files based on the properties defined in the Cached Raster function, such as the location and the compression of the cache.</para>
		/// <para>Checked—Cache will be generated. This is the default.</para>
		/// <para>Unchecked—Cache will not be generated.</para>
		/// <para><see cref="GenerateCacheEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object GenerateCache { get; set; } = "true";

		/// <summary>
		/// <para>Cache Path</para>
		/// <para>Choose to overwrite the default location to save your cache. If the mosaic dataset is inside of a file geodatabase, by default, the cache is saved in a folder with the same name as the geodatabase and a .cache extension. If the mosaic dataset is inside of an enterprise geodatabase, by default, the cache will be saved inside of that geodatabase. Once created, the cache will always save to the same location. To save the cache to a different location, you need to first use the Repair Mosaic Dataset tool to specify a new location and run this tool again.</para>
		/// <para>Once an item cache is created, regenerating an item cache to a different location is not possible by specifying a different cache path and rerunning this tool. It will still generate the item cache in the location where it was generated the first time. However, you can remove this function and insert a new one with the new path or use the Repair Mosaic Dataset tool to modify the cache path and run this tool to generate the item cache in a different location.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		[WorkspaceType("File System", "Local Database", "Remote Database")]
		[Category("Cache Properties")]
		public object ItemCacheFolder { get; set; }

		/// <summary>
		/// <para>Compression Method</para>
		/// <para>Choose how you want to compress your data for faster transmission.</para>
		/// <para>Lossless compression— Retain the values of each pixel when generating cache. Lossless has a compression ratio of approximately 2:1.</para>
		/// <para>Lossy compression— Appropriate when your imagery is only used as a backdrop. Lossy has the highest compression ratio (20:1) but groups similar pixel values to achieve higher compression.</para>
		/// <para>No compression— Do not compress imagery. This will make your imagery slower to transmit but faster to draw because it will not need to be decompressed when viewed.</para>
		/// <para><see cref="CompressionMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Cache Properties")]
		public object CompressionMethod { get; set; } = "LOSSLESS";

		/// <summary>
		/// <para>Compression Quality</para>
		/// <para>Set a compression quality when using the lossy method. The compression quality value is between 1 and 100 percent, with 100 compressing the least.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 0, Max = 100)]
		[Category("Cache Properties")]
		public object CompressionQuality { get; set; } = "80";

		/// <summary>
		/// <para>Maximum Allowed Rows</para>
		/// <para>Limit the size of the cache dataset by number of rows. If value is more than the number of rows in the dataset, the cache will not generate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 10, Max = 2147483647)]
		[Category("Cache Properties")]
		public object MaxAllowedRows { get; set; } = "200000";

		/// <summary>
		/// <para>Maximum Allowed Columns</para>
		/// <para>Limit the size of the cache dataset by number of columns. If value is more than the number of columns in the dataset, the cache will not generate.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPRangeDomain(Min = 10, Max = 2147483647)]
		[Category("Cache Properties")]
		public object MaxAllowedColumns { get; set; } = "200000";

		/// <summary>
		/// <para>Request Size Type</para>
		/// <para>Resample the cache using one of these two methods:</para>
		/// <para>Pixel size factor— Set a scaling factor relative to the pixel size. To not resample the cache, choose Pixel size factor and set the Request Size parameter to 1.</para>
		/// <para>Pixel size— Specify a pixel size for the cached raster.</para>
		/// <para><see cref="RequestSizeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Resampling")]
		public object RequestSizeType { get; set; } = "PIXEL_SIZE_FACTOR";

		/// <summary>
		/// <para>Request Size</para>
		/// <para>Set a value to apply to the Request Size Type.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 1.7976931348623157e+308)]
		[Category("Resampling")]
		public object RequestSize { get; set; } = "1";

		/// <summary>
		/// <para>Updated Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BuildMosaicDatasetItemCache SetEnviroment(object extent = null , object parallelProcessingFactor = null )
		{
			base.SetEnv(extent: extent, parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Define Cache</para>
		/// </summary>
		public enum DefineCacheEnum 
		{
			/// <summary>
			/// <para>Checked—Add the Cached Raster function to the selected items. If an item already has this function, it will not add another one. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("DEFINE_CACHE")]
			DEFINE_CACHE,

			/// <summary>
			/// <para>Unchecked—No raster cache will be defined.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_DEFINE_CACHE")]
			NO_DEFINE_CACHE,

		}

		/// <summary>
		/// <para>Generate Cache</para>
		/// </summary>
		public enum GenerateCacheEnum 
		{
			/// <summary>
			/// <para>Checked—Cache will be generated. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("GENERATE_CACHE")]
			GENERATE_CACHE,

			/// <summary>
			/// <para>Unchecked—Cache will not be generated.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_GENERATE_CACHE")]
			NO_GENERATE_CACHE,

		}

		/// <summary>
		/// <para>Compression Method</para>
		/// </summary>
		public enum CompressionMethodEnum 
		{
			/// <summary>
			/// <para>No compression— Do not compress imagery. This will make your imagery slower to transmit but faster to draw because it will not need to be decompressed when viewed.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("No compression")]
			No_compression,

			/// <summary>
			/// <para>Lossless compression— Retain the values of each pixel when generating cache. Lossless has a compression ratio of approximately 2:1.</para>
			/// </summary>
			[GPValue("LOSSLESS")]
			[Description("Lossless compression")]
			Lossless_compression,

			/// <summary>
			/// <para>Lossy compression— Appropriate when your imagery is only used as a backdrop. Lossy has the highest compression ratio (20:1) but groups similar pixel values to achieve higher compression.</para>
			/// </summary>
			[GPValue("LOSSY")]
			[Description("Lossy compression")]
			Lossy_compression,

		}

		/// <summary>
		/// <para>Request Size Type</para>
		/// </summary>
		public enum RequestSizeTypeEnum 
		{
			/// <summary>
			/// <para>Pixel size factor— Set a scaling factor relative to the pixel size. To not resample the cache, choose Pixel size factor and set the Request Size parameter to 1.</para>
			/// </summary>
			[GPValue("PIXEL_SIZE")]
			[Description("Pixel size")]
			Pixel_size,

			/// <summary>
			/// <para>Pixel size factor— Set a scaling factor relative to the pixel size. To not resample the cache, choose Pixel size factor and set the Request Size parameter to 1.</para>
			/// </summary>
			[GPValue("PIXEL_SIZE_FACTOR")]
			[Description("Pixel size factor")]
			Pixel_size_factor,

		}

#endregion
	}
}
