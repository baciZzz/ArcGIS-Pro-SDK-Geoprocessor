using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.StandardFeatureAnalysisTools
{
	/// <summary>
	/// <para>Overlay Layers</para>
	/// <para>Overlay Layers</para>
	/// <para>Overlays the geometries from multiple layers into one single layer.  Overlay can be used to combine, erase, modify, or update spatial features. Overlay is much more than a merging of geometries; all the attributes of the features taking part in the overlay are carried through to the result.</para>
	/// </summary>
	public class OverlayLayers : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Inputlayer">
		/// <para>Input Layer</para>
		/// <para>The point, line, or polygon features that will be overlaid with the overlay layer.</para>
		/// </param>
		/// <param name="Overlaylayer">
		/// <para>Overlay Layer</para>
		/// <para>The features that will be overlaid with the input layer features.</para>
		/// </param>
		/// <param name="Outputname">
		/// <para>Output Name</para>
		/// <para>The name of the output layer to create on your portal.</para>
		/// </param>
		public OverlayLayers(object Inputlayer, object Overlaylayer, object Outputname)
		{
			this.Inputlayer = Inputlayer;
			this.Overlaylayer = Overlaylayer;
			this.Outputname = Outputname;
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
		/// <para>Tool Excute Name : sfa.OverlayLayers</para>
		/// </summary>
		public override string ExcuteName() => "sfa.OverlayLayers";

		/// <summary>
		/// <para>Toolbox Display Name : Standard Feature Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Standard Feature Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : sfa</para>
		/// </summary>
		public override string ToolboxAlise() => "sfa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Inputlayer, Overlaylayer, Outputname, Overlaytype, Outputtype, Snaptoinput, Tolerance, Output };

		/// <summary>
		/// <para>Input Layer</para>
		/// <para>The point, line, or polygon features that will be overlaid with the overlay layer.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Inputlayer { get; set; }

		/// <summary>
		/// <para>Overlay Layer</para>
		/// <para>The features that will be overlaid with the input layer features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureRecordSetLayer()]
		public object Overlaylayer { get; set; }

		/// <summary>
		/// <para>Output Name</para>
		/// <para>The name of the output layer to create on your portal.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object Outputname { get; set; }

		/// <summary>
		/// <para>Overlay Type</para>
		/// <para>The type of overlay to be performed.</para>
		/// <para>Intersect—Computes a geometric intersection of the input layers. Features or portions of features that overlap in both the input layer and overlay layer will be written to the output layer. This is the default.</para>
		/// <para>Union—Computes a geometric union of the input layers. All features and their attributes will be written to the output layer. This option is only valid if both the input layer and the overlay layer contain polygon features.</para>
		/// <para>Erase—Only those features or portions of features in the overlay layer that are not within the features in the input layer are written to the output.</para>
		/// <para><see cref="OverlaytypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Overlaytype { get; set; } = "INTERSECT";

		/// <summary>
		/// <para>Output Type</para>
		/// <para>The type of intersection you want to find. This parameter is only valid when the overlay type is Intersect.</para>
		/// <para>Input—The features returned will be the same geometry type as the input layer or overlay layer with the lowest dimension geometry. If all inputs are polygons, the output will contain polygons. If one or more of the inputs are lines and none of the inputs are points, the output will be line. If one or more of the inputs are points, the output will contain points. This is the default.</para>
		/// <para>Line— Line intersections will be returned. This is only valid if none of the inputs are points.</para>
		/// <para>Point— Point intersections will be returned. If the inputs are line or polygon, the output will be a multipoint layer.</para>
		/// <para><see cref="OutputtypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Outputtype { get; set; } = "INPUT";

		/// <summary>
		/// <para>Snap To Input</para>
		/// <para>Specifies if feature vertices in the input layer are allowed to move. The default is unchecked and means if the distance between features is less than the tolerance value, all features from both layers can move to allow snapping to each other. When checked, only features in overlay layer can move to snap to the input layer features.</para>
		/// <para>Unchecked—Allow features from both layers to snap their vertices to each other. This is the default.</para>
		/// <para>Checked—Only allow features in the overlay layer to move vertices to snap to the input layer.</para>
		/// <para><see cref="SnaptoinputEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object Snaptoinput { get; set; } = "false";

		/// <summary>
		/// <para>Tolerance</para>
		/// <para>A double value of the minimum distance separating all feature coordinates as well as the distance a coordinate can move in X or Y (or both). The units of tolerance are the same as the units of the input layer's coordinate system.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object Tolerance { get; set; }

		/// <summary>
		/// <para>Output</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureRecordSetLayer()]
		public object Output { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public OverlayLayers SetEnviroment(object extent = null)
		{
			base.SetEnv(extent: extent);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Overlay Type</para>
		/// </summary>
		public enum OverlaytypeEnum 
		{
			/// <summary>
			/// <para>Intersect—Computes a geometric intersection of the input layers. Features or portions of features that overlap in both the input layer and overlay layer will be written to the output layer. This is the default.</para>
			/// </summary>
			[GPValue("INTERSECT")]
			[Description("Intersect")]
			Intersect,

			/// <summary>
			/// <para>Union—Computes a geometric union of the input layers. All features and their attributes will be written to the output layer. This option is only valid if both the input layer and the overlay layer contain polygon features.</para>
			/// </summary>
			[GPValue("UNION")]
			[Description("Union")]
			Union,

			/// <summary>
			/// <para>Erase—Only those features or portions of features in the overlay layer that are not within the features in the input layer are written to the output.</para>
			/// </summary>
			[GPValue("ERASE")]
			[Description("Erase")]
			Erase,

		}

		/// <summary>
		/// <para>Output Type</para>
		/// </summary>
		public enum OutputtypeEnum 
		{
			/// <summary>
			/// <para>Input—The features returned will be the same geometry type as the input layer or overlay layer with the lowest dimension geometry. If all inputs are polygons, the output will contain polygons. If one or more of the inputs are lines and none of the inputs are points, the output will be line. If one or more of the inputs are points, the output will contain points. This is the default.</para>
			/// </summary>
			[GPValue("INPUT")]
			[Description("Input")]
			Input,

			/// <summary>
			/// <para>Line— Line intersections will be returned. This is only valid if none of the inputs are points.</para>
			/// </summary>
			[GPValue("LINE")]
			[Description("Line")]
			Line,

			/// <summary>
			/// <para>Point— Point intersections will be returned. If the inputs are line or polygon, the output will be a multipoint layer.</para>
			/// </summary>
			[GPValue("POINT")]
			[Description("Point")]
			Point,

		}

		/// <summary>
		/// <para>Snap To Input</para>
		/// </summary>
		public enum SnaptoinputEnum 
		{
			/// <summary>
			/// <para>Checked—Only allow features in the overlay layer to move vertices to snap to the input layer.</para>
			/// </summary>
			[GPValue("true")]
			[Description("SNAP")]
			SNAP,

			/// <summary>
			/// <para>Unchecked—Allow features from both layers to snap their vertices to each other. This is the default.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_SNAP")]
			NO_SNAP,

		}

#endregion
	}
}
