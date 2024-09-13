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
	/// <para>Surface Aspect</para>
	/// <para>表面坡向</para>
	/// <para>创建表示派生自 TIN、terrain 或 LAS 数据集表面的坡向测量值的面要素。</para>
	/// </summary>
	public class SurfaceAspect : AbstractGPProcess
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
		public SurfaceAspect(object InSurface, object OutFeatureClass)
		{
			this.InSurface = InSurface;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 表面坡向</para>
		/// </summary>
		public override string DisplayName() => "表面坡向";

		/// <summary>
		/// <para>Tool Name : SurfaceAspect</para>
		/// </summary>
		public override string ToolName() => "SurfaceAspect";

		/// <summary>
		/// <para>Tool Excute Name : 3d.SurfaceAspect</para>
		/// </summary>
		public override string ExcuteName() => "3d.SurfaceAspect";

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
		public override object[] Parameters() => new object[] { InSurface, OutFeatureClass, ClassBreaksTable!, AspectField!, PyramidLevelResolution! };

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
		/// <para>Class Breaks Table</para>
		/// <para>包含将用于对输出要素类中的坡向范围进行定义的分类间隔的表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DETable()]
		public object? ClassBreaksTable { get; set; }

		/// <summary>
		/// <para>Aspect Field</para>
		/// <para>包含坡向编码值的字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? AspectField { get; set; } = "AspectCode";

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
		public SurfaceAspect SetEnviroment(object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , bool? terrainMemoryUsage = null , object? workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, terrainMemoryUsage: terrainMemoryUsage, workspace: workspace);
			return this;
		}

	}
}
