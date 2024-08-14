using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.CartographyTools
{
	/// <summary>
	/// <para>Align Marker To Stroke Or Fill</para>
	/// <para>Aligns the marker symbol layers of a point feature class to the nearest stroke or fill symbol layers in a line or polygon feature class within a specified search distance.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class AlignMarkerToStrokeOrFill : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InPointFeatures">
		/// <para>Input Point Features</para>
		/// <para>The input point feature layer containing point symbols to be aligned to nearby lines or polygons. Symbols are aligned by storing an angle in the attribute connected to the angle property of the marker symbol layer. This must be connected to a single field with no expression applied.</para>
		/// </param>
		/// <param name="InLineOrPolygonFeatures">
		/// <para>Input Line or Polygon Features</para>
		/// <para>The input line or polygon feature layer to which the input point symbols will be aligned.</para>
		/// </param>
		/// <param name="SearchDistance">
		/// <para>Search Distance</para>
		/// <para>The search distance from graphical marker edge to graphical stroke or fill edge. A distance greater than or equal to zero must be specified.</para>
		/// </param>
		public AlignMarkerToStrokeOrFill(object InPointFeatures, object InLineOrPolygonFeatures, object SearchDistance)
		{
			this.InPointFeatures = InPointFeatures;
			this.InLineOrPolygonFeatures = InLineOrPolygonFeatures;
			this.SearchDistance = SearchDistance;
		}

		/// <summary>
		/// <para>Tool Display Name : Align Marker To Stroke Or Fill</para>
		/// </summary>
		public override string DisplayName => "Align Marker To Stroke Or Fill";

		/// <summary>
		/// <para>Tool Name : AlignMarkerToStrokeOrFill</para>
		/// </summary>
		public override string ToolName => "AlignMarkerToStrokeOrFill";

		/// <summary>
		/// <para>Tool Excute Name : cartography.AlignMarkerToStrokeOrFill</para>
		/// </summary>
		public override string ExcuteName => "cartography.AlignMarkerToStrokeOrFill";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "cartographicCoordinateSystem", "cartographicPartitions", "referenceScale" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InPointFeatures, InLineOrPolygonFeatures, SearchDistance, MarkerOrientation, OutRepresentations };

		/// <summary>
		/// <para>Input Point Features</para>
		/// <para>The input point feature layer containing point symbols to be aligned to nearby lines or polygons. Symbols are aligned by storing an angle in the attribute connected to the angle property of the marker symbol layer. This must be connected to a single field with no expression applied.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		[GPFeatureClassDomain()]
		public object InPointFeatures { get; set; }

		/// <summary>
		/// <para>Input Line or Polygon Features</para>
		/// <para>The input line or polygon feature layer to which the input point symbols will be aligned.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLayer()]
		[GPFeatureClassDomain()]
		public object InLineOrPolygonFeatures { get; set; }

		/// <summary>
		/// <para>Search Distance</para>
		/// <para>The search distance from graphical marker edge to graphical stroke or fill edge. A distance greater than or equal to zero must be specified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object SearchDistance { get; set; }

		/// <summary>
		/// <para>Marker Orientation</para>
		/// <para>Specifies how the marker symbol layer will be oriented relative to the stroke or fill symbol layer&apos;s edge.</para>
		/// <para>Perpendicular—Marker symbol layers will be aligned perpendicularly to the stroke or fill edge. This is the default.</para>
		/// <para>Parallel—Marker symbol layers will be aligned parallel to the stroke or fill edge.</para>
		/// <para><see cref="MarkerOrientationEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object MarkerOrientation { get; set; } = "PERPENDICULAR";

		/// <summary>
		/// <para>Updated Input Layer</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPLayer()]
		public object OutRepresentations { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public AlignMarkerToStrokeOrFill SetEnviroment(object cartographicCoordinateSystem = null , object cartographicPartitions = null , object referenceScale = null )
		{
			base.SetEnv(cartographicCoordinateSystem: cartographicCoordinateSystem, cartographicPartitions: cartographicPartitions, referenceScale: referenceScale);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Marker Orientation</para>
		/// </summary>
		public enum MarkerOrientationEnum 
		{
			/// <summary>
			/// <para>Perpendicular—Marker symbol layers will be aligned perpendicularly to the stroke or fill edge. This is the default.</para>
			/// </summary>
			[GPValue("PERPENDICULAR")]
			[Description("Perpendicular")]
			Perpendicular,

			/// <summary>
			/// <para>Parallel—Marker symbol layers will be aligned parallel to the stroke or fill edge.</para>
			/// </summary>
			[GPValue("PARALLEL")]
			[Description("Parallel")]
			Parallel,

		}

#endregion
	}
}
