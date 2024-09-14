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
	/// <para>Compute Block Adjustment</para>
	/// <para>Compute Block Adjustment</para>
	/// <para>Computes the adjustments</para>
	/// <para>to the mosaic dataset. This tool will create a solution  table that can be used to apply the actual adjustments.</para>
	/// </summary>
	public class ComputeBlockAdjustment : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Input Mosaic Dataset</para>
		/// <para>The input mosaic dataset that will be adjusted.</para>
		/// </param>
		/// <param name="InControlPoints">
		/// <para>Input Control Points</para>
		/// <para>The control point table that includes tie points and ground control points.</para>
		/// <para>This is usually the output from the Compute Tie Points tool.</para>
		/// </param>
		/// <param name="TransformationType">
		/// <para>Transformation Type</para>
		/// <para>Specifies the type of transformation that will be used when adjusting the mosaic dataset.</para>
		/// <para>Zero-order polynomial—A zero-order polynomial is used in the block adjustment computation. This is commonly used when your data is in flat area.</para>
		/// <para>First-order polynomial—A first-order polynomial (affine) is used in the block adjustment computation. This is the default.</para>
		/// <para>Rational Polynomial Coefficients—The Rational Polynomial Coefficients will be used for the transformation. This is used for satellite imagery that contains RPC information within the metadata. This option requires the ArcGIS Desktop Advanced license.</para>
		/// <para>Frame camera model—The Frame camera model will be used for the transformation. This is used for aerial imagery that contains the frame camera information within the metadata. This option requires the ArcGIS Desktop Advanced license.</para>
		/// <para><see cref="TransformationTypeEnum"/></para>
		/// </param>
		/// <param name="OutSolutionTable">
		/// <para>Output Solution Table</para>
		/// <para>The output solution table containing the adjustments.</para>
		/// </param>
		public ComputeBlockAdjustment(object InMosaicDataset, object InControlPoints, object TransformationType, object OutSolutionTable)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.InControlPoints = InControlPoints;
			this.TransformationType = TransformationType;
			this.OutSolutionTable = OutSolutionTable;
		}

		/// <summary>
		/// <para>Tool Display Name : Compute Block Adjustment</para>
		/// </summary>
		public override string DisplayName() => "Compute Block Adjustment";

		/// <summary>
		/// <para>Tool Name : ComputeBlockAdjustment</para>
		/// </summary>
		public override string ToolName() => "ComputeBlockAdjustment";

		/// <summary>
		/// <para>Tool Excute Name : management.ComputeBlockAdjustment</para>
		/// </summary>
		public override string ExcuteName() => "management.ComputeBlockAdjustment";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, InControlPoints, TransformationType, OutSolutionTable, OutSolutionPointTable!, MaximumResidualValue!, AdjustmentOptions!, LocationAccuracy!, OutQualityTable! };

		/// <summary>
		/// <para>Input Mosaic Dataset</para>
		/// <para>The input mosaic dataset that will be adjusted.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Input Control Points</para>
		/// <para>The control point table that includes tie points and ground control points.</para>
		/// <para>This is usually the output from the Compute Tie Points tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InControlPoints { get; set; }

		/// <summary>
		/// <para>Transformation Type</para>
		/// <para>Specifies the type of transformation that will be used when adjusting the mosaic dataset.</para>
		/// <para>Zero-order polynomial—A zero-order polynomial is used in the block adjustment computation. This is commonly used when your data is in flat area.</para>
		/// <para>First-order polynomial—A first-order polynomial (affine) is used in the block adjustment computation. This is the default.</para>
		/// <para>Rational Polynomial Coefficients—The Rational Polynomial Coefficients will be used for the transformation. This is used for satellite imagery that contains RPC information within the metadata. This option requires the ArcGIS Desktop Advanced license.</para>
		/// <para>Frame camera model—The Frame camera model will be used for the transformation. This is used for aerial imagery that contains the frame camera information within the metadata. This option requires the ArcGIS Desktop Advanced license.</para>
		/// <para><see cref="TransformationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TransformationType { get; set; } = "POLYORDER1";

		/// <summary>
		/// <para>Output Solution Table</para>
		/// <para>The output solution table containing the adjustments.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutSolutionTable { get; set; }

		/// <summary>
		/// <para>Output Solution  Points</para>
		/// <para>The output solution points table. This will be saved as a polygon feature class. This output can be quite large.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutSolutionPointTable { get; set; }

		/// <summary>
		/// <para>Maximum Residual</para>
		/// <para>A threshold that is used in block adjustment computation, points with residuals exceeding the threshold will not be used. This parameter applies when the transformation type is Zero-order polynomial, First-order polynomial, or Frame camera model. If the transformation is Rational Polynomial Coefficients, the proper threshold for eliminating invalid points will be automatically determined.</para>
		/// <para>When the transformation is Zero-order polynomial or First-order polynomial the units for this parameter will be in map units, and the default value will be 2.</para>
		/// <para>When the transformation is Frame camera model the units for this parameter will be in pixels, and the default value will be 5.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaximumResidualValue { get; set; } = "5";

		/// <summary>
		/// <para>Adjustment Options</para>
		/// <para>Additional options that can fine-tune the adjustment computation. To set, type the keyword and the corresponding value in the list box.</para>
		/// <para>Minimum residual value—The minimum residual value, which is the lower threshold value. When polynomial transformation is either Zero-order polynomial or First-order polynomial, the units will be in map units and the default minimum residual will be 0. The minimum residual value and the maximum residual parameter are used in detecting and removing points that generate large errors from the block adjustment computation.</para>
		/// <para>Maximum residual factor—The maximum residual factor is a factor used to generate maximum (upper threshold) residual. If the Maximum Residual parameter is not defined, it will use the MaxResidualFactor * RMS to calculate the upper threshold value.The minimum residual value and the maximum residual parameter are used in detecting and removing points that generate large errors from block adjustment computation.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? AdjustmentOptions { get; set; }

		/// <summary>
		/// <para>Image Location Accuracy</para>
		/// <para>Specifies the geometric accuracy level of the images.</para>
		/// <para>This parameter is only valid if Rational Polynomial Coefficients is specified as the Transformation Type value.</para>
		/// <para>High accuracy—Accuracy is under 30 meters.</para>
		/// <para>Medium accuracy—Accuracy is between 31 meters and 100 meters. This is the default.</para>
		/// <para>Low accuracy—Accuracy is higher than 100 meters.</para>
		/// <para>Very High accuracy—Imagery was collected with a high-accuracy, differential GPS, such as RTK or PPK. This option will keep image locations fixed during block adjustment.</para>
		/// <para>If low accuracy is specified, the control points will first be improved by an initial triangulation; then they will be used in the block adjustment calculation. The medium and high accuracy options do not require additional estimation processing.</para>
		/// <para><see cref="LocationAccuracyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LocationAccuracy { get; set; } = "MEDIUM";

		/// <summary>
		/// <para>Output Adjustment Quality Table</para>
		/// <para>An output table used to store adjustment quality information.</para>
		/// <para>This parameter is only valid if Rational Polynomial Coefficients is specified as the Transformation Type value.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? OutQualityTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ComputeBlockAdjustment SetEnviroment(object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Transformation Type</para>
		/// </summary>
		public enum TransformationTypeEnum 
		{
			/// <summary>
			/// <para>First-order polynomial—A first-order polynomial (affine) is used in the block adjustment computation. This is the default.</para>
			/// </summary>
			[GPValue("POLYORDER1")]
			[Description("First-order polynomial")]
			POLYORDER1,

			/// <summary>
			/// <para>Zero-order polynomial—A zero-order polynomial is used in the block adjustment computation. This is commonly used when your data is in flat area.</para>
			/// </summary>
			[GPValue("POLYORDER0")]
			[Description("Zero-order polynomial")]
			POLYORDER0,

			/// <summary>
			/// <para>Rational Polynomial Coefficients—The Rational Polynomial Coefficients will be used for the transformation. This is used for satellite imagery that contains RPC information within the metadata. This option requires the ArcGIS Desktop Advanced license.</para>
			/// </summary>
			[GPValue("RPC")]
			[Description("Rational Polynomial Coefficients")]
			Rational_Polynomial_Coefficients,

			/// <summary>
			/// <para>Frame camera model—The Frame camera model will be used for the transformation. This is used for aerial imagery that contains the frame camera information within the metadata. This option requires the ArcGIS Desktop Advanced license.</para>
			/// </summary>
			[GPValue("Frame")]
			[Description("Frame camera model")]
			Frame_camera_model,

		}

		/// <summary>
		/// <para>Image Location Accuracy</para>
		/// </summary>
		public enum LocationAccuracyEnum 
		{
			/// <summary>
			/// <para>Low accuracy—Accuracy is higher than 100 meters.</para>
			/// </summary>
			[GPValue("LOW")]
			[Description("Low accuracy")]
			Low_accuracy,

			/// <summary>
			/// <para>Medium accuracy—Accuracy is between 31 meters and 100 meters. This is the default.</para>
			/// </summary>
			[GPValue("MEDIUM")]
			[Description("Medium accuracy")]
			Medium_accuracy,

			/// <summary>
			/// <para>High accuracy—Accuracy is under 30 meters.</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("High accuracy")]
			High_accuracy,

			/// <summary>
			/// <para>Very High accuracy—Imagery was collected with a high-accuracy, differential GPS, such as RTK or PPK. This option will keep image locations fixed during block adjustment.</para>
			/// </summary>
			[GPValue("VERY_HIGH")]
			[Description("Very High accuracy")]
			Very_High_accuracy,

		}

#endregion
	}
}
