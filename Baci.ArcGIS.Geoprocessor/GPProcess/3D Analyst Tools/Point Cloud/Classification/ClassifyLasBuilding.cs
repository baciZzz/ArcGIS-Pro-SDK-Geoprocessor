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
	/// <para>Classify LAS Building</para>
	/// <para>分类 LAS 建筑物</para>
	/// <para>在 LAS 数据中对建筑屋顶和侧墙进行分类。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class ClassifyLasBuilding : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>待分类的 LAS 数据集。</para>
		/// </param>
		/// <param name="MinHeight">
		/// <para>Minimum Rooftop Height</para>
		/// <para>定义可识别的屋顶点最低点距离地面的高度。</para>
		/// </param>
		/// <param name="MinArea">
		/// <para>Minimum Area</para>
		/// <para>建筑物屋顶的最小面积。</para>
		/// </param>
		public ClassifyLasBuilding(object InLasDataset, object MinHeight, object MinArea)
		{
			this.InLasDataset = InLasDataset;
			this.MinHeight = MinHeight;
			this.MinArea = MinArea;
		}

		/// <summary>
		/// <para>Tool Display Name : 分类 LAS 建筑物</para>
		/// </summary>
		public override string DisplayName() => "分类 LAS 建筑物";

		/// <summary>
		/// <para>Tool Name : ClassifyLasBuilding</para>
		/// </summary>
		public override string ToolName() => "ClassifyLasBuilding";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ClassifyLasBuilding</para>
		/// </summary>
		public override string ExcuteName() => "3d.ClassifyLasBuilding";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "parallelProcessingFactor" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, MinHeight, MinArea, ComputeStats, Extent, Boundary, ProcessEntireFiles, DerivedLasDataset, PointSpacing, ReuseBuilding, PhotogrammetricData, Method, ClassifyAboveRoof, AboveRoofHeight, AboveRoofCode, ClassifyBelowRoof, BelowRoofCode, UpdatePyramid };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>待分类的 LAS 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Minimum Rooftop Height</para>
		/// <para>定义可识别的屋顶点最低点距离地面的高度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object MinHeight { get; set; }

		/// <summary>
		/// <para>Minimum Area</para>
		/// <para>建筑物屋顶的最小面积。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPArealUnit()]
		public object MinArea { get; set; }

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
		/// <para>Derived LAS Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLasDatasetLayer()]
		public object DerivedLasDataset { get; set; }

		/// <summary>
		/// <para>Average Point Spacing</para>
		/// <para>LAS 点的平均间距。 该参数不再使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object PointSpacing { get; set; }

		/// <summary>
		/// <para>Reuse existing building classified points</para>
		/// <para>指定是否将重用或重新评估现有建筑物分类点。</para>
		/// <para>未选中 - 系统将重新评估现有建筑物分类点以符合平面检测条件，且不符合指定面积和高度的点将被分配值 1。 这是默认设置。</para>
		/// <para>选中 - 现有建筑物分类点将为平面检测过程提供支持，但如果这些分类点不符合工具执行期间指定的条件，则系统不会对其进行重分类。 如果现有分类十分必要，则请使用此选项。</para>
		/// <para><see cref="ReuseBuildingEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ReuseBuilding { get; set; } = "false";

		/// <summary>
		/// <para>Is photogrammetric data</para>
		/// <para>指定是否使用摄影测量技术获取 .las 文件中的点。</para>
		/// <para>未选中 - .las 文件中的点是通过激光雷达测量而非通过产生点云的摄影测量技术获得的。 这是默认设置。</para>
		/// <para>选中 - .las 文件中的点是使用摄影测量技术基于重叠影像产生点云获得的。</para>
		/// <para><see cref="PhotogrammetricDataEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object PhotogrammetricData { get; set; } = "false";

		/// <summary>
		/// <para>Classification Method</para>
		/// <para>指定将使用的分类方法。</para>
		/// <para>激进—将以异常值的相对较高容差来检测符合平面屋顶特征的点。 如果没有精确标定这些点，则使用此方法。</para>
		/// <para>标准—将以不规则点的相对适中容差来检测符合平面屋顶特征的点。 这是默认设置</para>
		/// <para>保守—将以不规则点的相对较低容差来检测符合平面屋顶特征的点。 如果建筑物点与非建筑物对象的点共面，请使用此方法。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "STANDARD";

		/// <summary>
		/// <para>Classify points above the roof</para>
		/// <para>指定是否会对检测到的屋顶平面上方的点进行分类。</para>
		/// <para>未选中 - 不会对平面上方检测到的的点进行分类。 这是默认设置。</para>
		/// <para>选中 - 将对平面上方检测到的的点进行分类。</para>
		/// <para><see cref="ClassifyAboveRoofEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Above-Roof Classification")]
		public object ClassifyAboveRoof { get; set; } = "false";

		/// <summary>
		/// <para>Maximum Height Above Roof</para>
		/// <para>将分类为某值（在屋顶上方类代码参数中指定）的建筑屋顶上方的点的最大高度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPNumericDomain()]
		[Category("Above-Roof Classification")]
		public object AboveRoofHeight { get; set; }

		/// <summary>
		/// <para>Above Roof Class Code</para>
		/// <para>将分配给屋顶上方的点的类代码。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[Category("Above-Roof Classification")]
		public object AboveRoofCode { get; set; }

		/// <summary>
		/// <para>Classify points below the roof</para>
		/// <para>指定是否会对屋顶和地面之间的点进行分类。</para>
		/// <para>未选中 - 将不会对屋顶和地面之间的点进行分类。 这是默认设置。</para>
		/// <para>选中 - 将对屋顶和地面之间的点进行分类。</para>
		/// <para><see cref="ClassifyBelowRoofEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Below-Roof Classification")]
		public object ClassifyBelowRoof { get; set; } = "false";

		/// <summary>
		/// <para>Below Roof Class Code</para>
		/// <para>将分配给地面和屋顶之间的点的类代码。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		[Low(Inclusive = true, Value = 0)]
		[Category("Below-Roof Classification")]
		public object BelowRoofCode { get; set; }

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
		public ClassifyLasBuilding SetEnviroment(object extent = null , object parallelProcessingFactor = null )
		{
			base.SetEnv(extent: extent, parallelProcessingFactor: parallelProcessingFactor);
			return this;
		}

		#region InnerClass

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
		/// <para>Reuse existing building classified points</para>
		/// </summary>
		public enum ReuseBuildingEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REUSE_BUILDING")]
			REUSE_BUILDING,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("RECLASSIFY_BUILDING")]
			RECLASSIFY_BUILDING,

		}

		/// <summary>
		/// <para>Is photogrammetric data</para>
		/// </summary>
		public enum PhotogrammetricDataEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PHOTOGRAMMETRIC_DATA")]
			PHOTOGRAMMETRIC_DATA,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_PHOTOGRAMMETRIC_DATA")]
			NOT_PHOTOGRAMMETRIC_DATA,

		}

		/// <summary>
		/// <para>Classification Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>标准—将以不规则点的相对适中容差来检测符合平面屋顶特征的点。 这是默认设置</para>
			/// </summary>
			[GPValue("STANDARD")]
			[Description("标准")]
			Standard,

			/// <summary>
			/// <para>保守—将以不规则点的相对较低容差来检测符合平面屋顶特征的点。 如果建筑物点与非建筑物对象的点共面，请使用此方法。</para>
			/// </summary>
			[GPValue("CONSERVATIVE")]
			[Description("保守")]
			Conservative,

			/// <summary>
			/// <para>激进—将以异常值的相对较高容差来检测符合平面屋顶特征的点。 如果没有精确标定这些点，则使用此方法。</para>
			/// </summary>
			[GPValue("AGGRESSIVE")]
			[Description("激进")]
			Aggressive,

		}

		/// <summary>
		/// <para>Classify points above the roof</para>
		/// </summary>
		public enum ClassifyAboveRoofEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CLASSIFY_ABOVE_ROOF")]
			CLASSIFY_ABOVE_ROOF,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CLASSIFY_ABOVE_ROOF")]
			NO_CLASSIFY_ABOVE_ROOF,

		}

		/// <summary>
		/// <para>Classify points below the roof</para>
		/// </summary>
		public enum ClassifyBelowRoofEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CLASSIFY_BELOW_ROOF")]
			CLASSIFY_BELOW_ROOF,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CLASSIFY_BELOW_ROOF")]
			NO_CLASSIFY_BELOW_ROOF,

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
