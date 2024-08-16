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
	/// <para>Radial Line Of Sight</para>
	/// <para>Shows  areas visible to one or more observer locations.</para>
	/// </summary>
	public class RadialLineOfSight : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InObserverFeatures">
		/// <para>Input Observer Features</para>
		/// <para>The input observer points.</para>
		/// </param>
		/// <param name="InSurface">
		/// <para>Input Surface</para>
		/// <para>The input elevation raster surface.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Visibility</para>
		/// <para>The output polygon feature class showing visible and nonvisible surface areas.</para>
		/// </param>
		public RadialLineOfSight(object InObserverFeatures, object InSurface, object OutFeatureClass)
		{
			this.InObserverFeatures = InObserverFeatures;
			this.InSurface = InSurface;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Radial Line Of Sight</para>
		/// </summary>
		public override string DisplayName => "Radial Line Of Sight";

		/// <summary>
		/// <para>Tool Name : RadialLineOfSight</para>
		/// </summary>
		public override string ToolName => "RadialLineOfSight";

		/// <summary>
		/// <para>Tool Excute Name : defense.RadialLineOfSight</para>
		/// </summary>
		public override string ExcuteName => "defense.RadialLineOfSight";

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
		public override object[] Parameters => new object[] { InObserverFeatures, InSurface, OutFeatureClass, Radius, ObserverHeightAboveSurface };

		/// <summary>
		/// <para>Input Observer Features</para>
		/// <para>The input observer points.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		[FeatureType("Simple")]
		public object InObserverFeatures { get; set; }

		/// <summary>
		/// <para>Input Surface</para>
		/// <para>The input elevation raster surface.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPRasterLayer()]
		public object InSurface { get; set; }

		/// <summary>
		/// <para>Output Visibility</para>
		/// <para>The output polygon feature class showing visible and nonvisible surface areas.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Radius Of Observer (meters)</para>
		/// <para>The radius of the analysis area from the observer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Visibility Options")]
		public object Radius { get; set; } = "1000";

		/// <summary>
		/// <para>Observer Height Above Surface (meters)</para>
		/// <para>The height added to the surface elevation of the observer. The default is 2.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Visibility Options")]
		public object ObserverHeightAboveSurface { get; set; } = "2";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public RadialLineOfSight SetEnviroment(object outputCoordinateSystem = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
