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
	/// <para>Surface Contour</para>
	/// <para>Creates contour lines derived from a terrain, TIN, or LAS dataset surface.</para>
	/// </summary>
	public class SurfaceContour : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>The TIN, terrain, or LAS dataset surface to process.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </param>
		/// <param name="Interval">
		/// <para>Contour Interval</para>
		/// <para>The interval between the contours.</para>
		/// </param>
		public SurfaceContour(object InSurface, object OutFeatureClass, object Interval)
		{
			this.InSurface = InSurface;
			this.OutFeatureClass = OutFeatureClass;
			this.Interval = Interval;
		}

		/// <summary>
		/// <para>Tool Display Name : Surface Contour</para>
		/// </summary>
		public override string DisplayName() => "Surface Contour";

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
		public override object[] Parameters() => new object[] { InSurface, OutFeatureClass, Interval, BaseContour!, ContourField!, ContourFieldPrecision!, IndexInterval!, IndexIntervalField!, ZFactor!, PyramidLevelResolution! };

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>The TIN, terrain, or LAS dataset surface to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The feature class that will be produced.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Contour Interval</para>
		/// <para>The interval between the contours.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDouble()]
		public object Interval { get; set; }

		/// <summary>
		/// <para>Base Contour</para>
		/// <para>Defines the starting Z value from which the contour interval is either added or subtracted to delineate contours. The default value is 0.0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? BaseContour { get; set; } = "0";

		/// <summary>
		/// <para>Contour Field</para>
		/// <para>The field that stores the contour value associated with each line in the output feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ContourField { get; set; } = "Contour";

		/// <summary>
		/// <para>Contour Field Precision</para>
		/// <para>The precision of the contour field. Zero specifies an integer, and the numbers 1–9 indicate how many decimal places the field will contain. By default, the field will be an integer (0).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? ContourFieldPrecision { get; set; } = "0";

		/// <summary>
		/// <para>Index Interval</para>
		/// <para>Index contours are commonly used as a cartographic aid for assisting in the visualization of contour lines. The index interval is typically five times larger than the contour interval. Use of this parameter adds an integer field defined by the Index Interval Field to the attribute table of the output feature class, where a value of 1 denotes the index contours.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? IndexInterval { get; set; }

		/// <summary>
		/// <para>Index Interval Field</para>
		/// <para>The name of the field used to identify index contours. This will only be used if the Index Interval is defined. By default, the field name is Index.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? IndexIntervalField { get; set; } = "Index_Cont";

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>The factor by which z-values will be multiplied. This is typically used to convert z linear units to match x,y linear units. The default is 1, which leaves elevation values unchanged. This parameter is not available if the spatial reference of the input surface has a z datum with a specified linear unit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Pyramid Level Resolution</para>
		/// <para>The z-tolerance or window-size resolution of the terrain pyramid level that will be used. The default is 0, or full resolution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? PyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SurfaceContour SetEnviroment(object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null, int? autoCommit = null, object? configKeyword = null, object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, bool? terrainMemoryUsage = null, object? workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, terrainMemoryUsage: terrainMemoryUsage, workspace: workspace);
			return this;
		}

	}
}
