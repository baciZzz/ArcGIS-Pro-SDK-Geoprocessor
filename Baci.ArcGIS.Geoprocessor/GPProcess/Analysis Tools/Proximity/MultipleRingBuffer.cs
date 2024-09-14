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
	/// <para>Multiple Ring Buffer</para>
	/// <para>多环缓冲区</para>
	/// <para>在输入要素周围的指定距离内创建多个缓冲区。 使用缓冲距离值可随意合并和融合这些缓冲区，以便创建非重叠缓冲区。</para>
	/// </summary>
	public class MultipleRingBuffer : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFeatures">
		/// <para>Input Features</para>
		/// <para>要进行缓冲的输入点、线或面要素。</para>
		/// </param>
		/// <param name="OutputFeatureClass">
		/// <para>Output Feature class</para>
		/// <para>含有多个缓冲区的输出要素类。</para>
		/// </param>
		/// <param name="Distances">
		/// <para>Distances</para>
		/// <para>缓冲距离列表。</para>
		/// </param>
		public MultipleRingBuffer(object InputFeatures, object OutputFeatureClass, object Distances)
		{
			this.InputFeatures = InputFeatures;
			this.OutputFeatureClass = OutputFeatureClass;
			this.Distances = Distances;
		}

		/// <summary>
		/// <para>Tool Display Name : 多环缓冲区</para>
		/// </summary>
		public override string DisplayName() => "多环缓冲区";

		/// <summary>
		/// <para>Tool Name : MultipleRingBuffer</para>
		/// </summary>
		public override string ToolName() => "MultipleRingBuffer";

		/// <summary>
		/// <para>Tool Excute Name : analysis.MultipleRingBuffer</para>
		/// </summary>
		public override string ExcuteName() => "analysis.MultipleRingBuffer";

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
		public override string[] ValidEnvironments() => new string[] { "MResolution", "MTolerance", "XYDomain", "XYResolution", "XYTolerance", "ZResolution", "ZTolerance", "extent", "geographicTransformations", "outputCoordinateSystem", "outputMFlag", "outputZFlag", "outputZValue", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFeatures, OutputFeatureClass, Distances, BufferUnit, FieldName, DissolveOption, OutsidePolygonsOnly };

		/// <summary>
		/// <para>Input Features</para>
		/// <para>要进行缓冲的输入点、线或面要素。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InputFeatures { get; set; }

		/// <summary>
		/// <para>Output Feature class</para>
		/// <para>含有多个缓冲区的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutputFeatureClass { get; set; }

		/// <summary>
		/// <para>Distances</para>
		/// <para>缓冲距离列表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object Distances { get; set; }

		/// <summary>
		/// <para>Distance Unit</para>
		/// <para>指定与距离值一起使用的线性单位。</para>
		/// <para>默认值—系统将使用输入要素空间参考的线性单位。 如果已设置了输出坐标系地理处理环境，则将使用环境的线性单位。 如果输入要素的空间参考未知或未定义，则线性单位将被忽略。 这是默认设置。</para>
		/// <para>英寸—将以英寸为单位。</para>
		/// <para>英尺—单位将为英尺。</para>
		/// <para>码—单位将为码。</para>
		/// <para>英里—单位将为英里。</para>
		/// <para>海里—单位将为海里。</para>
		/// <para>毫米—将以毫米为单位。</para>
		/// <para>厘米—将以厘米为单位。</para>
		/// <para>分米—将以分米为单位。</para>
		/// <para>米—单位将为米。</para>
		/// <para>千米—单位将为公里。</para>
		/// <para>十进制度—将以十进制度为单位。</para>
		/// <para>点—将以磅为单位。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object BufferUnit { get; set; } = "Default";

		/// <summary>
		/// <para>Buffer Distance Field Name</para>
		/// <para>输出要素类中的字段名称，其中将存储用于创建每个缓冲区要素的缓冲距离。 默认设置为 distance。 字段将为双精度型。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object FieldName { get; set; } = "distance";

		/// <summary>
		/// <para>Dissolve Option</para>
		/// <para>指定确定是否要像围绕输入要素的环一样融合缓冲区。</para>
		/// <para>非重叠（环）—将像围绕输入要素的环一样（将其视为输入要素周围的圆环）融合缓冲区。 最小缓冲区将覆盖其输入要素加上缓冲距离的区域，后续缓冲区将是围绕最小缓冲区的圆环，该最小缓冲区不覆盖输入要素或较小缓冲区的区域。 相同距离的所有缓冲区都将融合到单个要素中。 这是默认设置。</para>
		/// <para>重叠（圆盘）—不融合缓冲区。 不论是否重叠，都会保存所有缓冲区域。 每个缓冲区均会覆盖其输入要素加上任何较小缓冲区的区域。</para>
		/// <para><see cref="DissolveOptionEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[GPCodedValueDomain()]
		public object DissolveOption { get; set; } = "ALL";

		/// <summary>
		/// <para>Outside Polygons Only</para>
		/// <para>指定缓冲区是否覆盖输入要素。 此参数仅对面输入要素有效。</para>
		/// <para>未选中 - 缓冲区会叠加或覆盖输入要素。 这是默认设置。</para>
		/// <para>选中 - 缓冲区将是围绕输入要素的环，并且不会叠加或覆盖输入要素（输入面内部的区域将从缓冲区中擦除）。</para>
		/// <para><see cref="OutsidePolygonsOnlyEnum"/></para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPBoolean()]
		[GPCodedValueDomain()]
		public object OutsidePolygonsOnly { get; set; } = "false";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MultipleRingBuffer SetEnviroment(object MResolution = null, object MTolerance = null, object XYDomain = null, object XYResolution = null, object XYTolerance = null, object ZResolution = null, object ZTolerance = null, object extent = null, object geographicTransformations = null, object outputCoordinateSystem = null, object outputMFlag = null, object outputZFlag = null, object outputZValue = null, object scratchWorkspace = null, object workspace = null)
		{
			base.SetEnv(MResolution: MResolution, MTolerance: MTolerance, XYDomain: XYDomain, XYResolution: XYResolution, XYTolerance: XYTolerance, ZResolution: ZResolution, ZTolerance: ZTolerance, extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, outputMFlag: outputMFlag, outputZFlag: outputZFlag, outputZValue: outputZValue, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

		#region InnerClass

		/// <summary>
		/// <para>Dissolve Option</para>
		/// </summary>
		public enum DissolveOptionEnum 
		{
			/// <summary>
			/// <para>非重叠（环）—将像围绕输入要素的环一样（将其视为输入要素周围的圆环）融合缓冲区。 最小缓冲区将覆盖其输入要素加上缓冲距离的区域，后续缓冲区将是围绕最小缓冲区的圆环，该最小缓冲区不覆盖输入要素或较小缓冲区的区域。 相同距离的所有缓冲区都将融合到单个要素中。 这是默认设置。</para>
			/// </summary>
			[GPValue("ALL")]
			[Description("非重叠（环）")]
			ALL,

			/// <summary>
			/// <para>重叠（圆盘）—不融合缓冲区。 不论是否重叠，都会保存所有缓冲区域。 每个缓冲区均会覆盖其输入要素加上任何较小缓冲区的区域。</para>
			/// </summary>
			[GPValue("NONE")]
			[Description("重叠（圆盘）")]
			NONE,

		}

		/// <summary>
		/// <para>Outside Polygons Only</para>
		/// </summary>
		public enum OutsidePolygonsOnlyEnum 
		{
			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("true")]
			[Description("OUTSIDE_ONLY")]
			OUTSIDE_ONLY,

			/// <summary>
			/// <para></para>
			/// </summary>
			[GPValue("false")]
			[Description("FULL")]
			FULL,

		}

#endregion
	}
}
