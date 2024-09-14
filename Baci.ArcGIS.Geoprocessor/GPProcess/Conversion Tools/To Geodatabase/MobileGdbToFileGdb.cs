using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.ConversionTools
{
	/// <summary>
	/// <para>Mobile Geodatabase To File Geodatabase</para>
	/// <para>Mobile Geodatabase To File Geodatabase</para>
	/// <para>Copies the contents of a mobile geodatabase to a new file geodatabase.</para>
	/// </summary>
	public class MobileGdbToFileGdb : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMobileGdb">
		/// <para>Input Mobile Geodatabase</para>
		/// <para>The mobile geodatabase that will have its contents copied to a new file geodatabase.</para>
		/// </param>
		/// <param name="OutFileGdb">
		/// <para>Output File Geodatabase</para>
		/// <para>The name and location of the output file geodatabase, for example, c:\temp\outputGeodatabases\copiedFGDB.gdb.</para>
		/// </param>
		public MobileGdbToFileGdb(object InMobileGdb, object OutFileGdb)
		{
			this.InMobileGdb = InMobileGdb;
			this.OutFileGdb = OutFileGdb;
		}

		/// <summary>
		/// <para>Tool Display Name : Mobile Geodatabase To File Geodatabase</para>
		/// </summary>
		public override string DisplayName() => "Mobile Geodatabase To File Geodatabase";

		/// <summary>
		/// <para>Tool Name : MobileGdbToFileGdb</para>
		/// </summary>
		public override string ToolName() => "MobileGdbToFileGdb";

		/// <summary>
		/// <para>Tool Excute Name : conversion.MobileGdbToFileGdb</para>
		/// </summary>
		public override string ExcuteName() => "conversion.MobileGdbToFileGdb";

		/// <summary>
		/// <para>Toolbox Display Name : Conversion Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Conversion Tools";

		/// <summary>
		/// <para>Toolbox Alise : conversion</para>
		/// </summary>
		public override string ToolboxAlise() => "conversion";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InMobileGdb, OutFileGdb };

		/// <summary>
		/// <para>Input Mobile Geodatabase</para>
		/// <para>The mobile geodatabase that will have its contents copied to a new file geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("geodatabase")]
		public object InMobileGdb { get; set; }

		/// <summary>
		/// <para>Output File Geodatabase</para>
		/// <para>The name and location of the output file geodatabase, for example, c:\temp\outputGeodatabases\copiedFGDB.gdb.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("gdb")]
		public object OutFileGdb { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MobileGdbToFileGdb SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
