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
	/// <para>Generate SDCX Index</para>
	/// <para>Creates an index for a Statistical Data Collection (SDCX). The index will improve performance when using the custom data in analysis tools such as Enrich Layer.</para>
	/// </summary>
	public class GenerateSDCXIndex : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="SdcxFile">
		/// <para>Input SDCX File</para>
		/// <para>The input Statistical Data Collection file (.sdcx).</para>
		/// </param>
		public GenerateSDCXIndex(object SdcxFile)
		{
			this.SdcxFile = SdcxFile;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate SDCX Index</para>
		/// </summary>
		public override string DisplayName => "Generate SDCX Index";

		/// <summary>
		/// <para>Tool Name : GenerateSDCXIndex</para>
		/// </summary>
		public override string ToolName => "GenerateSDCXIndex";

		/// <summary>
		/// <para>Tool Excute Name : ba.GenerateSDCXIndex</para>
		/// </summary>
		public override string ExcuteName => "ba.GenerateSDCXIndex";

		/// <summary>
		/// <para>Toolbox Display Name : Business Analyst Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Business Analyst Tools";

		/// <summary>
		/// <para>Toolbox Alise : ba</para>
		/// </summary>
		public override string ToolboxAlise => "ba";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { SdcxFile, UpdatedSdcxFile };

		/// <summary>
		/// <para>Input SDCX File</para>
		/// <para>The input Statistical Data Collection file (.sdcx).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object SdcxFile { get; set; }

		/// <summary>
		/// <para>Updated SDCX File</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFile()]
		[GPFileDomain()]
		public object UpdatedSdcxFile { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateSDCXIndex SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
