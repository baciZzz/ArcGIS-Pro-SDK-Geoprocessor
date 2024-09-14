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
	/// <para>Generate Point Cloud</para>
	/// <para>生成点云</para>
	/// <para>基于立体像对计算 3D 点并将点云作为一组 LAS 文件进行输出。</para>
	/// </summary>
	public class GeneratePointCloud : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Input Mosaic Dataset</para>
		/// <para>必须已完成区域网平差过程且具有立体模型的输入镶嵌数据集。</para>
		/// <para>要对镶嵌数据集执行区域网平差，请使用应用区域网平差工具。要基于镶嵌数据集构建立体模型，请使用构建立体模型工具。</para>
		/// </param>
		/// <param name="MatchingMethod">
		/// <para>Matching Method</para>
		/// <para>用于生成 3D 点的方法。</para>
		/// <para>扩展的地形匹配—一种使用 Harris 算子检测要素点的，基于要素的立体匹配。由于提取的要素点较少，此方法速度较快，可用于地形变化和细节较少的数据。</para>
		/// <para>半全局匹配—半全局匹配 (SGM) 可生成密度较高且具有更多详细地形信息的点。可将其用于城市区域的影像。与 ETM 相比，此方法运算量更大。1</para>
		/// <para>多视图影像匹配—多视图影像匹配 (MVM) 基于 SGM 匹配方法，且随后采用合并跨单个立体模型的冗余深度估计的融合步骤。此方法可生成密集的 3D 点且具有较高的运算效率。2</para>
		/// <para>参考文献：</para>
		/// <para>Heiko Hirschmuller et al., Memory Efficient Semi-Global Matching, ISPRS Annals of the Photogrammetry, Remote Sensing and Spatial Information Sciences，卷 1–3，(2012): 371–376.</para>
		/// <para>Hirschmuller, H. &quot;Stereo Processing by Semiglobal Matching and Mutual Information.&quot; Pattern Analysis and Machine Intelligence, (2008).</para>
		/// <para><see cref="MatchingMethodEnum"/></para>
		/// </param>
		/// <param name="OutFolder">
		/// <para>Output LAS Folder</para>
		/// <para>用于存储输出 LAS 文件的文件夹。</para>
		/// <para>如果使用相同的输入参数多次运行此工具，则由于采样是随机的，因此输出可能稍有不同。</para>
		/// </param>
		/// <param name="OutBaseName">
		/// <para>Output LAS Base Name</para>
		/// <para>用作格式化输出 LAS 文件名的前缀的字符串。例如，如果以 name 为基础，则输出文件将命名为 name1.las、name2.las，以此类推。</para>
		/// </param>
		public GeneratePointCloud(object InMosaicDataset, object MatchingMethod, object OutFolder, object OutBaseName)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.MatchingMethod = MatchingMethod;
			this.OutFolder = OutFolder;
			this.OutBaseName = OutBaseName;
		}

		/// <summary>
		/// <para>Tool Display Name : 生成点云</para>
		/// </summary>
		public override string DisplayName() => "生成点云";

		/// <summary>
		/// <para>Tool Name : GeneratePointCloud</para>
		/// </summary>
		public override string ToolName() => "GeneratePointCloud";

		/// <summary>
		/// <para>Tool Excute Name : management.GeneratePointCloud</para>
		/// </summary>
		public override string ExcuteName() => "management.GeneratePointCloud";

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
		public override object[] Parameters() => new object[] { InMosaicDataset, MatchingMethod, OutFolder, OutBaseName, ObjectSize!, GroundSpacing!, MinimumPairs!, MinimumArea!, MinimumAdjustmentQuality!, MaximumDiffGsd!, MaximumDiffOP! };

		/// <summary>
		/// <para>Input Mosaic Dataset</para>
		/// <para>必须已完成区域网平差过程且具有立体模型的输入镶嵌数据集。</para>
		/// <para>要对镶嵌数据集执行区域网平差，请使用应用区域网平差工具。要基于镶嵌数据集构建立体模型，请使用构建立体模型工具。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Matching Method</para>
		/// <para>用于生成 3D 点的方法。</para>
		/// <para>扩展的地形匹配—一种使用 Harris 算子检测要素点的，基于要素的立体匹配。由于提取的要素点较少，此方法速度较快，可用于地形变化和细节较少的数据。</para>
		/// <para>半全局匹配—半全局匹配 (SGM) 可生成密度较高且具有更多详细地形信息的点。可将其用于城市区域的影像。与 ETM 相比，此方法运算量更大。1</para>
		/// <para>多视图影像匹配—多视图影像匹配 (MVM) 基于 SGM 匹配方法，且随后采用合并跨单个立体模型的冗余深度估计的融合步骤。此方法可生成密集的 3D 点且具有较高的运算效率。2</para>
		/// <para>参考文献：</para>
		/// <para>Heiko Hirschmuller et al., Memory Efficient Semi-Global Matching, ISPRS Annals of the Photogrammetry, Remote Sensing and Spatial Information Sciences，卷 1–3，(2012): 371–376.</para>
		/// <para>Hirschmuller, H. &quot;Stereo Processing by Semiglobal Matching and Mutual Information.&quot; Pattern Analysis and Machine Intelligence, (2008).</para>
		/// <para><see cref="MatchingMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MatchingMethod { get; set; } = "ETM";

		/// <summary>
		/// <para>Output LAS Folder</para>
		/// <para>用于存储输出 LAS 文件的文件夹。</para>
		/// <para>如果使用相同的输入参数多次运行此工具，则由于采样是随机的，因此输出可能稍有不同。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolder { get; set; }

		/// <summary>
		/// <para>Output LAS Base Name</para>
		/// <para>用作格式化输出 LAS 文件名的前缀的字符串。例如，如果以 name 为基础，则输出文件将命名为 name1.las、name2.las，以此类推。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutBaseName { get; set; }

		/// <summary>
		/// <para>Maximum Object Size (in meter)</para>
		/// <para>将在其中标识建筑物或树木等表面对象的搜索半径。它是以地图单位表示的线大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ObjectSize { get; set; } = "10";

		/// <summary>
		/// <para>DSM Ground Spacing (in meter)</para>
		/// <para>生成 3D 点时采用的地面间距（以米为单位）。</para>
		/// <para>默认值为源影像像素大小的五倍。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? GroundSpacing { get; set; }

		/// <summary>
		/// <para>Number of Image Pairs</para>
		/// <para>用于生成 3D 点的影像对数量。默认值是最少 2 个影像对。</para>
		/// <para>有时，一个位置可能被许多影像对覆盖。在此情况中，该工具将根据此工具中指定的不同阈值参数对这些影像对进行排序。将使用得分最高的影像对生成点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MinimumPairs { get; set; } = "4";

		/// <summary>
		/// <para>Overlap Area Threshold</para>
		/// <para>指定可接受的最小重叠区域阈值，即影像对之间的重叠百分比。按照此条件，重叠区域小于此阈值的影像对将获得 0 分，且其在排序列表中的位置将下降。阈值的值范围介于 0 到 1 之间。默认阈值为 0.6，相当于 60%。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MinimumArea { get; set; } = "0.6";

		/// <summary>
		/// <para>Adjustment Quality Threshold</para>
		/// <para>指定可接受的最小校正质量。该阈值将与存储在立体模型中的校正质量值进行比较。按照此条件，校正质量低于此指定阈值的影像对将获得 0 分，且其在排序列表中的位置将下降。阈值的值范围介于 0 到 1 之间。默认值为 0.2，相当于 20%。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MinimumAdjustmentQuality { get; set; } = "0.2";

		/// <summary>
		/// <para>GSD Difference Threshold</para>
		/// <para>指定影像对中两个影像之间的地面采样间距 (GSD) 的最大允许阈值。两个影像之间的分辨率比值将与此阈值进行比较。按照此条件，地面采样比率大于此阈值的影像对将获得 0 分，且其在排序列表中的位置将下降。默认阈值比为 2。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaximumDiffGsd { get; set; } = "2";

		/// <summary>
		/// <para>Omega/Phi Difference Threshold</para>
		/// <para>指定两个影像对之间的 Omega\Phi 差异的最大阈值。将比较图像对的 Omega 值和 Phi 值。按照此条件，Omega 或 Phi 差异大于此阈值的影像对将获得 0 分，且其在排序列表中的位置将下降。每个比较项的默认阈值差异为 8。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaximumDiffOP { get; set; } = "8";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GeneratePointCloud SetEnviroment(object? parallelProcessingFactor = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Matching Method</para>
		/// </summary>
		public enum MatchingMethodEnum 
		{
			/// <summary>
			/// <para>扩展的地形匹配—一种使用 Harris 算子检测要素点的，基于要素的立体匹配。由于提取的要素点较少，此方法速度较快，可用于地形变化和细节较少的数据。</para>
			/// </summary>
			[GPValue("ETM")]
			[Description("扩展的地形匹配")]
			Extended_terrain_matching,

			/// <summary>
			/// <para>半全局匹配—半全局匹配 (SGM) 可生成密度较高且具有更多详细地形信息的点。可将其用于城市区域的影像。与 ETM 相比，此方法运算量更大。1</para>
			/// </summary>
			[GPValue("SGM")]
			[Description("半全局匹配")]
			Semiglobal_matching,

			/// <summary>
			/// <para>多视图影像匹配—多视图影像匹配 (MVM) 基于 SGM 匹配方法，且随后采用合并跨单个立体模型的冗余深度估计的融合步骤。此方法可生成密集的 3D 点且具有较高的运算效率。2</para>
			/// </summary>
			[GPValue("MVM")]
			[Description("多视图影像匹配")]
			MVM,

		}

#endregion
	}
}
