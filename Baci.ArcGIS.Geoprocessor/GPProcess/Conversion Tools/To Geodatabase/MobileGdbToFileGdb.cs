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
	/// <para>移动地理数据库到文件地理数据库</para>
	/// <para>将移动地理数据库的内容复制到新的文件地理数据库中。</para>
	/// </summary>
	public class MobileGdbToFileGdb : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InMobileGdb">
		/// <para>Input Mobile Geodatabase</para>
		/// <para>此移动地理数据库会将其内容复制到新的文件地理数据库。</para>
		/// </param>
		/// <param name="OutFileGdb">
		/// <para>Output File Geodatabase</para>
		/// <para>输出文件地理数据库的名称和位置，例如，c:\temp\outputGeodatabases\copiedFGDB.gdb。</para>
		/// </param>
		public MobileGdbToFileGdb(object InMobileGdb, object OutFileGdb)
		{
			this.InMobileGdb = InMobileGdb;
			this.OutFileGdb = OutFileGdb;
		}

		/// <summary>
		/// <para>Tool Display Name : 移动地理数据库到文件地理数据库</para>
		/// </summary>
		public override string DisplayName() => "移动地理数据库到文件地理数据库";

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
		/// <para>此移动地理数据库会将其内容复制到新的文件地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("geodatabase")]
		public object InMobileGdb { get; set; }

		/// <summary>
		/// <para>Output File Geodatabase</para>
		/// <para>输出文件地理数据库的名称和位置，例如，c:\temp\outputGeodatabases\copiedFGDB.gdb。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("gdb")]
		public object OutFileGdb { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public MobileGdbToFileGdb SetEnviroment(object? workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
