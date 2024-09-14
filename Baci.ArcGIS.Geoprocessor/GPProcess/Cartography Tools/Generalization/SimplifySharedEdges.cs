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
	/// <para>Simplify Shared Edges</para>
	/// <para>Simplify Shared Edges</para>
	/// <para>Simplifies the edges of input features while maintaining the topological relationship with edges shared with other features.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class SimplifySharedEdges : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The lines or polygons to be simplified.</para>
		/// </param>
		/// <param name="Algorithm">
		/// <para>Simplification Algorithm</para>
		/// <para>Specifies the simplification algorithm.</para>
		/// <para>Retain critical points (Douglas-Peucker)—Retains critical points that preserve the essential shape of a polygon outline and removes all other points (Douglas-Peucker). This is the default.</para>
		/// <para>Retain critical bends (Wang-Müller)— Retains the critical bends and removes extraneous bends from a line (Wang-Müller).</para>
		/// <para>Retain weighted effective areas (Zhou-Jones)—Retains vertices that form triangles of effective area that have been weighted by triangle shape (Zhou-Jones).</para>
		/// <para>Retain effective areas (Visvalingam-Whyatt)— Retains vertices that form triangles of effective area (Visvalingam-Whyatt).</para>
		/// <para><see cref="AlgorithmEnum"/></para>
		/// </param>
		/// <param name="Tolerance">
		/// <para>Simplification Tolerance</para>
		/// <para>Determines the degree of simplification. If a unit is not specified, the units of the input will be used.</para>
		/// <para>For the Retain critical points (Douglas-Peucker) algorithm, the tolerance is the maximum allowable perpendicular distance between each vertex and the new line created.</para>
		/// <para>For the Retain critical bends (Wang-Müller) algorithm, the tolerance is the diameter of a circle that approximates a significant bend.</para>
		/// <para>For the Retain weighted effective areas (Zhou-Jones) algorithm, the square of the tolerance is the area of a significant triangle defined by three adjacent vertices. The further a triangle deviates from equilateral, the higher weight it is given, and the less likely it is to be removed.</para>
		/// <para>For the Retain effective areas (Visvalingam-Whyatt) algorithm, the square of the tolerance is the area of a significant triangle defined by three adjacent vertices.</para>
		/// </param>
		public SimplifySharedEdges(object InFeatures, object Algorithm, object Tolerance)
		{
			this.InFeatures = InFeatures;
			this.Algorithm = Algorithm;
			this.Tolerance = Tolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : Simplify Shared Edges</para>
		/// </summary>
		public override string DisplayName() => "Simplify Shared Edges";

		/// <summary>
		/// <para>Tool Name : SimplifySharedEdges</para>
		/// </summary>
		public override string ToolName() => "SimplifySharedEdges";

		/// <summary>
		/// <para>Tool Excute Name : cartography.SimplifySharedEdges</para>
		/// </summary>
		public override string ExcuteName() => "cartography.SimplifySharedEdges";

		/// <summary>
		/// <para>Toolbox Display Name : Cartography Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Cartography Tools";

		/// <summary>
		/// <para>Toolbox Alise : cartography</para>
		/// </summary>
		public override string ToolboxAlise() => "cartography";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "cartographicPartitions" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, Algorithm, Tolerance, SharedEdgeFeatures, MinimumArea, InBarriers, OutFeatureClass, OutSharedEdgeFeatureClass };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The lines or polygons to be simplified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Simplification Algorithm</para>
		/// <para>Specifies the simplification algorithm.</para>
		/// <para>Retain critical points (Douglas-Peucker)—Retains critical points that preserve the essential shape of a polygon outline and removes all other points (Douglas-Peucker). This is the default.</para>
		/// <para>Retain critical bends (Wang-Müller)— Retains the critical bends and removes extraneous bends from a line (Wang-Müller).</para>
		/// <para>Retain weighted effective areas (Zhou-Jones)—Retains vertices that form triangles of effective area that have been weighted by triangle shape (Zhou-Jones).</para>
		/// <para>Retain effective areas (Visvalingam-Whyatt)— Retains vertices that form triangles of effective area (Visvalingam-Whyatt).</para>
		/// <para><see cref="AlgorithmEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Algorithm { get; set; } = "POINT_REMOVE";

		/// <summary>
		/// <para>Simplification Tolerance</para>
		/// <para>Determines the degree of simplification. If a unit is not specified, the units of the input will be used.</para>
		/// <para>For the Retain critical points (Douglas-Peucker) algorithm, the tolerance is the maximum allowable perpendicular distance between each vertex and the new line created.</para>
		/// <para>For the Retain critical bends (Wang-Müller) algorithm, the tolerance is the diameter of a circle that approximates a significant bend.</para>
		/// <para>For the Retain weighted effective areas (Zhou-Jones) algorithm, the square of the tolerance is the area of a significant triangle defined by three adjacent vertices. The further a triangle deviates from equilateral, the higher weight it is given, and the less likely it is to be removed.</para>
		/// <para>For the Retain effective areas (Visvalingam-Whyatt) algorithm, the square of the tolerance is the area of a significant triangle defined by three adjacent vertices.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object Tolerance { get; set; }

		/// <summary>
		/// <para>Shared Edge Features</para>
		/// <para>Line or polygon features that will be simplified along edges shared with input features. Other edges are not simplified.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object SharedEdgeFeatures { get; set; }

		/// <summary>
		/// <para>Minimum Area</para>
		/// <para>The minimum area for a polygon to be retained. The default value is zero, which will retain all polygons. A unit can be specified; if no unit is specified, the unit of the input will be used. This parameter is available only when at least one of the inputs is a polygon feature class.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPArealUnit()]
		public object MinimumArea { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Input Barrier Layers</para>
		/// <para>Point, line, or polygon features that act as barriers for the simplification. The simplified features will not touch or cross barrier features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object InBarriers { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutSharedEdgeFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SimplifySharedEdges SetEnviroment(object cartographicPartitions = null)
		{
			base.SetEnv(cartographicPartitions: cartographicPartitions);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Simplification Algorithm</para>
		/// </summary>
		public enum AlgorithmEnum 
		{
			/// <summary>
			/// <para>Retain critical points (Douglas-Peucker)—Retains critical points that preserve the essential shape of a polygon outline and removes all other points (Douglas-Peucker). This is the default.</para>
			/// </summary>
			[GPValue("POINT_REMOVE")]
			[Description("Retain critical points (Douglas-Peucker)")]
			POINT_REMOVE,

			/// <summary>
			/// <para>Retain critical bends (Wang-Müller)— Retains the critical bends and removes extraneous bends from a line (Wang-Müller).</para>
			/// </summary>
			[GPValue("BEND_SIMPLIFY")]
			[Description("Retain critical bends (Wang-Müller)")]
			BEND_SIMPLIFY,

			/// <summary>
			/// <para>Retain weighted effective areas (Zhou-Jones)—Retains vertices that form triangles of effective area that have been weighted by triangle shape (Zhou-Jones).</para>
			/// </summary>
			[GPValue("WEIGHTED_AREA")]
			[Description("Retain weighted effective areas (Zhou-Jones)")]
			WEIGHTED_AREA,

			/// <summary>
			/// <para>Retain effective areas (Visvalingam-Whyatt)— Retains vertices that form triangles of effective area (Visvalingam-Whyatt).</para>
			/// </summary>
			[GPValue("EFFECTIVE_AREA")]
			[Description("Retain effective areas (Visvalingam-Whyatt)")]
			EFFECTIVE_AREA,

		}

#endregion
	}
}
