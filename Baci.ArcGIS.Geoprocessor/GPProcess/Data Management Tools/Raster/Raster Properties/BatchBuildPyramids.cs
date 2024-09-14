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
	/// <para>Batch Build Pyramids</para>
	/// <para>Batch Build Pyramids</para>
	/// <para>Builds pyramids for multiple raster datasets.</para>
	/// </summary>
	public class BatchBuildPyramids : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputRasterDatasets">
		/// <para>Input Raster Datasets</para>
		/// <para>The raster datasets for which you want to build raster pyramids.</para>
		/// <para>Each input should have more than 1024 rows and 1024 columns.</para>
		/// </param>
		public BatchBuildPyramids(object InputRasterDatasets)
		{
			this.InputRasterDatasets = InputRasterDatasets;
		}

		/// <summary>
		/// <para>Tool Display Name : Batch Build Pyramids</para>
		/// </summary>
		public override string DisplayName() => "Batch Build Pyramids";

		/// <summary>
		/// <para>Tool Name : BatchBuildPyramids</para>
		/// </summary>
		public override string ToolName() => "BatchBuildPyramids";

		/// <summary>
		/// <para>Tool Excute Name : management.BatchBuildPyramids</para>
		/// </summary>
		public override string ExcuteName() => "management.BatchBuildPyramids";

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
		public override string[] ValidEnvironments() => new string[] { "pyramid", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputRasterDatasets, PyramidLevels, SkipFirstLevel, PyramidResamplingTechnique, PyramidCompressionType, CompressionQuality, SkipExisting, BatchBuildPyramidsSucceeded };

		/// <summary>
		/// <para>Input Raster Datasets</para>
		/// <para>The raster datasets for which you want to build raster pyramids.</para>
		/// <para>Each input should have more than 1024 rows and 1024 columns.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InputRasterDatasets { get; set; }

		/// <summary>
		/// <para>Pyramid levels</para>
		/// <para>Choose the number of reduced-resolution dataset layers that will be built. The default value is -1, which will build full pyramids. A value of 0 will result in no pyramid levels.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object PyramidLevels { get; set; } = "-1";

		/// <summary>
		/// <para>Skip first level</para>
		/// <para>Choose whether to skip the first pyramid level. Skipping the first level will take up slightly less disk space, but it will slow down performance at these scales.</para>
		/// <para>Unchecked—The first pyramid level will be built. This is the default.</para>
		/// <para>Checked—The first pyramid level will not be built.</para>
		/// <para><see cref="SkipFirstLevelEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SkipFirstLevel { get; set; } = "false";

		/// <summary>
		/// <para>Pyramid resampling technique</para>
		/// <para>The resampling technique used to build your pyramids.</para>
		/// <para>Nearest neighbor—The nearest neighbor resampling method uses the value of the closest cell to assign a value to the output cell when resampling. This is the default.</para>
		/// <para>Bilinear—The bilinear interpolation resampling method determines the new value of a cell based on a weighted distance average of the four nearest input cell centers.</para>
		/// <para>Cubic—The Cubic convolution resampling method determines the new value of a cell based on fitting a smooth curve through the 16 nearest input cell centers.</para>
		/// <para><see cref="PyramidResamplingTechniqueEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PyramidResamplingTechnique { get; set; } = "NEAREST";

		/// <summary>
		/// <para>Pyramid compression type</para>
		/// <para>The compression type to use when building the raster pyramids.</para>
		/// <para>Default—If the source data is compressed using a wavelet compression, it will build pyramids with the JPEG compression type; otherwise, LZ77 will be used. This is the default compression method.</para>
		/// <para>LZ77 Compression—The LZ77 compression algorithm will be used to build the pyramids. LZ77 can be used for any data type.</para>
		/// <para>JPEG—The JPEG compression algorithm to build pyramids. Only data that adheres to the JPEG compression specification can use this compression type. If JPEG is chosen, you can then set the compression quality.</para>
		/// <para>None—No compression will be used when building pyramids.</para>
		/// <para><see cref="PyramidCompressionTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object PyramidCompressionType { get; set; } = "DEFAULT";

		/// <summary>
		/// <para>Compression quality</para>
		/// <para>The compression quality to use when pyramids are built with the JPEG compression method. The value must be between 0 and 100. The values closer to 100 will produce a higher-quality image, but the compression ratio will be lower.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object CompressionQuality { get; set; } = "75";

		/// <summary>
		/// <para>Skip Existing</para>
		/// <para>Specify whether to build pyramids only where they are missing or regenerate them even if they exist.</para>
		/// <para>Unchecked—Pyramids will be built even if they already exist. Therefore, existing pyramids will be overwritten. This is the default.</para>
		/// <para>Checked—Pyramids will only be built if they do not exist.</para>
		/// <para><see cref="SkipExistingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object SkipExisting { get; set; }

		/// <summary>
		/// <para>Batch Build Pyramids Succeeded</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPBoolean()]
		public object BatchBuildPyramidsSucceeded { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public BatchBuildPyramids SetEnviroment(object pyramid = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(pyramid: pyramid, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Skip first level</para>
		/// </summary>
		public enum SkipFirstLevelEnum 
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
		public enum PyramidResamplingTechniqueEnum 
		{
			/// <summary>
			/// <para>Nearest neighbor—The nearest neighbor resampling method uses the value of the closest cell to assign a value to the output cell when resampling. This is the default.</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("Nearest neighbor")]
			Nearest_neighbor,

			/// <summary>
			/// <para>Bilinear—The bilinear interpolation resampling method determines the new value of a cell based on a weighted distance average of the four nearest input cell centers.</para>
			/// </summary>
			[GPValue("BILINEAR")]
			[Description("Bilinear")]
			Bilinear,

			/// <summary>
			/// <para>Cubic—The Cubic convolution resampling method determines the new value of a cell based on fitting a smooth curve through the 16 nearest input cell centers.</para>
			/// </summary>
			[GPValue("CUBIC")]
			[Description("Cubic")]
			Cubic,

		}

		/// <summary>
		/// <para>Pyramid compression type</para>
		/// </summary>
		public enum PyramidCompressionTypeEnum 
		{
			/// <summary>
			/// <para>Default—If the source data is compressed using a wavelet compression, it will build pyramids with the JPEG compression type; otherwise, LZ77 will be used. This is the default compression method.</para>
			/// </summary>
			[GPValue("DEFAULT")]
			[Description("Default")]
			Default,

			/// <summary>
			/// <para>JPEG—The JPEG compression algorithm to build pyramids. Only data that adheres to the JPEG compression specification can use this compression type. If JPEG is chosen, you can then set the compression quality.</para>
			/// </summary>
			[GPValue("JPEG")]
			[Description("JPEG")]
			JPEG,

			/// <summary>
			/// <para>LZ77 Compression—The LZ77 compression algorithm will be used to build the pyramids. LZ77 can be used for any data type.</para>
			/// </summary>
			[GPValue("LZ77")]
			[Description("LZ77 Compression")]
			LZ77_Compression,

			/// <summary>
			/// <para>None—No compression will be used when building pyramids.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

		}

		/// <summary>
		/// <para>Skip Existing</para>
		/// </summary>
		public enum SkipExistingEnum 
		{
			/// <summary>
			/// <para>Checked—Pyramids will only be built if they do not exist.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SKIP_EXISTING")]
			SKIP_EXISTING,

			/// <summary>
			/// <para>Unchecked—Pyramids will be built even if they already exist. Therefore, existing pyramids will be overwritten. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("OVERWRITE")]
			OVERWRITE,

		}

#endregion
	}
}
