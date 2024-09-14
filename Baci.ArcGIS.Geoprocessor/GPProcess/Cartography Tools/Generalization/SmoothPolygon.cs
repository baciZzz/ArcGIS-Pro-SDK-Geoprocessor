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
	/// <para>平滑面</para>
	/// <para>平滑面轮廓中的尖角以改善美学或制图质量。</para>
	/// </summary>
	public class SmoothPolygon : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要对其进行平滑处理的面要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>要创建的输出面要素类。</para>
		/// </param>
		/// <param name="Algorithm">
		/// <para>Smoothing Algorithm</para>
		/// <para>指定平滑算法。</para>
		/// <para>指数核的多项式近似 (PAEK)—此为 Polynomial Approximation with Exponential Kernel（指数核的多项式近似）的首字母缩略词。 将计算不经过输入面折点的平滑面。 这是默认设置。</para>
		/// <para>贝塞尔插值—拟合折点间的贝塞尔曲线。 生成的面将经过输入面的折点。 该算法不需要容差。 在输出中，将创建近似的贝塞尔曲线。</para>
		/// <para><see cref="AlgorithmEnum"/></para>
		/// </param>
		/// <param name="Tolerance">
		/// <para>Smoothing Tolerance</para>
		/// <para>指数核的多项式近似 (PAEK) 算法使用的容差。 必须指定一个容差，且值必须大于零。 可以选择首选单位；默认为要素单位。 使用贝塞尔插值法时，该参数将不可用。</para>
		/// </param>
		public SmoothPolygon(object InFeatures, object OutFeatureClass, object Algorithm, object Tolerance)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.Algorithm = Algorithm;
			this.Tolerance = Tolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : 平滑面</para>
		/// </summary>
		public override string DisplayName() => "平滑面";

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
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, Algorithm, Tolerance, EndpointOption, ErrorOption, InBarriers };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要对其进行平滑处理的面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>要创建的输出面要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Smoothing Algorithm</para>
		/// <para>指定平滑算法。</para>
		/// <para>指数核的多项式近似 (PAEK)—此为 Polynomial Approximation with Exponential Kernel（指数核的多项式近似）的首字母缩略词。 将计算不经过输入面折点的平滑面。 这是默认设置。</para>
		/// <para>贝塞尔插值—拟合折点间的贝塞尔曲线。 生成的面将经过输入面的折点。 该算法不需要容差。 在输出中，将创建近似的贝塞尔曲线。</para>
		/// <para><see cref="AlgorithmEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Algorithm { get; set; } = "PAEK";

		/// <summary>
		/// <para>Smoothing Tolerance</para>
		/// <para>指数核的多项式近似 (PAEK) 算法使用的容差。 必须指定一个容差，且值必须大于零。 可以选择首选单位；默认为要素单位。 使用贝塞尔插值法时，该参数将不可用。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object Tolerance { get; set; }

		/// <summary>
		/// <para>Preserve endpoint for rings</para>
		/// <para>这是一个不再使用的旧参数。 之前曾将其用于指定是否保留孤立面环的端点。 为了脚本和模型的兼容性，工具语法中仍然包含此参数，但其已从工具对话框中隐藏。</para>
		/// <para>指定是否保留孤立面环的端点。 此选项仅可用于 PAEK 算法。</para>
		/// <para>选中 - 将保留孤立面环的端点。 这是默认设置。</para>
		/// <para>未选中 - 不保留孤立面环的端点，将对其进行平滑处理。</para>
		/// <para><see cref="EndpointOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object EndpointOption { get; set; } = "true";

		/// <summary>
		/// <para>Handling Topological Errors</para>
		/// <para>指定如何处理拓扑错误（可能是在该过程中引发的，如线的交叉或重叠）。</para>
		/// <para>不检查拓扑错误—不会识别拓扑错误。 这是默认设置。</para>
		/// <para>检查并标记拓扑错误—标记拓扑错误（如果发现拓扑错误）。</para>
		/// <para>解决拓扑错误—解决拓扑错误（如果发现拓扑错误）。</para>
		/// <para><see cref="ErrorOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object ErrorOption { get; set; } = "NO_CHECK";

		/// <summary>
		/// <para>Input Barrier Layers</para>
		/// <para>包含将充当平滑障碍的要素的输入。 生成的平滑面不会接触或越过障碍要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object InBarriers { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SmoothPolygon SetEnviroment(object MDomain = null, object XYDomain = null, object XYTolerance = null, object cartographicPartitions = null, object extent = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, object scratchWorkspace = null, object workspace = null)
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
			/// <para>指数核的多项式近似 (PAEK)—此为 Polynomial Approximation with Exponential Kernel（指数核的多项式近似）的首字母缩略词。 将计算不经过输入面折点的平滑面。 这是默认设置。</para>
			/// </summary>
			[GPValue("PAEK")]
			[Description("指数核的多项式近似 (PAEK)")]
			PAEK,

			/// <summary>
			/// <para>贝塞尔插值—拟合折点间的贝塞尔曲线。 生成的面将经过输入面的折点。 该算法不需要容差。 在输出中，将创建近似的贝塞尔曲线。</para>
			/// </summary>
			[GPValue("BEZIER_INTERPOLATION")]
			[Description("贝塞尔插值")]
			Bezier_interpolation,

		}

		/// <summary>
		/// <para>Preserve endpoint for rings</para>
		/// </summary>
		public enum EndpointOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FIXED_ENDPOINT")]
			FIXED_ENDPOINT,

			/// <summary>
			/// <para></para>
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
			/// <para>不检查拓扑错误—不会识别拓扑错误。 这是默认设置。</para>
			/// </summary>
			[GPValue("NO_CHECK")]
			[Description("不检查拓扑错误")]
			Do_not_check_for_topological_errors,

			/// <summary>
			/// <para>检查并标记拓扑错误—标记拓扑错误（如果发现拓扑错误）。</para>
			/// </summary>
			[GPValue("FLAG_ERRORS")]
			[Description("检查并标记拓扑错误")]
			Check_and_flag_topological_errors,

			/// <summary>
			/// <para>解决拓扑错误—解决拓扑错误（如果发现拓扑错误）。</para>
			/// </summary>
			[GPValue("RESOLVE_ERRORS")]
			[Description("解决拓扑错误")]
			Resolve_topological_errors,

		}

#endregion
	}
}
