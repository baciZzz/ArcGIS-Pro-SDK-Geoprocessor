using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAnalyticsServerTools
{
	/// <summary>
	/// <para>Overlay Layers</para>
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
		/// <param name="OutputName">
		/// <para>Output Name</para>
		/// <para>The name of the output feature service.</para>
		/// </param>
		/// <param name="OverlayType">
		/// <para>Overlay Type</para>
		/// <para>Specifies the type of overlay to be performed.</para>
		/// <para>Intersect—A geometric intersection of the input layers will be computed. Features or portions of features that overlap in both the input layer and overlay layer will be written to the output layer. This is the default.</para>
		/// <para>Erase—Only those features or portions of features in the input layer that do not overlap the features in the overlay layer will be written to the output.</para>
		/// <para>Union—A geometric union of the input layer and overlay layer will be computed. All features and their attributes will be written to the layer.</para>
		/// <para>Identity—A geometric intersection of the input features and identity features will be computed. Features or portions of features that overlap in both the input layer and the overlay layer will be written to the output layer.</para>
		/// <para>Symmetrical Difference— Features or portions of features in the input layer and overlay layer that do not overlap will be written to the output layer.</para>
		/// <para><see cref="OverlayTypeEnum"/></para>
		/// </param>
		public OverlayLayers(object InputLayer, object OverlayLayer, object OutputName, object OverlayType)
		{
			this.InputLayer = InputLayer;
			this.OverlayLayer = OverlayLayer;
			this.OutputName = OutputName;
			this.OverlayType = OverlayType;
		}

		/// <summary>
		/// <para>Tool Display Name : Overlay Layers</para>
		/// </summary>
		public override string DisplayName() => "Overlay Layers";

		/// <summary>
		/// <para>Tool Name : OverlayLayers</para>
		/// </summary>
		public override string ToolName() => "OverlayLayers";

		/// <summary>
		/// <para>Tool Excute Name : geoanalytics.OverlayLayers</para>
		/// </summary>
		public override string ExcuteName() => "geoanalytics.OverlayLayers";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAnalytics Server Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAnalytics Server Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoanalytics</para>
		/// </summary>
		public override string ToolboxAlise() => "geoanalytics";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "outputCoordinateSystem", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputLayer, OverlayLayer, OutputName, OverlayType, IncludeOverlaps!, DataStore!, Output! };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The point, line, or polygon features that will be overlaid with the overlay layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple")]
		[PortalType("DataStoreCatalogLayer")]
		public object InputLayer { get; set; }

		/// <summary>
		/// <para>Overlay Layer</para>
		/// <para>The features that will be overlaid with the input layer features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		[GPFeatureClassDomain()]
		[FeatureType("Simple")]
		[PortalType("DataStoreCatalogLayer")]
		public object OverlayLayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output feature service.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutputName { get; set; }

		/// <summary>
		/// <para>Overlay Type</para>
		/// <para>Specifies the type of overlay to be performed.</para>
		/// <para>Intersect—A geometric intersection of the input layers will be computed. Features or portions of features that overlap in both the input layer and overlay layer will be written to the output layer. This is the default.</para>
		/// <para>Erase—Only those features or portions of features in the input layer that do not overlap the features in the overlay layer will be written to the output.</para>
		/// <para>Union—A geometric union of the input layer and overlay layer will be computed. All features and their attributes will be written to the layer.</para>
		/// <para>Identity—A geometric intersection of the input features and identity features will be computed. Features or portions of features that overlap in both the input layer and the overlay layer will be written to the output layer.</para>
		/// <para>Symmetrical Difference— Features or portions of features in the input layer and overlay layer that do not overlap will be written to the output layer.</para>
		/// <para><see cref="OverlayTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object OverlayType { get; set; } = "INTERSECT";

		/// <summary>
		/// <para>Include Overlapping Input Layers</para>
		/// <para>Specifies whether one or both of the input layers have overlapping features. This parameter is only supported for ArcGIS Enterprise 10.6.1.</para>
		/// <para>Checked—One or both of the layers have overlapping features. This is the default.</para>
		/// <para>Unchecked—Neither layer has overlapping features.</para>
		/// <para><see cref="IncludeOverlapsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		[Category("Advanced")]
		public object? IncludeOverlaps { get; set; } = "true";

		/// <summary>
		/// <para>Data Store</para>
		/// <para>Specifies the ArcGIS Data Store where the output will be saved. The default is Spatiotemporal big data store. All results stored in a spatiotemporal big data store will be stored in WGS84. Results stored in a relational data store will maintain their coordinate system.</para>
		/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
		/// <para>Relational data store—Output will be stored in a relational data store.</para>
		/// <para><see cref="DataStoreEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		[Category("Data Store")]
		public object? DataStore { get; set; } = "SPATIOTEMPORAL_DATA_STORE";

		/// <summary>
		/// <para>Output Feature Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object? Output { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public OverlayLayers SetEnviroment(object? extent = null , object? outputCoordinateSystem = null , object? workspace = null )
		{
			base.SetEnv(extent: extent, outputCoordinateSystem: outputCoordinateSystem, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Overlay Type</para>
		/// </summary>
		public enum OverlayTypeEnum 
		{
			/// <summary>
			/// <para>Intersect—A geometric intersection of the input layers will be computed. Features or portions of features that overlap in both the input layer and overlay layer will be written to the output layer. This is the default.</para>
			/// </summary>
			[GPValue("INTERSECT")]
			[Description("Intersect")]
			Intersect,

			/// <summary>
			/// <para>Erase—Only those features or portions of features in the input layer that do not overlap the features in the overlay layer will be written to the output.</para>
			/// </summary>
			[GPValue("ERASE")]
			[Description("Erase")]
			Erase,

			/// <summary>
			/// <para>Identity—A geometric intersection of the input features and identity features will be computed. Features or portions of features that overlap in both the input layer and the overlay layer will be written to the output layer.</para>
			/// </summary>
			[GPValue("IDENTITY")]
			[Description("Identity")]
			Identity,

			/// <summary>
			/// <para>Union—A geometric union of the input layer and overlay layer will be computed. All features and their attributes will be written to the layer.</para>
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

		/// <summary>
		/// <para>Include Overlapping Input Layers</para>
		/// </summary>
		public enum IncludeOverlapsEnum 
		{
			/// <summary>
			/// <para>Checked—One or both of the layers have overlapping features. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("OVERLAPPING")]
			OVERLAPPING,

			/// <summary>
			/// <para>Unchecked—Neither layer has overlapping features.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NOT_OVERLAPPING")]
			NOT_OVERLAPPING,

		}

		/// <summary>
		/// <para>Data Store</para>
		/// </summary>
		public enum DataStoreEnum 
		{
			/// <summary>
			/// <para>Spatiotemporal big data store—Output will be stored in a spatiotemporal big data store. This is the default.</para>
			/// </summary>
			[GPValue("SPATIOTEMPORAL_DATA_STORE")]
			[Description("Spatiotemporal big data store")]
			Spatiotemporal_big_data_store,

			/// <summary>
			/// <para>Relational data store—Output will be stored in a relational data store.</para>
			/// </summary>
			[GPValue("RELATIONAL_DATA_STORE")]
			[Description("Relational data store")]
			Relational_data_store,

		}

#endregion
	}
}
