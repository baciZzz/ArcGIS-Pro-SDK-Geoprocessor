using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ParcelTools
{
	/// <summary>
	/// <para>Analyze Parcels By Least Squares Adjustment</para>
	/// <para>通过最小二乘平差分析宗地</para>
	/// <para>通过对输入宗地运行最小二乘平差来分析宗地结构测量网络。最小二乘平差是一种数学过程，该过程使用统计分析来估计测量网络中连接点的最可能坐标。可以对宗地结构运行最小二乘平差，以评估和改善宗地拐角点位置的空间精度。</para>
	/// </summary>
	public class AnalyzeParcelsByLeastSquaresAdjustment : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InParcelFabric">
		/// <para>Input Parcel Fabric</para>
		/// <para>将通过最小二乘平差分析的输入宗地结构。</para>
		/// </param>
		/// <param name="AnalysisType">
		/// <para>Analysis Type</para>
		/// <para>指定将在校正中使用的最小二乘分析的类型。</para>
		/// <para>一致性检查—将运行自由网最小二乘平差以检查宗地线上的尺寸是否存在不一致和错误。校正将不会使用固定或加权控制点。</para>
		/// <para>加权最小二乘法—将运行加权最小二乘平差以计算宗地点的更新坐标。将进行校正的宗地应连接至至少两个固定或加权控制点。</para>
		/// <para><see cref="AnalysisTypeEnum"/></para>
		/// </param>
		public AnalyzeParcelsByLeastSquaresAdjustment(object InParcelFabric, object AnalysisType)
		{
			this.InParcelFabric = InParcelFabric;
			this.AnalysisType = AnalysisType;
		}

		/// <summary>
		/// <para>Tool Display Name : 通过最小二乘平差分析宗地</para>
		/// </summary>
		public override string DisplayName() => "通过最小二乘平差分析宗地";

		/// <summary>
		/// <para>Tool Name : AnalyzeParcelsByLeastSquaresAdjustment</para>
		/// </summary>
		public override string ToolName() => "AnalyzeParcelsByLeastSquaresAdjustment";

		/// <summary>
		/// <para>Tool Excute Name : parcel.AnalyzeParcelsByLeastSquaresAdjustment</para>
		/// </summary>
		public override string ExcuteName() => "parcel.AnalyzeParcelsByLeastSquaresAdjustment";

		/// <summary>
		/// <para>Toolbox Display Name : Parcel Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Parcel Tools";

		/// <summary>
		/// <para>Toolbox Alise : parcel</para>
		/// </summary>
		public override string ToolboxAlise() => "parcel";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InParcelFabric, AnalysisType, ConvergenceTolerance!, UpdatedParcelFabric!, UpdatedAdjustmentPoints!, UpdatedAdjustmentLines!, UpdatedAdjustmentVectors! };

		/// <summary>
		/// <para>Input Parcel Fabric</para>
		/// <para>将通过最小二乘平差分析的输入宗地结构。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPParcelLayer()]
		public object InParcelFabric { get; set; }

		/// <summary>
		/// <para>Analysis Type</para>
		/// <para>指定将在校正中使用的最小二乘分析的类型。</para>
		/// <para>一致性检查—将运行自由网最小二乘平差以检查宗地线上的尺寸是否存在不一致和错误。校正将不会使用固定或加权控制点。</para>
		/// <para>加权最小二乘法—将运行加权最小二乘平差以计算宗地点的更新坐标。将进行校正的宗地应连接至至少两个固定或加权控制点。</para>
		/// <para><see cref="AnalysisTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object AnalysisType { get; set; } = "CONSISTENCY_CHECK";

		/// <summary>
		/// <para>Convergence Tolerance</para>
		/// <para>容差表示迭代最小二乘平差后预期的最大坐标偏移。反复（迭代）运行最小二乘平差，直到解收敛为止。当遇到的最大坐标偏移小于指定的收敛容差时，该解决方案被视为收敛。默认值是 0.05 米。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? ConvergenceTolerance { get; set; } = "0.05 Meters";

		/// <summary>
		/// <para>Updated Parcel Fabric</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEParcelDataset()]
		public object? UpdatedParcelFabric { get; set; }

		/// <summary>
		/// <para>Updated Adjustment Points</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? UpdatedAdjustmentPoints { get; set; }

		/// <summary>
		/// <para>Updated Adjustment Lines</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? UpdatedAdjustmentLines { get; set; }

		/// <summary>
		/// <para>Updated Adjustment Vectors</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? UpdatedAdjustmentVectors { get; set; }

		#region InnerClass

		/// <summary>
		/// <para>Analysis Type</para>
		/// </summary>
		public enum AnalysisTypeEnum 
		{
			/// <summary>
			/// <para>一致性检查—将运行自由网最小二乘平差以检查宗地线上的尺寸是否存在不一致和错误。校正将不会使用固定或加权控制点。</para>
			/// </summary>
			[GPValue("CONSISTENCY_CHECK")]
			[Description("一致性检查")]
			Consistency_check,

			/// <summary>
			/// <para>加权最小二乘法—将运行加权最小二乘平差以计算宗地点的更新坐标。将进行校正的宗地应连接至至少两个固定或加权控制点。</para>
			/// </summary>
			[GPValue("WEIGHTED_LEAST_SQUARES")]
			[Description("加权最小二乘法")]
			Weighted_least_squares,

		}

#endregion
	}
}
