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
	/// <para>Apply Block Adjustment</para>
	/// <para>Applies the geographic adjustments</para>
	/// <para>to the mosaic dataset items. This tool uses the solution table from the Compute Block Adjustments tool.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ApplyBlockAdjustment : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Input Mosaic Dataset</para>
		/// <para>The input mosaic dataset to adjust.</para>
		/// </param>
		/// <param name="AdjustmentOperation">
		/// <para>Adjustment Operation</para>
		/// <para>Choose whether you want to adjust the mosaic dataset using the solution table or if you want to reset the mosaic dataset so there are no adjustments applied.</para>
		/// <para>Adjust the mosaic dataset—Adjust the mosaic dataset using the input solution table.</para>
		/// <para>Reset the mosaic dataset—Reset the mosaic dataset so there are no adjustments applied to it.</para>
		/// <para>Reactivate image status—Images dropped from the adjustment will be restored to active status. Images without the minimum number of control points required for adjustment are dropped from the computation in the standard adjustment operation, such that the images are categorized as Inactive in the footprints table, the maxPS value is set to 0, the imagery is not visible in the map, and the tie points statuses for the dropped images are disabled. This option will restore the Category status to Primary and ensure the maxPS value is resumed. Images that were included in the adjustment process are unaffected by this option.</para>
		/// <para><see cref="AdjustmentOperationEnum"/></para>
		/// </param>
		public ApplyBlockAdjustment(object InMosaicDataset, object AdjustmentOperation)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.AdjustmentOperation = AdjustmentOperation;
		}

		/// <summary>
		/// <para>Tool Display Name : Apply Block Adjustment</para>
		/// </summary>
		public override string DisplayName => "Apply Block Adjustment";

		/// <summary>
		/// <para>Tool Name : ApplyBlockAdjustment</para>
		/// </summary>
		public override string ToolName => "ApplyBlockAdjustment";

		/// <summary>
		/// <para>Tool Excute Name : management.ApplyBlockAdjustment</para>
		/// </summary>
		public override string ExcuteName => "management.ApplyBlockAdjustment";

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
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InMosaicDataset, AdjustmentOperation, InputSolutionTable!, PanToMsScalingFactor!, OutMosaicDataset!, DEM!, Zoffset!, ControlPointTable!, AdjustFootprints!, SolutionPointTable!, OutControlPointTable! };

		/// <summary>
		/// <para>Input Mosaic Dataset</para>
		/// <para>The input mosaic dataset to adjust.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Adjustment Operation</para>
		/// <para>Choose whether you want to adjust the mosaic dataset using the solution table or if you want to reset the mosaic dataset so there are no adjustments applied.</para>
		/// <para>Adjust the mosaic dataset—Adjust the mosaic dataset using the input solution table.</para>
		/// <para>Reset the mosaic dataset—Reset the mosaic dataset so there are no adjustments applied to it.</para>
		/// <para>Reactivate image status—Images dropped from the adjustment will be restored to active status. Images without the minimum number of control points required for adjustment are dropped from the computation in the standard adjustment operation, such that the images are categorized as Inactive in the footprints table, the maxPS value is set to 0, the imagery is not visible in the map, and the tie points statuses for the dropped images are disabled. This option will restore the Category status to Primary and ensure the maxPS value is resumed. Images that were included in the adjustment process are unaffected by this option.</para>
		/// <para><see cref="AdjustmentOperationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AdjustmentOperation { get; set; } = "ADJUST";

		/// <summary>
		/// <para>Input Solution Table</para>
		/// <para>Specify a solution table to use when adjusting your mosaic dataset. This is the output from the Compute Block Adjustments tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		public object? InputSolutionTable { get; set; }

		/// <summary>
		/// <para>Pan-To-MS Scaling Factor</para>
		/// <para>If your mosaic dataset contains pan-sharpened rasters, specify the scaling factor between the pan-sharpened resolution and the multispectral resolution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? PanToMsScalingFactor { get; set; }

		/// <summary>
		/// <para>Updated Input Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Input DEM</para>
		/// <para>A DEM to use within the application of the block adjustment. This DEM will only be used if it is a higher resolution than any DEM that may already exist within the mosaic dataset.</para>
		/// <para>If this input DEM is used, the geometric function of the mosaic dataset will be updated using this input.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object? DEM { get; set; }

		/// <summary>
		/// <para>Z offset</para>
		/// <para>The vertical offset used to adjust the elevation layer within the mosaic dataset's Geometric function.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? Zoffset { get; set; }

		/// <summary>
		/// <para>Control Point Table</para>
		/// <para>The input control point table will have the same adjustments applied as the solution table adjustments.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		public object? ControlPointTable { get; set; }

		/// <summary>
		/// <para>Adjust Footprints</para>
		/// <para>Choose whether to update the footprint geometry using the same transformation that was applied to the image.</para>
		/// <para>Unchecked—Do not update the footprint geometry. This is the default.</para>
		/// <para>Checked—Update the footprint geometry to the image geometry. The control point table will also be transformed, if one is provided.</para>
		/// <para><see cref="AdjustFootprintsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? AdjustFootprints { get; set; } = "false";

		/// <summary>
		/// <para>Solution Point Table</para>
		/// <para>Specify a solution points table to use to update the status field for the control point table. This parameter is used only when the Control Point Table parameter is set.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		public object? SolutionPointTable { get; set; }

		/// <summary>
		/// <para>Output Control Points</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object? OutControlPointTable { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Adjustment Operation</para>
		/// </summary>
		public enum AdjustmentOperationEnum 
		{
			/// <summary>
			/// <para>Adjust the mosaic dataset—Adjust the mosaic dataset using the input solution table.</para>
			/// </summary>
			[GPValue("ADJUST")]
			[Description("Adjust the mosaic dataset")]
			Adjust_the_mosaic_dataset,

			/// <summary>
			/// <para>Reset the mosaic dataset—Reset the mosaic dataset so there are no adjustments applied to it.</para>
			/// </summary>
			[GPValue("RESET")]
			[Description("Reset the mosaic dataset")]
			Reset_the_mosaic_dataset,

			/// <summary>
			/// <para>Reactivate image status—Images dropped from the adjustment will be restored to active status. Images without the minimum number of control points required for adjustment are dropped from the computation in the standard adjustment operation, such that the images are categorized as Inactive in the footprints table, the maxPS value is set to 0, the imagery is not visible in the map, and the tie points statuses for the dropped images are disabled. This option will restore the Category status to Primary and ensure the maxPS value is resumed. Images that were included in the adjustment process are unaffected by this option.</para>
			/// </summary>
			[GPValue("REACTIVATE")]
			[Description("Reactivate image status")]
			Reactivate_image_status,

		}

		/// <summary>
		/// <para>Adjust Footprints</para>
		/// </summary>
		public enum AdjustFootprintsEnum 
		{
			/// <summary>
			/// <para>Checked—Update the footprint geometry to the image geometry. The control point table will also be transformed, if one is provided.</para>
			/// </summary>
			[GPValue("true")]
			[Description("ADJUST_FOOTPRINTS")]
			ADJUST_FOOTPRINTS,

			/// <summary>
			/// <para>Unchecked—Do not update the footprint geometry. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ADJUST_FOOTPRINTS")]
			NO_ADJUST_FOOTPRINTS,

		}

#endregion
	}
}
