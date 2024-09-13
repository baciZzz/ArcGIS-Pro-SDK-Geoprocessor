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
	/// <para>Classify LAS Noise</para>
	/// <para>分类 LAS 噪声</para>
	/// <para>将具有异常空间特征的 LAS 点分类为噪点。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ClassifyLasNoise : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </param>
		public ClassifyLasNoise(object InLasDataset)
		{
			this.InLasDataset = InLasDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 分类 LAS 噪声</para>
		/// </summary>
		public override string DisplayName() => "分类 LAS 噪声";

		/// <summary>
		/// <para>Tool Name : ClassifyLasNoise</para>
		/// </summary>
		public override string ToolName() => "ClassifyLasNoise";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ClassifyLasNoise</para>
		/// </summary>
		public override string ExcuteName() => "3d.ClassifyLasNoise";

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
		public override string[] ValidEnvironments() => new string[] { "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, Method, EditLas, Withheld, ComputeStats, Ground, LowZ, HighZ, MaxNeighbors, StepWidth, StepHeight, Extent, ProcessEntireFiles, OutFeatureClass, OutLasDataset, UpdatePyramid };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>指定将使用的噪点检测方法。</para>
		/// <para>孤立—按分块体积对 LAS 点进行分析，以确定噪音测量点以及基于高度的噪点检测。 这是默认设置。</para>
		/// <para>距离地面相对高度—所有低于距地表指定最小高度和高于距地表指定最大高度的点均将标识为噪点。</para>
		/// <para>绝对高度—所有相对于平均海平面，低于指定最小高度和高于指定最大高度的点均将被标识为噪点。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "ISOLATION";

		/// <summary>
		/// <para>Edit Classification</para>
		/// <para>指定是否对标识为噪点的 LAS 点进行重分类。</para>
		/// <para>选中 - 将对噪点进行重分类。 这是默认设置。</para>
		/// <para>未选中 - 将不对噪点进行分类。</para>
		/// <para><see cref="EditLasEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object EditLas { get; set; } = "true";

		/// <summary>
		/// <para>Assign Withheld Flag</para>
		/// <para>指定是否为噪点分配保留分类标记。 此选项仅在选中编辑分类参数后强制使用。</para>
		/// <para>选中 - 将为噪点分配保留分类标记。</para>
		/// <para>未选中 - 不为噪点分配保留分类标记。 这是默认设置。</para>
		/// <para><see cref="WithheldEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Withheld { get; set; } = "false";

		/// <summary>
		/// <para>Compute statistics</para>
		/// <para>指定是否将计算 LAS 数据集引用的 .las 文件的统计数据。 计算统计数据时会为每个 .las 文件提供一个空间索引，从而提高了分析和显示性能。 统计数据还可通过将 LAS 属性（例如分类代码和返回信息）显示限制为 .las 文件中存在的值来提升过滤和符号系统体验。</para>
		/// <para>选中 - 将计算统计数据。 这是默认设置。</para>
		/// <para>未选中 - 不计算统计数据。</para>
		/// <para><see cref="ComputeStatsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ComputeStats { get; set; } = "true";

		/// <summary>
		/// <para>Ground</para>
		/// <para>用于定义相对高度的地表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPRasterLayer()]
		[Category("Height Detection")]
		public object Ground { get; set; }

		/// <summary>
		/// <para>Minimum Height</para>
		/// <para>将针对标识噪点来定义最低 z 值阈值的高度。 任何低于指定值的点将分类为噪点。 如果指定了地表，则此阈值将以距离地面的偏移为基础，因此，值 -3 英尺表示地表以下 3 英尺的所有点将分类为噪点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Height Detection")]
		public object LowZ { get; set; }

		/// <summary>
		/// <para>Maximum Height</para>
		/// <para>将针对标识噪点来定义最高 z 值阈值的高度。 任何高于指定值的点将分类为噪点。 如果提供了地表，则此阈值将以距离地面的偏移为基础，因此，值 250 米表示地表以上 250 米的所有点将分类为噪点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Height Detection")]
		public object HighZ { get; set; }

		/// <summary>
		/// <para>Neighborhood Point Limit</para>
		/// <para>使用孤立方法时，分析体积内可分类为噪点的最大点数。 如果分析体积包含等于或小于此值的任意数量的 LAS 点，则将这些点分类为噪点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Category("Isolation Detection")]
		public object MaxNeighbors { get; set; }

		/// <summary>
		/// <para>Neighborhood Width</para>
		/// <para>使用孤立方法时，分析体积的 XY 空间中各维度的尺寸。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Isolation Detection")]
		public object StepWidth { get; set; }

		/// <summary>
		/// <para>Neighborhood Height</para>
		/// <para>使用孤立方法时，分析体积的高度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Isolation Detection")]
		public object StepHeight { get; set; }

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
		/// <para>Output Noise Points</para>
		/// <para>用于表示标识为噪点的 LAS 点的输出点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Output LAS Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLasDatasetLayer()]
		public object OutLasDataset { get; set; }

		/// <summary>
		/// <para>Update pyramid</para>
		/// <para>指定修改类代码后，LAS 数据集金字塔是否会更新。</para>
		/// <para>选中 - LAS 数据集金字塔将更新。 这是默认设置。</para>
		/// <para>未选中 - LAS 数据集金字塔不会更新。</para>
		/// <para><see cref="UpdatePyramidEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object UpdatePyramid { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ClassifyLasNoise SetEnviroment(object geographicTransformations = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>孤立—按分块体积对 LAS 点进行分析，以确定噪音测量点以及基于高度的噪点检测。 这是默认设置。</para>
			/// </summary>
			[GPValue("ISOLATION")]
			[Description("孤立")]
			Isolation,

			/// <summary>
			/// <para>距离地面相对高度—所有低于距地表指定最小高度和高于距地表指定最大高度的点均将标识为噪点。</para>
			/// </summary>
			[GPValue("RELATIVE_HEIGHT")]
			[Description("距离地面相对高度")]
			Relative_Height_from_Ground,

			/// <summary>
			/// <para>绝对高度—所有相对于平均海平面，低于指定最小高度和高于指定最大高度的点均将被标识为噪点。</para>
			/// </summary>
			[GPValue("ABSOLUTE_HEIGHT")]
			[Description("绝对高度")]
			Absolute_Height,

		}

		/// <summary>
		/// <para>Edit Classification</para>
		/// </summary>
		public enum EditLasEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CLASSIFY")]
			CLASSIFY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CLASSIFY")]
			NO_CLASSIFY,

		}

		/// <summary>
		/// <para>Assign Withheld Flag</para>
		/// </summary>
		public enum WithheldEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("WITHHELD")]
			WITHHELD,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_WITHHELD")]
			NO_WITHHELD,

		}

		/// <summary>
		/// <para>Compute statistics</para>
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
		/// <para>Update pyramid</para>
		/// </summary>
		public enum UpdatePyramidEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("UPDATE_PYRAMID")]
			UPDATE_PYRAMID,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_UPDATE_PYRAMID")]
			NO_UPDATE_PYRAMID,

		}

#endregion
	}
}
