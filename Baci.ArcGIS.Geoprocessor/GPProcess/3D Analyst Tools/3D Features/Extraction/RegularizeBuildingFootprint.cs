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
	/// <para>Regularize Building Footprint</para>
	/// <para>规则化建筑物覆盖区</para>
	/// <para>通过消除几何中不需要出现的伪影来对建筑物覆盖区面的形状进行规范化。</para>
	/// </summary>
	public class RegularizeBuildingFootprint : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>表示建筑物覆盖区的待规则化面。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </param>
		/// <param name="Method">
		/// <para>Method</para>
		/// <para>指定在输入要素处理过程中要使用的规则化方法。</para>
		/// <para>直角—将在相邻边之间构造由 90° 角组成的形状。</para>
		/// <para>直角和对角—将在相邻边之间构造由 45° 和 90° 角组成的形状。</para>
		/// <para>任意角—将在相邻边之间构造由任意角组成的形状。</para>
		/// <para>圆形—将在输入要素周围构造最佳拟合圆。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </param>
		/// <param name="Tolerance">
		/// <para>Tolerance</para>
		/// <para>对于大多数方法，此值表示规则化覆盖区可从其原始要素的边界偏移的最大距离。 指定的值将基于输入要素坐标系的线性单位。 使用圆形方法时，基于在容差类型参数中的选择，此选项也可以解释为相对于规则化结果区域，原始要素与其规则化结果之间的差异。</para>
		/// </param>
		public RegularizeBuildingFootprint(object InFeatures, object OutFeatureClass, object Method, object Tolerance)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.Method = Method;
			this.Tolerance = Tolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : 规则化建筑物覆盖区</para>
		/// </summary>
		public override string DisplayName() => "规则化建筑物覆盖区";

		/// <summary>
		/// <para>Tool Name : RegularizeBuildingFootprint</para>
		/// </summary>
		public override string ToolName() => "RegularizeBuildingFootprint";

		/// <summary>
		/// <para>Tool Excute Name : 3d.RegularizeBuildingFootprint</para>
		/// </summary>
		public override string ExcuteName() => "3d.RegularizeBuildingFootprint";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "gpuID", "outputCoordinateSystem", "parallelProcessingFactor", "processorType", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, Method, Tolerance, Densification!, Precision!, DiagonalPenalty!, MinRadius!, MaxRadius!, AlignmentFeature!, AlignmentTolerance!, ToleranceType! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>表示建筑物覆盖区的待规则化面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>指定在输入要素处理过程中要使用的规则化方法。</para>
		/// <para>直角—将在相邻边之间构造由 90° 角组成的形状。</para>
		/// <para>直角和对角—将在相邻边之间构造由 45° 和 90° 角组成的形状。</para>
		/// <para>任意角—将在相邻边之间构造由任意角组成的形状。</para>
		/// <para>圆形—将在输入要素周围构造最佳拟合圆。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "RIGHT_ANGLES";

		/// <summary>
		/// <para>Tolerance</para>
		/// <para>对于大多数方法，此值表示规则化覆盖区可从其原始要素的边界偏移的最大距离。 指定的值将基于输入要素坐标系的线性单位。 使用圆形方法时，基于在容差类型参数中的选择，此选项也可以解释为相对于规则化结果区域，原始要素与其规则化结果之间的差异。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		[GPNumericDomain()]
		public object Tolerance { get; set; }

		/// <summary>
		/// <para>Densification</para>
		/// <para>用于评估规则化要素为直的或弯的采样间隔。 增密必须小于等于容差值。</para>
		/// <para>此参数仅用于支持直角标识的方法。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? Densification { get; set; }

		/// <summary>
		/// <para>Precision</para>
		/// <para>将在规则化过程中使用的空间格网精度。 值的有效范围为 0.05 到 0.25。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0.050000000000000003, Max = 0.25)]
		public object? Precision { get; set; } = "0.25";

		/// <summary>
		/// <para>Diagonal Penalty</para>
		/// <para>如果使用直角和对角方法，则该值将识别在两条相邻线段之间构造直角或对角边的可能性。 如果使用任意角方法，则该值将识别构造相应对角边的可能性，这些对角边不符合由工具算法确定的首选边。 如果惩罚值设置为 0，则将不使用首选边，由此生成简化的不规则面。 通常，该值越高，则构造对角边的可能性越小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0, Max = 10)]
		public object? DiagonalPenalty { get; set; } = "1.5";

		/// <summary>
		/// <para>Minimum Radius</para>
		/// <para>适用于规则化圆的最小半径。 值 0 表示无最小尺寸限制。 此选项仅适用于圆形方法。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? MinRadius { get; set; } = "0.1";

		/// <summary>
		/// <para>Maximum Radius</para>
		/// <para>适用于规则化圆的最大半径。 此选项仅适用于圆形方法。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		public object? MaxRadius { get; set; } = "1000000";

		/// <summary>
		/// <para>Alignment Feature</para>
		/// <para>将用于对齐规则化面方向的线要素。 每个面将仅与一个线要素对齐。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon")]
		public object? AlignmentFeature { get; set; }

		/// <summary>
		/// <para>Alignment Tolerance</para>
		/// <para>将用于查找最近对齐要素的最大距离阈值。 例如，值 20 米表示将使用 20 米范围内的最近线来对齐规则化面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? AlignmentTolerance { get; set; }

		/// <summary>
		/// <para>Tolerance Type</para>
		/// <para>指定当方法参数设置为圆形时，容差的应用方式。</para>
		/// <para>距离分析—表示距正在处理的要素边界的最大距离的容差。 这是默认设置。</para>
		/// <para>面积比—表示非规则化圆形的原始要素的面积与规则化圆形的面积之比的容差上限。</para>
		/// <para><see cref="ToleranceTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ToleranceType { get; set; } = "DISTANCE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RegularizeBuildingFootprint SetEnviroment(object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? parallelProcessingFactor = null , object? processorType = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, processorType: processorType, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>直角—将在相邻边之间构造由 90° 角组成的形状。</para>
			/// </summary>
			[GPValue("RIGHT_ANGLES")]
			[Description("直角")]
			Right_Angles,

			/// <summary>
			/// <para>直角和对角—将在相邻边之间构造由 45° 和 90° 角组成的形状。</para>
			/// </summary>
			[GPValue("RIGHT_ANGLES_AND_DIAGONALS")]
			[Description("直角和对角")]
			Right_Angles_and_Diagonals,

			/// <summary>
			/// <para>任意角—将在相邻边之间构造由任意角组成的形状。</para>
			/// </summary>
			[GPValue("ANY_ANGLE")]
			[Description("任意角")]
			Any_Angles,

			/// <summary>
			/// <para>圆形—将在输入要素周围构造最佳拟合圆。</para>
			/// </summary>
			[GPValue("CIRCLE")]
			[Description("圆形")]
			Circle,

		}

		/// <summary>
		/// <para>Tolerance Type</para>
		/// </summary>
		public enum ToleranceTypeEnum 
		{
			/// <summary>
			/// <para>距离分析—表示距正在处理的要素边界的最大距离的容差。 这是默认设置。</para>
			/// </summary>
			[GPValue("DISTANCE")]
			[Description("距离分析")]
			Distance,

			/// <summary>
			/// <para>面积比—表示非规则化圆形的原始要素的面积与规则化圆形的面积之比的容差上限。</para>
			/// </summary>
			[GPValue("AREA_RATIO")]
			[Description("面积比")]
			Area_Ratio,

		}

#endregion
	}
}
