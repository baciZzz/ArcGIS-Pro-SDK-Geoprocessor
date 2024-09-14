using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Dendrogram</para>
	/// <para>树状图</para>
	/// <para>构造可显示特征文件中连续合并类之间的属性距离的树示意图（树状图）。</para>
	/// </summary>
	public class Dendrogram : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSignatureFile">
		/// <para>Input signature file</para>
		/// <para>其类特征可用于生成树状图的输入特征文件。</para>
		/// <para>需要使用 .gsg 扩展名。</para>
		/// </param>
		/// <param name="OutDendrogramFile">
		/// <para>Output dendrogram file</para>
		/// <para>输出树状图 ASCII 文件。</para>
		/// <para>扩展名可以是 .txt 或 .asc。</para>
		/// </param>
		public Dendrogram(object InSignatureFile, object OutDendrogramFile)
		{
			this.InSignatureFile = InSignatureFile;
			this.OutDendrogramFile = OutDendrogramFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 树状图</para>
		/// </summary>
		public override string DisplayName() => "树状图";

		/// <summary>
		/// <para>Tool Name : 树状图</para>
		/// </summary>
		public override string ToolName() => "树状图";

		/// <summary>
		/// <para>Tool Excute Name : sa.Dendrogram</para>
		/// </summary>
		public override string ExcuteName() => "sa.Dendrogram";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSignatureFile, OutDendrogramFile, DistanceCalculation!, LineWidth! };

		/// <summary>
		/// <para>Input signature file</para>
		/// <para>其类特征可用于生成树状图的输入特征文件。</para>
		/// <para>需要使用 .gsg 扩展名。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("GSG")]
		public object InSignatureFile { get; set; }

		/// <summary>
		/// <para>Output dendrogram file</para>
		/// <para>输出树状图 ASCII 文件。</para>
		/// <para>扩展名可以是 .txt 或 .asc。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("TXT", "ASC")]
		public object OutDendrogramFile { get; set; }

		/// <summary>
		/// <para>Use variance in distance calculations</para>
		/// <para>指定多维属性空间中各类之间的距离的定义方式。</para>
		/// <para>选中 - 各类之间的距离将根据其特征平均值之间的方差和欧氏距离来进行计算。</para>
		/// <para>取消选中 - 各类之间的距离仅由类特征平均值之间的欧氏距离决定。</para>
		/// <para><see cref="DistanceCalculationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? DistanceCalculation { get; set; } = "true";

		/// <summary>
		/// <para>Line width of dendrogram</para>
		/// <para>通过行字符数设置树状图宽度。</para>
		/// <para>默认值为 78。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		[GPNumericDomain()]
		public object? LineWidth { get; set; } = "78";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Dendrogram SetEnviroment(object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Use variance in distance calculations</para>
		/// </summary>
		public enum DistanceCalculationEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("VARIANCE")]
			VARIANCE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("MEAN_ONLY")]
			MEAN_ONLY,

		}

#endregion
	}
}
