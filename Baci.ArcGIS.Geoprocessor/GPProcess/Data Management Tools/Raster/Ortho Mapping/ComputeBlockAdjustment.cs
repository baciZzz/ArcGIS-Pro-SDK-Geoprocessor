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
	/// <para>计算区域网平差</para>
	/// <para>计算对镶嵌数据集的调整。 该工具将创建一个解决方案表，可用于应用实际调整。</para>
	/// </summary>
	public class ComputeBlockAdjustment : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Input Mosaic Dataset</para>
		/// <para>将调整的输入镶嵌数据集。</para>
		/// </param>
		/// <param name="InControlPoints">
		/// <para>Input Control Points</para>
		/// <para>包含连接点和地面控制点的控制点表。</para>
		/// <para>这通常是计算连接点工具的输出。</para>
		/// </param>
		/// <param name="TransformationType">
		/// <para>Transformation Type</para>
		/// <para>指定在校正镶嵌数据集时要使用的变换类型。</para>
		/// <para>零阶多项式—区域网平差计算采用零阶多项式。 当您的数据位于平坦区域时，通常使用此方法。</para>
		/// <para>一阶多项式—区域网平差计算采用一阶多项式（仿射）。 这是默认设置。</para>
		/// <para>有理多项式系数—有理多项式系数将用于变换中。 用于在元数据中包含 RPC 信息的卫星影像。该选项要求要有 ArcGIS Desktop Advanced 许可。</para>
		/// <para>帧照相机模型—帧照相机模型将用于变换中。 用于在元数据中包含帧照相机信息的航空影像。该选项要求要有 ArcGIS Desktop Advanced 许可。</para>
		/// <para><see cref="TransformationTypeEnum"/></para>
		/// </param>
		/// <param name="OutSolutionTable">
		/// <para>Output Solution Table</para>
		/// <para>输出解决方案表包含调整。</para>
		/// </param>
		public ComputeBlockAdjustment(object InMosaicDataset, object InControlPoints, object TransformationType, object OutSolutionTable)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.InControlPoints = InControlPoints;
			this.TransformationType = TransformationType;
			this.OutSolutionTable = OutSolutionTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算区域网平差</para>
		/// </summary>
		public override string DisplayName() => "计算区域网平差";

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
		/// <para>将调整的输入镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Input Control Points</para>
		/// <para>包含连接点和地面控制点的控制点表。</para>
		/// <para>这通常是计算连接点工具的输出。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InControlPoints { get; set; }

		/// <summary>
		/// <para>Transformation Type</para>
		/// <para>指定在校正镶嵌数据集时要使用的变换类型。</para>
		/// <para>零阶多项式—区域网平差计算采用零阶多项式。 当您的数据位于平坦区域时，通常使用此方法。</para>
		/// <para>一阶多项式—区域网平差计算采用一阶多项式（仿射）。 这是默认设置。</para>
		/// <para>有理多项式系数—有理多项式系数将用于变换中。 用于在元数据中包含 RPC 信息的卫星影像。该选项要求要有 ArcGIS Desktop Advanced 许可。</para>
		/// <para>帧照相机模型—帧照相机模型将用于变换中。 用于在元数据中包含帧照相机信息的航空影像。该选项要求要有 ArcGIS Desktop Advanced 许可。</para>
		/// <para><see cref="TransformationTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TransformationType { get; set; } = "POLYORDER1";

		/// <summary>
		/// <para>Output Solution Table</para>
		/// <para>输出解决方案表包含调整。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutSolutionTable { get; set; }

		/// <summary>
		/// <para>Output Solution  Points</para>
		/// <para>输出解决方案点表。 该表将保存为面要素类。 此输出可能非常大。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutSolutionPointTable { get; set; }

		/// <summary>
		/// <para>Maximum Residual</para>
		/// <para>在区域网平差计算中使用的阈值，残差大于阈值的点不会被使用。 当变换类型为零阶多项式、一阶多项式或帧照相机模型时，将应用此参数。 如果变换为有理多项式系数，则将自动确定消除无效点的适当阈值。</para>
		/// <para>当变换为零阶多项式或一阶多项式时，该参数的单位将为地图单位，且默认值为 2。</para>
		/// <para>当变换为帧照相机模型时，该参数的单位将为像素单位，且默认值为 5。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaximumResidualValue { get; set; } = "5";

		/// <summary>
		/// <para>Adjustment Options</para>
		/// <para>可用来对校正计算进行调整的附加选项。 设置时，在列表框中输入关键字和相应的值。</para>
		/// <para>最小残差值—作为阈值下限的最小残差值。 多项式变换为零阶多项式或一阶多项式时，该单位将为地图单位，且默认最小残差为 0。最小残差值和最大残差值参数用于检测产生严重错误的点，并将这些点从局域网平差计算中移除。</para>
		/// <para>最大残差因子—最大残差因子用于生成最大（阈值上限）残差。 如果未定义最大残差参数，将使用MaxResidualFactor * RMS来计算阈值上限。最小残差值和最大残差参数用于检测产生严重错误的点，并将这些点从局域网平差计算中移除。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? AdjustmentOptions { get; set; }

		/// <summary>
		/// <para>Image Location Accuracy</para>
		/// <para>指定图像的几何精度级别。</para>
		/// <para>仅当将有理多项式系数指定为变换类型值时，此参数才有效。</para>
		/// <para>高精度—精度小于 30 米。</para>
		/// <para>中等精度—精度介于 31 米到 100 米之间。 这是默认设置。</para>
		/// <para>低精度—精度大于 100 米。</para>
		/// <para>极高精度—影像是使用高精度的差分 GPS（例如 RTK 或 PPK）收集的。 此选项将在进行区域网平差期间保持影像位置固定。</para>
		/// <para>如果指定低精度，则控制点首先将通过初始三角测量改善；然后它将在区域网平差计算中使用。 中等精度和高精度选项不需要任何其他估算处理。</para>
		/// <para><see cref="LocationAccuracyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LocationAccuracy { get; set; } = "MEDIUM";

		/// <summary>
		/// <para>Output Adjustment Quality Table</para>
		/// <para>用来存储校正质量信息的输出表格。</para>
		/// <para>仅当将有理多项式系数指定为变换类型值时，此参数才有效。</para>
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
			/// <para>一阶多项式—区域网平差计算采用一阶多项式（仿射）。 这是默认设置。</para>
			/// </summary>
			[GPValue("POLYORDER1")]
			[Description("一阶多项式")]
			POLYORDER1,

			/// <summary>
			/// <para>零阶多项式—区域网平差计算采用零阶多项式。 当您的数据位于平坦区域时，通常使用此方法。</para>
			/// </summary>
			[GPValue("POLYORDER0")]
			[Description("零阶多项式")]
			POLYORDER0,

			/// <summary>
			/// <para>有理多项式系数—有理多项式系数将用于变换中。 用于在元数据中包含 RPC 信息的卫星影像。该选项要求要有 ArcGIS Desktop Advanced 许可。</para>
			/// </summary>
			[GPValue("RPC")]
			[Description("有理多项式系数")]
			Rational_Polynomial_Coefficients,

			/// <summary>
			/// <para>帧照相机模型—帧照相机模型将用于变换中。 用于在元数据中包含帧照相机信息的航空影像。该选项要求要有 ArcGIS Desktop Advanced 许可。</para>
			/// </summary>
			[GPValue("Frame")]
			[Description("帧照相机模型")]
			Frame_camera_model,

		}

		/// <summary>
		/// <para>Image Location Accuracy</para>
		/// </summary>
		public enum LocationAccuracyEnum 
		{
			/// <summary>
			/// <para>低精度—精度大于 100 米。</para>
			/// </summary>
			[GPValue("LOW")]
			[Description("低精度")]
			Low_accuracy,

			/// <summary>
			/// <para>中等精度—精度介于 31 米到 100 米之间。 这是默认设置。</para>
			/// </summary>
			[GPValue("MEDIUM")]
			[Description("中等精度")]
			Medium_accuracy,

			/// <summary>
			/// <para>高精度—精度小于 30 米。</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("高精度")]
			High_accuracy,

			/// <summary>
			/// <para>极高精度—影像是使用高精度的差分 GPS（例如 RTK 或 PPK）收集的。 此选项将在进行区域网平差期间保持影像位置固定。</para>
			/// </summary>
			[GPValue("VERY_HIGH")]
			[Description("极高精度")]
			Very_High_accuracy,

		}

#endregion
	}
}
