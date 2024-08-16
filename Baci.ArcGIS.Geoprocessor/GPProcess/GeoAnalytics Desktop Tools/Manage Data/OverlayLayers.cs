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
	/// <para>Overlay Layers</para>
	/// <para>Overlays the geometries from multiple layers into a single layer.  Overlay can be used to combine, erase, modify, or update spatial features.</para>
	/// </summary>
	public class OverlayLayers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputLayer">
		/// <para>Input Layer</para>
		/// <para>The point, line, or polygon features that will be overlaid with the overlay layer.</para>
		/// </param>
		/// <param name="OverlayLayer">
		/// <para>Overlay Layer</para>
		/// <para>The features that will be overlaid with the input layer features.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>A new feature class with overlaid features.</para>
		/// </param>
		/// <param name="OverlayType">
		/// <para>Overlay Type</para>
		/// <para>Specifies the type of overlay to be performed.</para>
		/// <para>Intersect—Computes a geometric intersection of the input layers. Features or portions of features that overlap in both the input layer and overlay layer will be written to the output layer. This is the default.</para>
		/// <para>Erase—Only those features or portions of features in the overlay layer that are not within the features in the input layer are written to the output.</para>
		/// <para>Union— Computes a geometric union of the input layer and overlay layer. All features and their attributes will be written to the layer.</para>
		/// <para>Identity— Computes a geometric intersection of the input features and identity features. Features or portions of features that overlap in both input layer and overlay layer will be written to the output layer.</para>
		/// <para>Symmetrical Difference— Features or portions of features in the input layer and overlay layer that do not overlap will be written to the output layer.</para>
		/// <para><see cref="OverlayTypeEnum"/></para>
		/// </param>
		public OverlayLayers(object InputLayer, object OverlayLayer, object OutFeatureClass, object OverlayType)
		{
			this.InputLayer = InputLayer;
			this.OverlayLayer = OverlayLayer;
			this.OutFeatureClass = OutFeatureClass;
			this.OverlayType = OverlayType;
		}

		/// <summary>
		/// <para>Tool Display Name : Overlay Layers</para>
		/// </summary>
		public override string DisplayName => "Overlay Layers";

		/// <summary>
		/// <para>Tool Name : OverlayLayers</para>
		/// </summary>
		public override string ToolName => "OverlayLayers";

		/// <summary>
		/// <para>Tool Excute Name : gapro.OverlayLayers</para>
		/// </summary>
		public override string ExcuteName => "gapro.OverlayLayers";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Desktop Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "GeoAnalytics Desktop Tools";

		/// <summary>
		/// <para>Toolbox Alise : gapro</para>
		/// </summary>
		public override string ToolboxAlise => "gapro";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "extent", "outputCoordinateSystem", "parallelProcessingFactor", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InputLayer, OverlayLayer, OutFeatureClass, OverlayType };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The point, line, or polygon features that will be overlaid with the overlay layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Polygon", "Polyline")]
		[FeatureType("Simple")]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Overlay Layer</para>
		/// <para>The features that will be overlaid with the input layer features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object OverlayLayer { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>A new feature class with overlaid features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Overlay Type</para>
		/// <para>Specifies the type of overlay to be performed.</para>
		/// <para>Intersect—Computes a geometric intersection of the input layers. Features or portions of features that overlap in both the input layer and overlay layer will be written to the output layer. This is the default.</para>
		/// <para>Erase—Only those features or portions of features in the overlay layer that are not within the features in the input layer are written to the output.</para>
		/// <para>Union— Computes a geometric union of the input layer and overlay layer. All features and their attributes will be written to the layer.</para>
		/// <para>Identity— Computes a geometric intersection of the input features and identity features. Features or portions of features that overlap in both input layer and overlay layer will be written to the output layer.</para>
		/// <para>Symmetrical Difference— Features or portions of features in the input layer and overlay layer that do not overlap will be written to the output layer.</para>
		/// <para><see cref="OverlayTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OverlayType { get; set; } = "INTERSECT";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public OverlayLayers SetEnviroment(object extent = null , object outputCoordinateSystem = null , object parallelProcessingFactor = null , object workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, parallelProcessingFactor: parallelProcessingFactor, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Overlay Type</para>
		/// </summary>
		public enum OverlayTypeEnum 
		{
			/// <summary>
			/// <para>Intersect—Computes a geometric intersection of the input layers. Features or portions of features that overlap in both the input layer and overlay layer will be written to the output layer. This is the default.</para>
			/// </summary>
			[GPValue("INTERSECT")]
			[Description("Intersect")]
			Intersect,

			/// <summary>
			/// <para>Erase—Only those features or portions of features in the overlay layer that are not within the features in the input layer are written to the output.</para>
			/// </summary>
			[GPValue("ERASE")]
			[Description("Erase")]
			Erase,

			/// <summary>
			/// <para>Identity— Computes a geometric intersection of the input features and identity features. Features or portions of features that overlap in both input layer and overlay layer will be written to the output layer.</para>
			/// </summary>
			[GPValue("IDENTITY")]
			[Description("Identity")]
			Identity,

			/// <summary>
			/// <para>Union— Computes a geometric union of the input layer and overlay layer. All features and their attributes will be written to the layer.</para>
			/// </summary>
			[GPValue("UNION")]
			[Description("Union")]
			Union,

			/// <summary>
			/// <para>Symmetrical Difference— Features or portions of features in the input layer and overlay layer that do not overlap will be written to the output layer.</para>
			/// </summary>
			[GPValue("SYMMETRICAL_DIFFERENCE")]
			[Description("Symmetrical Difference")]
			Symmetrical_Difference,

		}

#endregion
	}
}
