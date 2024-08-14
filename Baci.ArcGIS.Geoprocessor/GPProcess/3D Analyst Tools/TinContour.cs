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
	/// <para>TIN Contour</para>
	/// <para>Generates contours from a TIN surface.</para>
	/// </summary>
	[Obsolete()]
	public class TinContour : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTin">
		/// <para>Input TIN</para>
		/// <para>The surface from which the contours will be interpolated.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class.</para>
		/// </param>
		/// <param name="Interval">
		/// <para>Contour Interval</para>
		/// <para>The interval between the contours.</para>
		/// </param>
		public TinContour(object InTin, object OutFeatureClass, object Interval)
		{
			this.InTin = InTin;
			this.OutFeatureClass = OutFeatureClass;
			this.Interval = Interval;
		}

		/// <summary>
		/// <para>Tool Display Name : TIN Contour</para>
		/// </summary>
		public override string DisplayName => "TIN Contour";

		/// <summary>
		/// <para>Tool Name : TinContour</para>
		/// </summary>
		public override string ToolName => "TinContour";

		/// <summary>
		/// <para>Tool Excute Name : 3d.TinContour</para>
		/// </summary>
		public override string ExcuteName => "3d.TinContour";

		/// <summary>
		/// <para>Toolbox Display Name : 3D Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "3D Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : 3d</para>
		/// </summary>
		public override string ToolboxAlise => "3d";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "XYDomain", "XYResolution", "XYTolerance", "extent", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InTin, OutFeatureClass, Interval, BaseContour!, ContourField!, ContourFieldPrecision!, IndexInterval!, IndexIntervalField!, ZFactor! };

		/// <summary>
		/// <para>Input TIN</para>
		/// <para>The surface from which the contours will be interpolated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InTin { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class.</para>
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
		/// <para>Along with the index interval, the base height is used to determine what contours are produced. The base height is a starting point from which the index interval is either added or subtracted. By default, the base contour is 0.0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? BaseContour { get; set; }

		/// <summary>
		/// <para>Contour Field</para>
		/// <para>The field containing contour values.</para>
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
		/// <para>The difference, in Z units, between index contours. The value specified should be evenly divisible by the contour interval. Typically, it’s five times greater. Use of this parameter adds an attribute field to the output feature class that’s used to differentiate index contours from regular contours.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? IndexInterval { get; set; }

		/// <summary>
		/// <para>Index Interval Field</para>
		/// <para>The name of the field used to record whether a contour is a regular or an index contour. By default, the value is ‘Index’.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? IndexIntervalField { get; set; } = "Index_Cont";

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>Specifies a factor by which to multiply the surface heights. Used to convert z units to x and y units.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TinContour SetEnviroment(object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? extent = null , object? outputCoordinateSystem = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, extent: extent, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
