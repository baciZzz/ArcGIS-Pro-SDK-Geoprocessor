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
	/// <para>Locate Outliers</para>
	/// <para>定位异常值</para>
	/// <para>标识 terrain、TIN 或 LAS 数据集中超出高程值定义范围的异常高程测量或存在与周围表面不一致的坡度特征的异常高程测量。</para>
	/// </summary>
	public class LocateOutliers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurface">
		/// <para>Input  Surface</para>
		/// <para>将要分析的 terrain、TIN 或 LAS 数据集。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </param>
		public LocateOutliers(object InSurface, object OutFeatureClass)
		{
			this.InSurface = InSurface;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 定位异常值</para>
		/// </summary>
		public override string DisplayName() => "定位异常值";

		/// <summary>
		/// <para>Tool Name : LocateOutliers</para>
		/// </summary>
		public override string ToolName() => "LocateOutliers";

		/// <summary>
		/// <para>Tool Excute Name : 3d.LocateOutliers</para>
		/// </summary>
		public override string ExcuteName() => "3d.LocateOutliers";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSurface, OutFeatureClass, ApplyHardLimit, AbsoluteZMin, AbsoluteZMax, ApplyComparisonFilter, ZTolerance, SlopeTolerance, ExceedToleranceRatio, OutlierCap };

		/// <summary>
		/// <para>Input  Surface</para>
		/// <para>将要分析的 terrain、TIN 或 LAS 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Apply Hard Limit</para>
		/// <para>指定使用 Z 最小绝对值和 Z 最大绝对值寻找异常值。</para>
		/// <para>未选中 - 不使用 Z 最小绝对值和 Z 最大绝对值寻找异常值。这是默认设置。</para>
		/// <para>选中 - 使用 Z 最小绝对值和 Z 最大绝对值寻找异常值。</para>
		/// <para><see cref="ApplyHardLimitEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ApplyHardLimit { get; set; } = "false";

		/// <summary>
		/// <para>Absolute Z Minimum</para>
		/// <para>如果应用了硬限制，那么任何一个点的高程低于此值将被视为异常值。默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object AbsoluteZMin { get; set; } = "0";

		/// <summary>
		/// <para>Absolute Z Maximum</para>
		/// <para>如果应用了硬限制，那么任何一个点的高程高于此值将被视为异常值。默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object AbsoluteZMax { get; set; } = "0";

		/// <summary>
		/// <para>Apply Comparison Filter</para>
		/// <para>比较过滤器包含三个用于确定异常点的参数：Z 容差、坡度容差和超出容差比。</para>
		/// <para>未选中 - 在评估点时不使用三个比较参数（“Z 容差”、“坡度容差”和“超出容差比”）。</para>
		/// <para>选中 - 在评估点时使用三个比较参数（“Z 容差”、“坡度容差”和“超出容差比”）。这是默认设置。</para>
		/// <para><see cref="ApplyComparisonFilterEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ApplyComparisonFilter { get; set; } = "true";

		/// <summary>
		/// <para>Z Tolerance</para>
		/// <para>在应用了比较过滤器的情况下比较邻近点的 Z 值。默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ZTolerance { get; set; } = "0";

		/// <summary>
		/// <para>Slope Tolerance</para>
		/// <para>用于标识异常值点的连续点之间坡度变化的阈值。坡度用百分比表示，默认为 150。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object SlopeTolerance { get; set; } = "150";

		/// <summary>
		/// <para>Exceed Tolerance Ratio</para>
		/// <para>将确定每个异常值点的条件定义为其邻域内必须超出指定比较过滤器的点比例的函数。例如，默认值 0.5 表示查询点周围至少有一半的点必须超出比较过滤器，这样查询点才会被视为异常值。值 0.7 表示至少 70% 的相邻点必须超出容差。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ExceedToleranceRatio { get; set; } = "0.5";

		/// <summary>
		/// <para>Outlier Cap</para>
		/// <para>异常值点的最大数量可被写入至输出。一旦达到了该值，将无法搜索其他异常值。默认值为 2500。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object OutlierCap { get; set; } = "2500";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LocateOutliers SetEnviroment(object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, int? autoCommit = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Apply Hard Limit</para>
		/// </summary>
		public enum ApplyHardLimitEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("APPLY_HARD_LIMIT")]
			APPLY_HARD_LIMIT,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_APPLY_HARD_LIMIT")]
			NO_APPLY_HARD_LIMIT,

		}

		/// <summary>
		/// <para>Apply Comparison Filter</para>
		/// </summary>
		public enum ApplyComparisonFilterEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("APPLY_COMPARISON_FILTER")]
			APPLY_COMPARISON_FILTER,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_APPLY_COMPARISON_FILTER")]
			NO_APPLY_COMPARISON_FILTER,

		}

#endregion
	}
}
