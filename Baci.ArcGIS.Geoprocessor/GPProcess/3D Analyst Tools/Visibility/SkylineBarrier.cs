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
	/// <para>Skyline Barrier</para>
	/// <para>天际线障碍物</para>
	/// <para>生成表示天际线障碍物或阴影体积的多面体要素类。</para>
	/// </summary>
	public class SkylineBarrier : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InObserverPointFeatures">
		/// <para>Input Observer Point Features</para>
		/// <para>包含观察点的点要素类。</para>
		/// </param>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>表示天际线的输入线要素类，或表示轮廓的输入多面体要素类。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output  Feature Class</para>
		/// <para>将放置天际线障碍物或阴影体积的输出要素类。</para>
		/// </param>
		public SkylineBarrier(object InObserverPointFeatures, object InFeatures, object OutFeatureClass)
		{
			this.InObserverPointFeatures = InObserverPointFeatures;
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 天际线障碍物</para>
		/// </summary>
		public override string DisplayName() => "天际线障碍物";

		/// <summary>
		/// <para>Tool Name : SkylineBarrier</para>
		/// </summary>
		public override string ToolName() => "SkylineBarrier";

		/// <summary>
		/// <para>Tool Excute Name : 3d.SkylineBarrier</para>
		/// </summary>
		public override string ExcuteName() => "3d.SkylineBarrier";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "ZDomain", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InObserverPointFeatures, InFeatures, OutFeatureClass, MinRadiusValueOrField!, MaxRadiusValueOrField!, Closed!, BaseElevation!, ProjectToPlane! };

		/// <summary>
		/// <para>Input Observer Point Features</para>
		/// <para>包含观察点的点要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object InObserverPointFeatures { get; set; }

		/// <summary>
		/// <para>Input Features</para>
		/// <para>表示天际线的输入线要素类，或表示轮廓的输入多面体要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "MultiPatch")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output  Feature Class</para>
		/// <para>将放置天际线障碍物或阴影体积的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Minimum Radius</para>
		/// <para>三角形边将从观察点延伸的最小半径。 例如，值为 10 米意味着所有输出障碍物要素将从其原点延伸至少 10 米。 默认值为 0，表示不强制执行最小距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? MinRadiusValueOrField { get; set; } = "0 Meters";

		/// <summary>
		/// <para>Maximum Radius</para>
		/// <para>三角形边将从观察点延伸的最大半径。 默认值为 0，表示不强制执行最大距离。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? MaxRadiusValueOrField { get; set; } = "0 Meters";

		/// <summary>
		/// <para>Closed</para>
		/// <para>指定是否将向天际线障碍物添加裙状伪影和基础高程，以便多面体显示为闭合实体。</para>
		/// <para>未选中 - 不会向多面体添加裙状伪影和基础高程；仅表示从观察点到天际线的表面的多面体。 这是默认设置。</para>
		/// <para>选中 - 将向多面体添加裙状伪影和基础高程以形成闭合实体外观。</para>
		/// <para><see cref="ClosedEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? Closed { get; set; } = "false";

		/// <summary>
		/// <para>Base Elevation</para>
		/// <para>闭合多面体的基础高程。 如果未选中闭合参数，则忽略此参数。 默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object? BaseElevation { get; set; } = "0 Meters";

		/// <summary>
		/// <para>Project to Plane</para>
		/// <para>指定障碍物的正面（靠近观察点）和背面（远离观察点）是否将分别投影到垂直平面上。 通常情况下，将选中此选项以创建阴影体。</para>
		/// <para>未选中 - 障碍物将从观察点延伸到天际线（如果为最小半径和最大半径提供非零值，则将更近或更远）。 这是默认设置。</para>
		/// <para>选中 - 障碍物将从一个垂直平面延伸到另一垂直平面。</para>
		/// <para><see cref="ProjectToPlaneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? ProjectToPlane { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SkylineBarrier SetEnviroment(object? XYDomain = null , object? ZDomain = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, ZDomain: ZDomain, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Closed</para>
		/// </summary>
		public enum ClosedEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CLOSED")]
			CLOSED,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CLOSED")]
			NO_CLOSED,

		}

		/// <summary>
		/// <para>Project to Plane</para>
		/// </summary>
		public enum ProjectToPlaneEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PROJECT_TO_PLANE")]
			PROJECT_TO_PLANE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_PROJECT_TO_PLANE")]
			NO_PROJECT_TO_PLANE,

		}

#endregion
	}
}
