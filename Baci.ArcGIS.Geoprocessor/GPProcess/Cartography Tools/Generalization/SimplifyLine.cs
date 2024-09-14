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
	/// <para>Simplify Line</para>
	/// <para>简化线</para>
	/// <para>在不改变基本几何形状的情况下，通过移除相对多余的折点来简化线。</para>
	/// </summary>
	public class SimplifyLine : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要简化的输入线要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>简化后的输出线要素类。 其中包含输入要素类中的所有字段。 输出线要素类具有正确的拓扑。 该工具不会引入拓扑错误，但输入数据中的拓扑错误会在输出线要素类中标记出来。 输出要素类包括含有相应输入要素 ID 和输入拓扑错误或差异的两个附加字段：InLine_FID 和 SimLnFlag。 SimLnFlag 值 1 表示存在输入拓扑错误；值 0（零）表示不存在输入错误。</para>
		/// </param>
		/// <param name="Algorithm">
		/// <para>Simplification Algorithm</para>
		/// <para>指定线的简化算法。</para>
		/// <para>保留关键点（道格拉斯-普克）—保留构成线的基本形状的关键点，并移除所有其他点（道格拉斯-普克）。此为默认设置。</para>
		/// <para>保留关键折弯 (Wang-Müller)—保留线中的关键折弯，并移除多余折弯 (Wang-Müller)。</para>
		/// <para>保留加权有效面积 (Zhou-Jones)—保留形成有效三角形面积的折点，这些面积已根据三角形形状进行了加权 (Zhou-Jones)。</para>
		/// <para>保留有效面积 (Visvalingam-Whyatt)—保留形成有效三角形面积的折点 (Visvalingam-Whyatt)。</para>
		/// <para><see cref="AlgorithmEnum"/></para>
		/// </param>
		/// <param name="Tolerance">
		/// <para>Simplification Tolerance</para>
		/// <para>容差用于确定简化程度。 可以选择首选单位；否则，将使用输入单位。 MinSimpTol 和 MaxSimpTol 字段将被添加至输出以存储在执行处理时使用过的容差。</para>
		/// <para>对于保留关键点（道格拉斯-普克）算法，容差表示每个折点与新创建的线之间的最大允许垂直距离。</para>
		/// <para>对于保留关键折弯 (Wang-Müller) 算法，容差是近似于有效折弯的圆的直径。</para>
		/// <para>对于保留加权有效面积 (Zhou-Jones) 算法，容差面积是由三个相邻折点定义的有效三角形的面积。 三角形越偏离等边三角形，则它的重量越大，被移除的可能性越小。</para>
		/// <para>对于保留有效面积 (Visvalingam-Whyatt) 算法，容差面积是由三个相邻折点定义的有效三角形的面积。</para>
		/// </param>
		public SimplifyLine(object InFeatures, object OutFeatureClass, object Algorithm, object Tolerance)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.Algorithm = Algorithm;
			this.Tolerance = Tolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : 简化线</para>
		/// </summary>
		public override string DisplayName() => "简化线";

		/// <summary>
		/// <para>Tool Name : SimplifyLine</para>
		/// </summary>
		public override string ToolName() => "SimplifyLine";

		/// <summary>
		/// <para>Tool Excute Name : cartography.SimplifyLine</para>
		/// </summary>
		public override string ExcuteName() => "cartography.SimplifyLine";

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
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, Algorithm, Tolerance, ErrorResolvingOption, CollapsedPointOption, ErrorCheckingOption, OutPointFeatureClass, InBarriers };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要简化的输入线要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>简化后的输出线要素类。 其中包含输入要素类中的所有字段。 输出线要素类具有正确的拓扑。 该工具不会引入拓扑错误，但输入数据中的拓扑错误会在输出线要素类中标记出来。 输出要素类包括含有相应输入要素 ID 和输入拓扑错误或差异的两个附加字段：InLine_FID 和 SimLnFlag。 SimLnFlag 值 1 表示存在输入拓扑错误；值 0（零）表示不存在输入错误。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Simplification Algorithm</para>
		/// <para>指定线的简化算法。</para>
		/// <para>保留关键点（道格拉斯-普克）—保留构成线的基本形状的关键点，并移除所有其他点（道格拉斯-普克）。此为默认设置。</para>
		/// <para>保留关键折弯 (Wang-Müller)—保留线中的关键折弯，并移除多余折弯 (Wang-Müller)。</para>
		/// <para>保留加权有效面积 (Zhou-Jones)—保留形成有效三角形面积的折点，这些面积已根据三角形形状进行了加权 (Zhou-Jones)。</para>
		/// <para>保留有效面积 (Visvalingam-Whyatt)—保留形成有效三角形面积的折点 (Visvalingam-Whyatt)。</para>
		/// <para><see cref="AlgorithmEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Algorithm { get; set; } = "POINT_REMOVE";

		/// <summary>
		/// <para>Simplification Tolerance</para>
		/// <para>容差用于确定简化程度。 可以选择首选单位；否则，将使用输入单位。 MinSimpTol 和 MaxSimpTol 字段将被添加至输出以存储在执行处理时使用过的容差。</para>
		/// <para>对于保留关键点（道格拉斯-普克）算法，容差表示每个折点与新创建的线之间的最大允许垂直距离。</para>
		/// <para>对于保留关键折弯 (Wang-Müller) 算法，容差是近似于有效折弯的圆的直径。</para>
		/// <para>对于保留加权有效面积 (Zhou-Jones) 算法，容差面积是由三个相邻折点定义的有效三角形的面积。 三角形越偏离等边三角形，则它的重量越大，被移除的可能性越小。</para>
		/// <para>对于保留有效面积 (Visvalingam-Whyatt) 算法，容差面积是由三个相邻折点定义的有效三角形的面积。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPLinearUnit()]
		public object Tolerance { get; set; }

		/// <summary>
		/// <para>Resolve topological errors</para>
		/// <para>这是一个不再使用的旧参数。 以前使用该参数来指示如何解决可能在处理过程中引入的拓扑错误。 为了脚本和模型的兼容性，工具语法中仍然包含此参数，但其已从工具对话框中隐藏。</para>
		/// <para><see cref="ErrorResolvingOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ErrorResolvingOption { get; set; } = "true";

		/// <summary>
		/// <para>Keep collapsed points</para>
		/// <para>指定是否创建输出点要素类以存储小于空间容差的所有线的端点。 已派生点输出；将使用与输出要素类参数相同的名称和位置，但带有 _Pnt 后缀。</para>
		/// <para>选中 - 将创建派生的输出点要素类以存储折叠的零长度线的端点。 这是默认设置。</para>
		/// <para>未选中 - 不创建派生的输出点要素类。</para>
		/// <para><see cref="CollapsedPointOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object CollapsedPointOption { get; set; } = "true";

		/// <summary>
		/// <para>Check for topological errors</para>
		/// <para>这是一个不再使用的旧参数。 以前使用该参数来指示如何处理可能在处理过程中引入的拓扑错误。 为了脚本和模型的兼容性，工具语法中仍然包含此参数，但其已从工具对话框中隐藏。</para>
		/// <para><see cref="ErrorCheckingOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object ErrorCheckingOption { get; set; } = "true";

		/// <summary>
		/// <para>Lines Collapsed To Zero Length</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object OutPointFeatureClass { get; set; } = "output_feature_class_Pnt";

		/// <summary>
		/// <para>Input Barrier Layers</para>
		/// <para>包含充当简化中障碍的要素的输入。 生成的简化线不会接触或越过障碍要素。 例如，在简化等值线时，将点高度要素输入作为障碍可确保简化等值线不会越过这些点进行简化。 输出不会违反测量点高度所述的高程。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object InBarriers { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SimplifyLine SetEnviroment(object MDomain = null, object XYDomain = null, object XYTolerance = null, object cartographicPartitions = null, object extent = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(MDomain: MDomain, XYDomain: XYDomain, XYTolerance: XYTolerance, cartographicPartitions: cartographicPartitions, extent: extent, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Simplification Algorithm</para>
		/// </summary>
		public enum AlgorithmEnum 
		{
			/// <summary>
			/// <para>保留关键点（道格拉斯-普克）—保留构成线的基本形状的关键点，并移除所有其他点（道格拉斯-普克）。此为默认设置。</para>
			/// </summary>
			[GPValue("POINT_REMOVE")]
			[Description("保留关键点（道格拉斯-普克）")]
			POINT_REMOVE,

			/// <summary>
			/// <para>保留关键折弯 (Wang-Müller)—保留线中的关键折弯，并移除多余折弯 (Wang-Müller)。</para>
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
			/// <para>保留有效面积 (Visvalingam-Whyatt)—保留形成有效三角形面积的折点 (Visvalingam-Whyatt)。</para>
			/// </summary>
			[GPValue("EFFECTIVE_AREA")]
			[Description("保留有效面积 (Visvalingam-Whyatt)")]
			EFFECTIVE_AREA,

		}

		/// <summary>
		/// <para>Resolve topological errors</para>
		/// </summary>
		public enum ErrorResolvingOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("RESOLVE_ERRORS")]
			RESOLVE_ERRORS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("FLAG_ERRORS")]
			FLAG_ERRORS,

		}

		/// <summary>
		/// <para>Keep collapsed points</para>
		/// </summary>
		public enum CollapsedPointOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("KEEP_COLLAPSED_POINTS")]
			KEEP_COLLAPSED_POINTS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_KEEP")]
			NO_KEEP,

		}

		/// <summary>
		/// <para>Check for topological errors</para>
		/// </summary>
		public enum ErrorCheckingOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("CHECK")]
			CHECK,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("NO_CHECK")]
			NO_CHECK,

		}

#endregion
	}
}
