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
	/// <para>ICAO Annex 15</para>
	/// <para>Creates obstruction identification surfaces (OIS) based on the ICAO Annex 15 specification (Areas 2a, 2b, and 2c). These surfaces assist in determining the height restriction or removal of obstacles that pose a hazard to air navigation in and around an aerodrome. This tool creates surfaces as a polygon or multipatch features.</para>
	/// </summary>
	public class ICAOAnnex15 : AbstractGPProcess
	{
		/// <summary>
		/// <para>Constructor that takes all required parameters for geoprocessor execution.</para>
		/// </summary>
		/// <param name="InFeatures">
		/// <para>Input Runway Features</para>
		/// <para>The input runway dataset. The feature class must be z-enabled and contain polylines.</para>
		/// </param>
		/// <param name="Target">
		/// <para>Target OIS Features</para>
		/// <para>The target feature class that will contain the generated obstruction identification surfaces.</para>
		/// </param>
		public ICAOAnnex15(object InFeatures, object Target)
		{
			this.InFeatures = InFeatures;
			this.Target = Target;
		}

		/// <summary>
		/// <para>Tool Display Name : ICAO Annex 15</para>
		/// </summary>
		public override string DisplayName() => "ICAO Annex 15";

		/// <summary>
		/// <para>Tool Name : ICAOAnnex15</para>
		/// </summary>
		public override string ToolName() => "ICAOAnnex15";

		/// <summary>
		/// <para>Tool Excute Name : aviation.ICAOAnnex15</para>
		/// </summary>
		public override string ExcuteName() => "aviation.ICAOAnnex15";

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
		public override object[] Parameters() => new object[] { InFeatures, Target, HighendClearWayLength, LowendClearWayLength, DerivedOutfeatureclass, CustomJsonFile, AirportControlPointFeatureClass };

		/// <summary>
		/// <para>Input Runway Features</para>
		/// <para>The input runway dataset. The feature class must be z-enabled and contain polylines.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Polyline")]
		public object InFeatures { get; set; }

		/// <summary>
		/// <para>Target OIS Features</para>
		/// <para>The target feature class that will contain the generated obstruction identification surfaces.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.must)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object Target { get; set; }

		/// <summary>
		/// <para>Length of High Runway End Clearway</para>
		/// <para>The length of the area at the high end of the runway. The unit of measurement is based on the input runway features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object HighendClearWayLength { get; set; } = "0";

		/// <summary>
		/// <para>Length of Low Runway End Clearway</para>
		/// <para>The length of the area at the low end of the runway. The unit of measurement is based on the input runway features.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPDouble()]
		public object LowendClearWayLength { get; set; } = "0";

		/// <summary>
		/// <para>Output OIS Features</para>
		/// </summary>
		[ParamType(ParamTypeEnum.derived)]
		[GPFeatureLayer()]
		[GPCompositeDomain()]
		public object DerivedOutfeatureclass { get; set; }

		/// <summary>
		/// <para>Custom JSON File</para>
		/// <para>The import configuration, in JSON format, that creates the custom OIS.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[DEFile()]
		[GPFileDomain()]
		[FileTypes("json")]
		public object CustomJsonFile { get; set; }

		/// <summary>
		/// <para>Input Airport Control Point Feature</para>
		/// <para>Supplies x-, y-, and z-geometry for displaced threshold features. If displaced thresholds are included, surfaces will be constructed based on their x-, y-, and z-geometry instead of their corresponding runway feature endpoint.</para>
		/// </summary>
		[ParamType(ParamTypeEnum.optional)]
		[GPFeatureLayer()]
		[GPFeatureClassDomain()]
		[GeometryType("Point")]
		public object AirportControlPointFeatureClass { get; set; }

		/// <summary>
		/// <para>Only Set The Valid Environment For This Tool</para>
		/// </summary>
		public ICAOAnnex15 SetEnviroment(object workspace = null )
		{
			base.SetEnv(workspace: workspace);
			return this;
		}

	}
}
