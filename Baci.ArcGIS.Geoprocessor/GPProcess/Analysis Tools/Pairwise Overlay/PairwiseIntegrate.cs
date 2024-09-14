using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AnalysisTools
{
	/// <summary>
	/// <para>Pairwise Integrate</para>
	/// <para>成对整合</para>
	/// <para>分析一个或多个要素类中要素之间的要素折点的坐标位置。彼此间距离在指定范围内的折点被认为表示同一个位置，并被指定一个共有坐标值（换句话说，将它们定位于同一点）。该工具还会在要素折点位于边的 x,y 容差范围内以及线段相交的位置处添加折点。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class PairwiseIntegrate : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要整合的要素类。如果要素间的距离小于容差，则折点或点将被聚类（移动至重合状态）。</para>
		/// </param>
		public PairwiseIntegrate(object InFeatures)
		{
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 成对整合</para>
		/// </summary>
		public override string DisplayName() => "成对整合";

		/// <summary>
		/// <para>Tool Name : PairwiseIntegrate</para>
		/// </summary>
		public override string ToolName() => "PairwiseIntegrate";

		/// <summary>
		/// <para>Tool Excute Name : analysis.PairwiseIntegrate</para>
		/// </summary>
		public override string ExcuteName() => "analysis.PairwiseIntegrate";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise() => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "XYTolerance", "extent", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, ClusterTolerance, OutFeatures };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要整合的要素类。如果要素间的距离小于容差，则折点或点将被聚类（移动至重合状态）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>XY Tolerance</para>
		/// <para>该距离可确定一个范围，要素折点将在此范围内实现重合。要最大限度的减少不必要的折点移动，x,y 容差应该非常小。如果未指定任何值，则将使用输入列表中第一个数据集的 xy 容差。</para>
		/// <para>更改此参数的值可能会导致出现故障或意外结果。建议不要修改此参数。已将其从工具对话框的视图中移除。默认情况下，将使用输入要素类的空间参考 x,y 容差属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object ClusterTolerance { get; set; }

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PairwiseIntegrate SetEnviroment(object XYTolerance = null, object extent = null, object parallelProcessingFactor = null, object workspace = null)
		{
			base.SetEnv(XYTolerance: XYTolerance, extent: extent, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

	}
}
