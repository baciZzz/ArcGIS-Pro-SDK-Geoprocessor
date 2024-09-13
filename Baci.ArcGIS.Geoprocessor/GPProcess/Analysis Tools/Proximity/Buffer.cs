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
	/// <para>Buffer</para>
	/// <para>缓冲区</para>
	/// <para>在输入要素周围某一指定距离内创建缓冲区多边形。</para>
	/// <para>The <see cref="Baci.ArcGIS.Geoprocessor.AnalysisTools.PairwiseBuffer"/> tool provides enhanced functionality or performance</para>
	/// </summary>
	[EnhancedFOP(typeof(Baci.ArcGIS.Geoprocessor.AnalysisTools.PairwiseBuffer))]
	public class Buffer : AbstractGPProcess
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
		public Buffer(object InFeatures, object OutFeatureClass, object BufferDistanceOrField)
		{
			this.InFeatures = InFeatures;
			this.OutFeatureClass = OutFeatureClass;
			this.BufferDistanceOrField = BufferDistanceOrField;
		}

		/// <summary>
		/// <para>Tool Display Name : 缓冲区</para>
		/// </summary>
		public override string DisplayName() => "缓冲区";

		/// <summary>
		/// <para>Tool Name : 缓冲区</para>
		/// </summary>
		public override string ToolName() => "缓冲区";

		/// <summary>
		/// <para>Tool Excute Name : analysis.Buffer</para>
		/// </summary>
		public override string ExcuteName() => "analysis.Buffer";

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
		public override object[] Parameters() => new object[] { InFeatures, OutFeatureClass, BufferDistanceOrField, LineSide!, LineEndType!, DissolveOption!, DissolveField!, Method! };

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
		/// <para>Side Type</para>
		/// <para>指定将在输入要素的哪一侧进行缓冲。 该参数仅支持面和线要素。</para>
		/// <para>全部—对于线，将在线两侧生成缓冲区。 对于面，将在面周围生成缓冲区，并且这些缓冲区将包含并叠加输入要素的区域。 这是默认设置。</para>
		/// <para>左侧—对于线，将在线的拓扑左侧生成缓冲区。 此选项不支持面输入要素。</para>
		/// <para>右—对于线，将在线的拓扑右侧生成缓冲区。 此选项不支持面输入要素。</para>
		/// <para>从缓冲区中排除输入面—对于面，仅在输入面的外部生成缓冲区（输入面内部的区域将在输出缓冲区中被擦除）。 此选项不支持线输入要素。</para>
		/// <para>此可选参数不适用于 Desktop Basic 或 Desktop Standard 许可。</para>
		/// <para><see cref="LineSideEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LineSide { get; set; } = "FULL";

		/// <summary>
		/// <para>End Type</para>
		/// <para>指定线输入要素末端的缓冲区形状。 此参数对于面输入要素无效。</para>
		/// <para>圆形—缓冲区的末端为圆形，即半圆形。 这是默认设置。</para>
		/// <para>平整—缓冲区的末端很平整或者为方形，并且在输入线要素的端点处终止。</para>
		/// <para>此可选参数不适用于 Desktop Basic 或 Desktop Standard 许可。</para>
		/// <para><see cref="LineEndTypeEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? LineEndType { get; set; } = "ROUND";

		/// <summary>
		/// <para>Dissolve Type</para>
		/// <para>指定移除缓冲区重叠要执行的融合类型。</para>
		/// <para>未融合—不考虑重叠，将保持每个要素的独立缓冲区。 这是默认设置。</para>
		/// <para>将全部输出要素融合为一个要素—将所有缓冲区融合为单个要素，从而移除所有重叠。</para>
		/// <para>使用所列字段唯一值或值的组合来融合要素—将融合共享所列字段（传递自输入要素）属性值的所有缓冲区。</para>
		/// <para><see cref="DissolveOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? DissolveOption { get; set; } = "NONE";

		/// <summary>
		/// <para>Dissolve Field(s)</para>
		/// <para>融合输出缓冲区所依据的输入要素的字段列表。 将融合共享所列字段（传递自输入要素）属性值的所有缓冲区。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Float", "Double", "Text", "Date", "OID", "GUID")]
		public object? DissolveField { get; set; }

		/// <summary>
		/// <para>Method</para>
		/// <para>指定是使用平面方法还是测地线方法来创建缓冲区。</para>
		/// <para>平面—如果输入要素位于投影坐标系中，则将创建欧氏缓冲区。 如果输入要素位于地理坐标系中且缓冲距离的单位为线性单位（米、英尺等，而非诸如度之类的角度单位），则会创建测地线缓冲区。 这是默认设置。您可以使用输出坐标系环境设置指定要使用的坐标系。 例如，如果输入要素位于投影坐标系中，您可以将环境设置为地理坐标系，以便创建测地线缓冲区。</para>
		/// <para>测地线（形状保持不变）—无论使用哪种输入坐标系，均使用形状不变的测地线缓冲区方法创建所有缓冲区。</para>
		/// <para><see cref="MethodEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object? Method { get; set; } = "PLANAR";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public Buffer SetEnviroment(object? MDomain = null , double? MResolution = null , double? MTolerance = null , object? XYDomain = null , object? XYResolution = null , object? XYTolerance = null , object? ZDomain = null , object? ZResolution = null , object? ZTolerance = null , object? extent = null , object? geographicTransformations = null , object? outputCoordinateSystem = null , object? outputMFlag = null , object? outputZFlag = null , double? outputZValue = null , object? parallelProcessingFactor = null , object? scratchWorkspace = null , object? workspace = null )
		{
			base.SetEnv(MDomain: MDomain, MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZDomain: ZDomain, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, parallelProcessingFactor: parallelProcessingFactor, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Side Type</para>
		/// </summary>
		public enum LineSideEnum 
		{
			/// <summary>
			/// <para>全部—对于线，将在线两侧生成缓冲区。 对于面，将在面周围生成缓冲区，并且这些缓冲区将包含并叠加输入要素的区域。 这是默认设置。</para>
			/// </summary>
			[GPValue("FULL")]
			[Description("全部")]
			Full,

			/// <summary>
			/// <para>左侧—对于线，将在线的拓扑左侧生成缓冲区。 此选项不支持面输入要素。</para>
			/// </summary>
			[GPValue("LEFT")]
			[Description("左侧")]
			Left,

			/// <summary>
			/// <para>右—对于线，将在线的拓扑右侧生成缓冲区。 此选项不支持面输入要素。</para>
			/// </summary>
			[GPValue("RIGHT")]
			[Description("右")]
			Right,

			/// <summary>
			/// <para>从缓冲区中排除输入面—对于面，仅在输入面的外部生成缓冲区（输入面内部的区域将在输出缓冲区中被擦除）。 此选项不支持线输入要素。</para>
			/// </summary>
			[GPValue("OUTSIDE_ONLY")]
			[Description("从缓冲区中排除输入面")]
			Exclude_the_input_polygon_from_buffer,

		}

		/// <summary>
		/// <para>End Type</para>
		/// </summary>
		public enum LineEndTypeEnum 
		{
			/// <summary>
			/// <para>圆形—缓冲区的末端为圆形，即半圆形。 这是默认设置。</para>
			/// </summary>
			[GPValue("ROUND")]
			[Description("圆形")]
			Round,

			/// <summary>
			/// <para>平整—缓冲区的末端很平整或者为方形，并且在输入线要素的端点处终止。</para>
			/// </summary>
			[GPValue("FLAT")]
			[Description("平整")]
			Flat,

		}

		/// <summary>
		/// <para>Dissolve Type</para>
		/// </summary>
		public enum DissolveOptionEnum 
		{
			/// <summary>
			/// <para>未融合—不考虑重叠，将保持每个要素的独立缓冲区。 这是默认设置。</para>
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
			/// <para>平面—如果输入要素位于投影坐标系中，则将创建欧氏缓冲区。 如果输入要素位于地理坐标系中且缓冲距离的单位为线性单位（米、英尺等，而非诸如度之类的角度单位），则会创建测地线缓冲区。 这是默认设置。您可以使用输出坐标系环境设置指定要使用的坐标系。 例如，如果输入要素位于投影坐标系中，您可以将环境设置为地理坐标系，以便创建测地线缓冲区。</para>
			/// </summary>
			[GPValue("PLANAR")]
			[Description("平面")]
			Planar,

		}

#endregion
	}
}
