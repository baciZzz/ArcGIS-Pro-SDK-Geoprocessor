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
	/// <para>Compute Mosaic Candidates</para>
	/// <para>计算镶嵌候选项</para>
	/// <para>在镶嵌数据集中找到最能代表镶嵌区域的影像候选项。</para>
	/// </summary>
	public class ComputeMosaicCandidates : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Input mosaic dataset</para>
		/// <para>带密集重叠影像的输入镶嵌数据集。</para>
		/// </param>
		public ComputeMosaicCandidates(object InMosaicDataset)
		{
			this.InMosaicDataset = InMosaicDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算镶嵌候选项</para>
		/// </summary>
		public override string DisplayName() => "计算镶嵌候选项";

		/// <summary>
		/// <para>Tool Name : ComputeMosaicCandidates</para>
		/// </summary>
		public override string ToolName() => "ComputeMosaicCandidates";

		/// <summary>
		/// <para>Tool Excute Name : management.ComputeMosaicCandidates</para>
		/// </summary>
		public override string ExcuteName() => "management.ComputeMosaicCandidates";

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
		public override object[] Parameters() => new object[] { InMosaicDataset, MaximumOverlap!, MaximumAreaLoss!, OutMosaicDataset! };

		/// <summary>
		/// <para>Input mosaic dataset</para>
		/// <para>带密集重叠影像的输入镶嵌数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Maximum Area Overlap</para>
		/// <para>您想要的镶嵌数据集和镶嵌数据集中每个影像的轮廓线之间的最大重叠数量。如果重叠的百分比高于此阈值，则影像因为有太多冗余信息而将被排除。</para>
		/// <para>百分比以小数表示。例如，百分比为 60 的最大重叠将表示为 0.6。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaximumOverlap { get; set; } = "0.6";

		/// <summary>
		/// <para>Maximum Area Loss Allowed</para>
		/// <para>这是可以被候选影像排除的区域的最大百分比。在根据最大区域重叠选择了最佳候选影像后，此工具会检查最大排除区域是否小于指定阈值。如果排除区域大于指定阈值，则该工具将添加更多候选影像来填补一些丢失的空白。大多数被排除的区域很可能是沿着镶嵌数据集边界的。</para>
		/// <para>百分比以小数表示。例如，百分比为 5 的最大排除区域将表示为 0.05。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaximumAreaLoss { get; set; } = "0.05";

		/// <summary>
		/// <para>Derived Mosaic Dataset</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? OutMosaicDataset { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ComputeMosaicCandidates SetEnviroment(object? parallelProcessingFactor = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
