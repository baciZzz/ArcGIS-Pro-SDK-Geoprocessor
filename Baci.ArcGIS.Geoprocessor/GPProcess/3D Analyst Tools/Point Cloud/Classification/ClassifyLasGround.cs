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
	/// <para>Classify LAS Ground</para>
	/// <para>分类 LAS 地面</para>
	/// <para>LAS 数据中的地面点。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ClassifyLasGround : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。 仅评估类代码值为 0、1 或 2 的 LAS 点的最近返回结果。</para>
		/// </param>
		public ClassifyLasGround(object InLasDataset)
		{
			this.InLasDataset = InLasDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 分类 LAS 地面</para>
		/// </summary>
		public override string DisplayName() => "分类 LAS 地面";

		/// <summary>
		/// <para>Tool Name : ClassifyLasGround</para>
		/// </summary>
		public override string ToolName() => "ClassifyLasGround";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ClassifyLasGround</para>
		/// </summary>
		public override string ExcuteName() => "3d.ClassifyLasGround";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, Method, ReuseGround, DemResolution, ComputeStats, Extent, Boundary, ProcessEntireFiles, OutLasDataset, UpdatePyramid };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。 仅评估类代码值为 0、1 或 2 的 LAS 点的最近返回结果。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Ground Detection Method</para>
		/// <para>指定将用于检测地面点的方法。</para>
		/// <para>标准分类—该方法对坡度变化具有容差，因此可以捕获到使用保守的传统方法无法捕获到的地面地形上的平缓波动，但是该方法无法捕获到通过激进方法捕获到的坡度起伏较大的地貌波动。 这是默认设置。</para>
		/// <para>传统分类—与其他方法相比，该方法对地面坡度的变化使用了更为严格的限制，因此该方法可将地面与草地和灌木丛等低地植被区分开来。 该方法最适合最小曲率的地形。</para>
		/// <para>大胆分类—对于标准分类方法容易忽略的山脊和山顶等地貌起伏较大的地面区域，此方法可检测到这些内容。 该方法最好在重新使用现有地面参数选中的情况下用于该工具的第二次迭代。 该方法不宜用于城市区域或地势平坦的乡村区域，因为可能会将地势较高的对象（例如，发电塔、植被和建筑物局部）错误分类为地面。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "STANDARD";

		/// <summary>
		/// <para>Reuse existing ground</para>
		/// <para>指定现有地面点是否会重新分类或重新使用。</para>
		/// <para>未选中 - 现有地面点将会重新分类。 将会为不属于地面的点重新分配类代码值 1，表示未分类的点。 这是默认设置。</para>
		/// <para>选中 - 现有地面点不经详查即可接受并重用，且可帮助确定未分类的点。</para>
		/// <para><see cref="ReuseGroundEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ReuseGround { get; set; } = "false";

		/// <summary>
		/// <para>DEM Resolution</para>
		/// <para>将导致仅评估分类为地面的点子集，从而加快分类过程的距离。 需要更迅速地生成 DEM 表面时可考虑使用该参数。 最小距离为 0.3 米，但指定距离必须至少为激光雷达数据平均点间距的 1.5 倍，否则该过程将无法生效。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object DemResolution { get; set; }

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
		/// <para>Processing Boundary</para>
		/// <para>定义将进行处理的感兴趣区域的面要素。</para>
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
		public ClassifyLasGround SetEnviroment(object extent = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Ground Detection Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>标准分类—该方法对坡度变化具有容差，因此可以捕获到使用保守的传统方法无法捕获到的地面地形上的平缓波动，但是该方法无法捕获到通过激进方法捕获到的坡度起伏较大的地貌波动。 这是默认设置。</para>
			/// </summary>
			[GPValue("STANDARD")]
			[Description("标准分类")]
			Standard_Classification,

			/// <summary>
			/// <para>传统分类—与其他方法相比，该方法对地面坡度的变化使用了更为严格的限制，因此该方法可将地面与草地和灌木丛等低地植被区分开来。 该方法最适合最小曲率的地形。</para>
			/// </summary>
			[GPValue("CONSERVATIVE")]
			[Description("传统分类")]
			Conservative_Classification,

			/// <summary>
			/// <para>大胆分类—对于标准分类方法容易忽略的山脊和山顶等地貌起伏较大的地面区域，此方法可检测到这些内容。 该方法最好在重新使用现有地面参数选中的情况下用于该工具的第二次迭代。 该方法不宜用于城市区域或地势平坦的乡村区域，因为可能会将地势较高的对象（例如，发电塔、植被和建筑物局部）错误分类为地面。</para>
			/// </summary>
			[GPValue("AGGRESSIVE")]
			[Description("大胆分类")]
			Aggressive_Classification,

		}

		/// <summary>
		/// <para>Reuse existing ground</para>
		/// </summary>
		public enum ReuseGroundEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REUSE_GROUND")]
			REUSE_GROUND,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("RECLASSIFY_GROUND")]
			RECLASSIFY_GROUND,

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
