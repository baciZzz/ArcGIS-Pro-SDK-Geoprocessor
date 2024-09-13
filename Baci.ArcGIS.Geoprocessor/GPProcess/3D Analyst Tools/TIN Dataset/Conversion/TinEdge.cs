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
	/// <para>TIN Edge</para>
	/// <para>TIN 边</para>
	/// <para>使用不规则三角网 (TIN) 数据集的三角形边创建 3D 线要素。</para>
	/// </summary>
	public class TinEdge : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTin">
		/// <para>Input TIN</para>
		/// <para>待处理的 TIN 数据集。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </param>
		public TinEdge(object InTin, object OutFeatureClass)
		{
			this.InTin = InTin;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : TIN 边</para>
		/// </summary>
		public override string DisplayName() => "TIN 边";

		/// <summary>
		/// <para>Tool Name : TinEdge</para>
		/// </summary>
		public override string ToolName() => "TinEdge";

		/// <summary>
		/// <para>Tool Excute Name : 3d.TinEdge</para>
		/// </summary>
		public override string ExcuteName() => "3d.TinEdge";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTin, OutFeatureClass, EdgeType };

		/// <summary>
		/// <para>Input TIN</para>
		/// <para>待处理的 TIN 数据集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InTin { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Edge Type</para>
		/// <para>将被导出的三角形边。</para>
		/// <para>数据区—表示插值区的边。这是默认设置。</para>
		/// <para>软隔断线—表示坡度平缓中断的边。</para>
		/// <para>硬隔断线—表示坡度明显中断的边。</para>
		/// <para>强化的边—不是由 TIN 三角测量引入的边。</para>
		/// <para>规则边—由 TIN 三角测量创建的边。</para>
		/// <para>排除的边—从插值区被排除的边。</para>
		/// <para>所有边—所有边，包括那些从插值区被排除的边。</para>
		/// <para><see cref="EdgeTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object EdgeType { get; set; } = "DATA";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TinEdge SetEnviroment(object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Edge Type</para>
		/// </summary>
		public enum EdgeTypeEnum 
		{
			/// <summary>
			/// <para>数据区—表示插值区的边。这是默认设置。</para>
			/// </summary>
			[GPValue("DATA")]
			[Description("数据区")]
			Data_Area,

			/// <summary>
			/// <para>软隔断线—表示坡度平缓中断的边。</para>
			/// </summary>
			[GPValue("SOFT")]
			[Description("软隔断线")]
			Soft_Breaklines,

			/// <summary>
			/// <para>硬隔断线—表示坡度明显中断的边。</para>
			/// </summary>
			[GPValue("HARD")]
			[Description("硬隔断线")]
			Hard_Breaklines,

			/// <summary>
			/// <para>强化的边—不是由 TIN 三角测量引入的边。</para>
			/// </summary>
			[GPValue("ENFORCED")]
			[Description("强化的边")]
			Enforced_Edges,

			/// <summary>
			/// <para>规则边—由 TIN 三角测量创建的边。</para>
			/// </summary>
			[GPValue("REGULAR")]
			[Description("规则边")]
			Regular_Edges,

			/// <summary>
			/// <para>排除的边—从插值区被排除的边。</para>
			/// </summary>
			[GPValue("OUTSIDE")]
			[Description("排除的边")]
			Excluded_Edges,

			/// <summary>
			/// <para>所有边—所有边，包括那些从插值区被排除的边。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("所有边")]
			All_Edges,

		}

#endregion
	}
}
