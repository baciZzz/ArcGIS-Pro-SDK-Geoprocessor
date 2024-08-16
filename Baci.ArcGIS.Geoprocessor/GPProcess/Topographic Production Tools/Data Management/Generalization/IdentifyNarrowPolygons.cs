using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Identify Narrow Polygons</para>
	/// <para>Splits a polygon based on its width and classifies each portion as narrow or wide based on its width and length.</para>
	/// </summary>
	public class IdentifyNarrowPolygons : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The features to be split.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing the results.</para>
		/// </param>
		/// <param name="MinWidth">
		/// <para>Minimum Width</para>
		/// <para>The width used to split and classify polygons as narrow or wide. Polygons will be split at any location where the edge-to-edge distance is equal to the Minimum Width.</para>
		/// </param>
		/// <param name="MinLength">
		/// <para>Minimum Length</para>
		/// <para>The length used to classify the split polygons as short or long.</para>
		/// </param>
		public IdentifyNarrowPolygons(object InFeatures, object OutFeatureClass, object MinWidth, object MinLength)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.MinWidth = MinWidth;
			this.MinLength = MinLength;
		}

		/// <summary>
		/// <para>Tool Display Name : Identify Narrow Polygons</para>
		/// </summary>
		public override string DisplayName => "Identify Narrow Polygons";

		/// <summary>
		/// <para>Tool Name : IdentifyNarrowPolygons</para>
		/// </summary>
		public override string ToolName => "IdentifyNarrowPolygons";

		/// <summary>
		/// <para>Tool Excute Name : topographic.IdentifyNarrowPolygons</para>
		/// </summary>
		public override string ExcuteName => "topographic.IdentifyNarrowPolygons";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatures, OutFeatureClass, MinWidth, MinLength, TaperLength, ConnectingFeatures };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The features to be split.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output feature class containing the results.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Minimum Width</para>
		/// <para>The width used to split and classify polygons as narrow or wide. Polygons will be split at any location where the edge-to-edge distance is equal to the Minimum Width.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object MinWidth { get; set; }

		/// <summary>
		/// <para>Minimum Length</para>
		/// <para>The length used to classify the split polygons as short or long.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object MinLength { get; set; }

		/// <summary>
		/// <para>Taper Length</para>
		/// <para>The distance the end of the split feature will extend to provide a more natural break.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object TaperLength { get; set; }

		/// <summary>
		/// <para>Connecting Features</para>
		/// <para>The features that will be used to refine the tapering of wide areas. The polygons will be tapered toward the touch point or the shared boundary of a connecting feature.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Point", "Multipoint", "Polyline", "Polygon")]
		[FeatureType("Simple")]
		public object ConnectingFeatures { get; set; }

	}
}
