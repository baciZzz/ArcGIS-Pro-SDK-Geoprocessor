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
	/// <para>Construct Sight Lines</para>
	/// <para>构造视线</para>
	/// <para>创建表示视线（从一个或多个视点到目标要素类的要素）的线要素。</para>
	/// </summary>
	public class ConstructSightLines : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InObserverPoints">
		/// <para>Observer Points</para>
		/// <para>表示观察点的单点要素。不支持多点要素。</para>
		/// </param>
		/// <param name="InTargetFeatures">
		/// <para>Target Features</para>
		/// <para>目标要素（点、多点、线和面）。</para>
		/// </param>
		/// <param name="OutLineFeatureClass">
		/// <para>Output</para>
		/// <para>包含视线的输出要素类。</para>
		/// </param>
		public ConstructSightLines(object InObserverPoints, object InTargetFeatures, object OutLineFeatureClass)
		{
			this.InObserverPoints = InObserverPoints;
			this.InTargetFeatures = InTargetFeatures;
			this.OutLineFeatureClass = OutLineFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 构造视线</para>
		/// </summary>
		public override string DisplayName() => "构造视线";

		/// <summary>
		/// <para>Tool Name : ConstructSightLines</para>
		/// </summary>
		public override string ToolName() => "ConstructSightLines";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ConstructSightLines</para>
		/// </summary>
		public override string ExcuteName() => "3d.ConstructSightLines";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InObserverPoints, InTargetFeatures, OutLineFeatureClass, ObserverHeightField, TargetHeightField, JoinField, SampleDistance, OutputTheDirection, SamplingMethod };

		/// <summary>
		/// <para>Observer Points</para>
		/// <para>表示观察点的单点要素。不支持多点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InObserverPoints { get; set; }

		/// <summary>
		/// <para>Target Features</para>
		/// <para>目标要素（点、多点、线和面）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polyline", "Polygon")]
		public object InTargetFeatures { get; set; }

		/// <summary>
		/// <para>Output</para>
		/// <para>包含视线的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutLineFeatureClass { get; set; }

		/// <summary>
		/// <para>Observer Height Field</para>
		/// <para>从观察点属性表获得的观察点高度值的源。</para>
		/// <para>从按优先级顺序列出的以下选项中选择默认的观察者高度字段字段。如果存在多个字段并且所需字段在默认字段选择上没有更高优先级，将需要指定所需字段。</para>
		/// <para>无高度源—不会将 Z 值分配至生成的视线要素。</para>
		/// <para>Shape.Z</para>
		/// <para>Spot</para>
		/// <para>Z</para>
		/// <para>Z_Value</para>
		/// <para>Height</para>
		/// <para>Elev</para>
		/// <para>Elevation</para>
		/// <para>Contour</para>
		/// <para><see cref="ObserverHeightFieldEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ObserverHeightField { get; set; } = "<None>";

		/// <summary>
		/// <para>Target Height Field</para>
		/// <para>目标的高度字段。</para>
		/// <para>从按优先级顺序列出的以下选项中选择默认的目标高度字段字段。如果存在多个字段并且所需字段在默认字段选择上没有更高优先级，将需要指定所需字段。</para>
		/// <para>无高度源—不会将 Z 值分配至生成的视线要素。</para>
		/// <para>Shape.Z</para>
		/// <para>Spot</para>
		/// <para>Z</para>
		/// <para>Z_Value</para>
		/// <para>Height</para>
		/// <para>Elev</para>
		/// <para>Elevation</para>
		/// <para>Contour</para>
		/// <para><see cref="TargetHeightFieldEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object TargetHeightField { get; set; } = "<None>";

		/// <summary>
		/// <para>Join Field</para>
		/// <para>使用连接字段将观察者与特定目标相匹配。</para>
		/// <para>无连接字段—不会将 Z 值分配至生成的视线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object JoinField { get; set; } = "<None>";

		/// <summary>
		/// <para>Sampling Distance</para>
		/// <para>目标为线或面要素类时采样之间的距离。按输出要素类的 XY 单位解释采样距离单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[GPNumericDomain()]
		[Low(Inclusive = false, Value = 1.0000000000000001e-05)]
		public object SampleDistance { get; set; } = "1";

		/// <summary>
		/// <para>Output The Direction</para>
		/// <para>向输出视线添加方向属性。将添加并填充两个附加字段以指示方向：AZIMUTH 和 VERT_ANGLE（垂直角）。</para>
		/// <para>未选中 - 不会向输出视线添加方向属性。这是默认设置。</para>
		/// <para>选中 - 将添加并填充两个附加字段以指示方向：方位角和垂直角。</para>
		/// <para><see cref="OutputTheDirectionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object OutputTheDirection { get; set; } = "false";

		/// <summary>
		/// <para>Sampling Method</para>
		/// <para>指定将如何使用采样距离沿目标要素创建视线。</para>
		/// <para>2D 距离—将在二维笛卡尔空间中评估距离。这是默认设置。</para>
		/// <para>3D 距离—将以三维长度评估距离。</para>
		/// <para><see cref="SamplingMethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object SamplingMethod { get; set; } = "2D_DISTANCE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ConstructSightLines SetEnviroment(object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, int? autoCommit = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Observer Height Field</para>
		/// </summary>
		public enum ObserverHeightFieldEnum 
		{
			/// <summary>
			/// <para>无高度源—不会将 Z 值分配至生成的视线要素。</para>
			/// </summary>
			[GPValue("<None>")]
			[Description("无高度源")]
			No_Height_Source,

		}

		/// <summary>
		/// <para>Target Height Field</para>
		/// </summary>
		public enum TargetHeightFieldEnum 
		{
			/// <summary>
			/// <para>无高度源—不会将 Z 值分配至生成的视线要素。</para>
			/// </summary>
			[GPValue("<None>")]
			[Description("无高度源")]
			No_Height_Source,

		}

		/// <summary>
		/// <para>Output The Direction</para>
		/// </summary>
		public enum OutputTheDirectionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("OUTPUT_THE_DIRECTION")]
			OUTPUT_THE_DIRECTION,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_OUTPUT_THE_DIRECTION")]
			NOT_OUTPUT_THE_DIRECTION,

		}

		/// <summary>
		/// <para>Sampling Method</para>
		/// </summary>
		public enum SamplingMethodEnum 
		{
			/// <summary>
			/// <para>2D 距离—将在二维笛卡尔空间中评估距离。这是默认设置。</para>
			/// </summary>
			[GPValue("2D_DISTANCE")]
			[Description("2D 距离")]
			_2D_distance,

			/// <summary>
			/// <para>3D 距离—将以三维长度评估距离。</para>
			/// </summary>
			[GPValue("3D_DISTANCE")]
			[Description("3D 距离")]
			_3D_distance,

		}

#endregion
	}
}
