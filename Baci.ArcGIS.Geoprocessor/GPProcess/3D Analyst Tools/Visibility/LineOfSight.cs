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
	/// <para>Line Of Sight</para>
	/// <para>通视分析</para>
	/// <para>确定穿过由表面和可选多面体数据集组成的障碍物的视线的可见性。</para>
	/// </summary>
	public class LineOfSight : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>集成网格场景图层、LAS 数据集、栅格、TIN 或者用于确定可见性的地形表面。</para>
		/// </param>
		/// <param name="InLineFeatureClass">
		/// <para>Input Line Features</para>
		/// <para>线要素，其第一个折点定义为观测点，最后一个折点标识目标位置。观测和目标位置的高度通过 3D 要素的 z 值获得，并且通过 2D 要素的表面插值。</para>
		/// <para>2D 线还将默认偏移量 1 添加到其高程，以使点位于表面之上。如果要素含有一个 OffsetA 字段，其值将加到观测点的高度上。如果存在 OffsetB 字段，其值将加到目标位置的高度上。</para>
		/// </param>
		/// <param name="OutLosFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>确定可见性所依据的输出线要素类。将创建两个属性字段。VisCode 字段表示沿线的可见性：1 表示可见，2 表示不可见。TarIsVis 字段表示目标可见性：0 表示不可见，1 表示可见。</para>
		/// </param>
		public LineOfSight(object InSurface, object InLineFeatureClass, object OutLosFeatureClass)
		{
			this.InSurface = InSurface;
			this.InLineFeatureClass = InLineFeatureClass;
			this.OutLosFeatureClass = OutLosFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 通视分析</para>
		/// </summary>
		public override string DisplayName() => "通视分析";

		/// <summary>
		/// <para>Tool Name : LineOfSight</para>
		/// </summary>
		public override string ToolName() => "LineOfSight";

		/// <summary>
		/// <para>Tool Excute Name : 3d.LineOfSight</para>
		/// </summary>
		public override string ExcuteName() => "3d.LineOfSight";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "terrainMemoryUsage", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSurface, InLineFeatureClass, OutLosFeatureClass, OutObstructionFeatureClass!, UseCurvature!, UseRefraction!, RefractionFactor!, PyramidLevelResolution!, InFeatures! };

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>集成网格场景图层、LAS 数据集、栅格、TIN 或者用于确定可见性的地形表面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>线要素，其第一个折点定义为观测点，最后一个折点标识目标位置。观测和目标位置的高度通过 3D 要素的 z 值获得，并且通过 2D 要素的表面插值。</para>
		/// <para>2D 线还将默认偏移量 1 添加到其高程，以使点位于表面之上。如果要素含有一个 OffsetA 字段，其值将加到观测点的高度上。如果存在 OffsetB 字段，其值将加到目标位置的高度上。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InLineFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>确定可见性所依据的输出线要素类。将创建两个属性字段。VisCode 字段表示沿线的可见性：1 表示可见，2 表示不可见。TarIsVis 字段表示目标可见性：0 表示不可见，1 表示可见。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutLosFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Obstruction Point Feature Class</para>
		/// <para>一个可选点要素类，用于标识其目标的观察点视线上的第一个障碍物的位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutObstructionFeatureClass { get; set; }

		/// <summary>
		/// <para>Use Curvature</para>
		/// <para>指定在视线分析时是否将考虑地球的曲率。若激活此参数，则表面必须具有采用含已定义 z 单位的投影坐标定义的空间参考。</para>
		/// <para>未选中 - 将不考虑地球的曲率。这是默认设置。</para>
		/// <para>选中 - 将考虑地球的曲率。</para>
		/// <para><see cref="UseCurvatureEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Surface Options")]
		public object? UseCurvature { get; set; } = "false";

		/// <summary>
		/// <para>Use Refraction</para>
		/// <para>指定在通过作用表面生成一条视线时是否将考虑大气折射。如果使用了多面体要素，则此参数不适用。</para>
		/// <para>未选中 - 将不考虑大气折射。这是默认设置。</para>
		/// <para>选中 - 将考虑大气折射。</para>
		/// <para><see cref="UseRefractionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Surface Options")]
		public object? UseRefraction { get; set; } = "false";

		/// <summary>
		/// <para>Refraction Factor</para>
		/// <para>要用于折射系数中的值。默认值为 0.13。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Surface Options")]
		public object? RefractionFactor { get; set; } = "0.13";

		/// <summary>
		/// <para>Pyramid Level Resolution</para>
		/// <para>将使用 terrain 金字塔等级的 z 容差或窗口大小分辨率。默认值为 0（z 容差），或全分辨率（窗口大小）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Surface Options")]
		public object? PyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Input Features</para>
		/// <para>可以定义其他阻碍元素（例如，建筑物）的多面体要素。此输入不支持折射选项。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("MultiPatch")]
		public object? InFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LineOfSight SetEnviroment(object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, int? autoCommit = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, bool? terrainMemoryUsage = null, object? workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, terrainMemoryUsage: terrainMemoryUsage, workspace: workspace);
			return this;
		}

		#region InnerClass

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

#endregion
	}
}
