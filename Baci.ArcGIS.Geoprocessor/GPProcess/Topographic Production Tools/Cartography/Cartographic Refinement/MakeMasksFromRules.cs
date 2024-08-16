using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.TopographicProductionTools
{
	/// <summary>
	/// <para>Make Masks From Rules</para>
	/// <para>Creates polygon masks for features based on color rules.</para>
	/// </summary>
	public class MakeMasksFromRules : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMap">
		/// <para>Input Map</para>
		/// <para>The input map containing symbolized features.</para>
		/// </param>
		/// <param name="RuleFile">
		/// <para>Rule File</para>
		/// <para>The XML file containing rules that define how features should be masked based on colors and symbol parts.</para>
		/// </param>
		/// <param name="OutFeatureDataset">
		/// <para>Output Feature Dataset</para>
		/// <para>The output feature dataset. The tool will create a feature dataset containing polygon feature classes that will be used for masking. The spatial reference for the feature dataset will be taken from the map for which masks are generated.</para>
		/// </param>
		public MakeMasksFromRules(object InMap, object RuleFile, object OutFeatureDataset)
		{
			this.InMap = InMap;
			this.RuleFile = RuleFile;
			this.OutFeatureDataset = OutFeatureDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Make Masks From Rules</para>
		/// </summary>
		public override string DisplayName => "Make Masks From Rules";

		/// <summary>
		/// <para>Tool Name : MakeMasksFromRules</para>
		/// </summary>
		public override string ToolName => "MakeMasksFromRules";

		/// <summary>
		/// <para>Tool Excute Name : topographic.MakeMasksFromRules</para>
		/// </summary>
		public override string ExcuteName => "topographic.MakeMasksFromRules";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InMap, RuleFile, OutFeatureDataset };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>The input map containing symbolized features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InMap { get; set; }

		/// <summary>
		/// <para>Rule File</para>
		/// <para>The XML file containing rules that define how features should be masked based on colors and symbol parts.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml")]
		public object RuleFile { get; set; }

		/// <summary>
		/// <para>Output Feature Dataset</para>
		/// <para>The output feature dataset. The tool will create a feature dataset containing polygon feature classes that will be used for masking. The spatial reference for the feature dataset will be taken from the map for which masks are generated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object OutFeatureDataset { get; set; }

	}
}
