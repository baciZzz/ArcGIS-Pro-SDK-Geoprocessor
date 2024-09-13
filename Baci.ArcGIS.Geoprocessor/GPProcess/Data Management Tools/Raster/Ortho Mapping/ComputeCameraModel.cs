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
	/// <para>Compute Camera Model</para>
	/// <para>Compute Camera Model</para>
	/// <para>Estimates the exterior camera model and interior camera model from the EXIF header of the raw image and refines the camera models. The model is then applied to the mosaic dataset with an option to use a tool-generated, high-resolution digital surface model (DSM) to achieve better orthorectification.</para>
	/// </summary>
	public class ComputeCameraModel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Input Mosaic Dataset</para>
		/// <para>The mosaic dataset on which the camera model will be built and calculated.</para>
		/// <para>Although not mandatory, it is recommended that you run the Apply Block Adjustment tool on the input mosaic dataset first.</para>
		/// </param>
		public ComputeCameraModel(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Compute Camera Model</para>
		/// </summary>
		public override string DisplayName() => "Compute Camera Model";

		/// <summary>
		/// <para>Tool Name : ComputeCameraModel</para>
		/// </summary>
		public override string ToolName() => "ComputeCameraModel";

		/// <summary>
		/// <para>Tool Excute Name : management.ComputeCameraModel</para>
		/// </summary>
		public override string ExcuteName() => "management.ComputeCameraModel";

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
		public override string[] ValidEnvironments() => new string[] { "gpuID", "parallelProcessingFactor", "processorType", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, OutDsm!, GpsAccuracy!, Estimate!, Refine!, ApplyAdjustment!, MaximumResidual!, InitialTiepointResolution!, OutControlPoints!, OutSolutionTable!, OutSolutionPointTable!, OutFlightPath!, MaximumOverlap!, MinimumCoverage!, Remove!, InControlPoints!, Options!, OutMosaicDataset! };

		/// <summary>
		/// <para>Input Mosaic Dataset</para>
		/// <para>The mosaic dataset on which the camera model will be built and calculated.</para>
		/// <para>Although not mandatory, it is recommended that you run the Apply Block Adjustment tool on the input mosaic dataset first.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Output DSM</para>
		/// <para>A DSM raster dataset generated from the adjusted images in the mosaic dataset. If Apply Adjustment is checked, this DSM will replace the DEM in the geometric function to achieve better orthorectification.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object? OutDsm { get; set; }

		/// <summary>
		/// <para>GPS Location Accuracy</para>
		/// <para>Specifies the accuracy level of the input images. The tool will search for images in the neighborhood to compute matching points and automatically apply an adjustment strategy based on the accuracy level.</para>
		/// <para>High GPS accuracy— The GPS accuracy is 0 to 10 meters, and the tool uses a maximum of 4 by 3 images.</para>
		/// <para>Medium GPS accuracy—The GPS accuracy is 10 to 20 meters, and the tool uses a maximum of 4 by 6 images.</para>
		/// <para>Low GPS accuracy—The GPS accuracy is 20 to 50 meters, and the tool uses a maximum of 4 by 12 images.</para>
		/// <para>Very low GPS accuracy—The GPS accuracy is more than 50 meters, and the tool uses a maximum of 4 by 20 images.</para>
		/// <para>Very high GPS accuracy—Imagery was collected with high-accuracy, differential GPS, such as RTK or PPK. This option will hold image locations fixed during block adjustment.</para>
		/// <para><see cref="GpsAccuracyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? GpsAccuracy { get; set; } = "HIGH";

		/// <summary>
		/// <para>Estimate Camera Model</para>
		/// <para>Specifies whether the camera model will be estimated by computing the adjustment based on eight times the mosaic dataset&apos;s source resolution. Computing the adjustment at this level will be faster but less accurate.</para>
		/// <para>Checked—The camera model will be estimated. This is the default.</para>
		/// <para>Unchecked—The camera model will not be estimated.</para>
		/// <para><see cref="EstimateEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Estimate { get; set; } = "true";

		/// <summary>
		/// <para>Refine Camera Model</para>
		/// <para>Specifies whether the camera model will be refined by computing the adjustment at the mosaic dataset resolution. Computing the adjustment at this level will provide the most accurate result.</para>
		/// <para>Checked—The camera model will be refined by computing the adjustment at the source resolution. This is the default.</para>
		/// <para>Unchecked—The camera model will not be refined. This option will be faster, so it is a good option when the computation does not need to be performed at the source resolution.</para>
		/// <para><see cref="RefineEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Refine { get; set; } = "true";

		/// <summary>
		/// <para>Apply Adjustment</para>
		/// <para>Specifies whether the adjusted transformation will be applied to the mosaic dataset.</para>
		/// <para>Checked—The calculated adjustment will be applied to the input mosaic dataset. This is the default.</para>
		/// <para>Unchecked—The calculated adjustment will not be applied to the input mosaic dataset.</para>
		/// <para><see cref="ApplyAdjustmentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ApplyAdjustment { get; set; } = "true";

		/// <summary>
		/// <para>Maximum Residual</para>
		/// <para>The maximum residual value allowed to keep a computed control point as a valid control point. The default is 5.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaximumResidual { get; set; } = "5";

		/// <summary>
		/// <para>Initial Tie Point Resolution</para>
		/// <para>The resolution factor at which tie points will be generated when estimating the camera model. The default value is 8, which means eight times the source pixel resolution.</para>
		/// <para>For images with only minor differentiation of features, such as agriculture fields, a lower value such as 2 can be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? InitialTiepointResolution { get; set; } = "8";

		/// <summary>
		/// <para>Output Control Point Table</para>
		/// <para>The optional control points feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Additional Outputs")]
		public object? OutControlPoints { get; set; }

		/// <summary>
		/// <para>Output Solution Table</para>
		/// <para>The optional adjustment solution table. The solution table contains the root mean square (RMS) of the adjustment error and solution matrix.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Additional Outputs")]
		public object? OutSolutionTable { get; set; }

		/// <summary>
		/// <para>Output Solution Point Table</para>
		/// <para>The optional solution point feature class. The solution points are the final controls points used to generate the adjustment solution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Additional Outputs")]
		public object? OutSolutionPointTable { get; set; }

		/// <summary>
		/// <para>Output Flight Path</para>
		/// <para>The optional flight path line feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Additional Outputs")]
		public object? OutFlightPath { get; set; }

		/// <summary>
		/// <para>Maximum Area Overlap</para>
		/// <para>The percentage of overlap between two images to consider them duplicates.</para>
		/// <para>For example, if the value is 0.9, it means if an image is 90 percent covered by another image, it will be considered a duplicate and removed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced Options")]
		public object? MaximumOverlap { get; set; }

		/// <summary>
		/// <para>Minimum Control Point Coverage</para>
		/// <para>The percentage indicating the control point's coverage on an image. If the coverage is less than the minimum percentage, the image will be unresolved and removed. The default is 0.05, which is 5 percent.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced Options")]
		public object? MinimumCoverage { get; set; } = "0.05";

		/// <summary>
		/// <para>Remove Off-Strip Images</para>
		/// <para>Specifies whether images will be automatically removed if they are too far from the flight strip.</para>
		/// <para>Unchecked—Images will not be removed. This is the default.</para>
		/// <para>Checked—Images that are too far away from the flight strip will be removed.</para>
		/// <para><see cref="RemoveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object? Remove { get; set; } = "false";

		/// <summary>
		/// <para>Input Tie Point Table</para>
		/// <para>The tie point table used to compute the camera model. If a tie point table is not specified, the tool will compute its own tie points and estimate the camera model.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Advanced Options")]
		public object? InControlPoints { get; set; }

		/// <summary>
		/// <para>Additional Options</para>
		/// <para>Additional options for the adjustment engine. These options are only used by third-party adjustment engines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[Category("Advanced Options")]
		public object? Options { get; set; }

		/// <summary>
		/// <para>Output Camera Model</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ComputeCameraModel SetEnviroment(object? parallelProcessingFactor = null , object? processorType = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, processorType: processorType, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>GPS Location Accuracy</para>
		/// </summary>
		public enum GpsAccuracyEnum 
		{
			/// <summary>
			/// <para>High GPS accuracy— The GPS accuracy is 0 to 10 meters, and the tool uses a maximum of 4 by 3 images.</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("High GPS accuracy")]
			High_GPS_accuracy,

			/// <summary>
			/// <para>Medium GPS accuracy—The GPS accuracy is 10 to 20 meters, and the tool uses a maximum of 4 by 6 images.</para>
			/// </summary>
			[GPValue("MEDIUM")]
			[Description("Medium GPS accuracy")]
			Medium_GPS_accuracy,

			/// <summary>
			/// <para>Low GPS accuracy—The GPS accuracy is 20 to 50 meters, and the tool uses a maximum of 4 by 12 images.</para>
			/// </summary>
			[GPValue("LOW")]
			[Description("Low GPS accuracy")]
			Low_GPS_accuracy,

			/// <summary>
			/// <para>Very low GPS accuracy—The GPS accuracy is more than 50 meters, and the tool uses a maximum of 4 by 20 images.</para>
			/// </summary>
			[GPValue("VERY_LOW")]
			[Description("Very low GPS accuracy")]
			Very_low_GPS_accuracy,

			/// <summary>
			/// <para>Very high GPS accuracy—Imagery was collected with high-accuracy, differential GPS, such as RTK or PPK. This option will hold image locations fixed during block adjustment.</para>
			/// </summary>
			[GPValue("VERY_HIGH")]
			[Description("Very high GPS accuracy")]
			Very_high_GPS_accuracy,

		}

		/// <summary>
		/// <para>Estimate Camera Model</para>
		/// </summary>
		public enum EstimateEnum 
		{
			/// <summary>
			/// <para>Checked—The camera model will be estimated. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ESTIMATE")]
			ESTIMATE,

			/// <summary>
			/// <para>Unchecked—The camera model will not be estimated.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ESTIMATE")]
			NO_ESTIMATE,

		}

		/// <summary>
		/// <para>Refine Camera Model</para>
		/// </summary>
		public enum RefineEnum 
		{
			/// <summary>
			/// <para>Checked—The camera model will be refined by computing the adjustment at the source resolution. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REFINE")]
			REFINE,

			/// <summary>
			/// <para>Unchecked—The camera model will not be refined. This option will be faster, so it is a good option when the computation does not need to be performed at the source resolution.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_REFINE")]
			NO_REFINE,

		}

		/// <summary>
		/// <para>Apply Adjustment</para>
		/// </summary>
		public enum ApplyAdjustmentEnum 
		{
			/// <summary>
			/// <para>Checked—The calculated adjustment will be applied to the input mosaic dataset. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("APPLY")]
			APPLY,

			/// <summary>
			/// <para>Unchecked—The calculated adjustment will not be applied to the input mosaic dataset.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_APPLY")]
			NO_APPLY,

		}

		/// <summary>
		/// <para>Remove Off-Strip Images</para>
		/// </summary>
		public enum RemoveEnum 
		{
			/// <summary>
			/// <para>Checked—Images that are too far away from the flight strip will be removed.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REMOVE")]
			REMOVE,

			/// <summary>
			/// <para>Unchecked—Images will not be removed. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_REMOVE")]
			NO_REMOVE,

		}

#endregion
	}
}
