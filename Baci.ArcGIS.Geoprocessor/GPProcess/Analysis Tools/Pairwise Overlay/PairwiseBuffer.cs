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
	/// <para>Pairwise Buffer</para>
	/// <para>成对缓冲</para>
	/// <para>用于使用并行处理方法在输入要素周围某一指定距离内创建缓冲区多边形。</para>
	/// </summary>
	public class PairwiseBuffer : AbstractGPProcess
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
		/// <para>与要缓冲的输入要素之间的距离。该距离可以用表示线性距离的某个值来指定，也可以用输入要素中的某个字段（包含用来对每个要素进行缓冲的距离）来指定。</para>
		/// <para>如果未指定线性单位或输入了“未知”，则将使用输入要素空间参考的线性单位。</para>
		/// </param>
		public PairwiseBuffer(object InFeatures, object OutFeatureClass, object BufferDistanceOrField)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.BufferDistanceOrField = BufferDistanceOrField;
		}

		/// <summary>
		/// <para>Tool Display Name : 成对缓冲</para>
		/// </summary>
		public override string DisplayName() => "成对缓冲";

		/// <summary>
		/// <para>Tool Name : PairwiseBuffer</para>
		/// </summary>
		public override string ToolName() => "PairwiseBuffer";

		/// <summary>
		/// <para>Tool Excute Name : analysis.PairwiseBuffer</para>
		/// </summary>
		public override string ExcuteName() => "analysis.PairwiseBuffer";

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
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, BufferDistanceOrField, DissolveOption, DissolveField, Method, MaxDeviation };

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
		/// <para>与要缓冲的输入要素之间的距离。该距离可以用表示线性距离的某个值来指定，也可以用输入要素中的某个字段（包含用来对每个要素进行缓冲的距离）来指定。</para>
		/// <para>如果未指定线性单位或输入了“未知”，则将使用输入要素空间参考的线性单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		[GPCompositeDomain()]
		public object BufferDistanceOrField { get; set; }

		/// <summary>
		/// <para>Dissolve Type</para>
		/// <para>指定移除缓冲区重叠要执行的融合操作类型。</para>
		/// <para>未融合—不考虑重叠，将保持每个要素的独立缓冲区。这是默认设置。</para>
		/// <para>将全部输出要素融合为一个要素—将所有缓冲区融合为单个要素，从而移除所有重叠。</para>
		/// <para>使用所列字段唯一值或值的组合来融合要素—将融合共享所列字段（传递自输入要素）属性值的所有缓冲区。</para>
		/// <para><see cref="DissolveOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DissolveOption { get; set; } = "NONE";

		/// <summary>
		/// <para>Dissolve Field(s)</para>
		/// <para>融合输出缓冲区所依据的输入要素的字段列表。将融合共享所列字段（传递自输入要素）属性值的所有缓冲区。</para>
		/// <para>添加字段按钮（仅在 ModelBuilder 中使用）可将预期字段添加到融合字段列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID")]
		public object DissolveField { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>指定用于创建缓冲区的方法是平面方法还是测地线方法。</para>
		/// <para>平面—如果输入要素位于投影坐标系中，则将创建欧氏缓冲区。如果输入要素位于地理坐标系中且缓冲距离的单位为线性单位（米、英尺等，而非诸如度之类的角度单位），则会创建测地线缓冲区。这是默认设置。您可以使用输出坐标系环境设置指定要使用的坐标系。例如，如果输入要素位于投影坐标系中，您可以将环境设置为地理坐标系，以便创建测地线缓冲区。</para>
		/// <para>测地线（形状保持不变）—无论使用哪种输入坐标系，均使用形状不变的测地线缓冲区方法创建所有缓冲区。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Method { get; set; } = "PLANAR";

		/// <summary>
		/// <para>Maximum Offset Deviation</para>
		/// <para>生成的输出缓冲区面边界将从实际缓冲区边界偏移的最大距离。</para>
		/// <para>实际缓冲区边界为曲线。但是，生成面边界为增密折线。可以使用此参数来控制面边界与实际缓冲区边界的近似程度。</para>
		/// <para>如果此参数未设置或设置为 0，则工具将确定最大偏差。建议您使用默认值。造成（工具或后续分析中）系统性能下降的原因可能为使用的最大偏移偏差过小。</para>
		/// <para>有关详细信息，请参阅增密工具文档中的最大偏移偏差参数信息。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPLinearUnit()]
		public object MaxDeviation { get; set; } = "0 Unknown";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public PairwiseBuffer SetEnviroment(object MDomain = null , object MResolution = null , object MTolerance = null , object XYDomain = null , object XYResolution = null , object XYTolerance = null , object ZDomain = null , object ZResolution = null , object ZTolerance = null , object extent = null , object geographicTransformations = null , object outputCoordinateSystem = null , object outputMFlag = null , object outputZFlag = null , object outputZValue = null , object parallelProcessingFactor = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Dissolve Type</para>
		/// </summary>
		public enum DissolveOptionEnum 
		{
			/// <summary>
			/// <para>未融合—不考虑重叠，将保持每个要素的独立缓冲区。这是默认设置。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("未融合")]
			No_Dissolve,

			/// <summary>
			/// <para>将全部输出要素融合为一个要素—将所有缓冲区融合为单个要素，从而移除所有重叠。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("将全部输出要素融合为一个要素")]
			Dissolve_all_output_features_into_a_single_feature,

			/// <summary>
			/// <para>使用所列字段唯一值或值的组合来融合要素—将融合共享所列字段（传递自输入要素）属性值的所有缓冲区。</para>
			/// </summary>
			[GPValue("LIST")]
			[Description("使用所列字段唯一值或值的组合来融合要素")]
			LIST,

		}

		/// <summary>
		/// <para>Method</para>
		/// </summary>
		public enum MethodEnum 
		{
			/// <summary>
			/// <para>测地线（形状保持不变）—无论使用哪种输入坐标系，均使用形状不变的测地线缓冲区方法创建所有缓冲区。</para>
			/// </summary>
			[GPValue("GEODESIC")]
			[Description("测地线（形状保持不变）")]
			GEODESIC,

			/// <summary>
			/// <para>平面—如果输入要素位于投影坐标系中，则将创建欧氏缓冲区。如果输入要素位于地理坐标系中且缓冲距离的单位为线性单位（米、英尺等，而非诸如度之类的角度单位），则会创建测地线缓冲区。这是默认设置。您可以使用输出坐标系环境设置指定要使用的坐标系。例如，如果输入要素位于投影坐标系中，您可以将环境设置为地理坐标系，以便创建测地线缓冲区。</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("平面")]
			Planar,

		}

#endregion
	}
}
