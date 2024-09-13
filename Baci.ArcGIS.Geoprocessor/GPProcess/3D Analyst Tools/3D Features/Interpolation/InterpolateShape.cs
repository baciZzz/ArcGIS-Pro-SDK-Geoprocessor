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
	/// <para>Interpolate Shape</para>
	/// <para>插值 Shape</para>
	/// <para>通过从表面插入 Z 值创建 3D 要素。</para>
	/// </summary>
	public class InterpolateShape : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>用于插入 Z 值的表面。</para>
		/// </param>
		/// <param name="InFeatureClass">
		/// <para>Input Features</para>
		/// <para>待处理的输入要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </param>
		public InterpolateShape(object InSurface, object InFeatureClass, object OutFeatureClass)
		{
			this.InSurface = InSurface;
			this.InFeatureClass = InFeatureClass;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 插值 Shape</para>
		/// </summary>
		public override string DisplayName() => "插值 Shape";

		/// <summary>
		/// <para>Tool Name : InterpolateShape</para>
		/// </summary>
		public override string ToolName() => "InterpolateShape";

		/// <summary>
		/// <para>Tool Excute Name : 3d.InterpolateShape</para>
		/// </summary>
		public override string ExcuteName() => "3d.InterpolateShape";

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
		public override string[] ValidEnvironments() => new string[] { "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSurface, InFeatureClass, OutFeatureClass, SampleDistance, ZFactor, Method, VerticesOnly, PyramidLevelResolution, PreserveFeatures };

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>用于插入 Z 值的表面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Input Features</para>
		/// <para>待处理的输入要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon", "Point", "Multipoint")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Sampling Distance</para>
		/// <para>用于内插 z 值的间距。默认情况下，该参数是栅格数据集的像元大小或三角化网格面的自然增密。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object SampleDistance { get; set; }

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>Z 值将乘上的系数。 此值通常用于转换 z 线性单位来匹配 x,y 线性单位。 默认值为 1，此时高程值保持不变。 如果输入表面的空间参考具有已指定线性单位的 z 基准，则此参数不可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Method</para>
		/// <para>用于确定输出要素的高程值的插值方法。可用选项取决于正在使用的表面类型。</para>
		/// <para>双线性法—可使用双线性插值法来确定查询点的值。如果输入为栅格表面，则其为默认值。</para>
		/// <para>最邻近法—可使用最邻近插值法来确定查询点的值。如果使用此方法，则将仅针对输入要素的折点对表面值进行插值。此选项仅适用于栅格表面。</para>
		/// <para>线性— TIN、terrain 和 LAS 数据集的默认插值方法。根据由三角形（包含查询点 XY 位置）定义的平面获取高程。</para>
		/// <para>自然邻域法— 通过将基于区域的权重应用于查询点的自然邻域获取高程。</para>
		/// <para>合并最小 Z 值— 根据在查询点自然邻域中找到的最小 z 值获取高程。</para>
		/// <para>合并最大 Z 值— 根据在查询点自然邻域中找到的最大 z 值获取高程。</para>
		/// <para>合并最近的 Z 值— 根据查询点自然邻域中的最近值获取高程。</para>
		/// <para>合并最接近平均值的 z 值— 根据距查询点所有自然邻域的平均值最近的 z 值获取高程。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "LINEAR";

		/// <summary>
		/// <para>Interpolate Vertices Only</para>
		/// <para>指定是否仅沿输入要素的折点进行插值，从而忽略采样距离选项。如果输入表面为栅格并且选择最邻近插值法，则只能在要素折点处插值 z 值。</para>
		/// <para>已选中 - 沿折点插值。</para>
		/// <para>取消选中 - 使用采样距离插值。这是默认设置。</para>
		/// <para><see cref="VerticesOnlyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object VerticesOnly { get; set; } = "false";

		/// <summary>
		/// <para>Pyramid Level Resolution</para>
		/// <para>将使用 terrain 金字塔等级的 z 容差或窗口大小分辨率。 默认值为 0，或全分辨率。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object PyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Preserve features partially outside surface</para>
		/// <para>指定是否将在输出中保留一个或多个折点落在栅格数据区域范围之外的要素。此参数仅当输入表面为栅格并且使用最邻近插值法时可用。</para>
		/// <para>选中 - 落在栅格表面范围之外的每个折点都将具有各自的 z 值，此值派生自针对栅格表面内的折点计算的 z 值趋势。</para>
		/// <para>未选中 - 将在输出中跳过至少一个折点落在栅格表面范围之外的要素。这是默认设置。</para>
		/// <para><see cref="PreserveFeaturesEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object PreserveFeatures { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public InterpolateShape SetEnviroment(object XYResolution = null , object XYTolerance = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>线性— TIN、terrain 和 LAS 数据集的默认插值方法。根据由三角形（包含查询点 XY 位置）定义的平面获取高程。</para>
			/// </summary>
			[GPValue("LINEAR")]
			[Description("线性")]
			Linear,

			/// <summary>
			/// <para>自然邻域法— 通过将基于区域的权重应用于查询点的自然邻域获取高程。</para>
			/// </summary>
			[GPValue("NATURAL_NEIGHBORS")]
			[Description("自然邻域法")]
			Natural_Neighbors,

			/// <summary>
			/// <para>合并最小 Z 值— 根据在查询点自然邻域中找到的最小 z 值获取高程。</para>
			/// </summary>
			[GPValue("CONFLATE_ZMIN")]
			[Description("合并最小 Z 值")]
			Conflate_Minimum_Z,

			/// <summary>
			/// <para>合并最大 Z 值— 根据在查询点自然邻域中找到的最大 z 值获取高程。</para>
			/// </summary>
			[GPValue("CONFLATE_ZMAX")]
			[Description("合并最大 Z 值")]
			Conflate_Maximum_Z,

			/// <summary>
			/// <para>合并最近的 Z 值— 根据查询点自然邻域中的最近值获取高程。</para>
			/// </summary>
			[GPValue("CONFLATE_NEAREST")]
			[Description("合并最近的 Z 值")]
			Conflate_Nearest_Z,

			/// <summary>
			/// <para>合并最接近平均值的 z 值— 根据距查询点所有自然邻域的平均值最近的 z 值获取高程。</para>
			/// </summary>
			[GPValue("CONFLATE_CLOSEST_TO_MEAN")]
			[Description("合并最接近平均值的 z 值")]
			Conflate_Z_Closest_To_Mean,

			/// <summary>
			/// <para>双线性法—可使用双线性插值法来确定查询点的值。如果输入为栅格表面，则其为默认值。</para>
			/// </summary>
			[GPValue("BILINEAR")]
			[Description("双线性法")]
			Bilinear,

			/// <summary>
			/// <para>最邻近法—可使用最邻近插值法来确定查询点的值。如果使用此方法，则将仅针对输入要素的折点对表面值进行插值。此选项仅适用于栅格表面。</para>
			/// </summary>
			[GPValue("NEAREST")]
			[Description("最邻近法")]
			Nearest_Neighbor,

		}

		/// <summary>
		/// <para>Interpolate Vertices Only</para>
		/// </summary>
		public enum VerticesOnlyEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("VERTICES_ONLY")]
			VERTICES_ONLY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DENSIFY")]
			DENSIFY,

		}

		/// <summary>
		/// <para>Preserve features partially outside surface</para>
		/// </summary>
		public enum PreserveFeaturesEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("PRESERVE")]
			PRESERVE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("EXCLUDE")]
			EXCLUDE,

		}

#endregion
	}
}
