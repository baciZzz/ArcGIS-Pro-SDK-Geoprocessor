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
	/// <para>TIN Domain</para>
	/// <para>TIN 范围</para>
	/// <para>可创建表示不规则三角网 (TIN) 数据集插值区的线或面要素类。</para>
	/// </summary>
	public class TinDomain : AbstractGPProcess
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
		/// <param name="OutGeometryType">
		/// <para>Output Feature Class Type</para>
		/// <para>输出要素类的几何。</para>
		/// <para>线段式—输出将是启用了 z 值的线要素类。</para>
		/// <para>面—输出将是启用了 z 值的面要素类。</para>
		/// <para><see cref="OutGeometryTypeEnum"/></para>
		/// </param>
		public TinDomain(object InTin, object OutFeatureClass, object OutGeometryType)
		{
			this.InTin = InTin;
			this.OutFeatureClass = OutFeatureClass;
			this.OutGeometryType = OutGeometryType;
		}

		/// <summary>
		/// <para>Tool Display Name : TIN 范围</para>
		/// </summary>
		public override string DisplayName() => "TIN 范围";

		/// <summary>
		/// <para>Tool Name : TinDomain</para>
		/// </summary>
		public override string ToolName() => "TinDomain";

		/// <summary>
		/// <para>Tool Excute Name : 3d.TinDomain</para>
		/// </summary>
		public override string ExcuteName() => "3d.TinDomain";

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
		public override object[] Parameters() => new object[] { InTin, OutFeatureClass, OutGeometryType };

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
		/// <para>Output Feature Class Type</para>
		/// <para>输出要素类的几何。</para>
		/// <para>线段式—输出将是启用了 z 值的线要素类。</para>
		/// <para>面—输出将是启用了 z 值的面要素类。</para>
		/// <para><see cref="OutGeometryTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OutGeometryType { get; set; } = "LINE";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TinDomain SetEnviroment(object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, int? autoCommit = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Output Feature Class Type</para>
		/// </summary>
		public enum OutGeometryTypeEnum 
		{
			/// <summary>
			/// <para>线段式—输出将是启用了 z 值的线要素类。</para>
			/// </summary>
			[GPValue("LINE")]
			[Description("线段式")]
			Line,

			/// <summary>
			/// <para>面—输出将是启用了 z 值的面要素类。</para>
			/// </summary>
			[GPValue("POLYGON")]
			[Description("面")]
			Polygon,

		}

#endregion
	}
}
