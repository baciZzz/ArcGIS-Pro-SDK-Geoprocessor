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
	/// <para>Compute Confusion Matrix</para>
	/// <para>计算混淆矩阵</para>
	/// <para>使用漏分误差和错分误差计算混淆矩阵，然后派生出分类地图与参考数据之间的一致性 kappa 指数、交并比 (IoU) 和整体精度。</para>
	/// </summary>
	public class ComputeConfusionMatrix : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InAccuracyAssessmentPoints">
		/// <para>Input Accuracy Assessment Points</para>
		/// <para>通过创建精度评估点工具创建的精度评估点要素类包含 Classified 以及 GrndTruth 字段。 Classified 和 GrndTruth 字段均为长整型字段。</para>
		/// </param>
		/// <param name="OutConfusionMatrix">
		/// <para>Output Confusion Matrix</para>
		/// <para>表格式形式的混淆矩阵输出文件名。</para>
		/// <para>表的格式由输出位置和路径确定。 默认情况下，输出为一张地理数据库表。 如果该路径不在地理数据库中，请指定 .dbf 扩展名以将其保存为 dBASE 格式。</para>
		/// </param>
		public ComputeConfusionMatrix(object InAccuracyAssessmentPoints, object OutConfusionMatrix)
		{
			this.InAccuracyAssessmentPoints = InAccuracyAssessmentPoints;
			this.OutConfusionMatrix = OutConfusionMatrix;
		}

		/// <summary>
		/// <para>Tool Display Name : 计算混淆矩阵</para>
		/// </summary>
		public override string DisplayName() => "计算混淆矩阵";

		/// <summary>
		/// <para>Tool Name : ComputeConfusionMatrix</para>
		/// </summary>
		public override string ToolName() => "ComputeConfusionMatrix";

		/// <summary>
		/// <para>Tool Excute Name : ia.ComputeConfusionMatrix</para>
		/// </summary>
		public override string ExcuteName() => "ia.ComputeConfusionMatrix";

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
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InAccuracyAssessmentPoints, OutConfusionMatrix };

		/// <summary>
		/// <para>Input Accuracy Assessment Points</para>
		/// <para>通过创建精度评估点工具创建的精度评估点要素类包含 Classified 以及 GrndTruth 字段。 Classified 和 GrndTruth 字段均为长整型字段。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		public object InAccuracyAssessmentPoints { get; set; }

		/// <summary>
		/// <para>Output Confusion Matrix</para>
		/// <para>表格式形式的混淆矩阵输出文件名。</para>
		/// <para>表的格式由输出位置和路径确定。 默认情况下，输出为一张地理数据库表。 如果该路径不在地理数据库中，请指定 .dbf 扩展名以将其保存为 dBASE 格式。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DETable()]
		public object OutConfusionMatrix { get; set; }

	}
}
