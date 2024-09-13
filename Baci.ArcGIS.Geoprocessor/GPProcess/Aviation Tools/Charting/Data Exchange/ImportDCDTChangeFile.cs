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
	/// <para>Import DCDT Change File</para>
	/// <para>Import DCDT Change File</para>
	/// <para>Imports an NGA Digital Chart Data Transaction (DCDT) change file into an aviation geodatabase.</para>
	/// </summary>
	public class ImportDCDTChangeFile : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InChangeFile">
		/// <para>Input DCDT Change File</para>
		/// <para>The NGA DCDT change file is a Microsoft Access .mdb or .accdb file with changes to be loaded for the current chart cycle.</para>
		/// </param>
		/// <param name="TargetGdb">
		/// <para>Target Geodatabase</para>
		/// <para>The Aviation charting schema workspace where the changes will be loaded.</para>
		/// </param>
		/// <param name="CurrentCycleDate">
		/// <para>Current Cycle Date</para>
		/// <para>The date of the current charting cycle.</para>
		/// </param>
		public ImportDCDTChangeFile(object InChangeFile, object TargetGdb, object CurrentCycleDate)
		{
			this.InChangeFile = InChangeFile;
			this.TargetGdb = TargetGdb;
			this.CurrentCycleDate = CurrentCycleDate;
		}

		/// <summary>
		/// <para>Tool Display Name : Import DCDT Change File</para>
		/// </summary>
		public override string DisplayName() => "Import DCDT Change File";

		/// <summary>
		/// <para>Tool Name : ImportDCDTChangeFile</para>
		/// </summary>
		public override string ToolName() => "ImportDCDTChangeFile";

		/// <summary>
		/// <para>Tool Excute Name : aviation.ImportDCDTChangeFile</para>
		/// </summary>
		public override string ExcuteName() => "aviation.ImportDCDTChangeFile";

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
		public override object[] Parameters() => new object[] { InChangeFile, TargetGdb, CurrentCycleDate, UpdatedGdb! };

		/// <summary>
		/// <para>Input DCDT Change File</para>
		/// <para>The NGA DCDT change file is a Microsoft Access .mdb or .accdb file with changes to be loaded for the current chart cycle.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("accdb", "mdb")]
		public object InChangeFile { get; set; }

		/// <summary>
		/// <para>Target Geodatabase</para>
		/// <para>The Aviation charting schema workspace where the changes will be loaded.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object TargetGdb { get; set; }

		/// <summary>
		/// <para>Current Cycle Date</para>
		/// <para>The date of the current charting cycle.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPDate()]
		public object CurrentCycleDate { get; set; }

		/// <summary>
		/// <para>Output Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? UpdatedGdb { get; set; }

	}
}
