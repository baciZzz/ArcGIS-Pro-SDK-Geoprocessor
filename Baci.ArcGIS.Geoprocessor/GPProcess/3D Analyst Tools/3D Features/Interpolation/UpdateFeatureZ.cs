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
	/// <para>Update Feature Z</para>
	/// <para>更新要素 Z 值</para>
	/// <para>使用表面来更新 3D 要素折点的 z 坐标。</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class UpdateFeatureZ : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>折点 z 值将被修改的 3D 要素。</para>
		/// </param>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>将用于确定 3D 要素折点新 z 值的表面。</para>
		/// </param>
		public UpdateFeatureZ(object InFeatures, object InSurface)
		{
			this.InFeatures = InFeatures;
			this.InSurface = InSurface;
		}

		/// <summary>
		/// <para>Tool Display Name : 更新要素 Z 值</para>
		/// </summary>
		public override string DisplayName() => "更新要素 Z 值";

		/// <summary>
		/// <para>Tool Name : UpdateFeatureZ</para>
		/// </summary>
		public override string ToolName() => "UpdateFeatureZ";

		/// <summary>
		/// <para>Tool Excute Name : 3d.UpdateFeatureZ</para>
		/// </summary>
		public override string ExcuteName() => "3d.UpdateFeatureZ";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, InSurface, Method, StatusField, OutFeatureClass };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>折点 z 值将被修改的 3D 要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polyline", "Polygon")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>将用于确定 3D 要素折点新 z 值的表面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Interpolation Method</para>
		/// <para>用于确定表面相关信息的插值方法。可用选项取决于输入表面的数据类型：</para>
		/// <para>双线性—可从四个最邻近的像元中确定像元值的栅格表面的专用插值方法。这是适用于栅格表面的唯一选项。</para>
		/// <para>线性— TIN、terrain 和 LAS 数据集的默认插值方法。根据由包含查询点 XY 位置的三角形定义的平面获取高程。</para>
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
		/// <para>Status Field</para>
		/// <para>将使用值进行填充的现有数值字段，可反映要素的折点是否已成功更新。已更新要素的值会被指定为 1，而未更新要素的值会被指定为 0。不会更新与表面部分重叠的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long")]
		public object StatusField { get; set; }

		/// <summary>
		/// <para>Updated Input Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public UpdateFeatureZ SetEnviroment(object extent = null, object workspace = null)
		{
			base.SetEnv(extent: extent, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Interpolation Method</para>
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
			/// <para>双线性—可从四个最邻近的像元中确定像元值的栅格表面的专用插值方法。这是适用于栅格表面的唯一选项。</para>
			/// </summary>
			[GPValue("BILINEAR")]
			[Description("双线性")]
			Bilinear,

		}

#endregion
	}
}
