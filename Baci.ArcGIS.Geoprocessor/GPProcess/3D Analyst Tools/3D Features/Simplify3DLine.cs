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
	/// <para>Simplify 3D Line</para>
	/// <para>Simplify 3D Line</para>
	/// <para>Generalizes 3D line features to reduce the overall number of vertices while approximating the original shape in horizontal and vertical directions within a specified tolerance.</para>
	/// </summary>
	public class Simplify3DLine : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Line Features</para>
		/// <para>The line features to be simplified.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Lines</para>
		/// <para>The simplified output line features.</para>
		/// </param>
		/// <param name="Tolerance">
		/// <para>Simplification Tolerance</para>
		/// <para>The 3D distance threshold from the input lines that the simplified output must remain within.</para>
		/// </param>
		public Simplify3DLine(object InFeatures, object OutFeatureClass, object Tolerance)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.Tolerance = Tolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : Simplify 3D Line</para>
		/// </summary>
		public override string DisplayName() => "Simplify 3D Line";

		/// <summary>
		/// <para>Tool Name : Simplify3DLine</para>
		/// </summary>
		public override string ToolName() => "Simplify3DLine";

		/// <summary>
		/// <para>Tool Excute Name : 3d.Simplify3DLine</para>
		/// </summary>
		public override string ExcuteName() => "3d.Simplify3DLine";

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
		public override string[] ValidEnvironments() => new string[] { "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, Tolerance };

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>The line features to be simplified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Lines</para>
		/// <para>The simplified output line features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Simplification Tolerance</para>
		/// <para>The 3D distance threshold from the input lines that the simplified output must remain within.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		[GPCodedValueDomain()]
		public object Tolerance { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Simplify3DLine SetEnviroment(object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

	}
}
