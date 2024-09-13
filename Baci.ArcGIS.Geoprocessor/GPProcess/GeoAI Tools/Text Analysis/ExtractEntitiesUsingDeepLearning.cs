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
	/// <para>Extract Entities Using Deep Learning</para>
	/// <para>Runs a trained named entity recognizer model on text files in a folder to extract entities and locations (such as addresses, place or person names, dates, and monetary values) in a table. If the extracted entities contain an address, the tool geocodes the addresses using the specified locator and produces a feature class as an output.</para>
	/// </summary>
	public class ExtractEntitiesUsingDeepLearning : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFolder">
		/// <para>Input Folder</para>
		/// <para>The folder containing the text files on which named entity extraction will be performed.</para>
		/// </param>
		/// <param name="OutTable">
		/// <para>Output Table</para>
		/// <para>The output feature class or table that will contain the extracted entities. If a locator is provided and the model extracts addresses, the feature class will be produced by geocoding the extracted addresses.</para>
		/// </param>
		/// <param name="InModelDefinitionFile">
		/// <para>Input Model Definition File</para>
		/// <para>The trained model that will be used for classification. The model definition file can be an Esri model definition JSON file (.emd) or a deep learning model package (.dlpk) stored locally.</para>
		/// </param>
		public ExtractEntitiesUsingDeepLearning(object InFolder, object OutTable, object InModelDefinitionFile)
		{
			this.InFolder = InFolder;
			this.OutTable = OutTable;
			this.InModelDefinitionFile = InModelDefinitionFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Extract Entities Using Deep Learning</para>
		/// </summary>
		public override string DisplayName() => "Extract Entities Using Deep Learning";

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
		/// <para>The folder containing the text files on which named entity extraction will be performed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object InFolder { get; set; }

		/// <summary>
		/// <para>Output Table</para>
		/// <para>The output feature class or table that will contain the extracted entities. If a locator is provided and the model extracts addresses, the feature class will be produced by geocoding the extracted addresses.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPComposite()]
		public object OutTable { get; set; }

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
		/// <para>Model Arguments</para>
		/// <para>Additional arguments, such as a confidence threshold, that will be used to adjust the sensitivity of the model.</para>
		/// <para>The names of the arguments will be populated by the tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPValueTable()]
		public object? ModelArguments { get; set; } = "sequence_length 512";

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
		/// <para>Location Zone</para>
		/// <para>The geographic region or zone in which the addresses are expected to be located. The specified text will be appended to the address extracted by the model.</para>
		/// <para>The locator uses the location zone information to identify the region or geographic area in which the address is located and produces better results.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPString()]
		[Category("Advanced")]
		public object? LocationZone { get; set; }

		/// <summary>
		/// <para>Input Locator</para>
		/// <para>The locator that will be used to geocode addresses found in the input text documents. A point is generated for each address that is geocoded successfully and stored in the output feature class.</para>
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
