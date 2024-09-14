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
	/// <para>Extract Power Lines From Point Cloud</para>
	/// <para>从点云中提取供电线路</para>
	/// <para>从已分类点云数据中提取用于供电线路建模的 3D 线要素。</para>
	/// </summary>
	public class ExtractPowerLinesFromPointCloud : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointCloud">
		/// <para>Input Point Cloud</para>
		/// <para>包含分类为供电线路的点的 LAS 数据集图层。</para>
		/// </param>
		/// <param name="ClassCodes">
		/// <para>Power Line Class Codes</para>
		/// <para>代表供电线路的点的类代码值。</para>
		/// </param>
		/// <param name="Out3DLines">
		/// <para>Output 3D Lines</para>
		/// <para>用于供电线路建模的 3D 线。</para>
		/// </param>
		public ExtractPowerLinesFromPointCloud(object InPointCloud, object ClassCodes, object Out3DLines)
		{
			this.InPointCloud = InPointCloud;
			this.ClassCodes = ClassCodes;
			this.Out3DLines = Out3DLines;
		}

		/// <summary>
		/// <para>Tool Display Name : 从点云中提取供电线路</para>
		/// </summary>
		public override string DisplayName() => "从点云中提取供电线路";

		/// <summary>
		/// <para>Tool Name : ExtractPowerLinesFromPointCloud</para>
		/// </summary>
		public override string ToolName() => "ExtractPowerLinesFromPointCloud";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ExtractPowerLinesFromPointCloud</para>
		/// </summary>
		public override string ExcuteName() => "3d.ExtractPowerLinesFromPointCloud";

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
		public override string[] ValidEnvironments() => new string[] { "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InPointCloud, ClassCodes, Out3DLines, PointTolerance, SeparationDistance, MaxSamplingGap, LineTolerance, WindCorrection, MinWindSpan, MaxWindDeviation, EndPointSearchRadius, MinLength };

		/// <summary>
		/// <para>Input Point Cloud</para>
		/// <para>包含分类为供电线路的点的 LAS 数据集图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InPointCloud { get; set; }

		/// <summary>
		/// <para>Power Line Class Codes</para>
		/// <para>代表供电线路的点的类代码值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPRangeDomain(Min = 0, Max = 255)]
		public object ClassCodes { get; set; }

		/// <summary>
		/// <para>Output 3D Lines</para>
		/// <para>用于供电线路建模的 3D 线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object Out3DLines { get; set; }

		/// <summary>
		/// <para>Point Tolerance</para>
		/// <para>用于确定属于给定供电线路的点的距离。默认值为 80 厘米。</para>
		/// <para><see cref="PointToleranceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object PointTolerance { get; set; } = "80 Centimeters";

		/// <summary>
		/// <para>Wire Separation Distance</para>
		/// <para>确定点是否属于不同供电线路时必须相距的距离。默认值为 1 米。</para>
		/// <para><see cref="SeparationDistanceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object SeparationDistance { get; set; } = "1 Meters";

		/// <summary>
		/// <para>Maximum Wire Sampling Gap</para>
		/// <para>给定供电线路跨度中可以存在的最大间距。将按此距离延长基于一组供电线路点建模的悬链曲线，以查找与同一供电线路拟合的其他点。默认值为 5 米。</para>
		/// <para><see cref="MaxSamplingGapEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object MaxSamplingGap { get; set; } = "5 Meters";

		/// <summary>
		/// <para>Output Line Tolerance</para>
		/// <para>用于确定输出供电线路精度的距离。距离越大，沿每条线创建的折点越少，生成的供电线路表示越粗糙。默认值为 1 厘米。</para>
		/// <para><see cref="LineToleranceEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object LineTolerance { get; set; } = "1 Centimeters";

		/// <summary>
		/// <para>Adjust for wind distortion</para>
		/// <para>指定是否使用风力校正来提高点与给定供电线路的拟合度。风力校正将仅在一个方向上应用，并且仅适用于跨度大于在进行风力校正的最小跨度参数中指定的距离的供电线路。</para>
		/// <para>选中 - 将使用风力校正提高属于同一供电线路的点的悬链曲线拟合度。这是默认设置。</para>
		/// <para>未选中 - 不会使用风力校正，从而导致创建的供电线路无法与在点云调查中捕获的点拟合。</para>
		/// <para><see cref="WindCorrectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Wind Correction")]
		public object WindCorrection { get; set; } = "true";

		/// <summary>
		/// <para>Minimum Span for Wind Correction</para>
		/// <para>要在生成输出供电线路时应用风力校正供电线路可以跨越的最短距离。默认值为 60 米。</para>
		/// <para><see cref="MinWindSpanEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		[Category("Wind Correction")]
		public object MinWindSpan { get; set; } = "60 Meters";

		/// <summary>
		/// <para>Maximum Deviation Angle</para>
		/// <para>风力预期偏离给定供电线路的最大角度。默认值为 10°。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPRangeDomain(Min = 0.10000000000000001, Max = 89.999999000000003)]
		[Category("Wind Correction")]
		public object MaxWindDeviation { get; set; } = "10";

		/// <summary>
		/// <para>End Point Search Radius</para>
		/// <para>用于识别连接到同一电线杆或输电塔的供电线路段的公共悬挂点的距离。默认值为 10 米。</para>
		/// <para><see cref="EndPointSearchRadiusEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		[Category("End Point Adjustment")]
		public object EndPointSearchRadius { get; set; } = "10 Meters";

		/// <summary>
		/// <para>Minimum Wire Length</para>
		/// <para>可用于确定是否存在公共端点的最短导线长度。默认值为 5 米。</para>
		/// <para><see cref="MinLengthEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		[Category("End Point Adjustment")]
		public object MinLength { get; set; } = "5 Meters";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractPowerLinesFromPointCloud SetEnviroment(object XYResolution = null, object XYTolerance = null, object ZResolution = null, object ZTolerance = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Point Tolerance</para>
		/// </summary>
		public enum PointToleranceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Decimeters")]
			[Description("Decimeters")]
			Decimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Centimeters")]
			[Description("Centimeters")]
			Centimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Inches")]
			[Description("Inches")]
			Inches,

		}

		/// <summary>
		/// <para>Wire Separation Distance</para>
		/// </summary>
		public enum SeparationDistanceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Decimeters")]
			[Description("Decimeters")]
			Decimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Centimeters")]
			[Description("Centimeters")]
			Centimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Inches")]
			[Description("Inches")]
			Inches,

		}

		/// <summary>
		/// <para>Maximum Wire Sampling Gap</para>
		/// </summary>
		public enum MaxSamplingGapEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Decimeters")]
			[Description("Decimeters")]
			Decimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Centimeters")]
			[Description("Centimeters")]
			Centimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Inches")]
			[Description("Inches")]
			Inches,

		}

		/// <summary>
		/// <para>Output Line Tolerance</para>
		/// </summary>
		public enum LineToleranceEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Decimeters")]
			[Description("Decimeters")]
			Decimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Centimeters")]
			[Description("Centimeters")]
			Centimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Inches")]
			[Description("Inches")]
			Inches,

		}

		/// <summary>
		/// <para>Adjust for wind distortion</para>
		/// </summary>
		public enum WindCorrectionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("WIND")]
			WIND,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_WIND")]
			NO_WIND,

		}

		/// <summary>
		/// <para>Minimum Span for Wind Correction</para>
		/// </summary>
		public enum MinWindSpanEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Decimeters")]
			[Description("Decimeters")]
			Decimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Centimeters")]
			[Description("Centimeters")]
			Centimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Inches")]
			[Description("Inches")]
			Inches,

		}

		/// <summary>
		/// <para>End Point Search Radius</para>
		/// </summary>
		public enum EndPointSearchRadiusEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Decimeters")]
			[Description("Decimeters")]
			Decimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Centimeters")]
			[Description("Centimeters")]
			Centimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Inches")]
			[Description("Inches")]
			Inches,

		}

		/// <summary>
		/// <para>Minimum Wire Length</para>
		/// </summary>
		public enum MinLengthEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Meters")]
			[Description("Meters")]
			Meters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Decimeters")]
			[Description("Decimeters")]
			Decimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Centimeters")]
			[Description("Centimeters")]
			Centimeters,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Yards")]
			[Description("Yards")]
			Yards,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Feet")]
			[Description("Feet")]
			Feet,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("Inches")]
			[Description("Inches")]
			Inches,

		}

#endregion
	}
}
