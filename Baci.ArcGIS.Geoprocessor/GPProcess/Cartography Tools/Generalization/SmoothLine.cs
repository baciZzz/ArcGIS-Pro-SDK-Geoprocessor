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
	/// <para>Smooth Line</para>
	/// <para>平滑线</para>
	/// <para>平滑线中的尖角以改善美学或制图质量。</para>
	/// </summary>
	public class SmoothLine : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要平滑的线要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>要创建的输出要素类。</para>
		/// </param>
		/// <param name="Algorithm">
		/// <para>Smoothing Algorithm</para>
		/// <para>指定平滑算法。</para>
		/// <para>指数核的多项式近似 (PAEK)—此为 Polynomial Approximation with Exponential Kernel（指数核的多项式近似）的首字母缩略词。 该方法可以计算不会经过输入线折点的平滑线。 这是默认设置。</para>
		/// <para>贝塞尔插值—拟合折点间的贝塞尔曲线。 生成的线将经过输入线的折点。 该算法不需要容差。 在输出中，将创建近似的贝塞尔曲线。</para>
		/// <para><see cref="AlgorithmEnum"/></para>
		/// </param>
		/// <param name="Tolerance">
		/// <para>Smoothing Tolerance</para>
		/// <para>指数核的多项式近似 (PAEK) 算法使用的容差。 必须指定一个容差，且值必须大于零。 可以选择首选单位；默认为要素单位。 使用贝塞尔插值法时，该参数将不可用。</para>
		/// </param>
		public SmoothLine(object InFeatures, object OutFeatureClass, object Algorithm, object Tolerance)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.Algorithm = Algorithm;
			this.Tolerance = Tolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : 平滑线</para>
		/// </summary>
		public override string DisplayName() => "平滑线";

		/// <summary>
		/// <para>Tool Name : SmoothLine</para>
		/// </summary>
		public override string ToolName() => "SmoothLine";

		/// <summary>
		/// <para>Tool Excute Name : cartography.SmoothLine</para>
		/// </summary>
		public override string ExcuteName() => "cartography.SmoothLine";

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
		/// <para>要平滑的线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>要创建的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Smoothing Algorithm</para>
		/// <para>指定平滑算法。</para>
		/// <para>指数核的多项式近似 (PAEK)—此为 Polynomial Approximation with Exponential Kernel（指数核的多项式近似）的首字母缩略词。 该方法可以计算不会经过输入线折点的平滑线。 这是默认设置。</para>
		/// <para>贝塞尔插值—拟合折点间的贝塞尔曲线。 生成的线将经过输入线的折点。 该算法不需要容差。 在输出中，将创建近似的贝塞尔曲线。</para>
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
		/// <para>Preserve endpoint for closed lines</para>
		/// <para>这是一个不再使用的旧参数。 之前曾将其用于指定是否保留闭合线的端点。 为了脚本和模型的兼容性，工具语法中仍然包含此参数，但其已从工具对话框中隐藏。</para>
		/// <para>用于指定是否保留闭合线的端点。 此选项仅可用于 PAEK 算法。</para>
		/// <para>选中 - 将保留闭合线的端点。 这是默认设置。</para>
		/// <para>未选中 - 不会保留闭合线的端点，其将被平滑处理。</para>
		/// <para><see cref="EndpointOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? EndpointOption { get; set; } = "true";

		/// <summary>
		/// <para>Handling Topological Errors</para>
		/// <para>指定如何处理拓扑错误（可能是在该过程中引发的，如线的交叉或重叠）。</para>
		/// <para>不检查拓扑错误—不会识别拓扑错误。 这是默认设置。</para>
		/// <para>标记拓扑错误—标记拓扑错误（如果发现拓扑错误）。</para>
		/// <para>解决拓扑错误—解决拓扑错误（如果发现拓扑错误）。</para>
		/// <para><see cref="ErrorOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ErrorOption { get; set; } = "NO_CHECK";

		/// <summary>
		/// <para>Input Barrier Layers</para>
		/// <para>包含将充当平滑障碍的要素的输入。 生成的平滑线不会接触或越过障碍要素。 例如，在平滑等值线时，将点高度要素输入作为障碍可确保平滑等值线不会越过这些点进行平滑。 输出不会违反测量点高度所述的高程。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? InBarriers { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SmoothLine SetEnviroment(object? MDomain = null, object? XYDomain = null, object? XYTolerance = null, object? cartographicPartitions = null, object? extent = null, object? outputCoordinateSystem = null, object? outputMFlag = null, object? outputZFlag = null, double? outputZValue = null, object? scratchWorkspace = null, object? workspace = null)
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
			/// <para>指数核的多项式近似 (PAEK)—此为 Polynomial Approximation with Exponential Kernel（指数核的多项式近似）的首字母缩略词。 该方法可以计算不会经过输入线折点的平滑线。 这是默认设置。</para>
			/// </summary>
			[GPValue("PAEK")]
			[Description("指数核的多项式近似 (PAEK)")]
			PAEK,

			/// <summary>
			/// <para>贝塞尔插值—拟合折点间的贝塞尔曲线。 生成的线将经过输入线的折点。 该算法不需要容差。 在输出中，将创建近似的贝塞尔曲线。</para>
			/// </summary>
			[GPValue("BEZIER_INTERPOLATION")]
			[Description("贝塞尔插值")]
			Bezier_interpolation,

		}

		/// <summary>
		/// <para>Preserve endpoint for closed lines</para>
		/// </summary>
		public enum EndpointOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("FIXED_CLOSED_ENDPOINT")]
			FIXED_CLOSED_ENDPOINT,

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
			/// <para>标记拓扑错误—标记拓扑错误（如果发现拓扑错误）。</para>
			/// </summary>
			[GPValue("FLAG_ERRORS")]
			[Description("标记拓扑错误")]
			Flag_topological_errors,

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
