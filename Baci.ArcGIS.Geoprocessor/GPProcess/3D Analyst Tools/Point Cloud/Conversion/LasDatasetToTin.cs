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
	/// <para>LAS Dataset To TIN</para>
	/// <para>LAS 数据集转 TIN</para>
	/// <para>通过 LAS 数据集导出不规则三角网 (TIN)。</para>
	/// </summary>
	public class LasDatasetToTin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLasDataset">
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </param>
		/// <param name="OutTin">
		/// <para>Output TIN</para>
		/// <para>将要生成的 TIN 数据集。</para>
		/// </param>
		public LasDatasetToTin(object InLasDataset, object OutTin)
		{
			this.InLasDataset = InLasDataset;
			this.OutTin = OutTin;
		}

		/// <summary>
		/// <para>Tool Display Name : LAS 数据集转 TIN</para>
		/// </summary>
		public override string DisplayName() => "LAS 数据集转 TIN";

		/// <summary>
		/// <para>Tool Name : LasDatasetToTin</para>
		/// </summary>
		public override string ToolName() => "LasDatasetToTin";

		/// <summary>
		/// <para>Tool Excute Name : 3d.LasDatasetToTin</para>
		/// </summary>
		public override string ExcuteName() => "3d.LasDatasetToTin";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "tinSaveVersion", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLasDataset, OutTin, ThinningType, ThinningMethod, ThinningValue, MaxNodes, ZFactor, ClipToExtent };

		/// <summary>
		/// <para>Input LAS Dataset</para>
		/// <para>待处理的 LAS 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLasDatasetLayer()]
		public object InLasDataset { get; set; }

		/// <summary>
		/// <para>Output TIN</para>
		/// <para>将要生成的 TIN 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETin()]
		public object OutTin { get; set; }

		/// <summary>
		/// <para>Thinning Type</para>
		/// <para>指定用于减少生成的 TIN 中被保存为结点的 LAS 数据点的稀疏化类型。</para>
		/// <para>无细化—不应用稀疏化功能。这是默认设置。</para>
		/// <para>随机—基于相应的稀疏化方法选择和稀疏化值条目随机选择 LAS 数据点。</para>
		/// <para>窗口大小—LAS 数据集分为由稀疏化值定义的方形切片，并使用稀疏化方法选择 LAS 点。</para>
		/// <para><see cref="ThinningTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ThinningType { get; set; } = "NONE";

		/// <summary>
		/// <para>Thinning Method</para>
		/// <para>指定用于减少 LAS 数据点的技术，该技术将对稀疏化值的解释产生影响。可用选项取决于所选的稀疏化类型。</para>
		/// <para>百分比—稀疏化值将反映将在输出中保留的 LAS 点的百分比</para>
		/// <para>节点计数—稀疏化值将反映输出中所允许的结点总数。</para>
		/// <para>Z 最小值—在每个窗口大小区域中选择具有最低高程的 LAS 数据点。</para>
		/// <para>Z 最大值—在每个自动确定的窗口大小区域中选择具有最高高程的 LAS 数据点。</para>
		/// <para>最接近平均值的 Z 值—选择高程最接近自动确定的窗口大小区域中平均值的 LAS 数据点。</para>
		/// <para><see cref="ThinningMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ThinningMethod { get; set; }

		/// <summary>
		/// <para>Thinning Value</para>
		/// <para>稀疏化值的解释取决于所选稀疏化类型。</para>
		/// <para>如果稀疏化类型设为窗口大小，则值表示要划分 LAS 数据集的采样区。</para>
		/// <para>如果稀疏化类型设置为随机，稀疏化方法设置为百分比，此值表示将导出到 TIN 的 LAS 点的百分比。</para>
		/// <para>如果稀疏化类型设置为随机，稀疏化方法设置为结点计数，此值表示可以导出到 TIN 的 LAS 点的总数。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object ThinningValue { get; set; } = "0";

		/// <summary>
		/// <para>Maximum Number of Output Nodes</para>
		/// <para>输出 TIN 中允许的结点的最大数量。默认值为 5 百万。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object MaxNodes { get; set; } = "5000000";

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>Z 值将乘上的系数。 此值通常用于转换 z 线性单位来匹配 x,y 线性单位。 默认值为 1，此时高程值保持不变。 如果输入表面的空间参考具有已指定线性单位的 z 基准，则此参数不可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Clip to Extent</para>
		/// <para>指定是否根据分析范围裁剪生成的 TIN。仅当分析范围是输入 LAS 数据集的子集时，该选项才有效。</para>
		/// <para>选中 - 根据分析范围裁剪输出 TIN。这是默认设置。</para>
		/// <para>未选中 - 不根据分析范围裁剪输出 TIN。</para>
		/// <para><see cref="ClipToExtentEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ClipToExtent { get; set; } = "true";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LasDatasetToTin SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object tinSaveVersion = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, tinSaveVersion: tinSaveVersion, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Thinning Type</para>
		/// </summary>
		public enum ThinningTypeEnum 
		{
			/// <summary>
			/// <para>无细化—不应用稀疏化功能。这是默认设置。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("无细化")]
			No_Thinning,

			/// <summary>
			/// <para>随机—基于相应的稀疏化方法选择和稀疏化值条目随机选择 LAS 数据点。</para>
			/// </summary>
			[GPValue("RANDOM")]
			[Description("随机")]
			Random,

			/// <summary>
			/// <para>窗口大小—LAS 数据集分为由稀疏化值定义的方形切片，并使用稀疏化方法选择 LAS 点。</para>
			/// </summary>
			[GPValue("WINDOW_SIZE")]
			[Description("窗口大小")]
			Window_Size,

		}

		/// <summary>
		/// <para>Thinning Method</para>
		/// </summary>
		public enum ThinningMethodEnum 
		{
			/// <summary>
			/// <para>百分比—稀疏化值将反映将在输出中保留的 LAS 点的百分比</para>
			/// </summary>
			[GPValue("PERCENT")]
			[Description("百分比")]
			Percent,

			/// <summary>
			/// <para>节点计数—稀疏化值将反映输出中所允许的结点总数。</para>
			/// </summary>
			[GPValue("NODE_COUNT")]
			[Description("节点计数")]
			Node_Count,

			/// <summary>
			/// <para>Z 最小值—在每个窗口大小区域中选择具有最低高程的 LAS 数据点。</para>
			/// </summary>
			[GPValue("MIN")]
			[Description("Z 最小值")]
			Minimum_Z,

			/// <summary>
			/// <para>Z 最大值—在每个自动确定的窗口大小区域中选择具有最高高程的 LAS 数据点。</para>
			/// </summary>
			[GPValue("MAX")]
			[Description("Z 最大值")]
			Maximum_Z,

			/// <summary>
			/// <para>最接近平均值的 Z 值—选择高程最接近自动确定的窗口大小区域中平均值的 LAS 数据点。</para>
			/// </summary>
			[GPValue("CLOSEST_TO_MEAN")]
			[Description("最接近平均值的 Z 值")]
			Closest_To_Mean_Z,

		}

		/// <summary>
		/// <para>Clip to Extent</para>
		/// </summary>
		public enum ClipToExtentEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CLIP")]
			CLIP,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CLIP")]
			NO_CLIP,

		}

#endregion
	}
}
