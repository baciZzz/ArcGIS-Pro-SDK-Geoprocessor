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
	/// <para>Recover File Geodatabase</para>
	/// <para>Recovers data from a file geodatabase that has become corrupt.</para>
	/// </summary>
	public class RecoverFileGDB : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InputFileGdb">
		/// <para>Input File Geodatabase</para>
		/// <para>Input corrupt file geodatabase.</para>
		/// </param>
		/// <param name="OutputLocation">
		/// <para>Output Location</para>
		/// <para>Output folder location for the recovered file geodatabase.</para>
		/// </param>
		/// <param name="OutName">
		/// <para>File Geodatabase Name</para>
		/// <para>Name for the output file geodatabase.</para>
		/// </param>
		public RecoverFileGDB(object InputFileGdb, object OutputLocation, object OutName)
		{
			this.InputFileGdb = InputFileGdb;
			this.OutputLocation = OutputLocation;
			this.OutName = OutName;
		}

		/// <summary>
		/// <para>Tool Display Name : Recover File Geodatabase</para>
		/// </summary>
		public override string DisplayName() => "Recover File Geodatabase";

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
		public override object[] Parameters() => new object[] { InputFileGdb, OutputLocation, OutName, OutFileGdb! };

		/// <summary>
		/// <para>Input File Geodatabase</para>
		/// <para>Input corrupt file geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object InputFileGdb { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>Output folder location for the recovered file geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutputLocation { get; set; }

		/// <summary>
		/// <para>File Geodatabase Name</para>
		/// <para>Name for the output file geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object OutName { get; set; }

		/// <summary>
		/// <para>Output File Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutFileGdb { get; set; }

	}
}
