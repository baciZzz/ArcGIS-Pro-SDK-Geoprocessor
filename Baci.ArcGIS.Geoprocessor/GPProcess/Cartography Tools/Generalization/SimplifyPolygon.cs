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
	/// <para>Simplify Polygon</para>
	/// <para>简化面</para>
	/// <para>在不改变基本几何形状的情况下，通过移除相对多余的折点来简化面要素。</para>
	/// </summary>
	public class SimplifyPolygon : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要简化的输入面要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>简化后的输出面要素类。 其中包含输入要素类中的所有字段。 输出面要素类具有正确的拓扑。 该工具不会引入拓扑错误，但输入数据中的拓扑错误会在输出面要素类中标记出来。</para>
		/// <para>输出要素类包括含有相应输入要素 ID 和输入拓扑错误或差异的两个附加字段：InPoly_FID 和 SimPgnFlag。</para>
		/// <para>SimPgnFlag 属性值如下：</para>
		/// <para>SimPgnFlag = 0 表示不存在错误。</para>
		/// <para>SimPgnFlag = 1 表示存在拓扑错误。</para>
		/// <para>SimPgnFlag = 2 表示已被分区分割的要素，该要素经过简化后现在小于最小面积。 该标记可能仅显示在分割要素的一部分上。 这些要素将全部保留在输出要素类中。 仅在使用制图分区环境设置时才会出现此情况。</para>
		/// </param>
		/// <param name="Algorithm">
		/// <para>Simplification Algorithm</para>
		/// <para>指定面简化算法。</para>
		/// <para>保留关键点（道格拉斯-普克）—保留构成面轮廓的基本形状的关键点，而移除所有其他点（道格拉斯-普克）。 这是默认设置。</para>
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
		public SimplifyPolygon(object InFeatures, object OutFeatureClass, object Algorithm, object Tolerance)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.Algorithm = Algorithm;
			this.Tolerance = Tolerance;
		}

		/// <summary>
		/// <para>Tool Display Name : 简化面</para>
		/// </summary>
		public override string DisplayName() => "简化面";

		/// <summary>
		/// <para>Tool Name : SimplifyPolygon</para>
		/// </summary>
		public override string ToolName() => "SimplifyPolygon";

		/// <summary>
		/// <para>Tool Excute Name : cartography.SimplifyPolygon</para>
		/// </summary>
		public override string ExcuteName() => "cartography.SimplifyPolygon";

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
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, Algorithm, Tolerance, MinimumArea!, ErrorOption!, CollapsedPointOption!, OutPointFeatureClass!, InBarriers! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要简化的输入面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polygon")]
		[FeatureType("Simple", "SimpleJunction", "SimpleEdge", "ComplexEdge", "RasterCatalogItem")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>简化后的输出面要素类。 其中包含输入要素类中的所有字段。 输出面要素类具有正确的拓扑。 该工具不会引入拓扑错误，但输入数据中的拓扑错误会在输出面要素类中标记出来。</para>
		/// <para>输出要素类包括含有相应输入要素 ID 和输入拓扑错误或差异的两个附加字段：InPoly_FID 和 SimPgnFlag。</para>
		/// <para>SimPgnFlag 属性值如下：</para>
		/// <para>SimPgnFlag = 0 表示不存在错误。</para>
		/// <para>SimPgnFlag = 1 表示存在拓扑错误。</para>
		/// <para>SimPgnFlag = 2 表示已被分区分割的要素，该要素经过简化后现在小于最小面积。 该标记可能仅显示在分割要素的一部分上。 这些要素将全部保留在输出要素类中。 仅在使用制图分区环境设置时才会出现此情况。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Simplification Algorithm</para>
		/// <para>指定面简化算法。</para>
		/// <para>保留关键点（道格拉斯-普克）—保留构成面轮廓的基本形状的关键点，而移除所有其他点（道格拉斯-普克）。 这是默认设置。</para>
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
		/// <para>Minimum Area</para>
		/// <para>要保留的面的最小面积。 默认值为零，即保留所有面。 可以为指定的值选择首选单位；否则，将使用输入单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPArealUnit()]
		public object? MinimumArea { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Handling Topological Errors</para>
		/// <para>这是一个不再使用的旧参数。 以前使用该参数来指定如何处理可能在处理过程中引入的拓扑错误。 为了脚本和模型的兼容性，工具语法中仍然包含这些参数，但现在这些参数已从工具对话框中隐藏。</para>
		/// <para><see cref="ErrorOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? ErrorOption { get; set; } = "RESOLVE_ERRORS";

		/// <summary>
		/// <para>Keep collapsed points</para>
		/// <para>指定是否创建输出点要素类以存储被移除的面的中心，因为这些面小于最小面积参数值。 已派生点输出；将使用与输出要素类参数相同的名称和位置，但带有 _Pnt 后缀。</para>
		/// <para>选中 - 将创建派生的输出点要素类以存储被移除的面的中心，因为这些面小于最小面积。 这是默认设置。</para>
		/// <para>未选中 - 不创建派生的输出点要素类。</para>
		/// <para><see cref="CollapsedPointOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object? CollapsedPointOption { get; set; } = "true";

		/// <summary>
		/// <para>Polygons Collapsed To Zero Area</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFeatureClass()]
		public object? OutPointFeatureClass { get; set; } = "output_feature_class_Pnt";

		/// <summary>
		/// <para>Input Barrier Layers</para>
		/// <para>包含充当简化中障碍的要素的输入。 生成简化面不会接触障碍要素或与其交叉。 例如，当简化森林覆盖区域时，生成的简化森林面不会穿过被定义为障碍的道路要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		public object? InBarriers { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public SimplifyPolygon SetEnviroment(object? MDomain = null , object? XYDomain = null , object? XYTolerance = null , object? cartographicPartitions = null , object? extent = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , object? scratchWorkspace = null , object? workspace = null )
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
			/// <para>保留关键点（道格拉斯-普克）—保留构成面轮廓的基本形状的关键点，而移除所有其他点（道格拉斯-普克）。 这是默认设置。</para>
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
		/// <para>Handling Topological Errors</para>
		/// </summary>
		public enum ErrorOptionEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("NO_CHECK")]
			[Description("NO_CHECK")]
			NO_CHECK,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("FLAG_ERRORS")]
			[Description("FLAG_ERRORS")]
			FLAG_ERRORS,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("RESOLVE_ERRORS")]
			[Description("RESOLVE_ERRORS")]
			RESOLVE_ERRORS,

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

#endregion
	}
}
