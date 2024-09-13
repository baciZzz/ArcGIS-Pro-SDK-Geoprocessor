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
	/// <para>Create TIN</para>
	/// <para>创建 TIN</para>
	/// <para>创建一个不规则三角网 (TIN) 数据集。</para>
	/// </summary>
	public class CreateTin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="OutTin">
		/// <para>Output TIN</para>
		/// <para>将要生成的 TIN 数据集。</para>
		/// </param>
		public CreateTin(object OutTin)
		{
			this.OutTin = OutTin;
		}

		/// <summary>
		/// <para>Tool Display Name : 创建 TIN</para>
		/// </summary>
		public override string DisplayName() => "创建 TIN";

		/// <summary>
		/// <para>Tool Name : CreateTin</para>
		/// </summary>
		public override string ToolName() => "CreateTin";

		/// <summary>
		/// <para>Tool Excute Name : 3d.CreateTin</para>
		/// </summary>
		public override string ExcuteName() => "3d.CreateTin";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "tinSaveVersion", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { OutTin, SpatialReference, InFeatures, ConstrainedDelaunay };

		/// <summary>
		/// <para>Output TIN</para>
		/// <para>将要生成的 TIN 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETin()]
		public object OutTin { get; set; }

		/// <summary>
		/// <para>Coordinate System</para>
		/// <para>应将输出 TIN 的空间参考设为投影坐标系。不建议使用地理坐标系，因为当以角度单位表示 XY 坐标时无法确保 Delaunay 三角测量，这可能会对基于距离的计算（如坡度、体积和视线）的准确性产生负面影响。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPCoordinateSystem()]
		public object SpatialReference { get; set; }

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>将构成 TIN 定义的输入要素及其相关属性。</para>
		/// <para>输入要素 - 所包含的几何将要导入至 TIN 的要素。</para>
		/// <para>高度字段 - 输入要素的高程源。可以使用输入要素属性表中的任何数值字段以及 Shape.Z（用于 3D 要素的 Z 值）和 Shape.M（用于存储于几何中的 M 值）。选择 &lt;None&gt; 关键字将导致要素的高程通过周围表面进行插值处理。</para>
		/// <para>类型 - 将定义 TIN 表面修整中要素的角色。 有关表面要素类型的详细信息，请参阅工具的使用提示。</para>
		/// <para>标签字段 - 将使用从输入要素属性表的整型字段中获得的值分配给 TIN 的数据元素的数值属性。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		[GPCompositeDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Constrained Delaunay</para>
		/// <para>指定将与 TIN 隔断线一同使用的三角测量技术。</para>
		/// <para>未选中 - TIN 将使用符合 Delaunay 的三角测量，这可能会增密每条隔断线线段以生成多条三角形边。 这是默认设置。</para>
		/// <para>选中 - TIN 将使用约束型 Delaunay 三角测量，这会将各线段作为单独的边添加。 所有位置均支持 Delaunay 三角测量规则，但沿隔断线处除外，因为它无法增密。</para>
		/// <para><see cref="ConstrainedDelaunayEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ConstrainedDelaunay { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public CreateTin SetEnviroment(object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object tinSaveVersion = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, tinSaveVersion: tinSaveVersion, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Constrained Delaunay</para>
		/// </summary>
		public enum ConstrainedDelaunayEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CONSTRAINED_DELAUNAY")]
			CONSTRAINED_DELAUNAY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("DELAUNAY")]
			DELAUNAY,

		}

#endregion
	}
}
