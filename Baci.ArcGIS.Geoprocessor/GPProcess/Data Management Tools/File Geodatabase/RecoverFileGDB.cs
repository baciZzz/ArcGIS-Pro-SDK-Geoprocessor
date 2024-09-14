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
	/// <para>Recover File Geodatabase</para>
	/// <para>恢复文件地理数据库</para>
	/// <para>从已损坏的文件地理数据库中恢复数据。</para>
	/// </summary>
	public class RecoverFileGDB : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFileGdb">
		/// <para>Input File Geodatabase</para>
		/// <para>输入损坏的文件地理数据库。</para>
		/// </param>
		/// <param name="OutputLocation">
		/// <para>Output Location</para>
		/// <para>恢复文件地理数据库的输出文件夹位置。</para>
		/// </param>
		/// <param name="OutName">
		/// <para>File Geodatabase Name</para>
		/// <para>输出文件地理数据库的名称。</para>
		/// </param>
		public RecoverFileGDB(object InputFileGdb, object OutputLocation, object OutName)
		{
			this.InputFileGdb = InputFileGdb;
			this.OutputLocation = OutputLocation;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : 恢复文件地理数据库</para>
		/// </summary>
		public override string DisplayName() => "恢复文件地理数据库";

		/// <summary>
		/// <para>Tool Name : RecoverFileGDB</para>
		/// </summary>
		public override string ToolName() => "RecoverFileGDB";

		/// <summary>
		/// <para>Tool Excute Name : management.RecoverFileGDB</para>
		/// </summary>
		public override string ExcuteName() => "management.RecoverFileGDB";

		/// <summary>
		/// <para>Toolbox Display Name : Data Management Tools</para>
		/// </summary>
		public override string ToolboxDisplayName() => "Data Management Tools";

		/// <summary>
		/// <para>Toolbox Alise : management</para>
		/// </summary>
		public override string ToolboxAlise() => "management";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments() => new string[] { };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InputFileGdb, OutputLocation, OutName, OutFileGdb };

		/// <summary>
		/// <para>Input File Geodatabase</para>
		/// <para>输入损坏的文件地理数据库。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object InputFileGdb { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>恢复文件地理数据库的输出文件夹位置。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutputLocation { get; set; }

		/// <summary>
		/// <para>File Geodatabase Name</para>
		/// <para>输出文件地理数据库的名称。</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Output File Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutFileGdb { get; set; }

	}
}
