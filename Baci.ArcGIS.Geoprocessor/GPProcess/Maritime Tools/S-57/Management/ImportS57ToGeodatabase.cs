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
	/// <para>Import S-57 To Geodatabase</para>
	/// <para>Imports an S-57 file into an ArcGIS Maritime geodatabase. Sources that can be imported include Electronic Navigational Chart (ENC), Additional Military layers (AML), and Inland Electronic Navigational Chart (IENC).</para>
	/// </summary>
	public class ImportS57ToGeodatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InBaseCell">
		/// <para>Input Base S-57 Cell</para>
		/// <para>The base cell file (*.000).</para>
		/// </param>
		/// <param name="TargetWorkspace">
		/// <para>Target Workspace</para>
		/// <para>The workspace where all the objects will be written.</para>
		/// </param>
		public ImportS57ToGeodatabase(object InBaseCell, object TargetWorkspace)
		{
			this.InBaseCell = InBaseCell;
			this.TargetWorkspace = TargetWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : Import S-57 To Geodatabase</para>
		/// </summary>
		public override string DisplayName => "Import S-57 To Geodatabase";

		/// <summary>
		/// <para>Tool Name : ImportS57ToGeodatabase</para>
		/// </summary>
		public override string ToolName => "ImportS57ToGeodatabase";

		/// <summary>
		/// <para>Tool Excute Name : maritime.ImportS57ToGeodatabase</para>
		/// </summary>
		public override string ExcuteName => "maritime.ImportS57ToGeodatabase";

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
		public override string[] ValidEnvironments => new string[] { "scratchWorkspace", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InBaseCell, TargetWorkspace, InUpdateCells, InProductConfig, OutputWorkspace };

		/// <summary>
		/// <para>Input Base S-57 Cell</para>
		/// <para>The base cell file (*.000).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object InBaseCell { get; set; }

		/// <summary>
		/// <para>Target Workspace</para>
		/// <para>The workspace where all the objects will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object TargetWorkspace { get; set; }

		/// <summary>
		/// <para>Update Cells</para>
		/// <para>Updates cell files (*.001 - *.999).</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFileDomain()]
		public object InUpdateCells { get; set; }

		/// <summary>
		/// <para>Product Configuration File</para>
		/// <para>The product configuration file to import.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		public object InProductConfig { get; set; }

		/// <summary>
		/// <para>Output Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutputWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportS57ToGeodatabase SetEnviroment(object scratchWorkspace = null , object workspace = null )
		{
			base.SetEnv(scratchWorkspace: scratchWorkspace, workspace: workspace);
			return this;
		}

	}
}
