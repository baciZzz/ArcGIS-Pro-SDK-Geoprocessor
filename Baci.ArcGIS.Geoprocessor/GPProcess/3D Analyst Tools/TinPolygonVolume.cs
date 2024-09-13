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
	/// <para>TIN Polygon Volume</para>
	/// <para>TIN Polygon Volume</para>
	/// <para>Calculates the volumetric and surface area between polygons of an input feature class and a TIN surface.</para>
	/// </summary>
	[Obsolete()]
	public class TinPolygonVolume : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTin">
		/// <para>Input TIN</para>
		/// <para>The input TIN.</para>
		/// </param>
		/// <param name="InFeatureClass">
		/// <para>Input Feature Class</para>
		/// <para>The input polygon feature class.</para>
		/// </param>
		/// <param name="InHeightField">
		/// <para>Height Field</para>
		/// <para>The name of the field containing polygon reference plane heights.</para>
		/// </param>
		public TinPolygonVolume(object InTin, object InFeatureClass, object InHeightField)
		{
			this.InTin = InTin;
			this.InFeatureClass = InFeatureClass;
			this.InHeightField = InHeightField;
		}

		/// <summary>
		/// <para>Tool Display Name : TIN Polygon Volume</para>
		/// </summary>
		public override string DisplayName() => "TIN Polygon Volume";

		/// <summary>
		/// <para>Tool Name : TinPolygonVolume</para>
		/// </summary>
		public override string ToolName() => "TinPolygonVolume";

		/// <summary>
		/// <para>Tool Excute Name : 3d.TinPolygonVolume</para>
		/// </summary>
		public override string ExcuteName() => "3d.TinPolygonVolume";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTin, InFeatureClass, InHeightField, ReferencePlane!, OutVolumeField!, SurfaceAreaField!, OutputFeatureClass! };

		/// <summary>
		/// <para>Input TIN</para>
		/// <para>The input TIN.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPTinLayer()]
		public object InTin { get; set; }

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>The input polygon feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		public object InFeatureClass { get; set; }

		/// <summary>
		/// <para>Height Field</para>
		/// <para>The name of the field containing polygon reference plane heights.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object InHeightField { get; set; }

		/// <summary>
		/// <para>Reference Plane</para>
		/// <para>The keyword used to indicate whether volume and surface area are calculated ABOVE the reference plane height of the polygons, or BELOW. The default is BELOW.</para>
		/// <para><see cref="ReferencePlaneEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ReferencePlane { get; set; } = "BELOW";

		/// <summary>
		/// <para>Volume Field</para>
		/// <para>The name of the output field used to store the volume result. The default is Volume.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? OutVolumeField { get; set; } = "Volume";

		/// <summary>
		/// <para>Surface Area Field</para>
		/// <para>The name of the output field used to store the surface area result. The default is SArea.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? SurfaceAreaField { get; set; } = "SArea";

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TinPolygonVolume SetEnviroment(object? extent = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Reference Plane</para>
		/// </summary>
		public enum ReferencePlaneEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("ABOVE")]
			[Description("ABOVE")]
			ABOVE,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("BELOW")]
			[Description("BELOW")]
			BELOW,

		}

#endregion
	}
}
