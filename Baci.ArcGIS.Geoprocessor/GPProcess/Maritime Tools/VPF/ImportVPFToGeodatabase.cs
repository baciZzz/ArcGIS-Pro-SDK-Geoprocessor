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
	/// <para>Import VPF To Geodatabase</para>
	/// <para>Imports Vector Product Format (VPF) data in Digital Nautical Chart (DNC) and Tactical Ocean Data (TOD) formats into an ArcGIS Maritime geodatabase. Sources that can be imported include DNC and TOD0, TOD2, and TOD4.</para>
	/// </summary>
	public class ImportVPFToGeodatabase : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InVpfFeatures">
		/// <para>Input VPF Features</para>
		/// <para>The VPF data to be imported into the geodatabase from a folder that contains one or more libraries. Point, line, polygon, and Ecrtext annotation features can be imported.</para>
		/// </param>
		/// <param name="TargetWorkspace">
		/// <para>Target Workspace</para>
		/// <para>The geodatabase to which the VPF data will be imported. This can be an empty template or existing geodatabase.</para>
		/// </param>
		public ImportVPFToGeodatabase(object InVpfFeatures, object TargetWorkspace)
		{
			this.InVpfFeatures = InVpfFeatures;
			this.TargetWorkspace = TargetWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : Import VPF To Geodatabase</para>
		/// </summary>
		public override string DisplayName => "Import VPF To Geodatabase";

		/// <summary>
		/// <para>Tool Name : ImportVPFToGeodatabase</para>
		/// </summary>
		public override string ToolName => "ImportVPFToGeodatabase";

		/// <summary>
		/// <para>Tool Excute Name : maritime.ImportVPFToGeodatabase</para>
		/// </summary>
		public override string ExcuteName => "maritime.ImportVPFToGeodatabase";

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
		public override object[] Parameters => new object[] { InVpfFeatures, TargetWorkspace, OutputWorkspace };

		/// <summary>
		/// <para>Input VPF Features</para>
		/// <para>The VPF data to be imported into the geodatabase from a folder that contains one or more libraries. Point, line, polygon, and Ecrtext annotation features can be imported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InVpfFeatures { get; set; }

		/// <summary>
		/// <para>Target Workspace</para>
		/// <para>The geodatabase to which the VPF data will be imported. This can be an empty template or existing geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object TargetWorkspace { get; set; }

		/// <summary>
		/// <para>Output Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object? OutputWorkspace { get; set; }

	}
}
