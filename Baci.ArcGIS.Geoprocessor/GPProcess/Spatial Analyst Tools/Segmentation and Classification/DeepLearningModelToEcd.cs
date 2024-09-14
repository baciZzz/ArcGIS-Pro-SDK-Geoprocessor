using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.SpatialAnalystTools
{
	/// <summary>
	/// <para>Deep Learning Model To Ecd</para>
	/// <para>深度学习模型至 Ecd 文件</para>
	/// <para>将深度学习模型转换为 Esri 分类器定义文件 (.ecd)。</para>
	/// </summary>
	[Obsolete()]
	public class DeepLearningModelToEcd : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDeepLearningModel">
		/// <para>Input Deep Learning Model File</para>
		/// <para>由深度学习包（如 Google TensorFlow、Microsoft CNTK 或类似应用程序）生成的二进制模型文件。</para>
		/// </param>
		/// <param name="InClassificationInfoJson">
		/// <para>Input Esri Extra Info File</para>
		/// <para>类信息 JSON 文件。请参阅上方的 JSON 文件示例。</para>
		/// </param>
		/// <param name="OutClassifierDefinition">
		/// <para>Output Classifier Definition File</para>
		/// <para>可用于分类函数和分类栅格工具的 .ecd 文件。</para>
		/// <para>.ecd 输出文件只用作 Esri Python 分类或检测适配器函数的输入。</para>
		/// </param>
		public DeepLearningModelToEcd(object InDeepLearningModel, object InClassificationInfoJson, object OutClassifierDefinition)
		{
			this.InDeepLearningModel = InDeepLearningModel;
			this.InClassificationInfoJson = InClassificationInfoJson;
			this.OutClassifierDefinition = OutClassifierDefinition;
		}

		/// <summary>
		/// <para>Tool Display Name : 深度学习模型至 Ecd 文件</para>
		/// </summary>
		public override string DisplayName() => "深度学习模型至 Ecd 文件";

		/// <summary>
		/// <para>Tool Name : DeepLearningModelToEcd</para>
		/// </summary>
		public override string ToolName() => "DeepLearningModelToEcd";

		/// <summary>
		/// <para>Tool Excute Name : sa.DeepLearningModelToEcd</para>
		/// </summary>
		public override string ExcuteName() => "sa.DeepLearningModelToEcd";

		/// <summary>
		/// <para>Toolbox Display Name : Spatial Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Spatial Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : sa</para>
		/// </summary>
		public override string ToolboxAlise() => "sa";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InDeepLearningModel, InClassificationInfoJson, OutClassifierDefinition };

		/// <summary>
		/// <para>Input Deep Learning Model File</para>
		/// <para>由深度学习包（如 Google TensorFlow、Microsoft CNTK 或类似应用程序）生成的二进制模型文件。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPCompositeDomain()]
		public object InDeepLearningModel { get; set; }

		/// <summary>
		/// <para>Input Esri Extra Info File</para>
		/// <para>类信息 JSON 文件。请参阅上方的 JSON 文件示例。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPCompositeDomain()]
		public object InClassificationInfoJson { get; set; }

		/// <summary>
		/// <para>Output Classifier Definition File</para>
		/// <para>可用于分类函数和分类栅格工具的 .ecd 文件。</para>
		/// <para>.ecd 输出文件只用作 Esri Python 分类或检测适配器函数的输入。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPCompositeDomain()]
		public object OutClassifierDefinition { get; set; }

	}
}
