using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsDesktopTools
{
	/// <summary>
	/// <para>Clip Layer</para>
	/// <para>Clip Layer</para>
	/// <para>Extracts input features from within specified polygons.</para>
	/// </summary>
	public class ClipLayer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>The dataset containing the point, line, or polygon features to be clipped.</para>
		/// </param>
		/// <param name="Clip_Layer">
		/// <para>Clip  Layer</para>
		/// <para>The dataset containing the polygon features used to clip the input features.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class with clipped features.</para>
		/// </param>
		public ClipLayer(object InputLayer, object Clip_Layer, object OutFeatureClass)
		{
			this.InputLayer = InputLayer;
			this.Clip_Layer = Clip_Layer;
			this.OutFeatureClass = OutFeatureClass;
		}

		/// <summary>
		/// <para>Tool Display Name : Clip Layer</para>
		/// </summary>
		public override string DisplayName() => "Clip Layer";

		/// <summary>
		/// <para>Tool Name : ClipLayer</para>
		/// </summary>
		public override string ToolName() => "ClipLayer";

		/// <summary>
		/// <para>Tool Excute Name : gapro.ClipLayer</para>
		/// </summary>
		public override string ExcuteName() => "gapro.ClipLayer";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise() => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputLayer, Clip_Layer, OutFeatureClass };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The dataset containing the point, line, or polygon features to be clipped.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon", "Polyline")]
		[FeatureType("Simple")]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Clip  Layer</para>
		/// <para>The dataset containing the polygon features used to clip the input features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object Clip_Layer { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class with clipped features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ClipLayer SetEnviroment(object? extent = null, object? outputCoordinateSystem = null, object? parallelProcessingFactor = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

	}
}
