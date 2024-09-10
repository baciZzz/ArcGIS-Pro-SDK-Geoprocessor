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
	/// <para>Workspace To Raster Dataset</para>
	/// <para>Merges all of the raster datasets in a folder into one raster dataset.</para>
	/// </summary>
	public class WorkspaceToRasterDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>The folder containing the raster datasets to merge.</para>
		/// </param>
		/// <param name="InRasterDataset">
		/// <para>Target Raster Dataset</para>
		/// <para>An existing raster dataset in which to merge all of the raster datasets from the input workspace.</para>
		/// </param>
		public WorkspaceToRasterDataset(object InWorkspace, object InRasterDataset)
		{
			this.InWorkspace = InWorkspace;
			this.InRasterDataset = InRasterDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Workspace To Raster Dataset</para>
		/// </summary>
		public override string DisplayName() => "Workspace To Raster Dataset";

		/// <summary>
		/// <para>Tool Name : WorkspaceToRasterDataset</para>
		/// </summary>
		public override string ToolName() => "WorkspaceToRasterDataset";

		/// <summary>
		/// <para>Tool Excute Name : management.WorkspaceToRasterDataset</para>
		/// </summary>
		public override string ExcuteName() => "management.WorkspaceToRasterDataset";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWorkspace, InRasterDataset, IncludeSubdirectories, MosaicType, Colormap, BackgroundValue, NodataValue, OnebitToEightbit, MosaickingTolerance, Matchingmethod, ColormapToRGB, OutRasterDataset };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>The folder containing the raster datasets to merge.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Target Raster Dataset</para>
		/// <para>An existing raster dataset in which to merge all of the raster datasets from the input workspace.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object InRasterDataset { get; set; }

		/// <summary>
		/// <para>Include Sub-directories</para>
		/// <para>Specify whether to include subdirectories.</para>
		/// <para>Unchecked—Does not include subdirectories. This is the default.</para>
		/// <para>Checked—Includes all the raster datasets in the subdirectories when loading.</para>
		/// <para><see cref="IncludeSubdirectoriesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeSubdirectories { get; set; } = "false";

		/// <summary>
		/// <para>Mosaic Operator</para>
		/// <para>Specifies the method that will be used to mosaic overlapping areas.</para>
		/// <para>First—The output cell value of the overlapping areas will be the value from the first raster dataset mosaicked into that location.</para>
		/// <para>Last—The output cell value of the overlapping areas will be the value from the last raster dataset mosaicked into that location. This is the default.</para>
		/// <para>Blend—The output cell value of the overlapping areas will be a horizontally weighted calculation of the values of the cells in the overlapping area.</para>
		/// <para>Mean—The output cell value of the overlapping areas will be the average value of the overlapping cells.</para>
		/// <para>Minimum—The output cell value of the overlapping areas will be the minimum value of the overlapping cells.</para>
		/// <para>Maximum—The output cell value of the overlapping areas will be the maximum value of the overlapping cells.</para>
		/// <para>Sum—The output cell value of the overlapping areas will be the total sum of the overlapping cells.</para>
		/// <para><see cref="MosaicTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MosaicType { get; set; } = "LAST";

		/// <summary>
		/// <para>Mosaic Colormap Mode</para>
		/// <para>Specifies the method that will be used to choose which color map from the input rasters will be applied to the mosaic output.</para>
		/// <para>First—The color map from the first raster dataset in the list will be applied to the output raster mosaic. This is the default.</para>
		/// <para>Last—The color map from the last raster dataset in the list will be applied to the output raster mosaic.</para>
		/// <para>Match—All the color maps will be considered when mosaicking. If all possible values are already used (for the bit depth), the tool will match the value with the closest available color.</para>
		/// <para>Reject—Only the raster datasets that do not have a color map associated with them will be mosaicked.</para>
		/// <para><see cref="ColormapEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Colormap { get; set; } = "FIRST";

		/// <summary>
		/// <para>Ignore Background Value</para>
		/// <para>Use this option to remove the unwanted values created around the raster data. The value specified will be distinguished from other valuable data in the raster dataset. For example, a value of zero along the raster dataset&apos;s borders will be distinguished from zero values in the raster dataset.</para>
		/// <para>The pixel value specified will be set to NoData in the output raster dataset.</para>
		/// <para>For file-based rasters the Ignore Background Value must be set to the same value as NoData in order for the background value to be ignored. Enterprise and file geodatabase rasters will work without this extra step.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object BackgroundValue { get; set; }

		/// <summary>
		/// <para>NoData Value</para>
		/// <para>All the pixels with the specified value will be set to NoData in the output raster dataset.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object NodataValue { get; set; }

		/// <summary>
		/// <para>Convert 1 bit data to 8 bit</para>
		/// <para>Choose whether the input 1-bit raster dataset will be converted to an 8-bit raster dataset. In this conversion, the value 1 in the input raster dataset will be changed to 255 in the output raster dataset. This is useful when importing a 1-bit raster dataset to a geodatabase. One-bit raster datasets have 8-bit pyramid layers when stored in a file system, but in a geodatabase, 1-bit raster datasets can only have 1-bit pyramid layers, which makes the display unpleasant. By converting the data to 8 bit in a geodatabase, the pyramid layers are built as 8 bit instead of 1 bit, resulting in a proper raster dataset in the display.</para>
		/// <para>Unchecked—No conversion will be done. This is the default.</para>
		/// <para>Checked—The input raster will be converted.</para>
		/// <para><see cref="OnebitToEightbitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object OnebitToEightbit { get; set; } = "false";

		/// <summary>
		/// <para>Mosaicking Tolerance</para>
		/// <para>When mosaicking occurs, the target and the source pixels do not always line up exactly. When there is a misalignment of pixels, you need to decide whether to resample or shift the data. The mosaicking tolerance controls whether resampling of the pixels will occur or the pixels will be shifted.</para>
		/// <para>If the difference in pixel alignment (of the incoming dataset and the target dataset) is greater than the tolerance, resampling will occur. If the difference in pixel alignment (of the incoming dataset and the target dataset) is less than the tolerance, resampling will not occur and a shift will be performed.</para>
		/// <para>The unit of tolerance is a pixel with a valid value range of 0 to 0.5. A tolerance of 0.5 will guarantee a shift occurs. A tolerance of zero guarantees resampling will occur if there is a misalignment in pixels.</para>
		/// <para>For example, the source and target pixels have a misalignment of 0.25. If the mosaicking tolerance is set to 0.2, resampling will occur since the pixel misalignment is greater than the tolerance. If the mosaicking tolerance is set to 0.3, the pixels will be shifted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MosaickingTolerance { get; set; } = "0";

		/// <summary>
		/// <para>Color Matching Method</para>
		/// <para>The color matching method to apply to the rasters.</para>
		/// <para>None—This option will not use the color matching operation when mosaicking your raster datasets.</para>
		/// <para>Match statistics—This method will use descriptive statistics from the overlapping areas; the transformation will then be applied to the entire target dataset.</para>
		/// <para>Match histogram—This method will match the histogram from the reference overlap area to the source overlap area; the transformation will then be applied to the entire target dataset.</para>
		/// <para>Linear correlation—This method will match overlapping pixels and then interpolated the rest of the source dataset; pixels without a one-to-one relationship will use a weighted average.</para>
		/// <para><see cref="MatchingmethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Matchingmethod { get; set; } = "NONE";

		/// <summary>
		/// <para>Colormap to RGB</para>
		/// <para>If the input raster dataset has a color map, the output raster dataset can be converted to a three-band output raster dataset. This is useful when mosaicking rasters with different color maps.</para>
		/// <para>Unchecked—No conversion will occur. This is the default.</para>
		/// <para>Checked—The input dataset will be converted.</para>
		/// <para><see cref="ColormapToRGBEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ColormapToRGB { get; set; } = "false";

		/// <summary>
		/// <para>Updated Target Raster Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DERasterDataset()]
		public object OutRasterDataset { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Include Sub-directories</para>
		/// </summary>
		public enum IncludeSubdirectoriesEnum 
		{
			/// <summary>
			/// <para>Checked—Includes all the raster datasets in the subdirectories when loading.</para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_SUBDIRECTORIES")]
			INCLUDE_SUBDIRECTORIES,

			/// <summary>
			/// <para>Unchecked—Does not include subdirectories. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Mosaic Operator</para>
		/// </summary>
		public enum MosaicTypeEnum 
		{
			/// <summary>
			/// <para>First—The output cell value of the overlapping areas will be the value from the first raster dataset mosaicked into that location.</para>
			/// </summary>
			[GPValue("FIRST")]
			[Description("First")]
			First,

			/// <summary>
			/// <para>Last—The output cell value of the overlapping areas will be the value from the last raster dataset mosaicked into that location. This is the default.</para>
			/// </summary>
			[GPValue("LAST")]
			[Description("Last")]
			Last,

			/// <summary>
			/// <para>Blend—The output cell value of the overlapping areas will be a horizontally weighted calculation of the values of the cells in the overlapping area.</para>
			/// </summary>
			[GPValue("BLEND")]
			[Description("Blend")]
			Blend,

			/// <summary>
			/// <para>Mean—The output cell value of the overlapping areas will be the average value of the overlapping cells.</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("Mean")]
			Mean,

			/// <summary>
			/// <para>Minimum—The output cell value of the overlapping areas will be the minimum value of the overlapping cells.</para>
			/// </summary>
			[GPValue("MINIMUM")]
			[Description("Minimum")]
			Minimum,

			/// <summary>
			/// <para>Maximum—The output cell value of the overlapping areas will be the maximum value of the overlapping cells.</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("Maximum")]
			Maximum,

			/// <summary>
			/// <para>Sum—The output cell value of the overlapping areas will be the total sum of the overlapping cells.</para>
			/// </summary>
			[GPValue("SUM")]
			[Description("Sum")]
			Sum,

		}

		/// <summary>
		/// <para>Mosaic Colormap Mode</para>
		/// </summary>
		public enum ColormapEnum 
		{
			/// <summary>
			/// <para>Reject—Only the raster datasets that do not have a color map associated with them will be mosaicked.</para>
			/// </summary>
			[GPValue("REJECT")]
			[Description("Reject")]
			Reject,

			/// <summary>
			/// <para>First—The color map from the first raster dataset in the list will be applied to the output raster mosaic. This is the default.</para>
			/// </summary>
			[GPValue("FIRST")]
			[Description("First")]
			First,

			/// <summary>
			/// <para>Last—The color map from the last raster dataset in the list will be applied to the output raster mosaic.</para>
			/// </summary>
			[GPValue("LAST")]
			[Description("Last")]
			Last,

			/// <summary>
			/// <para>Match—All the color maps will be considered when mosaicking. If all possible values are already used (for the bit depth), the tool will match the value with the closest available color.</para>
			/// </summary>
			[GPValue("MATCH")]
			[Description("Match")]
			Match,

		}

		/// <summary>
		/// <para>Convert 1 bit data to 8 bit</para>
		/// </summary>
		public enum OnebitToEightbitEnum 
		{
			/// <summary>
			/// <para>Checked—The input raster will be converted.</para>
			/// </summary>
			[GPValue("true")]
			[Description("OneBitTo8Bit")]
			OneBitTo8Bit,

			/// <summary>
			/// <para>Unchecked—No conversion will be done. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

		/// <summary>
		/// <para>Color Matching Method</para>
		/// </summary>
		public enum MatchingmethodEnum 
		{
			/// <summary>
			/// <para>None—This option will not use the color matching operation when mosaicking your raster datasets.</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("None")]
			None,

			/// <summary>
			/// <para>Match statistics—This method will use descriptive statistics from the overlapping areas; the transformation will then be applied to the entire target dataset.</para>
			/// </summary>
			[GPValue("STATISTIC_MATCHING")]
			[Description("Match statistics")]
			Match_statistics,

			/// <summary>
			/// <para>Match histogram—This method will match the histogram from the reference overlap area to the source overlap area; the transformation will then be applied to the entire target dataset.</para>
			/// </summary>
			[GPValue("HISTOGRAM_MATCHING")]
			[Description("Match histogram")]
			Match_histogram,

			/// <summary>
			/// <para>Linear correlation—This method will match overlapping pixels and then interpolated the rest of the source dataset; pixels without a one-to-one relationship will use a weighted average.</para>
			/// </summary>
			[GPValue("LINEARCORRELATION_MATCHING")]
			[Description("Linear correlation")]
			Linear_correlation,

		}

		/// <summary>
		/// <para>Colormap to RGB</para>
		/// </summary>
		public enum ColormapToRGBEnum 
		{
			/// <summary>
			/// <para>Checked—The input dataset will be converted.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ColormapToRGB")]
			ColormapToRGB,

			/// <summary>
			/// <para>Unchecked—No conversion will occur. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

#endregion
	}
}
