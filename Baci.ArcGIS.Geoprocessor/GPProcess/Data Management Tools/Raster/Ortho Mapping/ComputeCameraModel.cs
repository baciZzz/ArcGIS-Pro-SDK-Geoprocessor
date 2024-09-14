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
	/// <para>计算照相机模型</para>
	/// <para>通过原始影像的 EXIF 标头估计并优化外部和内部照相机模型。之后，该模型将应用于镶嵌数据集且可以选择使用工具生成的高分辨率数字表面模型 (DSM) 实现更好的正射校正。</para>
	/// </summary>
	public class ComputeCameraModel : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Input Mosaic Dataset</para>
		/// <para>用于构建和计算照相机模型的镶嵌数据集。</para>
		/// <para>尽管并非强制，但建议您先针对输入镶嵌数据集运行应用区域网平差工具。</para>
		/// </param>
		public ComputeCameraModel(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算照相机模型</para>
		/// </summary>
		public override string DisplayName() => "计算照相机模型";

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
		public override string[] ValidEnvironments() => new string[] { "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, OutDsm, GpsAccuracy, Estimate, Refine, ApplyAdjustment, MaximumResidual, InitialTiepointResolution, OutControlPoints, OutSolutionTable, OutSolutionPointTable, OutFlightPath, MaximumOverlap, MinimumCoverage, Remove, InControlPoints, Options, OutMosaicDataset };

		/// <summary>
		/// <para>Input Mosaic Dataset</para>
		/// <para>用于构建和计算照相机模型的镶嵌数据集。</para>
		/// <para>尽管并非强制，但建议您先针对输入镶嵌数据集运行应用区域网平差工具。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Output DSM</para>
		/// <para>通过镶嵌数据集中已调整影像生成的数字表面模型栅格数据集。如果选中了应用校正，则此 DSM 将用于替代几何函数中的 DEM，以实现更好的正射校正。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DERasterDataset()]
		public object OutDsm { get; set; }

		/// <summary>
		/// <para>GPS Location Accuracy</para>
		/// <para>指定输入图像的精度级别。此工具将在邻域内搜索影像以计算匹配点并自动根据精度级别应用校正策略。</para>
		/// <para>高 GPS 精度— GPS 精度介于 0 到 10 米之间，该工具可使用最多 4 x 3 张图像。</para>
		/// <para>中等 GPS 精度—GPS 精度介于 10 到 20 米之间，该工具可使用最多 4 x 6 张图像。</para>
		/// <para>低 GPS 精度—GPS 精度介于 20 到 50 米之间，该工具可使用最多 4 x 12 张图像。</para>
		/// <para>极低 GPS 精度—GPS 精度大于 50 米，该工具可使用最多 4 x 20 张图像。</para>
		/// <para>极高 GPS 精度—影像是使用高精度的差分 GPS（例如 RTK 或 PPK）收集的。此选项将在进行区域网平差期间保持影像位置固定。</para>
		/// <para><see cref="GpsAccuracyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GpsAccuracy { get; set; } = "HIGH";

		/// <summary>
		/// <para>Estimate Camera Model</para>
		/// <para>指定是否通过将镶嵌数据集源分辨率乘以八来计算平差，以估计照相机模型。在此级别下计算平差将加快速度但会降低精度。</para>
		/// <para>选中 - 将估计照相机模型。这是默认设置。</para>
		/// <para>未选中 - 将不会估计照相机模型。</para>
		/// <para><see cref="EstimateEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Estimate { get; set; } = "true";

		/// <summary>
		/// <para>Refine Camera Model</para>
		/// <para>指定是否在镶嵌数据集分辨率下计算平差，以优化照相机模型。在此级别下计算平差可提供最精确的结果。</para>
		/// <para>选中 - 在源分辨率下计算。这是默认设置。</para>
		/// <para>未选中 - 将不会在源分辨率下计算平差。使用此选项可加快速度，因此最好在不需要在源分辨率下执行计算时使用。</para>
		/// <para><see cref="RefineEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Refine { get; set; } = "true";

		/// <summary>
		/// <para>Apply Adjustment</para>
		/// <para>指定是否将已校正变换应用于镶嵌数据集。</para>
		/// <para>选中 - 已计算的平差将应用于输入镶嵌数据集。这是默认设置。</para>
		/// <para>未选中 - 已计算的平差将不会应用于输入镶嵌数据集。</para>
		/// <para><see cref="ApplyAdjustmentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ApplyAdjustment { get; set; } = "true";

		/// <summary>
		/// <para>Maximum Residual</para>
		/// <para>要将计算出的控制点保持为有效控制点时所容许的最大残差值。默认值为 5。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MaximumResidual { get; set; } = "5";

		/// <summary>
		/// <para>Initial Tie Point Resolution</para>
		/// <para>估计照相机模型时用于生成连接点的分辨率因子。默认值为 8，也就是源像素分辨率的八倍。</para>
		/// <para>对于仅有较小要素差异的影像（例如农田），可以使用较低的值（例如 2）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object InitialTiepointResolution { get; set; } = "8";

		/// <summary>
		/// <para>Output Control Point Table</para>
		/// <para>可选的控制点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Additional Outputs")]
		public object OutControlPoints { get; set; }

		/// <summary>
		/// <para>Output Solution Table</para>
		/// <para>可选的校正解决方案表。该解决方案表包含校正误差的均方根 (RMS) 和解决方案矩阵。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		[Category("Additional Outputs")]
		public object OutSolutionTable { get; set; }

		/// <summary>
		/// <para>Output Solution Point Table</para>
		/// <para>可选的解决方案点要素类。该解决方案点是用于生成校正解决方案的最终控制点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Additional Outputs")]
		public object OutSolutionPointTable { get; set; }

		/// <summary>
		/// <para>Output Flight Path</para>
		/// <para>可选的飞行路径线要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Additional Outputs")]
		public object OutFlightPath { get; set; }

		/// <summary>
		/// <para>Maximum Area Overlap</para>
		/// <para>要将两个图像视为重复项的二者之间的重叠百分比。</para>
		/// <para>例如，如果该值为 0.9，则意味着如果一个影像的 90% 被另一个影像覆盖，则系统会将其视为重复项并将其移除。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced Options")]
		public object MaximumOverlap { get; set; }

		/// <summary>
		/// <para>Minimum Control Point Coverage</para>
		/// <para>用于指示图像上的控制点覆盖范围的百分比。如果覆盖范围小于最小百分比，则系统将无法解析该图像并将其移除。默认值为 0.05，相当于 5%。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced Options")]
		public object MinimumCoverage { get; set; } = "0.05";

		/// <summary>
		/// <para>Remove Off-Strip Images</para>
		/// <para>用于指定当图像偏离航线条带过远时，是否自动将这些图像移除。</para>
		/// <para>未选中 - 将不移除图像。这是默认设置。</para>
		/// <para>选中 - 将移除偏离航线条带过远的图像。</para>
		/// <para><see cref="RemoveEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced Options")]
		public object Remove { get; set; } = "false";

		/// <summary>
		/// <para>Input Tie Point Table</para>
		/// <para>用于计算照相机模型的连接点表。如果未指定连接点表，则该工具将计算其自己的连接点并估计照相机模型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		[Category("Advanced Options")]
		public object InControlPoints { get; set; }

		/// <summary>
		/// <para>Additional Options</para>
		/// <para>用于校正引擎的其他选项。这些选项仅供第三方校正引擎使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[Category("Advanced Options")]
		public object Options { get; set; }

		/// <summary>
		/// <para>Output Camera Model</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ComputeCameraModel SetEnviroment(object parallelProcessingFactor = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>GPS Location Accuracy</para>
		/// </summary>
		public enum GpsAccuracyEnum 
		{
			/// <summary>
			/// <para>高 GPS 精度— GPS 精度介于 0 到 10 米之间，该工具可使用最多 4 x 3 张图像。</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("高 GPS 精度")]
			High_GPS_accuracy,

			/// <summary>
			/// <para>中等 GPS 精度—GPS 精度介于 10 到 20 米之间，该工具可使用最多 4 x 6 张图像。</para>
			/// </summary>
			[GPValue("MEDIUM")]
			[Description("中等 GPS 精度")]
			Medium_GPS_accuracy,

			/// <summary>
			/// <para>低 GPS 精度—GPS 精度介于 20 到 50 米之间，该工具可使用最多 4 x 12 张图像。</para>
			/// </summary>
			[GPValue("LOW")]
			[Description("低 GPS 精度")]
			Low_GPS_accuracy,

			/// <summary>
			/// <para>极低 GPS 精度—GPS 精度大于 50 米，该工具可使用最多 4 x 20 张图像。</para>
			/// </summary>
			[GPValue("VERY_LOW")]
			[Description("极低 GPS 精度")]
			Very_low_GPS_accuracy,

			/// <summary>
			/// <para>极高 GPS 精度—影像是使用高精度的差分 GPS（例如 RTK 或 PPK）收集的。此选项将在进行区域网平差期间保持影像位置固定。</para>
			/// </summary>
			[GPValue("VERY_HIGH")]
			[Description("极高 GPS 精度")]
			Very_high_GPS_accuracy,

		}

		/// <summary>
		/// <para>Estimate Camera Model</para>
		/// </summary>
		public enum EstimateEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ESTIMATE")]
			ESTIMATE,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REFINE")]
			REFINE,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("APPLY")]
			APPLY,

			/// <summary>
			/// <para></para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REMOVE")]
			REMOVE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_REMOVE")]
			NO_REMOVE,

		}

#endregion
	}
}
