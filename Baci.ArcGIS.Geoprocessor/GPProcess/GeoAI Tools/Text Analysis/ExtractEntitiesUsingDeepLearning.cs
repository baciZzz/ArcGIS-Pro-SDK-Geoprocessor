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
	/// <para>Extract Entities Using Deep Learning</para>
	/// <para>使用深度学习提取实体</para>
	/// <para>用于在文件夹中的文本文件上运行经过训练的指定实体识别器模型，以提取表中的实体和位置（例如地址、地点名称或人名、日期和货币值）。 如果所提取的实体包含地址，则该工具将使用指定的定位器对地址进行地理编码并生成要素类作为输出。</para>
	/// </summary>
	public class ExtractEntitiesUsingDeepLearning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFolder">
		/// <para>Input Folder</para>
		/// <para>包含待执行已命名实体提取的文本文件的文件夹。</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>将包含已提取实体的输出要素类或表。 如果提供了定位器且模型提取了地址，则系统将通过对已提取地址进行地理编码来生成要素类。</para>
		/// </param>
		/// <param name="InModelDefinitionFile">
		/// <para>Input Model Definition File</para>
		/// <para>将用于分类的训练模型。 模型定义文件可以是本地存储的 Esri 模型定义 JSON 文件 (.emd) 或深度学习模型包 (.dlpk)。</para>
		/// </param>
		public ExtractEntitiesUsingDeepLearning(object InFolder, object OutTable, object InModelDefinitionFile)
		{
			this.InFolder = InFolder;
			this.OutTable = OutTable;
			this.InModelDefinitionFile = InModelDefinitionFile;
		}

		/// <summary>
		/// <para>Tool Display Name : 使用深度学习提取实体</para>
		/// </summary>
		public override string DisplayName() => "使用深度学习提取实体";

		/// <summary>
		/// <para>Tool Name : ExtractEntitiesUsingDeepLearning</para>
		/// </summary>
		public override string ToolName() => "ExtractEntitiesUsingDeepLearning";

		/// <summary>
		/// <para>Tool Excute Name : geoai.ExtractEntitiesUsingDeepLearning</para>
		/// </summary>
		public override string ExcuteName() => "geoai.ExtractEntitiesUsingDeepLearning";

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
		public override object[] Parameters() => new object[] { InFolder, OutTable, InModelDefinitionFile, ModelArguments!, BatchSize!, LocationZone!, InLocator! };

		/// <summary>
		/// <para>Input Folder</para>
		/// <para>包含待执行已命名实体提取的文本文件的文件夹。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object InFolder { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>将包含已提取实体的输出要素类或表。 如果提供了定位器且模型提取了地址，则系统将通过对已提取地址进行地理编码来生成要素类。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutTable { get; set; }

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
		/// <para>Model Arguments</para>
		/// <para>将使用其他参数（例如，置信度阈值）调整模型的灵敏度。</para>
		/// <para>将使用该工具填充参数名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? ModelArguments { get; set; } = "sequence_length 512";

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
		/// <para>Location Zone</para>
		/// <para>预计地址所在的地理区域或地区。 指定的文本将被追加到模型所提取的地址中。</para>
		/// <para>定位器将使用位置区域信息来识别地址所在的地区或地理区域并生成更理想的结果。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced")]
		public object? LocationZone { get; set; }

		/// <summary>
		/// <para>Input Locator</para>
		/// <para>将用于对输入文本文档中发现的地址进行地理编码的定位器。 将为成功进行地理编码并存储在输出要素类中的每个地址生成一个点。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEAddressLocator()]
		[Category("Advanced")]
		public object? InLocator { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExtractEntitiesUsingDeepLearning SetEnviroment(object? processorType = null )
		{
			base.SetEnv(processorType: processorType);
			return this;
		}

	}
}
