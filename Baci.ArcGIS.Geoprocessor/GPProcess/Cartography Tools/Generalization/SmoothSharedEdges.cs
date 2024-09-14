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
	/// <para>平滑共享边</para>
	/// <para>可平滑输入要素的边，对于与其他要素共享的边，可同时保持与这些边的拓扑关系。</para>
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
		/// <para>要进行平滑的线或面。</para>
		/// </param>
		/// <param name="Algorithm">
		/// <para>Smoothing Algorithm</para>
		/// <para>指定平滑算法。</para>
		/// <para>指数核的多项式近似 (PAEK)— 可以计算不经过输入面折点的平滑面。Polynomial Approximation with Exponential Kernel（指数核的多项式近似）的首字母缩略词。这是默认设置。</para>
		/// <para>贝塞尔插值—拟合折点间的贝塞尔曲线。生成的面将经过输入面的折点。该算法不需要容差。在输出中，将创建近似的贝塞尔曲线。</para>
		/// <para><see cref="AlgorithmEnum"/></para>
		/// </param>
		/// <param name="Tolerance">
		/// <para>Smoothing Tolerance</para>
		/// <para>用于确定平滑程度。可以指定单位，如果未指定单位，则将使用输入单位。仅用于 PAEK 算法。如果选择贝塞尔插值，则工具对话框中将不显示此参数，并且必须在脚本中使用值 0。</para>
		/// </param>
		public SmoothSharedEdges(object InFeatures, object Algorithm, object Tolerance)
		{
			this.InFeatures = InFeatures;
			this.Algorithm = Algorithm;
			this.Tolerance = Tolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : 平滑共享边</para>
		/// </summary>
		public override string DisplayName() => "平滑共享边";

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
		public override object[] Parameters() => new object[] { InFeatures, Algorithm, Tolerance, SharedEdgeFeatures, InBarriers, OutFeatureClass, OutSharedEdgeFeatureClass };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要进行平滑的线或面。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Smoothing Algorithm</para>
		/// <para>指定平滑算法。</para>
		/// <para>指数核的多项式近似 (PAEK)— 可以计算不经过输入面折点的平滑面。Polynomial Approximation with Exponential Kernel（指数核的多项式近似）的首字母缩略词。这是默认设置。</para>
		/// <para>贝塞尔插值—拟合折点间的贝塞尔曲线。生成的面将经过输入面的折点。该算法不需要容差。在输出中，将创建近似的贝塞尔曲线。</para>
		/// <para><see cref="AlgorithmEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Algorithm { get; set; } = "PAEK";

		/// <summary>
		/// <para>Smoothing Tolerance</para>
		/// <para>用于确定平滑程度。可以指定单位，如果未指定单位，则将使用输入单位。仅用于 PAEK 算法。如果选择贝塞尔插值，则工具对话框中将不显示此参数，并且必须在脚本中使用值 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object Tolerance { get; set; }

		/// <summary>
		/// <para>Shared Edge Features</para>
		/// <para>将沿与输入要素共享的边进行平滑的线要素或面要素。将不会对其他边进行平滑。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon", "Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object SharedEdgeFeatures { get; set; }

		/// <summary>
		/// <para>Input Barrier Layers</para>
		/// <para>作为障碍进行平滑的点、线、或面要素。平滑要素不会与障碍要素接触或相交。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object InBarriers { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
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
		public SmoothSharedEdges SetEnviroment(object cartographicPartitions = null)
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
			/// <para>指数核的多项式近似 (PAEK)— 可以计算不经过输入面折点的平滑面。Polynomial Approximation with Exponential Kernel（指数核的多项式近似）的首字母缩略词。这是默认设置。</para>
			/// </summary>
			[GPValue("PAEK")]
			[Description("指数核的多项式近似 (PAEK)")]
			PAEK,

			/// <summary>
			/// <para>贝塞尔插值—拟合折点间的贝塞尔曲线。生成的面将经过输入面的折点。该算法不需要容差。在输出中，将创建近似的贝塞尔曲线。</para>
			/// </summary>
			[GPValue("BEZIER_INTERPOLATION")]
			[Description("贝塞尔插值")]
			Bezier_interpolation,

		}

#endregion
	}
}
