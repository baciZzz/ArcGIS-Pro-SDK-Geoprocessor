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
	/// <para>Line Of Sight</para>
	/// <para>Line Of Sight</para>
	/// <para>Determines the visibility of sight lines over obstructions consisting of a surface and an optional multipatch dataset.</para>
	/// </summary>
	public class LineOfSight : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>The integrated mesh scene layer, LAS dataset, raster, TIN, or terrain surface used to determine visibility.</para>
		/// </param>
		/// <param name="InLineFeatureClass">
		/// <para>Input Line Features</para>
		/// <para>The line features whose first vertex defines the observation point and last vertex identifies the target location. The heights of the observation and target locations are obtained from the z-values of 3D features and interpolated from the surface for 2D features.</para>
		/// <para>2D lines also have a default offset of 1 added to their elevation to raise the points above the surface. If the feature has an OffsetA field, its value will be added to the height of the observation point. If the OffsetB field is present, its value will be added to the height of the target position.</para>
		/// </param>
		/// <param name="OutLosFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output line feature class along which visibility has been determined. Two attribute fields are created. The VisCode field indicates visibility along the line: 1 being visible and 2 not visible. The TarIsVis field indicates the target visibility: 0 being not visible and 1 being visible.</para>
		/// </param>
		public LineOfSight(object InSurface, object InLineFeatureClass, object OutLosFeatureClass)
		{
			this.InSurface = InSurface;
			this.InLineFeatureClass = InLineFeatureClass;
			this.OutLosFeatureClass = OutLosFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Line Of Sight</para>
		/// </summary>
		public override string DisplayName() => "Line Of Sight";

		/// <summary>
		/// <para>Tool Name : LineOfSight</para>
		/// </summary>
		public override string ToolName() => "LineOfSight";

		/// <summary>
		/// <para>Tool Excute Name : 3d.LineOfSight</para>
		/// </summary>
		public override string ExcuteName() => "3d.LineOfSight";

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
		public override object[] Parameters() => new object[] { InSurface, InLineFeatureClass, OutLosFeatureClass, OutObstructionFeatureClass, UseCurvature, UseRefraction, RefractionFactor, PyramidLevelResolution, InFeatures };

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>The integrated mesh scene layer, LAS dataset, raster, TIN, or terrain surface used to determine visibility.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Input Line Features</para>
		/// <para>The line features whose first vertex defines the observation point and last vertex identifies the target location. The heights of the observation and target locations are obtained from the z-values of 3D features and interpolated from the surface for 2D features.</para>
		/// <para>2D lines also have a default offset of 1 added to their elevation to raise the points above the surface. If the feature has an OffsetA field, its value will be added to the height of the observation point. If the OffsetB field is present, its value will be added to the height of the target position.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InLineFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output line feature class along which visibility has been determined. Two attribute fields are created. The VisCode field indicates visibility along the line: 1 being visible and 2 not visible. The TarIsVis field indicates the target visibility: 0 being not visible and 1 being visible.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutLosFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Obstruction Point Feature Class</para>
		/// <para>An optional point feature class identifying the location of the first obstruction on the observer's sight line to its target.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFeatureClass()]
		public object OutObstructionFeatureClass { get; set; }

		/// <summary>
		/// <para>Use Curvature</para>
		/// <para>Specifies whether the earth&apos;s curvature will be taken into consideration for the line-of-sight analysis. For this parameter to be active, the surface must have a defined spatial reference in projected coordinates with defined z-units.</para>
		/// <para>Unchecked—The earth&apos;s curvature will not be taken into consideration. This is the default.</para>
		/// <para>Checked—The earth&apos;s curvature will be taken into consideration.</para>
		/// <para><see cref="UseCurvatureEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Surface Options")]
		public object UseCurvature { get; set; } = "false";

		/// <summary>
		/// <para>Use Refraction</para>
		/// <para>Specifies whether atmospheric refraction will be taken into consideration when generating a line of sight from a functional surface. This parameter does not apply if multipatch features are used.</para>
		/// <para>Unchecked—Atmospheric refraction will not be taken into consideration. This is the default.</para>
		/// <para>Checked—Atmospheric refraction will be taken into consideration.</para>
		/// <para><see cref="UseRefractionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Surface Options")]
		public object UseRefraction { get; set; } = "false";

		/// <summary>
		/// <para>Refraction Factor</para>
		/// <para>The value to be used in the refraction factor. The default value is 0.13.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Surface Options")]
		public object RefractionFactor { get; set; } = "0.13";

		/// <summary>
		/// <para>Pyramid Level Resolution</para>
		/// <para>The z-tolerance or window-size resolution of the terrain pyramid level that will be used. The default value is 0, or full resolution.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Surface Options")]
		public object PyramidLevelResolution { get; set; } = "0";

		/// <summary>
		/// <para>Input Features</para>
		/// <para>A multipatch feature that may define additional obstructing elements, such as buildings. Refraction options are not honored for this input.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("MultiPatch")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public LineOfSight SetEnviroment(object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZDomain = null, object ZResolution = null, object ZTolerance = null, int? autoCommit = null, object configKeyword = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object terrainMemoryUsage = null, object workspace = null)
		{
			base.SetEnv(XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, autoCommit: autoCommit, configKeyword: configKeyword, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, terrainMemoryUsage: terrainMemoryUsage, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Use Curvature</para>
		/// </summary>
		public enum UseCurvatureEnum 
		{
			/// <summary>
			/// <para>Checked—The earth&apos;s curvature will be taken into consideration.</para>
			/// </summary>
			[GPValue("true")]
			[Description("CURVATURE")]
			CURVATURE,

			/// <summary>
			/// <para>Unchecked—The earth&apos;s curvature will not be taken into consideration. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CURVATURE")]
			NO_CURVATURE,

		}

		/// <summary>
		/// <para>Use Refraction</para>
		/// </summary>
		public enum UseRefractionEnum 
		{
			/// <summary>
			/// <para>Checked—Atmospheric refraction will be taken into consideration.</para>
			/// </summary>
			[GPValue("true")]
			[Description("REFRACTION")]
			REFRACTION,

			/// <summary>
			/// <para>Unchecked—Atmospheric refraction will not be taken into consideration. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_REFRACTION")]
			NO_REFRACTION,

		}

#endregion
	}
}
