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
	/// <para>Polygon Volume</para>
	/// <para>Calculates the volume and surface area between a polygon of a constant height and a surface.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class PolygonVolume : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>The TIN, terrain, or LAS dataset surface to process.</para>
		/// </param>
		/// <param name="InFeatureClass">
		/// <para>Input Features</para>
		/// <para>The polygon features that define the region being processed.</para>
		/// </param>
		/// <param name="InHeightField">
		/// <para>Height Field</para>
		/// <para>The field in the polygon's attribute table that defines the height of the reference plane used in determining volumetric calculations.</para>
		/// </param>
		public PolygonVolume(object InSurface, object InFeatureClass, object InHeightField)
		{
			this.InSurface = InSurface;
			this.InFeatureClass = InFeatureClass;
			this.InHeightField = InHeightField;
		}

		/// <summary>
		/// <para>Tool Display Name : Polygon Volume</para>
		/// </summary>
		public override string DisplayName() => "Polygon Volume";

		/// <summary>
		/// <para>Tool Name : PolygonVolume</para>
		/// </summary>
		public override string ToolName() => "PolygonVolume";

		/// <summary>
		/// <para>Tool Excute Name : 3d.PolygonVolume</para>
		/// </summary>
		public override string ExcuteName() => "3d.PolygonVolume";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "terrainMemoryUsage", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InSurface, InFeatureClass, InHeightField, ReferencePlane, OutVolumeField, SurfaceAreaField, PyramidLevelResolution, OutputFeatureClass };

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>The TIN, terrain, or LAS dataset surface to process.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The polygon features that define the region being processed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Height Field</para>
		/// <para>The field in the polygon's attribute table that defines the height of the reference plane used in determining volumetric calculations.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InHeightField { get; set; }

		/// <summary>
		/// <para>Reference Plane</para>
		/// <para>The direction from the reference plane that volume and surface area will be calculated.</para>
		/// <para>Calculate above the plane—Volume and surface area are calculated above the reference plane height of the polygons.</para>
		/// <para>Calculate below the plane—Volume and surface area are calculated below the reference plane height of the polygons. This is the default.</para>
		/// <para><see cref="ReferencePlaneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ReferencePlane { get; set; } = "BELOW";

		/// <summary>
		/// <para>Volume Field</para>
		/// <para>Specifies the name of the field that will contain volumetric calculations. The default is Volume.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object OutVolumeField { get; set; } = "Volume";

		/// <summary>
		/// <para>Surface Area Field</para>
		/// <para>Specifies the name of the field that will contain the surface area calculations. The default is SArea.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object SurfaceAreaField { get; set; } = "SArea";

		/// <summary>
		/// <para>Pyramid Level Resolution</para>
		/// <para>The z-tolerance or window-size resolution of the terrain pyramid level that will be used. The default is 0, or full resolution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object PyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PolygonVolume SetEnviroment(object extent = null , object geographicTransformations = null , object terrainMemoryUsage = null , object workspace = null )
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, terrainMemoryUsage: terrainMemoryUsage, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Reference Plane</para>
		/// </summary>
		public enum ReferencePlaneEnum 
		{
			/// <summary>
			/// <para>Calculate above the plane—Volume and surface area are calculated above the reference plane height of the polygons.</para>
			/// </summary>
			[GPValue("ABOVE")]
			[Description("Calculate above the plane")]
			Calculate_above_the_plane,

			/// <summary>
			/// <para>Calculate below the plane—Volume and surface area are calculated below the reference plane height of the polygons. This is the default.</para>
			/// </summary>
			[GPValue("BELOW")]
			[Description("Calculate below the plane")]
			Calculate_below_the_plane,

		}

#endregion
	}
}
