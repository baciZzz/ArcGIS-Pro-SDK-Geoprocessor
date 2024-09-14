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
	/// <para>Delineate TIN Data Area</para>
	/// <para>描绘 TIN 数据区</para>
	/// <para>基于三角形的边长度重新定义不规则三角网 (TIN) 的数据区或内插区。</para>
	/// </summary>
	public class DelineateTinDataArea : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTin">
		/// <para>Input TIN</para>
		/// <para>待处理的 TIN 数据集。</para>
		/// </param>
		/// <param name="MaxEdgeLength">
		/// <para>Maximum Edge Length</para>
		/// <para>用于在 TIN 数据区中定义 TIN 三角形边的最大长度的二维距离。如果三角形的一个或多个边大于此值，则会将其视为处于 TIN 插值区之外，并且不会在地图中进行渲染或用于表面分析。</para>
		/// </param>
		public DelineateTinDataArea(object InTin, object MaxEdgeLength)
		{
			this.InTin = InTin;
			this.MaxEdgeLength = MaxEdgeLength;
		}

		/// <summary>
		/// <para>Tool Display Name : 描绘 TIN 数据区</para>
		/// </summary>
		public override string DisplayName() => "描绘 TIN 数据区";

		/// <summary>
		/// <para>Tool Name : DelineateTinDataArea</para>
		/// </summary>
		public override string ToolName() => "DelineateTinDataArea";

		/// <summary>
		/// <para>Tool Excute Name : 3d.DelineateTinDataArea</para>
		/// </summary>
		public override string ExcuteName() => "3d.DelineateTinDataArea";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTin, MaxEdgeLength, Method!, DerivedOutTin! };

		/// <summary>
		/// <para>Input TIN</para>
		/// <para>待处理的 TIN 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InTin { get; set; }

		/// <summary>
		/// <para>Maximum Edge Length</para>
		/// <para>用于在 TIN 数据区中定义 TIN 三角形边的最大长度的二维距离。如果三角形的一个或多个边大于此值，则会将其视为处于 TIN 插值区之外，并且不会在地图中进行渲染或用于表面分析。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object MaxEdgeLength { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>描绘 TIN 数据区时将对 TIN 边进行求值。</para>
		/// <para>周边边—从 TIN 的外部范围向内遍历各个三角形，如果边界三角形的边在当前迭代中小于最大边长，则将停止遍历。这是默认设置。</para>
		/// <para>所有边—按边长对整个 TIN 三角形集合进行分类。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "PERIMETER_ONLY";

		/// <summary>
		/// <para>Updated TIN</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPTinLayer()]
		public object? DerivedOutTin { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public DelineateTinDataArea SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>周边边—从 TIN 的外部范围向内遍历各个三角形，如果边界三角形的边在当前迭代中小于最大边长，则将停止遍历。这是默认设置。</para>
			/// </summary>
			[GPValue("PERIMETER_ONLY")]
			[Description("周边边")]
			Perimeter_Edges,

			/// <summary>
			/// <para>所有边—按边长对整个 TIN 三角形集合进行分类。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有边")]
			All_Edges,

		}

#endregion
	}
}
