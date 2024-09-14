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
	/// <para>Deep Learning Model To Ecd</para>
	/// <para>Converts a deep learning model to an Esri classifier definition file (.ecd).</para>
	/// </summary>
	[Obsolete()]
	public class DeepLearningModelToEcd : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InDeepLearningModel">
		/// <para>Input Deep Learning Model File</para>
		/// <para>The binary model file generated by a deep learning package such as Google TensorFlow, Microsoft CNTK, or similar application.</para>
		/// </param>
		/// <param name="InClassificationInfoJson">
		/// <para>Input Esri Extra Info File</para>
		/// <para>The class information JSON file. See the JSON file example above.</para>
		/// </param>
		/// <param name="OutClassifierDefinition">
		/// <para>Output Classifier Definition File</para>
		/// <para>The .ecd file that can be used in the Classify function and Classify Raster tool.</para>
		/// <para>The .ecd output file only works as input to the Esri Python Classify or Detect adaptor function.</para>
		/// </param>
		public DeepLearningModelToEcd(object InDeepLearningModel, object InClassificationInfoJson, object OutClassifierDefinition)
		{
			this.InDeepLearningModel = InDeepLearningModel;
			this.InClassificationInfoJson = InClassificationInfoJson;
			this.OutClassifierDefinition = OutClassifierDefinition;
		}

		/// <summary>
		/// <para>Tool Display Name : Deep Learning Model To Ecd</para>
		/// </summary>
		public override string DisplayName() => "Deep Learning Model To Ecd";

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
		/// <para>The binary model file generated by a deep learning package such as Google TensorFlow, Microsoft CNTK, or similar application.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPCompositeDomain()]
		public object InDeepLearningModel { get; set; }

		/// <summary>
		/// <para>Input Esri Extra Info File</para>
		/// <para>The class information JSON file. See the JSON file example above.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPCompositeDomain()]
		public object InClassificationInfoJson { get; set; }

		/// <summary>
		/// <para>Output Classifier Definition File</para>
		/// <para>The .ecd file that can be used in the Classify function and Classify Raster tool.</para>
		/// <para>The .ecd output file only works as input to the Esri Python Classify or Detect adaptor function.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPCompositeDomain()]
		public object OutClassifierDefinition { get; set; }

	}
}
