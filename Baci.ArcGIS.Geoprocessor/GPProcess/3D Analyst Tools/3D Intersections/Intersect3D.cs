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
	/// <para>Intersect 3D</para>
	/// <para>3D 相交</para>
	/// <para>计算多面体要素的交集，以便生成包含重叠体积的闭合多面体，根据公共表面积生成非闭合多面体要素，或根据相交边生成线要素。</para>
	/// </summary>
	public class Intersect3D : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureClass1">
		/// <para>Input Multipatch Features</para>
		/// <para>要相交的多面体属性。当只提供一个输入要素图层或要素类时，输出将表示其自身要素的交集。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </param>
		public Intersect3D(object InFeatureClass1, object OutFeatureClass)
		{
			this.InFeatureClass1 = InFeatureClass1;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 3D 相交</para>
		/// </summary>
		public override string DisplayName() => "3D 相交";

		/// <summary>
		/// <para>Tool Name : Intersect3D</para>
		/// </summary>
		public override string ToolName() => "Intersect3D";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Intersect3D</para>
		/// </summary>
		public override string ExcuteName() => "3d.Intersect3D";

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
		public override object[] Parameters() => new object[] { InFeatureClass1, OutFeatureClass, InFeatureClass2, OutputGeometryType };

		/// <summary>
		/// <para>Input Multipatch Features</para>
		/// <para>要相交的多面体属性。当只提供一个输入要素图层或要素类时，输出将表示其自身要素的交集。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object InFeatureClass1 { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Input Multipatch Features</para>
		/// <para>与第一个多面体要素图层或要素类相交的第二个多面体要素图层或要素类（可选）。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object InFeatureClass2 { get; set; }

		/// <summary>
		/// <para>Output Geometry Type</para>
		/// <para>确定创建的相交几何的类型。</para>
		/// <para>实线—创建表示输入要素之间重叠体积的闭合多面体。这是默认设置。</para>
		/// <para>表面分析—创建表示输入要素之间共享面的多面体表面。</para>
		/// <para>折线— 创建表示输入要素之间共享边的线。</para>
		/// <para><see cref="OutputGeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutputGeometryType { get; set; } = "SOLID";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Intersect3D SetEnviroment(object XYDomain = null, object ZDomain = null, int? autoCommit = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, ZDomain: ZDomain, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Geometry Type</para>
		/// </summary>
		public enum OutputGeometryTypeEnum 
		{
			/// <summary>
			/// <para>实线—创建表示输入要素之间重叠体积的闭合多面体。这是默认设置。</para>
			/// </summary>
			[GPValue("SOLID")]
			[Description("实线")]
			Solid,

			/// <summary>
			/// <para>表面分析—创建表示输入要素之间共享面的多面体表面。</para>
			/// </summary>
			[GPValue("SURFACE")]
			[Description("表面分析")]
			Surface,

			/// <summary>
			/// <para>折线— 创建表示输入要素之间共享边的线。</para>
			/// </summary>
			[GPValue("LINE")]
			[Description("折线")]
			Line,

		}

#endregion
	}
}
