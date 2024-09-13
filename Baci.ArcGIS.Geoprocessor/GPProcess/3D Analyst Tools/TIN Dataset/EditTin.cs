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
	/// <para>Edit TIN</para>
	/// <para>编辑 TIN</para>
	/// <para>从一个或多个输入要素中加载数据以修改现有不规则三角网 (TIN) 的表面。</para>
	/// </summary>
	public class EditTin : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTin">
		/// <para>Input TIN</para>
		/// <para>待处理的 TIN 数据集。</para>
		/// </param>
		/// <param name="InFeatures">
		/// <para>Input Feature Class</para>
		/// <para>将构成 TIN 定义的输入要素及其相关属性。</para>
		/// <para>输入要素 - 所包含的几何将要导入至 TIN 的要素。</para>
		/// <para>高度字段 - 输入要素的高程源。 可以使用输入要素属性表中的任何数值字段以及存储于 Shape 字段中的 Z 或 M 值。 选择 &lt;None&gt; 关键字将导致要素的高程通过周围表面进行插值处理。</para>
		/// <para>标签字段 - 将使用从输入要素属性表的整型字段中获得的值分配给 TIN 的数据元素的数值属性。</para>
		/// <para>类型 - 将定义 TIN 表面修整中要素的角色。 有关表面要素类型的详细信息，请参阅工具的使用提示。</para>
		/// <para>使用 Z - 指示将 SHAPE 字段表示为高度源时是否使用 Z 或 M 值。 将此选项设为 True 表示将使用 Z 值，而将其设为 False 将导致使用 M 值。</para>
		/// </param>
		public EditTin(object InTin, object InFeatures)
		{
			this.InTin = InTin;
			this.InFeatures = InFeatures;
		}

		/// <summary>
		/// <para>Tool Display Name : 编辑 TIN</para>
		/// </summary>
		public override string DisplayName() => "编辑 TIN";

		/// <summary>
		/// <para>Tool Name : EditTin</para>
		/// </summary>
		public override string ToolName() => "EditTin";

		/// <summary>
		/// <para>Tool Excute Name : 3d.EditTin</para>
		/// </summary>
		public override string ExcuteName() => "3d.EditTin";

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
		public override object[] Parameters() => new object[] { InTin, InFeatures, ConstrainedDelaunay!, DerivedOutTin! };

		/// <summary>
		/// <para>Input TIN</para>
		/// <para>待处理的 TIN 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InTin { get; set; }

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>将构成 TIN 定义的输入要素及其相关属性。</para>
		/// <para>输入要素 - 所包含的几何将要导入至 TIN 的要素。</para>
		/// <para>高度字段 - 输入要素的高程源。 可以使用输入要素属性表中的任何数值字段以及存储于 Shape 字段中的 Z 或 M 值。 选择 &lt;None&gt; 关键字将导致要素的高程通过周围表面进行插值处理。</para>
		/// <para>标签字段 - 将使用从输入要素属性表的整型字段中获得的值分配给 TIN 的数据元素的数值属性。</para>
		/// <para>类型 - 将定义 TIN 表面修整中要素的角色。 有关表面要素类型的详细信息，请参阅工具的使用提示。</para>
		/// <para>使用 Z - 指示将 SHAPE 字段表示为高度源时是否使用 Z 或 M 值。 将此选项设为 True 表示将使用 Z 值，而将其设为 False 将导致使用 M 值。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
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
		public object? ConstrainedDelaunay { get; set; } = "false";

		/// <summary>
		/// <para>Updated TIN</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTinLayer()]
		public object? DerivedOutTin { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public EditTin SetEnviroment(object? extent = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, workspace: workspace);
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
