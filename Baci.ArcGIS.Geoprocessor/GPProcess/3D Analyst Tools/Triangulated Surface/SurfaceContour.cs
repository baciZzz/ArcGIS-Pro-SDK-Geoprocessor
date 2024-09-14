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
	/// <para>Surface Contour</para>
	/// <para>表面等值线</para>
	/// <para>创建派生自 terrain、TIN 或 LAS 数据集表面的等值线。</para>
	/// </summary>
	public class SurfaceContour : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>待处理的 TIN、terrain 或 LAS 数据集表面。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </param>
		/// <param name="Interval">
		/// <para>Contour Interval</para>
		/// <para>等值线间的间距。</para>
		/// </param>
		public SurfaceContour(object InSurface, object OutFeatureClass, object Interval)
		{
			this.InSurface = InSurface;
			this.OutFeatureClass = OutFeatureClass;
			this.Interval = Interval;
		}

		/// <summary>
		/// <para>Tool Display Name : 表面等值线</para>
		/// </summary>
		public override string DisplayName() => "表面等值线";

		/// <summary>
		/// <para>Tool Name : SurfaceContour</para>
		/// </summary>
		public override string ToolName() => "SurfaceContour";

		/// <summary>
		/// <para>Tool Excute Name : 3d.SurfaceContour</para>
		/// </summary>
		public override string ExcuteName() => "3d.SurfaceContour";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "terrainMemoryUsage", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSurface, OutFeatureClass, Interval, BaseContour, ContourField, ContourFieldPrecision, IndexInterval, IndexIntervalField, ZFactor, PyramidLevelResolution };

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>待处理的 TIN、terrain 或 LAS 数据集表面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>将生成的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Contour Interval</para>
		/// <para>等值线间的间距。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object Interval { get; set; }

		/// <summary>
		/// <para>Base Contour</para>
		/// <para>定义要加上或减去等值线间距以描绘等值线的起始 z 值。默认值为 0.0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object BaseContour { get; set; } = "0";

		/// <summary>
		/// <para>Contour Field</para>
		/// <para>将与每条线均关联的等值线值存储在输出要素类中的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object ContourField { get; set; } = "Contour";

		/// <summary>
		/// <para>Contour Field Precision</para>
		/// <para>等值线字段的精度。零将指定一个整数，数字 1-9 则指示字段将包含的小数位数。默认情况下，字段将为整数 (0)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object ContourFieldPrecision { get; set; } = "0";

		/// <summary>
		/// <para>Index Interval</para>
		/// <para>计曲线通常用于制图帮助以协助实现等值线可视化。计曲线间距的值通常比等值线间距的值大五倍。使用该参数会将计曲线间距字段定义的整型字段添加到输出要素类的属性表中，其中值 1 指示计曲线。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object IndexInterval { get; set; }

		/// <summary>
		/// <para>Index Interval Field</para>
		/// <para>字段名称用于标识计曲线。该参数仅能在定义了计曲线间距后使用。默认情况下，字段名称是 Index。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object IndexIntervalField { get; set; } = "Index_Cont";

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>Z 值将乘上的系数。 此值通常用于转换 z 线性单位来匹配 x,y 线性单位。 默认值为 1，此时高程值保持不变。 如果输入表面的空间参考具有已指定线性单位的 z 基准，则此参数不可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Pyramid Level Resolution</para>
		/// <para>将使用 terrain 金字塔等级的 z 容差或窗口大小分辨率。 默认值为 0，或全分辨率。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object PyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SurfaceContour SetEnviroment(object XYDomain = null, object XYResolution = null, object XYTolerance = null, int? autoCommit = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object terrainMemoryUsage = null, object workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, terrainMemoryUsage: terrainMemoryUsage, workspace: workspace);
			return this;
		}

	}
}
