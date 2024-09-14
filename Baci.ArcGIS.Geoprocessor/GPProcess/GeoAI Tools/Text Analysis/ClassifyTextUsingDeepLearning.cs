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
	/// <para>Classify Text Using Deep Learning</para>
	/// <para>使用深度学习分类文本</para>
	/// <para>在要素类或表中的文本字段上运行经过训练的文本分类模型，并使用已分配的类或类别标注更新每个记录。</para>
	/// </summary>
	public class ClassifyTextUsingDeepLearning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>输入点、线或面要素类或表，其中包含将分类和标注的文本。</para>
		/// </param>
		/// <param name="TextField">
		/// <para>Text Field</para>
		/// <para>输入要素类或表中的文本字段，其中包含将分类的文本。</para>
		/// </param>
		/// <param name="InModelDefinitionFile">
		/// <para>Input Model Definition File</para>
		/// <para>将用于分类的训练模型。 模型定义文件可以是本地存储的 Esri 模型定义 JSON 文件 (.emd) 或深度学习模型包 (.dlpk)。</para>
		/// </param>
		public ClassifyTextUsingDeepLearning(object InTable, object TextField, object InModelDefinitionFile)
		{
			this.InTable = InTable;
			this.TextField = TextField;
			this.InModelDefinitionFile = InModelDefinitionFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 使用深度学习分类文本</para>
		/// </summary>
		public override string DisplayName() => "使用深度学习分类文本";

		/// <summary>
		/// <para>Tool Name : ClassifyTextUsingDeepLearning</para>
		/// </summary>
		public override string ToolName() => "ClassifyTextUsingDeepLearning";

		/// <summary>
		/// <para>Tool Excute Name : geoai.ClassifyTextUsingDeepLearning</para>
		/// </summary>
		public override string ExcuteName() => "geoai.ClassifyTextUsingDeepLearning";

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
		public override object[] Parameters() => new object[] { InTable, TextField, InModelDefinitionFile, ClassLabelField!, ModelArguments!, UpdatedTable! };

		/// <summary>
		/// <para>Input Table</para>
		/// <para>输入点、线或面要素类或表，其中包含将分类和标注的文本。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Text Field</para>
		/// <para>输入要素类或表中的文本字段，其中包含将分类的文本。</para>
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
		/// <para>Class Label Field</para>
		/// <para>将包含模型分配的类或类别标注的字段名称。 默认字段名称为 ClassLabel。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ClassLabelField { get; set; } = "ClassLabel";

		/// <summary>
		/// <para>Model Arguments</para>
		/// <para>将使用其他参数（例如，置信度阈值）调整模型的灵敏度。</para>
		/// <para>将使用该工具填充参数名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? ModelArguments { get; set; } = "sequence_length 512";

		/// <summary>
		/// <para>Updated Table</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPComposite()]
		public object? UpdatedTable { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ClassifyTextUsingDeepLearning SetEnviroment(object? processorType = null)
		{
			base.SetEnv(processorType: processorType);
			return this;
		}

	}
}
