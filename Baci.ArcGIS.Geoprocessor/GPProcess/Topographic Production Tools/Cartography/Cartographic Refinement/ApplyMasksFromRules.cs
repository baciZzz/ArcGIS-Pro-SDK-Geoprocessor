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
	/// <para>Apply Masks From Rules</para>
	/// <para>Applies symbol layer masking to feature layers in a map based on an XML rule file and mask features created by the Make Mask From Rules tool.</para>
	/// </summary>
	public class ApplyMasksFromRules : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMap">
		/// <para>Input Map</para>
		/// <para>The input map containing symbolized features such as a map in a project or a MAPX file on disk.</para>
		/// </param>
		/// <param name="RuleFile">
		/// <para>Rule File</para>
		/// <para>The XML file containing rules to define how features should be masked based on colors and symbol parts.</para>
		/// </param>
		/// <param name="InFeatureDataset">
		/// <para>Mask Feature Dataset</para>
		/// <para>The feature dataset containing the masking polygon feature classes created by the Make Mask From Rules tool.</para>
		/// </param>
		public ApplyMasksFromRules(object InMap, object RuleFile, object InFeatureDataset)
		{
			this.InMap = InMap;
			this.RuleFile = RuleFile;
			this.InFeatureDataset = InFeatureDataset;
		}

		/// <summary>
		/// <para>Tool Display Name : Apply Masks From Rules</para>
		/// </summary>
		public override string DisplayName() => "Apply Masks From Rules";

		/// <summary>
		/// <para>Tool Name : ApplyMasksFromRules</para>
		/// </summary>
		public override string ToolName() => "ApplyMasksFromRules";

		/// <summary>
		/// <para>Tool Excute Name : topographic.ApplyMasksFromRules</para>
		/// </summary>
		public override string ExcuteName() => "topographic.ApplyMasksFromRules";

		/// <summary>
		/// <para>Toolbox Display Name : Topographic Production Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Topographic Production Tools";

		/// <summary>
		/// <para>Toolbox Alise : topographic</para>
		/// </summary>
		public override string ToolboxAlise() => "topographic";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMap, RuleFile, InFeatureDataset, UpdatedMap };

		/// <summary>
		/// <para>Input Map</para>
		/// <para>The input map containing symbolized features such as a map in a project or a MAPX file on disk.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMap()]
		public object InMap { get; set; }

		/// <summary>
		/// <para>Rule File</para>
		/// <para>The XML file containing rules to define how features should be masked based on colors and symbol parts.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("xml")]
		public object RuleFile { get; set; }

		/// <summary>
		/// <para>Mask Feature Dataset</para>
		/// <para>The feature dataset containing the masking polygon feature classes created by the Make Mask From Rules tool.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFeatureDataset()]
		public object InFeatureDataset { get; set; }

		/// <summary>
		/// <para>Updated Map</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMap()]
		public object UpdatedMap { get; set; }

	}
}
