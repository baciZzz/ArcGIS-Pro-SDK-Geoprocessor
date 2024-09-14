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
	/// <para>Extrude Between</para>
	/// <para>在两个 TIN 间拉伸</para>
	/// <para>通过在两个不规则三角网 (TIN) 数据集间拉伸各输入要素创建 3D 要素。</para>
	/// </summary>
	public class ExtrudeBetween : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTin1">
		/// <para>Input TIN</para>
		/// <para>第一个输入 TIN。</para>
		/// </param>
		/// <param name="InTin2">
		/// <para>Input TIN</para>
		/// <para>第二个输入 TIN。</para>
		/// </param>
		/// <param name="InFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>将在 TIN 之间拉伸的要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将存储拉伸后的要素输出。</para>
		/// </param>
		public ExtrudeBetween(object InTin1, object InTin2, object InFeatureClass, object OutFeatureClass)
		{
			this.InTin1 = InTin1;
			this.InTin2 = InTin2;
			this.InFeatureClass = InFeatureClass;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 在两个 TIN 间拉伸</para>
		/// </summary>
		public override string DisplayName() => "在两个 TIN 间拉伸";

		/// <summary>
		/// <para>Tool Name : ExtrudeBetween</para>
		/// </summary>
		public override string ToolName() => "ExtrudeBetween";

		/// <summary>
		/// <para>Tool Excute Name : 3d.ExtrudeBetween</para>
		/// </summary>
		public override string ExcuteName() => "3d.ExtrudeBetween";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTin1, InTin2, InFeatureClass, OutFeatureClass };

		/// <summary>
		/// <para>Input TIN</para>
		/// <para>第一个输入 TIN。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTin1 { get; set; }

		/// <summary>
		/// <para>Input TIN</para>
		/// <para>第二个输入 TIN。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTin2 { get; set; }

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>将在 TIN 之间拉伸的要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon", "Polyline")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将存储拉伸后的要素输出。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtrudeBetween SetEnviroment(object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, int? autoCommit = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

	}
}
