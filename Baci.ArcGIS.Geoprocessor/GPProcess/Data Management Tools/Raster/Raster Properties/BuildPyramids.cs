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
	/// <para>Build Pyramids</para>
	/// <para>Builds raster pyramids for your raster dataset.</para>
	/// </summary>
	public class BuildPyramids : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InRasterDataset">
		/// <para>Input Raster Dataset</para>
		/// <para>The raster dataset for which you want to build pyramids.</para>
		/// <para>The input should have more than 1,024 rows and 1,024 columns.</para>
		/// </param>
		public BuildPyramids(object InRasterDataset)
		{
			this.InRasterDataset = InRasterDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Build Pyramids</para>
		/// </summary>
		public override string DisplayName => "Build Pyramids";

		/// <summary>
		/// <para>Tool Name : BuildPyramids</para>
		/// </summary>
		public override string ToolName => "BuildPyramids";

		/// <summary>
		/// <para>Tool Excute Name : management.BuildPyramids</para>
		/// </summary>
		public override string ExcuteName => "management.BuildPyramids";

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
		public override string[] ValidEnvironments => new string[] { "parallelProcessingFactor", "pyramid", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InRasterDataset, PyramidLevel!, SKIPFIRST!, ResampleTechnique!, CompressionType!, CompressionQuality!, SkipExisting!, OutRaster! };

		/// <summary>
		/// <para>Input Raster Dataset</para>
		/// <para>The raster dataset for which you want to build pyramids.</para>
		/// <para>The input should have more than 1,024 rows and 1,024 columns.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InRasterDataset { get; set; }

		/// <summary>
		/// <para>Pyramid levels</para>
		/// <para>The number of reduced-resolution dataset layers that will be built. The default value is -1, which will build full pyramids. A value of 0 will result in no pyramid levels.</para>
		/// <para>To delete pyramids, set the number of levels to 0.</para>
		/// <para>The maximum number of pyramid levels you can specify is 29. Any value that is 30 or higher will revert to a value of -1, which will create a full set of pyramids.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? PyramidLevel { get; set; }

		/// <summary>
		/// <para>Skip first level</para>
		/// <para>Specifies whether the first pyramid level will be skipped. Skipping the first level will take up slightly less disk space, but it will slow down performance at these scales.</para>
		/// <para>Unchecked—The first pyramid level will not be skipped; it will be built. This is the default.</para>
		/// <para>Checked—The first pyramid level will be skipped; it will not be built.</para>
		/// <para><see cref="SKIPFIRSTEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SKIPFIRST { get; set; } = "false";

		/// <summary>
		/// <para>Pyramid resampling technique</para>
		/// <para>Specifies the resampling technique that will be used to build the pyramids.</para>
		/// <para>Nearest—The value of the closest pixel will be used to assign a value to the output pixel when resampling. This is the default.</para>
		/// <para>Bilinear—The new value of a pixel will be based on a weighted distance average of the four nearest input pixel centers.</para>
		/// <para>Cubic—The new value of a pixel will be based on fitting a smooth curve through the 16 nearest input pixel centers.</para>
		/// <para><see cref="ResampleTechniqueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ResampleTechnique { get; set; } = "NEAREST";

		/// <summary>
		/// <para>Pyramid compression type</para>
		/// <para>Specifies the compression type that will be used when building the raster pyramids.</para>
		/// <para>Default—If the source data is compressed using a wavelet compression, it will build pyramids with the JPEG compression type; otherwise, LZ77 will be used. This is the default compression method.</para>
		/// <para>LZ77—The LZ77 compression algorithm will be used to build the pyramids. LZ77 can be used for any data type.</para>
		/// <para>Jpeg—The JPEG compression algorithm will be used to build pyramids. Only data that adheres to the JPEG compression specification can use this compression type. If JPEG is chosen, you can then set the compression quality.</para>
		/// <para>Jpeg Luma and Chroma—A lossy compression using the luma (Y) and chroma (Cb and Cr) color space components will be used to build pyramids.</para>
		/// <para>No compression—No compression will be used when building pyramids.</para>
		/// <para><see cref="CompressionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? CompressionType { get; set; } = "DEFAULT";

		/// <summary>
		/// <para>Compression quality (1-100)</para>
		/// <para>The compression quality that will be used when pyramids are built with the JPEG compression method. The value must be between 0 and 100. The values closer to 100 will produce a higher-quality image, but the compression ratio will be lower.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? CompressionQuality { get; set; } = "75";

		/// <summary>
		/// <para>Skip Existing</para>
		/// <para>Specifies whether pyramids will be built only when they are missing or will be regenerated even if they exist.</para>
		/// <para>Unchecked—Pyramids will be built even if they already exist, and existing pyramids will be overwritten. This is the default.</para>
		/// <para>Checked—Pyramids will only be built if they do not already exist.</para>
		/// <para><see cref="SkipExistingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? SkipExisting { get; set; } = "false";

		/// <summary>
		/// <para>Updated Input Raster</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERasterDataset()]
		public object? OutRaster { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BuildPyramids SetEnviroment(object? parallelProcessingFactor = null , object? pyramid = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, pyramid: pyramid, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Skip first level</para>
		/// </summary>
		public enum SKIPFIRSTEnum 
		{
			/// <summary>
			/// <para>Checked—The first pyramid level will be skipped; it will not be built.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SKIP_FIRST")]
			SKIP_FIRST,

			/// <summary>
			/// <para>Unchecked—The first pyramid level will not be skipped; it will be built. This is the default.</para>
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
			/// <para>Nearest—The value of the closest pixel will be used to assign a value to the output pixel when resampling. This is the default.</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("Nearest")]
			Nearest,

			/// <summary>
			/// <para>Bilinear—The new value of a pixel will be based on a weighted distance average of the four nearest input pixel centers.</para>
			/// </summary>
			[GPValue("BILINEAR")]
			[Description("Bilinear")]
			Bilinear,

			/// <summary>
			/// <para>Cubic—The new value of a pixel will be based on fitting a smooth curve through the 16 nearest input pixel centers.</para>
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
			/// <para>Jpeg—The JPEG compression algorithm will be used to build pyramids. Only data that adheres to the JPEG compression specification can use this compression type. If JPEG is chosen, you can then set the compression quality.</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("Jpeg")]
			Jpeg,

			/// <summary>
			/// <para>LZ77—The LZ77 compression algorithm will be used to build the pyramids. LZ77 can be used for any data type.</para>
			/// </summary>
			[GPValue("LZ77")]
			[Description("LZ77")]
			LZ77,

			/// <summary>
			/// <para>No compression—No compression will be used when building pyramids.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("No compression")]
			No_compression,

			/// <summary>
			/// <para>Jpeg Luma and Chroma—A lossy compression using the luma (Y) and chroma (Cb and Cr) color space components will be used to build pyramids.</para>
			/// </summary>
			[GPValue("JPEG_YCbCr")]
			[Description("Jpeg Luma and Chroma")]
			Jpeg_Luma_and_Chroma,

		}

		/// <summary>
		/// <para>Skip Existing</para>
		/// </summary>
		public enum SkipExistingEnum 
		{
			/// <summary>
			/// <para>Checked—Pyramids will only be built if they do not already exist.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SKIP_EXISTING")]
			SKIP_EXISTING,

			/// <summary>
			/// <para>Unchecked—Pyramids will be built even if they already exist, and existing pyramids will be overwritten. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("OVERWRITE")]
			OVERWRITE,

		}

#endregion
	}
}
