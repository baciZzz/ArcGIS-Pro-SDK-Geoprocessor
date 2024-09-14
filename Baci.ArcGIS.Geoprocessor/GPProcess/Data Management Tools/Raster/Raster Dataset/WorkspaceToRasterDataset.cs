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
	/// <para>工作空间转栅格数据集</para>
	/// <para>将文件夹中的所有栅格数据集合并为一个栅格数据集。</para>
	/// </summary>
	public class WorkspaceToRasterDataset : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Workspace</para>
		/// <para>包含要合并的栅格数据集的文件夹。</para>
		/// </param>
		/// <param name="InRasterDataset">
		/// <para>Target Raster Dataset</para>
		/// <para>要在其中合并输入工作空间内所有栅格数据集的现有栅格数据集。</para>
		/// </param>
		public WorkspaceToRasterDataset(object InWorkspace, object InRasterDataset)
		{
			this.InWorkspace = InWorkspace;
			this.InRasterDataset = InRasterDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 工作空间转栅格数据集</para>
		/// </summary>
		public override string DisplayName() => "工作空间转栅格数据集";

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
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWorkspace, InRasterDataset, IncludeSubdirectories, MosaicType, Colormap, BackgroundValue, NodataValue, OnebitToEightbit, MosaickingTolerance, Matchingmethod, ColormapToRGB, OutRasterDataset };

		/// <summary>
		/// <para>Input Workspace</para>
		/// <para>包含要合并的栅格数据集的文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Target Raster Dataset</para>
		/// <para>要在其中合并输入工作空间内所有栅格数据集的现有栅格数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DERasterDataset()]
		public object InRasterDataset { get; set; }

		/// <summary>
		/// <para>Include Sub-directories</para>
		/// <para>指定是否包含子目录。</para>
		/// <para>未选中 - 不包括子目录。 这是默认设置。</para>
		/// <para>选中 - 加载时包括子目录中的所有栅格数据集。</para>
		/// <para><see cref="IncludeSubdirectoriesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object IncludeSubdirectories { get; set; } = "false";

		/// <summary>
		/// <para>Mosaic Operator</para>
		/// <para>指定将用于镶嵌重叠区域的方法。</para>
		/// <para>第一个—叠置区域的输出像元值为镶嵌到该位置的第一个栅格数据集中的值。</para>
		/// <para>最后一个—叠置区域的输出像元值为镶嵌到该位置的最后一个栅格数据集中的值。这是默认设置。</para>
		/// <para>混合—叠置区域的输出像元值为叠置区域中各像元值的水平加权计算结果。</para>
		/// <para>平均值—重叠区域的输出像元值为叠置像元的平均值。</para>
		/// <para>最小值—重叠区域的输出像元值为叠置像元的最小值。</para>
		/// <para>最大值—重叠区域的输出像元值为叠置像元的最大值。</para>
		/// <para>总和—重叠区域的输出像元值为叠置像元的总和。</para>
		/// <para><see cref="MosaicTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MosaicType { get; set; } = "LAST";

		/// <summary>
		/// <para>Mosaic Colormap Mode</para>
		/// <para>指定对输入栅格中应用于镶嵌输出的色彩映射表进行选择的方法。</para>
		/// <para>第一个—列表中第一个栅格数据集中的色彩映射表将应用于输出栅格镶嵌。这是默认设置。</para>
		/// <para>最后一个—列表中最后一个栅格数据集中的色彩映射表将应用于输出栅格镶嵌。</para>
		/// <para>匹配—镶嵌时将考虑所有色彩映射表。如果已经使用了所有可能的值（对于位深度），则该工具将与具有最接近的可用色彩的值进行匹配。</para>
		/// <para>拒绝—仅对那些不包含关联色彩映射表的栅格数据集进行镶嵌。</para>
		/// <para><see cref="ColormapEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Colormap { get; set; } = "FIRST";

		/// <summary>
		/// <para>Ignore Background Value</para>
		/// <para>使用此选项移除在栅格数据周围创建的不需要的值。 指定的值与栅格数据集中的其他有用数据不同。 例如，栅格边界上为零的值不同于栅格数据集内的零值。</para>
		/// <para>指定的像素值在输出栅格数据集中将被设置为 NoData。</para>
		/// <para>对于基于文件的栅格，为了忽略背景值，忽略背景值必须设置为与 NoData 相同的值。企业级和文件地理数据库栅格无需经过此额外步骤即可忽略背景值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object BackgroundValue { get; set; }

		/// <summary>
		/// <para>NoData Value</para>
		/// <para>具有指定值的所有像素将在输出栅格数据集中被设置为 NoData。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object NodataValue { get; set; }

		/// <summary>
		/// <para>Convert 1 bit data to 8 bit</para>
		/// <para>选择是否将输入 1 位栅格数据集转换为 8 位栅格数据集。 使用这种转换方法时，输入栅格数据集中的值 1 将在输出栅格数据集中更改为 255。 这在将 1 位栅格数据集导入地理数据库时十分有用。 1 位栅格数据集存储在文件系统中时包含 8 位金字塔图层，但在地理数据库中，1 位栅格数据集只能包含 1 位金字塔图层，这使得显示画面看起来没有吸引力。 通过在地理数据库中将数据转换为 8 位，可将金字塔图层构建为 8 位而非 1 位，从而在显示画面中生成适合的栅格数据集。</para>
		/// <para>未选中 - 不执行任何转换。 这是默认设置。</para>
		/// <para>选中 - 将转换输入栅格。</para>
		/// <para><see cref="OnebitToEightbitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object OnebitToEightbit { get; set; } = "false";

		/// <summary>
		/// <para>Mosaicking Tolerance</para>
		/// <para>发生镶嵌时，目标及源像素并不总是准确地排成直线。如果像素未对齐，则需要确定是重新采样还是平移数据。镶嵌容差可控制是否对像素执行重采样，或者是否平移像素。</para>
		/// <para>如果（传入的数据集与目标数据集之间的）像素偏差大于该容差，则执行重采样。如果（传入的数据集与目标数据集之间的）像素偏差小于该容差，则不执行重采样，而是执行平移。</para>
		/// <para>容差的单位为像素，有效值范围为 0 到 0.5。容差为 0.5 会保证发生平移。存在像素偏差时，容差为零会保证执行重采样。</para>
		/// <para>例如，源像素和目标像素的偏差值为 0.25。如果将镶嵌容差设置为 0.2，由于像素偏差大于该容差，因此将执行重采样。如果将镶嵌容差设置为 0.3，则会平移像素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MosaickingTolerance { get; set; } = "0";

		/// <summary>
		/// <para>Color Matching Method</para>
		/// <para>应用于栅格的色彩匹配方法。</para>
		/// <para>无—当镶嵌栅格数据集时，此选项不会使用色彩匹配操作。</para>
		/// <para>匹配统计数据—此方法将使用重叠区域中的描述统计；然后将变换应用于整个目标数据集。</para>
		/// <para>匹配直方图—此方法将引用重叠区域与源重叠区域的直方图进行匹配；然后将变换应用于整个目标数据集。</para>
		/// <para>线性相关—此方法将对重叠像素进行匹配，然后对源数据集的其余部分进行插值；不具有一对一关系的像素将使用加权平均值。</para>
		/// <para><see cref="MatchingmethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Matchingmethod { get; set; } = "NONE";

		/// <summary>
		/// <para>Colormap to RGB</para>
		/// <para>如果输入栅格数据集具有色彩映射表，则可将输出栅格数据集转换为三波段输出栅格数据集。 这在镶嵌包含不同色彩映射表的栅格时很有用。</para>
		/// <para>未选中 - 不发生任何转换。 这是默认设置。</para>
		/// <para>选中 - 将转换输入数据集。</para>
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
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("INCLUDE_SUBDIRECTORIES")]
			INCLUDE_SUBDIRECTORIES,

			/// <summary>
			/// <para></para>
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
			/// <para>第一个—叠置区域的输出像元值为镶嵌到该位置的第一个栅格数据集中的值。</para>
			/// </summary>
			[GPValue("FIRST")]
			[Description("第一个")]
			First,

			/// <summary>
			/// <para>最后一个—叠置区域的输出像元值为镶嵌到该位置的最后一个栅格数据集中的值。这是默认设置。</para>
			/// </summary>
			[GPValue("LAST")]
			[Description("最后一个")]
			Last,

			/// <summary>
			/// <para>混合—叠置区域的输出像元值为叠置区域中各像元值的水平加权计算结果。</para>
			/// </summary>
			[GPValue("BLEND")]
			[Description("混合")]
			Blend,

			/// <summary>
			/// <para>平均值—重叠区域的输出像元值为叠置像元的平均值。</para>
			/// </summary>
			[GPValue("MEAN")]
			[Description("平均值")]
			Mean,

			/// <summary>
			/// <para>最小值—重叠区域的输出像元值为叠置像元的最小值。</para>
			/// </summary>
			[GPValue("MINIMUM")]
			[Description("最小值")]
			Minimum,

			/// <summary>
			/// <para>最大值—重叠区域的输出像元值为叠置像元的最大值。</para>
			/// </summary>
			[GPValue("MAXIMUM")]
			[Description("最大值")]
			Maximum,

			/// <summary>
			/// <para>总和—重叠区域的输出像元值为叠置像元的总和。</para>
			/// </summary>
			[GPValue("SUM")]
			[Description("总和")]
			Sum,

		}

		/// <summary>
		/// <para>Mosaic Colormap Mode</para>
		/// </summary>
		public enum ColormapEnum 
		{
			/// <summary>
			/// <para>拒绝—仅对那些不包含关联色彩映射表的栅格数据集进行镶嵌。</para>
			/// </summary>
			[GPValue("REJECT")]
			[Description("拒绝")]
			Reject,

			/// <summary>
			/// <para>第一个—列表中第一个栅格数据集中的色彩映射表将应用于输出栅格镶嵌。这是默认设置。</para>
			/// </summary>
			[GPValue("FIRST")]
			[Description("第一个")]
			First,

			/// <summary>
			/// <para>最后一个—列表中最后一个栅格数据集中的色彩映射表将应用于输出栅格镶嵌。</para>
			/// </summary>
			[GPValue("LAST")]
			[Description("最后一个")]
			Last,

			/// <summary>
			/// <para>匹配—镶嵌时将考虑所有色彩映射表。如果已经使用了所有可能的值（对于位深度），则该工具将与具有最接近的可用色彩的值进行匹配。</para>
			/// </summary>
			[GPValue("MATCH")]
			[Description("匹配")]
			Match,

		}

		/// <summary>
		/// <para>Convert 1 bit data to 8 bit</para>
		/// </summary>
		public enum OnebitToEightbitEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("OneBitTo8Bit")]
			OneBitTo8Bit,

			/// <summary>
			/// <para></para>
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
			/// <para>无—当镶嵌栅格数据集时，此选项不会使用色彩匹配操作。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>匹配统计数据—此方法将使用重叠区域中的描述统计；然后将变换应用于整个目标数据集。</para>
			/// </summary>
			[GPValue("STATISTIC_MATCHING")]
			[Description("匹配统计数据")]
			Match_statistics,

			/// <summary>
			/// <para>匹配直方图—此方法将引用重叠区域与源重叠区域的直方图进行匹配；然后将变换应用于整个目标数据集。</para>
			/// </summary>
			[GPValue("HISTOGRAM_MATCHING")]
			[Description("匹配直方图")]
			Match_histogram,

			/// <summary>
			/// <para>线性相关—此方法将对重叠像素进行匹配，然后对源数据集的其余部分进行插值；不具有一对一关系的像素将使用加权平均值。</para>
			/// </summary>
			[GPValue("LINEARCORRELATION_MATCHING")]
			[Description("线性相关")]
			Linear_correlation,

		}

		/// <summary>
		/// <para>Colormap to RGB</para>
		/// </summary>
		public enum ColormapToRGBEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("ColormapToRGB")]
			ColormapToRGB,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NONE")]
			NONE,

		}

#endregion
	}
}
