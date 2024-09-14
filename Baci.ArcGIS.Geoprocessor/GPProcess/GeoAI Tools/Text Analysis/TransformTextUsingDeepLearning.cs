using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.GeoAITools
{
	/// <summary>
	/// <para>Transform Text Using Deep Learning</para>
	/// <para>使用深度学习转换文本</para>
	/// <para>在要素类或表中的文本字段上运行经过训练的序列到序列模型，并使用包含已转换、已变换或已翻译文本的新字段对其进行更新。</para>
	/// </summary>
	public class TransformTextUsingDeepLearning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>输入点、线或面要素类或表，其中包含将转换的文本。</para>
		/// </param>
		/// <param name="TextField">
		/// <para>Text Field</para>
		/// <para>输入要素类或表中的文本字段，其中包含将转换的文本。</para>
		/// </param>
		/// <param name="InModelDefinitionFile">
		/// <para>Input Model Definition File</para>
		/// <para>将用于分类的训练模型。 模型定义文件可以是本地存储的 Esri 模型定义 JSON 文件 (.emd) 或深度学习模型包 (.dlpk)。</para>
		/// </param>
		public TransformTextUsingDeepLearning(object InTable, object TextField, object InModelDefinitionFile)
		{
			this.InTable = InTable;
			this.TextField = TextField;
			this.InModelDefinitionFile = InModelDefinitionFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 使用深度学习转换文本</para>
		/// </summary>
		public override string DisplayName() => "使用深度学习转换文本";

		/// <summary>
		/// <para>Tool Name : TransformTextUsingDeepLearning</para>
		/// </summary>
		public override string ToolName() => "TransformTextUsingDeepLearning";

		/// <summary>
		/// <para>Tool Excute Name : geoai.TransformTextUsingDeepLearning</para>
		/// </summary>
		public override string ExcuteName() => "geoai.TransformTextUsingDeepLearning";

		/// <summary>
		/// <para>Toolbox Display Name : GeoAI Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "GeoAI Tools";

		/// <summary>
		/// <para>Toolbox Alise : geoai</para>
		/// </summary>
		public override string ToolboxAlise() => "geoai";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "gpuID", "processorType" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InTable, TextField, InModelDefinitionFile, ResultField!, ModelArguments!, BatchSize!, MinimumSequenceLength!, MaximumSequenceLength!, UpdatedTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>输入点、线或面要素类或表，其中包含将转换的文本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Text Field</para>
		/// <para>输入要素类或表中的文本字段，其中包含将转换的文本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object TextField { get; set; }

		/// <summary>
		/// <para>Input Model Definition File</para>
		/// <para>将用于分类的训练模型。 模型定义文件可以是本地存储的 Esri 模型定义 JSON 文件 (.emd) 或深度学习模型包 (.dlpk)。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("emd", "dlpk")]
		public object InModelDefinitionFile { get; set; }

		/// <summary>
		/// <para>Result Field</para>
		/// <para>包含输出要素类或表中已转换文本的字段名称。 默认字段名称为 Result。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ResultField { get; set; } = "Result";

		/// <summary>
		/// <para>Model Arguments</para>
		/// <para>将使用其他参数（例如，置信度阈值）调整模型的灵敏度。</para>
		/// <para>将使用该工具填充参数名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? ModelArguments { get; set; }

		/// <summary>
		/// <para>Batch Size</para>
		/// <para>一次需要处理的训练样本数。 默认值为 4。</para>
		/// <para>增加批处理大小可以提高工具性能；但是，随着批处理大小的增加，会占用更多内存。 如果发生内存不足错误，请使用较小的批处理大小。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced")]
		public object? BatchSize { get; set; } = "4";

		/// <summary>
		/// <para>Minimum Sequence Length</para>
		/// <para>输出文本字符串的最小字符数。 默认值为 20。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced")]
		public object? MinimumSequenceLength { get; set; } = "20";

		/// <summary>
		/// <para>Maximum Sequence Length</para>
		/// <para>输出文本字符串的最大字符数。 默认值为 50。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced")]
		public object? MaximumSequenceLength { get; set; } = "50";

		/// <summary>
		/// <para>Updated Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? UpdatedTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public TransformTextUsingDeepLearning SetEnviroment(object? processorType = null)
		{
			base.SetEnv(processorType: processorType);
			return this;
		}

	}
}
