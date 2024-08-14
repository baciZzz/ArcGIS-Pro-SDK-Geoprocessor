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
	/// <para>Import S-100 Cell</para>
	/// <para>Imports S-100 hydrographic data into a geodatabase created from a related S-100 feature catalogue.</para>
	/// </summary>
	public class ImportS100Cell : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatureCatalogue">
		/// <para>S-100 Feature Catalogue</para>
		/// <para>An S-100 feature catalogue document that describes the content of a data product and specification.</para>
		/// </param>
		/// <param name="InBaseCell">
		/// <para>S-100 Cell</para>
		/// <para>The base file in the S-100 format.</para>
		/// </param>
		/// <param name="TargetWorkspace">
		/// <para>Target Workspace</para>
		/// <para>The geodatabase to which all output data will be written.</para>
		/// </param>
		public ImportS100Cell(object InFeatureCatalogue, object InBaseCell, object TargetWorkspace)
		{
			this.InFeatureCatalogue = InFeatureCatalogue;
			this.InBaseCell = InBaseCell;
			this.TargetWorkspace = TargetWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : Import S-100 Cell</para>
		/// </summary>
		public override string DisplayName => "Import S-100 Cell";

		/// <summary>
		/// <para>Tool Name : ImportS100Cell</para>
		/// </summary>
		public override string ToolName => "ImportS100Cell";

		/// <summary>
		/// <para>Tool Excute Name : maritime.ImportS100Cell</para>
		/// </summary>
		public override string ExcuteName => "maritime.ImportS100Cell";

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
		public override string[] ValidEnvironments => new string[] { "S100FeatureCatalogueFile", "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters => new object[] { InFeatureCatalogue, InBaseCell, TargetWorkspace, InUpdateCells, OutputWorkspace };

		/// <summary>
		/// <para>S-100 Feature Catalogue</para>
		/// <para>An S-100 feature catalogue document that describes the content of a data product and specification.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object InFeatureCatalogue { get; set; }

		/// <summary>
		/// <para>S-100 Cell</para>
		/// <para>The base file in the S-100 format.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFile()]
		[GPFileDomain()]
		public object InBaseCell { get; set; }

		/// <summary>
		/// <para>Target Workspace</para>
		/// <para>The geodatabase to which all output data will be written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		[GPWorkspaceDomain()]
		public object TargetWorkspace { get; set; }

		/// <summary>
		/// <para>S-100 Update Cells</para>
		/// <para>An update to a base file in the S-100 format.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPFileDomain()]
		public object InUpdateCells { get; set; }

		/// <summary>
		/// <para>Output Workspace</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutputWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportS100Cell SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
