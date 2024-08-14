using Baci.ArcGIS.Geoprocessor.Models;
using Baci.ArcGIS.Geoprocessor.Models.Attributes;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.Domains;
using Baci.ArcGIS.Geoprocessor.Models.Attributes.DataTypes;
using Baci.ArcGIS.Geoprocessor.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Baci.ArcGIS.Geoprocessor.MaritimeTools
{
	/// <summary>
	/// <para>Export Geodatabase To VPF</para>
	/// <para>Exports hydrographic data from maritime geodatabases to Vector Product Format (VPF).</para>
	/// </summary>
	public class ExportGeodatabaseToVPF : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InSourceGdb">
		/// <para>Source Geodatabase(s)</para>
		/// <para>The source geodatabases that will be exported.</para>
		/// </param>
		/// <param name="NtmDate">
		/// <para>Notice to Mariners Date</para>
		/// <para>The Notice to Mariners date of the source geodatabases.</para>
		/// </param>
		/// <param name="OutLocation">
		/// <para>Output Location</para>
		/// <para>The location where the export package will be written.</para>
		/// </param>
		public ExportGeodatabaseToVPF(object InSourceGdb, object NtmDate, object OutLocation)
		{
			this.InSourceGdb = InSourceGdb;
			this.NtmDate = NtmDate;
			this.OutLocation = OutLocation;
		}

		/// <summary>
		/// <para>Tool Display Name : Export Geodatabase To VPF</para>
		/// </summary>
		public override string DisplayName => "Export Geodatabase To VPF";

		/// <summary>
		/// <para>Tool Name : ExportGeodatabaseToVPF</para>
		/// </summary>
		public override string ToolName => "ExportGeodatabaseToVPF";

		/// <summary>
		/// <para>Tool Excute Name : maritime.ExportGeodatabaseToVPF</para>
		/// </summary>
		public override string ExcuteName => "maritime.ExportGeodatabaseToVPF";

		/// <summary>
		/// <para>Toolbox Display Name : Maritime Tools</para>
		/// </summary>
		public override string ToolboxDisplayName => "Maritime Tools";

		/// <summary>
		/// <para>Toolbox Alise : maritime</para>
		/// </summary>
		public override string ToolboxAlise => "maritime";

		/// <summary>
		/// <para>Valid Environment Params</para>
		/// </summary>
		public override string[] ValidEnvironments => new string[] {  };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InSourceGdb, NtmDate, OutLocation, OutVpfFolder! };

		/// <summary>
		/// <para>Source Geodatabase(s)</para>
		/// <para>The source geodatabases that will be exported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		[GPWorkspaceDomain()]
		public object InSourceGdb { get; set; }

		/// <summary>
		/// <para>Notice to Mariners Date</para>
		/// <para>The Notice to Mariners date of the source geodatabases.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPString()]
		public object NtmDate { get; set; }

		/// <summary>
		/// <para>Output Location</para>
		/// <para>The location where the export package will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object OutLocation { get; set; }

		/// <summary>
		/// <para>Output VPF Library</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object? OutVpfFolder { get; set; }

	}
}
