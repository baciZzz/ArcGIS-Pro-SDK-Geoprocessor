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
	/// <para>Skyline</para>
	/// <para>天际线</para>
	/// <para>生成一个包含天际线或轮廓分析结果的线要素类或多面体要素类。</para>
	/// </summary>
	public class Skyline : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InObserverPointFeatures">
		/// <para>Input Observer Point Features</para>
		/// <para>表示观察点的 3D 点。每个要素都将具有自己的输出。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>表示天际线的线或表示轮廓的多面体的3D 要素。</para>
		/// </param>
		public Skyline(object InObserverPointFeatures, object OutFeatureClass)
		{
			this.InObserverPointFeatures = InObserverPointFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 天际线</para>
		/// </summary>
		public override string DisplayName() => "天际线";

		/// <summary>
		/// <para>Tool Name : 天际线</para>
		/// </summary>
		public override string ToolName() => "天际线";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Skyline</para>
		/// </summary>
		public override string ExcuteName() => "3d.Skyline";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "geographicTransformations", "outputCoordinateSystem", "terrainMemoryUsage", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InObserverPointFeatures, OutFeatureClass, InSurface, VirtualSurfaceRadius, VirtualSurfaceElevation, InFeatures, FeatureLod, FromAzimuthValueOrField, ToAzimuthValueOrField, AzimuthIncrementValueOrField, MaxHorizonRadius, SegmentSkyline, ScaleToPercent, ScaleAccordingTo, ScaleMethod, UseCurvature, UseRefraction, RefractionFactor, PyramidLevelResolution, CreateSilhouettes };

		/// <summary>
		/// <para>Input Observer Point Features</para>
		/// <para>表示观察点的 3D 点。每个要素都将具有自己的输出。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InObserverPointFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>表示天际线的线或表示轮廓的多面体的3D 要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>将用于定义地平线的地形面。如果未提供表面，则会通过使用虚拟表面半径和虚拟表面高程参数采用一个虚拟表面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Virtual Surface Radius</para>
		/// <para>未提供地形面时，用于定义地平线的虚拟表面的半径。默认值是 1,000 米。</para>
		/// <para>支持的单位如下：</para>
		/// <para>未知—未知</para>
		/// <para>英寸—英寸</para>
		/// <para>英尺—英尺</para>
		/// <para>码—码</para>
		/// <para>英里—英里</para>
		/// <para>毫米—毫米</para>
		/// <para>厘米—厘米</para>
		/// <para>公寸—公寸</para>
		/// <para>米—米</para>
		/// <para>千米—千米</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object VirtualSurfaceRadius { get; set; } = "1000 Meters";

		/// <summary>
		/// <para>Virtual Surface Elevation</para>
		/// <para>代替实际表面来定义地平线的虚拟表面的高程。如果提供了实际表面，则可忽略。默认值为 0。</para>
		/// <para>支持的单位如下：</para>
		/// <para>未知—未知</para>
		/// <para>英寸—英寸</para>
		/// <para>英尺—英尺</para>
		/// <para>码—码</para>
		/// <para>英里—英里</para>
		/// <para>毫米—毫米</para>
		/// <para>厘米—厘米</para>
		/// <para>公寸—公寸</para>
		/// <para>米—米</para>
		/// <para>千米—千米</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object VirtualSurfaceElevation { get; set; } = "0 Meters";

		/// <summary>
		/// <para>Input Features</para>
		/// <para>用于测定天际线的要素。如果没有指定要素，则天际线将只由地平线（通过地形面或虚拟表面定义）构成。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("MultiPatch")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Feature Level of Detail</para>
		/// <para>在天际线分析中检查每个要素的细节层次。</para>
		/// <para>详细信息—在天际线分析中考虑要素中的每条边（仅限三角形和外部环的边）。此时，消耗大量时间的操作最为精确，也是默认选项。</para>
		/// <para>凸轮廓—天际线分析将使用每个要素轮廓线的凸包（拉伸到要素内最高折点的高程）的上部周长。</para>
		/// <para>包络— 天际线分析将使用三维要素包络的周长。这是最快的方法。</para>
		/// <para><see cref="FeatureLodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object FeatureLod { get; set; } = "FULL_DETAIL";

		/// <summary>
		/// <para>From Azimuth</para>
		/// <para>开始天际线分析的方位角，以度为单位。天际线分析以观察点为起点，并从起始方位角向右移动，直到结束方位角。方位角必须大于负 360 且小于 360。默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Azimuths")]
		public object FromAzimuthValueOrField { get; set; } = "0";

		/// <summary>
		/// <para>To Azimuth</para>
		/// <para>完成天际线分析的方位角，以度为单位。天际线分析以观察点为起点，并从起始方位角向右移动，直到结束方位角。结束方位角必须大于起始方位角，且不得超过 360。默认值为 360。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Azimuths")]
		public object ToAzimuthValueOrField { get; set; } = "360";

		/// <summary>
		/// <para>Azimuth Increment</para>
		/// <para>在起始方位角和结束方位角之间执行天际线分析以计算地平线时的角度间隔，以度为单位。此值不得大于结束方位角与起始方位角的差值。默认值为 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		[Category("Azimuths")]
		public object AzimuthIncrementValueOrField { get; set; } = "1";

		/// <summary>
		/// <para>Maximum Horizon Radius</para>
		/// <para>从观察点位置应能搜索到地平线的最大距离。零值表明应没有施加限制。默认值为 0。</para>
		/// <para>支持的单位如下：</para>
		/// <para>未知—未知</para>
		/// <para>英寸—英寸</para>
		/// <para>英尺—英尺</para>
		/// <para>码—码</para>
		/// <para>英里—英里</para>
		/// <para>毫米—毫米</para>
		/// <para>厘米—厘米</para>
		/// <para>公寸—公寸</para>
		/// <para>米—米</para>
		/// <para>千米—千米</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		[Category("Skyline Options")]
		public object MaxHorizonRadius { get; set; } = "0 Meters";

		/// <summary>
		/// <para>Segment Skyline</para>
		/// <para>确定生成的天际线是为每个观察点对应一个要素，还是每个观察点的天际线将按照构成天际线的唯一元素进行分段。</para>
		/// <para>如果正在生成轮廓，那么此参数将指示是否使用发散光线；对于太阳阴影，此参数的状态通常为禁用或未选中。</para>
		/// <para>未选中 - 每个天际线要素将表示一个观察点。这是默认设置。</para>
		/// <para>选中 - 每个观察点的天际线都将按照构成天际线的唯一元素进行分段。</para>
		/// <para><see cref="SegmentSkylineEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Skyline Options")]
		public object SegmentSkyline { get; set; } = "false";

		/// <summary>
		/// <para>Scale To Percent</para>
		/// <para>表示放置每个天际线折点应依据的原始垂直角（地平线以上的角或高程角）或高程的缩放百分比。如果输入 0 或 100，则不会进行缩放。默认值为 100。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Scaling Options")]
		public object ScaleToPercent { get; set; } = "100";

		/// <summary>
		/// <para>Scale According To</para>
		/// <para>确定缩放所依据的值。</para>
		/// <para>基于观察点的垂直角度—通过考虑每个折点相对于观察点的垂直角确定缩放。这是默认设置。</para>
		/// <para>高程—通过考虑每个折点相对于观察点的高度确定缩放。</para>
		/// <para><see cref="ScaleAccordingToEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Scaling Options")]
		public object ScaleAccordingTo { get; set; } = "VERTICAL_ANGLE";

		/// <summary>
		/// <para>Scale Method</para>
		/// <para>计算折点所依据的缩放方法。</para>
		/// <para>天际线最大值—将相对于具有最高垂直角（或高程）的折点的垂直角（或高程）进行缩放。这是默认设置。</para>
		/// <para>每个折点—将相对于每个折点的原始垂直角（或高程）进行缩放。</para>
		/// <para><see cref="ScaleMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Scaling Options")]
		public object ScaleMethod { get; set; } = "SKYLINE_MAXIMUM";

		/// <summary>
		/// <para>Use Curvature</para>
		/// <para>指示根据作用表面生成山脊线时，是否要考虑地球的曲率。</para>
		/// <para>未选中 - 将不考虑地球的曲率。这是默认设置。</para>
		/// <para>选中 - 将考虑地球的曲率。</para>
		/// <para><see cref="UseCurvatureEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Surface Options")]
		public object UseCurvature { get; set; } = "false";

		/// <summary>
		/// <para>Use Refraction</para>
		/// <para>指示根据作用表面生成山脊线时，是否要考虑应用大气折射。</para>
		/// <para>未选中 - 将不考虑大气折射。这是默认设置。</para>
		/// <para>选中 - 将考虑大气折射。</para>
		/// <para><see cref="UseRefractionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Surface Options")]
		public object UseRefraction { get; set; } = "false";

		/// <summary>
		/// <para>Refraction Factor</para>
		/// <para>考虑大气折射时使用的折射系数。默认值为 0.13。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Surface Options")]
		public object RefractionFactor { get; set; } = "0.13";

		/// <summary>
		/// <para>Pyramid Level Resolution</para>
		/// <para>此工具将使用 terrain 金字塔等级的 z 容差或窗口大小分辨率。默认值为 0（z 容差），或全分辨率（窗口大小）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Surface Options")]
		public object PyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Create Silhouettes</para>
		/// <para>指定输出要素是表示天际线还是轮廓。</para>
		/// <para>未选中 - 输出将创建为表示天际线的折线要素。这是默认设置。</para>
		/// <para>选中 - 输出将创建为表示轮廓的多面体要素。</para>
		/// <para><see cref="CreateSilhouettesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Skyline Options")]
		public object CreateSilhouettes { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Skyline SetEnviroment(object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, int? autoCommit = null, object configKeyword = null, object geographicTransformations = null, object outputCoordinateSystem = null, object terrainMemoryUsage = null, object workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, terrainMemoryUsage: terrainMemoryUsage, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Feature Level of Detail</para>
		/// </summary>
		public enum FeatureLodEnum 
		{
			/// <summary>
			/// <para>详细信息—在天际线分析中考虑要素中的每条边（仅限三角形和外部环的边）。此时，消耗大量时间的操作最为精确，也是默认选项。</para>
			/// </summary>
			[GPValue("FULL_DETAIL")]
			[Description("详细信息")]
			Full_Detail,

			/// <summary>
			/// <para>凸轮廓—天际线分析将使用每个要素轮廓线的凸包（拉伸到要素内最高折点的高程）的上部周长。</para>
			/// </summary>
			[GPValue("CONVEX_FOOTPRINT")]
			[Description("凸轮廓")]
			Convex_Footprint,

			/// <summary>
			/// <para>包络— 天际线分析将使用三维要素包络的周长。这是最快的方法。</para>
			/// </summary>
			[GPValue("ENVELOPE")]
			[Description("包络")]
			Envelope,

		}

		/// <summary>
		/// <para>Segment Skyline</para>
		/// </summary>
		public enum SegmentSkylineEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("SEGMENT_SKYLINE")]
			SEGMENT_SKYLINE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SEGMENT_SKYLINE")]
			NO_SEGMENT_SKYLINE,

		}

		/// <summary>
		/// <para>Scale According To</para>
		/// </summary>
		public enum ScaleAccordingToEnum 
		{
			/// <summary>
			/// <para>基于观察点的垂直角度—通过考虑每个折点相对于观察点的垂直角确定缩放。这是默认设置。</para>
			/// </summary>
			[GPValue("VERTICAL_ANGLE")]
			[Description("基于观察点的垂直角度")]
			Vertical_Angle_From_Observer,

			/// <summary>
			/// <para>高程—通过考虑每个折点相对于观察点的高度确定缩放。</para>
			/// </summary>
			[GPValue("ELEVATION")]
			[Description("高程")]
			Elevation,

		}

		/// <summary>
		/// <para>Scale Method</para>
		/// </summary>
		public enum ScaleMethodEnum 
		{
			/// <summary>
			/// <para>天际线最大值—将相对于具有最高垂直角（或高程）的折点的垂直角（或高程）进行缩放。这是默认设置。</para>
			/// </summary>
			[GPValue("SKYLINE_MAXIMUM")]
			[Description("天际线最大值")]
			Skyline_Maximum,

			/// <summary>
			/// <para>每个折点—将相对于每个折点的原始垂直角（或高程）进行缩放。</para>
			/// </summary>
			[GPValue("EACH_VERTEX")]
			[Description("每个折点")]
			Each_Vertex,

		}

		/// <summary>
		/// <para>Use Curvature</para>
		/// </summary>
		public enum UseCurvatureEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CURVATURE")]
			CURVATURE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CURVATURE")]
			NO_CURVATURE,

		}

		/// <summary>
		/// <para>Use Refraction</para>
		/// </summary>
		public enum UseRefractionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("REFRACTION")]
			REFRACTION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_REFRACTION")]
			NO_REFRACTION,

		}

		/// <summary>
		/// <para>Create Silhouettes</para>
		/// </summary>
		public enum CreateSilhouettesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CREATE_SILHOUETTES")]
			CREATE_SILHOUETTES,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CREATE_SILHOUETTES")]
			NO_CREATE_SILHOUETTES,

		}

#endregion
	}
}
