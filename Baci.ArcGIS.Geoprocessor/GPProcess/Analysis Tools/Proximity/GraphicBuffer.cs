using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AnalysisTools
{
	/// <summary>
	/// <para>Graphic Buffer</para>
	/// <para>图形缓冲</para>
	/// <para>在输入要素周围某一指定距离内创建缓冲区多边形。 在要素周围生成缓冲区时，多种制图形状对缓冲区末端（端头）和拐角（连接）可用。</para>
	/// </summary>
	public class GraphicBuffer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Features</para>
		/// <para>要进行缓冲的输入点、线或面要素。</para>
		/// </param>
		/// <param name="OutFeatureClass">
		/// <para>Output Feature Class</para>
		/// <para>包含输出缓冲区的要素类。</para>
		/// </param>
		/// <param name="BufferDistanceOrField">
		/// <para>Distance [value or field]</para>
		/// <para>与要缓冲的输入要素之间的距离。 该距离可以用表示线性距离的某个值来指定，也可以用输入要素中的某个字段（包含用来对每个要素进行缓冲的距离）来指定。</para>
		/// <para>如果未指定线性单位或输入了“未知”，则将使用输入要素空间参考的线性单位。</para>
		/// </param>
		public GraphicBuffer(object InFeatures, object OutFeatureClass, object BufferDistanceOrField)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.BufferDistanceOrField = BufferDistanceOrField;
		}

		/// <summary>
		/// <para>Tool Display Name : 图形缓冲</para>
		/// </summary>
		public override string DisplayName() => "图形缓冲";

		/// <summary>
		/// <para>Tool Name : GraphicBuffer</para>
		/// </summary>
		public override string ToolName() => "GraphicBuffer";

		/// <summary>
		/// <para>Tool Excute Name : analysis.GraphicBuffer</para>
		/// </summary>
		public override string ExcuteName() => "analysis.GraphicBuffer";

		/// <summary>
		/// <para>Toolbox Display Name : Analysis Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Analysis Tools";

		/// <summary>
		/// <para>Toolbox Alise : analysis</para>
		/// </summary>
		public override string ToolboxAlise() => "analysis";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "MDomain", "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZDomain", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "parallelProcessingFactor", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, BufferDistanceOrField, LineCaps!, LineJoins!, MiterLimit!, MaxDeviation! };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要进行缓冲的输入点、线或面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>包含输出缓冲区的要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureClass { get; set; }

		/// <summary>
		/// <para>Distance [value or field]</para>
		/// <para>与要缓冲的输入要素之间的距离。 该距离可以用表示线性距离的某个值来指定，也可以用输入要素中的某个字段（包含用来对每个要素进行缓冲的距离）来指定。</para>
		/// <para>如果未指定线性单位或输入了“未知”，则将使用输入要素空间参考的线性单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object BufferDistanceOrField { get; set; }

		/// <summary>
		/// <para>Caps Type</para>
		/// <para>指定将要进行缓冲的输入要素的端头（末端）类型。 该参数仅支持点和面要素。</para>
		/// <para>正方形—输入段末端周围的输出缓冲区将具有方形端头。 这是默认设置。</para>
		/// <para>平端头—输出缓冲区的端头将垂直于输入段末端。</para>
		/// <para>圆形—输入段末端的输出缓冲区将具有圆形端头。</para>
		/// <para><see cref="LineCapsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LineCaps { get; set; } = "SQUARE";

		/// <summary>
		/// <para>Join Type</para>
		/// <para>两条线段连接拐角处的缓冲区的形状。 该参数仅支持线和面要素。</para>
		/// <para>尖头斜接—在拐角周围生成方形或尖角形状的输出缓冲区要素。 例如，方形输入面要素具有方形缓冲区要素。 这是默认设置。</para>
		/// <para>平头斜接—内拐角的输出缓冲区要素将为方形，而垂直于拐角最远点的外拐角将被切掉。</para>
		/// <para>圆形—内拐角的输出缓冲区要素为方形，而外拐角则为圆形。</para>
		/// <para><see cref="LineJoinsEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LineJoins { get; set; } = "MITER";

		/// <summary>
		/// <para>Miter Limit</para>
		/// <para>当线段相交呈锐角且指定了斜接角连接类型时，可使用该参数来控制缓冲输出的锐角如何逐渐变为点。 某些情况下，当使用斜接角连接类型时，两条线连接形成的外角会非常大。 这可能会导致拐角点的延伸超出预期。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MiterLimit { get; set; } = "10";

		/// <summary>
		/// <para>Maximum Offset Deviation</para>
		/// <para>输出缓冲区面边界将从实际理想缓冲区边界偏移的最大距离。 实际缓冲区边界为曲线，输出面边界为增密折线。 可以使用此参数来控制面边界与实际缓冲区边界的近似程度。</para>
		/// <para>如果此参数未设置或设置为 0，则工具将确定最大偏差。 建议您使用默认值。 造成工具或后续分析性能下降的原因可能为使用的最大偏移偏差值过小。</para>
		/// <para>有关详细信息，请参阅增密工具文档中的最大偏移偏差参数信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object? MaxDeviation { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GraphicBuffer SetEnviroment(object? MDomain = null, double? MResolution = null, double? MTolerance = null, object? XYDomain = null, object? XYResolution = null, object? XYTolerance = null, object? ZDomain = null, object? ZResolution = null, object? ZTolerance = null, object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? outputMFlag = null, object? outputZFlag = null, double? outputZValue = null, object? parallelProcessingFactor = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Caps Type</para>
		/// </summary>
		public enum LineCapsEnum 
		{
			/// <summary>
			/// <para>正方形—输入段末端周围的输出缓冲区将具有方形端头。 这是默认设置。</para>
			/// </summary>
			[GPValue("SQUARE")]
			[Description("正方形")]
			Square,

			/// <summary>
			/// <para>平端头—输出缓冲区的端头将垂直于输入段末端。</para>
			/// </summary>
			[GPValue("BUTT")]
			[Description("平端头")]
			Butt,

			/// <summary>
			/// <para>圆形—输入段末端的输出缓冲区将具有圆形端头。</para>
			/// </summary>
			[GPValue("ROUND")]
			[Description("圆形")]
			Round,

		}

		/// <summary>
		/// <para>Join Type</para>
		/// </summary>
		public enum LineJoinsEnum 
		{
			/// <summary>
			/// <para>尖头斜接—在拐角周围生成方形或尖角形状的输出缓冲区要素。 例如，方形输入面要素具有方形缓冲区要素。 这是默认设置。</para>
			/// </summary>
			[GPValue("MITER")]
			[Description("尖头斜接")]
			Miter,

			/// <summary>
			/// <para>平头斜接—内拐角的输出缓冲区要素将为方形，而垂直于拐角最远点的外拐角将被切掉。</para>
			/// </summary>
			[GPValue("BEVEL")]
			[Description("平头斜接")]
			Bevel,

			/// <summary>
			/// <para>圆形—内拐角的输出缓冲区要素为方形，而外拐角则为圆形。</para>
			/// </summary>
			[GPValue("ROUND")]
			[Description("圆形")]
			Round,

		}

#endregion
	}
}
