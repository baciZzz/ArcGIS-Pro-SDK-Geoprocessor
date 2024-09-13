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
	/// <para>Compute Accuracy For Object Detection</para>
	/// <para>计算对象检测的精度</para>
	/// <para>通过对深度学习检测对象使用工具检测到的对象和实际地表数据进行比较来计算深度学习模型的精度。</para>
	/// </summary>
	public class ComputeAccuracyForObjectDetection : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="DetectedFeatures">
		/// <para>Detected Features</para>
		/// <para>面要素类，其中包含使用深度学习检测对象工具检测的对象。</para>
		/// </param>
		/// <param name="GroundTruthFeatures">
		/// <para>Ground Truth Features</para>
		/// <para>包含实际地表数据的面要素类。</para>
		/// </param>
		/// <param name="OutAccuracyTable">
		/// <para>Output Accuracy Table</para>
		/// <para>输出精度表。</para>
		/// </param>
		public ComputeAccuracyForObjectDetection(object DetectedFeatures, object GroundTruthFeatures, object OutAccuracyTable)
		{
			this.DetectedFeatures = DetectedFeatures;
			this.GroundTruthFeatures = GroundTruthFeatures;
			this.OutAccuracyTable = OutAccuracyTable;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算对象检测的精度</para>
		/// </summary>
		public override string DisplayName() => "计算对象检测的精度";

		/// <summary>
		/// <para>Tool Name : ComputeAccuracyForObjectDetection</para>
		/// </summary>
		public override string ToolName() => "ComputeAccuracyForObjectDetection";

		/// <summary>
		/// <para>Tool Excute Name : ia.ComputeAccuracyForObjectDetection</para>
		/// </summary>
		public override string ExcuteName() => "ia.ComputeAccuracyForObjectDetection";

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
		public override string[] ValidEnvironments() => new string[] { "extent", "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { DetectedFeatures, GroundTruthFeatures, OutAccuracyTable, OutAccuracyReport, DetectedClassValueField, GroundTruthClassValueField, MinIou, MaskFeatures };

		/// <summary>
		/// <para>Detected Features</para>
		/// <para>面要素类，其中包含使用深度学习检测对象工具检测的对象。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object DetectedFeatures { get; set; }

		/// <summary>
		/// <para>Ground Truth Features</para>
		/// <para>包含实际地表数据的面要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object GroundTruthFeatures { get; set; }

		/// <summary>
		/// <para>Output Accuracy Table</para>
		/// <para>输出精度表。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutAccuracyTable { get; set; }

		/// <summary>
		/// <para>Output Accuracy Report</para>
		/// <para>输出精度报表的名称。该报表是包含精度指标和图表的 PDF 文档。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPCompositeDomain()]
		public object OutAccuracyReport { get; set; }

		/// <summary>
		/// <para>Detected Class Value Field</para>
		/// <para>检测到的对象要素类中的字段，包含类值或类名称。</para>
		/// <para>如果未指定字段名称，则 Classvalue 或 Value 字段将被使用。 如果这些字段不存在，则会将所有记录标识为属于一个类。</para>
		/// <para>类值或类名称必须与地面参考要素类中的类值或类名称完全匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object DetectedClassValueField { get; set; }

		/// <summary>
		/// <para>Ground Truth Class Value Field</para>
		/// <para>实际地表要素中的字段，包含类值。</para>
		/// <para>如果未指定字段名称，则 Classvalue 或 Value 字段将被使用。 如果这些字段不存在，则会将所有记录标识为属于一个类。</para>
		/// <para>类值或类名称必须与检测到的对象要素类中的类值或类名称完全匹配。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Short", "Long", "Text")]
		public object GroundTruthClassValueField { get; set; }

		/// <summary>
		/// <para>Minimum Intersection Over Union (IoU)</para>
		/// <para>用作阈值的 IoU 比率，用于评估对象检测模型的精度。分子是预测边界框与地面参考边界框之间的重叠区域。分母是并集区域或者两个边界框所包含的区域。IoU 的范围从 0 到 1。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object MinIou { get; set; } = "0.5";

		/// <summary>
		/// <para>Mask Features</para>
		/// <para>面要素类，用于描绘将计算精度的区域。仅对与掩膜相交的要素进行精度评估。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPComposite()]
		public object MaskFeatures { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ComputeAccuracyForObjectDetection SetEnviroment(object extent = null , object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(extent: extent, scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
