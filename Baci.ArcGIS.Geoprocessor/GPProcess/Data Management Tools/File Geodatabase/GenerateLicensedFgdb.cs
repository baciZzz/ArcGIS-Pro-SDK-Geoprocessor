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
	/// <para>Generate Licensed File Geodatabase</para>
	/// <para>Generates a license definition file (.licdef) that defines and restricts the display of contents in a file geodatabase.  The contents of the licensed file geodatabase can be viewed by creating  a license file (*.sdlic) and installing it with ArcGIS Administrator.  The license file is created using the Generate File Geodatabase License tool.</para>
	/// </summary>
	public class GenerateLicensedFgdb : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFgdb">
		/// <para>Input File Geodatabase</para>
		/// <para>The unlicensed file geodatabase to make licensed.</para>
		/// </param>
		/// <param name="OutFgdb">
		/// <para>Output Licensed File Geodatabase</para>
		/// <para>The name of and location to create the licensed file geodatabase.</para>
		/// </param>
		/// <param name="OutLicDef">
		/// <para>Output License Definition File</para>
		/// <para>The license definition file.</para>
		/// </param>
		public GenerateLicensedFgdb(object InFgdb, object OutFgdb, object OutLicDef)
		{
			this.InFgdb = InFgdb;
			this.OutFgdb = OutFgdb;
			this.OutLicDef = OutLicDef;
		}

		/// <summary>
		/// <para>Tool Display Name : Generate Licensed File Geodatabase</para>
		/// </summary>
		public override string DisplayName => "Generate Licensed File Geodatabase";

		/// <summary>
		/// <para>Tool Name : GenerateLicensedFgdb</para>
		/// </summary>
		public override string ToolName => "GenerateLicensedFgdb";

		/// <summary>
		/// <para>Tool Excute Name : management.GenerateLicensedFgdb</para>
		/// </summary>
		public override string ExcuteName => "management.GenerateLicensedFgdb";

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
		public override string[] ValidEnvironments => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFgdb, OutFgdb, OutLicDef };

		/// <summary>
		/// <para>Input File Geodatabase</para>
		/// <para>The unlicensed file geodatabase to make licensed.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object InFgdb { get; set; }

		/// <summary>
		/// <para>Output Licensed File Geodatabase</para>
		/// <para>The name of and location to create the licensed file geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object OutFgdb { get; set; }

		/// <summary>
		/// <para>Output License Definition File</para>
		/// <para>The license definition file.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object OutLicDef { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public GenerateLicensedFgdb SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
