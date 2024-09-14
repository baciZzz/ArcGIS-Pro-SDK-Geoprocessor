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
	/// <para>Smooth Shared Edges</para>
	/// <para>Smooth Shared Edges</para>
	/// <para>Smooths the edges of the input features while maintaining the topological relationship with edges shared with other features.</para>
	/// <para>Input Will Be Modified</para>
	/// </summary>
	[InputWillBeModified()]
	public class SmoothSharedEdges : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The lines or polygons to be smoothed.</para>
		/// </param>
		/// <param name="Algorithm">
		/// <para>Smoothing Algorithm</para>
		/// <para>Specifies the smoothing algorithm.</para>
		/// <para>Polynomial Approximation with Exponential Kernel (PAEK)— Calculates a smoothed polygon that will not pass through the input polygon vertices. It is the acronym for Polynomial Approximation with Exponential Kernel. This is the default.</para>
		/// <para>Bezier interpolation—Fits Bezier curves between vertices. The resulting polygons pass through the vertices of the input polygons. This algorithm does not require a tolerance. Bezier curves will be approximated in the output.</para>
		/// <para><see cref="AlgorithmEnum"/></para>
		/// </param>
		/// <param name="Tolerance">
		/// <para>Smoothing Tolerance</para>
		/// <para>Determines the degree of smoothing. A unit can be specified; if no unit is specified, the unit of the input will be used. This is only used for the PAEK algorithm. The parameter will not appear on the tool dialog box when Bezier interpolation is selected and, in scripting, a value of 0 must be used.</para>
		/// </param>
		public SmoothSharedEdges(object InFeatures, object Algorithm, object Tolerance)
		{
			this.InFeatures = InFeatures;
			this.Algorithm = Algorithm;
			this.Tolerance = Tolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : Smooth Shared Edges</para>
		/// </summary>
		public override string DisplayName() => "Smooth Shared Edges";

		/// <summary>
		/// <para>Tool Name : SmoothSharedEdges</para>
		/// </summary>
		public override string ToolName() => "SmoothSharedEdges";

		/// <summary>
		/// <para>Tool Excute Name : cartography.SmoothSharedEdges</para>
		/// </summary>
		public override string ExcuteName() => "cartography.SmoothSharedEdges";

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
		public override object[] Parameters() => new object[] { InFeatures, Algorithm, Tolerance, SharedEdgeFeatures!, InBarriers!, OutFeatureClass!, OutSharedEdgeFeatureClass! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The lines or polygons to be smoothed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Smoothing Algorithm</para>
		/// <para>Specifies the smoothing algorithm.</para>
		/// <para>Polynomial Approximation with Exponential Kernel (PAEK)— Calculates a smoothed polygon that will not pass through the input polygon vertices. It is the acronym for Polynomial Approximation with Exponential Kernel. This is the default.</para>
		/// <para>Bezier interpolation—Fits Bezier curves between vertices. The resulting polygons pass through the vertices of the input polygons. This algorithm does not require a tolerance. Bezier curves will be approximated in the output.</para>
		/// <para><see cref="AlgorithmEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Algorithm { get; set; } = "PAEK";

		/// <summary>
		/// <para>Smoothing Tolerance</para>
		/// <para>Determines the degree of smoothing. A unit can be specified; if no unit is specified, the unit of the input will be used. This is only used for the PAEK algorithm. The parameter will not appear on the tool dialog box when Bezier interpolation is selected and, in scripting, a value of 0 must be used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object Tolerance { get; set; }

		/// <summary>
		/// <para>Shared Edge Features</para>
		/// <para>Line or polygon features that will be smoothed along edges shared with input features. Other edges are not smoothed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object? SharedEdgeFeatures { get; set; }

		/// <summary>
		/// <para>Input Barrier Layers</para>
		/// <para>Point, line, or polygon features that act as barriers for smoothing. The smoothed features will not touch or cross barrier features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? InBarriers { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		public object? OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object? OutSharedEdgeFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SmoothSharedEdges SetEnviroment(object? cartographicPartitions = null)
		{
			base.SetEnv(cartographicPartitions: cartographicPartitions);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Smoothing Algorithm</para>
		/// </summary>
		public enum AlgorithmEnum 
		{
			/// <summary>
			/// <para>Polynomial Approximation with Exponential Kernel (PAEK)— Calculates a smoothed polygon that will not pass through the input polygon vertices. It is the acronym for Polynomial Approximation with Exponential Kernel. This is the default.</para>
			/// </summary>
			[GPValue("PAEK")]
			[Description("Polynomial Approximation with Exponential Kernel (PAEK)")]
			PAEK,

			/// <summary>
			/// <para>Bezier interpolation—Fits Bezier curves between vertices. The resulting polygons pass through the vertices of the input polygons. This algorithm does not require a tolerance. Bezier curves will be approximated in the output.</para>
			/// </summary>
			[GPValue("BEZIER_INTERPOLATION")]
			[Description("Bezier interpolation")]
			Bezier_interpolation,

		}

#endregion
	}
}
