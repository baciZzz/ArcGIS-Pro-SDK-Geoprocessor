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
	/// <para>TIN Node</para>
	/// <para>TIN 结点</para>
	/// <para>可将不规则三角网 (TIN) 数据集的结点导出到点要素类。</para>
	/// </summary>
	public class TinNode : AbstractGPProcess
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
		public TinNode(object InTin, object OutFeatureClass)
		{
			this.InTin = InTin;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : TIN 结点</para>
		/// </summary>
		public override string DisplayName() => "TIN 结点";

		/// <summary>
		/// <para>Tool Name : TinNode</para>
		/// </summary>
		public override string ToolName() => "TinNode";

		/// <summary>
		/// <para>Tool Excute Name : 3d.TinNode</para>
		/// </summary>
		public override string ExcuteName() => "3d.TinNode";

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
		public override object[] Parameters() => new object[] { InTin, OutFeatureClass, SpotField!, TagField! };

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
		/// <para>Spot Field</para>
		/// <para>输出要素类的高程属性字段的名称。如果指定名称，要素类将是 2D 的；否则，要素类将是 3D 的。默认情况下不提供名称，因此会创建 3D 点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? SpotField { get; set; }

		/// <summary>
		/// <para>Tag Value Field</para>
		/// <para>将标签属性存储在输出要素类中的字段的名称。默认情况下，不创建任何标签值字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? TagField { get; set; } = "Tag_Value";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TinNode SetEnviroment(object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

	}
}
