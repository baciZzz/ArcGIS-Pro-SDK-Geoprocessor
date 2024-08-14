using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.DataManagementTools
{
	/// <summary>
	/// <para>Analyze Toolbox For Version</para>
	/// <para>Analyzes the contents of a toolbox and identifies compatibility issues with previous versions of ArcGIS software.</para>
	/// </summary>
	public class AnalyzeToolboxForVersion : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InToolbox">
		/// <para>Input</para>
		/// <para>The input toolbox (.tbx or .atbx) that will be analyzed.</para>
		/// <para>The Python toolbox (.pyt) format is not supported as an input.</para>
		/// </param>
		/// <param name="Version">
		/// <para>Target  Version</para>
		/// <para>Specifies the software version that will be used for toolbox compatibility analysis.</para>
		/// <para>10.6.0—ArcGIS Desktop 10.6.0 will be used for toolbox compatibility issue analysis.</para>
		/// <para>10.7.0—ArcGIS Desktop 10.7.0 will be used for toolbox compatibility issue analysis.</para>
		/// <para>10.8.0—ArcGIS Desktop 10.8.0 will be used for toolbox compatibility issue analysis.</para>
		/// <para>10.8.2—ArcGIS Desktop 10.8.2 will be used for toolbox compatibility issue analysis.</para>
		/// <para>2.2—ArcGIS Pro 2.2 will be used for toolbox compatibility issue analysis.</para>
		/// <para>2.3—ArcGIS Pro 2.3 will be used for toolbox compatibility issue analysis.</para>
		/// <para>2.4—ArcGIS Pro 2.4 will be used for toolbox compatibility issue analysis.</para>
		/// <para>2.5—ArcGIS Pro2.5 will be used for toolbox compatibility issue analysis.</para>
		/// <para>2.6—ArcGIS Pro 2.6 will be used for toolbox compatibility issue analysis.</para>
		/// <para>2.7—ArcGIS Pro 2.7 will be used for toolbox compatibility issue analysis.</para>
		/// <para>2.8—ArcGIS Pro 2.8 will be used for toolbox compatibility issue analysis.</para>
		/// <para>2.9—ArcGIS Pro 2.9 will be used for toolbox compatibility issue analysis.</para>
		/// </param>
		public AnalyzeToolboxForVersion(object InToolbox, object Version)
		{
			this.InToolbox = InToolbox;
			this.Version = Version;
		}

		/// <summary>
		/// <para>Tool Display Name : Analyze Toolbox For Version</para>
		/// </summary>
		public override string DisplayName => "Analyze Toolbox For Version";

		/// <summary>
		/// <para>Tool Name : AnalyzeToolboxForVersion</para>
		/// </summary>
		public override string ToolName => "AnalyzeToolboxForVersion";

		/// <summary>
		/// <para>Tool Excute Name : management.AnalyzeToolboxForVersion</para>
		/// </summary>
		public override string ExcuteName => "management.AnalyzeToolboxForVersion";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InToolbox, Version, Report };

		/// <summary>
		/// <para>Input</para>
		/// <para>The input toolbox (.tbx or .atbx) that will be analyzed.</para>
		/// <para>The Python toolbox (.pyt) format is not supported as an input.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEToolbox()]
		public object InToolbox { get; set; }

		/// <summary>
		/// <para>Target  Version</para>
		/// <para>Specifies the software version that will be used for toolbox compatibility analysis.</para>
		/// <para>10.6.0—ArcGIS Desktop 10.6.0 will be used for toolbox compatibility issue analysis.</para>
		/// <para>10.7.0—ArcGIS Desktop 10.7.0 will be used for toolbox compatibility issue analysis.</para>
		/// <para>10.8.0—ArcGIS Desktop 10.8.0 will be used for toolbox compatibility issue analysis.</para>
		/// <para>10.8.2—ArcGIS Desktop 10.8.2 will be used for toolbox compatibility issue analysis.</para>
		/// <para>2.2—ArcGIS Pro 2.2 will be used for toolbox compatibility issue analysis.</para>
		/// <para>2.3—ArcGIS Pro 2.3 will be used for toolbox compatibility issue analysis.</para>
		/// <para>2.4—ArcGIS Pro 2.4 will be used for toolbox compatibility issue analysis.</para>
		/// <para>2.5—ArcGIS Pro2.5 will be used for toolbox compatibility issue analysis.</para>
		/// <para>2.6—ArcGIS Pro 2.6 will be used for toolbox compatibility issue analysis.</para>
		/// <para>2.7—ArcGIS Pro 2.7 will be used for toolbox compatibility issue analysis.</para>
		/// <para>2.8—ArcGIS Pro 2.8 will be used for toolbox compatibility issue analysis.</para>
		/// <para>2.9—ArcGIS Pro 2.9 will be used for toolbox compatibility issue analysis.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		[GPCodedValueDomain()]
		public object Version { get; set; }

		/// <summary>
		/// <para>Output File</para>
		/// <para>The text file that will be created containing the compatibility issues identified by the analyzers.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		public object? Report { get; set; }

	}
}
