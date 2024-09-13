using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.BusinessAnalystTools
{
	/// <summary>
	/// <para>Import Survey Profiles</para>
	/// <para>Import Survey Profiles</para>
	/// <para>Imports segmentation profiles consisting of survey variable data.</para>
	/// </summary>
	public class ImportSurveyProfiles : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="Profiles">
		/// <para>Profiles</para>
		/// <para>Categories of survey variables that can be selected for importing as profiles.</para>
		/// </param>
		/// <param name="OutFolder">
		/// <para>Output Folder</para>
		/// <para>The folder selected to contain the profiles being created.</para>
		/// </param>
		public ImportSurveyProfiles(object Profiles, object OutFolder)
		{
			this.Profiles = Profiles;
			this.OutFolder = OutFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : Import Survey Profiles</para>
		/// </summary>
		public override string DisplayName() => "Import Survey Profiles";

		/// <summary>
		/// <para>Tool Name : ImportSurveyProfiles</para>
		/// </summary>
		public override string ToolName() => "ImportSurveyProfiles";

		/// <summary>
		/// <para>Tool Excute Name : ba.ImportSurveyProfiles</para>
		/// </summary>
		public override string ExcuteName() => "ba.ImportSurveyProfiles";

		/// <summary>
		/// <para>Toolbox Display Name : Business Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Business Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ba</para>
		/// </summary>
		public override string ToolboxAlise() => "ba";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "baDataSource", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { Profiles, OutFolder, OutProfiles };

		/// <summary>
		/// <para>Profiles</para>
		/// <para>Categories of survey variables that can be selected for importing as profiles.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object Profiles { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// <para>The folder selected to contain the profiles being created.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutFolder { get; set; }

		/// <summary>
		/// <para>Output Profiles</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPMultiValue()]
		public object OutProfiles { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportSurveyProfiles SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
