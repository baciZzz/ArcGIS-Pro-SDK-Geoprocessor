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
	/// <para>Intersect 3D Line With Surface</para>
	/// <para>Computes the geometric intersection of 3D line features and one or more surfaces to return the intersection as segmented line features and points.</para>
	/// </summary>
	public class Intersect3DLineWithSurface : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InLineFeatures">
		/// <para>Input Line Features</para>
		/// <para>The input 3D line features.</para>
		/// </param>
		/// <param name="InSurfaces">
		/// <para>Input Surfaces</para>
		/// <para>One or more surfaces that will be used to determine the points of intersection.</para>
		/// </param>
		/// <param name="OutLineFeatureClass">
		/// <para>Output Lines</para>
		/// <para>The output line features that represent the input line features split at the points of intersection with the surface.</para>
		/// </param>
		public Intersect3DLineWithSurface(object InLineFeatures, object InSurfaces, object OutLineFeatureClass)
		{
			this.InLineFeatures = InLineFeatures;
			this.InSurfaces = InSurfaces;
			this.OutLineFeatureClass = OutLineFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Intersect 3D Line With Surface</para>
		/// </summary>
		public override string DisplayName() => "Intersect 3D Line With Surface";

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
		public override object[] Parameters() => new object[] { InLineFeatures, InSurfaces, OutLineFeatureClass, OutPointFeatureClass! };

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>The input 3D line features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InLineFeatures { get; set; }

		/// <summary>
		/// <para>Input Surfaces</para>
		/// <para>One or more surfaces that will be used to determine the points of intersection.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InSurfaces { get; set; }

		/// <summary>
		/// <para>Output Lines</para>
		/// <para>The output line features that represent the input line features split at the points of intersection with the surface.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutLineFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Points</para>
		/// <para>The optional point features that represent the input line's intersection with a surface .</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object? OutPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Intersect3DLineWithSurface SetEnviroment(object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , bool? terrainMemoryUsage = null , object? workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, terrainMemoryUsage: terrainMemoryUsage, workspace: workspace);
			return this;
		}

	}
}
