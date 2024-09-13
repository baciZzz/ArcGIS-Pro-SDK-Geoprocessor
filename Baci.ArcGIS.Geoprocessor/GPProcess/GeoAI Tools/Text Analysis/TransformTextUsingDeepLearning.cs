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
	/// <para>Transform Text Using Deep Learning</para>
	/// <para>Runs a trained sequence-to-sequence model on a text field in a feature class or table and updates it with a new field containing the converted, transformed, or translated text.</para>
	/// </summary>
	public class TransformTextUsingDeepLearning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The input point, line, or polygon feature class, or table, containing the text that will be transformed.</para>
		/// </param>
		/// <param name="TextField">
		/// <para>Text Field</para>
		/// <para>A text field in the input feature class or table that contains the text that will be transformed.</para>
		/// </param>
		/// <param name="InModelDefinitionFile">
		/// <para>Input Model Definition File</para>
		/// <para>The trained model that will be used for classification. The model definition file can be an Esri model definition JSON file (.emd) or a deep learning model package (.dlpk) stored locally.</para>
		/// </param>
		public TransformTextUsingDeepLearning(object InTable, object TextField, object InModelDefinitionFile)
		{
			this.InTable = InTable;
			this.TextField = TextField;
			this.InModelDefinitionFile = InModelDefinitionFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Transform Text Using Deep Learning</para>
		/// </summary>
		public override string DisplayName() => "Transform Text Using Deep Learning";

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
		/// <para>The input point, line, or polygon feature class, or table, containing the text that will be transformed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Text Field</para>
		/// <para>A text field in the input feature class or table that contains the text that will be transformed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[Field()]
		[GPFieldDomain()]
		[FieldType("Text")]
		public object TextField { get; set; }

		/// <summary>
		/// <para>Input Model Definition File</para>
		/// <para>The trained model that will be used for classification. The model definition file can be an Esri model definition JSON file (.emd) or a deep learning model package (.dlpk) stored locally.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("emd", "dlpk")]
		public object InModelDefinitionFile { get; set; }

		/// <summary>
		/// <para>Result Field</para>
		/// <para>The name of the field that will contain the transformed text in the output feature class or table. The default field name is Result.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ResultField { get; set; } = "Result";

		/// <summary>
		/// <para>Model Arguments</para>
		/// <para>Additional arguments, such as a confidence threshold, that will be used to adjust the sensitivity of the model.</para>
		/// <para>The names of the arguments will be populated by the tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? ModelArguments { get; set; }

		/// <summary>
		/// <para>Batch Size</para>
		/// <para>The number of training samples that will be processed at one time. The default value is 4.</para>
		/// <para>Increasing the batch size can improve tool performance; however, as the batch size increases, more memory is used. If an out of memory error occurs, use a smaller batch size.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced")]
		public object? BatchSize { get; set; } = "4";

		/// <summary>
		/// <para>Minimum Sequence Length</para>
		/// <para>The minimum number of characters for the output text string. The default value is 20.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		[Category("Advanced")]
		public object? MinimumSequenceLength { get; set; } = "20";

		/// <summary>
		/// <para>Maximum Sequence Length</para>
		/// <para>The maximum number of characters for the output text string. The default value is 50.</para>
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
		public TransformTextUsingDeepLearning SetEnviroment(object? processorType = null )
		{
			base.SetEnv(processorType: processorType);
			return this;
		}

	}
}
