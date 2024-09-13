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
	/// <para>Intersect 3D Line With Surface</para>
	/// <para>3D 线与表面相交</para>
	/// <para>计算 3D 线要素与一个或多个表面的几何交集，并以分割线要素和点的形式返回交集。</para>
	/// </summary>
	public class Intersect3DLineWithSurface : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLineFeatures">
		/// <para>Input Line Features</para>
		/// <para>输入 3D 线要素。</para>
		/// </param>
		/// <param name="InSurfaces">
		/// <para>Input Surfaces</para>
		/// <para>将用于确定交点的一个或多个表面。</para>
		/// </param>
		/// <param name="OutLineFeatureClass">
		/// <para>Output Lines</para>
		/// <para>表示输入线要素在与表面的交点处分割的输出线要素。</para>
		/// </param>
		public Intersect3DLineWithSurface(object InLineFeatures, object InSurfaces, object OutLineFeatureClass)
		{
			this.InLineFeatures = InLineFeatures;
			this.InSurfaces = InSurfaces;
			this.OutLineFeatureClass = OutLineFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : 3D 线与表面相交</para>
		/// </summary>
		public override string DisplayName() => "3D 线与表面相交";

		/// <summary>
		/// <para>Tool Name : Intersect3DLineWithSurface</para>
		/// </summary>
		public override string ToolName() => "Intersect3DLineWithSurface";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Intersect3DLineWithSurface</para>
		/// </summary>
		public override string ExcuteName() => "3d.Intersect3DLineWithSurface";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "autoCommit", "configKeyword", "extent", "geographicTransformations", "outputCoordinateSystem", "terrainMemoryUsage", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InLineFeatures, InSurfaces, OutLineFeatureClass, OutPointFeatureClass };

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>输入 3D 线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InLineFeatures { get; set; }

		/// <summary>
		/// <para>Input Surfaces</para>
		/// <para>将用于确定交点的一个或多个表面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InSurfaces { get; set; }

		/// <summary>
		/// <para>Output Lines</para>
		/// <para>表示输入线要素在与表面的交点处分割的输出线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutLineFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Points</para>
		/// <para>表示输入线与表面的交点的可选点要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Intersect3DLineWithSurface SetEnviroment(object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , int? autoCommit = null , object configKeyword = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object terrainMemoryUsage = null , object workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, terrainMemoryUsage: terrainMemoryUsage, workspace: workspace);
			return this;
		}

	}
}
