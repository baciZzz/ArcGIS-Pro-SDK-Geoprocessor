using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ImageAnalystTools
{
	/// <summary>
	/// <para>Non Maximum Suppression</para>
	/// <para>非极大值抑制</para>
	/// <para>可将使用深度学习检测对象工具的输出中的重复要素识别为后处理步骤，并创建没有重复要素的新输出。使用深度学习检测对象工具可针对同一对象（尤其是作为切片的边际效应）返回多个边界框或面。如果两个要素的重叠超过给定的最大比率，则将移除置信值较低的要素。</para>
	/// </summary>
	public class NonMaximumSuppression : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureclass">
		/// <para>Input Feature Class</para>
		/// <para>包含重叠要素或重复要素的输入要素类或要素图层。</para>
		/// </param>
		/// <param name="ConfidenceScoreField">
		/// <para>Confidence Score Field</para>
		/// <para>要素类中的字段，该字段包含将由对象检测方法输出的置信度得分。</para>
		/// </param>
		/// <param name="OutFeatureclass">
		/// <para>Output Feature Class</para>
		/// <para>移除了重复要素的输出要素类。</para>
		/// </param>
		public NonMaximumSuppression(object InFeatureclass, object ConfidenceScoreField, object OutFeatureclass)
		{
			this.InFeatureclass = InFeatureclass;
			this.ConfidenceScoreField = ConfidenceScoreField;
			this.OutFeatureclass = OutFeatureclass;
		}

		/// <summary>
		/// <para>Tool Display Name : 非极大值抑制</para>
		/// </summary>
		public override string DisplayName() => "非极大值抑制";

		/// <summary>
		/// <para>Tool Name : NonMaximumSuppression</para>
		/// </summary>
		public override string ToolName() => "NonMaximumSuppression";

		/// <summary>
		/// <para>Tool Excute Name : ia.NonMaximumSuppression</para>
		/// </summary>
		public override string ExcuteName() => "ia.NonMaximumSuppression";

		/// <summary>
		/// <para>Toolbox Display Name : Image Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Image Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ia</para>
		/// </summary>
		public override string ToolboxAlise() => "ia";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "extent", "geographicTransformations", "outputCoordinateSystem", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InFeatureclass, ConfidenceScoreField, OutFeatureclass, ClassValueField!, MaxOverlapRatio! };

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>包含重叠要素或重复要素的输入要素类或要素图层。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InFeatureclass { get; set; }

		/// <summary>
		/// <para>Confidence Score Field</para>
		/// <para>要素类中的字段，该字段包含将由对象检测方法输出的置信度得分。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Float", "Double")]
		public object ConfidenceScoreField { get; set; }

		/// <summary>
		/// <para>Output Feature Class</para>
		/// <para>移除了重复要素的输出要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureClass()]
		public object OutFeatureclass { get; set; }

		/// <summary>
		/// <para>Class Value Field</para>
		/// <para>输入要素类中的类值字段。若未指定，则工具将使用标准类值字段 Classvalue 和 Value。若这些字段不存在，则所有要素将被视为相同的对象类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object? ClassValueField { get; set; }

		/// <summary>
		/// <para>Max Overlap Ratio</para>
		/// <para>两个重叠要素的最大重叠比。其定义为交集区域与并集区域之比。默认值为 0。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object? MaxOverlapRatio { get; set; } = "0";

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public NonMaximumSuppression SetEnviroment(object? extent = null, object? geographicTransformations = null, object? outputCoordinateSystem = null, object? scratchWorkspace = null, object? workspace = null)
		{
			base.SetEnv(extent: extent, geographicTransformations: geographicTransformations, outputCoordinateSystem: outputCoordinateSystem, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
