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
	/// <para>Classify Text Using Deep Learning</para>
	/// <para>Runs a trained text classification model on a text field in a feature class or table and updates each record with an assigned class or category label.</para>
	/// </summary>
	public class ClassifyTextUsingDeepLearning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InTable">
		/// <para>Input Table</para>
		/// <para>The input point, line, or polygon feature class, or table, containing the text that will be classified and labelled.</para>
		/// </param>
		/// <param name="TextField">
		/// <para>Text Field</para>
		/// <para>A text field in the input feature class or table that contains the text that will be classified.</para>
		/// </param>
		/// <param name="InModelDefinitionFile">
		/// <para>Input Model Definition File</para>
		/// <para>The trained model that will be used for classification. The model definition file can be an Esri model definition JSON file (.emd) or a deep learning model package (.dlpk) stored locally.</para>
		/// </param>
		public ClassifyTextUsingDeepLearning(object InTable, object TextField, object InModelDefinitionFile)
		{
			this.InTable = InTable;
			this.TextField = TextField;
			this.InModelDefinitionFile = InModelDefinitionFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Classify Text Using Deep Learning</para>
		/// </summary>
		public override string DisplayName() => "Classify Text Using Deep Learning";

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
		/// <para>The input point, line, or polygon feature class, or table, containing the text that will be classified and labelled.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object InTable { get; set; }

		/// <summary>
		/// <para>Text Field</para>
		/// <para>A text field in the input feature class or table that contains the text that will be classified.</para>
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
		/// <para>Class Label Field</para>
		/// <para>The name of the field that will contain the class or category label assigned by the model. The default field name is ClassLabel.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		public object? ClassLabelField { get; set; } = "ClassLabel";

		/// <summary>
		/// <para>Model Arguments</para>
		/// <para>Additional arguments, such as a confidence threshold, that will be used to adjust the sensitivity of the model.</para>
		/// <para>The names of the arguments will be populated by the tool.</para>
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
