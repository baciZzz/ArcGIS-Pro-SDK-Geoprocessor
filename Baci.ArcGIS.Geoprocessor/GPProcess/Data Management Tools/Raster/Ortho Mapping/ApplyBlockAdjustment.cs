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
	/// <para>应用区域网平差</para>
	/// <para>将地理校正应用到镶嵌数据集项目。该工具使用计算区域网平差工具中的解决方案表。</para>
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
		/// <para>要校正的输入镶嵌数据集。</para>
		/// </param>
		/// <param name="AdjustmentOperation">
		/// <para>Adjustment Operation</para>
		/// <para>选择是希望使用解决方案表校正镶嵌数据集还是要重置镶嵌数据集而不应用任何校正。</para>
		/// <para>校正镶嵌数据集—使用输入解决方案表校正镶嵌数据集。</para>
		/// <para>重置镶嵌数据集—重置镶嵌数据集，而不应用任何校正。</para>
		/// <para>重新激活图像状态—在校正过程中删除的图像将恢复为活动状态。在标准校正操作中，系统将在计算中删除无校正所需最小控制点数限制的图像，这样轮廓线表中的图像就会被分类为非活动状态，maxPS 值将设置为 0，影像在地图中不可见，且所删除图像的连接点状态将变为已禁用。此选项会将 Category 状态还原为主状态，并确保恢复 maxPS 值。校正过程中涉及的图像则不受此选项影响。</para>
		/// <para><see cref="AdjustmentOperationEnum"/></para>
		/// </param>
		public ApplyBlockAdjustment(object InMosaicDataset, object AdjustmentOperation)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.AdjustmentOperation = AdjustmentOperation;
		}

		/// <summary>
		/// <para>Tool Display Name : 应用区域网平差</para>
		/// </summary>
		public override string DisplayName() => "应用区域网平差";

		/// <summary>
		/// <para>Tool Name : ApplyBlockAdjustment</para>
		/// </summary>
		public override string ToolName() => "ApplyBlockAdjustment";

		/// <summary>
		/// <para>Tool Excute Name : management.ApplyBlockAdjustment</para>
		/// </summary>
		public override string ExcuteName() => "management.ApplyBlockAdjustment";

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
		public override object[] Parameters() => new object[] { InMosaicDataset, AdjustmentOperation, InputSolutionTable, PanToMsScalingFactor, OutMosaicDataset, DEM, Zoffset, ControlPointTable, AdjustFootprints, SolutionPointTable, OutControlPointTable };

		/// <summary>
		/// <para>Input Mosaic Dataset</para>
		/// <para>要校正的输入镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Adjustment Operation</para>
		/// <para>选择是希望使用解决方案表校正镶嵌数据集还是要重置镶嵌数据集而不应用任何校正。</para>
		/// <para>校正镶嵌数据集—使用输入解决方案表校正镶嵌数据集。</para>
		/// <para>重置镶嵌数据集—重置镶嵌数据集，而不应用任何校正。</para>
		/// <para>重新激活图像状态—在校正过程中删除的图像将恢复为活动状态。在标准校正操作中，系统将在计算中删除无校正所需最小控制点数限制的图像，这样轮廓线表中的图像就会被分类为非活动状态，maxPS 值将设置为 0，影像在地图中不可见，且所删除图像的连接点状态将变为已禁用。此选项会将 Category 状态还原为主状态，并确保恢复 maxPS 值。校正过程中涉及的图像则不受此选项影响。</para>
		/// <para><see cref="AdjustmentOperationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AdjustmentOperation { get; set; } = "ADJUST";

		/// <summary>
		/// <para>Input Solution Table</para>
		/// <para>指定校正镶嵌数据集时使用的解决方案表。这是计算区域网平差工具的输出。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		public object InputSolutionTable { get; set; }

		/// <summary>
		/// <para>Pan-To-MS Scaling Factor</para>
		/// <para>如果镶嵌数据集中包含全色锐化栅格，请指定全色锐化分辨率和多光谱分辨率之间的比例因子。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object PanToMsScalingFactor { get; set; }

		/// <summary>
		/// <para>Updated Input Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Input DEM</para>
		/// <para>在区域网平差中使用的 DEM。仅当此 DEM 比已存在于镶嵌数据集中的 DEM 分辨率高时才会用到它。</para>
		/// <para>如果使用了此输入 DEM，则镶嵌数据集的几何函数将使用此输入进行更新。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object DEM { get; set; }

		/// <summary>
		/// <para>Z offset</para>
		/// <para>垂直偏移用于调整镶嵌数据集几何函数中的高程图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Zoffset { get; set; }

		/// <summary>
		/// <para>Control Point Table</para>
		/// <para>输入控制点表有与解决方案校正中应用的相同的校正。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		public object ControlPointTable { get; set; }

		/// <summary>
		/// <para>Adjust Footprints</para>
		/// <para>使用与应用至影像相同的变换来选择是否更新轮廓线几何。</para>
		/// <para>未选中 - 不要更新轮廓线几何。这是默认设置。</para>
		/// <para>选中 - 将轮廓线几何更新至影像几何。如果提供了控制点表，也可以将其转换。</para>
		/// <para><see cref="AdjustFootprintsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object AdjustFootprints { get; set; } = "false";

		/// <summary>
		/// <para>Solution Point Table</para>
		/// <para>指定用于更新控制点表状态字段的解决方案点表。只能在设置了控制点表参数时使用此参数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPTableView()]
		public object SolutionPointTable { get; set; }

		/// <summary>
		/// <para>Output Control Points</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTableView()]
		public object OutControlPointTable { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Adjustment Operation</para>
		/// </summary>
		public enum AdjustmentOperationEnum 
		{
			/// <summary>
			/// <para>校正镶嵌数据集—使用输入解决方案表校正镶嵌数据集。</para>
			/// </summary>
			[GPValue("ADJUST")]
			[Description("校正镶嵌数据集")]
			Adjust_the_mosaic_dataset,

			/// <summary>
			/// <para>重置镶嵌数据集—重置镶嵌数据集，而不应用任何校正。</para>
			/// </summary>
			[GPValue("RESET")]
			[Description("重置镶嵌数据集")]
			Reset_the_mosaic_dataset,

			/// <summary>
			/// <para>重新激活图像状态—在校正过程中删除的图像将恢复为活动状态。在标准校正操作中，系统将在计算中删除无校正所需最小控制点数限制的图像，这样轮廓线表中的图像就会被分类为非活动状态，maxPS 值将设置为 0，影像在地图中不可见，且所删除图像的连接点状态将变为已禁用。此选项会将 Category 状态还原为主状态，并确保恢复 maxPS 值。校正过程中涉及的图像则不受此选项影响。</para>
			/// </summary>
			[GPValue("REACTIVATE")]
			[Description("重新激活图像状态")]
			Reactivate_image_status,

		}

		/// <summary>
		/// <para>Adjust Footprints</para>
		/// </summary>
		public enum AdjustFootprintsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ADJUST_FOOTPRINTS")]
			ADJUST_FOOTPRINTS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_ADJUST_FOOTPRINTS")]
			NO_ADJUST_FOOTPRINTS,

		}

#endregion
	}
}
