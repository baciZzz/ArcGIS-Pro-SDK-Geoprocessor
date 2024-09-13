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
	/// <para>Analyze Control Points</para>
	/// <para>分析控制点</para>
	/// <para>分析控制点覆盖范围并标识需要额外控制点来改善局域网平差结果的区域。</para>
	/// </summary>
	public class AnalyzeControlPoints : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMosaicDataset">
		/// <para>Input Mosaic Dataset</para>
		/// <para>要分析输入镶嵌数据集的控制点。</para>
		/// </param>
		/// <param name="InControlPoints">
		/// <para>Input Control Points</para>
		/// <para>输入控制点要素类。</para>
		/// <para>通常通过计算连接点或计算控制点工具进行创建。</para>
		/// </param>
		/// <param name="OutCoverageTable">
		/// <para>Output Control Point Coverage Feature Class</para>
		/// <para>包含控制点覆盖范围和相应影像内区域百分比的面要素类输出。</para>
		/// </param>
		public AnalyzeControlPoints(object InMosaicDataset, object InControlPoints, object OutCoverageTable)
		{
			this.InMosaicDataset = InMosaicDataset;
			this.InControlPoints = InControlPoints;
			this.OutCoverageTable = OutCoverageTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 分析控制点</para>
		/// </summary>
		public override string DisplayName() => "分析控制点";

		/// <summary>
		/// <para>Tool Name : AnalyzeControlPoints</para>
		/// </summary>
		public override string ToolName() => "AnalyzeControlPoints";

		/// <summary>
		/// <para>Tool Excute Name : management.AnalyzeControlPoints</para>
		/// </summary>
		public override string ExcuteName() => "management.AnalyzeControlPoints";

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
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMosaicDataset, InControlPoints, OutCoverageTable, OutOverlapTable, InMaskDataset, MinimumArea, MaximumLevel };

		/// <summary>
		/// <para>Input Mosaic Dataset</para>
		/// <para>要分析输入镶嵌数据集的控制点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InMosaicDataset { get; set; }

		/// <summary>
		/// <para>Input Control Points</para>
		/// <para>输入控制点要素类。</para>
		/// <para>通常通过计算连接点或计算控制点工具进行创建。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InControlPoints { get; set; }

		/// <summary>
		/// <para>Output Control Point Coverage Feature Class</para>
		/// <para>包含控制点覆盖范围和相应影像内区域百分比的面要素类输出。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutCoverageTable { get; set; }

		/// <summary>
		/// <para>Output Overlap Feature Class</para>
		/// <para>包含影像间所有重叠区域的面要素类输出。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutOverlapTable { get; set; }

		/// <summary>
		/// <para>Input Mask</para>
		/// <para>用于排除控制点计算分析中不需要的区域的面要素类。</para>
		/// <para>名为 mask 的字段可控制区域的纳入或排除。 值为 1 时表示由面（内部）定义的区域将从计算中排除。 值为 2 时表示计算中将包括定义面（内部）而不包括面外部的区域。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		public object InMaskDataset { get; set; }

		/// <summary>
		/// <para>Minimum Overlap Area</para>
		/// <para>相对于影像，指定重叠区域所必须的最小百分比。小于指定百分比阈值的区域将从分析中排除。</para>
		/// <para>请确保您拥有的区域不要过小；否者，将需要分析很小的狭长面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MinimumArea { get; set; } = "0.2";

		/// <summary>
		/// <para>Maximum Overlap Level</para>
		/// <para>分析控制点时，可以重叠的最大图像数。</para>
		/// <para>例如，如果镶嵌数据集中有四张图像，且指定的最大重叠值为 3，则将有十种不同的组合显示在重叠窗口中。如果四张图像分别以 i1、i2、i3 和 i4 命名，则将显示的十种组合为 [i1, i2, i3]、[i1 i2 i4]、[i1 i3 i4]、[i2 i3 i4]、[i1, i2]、[i1, i3]、[i1, i4]、[i2, i3]、[i2, i4] 和 [i3, i4]。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object MaximumLevel { get; set; } = "2";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AnalyzeControlPoints SetEnviroment(object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
