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
	/// <para>Create Terrain</para>
	/// <para>创建 Terrain</para>
	/// <para>创建 terrain 数据集</para>
	/// </summary>
	public class CreateTerrain : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureDataset">
		/// <para>Input Feature Dataset</para>
		/// <para>将包含 terrain 数据集的要素数据集。</para>
		/// </param>
		/// <param name="OutTerrainName">
		/// <para>Output Terrain</para>
		/// <para>Terrain 数据集的名称。</para>
		/// </param>
		/// <param name="AveragePointSpacing">
		/// <para>Average Point Spacing</para>
		/// <para>对 terrain 建模时所用数据点之间的平均水平距离。 对于摄影测量、激光雷达和声纳测量等基于传感器的测量，通常已知所需使用的间距。 间距使用要素数据集坐标系的水平单位。</para>
		/// </param>
		public CreateTerrain(object InFeatureDataset, object OutTerrainName, object AveragePointSpacing)
		{
			this.InFeatureDataset = InFeatureDataset;
			this.OutTerrainName = OutTerrainName;
			this.AveragePointSpacing = AveragePointSpacing;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建 Terrain</para>
		/// </summary>
		public override string DisplayName() => "创建 Terrain";

		/// <summary>
		/// <para>Tool Name : CreateTerrain</para>
		/// </summary>
		public override string ToolName() => "CreateTerrain";

		/// <summary>
		/// <para>Tool Excute Name : 3d.CreateTerrain</para>
		/// </summary>
		public override string ExcuteName() => "3d.CreateTerrain";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "configKeyword", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureDataset, OutTerrainName, AveragePointSpacing, MaxOverviewSize!, ConfigKeyword!, PyramidType!, WindowsizeMethod!, SecondaryThinningMethod!, SecondaryThinningThreshold!, DerivedOutTerrain!, TriangulationMethod! };

		/// <summary>
		/// <para>Input Feature Dataset</para>
		/// <para>将包含 terrain 数据集的要素数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object InFeatureDataset { get; set; }

		/// <summary>
		/// <para>Output Terrain</para>
		/// <para>Terrain 数据集的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutTerrainName { get; set; }

		/// <summary>
		/// <para>Average Point Spacing</para>
		/// <para>对 terrain 建模时所用数据点之间的平均水平距离。 对于摄影测量、激光雷达和声纳测量等基于传感器的测量，通常已知所需使用的间距。 间距使用要素数据集坐标系的水平单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object AveragePointSpacing { get; set; }

		/// <summary>
		/// <para>Maximum Overview Size</para>
		/// <para>Terrain 概貌类似于缩略图概念。 它是 terrain 数据集的最粗略表示，其最大大小表示为创建概貌而进行采样的测量点的数量上限。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MaxOverviewSize { get; set; } = "50000";

		/// <summary>
		/// <para>Config Keyword</para>
		/// <para>用于优化企业级数据库中 terrain 存储的配置关键字。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ConfigKeyword { get; set; }

		/// <summary>
		/// <para>Pyramid Type</para>
		/// <para>指定将用于构建地形金字塔的点细化方法。</para>
		/// <para>窗口大小—将使用窗口大小方法参数值，为每个金字塔等级选择由给定窗口大小定义的区域中的数据点。 这是默认设置。</para>
		/// <para>Z 容差—将指定每个金字塔等级相对于数据点全分辨率的垂直精度。</para>
		/// <para><see cref="PyramidTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? PyramidType { get; set; } = "WINDOWSIZE";

		/// <summary>
		/// <para>Window Size Method</para>
		/// <para>指定如何在由窗口大小定义的区域中选择点。 仅当在金字塔类型参数中指定窗口大小时，此参数才适用。</para>
		/// <para>Z 最小值—将选择具有最小高程值的点。 这是默认设置。</para>
		/// <para>Z 最大值—将选择具有最大高程值的点。</para>
		/// <para>最接近平均值的 Z 值—将选择具有最接近所有高程值的平均值的点。</para>
		/// <para>最小和最大 Z 值—将选择具有最小和最大高程值的点。</para>
		/// <para><see cref="WindowsizeMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? WindowsizeMethod { get; set; } = "ZMIN";

		/// <summary>
		/// <para>Secondary Thinning Method</para>
		/// <para>当使用窗口大小金字塔时，指定要执行的外加细化来减少在平坦区域上所用的点数。 如果某个区域内点的高度均在二次细化阈值参数值内，则可将该区域视为平坦区域。 它的效果在更高分辨率的金字塔等级上更为明显，因为与较大的区域相比，较小的区域更可能是平坦的。</para>
		/// <para>无—将不执行任何二次细化。 这是默认设置。</para>
		/// <para>轻度—将执行轻度抽稀，以保留线性不连续的地形（如建筑面和森林边界）。 建议对包括地面点和非地面点的激光雷达数据使用该方法。 其将抽稀最少的点。</para>
		/// <para>中等—将执行中度抽稀，以在性能和精度之间实现平衡。 该方法不像轻度抽稀方法那样保留很多细节，尽管消除更多点，但整体上这两种方法相差无几。</para>
		/// <para>高度—将执行高度抽稀，以移除大多数点，不大可能保留轮廓清晰的要素。 该方法仅限于使用在坡度逐渐更改的表面。 例如，高度抽稀对裸地激光雷达或深海探测数据具有效果。</para>
		/// <para><see cref="SecondaryThinningMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? SecondaryThinningMethod { get; set; } = "NONE";

		/// <summary>
		/// <para>Secondary Thinning Threshold</para>
		/// <para>将金字塔类型参数设置为窗口大小后，用于激活二次细化的垂直阈值。 将该值设置为等于或大于数据的垂直精度。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? SecondaryThinningThreshold { get; set; } = "1";

		/// <summary>
		/// <para>Output Terrain</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DETerrain()]
		public object? DerivedOutTerrain { get; set; }

		/// <summary>
		/// <para>Triangulation Method</para>
		/// <para>指定是否要通过增密隔断线要素的线段使其符合用于构建 TIN 表面的 Delaunay 三角测量规则，从而将其合并到 terrain 表面中。</para>
		/// <para>Delaunay 三角测量将增密隔断线要素以容纳其周围的点，从而避免创建细长三角形。在分析基于 TIN 的表面时，这些三角形通常会产生不良结果。 此外，只能对符合 Delaunay 准则的三角测量执行自然邻域插值和泰森多边形生成。</para>
		/// <para>受约束的 Delaunay 三角测量将避免增密隔断线要素，而是将隔断线段作为边合并到 TIN 表面中。 当您需要明确定义以确保不会被三角仪修改（即，分割为多条边）的某些边时，请考虑使用此选项。</para>
		/// <para>Delaunay—将增密隔断线以构建容纳其周围点的 Delaunay 三角形。 这是默认设置。</para>
		/// <para>约束型 Delaunay—隔断线不会被增密。</para>
		/// <para><see cref="TriangulationMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? TriangulationMethod { get; set; } = "DELAUNAY";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateTerrain SetEnviroment(int? autoCommit = null , object? configKeyword = null , object? workspace = null )
		{
			base.SetEnv(autoCommit: autoCommit, configKeyword: configKeyword, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Pyramid Type</para>
		/// </summary>
		public enum PyramidTypeEnum 
		{
			/// <summary>
			/// <para>窗口大小—将使用窗口大小方法参数值，为每个金字塔等级选择由给定窗口大小定义的区域中的数据点。 这是默认设置。</para>
			/// </summary>
			[GPValue("WINDOWSIZE")]
			[Description("窗口大小")]
			Window_Size,

			/// <summary>
			/// <para>Z 容差—将指定每个金字塔等级相对于数据点全分辨率的垂直精度。</para>
			/// </summary>
			[GPValue("ZTOLERANCE")]
			[Description("Z 容差")]
			Z_Tolerance,

		}

		/// <summary>
		/// <para>Window Size Method</para>
		/// </summary>
		public enum WindowsizeMethodEnum 
		{
			/// <summary>
			/// <para>Z 最小值—将选择具有最小高程值的点。 这是默认设置。</para>
			/// </summary>
			[GPValue("ZMIN")]
			[Description("Z 最小值")]
			Minimum_Z,

			/// <summary>
			/// <para>Z 最大值—将选择具有最大高程值的点。</para>
			/// </summary>
			[GPValue("ZMAX")]
			[Description("Z 最大值")]
			Maximum_Z,

			/// <summary>
			/// <para>最接近平均值的 Z 值—将选择具有最接近所有高程值的平均值的点。</para>
			/// </summary>
			[GPValue("ZMEAN")]
			[Description("最接近平均值的 Z 值")]
			Closest_To_Mean_Z,

			/// <summary>
			/// <para>最小和最大 Z 值—将选择具有最小和最大高程值的点。</para>
			/// </summary>
			[GPValue("ZMINMAX")]
			[Description("最小和最大 Z 值")]
			Minimum_and_Maximum_Z,

		}

		/// <summary>
		/// <para>Secondary Thinning Method</para>
		/// </summary>
		public enum SecondaryThinningMethodEnum 
		{
			/// <summary>
			/// <para>无—将不执行任何二次细化。 这是默认设置。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无")]
			None,

			/// <summary>
			/// <para>轻度—将执行轻度抽稀，以保留线性不连续的地形（如建筑面和森林边界）。 建议对包括地面点和非地面点的激光雷达数据使用该方法。 其将抽稀最少的点。</para>
			/// </summary>
			[GPValue("MILD")]
			[Description("轻度")]
			Mild,

			/// <summary>
			/// <para>中等—将执行中度抽稀，以在性能和精度之间实现平衡。 该方法不像轻度抽稀方法那样保留很多细节，尽管消除更多点，但整体上这两种方法相差无几。</para>
			/// </summary>
			[GPValue("MODERATE")]
			[Description("中等")]
			Moderate,

			/// <summary>
			/// <para>高度—将执行高度抽稀，以移除大多数点，不大可能保留轮廓清晰的要素。 该方法仅限于使用在坡度逐渐更改的表面。 例如，高度抽稀对裸地激光雷达或深海探测数据具有效果。</para>
			/// </summary>
			[GPValue("STRONG")]
			[Description("高度")]
			Strong,

		}

		/// <summary>
		/// <para>Triangulation Method</para>
		/// </summary>
		public enum TriangulationMethodEnum 
		{
			/// <summary>
			/// <para>Delaunay 三角测量将增密隔断线要素以容纳其周围的点，从而避免创建细长三角形。在分析基于 TIN 的表面时，这些三角形通常会产生不良结果。 此外，只能对符合 Delaunay 准则的三角测量执行自然邻域插值和泰森多边形生成。</para>
			/// </summary>
			[GPValue("DELAUNAY")]
			[Description("Delaunay")]
			Delaunay,

			/// <summary>
			/// <para>约束型 Delaunay—隔断线不会被增密。</para>
			/// </summary>
			[GPValue("CONSTRAINED_DELAUNAY")]
			[Description("约束型 Delaunay")]
			Constrained_Delaunay,

		}

#endregion
	}
}
