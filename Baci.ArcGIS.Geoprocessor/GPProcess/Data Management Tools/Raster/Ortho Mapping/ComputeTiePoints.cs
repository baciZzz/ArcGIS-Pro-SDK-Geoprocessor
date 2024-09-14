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
	/// <para>Compute Tie Points</para>
	/// <para>计算连接点</para>
	/// <para>计算重叠镶嵌数据集项目之间的连接点。 连接点随后可用于计算镶嵌数据集的区域网平差。</para>
	/// </summary>
	public class ComputeTiePoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Input Mosaic Dataset</para>
		/// <para>将用于创建连接点的输入镶嵌数据集。</para>
		/// </param>
		/// <param name="OutControlPoints">
		/// <para>Output Control Points</para>
		/// <para>输出控制点表。 此表将包含使用此工具创建的连接点。</para>
		/// </param>
		public ComputeTiePoints(object InMosaicDataset, object OutControlPoints)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.OutControlPoints = OutControlPoints;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算连接点</para>
		/// </summary>
		public override string DisplayName() => "计算连接点";

		/// <summary>
		/// <para>Tool Name : ComputeTiePoints</para>
		/// </summary>
		public override string ToolName() => "ComputeTiePoints";

		/// <summary>
		/// <para>Tool Excute Name : management.ComputeTiePoints</para>
		/// </summary>
		public override string ExcuteName() => "management.ComputeTiePoints";

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
		public override object[] Parameters() => new object[] { InMosaicDataset, OutControlPoints, Similarity, InMaskDataset, OutImageFeatures, Density, Distribution, LocationAccuracy, Options };

		/// <summary>
		/// <para>Input Mosaic Dataset</para>
		/// <para>将用于创建连接点的输入镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Output Control Points</para>
		/// <para>输出控制点表。 此表将包含使用此工具创建的连接点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutControlPoints { get; set; }

		/// <summary>
		/// <para>Similarity</para>
		/// <para>指定将用于匹配连接点的相似性级别。</para>
		/// <para>低级相似性—两个匹配点的相似性条件为低级。 此选项将生成最匹配的连接点对，但是某些匹配连接点对的错误误差等级可能比较高。</para>
		/// <para>中级相似性—此匹配点对的相似性等级为中级。</para>
		/// <para>高级相似性—此匹配点对的相似性等级为高级。 此选项将生成数目最少的匹配连接点对，但是每个匹配连接点对的误差等级可能比较低。</para>
		/// <para><see cref="SimilarityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Similarity { get; set; } = "MEDIUM";

		/// <summary>
		/// <para>Input Mask</para>
		/// <para>用于排除控制点计算中不需要的区域的面要素类。</para>
		/// <para>名为 mask 的字段可控制区域的纳入或排除。 值为 1 时表示由面（内部）定义的区域将从计算中排除。 值为 2 时表示计算中将包括定义面（内部）而不包括面外部的区域。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object InMaskDataset { get; set; }

		/// <summary>
		/// <para>Output Image Features</para>
		/// <para>输出影像要素点表。 该表将保存为面要素类。 此输出可能非常大。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutImageFeatures { get; set; }

		/// <summary>
		/// <para>Point Density</para>
		/// <para>指定要创建的连接点数。</para>
		/// <para>低点密度—点的密度将较低，这将创建数量最少的连接点。</para>
		/// <para>中等点密度—点的密度将为中等，这将创建中等数量的连接点。</para>
		/// <para>高点密度—点的密度将较高，这将创建数量最多的连接点。</para>
		/// <para><see cref="DensityEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Density { get; set; } = "MEDIUM";

		/// <summary>
		/// <para>Point Distribution</para>
		/// <para>指定点具有常规分布还是随机分布。</para>
		/// <para>随机点分布—点将以随机方式生成。 随机生成的点更适合与不规则形状重叠的区域。</para>
		/// <para>常规点分布—将基于固定图案生成点。 基于固定图案生成的点使用点密度来确定点的创建频率。</para>
		/// <para><see cref="DistributionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Distribution { get; set; } = "RANDOM";

		/// <summary>
		/// <para>Image Location Accuracy</para>
		/// <para>指定用于描述影像精度的关键字。</para>
		/// <para>低影像位置精度—影像具有大幅度偏移和大幅度旋转（&gt; 5 度）。SIFT 算法将用于点匹配计算。</para>
		/// <para>中等影像位置精度—影像具有中等幅度偏移和小幅度旋转（&lt;5 度）。Harris 算法将用于点匹配计算。</para>
		/// <para>高影像位置精度—影像具有小幅度偏移和小幅度旋转。Harris 算法将用于点匹配计算。</para>
		/// <para><see cref="LocationAccuracyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object LocationAccuracy { get; set; } = "MEDIUM";

		/// <summary>
		/// <para>Additional Options</para>
		/// <para>指定用于校正引擎的其他选项。 这些选项仅供第三方校正引擎使用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object Options { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ComputeTiePoints SetEnviroment(object parallelProcessingFactor = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Similarity</para>
		/// </summary>
		public enum SimilarityEnum 
		{
			/// <summary>
			/// <para>低级相似性—两个匹配点的相似性条件为低级。 此选项将生成最匹配的连接点对，但是某些匹配连接点对的错误误差等级可能比较高。</para>
			/// </summary>
			[GPValue("LOW")]
			[Description("低级相似性")]
			Low_similarity,

			/// <summary>
			/// <para>中级相似性—此匹配点对的相似性等级为中级。</para>
			/// </summary>
			[GPValue("MEDIUM")]
			[Description("中级相似性")]
			Medium_similarity,

			/// <summary>
			/// <para>高级相似性—此匹配点对的相似性等级为高级。 此选项将生成数目最少的匹配连接点对，但是每个匹配连接点对的误差等级可能比较低。</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("高级相似性")]
			High_similarity,

		}

		/// <summary>
		/// <para>Point Density</para>
		/// </summary>
		public enum DensityEnum 
		{
			/// <summary>
			/// <para>低点密度—点的密度将较低，这将创建数量最少的连接点。</para>
			/// </summary>
			[GPValue("LOW")]
			[Description("低点密度")]
			Low_point_density,

			/// <summary>
			/// <para>中等点密度—点的密度将为中等，这将创建中等数量的连接点。</para>
			/// </summary>
			[GPValue("MEDIUM")]
			[Description("中等点密度")]
			Medium_point_density,

			/// <summary>
			/// <para>高点密度—点的密度将较高，这将创建数量最多的连接点。</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("高点密度")]
			High_point_density,

		}

		/// <summary>
		/// <para>Point Distribution</para>
		/// </summary>
		public enum DistributionEnum 
		{
			/// <summary>
			/// <para>随机点分布—点将以随机方式生成。 随机生成的点更适合与不规则形状重叠的区域。</para>
			/// </summary>
			[GPValue("RANDOM")]
			[Description("随机点分布")]
			Random_point_distribution,

			/// <summary>
			/// <para>常规点分布—将基于固定图案生成点。 基于固定图案生成的点使用点密度来确定点的创建频率。</para>
			/// </summary>
			[GPValue("REGULAR")]
			[Description("常规点分布")]
			Regular_point_distribution,

		}

		/// <summary>
		/// <para>Image Location Accuracy</para>
		/// </summary>
		public enum LocationAccuracyEnum 
		{
			/// <summary>
			/// <para>低影像位置精度—影像具有大幅度偏移和大幅度旋转（&gt; 5 度）。SIFT 算法将用于点匹配计算。</para>
			/// </summary>
			[GPValue("LOW")]
			[Description("低影像位置精度")]
			Low_image_location_accuracy,

			/// <summary>
			/// <para>中等影像位置精度—影像具有中等幅度偏移和小幅度旋转（&lt;5 度）。Harris 算法将用于点匹配计算。</para>
			/// </summary>
			[GPValue("MEDIUM")]
			[Description("中等影像位置精度")]
			Medium_image_location_accuracy,

			/// <summary>
			/// <para>高影像位置精度—影像具有小幅度偏移和小幅度旋转。Harris 算法将用于点匹配计算。</para>
			/// </summary>
			[GPValue("HIGH")]
			[Description("高影像位置精度")]
			High_image_location_accuracy,

		}

#endregion
	}
}
