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
	/// <para>Smooth Polygon</para>
	/// <para>Smooth Polygon</para>
	/// <para>Smooths sharp angles in polygon outlines to improve aesthetic or cartographic quality.</para>
	/// </summary>
	public class SmoothPolygon : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>The polygon features to be smoothed.</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>The output polygon feature class to be created.</para>
		/// </param>
		/// <param name="Algorithm">
		/// <para>Smoothing Algorithm</para>
		/// <para>Specifies the smoothing algorithm.</para>
		/// <para>Polynomial Approximation with Exponential Kernel (PAEK)—This is the acronym for Polynomial Approximation with Exponential Kernel. A smoothed polygon that will not pass through the input polygon vertices will be calculated. This is the default.</para>
		/// <para>Bezier interpolation—Bezier curves will be fitted between vertices. The resulting polygons pass through the vertices of the input polygons. This algorithm does not require a tolerance. Bezier curves will be approximated in the output.</para>
		/// <para><see cref="AlgorithmEnum"/></para>
		/// </param>
		/// <param name="Tolerance">
		/// <para>Smoothing Tolerance</para>
		/// <para>A tolerance used by the Polynomial Approximation with Exponential Kernel (PAEK) algorithm. A tolerance must be specified, and it must be greater than zero. You can choose a preferred unit; the default is the feature unit. This parameter is unavailable when the Bezier interpolation algorithm is used.</para>
		/// </param>
		public SmoothPolygon(object InFeatures, object OutFeatureClass, object Algorithm, object Tolerance)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.Algorithm = Algorithm;
			this.Tolerance = Tolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : Smooth Polygon</para>
		/// </summary>
		public override string DisplayName() => "Smooth Polygon";

		/// <summary>
		/// <para>Tool Name : SmoothPolygon</para>
		/// </summary>
		public override string ToolName() => "SmoothPolygon";

		/// <summary>
		/// <para>Tool Excute Name : cartography.SmoothPolygon</para>
		/// </summary>
		public override string ExcuteName() => "cartography.SmoothPolygon";

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
		public override string[] ValidEnvironments() => new string[] { "MDomain", "XYDomain", "XYTolerance", "cartographicPartitions", "extent", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, Algorithm, Tolerance, EndpointOption!, ErrorOption!, InBarriers! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>The polygon features to be smoothed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>The output polygon feature class to be created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Smoothing Algorithm</para>
		/// <para>Specifies the smoothing algorithm.</para>
		/// <para>Polynomial Approximation with Exponential Kernel (PAEK)—This is the acronym for Polynomial Approximation with Exponential Kernel. A smoothed polygon that will not pass through the input polygon vertices will be calculated. This is the default.</para>
		/// <para>Bezier interpolation—Bezier curves will be fitted between vertices. The resulting polygons pass through the vertices of the input polygons. This algorithm does not require a tolerance. Bezier curves will be approximated in the output.</para>
		/// <para><see cref="AlgorithmEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Algorithm { get; set; } = "PAEK";

		/// <summary>
		/// <para>Smoothing Tolerance</para>
		/// <para>A tolerance used by the Polynomial Approximation with Exponential Kernel (PAEK) algorithm. A tolerance must be specified, and it must be greater than zero. You can choose a preferred unit; the default is the feature unit. This parameter is unavailable when the Bezier interpolation algorithm is used.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object Tolerance { get; set; }

		/// <summary>
		/// <para>Preserve endpoint for rings</para>
		/// <para>This is a legacy parameter that is no longer used. It was formerly used to specify whether the endpoint of an isolated polygon ring would be preserved. This parameter is still included in the tool&apos;s syntax for compatibility in scripts and models but is hidden from the tool&apos;s dialog box.</para>
		/// <para>Specifies whether the endpoints of isolated polygon rings will be preserved. This option works with the PAEK algorithm only.</para>
		/// <para>Checked—The endpoint of an isolated polygon ring will be preserved. This is the default.</para>
		/// <para>Unchecked—The endpoint of an isolated polygon ring will not be preserved; it will be smoothed.</para>
		/// <para><see cref="EndpointOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? EndpointOption { get; set; } = "true";

		/// <summary>
		/// <para>Handling Topological Errors</para>
		/// <para>Specifies how topological errors (possibly introduced in the process, such as line crossing or overlapping) will be handled.</para>
		/// <para>Do not check for topological errors—Topological errors will not be identified. This is the default.</para>
		/// <para>Check and flag topological errors—If topological errors are found, they will be flagged.</para>
		/// <para>Resolve topological errors—If topological errors are found, they will be resolved.</para>
		/// <para><see cref="ErrorOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ErrorOption { get; set; } = "NO_CHECK";

		/// <summary>
		/// <para>Input Barrier Layers</para>
		/// <para>Inputs containing features that will act as barriers for smoothing. The resulting smoothed polygons will not touch or cross barrier features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? InBarriers { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SmoothPolygon SetEnviroment(object? MDomain = null , object? XYDomain = null , object? XYTolerance = null , object? cartographicPartitions = null , object? extent = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(MDomain: MDomain, XYDomain: XYDomain, XYTolerance: XYTolerance, cartographicPartitions: cartographicPartitions, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Smoothing Algorithm</para>
		/// </summary>
		public enum AlgorithmEnum 
		{
			/// <summary>
			/// <para>Polynomial Approximation with Exponential Kernel (PAEK)—This is the acronym for Polynomial Approximation with Exponential Kernel. A smoothed polygon that will not pass through the input polygon vertices will be calculated. This is the default.</para>
			/// </summary>
			[GPValue("PAEK")]
			[Description("Polynomial Approximation with Exponential Kernel (PAEK)")]
			PAEK,

			/// <summary>
			/// <para>Bezier interpolation—Bezier curves will be fitted between vertices. The resulting polygons pass through the vertices of the input polygons. This algorithm does not require a tolerance. Bezier curves will be approximated in the output.</para>
			/// </summary>
			[GPValue("BEZIER_INTERPOLATION")]
			[Description("Bezier interpolation")]
			Bezier_interpolation,

		}

		/// <summary>
		/// <para>Preserve endpoint for rings</para>
		/// </summary>
		public enum EndpointOptionEnum 
		{
			/// <summary>
			/// <para>Checked—The endpoint of an isolated polygon ring will be preserved. This is the default.</para>
			/// </summary>
			[GPValue("true")]
			[Description("FIXED_ENDPOINT")]
			FIXED_ENDPOINT,

			/// <summary>
			/// <para>Unchecked—The endpoint of an isolated polygon ring will not be preserved; it will be smoothed.</para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_FIXED")]
			NO_FIXED,

		}

		/// <summary>
		/// <para>Handling Topological Errors</para>
		/// </summary>
		public enum ErrorOptionEnum 
		{
			/// <summary>
			/// <para>Do not check for topological errors—Topological errors will not be identified. This is the default.</para>
			/// </summary>
			[GPValue("NO_CHECK")]
			[Description("Do not check for topological errors")]
			Do_not_check_for_topological_errors,

			/// <summary>
			/// <para>Check and flag topological errors—If topological errors are found, they will be flagged.</para>
			/// </summary>
			[GPValue("FLAG_ERRORS")]
			[Description("Check and flag topological errors")]
			Check_and_flag_topological_errors,

			/// <summary>
			/// <para>Resolve topological errors—If topological errors are found, they will be resolved.</para>
			/// </summary>
			[GPValue("RESOLVE_ERRORS")]
			[Description("Resolve topological errors")]
			Resolve_topological_errors,

		}

#endregion
	}
}
