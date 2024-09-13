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
	/// <para>简化共享边</para>
	/// <para>可简化输入要素的边，对于与其他要素共享的边，可同时保持与这些边的拓扑关系。</para>
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
		/// <para>要进行简化的线或面。</para>
		/// </param>
		/// <param name="Algorithm">
		/// <para>Simplification Algorithm</para>
		/// <para>用于指定简化算法。</para>
		/// <para>保留关键点（道格拉斯-普克）—保留构成面轮廓的基本形状的关键点，而移除所有其他点（道格拉斯-普克）。这是默认设置。</para>
		/// <para>保留关键折弯 (Wang-Müller)— 保留线中的关键折弯，并移除多余折弯 (Wang-Müller)。</para>
		/// <para>保留加权有效面积 (Zhou-Jones)—保留形成有效三角形面积的折点，这些面积已根据三角形形状进行了加权 (Zhou-Jones)。</para>
		/// <para>保留有效面积 (Visvalingam-Whyatt)— 保留形成有效三角形面积的折点 (Visvalingam-Whyatt)。</para>
		/// <para><see cref="AlgorithmEnum"/></para>
		/// </param>
		/// <param name="Tolerance">
		/// <para>Simplification Tolerance</para>
		/// <para>用于确定简化程度。如果未指定单位，则将使用输入单位。</para>
		/// <para>对于保留关键点（道格拉斯-普克）算法，容差表示每个折点与新创建的线之间的最大允许垂直距离。</para>
		/// <para>对于保留关键折弯 (Wang-Müller) 算法，容差是近似于有效折弯的圆的直径。</para>
		/// <para>对于保留加权有效面积 (Zhou-Jones) 算法，容差面积是由三个相邻折点定义的有效三角形的面积。三角形越偏离等边三角形，则它的重量越大，被移除的可能性越小。</para>
		/// <para>对于保留有效面积 (Visvalingam-Whyatt) 算法，容差面积是由三个相邻折点定义的有效三角形的面积。</para>
		/// </param>
		public SimplifySharedEdges(object InFeatures, object Algorithm, object Tolerance)
		{
			this.InFeatures = InFeatures;
			this.Algorithm = Algorithm;
			this.Tolerance = Tolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : 简化共享边</para>
		/// </summary>
		public override string DisplayName() => "简化共享边";

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
		/// <para>要进行简化的线或面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Simplification Algorithm</para>
		/// <para>用于指定简化算法。</para>
		/// <para>保留关键点（道格拉斯-普克）—保留构成面轮廓的基本形状的关键点，而移除所有其他点（道格拉斯-普克）。这是默认设置。</para>
		/// <para>保留关键折弯 (Wang-Müller)— 保留线中的关键折弯，并移除多余折弯 (Wang-Müller)。</para>
		/// <para>保留加权有效面积 (Zhou-Jones)—保留形成有效三角形面积的折点，这些面积已根据三角形形状进行了加权 (Zhou-Jones)。</para>
		/// <para>保留有效面积 (Visvalingam-Whyatt)— 保留形成有效三角形面积的折点 (Visvalingam-Whyatt)。</para>
		/// <para><see cref="AlgorithmEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Algorithm { get; set; } = "POINT_REMOVE";

		/// <summary>
		/// <para>Simplification Tolerance</para>
		/// <para>用于确定简化程度。如果未指定单位，则将使用输入单位。</para>
		/// <para>对于保留关键点（道格拉斯-普克）算法，容差表示每个折点与新创建的线之间的最大允许垂直距离。</para>
		/// <para>对于保留关键折弯 (Wang-Müller) 算法，容差是近似于有效折弯的圆的直径。</para>
		/// <para>对于保留加权有效面积 (Zhou-Jones) 算法，容差面积是由三个相邻折点定义的有效三角形的面积。三角形越偏离等边三角形，则它的重量越大，被移除的可能性越小。</para>
		/// <para>对于保留有效面积 (Visvalingam-Whyatt) 算法，容差面积是由三个相邻折点定义的有效三角形的面积。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object Tolerance { get; set; }

		/// <summary>
		/// <para>Shared Edge Features</para>
		/// <para>将沿与输入要素共享的边进行简化的线要素或面要素。将不会对其他边进行简化。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object SharedEdgeFeatures { get; set; }

		/// <summary>
		/// <para>Minimum Area</para>
		/// <para>要保留的面的最小面积。默认值为零，即保留所有面。可以指定单位，如果未指定单位，则将使用输入单位。此参数仅当至少其中一个输入为面要素类时可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPArealUnit()]
		public object MinimumArea { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Input Barrier Layers</para>
		/// <para>作为障碍进行简化的点、线、或面要素。简化要素不会与障碍要素接触或相交。</para>
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
		public SimplifySharedEdges SetEnviroment(object cartographicPartitions = null )
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
			/// <para>保留关键点（道格拉斯-普克）—保留构成面轮廓的基本形状的关键点，而移除所有其他点（道格拉斯-普克）。这是默认设置。</para>
			/// </summary>
			[GPValue("POINT_REMOVE")]
			[Description("保留关键点（道格拉斯-普克）")]
			POINT_REMOVE,

			/// <summary>
			/// <para>保留关键折弯 (Wang-Müller)— 保留线中的关键折弯，并移除多余折弯 (Wang-Müller)。</para>
			/// </summary>
			[GPValue("BEND_SIMPLIFY")]
			[Description("保留关键折弯 (Wang-Müller)")]
			BEND_SIMPLIFY,

			/// <summary>
			/// <para>保留加权有效面积 (Zhou-Jones)—保留形成有效三角形面积的折点，这些面积已根据三角形形状进行了加权 (Zhou-Jones)。</para>
			/// </summary>
			[GPValue("WEIGHTED_AREA")]
			[Description("保留加权有效面积 (Zhou-Jones)")]
			WEIGHTED_AREA,

			/// <summary>
			/// <para>保留有效面积 (Visvalingam-Whyatt)— 保留形成有效三角形面积的折点 (Visvalingam-Whyatt)。</para>
			/// </summary>
			[GPValue("EFFECTIVE_AREA")]
			[Description("保留有效面积 (Visvalingam-Whyatt)")]
			EFFECTIVE_AREA,

		}

#endregion
	}
}
