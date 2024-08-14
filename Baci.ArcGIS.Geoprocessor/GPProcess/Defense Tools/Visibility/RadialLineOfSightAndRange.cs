using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DefenseTools
{
	/// <summary>
	/// <para>Radial Line Of Sight And Range</para>
	/// <para>Shows  areas visible to one or more observer locations given a specified distance and viewing angle.</para>
	/// </summary>
	public class RadialLineOfSightAndRange : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InObserverFeatures">
		/// <para>Input Observer</para>
		/// <para>The input observer points.</para>
		/// </param>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>The input elevation raster surface. The elevation surface must be projected.</para>
		/// </param>
		/// <param name="OutViewshedFeatureClass">
		/// <para>Output Viewshed Feature Class</para>
		/// <para>The output polygon feature class showing visible and nonvisible areas.</para>
		/// </param>
		/// <param name="OutFovFeatureClass">
		/// <para>Output Field of View Outline Feature Class</para>
		/// <para>The output polygon feature class containing the field of view range fan.</para>
		/// </param>
		/// <param name="OutRangeRadiusFeatureClass">
		/// <para>Output Range</para>
		/// <para>The output polygon feature class containing the viewing sector created by the range radius, start angle, and end angle.</para>
		/// </param>
		public RadialLineOfSightAndRange(object InObserverFeatures, object InSurface, object OutViewshedFeatureClass, object OutFovFeatureClass, object OutRangeRadiusFeatureClass)
		{
			this.InObserverFeatures = InObserverFeatures;
			this.InSurface = InSurface;
			this.OutViewshedFeatureClass = OutViewshedFeatureClass;
			this.OutFovFeatureClass = OutFovFeatureClass;
			this.OutRangeRadiusFeatureClass = OutRangeRadiusFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Radial Line Of Sight And Range</para>
		/// </summary>
		public override string DisplayName => "Radial Line Of Sight And Range";

		/// <summary>
		/// <para>Tool Name : RadialLineOfSightAndRange</para>
		/// </summary>
		public override string ToolName => "RadialLineOfSightAndRange";

		/// <summary>
		/// <para>Tool Excute Name : defense.RadialLineOfSightAndRange</para>
		/// </summary>
		public override string ExcuteName => "defense.RadialLineOfSightAndRange";

		/// <summary>
		/// <para>Toolbox Display Name : Defense Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Defense Tools";

		/// <summary>
		/// <para>Toolbox Alise : defense</para>
		/// </summary>
		public override string ToolboxAlise => "defense";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InObserverFeatures, InSurface, OutViewshedFeatureClass, OutFovFeatureClass, OutRangeRadiusFeatureClass, ObserverHeightOffset, InnerRadius, OuterRadius, HorizontalStartAngle, HorizontalEndAngle };

		/// <summary>
		/// <para>Input Observer</para>
		/// <para>The input observer points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		public object InObserverFeatures { get; set; }

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>The input elevation raster surface. The elevation surface must be projected.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Output Viewshed Feature Class</para>
		/// <para>The output polygon feature class showing visible and nonvisible areas.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutViewshedFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Field of View Outline Feature Class</para>
		/// <para>The output polygon feature class containing the field of view range fan.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFovFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Range</para>
		/// <para>The output polygon feature class containing the viewing sector created by the range radius, start angle, and end angle.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutRangeRadiusFeatureClass { get; set; }

		/// <summary>
		/// <para>Observer Height Offset (meters)</para>
		/// <para>The height added to the surface elevation of the observer. The default is 2.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Visibility Options")]
		public object ObserverHeightOffset { get; set; } = "2";

		/// <summary>
		/// <para>Minimum Distance (meters)</para>
		/// <para>The minimum (nearest) distance from observers to consider for analysis in meters. The default is 1000.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Visibility Options")]
		public object InnerRadius { get; set; } = "1000";

		/// <summary>
		/// <para>Maximum Distance (meters)</para>
		/// <para>The maximum (farthest) distance from observers to consider for analysis in meters. The default is 3000.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Visibility Options")]
		public object OuterRadius { get; set; } = "3000";

		/// <summary>
		/// <para>Horizontal Start Angle (degrees)</para>
		/// <para>The left bearing limit in degrees. The default is 0.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Visibility Options")]
		public object HorizontalStartAngle { get; set; } = "0";

		/// <summary>
		/// <para>Horizontal End Angle (degrees)</para>
		/// <para>The right bearing limit in degrees. The default is 360.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Visibility Options")]
		public object HorizontalEndAngle { get; set; } = "360";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RadialLineOfSightAndRange SetEnviroment(object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
