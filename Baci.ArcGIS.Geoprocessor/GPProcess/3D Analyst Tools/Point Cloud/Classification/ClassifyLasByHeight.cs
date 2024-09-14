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
	/// <para>Classify LAS By Height</para>
	/// <para>按高度分类 LAS</para>
	/// <para>基于距离地表的高度对激光雷达点进行重分类。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ClassifyLasByHeight : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>将要处理的 LAS 数据集。 将仅对类代码值为 0 和 1 的 LAS 点进行评估。</para>
		/// </param>
		/// <param name="GroundSource">
		/// <para>Ground Source</para>
		/// <para>指定将用于确定距离地面高度的地面测量的资源。</para>
		/// <para>所有地面点—将使用通过地面分类代码值 2 和模型关键代码值 8 指定的 LAS 点。</para>
		/// <para>模型关键点—将仅使用通过模型关键分类代码值 8 指定的 LAS 点。</para>
		/// <para><see cref="GroundSourceEnum"/></para>
		/// </param>
		/// <param name="HeightClassification">
		/// <para>Height Classification</para>
		/// <para>将用于对 LAS 点进行重分类的类代码和距离地面的最大高度。 表中各个类的顺序可定义将用于处理重分类的 z 值的范围。 第一个条目的 z 范围将从地表跨越到指定的距离地面高度值。 后续条目的 z 范围将从先前条目的上限跨越到其自身的距离地面高度值。</para>
		/// </param>
		public ClassifyLasByHeight(object InLasDataset, object GroundSource, object HeightClassification)
		{
			this.InLasDataset = InLasDataset;
			this.GroundSource = GroundSource;
			this.HeightClassification = HeightClassification;
		}

		/// <summary>
		/// <para>Tool Display Name : 按高度分类 LAS</para>
		/// </summary>
		public override string DisplayName() => "按高度分类 LAS";

		/// <summary>
		/// <para>Tool Name : ClassifyLasByHeight</para>
		/// </summary>
		public override string ToolName() => "ClassifyLasByHeight";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ClassifyLasByHeight</para>
		/// </summary>
		public override string ExcuteName() => "3d.ClassifyLasByHeight";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, GroundSource, HeightClassification, Noise, ComputeStats, Extent, ProcessEntireFiles, Boundary, OutLasDataset, UpdatePyramid };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>将要处理的 LAS 数据集。 将仅对类代码值为 0 和 1 的 LAS 点进行评估。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Ground Source</para>
		/// <para>指定将用于确定距离地面高度的地面测量的资源。</para>
		/// <para>所有地面点—将使用通过地面分类代码值 2 和模型关键代码值 8 指定的 LAS 点。</para>
		/// <para>模型关键点—将仅使用通过模型关键分类代码值 8 指定的 LAS 点。</para>
		/// <para><see cref="GroundSourceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object GroundSource { get; set; } = "GROUND";

		/// <summary>
		/// <para>Height Classification</para>
		/// <para>将用于对 LAS 点进行重分类的类代码和距离地面的最大高度。 表中各个类的顺序可定义将用于处理重分类的 z 值的范围。 第一个条目的 z 范围将从地表跨越到指定的距离地面高度值。 后续条目的 z 范围将从先前条目的上限跨越到其自身的距离地面高度值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		public object HeightClassification { get; set; } = "3 5;4 25;5 50";

		/// <summary>
		/// <para>Noise Classification</para>
		/// <para>根据点距离地面的临近性指定是否对点进行重分类和如何进行重分类。 激光雷达数据中的噪点伪影可由传感器错误和空中障碍物（例如，位于激光雷达脉冲路径上的鸟类）的无意拦截引入。</para>
		/// <para>低噪音和高噪音—低噪点和高噪点都将得到分类。</para>
		/// <para>高噪音—只有大于 LAS 分类表中最大高度的点才会被重分类为高噪点。</para>
		/// <para>低噪音—只有低于地表的点才会被重分类为噪点。 此选项仅适用于所有地面点都用于定义地表时。</para>
		/// <para>无—没有将被重分类为噪点的点。</para>
		/// <para><see cref="NoiseEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Noise { get; set; } = "NONE";

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
		/// <para>指定处理范围的应用方式。</para>
		/// <para>未选中 - 将仅对处理范围内的 LAS 点进行评估。 这是默认设置。</para>
		/// <para>选中 - 将对处理范围相交的 .las 文件中的所有点进行评估。</para>
		/// <para><see cref="ProcessEntireFilesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Processing Extent")]
		public object ProcessEntireFiles { get; set; } = "false";

		/// <summary>
		/// <para>Processing Boundary</para>
		/// <para>定义评估 LAS 地面点所在区域的面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[Category("Processing Extent")]
		public object Boundary { get; set; }

		/// <summary>
		/// <para>Updated Input LAS Dataset</para>
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
		public ClassifyLasByHeight SetEnviroment(object extent = null, object workspace = null)
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Ground Source</para>
		/// </summary>
		public enum GroundSourceEnum 
		{
			/// <summary>
			/// <para>所有地面点—将使用通过地面分类代码值 2 和模型关键代码值 8 指定的 LAS 点。</para>
			/// </summary>
			[GPValue("GROUND")]
			[Description("所有地面点")]
			All_Ground_Points,

			/// <summary>
			/// <para>模型关键点—将仅使用通过模型关键分类代码值 8 指定的 LAS 点。</para>
			/// </summary>
			[GPValue("MODEL_KEY")]
			[Description("模型关键点")]
			Model_Key_Points,

		}

		/// <summary>
		/// <para>Noise Classification</para>
		/// </summary>
		public enum NoiseEnum 
		{
			/// <summary>
			/// <para>无—没有将被重分类为噪点的点。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>低噪音和高噪音—低噪点和高噪点都将得到分类。</para>
			/// </summary>
			[GPValue("LOW_NOISE")]
			[Description("低噪音")]
			Low_Noise,

			/// <summary>
			/// <para>高噪音—只有大于 LAS 分类表中最大高度的点才会被重分类为高噪点。</para>
			/// </summary>
			[GPValue("HIGH_NOISE")]
			[Description("高噪音")]
			High_Noise,

			/// <summary>
			/// <para>低噪音和高噪音—低噪点和高噪点都将得到分类。</para>
			/// </summary>
			[GPValue("ALL_NOISE")]
			[Description("低噪音和高噪音")]
			Low_and_High_Noise,

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
