using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.Analyst3DTools
{
	/// <summary>
	/// <para>Extract LAS</para>
	/// <para>提取 LAS</para>
	/// <para>通过 LAS 数据集或点云场景图层中的点云数据创建新的 LAS 文件。</para>
	/// </summary>
	public class ExtractLas : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input Point Cloud</para>
		/// <para>要处理的 LAS 数据集或点云场景图层。</para>
		/// </param>
		/// <param name="TargetFolder">
		/// <para>Target Folder</para>
		/// <para>输出 .las 文件将要写入的现有文件夹。</para>
		/// </param>
		public ExtractLas(object InLasDataset, object TargetFolder)
		{
			this.InLasDataset = InLasDataset;
			this.TargetFolder = TargetFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : 提取 LAS</para>
		/// </summary>
		public override string DisplayName() => "提取 LAS";

		/// <summary>
		/// <para>Tool Name : ExtractLas</para>
		/// </summary>
		public override string ToolName() => "ExtractLas";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ExtractLas</para>
		/// </summary>
		public override string ExcuteName() => "3d.ExtractLas";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise() => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, TargetFolder, Extent, Boundary, ProcessEntireFiles, NameSuffix, RemoveVlr, RearrangePoints, ComputeStats, OutLasDataset, OutFolder, Compression };

		/// <summary>
		/// <para>Input Point Cloud</para>
		/// <para>要处理的 LAS 数据集或点云场景图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Target Folder</para>
		/// <para>输出 .las 文件将要写入的现有文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object TargetFolder { get; set; }

		/// <summary>
		/// <para>Processing Extent</para>
		/// <para>待评估数据的范围。</para>
		/// <para>默认 - 该范围将基于所有参与输入的最大范围设定。这是默认设置。</para>
		/// <para>输入的并集 - 该范围将基于所有输入的最大范围。</para>
		/// <para>输入的交集 - 该范围将基于所有输入共用的最小区域。</para>
		/// <para>当前显示范围 - 该范围与可见显示范围相等。如果没有活动地图，则该选项将不可用。</para>
		/// <para>如下面的指定 - 该范围将基于指定的最小和最大范围值。</para>
		/// <para>浏览 - 该范围将基于现有数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPExtent()]
		[Category("Processing Extent")]
		public object Extent { get; set; }

		/// <summary>
		/// <para>Extraction Boundary</para>
		/// <para>定义将裁剪 .las 文件的区域的面边界。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[Category("Processing Extent")]
		public object Boundary { get; set; }

		/// <summary>
		/// <para>Process entire LAS files that intersect extent</para>
		/// <para>指定将如何使用感兴趣区以确定 .las 文件的处理方式。 感兴趣区由处理范围参数值和处理边界参数值定义，或由二者共同定义。</para>
		/// <para>未选中 - 仅处理与感兴趣区相交的 LAS 点。 这是默认设置。</para>
		/// <para>选中 - 如果 .las 文件的任何部分与感兴趣区相交，则该 .las 文件中的所有点（包括感兴趣区以外的点）都会得到处理。</para>
		/// <para><see cref="ProcessEntireFilesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Processing Extent")]
		public object ProcessEntireFiles { get; set; } = "false";

		/// <summary>
		/// <para>Output File Name Suffix</para>
		/// <para>将追加到每个输出 .las 文件名的文本。 每个文件都将从其源文件继承其基本名称，后跟此参数中指定的后缀。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("LAS File Options")]
		public object NameSuffix { get; set; }

		/// <summary>
		/// <para>Remove Variable Length Records</para>
		/// <para>指定是否删除变量长度记录 (VLR)。 每个 .las 文件都可能包含一组 VLR，由生成 VLR 的软件添加。 通常情况下，这些记录的含义仅源软件知晓。 除非由理解此类信息的应用程序处理输出 LAS 数据，否则保留 VLR 可能不会提供任何增值功能。 根据 VLR 的总大小以及包含 VLR 的文件的数量，删除 VLR 可能会节省大量磁盘空间。</para>
		/// <para>未选中 - 输入 .las 文件中的变量长度记录将不会被移除，并保留在输出 .las 文件中。 这是默认设置。</para>
		/// <para>选中 - 输入 .las 文件中的变量长度记录将从输出 .las 文件中移除。</para>
		/// <para><see cref="RemoveVlrEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object RemoveVlr { get; set; } = "false";

		/// <summary>
		/// <para>Rearrange points</para>
		/// <para>指定 .las 文件中的点是否将重新排列。</para>
		/// <para>未选中 - .las 文件中点的顺序将不会重新排列。</para>
		/// <para>选中 - 将重新排列 .las 文件中的点。 这是默认设置。</para>
		/// <para><see cref="RearrangePointsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object RearrangePoints { get; set; } = "true";

		/// <summary>
		/// <para>Compute Statistics</para>
		/// <para>指定是否将计算 LAS 数据集引用的 .las 文件的统计数据。 计算统计数据时会为每个 .las 文件提供一个空间索引，从而提高了分析和显示性能。 统计数据还可通过将 LAS 属性（例如分类代码和返回信息）显示限制为 .las 文件中存在的值来提升过滤和符号系统体验。</para>
		/// <para>选中 - 将计算统计数据。 这是默认设置。</para>
		/// <para>未选中 - 不计算统计数据。</para>
		/// <para><see cref="ComputeStatsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object ComputeStats { get; set; } = "true";

		/// <summary>
		/// <para>Output LAS Dataset</para>
		/// <para>参考新创建的 .las 文件的输出 LAS 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DELasDataset()]
		public object OutLasDataset { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object OutFolder { get; set; }

		/// <summary>
		/// <para>Compression</para>
		/// <para>指定输出 .las 文件为压缩格式还是标准 LAS 格式。</para>
		/// <para>与输入相同—压缩方法与输入 LAS 文件相同。 仅当输入为 LAS 数据集时，此选项才可用。在这种情况下，这是默认选项。</para>
		/// <para>不压缩—输出将采用标准 LAS 格式 (*.las)。 当输入为点云场景图层时，这是默认设置。</para>
		/// <para>zLAS 压缩—输出 .las 文件将以 zLAS 格式压缩。</para>
		/// <para><see cref="CompressionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("LAS File Options")]
		public object Compression { get; set; } = "SAME_AS_INPUT";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractLas SetEnviroment(object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Process entire LAS files that intersect extent</para>
		/// </summary>
		public enum ProcessEntireFilesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PROCESS_ENTIRE_FILES")]
			PROCESS_ENTIRE_FILES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("PROCESS_EXTENT")]
			PROCESS_EXTENT,

		}

		/// <summary>
		/// <para>Remove Variable Length Records</para>
		/// </summary>
		public enum RemoveVlrEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REMOVE_VLR")]
			REMOVE_VLR,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("MAINTAIN_VLR")]
			MAINTAIN_VLR,

		}

		/// <summary>
		/// <para>Rearrange points</para>
		/// </summary>
		public enum RearrangePointsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REARRANGE_POINTS")]
			REARRANGE_POINTS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("MAINTAIN_POINTS")]
			MAINTAIN_POINTS,

		}

		/// <summary>
		/// <para>Compute Statistics</para>
		/// </summary>
		public enum ComputeStatsEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("COMPUTE_STATS")]
			COMPUTE_STATS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_COMPUTE_STATS")]
			NO_COMPUTE_STATS,

		}

		/// <summary>
		/// <para>Compression</para>
		/// </summary>
		public enum CompressionEnum 
		{
			/// <summary>
			/// <para>与输入相同—压缩方法与输入 LAS 文件相同。 仅当输入为 LAS 数据集时，此选项才可用。在这种情况下，这是默认选项。</para>
			/// </summary>
			[GPValue("SAME_AS_INPUT")]
			[Description("与输入相同")]
			Same_As_Input,

			/// <summary>
			/// <para>不压缩—输出将采用标准 LAS 格式 (*.las)。 当输入为点云场景图层时，这是默认设置。</para>
			/// </summary>
			[GPValue("NO_COMPRESSION")]
			[Description("不压缩")]
			No_Compression,

			/// <summary>
			/// <para>zLAS 压缩—输出 .las 文件将以 zLAS 格式压缩。</para>
			/// </summary>
			[GPValue("ZLAS")]
			[Description("zLAS 压缩")]
			zLAS_Compression,

		}

#endregion
	}
}
