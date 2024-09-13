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
	/// <para>Interpolate Polygon To Multipatch</para>
	/// <para>Creates surface-conforming  multipatch features by draping polygon features over a surface.</para>
	/// </summary>
	public class InterpolatePolyToPatch : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>The input triangulated irregular network (TIN) or terrain dataset surface.</para>
		/// </param>
		/// <param name="InFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>The input polygon feature.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output multipatch feature class.</para>
		/// </param>
		public InterpolatePolyToPatch(object InSurface, object InFeatureClass, object OutFeatureClass)
		{
			this.InSurface = InSurface;
			this.InFeatureClass = InFeatureClass;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Interpolate Polygon To Multipatch</para>
		/// </summary>
		public override string DisplayName() => "Interpolate Polygon To Multipatch";

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
		/// <para>The input triangulated irregular network (TIN) or terrain dataset surface.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>The input polygon feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output multipatch feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Maximum Strip Size</para>
		/// <para>Controls the maximum number of points used to create an individual triangle strip. Note that each multipatch is usually composed of multiple strips. The default value is 1,024.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLong()]
		public object? MaxStripSize { get; set; } = "1024";

		/// <summary>
		/// <para>Z Factor</para>
		/// <para>The factor by which z-values will be multiplied. This is typically used to convert z linear units to match x,y linear units. The default is 1, which leaves elevation values unchanged. This parameter is not available if the spatial reference of the input surface has a z datum with a specified linear unit.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? ZFactor { get; set; } = "1";

		/// <summary>
		/// <para>Area Field</para>
		/// <para>The name of the output field containing the planimetric, or 2D, area of the resulting multipatches.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? AreaField { get; set; } = "Area";

		/// <summary>
		/// <para>Surface Area Field</para>
		/// <para>The name of the output field containing the 3D area of the resulting multipatches. This area takes the surface undulations into consideration and is always larger than the planimetric area unless the surface is flat, in which case, the two are equal.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? SurfaceAreaField { get; set; } = "SArea";

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
		public InterpolatePolyToPatch SetEnviroment(object? XYDomain = null , object? XYResolution = null , object? ZDomain = null , object? ZResolution = null , int? autoCommit = null , object? configKeyword = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, ZDomain: ZDomain, ZResolution: ZResolution, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

	}
}
