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
	/// <para>Export FAA 18B Shapefiles</para>
	/// <para>Export FAA 18B Shapefiles</para>
	/// <para>Exports one or more FAA Advisory Circular 150/5300-18B compliant shapefiles from a geodatabase that contains the ArcGIS Aviation Airports schema.</para>
	/// </summary>
	public class ExportFAA18BShapefiles : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InWorkspace">
		/// <para>Input Airport Geodatabase</para>
		/// <para>The workspace that contains the airport data.</para>
		/// </param>
		/// <param name="TargetFolder">
		/// <para>Target Folder</para>
		/// <para>The folder to which shapefiles are written.</para>
		/// </param>
		public ExportFAA18BShapefiles(object InWorkspace, object TargetFolder)
		{
			this.InWorkspace = InWorkspace;
			this.TargetFolder = TargetFolder;
		}

		/// <summary>
		/// <para>Tool Display Name : Export FAA 18B Shapefiles</para>
		/// </summary>
		public override string DisplayName() => "Export FAA 18B Shapefiles";

		/// <summary>
		/// <para>Tool Name : ExportFAA18BShapefiles</para>
		/// </summary>
		public override string ToolName() => "ExportFAA18BShapefiles";

		/// <summary>
		/// <para>Tool Excute Name : aviation.ExportFAA18BShapefiles</para>
		/// </summary>
		public override string ExcuteName() => "aviation.ExportFAA18BShapefiles";

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
		public override string[] ValidEnvironments() => new string[] { "workspace" };

		/// <summary>
		/// <para>Tool Parametrs</para>
		/// </summary>
		public override object[] Parameters() => new object[] { InWorkspace, TargetFolder, InFeatures, OutputFolder };

		/// <summary>
		/// <para>Input Airport Geodatabase</para>
		/// <para>The workspace that contains the airport data.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object InWorkspace { get; set; }

		/// <summary>
		/// <para>Target Folder</para>
		/// <para>The folder to which shapefiles are written.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEFolder()]
		public object TargetFolder { get; set; }

		/// <summary>
		/// <para>Input Feature Class</para>
		/// <para>A list of feature classes to export to shapefiles. If this parameter is not set, all feature classes in the input workspace are exported to shapefiles.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPMultiValue()]
		[GPCodedValueDomain()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Output Folder</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEFolder()]
		public object OutputFolder { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ExportFAA18BShapefiles SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
