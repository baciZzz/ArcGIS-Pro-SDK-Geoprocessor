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
	/// <para>Interpolate Polygon To Multipatch</para>
	/// <para>面插值为多面体</para>
	/// <para>通过在表面上叠加面要素来创建与表面一致的多面体要素。</para>
	/// </summary>
	public class InterpolatePolyToPatch : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>输入不规则三角网 (TIN) 或 terrain 数据集表面。</para>
		/// </param>
		/// <param name="InFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>输入面要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>输出多面体要素类。</para>
		/// </param>
		public InterpolatePolyToPatch(object InSurface, object InFeatureClass, object OutFeatureClass)
		{
			this.InSurface = InSurface;
			this.InFeatureClass = InFeatureClass;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 面插值为多面体</para>
		/// </summary>
		public override string DisplayName() => "面插值为多面体";

		/// <summary>
		/// <para>Tool Name : InterpolatePolyToPatch</para>
		/// </summary>
		public override string ToolName() => "InterpolatePolyToPatch";

		/// <summary>
		/// <para>Tool Excute Name : 3d.InterpolatePolyToPatch</para>
		/// </summary>
		public override string ExcuteName() => "3d.InterpolatePolyToPatch";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "ZDomain", "ZResolution", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSurface, InFeatureClass, OutFeatureClass, MaxStripSize!, ZFactor!, AreaField!, SurfaceAreaField!, PyramidLevelResolution! };

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>输入不规则三角网 (TIN) 或 terrain 数据集表面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>输入面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>输出多面体要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Maximum Strip Size</para>
		/// <para>控制用于创建单个三角条带的最大点数。请注意，每个多面体通常由多个条带组成。默认值为 1,024。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MaxStripSize { get; set; } = "1024";

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>Z 值将乘上的系数。 此值通常用于转换 z 线性单位来匹配 x,y 线性单位。 默认值为 1，此时高程值保持不变。 如果输入表面的空间参考具有已指定线性单位的 z 基准，则此参数不可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Area Field</para>
		/// <para>输出字段的名称，其中包含所得多面体的平面（或 2D）面积。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? AreaField { get; set; } = "Area";

		/// <summary>
		/// <para>Surface Area Field</para>
		/// <para>输出字段的名称，其中包含所得多面体的 3D 面积。该面积考虑到了表面的波动。如果表面是平的，则该面积与平面面积两者相等，否则它总是大于平面面积。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? SurfaceAreaField { get; set; } = "SArea";

		/// <summary>
		/// <para>Pyramid Level Resolution</para>
		/// <para>将使用 terrain 金字塔等级的 z 容差或窗口大小分辨率。 默认值为 0，或全分辨率。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? PyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public InterpolatePolyToPatch SetEnviroment(object? XYDomain = null , object? XYResolution = null , object? ZDomain = null , object? ZResolution = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, ZDomain: ZDomain, ZResolution: ZResolution, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

	}
}
