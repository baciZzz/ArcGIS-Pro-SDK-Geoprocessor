using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.AviationTools
{
	/// <summary>
	/// <para>Prepare Aviation Data</para>
	/// <para>Evaluates aviation data based on organizationally specific JSON scripts, returning values necessary for cartographic labeling and symbolization. Returned values are stored in a single attribute of your features.</para>
	/// </summary>
	public class PrepareAviationData : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="TargetGdb">
		/// <para>Target Geodatabase</para>
		/// <para>The ArcGIS Aviation Charting schema workspace on which the evaluation will be run.</para>
		/// </param>
		/// <param name="ConfigFile">
		/// <para>Configuration File (.json)</para>
		/// <para>The JSON file containing the evaluation criteria.</para>
		/// </param>
		public PrepareAviationData(object TargetGdb, object ConfigFile)
		{
			this.TargetGdb = TargetGdb;
			this.ConfigFile = ConfigFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Prepare Aviation Data</para>
		/// </summary>
		public override string DisplayName() => "Prepare Aviation Data";

		/// <summary>
		/// <para>Tool Name : PrepareAviationData</para>
		/// </summary>
		public override string ToolName() => "PrepareAviationData";

		/// <summary>
		/// <para>Tool Excute Name : aviation.PrepareAviationData</para>
		/// </summary>
		public override string ExcuteName() => "aviation.PrepareAviationData";

		/// <summary>
		/// <para>Toolbox Display Name : Aviation Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Aviation Tools";

		/// <summary>
		/// <para>Toolbox Alise : aviation</para>
		/// </summary>
		public override string ToolboxAlise() => "aviation";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { TargetGdb, ConfigFile, InDatasetNames, OutWorkspace };

		/// <summary>
		/// <para>Target Geodatabase</para>
		/// <para>The ArcGIS Aviation Charting schema workspace on which the evaluation will be run.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object TargetGdb { get; set; }

		/// <summary>
		/// <para>Configuration File (.json)</para>
		/// <para>The JSON file containing the evaluation criteria.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("json")]
		public object ConfigFile { get; set; }

		/// <summary>
		/// <para>Input Datasets</para>
		/// <para>The names of the tables and feature classes to be evaluated.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object InDatasetNames { get; set; }

		/// <summary>
		/// <para>Output Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

	}
}
