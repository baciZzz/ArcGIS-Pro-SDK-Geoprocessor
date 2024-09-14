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
	/// <para>Import FAA 18B Shapefiles</para>
	/// <para>Import FAA 18B Shapefiles</para>
	/// <para>Imports one or more FAA Advisory Circular 150/5300-18B compliant shapefiles into a geodatabase that contains the ArcGIS Aviation Airports schema.</para>
	/// </summary>
	public class ImportFAA18BShapefiles : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Shapefiles</para>
		/// <para>The FAA 18B shapefiles to be imported into a geodatabase.</para>
		/// </param>
		/// <param name="AirportsWorkspace">
		/// <para>Target Geodatabase</para>
		/// <para>The geodatabase into which the shapefiles will be imported.</para>
		/// </param>
		public ImportFAA18BShapefiles(object InFeatures, object AirportsWorkspace)
		{
			this.InFeatures = InFeatures;
			this.AirportsWorkspace = AirportsWorkspace;
		}

		/// <summary>
		/// <para>Tool Display Name : Import FAA 18B Shapefiles</para>
		/// </summary>
		public override string DisplayName() => "Import FAA 18B Shapefiles";

		/// <summary>
		/// <para>Tool Name : ImportFAA18BShapefiles</para>
		/// </summary>
		public override string ToolName() => "ImportFAA18BShapefiles";

		/// <summary>
		/// <para>Tool Excute Name : aviation.ImportFAA18BShapefiles</para>
		/// </summary>
		public override string ExcuteName() => "aviation.ImportFAA18BShapefiles";

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
		public override object[] Parameters() => new object[] { InFeatures, AirportsWorkspace, OutWorkspace };

		/// <summary>
		/// <para>Input Shapefiles</para>
		/// <para>The FAA 18B shapefiles to be imported into a geodatabase.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPMultiValue()]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Target Geodatabase</para>
		/// <para>The geodatabase into which the shapefiles will be imported.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[DEWorkspace()]
		public object AirportsWorkspace { get; set; }

		/// <summary>
		/// <para>Output Geodatabase</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[DEWorkspace()]
		public object OutWorkspace { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ImportFAA18BShapefiles SetEnviroment(object workspace = null)
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
