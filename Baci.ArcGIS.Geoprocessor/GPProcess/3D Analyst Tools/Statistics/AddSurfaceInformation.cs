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
	/// <para>Add Surface Information</para>
	/// <para>添加表面信息</para>
	/// <para>将获取自表面的空间信息添加到要素属性中。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AddSurfaceInformation : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass">
		/// <para>Input Features</para>
		/// <para>定义位置的点、多点、折线或面要素，用于确定一个或多个表面属性。</para>
		/// </param>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>用于内插 z 值的 LAS 数据集、镶嵌、栅格、terrain 或 TIN 表面。</para>
		/// </param>
		/// <param name="OutProperty">
		/// <para>Output Property</para>
		/// <para>将添加到输入要素类属性表中的表面高程属性。下表汇总了可用属性关键字及其支持的几何类型：</para>
		/// <para>Z—针对每个单点要素的 XY 位置插值的表面 Z 值。</para>
		/// <para>Z 最小值—由面、沿线的长度或多点记录中各点的插值定义的面积中最低的表面 Z 值。</para>
		/// <para>Z 最大值—由面、沿线的长度或多点记录中各点的插值定义的面积中最高的表面高程。</para>
		/// <para>Z 平均值—由面、沿线的长度或多点记录中各点的插值定义的面积中的平均表面高程。</para>
		/// <para>表面面积—由每个面定义的区域的 3D 表面区域。</para>
		/// <para>表面长度—沿着表面的线的 3D 距离。</para>
		/// <para>最小坡度—沿线或面定义的区域中的最接近零的坡度值。</para>
		/// <para>最大坡度—沿线或面定义的区域中的最高坡度值。</para>
		/// <para>平均坡度—沿线或面定义的区域中的平均坡度值。</para>
		/// <para><see cref="OutPropertyEnum"/></para>
		/// </param>
		public AddSurfaceInformation(object InFeatureClass, object InSurface, object OutProperty)
		{
			this.InFeatureClass = InFeatureClass;
			this.InSurface = InSurface;
			this.OutProperty = OutProperty;
		}

		/// <summary>
		/// <para>Tool Display Name : 添加表面信息</para>
		/// </summary>
		public override string DisplayName() => "添加表面信息";

		/// <summary>
		/// <para>Tool Name : AddSurfaceInformation</para>
		/// </summary>
		public override string ToolName() => "AddSurfaceInformation";

		/// <summary>
		/// <para>Tool Excute Name : 3d.AddSurfaceInformation</para>
		/// </summary>
		public override string ExcuteName() => "3d.AddSurfaceInformation";

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
		public override string[] ValidEnvironments() => new string[] { "autoCommit", "extent", "geographicTransformations", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureClass, InSurface, OutProperty, Method, SampleDistance, ZFactor, PyramidLevelResolution, NoiseFiltering, OutputFeatureClass };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>定义位置的点、多点、折线或面要素，用于确定一个或多个表面属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline", "Polygon", "Point", "Multipoint")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>用于内插 z 值的 LAS 数据集、镶嵌、栅格、terrain 或 TIN 表面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Output Property</para>
		/// <para>将添加到输入要素类属性表中的表面高程属性。下表汇总了可用属性关键字及其支持的几何类型：</para>
		/// <para>Z—针对每个单点要素的 XY 位置插值的表面 Z 值。</para>
		/// <para>Z 最小值—由面、沿线的长度或多点记录中各点的插值定义的面积中最低的表面 Z 值。</para>
		/// <para>Z 最大值—由面、沿线的长度或多点记录中各点的插值定义的面积中最高的表面高程。</para>
		/// <para>Z 平均值—由面、沿线的长度或多点记录中各点的插值定义的面积中的平均表面高程。</para>
		/// <para>表面面积—由每个面定义的区域的 3D 表面区域。</para>
		/// <para>表面长度—沿着表面的线的 3D 距离。</para>
		/// <para>最小坡度—沿线或面定义的区域中的最接近零的坡度值。</para>
		/// <para>最大坡度—沿线或面定义的区域中的最高坡度值。</para>
		/// <para>平均坡度—沿线或面定义的区域中的平均坡度值。</para>
		/// <para><see cref="OutPropertyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object OutProperty { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>用于确定表面相关信息的插值方法。可用选项取决于输入表面的数据类型：</para>
		/// <para>双线性法—可从四个最邻近的像元中确定像元值的栅格表面的专用插值方法。这是适用于栅格表面的唯一选项。</para>
		/// <para>线性— TIN、terrain 和 LAS 数据集的默认插值方法。根据由包含查询点 XY 位置的三角形定义的平面获取高程。</para>
		/// <para>自然邻域法— 通过将基于区域的权重应用于查询点的自然邻域获取高程。</para>
		/// <para>合并最小 Z 值— 根据在查询点自然邻域中找到的最小 Z 值获取高程。</para>
		/// <para>合并最大 Z 值— 根据在查询点自然邻域中找到的最大 Z 值获取高程。</para>
		/// <para>合并最近的 Z 值— 根据查询点自然邻域中的最近值获取高程。</para>
		/// <para>合并最接近平均值的 z 值— 根据距查询点所有自然邻域的平均值最近的 Z 值获取高程。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "LINEAR";

		/// <summary>
		/// <para>Sampling Distance</para>
		/// <para>用于内插 z 值的间距。默认情况下，如果输入表面是栅格，则使用栅格像元大小；如果输入是 terrain 或 TIN 数据集，则使用三角化网格面的自然增密。</para>
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
		/// <para>Pyramid Level Resolution</para>
		/// <para>将使用 terrain 金字塔等级的 z 容差或窗口大小分辨率。 默认值为 0，或全分辨率。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object PyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Noise Filtering</para>
		/// <para>排除以异常测量值为特征的部分表面参与到坡度计算过程中。线要素会提供长度过滤器，而面要素则提供面积过滤器。与任意一个过滤器选项对应的值都会以要素坐标系的线性单位进行评估。非坡度属性不受此参数影响。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object NoiseFiltering { get; set; }

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AddSurfaceInformation SetEnviroment(int? autoCommit = null, object extent = null, object geographicTransformations = null, object workspace = null)
		{
			base.SetEnv(autoCommit: autoCommit, extent: extent, geographicTransformations: geographicTransformations, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Property</para>
		/// </summary>
		public enum OutPropertyEnum 
		{
			/// <summary>
			/// <para>Z—针对每个单点要素的 XY 位置插值的表面 Z 值。</para>
			/// </summary>
			[GPValue("Z")]
			[Description("Z")]
			Z,

			/// <summary>
			/// <para>Z 最小值—由面、沿线的长度或多点记录中各点的插值定义的面积中最低的表面 Z 值。</para>
			/// </summary>
			[GPValue("Z_MIN")]
			[Description("Z 最小值")]
			Minimum_Z,

			/// <summary>
			/// <para>Z 最大值—由面、沿线的长度或多点记录中各点的插值定义的面积中最高的表面高程。</para>
			/// </summary>
			[GPValue("Z_MAX")]
			[Description("Z 最大值")]
			Maximum_Z,

			/// <summary>
			/// <para>Z 平均值—由面、沿线的长度或多点记录中各点的插值定义的面积中的平均表面高程。</para>
			/// </summary>
			[GPValue("Z_MEAN")]
			[Description("Z 平均值")]
			Mean_Z,

			/// <summary>
			/// <para>表面长度—沿着表面的线的 3D 距离。</para>
			/// </summary>
			[GPValue("SURFACE_LENGTH")]
			[Description("表面长度")]
			Surface_Length,

			/// <summary>
			/// <para>表面面积—由每个面定义的区域的 3D 表面区域。</para>
			/// </summary>
			[GPValue("SURFACE_AREA")]
			[Description("表面面积")]
			Surface_Area,

			/// <summary>
			/// <para>最小坡度—沿线或面定义的区域中的最接近零的坡度值。</para>
			/// </summary>
			[GPValue("MIN_SLOPE")]
			[Description("最小坡度")]
			Minimum_Slope,

			/// <summary>
			/// <para>最大坡度—沿线或面定义的区域中的最高坡度值。</para>
			/// </summary>
			[GPValue("MAX_SLOPE")]
			[Description("最大坡度")]
			Maximum_Slope,

			/// <summary>
			/// <para>平均坡度—沿线或面定义的区域中的平均坡度值。</para>
			/// </summary>
			[GPValue("AVG_SLOPE")]
			[Description("平均坡度")]
			Average_Slope,

		}

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>线性— TIN、terrain 和 LAS 数据集的默认插值方法。根据由包含查询点 XY 位置的三角形定义的平面获取高程。</para>
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
			/// <para>合并最小 Z 值— 根据在查询点自然邻域中找到的最小 Z 值获取高程。</para>
			/// </summary>
			[GPValue("CONFLATE_ZMIN")]
			[Description("合并最小 Z 值")]
			Conflate_Minimum_Z,

			/// <summary>
			/// <para>合并最大 Z 值— 根据在查询点自然邻域中找到的最大 Z 值获取高程。</para>
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
			/// <para>合并最接近平均值的 z 值— 根据距查询点所有自然邻域的平均值最近的 Z 值获取高程。</para>
			/// </summary>
			[GPValue("CONFLATE_CLOSEST_TO_MEAN")]
			[Description("合并最接近平均值的 z 值")]
			Conflate_Z_Closest_To_Mean,

			/// <summary>
			/// <para>双线性法—可从四个最邻近的像元中确定像元值的栅格表面的专用插值方法。这是适用于栅格表面的唯一选项。</para>
			/// </summary>
			[GPValue("BILINEAR")]
			[Description("双线性法")]
			Bilinear,

		}

#endregion
	}
}
